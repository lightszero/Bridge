    /* decimal.js v7.1.0 https://github.com/MikeMcl/decimal.js/LICENCE */
    !function (n) { "use strict"; function e(n) { var e, i, t, r = n.length - 1, s = "", o = n[0]; if (r > 0) { for (s += o, e = 1; r > e; e++) t = n[e] + "", i = Rn - t.length, i && (s += l(i)), s += t; o = n[e], t = o + "", i = Rn - t.length, i && (s += l(i)) } else if (0 === o) return "0"; for (; o % 10 === 0;) o /= 10; return s + o } function i(n, e, i) { if (n !== ~~n || e > n || n > i) throw Error(En + n) } function t(n, e, i, t) { var r, s, o, u; for (s = n[0]; s >= 10; s /= 10)--e; return --e < 0 ? (e += Rn, r = 0) : (r = Math.ceil((e + 1) / Rn), e %= Rn), s = On(10, Rn - e), u = n[r] % s | 0, null == t ? 3 > e ? (0 == e ? u = u / 100 | 0 : 1 == e && (u = u / 10 | 0), o = 4 > i && 99999 == u || i > 3 && 49999 == u || 5e4 == u || 0 == u) : o = (4 > i && u + 1 == s || i > 3 && u + 1 == s / 2) && (n[r + 1] / s / 100 | 0) == On(10, e - 2) - 1 || (u == s / 2 || 0 == u) && 0 == (n[r + 1] / s / 100 | 0) : 4 > e ? (0 == e ? u = u / 1e3 | 0 : 1 == e ? u = u / 100 | 0 : 2 == e && (u = u / 10 | 0), o = (t || 4 > i) && 9999 == u || !t && i > 3 && 4999 == u) : o = ((t || 4 > i) && u + 1 == s || !t && i > 3 && u + 1 == s / 2) && (n[r + 1] / s / 1e3 | 0) == On(10, e - 3) - 1, o } function r(n, e, i) { for (var t, r, s = [0], o = 0, u = n.length; u > o;) { for (r = s.length; r--;) s[r] *= e; for (s[0] += wn.indexOf(n.charAt(o++)), t = 0; t < s.length; t++) s[t] > i - 1 && (void 0 === s[t + 1] && (s[t + 1] = 0), s[t + 1] += s[t] / i | 0, s[t] %= i) } return s.reverse() } function s(n, e) { var i, t, r = e.d.length; 32 > r ? (i = Math.ceil(r / 3), t = Math.pow(4, -i).toString()) : (i = 16, t = "2.3283064365386962890625e-10"), n.precision += i, e = E(n, 1, e.times(t), new n(1)); for (var s = i; s--;) { var o = e.times(e); e = o.times(o).minus(o).times(8).plus(1) } return n.precision -= i, e } function o(n, e, i, t) { var r, s, o, u, c, f, a, h, l, d = n.constructor; n: if (null != e) { if (h = n.d, !h) return n; for (r = 1, u = h[0]; u >= 10; u /= 10) r++; if (s = e - r, 0 > s) s += Rn, o = e, a = h[l = 0], c = a / On(10, r - o - 1) % 10 | 0; else if (l = Math.ceil((s + 1) / Rn), u = h.length, l >= u) { if (!t) break n; for (; u++ <= l;) h.push(0); a = c = 0, r = 1, s %= Rn, o = s - Rn + 1 } else { for (a = u = h[l], r = 1; u >= 10; u /= 10) r++; s %= Rn, o = s - Rn + r, c = 0 > o ? 0 : a / On(10, r - o - 1) % 10 | 0 } if (t = t || 0 > e || void 0 !== h[l + 1] || (0 > o ? a : a % On(10, r - o - 1)), f = 4 > i ? (c || t) && (0 == i || i == (n.s < 0 ? 3 : 2)) : c > 5 || 5 == c && (4 == i || t || 6 == i && (s > 0 ? o > 0 ? a / On(10, r - o) : 0 : h[l - 1]) % 10 & 1 || i == (n.s < 0 ? 8 : 7)), 1 > e || !h[0]) return h.length = 0, f ? (e -= n.e + 1, h[0] = On(10, (Rn - e % Rn) % Rn), n.e = -e || 0) : h[0] = n.e = 0, n; if (0 == s ? (h.length = l, u = 1, l--) : (h.length = l + 1, u = On(10, Rn - s), h[l] = o > 0 ? (a / On(10, r - o) % On(10, o) | 0) * u : 0), f) for (; ;) { if (0 == l) { for (s = 1, o = h[0]; o >= 10; o /= 10) s++; for (o = h[0] += u, u = 1; o >= 10; o /= 10) u++; s != u && (n.e++, h[0] == Pn && (h[0] = 1)); break } if (h[l] += u, h[l] != Pn) break; h[l--] = 0, u = 1 } for (s = h.length; 0 === h[--s];) h.pop() } return bn && (n.e > d.maxE ? (n.d = null, n.e = NaN) : n.e < d.minE && (n.e = 0, n.d = [0])), n } function u(n, i, t) { if (!n.isFinite()) return v(n); var r, s = n.e, o = e(n.d), u = o.length; return i ? (t && (r = t - u) > 0 ? o = o.charAt(0) + "." + o.slice(1) + l(r) : u > 1 && (o = o.charAt(0) + "." + o.slice(1)), o = o + (n.e < 0 ? "e" : "e+") + n.e) : 0 > s ? (o = "0." + l(-s - 1) + o, t && (r = t - u) > 0 && (o += l(r))) : s >= u ? (o += l(s + 1 - u), t && (r = t - s - 1) > 0 && (o = o + "." + l(r))) : ((r = s + 1) < u && (o = o.slice(0, r) + "." + o.slice(r)), t && (r = t - u) > 0 && (s + 1 === u && (o += "."), o += l(r))), o } function c(n, e) { for (var i = 1, t = n[0]; t >= 10; t /= 10) i++; return i + e * Rn - 1 } function f(n, e, i) { if (e > Un) throw bn = !0, i && (n.precision = i), Error(Mn); return o(new n(mn), e, 1, !0) } function a(n, e, i) { if (e > _n) throw Error(Mn); return o(new n(vn), e, i, !0) } function h(n) { var e = n.length - 1, i = e * Rn + 1; if (e = n[e]) { for (; e % 10 == 0; e /= 10) i--; for (e = n[0]; e >= 10; e /= 10) i++ } return i } function l(n) { for (var e = ""; n--;) e += "0"; return e } function d(n, e, i, t) { var r, s = new n(1), o = Math.ceil(t / Rn + 4); for (bn = !1; ;) { if (i % 2 && (s = s.times(e), q(s.d, o) && (r = !0)), i = qn(i / 2), 0 === i) { i = s.d.length - 1, r && 0 === s.d[i] && ++s.d[i]; break } e = e.times(e), q(e.d, o) } return bn = !0, s } function p(n) { return 1 & n.d[n.d.length - 1] } function g(n, e, i) { for (var t, r = new n(e[0]), s = 0; ++s < e.length;) { if (t = new n(e[s]), !t.s) { r = t; break } r[i](t) && (r = t) } return r } function w(n, i) { var r, s, u, c, f, a, h, l = 0, d = 0, p = 0, g = n.constructor, w = g.rounding, m = g.precision; if (!n.d || !n.d[0] || n.e > 17) return new g(n.d ? n.d[0] ? n.s < 0 ? 0 : 1 / 0 : 1 : n.s ? n.s < 0 ? 0 : n : NaN); for (null == i ? (bn = !1, h = m) : h = i, a = new g(.03125) ; n.e > -2;) n = n.times(a), p += 5; for (s = Math.log(On(2, p)) / Math.LN10 * 2 + 5 | 0, h += s, r = c = f = new g(1), g.precision = h; ;) { if (c = o(c.times(n), h, 1), r = r.times(++d), a = f.plus(Sn(c, r, h, 1)), e(a.d).slice(0, h) === e(f.d).slice(0, h)) { for (u = p; u--;) f = o(f.times(f), h, 1); if (null != i) return g.precision = m, f; if (!(3 > l && t(f.d, h - s, w, l))) return o(f, g.precision = m, w, bn = !0); g.precision = h += 10, r = c = a = new g(1), d = 0, l++ } f = a } } function m(n, i) { var r, s, u, c, a, h, l, d, p, g, w, v = 1, N = 10, b = n, x = b.d, E = b.constructor, M = E.rounding, y = E.precision; if (b.s < 0 || !x || !x[0] || !b.e && 1 == x[0] && 1 == x.length) return new E(x && !x[0] ? -1 / 0 : 1 != b.s ? NaN : x ? 0 : b); if (null == i ? (bn = !1, p = y) : p = i, E.precision = p += N, r = e(x), s = r.charAt(0), !(Math.abs(c = b.e) < 15e14)) return d = f(E, p + 2, y).times(c + ""), b = m(new E(s + "." + r.slice(1)), p - N).plus(d), E.precision = y, null == i ? o(b, y, M, bn = !0) : b; for (; 7 > s && 1 != s || 1 == s && r.charAt(1) > 3;) b = b.times(n), r = e(b.d), s = r.charAt(0), v++; for (c = b.e, s > 1 ? (b = new E("0." + r), c++) : b = new E(s + "." + r.slice(1)), g = b, l = a = b = Sn(b.minus(1), b.plus(1), p, 1), w = o(b.times(b), p, 1), u = 3; ;) { if (a = o(a.times(w), p, 1), d = l.plus(Sn(a, new E(u), p, 1)), e(d.d).slice(0, p) === e(l.d).slice(0, p)) { if (l = l.times(2), 0 !== c && (l = l.plus(f(E, p + 2, y).times(c + ""))), l = Sn(l, new E(v), p, 1), null != i) return E.precision = y, l; if (!t(l.d, p - N, M, h)) return o(l, E.precision = y, M, bn = !0); E.precision = p += N, d = a = b = Sn(g.minus(1), g.plus(1), p, 1), w = o(b.times(b), p, 1), u = h = 1 } l = d, u += 2 } } function v(n) { return String(n.s * n.s / 0) } function N(n, e) { var i, t, r; for ((i = e.indexOf(".")) > -1 && (e = e.replace(".", "")), (t = e.search(/e/i)) > 0 ? (0 > i && (i = t), i += +e.slice(t + 1), e = e.substring(0, t)) : 0 > i && (i = e.length), t = 0; 48 === e.charCodeAt(t) ; t++); for (r = e.length; 48 === e.charCodeAt(r - 1) ; --r); if (e = e.slice(t, r)) { if (r -= t, n.e = i = i - t - 1, n.d = [], t = (i + 1) % Rn, 0 > i && (t += Rn), r > t) { for (t && n.d.push(+e.slice(0, t)), r -= Rn; r > t;) n.d.push(+e.slice(t, t += Rn)); e = e.slice(t), t = Rn - e.length } else t -= r; for (; t--;) e += "0"; n.d.push(+e), bn && (n.e > n.constructor.maxE ? (n.d = null, n.e = NaN) : n.e < n.constructor.minE && (n.e = 0, n.d = [0])) } else n.e = 0, n.d = [0]; return n } function b(n, e) { var i, t, s, o, u, f, a, h, l; if ("Infinity" === e || "NaN" === e) return +e || (n.s = NaN), n.e = NaN, n.d = null, n; if (An.test(e)) i = 16, e = e.toLowerCase(); else if (Fn.test(e)) i = 2; else { if (!Dn.test(e)) throw Error(En + e); i = 8 } for (o = e.search(/p/i), o > 0 ? (a = +e.slice(o + 1), e = e.substring(2, o)) : e = e.slice(2), o = e.indexOf("."), u = o >= 0, t = n.constructor, u && (e = e.replace(".", ""), f = e.length, o = f - o, s = d(t, new t(i), o, 2 * o)), h = r(e, i, Pn), l = h.length - 1, o = l; 0 === h[o]; --o) h.pop(); return 0 > o ? new t(0 * n.s) : (n.e = c(h, l), n.d = h, bn = !1, u && (n = Sn(n, s, 4 * f)), a && (n = n.times(Math.abs(a) < 54 ? Math.pow(2, a) : Nn.pow(2, a))), bn = !0, n) } function x(n, e) { var i, t = e.d.length; if (3 > t) return E(n, 2, e, e); i = 1.4 * Math.sqrt(t), i = i > 16 ? 16 : 0 | i, e = e.times(Math.pow(5, -i)), e = E(n, 2, e, e); for (var r, s = new n(5), o = new n(16), u = new n(20) ; i--;) r = e.times(e), e = e.times(s.plus(r.times(o.times(r).minus(u)))); return e } function E(n, e, i, t, r) { var s, o, u, c, f = 1, a = n.precision, h = Math.ceil(a / Rn); for (bn = !1, c = i.times(i), u = new n(t) ; ;) { if (o = Sn(u.times(c), new n(e++ * e++), a, 1), u = r ? t.plus(o) : t.minus(o), t = Sn(o.times(c), new n(e++ * e++), a, 1), o = u.plus(t), void 0 !== o.d[h]) { for (s = h; o.d[s] === u.d[s] && s--;); if (-1 == s) break } s = u, u = t, t = o, o = s, f++ } return bn = !0, o.d.length = h + 1, o } function M(n, e) { var i, t = e.s < 0, r = a(n, n.precision, 1), s = r.times(.5); if (e = e.abs(), e.lte(s)) return dn = t ? 4 : 1, e; if (i = e.divToInt(r), i.isZero()) dn = t ? 3 : 2; else { if (e = e.minus(i.times(r)), e.lte(s)) return dn = p(i) ? t ? 2 : 3 : t ? 4 : 1, e; dn = p(i) ? t ? 1 : 4 : t ? 3 : 2 } return e.minus(r).abs() } function y(n, e, t, s) { var o, c, f, a, h, l, d, p, g, w = n.constructor, m = void 0 !== t; if (m ? (i(t, 1, gn), void 0 === s ? s = w.rounding : i(s, 0, 8)) : (t = w.precision, s = w.rounding), n.isFinite()) { for (d = u(n), f = d.indexOf("."), m ? (o = 2, 16 == e ? t = 4 * t - 3 : 8 == e && (t = 3 * t - 2)) : o = e, f >= 0 && (d = d.replace(".", ""), g = new w(1), g.e = d.length - f, g.d = r(u(g), 10, o), g.e = g.d.length), p = r(d, 10, o), c = h = p.length; 0 == p[--h];) p.pop(); if (p[0]) { if (0 > f ? c-- : (n = new w(n), n.d = p, n.e = c, n = Sn(n, g, t, s, 0, o), p = n.d, c = n.e, l = hn), f = p[t], a = o / 2, l = l || void 0 !== p[t + 1], l = 4 > s ? (void 0 !== f || l) && (0 === s || s === (n.s < 0 ? 3 : 2)) : f > a || f === a && (4 === s || l || 6 === s && 1 & p[t - 1] || s === (n.s < 0 ? 8 : 7)), p.length = t, l) for (; ++p[--t] > o - 1;) p[t] = 0, t || (++c, p.unshift(1)); for (h = p.length; !p[h - 1]; --h); for (f = 0, d = ""; h > f; f++) d += wn.charAt(p[f]); if (m) { if (h > 1) if (16 == e || 8 == e) { for (f = 16 == e ? 4 : 3, --h; h % f; h++) d += "0"; for (p = r(d, o, e), h = p.length; !p[h - 1]; --h); for (f = 1, d = "1."; h > f; f++) d += wn.charAt(p[f]) } else d = d.charAt(0) + "." + d.slice(1); d = d + (0 > c ? "p" : "p+") + c } else if (0 > c) { for (; ++c;) d = "0" + d; d = "0." + d } else if (++c > h) for (c -= h; c--;) d += "0"; else h > c && (d = d.slice(0, c) + "." + d.slice(c)) } else d = m ? "0p+0" : "0"; d = (16 == e ? "0x" : 2 == e ? "0b" : 8 == e ? "0o" : "") + d } else d = v(n); return n.s < 0 ? "-" + d : d } function q(n, e) { return n.length > e ? (n.length = e, !0) : void 0 } function O(n) { return new this(n).abs() } function F(n) { return new this(n).acos() } function A(n) { return new this(n).acosh() } function D(n, e) { return new this(n).plus(e) } function Z(n) { return new this(n).asin() } function P(n) { return new this(n).asinh() } function R(n) { return new this(n).atan() } function L(n) { return new this(n).atanh() } function U(n, e) { n = new this(n), e = new this(e); var i, t = this.precision, r = this.rounding, s = t + 4; return n.s && e.s ? n.d || e.d ? !e.d || n.isZero() ? (i = e.s < 0 ? a(this, t, r) : new this(0), i.s = n.s) : !n.d || e.isZero() ? (i = a(this, s, 1).times(.5), i.s = n.s) : e.s < 0 ? (this.precision = s, this.rounding = 1, i = this.atan(Sn(n, e, s, 1)), e = a(this, s, 1), this.precision = t, this.rounding = r, i = n.s < 0 ? i.minus(e) : i.plus(e)) : i = this.atan(Sn(n, e, s, 1)) : (i = a(this, s, 1).times(e.s > 0 ? .25 : .75), i.s = n.s) : i = new this(NaN), i } function _(n) { return new this(n).cbrt() } function k(n) { return o(n = new this(n), n.e + 1, 2) } function S(n) { if (!n || "object" != typeof n) throw Error(xn + "Object expected"); var e, i, t, r = ["precision", 1, gn, "rounding", 0, 8, "toExpNeg", -pn, 0, "toExpPos", 0, pn, "maxE", 0, pn, "minE", -pn, 0, "modulo", 0, 9]; for (e = 0; e < r.length; e += 3) if (void 0 !== (t = n[i = r[e]])) { if (!(qn(t) === t && t >= r[e + 1] && t <= r[e + 2])) throw Error(En + i + ": " + t); this[i] = t } if (void 0 !== (t = n[i = "crypto"])) { if (t !== !0 && t !== !1 && 0 !== t && 1 !== t) throw Error(En + i + ": " + t); if (t) { if ("undefined" == typeof crypto || !crypto || !crypto.getRandomValues && !crypto.randomBytes) throw Error(yn); this[i] = !0 } else this[i] = !1 } return this } function T(n) { return new this(n).cos() } function C(n) { return new this(n).cosh() } function I(n) { function e(n) { var i, t, r, s = this; if (!(s instanceof e)) return new e(n); if (s.constructor = e, n instanceof e) return s.s = n.s, s.e = n.e, void (s.d = (n = n.d) ? n.slice() : n); if (r = typeof n, "number" === r) { if (0 === n) return s.s = 0 > 1 / n ? -1 : 1, s.e = 0, void (s.d = [0]); if (0 > n ? (n = -n, s.s = -1) : s.s = 1, n === ~~n && 1e7 > n) { for (i = 0, t = n; t >= 10; t /= 10) i++; return s.e = i, void (s.d = [n]) } return 0 * n !== 0 ? (n || (s.s = NaN), s.e = NaN, void (s.d = null)) : N(s, n.toString()) } if ("string" !== r) throw Error(En + n); return 45 === n.charCodeAt(0) ? (n = n.slice(1), s.s = -1) : s.s = 1, Zn.test(n) ? N(s, n) : b(s, n) } var i, t, r; if (e.prototype = kn, e.ROUND_UP = 0, e.ROUND_DOWN = 1, e.ROUND_CEIL = 2, e.ROUND_FLOOR = 3, e.ROUND_HALF_UP = 4, e.ROUND_HALF_DOWN = 5, e.ROUND_HALF_EVEN = 6, e.ROUND_HALF_CEIL = 7, e.ROUND_HALF_FLOOR = 8, e.EUCLID = 9, e.config = e.set = S, e.clone = I, e.abs = O, e.acos = F, e.acosh = A, e.add = D, e.asin = Z, e.asinh = P, e.atan = R, e.atanh = L, e.atan2 = U, e.cbrt = _, e.ceil = k, e.cos = T, e.cosh = C, e.div = H, e.exp = B, e.floor = V, e.hypot = $, e.ln = j, e.log = W, e.log10 = z, e.log2 = J, e.max = G, e.min = K, e.mod = Q, e.mul = X, e.pow = Y, e.random = nn, e.round = en, e.sign = tn, e.sin = rn, e.sinh = sn, e.sqrt = on, e.sub = un, e.tan = cn, e.tanh = fn, e.trunc = an, void 0 === n && (n = {}), n) for (r = ["precision", "rounding", "toExpNeg", "toExpPos", "maxE", "minE", "modulo", "crypto"], i = 0; i < r.length;) n.hasOwnProperty(t = r[i++]) || (n[t] = this[t]); return e.config(n), e } function H(n, e) { return new this(n).div(e) } function B(n) { return new this(n).exp() } function V(n) { return o(n = new this(n), n.e + 1, 3) } function $() { var n, e, i = new this(0); for (bn = !1, n = 0; n < arguments.length;) if (e = new this(arguments[n++]), e.d) i.d && (i = i.plus(e.times(e))); else { if (e.s) return bn = !0, new this(1 / 0); i = e } return bn = !0, i.sqrt() } function j(n) { return new this(n).ln() } function W(n, e) { return new this(n).log(e) } function J(n) { return new this(n).log(2) } function z(n) { return new this(n).log(10) } function G() { return g(this, arguments, "lt") } function K() { return g(this, arguments, "gt") } function Q(n, e) { return new this(n).mod(e) } function X(n, e) { return new this(n).mul(e) } function Y(n, e) { return new this(n).pow(e) } function nn(n) { var e, t, r, s, o = 0, u = new this(1), c = []; if (void 0 === n ? n = this.precision : i(n, 1, gn), r = Math.ceil(n / Rn), this.crypto) if (crypto.getRandomValues) for (e = crypto.getRandomValues(new Uint32Array(r)) ; r > o;) s = e[o], s >= 429e7 ? e[o] = crypto.getRandomValues(new Uint32Array(1))[0] : c[o++] = s % 1e7; else { if (!crypto.randomBytes) throw Error(yn); for (e = crypto.randomBytes(r *= 4) ; r > o;) s = e[o] + (e[o + 1] << 8) + (e[o + 2] << 16) + ((127 & e[o + 3]) << 24), s >= 214e7 ? crypto.randomBytes(4).copy(e, o) : (c.push(s % 1e7), o += 4); o = r / 4 } else for (; r > o;) c[o++] = 1e7 * Math.random() | 0; for (r = c[--o], n %= Rn, r && n && (s = On(10, Rn - n), c[o] = (r / s | 0) * s) ; 0 === c[o]; o--) c.pop(); if (0 > o) t = 0, c = [0]; else { for (t = -1; 0 === c[0]; t -= Rn) c.shift(); for (r = 1, s = c[0]; s >= 10; s /= 10) r++; Rn > r && (t -= Rn - r) } return u.e = t, u.d = c, u } function en(n) { return o(n = new this(n), n.e + 1, this.rounding) } function tn(n) { return n = new this(n), n.d ? n.d[0] ? n.s : 0 * n.s : n.s || NaN } function rn(n) { return new this(n).sin() } function sn(n) { return new this(n).sinh() } function on(n) { return new this(n).sqrt() } function un(n, e) { return new this(n).sub(e) } function cn(n) { return new this(n).tan() } function fn(n) { return new this(n).tanh() } function an(n) { return o(n = new this(n), n.e + 1, 1) } var hn, ln, dn, pn = 9e15, gn = 1e9, wn = "0123456789abcdef", mn = "2.3025850929940456840179914546843642076011014886287729760333279009675726096773524802359972050895982983419677840422862486334095254650828067566662873690987816894829072083255546808437998948262331985283935053089653777326288461633662222876982198867465436674744042432743651550489343149393914796194044002221051017141748003688084012647080685567743216228355220114804663715659121373450747856947683463616792101806445070648000277502684916746550586856935673420670581136429224554405758925724208241314695689016758940256776311356919292033376587141660230105703089634572075440370847469940168269282808481184289314848524948644871927809676271275775397027668605952496716674183485704422507197965004714951050492214776567636938662976979522110718264549734772662425709429322582798502585509785265383207606726317164309505995087807523710333101197857547331541421808427543863591778117054309827482385045648019095610299291824318237525357709750539565187697510374970888692180205189339507238539205144634197265287286965110862571492198849978748873771345686209167058", vn = "3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679821480865132823066470938446095505822317253594081284811174502841027019385211055596446229489549303819644288109756659334461284756482337867831652712019091456485669234603486104543266482133936072602491412737245870066063155881748815209209628292540917153643678925903600113305305488204665213841469519415116094330572703657595919530921861173819326117931051185480744623799627495673518857527248912279381830119491298336733624406566430860213949463952247371907021798609437027705392171762931767523846748184676694051320005681271452635608277857713427577896091736371787214684409012249534301465495853710507922796892589235420199561121290219608640344181598136297747713099605187072113499999983729780499510597317328160963185950244594553469083026425223082533446850352619311881710100031378387528865875332083814206171776691473035982534904287554687311595628638823537875937519577818577805321712268066130019278766111959092164201989380952572010654858632789", Nn = { precision: 20, rounding: 4, modulo: 1, toExpNeg: -7, toExpPos: 21, minE: -pn, maxE: pn, crypto: !1 }, bn = !0, xn = "[DecimalError] ", En = xn + "Invalid argument: ", Mn = xn + "Precision limit exceeded", yn = xn + "crypto unavailable", qn = Math.floor, On = Math.pow, Fn = /^0b([01]+(\.[01]*)?|\.[01]+)(p[+-]?\d+)?$/i, An = /^0x([0-9a-f]+(\.[0-9a-f]*)?|\.[0-9a-f]+)(p[+-]?\d+)?$/i, Dn = /^0o([0-7]+(\.[0-7]*)?|\.[0-7]+)(p[+-]?\d+)?$/i, Zn = /^(\d+(\.\d*)?|\.\d+)(e[+-]?\d+)?$/i, Pn = 1e7, Rn = 7, Ln = 9007199254740991, Un = mn.length - 1, _n = vn.length - 1, kn = {}; kn.absoluteValue = kn.abs = function () { var n = new this.constructor(this); return n.s < 0 && (n.s = 1), o(n) }, kn.ceil = function () { return o(new this.constructor(this), this.e + 1, 2) }, kn.comparedTo = kn.cmp = function (n) { var e, i, t, r, s = this, o = s.d, u = (n = new s.constructor(n)).d, c = s.s, f = n.s; if (!o || !u) return c && f ? c !== f ? c : o === u ? 0 : !o ^ 0 > c ? 1 : -1 : NaN; if (!o[0] || !u[0]) return o[0] ? c : u[0] ? -f : 0; if (c !== f) return c; if (s.e !== n.e) return s.e > n.e ^ 0 > c ? 1 : -1; for (t = o.length, r = u.length, e = 0, i = r > t ? t : r; i > e; ++e) if (o[e] !== u[e]) return o[e] > u[e] ^ 0 > c ? 1 : -1; return t === r ? 0 : t > r ^ 0 > c ? 1 : -1 }, kn.cosine = kn.cos = function () { var n, e, i = this, t = i.constructor; return i.d ? i.d[0] ? (n = t.precision, e = t.rounding, t.precision = n + Math.max(i.e, i.sd()) + Rn, t.rounding = 1, i = s(t, M(t, i)), t.precision = n, t.rounding = e, o(2 == dn || 3 == dn ? i.neg() : i, n, e, !0)) : new t(1) : new t(NaN) }, kn.cubeRoot = kn.cbrt = function () { var n, i, t, r, s, u, c, f, a, h, l = this, d = l.constructor; if (!l.isFinite() || l.isZero()) return new d(l); for (bn = !1, u = l.s * Math.pow(l.s * l, 1 / 3), u && Math.abs(u) != 1 / 0 ? r = new d(u.toString()) : (t = e(l.d), n = l.e, (u = (n - t.length + 1) % 3) && (t += 1 == u || -2 == u ? "0" : "00"), u = Math.pow(t, 1 / 3), n = qn((n + 1) / 3) - (n % 3 == (0 > n ? -1 : 2)), u == 1 / 0 ? t = "5e" + n : (t = u.toExponential(), t = t.slice(0, t.indexOf("e") + 1) + n), r = new d(t), r.s = l.s), c = (n = d.precision) + 3; ;) if (f = r, a = f.times(f).times(f), h = a.plus(l), r = Sn(h.plus(l).times(f), h.plus(a), c + 2, 1), e(f.d).slice(0, c) === (t = e(r.d)).slice(0, c)) { if (t = t.slice(c - 3, c + 1), "9999" != t && (s || "4999" != t)) { (!+t || !+t.slice(1) && "5" == t.charAt(0)) && (o(r, n + 1, 1), i = !r.times(r).times(r).eq(l)); break } if (!s && (o(f, n + 1, 0), f.times(f).times(f).eq(l))) { r = f; break } c += 4, s = 1 } return bn = !0, o(r, n, d.rounding, i) }, kn.decimalPlaces = kn.dp = function () { var n, e = this.d, i = NaN; if (e) { if (n = e.length - 1, i = (n - qn(this.e / Rn)) * Rn, n = e[n]) for (; n % 10 == 0; n /= 10) i--; 0 > i && (i = 0) } return i }, kn.dividedBy = kn.div = function (n) { return Sn(this, new this.constructor(n)) }, kn.dividedToIntegerBy = kn.divToInt = function (n) { var e = this, i = e.constructor; return o(Sn(e, new i(n), 0, 1, 1), i.precision, i.rounding) }, kn.equals = kn.eq = function (n) { return 0 === this.cmp(n) }, kn.floor = function () { return o(new this.constructor(this), this.e + 1, 3) }, kn.greaterThan = kn.gt = function (n) { return this.cmp(n) > 0 }, kn.greaterThanOrEqualTo = kn.gte = function (n) { var e = this.cmp(n); return 1 == e || 0 === e }, kn.hyperbolicCosine = kn.cosh = function () { var n, e, i, t, r, s = this, u = s.constructor, c = new u(1); if (!s.isFinite()) return new u(s.s ? 1 / 0 : NaN); if (s.isZero()) return c; i = u.precision, t = u.rounding, u.precision = i + Math.max(s.e, s.sd()) + 4, u.rounding = 1, r = s.d.length, 32 > r ? (n = Math.ceil(r / 3), e = Math.pow(4, -n).toString()) : (n = 16, e = "2.3283064365386962890625e-10"), s = E(u, 1, s.times(e), new u(1), !0); for (var f, a = n, h = new u(8) ; a--;) f = s.times(s), s = c.minus(f.times(h.minus(f.times(h)))); return o(s, u.precision = i, u.rounding = t, !0) }, kn.hyperbolicSine = kn.sinh = function () { var n, e, i, t, r = this, s = r.constructor; if (!r.isFinite() || r.isZero()) return new s(r); if (e = s.precision, i = s.rounding, s.precision = e + Math.max(r.e, r.sd()) + 4, s.rounding = 1, t = r.d.length, 3 > t) r = E(s, 2, r, r, !0); else { n = 1.4 * Math.sqrt(t), n = n > 16 ? 16 : 0 | n, r = r.times(Math.pow(5, -n)), r = E(s, 2, r, r, !0); for (var u, c = new s(5), f = new s(16), a = new s(20) ; n--;) u = r.times(r), r = r.times(c.plus(u.times(f.times(u).plus(a)))) } return s.precision = e, s.rounding = i, o(r, e, i, !0) }, kn.hyperbolicTangent = kn.tanh = function () { var n, e, i = this, t = i.constructor; return i.isFinite() ? i.isZero() ? new t(i) : (n = t.precision, e = t.rounding, t.precision = n + 7, t.rounding = 1, Sn(i.sinh(), i.cosh(), t.precision = n, t.rounding = e)) : new t(i.s) }, kn.inverseCosine = kn.acos = function () { var n, e = this, i = e.constructor, t = e.abs().cmp(1), r = i.precision, s = i.rounding; return -1 !== t ? 0 === t ? e.isNeg() ? a(i, r, s) : new i(0) : new i(NaN) : e.isZero() ? a(i, r + 4, s).times(.5) : (i.precision = r + 6, i.rounding = 1, e = e.asin(), n = a(i, r + 4, s).times(.5), i.precision = r, i.rounding = s, n.minus(e)) }, kn.inverseHyperbolicCosine = kn.acosh = function () { var n, e, i = this, t = i.constructor; return i.lte(1) ? new t(i.eq(1) ? 0 : NaN) : i.isFinite() ? (n = t.precision, e = t.rounding, t.precision = n + Math.max(Math.abs(i.e), i.sd()) + 4, t.rounding = 1, bn = !1, i = i.times(i).minus(1).sqrt().plus(i), bn = !0, t.precision = n, t.rounding = e, i.ln()) : new t(i) }, kn.inverseHyperbolicSine = kn.asinh = function () { var n, e, i = this, t = i.constructor; return !i.isFinite() || i.isZero() ? new t(i) : (n = t.precision, e = t.rounding, t.precision = n + 2 * Math.max(Math.abs(i.e), i.sd()) + 6, t.rounding = 1, bn = !1, i = i.times(i).plus(1).sqrt().plus(i), bn = !0, t.precision = n, t.rounding = e, i.ln()) }, kn.inverseHyperbolicTangent = kn.atanh = function () { var n, e, i, t, r = this, s = r.constructor; return r.isFinite() ? r.e >= 0 ? new s(r.abs().eq(1) ? r.s / 0 : r.isZero() ? r : NaN) : (n = s.precision, e = s.rounding, t = r.sd(), Math.max(t, n) < 2 * -r.e - 1 ? o(new s(r), n, e, !0) : (s.precision = i = t - r.e, r = Sn(r.plus(1), new s(1).minus(r), i + n, 1), s.precision = n + 4, s.rounding = 1, r = r.ln(), s.precision = n, s.rounding = e, r.times(.5))) : new s(NaN) }, kn.inverseSine = kn.asin = function () { var n, e, i, t, r = this, s = r.constructor; return r.isZero() ? new s(r) : (e = r.abs().cmp(1), i = s.precision, t = s.rounding, -1 !== e ? 0 === e ? (n = a(s, i + 4, t).times(.5), n.s = r.s, n) : new s(NaN) : (s.precision = i + 6, s.rounding = 1, r = r.div(new s(1).minus(r.times(r)).sqrt().plus(1)).atan(), s.precision = i, s.rounding = t, r.times(2))) }, kn.inverseTangent = kn.atan = function () { var n, e, i, t, r, s, u, c, f, h = this, l = h.constructor, d = l.precision, p = l.rounding; if (h.isFinite()) { if (h.isZero()) return new l(h); if (h.abs().eq(1) && _n >= d + 4) return u = a(l, d + 4, p).times(.25), u.s = h.s, u } else { if (!h.s) return new l(NaN); if (_n >= d + 4) return u = a(l, d + 4, p).times(.5), u.s = h.s, u } for (l.precision = c = d + 10, l.rounding = 1, i = Math.min(28, c / Rn + 2 | 0), n = i; n; --n) h = h.div(h.times(h).plus(1).sqrt().plus(1)); for (bn = !1, e = Math.ceil(c / Rn), t = 1, f = h.times(h), u = new l(h), r = h; -1 !== n;) if (r = r.times(f), s = u.minus(r.div(t += 2)), r = r.times(f), u = s.plus(r.div(t += 2)), void 0 !== u.d[e]) for (n = e; u.d[n] === s.d[n] && n--;); return i && (u = u.times(2 << i - 1)), bn = !0, o(u, l.precision = d, l.rounding = p, !0) }, kn.isFinite = function () { return !!this.d }, kn.isInteger = kn.isInt = function () { return !!this.d && qn(this.e / Rn) > this.d.length - 2 }, kn.isNaN = function () { return !this.s }, kn.isNegative = kn.isNeg = function () { return this.s < 0 }, kn.isPositive = kn.isPos = function () { return this.s > 0 }, kn.isZero = function () { return !!this.d && 0 === this.d[0] }, kn.lessThan = kn.lt = function (n) { return this.cmp(n) < 0 }, kn.lessThanOrEqualTo = kn.lte = function (n) { return this.cmp(n) < 1 }, kn.logarithm = kn.log = function (n) { var i, r, s, u, c, a, h, l, d = this, p = d.constructor, g = p.precision, w = p.rounding, v = 5; if (null == n) n = new p(10), i = !0; else { if (n = new p(n), r = n.d, n.s < 0 || !r || !r[0] || n.eq(1)) return new p(NaN); i = n.eq(10) } if (r = d.d, d.s < 0 || !r || !r[0] || d.eq(1)) return new p(r && !r[0] ? -1 / 0 : 1 != d.s ? NaN : r ? 0 : 1 / 0); if (i) if (r.length > 1) c = !0; else { for (u = r[0]; u % 10 === 0;) u /= 10; c = 1 !== u } if (bn = !1, h = g + v, a = m(d, h), s = i ? f(p, h + 10) : m(n, h), l = Sn(a, s, h, 1), t(l.d, u = g, w)) do if (h += 10, a = m(d, h), s = i ? f(p, h + 10) : m(n, h), l = Sn(a, s, h, 1), !c) { +e(l.d).slice(u + 1, u + 15) + 1 == 1e14 && (l = o(l, g + 1, 0)); break } while (t(l.d, u += 10, w)); return bn = !0, o(l, g, w) }, kn.minus = kn.sub = function (n) { var e, i, t, r, s, u, f, a, h, l, d, p, g = this, w = g.constructor; if (n = new w(n), !g.d || !n.d) return g.s && n.s ? g.d ? n.s = -n.s : n = new w(n.d || g.s !== n.s ? g : NaN) : n = new w(NaN), n; if (g.s != n.s) return n.s = -n.s, g.plus(n); if (h = g.d, p = n.d, f = w.precision, a = w.rounding, !h[0] || !p[0]) { if (p[0]) n.s = -n.s; else { if (!h[0]) return new w(3 === a ? -0 : 0); n = new w(g) } return bn ? o(n, f, a) : n } if (i = qn(n.e / Rn), l = qn(g.e / Rn), h = h.slice(), s = l - i) { for (d = 0 > s, d ? (e = h, s = -s, u = p.length) : (e = p, i = l, u = h.length), t = Math.max(Math.ceil(f / Rn), u) + 2, s > t && (s = t, e.length = 1), e.reverse(), t = s; t--;) e.push(0); e.reverse() } else { for (t = h.length, u = p.length, d = u > t, d && (u = t), t = 0; u > t; t++) if (h[t] != p[t]) { d = h[t] < p[t]; break } s = 0 } for (d && (e = h, h = p, p = e, n.s = -n.s), u = h.length, t = p.length - u; t > 0; --t) h[u++] = 0; for (t = p.length; t > s;) { if (h[--t] < p[t]) { for (r = t; r && 0 === h[--r];) h[r] = Pn - 1; --h[r], h[t] += Pn } h[t] -= p[t] } for (; 0 === h[--u];) h.pop(); for (; 0 === h[0]; h.shift())--i; return h[0] ? (n.d = h, n.e = c(h, i), bn ? o(n, f, a) : n) : new w(3 === a ? -0 : 0) }, kn.modulo = kn.mod = function (n) { var e, i = this, t = i.constructor; return n = new t(n), !i.d || !n.s || n.d && !n.d[0] ? new t(NaN) : !n.d || i.d && !i.d[0] ? o(new t(i), t.precision, t.rounding) : (bn = !1, 9 == t.modulo ? (e = Sn(i, n.abs(), 0, 3, 1), e.s *= n.s) : e = Sn(i, n, 0, t.modulo, 1), e = e.times(n), bn = !0, i.minus(e)) }, kn.naturalExponential = kn.exp = function () { return w(this) }, kn.naturalLogarithm = kn.ln = function () { return m(this) }, kn.negated = kn.neg = function () { var n = new this.constructor(this); return n.s = -n.s, o(n) }, kn.plus = kn.add = function (n) { var e, i, t, r, s, u, f, a, h, l, d = this, p = d.constructor; if (n = new p(n), !d.d || !n.d) return d.s && n.s ? d.d || (n = new p(n.d || d.s === n.s ? d : NaN)) : n = new p(NaN), n; if (d.s != n.s) return n.s = -n.s, d.minus(n); if (h = d.d, l = n.d, f = p.precision, a = p.rounding, !h[0] || !l[0]) return l[0] || (n = new p(d)), bn ? o(n, f, a) : n; if (s = qn(d.e / Rn), t = qn(n.e / Rn), h = h.slice(), r = s - t) { for (0 > r ? (i = h, r = -r, u = l.length) : (i = l, t = s, u = h.length), s = Math.ceil(f / Rn), u = s > u ? s + 1 : u + 1, r > u && (r = u, i.length = 1), i.reverse() ; r--;) i.push(0); i.reverse() } for (u = h.length, r = l.length, 0 > u - r && (r = u, i = l, l = h, h = i), e = 0; r;) e = (h[--r] = h[r] + l[r] + e) / Pn | 0, h[r] %= Pn; for (e && (h.unshift(e), ++t), u = h.length; 0 == h[--u];) h.pop(); return n.d = h, n.e = c(h, t), bn ? o(n, f, a) : n }, kn.precision = kn.sd = function (n) { var e, i = this; if (void 0 !== n && n !== !!n && 1 !== n && 0 !== n) throw Error(En + n); return i.d ? (e = h(i.d), n && i.e + 1 > e && (e = i.e + 1)) : e = NaN, e }, kn.round = function () { var n = this, e = n.constructor; return o(new e(n), n.e + 1, e.rounding) }, kn.sine = kn.sin = function () { var n, e, i = this, t = i.constructor; return i.isFinite() ? i.isZero() ? new t(i) : (n = t.precision, e = t.rounding, t.precision = n + Math.max(i.e, i.sd()) + Rn, t.rounding = 1, i = x(t, M(t, i)), t.precision = n, t.rounding = e, o(dn > 2 ? i.neg() : i, n, e, !0)) : new t(NaN) }, kn.squareRoot = kn.sqrt = function () { var n, i, t, r, s, u, c = this, f = c.d, a = c.e, h = c.s, l = c.constructor; if (1 !== h || !f || !f[0]) return new l(!h || 0 > h && (!f || f[0]) ? NaN : f ? c : 1 / 0); for (bn = !1, h = Math.sqrt(+c), 0 == h || h == 1 / 0 ? (i = e(f), (i.length + a) % 2 == 0 && (i += "0"), h = Math.sqrt(i), a = qn((a + 1) / 2) - (0 > a || a % 2), h == 1 / 0 ? i = "1e" + a : (i = h.toExponential(), i = i.slice(0, i.indexOf("e") + 1) + a), r = new l(i)) : r = new l(h.toString()), t = (a = l.precision) + 3; ;) if (u = r, r = u.plus(Sn(c, u, t + 2, 1)).times(.5), e(u.d).slice(0, t) === (i = e(r.d)).slice(0, t)) { if (i = i.slice(t - 3, t + 1), "9999" != i && (s || "4999" != i)) { (!+i || !+i.slice(1) && "5" == i.charAt(0)) && (o(r, a + 1, 1), n = !r.times(r).eq(c)); break } if (!s && (o(u, a + 1, 0), u.times(u).eq(c))) { r = u; break } t += 4, s = 1 } return bn = !0, o(r, a, l.rounding, n) }, kn.tangent = kn.tan = function () { var n, e, i = this, t = i.constructor; return i.isFinite() ? i.isZero() ? new t(i) : (n = t.precision, e = t.rounding, t.precision = n + 10, t.rounding = 1, i = i.sin(), i.s = 1, i = Sn(i, new t(1).minus(i.times(i)).sqrt(), n + 10, 0), t.precision = n, t.rounding = e, o(2 == dn || 4 == dn ? i.neg() : i, n, e, !0)) : new t(NaN) }, kn.times = kn.mul = function (n) { var e, i, t, r, s, u, f, a, h, l = this, d = l.constructor, p = l.d, g = (n = new d(n)).d; if (n.s *= l.s, !(p && p[0] && g && g[0])) return new d(!n.s || p && !p[0] && !g || g && !g[0] && !p ? NaN : p && g ? 0 * n.s : n.s / 0); for (i = qn(l.e / Rn) + qn(n.e / Rn), a = p.length, h = g.length, h > a && (s = p, p = g, g = s, u = a, a = h, h = u), s = [], u = a + h, t = u; t--;) s.push(0); for (t = h; --t >= 0;) { for (e = 0, r = a + t; r > t;) f = s[r] + g[t] * p[r - t - 1] + e, s[r--] = f % Pn | 0, e = f / Pn | 0; s[r] = (s[r] + e) % Pn | 0 } for (; !s[--u];) s.pop(); for (e ? ++i : s.shift(), t = s.length; !s[--t];) s.pop(); return n.d = s, n.e = c(s, i), bn ? o(n, d.precision, d.rounding) : n }, kn.toBinary = function (n, e) { return y(this, 2, n, e) }, kn.toDecimalPlaces = kn.toDP = function (n, e) { var t = this, r = t.constructor; return t = new r(t), void 0 === n ? t : (i(n, 0, gn), void 0 === e ? e = r.rounding : i(e, 0, 8), o(t, n + t.e + 1, e)) }, kn.toExponential = function (n, e) { var t, r = this, s = r.constructor; return void 0 === n ? t = u(r, !0) : (i(n, 0, gn), void 0 === e ? e = s.rounding : i(e, 0, 8), r = o(new s(r), n + 1, e), t = u(r, !0, n + 1)), r.isNeg() && !r.isZero() ? "-" + t : t }, kn.toFixed = function (n, e) { var t, r, s = this, c = s.constructor; return void 0 === n ? t = u(s) : (i(n, 0, gn), void 0 === e ? e = c.rounding : i(e, 0, 8), r = o(new c(s), n + s.e + 1, e), t = u(r, !1, n + r.e + 1)), s.isNeg() && !s.isZero() ? "-" + t : t }, kn.toFraction = function (n) { var i, t, r, s, o, u, c, f, a, l, d, p, g = this, w = g.d, m = g.constructor; if (!w) return new m(g); if (a = t = new m(1), r = f = new m(0), i = new m(r), o = i.e = h(w) - g.e - 1, u = o % Rn, i.d[0] = On(10, 0 > u ? Rn + u : u), null == n) n = o > 0 ? i : a; else { if (c = new m(n), !c.isInt() || c.lt(a)) throw Error(En + c); n = c.gt(i) ? o > 0 ? i : a : c } for (bn = !1, c = new m(e(w)), l = m.precision, m.precision = o = w.length * Rn * 2; d = Sn(c, i, 0, 1, 1), s = t.plus(d.times(r)), 1 != s.cmp(n) ;) t = r, r = s, s = a, a = f.plus(d.times(s)), f = s, s = i, i = c.minus(d.times(s)), c = s; return s = Sn(n.minus(t), r, 0, 1, 1), f = f.plus(s.times(a)), t = t.plus(s.times(r)), f.s = a.s = g.s, p = Sn(a, r, o, 1).minus(g).abs().cmp(Sn(f, t, o, 1).minus(g).abs()) < 1 ? [a, r] : [f, t], m.precision = l, bn = !0, p }, kn.toHexadecimal = kn.toHex = function (n, e) { return y(this, 16, n, e) }, kn.toNearest = function (n, e) { var t = this, r = t.constructor; if (t = new r(t), null == n) { if (!t.d) return t; n = new r(1), e = r.rounding } else { if (n = new r(n), void 0 !== e && i(e, 0, 8), !t.d) return n.s ? t : n; if (!n.d) return n.s && (n.s = t.s), n } return n.d[0] ? (bn = !1, 4 > e && (e = [4, 5, 7, 8][e]), t = Sn(t, n, 0, e, 1).times(n), bn = !0, o(t)) : (n.s = t.s, t = n), t }, kn.toNumber = function () { return +this }, kn.toOctal = function (n, e) { return y(this, 8, n, e) }, kn.toPower = kn.pow = function (n) { var i, r, s, u, c, f, a, h = this, l = h.constructor, p = +(n = new l(n)); if (!(h.d && n.d && h.d[0] && n.d[0])) return new l(On(+h, p)); if (h = new l(h), h.eq(1)) return h; if (s = l.precision, c = l.rounding, n.eq(1)) return o(h, s, c); if (i = qn(n.e / Rn), r = n.d.length - 1, a = i >= r, f = h.s, a) { if ((r = 0 > p ? -p : p) <= Ln) return u = d(l, h, r, s), n.s < 0 ? new l(1).div(u) : o(u, s, c) } else if (0 > f) return new l(NaN); return f = 0 > f && 1 & n.d[Math.max(i, r)] ? -1 : 1, r = On(+h, p), i = 0 != r && isFinite(r) ? new l(r + "").e : qn(p * (Math.log("0." + e(h.d)) / Math.LN10 + h.e + 1)), i > l.maxE + 1 || i < l.minE - 1 ? new l(i > 0 ? f / 0 : 0) : (bn = !1, l.rounding = h.s = 1, r = Math.min(12, (i + "").length), u = w(n.times(m(h, s + r)), s), u = o(u, s + 5, 1), t(u.d, s, c) && (i = s + 10, u = o(w(n.times(m(h, i + r)), i), i + 5, 1), +e(u.d).slice(s + 1, s + 15) + 1 == 1e14 && (u = o(u, s + 1, 0))), u.s = f, bn = !0, l.rounding = c, o(u, s, c)) }, kn.toPrecision = function (n, e) { var t, r = this, s = r.constructor; return void 0 === n ? t = u(r, r.e <= s.toExpNeg || r.e >= s.toExpPos) : (i(n, 1, gn), void 0 === e ? e = s.rounding : i(e, 0, 8), r = o(new s(r), n, e), t = u(r, n <= r.e || r.e <= s.toExpNeg, n)), r.isNeg() && !r.isZero() ? "-" + t : t }, kn.toSignificantDigits = kn.toSD = function (n, e) { var t = this, r = t.constructor; return void 0 === n ? (n = r.precision, e = r.rounding) : (i(n, 1, gn), void 0 === e ? e = r.rounding : i(e, 0, 8)), o(new r(t), n, e) }, kn.toString = function () { var n = this, e = n.constructor, i = u(n, n.e <= e.toExpNeg || n.e >= e.toExpPos); return n.isNeg() && !n.isZero() ? "-" + i : i }, kn.truncated = kn.trunc = function () { return o(new this.constructor(this), this.e + 1, 1) }, kn.valueOf = kn.toJSON = function () { var n = this, e = n.constructor, i = u(n, n.e <= e.toExpNeg || n.e >= e.toExpPos); return n.isNeg() ? "-" + i : i }; var Sn = function () { function n(n, e, i) { var t, r = 0, s = n.length; for (n = n.slice() ; s--;) t = n[s] * e + r, n[s] = t % i | 0, r = t / i | 0; return r && n.unshift(r), n } function e(n, e, i, t) { var r, s; if (i != t) s = i > t ? 1 : -1; else for (r = s = 0; i > r; r++) if (n[r] != e[r]) { s = n[r] > e[r] ? 1 : -1; break } return s } function i(n, e, i, t) { for (var r = 0; i--;) n[i] -= r, r = n[i] < e[i] ? 1 : 0, n[i] = r * t + n[i] - e[i]; for (; !n[0] && n.length > 1;) n.shift() } return function (t, r, s, u, c, f) { var a, h, l, d, p, g, w, m, v, N, b, x, E, M, y, q, O, F, A, D, Z = t.constructor, P = t.s == r.s ? 1 : -1, R = t.d, L = r.d; if (!(R && R[0] && L && L[0])) return new Z(t.s && r.s && (R ? !L || R[0] != L[0] : L) ? R && 0 == R[0] || !L ? 0 * P : P / 0 : NaN); for (f ? (p = 1, h = t.e - r.e) : (f = Pn, p = Rn, h = qn(t.e / p) - qn(r.e / p)), A = L.length, O = R.length, v = new Z(P), N = v.d = [], l = 0; L[l] == (R[l] || 0) ; l++); if (L[l] > (R[l] || 0) && h--, null == s ? (M = s = Z.precision, u = Z.rounding) : M = c ? s + (t.e - r.e) + 1 : s, 0 > M) N.push(1), g = !0; else { if (M = M / p + 2 | 0, l = 0, 1 == A) { for (d = 0, L = L[0], M++; (O > l || d) && M--; l++) y = d * f + (R[l] || 0), N[l] = y / L | 0, d = y % L | 0; g = d || O > l } else { for (d = f / (L[0] + 1) | 0, d > 1 && (L = n(L, d, f), R = n(R, d, f), A = L.length, O = R.length), q = A, b = R.slice(0, A), x = b.length; A > x;) b[x++] = 0; D = L.slice(), D.unshift(0), F = L[0], L[1] >= f / 2 && ++F; do d = 0, a = e(L, b, A, x), 0 > a ? (E = b[0], A != x && (E = E * f + (b[1] || 0)), d = E / F | 0, d > 1 ? (d >= f && (d = f - 1), w = n(L, d, f), m = w.length, x = b.length, a = e(w, b, m, x), 1 == a && (d--, i(w, m > A ? D : L, m, f))) : (0 == d && (a = d = 1), w = L.slice()), m = w.length, x > m && w.unshift(0), i(b, w, x, f), -1 == a && (x = b.length, a = e(L, b, A, x), 1 > a && (d++, i(b, x > A ? D : L, x, f))), x = b.length) : 0 === a && (d++, b = [0]), N[l++] = d, a && b[0] ? b[x++] = R[q] || 0 : (b = [R[q]], x = 1); while ((q++ < O || void 0 !== b[0]) && M--); g = void 0 !== b[0] } N[0] || N.shift() } if (1 == p) v.e = h, hn = g; else { for (l = 1, d = N[0]; d >= 10; d /= 10) l++; v.e = l + h * p - 1, o(v, c ? s + v.e + 1 : s, u, g) } return v } }(); Nn = I(Nn), mn = new Nn(mn), vn = new Nn(vn), Bridge.$Decimal = Nn, "function" == typeof define && define.amd ? define("decimal.js", function () { return Nn }) : "undefined" != typeof module && module.exports ? module.exports = Nn["default"] = Nn.Decimal = Nn : (n || (n = "undefined" != typeof self && self && self.self == self ? self : Function("return this")()), ln = n.Decimal, Nn.noConflict = function () { return n.Decimal = ln, Nn }/*, n.Decimal = Nn*/) }(Bridge.global);

    System.Decimal = function (v, provider, T) {
        if (this.constructor !== System.Decimal) {
            return new System.Decimal(v, provider, T);
        }

        if (v == null) {
            v = 0;
        }

        if (Bridge.isNumber(provider)) {
            this.$precision = provider;
            provider = undefined;
        } else {
            this.$precision = 0;
        }

        if (typeof v === "string") {
            provider = provider || System.Globalization.CultureInfo.getCurrentCulture();

            var nfInfo = provider && provider.getFormat(System.Globalization.NumberFormatInfo),
                dot;

            if (nfInfo && nfInfo.numberDecimalSeparator !== ".") {
                v = v.replace(nfInfo.numberDecimalSeparator, ".");
            }

            // Native .NET accepts the sign in postfixed form. Yet, it is documented otherwise.
            // https://docs.microsoft.com/en-us/dotnet/api/system.decimal.parse
            if (!/^\s*[+-]?(\d+|\d+\.|\d*\.\d+)((e|E)[+-]?\d+)?\s*$/.test(v) &&
                !/^\s*(\d+|\d+\.|\d*\.\d+)((e|E)[+-]?\d+)?[+-]\s*$/.test(v)) {
                throw new System.FormatException();
            }

            v = v.replace(/\s/g, "");

            // Move the postfixed - to front, or remove '+' so the underlying
            // decimal handler knows what to do with the string.
            if (/[+-]$/.test(v)) {
                if (v.endsWith('-')) {
                    v = v.replace(/(.*)(-)$/, "$2$1");
                } else {
                    v = v.substr(0, v.length - 1);
                }
            } else if (v.startsWith("+")) {
                v = v.substr(1);
            }

            if (!this.$precision && (dot = v.indexOf('.')) >= 0) {
                this.$precision = v.length - dot - 1;
            }
        }

        if (T && T.precision && typeof v === "number") {
            var i = Bridge.Int.trunc(v);
            var length = (i + "").length;
            var p = T.precision - length;
            if (p < 0) {
                p = 0;
            }
            v = v.toFixed(p);
        }

        if (v instanceof System.Decimal) {
            this.$precision = v.$precision;
        }

        this.value = System.Decimal.getValue(v);
    }

    System.Decimal.$number = true;
    System.Decimal.$$name = "System.Decimal";
    System.Decimal.prototype.$$name = "System.Decimal";
    System.Decimal.$kind = "struct";
    System.Decimal.prototype.$kind = "struct";
    System.Decimal.$$inherits = [];
    Bridge.Class.addExtend(System.Decimal, [System.IComparable, System.IFormattable, System.IComparable$1(System.Decimal), System.IEquatable$1(System.Decimal)]);

    System.Decimal.$is = function (instance) {
        return instance instanceof System.Decimal;
    };

    System.Decimal.getDefaultValue = function () {
        return new System.Decimal(0);
    };

    System.Decimal.getValue = function (d) {
        if (!Bridge.hasValue(d)) {
            return this.getDefaultValue();
        }

        if (d instanceof System.Decimal) {
            return d.value;
        }

        if (d instanceof System.Int64 || d instanceof System.UInt64) {
            return new Bridge.$Decimal(d.toString());
        }

        return new Bridge.$Decimal(d);
    };

    System.Decimal.create = function (d) {
        if (!Bridge.hasValue(d)) {
            return null;
        }

        if (d instanceof System.Decimal) {
            return d;
        }

        return new System.Decimal(d);
    };

    System.Decimal.lift = function (d) {
        return d == null ? null : System.Decimal.create(d);
    };

    System.Decimal.prototype.toString = function (format, provider) {
        return Bridge.Int.format(this, format || "G", provider);
    };

    System.Decimal.prototype.toFloat = function () {
        return this.value.toNumber();
    };

    System.Decimal.prototype.toJSON = function () {
        return this.value.toNumber();
    };

    System.Decimal.prototype.format = function (format, provider) {
        return Bridge.Int.format(this, format, provider);
    };

    System.Decimal.prototype.decimalPlaces = function () {
        return this.value.decimalPlaces();
    };

    System.Decimal.prototype.dividedToIntegerBy = function (d) {
        var d = new System.Decimal(this.value.dividedToIntegerBy(System.Decimal.getValue(d)), this.$precision);
        d.$precision = Math.max(d.value.decimalPlaces(), this.$precision);
        return d;
    };

    System.Decimal.prototype.exponential = function () {
        return new System.Decimal(this.value.exponential(), this.$precision);
    };

    System.Decimal.prototype.abs = function () {
        return new System.Decimal(this.value.abs(), this.$precision);
    };

    System.Decimal.prototype.floor = function () {
        return new System.Decimal(this.value.floor());
    };

    System.Decimal.prototype.ceil = function () {
        return new System.Decimal(this.value.ceil());
    };

    System.Decimal.prototype.trunc = function () {
        return new System.Decimal(this.value.trunc());
    };

    System.Decimal.round = function (obj, mode) {
        obj = System.Decimal.create(obj);

        var old = Bridge.$Decimal.rounding;

        Bridge.$Decimal.rounding = mode;

        var d = new System.Decimal(obj.value.round());

        Bridge.$Decimal.rounding = old;

        return d;
    };

    System.Decimal.toDecimalPlaces = function (obj, decimals, mode) {
        obj = System.Decimal.create(obj);
        var d = new System.Decimal(obj.value.toDecimalPlaces(decimals, mode));
        return d;
    };

    System.Decimal.prototype.compareTo = function (another) {
        return this.value.comparedTo(System.Decimal.getValue(another));
    };

    System.Decimal.prototype.add = function (another) {
        var d = new System.Decimal(this.value.plus(System.Decimal.getValue(another)));
        d.$precision = Math.max(d.value.decimalPlaces(), Math.max(another.$precision || 0, this.$precision));
        return d;
    };

    System.Decimal.prototype.sub = function (another) {
        var d = new System.Decimal(this.value.minus(System.Decimal.getValue(another)));
        d.$precision = Math.max(d.value.decimalPlaces(), Math.max(another.$precision || 0, this.$precision));
        return d;
    };

    System.Decimal.prototype.isZero = function () {
        return this.value.isZero;
    };

    System.Decimal.prototype.mul = function (another) {
        var d = new System.Decimal(this.value.times(System.Decimal.getValue(another)));
        d.$precision = Math.max(d.value.decimalPlaces(), Math.max(another.$precision || 0, this.$precision));
        return d;
    };

    System.Decimal.prototype.div = function (another) {
        var d = new System.Decimal(this.value.dividedBy(System.Decimal.getValue(another)));
        d.$precision = Math.max(d.value.decimalPlaces(), Math.max(another.$precision || 0, this.$precision));
        return d;
    };

    System.Decimal.prototype.mod = function (another) {
        var d = new System.Decimal(this.value.modulo(System.Decimal.getValue(another)));
        d.$precision = Math.max(d.value.decimalPlaces(), Math.max(another.$precision || 0, this.$precision));
        return d;
    };

    System.Decimal.prototype.neg = function () {
        return new System.Decimal(this.value.negated(), this.$precision);
    };

    System.Decimal.prototype.inc = function () {
        return new System.Decimal(this.value.plus(System.Decimal.getValue(1)), this.$precision);
    };

    System.Decimal.prototype.dec = function () {
        return new System.Decimal(this.value.minus(System.Decimal.getValue(1)), this.$precision);
    };

    System.Decimal.prototype.sign = function () {
        return this.value.isZero() ? 0 : (this.value.isNegative() ? -1 : 1);
    };

    System.Decimal.prototype.clone = function () {
        return new System.Decimal(this, this.$precision);
    };

    System.Decimal.prototype.ne = function (v) {
        return !!this.compareTo(v);
    };

    System.Decimal.prototype.lt = function (v) {
        return this.compareTo(v) < 0;
    };

    System.Decimal.prototype.lte = function (v) {
        return this.compareTo(v) <= 0;
    };

    System.Decimal.prototype.gt = function (v) {
        return this.compareTo(v) > 0;
    };

    System.Decimal.prototype.gte = function (v) {
        return this.compareTo(v) >= 0;
    };

    System.Decimal.prototype.equals = function (v) {
        if (v instanceof System.Decimal || typeof v === "number") {
            return !this.compareTo(v);
        }

        return false;
    };

    System.Decimal.prototype.equalsT = function (v) {
        return !this.compareTo(v);
    };

    System.Decimal.prototype.getHashCode = function () {
        var n = (this.sign() * 397 + this.value.e) | 0;

        for (var i = 0; i < this.value.d.length; i++) {
            n = (n * 397 + this.value.d[i]) | 0;
        }

        return n;
    };

    System.Decimal.toInt = function (v, tp) {
        if (!v) {
            return null;
        }

        if (tp) {
            var str,
                r;

            if (tp === System.Int64) {
                str = v.value.trunc().toString();
                r = new System.Int64(str);

                if (str !== r.value.toString()) {
                    throw new System.OverflowException();
                }

                return r;
            }

            if (tp === System.UInt64) {
                if (v.value.isNegative()) {
                    throw new System.OverflowException();
                }

                str = v.value.trunc().toString();
                r = new System.UInt64(str);

                if (str !== r.value.toString()) {
                    throw new System.OverflowException();
                }

                return r;
            }

            return Bridge.Int.check(Bridge.Int.trunc(v.value.toNumber()), tp);
        }

        var i = Bridge.Int.trunc(System.Decimal.getValue(v).toNumber());

        if (!Bridge.Int.$is(i)) {
            throw new System.OverflowException();
        }

        return i;
    };

    System.Decimal.tryParse = function (s, provider, v) {
        try {
            v.v = new System.Decimal(s, provider);

            return true;
        } catch (e) {
            v.v = new System.Decimal(0);

            return false;
        }
    };

    System.Decimal.toFloat = function (v) {
        if (!v) {
            return null;
        }

        return System.Decimal.getValue(v).toNumber();
    };

    System.Decimal.setConfig = function (config) {
        Bridge.$Decimal.config(config);
    };

    System.Decimal.min = function () {
        var values = [],
            d, p;

        for (var i = 0, len = arguments.length; i < len; i++) {
            values.push(System.Decimal.getValue(arguments[i]));
        }

        d = Bridge.$Decimal.min.apply(Bridge.$Decimal, values);

        for (var i = 0; i < arguments.length; i++) {
            if (d.eq(values[i])) {
                p = arguments[i].$precision;
            }
        }

        return new System.Decimal(d, p);
    };

    System.Decimal.max = function () {
        var values = [],
            d, p;

        for (var i = 0, len = arguments.length; i < len; i++) {
            values.push(System.Decimal.getValue(arguments[i]));
        }

        d = Bridge.$Decimal.max.apply(Bridge.$Decimal, values);

        for (var i = 0; i < arguments.length; i++) {
            if (d.eq(values[i])) {
                p = arguments[i].$precision;
            }
        }

        return new System.Decimal(d, p);
    };

    System.Decimal.random = function (dp) {
        return new System.Decimal(Bridge.$Decimal.random(dp));
    };

    System.Decimal.exp = function (d) {
        return new System.Decimal(System.Decimal.getValue(d).exp());
    };

    System.Decimal.exp = function (d) {
        return new System.Decimal(System.Decimal.getValue(d).exp());
    };

    System.Decimal.ln = function (d) {
        return new System.Decimal(System.Decimal.getValue(d).ln());
    };

    System.Decimal.log = function (d, logBase) {
        return new System.Decimal(System.Decimal.getValue(d).log(logBase));
    };

    System.Decimal.pow = function (d, exponent) {
        return new System.Decimal(System.Decimal.getValue(d).pow(exponent));
    };

    System.Decimal.sqrt = function (d) {
        return new System.Decimal(System.Decimal.getValue(d).sqrt());
    };

    System.Decimal.prototype.isFinite = function () {
        return this.value.isFinite();
    };

    System.Decimal.prototype.isInteger = function () {
        return this.value.isInteger();
    };

    System.Decimal.prototype.isNaN = function () {
        return this.value.isNaN();
    };

    System.Decimal.prototype.isNegative = function () {
        return this.value.isNegative();
    };

    System.Decimal.prototype.isZero = function () {
        return this.value.isZero();
    };

    System.Decimal.prototype.log = function (logBase) {
        var d = new System.Decimal(this.value.log(logBase));
        d.$precision = Math.max(d.value.decimalPlaces(), this.$precision);
        return d;
    };

    System.Decimal.prototype.ln = function () {
        var d = new System.Decimal(this.value.ln());
        d.$precision = Math.max(d.value.decimalPlaces(), this.$precision);
        return d;
    };

    System.Decimal.prototype.precision = function () {
        return this.value.precision();
    };

    System.Decimal.prototype.round = function () {
        var old = Bridge.$Decimal.rounding,
            r;

        Bridge.$Decimal.rounding = 6;
        r = new System.Decimal(this.value.round());
        Bridge.$Decimal.rounding = old;

        return r;
    };

    System.Decimal.prototype.sqrt = function () {
        var d = new System.Decimal(this.value.sqrt());
        d.$precision = Math.max(d.value.decimalPlaces(), this.$precision);
        return d;
    };

    System.Decimal.prototype.toDecimalPlaces = function (dp, rm) {
        return new System.Decimal(this.value.toDecimalPlaces(dp, rm));
    };

    System.Decimal.prototype.toExponential = function (dp, rm) {
        return this.value.toExponential(dp, rm);
    };

    System.Decimal.prototype.toFixed = function (dp, rm) {
        return this.value.toFixed(dp, rm);
    };

    System.Decimal.prototype.pow = function (n) {
        var d = new System.Decimal(this.value.pow(n));
        d.$precision = Math.max(d.value.decimalPlaces(), this.$precision);
        return d;
    };

    System.Decimal.prototype.toPrecision = function (dp, rm) {
        return this.value.toPrecision(dp, rm);
    };

    System.Decimal.prototype.toSignificantDigits = function (dp, rm) {
        var d = new System.Decimal(this.value.toSignificantDigits(dp, rm));
        d.$precision = Math.max(d.value.decimalPlaces(), this.$precision);
        return d;
    };

    System.Decimal.prototype.valueOf = function () {
        return this.value.valueOf();
    };

    System.Decimal.prototype._toFormat = function (dp, rm, f) {
        var x = this.value;

        if (!x.isFinite()) {
            return x.toString();
        }

        var i,
            isNeg = x.isNeg(),
            groupSeparator = f.groupSeparator,
            g1 = +f.groupSize,
            g2 = +f.secondaryGroupSize,
            arr = x.toFixed(dp, rm).split("."),
            intPart = arr[0],
            fractionPart = arr[1],
            intDigits = isNeg ? intPart.slice(1) : intPart,
            len = intDigits.length;

        if (g2) {
            len -= (i = g1, g1 = g2, g2 = i);
        }

        if (g1 > 0 && len > 0) {
            i = len % g1 || g1;
            intPart = intDigits.substr(0, i);

            for (; i < len; i += g1) {
                intPart += groupSeparator + intDigits.substr(i, g1);
            }

            if (g2 > 0) {
                intPart += groupSeparator + intDigits.slice(i);
            }

            if (isNeg) {
                intPart = "-" + intPart;
            }
        }

        return fractionPart
            ? intPart + f.decimalSeparator + ((g2 = +f.fractionGroupSize)
                ? fractionPart.replace(new RegExp("\\d{" + g2 + "}\\B", "g"),
                    "$&" + f.fractionGroupSeparator)
                : fractionPart)
            : intPart;
    };

    System.Decimal.prototype.toFormat = function (dp, rm, provider) {
        var config = {
                decimalSeparator : ".",
                groupSeparator : ",",
                groupSize : 3,
                secondaryGroupSize : 0,
                fractionGroupSeparator : "\xA0",
                fractionGroupSize : 0
            },
            d;

        if (provider && !provider.getFormat) {
            config = Bridge.merge(config, provider);
            d = this._toFormat(dp, rm, config);
        } else {
            provider = provider || System.Globalization.CultureInfo.getCurrentCulture();

            var nfInfo = provider && provider.getFormat(System.Globalization.NumberFormatInfo);

            if (nfInfo) {
                config.decimalSeparator = nfInfo.numberDecimalSeparator;
                config.groupSeparator = nfInfo.numberGroupSeparator;
                config.groupSize = nfInfo.numberGroupSizes[0];
            }

            d = this._toFormat(dp, rm, config);
        }

        return d;
    };

    System.Decimal.prototype.getBytes = function () {
        var s = this.value.s,
            e = this.value.e,
            d = this.value.d,
            bytes = System.Array.init(23, 0, System.Byte);

        bytes[0] = s & 255;
        bytes[1] = e;

        if (d && d.length > 0) {
            bytes[2] = d.length * 4;

            for (var i = 0; i < d.length; i++) {
                bytes[i*4 + 3] = d[i] & 255;
                bytes[i*4 + 4] = (d[i] >> 8) & 255;
                bytes[i*4 + 5] = (d[i] >> 16) & 255;
                bytes[i*4 + 6] = (d[i] >> 24) & 255;
            }
        } else {
            bytes[2] = 0;
        }

        return bytes;
    };

    System.Decimal.fromBytes = function (bytes) {
        var value = new System.Decimal(0),
            s = Bridge.Int.sxb(bytes[0] & 255),
            e = bytes[1],
            ln = bytes[2],
            d = [];

        value.value.s = s;
        value.value.e = e;

        if (ln > 0) {
            for (var i = 3; i < (ln + 3);) {
                d.push(bytes[i] | bytes[i + 1] << 8 | bytes[i + 2] << 16 | bytes[i + 3] << 24);
                i = i + 4;
            }
        }

        value.value.d = d;

        return value;
    };

    Bridge.$Decimal.config({ precision: 29 });

    System.Decimal.Zero = System.Decimal(0);
    System.Decimal.One = System.Decimal(1);
    System.Decimal.MinusOne = System.Decimal(-1);
    System.Decimal.MinValue = System.Decimal("-79228162514264337593543950335");
    System.Decimal.MaxValue = System.Decimal("79228162514264337593543950335");
    System.Decimal.precision = 29;
