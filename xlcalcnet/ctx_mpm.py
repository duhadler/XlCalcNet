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


from xlcalcnet import mathmp, mathstr
from xlcalcnet.mpmath import mp
from xlcalcnet import ctx_shared
from xlcalcnet import ctx07StatDataAnalysis
from xlcalcnet import ctx11PmfVector

ctxm = ctx_shared.ctxUtil()
stat = ctx07StatDataAnalysis.inferential_statistics()
#pmfvec = ctx11PmfVector


# class mpm():
class mpm():
    ''' a numerical class in arbitrary precision '''

    # %% General functions

    def pmfvec(self):
        return ctx11PmfVector

    def __init__(self):
        pass

    def prec_(self, n):
        mp.prec = n
        self._prec = mp.prec
        self._dps = mp.dps

    def dps_(self, n):
        mp.dps = n
        self._prec = mp.prec
        self._dps = mp.dps

    def getprec_(self):
        return self._prec

    def getdps_(self):
        return self._dps


# %% 02 Contexts and a minimal set of context functions


# %%%  2.4 Contexts in xlcalcnet: common interface


# 2.4.1 A minimal set of context functions


    @property
    def name(self):
        ''' returns the name of the class as string '''
        return "mpm"

    @property
    def fmtname(self):
        return "    mpm"

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
        return mp.mpf

    @property
    def complextype(self):
        return mp.mpc




# 2.3.2 Creating a real number

    def mpf(self, x):
        ''' returns a real number of type mpf '''
        x = self.t(x)
        return mp.mpf(x)

# 2.4.3 Creating a complex number

    def mpc(self, x, y=None):
        ''' returns a complex number of type mpc '''
        z = self.t(x, y)
        return mp.mpc(z)


# 2.1.4 Getting and setting the current precision (in bits)

    @property
    def prec(self):
        ''' gets or sets the current binary precision (in bits) as
        integer '''
        return mp.prec

    @prec.setter
    def prec(self, value):
        mp.prec = int(value)


# 2.1.5 Getting and setting the current decimal precision (in digits)

    @property
    def dps(self):
        ''' gets or sets the current decimal precision (in digits) as
        integer '''
        return mp.dps

    @dps.setter
    def dps(self, value):
        mp.dps = int(value)


# 2.1.6 Getting and setting the current decimal precision (in digits)

    @property
    def pretty(self):
        ''' gets or sets whether pretty formatting is active '''
        return mp.pretty

    @pretty.setter
    def pretty(self, value):
        mp.pretty = bool(value)


# %%%  2.2 Arithmetic operations

# This is implemented in mp, iv, dp


# 2.2.1 Addition using a custom precision and rounding mode

    def fadd(self, x, y, **kwargs):
        """ returns the sum of x and y """
        return mp.fadd(x, y, **kwargs)


# 2.2.2 Subtraction using a custom precision and rounding mode

    def fsub(self, x, y, **kwargs):
        ''' returns the difference of x and y '''
        return mp.fsub(x, y, **kwargs)


# 2.2.3 Negation of a number using a custom precision and rounding mode

    def fneg(self, x, **kwargs):
        ''' returns the negation of x '''
        return mp.fneg(x, **kwargs)


# 2.2.4 Multiplication using a custom precision and rounding mode

    def fmul(self, x, y, **kwargs):
        ''' returns the product of x and y '''
        return mp.fmul(x, y, **kwargs)


# 2.2.5 Division using a custom precision and rounding mode

    def fdiv(self, x, y, **kwargs):
        ''' returns the quotient of x and y '''
        return mp.fdiv(x, y, **kwargs)


# 2.2.6 Modular division (real numbers only)

    def fmod(self, x, y):
        ''' returns x mod y '''
        return mp.fmod(x, y)


# 2.2.7 Sum of a finite number of terms

    def fsum(self, terms, absolute=False, squared=False):
        ''' returns the sum of terms '''
        return mp.fsum(terms, absolute, squared)


# 2.2.8 Product of a finite number of factors

    def fprod(self, factors):
        ''' returns the product of factors '''
        return mp.fprod(factors)


# 2.2.9 Dot product

    def fdot(self, A, B=None, conjugate=False):
        ''' returns the dot product of A and B '''
        return mp.fdot(A, B, conjugate)


# %%%  2.3 Functions related to intervals and balls

# 2.3.1 Middle value of an interval or ball

    def mid(self, z):
        ''' returns the middle value of an interval or ball '''
        z = self.t(z)
        return z


# 2.3.2 Radius of an interval or ball

    def radius(self, z):
        ''' returns the Radius of an interval or ball '''
        return self.t(0)


# 2.3.3 Left border of an interval or ball

    def left(self, z):
        ''' returns the left border of an interval or ball '''
        z = self.t(z)
        return z


# 2.3.4 Right border of an interval or ball

    def right(self, z):
        ''' returns the right border of an interval or ball '''
        z = self.t(z)
        return z


# 2.3.5 Absolute value of the left end of an interval

    def absmin(self, z):   # infimum
        ''' returns the absolute value of the left end of an interval '''
        return mp.absmin(z)


# 2.3.6 Absolute value of the right end of an interval

    def absmax(self, z):   # supremum
        ''' returns the absolute value of the right end of an interval '''
        return mp.absmax(z)


# %%%  2.4 Complex components

# 2.4.1 Absolute value of a real or complex number

    def abs(self, z):
        ''' returns the absolute value of a real or complex number '''
        z = self.t(z)
        return mp.fabs(z)

    def fabs(self, z):
        ''' returns the absolute value of a real or complex number '''
        z = self.t(z)
        return mp.fabs(z)


# 2.4.2 Sign of a real or complex number

    def sign(self, z):
        ''' returns the sign of a real or complex number '''
        z = self.t(z)
        return mp.sign(z)


# 2.4.3 Real part of a real or complex number

    def re(self, z):
        ''' returns the real part of a real or complex number '''
        z = self.t(z)
        return mp.re(z)


# 2.4.3 Real part of a real or complex number

    def real(self, z):
        ''' returns the real part of a real or complex number '''
        z = self.t(z)
        return mp.re(z)


# 2.4.4 Imaginary part of a real or complex number

    def im(self, z):
        ''' returns the imaginary part of a real or complex number '''
        z = self.t(z)
        return mp.im(z)


# 2.4.4 Imaginary part of a real or complex number

    def imag(self, z):
        ''' returns the imaginary part of a real or complex number '''
        z = self.t(z)
        return mp.im(z)


# 2.4.5 Argument (or phase) of a real or complex number

    def arg(self, z):
        ''' returns the argument (or phase) of a real or complex number '''
        z = self.t(z)
        return mp.arg(z)


# 2.4.5 Argument (or phase) of a real or complex number

    def phase(self, z):
        ''' returns the argument (or phase) of a real or complex number '''
        z = self.t(z)
        return mp.arg(z)


# 2.4.6 Conjugate of a real or complex number

    def conj(self, z):
        ''' returns the conjugate of a real or complex number '''
        z = self.t(z)
        return mp.conj(z)


# 2.4.7 Polar representation of a real or complex number

    def polar(self, z):
        ''' returns the polar representation of a real or complex number '''
        z = self.t(z)
        return mp.polar(z)


# 2.4.8 Rectangular coordinates calculated from the polar representation of a
    # real or complex number

    def rect(self, r, phi):
        '''
        returns the rectangular coordinates calculated from the polar
        representation of a real or complex number
        '''
        z = self.t(z)
        return mp.rect(r, phi)


# %%%  2.5 Integer and fractional parts

# 2.5.1 Floor of a real or complex number

    def floor(self, z):
        ''' returns the floor of a real or complex number '''
        z = self.t(z)
        return mp.floor(z)


# 2.5.2 Ceiling of a real or complex number

    def ceil(self, z):
        ''' returns the ceiling of a real or complex number '''
        z = self.t(z)
        return mp.ceil(z)


# 2.5.3 Nearest integer(s) of a real or complex number

    def nint(self, z):
        ''' returns the nearest integer(s) of a real or complex number '''
        z = self.t(z)
        return mp.nint(z)


# 2.5.4 Fractional part of a real or complex number

    def frac(self, z):
        ''' returns the fractional part of a real or complex number '''
        z = self.t(z)
        return mp.frac(z)


# %%%  2.6 Tolerances and approximate comparisons

# 2.6.1 Chopping off small real or imaginary parts

    def chop(self, x, tol=None):
        ''' Chopping off small real or imaginary parts '''
        return mp.chop(x, tol)


# 2.6.2 Testing if 2 numbers are almost equal

    def almosteq(self, s, t, rel_eps=None, abs_eps=None):
        ''' Testing if 2 numbers are almost equal '''
        return mp.almosteq(s, t, rel_eps, abs_eps)


# %%%  2.7 Properties of numbers


# 2.7.1 Testing for a real number in a given context

    def ismpf(self, z):
        ''' Testing for a real number in a given context '''
        return isinstance(z, mp.mpf)


# 2.7.2 Testing for a complex number in a given context

    def ismpc(self, z):
        ''' Testing for a complex number in a given context '''
        return isinstance(z, mp.mpc)


# 2.7.3 Testing if a real or complex number is infinite

    def isinf(self, z):
        ''' Testing if a real or complex number is infinite '''
        return mp.isinf(z)


# 2.7.4 Testing if a real or complex number is NaN

    def isnan(self, z):
        ''' Testing if a real or complex number is NaN '''
        return mp.isnan(z)


# 2.7.5 Testing if a real or complex number is "normal"

    def isnormal(self, z):
        ''' Testing if a real or complex number is "normal" '''
        return mp.isnormal(z)


# 2.7.6 Testing if a real or complex number is finite

    def isfinite(self, z):
        ''' Testing if a real or complex number is finite '''
        return mp.isfinite(z)


# 2.7.7 Testing if a real or complex number is integer-valued

    def isint(self, z):
        ''' Testing if a real or complex number is integer-valued '''
        return mp.isint(z)


# 2.7.8 Calculating x * 2^n efficiently for a real number

    def ldexp(self, x, n):
        ''' Calculating x * 2^n efficiently for a real number '''
        return mp.ldexp(x, n)


# 2.7.9 Calculating (y,n) such that  x = y * 2^n (real numbers only)

    def frexp(self, x):
        ''' Calculating (y,n) such that  x = y * 2^n (real numbers only) '''
        return mp.frexp(x)


# 2.7.10 Quick logarithmic magnitude estimate

    def mag(self, x):
        ''' Quick logarithmic magnitude estimate '''
        return mp.mag(x)


# 2.7.11 Nearest integer and distance estimate

    def nint_distance(self, x):
        ''' Nearest integer and distance estimate '''
        return mp.nint_distance(x)


# %%%  2.8 Number generation

# 2.8.1 "Lazy" representation of a fraction

    def fraction(self, p, q):
        ''' "Lazy" representation of a fraction '''
        return mp.fraction(p, q)


# 2.8.2 Generation of random numbers

    def rand(self):
        ''' Generation of random numbers '''
        return mp.rand()


# 2.8.3 Generation of a list of real numbers

    def arange(self, *args):
        ''' Generation of a list of real numbers '''
        return mp.arange(*args)


# 2.8.4 Generation of a list of evenly spaced real numbers

    def linspace(self, *args, **kwargs):
        ''' Generation of a list of evenly spaced real numbers '''
        return mp.arange(*args, **kwargs)


# %%%  2.9 Exact mathematical constants

# 2.9.1 Zero

    @property
    def zero(self):
        ''' returns zero '''
        return mp.zero


# 2.9.2 One

    @property
    def one(self):
        ''' returns one '''
        return mp.one


# 2.9.3 Imaginary unit

    @property
    def j(self):
        ''' returns the imaginary unit '''
        return mp.j


# 2.9.4 Positive Infinity

    @property
    def inf(self):
        ''' returns positive infinity '''
        return mp.inf


# 2.9.5 Negative Infinity

    @property
    def ninf(self):
        ''' returns negative infinity '''
        return mp.ninf


# 2.9.6 Not-a-Number: NaN

    @property
    def nan(self):
        ''' returns Not-a-Number: NaN '''
        return mp.nan



# %%%  2.10 Approximate mathematical constants

# 2.10.1 Machine Epsilon

    @property
    def eps(self):
        ''' returns the machine epsilon '''
        return +mp.eps()


# 2.10.2 Log2 (ln(2))

    @property
    def ln2(self):
        ''' returns the natural logarithm of 2 '''
        return +mp.ln2


# 2.10.3 Log10 (ln(10))

    @property
    def ln10(self):
        ''' returns the natural logarithm of 10 '''
        return +mp.ln10


# 2.10.4 Pi (pi)

    @property
    def pi(self):
        ''' returns pi '''
        return +mp.pi


# 2.10.5 Euler e (exp(1)

    @property
    def e(self):
        ''' returns Euler's e (exp(1) '''
        return +mp.e


# 2.10.6 Euler-Mascheroni constant gamma

    @property
    def euler(self):
        ''' returns the Euler-Mascheroni constant gamma '''
        return +mp.euler


# 2.10.7 Golden ratio phi

    @property
    def phi(self):
        ''' returns the Golden ratio phi '''
        return +mp.phi


# 2.10.8 Catalan's constant

    @property
    def catalan(self):
        ''' returns Catalan's constant '''
        return +mp.catalan


# 2.10.9 Khinchin's constant

    @property
    def khinchin(self):
        ''' returns Khinchin's constant '''
        return +mp.khinchin


# 2.10.10 Glaisher's constant

    @property
    def glaisher(self):
        ''' returns Glaisher's constant '''
        return +mp.glaisher


# 2.10.11 Apéry's constant

    @property
    def apery(self):
        ''' returns Apéry's constant '''
        return +mp.apery


# 2.10.12 Degree

    @property
    def degree(self):
        ''' returns degree = pi/180 '''
        return +mp.degree


# %%%  2.11 Utility functions


# 2.11.1 Convertion of scalars

    def t(self, x, y=None):
        ''' Convertion of scalars '''
        #return mathmp.convert(x, y)
        return mathstr.t_mpm(x, y)


# 2.11.1 Convertion of scalars

    def convert(self, x, y=None):
        ''' Convertion of scalars '''
        return mathmp.convert(x, y)


# 2.11.1 Convertion of scalars

    def mpmathify(self, x, y=None):
        ''' Convertion of scalars '''
        return mathmp.convert(x, y)

# 2.11.1 Union of 2 scalars
    # this is missing for this data type


# 2.11.3 Decimal string literals with n significant digits (scalars, lists,
    # tuples, matrices)

    def nstr(self, x, n=6, **kwargs):
        '''
        Decimal string literals with n significant digits
        (scalars, lists, tuples, matrices)
        '''
        return mp.nstr(x, n, **kwargs)


# 2.11.4 Printing with nsignificant digits (scalars, lists, tuples, matrices)

    def nprint(self, x, n=6, **kwargs):
        '''
        Printing with nsignificant digits
        (scalars, lists, tuples, matrices)
        '''
        mp.nprint(x, n, **kwargs)


# 2.11.5 Tabular show
# !!! missing in documentation !!!

    def show(self, items, aligned=True):
        ''' Tabular show '''
        mathmp.show(items, aligned)


# dispose later


    def to_float(self, z):
        return float(z)

    def to_mpf(self, z):
        return mp.mpf(z)

    def from_mpf(self, z):
        return mp.mpf(z)


# %%%  2.12 Precision management

# 2.12.1 Automatic precision management

    def autoprec(self, f, maxprec=None, catch=(), verbose=False):
        ''' Automatic precision management '''
        return mp.autoprec(f, maxprec, catch, verbose)


# 2.12.2 Temporarily setting the working precision (prec)

    def workprec(self, n, normalize_output=False):
        ''' Temporarily setting the working precision (prec) '''
        return mp.workprec(n, normalize_output)


# 2.12.3 Temporarily setting the decimal precision (dps)

    def workdps(self, n, normalize_output=False):
        ''' Temporarily setting the decimal precision (dps) '''
        return mp.workdps(n, normalize_output)


# 2.12.4 Temporarily adding working precision (prec)

    def extraprec(self, n, normalize_output=False):
        ''' Temporarily adding working precision (prec) '''
        return mp.extraprec(n, normalize_output)


# 2.12.5 Temporarily adding decimal precision (dps)

    def extradps(self, n, normalize_output=False):
        ''' Temporarily adding decimal precision (dps) '''
        return mp.extradps(n, normalize_output)


# %%%  2.13 Performance and debugging

# 2.13.1 Reusing computed values, given a minimal precision

    def memoize(self, f):
        ''' Reusing computed values, given a minimal precision '''
        return mp.memoize(f)


# 2.13.2 Setting the maximal number of function calls

    def maxcalls(self, f, N):
        ''' Setting the maximal number of function calls '''
        return mp.maxcalls(f, N)

# monitor and timing are not ctx functions


# %%%  2.14 Additonal functionality

# 2.14.1 plotting of 2D functions
# !!! missing in documentation !!!

    def plot(self, f, xlim=[- 5, 5], ylim=None, points=200, file=None,
             dpi=None, singularities=[], axes=None):
        ''' plotting of 2D functions '''
        res = mp.plot(f, xlim, ylim, points, file, dpi, singularities, axes)
        return res


# %% 03 Scalar elementary functions


# %%%  3.1 Exponential and related functions

# 3.1.1 Exponential function exp(x)

    def exp(self, z):
        '''Returns exp(z), the exponential function of z.'''
        z = self.t(z)
        return mp.exp(z)


# 3.1.2 Exponential function expj

    def expj(self, z):
        '''Returns expj(z) = cos(z) + i * sin(z).'''
        z = self.t(z)
        return mp.expj(z)


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

    def logb(self, z, b):
        '''Returns the base b logarithm of z, logb(z,b) = ln(z)/ln(b).'''
        z = self.t(z)
        b = self.t(b)
        return mp.log(z, b)


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
        return mp.power(a, b)


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
        return mp.sin(z)


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
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.sinpi(z) / mp.cospi(z)

    def cotpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.cospi(z) / mp.sinpi(z)

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


# 3.4.14 Auxiliary function cospi = cos(pi*z)

    def cospi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.cospi(z)


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
        return mp.acoth(z)


# 3.7.7 Inverse Gudermannian function arcgd(x) = atanh(sin(x))

    def arcgd(self, z):
        '''Returns the inverse Gudermannian function,
        arcgd(x) = atanh(sin(x)).'''
        z = self.t(z)
        return mp.atanh(mp.sin(z))


# %%%  3.8 Factorials and related functions

# 3.8.1 Factorial

    def factorial(self, z):
        '''Returns the factorial of z, z! = Gamma(z+1).'''
        z = self.t(z)
        return mp.factorial(z)


# 3.8.2 Binomial coefficient

    def binomial(self, n, k):
        '''Returns binomial(n, k), the binomial coefficient n!/(k!(n-k)!) .'''
        n = self.t(n)
        k = self.t(k)
        return mp.factorial(n) / (mp.factorial(k) * mp.factorial(n - k))

# 3.8.3 Multinomial coefficient
    def multinomial(self, n, k):
        '''NOT IMPLEMENTED.'''
        raise Exception("NOT IMPLEMENTED")


# 3.8.4 Rising factorial (Pochhammer symbol)

    def rf(self, z, n):
        '''Returns the rising factorial (or Pochhammer symbol).'''
        z = self.t(z)
        n = self.t(n)
        return mp.rf(z, n)


# 3.8.5 Falling factorial

    def ff(self, z, n):
        '''Returns the falling factorial.'''
        z = self.t(z)
        n = self.t(n)
        return mp.ff(z, n)


# 3.8.6 Double factorial

    def fac2(self, z):
        '''Returns the double factorial.'''
        z = self.t(z)
        return mp.fac2(z)


# %%%  3.9 Gamma function and related functions

# 3.9.1 Gamma function

    def gamma(self, z):
        '''Returns the Gamma function.'''
        z = self.t(z)
        return mp.gamma(z)


# 3.9.2 Reciprocal Gamma function

    def rgamma(self, z):
        '''Returns the Reciprocal Gamma function.'''
        z = self.t(z)
        return mp.rgamma(z)


# 3.9.3 Log-Gamma function

    def loggamma(self, z):
        '''Returns the Log-Gamma function.'''
        z = self.t(z)
        return mp.loggamma(z)


# 3.9.4 Beta function

    def beta(self, a, b):
        '''Returns the Beta function.'''
        a = self.t(a)
        b = self.t(b)
        return mp.beta(a, b)


# 3.9.5 Log-Beta function

    def logbeta(self, a, b):
        '''Returns the Log-Beta function.'''
        a = self.t(a)
        b = self.t(b)
        return mp.ln(mp.beta(a, b))


# 3.9.6 Ratio of gamma functions

    def gamma_ratio(self, a, b):
        '''Returns the ratio of gamma functions.'''
        a = self.t(a)
        b = self.t(b)
        return mp.gamma(a) / mp.gamma(b)


# 3.9.7 Gamma-delta ratio

    def gamma_delta_ratio(self, a, delta):
        '''Returns the Gamma-delta ratio.'''
        a = self.t(a)
        delta = self.t(delta)
        return mp.gamma(a) / mp.gamma(a + delta)


# 3.9.8 Catalan function

    def catalan_c(self, z):
        '''Returns the Catalan function.'''
        z = self.t(z)
        t = mp.gamma(z+1)
        return mp.gamma(2*z+1) / ((z+1)*t*t)


# %% 04 Real scalar functions


# %%% 4.1 Error functions for real arguments

# 4.1.1 Error function erf

    def real_erf(self, x):
        '''Returns the Error function erf.'''
        x = self.t(x)
        return mp.erf(x)


# 4.1.2 Complementary error function erfc

    def real_erfc(self, x):
        '''Returns the Complementary error function erfc.'''
        x = self.t(x)
        return mp.erfc(x)


# 4.1.3 Inverse of the real error function

    def real_erfinv(self, prob):
        '''Returns the Inverse of the real error function.'''
        prob = self.t(prob)
        return mp.erfinv(prob)


# 4.1.4 Inverse of the real complementory error function

    def real_erfcinv(self, prob):
        '''Returns the Inverse of the real complementory error function.'''
        prob = self.t(prob)
        return mp.erfinv(1-prob)


# 4.1.5 Standard normal density function

    def ndens(self, z):
        '''Returns the Standard normal density function.'''
        z = self.t(z)
        a = mp.exp(-0.5*z*z)/mp.sqrt(2*mp.pi)
        return a


# 4.1.6 Standard normal cumulative distribution function

    def ndis(self, x):
        '''Returns the Standard normal cumulative distribution function.'''
        x = self.t(x)
        a = 0.5 * mp.erfc(-x/mp.sqrt(mp.mpf(2)))
        return a


# 4.1.7 Standard normal percentage point function

    def ndis_inv(self, q):
        '''Returns the Standard normal percentage point function.'''
        q = self.t(q)
        a = -mp.sqrt(2) * self.real_erfinv(2*q)
        return a

    def ndisx(self, L, R):
        '''Returns the Standard normal percentage point function.'''
        return ctxm.ndisx_erf(self, L, R)

    def cplxerfc(self, z):
        '''Returns the complex error function.'''
        z = self.t(z)
        x = self.real(z)
        if x < 0:
            y = -z
            return mp.erfc(y)
        else:
            return mp.erfc(z)

#    def cplxerfc2(self, z):
#        z = self.t(z)
#        res = arb().erfc(z)
#        res = self.t(res)
#        return res

    def cplxndis(self, z):
        '''Returns the complex standard normal percentage point function.'''
        # x = mp.mpf(x)
        z = self.t(z)
        a = 0.5 * self.cplxerfc(-z/mp.sqrt(mp.mpf(2)))
        return a

#    def cplxndis2(self, z):
#        #x = mp.mpf(x)
#        z = self.t(z)
#        x = 0.5 * arb().erfc(-z/mp.sqrt(mp.mpf(2)))
#        res = self.t(x)
#        return res


# %%% 4.2 Incomplete gamma functions for non-negative real arguments and
    # parameters


# 4.2.1 Real lower non-normalised incomplete gamma function

    def real_gamma_lower(self, a, x, **kwargs):
        '''Returns the Real lower non-normalised incomplete gamma function.'''
        res = self.real_gamma_p(a, x, **kwargs)
        return res * self.gamma(a)


# 4.2.2 Real upper non-normalised incomplete gamma function

    def real_gamma_upper(self, a, x, **kwargs):
        '''Returns the Real upper non-normalised incomplete gamma function.'''
        res = self.real_gamma_q(a, x, **kwargs)
        return res * self.gamma(a)


# 4.2.3 Real lower normalised incomplete gamma function

    def real_gamma_p(self, a, x, **kwargs):
        '''Returns the Real lower normalised incomplete gamma function.'''
        a = self.t(a)
        x = self.t(x)
        return ctxm.real_gamma_p(self, a, x, **kwargs)


# 4.2.4 Real upper normalised incomplete gamma function

    def real_gamma_q(self, a, x, **kwargs):
        '''Returns the Real upper normalised incomplete gamma function.'''
        a = self.t(a)
        x = self.t(x)
        return ctxm.real_gamma_q(self, a, x, **kwargs)


# 4.2.5 Tricomi’s entire incomplete gamma function

    # move to special functions
    def real_gamma_tricomi(self, a, x, **kwargs):
        '''Returns Tricomi’s entire incomplete gamma function.'''
        res = self.real_gamma_p(a, x, **kwargs)
        return res * self.power(x, -self.t(a))


# 4.2.6 Inverse of the real lower normalised incomplete gamma function

    def real_gamma_p_inv(self, a, p, **kwargs):
        '''Returns the Inverse of the real lower normalised incomplete gamma
        function.'''
        a = self.t(a)
        p = self.t(p)
        return ctxm.real_gamma_p_inv(self, a, p, **kwargs)


# 4.2.7 Inverse of the real upper normalised incomplete gamma function

    def real_gamma_q_inv(self, a, q, **kwargs):
        '''Returns the Inverse of the real upper normalised incomplete gamma
        function.'''
        a = self.t(a)
        q = self.t(q)
        return ctxm.real_gamma_q_inv(self, a, q, **kwargs)


# 4.2.10 Derivative of the incomplete gamma function

    def real_gamma_derivative(self, a, x):
        '''Returns the Derivative of the incomplete gamma function.'''
        a = self.t(a)
        x = self.t(x)
        return self.exp(-x) * self.power(x, a-1) / self.gamma(a)


# %%%  4.3 Incomplete beta functions for non-negative real arguments and
    # parameters

# 4.3.1 Non-normalised incomplete beta function

    def real_beta3(self, a, b, x, **kwargs):
        '''Returns the Non-normalised incomplete beta function.'''
        res = self.real_ibeta(a, b, x, **kwargs)
        return res * self.beta(a, b)


# 4.3.2 Non-normalised complement of the incomplete beta function

    def real_betac(self, a, b, x, **kwargs):
        '''Returns the Non-normalised complement of the incomplete beta
        function.'''
        res = self.real_ibetac(a, b, x, **kwargs)
        return res * self.beta(a, b)


# 4.3.3 Normalised incomplete beta function

    def real_ibeta(self, a, b, x, **kwargs):
        '''Returns the Normalised incomplete beta function.'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return ctxm.real_ibeta(self, a, b, x, **kwargs)


# 4.3.4 Normalised complementory incomplete beta function

    def real_ibetac(self, a, b, x, **kwargs):
        '''Returns the Normalised complementory incomplete beta function.'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return ctxm.real_ibetac(self, a, b, x, **kwargs)


# 4.3.5 Inverse of the real normalised incomplete beta function

    def real_ibeta_inv(self, a, b, prob, **kwargs):
        '''Returns the Inverse of the real normalised incomplete beta
        function.'''
        a = self.t(a)
        b = self.t(b)
        prob = self.t(prob)
        return ctxm.real_ibeta_inv(self, a, b, prob, **kwargs)

    def betadisx(self, LeftTail, Righttail, a, b, **kwargs):
        '''Returns the Inverse of the real normalised incomplete beta
        function.'''
        a = self.t(a)
        b = self.t(b)
        LeftTail = self.t(LeftTail)
        x = ctxm.real_ibeta_inv(self, a, b, LeftTail, **kwargs)
        return x, 1-x


# 4.3.6 Inverse of the real normalised complementary incomplete beta function

    def real_ibetac_inv(self, a, b, prob, **kwargs):
        '''Returns the IInverse of the real normalised complementary incomplete
        beta function.'''
        a = self.t(a)
        b = self.t(b)
        prob = self.t(prob)
        return ctxm.real_ibetac_inv(self, a, b, prob, **kwargs)


