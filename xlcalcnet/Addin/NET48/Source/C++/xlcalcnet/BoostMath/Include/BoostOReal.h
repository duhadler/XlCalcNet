
#include "stdint.h"


typedef void* ORealPtr;
typedef void* OCplxPtr;

typedef void* OStatePtr;

typedef void(*ORealFuncPtr) (void*, void*);
typedef void(*OAnyFuncPtr2) (const void*,const  void*);
typedef void(*OAnyFuncPtr3) (const void*,const  void*,const  void*);




//////*********************** Boost/CppOptLib **********************************
//
//
//void LibOReal_LbfgsSolver(ORealFuncPtr f1, ORealFuncPtr f2, OStatePtr matX_, OStatePtr matGrad_, OStatePtr xPtr);
//
//void LibOReal_BfgsSolver(ORealFuncPtr f1, ORealFuncPtr f2, OStatePtr matX_, OStatePtr matGrad_, OStatePtr xPtr);
//
//
//
//void LibOReal_GradientDescentSolver(ORealFuncPtr f1, ORealFuncPtr f2, OStatePtr matX_, OStatePtr matGrad_, OStatePtr xPtr);
//
//void LibOReal_ConjugatedGradientDescentSolver(ORealFuncPtr f1, ORealFuncPtr f2, OStatePtr matX_, OStatePtr matGrad_, OStatePtr xPtr);
//





//*********************** Boost Odeint, OReal  **********************************

OStatePtr LibOReal_StateInit_Func_N(int N);

void LibOReal_StateClear(OStatePtr x);

void LibOReal_StateGetCoeff(ORealPtr res, long row, OStatePtr source);

void LibOReal_StateSetCoeff(OStatePtr result, ORealPtr source, long row);

void LibOReal_StateGetSize(long *result, OStatePtr x);


void LibOReal_Const_RungeKutta4(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);

void LibOReal_Const_RungeKuttaCashKarp54(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);

void LibOReal_Const_RungeKuttaDopri5(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);

void LibOReal_Const_RungeKuttaFehlberg78(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);

void LibOReal_Const_AdamsBashforthMoulton(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);


void LibOReal_Adaptive_RungeKuttaDopri5(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

void LibOReal_Adaptive_RungeKuttaCashKarp54(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

void LibOReal_Adaptive_RungeKuttaFehlberg78(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

void LibOReal_Adaptive_BulirschStoer(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

void LibOReal_DenseOutput_Dopri5(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

void LibOReal_DenseOutput_BulirschStoer(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);









//*********************** Boost Numerical Calculus, OReal **********************************


void LibOReal_BracketRoot(ORealPtr res1, ORealPtr res2, int* iter, ORealFuncPtr f1, ORealPtr guess_, ORealPtr factor_, bool is_rising, int get_digits, unsigned int maxit);

void LibOReal_NewtonRaphson(ORealPtr res,  int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit);

void LibOReal_Halley(ORealPtr res, int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit);

void LibOReal_Schroder(ORealPtr res, int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit);

void LibOReal_Brent_Minimum(ORealPtr res, ORealPtr resFx, int* iter, ORealFuncPtr f1, ORealPtr bracket_min_, ORealPtr bracket_max_, int bits, unsigned int maxit);



void LibOReal_Trapezoidal(ORealPtr res1, ORealPtr res2, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_);

void LibOReal_GaussLegendre(ORealPtr res1, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_);

void LibOReal_GaussKronrod(ORealPtr res1, ORealPtr res2, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_);

void LibOReal_TanhSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_);

void LibOReal_SinhSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1);

void LibOReal_ExpSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1);

void LibOReal_Ooura_Cos(ORealPtr res1, ORealPtr res2, ORealFuncPtr f1);

void LibOReal_Ooura_Sin(ORealPtr res1, ORealPtr res2, ORealFuncPtr f1);





//*********************** Boost Distributions, OReal **********************************


void LibOReal_ArcsineDist(long Target, ORealPtr res, ORealPtr x, ORealPtr a, ORealPtr b);

void LibOReal_BernoulliDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr p);

void LibOReal_BetaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b);

void LibOReal_BinomialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n, ORealPtr p);

void LibOReal_CauchyDist(long Target, ORealPtr res, ORealPtr x, ORealPtr location, ORealPtr scale);

