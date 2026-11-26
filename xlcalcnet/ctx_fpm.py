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





from xlcalcnet import ctx_shared
from xlcalcnet import ctx07StatDataAnalysis

from xlcalcnet.mpmath import mp
import math
import cmath

from xlcalcnet import ctx_mpm
mpm = ctx_mpm.mpm()

from xlcalcnet import ctx_fp53
fp = ctx_fp53.FP53Context()
ctxm = ctx_shared.ctxUtil()
stat = ctx07StatDataAnalysis.inferential_statistics()




class fpm():

    # %% General functions

    targetpdf = 1
    targetcdf = 2
    targetsf = 3
    targetqtf = 6
    targetisf = 7



    def __init__(self):
        pass



    def _fm1(self, fun, fpm_z1):
        dps_old = mp.dps
        mp.dps = 30
        z1 = mpm.t(fpm_z1)
        res = fun(z1)
        res = self.t(res)
        mp.dps = dps_old
        return res

    def _fm2(self, fun, fpm_z1, fpm_z2):
        dps_old = mp.dps
        mp.dps = 30
        z1 = mpm.t(fpm_z1)
        z2 = mpm.t(fpm_z2)
        res = fun(z1, z2)
        res = self.t(res)
        mp.dps = dps_old
        return res

    def _fm2b(self, fun, fpm_z1, fpm_z2, b):
        dps_old = mp.dps
        mp.dps = 30
        z1 = mpm.t(fpm_z1)
        z2 = mpm.t(fpm_z2)
        res = fun(z1, z2, b)
        res = self.t(res)
        mp.dps = dps_old
        return res

    def _fm3(self, fun, fpm_z1, fpm_z2, fpm_z3):
        dps_old = mp.dps
        mp.dps = 30
        z1 = mpm.t(fpm_z1)
        z2 = mpm.t(fpm_z2)
        z3 = mpm.t(fpm_z3)
        res = fun(z1, z2, z3)
        res = self.t(res)
        mp.dps = dps_old
        return res

    def _fm3b(self, fun, fpm_z1, fpm_z2, fpm_z3, b):
        dps_old = mp.dps
        mp.dps = 30
        z1 = mpm.t(fpm_z1)
        z2 = mpm.t(fpm_z2)
        z3 = mpm.t(fpm_z3)
        res = fun(z1, z2, z3, b)
        res = self.t(res)
        mp.dps = dps_old
        return res

    def _fm4(self, fun, fpm_z1, fpm_z2, fpm_z3, fpm_z4):
        dps_old = mp.dps
        mp.dps = 30
        z1 = mpm.t(fpm_z1)
        z2 = mpm.t(fpm_z2)
        z3 = mpm.t(fpm_z3)
        z4 = mpm.t(fpm_z4)
        res = fun(z1, z2, z3, z4)
        res = self.t(res)
        mp.dps = dps_old
        return res



    def tc(self, z2):
        return complex(z2.Real, z2.Imaginary)

    # def nc(self, c2):
    #     return Numerics.Complex(c2.real, c2.imag)



    # def t(self, x, y=None):
    #     if y is None:
    #         if isinstance(x, int):
    #             return float(x)
    #         if isinstance(x, float) or isinstance(x, complex):
    #             return x
    #         elif isinstance(x, mp.mpf):
    #             return float(x)
    #         elif isinstance(x, mp.mpc):
    #             return complex(x)
    #         if isinstance(x, str):
    #             s = ''.join(x.split())
    #             if s[-1] not in ['j', 'J']:
    #                 return float(s)
    #             else:
    #                 return complex(s)
    #     x = float(x)
    #     y = float(y)
    #     return complex(x, y)



##
##    def s(self, z, mantissa_dps=None):
##        if mantissa_dps is None:
##            mantissa_dps = 15
##            if mp.dps < 15:
##                mantissa_dps = mp.dps
##        f = "{0:." + str(mantissa_dps-1) + "E}"
##        # print(f)
##        z = self.t(z)
##        s = f.format(z)
##        return s
##
##    def _fm1(self, fun, fpm_z1):
##        z1 = mpm().t(fpm_z1)
##        res = fun(z1)
##        return self.t(res)
##
##    def _fm2(self, fun, fpm_z1, fpm_z2):
##        z1 = mpm().t(fpm_z1)
##        z2 = mpm().t(fpm_z2)
##        res = fun(z1, z2)
##        return self.t(res)
##
##    def _fm3(self, fun, fpm_z1, fpm_z2, fpm_z3):
##        z1 = mpm().t(fpm_z1)
##        z2 = mpm().t(fpm_z2)
##        z3 = mpm().t(fpm_z3)
##        res = fun(z1, z2, z3)
##        return self.t(res)
##
##    def _fm3b(self, fun, fpm_z1, fpm_z2, fpm_z3, b):
##        z1 = mpm().t(fpm_z1)
##        z2 = mpm().t(fpm_z2)
##        z3 = mpm().t(fpm_z3)
##        res = fun(z1, z2, z3, b)
##        return self.t(res)
##
##    def _fm4(self, fun, fpm_z1, fpm_z2, fpm_z3, fpm_z4):
##        z1 = mpm().t(fpm_z1)
##        z2 = mpm().t(fpm_z2)
##        z3 = mpm().t(fpm_z3)
##        z4 = mpm().t(fpm_z4)
##        res = fun(z1, z2, z3, z4)
##        return self.t(res)




# %% 2 Contexts and a minimal set of context functions


# %%%  2.1 Contexts in xlcalcnet: common interface


# 2.1.2 Obtaining the name of a context

    @property
    def name(self):
        return "fpm"

    @property
    def fmtname(self):
        return "    fpm"

    @property
    def realctx(self):
        return self

    @property
    def cplxctx(self):
        return self

    def fmt(self, z):
        try:
            z = self.t(z)
            s1 = "{:.15G}".format(z.real)
            if self.ismpf(z):
                return ' ' + s1
            else:
                s2 = "{:.15G}".format(z.imag)
                return " " + "(" + s1 + ", " + s2 + ")"
        except:
            return str(z)


    @property
    def realtype(self):
        return fp.mpf

    @property
    def complextype(self):
        return fp.mpc



# 2.1.2 Creating a real number
    def mpf(self, x):
        return fp.mpf(x)

# 2.1.3 Creating a complex number
    def mpc(self, x, y=None):
        if y is not None:
            y = float(y)
            x = float(x)
            return fp.mpc(x, y)
        else: return fp.mpc(x)

# 2.1.4 Getting and setting the current precision (in bits)
    @property
    def prec(self):
        return fp.prec

    @prec.setter
    def prec(self, value):
        fp.prec = int(value)

# 2.1.5 Getting and setting the current decimal precision (in digits)

    @property
    def dps(self):
        return fp.dps

    @dps.setter
    def dps(self, value):
        fp.dps = int(value)

# 2.1.6 Getting and setting the current decimal precision (in digits)
    @property
    def pretty(self):
        return fp.pretty

    @pretty.setter
    def pretty(self, value):
        fp.pretty = bool(value)



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
        return fp.fadd(x, y, **kwargs)

    def fsub(self, x, y, **kwargs):
        return fp.fsub(x, y, **kwargs)

    def fneg(self, x, **kwargs):
        return fp.fneg(x, **kwargs)

    def fmul(self, x, y, **kwargs):
        return fp.fmul(x, y, **kwargs)

    def fdiv(self, x, y, **kwargs):
        return fp.fdiv(x, y, **kwargs)

##    def fmod(self, x, y):
##        return fp.fmod(x, y)

    def fsum(self, terms, absolute=False, squared=False):
        return fp.fsum(terms, absolute, squared)

    def fprod(self, factors):
        return fp.fprod(factors)

    def fdot(self, A, B=None, conjugate=False):
        return fp.fdot(A, B, conjugate)



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
        z = self.t(z)
        return fp.absmin(z)

# 2.3.6 Absolute value of the right end of an interval
    def absmax(self, z):
        z = self.t(z)
        return fp.absmax(z)



