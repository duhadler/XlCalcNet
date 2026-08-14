
#include "stdint.h"

typedef void* SRealPtr;
typedef void* SCplxPtr;

typedef void* SStatePtr;

//typedef float(*SRealFuncPtr) (float);

typedef void(*SRealFuncPtr) (void*, void*);

typedef void(*SAnyFuncPtr2) (const void*,const  void*);
typedef void(*SAnyFuncPtr3) (const void*,const  void*,const  void*);




//////*********************** Boost/CppOptLib **********************************
//
//
//void LibSReal_LbfgsSolver(SRealFuncPtr f1, SRealFuncPtr f2, SStatePtr matX_, SStatePtr matGrad_, SStatePtr xPtr);
//
//void LibSReal_BfgsSolver(SRealFuncPtr f1, SRealFuncPtr f2, SStatePtr matX_, SStatePtr matGrad_, SStatePtr xPtr);
//
//
//
//void LibSReal_GradientDescentSolver(SRealFuncPtr f1, SRealFuncPtr f2, SStatePtr matX_, SStatePtr matGrad_, SStatePtr xPtr);
//
//void LibSReal_ConjugatedGradientDescentSolver(SRealFuncPtr f1, SRealFuncPtr f2, SStatePtr matX_, SStatePtr matGrad_, SStatePtr xPtr);





//*********************** Boost Odeint **********************************

void LibSReal_Const_RungeKutta4(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt);

void LibSReal_Const_RungeKuttaCashKarp54(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt);

void LibSReal_Const_RungeKuttaDopri5(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt);

void LibSReal_Const_RungeKuttaFehlberg78(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt);

void LibSReal_Const_AdamsBashforthMoulton(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt);


void LibSReal_Adaptive_RungeKuttaDopri5(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel);

void LibSReal_Adaptive_RungeKuttaCashKarp54(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel);

void LibSReal_Adaptive_RungeKuttaFehlberg78(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel);

void LibSReal_Adaptive_BulirschStoer(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel);


void LibSReal_DenseOutput_Dopri5(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel);

void LibSReal_DenseOutput_BulirschStoer(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel);




//*********************** Boost Rootfinding, float precision **********************************


void LibSReal_BracketRoot(float* res1, float* res2, int* iter, SRealFuncPtr f1, float* guess, float* factor, bool is_rising, int get_digits, unsigned int maxit);

void LibSReal_NewtonRaphson(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit);

void LibSReal_Halley(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, SRealFuncPtr f3, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit);

void LibSReal_Schroder(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, SRealFuncPtr f3, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit);

void LibSReal_Brent_Minimum(float* res, float* resFx, int* iter, SRealFuncPtr f1, float* bracket_min, float* bracket_max, int bits, unsigned int maxit);



//*********************** Boost Numerical Integration, float precision **********************************




void LibSReal_Trapezoidal(float* res1, float* res2, float* res3, SRealFuncPtr f1, float* a, float* b);

void LibSReal_GaussLegendre(float* res1, float* res3, SRealFuncPtr f1, float* a, float* b);

void LibSReal_GaussKronrod(float* res1, float* res2, float* res3, SRealFuncPtr f1, float* a, float* b);

void LibSReal_TanhSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1, float* a, float* b);

void LibSReal_SinhSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1);

void LibSReal_ExpSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1);

void LibSReal_Ooura_Cos(float* res1, float* res2, SRealFuncPtr f1);

void LibSReal_Ooura_Sin(float* res1, float* res2, SRealFuncPtr f1);





//*********************** Boost Distributions, float precision **********************************


void LibSReal_ArcsineDist(long Target, float* res, float* xqp, float* a, float* b);

void LibSReal_BernoulliDist(long Target, float* res, float* xqp, float* p);

void LibSReal_BetaDist(long Target, float* res, float* xqp, float* a, float* b);

void LibSReal_BinomialDist(long Target, float* res, float* xqp, float* n, float* p);

void LibSReal_CauchyDist(long Target, float* res, float* xqp, float* location, float* scale);

void LibSReal_Chi2Dist(long Target, float* res, float* xqp, float* nu);

