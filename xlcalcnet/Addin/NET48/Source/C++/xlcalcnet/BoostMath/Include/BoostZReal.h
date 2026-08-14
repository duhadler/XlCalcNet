
#include "stdint.h"



typedef void* ZRealPtr;
typedef void* ZCplxPtr;

typedef void* DStatePtr;

typedef void(*ZRealFuncPtr) (void*, void*);
typedef void(*DAnyFuncPtr2) (const void*,const  void*);
typedef void(*DAnyFuncPtr3) (const void*,const  void*,const  void*);




//*********************** Boost/CppOptLib **********************************

void LibZReal_GradientDescentSolverSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr);

void LibZReal_ConjugatedGradientDescentSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr);

void LibZReal_BfgsSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr);

void LibZReal_LbfgsSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr);




//*********************** Boost Odeint, ZReal  **********************************

DStatePtr LibZReal_StateInit_Func_N(int N);

void LibZReal_StateClear(DStatePtr x);

void LibZReal_StateGetCoeff(ZRealPtr res, long row, DStatePtr source);

void LibZReal_StateSetCoeff(DStatePtr result, ZRealPtr source, long row);

void LibZReal_StateGetSize(long *result, DStatePtr x);


void LibZReal_Const_RungeKutta4(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);

void LibZReal_Const_RungeKuttaCashKarp54(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);

void LibZReal_Const_RungeKuttaDopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);

void LibZReal_Const_RungeKuttaFehlberg78(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);

void LibZReal_Const_AdamsBashforthMoulton(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);


void LibZReal_Adaptive_RungeKuttaDopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

void LibZReal_Adaptive_RungeKuttaCashKarp54(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

void LibZReal_Adaptive_RungeKuttaFehlberg78(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

void LibZReal_Adaptive_BulirschStoer(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

void LibZReal_DenseOutput_Dopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

void LibZReal_DenseOutput_BulirschStoer(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);









//*********************** Boost Numerical Calculus, ZReal **********************************


void LibZReal_BracketRoot(ZRealPtr res1, ZRealPtr res2, int* iter, ZRealFuncPtr f1, ZRealPtr guess_, ZRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit);

void LibZReal_NewtonRaphson(ZRealPtr res,  int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit);

void LibZReal_Halley(ZRealPtr res, int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit);

void LibZReal_Schroder(ZRealPtr res, int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit);

void LibZReal_Brent_Minimum(ZRealPtr res, ZRealPtr resFx, int* iter, ZRealFuncPtr f1, ZRealPtr bracket_min_, ZRealPtr bracket_max_, int bits, unsigned int maxit);



void LibZReal_Trapezoidal(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_);

void LibZReal_GaussLegendre(ZRealPtr res1, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_);

void LibZReal_GaussKronrod(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_);

void LibZReal_TanhSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_);

void LibZReal_SinhSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1);

void LibZReal_ExpSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1);

void LibZReal_Ooura_Cos(ZRealPtr res1, ZRealPtr res2, ZRealFuncPtr f1);

void LibZReal_Ooura_Sin(ZRealPtr res1, ZRealPtr res2, ZRealFuncPtr f1);





//*********************** Boost Distributions, ZReal **********************************


void LibZReal_ArcsineDist(long Target, ZRealPtr res, ZRealPtr x, ZRealPtr a, ZRealPtr b);

void LibZReal_BernoulliDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr p);

void LibZReal_BetaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b);

void LibZReal_BinomialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr n, ZRealPtr p);

void LibZReal_CauchyDist(long Target, ZRealPtr res, ZRealPtr x, ZRealPtr location, ZRealPtr scale);

void LibZReal_Chi2Dist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu);

void LibZReal_ExponentialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lambda);

void LibZReal_ExtremeValueDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale);

void LibZReal_FisherFDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mu, ZRealPtr nu);

void LibZReal_GammaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale);

void LibZReal_GeometricDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr p);

void LibZReal_HypergeometricDist(long Target, ZRealPtr res, ZRealPtr x, unsigned r, unsigned n, unsigned N);

void LibZReal_InverseChi2Dist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr df, ZRealPtr scale);

void LibZReal_InverseGammaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale);

void LibZReal_InverseGaussianDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr scale);

void LibZReal_LaplaceDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale);

void LibZReal_LogisticDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale);

void LibZReal_LognormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale);

void LibZReal_NegBinomialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr n, ZRealPtr p);

