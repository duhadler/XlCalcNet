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




from xlcalcnet import mathgp
from xlcalcnet import ctx_shared
from xlcalcnet import ctx07StatDataAnalysis
from xlcalcnet.mpmath import mp

import gmpy2

from gmpy2 import  get_context as gpm_context
from xlcalcnet import ctx_gp


from xlcalcnet import ctx_mpm
mpm = ctx_mpm.mpm()


gp2 = ctx_gp.GPContext()
ctxm = ctx_shared.ctxUtil()
stat = ctx07StatDataAnalysis.inferential_statistics()


class gpm():


    # %% General functions


    def __init__(self):
        gpm_context().allow_complex = True


    def _fm1(self, fun, gpm_z1):
        z1 = mpm.t(gpm_z1)
        res = fun(z1)
        return self.t(res)

    def _fm2(self, fun, gpm_z1, gpm_z2):
        z1 = mpm.t(gpm_z1)
        z2 = mpm.t(gpm_z2)
        res = fun(z1, z2)
        return self.t(res)

    def _fm2b(self, fun, gpm_z1, gpm_z2, b):
        z1 = mpm.t(gpm_z1)
        z2 = mpm.t(gpm_z2)
        res = fun(z1, z2, b)
        return self.t(res)

    def _fm3(self, fun, gpm_z1, gpm_z2, gpm_z3):
        z1 = mpm.t(gpm_z1)
        z2 = mpm.t(gpm_z2)
        z3 = mpm.t(gpm_z3)
        res = fun(z1, z2, z3)
        return self.t(res)

    def _fm3b(self, fun, gpm_z1, gpm_z2, gpm_z3, b):
        z1 = mpm.t(gpm_z1)
        z2 = mpm.t(gpm_z2)
        z3 = mpm.t(gpm_z3)
        res = fun(z1, z2, z3, b)
        return self.t(res)

    def _fm4(self, fun, gpm_z1, gpm_z2, gpm_z3, gpm_z4):
        z1 = mpm.t(gpm_z1)
        z2 = mpm.t(gpm_z2)
        z3 = mpm.t(gpm_z3)
        z4 = mpm.t(gpm_z4)
        res = fun(z1, z2, z3, z4)
        return self.t(res)


# %% 2 Contexts and a minimal set of context functions


# %%%  2.1 Contexts in xlcalcnet: common interface


# 2.1.1 A minimal set of context functions
    def loadbinaries(self, path):
        print("loading binaries from:", path)

    @property
    def name(self):
        return "gpm"

    @property
    def fmtname(self):
        return "    gpm"

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
            return ' ' + s1
        else:
            s2 = str(z.imag)
            return " " + "(" + s1 + ", " + s2 + ")"


    @property
    def realtype(self):
        return gp2.mpf

    @property
    def complextype(self):
        return gp2.mpc

# 2.1.2 Creating a real number
    def mpf(self, x):
        return gp2.mpf(x)

# 2.1.3 Creating a complex number
    def mpc(self, x, y=None):
        if y is None: return gp2.mpc(x)
        else: return gp2.mpc(x, y)

# 2.1.4 Getting and setting the current precision (in bits)
    @property
    def prec(self):
        return gp2.prec

    @prec.setter
    def prec(self, value):
        gp2.prec = int(value)

# 2.1.5 Getting and setting the current decimal precision (in digits)
    @property
    def dps(self):
        return gp2.dps

    @dps.setter
    def dps(self, value):
        gp2.dps = int(value)

# 2.1.6 Getting and setting the current decimal precision (in digits)
    @property
    def pretty(self):
        return gp2.pretty

    @pretty.setter
    def pretty(self, value):
        gp2.pretty = bool(value)





# %%%  2.2 Arithmetic operations

# This is implemented in fp, mp, iv, dp, gp, ap

    def fma(self, x, y, z):
        return x * y + z

    def fmax(self, x, y):
        if (x >= y): return x
        else: return y

    def fmin(self, x, y):
        if (x <= y): return x
        else: return y


    def fadd(self, x, y, **kwargs):
        return gp2.fadd(x, y, **kwargs)

    def fsub(self, x, y, **kwargs):
        return gp2.fsub(x, y, **kwargs)

    def fneg(self, x, **kwargs):
        return gp2.fneg(x, **kwargs)

    def fmul(self, x, y, **kwargs):
        return gp2.fmul(x, y, **kwargs)

    def fdiv(self, x, y, **kwargs):
        return gp2.fdiv(x, y, **kwargs)

##    def fmod(self, x, y):
##        return gp2.fdiv(x, y)

    def fsum(self, terms, absolute=False, squared=False):
        return gp2.fsum(terms, absolute, squared)

    def fprod(self, factors):
        return gp2.fprod(factors)

    def fdot(self, A, B=None, conjugate=False):
        return gp2.fdot(A, B, conjugate)




# %%%  2.3 Functions related to intervals and balls

# 2.3.1 Middle value of an interval or ball
    def mid(self, z):
        z = self.t(z)
        return z

# 2.3.2 Radius of an interval or ball
    def radius(self, z):
        return self.t(0)

# 2.3.3 Left border of an interval or ball
    def left(self, z):
        z = self.t(z)
        return z

# 2.3.4 Left border of an interval or ball
    def right(self, z):
        z = self.t(z)
        return z

# 2.3.5 Absolute value of the left end of an interval
    def absmin(self, z):
        return gp2.absmin(z)

# 2.3.6 Absolute value of the right end of an interval
    def absmax(self, z):
        return gp2.absmax(z)




