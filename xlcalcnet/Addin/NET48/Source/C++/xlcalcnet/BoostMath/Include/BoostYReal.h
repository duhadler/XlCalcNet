
#include "stdint.h"



typedef void* YRealPtr;
typedef void* YCplxPtr;

typedef void* DStatePtr;

typedef void(*YRealFuncPtr) (void*, void*);
typedef void(*DAnyFuncPtr2) (const void*,const  void*);
typedef void(*DAnyFuncPtr3) (const void*,const  void*,const  void*);




//*********************** Boost/CppOptLib **********************************

void LibYReal_GradientDescentSolverSolver(YRealFuncPtr f1, YRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr);

void LibYReal_ConjugatedGradientDescentSolver(YRealFuncPtr f1, YRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr);

void LibYReal_BfgsSolver(YRealFuncPtr f1, YRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr);

void LibYReal_LbfgsSolver(YRealFuncPtr f1, YRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr);




//*********************** Boost Odeint, YReal  **********************************

DStatePtr LibYReal_StateInit_Func_N(int N);

void LibYReal_StateClear(DStatePtr x);

void LibYReal_StateGetCoeff(YRealPtr res, long row, DStatePtr source);

void LibYReal_StateSetCoeff(DStatePtr result, YRealPtr source, long row);

void LibYReal_StateGetSize(long *result, DStatePtr x);


void LibYReal_Const_RungeKutta4(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);

void LibYReal_Const_RungeKuttaCashKarp54(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);

void LibYReal_Const_RungeKuttaDopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);

void LibYReal_Const_RungeKuttaFehlberg78(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);

void LibYReal_Const_AdamsBashforthMoulton(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);


void LibYReal_Adaptive_RungeKuttaDopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

void LibYReal_Adaptive_RungeKuttaCashKarp54(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

void LibYReal_Adaptive_RungeKuttaFehlberg78(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

void LibYReal_Adaptive_BulirschStoer(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

void LibYReal_DenseOutput_Dopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

void LibYReal_DenseOutput_BulirschStoer(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);









//*********************** Boost Numerical Calculus, YReal **********************************


void LibYReal_BracketRoot(YRealPtr res1, YRealPtr res2, int* iter, YRealFuncPtr f1, YRealPtr guess_, YRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit);

void LibYReal_NewtonRaphson(YRealPtr res,  int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit);

void LibYReal_Halley(YRealPtr res, int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit);

void LibYReal_Schroder(YRealPtr res, int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit);

void LibYReal_Brent_Minimum(YRealPtr res, YRealPtr resFx, int* iter, YRealFuncPtr f1, YRealPtr bracket_min_, YRealPtr bracket_max_, int bits, unsigned int maxit);



void LibYReal_Trapezoidal(YRealPtr res1, YRealPtr res2, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_);

void LibYReal_GaussLegendre(YRealPtr res1, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_);

void LibYReal_GaussKronrod(YRealPtr res1, YRealPtr res2, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_);

void LibYReal_TanhSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_);

void LibYReal_SinhSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1);

void LibYReal_ExpSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1);

void LibYReal_Ooura_Cos(YRealPtr res1, YRealPtr res2, YRealFuncPtr f1);

void LibYReal_Ooura_Sin(YRealPtr res1, YRealPtr res2, YRealFuncPtr f1);





//*********************** Boost Distributions, YReal **********************************


void LibYReal_ArcsineDist(long Target, YRealPtr res, YRealPtr x, YRealPtr a, YRealPtr b);

void LibYReal_BernoulliDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr p);

void LibYReal_BetaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b);

void LibYReal_BinomialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr n, YRealPtr p);

void LibYReal_CauchyDist(long Target, YRealPtr res, YRealPtr x, YRealPtr location, YRealPtr scale);

void LibYReal_Chi2Dist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu);

void LibYReal_ExponentialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lambda);

void LibYReal_ExtremeValueDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale);

void LibYReal_FisherFDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mu, YRealPtr nu);

void LibYReal_GammaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale);

void LibYReal_GeometricDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr p);