void LibOReal_Chi2Dist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);

void LibOReal_ExponentialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lambda);

void LibOReal_ExtremeValueDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale);

void LibOReal_FisherFDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mu, ORealPtr nu);

void LibOReal_GammaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale);

void LibOReal_GeometricDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr p);

void LibOReal_HypergeometricDist(long Target, ORealPtr res, ORealPtr x, uint64_t r, uint64_t n, uint64_t N);

void LibOReal_InverseChi2Dist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr df, ORealPtr scale);

void LibOReal_InverseGammaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale);

void LibOReal_InverseGaussianDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr scale);

void LibOReal_LaplaceDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale);

void LibOReal_LogisticDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale);

void LibOReal_LognormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale);

void LibOReal_NegBinomialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n, ORealPtr p);

void LibOReal_Chi2NCDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu, ORealPtr nc);

void LibOReal_StudentTNCDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu, ORealPtr delta);

void LibOReal_FisherNCDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mu, ORealPtr nu, ORealPtr nc);

void LibOReal_BetaNCDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b, ORealPtr nc);

void LibOReal_NormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr stdev);

void LibOReal_ParetoDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale);

void LibOReal_PoissonDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);

void LibOReal_RayleighDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);

void LibOReal_SkewNormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr scale, ORealPtr shape);

void LibOReal_StudentTDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);

void LibOReal_TriangularDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lower, ORealPtr mode_, ORealPtr upper);

void LibOReal_WeibullDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale);

void LibOReal_UniformDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lower, ORealPtr upper);




//*********************** New , octuple precision **********************************



void LibOReal_Logaddexp(ORealPtr res, const ORealPtr a, const ORealPtr b);


void LibOReal_HyperexponentialDist(long Target, ORealPtr res, ORealPtr xqp, OStatePtr l1, OStatePtr l2);

void LibOReal_KolmogorovSmirnovDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);









//*********************** Boost Special functions , OReal **********************************


void LibOReal_Ulp(ORealPtr res, const ORealPtr x);

void LibOReal_BernoulliB2n(ORealPtr res, int n);

void LibOReal_TangentT2n(ORealPtr res, int n);

void LibOReal_Sqrt1pm1(ORealPtr res, const ORealPtr x);



void LibOReal_SinPi(ORealPtr res, const ORealPtr x);

void LibOReal_CosPi(ORealPtr res, const ORealPtr x);

void LibOReal_TanPi(ORealPtr res, const ORealPtr x);

void LibOReal_CscPi(ORealPtr res, const ORealPtr x);

void LibOReal_SecPi(ORealPtr res, const ORealPtr x);

void LibOReal_CotPi(ORealPtr res, const ORealPtr x);



void LibOReal_SincPi(ORealPtr res, const ORealPtr x);

void LibOReal_SinhcPi(ORealPtr res, const ORealPtr x);


void LibOReal_Tgamma_(ORealPtr res, const ORealPtr x);

void LibOReal_Tgamma1pm1(ORealPtr res, const ORealPtr x);

void LibOReal_Lgamma_(ORealPtr res, const ORealPtr x);

void LibOReal_Digamma(ORealPtr res, const ORealPtr x);

void LibOReal_Trigamma(ORealPtr res, const ORealPtr x);


void LibOReal_Factorial(ORealPtr res, const ORealPtr x);

void LibOReal_DoubleFactorial(ORealPtr res, const ORealPtr x);


void LibOReal_Erf_(ORealPtr res, const ORealPtr x);

void LibOReal_Erfc_(ORealPtr res, const ORealPtr x);

void LibOReal_Erf_inv(ORealPtr res, const ORealPtr x);

void LibOReal_Erfc_inv(ORealPtr res, const ORealPtr x);


void LibOReal_AiryAi(ORealPtr res, const ORealPtr x);

void LibOReal_AiryBi(ORealPtr res, const ORealPtr x);

void LibOReal_AiryAiPrime(ORealPtr res, const ORealPtr x);

void LibOReal_AiryBiPrime(ORealPtr res, const ORealPtr x);

void LibOReal_Aizero(ORealPtr res, int n);

void LibOReal_Bizero(ORealPtr res, int n);


