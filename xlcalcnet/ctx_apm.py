# -*- coding: utf-8 -*-
"""
Spyder Editor
"""

from xlcalcnet.dist_elementary import \
    ctx_arcsine, ctx_cauchy, ctx_dagum, ctx_exponential, ctx_fisk, \
    ctx_frechet, ctx_gev, ctx_genpareto, ctx_gompertz, ctx_gumbel, \
    ctx_hyperexponential, ctx_kumaraswamy, ctx_laplace, ctx_logistic,  \
    ctx_lomax, ctx_pareto, ctx_rayleigh, ctx_shifted_gompertz,   \
    ctx_singh_maddala, ctx_triangular, ctx_uniform, ctx_weibull

from xlcalcnet.dist_errorfunction import \
    ctx_birnb_saunders, ctx_emg, ctx_folded_normal, ctx_half_normal,  \
    ctx_johnson_sb, ctx_johnson_su, ctx_levy, ctx_lognormal, ctx_moyal, \
    ctx_normal, ctx_normal_max, ctx_normal_maxmod, ctx_sasnormal,  \
    ctx_skewnormal, ctx_trunc_normal, ctx_wald

from xlcalcnet.dist_gammafunction import \
    ctx_amoroso, ctx_chi, ctx_chi2, ctx_logrv_chi2, ctx_gamma, ctx_hypoexp, \
    ctx_invchi2, ctx_invgamma, ctx_maxwell, ctx_lindley, ctx_nakagami, \
    ctx_skew_exp_power, ctx_stacy

from xlcalcnet.dist_betafunction import \
    ctx_beta, ctx_logrv_beta, ctx_beta_prime, ctx_genbeta1, ctx_genbeta2, \
    ctx_genlogistic, ctx_gen_beta_exp, ctx_feller_pareto, ctx_fisher_f, \
    ctx_fisher_z, ctx_student_t, ctx_skew_t, ctx_pearson_rho \

from xlcalcnet.dist_noncentral import \
    ctx_chi2_nc, ctx_chi_nc, ctx_rice, ctx_student_t_nc, \
    ctx_pearson_rho_nc, ctx_fisher_f_nc, ctx_beta_nc_type_I, \
    ctx_logrv_beta_nc_type_II, ctx_fisher_r2, \
    ctx_logrv_fisher_1mr2, ctx_student_t_2nc, ctx_fisher_f_2nc

from xlcalcnet.dist_mcp_means import \
    ctx_nmax_corr, ctx_nmm_corr, ctx_normal_range, ctx_smax, ctx_smm, \
    ctx_dunnett1_t, ctx_dunnett2_t, ctx_nair_t, ctx_halperin_t,  \
    ctx_studentized_range

from xlcalcnet.dist_mvstats import \
    ctx_lrt_s0, ctx_lrt_x0_s0, ctx_betaproduct, ctx_logrv_betaproduct,  \
    ctx_bartlett, ctx_wilks_ip, ctx_mauchley, ctx_wilks_cs, ctx_wilks_iblocks,\
    ctx_box_nsame_cov, ctx_box_nsame_means_cov, ctx_box_cov, ctx_box_mvn, \
    ctx_roy, ctx_wilks_lambda, ctx_pillai_v, ctx_hotelling_t2, \
    ctx_wilks_lambda_glm,  ctx_wilks_lambda_corr

from xlcalcnet.dist_misc_cont import \
    ctx_levy_alpha_stable, ctx_landau, ctx_pearson_type_IV, ctx_meixner, \
    ctx_voigt_profile, ctx_wrapped_cauchy, ctx_wrapped_normal, \
    ctx_von_mises, ctx_gen_inv_gaussian, ctx_harmonic, ctx_halphen_a, \
    ctx_halphen_b, ctx_halphen_ib,  ctx_gen_hyperbolic, ctx_hyperbolic, \
    ctx_variance_gamma

from xlcalcnet.dist_elementary_discrete import \
    ctx_geometric, ctx_poisson, ctx_logseries, ctx_skellam, ctx_binomial, \
    ctx_negative_binomial, ctx_delaporte, ctx_betapoisson, ctx_betabinomial, \
    ctx_beta_negbinomial, ctx_hypergeometric, ctx_neghypergeo, ctx_polya, \
    ctx_genhypergeo, ctx_hypergeo_nc_fisher, ctx_zeta

from xlcalcnet.dist_lattice_ranktests import \
    ctx_wilcoxon, ctx_bennett, ctx_mann_whitney_u, ctx_mann_whitney_u_lehmann,\
    ctx_mann_whitney_u_milton, ctx_kendall_tau, ctx_jterpsta_s, ctx_page_l, \
    ctx_page_l_nc_milton

from xlcalcnet.dist_nonlattice_ranktests import \
    ctx_friedman, ctx_kruskal_wallis



from flint import arb, acb
from xlcalcnet import ctx_ap , mathap
ap = ctx_ap.APContext()

from xlcalcnet import ctx_shared
ctxm = ctx_shared.ctxUtil()
from xlcalcnet.mpmath import mp

class apm():

    # %% General functions


    def __init__(self):
        pass


# %% 2 Contexts and a minimal set of context functions


# %%%  2.1 Contexts in xlcalcnet: common interface


# 2.1.1 A minimal set of context functions


    @property
    def name(self):
        return "apm"

    @property
    def fmtname(self):
        return "    apm"

    @property
    def realctx(self):
        return self

    @property
    def cplxctx(self):
        return self

    def fmt(self, z):
        z = self.t(z)
        s1 = str(z.real)
        if self.ismpf(z):
            return s1
        else:
            s2 = str(z.imag)
            return "(" + s1 + ", " + s2 + ")"



    @property
    def realtype(self):
        return ap.mpf

    @property
    def complextype(self):
        return ap.mpc




# 2.1.2 Creating a real number
    def mpf(self, x):
        return ap.mpf(x)

# 2.1.3 Creating a complex number
    def mpc(self, x, y=None):
        return ap.mpc(x, y)


# 2.1.4 Getting and setting the current precision (in bits)
    @property
    def prec(self):
        return ap.prec

    @prec.setter
    def prec(self, value):
        ap.prec = int(value)

# 2.1.5 Getting and setting the current decimal precision (in digits)
    @property
    def dps(self):
        return ap.dps

    @dps.setter
    def dps(self, value):
        ap.dps = int(value)


# 2.1.6 Getting and setting the current decimal precision (in digits)
    @property
    def pretty(self):
        return ap.pretty

    @pretty.setter
    def pretty(self, value):
        ap.pretty = bool(value)




# %%%  2.2 Arithmetic operations


    def fma(self, x, y, z):
        return x * y + z

    def fmax(self, x, y):
        if (x >= y): return x
        else: return y

    def fmin(self, x, y):
        if (x <= y): return x
        else: return y



    def fadd(self, x, y, **kwargs):
        return ap.fadd(x, y, **kwargs)

    def fsub(self, x, y, **kwargs):
        return ap.fsub(x, y, **kwargs)

    def fneg(self, x, **kwargs):
        return ap.fneg(x, **kwargs)

    def fmul(self, x, y, **kwargs):
        return ap.fmul(x, y, **kwargs)

    def fdiv(self, x, y, **kwargs):
        return ap.fdiv(x, y, **kwargs)

##    def fmod(self, x, y):
##        return ap.fdiv(x, y)

    def fsum(self, terms, absolute=False, squared=False):
        return ap.fsum(terms, absolute, squared)

    def fprod(self, factors):
        return ap.fprod(factors)

    def fdot(self, A, B=None, conjugate=False):
        return ap.fdot(A, B, conjugate)




# %%%  2.3 Functions related to intervals and balls

# 2.3.1 Middle value of an interval or ball
    def mid(self, z):
        z = self.t(z)
        return z.mid()

# 2.3.2 Radius of an interval or ball
    def radius(self, z):
        z = self.t(z)
        return z.delta

# 2.3.3 Left border of an interval or ball
    def left(self, z):
        z = self.t(z)
        return z.a

# 2.3.4 Left border of an interval or ball
    def right(self, z):
        z = self.t(z)
        return z.b

# 2.3.5 Absolute value of the left end of an interval
    def absmin(self, z):
        return ap.absmin(z)

# 2.3.6 Absolute value of the right end of an interval
    def absmax(self, z):
        return ap.absmax(z)



# %%%  2.4 Complex components


    def abs(self, z):
        z = self.t(z)
        return abs(z)


    def fabs(self, z):
        z = self.t(z)
        return abs(z)

    def sign(self, z):
        z = self.t(z)
        if z == 0: return z
        else: return z / abs(z)

    def re(self, z):
        z = self.t(z)
        return z.real

    def real(self, z):
        return self.re(z)

    def im(self, z):
        z = self.t(z)
        return z.imag

    def imag(self, z):
        return self.im(z)

    def arg(self, z):
        z = self.t(z)
        return acb(z).arg()

    def phase(self, z):
        z = self.t(z)
        return acb(z).arg()

    def conj(self, z):
        z = self.t(z)
        if z.imag.is_zero(): return z
        else: return z.conjugate()

    def polar(self, z):
        z = self.t(z)
        return (self.abs(z), self.phase(z))

    def rect(self, r, phi):
        r = self.t(r)
        phi = self.t(phi)
        return r * self.expj(phi)