void LibZReal_Chi2NCDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu, ZRealPtr nc);

void LibZReal_StudentTNCDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu, ZRealPtr delta);

void LibZReal_FisherNCDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mu, ZRealPtr nu, ZRealPtr nc);

void LibZReal_BetaNCDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b, ZRealPtr nc);

void LibZReal_NormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr stdev);

void LibZReal_ParetoDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale);

void LibZReal_PoissonDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu);

void LibZReal_RayleighDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu);

void LibZReal_SkewNormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr scale, ZRealPtr shape);

void LibZReal_StudentTDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu);

void LibZReal_TriangularDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lower, ZRealPtr mode_, ZRealPtr upper);

void LibZReal_WeibullDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale);

void LibZReal_UniformDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lower, ZRealPtr upper);




//*********************** Boost Special functions , ZReal **********************************


void LibZReal_Ulp(ZRealPtr res, const ZRealPtr x);

void LibZReal_BernoulliB2n(ZRealPtr res, int n);

void LibZReal_TangentT2n(ZRealPtr res, int n);

void LibZReal_Sqrt1pm1(ZRealPtr res, const ZRealPtr x);



void LibZReal_SinPi(ZRealPtr res, const ZRealPtr x);

void LibZReal_CosPi(ZRealPtr res, const ZRealPtr x);

void LibZReal_TanPi(ZRealPtr res, const ZRealPtr x);

void LibZReal_CscPi(ZRealPtr res, const ZRealPtr x);

void LibZReal_SecPi(ZRealPtr res, const ZRealPtr x);

void LibZReal_CotPi(ZRealPtr res, const ZRealPtr x);



void LibZReal_SincPi(ZRealPtr res, const ZRealPtr x);

void LibZReal_SinhcPi(ZRealPtr res, const ZRealPtr x);


void LibZReal_Tgamma_(ZRealPtr res, const ZRealPtr x);

void LibZReal_Tgamma1pm1(ZRealPtr res, const ZRealPtr x);

void LibZReal_Lgamma_(ZRealPtr res, const ZRealPtr x);

void LibZReal_Digamma(ZRealPtr res, const ZRealPtr x);

void LibZReal_Trigamma(ZRealPtr res, const ZRealPtr x);


void LibZReal_Factorial(ZRealPtr res, const ZRealPtr x);

void LibZReal_DoubleFactorial(ZRealPtr res, const ZRealPtr x);


void LibZReal_Erf_(ZRealPtr res, const ZRealPtr x);

void LibZReal_Erfc_(ZRealPtr res, const ZRealPtr x);

void LibZReal_Erf_inv(ZRealPtr res, const ZRealPtr x);

void LibZReal_Erfc_inv(ZRealPtr res, const ZRealPtr x);


void LibZReal_AiryAi(ZRealPtr res, const ZRealPtr x);

void LibZReal_AiryBi(ZRealPtr res, const ZRealPtr x);

void LibZReal_AiryAiPrime(ZRealPtr res, const ZRealPtr x);

void LibZReal_AiryBiPrime(ZRealPtr res, const ZRealPtr x);

void LibZReal_Aizero(ZRealPtr res, int n);

void LibZReal_Bizero(ZRealPtr res, int n);


void LibZReal_Ellint_1_K(ZRealPtr res, const ZRealPtr x);

void LibZReal_Ellint_2_K(ZRealPtr res, const ZRealPtr x);

void LibZReal_Zeta(ZRealPtr res, const ZRealPtr x);

void LibZReal_Ei(ZRealPtr res, const ZRealPtr x);


void LibZReal_LambertW0(ZRealPtr res, const ZRealPtr x);

void LibZReal_LambertWm1(ZRealPtr res, const ZRealPtr x);

void LibZReal_LambertW0Prime(ZRealPtr res, const ZRealPtr x);

void LibZReal_LambertWm1Prime(ZRealPtr res, const ZRealPtr x);


void LibZReal_Powm1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b);

void LibZReal_TgammaRatio(ZRealPtr res, const ZRealPtr a, const ZRealPtr b);

void LibZReal_TgammaDeltaRatio(ZRealPtr res, const ZRealPtr a, const ZRealPtr b);


void LibZReal_Binomial(ZRealPtr res, const ZRealPtr n, const ZRealPtr k);

void LibZReal_RisingFactorial(ZRealPtr res, const ZRealPtr x, const ZRealPtr n);

