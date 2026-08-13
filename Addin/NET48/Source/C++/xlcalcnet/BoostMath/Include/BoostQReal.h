
#include "stdint.h"

typedef void* QRealPtr;
typedef void* QCplxPtr;

typedef void* QStatePtr;


typedef void(*QRealFuncPtr) (void*, void*);
typedef void(*QAnyFuncPtr2) (const void*,const  void*);
typedef void(*QAnyFuncPtr3) (const void*,const  void*,const  void*);



//////*********************** Boost/CppOptLib **********************************
//
//
//void LibQReal_LbfgsSolver(QRealFuncPtr f1, QRealFuncPtr f2, QStatePtr matX_, QStatePtr matGrad_, QStatePtr xPtr);
//
//void LibQReal_BfgsSolver(QRealFuncPtr f1, QRealFuncPtr f2, QStatePtr matX_, QStatePtr matGrad_, QStatePtr xPtr);
//
//
//
//void LibQReal_GradientDescentSolver(QRealFuncPtr f1, QRealFuncPtr f2, QStatePtr matX_, QStatePtr matGrad_, QStatePtr xPtr);
//
//void LibQReal_ConjugatedGradientDescentSolver(QRealFuncPtr f1, QRealFuncPtr f2, QStatePtr matX_, QStatePtr matGrad_, QStatePtr xPtr);







//*********************** Boost Odeint **********************************

void LibQReal_Const_RungeKutta4(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);

void LibQReal_Const_RungeKuttaCashKarp54(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);

void LibQReal_Const_RungeKuttaDopri5(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);

void LibQReal_Const_RungeKuttaFehlberg78(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);

void LibQReal_Const_AdamsBashforthMoulton(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);



void LibQReal_Adaptive_RungeKuttaDopri5(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

void LibQReal_Adaptive_RungeKuttaCashKarp54(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

void LibQReal_Adaptive_RungeKuttaFehlberg78(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

void LibQReal_Adaptive_BulirschStoer(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

void LibQReal_DenseOutput_Dopri5(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

void LibQReal_DenseOutput_BulirschStoer(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);







//*********************** Boost Numerical Calculus, quadruple precision **********************************


void LibQReal_BracketRoot(QRealPtr res1, QRealPtr res2, int* iter, QRealFuncPtr f1, QRealPtr guess_, QRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit);

void LibQReal_NewtonRaphson(QRealPtr res,  int* iter, QRealFuncPtr f1, QRealFuncPtr f2, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit);

void LibQReal_Halley(QRealPtr res, int* iter, QRealFuncPtr f1, QRealFuncPtr f2, QRealFuncPtr f3, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit);

void LibQReal_Schroder(QRealPtr res, int* iter, QRealFuncPtr f1, QRealFuncPtr f2, QRealFuncPtr f3, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit);

void LibQReal_Brent_Minimum(QRealPtr res, QRealPtr resFx, int* iter, QRealFuncPtr f1, QRealPtr bracket_min_, QRealPtr bracket_max_, int bits, unsigned int maxit);



void LibQReal_Trapezoidal(QRealPtr res1, QRealPtr res2, QRealPtr res3, QRealFuncPtr f1, QRealPtr a_, QRealPtr b_);

void LibQReal_GaussLegendre(QRealPtr res1, QRealPtr res3, QRealFuncPtr f1, QRealPtr a_, QRealPtr b_);

void LibQReal_GaussKronrod(QRealPtr res1, QRealPtr res2, QRealPtr res3, QRealFuncPtr f1, QRealPtr a_, QRealPtr b_);

void LibQReal_TanhSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QRealFuncPtr f1, QRealPtr a_, QRealPtr b_);

void LibQReal_SinhSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QRealFuncPtr f1);

void LibQReal_ExpSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QRealFuncPtr f1);

void LibQReal_Ooura_Cos(QRealPtr res1, QRealPtr res2, QRealFuncPtr f1);

void LibQReal_Ooura_Sin(QRealPtr res1, QRealPtr res2, QRealFuncPtr f1);





//*********************** Boost Distributions, quadruple precision **********************************


void LibQReal_ArcsineDist(long Target, QRealPtr res, QRealPtr x, QRealPtr a, QRealPtr b);

void LibQReal_BernoulliDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr p);

void LibQReal_BetaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b);

void LibQReal_BinomialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n, QRealPtr p);

