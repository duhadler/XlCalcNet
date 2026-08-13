
#include "stdint.h"

typedef void* XRealPtr;
typedef void* XCplxPtr;

typedef void* XStatePtr;

typedef void(*XRealFuncPtr) (void*, void*);
typedef void(*XAnyFuncPtr2) (const void*,const  void*);
typedef void(*XAnyFuncPtr3) (const void*,const  void*,const  void*);




////*********************** Boost/CppOptLib **********************************
//
//
//void LibXReal_LbfgsSolver(XRealFuncPtr f1, XRealFuncPtr f2, XStatePtr matX_, XStatePtr matGrad_, XStatePtr xPtr);
//
//void LibXReal_BfgsSolver(XRealFuncPtr f1, XRealFuncPtr f2, XStatePtr matX_, XStatePtr matGrad_, XStatePtr xPtr);
//
//
//
//void LibXReal_GradientDescentSolver(XRealFuncPtr f1, XRealFuncPtr f2, XStatePtr matX_, XStatePtr matGrad_, XStatePtr xPtr);
//
//void LibXReal_ConjugatedGradientDescentSolver(XRealFuncPtr f1, XRealFuncPtr f2, XStatePtr matX_, XStatePtr matGrad_, XStatePtr xPtr);
//
//


//*********************** Boost Odeint **********************************

void LibXReal_Const_RungeKutta4(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt);

void LibXReal_Const_RungeKuttaCashKarp54(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt);

void LibXReal_Const_RungeKuttaDopri5(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt);

void LibXReal_Const_RungeKuttaFehlberg78(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt);

void LibXReal_Const_AdamsBashforthMoulton(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt);


void LibXReal_Adaptive_RungeKuttaDopri5(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel);

void LibXReal_Adaptive_RungeKuttaCashKarp54(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel);

void LibXReal_Adaptive_RungeKuttaFehlberg78(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel);

void LibXReal_Adaptive_BulirschStoer(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel);


void LibXReal_DenseOutput_Dopri5(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel);

void LibXReal_DenseOutput_BulirschStoer(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel);






//*********************** Extra **********************************




void LibXReal_Pi(long double* res);

void LibXReal_E(long double* res);



void LibXReal_ShowExtNet(char* cstr, const long double* d);




//*********************** Boost Numerical Calculus, extended precision **********************************


void LibXReal_BracketRoot(long double* res1, long double* res2, int* iter, XRealFuncPtr f1, long double* guess, long double* factor, bool is_rising, int get_digits, unsigned int maxit);

void LibXReal_NewtonRaphson(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit);

void LibXReal_Halley(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit);

void LibXReal_Schroder(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit);

void LibXReal_Brent_Minimum(long double* res, long double* resFx, int* iter, XRealFuncPtr f1, long double* bracket_min, long double* bracket_max, int bits, unsigned int maxit);



void LibXReal_Trapezoidal(long double* res1, long double* res2, long double* res3, XRealFuncPtr f1, long double* a, long double* b);

void LibXReal_GaussLegendre(long double* res1, long double* res3, XRealFuncPtr f1, long double* a, long double* b);

void LibXReal_GaussKronrod(long double* res1, long double* res2, long double* res3, XRealFuncPtr f1, long double* a, long double* b);

void LibXReal_TanhSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1, long double* a, long double* b);

void LibXReal_SinhSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1);

void LibXReal_ExpSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1);

void LibXReal_Ooura_Cos(long double* res1, long double* res2, XRealFuncPtr f1);

void LibXReal_Ooura_Sin(long double* res1, long double* res2, XRealFuncPtr f1);





//*********************** Boost Distributions, extended precision **********************************


void LibXReal_ArcsineDist(long Target, long double* res, long double* xqp, long double* a, long double* b);

void LibXReal_BernoulliDist(long Target, long double* res, long double* xqp, long double* p);

void LibXReal_BetaDist(long Target, long double* res, long double* xqp, long double* a, long double* b);

void LibXReal_BinomialDist(long Target, long double* res, long double* xqp, long double* n, long double* p);

