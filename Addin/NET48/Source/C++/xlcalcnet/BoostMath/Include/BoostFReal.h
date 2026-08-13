
#include "stdint.h"

typedef void* FRealPtr;
typedef void* FCplxPtr;

typedef void* FStatePtr;

typedef void(*FRealFuncPtr) (void*, void*);
typedef void(*FCplxFuncPtr) (void*, void*, void*);
typedef void(*FAnyFuncPtr2) (const void*,const  void*);
typedef void(*FAnyFuncPtr3) (const void*,const  void*,const  void*);



//////*********************** Boost/CppOptLib **********************************
//
//
//void LibFReal_LbfgsSolver(FRealFuncPtr f1, FRealFuncPtr f2, FStatePtr matX_, FStatePtr matGrad_, FStatePtr xPtr);
//
//void LibFReal_BfgsSolver(FRealFuncPtr f1, FRealFuncPtr f2, FStatePtr matX_, FStatePtr matGrad_, FStatePtr xPtr);
//
//
//
//void LibFReal_GradientDescentSolver(FRealFuncPtr f1, FRealFuncPtr f2, FStatePtr matX_, FStatePtr matGrad_, FStatePtr xPtr);
//
//void LibFReal_ConjugatedGradientDescentSolver(FRealFuncPtr f1, FRealFuncPtr f2, FStatePtr matX_, FStatePtr matGrad_, FStatePtr xPtr);




//*********************** Boost Odeint **********************************

void LibFReal_Const_RungeKutta4(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt);

void LibFReal_Const_RungeKuttaCashKarp54(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt);

void LibFReal_Const_RungeKuttaDopri5(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt);

void LibFReal_Const_RungeKuttaFehlberg78(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt);

void LibFReal_Const_AdamsBashforthMoulton(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt);


void LibFReal_Adaptive_RungeKuttaDopri5(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel);

void LibFReal_Adaptive_RungeKuttaCashKarp54(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel);

void LibFReal_Adaptive_RungeKuttaFehlberg78(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel);

void LibFReal_Adaptive_BulirschStoer(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel);


void LibFReal_DenseOutput_Dopri5(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel);

void LibFReal_DenseOutput_BulirschStoer(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel);






//*********************** Extra **********************************




void LibFReal_Pi(double* res);

void LibFReal_E(double* res);



void LibFReal_ShowExtNet(char* cstr, const double* d);




//*********************** Boost Numerical Calculus, double precision **********************************


void LibFReal_BracketRoot(double* res1, double* res2, int* iter, FRealFuncPtr f1, double* guess, double* factor, bool is_rising, int get_digits, unsigned int maxit);

void LibFReal_NewtonRaphson(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit);

void LibFReal_Halley(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit);

void LibFReal_Schroder(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit);

void LibFReal_Brent_Minimum(double* res, double* resFx, int* iter, FRealFuncPtr f1, double* bracket_min, double* bracket_max, int bits, unsigned int maxit);



void LibFReal_Trapezoidal(double* res1, double* res2, double* res3, FRealFuncPtr f1, double* a, double* b);

void LibFReal_GaussLegendre(double* res1, double* res3, FRealFuncPtr f1, double* a, double* b);

void LibFReal_GaussKronrod(double* res1, double* res2, double* res3, FRealFuncPtr f1, double* a, double* b);

void LibFReal_TanhSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1, double* a, double* b);

void LibFReal_SinhSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1);

void LibFReal_ExpSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1);

void LibFReal_Ooura_Cos(double* res1, double* res2, FRealFuncPtr f1);

void LibFReal_Ooura_Sin(double* res1, double* res2, FRealFuncPtr f1);





//*********************** Boost Distributions, double precision **********************************


void LibFReal_ArcsineDist(long Target, double* res, double* xqp, double* a, double* b);

void LibFReal_BernoulliDist(long Target, double* res, double* xqp, double* p);

void LibFReal_BetaDist(long Target, double* res, double* xqp, double* a, double* b);

void LibFReal_BinomialDist(long Target, double* res, double* xqp, double* n, double* p);

void LibFReal_CauchyDist(long Target, double* res, double* x, double* location, double* scale);