void LibOReal_Ellint_1_K(ORealPtr res, const ORealPtr x);

void LibOReal_Ellint_2_K(ORealPtr res, const ORealPtr x);

void LibOReal_Zeta(ORealPtr res, const ORealPtr x);

void LibOReal_Ei(ORealPtr res, const ORealPtr x);


void LibOReal_LambertW0(ORealPtr res, const ORealPtr x);

void LibOReal_LambertWm1(ORealPtr res, const ORealPtr x);

void LibOReal_LambertW0Prime(ORealPtr res, const ORealPtr x);

void LibOReal_LambertWm1Prime(ORealPtr res, const ORealPtr x);


void LibOReal_Agm(ORealPtr res, const ORealPtr a, const ORealPtr b);


void LibOReal_Powm1(ORealPtr res, const ORealPtr a, const ORealPtr b);

void LibOReal_TgammaRatio(ORealPtr res, const ORealPtr a, const ORealPtr b);

void LibOReal_TgammaDeltaRatio(ORealPtr res, const ORealPtr a, const ORealPtr b);


void LibOReal_Binomial(ORealPtr res, const ORealPtr n, const ORealPtr k);

void LibOReal_RisingFactorial(ORealPtr res, const ORealPtr x, const ORealPtr n);

void LibOReal_FallingFactorial(ORealPtr res, const ORealPtr x, const ORealPtr n);


void LibOReal_BesselJ(ORealPtr res, const ORealPtr v, const ORealPtr x);

void LibOReal_BesselY(ORealPtr res, const ORealPtr v, const ORealPtr x);

void LibOReal_BesselI(ORealPtr res, const ORealPtr v, const ORealPtr x);

void LibOReal_BesselK(ORealPtr res, const ORealPtr v, const ORealPtr x);

void LibOReal_SphBessel(ORealPtr res, const unsigned v, const ORealPtr x);

void LibOReal_SphNeumann(ORealPtr res, const unsigned v, const ORealPtr x);


void LibOReal_BesselJPrime(ORealPtr res, const ORealPtr v, const ORealPtr x);

void LibOReal_BesselYPrime(ORealPtr res, const ORealPtr v, const ORealPtr x);

void LibOReal_BesselIPrime(ORealPtr res, const ORealPtr v, const ORealPtr x);

void LibOReal_BesselKPrime(ORealPtr res, const ORealPtr v, const ORealPtr x);

void LibOReal_SphBesselPrime(ORealPtr res, const unsigned v, const ORealPtr x);

void LibOReal_SphNeumannPrime(ORealPtr res, const unsigned v, const ORealPtr x);


void LibOReal_BesselJZero(ORealPtr res, const ORealPtr v, const int m);

void LibOReal_BesselYZero(ORealPtr res, const ORealPtr v, const int m);


void LibOReal_GammaP(ORealPtr res, const ORealPtr a, const ORealPtr x);

void LibOReal_GammaQ(ORealPtr res, const ORealPtr a, const ORealPtr x);

void LibOReal_TgammaLower(ORealPtr res, const ORealPtr a, const ORealPtr x);

void LibOReal_TgammaUpper(ORealPtr res, const ORealPtr a, const ORealPtr x);


void LibOReal_GammaPInv(ORealPtr res, const ORealPtr a, const ORealPtr p);

void LibOReal_GammaQInv(ORealPtr res, const ORealPtr a, const ORealPtr q);

void LibOReal_GammaPInva(ORealPtr res, const ORealPtr p, const ORealPtr x);

void LibOReal_GammaQInva(ORealPtr res, const ORealPtr q, const ORealPtr x);


void LibOReal_GammaPDerivative(ORealPtr res, const ORealPtr a, const ORealPtr x);

void LibOReal_Beta(ORealPtr res, const ORealPtr a, const ORealPtr b);


void LibOReal_LegendreP(ORealPtr res, int n, const ORealPtr x);

void LibOReal_LegendreQ(ORealPtr res, int n, const ORealPtr x);

void LibOReal_Laguerre(ORealPtr res, int n, const ORealPtr x);

void LibOReal_Hermite(ORealPtr res, int n, const ORealPtr x);

void LibOReal_ChebyshevT(ORealPtr res, int n, const ORealPtr x);

void LibOReal_ChebyshevU(ORealPtr res, int n, const ORealPtr x);