void LibXReal_CauchyDist(long Target, long double* res, long double* x, long double* location, long double* scale);

void LibXReal_Chi2Dist(long Target, long double* res, long double* xqp, long double* nu);

void LibXReal_ExponentialDist(long Target, long double* res, long double* xqp, long double* lambda);

void LibXReal_ExtremeValueDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

void LibXReal_FisherFDist(long Target, long double* res, long double* xqp, long double* mu, long double* nu);

void LibXReal_GammaDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale);

void LibXReal_GeometricDist(long Target, long double* res, long double* xqp, long double* p);

void LibXReal_HypergeometricDist(long Target, long double* res, long double* x, uint64_t r, uint64_t n, uint64_t N);

void LibXReal_InverseChi2Dist(long Target, long double* res, long double* xqp, long double* df, long double* scale);

void LibXReal_InverseGammaDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale);

void LibXReal_InverseGaussianDist(long Target, long double* res, long double* xqp, long double* mean_, long double* scale);

void LibXReal_LaplaceDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

void LibXReal_LogisticDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

void LibXReal_LognormalDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

void LibXReal_NegBinomialDist(long Target, long double* res, long double* xqp, long double* n, long double* p);

void LibXReal_Chi2NCDist(long Target, long double* res, long double* xqp, long double* nu, long double* nc);

void LibXReal_StudentTNCDist(long Target, long double* res, long double* xqp, long double* nu, long double* delta);

void LibXReal_FisherNCDist(long Target, long double* res, long double* xqp, long double* mu, long double* nu, long double* nc);

void LibXReal_BetaNCDist(long Target, long double* res, long double* xqp, long double* a, long double* b, long double* nc);

void LibXReal_NormalDist(long Target, long double* res, long double* xqp, long double* mean_, long double* stdev);

void LibXReal_ParetoDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale);

void LibXReal_PoissonDist(long Target, long double* res, long double* xqp, long double* nu);

void LibXReal_RayleighDist(long Target, long double* res, long double* xqp, long double* nu);

void LibXReal_SkewNormalDist(long Target, long double* res, long double* xqp, long double* mean_, long double* scale, long double* shape);

void LibXReal_StudentTDist(long Target, long double* res, long double* xqp, long double* nu);

void LibXReal_TriangularDist(long Target, long double* res, long double* xqp, long double* lower, long double* mode_, long double* upper);

void LibXReal_WeibullDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale);

void LibXReal_UniformDist(long Target, long double* res, long double* xqp, long double* lower, long double* upper);




//*********************** New , extended precision **********************************



void LibXReal_Logaddexp(long double* res, const long double* a, const long double* b);


void LibXReal_HyperexponentialDist(long Target, long double* res, long double* xqp, XStatePtr l1, XStatePtr l2);

void LibXReal_KolmogorovSmirnovDist(long Target, long double* res, long double* xqp, long double* n);

void LibXReal_HoltsmarkDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

void LibXReal_LandauDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

void LibXReal_MapAiryDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

void LibXReal_Saspoint5Dist(long Target, long double* res, long double* xqp, long double* location, long double* scale);




//*********************** Boost Special functions , extended precision **********************************

void LibXReal_Ulp(long double* res, const long double* x);

void LibXReal_BernoulliB2n(long double* res, const int n);

void LibXReal_TangentT2n(long double* res, const int n);

void LibXReal_Sqrt1pm1(long double* res, const long double* x);


void LibXReal_SinPi(long double* res, const long double* x);

void LibXReal_CosPi(long double* res, const long double* x);

void LibXReal_TanPi(long double* res, const long double* x);

void LibXReal_CscPi(long double* res, const long double* x);

void LibXReal_SecPi(long double* res, const long double* x);

void LibXReal_CotPi(long double* res, const long double* x);


void LibXReal_SincPi(long double* res, const long double* x);

void LibXReal_SinhcPi(long double* res, const long double* x);

void LibXReal_Tgamma_(long double* res, const long double* x);

void LibXReal_Tgamma1pm1(long double* res, const long double* x);

void LibXReal_Digamma(long double* res, const long double* x);

