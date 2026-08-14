//
//#include "mpNumC_Main_Boost.h"
//#include "BoostFReal.h"
//
//
//
//using namespace std;
//
//
//
//
////*********************** Numerical Calculus, double precision  **********************************
//
//
//
//
//void Lib_FReal_BracketRoot(double* res1, double* res2, int* iter, FRealFuncPtr f1, double guess, double factor, bool is_rising, int get_digits, unsigned int maxit)
//{
//    LibFReal_BracketRoot(res1, res2, iter, f1, guess, factor, is_rising, get_digits, maxit);
//}
//
//
//
//void Lib_FReal_NewtonRaphson(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
//{
//    LibFReal_NewtonRaphson(res, iter, f1, f2, guess, xmin, xmax, get_digits, maxit);
//}
//
//
//
//void Lib_FReal_Halley(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
//{
//    LibFReal_Halley(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
//}
//
//
//
//void Lib_FReal_Schroder(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
//{
//    LibFReal_Schroder(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
//}
//
//
//
//void Lib_FReal_Brent_Minimum(double* res, double* resFx, int* iter, FRealFuncPtr f1, double bracket_min, double bracket_max, int bits, unsigned int maxit)
//{
//    LibFReal_Brent_Minimum(res, resFx, iter, f1, bracket_min, bracket_max, bits, maxit);
//}
//
//
//
//
//void Lib_FReal_Trapezoidal(double* res1, double* res2, double* res3, FRealFuncPtr f1, double a, double b)
//{
//    LibFReal_Trapezoidal(res1, res2, res3, f1, a, b);
//}
//
//
//
//// 7, 15, 20, 25 and 30
//
//void Lib_FReal_GaussLegendre(double* res1, double* res3, FRealFuncPtr f1, double a, double b)
//{
//    LibFReal_GaussLegendre(res1, res3, f1, a, b);
//}
//
//
//
//
////15, 31, 41, 51 and 61
//
//void Lib_FReal_GaussKronrod(double* res1, double* res2, double* res3, FRealFuncPtr f1, double a, double b)
//{
//    LibFReal_GaussKronrod(res1, res2, res3, f1, a, b);
//}
//
//
//
//void Lib_FReal_TanhSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1, double a, double b)
//{
//    LibFReal_TanhSinh(res1, res2, res3, levels_, f1, a, b);
//}
//
//
//
//void Lib_FReal_SinhSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1)
//{
//    LibFReal_SinhSinh(res1, res2, res3, levels_, f1);
//}
//
//
//
//void Lib_FReal_ExpSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1)
//{
//    LibFReal_ExpSinh(res1, res2, res3, levels_, f1);
//}
//
//
//
//void Lib_FReal_Ooura_Cos(double* res1, double* res2, FRealFuncPtr f1)
//{
//    LibFReal_Ooura_Cos(res1, res2, f1);
//}
//
//
//
//void Lib_FReal_Ooura_Sin(double* res1, double* res2, FRealFuncPtr f1)
//{
//    LibFReal_Ooura_Sin(res1, res2, f1);
//}
//
//
//
//
//
////*********************** Distributions, double precision  **********************************
//
//
//void Lib_FReal_ArcsineDist(long Target, double* res, double xqp, double a, double b)
//{
//    LibFReal_ArcsineDist(Target, res, xqp, a, b);
//}
//
//
//void Lib_FReal_BernoulliDist(long Target, double* res, double xqp, double p)
//{
//    LibFReal_BernoulliDist(Target, res, xqp, p);
//}
//
//
//void Lib_FReal_BetaDist(long Target, double* res, double xqp, double a, double b)
//{
//    LibFReal_BetaDist(Target, res, xqp, a, b);
//}
//
//
//void Lib_FReal_BinomialDist(long Target, double* res, double xqp, double n, double p)
//{
//    LibFReal_BinomialDist(Target, res, xqp, n, p);
//}
//
//
//void Lib_FReal_CauchyDist(long Target, double* res, double xqp, double location, double scale)
//{
//    LibFReal_CauchyDist(Target, res, xqp, location, scale);
//}
//
//
//void Lib_FReal_Chi2Dist(long Target, double* res, double xqp, double nu)
//{
//    LibFReal_Chi2Dist(Target, res, xqp, nu);
//}
//
//void Lib_FReal_ExponentialDist(long Target, double* res, double xqp, double lambda)
//{
//    LibFReal_ExponentialDist(Target, res, xqp, lambda);
//}
//
//
//void Lib_FReal_ExtremeValueDist(long Target, double* res, double xqp, double location, double scale)
//{
//    LibFReal_ExtremeValueDist(Target, res, xqp, location, scale);
//}
//
//
//void Lib_FReal_FisherFDist(long Target, double* res, double xqp, double mu, double nu)
//{
//    LibFReal_FisherFDist(Target, res, xqp, mu, nu);
//}
//
//
//void Lib_FReal_GammaDist(long Target, double* res, double xqp, double shape, double scale)
//{
//    LibFReal_GammaDist(Target, res, xqp, shape, scale);
//}
//
//
//void Lib_FReal_GeometricDist(long Target, double* res, double xqp, double p)
//{
//    LibFReal_GeometricDist(Target, res, xqp, p);
//}
//
//
//void Lib_FReal_HypergeometricDist(long Target, double* res, double xqp, unsigned r, unsigned n, unsigned N)
//{
//    LibFReal_HypergeometricDist(Target, res, xqp, r, n, N);
//}
//
//
//void Lib_FReal_InverseChi2Dist(long Target, double* res, double xqp, double df, double scale)
//{
//    LibFReal_InverseChi2Dist(Target, res, xqp, df, scale);
//}
//
//
//
//void Lib_FReal_InverseGammaDist(long Target, double* res, double xqp, double shape, double scale)
//{
//    LibFReal_InverseGammaDist(Target, res, xqp, shape, scale);
//}
//
//
//void Lib_FReal_InverseGaussianDist(long Target, double* res, double xqp, double mean_, double scale)
//{
//    LibFReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
//}
//
//
//void Lib_FReal_LaplaceDist(long Target, double* res, double xqp, double location, double scale)
//{
//    LibFReal_LaplaceDist(Target, res, xqp, location, scale);
//}
//
//
//void Lib_FReal_LogisticDist(long Target, double* res, double xqp, double location, double scale)
//{
//    LibFReal_LogisticDist(Target, res, xqp, location, scale);
//}
//
//
//void Lib_FReal_LognormalDist(long Target, double* res, double xqp, double location, double scale)
//{
//    LibFReal_LognormalDist(Target, res, xqp, location, scale);
//}
//
//
//void Lib_FReal_NegBinomialDist(long Target, double* res, double xqp, double n, double p)
//{
//    LibFReal_NegBinomialDist(Target, res, xqp, n, p);
//}
//
//
//void Lib_FReal_Chi2NCDist(long Target, double* res, double xqp, double nu, double nc)
//{
//    LibFReal_Chi2NCDist(Target, res, xqp, nu, nc);
//}
//
//
//void Lib_FReal_StudentTNCDist(long Target, double* res, double xqp, double nu, double delta)
//{
//    LibFReal_StudentTNCDist(Target, res, xqp, nu, delta);
//}
//
//
//void Lib_FReal_FisherNCDist(long Target, double* res, double xqp, double mu, double nu, double nc)
//{
//    LibFReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
//}
//
//
//void Lib_FReal_BetaNCDist(long Target, double* res, double xqp, double a, double b, double nc)
//{
//    LibFReal_BetaNCDist(Target, res, xqp, a, b, nc);
//}
//
//
//void Lib_FReal_NormalDist(long Target, double* res, double xqp, double mean_, double stdev)
//{
//    LibFReal_NormalDist(Target, res, xqp, mean_, stdev);
//}
//
//
//void Lib_FReal_ParetoDist(long Target, double* res, double xqp, double shape, double scale)
//{
//    LibFReal_ParetoDist(Target, res, xqp, shape, scale);
//}
//
//
//void Lib_FReal_PoissonDist(long Target, double* res, double xqp, double nu)
//{
//    LibFReal_PoissonDist(Target, res, xqp, nu);
//}
//
//
//void Lib_FReal_RayleighDist(long Target, double* res, double xqp, double nu)
//{
//    LibFReal_RayleighDist(Target, res, xqp, nu);
//}
//
//
//void Lib_FReal_SkewNormalDist(long Target, double* res, double xqp, double mean_, double scale, double shape)
//{
//    LibFReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
//}
//
//
//void Lib_FReal_StudentTDist(long Target, double* res, double xqp, double nu)
//{
//    LibFReal_StudentTDist(Target, res, xqp, nu);
//}
//
//
//void Lib_FReal_TriangularDist(long Target, double* res, double xqp, double lower, double mode_, double upper)
//{
//    LibFReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
//}
//
//
//void Lib_FReal_WeibullDist(long Target, double* res, double xqp, double shape, double scale)
//{
//    LibFReal_WeibullDist(Target, res, xqp, shape, scale);
//}
//
//
//void Lib_FReal_UniformDist(long Target, double* res, double xqp, double lower, double upper)
//{
//    LibFReal_UniformDist(Target, res, xqp, lower, upper);
//}
//
//
//
//
//
//
//
//
//
//
//
////*********************** Boost Special functions, double precision **********************************
//
//
//
//void Lib_FReal_BernoulliB2n(double* res, const int n)
//{
//    LibFReal_BernoulliB2n(res, n);
//}
//
//
//
//void Lib_FReal_TangentT2n(double* res, const int n)
//{
//    LibFReal_TangentT2n(res, n);
//}
//
//
//
//void Lib_FReal_Sqrt1pm1(double* res, const double x)
//{
//    LibFReal_Sqrt1pm1(res, x);
//}
//
//
//
//void Lib_FReal_SinPi(double* res, const double x)
//{
//    LibFReal_SinPi(res, x);
//}
//
//
//
//void Lib_FReal_CosPi(double* res, const double x)
//{
//    LibFReal_CosPi(res, x);
//}
//
//
//
//void Lib_FReal_SincPi(double* res, const double x)
//{
//    LibFReal_SincPi(res, x);
//}
//
//
//
//void Lib_FReal_SinhcPi(double* res, const double x)
//{
//    LibFReal_SinhcPi(res, x);
//}
//
//
//
//void Lib_FReal_Tgamma_(double* res, const double x)
//{
//    LibFReal_Tgamma_(res, x);
//}
//
//
//void Lib_FReal_Tgamma1pm1(double* res, const double x)
//{
//    LibFReal_Tgamma1pm1(res, x);
//}
//
//
//
//void Lib_FReal_Lgamma_(double* res, const double x)
//{
//    LibFReal_Lgamma_(res, x);
//}
//
//
//
//void Lib_FReal_Digamma(double* res, const double x)
//{
//    LibFReal_Digamma(res, x);
//}
//
//
//
//void Lib_FReal_Trigamma(double* res, const double x)
//{
//    LibFReal_Trigamma(res, x);
//}
//
//
//
//void Lib_FReal_Factorial(double* res, const double x)
//{
//    LibFReal_Factorial(res, x);
//}
//
//
//
//void Lib_FReal_DoubleFactorial(double* res, const double x)
//{
//    LibFReal_DoubleFactorial(res, x);
//}
//
//
//
//
//
//void Lib_FReal_Erf_(double* res, const double x)
//{
//    LibFReal_Erf_(res, x);
//}
//
//
//
//void Lib_FReal_Erfc_(double* res, const double x)
//{
//    LibFReal_Erfc_(res, x);
//}
//
//
//
//void Lib_FReal_Erf_inv(double* res, const double x)
//{
//    LibFReal_Erf_inv(res, x);
//}
//
//
//
//void Lib_FReal_Erfc_inv(double* res, const double x)
//{
//    LibFReal_Erfc_inv(res, x);
//}
//
//
//
//void Lib_FReal_AiryAi(double* res, const double x)
//{
//    LibFReal_AiryAi(res, x);
//}
//
//
//
//void Lib_FReal_AiryBi(double* res, const double x)
//{
//    LibFReal_AiryBi(res, x);
//}
//
//
//
//void Lib_FReal_AiryAiPrime(double* res, const double x)
//{
//    LibFReal_AiryAiPrime(res, x);
//}
//
//
//
//void Lib_FReal_AiryBiPrime(double* res, const double x)
//{
//    LibFReal_AiryBiPrime(res, x);
//}
//
//
//
//void Lib_FReal_Aizero(double* res, const int n)
//{
//    LibFReal_Aizero(res, n);
//}
//
//
//
//void Lib_FReal_Bizero(double* res, const int n)
//{
//    LibFReal_Bizero(res, n);
//}
//
//
//
//void Lib_FReal_Ellint_1_K(double* res, const double x)
//{
//    LibFReal_Ellint_1_K(res, x);
//}
//
//
//
//void Lib_FReal_Ellint_2_K(double* res, const double x)
//{
//    LibFReal_Ellint_2_K(res, x);
//}
//
//
//
//void Lib_FReal_Zeta(double* res, const double x)
//{
//    LibFReal_Zeta(res, x);
//}
//
//
//
//void Lib_FReal_Ei(double* res, const double x)
//{
//    LibFReal_Ei(res, x);
//}
//
//
//
//void Lib_FReal_LambertW0(double* res, const double x)
//{
//    LibFReal_LambertW0(res, x);
//}
//
//
//void Lib_FReal_LambertWm1(double* res, const double x)
//{
//    LibFReal_LambertWm1(res, x);
//}
//
//
//
//void Lib_FReal_LambertW0Prime(double* res, const double x)
//{
//    LibFReal_LambertW0Prime(res, x);
//}
//
//
//void Lib_FReal_LambertWm1Prime(double* res, const double x)
//{
//    LibFReal_LambertWm1Prime(res, x);
//}
//
//
//
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//
//
//
//void Lib_FReal_Powm1(double* res, const double a, const double b)
//{
//    LibFReal_Powm1(res, a, b);
//}
//
//
//
//void Lib_FReal_TgammaRatio(double* res, const double a, const double b)
//{
//    LibFReal_TgammaRatio(res, a, b);
//}
//
//
//
//void Lib_FReal_TgammaDeltaRatio(double* res, const double a, const double b)
//{
//    LibFReal_TgammaDeltaRatio(res, a, b);
//}
//
//
//
//void Lib_FReal_Binomial(double* res, const double n, const double k)
//{
//    LibFReal_Binomial(res, n, k);
//}
//
//void Lib_FReal_RisingFactorial(double* res, const double x, const double n)
//{
//    LibFReal_RisingFactorial(res, x, n);
//}
//
//
//
//
//void Lib_FReal_FallingFactorial(double* res, const double x, const double n)
//{
//    LibFReal_FallingFactorial(res, x, n);
//}
//
//
//
//
//void Lib_FReal_BesselJ(double* res, const double v, const double x)
//{
//    LibFReal_BesselJ(res, v, x);
//}
//
//
//
//void Lib_FReal_BesselY(double* res, const double v, const double x)
//{
//    LibFReal_BesselY(res, v, x);
//}
//
//
//
//void Lib_FReal_BesselI(double* res, const double v, const double x)
//{
//    LibFReal_BesselI(res, v, x);
//}
//
//
//
//void Lib_FReal_BesselK(double* res, const double v, const double x)
//{
//    LibFReal_BesselK(res, v, x);
//}
//
//
//
//void Lib_FReal_SphBessel(double* res, const unsigned v, const double x)
//{
//    LibFReal_SphBessel(res, v, x);
//}
//
//
//
//void Lib_FReal_SphNeumann(double* res, const unsigned v, const double x)
//{
//    LibFReal_SphNeumann(res, v, x);
//}
//
//
//
//
//
//void Lib_FReal_BesselJPrime(double* res, const double v, const double x)
//{
//    LibFReal_BesselJPrime(res, v, x);
//}
//
//
//
//void Lib_FReal_BesselYPrime(double* res, const double v, const double x)
//{
//    LibFReal_BesselYPrime(res, v, x);
//}
//
//
//
//void Lib_FReal_BesselIPrime(double* res, const double v, const double x)
//{
//    LibFReal_BesselIPrime(res, v, x);
//}
//
//
//
//void Lib_FReal_BesselKPrime(double* res, const double v, const double x)
//{
//    LibFReal_BesselKPrime(res, v, x);
//}
//
//
//
//void Lib_FReal_SphBesselPrime(double* res, const unsigned v, const double x)
//{
//    LibFReal_SphBesselPrime(res, v, x);
//}
//
//
//
//void Lib_FReal_SphNeumannPrime(double* res, const unsigned v, const double x)
//{
//    LibFReal_SphNeumannPrime(res, v, x);
//}
//
//
//
//
//
//void Lib_FReal_BesselJZero(double* res, const double v, const int m)
//{
//    LibFReal_BesselJZero(res, v, m);
//}
//
//
//
//void Lib_FReal_BesselYZero(double* res, const double v, const int m)
//{
//    LibFReal_BesselYZero(res, v, m);
//}
//
//
//
//
//
//void Lib_FReal_GammaP(double* res, const double a, const double x)
//{
//    LibFReal_GammaP(res, a, x);
//}
//
//
//void Lib_FReal_GammaQ(double* res, const double a, const double x)
//{
//    LibFReal_GammaQ(res, a, x);
//}
//
//
//void Lib_FReal_TgammaLower(double* res, const double a, const double x)
//{
//    LibFReal_TgammaLower(res, a, x);
//}
//
//
//void Lib_FReal_TgammaUpper(double* res, const double a, const double x)
//{
//    LibFReal_TgammaUpper(res, a, x);
//}
//
//
//
//
//void Lib_FReal_GammaPInv(double* res, const double a, const double p)
//{
//    LibFReal_GammaPInv(res, a, p);
//}
//
//
//void Lib_FReal_GammaQInv(double* res, const double a, const double q)
//{
//    LibFReal_GammaQInv(res, a, q);
//}
//
//
//void Lib_FReal_GammaPInva(double* res, const double x, const double p)
//{
//    LibFReal_GammaPInva(res, x, p);
//}
//
//
//void Lib_FReal_GammaQInva(double* res, const double x, const double q)
//{
//    LibFReal_GammaQInva(res, x, q);
//}
//
//
//
//void Lib_FReal_GammaPDerivative(double* res, const double a, const double x)
//{
//    LibFReal_GammaPDerivative(res, a, x);
//}
//
//
//void Lib_FReal_Beta(double* res, const double a, const double b)
//{
//    LibFReal_Beta(res, a, b);
//}
//
//
//
//
//
//
//
//
//
//void Lib_FReal_LegendreP(double* res, int n, const double x)
//{
//    LibFReal_LegendreP(res, n, x);
//}
//
//
//
//void Lib_FReal_LegendreQ(double* res, int n, const double x)
//{
//    LibFReal_LegendreQ(res, n, x);
//}
//
//
//
//void Lib_FReal_Laguerre(double* res, int n, const double x)
//{
//    LibFReal_Laguerre(res, n, x);
//}
//
//
//
//void Lib_FReal_Hermite(double* res, int n, const double x)
//{
//    LibFReal_Hermite(res, n, x);
//}
//
//
//
//void Lib_FReal_ChebyshevT(double* res, int n, const double x)
//{
//    LibFReal_ChebyshevT(res, n, x);
//}
//
//
//void Lib_FReal_ChebyshevU(double* res, int n, const double x)
//{
//    LibFReal_ChebyshevU(res, n, x);
//}
//
//
//
//void Lib_FReal_Polygamma(double* res, int n, const double x)
//{
//    LibFReal_Polygamma(res, n, x);
//}
//
//
//
//
//
//void Lib_FReal_EllintRC(double* res, const double x, const double y)
//{
//    LibFReal_EllintRC(res, x, y);
//}
//
//
//void Lib_FReal_Ellint1F(double* res, const double k, const double phi)
//{
//    LibFReal_Ellint1F(res, k, phi);
//}
//
//
//void Lib_FReal_Ellint2F(double* res, const double k, const double phi)
//{
//    LibFReal_Ellint2F(res, k, phi);
//}
//
//
//void Lib_FReal_Ellint3K(double* res, const double k, const double n)
//{
//    LibFReal_Ellint3K(res, k, n);
//}
//
//
//
//
//void Lib_FReal_JacobiCD(double* res, const double k, const double u)
//{
//    LibFReal_JacobiCD(res, k, u);
//}
//
//
//void Lib_FReal_JacobiCN(double* res, const double k, const double u)
//{
//    LibFReal_JacobiCN(res, k, u);
//}
//
//
//void Lib_FReal_JacobiCS(double* res, const double k, const double u)
//{
//    LibFReal_JacobiCS(res, k, u);
//}
//
//
//void Lib_FReal_JacobiDC(double* res, const double k, const double u)
//{
//    LibFReal_JacobiDC(res, k, u);
//}
//
//
//void Lib_FReal_JacobiDN(double* res, const double k, const double u)
//{
//    LibFReal_JacobiDN(res, k, u);
//}
//
//
//void Lib_FReal_JacobiDS(double* res, const double k, const double u)
//{
//    LibFReal_JacobiDS(res, k, u);
//}
//
//
//void Lib_FReal_JacobiNC(double* res, const double k, const double u)
//{
//    LibFReal_JacobiNC(res, k, u);
//}
//
//
//void Lib_FReal_JacobiND(double* res, const double k, const double u)
//{
//    LibFReal_JacobiND(res, k, u);
//}
//
//
//void Lib_FReal_JacobiNS(double* res, const double k, const double u)
//{
//    LibFReal_JacobiNS(res, k, u);
//}
//
//
//void Lib_FReal_JacobiSC(double* res, const double k, const double u)
//{
//    LibFReal_JacobiSC(res, k, u);
//}
//
//
//void Lib_FReal_JacobiSD(double* res, const double k, const double u)
//{
//    LibFReal_JacobiSD(res, k, u);
//}
//
//
//void Lib_FReal_JacobiSN(double* res, const double k, const double u)
//{
//    LibFReal_JacobiSN(res, k, u);
//}
//
//
//
//void Lib_FReal_expint(double* res, const unsigned n, const double x)
//{
//    LibFReal_expint(res, n, x);
//}
//
//
//
//
//void Lib_FReal_OwenT(double* res, const double h, const double a)
//{
//    LibFReal_OwenT(res, h, a);
//}
//
//
//
//
//
//void Lib_FReal_IBeta(double* res, const double a, const double b, const double x)
//{
//    LibFReal_IBeta(res, a, b, x);
//}
//
//
//void Lib_FReal_IBetac(double* res, const double a, const double b, const double x)
//{
//    LibFReal_IBetac(res, a, b, x);
//}
//
//
//void Lib_FReal_IBetaNonNormalized(double* res, const double a, const double b, const double x)
//{
//    LibFReal_IBetaNonNormalized(res, a, b, x);
//}
//
//
//void Lib_FReal_IBetacNonNormalized(double* res, const double a, const double b, const double x)
//{
//    LibFReal_IBetacNonNormalized(res, a, b, x);
//}
//
//
//void Lib_FReal_IBetaInv(double* res, const double a, const double b, const double p)
//{
//    LibFReal_IBetaInv(res, a, b, p);
//}
//
//
//void Lib_FReal_IBetacInv(double* res, const double a, const double b, const double q)
//{
//    LibFReal_IBetacInv(res, a, b, q);
//}
//
//
//void Lib_FReal_IBetaInva(double* res, const double b, const double x, const double p)
//{
//    LibFReal_IBetaInva(res, b, x, p);
//}
//
//
//void Lib_FReal_IBetacInva(double* res, const double b, const double x, const double q)
//{
//    LibFReal_IBetacInva(res, b, x, q);
//}
//
//
//void Lib_FReal_IBetaInvb(double* res, const double a, const double x, const double p)
//{
//    LibFReal_IBetaInvb(res, a, x, p);
//}
//
//
//void Lib_FReal_IBetacInvb(double* res, const double a, const double x, const double q)
//{
//    LibFReal_IBetacInvb(res, a, x, q);
//}
//
//
//void Lib_FReal_IBetaDerivative(double* res, const double a, const double b, const double x)
//{
//    LibFReal_IBetaDerivative(res, a, b, x);
//}
//
//
//
//
//void Lib_FReal_LegendrePM(double* res, const int n, const int m, const double x)
//{
//    LibFReal_LegendrePM(res, n, m, x);
//}
//
//
//
//void Lib_FReal_LaguerreM(double* res, const int n, const int m, const double x)
//{
//    LibFReal_LaguerreM(res, n, m, x);
//}
//
//
//
//
//
//void Lib_FReal_EllipticRF(double* res, const double x, const double y, const double z)
//{
//    LibFReal_EllipticRF(res, x, y, z);
//}
//
//
//
//void Lib_FReal_EllipticRD(double* res, const double x, const double y, const double z)
//{
//    LibFReal_EllipticRD(res, x, y, z);
//}
//
//
//
//void Lib_FReal_Ellint3F(double* res, const double k, const double n, const double phi)
//{
//    LibFReal_Ellint3F(res, k, n, phi);
//}
//
//
//
//
//void Lib_FReal_SphericalHarmonicR(double* res, const int n, const int m, const double theta, const double phi)
//{
//    LibFReal_SphericalHarmonicR(res, n, m, theta, phi);
//}
//
//
//void Lib_FReal_SphericalHarmonicI(double* res, const int n, const int m, const double theta, const double phi)
//{
//    LibFReal_SphericalHarmonicI(res, n, m, theta, phi);
//}
//
//
//void Lib_FReal_EllipticRJ(double* res, const double x, const double y, const double z, const double p)
//{
//    LibFReal_EllipticRJ(res, x, y, z, p);
//}
//
//
//// Hypergeometric and Theta Functions
//
//
//
//
//void Lib_FReal_Hypergeo0F1(double* res, const double b, const double x)
//{
//    LibFReal_Hypergeo0F1(res, b, x);
//}
//
//
//
//void Lib_FReal_Hypergeo1F1(double* res, const double a, const double b, const double x)
//{
//    LibFReal_Hypergeo1F1(res, a, b, x);
//}
//
//
//
//void Lib_FReal_Hypergeo1F1r(double* res, const double a, const double b, const double x)
//{
//    LibFReal_Hypergeo1F1r(res, a, b, x);
//}
//
//
//
//void Lib_FReal_LogHypergeo1F1(double* res, const double a, const double b, const double x)
//{
//    LibFReal_LogHypergeo1F1(res, a, b, x);
//}
//
//
//
//
//
//void Lib_FReal_JacobiTheta1(double* res, const double x, const double q)
//{
//    LibFReal_JacobiTheta1(res, x, q);
//}
//
//
//void Lib_FReal_JacobiTheta2(double* res, const double x, const double q)
//{
//    LibFReal_JacobiTheta2(res, x, q);
//}
//
//
//void Lib_FReal_JacobiTheta3(double* res, const double x, const double q)
//{
//    LibFReal_JacobiTheta3(res, x, q);
//}
//
//
//void Lib_FReal_JacobiTheta4(double* res, const double x, const double q)
//{
//    LibFReal_JacobiTheta4(res, x, q);
//}
//
//
//
//
//
//
//
//
//
//
//
//