# %%%  2.4 Complex components

    def abs(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            if z < 0:
                return -z
            else:
                return +z
        else:
            return gmpy2.hypot(z.real, z.imag)

    def fabs(self, z):
        return self.abs(z)

    def sign(self, z):
        z = self.t(z)
        if z == 0:
            return self.t(0)
        if isinstance(z, gmpy2.mpfr):
            if z < 0:
                return self.t(-1)
            else:
                return self.t(+1)
        else:
            return z / self.fabs(z)

    def re(self, z):
        z = self.t(z)
        return z.real

    def real(self, z):
        z = self.t(z)
        return z.real

    def im(self, z):
        z = self.t(z)
        return z.imag

    def imag(self, z):
        z = self.t(z)
        return z.imag


    def arg(self, z):
        return self.phase(z)


    def phase(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            if z < 0:
                res = self.pi
                return res
            else: return self.t(0)
        else:
            return gmpy2.phase(z)

    def conj(self, z):
        z = self.t(z)
        return gp2.conj(z)

    def polar(self, z):
        return gp2.polar(z)

    def rect(self, r, phi):
        return gp2.rect(r, phi)





# %%%  2.5 Integer and fractional parts

    def floor(self, z):
        z = self.t(z)
        if hasattr(z, '__trunc__'):
            return gmpy2.floor(z)
        else:
            return gmpy2.mpc(gmpy2.floor(z.real), gmpy2.floor(z.imag))

    def ceil(self, z):
        z = self.t(z)
        if hasattr(z, '__trunc__'):
            return gmpy2.ceil(z)
        else:
            return gmpy2.mpc(gmpy2.ceil(z.real), gmpy2.ceil(z.imag))




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
        s = ereal.t(z)
        return ereal.lrint(s)

    def llrint(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        s = ereal.t(z)
        return ereal.llrint(s)


    def lround(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        s = ereal.t(z)
        return ereal.lround(s)

    def llround(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        s = ereal.t(z)
        return ereal.llround(s)



    def nint(self, z):
        return mp.nint(z)

    def frac(self, z):
        return mp.frac(z)





# %%%  2.6 Tolerances and approximate comparisons

    def chop(self, x, tol=None):
        return gp2.chop(x, tol)

    def almosteq(self, s, t, rel_eps=None, abs_eps=None):
        return gp2.almosteq(s, t, rel_eps, abs_eps)




# %%%  2.7 Properties of numbers

    def signbit(self, z):
        if (z < 0): return 1
        else: return 0



    def ismpf(self, z):
        return gp2.ismpf(z)

    def ismpc(self, z):
        return gp2.ismpc(z)


    def isinf(self, z):
        return gp2.isinf(z)




    def isposinf(self, z):
        z = self.t(z)
        return gp2.isinf(z) and z>0

    def isneginf(self, z):
        z = self.t(z)
        return gp2.isinf(z) and z<0

    def iszero(self, z):
        z = self.t(z)
        return z==0

    def isone(self, z):
        z = self.t(z)
        return z==1

    def isinteger(self, z):
        z = self.t(z)
        return gp2.isint(z)





    def isnan(self, z):
        return gp2.isnan(z)

    def isnormal(self, z):
        return gp2.isnormal(z)




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
        return gp2.isfinite(z)

    def isint(self, z):
        return gp2.isint(z)



    def copysign(self, x, y):
        x = self.t(x)
        y = self.t(y)
        return self.abs(x) * self.sign(y)


    def fdim(self, x, y):
        x = self.t(x)
        y = self.t(y)
        if (x > y): return x - y
        else: return self.zero


    def ldexp(self, x, n):
        return gp2.ldexp(x, n)

    def scalbn(self, x, n):
        return self.ldexp(x, n)

    def scalbln(self, x, n):
        return self.ldexp(x, n)



    def frexp(self, x):
        return gp2.frexp(x)


    def logb(self, z):
        z = self.t(z)
        res = self.frexp(z)
        return self.t(res[1] - 1)


    def ilogb(self, z):
        z = self.t(z)
        res = self.frexp(z)
        return int(res[1] - 1)




    def mag(self, x):
        return gp2.mag(x)

    def nint_distance(self, x):
        return gp2.nint_distance(x)


    def modf(self, x):
        x = self.t(x)
        return gmpy2.modf(x)

    def fmod(self, x, y):
        x = self.t(x)
        y = self.t(y)
        gmpy2.fmod(x, y)
        return gmpy2.fmod(x, y)

    def frac(self, x):
        x = self.t(x)
        return x - self.floor(x)

    def fractionalpart(self, x):
        x = self.t(x)
        return gmpy2.frac(x)


    def remainder(self, x, y):
        x = self.t(x)
        y = self.t(y)
        return gmpy2.remainder(x, y)

    def remquo(self, x, y):
        x = self.t(x)
        y = self.t(y)
        return gmpy2.remquo(x, y)


    def ulp(self, x):
        x = self.t(x)
        if x < 0: return self.ulp(-x)
        if self.isposinf(x): return x
        if self.iszero(x): return self.minposvalue()
        res0 = self.nextafter(x, self.inf)
        res = res0 - x
        return res

    def epsilon(self):
        return self.eps

    def maxvalue(self):
        s ='2.09857871646738769240435811688383907063809796547335262778664622571024044777576820818355304'
        s = s[:1+self.dps]
        s = s + 'E+323228496'
        return self.t(s)

    def lowestvalue(self):
        s ='-2.09857871646738769240435811688383907063809796547335262778664622571024044777576820818355304'
        s = s[:2+self.dps]
        s = s + 'E+323228496'
        return self.t(s)

    def minposvalue(self):
        s ='2.38256490488795107321616978173267452041519612555923978795502375260094538610432437489305775'
        s = s[:1+self.dps]
        s = s + 'E-323228496'
        return self.t(s)


    def nextafter(self, x, y):
        x = self.t(x)
        y = self.t(y)
        if x == y: return x
        elif x < y: return gmpy2.next_above(x)
        else: return gmpy2.next_below(x)



# %%%  2.8 Number generation


    def fraction(self, p, q):
        return gp2.fraction(p, q)

    def rand(self):
        return gp2.rand()

    def arange(self, *args):
        return gp2.arange(*args)

    def linspace(self, *args, **kwargs):
        return gp2.arange(*args, **kwargs)






# %%%  2.9 Exact mathematical constants

    @property
    def zero(self):
        return +gp2.zero

    @property
    def negzero(self):
        return -gp2.zero

    @property
    def one(self):
        return +gp2.one

    @property
    def j(self):
        return +gp2.j

    @property
    def onej(self):
        return +gp2.j

    @property
    def inf(self):
        return +gp2.inf

    @property
    def ninf(self):
        return +gp2.ninf

    @property
    def neginf(self):
        return +gp2.ninf

    @property
    def nan(self):
        return +gp2.nan




# %%%  2.10 Mathematical Constants


    @property
    def eps(self):
        return +gp2.eps()

    @property
    def ln2(self):
        return +gp2.ln2

    @property
    def ln10(self):
        return +gp2.ln10

    @property
    def pi(self):
        return +gp2.pi

    @property
    def e(self):
        return +gp2.e

    @property
    def euler(self):
        return +gp2.euler

    @property
    def egamma(self):
        return +gp2.euler

    @property
    def phi(self):
        return +gp2.phi

    @property
    def catalan(self):
        return +gp2.catalan

    @property
    def khinchin(self):
        return +gp2.khinchin

    @property
    def glaisher(self):
        return +gp2.glaisher

    @property
    def apery(self):
        return +gp2.apery

    @property
    def degree(self):
        return +gp2.degree





# %%%  2.11 Utility functions

    def t(self, x, y=None):
        return mathgp.convert(x, y)


    def convert(self, x, y=None):
        return mathgp.convert(x, y)


    def mpmathify(self, x, y=None):
        return mathgp.convert(x, y)


    def nstr(self, x, n=6, **kwargs):
        return gp2.nstr(x, n, **kwargs)

    def nprint(self, x, n=6, **kwargs):
        return gp2.nprint(x, n, **kwargs)


# dispose later


    def to_float(self, z):
        return float(z)

    def to_mpf(self, z):
        return mpm().t(z)

    def from_mpf(self, z):
        return self.t(z)



# %%%  2.12 Precision management


    def autoprec(self, f, maxprec=None, catch=(), verbose=False):
        return gp2.autoprec(f, maxprec, catch, verbose)

    def workprec(self, n, normalize_output=False):
        return gp2.workprec(n, normalize_output)

    def workdps(self, n, normalize_output=False):
        return gp2.workdps(n, normalize_output)

    def extraprec(self, n, normalize_output=False):
        return gp2.extraprec(n, normalize_output)

    def extradps(self, n, normalize_output=False):
        return gp2.extradps(n, normalize_output)



# %%%  2.13 Performance and debugging


    def memoize(self, f):
        return gp2.memoize(f)

    def maxcalls(self, f, N):
        return gp2.maxcalls(f, N)

# monitor and timing are not ctx functions


# %%%  2.14 Additonal functionality


    def plot(self, f, xlim=[- 5, 5], ylim=None, points=200, file=None, dpi=None, singularities=[], axes=None):
        res = gp2.plot(f, xlim, ylim, points, file, dpi, singularities, axes)
        return res




# %% 3 Scalar elementary functions

# %%%  3.1 Exponential and related functions

    def exp(self, z):
        z = self.t(z)
        # return gmpy2.exp(z)
        return gp2.exp(z)

    def expj(self, z):
        z = self.t(z)
        # return gmpy2.cos(z) + gmpy2.sin(z) * 1j
        return gp2.expj(z)

    def expjpi(self, z):
        z = self.t(z)
#        z = self.t(z) * gmpy2.pi()
#        return gmpy2.cos(z) + gmpy2.sin(z) * 1j
        return gp2.expjpi(z)

    def exp10(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.exp10(z)
        else:
            return gmpy2.exp(z * self.ln10)

    def exp2(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.exp2(z)
        else:
            return gmpy2.exp(z * self.ln2)

    def expm1(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.expm1(z)
        else:
            v = self.tanh(0.5 * z)
            return (2 * v)/(1 - v)
#        return gp2.expm1(z)

    def exp10m1(self, z):
        z = self.t(z)
        return self.expm1(z * self.ln10)

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
        return 1/(1 + gmpy2.exp(-z))


# %%%  3.2 Logarithms and related functions

##    def logb(self, z, b):
##        z = self.t(z)
##        b = self.t(b)
##        return gmpy2.log(z)/gmpy2.log(b)
##        #return gp2.log(z, b)

    def ln(self, z):
        z = self.t(z)
        # return gmpy2.log(z)
        return gp2.ln(z)

    def log(self, z, base=None):
        z = self.t(z)
        # return gmpy2.log(z)
        return gp2.ln(z)

    def log1p(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            if (z < -1):
                z = z + self.t(0+0j)
            else: return gmpy2.log1p(z)
        return 2*gmpy2.atanh(z/(2+z))

    def log10(self, z):
        z = self.t(z)
        return gmpy2.log10(z)

    def log2(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.log2(z)
        else:
            return gmpy2.log(z)/self.ln2

    def log1mexp(self, z):
        z = self.t(z)
        x = self.fabs(z)
        if x < self.ln2:
            return gmpy2.log(-gmpy2.expm1(-x))
        else:
            return gmpy2.log1p(-gmpy2.exp(-x))


    def log2p1(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            if (z < -1):
                z = z + self.t(0+0j)
            else: return gmpy2.log1p(z) / self.ln2
        return 2*gmpy2.atanh(z/(2+z)) / self.ln2



    def log10p1(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            if (z < -1):
                z = z + self.t(0+0j)
            else: return gmpy2.log1p(z) / self.ln10
        return 2*gmpy2.atanh(z/(2+z)) / self.ln10

##
##    def log10p1(self, z):
##        z = self.t(z)
##        return self.log1p(z)/self.ln10

    def ln1mexp(self, z):
        z = self.t(z)
        return self.ln(-self.expm1(z))

    def ln1pexp(self, z):
        z = self.t(z)
        return self.log1p(self.exp(z))

    def ln1pmx(self, z):
        z = self.t(z)
        return self.log1p(z) - z

    def logit(self, z):
        z = self.t(z)
        return gmpy2.log(z/(1-z))

    def lambertw(self, z, k=0):
        z = self.t(z)
        k = int(k)
        return self._fm2(mpm().lambertw, z, k)

    def lambert_wk(self, z, k=0):
        z = self.t(z)
        k = int(k)
        return self._fm2(mpm().lambertw, z, k)

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
        return self._fm2(mpm().agm, a, b)


# %%%  3.3 Square, roots and power functions

    def square(self, z):
        z = self.t(z)
        return gmpy2.square(z)

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
        return gmpy2.sqrt(z)

    def rsqrt(self, z):
        return 1/self.sqrt(z)

    def sqrt1pm1(self, z):
        return self.expm1(self.log1p(z)/2)

    def cuberoot(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.cbrt(z)
        else:
            return gmpy2.exp(gmpy2.log(z)/3)

    def cbrt(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.cbrt(z)
        else:
            return gmpy2.exp(gmpy2.log(z)/3)

    def nthroot(self, z, n):
        z = self.t(z)
        n = int(n)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.root(z, n)
        else:
            return gmpy2.exp(gmpy2.log(z)/n)

    def root_si(self, z, n):
        return self.nthroot(z, n)


    def unitroot(self, k, n):
        return self.exp(2j*k*self.pi/n)

    def hypot(self, a, b):
        a = self.t(a)
        b = self.t(b)
        if (isinstance(a, gmpy2.mpfr)) and (isinstance(b, gmpy2.mpfr)):
            return gmpy2.hypot(a, b)
        else:
            return gmpy2.sqrt(gmpy2.square(a) + gmpy2.square(b))

    def power(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return a**b

    def pow(self, a, b):
        return self.power(a, b)


    def pow_si(self, x, n):
        '''Returns pow(a, b) = exp(b*log(a)).'''
        return pow(x, n)


    def powm1(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.expm1(b * gmpy2.log(a))

    def pow1p(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return gmpy2.exp(b * self.log1p(a))

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
        w = gmpy2.sqrt(z*z+4)
        return (1/w) * (((z+w)/2)**n - ((z-w)/2)**n)

    def lucas(self, n):
        n = self.t(n)
        phi = self.phi
        return phi**n + (-phi)**(-n)

    def lucaspoly(self, n, z):
        n = self.t(n)
        z = self.t(z)
        w = gmpy2.sqrt(z*z+4)
        return (((z+w)/2)**n + ((z-w)/2)**n)


# %%%  3.4 Trigonometric functions

    def radians(self, x):
        return gmpy2.radians(x)

    def degrees(self, x):
        return gmpy2.degrees(x)

    def sin(self, z):
        z = self.t(z)
        return gmpy2.sin(z)

    def cos(self, z):
        z = self.t(z)
        return gmpy2.cos(z)

    def tan(self, z):
        z = self.t(z)
        return gmpy2.tan(z)

    def sec(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.sec(z)
        else:
            return 1/gmpy2.cos(z)

    def csc(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.csc(z)
        else:
            return 1/gmpy2.sin(z)

    def cot(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.cot(z)
        else:
            return 1/gmpy2.tan(z)

    def hav(self, z):
        z = self.t(z)
        v = gmpy2.sin(0.5 * z)
        return v*v

    def sinpi(self, z):
        z = self.t(z)
        return gmpy2.sin(z * self.pi)

    def cospi(self, z):
        z = self.t(z)
        return gmpy2.cos(z * self.pi)

    def tanpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return self.sinpi(z) / self.cospi(z)

    def cotpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return self.cospi(z) / self.sinpi(z)

    def cscpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return 1.0 / self.sinpi(z)

    def secpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return 1.0 / self.cospi(z)


    def sinc(self, z):
        z = self.t(z)
        if z == 0:
            return self.t(1)
        else:
            return gmpy2.sin(z)/z

    def sincpi(self, z):
        z = self.t(z)
        return self.sinc(z * self.pi)

    def cospi(self, z):
        z = self.t(z)
        return gmpy2.cos(z * self.pi)


# %%%  3.5 Hyperbolic functions

    def sinh(self, z):
        z = self.t(z)
        return gmpy2.sinh(z)

    def cosh(self, z):
        z = self.t(z)
        return gmpy2.cosh(z)

    def tanh(self, z):
        z = self.t(z)
        return gmpy2.tanh(z)

    def sech(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.sech(z)
        else:
            return 1/gmpy2.cosh(z)

    def csch(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.csch(z)
        else:
            return 1/gmpy2.sinh(z)

    def coth(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.coth(z)
        else:
            return 1/gmpy2.tanh(z)


# %%%  3.6 Inverse trigonometric functions

    def asin(self, z):
        z = self.t(z)
        return gmpy2.asin(z)

    def acos(self, z):
        z = self.t(z)
        return gmpy2.acos(z)

    def atan(self, z):
        z = self.t(z)
        return gmpy2.atan(z)

    def atan2(self, x, y):
        return gmpy2.atan2(x, y)

    def asec(self, z):
        z = self.t(z)
        return gmpy2.acos(1/z)

    def acsc(self, z):
        z = self.t(z)
        return gmpy2.asin(1/z)

    def acot(self, z):
        z = self.t(z)
        return gmpy2.atan(1/z)

    def gd(self, z):
        z = self.t(z)
        return 2*gmpy2.atan(gmpy2.tanh(z/2))

    def archav(self, z):
        z = self.t(z)
        return 2*gmpy2.asin(gmpy2.sqrt(z))


# %%%  3.7 Inverse hyperbolic functions

    def asinh(self, z):
        z = self.t(z)
        return gmpy2.asinh(z)

    def acosh(self, z):
        z = self.t(z)
        return gmpy2.acosh(z)

    def atanh(self, z):
        z = self.t(z)
        return gmpy2.atanh(z)

    def asech(self, z):
        z = self.t(z)
        return gmpy2.acosh(1/z)

    def acsch(self, z):
        z = self.t(z)
        return gmpy2.asinh(1/z)

    def acoth(self, z):
        z = self.t(z)
        return gmpy2.atanh(1/z)

    def arcgd(self, z):
        z = self.t(z)
        return gmpy2.atanh(gmpy2.sin(z))


# %%%  3.8 Factorials and related functions

    def factorial(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.gamma(z+1)
        else:
            return self._fm1(mpm().factorial, z)

    def binomial(self, n, k):
        n = self.t(n)
        k = self.t(k)
        if (isinstance(n, gmpy2.mpfr)) and (isinstance(k, gmpy2.mpfr)):
            return gmpy2.gamma(n+1) / (gmpy2.gamma(k+1) * gmpy2.gamma(n-k+1))
        else:
            return self._fm2(mpm().binomial, n, k)

    def multinomial(self, n, k):
        raise Exception("NOT IMPLEMENTED")

    def rf(self, z, n):
        z = self.t(z)
        n = self.t(n)
        if (isinstance(z, gmpy2.mpfr)) and (isinstance(n, gmpy2.mpfr)):
            return gmpy2.gamma(z+n) / gmpy2.gamma(z)
        else:
            return self._fm2(mpm().rf, z, n)

    def rising_factorial(self, z, n):
        z = self.t(z)
        n = self.t(n)
        if (isinstance(z, gmpy2.mpfr)) and (isinstance(n, gmpy2.mpfr)):
            return gmpy2.gamma(z+n) / gmpy2.gamma(z)
        else:
            return self._fm2(mpm().rf, z, n)

    def ff(self, z, n):
        z = self.t(z)
        n = self.t(n)
        if (isinstance(z, gmpy2.mpfr)) and (isinstance(n, gmpy2.mpfr)):
            return gmpy2.gamma(z+1) / gmpy2.gamma(z-n+1)
        else:
            return self._fm2(mpm().ff, z, n)

    def falling_factorial(self, z, n):
        z = self.t(z)
        n = self.t(n)
        if (isinstance(z, gmpy2.mpfr)) and (isinstance(n, gmpy2.mpfr)):
            return gmpy2.gamma(z+1) / gmpy2.gamma(z-n+1)
        else:
            return self._fm2(mpm().ff, z, n)

    def fac2(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            w = 0.25*(self.cospi(z)-1)
            return 2**(0.5*z) * (0.5*self.pi)**w * self.gamma(0.5*z+1)
        else:
            return self._fm1(mpm().fac2, z)

    def doublefactorial(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            w = 0.25*(self.cospi(z)-1)
            return 2**(0.5*z) * (0.5*self.pi)**w * self.gamma(0.5*z+1)
        else:
            return self._fm1(mpm().fac2, z)


# %%%  3.9 Gamma function and related functions

    def gamma(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.gamma(z)
        else:
            return self._fm1(mpm().gamma, z)

    def gamma1pm1(self, z):
        '''Returns gamma(z+1)-1.'''
        z = self.t(z)
        return self.gamma(z+1)-1

    def rgamma(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return 1.0/gmpy2.gamma(z)
        else:
            return self._fm1(mpm().rgamma, z)

    def loggamma(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.lngamma(z)
        else:
            return self._fm1(mpm().loggamma, z)

    def lgamma(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            return gmpy2.lngamma(z)
        else:
            return self._fm1(mpm().loggamma, z)

    def beta(self, a, b):
        a = self.t(a)
        b = self.t(b)
        if (isinstance(a, gmpy2.mpfr)) and (isinstance(b, gmpy2.mpfr)):
            return gmpy2.gamma(a) * gmpy2.gamma(b) / gmpy2.gamma(a+b)
        else:
            return self._fm2(mpm().beta, a, b)

    def gamma_ratio(self, a, b):
        a = self.t(a)
        b = self.t(b)
        if (isinstance(a, gmpy2.mpfr)) and (isinstance(b, gmpy2.mpfr)):
            return gmpy2.gamma(a) / gmpy2.gamma(b)
        else:
            return self._fm2(mpm().gamma_ratio, a, b)

    def gamma_delta_ratio(self, a, delta):
        a = self.t(a)
        delta = self.t(delta)
        if (isinstance(a, gmpy2.mpfr)) and (isinstance(delta, gmpy2.mpfr)):
            return gmpy2.gamma(a) / gmpy2.gamma(a+delta)
        else:
            return self._fm2(mpm().gamma_delta_ratio, a, delta)

    def catalan_c(self, z):
        z = self.t(z)
        if isinstance(z, gmpy2.mpfr):
            w = gmpy2.gamma(z+1)
            return gmpy2.gamma(2*z+1) / ((z+1)*w*w)
        else:
            return self._fm1(mpm().catalan_c, z)




##
##
##
##
### %% 4 Real scalar functions
##
##
### %%% 4.1 Error functions for real arguments
##
##    def real_erf(self, x):
##        x = self.t(x)
##        if isinstance(z, gmpy2.mpfr):
##            return gmpy2.erf(x)
##        else:
##            raise Exception("x needs to real")
##
##    def real_erfc(self, x):
##        x = self.t(x)
##        if isinstance(z, gmpy2.mpfr):
##            return gmpy2.erfc(x)
##        else:
##            raise Exception("x needs to real")
##
##    def real_erfinv(self, prob):
##        prob = mp.mpf(str(prob))
##        s = str(mp.erfinv(prob))
##        return self.t(s)
##
##    def real_erfcinv(self, prob):
##        prob = mp.mpf(str(prob))
##        s = str(mp.erfinv(1-prob))
##        return self.t(s)
##
##
### %%% 4.2 Incomplete gamma functions for non-negative real arguments and parameters
##
##    # Real lower non-normalised incomplete gamma function
##
##    def real_gamma_lower(self, a, x, **kwargs):
##        res = self.real_gamma_p(a, x, **kwargs)
##        return res * self.gamma(a)
##
##    # Real upper non-normalised incomplete gamma function
##
##    def real_gamma_upper(self, a, x, **kwargs):
##        res = self.real_gamma_q(a, x, **kwargs)
##        return res * self.gamma(a)
##
##    # Real lower normalised incomplete gamma function
##
##    def real_gamma_p(self, a, x, **kwargs):
##        a = mp.mpf(str(a))
##        x = mp.mpf(str(x))
##        s = str(ctxm.real_gamma_p(self, a, x, **kwargs))
##        return self.t(s)
##
##    # Real upper normalised incomplete gamma function
##
##    def real_gamma_q(self, a, x, **kwargs):
##        a = mp.mpf(str(a))
##        x = mp.mpf(str(x))
##        s = str(ctxm.real_gamma_q(self, a, x, **kwargs))
##        return self.t(s)
##
##    def real_gamma_tricomi(self, a, x, **kwargs):
##        res = self.real_gamma_p(a, x, **kwargs)
##        return res * self.power(x, -self.t(a))
##
##    def real_gamma_p_inv(self, a, prob, **kwargs):
##        a = mp.mpf(str(a))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_gamma_p_inv(self, a, prob, **kwargs))
##        return self.t(s)
##
##    def real_gamma_q_inv(self, a, prob, **kwargs):
##        a = mp.mpf(str(a))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_gamma_q_inv(self, a, prob, **kwargs))
##        return self.t(s)
##
##    def real_gamma_p_inva(self, x, prob, **kwargs):
##        x = mp.mpf(str(x))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_gamma_p_inva(self, x, prob, **kwargs))
##        return self.t(s)
##
##    def real_gamma_q_inva(self, x, prob, **kwargs):
##        x = mp.mpf(str(x))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_gamma_q_inva(self, x, prob, **kwargs))
##        return self.t(s)
##
##    def real_gamma_derivative(self, a, x):
##        a = self.t(a)
##        x = self.t(x)
##        return self.exp(-x) * self.power(x, a-1) / self.gamma(a)
##
## # %%%  4.3 Incomplete beta functions for non-negative real arguments and parameters
##
##    def real_beta3(self, a, b, x, **kwargs):
##        res = self.real_ibeta(a, b, x, **kwargs)
##        return res * self.beta(a, b)
##
##    def real_betac(self, a, b, x, **kwargs):
##        res = self.real_ibetac(a, b, x, **kwargs)
##        return res * self.beta(a, b)
##
##    def real_ibeta(self, a, b, x, **kwargs):
##        a = mp.mpf(str(a))
##        b = mp.mpf(str(b))
##        x = mp.mpf(str(x))
##        s = str(ctxm.real_ibeta(self, a, b, x, **kwargs))
##        return self.t(s)
##
##    def real_ibetac(self, a, b, x, **kwargs):
##        a = mp.mpf(str(a))
##        b = mp.mpf(str(b))
##        x = mp.mpf(str(x))
##        s = str(ctxm.real_ibetac(self, a, b, x, **kwargs))
##        return self.t(s)
##
##    def real_ibeta_inv(self, a, b, prob, **kwargs):
##        a = mp.mpf(str(a))
##        b = mp.mpf(str(b))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_ibeta_inv(self, a, b, prob, **kwargs))
##        return self.t(s)
##
##    def real_ibetac_inv(self, a, b, prob, **kwargs):
##        a = mp.mpf(str(a))
##        b = mp.mpf(str(b))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_ibetac_inv(self, a, b, prob, **kwargs))
##        return self.t(s)
##
##    def real_ibeta_inva(self, b, x, prob, **kwargs):
##        x = mp.mpf(str(x))
##        b = mp.mpf(str(b))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_ibeta_inva(self, b, x, prob, **kwargs))
##        return self.t(s)
##
##    def real_ibetac_inva(self, b, x, prob, **kwargs):
##        x = mp.mpf(str(x))
##        b = mp.mpf(str(b))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_ibetac_inva(self, b, x, prob, **kwargs))
##        return self.t(s)
##
##    def real_ibeta_invb(self, a, x, prob, **kwargs):
##        x = mp.mpf(str(x))
##        a = mp.mpf(str(a))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_ibeta_invb(self, a, x, prob, **kwargs))
##        return self.t(s)
##
##    def real_ibetac_invb(self, a, x, prob, **kwargs):
##        x = mp.mpf(str(x))
##        a = mp.mpf(str(a))
##        prob = mp.mpf(str(prob))
##        s = str(ctxm.real_ibetac_invb(self, a, x, prob, **kwargs))
##        return self.t(s)
##
##    def real_ibeta_derivative(self, a, b, x):
##        a = self.t(a)
##        b = self.t(b)
##        x = self.t(x)
##        return self.power(x, a-1) * self.power(1-x, b-1) / self.beta(a, b)
##




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












# %% 5 Basic continuous distribution functions


# %%%  5.1 Closed form distributions, based on elementary functions


# 5.1.1 Arcsine distribution, pdf

    def arcsine_pdf(self, x, a=0, b=1):
        return ctxm.arcsine_pdf(self, x, a, b)

# 5.1.2 Arcsine distribution, cdf and sf
    def arcsine_cdf(self, x, a=0, b=1, cdf=True):
        return ctxm.arcsine_cdf(self, x, a, b, cdf)

# 5.1.3 Arcsine distribution, qtf and isf
    def arcsine_qtf(self, prob, a=0, b=1, qtf=True):
        return ctxm.arcsine_qtf(self, prob, a, b, qtf)


# 5.1.4 Cauchy distribution, pdf

    def cauchy_pdf(self, x, a, b):
        return ctxm.cauchy_pdf(self, x, a, b)

# 5.1.5 Cauchy distribution, cdf and sf
    def cauchy_cdf(self, x, a, b, cdf=True):
        return ctxm.cauchy_cdf(self, x, a, b, cdf)

# 5.1.6 Cauchy distribution, qtf and isf
    def cauchy_qtf(self, prob, a, b, qtf=True):
        return ctxm.cauchy_qtf(self, prob, a, b, qtf)


# 5.1.7 Dagum distribution, pdf

    def dagum_pdf(self, x, a, b):
        return ctxm.dagum_pdf(self, x, a, b)

# 5.1.8 Dagum distribution, cdf and sf
    def dagum_cdf(self, x, a, b, cdf=True):
        return ctxm.dagum_cdf(self, x, a, b, cdf)

# 5.1.9 Dagum distribution, qtf and isf
    def dagum_qtf(self, prob, a, b, qtf=True):
        return ctxm.dagum_qtf(self, prob, a, b, qtf)


# 5.1.10 Exponential distribution, pdf

    def exponential_pdf(self, x, lambda1):
        return ctxm.exponential_pdf(self, x, lambda1)

# 5.1.11 Exponential distribution, cdf and sf
    def exponential_cdf(self, x, lambda1, cdf=True):
        return ctxm.exponential_cdf(self, x, lambda1, cdf)

# 5.1.12 Exponential distribution, qtf and isf
    def exponential_qtf(self, prob, lambda1, qtf=True):
        return ctxm.exponential_qtf(self, prob, lambda1, qtf)


# 5.1.13 Fisk distribution, pdf

    def fisk_pdf(self, x, a, b):
        return ctxm.fisk_pdf(self, x, a, b)

# 5.1.14 Fisk distribution, cdf and sf
    def fisk_cdf(self, x, a, b, cdf=True):
        return ctxm.fisk_cdf(self, x, a, b, cdf)

# 5.1.15 Fisk distribution, qtf and isf
    def fisk_qtf(self, prob, a, b, qtf=True):
        return ctxm.fisk_qtf(self, prob, a, b, qtf)


# 5.1.16 Frechet distribution, pdf

    def frechet_pdf(self, x, a, b):
        return ctxm.frechet_pdf(self, x, a, b)

# 5.1.17 Frechet distribution, cdf and sf
    def frechet_cdf(self, x, a, b, cdf=True):
        return ctxm.frechet_cdf(self, x, a, b, cdf)

# 5.1.18 Frechet distribution, qtf and isf
    def frechet_qtf(self, prob, a, b, qtf=True):
        return ctxm.frechet_qtf(self, prob, a, b, qtf)


# 5.1.19 Generalized Extreme Value (GEV), pdf

    def gev_pdf(self, x, a, b):
        return ctxm.gev_pdf(self, x, a, b)

# 5.1.20 Generalized Extreme Value (GEV), cdf and sf
    def gev_cdf(self, x, a, b, cdf=True):
        return ctxm.gev_cdf(self, x, a, b, cdf)

# 5.1.21 Generalized Extreme Value (GEV), qtf and isf
    def gev_qtf(self, prob, a, b, qtf=True):
        return ctxm.gev_qtf(self, prob, a, b, qtf)


# 5.1.22 Gompertz distribution, pdf

    def gompertz_pdf(self, x, a, b):
        return ctxm.gompertz_pdf(self, x, a, b)

# 5.1.23 Gompertz distribution, cdf and sf
    def gompertz_cdf(self, x, a, b, cdf=True):
        return ctxm.gompertz_cdf(self, x, a, b, cdf)

# 5.1.24 Gompertz distribution, qtf and isf
    def gompertz_qtf(self, prob, a, b, qtf=True):
        return ctxm.gompertz_qtf(self, prob, a, b, qtf)


# 5.1.25 Gumbel (Extreme Value) distribution, pdf

    def gumbel_pdf(self, x, a, b):
        return ctxm.gumbel_pdf(self, x, a, b)

# 5.1.26 Gumbel (Extreme Value) distribution, cdf and sf
    def gumbel_cdf(self, x, a, b, cdf=True):
        return ctxm.gumbel_cdf(self, x, a, b, cdf)

# 5.1.27 Gumbel (Extreme Value) distribution, qtf and isf
    def gumbel_qtf(self, prob, a, b, qtf=True):
        return ctxm.gumbel_qtf(self, prob, a, b, qtf)


# 5.1.28 Hyperexponential distribution, pdf

    def hyperexp_pdf(self, x, a, b):
        return ctxm.hyperexp_pdf(self, x, a, b)

# 5.1.29 Hyperexponential distribution, cdf and sf
    def hyperexp_cdf(self, x, a, b, cdf=True):
        return ctxm.hyperexp_cdf(self, x, a, b, cdf)

# 5.1.30 Hyperexponential distribution, qtf and isf
    def hyperexp_qtf(self, prob, a, b, qtf=True):
        return ctxm.hyperexp_qtf(self, prob, a, b, qtf)


# 5.1.31 Kumaraswamy distribution, pdf

    def kumaraswamy_pdf(self, x, a, b):
        return ctxm.kumaraswamy_pdf(self, x, a, b)

# 5.1.32 Kumaraswamy distribution, cdf and sf
    def kumaraswamy_cdf(self, x, a, b, cdf=True):
        return ctxm.kumaraswamy_cdf(self, x, a, b, cdf)

# 5.1.33 Kumaraswamy distribution, qtf and isf
    def kumaraswamy_qtf(self, prob, a, b, qtf=True):
        return ctxm.kumaraswamy_qtf(self, prob, a, b, qtf)


# 5.1.34 Laplace distribution, pdf

    def laplace_pdf(self, x, a, b):
        return ctxm.laplace_pdf(self, x, a, b)

# 5.1.35 Laplace distribution, cdf and sf
    def laplace_cdf(self, x, a, b, cdf=True):
        return ctxm.laplace_cdf(self, x, a, b, cdf)

# 5.1.36 Laplace distribution, qtf and isf
    def laplace_qtf(self, prob, a, b, qtf=True):
        return ctxm.laplace_qtf(self, prob, a, b, qtf)


# 5.1.37 Logistic distribution, pdf

    def logistic_pdf(self, x, a, b):
        return ctxm.logistic_pdf(self, x, a, b)

# 5.1.38 Logistic distribution, cdf and sf
    def logistic_cdf(self, x, a, b, cdf=True):
        return ctxm.logistic_cdf(self, x, a, b, cdf)

# 5.1.39 Logistic distribution, qtf and isf
    def logistic_qtf(self, prob, a, b, qtf=True):
        return ctxm.logistic_qtf(self, prob, a, b, qtf)


# 5.1.40 Lomax distribution, pdf

    def lomax_pdf(self, x, a, b):
        return ctxm.lomax_pdf(self, x, a, b)

# 5.1.41 Lomax distribution, cdf and sf
    def lomax_cdf(self, x, a, b, cdf=True):
        return ctxm.lomax_cdf(self, x, a, b, cdf)

# 5.1.42 Lomax distribution, qtf and isf
    def lomax_qtf(self, prob, a, b, qtf=True):
        return ctxm.lomax_qtf(self, prob, a, b, qtf)


# 5.1.43 Pareto distribution, pdf

    def pareto_pdf(self, x, a, b):
        return ctxm.pareto_pdf(self, x, a, b)

# 5.1.44 Pareto distribution, cdf and sf
    def pareto_cdf(self, x, a, b, cdf=True):
        return ctxm.pareto_cdf(self, x, a, b, cdf)

# 5.1.45 Pareto distribution, qtf and isf
    def pareto_qtf(self, prob, a, b, qtf=True):
        return ctxm.pareto_qtf(self, prob, a, b, qtf)


# 5.1.46 Rayleigh distribution, pdf

    def rayleigh_pdf(self, x, b):
        return ctxm.rayleigh_pdf(self, x, b)

# 5.1.47 Rayleigh distribution, cdf and sf
    def rayleigh_cdf(self, x, b, cdf=True):
        return ctxm.rayleigh_cdf(self, x, b, cdf)

# 5.1.48 Rayleigh distribution, qtf and isf
    def rayleigh_qtf(self, prob, b, qtf=True):
        return ctxm.rayleigh_qtf(self, prob, b, qtf)


# 5.1.49 Singh-Maddala (Burr Type XII) distribution, pdf

    def singh_maddala_pdf(self, x, b):
        return ctxm.singh_maddala_pdf(self, x, b)

# 5.1.50 Singh-Maddala (Burr Type XII) distribution, cdf and sf
    def singh_maddala_cdf(self, x, b, cdf=True):
        return ctxm.singh_maddala_cdf(self, x, b, cdf)

# 5.1.51 Singh-Maddala (Burr Type XII) distribution, qtf and isf
    def singh_maddala_qtf(self, prob, b, qtf=True):
        return ctxm.singh_maddala_qtf(self, prob, b, qtf)


# 5.1.52 Triangular distribution, pdf

    def triangular_pdf(self, x, lower, upper, mode):
        return ctxm.triangular_pdf(self, x, lower, upper, mode)

# 5.1.53 Triangular distribution, cdf and sf
    def triangular_cdf(self, x, lower, mode, upper, cdf=True):
        return ctxm.triangular_cdf(self, x, lower, mode, upper, cdf)


# 5.1.54 Triangular distribution, qtf and isf

    def triangular_qtf(self, prob, lower, mode, upper, qtf=True):
        return ctxm.triangular_qtf(self, prob, lower, mode, upper, qtf)


# 5.1.55 Uniform distribution, pdf

    def uniform_pdf(self, x, a, b):
        return ctxm.uniform_pdf(self, x, a, b)

# 5.1.56 Uniform distribution, cdf and sf
    def uniform_cdf(self, x, a, b, cdf=True):
        return ctxm.uniform_cdf(self, x, a, b, cdf)


# 5.1.57 Uniform distribution, qtf and isf

    def uniform_qtf(self, prob, a, b, qtf=True):
        return ctxm.uniform_qtf(self, prob, a, b, qtf)


# 5.1.58 Weibull distribution, pdf

    def weibull_pdf(self, x, a, b):
        return ctxm.weibull_pdf(self, x, a, b)

# 5.1.59 Weibull distribution, cdf and sf
    def weibull_cdf(self, x, a, b, cdf=True):
        return ctxm.weibull_cdf(self, x, a, b, cdf)

# 5.1.60 Weibull distribution, qtf and isf
    def weibull_qtf(self, prob, a, b, qtf=True):
        return ctxm.weibull_qtf(self, prob, a, b, qtf)


# %%%  5.2 Closed form distributions, based on the error function


# 5.2.1 Birnbaum-Saunders distribution, pdf

    def birnb_saunders_pdf(self, x, mu, sigma):
        return ctxm.birnb_saunders_pdf(self, x, mu, sigma)

# 5.2.2 Birnbaum-Saunders distribution, cdf and sf
    def birnb_saunders_cdf(self, x, mu, sigma, cdf=True):
        return ctxm.birnb_saunders_cdf(self, x, mu, sigma, cdf)

# 5.2.3 Birnbaum-Saunders distribution distribution, qtf and isf
    def birnb_saunders_qtff(self, x, mu, sigma, qtf=True):
        return ctxm.birnb_saunders_qtff(self, x, mu, sigma, qtf)


# 5.2.4 Exponentially Modified Gaussian (EMG) distribution, pdf

    def emg_pdf(self, x, mu, sigma):
        return ctxm.emg_pdf(self, x, mu, sigma)

# 5.2.5 Exponentially Modified Gaussian (EMG) distribution, cdf and sf
    def emg_cdf(self, x, mu, sigma, cdf=True):
        return ctxm.emg_cdf(self, x, mu, sigma, cdf)

# 5.2.6 Exponentially Modified Gaussian (EMG) distribution, qtf and isf
    def emg_qtff(self, x, mu, sigma, qtf=True):
        return ctxm.emg_qtff(self, x, mu, sigma, qtf)


# 5.2.7 Folded normal distribution, pdf

    def folded_normal_pdf(self, x, sigma):
        return ctxm.folded_normal_pdf(self, x, sigma)

# 5.2.8 Folded normal distribution, cdf and sf
    def folded_normal_cdf(self, x, sigma, cdf=True):
        return ctxm.folded_normal_cdf(self, x, sigma, cdf)

# 5.2.9 Folded normal distribution, qtf and isf
    def folded_normal_qtff(self, x, sigma, qtf=True):
        return ctxm.folded_normal_qtff(self, x, sigma, qtf)


# 5.2.10 Half-normal distribution, pdf

    def half_normal_pdf(self, x, sigma):
        return ctxm.half_normal_pdf(self, x, sigma)

# 5.2.11 Half_normal distribution, cdf and sf
    def half_normal_cdf(self, x, sigma, cdf=True):
        return ctxm.half_normal_cdf(self, x, sigma, cdf)

# 5.2.12 Half_normal distribution, qtf and isf
    def half_normal_qtff(self, x, sigma, qtf=True):
        return ctxm.half_normal_qtff(self, x, sigma, qtf)


# 5.2.13 Johnson 𝑆𝐵 distribution, pdf

    def johnson_sb_pdf(self, x, sigma):
        return ctxm.johnson_sb_pdf(self, x, sigma)

# 5.2.14 Johnson 𝑆𝐵 distribution, cdf and sf
    def johnson_sb_cdf(self, x, sigma, cdf=True):
        return ctxm.johnson_sb_cdf(self, x, sigma, cdf)

# 5.2.15 Johnson 𝑆𝐵 distribution, qtf and isf
    def johnson_sb_qtff(self, x, sigma, qtf=True):
        return ctxm.johnson_sb_qtff(self, x, sigma, qtf)


# 5.2.16 Johnson 𝑆𝑈 distribution, pdf

    def johnson_su_pdf(self, x, sigma):
        return ctxm.johnson_su_pdf(self, x, sigma)

# 5.2.17 Johnson 𝑆𝑈 distribution, cdf and sf
    def johnson_su_cdf(self, x, sigma, cdf=True):
        return ctxm.johnson_su_cdf(self, x, sigma, cdf)

# 5.2.18 Johnson 𝑆𝑈 distribution, qtf and isf
    def johnson_su_qtff(self, x, sigma, qtf=True):
        return ctxm.johnson_su_qtff(self, x, sigma, qtf)


# 5.2.19 Lévy distribution, pdf

    def levy_pdf(self, x, a, b):
        return ctxm.levy_pdf(self, x, a, b)

# 5.2.20 Lévy distribution, cdf and sf
    def levy_cdf(self, x, a, b, cdf=True):
        return ctxm.levy_cdf(self, x, a, b, cdf)

# 5.2.21 Lévy distribution, qtf and isf
    def levy_qtf(self, prob, a, b, qtf=True):
        return ctxm.levy_qtf(self, prob, a, b, qtf)


# 5.2.22 Lognormal distribution, pdf

    def lognormal_pdf(self, x, mu, sigma):
        return ctxm.lognormal_pdf(self, x, mu, sigma)

# 5.2.23 Lognormal distribution, cdf and sf
    def lognormal_cdf(self, x, mu, sigma, cdf=True):
        return ctxm.lognormal_cdf(self, x, mu, sigma, cdf)

# 5.2.24 Lognormal distribution, qtf and isf
    def lognormal_qtf(self, prob, mu, sigma, qtf=True):
        return ctxm.lognormal_qtf(self, prob, mu, sigma, qtf)


# 5.2.25 Moyal distribution, pdf

    def moyal_pdf(self, x, a, b):
        return ctxm.moyal_pdf(self, x, a, b)

# 5.2.26 Moyal distribution, cdf and sf
    def moyal_cdf(self, x, a, b, cdf=True):
        return ctxm.moyal_cdf(self, x, a, b, cdf)

# 5.2.27 Moyal distribution, qtf and isf
    def moyal_qtf(self, prob, a, b, qtf=True):
        return ctxm.moyal_qtf(self, prob, a, b, qtf)


# 5.2.28 Normal distribution, pdf

    def normal_pdf(self, x, mu=0, sigma=1):
        return ctxm.normal_pdf(self, x, mu, sigma)

# 5.2.29 Normal distribution, cdf and sf
    def normal_cdf(self, x, mu=0, sigma=1, cdf=True):
        return ctxm.normal_cdf(self, x, mu, sigma, cdf)

# 5.2.30 Normal distribution, qtf and isf
    def normal_qtf(self, prob, mu=0, sigma=1, qtf=True):
        return ctxm.normal_qtf(self, prob, mu, sigma, qtf)


# 5.2.31 Skew normal distribution, pdf

    def skewnormal_pdf(self, x, a, b, c):
        return ctxm.skewnormal_pdf(self, x, a, b, c)

# 5.2.32 Skew normal distribution, cdf and sf
    def skewnormal_cdf(self, x, a, b, c, cdf=True):
        return ctxm.skewnormal_cdf(self, x, a, b, c, cdf)

# 5.2.33 Skew normal distribution, qtf and isf
    def skewnormal_qtf(self, prob, a, b, c, qtf=True):
        return ctxm.skewnormal_qtf(self, prob, a, b, c, qtf)


# 5.2.34 Truncated normal distribution, pdf

    def trunc_normal_pdf(self, x, a, b, c):
        return ctxm.trunc_normal_pdf(self, x, a, b, c)

# 5.2.35 Truncated normal distribution, cdf and sf
    def trunc_normal_cdf(self, x, a, b, c, cdf=True):
        return ctxm.trunc_normal_cdf(self, x, a, b, c, cdf)

# 5.2.36 Truncated normal distribution, qtf and isf
    def trunc_normal_qtf(self, prob, a, b, c, qtf=True):
        return ctxm.trunc_normal_qtf(self, prob, a, b, c, qtf)


# 5.2.37 Wald distribution, pdf

    def wald_pdf(self, x, mu, b):
        return ctxm.wald_pdf(self, x, mu, b)

# 5.2.38 Wald distribution, cdf and sf
    def wald_cdf(self, x, mu, b, cdf=True):
        return ctxm.wald_cdf(self, x, mu, b, cdf)

# 5.2.39 Wald distribution, qtf and isf
    def wald_qtf(self, prob, mu, b, qtf=True):
        return ctxm.wald_qtf(self, prob, mu, b, qtf)


# %%%  5.3 Closed form distributions, based on the incomplete gamma function


# 5.3.1 Amoroso distribution, pdf

    def amoroso_pdf(self, x, nu):
        return ctxm.amoroso_pdf(self, x, nu)

# 5.3.2 Amoroso distribution, cdf and sf
    def amoroso_cdf(self, x, nu, cdf=True, **kwargs):
        return ctxm.amoroso_cdf(self, x, nu, cdf, **kwargs)

# 5.3.3 Amoroso distribution, qtf and isf
    def amoroso_qtf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.amoroso_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.4 𝜒-distribution, pdf

    def chi_pdf(self, x, nu):
        return ctxm.chi_pdf(self, x, nu)

# 5.3.5 𝜒-distribution, cdf and sf
    def chi_cdf(self, x, nu, cdf=True, **kwargs):
        return ctxm.chi_cdf(self, x, nu, cdf, **kwargs)

# 5.3.6 𝜒-distribution, qtf and isf
    def chi_qtf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.chi_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.7 𝜒2-distribution, pdf

    def chi_squared_pdf(self, x, nu):
        return ctxm.chi_squared_pdf(self, x, nu)

# 5.3.8 𝜒2-distribution, cdf and sf
    def chi_squared_cdf(self, x, nu, cdf=True, **kwargs):
        return ctxm.chi_squared_cdf(self, x, nu, cdf, **kwargs)

# 5.3.9 𝜒2-distribution, qtf and isf
    def chi_squared_qtf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.chi_squared_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.10 Distribution of the logarithm of a 𝜒2 random variable, pdf

    def logchisquare_pdf(self, x, nu):
        return ctxm.logchisquare_pdf(self, x, nu)

# 5.3.11 Distribution of the logarithm of a 𝜒2 random variable, cdf and sf
    def logchisquare_cdf(self, x, nu, cdf=True, **kwargs):
        return ctxm.logchisquare_cdf(self, x, nu, cdf, **kwargs)

    def logchisquare_sf(self, x, nu, cdf=True, **kwargs):
        return ctxm.logchisquare_sf(self, x, nu, cdf, **kwargs)

# 5.3.12 Distribution of the logarithm of a 𝜒2 random variable, qtf and isf
    def logchisquare_qtf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.logchisquare_qtf(self, prob, nu, qtf, **kwargs)

    def logchisquare_isf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.logchisquare_isf(self, prob, nu, qtf, **kwargs)


# 5.3.13 Gamma distribution, pdf

    def gamma_pdf(self, x, a, b):
        return ctxm.gamma_pdf(self, x, a, b)

# 5.3.14 Gamma distribution, cdf and sf
    def gamma_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.gamma_cdf(self, x, a, b, cdf, **kwargs)

# 5.3.15 Gamma distribution, qtf and isf
    def gamma_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.gamma_qtf(self, prob, a, b, qtf, **kwargs)


# 5.3.16 Inverse 𝜒2-distribution, pdf

    def invchisquared_pdf(self, x, a, b):
        return ctxm.invchisquared_pdf(self, x, a, b)

# 5.3.17 Inverse 𝜒2-distribution, cdf and sf
    def invchisquared_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.invchisquared_cdf(self, x, a, b, cdf)

# 5.3.18 Inverse 𝜒2-distribution, qtf and isf
    def invchisquared_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.invchisquared_qtf(self, prob, a, b, qtf)


# 5.3.19 Inverse Gamma distribution, pdf

    def invgamma_pdf(self, x, a, b):
        return ctxm.invgamma_pdf(self, x, a, b)

# 5.3.20 Inverse Gamma distribution, cdf and sf
    def invgamma_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.invgamma_cdf(self, x, a, b, cdf, **kwargs)

# 5.3.21 Inverse Gamma distribution, qtf and isf
    def invgamma_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.invgamma_qtf(self, prob, a, b, qtf, **kwargs)


# 5.3.22 Maxwell distribution, pdf

    def maxwell_pdf(self, x, b):
        return ctxm.maxwell_pdf(self, x, b)

# 5.3.23 Maxwell distribution, cdf and sf
    def maxwell_cdf(self, x, b, cdf=True, **kwargs):
        return ctxm.maxwell_cdf(self, x, b, cdf, **kwargs)

# 5.3.24 Maxwell distribution, qtf and isf
    def maxwell_qtf(self, prob, b, qtf=True, **kwargs):
        return ctxm.maxwell_qtf(self, prob, b, qtf, **kwargs)


# 5.3.25 Nakagami distribution, pdf

    def nakagami_pdf(self, x, m, w):
        return ctxm.nakagami_pdf(self, x, m, w)

# 5.3.26 Nakagami distribution, cdf and sf
    def nakagami_cdf(self, x, m, w, cdf=True, **kwargs):
        return ctxm.nakagami_cdf(self, x, m, w, cdf, **kwargs)

# 5.3.27 Nakagami distribution, qtf and isf
    def nakagami_qtf(self, prob, m, w, qtf=True, **kwargs):
        return ctxm.nakagami_qtf(self, prob, m, w, qtf, **kwargs)


# 5.3.28 Stacy (generalized gamma) distribution, pdf

    def stacy_pdf(self, x, m, w):
        return ctxm.stacy_pdf(self, x, m, w)

# 5.3.29 Stacy (generalized gamma) distribution, cdf and sf
    def stacy_cdf(self, x, m, w, cdf=True, **kwargs):
        return ctxm.stacy_cdf(self, x, m, w, cdf, **kwargs)

# 5.3.30 Stacy (generalized gamma) distribution, qtf and isf
    def stacy_qtf(self, prob, m, w, qtf=True, **kwargs):
        return ctxm.stacy_qtf(self, prob, m, w, qtf, **kwargs)


# %%%  5.4 Closed form distributions, based on the incomplete beta function


# 5.4.1 Beta distribution, pdf

    def beta_pdf(self, x, a, b):
        return ctxm.beta_pdf(self, x, a, b)

# 5.4.2 Beta distribution, cdf and sf
    def beta_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.beta_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.3 Beta distribution, qtf and isf
    def beta_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.beta_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.4 Distribution of the negative logarithm of a beta variable, pdf

    def logrv_beta_pdf(self, x, a, b):
        return ctxm.logbeta_pdf(self, x, a, b)

# 5.4.5 Distribution of the negative logarithm of a beta variable, cdf and sf
    def logrv_beta_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.logbeta_cdf(self, x, a, b, cdf, **kwargs)

    def logrv_beta_sf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.logbeta_sf(self, x, a, b, cdf, **kwargs)

# 5.4.6 Distribution of the negative logarithm of a beta variable, qtf and isf
    def logrv_beta_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.logbeta_qtf(self, prob, a, b, qtf, **kwargs)

    def logrv_beta_isf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.logbeta_isf(self, prob, a, b, qtf, **kwargs)


# 5.4.7 Beta-prime distribution, pdf

    def beta_prime_pdf(self, x, a, b):
        return ctxm.beta_prime_pdf(self, x, a, b)

# 5.4.8 Beta-prime distribution, cdf and sf
    def beta_prime_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.beta_prime_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.9 Beta-prime distribution, qtf and isf
    def beta_prime_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.beta_prime_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.10 Generalized Beta (Type 1) distribution, pdf

    def genbeta1_pdf(self, x, a, b):
        return ctxm.genbeta1_pdf(self, x, a, b)

# 5.4.11 Generalized Beta (Type 1) distribution, cdf and sf
    def genbeta1_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.genbeta1_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.12 Generalized Beta (Type 1) distribution, qtf and isf
    def genbeta1_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.genbeta1_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.13 Generalized Beta (Type 2) distribution, pdf

    def genbeta2_pdf(self, x, a, b):
        return ctxm.genbeta2_pdf(self, x, a, b)

# 5.4.14 Generalized Beta (Type 2) distribution, cdf and sf
    def genbeta2_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.genbeta2_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.15 Generalized Beta (Type 2) distribution, qtf and isf
    def genbeta2_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.genbeta2_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.16 Generalized logistic distribution, pdf

    def genlogistic_pdf(self, x, a, b):
        return ctxm.genlogistic_pdf(self, x, a, b)

# 5.4.17 Generalized logistic distribution, cdf and sf
    def genlogistic_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.genlogistic_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.18 Generalized logistic distribution, qtf and isf
    def genlogistic_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.genlogistic_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.19 Generalized beta-exponential distribution, pdf

    def gen_beta_exp_pdf(self, x, a, b):
        return ctxm.gen_beta_exp_pdf(self, x, a, b)

# 5.4.20 Generalized beta-exponential distribution, cdf and sf
    def gen_beta_exp_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.gen_beta_exp_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.21 Generalized beta-exponential distribution, qtf and isf
    def gen_beta_exp_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.gen_beta_exp_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.22 Fisher 𝐹 distribution, pdf

    def fisher_f_pdf(self, x, df1, df2, **kwargs):
        return ctxm.fisher_f_pdf(self, x, df1, df2)

# 5.4.23 Fisher 𝐹 distribution, cdf and sf
    def fisher_f_cdf(self, x, df1, df2, cdf=True, **kwargs):
        return ctxm.fisher_f_cdf(self, x, df1, df2, cdf, **kwargs)

# 5.4.24 Fisher 𝐹 distribution, qtf and isf
    def fisher_f_qtf(self, prob, df1, df2, qtf=True, **kwargs):
        return ctxm.fisher_f_qtf(self, prob, df1, df2, qtf, **kwargs)


# 5.4.25 Fisher 𝑧 distribution, pdf

    def fisher_z_pdf(self, x, df1, df2, **kwargs):
        return ctxm.fisher_z_pdf(self, x, df1, df2)

# 5.4.26 Fisher 𝑧 distribution, cdf and sf
    def fisher_z_cdf(self, x, df1, df2, cdf=True, **kwargs):
        return ctxm.fisher_z_cdf(self, x, df1, df2, cdf, **kwargs)

    def fisher_z_sf(self, x, df1, df2, cdf=True, **kwargs):
        return ctxm.fisher_z_sf(self, x, df1, df2, cdf, **kwargs)

# 5.4.27 Fisher 𝑧 distribution, qtf and isf
    def fisher_z_qtf(self, prob, df1, df2, qtf=True, **kwargs):
        return ctxm.fisher_z_qtf(self, prob, df1, df2, qtf, **kwargs)

    def fisher_z_isf(self, prob, df1, df2, qtf=True, **kwargs):
        return ctxm.fisher_z_isf(self, prob, df1, df2, qtf, **kwargs)


# 5.4.28 Student 𝑡 distribution, pdf

    def student_t_pdf(self, x, df):
        return ctxm.student_t_pdf(self, x, df)

# 5.4.29 Student 𝑡 distribution, cdf and sf
    def student_t_cdf(self, x, df, cdf=True, **kwargs):
        return ctxm.student_t_cdf(self, x, df, cdf, **kwargs)

# 5.4.30 Student 𝑡 distribution, qtf and isf
    def student_t_qtf(self, prob, df, qtf=True, **kwargs):
        return ctxm.student_t_qtf(self, prob, df, qtf, **kwargs)


# 5.4.31 Pearson’s rho distribution (under 𝐻0): pdf

    def pearson_rho_pdf(self, r, N):
        return ctxm.pearson_rho_pdf(self, r, N)

# 5.4.32 Pearson’s rho distribution (under 𝐻0): cdf and sf
    def pearson_rho_cdf(self, r, N, cdf=True, **kwargs):
        return ctxm.pearson_rho_cdf(self, r, N, cdf)

# 5.4.33 Pearson’s rho distribution (under 𝐻0): qtf and isf
    def pearson_rho_qtf(self, q, N, qtf=True, **kwargs):
        return ctxm.pearson_rho_qtf(self, q, N, qtf)


# %% 6 Advanced continuous distribution functions


# %%%  6.1 Closed form distributions, based on the distribution of the product of beta variables


# 6.1.2 Distribution of the product of independent beta variables, pdf

    def beta_product_pdf(self, x, p, bi, ci, method='default'):
        return ctxm.beta_product_pdf(self, x, p, bi, ci, method)


# 6.1.3 Distribution of the product of independent beta variables, cdf and sf

    def beta_product_cdf(self, x, p, bi, ci, cdf=True, method='default'):
        return ctxm.beta_product_cdf(self, x, p, bi, ci, cdf, method)


# 6.1.4 Distribution of the product of independent beta variables, qtf and isf

    def beta_product_qtf(self, q, p, bi, ci, qtf=True, method='default'):
        return ctxm.beta_product_qtf(self, q, p, bi, ci, qtf, method)


# %%%  6.2 Distribution functions related to multivariate statistical analysis


# 6.2.1 Roy’s largest root distribution, pdf, cdf and sf

    def roy_pdf_cdf_sf(self, x, p, n1, n2):
        return ctxm.roy_pdf_cdf_sf(self, x, p, n1, n2)


# 6.2.2 Roy’s largest root distribution, pdf

    def roy_pdf(self, x, p, n1, n2, method='default'):
        return ctxm.roy_pdf(self, x, p, n1, n2, method)


# 6.2.3 Roy’s largest root distribution, cdf and sf

    def roy_cdf(self, x, p, n1, n2, cdf=True, method='default'):
        return ctxm.roy_cdf(self, x, p, n1, n2, cdf, method)


# 6.2.4 Roy’s largest root distribution, qtf and isf

    def roy_qtf(self, q, p, n1, n2, qtf=True, method='default'):
        return ctxm.roy_qtf(self, q, p, n1, n2, qtf, method)


# 6.2.5 Wilks’ Λ distribution, pdf

    def wilks_lambda_pdf(self, x, p, n1, n2, method='default'):
        return ctxm.wilks_lambda_pdf(self, x, p, n1, n2, method)


# 6.2.6 Wilks’ Λ distribution, cdf and sf

    def wilks_lambda_cdf(self, x, p, n1, n2, cdf=True, method='default'):
        return ctxm.wilks_lambda_cdf(self, x, p, n1, n2, cdf, method)


# 6.2.7 Wilks’ Λ distribution, qtf and isf

    def wilks_lambda_qtf(self, q, p, n1, n2, qtf=True, method='default'):
        return ctxm.wilks_lambda_qtf(self, q, p, n1, n2, qtf, method)


# 6.2.8 Pillai’s 𝑉 distribution, pdf

    def pillai_v_pdf(self, x, p, n1, n2, method='default'):
        return ctxm.pillai_v_pdf(self, x, p, n1, n2, method)


# 6.2.9 Pillai’s 𝑉 distribution, cdf and sf

    def pillai_v_cdf(self, x, p, n1, n2, cdf=True, method='default'):
        return ctxm.pillai_v_cdf(self, x, p, n1, n2, cdf, method)


# 6.2.10 Pillai’s 𝑉 distribution, qtf and isf

    def pillai_v_qtf(self, q, p, n1, n2, qtf=True, method='default'):
        return ctxm.pillai_v_qtf(self, q, p, n1, n2, qtf, method)


# 6.2.11 Hotelling’s 𝑇2 distribution, pdf

    def hotelling_t2_pdf(self, x, p, n1, n2, method='default'):
        return ctxm.hotelling_t2_pdf(self, x, p, n1, n2, method)


# 6.2.12 Hotelling’s 𝑇2 distribution, cdf and sf

    def hotelling_t2_cdf(self, x, p, n1, n2, cdf=True, method='default'):
        return ctxm.hotelling_t2_cdf(self, x, p, n1, n2, cdf, method)


# 6.2.13 Hotelling’s 𝑇2 distribution, qtf and isf

    def hotelling_t2_qtf(self, q, p, n1, n2, qtf=True, method='default'):
        return ctxm.hotelling_t2_qtf(self, q, p, n1, n2, qtf, method)


# 6.2.14 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes, pdf

    def box_cov_pdf(self, x, p, ni, method='default'):
        return ctxm.box_cov_pdf(self, x, p, ni, method)


# 6.2.15 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes, cdf and sf

    def box_cov_cdf(self, x, p, ni, cdf=True, method='default'):
        return ctxm.box_cov_cdf(self, x, p, ni, cdf, method)


# 6.2.16 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes, qtf and isf

    def box_cov_qtf(self, q, p, ni, qtf=True, method='default'):
        return ctxm.box_cov_qtf(self, q, p, ni, qtf, method)


# 6.2.17 Distribution of Box’s test for same multivariate normal distributions,, unequal sample sizes, pdf

    def box_means_cov_pdf(self, x, p, ni, method='default'):
        return ctxm.box_means_cov_pdf(self, x, p, ni, method)


# 6.2.18 Distribution of Box’s test for same multivariate normal distributions,, unequal sample sizes, cdf and sf

    def box_means_cov_cdf(self, x, p, ni, cdf=True, method='default'):
        return ctxm.box_means_cov_cdf(self, x, p, ni, cdf, method)


# 6.2.19 Distribution of Box’s test for same multivariate normal distributions,, unequal sample sizes, qtf and isf

    def box_means_cov_qtf(self, q, p, ni, qtf=True, method='default'):
        return ctxm.box_means_cov_qtf(self, q, p, ni, qtf, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix, pdf

    def lrt_vc0_pdf(self, x, p, n, method='default'):
        return ctxm.lrt_vc0_pdf(self, x, p, n, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix, cdf and sf

    def lrt_vc0_cdf(self, x, p, n, cdf=True, method='default'):
        return ctxm.lrt_vc0_cdf(self, x, p, n, cdf, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix, qtf and isf

    def lrt_vc0_qtf(self, q, p, n, qtf=True, method='default'):
        return ctxm.lrt_vc0_qtf(self, q, p, n, qtf, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean, pdf

    def lrt_x0_vc0_pdf(self, x, p, n, method='default'):
        return ctxm.lrt_x0_vc0_pdf(self, x, p, n, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean, cdf and sf

    def lrt_x0_vc0_cdf(self, x, p, n, cdf=True, method='default'):
        return ctxm.lrt_x0_vc0_cdf(self, x, p, n, cdf, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean, qtf and isf

    def lrt_x0_vc0_qtf(self, q, p, n, qtf=True, method='default'):
        return ctxm.lrt_x0_vc0_qtf(self, q, p, n, qtf, method)


# %%%  6.3 Distributions related to the multivariate normal distribution


# 6.3.3 Normal maximum distribution: pdf

    def nmax_pdf(self, x, k):
        return ctxm.nmax_pdf(self, x, k)

# 6.3.4 Normal maximum distribution: cdf and sf
    def nmax_cdf(self, x, k):
        return ctxm.nmax_cdf(self, x, k)

# 6.3.5 Normal maximum distribution: qtf and isf
    def nmax_qtf(self, q, k):
        return ctxm.nmax_qtf(self, q, k)


# 6.3.6 Normal maximum modulus distribution: pdf

    def nmm_pdf(self, x, k):
        return ctxm.nmm_pdf(self, x, k)

# 6.3.7 Normal maximum modulus distribution: cdf and sf
    def nmm_cdf(self, x, k):
        return ctxm.nmm_cdf(self, x, k)

# 6.3.8 Normal maximum modulus distribution: qtf and isf
    def nmm_qtf(self, q, k):
        return ctxm.nmm_qtf(self, q, k)


# 6.3.9 Normal maximum distribution, equicorrelated case: pdf

    def nmax_corr_pdf(self, x, k, rho):
        return ctxm.nmax_corr_pdf(self, x, k, rho)

# 6.3.10 Normal maximum distribution, equicorrelated case:: cdf and sf
    def nmax_corr_cdf(self, x, k, rho, cdf=True):
        return ctxm.nmax_corr_cdf(self, x, k, rho)

# 6.3.11 Normal maximum distribution, equicorrelated case: qtf and isf
    def nmax_corr_qtf(self, q, k, rho, qtf=True):
        return ctxm.nmax_corr_qtf(self, q, k, rho, qtf=True)


# 6.3.12 Normal maximum modulus distribution, equicorrelated case: pdf

    def nmm_corr_pdf(self, x, k, rho):
        return ctxm.nmm_corr_pdf(self, x, k, rho)

# 6.3.13 Normal maximum modulus distribution, equicorrelated case: cdf and sf
    def nmm_corr_cdf(self, x, k, rho, cdf=True):
        return ctxm.nmm_corr_cdf(self, x, k, rho)

# 6.3.14 Normal maximum modulus distribution, equicorrelated case: qtf and isf
    def nmm_corr_qtf(self, q, k, rho, qtf=True):
        return ctxm.nmm_corr_qtf(self, q, k, rho, qtf)


# 6.3.15 Normal range distribution: pdf

    def nrange_pdf(self, x, k):
        return ctxm.nrange_pdf(self, x, k)

# 6.3.16 Normal range distribution: cdf and sf
    def nrange_cdf(self, x, k, cdf=True):
        return ctxm.nrange_cdf(self, x, k)

# 6.3.17 Normal range distribution: qtf and isf
    def nrange_qtf(self, q, k, qtf=True):
        return ctxm.nrange_qtf(self, q, k, qtf)


# %%%  6.4 Distributions related to multiple comparisons of means


# 6.4.3 Studentized maximum distribution: pdf

    def smax_pdf(self, x, k, n):
        return ctxm.smax_pdf(self, x, k, n)


# 6.4.4 Studentized maximum distribution: cdf and sf

    def smax_cdf(self, x, k, n, cdf=True):
        return ctxm.smax_cdf(self, x, k, n)


# 6.4.5 Studentized maximum distribution: qtf and isf

    def smax_qtf(self, q, k, n, qtf=True):
        return ctxm.smax_qtf(self, q, k, n, qtf)


# 6.4.7 Studentized maximum modulus distribution: pdf

    def smm_pdf(self, x, k, n):
        return ctxm.smm_pdf(self, x, k, n)


# 6.4.8 Studentized maximum modulus distribution: cdf and sf

    def smm_cdf(self, x, k, n, cdf=True):
        return ctxm.smm_cdf(self, x, k, n)


# 6.4.9 Studentized maximum modulus distribution: cdf and sf

    def smm_qtf(self, q, k, n, qtf=True):
        return ctxm.smm_qtf(self, q, k, n, qtf)


# 6.4.11 Dunnett’s 𝑡-distribution, 1-sided: pdf

    def dunnett1_pdf(self, x, k, n, rho):
        return ctxm.dunnett1_pdf(self, x, k, n, rho)

# 6.4.12 Dunnett’s 𝑡-distribution, 1-sided: cdf and sf
    def dunnett1_cdf(self, x, k, n, rho, cdf=True):
        return ctxm.dunnett1_cdf(self, x, k, n, rho)

# 6.4.13 Dunnett’s 𝑡-distribution, 1-sided: qtf and isf
    def dunnett1_qtf(self, q, k, n, rho, qtf=True):
        return ctxm.dunnett1_qtf(self, q, k, n, rho, qtf)


# 6.4.15 Dunnett’s t-distribution, 2-sided: pdf

    def dunnett2_pdf(self, x, k, n, rho):
        return ctxm.dunnett2_pdf(self, x, k, n, rho)

# 6.4.16 Dunnett’s 𝑡-distribution, 2-sided: cdf and sf
    def dunnett2_cdf(self, x, k, n, rho, cdf=True):
        return ctxm.dunnett2_cdf(self, x, k, n, rho)

# 6.4.17 Dunnett’s 𝑡-distribution, 2-sided: qtf and isf
    def dunnett2_qtf(self, q, k, n, rho, qtf=True):
        return ctxm.dunnett2_qtf(self, q, k, n, rho, qtf)


# 6.4.19 Studentized range distribution: pdf

    def srange_pdf(self, x, k, n):
        return ctxm.srange_pdf(self, x, k, n)

# 6.4.20 Studentized range distribution: cdf and isf
    def srange_cdf(self, x, k, n, cdf=True):
        return ctxm.srange_cdf(self, x, k, n)


# 6.4.21 Studentized range distribution: qtf and isf

    def srange_qtf(self, q, k, n, qtf=True):
        return ctxm.srange_qtf(self, q, k, n, qtf)


# %%%  6.5 Noncentral distribution functions


# 6.5.1 Non-central 𝜒2-distribution, pdf

    def chi_squared_nc_pdf(self, x, n, lambda1, method='default'):
        return ctxm.chi_squared_nc_pdf(self, x, n, lambda1, method)

# 6.5.2 Non-central 𝜒2-distribution, cdf and sf
    def chi_squared_nc_cdf(self, x, n, lambda1, cdf=True, method='default'):
        return ctxm.chi_squared_nc_cdf(self, x, n, lambda1, cdf, method)

##    # Noncentral ch^2-distribution, cdf (Chou1985)
##    def Chi2nc_cdf(self, x, n, lambda1):
##        return ctxm.Chi2nc_cdf(self, x, n, lambda1)

# 6.5.3 Non-central 𝜒2-distribution, qtf and isf
    def chi_squared_nc_qtf(self, q, n, lambda1, qtf=True, method='default'):
        return ctxm.chi_squared_nc_qtf(self, q, n, lambda1, qtf, method)

# 6.5.4 Non-central 𝜒2-distribution: confidence limit for lambda1
    def chi_squared_nc_cl(self, alpha, beta, n, cdfmethod='default'):
        return ctxm.chi_squared_nc_cl(self, alpha, beta, n, cdfmethod)


# 6.5.5 Generalized Marcum 𝑄 function

    def marcumq(self, alpha, beta, n):
        return ctxm.marcumq(self, alpha, beta, n)


# 6.5.6 Noncentral Chi-distribution, pdf

    def chi_nc_pdf(self, x, n, lambda1, method='default'):
        return ctxm.chi_nc_pdf(self, x, n, lambda1, method)

# 6.5.7 Noncentral Chi-distribution, cdf and sf
    def chi_nc_cdf(self, x, n, lambda1, cdf=True, method='default'):
        return ctxm.chi_nc_cdf(self, x, n, lambda1, cdf, method)

# 6.5.8 Noncentral Chi-distribution, qtf and isf
    def chi_nc_qtf(self, q, n, lambda1, qtf=True, method='default'):
        return ctxm.chi_nc_qtf(self, q, n, lambda1, qtf, method)


# 6.5.9 Rice distribution, pdf

    def rice_pdf(self, x, nu, sigma, method='default'):
        return ctxm.rice_pdf(self, x, nu, sigma, method)

# 6.5.10 Rice distribution, cdf and sf
    def rice_cdf(self, x, nu, sigma, cdf=True, method='default'):
        return ctxm.rice_cdf(self, x, nu, sigma, cdf, method)

# 6.5.11 Rice distribution, qtf and isf
    def rice_qtf(self, q, nu, sigma, qtf=True, method='default'):
        return ctxm.rice_qtf(self, q, nu, sigma, qtf, qtf, method)


# 6.5.12 Non-central Student 𝑡 distribution: pdf

    def student_t_nc_pdf(self, x, n, delta, method='default'):
        return ctxm.student_t_nc_pdf(self, x, n, delta, method)

##    # Singly Noncentral t-distribution, sf (Witkovsky2013)
##    def Tdisnc_pdf(self, x, n, delta):
##        return ctxm.Tdisnc_pdf(self, x, n, delta)


# 6.5.13 Non-central Student 𝑡 distribution: cdf and sf

    def student_t_nc_cdf(self, x, n, delta, method='default'):
        return ctxm.student_t_nc_cdf(self, x, n, delta, method)

##    # Singly Noncentral t-distribution, cdf (Witkovsky2013)
##    def Tdisnc_cdf(self, x, n, delta):
##        return ctxm.Tdisnc_cdf(self, x, n, delta)
##
##    # Singly Noncentral t-distribution, sf (Witkovsky2013)
##    def Tdisnc_sf(self, x, n, delta):
##        return ctxm.Tdisnc_sf(self, x, n, delta)


# 6.5.14 Non-central Student 𝑡 distribution, qtf and isf

    def student_t_nc_qtf(self, q, n, delta, qtf=True, method='default'):
        return ctxm.student_t_nc_qtf(self, q, n, delta, qtf, method)


# 6.5.15 Non-central Student 𝑡 distribution,: confidence limit for 𝛿

    def student_t_nc_cl(self, alpha, beta, n, cdfmethod='default'):
        return ctxm.student_t_nc_cl(self, alpha, beta, n, cdfmethod)


# 6.5.16 Non-central Pearson’s rho distribution: pdf

    def pearson_rho_nc_pdf(self, r, N, rho, method='default'):
        return ctxm.pearson_rho_nc_pdf(self, r, N, rho, method)


# 6.5.17 Non-central Pearson’s rho distribution: cdf and sf

    def pearson_rho_nc_cdf(self, r, N, rho, cdf=True, method='default'):
        return ctxm.pearson_rho_nc_cdf(self, r, N, rho, cdf, method)


# 6.5.18 Non-central Pearson’s rho distribution: qtf and isf

    def pearson_rho_nc_qtf(self, q, N, rho, qtf=True, method='default'):
        return ctxm.pearson_rho_nc_qtf(self, q, N, rho, qtf, method)


# 6.5.19 Non-central Pearson’s rho distribution: confidence limit for 𝜌

    def pearson_rho_nc_cl(self, alpha, beta, N, cdfmethod='default'):
        return ctxm.pearson_rho_nc_cl(self, alpha, beta, N, cdfmethod)


# 6.5.20 Pearson’s rho: unbiased estimate of 𝜌

    def pearson_rho_nc_unbiased_estimate(self, r, N):
        return ctxm.pearson_rho_nc_unbiased_estimate(self, r, N)


# 6.5.21 Non-central Fisher 𝐹 distribution: pdf

    def fisher_f_nc_pdf(self, x, m, n, lambda1, method='default'):
        return ctxm.fisher_f_nc_pdf(self, x, m, n, lambda1, method)

##    # Singly Noncentral F-distribution, pdf (Chou1985)
##
##    def Fdisnc_pdf(self, x, m, n, lambda1):
##        return ctxm.Fdisnc_pdf(self, x, m, n, lambda1)


# 6.5.22 Non-central Fisher 𝐹 distribution: cdf and sf

    def fisher_f_nc_cdf(self, x, m, n, lambda1, cdf=True, method='default'):
        return ctxm.fisher_f_nc_cdf(self, x, m, n, lambda1, cdf, method)

##    # Singly Noncentral F-distribution, cdf (Chou1985)
##    def Fdisnc_cdf(self, x, m, n, lambda1):
##        return ctxm.Fdisnc_cdf(self, x, m, n, lambda1)
##
##    # Singly Noncentral F-distribution, cdf2 (Chou1985)
##    def Fdisnc_cdf2(self, x, m, n, lambda1):
##        return ctxm.Fdisnc_cdf2(self, x, m, n, lambda1)
##
##    # Singly Noncentral F-distribution, sf (Chou1985)
##
##    def Fdisnc_sf(self, x, m, n, lambda1):
##        return ctxm.Fdisnc_sf(self, x, m, n, lambda1)


# 6.5.23 Non-central Fisher 𝐹 distribution: qtf and isf

    def fisher_f_nc_qtf(self, q, m, n, lambda1, qtf=True, method='default'):
        return ctxm.fisher_f_nc_qtf(self, q, m, n, lambda1, qtf, method)


# 6.5.24 Non-central Fisher 𝐹 distribution: confidence limit for 𝜆1

    def fisher_f_nc_cl(self, alpha, beta, m, n, cdfmethod='default'):
        return ctxm.fisher_f_nc_cl(self, alpha, beta, m, n, cdfmethod)


# 6.5.25 Non-central Beta distribution: pdf

    def beta_nc_pdf(self, x, a, b, lambda1, method='default'):
        return ctxm.beta_nc_pdf(self, x, a, b, lambda1, method)


# 6.5.26 Non-central Beta distribution: cdf and sf

    def beta_nc_cdf(self, x, a, b, lambda1, cdf=True, method='default'):
        return ctxm.beta_nc_cdf(self, x, a, b, lambda1, cdf, method)


# 6.5.27 Non-central Beta distribution: qtf and isf

    def beta_nc_qtf(self, q, a, b, lambda1, cdf=True, method='default'):
        return ctxm.beta_nc_qtf(self, q, a, b, lambda1, cdf, method)


# 6.5.28 Non-central Beta distribution: confidence limit for 𝜆1

    def beta_nc_cl(self, alpha, beta, a, b, cdfmethod='default'):
        return ctxm.beta_nc_cl(self, alpha, beta, a, b, cdfmethod)


# 6.5.29 Fisher’s 𝑅2 distribution: pdf

    def fisher_r2_pdf(self, x, p, N, rho2, typeI=True, method='default'):
        return ctxm.fisher_r2_pdf(self, x, p, N, rho2, typeI, method)

    # Singly Noncentral Fisher R2-distribution, pdf (Chou1985)
    def fisher_r2_pdf2_(self, x, p, N, rho2):
        return ctxm.fisher_r2_pdf(self, x, p, N, rho2)


# 6.5.30 Fisher’s 𝑅2 distribution: cdf and sf

    def fisher_r2_cdf(self, x, p, N, rho2, cdf=True, typeI=True, method='default'):
        return ctxm.fisher_r2_cdf(self, x, p, N, rho2, cdf, typeI, method)


# 6.5.31 Fisher’s 𝑅2 distribution: qtf and isf

    def fisher_r2_qtf(self, q, p, N, rho2, qtf=True, typeI=True, method='default'):
        return ctxm.fisher_r2_qtf(self, q, p, N, rho2, qtf, typeI, method)


# 6.5.32 Fisher’s 𝑅2 distribution: confidence limit for 𝜌2

    def fisher_r2_cl(self, alpha, beta, p, N, cdfmethod='default'):
        return ctxm.fisher_r2_cl(self, alpha, beta, p, N, cdfmethod)


# 6.5.33 Fisher’s 𝑅2: unbiased estimate of rho^2

    def fisher_r2_unbiased_estimate(self, R, p, N):
        return ctxm.fisher_r2_unbiased_estimate(self, R, p, N)


# 6.5.34 Doubly non-central Student 𝑡 distribution: pdf

    def student_t_nc2_pdf(self, x, n, delta, theta, method='default'):
        return ctxm.student_t_nc2_pdf(self, x, n, delta, theta, method)

##    # Doubly Noncentral t-distribution, pdf (Witkovsky2013)
##    def Tdisnc2_pdf(self, x, n, delta, theta):
##        return ctxm.Tdisnc2_pdf(self, x, n, delta, theta)


# 6.5.35 Doubly non-central Student 𝑡 distribution: cdf and sf

    def student_t_nc2_cdf(self, x, n, delta, theta, cdf=True, method='default'):
        return ctxm.student_t_nc2_cdf(self, x, n, delta, theta, cdf, method)

##    # Doubly Noncentral t-distribution, cdf (Witkovsky2013)
##    def Tdisnc2_cdf(self, x, n, delta, theta):
##        return ctxm.Tdisnc2_cdf(self, x, n, delta, theta)


# 6.5.36 Doubly noncentral Student 𝑡 distribution, qtf and isf

    def student_t_nc2_qtf(self, x, n, delta, theta, qtf=True, method='default'):
        return ctxm.student_t_nc2_qtf(self, x, n, delta, theta, qtf, method)


# 6.5.37 Doubly noncentral Student 𝑡 distribution,: confidence limit for 𝛿

    def student_t_nc2_cl(self, alpha, beta, n, theta, cdfmethod='default'):
        return ctxm.student_t_nc2_cl(self, alpha, beta, n, theta, cdfmethod)


# 6.5.38 Doubly non-central Fisher 𝐹 distribution: pdf

    def fisher_f_nc2_pdf(self, x, m, n, lambda1, lambda2, method='default'):
        return ctxm.fisher_f_nc2_pdf(self, x, m, n, lambda1, lambda2, method)

##    # Doubly Noncentral F-distribution, cdf (Chou1985)
##    def Fdisnc2_pdf(self, x, m, n, lambda1, lambda2):
##        return ctxm.Fdisnc2_pdf(self, x, m, n, lambda1, lambda2)


# 6.5.39 Doubly non-central Fisher 𝐹 distribution: cdf and sf

    def fisher_f_nc2_cdf(self, x, m, n, lambda1, lambda2, cdf=True, method='default'):
        return ctxm.fisher_f_nc2_cdf(self, x, m, n, lambda1, lambda2, cdf, method)

##    # Doubly Noncentral F-distribution, cdf (Chou1985)
##    def Fdisnc2_cdf(self, x, m, n, lambda1, lambda2):
##        return ctxm.Fdisnc2_cdf(self, x, m, n, lambda1, lambda2)


# 6.5.40 Doubly noncentral Fisher 𝐹 distribution, qtf and isf

    def fisher_f_nc2_qtf(self, q, m, n, lambda1, lambda2, qtf=True, method='default'):
        return ctxm.fisher_f_nc2_qtf(self, q, m, n, lambda1, lambda2, qtf, method)


# 6.5.41 Doubly noncentral Fisher 𝐹 distribution: confidence limit for lambda1

    def fisher_f_nc2_cl(self, alpha, beta, m, n, lambda2, cdfmethod='default'):
        return ctxm.fisher_f_nc2_cl(self, alpha, beta, m, n, lambda2, cdfmethod)


# 6.5.42 Non-central Wilks’ Λ distribution: MANOVA, pdf

    def wilks_lambda_glm_pdf(self, x, p, m, n, Omega, method='default'):
        return ctxm.wilks_lambda_glm_pdf(self, x, p, m, n, Omega, method)


# 6.5.43 Non-central Wilks’ Λ distribution: MANOVA, cdf and sf

    def wilks_lambda_glm_cdf(self, x, p, m, n, Omega, cdf=True, method='default'):
        return ctxm.wilks_lambda_glm_cdf(self, x, p, m, n, Omega, cdf, method)


# 6.5.44 Non-central Wilks’ Λ distribution: MANOVA, cdf and sf

    def wilks_lambda_glm_qtf(self, x, p, m, n, Omega, qtf=True, method='default'):
        return ctxm.wilks_lambda_glm_qtf(self, x, p, m, n, Omega, qtf, method)


# 6.5.45 Non-central Wilks’ Λ distribution: Independence, pdf

    def wilks_lambda_ind_pdf(self, x, p1, p2, n, Rho2, method='default'):
        return ctxm.wilks_lambda_ind_pdf(self, x, p1, p2, n, Rho2, method)


# 6.5.46 Non-central Wilks’ Λ distribution: Independence, cdf and sf

    def wilks_lambda_ind_cdf(self, x, p1, p2, n, Rho2, cdf=True, method='default'):
        return ctxm.wilks_lambda_ind_cdf(self, x, p1, p2, n, Rho2, cdf, method)


# 6.5.47 Non-central Wilks’ Λ distribution: Independence, cdf and sf

    def wilks_lambda_ind_qtf(self, x, p1, p2, n, Rho2, qtf=True, method='default'):
        return ctxm.wilks_lambda_ind_qtf(self, x, p1, p2, n, Rho2, qtf, method)


# %%%  6.6 Miscellaneous continuous distributions


# 6.6.1 Lévy alpha-stable distribution, pdf

    def levy_alphastable_pdf(self, a, b, n):
        return ctxm.levy_alphastable_pdf(self, a, b, n)

# 6.6.2 Lévy alpha-stable distribution, cdf and sf
    def levy_alphastable_cdf(self, a, b, n):
        return ctxm.levy_alphastable_pdf(self, a, b, n)

# 6.6.3 Lévy alpha-stable distribution, qtf and isf
    def levy_alphastable_qtf(self, a, b, n):
        return ctxm.levy_alphastable_pdf(self, a, b, n)


# 6.6.4 Landau distribution, pdf

    def landau_pdf(self, a, b, n):
        return ctxm.landau_pdf(self, a, b, n)

# 6.6.5 Landau distribution, cdf and sf
    def landau_cdf(self, a, b, n):
        return ctxm.landau_cdf(self, a, b, n)

# 6.6.6 Landau distribution, qtf and isf
    def landau_qtf(self, a, b, n):
        return ctxm.landau_qtf(self, a, b, n)


# 6.6.7 Voigt Profile distribution, pdf

    def voigt_profile_pdf(self, a, b, n):
        return ctxm.voigt_profile_pdf(self, a, b, n)

# 6.6.8 Voigt Profile distribution, cdf and sf
    def voigt_profile_cdf(self, a, b, n):
        return ctxm.voigt_profile_cdf(self, a, b, n)

# 6.6.9 Voigt Profile distribution, qtf and isf
    def voigt_profile_qtf(self, a, b, n):
        return ctxm.voigt_profile_qtf(self, a, b, n)


# 6.6.10 Pearson Type IV distribution, pdf

    def pearson_type4_pdf(self, a, b, n):
        return ctxm.pearson_type4_pdf(self, a, b, n)

# 6.6.11 Pearson Type IV distribution, cdf and sf
    def pearson_type4_cdf(self, a, b, n):
        return ctxm.pearson_type4_cdf(self, a, b, n)

# 6.6.12 Pearson Type IV distribution, qtf and isf
    def pearson_type4_qtf(self, a, b, n):
        return ctxm.pearson_type4_qtf(self, a, b, n)


# 6.6.13 von Mises distribution, pdf

    def von_mises_pdf(self, a, b, n):
        return ctxm.von_mises_pdf(self, a, b, n)

# 6.6.14 von Mises distribution, cdf and sf
    def von_mises_cdf(self, a, b, n):
        return ctxm.von_mises_cdf(self, a, b, n)

# 6.6.15 von Mises distribution, qtf and isf
    def von_mises_qtf(self, a, b, n):
        return ctxm.von_mises_qtf(self, a, b, n)


# 6.6.16 Generalized inverse Gaussian distribution, pdf

    def gen_inv_gaussian_pdf(self, a, b, n):
        return ctxm.gen_inv_gaussian_pdf(self, a, b, n)

# 6.6.17 Generalized inverse Gaussian distribution, cdf and sf
    def gen_inv_gaussian_cdf(self, a, b, n):
        return ctxm.gen_inv_gaussian_cdf(self, a, b, n)

# 6.6.18 Generalized inverse Gaussian distribution, qtf and isf
    def gen_inv_gaussian_qtf(self, a, b, n):
        return ctxm.gen_inv_gaussian_qtf(self, a, b, n)


# 6.6.19 Harmonic distribution, pdf

    def harmonic_pdf(self, a, b, n):
        return ctxm.harmonic_pdf(self, a, b, n)

# 6.6.20 Harmonic distribution, cdf and sf
    def harmonic_cdf(self, a, b, n):
        return ctxm.harmonic_cdf(self, a, b, n)

# 6.6.21 Harmonic distribution, qtf and isf
    def harmonic_qtf(self, a, b, n):
        return ctxm.harmonic_qtf(self, a, b, n)


# 6.6.22 Halphen A distribution, pdf

    def halphen_a_pdf(self, a, b, n):
        return ctxm.halphen_a_pdf(self, a, b, n)

# 6.6.23 Halphen A distribution, cdf and sf
    def halphen_a_cdf(self, a, b, n):
        return ctxm.halphen_a_cdf(self, a, b, n)

# 6.6.24 Halphen A distribution, qtf and isf
    def halphen_a_qtf(self, a, b, n):
        return ctxm.halphen_a_qtf(self, a, b, n)


# 6.6.25 Halphen B distribution, pdf

    def halphen_b_pdf(self, a, b, n):
        return ctxm.halphen_b_qtf(self, a, b, n)

# 6.6.26 Halphen B distribution, cdf and sf
    def halphen_b_cdf(self, a, b, n):
        return ctxm.halphen_b_qtf(self, a, b, n)

# 6.6.27 Halphen B distribution, qtf and isf
    def halphen_b_qtf(self, a, b, n):
        return ctxm.halphen_b_qtf(self, a, b, n)


# 6.6.28 Halphen IB distribution, pdf

    def halphen_ib_pdf(self, a, b, n):
        return ctxm.halphen_ib_qtf(self, a, b, n)

# 6.6.29 Halphen IB distribution, cdf and sf
    def halphen_ib_cdf(self, a, b, n):
        return ctxm.halphen_ib_qtf(self, a, b, n)

# 6.6.30 Halphen IB distribution, qtf and isf
    def halphen_ib_qtf(self, a, b, n):
        return ctxm.halphen_ib_qtf(self, a, b, n)


# 6.6.31 Generalized hyperbolic distribution, pdf

    def gen_hyperbolic_pdf(self, a, b, n):
        return ctxm.gen_hyperbolic_pdf(self, a, b, n)

# 6.6.32 Generalized hyperbolic distribution, cdf and sf
    def gen_hyperbolic_cdf(self, a, b, n):
        return ctxm.gen_hyperbolic_cdf(self, a, b, n)

# 6.6.33 Generalized hyperbolic distribution, qtf and isf
    def gen_hyperbolic_qtf(self, a, b, n):
        return ctxm.gen_hyperbolic_qtf(self, a, b, n)


# 6.6.34 Hyperbolic distribution, pdf

    def hyperbolic_pdf(self, a, b, n):
        return ctxm.hyperbolic_pdf(self, a, b, n)

# 6.6.35 Hyperbolic distribution, cdf and sf
    def hyperbolic_cdf(self, a, b, n):
        return ctxm.hyperbolic_cdf(self, a, b, n)

# 6.6.36 Hyperbolic distribution, qtf and isf
    def hyperbolic_qtf(self, a, b, n):
        return ctxm.hyperbolic_qtf(self, a, b, n)


# 6.6.37 Variance-gamma distribution, pdf

    def variance_gamma_pdf(self, a, b, n):
        return ctxm.variance_gamma_pdf(self, a, b, n)

# 6.6.38 Variance-gamma distribution, cdf and sf
    def variance_gamma_cdf(self, a, b, n):
        return ctxm.variance_gamma_cdf(self, a, b, n)

# 6.6.39 Variance-gamma distribution, qtf and isf
    def variance_gamma_qtf(self, a, b, n):
        return ctxm.variance_gamma_qtf(self, a, b, n)


# %% 7 Discrete distribution functions

# %%%  7.1 Elementary discrete (lattice) distribution functions


# 7.1.1 Geometric distribution, pmf

    def geometric_pmf(self, k, p):
        return ctxm.geometric_pmf(self, k, p)

# 7.1.2 Geometric distribution, cdf and sf
    def geometric_cdf(self, k, p, cdf=True):
        return ctxm.geometric_cdf(self, k, p, cdf)

# 7.1.3 Geometric distribution, qtf and isf
    def geometric_qtf(self, prob, p, qtf=True):
        return ctxm.geometric_qtf(self, prob, p, qtf)


# 7.1.4 Log-series distribution, pmf

    def logseries_pmf(self, k, lambda1):
        return ctxm.logseries_pmf(self, k, lambda1)

# 7.1.5 Log-series distribution, cdf and sf
    def logseries_cdf(self, k, lambda1, cdf=True, **kwargs):
        return ctxm.logseries_cdf(self, k, lambda1, cdf)

# 7.1.6 Log-series distribution, qtf and isf
    def logseries_qtf(self, prob, lambda1, qtf=True, **kwargs):
        return ctxm.logseries_qtf(self, prob, lambda1, qtf)


# 7.1.7 Poisson distribution, pmf

    def poisson_pmf(self, k, lambda1):
        return ctxm.poisson_pmf(self, k, lambda1)

# 7.1.8 Poisson distribution, cdf and sf
    def poisson_cdf(self, k, lambda1, cdf=True, **kwargs):
        return ctxm.poisson_cdf(self, k, lambda1, cdf, **kwargs)

# 7.1.9 Poisson distribution, qtf and isf
    def poisson_qtf(self, prob, lambda1, qtf=True, **kwargs):
        return ctxm.poisson_qtf(self, prob, lambda1, qtf, **kwargs)


# 7.1.10 Skellam distribution, pmf

    def skellam_pmf(self, k, lambda1):
        return ctxm.skellam_pmf(self, k, lambda1)

# 7.1.11 Skellam distribution, cdf and sf
    def skellam_cdf(self, k, lambda1, cdf=True, **kwargs):
        return ctxm.skellam_cdf(self, k, lambda1, cdf)

# 7.1.12 Skellam distribution, qtf and isf
    def skellam_qtf(self, prob, lambda1, qtf=True, **kwargs):
        return ctxm.skellam_qtf(self, prob, lambda1, qtf)


# 7.1.13 Binomial distribution, pmf

    def binomial_pmf(self, k, n, p):
        return ctxm.binomial_pmf(self, k, n, p)

# 7.1.14 Binomial distribution, cdf and sf
    def binomial_cdf(self, k, n, p, cdf=True, **kwargs):
        return ctxm.binomial_cdf(self, k, n, p, cdf, **kwargs)

# 7.1.15 Binomial distribution, qtf and isf
    def binomial_qtf(self, prob, n, p, qtf=True, **kwargs):
        return ctxm.binomial_qtf(self, prob, n, p, qtf, **kwargs)


# 7.1.16 Negative binomial (gamma-Poisson) distribution, pmf

    def negbinom_pmf(self, k, r, p):
        return ctxm.negbinom_pmf(self, k, r, p)

# 7.1.17 Negative binomial (gamma-Poisson) distribution, cdf and sf
    def negbinom_cdf(self, k, r, p, cdf=True, **kwargs):
        return ctxm.negbinom_cdf(self, k, r, p, cdf, **kwargs)

# 7.1.18 Negative binomial (gamma-Poisson) distribution, qtf and isf
    def negbinom_qtf(self, prob, r, p, qtf=True, **kwargs):
        return ctxm.negbinom_qtf(self, prob, r, p, qtf, **kwargs)


# 7.1.19 Delaporte distribution, pmf

    def delaporte_pmf(self, x, r, n, NN):
        return ctxm.delaporte_pmf(self, x, r, n, NN)

# 7.1.20 Delaporte distribution, cdf and sf
    def delaporte_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.delaporte_cdf(self, x, r, n, NN, cdf)

# 7.1.21 Delaporte distribution, qtf and isf
    def delaporte_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.delaporte_qtf(self, prob, r, n, NN, qtf)


# 7.1.22 Beta-Poisson distribution (Quinkert), pmf

    def betapoisson_pmf(self, x, r, n, NN):
        return ctxm.betapoisson_pmf(self, x, r, n, NN)

# 7.1.23 Beta-Poisson distribution (Quinkert), cdf and sf
    def betapoisson_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.betapoisson_cdf(self, x, r, n, NN, cdf)

# 7.1.24 Beta-Poisson distribution (Quinkert), qtf and isf
    def betapoisson_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.betapoisson_qtf(self, prob, r, n, NN, qtf)


# 7.1.25 Beta-binomial distribution, pmf

    def betabinom_pmf(self, x, r, n, NN):
        return ctxm.betabinom_pmf(self, x, r, n, NN)

# 7.1.26 Beta-binomial distribution, cdf and sf
    def betabinom_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.betabinom_cdf(self, x, r, n, NN, cdf)

# 7.1.27 Beta-binomial distribution, qtf and isf
    def betabinom_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.betabinom_qtf(self, prob, r, n, NN, qtf)


# 7.1.28 Beta-negative binomial distribution (Waring), pmf

    def beta_negbinom_pmf(self, x, r, n, NN):
        return ctxm.beta_negbinom_pmf(self, x, r, n, NN)

# 7.1.29 Beta-negative binomial distribution (Waring), cdf and sf
    def beta_negbinom_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.beta_negbinom_cdf(self, x, r, n, NN, cdf)

# 7.1.30 Beta-negative binomial distribution (Waring), qtf and isf
    def beta_negbinom_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.beta_negbinom_qtf(self, prob, r, n, NN, qtf)


# 7.1.31 Classical hypergeometric distribution, pmf

    def hypergeo_pmf(self, x, r, n, NN):
        return ctxm.hypergeo_pmf(self, x, r, n, NN)

# 7.1.32 Classical hypergeometric distribution, cdf and sf
    def hypergeo_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.hypergeo_cdf(self, x, r, n, NN, cdf)

# 7.1.33 Classical hypergeometric distribution, qtf and isf
    def hypergeo_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.hypergeo_qtf(self, prob, r, n, NN, qtf)


# 7.1.34 Negative hypergeometric distribution, pmf

    def neghypergeo_pmf(self, x, r, n, NN):
        return ctxm.neghypergeo_pmf(self, x, r, n, NN)

# 7.1.35 Negative hypergeometric distribution, cdf and sf
    def neghypergeo_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.neghypergeo_cdf(self, x, r, n, NN, cdf)

# 7.1.36 Negative hypergeometric distribution, qtf and isf
    def neghypergeo_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.neghypergeo_qtf(self, prob, r, n, NN, qtf)


# 7.1.37 Pólya-Eggenberger distribution, pmf

    def polya_pmf(self, x, r, n, NN):
        return ctxm.polya_pmf(self, x, r, n, NN)

# 7.1.38 Pólya-Eggenberger distribution, cdf and sf
    def polya_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.polya_cdf(self, x, r, n, NN, cdf)

# 7.1.39 Pólya-Eggenberger distribution, qtf and isf
    def polya_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.polya_qtf(self, prob, r, n, NN, qtf)


# 7.1.40 General hypergeometric distribution, pmf

    def genhypergeo_pmf(self, x, r, n, NN):
        return ctxm.genhypergeo_pmf(self, x, r, n, NN)

# 7.1.41 General hypergeometric distribution, cdf and sf
    def genhypergeo_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.genhypergeo_cdf(self, x, r, n, NN, cdf)

# 7.1.42 General hypergeometric distribution, qtf and isf
    def genhypergeo_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.genhypergeo_qtf(self, prob, r, n, NN, qtf)


# 7.1.43 Noncentral hypergeometric distribution (Fisher alternatives), pmf

    def hypergeo_nc_pmf(self, x, r, n, NN):
        return ctxm.hypergeo_nc_pmf(self, x, r, n, NN)

# 7.1.44 Noncentral hypergeometric distribution (Fisher alternatives), cdf and sf
    def hypergeo_nc_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.hypergeo_nc_cdf(self, x, r, n, NN, cdf)

# 7.1.45 Noncentral hypergeometric distribution (Fisher alternatives), qtf and isf
    def hypergeo_nc_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.hypergeo_nc_qtf(self, prob, r, n, NN, qtf)


# 7.1.46 Zeta distribution, pmf

    def zeta_pmf(self, k, p):
        return ctxm.zeta_pmf(self, k, p)

# 7.1.47 Zeta distribution, cdf and sf
    def zeta_cdf(self,  k, p, cdf=True):
        return ctxm.zeta_cdf(self,  k, p, cdf)

# 7.1.48 Zeta distribution, qtf and isf
    def zeta_qtf(self, prob, p, qtf=True):
        return ctxm.zeta_qtf(self, prob, p, qtf)


# %%%  7.2 Discrete (lattice) distribution functions related to (stratified) rank tests


# 7.2.1 Wilcoxon 𝑇 distribution, pmf

    def wilcoxon_pmf(self, x, N):
        return ctxm.wilcoxon_pmf(self, x, N)

# 7.2.2 Wilcoxon 𝑇 distribution, cdf and sf
    def wilcoxon_cdf(self, x, N, cdf=True):
        return ctxm.wilcoxon_cdf(self, x, N, cdf)

# 7.2.3 Wilcoxon 𝑇 distribution, qtf and isf
    def wilcoxon_qtf(self, prob, N, qtf=True):
        return ctxm.wilcoxon_qtf(self, prob, N, qtf)


# 7.2.4 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, pmf

    def wilcoxon_nc_bennett_pmf(self, x, r, n, NN):
        return ctxm.wilcoxon_nc_bennett_pmf(self, x, r, n, NN)

# 7.2.5 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, cdf and sf
    def wilcoxon_nc_bennett_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.wilcoxon_nc_bennett_cdf(self, x, r, n, NN, cdf)

# 7.2.6 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, qtf and isf
    def wilcoxon_nc_bennett_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.wilcoxon_nc_bennett_qtf(self, prob, r, n, NN, qtf)


# 7.2.7 Mann-Whitney 𝑈 distribution, pmf

    def mannwhitney_pmf(self, x, r, n, NN):
        return ctxm.mannwhitney_pmf(self, x, r, n, NN)

# 7.2.8 Mann-Whitney 𝑈 distribution, cdf and sf
    def mannwhitney_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.mannwhitney_cdf(self, x, r, n, NN, cdf)

# 7.2.9 Mann-Whitney 𝑈 distribution, qtf and isf
    def mannwhitney_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.mannwhitney_qtf(self, prob, r, n, NN, qtf)


# 7.2.10 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, pmf

    def mannwhitney_nc_lehmann_pmf(self, x, r, n, NN):
        return ctxm.mannwhitney_nc_lehmann_pmf(self, x, r, n, NN)

# 7.2.11 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, cdf and sf
    def mannwhitney_nc_lehmann_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.mannwhitney_nc_lehmann_cdf(self, x, r, n, NN, cdf)

# 7.2.12 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, qtf and isf
    def mannwhitney_nc_lehmann_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.mannwhitney_nc_lehmann_qtf(self, prob, r, n, NN, qtf)


# 7.2.13 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, pmf

    def mannwhitney_nc_milton_pmf(self, x, r, n, NN):
        return ctxm.mannwhitney_nc_milton_pmf(self, x, r, n, NN)

# 7.2.14 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, cdf and sf
    def mannwhitney_nc_milton_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.mannwhitney_nc_milton_cdf(self, x, r, n, NN, cdf)

# 7.2.15 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, qtf and isf
    def mannwhitney_nc_milton_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.mannwhitney_nc_milton_qtf(self, prob, r, n, NN, qtf)


# 7.2.16 Kendall’s 𝑆 (or 𝜏 ) distribution, pmf

    def kendall_tau_pmf(self, x, r, n, NN):
        return ctxm.kendall_tau_pmf(self, x, r, n, NN)

# 7.2.17 Kendall’s 𝑆 (or 𝜏 ) distribution, cdf and sf
    def kendall_tau_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.kendall_tau_cdf(self, x, r, n, NN, cdf)

# 7.2.18 Kendall’s 𝑆 (or 𝜏 ) distribution, qtf and isf
    def kendall_tau_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.kendall_tau_qtf(self, prob, r, n, NN, qtf)


# 7.2.19 Jonckheere-Terpsta 𝑆 distribution, pmf

    def jterpsta_s_pmf(self, x, r, n, NN):
        return ctxm.jterpsta_s_pmf(self, x, r, n, NN)

# 7.2.20 Jonckheere-Terpsta 𝑆 distribution, cdf and sf
    def jterpsta_s_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.jterpsta_s_cdf(self, x, r, n, NN, cdf)

# 7.2.21 Jonckheere-Terpsta 𝑆 distribution, qtf and isf
    def jterpsta_s_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.jterpsta_s_qtf(self, prob, r, n, NN, qtf)


# 7.2.22 Generalized Page 𝐿 distribution, pmf

    def page_l_pmf(self, x, r, n, NN):
        return ctxm.page_l_pmf(self, x, r, n, NN)

# 7.2.23 Generalized Page 𝐿 distribution, cdf and sf
    def page_l_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.page_l_cdf(self, x, r, n, NN, cdf)

# 7.2.24 Generalized Page 𝐿 distribution, qtf and isf
    def page_l_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.page_l_qtf(self, prob, r, n, NN, qtf)


# 7.2.25 Noncentral generalized Page 𝐿 distribution, Milton alternatives, pmf

    def page_l_nc_milton_pmf(self, x, r, n, NN):
        return ctxm.page_l_nc_milton_pmf(self, x, r, n, NN)

# 7.2.26 Noncentral generalized Page 𝐿 distribution, Milton alternatives, cdf and sf
    def page_l_nc_milton_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.page_l_nc_milton_cdf(self, x, r, n, NN, cdf)

# 7.2.27 Noncentral generalized Page 𝐿 distribution, Milton alternatives, qtf and isf
    def page_l_nc_milton_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.page_l_nc_milton_qtf(self, prob, r, n, NN, qtf)


# %%%  7.3 Discrete (non-lattice) distribution functions related to rank tests


# 7.3.1 Cochran-Friedman-Quade distribution, pmf

    def friedman_pmf(self, x, r, n, NN):
        return ctxm.friedman_pmf(self, x, r, n, NN)

# 7.3.2 Cochran-Friedman-Quade distribution, cdf and sf
    def friedman_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.friedman_cdf(self, x, r, n, NN, cdf)

# 7.3.3 Cochran-Friedman-Quade distribution, qtf and isf
    def friedman_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.friedman_qtf(self, prob, r, n, NN, qtf)


# 7.3.4 Kruskal-Wallis distribution, pmf

    def kruskal_wallis_pmf(self, x, r, n, NN):
        return ctxm.kruskal_wallis_pmf(self, x, r, n, NN)

# 7.3.5 Kruskal-Wallis distribution, cdf and sf
    def kruskal_wallis_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.kruskal_wallis_cdf(self, x, r, n, NN, cdf)

# 7.3.6 Kruskal-Wallis distribution, qtf and isf
    def kruskal_wallis_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.kruskal_wallis_qtf(self, prob, r, n, NN, qtf)


# %% 8 Pmf vectors, sums and integrals


# %%%  8.1 Recursive generation of pmf vectors for selected discrete distributions


# 8.1.1 Poisson distribution, pmf vector

    def poisson_pmf_vector(self, N):
        return ctxm.poisson_pmf_vector(self, N)

# 8.1.2 Binomial distribution, pmf vector
    def binomial_pmf_vector(self, N):
        return ctxm.binomial_pmf_vector(self, N)

# 8.1.3 Negative binomial distribution, pmf vector
    def negbinom_pmf_vector(self, N):
        return ctxm.negbinom_pmf_vector(self, N)

# 8.1.4 Hypergeometric distribution, pmf vector
    def hypergeometric_pmf_vector(self, N):
        return ctxm.hypergeometric_pmf_vector(self, N)


# 8.1.5 Noncentral hypergeometric distribution (Fisher), pmf vector

    def hypergeo_nc_pmf_vector(self, N):
        return ctxm.hypergeo_nc_pmf_vector(self, N)


# 8.1.6 Sign test distribution (under 𝐻0), pmf vector

    def signtest_pmf_vector(self, N):
        return ctxm.signtest_pmf_vector(self, N)


# 8.1.7 Wilcoxon 𝑇 distribution (under 𝐻0), pmf vector

    def wilcoxon_pmf_vector(self, N):
        return ctxm.wilcoxon_pmf_vector(self, N)

    def wilcoxon_full_vector(self, N, cdf=False, show=False, start=None, stop=None):
        return ctxm.wilcoxon_full_vector(self, N, cdf, show, start, stop)


# 8.1.8 Wilcoxon 𝑇 distribution (under Bennett alternatives), pmf vector

    def wilcoxon_bennett_pmf_vector(self, N):
        return ctxm.poisson_pmf_vector(self, N)


# 8.1.9 Kendall 𝑆 (or tau) distribution (under 𝐻0), pmf vector

    def kendall_tau_pmf_vector(self, n):
        return ctxm.kendall_tau_pmf_vector(self, n)

    def kendall_full_vector(self, N, cdf=False, show=False, start=None, stop=None):
        return ctxm.kendall_full_vector(self, N, cdf, show, start, stop)


# 8.1.10 Mann-Whitney 𝑈 distribution (under 𝐻0), pmf vector

    def mann_whitney_u_pmf_vector(self, m, n):
        return ctxm.mann_whitney_u_pmf_vector(self, m, n)


# 8.1.11 Mann-Whitney 𝑈 distribution (under Lehmann alternatives), pmf vector

    def mannwhitney_u_lehmann_pmf_vector(self, m, n):
        return ctxm.mannwhitney_u_lehmann_pmf_vector(self, m, n)


# 8.1.12 Mann-Whitney 𝑈 distribution (under Milton alternatives), pmf vector

    def mannwhitney_u_milton_pmf_vector(self, m, n):
        return ctxm.mannwhitney_u_milton_pmf_vector(self, m, n)


# 8.1.13 Jonckheere-Terpsta 𝑆 distribution (under 𝐻0), pmf vector

    def jterpsta_s_pmf_vector(self, k, n):
        return ctxm.jterpsta_s_pmf_vector(self, k, n)


# 8.1.14 Spearman 𝜌 distribution (under 𝐻0), pmf vector

    def spearman_rho_pmf_vector(self, k, Order):
        return ctxm.spearman_rho_pmf_vector(self, k, Order)


# 8.1.15 Page 𝐿 distribution (under 𝐻0), pmf vector

    def page_l_pmf_vector(self, k, n):
        return ctxm.page_l_pmf_vector(self, k, n)


# 8.1.16 Quade 𝐿 distribution (under 𝐻0), pmf vector

    def quade_l_pmf_vector(self, k, n):
        return ctxm.quade_l_pmf_vector(self, k, n)


# 8.1.17 Cochran 𝑆 distribution (under 𝐻0), pmf vector

    def cochran_s_pmf_vector(self, m, n):
        return ctxm.cochran_s_pmf_vector(self, m, n)


# 8.1.18 Friedman 𝑆 distribution (under 𝐻0), pmf vector

    def friedman_s_pmf_vector(self, m, n):
        return ctxm.friedman_s_pmf_vector(self, m, n)


# 8.1.19 Quade 𝑆 distribution (under 𝐻0), pmf vector

    def quade_s_pmf_vector(self, m, n):
        return ctxm.quade_s_pmf_vector(self, m, n)


# 8.1.20 Kruskal-Wallis 𝐻 distribution (under 𝐻0), pmf vector

    def kruskal_wallis_h_pmf_vector(self, m, n):
        return ctxm.kruskal_wallis_h_pmf_vector(self, m, n)


# %%% 8.2 Finite sums algorithms for selected distributions


# 8.2.1 Central 𝜒2 distribution, cdf (integer degrees of freedom)

    def int_df_chi_squared_cdf(self, x, nu, cdf=True):
        if cdf:
            return ctxm.int_df_chi_squared_cdf(self, x, nu)
        else:
            return 1-ctxm.int_df_chi_squared_cdf(self, x, nu)


# 8.2.2 Central Student 𝑡 distribution, cdf (integer degrees of freedom)

    def int_df_student_t_cdf(self, x, nu, cdf=True):
        if cdf:
            return ctxm.int_df_student_t_cdf(self, x, nu)
        else:
            return 1-ctxm.int_df_student_t_cdf(self, x, nu)


# 8.2.3 Central Fisher 𝐹 distribution, cdf (integer degrees of freedom)

    def int_df_fisher_f_cdf(self, x, m, n, cdf=True):
        if cdf:
            return ctxm.int_df_fisher_f_cdf(self, x, m, n)
        else:
            return 1-ctxm.int_df_fisher_f_cdf(self, x, m, n)


# 8.2.4 Central Beta distribution, cdf (2𝑎 an integer, 2𝑏 an integer)

    def int_df_beta_cdf(self, x, a, b, cdf=True):
        if cdf:
            return ctxm.int_df_beta_cdf(self, x, a, b)
        else:
            return 1-ctxm.int_df_beta_cdf(self, x, a, b)


# 8.2.5 Noncentral 𝜒2 distribution, cdf (integer degrees of freedom)

    def int_df_chi_squared_nc_cdf(self, x, nu, nc, cdf=True):
        if cdf:
            return ctxm.int_df_chi_squared_nc_cdf(self, x, nu, nc)
        else:
            return 1-ctxm.int_df_chi_squared_nc_cdf(self, x, nu, nc)


# 8.2.6 Noncentral Student 𝑡 distribution, cdf (integer degrees of freedom)

    def int_df_student_t_nc_cdf(self, x, nu, nc, cdf=True):
        if cdf:
            return ctxm.int_df_student_t_nc_cdf(self, nu, x, nc)
        else:
            return 1-ctxm.int_df_student_t_nc_cdf(self, nu, x, nc)


# 8.2.7 Noncentral Fisher 𝐹 distribution, cdf (𝑚 an even integer)

    def int_df_fisher_f_nc_cdf(self, x, nu1, nu2, nc, cdf=True):
        if cdf:
            return ctxm.int_df_fisher_f_nc_cdf(self, x, nu1, nu2, nc)
        else:
            return 1-ctxm.int_df_fisher_f_nc_cdf(self, x, nu1, nu2, nc)


# 8.2.8 Noncentral Beta distribution, cdf (𝑏 an integer)

    def int_df_beta_nc_cdf(self, x, a, b, nc, cdf=True):
        if cdf:
            return ctxm.int_df_beta_nc_cdf(self, x, a, b, nc)
        else:
            return 1-ctxm.int_df_beta_nc_cdf(self, x, a, b, nc)


# 8.2.9 Pearson’s 𝜌 distribution, pdf (integer N)

    def int_df_pearson_rho_pdf(self, r, N, rho):
        return ctxm.int_df_pearson_rho_cdf(self, r, N, rho,)


# 8.2.10 Pearson’s 𝜌 distribution, cdf (integer N)

    def int_df_pearson_rho_cdf(self, r, N, rho, cdf=True):
        if cdf:
            return ctxm.int_df_pearson_rho_cdf(self, r, N, rho,)
        else:
            return 1-ctxm.int_df_pearson_rho_cdf(self, r, N, rho,)


# 8.2.11 Fisher’s 𝑅2 distribution, cdf (finite sum for odd 𝑁 − 𝑝)

    def int_df_rsquare_gurland_nc_cdf(self, ctx, x, p, N, Rho2, cdf=True):
        if cdf:
            return ctxm.int_df_rsquare_gurland_nc_cdf(self, ctx, x, p, N, Rho2)
        else:
            return 1-ctxm.int_df_rsquare_gurland_nc_cdf(self, ctx, x, p, N, Rho2)


# %%% 8.3 Infinite sums algorithms for selected functions and distributions


# 8.3.1 Incomplete gamma function, continued fractions (Peizer)

    def real_gamma_p_q_peizer(self, a, x):
        return ctxm.real_gamma_p_q_peizer(self, a, x)


# 8.3.2 Incomplete gamma function, asymptotic expansion (Paris)

    def real_gamma_p_q_paris(self, a, x):
        return ctxm.real_gamma_p_q_paris(self, a, x)


# 8.3.3 Incomplete beta function, continued fractions (Peizer)

    def real_betadis_peizer(self, a, b, q, p):
        return ctxm.real_betadis_peizer(self, a, b, q, p)


# 8.3.4 Noncentral 𝜒2 distribution, pdf, cdf and sf (Boost)

    def chi_squared_nc_boost(self, x, n, lambda1, cdf=True, **options):
        return ctxm.chi_squared_nc_boost(self, x, n, lambda1, cdf)


# 8.3.5 Noncentral Student 𝑡 distribution, pdf, cdf and sf (Boost)

    def student_t_nc_boost(self, x, nu, delta, cdf=True, **options):
        return ctxm.student_t_nc_boost(self, x, nu, delta, cdf=True)


# 8.3.6 Noncentral Beta distribution, pdf, cdf and sf (Boost)

    def beta_nc_boost(self, x, a, b, lambda1):
        return ctxm.beta_nc_boost(self, x, a, b, lambda1)


# 8.3.7 Pearson’s 𝜌 distribution, cdf and sf (Hotelling’s series)

    def pearson_rho_hotelling_cdf(self, r, N, rho):
        return ctxm.pearson_rho_hotelling_cdf(self, r, N, rho)


# 8.3.8 Pearson’s 𝜌 distribution, cdf and sf (Guenther’s series)

    def pearson_rho_guenther_cdf(self, r, N, rho):
        return ctxm.pearson_rho_guenther_cdf(self, r, N, rho)


# 8.3.9 Fisher’s 𝑅2 distribution, pdf (Boost, Benton)

    def fisher_r2_boost_pdf(self, x, p, N, rho2, **options):
        return ctxm.fisher_r2_boost_pdf(self, x, p, N, rho2)


# 8.3.10 Fisher’s 𝑅2 distribution, cdf and sf (Boost, Benton)

    def fisher_r2_boost_cdf(self, x, p, N, rho2, **options):
        return ctxm.fisher_r2_boost_cdf(self, x, p, N, rho2)


# %%% 8.4 Verified numerical integration


# 8.4.2 Error function

    def real_quad_erf(self, x):
        return ctxm.real_quad_erf(self, x)


# 8.4.3 Lower non-normalised incomplete gamma function,

    def real_quad_gamma_lower(self, a, x):
        return ctxm.real_quad_gamma_lower(self, a, x)


# 8.4.4 Real upper non-normalised incomplete gamma function,

    def real_quad_gamma_upper(self, a, x):
        return ctxm.real_quad_gamma_upper(self, a, x)


# 8.4.5 Normalised incomplete beta function,

    def real_quad_ibeta(self, a, b, x):
        return ctxm.real_quad_ibeta(self, a, b, x)


# 8.4.6 Non-central chi-square cdf and sf (Chow)

    def chi_squared_nc_quad_cdf(self, n, x, l):
        return ctxm.chi_squared_nc_quad_cdf(self, n, x, l)


# 8.4.7 Marcum 𝑄 function

    def marcumq_quad(self, a, b):
        b = self.t(b)
        a = self.t(a)
        res = ctxm.marcumq_quad(self, a, b)
        return res


# 8.4.8 Owen’s 𝑇 function

    def owent(self, h, a):
        h = self.t(h)
        a = self.t(a)
        res = ctxm.owent_quad(self, h, a)
        return res


# %%% 8.5 Numerical Fourier transform and its inverse: continuous distributions


# 8.5.1 Central Chi-square: pdf, cdf, sf

    def chi_squared_gp(self):
        return ctxm.chi_squared_gp(self)


# 8.5.2 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_gp(self):
        return ctxm.wilks_lambda_gp(self)


# 8.5.3 Distribution of the product of independent beta variates: pdf, cdf and sf

    def log_beta_prod_gp(self):
        return ctxm.log_beta_prod_gp(self)


# 8.5.4 Box-Davis distribution: pdf, cdf and sf

    def log_box_davis_gp(self):
        return ctxm.log_box_davis_gp(self)


# 8.5.5 Noncentral Chi-square: pdf, cdf, sf

    def chi_squared_nc_gp(self):
        return ctxm.chi_squared_nc_gp(self)


# 8.5.6 Non-central Beta distribution: pdf, cdf and sf

    def log1mbeta_nc_gp(self):
        return ctxm.log1mbeta_nc_gp(self)


# 8.5.7 Fisher’s 𝑅2 distribution: pdf, cdf and sf

    def fisher_log1mr2_gp(self):
        return ctxm.fisher_log1mr2_gp(self)


# 8.5.8 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf and sf

    def wilks_lambda_glm_gp(self):
        return ctxm.wilks_lambda_glm_gp(self)


# 8.5.9 Noncentral Wilks’ Λ distribution: Independence, pdf, cdf and sf

    def wilks_lambda_ind_gp(self):
        return ctxm.wilks_lambda_ind_gp(self)


# %%% 8.6 Numerical Fourier transform and its inverse: discrete distributions


# 8.6.1 Binomial distribution: pmf, cdf, sf

    def binomial_ft(self):
        return ctxm.binomial_ft(self)


# 8.6.2 Wilcoxon distribution: pmf, cdf, sf

    def wilcoxon_ft(self):
        return ctxm.wilcoxon_ft(self)


# %% 9 Asymptotic expansions

# %%% 9.1 Edgeworth and Cornish-Fisher expansions: continuous distributions


#   9.1.1 Edgeworth expansion: general approximation to the pdf, cdf and sf

    def edgeworth(self, x, order, kappa):
        return ctxm.edgeworth(self, x, order, kappa)


#   9.1.2 Cornish-Fisher expansion: general approximation to the qtf and isf

    def cornish_fisher(self, LeftTail, RightTail, kappa, nord):
        result = ctxm.cornish_fisher(self, LeftTail, RightTail, kappa, nord)
        return result

##    def CalcCornish(self, LeftTail, RightTail, mean, sigma, kappa, nord):
##        result = ctxm.CalcCornish(
##            self, LeftTail, RightTail, mean, sigma, kappa, nord)
##        return result


#   9.1.3 Central Chi-square

    def chi_squared_ecf(self, x, n, order, verbose):
        return ctxm.chi_squared_ecf(self, x, n, order, verbose)


#   9.1.4 Chi-squared distribution: qtf and isf

    def chi_squared_ecf_inv(self, L1, R1, n, order, verbose):
        return ctxm.chi_squared_ecf_inv(self, L1, R1, n, order, verbose)

    def chi_squared_cumulants(self, k, df):
        return ctxm.chi_squared_cumulants(self, k, df)


#  9.1.5 Distribution of the logarithm of a 𝜒2 random variable: pdf, cdf and sf

    def logrv_chisquared_ecf(self):
        return ctxm.logrv_chisquared_ecf(self)

#  9.1.6 Distribution of the logarithm of a 𝜒2 random variable: qtf and isf
    def logrv_chisquared_ecf_inv(self):
        return ctxm.logrv_chisquared_ecf_inv(self)


#  9.1.7 Fisher 𝑧 distribution: pdf, cdf and sf

    def fisher_z_ecf(self):
        return ctxm.fisher_z_ecf(self)

#  9.1.8 Fisher 𝑧 distribution: qtf and isf
    def fisher_z_ecf_inv(self):
        return ctxm.fisher_z_ecf_inv(self)


#  9.1.9 Distribution of the negative logarithm of a beta variable: pdf, cdf and sf

    def logrv_beta_ecf_pdf(self):
        return ctxm.logrv_beta_ecf_pdf(self)

#  9.1.10 Distribution of the negative logarithm of a beta variable: qtf and isf
    def logrv_beta_ecf_qtf(self):
        return ctxm.logrv_beta_ecf_qtf(self)


#  9.1.11 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_ecf(self):
        return ctxm.wilks_lambda_ecf(self)

#  9.1.12 Wilks’ Lambda distribution: qtf and isf
    def wilks_lambda_ecf_inv(self):
        return ctxm.wilks_lambda_ecf_inv(self)


#  9.1.13 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def pillai_v_ecf(self):
        return ctxm.pillai_v_ecf(self)

#  9.1.14 Pillai’s 𝑉 distribution: qtf and isf
    def pillai_v_ecf_inv(self):
        return ctxm.pillai_v_ecf_inv(self)

##    def PillaiVMoments(self, k, p, n1, n2):
##        return ctxm.PillaiVMoments(self, k, p, n1, n2)


#  9.1.15 Hotelling’s 𝑇2 distribution: pdf, cdf and sf

    def hotelling_t2_ecf(self):
        return ctxm.hotelling_t2_ecf(self)

#  9.1.16 Hotelling’s 𝑇2 distribution: qtf and isf
    def hotelling_t2_ecf_inv(self):
        return ctxm.hotelling_t2_ecf_inv(self)

##    def HotellingT2Moments(self, k, p, n1, n2):
##        return ctxm.HotellingT2Moments(self, k, p, n1, n2)


#  9.1.17 Distribution of the product of independent beta variates: pdf, cdf and sf

    def beta_product_ecf(self):
        return ctxm.beta_product_ecf(self)

#  9.1.18 Distribution of the product of independent beta variates: qtf and isf
    def beta_product_ecf_inv(self):
        return ctxm.beta_product_ecf_inv(self)


#  9.1.19 Box-Davis distribution (covariance matrices): pdf, cdf and sf

    def box_davis_ecf(self):
        return ctxm.box_davis_ecf(self)

#  9.1.20 Box-Davis distribution (covariance matrices): qtf and isf
    def box_davis_ecf_inv(self):
        return ctxm.box_davis_ecf_inv(self)


#  9.1.21 Noncentral chi-squared distribution: pdf, cdf and sf

    def chi_squared_nc_ecf(self):
        return ctxm.chi_squared_nc_ecf(self)

#  9.1.22 Noncentral chi-squared distribution: qtf and isf
    def chi_squared_nc_ecf_inv(self):
        return ctxm.chi_squared_nc_ecf_inv(self)


#  9.1.23 Noncentral 𝑡-distribution: pdf, cdf and sf

    def student_t_nc_ecf(self):
        return ctxm.student_t_nc_ecf(self)

#  9.1.24 Noncentral 𝑡-distribution: qtf and isf
    def student_t_nc_ecf_inv(self):
        return ctxm.student_t_nc_ecf_inv(self)


#  9.1.25 Noncentral 𝐹-distribution: pdf, cdf and sf

    def fisher_f_nc_ecf(self):
        return ctxm.fisher_f_nc_ecf(self)

#  9.1.26 Noncentral 𝐹-distribution: qtf and isf
    def fisher_f_nc_ecf_inv(self):
        return ctxm.fisher_f_nc_ecf_inv(self)

    def fisher_f_nc_moments(self, k, n1, n2, lambda1):
        return ctxm.fisher_f_nc_moments(self, k, n1, n2, lambda1)


#  9.1.27 Doubly noncentral 𝑡-distribution: pdf, cdf and sf

    def student_t_nc2_ecf(self):
        return ctxm.student_t_nc2_ecf(self)

#  9.1.28 Doubly noncentral 𝑡-distribution: qtf and isf
    def student_t_nc2_ecf_inv(self):
        return ctxm.student_t_nc2_ecf_inv(self)

    def student_t_nc2_moments(self, k, n, delta, theta):
        return ctxm.student_t_nc2_moments(self, k, n, delta, theta)


#  9.1.29 Doubly noncentral 𝐹-distribution: pdf, cdf and sf

    def fisher_f_nc2_ecf(self):
        return ctxm.fisher_f_nc2_ecf(self)

#  9.1.30 Doubly noncentral 𝐹-distribution: qtf and isf
    def fisher_f_nc2_ecf_inv(self):
        return ctxm.fisher_f_nc2_ecf_inv(self)

    def fisher_f_nc2_moments(self, k, n1, n2, lambda1, lambda2):
        return ctxm.fisher_f_nc2_moments(self, k, n1, n2, lambda1, lambda2)


# %%% 9.2 Edgeworth and Cornish-Fisher expansions: discrete (“lattice”) distributions

#   9.2.1 The Sheppard correction

    def sheppard_correction(self, kappa, show=False):
        return ctxm.sheppard_correction(self, kappa, show)


#   9.2.2 Poisson distribution: pdf, cdf and sf

    def poisson_ecf(self):
        return ctxm.poisson_ecf(self)

#   9.2.3 Poisson distribution: qtf and isf
    def poisson_ecf_inv(self):
        return ctxm.poisson_ecf_inv(self)

    def poisson_cumulants(self, mu, maxcum):
        return ctxm.poisson_cumulants(self, mu, maxcum)


#   9.2.4 Binomial distribution: pdf, cdf and sf

    def binomial_ecf(self):
        return ctxm.binomial_ecf(self)

#   9.2.5 Binomial distribution: qtf and isf
    def binomial_ecf_inv(self):
        return ctxm.binomial_ecf_inv(self)

    def binomial_cumulants(self, n, p, rmax):
        return ctxm.binomial_cumulants(self, n, p, rmax)


#   9.2.6 Negative binomial distribution: pdf, cdf and sf

    def negbinom_ecf(self):
        return ctxm.negbinom_ecf(self)

#   9.2.7 Negative binomial distribution: qtf and isf
    def negbinom_ecf_inv(self):
        return ctxm.negbinom_ecf_inv(self)

    def negbinom_cumulants(self, r, p, jmax):
        return ctxm.negbinom_cumulants(self, r, p, jmax)


#   9.2.8 Hypergeometric distribution: pdf, cdf and sf

    def hypergeo_ecf(self):
        return ctxm.hypergeo_ecf(self)

#   9.2.9 Hypergeometric distribution: qtf and isf
    def hypergeo_ecf_inv(self):
        return ctxm.hypergeo_ecf_inv(self)

    def hypergeo_rawmoments(self, M, n, NN, rmax):
        return ctxm.hypergeo_rawmoments(self, M, n, NN, rmax)

    def hypergeo_cumulants(self, M, n, NN, rmax):
        return ctxm.hypergeo_cumulants(self, M, n, NN, rmax)


#   9.2.10 Wilcoxon Signed Rank distribution: pdf, cdf and sf

    def wilcoxon_ecf(self, x, N, order):
        return ctxm.wilcoxon_ecf(self, x, N, order)

#   9.2.11 Wilcoxon Signed Rank distribution: qtf and isf
    def wilcoxon_ecf_inv(self, L1, R1, N, order):
        return ctxm.wilcoxon_ecf_inv(self, L1, R1, N, order)

    def wilcoxon_cumulants(self, n, maxcum):
        return ctxm.wilcoxon_cumulants(self, n, maxcum)


#   9.2.12 Kendall’s 𝑆 (or 𝜏 ) distribution: pdf, cdf and sf

    def kendall_ecf(self, x, N, order):
        return ctxm.kendall_ecf(self, x, N, order)

#   9.2.13 Kendall’s 𝑆 (or 𝜏 ) distribution: qtf and isf
    def kendall_ecf_inv(self, L1, R1, N, order):
        return ctxm.kendall_ecf_inv(self, L1, R1, N, order)

    def kendall_cumulants(self, n, maxcum):
        return ctxm.kendall_cumulants(self, n, maxcum)


#   9.2.14 Mann-Whitney 𝑈 distribution: pdf, cdf and sf

    def mannwhitney_ecf(self):
        return ctxm.mannwhitney_ecf(self)

#   9.2.15 Mann-Whitney 𝑈 distribution: qtf and isf
    def mannwhitney_ecf_inv(self):
        return ctxm.mannwhitney_ecf_inv(self)


#   9.2.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf and sf

    def jterpsta_ecf(self):
        return ctxm.jterpsta_ecf(self)

#   9.2.17 Jonckheere-Terpsta 𝑆 distribution: qtf and isf
    def jterpsta_ecf_inv(self):
        return ctxm.jterpsta_ecf_inv(self)

##    def TerpstaCum(self, k, n, maxcum):
##        return ctxm.TerpstaCum(self, k, n, maxcum)


#   9.2.18 Page 𝐿 distribution: pdf, cdf and sf

    def page_ecf(self):
        return ctxm.page_ecf(self)

#   9.2.19 Page 𝐿 distribution: qtf and isf
    def page_ecf_inv(self):
        return ctxm.page_ecf_inv(self)


# %%%  9.3 Luggannini-Rice and Jensen saddle point expansions: continuous distributions


#   9.3.1 Luggannini-Rice expansion: general approximation to the pdf, cdf, and sf

    def lugannani_rice(self, order, kderiv, s, verbose=True):
        '''Returns the Luggannini-Rice expansion: general approximation to the
        pdf, cdf, and sf'''
        return ctxm.lugannani_rice(self, order, kderiv, s, verbose)


#   9.3.2a Jensen expansion: general approximation to the qtf and isf

    def jensen(self, kderiv, s):
        '''Returns the Jensen expansion: general approximation to the
        pdf, cdf, and sf'''
        return ctxm.jensen(self, kderiv, s)


#   9.3.2b Jensen expansion: general approximation to the qtf and isf

    def jensen_inverse(self, n0, lambda0_, za_):
        '''Returns the Inverse Jensen expansion: general approximation to the
        qtf and isf'''
        return ctxm.jensen_inverse(self, n0, lambda0_, za_)

##    def JensenDemo(self):
##        return ctxm.JensenDemo(self)


#   9.3.3 Central Chi-square: pdf, cdf, sf

    def chi_squared_spa(self):
        return ctxm.chi_squared_spa(self)

#   9.3.4 Central Chi-square: qtf, isf
    def chi_squared_spa_inv(self):
        return ctxm.chi_squared_spa_inv(self)


#   9.3.5 Fisher 𝑧 distribution: pdf, cdf, sf

    def fisher_z_spa(self):
        return ctxm.fisher_z_spa(self)

#   9.3.6 Fisher 𝑧 distribution: qtf, isf
    def fisher_z_spa_inv(self):
        return ctxm.fisher_z_spa_inv(self)


#   9.3.7 Noncentral Chi-square: pdf, cdf, sf

    def chi_squared_nc_spa(self, x0, n0, lambda0_, Order=10, verbose=False):
        return ctxm.chi_squared_nc_spa(self, x0, n0, lambda0_, Order, verbose)


#   9.3.8 Noncentral Chi-square: qtf, isf

    def chi_squared_nc_spa_inv(self):
        return ctxm.chi_squared_nc_spa_inv(self)

##    def CdisnJensen(self, x0, n0, lambda0_, Order=10, verbose=False):
##        return ctxm.CdisnJensen(self, x0, n0, lambda0_)


#  9.3.9 Doubly Non-central Fisher F

    def fisher_f_nc2_spa(self, x, n1, n2, lambda1, lambda2):
        return ctxm.fisher_f_nc2_spa(self, x, n1, n2, lambda1, lambda2)


#  9.3.10 Doubly Non-central Fisher F: qtf, isf

    def fisher_f_nc2_spa_inv(self):
        return ctxm.fisher_f_nc2_spa_inv(self)

##    def FdisnJensen(self, N1, n2, F, t1, t2):
##        return ctxm.FdisnJensen(self, N1, n2, F, t1, t2)


#  9.3.11 Wilks’ Λ distribution, pdf, cdf, sf

    def wilks_lambda_spa(self):
        return ctxm.wilks_lambda_spa(self)

#  9.3.12 Wilks’ Λ distribution, cdf and sf
    def wilks_lambda_spa_inv(self):
        return ctxm.wilks_lambda_spa_inv(self)


#  9.3.13 Distribution of the product of independent beta variables, pdf, cdf, sf

    def beta_prod_spa(self):
        return ctxm.beta_prod_spa(self)

#  9.3.14 Distribution of the product of independent beta variables : qtf, isf
    def beta_prod_spa_inv(self):
        return ctxm.beta_prod_spa_inv(self)


#  9.3.15 Box distribution: pdf, cdf, sf

    def box_spa(self):
        return ctxm.box_spa(self)

#  9.3.16 Box distribution : qtf, isf
    def box_spa_inv(self):
        return ctxm.box_spa_inv(self)


#  9.3.17 Non-central Beta distribution: pdf, cdf, sf

    def beta_nc_spa(self):
        return ctxm.beta_nc_spa(self)

#  9.3.18 Non-central Beta distribution : qtf, isf
    def beta_nc_spa_inv(self):
        return ctxm.beta_nc_spa_inv(self)


#  9.3.19 Fisher’s 𝑅2 distribution: pdf, cdf, sf

    def fisher_r2_spa(self):
        return ctxm.fisher_r2_spa(self)

#  9.3.20 Fisher’s 𝑅2 distribution : qtf, isf
    def fisher_r2_spa_inv(self):
        return ctxm.fisher_r2_spa_inv(self)


#  9.3.21 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf, sf

    def wilks_lambda_glm_spa(self):
        return ctxm.wilks_lambda_glm_spa(self)

#  9.3.22 Noncentral Wilks’ Λ distribution: MANOVA, qtf, isf
    def wilks_lambda_glm_inv(self):
        return ctxm.wilks_lambda_glm_inv(self)


#  9.3.23 Noncentral Wilks’ Λ distribution: Independence, pdf, cdf, sf

    def wilks_lambda_ind_spa(self):
        return ctxm.wilks_lambda_ind_spa(self)

#  9.3.24 Noncentral Wilks’ Λ distribution: Independence, : qtf, isf
    def wilks_lambda_ind_spa_inv(self):
        return ctxm.wilks_lambda_ind_spa_inv(self)


# %%% 9.4 Luggannini-Rice and Jensen saddle point expansions: discrete (“lattice”) distributions


#  9.4.1 The Sheppard correction

    def sheppard_per_cgf(self):
        return ctxm.sheppard_per_cgf(self)


#  9.4.2 Poisson distribution: pdf, cdf, sf

    def poisson_spa(self):
        return ctxm.poisson_spa(self)

#  9.4.3 Poisson distribution: qtf, isf
    def poisson_spa_inv(self):
        return ctxm.poisson_spa_inv(self)


#  9.4.4 Binomial distribution: pdf, cdf and sf

    def binomial_spa(self):
        return ctxm.binomial_spa(self)

#  9.4.5 Binomial distribution: qtf and isf
    def binomial_spa_inv(self):
        return ctxm.binomial_spa_inv(self)

    def binomial_kderiv(self, order, t, n, p):
        return ctxm.binomial_kderiv(self, order, t, n, p)


#  9.4.6 Negative binomial distribution: pdf, cdf and sf

    def negbinom_spa(self):
        return ctxm.negbinom_spa(self)

#  9.4.7 Negative binomial distribution: qtf and isf
    def negbinom_spa_inv(self):
        return ctxm.negbinom_spa_inv(self)

    def negbinomial_kderiv(self, order, t, r, p):
        return ctxm.negbinomial_kderiv(self, order, t, r, p)


#  9.4.8 Hypergeometric distribution: pdf, cdf and sf

    def hypergeo_spa(self):
        return ctxm.hypergeo_spa(self)

#  9.4.9 Hypergeometric distribution: qtf and isf
    def hypergeo_spa_inv(self):
        return ctxm.hypergeo_spa_inv(self)


#  9.4.10 Wilcoxon distribution: pdf, cdf, sf

    def wilcoxon_spa(self):
        return ctxm.wilcoxon_spa(self)

#  9.4.11 Wilcoxon distribution: qtf, isf
    def wilcoxon_spa_inv(self):
        return ctxm.wilcoxon_spa_inv(self)


#  9.4.12 Mann-Whitney’s U distribution: pdf, cdf, sf

    def mannwhitney_spa(self):
        return ctxm.mannwhitney_spa(self)

#  9.4.13 Mann-Whitney’s U distribution: qtf, isf
    def mannwhitney_spa_inv(self):
        return ctxm.mannwhitney_spa_inv(self)


#  9.4.14 Kendall’s Tau distribution: pdf, cdf, sf

    def kendall_tau_spa(self):
        return ctxm.kendall_tau_spa(self)

#  9.4.15 Kendall’s Tau distribution: qtf, isf
    def kendall_tau_spa_inv(self):
        return ctxm.kendall_tau_spa_inv(self)


#  9.4.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf, sf

    def jterpsta_spa(self):
        return ctxm.jterpsta_spa(self)

#  9.4.17 Jonckheere-Terpsta 𝑆 distribution: qtf, isf
    def jterpsta_spa_inv(self):
        return ctxm.jterpsta_spa_inv(self)


#  9.4.18 Page 𝐿 distribution: pdf, cdf, sf

    def page_spa(self):
        return ctxm.page_spa(self)

#  9.4.19 Page 𝐿 distribution: qtf, isf
    def page_spa_inv(self):
        return ctxm.page_spa_inv(self)


# %%%  9.5 Box-Davis expansions and their inverses


#  9.5.1 Box-Davis expansion: general approximation to the pdf, cdf and sf

    def box_davis_expansion(self, x, f, rho, omega):
        return ctxm.box_davis_expansion(self, x, f, rho, omega)

#  9.5.2 Box-Davis expansion: general approximation to the qtf and isf
    def box_davis_expansion_inv(self, q, f, rho, omega):
        return ctxm.box_davis_expansion_inv(self, q, f, rho, omega)

##    def NewTestWilksUArb(self):
##        result = ctxm.NewTestWilksUArb(self)
##        return result


#  9.5.3 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_bd(self, x, f, rho, omega):
        return ctxm.wilks_lambda_bd(self, x, f, rho, omega)

#  9.5.4 Wilks’ Lambda distribution: qtf and isf
    def wilks_lambda_bd_inv(self, q, f, rho, omega):
        return ctxm.wilks_lambda_bd_inv(self, q, f, rho, omega)


#  9.5.5 Distribution of the product of independent beta variates: pdf, cdf and sf

    def beta_product_bd(self, x, f, rho, omega):
        return ctxm.beta_product_bd(self, x, f, rho, omega)

# 9.5.6 Distribution of the product of independent beta variates: qtf and isf
    def beta_product_bd_inv(self, q, f, rho, omega):
        return ctxm.beta_product_bd_inv(self, q, f, rho, omega)


#  9.5.7 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: pdf, cdf and sf

    def box_cov_bd(self, x, f, rho, omega):
        return ctxm.box_cov_bd(self, x, f, rho, omega)

#  9.5.8 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: qtf and isf
    def box_cov_bd_inv(self, q, f, rho, omega):
        return ctxm.box_cov_bd_inv(self, q, f, rho, omega)


#  9.5.9 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: pdf, cdf and sf

    def box_means_cov_bd(self, x, f, rho, omega):
        return ctxm.box_means_cov_bd(self, x, f, rho, omega)

#  9.5.10 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: qtf and isf
    def box_means_cov_bd_inv(self, q, f, rho, omega):
        return ctxm.box_means_cov_bd_inv(self, q, f, rho, omega)


#  9.5.11 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix: pdf, cdf and sf

    def lrt_vc0_bd(self, x, f, rho, omega):
        return ctxm.lrt_vc0_bd(self, x, f, rho, omega)

#  9.5.12 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix: qtf and isf
    def lrt_vc0_bd_inv(self, q, f, rho, omega):
        return ctxm.lrt_vc0_bd_inv(self, q, f, rho, omega)


#  9.5.13 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean: pdf, cdf and sf

    def lrt_x0_vc0_bd(self, x, f, rho, omega):
        return ctxm.lrt_x0_vc0_bd(self, x, f, rho, omega)

#  9.5.14 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean: qtf and isf
    def lrt_x0_vc0_bd_inv(self, q, f, rho, omega):
        return ctxm.lrt_x0_vc0_bd_inv(self, q, f, rho, omega)


#  9.5.15 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def pillai_v_bd(self, x, f, rho, omega):
        return ctxm.pillai_v_bd(self, x, f, rho, omega)

#  9.5.16 Pillai’s 𝑉 distribution: qtf and isf
    def pillai_v_bd_inv(self, q, f, rho, omega):
        return ctxm.pillai_v_bd_inv(self, q, f, rho, omega)


#  9.5.17 Hotelling’s 𝑇2 distribution: pdf, cdf and sf

    def hotelling_t2_bd(self, x, f, rho, omega):
        return ctxm.hotelling_t2_bd(self, x, f, rho, omega)

#  9.5.18 Hotelling’s 𝑇2 distribution: qtf and isf
    def hotelling_t2_bd_inv(self, q, f, rho, omega):
        return ctxm.hotelling_t2_bd_inv(self, q, f, rho, omega)


# %% 10 Fast approximations, without error estimates

# %%%  10.1 Approximations based on the normal distribution


# 10.1.1 Non-central chi-squared distribution: cdf and sf (Penev)


    def chi_squared_nc_penev_cdf(self, x, nu, nc):
        # def cdisn_penev(self, x, nu, nc):
        x = self.t(x)
        nu = self.t(nu)
        nc = self.t(nc)
        res = ctxm.cdisn_penev(self, x, nu, nc)
        return res


# 10.1.2 (Non-central) chi-squared distribution: qtf and isf (Canal)


    def chi_squared_nc_canal_qtf(self, L, R, n):
        # def cdisx_approx(self, L, R, n):
        L = self.t(L)
        R = self.t(R)
        n = self.t(n)
        res = ctxm.cdisx_approx(self, L, R, n)
        return res


# 10.1.3 Gamma distribution: qtf and isf (Canal)


    def gamma_canal_qtf(self, L, R, a):
        # def gammainv_approx(self, L, R, a):
        L = self.t(L)
        R = self.t(R)
        a = self.t(a)
        res = ctxm.gammainv_approx(self, L, R, a)
        return res


# 10.1.4 F distribution: qtf and isf (Davis)

    def fisher_f_davis_qtf(self, l, r, m, n):
        # def fdisx_approx(self, l, r, m, n):
        l = self.t(l)
        r = self.t(r)
        m = self.t(m)
        n = self.t(n)
        res = ctxm.fdisx_approx(self, l, r, m, n)
        return res


# 10.1.5 Beta distribution: qtf and isf (Davis)

    def beta_davis_qtf(self, l, r, a, b):
        # def betadisx_approx(self, l, r, a, b):
        l = self.t(l)
        r = self.t(r)
        a = self.t(a)
        b = self.t(b)
        res = ctxm.fdisx_approx(self, l, r, a, b)
        return res


# 10.1.6 Pearson’s rho distribution: pdf (Winterbottom)

    def pearson_rho_winterbottom_pdf(self):
        return ctxm.pearson_rho_winterbottom_pdf(self)


# 10.1.7 Pearson’s rho distribution: cdf and sf (Winterbottom)
    def pearson_rho_wb_cdf(self, N, r, rho):
        '''Returns Pearson’s rho distribution: cdf and sf (Winterbottom)'''
        return ctxm.pearson_rho_wb_cdf(self, N, r, rho)


##    def Rhodis_DH(self, N, r, rho):
##        # def Rhodis_DH(self, N, r, rho):
##        N = self.t(N)
##        r = self.t(r)
##        rho = self.t(rho)
##        res = ctxm.Rhodis_DH(self, N, r, rho)
##        return res


# 10.1.8 Pearson’s rho distribution: qtf and isf (Winterbottom)

    def pearson_rho_wb_qtf(self, l, r, n, rho):
        # def Rhodisx_W(self, l, r, n, rho):
        l = self.t(l)
        r = self.t(r)
        n = self.t(n)
        rho = self.t(rho)
        res = ctxm.Rhodisx_W(self, l, r, n, rho)
        return res


# 10.1.9 Pearson’s rho distribution: confidence limit for 𝜌 (Winterbottom)

    def pearson_rho_wb_cl(self, l, r, N, x):
        l = self.t(l)
        r = self.t(r)
        N = self.t(N)
        x = self.t(x)
        res = ctxm.Rhodisx_W(self, l, r, N, x)
        return res


# 10.1.10 Singly noncentral t: pdf (Broda)

    def student_t_nc_broda_pdf(self):
        return ctxm.student_t_nc_broda_pdf(self)


# 10.1.11 Singly noncentral t: cdf, sf (Broda)

    def student_t_nc_broda_cdf(self):
        return ctxm.student_t_nc_broda_cdf(self)

##    def TDistNC_Broda(self, n, x, mu):
##        L, R = ctxm.TDistDoublyNC_Broda_Combined(self, n, x, mu, 0)
##        return L, R


# 10.1.12 Singly noncentral t: qtf, isf (Harley)

    def student_t_nc_qtf_harley(self, alpha, df, delta):
        return ctxm.student_t_nc_qtf_harley(self, alpha, df, delta)


# 10.1.13 Singly noncentral t: confidence limit for 𝛿 (Akahira)

    def student_t_nc_akahira_cl(self, IsGLM, Df2, t, beta):
        return ctxm.student_t_nc_akahira_cl(self, IsGLM, Df2, t, beta)


# 10.1.14 Doubly noncentral t: cdf, sf (Broda)

    def student_t_nc2_broda_cdf(self):
        return ctxm.student_t_nc2_broda_cdf(self)

##    def TDistDoublyNC_Broda(self, n, x, mu, theta):
##        L, R = ctxm.TDistDoublyNC_Broda_Combined(self, n, x, mu, theta)
##        return L, R


# 10.1.15 Doubly noncentral t: qtf, isf (Broda)

    def student_t_nc2_broda_qtf(self):
        return ctxm.student_t_nc2_broda_qtf(self)


# 10.1.16 Spearman’s rho, first 8 cumulants

    def spearman_mu8(self, x, n, lambda1):
        return ctxm.spearman_mu8(self, x, n, lambda1)


# 10.1.17 Mann-Whitney U distribution: general alternatives specified by rank order probabilities

    def mannwhitney_nc_mu4(self, x, n, lambda1):
        return ctxm.mannwhitney_nc_mu4(self, x, n, lambda1)


# 10.1.18 First 4 moments of Kendalls 𝜏 in the general case

    def kendall_tau_nc_mu4(self, x, n, lambda1):
        return ctxm.kendall_tau_nc_mu4(self, x, n, lambda1)


# %%%  10.2 Approximations based on the chi-squared distribution


# 10.2.1 Non-Central chi-squared : cdf, sf (Patnaik)

    def chi_squared_nc_mu2_cdf(self, x, n, lambda1):
        return ctxm.chi_squared_nc_mu2_cdf(self, x, n, lambda1)


# 10.2.2 Non-Central chi-squared: qtf, isf (Patnaik)

    def chi_squared_nc_mu2_qtf(self, n, lambda1, LeftTail, RightTail):
        return ctxm.chi_squared_nc_mu2_qtf(self, n, lambda1, LeftTail, RightTail)


# 10.2.3 Non-Central chi-squared: confidence limit for 𝜆 (Winterbottom)

    def chi_squared_nc_wb_cl(self, F, alpha, Beta):
        return ctxm.chi_squared_nc_wb_cl(self, F, alpha, Beta)


# 10.2.4 Roy’s largest root 𝜃: pdf (Chiani)

    def roy_chiani_pdf(self, t1, p, n1, n2):
        return ctxm.roy_chiani_pdf(self, t1, p, n1, n2)


# 10.2.5 Roy’s largest root: cdf and sf (Chiani)

    def roy_chiani_cdf(self, t1, p, n1, n2):
        return ctxm.roy_chiani_cdf(self, t1, p, n1, n2)


# 10.2.6 Roy’s largest root: qtf and isf (Chiani)

    def roy_chiani_qtf(self, LeftTail, p, n1, n2):
        return ctxm.roy_chiani_qtf(self, LeftTail, p, n1, n2)


# %%%  10.3 Approximations based on the central F or beta distribution

# 10.3.1 Dunn-Šidák percentage points

    def dunn_sidak_qtf(self, LeftTail, RightTail, f1):
        return ctxm.dunn_sidak_qtf(self, LeftTail, RightTail, f1)


# 10.3.2 Singly non-central Fisher F distribution: cdf, sf (Patnaik)

    def fisher_f_nc_mu2_cdf(self, IsGLM, X, f1, f2, L):
        return ctxm.fisher_f_nc_mu2_cdf(self, IsGLM, X, f1, f2, L)


# 10.3.3 Singly non-central F distribution: qtf, isf (Patnaik)

    def fisher_f_nc_mu2_qtf(self, IsGLM, LeftTail, RightTail, f1, f2, L):
        return ctxm.fisher_f_nc_mu2_qtf(self, IsGLM, LeftTail, RightTail, f1, f2, L)


# 10.3.4 Singly non-central F: confidence interval for the noncentrality parameter 𝜆

    def fisher_f_nc_cl_(self, f1, f2,  X, l1, l2, LeftTail, RightTail):
        return ctxm.fisher_f_nc_cl_(self, f1, f2,  X, l1, l2, LeftTail, RightTail)


# 10.3.5 Doubly non-central F distribution: cdf, sf (Patnaik)

    def fisher_f_nc2_mu2_cdf(self, f1, f2,  X, l1, l2, LeftTail, RightTail):
        return ctxm.fisher_f_nc2_mu2_cdf(self, f1, f2,  X, l1, l2, LeftTail, RightTail)


# 10.3.6 Doubly non-central F distribution: qtf, isf (Patnaik)

    def fisher_f_nc2_mu2_qtf(self, LeftTail, RightTail, f1, f2, l1, l2):
        return ctxm.fisher_f_nc2_mu2_qtf(self, LeftTail, RightTail, f1, f2, l1, l2)


# 10.3.7 Multiple correlation coefficient: cdf, sf (Lee and Gurland)

    def fisher_r2_lee_cdf(self, IsGLM, X, f1, f2, L):
        return ctxm.fisher_r2_lee_cdf(self, IsGLM, X, f1, f2, L)


# 10.3.8 Multiple correlation coefficient: qtf, isf (Lee and Gurland)

    def fisher_r2_lee_qtf(self, IsGLM, LeftTail, RightTail, f1, f2, L):
        return ctxm.fisher_r2_lee_qtf(self, IsGLM, LeftTail, RightTail, f1, f2, L)


# 10.3.9 Fisher 𝑅2,: confidence limit for rho^2

    def fisher_r2_lee_cl(self):
        return ctxm.fisher_r2_lee_cl(self)


# 10.3.10 Central Wilks’ Lambda: cdf, sf (Rao)

    def wilks_lambda_rao_cdf(self, p, f1, f2, l, LeftTail, Righttail):
        return ctxm.wilks_lambda_rao_cdf(self, p, f1, f2, l, LeftTail, Righttail)


# 10.3.11 Central Wilks’ Lambda: qtf, isf (Rao)

    def wilks_lambda_rao_qtf(self, ctx, LeftTail, Righttail, p, f1, f2):
        return ctxm.wilks_lambda_rao_qtf(self, ctx, LeftTail, Righttail, p, f1, f2)


# 10.3.12 Central Hotelling’s 𝑇2: cdf, sf (Pillai and Young)

    def hotelling_t2_mu3_cdf(self, ctx, p, m, n, x):
        return ctxm.hotelling_t2_mu3_cdf(self, ctx, p, m, n, x)


# 10.3.13 Central Hotelling’s 𝑇2: qtf, isf (Pillai and Young)

    def hotelling_t2_mu3_qtf(self, ctx, p, m, n, x, LeftTail, Righttail):
        return ctxm.hotelling_t2_mu3_qtf(self, ctx, p, m, n, x, LeftTail, Righttail)


# 10.3.14 Central Pillai’s 𝑉 : cdf, sf (Ginzberg)

    def pillai_v_mu3_cdf(self, ctx, p, N1, n2, x):
        return ctxm.pillai_v_mu3_cdf(self, ctx, p, N1, n2, x)


# 10.3.15 Central Pillai’s 𝑉 : qtf, isf (Ginzberg)

    def pillai_v_mu3_qtf(self, ctx, p, n1, n2, LeftTail, Righttail):
        return ctxm.pillai_v_mu3_qtf(self, ctx, p, n1, n2, LeftTail, Righttail)


# 10.3.16 Product of independent beta variables: cdf, sf (Nagarsenker)

    def beta_product_mu3_cdf(self, ctx, p, b, c, x):
        return ctxm.beta_product_mu3_cdf(self, ctx, p, b, c, x)


# 10.3.17 Product of independent beta variables: qtf, isf (Nagarsenker)

    def beta_product_mu3_qtf(self, ctx, LeftTail, RightTail, p, b, c):
        return ctxm.beta_product_mu3_qtf(self, ctx, LeftTail, RightTail, p, b, c)


# %%%  10.4 Approximations based on the noncentral chi-squared distribution


# 10.4.1 Non-central Wilks’ Lambda (GLM): cdf and sf (Fujikoshi)

    def wilks_lambda_glm_chi2_cdf(self):
        return ctxm.wilks_lambda_glm_chi2_cdf(self)


# 10.4.2 Non-central Wilks’ Lambda (independence): cdf and sf (Lee)

    def wilks_lambda_ind_chi2_cdf(self):
        return ctxm.wilks_lambda_ind_chi2_cdf(self)


# 10.4.3 Non-central Pillai’s V (GLM): cdf and sf Fujikoshi

    def pillai_v_glm_chi2_cdf(self):
        return ctxm.pillai_v_glm_chi2_cdf(self)


# 10.4.4 Non-central Pillai’s V (independence): cdf and sf (Lee)

    def pillai_v_ind_chi2_cdf(self):
        return ctxm.hotelling_t2_glm_mu2_cdf(self)


# 10.4.5 Non-central Hotelling 𝑇2 (GLM): cdf and sf (Fujikoshi)

    def hotelling_t2_glm_chi2_cdf(self):
        return ctxm.hotelling_t2_glm_mu2_cdf(self)


# 10.4.6 Non-central Hotelling 𝑇2 (independence): cdf and sf (Lee)

    def hotelling_t2_ind_chi2_cdf(self):
        return ctxm.hotelling_t2_glm_mu2_cdf(self)


# %%%  10.5 Approximations based on the noncentral F or beta distribution


# 10.5.1 Multiple correlation coefficient (Lee and Gurland)

    def fisher_r2_lee_mu3_cdf(self, ctx, r2, f1, f2, Rho2):
        return ctxm.fisher_r2_lee_mu3_cdf(self, ctx, r2, f1, f2, Rho2)


# 10.5.2 Noncentral Wilks’ Lambda under the GLM or independence alternative

    def wilks_lambda_glm_mu2_cdf(self):
        return ctxm.wilks_lambda_glm_mu2_cdf(self)


# 10.5.3 Noncentral Hotelling’s T under the GLM or independence alternative

    def hotelling_t2_glm_mu2_cdf(self):
        return ctxm.hotelling_t2_glm_mu2_cdf(self)


# 10.5.4 Noncentral Pillai’s V under the GLM or independence alternative

    def pillai_v_glm_mu2_cdf(self):
        return ctxm.pillai_v_glm_mu2_cdf(self)


# 10.5.5 Noncentral Roy’s largest root under the GLM or independence alternative


    def roy_glm_mu2_cdf(self, ctx, IsRho, Model, p, m, n, x, omega):
        return ctxm.roy_glm_mu2_cdf(self, ctx, IsRho, Model, p, m, n, x, omega)


# %%% 10.6 Approximations based on hypergeometric functions of scalar argument


# 10.6.1 Hypergeometric function 1𝐹1 for matrix argument (Butler’s approximation)

    def hypergeom_matrix_1f1_butler(self, r2, f1, f2, Rho2):
        return ctxm.hypergeom_matrix_1f1_butler(self, r2, f1, f2, Rho2)


# 10.6.3 Hypergeometric function 2𝐹1 for matrix argument (Butler’s approximation)

    def hypergeom_matrix_2f1_butler(self, a, b, c, x):
        return ctxm.hypergeom_matrix_2f1_butler(self, a, b, c, x)


# %% 12 Numerical calculus (multiprecision floating point arithmetic)

# %%%  12.1 Polynomials

    def polyval(self, coeffs, x, derivative=False):
        res = gp2.polyval(coeffs, x, derivative)
        return res


    def polyroots(self, coeffs, maxsteps=50, cleanup=True, extraprec=10, error=False, roots_init=None):
        res = gp2.polyroots(coeffs, maxsteps, cleanup, extraprec, error, roots_init)
        return res


# %%%  12.2 Rootfinder

    def findroot(self, f, x0, solver='secant', tol=None, verbose=False, verify=True, **kwargs):
        res = gp2.findroot(f, x0, solver, tol, verbose, verify, **kwargs)
        return res


# %%%  12.3 Sums, products, limits and extrapolation


    def nsum(self, f, *intervals, **options):
        res = gp2.nsum(f, *intervals, **options)
        return res

    def sumem(self, f, interval, tol=None, reject=10, integral=None, adiffs=None, bdiffs=None, verbose=False, error=False, _fast_abort=False):
        res = gp2.sumem(f, interval, tol, reject, integral, adiffs, bdiffs, verbose, error, _fast_abort)
        return res

    def sumap(self, f, interval, integral=None, error=False):
        res = gp2.sumap(f, interval, integral, error)
        return res

    def nprod(self, f, interval, nsum=False, **kwargs):
        res = gp2.nprod(f, interval, nsum, **kwargs)
        return res

    def limit(self, f, x, direction=1, exp=False, **kwargs):
        res = gp2.limit(f, x, direction, exp, **kwargs)
        return res

    def richardson(self, seq):
        res = gp2.richardson(seq)
        return res

    def shanks(self, seq, table=None, randomized=False):
        res = gp2.shanks(seq, table, randomized)
        return res

    def levin(self, method='levin', variant='u'):
        res = gp2.levin( method, variant)
        return res

    def cohen_alt(self):
        res = gp2.cohen_alt()
        return res



# %%%  12.4 Numerical differentiation and ordinary differential equations


    def diff(self, f, x, n=1, **options):
        res = gp2.diff(f, x, n, **options)
        return res



    def diffs(self, f, x, n=None, **options):
        res = gp2.diffs(f, x, n, **options)
        return res


    def diffs_prod(self, factors):
        res = gp2.diffs_prod(factors)
        return res


    def diffs_exp(self, fdiffs):
        res = gp2.diffs_exp(fdiffs)
        return res


    def differint(self, f, x, n=1, x0=0):
        res = gp2.differint(f, x, n, x0)
        return res


    def odefun(self, F, x0, y0, tol=None, degree=None, method='taylor', verbose=False):
        res = gp2.odefun(F, x0, y0, tol, degree, method, verbose)
        return res



# %%%  12.5 Numerical integration

    def quad(self, f, *points, **kwargs):
        res = gp2.quad(f, *points, **kwargs)
        return res


    def quadosc(self, f, interval, omega=None, period=None, zeros=None):
        res = gp2.quadosc(f, interval, omega, period, zeros)
        return res



# 14.5.2 Doubly exponential quadrature

# 14.5.3 Gauss-Legendre quadrature


# 14.5.4 Quadrature with subdivision

    def quadsubdiv(self, f, interval, tol=None, maxintervals=None,  **kwargs):
        '''Quadrature with subdivision'''
        res = gp2.quadsubdiv(f, interval, tol, maxintervals, **kwargs)
        return res


# %%%  12.6 Numerical inverse Laplace transform


    def invertlaplace(self, f, t, **kwargs):
        res = gp2.invertlaplace(f, t, **kwargs)
        return res


# %%%  12.7 Function approximation



    def taylor(self, f, x, n, **options):
        res = gp2.taylor(f, x, n, **options)
        return res


    def pade(self, a, L, M):
        res = gp2.pade(a, L, M)
        return res


    def chebyfit(self, f, interval, N, error=False):
        res = gp2.chebyfit(f, interval, N, error)
        return res


    def fourier(self, f, interval, N):
        res = gp2.fourier(f, interval, N)
        return res


    def fourierval(self, series, interval, x):
        res = gp2.fourierval(series, interval, x)
        return res




# %%%  12.8 Number identification


    def identify(self, x, constants=[], tol=None, maxcoeff=1000, full=False, verbose=False):
        res = gp2.identify(x, constants, tol, maxcoeff, full, verbose)
        return res


    def findpoly(self, x, n=1, **kwargs):
        res = gp2.findpoly(x, n, **kwargs)
        return res


    def pslq(self, x, tol=None, maxcoeff=1000, maxsteps=100, verbose=False):
        res = gp2.pslq(x, tol, maxcoeff, maxsteps, verbose)
        return res



# %% 13 Algebra with random variables

# 13.1-13.2 is just text


# %%% 13.3 Probability density function (pdf)

# 13.3.1 Calculating the pdf from the cdf

    def pdf_from_cdf(self):
        return ctxm.pdf_from_cdf(self)

# 13.3.2 Calculating the pdf from the characteristic function
    def pdf_from_cf(self):
        return ctxm.pdf_from_cf(self)


# %%% 13.4 Probability mass function (pmf)

# 13.4.1 Calculating the pmf from the cdf

    def pmf_from_cdf(self):
        return ctxm.pmf_from_cdf(self)

# 13.4.2 Calculating the pmf from the characteristic function
    def pmf_from_cf(self):
        return ctxm.pmf_from_cf(self)

# 13.4.3 Calculating the pmf from the factorial moments
    def pmf_from_factorialmoments(self):
        return ctxm.pmf_from_factorialmoments(self)


# 13.4.4 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 13.5 Cumulative distribution function (cdf)

# 13.5.1 Calculating the cdf from the pdf

    def cdf_from_pdf(self):
        return ctxm.cdf_from_pdf(self)

# 13.5.2 Calculating the cdf from the pmf vector
    def cdf_from_pmf_vector(self):
        return ctxm.cdf_from_pmf_vector(self)


# 13.5.3 Calculating the cdf from the characteristic function, continuous cdf

    def cdf_from_cf_continuous(self):
        return ctxm.cdf_from_cf_continuous(self)


# 13.5.4 Calculating the cdf from the characteristic function (lattice distribution)

    def cdf_from_cf_lattice(self):
        return ctxm.cdf_from_cf_lattice(self)

# 13.5.5 Calculating the cdf from the factorial moments (lattice distributions)
    def cdf_from_factorial_moments_lattice(self):
        return ctxm.cdf_from_factorial_moments_lattice(self)


# %%% 13.6 Percentage point function

# 13.6.1 Calculating the percentage point function from the cdf

    def qtf_from_cdf(self):
        return ctxm.qtf_from_cdf(self)


# 13.6.2 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 13.7 Characteristic function

# 13.7.1 Calculating the characteristic function from the pdf

    def cf_from_pdf(self, cf):
        return ctxm.cf_from_pdf(self, cf)

# 13.7.2 Calculating the characteristic function from the pmf (lattice distribution)
    def cf_from_pmf(self, cf):
        return ctxm.cf_from_pmf(self, cf)

# 13.7.3 Calculating the characteristic function from the percentage point function
    def cf_from_qtf(self):
        return ctxm.cf_from_qtf(self)

# 13.7.4 Calculating the characteristic function from the raw moments
    def cf_from_rawmoments(self):
        return ctxm.cf_from_rawmoments(self)


# %%% 13.8 Moment generating function

# 13.8.1 Calculating the moment-generating function from the pdf

    def mgf_from_pdf(self):
        return ctxm.mgf_from_pdf(self)

# 13.8.2 Calculating the moment-generating function from the characteristic function
    def mgf_from_cf(self):
        return ctxm.mgf_from_cf(self)

# 13.8.3 Calculating the moment-generating function from the cumulant-generating function
    def mgf_from_cgf(self):
        return ctxm.mgf_from_cgf(self)

# 13.8.4 Calculating the moment-generating function from the probability-generating function
    def mgf_from_pgf(self):
        return ctxm.mgf_from_pgf(self)

# 13.8.5 Calculating the moment-generating function from the raw moments
    def mgf_from_rawmoments(self):
        return ctxm.mgf_from_rawmoments(self)


# %%% 13.9 Cumulant generating function

# 13.9.1 Calculating the cumulant-generating function from the characteristic function

    def cgf_from_cf(self):
        return ctxm.cgf_from_cf(self)

# 13.9.2 Calculating the cumulant-generating function from the moment-generating function
    def cgf_from_mgf(self):
        return ctxm.cgf_from_mgf(self)

# 13.9.3 Calculating the cumulant-generating function from the probability-generating function
    def cgf_from_pgf(self):
        return ctxm.cgf_from_pgf(self)

# 13.9.4 Calculating the cumulant-generating function from the cumulants
    def cgf_from_cumulants(self):
        return ctxm.cgf_from_cumulants(self)


# %%% 13.10 Probability generating function

# 13.10.1 Calculating the probability-generating function from the pmf vector

    def pgf_from_pmf_vector(self):
        return ctxm.pgf_from_pmf_vector(self)

# 13.10.1 Calculating the probability-generating function from the pmf vector
    def pgf_from_mgf(self):
        return ctxm.pgf_from_mgf(self)


# %%% 13.11 Factorial Moments

# 13.11.1 Calculating the factorial moments from the raw moments

    def factorialmoments_from_rawmoments(self, mraw):
        return ctxm.factorialmoments_from_rawmoments(self, mraw)

# 13.11.2 Calculating the factorial moments from the cumulants
    def factorialmoments_from_cumulants(self, mraw):
        return ctxm.factorialmoments_from_cumulants(self, mraw)


# %%% 13.12 Raw Moments

# 13.13.1 Calculating the raw moments from the pdf

    def rawmoments_from_pdf(self, pdf):
        return ctxm.rawmoments_from_pdf(self, pdf)

# 13.13.2 Calculating the raw moments from the pmf vector
    def rawmoments_from_pmfvector(self, x, nl, order, show=False):
        return ctxm.rawmoments_from_pmfvector(self, x, nl, order, show)

# 13.13.3 Calculating the raw moments from the factorial moments
    def rawmoments_from_factorialmoments(self, mfac):
        return ctxm.rawmoments_from_factorialmoments(self, mfac)

# 13.13.4 Calculating the raw moments from the central moments
    def rawmoments_from_centralmoments(self, mu):
        return ctxm.rawmoments_from_centralmoments(self, mu)

# 13.13.5 Calculating the raw moments from the cumulants
    def rawmoments_from_cumulants(self, kappa):
        return ctxm.rawmoments_from_cumulants(self, kappa)

# 13.13.6 Calculating the raw moments from the moment-generating function
    def rawmoments_from_mgf(self):
        return ctxm.rawmoments_from_mgf(self)

# 13.13.7 Calculating the raw moments from the characteristic function
    def rawmoments_from_cf(self):
        return ctxm.rawmoments_from_cf(self)

# 13.13.8 Calculating the raw moments from the probability-generating function
    def rawmoments_from_pgf(self):
        return ctxm.rawmoments_from_pgf(self)


# %%% 13.13 Central Moments

# 13.13.1 Calculating the central moments from the factorial moments

    def centralmoments_from_factorialmoments(self, mfac):
        return ctxm.centralmoments_from_factorialmoments(self, mfac)

# 13.13.1 Calculating the central moments from the raw moments
    def centralmoments_from_rawmoments(self, mraw):
        return ctxm.centralmoments_from_rawmoments(self, mraw)

# 13.13.2 Calculating the central moments from the cumulants
    def centralmoments_from_cumulants(self):
        return ctxm.centralmoments_from_cumulants(self)


# %%% 13.14 Cumulants

# 13.14.1 Calculating the cumulants from the pmf vector

    def cumulants_from_pmfvector(self, x, nl, order, show=False):
        return ctxm.cumulants_from_pmfvector(self, x, nl, order, show)

# 13.14.2 Calculating the cumulants from the factorial moments
    def cumulants_from_factorialmoments(self, mfac):
        return ctxm.cumulants_from_factorialmoments(self, mfac)

# 13.14.3 Calculating the cumulants from the raw moments
    def cumulants_from_rawmoments(self, mu):
        return ctxm.cumulants_from_rawmoments(self, mu)

    def cumulants_from_rawmoments_list(self, mu):
        '''Calculates the cumulants from the raw moments'''
        return ctxm.cumulants_from_rawmoments_list(self, mu)

# 13.14.4 Calculating the cumulants from the central moments
    def cumulants_from_centralmoments(self, mu):
        return ctxm.cumulants_from_centralmoments(self, mu)

# 13.14.5 Calculating the cumulants from the cumulant-generating function
    def cumulants_from_cgf(self, cgf):
        return ctxm.cumulants_from_cgf(self, cgf)


# 13.15-13.18 is just text






# %% 8 Elliptic functions and integrals




# %%%  8.1 Carlson symmetric elliptic integrals

# 8.1.1 Carlson symmetric elliptic integral of the first kind, 𝑅𝐹 (𝑥, 𝑦, 𝑧)

    def elliptic_rf(self, x, y, z):
        '''Carlson symmetric elliptic integral of the first kind,
        𝑅𝐹 (𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return self._fm3(mpm.elliptic_rf, x, y, z)


# 8.1.2 Carlson completely symmetric elliptic integral of the second kind,
    # 𝑅𝐺(𝑥, 𝑦, 𝑧)

    def elliptic_rg(self, x, y, z):
        '''Carlson completely symmetric elliptic integral of the second kind,
        𝑅𝐺(𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return self._fm3(mpm.elliptic_rg, x, y, z)


# 8.1.3 Carlson symmetric elliptic integral of the third kind, 𝑅𝐽 (𝑥, 𝑦, 𝑧, 𝑝)

    def elliptic_rj(self, x, y, z, p):
        '''Carlson symmetric elliptic integral of the third kind,
        𝑅𝐽 (𝑥, 𝑦, 𝑧, 𝑝)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        p = self.t(p)
        return self._fm4(mpm.elliptic_rj, x, y, z, p)


# 8.1.4 Carlson symmetric elliptic integral of the second kind, 𝑅𝐷(𝑥, 𝑦, 𝑧)

    def elliptic_rd(self, x, y, z):
        '''Carlson symmetric elliptic integral of the second kind,
        𝑅𝐷(𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return self._fm3(mpm.elliptic_rd, x, y, z)


# 8.1.5 Carlson degenerate symmetric elliptic integral of the first kind,
    # 𝑅𝐶(𝑥, 𝑦)

    def elliptic_rc(self, x, y):
        '''Carlson degenerate symmetric elliptic integral of the first kind,
        𝑅𝐶(𝑥, 𝑦)'''
        x = self.t(x)
        y = self.t(y)
        return self._fm2(mpm.elliptic_rc, x, y)





# %%%  8.2 Legendre elliptic integrals (elliptic parameter 𝑚)


# 8.2.1 Legendre complete elliptic integral of the first kind, 𝐾(m)

    def m_elliptic_k(self, m):
        '''Legendre complete elliptic integral of the first kind, 𝐾(m)'''
        m = self.t(m)
        return self._fm1(mpm.m_elliptic_k, m)


# 8.2.2 Legendre complete elliptic integral of the second kind, 𝐸(m)

    def m_elliptic_e(self, m):
        '''Legendre complete elliptic integral of the second kind, 𝐸(m)'''
        m = self.t(m)
        return self._fm1(mpm.m_elliptic_e, m)


# 8.2.3 Legendre complete elliptic integral of the third kind, Π(𝑛, m)

    def m_elliptic_pi(self, n, m):
        '''Legendre complete elliptic integral of the third kind, Π(𝑛, m)'''
        n = self.t(n)
        m = self.t(m)
        return self._fm2(mpm.m_elliptic_pi, n, m)


# 8.2.4 Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, m)

    def m_elliptic_f(self, phi, m):
        '''Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, m)'''
        phi = self.t(phi)
        m = self.t(m)
        return self._fm2(mpm.m_elliptic_f, phi, m)


# 8.2.5 Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, m)

    def m_elliptic_e_inc(self, phi, m):
        '''Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, m)'''
        phi = self.t(phi)
        m = self.t(m)
        return self._fm2(mpm.m_elliptic_e_inc, phi, m)


# 8.2.6 Legendre incomplete elliptic integral of the third kind, Π(𝑛, 𝜑, m)

    def m_elliptic_pi_inc(self, n, phi, m):
        '''Legendre incomplete elliptic integral of the third kind,
         Π(𝑛, 𝜑, m)'''
        n = self.t(n)
        phi = self.t(phi)
        m = self.t(m)
        return self._fm3(mpm.m_elliptic_pi_inc, n, phi, m)





# %%%  8.3 Legendre elliptic integrals (elliptic parameter 𝑘)


# 8.3.1 Legendre complete elliptic integral of the first kind, 𝐾(𝑘)

    def elliptic_k(self, k):
        '''Legendre complete elliptic integral of the first kind, 𝐾(𝑘)'''
        k = self.t(k)
        return self._fm1(mpm.elliptic_k, k)


# 8.3.2 Legendre complete elliptic integral of the second kind, 𝐸(𝑘)

    def elliptic_e(self, k):
        '''Legendre complete elliptic integral of the second kind, 𝐸(𝑘)'''
        k = self.t(k)
        return self._fm1(mpm.elliptic_e, k)


# 8.3.3 Legendre complete elliptic integral of the third kind, Π(𝑛, 𝑘)

    def elliptic_pi(self, n, k):
        '''Legendre complete elliptic integral of the third kind, Π(𝑛, 𝑘)'''
        n = self.t(n)
        k = self.t(k)
        return self._fm2(mpm.elliptic_pi, n, k)


# 8.3.4 Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, 𝑘)

    def elliptic_f(self, phi, k):
        '''Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k)
        return self._fm2(mpm.elliptic_f, phi, k)


# 8.3.5 Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, 𝑘)

    def elliptic_e_inc(self, phi, k):
        '''Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k)
        return self._fm2(mpm.elliptic_e_inc, phi, k)


# 8.3.6 Legendre incomplete elliptic integral of the third kind, Π(𝑛, 𝜑, 𝑘)

    def elliptic_pi_inc(self, n, phi, k):
        '''Legendre incomplete elliptic integral of the third kind,
         Π(𝑛, 𝜑, 𝑘)'''
        n = self.t(k)
        phi = self.t(phi)
        k = self.t(k)
        return self._fm3(mpm.elliptic_pi_inc, n, phi, k)



# 8.3.7 Jacobi Zeta function, 𝑍(𝜑, 𝑘)

    def jacobi_zeta(self, phi, k):
        '''Jacobi Zeta function, 𝑍(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k)
        return self._fm2(mpm.jacobi_zeta, phi, k)


# 8.3.8 Heuman’s Lambda function, Λ(𝜑, 𝑘)

    def heuman_lambda(self, phi, k):
        '''Heuman’s Lambda function, Λ(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k)
        return self._fm2(mpm.heuman_lambda, phi, k)





# %%%  8.4 Jacobi elliptic functions

##    def ellipfun(self, kind, u=None, m=None, q=None, k=None, tau=None):
##        u = self.t(u)
##        m = self.t(m)
##        return mpm.ellipfun('sn', u, m)


# 8.4.1 Jacobi elliptic function sn

    def jacobi_sn(self, u, k):
        '''Jacobi elliptic function sn'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_sn, u, k)


# 8.4.2 Jacobi elliptic function cn

    def jacobi_cn(self, u, k):
        '''Jacobi elliptic function cn'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_cn, u, k)

# 8.4.3 Jacobi elliptic function dn

    def jacobi_dn(self, u, k):
        '''Jacobi elliptic function dn'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_dn, u, k)

# 8.4.4 Jacobi elliptic function ns

    def jacobi_ns(self, u, k):
        '''Jacobi elliptic function ns'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_ns, u, k)

# 8.4.5 Jacobi elliptic function nc

    def jacobi_nc(self, u, k):
        '''Jacobi elliptic function nc'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_nc, u, k)

# 8.4.6 Jacobi elliptic function nd

    def jacobi_nd(self, u, k):
        '''Jacobi elliptic function nd'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_nd, u, k)

# 8.4.7 Jacobi elliptic function sc

    def jacobi_sc(self, u, k):
        '''Jacobi elliptic function sc'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_sc, u, k)

# 8.4.8 Jacobi elliptic function sd

    def jacobi_sd(self, u, k):
        '''Jacobi elliptic function sd'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_sd, u, k)

    def jacobi_dc(self, u, k):
        '''Jacobi elliptic function dc'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_dc, u, k)

    def jacobi_ds(self, u, k):
        '''Jacobi elliptic function ds'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_ds, u, k)

# 8.4.11 Jacobi elliptic function cs

    def jacobi_cs(self, u, k):
        '''Jacobi elliptic function cs'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_cs, u, k)

# 8.4.12 Jacobi elliptic function cd

    def jacobi_cd(self, u, k):
        '''Jacobi elliptic function cd'''
        u = self.t(u)
        k = self.t(k)
        return self._fm2(mpm.jacobi_cd, u, k)




# %%%  8.5 Jacobi theta functions


# 8.5.1 Jacobi theta1 function

    def jacobi_theta1(self, z, q):
        '''Jacobi theta1 function'''
        z = self.t(z)
        q = self.t(q)
        return self._fm2(mpm.jacobi_theta1, z, q)



# 8.5.2 Jacobi theta2 function

    def jacobi_theta2(self, z, q):
        '''Jacobi theta2 function'''
        z = self.t(z)
        q = self.t(q)
        return self._fm2(mpm.jacobi_theta2, z, q)


# 8.5.3 Jacobi theta3 function

    def jacobi_theta3(self, z, q):
        '''Jacobi theta3 function'''
        z = self.t(z)
        q = self.t(q)
        return self._fm2(mpm.jacobi_theta3, z, q)


# 8.5.4 Jacobi theta4 function

    def jacobi_theta4(self, z, q):
        '''Jacobi theta4 function'''
        z = self.t(z)
        q = self.t(q)
        return self._fm2(mpm.jacobi_theta4, z, q)




# %%%  8.6 Conversions of parameters of elliptic functions


# 8.6.1 Elliptic nome q

    def qfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic nome q'''
        return mpm.qfrom(kwargs)


# 8.6.2 Number-theoretic nome qbar

    def qbarfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Number-theoretic nome qbar'''
        return mpm.qbarfrom(kwargs)


# 8.6.3 Elliptic parameter m

    def mfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic parameter m'''
        return mpm.mfrom(kwargs)


# 8.6.4 Elliptic modulus k

    def kfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic modulus k'''
        return mpm.kfrom(kwargs)

# 8.6.5 Elliptic half-period ratio tau

    def taufrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic modulus k'''

    def taufrom(self, **kwargs):
        return mpm.taufrom(kwargs)


# 8.6.6 Elliptic lattice roots in terms of Elliptic period ratio 𝜏

    def elliptic_roots(self, tau):
        '''Elliptic lattice roots in terms of Elliptic period ratio 𝜏'''
        tau = self.t(tau)
        return self._fm1(mpm.elliptic_roots, tau)

# 8.6.7 Elliptic lattice invariants

    def elliptic_invariants(self, tau):
        '''Elliptic lattice invariants'''
        tau = self.t(tau)
        return self._fm1(mpm.elliptic_roots, tau)



# %%%  8.7 Weierstrass elliptic functions

# 8.7.1 Weierstrass function ℘(𝑧, 𝜏 )

    def weierstrass_p_t(self, z, tau):
        '''Weierstrass function ℘(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        return self._fm2(mpm.weierstrass_p_t, z, tau)


# 8.7.2 Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )

    def weierstrass_pprime_t(self, z, tau):
        '''Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        return self._fm2(mpm.weierstrass_pprime_t, z, tau)


# 8.7.3 Inverse Weierstrass function ℘−1 (𝑧, 𝜏 )

    def weierstrass_pinv_t(self, z, tau):
        '''Inverse Weierstrass function ℘−1 (𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        return self._fm2(mpm.weierstrass_pinv_t, z, tau)


# 8.7.4 Weierstrass Zeta

    def weierstrass_zeta_t(self, z, tau):
        '''Weierstrass Zeta'''
        z = self.t(z)
        tau = self.t(tau)
        return self._fm2(mpm.weierstrass_zeta_t, z, tau)


# 8.7.5 Weierstrass Sigma

    def weierstrass_sigma_t(self, z, tau):
        '''Weierstrass Sigma'''
        z = self.t(z)
        tau = self.t(tau)
        return self._fm2(mpm.weierstrass_sigma_t, z, tau)




# %%%  8.8 Modular forms


# 8.8.1 Dedekind eta function

    def dedekind_eta(self, tau):
        '''Dedekind eta function'''
        tau = self.t(tau)
        return self._fm1(mpm.dedekind_eta, tau)


# 8.8.2 Elliptic modular Lambda

    def modular_lambda(self, tau):
        '''Elliptic modular Lambda'''
        tau = self.t(tau)
        return self._fm1(mpm.modular_lambda, tau)



# 8.8.3 Elliptic modular Delta

    def modular_delta(self, tau):
        '''Elliptic modular Delta'''
        tau = self.t(tau)
        return self._fm1(mpm.modular_delta, tau)


# 8.8.4 Klein j-invariant

    def klein_j(self, tau):
        '''Klein j-invariant'''
        tau = self.t(tau)
        return self._fm1(mpm.klein_j, tau)


















# %% 09 Lerch’s transcendent and related functions

# %%%  9.1 Overview LERCH’S TRANSCENDENT, POLYGAMMA


# 9.1.1 Lerch’s transcendent

    def lerch_phi(self, z, s, a):
        '''Lerch’s transcendent'''
        z = self.t(z)
        s = self.t(s)
        a = self.t(a)
        return self._fm3(mpm.lerch_phi, z, s, a)


# 9.1.2 Lerch’s zeta

    def lerch_zeta(self, lambda1, alpha, s):
        '''Lerch’s zeta'''
        lambda1 = self.t(lambda1)
        alpha = self.t(alpha)
        s = self.t(s)
        return self._fm3(mpm.lerch_zeta, lambda1, alpha, s)


# %%%  9.2 Polygamma functions



# 9.2.1 Polygamma function 𝜓𝑚(𝑥)

    def polygamma(self, m, z):
        '''Polygamma function 𝜓𝑚(𝑥)'''
        m = self.t(m)
        z = self.t(z)
        return self._fm2(mpm.polygamma, m, z)


# 9.2.2 TriGamma function 𝜓′(𝑥)

    def trigamma(self, z):
        '''TriGamma function 𝜓′(𝑥)'''
        z = self.t(z)
        return self._fm1(mpm.trigamma, z)


# 9.2.3 DiGamma function 𝜓(𝑥)

    def digamma(self, z):
        '''DiGamma function 𝜓(𝑥)'''
        z = self.t(z)
        return self._fm1(mpm.digamma, z)


# 9.2.4 Harmonic numbers

    def harmonic(self, z):
        '''Harmonic numbers'''
        z = self.t(z)
        return self._fm1(mpm.harmonic, z)


# %%%  9.3 Polylogarithms and related functions

# 9.3.1 Polylogarithm, Li𝑠(𝑧)

    def polylog(self, s, z):
        '''Polylogarithm, Li𝑠(𝑧)'''
        s = self.t(s)
        z = self.t(z)
        return self._fm2(mpm.polylog, s, z)


# 9.3.2 Trilogarithm Function, Li3(𝑧)

    def trilog(self, z):
        '''Trilogarithm Function, Li3(𝑧)'''
        z = self.t(z)
        return self._fm1(mpm.trilog, z)


# 9.3.3 Dilogarithm Function, Li2(𝑧)

    def dilog(self, z):
        '''Dilogarithm Function, Li2(𝑧)'''
        z = self.t(z)
        return self._fm1(mpm.dilog, z)


# 9.3.4 Generalized Clausen sine function
    def clausen_sin(self, s, z):
        '''Generalized Clausen sine function'''
        s = self.t(s)
        z = self.t(z)
        return self._fm2(mpm.clausen_sin, s, z)


# 9.3.5 Generalized Clausen cosine function

    def clausen_cos(self, s, z):
        '''Generalized Clausen cosine function'''
        s = self.t(s)
        z = self.t(z)
        return self._fm2(mpm.clausen_cos, s, z)


# 9.3.6 Classical Clausen function

    def clausen2(self, z):
        '''Classical Clausen function'''
        z = self.t(z)
        return self._fm1(mpm.clausen2, z)


# 9.3.7 Bose-Einstein integrals of real order

    def bose_einstein(self, s, z, real4real=True):
        '''Bose-Einstein integrals of real order'''
        s = self.t(s)
        z = self.t(z)
        return self._fm2(mpm.bose_einstein, s, z)


# 9.3.8 Fermi-Dirac integrals

    def fermi_dirac(self, s, z, real4real=True):
        '''Fermi-Dirac integrals'''
        s = self.t(s)
        z = self.t(z)
        return self._fm2(mpm.fermi_dirac, s, z)


# 9.3.9 Legendre’s chi function

    def legendre_chi(self, s, z, real4real=True):
        '''Legendre’s chi function'''
        s = self.t(s)
        z = self.t(z)
        return self._fm2(mpm.legendre_chi, s, z)


# 9.3.10 Inverse tangent integral

    def inverse_tan_integral(self, s, z):
        '''Inverse tangent integral'''
        s = self.t(s)
        z = self.t(z)
        return self._fm2(mpm.inverse_tan_integral, s, z)


# %%%  9.4 Hurwitz zeta function and related functions


# 9.4.1 Hurwitz zeta function

    def hurwitz_zeta(self, s, a, derivative=0):
        '''Hurwitz zeta function'''
        s = self.t(s)
        a = self.t(a)
        return self._fm2(mpm.hurwitz_zeta, s, a)

# 9.4.2 Generalized harmonic number function

    def harmonic2(self, z, r):
        '''Generalized harmonic number function'''
        z = self.t(z)
        r = self.t(r)
        return self._fm2(mpm.harmonic2, z, r)


# 9.4.3 Bernoulli numbers

    def bernoulli(self, n):
        '''Bernoulli numbers'''
        n = int(n)
        return self._fm1(mpm.bernoulli, n)


# 9.4.4 Bernoulli polynomials

    def bernpoly(self, n, z):
        '''Bernoulli polynomials'''
        n = int(n)
        z = self.t(z)
        return self._fm2(mpm.bernpoly, n, z)


# 9.4.5 Euler numbers

    def eulernum(self, n):
        '''Euler numbers'''
        n = int(n)
        return self._fm1(mpm.eulernum, n)


# 9.4.6 Euler polynomials

    def eulerpoly(self, n, z):
        '''Euler polynomials'''
        n = int(n)
        z = self.t(z)
        return self._fm2(mpm.eulerpoly, n, z)


# 9.4.7 Barnes G-function

    def barnes_g(self, z):
        '''Barnes G-function'''
        z = self.t(z)
        return self._fm1(mpm.barnes_g, z)


# 9.4.8 Logarithm of Barnes G function

    def logbarnes_g(self, z):
        '''Logarithm of Barnes G function'''
        z = self.t(z)
        return self._fm1(mpm.logbarnes_g, z)

# 9.4.9 Hyperfactorial

    def hyperfactorial(self, z):
        '''Hyperfactorial'''
        z = self.t(z)
        return self._fm1(mpm.hyperfactorial, z)


# 9.4.10 Superfactorial

    def superfactorial(self, z):
        '''Superfactorial'''
        z = self.t(z)
        return self._fm1(mpm.superfactorial, z)


# %%%  9.5 Dirichlet L series, Riemann zeta function and related functions


# 9.5.1 Riemann zeta function

    def zeta(self, s):
        '''Riemann zeta function'''
        s = self.t(s)
        return self._fm1(mpm.zeta, s)


# 9.5.2 Riemann 𝜁(𝑠) − 1

    def zetam1(self, s):
        '''Riemann 𝜁(𝑠) − 1'''
        s = self.t(s)
        return self._fm1(mpm.zetam1, s)


# 9.5.3 Riemann-Siegel theta function

    def hardy_theta(self, t):
        '''Riemann-Siegel theta function'''
        t = self.t(t)
        return self._fm1(mpm.hardy_theta, t)


# 9.5.4 Riemann-Siegel Z function

    def hardy_z(self, t):
        '''Riemann-Siegel Z function'''
        t = self.t(t)
        return self._fm1(mpm.hardy_z, t)


# 9.5.5 Riemann (Landau) function 𝜉(𝑠)

    def riemann_xi(self, s):
        '''Riemann (Landau) function 𝜉(𝑠)'''
        s = self.t(s)
        return self._fm1(mpm.riemann_xi, s)


# 9.5.6 Dirichlet eta function

    def dirichlet_eta(self, s):
        '''Dirichlet eta function'''
        s = self.t(s)
        return self._fm1(mpm.dirichlet_eta, s)


# 9.5.7 Dirichlet 𝜂(𝑠) − 1: etam1(s)

    def dirichlet_etam1(self, s):
        '''Dirichlet 𝜂(𝑠) − 1: etam1(s)'''
        s = self.t(s)
        return self._fm1(mpm.dirichlet_etam1, s)


# 9.5.8 Dirichlet Beta function

    def dirichlet_beta(self, s):
        '''Dirichlet Beta function'''
        s = self.t(s)
        return self._fm1(mpm.dirichlet_beta, s)


# 9.5.9 Dirichlet Lambda function

    def dirichlet_lambda(self, s):
        '''Dirichlet Lambda function'''
        s = self.t(s)
        return self._fm1(mpm.dirichlet_lambda, s)


# 9.5.10 The nth nontrivial zero of Riemann's zeta on the critical line

    def zeta_zero(self, n):
        '''The nth nontrivial zero of Riemann's zeta on the critical line'''
        n = int(n)
        return self._fm1(mpm.zeta_zero, n)














# %% 10 Hypergeometric Function 0_F_1 and related functions

# %%%  10.1 Overview


# 10.1.1 Confluent Hypergeometric Limit Function 0𝐹1

    def hyperg_0f1(self, b, x):
        '''Confluent Hypergeometric Limit Function 0𝐹1'''
        b = self.t(b)
        x = self.t(x)
        return self._fm2(mpm.hyperg_0f1, b, x)


# 10.1.2 Regularized Confluent Hypergeometric Limit Function 0𝐹1r

    def hyperg_0f1r(self, b, x):
        '''Regularized Confluent Hypergeometric Limit Function 0𝐹1'''
        b = self.t(b)
        x = self.t(x)
        return self._fm2(mpm.hyperg_0f1r, b, x)


##    def chi_squared_nc_0f1_nc_pdf(self, x, nu, lambda1):
##        x = self.t(x)
##        nu = self.t(nu)
##        return self._fm3(mpm().chi_squared_nc_0f1_nc_pdf, x, nu, lambda1)


# %%%  10.2 Bessel functions and modified Bessel functions of real or complex order


# 10.2.1 Bessel function of the 1st kind 𝐽𝜈(𝑥)

    def bessel_jv(self, nu, x, scaled = False):
        '''Bessel function of the 1st kind 𝐽𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.bessel_jv, nu, x, scaled)


# 10.2.2 Bessel function of the 2nd kind 𝑌𝜈(𝑥)

    def bessel_yv(self, nu, x, scaled = False):
        '''Bessel function of the 2nd kind 𝑌𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.bessel_yv, nu, x, scaled)


# 10.2.3 First derivative of the Bessel function of the first kind: 𝐽′𝜈(𝑥)

    def bessel_jv_prime(self, nu, x, scaled = False):
        '''First derivative of the Bessel function of the 1st kind 𝐽𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.bessel_jv_prime, nu, x, scaled)


# 10.2.4 First derivative of the Bessel function of the 2nd kind: 𝑌′𝜈(𝑥)

    def bessel_yv_prime(self, nu, x, scaled = False):
        '''First derivative of the Bessel function of the 2nd kind 𝐽𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.bessel_yv_prime, nu, x, scaled)



# 10.2.5 Zeros 𝑥𝑖 of the Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0

    def bessel_jv_zero(self, nu, m):
        '''Zeros 𝑥𝑖 of the Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0'''
        nu = self.t(nu)
        m = int(m)
        return self._fm2(mpm.bessel_jv_zero, nu, m)


# 10.2.6 Zeros 𝑥𝑖 of the Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0

    def bessel_yv_zero(self, nu, m):
        '''Zeros 𝑥𝑖 of the Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0'''
        nu = self.t(nu)
        m = int(m)
        return self._fm2(mpm.bessel_yv_zero, nu, m)



# %%%  10.3 Modified Bessel functions


# 10.3.1 Modified Bessel function of the 1st kind 𝐼𝜈(𝑥)

    def bessel_iv(self, nu, x, scaled = False):
        '''Bessel function of the 1st kind 𝐽𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.bessel_iv, nu, x, scaled)


# 10.3.2 Modified Bessel function of the 2nd kind 𝐾𝜈(𝑥)

    def bessel_kv(self, nu, x, scaled = False):
        '''Bessel function of the 2nd kind 𝑌𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.bessel_kv, nu, x, scaled)


# 10.3.3 First derivative of the Modified Bessel function of the 1st kind 𝐼'𝜈(𝑥)

    def bessel_iv_prime(self, nu, x, scaled = False):
        '''First derivative of the Modified Bessel function of the 1st kind 𝐼'𝜈(𝑥'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.bessel_iv_prime, nu, x, scaled)


# 10.3.4 First derivative of the Modified Bessel function of the 2nd kind 𝐾'𝜈(𝑥)

    def bessel_kv_prime(self, nu, x, scaled = False):
        '''First derivative of the Modified Bessel function of the 2nd kind 𝐾'𝜈(𝑥)'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.bessel_kv_prime, nu, x, scaled)


# 10.3.5 Marcum Q function

    def marcum_q(self, m, a, b):
        '''Marcum Q function'''
        m = self.t(m)
        a = self.t(a)
        b = self.t(b)
        return self._fm3(mpm.marcum_q, m, a, b)




# %%%  10.4 Spherical Bessel functions

    # See also: https://github.com/fredrik-johansson/mpmath/issues/319

# 10.4.1 Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)

    def sph_bessel_jn(self, n, x, scaled = False):
        '''Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2b(mpm.sph_bessel_jn, n, x, scaled)

# 10.4.2 Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)

    def sph_bessel_yn(self, n, x, scaled = False):
        '''Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2b(mpm.sph_bessel_yn, n, x, scaled)


# 10.4.3 First derivative of the spherical Bessel function of the first
    # kind, 𝑗′𝑛(𝑥)

    def sph_bessel_jn_prime(self, n, x, scaled = False):
        '''Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2b(mpm.sph_bessel_jn_prime, n, x, scaled)


# 10.4.4 First derivative of the spherical Bessel function of the second
    # kind, 𝑦′𝑛(𝑥)

    def sph_bessel_yn_prime(self, n, x, scaled = False):
        '''Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2b(mpm.sph_bessel_yn_prime, n, x, scaled)


# 10.4.5 Zeros 𝑥𝑖 of the spherical Bessel function of the first kind, 𝑗𝑛(𝑥𝑖) = 0

    def sph_bessel_jn_zero(self, n, m):
        '''Zeros 𝑥𝑖 of the spherical Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0'''
        n = int(n)
        m = int(m)
        return self._fm2(mpm.sph_bessel_jn_zero, n, m)


# 10.4.6 Zeros 𝑥𝑖 of the spherical Bessel function of the second kind, 𝑦𝑛(𝑥𝑖) = 0

    def sph_bessel_yn_zero(self, n, m):
        '''Zeros 𝑥𝑖 of the spherical Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0'''
        n = int(n)
        m = int(m)
        return self._fm2(mpm.sph_bessel_yn_zero, n, m)





# %%%  10.5 Modified Spherical Bessel functions


# 10.5.1 Modified Spherical Bessel function of the first kind, 𝑖𝑛(𝑥)

    def sph_bessel_in(self, n, x, scaled = False):
        '''Modified Spherical Bessel function of the first kind, 𝑖𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2b(mpm.sph_bessel_in, n, x, scaled)

# 10.5.2 Modified Spherical Bessel function of the second kind, 𝑘𝑛(𝑥)

    def sph_bessel_kn(self, n, x, scaled = False):
        '''Modified Spherical Bessel function of the second kind, 𝑘𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2b(mpm.sph_bessel_kn, n, x, scaled)


# 10.5.3 Modified Spherical Bessel function of the first kind, 𝑖𝑛(𝑥)

    def sph_bessel_in_prime(self, n, x, scaled = False):
        '''Modified Spherical Bessel function of the first kind, 𝑖𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2b(mpm.sph_bessel_in_prime, n, x, scaled)


# 10.5.4 Modified Spherical Bessel function of the second kind, 𝑘𝑛(𝑥)

    def sph_bessel_kn_prime(self, n, x, scaled = False):
        '''Modified Spherical Bessel function of the second kind, 𝑘𝑛(𝑥)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2b(mpm.sph_bessel_kn_prime, n, x, scaled)


# 10.5.5  Bessel bessel polynomial besselpoly(n, x)

    def besselpoly(self, n, x):
        '''Bessel bessel polynomial besselpoly(n, x)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2(mpm.besselpoly, n, x)


# 10.5.6  Reverse Bessel bessel polynomial besseltheta(n, x)

    def besseltheta(self, n, x):
        '''Reverse Bessel bessel polynomial besseltheta(n, x)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2(mpm.besseltheta, n, x)










# %%%  10.6 Hankel functions


# 10.6.1 Hankel function of the first kind 𝐻1,𝜈(𝑥)

    def hankel_h1(self, n, z, scaled = False):
        '''Hankel function of the first kind 𝐻1,𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2b(mpm.hankel_h1, n, z, scaled)


# 10.6.2 Hankel function of the second kind 𝐻2,𝜈(𝑥)

    def hankel_h2(self, n, z, scaled = False):
        '''Hankel function of the second kind 𝐻2,𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2b(mpm.hankel_h2, n, z, scaled)


# 10.6.3 Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)

    def sph_hankel_h1(self, n, z, scaled = False):
        '''Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2b(mpm.sph_hankel_h1, n, z, scaled)

# 10.6.4 Spherical Hankel function of the second kind, ℎ2,𝑛(𝑥)

    def sph_hankel_h2(self, n, z, scaled = False):
        '''Spherical Hankel function of the second kind, ℎ2,𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2b(mpm.sph_hankel_h2, n, z, scaled)






# %%%  10.7 Airy functions

# 10.7.1 Airy function Ai

    def airy_ai(self, z, scaled = False):
        '''Airy function Ai'''
        z = self.t(z)
        return self._fm1(mpm.airy_ai, z)


# 10.7.2 Airy function Bi

    def airy_bi(self, z, scaled = False):
        '''Airy function Bi'''
        z = self.t(z)
        return self._fm1(mpm.airy_bi, z)


# 10.7.5 Airy Ai'(x)

    def airy_ai_prime(self, z, scaled = False):
        '''Airy Ai'(x)'''
        z = self.t(z)
        return self._fm1(mpm.airy_ai_prime, z)


# 10.7.6 Airy Bi'(x)

    def airy_bi_prime(self, z, scaled = False):
        '''Airy Bi'(x)'''
        z = self.t(z)
        return self._fm1(mpm.airy_bi_prime, z)


# 10.7.3 Zeros 𝑥𝑖 of the Airy function Ai, Ai(𝑥𝑖) = 0

    def airy_ai_zero(self, k):
        '''Zeros 𝑥𝑖 of the Airy function Ai, Ai(𝑥𝑖) = 0'''
        k = int(k)
        return self._fm1(mpm.airy_ai_zero, k)


# 10.7.4 Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0

    def airy_bi_zero(self, k):
        '''Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0'''
        k = int(k)
        return self._fm1(mpm.airy_bi_zero, k)





# %%%  10.8 Kelvin functions


# 10.8.1 Kelvin function ber

    def kelvin_ber(self, nu, x, scaled):
        '''Kelvin function ber'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.kelvin_ber, nu, x, scaled)


# 10.8.2 Kelvin function bei

    def kelvin_bei(self, nu, x, scaled):
        '''Kelvin function bei'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.kelvin_bei, nu, x, scaled)


# 10.8.3 Kelvin function ker

    def kelvin_ker(self, nu, x, scaled):
        '''Kelvin function ker'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.kelvin_ker, nu, x, scaled)


# 10.8.4 Kelvin function kei

    def kelvin_kei(self, nu, x, scaled):
        '''Kelvin function kei'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.kelvin_kei, nu, x, scaled)




# 10.8.5 First derivative of Kelvin function ber

    def kelvin_ber_prime(self, nu, x, scaled):
        '''First derivative of Kelvin function ber'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.kelvin_ber_prime, nu, x, scaled)


# 10.8.6 First derivative of Kelvin function bei

    def kelvin_bei_prime(self, nu, x, scaled):
        '''First derivative of Kelvin function bei'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.kelvin_bei_prime, nu, x, scaled)


# 10.8.7 First derivative of Kelvin function ker

    def kelvin_ker_prime(self, nu, x, scaled):
        '''First derivative of Kelvin function ker'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.kelvin_ker_prime, nu, x, scaled)


# 10.8.8 First derivative of Kelvin function kei

    def kelvin_kei_prime(self, nu, x, scaled):
        '''First derivative of Kelvin function kei'''
        nu = self.t(nu)
        x = self.t(x)
        return self._fm2b(mpm.kelvin_kei_prime, nu, x, scaled)















# %% 11 Hypergeometric Function 1_F_1 and related functions

# %%%  11.1 Overview

# 11.1.1 Kummer’s Confluent Hypergeometric Function 1𝐹1

    def hyperg_1f1(self, a, b, x):
        '''Kummer’s Confluent Hypergeometric Function 1𝐹1'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return self._fm3(mpm.hyperg_1f1, a, b, x)


# 11.1.2 Regularized Kummer’s Confluent Hypergeometric Function 1𝐹1

    def hyperg_1f1r(self, a, b, x):
        '''Regularized Kummer’s Confluent Hypergeometric Function 1𝐹1'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return self._fm3(mpm.hyperg_1f1r, a, b, x)


# 11.1.3 Tricomi’s Confluent Hypergeometric Function 𝑈

    def hyperg_u(self, a, b, x):
        '''Tricomi’s Confluent Hypergeometric Function 𝑈'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return self._fm3(mpm.hyperg_u, a, b, x)


# 11.1.4 Generalized Laguerre polynomials, 𝐿𝑚𝑛(𝑥)

    def laguerre_l(self, n, a, x):
        '''Generalized Laguerre polynomials, 𝐿𝑚𝑛(𝑥)'''
        n = self.t(n)
        a = self.t(a)
        x = self.t(x)
        return self._fm3(mpm.laguerre_l, n, a, x)


# 11.1.5 Hermite polynomials (physicist)

    def hermite_h(self, n, x):
        '''Hermite polynomials (physicist)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2(mpm.hermite_h, n, x)


# 11.1.6 Hermite polynomials (probabilist)

    def hermite_he(self, n, x):
        '''Hermite polynomials (probabilist)'''
        n = self.t(n)
        x = self.t(x)
        return self._fm2(mpm.hermite_he, n, x)




# %%%  11.2 Incomplete gamma functions

# 11.2.1 Lower normalised incomplete gamma function

    def gamma_p(self, a, x):
        '''Lower normalised incomplete gamma function'''
        a = self.t(a)
        x = self.t(x)
        return self._fm2(mpm.gamma_p, a, x)


# 11.2.2 Upper normalised incomplete gamma function

    def gamma_q(self, a, x):
        '''Upper normalised incomplete gamma function'''
        a = self.t(a)
        x = self.t(x)
        return self._fm2(mpm.gamma_q, a, x)


# 11.2.3 Lower non-normalised incomplete gamma function, 𝛾(𝑎, 𝑥)

    def gamma_lower(self, a, x):
        '''Lower non-normalised incomplete gamma function, 𝛾(𝑎, 𝑥)'''
        a = self.t(a)
        x = self.t(x)
        return self._fm2(mpm.gamma_lower, a, x)


# 11.2.4 Upper non-normalised incomplete gamma function, Γ(𝑎, 𝑥)

    def gamma_upper(self, a, x):
        '''Upper non-normalised incomplete gamma function, Γ(𝑎, 𝑥)'''
        a = self.t(a)
        x = self.t(x)
        return self._fm2(mpm.gamma_upper, a, x)


# 11.2.5 Derivative of the incomplete gamma function

    def gamma_p_prime(self, a, x):
        '''Derivative of the incomplete gamma function'''
        a = self.t(a)
        x = self.t(x)
        return self._fm2(mpm.gamma_p_prime, a, x)


# 11.2.6 Inverse of the real lower normalised incomplete gamma function

    def gamma_p_inv(self, a, p):
        '''Returns the Inverse of the real lower normalised incomplete gamma
        function.'''
        a = self.t(a)
        p = self.t(p)
        return self._fm2(mpm.gamma_p_inv, a, p)


# 11.2.7 Inverse of the real upper normalised incomplete gamma function

    def gamma_q_inv(self, a, q):
        '''Returns the Inverse of the real upper normalised incomplete gamma
        function.'''
        a = self.t(a)
        q = self.t(q)
        return self._fm2(mpm.gamma_q_inv, a, q)





# %%%  11.3 Coulomb, Whittaker and parabolic cylinder functions

# 11.6.0 Normalizing Gamow constant for Coulomb wave functions

    def coulombc(self, l, eta):
        '''Normalizing Gamow constant for Coulomb wave functions'''
        l = self.t(l)
        eta = self.t(eta)
        return mp.coulombc(l, eta)


# 11.6.1 Coulomb wave function F

    def coulomb_f(self, l, eta, z):
        '''Coulomb wave function F'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return self._fm3(mpm.coulomb_f, l, eta, z)


# 11.6.2 Coulomb wave function G

    def coulomb_g(self, l, eta, z):
        '''Coulomb wave function G'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return self._fm3(mpm.coulomb_g, l, eta, z)

# 11.3.3 Coulomb wave function Hplus

    def coulomb_hplus(self, l, eta, z):
        '''Coulomb wave function Hplus'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return self._fm3(mpm.coulomb_hplus, l, eta, z)

# 11.3.4 Coulomb wave function Hminus

    def coulomb_hminus(self, l, eta, z):
        '''Coulomb wave function Hminus'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return self._fm3(mpm.coulomb_hminus, l, eta, z)


# 11.3.5 Whittaker function M

    def whittaker_m(self, k, m, z):
        '''Whittaker function M'''
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        return self._fm3(mpm.whittaker_m, k, m, z)

# 11.3.6 Whittaker function W

    def whittaker_w(self, k, m, z):
        '''Whittaker function W'''
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        return self._fm3(mpm.whittaker_w, k, m, z)



# 11.3.7 Parabolic cylinder function D

    def pcfd(self, n, z):
        '''Parabolic cylinder function D'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.pcfd, n, z)


# 11.3.8 Parabolic cylinder function U

    def pcfu(self, a, z):
        '''Parabolic cylinder function U'''
        a = self.t(a)
        z = self.t(z)
        return self._fm2(mpm.pcfu, a, z)


# 11.3.9 Parabolic cylinder function V

    def pcfv(self, a, z):
        '''Parabolic cylinder function V'''
        a = self.t(a)
        z = self.t(z)
        return self._fm2(mpm.pcfv, a, z)


# 11.3.10 Parabolic cylinder function W

    def pcfw(self, a, z):
        '''Parabolic cylinder function W'''
        a = self.t(a)
        z = self.t(z)
        return self._fm2(mpm.pcfw, a, z)







# %%%  11.4 Error function and related functions


# 11.4.1 Error function erf

    def erf(self, z):
        '''Error function erf'''
        z = self.t(z)
        return self._fm1(mpm.erf, z)


# 11.4.2 Complementary error function erfc

    def erfc(self, z):
        '''Complementary error function erfc'''
        z = self.t(z)
        return self._fm1(mpm.erfc, z)



# 11.4.3 Inverse of the real error function

    def erf_inv(self, prob):
        '''Returns the Inverse of the real error function.'''
        prob = self.t(prob)
        return self._fm1(mpm.erf_inv, prob)


# 11.4.4 Inverse of the real complementory error function

    def erfc_inv(self, prob):
        '''Returns the Inverse of the real complementory error function.'''
        prob = self.t(prob)
        return self._fm1(mpm.erfc_inv, prob)


# 11.4.5 Standard normal density function

    def ndens(self, z):
        '''Returns the Standard normal density function.'''
        z = self.t(z)
        return self._fm1(mpm.ndens, z)


# 11.4.6 Standard normal cumulative distribution function

    def ndis(self, z):
        '''Returns the Standard normal cumulative distribution function.'''
        z = self.t(z)
        return self._fm1(mpm.ndis, z)


# 11.7.7 Standard normal percentage point function

    def ndisx(self, prob):
        '''Returns the Standard normal percentage point function.'''
        prob = self.t(prob)
        return self._fm1(mpm.ndisx, prob)


# 11.3.8 Imaginary error function erfi

    def erfi(self, z):
        '''Imaginary error function erfi'''
        z = self.t(z)
        return self._fm1(mpm.erfi, z)


# 11.4.9 Dawson’s integral

    def dawson(self, z):
        '''Dawson’s integral'''
        z = self.t(z)
        return self._fm1(mpm.dawson, z)


# 11.4.10 Faddeeva function

    def faddeeva(self, z):
        '''Faddeeva function'''
        z = self.t(z)
        return self._fm1(mpm.faddeeva, z)


# 11.4.11 Fresnel sine integral

    def fresnel_s(self, z):
        '''Fresnel sine integral'''
        z = self.t(z)
        return self._fm1(mpm.fresnel_s, z)

# 11.4.12 Fresnel cosine integral

    def fresnel_c(self, z):
        '''Fresnel cosine integral'''
        z = self.t(z)
        return self._fm1(mpm.fresnel_c, z)


# 11.4.13 Owen’s T function

    def owen_t(self, h, a):
        '''Returns Owen’s 𝑇 function via Verified Integration'''
        h = self.t(h)
        a = self.t(a)
        return self._fm2(mpm.owen_t, h, a)








# %%%  11.5 Exponential integrals and related functions

# 11.5.1 Exponential integral E1

    def exp_integral_e1(self, z):
        '''Exponential integral E1'''
        z = self.t(z)
        return self._fm1(mpm.exp_integral_e1, z)


# 11.5.2 Exponential integral Ei

    def exp_integral_ei(self, z):
        '''Exponential integral Ei'''
        z = self.t(z)
        return self._fm1(mpm.exp_integral_ei, z)


# 11.5.3 Logarithmic integral li

    def log_integral(self, z, offset=False):
        '''Logarithmic integral li'''
        z = self.t(z)
        return self._fm1(mpm.log_integral, z)


# 11.5.4 Hyperbolic sine integral shi

    def sinh_integral(self, z):
        '''Hyperbolic sine integral shi'''
        z = self.t(z)
        return self._fm1(mpm.sinh_integral, z)


# 11.5.5 Hyperbolic cosine integral Chi

    def cosh_integral(self, z):
        '''Hyperbolic cosine integral Chi'''
        z = self.t(z)
        return self._fm1(mpm.cosh_integral, z)


# 11.5.6 Exponential integral 𝐸𝑛

    def exp_integral_en(self, n, z):
        '''Exponential integral 𝐸𝑛'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.exp_integral_en, n, z)


# 11.5.7 Sine integral si
    def sin_integral(self, z):
        '''Sine integral si'''
        z = self.t(z)
        return self._fm1(mpm.sin_integral, z)


# 11.5.8 Cosine integral Ci

    def cos_integral(self, z):
        '''Cosine integral Ci'''
        z = self.t(z)
        return self._fm1(mpm.cos_integral, z)






# %% 12 Hypergeometric Function 2F1 and 1F2 (and related functions)

# %%%  12.1 Overview

# 12.1.1 Gauss Hypergeometric Function 2𝐹1

    def hyperg_2f1(self, a, b, c, z):
        '''Gauss Hypergeometric Function 2𝐹1'''
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        return self._fm4(mpm.hyperg_2f1, a, b, c, z)


# 12.1.2 Regularized Gauss Hypergeometric Function 2𝐹1

    def hyperg_2f1r(self, a, b, c, z):
        '''Regularized Gauss Hypergeometric Function 2𝐹1'''
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        return self._fm4(mpm.hyperg_2f1r, a, b, c, z)





# %%%  12.2 Chebyshev, Gegenbauer and Jacobi polynomials

# 12.2.1 Chebyshev polynomial of the first kind, 𝑇𝑛(𝑥)

    def chebyshev_t(self, n, z):
        '''Chebyshev polynomial of the first kind, 𝑇𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.chebyshev_t, n, z)


# 12.2.2 Chebyshev polynomial of the second kind, 𝑈𝑛(𝑥)

    def chebyshev_u(self, n, z):
        '''Chebyshev polynomial of the second kind, 𝑈𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.chebyshev_u, n, z)


# 12.2.3 Chebyshev polynomial of the third kind, V
    def chebyshev_v(self, n, z):
        '''Chebyshev polynomial of the third kind, 𝑈𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.chebyshev_v, n, z)


# 12.2.4 Chebyshev polynomial of the fourth kind, W
    def chebyshev_w(self, n, z):
        '''Chebyshev polynomial of the fourth kind, 𝑈𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.chebyshev_w, n, z)


# 12.2.5 Gegenbauer polynomials, 𝐶𝛼𝑛 (𝑥)

    def gegenbauer_c(self, n, a, z):
        '''Gegenbauer polynomials, 𝐶𝛼𝑛 (𝑥)'''
        n = self.t(n)
        a = self.t(a)
        z = self.t(z)
        return self._fm3(mpm.gegenbauer_c, n, a, z)


# 12.2.6 Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛

    def jacobi_p(self, n, a, b, z):
        '''Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛'''
        n = self.t(n)
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return self._fm4(mpm.jacobi_p, n, a, b, z)


# 12.2.7 Zernike radial polynomials

    def zernike_r(self, n, m, r):
        '''Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛'''
        n = int(n)
        m = int(m)
        r = self.t(r)
        return self._fm3(mpm.zernike_r, n, m, r)




# %%%  12.3 Legendre polynomials and related

# 12.3.1 Legendre polynomials / functions, 𝑃𝑙(𝑥)

    def legendre_p(self, n, z):
        '''Legendre polynomials / functions, 𝑃𝑙(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.legendre_p, n, z)


# 12.3.2 Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)

    def legendre_plm(self, l, m, z):
        '''Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)'''
        l = self.t(l)
        m = self.t(m)
        z = self.t(z)
        return self._fm3(mpm.legendre_plm, l, m, z)


# 12.3.3 Associated Legendre function of the second kind, 𝑄𝑙(𝑥)

    def legendre_q(self, l, z):
        '''Associated Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        l = self.t(l)
        z = self.t(z)
        return self._fm2(mpm.legendre_q, l, z)


# 12.3.4 Associated Legendre function of the second kind, 𝑄𝑙(𝑥)

    def legendre_qlm(self, n, m, z):
        '''Associated Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        return self._fm3(mpm.legendre_qlm, n, m, z)


# 12.3.5 Spherical harmonics, 𝑌 𝑚𝑛 (𝜃, 𝜑)

    def spherical_y(self, l, m, theta, phi):
        '''Spherical harmonics, 𝑌 𝑚𝑛 (𝜃, 𝜑)'''
        l = int(l)
        m = int(m)
        theta = self.t(theta)
        phi = self.t(phi)
        return self._fm4(mpm.spherical_y, l, m, theta, phi)


# 12.3.6 Toroidal harmonics, P

    def toroidal_plm(self, l, m, z):
        '''Associated Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        l = self.t(l)
        m = self.t(m)
        z = self.t(z)
        return self._fm3(mpm.toroidal_plm, l, m, z)


# 12.3.7 Toroidal harmonics, Q

    def toroidal_qlm(self, l, m, z):
        '''Associated Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        l = self.t(l)
        m = self.t(m)
        z = self.t(z)
        return self._fm3(mpm.toroidal_qlm, l, m, z)




# %%%  12.4 Incomplete Beta

# 12.4.1 Non-Normalised incomplete beta function

    def beta_lower(self, a, b, z):
        '''Non-Normalised incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return self._fm3(mpm.beta_lower, a, b, z)


# 12.4.2 Normalised incomplete beta function

    def ibeta(self, a, b, z):
        '''Normalised incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return self._fm3(mpm.ibeta, a, b, z)


# 12.4.3 Derivative of the incomplete beta function

    def ibeta_prime(self, a, b, z):
        '''Derivative of the incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return self._fm3(mpm.ibeta_prime, a, b, z)


# 12.4.4 Real non-normalized upper incomplete beta function

    def beta_upper(self, a, b, z):
        '''beta_upper'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return self._fm3(mpm.beta_upper, a, b, z)


# 12.4.5 Real normalized complementory incomplete beta function

    def ibetac(self, a, b, x):
        '''Real normalized complementory incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return self._fm3(mpm.ibetac, a, b, x)


# 12.4.6 Inverse of the real normalised incomplete beta function

    def ibeta_inv(self, a, b, prob):
        '''Returns the Inverse of the real normalised incomplete beta
        function.'''
        a = self.t(a)
        b = self.t(b)
        prob = self.t(prob)
        return self._fm3(mpm.ibeta_inv, a, b, prob)



# 12.4.7 Inverse of the real normalised complementary incomplete beta function

    def ibetac_inv(self, a, b, prob):
        '''Returns the Inverse of the real normalised complementary incomplete
        beta function.'''
        a = self.t(a)
        b = self.t(b)
        prob = self.t(prob)
        return self._fm3(mpm.ibetac_inv, a, b, prob)






# %%%  12.5 Hypergeometric function 1𝐹2

# 12.5.1 Non-regularized hypergeometric function 1𝐹2

    def hyperg_1f2(self, a1, b1, b2, z):
        '''Non-regularized hypergeometric function 1𝐹2'''
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        return self._fm4(mpm.hyperg_1f2, a1, b1, b2, z)


# 12.5.2 Regularized hypergeometric function 1𝐹2

    def hyperg_1f2r(self, a1, b1, b2, z):
        '''Regularized hypergeometric function 1𝐹2'''
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        return self._fm4(mpm.hyperg_1f2r, a1, b1, b2, z)




# %%%  12.6 Scorer functions

# 12.6.1 Scorer function Gi

    def scorer_gi(self, z):
        '''Scorer function Gi'''
        z = self.t(z)
        return self._fm1(mpm.scorer_gi, z)


# 12.6.2 Scorer function Hi(x)

    def scorer_hi(self, z):
        '''Scorer function Hi'''
        z = self.t(z)
        return self._fm1(mpm.scorer_hi, z)


# 12.6.3 Scorer function Gi'(x)

    def scorer_gi_prime(self, z):
        # Missing
        '''Scorer function Gi\' '''
        z = self.t(z)
        return self._fm1(mpm.scorer_gi_prime, z)


# 12.6.4 Scorer function Hi'(x)

    def scorer_hi_prime(self, z):
        # Missing
        '''Scorer function Hi\' '''
        z = self.t(z)
        return self._fm1(mpm.scorer_hi_prime, z)




# %%%  12.7 Struve functions

# 12.7.1 Struve function 𝐻𝜈(𝑥)

    def struve_h(self, n, z):
        '''Struve function 𝐻𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.struve_h, n, z)


# 12.7.2 Struve function 𝐿𝜈(𝑥)

    def struve_l(self, n, z):
        '''Struve function 𝐿𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.struve_l, n, z)


# 21.7.3 Struve function K

    def struve_k(self, n, z):
        '''Struve function K'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.struve_k, n, z)


# 12.7.1 Struve function M

    def struve_m(self, n, z):
        '''Struve function M'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.struve_m, n, z)





# %%%  12.8 Anger, Weber and Lommel functions

# 12.8.1 Anger function J

    def anger_j(self, n, z):
        '''Anger function J'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.anger_j, n, z)


# 12.8.2 Weber function E

    def weber_e(self, n, z):
        '''Weber function E'''
        n = self.t(n)
        z = self.t(z)
        return self._fm2(mpm.weber_e, n, z)


# 12.8.3 Lommel function 𝑆1

    def lommel_s1(self, mu, nu, z):
        '''Lommel function 𝑆1'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        return self._fm3(mpm.lommel_s1, mu, nu, z)


# 12.8.4 Lommel function 𝑆2

    def lommel_s2(self, mu, nu, z):
        '''Lommel function 𝑆2'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        return self._fm3(mpm.lommel_s2, mu, nu, z)








# %% 16 Inferential statistics

# 16.1 Basic classical statistical tests for 1 sample

# 16.1.1 Student t-test for 1 sample: tests (p-values)

    def student_t_1sample_test(self, n, mean, mu0, std, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (tests and CI)'''
        return stat.student_t_1sample_test(self, n, mean, mu0, std, alpha, **kwargs)


    def student_t_1sample_power(self, n, mean, mu0, std, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (power)'''
        return stat.student_t_1sample_power(self, n, mean, mu0, std, alpha, **kwargs)


    def student_t_1sample_samplesize(self, mean, mu0, std, alpha=0.05, beta=0.10, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (power)'''
        return stat.student_t_1sample_samplesize(self, mean, mu0, std, alpha, beta, **kwargs)