void LibZReal_FallingFactorial(ZRealPtr res, const ZRealPtr x, const ZRealPtr n);


void LibZReal_BesselJ(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

void LibZReal_BesselY(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

void LibZReal_BesselI(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

void LibZReal_BesselK(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

void LibZReal_SphBessel(ZRealPtr res, const unsigned v, const ZRealPtr x);

void LibZReal_SphNeumann(ZRealPtr res, const unsigned v, const ZRealPtr x);


void LibZReal_BesselJPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

void LibZReal_BesselYPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

void LibZReal_BesselIPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

void LibZReal_BesselKPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

void LibZReal_SphBesselPrime(ZRealPtr res, const unsigned v, const ZRealPtr x);

void LibZReal_SphNeumannPrime(ZRealPtr res, const unsigned v, const ZRealPtr x);


void LibZReal_BesselJZero(ZRealPtr res, const ZRealPtr v, const int m);

void LibZReal_BesselYZero(ZRealPtr res, const ZRealPtr v, const int m);


void LibZReal_GammaP(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);

void LibZReal_GammaQ(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);

void LibZReal_TgammaLower(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);

void LibZReal_TgammaUpper(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);


void LibZReal_GammaPInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr p);

void LibZReal_GammaQInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr q);

void LibZReal_GammaPInva(ZRealPtr res, const ZRealPtr p, const ZRealPtr x);

void LibZReal_GammaQInva(ZRealPtr res, const ZRealPtr q, const ZRealPtr x);


void LibZReal_GammaPDerivative(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);

void LibZReal_Beta(ZRealPtr res, const ZRealPtr a, const ZRealPtr b);


void LibZReal_LegendreP(ZRealPtr res, int n, const ZRealPtr x);

void LibZReal_LegendreQ(ZRealPtr res, int n, const ZRealPtr x);

void LibZReal_Laguerre(ZRealPtr res, int n, const ZRealPtr x);

void LibZReal_Hermite(ZRealPtr res, int n, const ZRealPtr x);

void LibZReal_ChebyshevT(ZRealPtr res, int n, const ZRealPtr x);

void LibZReal_ChebyshevU(ZRealPtr res, int n, const ZRealPtr x);

void LibZReal_Polygamma(ZRealPtr res, int n, const ZRealPtr x);


void LibZReal_EllintRC(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

void LibZReal_Ellint1F(ZRealPtr res, const ZRealPtr k, const ZRealPtr phi);

void LibZReal_Ellint2F(ZRealPtr res, const ZRealPtr k, const ZRealPtr phi);

void LibZReal_Ellint3K(ZRealPtr res, const ZRealPtr k, const ZRealPtr n);


void LibZReal_JacobiCD(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiCN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiCS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiDC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiDN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiDS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiNC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiND(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiNS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiSC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiSD(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

void LibZReal_JacobiSN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);


void LibZReal_expint(ZRealPtr res, const unsigned n, const ZRealPtr x);

void LibZReal_OwenT(ZRealPtr res, const ZRealPtr h, const ZRealPtr a);


void LibZReal_IBeta(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

void LibZReal_IBetac(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

void LibZReal_IBetaNonNormalized(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

void LibZReal_IBetacNonNormalized(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

void LibZReal_IBetaInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr p);

void LibZReal_IBetacInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr q);

void LibZReal_IBetaInva(ZRealPtr res, const ZRealPtr b, const ZRealPtr x, const ZRealPtr p);

void LibZReal_IBetacInva(ZRealPtr res, const ZRealPtr b, const ZRealPtr x, const ZRealPtr q);

void LibZReal_IBetaInvb(ZRealPtr res, const ZRealPtr a, const ZRealPtr x, const ZRealPtr p);

void LibZReal_IBetacInvb(ZRealPtr res, const ZRealPtr a, const ZRealPtr x, const ZRealPtr q);

void LibZReal_IBetaDerivative(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);


void LibZReal_LegendrePM(ZRealPtr res, const int n, const int m, const ZRealPtr x);

void LibZReal_LaguerreM(ZRealPtr res, const int n, const int m, const ZRealPtr x);


void LibZReal_EllipticRF(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z);

void LibZReal_EllipticRD(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z);

void LibZReal_Ellint3F(ZRealPtr res, const ZRealPtr k, const ZRealPtr n, const ZRealPtr phi);


void LibZReal_SphericalHarmonicR(ZRealPtr res, const int n, const int m, const ZRealPtr theta, const ZRealPtr phi);

void LibZReal_SphericalHarmonicI(ZRealPtr res, const int n, const int m, const ZRealPtr theta, const ZRealPtr phi);

void LibZReal_EllipticRJ(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z, const ZRealPtr p);


void LibZReal_Hypergeo0F1(ZRealPtr res, const ZRealPtr b, const ZRealPtr x);

void LibZReal_Hypergeo1F1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

void LibZReal_Hypergeo1F1r(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

void LibZReal_LogHypergeo1F1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);


void LibZReal_JacobiTheta1(ZRealPtr res, const ZRealPtr x, const ZRealPtr q);

void LibZReal_JacobiTheta2(ZRealPtr res, const ZRealPtr x, const ZRealPtr q);

void LibZReal_JacobiTheta3(ZRealPtr res, const ZRealPtr x, const ZRealPtr q);

void LibZReal_JacobiTheta4(ZRealPtr res, const ZRealPtr x, const ZRealPtr q);

















//*********************** Real Basic Functions, ZReal **********************************



ZRealPtr LibZReal_Init_Func();

void LibZReal_Clear(ZRealPtr x);


void LibZReal_Get_Str(char* cstr, ZRealPtr x);


void LibZReal_Set_Str(ZRealPtr res, const char * str);


void LibZReal_Set(ZRealPtr res, const ZRealPtr x);


void LibZReal_Neg(ZRealPtr res, const ZRealPtr x);


void LibZReal_Set_LD(ZRealPtr res, const long double* x);


void LibZReal_Set_D(ZRealPtr res, const double x);


void LibZReal_Set_S(ZRealPtr res, const float* x);


void LibZReal_Set_Si(ZRealPtr res, const int32_t x);


void LibZReal_Set_Si64(ZRealPtr res, const int64_t x);


void LibZReal_Set_Ui(ZRealPtr res, const uint32_t x);


void LibZReal_Set_Ui64(ZRealPtr res, const uint64_t x);





void LibZReal_Add(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Sub(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Mul(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Div(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);


void LibZReal_Add_D(ZRealPtr res, const ZRealPtr x, const double y);
void LibZReal_Sub_D(ZRealPtr res, const ZRealPtr x, const double y);
void LibZReal_D_Sub(ZRealPtr res, const ZRealPtr x, const double y);

void LibZReal_Mul_D(ZRealPtr res, const ZRealPtr x, const double y);
void LibZReal_Div_D(ZRealPtr res, const ZRealPtr x, const double y);
void LibZReal_D_Div(ZRealPtr res, const ZRealPtr x, const double y);


void LibZReal_Add_Si(ZRealPtr res, const ZRealPtr x, const int32_t y);
void LibZReal_Sub_Si(ZRealPtr res, const ZRealPtr x, const int32_t y);
void LibZReal_Si_Sub(ZRealPtr res, const ZRealPtr x, const int32_t y);

void LibZReal_Mul_Si(ZRealPtr res, const ZRealPtr x, const int32_t y);
void LibZReal_Div_Si(ZRealPtr res, const ZRealPtr x, const int32_t y);
void LibZReal_Si_Div(ZRealPtr res, const ZRealPtr x, const int32_t y);







int32_t LibZReal_LT(const ZRealPtr x, const ZRealPtr y);
int32_t LibZReal_GE(const ZRealPtr x, const ZRealPtr y);
int32_t LibZReal_GT(const ZRealPtr x, const ZRealPtr y);
int32_t LibZReal_LE(const ZRealPtr x, const ZRealPtr y);
int32_t LibZReal_EQ(const ZRealPtr x, const ZRealPtr y);
int32_t LibZReal_NE(const ZRealPtr x, const ZRealPtr y);






/* General functions for real numbers  */

void LibZReal_Fma(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z);
void LibZReal_Fmax(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Fmin(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);




/* Machine constants */

void LibZReal_Zero(ZRealPtr res);
void LibZReal_NegZero(ZRealPtr res);
void LibZReal_One(ZRealPtr res);
void LibZReal_Inf(ZRealPtr res);
void LibZReal_NegInf(ZRealPtr res);
void LibZReal_Nan(ZRealPtr res);




/* Properties of numbers  */

int LibZReal_Signbit(const ZRealPtr x);
int LibZReal_Finite(const ZRealPtr x);
int LibZReal_Isinf(const ZRealPtr x);
int LibZReal_Isposinf(const ZRealPtr x);
int LibZReal_Isneginf(const ZRealPtr x);
int LibZReal_Isnan(const ZRealPtr x);

int LibZReal_Iszero(const ZRealPtr x);
int LibZReal_Isposzero(const ZRealPtr x);
int LibZReal_Isnegzero(const ZRealPtr x);
int LibZReal_Isone(const ZRealPtr x);
int LibZReal_Isinteger(const ZRealPtr x);

int LibZReal_Isnumber(const ZRealPtr x);
int LibZReal_Isregular(const ZRealPtr x);
int LibZReal_Isnormal(const ZRealPtr x);
int LibZReal_Issubnormal(const ZRealPtr x);
int LibZReal_Isunordered(const ZRealPtr x, const ZRealPtr y);

int LibZReal_FitsInt32(const ZRealPtr x);
int LibZReal_FitsInt64(const ZRealPtr x);
int LibZReal_FitsUInt32(const ZRealPtr x);
int LibZReal_FitsUInt64(const ZRealPtr x);





/* Integer Related Functions  */

void LibZReal_Nearbyint(ZRealPtr res, const ZRealPtr x);
void LibZReal_Rint(ZRealPtr res, const ZRealPtr x);
long int LibZReal_Lrint(const ZRealPtr x);
long long int LibZReal_Llrint(const ZRealPtr x);

void LibZReal_Ceil(ZRealPtr res, const ZRealPtr x);
void LibZReal_Floor(ZRealPtr res, const ZRealPtr x);
void LibZReal_Trunc(ZRealPtr res, const ZRealPtr x);

void LibZReal_Round(ZRealPtr res, const ZRealPtr x);
long int LibZReal_Lround(const ZRealPtr x);
long long int LibZReal_Llround(const ZRealPtr x);

int32_t LibZReal_ToInt32(const ZRealPtr x);
int64_t LibZReal_ToInt64(const ZRealPtr x);

uint32_t LibZReal_ToUInt32(const ZRealPtr x);
uint64_t LibZReal_ToUInt64(const ZRealPtr x);



/* Floating point functions for real numbers */

void LibZReal_Copysign(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

void LibZReal_Frexp(ZRealPtr res, const ZRealPtr x, int* e);
void LibZReal_Logb(ZRealPtr res, const ZRealPtr x);
int LibZReal_Ilogb(const ZRealPtr x);

void LibZReal_Ldexp(ZRealPtr res, const ZRealPtr x, const int e);
void LibZReal_Scalbln(ZRealPtr res, const ZRealPtr x, const long int e);
void LibZReal_Scalbn(ZRealPtr res, const ZRealPtr x, const int e);

void LibZReal_Fdim(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);




/* Fraction and Remainder Related Functions  */

void LibZReal_Modf(ZRealPtr frac, const ZRealPtr x, ZRealPtr iptr);
void LibZReal_Fmod(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Remainder(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Remquo(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, int* e);




/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

void LibZReal_Epsilon(ZRealPtr res);
void LibZReal_Max(ZRealPtr res);
void LibZReal_Min(ZRealPtr res);
void LibZReal_Lowest(ZRealPtr res);
void LibZReal_Nexttowards(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Nextabove(ZRealPtr res, const ZRealPtr x);
void LibZReal_Nextbelow(ZRealPtr res, const ZRealPtr x);



/* Complex components  */

void LibZReal_Fabs(ZRealPtr res, const ZRealPtr x);
void LibZReal_Sign(ZRealPtr res, const ZRealPtr x);



/* Mathematical Constants  */

void LibZReal_Pi(ZRealPtr res);
void LibZReal_E(ZRealPtr res);



/* Roots and related functions  */

void LibZReal_Sqrt(ZRealPtr res, const ZRealPtr x);
void LibZReal_Rsqrt(ZRealPtr res, const ZRealPtr x);
void LibZReal_Cbrt(ZRealPtr res, const ZRealPtr x);
void LibZReal_Root_Si(ZRealPtr res, const ZRealPtr x, const int32_t k_);


/* Exponential and related functions  */

void LibZReal_Exp(ZRealPtr res, const ZRealPtr x);
void LibZReal_Exp2(ZRealPtr res, const ZRealPtr x);
void LibZReal_Exp10(ZRealPtr res, const ZRealPtr x);

void LibZReal_Expm1(ZRealPtr res, const ZRealPtr x);
void LibZReal_Exp2m1(ZRealPtr res, const ZRealPtr x);
void LibZReal_Exp10m1(ZRealPtr res, const ZRealPtr x);


/* Logarithms and related functions  */

void LibZReal_Log(ZRealPtr res, const ZRealPtr x);
void LibZReal_Log2(ZRealPtr res, const ZRealPtr x);
void LibZReal_Log10(ZRealPtr res, const ZRealPtr x);

void LibZReal_Log1p(ZRealPtr res, const ZRealPtr x);
void LibZReal_Log2p1(ZRealPtr res, const ZRealPtr x);
void LibZReal_Log10p1(ZRealPtr res, const ZRealPtr x);



/* Power functions */

void LibZReal_Square(ZRealPtr res, const ZRealPtr x);
void LibZReal_Cube(ZRealPtr res, const ZRealPtr x);
void LibZReal_Hypot(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

void LibZReal_Pow(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Pow1p(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
void LibZReal_Pow1pm1(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

void LibZReal_Pow_Si(ZRealPtr res, const ZRealPtr x, const int32_t k_);
void LibZReal_Compound_Si(ZRealPtr res, const ZRealPtr x, const int32_t k_);


/* Trigonometric functions  */

void LibZReal_Sin(ZRealPtr res, const ZRealPtr x);
void LibZReal_Cos(ZRealPtr res, const ZRealPtr x);
void LibZReal_Tan(ZRealPtr res, const ZRealPtr x);

void LibZReal_Csc(ZRealPtr res, const ZRealPtr x);
void LibZReal_Sec(ZRealPtr res, const ZRealPtr x);
void LibZReal_Cot(ZRealPtr res, const ZRealPtr x);


/* Hyperbolic functions  */

void LibZReal_Sinh(ZRealPtr res, const ZRealPtr x);
void LibZReal_Cosh(ZRealPtr res, const ZRealPtr x);
void LibZReal_Tanh(ZRealPtr res, const ZRealPtr x);

void LibZReal_Csch(ZRealPtr res, const ZRealPtr x);
void LibZReal_Sech(ZRealPtr res, const ZRealPtr x);
void LibZReal_Coth(ZRealPtr res, const ZRealPtr x);



/* Inverse trigonometric functions  */

void LibZReal_Acos(ZRealPtr res, const ZRealPtr x);
void LibZReal_Asin(ZRealPtr res, const ZRealPtr x);
void LibZReal_Atan(ZRealPtr res, const ZRealPtr x);
void LibZReal_Atan2(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

void LibZReal_Acsc(ZRealPtr res, const ZRealPtr x);
void LibZReal_Asec(ZRealPtr res, const ZRealPtr x);
void LibZReal_Acot(ZRealPtr res, const ZRealPtr x);


/* Inverse hyperbolic functions  */

void LibZReal_Acosh(ZRealPtr res, const ZRealPtr x);
void LibZReal_Asinh(ZRealPtr res, const ZRealPtr x);
void LibZReal_Atanh(ZRealPtr res, const ZRealPtr x);

void LibZReal_Acsch(ZRealPtr res, const ZRealPtr x);
void LibZReal_Asech(ZRealPtr res, const ZRealPtr x);
void LibZReal_Acoth(ZRealPtr res, const ZRealPtr x);



/* Special functions  */

void LibZReal_Erf(ZRealPtr res, const ZRealPtr x);
void LibZReal_Erfc(ZRealPtr res, const ZRealPtr x);

void LibZReal_Tgamma(ZRealPtr res, const ZRealPtr x);
void LibZReal_Lgamma(ZRealPtr res, const ZRealPtr x);

void LibZReal_J0(ZRealPtr res, const ZRealPtr x);
void LibZReal_J1(ZRealPtr res, const ZRealPtr x);
void LibZReal_Jn(ZRealPtr res, const int n, const ZRealPtr x);

void LibZReal_Y0(ZRealPtr res, const ZRealPtr x);
void LibZReal_Y1(ZRealPtr res, const ZRealPtr x);
void LibZReal_Yn(ZRealPtr res, const int n, const ZRealPtr x);









//*********************** Complex **********************************


ZCplxPtr LibZCplx_Init_Func();
void LibZCplx_Clear(ZCplxPtr x);

void LibZCplx_Get_Str_Real(char* cstr, ZCplxPtr x);
void LibZCplx_Get_Str_Imag(char* cstr, ZCplxPtr x);




void LibZCplx_Neg(ZCplxPtr res, const ZCplxPtr x);



void LibZCplx_Add(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
void LibZCplx_Sub(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
void LibZCplx_Mul(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
void LibZCplx_Div(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);


void LibZCplx_Add_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y);
void LibZCplx_Sub_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y);
void LibZCplx_ZReal_Sub(ZCplxPtr res, const ZCplxPtr y, const ZRealPtr x);

void LibZCplx_Mul_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y);
void LibZCplx_Div_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y);
void LibZCplx_ZReal_Div(ZCplxPtr res, const ZCplxPtr y, const ZRealPtr x);


void LibZCplx_Add_D(ZCplxPtr res, const ZCplxPtr x, const double y);
void LibZCplx_Sub_D(ZCplxPtr res, const ZCplxPtr x, const double y);
void LibZCplx_D_Sub(ZCplxPtr res, const ZCplxPtr y, const double x);

void LibZCplx_Mul_D(ZCplxPtr res, const ZCplxPtr x, const double y);
void LibZCplx_Div_D(ZCplxPtr res, const ZCplxPtr x, const double y);
void LibZCplx_D_Div(ZCplxPtr res, const ZCplxPtr y, const double x);


void LibZCplx_Add_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y);
void LibZCplx_Sub_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y);
void LibZCplx_Si_Sub(ZCplxPtr res, const ZCplxPtr y, const int32_t x);

void LibZCplx_Mul_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y);
void LibZCplx_Div_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y);
void LibZCplx_Si_Div(ZCplxPtr res, const ZCplxPtr y, const int32_t x);





/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void LibZCplx_Set(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Set_Real(ZCplxPtr res, const ZRealPtr re);
void LibZCplx_Set2(ZCplxPtr res, const ZRealPtr re, const ZRealPtr im);

void LibZCplx_Set2_Str2(ZRealPtr res, const char * str_re, const char * str_im);

void LibZCplx_Abs(ZRealPtr res, const ZCplxPtr x);
void LibZCplx_Arg(ZRealPtr res, const ZCplxPtr x);
void LibZCplx_Imag(ZRealPtr res, const ZCplxPtr x);
void LibZCplx_Real(ZRealPtr res, const ZCplxPtr x);
void LibZCplx_Conj(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Proj(ZCplxPtr res, const ZCplxPtr x);



/* Roots  */

void LibZCplx_Sqrt(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Sqrt1pm1(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_Rsqrt(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Cbrt(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Root_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k);


/* Exponential and related functions  */

void LibZCplx_Exp(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Expi(ZCplxPtr res, const ZRealPtr x);
void LibZCplx_Exp2(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Exp10(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_Expm1(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Exp2m1(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Exp10m1(ZCplxPtr res, const ZCplxPtr x);



/* Logarithms and related functions  */

void LibZCplx_Log(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Log2(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Log10(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_Log1p(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Log2p1(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Log10p1(ZCplxPtr res, const ZCplxPtr x);




/* Power functions and roots  */

void LibZCplx_Square(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Cube(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_Pow(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
void LibZCplx_Powm1(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
void LibZCplx_Pow1p(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
void LibZCplx_Pow1pm1(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);

void LibZCplx_Pow_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k);
void LibZCplx_Compound_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k);



/* Trigonometric functions  */

void LibZCplx_Sin(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Cos(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Tan(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_Csc(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Sec(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Cot(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_SinPi(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_CosPi(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_TanPi(ZCplxPtr res, const ZCplxPtr x);



/* Hyperbolic functions  */

void LibZCplx_Sinh(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Cosh(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Tanh(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_Csch(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Sech(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Coth(ZCplxPtr res, const ZCplxPtr x);


/* Inverse trigonometric functions  */

void LibZCplx_Asin(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Acos(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Atan(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_Acsc(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Asec(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Acot(ZCplxPtr res, const ZCplxPtr x);



/* Inverse hyperbolic functions  */

void LibZCplx_Asinh(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Acosh(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Atanh(ZCplxPtr res, const ZCplxPtr x);

void LibZCplx_Acsch(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Asech(ZCplxPtr res, const ZCplxPtr x);
void LibZCplx_Acoth(ZCplxPtr res, const ZCplxPtr x);