void LibXReal_Lgamma_(long double* res, const long double* x);

void LibXReal_Trigamma(long double* res, const long double* x);

void LibXReal_Factorial(long double* res, const long double* x);

void LibXReal_DoubleFactorial(long double* res, const long double* x);

void LibXReal_Erf_(long double* res, const long double* x);

void LibXReal_Erfc_(long double* res, const long double* x);

void LibXReal_Erf_inv(long double* res, const long double* x);

void LibXReal_Erfc_inv(long double* res, const long double* x);

void LibXReal_AiryAi(long double* res, const long double* x);

void LibXReal_AiryBi(long double* res, const long double* x);

void LibXReal_AiryAiPrime(long double* res, const long double* x);

void LibXReal_AiryBiPrime(long double* res, const long double* x);

void LibXReal_Aizero(long double* res, const int n);

void LibXReal_Bizero(long double* res, const int n);

void LibXReal_Ellint_1_K(long double* res, const long double* x);

void LibXReal_Ellint_2_K(long double* res, const long double* x);

void LibXReal_Zeta(long double* res, const long double* x);

void LibXReal_Ei(long double* res, const long double* x);

void LibXReal_LambertW0(long double* res, const long double* x);

void LibXReal_LambertWm1(long double* res, const long double* x);

void LibXReal_LambertW0Prime(long double* res, const long double* x);

void LibXReal_LambertWm1Prime(long double* res, const long double* x);





void LibXReal_Agm(long double* res, const long double* a, const long double* b);


void LibXReal_Powm1(long double* res, const long double* a, const long double* b);

void LibXReal_TgammaRatio(long double* res, const long double* a, const long double* b);

void LibXReal_TgammaDeltaRatio(long double* res, const long double* a, const long double* b);

void LibXReal_Binomial(long double* res, const long double* n, const long double* k);

void LibXReal_RisingFactorial(long double* res, const long double* x, const long double* n);

void LibXReal_FallingFactorial(long double* res, const long double* x, const long double* n);

void LibXReal_BesselJ(long double* res, const long double* v, const long double* x);

void LibXReal_BesselY(long double* res, const long double* v, const long double* x);

void LibXReal_BesselI(long double* res, const long double* v, const long double* x);

void LibXReal_BesselK(long double* res, const long double* v, const long double* x);

void LibXReal_SphBessel(long double* res, const unsigned v, const long double* x);

void LibXReal_SphNeumann(long double* res, const unsigned v, const long double* x);

void LibXReal_BesselJPrime(long double* res, const long double* v, const long double* x);

void LibXReal_BesselYPrime(long double* res, const long double* v, const long double* x);

void LibXReal_BesselIPrime(long double* res, const long double* v, const long double* x);

void LibXReal_BesselKPrime(long double* res, const long double* v, const long double* x);

void LibXReal_SphBesselPrime(long double* res, const unsigned v, const long double* x);

void LibXReal_SphNeumannPrime(long double* res, const unsigned v, const long double* x);

void LibXReal_BesselJZero(long double* res, const long double* v, const int m);

void LibXReal_BesselYZero(long double* res, const long double* v, const int m);


void LibXReal_GammaP(long double* res, const long double* a, const long double* x);

void LibXReal_GammaQ(long double* res, const long double* a, const long double* x);

void LibXReal_TgammaLower(long double* res, const long double* a, const long double* x);

void LibXReal_TgammaUpper(long double* res, const long double* a, const long double* x);

void LibXReal_GammaPInv(long double* res, const long double* a, const long double* p);

void LibXReal_GammaQInv(long double* res, const long double* a, const long double* q);

void LibXReal_GammaPInva(long double* res, const long double* x, const long double* p);

void LibXReal_GammaQInva(long double* res, const long double* x, const long double* q);

void LibXReal_GammaPDerivative(long double* res, const long double* a, const long double* x);

void LibXReal_Beta(long double* res, const long double* a, const long double* b);


void LibXReal_LegendreP(long double* res, int n, const long double* x);

void LibXReal_LegendreQ(long double* res, int n, const long double* x);

