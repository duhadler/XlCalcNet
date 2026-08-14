# -*- coding: utf-8 -*-
"""
@author: DH
"""


# %% 16 Base class for random variables with univariate distributions


class ctx_rv_base(object):
    r"""
    Basic text for a univariate distribution

    **References**

    1. Wikipedia contributors. *Probability density function. Wikipedia, the
    free encyclopedia*.
    https://en.wikipedia.org/wiki/Probability_density_function
    """

    __ctx = None

    __supportleft = None
    __supportright = None

    __rangeleft = None
    __rangeright = None

    __x = None
    __q = None

    __onemx = None
    __onemq = None

    __pdf_method = "auto"
    __cdf_method = "auto"

    def __init__(self):
        pass

    @property
    def ctx(self):
        return self.__ctx

    @property
    def supportleft(self):
        return self.__supportleft

    @property
    def supportright(self):
        return self.__supportright

    @property
    def rangeleft(self):
        return self.__rangeleft

    @property
    def rangeright(self):
        return self.__rangeright


    def support(self):
        r"""
        Returns the support domain of the distribution function as a tuple.

        **References**

        1. Wikipedia contributors. *Support (mathematics). Wikipedia, the free
        encyclopedia*.
        https://en.wikipedia.org/wiki/Support_(mathematics)
        """
        return self.__supportleft, self.__supportright


    def range(self):
        r"""
        Returns the range of the distribution function as a tuple.
        """
        return self.__rangeleft, self.__rangeright



    def x(self):
        return self.__x

    def onemx(self):
        return self.__onemx


    def q(self):
        return self.__q

    def onemq(self):
        return self.__onemq


    def pdf_method(self):
        return self.__pdf_method

    def cdf_method(self):
        return self.__cdf_method

    def set_supportleft(self, sleft):
        self.__supportleft = sleft

    def set_supportright(self, sright):
        self.__supportright = sright

    def set_rangeleft(self, rleft):
        self.__rangeleft = rleft

    def set_rangeright(self, rright):
        self.__rangeright = rright



    def set_x(self, x):
        self.__x = x

    def set_ctx(self, ctx_):
        self.__ctx = ctx_

    def set_pdf_method(self, method='default'):
        r"""
        Sets the algorithm used for the calculation of the pdf. The default is "auto",
        which will select the algorithm automatically. Choices which are always available are

        :"default": An automatic choice of algorithm.

        :"diff_cdf": Numerical differentiation of the cdf is used.

        :"fft": Numerical integration of the characteristic function (as inverse fourier transform) is used.

        :"cumulants": The asymptotic Cornish-Fisher expansion according to Lee and Lee (1991) is used. Only available if cumulants exist.

        :"luggannini": The saddlepoint approximation according to Luggannini and Rice (1980) is used. Only available if the cumulant generating function exists.

        For most distributions additional algorithms are available, which are listed in the documentation of the distribution class.


        **References**

        1. Wikipedia contributors. *Cumulative distribution function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Cumulative_distribution_function

        """
        self.__pdf_method = x

    def set_cdf_algorithm(self, x):
        r"""
        Sets the algorithm used for the calculation of the cdf. The default is "auto",
        which will select the algorithm automatically. Choices which are always available are

        :"auto": An automatic choice of algorithm

        :"quad_pdf": Numerical integration of the pdf is used

        :"gil_pelaez": Numerical integration of the characteristic function according to Gil-Pelaez (1949) is used

        :"cumulants": The asymptotic Cornish-Fisher expansion according to Lee and Lee (1991) is used. Only available if cumulants exist

        :"luggannini": The saddlepoint approximation according to Luggannini and Rice (1980) is used. Only available if the cumulant generating function exists

        For most distributions additional algorithms are available, which are listed in the documentation of the distribution class.


        **References**

        1. Wikipedia contributors. *Cumulative distribution function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Cumulative_distribution_function

        """
        self.__cdf_method = x

    def cdf(self, x):
        r"""
        Returns the cumulative distribution function.

        **References**

        1. Wikipedia contributors. *Cumulative distribution function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Cumulative_distribution_function
        """
        return None

    def logcdf(self, x):
        r"""
        Returns the natural logaritm of the cumulative distribution function.

        **References**

        1. Wikipedia contributors. *Cumulative distribution function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Cumulative_distribution_function
        """
        return self.ctx.log(self.cdf(self.ctx.t(x)))

    def sf(self, x):
        r"""
        Returns the survival function.

        **References**

        1. Wikipedia contributors. *Survival function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Survival_function#Parametric_survival_functions
        """
        return 1 - self.cdf(self.ctx.t(x))

    def logsf(self, x):
        r"""
        Returns the natural logaritm of the survival function.

        **References**

        1. Wikipedia contributors. *Survival function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Survival_function#Parametric_survival_functions
        """
        return self.ctx.log(self.sf(self.ctx.t(x)))

    def qtf(self, q):
        r"""
        Returns the percentage point function (qtf)

        **References**

        1. Wikipedia contributors. *Quantile function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Quantile_function
        """
        return None

    def isf(self, q):
        r"""
        Returns the inverse survival function (isf)

        **References**

        1. Wikipedia contributors. *Quantile function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Quantile_function
        """
        return self.qtf(1-self.ctx.t(q))

    def c_x(self, t):
        r"""
        Returns the characteristic function.

        **References**

        1. Wikipedia contributors. *Characteristic function (probability theory). Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Characteristic_function_(probability_theory)
        """
        return None   # integration via pdf

    def gil_pelaez_imag(self, t):
        r"""
        Returns the imaginary part of the Gil-Pelaez integral, which is used to
        calculated the probability density function (pdf) from the characteristic
        function.

        **References**

        1. Wikipedia contributors. *Probability mass function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_mass_function
        """
        phi = self.c_x(t)
        z = self.ctx.exp(-t*self.__x*self.ctx.j) * phi
        result = z.imag / t
        return result   # convenience function for Gil-Pelaez inversion, cdf

    def gil_pelaez_real(self, t):
        r"""
        Returns the real part of the Gil-Pelaez integral, which is used to
        calculated the cumulative distribution function (cdf) from the characteristic
        function.

        **References**

        1. Wikipedia contributors. *Probability mass function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_mass_function
        """
        phi = self.c_x(t)
        z = self.ctx.exp(-t*self.__x*self.ctx.j) * phi
        result = z.real
        return result   # convenience function for Gil-Pelaez inversion, pdf

    def gil_pelaez_cos(self, t):
        r"""
        Returns the cosine part of the Gil-Pelaez integral, which is used to
        calculated the cumulative distribution function (cdf) from the characteristic
        function.

        **References**

        1. Wikipedia contributors. *Probability mass function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_mass_function
        """
        phi = self.c_x(t)
        result = self.ctx.cos(-t*self.__x) * phi.imag/t
        return result  # convenience function for Gil-Pelaez inversion, cdf

    def gil_pelaez_sin(self, t):
        r"""
        '''Returns the sine part of the Gil-Pelaez integral, which is used to
        calculated the cumulative distribution function (cdf) from the characteristic
        function.

        **References**

        1. Wikipedia contributors. *Probability mass function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_mass_function
        """
        phi = self.c_x(t)
        result = self.ctx.sin(-t*self.__x) * phi.real/t
        return result  # convenience function for Gil-Pelaez inversion, cdf

    def m_x(self, t):
        r"""
        Returns the moment generating function.

        **References**

        1. Wikipedia contributors. *Moment-generating function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Moment-generating_function
        """
        return self.ctx.log(self.c_x(t*1j))

    def k_x(self, t):
        r"""
        Returns the cumulant generating function.

        **References**

        1. Wikipedia contributors. *Cumulant. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Cumulant#Definition
        """
        return self.ctx.log(self.m_x(t))

    def kderiv_x(self, t):
        r"""
        Returns the first k derivatives of the cumulant generating function

        **References**

        1. Wikipedia contributors. *Cumulant. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Cumulant#Definition
        """
        return None   # numerical deriative

    def saddleppoint(self, t):
        r"""
        Returns the solution to the saddlepoint equation

        **References**

        1. Wikipedia contributors. *Saddlepoint approximation method. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Saddlepoint_approximation_method
        2. Wikipedia contributors. *Cumulant. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Cumulant#Definition
        """
        return None  # numerical calculation with standard starter

    def moments(self, k):
        r"""
        Returns the moments of the distribution.

        **References**

        1. Wikipedia contributors. *Moment (mathematics). Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Moment_(mathematics)
        """
        return [None, None, None, None]  # numerical calculation via pdf

    def cumulants(self, k):
        r"""
        '''Returns the cumulants of the distribution.

        **References**

        1. Wikipedia contributors. *Cumulant. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Cumulant#Definition
        """
        return [None, None, None, None]  # from moments

    def mode(self):
        r"""
        Returns the mode of the distribution.

        **References**

        1. Wikipedia contributors. *Mode (statistics). Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Mode_(statistics)
        """
        return None

    def median(self):
        r"""
        '''Returns the median of the distribution.

        **References**

        1. Wikipedia contributors. *Median. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Median
        """
        return self.qtf(0.5)

    def mean(self):
        r"""
        Returns the mean of the distribution.

        **References**

        1. Wikipedia contributors. *Expected value. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Expected_value
        """
        cum = self.cumulants(4)
        return cum[0]

    def variance(self):
        r"""
        Returns the variance of the distribution.

        **References**

        1. Wikipedia contributors. *Variance. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Variance
        """
        cum = self.cumulants(2)
        return cum[1]

    def stdev(self):
        r"""
        '''Returns the standard deviation of the distribution.

        **References**

        1. Wikipedia contributors. *Standard deviation. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Standard_deviation
        """
        return self.ctx.sqrt(self.variance)

    def skewness(self):
        r"""
        Returns the skewness of the distribution.

        **References**

        1. Wikipedia contributors. *Skewness. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Skewness
        """
        cum = self.cumulants(4)
        return cum[2]/self.ctx.sqrt(cum[1]*cum[1]*cum[1])

    def kurtosis(self):
        r"""
        Returns the kurtosis of the distribution.

        **References**

        1. Wikipedia contributors. *Kurtosis. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Kurtosis
        """
        cum = self.cumulants(4)
        k22 = cum[1] * cum[1]
        return ((cum[3] + 3 * k22) / k22)

    def kurtosis_excess(self):
        r"""
        Returns the kurtosis excess of the distribution.


        **References**

        1. Wikipedia contributors. *Kurtosis. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Kurtosis
        """

        return self.kurtosis() - 3

    def rv(self, n):
        r"""
        '''Returns n pseudo random variates of the distribution.
        A pseudo random variate is calculated as

        **References**

        1. Wikipedia contributors. *Random variate. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Random_variate
        """
        return None