void LibYReal_HypergeometricDist(long Target, YRealPtr res, YRealPtr x, unsigned r, unsigned n, unsigned N);

void LibYReal_InverseChi2Dist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr df, YRealPtr scale);

void LibYReal_InverseGammaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale);

void LibYReal_InverseGaussianDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr scale);

void LibYReal_LaplaceDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale);

void LibYReal_LogisticDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale);

void LibYReal_LognormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale);

void LibYReal_NegBinomialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr n, YRealPtr p);

void LibYReal_Chi2NCDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu, YRealPtr nc);

void LibYReal_StudentTNCDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu, YRealPtr delta);

void LibYReal_FisherNCDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mu, YRealPtr nu, YRealPtr nc);

void LibYReal_BetaNCDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b, YRealPtr nc);

void LibYReal_NormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr stdev);

void LibYReal_ParetoDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale);

void LibYReal_PoissonDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu);

void LibYReal_RayleighDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu);

void LibYReal_SkewNormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr scale, YRealPtr shape);

void LibYReal_StudentTDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu);

void LibYReal_TriangularDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lower, YRealPtr mode_, YRealPtr upper);

void LibYReal_WeibullDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale);

void LibYReal_UniformDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lower, YRealPtr upper);




//*********************** Boost Special functions , YReal **********************************


void LibYReal_Ulp(YRealPtr res, const YRealPtr x);

void LibYReal_BernoulliB2n(YRealPtr res, int n);

void LibYReal_TangentT2n(YRealPtr res, int n);

void LibYReal_Sqrt1pm1(YRealPtr res, const YRealPtr x);



void LibYReal_SinPi(YRealPtr res, const YRealPtr x);

void LibYReal_CosPi(YRealPtr res, const YRealPtr x);

void LibYReal_TanPi(YRealPtr res, const YRealPtr x);

void LibYReal_CscPi(YRealPtr res, const YRealPtr x);

void LibYReal_SecPi(YRealPtr res, const YRealPtr x);

void LibYReal_CotPi(YRealPtr res, const YRealPtr x);



void LibYReal_SincPi(YRealPtr res, const YRealPtr x);

void LibYReal_SinhcPi(YRealPtr res, const YRealPtr x);


void LibYReal_Tgamma_(YRealPtr res, const YRealPtr x);

void LibYReal_Tgamma1pm1(YRealPtr res, const YRealPtr x);

void LibYReal_Lgamma_(YRealPtr res, const YRealPtr x);

void LibYReal_Digamma(YRealPtr res, const YRealPtr x);

void LibYReal_Trigamma(YRealPtr res, const YRealPtr x);


void LibYReal_Factorial(YRealPtr res, const YRealPtr x);

void LibYReal_DoubleFactorial(YRealPtr res, const YRealPtr x);


void LibYReal_Erf_(YRealPtr res, const YRealPtr x);

void LibYReal_Erfc_(YRealPtr res, const YRealPtr x);

void LibYReal_Erf_inv(YRealPtr res, const YRealPtr x);

void LibYReal_Erfc_inv(YRealPtr res, const YRealPtr x);


void LibYReal_AiryAi(YRealPtr res, const YRealPtr x);

void LibYReal_AiryBi(YRealPtr res, const YRealPtr x);

void LibYReal_AiryAiPrime(YRealPtr res, const YRealPtr x);

void LibYReal_AiryBiPrime(YRealPtr res, const YRealPtr x);

void LibYReal_Aizero(YRealPtr res, int n);

void LibYReal_Bizero(YRealPtr res, int n);


void LibYReal_Ellint_1_K(YRealPtr res, const YRealPtr x);

void LibYReal_Ellint_2_K(YRealPtr res, const YRealPtr x);

void LibYReal_Zeta(YRealPtr res, const YRealPtr x);

void LibYReal_Ei(YRealPtr res, const YRealPtr x);


void LibYReal_LambertW0(YRealPtr res, const YRealPtr x);

void LibYReal_LambertWm1(YRealPtr res, const YRealPtr x);

void LibYReal_LambertW0Prime(YRealPtr res, const YRealPtr x);