void LibXReal_Laguerre(long double* res, int n, const long double* x);

void LibXReal_Hermite(long double* res, int n, const long double* x);

void LibXReal_ChebyshevT(long double* res, int n, const long double* x);

void LibXReal_ChebyshevU(long double* res, int n, const long double* x);

void LibXReal_Polygamma(long double* res, int n, const long double* x);

void LibXReal_EllintRC(long double* res, const long double* x, const long double* y);

void LibXReal_Ellint1F(long double* res, const long double* k, const long double* phi);

void LibXReal_Ellint2F(long double* res, const long double* k, const long double* phi);

void LibXReal_Ellint3K(long double* res, const long double* k, const long double* n);




void LibXReal_JacobiCD(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiCN(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiCS(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiDC(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiDN(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiDS(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiNC(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiND(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiNS(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiSC(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiSD(long double* res, const long double* k, const long double* u);

void LibXReal_JacobiSN(long double* res, const long double* k, const long double* u);


void LibXReal_expint(long double* res, const unsigned n, const long double* x);

void LibXReal_OwenT(long double* res, const long double* h, const long double* a);





void LibXReal_IBeta(long double* res, const long double* a, const long double* b, const long double* x);

void LibXReal_IBetac(long double* res, const long double* a, const long double* b, const long double* x);

void LibXReal_IBetaNonNormalized(long double* res, const long double* a, const long double* b, const long double* x);

void LibXReal_IBetacNonNormalized(long double* res, const long double* a, const long double* b, const long double* x);

void LibXReal_IBetaInv(long double* res, const long double* a, const long double* b, const long double* p);

void LibXReal_IBetacInv(long double* res, const long double* a, const long double* b, const long double* q);

void LibXReal_IBetaInva(long double* res, const long double* b, const long double* x, const long double* p);

void LibXReal_IBetacInva(long double* res, const long double* b, const long double* x, const long double* q);

void LibXReal_IBetaInvb(long double* res, const long double* a, const long double* x, const long double* p);

void LibXReal_IBetacInvb(long double* res, const long double* a, const long double* x, const long double* q);

void LibXReal_IBetaDerivative(long double* res, const long double* a, const long double* b, const long double* x);


void LibXReal_LegendrePM(long double* res, const int n, const int m, const long double* x);

void LibXReal_LaguerreM(long double* res, const int n, const int m, const long double* x);


void LibXReal_EllipticRF(long double* res, const long double* x, const long double* y, const long double* z);

void LibXReal_EllipticRD(long double* res, const long double* x, const long double* y, const long double* z);

void LibXReal_EllipticRG(long double* res, const long double* x, const long double* y, const long double* z);

void LibXReal_Ellint3F(long double* res, const long double* k, const long double* n, const long double* phi);


void LibXReal_Gegenbauer(long double* res, const int n, const long double* lambda, const long double* x);

void LibXReal_Jacobi(long double* res, const int n, const long double* alpha, const long double* beta, const long double* x);



void LibXReal_SphericalHarmonicR(long double* res, const int n, const int m, const long double* theta, const long double* phi);

void LibXReal_SphericalHarmonicI(long double* res, const int n, const int m, const long double* theta, const long double* phi);

void LibXReal_EllipticRJ(long double* res, const long double* x, const long double* y, const long double* z, const long double* p);



// Hypergeometric and Theta Functions



void LibXReal_Hypergeo0F1(long double* res, const long double* b, const long double* x);

void LibXReal_Hypergeo1F1(long double* res, const long double* a, const long double* b, const long double* x);

void LibXReal_Hypergeo1F1r(long double* res, const long double* a, const long double* b, const long double* x);

void LibXReal_LogHypergeo1F1(long double* res, const long double* a, const long double* b, const long double* x);



void LibXReal_JacobiTheta1(long double* res, const long double* x, const long double* q);

void LibXReal_JacobiTheta2(long double* res, const long double* x, const long double* q);

void LibXReal_JacobiTheta3(long double* res, const long double* x, const long double* q);

void LibXReal_JacobiTheta4(long double* res, const long double* x, const long double* q);