void LibQReal_CauchyDist(long Target, QRealPtr res, QRealPtr x, QRealPtr location, QRealPtr scale);

void LibQReal_Chi2Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

void LibQReal_ExponentialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lambda);

void LibQReal_ExtremeValueDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

void LibQReal_FisherFDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mu, QRealPtr nu);

void LibQReal_GammaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale);

void LibQReal_GeometricDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr p);

void LibQReal_HypergeometricDist(long Target, QRealPtr res, QRealPtr x, uint64_t r, uint64_t n, uint64_t N);

void LibQReal_InverseChi2Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr df, QRealPtr scale);

void LibQReal_InverseGammaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale);

void LibQReal_InverseGaussianDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr scale);

void LibQReal_LaplaceDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

void LibQReal_LogisticDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

void LibQReal_LognormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

void LibQReal_NegBinomialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n, QRealPtr p);

void LibQReal_Chi2NCDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu, QRealPtr nc);

void LibQReal_StudentTNCDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu, QRealPtr delta);

void LibQReal_FisherNCDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mu, QRealPtr nu, QRealPtr nc);

void LibQReal_BetaNCDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b, QRealPtr nc);

void LibQReal_NormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr stdev);

void LibQReal_ParetoDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale);

void LibQReal_PoissonDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

void LibQReal_RayleighDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

void LibQReal_SkewNormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr scale, QRealPtr shape);

void LibQReal_StudentTDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

void LibQReal_TriangularDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lower, QRealPtr mode_, QRealPtr upper);

void LibQReal_WeibullDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale);

void LibQReal_UniformDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lower, QRealPtr upper);




//*********************** New , quadruple precision **********************************



void LibQReal_Logaddexp(QRealPtr res, const QRealPtr a, const QRealPtr b);


void LibQReal_HyperexponentialDist(long Target, QRealPtr res, QRealPtr xqp, QStatePtr l1, QStatePtr l2);

void LibQReal_KolmogorovSmirnovDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

void LibQReal_HoltsmarkDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

void LibQReal_LandauDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

void LibQReal_MapAiryDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

void LibQReal_Saspoint5Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);





//*********************** Boost Special functions , quadruple precision **********************************


void LibQReal_Ulp(QRealPtr res, const QRealPtr x);

void LibQReal_BernoulliB2n(QRealPtr res, int n);

void LibQReal_TangentT2n(QRealPtr res, int n);

void LibQReal_Sqrt1pm1(QRealPtr res, const QRealPtr x);



void LibQReal_SinPi(QRealPtr res, const QRealPtr x);

void LibQReal_CosPi(QRealPtr res, const QRealPtr x);

void LibQReal_TanPi(QRealPtr res, const QRealPtr x);


void LibQReal_CscPi(QRealPtr res, const QRealPtr x);

void LibQReal_SecPi(QRealPtr res, const QRealPtr x);

void LibQReal_CotPi(QRealPtr res, const QRealPtr x);




void LibQReal_SincPi(QRealPtr res, const QRealPtr x);

void LibQReal_SinhcPi(QRealPtr res, const QRealPtr x);


void LibQReal_Tgamma_(QRealPtr res, const QRealPtr x);

void LibQReal_Tgamma1pm1(QRealPtr res, const QRealPtr x);

void LibQReal_Lgamma_(QRealPtr res, const QRealPtr x);

void LibQReal_Digamma(QRealPtr res, const QRealPtr x);

void LibQReal_Trigamma(QRealPtr res, const QRealPtr x);


void LibQReal_Factorial(QRealPtr res, const QRealPtr x);

void LibQReal_DoubleFactorial(QRealPtr res, const QRealPtr x);


void LibQReal_Erf_(QRealPtr res, const QRealPtr x);

void LibQReal_Erfc_(QRealPtr res, const QRealPtr x);

void LibQReal_Erf_inv(QRealPtr res, const QRealPtr x);

void LibQReal_Erfc_inv(QRealPtr res, const QRealPtr x);


void LibQReal_AiryAi(QRealPtr res, const QRealPtr x);

void LibQReal_AiryBi(QRealPtr res, const QRealPtr x);

void LibQReal_AiryAiPrime(QRealPtr res, const QRealPtr x);

void LibQReal_AiryBiPrime(QRealPtr res, const QRealPtr x);

void LibQReal_Aizero(QRealPtr res, int n);

void LibQReal_Bizero(QRealPtr res, int n);