void LibYReal_LambertWm1Prime(YRealPtr res, const YRealPtr x);


void LibYReal_Powm1(YRealPtr res, const YRealPtr a, const YRealPtr b);

void LibYReal_TgammaRatio(YRealPtr res, const YRealPtr a, const YRealPtr b);

void LibYReal_TgammaDeltaRatio(YRealPtr res, const YRealPtr a, const YRealPtr b);


void LibYReal_Binomial(YRealPtr res, const YRealPtr n, const YRealPtr k);

void LibYReal_RisingFactorial(YRealPtr res, const YRealPtr x, const YRealPtr n);

void LibYReal_FallingFactorial(YRealPtr res, const YRealPtr x, const YRealPtr n);


void LibYReal_BesselJ(YRealPtr res, const YRealPtr v, const YRealPtr x);

void LibYReal_BesselY(YRealPtr res, const YRealPtr v, const YRealPtr x);

void LibYReal_BesselI(YRealPtr res, const YRealPtr v, const YRealPtr x);

void LibYReal_BesselK(YRealPtr res, const YRealPtr v, const YRealPtr x);

void LibYReal_SphBessel(YRealPtr res, const unsigned v, const YRealPtr x);

void LibYReal_SphNeumann(YRealPtr res, const unsigned v, const YRealPtr x);


void LibYReal_BesselJPrime(YRealPtr res, const YRealPtr v, const YRealPtr x);

void LibYReal_BesselYPrime(YRealPtr res, const YRealPtr v, const YRealPtr x);

void LibYReal_BesselIPrime(YRealPtr res, const YRealPtr v, const YRealPtr x);

void LibYReal_BesselKPrime(YRealPtr res, const YRealPtr v, const YRealPtr x);

void LibYReal_SphBesselPrime(YRealPtr res, const unsigned v, const YRealPtr x);

void LibYReal_SphNeumannPrime(YRealPtr res, const unsigned v, const YRealPtr x);


void LibYReal_BesselJZero(YRealPtr res, const YRealPtr v, const int m);

void LibYReal_BesselYZero(YRealPtr res, const YRealPtr v, const int m);


void LibYReal_GammaP(YRealPtr res, const YRealPtr a, const YRealPtr x);

void LibYReal_GammaQ(YRealPtr res, const YRealPtr a, const YRealPtr x);

void LibYReal_TgammaLower(YRealPtr res, const YRealPtr a, const YRealPtr x);

void LibYReal_TgammaUpper(YRealPtr res, const YRealPtr a, const YRealPtr x);


void LibYReal_GammaPInv(YRealPtr res, const YRealPtr a, const YRealPtr p);

void LibYReal_GammaQInv(YRealPtr res, const YRealPtr a, const YRealPtr q);

void LibYReal_GammaPInva(YRealPtr res, const YRealPtr p, const YRealPtr x);

void LibYReal_GammaQInva(YRealPtr res, const YRealPtr q, const YRealPtr x);


void LibYReal_GammaPDerivative(YRealPtr res, const YRealPtr a, const YRealPtr x);

void LibYReal_Beta(YRealPtr res, const YRealPtr a, const YRealPtr b);


void LibYReal_LegendreP(YRealPtr res, int n, const YRealPtr x);

void LibYReal_LegendreQ(YRealPtr res, int n, const YRealPtr x);

void LibYReal_Laguerre(YRealPtr res, int n, const YRealPtr x);

void LibYReal_Hermite(YRealPtr res, int n, const YRealPtr x);

void LibYReal_ChebyshevT(YRealPtr res, int n, const YRealPtr x);

void LibYReal_ChebyshevU(YRealPtr res, int n, const YRealPtr x);

void LibYReal_Polygamma(YRealPtr res, int n, const YRealPtr x);


void LibYReal_EllintRC(YRealPtr res, const YRealPtr x, const YRealPtr y);

void LibYReal_Ellint1F(YRealPtr res, const YRealPtr k, const YRealPtr phi);

void LibYReal_Ellint2F(YRealPtr res, const YRealPtr k, const YRealPtr phi);