void LibOReal_Polygamma(ORealPtr res, int n, const ORealPtr x);


void LibOReal_EllintRC(ORealPtr res, const ORealPtr x, const ORealPtr y);

void LibOReal_Ellint1F(ORealPtr res, const ORealPtr k, const ORealPtr phi);

void LibOReal_Ellint2F(ORealPtr res, const ORealPtr k, const ORealPtr phi);

void LibOReal_Ellint3K(ORealPtr res, const ORealPtr k, const ORealPtr n);


void LibOReal_JacobiCD(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiCN(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiCS(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiDC(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiDN(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiDS(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiNC(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiND(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiNS(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiSC(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiSD(ORealPtr res, const ORealPtr k, const ORealPtr u);

void LibOReal_JacobiSN(ORealPtr res, const ORealPtr k, const ORealPtr u);


void LibOReal_expint(ORealPtr res, const unsigned n, const ORealPtr x);

void LibOReal_OwenT(ORealPtr res, const ORealPtr h, const ORealPtr a);


void LibOReal_IBeta(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

void LibOReal_IBetac(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

void LibOReal_IBetaNonNormalized(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

void LibOReal_IBetacNonNormalized(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

void LibOReal_IBetaInv(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr p);

void LibOReal_IBetacInv(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr q);

void LibOReal_IBetaInva(ORealPtr res, const ORealPtr b, const ORealPtr x, const ORealPtr p);

void LibOReal_IBetacInva(ORealPtr res, const ORealPtr b, const ORealPtr x, const ORealPtr q);

void LibOReal_IBetaInvb(ORealPtr res, const ORealPtr a, const ORealPtr x, const ORealPtr p);

void LibOReal_IBetacInvb(ORealPtr res, const ORealPtr a, const ORealPtr x, const ORealPtr q);

void LibOReal_IBetaDerivative(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);


void LibOReal_LegendrePM(ORealPtr res, const int n, const int m, const ORealPtr x);

void LibOReal_LaguerreM(ORealPtr res, const int n, const int m, const ORealPtr x);


void LibOReal_EllipticRF(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z);

void LibOReal_EllipticRD(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z);

void LibOReal_EllipticRG(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z);

void LibOReal_Ellint3F(ORealPtr res, const ORealPtr k, const ORealPtr n, const ORealPtr phi);


void LibOReal_Gegenbauer(ORealPtr res, const int n, const ORealPtr lambda, const ORealPtr x);

void LibOReal_Jacobi(ORealPtr res, const int n, const ORealPtr alpha, const ORealPtr beta, const ORealPtr x);




void LibOReal_SphericalHarmonicR(ORealPtr res, const int n, const int m, const ORealPtr theta, const ORealPtr phi);

void LibOReal_SphericalHarmonicI(ORealPtr res, const int n, const int m, const ORealPtr theta, const ORealPtr phi);

void LibOReal_EllipticRJ(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z, const ORealPtr p);


void LibOReal_Hypergeo0F1(ORealPtr res, const ORealPtr b, const ORealPtr x);

void LibOReal_Hypergeo1F1(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

void LibOReal_Hypergeo1F1r(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

void LibOReal_LogHypergeo1F1(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);


void LibOReal_JacobiTheta1(ORealPtr res, const ORealPtr x, const ORealPtr q);

void LibOReal_JacobiTheta2(ORealPtr res, const ORealPtr x, const ORealPtr q);

void LibOReal_JacobiTheta3(ORealPtr res, const ORealPtr x, const ORealPtr q);

void LibOReal_JacobiTheta4(ORealPtr res, const ORealPtr x, const ORealPtr q);

















//*********************** Real Basic Functions, OReal **********************************



ORealPtr LibOReal_Init_Func();

void LibOReal_Clear(ORealPtr x);


void LibOReal_Get_Str(char* cstr, ORealPtr x);


void LibOReal_Get_HexStr(char* cstr, ORealPtr x);




void LibOReal_Set_Str(ORealPtr res, const char * str);


void LibOReal_Set(ORealPtr res, const ORealPtr x);


void LibOReal_Neg(ORealPtr res, const ORealPtr x);




void LibOReal_Set_S(ORealPtr res, const float* x);


void LibOReal_Set_D(ORealPtr res, const double x);


void LibOReal_Set_LD(ORealPtr res, const long double* x);



void LibOReal_Get_S(float* res, const ORealPtr x);


void LibOReal_Get_D(double* res, const ORealPtr x);


void LibOReal_Get_LD(long double* res, const ORealPtr x);




void LibOReal_Set_Si(ORealPtr res, const int32_t x);


void LibOReal_Set_Si64(ORealPtr res, const int64_t x);


void LibOReal_Set_Ui(ORealPtr res, const uint32_t x);


void LibOReal_Set_Ui64(ORealPtr res, const uint64_t x);





void LibOReal_Add(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Sub(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Mul(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Div(ORealPtr res, const ORealPtr x, const ORealPtr y);


void LibOReal_Add_D(ORealPtr res, const ORealPtr x, const double y);
void LibOReal_Sub_D(ORealPtr res, const ORealPtr x, const double y);
void LibOReal_D_Sub(ORealPtr res, const ORealPtr x, const double y);

void LibOReal_Mul_D(ORealPtr res, const ORealPtr x, const double y);
void LibOReal_Div_D(ORealPtr res, const ORealPtr x, const double y);
void LibOReal_D_Div(ORealPtr res, const ORealPtr x, const double y);


void LibOReal_Add_Si(ORealPtr res, const ORealPtr x, const int32_t y);
void LibOReal_Sub_Si(ORealPtr res, const ORealPtr x, const int32_t y);
void LibOReal_Si_Sub(ORealPtr res, const ORealPtr x, const int32_t y);

void LibOReal_Mul_Si(ORealPtr res, const ORealPtr x, const int32_t y);
void LibOReal_Div_Si(ORealPtr res, const ORealPtr x, const int32_t y);
void LibOReal_Si_Div(ORealPtr res, const ORealPtr x, const int32_t y);







int32_t LibOReal_LT(const ORealPtr x, const ORealPtr y);
int32_t LibOReal_GE(const ORealPtr x, const ORealPtr y);
int32_t LibOReal_GT(const ORealPtr x, const ORealPtr y);
int32_t LibOReal_LE(const ORealPtr x, const ORealPtr y);
int32_t LibOReal_EQ(const ORealPtr x, const ORealPtr y);
int32_t LibOReal_NE(const ORealPtr x, const ORealPtr y);






/* General functions for real numbers  */

void LibOReal_Fma(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z);
void LibOReal_Fmax(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Fmin(ORealPtr res, const ORealPtr x, const ORealPtr y);




/* Machine constants */

void LibOReal_Zero(ORealPtr res);
void LibOReal_NegZero(ORealPtr res);
void LibOReal_One(ORealPtr res);
void LibOReal_Inf(ORealPtr res);
void LibOReal_NegInf(ORealPtr res);
void LibOReal_Nan(ORealPtr res);




/* Properties of numbers  */

int LibOReal_Signbit(const ORealPtr x);
int LibOReal_Finite(const ORealPtr x);
int LibOReal_Isinf(const ORealPtr x);
int LibOReal_Isposinf(const ORealPtr x);
int LibOReal_Isneginf(const ORealPtr x);
int LibOReal_Isnan(const ORealPtr x);

int LibOReal_Iszero(const ORealPtr x);
int LibOReal_Isposzero(const ORealPtr x);
int LibOReal_Isnegzero(const ORealPtr x);
int LibOReal_Isone(const ORealPtr x);
int LibOReal_Isinteger(const ORealPtr x);

int LibOReal_Isnumber(const ORealPtr x);
int LibOReal_Isregular(const ORealPtr x);
int LibOReal_Isnormal(const ORealPtr x);
int LibOReal_Issubnormal(const ORealPtr x);
int LibOReal_Isunordered(const ORealPtr x, const ORealPtr y);

int LibOReal_FitsInt32(const ORealPtr x);
int LibOReal_FitsInt64(const ORealPtr x);
int LibOReal_FitsUInt32(const ORealPtr x);
int LibOReal_FitsUInt64(const ORealPtr x);





/* Integer Related Functions  */

void LibOReal_Nearbyint(ORealPtr res, const ORealPtr x);
void LibOReal_Rint(ORealPtr res, const ORealPtr x);
long int LibOReal_Lrint(const ORealPtr x);
long long int LibOReal_Llrint(const ORealPtr x);

void LibOReal_Ceil(ORealPtr res, const ORealPtr x);
void LibOReal_Floor(ORealPtr res, const ORealPtr x);
void LibOReal_Trunc(ORealPtr res, const ORealPtr x);

void LibOReal_Round(ORealPtr res, const ORealPtr x);
long int LibOReal_Lround(const ORealPtr x);
long long int LibOReal_Llround(const ORealPtr x);

int32_t LibOReal_ToInt32(const ORealPtr x);
int64_t LibOReal_ToInt64(const ORealPtr x);

uint32_t LibOReal_ToUInt32(const ORealPtr x);
uint64_t LibOReal_ToUInt64(const ORealPtr x);



/* Floating point functions for real numbers */

void LibOReal_Copysign(ORealPtr res, const ORealPtr x, const ORealPtr y);

void LibOReal_Frexp(ORealPtr res, const ORealPtr x, int* e);
void LibOReal_Logb(ORealPtr res, const ORealPtr x);
int LibOReal_Ilogb(const ORealPtr x);

void LibOReal_Ldexp(ORealPtr res, const ORealPtr x, const int e);
void LibOReal_Scalbln(ORealPtr res, const ORealPtr x, const long int e);
void LibOReal_Scalbn(ORealPtr res, const ORealPtr x, const int e);

void LibOReal_Fdim(ORealPtr res, const ORealPtr x, const ORealPtr y);




/* Fraction and Remainder Related Functions  */

void LibOReal_Modf(ORealPtr frac, const ORealPtr x, ORealPtr iptr);
void LibOReal_Fmod(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Remainder(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Remquo(ORealPtr res, const ORealPtr x, const ORealPtr y, int* e);




/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

void LibOReal_Epsilon(ORealPtr res);
void LibOReal_Max(ORealPtr res);
void LibOReal_Min(ORealPtr res);
void LibOReal_Lowest(ORealPtr res);
void LibOReal_Nexttowards(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Nextabove(ORealPtr res, const ORealPtr x);
void LibOReal_Nextbelow(ORealPtr res, const ORealPtr x);



/* Complex components  */

void LibOReal_Fabs(ORealPtr res, const ORealPtr x);
void LibOReal_Sign(ORealPtr res, const ORealPtr x);



/* Mathematical Constants  */

void LibOReal_Pi(ORealPtr res);
void LibOReal_E(ORealPtr res);



/* Roots and related functions  */

void LibOReal_Sqrt(ORealPtr res, const ORealPtr x);
void LibOReal_Rsqrt(ORealPtr res, const ORealPtr x);
void LibOReal_Cbrt(ORealPtr res, const ORealPtr x);
void LibOReal_Root_Si(ORealPtr res, const ORealPtr x, const int32_t k_);


/* Exponential and related functions  */

void LibOReal_Exp(ORealPtr res, const ORealPtr x);
void LibOReal_Exp2(ORealPtr res, const ORealPtr x);
void LibOReal_Exp10(ORealPtr res, const ORealPtr x);

void LibOReal_Expm1(ORealPtr res, const ORealPtr x);
void LibOReal_Exp2m1(ORealPtr res, const ORealPtr x);
void LibOReal_Exp10m1(ORealPtr res, const ORealPtr x);


/* Logarithms and related functions  */

void LibOReal_Log(ORealPtr res, const ORealPtr x);
void LibOReal_Log2(ORealPtr res, const ORealPtr x);
void LibOReal_Log10(ORealPtr res, const ORealPtr x);

void LibOReal_Log1p(ORealPtr res, const ORealPtr x);
void LibOReal_Log2p1(ORealPtr res, const ORealPtr x);
void LibOReal_Log10p1(ORealPtr res, const ORealPtr x);



/* Power functions */

void LibOReal_Square(ORealPtr res, const ORealPtr x);
void LibOReal_Cube(ORealPtr res, const ORealPtr x);
void LibOReal_Hypot(ORealPtr res, const ORealPtr x, const ORealPtr y);

void LibOReal_Pow(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Pow1p(ORealPtr res, const ORealPtr x, const ORealPtr y);
void LibOReal_Pow1pm1(ORealPtr res, const ORealPtr x, const ORealPtr y);

void LibOReal_Pow_Si(ORealPtr res, const ORealPtr x, const int32_t k_);
void LibOReal_Compound_Si(ORealPtr res, const ORealPtr x, const int32_t k_);


/* Trigonometric functions  */

void LibOReal_Sin(ORealPtr res, const ORealPtr x);
void LibOReal_Cos(ORealPtr res, const ORealPtr x);
void LibOReal_Tan(ORealPtr res, const ORealPtr x);

void LibOReal_Csc(ORealPtr res, const ORealPtr x);
void LibOReal_Sec(ORealPtr res, const ORealPtr x);
void LibOReal_Cot(ORealPtr res, const ORealPtr x);


/* Hyperbolic functions  */

void LibOReal_Sinh(ORealPtr res, const ORealPtr x);
void LibOReal_Cosh(ORealPtr res, const ORealPtr x);
void LibOReal_Tanh(ORealPtr res, const ORealPtr x);

void LibOReal_Csch(ORealPtr res, const ORealPtr x);
void LibOReal_Sech(ORealPtr res, const ORealPtr x);
void LibOReal_Coth(ORealPtr res, const ORealPtr x);



/* Inverse trigonometric functions  */

void LibOReal_Acos(ORealPtr res, const ORealPtr x);
void LibOReal_Asin(ORealPtr res, const ORealPtr x);
void LibOReal_Atan(ORealPtr res, const ORealPtr x);
void LibOReal_Atan2(ORealPtr res, const ORealPtr x, const ORealPtr y);

void LibOReal_Acsc(ORealPtr res, const ORealPtr x);
void LibOReal_Asec(ORealPtr res, const ORealPtr x);
void LibOReal_Acot(ORealPtr res, const ORealPtr x);


/* Inverse hyperbolic functions  */

void LibOReal_Acosh(ORealPtr res, const ORealPtr x);
void LibOReal_Asinh(ORealPtr res, const ORealPtr x);
void LibOReal_Atanh(ORealPtr res, const ORealPtr x);

void LibOReal_Acsch(ORealPtr res, const ORealPtr x);
void LibOReal_Asech(ORealPtr res, const ORealPtr x);
void LibOReal_Acoth(ORealPtr res, const ORealPtr x);



/* Special functions  */

void LibOReal_Erf(ORealPtr res, const ORealPtr x);
void LibOReal_Erfc(ORealPtr res, const ORealPtr x);

void LibOReal_Tgamma(ORealPtr res, const ORealPtr x);
void LibOReal_Lgamma(ORealPtr res, const ORealPtr x);

void LibOReal_J0(ORealPtr res, const ORealPtr x);
void LibOReal_J1(ORealPtr res, const ORealPtr x);
void LibOReal_Jn(ORealPtr res, const int n, const ORealPtr x);

void LibOReal_Y0(ORealPtr res, const ORealPtr x);
void LibOReal_Y1(ORealPtr res, const ORealPtr x);
void LibOReal_Yn(ORealPtr res, const int n, const ORealPtr x);









//*********************** Complex **********************************


OCplxPtr LibOCplx_Init_Func();
void LibOCplx_Clear(OCplxPtr x);

void LibOCplx_Get_Str_Real(char* cstr, OCplxPtr x);
void LibOCplx_Get_Str_Imag(char* cstr, OCplxPtr x);




void LibOCplx_Neg(OCplxPtr res, const OCplxPtr x);



void LibOCplx_Add(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
void LibOCplx_Sub(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
void LibOCplx_Mul(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
void LibOCplx_Div(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);


void LibOCplx_Add_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y);
void LibOCplx_Sub_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y);
void LibOCplx_OReal_Sub(OCplxPtr res, const OCplxPtr y, const ORealPtr x);

void LibOCplx_Mul_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y);
void LibOCplx_Div_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y);
void LibOCplx_OReal_Div(OCplxPtr res, const OCplxPtr y, const ORealPtr x);


void LibOCplx_Add_D(OCplxPtr res, const OCplxPtr x, const double y);
void LibOCplx_Sub_D(OCplxPtr res, const OCplxPtr x, const double y);
void LibOCplx_D_Sub(OCplxPtr res, const OCplxPtr y, const double x);

void LibOCplx_Mul_D(OCplxPtr res, const OCplxPtr x, const double y);
void LibOCplx_Div_D(OCplxPtr res, const OCplxPtr x, const double y);
void LibOCplx_D_Div(OCplxPtr res, const OCplxPtr y, const double x);


void LibOCplx_Add_Si(OCplxPtr res, const OCplxPtr x, const int32_t y);
void LibOCplx_Sub_Si(OCplxPtr res, const OCplxPtr x, const int32_t y);
void LibOCplx_Si_Sub(OCplxPtr res, const OCplxPtr y, const int32_t x);

void LibOCplx_Mul_Si(OCplxPtr res, const OCplxPtr x, const int32_t y);
void LibOCplx_Div_Si(OCplxPtr res, const OCplxPtr x, const int32_t y);
void LibOCplx_Si_Div(OCplxPtr res, const OCplxPtr y, const int32_t x);





/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void LibOCplx_Set(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Set_Real(OCplxPtr res, const ORealPtr re);
void LibOCplx_Set2(OCplxPtr res, const ORealPtr re, const ORealPtr im);

void LibOCplx_Set2_Str2(ORealPtr res, const char * str_re, const char * str_im);

void LibOCplx_Abs(ORealPtr res, const OCplxPtr x);
void LibOCplx_Arg(ORealPtr res, const OCplxPtr x);
void LibOCplx_Imag(ORealPtr res, const OCplxPtr x);
void LibOCplx_Real(ORealPtr res, const OCplxPtr x);
void LibOCplx_Conj(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Proj(OCplxPtr res, const OCplxPtr x);



/* Roots  */

void LibOCplx_Sqrt(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Sqrt1pm1(OCplxPtr res, const OCplxPtr x);

void LibOCplx_Rsqrt(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Cbrt(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Root_Si(OCplxPtr res, const OCplxPtr x, const int32_t k);


/* Exponential and related functions  */

void LibOCplx_Exp(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Expi(OCplxPtr res, const ORealPtr x);
void LibOCplx_Exp2(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Exp10(OCplxPtr res, const OCplxPtr x);

void LibOCplx_Expm1(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Exp2m1(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Exp10m1(OCplxPtr res, const OCplxPtr x);



/* Logarithms and related functions  */

void LibOCplx_Log(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Log2(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Log10(OCplxPtr res, const OCplxPtr x);

void LibOCplx_Log1p(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Log2p1(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Log10p1(OCplxPtr res, const OCplxPtr x);




/* Power functions and roots  */

void LibOCplx_Square(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Cube(OCplxPtr res, const OCplxPtr x);

void LibOCplx_Pow(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
void LibOCplx_Powm1(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
void LibOCplx_Pow1p(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
void LibOCplx_Pow1pm1(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);

void LibOCplx_Pow_Si(OCplxPtr res, const OCplxPtr x, const int32_t k);
void LibOCplx_Compound_Si(OCplxPtr res, const OCplxPtr x, const int32_t k);



/* Trigonometric functions  */

void LibOCplx_Sin(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Cos(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Tan(OCplxPtr res, const OCplxPtr x);

void LibOCplx_Csc(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Sec(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Cot(OCplxPtr res, const OCplxPtr x);

void LibOCplx_SinPi(OCplxPtr res, const OCplxPtr x);
void LibOCplx_CosPi(OCplxPtr res, const OCplxPtr x);
void LibOCplx_TanPi(OCplxPtr res, const OCplxPtr x);



/* Hyperbolic functions  */

void LibOCplx_Sinh(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Cosh(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Tanh(OCplxPtr res, const OCplxPtr x);

void LibOCplx_Csch(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Sech(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Coth(OCplxPtr res, const OCplxPtr x);


/* Inverse trigonometric functions  */

void LibOCplx_Asin(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Acos(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Atan(OCplxPtr res, const OCplxPtr x);

void LibOCplx_Acsc(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Asec(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Acot(OCplxPtr res, const OCplxPtr x);



/* Inverse hyperbolic functions  */

void LibOCplx_Asinh(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Acosh(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Atanh(OCplxPtr res, const OCplxPtr x);

void LibOCplx_Acsch(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Asech(OCplxPtr res, const OCplxPtr x);
void LibOCplx_Acoth(OCplxPtr res, const OCplxPtr x);