void LibQReal_Ellint_1_K(QRealPtr res, const QRealPtr x);

void LibQReal_Ellint_2_K(QRealPtr res, const QRealPtr x);

void LibQReal_Zeta(QRealPtr res, const QRealPtr x);

void LibQReal_Ei(QRealPtr res, const QRealPtr x);


void LibQReal_LambertW0(QRealPtr res, const QRealPtr x);

void LibQReal_LambertWm1(QRealPtr res, const QRealPtr x);

void LibQReal_LambertW0Prime(QRealPtr res, const QRealPtr x);

void LibQReal_LambertWm1Prime(QRealPtr res, const QRealPtr x);


void LibQReal_Agm(QRealPtr res, const QRealPtr a, const QRealPtr b);


void LibQReal_Powm1(QRealPtr res, const QRealPtr a, const QRealPtr b);

void LibQReal_TgammaRatio(QRealPtr res, const QRealPtr a, const QRealPtr b);

void LibQReal_TgammaDeltaRatio(QRealPtr res, const QRealPtr a, const QRealPtr b);


void LibQReal_Binomial(QRealPtr res, const QRealPtr n, const QRealPtr k);

void LibQReal_RisingFactorial(QRealPtr res, const QRealPtr x, const QRealPtr n);

void LibQReal_FallingFactorial(QRealPtr res, const QRealPtr x, const QRealPtr n);


void LibQReal_BesselJ(QRealPtr res, const QRealPtr v, const QRealPtr x);

void LibQReal_BesselY(QRealPtr res, const QRealPtr v, const QRealPtr x);

void LibQReal_BesselI(QRealPtr res, const QRealPtr v, const QRealPtr x);

void LibQReal_BesselK(QRealPtr res, const QRealPtr v, const QRealPtr x);

void LibQReal_SphBessel(QRealPtr res, const unsigned v, const QRealPtr x);

void LibQReal_SphNeumann(QRealPtr res, const unsigned v, const QRealPtr x);


void LibQReal_BesselJPrime(QRealPtr res, const QRealPtr v, const QRealPtr x);

void LibQReal_BesselYPrime(QRealPtr res, const QRealPtr v, const QRealPtr x);

void LibQReal_BesselIPrime(QRealPtr res, const QRealPtr v, const QRealPtr x);

void LibQReal_BesselKPrime(QRealPtr res, const QRealPtr v, const QRealPtr x);

void LibQReal_SphBesselPrime(QRealPtr res, const unsigned v, const QRealPtr x);

void LibQReal_SphNeumannPrime(QRealPtr res, const unsigned v, const QRealPtr x);


void LibQReal_BesselJZero(QRealPtr res, const QRealPtr v, const int m);

void LibQReal_BesselYZero(QRealPtr res, const QRealPtr v, const int m);


void LibQReal_GammaP(QRealPtr res, const QRealPtr a, const QRealPtr x);

void LibQReal_GammaQ(QRealPtr res, const QRealPtr a, const QRealPtr x);

void LibQReal_TgammaLower(QRealPtr res, const QRealPtr a, const QRealPtr x);

void LibQReal_TgammaUpper(QRealPtr res, const QRealPtr a, const QRealPtr x);


void LibQReal_GammaPInv(QRealPtr res, const QRealPtr a, const QRealPtr p);

void LibQReal_GammaQInv(QRealPtr res, const QRealPtr a, const QRealPtr q);

void LibQReal_GammaPInva(QRealPtr res, const QRealPtr p, const QRealPtr x);

void LibQReal_GammaQInva(QRealPtr res, const QRealPtr q, const QRealPtr x);


void LibQReal_GammaPDerivative(QRealPtr res, const QRealPtr a, const QRealPtr x);

void LibQReal_Beta(QRealPtr res, const QRealPtr a, const QRealPtr b);


void LibQReal_LegendreP(QRealPtr res, int n, const QRealPtr x);

void LibQReal_LegendreQ(QRealPtr res, int n, const QRealPtr x);

void LibQReal_Laguerre(QRealPtr res, int n, const QRealPtr x);

void LibQReal_Hermite(QRealPtr res, int n, const QRealPtr x);

void LibQReal_ChebyshevT(QRealPtr res, int n, const QRealPtr x);

void LibQReal_ChebyshevU(QRealPtr res, int n, const QRealPtr x);