void LibSReal_ExponentialDist(long Target, float* res, float* xqp, float* lambda);

void LibSReal_ExtremeValueDist(long Target, float* res, float* xqp, float* location, float* scale);

void LibSReal_FisherFDist(long Target, float* res, float* xqp, float* mu, float* nu);

void LibSReal_GammaDist(long Target, float* res, float* xqp, float* shape, float* scale);

void LibSReal_GeometricDist(long Target, float* res, float* xqp, float* p);

void LibSReal_HypergeometricDist(long Target, float* res, float* xqp, uint64_t r, uint64_t n, uint64_t N);

void LibSReal_InverseChi2Dist(long Target, float* res, float* xqp, float* df, float* scale);

void LibSReal_InverseGammaDist(long Target, float* res, float* xqp, float* shape, float* scale);

void LibSReal_InverseGaussianDist(long Target, float* res, float* xqp, float* mean_, float* scale);

void LibSReal_LaplaceDist(long Target, float* res, float* xqp, float* location, float* scale);

void LibSReal_LogisticDist(long Target, float* res, float* xqp, float* location, float* scale);

void LibSReal_LognormalDist(long Target, float* res, float* xqp, float* location, float* scale);

void LibSReal_NegBinomialDist(long Target, float* res, float* xqp, float* n, float* p);

void LibSReal_Chi2NCDist(long Target, float* res, float* xqp, float* nu, float* nc);

void LibSReal_StudentTNCDist(long Target, float* res, float* xqp, float* nu, float* delta);

void LibSReal_FisherNCDist(long Target, float* res, float* xqp, float* mu, float* nu, float* nc);

void LibSReal_BetaNCDist(long Target, float* res, float* xqp, float* a, float* b, float* nc);

void LibSReal_NormalDist(long Target, float* res, float* xqp, float* mean_, float* stdev);

void LibSReal_ParetoDist(long Target, float* res, float* xqp, float* shape, float* scale);

void LibSReal_PoissonDist(long Target, float* res, float* xqp, float* nu);

void LibSReal_RayleighDist(long Target, float* res, float* xqp, float* nu);

void LibSReal_SkewNormalDist(long Target, float* res, float* xqp, float* mean_, float* scale, float* shape);

void LibSReal_StudentTDist(long Target, float* res, float* xqp, float* nu);

void LibSReal_TriangularDist(long Target, float* res, float* xqp, float* lower, float* mode_, float* upper);

void LibSReal_WeibullDist(long Target, float* res, float* xqp, float* shape, float* scale);

void LibSReal_UniformDist(long Target, float* res, float* xqp, float* lower, float* upper);




//*********************** New , float precision **********************************



void LibSReal_Logaddexp(float* res, const float* a, const float* b);


void LibSReal_HyperexponentialDist(long Target, float* res, float* xqp, SStatePtr l1, SStatePtr l2);

void LibSReal_KolmogorovSmirnovDist(long Target, float* res, float* xqp, float* n);

void LibSReal_HoltsmarkDist(long Target, float* res, float* xqp, float* location, float* scale);

void LibSReal_LandauDist(long Target, float* res, float* xqp, float* location, float* scale);

void LibSReal_MapAiryDist(long Target, float* res, float* xqp, float* location, float* scale);

void LibSReal_Saspoint5Dist(long Target, float* res, float* xqp, float* location, float* scale);




//*********************** Boost Special functions , float precision **********************************


void LibSReal_Ulp(float* res, const float* x);

void LibSReal_BernoulliB2n(float* res, const int n);

void LibSReal_TangentT2n(float* res, const int n);

void LibSReal_Sqrt1pm1(float* res, const float* x);



void LibSReal_SinPi(float* res, const float* x);

void LibSReal_CosPi(float* res, const float* x);

void LibSReal_TanPi(float* res, const float* x);


void LibSReal_CscPi(float* res, const float* x);

void LibSReal_SecPi(float* res, const float* x);

void LibSReal_CotPi(float* res, const float* x);




void LibSReal_SincPi(float* res, const float* x);

void LibSReal_SinhcPi(float* res, const float* x);