# %% 17 Base class for random variables with univariate continuous distribution
    #functions


class ctx_rv_cont(ctx_rv_base):
    r"""
    Basic text for a univariate continuous distribution

    **References**

    1. Wikipedia contributors. *Probability density function. Wikipedia, the
    free encyclopedia*.
    https://en.wikipedia.org/wiki/Probability_density_function

    parent:
    """
    __doc__ += ctx_rv_base.__doc__

    def __init__(self):
        pass

    def pdf(self, x):
        r"""
        Returns the probability density function.
        The probability density function is typically given in explicit from.
        However, it can also be calculated from other functions:

        **References**

        1. Wikipedia contributors. *Probability density function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_density_function
        """
        return None

    def logpdf(self, x):
        r"""
        Returns the natural logarithm of the probability density function.

        **References**

        1. Wikipedia contributors. *Probability density function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_density_function
        """
        return self.ctx.log(self.pdf(self.ctx.t(x)))



    def psf(self, x):
        r"""
        Returns the probability sparsity function (psf), which is the
        derivative of the percentage point function (qtf). The qtf is also
        known as the quantile function.

        **References**

        1. Wikipedia contributors. *Quantile function. Wikipedia, the free
        encyclopedia*.
        https://en.wikipedia.org/wiki/Quantile_function

        2. Wikipedia contributors. *Inverse functions and differentiation.
        Wikipedia, the free encyclopedia*.
        https://en.wikipedia.org/wiki/Inverse_functions_and_differentiation
        """
        return self.pdf(x) / self.sf(x)

    def hf(self, x):
        r"""
        Returns the hazard function.

        **References**

        1. Wikipedia contributors. *Hazard function and cumulative hazard
        function. Wikipedia, the free encyclopedia*.
        https://en.wikipedia.org/wiki/Survival_analysis#Hazard_function_and_cumulative_hazard_function

        2. Boost Math. *Hazard function*.
        https://www.boost.org/doc/libs/1_71_0/libs/math/doc/html/math_toolkit/dist_ref/nmp.html#math_toolkit.dist_ref.nmp.chf
        """
        return self.pdf(x) / self.sf(x)

    def chf(self, x):
        r"""
        Returns the cumulative hazard function.

        **References**

        1. Wikipedia contributors. *Hazard function and cumulative hazard
        function. Wikipedia, the free encyclopedia*.
        https://en.wikipedia.org/wiki/Survival_analysis#Hazard_function_and_cumulative_hazard_function

        2. Boost Math. *Hazard function*.
        https://www.boost.org/doc/libs/1_71_0/libs/math/doc/html/math_toolkit/dist_ref/nmp.html#math_toolkit.dist_ref.nmp.chf
        """
        return self.ctx.log(1 / self.sf(x))

    def entropy(self, x):
        r"""
        Returns the differential entropy.

        **References**

        1. Wikipedia contributors. *Definition of entropy and differential
        entropy. Wikipedia, the free encyclopedia*.
        https://en.wikipedia.org/wiki/Maximum_entropy_probability_distribution#Definition_of_entropy_and_differential_entropy
        """
        return None

    def nnlf(self, x):
        r"""
        Returns the negative loglikelihood function.

        **References**

        1. Wikipedia contributors. *Likelihood function. Wikipedia, the free
        encyclopedia*. https://en.wikipedia.org/wiki/Likelihood_function
        """
        return None