void LibQReal_Polygamma(QRealPtr res, int n, const QRealPtr x);


void LibQReal_EllintRC(QRealPtr res, const QRealPtr x, const QRealPtr y);

void LibQReal_Ellint1F(QRealPtr res, const QRealPtr k, const QRealPtr phi);

void LibQReal_Ellint2F(QRealPtr res, const QRealPtr k, const QRealPtr phi);

void LibQReal_Ellint3K(QRealPtr res, const QRealPtr k, const QRealPtr n);


void LibQReal_JacobiCD(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiCN(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiCS(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiDC(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiDN(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiDS(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiNC(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiND(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiNS(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiSC(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiSD(QRealPtr res, const QRealPtr k, const QRealPtr u);

void LibQReal_JacobiSN(QRealPtr res, const QRealPtr k, const QRealPtr u);


void LibQReal_expint(QRealPtr res, const unsigned n, const QRealPtr x);

void LibQReal_OwenT(QRealPtr res, const QRealPtr h, const QRealPtr a);


void LibQReal_IBeta(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

void LibQReal_IBetac(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

void LibQReal_IBetaNonNormalized(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

void LibQReal_IBetacNonNormalized(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

void LibQReal_IBetaInv(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr p);

void LibQReal_IBetacInv(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr q);

void LibQReal_IBetaInva(QRealPtr res, const QRealPtr b, const QRealPtr x, const QRealPtr p);

void LibQReal_IBetacInva(QRealPtr res, const QRealPtr b, const QRealPtr x, const QRealPtr q);

void LibQReal_IBetaInvb(QRealPtr res, const QRealPtr a, const QRealPtr x, const QRealPtr p);

void LibQReal_IBetacInvb(QRealPtr res, const QRealPtr a, const QRealPtr x, const QRealPtr q);

void LibQReal_IBetaDerivative(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);


void LibQReal_LegendrePM(QRealPtr res, const int n, const int m, const QRealPtr x);

void LibQReal_LaguerreM(QRealPtr res, const int n, const int m, const QRealPtr x);


void LibQReal_EllipticRF(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z);

void LibQReal_EllipticRD(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z);

void LibQReal_EllipticRG(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z);

void LibQReal_Ellint3F(QRealPtr res, const QRealPtr k, const QRealPtr n, const QRealPtr phi);


void LibQReal_Gegenbauer(QRealPtr res, const int n, const QRealPtr lambda, const QRealPtr x);

void LibQReal_Jacobi(QRealPtr res, const int n, const QRealPtr alpha, const QRealPtr beta, const QRealPtr x);


void LibQReal_SphericalHarmonicR(QRealPtr res, const int n, const int m, const QRealPtr theta, const QRealPtr phi);

void LibQReal_SphericalHarmonicI(QRealPtr res, const int n, const int m, const QRealPtr theta, const QRealPtr phi);

void LibQReal_EllipticRJ(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z, const QRealPtr p);


void LibQReal_Hypergeo0F1(QRealPtr res, const QRealPtr b, const QRealPtr x);

void LibQReal_Hypergeo1F1(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

void LibQReal_Hypergeo1F1r(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

void LibQReal_LogHypergeo1F1(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);


void LibQReal_JacobiTheta1(QRealPtr res, const QRealPtr x, const QRealPtr q);

void LibQReal_JacobiTheta2(QRealPtr res, const QRealPtr x, const QRealPtr q);

void LibQReal_JacobiTheta3(QRealPtr res, const QRealPtr x, const QRealPtr q);

void LibQReal_JacobiTheta4(QRealPtr res, const QRealPtr x, const QRealPtr q);





//*********************** Extra, quadruple precision **********************************

void LibQReal_ShowQuadNet(char* cstr, QRealPtr x);


void LibQReal_Inf(QRealPtr res);

void LibQReal_NegInf(QRealPtr res);

void LibQReal_Nan(QRealPtr res);

void LibQReal_Lowest(QRealPtr res);

int LibQReal_Isnormal(QRealPtr res);

int LibQReal_Issubnormal(QRealPtr res);

void LibQReal_Nextafter(QRealPtr res, const QRealPtr x, const QRealPtr y);

void LibQReal_Nexttowards(QRealPtr res, const QRealPtr x, const QRealPtr y);

void LibQReal_Nextabove(QRealPtr res, const QRealPtr x);

void LibQReal_Nextbelow(QRealPtr res, const QRealPtr x);