# %%%  2.5 Integer and fractional parts


    def floor(self, x):
        x = self.t(x)
        return x.floor()

    def ceil(self, x):
        x = self.t(x)
        return x.ceil()




    def rint(self, z):
        return self.nint(z)

    def nearbyint(self, z):
        return self.nint(z)


    def round(self, z):
        z = self.t(z)
        return self.nint(z)


    def trunc(self, x):
        x = self.t(x)
        return self.floor(x) if x >= 0 else self.ceil(x)


    def lrint(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        s = z.mid().str(radius=False)
        return ereal.lrint(s)

    def llrint(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        s = z.mid().str(radius=False)
        return ereal.llrint(s)


    def lround(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        s = z.mid().str(radius=False)
        return ereal.lround(s)

    def llround(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        s = z.mid().str(radius=False)
        return ereal.llround(s)


    def nint(self, z):
        z = self.t(z)
        s = z.mid().str(radius=False)
        x = mp.convert(s)
        res = mp.nint(x)
        return self.t(str(res))

    def frac(self, z):
        return ap.frac(z)


# %%%  2.6 Tolerances and approximate comparisons

    def chop(self, x, tol=None):
        return ap.chop(x, tol)

    def almosteq(self, s, t, rel_eps=None, abs_eps=None):
        return ap.almosteq(s, t, rel_eps, abs_eps)



# %%%  2.7 Properties of numbers

    def signbit(self, z):
        if (z < 0): return 1
        else: return 0



    def ismpf(self, z):
        return ap.ismpf(z)

    def ismpc(self, z):
        return ap.ismpc(z)

#Extra
    def isreal(self, z):
        z = self.t(z)
        return ap.ismpf(z)

#Extra
    def iscomplex(self, z):
        z = self.t(z)
        return ap.ismpc(z)

#Extra
    def iszero(self, z):
        z = self.t(z)
        return ap.iszero(z)


    def isinf(self, z):
        z = self.t(z)
        return ap.isinf(z)




    def isposinf(self, z):
        z = self.t(z)
        return ap.isinf(z) and z>0

    def isneginf(self, z):
        z = self.t(z)
        return ap.isinf(z) and z<0

    def iszero(self, z):
        z = self.t(z)
        return z==0

    def isone(self, z):
        z = self.t(z)
        return z==1

    def isinteger(self, z):
        z = self.t(z)
        return ap.isint(z)




    def isnan(self, z):
        z = self.t(z)
        return ap.isnan(z)

    def isnormal(self, z):
        z = self.t(z)
        return ap.isnormal(z)




    def isnumber(self, z):
        z = self.t(z)
        return not(self.isinf(z) or self.isnan(z))

    def isregular(self, z):
        z = self.t(z)
        return self.isnumber(z) and (z != self.t(0))

    def isunordered(self, x, y):
        x = self.t(x)
        y = self.t(y)
        return self.isnan(x) or self.isnan(y)

    def fitsint32(self, z):
        z = self.t(z)
        if not(self.isnumber(z)): return False
        return (z >= self.t('-2147483648')) and (z <= self.t('2147483647'))

    def fitsint64(self, z):
        z = self.t(z)
        if not(self.isnumber(z)): return False
        return (z >= self.t('-9223372036854775808')) and (z <= self.t('9223372036854775807'))




    def isfinite(self, z):
        z = self.t(z)
        return ap.isfinite(z)

    def isint(self, z):
        z = self.t(z)
        return ap.isint(z)

#Extra
    def isnpint(self, z):
        z = self.convert(z)
        return ap.isnpint(z)




    def copysign(self, x, y):
        x = self.t(x)
        y = self.t(y)
        return self.abs(x) * self.sign(y)


    def fdim(self, x, y):
        x = self.t(x)
        y = self.t(y)
        if (x > y): return x - y
        else: return self.zero


    def ldexp(self, z, e):
        z = self.t(z)
        e = int(e)
        return z * 2**e

    def scalbn(self, x, n):
        return self.ldexp(x, n)

    def scalbln(self, x, n):
        return self.ldexp(x, n)



    def frexp(self, z):
        z = self.t(z)
        if self.isnormal(z):
            s = z.mid().str(radius=False)
            x = mp.convert(s)
            res = mp.frexp(x)
            return (self.t(str(res[0])), res[1])
        else: return (z, 0)


    def logb(self, z):
        z = self.t(z)
        res = self.frexp(z)
        return self.t(res[1] - 1)


    def ilogb(self, z):
        z = self.t(z)
        res = self.frexp(z)
        return int(res[1] - 1)




    def mag(self, z):
        z = self.t(z)
        return ap.mag(z)

    def nint_distance(self, z):
        z = self.t(z)
        return ap.nint_distance(z)


    def modf(self, x):
        x = self.t(x)
        return (self.trunc(x), self.fractionalpart(x))

    def fmod(self, x, y):
        x = self.t(x)
        y = self.t(y)
        res = x - y * self.floor(x/y)
        return res

    def frac(self, x):
        x = self.t(x)
        return x - self.floor(x)

    def fractionalpart(self, x):
        x = self.t(x)
        s = self.sign(x)
        x = abs(x)
        res = x - self.floor(x)
        return s * res



    def remainder(self, x, y):
        x = self.t(x)
        y = self.t(y)
        n = self.nint(x/y)
        res = x - n * y
        return res


    def remquo(self, x, y):
        from xlcalcnet import ereal
        res1 = ereal.remquo(x, y)
        i1 = int(res1.Item2)
        res0 = self.remainder(x,y)
        return (res0, i1)


    def ulp(self, x):
        # Note: eps = ulp(0)
        x = mp.convert(x)
        if x < 0: x = -x
        # See https://github.com/mpmath/mpmath/issues/1020
        # See https://docs.python.org/3/library/math.html#math.ulp
        _, _, e, bc = x._mpf_
        res = mp.mpf((0, 1, e + (bc - mp.prec), 1))
        return self.t(str(res))

    def epsilon(self):
        return self.eps

    def maxvalue(self):
        return self.t('2.09857871646738769240435811688383907063809796547335262778664622571024044777576820818355304E+323228496')

    def lowestvalue(self):
        return self.t('-2.09857871646738769240435811688383907063809796547335262778664622571024044777576820818355304E+323228496')

    def minposvalue(self):
        return self.t('2.38256490488795107321616978173267452041519612555923978795502375260094538610432437489305775E-323228497')


    def nextafter(self, x, y):
        # See https://docs.python.org/3/library/math.html#math.nextafter
        x = self.t(x)
        y = self.t(y)
        if x == y: return y
        if x < y: return x + self.ulp(x)
        if x > y: return x - self.ulp(x)




# %%%  2.8 Number generation


    def fraction(self, p, q):
        return ap.fraction(p, q)

    def rand(self):
        return ap.rand()

    def arange(self, *args):
        return ap.arange(*args)

    def linspace(self, *args, **kwargs):
        return ap.arange(*args, **kwargs)





# %%%  2.9 Exact Mathematical Constants


    @property
    def zero(self):
        return +ap.zero

    @property
    def negzero(self):
        return -ap.zero

    @property
    def one(self):
        return +ap.one

    @property
    def j(self):
        return +ap.j

    @property
    def onej(self):
        return +ap.j

    @property
    def inf(self):
        return +ap.inf

    @property
    def ninf(self):
        return +ap.ninf

    @property
    def neginf(self):
        return +ap.ninf

    @property
    def nan(self):
        return +ap.nan



# %%%  2.10 Approximate Mathematical Constants



    @property
    def eps(self):
        return +arb((2,-self.prec))

    @property
    def ln2(self):
        return +arb.const_log2()

    @property
    def ln10(self):
        return +arb.const_log10()

    @property
    def pi(self):
        return +arb.pi()

    @property
    def e(self):
        return +arb.const_e()

    @property
    def euler(self):
        return +arb.const_euler()

    @property
    def egamma(self):
        return +arb.const_euler()

    @property
    def phi(self):
        return +(1+arb(5).sqrt())/2

    @property
    def catalan(self):
        return +arb.const_catalan()

    @property
    def khinchin(self):
        return +arb.const_khinchin()

    @property
    def glaisher(self):
        return +arb.const_glaisher()

    @property
    def apery(self):
        return +arb(3).zeta()

    @property
    def degree(self):
        return +arb.pi() / arb(180)








# %%%  2.11 Utility functions


    def force_complex(self, z):
        return acb(z)


    def t(self, x, y=None):
        return mathap.convert(x, y)


    def convert(self, z):
        return self.t(z)

    def mpmathify(self, z):
        return self.t(z)


    def union(self, x, y):
        xa = x.a
        xb = x.b
        ya = y.a
        yb = y.b
        l = xa
        if l > xb:
            l = xb
        if l > ya:
            l = ya
        if l > yb:
            l = yb
        r = xa
        if r < xb:
            r = xb
        if r < ya:
            r = ya
        if r < yb:
            r = yb
        #return iv.mpf([l, r])





    def nstr(self, x, n=6, **kwargs):
        return ap.nstr(x, n, **kwargs)

    def nprint(self, x, n=6, **kwargs):
        return ap.nprint(x, n, **kwargs)


# dispose later

    def to_float(self, z):
        return float(z)

    def from_mpf(self, z):
        return self.t(str(z))


# %%%  2.12 Precision management


    def autoprec(self, f, maxprec=None, catch=(), verbose=False):
        return ap.autoprec(f, maxprec, catch, verbose)

    def workprec(self, n, normalize_output=False):
        return ap.workprec(n, normalize_output)

    def workdps(self, n, normalize_output=False):
        return ap.workdps(n, normalize_output)

    def extraprec(self, n, normalize_output=False):
        return ap.extraprec(n, normalize_output)

    def extradps(self, n, normalize_output=False):
        return ap.extradps(n, normalize_output)



# %%%  2.13 Performance and debugging


    def memoize(self, f):
        return ap.memoize(f)

    def maxcalls(self, f, N):
        return ap.maxcalls(f, N)

# monitor and timing are not ctx functions


# %%%  2.14 Additonal functionality


    def plot(self, f, xlim=[- 5, 5], ylim=None, points=200, file=None,
            dpi=None, singularities=[], axes=None):
        res = ap.plot(f, xlim, ylim, points, file, dpi, singularities, axes)
        return res





# %% 3 Scalar elementary functions

# %%%  3.1 Exponential and related functions

    def exp(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).exp()
        return acb(z).exp()

    def expj(self, z):
        z = self.t(z)
        return self.cos(z) + self.sin(z) * self.j


    def expjpi(self, z):
        z = self.t(z)
        return acb(z).exp_pi_i()


    def exp10(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z*self.ln10).exp()
        return acb(z*self.ln10).exp()

    def exp2(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z*self.ln2).exp()
        return acb(z*self.ln2).exp()

    def expm1(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).expm1()
        return acb(z).expm1()

    def exp10m1(self, z):
        z = self.t(z) * self.ln10
        return self.expm1(z)

    def exp2m1(self, z):
        z = self.t(z)
        return self.expm1(z * self.ln2)

    def exprel(self, z):
        z = self.t(z)
        if (z == 0):
            return self.t(1)
        else:
            return self.expm1(z)/z

    def logistic(self, z):
        z = self.t(z)
        return 1/(1 + self.exp(-z))


# %%%  3.2 Logarithms and related functions

##    def logbase(self, z, b):
##        z = self.t(z)
##        b = self.t(b)
##        return self.log(z) / self.log(b)

    def ln(self, z):
        z = self.t(z)
        return self.log(z)

    def log(self, z, base=None):
        z = self.t(z)
        if base is None:
            if isinstance(z, arb): return arb(z).log()
            else: return acb(z).log()
        else:
            if isinstance(z, arb) and isinstance(base, arb):
                return arb(z).log() / arb(base).log()
            return acb(z).log()


    def log1p(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).log1p()
        return acb(z).log1p()

    def log10(self, z):
        z = self.t(z)
        return self.log(z)/self.ln10

    def log2(self, z):
        z = self.t(z)
##        return self.log(z,2)
        return self.log(z)/self.ln2

##        if isinstance(z, arb): return arb(z).log2()
##        return acb(z).log2()

    def log1mexp(self, z):
        z = self.t(z)
        x = self.fabs(z)
        if x < self.ln2:
            return self.log(-self.expm1(-x))
        else:
            return self.log1p(-self.exp(-x))

    def log2p1(self, z):
        z = self.t(z)
        return self.log1p(z)/self.ln2

    def log10p1(self, z):
        z = self.t(z)
        return self.log1p(z)/self.ln10

    # real result only for z<0

    def ln1mexp(self, z):
        z = self.t(z)
        return self.log(-self.expm1(z))

    def ln1pexp(self, z):
        z = self.t(z)
        return self.log1p(self.exp(z))

    def ln1pmx(self, z):
        z = self.t(z)
        return self.log1p(z) - z

    def logit(self, z):
        z = self.t(z)
        return self.log(z/(1-z))

    def lambertw(self, z, k):
        z = self.t(z)
        k = int(k)
        if isinstance(z, arb): return arb(z).lambertw(k)
        return acb(z).lambertw(k)

    def lambert_wk(self, z, k):
        z = self.t(z)
        k = int(k)
        if isinstance(z, arb): return arb(z).lambertw(k)
        return acb(z).lambertw(k)

    def lambert_w0(self, z, k=0):
        '''Returns lambertw(z), the Lambert W function z.'''
        z = self.t(z)
        return self.lambertw(z, 0)

    def lambert_wm1(self, z, k=0):
        '''Returns lambertw(z), the Lambert W function z.'''
        z = self.t(z)
        return self.lambertw(z, -1)

    def agm(self, a, b=1):
        a = self.t(a)
        b = self.t(b)
        if isinstance(a, arb) and isinstance(b, arb) : return arb(a).agm(b)
        return acb(a).agm(b)


# %%%  3.3 Square, roots and power functions

    def square(self, z):
        z = self.t(z)
        return z * z

    def sqr(self, z):
        '''Returns sqr(z) = z * z.'''
        z = self.t(z)
        return z * z

    def cube(self, z):
        '''Returns sqr(z) = z * z.'''
        z = self.t(z)
        return z * z * z


    def sqrt(self, z):
        z = self.t(z)
        if isinstance(z, arb) and (self.real(z)>=0): return arb(z).sqrt()
        return acb(z).sqrt()

    def rsqrt(self, z):
        z = self.t(z)
        if isinstance(z, arb) and (self.real(z)>=0): return arb(z).rsqrt()
        return acb(z).rsqrt()

    def sqrt1pm1(self, z):
        z = self.t(z)
        return self.expm1(self.log1p(z)/2)

    def cbrt(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).root(3)
        return acb(z).root(3)

    def cuberoot(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).root(3)
        return acb(z).root(3)

    def nthroot(self, z, n):
        z = self.t(z)
        return self.exp(self.log(z)/n)

    def root_si(self, z, n):
        return self.nthroot(z, n)


    def unitroot(self, k, n):
        return self.exp((2j*k*self.pi)/n)

    def hypot(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.sqrt(self.square(a) + self.square(b))

    def power(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return a**b

    def pow(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return a**b

    def pow_si(self, x, n):
        '''Returns pow(a, b) = exp(b*log(a)).'''
        return pow(x, n)


    def powm1(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.expm1(b * self.log(a))

    def pow1p(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.exp(b * self.log1p(a))

    def pow1pm1(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.expm1(b * self.log1p(a))

    def fibonacci(self, n):
        n = self.t(n)
        phi = self.phi
        return (phi**n - (-phi)**(-n))/(2*phi-1)

    def fibpoly(self, n, z):
        n = self.t(n)
        z = self.t(z)
        w = self.sqrt(z*z+4)
        return (1/w) * (((z+w)/2)**n - ((z-w)/2)**n)

    def lucas(self, n):
        n = self.t(n)
        phi = self.phi
        return phi**n + (-phi)**(-n)

    def lucaspoly(self, n, z):
        n = self.t(n)
        z = self.t(z)
        w = self.sqrt(z*z+4)
        return (((z+w)/2)**n + ((z-w)/2)**n)


# %%%  3.4 Trigonometric functions

    def radians(self, z):
        z = self.t(z)
        return z * self.degree

    def degrees(self, z):
        z = self.t(z)
        return z * 180 / self.pi

    def sin(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).sin()
        else:
            return acb(z).sin()

    def cos(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cos()
        return acb(z).cos()

    def tan(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).tan()
        return acb(z).tan()

    def sec(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sec()
        return acb(z).sec()

    def csc(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).csc()
        return acb(z).csc()

    def cot(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cot()
        return acb(z).cot()

    def hav(self, z):
        z = self.t(z)
        v = self.sin(0.5 * z)
        return v*v

    def sinpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sin_pi()
        return acb(z).sin_pi()

    def cospi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cos_pi()
        return acb(z).cos_pi()

    def tanpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).tan_pi()
        return acb(z).tan_pi()

    def cotpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cot_pi()
        return acb(z).cot_pi()

    def cscpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return 1/arb(z).sin_pi()
        return 1/acb(z).sin_pi()

    def secpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return 1/arb(z).cos_pi()
        return 1/acb(z).cos_pi()



    def sinc(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sinc()
        return acb(z).sinc()

    def sincpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sinc_pi()
        return acb(z).sinc_pi()


# %%%  3.5 Hyperbolic functions

    def sinh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sinh()
        return acb(z).sinh()

    def cosh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cosh()
        return acb(z).cosh()

    def tanh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).tanh()
        return acb(z).tanh()

    def sech(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sech()
        return acb(z).sech()

    def csch(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).csch()
        return acb(z).csch()

    def coth(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).coth()
        return acb(z).coth()


# %%%  3.6 Inverse trigonometric functions

    def asin(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).asin()
        return acb(z).asin()

    def acos(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).acos()
        return acb(z).acos()

    def atan(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).atan()
        return acb(z).atan()

    def atan2(self, x, y):
        x = self.t(x)
        y = self.t(y)
        if isinstance(x, arb) and isinstance(y, arb):
            return arb.atan2(x, y)
        raise Exception("NOT IMPLEMENTED")

    def asec(self, z):
        z = self.t(z)
        return self.acos(1/z)

    def acsc(self, z):
        z = self.t(z)
        return self.asin(1/z)

    def acot(self, z):
        z = self.t(z)
        return self.atan(1/z)

    def gd(self, z):
        z = self.t(z)
        return self.asin(self.tanh(z))

    def archav(self, z):
        z = self.t(z)
        return 2*self.asin(self.sqrt(z))


# %%%  3.7 Inverse hyperbolic functions

    def asinh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).asinh()
        return acb(z).asinh()

    def acosh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).acosh()
        return acb(z).acosh()

    def atanh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).atanh()
        return acb(z).atanh()

    def asech(self, z):
        z = self.t(z)
        return self.acosh(1/z)
##        if isinstance(z, arb): return arb(z).asech()
##        return acb(z).asech()

    def acsch(self, z):
        z = self.t(z)
        return self.asinh(1/z)
##        if isinstance(z, arb): return arb(z).acsch()
##        return acb(z).acsch()

    def acoth(self, z):
        z = self.t(z)
        return self.atanh(1/z)
        if isinstance(z, arb): return arb(z).acoth()
        return acb(z).acoth()

    def arcgd(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).acoth()
        return acb(z).acoth()


# %%%  3.8 Factorials and related functions

    def factorial(self, z):
        z = self.t(z)
        return self.gamma(z+1)

    def binomial(self, n, k):
        n = self.t(n)
        k = self.t(k)
        return self.gamma(n+1) / (self.gamma(k+1) * self.gamma(n-k+1))

    def multinomial(self, n, k):
        raise Exception("NOT IMPLEMENTED")

    def rf(self, z, n):
        z = self.t(z)
        n = self.t(n)
        return self.gamma(z+n) / self.gamma(z)

    def rising_factorial(self, z, n):
        z = self.t(z)
        n = self.t(n)
        return self.gamma(z+n) / self.gamma(z)

    def ff(self, z, n):
        z = self.t(z)
        n = self.t(n)
        return self.gamma(z+1) / self.gamma(z-n+1)

    def falling_factorial(self, z, n):
        z = self.t(z)
        n = self.t(n)
        return self.gamma(z+1) / self.gamma(z-n+1)

    def fac2(self, z):
        z = self.t(z)
        w = 0.25*(self.cospi(z)-1)
        return 2**(0.5*z) * (0.5*self.pi)**w * self.gamma(0.5*z+1)

    def doublefactorial(self, z):
        z = self.t(z)
        w = 0.25*(self.cospi(z)-1)
        return 2**(0.5*z) * (0.5*self.pi)**w * self.gamma(0.5*z+1)



# %%%  3.9 Gamma function and related functions

    def gamma(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).gamma()
        return acb(z).gamma()

    def gamma1pm1(self, z):
        '''Returns gamma(z+1)-1.'''
        z = self.t(z)
        return self.gamma(z+1)-1

    def rgamma(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).rgamma()
        return acb(z).rgamma()

    def loggamma(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).lgamma()
        return acb(z).lgamma()

    def lgamma(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).lgamma()
        return acb(z).lgamma()

    def beta(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.gamma(a) * self.gamma(b) / self.gamma(a+b)

    def gamma_ratio(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.gamma(a) / self.gamma(b)

    def gamma_delta_ratio(self, a, delta):
        a = self.t(a)
        delta = self.t(delta)
        return self.gamma(a) / self.gamma(a+delta)

    def catalan_c(self, z):
        z = self.t(z)
        w = self.gamma(z+1)
        return self.gamma(2*z+1) / ((z+1)*w*w)










# %% 15 Algebra with random variables

# 12.1-12.2 is just text


# %%% 12.3 Probability density function (pdf)


# 12.3.1 Calculating the pdf from the cdf

    def pdf_from_cdf(self):
        '''Calculates the pdf from the cdf'''
        return ctxm.pdf_from_cdf(self)

# 12.3.2 Calculating the pdf from the characteristic function

    def pdf_from_cf(self):
        '''Calculates the pdf from the characteristic function'''
        return ctxm.pdf_from_cf(self)


# %%% 12.4 Probability mass function (pmf)


# 12.4.1 Calculating the pmf from the cdf

    def pmf_from_cdf(self):
        '''Calculates the pmf from the cdf'''
        return ctxm.pmf_from_cdf(self)

# 12.4.2 Calculating the pmf from the characteristic function

    def pmf_from_cf(self):
        '''Calculates the pmf from the characteristic function'''
        return ctxm.pmf_from_cf(self)

# 12.4.3 Calculating the pmf from the factorial moments

    def pmf_from_factorialmoments(self):
        '''Calculates the pmf from the factorial moments'''
        return ctxm.pmf_from_factorialmoments(self)


# 12.4.4 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 12.5 Cumulative distribution function (cdf)


# 12.5.1 Calculating the cdf from the pdf

    def cdf_from_pdf(self):
        '''Calculates the cdf from the pdf'''
        return ctxm.cdf_from_pdf(self)

# 12.5.2 Calculating the cdf from the pmf vector

    def cdf_from_pmf_vector(self):
        '''Calculates the cdf from the pmf vector'''
        return ctxm.cdf_from_pmf_vector(self)


# 12.5.3 Calculating the cdf from the characteristic function, continuous cdf

    def cdf_from_cf_continuous(self):
        '''Calculates the cdf from the characteristic function,
        continuous distribution'''
        return ctxm.cdf_from_cf_continuous(self)


# 12.5.4 Calculating the cdf from the characteristic function
    # (lattice distribution)

    def cdf_from_cf_lattice(self):
        '''Calculates the cdf from the characteristic function,
        lattice distribution'''
        return ctxm.cdf_from_cf_lattice(self)

# 12.5.5 Calculating the cdf from the factorial moments (lattice distributions)

    def cdf_from_factorial_moments_lattice(self):
        '''Calculates the cdf from the factorial moments,
        lattice distribution'''
        return ctxm.cdf_from_factorial_moments_lattice(self)


# %%% 12.6 Percentage point function


# 12.6.1 Calculating the percentage point function from the cdf

    def qtf_from_cdf(self):
        '''Calculates the percentage point function from the cdf'''
        return ctxm.qtf_from_cdf(self)


# 12.6.2 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 12.7 Characteristic function


# 12.7.1 Calculating the characteristic function from the pdf

    def cf_from_pdf(self, cf):
        '''Calculates the characteristic function from the pdf,
        continuous distribution'''
        return ctxm.cf_from_pdf(self, cf)

# 12.7.2 Calculating the characteristic function from the pmf
    # (lattice distribution)

    def cf_from_pmf(self, cf):
        '''Calculates the characteristic function from the pmf,
        lattice distribution'''
        return ctxm.cf_from_pmf(self, cf)

# 12.7.3 Calculating the characteristic function from the percentage
    # point function

    def cf_from_qtf(self):
        '''Calculates the characteristic function from the percentage point
        function, continuous distribution'''
        return ctxm.cf_from_qtf(self)

# 12.7.4 Calculating the characteristic function from the raw moments

    def cf_from_rawmoments(self):
        '''Calculates the characteristic function from the raw moments,
        continuous distribution'''
        return ctxm.cf_from_rawmoments(self)


# %%% 12.8 Moment generating function


# 12.8.1 Calculating the moment-generating function from the pdf

    def mgf_from_pdf(self):
        '''Calculates the moment-generating function from the pdf,
        continuous distribution'''
        return ctxm.mgf_from_pdf(self)

# 12.8.2 Calculating the moment-generating function from the
    # characteristic function

    def mgf_from_cf(self):
        '''Calculates the moment-generating function from the characteristic
        function, continuous distribution'''
        return ctxm.mgf_from_cf(self)

# 12.8.3 Calculating the moment-generating function from the
    # cumulant-generating function

    def mgf_from_cgf(self):
        '''Calculates the moment-generating function from the
        cumulant-generating, continuous distribution'''
        return ctxm.mgf_from_cgf(self)

# 12.8.4 Calculating the moment-generating function from the
    # probability-generating function

    def mgf_from_pgf(self):
        '''Calculates the moment-generating function from the
        probability-generating, lattice distribution'''
        return ctxm.mgf_from_pgf(self)

# 12.8.5 Calculating the moment-generating function from the raw moments

    def mgf_from_rawmoments(self):
        '''Calculates the moment-generating function from the
        raw moments, continuous distribution'''
        return ctxm.mgf_from_rawmoments(self)

# 12.8.6 Calculating the moment-generating function from the pmf vector

    def mgf_from_pmf_vector(self, t, pmfvec):
        '''Calculates the moment-generating function from the
        pmf vector, lattice distribution'''
        return ctxm.mgf_from_pmf_vector(self, t, pmfvec)


# %%% 12.9 Cumulant generating function


# 12.9.1 Calculating the cumulant-generating function from the
    # characteristic function

    def cgf_from_cf(self):
        '''Calculates the cumulant-generating function from the characteristic
        function, continuous distribution'''
        return ctxm.cgf_from_cf(self)

# 12.9.2 Calculating the cumulant-generating function from the
    # moment-generating function

    def cgf_from_mgf(self):
        '''Calculates the cumulant-generating function from the
        moment-generating function, continuous distribution'''
        return ctxm.cgf_from_mgf(self)

# 12.9.3 Calculating the cumulant-generating function from the
    # probability-generating function

    def cgf_from_pgf(self):
        '''Calculates the cumulant-generating function from the
        probability-generating function, continuous distribution'''
        return ctxm.cgf_from_pgf(self)

# 12.9.4 Calculating the cumulant-generating function from the cumulants

    def cgf_from_cumulants(self):
        '''Calculates the cumulant-generating function from the
        cumulants, continuous distribution'''
        return ctxm.cgf_from_cumulants(self)

# 12.9.5 Calculating the cumulant-generating function from the pmf vector

    def cgf_from_pmf_vector(self, t, pmfvec):
        '''Calculates the cumulant-generating function from the
        pmf vector, lattice distribution'''
        return ctxm.cgf_from_pmf_vector(self, t, pmfvec)


# %%% 12.10 Probability generating function


# 12.10.1 Calculating the probability-generating function from the pmf vector

    def pgf_from_pmf_vector(self):
        '''Calculates the probability-generating function from the
        pmf vector, lattice distribution'''
        return ctxm.pgf_from_pmf_vector(self)

# 12.10.1 Calculating the probability-generating function from the
    # moment-generating function

    def pgf_from_mgf(self):
        '''Calculates the probability-generating function from the
        moment-generating function, lattice distribution'''
        return ctxm.pgf_from_mgf(self)


# %%% 12.11 Factorial Moments


# 12.11.1 Calculating the factorial moments from the raw moments

    def factorialmoments_from_rawmoments(self, mraw):
        '''Calculates the factorial moments from the raw moments,
        lattice distribution'''
        return ctxm.factorialmoments_from_rawmoments(self, mraw)

# 12.11.2 Calculating the factorial moments from the cumulants

    def factorialmoments_from_cumulants(self, mraw):
        '''Calculates the factorial moments from the raw moments,
        lattice distribution'''
        return ctxm.factorialmoments_from_cumulants(self, mraw)


# %%% 12.12 Raw Moments


# 12.12.1 Calculating the raw moments from the pdf

    def rawmoments_from_pdf(self, pdf):
        '''Calculates the raw moments from the pdf'''
        return ctxm.rawmoments_from_pdf(self, pdf)

# 12.12.2 Calculating the raw moments from the pmf vector

    def rawmoments_from_pmfvector(self, x, nl, order, show=False):
        '''Calculates the raw moments from the pmf vector'''
        return ctxm.rawmoments_from_pmfvector(self, x, nl, order, show)

# 12.12.3 Calculating the raw moments from the factorial moments

    def rawmoments_from_factorialmoments(self, mfac):
        '''Calculates the raw moments from the factorial moments'''
        return ctxm.rawmoments_from_factorialmoments(self, mfac)

# 12.12.4 Calculating the raw moments from the central moments
    def rawmoments_from_centralmoments(self, mu):
        '''Calculates the raw moments from the central moments'''
        return ctxm.rawmoments_from_centralmoments(self, mu)

# 12.12.5 Calculating the raw moments from the cumulants

    def rawmoments_from_cumulants(self, kappa):
        '''Calculates the raw moments from the cumulants'''
        return ctxm.rawmoments_from_cumulants(self, kappa)

# 12.12.6 Calculating the raw moments from the moment-generating function

    def rawmoments_from_mgf(self):
        '''Calculates the raw moments from the moment-generating function'''
        return ctxm.rawmoments_from_mgf(self)

# 12.12.7 Calculating the raw moments from the characteristic function

    def rawmoments_from_cf(self):
        '''Calculates the raw moments from the characteristic function'''
        return ctxm.rawmoments_from_cf(self)

# 12.12.8 Calculating the raw moments from the probability-generating function

    def rawmoments_from_pgf(self):
        '''Calculates the raw moments from the probability-generating
        function'''
        return ctxm.rawmoments_from_pgf(self)


# %%% 12.13 Central Moments

# 12.12.1 Calculating the central moments from the factorial moments

    def centralmoments_from_factorialmoments(self, mfac):
        '''Calculates the central moments from the factorial moments'''
        return ctxm.centralmoments_from_factorialmoments(self, mfac)

# 12.12.1 Calculating the central moments from the raw moments

    def centralmoments_from_rawmoments(self, mraw):
        '''Calculates the central moments from the raw moments'''
        return ctxm.centralmoments_from_rawmoments(self, mraw)

# 12.12.2 Calculating the central moments from the cumulants

    def centralmoments_from_cumulants(self):
        '''Calculates the central moments from the cumulants'''
        return ctxm.centralmoments_from_cumulants(self)


# %%% 12.14 Cumulants

# 12.14.1 Calculating the cumulants from the pmf vector

    def cumulants_from_pmfvector(self, x, nl, order, show=False):
        '''Calculates the cumulants from the pmf vector'''
        return ctxm.cumulants_from_pmfvector(self, x, nl, order, show)

# 12.14.2 Calculating the cumulants from the factorial moments

    def cumulants_from_factorialmoments(self, mfac):
        '''Calculates the cumulants from the factorial moments'''
        return ctxm.cumulants_from_factorialmoments(self, mfac)

# 12.14.3 Calculating the cumulants from the raw moments

    def cumulants_from_rawmoments(self, mu):
        '''Calculates the cumulants from the raw moments'''
        return ctxm.cumulants_from_rawmoments(self, mu)

    def cumulants_from_rawmoments_list(self, mu):
        '''Calculates the cumulants from the raw moments'''
        return ctxm.cumulants_from_rawmoments_list(self, mu)

# 12.14.4 Calculating the cumulants from the central moments

    def cumulants_from_centralmoments(self, mu):
        '''Calculates the cumulants from the central moments'''
        return ctxm.cumulants_from_centralmoments(self, mu)

# 12.14.5 Calculating the cumulants from the cumulant-generating function

    def cumulants_from_cgf(self, cgf):
        '''Calculates the cumulants from the cumulant-generating function'''
        return ctxm.cumulants_from_cgf(self, cgf)


# 12.15-12.18 is just text





# %% 4 Statistical distributions


# %% 4.1 Introduction (only text)


# %% 4.2 Base class for random variables with univariate distribution functions
    # Implemented in dist_base.py


# %% 4.3 Base class for random variables with univariate continuous distribution
    # functions
    # Implemented in dist_base.py


# %% 4.4 Base class for random variables with univariate discrete distribution
    # functions
    # Implemented in dist_base.py



# %% 4.5 Closed form distributions, based on elementary functions


# 4.5.1 Arcsine Distribution

    def dist_arcsine(self, a, b):
        '''Arcsine distribution'''
        return ctx_arcsine(self, a, b)


# 4.5.2 Cauchy distribution

    def dist_cauchy(self, a, b):
        '''Cauchy distribution'''
        return ctx_cauchy(self, a, b)


# 4.5.3 Exponential distribution

    def dist_exponential(self, lambda1):
        '''Exponential distribution'''
        return ctx_exponential(self, lambda1)


# 4.5.4 Gumbel (Generalized Extreme Value distribution Type-I) distribution

    def dist_gumbel(self, a, b):
        '''Gumbel (Generalized Extreme Value distribution Type-I)
        distribution'''
        return ctx_gumbel(self, a, b)


# 4.5.5 Hyperexponential Distribution

    def dist_hyperexponential(self, k, w, l):
        '''Hyperexponential Distribution'''
        return ctx_hyperexponential(self, k, w, l)



# 4.5.6 Kumaraswamy distribution

    def dist_kumaraswamy(self, a, b):
        '''Kumaraswamy distribution'''
        return ctx_kumaraswamy(self, a, b)


# 4.5.7 Laplace distribution

    def dist_laplace(self, a, b):
        '''Laplace distribution'''
        return ctx_laplace(self, a, b)


# 4.5.8 Logistic distribution

    def dist_logistic(self, a, b):
        '''Logistic distribution'''
        return ctx_logistic(self, a, b)


# 4.5.9 Pareto distribution

    def dist_pareto(self, a, b):
        '''Pareto distribution'''
        return ctx_pareto(self, a, b)


# 4.5.10 Rayleigh distribution

    def dist_rayleigh(self, b):
        '''Rayleigh distribution'''
        return ctx_rayleigh(self, b)


# 4.5.11 Triangular Distribution

    def dist_triangular(self, a, b, c):
        '''Triangular Distribution'''
        return ctx_triangular(self, a, b, c)


# 4.5.12 Uniform distribution

    def dist_uniform(self, a, b):
        '''Uniform distribution'''
        return ctx_uniform(self, a, b)


# 4.5.13 Weibull distribution

    def dist_weibull(self, a, b):
        '''Weibull distribution'''
        return ctx_weibull(self, a, b)


# 4.5.14 Dagum (Burr Type III) distribution

    def dist_dagum(self, a, b, p):
        '''Dagum (Burr Type III) distribution'''
        return ctx_dagum(self, a, b, p)


# 4.5.15 (log-logistic) distribution

    def dist_fisk(self, a, b):
        '''Fisk (log-logistic) distribution'''
        return ctx_fisk(self, a, b)


# 4.5.15 Fréchet (Generalized Extreme Value distribution Type-II) distribution

    def dist_frechet(self, a, b):
        '''Fréchet (Generalized Extreme Value distribution Type-II)
        distribution'''
        return ctx_frechet(self, a, b)


# 4.5.15 Generalized Extreme Value (GEV) distribution

    def dist_gev(self, lambda1):
        '''Generalized Extreme Value (GEV) distribution'''
        return ctx_gev(self, lambda1)


# 4.5.18 Generalized Pareto distribution

    def dist_genpareto(self, m, s, c):
        '''Generalized Pareto distribution'''
        return ctx_genpareto(self, m, s, c)



# 4.5.18 Gompertz-Makeham distribution

    def dist_gompertz(self, a, b, l):
        '''Gompertz distribution'''
        return ctx_gompertz(self, a, b, l)


# 4.5.19 Lomax distribution

    def dist_lomax(self, a, b):
        '''Lomax distribution'''
        return ctx_lomax(self, a, b)


# 4.5.20 Shifted Gompertz distribution

    def dist_shifted_gompertz(self, a, b):
        '''Shifted Gompertz distribution'''
        return ctx_shifted_gompertz(self, a, b)


# 4.5.21 Singh-Maddala (Burr Type XII) distribution

    def dist_singh_maddala(self, a, b, d):
        '''Singh-Maddala (Burr Type XII) distribution'''
        return ctx_singh_maddala(self, a, b, d)






# %% 4.6 Closed form distributions, based on the error function

# 4.6.1 Lévy distribution

    def dist_levy(self, a, b):
        '''Lévy distribution'''
        return ctx_levy(self, a, b)

# 4.6.2 Lognormal (Johnson SL) distribution

    def dist_lognormal(self, a, b):
        '''Lognormal (Johnson SL) distribution'''
        return ctx_lognormal(self, a, b)


# 4.6.3 Moyal Distribution

    def dist_moyal(self, a, b):
        '''Moyal Distribution'''
        return ctx_moyal(self, a, b)


# 4.6.4 Normal (Johnson SN) distribution

    def dist_normal(self, a, b):
        '''Normal (Johnson SN) distribution'''
        return ctx_normal(self, a, b)


# 4.6.5 Skew normal Distribution

    def dist_skewnormal(self, a, b, c):
        '''Skew normal Distribution'''
        return ctx_skewnormal(self, a, b, c)


# 4.6.6 Wald (or Inverse Gaussian) distribution

    def dist_wald(self, a, b):
        '''Wald (or Inverse Gaussian) distribution'''
        return ctx_wald(self, a, b)






# 4.6.7 Birnbaum-Saunders Distribution

    def dist_birnb_saunders(self, a, b):
        '''Birnbaum-Saunders Distribution'''
        return ctx_birnb_saunders(self, a, b)


# 4.6.8 Exponentially Modified Gaussian (EMG) distribution

    def dist_emg(self, a, b):
        '''Exponentially Modified Gaussian (EMG) distribution'''
        return ctx_emg(self, a, b)


# 4.6.9 Folded normal distribution

    def dist_folded_normal(self, a, b):
        '''Folded normal distribution'''
        return ctx_folded_normal(self, a, b)


# 4.6.10 Half-normal distribution

    def dist_half_normal(self, a, b):
        '''Half-normal distribution'''
        return ctx_half_normal(self, a, b)


# 4.6.11 Johnson SB distribution

    def dist_johnson_sb(self, a, b):
        '''Johnson SB distribution'''
        return ctx_johnson_sb(self, a, b)


# 4.6.12 Johnson SU distribution

    def dist_johnson_su(self, a, b):
        '''Johnson SU distribution'''
        return ctx_johnson_su(self, a, b)

# 4.6.13 Normal maximum distribution

    def dist_normal_max(self, k):
        '''Normal maximum distribution'''
        return ctx_normal_max(self, k)


# 4.6.14 Normal maximum modulus distribution

    def dist_normal_maxmod(self, k):
        '''Normal maximum modulus distribution'''
        return ctx_normal_maxmod(self, k)



# 4.6.15 Sinh-arcsinh normal distribution

    def dist_sasnormal(self, a, b, c):
        '''Skew normal Distribution'''
        return ctx_sasnormal(self, a, b, c)


# 4.6.16 Truncated normal distribution

    def dist_trunc_normal(self, a, b):
        '''Truncated normal distribution'''
        return ctx_trunc_normal(self, a, b)






# %% 4.7 Closed form distributions, based on the incomplete gamma function


# 4.7.1 Chi Distribution

    def dist_chi(self, nu):
        '''Chi Distribution'''
        return ctx_chi(self, nu)


# 4.7.2 Chi-Squared distribution

    def dist_chi2(self, nu):
        '''Chi-Squared distribution'''
        return ctx_chi2(self, nu)


# 4.7.3 Gamma (Pearson Type III) distribution

    def dist_gamma(self, a, b):
        '''Gamma (Pearson Type III) distribution'''
        return ctx_gamma(self, a, b)


# 4.7.4 Inverse chisquared distribution

    def dist_invchi2(self, a, b):
        '''Inverse chisquared distribution'''
        return ctx_invchi2(self, a, b)


# 4.7.5 Inverse Gamma (Pearson Type V) distribution

    def dist_invgamma(self, a, b):
        '''Inverse Gamma (Pearson Type V) distribution'''
        return ctx_invgamma(self, a, b)


# 4.7.6 Maxwell Distribution

    def dist_maxwell(self, b):
        '''Maxwell Distribution'''
        return ctx_maxwell(self, b)


# 4.7.7 Nakagami distribution

    def dist_nakagami(self, m, w):
        '''Nakagami distribution'''
        return ctx_nakagami(self, m, w)


# 4.7.8 Amoroso distribution

    def dist_amoroso(self, a, b):
        '''Amoroso distribution'''
        return ctx_amoroso(self, a, b)


# 4.7.9 Distribution of the logarithm of a chi^2 random variable

    def dist_logrv_chi2(self, nu):
        '''Distribution of the logarithm of a chi^2 random variable'''
        return ctx_logrv_chi2(self, nu)


# 4.7.10 Hypoexponential distribution

    def dist_hypoexp(self, n, l):
        '''Hypoexponential distribution'''
        return ctx_hypoexp(self, n, l)


# 4.7.11 Lindley distribution

    def dist_lindley(self, m, w):
        '''Nakagami distribution'''
        return ctx_lindley(self, m, w)


# 4.7.12 Skew exponential power distribution

    def dist_skew_exp_power(self, m, w):
        '''Nakagami distribution'''
        return ctx_skew_exp_power(self, m, w)


# 4.7.13 Stacy (generalized gamma) distribution

    def dist_stacy(self, m, w):
        '''Stacy (generalized gamma) distribution'''
        return ctx_stacy(self, m, w)




# %% 4.8 Closed form distributions, based on the incomplete beta function

# 4.8.1 Beta (Pearson Type I and II) distribution

    def dist_beta(self, a, b):
        '''Beta (Pearson Type I and II) distribution'''
        return ctx_beta(self, a, b)


# 4.8.2 Central Fisher F distribution

    def dist_fisher_f(self, a, b):
        '''Central Fisher F distribution'''
        return ctx_fisher_f(self, a, b)


# 4.8.3 Student t (Pearson Type VII) distribution

    def dist_student_t(self, n):
        '''Student t (Pearson Type VII) distribution'''
        return ctx_student_t(self, n)


# 4.8.4 Distribution of the negative logarithm of a beta variable

    def dist_logrv_beta(self, a, b):
        '''Distribution of the negative logarithm of a beta variable'''
        return ctx_logrv_beta(self, a, b)


# 4.8.5 Beta-prime (Pearson Type VI) distribution

    def dist_beta_prime(self, a, b):
        '''Beta-prime (Pearson Type VI) distribution'''
        return ctx_beta_prime(self, a, b)


# 4.8.6 Generalized Beta (Type 1) distribution

    def dist_genbeta1(self, a, b):
        '''Generalized Beta (Type 1) distribution'''
        return ctx_genbeta1(self, a, b)


# 4.8.7 Generalized Beta (Type 2) distribution

    def dist_genbeta2(self, a, b):
        '''Generalized Beta (Type 2) distribution'''
        return ctx_genbeta2(self, a, b)


# 4.8.8 Generalized logistic distribution

    def dist_genlogistic(self, a, b):
        '''Generalized logistic distribution'''
        return ctx_genlogistic(self, a, b)


# 4.8.9 Generalized beta-exponential distribution

    def dist_gen_beta_exp(self, a, b):
        '''Generalized beta-exponential distribution'''
        return ctx_gen_beta_exp(self, a, b)



# 4.8.10 Feller-Pareto distribution

    def dist_feller_pareto(self, a, b):
        '''Feller-Pareto distribution'''
        return ctx_feller_pareto(self, a, b)



# 4.8.11 Fisher z distribution

    def dist_fisher_z(self, a, b):
        '''Fisher z distribution'''
        return ctx_fisher_z(self, a, b)


# 4.8.12 Skew t-distribution

    def dist_skew_t(self, n):
        '''Student t (Pearson Type VII) distribution'''
        return ctx_skew_t(self, n)


# 4.8.13 Pearson’s rho distribution (under H0)

    def dist_pearson_rho(self, a, b):
        '''Pearson’s rho distribution (under H0)'''
        return ctx_pearson_rho(self, a, b)





# %% 4.9 Noncentral distribution functions


# 4.9.1 Noncentral chi^2 distribution

    def dist_chi2_nc(self, df_, lambda1_):
        '''Noncentral Chi distribution'''
        return ctx_chi2_nc(self, df_, lambda1_)


# 4.9.2 Noncentral Student t distribution

    def dist_student_t_nc(self, a, b):
        '''Noncentral Student t distribution'''
        return ctx_student_t_nc(self, a, b)


# 4.9.3 Noncentral Fisher F distribution

    def dist_fisher_f_nc(self, a, b):
        '''Noncentral Fisher F distribution'''
        return ctx_fisher_f_nc(self, a, b)


# 4.9.4 Noncentral Beta Type I distribution

    def dist_beta_nc_type_I(self, a, b):
        '''Noncentral Beta Type I distribution'''
        return ctx_beta_nc_type_I(self, a, b)



# 4.9.5 Noncentral Chi distribution

    def dist_chi_nc(self, a, b):
        '''Noncentral Chi distribution'''
        return ctx_chi_nc(self, a, b)


# 4.9.6 Rice distribution

    def dist_rice(self, a, b):
        '''Rice distribution'''
        return ctx_rice(self, a, b)


# 4.9.7 Noncentral distribution of the sample correlation coefficient

    def dist_pearson_rho_nc(self, a, b):
        '''Noncentral distribution of the sample correlation coefficient'''
        return ctx_pearson_rho_nc(self, a, b)


# 4.9.8 Noncentral Beta Type II distribution

    def dist_logrv_beta_nc_type_II(self, a, b):
        '''Noncentral Beta Type II distribution'''
        return ctx_logrv_beta_nc_type_II(self, a, b)


# 4.9.9 Noncentral distribution (Type I) of Fisher’s R^2

    def dist_fisher_r2(self, a, b):
        '''Noncentral distribution (Type I) of Fisher’s R^2'''
        return ctx_fisher_r2(self, a, b)


# 4.9.10 Noncentral distribution (Type II) of Fisher’s R^2

    def dist_logrv_fisher_1mr2(self, a, b):
        '''Noncentral distribution (Type II) of Fisher’s R^2'''
        return ctx_logrv_fisher_1mr2(self, a, b)


# 4.9.11 Doubly non-central Student t distribution

    def dist_student_t_2nc(self, a, b):
        '''Doubly non-central Student t distribution'''
        return ctx_student_t_2nc(self, a, b)


# 4.9.12 Doubly non-central Fisher F distribution

    def dist_fisher_f_2nc(self, a, b):
        '''Doubly non-central Fisher F distribution'''
        return ctx_fisher_f_2nc(self, a, b)






# %% 4.10 Distributions related to multiple comparisons of means

# 4.10.1 Overview and literature


# 4.10.2 Normal maximum distribution, equicorrelated case

    def dist_nmax_rho(self, k, rho):
        '''Normal maximum distribution, equicorrelated case'''
        return ctx_nmax_corr(self, k, rho)


# 4.10.3 Normal maximum modulus distribution, equicorrelated case

    def dist_nmm_rho(self, k, rho):
        '''Normal maximum modulus distribution, rhoij = li*lj'''
        return ctx_nmm_corr(self, k, rho)


# 4.10.4 Normal maximum distribution,  rhoij = li*lj

    def dist_nmax_rhoij(self, k, rho):
        '''Normal maximum distribution, rhoij = li*lj'''
        return ctx_nmax_corr(self, k, rho)


# 4.10.5 Normal maximum modulus distribution,  rhoij = li*lj

    def dist_nmm_rhoij(self, k, rho):
        '''Normal maximum modulus distribution, equicorrelated case'''
        return ctx_nmm_corr(self, k, rho)



# 4.10.6 Normal range distribution

    def dist_normal_range(self, k):
        '''Normal range distribution'''
        return ctx_normal_range(self, k)



# 4.10.7 Studentized maximum distribution

    def dist_smax(self, k, n):
        '''Studentized maximum distribution'''
        return ctx_smax(self, k, n)


# 4.10.8 Studentized maximum modulus distribution

    def dist_smm(self, k, n):
        '''Studentized maximum modulus distribution'''
        return ctx_smm(self, k, n)


# 4.10.9 Distribution of Dunnett’s t, one-sided

    def dist_dunnett1_t(self, k, n, rho):
        '''Distribution of Dunnett’s t, one-sided'''
        return ctx_dunnett1_t(self, k, n, rho)


# 4.10.10 Distribution of Dunnett’s t, two-sided

    def dist_dunnett2_t(self, k, n, rho):
        '''Distribution of Dunnett’s t, two-sided'''
        return ctx_dunnett2_t(self, k, n, rho)


# 4.10.11 Distribution of Nair's t, one-sided

    def dist_nair_t(self, a, b):
        '''Distribution of Nair's t, one-sided'''
        return ctx_nair_t(self, a, b)


# 4.10.12 Distribution of Halperin’s t, two-sided

    def dist_halperin_t(self, a, b):
        '''Distribution of Halperin’s t, two-sided'''
        return ctx_halperin_t(self, a, b)


# 4.10.13 Distribution of Nelson’s h, two-sided

    def dist_halperin_t(self, a, b):
        '''Distribution of Halperin’s t, two-sided'''
        return ctx_halperin_t(self, a, b)


# 4.10.14 Studentized range distribution

    def dist_studentized_range(self, a, b):
        '''Studentized range distribution'''
        return ctx_studentized_range(self, a, b)





# %% 4.11 Distribution functions related to multivariate statistical analysis



# 4.11.1 Distribution of the negative logarithm of a betaproduct variable

    def dist_logrv_betaproduct(self, a, b):
        '''Distribution of the negative logarithm of a betaproduct variable'''
        return ctx_logrv_betaproduct(self, a, b)


# 4.11.2 Distribution of the product of independent beta variables

    def dist_betaproduct(self, a, b):
        '''Distribution of the product of independent beta variables'''
        return ctx_betaproduct(self, a, b)


# 4.11.3 Central distribution of Wilks' Lambda

    def dist_wilks_lambda(self, a, b):
        '''Central distribution of Wilks' Lambda'''
        return ctx_wilks_lambda(self, a, b)


# 4.11.4 Central distribution of Wilks' Lvc

    def dist_wilks_lambda(self, a, b):
        '''Central distribution of Wilks' Lvc'''
        return ctx_wilks_lambda(self, a, b)


# 4.11.5 Central distribution of Wilks' Lvcm

    def dist_wilks_lambda(self, a, b):
        '''Central distribution of Wilks' Lvc'''
        return ctx_wilks_lambda(self, a, b)


# 4.11.6 Wilks_ip distribution

    def dist_wilks_ip(self, a, b):
        '''Wilks_ip distribution'''
        return ctx_wilks_ip(self, a, b)


# 4.11.7 Wilks_iblocks distribution

    def dist_wilks_iblocks(self, a, b):
        '''Wilks_iblocks distribution'''
        return ctx_wilks_iblocks(self, a, b)


# 4.11.8 Mauchley distribution

    def dist_mauchley(self, a, b):
        '''Bartlett distribution'''
        return ctx_mauchley(self, a, b)


# 4.11.9 Box_nsame_cov distribution

    def dist_box_nsame_cov(self, a, b):
        '''Wilks_iblocks distribution'''
        return ctx_box_nsame_cov(self, a, b)


# 4.11.10 Distribution of Box’s test of equality of k covariance matrices, unequal
    # sample sizes

    def dist_box_cov(self, a, b):
        '''Distribution of Box’s test of equality of k covariance matrices,
        unequal sample sizes'''
        return ctx_box_cov(self, a, b)


# 4.11.11 Distribution of Box’s test for same multivariate normal distributions,
    # unequal sample sizes

    def dist_box_mvn(self, a, b):
        '''Distribution of Box’s test for same multivariate normal
        distributions, unequal sample sizes'''
        return ctx_box_mvn(self, a, b)


# 4.11.12 Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix

    def dist_lrt_s0(self, a, b):
        '''Distribution of the modified likelihood ratio test (LRT) for a given
        covariance matrix'''
        return ctx_lrt_s0(self, a, b)


# 4.11.13 Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix and mean vector

    def dist_lrt_x0_s0(self, a, b):
        '''Distribution of the modified likelihood ratio test (LRT) for a given
        covariance matrix and mean vector'''
        return ctx_lrt_x0_s0(self, a, b)


# 4.11.14 Central distribution of Roy’s largest root

    def dist_roy(self, a, b):
        '''Central distribution of Roy’s largest root'''
        return ctx_roy(self, a, b)


# 4.11.15 Central distribution of Pillai’s V

    def dist_pillai_v(self, a, b):
        '''Central distribution of Pillai’s V'''
        return ctx_pillai_v(self, a, b)


# 4.11.16 Central distribution of Hotelling’s T2

    def dist_hotelling_t2(self, a, b):
        '''Central distribution of Hotelling’s T2'''
        return ctx_hotelling_t2(self, a, b)


# 4.11.17 Noncentral Distribution of Wilks' Lambda: MANOVA

    def dist_wilks_lambda_glm(self, a, b):
        '''Noncentral Distribution of Wilks' Lambda: MANOVA'''
        return ctx_wilks_lambda_glm(self, a, b)


# 4.11.18 Noncentral Distribution of  Wilks' Lambda: Canonical Correlation

    def dist_wilks_lambda_corr(self, a, b):
        '''Noncentral Distribution of  Wilks' Lambda: Canonical Correlation'''
        return ctx_wilks_lambda_corr(self, a, b)





# %% 4.12 Miscellaneous continuous distributions


# 4.12.1 Boost: Kolmogorov-Smirnov distribution (limiting form)

    def dist_kolmogorov_smirnov():
        '''Bernoulli distribution'''
        return dist_kolmogorov_smirnov(self, p)


# 4.12.2 Boost: Landau Distribution

    def dist_landau():
        '''Landau Distribution'''
        return dist_landau(self, p)


# 4.12.3 Boost: Holtsmark distribution

    def dist_holtsmark():
        '''Landau Distribution'''
        return dist_holtsmark(self, p)


# 4.12.4 Boost: Map-Airy distribution

    def dist_mapairy():
        '''Landau Distribution'''
        return dist_mapairy(self, p)


# 4.12.5 Boost: Saspoint5 distribution

    def dist_saspoint5():
        '''Landau Distribution'''
        return dist_saspoint5(self, p)





# %% 4.13 Elementary discrete (lattice) distributions


# 4.13.1 Bernoulli distribution

    def dist_bernoulli(self, p):
        '''Bernoulli distribution'''
        return ctx_geometric(self, p)


# 4.13.2 Geometric distribution

    def dist_geometric(self, p):
        '''Geometric distribution'''
        return ctx_geometric(self, p)


# 4.13.3 Poisson distribution

    def dist_poisson(self, mu):
        '''Poisson distribution'''
        return ctx_poisson(self, mu)


# 4.13.4 Binomial distribution

    def dist_binomial(self, n, p):
        '''Binomial distribution'''
        return ctx_binomial(self, n, p)


# 4.13.5 Negative binomial distribution

    def dist_negative_binomial(self, r, p):
        '''Negative binomial distribution'''
        return ctx_negative_binomial(self, r, p)


# 4.13.6 Classical hypergeometric distribution

    def dist_hypergeometric(self, n, K, N):
        '''Classical hypergeometric distribution'''
        return ctx_hypergeometric(self, n, K, N)





# %% 4.14 Discrete (lattice) distributions related to (stratified) rank tests


# 4.14.1 Wilcoxon signed rank T distribution, continuous data

    def dist_wilcoxon(self, a, b):
        '''Wilcoxon signed rank T distribution, continuous data'''
        return ctx_wilcoxon(self, a, b)


# 4.14.2 Noncentral Wilcoxon signed rank T distribution, Bennett alternatives

    def dist_bennett(self, a, b):
        '''Noncentral Wilcoxon signed rank T distribution,
        Bennett alternatives'''
        return ctx_bennett(self, a, b)


# 4.14.3 Mann-Whitney U distribution, continuous data

    def dist_mann_whitney_u(self, a, b):
        '''Mann-Whitney U distribution, continuous data'''
        return ctx_mann_whitney_u(self, a, b)


# 4.14.4 Noncentral Mann-Whitney U distribution, Lehmann alternatives

    def dist_mann_whitney_u_lehmann(self, a, b):
        '''Noncentral Mann-Whitney U distribution, Lehmann alternatives'''
        return ctx_mann_whitney_u_lehmann(self, a, b)


# 4.14.5 Noncentral Mann-Whitney U distribution, Milton alternatives

    def dist_mann_whitney_u_milton(self, a, b):
        '''Noncentral Mann-Whitney U distribution, Milton alternatives'''
        return ctx_mann_whitney_u_milton(self, a, b)


# 4.14.6 Kendall’s tau distribution, continuous data

    def dist_kendall_tau(self, a, b):
        '''Kendall’s tau distribution, continuous data'''
        return ctx_kendall_tau(self, a, b)


# 4.14.7 Jonckheere-Terpsta S distribution, continuous data

    def dist_jterpsta_s(self, a, b):
        '''Jonckheere-Terpsta S distribution, continuous data'''
        return ctx_jterpsta_s(self, a, b)


# 4.14.8 Generalized Page L distribution, continuous data

    def dist_page_l(self, a, b):
        '''Generalized Page L distribution, continuous data'''
        return ctx_page_l(self, a, b)


# 4.14.9 Noncentral generalized Page L distribution, Milton alternatives

    def dist_page_l_nc_milton(self, a, b):
        '''Noncentral generalized Page L distribution, Milton alternatives'''
        return ctx_page_l_nc_milton(self, a, b)


# %% 4.15 Discrete (non-lattice) distributions related to rank tests

# 4.15.1 Cochran-Friedman-Quade distribution

    def dist_friedman(self, a, b):
        '''Cochran-Friedman-Quade distribution'''
        return ctx_friedman(self, a, b)


# 4.15.2 Kruskal_Wallis distribution

    def dist_kruskal_wallis(self, a, b):
        '''Kruskal_Wallis distribution'''
        return ctx_kruskal_wallis(self, a, b)


















# %% 8 Elliptic functions and integrals


# %%%  8.1 Carlson symmetric elliptic integrals

# 8.1.1 Carlson symmetric elliptic integral of the first kind, 𝑅𝐹 (𝑥, 𝑦, 𝑧)

    def elliptic_rf(self, x, y, z):
        '''Carlson symmetric elliptic integral of the first kind,
        𝑅𝐹 (𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        res = acb.elliptic_rf(x, y, z)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.1.2 Carlson completely symmetric elliptic integral of the second kind,
    # 𝑅𝐺(𝑥, 𝑦, 𝑧)

    def elliptic_rg(self, x, y, z):
        '''Carlson completely symmetric elliptic integral of the second kind,
        𝑅𝐺(𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        res = acb.elliptic_rg(x, y, z)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.1.3 Carlson symmetric elliptic integral of the third kind, 𝑅𝐽 (𝑥, 𝑦, 𝑧, 𝑝)

    def elliptic_rj(self, x, y, z, p):
        '''Carlson symmetric elliptic integral of the third kind,
        𝑅𝐽 (𝑥, 𝑦, 𝑧, 𝑝)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        p = self.t(p)
        res = acb.elliptic_rj(x, y, z, p)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res



# 8.1.4 Carlson symmetric elliptic integral of the second kind, 𝑅𝐷(𝑥, 𝑦, 𝑧)

    def elliptic_rd(self, x, y, z):
        '''Carlson symmetric elliptic integral of the second kind,
        𝑅𝐷(𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        res = acb.elliptic_rd(x, y, z)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.1.5 Carlson degenerate symmetric elliptic integral of the first kind,
    # 𝑅𝐶(𝑥, 𝑦)

    def elliptic_rc(self, x, y):
        '''Carlson degenerate symmetric elliptic integral of the first kind,
        𝑅𝐶(𝑥, 𝑦)'''
        x = self.t(x)
        y = self.t(y)
        res = acb.elliptic_rc(x, y)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res






# %%%  8.2 Legendre elliptic integrals (elliptic parameter 𝑚)


# 8.2.1 Legendre complete elliptic integral of the first kind, 𝐾(m)

    def m_elliptic_k(self, m):
        '''Legendre complete elliptic integral of the first kind, 𝐾(m)'''
        m = self.t(m)
        res = acb(m).elliptic_k()
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.2.2 Legendre complete elliptic integral of the second kind, 𝐸(m)

    def m_elliptic_e(self, m):
        '''Legendre complete elliptic integral of the second kind, 𝐸(m)'''
        m = self.t(m)
        res = acb(m).elliptic_e()
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.2.3 Legendre complete elliptic integral of the third kind, Π(𝑛, m)

    def m_elliptic_pi(self, n, m):
        '''Legendre complete elliptic integral of the third kind, Π(𝑛, m)'''
        n = self.t(n)
        m = self.t(m)
        res = acb.elliptic_pi(n, m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.2.4 Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, m)

    def m_elliptic_f(self, phi, m):
        '''Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, m)'''
        phi = self.t(phi)
        m = self.t(m)
        res = acb.elliptic_f(phi, m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.2.5 Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, m)

    def m_elliptic_e_inc(self, phi, m):
        '''Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, m)'''
        phi = self.t(phi)
        m = self.t(m)
        res = acb.elliptic_e_inc(phi, m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.2.6 Legendre incomplete elliptic integral of the third kind, Π(𝑛, 𝜑, m)

    def m_elliptic_pi_inc(self, n, phi, m):
        '''Legendre incomplete elliptic integral of the third kind,
         Π(𝑛, 𝜑, m)'''
        n = self.t(n)
        phi = self.t(phi)
        m = self.t(m)
        res = acb.elliptic_pi_inc(n, phi, m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res




# %%%  8.3 Legendre elliptic integrals (elliptic parameter 𝑘)


# 8.3.1 Legendre complete elliptic integral of the first kind, 𝐾(𝑘)

    def elliptic_k(self, k):
        '''Legendre complete elliptic integral of the first kind, 𝐾(𝑘)'''
        m = self.t(k); m = m*m
        res = self.m_elliptic_k(m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.3.2 Legendre complete elliptic integral of the second kind, 𝐸(𝑘)

    def elliptic_e(self, k):
        '''Legendre complete elliptic integral of the second kind, 𝐸(𝑘)'''
        m = self.t(k); m = m*m
        res = self.m_elliptic_e(m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res

# 8.3.3 Legendre complete elliptic integral of the third kind, Π(𝑛, 𝑘)

    def elliptic_pi(self, n, k):
        '''Legendre complete elliptic integral of the third kind, Π(𝑛, 𝑘)'''
        n = self.t(n)
        m = self.t(k); m = m*m
        res = self.m_elliptic_pi(n, m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.3.4 Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, 𝑘)

    def elliptic_f(self, phi, k):
        '''Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, 𝑘)'''
        phi = self.t(phi)
        m = self.t(k); m = m*m
        res = self.m_elliptic_f(phi, m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.3.5 Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, 𝑘)

    def elliptic_e_inc(self, phi, k):
        '''Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, 𝑘)'''
        phi = self.t(phi)
        m = self.t(k); m = m*m
        res = self.m_elliptic_e_inc(phi, m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.3.6 Legendre incomplete elliptic integral of the third kind, Π(𝑛, 𝜑, 𝑘)

    def elliptic_pi_inc(self, n, phi, k):
        '''Legendre incomplete elliptic integral of the third kind,
         Π(𝑛, 𝜑, 𝑘)'''
        n = self.t(n)
        phi = self.t(phi)
        m = self.t(k); m = m*m
        res = self.m_elliptic_pi_inc(n, phi, m)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.3.7 Jacobi Zeta function, 𝑍(𝜑, 𝑘)

    def jacobi_zeta(self, phi, k):
        '''Jacobi Zeta function, 𝑍(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k);
        res = self.elliptic_e_inc(phi, k)
        - (self.elliptic_e(k)*self.elliptic_f(phi, k)) / self.elliptic_k(k)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.3.8 Heuman’s Lambda function, Λ(𝜑, 𝑘)

    def heuman_lambda(self, phi, k):
        '''Heuman’s Lambda function, Λ(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k); k1 = self.sqrt(1-k*k)
        res = self.elliptic_f(phi, k1)/self.elliptic_k(k1)
        res = res + 2*self.elliptic_k(k) * self.jacobi_zeta(phi, k1)/self.pi
        if self.imag(res) == self.t(0): res = self.real(res)
        return res








# %%%  8.4 Jacobi elliptic functions


    def jacobi_elliptic_sncndn(self, u, k):
        u, k = acb(u), acb(k)
        m = k*k
        K = acb.elliptic_k(m)
        Kp = acb.elliptic_k(1 - m)
        tau = acb(0, 1) * Kp / K
        z = u / (2 * K)
        _, t2_0, t3_0, t4_0 = acb(0).modular_theta(tau)
        t1, t2, t3, t4 = z.modular_theta(tau)
        sn = (t3_0 / t2_0) * (t1 / t4)
        cn = (t4_0 / t2_0) * (t2 / t4)
        dn = (t4_0 / t3_0) * (t3 / t4)
        return sn, cn, dn

# 8.4.1 Jacobi elliptic function sn


    def jacobi_sn(self, u, k):
        '''Jacobi elliptic function sn'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = sn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.2 Jacobi elliptic function cn

    def jacobi_cn(self, u, k):
        '''Jacobi elliptic function cn'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = cn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.3 Jacobi elliptic function dn

    def jacobi_dn(self, u, k):
        '''Jacobi elliptic function dn'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = dn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.4 Jacobi elliptic function ns

    def jacobi_ns(self, u, k):
        '''Jacobi elliptic function ns'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = 1 / sn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.5 Jacobi elliptic function nc

    def jacobi_nc(self, u, k):
        '''Jacobi elliptic function nc'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = 1 / cn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.6 Jacobi elliptic function nd

    def jacobi_nd(self, u, k):
        '''Jacobi elliptic function nd'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = 1 / dn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.7 Jacobi elliptic function sc

    def jacobi_sc(self, u, k):
        '''Jacobi elliptic function sc'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = sn / cn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.8 Jacobi elliptic function sd

    def jacobi_sd(self, u, k):
        '''Jacobi elliptic function sd'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = sn / dn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.9 Jacobi elliptic function dc

    def jacobi_dc(self, u, k):
        '''Jacobi elliptic function dc'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = dn / cn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.10 Jacobi elliptic function ds

    def jacobi_ds(self, u, k):
        '''Jacobi elliptic function ds'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = dn / sn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.11 Jacobi elliptic function cs

    def jacobi_cs(self, u, k):
        '''Jacobi elliptic function cs'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = cn / sn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res


# 8.4.12 Jacobi elliptic function cd

    def jacobi_cd(self, u, k):
        '''Jacobi elliptic function cd'''
        u = self.t(u)
        k = self.t(k)
        sn, cn, dn = self.jacobi_elliptic_sncndn(u,k)
        res = cn / dn
        if (self.imag(u) == 0) and (self.imag(k) == 0):
            res = self.real(res)
        return res






# %%%  8.5 Jacobi theta functions


    def jtheta(self, n, z, q):
        n = int(n)
        z = self.t(z)
        q = self.t(q)
        p = self.pi
        tau = self.ln(q) / (p * self.t(1j))
        z = z / p
        res = acb(z).modular_theta(tau)[n-1]
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 8.5.1 Jacobi theta1 function

    def jacobi_theta1(self, z, q):
        '''Jacobi theta1 function'''
        return self.jtheta(1, z, q)


# 8.5.2 Jacobi theta2 function

    def jacobi_theta2(self, z, q):
        '''Jacobi theta2 function'''
        return self.jtheta(2, z, q)


# 8.5.3 Jacobi theta3 function

    def jacobi_theta3(self, z, q):
        '''Jacobi theta3 function'''
        return self.jtheta(3, z, q)


# 8.5.4 Jacobi theta4 function

    def jacobi_theta4(self, z, q):
        '''Jacobi theta4 function'''
        return self.jtheta(4, z, q)



# %%%  8.6 Conversions of parameters of elliptic functions

    def taufrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if tau is not None:
            return self.t(tau)
        if m is not None:
            m = self.t(m)
            return self.t(1j)*self.elliptic_k(1-m)/self.elliptic_k(m)
        if k is not None:
            k = self.t(k)
            return self.t(1j)*self.elliptic_k(1-k**2)/self.elliptic_k(k**2)
        if q is not None:
            return self.ln(q) / (self.pi*self.t(1j))
        if qbar is not None:
            qbar = self.t(qbar)
            return self.ln(qbar) / (2*self.pi*self.t(1j))

    def nome(self, m):
        m = self.t(m)
        if not m:
            return m
        if m == self.t(1):
            return m
        if self.isnan(m):
            return m
        if self.isinf(m):
            if m == self.ninf:
                return self.t(-1)
            else:
                return self(-1)
        a = self.elliptic_k(self.one-m)
        b = self.elliptic_k(m)
        v = self.exp(-self.pi*a/b)
#        if not iv._im(m) and iv._re(m) < 1:
#            if iv._is_real_type(m):
        if not self.imag(m) and self.real(m) < 1:
            if self.is_real(m):
                return v.real
            else:
                return v.real + 0j
        elif m == 2:
            #v = iv.mpc(0, v.imag)
            v = self.t(0, v.imag)
        return v

    def qfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if q is not None:
            return self.t(q)
        if m is not None:
            return self.nome(m)
        if k is not None:
            return self.nome(self.t(k)**2)
        if tau is not None:
            return self.expjpi(tau)
        if qbar is not None:
            return self.sqrt(qbar)

    def qbarfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if qbar is not None:
            return self.t(qbar)
        if q is not None:
            return self.t(q) ** 2
        if m is not None:
            return self.nome(m) ** 2
        if k is not None:
            return self.nome(self.t(k)**2) ** 2
        if tau is not None:
            return self.expjpi(2*tau)

    def mfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if m is not None:
            return m
        if k is not None:
            return k**2
        if tau is not None:
            q = self.expjpi(tau)
        if qbar is not None:
            q = self.sqrt(qbar)
        if q == 1:
            return self.t(q)
        if q == -1:
            return q*self.inf
        v = (self.jtheta(2, 0, q)/self.jtheta(3, 0, q))**4
        #if iv._is_real_type(q) and q < 0:
        if self.isreal(q) and q < 0:
            v = v.real
        return v

    def kfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if k is not None:
            return self.t(k)
        if m is not None:
            return self.sqrt(m)
        if tau is not None:
            q = self.expjpi(tau)
        if qbar is not None:
            q = self.sqrt(qbar)
        if q == 1:
            return q
        if q == -1:
            return self.t(0, 'inf')
        return (self.jtheta(2, 0, q)/self.jtheta(3, 0, q))**2



    def elliptic_roots(self, tau):
        return acb(tau).elliptic_roots()


    def elliptic_invariants(self, tau):
        return acb(tau).elliptic_invariants()







# %%%  8.7 Weierstrass elliptic functions


# 8.7.1 Weierstrass function ℘(𝑧, 𝜏 )

    def weierstrass_p_t(self, z, tau):
        '''Weierstrass function ℘(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        return z.elliptic_p(tau)


# 8.7.2 Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )

    def weierstrass_pprime_t(self, z, tau):
        '''Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )'''
        from flint import acb, acb_series
        z = self.t(z)
        tau = self.t(tau)
        z_series = acb_series([acb(z), acb(1)], prec=self.prec)
        p_series = z_series.elliptic_p(acb(tau))
        res = p_series[1]
        return res



# 8.7.3 Inverse Weierstrass function ℘−1 (𝑧, 𝜏 )

    def weierstrass_pinv_t(self, z, tau):
        '''Inverse Weierstrass function ℘−1 (𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        return z.elliptic_inv_p(tau)



# 8.7.4 Weierstrass Zeta

    def weierstrass_zeta_t(self, z, tau):
        '''Weierstrass Zeta'''
        z = self.t(z)
        tau = self.t(tau)
        return z.elliptic_zeta(tau)


# 8.7.5 Weierstrass Sigma

    def weierstrass_sigma_t(self, z, tau):
        '''Weierstrass Sigma'''
        z = self.t(z)
        tau = self.t(tau)
        return z.elliptic_sigma(tau)





# %%%  8.8 Modular forms


# 8.8.1 Dedekind eta function

    def dedekind_eta(self, tau):
        '''Dedekind eta function'''
        tau = self.t(tau)
        return acb(tau).modular_eta()


# 8.8.2 Elliptic modular Lambda

    def modular_lambda(self, tau):
        '''Elliptic modular Lambda'''
        tau = self.t(tau)
        return acb(tau).modular_lambda()


# 8.8.3 Elliptic modular Delta

    def modular_delta(self, tau):
        '''Elliptic modular Delta'''
        tau = self.t(tau)
        return acb(tau).modular_delta()


# 8.8.4 Klein j-invariant

    def klein_j(self, tau):
        '''Klein j-invariant'''
        tau = self.t(tau)
        return acb(tau).modular_j()   # /1728







# %% 09 Lerch’s transcendent and related functions

# %%%  9.1 Overview LERCH’S TRANSCENDENT, POLYGAMMA


# 9.1.1 Lerch’s transcendent

    def lerch_phi(self, z, s, a):
        '''Lerch’s transcendent'''
        z = self.t(z)
        s = self.t(s)
        a = self.t(a)
        res = acb(z).lerch_phi(s, a)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# 9.1.2 Lerch’s zeta

    def lerch_zeta(self, lambda1, alpha, s):
        '''Lerch’s zeta'''
        lambda1 = self.t(lambda1)
        alpha = self.t(alpha)
        s = self.t(s)
        res = self.lerch_phi(self.exp( 2*self.pi* self.j  * lambda1), s, alpha)
        if self.imag(res) == self.t(0): res = self.real(res)
        return res


# %%%  9.2 Polygamma functions


# 9.2.1 Polygamma function 𝜓𝑚(𝑥)

    def polygamma(self, m, z):
        '''Polygamma function 𝜓𝑚(𝑥)'''
        m = self.t(m)
        z = self.t(z)
        res = acb(z).polygamma(m)
        if self.imag(z) == self.t(0): res = self.real(res)
        return res


# 9.2.2 TriGamma function 𝜓′(𝑥)

    def trigamma(self, z):
        '''TriGamma function 𝜓′(𝑥)'''
        z = self.t(z)
        res = self.polygamma(1, z)
        if self.imag(z) == self.t(0): res = self.real(res)
        return res


# 9.2.3 DiGamma function 𝜓(𝑥)

    def digamma(self, z):
        '''DiGamma function 𝜓(𝑥)'''
        res = self.polygamma(0, z)
        if self.imag(z) == self.t(0): res = self.real(res)
        return res


# 9.2.4 Harmonic numbers

    def harmonic(self, z):
        '''Harmonic numbers'''
        z = self.t(z)
        res = self.digamma(z+1)+self.egamma
        if self.imag(z) == self.t(0): res = self.real(res)
        return res


# %%%  9.3 Polylogarithms and related functions


# 9.3.1 Polylogarithm, Li𝑠(𝑧)

    def polylog(self, s, z):
        '''Polylogarithm, Li𝑠(𝑧)'''
        s = self.t(s)
        z = self.t(z)
        return acb(z).polylog(s)


# 9.3.2 Trilogarithm Function, Li3(𝑧)

    def trilog(self, z):
        '''Trilogarithm Function, Li3(𝑧)'''
        z = self.t(z)
        res = self.polylog(3, z)
        if self.imag(z) == self.t(0): res = self.real(res)
        return res


# 9.3.3 Dilogarithm Function, Li2(𝑧)

    def dilog(self, z):
        '''Dilogarithm Function, Li2(𝑧)'''
        z = self.t(z)
        res = self.polylog(2, z)
        if self.imag(z) == self.t(0): res = self.real(res)
        return res


# 9.3.4 Generalized Clausen sine function
    def clausen_sin(self, s, z):
        '''Generalized Clausen sine function'''
        s = self.t(s)
        z = self.t(z)
        res = self.polylog(s, self.exp(self.j*z))
        res = res - self.polylog(s, self.exp(-self.j*z))
        res = res / (2*self.j)
        if z.imag == self.t(0):
            res = res.real
        return res


# 9.3.5 Generalized Clausen cosine function

    def clausen_cos(self, s, z):
        '''Generalized Clausen cosine function'''
        s = self.t(s)
        z = self.t(z)
        res = self.polylog(s, self.exp(self.j*z))
        res = res + self.polylog(s, self.exp(-self.j*z))
        res = res / (2)
        if z.imag == self.t(0):
            res = res.real
        return res


# 9.3.6 Classical Clausen function

    def clausen2(self, z):
        '''Classical Clausen function'''
        z = self.t(z)
        return self.clausen_sin(2, z)



# 9.3.7 Bose-Einstein integrals of real order

    def bose_einstein(self, s, z, real4real=True):
        '''Bose-Einstein integrals of real order'''
        s = self.t(s)
        z = self.t(z)
        res = self.polylog(s+1, self.exp(z))
        if z.imag == self.t(0) and real4real:
            res = res.real
        return res


# 9.3.8 Fermi-Dirac integrals

    def fermi_dirac(self, s, z, real4real=True):
        '''Fermi-Dirac integrals'''
        s = self.t(s)
        z = self.t(z)
        res = -self.polylog(s+1, -self.exp(z))
        if z.imag == self.t(0) and real4real:
            res = res.real
        return res


# 9.3.9 Legendre’s chi function

    def legendre_chi(self, s, z, real4real=True):
        '''Legendre’s chi function'''
        s = self.t(s)
        z = self.t(z)
        res = 0.5 * (self.polylog(s, z) - self.polylog(s, -z))
        if self.isreal(z) and real4real:
            res = res.real
        return res


# 9.3.10 Inverse tangent integral

    def inverse_tan_integral(self, s, z, real4real=True):
        '''Inverse tangent integral'''
        s = self.t(s)
        z = self.t(z)
        res = (self.polylog(s, self.j*z) - self.polylog(s, -self.j*z))
        res = res / (2 * self.j)
        if self.isreal(z) and real4real:
            res = res.real
        return res



# %%%  9.4 Hurwitz zeta function and related functions


# 9.4.1 Hurwitz zeta function

    def hurwitz_zeta(self, s, a, derivative=0):
        '''Hurwitz zeta function'''
        s = self.t(s)
        a = self.t(a)
        return acb(s).zeta(a)


# 9.4.2 Generalized harmonic number function

    def harmonic2(self, z, r):
        '''Generalized harmonic number function'''
        z = self.t(z)
        r = self.t(r)
        if r == self.t(1):
            return self.harmonic(z)
        else:
            return self.zeta(r) - self.hurwitz_zeta(r, z + 1)


# 9.4.3 Bernoulli numbers

    def bernoulli(self, n):
        '''Bernoulli numbers'''
        n = int(n)
        return arb.bernoulli(n)



# 9.4.4 Bernoulli polynomials

    def bernpoly(self, n, z):
        '''Bernoulli polynomials'''
        n = int(n)
        z = self.t(z)
        if isinstance(z, arb): return arb(z).bernoulli_poly(n)
        return acb(z).bernoulli_poly(n)


# 9.4.5 Euler numbers

    def eulernum(self, n):
        '''Euler numbers'''
        n = int(n)
        return 2**n * self.eulerpoly(n, 0.5)


# 9.4.6 Euler polynomials

    def eulerpoly(self, n, z):
        '''Euler polynomials'''
        n = int(n)
        z = self.t(z)
        n = n+1
        res = 2*(self.bernpoly(n, z) - (2**n)*self.bernpoly(n, z/2))/n
        return res


# 9.4.7 Barnes G-function

    def barnes_g(self, z):
        '''Barnes G-function'''
        z = self.t(z)
        res = acb(z).barnes_g()
        #print("res:", res)
        if self.isreal(z):
            res = res.real
        return res



# 9.4.8 Logarithm of Barnes G function

    def logbarnes_g(self, z):
        '''Logarithm of Barnes G function'''
        z = self.t(z)
        return acb(z).log_barnes_g()


# 9.4.9 Hyperfactorial


    def hyperfactorial(self, z):
        '''Hyperfactorial'''
        z = self.t(z)
        return (self.exp(z * self.lgamma(z + 1))) / self.barnes_g(z + 1)


# 9.4.10 Superfactorial

    def superfactorial(self, z):
        '''Superfactorial'''
        z = self.t(z)
        return self.barnes_g(z+2)



# %%%  9.5 Dirichlet L series, Riemann zeta function and related functions



# 9.5.1 Riemann zeta function

    def zeta(self, s):
        '''Riemann zeta function'''
        s = self.t(s)
        res = acb(s).zeta()
        if self.isreal(s):
            res = res.real
        return res


# 9.5.2 Riemann 𝜁(𝑠) − 1

    def zetam1(self, s):
        '''Riemann 𝜁(𝑠) − 1'''
        s = self.t(s)
        res = self.hurwitz_zeta(s, 2)
        if self.isreal(s):
            res = res.real
        return res


# 9.5.3 Riemann-Siegel theta function

    def hardy_theta(self, t):
        '''Riemann-Siegel theta function'''
        t = self.t(t)
        res = (self.lgamma((1+2*self.onej*t)/4) - self.lgamma((1-2*self.onej*t)/4)) / (2*self.onej)
        res = res - 0.5 * t * self.log(self.pi)
        if self.isreal(t):
            res = res.real
        return res


# 9.5.4 Riemann-Siegel Z function

    def hardy_z(self, t):
        '''Riemann-Siegel Z function'''
        t = self.t(t)
        res = self.exp(self.onej*self.hardy_theta(t)) * self.zeta(0.5+self.onej*t)
        if self.isreal(t):
            res = res.real
        return res


# 9.5.5 Riemann (Landau) function 𝜉(𝑠)

    def riemann_xi(self, s):
        '''Riemann (Landau) function 𝜉(𝑠)'''
        s = self.t(s)
        res = 0.5 * s * (s-1) * self.pi ** (-s/2) * self.gamma(s/2) * self.zeta(s)
        if self.isreal(s):
            res = res.real
        return res


# 9.5.6 Dirichlet eta function

    def dirichlet_eta(self, s):
        '''Dirichlet eta function'''
        s = self.t(s)
        res = acb(s).dirichlet_eta()
        if self.isreal(s):
            res = res.real
        return res


# 9.5.7 Dirichlet 𝜂(𝑠) − 1: etam1(s)

    def dirichlet_etam1(self, s):
        '''Dirichlet 𝜂(𝑠) − 1: etam1(s)'''
        s = self.t(s)
        res = self.dirichlet_eta(s) - 1
        if self.isreal(s):
            res = res.real
        return res


# 9.5.8 Dirichlet Beta function

    def dirichlet_beta(self, s):
        '''Dirichlet Beta function'''
        s = self.t(s)
        res = self.power(4, -s) * (self.hurwitz_zeta(s, 0.25) - self.hurwitz_zeta(s, 0.75))
        if self.isreal(s):
            res = res.real
        return res


# 9.5.9 Dirichlet Lambda function

    def dirichlet_lambda(self, s):
        '''Dirichlet Lambda function'''
        s = self.t(s)
        # return (1 - self.power(2, -s)) * self.zeta(s)
        return -self.exp2m1(-s) * self.zeta(s)


# 9.5.10 The nth nontrivial zero of Riemann's zeta on the critical line

    def zeta_zero(self, n):
        '''The nth nontrivial zero of Riemann's zeta on the critical line'''
        n = int(n)
        return acb.zeta_zero(n)













# %% 10 Hypergeometric Function 0_F_1 and related functions

# %%%  10.1 Overview

# 10.1.1 Confluent Hypergeometric Limit Function 0𝐹1

    def hyperg_0f1(self, b, x):
        b = self.t(b)
        x = self.t(x)
        res = acb(x).hypgeom_0f1(b)
        if self.isreal(x):
            res = res.real
        return res


# 10.1.2 Regularized Confluent Hypergeometric Limit Function 0𝐹1r

    def hyperg_0f1r(self, b, x):
        b = self.t(b)
        x = self.t(x)
        res = acb(x).hypgeom_0f1(b, True)
        if self.isreal(x):
            res = res.real
        return res



# %%%  10.2 Bessel functions and modified Bessel functions of real or complex order

# 10.2.1 Bessel function of the 1st kind 𝐽𝜈(𝑥)

    def bessel_jv(self, nu, x, scaled = False):
        '''Bessel function of the 1st kind 𝐽𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        res = acb(x).bessel_j(nu)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.2.2 Bessel function of the 2nd kind 𝑌𝜈(𝑥)

    def bessel_yv(self, nu, x, scaled = False):
        '''Bessel function of the 2nd kind 𝑌𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        res = acb(x).bessel_y(nu)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.2.3 First derivative of the Bessel function of the first kind: 𝐽′𝜈(𝑥)

    def bessel_jv_prime(self, nu, x, scaled = False):
        '''First derivative of the Bessel function of the 1st kind 𝐽𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return 0.5 * (self.bessel_jv(nu-1, x) - self.bessel_jv(nu+1, x))


# 10.2.4 First derivative of the Bessel function of the 2nd kind: 𝑌′𝜈(𝑥)

    def bessel_yv_prime(self, nu, x, scaled = False):
        '''First derivative of the Bessel function of the 2nd kind 𝐽𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return 0.5 * (self.bessel_yv(nu-1, x) - self.bessel_yv(nu+1, x))



# 10.2.5 Zeros 𝑥𝑖 of the Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0

    def bessel_jv_zero(self, nu, m):
        '''Zeros 𝑥𝑖 of the Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0'''
        nu = mp.convert(str(nu))
        m = int(m)
        res = mp.besseljzero(nu, m)
        return self.t(str(res))

# 10.2.6 Zeros 𝑥𝑖 of the Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0

    def bessel_yv_zero(self, nu, m):
        '''Zeros 𝑥𝑖 of the Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0'''
        nu = mp.convert(str(nu))
        m = int(m)
        res = mp.besselyzero(nu, m)
        return self.t(str(res))










# %%%  10.3 Modified Bessel functions

# 10.3.1 Modified Bessel function of the 1st kind 𝐼𝜈(𝑥)

    def bessel_iv(self, nu, x, scaled = False):
        '''Modified Bessel function of the 1st kind 𝐼𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        res = acb(x).bessel_i(nu)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.3.2 Modified Bessel function of the 2nd kind 𝐾𝜈(𝑥)

    def bessel_kv(self, nu, x, scaled = False):
        '''Modified Bessel function of the 2nd kind 𝐾𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        res = acb(x).bessel_k(nu)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.3.3 First derivative of the Modified Bessel function of the 1st kind 𝐼'𝜈(𝑥)

    def bessel_iv_prime(self, nu, x, scaled = False):
        '''First derivative of the Modified Bessel function of the 1st kind 𝐼'𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return 0.5 * (self.bessel_iv(nu-1, x) + self.bessel_iv(nu+1, x))


# 10.3.4 First derivative of the Modified Bessel function of the 2nd kind 𝐾'𝜈(𝑥)

    def bessel_kv_prime(self, nu, x, scaled = False):
        '''First derivative of the Modified Bessel function of the 2nd kind 𝐾'𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return -0.5 * (self.bessel_kv(nu-1, x) + self.bessel_kv(nu+1, x))


# 10.3.5 Marcum Q function

    def marcum_q(self, m, a, b):
        '''Marcum Q function'''
        from xlcalcnet import mpm
        m = mp.convert(str(m))
        a = mp.convert(str(a))
        b = mp.convert(str(b))
        res = mpm.marcum_q(m, a, b)
        return self.t(str(res))




# %%%  10.4 Spherical Bessel functions

# 10.4.1 Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)

    def sph_bessel_jn(self, n, x, scaled = False):
        '''Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        res = self.sqrt(0.5*self.pi) * (1/self.sqrt(x)) * self.bessel_jv(n+0.5, x)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.4.2 Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)

    def sph_bessel_yn(self, n, x, scaled = False):
        '''Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        res = self.sqrt(0.5*self.pi) * (1/self.sqrt(x)) * self.bessel_yv(n+0.5, x)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.4.3 First derivative of the spherical Bessel function of the first
    # kind, 𝑗′𝑛(𝑥)

    def sph_bessel_jn_prime(self, n, x, scaled = False):
        '''First derivative of the spherical Bessel function of the first kind, 𝑗′𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        if (abs(2*n+1) > 0.1):
            res = (n * self.sph_bessel_jn(n-1, x)-(n+1) * self.sph_bessel_jn(n+1, x))
            res = res / (2*n + 1)
        else:
            res = self.sph_bessel_jn(n-1, x)
            res = res - ((n+1) / x) * self.sph_bessel_jn(n, x)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.4.4 First derivative of the spherical Bessel function of the second
    # kind, 𝑦′𝑛(𝑥)

    def sph_bessel_yn_prime(self, n, x, scaled = False):
        '''First derivative of the spherical Bessel function of the second kind, 𝑦′𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        if (abs(2*n+1) > 0.1):
            res = (n * self.sph_bessel_yn(n-1, x)-(n+1) * self.sph_bessel_yn(n+1, x))
            res = res / (2*n + 1)
        else:
            res = self.sph_bessel_yn(n-1, x)
            res = res - ((n+1) / x) * self.sph_bessel_yn(n, x)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.4.5 Zeros 𝑥𝑖 of the spherical Bessel function of the first kind, 𝑗𝑛(𝑥𝑖) = 0

    def sph_bessel_jn_zero(self, n, m):
        '''Zeros 𝑥𝑖 of the spherical Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0'''
        n = int(n)
        m = int(m)
        res = mp.besseljzero(n+0.5, m)
        return self.t(str(res))


# 10.4.6 Zeros 𝑥𝑖 of the spherical Bessel function of the second kind, 𝑦𝑛(𝑥𝑖) = 0

    def sph_bessel_yn_zero(self, n, m):
        '''Zeros 𝑥𝑖 of the spherical Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0'''
        n = int(n)
        m = int(m)
        res = mp.besselyzero(n+0.5, m)
        return self.t(str(res))






# %%%  10.5 Spherical Bessel functions

# 10.5.1 Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)

    def sph_bessel_in(self, n, x, scaled = False):
        '''Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        res = self.sqrt(0.5*self.pi) * (1/self.sqrt(x)) * self.bessel_iv(n+0.5, x)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.5.2 Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)

    def sph_bessel_kn(self, n, x, scaled = False):
        '''Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        res = self.sqrt(0.5*self.pi) * (1/self.sqrt(x)) * self.bessel_kv(n+0.5, x)
        if self.imag(res) == 0:
            res = res.real
        return res



# 10.5.3 First derivative of the Modified Spherical Bessel function of the first kind, 𝑖𝑛'(𝑥)

    def sph_bessel_in_prime(self, n, x, scaled = False):
        '''First derivative of the Modified Spherical Bessel function of the first kind, 𝑖𝑛'(𝑥'''
        n = self.t(n)
        x = self.t(x)
        if (abs(2*n+1) > 0.1):
            res = (n * self.sph_bessel_in(n-1, x) + (n+1) * self.sph_bessel_in(n+1, x))
            res = res / (2*n + 1)
        else:
            res = self.sph_bessel_in(n-1, x)
            res = res - ((n+1) / x) * self.sph_bessel_in(n, x)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.5.4 First derivative of the Modified Spherical Bessel function of the second kind, 𝑘𝑛'(𝑥)

    def sph_bessel_kn_prime(self, n, x, scaled = False):
        '''First derivative of the Modified Spherical Bessel function of the second kind, 𝑘𝑛'(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        if (abs(2*n+1) > 0.1):
            res = -(n * self.sph_bessel_kn(n-1, x) + (n+1) * self.sph_bessel_kn(n+1, x))
            res = res / (2*n + 1)
        else:
            res = self.sph_bessel_kn(n-1, x)
            res = res - ((n+1) / x) * self.sph_bessel_kn(n, x)
        if self.imag(res) == 0:
            res = res.real
        return res



# 10.5.5  Bessel bessel polynomial besselpoly(n, x)

    def besselpoly(self, n, x):
        '''Bessel bessel polynomial besselpoly(n, x)'''

        def besselpoly_(n, x):
            res = self.exp2(n + 1) * self.pow(1 / x, n + 1) * self.hyperg_u(n + 1, 2 * n + 2, 2 / x)
            return res

        n = self.t(n)
        x = self.t(x)
        if self.iszero(x):
            h = self.t(self.sqrt(self.epsilon()));
            res1 = besselpoly_(n, h * (1 + self.onej));
            res2 = besselpoly_(n, -h * (1 + self.onej));
            if (self.sign(res1.real) == self.sign(res2.real)):
                res = (res1 + res2) / 2
            else: return self.nan;
        res = besselpoly_(n, x)
        if self.imag(res) == 0:
            res = res.real
        return res


    def besseltheta(self, n, x):
        '''Reverse Bessel bessel polynomial besseltheta(n, x)'''

        def besseltheta_(n, x):
            res = self.exp2(n + 1) * self.pow(x, 2 * n + 1) * self.hyperg_u(n + 1, 2 * n + 2, 2 * x)
            return res

        n = self.t(n)
        x = self.t(x)
        if self.iszero(x):
            h = self.t(self.sqrt(self.epsilon()));
            res1 = besseltheta_(n, h * (1 + self.onej));
            res2 = besseltheta_(n, -h * (1 + self.onej));
            if (self.sign(res1.real) == self.sign(res2.real)):
                res = (res1 + res2) / 2
            else: return self.nan;
        res = besseltheta_(n, x)
        if self.imag(res) == 0:
            res = res.real
        return res






# %%%  10.6 Hankel functions


# 10.6.1 Hankel function of the first kind 𝐻1,𝜈(𝑥)

    def hankel_h1(self, n, z, scaled = False):
        '''Hankel function of the first kind 𝐻1,𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = self.bessel_jv(n, z) + self.j * self.bessel_yv(n, z)
        return res


# 10.6.2 Hankel function of the second kind 𝐻2,𝜈(𝑥)

    def hankel_h2(self, n, z, scaled = False):
        '''Hankel function of the second kind 𝐻2,𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = self.bessel_jv(n, z) - self.j * self.bessel_yv(n, z)
        return res


# 10.6.3 Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)

    def sph_hankel_h1(self, n, z, scaled = False):
        '''Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = self.sph_bessel_jn(n, z) + self.j * self.sph_bessel_yn(n, z)
        return res


# 10.6.4 Spherical Hankel function of the second kind, ℎ2,𝑛(𝑥)

    def sph_hankel_h2(self, n, z, scaled = False):
        '''Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = self.sph_bessel_jn(n, z) - self.j * self.sph_bessel_yn(n, z)
        return res








# %%%  10.4 Airy functions


# 10.7.1 Airy function Ai

    def airy_ai(self, z, scaled = False):
        '''Airy function Ai'''
        z = self.t(z)
        res = acb(z).airy_ai()
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.7.2 Airy function Bi

    def airy_bi(self, z, scaled = False):
        '''Airy function Bi'''
        res = acb(z).airy_bi()
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.7.5 Airy Ai'(x)

    def airy_ai_prime(self, z, scaled = False):
        '''Airy Ai'(x)'''
        z = self.t(z)
        res = acb(z).airy_ai(derivative=1)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.7.6 Airy Bi'(x)

    def airy_bi_prime(self, z, scaled = False):
        '''Airy Bi'(x)'''
        z = self.t(z)
        res = acb(z).airy_bi(derivative=1)
        if self.imag(res) == 0:
            res = res.real
        return res


# 10.7.4 Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0

    def airy_ai_zero(self, k):
        '''Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0'''
        k = int(k)
        return arb.airy_ai_zero(k)


# 10.7.4 Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0

    def airy_bi_zero(self, k):
        '''Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0'''
        k = int(k)
        return arb.airy_bi_zero(k)






# %%%  10.8 Kelvin functions, TODO: scaled functions


# 10.8.1 Kelvin function ber

    def kelvin_ber(self, nu, x, scaled):
        '''Kelvin function ber'''
        nu = self.t(nu)
        x = self.t(x)
        a = 0.5 * self.sqrt(2)
        j1 = self.bessel_jv(nu, x * (-a + self.onej*a))
        j2 = self.bessel_jv(nu, x * (-a - self.onej*a))
        res = 0.5 * (j1 + j2)
        if self.isreal(x,):
            res = res.real
        return res


# 10.8.2 Kelvin function bei

    def kelvin_bei(self, nu, x, scaled):
        '''Kelvin function bei'''
        nu = self.t(nu)
        x = self.t(x)
        a = 0.5 * self.sqrt(2)
        j1 = self.bessel_jv(nu, x * (-a + self.onej*a))
        j2 = self.bessel_jv(nu, x * (-a - self.onej*a))
        #res = -0.5j * (j1 - j2)
        res = -0.5*self.onej * (j1 - j2)
        if self.isreal(x,):
            res = res.real
        return res


# 10.8.3 Kelvin function ker

    def kelvin_ker(self, nu, x, scaled):
        '''Kelvin function ker'''
        nu = self.t(nu)
        x = self.t(x)
        a = 0.5 * self.sqrt(2)
        k1 = self.exp(-self.onej*nu*self.pi/2) * self.bessel_kv(nu, x * (a + self.onej*a))
        k2 = self.exp( self.onej*nu*self.pi/2) * self.bessel_kv(nu, x * (a - self.onej*a))
        res = 0.5 * (k1 + k2)
        if self.isreal(x,):
            res = res.real
        return res


# 10.8.4 Kelvin function kei

    def kelvin_kei(self, nu, x, scaled):
        '''Kelvin function kei'''
        nu = self.t(nu)
        x = self.t(x)
        a = 0.5 * self.sqrt(2)
        k1 = self.exp(-self.onej*nu*self.pi/2) * self.bessel_kv(nu, x * (a + self.onej*a))
        k2 = self.exp( self.onej*nu*self.pi/2) * self.bessel_kv(nu, x * (a - self.onej*a))
        res = -0.5*self.onej * (k1 - k2)
        res = -0.5*self.onej * (k1 - k2)
        if self.isreal(x,):
            res = res.real
        return res




# 10.5.5 First derivative of Kelvin function ber

    def kelvin_ber_prime(self, nu, x, scaled):
        '''First derivative of Kelvin function ber'''
        nu = self.t(nu)
        x = self.t(x)
        a = 0.5 * self.sqrt(self.t(2))
        ia = self.onej * a
        a1 = -a + ia
        a2 = -a - ia
        res = 0.5 * (a1 * self.bessel_jv_prime(nu, x * a1)
            + a2 * self.bessel_jv_prime(nu, x * a2));
        if self.imag(x) == self.t(0):
            res = res.real
        return res


# 10.5.6 First derivative of Kelvin function bei

    def kelvin_bei_prime(self, nu, x, scaled):
        '''First derivative of Kelvin function bei'''
        nu = self.t(nu)
        x = self.t(x)
        a = 0.5 * self.sqrt(self.t(2))
        i = self.onej
        ia = i * a
        a1 = -a + ia
        a2 = -a - ia
        res = 0.5 * (a1 * self.bessel_jv_prime(nu, x * a1)
            - a2 * self.bessel_jv_prime(nu, x * a2)) / i
        if self.imag(x) == self.t(0):
            res = res.real
        return res


# 10.5.7 First derivative of Kelvin function ker

    def kelvin_ker_prime(self, nu, x, scaled):
        '''First derivative of Kelvin function ker'''
        nu = self.t(nu)
        x = self.t(x)
        a = 0.5 * self.sqrt(self.t(2))
        i = self.onej
        ia = i * a
        p = 0.5 * i * nu * self.pi;
        e1 = self.exp(-p);
        e2 = self.exp(p);
        a1 = a + ia
        a2 = a - ia
        res = 0.5 * (e1 * a1 * self.bessel_kv_prime(nu, x * a1)
            + e2 * a2 * self.bessel_kv_prime(nu, x * a2))
        if self.imag(x) == self.t(0):
            res = res.real
        return res


# 10.5.8 First derivative of Kelvin function kei

    def kelvin_kei_prime(self, nu, x, scaled):
        '''First derivative of Kelvin function kei'''
        nu = self.t(nu)
        x = self.t(x)
        a = 0.5 * self.sqrt(self.t(2))
        i = self.onej
        ia = i * a
        p = 0.5 * i * nu * self.pi;
        e1 = self.exp(-p);
        e2 = self.exp(p);
        a1 = a + ia
        a2 = a - ia
        res = 0.5 * (e1 * a1 * self.bessel_kv_prime(nu, x * a1)
            - e2 * a2 * self.bessel_kv_prime(nu, x * a2)) / i
        if self.imag(x) == self.t(0):
            res = res.real
        return res











# %% 11 Hypergeometric Function 1_F_1 and related functions

# %%%  11.1 Overview


# 11.1.1 Kummer’s Confluent Hypergeometric Function 1𝐹1

    def hyperg_1f1(self, a, b, x):
        '''Kummer’s Confluent Hypergeometric Function 1𝐹1'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        res = acb(x).hypgeom_1f1(a, b)
        if self.imag(res) == self.t(0):
            res = res.real
        return res


# 11.1.2 Regularized Kummer’s Confluent Hypergeometric Function 1𝐹1

    def hyperg_1f1r(self, a, b, x):
        '''Regularized Kummer’s Confluent Hypergeometric Function 1𝐹1'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        res = acb(x).hypgeom_1f1(a, b, True)
        if self.imag(res) == self.t(0):
            res = res.real
        return res


# 11.1.3 Tricomi’s Confluent Hypergeometric Function 𝑈

    def hyperg_u(self, a, b, x):
        '''Tricomi’s Confluent Hypergeometric Function 𝑈'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        res = acb(x).hypgeom_u(a, b)
        if self.imag(res) == self.t(0):
            res = res.real
        return res



# 11.1.4 Generalized Laguerre polynomials, 𝐿𝑚𝑛(𝑥)

    def laguerre_l(self, n, m, z):
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).laguerre_l(n, m)
        return acb(z).laguerre_l(n, m)


# 11.1.5 Hermite polynomials (physicist)

    def hermite_h(self, n, z):
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).hermite_h(n)
        return acb(z).hermite_h(n)


# 11.1.6 Hermite polynomials (probabilist)

    def hermite_he(self, n, z):
        n = self.t(n)
        z = self.t(z)
        res = 2**(-n/2) * self.hermite_h(n, z/self.sqrt(2))
        return res

##    def laguerre_l(self, n, z):
##        n = self.t(n)
##        z = self.t(z)
##        if isinstance(n, arb) and isinstance(z, arb):
##            return arb(z).laguerre_l(n)
##        return acb(z).laguerre_l(n)



# %%%  11.2 Incomplete gamma functions

# 11.2.1 Lower normalised incomplete gamma function

    def gamma_p(self, a, z):
        a = self.t(a)
        z = self.t(z)
        res = self.gamma_lower(a, z, 1)
        if self.imag(res) == self.t(0):
            res = res.real
        return res


# 11.2.2 Upper normalised incomplete gamma function

    def gamma_q(self, a, z):
        a = self.t(a)
        z = self.t(z)
        res = self.gamma_upper(a, z, 1)
        if self.imag(res) == self.t(0):
            res = res.real
        return res


# 11.2.3 Lower non-normalised incomplete gamma function, 𝛾(𝑎, 𝑥)

    def gamma_lower(self, a, z, regularized=0):
        a = self.t(a)
        z = self.t(z)
        res = acb(z).gamma_lower(a, regularized)
        if self.imag(res) == self.t(0):
            res = res.real
        return res


# 11.2.4 Upper non-normalised incomplete gamma function, Γ(𝑎, 𝑥)

    def gamma_upper(self, a, z, regularized=0):
        a = self.t(a)
        z = self.t(z)
        res = acb(z).gamma_upper(a, regularized)
        if self.imag(res) == self.t(0):
            res = res.real
        return res



# 11.2.5 Derivative of the incomplete gamma function

    def gamma_p_prime(self, a, z):
        '''Derivative of the incomplete gamma function'''
        a = self.t(a)
        z = self.t(z)
        res = self.exp(-z) * self.power(z, a-1) / self.gamma(a)
        if self.imag(res) == self.t(0):
            res = res.real
        return res




# 11.2.6 Inverse of the real lower normalised incomplete gamma function

    def gamma_p_inv(self, a, p):
        '''Returns the Inverse of the real lower normalised incomplete gamma
        function.'''
        from xlcalcnet import mpm
        a = mpm.t(a)
        p = mpm.t(p)
        res = mpm.gamma_p_inv( a, p)
        return self.t(str(res))


# 11.2.7 Inverse of the real upper normalised incomplete gamma function

    def gamma_q_inv(self, a, q):
        '''Returns the Inverse of the real upper normalised incomplete gamma
        function.'''
        from xlcalcnet import mpm
        a = mpm.t(a)
        q = mpm.t(q)
        res = mpm.gamma_q_inv( a, q)
        return self.t(str(res))




# %%%  11.3 Coulomb, Whittaker and parabolic cylinder functions

# 11.6.0 Normalizing Gamow constant for Coulomb wave functions

    def coulombc(self, l, eta):
        l = self.t(l)
        eta = self.t(eta)
        res1 = 0.5*(self.loggamma(1+l+1j*eta) + self.loggamma(1+l-1j*eta))
        res2 = self.loggamma(2*l+2)
        res = 2**l * self.exp(-self.pi*eta/2 + res1 - res2)
        if self.iszero(l.imag) and self.iszero(eta.imag):
            res = res.real
        return res


# 11.6.1 Coulomb wave function F

    def coulomb_f(self, l, eta, z):
        '''Coulomb wave function F'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        res = acb(z).coulomb_f(l, eta)
        if self.iszero(res):
            res = res.real
        return res


# 11.6.2 Coulomb wave function G

    def coulomb_g(self, l, eta, z):
        '''Coulomb wave function G'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        res = acb(z).coulomb_g(l, eta)
        if self.iszero(res):
            res = res.real
        return res


# 11.3.3 Coulomb wave function Hplus

    def coulomb_hplus(self, l, eta, z):
        '''Coulomb wave function Hplus'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        restuple = acb(z).coulomb(l, eta)
        res = restuple[2]
        return res


# 11.3.4 Coulomb wave function Hminus

    def coulomb_hminus(self, l, eta, z):
        '''Coulomb wave function Hminus'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        restuple = acb(z).coulomb(l, eta)
        res = restuple[3]
        return res




# 11.3.5 Whittaker function M

    def whittaker_m(self, k, m, z):
        '''Whittaker function M'''
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        if z == 0:
            if m.real > -0.5:
                return z
            elif m.real < -0.5:
                return self.inf() + z
            else:
                return self.nan() * z
        #x = self.fmul(-0.5, z, exact=True)
        x =-0.5 * z
        y = 0.5 + m
        return self.exp(x) * z**y * self.hyperg_1f1(y-k, 1+2*m, z)


# 11.3.6 Whittaker function W

    def whittaker_w(self, k, m, z):
        '''Whittaker function W'''
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        if z == 0:
            g = abs(m.real)
            if g < 0.5:
                return z
            elif g > 0.5:
                return self.inf() + z
            else:
                return self.nan() * z
        #x = self.fmul(-0.5, z, exact=True)
        x =-0.5 * z
        y = 0.5+m
        return self.exp(x) * z**y * self.hyperg_u(y-k, 1+2*m, z)



# 11.3.7 Parabolic cylinder function D

    def pcfd(self, n, z):
        '''Parabolic cylinder function D'''
        n = self.t(n)
        z = self.t(z)
        res = self.pcfu(-n-0.5, z)
        return res


# 11.3.8 Parabolic cylinder function U

    def pcfu(self, a, z):
        '''Parabolic cylinder function U'''
        a = self.t(a)
        z = self.t(z)

        dps = self.dps
        dpsplus = 40
        self.dps += dpsplus

        p = self.pi
        p = self.sqrt(p)
        U1 = p / (self.exp2(0.5*a+0.25) * self.gamma(0.75+0.5*a))
        U2 = -p / (self.exp2(0.5*a-0.25) * self.gamma(0.25+0.5*a))
        F1 = self.hyperg_1f1(-0.5*a+0.25, 0.5, -0.5*z*z)
        F2 = self.hyperg_1f1(-0.5*a+0.75, 1.5, -0.5*z*z)
        res = (U1*F1 + U2*z*F2) / self.exp(-0.25*z*z)

        self.dps = dps

        return +res


# 11.3.9 Parabolic cylinder function V

    def pcfv(self, a, z):
        a = self.t(a)
        z = self.t(z)
        p = self.pi
        res = self.gamma(a+0.5)*self.pcfu(a, -z)
        res = res - self.sin(p*a)*self.pcfu(a, z)
        res = res / p
        return res


# 11.3.10 Parabolic cylinder function W

    def pcfw(self, a, z):
        '''Parabolic cylinder function W'''
        a = self.t(a)
        z = self.t(z)

        dps = self.dps
        dpsplus = 40
        self.dps += dpsplus

        W1a = self.gamma(0.25 + 0.5*self.j*a) / self.gamma(0.75 + 0.5*self.j*a)
        W1 = self.exp2(-0.75) * self.sqrt(self.fabs(W1a))
        W2a = self.gamma(0.75 + 0.5*self.j*a) / self.gamma(0.25 + 0.5*self.j*a)
        W2 = -self.exp2(-0.25) * self.sqrt(self.fabs(W2a))
        F1 = self.exp(-0.25*self.j*z*z) * self.hyperg_1f1(0.25 - 0.5*self.j*a, 0.5, 0.5*self.j*z*z)
        F2 = self.exp(-0.25*self.j*z*z) * self.hyperg_1f1(0.75 - 0.5*self.j*a, 1.5, 0.5*self.j*z*z)
        res = W1*F1 + W2*z*F2

        self.dps = dps
        if self.iszero(a.imag) and self.iszero(z.imag):
            res = res.real

        return +res






# %%%  11.4 Error function and related functions


# 11.4.1 Error function erf

    def erf(self, z):
        '''Error function erf'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).erf()
        return acb(z).erf()


# 11.4.2 Complementary error function erfc

    def erfc(self, z):
        '''Complementary error function erfc'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).erfc()
        return acb(z).erfc()



# 11.4.3 Inverse of the real error function

    def erf_inv(self, prob):
        '''Returns the Inverse of the real error function.'''
        prob = self.t(prob)
        return arb(prob).erfinv()


# 11.4.4 Inverse of the real complementory error function

    def erfc_inv(self, prob):
        '''Returns the Inverse of the real complementory error function.'''
        prob = self.t(prob)
        return arb(prob).erfcinv()


# 11.4.5 Standard normal density function

    def ndens(self, z):
        '''Returns the Standard normal density function.'''
        z = self.t(z)
        a = self.exp(-0.5*z*z)/self.sqrt(2*self.pi)
        return a


# 11.4.6 Standard normal cumulative distribution function

    def ndis(self, x):
        '''Returns the Standard normal cumulative distribution function.'''
        x = self.t(x)
        a = 0.5 * self.erfc(-x/self.sqrt(2))
        return a


# 11.7.7 Standard normal percentage point function

    def ndisx(self, p):
        '''Returns the Standard normal percentage point function.'''
        p = self.t(p)
        return -self.sqrt(2) * self.erfc_inv(2*p)


# 11.3.8 Imaginary error function erfi

    def erfi(self, z):
        '''Imaginary error function erfi'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).erfi()
        return acb(z).erfi()



# 11.4.9 Dawson’s integral

    def dawson(self, z):
        '''Dawson’s integral'''
        z = self.t(z)
        res = 0.5 * self.sqrt(self.pi) * self.exp(-z*z)
        res = res * self.erfi(z)
        return res



# 11.4.10 Faddeeva function

    def faddeeva(self, z):
        '''Faddeeva function'''
        z = self.t(z)
        res = self.exp(-z*z) * self.erfc(-self.j * z)
        return res


# 11.4.11 Fresnel sine integral

    def fresnel_s(self, z):
        '''Fresnel sine integral'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).fresnel_s()
        return acb(z).fresnel_s()


# 11.4.12 Fresnel cosine integral

    def fresnel_c(self, z):
        '''Fresnel cosine integral'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).fresnel_c()
        return acb(z).fresnel_c()


# 11.4.13 Owen’s T function

    def owen_t(self, h, a):
        '''Returns Owen’s 𝑇 function via Verified Integration'''
        from xlcalcnet import mpm
        h = mpm.t(h)
        a = mpm.t(a)
        res = mpm.owen_t(h, a)
        return self.t(str(res))


##    def inerfc(self, n, z):
##        n = self.t(n)
##        z = self.t(z)
##        scaled = True
##        res = 1/(2**n * self.sqrt(self.pi))
##        res = res * self.hyperu(0.5*n+0.5, 0.5, z*z)
##        if not(scaled):
##            res = res * self.exp(-z*z)
##        return res


##    def voigt_u(self, x, t):
##        z = (1-1j*x)/(2*self.sqrt(t))
##        res = self.sqrt(self.pi/(4*t)) * self.faddeeva(1j * z)
##        return res.real
##
##    def voigt_v(self, x, t):
##        z = (1-1j*x)/(2*self.sqrt(t))
##        res = self.sqrt(self.pi/(4*t)) * self.faddeeva(1j * z)
##        return res.imag
##
##    def voigt_h(self, a, u):
##        res = 1/(a*self.sqrt(self.pi))
##        res = res * self.voigt_u(u/a, 1/(4*a*a))
##        return res




# %%%  11.5 Exponential integrals and related functions

# 11.5.1 Exponential integral E1

    def exp_integral_e1(self, z):
        '''Exponential integral E1'''
        z = self.t(z)
        return self.exp_integral_en(1, z)



# 11.5.2 Exponential integral Ei

    def exp_integral_ei(self, z):
        '''Exponential integral Ei'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).ei()
        return acb(z).ei()


# 11.5.3 Logarithmic integral li

    def log_integral(self, z, offset=False):
        '''Logarithmic integral li'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).li()
        return acb(z).li()


# 11.5.4 Hyperbolic sine integral shi

    def sinh_integral(self, z):
        '''Hyperbolic sine integral shi'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).shi()
        return acb(z).shi()


# 11.5.5 Hyperbolic cosine integral Chi

    def cosh_integral(self, z):
        '''Hyperbolic cosine integral Chi'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).chi()
        return acb(z).chi()


# 11.5.6 Exponential integral 𝐸𝑛

    def exp_integral_en(self, n, z):
        '''Exponential integral 𝐸𝑛'''
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).expint(n)
        return acb(z).expint(n)


# 11.5.7 Sine integral si
    def sin_integral(self, z):
        '''Sine integral si'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).si()
        return acb(z).si()


# 11.5.8 Cosine integral Ci

    def cos_integral(self, z):
        '''Cosine integral Ci'''
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).ci()
        return acb(z).ci()








# %% 12 Hypergeometric Function 2F1 and 1F2 (and related functions)

# %%%  12.1 Overview



# 12.1.1 Gauss Hypergeometric Function 2𝐹1

    def hyperg_2f1(self, a, b, c, z):
        '''Gauss Hypergeometric Function 2𝐹1'''
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        res = acb(z).hypgeom_2f1(a, b, c)
        if self.imag(res) == self.t(0):
            res = res.real
        return res


# 12.1.2 Regularized Gauss Hypergeometric Function 2𝐹1

    def hyperg_2f1r(self, a, b, c, z):
        '''Regularized Gauss Hypergeometric Function 2𝐹1'''
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        res = acb(z).hypgeom_2f1(a, b, c, True)
        if self.imag(res) == self.t(0):
            res = res.real
        return res



# %%%  12.2 Chebyshev, Gegenbauer and Jacobi polynomials



# 12.2.1 Chebyshev polynomial of the first kind, 𝑇𝑛(𝑥)

    def chebyshev_t(self, n, z):
        '''Chebyshev polynomial of the first kind, 𝑇𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).chebyshev_t(n)
        return acb(z).chebyshev_t(n)


# 12.2.2 Chebyshev polynomial of the second kind, 𝑈𝑛(𝑥)

    def chebyshev_u(self, n, z):
        '''Chebyshev polynomial of the second kind, 𝑈𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).chebyshev_u(n)
        return acb(z).chebyshev_u(n)


# 12.2.3 Chebyshev polynomial of the third kind, n
    def chebyshev_v(self, n, z):
        '''Chebyshev polynomial of the third kind, 𝑈𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = self.expjpi(n) * (2 * n + 1) * self.hyperg_2f1(-n, n + 1, self.t(1.5), (1 + z) / 2)
        if self.imag(res) == self.t(0):
            res = res.real
        return res


# 12.2.4 Chebyshev polynomial of the fourth kind, W
    def chebyshev_w(self, n, z):
        '''Chebyshev polynomial of the fourth kind, 𝑈𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = self.expjpi(n) * self.hyperg_2f1(-n, n + 1, self.t(0.5), (1 + z) / 2)
        if self.imag(res) == self.t(0):
            res = res.real
        return res




# 12.2.5 Gegenbauer polynomials, 𝐶𝛼𝑛 (𝑥)

    def gegenbauer_c(self, n, a, z):
        '''Gegenbauer polynomials, 𝐶𝛼𝑛 (𝑥)'''
        n = self.t(n)
        a = self.t(a)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(a, arb) and isinstance(z, arb):
            return arb(z).gegenbauer_c(n, a)
        return acb(z).gegenbauer_c(n, a)


# 12.2.6 Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛

    def jacobi_p(self, n, a, b, z):
        '''Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛'''
        n = self.t(n)
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(a, arb) and isinstance(z, arb)\
            and isinstance(z, arb): return arb(z).jacobi_p(n, a, b)
        return acb(z).jacobi_p(n, a, b)


# 12.2.7 Zernike radial polynomials

    def zernike_r(self, n, m, r):
        '''Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛'''
        n = int(n)
        m = int(m)
        r = self.t(r)
        if (r>=0) and (n>=m) and (m>=0) and ((n-m)%2 == 0):
            return r**m * self.jacobi_p((n - m) / 2, 0, m, 2 * r * r - 1)
        else: return 0






# %%%  12.3 Legendre polynomials and related

# 12.3.1 Legendre polynomials / functions, 𝑃𝑙(𝑥)

    def legendre_p(self, n, z):
        '''Legendre polynomials / functions, 𝑃𝑙(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self.legendre_plm(n, 0, z)


# 12.3.2 Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)

    def legendre_plm(self, l, m, z):
        '''Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)'''
        l = self.t(l)
        m = self.t(m)
        z = self.t(z)
        if isinstance(l, arb) and isinstance(m, arb) and isinstance(z, arb):
            if abs(self.real(z)) < 1: res = arb(z).legendre_p(l, m, 2)
            else: res = arb(z).legendre_p(l, m, 3)
        else:
            if abs(self.real(z)) < 1: res = acb(z).legendre_p(l, m, 2)
            else: res = acb(z).legendre_p(l, m, 3)
        return res


# 12.3.3 Legendre function of the second kind, 𝑄𝑙(𝑥)

    def legendre_q(self, n, z):
        '''Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self.legendre_qlm(n, 0, z)


# 12.3.4 Associated Legendre function of the second kind, 𝑄𝑙(𝑥)

    def legendre_qlm(self, l, m, z):
        '''Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)'''
        l = self.t(l)
        m = self.t(m)
        z = self.t(z)
        if isinstance(l, arb) and isinstance(m, arb) and isinstance(z, arb):
            if abs(self.real(z)) < 1: res = arb(z).legendre_q(l, m, 2)
            else: res = arb(z).legendre_q(l, m, 3)
        else:
            if abs(self.real(z)) < 1: res = acb(z).legendre_q(l, m, 2)
            else: res = acb(z).legendre_q(l, m, 3)
        return res



# 12.3.5 Spherical harmonics, 𝑌 𝑚𝑛 (𝜃, 𝜑)

    def spherical_y(self, l, m, theta, phi):
        '''Spherical harmonics, 𝑌 𝑚𝑛 (𝜃, 𝜑)'''
        l = int(l)
        m = int(m)
        theta = self.t(theta)
        phi = self.t(phi)
        return acb.spherical_y(l, m, theta, phi)


# 12.3.6 Toroidal harmonics, P

    def toroidal_plm(self, l, m, x):
        '''Associated Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        l = int(l)
        m = int(m)
        x = self.t(x)
        nu = l - self.t(0.5);
        if (x < 1): return self.nan;
        if (x == 1): return self.hyperg_2f1r(nu + 1, -nu, 1 - m, (1 - x) / 2)
        res = acb(x).legendre_p(self.t(l - 0.5), self.t(m), type=3)
        if acb(self.imag(res).contains(self.t(0))):
            res = res.real
        return res



# 12.3.7 Toroidal harmonics, Q

    def toroidal_qlm(self, l, m, x):
        '''Associated Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        l = self.t(l)
        m = self.t(m)
        x = self.t(x)
        res = acb(x).legendre_q(self.t(l - 0.5), self.t(m), type=3)
        if acb(self.imag(res).contains(self.t(0))):
            res = res.real
        return res






# %%%  12.4 Incomplete Beta


# 12.4.1 Non-Normalised incomplete beta function

    def beta_lower(self, a, b, z):
        '''Non-Normalised incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        if isinstance(a, arb) and isinstance(b, arb) and isinstance(z, arb):
            return arb(z).beta_lower(a, b, 0)
        return acb(z).beta_lower(a, b, 0)


# 12.4.2 Normalised incomplete beta function

    def ibeta(self, a, b, z):
        '''Normalised incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        if isinstance(a, arb) and isinstance(b, arb) and isinstance(z, arb):
            return arb(z).beta_lower(a, b, 1)
        return acb(z).beta_lower(a, b, 1)


# 12.4.3 Derivative of the incomplete beta function

    def ibeta_prime(self, a, b, x):
        '''Derivative of the incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return self.power(x, a-1) * self.power(1-x, b-1) / self.beta(a, b)


# 12.4.4 Real non-normalized upper incomplete beta function

    def beta_upper(self, a, b, z):
        '''beta_upper'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return self.beta(a, b) - self.beta_lower(a, b, z)


# 12.4.5 Real normalized complementory incomplete beta function

    def ibetac(self, a, b, x):
        '''Real normalized complementory incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return 1 - self.ibeta(a, b, x)





# 12.4.6 Inverse of the real normalised incomplete beta function

    def ibeta_inv(self, a, b, prob):
        '''Returns the Inverse of the real normalised incomplete beta
        function.'''
        from xlcalcnet import mpm
        a = mp.convert(str(a))
        b = mp.convert(str(b))
        prob = mp.convert(str(prob))
        res = mpm.ibeta_inv(a, b, prob)
        return self.t(str(res))


# 12.4.7 Inverse of the real normalised complementary incomplete beta function

    def ibetac_inv(self, a, b, prob):
        '''Returns the Inverse of the real normalised complementary incomplete
        beta function.'''
        from xlcalcnet import mpm
        a = mp.convert(str(a))
        b = mp.convert(str(b))
        prob = mp.convert(str(prob))
        res = mpm.ibetac_inv(a, b, prob)
        return self.t(str(res))





# %%%  12.5 Hypergeometric function 1𝐹2

# 12.5.1 Non-regularized hypergeometric function 1𝐹2

    def hyperg_1f2(self, a1, b1, b2, z):
        '''Non-regularized hypergeometric function 1𝐹2'''
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        res = acb(z).hypgeom([a1], [b1, b2], regularized=False)
        if self.imag(res) == self.t(0):
            res = res.real
        return res


# 12.5.2 Regularized hypergeometric function 1𝐹2

    def hyperg_1f2r(self, a1, b1, b2, z):
        '''Regularized hypergeometric function 1𝐹2'''
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        res = acb(z).hypgeom([a1], [b1, b2], regularized=True)
        if self.imag(res) == self.t(0):
            res = res.real
        return res



# %%%  12.6 Scorer functions


# 12.6.1 Scorer function Gi

    def scorer_gi(self, z):
        '''Scorer function Gi'''
        z = self.t(z)
        t = self.t(1)/self.t(3)
        res1 = self.airy_bi(z)/3
        res2 = (z*z)/(2*self.pi)
        res3 = self.hyperg_1f2(1, 4*t, 5*t, z*z*z/9)
        res = res1 - res2*res3
        return res


# 12.6.2 Scorer function Hi(x)

    def scorer_hi(self, z):
        '''Scorer function Hi'''
        z = self.t(z)
        t = self.t(1)/self.t(3)
        res1 = 2*self.airy_bi(z)/3
        res2 = (z*z)/(2*self.pi)
        res3 = self.hyperg_1f2(1, 4*t, 5*t, z*z*z/9)
        res = res1 + res2*res3
        return res


# 12.6.3 Scorer function Gi'(x)

    def scorer_gi_prime(self, x):
        # Missing
        '''Scorer function Gi\' '''
        x = self.t(x)
        x3 = x * x * x;
        x4 = x3 * x;
        res = self.airy_bi_prime(x) / 3 - 1 / (40 * self.pi) * (40 * x * self.hyperg_1f2(1, self.t(4) / 3,
            self.t(5) / 3, x3 / 9) + (3 * x4 * self.hyperg_1f2(2, self.t(7) / 3, self.t(8) / 3, x3 / 9)));
        return res


# 12.6.4 Scorer function Hi'(x)

    def scorer_hi_prime(self, x):
        # Missing
        '''Scorer function Hi\' '''
        x = self.t(x)
        res = self.airy_bi_prime(x) - self.scorer_gi_prime(x)
        return res





# %%%  12.7 Struve functions

# 12.7.1 Struve function 𝐻𝜈(𝑥)

    def struve_h(self, n, z):
        '''Struve function 𝐻𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res2 = (z/2)**(n+1)
        res3 = self.hyperg_1f2r(1, 1.5, n+1.5, -z*z/4)
        res = res2*res3
        return res



# 12.7.2 Struve function 𝐿𝜈(𝑥)

    def struve_l(self, n, z):
        '''Struve function 𝐿𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = -1j*self.expjpi(-n/2)*self.struve_h(n, self.j*z)
        if self.iszero(res.imag):
            res = res.real
        return res


# 21.7.3 Struve function K

    def struve_k(self, n, z):
        '''Struve function K'''
        n = self.t(n)
        z = self.t(z)
        res1 = self.struve_h(n, z)
        res2 = self.bessel_yv(n, z)
        return res1 - res2


# 12.7.4 Struve function M

    def struve_m(self, n, z):
        '''Struve function M'''
        n = self.t(n)
        z = self.t(z)
        return self.struve_l(n, z) - self.bessel_iv(n, z)






# %%%  12.8 Anger, Weber and Lommel functions

# 12.8.1 Anger function J

    def anger_j(self, n, z):
        '''Anger function J'''
        # if n is an integer, return besselj(n,z)
        n = self.t(n)
        z = self.t(z)
        tau = self.pi * n / 2
        res2a = (z/2)*self.sin(tau)
        res3a = self.hyperg_1f2r(1, 0.5*(3-n), 0.5*(3+n), -z*z/4)
        res2b = self.cos(tau)
        res3b = self.hyperg_1f2r(1, 0.5*(2-n), 0.5*(2+n), -z*z/4)
        res = res2a*res3a + res2b*res3b
        return res



# 12.8.2 Weber function E

    def weber_e(self, n, z):
        '''Weber function E'''
        n = self.t(n)
        z = self.t(z)
        tau = self.pi * n / 2
        res2a = self.sin(tau)
        res3a = self.hyperg_1f2r(1, 0.5*(2-n), 0.5*(2+n), -z*z/4)
        res2b = (z/2)*self.cos(tau)
        res3b = self.hyperg_1f2r(1, 0.5*(3-n), 0.5*(3+n), -z*z/4)
        res = res2a*res3a - res2b*res3b
        return res



# 12.8.3 Lommel function 𝑆1

    def lommel_s1(self, mu, nu, z):
        '''Lommel function 𝑆1'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        res2 = z**(mu+1)/((mu-nu+1)*(mu+nu+1))
        res3 = self.hyperg_1f2(1, (mu-nu+3)/2, (mu+nu+3)/2, -z*z/4)
        res = res2*res3
        return res



# 12.8.4 Lommel function 𝑆2

    def lommel_s2(self, mu, nu, z):
        '''Lommel function 𝑆2'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        res1 = self.lommel_s1(mu, nu, z)
        res2 = 2**(mu-1) * self.gamma((mu-nu+1)/2) * self.gamma((mu+nu+1)/2)
        res3 = self.sin(self.pi*(mu-nu)/2) * self.bessel_jv(nu, z)
        res4 = self.cos(self.pi*(mu-nu)/2) * self.bessel_yv(nu, z)
        res = res1+res2*(res3-res4)
        return res