# %% 18 Base class for random variables with univariate discrete distribution functions


class ctx_rv_discrete(ctx_rv_base):
    __a = 0
    __b = 1

    def __init__(self, mu=0.0, sigma=1.0):
        pass

    def pmf(self, x):
        r"""
        Returns the probability mass function.

        **References**

        1. Wikipedia contributors. *Probability mass function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_mass_function
        """
        # return self.ctx.convert(1)
        return None

    def logpmf(self, x):
        r"""
        Returns the natural logarithm of the probability mass function.

        **References**

        1. Wikipedia contributors. *Probability mass function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_mass_function
        """
        return self.ctx.log(self.pdf(self.ctx.t(x)))

    def pgf(self, x):
        r"""
        Returns the probability generating function

        **References**

        1. Wikipedia contributors. *Probability-generating function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability-generating_function
        """
        return None

    def pmf_vector(self, x):
        r"""
        Returns a vector containing all values of the probability mass function.

        **References**

        1. Wikipedia contributors. *Probability mass function. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Probability_mass_function
        """
        return None

    def entropy(self, x):
        r"""
        Returns the entropy.


        **References**

        1. Wikipedia contributors. *Definition of entropy and differential entropy. Wikipedia, the free encyclopedia*. https://en.wikipedia.org/wiki/Maximum_entropy_probability_distribution#Definition_of_entropy_and_differential_entropy
        """
        return None






