using Bridge.Test.NUnit;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bridge.ClientTest.Threading
{
    [Category(Constants.MODULE_THREADING)]
    [TestFixture(TestNameFormat = "Promise - {0}")]
    public class PromiseTests
    {
        private class SimplePromise : IPromise
        {
            public class A
            {
                public PromiseDelegate Filled { get; set; }
                public PromiseDelegate Error { get; set; }
                public PromiseDelegate Progress { get; set; }
            }

            private enum Which
            {
                Resolve, Reject
            }

            private delegate void Next(PromiseDelegate fulfilledHandler, PromiseDelegate errorHandler = null, PromiseDelegate progressHandler = null);

            public delegate void PromiseDelegate(params object[] args);

            private Next DoThen;

            public List<A> Thens { get; private set; }

            public SimplePromise()
            {
                Thens = new List<A>();

                DoThen = (f, e, p) =>
                {
                    this.Thens.Add(new A() { Filled = f, Error = e, Progress = p });
                };
            }

            public void Then(Delegate fulfilledHandler, Delegate errorHandler = null, Delegate progressHandler = null)
            {
                DoThen((PromiseDelegate)fulfilledHandler, (PromiseDelegate)errorHandler, (PromiseDelegate)progressHandler);
            }

            public void Resolve(params object[] args)
            {
                Complete(Which.Resolve, args);
            }

            public void Reject(params object[] args)
            {
                Complete(Which.Reject, args);
            }

            public void Progress(params object[] args)
            {
                var i = 0;
                while (i < Thens.Count)
                {
                    var aThen = Thens[i];

                    if (aThen.Progress != null)
                    {
                        aThen.Progress(args);
                    }

                    i++;
                }
            }

            private void Complete(Which which, params object[] args)
            {
                if (which == Which.Resolve)
                {
                    DoThen = (f, e, p) => { Resolve(args); };
                }
                else
                {
                    DoThen = (f, e, p) => { Reject(args); };
                }

                var i = 0;
                while (i < Thens.Count)
                {
                    var aThen = Thens[i];

                    if (which == Which.Resolve)
                    {
                        if (aThen.Filled != null)
                        {
                            aThen.Filled.Apply(null, args);
                        }
                    }
                    else
                    {
                        if (aThen.Error != null)
                        {
                            aThen.Error.Apply(null, args);
                        }
                    }

                    if (aThen.Progress != null)
                    {
                        aThen.Progress(100);
                    }

                    i++;
                }
                Thens.Clear();
            }
        }

        private SimplePromise CreatePromise()
        {
            return new SimplePromise();
        }

        private class TaskResult
        {
            public int I { get; set; }
            public string S { get; set; }
            public int J { get; set; }

            public delegate TaskResult TaskResultHandler(object i, object s, object j);
        }

        [Test(ExpectedCount = 7)]
        public void TaskFromPromiseWithoutResultFactoryWorksWhenPromiseCompletes()
        {
            var completeAsync = Assert.Async();

            var promise = CreatePromise();
            var task = Task.FromPromise(promise);

            Assert.AreEqual(TaskStatus.Running, task.Status, "Task should be running after being created");

            bool continuationRun = false;

            var task1 = task.ContinueWith(t =>
                {
                    Assert.True(t == task, "ContinueWith parameter should be correct");
                    continuationRun = true;
                });

            Assert.False(continuationRun, "Continuation should not be run too early.");
            Assert.AreEqual(TaskStatus.Running, task.Status, "Task should be running before promise is completed.");
            promise.Resolve(42, "result 123", 101);

            task1.ContinueWith(x =>
                {
                    Assert.AreEqual(TaskStatus.RanToCompletion, task.Status, "Task should be completed after promise");
                    Assert.True(continuationRun, "Continuation should have been run after promise was completed.");
                    Assert.AreDeepEqual(new object[] { 42, "result 123", 101 }, task.Result, "The result should be correct");

                    completeAsync();
                });
        }

        [Test(ExpectedCount = 7)]
        public void TaskFromPromiseWithResultFactoryWorksWhenPromiseCompletes()
        {
            var completeAsync = Assert.Async();

            TaskResult.TaskResultHandler trh = (object i, object s, object j) => { return new TaskResult() { I = (int)i, S = (string)s, J = (int)j }; };

            var promise = CreatePromise();
            var task = Task.FromPromise<TaskResult>(promise, trh);

            Assert.AreEqual(TaskStatus.Running, task.Status, "Task should be running after being created");

            bool continuationRun = false;

            var task1 = task.ContinueWith(t =>
                {
                    Assert.True(t == task, "ContinueWith parameter should be correct");
                    continuationRun = true;
                });

            Assert.False(continuationRun, "Continuation should not be run too early.");
            Assert.AreEqual(TaskStatus.Running, task.Status, "Task should be running before promise is completed.");
            promise.Resolve(42, "result 123", 101);

            task1.ContinueWith(x =>
                {
                    Assert.AreEqual(TaskStatus.RanToCompletion, task.Status, "Task should be completed after promise");
                    Assert.True(continuationRun, "Continuation should have been run after promise was completed.");
                    Assert.AreDeepEqual(new TaskResult()
                    {
                        I = 42,
                        S = "result 123",
                        J = 101
                    }, task.Result);

                    completeAsync();
                });
        }

        [Test(ExpectedCount = 10)]
        public void TaskFromPromiseWorksWhenPromiseFails()
        {
            var completeAsync = Assert.Async();

            var promise = CreatePromise();
            var task = Task.FromPromise(promise);

            Assert.AreEqual(TaskStatus.Running, task.Status, "Task should be running after being created");

            bool continuationRun = false;

            var task1 = task.ContinueWith(t =>
                {
                    Assert.True(t == task, "ContinueWith parameter should be correct");
                    continuationRun = true;
                });

            Assert.False(continuationRun, "Continuation should not be run too early.");
            Assert.AreEqual(TaskStatus.Running, task.Status, "Task should be running before promise is completed.");
            promise.Reject(42, "result 123", 101);

            task1.ContinueWith(x =>
                {
                    Assert.AreEqual(TaskStatus.Faulted, task.Status, "Task should have faulted after the promise was rejected.");
                    Assert.True(continuationRun, "Continuation should have been run after promise was rejected.");
                    Assert.True((object)task.Exception is AggregateException, "Exception should be an AggregateException");
                    Assert.AreEqual(1, task.Exception.InnerExceptions.Count, "Exception should have one inner exception");
                    Assert.True(task.Exception.InnerExceptions[0] is PromiseException, "Inner exception should be a PromiseException");
                    Assert.AreDeepEqual(new object[] { 42, "result 123", 101 }, ((PromiseException)task.Exception.InnerExceptions[0]).Arguments, "The PromiseException arguments should be correct");

                    completeAsync();
                });
        }

        [Test(ExpectedCount = 3)]
        public async void CompletingPromiseCanBeAwaited()
        {
            var completeAsync = Assert.Async();

            var promise = CreatePromise();
            object[] result = null;

            var task = Task.Run(() =>
               {
                   Assert.True(result == null, "Await should not finish too early (a).");
                   promise.Resolve(42, "result 123", 101);
               });

            Assert.True(result == null, "Await should not finish too early (b).");

            result = await promise;

            Assert.AreEqual(new object[] { 42, "result 123", 101 }, result, "The result should be correct");
            completeAsync();
        }

        [Test(ExpectedCount = 4)]
        public async void FailingPromiseCanBeAwaited()
        {
            var completeAsync = Assert.Async();

            var promise = CreatePromise();

            bool continuationRun = false;

            var task = Task.Run(() =>
                {
                    Assert.False(continuationRun, "Continuation should not be run too early (a).");
                    promise.Reject(42, "result 123", 101);
                });

            try
            {
                Assert.False(continuationRun, "Continuation should not be run too early (b).");
                await promise;

                Assert.Fail("Await should throw");
            }
            catch (PromiseException ex)
            {
                continuationRun = true;
                Assert.AreEqual(new object[] { 42, "result 123", 101 }, ex.Arguments, "The PromiseException arguments should be correct");
            }
            catch (Exception ex)
            {
                Assert.Fail("Thrown exception should have been an AggregateException, was " + ex.GetType().FullName);
            }

            Assert.True(continuationRun, "Continuation should have been run after promise was rejected.");

            completeAsync();
        }

        public int PromiseProgress { get; set; }

        private void HandleProgress(params object[] args)
        {
            var i = (int)args[0];
            this.PromiseProgress = i;
        }

        [Test(ExpectedCount = 9)]
        public void TaskFromPromiseWithProgressWithoutResultFactoryWorksWhenPromiseProgressesAndCompletes()
        {
            var completeAsync = Assert.Async();

            var promise = CreatePromise();

            PromiseProgress = -1;
            var task = Task.FromPromise<TaskResult>(promise, null, null, (SimplePromise.PromiseDelegate)HandleProgress);

            Assert.AreEqual(TaskStatus.Running, task.Status, "Task should be running after being created");

            bool continuationRun = false;

            var task1 = task.ContinueWith(t =>
            {
                Assert.True(t == task, "ContinueWith parameter should be correct");
                continuationRun = true;
            });

            Assert.False(continuationRun, "Continuation should not be run too early.");
            Assert.AreEqual(TaskStatus.Running, task.Status, "Task should be running before promise is completed.");

            promise.Progress(20);
            Assert.AreEqual(20, PromiseProgress, "Progress 20");

            // Resolve will set Progress to 100%
            promise.Resolve(42, "result 123", 101);
            Assert.AreEqual(100, PromiseProgress, "Progress 100");

            task1.ContinueWith(x =>
            {
                Assert.AreEqual(TaskStatus.RanToCompletion, task.Status, "Task should be completed after promise");
                Assert.True(continuationRun, "Continuation should have been run after promise was completed.");
                Assert.AreDeepEqual(new object[] { 42, "result 123", 101 }, task.Result, "The result should be correct");

                completeAsync();
            });
        }
    }
}