void LibFReal_Chi2Dist(long Target, double* res, double* xqp, double* nu);

void LibFReal_ExponentialDist(long Target, double* res, double* xqp, double* lambda);

void LibFReal_ExtremeValueDist(long Target, double* res, double* xqp, double* location, double* scale);

void LibFReal_FisherFDist(long Target, double* res, double* xqp, double* mu, double* nu);

void LibFReal_GammaDist(long Target, double* res, double* xqp, double* shape, double* scale);

void LibFReal_GeometricDist(long Target, double* res, double* xqp, double* p);

void LibFReal_HypergeometricDist(long Target, double* res, double* x, uint64_t r, uint64_t n, uint64_t N);

void LibFReal_InverseChi2Dist(long Target, double* res, double* xqp, double* df, double* scale);

void LibFReal_InverseGammaDist(long Target, double* res, double* xqp, double* shape, double* scale);

void LibFReal_InverseGaussianDist(long Target, double* res, double* xqp, double* mean_, double* scale);

void LibFReal_LaplaceDist(long Target, double* res, double* xqp, double* location, double* scale);

void LibFReal_LogisticDist(long Target, double* res, double* xqp, double* location, double* scale);

void LibFReal_LognormalDist(long Target, double* res, double* xqp, double* location, double* scale);

void LibFReal_NegBinomialDist(long Target, double* res, double* xqp, double* n, double* p);

void LibFReal_Chi2NCDist(long Target, double* res, double* xqp, double* nu, double* nc);

void LibFReal_StudentTNCDist(long Target, double* res, double* xqp, double* nu, double* delta);

void LibFReal_FisherNCDist(long Target, double* res, double* xqp, double* mu, double* nu, double* nc);

void LibFReal_BetaNCDist(long Target, double* res, double* xqp, double* a, double* b, double* nc);

void LibFReal_NormalDist(long Target, double* res, double* xqp, double* mean_, double* stdev);

void LibFReal_ParetoDist(long Target, double* res, double* xqp, double* shape, double* scale);

void LibFReal_PoissonDist(long Target, double* res, double* xqp, double* nu);

void LibFReal_RayleighDist(long Target, double* res, double* xqp, double* nu);

void LibFReal_SkewNormalDist(long Target, double* res, double* xqp, double* mean_, double* scale, double* shape);

void LibFReal_StudentTDist(long Target, double* res, double* xqp, double* nu);

void LibFReal_TriangularDist(long Target, double* res, double* xqp, double* lower, double* mode_, double* upper);

void LibFReal_WeibullDist(long Target, double* res, double* xqp, double* shape, double* scale);

void LibFReal_UniformDist(long Target, double* res, double* xqp, double* lower, double* upper);




//*********************** New , double precision **********************************



void LibFReal_Logaddexp(double* res, const double* a, const double* b);


void LibFReal_HyperexponentialDist(long Target, double* res, double* xqp, FStatePtr l1, FStatePtr l2);

void LibFReal_KolmogorovSmirnovDist(long Target, double* res, double* xqp, double* n);

void LibFReal_HoltsmarkDist(long Target, double* res, double* xqp, double* location, double* scale);

void LibFReal_LandauDist(long Target, double* res, double* xqp, double* location, double* scale);

void LibFReal_MapAiryDist(long Target, double* res, double* xqp, double* location, double* scale);

void LibFReal_Saspoint5Dist(long Target, double* res, double* xqp, double* location, double* scale);




//*********************** Boost Special functions , double precision **********************************


void LibFReal_Ulp(double* res, const double* x);

void LibFReal_BernoulliB2n(double* res, const int n);

void LibFReal_TangentT2n(double* res, const int n);

void LibFReal_Sqrt1pm1(double* res, const double* x);


void LibFReal_SinPi(double* res, const double* x);

void LibFReal_CosPi(double* res, const double* x);

void LibFReal_TanPi(double* res, const double* x);


void LibFReal_CscPi(double* res, const double* x);

void LibFReal_SecPi(double* res, const double* x);

void LibFReal_CotPi(double* res, const double* x);



void LibFReal_SincPi(double* res, const double* x);

