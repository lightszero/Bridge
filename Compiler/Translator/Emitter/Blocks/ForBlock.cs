using Bridge.Contract;
using Bridge.Contract.Constants;
using ICSharpCode.NRefactory.CSharp;
using System.Collections.Generic;
using System.Linq;

namespace Bridge.Translator
{
    public class ForBlock : AbstractEmitterBlock
    {
        public ForBlock(IEmitter emitter, ForStatement forStatement)
            : base(emitter, forStatement)
        {
            this.Emitter = emitter;
            this.ForStatement = forStatement;
        }

        public ForStatement ForStatement
        {
            get;
            set;
        }

        public List<IAsyncStep> EmittedAsyncSteps
        {
            get;
            set;
        }

        protected override void DoEmit()
        {
            var awaiters = this.Emitter.IsAsync ? this.GetAwaiters(this.ForStatement) : null;

            if (awaiters != null && awaiters.Length > 0)
            {
                this.VisitAsyncForStatement();
            }
            else
            {
                this.VisitForStatement();
            }
        }

        protected void VisitAsyncForStatement()
        {
            ForStatement forStatement = this.ForStatement;
            var oldValue = this.Emitter.ReplaceAwaiterByVar;
            var jumpStatements = this.Emitter.JumpStatements;
            this.Emitter.JumpStatements = new List<IJumpInfo>();

            this.PushLocals();

            bool newLine = false;

            foreach (var item in forStatement.Initializers)
            {
                if (newLine)
                {
                    this.WriteNewLine();
                }

                item.AcceptVisitor(this.Emitter);
                newLine = true;
            }

            this.RemovePenultimateEmptyLines(true);
            this.WriteNewLine();
            this.Write(JS.Vars.ASYNC_STEP + " = " + this.Emitter.AsyncBlock.Step + ";");
            this.WriteNewLine();
            this.Write("continue;");

            IAsyncStep conditionStep = this.Emitter.AsyncBlock.AddAsyncStep();
            this.WriteAwaiters(forStatement.Condition);
            this.Emitter.ReplaceAwaiterByVar = true;
            var lastConditionStep = this.Emitter.AsyncBlock.Steps.Last();

            this.WriteIf();
            this.WriteOpenParentheses(true);

            if (!forStatement.Condition.IsNull)
            {
                forStatement.Condition.AcceptVisitor(this.Emitter);
            }
            else
            {
                this.Write("true");
            }

            this.WriteCloseParentheses(true);
            this.Emitter.ReplaceAwaiterByVar = oldValue;

            this.WriteSpace();
            this.BeginBlock();
            this.Write(JS.Vars.ASYNC_STEP + " = " + this.Emitter.AsyncBlock.Step + ";");
            this.WriteNewLine();
            this.Write("continue;");

            this.EmittedAsyncSteps = this.Emitter.AsyncBlock.EmittedAsyncSteps;
            this.Emitter.AsyncBlock.EmittedAsyncSteps = new List<IAsyncStep>();
            var writer = this.SaveWriter();

            this.Emitter.AsyncBlock.AddAsyncStep();
            this.Emitter.IgnoreBlock = forStatement.EmbeddedStatement;
            var startCount = this.Emitter.AsyncBlock.Steps.Count;
            forStatement.EmbeddedStatement.AcceptVisitor(this.Emitter);
            IAsyncStep loopStep = null;

            if (this.Emitter.AsyncBlock.Steps.Count > startCount)
            {
                loopStep = this.Emitter.AsyncBlock.Steps.Last();
            }

            this.RestoreWriter(writer);

            if (!AbstractEmitterBlock.IsJumpStatementLast(this.Emitter.Output.ToString()))
            {
                this.WriteNewLine();
                this.Write(JS.Vars.ASYNC_STEP + " = " + this.Emitter.AsyncBlock.Step + ";");
                this.WriteNewLine();
                this.Write("continue;");
                this.WriteNewLine();
                this.EndBlock();
                this.WriteSpace();
            }
            else
            {
                this.WriteNewLine();
                this.EndBlock();
                this.WriteSpace();
            }

            if (this.Emitter.IsAsync)
            {
                this.Emitter.AsyncBlock.EmittedAsyncSteps = this.EmittedAsyncSteps;
            }

            IAsyncStep iteratorsStep = this.Emitter.AsyncBlock.AddAsyncStep();

            /*foreach (var item in forStatement.Iterators)
            {
                this.WriteAwaiters(item);
            }*/

            var lastIteratorStep = this.Emitter.AsyncBlock.Steps.Last();

            if (loopStep != null)
            {
                loopStep.JumpToStep = iteratorsStep.Step;
            }

            lastIteratorStep.JumpToStep = conditionStep.Step;
            this.Emitter.ReplaceAwaiterByVar = true;

            var beforeStepsCount = this.Emitter.AsyncBlock.Steps.Count;
            foreach (var item in forStatement.Iterators)
            {
                item.AcceptVisitor(this.Emitter);

                if (this.Emitter.Output.ToString().TrimEnd().Last() != ';')
                {
                    this.WriteSemiColon();
                }

                this.WriteNewLine();
            }

            if (beforeStepsCount < this.Emitter.AsyncBlock.Steps.Count)
            {
                this.Emitter.AsyncBlock.Steps.Last().JumpToStep = conditionStep.Step;
            }

            this.Emitter.ReplaceAwaiterByVar = oldValue;

            this.PopLocals();
            var nextStep = this.Emitter.AsyncBlock.AddAsyncStep();
            lastConditionStep.JumpToStep = nextStep.Step;

            if (this.Emitter.JumpStatements.Count > 0)
            {
                this.Emitter.JumpStatements.Sort((j1, j2) => -j1.Position.CompareTo(j2.Position));
                foreach (var jump in this.Emitter.JumpStatements)
                {
                    jump.Output.Insert(jump.Position, jump.Break ? nextStep.Step : iteratorsStep.Step);
                }
            }

            this.Emitter.JumpStatements = jumpStatements;
        }

        protected void VisitForStatement()
        {
            ForStatement forStatement = this.ForStatement;
            var jumpStatements = this.Emitter.JumpStatements;
            this.Emitter.JumpStatements = null;

            this.PushLocals();
            this.Emitter.EnableSemicolon = false;

            this.WriteFor();
            this.WriteOpenParentheses();

            var old = this.Emitter.IsAsync;
            this.Emitter.IsAsync = false;
            foreach (var item in forStatement.Initializers)
            {
                if (item != forStatement.Initializers.First())
                {
                    this.WriteComma();
                }

                item.AcceptVisitor(this.Emitter);
            }
            this.Emitter.IsAsync = old;

            this.WriteSemiColon();
            this.WriteSpace();

            if (!forStatement.Condition.IsNull)
            {
                forStatement.Condition.AcceptVisitor(this.Emitter);
            }

            this.WriteSemiColon();
            this.WriteSpace();

            foreach (var item in forStatement.Iterators)
            {
                if (item != forStatement.Iterators.First())
                {
                    this.WriteComma();
                }

                item.AcceptVisitor(this.Emitter);
            }

            this.WriteCloseParentheses();

            this.Emitter.EnableSemicolon = true;

            this.EmitBlockOrIndentedLine(forStatement.EmbeddedStatement);

            this.PopLocals();
            this.Emitter.JumpStatements = jumpStatements;
        }
    }
}