void LibSReal_Tgamma_(float* res, const float* x);

void LibSReal_Tgamma1pm1(float* res, const float* x);

void LibSReal_Lgamma_(float* res, const float* x);

void LibSReal_Digamma(float* res, const float* x);

void LibSReal_Trigamma(float* res, const float* x);

void LibSReal_Factorial(float* res, const float* x);

void LibSReal_DoubleFactorial(float* res, const float* x);

void LibSReal_Erf_(float* res, const float* x);

void LibSReal_Erfc_(float* res, const float* x);

void LibSReal_Erf_inv(float* res, const float* x);

void LibSReal_Erfc_inv(float* res, const float* x);

void LibSReal_AiryAi(float* res, const float* x);

void LibSReal_AiryBi(float* res, const float* x);

void LibSReal_AiryAiPrime(float* res, const float* x);

void LibSReal_AiryBiPrime(float* res, const float* x);

void LibSReal_Aizero(float* res, const int n);

void LibSReal_Bizero(float* res, const int n);

void LibSReal_Ellint_1_K(float* res, const float* x);

void LibSReal_Ellint_2_K(float* res, const float* x);

void LibSReal_Zeta(float* res, const float* x);

void LibSReal_Ei(float* res, const float* x);

void LibSReal_LambertW0(float* res, const float* x);

void LibSReal_LambertWm1(float* res, const float* x);

void LibSReal_LambertW0Prime(float* res, const float* x);

void LibSReal_LambertWm1Prime(float* res, const float* x);





void LibSReal_Agm(float* res, const float* a, const float* b);


void LibSReal_Powm1(float* res, const float* a, const float* b);

void LibSReal_TgammaRatio(float* res, const float* a, const float* b);

void LibSReal_TgammaDeltaRatio(float* res, const float* a, const float* b);

void LibSReal_Binomial(float* res, const float* n, const float* k);

void LibSReal_RisingFactorial(float* res, const float* x, const float* n);

void LibSReal_FallingFactorial(float* res, const float* x, const float* n);

void LibSReal_BesselJ(float* res, const float* v, const float* x);

void LibSReal_BesselY(float* res, const float* v, const float* x);

void LibSReal_BesselI(float* res, const float* v, const float* x);

void LibSReal_BesselK(float* res, const float* v, const float* x);

void LibSReal_SphBessel(float* res, const unsigned v, const float* x);

void LibSReal_SphNeumann(float* res, const unsigned v, const float* x);

void LibSReal_BesselJPrime(float* res, const float* v, const float* x);

void LibSReal_BesselYPrime(float* res, const float* v, const float* x);

void LibSReal_BesselIPrime(float* res, const float* v, const float* x);

void LibSReal_BesselKPrime(float* res, const float* v, const float* x);

void LibSReal_SphBesselPrime(float* res, const unsigned v, const float* x);

void LibSReal_SphNeumannPrime(float* res, const unsigned v, const float* x);

void LibSReal_BesselJZero(float* res, const float* v, const int m);

void LibSReal_BesselYZero(float* res, const float* v, const int m);


void LibSReal_GammaP(float* res, const float* a, const float* x);

void LibSReal_GammaQ(float* res, const float* a, const float* x);

void LibSReal_TgammaLower(float* res, const float* a, const float* x);

void LibSReal_TgammaUpper(float* res, const float* a, const float* x);

void LibSReal_GammaPInv(float* res, const float* a, const float* p);

void LibSReal_GammaQInv(float* res, const float* a, const float* q);

void LibSReal_GammaPInva(float* res, const float* x, const float* p);

void LibSReal_GammaQInva(float* res, const float* x, const float* q);

void LibSReal_GammaPDerivative(float* res, const float* a, const float* x);

void LibSReal_Beta(float* res, const float* a, const float* b);


void LibSReal_LegendreP(float* res, int n, const float* x);

void LibSReal_LegendreQ(float* res, int n, const float* x);

void LibSReal_Laguerre(float* res, int n, const float* x);

void LibSReal_Hermite(float* res, int n, const float* x);

void LibSReal_ChebyshevT(float* res, int n, const float* x);