void LibFReal_SinhcPi(double* res, const double* x);

void LibFReal_Tgamma_(double* res, const double* x);

void LibFReal_Tgamma1pm1(double* res, const double* x);

void LibFReal_Digamma(double* res, const double* x);

void LibFReal_Lgamma_(double* res, const double* x);

void LibFReal_Trigamma(double* res, const double* x);

void LibFReal_Factorial(double* res, const double* x);

void LibFReal_DoubleFactorial(double* res, const double* x);

void LibFReal_Erf_(double* res, const double* x);

void LibFReal_Erfc_(double* res, const double* x);

void LibFReal_Erf_inv(double* res, const double* x);

void LibFReal_Erfc_inv(double* res, const double* x);

void LibFReal_AiryAi(double* res, const double* x);

void LibFReal_AiryBi(double* res, const double* x);

void LibFReal_AiryAiPrime(double* res, const double* x);

void LibFReal_AiryBiPrime(double* res, const double* x);

void LibFReal_Aizero(double* res, const int n);

void LibFReal_Bizero(double* res, const int n);

void LibFReal_Ellint_1_K(double* res, const double* x);

void LibFReal_Ellint_2_K(double* res, const double* x);

void LibFReal_Zeta(double* res, const double* x);

void LibFReal_Ei(double* res, const double* x);

void LibFReal_LambertW0(double* res, const double* x);

void LibFReal_LambertWm1(double* res, const double* x);

void LibFReal_LambertW0Prime(double* res, const double* x);

void LibFReal_LambertWm1Prime(double* res, const double* x);





void LibFReal_Agm(double* res, const double* a, const double* b);


void LibFReal_Powm1(double* res, const double* a, const double* b);

void LibFReal_TgammaRatio(double* res, const double* a, const double* b);

void LibFReal_TgammaDeltaRatio(double* res, const double* a, const double* b);

void LibFReal_Binomial(double* res, const double* n, const double* k);

void LibFReal_RisingFactorial(double* res, const double* x, const double* n);

void LibFReal_FallingFactorial(double* res, const double* x, const double* n);

void LibFReal_BesselJ(double* res, const double* v, const double* x);

void LibFReal_BesselY(double* res, const double* v, const double* x);

void LibFReal_BesselI(double* res, const double* v, const double* x);

void LibFReal_BesselK(double* res, const double* v, const double* x);

void LibFReal_SphBessel(double* res, const unsigned v, const double* x);

void LibFReal_SphNeumann(double* res, const unsigned v, const double* x);

void LibFReal_BesselJPrime(double* res, const double* v, const double* x);

void LibFReal_BesselYPrime(double* res, const double* v, const double* x);

void LibFReal_BesselIPrime(double* res, const double* v, const double* x);

void LibFReal_BesselKPrime(double* res, const double* v, const double* x);

void LibFReal_SphBesselPrime(double* res, const unsigned v, const double* x);

void LibFReal_SphNeumannPrime(double* res, const unsigned v, const double* x);

void LibFReal_BesselJZero(double* res, const double* v, const int m);

void LibFReal_BesselYZero(double* res, const double* v, const int m);


void LibFReal_GammaP(double* res, const double* a, const double* x);

void LibFReal_GammaQ(double* res, const double* a, const double* x);

void LibFReal_TgammaLower(double* res, const double* a, const double* x);

void LibFReal_TgammaUpper(double* res, const double* a, const double* x);

void LibFReal_GammaPInv(double* res, const double* a, const double* p);

void LibFReal_GammaQInv(double* res, const double* a, const double* q);

void LibFReal_GammaPInva(double* res, const double* x, const double* p);

void LibFReal_GammaQInva(double* res, const double* x, const double* q);

void LibFReal_GammaPDerivative(double* res, const double* a, const double* x);

void LibFReal_Beta(double* res, const double* a, const double* b);


void LibFReal_LegendreP(double* res, int n, const double* x);

void LibFReal_LegendreQ(double* res, int n, const double* x);

void LibFReal_Laguerre(double* res, int n, const double* x);

void LibFReal_Hermite(double* res, int n, const double* x);

void LibFReal_ChebyshevT(double* res, int n, const double* x);