# %%%  2.4 Complex components


    def abs(self, z):
        z = self.t(z)
        return abs(z)

    def fabs(self, z):
        z = self.t(z)
        return abs(z)

    def sign(self, z):
        z = self.t(z)
        if z == 0:
            return self.t(0)
        if isinstance(z, float):
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
        if isinstance(z, float):
            return 0.0
        else:
            z = self.t(z)
            return cmath.phase(z)

    def phase(self, z):
        if isinstance(z, float):
            return 0.0
        else:
            z = self.t(z)
            return cmath.phase(z)

    def conj(self, z):
        z = self.t(z)
        return z.conjugate()

    def polar(self, z):
        z = self.t(z)
        res = mp.polar(z)
        return (self.t(res[0]), self.t(res[1]))

    def rect(self, r, phi):
        r = self.t(r)
        phi = self.t(phi)
        return r * self.expj(phi)



# %%%  2.5 Integer and fractional parts

    def floor(self, z):
        z = self.t(z)
        return float(math.floor(z))

    def ceil(self, z):
        z = self.t(z)
        return float(math.ceil(z))



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
        return ereal.lrint(z)

    def llrint(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        return ereal.llrint(z)


    def lround(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        return ereal.lround(z)

    def llround(self, z):
        from xlcalcnet import ereal
        z = self.t(z)
        return ereal.llround(z)





    def nint(self, z):
        return round(z)

##    def frac(self, z):
##        return fp.frac(z)




# %%%  2.6 Tolerances and approximate comparisons

    def chop(self, x, tol=None):
        return fp.chop(x, tol)

    def almosteq(self, s, t, rel_eps=None, abs_eps=None):
        return fp.almosteq(s, t, rel_eps, abs_eps)


# %%%  2.7 Properties of numbers

    def signbit(self, z):
        if (z < 0): return 1
        else: return 0


    def ismpf(self, z):
        return isinstance(z, fp.mpf)

    def ismpc(self, z):
        return isinstance(z, fp.mpc)


    def isinf(self, z):
        return fp.isinf(z)




    def isposinf(self, z):
        z = self.t(z)
        return fp.isinf(z) and z>0

    def isneginf(self, z):
        z = self.t(z)
        return fp.isinf(z) and z<0

    def iszero(self, z):
        z = self.t(z)
        return z==0

    def isone(self, z):
        z = self.t(z)
        return z==1

    def isinteger(self, z):
        z = self.t(z)
        return fp.isint(z)




    def isnan(self, z):
        z = self.t(z)
        return fp.isnan(z)

    def isnormal(self, z):
        z = self.t(z)
        return fp.isnormal(z)




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
        return fp.isfinite(z)

    def isint(self, z):
        return fp.isint(z)


    def copysign(self, x, y):
        x = self.t(x)
        y = self.t(y)
        return math.copysign(x, y)


    def fdim(self, x, y):
        x = self.t(x)
        y = self.t(y)
        if (x > y): return x - y
        else: return self.zero


    def ldexp(self, x, n):
        x = self.t(x)
        n = int(n)
        return fp.ldexp(x, n)

    def scalbn(self, x, n):
        return self.ldexp(x, n)

    def scalbln(self, x, n):
        return self.ldexp(x, n)



    def frexp(self, x):
        return fp.frexp(x)


    def logb(self, z):
        z = self.t(z)
        res = self.frexp(z)
        return self.t(res[1] - 1)


    def ilogb(self, z):
        z = self.t(z)
        res = self.frexp(z)
        return int(res[1] - 1)

    def mag(self, x):
        return fp.mag(x)

    def nint_distance(self, x):
        return fp.nint_distance(x)


    def modf(self, x):
        res = math.modf(x)
        return (res[1], res[0])

    def fmod(self, x, y):
        return math.fmod(x, y)

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
        return math.remainder(x, y)

    def remquo(self, x, y):
        from xlcalcnet import ereal
        res1 = ereal.remquo(x, y)
        i1 = int(res1.Item2)
        res0 = self.remainder(x,y)
        return (res0, i1)


    def ulp(self, x):
        # Note: eps = ulp(0)
        # See https://docs.python.org/3/library/math.html#math.ulp
        x = self.t(x)
        return math.ulp(x)

    def epsilon(self):
        return self.eps

    def maxvalue(self):
        import sys
        return sys.float_info.max

    def lowestvalue(self):
        import sys
        return -sys.float_info.max

    def minposvalue(self):
        import sys
        return sys.float_info.min


    def nextafter(self, x, y):
        # See https://docs.python.org/3/library/math.html#math.nextafter
        x = self.t(x)
        y = self.t(y)
        return math.nextafter(x, y)



# %%%  2.8 Number generation


    def fraction(self, p, q):
        return fp.fraction(p, q)

    def rand(self):
        return fp.rand()

    def arange(self, *args):
        return fp.arange(*args)

    def linspace(self, *args, **kwargs):
        return fp.arange(*args, **kwargs)




# %%%  2.9 Exact mathematical constants

    @property
    def zero(self):
        return +fp.zero

    @property
    def negzero(self):
        return -fp.zero

    @property
    def one(self):
        return +fp.one

    @property
    def j(self):
        return +fp.j

    @property
    def onej(self):
        return +fp.j

    @property
    def inf(self):
        return +fp.inf

    @property
    def ninf(self):
        return +fp.ninf

    @property
    def neginf(self):
        return +fp.ninf

    @property
    def nan(self):
        return +fp.nan



# %%%  2.10 Mathematical Constants



    @property
    def eps(self):
        return +fp.eps

    @property
    def ln2(self):
        return +fp.ln2

    @property
    def ln10(self):
        return +fp.ln10

    @property
    def pi(self):
        return +fp.pi

    @property
    def e(self):
        return +fp.e

    @property
    def euler(self):
        return +fp.euler

    @property
    def egamma(self):
        return +fp.euler

    @property
    def phi(self):
        return +fp.phi

    @property
    def catalan(self):
        return +fp.catalan

    @property
    def khinchin(self):
        return +fp.khinchin

    @property
    def glaisher(self):
        return +fp.glaisher

    @property
    def apery(self):
        return +fp.apery

    @property
    def degree(self):
        return +fp.degree






# %%%  2.11 Utility functions

    def t(self, x, y=None):
        return fp.convert(x, y)

    def convert(self, x, y=None):
        return fp.convert(x, y)

    def mpmathify(self, x, y=None):
        return fp.convert(x, y)


    def nstr(self, x, n=6, **kwargs):
        return fp.nstr(x, n, **kwargs)

    def nprint(self, x, n=6, **kwargs):
        return fp.nprint(x, n, **kwargs)


# dispose later

    def to_float(self, z):
        return float(z)

    def to_mpf(self, z):
        return mp.mpf(z)

    def from_mpf(self, z):
        return float(z)



# %%%  2.12 Precision management


    def autoprec(self, f, maxprec=None, catch=(), verbose=False):
        return fp.autoprec(f, maxprec, catch, verbose)

    def workprec(self, n, normalize_output=False):
        return fp.workprec(n, normalize_output)

    def workdps(self, n, normalize_output=False):
        return fp.workdps(n, normalize_output)

    def extraprec(self, n, normalize_output=False):
        return fp.extraprec(n, normalize_output)

    def extradps(self, n, normalize_output=False):
        return fp.extradps(n, normalize_output)



# %%%  2.13 Performance and debugging


    def memoize(self, f):
        return fp.memoize(f)

    def maxcalls(self, f, N):
        return fp.maxcalls(f, N)

# monitor and timing are not ctx functions


# %%%  2.14 Additonal functionality


    def plot(self, f, xlim=[- 5, 5], ylim=None, points=200, file=None, dpi=None, singularities=[], axes=None):
        res = mp.plot(f, xlim, ylim, points, file, dpi, singularities, axes)
        return res



# %% 03 Scalar elementary functions


# %%%  3.1 Exponential and related functions

# 3.1.1 Exponential function exp(x)

    def exp(self, z):
        '''Returns exp(z), the exponential function of z.'''
        z = self.t(z)
        return self.t(mp.exp(z))


# 3.1.2 Exponential function expj

    def expj(self, z):
        '''Returns expj(z) = cos(z) + i * sin(z).'''
        z = self.t(z)
        return self.t(mp.expj(z))


# 3.1.3 Exponential function expjpi

    def expjpi(self, z):
        '''Returns expjpi(z) = cos(pi*z) + i * sin(pi*z).'''
        z = self.t(z)
        return mp.expjpi(z)


# 3.1.4 Exponential function with base 10,

    def exp10(self, z):
        '''Returns exp10(z) = exp(z*ln(10)).'''
        z = self.t(z)
        return mp.exp(z * mp.log(10))


# 3.1.5 Exponential function with base 2,

    def exp2(self, z):
        '''Returns exp2(z) = exp(z*ln(2)).'''
        z = self.t(z)
        return mp.exp(z * mp.log(2))


# 3.1.6 Auxiliary function exp(z) - 1

    def expm1(self, z):
        '''Returns expm1(z) = exp(z)-1, computed accurately also for small z.'''
        z = self.t(z)
        return mp.expm1(z)


# 3.1.7 Auxiliary function 10^z - 1

    def exp10m1(self, z):
        '''Returns exp10m1(z) = exp10(z)-1,
        computed accurately also for small z.'''
        z = self.t(z)
        return mp.expm1(z * mp.log(10))


# 3.1.8 Auxiliary function 2^z - 1

    def exp2m1(self, z):
        '''Returns exp2m1(z) = exp2(z)-1,
        computed accurately also for small z.'''
        z = self.t(z)
        return mp.expm1(z * mp.log(2))


# 3.1.9 Relative error exponential (exp(z) - 1)/z

    def exprel(self, z):
        '''Returns exprel(z) = (exp(z) - 1)/z, 1 for z == 0.'''
        z = self.t(z)
        if (z == 0):
            return 1
        else:
            return mp.expm1(z)/z


# 3.1.10 Auxiliary function logistic(z) = 1/(1+exp(-z))

    def logistic(self, z):
        '''Returns logistic(z) = 1/(1+exp(-z)).'''
        z = self.t(z)
        return 1 / (1 + mp.exp(-z))


# %%%  3.2 Logarithms and related functions

# 3.2.1 Logarithm with base b, log_b(x)

##    def logb(self, z, b):
##        '''Returns the base b logarithm of z, logb(z,b) = ln(z)/ln(b).'''
##        z = self.t(z)
##        b = self.t(b)
##        return mp.log(z, b)


# 3.2.2 Natural logarithm ln(z)

    def ln(self, z):
        '''Returns the natural logarithm of z, ln(z) = log(z).'''
        z = self.t(z)
        return mp.ln(z)

    def log(self, z):
        '''Returns the natural logarithm of z, log(z) = ln(z).'''
        z = self.t(z)
        return mp.ln(z)


# 3.2.3 Auxiliary function log(z+1)

    def log1p(self, z):
        '''Returns log1p(z) = log(1+z) = ln(1+z), accurate also for small z.'''
        z = self.t(z)
        return mp.log1p(z)


# 3.2.4 Logarithm with base 10, log_10(z)

    def log10(self, z):
        '''Returns the base 10 logarithm of z, log10(z) = ln(z)/ln(10).'''
        z = self.t(z)
        return mp.log10(z)


# 3.2.5 Logarithm with base 2, log_2(z)

    def log2(self, z):
        '''Returns the base 2 logarithm of z, log2(z) = ln(z)/ln(2).'''
        z = self.t(z)
        return mp.log(z, 2)


# 3.2.6 Auxiliary function log(1 - exp(−|z|))

    def log1mexp(self, z):
        '''
        Returns log1mexp(z) = log(1 - exp(−|z|)),
        calculated in an accurate and efficient way.
        '''
        z = self.t(z)
        x = mp.fabs(z)
        if (mp.fabs(x) < 0.693):
            return mp.ln(-mp.expm1(-x))
        else:
            return mp.log1p(-mp.exp(-x))

        if (mp.fabs(z) > 0):
            return mp.ln(-mp.expm1(-z))
        else:
            return mp.log1p(-mp.exp(-z))


# 3.2.7 Auxiliary function log_2(1 + x)

    def log2p1(self, z):
        '''Returns log2p1(z) = mp.log1p(z) / mp.ln(2),
        accurate also for small z.'''
        z = self.t(z)
        return mp.log1p(z) / mp.ln(2)


# 3.2.8 Auxiliary function log10(1 + x)

    def log10p1(self, z):
        '''Returns log10p1(z) = mp.log1p(z) / mp.ln(10),
        accurate also for small z.'''
        z = self.t(z)
        return mp.log1p(z) / mp.ln(10)


# 3.2.9 Auxiliary function ln(1 − exp(x))

    def ln1mexp(self, z):
        '''
        Returns ln1mexp(z) = ln(-expm1(z)).
        For real input, the result is real-valued only for z < 0.
        '''
        z = self.t(z)
        return mp.ln(-mp.expm1(z))


# 3.2.10 Auxiliary function ln(1 + exp(x))

    def ln1pexp(self, z):
        '''Returns ln1pexp(z) = log1p(exp(z)).'''
        z = self.t(z)
        return mp.log1p(mp.exp(z))


# 3.2.11 Auxiliary function ln(1 + x) − x

    def ln1pmx(self, z):
        '''
        Returns ln1pmx(z) = log1p(z) - z, accurate also for -0.5 <= z <= 0.5.
        '''
        z = self.t(z)
        return mp.log1p(z) - z


# 3.2.12 Auxiliary function logit(x) = ln(x/(1-x))

    def logit(self, z):
        '''Returns logit(z) = ln(z/(1-z)), accurate also near x = 0.5.'''
        z = self.t(z)
        return mp.ln(z/(1-z))


# 3.2.13 Lambert W

    def lambertw(self, z, k=0):
        '''Returns lambertw(z), the Lambert W function z.'''
        z = self.t(z)
        k = int(k)
        return mp.lambertw(z, k)

    def lambert_wk(self, z, k=0):
        '''Returns lambertw(z), the Lambert W function z.'''
        z = self.t(z)
        k = int(k)
        return mp.lambertw(z, k)

    def lambert_w0(self, z, k=0):
        '''Returns lambertw(z), the Lambert W function z.'''
        z = self.t(z)
        return self.lambertw(z, 0)

    def lambert_wm1(self, z, k=0):
        '''Returns lambertw(z), the Lambert W function z.'''
        z = self.t(z)
        return self.lambertw(z, -1)


# 3.2.14 Arithmetic-geometric mean (AGM)

    def agm(self, a, b=1):
        '''Returns agm(a, b), the Arithmetic-geometric mean of a and b.'''
        a = self.t(a)
        b = self.t(b)
        return mp.agm(a, b)


# %%%  3.3 Square, roots and power functions

# 3.3.1 Square, x^2

    def square(self, z):
        '''Returns square(z) = z * z.'''
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


# 3.3.2 Square root

    def sqrt(self, z):
        '''Returns sqrt(z), the square root of z.'''
        z = self.t(z)
        return mp.sqrt(z)


# 3.3.3 Reciprocal of the square root

    def rsqrt(self, z):
        '''Returns rsqrt(z),the reciprocal of the principal square root of z.'''
        z = self.t(z)
        return 1/mp.sqrt(z)


# 3.3.4 Auxiliary function sqtz(1+z) - 1

    def sqrt1pm1(self, z):
        '''Returns sqrt1pm1(z) = expm1(log1p(z)/2),
        accurate also for z near 0.'''
        z = self.t(z)
        return mp.expm1(mp.log1p(z)/2)


# 3.3.5 Cube root

    def cbrt(self, z):
        '''Returns cbrt(z), the cube root of z.'''
        z = self.t(z)
        return mp.cbrt(z)


# 3.3.6 Returns the cube root in a way which gives a negative real number
# for negative input (like surd)

    def cuberoot(self, z):
        '''
        Returns cuberoot(z), the cube root of z,  in a way which gives a
        negative real number for negative input (like surd).
        '''
        z = self.t(z)
        return mp.cbrt(z)


# 3.3.7 Nth root,

    def nthroot(self, z, n):
        '''Returns nthroot(z, n), the nth root of z.'''
        z = self.t(z)
        n = int(n)
        return mp.nthroot(z, n)

    def root_si(self, z, n):
        return self.nthroot(z, n)



# 3.3.8 Unit roots

    def unitroot(self, k, n):
        '''Returns unitroot(z, n), the n unit roots of z.'''
        n = int(n)
        return mp.unitroots(n)


# 3.3.9 Hypotenuse

    def hypot(self, a, b):
        '''Returns hypot(a, b) = sqrt(a^2 + b^2).'''
        a = self.t(a)
        b = self.t(b)
        return mp.sqrt(a*a + b*b)


# 3.3.10 Power function


    def power(self, a, b):
        '''Returns power(a, b) = exp(b*log(a)).'''
        a = self.t(a)
        b = self.t(b)
        return mp.power(a, b)

    def pow(self, a, b):
        '''Returns pow(a, b) = exp(b*log(a)).'''
        a = self.t(a)
        b = self.t(b)
        return self.t(mp.power(a, b))

    def pow_si(self, x, n):
        '''Returns pow(a, b) = exp(b*log(a)).'''
        return pow(x, n)


# 3.3.11 Auxiliary function a^b - 1

    def powm1(self, a, b):
        '''
        Returns powm1(a, b) = a^b - 1 = exp(b*log(a)) - 1 = expm1(b*log(a)).,
        computed accurately also when a^b is very close to 1.
        '''
        a = self.t(a)
        b = self.t(b)
        return mp.powm1(a, b)


# 3.3.12 Auxiliary function (1+a)^b

    def pow1p(self, a, b):
        '''
        Returns pow1p(a, b) = (1+a)^b = exp(b*log(1+a)) = exp(b*logp1(a)).,
        computed accurately also when a is very close to 0.
        '''
        a = self.t(a)
        b = self.t(b)
        return mp.exp(b * mp.log1p(a))


# 3.3.13 Auxiliary function (1+a)^b - 1

    def pow1pm1(self, a, b):
        '''
        Returns pow1pm1(a, b) = (1+a)^b - 1 = expm1(b*logp1(a)).,
        computed accurately also when a is very close to 0
        or (1+a)^b is very close to 1.
        '''
        a = self.t(a)
        b = self.t(b)
        return mp.expm1(b * mp.log1p(a))


# 3.3.14 Fibonacci numbers

    def fibonacci(self, z):
        '''Returns fibonacci(z), the zth Fibonacci number, F(z).'''
        z = self.t(z)
        return mp.fibonacci(z)


# 3.3.15 Fibonacci polynomials

    def fibpoly(self, n, z):
        '''Returns fibpoly(n, z), the nth Fibonacci polynomial, F(n,z).'''
        n = self.t(n)
        z = self.t(z)
        w = self.sqrt(z*z+4)
        return (1/w) * (((z+w)/2)**n - ((z-w)/2)**n)


# 3.3.16 Lucas numbers

    def lucas(self, n):
        '''Returns lucas(z), the zth Lucas number, L(z).'''
        n = self.t(n)
        phi = self.phi
        return phi**n + (-phi)**(-n)


# 3.3.17 Lucas polynomials

    def lucaspoly(self, n, z):
        '''Returns lucaspoly(n, z), the nth Lucas polynomial, F(n,z).'''
        n = self.t(n)
        z = self.t(z)
        w = self.sqrt(z*z+4)
        return (((z+w)/2)**n + ((z-w)/2)**n)


# %%%  3.4 Trigonometric functions

# 3.4.1 Radians

    def radians(self, x):
        '''Converts the degree angle x to radians.'''
        return mp.radians(x)


# 3.4.2 Degrees

    def degrees(self, x):
        '''Converts the radian angle x to a degree angle.'''
        return mp.degrees(x)


# 3.4.3 Sine

    def sin(self, z):
        '''Returns the (circular) sine of z.'''
        z = self.t(z)
        return self.t(mp.sin(z))


# 3.4.4 Cosine

    def cos(self, z):
        '''Returns the (circular) cosine of z.'''
        z = self.t(z)
        return mp.cos(z)


# 3.4.5 Sine and cosine

    def sin_cos(self, z):
        '''Returns simultaneously the (circular) sine and cosine of z.'''
        z = self.t(z)
        return mp.sin(z), mp.cos(z)


# 3.4.6 Tangent

    def tan(self, z):
        '''Returns the (circular) tangent of z.'''
        z = self.t(z)
        return mp.tan(z)


# 3.4.7 Secant

    def sec(self, z):
        '''Returns the (circular) secant of z.'''
        z = self.t(z)
        return mp.sec(z)


# 3.4.8 Cosecant

    def csc(self, z):
        '''Returns the (circular) cosecant of z.'''
        z = self.t(z)
        return mp.csc(z)


# 3.4.9 Cotangent

    def cot(self, z):
        '''Returns the (circular) cotangent of z.'''
        z = self.t(z)
        return mp.cot(z)


# 3.4.10 Haversine function hav(z) = (1-cos(z))/2

    def hav(self, z):
        '''Returns the haversine function hav(z) = (1-cos(z))/2.'''
        z = self.t(z)
        t = mp.sin(0.5 * z)
        return t*t


# 3.4.11 Auxiliary function sinpi, sin(pi*x)

    def sinpi(self, z):
        '''Returns sinpi(z) = sin(pi*z).'''
        z = self.t(z)
        return mp.sinpi(z)


# 3.4.14 Auxiliary function cospi = cos(pi*z)

    def cospi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.cospi(z)

    def tanpi(self, z):
        '''Returns tanpi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.sinpi(z)/mp.cospi(z)

    def cotpi(self, z):
        '''Returns cotpi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.cospi(z)/mp.sinpi(z)

    def cscpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return 1.0 / mp.sinpi(z)

    def secpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return 1.0 / mp.cospi(z)


# 3.4.12 Cardinal sine, sinc(z) = sin(z)/z for z!=0; 1 for z==0

    def sinc(self, z):
        '''Returns the cardinal sine,
        sinc(z) = sin(z)/z for z!=0; 1 for z==0.'''
        z = self.t(z)
        return mp.sinc(z)


# 3.4.13 Auxiliary function sincpi(x) = sin(pi*z)/z for z!=0; 1 for z==0

    def sincpi(self, z):
        '''Returns sincpi(z) = sin(pi*z)/z for z!=0; 1 for z==0.'''
        z = self.t(z)
        return mp.sincpi(z)


# %%%  3.5 Hyperbolic functions

# 3.5.1 Hyperbolic Sine

    def sinh(self, z):
        '''Returns the hyperbolic sine of z, sinh(z).'''
        z = self.t(z)
        return mp.sinh(z)


# 3.5.2 Hyperbolic Cosine

    def cosh(self, z):
        '''Returns the hyperbolic cosine of z, cosh(z).'''
        z = self.t(z)
        return mp.cosh(z)


# 3.5.3 Hyperbolic Tangent

    def tanh(self, z):
        '''Returns the hyperbolic tangent of z, tanh(z).'''
        z = self.t(z)
        return mp.tanh(z)


# 3.5.4 Hyperbolic Secant

    def sech(self, z):
        '''Returns the hyperbolic secant of z, sech(z).'''
        z = self.t(z)
        return mp.sech(z)


# 3.5.5 Hyperbolic Cosecant

    def csch(self, z):
        '''Returns the hyperbolic cosecant of z, csch(z).'''
        z = self.t(z)
        return mp.csch(z)


# 3.5.6 Hyperbolic Cotangent

    def coth(self, z):
        '''Returns the hyperbolic cotangent of z, coth(z).'''
        z = self.t(z)
        return mp.coth(z)


# %%%  3.6 Inverse trigonometric functions

# 3.6.1 Inverse Sine

    def asin(self, z):
        '''Returns the inverse (circular) sine of z, asin(z).'''
        z = self.t(z)
        return mp.asin(z)


# 3.6.2 Inverse Cosine

    def acos(self, z):
        '''Returns the inverse (circular) cosine of z, acos(z).'''
        z = self.t(z)
        return mp.acos(z)


# 3.6.3 Inverse Tangent

    def atan(self, z):
        '''Returns the inverse (circular) tangent of z, atan(z).'''
        z = self.t(z)
        return mp.atan(z)


# 3.6.4 Inverse Tangent, 2 real arguments

    def atan2(self, x, y):
        '''
        Returns the inverse (circular) tangent of z, atan2(x,y),
        using to real arguments, x, and y.
        '''
        return mp.atan2(x, y)


# 3.6.5 Inverse Secant

    def asec(self, z):
        '''Returns the inverse (circular) secant of z, asec(z).'''
        z = self.t(z)
        return mp.asec(z)


# 3.6.6 Inverse Cosecant

    def acsc(self, z):
        '''Returns the inverse (circular) cosecant of z, acsc(z).'''
        z = self.t(z)
        return mp.acsc(z)


# 3.6.7 Inverse Cotangent

    def acot(self, z):
        '''Returns the inverse (circular) cosecant of z, acot(z).'''
        z = self.t(z)
        return mp.acot(z)


# 3.6.8 Gudermannian function gd(x) = asin(tanh(x))

    def gd(self, z):
        '''Returns the Gudermannian function gd(x) = asin(tanh(x)).'''
        z = self.t(z)
        return mp.asin(mp.tanh(z))


# 3.6.9 Inverse haversine function archav(z) = acos(1-2z) = 2*asin(sqrt(z))

    def archav(self, z):
        '''
        Returns the inverse haversine function
        archav(z) = acos(1-2z) = 2*asin(sqrt(z)).
        '''
        z = self.t(z)
        return 2*mp.asin(mp.sqrt(z))


# %%%  3.7 Inverse hyperbolic functions

# 3.7.1 Inverse Hyperbolic Sine

    def asinh(self, z):
        '''Returns the inverse hyperbolic sine of z, asinh(z).'''
        z = self.t(z)
        return mp.asinh(z)


# 3.7.2 Inverse Hyperbolic Cosine

    def acosh(self, z):
        '''Returns the inverse hyperbolic cosine of z, acosh(z).'''
        z = self.t(z)
        return mp.acosh(z)


# 3.7.3 Inverse Hyperbolic Tangent

    def atanh(self, z):
        '''Returns the inverse hyperbolic tangent of z, atanh(z).'''
        z = self.t(z)
        return mp.atanh(z)


# 3.7.4 Inverse Hyperbolic Secant

    def asech(self, z):
        '''Returns the inverse hyperbolic secant of z, asech(z).'''
        z = self.t(z)
        return mp.asech(z)


# 3.7.5 Inverse Hyperbolic Cosecant

    def acsch(self, z):
        '''Returns the inverse hyperbolic cosecant of z, acsch(z).'''
        z = self.t(z)
        return mp.acsch(z)


# 3.7.6 Inverse Hyperbolic Cotangent

    def acoth(self, z):
        '''Returns the inverse hyperbolic cotangent of z, acoth(z).'''
        z = self.t(z)
        return self.t(mp.acoth(z))


# 3.7.7 Inverse Gudermannian function arcgd(x) = atanh(sin(x))

    def arcgd(self, z):
        '''Returns the inverse Gudermannian function,
        arcgd(x) = atanh(sin(x)).'''
        z = self.t(z)
        return self.t(mp.atanh(mp.sin(z)))


# %%%  3.8 Factorials and related functions

# 3.8.1 Factorial

    def factorial(self, z):
        '''Returns the factorial of z, z! = Gamma(z+1).'''
        z = self.t(z)
        return self.t(mp.factorial(z))


# 3.8.2 Binomial coefficient

    def binomial(self, n, k):
        '''Returns binomial(n, k), the binomial coefficient n!/(k!(n-k)!) .'''
        n = self.t(n)
        k = self.t(k)
        return self.t(mp.factorial(n) / (mp.factorial(k) * mp.factorial(n - k)))



# 3.8.4 Rising factorial (Pochhammer symbol)

    def rf(self, z, n):
        '''Returns the rising factorial (or Pochhammer symbol).'''
        z = self.t(z)
        n = self.t(n)
        return self.t(mp.rf(z, n))

    def rising_factorial(self, z, n):
        '''Returns the rising factorial (or Pochhammer symbol).'''
        z = self.t(z)
        n = self.t(n)
        return self.t(mp.rf(z, n))


# 3.8.5 Falling factorial

    def ff(self, z, n):
        '''Returns the falling factorial.'''
        z = self.t(z)
        n = self.t(n)
        return self.t(mp.ff(z, n))

    def falling_factorial(self, z, n):
        '''Returns the falling factorial.'''
        z = self.t(z)
        n = self.t(n)
        return self.t(mp.ff(z, n))


# 3.8.6 Double factorial

    def fac2(self, z):
        '''Returns the double factorial.'''
        z = self.t(z)
        return self.t(mp.fac2(z))

    def doublefactorial(self, z):
        '''Returns the double factorial.'''
        z = self.t(z)
        return self.t(mp.fac2(z))


# %%%  3.9 Gamma function and related functions

# 3.9.1 Gamma function

    def gamma(self, z):
        '''Returns the Gamma function.'''
        z = self.t(z)
        return self.t(mp.gamma(z))

    def gamma1pm1(self, z):
        '''Returns gamma(z+1)-1.'''
        z = self.t(z)
        return self.t(mp.gamma(z+1)-1)


# 3.9.2 Reciprocal Gamma function

    def rgamma(self, z):
        '''Returns the Reciprocal Gamma function.'''
        z = self.t(z)
        return self.t(mp.rgamma(z))


# 3.9.3 Log-Gamma function

    def loggamma(self, z):
        '''Returns the Log-Gamma function.'''
        z = self.t(z)
        return self.t(mp.loggamma(z))

    def lgamma(self, z):
        '''Returns the Log-Gamma function.'''
        z = self.t(z)
        return self.t(mp.loggamma(z))


# 3.9.4 Beta function

    def beta(self, a, b):
        '''Returns the Beta function.'''
        a = self.t(a)
        b = self.t(b)
        return self.t(mp.beta(a, b))


# 3.9.5 Log-Beta function

    def logbeta(self, a, b):
        '''Returns the Log-Beta function.'''
        a = self.t(a)
        b = self.t(b)
        return self.t(mp.ln(mp.beta(a, b)))


# 3.9.6 Ratio of gamma functions

    def gamma_ratio(self, a, b):
        '''Returns the ratio of gamma functions.'''
        a = self.t(a)
        b = self.t(b)
        return self.t(mp.gamma(a) / mp.gamma(b))


# 3.9.7 Gamma-delta ratio

    def gamma_delta_ratio(self, a, delta):
        '''Returns the Gamma-delta ratio.'''
        a = self.t(a)
        delta = self.t(delta)
        return self.t(mp.gamma(a) / mp.gamma(a + delta))


# 3.9.8 Catalan function

    def catalan_c(self, z):
        '''Returns the Catalan function.'''
        z = self.t(z)
        t = mp.gamma(z+1)
        return self.t(mp.gamma(2*z+1) / ((z+1)*t*t))





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










##
### %% 04 Real scalar functions
##
##
### %%% 4.1 Error functions for real arguments
##
### 4.1.1 Error function erf
##
##    def real_erf(self, x):
##        '''Returns the Error function erf.'''
##        x = self.t(x)
##        return mp.erf(x)
##
##
### 4.1.2 Complementary error function erfc
##
##    def real_erfc(self, x):
##        '''Returns the Complementary error function erfc.'''
##        x = self.t(x)
##        return mp.erfc(x)
##
##
### 4.1.3 Inverse of the real error function
##
##    def real_erfinv(self, prob):
##        '''Returns the Inverse of the real error function.'''
##        prob = self.t(prob)
##        return mp.erfinv(prob)
##
##
### 4.1.4 Inverse of the real complementory error function
##
##    def real_erfcinv(self, prob):
##        '''Returns the Inverse of the real complementory error function.'''
##        prob = self.t(prob)
##        return mp.erfinv(1-prob)
##
##
### 4.1.5 Standard normal density function
##
##    def ndens(self, z):
##        '''Returns the Standard normal density function.'''
##        z = self.t(z)
##        a = mp.exp(-0.5*z*z)/mp.sqrt(2*mp.pi)
##        return a
##
##
### 4.1.6 Standard normal cumulative distribution function
##
##    def ndis(self, x):
##        '''Returns the Standard normal cumulative distribution function.'''
##        x = self.t(x)
##        a = 0.5 * mp.erfc(-x/mp.sqrt(mp.mpf(2)))
##        return a
##
##
### 4.1.7 Standard normal percentage point function
##
##    def ndis_inv(self, q):
##        '''Returns the Standard normal percentage point function.'''
##        q = self.t(q)
##        a = -mp.sqrt(2) * self.real_erfinv(2*q)
##        return a
##
##    def ndisx(self, L, R):
##        '''Returns the Standard normal percentage point function.'''
##        return ctxm.ndisx_erf(self, L, R)
##
##    def cplxerfc(self, z):
##        '''Returns the complex error function.'''
##        z = self.t(z)
##        x = self.real(z)
##        if x < 0:
##            y = -z
##            return mp.erfc(y)
##        else:
##            return mp.erfc(z)
##
###    def cplxerfc2(self, z):
###        z = self.t(z)
###        res = arb().erfc(z)
###        res = self.t(res)
###        return res
##
##    def cplxndis(self, z):
##        '''Returns the complex standard normal percentage point function.'''
##        # x = mp.mpf(x)
##        z = self.t(z)
##        a = 0.5 * self.cplxerfc(-z/mp.sqrt(mp.mpf(2)))
##        return a
##
###    def cplxndis2(self, z):
###        #x = mp.mpf(x)
###        z = self.t(z)
###        x = 0.5 * arb().erfc(-z/mp.sqrt(mp.mpf(2)))
###        res = self.t(x)
###        return res
##
##
### %%% 4.2 Incomplete gamma functions for non-negative real arguments and
##    # parameters
##
##
### 4.2.1 Real lower non-normalised incomplete gamma function
##
##    def real_gamma_lower(self, a, x, **kwargs):
##        '''Returns the Real lower non-normalised incomplete gamma function.'''
##        res = self.real_gamma_p(a, x, **kwargs)
##        return res * self.gamma(a)
##
##
### 4.2.2 Real upper non-normalised incomplete gamma function
##
##    def real_gamma_upper(self, a, x, **kwargs):
##        '''Returns the Real upper non-normalised incomplete gamma function.'''
##        res = self.real_gamma_q(a, x, **kwargs)
##        return res * self.gamma(a)
##
##
### 4.2.3 Real lower normalised incomplete gamma function
##
##    def real_gamma_p(self, a, x, **kwargs):
##        '''Returns the Real lower normalised incomplete gamma function.'''
##        a = self.t(a)
##        x = self.t(x)
##        return ctxm.real_gamma_p(self, a, x, **kwargs)
##
##
### 4.2.4 Real upper normalised incomplete gamma function
##
##    def real_gamma_q(self, a, x, **kwargs):
##        '''Returns the Real upper normalised incomplete gamma function.'''
##        a = self.t(a)
##        x = self.t(x)
##        return ctxm.real_gamma_q(self, a, x, **kwargs)
##
##
### 4.2.5 Tricomi’s entire incomplete gamma function
##
##    def real_gamma_tricomi(self, a, x, **kwargs):
##        '''Returns Tricomi’s entire incomplete gamma function.'''
##        res = self.real_gamma_p(a, x, **kwargs)
##        return res * self.power(x, -self.t(a))
##
##
### 4.2.6 Inverse of the real lower normalised incomplete gamma function
##
##    def real_gamma_p_inv(self, a, p, **kwargs):
##        '''Returns the Inverse of the real lower normalised incomplete gamma
##        function.'''
##        a = self.t(a)
##        p = self.t(p)
##        return ctxm.real_gamma_p_inv(self, a, p, **kwargs)
##
##
### 4.2.7 Inverse of the real upper normalised incomplete gamma function
##
##    def real_gamma_q_inv(self, a, q, **kwargs):
##        '''Returns the Inverse of the real upper normalised incomplete gamma
##        function.'''
##        a = self.t(a)
##        q = self.t(q)
##        return ctxm.real_gamma_q_inv(self, a, q, **kwargs)
##
##
### 4.2.8 Inverse (on parameter a) of the real lower normalised incomplete
##    # gamma function
##
##    def real_gamma_p_inva(self, x, prob, **kwargs):
##        '''Inverse (on parameter a) of the real lower normalised incomplete
##        gamma function.'''
##        x = self.t(x)
##        prob = self.t(prob)
##        return ctxm.real_gamma_p_inva(self, x, prob, **kwargs)
##
##
### 4.2.9 Inverse (on parameter a) of the real upper normalised incomplete
##    # gamma function
##
##    def real_gamma_q_inva(self, x, prob, **kwargs):
##        '''Returns the Inverse (on parameter a) of the real upper normalised
##        incomplete gamma function.'''
##        x = self.t(x)
##        prob = self.t(prob)
##        return ctxm.real_gamma_q_inva(self, x, prob, **kwargs)
##
##
### 4.2.10 Derivative of the incomplete gamma function
##
##    def real_gamma_derivative(self, a, x):
##        '''Returns the Derivative of the incomplete gamma function.'''
##        a = self.t(a)
##        x = self.t(x)
##        return self.exp(-x) * self.power(x, a-1) / self.gamma(a)
##
##
### %%%  4.3 Incomplete beta functions for non-negative real arguments and
##    # parameters
##
### 4.3.1 Non-normalised incomplete beta function
##
##    def real_beta3(self, a, b, x, **kwargs):
##        '''Returns the Non-normalised incomplete beta function.'''
##        res = self.real_ibeta(a, b, x, **kwargs)
##        return res * self.beta(a, b)
##
##
### 4.3.2 Non-normalised complement of the incomplete beta function
##
##    def real_betac(self, a, b, x, **kwargs):
##        '''Returns the Non-normalised complement of the incomplete beta
##        function.'''
##        res = self.real_ibetac(a, b, x, **kwargs)
##        return res * self.beta(a, b)
##
##
### 4.3.3 Normalised incomplete beta function
##
##    def real_ibeta(self, a, b, x, **kwargs):
##        '''Returns the Normalised incomplete beta function.'''
##        a = self.t(a)
##        b = self.t(b)
##        x = self.t(x)
##        return ctxm.real_ibeta(self, a, b, x, **kwargs)
##
##
### 4.3.4 Normalised complementory incomplete beta function
##
##    def real_ibetac(self, a, b, x, **kwargs):
##        '''Returns the Normalised complementory incomplete beta function.'''
##        a = self.t(a)
##        b = self.t(b)
##        x = self.t(x)
##        return ctxm.real_ibetac(self, a, b, x, **kwargs)
##
##
### 4.3.5 Inverse of the real normalised incomplete beta function
##
##    def real_ibeta_inv(self, a, b, prob, **kwargs):
##        '''Returns the Inverse of the real normalised incomplete beta
##        function.'''
##        a = self.t(a)
##        b = self.t(b)
##        prob = self.t(prob)
##        return ctxm.real_ibeta_inv(self, a, b, prob, **kwargs)
##
##    def betadisx(self, LeftTail, Righttail, a, b, **kwargs):
##        '''Returns the Inverse of the real normalised incomplete beta
##        function.'''
##        a = self.t(a)
##        b = self.t(b)
##        LeftTail = self.t(LeftTail)
##        x = ctxm.real_ibeta_inv(self, a, b, LeftTail, **kwargs)
##        return x, 1-x
##
##
### 4.3.6 Inverse of the real normalised complementary incomplete beta function
##
##    def real_ibetac_inv(self, a, b, prob, **kwargs):
##        '''Returns the IInverse of the real normalised complementary incomplete
##        beta function.'''
##        a = self.t(a)
##        b = self.t(b)
##        prob = self.t(prob)
##        return ctxm.real_ibetac_inv(self, a, b, prob, **kwargs)
##
##
### 4.3.7 Inverse (on parameter a) of the normalised incomplete beta function
##
##    def real_ibeta_inva(self, b, x, prob, **kwargs):
##        '''Returns the Inverse (on parameter a) of the normalised incomplete
##        beta function.'''
##        x = self.t(x)
##        b = self.t(b)
##        prob = self.t(prob)
##        return ctxm.real_ibeta_inva(self, b, x, prob, **kwargs)
##
##
### 4.3.8 Inverse (on parameter a) of the normalised complementary incomplete
##    # beta function
##
##    def real_ibetac_inva(self, b, x, prob, **kwargs):
##        '''Returns the Inverse (on parameter a) of the normalised complementary
##        incomplete beta function.'''
##        x = self.t(x)
##        b = self.t(b)
##        prob = self.t(prob)
##        return ctxm.real_ibetac_inva(self, b, x, prob, **kwargs)
##
##
### 4.3.9 Inverse (on parameter b) of the normalised incomplete beta function
##
##    def real_ibeta_invb(self, a, x, prob, **kwargs):
##        '''Returns the Inverse (on parameter b) of the normalised incomplete
##        beta function.'''
##        x = self.t(x)
##        a = self.t(a)
##        prob = self.t(prob)
##        return ctxm.real_ibeta_invb(self, a, x, prob, **kwargs)
##
##
### 4.3.10 Inverse (on parameter b) of the normalised complementary incomplete
##    # beta function
##
##    def real_ibetac_invb(self, a, x, prob, **kwargs):
##        '''Returns the Inverse (on parameter b) of the normalised complementary
##        incomplete beta function.'''
##        x = self.t(x)
##        a = self.t(a)
##        prob = self.t(prob)
##        return ctxm.real_ibetac_invb(self, a, x, prob, **kwargs)
##
##
### 4.3.11 Derivative of the incomplete beta function
##
##    def real_ibeta_derivative(self, a, b, x):
##        '''Returns the Derivative of the incomplete beta function.'''
##        a = self.t(a)
##        b = self.t(b)
##        x = self.t(x)
##        return self.power(x, a-1) * self.power(1-x, b-1) / self.beta(a, b)
##
##    def betadis(self, a, b, q, p):
##        '''Returns the incomplete beta function (L, R).'''
##        L, R = ctxm.betadis(self, a, b, q, p)
##        return L, R
##
##    def betadis3(self, a, b, q, p):
##        '''Returns the incomplete beta function (L, R, density).'''
##        L, R, density = ctxm.betadis3(self, a, b, q, p)
##        return L, R, density
##


# %% 05 Numerical calculus

# %%%  14.1 Polynomials

# 14.1.1 Polynomial evaluation

    def polyval(self, coeffs, x, derivative=False):
        '''Returns the value of a polynomial with coefficients coeff at x'''
        res = mp.polyval(coeffs, x, derivative)
        return res

# 14.1.2 Polynomial roots
    def polyroots(self, coeffs, maxsteps=50, cleanup=True, extraprec=10,
                  error=False, roots_init=None):
        '''Computes all roots (real or complex) of a given polynomial'''
        res = mp.polyroots(coeffs, maxsteps, cleanup, extraprec, error,
                           roots_init)
        return res


# %%%  14.2 Rootfinder

# 14.2.1 Root-finding

    def findroot(self, f, x0, solver='secant', tol=None, verbose=False,
                 verify=True, **kwargs):
        '''Find a solution to 𝑓(𝑥) = 0, using x0 as starting point or
        interval for x.'''
        res = mp.findroot(f, x0, solver, tol, verbose, verify, **kwargs)
        return res


# 14.2.2 Newton

# 14.2.3 Secant

# 14.2.4 MNewton

# 14.2.5 Halley

# 14.2.6 Muller

# 14.2.7 Bisection

# 14.2.8 Illinois

# 14.2.9 Pegasus

# 14.2.10 Anderson

# 14.2.11 Ridder

# 14.2.12 MDNewton

# 14.2.13 Multiplicity of roots

# 14.2.14 Steffensen acceleration

# 14.2.15 Jacobian Matrix


# %%%  14.3 Sums, products, limits and extrapolation

# 14.3.1 Summation of infinite series

    def nsum(self, f, *intervals, **options):
        '''Summation of infinite series'''
        res = mp.nsum(f, *intervals, **options)
        return res


# 14.3.2 Summation using the Euler-Maclaurin formula

    def sumem(self, f, interval, tol=None, reject=10, integral=None,
              adiffs=None, bdiffs=None, verbose=False, error=False,
              _fast_abort=False):
        '''Summation using the Euler-Maclaurin formula'''
        res = mp.sumem(f, interval, tol, reject, integral, adiffs, bdiffs,
                       verbose, error, _fast_abort)
        return res


# 14.3.3 Summation using the Abel-Plana formula

    def sumap(self, f, interval, integral=None, error=False):
        '''Summation using the Abel-Plana formula'''
        res = mp.sumap(f, interval, integral, error)
        return res


# 14.3.4 Products

    def nprod(self, f, interval, nsum=False, **kwargs):
        '''Products'''
        res = mp.nprod(f, interval, nsum, **kwargs)
        return res


# 14.3.5 Limits, general

    def limit(self, f, x, direction=1, exp=False, **kwargs):
        '''Limits, general'''
        res = mp.limit(f, x, direction, exp, **kwargs)
        return res


# 14.3.6 Richardson extrapolation

    def richardson(self, seq):
        '''Richardson extrapolation'''
        res = mp.richardson(seq)
        return res


# 14.3.7 Shanks extrapolation

    def shanks(self, seq, table=None, randomized=False):
        '''Shanks extrapolation'''
        res = mp.shanks(seq, table, randomized)
        return res


# 14.3.8 Levin extrapolation

    def levin(self, method='levin', variant='u'):
        '''Levin extrapolation'''
        res = mp.levin(method, variant)
        return res


# 14.3.9 Cohan alternating extrapolation

    def cohen_alt(self):
        '''Cohan alternating extrapolation'''
        res = mp.cohen_alt()
        return res


# %%%  14.4 Numerical differentiation and ordinary differential equations

# 14.4.1 Numerical derivatives

    def diff(self, f, x, n=1, **options):
        '''Numerical derivatives'''
        res = mp.diff(f, x, n, **options)
        return res


# 14.4.2 Nth derivative

    def diffs(self, f, x, n=None, **options):
        '''Nth derivative'''
        res = mp.diffs(f, x, n, **options)
        return res


# 14.4.3 Forward difference

# 14.4.4 Generating a sequence of derivatives


# 14.4.5 Composition of derivatives

    def diffs_prod(self, factors):
        '''Composition of derivatives'''
        res = mp.diffs_prod(factors)
        return res


# 14.4.6 Composition of exponential of derivatives

    def diffs_exp(self, fdiffs):
        '''Composition of exponential of derivatives'''
        res = mp.diffs_exp(fdiffs)
        return res


# 14.4.7 Fractional derivatives / differintegration

    def differint(self, f, x, n=1, x0=0):
        '''Fractional derivatives / differintegration'''
        res = mp.differint(f, x, n, x0)
        return res


# 14.4.8 Solving the ODE initial value problem

    def odefun(self, F, x0, y0, tol=None, degree=None, method='taylor',
               verbose=False):
        '''Solving the ODE initial value problem'''
        res = mp.odefun(F, x0, y0, tol, degree, method, verbose)
        return res


# %%%  14.5 Numerical integration

# 14.5.1 Standard quadrature

    def quad(self, f, *points, **kwargs):
        '''Solving the ODE initial value problem'''
        res = mp.quad(f, *points, **kwargs)
        return res


# 14.5.2 Doubly exponential quadrature

# 14.5.3 Gauss-Legendre quadrature


# 14.5.4 Quadrature with subdivision

    def quadsubdiv(self, f, interval, tol=None, maxintervals=None,  **kwargs):
        '''Quadrature with subdivision'''
        res = mp.quadsubdiv(f, interval, tol, maxintervals, **kwargs)
        return res


# 14.5.5 Quadrature of oscillatory functions

    def quadosc(self, f, interval, omega=None, period=None, zeros=None):
        '''Quadrature of oscillatory functions'''
        res = mp.quadosc(f, interval, omega, period, zeros)
        return res


# %%%  14.6 Numerical inverse Laplace transform

# 14.6.1 Standard inverse Laplace transform

    def invertlaplace(self, f, t, **kwargs):
        '''Standard inverse Laplace transform'''
        res = mp.invertlaplace(f, t, **kwargs)
        return res


# 14.6.2 Talbot method: inverse Laplace transform


# 14.6.3 Stehfest method: inverse Laplace transform


# 14.6.4 de Hoog, Knight, and Stokes method: inverse Laplace transform


# %%%  14.7 Function approximation


# 14.7.1 Taylor series

    def taylor(self, f, x, n, **options):
        '''Taylor series'''
        res = mp.taylor(f, x, n, **options)
        return res


# 14.7.2 Pade approximation

    def pade(self, a, L, M):
        '''Taylor series'''
        res = mp.pade(a, L, M)
        return res


# 14.7.3 Chebyshev approximation

    def chebyfit(self, f, interval, N, error=False):
        '''Taylor series'''
        res = mp.chebyfit(f, interval, N, error)
        return res


# 14.7.4 Fourier series

    def fourier(self, f, interval, N):
        '''Fourier series'''
        res = mp.fourier(f, interval, N)
        return res

# 14.7.5 Fourier series evaluation
    def fourierval(self, series, interval, x):
        '''Fourier series evaluation'''
        res = mp.fourierval(series, interval, x)
        return res


# %%%  14.8 Number identification


# 14.8.1 Constant recognition

    def pslq(self, x, tol=None, maxcoeff=1000, maxsteps=100, verbose=False):
        '''Constant recognition'''
        res = mp.pslq(x, tol, maxcoeff, maxsteps, verbose)
        return res


# 14.8.2 Algebraic identification

    def findpoly(self, x, n=1, **kwargs):
        '''Algebraic identification'''
        res = mp.findpoly(x, n, **kwargs)
        return res


# 14.8.3 Integer relations (PSLQ)

    def identify(self, x, constants=[], tol=None, maxcoeff=1000, full=False,
                 verbose=False):
        '''Integer relations (PSLQ)'''
        res = mp.identify(x, constants, tol, maxcoeff, full, verbose)
        return res





# %% 06 Inferential statistics



# %%%  06.1 Tests for 1 sample


    def stats_tests_1sample(self):
        return ctx_stats_tests_1sample(self)



# %%%  06.2 Tests for 2 independent samples


    def stats_tests_2_independent_samples(self):
        return ctx_stats_tests_2_independent_samples(self)




# %%%  06.3 Tests for 2 correlated samples


    def stats_tests_2_correlated_samples(self):
        return ctx_stats_tests_2_correlated_samples(self)




# %%%  06.4 Anova and MCP


    def stats_tests_anova(self):
        return ctx_stats_tests_anova(self)



# %%%  06.5 Nonparametric tests


    def stats_nonparametric_tests(self):
        return ctx_stats_nonparametric_tests(self)



# %%%  06.6 Multivariate tests


    def stats_multivariate_tests(self):
        return ctx_stats_multivariate_tests(self)






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

    def zeta(self, s, derivative=0):
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
        '''Hardy-Riemann-Siegel theta function'''
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


### !!! Missing in documentation, move to chi-squared !!!
##    def chi_squared_nc_0f1_nc_pdf(self, x, nu, lambda1):
##        x = self.t(x)
##        nu = self.t(nu)
##        res = self.exp(-lambda1/2) * self.chi2_pdf(x, nu)
##        res = res * self.hyp0f1(nu/2, x * lambda1 / 4)
##        return res


# %%%  10.2 Bessel functions


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


# 10.2.3 First derivative of the Bessel function of the 1st kind: 𝐽′𝜈(𝑥)

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


# 12.3.3 Legendre function of the second kind, 𝑄𝑙(𝑥)

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
        l = self.t(l)
        m = self.t(m)
        theta = self.t(theta)
        phi = self.t(phi)
        return self._fm4(mpm.spherical_y, l, m, theta, phi)


# 12.3.6 Toroidal harmonics, P

    def toroidal_plm(self, l, m, z):
        '''Toroidal harmonics, P'''
        l = self.t(l)
        m = self.t(m)
        z = self.t(z)
        return self._fm3(mpm.toroidal_plm, l, m, z)


# 12.3.7 Toroidal harmonics, Q

    def toroidal_qlm(self, l, m, z):
        '''Toroidal harmonics, Q'''
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


# 12.7.4 Struve function M

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



# 16.2 Basic classical statistical tests for 2 independent sample (stratified)

# 16.2.1 Student t-test for 2 independent samples: tests (p-values)

    def student_t_2isamples_test(self, n1, n2, mean1, mean2, stdev1, stdev2, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 2 independent samples'''
        return stat.student_t_2isamples_test(self, n1, n2, mean1, mean2, stdev1, stdev2, alpha, **kwargs)




# 8.1 Basic classical statistical tests for 2 correlated sample

# 8.1.1 Student t-test for 2 correlated samples: tests (p-values)

    def student_t_2csamples_test(self, n, mean1, mean2, stdev1, stdev2, rho, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 2 correlated samples'''
        return stat.student_t_2csamples_test(self, n, mean1, mean2, stdev1, stdev2, rho, alpha, **kwargs)




# 16.4 Anova, orthogonal polynomials, and AOM

# 16.4.1 Anova: tests (p-values)

    def anova_test(self, n, mean, stdev, alpha=0.05, **kwargs):
        '''Returns results for Anova'''
        return stat.anova_test(self, n, mean, stdev, alpha, **kwargs)



# 16.5 Multiple comparisons of means

# 16.5.1 Scheffe-test: tests (p-values)

    def scheffe_test(self, n, mean, stdev, alpha=0.05, **kwargs):
        '''Returns results for the Scheffe-test'''
        return stat.scheffe_test(self, n, mean, stdev, alpha, **kwargs)




# 16.6 Nonparametric statistical tests, 1 or 2 samples

# 16.6.1 sign-test: tests (p-values)

    def sign_test(self, n, mean1, mean2, std, alpha=0.05, **kwargs):
        '''Returns results for the sign-test'''
        return stat.sign_test(self, n, mean1, mean2, std, alpha, **kwargs)




# 16.7 Nonparametric statistical tests, k samples

# 16.6.1 Jonckheere-Terpsta S test: tests (p-values)

    def jterpsta_test(self, n, mean1, mean2, std, alpha=0.05, **kwargs):
        '''Returns results for the jterpsta_test'''
        return stat.jterpsta_test(self, n, mean1, mean2, std, alpha, **kwargs)




# 16.8 Multivariate statistical tests

# 16.8.1 Multiple linear regression: tests (p-values)

    def multlinreg_test(self, n, mean1, mean2, std, alpha=0.05, **kwargs):
        '''Returns results for multiple linear regression'''
        return stat.multlinreg_test(self, n, mean1, mean2, std, alpha, **kwargs)





# 5.4.31 Student t distribution, pdf

    def student_t_pdf(self, x, df):
        '''Returns the Student t distribution, pdf'''
        return ctxm.student_t_pdf(self, x, df)

# 5.4.32 Student t distribution, cdf and sf
    def student_t_cdf(self, x, df, cdf=True, **kwargs):
        '''Returns the Student t distribution, cdf and sf'''
        return ctxm.student_t_cdf(self, x, df, cdf, **kwargs)

# 5.4.33 Student t distribution, qtf and isf
    def student_t_qtf(self, prob, df, qtf=True, **kwargs):
        '''Returns the Student t distribution, qtf and isf'''
        return ctxm.student_t_qtf(self, prob, df, qtf, **kwargs)