void LibSReal_ChebyshevU(float* res, int n, const float* x);

void LibSReal_Polygamma(float* res, int n, const float* x);

void LibSReal_EllintRC(float* res, const float* x, const float* y);

void LibSReal_Ellint1F(float* res, const float* k, const float* phi);

void LibSReal_Ellint2F(float* res, const float* k, const float* phi);

void LibSReal_Ellint3K(float* res, const float* k, const float* n);




void LibSReal_JacobiCD(float* res, const float* k, const float* u);

void LibSReal_JacobiCN(float* res, const float* k, const float* u);

void LibSReal_JacobiCS(float* res, const float* k, const float* u);

void LibSReal_JacobiDC(float* res, const float* k, const float* u);

void LibSReal_JacobiDN(float* res, const float* k, const float* u);

void LibSReal_JacobiDS(float* res, const float* k, const float* u);

void LibSReal_JacobiNC(float* res, const float* k, const float* u);

void LibSReal_JacobiND(float* res, const float* k, const float* u);

void LibSReal_JacobiNS(float* res, const float* k, const float* u);

void LibSReal_JacobiSC(float* res, const float* k, const float* u);

void LibSReal_JacobiSD(float* res, const float* k, const float* u);

void LibSReal_JacobiSN(float* res, const float* k, const float* u);


void LibSReal_expint(float* res, const unsigned n, const float* x);

void LibSReal_OwenT(float* res, const float* h, const float* a);





void LibSReal_IBeta(float* res, const float* a, const float* b, const float* x);

void LibSReal_IBetac(float* res, const float* a, const float* b, const float* x);

void LibSReal_IBetaNonNormalized(float* res, const float* a, const float* b, const float* x);

void LibSReal_IBetacNonNormalized(float* res, const float* a, const float* b, const float* x);

void LibSReal_IBetaInv(float* res, const float* a, const float* b, const float* p);

void LibSReal_IBetacInv(float* res, const float* a, const float* b, const float* q);

void LibSReal_IBetaInva(float* res, const float* b, const float* x, const float* p);

void LibSReal_IBetacInva(float* res, const float* b, const float* x, const float* q);

void LibSReal_IBetaInvb(float* res, const float* a, const float* x, const float* p);

void LibSReal_IBetacInvb(float* res, const float* a, const float* x, const float* q);

void LibSReal_IBetaDerivative(float* res, const float* a, const float* b, const float* x);


void LibSReal_LegendrePM(float* res, const int n, const int m, const float* x);

void LibSReal_LaguerreM(float* res, const int n, const int m, const float* x);


void LibSReal_EllipticRF(float* res, const float* x, const float* y, const float* z);

void LibSReal_EllipticRD(float* res, const float* x, const float* y, const float* z);

void LibSReal_EllipticRG(float* res, const float* x, const float* y, const float* z);

void LibSReal_Ellint3F(float* res, const float* k, const float* n, const float* phi);


void LibSReal_Gegenbauer(float* res, const int n, const float* lambda, const float* x);

void LibSReal_Jacobi(float* res, const int n, const float* alpha, const float* beta, const float* x);





void LibSReal_SphericalHarmonicR(float* res, const int n, const int m, const float* theta, const float* phi);

void LibSReal_SphericalHarmonicI(float* res, const int n, const int m, const float* theta, const float* phi);

void LibSReal_EllipticRJ(float* res, const float* x, const float* y, const float* z, const float* p);



// Hypergeometric and Theta Functions



void LibSReal_Hypergeo0F1(float* res, const float* b, const float* x);

void LibSReal_Hypergeo1F1(float* res, const float* a, const float* b, const float* x);

void LibSReal_Hypergeo1F1r(float* res, const float* a, const float* b, const float* x);

void LibSReal_LogHypergeo1F1(float* res, const float* a, const float* b, const float* x);



void LibSReal_JacobiTheta1(float* res, const float* x, const float* q);

void LibSReal_JacobiTheta2(float* res, const float* x, const float* q);

void LibSReal_JacobiTheta3(float* res, const float* x, const float* q);

void LibSReal_JacobiTheta4(float* res, const float* x, const float* q);