void LibFReal_ChebyshevU(double* res, int n, const double* x);

void LibFReal_Polygamma(double* res, int n, const double* x);

void LibFReal_EllintRC(double* res, const double* x, const double* y);

void LibFReal_Ellint1F(double* res, const double* k, const double* phi);

void LibFReal_Ellint2F(double* res, const double* k, const double* phi);

void LibFReal_Ellint3K(double* res, const double* k, const double* n);




void LibFReal_JacobiCD(double* res, const double* k, const double* u);

void LibFReal_JacobiCN(double* res, const double* k, const double* u);

void LibFReal_JacobiCS(double* res, const double* k, const double* u);

void LibFReal_JacobiDC(double* res, const double* k, const double* u);

void LibFReal_JacobiDN(double* res, const double* k, const double* u);

void LibFReal_JacobiDS(double* res, const double* k, const double* u);

void LibFReal_JacobiNC(double* res, const double* k, const double* u);

void LibFReal_JacobiND(double* res, const double* k, const double* u);

void LibFReal_JacobiNS(double* res, const double* k, const double* u);

void LibFReal_JacobiSC(double* res, const double* k, const double* u);

void LibFReal_JacobiSD(double* res, const double* k, const double* u);

void LibFReal_JacobiSN(double* res, const double* k, const double* u);


void LibFReal_expint(double* res, const unsigned n, const double* x);

void LibFReal_OwenT(double* res, const double* h, const double* a);





void LibFReal_IBeta(double* res, const double* a, const double* b, const double* x);

void LibFReal_IBetac(double* res, const double* a, const double* b, const double* x);

void LibFReal_IBetaNonNormalized(double* res, const double* a, const double* b, const double* x);

void LibFReal_IBetacNonNormalized(double* res, const double* a, const double* b, const double* x);

void LibFReal_IBetaInv(double* res, const double* a, const double* b, const double* p);

void LibFReal_IBetacInv(double* res, const double* a, const double* b, const double* q);

void LibFReal_IBetaInva(double* res, const double* b, const double* x, const double* p);

void LibFReal_IBetacInva(double* res, const double* b, const double* x, const double* q);

void LibFReal_IBetaInvb(double* res, const double* a, const double* x, const double* p);

void LibFReal_IBetacInvb(double* res, const double* a, const double* x, const double* q);

void LibFReal_IBetaDerivative(double* res, const double* a, const double* b, const double* x);


void LibFReal_LegendrePM(double* res, const int n, const int m, const double* x);

void LibFReal_LaguerreM(double* res, const int n, const int m, const double* x);


void LibFReal_EllipticRF(double* res, const double* x, const double* y, const double* z);

void LibFReal_EllipticRD(double* res, const double* x, const double* y, const double* z);

void LibFReal_EllipticRG(double* res, const double* x, const double* y, const double* z);

void LibFReal_Ellint3F(double* res, const double* k, const double* n, const double* phi);


void LibFReal_Gegenbauer(double* res, const int n, const double* lambda, const double* x);

void LibFReal_Jacobi(double* res, const int n, const double* alpha, const double* beta, const double* x);




void LibFReal_SphericalHarmonicR(double* res, const int n, const int m, const double* theta, const double* phi);

void LibFReal_SphericalHarmonicI(double* res, const int n, const int m, const double* theta, const double* phi);

void LibFReal_EllipticRJ(double* res, const double* x, const double* y, const double* z, const double* p);



// Hypergeometric and Theta Functions



void LibFReal_Hypergeo0F1(double* res, const double* b, const double* x);

void LibFReal_Hypergeo1F1(double* res, const double* a, const double* b, const double* x);

void LibFReal_Hypergeo1F1r(double* res, const double* a, const double* b, const double* x);

void LibFReal_LogHypergeo1F1(double* res, const double* a, const double* b, const double* x);



void LibFReal_JacobiTheta1(double* res, const double* x, const double* q);

void LibFReal_JacobiTheta2(double* res, const double* x, const double* q);

void LibFReal_JacobiTheta3(double* res, const double* x, const double* q);

void LibFReal_JacobiTheta4(double* res, const double* x, const double* q);