void LibYReal_Ellint3K(YRealPtr res, const YRealPtr k, const YRealPtr n);


void LibYReal_JacobiCD(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiCN(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiCS(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiDC(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiDN(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiDS(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiNC(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiND(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiNS(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiSC(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiSD(YRealPtr res, const YRealPtr k, const YRealPtr u);

void LibYReal_JacobiSN(YRealPtr res, const YRealPtr k, const YRealPtr u);


void LibYReal_expint(YRealPtr res, const unsigned n, const YRealPtr x);

void LibYReal_OwenT(YRealPtr res, const YRealPtr h, const YRealPtr a);


void LibYReal_IBeta(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

void LibYReal_IBetac(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

void LibYReal_IBetaNonNormalized(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

void LibYReal_IBetacNonNormalized(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

void LibYReal_IBetaInv(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr p);

void LibYReal_IBetacInv(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr q);

void LibYReal_IBetaInva(YRealPtr res, const YRealPtr b, const YRealPtr x, const YRealPtr p);

void LibYReal_IBetacInva(YRealPtr res, const YRealPtr b, const YRealPtr x, const YRealPtr q);

void LibYReal_IBetaInvb(YRealPtr res, const YRealPtr a, const YRealPtr x, const YRealPtr p);

void LibYReal_IBetacInvb(YRealPtr res, const YRealPtr a, const YRealPtr x, const YRealPtr q);

void LibYReal_IBetaDerivative(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);


void LibYReal_LegendrePM(YRealPtr res, const int n, const int m, const YRealPtr x);

void LibYReal_LaguerreM(YRealPtr res, const int n, const int m, const YRealPtr x);


void LibYReal_EllipticRF(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z);

void LibYReal_EllipticRD(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z);

void LibYReal_Ellint3F(YRealPtr res, const YRealPtr k, const YRealPtr n, const YRealPtr phi);


void LibYReal_SphericalHarmonicR(YRealPtr res, const int n, const int m, const YRealPtr theta, const YRealPtr phi);

void LibYReal_SphericalHarmonicI(YRealPtr res, const int n, const int m, const YRealPtr theta, const YRealPtr phi);

void LibYReal_EllipticRJ(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z, const YRealPtr p);


void LibYReal_Hypergeo0F1(YRealPtr res, const YRealPtr b, const YRealPtr x);

void LibYReal_Hypergeo1F1(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

void LibYReal_Hypergeo1F1r(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

void LibYReal_LogHypergeo1F1(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);


void LibYReal_JacobiTheta1(YRealPtr res, const YRealPtr x, const YRealPtr q);

void LibYReal_JacobiTheta2(YRealPtr res, const YRealPtr x, const YRealPtr q);

void LibYReal_JacobiTheta3(YRealPtr res, const YRealPtr x, const YRealPtr q);

void LibYReal_JacobiTheta4(YRealPtr res, const YRealPtr x, const YRealPtr q);

















//*********************** Real Basic Functions, YReal **********************************



YRealPtr LibYReal_Init_Func();

void LibYReal_Clear(YRealPtr x);


void LibYReal_Get_Str(char* cstr, YRealPtr x);


void LibYReal_Set_Str(YRealPtr res, const char * str);


void LibYReal_Set(YRealPtr res, const YRealPtr x);


void LibYReal_Neg(YRealPtr res, const YRealPtr x);


void LibYReal_Set_LD(YRealPtr res, const long double* x);


void LibYReal_Set_D(YRealPtr res, const double x);


void LibYReal_Set_S(YRealPtr res, const float* x);


void LibYReal_Set_Si(YRealPtr res, const int32_t x);


void LibYReal_Set_Si64(YRealPtr res, const int64_t x);


void LibYReal_Set_Ui(YRealPtr res, const uint32_t x);


void LibYReal_Set_Ui64(YRealPtr res, const uint64_t x);





void LibYReal_Add(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Sub(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Mul(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Div(YRealPtr res, const YRealPtr x, const YRealPtr y);


void LibYReal_Add_D(YRealPtr res, const YRealPtr x, const double y);
void LibYReal_Sub_D(YRealPtr res, const YRealPtr x, const double y);
void LibYReal_D_Sub(YRealPtr res, const YRealPtr x, const double y);

void LibYReal_Mul_D(YRealPtr res, const YRealPtr x, const double y);
void LibYReal_Div_D(YRealPtr res, const YRealPtr x, const double y);
void LibYReal_D_Div(YRealPtr res, const YRealPtr x, const double y);


void LibYReal_Add_Si(YRealPtr res, const YRealPtr x, const int32_t y);
void LibYReal_Sub_Si(YRealPtr res, const YRealPtr x, const int32_t y);
void LibYReal_Si_Sub(YRealPtr res, const YRealPtr x, const int32_t y);

void LibYReal_Mul_Si(YRealPtr res, const YRealPtr x, const int32_t y);
void LibYReal_Div_Si(YRealPtr res, const YRealPtr x, const int32_t y);
void LibYReal_Si_Div(YRealPtr res, const YRealPtr x, const int32_t y);







int32_t LibYReal_LT(const YRealPtr x, const YRealPtr y);
int32_t LibYReal_GE(const YRealPtr x, const YRealPtr y);
int32_t LibYReal_GT(const YRealPtr x, const YRealPtr y);
int32_t LibYReal_LE(const YRealPtr x, const YRealPtr y);
int32_t LibYReal_EQ(const YRealPtr x, const YRealPtr y);
int32_t LibYReal_NE(const YRealPtr x, const YRealPtr y);






/* General functions for real numbers  */

void LibYReal_Fma(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z);
void LibYReal_Fmax(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Fmin(YRealPtr res, const YRealPtr x, const YRealPtr y);




/* Machine constants */

void LibYReal_Zero(YRealPtr res);
void LibYReal_NegZero(YRealPtr res);
void LibYReal_One(YRealPtr res);
void LibYReal_Inf(YRealPtr res);
void LibYReal_NegInf(YRealPtr res);
void LibYReal_Nan(YRealPtr res);




/* Properties of numbers  */

int LibYReal_Signbit(const YRealPtr x);
int LibYReal_Finite(const YRealPtr x);
int LibYReal_Isinf(const YRealPtr x);
int LibYReal_Isposinf(const YRealPtr x);
int LibYReal_Isneginf(const YRealPtr x);
int LibYReal_Isnan(const YRealPtr x);

int LibYReal_Iszero(const YRealPtr x);
int LibYReal_Isposzero(const YRealPtr x);
int LibYReal_Isnegzero(const YRealPtr x);
int LibYReal_Isone(const YRealPtr x);
int LibYReal_Isinteger(const YRealPtr x);

int LibYReal_Isnumber(const YRealPtr x);
int LibYReal_Isregular(const YRealPtr x);
int LibYReal_Isnormal(const YRealPtr x);
int LibYReal_Issubnormal(const YRealPtr x);
int LibYReal_Isunordered(const YRealPtr x, const YRealPtr y);

int LibYReal_FitsInt32(const YRealPtr x);
int LibYReal_FitsInt64(const YRealPtr x);
int LibYReal_FitsUInt32(const YRealPtr x);
int LibYReal_FitsUInt64(const YRealPtr x);





/* Integer Related Functions  */

void LibYReal_Nearbyint(YRealPtr res, const YRealPtr x);
void LibYReal_Rint(YRealPtr res, const YRealPtr x);
long int LibYReal_Lrint(const YRealPtr x);
long long int LibYReal_Llrint(const YRealPtr x);

void LibYReal_Ceil(YRealPtr res, const YRealPtr x);
void LibYReal_Floor(YRealPtr res, const YRealPtr x);
void LibYReal_Trunc(YRealPtr res, const YRealPtr x);

void LibYReal_Round(YRealPtr res, const YRealPtr x);
long int LibYReal_Lround(const YRealPtr x);
long long int LibYReal_Llround(const YRealPtr x);

int32_t LibYReal_ToInt32(const YRealPtr x);
int64_t LibYReal_ToInt64(const YRealPtr x);

uint32_t LibYReal_ToUInt32(const YRealPtr x);
uint64_t LibYReal_ToUInt64(const YRealPtr x);



/* Floating point functions for real numbers */

void LibYReal_Copysign(YRealPtr res, const YRealPtr x, const YRealPtr y);

void LibYReal_Frexp(YRealPtr res, const YRealPtr x, int* e);
void LibYReal_Logb(YRealPtr res, const YRealPtr x);
int LibYReal_Ilogb(const YRealPtr x);

void LibYReal_Ldexp(YRealPtr res, const YRealPtr x, const int e);
void LibYReal_Scalbln(YRealPtr res, const YRealPtr x, const long int e);
void LibYReal_Scalbn(YRealPtr res, const YRealPtr x, const int e);

void LibYReal_Fdim(YRealPtr res, const YRealPtr x, const YRealPtr y);




/* Fraction and Remainder Related Functions  */

void LibYReal_Modf(YRealPtr frac, const YRealPtr x, YRealPtr iptr);
void LibYReal_Fmod(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Remainder(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Remquo(YRealPtr res, const YRealPtr x, const YRealPtr y, int* e);




/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

void LibYReal_Epsilon(YRealPtr res);
void LibYReal_Max(YRealPtr res);
void LibYReal_Min(YRealPtr res);
void LibYReal_Lowest(YRealPtr res);
void LibYReal_Nexttowards(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Nextabove(YRealPtr res, const YRealPtr x);
void LibYReal_Nextbelow(YRealPtr res, const YRealPtr x);



/* Complex components  */

void LibYReal_Fabs(YRealPtr res, const YRealPtr x);
void LibYReal_Sign(YRealPtr res, const YRealPtr x);



/* Mathematical Constants  */

void LibYReal_Pi(YRealPtr res);
void LibYReal_E(YRealPtr res);



/* Roots and related functions  */

void LibYReal_Sqrt(YRealPtr res, const YRealPtr x);
void LibYReal_Rsqrt(YRealPtr res, const YRealPtr x);
void LibYReal_Cbrt(YRealPtr res, const YRealPtr x);
void LibYReal_Root_Si(YRealPtr res, const YRealPtr x, const int32_t k_);


/* Exponential and related functions  */

void LibYReal_Exp(YRealPtr res, const YRealPtr x);
void LibYReal_Exp2(YRealPtr res, const YRealPtr x);
void LibYReal_Exp10(YRealPtr res, const YRealPtr x);

void LibYReal_Expm1(YRealPtr res, const YRealPtr x);
void LibYReal_Exp2m1(YRealPtr res, const YRealPtr x);
void LibYReal_Exp10m1(YRealPtr res, const YRealPtr x);


/* Logarithms and related functions  */

void LibYReal_Log(YRealPtr res, const YRealPtr x);
void LibYReal_Log2(YRealPtr res, const YRealPtr x);
void LibYReal_Log10(YRealPtr res, const YRealPtr x);

void LibYReal_Log1p(YRealPtr res, const YRealPtr x);
void LibYReal_Log2p1(YRealPtr res, const YRealPtr x);
void LibYReal_Log10p1(YRealPtr res, const YRealPtr x);



/* Power functions */

void LibYReal_Square(YRealPtr res, const YRealPtr x);
void LibYReal_Cube(YRealPtr res, const YRealPtr x);
void LibYReal_Hypot(YRealPtr res, const YRealPtr x, const YRealPtr y);

void LibYReal_Pow(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Pow1p(YRealPtr res, const YRealPtr x, const YRealPtr y);
void LibYReal_Pow1pm1(YRealPtr res, const YRealPtr x, const YRealPtr y);

void LibYReal_Pow_Si(YRealPtr res, const YRealPtr x, const int32_t k_);
void LibYReal_Compound_Si(YRealPtr res, const YRealPtr x, const int32_t k_);


/* Trigonometric functions  */

void LibYReal_Sin(YRealPtr res, const YRealPtr x);
void LibYReal_Cos(YRealPtr res, const YRealPtr x);
void LibYReal_Tan(YRealPtr res, const YRealPtr x);

void LibYReal_Csc(YRealPtr res, const YRealPtr x);
void LibYReal_Sec(YRealPtr res, const YRealPtr x);
void LibYReal_Cot(YRealPtr res, const YRealPtr x);


/* Hyperbolic functions  */

void LibYReal_Sinh(YRealPtr res, const YRealPtr x);
void LibYReal_Cosh(YRealPtr res, const YRealPtr x);
void LibYReal_Tanh(YRealPtr res, const YRealPtr x);

void LibYReal_Csch(YRealPtr res, const YRealPtr x);
void LibYReal_Sech(YRealPtr res, const YRealPtr x);
void LibYReal_Coth(YRealPtr res, const YRealPtr x);



/* Inverse trigonometric functions  */

void LibYReal_Acos(YRealPtr res, const YRealPtr x);
void LibYReal_Asin(YRealPtr res, const YRealPtr x);
void LibYReal_Atan(YRealPtr res, const YRealPtr x);
void LibYReal_Atan2(YRealPtr res, const YRealPtr x, const YRealPtr y);

void LibYReal_Acsc(YRealPtr res, const YRealPtr x);
void LibYReal_Asec(YRealPtr res, const YRealPtr x);
void LibYReal_Acot(YRealPtr res, const YRealPtr x);


/* Inverse hyperbolic functions  */

void LibYReal_Acosh(YRealPtr res, const YRealPtr x);
void LibYReal_Asinh(YRealPtr res, const YRealPtr x);
void LibYReal_Atanh(YRealPtr res, const YRealPtr x);

void LibYReal_Acsch(YRealPtr res, const YRealPtr x);
void LibYReal_Asech(YRealPtr res, const YRealPtr x);
void LibYReal_Acoth(YRealPtr res, const YRealPtr x);



/* Special functions  */

void LibYReal_Erf(YRealPtr res, const YRealPtr x);
void LibYReal_Erfc(YRealPtr res, const YRealPtr x);

void LibYReal_Tgamma(YRealPtr res, const YRealPtr x);
void LibYReal_Lgamma(YRealPtr res, const YRealPtr x);

void LibYReal_J0(YRealPtr res, const YRealPtr x);
void LibYReal_J1(YRealPtr res, const YRealPtr x);
void LibYReal_Jn(YRealPtr res, const int n, const YRealPtr x);

void LibYReal_Y0(YRealPtr res, const YRealPtr x);
void LibYReal_Y1(YRealPtr res, const YRealPtr x);
void LibYReal_Yn(YRealPtr res, const int n, const YRealPtr x);









//*********************** Complex **********************************


YCplxPtr LibYCplx_Init_Func();
void LibYCplx_Clear(YCplxPtr x);

void LibYCplx_Get_Str_Real(char* cstr, YCplxPtr x);
void LibYCplx_Get_Str_Imag(char* cstr, YCplxPtr x);




void LibYCplx_Neg(YCplxPtr res, const YCplxPtr x);



void LibYCplx_Add(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
void LibYCplx_Sub(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
void LibYCplx_Mul(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
void LibYCplx_Div(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);


void LibYCplx_Add_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y);
void LibYCplx_Sub_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y);
void LibYCplx_YReal_Sub(YCplxPtr res, const YCplxPtr y, const YRealPtr x);

void LibYCplx_Mul_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y);
void LibYCplx_Div_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y);
void LibYCplx_YReal_Div(YCplxPtr res, const YCplxPtr y, const YRealPtr x);


void LibYCplx_Add_D(YCplxPtr res, const YCplxPtr x, const double y);
void LibYCplx_Sub_D(YCplxPtr res, const YCplxPtr x, const double y);
void LibYCplx_D_Sub(YCplxPtr res, const YCplxPtr y, const double x);

void LibYCplx_Mul_D(YCplxPtr res, const YCplxPtr x, const double y);
void LibYCplx_Div_D(YCplxPtr res, const YCplxPtr x, const double y);
void LibYCplx_D_Div(YCplxPtr res, const YCplxPtr y, const double x);


void LibYCplx_Add_Si(YCplxPtr res, const YCplxPtr x, const int32_t y);
void LibYCplx_Sub_Si(YCplxPtr res, const YCplxPtr x, const int32_t y);
void LibYCplx_Si_Sub(YCplxPtr res, const YCplxPtr y, const int32_t x);

void LibYCplx_Mul_Si(YCplxPtr res, const YCplxPtr x, const int32_t y);
void LibYCplx_Div_Si(YCplxPtr res, const YCplxPtr x, const int32_t y);
void LibYCplx_Si_Div(YCplxPtr res, const YCplxPtr y, const int32_t x);





/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void LibYCplx_Set(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Set_Real(YCplxPtr res, const YRealPtr re);
void LibYCplx_Set2(YCplxPtr res, const YRealPtr re, const YRealPtr im);

void LibYCplx_Set2_Str2(YRealPtr res, const char * str_re, const char * str_im);

void LibYCplx_Abs(YRealPtr res, const YCplxPtr x);
void LibYCplx_Arg(YRealPtr res, const YCplxPtr x);
void LibYCplx_Imag(YRealPtr res, const YCplxPtr x);
void LibYCplx_Real(YRealPtr res, const YCplxPtr x);
void LibYCplx_Conj(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Proj(YCplxPtr res, const YCplxPtr x);



/* Roots  */

void LibYCplx_Sqrt(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Sqrt1pm1(YCplxPtr res, const YCplxPtr x);

void LibYCplx_Rsqrt(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Cbrt(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Root_Si(YCplxPtr res, const YCplxPtr x, const int32_t k);


/* Exponential and related functions  */

void LibYCplx_Exp(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Expi(YCplxPtr res, const YRealPtr x);
void LibYCplx_Exp2(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Exp10(YCplxPtr res, const YCplxPtr x);

void LibYCplx_Expm1(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Exp2m1(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Exp10m1(YCplxPtr res, const YCplxPtr x);



/* Logarithms and related functions  */

void LibYCplx_Log(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Log2(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Log10(YCplxPtr res, const YCplxPtr x);

void LibYCplx_Log1p(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Log2p1(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Log10p1(YCplxPtr res, const YCplxPtr x);




/* Power functions and roots  */

void LibYCplx_Square(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Cube(YCplxPtr res, const YCplxPtr x);

void LibYCplx_Pow(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
void LibYCplx_Powm1(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
void LibYCplx_Pow1p(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
void LibYCplx_Pow1pm1(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);

void LibYCplx_Pow_Si(YCplxPtr res, const YCplxPtr x, const int32_t k);
void LibYCplx_Compound_Si(YCplxPtr res, const YCplxPtr x, const int32_t k);



/* Trigonometric functions  */

void LibYCplx_Sin(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Cos(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Tan(YCplxPtr res, const YCplxPtr x);

void LibYCplx_Csc(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Sec(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Cot(YCplxPtr res, const YCplxPtr x);

void LibYCplx_SinPi(YCplxPtr res, const YCplxPtr x);
void LibYCplx_CosPi(YCplxPtr res, const YCplxPtr x);
void LibYCplx_TanPi(YCplxPtr res, const YCplxPtr x);



/* Hyperbolic functions  */

void LibYCplx_Sinh(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Cosh(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Tanh(YCplxPtr res, const YCplxPtr x);

void LibYCplx_Csch(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Sech(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Coth(YCplxPtr res, const YCplxPtr x);


/* Inverse trigonometric functions  */

void LibYCplx_Asin(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Acos(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Atan(YCplxPtr res, const YCplxPtr x);

void LibYCplx_Acsc(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Asec(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Acot(YCplxPtr res, const YCplxPtr x);



/* Inverse hyperbolic functions  */

void LibYCplx_Asinh(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Acosh(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Atanh(YCplxPtr res, const YCplxPtr x);

void LibYCplx_Acsch(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Asech(YCplxPtr res, const YCplxPtr x);
void LibYCplx_Acoth(YCplxPtr res, const YCplxPtr x);