# 4.3.11 Derivative of the incomplete beta function

    def real_ibeta_derivative(self, a, b, x):
        '''Returns the Derivative of the incomplete beta function.'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return self.power(x, a-1) * self.power(1-x, b-1) / self.beta(a, b)

    def betadis(self, a, b, q, p):
        '''Returns the incomplete beta function (L, R).'''
        L, R = ctxm.betadis(self, a, b, q, p)
        return L, R

    def betadis3(self, a, b, q, p):
        '''Returns the incomplete beta function (L, R, density).'''
        L, R, density = ctxm.betadis3(self, a, b, q, p)
        return L, R, density



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






# %% 16 Inferential statistics

# 16.1 Basic classical statistical tests for 1 sample

# 16.1.1 Student t-test for 1 sample: tests (p-values)

    def student_t_1sample_test(self, n, mu0, mean, std, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (tests and CI)'''
        return stat.student_t_1sample_test(self, n, mu0, mean, std, alpha, \
            **kwargs)


    def student_t_1sample_power(self, n, mu0, mean, std, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (power)'''
        return stat.student_t_1sample_power(self, n, mu0, mean, std, alpha, \
            **kwargs)


    def student_t_1sample_samplesize(self, mu0, mean, std, alpha=0.05, \
        beta=0.10, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (power)'''
        return stat.student_t_1sample_samplesize(self, mean, mu0, std, alpha, \
            beta, **kwargs)



# 16.2 Basic classical statistical tests for 2 independent sample (stratified)

# 16.2.1 Student t-test for 2 independent samples: tests (p-values)

    def student_t_2isamples_test(self, n1, n2, mean1, mean2, stdev1, stdev2, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 2 independent samples'''
        return stat.student_t_2isamples_test(self, n1, n2, mean1, mean2, stdev1, stdev2, alpha, **kwargs)




# 16.3 Basic classical statistical tests for 2 correlated sample

# 16.3.1 Student t-test for 2 correlated samples: tests (p-values)

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








# %% 13 Descriptive statistics and matrix algebra


# %%%  13.1 Matrix functions: decompositions for linear solving


# 13.1.4 Creating a matrix as a dictionary

    def matrix(self, r, c=1):
        '''Creates  a matrix as a dictionary'''
        return mp.matrix(r, c)

    def mat_t(self, m, n):
        '''Creates  a matrix as a dictionary'''
        matA = mp.matrix(m, n)
        return matA

    def mat_show(self, matA, title="mat"):
        '''Prints a matrix'''
        for i in range(matA.rows):
            for j in range(matA.cols):
                x = matA[i, j]
                print(title+"[" + str(i) + "," + str(j)+"]: ", x)
            print()


# 13.1.5 Creating an identity matrix as a dictionary

    def eye(self, m):
        '''Creates an identity matrix as a dictionary'''
        matA = mp.eye(m)
        return matA

    def mat_identity(self, m):
        '''Creates an identity matrix as a dictionary'''
        matA = mp.eye(m)
        return matA


# 13.1.6 Creating a diagonal matrix as a dictionary

    def diag(self, vecA):
        '''Creates a diagonal matrix as a dictionary'''
        return mp.diag(vecA)


# 13.1.7 Creating a matrix of zeros as a dictionary

    def mat_zeros(self, m, n):
        '''Creates a matrix of zeros as a dictionary'''
        matA = mp.zeros(m, n)
        return matA

    def zeros(self, *args, **kwargs):
        '''Creates a matrix of zeros as a dictionary'''
        matA = mp.zeros(*args, **kwargs)
        return matA


# 13.1.8 Creating a matrix of ones as a dictionary

    def mat_ones(self, m, n):
        '''Creates a matrix of ones as a dictionary'''
        matA = mp.ones(m, n)
        return matA

    def ones(self, *args, **kwargs):
        '''Creates a matrix of ones as a dictionary'''
        matA = mp.ones(*args, **kwargs)
        return matA

    def mat_constant(self, m, n, coeff):
        '''Creates a matrix of a constant as a dictionary'''
        matA = mp.ones(m, n)
        matA = matA * coeff
        return matA


# 13.1.9 Creating a Hilbert matrix as a dictionary

    def hilbert(self, n):
        '''Creates a Hilbert matrix as a dictionary'''
        matA = mp.hilbert(n)
        return matA


# 13.1.10 Creating a random matrix as a dictionary

    def randmatrix(self, m, n):
        '''Creates a random matrix as a dictionary'''
        return mp.randmatrix(m, n)

    def mat_random(self, m, n):
        '''Creates a random matrix as a dictionary'''
        matA = mp.randmatrix(m, n)
        matB = mp.zeros(m, n)
        for i in range(m):
            for j in range(n):
                matB[i, j] = mp.mpf(matA[i, j])
        return matB

    def mat_random_complex(self, m, n):
        '''Creates a random matrix as a dictionary'''
        matA = self.mat_random(m, n) + self.mat_random(m, n) * 1j
        return matA


# 13.1.11 Swap of rows in a mpmath matrix


# 13.1.12 Extending a mpmath matrix by another column


# 13.1.13 Unit vectors

    def unitvector(self, n, i):
        '''Creates a unit vector as a dictionary'''
        return mp.unitvector(n, i)


# %%%  13.2 Methods and arithmetic operators of a mpmath matrix

# this functionality is already built in


# %%%  13.3 Norms


# 13.3.1 Vector norm of a matrix

    def norm(self, x, p=2):
        '''Returns the vector norm of a matrix'''
        return mp.norm(x, p)


# 13.3.2 Matrix norm

    def mnorm(self, A, p=1):
        '''Returns the matrix norm of a matrix'''
        return mp.mnorm(A, p=1)


# %%%  13.4 Cholesky Decomposition without Pivoting


# 13.4.1 Cholesky decomposition

    def cholesky(self, A, tol=None):
        '''Returns the Cholesky decomposition of a matrix'''
        return mp.cholesky(A, tol=None)


# 13.4.2 Cholesky decomposition, solve

    def cholesky_solve(self, A, b, **kwargs):
        '''Returns the Cholesky decomposition of a matrix, with solve'''
        return mp.cholesky_solve(A, b, **kwargs)


# %%%  13.5 LU Decomposition with partial Pivoting


# 13.5.1 Matrix LU factorization

    def lu(ctx, A):
        '''Returns the LU factorization of a matrix'''
        return mp.lu(A)


# 13.5.2 Determinant of a matrix, using LU decomposition

    def det(self, matA):   # uses  lu decomposition
        '''Returns the determinant of a matrix, using LU decomposition'''
        return mp.det(matA)


# 13.5.3 Inverse of a matrix, using the LU factorization

    def inverse(self, A, **kwargs):   # uses  lu decomposition
        '''Returns Inverse of a matrix, using the LU factorization'''
        return mp.inverse(A, **kwargs)


# 13.5.4 Linear equations: LU solve

    def lu_solve(ctx, A, b, **kwargs):
        '''LU factorization of a matrix, Linear equations: LU solve'''
        return mp.lu_solve(A, b, **kwargs)

    def lu_solve_mat(self, a, b):   # uses  lu decomposition
        '''LU factorization of a matrix, Linear equations: LU solve'''
        return mp.lu_solve_mat(a, b)


# 13.5.5 Linear equations: residual of LU solve

    def residual(self, A, x, b, **kwargs):
        '''LU factorization of a matrix, Linear equations:
        residual of LU solve'''
        return mp.residual(A, x, b, **kwargs)


# 13.5.6 Linear equations: LU improve solution

    def improve_solution(ctx, A, x, b, maxsteps=1):
        '''LU factorization of a matrix, Linear equations:
        LU improve solution'''
        return mp.improve_solution(A, x, b, maxsteps=1)


# 13.5.7 Linear equations: LU condition number

    def cond(self, A, norm=None):   # uses  lu decomposition
        '''LU factorization of a matrix, Linear equations:
        LU improve solution'''
        return mp.cond(A, norm)


# %%%  13.6 QR Decomposition without Pivoting


# 13.6.1 QR factorization

    def qr(self, A, mode='full', edps=10):
        '''Returns the QR factorization of a matrix'''
        return mp.qr(A, mode, edps)

# 13.6.2 QR solve
    def qr_solve(self, A, b, norm=None, **kwargs):
        '''Returns the QR factorization of a matrix, solve'''
        return mp.qr_solve(A, b, norm, **kwargs)


# %%%  13.7 Singular Value Decomposition, singular values and full
    # singular vectors


# 13.7.1 Real singular value decomposition of a matrix A

    def svd_r(self, A, full_matrices=False, compute_uv=True,
              overwrite_a=False):
        '''Returns the singular value decomposition of a real matrix'''
        return mp.svd_r(A, full_matrices, compute_uv, overwrite_a)


# 13.7.2 Complex singular value decomposition of a matrix A

    def svd_c(self, A, full_matrices=False, compute_uv=True,
              overwrite_a=False):
        '''Returns the singular value decomposition of a complex matrix'''
        return mp.svd_c(A, full_matrices, compute_uv, overwrite_a)


# 13.7.3 Singular value decomposition of a matrix A (real or complex)

    def svd(self, A, full_matrices=False, compute_uv=True,
            overwrite_a=False):
        '''Returns the singular value decomposition of a real or
        complex matrix'''
        return mp.svd(A, full_matrices, compute_uv, overwrite_a)


# %%%  13.8 Symmetric/Hermitian Eigensystem


# 13.8.1 Eigenvalue problem for a real symmetric square matrix A

    def eigsy(self, A, eigvals_only=False, overwrite_a=False):
        '''Returns the eigen value decomposition of a real symmetric
        square matrix'''
        return mp.eigsy(A, eigvals_only, overwrite_a)


# 13.8.2 Eigenvalue problem for a complex hermitian square matrix A

    def eighe(self, A, eigvals_only=False, overwrite_a=False):
        '''Returns the eigen value decomposition of a complex hermitian
        square matrix'''
        return mp.eighe(A, eigvals_only, overwrite_a)


# 13.8.3 mpmath: Eigenvalue problem for a selfadjoint square matrix A

    def eigh(self, A, eigvals_only=False, overwrite_a=False):
        '''Returns the eigen value decomposition of a complex hermitian
        square matrix'''
        return mp.eigh(A, eigvals_only, overwrite_a)


# %%%  13.9 TODO: Tridiagonalization


# 13.9.1 mpmath: tridiag_sym

    def r_sy_tridiag(self, A, D, E, calc_ev=True):
        '''Returns the tridiagonal decomposition of a selfadjoint matrix'''
        return mp.tridiag_eigen(A, D, E, calc_ev=True)


# 13.9.2 mpmath tridiag_her

    def c_he_tridiag_0(self, A, D, E, T):
        '''Returns the tridiagonal decomposition of a selfadjoint matrix'''
        return mp.tridiag_eigen(A, D, E, T)


# 13.9.3 mpmath: tridiag_eigen_sym

    def tridiag_eigen(self, d, e, z=False):
        '''Returns the tridiagonal decomposition of a selfadjoint matrix'''
        return mp.tridiag_eigen(d, e, z=False)


# %%%  13.10 Eigensystem of a general square matrix


# 13.10.1 Eigensystem decomposition of a matrix A (real or complex)

    def eig(self, A, left=False, right=True, overwrite_a=False):
        '''Returns the eigen value decomposition of a real or complex
        square matrix'''
        return mp.eig(A, left, right, overwrite_a)


# 13.10.2 Sorting Eigenvalues

    def eig_sort(self, E, EL=False, ER=False, f="real"):
        '''sorts the eigenvalues and eigenvectors delivered by eig.'''
        return mp.eig_sort(E, EL, ER, f)


# %%%  13.11 Hessenberg and Schur decompositions


# 13.11.1 Hessenberg decomposition of a matrix A (real or complex)

    def hessenberg(self, A, overwrite_a=False):
        '''Returns the Hessenberg decomposition of a real or complex
        square matrix'''
        return mp.hessenberg(A, overwrite_a)


# 13.11.2 Schur decomposition of a matrix A (real or complex)

    def schur(self, A, overwrite_a=False):
        '''Returns the Schur decomposition of a real or complex
        square matrix'''
        return mp.schur(A, overwrite_a)


# %%%  13.12 Analytic functions of a matrix (using mpmath or Arb)

# 13.12.1 Matrix Exponential

    def expm(self, A, method='taylor'):
        '''Returns the matrix exponential of a square matrix'''
        return mp.expm(A, method)


# 13.12.2 Matrix Sine

    def sinm(self, A):
        '''Returns the matrix sine of a square matrix'''
        return mp.sinm(A)


# 13.12.3 Matrix Cosine

    def cosm(self, A):
        '''Returns the matrix Cosine of a square matrix'''
        return mp.cosm(A)


# 13.12.6 Matrix Square Root

    def sqrtm(self, A, _may_rotate=2):
        '''Returns the matrix Square Root of a square matrix'''
        return mp.sqrtm(A, _may_rotate)


# 13.12.7 Matrix Logarithm

    def logm(self, A):
        '''Returns the matrix Logarithm of a square matrix'''
        return mp.logm(A)


# 13.12.8 Matrix power

    def powm(self, A, r):
        '''Returns the matrix power of a square matrix'''
        return mp.powm(A, r)


# %% 07 Inferential statistics

# %%%  15.1 Transformations of raw data

# %%%  15.2 Descriptive Statistics

# %%%  15.3 Descriptive statistical functions: real matrices

# %%%  15.4 Basic classical statistical tests (stratified)

# %%%  15.5 Nonparametric statistical tests

# %%%  15.6 Multivariate statistical tests




# %% 08 Elliptic functions and integrals

# %%%  16.1 Conversions of parameters of elliptic functions

# 16.1.1 Elliptic nome q

    def qfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic nome q'''
        return mp.qfrom(q, m, k, tau, qbar)

# 16.1.2 Number-theoretic nome qbar

    def qbarfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Number-theoretic nome qbar'''
        return mp.qbarfrom(q, m, k, tau, qbar)

# 16.1.3 Elliptic parameter m

    def mfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic parameter m'''
        return mp.mfrom(q, m, k, tau, qbar)

# 16.1.4 Elliptic modulus k

    def kfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic modulus k'''
        return mp.kfrom(q, m, k, tau, qbar)

# 16.1.5 Elliptic half-period ratio tau

    def taufrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic modulus k'''
        return mp.taufrom(q, m, k, tau, qbar)

# 16.1.6 Elliptic lattice roots

# 16.1.7 Elliptic lattice invariants



# %%%  16.2 Legendre elliptic integrals

# 16.2.1 Elliptic integrals overview


# 16.2.2 Legendre complete elliptic integral of the first kind, 𝐾(m)

    def melliptic_k(self, m):
        '''Legendre complete elliptic integral of the first kind, 𝐾(m)'''
        m = self.t(m)
        return mp.ellipk(m)

# 16.2.3 Legendre complete elliptic integral of the second kind, 𝐸(m)

    def melliptic_e(self, m):
        '''Legendre complete elliptic integral of the second kind, 𝐸(m)'''
        m = self.t(m)
        return mp.ellipe(m)

# 16.2.4 Legendre complete elliptic integral of the third kind, Π(𝑛, m)

    def melliptic_pi(self, n, m):
        '''Legendre complete elliptic integral of the third kind, Π(𝑛, m)'''
        n = self.t(n)
        m = self.t(m)
        return mp.ellippi(n, m)

# 16.2.5 Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, m)

    def melliptic_f(self, phi, m):
        '''Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, m)'''
        phi = self.t(phi)
        m = self.t(m)
        return mp.ellipf(phi, m)

# 16.2.6 Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, m)

    def melliptic_e_inc(self, phi, m):
        '''Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, m)'''
        phi = self.t(phi)
        m = self.t(m)
        return mp.ellipe(phi, m)

# 16.2.7 Legendre incomplete elliptic integral of the third kind, Π(𝑛, 𝜑, m)

    def melliptic_pi_inc(self, n, phi, m):
        '''Legendre incomplete elliptic integral of the third kind,
         Π(𝑛, 𝜑, 𝑘)'''
        n = self.t(n)
        phi = self.t(phi)
        m = self.t(m)
        return mp.ellippi(n, phi, m)


# 16.2.2 Legendre complete elliptic integral of the first kind, 𝐾(𝑘)

    def elliptic_k(self, k):
        '''Legendre complete elliptic integral of the first kind, 𝐾(𝑘)'''
        m = self.t(k); m = m*m
        return mp.ellipk(m)

# 16.2.3 Legendre complete elliptic integral of the second kind, 𝐸(𝑘)

    def elliptic_e(self, k):
        '''Legendre complete elliptic integral of the second kind, 𝐸(𝑘)'''
        m = self.t(k); m = m*m
        return mp.ellipe(m)

# 16.2.4 Legendre complete elliptic integral of the third kind, Π(𝑛, 𝑘)

    def elliptic_pi(self, n, k):
        '''Legendre complete elliptic integral of the third kind, Π(𝑛, 𝑘)'''
        n = self.t(n)
        m = self.t(k); m = m*m
        return mp.ellippi(n, m)

# 16.2.5 Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, 𝑘)

    def elliptic_f(self, phi, k):
        '''Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, 𝑘)'''
        phi = self.t(phi)
        m = self.t(k); m = m*m
        return mp.ellipf(phi, m)

# 16.2.6 Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, 𝑘)

    def elliptic_e_inc(self, phi, k):
        '''Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, 𝑘)'''
        phi = self.t(phi)
        m = self.t(k); m = m*m
        return mp.ellipe(phi, m)

# 16.2.7 Legendre incomplete elliptic integral of the third kind, Π(𝑛, 𝜑, 𝑘)

    def elliptic_pi_inc(self, n, phi, k):
        '''Legendre incomplete elliptic integral of the third kind,
         Π(𝑛, 𝜑, 𝑘)'''
        n = self.t(n)
        phi = self.t(phi)
        m = self.t(k); m = m*m
        return mp.ellippi(n, phi, m)


# 16.2.8 Incomplete elliptic integral D (Legendre Form), 𝐷(𝜑, 𝑘)


# 16.2.9 Jacobi Zeta function, 𝑍(𝜑, 𝑘)

    def jacobi_zeta(self, phi, k):
        '''Jacobi Zeta function, 𝑍(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k);
        return self.elliptic_e_inc(phi, k)
        - (self.elliptic_e(k)*self.elliptic_f(phi, k)) / self.elliptic_k(k)

# 16.2.10 Heuman’s Lambda function, Λ(𝜑, 𝑘)

    def heuman_lambda(self, phi, k):
        '''Heuman’s Lambda function, Λ(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k); k1 = self.sqrt(1-k*k)
        res = self.elliptic_f(phi, k1)/self.elliptic_k(k1)
        res = res + 2*self.elliptic_k(k) * self.jacobi_zeta(phi, k1)/self.pi()
        return res


# %%%  16.3 Carlson symmetric elliptic integrals

# 16.3.1 Carlson symmetric elliptic integral of the first kind, 𝑅𝐹 (𝑥, 𝑦, 𝑧)

    def elliprf(self, x, y, z):
        '''Carlson symmetric elliptic integral of the first kind,
        𝑅𝐹 (𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return mp.elliprf(x, y, z)

# 16.3.2 Carlson completely symmetric elliptic integral of the second kind,
    # 𝑅𝐺(𝑥, 𝑦, 𝑧)

    def elliprg(self, x, y, z):
        '''Carlson completely symmetric elliptic integral of the second kind,
        𝑅𝐺(𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return mp.elliprg(x, y, z)

# 16.3.3 Carlson symmetric elliptic integral of the third kind, 𝑅𝐽 (𝑥, 𝑦, 𝑧, 𝑝)

    def elliprj(self, x, y, z, p):
        '''Carlson symmetric elliptic integral of the third kind,
        𝑅𝐽 (𝑥, 𝑦, 𝑧, 𝑝)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        p = self.t(p)
        return mp.elliprj(x, y, z, p)

# 16.3.4 Carlson symmetric elliptic integral of the second kind, 𝑅𝐷(𝑥, 𝑦, 𝑧)

    def elliprd(self, x, y, z):
        '''Carlson symmetric elliptic integral of the second kind,
        𝑅𝐷(𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return mp.elliprd(x, y, z)

# 16.3.5 Carlson degenerate symmetric elliptic integral of the first kind,
    # 𝑅𝐶(𝑥, 𝑦)

    def elliprc(self, x, y):
        '''Carlson degenerate symmetric elliptic integral of the first kind,
        𝑅𝐶(𝑥, 𝑦)'''
        x = self.t(x)
        y = self.t(y)
        return mp.elliprc(x, y)


# %%%  16.4 Jacobi elliptic functions

# 16.4.1 Jacobi elliptic functions, general form

    def ellipfun(self, kind, u=None, m=None, q=None, k=None, tau=None):
        '''Jacobi elliptic functions, general form'''
        return mp.ellipfun(kind, u, m, q, k, tau)

# 16.4.2 Jacobi elliptic function sn

    def jacobi_sn(self, u, k):
        '''Jacobi elliptic function sn'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('sn', u, k=k)

# 16.4.3 Jacobi elliptic function cn

    def jacobi_cn(self, u, k):
        '''Jacobi elliptic function cn'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('cn', u, k=k)

# 16.4.4 Jacobi elliptic function dn

    def jacobi_dn(self, u, k):
        '''Jacobi elliptic function dn'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('dn', u, k=k)

# 16.4.5 Jacobi elliptic function ns

    def jacobi_ns(self, u, k):
        '''Jacobi elliptic function ns'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('ns', u, k=k)

# 16.4.6 Jacobi elliptic function nc

    def jacobi_nc(self, u, k):
        '''Jacobi elliptic function nc'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('nc', u, k=k)

# 16.4.7 Jacobi elliptic function nd

    def jacobi_nd(self, u, k):
        '''Jacobi elliptic function nd'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('nd', u, k=k)

# 16.4.8 Jacobi elliptic function sc

    def jacobi_sc(self, u, k):
        '''Jacobi elliptic function sc'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('sc', u, k=k)

# 16.4.9 Jacobi elliptic function sd

    def jacobi_sd(self, u, k):
        '''Jacobi elliptic function sd'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('sd', u, k=k)

# 16.4.10 Jacobi elliptic function dc

    def jacobi_dc(self, u, k):
        '''Jacobi elliptic function dc'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('dc', u, k=k)

# 16.4.11 Jacobi elliptic function ds

    def jacobi_ds(self, u, k):
        '''Jacobi elliptic function ds'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('ds', u, k=k)

# 16.4.12 Jacobi elliptic function cs

    def jacobi_cs(self, u, k):
        '''Jacobi elliptic function cs'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('cs', u, k=k)

# 16.4.13 Jacobi elliptic function cd

    def jacobi_cd(self, u, k):
        '''Jacobi elliptic function cd'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('cd', u, k=k)


# %%%  16.5 Weierstrass elliptic functions

# 16.5.1 Weierstrass function ℘(𝑧, 𝜏 )

    def weierstrass_p(self, z, tau):
        '''Weierstrass function ℘(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        p = self.pi()
        z = z * p
        q = self.exp(1j * p * tau)
        t20 = self.jtheta(2, 0, q)
        t30 = self.jtheta(3, 0, q)
        t4z = self.jtheta(4, z, q)
        t1z = self.jtheta(1, z, q)
        res1 = p*p*t20*t20*t30*t30*t4z*t4z/(t1z*t1z)
        res2 = -p*p*(t20**4+t30**4)/3
        res = res1+res2
        res = mp.re(res)
        return res

# 16.5.2 Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )

    def weierstrass_p_prime(self, z, tau):
        '''Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        p = self.pi()
        zp = z * p
        q = self.exp(1j * p * tau)
        t20 = self.jtheta(2, 0, q)
        t30 = self.jtheta(3, 0, q)
        res1 = p*p*t20*t20*t30*t30
        f = self.jtheta(4, zp, q)
        g = self.jtheta(1, zp, q)
        f1 = self.jtheta(4, zp, q, derivative=1)
        g1 = self.jtheta(1, zp, q, derivative=1)
        res2 = p*(2*f*(g*f1-f*g1))/(g*g*g)
        res = res1*res2
        res = mp.re(res)
        return res

    def weierstrass_p_prime_diff(self, z, tau):
        '''Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        res = mp.diff(lambda x: self.weierstrass_p(x, tau), z)
        return res


# 16.5.3 Inverse Weierstrass function ℘−1 (𝑧, 𝜏 )

    def weierstrass_p_inv(self, z, tau):
        '''Inverse Weierstrass function ℘−1 (𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        e1, e2, e3 = self.elliptic_roots(tau)
        res = self.elliprf(z-e1, z-e2, z-e3)
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res


# 16.5.4 Weierstrass Zeta

    def weierstrass_zeta(self, z, tau):
        '''Weierstrass Zeta'''
        z = self.t(z)
        tau = self.t(tau)
        p = self.pi()
        z = z * p
        q = self.exp(1j * p * tau)
        t10p1 = self.jtheta(1, 0, q, derivative=1)
        t10p3 = self.jtheta(1, 0, q, derivative=3)
        eta1 = -t10p3/t10p1 / 6
        t1zp1 = self.jtheta(1, z, q, derivative=1)
        t1z = self.jtheta(1, z, q)
        res = 2*eta1*z + t1zp1/t1z
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return p*res


# 16.5.5 Weierstrass Sigma

    def weierstrass_sigma(self, z, tau):
        '''Weierstrass Sigma'''
        z = self.t(z)
        tau = self.t(tau)
        p = self.pi()
        z = z * p
        q = self.exp(1j * p * tau)
        t10p1 = self.jtheta(1, 0, q, derivative=1)
        t10p3 = self.jtheta(1, 0, q, derivative=3)
        eta1 = -t10p3/t10p1 / 6
        t1z = self.jtheta(1, z, q)
        res = self.exp(eta1*z*z) * t1z/t10p1
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res/p


# %%%  16.6 Jacobi theta functions and related functions

# 16.6.1 Jacobi theta functions, general form

    def jtheta(self, n, z, q, derivative=0):
        '''Jacobi theta functions, general form'''
        n = int(n)
        z = self.t(z)
        q = self.t(q)
        return mp.jtheta(n, z, q, derivative)

# 16.6.2 Dedekind eta function

    def dedekind_eta(self, tau):
        '''Dedekind eta function'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        q = mp.qfrom(tau=tau)
        res = mp.jtheta(2, mp.pi()/6, pow(q*q, 1/6)) / mp.sqrt(3)
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res

# 16.6.3 Elliptic modular Lambda

    def modular_lambda(self, tau):
        '''Elliptic modular Lambda'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        q = mp.qfrom(tau=tau)
        t2 = self.jtheta(2, 0, q)
        t3 = self.jtheta(3, 0, q)
        res = (t2**4)/(t3**4)
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res

# 16.6.4 Elliptic modular Delta

    def modular_delta(self, tau):
        '''Elliptic modular Delta'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        res = (self.dedekind_eta(tau))**24
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res

# 16.6.5 Klein j-invariant

    def kleinj(self, tau):
        '''Klein j-invariant'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        res = mp.kleinj(tau)
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res

# 16.6.6 Elliptic lattice roots in terms of Elliptic period ratio 𝜏

    def elliptic_roots(self, tau):
        '''Elliptic lattice roots in terms of Elliptic period ratio 𝜏'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        p = self.pi()
        q = self.exp(1j * p * tau)
        a = self.jtheta(2, 0, q)
        b = self.jtheta(3, 0, q)
        c = self.jtheta(4, 0, q)
        p = p*p/3
        a2 = a*a
        a4 = a2*a2
        b2 = b*b
        b4 = b2*b2
        c2 = c*c
        c4 = c2*c2
        e1 = p*(b4 + c4)
        e2 = p*(-a4 - b4)
        e3 = p*(a4 - c4)
        if self.imag(e1) == self.t(0):
            e1 = self.real(e1)
        if self.imag(e2) == self.t(0):
            e2 = self.real(e2)
        if self.imag(e3) == self.t(0):
            e3 = self.real(e3)
        return e1, e2, e3

# 16.6.7 Elliptic lattice invariants

    def elliptic_invariants(self, tau):
        '''Elliptic lattice invariants'''
        tau = self.t(tau)
        e1, e2, e3 = self.elliptic_roots(tau)
        g2 = 2*(e1*e1 + e2*e2 + e3*e3)
        g3 = 4*e1*e2*e3
        if self.imag(g2) == self.t(0):
            g2 = self.real(g2)
        if self.imag(g3) == self.t(0):
            g3 = self.real(g3)
        return g2, g3


# %% 09 Lerch’s transcendent and related functions

# %%%  17.1 Overview LERCH’S TRANSCENDENT, POLYGAMMA

# 17.1.1 Lerch’s transcendent

    def lerchphi(self, z, s, a):
        '''Lerch’s transcendent'''
        z = self.t(z)
        s = self.t(s)
        a = self.t(a)
        return mp.lerchphi(z, s, a)

# 17.1.2 Lerch’s zeta

    def lerch_zeta(self, lambda1, alpha, s):
        '''Lerch’s zeta'''
        lambda1 = self.t(lambda1)
        alpha = self.t(alpha)
        s = self.t(s)
        return mp.lerchphi(mp.exp(2*mp.pi()*1j*lambda1), s, alpha)


# %%%  17.2 Polygamma functions

# 17.2.1 Polygamma function 𝜓𝑚(𝑥)

    def psi(self, m, z):
        '''Polygamma function 𝜓𝑚(𝑥)'''
        m = self.t(m)
        z = self.t(z)
        return mp.psi(m, z)

    def polygamma(self, m, z):
        '''Polygamma function 𝜓𝑚(𝑥)'''
        m = self.t(m)
        z = self.t(z)
        return mp.psi(m, z)

# 17.2.2 TriGamma function 𝜓′(𝑥)

    def trigamma(self, z):
        '''TriGamma function 𝜓′(𝑥)'''
        z = self.t(z)
        return mp.psi(1, z)

# 17.2.3 DiGamma function 𝜓(𝑥)

    def digamma(self, z):
        '''DiGamma function 𝜓(𝑥)'''
        z = self.t(z)
        return mp.psi(0, z)


# %%%  17.3 Polylogarithms and related functions

# 17.3.1 Polylogarithm, Li𝑠(𝑧)

    def polylog(self, s, z):
        '''Polylogarithm, Li𝑠(𝑧)'''
        s = self.t(s)
        z = self.t(z)
        return mp.polylog(s, z)

# 17.3.2 Trilogarithm Function, Li3(𝑧)

    def trilog(self, z):
        '''Trilogarithm Function, Li3(𝑧)'''
        z = self.t(z)
        return mp.polylog(3, z)

# 17.3.3 Dilogarithm Function, Li2(𝑧)

    def dilog(self, z):
        '''Dilogarithm Function, Li2(𝑧)'''
        z = self.t(z)
        return mp.polylog(2, z)

# 17.3.4 Generalized Clausen sine function
    def clsin(self, s, z):
        '''Generalized Clausen sine function'''
        s = self.t(s)
        z = self.t(z)
        return mp.clsin(s, z)

# 17.3.5 Generalized Clausen cosine function

    def clcos(self, s, z):
        '''Generalized Clausen cosine function'''
        s = self.t(s)
        z = self.t(z)
        return mp.clcos(s, z)

# 17.3.6 Classical Clausen function

    def cl2(self, z):
        '''Classical Clausen function'''
        z = self.t(z)
        return self.clsin(2, z)

# 17.3.7 Bose-Einstein integrals of real order

    def bose_einstein(self, s, z, real4real=True):
        '''Bose-Einstein integrals of real order'''
        s = self.t(s)
        z = self.t(z)
        res = self.polylog(s+1, self.exp(z))
        if mp.im(z) == mp.mpf(0) and real4real:
            res = mp.re(res)
        return res

# 17.3.8 Fermi-Dirac integrals

    def fermi_dirac(self, s, z, real4real=True):
        '''Fermi-Dirac integrals'''
        s = self.t(s)
        z = self.t(z)
        res = -self.polylog(s+1, -self.exp(z))
        if mp.im(z) == mp.mpf(0) and real4real:
            res = mp.re(res)
        return res

# 17.3.9 Legendre’s chi function

    def legendre_chi(self, s, z, real4real=True):
        '''Legendre’s chi function'''
        s = self.t(s)
        z = self.t(z)
        res = 0.5 * (self.polylog(s, z) - self.polylog(s, -z))
        if mp.im(z) == mp.mpf(0) and real4real:
            res = mp.re(res)
        return res

# 17.3.10 Inverse tangent integral

    def ti(self, s, z):
        '''Inverse tangent integral'''
        s = self.t(s)
        z = self.t(z)
        res = (self.polylog(s, 1j*z) - self.polylog(s, -1j*z))
        res = res / (2j)
        if mp.im(z) == mp.mpf(0):
            res = mp.re(res)
        return res

# !!! Missing in documentation !!!

    def ti2(self, z):
        z = self.t(z)
        return self.ti(2, z)

# 17.3.11 Debye functions
    def debye(self, n, x):
        '''Debye functions'''
        return ctxm.debye(self, n, x)


# %%%  17.4 Hurwitz zeta function and related functions

# 17.4.1 Hurwitz zeta function

    def hurwitz(self, s, a, derivative=0):
        '''Hurwitz zeta function'''
        s = self.t(s)
        a = self.t(a)
        return mp.zeta(s, a, derivative)

# 17.4.2 Stieltjes constant

    def stieltjes(self, n, a=1):
        '''Stieltjes constant'''
        n = int(n)
        a = self.t(a)
        return mp.stieltjes(n, a)

# 17.4.3 Harmonic numbers

    def harmonic(self, z):
        '''Harmonic numbers'''
        z = self.t(z)
        return mp.harmonic(z)

# 17.4.4 Generalized harmonic number function

    def harmonic2(self, z, r):
        '''Generalized harmonic number function'''
        z = self.t(z)
        r = self.t(r)
        if r == mp.mpf(1):
            return self.harmonic(z)
        else:
            return mp.zeta(r) - mp.zeta(r, z + 1)

# 17.4.5 Bernoulli numbers

    def bernoulli(self, n):
        '''Bernoulli numbers'''
        n = int(n)
        return mp.bernoulli(n)

# 17.4.6 Bernoulli number as fraction

    def bernfrac(self, n):
        '''Bernoulli number as fraction'''
        n = int(n)
        return mp.bernfrac(n)

# 17.4.7 Bernoulli polynomials

    def bernpoly(self, n, z):
        '''Bernoulli polynomials'''
        n = int(n)
        z = self.t(z)
        return mp.bernpoly(n, z)

# 17.4.8 Euler numbers

    def eulernum(self, n):
        '''Euler numbers'''
        n = int(n)
        return mp.eulernum(n)

# 17.4.9 Euler polynomials

    def eulerpoly(self, n, z):
        '''Euler polynomials'''
        n = int(n)
        z = self.t(z)
        return mp.eulerpoly(n, z)

# 17.4.10 Logarithm of Barnes G function

    def lnbarnesg(self, z):
        '''Logarithm of Barnes G function'''
        z = self.t(z)
        return mp.ln(mp.barnesg(z))

# 17.4.11 Barnes G-function

    def barnesg(self, z):
        '''Barnes G-function'''
        z = self.t(z)
        return mp.barnesg(z)

# 17.4.12 Hyperfactorial

    def hyperfac(self, z):
        '''Hyperfactorial'''
        z = self.t(z)
        return mp.hyperfac(z)

# 17.4.13 Superfactorial

    def superfac(self, z):
        '''Superfactorial'''
        z = self.t(z)
        return mp.superfac(z)


# %%%  17.5 Dirichlet L series, Riemann zeta function and related functions

# 17.5.1 Dirichlet L-Series

    def dirichlet_l(self, s, chi, derivative=0):
        '''Dirichlet L-Series'''
        s = self.t(s)
        return mp.dirichlet(s, chi, derivative)

# 17.5.2 Riemann zeta function

    def zeta(self, s, derivative=0):
        '''Riemann zeta function'''
        s = self.t(s)
        return mp.zeta(s, 1, derivative)

# 17.5.3 Riemann 𝜁(𝑠) − 1

    def zetam1(self, s):
        '''Riemann 𝜁(𝑠) − 1'''
        s = self.t(s)
        return mp.zeta(s, 2)

# 17.5.4 Riemann (Landau) function 𝜉(𝑠)

    def riemann_xi(self, s):
        '''Riemann (Landau) function 𝜉(𝑠)'''
        s = self.t(s)
        res = 0.5*s*(s-1)*self.pi()**(-s/2)*self.gamma(s/2)
        res = res * self.zeta(s)
        return res

# 17.5.5 Dirichlet eta function

    def dirichlet_eta(self, s):
        '''Dirichlet eta function'''
        s = self.t(s)
        return mp.altzeta(s)

# 17.5.6 Dirichlet 𝜂(𝑠) − 1: etam1(s)

    def dirichlet_etam1(self, s):
        '''Dirichlet 𝜂(𝑠) − 1: etam1(s)'''
        s = self.t(s)
        return self.dirichlet_eta(s) - 1

# 17.5.7 Dirichlet Beta function

    def dirichlet_beta(self, s):
        '''Dirichlet Beta function'''
        s = self.t(s)
        return mp.power(4, -s) * (mp.zeta(s, 0.25) - mp.zeta(s, 0.75))

# 17.5.8 Dirichlet Lambda function

    def dirichlet_lambda(self, s):
        '''Dirichlet Lambda function'''
        s = self.t(s)
        # return (1 - mp.power(2, -s)) * mp.zeta(s)
        return -self.exp2m1(-s) * self.zeta(s)

# 17.5.9 Riemann-Siegel Z function

    def siegelz(self, t):
        '''Riemann-Siegel Z function'''
        t = self.t(t)
        return mp.siegelz(t)

# 17.5.10 Riemann-Siegel theta function

    def siegeltheta(self, t):
        '''Riemann-Siegel theta function'''
        t = self.t(t)
        return mp.siegeltheta(t)

# 17.5.11 Backlund S function

    def backlunds(self, t):
        '''Backlund S function'''
        t = self.t(t)
        return mp.backlunds(t)

# 17.5.12 Gram points

    def grampoint(self, n):
        '''Gram points'''
        n = int(n)
        return mp.grampoint(n)

# 17.5.13 Number of zeros of the Riemann zeta function

    def zetazero(self, n, verbose=False):
        '''Number of zeros of the Riemann zeta function'''
        n = int(n)
        return mp.zetazero(n, verbose)

# 17.5.14 Zeros of the Riemann zeta function

    def nzeros(self, t):
        '''Zeros of the Riemann zeta function'''
        t = self.t(t)
        res = mp.nzeros(t)
        res = self.t(res)
        return res

# 17.5.15 Secondary zeta function

    def secondzeta(self, s, a=0.015):
        '''Secondary zeta function'''
        s = self.t(s)
        a = self.t(a)
        return mp.secondzeta(s, a)


# %%%  17.6 Additional numbertheoretic functions

# 17.6.1 Prime counting function

    def primepi(self, x):
        '''Prime counting function'''
        return mp.primepi(x)

# 17.6.2 Mangoldt function

    def mangoldt(self, n):
        '''Mangoldt function'''
        return mp.mangoldt(n)

# 17.6.3 Riemann R function

    def riemannr(self, z):
        '''Riemann R function'''
        z = self.t(z)
        return mp.riemannr(z)

# 17.6.4 Prime zeta function

    def primezeta(self, s):
        '''Prime zeta function'''
        s = self.t(s)
        return mp.primezeta(s)

# 17.6.5 Mertens constant

    def mertens(self):
        '''Mertens constant'''
        return mp.mertens()

# 17.6.6 Twin prime constant

    def twinprime(self):
        '''Twin prime constant'''
        return mp.twinprime()

# 17.6.7 Cyclotomic polynomial

    def cyclotomic(self, n, x):
        '''Cyclotomic polynomial'''
        return mp.cyclotomic(n, x)

# 17.6.8 Stirling number of the first kind

    def stirling1(self, n, k, exact=False):
        '''Stirling number of the first kind'''
        return mp.stirling1(n, k, exact)

# 17.6.9 Stirling number of the second kind

    def stirling2(self, n, k, exact=False):
        '''Stirling number of the second kind'''
        return mp.stirling2(n, k, exact)

# 17.6.10 Bell (Touchard) polynomials

    def bell(self, n, x):
        '''Bell (Touchard) polynomials'''
        return mp.bell(n, x)

# 17.6.11 Polyexponential function

    def polyexp(self, s, z):
        '''Polyexponential function'''
        return mp.polyexp(s, z)


# %% 10 Hypergeometric Function 0_F_1 and related functions

# %%%  18.1 Overview

# 18.1.1 Confluent Hypergeometric Limit Function 0𝐹1

    def hyp0f1(self, a, z):
        '''Confluent Hypergeometric Limit Function 0𝐹1'''
        a = self.t(a)
        z = self.t(z)
        return mp.hyp0f1(a, z)

# 18.1.2 Regularized Confluent Hypergeometric Limit Function 0𝐹1

    def hyp0f1r(self, a, z):
        '''Regularized Confluent Hypergeometric Limit Function 0𝐹1'''
        a = self.t(a)
        z = self.t(z)
        return mp.hyp0f1(a, z)/mp.gamma(a)

# !!! Missing in documentation, move to chi-squared !!!
    def chi_squared_nc_0f1_nc_pdf(self, x, nu, lambda1):
        x = self.t(x)
        nu = self.t(nu)
        res = self.exp(-lambda1/2) * self.chi2_pdf(x, nu)
        res = res * self.hyp0f1(nu/2, x * lambda1 / 4)
        return res


# %%%  18.2 Bessel functions and modified Bessel functions of real or
    # complex order

# !!! Missing in documentation, remove? !!!

    def j0(self, z):
        # return mp.j0(z)
        return self.besselj(0, z)

# 18.2.1 Bessel function of the 1st kind 𝐽𝜈(𝑥)

    def besselj(self, n, z, derivative=0):
        '''Bessel function of the 1st kind 𝐽𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.besselj(n, z, derivative)

# 18.2.2 Bessel function of the 2nd kind 𝑌𝜈(𝑥)

    def bessely(self, n, z, derivative=0):
        '''Bessel function of the 2nd kind 𝑌𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.bessely(n, z, derivative)

# 18.2.3 Zeros 𝑥𝑖 of the Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0

    def besseljzero(self, n, m, derivative=0):
        '''Zeros 𝑥𝑖 of the Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0'''
        n = self.t(n)
        m = int(m)
        return mp.besseljzero(n, m, derivative)

# 18.2.4 Zeros 𝑥𝑖 of the Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0

    def besselyzero(self, n, m, derivative=0):
        '''Zeros 𝑥𝑖 of the Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0'''
        n = self.t(n)
        m = int(m)
        return mp.besselyzero(n, m, derivative)

    # TODO: scaled version

# 18.2.5 Modified Bessel function of the 1st kind 𝐼𝜈(𝑥)

    def besseli(self, n, z, derivative=0):
        '''Modified Bessel function of the 1st kind 𝐼𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.besseli(n, z, derivative)

    # TODO: scaled version

# 18.2.6 Modified Bessel function of the 2nd kind 𝐾𝜈(𝑥)

    def besselk(self, n, z):
        '''Modified Bessel function of the 2nd kind 𝐾𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.besselk(n, z)

# !!! Missing in documentation, move to t-distribution !!!
    def student_t_c_x(self, t, n):
        t = self.t(t)
        n = self.t(n)
        res = self.besselk(n/2, self.sqrt(n) * self.fabs(t))
        res = self.power(res, n/2)
        res = res / self.gamma(n/2) * self.power(2, n/2-1)
        return res

# 18.2.7 First derivative of the Bessel function of the first kind: 𝐽′𝜈(𝑥)

# 18.2.8 First derivative of the Bessel function of the second kind 𝑌′𝜈 (𝑥)

# 18.2.9 First derivative of the modified Bessel function of the first
    # kind 𝐼′𝜈(𝑥)

# 18.2.10 First derivative of the modified Bessel function of the second
    # kind 𝐾′𝜈(𝑥)


# 18.2.11 Hankel function of the first kind 𝐻1,𝜈(𝑥)

    def hankel1(self, n, z):
        '''Hankel function of the first kind 𝐻1,𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.hankel1(n, z)

# 18.2.12 Hankel function of the second kind 𝐻2,𝜈(𝑥)

    def hankel2(self, n, z):
        '''Hankel function of the second kind 𝐻2,𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.hankel2(n, z)


# %%%  18.3 Spherical Bessel functions

    # See also: https://github.com/fredrik-johansson/mpmath/issues/319

# 18.3.1 Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)

    def sph_bessel_jn(self, n, z, derivative=0):
        '''Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.besselj(n+0.5, z)
        return res

# 18.3.2 Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)

    def sph_bessel_yn(self, n, z, derivative=0):
        '''Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.bessely(n+0.5, z)
        return res

# 18.3.3 Modified Spherical Bessel function of the first kind, 𝑖𝑛(𝑥)

    def sph_bessel_in(self, n, z, derivative=0):
        '''Modified Spherical Bessel function of the first kind, 𝑖𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.besseli(n+0.5, z)
        return res

# 18.3.4 Modified Spherical Bessel function of the second kind, 𝑘𝑛(𝑥)

    def sph_bessel_kn(self, n, z, derivative=0):
        '''Modified Spherical Bessel function of the second kind, 𝑘𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.besselk(n+0.5, z)
        return res


# 18.3.5 First derivative of the spherical Bessel function of the first
    # kind, 𝑗′𝑛(𝑥)

# 18.3.6 First derivative of the spherical Bessel function of the second
    # kind, 𝑦′𝑛(𝑥)


# Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)

    def sph_hankel_h1(self, n, z, derivative=0):
        '''Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.hankel1(n+0.5, z)
        return res

# 18.3.8 Spherical Hankel function of the second kind, ℎ2,𝑛(𝑥)
    def sph_hankel_h2(self, n, z, derivative=0):
        '''Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.hankel2(n+0.5, z)
        return res


# %%%  18.4 Airy functions, TODO: scaled functions

# 18.4.1 Airy function Ai

    def airyai(self, z, derivative=0):
        '''Airy function Ai'''
        z = self.t(z)
        return mp.airyai(z, derivative)

# 18.4.2 Airy function Bi

    def airybi(self, z, derivative=0):
        '''Airy function Bi'''
        z = self.t(z)
        return mp.airybi(z, derivative)

# 18.4.3 Zeros 𝑥𝑖 of the Airy function Ai, Ai(𝑥𝑖) = 0

    def airyaizero(self, k, derivative=0):
        '''Zeros 𝑥𝑖 of the Airy function Ai, Ai(𝑥𝑖) = 0'''
        k = int(k)
        return mp.airyaizero(k, derivative)

# 18.4.4 Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0

    def airybizero(self, k, derivative=0, complex=0):
        '''Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0'''
        k = int(k)
        return mp.airybizero(k, derivative, complex)

# 18.4.5 Airy Ai'(x)

    def airy_aip(self, z):
        '''Airy Ai'(x)'''
        z = self.t(z)
        return mp.airyai(z, 1)

# 18.4.6 Airy Bi'(x)

    def airy_bip(self, z):
        '''Airy Bi'(x)'''
        z = self.t(z)
        return mp.airybi(z, 1)


# %%%  18.5 Kelvin functions, TODO: scaled functions

# 18.5.1 Kelvin function ber

    def ber(self, n, z):
        '''Kelvin function ber'''
        n = self.t(n)
        z = self.t(z)
        return mp.ber(n, z)

    def kelvinber(self, n, z):
        '''Kelvin function ber'''
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * mp.sqrt(mp.mpf(2))
        j1 = mp.besselj(n, z * (-a + 1j*a))
        j2 = mp.besselj(n, z * (-a - 1j*a))
        res = 0.5 * (j1 + j2)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# 18.5.2 Kelvin function bei

    def bei(self, n, z):
        '''Kelvin function bei'''
        n = self.t(n)
        z = self.t(z)
        return mp.bei(n, z)

    def kelvinbei(self, n, z):
        '''Kelvin function bei'''
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * mp.sqrt(mp.mpf(2))
        j1 = mp.besselj(n, z * (-a + 1j*a))
        j2 = mp.besselj(n, z * (-a - 1j*a))
        res = -0.5j * (j1 - j2)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# 18.5.3 Kelvin function ker

    def ker(self, n, z):
        '''Kelvin function ker'''
        n = self.t(n)
        z = self.t(z)
        return mp.ker(n, z)

    def kelvinker(self, n, z):
        '''Kelvin function ker'''
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * mp.sqrt(mp.mpf(2))
        k1 = mp.exp(-1j*n*mp.pi()/2) * mp.besselk(n, z * (a + 1j*a))
        k2 = mp.exp(1j*n*mp.pi()/2) * mp.besselk(n, z * (a - 1j*a))
        res = 0.5 * (k1 + k2)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# 18.5.4 Kelvin function kei

    def kei(self, n, z):
        '''Kelvin function kei'''
        n = self.t(n)
        z = self.t(z)
        return mp.kei(n, z)

    def kelvinkei(self, n, z):
        '''Kelvin function kei'''
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * mp.sqrt(mp.mpf(2))
        k1 = mp.exp(-1j*n*mp.pi()/2) * mp.besselk(n, z * (a + 1j*a))
        k2 = mp.exp(1j*n*mp.pi()/2) * mp.besselk(n, z * (a - 1j*a))
        res = -0.5j * (k1 - k2)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# %% 11 Hypergeometric Function 1_F_1 and related functions

# %%%  19.1 Overview

# 19.1.1 Kummer’s Confluent Hypergeometric Function 1𝐹1

    def hyp1f1(self, a, b, z):
        '''Kummer’s Confluent Hypergeometric Function 1𝐹1'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.hyp1f1(a, b, z)

# 19.1.2 Regularized Kummer’s Confluent Hypergeometric Function 1𝐹1

    def hyp1f1r(self, a, b, z):
        '''Regularized Kummer’s Confluent Hypergeometric Function 1𝐹1'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.hyp1f1(a, b, z) / mp.gamma(b)

# 19.1.3 Tricomi’s Confluent Hypergeometric Function 𝑈

    def hyperu(self, a, b, z):
        '''Tricomi’s Confluent Hypergeometric Function 𝑈'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.hyperu(a, b, z)


# %%%  19.2 Incomplete gamma functions

# 19.2.1 Incomplete gamma function, general form

    def gammainc(self, a, z1=0, z2=mp.inf, regularized=False):
        '''Incomplete gamma function, general form'''
        a = self.t(a)
        z1 = self.t(z1)
        z2 = self.t(z2)
        return mp.gammainc(a, z1, z2, regularized)

# 19.2.2 Lower non-normalised incomplete gamma function, 𝛾(𝑎, 𝑥)

    def gamma_lower(self, a, z):
        '''Lower non-normalised incomplete gamma function, 𝛾(𝑎, 𝑥)'''
        a = self.t(a)
        z = self.t(z)
        return mp.gammainc(a, 0, z, False)

# 19.2.3 Upper non-normalised incomplete gamma function, Γ(𝑎, 𝑥)

    def gamma_upper(self, a, z):
        '''Upper non-normalised incomplete gamma function, Γ(𝑎, 𝑥)'''
        a = self.t(a)
        z = self.t(z)
        return mp.gammainc(a, z, mp.inf, False)

# 19.2.4 Lower normalised incomplete gamma function

    def gamma_p(self, a, z):
        '''Lower normalised incomplete gamma function'''
        a = self.t(a)
        z = self.t(z)
        return mp.gammainc(a, 0, z, True)

# 19.2.5 Upper normalised incomplete gamma function

    def gamma_q(self, a, z):
        '''Upper normalised incomplete gamma function'''
        a = self.t(a)
        z = self.t(z)
        return mp.gammainc(a, z, mp.inf, True)

# 19.2.6 Tricomi’s entire incomplete gamma function: 𝛾*(𝑎, 𝑥)

    def gamma_tricomi(self, a, z):
        '''Tricomi’s entire incomplete gamma function: 𝛾*(𝑎, 𝑥)'''
        a = self.t(a)
        z = self.t(z)
        return self.gamma_p(a, z) * mp.power(z, -a)

# 19.2.7 Derivative of the incomplete gamma function

    def gamma_derivative(self, a, z):
        '''Derivative of the incomplete gamma function'''
        a = self.t(a)
        z = self.t(z)
        return mp.exp(-z) * mp.power(z, a-1) / mp.gamma(a)


# %%%  19.3 Error function and related functions

    # Note: make correction for complex case

# 19.3.1 Error function erf

    def erf(self, z):
        '''Error function erf'''
        z = self.t(z)
        return mp.erf(z)

    # Note: make correction for complex case

# 19.3.2 Complementary error function erfc

    def erfc(self, z):
        '''Complementary error function erfc'''
        z = self.t(z)
        return mp.erfc(z)


# 19.3.3 Scaled repeated integrals of erfc

    def inerfc(self, n, z):
        '''Scaled repeated integrals of erfc'''
        n = self.t(n)
        z = self.t(z)
        scaled = True
        res = 1/(2**n * self.sqrt(self.pi()))
        res = res * self.hyperu(0.5*n+0.5, 0.5, z*z)
        if not (scaled):
            res = res * self.exp(-z*z)
        return res

# 19.3.4 Imaginary error function erfi

    def erfi(self, z):
        '''Imaginary error function erfi'''
        z = self.t(z)
        return mp.erfi(z)

# 19.3.5 Dawson’s integral

    def dawson(self, z):
        '''Dawson’s integral'''
        z = self.t(z)
        res = 0.5 * mp.sqrt(mp.pi()) * mp.exp(-z*z)
        res = res * mp.erfi(z)
        return res

# 19.3.6 Fresnel sine integral

    def fresnels(self, z):
        '''Fresnel sine integral'''
        z = self.t(z)
        return mp.fresnels(z)

# 19.3.7 Fresnel cosine integral

    def fresnelc(self, z):
        '''Fresnel cosine integral'''
        z = self.t(z)
        return mp.fresnelc(z)


# 19.3.8 Faddeeva function

    def faddeeva(self, z):
        '''Faddeeva function'''
        z = self.t(z)
        res = mp.exp(-z*z) * mp.erfc(-1j * z)
        return res

# 19.3.9 Voigt function U

    def voigt_u(self, x, t):
        '''Voigt function U'''
        x = self.t(x)
        t = self.t(t)
        z = (1-1j*x)/(2*mp.sqrt(t))
        res = mp.sqrt(mp.pi()/(4*t)) * self.faddeeva(1j * z)
        return mp.re(res)

# 19.3.10 Voigt function V

    def voigt_v(self, x, t):
        '''Voigt function V'''
        x = self.t(x)
        t = self.t(t)
        z = (1-1j*x)/(2*mp.sqrt(t))
        res = mp.sqrt(mp.pi()/(4*t)) * self.faddeeva(1j * z)
        return mp.im(res)

# 19.3.11 Voigt function H

    def voigt_h(self, a, u):
        '''Voigt function H'''
        a = self.t(a)
        u = self.t(u)
        res = 1/(a*mp.sqrt(mp.pi()))
        res = res * self.voigt_u(u/a, 1/(4*a*a))
        return res


# %%%  19.4 Exponential integrals and related functions

# 19.4.1 Hyperbolic cosine integral Chi

    def chi(self, z):
        '''Hyperbolic cosine integral Chi'''
        z = self.t(z)
        return mp.chi(z)

# 19.4.2 Cosine integral Ci

    def ci(self, z):
        '''Cosine integral Ci'''
        z = self.t(z)
        return mp.ci(z)

# 19.4.3 Exponential integral E1

    def e1(self, z):
        '''Exponential integral E1'''
        z = self.t(z)
        return mp.e1(z)

# 19.4.4 Exponential integral Ei

    def ei(self, z):
        '''Exponential integral Ei'''
        z = self.t(z)
        return mp.ei(z)

# 19.4.5 Exponential integral 𝐸𝑛

    def expint(self, n, z):
        '''Exponential integral 𝐸𝑛'''
        n = self.t(n)
        z = self.t(z)
        return mp.expint(n, z)

# 19.4.6 Logarithmic integral li

    def li(self, z, offset=False):
        '''Logarithmic integral li'''
        z = self.t(z)
        return mp.li(z, offset)

# 19.4.7 Bounds for the value of the prime counting function

    def primepi2_upper(self, x):
        '''Bounds for the value of the prime counting function'''
        x = self.t(x)
        m = self.li(x)
        d = self.sqrt(x) * self.ln(x)/(8*self.pi())
        res = self.ceil(m+d)
        return res

# 19.4.8 Bounds for the value of the prime counting function

    def primepi2_lower(self, x):
        '''Bounds for the value of the prime counting function'''
        x = self.t(x)
        m = self.li(x)
        d = self.sqrt(x) * self.ln(x)/(8*self.pi())
        res = self.floor(m-d)
        return res

# 19.4.9 Hyperbolic sine integral shi

    def shi(self, z):
        '''Hyperbolic sine integral shi'''
        z = self.t(z)
        return mp.shi(z)

# 19.4.10 Sine integral si
    def si(self, z):
        '''Sine integral si'''
        z = self.t(z)
        return mp.si(z)


# %%%  19.5 Orthogonal polynomials

# 19.5.1 Hermite polynomials (physicist)

    def hermite(self, n, z):
        '''Hermite polynomials (physicist)'''
        n = self.t(n)
        z = self.t(z)
        return mp.hermite(n, z)

# 19.5.2 Hermite polynomials (probabilist)

    def hermite_he(self, n, z):
        '''Hermite polynomials (probabilist)'''
        n = self.t(n)
        z = self.t(z)
        res = 2**(-n/2) * self.hermite(n, z/self.sqrt(2))
        return res

# 19.5.3 Laguerre Polynomials, 𝐿𝑛(𝑥)

    def laguerre_l(self, n, z):
        '''Laguerre Polynomials, 𝐿𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.laguerre(n, 0.0, z)

# 19.5.4 Generalized Laguerre polynomials, 𝐿𝑚𝑛(𝑥)

    def laguerre(self, n, a, z):
        '''Generalized Laguerre polynomials, 𝐿𝑚𝑛(𝑥)'''
        n = self.t(n)
        a = self.t(a)
        z = self.t(z)
        return mp.laguerre(n, a, z)


# %%%  19.6 Coulomb functions

# 19.6.1 Normalizing Gamow constant for Coulomb wave functions

    def coulombc(self, l, eta):
        '''Normalizing Gamow constant for Coulomb wave functions'''
        l = self.t(l)
        eta = self.t(eta)
        return mp.coulombc(l, eta)

# 19.6.2 Coulomb wave function F

    def coulombf(self, l, eta, z):
        '''Coulomb wave function F'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return mp.coulombf(l, eta, z)

# 19.6.3 Coulomb wave function G

    def coulombg(self, l, eta, z):
        '''Coulomb wave function G'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return mp.coulombg(l, eta, z)


# %%%  19.7 Whittaker functions

# 19.7.1 Whittaker function M

    def whitm(self, k, m, z):
        '''Whittaker function M'''
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        return mp.whitm(k, m, z)

# 19.7.2 Whittaker function W

    def whitw(self, k, m, z):
        '''Whittaker function W'''
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        return mp.whitw(k, m, z)


# %%%  19.8 Parabolic cylinder functions

# 19.8.1 Parabolic cylinder function D

    def pcfd(self, n, z):
        '''Parabolic cylinder function D'''
        n = self.t(n)
        z = self.t(z)
        return mp.pcfd(n, z)

# 19.8.2 Parabolic cylinder function U

    def pcfu(self, a, z):
        '''Parabolic cylinder function U'''
        a = self.t(a)
        z = self.t(z)
        return mp.pcfu(a, z)

# 19.8.3 Parabolic cylinder function V

    def pcfv(self, a, z):
        '''Parabolic cylinder function V'''
        a = self.t(a)
        z = self.t(z)
        return mp.pcfv(a, z)

# 19.8.4 Parabolic cylinder function W

    def pcfw(self, a, z):
        '''Parabolic cylinder function W'''
        a = self.t(a)
        z = self.t(z)
        return mp.pcfw(a, z)


# %% 12 Hypergeometric Function 2_F_1 and related functions

# %%%  20.1 Overview


# 20.1.1 Gauss Hypergeometric Function 2𝐹1

    def hyp2f1(self, a, b, c, z):
        '''Gauss Hypergeometric Function 2𝐹1'''
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        return mp.hyp2f1(a, b, c, z)

# 20.1.2 Regularized Gauss Hypergeometric Function 2𝐹1

    def hyp2f1r(self, a, b, c, z):
        '''Regularized Gauss Hypergeometric Function 2𝐹1'''
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        return mp.hyp2f1(a, b, c, z) / mp.gamma(c)


# %%%  20.2 Orthogonal polynomials

# 20.2.1 Chebyshev polynomial of the first kind, 𝑇𝑛(𝑥)

    def chebyt(self, n, z):
        '''Chebyshev polynomial of the first kind, 𝑇𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.chebyt(n, z)

# 20.2.2 Chebyshev polynomial of the second kind, 𝑈𝑛(𝑥)

    def chebyu(self, n, z):
        '''Chebyshev polynomial of the second kind, 𝑈𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.chebyu(n, z)

# 20.2.3 Gegenbauer polynomials, 𝐶𝛼𝑛 (𝑥)

    def gegenbauer(self, n, a, z):
        '''Gegenbauer polynomials, 𝐶𝛼𝑛 (𝑥)'''
        n = self.t(n)
        a = self.t(a)
        z = self.t(z)
        return mp.gegenbauer(n, a, z)

# 20.2.4 Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛

    def jacobi(self, n, a, b, z):
        '''Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛'''
        n = self.t(n)
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.jacobi(n, a, b, z)

# 20.2.5 Legendre polynomials / functions, 𝑃𝑙(𝑥)

    def legendre(self, n, z):
        '''Legendre polynomials / functions, 𝑃𝑙(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.legendre(n, z)

# 20.2.6 Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)

    def legenp(self, n, m, z, type=2):
        '''Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)'''
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        return mp.legenp(n, m, z, type)

# 20.2.7 Associated Legendre function of the second kind, 𝑄𝑙(𝑥)

    def legenq(self, n, m, z, type=2):
        '''Associated Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        return mp.legenq(n, m, z, type)

# 20.2.8 Spherical harmonics, 𝑌 𝑚𝑛 (𝜃, 𝜑)

    def spherharm(self, l, m, theta, phi):
        '''Spherical harmonics, 𝑌 𝑚𝑛 (𝜃, 𝜑)'''
        l = self.t(l)
        m = self.t(m)
        theta = self.t(theta)
        phi = self.t(phi)
        return mp.spherharm(l, m, theta, phi)


# %%%  20.3 Incomplete Beta

# 20.3.1 General incomplete beta function

    def betainc(self, a, b, z1=0, z2=1, regularized=False):
        '''General incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z1 = self.t(z1)
        z2 = self.t(z2)
        return mp.betainc(a, b, z1, z2, regularized)

# 20.3.2 Normalised incomplete beta function

    def ibeta(self, a, b, z):
        '''Normalised incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.betainc(a, b, 0, z, True)

# 20.3.3 Non-Normalised incomplete beta function

    def beta3(self, a, b, z):
        '''Non-Normalised incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.betainc(a, b, 0, z, False)


# %% 13 Hypergeometric Function p_F_q and related functions


# %%%  21.1 Generalized hypergeometric functions

# 21.1.1 Generalized hypergeometric function 𝑝𝐹𝑞

    def hyper(self, a_s, b_s, z):
        '''Generalized hypergeometric function 𝑝𝐹𝑞'''
        return mp.hyper(a_s, b_s, z)

# 21.1.2 Generalized hypergeometric function 2𝐹3

    def hyp2f3(self, a1, a2, b1, b2, b3, z):
        '''Generalized hypergeometric function 2𝐹3'''
        return mp.hyp2f3(a1, a2, b1, b2, b3, z)

# 21.1.3 Generalized hypergeometric function 3𝐹2

    def hyp3f2(self, a1, a2, a3, b1, b2, z):
        '''Generalized hypergeometric function 3𝐹2'''
        return mp.hyp3f2(a1, a2, a3, b1, b2, z)

# 21.1.4 Generalized hypergeometric function 2𝐹2

    def hyp2f2(self, a1, a2, b1, b2, z):
        '''Generalized hypergeometric function 2𝐹2'''
        return mp.hyp2f2(a1, a2, b1, b2, z)


# 21.1.5 Generalized hypergeometric function 2𝐹0

    def hyp2f0(self, a, b, z):
        '''Generalized hypergeometric function 2𝐹0'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.hyp2f0(a, b, z)


# %%%  21.2 Generalized hypergeometric function 1F2 and related functions

# 21.2.1 Non-regularized hypergeometric function 1𝐹2

    def hyp1f2(self, a1, b1, b2, z):
        '''Non-regularized hypergeometric function 1𝐹2'''
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        return mp.hyp1f2(a1, b1, b2, z)

    # see  https://functions.wolfram.com/HypergeometricFunctions/
    # Hypergeometric1F2/25/01/

# 21.2.2 Regularized hypergeometric function 1𝐹2

    def hyp1f2r(self, a1, b1, b2, z):
        '''Regularized hypergeometric function 1𝐹2'''
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        res = mp.hyp1f2(a1, b1, b2, z)
        res = res / (mp.gamma(b1)*mp.gamma(b2))
        return res

# 21.2.3 Scorer function Gi

    def scorergi(self, z):
        '''Scorer function Gi'''
        z = self.t(z)
        return mp.scorergi(z)

    def scorergi2(self, z):
        '''Scorer function Gi'''
        z = self.t(z)
        t = mp.mpf(1)/mp.mpf(3)
        res1 = self.airybi(z)/3
        res2 = (z*z)/(2*self.pi())
        res3 = self.hyp1f2(1, 4*t, 5*t, z*z*z/9)
        res = res1 - res2*res3
        return res


# 21.2.4 Scorer function Hi(x)

    def scorerhi(self, z):
        '''Scorer function Hi'''
        z = self.t(z)
        return mp.scorerhi(z)

    def scorerhi2(self, z):
        '''Scorer function Hi'''
        z = self.t(z)
        t = mp.mpf(1)/mp.mpf(3)
        res1 = 2*self.airybi(z)/3
        res2 = (z*z)/(2*self.pi())
        res3 = self.hyp1f2(1, 4*t, 5*t, z*z*z/9)
        res = res1 + res2*res3
        return res


# 21.2.5 Struve function 𝐻𝜈(𝑥)

    def struveh(self, n, z):
        '''Struve function 𝐻𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.struveh(n, z)

    def struveh2(self, n, z):
        '''Struve function 𝐻𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res2 = (z/2)**(n+1)
        res3 = self.hyp1f2r(1, 1.5, n+1.5, -z*z/4)
        res = res2*res3
        return res


# 21.2.6 Struve function 𝐿𝜈(𝑥)

    def struvel(self, n, z):
        '''Struve function 𝐿𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.struvel(n, z)

    def struvel2(self, n, z):
        '''Struve function 𝐿𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = -1j*self.expjpi(-n/2)*self.struveh(n, 1j*z)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# 21.2.7 Struve function K

    def struvek(self, n, z):
        '''Struve function K'''
        n = self.t(n)
        z = self.t(z)
        return self.struveh(n, z) - self.bessely(n, z)

# 21.2.8 Struve function M

    def struvem(self, n, z):
        '''Struve function M'''
        n = self.t(n)
        z = self.t(z)
        return self.struvel(n, z) - self.besseli(n, z)

# 21.2.9 Anger function J

    def angerj(self, n, z):
        '''Anger function J'''
        n = self.t(n)
        z = self.t(z)
        return mp.angerj(n, z)

    def angerj2(self, n, z):
        '''Anger function J'''
        # if n is an integer, return besselj(n,z)
        n = self.t(n)
        z = self.t(z)
        tau = self.pi() * n / 2
        res2a = (z/2)*self.sin(tau)
        res3a = self.hyp1f2r(1, 0.5*(3-n), 0.5*(3+n), -z*z/4)
        res2b = self.cos(tau)
        res3b = self.hyp1f2r(1, 0.5*(2-n), 0.5*(2+n), -z*z/4)
        res = res2a*res3a + res2b*res3b
        return res


# 21.2.10 Weber function E

    def webere(self, n, z):
        '''Weber function E'''
        n = self.t(n)
        z = self.t(z)
        return mp.webere(n, z)

    def webere2(self, n, z):
        '''Weber function E'''
        n = self.t(n)
        z = self.t(z)
        tau = self.pi() * n / 2
        res2a = self.sin(tau)
        res3a = self.hyp1f2r(1, 0.5*(2-n), 0.5*(2+n), -z*z/4)
        res2b = (z/2)*self.cos(tau)
        res3b = self.hyp1f2r(1, 0.5*(3-n), 0.5*(3+n), -z*z/4)
        res = res2a*res3a - res2b*res3b
        return res


# 21.2.11 Lommel function 𝑆1

    def lommels1(self, mu, nu, z):
        '''Lommel function 𝑆1'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        return mp.lommels1(mu, nu, z)

    def lommels1_2(self, mu, nu, z):
        '''Lommel function 𝑆1'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        res2 = z**(mu+1)/((mu-nu+1)*(mu+nu+1))
        res3 = self.hyp1f2(1, (mu-nu+3)/2, (mu+nu+3)/2, -z*z/4)
        res = res2*res3
        return res


# 21.2.12 Lommel function 𝑆2

    def lommels2(self, mu, nu, z):
        '''Lommel function 𝑆2'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        return mp.lommels2(mu, nu, z)

    def lommels2_2(self,  mu, nu, z):
        '''Lommel function 𝑆2'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        res1 = self.lommels1(mu, nu, z)
        res2 = 2**(mu-1) * self.gamma((mu-nu+1)/2) * self.gamma((mu+nu+1)/2)
        res3 = self.sin(self.pi()*(mu-nu)/2) * self.besselj(nu, z)
        res4 = self.cos(self.pi()*(mu-nu)/2) * self.bessely(nu, z)
        res = res1+res2*(res3-res4)
        return res


# %% 14 Generalizations of gamma and hypergeometric functions
    # (without ARB support)


# %%%  22.1 Appell Functions

# 22.1.1 Appell function 𝐹1

    def appellf1(self, a, b1, b2, c, x, y):
        '''Appell function 𝐹1'''
        return mp.appellf1(a, b1, b2, c, x, y)

# 22.1.2 Appell function 𝐹2

    def appellf2(self, a, b1, b2, c1, c2, x, y):
        '''Appell function 𝐹2'''
        return mp.appellf2(a, b1, b2, c1, c2, x, y)

# 22.1.3 Appell function 𝐹3

    def appellf3(self, a1, a2, b1, b2, c, x, y):
        '''Appell function 𝐹3'''
        return mp.appellf3(a1, a2, b1, b2, c, x, y)

# 22.1.4 Appell function 𝐹4

    def appellf4(self, a, b, c1, c2, x, y):
        '''Appell function 𝐹4'''
        return mp.appellf4(a, b, c1, c2, x, y)


# %%%  22.2 Q Functions

# 22.2.1 q-Pochhammer symbol

    def qp(self, a, q=None, n=None):
        '''q-Pochhammer symbol'''
        return mp.qp(a, q, n)

# 22.2.2 q-gamma function

    def qgamma(self, z, q):
        '''q-gamma function'''
        return mp.qgamma(z, q)

# 22.2.3 q-factorial

    def qfac(self, z, q):
        '''q-factorial'''
        return mp.qfac(z, q)

# 22.2.4 Hypergeometric q-series

    def qhyper(self, a_s, b_s, q, z):
        '''Hypergeometric q-series'''
        return mp.qhyper(a_s, b_s, q, z)


# %%%  22.3 Further generalizations of gamma and hypergeometric functions

# 22.3.1 Limit of the product of gamma functions

    def gammaprod(self, a, b):
        '''Limit of the product of gamma functions'''
        return mp.gammaprod(a, b)

# 22.3.2 Limit of a weighted combination of hypergeometric functions

    def hypercomb(self, function, params=[], discard_known_zeros=True):
        '''Limit of a weighted combination of hypergeometric functions'''
        return mp.hypercomb(function, params, discard_known_zeros)

# 22.3.3 Meijer G-function

    def meijerg(self, a_s, b_s, r, z):
        '''Meijer G-function'''
        return mp.meijerg(a_s, b_s, r, z)

# 22.3.4 Bilateral hypergeometric series

    def bihyper(self, a_s, b_s, z):
        '''Bilateral hypergeometric series'''
        return mp.bihyper(a_s, b_s, z)

# 22.3.5 Generalized 2D hypergeometric series

    def hyper2d(self, a, b, x, y):
        '''Generalized 2D hypergeometric series'''
        return mp.hyper2d(a, b, x, y)



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

# 12.14.4 Calculating the cumulants from the central moments

    def cumulants_from_centralmoments(self, mu):
        '''Calculates the cumulants from the central moments'''
        return ctxm.cumulants_from_centralmoments(self, mu)

# 12.14.5 Calculating the cumulants from the cumulant-generating function

    def cumulants_from_cgf(self, cgf):
        '''Calculates the cumulants from the cumulant-generating function'''
        return ctxm.cumulants_from_cgf(self, cgf)


# 12.15-12.18 is just text






# %% 16 Base class for random variables with univariate distribution functions
    # Implemented in dist_base.py


# %% 17 Base class for random variables with univariate continuous distribution
    # functions
    # Implemented in dist_base.py


# %% 18 Base class for random variables with univariate discrete distribution
    # functions
    # Implemented in dist_base.py


# %% 19 Closed form distributions, based on elementary functions

# 26.1 Arcsine Distribution

    def dist_arcsine(self, a, b):
        r"""
        The **ctx_chi_squared_nc** class implements a arcsine
        distribution with parameters a and b.

        Parameters
        ----------
        a : a real scalar of type ctx.mpf
            the left end of the range

        b : a real scalar of type ctx.mpf
            the right end of the range

        Returns
        -------
        object
            an instance of the arcsine class

        **References**

        1. Wikipedia contributors. *Noncentral chi-squared distribution.
        Wikipedia, the free encyclopedia*.
        https://en.wikipedia.org/wiki/Arcsine_distribution.
        """
        return ctx_arcsine(self, a, b)


# 26.2 Cauchy distribution

    def dist_cauchy(self, a, b):
        '''Cauchy distribution'''
        return ctx_cauchy(self, a, b)


# 26.3 Dagum (Burr Type III) distribution

    def dist_dagum(self, a, b, p):
        '''Dagum (Burr Type III) distribution'''
        return ctx_dagum(self, a, b, p)


# 26.4 Exponential distribution

    def dist_exponential(self, lambda1):
        '''Exponential distribution'''
        return ctx_exponential(self, lambda1)


# 26.5 Fisk (log-logistic) distribution

    def dist_fisk(self, a, b):
        '''Fisk (log-logistic) distribution'''
        return ctx_fisk(self, a, b)


# 26.6 Fréchet (Generalized Extreme Value distribution Type-II) distribution

    def dist_frechet(self, a, b):
        '''Fréchet (Generalized Extreme Value distribution Type-II)
        distribution'''
        return ctx_frechet(self, a, b)


# 26.7 Generalized Extreme Value (GEV) distribution

    def dist_gev(self, lambda1):
        '''Generalized Extreme Value (GEV) distribution'''
        return ctx_gev(self, lambda1)


# 26.8 Generalized Pareto distribution

    def dist_genpareto(self, m, s, c):
        '''Generalized Pareto distribution'''
        return ctx_genpareto(self, m, s, c)



# 26.8 Gompertz distribution

    def dist_gompertz(self, a, b, l):
        '''Gompertz distribution'''
        return ctx_gompertz(self, a, b, l)




# 26.9 Gumbel (Generalized Extreme Value distribution Type-I) distribution

    def dist_gumbel(self, a, b):
        '''Gumbel (Generalized Extreme Value distribution Type-I)
        distribution'''
        return ctx_gumbel(self, a, b)


# 26.10 Hyperexponential Distribution

    def dist_hyperexponential(self, k, w, l):
        '''Hyperexponential Distribution'''
        return ctx_hyperexponential(self, k, w, l)


# 26.11 Kumaraswamy distribution

    def dist_kumaraswamy(self, a, b):
        '''Kumaraswamy distribution'''
        return ctx_kumaraswamy(self, a, b)


# 26.12 Laplace distribution

    def dist_laplace(self, a, b):
        '''Laplace distribution'''
        return ctx_laplace(self, a, b)


# 26.13 Logistic distribution

    def dist_logistic(self, a, b):
        '''Logistic distribution'''
        return ctx_logistic(self, a, b)


# 26.14 Lomax distribution

    def dist_lomax(self, a, b):
        '''Lomax distribution'''
        return ctx_lomax(self, a, b)


# 26.15 Pareto distribution

    def dist_pareto(self, a, b):
        '''Pareto distribution'''
        return ctx_pareto(self, a, b)


# 26.16 Rayleigh distribution

    def dist_rayleigh(self, b):
        '''Rayleigh distribution'''
        return ctx_rayleigh(self, b)


# 26.17 Shifted Gompertz distribution

    def dist_shifted_gompertz(self, a, b):
        '''Shifted Gompertz distribution'''
        return ctx_shifted_gompertz(self, a, b)


# 26.17 Singh-Maddala (Burr Type XII) distribution

    def dist_singh_maddala(self, a, b, d):
        '''Singh-Maddala (Burr Type XII) distribution'''
        return ctx_singh_maddala(self, a, b, d)


# 26.18 Triangular Distribution

    def dist_triangular(self, a, b, c):
        '''Triangular Distribution'''
        return ctx_triangular(self, a, b, c)


# 26.19 Uniform distribution

    def dist_uniform(self, a, b):
        '''Uniform distribution'''
        return ctx_uniform(self, a, b)


# 26.20 Weibull distribution

    def dist_weibull(self, a, b):
        '''Weibull distribution'''
        return ctx_weibull(self, a, b)


# %% 20 Closed form distributions, based on the error function


# 27.1 Birnbaum-Saunders Distribution

    def dist_birnb_saunders(self, a, b):
        '''Birnbaum-Saunders Distribution'''
        return ctx_birnb_saunders(self, a, b)


# 27.2 Exponentially Modified Gaussian (EMG) distribution

    def dist_emg(self, a, b):
        '''Exponentially Modified Gaussian (EMG) distribution'''
        return ctx_emg(self, a, b)


# 27.3 Folded normal distribution

    def dist_folded_normal(self, a, b):
        '''Folded normal distribution'''
        return ctx_folded_normal(self, a, b)


# 27.4 Half-normal distribution

    def dist_half_normal(self, a, b):
        '''Half-normal distribution'''
        return ctx_half_normal(self, a, b)


# 27.5 Johnson SB distribution

    def dist_johnson_sb(self, a, b):
        '''Johnson SB distribution'''
        return ctx_johnson_sb(self, a, b)


# 27.6 Johnson SU distribution

    def dist_johnson_su(self, a, b):
        '''Johnson SU distribution'''
        return ctx_johnson_su(self, a, b)


# 27.7 Lévy distribution

    def dist_levy(self, a, b):
        '''Lévy distribution'''
        return ctx_levy(self, a, b)


# 27.8 Lognormal (Johnson SL) distribution

    def dist_lognormal(self, a, b):
        '''Lognormal (Johnson SL) distribution'''
        return ctx_lognormal(self, a, b)


# 27.9 Moyal Distribution

    def dist_moyal(self, a, b):
        '''Moyal Distribution'''
        return ctx_moyal(self, a, b)


# 27.10 Normal (Johnson SN) distribution

    def dist_normal(self, a, b):
        '''Normal (Johnson SN) distribution'''
        return ctx_normal(self, a, b)


# 32.1 Normal maximum distribution

    def dist_normal_max(self, k):
        '''Normal maximum distribution'''
        return ctx_normal_max(self, k)


# 32.2 Normal maximum modulus distribution

    def dist_normal_maxmod(self, k):
        '''Normal maximum modulus distribution'''
        return ctx_normal_maxmod(self, k)



# 27.11 Sinh-arcsinh normal distribution

    def dist_sasnormal(self, a, b, c):
        '''Skew normal Distribution'''
        return ctx_sasnormal(self, a, b, c)


# 27.11 Skew normal Distribution

    def dist_skewnormal(self, a, b, c):
        '''Skew normal Distribution'''
        return ctx_skewnormal(self, a, b, c)



# 27.12 Truncated normal distribution

    def dist_trunc_normal(self, a, b):
        '''Truncated normal distribution'''
        return ctx_trunc_normal(self, a, b)


# 27.13 Wald (or Inverse Gaussian) distribution

    def dist_wald(self, a, b):
        '''Wald (or Inverse Gaussian) distribution'''
        return ctx_wald(self, a, b)


# %% 21 Closed form distributions, based on the incomplete gamma function


# 28.1 Amoroso distribution

    def dist_amoroso(self, a, b):
        '''Amoroso distribution'''
        return ctx_amoroso(self, a, b)


# 28.2 Chi Distribution

    def dist_chi(self, nu):
        '''Chi Distribution'''
        return ctx_chi(self, nu)


# 28.3 Chi-Squared distribution

    def dist_chi2(self, nu):
        '''Chi-Squared distribution'''
        return ctx_chi2(self, nu)


# 28.4 Distribution of the logarithm of a chi^2 random variable

    def dist_logrv_chi2(self, nu):
        '''Distribution of the logarithm of a chi^2 random variable'''
        return ctx_logrv_chi2(self, nu)


# 28.5 Gamma (Pearson Type III) distribution

    def dist_gamma(self, a, b):
        '''Gamma (Pearson Type III) distribution'''
        return ctx_gamma(self, a, b)



# 28.5 Hypoexponential distribution

    def dist_hypoexp(self, n, l):
        '''Hypoexponential distribution'''
        return ctx_hypoexp(self, n, l)


# 28.6 Inverse chisquared distribution

    def dist_invchi2(self, a, b):
        '''Inverse chisquared distribution'''
        return ctx_invchi2(self, a, b)


# 28.7 Inverse Gamma (Pearson Type V) distribution

    def dist_invgamma(self, a, b):
        '''Inverse Gamma (Pearson Type V) distribution'''
        return ctx_invgamma(self, a, b)


# 28.8 Maxwell Distribution

    def dist_maxwell(self, b):
        '''Maxwell Distribution'''
        return ctx_maxwell(self, b)


# 28.9 Lindley distribution

    def dist_lindley(self, m, w):
        '''Nakagami distribution'''
        return ctx_lindley(self, m, w)


# 28.9 Nakagami distribution

    def dist_nakagami(self, m, w):
        '''Nakagami distribution'''
        return ctx_nakagami(self, m, w)


# 28.9 Skew exponential power distribution

    def dist_skew_exp_power(self, m, w):
        '''Nakagami distribution'''
        return ctx_skew_exp_power(self, m, w)


# 28.10 Stacy (generalized gamma) distribution

    def dist_stacy(self, m, w):
        '''Stacy (generalized gamma) distribution'''
        return ctx_stacy(self, m, w)




# %% 22 Closed form distributions, based on the incomplete beta function

# 29.1 Beta (Pearson Type I and II) distribution

    def dist_beta(self, a, b):
        '''Beta (Pearson Type I and II) distribution'''
        return ctx_beta(self, a, b)


# 29.2 Distribution of the negative logarithm of a beta variable

    def dist_logrv_beta(self, a, b):
        '''Distribution of the negative logarithm of a beta variable'''
        return ctx_logrv_beta(self, a, b)


# 29.3 Beta-prime (Pearson Type VI) distribution

    def dist_beta_prime(self, a, b):
        '''Beta-prime (Pearson Type VI) distribution'''
        return ctx_beta_prime(self, a, b)


# 29.4 Generalized Beta (Type 1) distribution

    def dist_genbeta1(self, a, b):
        '''Generalized Beta (Type 1) distribution'''
        return ctx_genbeta1(self, a, b)


# 29.5 Generalized Beta (Type 2) distribution

    def dist_genbeta2(self, a, b):
        '''Generalized Beta (Type 2) distribution'''
        return ctx_genbeta2(self, a, b)


# 29.6 Generalized logistic distribution

    def dist_genlogistic(self, a, b):
        '''Generalized logistic distribution'''
        return ctx_genlogistic(self, a, b)


# 29.7 Generalized beta-exponential distribution

    def dist_gen_beta_exp(self, a, b):
        '''Generalized beta-exponential distribution'''
        return ctx_gen_beta_exp(self, a, b)



# 29.7 Feller-Pareto distribution

    def dist_feller_pareto(self, a, b):
        '''Feller-Pareto distribution'''
        return ctx_feller_pareto(self, a, b)


# 29.8 Central Fisher F distribution

    def dist_fisher_f(self, a, b):
        '''Central Fisher F distribution'''
        return ctx_fisher_f(self, a, b)


# 29.9 Fisher z distribution

    def dist_fisher_z(self, a, b):
        '''Fisher z distribution'''
        return ctx_fisher_z(self, a, b)


# 29.10 Student t (Pearson Type VII) distribution

    def dist_student_t(self, n):
        '''Student t (Pearson Type VII) distribution'''
        return ctx_student_t(self, n)


# 29.10 Skew t-distribution

    def dist_skew_t(self, n):
        '''Student t (Pearson Type VII) distribution'''
        return ctx_skew_t(self, n)


# 29.11 Pearson’s rho distribution (under H0)

    def dist_pearson_rho(self, a, b):
        '''Pearson’s rho distribution (under H0)'''
        return ctx_pearson_rho(self, a, b)





# %% 23 Noncentral distribution functions


# 31.1 Noncentral chi^2 distribution

    def dist_chi2_nc(self, df_, lambda1_):
        r"""
        The **ctx_chi_squared_nc** class implements a non-central chi-squared
        distribution with n degrees of freedom and noncentrality parameter
        lambda1.


        Parameters
        ----------
        n : a real scalar of type ctx.mpf
            The degrees of freedom

        lambda1 : a real scalar of type ctx.mpf
            The noncentrality parameter

        Returns
        -------
        object
            an instance of the chi_squared_nc class


        **References**

        1. Wikipedia contributors. *Noncentral chi-squared distribution.
        Wikipedia, the free encyclopedia*.
        https://en.wikipedia.org/wiki/Noncentral_chi-squared_distribution
        """
        return ctx_chi2_nc(self, df_, lambda1_)


# 31.2 Noncentral Chi distribution

    def dist_chi_nc(self, a, b):
        '''Noncentral Chi distribution'''
        return ctx_chi_nc(self, a, b)


# 31.3 Rice distribution

    def dist_rice(self, a, b):
        '''Rice distribution'''
        return ctx_rice(self, a, b)


# 31.4 Noncentral Student t distribution

    def dist_student_t_nc(self, a, b):
        '''Noncentral Student t distribution'''
        return ctx_student_t_nc(self, a, b)


# 31.5 Noncentral distribution of the sample correlation coefficient

    def dist_pearson_rho_nc(self, a, b):
        '''Noncentral distribution of the sample correlation coefficient'''
        return ctx_pearson_rho_nc(self, a, b)


# 31.6 Noncentral Fisher F distribution

    def dist_fisher_f_nc(self, a, b):
        '''Noncentral Fisher F distribution'''
        return ctx_fisher_f_nc(self, a, b)


# 31.7 Noncentral Beta Type I distribution

    def dist_beta_nc_type_I(self, a, b):
        '''Noncentral Beta Type I distribution'''
        return ctx_beta_nc_type_I(self, a, b)


# 31.8 Noncentral Beta Type II distribution

    def dist_logrv_beta_nc_type_II(self, a, b):
        '''Noncentral Beta Type II distribution'''
        return ctx_logrv_beta_nc_type_II(self, a, b)


# 31.9 Noncentral distribution (Type I) of Fisher’s R^2

    def dist_fisher_r2(self, a, b):
        '''Noncentral distribution (Type I) of Fisher’s R^2'''
        return ctx_fisher_r2(self, a, b)


# 31.10 Noncentral distribution (Type II) of Fisher’s R^2

    def dist_logrv_fisher_1mr2(self, a, b):
        '''Noncentral distribution (Type II) of Fisher’s R^2'''
        return ctx_logrv_fisher_1mr2(self, a, b)


# 31.11 Doubly non-central Student t distribution

    def dist_student_t_2nc(self, a, b):
        '''Doubly non-central Student t distribution'''
        return ctx_student_t_2nc(self, a, b)


# 31.12 Doubly non-central Fisher F distribution

    def dist_fisher_f_2nc(self, a, b):
        '''Doubly non-central Fisher F distribution'''
        return ctx_fisher_f_2nc(self, a, b)




# %% 24 Distributions related to multiple comparisons of means


# 32.3 Normal maximum distribution, equicorrelated case

    def dist_nmax_corr(self, k, rho):
        '''Normal maximum distribution, equicorrelated case'''
        return ctx_nmax_corr(self, k, rho)


# 32.4 Normal maximum modulus distribution, equicorrelated case

    def dist_nmm_corr(self, k, rho):
        '''Normal maximum modulus distribution, equicorrelated case'''
        return ctx_nmm_corr(self, k, rho)


# 32.5 Normal range distribution

    def dist_normal_range(self, k):
        '''Normal range distribution'''
        return ctx_normal_range(self, k)


# 32.6 Studentized maximum distribution

    def dist_smax(self, k, n):
        '''Studentized maximum distribution'''
        return ctx_smax(self, k, n)


# 32.7 Studentized maximum modulus distribution

    def dist_smm(self, k, n):
        '''Studentized maximum modulus distribution'''
        return ctx_smm(self, k, n)


# 32.8 Distribution of Dunnett’s t, one-sided

    def dist_dunnett1_t(self, k, n, rho):
        '''Distribution of Dunnett’s t, one-sided'''
        return ctx_dunnett1_t(self, k, n, rho)


# 32.9 Distribution of Dunnett’s t, two-sided

    def dist_dunnett2_t(self, k, n, rho):
        '''Distribution of Dunnett’s t, two-sided'''
        return ctx_dunnett2_t(self, k, n, rho)


# 32.9 Distribution of Nair's t, two-sided

    def dist_nair_t(self, a, b):
        '''Distribution of Dunnett’s t, two-sided'''
        return ctx_nair_t(self, a, b)


# 32.9 Distribution of Halperin’s t, two-sided

    def dist_halperin_t(self, a, b):
        '''Distribution of Dunnett’s t, two-sided'''
        return ctx_halperin_t(self, a, b)


# 32.10 Studentized range distribution

    def dist_studentized_range(self, a, b):
        '''Studentized range distribution'''
        return ctx_studentized_range(self, a, b)





# %% 25 Distribution functions related to multivariate statistical analysis

# 30.9 Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix

    def dist_lrt_s0(self, a, b):
        '''Distribution of the modified likelihood ratio test (LRT) for a given
        covariance matrix'''
        return ctx_lrt_s0(self, a, b)


# 30.10 Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix and mean vector

    def dist_lrt_x0_s0(self, a, b):
        '''Distribution of the modified likelihood ratio test (LRT) for a given
        covariance matrix and mean vector'''
        return ctx_lrt_x0_s0(self, a, b)


# 30.1 Distribution of the product of independent beta variables

    def dist_betaproduct(self, a, b):
        '''Distribution of the product of independent beta variables'''
        return ctx_betaproduct(self, a, b)


# 30.2 Distribution of the negative logarithm of a betaproduct variable

    def dist_logrv_betaproduct(self, a, b):
        '''Distribution of the negative logarithm of a betaproduct variable'''
        return ctx_logrv_betaproduct(self, a, b)


# 30.3 Bartlett distribution

    def dist_bartlett(self, a, b):
        '''Bartlett distribution'''
        return ctx_bartlett(self, a, b)


# 30.3 Wilks_ip distribution

    def dist_wilks_ip(self, a, b):
        '''Wilks_ip distribution'''
        return ctx_wilks_ip(self, a, b)

# 30.3 Mauchley distribution

    def dist_mauchley(self, a, b):
        '''Bartlett distribution'''
        return ctx_mauchley(self, a, b)


# 30.3 Wilks_cs distribution

    def dist_ctx_wilks_cs(self, a, b):
        '''Wilks_cs distribution'''
        return ctx_wilks_cs(self, a, b)


# 30.3 Wilks_iblocks distribution

    def dist_wilks_iblocks(self, a, b):
        '''Wilks_iblocks distribution'''
        return ctx_wilks_iblocks(self, a, b)


# 30.3 Box_nsame_cov distribution

    def dist_box_nsame_cov(self, a, b):
        '''Wilks_iblocks distribution'''
        return ctx_box_nsame_cov(self, a, b)


# 30.3 Box_nsame_means_cov distribution

    def dist_box_nsame_means_cov(self, a, b):
        '''Wilks_iblocks distribution'''
        return ctx_box_nsame_means_cov(self, a, b)


# 30.7 Distribution of Box’s test of equality of k covariance matrices, unequal
    # sample sizes

    def dist_box_cov(self, a, b):
        '''Distribution of Box’s test of equality of k covariance matrices,
        unequal sample sizes'''
        return ctx_box_cov(self, a, b)


# 30.8 Distribution of Box’s test for same multivariate normal distributions,
    # unequal sample sizes

    def dist_box_mvn(self, a, b):
        '''Distribution of Box’s test for same multivariate normal
        distributions, unequal sample sizes'''
        return ctx_box_mvn(self, a, b)


# 30.3 Central distribution of Roy’s largest root

    def dist_roy(self, a, b):
        '''Central distribution of Roy’s largest root'''
        return ctx_roy(self, a, b)


# 30.4 Central distribution of Wilks' Lambda

    def dist_wilks_lambda(self, a, b):
        '''Central distribution of Wilks' Lambda'''
        return ctx_wilks_lambda(self, a, b)


# 30.5 Central distribution of Pillai’s V

    def dist_pillai_v(self, a, b):
        '''Central distribution of Pillai’s V'''
        return ctx_pillai_v(self, a, b)


# 30.6 Central distribution of Hotelling’s T2

    def dist_hotelling_t2(self, a, b):
        '''Central distribution of Hotelling’s T2'''
        return ctx_hotelling_t2(self, a, b)



# 31.13 Noncentral Distribution of Wilks' Lambda: MANOVA

    def dist_wilks_lambda_glm(self, a, b):
        '''Noncentral Distribution of Wilks' Lambda: MANOVA'''
        return ctx_wilks_lambda_glm(self, a, b)


# 31.14 Noncentral Distribution of  Wilks' Lambda: Canonical Correlation

    def dist_wilks_lambda_corr(self, a, b):
        '''Noncentral Distribution of  Wilks' Lambda: Canonical Correlation'''
        return ctx_wilks_lambda_corr(self, a, b)




# %% 26 Miscellaneous continuous distributions


# 33.1 Lévy alpha-stable distribution

    def dist_levy_alpha_stable(self, a, b):
        '''Lévy alpha-stable distribution'''
        return ctx_levy_alpha_stable(self, a, b)


# 33.2 Landau Distribution

    def dist_landau(self, a, b):
        '''Landau Distribution'''
        return ctx_landau(self, a, b)


# 33.4 Pearson Type IV distribution

    def dist_pearson_type_IV(self, a, b):
        '''Pearson Type IV distribution'''
        return ctx_pearson_type_IV(self, a, b)


# 33.4 Meixner distribution

    def dist_meixner(self, a, b):
        '''Meixner distribution'''
        return ctx_meixner(self, a, b)


# 33.4 Wrapped Cauchy distribution

    def dist_wrapped_cauchy(self, a, b):
        '''Wrapped Cauchy distribution'''
        return ctx_wrapped_cauchy(self, a, b)


# 33.4 Wrapped Normal distribution

    def dist_wrapped_normal(self, a, b):
        '''Wrapped Normal distribution'''
        return ctx_wrapped_normal(self, a, b)


# 33.3 Voigt Profile Distribution

    def dist_voigt_profile(self, a, b):
        '''Voigt Profile Distribution'''
        return ctx_voigt_profile(self, a, b)


# 33.5 Von Mises distribution

    def dist_von_mises(self, a, b):
        '''Von Mises distribution'''
        return ctx_von_mises(self, a, b)


# 33.6 Generalized inverse Gaussian distribution

    def dist_gen_inv_gaussian(self, a, b):
        '''Generalized inverse Gaussian distribution'''
        return ctx_gen_inv_gaussian(self, a, b)


# 33.7 Harmonic distribution

    def dist_harmonic(self, a, b):
        '''Harmonic distribution'''
        return ctx_harmonic(self, a, b)


# 33.8 Halphen A distribution

    def dist_halphen_a(self, a, b):
        '''Halphen A distribution'''
        return ctx_halphen_a(self, a, b)


# 33.9 Halphen B distribution

    def dist_halphen_b(self, a, b):
        '''Halphen B distribution'''
        return ctx_halphen_b(self, a, b)


# 33.10 Halphen IB distribution

    def dist_halphen_ib(self, a, b):
        '''Halphen IB distribution'''
        return ctx_halphen_ib(self, a, b)


# 33.11 Generalized hyperbolic distribution

    def dist_gen_hyperbolic(self, a, b):
        '''Generalized hyperbolic distribution'''
        return ctx_gen_hyperbolic(self, a, b)


# 33.12 Hyperbolic distribution

    def dist_hyperbolic(self, a, b):
        '''Hyperbolic distribution'''
        return ctx_hyperbolic(self, a, b)


# 33.13 Variance-gamma distribution

    def dist_variance_gamma(self, a, b):
        '''Variance-gamma distribution'''
        return ctx_variance_gamma(self, a, b)


# %% 27 Elementary discrete (lattice) distributions


# 34.1 Geometric distribution

    def dist_geometric(self, p):
        '''Geometric distribution'''
        return ctx_geometric(self, p)


# 34.2 Log-series distribution

    def dist_logseries(self, a, b):
        '''Log-series distribution'''
        return ctx_logseries(self, a, b)


# 34.3 Poisson distribution

    def dist_poisson(self, mu):
        '''Poisson distribution'''
        return ctx_poisson(self, mu)


# 34.4 Skellam distribution

    def dist_skellam(self, a, b):
        '''Skellam distribution'''
        return ctx_skellam(self, a, b)


# 34.5 Binomial distribution

    def dist_binomial(self, n, p):
        '''Binomial distribution'''
        return ctx_binomial(self, n, p)


# 34.6 Negative binomial distribution

    def dist_negative_binomial(self, r, p):
        '''Negative binomial distribution'''
        return ctx_negative_binomial(self, r, p)


# 34.7 Delaporte distribution

    def dist_delaporte(self, a, b):
        '''Delaporte distribution'''
        return ctx_delaporte(self, a, b)


# 34.8 Beta-Poisson distribution (Quinkert)

    def dist_betapoisson(self, a, b):
        '''Beta-Poisson distribution (Quinkert)'''
        return ctx_betapoisson(self, a, b)


# 34.9 Beta-binomial distribution

    def dist_betabinomial(self, a, b):
        '''Beta-binomial distribution'''
        return ctx_betabinomial(self, a, b)


# 34.10 Beta-negative binomial distribution (Waring)

    def dist_beta_negbinomial(self, a, b):
        '''Beta-negative binomial distribution (Waring)'''
        return ctx_beta_negbinomial(self, a, b)


# 34.11 Classical hypergeometric distribution

    def dist_hypergeometric(self, n, K, N):
        '''Classical hypergeometric distribution'''
        return ctx_hypergeometric(self, n, K, N)


# 34.12 Negative hypergeometric distribution

    def dist_neghypergeo(self, a, b):
        '''Negative hypergeometric distribution'''
        return ctx_neghypergeo(self, a, b)


# 34.13 Pólya-Eggenberger distribution

    def dist_polya(self, a, b):
        '''Pólya-Eggenberger distribution'''
        return ctx_polya(self, a, b)


# 34.14 General hypergeometric distribution

    def dist_genhypergeo(self, a, b):
        '''General hypergeometric distribution'''
        return ctx_genhypergeo(self, a, b)


# 34.15 Noncentral hypergeometric distribution, Fisher alternatives

    def dist_hypergeo_nc_fisher(self, a, b):
        '''Noncentral hypergeometric distribution, Fisher alternatives'''
        return ctx_hypergeo_nc_fisher(self, a, b)


# 34.16 Zeta distribution

    def dist_zeta(self, a, b):
        '''Zeta distribution'''
        return ctx_zeta(self, a, b)


# %% 28 Discrete (lattice) distributions related to (stratified) rank tests


# 35.1 Wilcoxon signed rank T distribution, continuous data

    def dist_wilcoxon(self, a, b):
        '''Wilcoxon signed rank T distribution, continuous data'''
        return ctx_wilcoxon(self, a, b)


# 35.2 Noncentral Wilcoxon signed rank T distribution, Bennett alternatives

    def dist_bennett(self, a, b):
        '''Noncentral Wilcoxon signed rank T distribution,
        Bennett alternatives'''
        return ctx_bennett(self, a, b)


# 35.3 Mann-Whitney U distribution, continuous data

    def dist_mann_whitney_u(self, a, b):
        '''Mann-Whitney U distribution, continuous data'''
        return ctx_mann_whitney_u(self, a, b)


# 35.4 Noncentral Mann-Whitney U distribution, Lehmann alternatives

    def dist_mann_whitney_u_lehmann(self, a, b):
        '''Noncentral Mann-Whitney U distribution, Lehmann alternatives'''
        return ctx_mann_whitney_u_lehmann(self, a, b)


# 35.5 Noncentral Mann-Whitney U distribution, Milton alternatives

    def dist_mann_whitney_u_milton(self, a, b):
        '''Noncentral Mann-Whitney U distribution, Milton alternatives'''
        return ctx_mann_whitney_u_milton(self, a, b)


# 35.6 Kendall’s tau distribution, continuous data

    def dist_kendall_tau(self, a, b):
        '''Kendall’s tau distribution, continuous data'''
        return ctx_kendall_tau(self, a, b)


# 35.7 Jonckheere-Terpsta S distribution, continuous data

    def dist_jterpsta_s(self, a, b):
        '''Jonckheere-Terpsta S distribution, continuous data'''
        return ctx_jterpsta_s(self, a, b)


# 35.8 Generalized Page L distribution, continuous data

    def dist_page_l(self, a, b):
        '''Generalized Page L distribution, continuous data'''
        return ctx_page_l(self, a, b)


# 35.9 Noncentral generalized Page L distribution, Milton alternatives

    def dist_page_l_nc_milton(self, a, b):
        '''Noncentral generalized Page L distribution, Milton alternatives'''
        return ctx_page_l_nc_milton(self, a, b)


# %% 29 Discrete (non-lattice) distributions related to rank tests

# 36.1 Cochran-Friedman-Quade distribution

    def dist_friedman(self, a, b):
        '''Cochran-Friedman-Quade distribution'''
        return ctx_friedman(self, a, b)


# 36.2 Kruskal_Wallis distribution

    def dist_kruskal_wallis(self, a, b):
        '''Kruskal_Wallis distribution'''
        return ctx_kruskal_wallis(self, a, b)




# %% 105 Basic continuous distribution functions

# %%%  5.1 Closed form distributions, based on elementary functions


# 5.1.1 Arcsine distribution, pdf

    def arcsine_pdf(self, x, a=0, b=1):
        '''Returns the Arcsine distribution, pdf.'''
        return ctxm.arcsine_pdf(self, x, a, b)

# 5.1.2 Arcsine distribution, cdf and sf

    def arcsine_cdf(self, x, a=0, b=1, cdf=True):
        '''Returns the Arcsine distribution, cdf and sf.'''
        return ctxm.arcsine_cdf(self, x, a, b, cdf)

# 5.1.3 Arcsine distribution, qtf and isf

    def arcsine_qtf(self, prob, a=0, b=1, qtf=True):
        '''Returns the Arcsine distribution, qtf and isf.'''
        return ctxm.arcsine_qtf(self, prob, a, b, qtf)


# 5.1.4 Cauchy distribution, pdf

    def cauchy_pdf(self, x, a, b):
        '''Returns the Cauchy distribution, pdf.'''
        return ctxm.cauchy_pdf(self, x, a, b)

# 5.1.5 Cauchy distribution, cdf and sf

    def cauchy_cdf(self, x, a, b, cdf=True):
        '''Returns the Cauchy distribution, cdf and sf.'''
        return ctxm.cauchy_cdf(self, x, a, b, cdf)

# 5.1.6 Cauchy distribution, qtf and isf

    def cauchy_qtf(self, prob, a, b, qtf=True):
        '''Returns the Cauchy distribution, qtf and isf.'''
        return ctxm.cauchy_qtf(self, prob, a, b, qtf)


# 5.1.7 Dagum distribution, pdf

    def dagum_pdf(self, x, a, b, p):
        '''Returns the Dagum distribution, pdf.'''
        return ctxm.dagum_pdf(self, x, a, b, p)

# 5.1.8 Dagum distribution, cdf and sf

    def dagum_cdf(self, x, a, b, p, cdf=True):
        '''Returns the Dagum distribution, cdf and sf.'''
        return ctxm.dagum_cdf(self, x, a, b, p, cdf)

# 5.1.9 Dagum distribution, qtf and isf

    def dagum_qtf(self, prob, a, b, p, qtf=True):
        '''Returns the Dagum distribution, qtf and isf.'''
        return ctxm.dagum_qtf(self, prob, a, b, p, qtf)


# 5.1.10 Exponential distribution, pdf

    def exponential_pdf(self, x, lambda1):
        '''Returns the Exponential distribution, pdf.'''
        return ctxm.exponential_pdf(self, x, lambda1)

# 5.1.11 Exponential distribution, cdf and sf

    def exponential_cdf(self, x, lambda1, cdf=True):
        '''Returns the Exponential distribution, cdf and sf.'''
        return ctxm.exponential_cdf(self, x, lambda1, cdf)

# 5.1.12 Exponential distribution, qtf and isf

    def exponential_qtf(self, prob, lambda1, qtf=True):
        '''Returns the Exponential distribution, qtf and isf.'''
        return ctxm.exponential_qtf(self, prob, lambda1, qtf)


# 5.1.13 Fisk distribution, pdf

    def fisk_pdf(self, x, a, b):
        '''Returns the Fisk distribution, pdf.'''
        return ctxm.fisk_pdf(self, x, a, b)

# 5.1.14 Fisk distribution, cdf and sf

    def fisk_cdf(self, x, a, b, cdf=True):
        '''Returns the Fisk distribution, cdf and sf.'''
        return ctxm.fisk_cdf(self, x, a, b, cdf)

# 5.1.15 Fisk distribution, qtf and isf

    def fisk_qtf(self, prob, a, b, qtf=True):
        '''Returns the Fisk distribution, qtf and isf.'''
        return ctxm.fisk_qtf(self, prob, a, b, qtf)


# 5.1.16 Frechet distribution, pdf

    def frechet_pdf(self, x, a, b):
        '''Returns the Frechet distribution, pdf.'''
        return ctxm.frechet_pdf(self, x, a, b)

# 5.1.17 Frechet distribution, cdf and sf

    def frechet_cdf(self, x, a, b, cdf=True):
        '''Returns the Frechet distribution, cdf and sf.'''
        return ctxm.frechet_cdf(self, x, a, b, cdf)

# 5.1.18 Frechet distribution, qtf and isf

    def frechet_qtf(self, prob, a, b, qtf=True):
        '''Returns the Frechet distribution, qtf and isf.'''
        return ctxm.frechet_qtf(self, prob, a, b, qtf)


# 5.1.19 Generalized Extreme Value (GEV), pdf

    def gev_pdf(self, x, a, b, c, Max=True):
        '''Returns the Generalized Extreme Value (GEV), pdf.'''
        return ctxm.gev_pdf(self, x, a, b, c)

# 5.1.20 Generalized Extreme Value (GEV), cdf and sf

    def gev_cdf(self, x, a, b, c, cdf=True, Max=True):
        '''Returns the Generalized Extreme Value (GEV), cdf and sf.'''
        return ctxm.gev_cdf(self, x, a, b, c, cdf, Max)

# 5.1.21 Generalized Extreme Value (GEV), qtf and isf

    def gev_qtf(self, prob, a, b, c, qtf=True, Max=True):
        '''Returns the Generalized Extreme Value (GEV), qtf and isf.'''
        return ctxm.gev_qtf(self, prob, a, b, c, qtf, Max)


# 5.1.22 Generalized Pareto distribution, pdf

    def genpareto_pdf(self, x, m, s, c):
        '''Returns the Generalized Pareto distribution, pdf.'''
        return ctxm.genpareto_pdf(self, x, m, s, c)

# 5.1.23 Generalized Pareto distribution, cdf and sf

    def genpareto_cdf(self, x, m, s, c, cdf=True):
        '''Returns the Generalized Pareto distribution, cdf and sf.'''
        return ctxm.genpareto_cdf(self, x, m, s, c, cdf)

# 5.1.24 Generalized Pareto distribution, qtf and isf

    def genpareto_qtf(self, prob, m, s, c, qtf=True):
        '''Returns the Generalized Pareto distribution, qtf and isf.'''
        return ctxm.genpareto_qtf(self, prob, m, s, c, qtf)


# 5.1.25 Gompertz-Makeham distribution, pdf

    def gompertz_pdf(self, x, a, b, l):
        '''Returns the Gompertz-Makeham distribution, pdf.'''
        return ctxm.gompertz_pdf(self, x, a, b, l)

# 5.1.26 Gompertz-Makeham distribution, cdf and sf

    def gompertz_cdf(self, x, a, b, l, cdf=True):
        '''Returns the Gompertz-Makeham distribution, cdf and sf.'''
        return ctxm.gompertz_cdf(self, x, a, b, l, cdf)

# 5.1.27 Gompertz-Makeham distribution, qtf and isf

    def gompertz_qtf(self, prob, a, b, l, qtf=True):
        '''Returns the Gompertz-Makeham distribution, qtf and isf.'''
        return ctxm.gompertz_qtf(self, prob, a, b, l, qtf)


# 5.1.28 Gumbel (Extreme Value) distribution, pdf

    def gumbel_pdf(self, x, a, b):
        '''Returns the Gumbel (Extreme Value) distribution, pdf.'''
        return ctxm.gumbel_pdf(self, x, a, b)

# 5.1.29 Gumbel (Extreme Value) distribution, cdf and sf

    def gumbel_cdf(self, x, a, b, cdf=True):
        '''Returns the Gumbel (Extreme Value) distribution, cdf and sf.'''
        return ctxm.gumbel_cdf(self, x, a, b, cdf)

# 5.1.30 Gumbel (Extreme Value) distribution, qtf and isf

    def gumbel_qtf(self, prob, a, b, qtf=True):
        '''Returns the Gumbel (Extreme Value) distribution, qtf and isf.'''
        return ctxm.gumbel_qtf(self, prob, a, b, qtf)


# 5.1.31 Hyperexponential distribution, pdf

    def hyperexp_pdf(self, x, k, w, l):
        '''Returns the Hyperexponential distribution, pdf.'''
        return ctxm.hyperexp_pdf(self, x, k, w, l)

# 5.1.32 Hyperexponential distribution, cdf and sf

    def hyperexp_cdf(self, x, k, w, l, cdf=True):
        '''Returns the Hyperexponential distribution, cdf and sf.'''
        return ctxm.hyperexp_cdf(self, x, k, w, l, cdf)

# 5.1.33 Hyperexponential distribution, qtf and isf

    def hyperexp_qtf(self, prob, k, w, l, qtf=True):
        '''Returns the Hyperexponential distribution, qtf and isf.'''
        return ctxm.hyperexp_qtf(self, prob, k, w, l, qtf)


# 5.1.34 Kumaraswamy distribution, pdf

    def kumaraswamy_pdf(self, x, a, b):
        '''Returns the Kumaraswamy distribution, pdf.'''
        return ctxm.kumaraswamy_pdf(self, x, a, b)

# 5.1.35 Kumaraswamy distribution, cdf and sf

    def kumaraswamy_cdf(self, x, a, b, cdf=True):
        '''Returns the Kumaraswamy distribution, cdf and sf.'''
        return ctxm.kumaraswamy_cdf(self, x, a, b, cdf)

# 5.1.36 Kumaraswamy distribution, qtf and isf

    def kumaraswamy_qtf(self, prob, a, b, qtf=True):
        '''Returns the Kumaraswamy distribution, qtf and isf.'''
        return ctxm.kumaraswamy_qtf(self, prob, a, b, qtf)


# 5.1.37 Laplace distribution, pdf

    def laplace_pdf(self, x, a, b):
        '''Returns the Laplace distribution, pdf.'''
        return ctxm.laplace_pdf(self, x, a, b)

# 5.1.38 Laplace distribution, cdf and sf

    def laplace_cdf(self, x, a, b, cdf=True):
        '''Returns the Laplace distribution, cdf and sf.'''
        return ctxm.laplace_cdf(self, x, a, b, cdf)

# 5.1.39 Laplace distribution, qtf and isf

    def laplace_qtf(self, prob, a, b, qtf=True):
        '''Returns the Laplace distribution, qtf and isf.'''
        return ctxm.laplace_qtf(self, prob, a, b, qtf)


# 5.1.40 Logistic distribution, pdf

    def logistic_pdf(self, x, a, b):
        '''Returns the Logistic distribution, pdf.'''
        return ctxm.logistic_pdf(self, x, a, b)

# 5.1.41 Logistic distribution, cdf and sf

    def logistic_cdf(self, x, a, b, cdf=True):
        '''Returns the Logistic distribution, cdf and sf.'''
        return ctxm.logistic_cdf(self, x, a, b, cdf)

# 5.1.42 Logistic distribution, qtf and isf

    def logistic_qtf(self, prob, a, b, qtf=True):
        '''Returns the Logistic distribution, qtf and isf.'''
        return ctxm.logistic_qtf(self, prob, a, b, qtf)


# 5.1.43 Lomax distribution, pdf

    def lomax_pdf(self, x, a, b):
        '''Returns the Lomax distribution, pdf.'''
        return ctxm.lomax_pdf(self, x, a, b)

# 5.1.44 Lomax distribution, cdf and sf

    def lomax_cdf(self, x, a, b, cdf=True):
        '''Returns the Lomax distribution, cdf and sf.'''
        return ctxm.lomax_cdf(self, x, a, b, cdf)

# 5.1.45 Lomax distribution, qtf and isf

    def lomax_qtf(self, prob, a, b, qtf=True):
        '''Returns the Lomax distribution, qtf and isf.'''
        return ctxm.lomax_qtf(self, prob, a, b, qtf)


# 5.1.46 Pareto distribution, pdf

    def pareto_pdf(self, x, a, b):
        '''Returns the Pareto distribution, pdf.'''
        return ctxm.pareto_pdf(self, x, a, b)

# 5.1.47 Pareto distribution, cdf and sf

    def pareto_cdf(self, x, a, b, cdf=True):
        '''Returns the Pareto distribution, cdf and sf.'''
        return ctxm.pareto_cdf(self, x, a, b, cdf)

# 5.1.48 Pareto distribution, qtf and isf

    def pareto_qtf(self, prob, a, b, qtf=True):
        '''Returns the Pareto distribution, qtf and isf.'''
        return ctxm.pareto_qtf(self, prob, a, b, qtf)


# 5.1.49 Rayleigh distribution, pdf

    def rayleigh_pdf(self, x, b):
        '''Returns the Rayleigh distribution, pdf.'''
        return ctxm.rayleigh_pdf(self, x, b)

# 5.1.50 Rayleigh distribution, cdf and sf

    def rayleigh_cdf(self, x, b, cdf=True):
        '''Returns the Rayleigh distribution, cdf and sf.'''
        return ctxm.rayleigh_cdf(self, x, b, cdf)

# 5.1.51 Rayleigh distribution, qtf and isf

    def rayleigh_qtf(self, prob, b, qtf=True):
        '''Returns the Rayleigh distribution, qtf and isf.'''
        return ctxm.rayleigh_qtf(self, prob, b, qtf)


# 5.1.52 Shifted Gompertz distribution, pdf

    def shifted_gompertz_pdf(self, x, a, b):
        '''Returns the Shifted Gompertz distribution, pdf.'''
        return ctxm.shifted_gompertz_pdf(self, x, a, b)

# 5.1.53 Shifted Gompertz distribution, cdf and sf

    def shifted_gompertz_cdf(self, x, a, b, cdf=True):
        '''Returns the Shifted Gompertz distribution, cdf and sf.'''
        return ctxm.shifted_gompertz_cdf(self, x, a, b, cdf)

# 5.1.54 Shifted Gompertz distribution, qtf and isf

    def shifted_gompertz_qtf(self, prob, a, b, qtf=True):
        '''Returns the Shifted Gompertz distribution, qtf and isf.'''
        return ctxm.shifted_gompertz_qtf(self, prob, a, b, qtf)


# 5.1.55 Singh-Maddala (Burr Type XII) distribution, pdf

    def singh_maddala_pdf(self, x, a, b, d):
        '''Returns the Singh-Maddala (Burr Type XII) distribution, pdf.'''
        return ctxm.singh_maddala_pdf(self, x, a, b, d)

# 5.1.56 Singh-Maddala (Burr Type XII) distribution, cdf and sf

    def singh_maddala_cdf(self, x, a, b, d, cdf=True):
        '''Returns the Singh-Maddala (Burr Type XII) distribution,
        cdf and sf.'''
        return ctxm.singh_maddala_cdf(self, x, a, b, d, cdf)

# 5.1.57 Singh-Maddala (Burr Type XII) distribution, qtf and isf

    def singh_maddala_qtf(self, prob, a, b, d, qtf=True):
        '''Returns the Singh-Maddala (Burr Type XII) distribution,
        qtf and isf.'''
        return ctxm.singh_maddala_qtf(self, prob, a, b, d, qtf)


# 5.1.58 Triangular distribution, pdf

    def triangular_pdf(self, x, lower, upper, mode):
        '''Returns the Triangular distribution, pdf.'''
        return ctxm.triangular_pdf(self, x, lower, upper, mode)

# 5.1.59 Triangular distribution, cdf and sf

    def triangular_cdf(self, x, lower, mode, upper, cdf=True):
        '''Returns the Triangular distribution, cdf and sf.'''
        return ctxm.triangular_cdf(self, x, lower, mode, upper, cdf)

# 5.1.60 Triangular distribution, qtf and isf

    def triangular_qtf(self, prob, lower, mode, upper, qtf=True):
        '''Returns the Triangular distribution, qtf and isf'''
        return ctxm.triangular_qtf(self, prob, lower, mode, upper, qtf)


# 5.1.61 Uniform distribution, pdf

    def uniform_pdf(self, x, a, b):
        '''Returns the Uniform distribution, pdf'''
        return ctxm.uniform_pdf(self, x, a, b)

# 5.1.62 Uniform distribution, cdf and sf

    def uniform_cdf(self, x, a, b, cdf=True):
        '''Returns the Uniform distribution, cdf and sf'''
        return ctxm.uniform_cdf(self, x, a, b, cdf)


# 5.1.63 Uniform distribution, qtf and isf

    def uniform_qtf(self, prob, a, b, qtf=True):
        '''Returns the Uniform distribution, qtf and isf'''
        return ctxm.uniform_qtf(self, prob, a, b, qtf)


# 5.1.64 Weibull distribution, pdf

    def weibull_pdf(self, x, a, b, Max=False):
        '''Returns the Weibull distribution, pdf'''
        return ctxm.weibull_pdf(self, x, a, b, Max)

# 5.1.65 Weibull distribution, cdf and sf

    def weibull_cdf(self, x, a, b, cdf=True, Max=False):
        '''Returns the Weibull distribution, cdf and sf'''
        return ctxm.weibull_cdf(self, x, a, b, cdf, Max)

# 5.1.66 Weibull distribution, qtf and isf

    def weibull_qtf(self, prob, a, b, qtf=True, Max=False):
        '''Returns the Weibull distribution, qtf and isf'''
        return ctxm.weibull_qtf(self, prob, a, b, qtf, Max)


# %%%  5.2 Closed form distributions, based on the error function


# 5.2.1 Birnbaum-Saunders distribution, pdf

    def birnb_saunders_pdf(self, x, mu, sigma):
        '''Returns the Birnbaum-Saunders distribution, pdf'''
        return ctxm.birnb_saunders_pdf(self, x, mu, sigma)

# 5.2.2 Birnbaum-Saunders distribution, cdf and sf

    def birnb_saunders_cdf(self, x, mu, sigma, cdf=True):
        '''Returns the Birnbaum-Saunders distribution, cdf and sf'''
        return ctxm.birnb_saunders_cdf(self, x, mu, sigma, cdf)

# 5.2.3 Birnbaum-Saunders distribution distribution, qtf and isf

    def birnb_saunders_qtf(self, x, mu, sigma, qtf=True):
        '''Returns the Birnbaum-Saunders distribution distribution, qtf and
        isf'''
        return ctxm.birnb_saunders_qtf(self, x, mu, sigma, qtf)


# 5.2.4 Exponentially Modified Gaussian (EMG) distribution, pdf

    def emg_pdf(self, x, mu, sigma):
        '''Returns the Exponentially Modified Gaussian (EMG) distribution,
        pdf'''
        return ctxm.emg_pdf(self, x, mu, sigma)

# 5.2.5 Exponentially Modified Gaussian (EMG) distribution, cdf and sf

    def emg_cdf(self, x, mu, sigma, cdf=True):
        '''Returns the Exponentially Modified Gaussian (EMG) distribution,
        cdf and sf'''
        return ctxm.emg_cdf(self, x, mu, sigma, cdf)

# 5.2.6 Exponentially Modified Gaussian (EMG) distribution, qtf and isf

    def emg_qtf(self, x, mu, sigma, qtf=True):
        '''Returns the Exponentially Modified Gaussian (EMG) distribution,
        cdf and sf'''
        return ctxm.emg_qtf(self, x, mu, sigma, qtf)


# 5.2.7 Folded normal distribution, pdf

    def folded_normal_pdf(self, x, sigma):
        '''Returns the Folded normal distribution, pdf'''
        return ctxm.folded_normal_pdf(self, x, sigma)

# 5.2.8 Folded normal distribution, cdf and sf

    def folded_normal_cdf(self, x, sigma, cdf=True):
        '''Returns the Folded normal distribution, cdf and sf'''
        return ctxm.folded_normal_cdf(self, x, sigma, cdf)

# 5.2.9 Folded normal distribution, qtf and isf

    def folded_normal_qtf(self, x, sigma, qtf=True):
        '''Returns the Folded normal distribution, qtf and isf'''
        return ctxm.folded_normal_qtf(self, x, sigma, qtf)


# 5.2.10 Half-normal distribution, pdf

    def half_normal_pdf(self, x, sigma):
        '''Returns the Half-normal distribution, pdf'''
        return ctxm.half_normal_pdf(self, x, sigma)

# 5.2.11 Half_normal distribution, cdf and sf

    def half_normal_cdf(self, x, sigma, cdf=True):
        '''Returns the Half_normal distribution, cdf and sf'''
        return ctxm.half_normal_cdf(self, x, sigma, cdf)

# 5.2.12 Half_normal distribution, qtf and isf

    def half_normal_qtf(self, x, sigma, qtf=True):
        '''Returns the Half_normal distribution, qtf and isf'''
        return ctxm.half_normal_qtf(self, x, sigma, qtf)


# 5.2.13 Johnson SB distribution, pdf

    def johnson_sb_pdf(self, x, sigma):
        '''Returns the Johnson SB distribution, pdf'''
        return ctxm.johnson_sb_pdf(self, x, sigma)

# 5.2.14 Johnson SB distribution, cdf and sf

    def johnson_sb_cdf(self, x, sigma, cdf=True):
        '''Returns the Johnson SB distribution, cdf and sf'''
        return ctxm.johnson_sb_cdf(self, x, sigma, cdf)

# 5.2.15 Johnson SB distribution, qtf and isf

    def johnson_sb_qtf(self, x, sigma, qtf=True):
        '''Returns the Johnson SB distribution, qtf and isf'''
        return ctxm.johnson_sb_qtf(self, x, sigma, qtf)


# 5.2.16 Johnson SU distribution, pdf

    def johnson_su_pdf(self, x, sigma):
        '''Returns the Johnson SU distribution, pdf'''
        return ctxm.johnson_su_pdf(self, x, sigma)

# 5.2.17 Johnson SU distribution, cdf and sf

    def johnson_su_cdf(self, x, sigma, cdf=True):
        '''Returns the Johnson SU distribution, cdf and sf'''
        return ctxm.johnson_su_cdf(self, x, sigma, cdf)

# 5.2.18 Johnson SU distribution, qtf and isf

    def johnson_su_qtf(self, x, sigma, qtf=True):
        '''Returns the Johnson SU distribution, qtf and isf'''
        return ctxm.johnson_su_qtf(self, x, sigma, qtf)


# 5.2.19 Lévy distribution, pdf

    def levy_pdf(self, x, a, b):
        '''Returns the Lévy distribution, pdf'''
        return ctxm.levy_pdf(self, x, a, b)

# 5.2.20 Lévy distribution, cdf and sf
    def levy_cdf(self, x, a, b, cdf=True):
        '''Returns the Lévy distribution, cdf and sf'''
        return ctxm.levy_cdf(self, x, a, b, cdf)

# 5.2.21 Lévy distribution, qtf and isf

    def levy_qtf(self, prob, a, b, qtf=True):
        '''Returns the Lévy distribution, qtf and isf'''
        return ctxm.levy_qtf(self, prob, a, b, qtf)


# 5.2.22 Lognormal distribution, pdf

    def lognormal_pdf(self, x, mu, sigma):
        '''Returns the Lognormal distribution, pdf'''
        return ctxm.lognormal_pdf(self, x, mu, sigma)

# 5.2.23 Lognormal distribution, cdf and sf

    def lognormal_cdf(self, x, mu, sigma, cdf=True):
        '''Returns the Lognormal distribution, cdf and sf'''
        return ctxm.lognormal_cdf(self, x, mu, sigma, cdf)

# 5.2.24 Lognormal distribution, qtf and isf

    def lognormal_qtf(self, prob, mu, sigma, qtf=True):
        '''Returns the Lognormal distribution, qtf and isf'''
        return ctxm.lognormal_qtf(self, prob, mu, sigma, qtf)


# 5.2.25 Moyal distribution, pdf

    def moyal_pdf(self, x, a, b):
        '''Returns the Moyal distribution, pdf'''
        return ctxm.moyal_pdf(self, x, a, b)

# 5.2.26 Moyal distribution, cdf and sf

    def moyal_cdf(self, x, a, b, cdf=True):
        '''Returns the Moyal distribution, cdf and sf'''
        return ctxm.moyal_cdf(self, x, a, b, cdf)

# 5.2.27 Moyal distribution, qtf and isf

    def moyal_qtf(self, prob, a, b, qtf=True):
        '''Returns the Moyal distribution, qtf and isf'''
        return ctxm.moyal_qtf(self, prob, a, b, qtf)


# 5.2.28 Normal distribution, pdf

    def normal_pdf(self, x, mu=0, sigma=1):
        '''Returns the Normal distribution, pdf'''
        return ctxm.normal_pdf(self, x, mu, sigma)

# 5.2.29 Normal distribution, cdf and sf

    def normal_cdf(self, x, mu=0, sigma=1, cdf=True):
        '''Returns the Normal distribution, cdf and sf'''
        return ctxm.normal_cdf(self, x, mu, sigma, cdf)

# 5.2.30 Normal distribution, qtf and isf

    def normal_qtf(self, prob, mu=0, sigma=1, qtf=True):
        '''Returns the Normal distribution, qtf and isf'''
        return ctxm.normal_qtf(self, prob, mu, sigma, qtf)


# 5.2.31 Normal maximum distribution: pdf

    def nmax_pdf(self, x, k):
        '''Returns the Normal maximum distribution: pdf'''
        return ctxm.nmax_pdf(self, x, k)

# 5.2.32 Normal maximum distribution: cdf and sf

    def nmax_cdf(self, x, k, cdf=True):
        '''Returns the Normal maximum distribution: cdf and sf'''
        return ctxm.nmax_cdf(self, x, k)

# 5.2.33 Normal maximum distribution: qtf and isf

    def nmax_qtf(self, q, k, qtf=True):
        '''Returns the Normal maximum distribution: qtf and isf'''
        return ctxm.nmax_qtf(self, q, k)


# 5.2.34 Normal maximum modulus distribution: pdf

    def nmm_pdf(self, x, k):
        '''Returns the Normal maximum modulus distribution: pdf'''
        return ctxm.nmm_pdf(self, x, k)

# 5.2.35 Normal maximum modulus distribution: cdf and sf

    def nmm_cdf(self, x, k, cdf=True):
        '''Returns the Normal maximum modulus distribution: cdf and sf'''
        return ctxm.nmm_cdf(self, x, k)

# 5.2.36 Normal maximum modulus distribution: qtf and isf

    def nmm_qtf(self, q, k, qtf=True):
        '''Returns the Normal maximum modulus distribution: qtf and isf'''
        return ctxm.nmm_qtf(self, q, k)


# 5.2.37 Sinh-arcsinh normal distribution, pdf

    def sasnormal_pdf(self, x, a, b, c):
        '''Returns the Sinh-arcsinh normal distribution, pdf'''
        return ctxm.sasnormal_pdf(self, x, a, b, c)

# 5.2.38 Sinh-arcsinh normal distribution, cdf and sf

    def sasnormal_cdf(self, x, a, b, c, cdf=True):
        '''Returns the Sinh-arcsinh normal distribution, cdf and sf'''
        return ctxm.sasnormal_cdf(self, x, a, b, c, cdf)

# 5.2.39 Sinh-arcsinh normal distribution, qtf and isf

    def sasnormal_qtf(self, prob, a, b, c, qtf=True):
        '''Returns the Sinh-arcsinh normal distribution, qtf and isf'''
        return ctxm.sasnormal_qtf(self, prob, a, b, c, qtf)


# 5.2.40 Skew normal distribution, pdf

    def skewnormal_pdf(self, x, a, b, c):
        '''Returns the Skew normal distribution, pdf'''
        return ctxm.skewnormal_pdf(self, x, a, b, c)

# 5.2.41 Skew normal distribution, cdf and sf

    def skewnormal_cdf(self, x, a, b, c, cdf=True):
        '''Returns the Skew normal distribution, cdf and sf'''
        return ctxm.skewnormal_cdf(self, x, a, b, c, cdf)

# 5.2.42 Skew normal distribution, qtf and isf

    def skewnormal_qtf(self, prob, a, b, c, qtf=True):
        '''Returns the Skew normal distribution, qtf and isf'''
        return ctxm.skewnormal_qtf(self, prob, a, b, c, qtf)


# 5.2.43 Truncated normal distribution, pdf

    def trunc_normal_pdf(self, x, a, b, c):
        '''Returns the Truncated normal distribution, pdf'''
        return ctxm.trunc_normal_pdf(self, x, a, b, c)

# 5.2.44 Truncated normal distribution, cdf and sf

    def trunc_normal_cdf(self, x, a, b, c, cdf=True):
        '''Returns the Truncated normal distribution, cdf and sf'''
        return ctxm.trunc_normal_cdf(self, x, a, b, c, cdf)

# 5.2.45 Truncated normal distribution, qtf and isf

    def trunc_normal_qtf(self, prob, a, b, c, qtf=True):
        '''Returns the Truncated normal distribution, qtf and isf'''
        return ctxm.trunc_normal_qtf(self, prob, a, b, c, qtf)


# 5.2.46 Wald distribution, pdf

    def wald_pdf(self, x, mu, b):
        '''Returns the Wald distribution, pdf'''
        return ctxm.wald_pdf(self, x, mu, b)

# 5.2.47 Wald distribution, cdf and sf

    def wald_cdf(self, x, mu, b, cdf=True):
        '''Returns the Wald distribution, cdf and sf'''
        return ctxm.wald_cdf(self, x, mu, b, cdf)

# 5.2.48 Wald distribution, qtf and isf

    def wald_qtf(self, prob, mu, b, qtf=True):
        '''Returns the Wald distribution, qtf and isf'''
        return ctxm.wald_qtf(self, prob, mu, b, qtf)


# %%%  5.3 Closed form distributions, based on the incomplete gamma function


# 5.3.1 Amoroso distribution, pdf

    def amoroso_pdf(self, x, nu):
        '''Returns the Amoroso distribution, pdf'''
        return ctxm.amoroso_pdf(self, x, nu)

# 5.3.2 Amoroso distribution, cdf and sf

    def amoroso_cdf(self, x, nu, cdf=True, **kwargs):
        '''Returns the Amoroso distribution, cdf and sf'''
        return ctxm.amoroso_cdf(self, x, nu, cdf, **kwargs)

# 5.3.3 Amoroso distribution, qtf and isf

    def amoroso_qtf(self, prob, nu, qtf=True, **kwargs):
        '''Returns the Amoroso distribution, qtf and isf'''
        return ctxm.amoroso_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.4 𝜒-distribution, pdf

    def chi_pdf(self, x, nu):
        '''Returns the 𝜒-distribution, pdf'''
        return ctxm.chi_pdf(self, x, nu)

# 5.3.5 𝜒-distribution, cdf and sf

    def chi_cdf(self, x, nu, cdf=True, **kwargs):
        '''Returns the 𝜒-distribution, cdf and sf'''
        return ctxm.chi_cdf(self, x, nu, cdf, **kwargs)

# 5.3.6 𝜒-distribution, qtf and isf

    def chi_qtf(self, prob, nu, qtf=True, **kwargs):
        '''Returns the 𝜒-distribution, qtf and isf'''
        return ctxm.chi_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.7 𝜒2-distribution, pdf

    def chi2_pdf(self, x, nu):
        '''Returns the 𝜒2-distribution, pdf'''
        return ctxm.chi2_pdf(self, x, nu)

# 5.3.8 𝜒2-distribution, cdf and sf

    def chi2_cdf(self, x, nu, cdf=True, **kwargs):
        '''Returns the 𝜒2-distribution, cdf and sf'''
        return ctxm.chi2_cdf(self, x, nu, cdf, **kwargs)

# 5.3.9 𝜒2-distribution, qtf and isf

    def chi2_qtf(self, prob, nu, qtf=True, **kwargs):
        '''Returns the 𝜒2-distribution, qtf and isf'''
        return ctxm.chi2_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.10 Distribution of the logarithm of a 𝜒2 random variable, pdf

    def logchisquare_pdf(self, x, nu):
        '''Returns the Distribution of the logarithm of a 𝜒2 random variable,
        pdf'''
        return ctxm.logchisquare_pdf(self, x, nu)

# 5.3.11 Distribution of the logarithm of a 𝜒2 random variable, cdf and sf

    def logchisquare_cdf(self, x, nu, cdf=True, **kwargs):
        '''Returns the Distribution of the logarithm of a 𝜒2 random variable,
        cdf and sf'''
        return ctxm.logchisquare_cdf(self, x, nu, cdf, **kwargs)

    def logchisquare_sf(self, x, nu, cdf=True, **kwargs):
        '''Returns the Distribution of the logarithm of a 𝜒2 random variable,
        cdf and sf'''
        return ctxm.logchisquare_sf(self, x, nu, cdf, **kwargs)

# 5.3.12 Distribution of the logarithm of a 𝜒2 random variable, qtf and isf

    def logchisquare_qtf(self, prob, nu, qtf=True, **kwargs):
        '''Returns the Distribution of the logarithm of a 𝜒2 random variable,
        qtf and isf'''
        return ctxm.logchisquare_qtf(self, prob, nu, qtf, **kwargs)

    def logchisquare_isf(self, prob, nu, qtf=True, **kwargs):
        '''Returns the Distribution of the logarithm of a 𝜒2 random variable,
        qtf and isf'''
        return ctxm.logchisquare_isf(self, prob, nu, qtf, **kwargs)


# 5.3.13 Gamma distribution, pdf

    def gamma_pdf(self, x, a, b):
        '''Returns the Gamma distribution, pdf'''
        return ctxm.gamma_pdf(self, x, a, b)

# 5.3.14 Gamma distribution, cdf and sf

    def gamma_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Gamma distribution, cdf and sf'''
        return ctxm.gamma_cdf(self, x, a, b, cdf, **kwargs)

# 5.3.15 Gamma distribution, qtf and isf

    def gamma_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Gamma distribution, qtf and isf'''
        return ctxm.gamma_qtf(self, prob, a, b, qtf, **kwargs)


# 5.3.16 Hypoexponential distribution, pdf

    def hypoexp_pdf(self, x, n, l):
        '''Returns the Hypoexponential distribution, pdf'''
        return ctxm.hypoexp_pdf(self, x, n, l)

# 5.3.17 Hypoexponential distribution, cdf and sf

    def hypoexp_cdf(self, x, n, l, cdf=True):
        '''Returns the Hypoexponential distribution, cdf and sf'''
        return ctxm.hypoexp_cdf(self, x, n, l, cdf)

# 5.3.18 Hypoexponential distribution, qtf and isf

    def hypoexp_qtf(self, prob, n, l, qtf=True):
        '''Returns the Hypoexponential distribution, qtf and isf'''
        return ctxm.hypoexp_qtf(self, prob, n, l, qtf)


# 5.3.19 Inverse 𝜒2-distribution, pdf

    def invchisquared_pdf(self, x, a, b):
        '''Returns the Inverse 𝜒2-distribution, pdf'''
        return ctxm.invchisquared_pdf(self, x, a, b)

# 5.3.20 Inverse 𝜒2-distribution, cdf and sf

    def invchisquared_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Inverse 𝜒2-distribution, cdf and sf'''
        return ctxm.invchisquared_cdf(self, x, a, b, cdf)

# 5.3.21 Inverse 𝜒2-distribution, qtf and isf

    def invchisquared_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Inverse 𝜒2-distribution, qtf and isf'''
        return ctxm.invchisquared_qtf(self, prob, a, b, qtf)


# 5.3.22 Inverse Gamma distribution, pdf

    def invgamma_pdf(self, x, a, b):
        '''Returns the Inverse Inverse Gamma distribution, pdf'''
        return ctxm.invgamma_pdf(self, x, a, b)

# 5.3.23 Inverse Gamma distribution, cdf and sf

    def invgamma_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Inverse Inverse Gamma distribution, cdf and sf'''
        return ctxm.invgamma_cdf(self, x, a, b, cdf, **kwargs)

# 5.3.24 Inverse Gamma distribution, qtf and isf

    def invgamma_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Inverse Inverse Gamma distribution, qtf and isf'''
        return ctxm.invgamma_qtf(self, prob, a, b, qtf, **kwargs)


# 5.3.25 Maxwell distribution, pdf

    def maxwell_pdf(self, x, b):
        '''Returns the Maxwell distribution, pdf'''
        return ctxm.maxwell_pdf(self, x, b)

# 5.3.26 Maxwell distribution, cdf and sf

    def maxwell_cdf(self, x, b, cdf=True, **kwargs):
        '''Returns the Maxwell distribution, cdf and sf'''
        return ctxm.maxwell_cdf(self, x, b, cdf, **kwargs)

# 5.3.27 Maxwell distribution, qtf and isf

    def maxwell_qtf(self, prob, b, qtf=True, **kwargs):
        '''Returns the Maxwell distribution, qtf and isf'''
        return ctxm.maxwell_qtf(self, prob, b, qtf, **kwargs)


# 5.3.28 Lindley distribution, pdf

    def lindley_pdf(self, x, b):
        '''Returns the Lindley distribution, pdf'''
        return ctxm.lindley_pdf(self, x, b)

# 5.3.29 Lindley distribution, cdf and sf

    def lindley_cdf(self, x, b, cdf=True, **kwargs):
        '''Returns the Lindley distribution, cdf and sf'''
        return ctxm.lindley_cdf(self, x, b, cdf, **kwargs)

# 5.3.30 Lindley distribution, qtf and isf

    def lindley_qtf(self, prob, b, qtf=True, **kwargs):
        '''Returns the Lindley distribution, qtf and isf'''
        return ctxm.lindley_qtf(self, prob, b, qtf, **kwargs)


# 5.3.31 Nakagami distribution, pdf

    def nakagami_pdf(self, x, m, w):
        '''Returns the Nakagami distribution, pdf'''
        return ctxm.nakagami_pdf(self, x, m, w)

# 5.3.32 Nakagami distribution, cdf and sf

    def nakagami_cdf(self, x, m, w, cdf=True, **kwargs):
        '''Returns the Nakagami distribution, cdf and sf'''
        return ctxm.nakagami_cdf(self, x, m, w, cdf, **kwargs)

# 5.3.33 Nakagami distribution, qtf and isf

    def nakagami_qtf(self, prob, m, w, qtf=True, **kwargs):
        '''Returns the Nakagami distribution, qtf and isf'''
        return ctxm.nakagami_qtf(self, prob, m, w, qtf, **kwargs)


# 5.3.34 Skew exponential power distribution, pdf

    def skew_exp_power_pdf(self, x, m, w):
        '''Returns the Skew exponential power distribution, pdf'''
        return ctxm.skew_exp_power_pdf(self, x, m, w)

# 5.3.35 Skew exponential power distribution, cdf and sf

    def skew_exp_power_cdf(self, x, m, w, cdf=True, **kwargs):
        '''Returns the Skew exponential power distribution, cdf and sf'''
        return ctxm.skew_exp_power_cdf(self, x, m, w, cdf, **kwargs)

# 5.3.36 Skew exponential power distribution, qtf and isf

    def skew_exp_power_qtf(self, prob, m, w, qtf=True, **kwargs):
        '''Returns the Skew exponential power distribution, qtf and isf'''
        return ctxm.skew_exp_power_qtf(self, prob, m, w, qtf, **kwargs)


# 5.3.37 Stacy (generalized gamma) distribution, pdf

    def stacy_pdf(self, x, m, w):
        '''Returns the Stacy (generalized gamma) distribution, pdf'''
        return ctxm.stacy_pdf(self, x, m, w)

# 5.3.38 Stacy (generalized gamma) distribution, cdf and sf

    def stacy_cdf(self, x, m, w, cdf=True, **kwargs):
        '''Returns the Stacy (generalized gamma) distribution, cdf and sf'''
        return ctxm.stacy_cdf(self, x, m, w, cdf, **kwargs)

# 5.3.39 Stacy (generalized gamma) distribution, qtf and isf

    def stacy_qtf(self, prob, m, w, qtf=True, **kwargs):
        '''Returns the Stacy (generalized gamma) distribution, qtf and isf'''
        return ctxm.stacy_qtf(self, prob, m, w, qtf, **kwargs)


# %%%  5.4 Closed form distributions, based on the incomplete beta function


# 5.4.1 Beta distribution, pdf

    def beta_pdf(self, x, a, b):
        '''Returns the Beta distribution, pdf'''
        return ctxm.beta_pdf(self, x, a, b)

# 5.4.2 Beta distribution, cdf and sf

    def beta_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Beta distribution, cdf and sf'''
        return ctxm.beta_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.3 Beta distribution, qtf and isf

    def beta_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Beta distribution, qtf and isf'''
        return ctxm.beta_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.4 Distribution of the negative logarithm of a beta variable, pdf

    def logrv_beta_pdf(self, x, a, b):
        '''Returns the Distribution of the negative logarithm of a beta
        variable, pdf'''
        return ctxm.logbeta_pdf(self, x, a, b)

# 5.4.5 Distribution of the negative logarithm of a beta variable, cdf and sf

    def logrv_beta_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Distribution of the negative logarithm of a beta
        variable, cdf and sf'''
        return ctxm.logbeta_cdf(self, x, a, b, cdf, **kwargs)

    def logrv_beta_sf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Distribution of the negative logarithm of a beta
        variable, cdf and sf'''
        return ctxm.logbeta_sf(self, x, a, b, cdf, **kwargs)


# 5.4.6 Distribution of the negative logarithm of a beta variable, qtf and isf

    def logrv_beta_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Distribution of the negative logarithm of a beta
        variable, qtf and isf'''
        return ctxm.logbeta_qtf(self, prob, a, b, qtf, **kwargs)

    def logrv_beta_isf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Distribution of the negative logarithm of a beta
        variable, qtf and isf'''
        return ctxm.logbeta_isf(self, prob, a, b, qtf, **kwargs)


# 5.4.7 Beta-prime distribution, pdf

    def beta_prime_pdf(self, x, a, b):
        '''Returns the Beta-prime distribution, pdf'''
        return ctxm.beta_prime_pdf(self, x, a, b)

# 5.4.8 Beta-prime distribution, cdf and sf

    def beta_prime_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Beta-prime distribution, cdf and sf'''
        return ctxm.beta_prime_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.9 Beta-prime distribution, qtf and isf

    def beta_prime_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Beta-prime distribution, qtf and isf'''
        return ctxm.beta_prime_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.10 Generalized Beta (Type 1) distribution, pdf

    def genbeta1_pdf(self, x, a, b):
        '''Returns the Generalized Beta (Type 1) distribution, pdf'''
        return ctxm.genbeta1_pdf(self, x, a, b)

# 5.4.11 Generalized Beta (Type 1) distribution, cdf and sf

    def genbeta1_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Generalized Beta (Type 1) distribution, cdf and sf'''
        return ctxm.genbeta1_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.12 Generalized Beta (Type 1) distribution, qtf and isf

    def genbeta1_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Generalized Beta (Type 1) distribution, qtf and isf'''
        return ctxm.genbeta1_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.13 Generalized Beta (Type 2) distribution, pdf

    def genbeta2_pdf(self, x, a, b):
        '''Returns the Generalized Beta (Type 2) distribution, pdf'''
        return ctxm.genbeta2_pdf(self, x, a, b)

# 5.4.14 Generalized Beta (Type 2) distribution, cdf and sf

    def genbeta2_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Generalized Beta (Type 2) distribution, cdf and sf'''
        return ctxm.genbeta2_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.15 Generalized Beta (Type 2) distribution, qtf and isf

    def genbeta2_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Generalized Beta (Type 2) distribution, qtf and isf'''
        return ctxm.genbeta2_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.16 Generalized logistic distribution, pdf

    def genlogistic_pdf(self, x, a, b):
        '''Returns the Generalized logistic distribution, pdf'''
        return ctxm.genlogistic_pdf(self, x, a, b)

# 5.4.17 Generalized logistic distribution, cdf and sf

    def genlogistic_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Generalized logistic distribution, cdf and sf'''
        return ctxm.genlogistic_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.18 Generalized logistic distribution, qtf and isf

    def genlogistic_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Generalized logistic distribution, qtf and isf'''
        return ctxm.genlogistic_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.19 Generalized beta-exponential distribution, pdf

    def gen_beta_exp_pdf(self, x, a, b):
        '''Returns the Generalized beta-exponential distribution, pdf'''
        return ctxm.gen_beta_exp_pdf(self, x, a, b)

# 5.4.20 Generalized beta-exponential distribution, cdf and sf

    def gen_beta_exp_cdf(self, x, a, b, cdf=True, **kwargs):
        '''Returns the Generalized beta-exponential distribution, cdf and sf'''
        return ctxm.gen_beta_exp_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.21 Generalized beta-exponential distribution, qtf and isf

    def gen_beta_exp_qtf(self, prob, a, b, qtf=True, **kwargs):
        '''Returns the Generalized beta-exponential distribution,
        qtf and isf'''
        return ctxm.gen_beta_exp_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.22 Feller-Pareto distribution, pdf

    def feller_pareto_pdf(self, x, df1, df2, **kwargs):
        '''Returns the Feller-Pareto distribution, pdf'''
        return ctxm.feller_pareto_pdf(self, x, df1, df2)

# 5.4.23 Feller-Pareto distribution, cdf and sf

    def feller_pareto_cdf(self, x, df1, df2, cdf=True, **kwargs):
        '''Returns the Feller-Pareto distribution, cdf and sf'''
        return ctxm.feller_pareto_cdf(self, x, df1, df2, cdf, **kwargs)

# 5.4.24 Feller-Pareto distribution, qtf and isf

    def feller_pareto_qtf(self, prob, df1, df2, qtf=True, **kwargs):
        '''Returns the Feller-Pareto distribution, qtf and isf'''
        return ctxm.feller_pareto_qtf(self, prob, df1, df2, qtf, **kwargs)


# 5.4.25 Fisher F distribution, pdf

    def fisher_f_pdf(self, x, df1, df2, **kwargs):
        '''Returns the Fisher F distribution, pdf'''
        return ctxm.fisher_f_pdf(self, x, df1, df2)

# 5.4.26 Fisher F distribution, cdf and sf

    def fisher_f_cdf(self, x, df1, df2, cdf=True, **kwargs):
        '''Returns the Fisher F distribution, cdf and sf'''
        return ctxm.fisher_f_cdf(self, x, df1, df2, cdf, **kwargs)

# 5.4.27 Fisher F distribution, qtf and isf

    def fisher_f_qtf(self, prob, df1, df2, qtf=True, **kwargs):
        '''Returns the Fisher F distribution, qtf and isf'''
        return ctxm.fisher_f_qtf(self, prob, df1, df2, qtf, **kwargs)


# 5.4.28 Fisher z distribution, pdf

    def fisher_z_pdf(self, x, df1, df2, **kwargs):
        '''Returns the Fisher z distribution, pdf'''
        return ctxm.fisher_z_pdf(self, x, df1, df2)

# 5.4.29 Fisher z distribution, cdf and sf

    def fisher_z_cdf(self, x, df1, df2, cdf=True, **kwargs):
        '''Returns the Fisher z distribution, cdf and sf'''
        return ctxm.fisher_z_cdf(self, x, df1, df2, cdf, **kwargs)

    def fisher_z_sf(self, x, df1, df2, cdf=True, **kwargs):
        '''Returns the Fisher z distribution, cdf and sf'''
        return ctxm.fisher_z_sf(self, x, df1, df2, cdf, **kwargs)

# 5.4.30 Fisher z distribution, qtf and isf

    def fisher_z_qtf(self, prob, df1, df2, qtf=True, **kwargs):
        '''Returns the Fisher z distribution, qtf and isf'''
        return ctxm.fisher_z_qtf(self, prob, df1, df2, qtf, **kwargs)

    def fisher_z_isf(self, prob, df1, df2, qtf=True, **kwargs):
        '''Returns the Fisher z distribution, qtf and isf'''
        return ctxm.fisher_z_isf(self, prob, df1, df2, qtf, **kwargs)


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



# %% 106 Advanced continuous distribution functions



# %%%  6.3 Noncentral distribution functions


# 6.3.1 Non-central 𝜒2-distribution, pdf

    def chi2_nc_pdf(self, x, n, lambda1, method='default'):
        '''Returns the Non-central 𝜒2-distribution, pdf'''
        return ctxm.chi2_nc_pdf(self, x, n, lambda1, method)

# 6.3.2 Non-central 𝜒2-distribution, cdf and sf

    def chi2_nc_cdf(self, x, n, lambda1, cdf=True, method='default'):
        '''Returns the Non-central 𝜒2-distribution, cdf and sf'''
        return ctxm.chi2_nc_cdf(self, x, n, lambda1, cdf, method)

    # Noncentral ch^2-distribution, cdf (Chou1985)
    def chi2nc_cdf(self, x, n, lambda1):
        '''Returns the Non-central 𝜒2-distribution, cdf (Chou1985)'''
        return ctxm.chi2nc_cdf(self, x, n, lambda1)

# 6.3.3 Non-central 𝜒2-distribution, qtf and isf

    def chi2_nc_qtf(self, q, n, lambda1, qtf=True, method='default'):
        '''Returns the Non-central 𝜒2-distribution, qtf and isf'''
        return ctxm.chi2_nc_qtf(self, q, n, lambda1, qtf, method)

# 6.3.4 Non-central 𝜒2-distribution: confidence limit for lambda1

    def chi2_nc_cl(self, alpha, beta, n, cdfmethod='default'):
        '''Returns the Non-central 𝜒2-distribution,
        confidence limit for lambda1'''
        return ctxm.chi2_nc_cl(self, alpha, beta, n, cdfmethod)


# 6.3.5 Generalized Marcum Q function

    def marcumq(self, alpha, beta, n):
        '''Returns the Generalized Marcum Q function'''
        return ctxm.marcumq(self, alpha, beta, n)


# 6.3.6 Noncentral Chi-distribution, pdf

    def chi_nc_pdf(self, x, n, lambda1, method='default'):
        '''Returns the Noncentral Chi-distribution, pdf'''
        return ctxm.chi_nc_pdf(self, x, n, lambda1, method)

# 6.3.7 Noncentral Chi-distribution, cdf and sf

    def chi_nc_cdf(self, x, n, lambda1, cdf=True, method='default'):
        '''Returns the Noncentral Chi-distribution, cdf and sf'''
        return ctxm.chi_nc_cdf(self, x, n, lambda1, cdf, method)

# 6.3.8 Noncentral Chi-distribution, qtf and isf

    def chi_nc_qtf(self, q, n, lambda1, qtf=True, method='default'):
        '''Returns the Noncentral Chi-distribution, qtf and isf'''
        return ctxm.chi_nc_qtf(self, q, n, lambda1, qtf, method)


# 6.3.9 Rice distribution, pdf

    def rice_pdf(self, x, nu, sigma, method='default'):
        '''Returns the Rice distribution, pdf'''
        return ctxm.rice_pdf(self, x, nu, sigma, method)

# 6.3.10 Rice distribution, cdf and sf

    def rice_cdf(self, x, nu, sigma, cdf=True, method='default'):
        '''Returns the Rice distribution, cdf and sf'''
        return ctxm.rice_cdf(self, x, nu, sigma, cdf, method)

# 6.3.11 Rice distribution, qtf and isf

    def rice_qtf(self, q, nu, sigma, qtf=True, method='default'):
        '''Returns the Rice distribution, qtf and isf'''
        return ctxm.rice_qtf(self, q, nu, sigma, qtf, qtf, method)


# 6.3.12 Non-central Student 𝑡 distribution: pdf

    def student_t_nc_pdf(self, x, n, delta, method='default'):
        '''Returns the Non-central Student 𝑡 distribution: pdf'''
        return ctxm.student_t_nc_pdf(self, x, n, delta, method)

#    #Singly Noncentral t-distribution, sf (Witkovsky2013)
#    def Tdisnc_pdf(self, x, n, delta):
#        return ctxm.Tdisnc_pdf(self, x, n, delta)


# 6.3.13 Non-central Student 𝑡 distribution: cdf and sf

    def student_t_nc_cdf(self, x, n, delta, cdf=True, method='default'):
        '''Returns the Non-central Student 𝑡 distribution: cdf and sf'''
        return ctxm.student_t_nc_cdf(self, x, n, delta, cdf, method)

    # Singly Noncentral t-distribution, cdf (Witkovsky2013)
    def tdisnc_cdf(self, x, n, delta):
        '''Returns the Singly Noncentral t-distribution, cdf (Witkovsky2013)'''
        return ctxm.tdisnc_cdf(self, x, n, delta)

    # Singly Noncentral t-distribution, sf (Witkovsky2013)
    def tdisnc_sf(self, x, n, delta):
        '''Returns the Singly Noncentral t-distribution, sf (Witkovsky2013)'''
        return ctxm.tdisnc_sf(self, x, n, delta)


# 6.3.14 Non-central Student 𝑡 distribution, qtf and isf

    def student_t_nc_qtf(self, q, n, delta, qtf=True, method='default'):
        '''Returns the Non-central Student 𝑡 distribution, qtf and isf'''
        return ctxm.student_t_nc_qtf(self, q, n, delta, qtf, method)


# 6.3.15 Non-central Student 𝑡 distribution, confidence limit for delta

    def student_t_nc_cl(self, alpha, beta, n, cdfmethod='default'):
        '''Returns the Non-central Student 𝑡 distribution,
        confidence limit for delta'''
        return ctxm.student_t_nc_cl(self, alpha, beta, n, cdfmethod)


# 6.3.16 Non-central Pearson’s rho distribution: pdf

    def pearson_rho_nc_pdf(self, r, N, rho, method='default'):
        '''Returns the Non-central Pearson’s rho distribution: pdf'''
        return ctxm.pearson_rho_nc_pdf(self, r, N, rho, method)


# 6.3.17 Non-central Pearson’s rho distribution: cdf and sf

    def pearson_rho_nc_cdf(self, r, N, rho, cdf=True, method='default'):
        '''Returns the Non-central Pearson’s rho distribution: cdf and sf'''
        return ctxm.pearson_rho_nc_cdf(self, r, N, rho, cdf, method)


# 6.3.18 Non-central Pearson’s rho distribution: qtf and isf

    def pearson_rho_nc_qtf(self, q, N, rho, qtf=True, method='default'):
        '''Returns the Non-central Pearson’s rho distribution: qtf and isf'''
        return ctxm.pearson_rho_nc_qtf(self, q, N, rho, qtf, method)


# 6.3.19 Non-central Pearson's rho distribution: confidence limit for rho

    def pearson_rho_nc_cl(self, alpha, beta, N, cdfmethod='default'):
        '''Returns the Non-central Pearson’s rho distribution:
        confidence limit for rho'''
        return ctxm.pearson_rho_nc_cl(self, alpha, beta, N, cdfmethod)


# 6.3.20 Non-central Pearson’s rho: unbiased estimate of rho

    def pearson_rho_nc_unbiased_estimate(self, r, N):
        '''Returns the Non-central Pearson’s rho distribution:
        unbiased estimate of rho'''
        return ctxm.pearson_rho_nc_unbiased_estimate(self, r, N)


# 6.3.21 Non-central Fisher 𝐹 distribution: pdf

    def fisher_f_nc_pdf(self, x, m, n, lambda1, method='default'):
        '''Returns the Non-central Fisher 𝐹 distribution: pdf'''
        return ctxm.fisher_f_nc_pdf(self, x, m, n, lambda1, method)

    # Singly Noncentral F-distribution, pdf (Chou1985)
    def fdisnc_pdf(self, x, m, n, lambda1):
        '''Returns the Non-central Fisher 𝐹 distribution: pdf (Chou1985)'''
        return ctxm.fdisnc_pdf(self, x, m, n, lambda1)


# 6.3.22 Non-central Fisher 𝐹 distribution: cdf and sf

    def fisher_f_nc_cdf(self, x, m, n, lambda1, cdf=True, method='default'):
        '''Returns the Non-central Fisher 𝐹 distribution: cdf and sf'''
        return ctxm.fisher_f_nc_cdf(self, x, m, n, lambda1, cdf, method)

    # Singly Noncentral F-distribution, cdf (Chou1985)
    def fdisnc_cdf(self, x, m, n, lambda1):
        '''Returns the Singly Noncentral F-distribution, cdf (Chou1985)'''
        return ctxm.fdisnc_cdf(self, x, m, n, lambda1)

    # Singly Noncentral F-distribution, cdf2 (Chou1985)
    def fdisnc_cdf2(self, x, m, n, lambda1):
        '''Returns the Singly Noncentral F-distribution, cdf2 (Chou1985)'''
        return ctxm.fdisnc_cdf2(self, x, m, n, lambda1)

    # Singly Noncentral F-distribution, sf (Chou1985)
    def fdisnc_sf(self, x, m, n, lambda1):
        '''Returns the Singly Noncentral F-distribution, sf (Chou1985)'''
        return ctxm.fdisnc_sf(self, x, m, n, lambda1)


# 6.3.23 Non-central Fisher 𝐹 distribution: qtf and isf

    def fisher_f_nc_qtf(self, q, m, n, lambda1, qtf=True, method='default'):
        '''Returns the Non-central Fisher 𝐹 distribution: qtf and isf'''
        return ctxm.fisher_f_nc_qtf(self, q, m, n, lambda1, qtf, method)


# 6.3.24 Non-central Fisher 𝐹 distribution: confidence limit for 𝜆1

    def fisher_f_nc_cl(self, alpha, beta, m, n, cdfmethod='default'):
        '''Returns the Non-central Fisher 𝐹 distribution:
        confidence limit for 𝜆1'''
        return ctxm.fisher_f_nc_cl(self, alpha, beta, m, n, cdfmethod)


# 6.3.25 Non-central Beta distribution: pdf

    def beta_nc_pdf(self, x, a, b, lambda1, method='default'):
        '''Returns the Non-central Beta distribution: pdf'''
        return ctxm.beta_nc_pdf(self, x, a, b, lambda1, method)


# 6.3.26 Non-central Beta distribution: cdf and sf

    def beta_nc_cdf(self, x, a, b, lambda1, cdf=True, method='default'):
        '''Returns the Non-central Beta distribution: cdf and sf'''
        return ctxm.beta_nc_cdf(self, x, a, b, lambda1, cdf, method)


# 6.3.27 Non-central Beta distribution: qtf and isf

    def beta_nc_qtf(self, q, a, b, lambda1, cdf=True, method='default'):
        '''Returns the Non-central Beta distribution: qtf and isf'''
        return ctxm.beta_nc_qtf(self, q, a, b, lambda1, cdf, method)


# 6.3.28 Non-central Beta distribution: confidence limit for 𝜆1

    def beta_nc_cl(self, alpha, beta, a, b, cdfmethod='default'):
        '''Returns the Non-central Beta distribution: confidence limit for 𝜆1'''
        return ctxm.beta_nc_cl(self, alpha, beta, a, b, cdfmethod)


# 6.3.29 Fisher’s R2 distribution: pdf

    def fisher_r2_pdf(self, x, p, N, rho2, typeI=True, method='default'):
        '''Returns Fisher’s R2 distribution: pdf'''
        return ctxm.fisher_r2_pdf(self, x, p, N, rho2, typeI, method)

    # Singly Noncentral Fisher R2-distribution, pdf (Chou1985)
    def fisher_r2_pdf2_(self, x, p, N, rho2):
        '''Returns Fisher’s R2 distribution: pdf'''
        return ctxm.fisher_r2_pdf(self, x, p, N, rho2)


# 6.3.30 Fisher’s R2 distribution: cdf and sf

    def fisher_r2_cdf(self, x, p, N, rho2, cdf=True, method='default'):
        '''Returns Fisher’s R2 distribution: cdf and sf'''
        return ctxm.fisher_r2_cdf(self, x, p, N, rho2, cdf, method)


# 6.3.31 Fisher’s R2 distribution: qtf and isf

    def fisher_r2_qtf(self, q, p, N, rho2, qtf=True, typeI=True,
                      method='default'):
        '''Returns Fisher’s R2 distribution: qtf and isf'''
        return ctxm.fisher_r2_qtf(self, q, p, N, rho2, qtf, typeI, method)


# 6.3.32 Fisher’s R2 distribution: confidence limit for rho^2

    def fisher_r2_cl(self, alpha, beta, p, N, cdfmethod='default'):
        '''Returns Fisher’s R2 distribution: confidence limit for rho^2'''
        return ctxm.fisher_r2_cl(self, alpha, beta, p, N, cdfmethod)


# 6.3.33 Fisher’s R2: unbiased estimate of rho^2

    def fisher_r2_unbiased_estimate(self, R, p, N):
        '''Returns Fisher’s R2 distribution: confidence limit for rho^2'''
        return ctxm.fisher_r2_unbiased_estimate(self, R, p, N)


# 6.3.34 Doubly non-central Student t-distribution: pdf

    def student_t_nc2_pdf(self, x, n, delta, theta, method='default'):
        '''Returns the Doubly non-central Student t-distribution: pdf'''
        return ctxm.student_t_nc2_pdf(self, x, n, delta, theta, method)

    # Doubly Noncentral t-distribution, pdf (Witkovsky2013)
    def tdisnc2_pdf(self, x, n, delta, theta):
        '''Returns the Doubly non-central Student t-distribution:
        pdf (Witkovsky2013)'''
        return ctxm.tdisnc2_pdf(self, x, n, delta, theta)


# 6.3.35 Doubly non-central Student t-distribution: cdf and sf

    def student_t_nc2_cdf(self, x, n, delta, theta, cdf=True,
                          method='default'):
        '''Returns the Doubly non-central Student t-distribution: cdf and sf'''
        return ctxm.student_t_nc2_cdf(self, x, n, delta, theta, cdf, method)

    # Doubly Noncentral t-distribution, cdf (Witkovsky2013)
    def tdisnc2_cdf(self, x, n, delta, theta):
        '''Returns the Doubly non-central Student t-distribution:
        cdf (Witkovsky2013)'''
        return ctxm.tdisnc2_cdf(self, x, n, delta, theta)


# 6.3.36 Doubly noncentral Student t-distribution, qtf and isf

    def student_t_nc2_qtf(self, x, n, delta, theta, qtf=True,
                          method='default'):
        '''Returns the Doubly non-central Student t-distribution:
            qtf and isf'''
        return ctxm.student_t_nc2_qtf(self, x, n, delta, theta, qtf, method)


# 6.3.37 Doubly noncentral Student t-distribution,: confidence limit for delta

    def student_t_nc2_cl(self, alpha, beta, n, theta, cdfmethod='default'):
        '''Returns the Doubly non-central Student t-distribution:
        confidence limit for delta'''
        return ctxm.student_t_nc2_cl(self, alpha, beta, n, theta, cdfmethod)


# 6.3.38 Doubly non-central Fisher F-distribution: pdf

    def fisher_f_nc2_pdf(self, x, m, n, lambda1, lambda2, method='default'):
        '''Returns the Doubly non-central Fisher F-distribution: pdf'''
        return ctxm.fisher_f_nc2_pdf(self, x, m, n, lambda1, lambda2, method)

    # Doubly Noncentral F-distribution, pdf (Chou1985)
    def fdisnc2_pdf(self, x, m, n, lambda1, lambda2):
        '''Returns the Doubly non-central Fisher F-distribution:
        pdf (Chou1985)'''
        return ctxm.fdisnc2_pdf(self, x, m, n, lambda1, lambda2)


# 6.3.39 Doubly non-central Fisher F-distribution: cdf and sf

    def fisher_f_nc2_cdf(self, x, m, n, lambda1, lambda2, cdf=True,
                         method='default'):
        '''Returns the Doubly non-central Fisher F-distribution: cdf and sf'''
        return ctxm.fisher_f_nc2_cdf(self, x, m, n, lambda1, lambda2, cdf,
                                     method)

    # Doubly Noncentral F-distribution, cdf (Chou1985)
    def fdisnc2_cdf(self, x, m, n, lambda1, lambda2):
        '''Returns the Doubly non-central Fisher F-distribution:
        cdf (Chou1985)'''
        return ctxm.fdisnc2_cdf(self, x, m, n, lambda1, lambda2)





# %%%  6.4 Distributions related to multiple comparisons of means


# 6.4.1 Normal maximum distribution, equicorrelated case: pdf

    def nmax_corr_pdf(self, x, k, rho):
        '''Returns the Normal maximum distribution, equicorrelated case: pdf'''
        return ctxm.nmax_corr_pdf(self, x, k, rho)

# 6.4.2 Normal maximum distribution, equicorrelated case:: cdf and sf

    def nmax_corr_cdf(self, x, k, rho, cdf=True):
        '''Returns the Normal maximum distribution, equicorrelated case:
        cdf and sf'''
        return ctxm.nmax_corr_cdf(self, x, k, rho)

# 6.4.2a Normal maximum distribution, negative rho,
    # equicorrelated case:: cdf and sf

    def nmax_corr_negative_rho_cdf(self, x, k, rho, cdf=True):
        '''Returns the Normal maximum distribution, negative rho,
        equicorrelated case:: cdf and sf'''
        return ctxm.nmax_corr_negative_rho_cdf(self, x, k, rho)

# 6.4.3 Normal maximum distribution, negative rho,
    # equicorrelated case: qtf and isf

    def nmax_corr_qtf(self, q, k, rho, qtf=True):
        '''Returns the Normal maximum distribution, negative rho,
        equicorrelated case:: qtf and isf'''
        return ctxm.nmax_corr_qtf(self, q, k, rho, qtf=True)


# 6.4.4 Normal maximum modulus distribution, equicorrelated case: pdf

    def nmm_corr_pdf(self, x, k, rho):
        '''Returns the Normal maximum modulus distribution,
        equicorrelated case: pdf'''
        return ctxm.nmm_corr_pdf(self, x, k, rho)

# 6.4.5 Normal maximum modulus distribution, equicorrelated case: cdf and sf

    def nmm_corr_cdf(self, x, k, rho, cdf=True):
        '''Returns the Normal maximum modulus distribution,
        equicorrelated case: cdf and sf'''
        return ctxm.nmm_corr_cdf(self, x, k, rho)

# 6.4.5a Normal maximum modulus distribution, negative rho,
    # equicorrelated case: cdf and sf

    def nmm_corr_negative_rho_cdf(self, x, k, rho, cdf=True):
        '''Returns the Normal maximum modulus distribution, negative rho,
        equicorrelated case: cdf and sf'''
        return ctxm.nmm_corr_negative_rho_cdf(self, x, k, rho)

# 6.4.6 Normal maximum modulus distribution, equicorrelated case: qtf and isf

    def nmm_corr_qtf(self, q, k, rho, qtf=True):
        '''Returns the Normal maximum modulus distribution,
        equicorrelated case: qtf and isf'''
        return ctxm.nmm_corr_qtf(self, q, k, rho, qtf)


# 6.4.7 Normal range distribution: pdf

    def nrange_pdf(self, x, k):
        '''Returns the Normal range distribution: pdf'''
        return ctxm.nrange_pdf(self, x, k)

# 6.4.8 Normal range distribution: cdf and sf
    def nrange_cdf(self, x, k, cdf=True):
        '''Returns the Normal range distribution: cdf and sf'''
        return ctxm.nrange_cdf(self, x, k)

# 6.4.9 Normal range distribution: qtf and isf
    def nrange_qtf(self, q, k, qtf=True):
        '''Returns the Normal range distribution: qtf and isf'''
        return ctxm.nrange_qtf(self, q, k, qtf)


# 6.4.16 Studentized maximum distribution: pdf

    def smax_pdf(self, x, k, n):
        '''Returns the Studentized maximum distribution: pdf'''
        return ctxm.smax_pdf(self, x, k, n)


# 6.4.17 Studentized maximum distribution: cdf and sf

    def smax_cdf(self, x, k, n, cdf=True):
        '''Returns the Studentized maximum distribution: cdf and sf'''
        return ctxm.smax_cdf(self, x, k, n)


# 6.4.18 Studentized maximum distribution: qtf and isf

    def smax_qtf(self, q, k, n, qtf=True):
        '''Returns the Studentized maximum distribution: qtf and isf'''
        return ctxm.smax_qtf(self, q, k, n, qtf)


# 6.4.19 Studentized maximum modulus distribution: pdf

    def smm_pdf(self, x, k, n):
        '''Returns the Studentized maximum modulus distribution: pdf'''
        return ctxm.smm_pdf(self, x, k, n)


# 6.4.20 Studentized maximum modulus distribution: cdf and sf

    def smm_cdf(self, x, k, n, cdf=True):
        '''Returns the Studentized maximum modulus distribution: cdf and sf'''
        return ctxm.smm_cdf(self, x, k, n)


# 6.4.21 Studentized maximum modulus distribution: qtf and isf

    def smm_qtf(self, q, k, n, qtf=True):
        '''Returns the Studentized maximum modulus distribution: qtf and isf'''
        return ctxm.smm_qtf(self, q, k, n, qtf)


# 6.4.22 Dunnett's t-distribution, 1-sided: pdf

    def dunnett1_pdf(self, x, k, n, rho):
        '''Returns Dunnett's t-distribution, 1-sided: pdf'''
        return ctxm.dunnett1_pdf(self, x, k, n, rho)

# 6.4.23 Dunnett's t-distribution, 1-sided: cdf and sf

    def dunnett1_cdf(self, x, k, n, rho, cdf=True):
        '''Returns Dunnett's t-distribution, 1-sided: cdf and sf'''
        return ctxm.dunnett1_cdf(self, x, k, n, rho)

# 6.4.24 Dunnett's t-distribution, 1-sided: qtf and isf

    def dunnett1_qtf(self, q, k, n, rho, qtf=True):
        '''Returns Dunnett's t-distribution, 1-sided: qtf and isf'''
        return ctxm.dunnett1_qtf(self, q, k, n, rho, qtf)


# 6.4.25 Dunnett's t-distribution, 2-sided: pdf

    def dunnett2_pdf(self, x, k, n, rho):
        '''Returns Dunnett's t-distribution, 2-sided: pdf'''
        return ctxm.dunnett2_pdf(self, x, k, n, rho)

# 6.4.26 Dunnett's t-distribution, 2-sided: cdf and sf

    def dunnett2_cdf(self, x, k, n, rho, cdf=True):
        '''Returns Dunnett's t-distribution, 2-sided: cdf and sf'''
        return ctxm.dunnett2_cdf(self, x, k, n, rho)

# 6.4.27 Dunnett's t-distribution, 2-sided: qtf and isf

    def dunnett2_qtf(self, q, k, n, rho, qtf=True):
        '''Returns Dunnett's t-distribution, 2-sided: qtf and isf'''
        return ctxm.dunnett2_qtf(self, q, k, n, rho, qtf)


# 6.4.26 Nelson's h-distribution, 2-sided: cdf and sf

    def nelson2_cdf(self, x, k, n, rho, cdf=True):
        '''Returns Nelson's h-distribution, 2-sided: qtf and isf'''
        return ctxm.nelson2_cdf(self, x, k, n, rho)


# 6.4.26 Nair's t-distribution, 1-sided: cdf and sf

    def nair1_cdf(self, x, k, n, rho, cdf=True):
        '''Returns Nair's t-distribution, 1-sided: qtf and isf'''
        return ctxm.nair1_cdf(self, x, k, n, rho)


# 6.4.28 Studentized range distribution: pdf

    def srange_pdf(self, x, k, n):
        '''Returns the Studentized range distribution: pdf'''
        return ctxm.srange_pdf(self, x, k, n)

# 6.4.29 Studentized range distribution: cdf and sf

    def srange_cdf(self, x, k, n, cdf=True):
        '''Returns the Studentized range distribution: cdf and sf'''
        return ctxm.srange_cdf(self, x, k, n)


# 6.4.30 Studentized range distribution: qtf and isf

    def srange_qtf(self, q, k, n, qtf=True):
        '''Returns the Studentized range distribution: cdf and sf'''
        return ctxm.srange_qtf(self, q, k, n, qtf)


# %%%  6.5 Miscellaneous continuous distributions


# 6.5.1 Lévy alpha-stable distribution, pdf

    def levy_alphastable_pdf(self, a, b, n):
        '''Returns the Lévy alpha-stable distribution, pdf'''
        return ctxm.levy_alphastable_pdf(self, a, b, n)

# 6.5.2 Lévy alpha-stable distribution, cdf and sf

    def levy_alphastable_cdf(self, a, b, n):
        '''Returns the Lévy alpha-stable distribution, cdf and sf'''
        return ctxm.levy_alphastable_pdf(self, a, b, n)

# 6.5.3 Lévy alpha-stable distribution, qtf and isf

    def levy_alphastable_qtf(self, a, b, n):
        '''Returns the Lévy alpha-stable distribution, qtf and isf'''
        return ctxm.levy_alphastable_pdf(self, a, b, n)


# 6.5.4 Landau distribution, pdf

    def landau_pdf(self, a, b, n):
        '''Returns the Landau distribution, pdf'''
        return ctxm.landau_pdf(self, a, b, n)

# 6.5.5 Landau distribution, cdf and sf

    def landau_cdf(self, a, b, n):
        '''Returns the Landau distribution, cdf and sf'''
        return ctxm.landau_cdf(self, a, b, n)

# 6.5.6 Landau distribution, qtf and isf

    def landau_qtf(self, a, b, n):
        '''Returns the Landau distribution, qtf and isf'''
        return ctxm.landau_qtf(self, a, b, n)


# 6.5.7 Pearson Type IV distribution, pdf

    def pearson_type4_pdf(self, a, b, n):
        '''Returns the Pearson Type IV distribution, pdf'''
        return ctxm.pearson_type4_pdf(self, a, b, n)

# 6.5.8 Pearson Type IV distribution, cdf and sf

    def pearson_type4_cdf(self, a, b, n):
        '''Returns the Pearson Type IV distribution, cdf and sf'''
        return ctxm.pearson_type4_cdf(self, a, b, n)

# 6.5.9 Pearson Type IV distribution, qtf and isf

    def pearson_type4_qtf(self, a, b, n):
        '''Returns the Pearson Type IV distribution, qtf and isf'''
        return ctxm.pearson_type4_qtf(self, a, b, n)


# 6.5.10 Meixner distribution, pdf

    def meixner_pdf(self, a, b, n):
        '''Returns the Meixner distribution, pdf'''
        return ctxm.meixner_pdf(self, a, b, n)

# 6.5.11 Meixner distribution, cdf and sf

    def meixner_cdf(self, a, b, n):
        '''Returns the Meixner distribution, cdf and sf'''
        return ctxm.meixner_cdf(self, a, b, n)

# 6.5.12 Meixner distribution, qtf and isf

    def meixner_qtf(self, a, b, n):
        '''Returns the Meixner distribution, qtf and isf'''
        return ctxm.meixner_qtf(self, a, b, n)


# 6.5.13 Voigt Profile distribution, pdf

    def voigt_profile_pdf(self, a, b, n):
        '''Returns the Voigt Profile distribution, pdf'''
        return ctxm.voigt_profile_pdf(self, a, b, n)

# 6.5.14 Voigt Profile distribution, cdf and sf

    def voigt_profile_cdf(self, a, b, n):
        '''Returns the Voigt Profile distribution, cdf and sf'''
        return ctxm.voigt_profile_cdf(self, a, b, n)

# 6.5.15 Voigt Profile distribution, qtf and isf

    def voigt_profile_qtf(self, a, b, n):
        '''Returns the Voigt Profile distribution, qtf and isf'''
        return ctxm.voigt_profile_qtf(self, a, b, n)


# 6.5.16 Wrapped Cauchy distribution, pdf

    def wrapped_cauchy_pdf(self, a, b, n):
        '''Returns the Wrapped Cauchy distribution, pdf'''
        return ctxm.wrapped_cauchy_pdf(self, a, b, n)

# 6.5.17 Wrapped Cauchy distribution, cdf and sf

    def wrapped_cauchy_cdf(self, a, b, n):
        '''Returns the Wrapped Cauchy distribution, cdf and sf'''
        return ctxm.wrapped_cauchy_cdf(self, a, b, n)

# 6.5.18 Wrapped Cauchy distribution, qtf and isf

    def wrapped_cauchy_qtf(self, a, b, n):
        '''Returns the Wrapped Cauchy distribution, qtf and isf'''
        return ctxm.wrapped_cauchy_qtf(self, a, b, n)


# 6.5.19 Wrapped normal distribution, pdf

    def wrapped_normal_pdf(self, a, b, n):
        '''Returns the Wrapped normal distribution, pdf'''
        return ctxm.wrapped_normal_pdf(self, a, b, n)

# 6.5.20 Wrapped normal distribution, cdf and sf

    def wrapped_normal_cdf(self, a, b, n):
        '''Returns the Wrapped normal distribution, cdf and sf'''
        return ctxm.wrapped_normal_cdf(self, a, b, n)

# 6.5.21 Wrapped normal distribution, qtf and isf

    def wrapped_normal_qtf(self, a, b, n):
        '''Returns the Wrapped normal distribution, qtf and isf'''
        return ctxm.wrapped_normal_qtf(self, a, b, n)


# 6.5.22 von Mises distribution, pdf

    def von_mises_pdf(self, a, b, n):
        '''Returns the Wrapped normal distribution, pdf'''
        return ctxm.von_mises_pdf(self, a, b, n)

# 6.5.23 von Mises distribution, cdf and sf

    def von_mises_cdf(self, a, b, n):
        '''Returns the Wrapped normal distribution, cdf and sf'''
        return ctxm.von_mises_cdf(self, a, b, n)

# 6.5.24 von Mises distribution, qtf and isf

    def von_mises_qtf(self, a, b, n):
        '''Returns the Wrapped normal distribution, qtf and isf'''
        return ctxm.von_mises_qtf(self, a, b, n)


# 6.5.25 Generalized inverse Gaussian distribution, pdf

    def gen_inv_gaussian_pdf(self, a, b, n):
        '''Returns the Generalized inverse Gaussian distribution, pdf'''
        return ctxm.gen_inv_gaussian_pdf(self, a, b, n)

# 6.5.26 Generalized inverse Gaussian distribution, cdf and sf

    def gen_inv_gaussian_cdf(self, a, b, n):
        '''Returns the Generalized inverse Gaussian distribution, cdf and sf'''
        return ctxm.gen_inv_gaussian_cdf(self, a, b, n)

# 6.5.27 Generalized inverse Gaussian distribution, qtf and isf

    def gen_inv_gaussian_qtf(self, a, b, n):
        '''Returns the Generalized inverse Gaussian distribution,
        qtf and isf'''
        return ctxm.gen_inv_gaussian_qtf(self, a, b, n)


# 6.5.28 Harmonic distribution, pdf

    def harmonic_pdf(self, a, b, n):
        '''Returns the Harmonic distribution, pdf'''
        return ctxm.harmonic_pdf(self, a, b, n)

# 6.5.29 Harmonic distribution, cdf and sf

    def harmonic_cdf(self, a, b, n):
        '''Returns the Harmonic distribution, cdf and sf'''
        return ctxm.harmonic_cdf(self, a, b, n)

# 6.5.30 Harmonic distribution, qtf and isf

    def harmonic_qtf(self, a, b, n):
        '''Returns the Harmonic distribution, qtf and isf'''
        return ctxm.harmonic_qtf(self, a, b, n)


# 6.5.31 Halphen A distribution, pdf

    def halphen_a_pdf(self, a, b, n):
        '''Returns the Halphen A distribution, pdf'''
        return ctxm.halphen_a_pdf(self, a, b, n)

# 6.5.32 Halphen A distribution, cdf and sf

    def halphen_a_cdf(self, a, b, n):
        '''Returns the Halphen A distribution, cdf and sf'''
        return ctxm.halphen_a_cdf(self, a, b, n)

# 6.5.33 Halphen A distribution, qtf and isf

    def halphen_a_qtf(self, a, b, n):
        '''Returns the Halphen A distribution, qtf and isf'''
        return ctxm.halphen_a_qtf(self, a, b, n)


# 6.5.34 Halphen B distribution, pdf

    def halphen_b_pdf(self, a, b, n):
        '''Returns the Halphen B distribution, pdf'''
        return ctxm.halphen_b_qtf(self, a, b, n)

# 6.5.35 Halphen B distribution, cdf and sf

    def halphen_b_cdf(self, a, b, n):
        '''Returns the Halphen B distribution, cdf and sf'''
        return ctxm.halphen_b_qtf(self, a, b, n)

# 6.5.36 Halphen B distribution, qtf and isf

    def halphen_b_qtf(self, a, b, n):
        '''Returns the Halphen B distribution, qtf and isf'''
        return ctxm.halphen_b_qtf(self, a, b, n)


# 6.5.37 Halphen IB distribution, pdf

    def halphen_ib_pdf(self, a, b, n):
        '''Returns the Halphen IB distribution, pdf'''
        return ctxm.halphen_ib_qtf(self, a, b, n)

# 6.5.38 Halphen IB distribution, cdf and sf

    def halphen_ib_cdf(self, a, b, n):
        '''Returns the Halphen IB distribution, cdf and sf'''
        return ctxm.halphen_ib_qtf(self, a, b, n)

# 6.5.39 Halphen IB distribution, qtf and isf

    def halphen_ib_qtf(self, a, b, n):
        '''Returns the Halphen IB distribution, qtf and isf'''
        return ctxm.halphen_ib_qtf(self, a, b, n)


# 6.5.40 Generalized hyperbolic distribution, pdf

    def gen_hyperbolic_pdf(self, a, b, n):
        '''Returns the Generalized hyperbolic distribution, pdf'''
        return ctxm.gen_hyperbolic_pdf(self, a, b, n)

# 6.5.41 Generalized hyperbolic distribution, cdf and sf

    def gen_hyperbolic_cdf(self, a, b, n):
        '''Returns the Generalized hyperbolic distribution, cdf and sf'''
        return ctxm.gen_hyperbolic_cdf(self, a, b, n)

# 6.5.42 Generalized hyperbolic distribution, qtf and isf

    def gen_hyperbolic_qtf(self, a, b, n):
        '''Returns the Generalized hyperbolic distribution, qtf and isf'''
        return ctxm.gen_hyperbolic_qtf(self, a, b, n)


# 6.5.43 Hyperbolic distribution, pdf

    def hyperbolic_pdf(self, a, b, n):
        '''Returns the Hyperbolic distribution, pdf'''
        return ctxm.hyperbolic_pdf(self, a, b, n)

# 6.5.44 Hyperbolic distribution, cdf and sf

    def hyperbolic_cdf(self, a, b, n):
        '''Returns the Hyperbolic distribution, cdf and sf'''
        return ctxm.hyperbolic_cdf(self, a, b, n)

# 6.5.45 Hyperbolic distribution, qtf and isf

    def hyperbolic_qtf(self, a, b, n):
        '''Returns the Hyperbolic distribution, qtf and isf'''
        return ctxm.hyperbolic_qtf(self, a, b, n)


# 6.5.46 Variance-gamma distribution, pdf

    def variance_gamma_pdf(self, a, b, n):
        '''Returns the Variance-gamma distribution, pdf'''
        return ctxm.variance_gamma_pdf(self, a, b, n)

# 6.5.47 Variance-gamma distribution, cdf and sf

    def variance_gamma_cdf(self, a, b, n):
        '''Returns the Variance-gamma distribution, cdf and sf'''
        return ctxm.variance_gamma_cdf(self, a, b, n)

# 6.5.48 Variance-gamma distribution, qtf and isf

    def variance_gamma_qtf(self, a, b, n):
        '''Returns the Variance-gamma distribution, qtf and isf'''
        return ctxm.variance_gamma_qtf(self, a, b, n)


# %% 107 Discrete distribution functions

# %%%  7.1 Elementary discrete (lattice) distribution functions


# 7.1.1 Geometric distribution, pmf

    def geometric_pmf(self, k, p):
        '''Returns the Geometric distribution, pmf'''
        return ctxm.geometric_pmf(self, k, p)

# 7.1.2 Geometric distribution, cdf and sf

    def geometric_cdf(self, k, p, cdf=True):
        '''Returns the Geometric distribution, cdf and sf'''
        return ctxm.geometric_cdf(self, k, p, cdf)

# 7.1.3 Geometric distribution, qtf and isf

    def geometric_qtf(self, prob, p, qtf=True):
        '''Returns the Geometric distribution, qtf and isf'''
        return ctxm.geometric_qtf(self, prob, p, qtf)


# 7.1.4 Log-series distribution, pmf

    def logseries_pmf(self, k, lambda1):
        '''Returns the Log-series distribution, pmf'''
        return ctxm.logseries_pmf(self, k, lambda1)

# 7.1.5 Log-series distribution, cdf and sf

    def logseries_cdf(self, k, lambda1, cdf=True, **kwargs):
        '''Returns the Log-series distribution, cdf and sf'''
        return ctxm.logseries_cdf(self, k, lambda1, cdf)

# 7.1.6 Log-series distribution, qtf and isf

    def logseries_qtf(self, prob, lambda1, qtf=True, **kwargs):
        '''Returns the Log-series distribution, qtf and isf'''
        return ctxm.logseries_qtf(self, prob, lambda1, qtf)


# 7.1.7 Poisson distribution, pmf

    def poisson_pmf(self, k, lambda1):
        '''Returns the Poisson distribution, pmf'''
        return ctxm.poisson_pmf(self, k, lambda1)

# 7.1.8 Poisson distribution, cdf and sf

    def poisson_cdf(self, k, lambda1, cdf=True, **kwargs):
        '''Returns the Poisson distribution, cdf and sf'''
        return ctxm.poisson_cdf(self, k, lambda1, cdf, **kwargs)

# 7.1.9 Poisson distribution, qtf and isf

    def poisson_qtf(self, prob, lambda1, qtf=True, **kwargs):
        '''Returns the Poisson distribution, qtf and isf'''
        return ctxm.poisson_qtf(self, prob, lambda1, qtf, **kwargs)


# 7.1.10 Skellam distribution, pmf

    def skellam_pmf(self, k, lambda1):
        '''Returns the Skellam distribution, pmf'''
        return ctxm.skellam_pmf(self, k, lambda1)

# 7.1.11 Skellam distribution, cdf and sf

    def skellam_cdf(self, k, lambda1, cdf=True, **kwargs):
        '''Returns the Skellam distribution, cdf and sf'''
        return ctxm.skellam_cdf(self, k, lambda1, cdf)

# 7.1.12 Skellam distribution, qtf and isf

    def skellam_qtf(self, prob, lambda1, qtf=True, **kwargs):
        '''Returns the Skellam distribution, qtf and isf'''
        return ctxm.skellam_qtf(self, prob, lambda1, qtf)


# 7.1.13 Binomial distribution, pmf

    def binomial_pmf(self, k, n, p):
        '''Returns the Binomial distribution, pmf'''
        return ctxm.binomial_pmf(self, k, n, p)

# 7.1.14 Binomial distribution, cdf and sf

    def binomial_cdf(self, k, n, p, cdf=True, **kwargs):
        '''Returns the Binomial distribution, cdf and sf'''
        return ctxm.binomial_cdf(self, k, n, p, cdf, **kwargs)

# 7.1.15 Binomial distribution, qtf and isf

    def binomial_qtf(self, prob, n, p, qtf=True, **kwargs):
        '''Returns the Binomial distribution, qtf and isf'''
        return ctxm.binomial_qtf(self, prob, n, p, qtf, **kwargs)


# 7.1.16 Negative binomial (gamma-Poisson) distribution, pmf

    def negbinom_pmf(self, k, r, p):
        '''Returns the Negative binomial (gamma-Poisson) distribution, pmf'''
        return ctxm.negbinom_pmf(self, k, r, p)

# 7.1.17 Negative binomial (gamma-Poisson) distribution, cdf and sf

    def negbinom_cdf(self, k, r, p, cdf=True, **kwargs):
        '''Returns the Negative binomial (gamma-Poisson) distribution,
        cdf and sf'''
        return ctxm.negbinom_cdf(self, k, r, p, cdf, **kwargs)

# 7.1.18 Negative binomial (gamma-Poisson) distribution, qtf and isf

    def negbinom_qtf(self, prob, r, p, qtf=True, **kwargs):
        '''Returns the Negative binomial (gamma-Poisson) distribution,
        qtf and isf'''
        return ctxm.negbinom_qtf(self, prob, r, p, qtf, **kwargs)


# 7.1.19 Delaporte distribution, pmf

    def delaporte_pmf(self, x, r, n, NN):
        '''Returns the Delaporte distribution, pmf'''
        return ctxm.delaporte_pmf(self, x, r, n, NN)

# 7.1.20 Delaporte distribution, cdf and sf

    def delaporte_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Delaporte distribution, cdf and sf'''
        return ctxm.delaporte_cdf(self, x, r, n, NN, cdf)

# 7.1.21 Delaporte distribution, qtf and isf

    def delaporte_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Delaporte distribution, cdf and sf'''
        return ctxm.delaporte_qtf(self, prob, r, n, NN, qtf)


# 7.1.22 Beta-Poisson distribution (Quinkert), pmf

    def betapoisson_pmf(self, x, r, n, NN):
        '''Returns the Beta-Poisson distribution (Quinkert), pmf'''
        return ctxm.betapoisson_pmf(self, x, r, n, NN)

# 7.1.23 Beta-Poisson distribution (Quinkert), cdf and sf

    def betapoisson_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Beta-Poisson distribution (Quinkert), cdf and sf'''
        return ctxm.betapoisson_cdf(self, x, r, n, NN, cdf)

# 7.1.24 Beta-Poisson distribution (Quinkert), qtf and isf

    def betapoisson_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Beta-Poisson distribution (Quinkert), qtf and isf'''
        return ctxm.betapoisson_qtf(self, prob, r, n, NN, qtf)


# 7.1.25 Beta-binomial distribution, pmf

    def betabinom_pmf(self, x, r, n, NN):
        '''Returns the Beta-binomial distribution, pmf'''
        return ctxm.betabinom_pmf(self, x, r, n, NN)

# 7.1.26 Beta-binomial distribution, cdf and sf

    def betabinom_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Beta-binomial distribution, cdf and sf'''
        return ctxm.betabinom_cdf(self, x, r, n, NN, cdf)

# 7.1.27 Beta-binomial distribution, qtf and isf

    def betabinom_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Beta-binomial distribution, qtf and isf'''
        return ctxm.betabinom_qtf(self, prob, r, n, NN, qtf)


# 7.1.28 Beta-negative binomial distribution (Waring), pmf

    def beta_negbinom_pmf(self, x, r, n, NN):
        '''Returns the Beta-negative binomial distribution (Waring), pmf'''
        return ctxm.beta_negbinom_pmf(self, x, r, n, NN)

# 7.1.29 Beta-negative binomial distribution (Waring), cdf and sf

    def beta_negbinom_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Beta-negative binomial distribution (Waring),
        cdf and sf'''
        return ctxm.beta_negbinom_cdf(self, x, r, n, NN, cdf)

# 7.1.30 Beta-negative binomial distribution (Waring), qtf and isf

    def beta_negbinom_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Beta-negative binomial distribution (Waring),
        qtf and isf'''
        return ctxm.beta_negbinom_qtf(self, prob, r, n, NN, qtf)


# 7.1.31 Classical hypergeometric distribution, pmf

    def hypergeo_pmf(self, k, K, n, N):
        '''Returns the Classical hypergeometric distribution, pmf'''
        return ctxm.hypergeo_pmf(self, k, K, n, N)

# 7.1.32 Classical hypergeometric distribution, cdf and sf

    def hypergeo_cdf(self, k, K, n, N, cdf=True):
        '''Returns the Classical hypergeometric distribution, cdf and sf'''
        return ctxm.hypergeo_cdf(self, k, K, n, N, cdf)

# 7.1.33 Classical hypergeometric distribution, qtf and isf

    def hypergeo_qtf(self, prob, K, n, N, qtf=True):
        '''Returns the Classical hypergeometric distribution, qtf and isf'''
        return ctxm.hypergeo_qtf(self, prob, K, n, N, qtf)


# 7.1.34 Negative hypergeometric distribution, pmf

    def neghypergeo_pmf(self, x, r, n, NN):
        '''Returns the Negative hypergeometric distribution, pmf'''
        return ctxm.neghypergeo_pmf(self, x, r, n, NN)

# 7.1.35 Negative hypergeometric distribution, cdf and sf

    def neghypergeo_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Negative hypergeometric distribution, cdf and sf'''
        return ctxm.neghypergeo_cdf(self, x, r, n, NN, cdf)

# 7.1.36 Negative hypergeometric distribution, qtf and isf

    def neghypergeo_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Negative hypergeometric distribution, qtf and isf'''
        return ctxm.neghypergeo_qtf(self, prob, r, n, NN, qtf)


# 7.1.37 Pólya-Eggenberger distribution, pmf

    def polya_pmf(self, x, r, n, NN):
        '''Returns the Pólya-Eggenberger distribution, pmf'''
        return ctxm.polya_pmf(self, x, r, n, NN)

# 7.1.38 Pólya-Eggenberger distribution, cdf and sf

    def polya_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Pólya-Eggenberger distribution, cdf and sf'''
        return ctxm.polya_cdf(self, x, r, n, NN, cdf)

# 7.1.39 Pólya-Eggenberger distribution, qtf and isf

    def polya_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Pólya-Eggenberger distribution, qtf and isf'''
        return ctxm.polya_qtf(self, prob, r, n, NN, qtf)


# 7.1.40 General hypergeometric distribution, pmf

    def genhypergeo_pmf(self, x, r, n, NN):
        '''Returns the General hypergeometric distribution, pmf'''
        return ctxm.genhypergeo_pmf(self, x, r, n, NN)

# 7.1.41 General hypergeometric distribution, cdf and sf

    def genhypergeo_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the General hypergeometric distribution, cdf and sf'''
        return ctxm.genhypergeo_cdf(self, x, r, n, NN, cdf)

# 7.1.42 General hypergeometric distribution, qtf and isf

    def genhypergeo_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the General hypergeometric distribution, qtf and isf'''
        return ctxm.genhypergeo_qtf(self, prob, r, n, NN, qtf)


# 7.1.43 Noncentral hypergeometric distribution (Fisher alternatives), pmf

    def hypergeo_nc_pmf(self, x, r, n, NN):
        '''Returns the Noncentral hypergeometric distribution
        (Fisher alternatives), pmf'''
        return ctxm.hypergeo_nc_pmf(self, x, r, n, NN)

# 7.1.44 Noncentral hypergeometric distribution (Fisher alternatives),
    # cdf and sf

    def hypergeo_nc_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Noncentral hypergeometric distribution
        (Fisher alternatives), cdf and sf'''
        return ctxm.hypergeo_nc_cdf(self, x, r, n, NN, cdf)

# 7.1.45 Noncentral hypergeometric distribution (Fisher alternatives),
    # qtf and isf

    def hypergeo_nc_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Noncentral hypergeometric distribution
        (Fisher alternatives), qtf and isf'''
        return ctxm.hypergeo_nc_qtf(self, prob, r, n, NN, qtf)


# 7.1.46 Zeta distribution, pmf

    def zeta_pmf(self, k, p):
        '''Returns the Zeta distribution, pmf'''
        return ctxm.zeta_pmf(self, k, p)

# 7.1.47 Zeta distribution, cdf and sf

    def zeta_cdf(self,  k, p, cdf=True):
        '''Returns the Zeta distribution, cdf and sf'''
        return ctxm.zeta_cdf(self,  k, p, cdf)

# 7.1.48 Zeta distribution, qtf and isf

    def zeta_qtf(self, prob, p, qtf=True):
        '''Returns the Zeta distribution, qtf and isf'''
        return ctxm.zeta_qtf(self, prob, p, qtf)


# %%%  7.2 Discrete (lattice) distribution functions related to (stratified)
    # rank tests


# 7.2.1 Wilcoxon 𝑇 distribution, pmf

    def wilcoxon_pmf(self, x, N):
        '''Returns the Wilcoxon 𝑇 distribution, pmf'''
        return ctxm.wilcoxon_pmf(self, x, N)

# 7.2.2 Wilcoxon 𝑇 distribution, cdf and sf

    def wilcoxon_cdf(self, x, N, cdf=True):
        '''Returns the Wilcoxon 𝑇 distribution, cdf and sf'''
        return ctxm.wilcoxon_cdf(self, x, N, cdf)

# 7.2.3 Wilcoxon 𝑇 distribution, qtf and isf

    def wilcoxon_qtf(self, prob, N, qtf=True):
        '''Returns the Wilcoxon 𝑇 distribution, qtf and isf'''
        return ctxm.wilcoxon_qtf(self, prob, N, qtf)


# 7.2.4 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, pmf

    def wilcoxon_nc_bennett_pmf(self, x, r, n, NN):
        '''Returns the Noncentral Wilcoxon 𝑇 distribution,
        Bennett alternatives, pmf'''
        return ctxm.wilcoxon_nc_bennett_pmf(self, x, r, n, NN)

# 7.2.5 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, cdf and sf

    def wilcoxon_nc_bennett_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Noncentral Wilcoxon 𝑇 distribution,
        Bennett alternatives, cdf and sf'''
        return ctxm.wilcoxon_nc_bennett_cdf(self, x, r, n, NN, cdf)

# 7.2.6 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, qtf and isf

    def wilcoxon_nc_bennett_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Noncentral Wilcoxon 𝑇 distribution,
        Bennett alternatives, qtf and isf'''
        return ctxm.wilcoxon_nc_bennett_qtf(self, prob, r, n, NN, qtf)


# 7.2.7 Mann-Whitney 𝑈 distribution, pmf

    def mannwhitney_pmf(self, x, r, n, NN):
        '''Returns the Mann-Whitney 𝑈 distribution, pmf'''
        return ctxm.mannwhitney_pmf(self, x, r, n, NN)

# 7.2.8 Mann-Whitney 𝑈 distribution, cdf and sf

    def mannwhitney_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Mann-Whitney 𝑈 distribution, cdf and sf'''
        return ctxm.mannwhitney_cdf(self, x, r, n, NN, cdf)

# 7.2.9 Mann-Whitney 𝑈 distribution, qtf and isf

    def mannwhitney_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Mann-Whitney 𝑈 distribution, qtf and isf'''
        return ctxm.mannwhitney_qtf(self, prob, r, n, NN, qtf)


# 7.2.10 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, pmf

    def mannwhitney_nc_lehmann_pmf(self, x, r, n, NN):
        '''Returns the Noncentral Mann-Whitney 𝑈 distribution,
        Lehmann alternatives, pmf'''
        return ctxm.mannwhitney_nc_lehmann_pmf(self, x, r, n, NN)

# 7.2.11 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives,
    # cdf and sf

    def mannwhitney_nc_lehmann_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Noncentral Mann-Whitney 𝑈 distribution,
        Lehmann alternatives, cdf and sf'''
        return ctxm.mannwhitney_nc_lehmann_cdf(self, x, r, n, NN, cdf)

# 7.2.12 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives,
    # qtf and isf

    def mannwhitney_nc_lehmann_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Noncentral Mann-Whitney 𝑈 distribution,
        Lehmann alternatives, qtf and isf'''
        return ctxm.mannwhitney_nc_lehmann_qtf(self, prob, r, n, NN, qtf)


# 7.2.13 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, pmf

    def mannwhitney_nc_milton_pmf(self, x, r, n, NN):
        '''Returns the Noncentral Mann-Whitney 𝑈 distribution,
        Milton alternatives, pmf'''
        return ctxm.mannwhitney_nc_milton_pmf(self, x, r, n, NN)

# 7.2.14 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives,
    # cdf and sf

    def mannwhitney_nc_milton_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Noncentral Mann-Whitney 𝑈 distribution,
        Milton alternatives, cdf and sf'''
        return ctxm.mannwhitney_nc_milton_cdf(self, x, r, n, NN, cdf)

# 7.2.15 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives,
    # qtf and isf

    def mannwhitney_nc_milton_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Noncentral Mann-Whitney 𝑈 distribution,
        Milton alternatives, qtf and isf'''
        return ctxm.mannwhitney_nc_milton_qtf(self, prob, r, n, NN, qtf)


# 7.2.16 Kendall’s 𝑆 (or 𝜏 ) distribution, pmf

    def kendall_tau_pmf(self, x, r, n, NN):
        '''Returns the Kendall’s 𝑆 (or 𝜏 ) distribution, pmf'''
        return ctxm.kendall_tau_pmf(self, x, r, n, NN)

# 7.2.17 Kendall’s 𝑆 (or 𝜏 ) distribution, cdf and sf

    def kendall_tau_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Kendall’s 𝑆 (or 𝜏 ) distribution, cdf and sf'''
        return ctxm.kendall_tau_cdf(self, x, r, n, NN, cdf)

# 7.2.18 Kendall’s 𝑆 (or 𝜏 ) distribution, qtf and isf

    def kendall_tau_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Kendall’s 𝑆 (or 𝜏 ) distribution, qtf and isf'''
        return ctxm.kendall_tau_qtf(self, prob, r, n, NN, qtf)


# 7.2.19 Jonckheere-Terpsta 𝑆 distribution, pmf

    def jterpsta_s_pmf(self, x, r, n, NN):
        '''Returns the Jonckheere-Terpsta 𝑆 distribution, pmf'''
        return ctxm.jterpsta_s_pmf(self, x, r, n, NN)

# 7.2.20 Jonckheere-Terpsta 𝑆 distribution, cdf and sf

    def jterpsta_s_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Jonckheere-Terpsta 𝑆 distribution, cdf and sf'''
        return ctxm.jterpsta_s_cdf(self, x, r, n, NN, cdf)

# 7.2.21 Jonckheere-Terpsta 𝑆 distribution, qtf and isf

    def jterpsta_s_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Jonckheere-Terpsta 𝑆 distribution, qtf and isf'''
        return ctxm.jterpsta_s_qtf(self, prob, r, n, NN, qtf)


# 7.2.22 Generalized Page 𝐿 distribution, pmf

    def page_l_pmf(self, x, r, n, NN):
        '''Returns the Generalized Page 𝐿 distribution, pmf'''
        return ctxm.page_l_pmf(self, x, r, n, NN)

# 7.2.23 Generalized Page 𝐿 distribution, cdf and sf

    def page_l_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Generalized Page 𝐿 distribution, cdf and sf'''
        return ctxm.page_l_cdf(self, x, r, n, NN, cdf)

# 7.2.24 Generalized Page 𝐿 distribution, qtf and isf

    def page_l_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Generalized Page 𝐿 distribution, qtf and isf'''
        return ctxm.page_l_qtf(self, prob, r, n, NN, qtf)


# 7.2.25 Noncentral generalized Page 𝐿 distribution, Milton alternatives, pmf

    def page_l_nc_milton_pmf(self, x, r, n, NN):
        '''Returns the Noncentral generalized Page 𝐿 distribution,
        Milton alternatives, pmf'''
        return ctxm.page_l_nc_milton_pmf(self, x, r, n, NN)

# 7.2.26 Noncentral generalized Page 𝐿 distribution, Milton alternatives,
    # cdf and sf

    def page_l_nc_milton_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Noncentral generalized Page 𝐿 distribution,
        Milton alternatives, cdf and sf'''
        return ctxm.page_l_nc_milton_cdf(self, x, r, n, NN, cdf)

# 7.2.27 Noncentral generalized Page 𝐿 distribution, Milton alternatives,
    # qtf and isf

    def page_l_nc_milton_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Noncentral generalized Page 𝐿 distribution,
        Milton alternatives, qtf and isf'''
        return ctxm.page_l_nc_milton_qtf(self, prob, r, n, NN, qtf)


# %%%  7.3 Discrete (non-lattice) distribution functions related to rank tests

# 7.3.1 Cochran-Friedman-Quade distribution, pmf

    def friedman_pmf(self, x, r, n, NN):
        '''Returns the Cochran-Friedman-Quade distribution, pmf'''
        return ctxm.friedman_pmf(self, x, r, n, NN)

# 7.3.2 Cochran-Friedman-Quade distribution, cdf and sf

    def friedman_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Cochran-Friedman-Quade distribution, cdf and sf'''
        return ctxm.friedman_cdf(self, x, r, n, NN, cdf)

# 7.3.3 Cochran-Friedman-Quade distribution, qtf and isf

    def friedman_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Cochran-Friedman-Quade distribution, qtf and isf'''
        return ctxm.friedman_qtf(self, prob, r, n, NN, qtf)


# 7.3.4 Kruskal-Wallis distribution, pmf

    def kruskal_wallis_pmf(self, x, r, n, NN):
        '''Returns the Kruskal-Wallis distribution, pmf'''

        return ctxm.kruskal_wallis_pmf(self, x, r, n, NN)

# 7.3.5 Kruskal-Wallis distribution, cdf and sf

    def kruskal_wallis_cdf(self, x, r, n, NN, cdf=True):
        '''Returns the Kruskal-Wallis distribution, cdf and sf'''
        return ctxm.kruskal_wallis_cdf(self, x, r, n, NN, cdf)

# 7.3.6 Kruskal-Wallis distribution, qtf and isf

    def kruskal_wallis_qtf(self, prob, r, n, NN, qtf=True):
        '''Returns the Kruskal-Wallis distribution, qtf and isf'''
        return ctxm.kruskal_wallis_qtf(self, prob, r, n, NN, qtf)


# %% 108 Series and integrals


# %%% 8.1 Finite series algorithms for selected distributions


# 8.1.1 Central 𝜒2 distribution, cdf (integer degrees of freedom)

    def chi2_cohen_cdf(self, x, nu, cdf=True):
        '''Returns the Central 𝜒2 distribution, cdf
        (integer degrees of freedom)'''
        if cdf:
            return ctxm.chi2_cohen_cdf(self, x, nu)
        else:
            return 1-ctxm.chi2_cohen_cdf(self, x, nu)


# 8.1.2 Central Student 𝑡 distribution, cdf (integer degrees of freedom)

    def student_t_owen_cdf(self, x, nu, cdf=True):
        '''Returns the Central Student 𝑡 distribution, cdf
        (integer degrees of freedom)'''
        if cdf:
            return ctxm.student_t_owen_cdf(self, x, nu)
        else:
            return 1-ctxm.student_t_owen_cdf(self, x, nu)


# 8.1.3 Central Fisher 𝐹 distribution, cdf (integer degrees of freedom)

    def fisher_f_seber_cdf(self, x, m, n, cdf=True):
        '''Returns the Central Fisher 𝐹 distribution, cdf
        (integer degrees of freedom)'''
        if cdf:
            return ctxm.fisher_f_seber_cdf(self, x, m, n)
        else:
            return 1-ctxm.fisher_f_seber_cdf(self, x, m, n)


# 8.1.4 Central Beta distribution, cdf (2𝑎 an integer, 2𝑏 an integer)

    def beta_seber_cdf(self, x, a, b, cdf=True):
        '''Returns the Central Beta distribution, cdf
        (2𝑎 an integer, 2𝑏 an integer)'''
        if cdf:
            return ctxm.beta_seber_cdf(self, x, a, b)
        else:
            return 1-ctxm.beta_seber_cdf(self, x, a, b)


# 8.1.5 Noncentral 𝜒2 distribution, cdf (integer degrees of freedom)

    def chi2_nc_cohen_cdf(self, x, nu, lambda1, cdf=True):
        '''Returns the Noncentral 𝜒2 distribution, cdf
        (integer degrees of freedom)'''
        if cdf:
            return ctxm.chi2_nc_cohen_cdf(self, x, nu, lambda1)
        else:
            return 1-ctxm.chi2_nc_cohen_cdf(self, x, nu, lambda1)


# 8.1.6 Noncentral Student 𝑡 distribution, cdf (integer degrees of freedom)

    def student_t_nc_owen_cdf(self, x, nu, delta, cdf=True):
        '''Returns the Noncentral Student 𝑡 distribution, cdf
        (integer degrees of freedom)'''
        if cdf:
            return ctxm.student_t_nc_owen_cdf(self, x, nu, delta)
        else:
            return 1-ctxm.student_t_nc_owen_cdf(self, x, nu, delta)


# 8.1.7 Noncentral Fisher 𝐹 distribution, cdf (𝑚 an even integer)

    def fisher_f_nc_seber_cdf(self, x, nu1, nu2, nc, cdf=True):
        '''Returns the Noncentral Fisher 𝐹 distribution, cdf
        (𝑚 an even integer)'''
        if cdf:
            return ctxm.fisher_f_nc_seber_cdf(self, x, nu1, nu2, nc)
        else:
            return 1-ctxm.fisher_f_nc_seber_cdf(self, x, nu1, nu2, nc)


# 8.1.8 Noncentral Beta distribution, cdf (𝑏 an integer)

    def beta_nc_seber_cdf(self, x, a, b, nc, cdf=True):
        '''Returns the Noncentral Beta distribution, cdf
        (𝑏 an integer)'''
        if cdf:
            return ctxm.beta_nc_seber_cdf(self, x, a, b, nc)
        else:
            return 1-ctxm.beta_nc_seber_cdf(self, x, a, b, nc)


# 8.1.9 Pearson’s 𝜌 distribution, pdf (integer N)

    def pearson_rho_nc_owen_pdf(self, r, N, rho):
        '''Returns Pearson’s 𝜌 distribution, pdf (integer N)'''
        return ctxm.pearson_rho_nc_owen_pdf(self, r, N, rho,)


# 8.1.10 Pearson’s 𝜌 distribution, cdf (integer N)

    def pearson_rho_nc_owen_cdf(self, r, N, rho, cdf=True):
        '''Returns Pearson’s 𝜌 distribution, cdf (integer N)'''
        if cdf:
            return ctxm.pearson_rho_nc_owen_cdf(self, r, N, rho,)
        else:
            return 1-ctxm.pearson_rho_nc_owen_cdf(self, r, N, rho,)


# 8.1.11 Fisher’s 𝑅2 distribution, cdf (finite sum for odd 𝑁 − 𝑝)

    def fisher_r2_gd1_cdf(self, x, p, N, Rho2, cdf=True):
        '''Returns Fisher’s 𝑅2 distribution, cdf (finite sum for odd 𝑁 − 𝑝)'''
        if cdf:
            return ctxm.fisher_r2_gd1_cdf(self, x, p, N, Rho2)
        else:
            return 1-ctxm.fisher_r2_gd1_cdf(self, x, p, N, Rho2)


# 8.1.12 Roy’s largest root distribution, pdf, cdf and sf

    def roy_pdf_cdf_sf(self, x, p, n1, n2):
        '''Returns Roy’s largest root distribution, pdf, cdf and sf'''
        return ctxm.roy_pdf_cdf_sf(self, x, p, n1, n2)


# %%% 8.2 Infinite sums algorithms for selected functions and distributions


# 8.2.1 Incomplete gamma function, continued fractions (Peizer)

    def gamma_peizer_cdf_sf_pdf(self, a, x):
        '''Returns the Incomplete gamma function,
        continued fractions (Peizer)'''
        return ctxm.gamma_peizer_cdf_sf_pdf(self, a, x)


# 8.2.2 Incomplete gamma function, asymptotic expansion (Paris)

    def gamma_paris_cdf_sf(self, a, x, n=10):
        '''Returns the Incomplete gamma function,
        asymptotic expansion (Paris)'''
        return ctxm.gamma_paris_cdf_sf(self, a, x, n)


# 8.2.3 Incomplete beta function, continued fractions (Peizer)

    def beta_peizer_cdf_sf_pdf(self, a, b, q, p):
        '''Returns the Incomplete beta function, continued fractions
        (Peizer)'''
        return ctxm.beta_peizer_cdf_sf_pdf(self, a, b, q, p)


# 8.2.4 Noncentral 𝜒2 distribution, pdf, cdf and sf (Boost)

    def chi2_nc_benton_cdf_sf(self, x, n, lambda1, cdf=True):
        '''Returns the Noncentral 𝜒2 distribution, pdf, cdf and sf (Boost)'''
        return ctxm.chi2_nc_benton_cdf_sf(self, x, n, lambda1, cdf)


# 8.2.5 Noncentral Student 𝑡 distribution, pdf, cdf and sf (Boost)

    def student_t_nc_benton_cdf_sf(self, x, nu, delta, cdf=True):
        '''Returns the Noncentral Student 𝑡 distribution,
        pdf, cdf and sf (Boost)'''
        return ctxm.student_t_nc_benton_cdf_sf(self, x, nu, delta, cdf)


# 8.2.6 Noncentral Beta distribution, pdf, cdf and sf (Boost)

    def beta_nc_benton_cdf_sf(self, x, a, b, lambda1, cdf=True):
        '''Returns the Noncentral Beta distribution, pdf, cdf and sf (Boost)'''
        return ctxm.beta_nc_benton_cdf_sf(self, x, a, b, lambda1, cdf)


# 8.2.7 Noncentral F distribution, pdf, cdf and sf (Boost)

    def fisher_f_nc_benton_cdf_sf(self, x, m, n, lambda1, cdf=True):
        '''Returns the Noncentral F distribution, pdf, cdf and sf (Boost)'''
        return ctxm.fisher_f_nc_benton_cdf_sf(self, x, m, n, lambda1, cdf)


# 8.2.8 Pearson’s 𝜌 distribution, cdf and sf (Hotelling’s series)

    def pearson_rho_nc_ht_cdf(self, r, N, rho):
        '''Returns the Pearson’s 𝜌 distribution, cdf and sf
        (Hotelling’s series)'''
        return ctxm.pearson_rho_nc_ht_cdf(self, r, N, rho)


# 8.2.9 Pearson’s 𝜌 distribution, cdf and sf (Guenther’s series)

    def pearson_rho_nc_gt_cdf(self, r, N, rho):
        '''Returns the Pearson’s 𝜌 distribution, cdf and sf
        (Hotelling’s series)'''
        return ctxm.pearson_rho_nc_gt_cdf(self, r, N, rho)


# 8.2.10 Fisher’s 𝑅2 distribution, pdf (Gurland)

    def fisher_r2_gd2_cdf(self, x, p, N, rho2):
        '''Returns the Fisher’s 𝑅2 distribution, pdf (Gurland)'''
        return ctxm.fisher_r2_gd2_cdf(self, x, p, N, rho2)


#  8.3 Finite series for lattice distributions, based on factorial moments

    def demo_factorial_moments_pdf(self):
        '''Returns  a finite series for lattice distributions, based on
        factorial moments'''
        print("demo_bell_shaped")

    def demo_factorial_moments_cdf(self):
        '''Returns  a finite series for lattice distributions, based on
        factorial moments'''
        print("demo_bell_shaped")


# 8.4 Efficient integration of bell-shaped functions

    def demo_bell_shaped(self):
        '''Returns Efficient integration of bell-shaped functions'''
        print("demo_bell_shaped")


# %%% 8.5 Verified numerical integration


# 8.5.1 Verified Integration

    def quad_verified(self, f, a, b, epsabsStart, alpha=1, beta=1,
                      verbose=False):
        '''Returns Verified Integration'''
        return ctxm.quad_verified(self, f, a, b, epsabsStart, alpha, beta,
                                  verbose)


# 8.5.2 Error function

    def real_quad_erf(self, x):
        '''Returns the Error function via Verified Integration'''
        return ctxm.real_quad_erf(self, x)


# 8.5.3 Lower non-normalised incomplete gamma function

    def real_quad_gamma_lower(self, a, x):
        '''Returns the Lower non-normalised incomplete gamma function via
        Verified Integration'''
        return ctxm.real_quad_gamma_lower(self, a, x)


# 8.5.4 Real upper non-normalised incomplete gamma function

    def real_quad_gamma_upper(self, a, x):
        '''Returns the Real upper non-normalised incomplete gamma function via
        Verified Integration'''
        return ctxm.real_quad_gamma_upper(self, a, x)


# 8.5.5 Normalised incomplete beta function

    def real_quad_ibeta(self, a, b, x):
        '''Returns the Normalised incomplete beta function via
        Verified Integration'''
        return ctxm.real_quad_ibeta(self, a, b, x)


# 8.5.6 Non-central chi-square cdf and sf (Chow)

    def chi_squared_nc_quad_cdf(self, n, x, l):
        '''Returns the Non-central chi-square cdf and sf (Chow) via
        Verified Integration'''
        return ctxm.chi_squared_nc_quad_cdf(self, n, x, l)


# 8.5.7 Marcum 𝑄 function

    def marcumq_quad(self, a, b):
        '''Returns the Marcum 𝑄 function via Verified Integration'''
        b = self.t(b)
        a = self.t(a)
        res = ctxm.marcumq_quad(self, a, b)
        return res


# 8.5.8 Owen’s 𝑇 function

    def owent(self, h, a):
        '''Returns Owen’s 𝑇 function via Verified Integration'''
        h = self.t(h)
        a = self.t(a)
        res = ctxm.owent_quad(self, h, a)
        return res


# %%% 8.6 Numerical Fourier transform and its inverse: continuous distributions

# 8.6.1 Central Chi-square: pdf, cdf, sf

    def chi_squared_gp(self):
        '''Returns the Central Chi-square: pdf, cdf, sf via Fourier
        transform'''
        return ctxm.chi_squared_gp(self)


# 8.6.2 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_gp(self):
        '''Returns the Wilks’ Lambda distribution: pdf, cdf, sf
        via Fourier transform'''
        return ctxm.wilks_lambda_gp(self)


# 8.6.3 Distribution of the product of independent beta variates: pdf, cdf and
    # sf

    def log_beta_prod_gp(self):
        '''Returns the Distribution of the product of independent beta
        variates: pdf, cdf, sf via Fourier transform'''
        return ctxm.log_beta_prod_gp(self)


# 8.6.4 Box-Davis distribution: pdf, cdf and sf

    def log_box_davis_gp(self):
        '''Returns the Box-Davis distribution:
        pdf, cdf, sf via Fourier transform'''
        return ctxm.log_box_davis_gp(self)


# 8.6.5 Noncentral Chi-square distribution: pdf, cdf, sf

    def chi_squared_nc_gp(self):
        '''Returns the Noncentral Chi-square distribution:
        pdf, cdf, sf via Fourier transform'''
        return ctxm.chi_squared_nc_gp(self)


# 8.6.6 Non-central Beta distribution: pdf, cdf and sf

    def log1mbeta_nc_gp(self):
        '''Returns the Non-central Beta distribution:
        pdf, cdf, sf via Fourier transform'''
        return ctxm.log1mbeta_nc_gp(self)


# 8.6.7 Fisher’s 𝑅2 distribution: pdf, cdf and sf

    def fisher_log1mr2_gp(self):
        '''Returns Fisher’s 𝑅2 distribution:
        pdf, cdf, sf via Fourier transform'''
        return ctxm.fisher_log1mr2_gp(self)


# 8.6.8 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf and sf

    def wilks_lambda_glm_gp(self):
        '''Returns the Noncentral Wilks’ Λ distribution: MANOVA,:
        pdf, cdf, sf via Fourier transform'''
        return ctxm.wilks_lambda_glm_gp(self)


# 8.6.9 Noncentral Wilks’ Λ distribution: Independence, pdf, cdf and sf

    def wilks_lambda_ind_gp(self):
        '''Returns the Noncentral Wilks’ Λ distribution: Independence,:
        pdf, cdf, sf via Fourier transform'''
        return ctxm.wilks_lambda_ind_gp(self)


# %%% 8.7 Numerical Fourier transform and its inverse: discrete distributions


# 8.8.1 Binomial distribution: pmf, cdf, sf

    def binomial_ft(self):
        '''Returns the Binomial distribution:
        pmf, cdf, sf via Fourier transform'''
        return ctxm.binomial_ft(self)


# 8.8.2 Wilcoxon distribution: pmf, cdf, sf

    def wilcoxon_ft(self):
        '''Returns the Wilcoxon distribution:
        pmf, cdf, sf via Fourier transform'''
        return ctxm.wilcoxon_ft(self)


# %% 109 Pmf vectors, sums and integrals


# %%%  9.1 Basic discrete (lattice) distribution functions


# 9.1.1 Poisson distribution, pmf vector

    def poisson_pmf_vector(self, lambda1, count=20):
        '''Returns the Poisson distribution, pmf vector'''
        return ctxm.poisson_pmf_vector(self, lambda1, count)

# 9.1.2 Binomial distribution, pmf vector

    def binomial_pmf_vector(self, n, p):
        '''Returns the Binomial distribution, pmf vector'''
        return ctxm.binomial_pmf_vector(self, n, p)

# 9.1.3 Negative binomial distribution, pmf vector

    def negbinom_pmf_vector(self, r, p, count=20):
        '''Returns the Negative binomial distribution, pmf vector'''
        return ctxm.negbinom_pmf_vector(self, r, p, count)

# 9.1.4 Hypergeometric distribution, pmf vector

    def hypergeo_pmf_vector(self, r, n, NN):
        '''Returns the Hypergeometric distribution, pmf vector'''
        return ctxm.hypergeo_pmf_vector(self, r, n, NN)


# 9.1.5 Noncentral hypergeometric distribution (Fisher), pmf vector

    def hypergeo_nc_pmf_vector(self, N):
        '''Returns the Noncentral hypergeometric distribution (Fisher),
        pmf vector'''
        return ctxm.hypergeo_nc_pmf_vector(self, N)


# %%%  9.2 Discrete (lattice) distribution functions related to (stratified)
    # rank tests


# 9.2.1 Sign test distribution (under 𝐻0), pmf vector

    def signtest_pmf_vector(self, N):
        '''Returns the Sign test distribution (under 𝐻0), pmf vector'''
        return ctxm.signtest_pmf_vector(self, N)


# 9.2.2 Wilcoxon 𝑇 distribution (under 𝐻0), pmf vector

    def wilcoxon_pmf_vector(self, N):
        '''Returns the Wilcoxon 𝑇 distribution (under 𝐻0), pmf vector'''
        return ctxm.wilcoxon_pmf_vector(self, N)

    def wilcoxon_full_vector(self, N, cdf=False, show=False, start=None,
                             stop=None):
        '''Returns the Wilcoxon 𝑇 distribution (under 𝐻0), pmf vector'''
        return ctxm.wilcoxon_full_vector(self, N, cdf, show, start, stop)


# 9.2.3 Wilcoxon 𝑇 distribution (under Bennett alternatives), pmf vector

    def wilcoxon_bennett_pmf_vector(self, N):
        '''Returns the Wilcoxon 𝑇 distribution (under Bennett alternatives),
        pmf vector'''
        return ctxm.poisson_pmf_vector(self, N)


# 9.2.4 Kendall 𝑆 (or tau) distribution (under 𝐻0), pmf vector

    def kendall_tau_pmf_vector(self, n):
        '''Returns the Kendall 𝑆 (or tau) distribution (under 𝐻0),
        pmf vector'''
        return ctxm.kendall_tau_pmf_vector(self, n)

    def kendall_full_vector(self, N, cdf=False, show=False, start=None,
                            stop=None):
        '''Returns the Kendall 𝑆 (or tau) distribution (under 𝐻0),
        pmf vector'''
        return ctxm.kendall_full_vector(self, N, cdf, show, start, stop)


# 9.2.5 Mann-Whitney 𝑈 distribution (under 𝐻0), pmf vector

    def mann_whitney_u_pmf_vector(self, m, n):
        '''Returns the Mann-Whitney 𝑈 distribution (under 𝐻0), pmf vector'''
        return ctxm.mann_whitney_u_pmf_vector(self, m, n)


# 9.2.6 Mann-Whitney 𝑈 distribution (under Lehmann alternatives), pmf vector

    def mannwhitney_u_lehmann_pmf_vector(self, kValue, N1, n2):
        '''Returns the Mann-Whitney 𝑈 distribution (under Lehmann
        alternatives), pmf vector'''
        return ctxm.mannwhitney_u_lehmann_pmf_vector(self, kValue, N1, n2)


# 9.2.7 Mann-Whitney 𝑈 distribution (under Milton alternatives), pmf vector

    def mannwhitney_u_milton_pmf_vector(self, m, n):
        '''Returns the Mann-Whitney 𝑈 distribution (under Milton alternatives),
        pmf vector'''
        return ctxm.mannwhitney_u_milton_pmf_vector(self, m, n)

    def milton_pmf(self, n, delta):
        '''Returns the Mann-Whitney 𝑈 distribution (under Milton alternatives),
        pmf vector'''
        return ctxm.milton_pmf(self, n, delta)


# 9.2.8 Jonckheere-Terpsta 𝑆 distribution (under 𝐻0), pmf vector

    def jterpsta_s_pmf_vector(self, k, n):
        '''Returns the Jonckheere-Terpsta 𝑆 distribution (under 𝐻0),
        pmf vector'''
        return ctxm.jterpsta_s_pmf_vector(self, k, n)


# 9.2.9 Spearman 𝜌 distribution (under 𝐻0), pmf vector

    def spearman_rho_pmf_vector(self, k, Order):
        '''Returns the Spearman 𝜌 distribution (under 𝐻0), pmf vector'''
        return ctxm.spearman_rho_pmf_vector(self, k, Order)


# 9.2.10 Page 𝐿 distribution (under 𝐻0), pmf vector

    def page_l_pmf_vector(self, k, n):
        '''Returns the Page 𝐿 distribution (under 𝐻0), pmf vector'''
        return ctxm.page_l_pmf_vector(self, k, n)


# 9.2.11 Quade 𝐿 distribution (under 𝐻0), pmf vector

    def quade_l_pmf_vector(self, k, n):
        '''Returns the Quade 𝐿 distribution (under 𝐻0), pmf vector'''
        return ctxm.quade_l_pmf_vector(self, k, n)


# %%%  9.3 Discrete (non-lattice) distribution functions related to rank tests


# 9.3.1 Cochran 𝑆 distribution (under 𝐻0), pmf vector

    def cochran_s_pmf_vector(self, m, n):
        '''Returns the Cochran 𝑆 distribution (under 𝐻0), pmf vector'''
        return ctxm.cochran_s_pmf_vector(self, m, n)


# 9.2.2 Friedman 𝑆 distribution (under 𝐻0), pmf vector

    def friedman_s_pmf_vector(self, GetWhat, sum2, n, Quade, Mode, Mode2):
        '''Returns the Friedman 𝑆 distribution (under 𝐻0), pmf vector'''
        return ctxm.friedman_s_pmf_vector(self, GetWhat, sum2, n, Quade, Mode,
                                          Mode2)


# 9.3.3 Quade 𝑆 distribution (under 𝐻0), pmf vector

    def quade_s_pmf_vector(self, m, n):
        '''Returns the Quade 𝑆 distribution (under 𝐻0), pmf vector'''
        return ctxm.quade_s_pmf_vector(self, m, n)


# 9.3.4 Kruskal-Wallis 𝐻 distribution (under 𝐻0), pmf vector

    def kruskal_wallis_h_pmf_vector(self, n):
        '''Returns the Kruskal-Wallis 𝐻 distribution (under 𝐻0), pmf vector'''
        return ctxm.kruskal_wallis_h_pmf_vector(self, n)





# %% 110 Asymptotic expansions

# %%% 10.1 Edgeworth and Cornish-Fisher expansions: continuous distributions


#   10.1.1 Edgeworth expansion: general approximation to the pdf, cdf and sf

    def edgeworth(self, x, order, kappa):
        '''Returns the Edgeworth expansion: general approximation to the
        pdf, cdf and sf'''
        return ctxm.edgeworth(self, x, order, kappa)


#   10.1.2 Cornish-Fisher expansion: general approximation to the qtf and isf

    def cornish_fisher(self, LeftTail, RightTail, kappa, nord):
        '''Returns the Cornish-Fisher expansion: general approximation to the
        qtf and isf'''
        return ctxm.cornish_fisher(self, LeftTail, RightTail, kappa, nord)


#    def CalcCornish(self, LeftTail, RightTail, mean, sigma, kappa, nord):
#        result = ctxm.CalcCornish(self, LeftTail, RightTail, mean, sigma,
    # kappa, nord)
#        return result


#   10.1.3 Central Chi-squared distribution

    def chi2_ecf(self, x, n, order, verbose):
        '''Returns the Central Chi-square distribution, pdf, cdf and sf
        calculated via ecf'''
        return ctxm.chi2_ecf(self, x, n, order, verbose)


#   10.1.4 Chi-squared distribution: qtf and isf

    def chi2_ecf_inv(self, L1, R1, n, order, verbose):
        '''Returns the Central Chi-square distribution, qtf and isf,
        calculated via ecf_inv'''
        return ctxm.chi2_ecf_inv(self, L1, R1, n, order, verbose)


#    def chi_squared_cumulants(self, k, df):
#        return ctxm.chi_squared_cumulants(self, k, df)


#  10.1.5 Distribution of the logarithm of a 𝜒2 random variable: pdf, cdf
    # and sf

    def logrv_chi2_ecf(self):
        '''Returns the Distribution of the logarithm of a 𝜒2 random variable,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.logrv_chisquared_ecf(self)

#  10.1.6 Distribution of the logarithm of a 𝜒2 random variable: qtf and isf

    def logrv_chi2_ecf_inv(self):
        '''Returns the Distribution of the logarithm of a 𝜒2 random variable,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.logrv_chisquared_ecf_inv(self)


#  10.1.7 Fisher 𝑧 distribution: pdf, cdf and sf

    def fisher_z_ecf(self):
        '''Returns the Fisher 𝑧 distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.fisher_z_ecf(self)

#  10.1.8 Fisher 𝑧 distribution: qtf and isf

    def fisher_z_ecf_inv(self):
        '''Returns the Fisher 𝑧 distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.fisher_z_ecf_inv(self)


#  10.1.9 Distribution of the negative logarithm of a beta variable: pdf, cdf
    # and sf

    def logrv_beta_ecf_pdf(self):
        '''Returns the Distribution of the negative logarithm of a beta
        variable, pdf, cdf and sf, calculated via ecf'''
        return ctxm.logrv_beta_ecf_pdf(self)

#  10.1.10 Distribution of the negative logarithm of a beta variable: qtf and
    # isf

    def logrv_beta_ecf_qtf(self):
        '''Returns the Distribution of the negative logarithm of a beta
        variable, qtf and isf, calculated via ecf_inv'''
        return ctxm.logrv_beta_ecf_qtf(self)


#  10.1.11 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_ecf(self):
        '''Returns Wilks’ Lambda distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.wilks_lambda_ecf(self)

#  10.1.12 Wilks’ Lambda distribution: qtf and isf

    def wilks_lambda_ecf_inv(self):
        '''Returns Wilks’ Lambda distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.wilks_lambda_ecf_inv(self)


#  10.1.13 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def pillai_v_ecf(self):
        '''Returns Pillai’s 𝑉 distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.pillai_v_ecf(self)

#  10.1.14 Pillai’s 𝑉 distribution: qtf and isf

    def pillai_v_ecf_inv(self):
        '''Returns Pillai’s 𝑉 distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.pillai_v_ecf_inv(self)

    def pillai_v_moments(self, k, p, n1, n2):
        '''Returns the moments of Pillai’s 𝑉 distribution.'''
        return ctxm.pillai_v_moments(self, k, p, n1, n2)


#  10.1.15 Hotelling’s 𝑇2 distribution: pdf, cdf and sf

    def hotelling_t2_ecf(self):
        '''Returns Hotelling’s 𝑇2 distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.hotelling_t2_ecf(self)

#  10.1.16 Hotelling’s 𝑇2 distribution: qtf and isf

    def hotelling_t2_ecf_inv(self):
        '''Returns Hotelling’s 𝑇2 distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.hotelling_t2_ecf_inv(self)

    def hotelling_t2_moments(self, k, p, n1, n2):
        '''Returns the moments of Hotelling’s 𝑇2 distribution.'''
        return ctxm.hotelling_t2_moments(self, k, p, n1, n2)


#  10.1.17 Distribution of the product of independent beta variates: pdf, cdf
    # and sf

    def beta_product_ecf(self):
        '''Returns the Distribution of the product of independent beta
        variates, pdf, cdf and sf, calculated via ecf'''
        return ctxm.beta_product_ecf(self)

#  10.1.18 Distribution of the product of independent beta variates:
    # qtf and isf

    def beta_product_ecf_inv(self):
        '''Returns the Distribution of the product of independent beta
        variates, qtf and isf, calculated via ecf_inv'''
        return ctxm.beta_product_ecf_inv(self)


#  10.1.19 Box-Davis distribution (covariance matrices): pdf, cdf and sf

    def box_davis_ecf(self):
        '''Returns the Distribution of the product of independent beta
        variates, pdf, cdf and sf, calculated via ecf'''
        return ctxm.box_davis_ecf(self)

#  10.1.20 Box-Davis distribution (covariance matrices): qtf and isf

    def box_davis_ecf_inv(self):
        '''Returns the Distribution of the product of independent beta
        variates, qtf and isf, calculated via ecf_inv'''
        return ctxm.box_davis_ecf_inv(self)


#  10.1.21 Noncentral chi-squared distribution: pdf, cdf and sf

    def chi_squared_nc_ecf(self, x, n, lambda1, order, verbose):
        '''Returns the Noncentral chi-squared distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.chi_squared_nc_ecf(self, x, n, lambda1, order, verbose)

#  10.1.22 Noncentral chi-squared distribution: qtf and isf

    def chi_squared_nc_ecf_inv(self):
        '''Returns the Noncentral chi-squared distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.chi_squared_nc_ecf_inv(self)


#  10.1.23 Noncentral 𝑡-distribution: pdf, cdf and sf

    def student_t_nc_ecf(self):
        '''Returns the Noncentral 𝑡-distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.student_t_nc_ecf(self)

#  10.1.24 Noncentral 𝑡-distribution: qtf and isf

    def student_t_nc_ecf_inv(self):
        '''Returns the Noncentral 𝑡-distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.student_t_nc_ecf_inv(self)


#  10.1.25 Noncentral 𝐹-distribution: pdf, cdf and sf

    def fisher_f_nc_ecf(self):
        '''Returns the Noncentral 𝐹-distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.fisher_f_nc_ecf(self)

#  10.1.26 Noncentral 𝐹-distribution: qtf and isf

    def fisher_f_nc_ecf_inv(self):
        '''Returns the Noncentral 𝐹-distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.fisher_f_nc_ecf_inv(self)

#    def fisher_f_nc_moments(self, k, n1, n2, lambda1):
#        return ctxm.fisher_f_nc_moments(self, k, n1, n2, lambda1)


#  10.1.27 Doubly noncentral 𝑡-distribution: pdf, cdf and sf

    def student_t_nc2_ecf(self):
        '''Returns the Doubly noncentral 𝑡-distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.student_t_nc2_ecf(self)

#  10.1.28 Doubly noncentral 𝑡-distribution: qtf and isf
    def student_t_nc2_ecf_inv(self):
        '''Returns the Doubly noncentral 𝑡-distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.student_t_nc2_ecf_inv(self)

#    def student_t_nc2_moments(self, k, n, delta, theta):
#        return ctxm.student_t_nc2_moments(self, k, n, delta, theta)


#  10.1.29 Doubly noncentral 𝐹-distribution: pdf, cdf and sf

    def fisher_f_nc2_ecf(self):
        '''Returns the Doubly noncentral 𝐹-distribution,
        pdf, cdf and sf, calculated via ecf'''
        return ctxm.fisher_f_nc2_ecf(self)

#  10.1.30 Doubly noncentral 𝐹-distribution: qtf and isf

    def fisher_f_nc2_ecf_inv(self):
        '''Returns the Doubly noncentral 𝐹-distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.fisher_f_nc2_ecf_inv(self)

#    def fisher_f_nc2_moments(self, k, n1, n2, lambda1, lambda2):
#        return ctxm.fisher_f_nc2_moments(self, k, n1, n2, lambda1, lambda2)


# %%% 10.2 Edgeworth and Cornish-Fisher expansions: discrete (“lattice”)
    # distributions

#   10.2.1 The Sheppard correction

    def sheppard_correction(self, kappa, show=False):
        '''Returns the Sheppard correction'''
        return ctxm.sheppard_correction(self, kappa, show)


#   10.2.2 Poisson distribution: pdf, cdf and sf

    def poisson_ecf(self):
        '''Returns the Poisson distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.poisson_ecf(self)

#   10.2.3 Poisson distribution: qtf and isf

    def poisson_ecf_inv(self):
        '''Returns the Poisson distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.poisson_ecf_inv(self)

#    def poisson_cumulants(self, mu, maxcum):
#        return ctxm.poisson_cumulants(self, mu, maxcum)


#   10.2.4 Binomial distribution: pdf, cdf and sf

    def binomial_ecf(self):
        '''Returns the Binomial distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.binomial_ecf(self)

#   10.2.5 Binomial distribution: qtf and isf

    def binomial_ecf_inv(self):
        '''Returns the Binomial distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.binomial_ecf_inv(self)

#    def binomial_cumulants(self, n, p, rmax):
#        return ctxm.binomial_cumulants(self, n, p, rmax)


#   10.2.6 Negative binomial distribution: pdf, cdf and sf

    def negbinom_ecf(self):
        '''Returns the Negative binomial distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.negbinom_ecf(self)

#   10.2.7 Negative binomial distribution: qtf and isf

    def negbinom_ecf_inv(self):
        '''Returns the Negative binomial distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.negbinom_ecf_inv(self)

#    def negbinom_cumulants(self, r, p, jmax):
#        return ctxm.negbinom_cumulants(self, r, p, jmax)


#   10.2.8 Hypergeometric distribution: pdf, cdf and sf

    def hypergeo_ecf(self):
        '''Returns the Hypergeometric distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.hypergeo_ecf(self)

#   10.2.9 Hypergeometric distribution: qtf and isf

    def hypergeo_ecf_inv(self):
        '''Returns the Hypergeometric distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.hypergeo_ecf_inv(self)

#    def hypergeo_rawmoments(self, M, n, NN, rmax):
#        return ctxm.hypergeo_rawmoments(self, M, n, NN, rmax)
#
#    def hypergeo_cumulants(self, M, n, NN, rmax):
#        return ctxm.hypergeo_cumulants(self, M, n, NN, rmax)


#   10.2.10 Wilcoxon Signed Rank distribution: pdf, cdf and sf

    def wilcoxon_ecf(self, x, N, order):
        '''Returns the Wilcoxon Signed Rank distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.wilcoxon_ecf(self, x, N, order)

#   10.2.11 Wilcoxon Signed Rank distribution: qtf and isf

    def wilcoxon_ecf_inv(self, L1, R1, N, order):
        '''Returns the Wilcoxon Signed Rank distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.wilcoxon_ecf_inv(self, L1, R1, N, order)

#    def wilcoxon_cumulants(self, n, maxcum):
#        return ctxm.wilcoxon_cumulants(self, n, maxcum)


#   10.2.12 Kendall’s 𝑆 (or 𝜏 ) distribution: pdf, cdf and sf

    def kendall_ecf(self, x, N, order):
        '''Returns Kendall’s 𝑆 (or 𝜏 ) distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.kendall_ecf(self, x, N, order)

#   10.2.13 Kendall’s 𝑆 (or 𝜏 ) distribution: qtf and isf

    def kendall_ecf_inv(self, L1, R1, N, order):
        '''Returns Kendall’s 𝑆 (or 𝜏 ) distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.kendall_ecf_inv(self, L1, R1, N, order)

#    def kendall_cumulants(self, n, maxcum):
#        return ctxm.kendall_cumulants(self, n, maxcum)


#   10.2.14 Mann-Whitney 𝑈 distribution: pdf, cdf and sf

    def mannwhitney_ecf(self):
        '''Returns Mann-Whitney's 𝑈 distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.mannwhitney_ecf(self)

#   10.2.15 Mann-Whitney 𝑈 distribution: qtf and isf

    def mannwhitney_ecf_inv(self):
        '''Returns Mann-Whitney's 𝑈 distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.mannwhitney_ecf_inv(self)


#   10.2.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf and sf

    def jterpsta_ecf(self):
        '''Returns Jonckheere-Terpsta's 𝑆 distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.jterpsta_ecf(self)

#   10.2.17 Jonckheere-Terpsta 𝑆 distribution: qtf and isf

    def jterpsta_ecf_inv(self):
        '''Returns Jonckheere-Terpsta's 𝑆 distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.jterpsta_ecf_inv(self)

#    def TerpstaCum(self, k, n, maxcum):
#        return ctxm.TerpstaCum(self, k, n, maxcum)


#   10.2.18 Page 𝐿 distribution: pdf, cdf and sf

    def page_ecf(self):
        '''Returns Page's 𝐿 distribution,
        pmf, cdf and sf, calculated via ecf'''
        return ctxm.page_ecf(self)

#   10.2.19 Page 𝐿 distribution: qtf and isf

    def page_ecf_inv(self):
        '''Returns Page's 𝐿 distribution,
        qtf and isf, calculated via ecf_inv'''
        return ctxm.page_ecf_inv(self)


# %%%  10.3 Luggannini-Rice and Jensen saddle point expansions: continuous
    # distributions

#   10.3.1 Luggannini-Rice expansion: general approximation to the pdf, cdf, and
    # sf

    def lugannani_rice(self, order, kderiv, s, verbose=True):
        '''Returns the Luggannini-Rice expansion: general approximation to the
        pdf, cdf, and sf'''
        return ctxm.lugannani_rice(self, order, kderiv, s, verbose)


#   10.3.2a Jensen expansion: general approximation to the pdf, cdf, and sf

    def jensen(self, kderiv, s):
        '''Returns the Jensen expansion: general approximation to the
        pdf, cdf, and sf'''
        return ctxm.jensen(self, kderiv, s)


#   10.3.2b Inverse Jensen expansion: general approximation to the qtf and isf

    def jensen_inverse(self, n0, lambda0_, za_):
        '''Returns the Inverse Jensen expansion: general approximation to the
        qtf and isf'''
        return ctxm.jensen_inverse(self, n0, lambda0_, za_)


#   10.3.3 Central Chi-square distribution: pdf, cdf, sf

    def chi_squared_spa(self):
        '''Returns the Central Chi-square distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.chi_squared_spa(self)

#   10.3.4 Central Chi-square distribution: qtf, isf

    def chi_squared_spa_inv(self):
        '''Returns the Central Chi-square distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.chi_squared_spa_inv(self)


#   10.3.5 Fisher 𝑧 distribution: pdf, cdf, sf

    def fisher_z_spa(self):
        '''Returns the Central Fisher 𝑧 distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.fisher_z_spa(self)

#   10.3.6 Fisher 𝑧 distribution: qtf, isf

    def fisher_z_spa_inv(self):
        '''Returns the Central Fisher 𝑧 distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.fisher_z_spa_inv(self)


#   10.3.7 Noncentral Chi-square distribution: pdf, cdf, sf

    def chi2_nc_spa(self, x0, n0, lambda0_, Order=10, verbose=False):
        '''Returns the Noncentral Chi-square distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.chi2_nc_spa(self, x0, n0, lambda0_, Order, verbose)


#   10.3.8 Noncentral Chi-square distribution: qtf, isf

    def chi2_nc_spa_inv(self):
        '''Returns the Noncentral Chi-square distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.chi2_nc_spa_inv(self)


#  10.3.9 Doubly Non-central Fisher F distribution

    def fisher_f_nc2_spa(self, x, n1, n2, lambda1, lambda2):
        '''Returns the Doubly Non-central Fisher F distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.fisher_f_nc2_spa(self, x, n1, n2, lambda1, lambda2)


#  10.3.10 Doubly Non-central Fisher F distribution: qtf, isf

    def fisher_f_nc2_spa_inv(self):
        '''Returns the Doubly Non-central Fisher F distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.fisher_f_nc2_spa_inv(self)


#  10.3.11 Wilks’ Λ distribution, pdf, cdf, sf

    def wilks_lambda_spa(self):
        '''Returns Wilks’ Λ distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.wilks_lambda_spa(self)

#  10.3.12 Wilks’ Λ distribution, cdf and sf

    def wilks_lambda_spa_inv(self):
        '''Returns Wilks’ Λ distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.wilks_lambda_spa_inv(self)


#  10.3.13 Distribution of the product of independent beta variables, pdf, cdf,
    # sf

    def beta_prod_spa(self):
        '''Returns the Distribution of the product of independent beta
        variables, pdf, cdf and sf, calculated via spa'''
        return ctxm.beta_prod_spa(self)

#  10.3.14 Distribution of the product of independent beta variables : qtf, isf

    def beta_prod_spa_inv(self):
        '''Returns the Distribution of the product of independent beta
        variables, qtf and isf, calculated via spa_inv'''
        return ctxm.beta_prod_spa_inv(self)


#  10.3.15 Box distribution: pdf, cdf, sf

    def box_spa(self):
        '''Returns the Box distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.box_spa(self)

#  10.3.16 Box distribution : qtf, isf
    def box_spa_inv(self):
        '''Returns the Box distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.box_spa_inv(self)


#  10.3.17 Non-central Beta distribution: pdf, cdf, sf

    def beta_nc_spa(self):
        '''Returns the Non-central Beta distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.beta_nc_spa(self)

#  10.3.18 Non-central Beta distribution : qtf, isf

    def beta_nc_spa_inv(self):
        '''Returns the Non-central Beta distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.beta_nc_spa_inv(self)


#  10.3.19 Fisher’s 𝑅2 distribution: pdf, cdf, sf

    def fisher_r2_spa(self):
        '''Returns Fisher’s 𝑅2 distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.fisher_r2_spa(self)

#  10.3.20 Fisher’s 𝑅2 distribution : qtf, isf

    def fisher_r2_spa_inv(self):
        '''Returns Fisher’s 𝑅2 distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.fisher_r2_spa_inv(self)


#  10.3.21 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf, sf

    def wilks_lambda_glm_spa(self):
        '''Returns the Noncentral Wilks’ Λ distribution: MANOVA,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.wilks_lambda_glm_spa(self)

#  10.3.22 Noncentral Wilks’ Λ distribution: MANOVA, qtf, isf

    def wilks_lambda_glm_inv(self):
        '''Returns the Noncentral Wilks’ Λ distribution: MANOVA,
        qtf and isf, calculated via spa_inv'''
        return ctxm.wilks_lambda_glm_inv(self)


#  10.3.23 Noncentral Wilks’ Λ distribution: Independence, pdf, cdf, sf

    def wilks_lambda_ind_spa(self):
        '''Returns the Noncentral Wilks’ Λ distribution: Independence,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.wilks_lambda_ind_spa(self)

#  10.3.24 Noncentral Wilks’ Λ distribution: Independence, : qtf, isf

    def wilks_lambda_ind_spa_inv(self):
        '''Returns the Noncentral Wilks’ Λ distribution: Independence,
        qtf and isf, calculated via spa_inv'''
        return ctxm.wilks_lambda_ind_spa_inv(self)


# %%% 10.4 Luggannini-Rice and Jensen saddle point expansions: discrete
    # (“lattice”) distributions


#  10.4.1 The Sheppard correction

    def sheppard_per_cgf(self):
        '''Returns the Sheppard correction for the CGF'''
        return ctxm.sheppard_per_cgf(self)


#  10.4.2 Poisson distribution: pdf, cdf, sf

    def poisson_spa(self):
        '''Returns the Poisson distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.poisson_spa(self)

#  10.4.3 Poisson distribution: qtf, isf

    def poisson_spa_inv(self):
        '''Returns the Poisson distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.poisson_spa_inv(self)


#  10.4.4 Binomial distribution: pdf, cdf and sf

    def binomial_spa(self):
        '''Returns the Binomial distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.binomial_spa(self)

#  10.4.5 Binomial distribution: qtf and isf

    def binomial_spa_inv(self):
        '''Returns the Binomial distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.binomial_spa_inv(self)

    def binomial_kderiv(self, order, t, n, p):
        '''Returns the derivatives of the CGF of Binomial distribution'''
        return ctxm.binomial_kderiv(self, order, t, n, p)


#  10.4.6 Negative binomial distribution: pdf, cdf and sf

    def negbinom_spa(self):
        '''Returns the Negative binomial distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.negbinom_spa(self)

#  10.4.7 Negative binomial distribution: qtf and isf

    def negbinom_spa_inv(self):
        '''Returns the Negative binomial distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.negbinom_spa_inv(self)

    def negbinomial_kderiv(self, order, t, r, p):
        '''Returns the derivatives of the CGF of the Binomial distribution'''
        return ctxm.negbinomial_kderiv(self, order, t, r, p)


#  10.4.8 Hypergeometric distribution: pdf, cdf and sf

    def hypergeo_spa(self):
        '''Returns the Hypergeometric distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.hypergeo_spa(self)

#  10.4.9 Hypergeometric distribution: qtf and isf

    def hypergeo_spa_inv(self):
        '''Returns the Hypergeometric distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.hypergeo_spa_inv(self)

    def hypergeo_kderiv(self, t, n, K, N):
        '''Returns the derivatives of the CGF of the Hypergeometric
        distribution'''
        return ctxm.hypergeo_kderiv(self, t, n, K, N)


#  10.4.10 Wilcoxon distribution: pdf, cdf, sf

    def wilcoxon_spa(self):
        '''Returns the Wilcoxon distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.wilcoxon_spa(self)

#  10.4.11 Wilcoxon distribution: qtf, isf

    def wilcoxon_spa_inv(self):
        '''Returns the Wilcoxon distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.wilcoxon_spa_inv(self)


#  10.4.12 Mann-Whitney’s U distribution: pdf, cdf, sf

    def mannwhitney_spa(self):
        '''Returns the Mann-Whitney’s U distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.mannwhitney_spa(self)

#  10.4.13 Mann-Whitney’s U distribution: qtf, isf

    def mannwhitney_spa_inv(self):
        '''Returns the Mann-Whitney’s U distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.mannwhitney_spa_inv(self)


#  10.4.14 Kendall’s Tau distribution: pdf, cdf, sf

    def kendall_tau_spa(self):
        '''Returns Kendall’s Tau distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.kendall_tau_spa(self)

#  10.4.15 Kendall’s Tau distribution: qtf, isf

    def kendall_tau_spa_inv(self):
        '''Returns Kendall’s Tau distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.kendall_tau_spa_inv(self)


#  10.4.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf, sf

    def jterpsta_spa(self):
        '''Returns the Jonckheere-Terpsta 𝑆 distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.jterpsta_spa(self)

#  10.4.17 Jonckheere-Terpsta 𝑆 distribution: qtf, isf

    def jterpsta_spa_inv(self):
        '''Returns the Jonckheere-Terpsta 𝑆 distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.jterpsta_spa_inv(self)


#  10.4.18 Page 𝐿 distribution: pdf, cdf, sf

    def page_spa(self):
        '''Returns the Page 𝐿 distribution,
        pdf, cdf and sf, calculated via spa'''
        return ctxm.page_spa(self)

#  10.4.19 Page 𝐿 distribution: qtf, isf

    def page_spa_inv(self):
        '''Returns the Page 𝐿 distribution,
        qtf and isf, calculated via spa_inv'''
        return ctxm.page_spa_inv(self)


# %%%  10.5 Box-Davis expansions and their inverses

#  10.5.1 Box-Davis expansion: general approximation to the pdf, cdf and sf

    def box_davis_expansion(self, x, f, rho, omega):
        '''Returns the Box-Davis expansion: a general approximation to the
        pdf, cdf and sf'''
        return ctxm.box_davis_expansion(self, x, f, rho, omega)

#  10.5.2 Inverse Box-Davis expansion: a general approximation to the qtf and
    # isf

    def box_davis_expansion_inv(self, q, f, rho, omega):
        '''Returns the Inverse Box-Davis expansion: a general approximation
        to the pdf, cdf and sf'''
        return ctxm.box_davis_expansion_inv(self, q, f, rho, omega)


#  10.5.3 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_bd(self, x, f, rho, omega):
        '''Returns Wilks’ Lambda distribution,
        pdf, cdf and sf, calculated via Box-Davis expansion'''
        return ctxm.wilks_lambda_bd(self, x, f, rho, omega)

#  10.5.4 Wilks’ Lambda distribution: qtf and isf

    def wilks_lambda_bd_inv(self, q, f, rho, omega):
        '''Returns Wilks’ Lambda distribution,
        qtf and isf, calculated via Inverse Box-Davis expansion'''
        return ctxm.wilks_lambda_bd_inv(self, q, f, rho, omega)


#  10.5.5 Distribution of the product of independent beta variates: pdf, cdf
    # and sf

    def beta_product_bd(self, x, f, rho, omega):
        '''Returns the Distribution of the product of independent beta
        pdf, cdf and sf, calculated via Box-Davis expansion'''
        return ctxm.beta_product_bd(self, x, f, rho, omega)

# 10.5.6 Distribution of the product of independent beta variates: qtf and isf

    def beta_product_bd_inv(self, q, f, rho, omega):
        '''Returns the Distribution of the product of independent beta
        variates, qtf and isf, calculated via Inverse Box-Davis expansion'''
        return ctxm.beta_product_bd_inv(self, q, f, rho, omega)


#  10.5.7 Distribution of Box’s test of equality of k covariance matrices,
    # unequal sample sizes: pdf, cdf and sf

    def box_cov_bd(self, x, f, rho, omega):
        '''Returns the Distribution of Box’s test of equality of k covariance
        matrices, unequal sample sizes:
        pdf, cdf and sf, calculated via Box-Davis expansion'''
        return ctxm.box_cov_bd(self, x, f, rho, omega)

#  10.5.8 Distribution of Box’s test of equality of k covariance matrices,
    # unequal sample sizes: qtf and isf

    def box_cov_bd_inv(self, q, f, rho, omega):
        '''Returns the Distribution of Box’s test of equality of k covariance
        matrices, unequal sample sizes:
        qtf and isf, calculated via Inverse Box-Davis expansion'''
        return ctxm.box_cov_bd_inv(self, q, f, rho, omega)


#  10.5.9 Distribution of Box’s test for same multivariate normal
    # distributions, unequal sample sizes: pdf, cdf and sf

    def box_means_cov_bd(self, x, f, rho, omega):
        '''Returns the Distribution of Box’s test for same multivariate normal
        distributions, unequal sample sizes:
        pdf, cdf and sf, calculated via Box-Davis expansion'''
        return ctxm.box_means_cov_bd(self, x, f, rho, omega)

#  10.5.10 Distribution of Box’s test for same multivariate normal
    # distributions, unequal sample sizes: qtf and isf

    def box_means_cov_bd_inv(self, q, f, rho, omega):
        '''Returns the Distribution of Box’s test for same multivariate normal
        distributions, unequal sample sizes:
        qtf and isf, calculated via Inverse Box-Davis expansion'''
        return ctxm.box_means_cov_bd_inv(self, q, f, rho, omega)


#  10.5.11 Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix: pdf, cdf and sf

    def lrt_vc0_bd(self, x, f, rho, omega):
        '''Returns the Distribution of the modified likelihood ratio test (LRT)
        for a given covariance matrix:
        pdf, cdf and sf, calculated via Box-Davis expansion'''
        return ctxm.lrt_vc0_bd(self, x, f, rho, omega)

#  10.5.12 Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix: qtf and isf

    def lrt_vc0_bd_inv(self, q, f, rho, omega):
        '''Returns the Distribution of the modified likelihood ratio test (LRT)
        for a given covariance matrix:
        qtf and isf, calculated via Inverse Box-Davis expansion'''
        return ctxm.lrt_vc0_bd_inv(self, q, f, rho, omega)


#  10.5.13 Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix and mean: pdf, cdf and sf

    def lrt_x0_vc0_bd(self, x, f, rho, omega):
        '''Returns the Distribution of the modified likelihood ratio test (LRT)
        for a given covariance matrix and mean:
        pdf, cdf and sf, calculated via Box-Davis expansion'''
        return ctxm.lrt_x0_vc0_bd(self, x, f, rho, omega)

#  10.5.14 Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix and mean: qtf and isf

    def lrt_x0_vc0_bd_inv(self, q, f, rho, omega):
        '''Returns the Distribution of the modified likelihood ratio test (LRT)
        for a given covariance matrix and mean:
        qtf and isf, calculated via Inverse Box-Davis expansion'''
        return ctxm.lrt_x0_vc0_bd_inv(self, q, f, rho, omega)


#  10.5.15 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def pillai_v_bd(self, x, f, rho, omega):
        '''Returns Pillai’s 𝑉 distribution:
        pdf, cdf and sf, calculated via Box-Davis expansion'''
        return ctxm.pillai_v_bd(self, x, f, rho, omega)

#  10.5.16 Pillai’s 𝑉 distribution: qtf and isf

    def pillai_v_bd_inv(self, q, f, rho, omega):
        '''Returns Pillai’s 𝑉 distribution:
        qtf and isf, calculated via Inverse Box-Davis expansion'''
        return ctxm.pillai_v_bd_inv(self, q, f, rho, omega)


#  10.5.17 Hotelling’s 𝑇2 distribution: pdf, cdf and sf

    def hotelling_t2_bd(self, x, f, rho, omega):
        '''Returns Hotelling’s 𝑇2 distribution:
        pdf, cdf and sf, calculated via Box-Davis expansion'''
        return ctxm.hotelling_t2_bd(self, x, f, rho, omega)

#  10.5.18 Hotelling’s 𝑇2 distribution: qtf and isf

    def hotelling_t2_bd_inv(self, q, f, rho, omega):
        '''Returns Hotelling’s 𝑇2 distribution:
        qtf and isf, calculated via Inverse Box-Davis expansion'''
        return ctxm.hotelling_t2_bd_inv(self, q, f, rho, omega)


# %% 111 Fast approximations, without error estimates

# %%%  11.1 Approximations based on the normal distribution

# 11.1.1 Non-central chi-squared distribution: cdf and sf (Penev)

    def chi2_nc_penev_cdf(self, x, nu, nc):
        '''Returns the Non-central chi-squared distribution:
        cdf and sf (Penev)'''
        return ctxm.cdisn_penev(self, x, nu, nc)


# 11.1.2 (Non-central) chi-squared distribution: qtf and isf (Canal)

    def chi2_nc_canal_qtf(self, L, R, n):
        '''Returns the (Non-central) chi-squared distribution:
        qtf and isf (Canal)'''
        return ctxm.cdisx_approx(self, L, R, n)


# 11.1.3 Gamma distribution: qtf and isf (Canal)

    def gamma_canal_qtf(self, L, R, a):
        '''Returns the Gamma distribution: qtf and isf (Canal)'''
        return ctxm.gammainv_approx(self, L, R, a)


# 11.1.4 F distribution: qtf and isf (Davis)

    def fisher_f_davis_qtf(self, l, r, m, n):
        '''Returns the F distribution: qtf and isf (Davis)'''
        return ctxm.fdisx_approx(self, l, r, m, n)


# 11.1.5 Beta distribution: qtf and isf (Davis)

    def beta_davis_qtf(self, l, r, a, b):
        '''Returns the Beta distribution: qtf and isf (Davis)'''
        return ctxm.fdisx_approx(self, l, r, a, b)


# 11.1.6 Pearson’s rho distribution: pdf (Winterbottom)

    def pearson_rho_wb_pdf(self, N, r, rho):
        '''Returns Pearson’s rho distribution: pdf (Winterbottom)'''
        return ctxm.pearson_rho_wb_pdf(self)


# 11.1.7 Pearson’s rho distribution: cdf and sf (Winterbottom)

    def pearson_rho_wb_cdf(self, N, r, rho):
        '''Returns Pearson’s rho distribution: cdf and sf (Winterbottom)'''
        return ctxm.pearson_rho_wb_cdf(self, N, r, rho)


# 11.1.8 Pearson’s rho distribution: qtf and isf (Winterbottom)

    def pearson_rho_wb_qtf(self, l, r, n, rho):
        '''Returns Pearson’s rho distribution: qtf and isf (Winterbottom)'''
        return ctxm.pearson_rho_wb_qtf(self, l, r, n, rho)


# 11.1.9 Pearson’s rho distribution: confidence limit for 𝜌 (Winterbottom)

    def pearson_rho_wb_cl(self, l, r, N, x):
        '''Returns Pearson’s rho distribution:
        confidence limit for 𝜌 (Winterbottom)'''
        return ctxm.Rhodisx_W(self, l, r, N, x)


# 11.1.10 Singly noncentral t distribution: pdf (Broda)

    def student_t_nc_broda_pdf(self, x, n, delta):
        '''Returns Pearson’s rho distribution: qtf and isf (Winterbottom)'''
        return ctxm.student_t_nc_broda_pdf(self, x, n, delta)


# 11.1.11 Singly noncentral t distribution: cdf, sf (Broda)

    def student_t_nc_broda_cdf(self, x, n, delta):
        '''Returns the singly noncentral t distribution: cdf, sf (Broda)'''
        return ctxm.student_t_nc_broda_cdf(self, x, n, delta)


# 11.1.12 Singly noncentral t distribution: qtf, isf (Harley)

    def student_t_nc_harley_qtf(self, alpha, df, delta):
        '''Returns the singly noncentral t distribution: qtf, isf (Harley)'''
        return ctxm.student_t_nc_harley_qtf(self, alpha, df, delta)


# 11.1.13 Singly noncentral t distribution: confidence limit for 𝛿 (Akahira)

    def student_t_nc_akahira_cl(self, IsGLM, Df2, t, beta):
        '''Returns the singly noncentral t distribution:
        confidence limit for 𝛿 (Akahira)'''
        return ctxm.student_t_nc_akahira_cl(self, IsGLM, Df2, t, beta)


# 11.1.14 Doubly noncentral t distribution: cdf, sf (Broda)

    def student_t_nc2_broda_cdf(self, alpha, n, delta, theta):
        '''Returns the doubly noncentral t distribution: cdf, sf (Broda)'''
        return ctxm.student_t_nc2_broda_cdf(self, alpha, n, delta, theta)


# 11.1.15 Doubly noncentral t distribution: qtf, isf (Broda)

    def student_t_nc2_broda_qtf(self, x, n, delta, theta):
        '''Returns the doubly noncentral t distribution: qtf, isf (Broda)'''
        return ctxm.student_t_nc2_broda_qtf(self, x, n, delta, theta)


# 11.1.16 Spearman’s rho distribution, first 8 cumulants

    def spearman_mu8(self, x, n, lambda1):
        '''Returns Spearman’s rho distribution, first 8 cumulants'''
        return ctxm.spearman_mu8(self, x, n, lambda1)


# 11.1.17 Mann-Whitney U distribution: general alternatives specified by rank
    # order probabilities, first 4 moments

    def mannwhitney_nc_mu4(self, x, n, lambda1):
        '''Returns Mann-Whitney U distribution: general alternatives specified
        by rank order probabilities, first 4 moments'''
        return ctxm.mannwhitney_nc_mu4(self, x, n, lambda1)


# 11.1.18 First 4 moments of Kendalls 𝜏 in the general case

    def kendall_tau_nc_mu4(self, x, n, lambda1):
        '''Returns the First 4 moments of Kendalls 𝜏 in the general case'''
        return ctxm.kendall_tau_nc_mu4(self, x, n, lambda1)


# %%%  11.2 Approximations based on the chi-squared distribution


# 11.2.1 Non-Central chi-squared distribution: cdf, sf (Patnaik)

    def chi_squared_nc_mu2_cdf(self, x, n, lambda1):
        '''Returns the Non-Central chi-squared distribution:
        cdf, sf (Patnaik)'''
        return ctxm.chi_squared_nc_mu2_cdf(self, x, n, lambda1)


# 11.2.2 Non-Central chi-squared distribution: qtf, isf (Patnaik)

    def chi_squared_nc_mu2_qtf(self, n, lambda1, LeftTail, RightTail):
        '''Returns the Non-Central chi-squared distribution:
        qtf, isf (Patnaik)'''
        return ctxm.chi_squared_nc_mu2_qtf(self, n, lambda1, LeftTail,
                                           RightTail)


# 11.2.3 Non-Central chi-squared distribution:
    # confidence limit for 𝜆 (Winterbottom)

    def chi_squared_nc_wb_cl(self, F, alpha, Beta):
        '''Returns the Non-Central chi-squared distribution:
        confidence limit for 𝜆 (Winterbottom)'''
        return ctxm.chi_squared_nc_wb_cl(self, F, alpha, Beta)


# 11.2.4 Roy’s largest root 𝜃 distribution: pdf (Chiani)

    def roy_chiani_pdf(self, t1, p, n1, n2):
        '''Returns Roy’s largest root 𝜃 distribution: pdf (Chiani)'''
        return ctxm.roy_chiani_pdf(self, t1, p, n1, n2)


# 11.2.5 Roy’s largest root distribution: cdf and sf (Chiani)

    def roy_chiani_cdf(self, t1, p, n1, n2):
        '''Returns Roy’s largest root distribution: cdf and sf (Chiani)'''
        return ctxm.roy_chiani_cdf(self, t1, p, n1, n2)


# 11.2.6 Roy’s largest root distribution: qtf and isf (Chiani)

    def roy_chiani_qtf(self, LeftTail, p, n1, n2):
        '''Returns Roy’s largest root distribution: qtf and isf (Chiani)'''
        return ctxm.roy_chiani_qtf(self, LeftTail, p, n1, n2)


# %%%  11.3 Approximations based on the central F or beta distribution

# 11.3.1 Dunn-Šidák percentage points

    def dunn_sidak_qtf(self, LeftTail, RightTail, f1):
        '''Returns Dunn-Šidák percentage points'''
        return ctxm.dunn_sidak_qtf(self, LeftTail, RightTail, f1)


# 11.3.2 Singly non-central Fisher F distribution: cdf, sf (Patnaik)

    def fisher_f_nc_mu2_cdf(self, X, f1, f2, L=0, IsGLM=True):
        '''Returns the singly non-central Fisher F distribution:
        cdf, sf (Patnaik)'''
        return ctxm.fisher_f_nc_mu2_cdf(self, X, f1, f2, L, IsGLM)


# 11.3.3 Singly non-central F distribution: qtf, isf (Patnaik)

    def fisher_f_nc_mu2_qtf(self, LeftTail, f1, f2, L=0, IsGLM=True):
        '''Returns the singly non-central Fisher F distribution:
        qtf, isf (Patnaik)'''
        return ctxm.fisher_f_nc_mu2_qtf(self, LeftTail, f1, f2, L, IsGLM)


# 11.3.4 Singly non-central F: confidence interval for the noncentrality
    # parameter 𝜆

    def fisher_f_nc_cl_(self, f1, f2,  X, l1, l2, LeftTail, RightTail):
        '''Returns the singly non-central Fisher F distribution:
        confidence interval for the noncentrality parameter 𝜆'''
        return ctxm.fisher_f_nc_cl_(self, f1, f2,  X, l1, l2, LeftTail,
                                    RightTail)


# 11.3.5 Doubly non-central F distribution: cdf, sf (Patnaik)

    def fisher_f_nc2_mu2_cdf(self, X, f1, f2,  l1, l2):
        '''Returns the doubly non-central Fisher F distribution:
        cdf, sf (Patnaik)'''
        return ctxm.fisher_f_nc2_mu2_cdf(self, X, f1, f2,  l1, l2)


# 11.3.6 Doubly non-central F distribution: qtf, isf (Patnaik)

    def fisher_f_nc2_mu2_qtf(self, LeftTail, f1, f2, l1, l2):
        '''Returns the doubly non-central Fisher F distribution:
        qtf, isf (Patnaik)'''
        return ctxm.fisher_f_nc2_mu2_qtf(self, LeftTail, f1, f2, l1, l2)


# 11.3.7 Fisher 𝑅2 distribution: cdf, sf (Lee and Gurland)

    def fisher_r2_lee_cdf(self, r2, p, N, Rho2):
        '''Returns the Fisher 𝑅2 distribution: cdf, sf (Lee and Gurland)'''
        return ctxm.fisher_r2_lee_cdf(self, r2, p, N, Rho2)


# 11.3.8 Fisher 𝑅2 distribution: qtf, isf (Lee and Gurland)

    def fisher_r2_lee_qtf(self, L, p, N, rho2):
        '''Returns the Fisher 𝑅2 distribution: qtf, isf (Lee and Gurland)'''
        return ctxm.fisher_r2_lee_qtf(self, L, p, N, rho2)


# 11.3.9 Fisher 𝑅2 distribution: confidence limit for rho^2

    def fisher_r2_lee_cl(self, alpha, beta, p, N):
        '''Returns the Fisher 𝑅2 distribution: confidence limit for rho^2'''
        return ctxm.fisher_r2_lee_cl(self, alpha, beta, p, N)


# 11.3.10 Central Wilks’ Lambda distribution: cdf, sf (Rao)

    def wilks_lambda_rao_cdf(self, x, p, f1, f2):
        '''Returns Central Wilks’ Lambda: cdf, sf (Rao)'''
        return ctxm.wilks_lambda_rao_cdf(self, x, p, f1, f2)

    def wilks_lambda_bp_cdf(self, x, p, f1, f2):
        '''Returns Central Wilks’ Lambda: cdf, sf (Box-Davis cdf)'''
        return ctxm.wilks_lambda_bp_cdf(self, x, p, f1, f2)

    def wilks_lambda_bp_pdf(self, x, p, f1, f2):
        '''Returns Central Wilks’ Lambda: cdf, sf (Box-Davis pdf)'''
        return ctxm.wilks_lambda_bp_pdf(self, x, p, f1, f2)


# 11.3.11 Central Wilks’ Lambda distribution: qtf, isf (Rao)

    def wilks_lambda_rao_qtf(self, LeftTail, Righttail, p, f1, f2):
        '''Returns Central Wilks’ Lambda: cdf, sf (Box-Davis pdf)'''
        return ctxm.wilks_lambda_rao_qtf(self, LeftTail, Righttail, p, f1, f2)

    def wilks_lambda_bp_qtf(self, LeftTail, Righttail, p, f1, f2):
        '''Returns Central Wilks’ Lambda: qtf (Box-Davis pdf)'''
        return ctxm.wilks_lambda_bp_qtf(self, LeftTail, Righttail, p, f1, f2)


# 11.3.12 Central Hotelling’s 𝑇2 distribution: cdf, sf (Pillai and Young)

    def hotelling_t2_mu3_cdf(self, p, m, n, x):
        '''Returns the Central Hotelling’s 𝑇2 distribution:
        cdf, sf (Pillai and Young)'''
        return ctxm.hotelling_t2_mu3_cdf(self, p, m, n, x)


# 11.3.13 Central Hotelling’s 𝑇2 distribution: qtf, isf (Pillai and Young)

    def hotelling_t2_mu3_qtf(self, p, m, n, LeftTail, Righttail):
        '''Returns the Central Hotelling’s 𝑇2 distribution:
        qtf, isf (Pillai and Young)'''
        return ctxm.hotelling_t2_mu3_qtf(self, p, m, n, LeftTail, Righttail)


# 11.3.14 Central Pillai’s 𝑉 distribution: cdf, sf (Ginzberg)

    def pillai_v_mu3_cdf(self, p, N1, n2, x):
        '''Returns the Central Pillai’s 𝑉 distribution:
        cdf, sf (Ginzberg)'''
        return ctxm.pillai_v_mu3_cdf(self, p, N1, n2, x)


# 11.3.15 Central Pillai’s 𝑉 distribution: qtf, isf (Ginzberg)

    def pillai_v_mu3_qtf(self, p, n1, n2, LeftTail, Righttail):
        '''Returns the Central Pillai’s 𝑉 distribution:
        qtf, isf (Ginzberg)'''
        return ctxm.pillai_v_mu3_qtf(self, p, n1, n2, LeftTail, Righttail)


# 11.3.16 Product of independent beta variables: cdf, sf (Nagarsenker)

    def beta_product_mu3_pdf(self, x, p, b, c):
        '''Returns the distribution of the Product of independent beta
        variables: pdf (Nagarsenker)'''
        return ctxm.beta_product_mu3_pdf(self, x, p, b, c)

    def beta_product_mu3_cdf(self, x, p, b, c):
        '''Returns the distribution of the Product of independent beta
        variables: cdf, sf (Nagarsenker)'''
        return ctxm.beta_product_mu3_cdf(self, x, p, b, c)


# 11.3.17 Product of independent beta variables: qtf, isf (Nagarsenker)

    def beta_product_mu3_qtf(self, LeftTail, RightTail, p, b, c):
        '''Returns the distribution of the Product of independent beta
        variables: cdf, sf (Nagarsenker)'''
        return ctxm.beta_product_mu3_qtf(self,  LeftTail, RightTail, p, b, c)


# %%%  11.4 Approximations based on the noncentral chi-squared distribution


# 11.4.1 Non-central Wilks’ Lambda (GLM): cdf and sf (Fujikoshi)

    def wilks_lambda_glm_chi2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Non-central Wilks’ Lambda (GLM):
        cdf and sf (Fujikoshi)'''
        return ctxm.wilks_lambda_glm_chi2_cdf(self, p, q, n, x, omega)


# 11.4.2 Non-central Wilks’ Lambda (independence): cdf and sf (Lee)

    def wilks_lambda_ind_chi2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Non-central Wilks’ Lambda
        (independence): cdf and sf (Lee)'''
        return ctxm.wilks_lambda_ind_chi2_cdf(self, p, q, n, x, omega)


# 11.4.3 Non-central Pillai’s V (GLM): cdf and sf Fujikoshi

    def pillai_v_glm_chi2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Pillai’s V (GLM):
        cdf and sf (Fujikoshi)'''
        return ctxm.pillai_v_glm_chi2_cdf(self, p, q, n, x, omega)


# 11.4.4 Non-central Pillai’s V (independence): cdf and sf (Lee)

    def pillai_v_ind_chi2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Pillai’s V (independence):
        cdf and sf (Lee)'''
        return ctxm.pillai_v_ind_chi2_cdf(self, p, q, n, x, omega)


# 11.4.5 Non-central Hotelling'S 𝑇2 (GLM): cdf and sf (Fujikoshi)

    def hotelling_t2_glm_chi2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Hotelling's 𝑇2 (GLM):
        cdf and sf (Fujikoshi)'''
        return ctxm.hotelling_t2_glm_chi2_cdf(self, p, q, n, x, omega)


# 11.4.6 Non-central Hotelling's 𝑇2 (independence): cdf and sf (Lee)

    def hotelling_t2_ind_chi2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Hotelling's 𝑇2 (independence):
        cdf and sf (Lee)'''
        return ctxm.hotelling_t2_ind_chi2_cdf(self, p, q, n, x, omega)


# %%%  11.5 Approximations based on the noncentral F or beta distribution


# 11.5.1 Multiple correlation coefficient (Lee and Gurland)

    def fisher_r2_lee_mu3_cdf(self, r2, f1, f2, Rho2):
        '''Returns the distribution of Multiple correlation coefficient
        (Lee and Gurland)'''
        return ctxm.fisher_r2_lee_mu3_cdf(self, r2, f1, f2, Rho2)


# 11.5.2 Noncentral Wilks’ Lambda under the GLM or independence alternative

    def wilks_lambda_glm_mu2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Noncentral Wilks’ Lambda under the GLM
        or independence alternative'''
        return ctxm.wilks_lambda_glm_mu2_cdf(self, p, q, n, x, omega)

    def wilks_lambda_ind_mu2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Noncentral Wilks’ Lambda under the GLM
        or independence alternative'''
        return ctxm.wilks_lambda_ind_mu2_cdf(self, p, q, n, x, omega)


# 11.5.4 Noncentral Pillai’s V under the GLM or independence alternative

    def pillai_v_glm_mu2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Noncentral Pillai’s V under the GLM
        or independence alternative'''
        return ctxm.pillai_v_glm_mu2_cdf(self, p, q, n, x, omega)

    def pillai_v_ind_mu2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Noncentral Pillai’s V under the GLM
        or independence alternative'''
        return ctxm.pillai_v_ind_mu2_cdf(self, p, q, n, x, omega)


# 11.5.3 Noncentral Hotelling’s T under the GLM or independence alternative

    def hotelling_t2_glm_mu2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Noncentral Hotelling’s T under the GLM
        or independence alternative'''
        return ctxm.hotelling_t2_glm_mu2_cdf(self, p, q, n, x, omega)

    def hotelling_t2_ind_mu2_cdf(self, p, q, n, x, omega):
        '''Returns the distribution of Noncentral Hotelling’s T under the GLM
        or independence alternative'''
        return ctxm.hotelling_t2_ind_mu2_cdf(self, p, q, n, x, omega)


# 11.5.5 Noncentral Roy’s largest root under the GLM or independence
    # alternative

    def roy_glm_mu2_cdf(self, ctx, IsRho, Model, p, m, n, x, omega):
        '''Returns the distribution of Noncentral Roy’s largest root under
        the GLM or independence alternative'''
        return ctxm.roy_glm_mu2_cdf(self, IsRho, Model, p, m, n, x, omega)


# %%% 11.6 Approximations based on hypergeometric functions of scalar argument


# 11.6.1 Hypergeometric function 1𝐹1 for matrix argument
    # (Butler’s approximation)

    def hypergeom_matrix_1f1_butler(self, r2, f1, f2, Rho2):
        '''Returns the Hypergeometric function 1𝐹1 for matrix argument
        (Butler’s approximation)'''
        return ctxm.hypergeom_matrix_1f1_butler(self, r2, f1, f2, Rho2)


# 11.6.3 Hypergeometric function 2𝐹1 for matrix argument
    # (Butler’s approximation)

    def hypergeom_matrix_2f1_butler(self, a, b, c, x):
        '''Returns the Hypergeometric function 2𝐹1 for matrix argument
        (Butler’s approximation)'''
        return ctxm.hypergeom_matrix_2f1_butler(self, a, b, c, x)

