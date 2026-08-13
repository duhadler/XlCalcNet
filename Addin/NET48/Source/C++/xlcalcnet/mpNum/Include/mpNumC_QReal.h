
#ifndef MPNUMC_QREAL_H_INCLUDED
#define MPNUMC_QREAL_H_INCLUDED




/** ********************** Real Basic Functions, quadruple precision ******************************** **/


MPNUMC_DLL_IMPORTEXPORT QRealPtr __cdecl Lib_QReal_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Clear(QRealPtr x);



/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set(QRealPtr res, const QRealPtr x);

//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Fmpq(QRealPtr res, const FmpqPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Arb(QRealPtr res, const ArbPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Arf(QRealPtr res, const ArfPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Mpfi(QRealPtr res, const MpfiPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Mpfr(QRealPtr res, const MpfrPtr x);
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Mpd(QRealPtr res, const MpdPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_C34Real(QRealPtr res, const CRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_QReal(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_LD(QRealPtr res, long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_D(QRealPtr res, const double x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_S(QRealPtr res, float* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Si(QRealPtr res, const int32_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Ui(QRealPtr res, const uint32_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Si64(QRealPtr res, const int64_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Ui64(QRealPtr res, const uint64_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Set_Str(QRealPtr res, const char * str);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Get_Str(char * dest, const char *template1, const QRealPtr x);

/* Get Double */







/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Neg(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Add(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sub(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Mul(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Div(QRealPtr res, const QRealPtr x, const QRealPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Add_D(QRealPtr res, const QRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sub_D(QRealPtr res, const QRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_D_Sub(QRealPtr res, const QRealPtr x, const double y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Mul_D(QRealPtr res, const QRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Div_D(QRealPtr res, const QRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_D_Div(QRealPtr res, const QRealPtr x, const double y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Add_Si(QRealPtr res, const QRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sub_Si(QRealPtr res, const QRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Si_Sub(QRealPtr res, const QRealPtr x, const int32_t y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Mul_Si(QRealPtr res, const QRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Div_Si(QRealPtr res, const QRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Si_Div(QRealPtr res, const QRealPtr x, const int32_t y);


MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_QReal_LT(const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_QReal_GE(const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_QReal_GT(const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_QReal_LE(const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_QReal_EQ(const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_QReal_NE(const QRealPtr x, const QRealPtr y);







/* General functions for real numbers  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Fma(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Fmax(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Fmin(QRealPtr res, const QRealPtr x, const QRealPtr y);



/* Machine constants */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Zero(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_NegZero(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_One(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Inf(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_NegInf(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Nan(QRealPtr res);



/* Properties of numbers  */

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Signbit(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Finite(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isinf(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isposinf(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isneginf(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isnan(const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Iszero(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isposzero(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isnegzero(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isone(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isinteger(const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isnumber(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isregular(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isnormal(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Issubnormal(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Isunordered(const QRealPtr x, const QRealPtr y);


MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_FitsInt32(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_FitsInt64(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_FitsUInt32(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_FitsUInt64(const QRealPtr x);




/* Integer Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Nearbyint(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Rint(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_QReal_Lrint(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_QReal_Llrint(const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ceil(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Floor(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Trunc(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Round(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_QReal_Lround(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_QReal_Llround(const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_QReal_ToInt32(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_QReal_ToInt64(const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl Lib_QReal_ToUInt32(const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT uint64_t __cdecl Lib_QReal_ToUInt64(const QRealPtr x);




/* Floating point functions for real numbers */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Copysign(QRealPtr res, const QRealPtr x, const QRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Frexp(QRealPtr res, const QRealPtr x, int* e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Logb(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_QReal_Ilogb(const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ldexp(QRealPtr res, const QRealPtr x, const int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Scalbn(QRealPtr res, const QRealPtr x, const int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Scalbln(QRealPtr res, const QRealPtr x, const long int e);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Fdim(QRealPtr res, const QRealPtr x, const QRealPtr y);


/* Fraction and Remainder Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Modf(QRealPtr frac, const QRealPtr x, QRealPtr iptr);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Fmod(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Remainder(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Remquo(QRealPtr res, const QRealPtr x, const QRealPtr y, int* e);



/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Epsilon(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ulp(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Max(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Lowest(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Min(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Nextabove(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Nextbelow(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Nexttoward(QRealPtr res, const QRealPtr x, const QRealPtr y);



/* Mathematical Constants  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstDegree(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstPhi(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstLog2(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstLog10(QRealPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstPi(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstE(QRealPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstEulerGamma(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstApery(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstCatalan(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstGlaisher(QRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConstKhinchin(QRealPtr res);



/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Fabs(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sign(QRealPtr res, const QRealPtr x);




/* Roots and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sqrt(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sqrt1pm1(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Rsqrt(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Cbrt(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Root_Si(QRealPtr res, const QRealPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Exp(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Exp2(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Exp10(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Expm1(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Exp2m1(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Exp10m1(QRealPtr res, const QRealPtr x);




/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Log(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Log2(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Log10(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Log1p(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Log2p1(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Log10p1(QRealPtr res, const QRealPtr x);



/* Power functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Square(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Cube(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Hypot(QRealPtr res, const QRealPtr x, const QRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Pow(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Powm1(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Pow1p(QRealPtr res, const QRealPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Pow1pm1(QRealPtr res, const QRealPtr x, const QRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Pow_Si(QRealPtr res, const QRealPtr x, const int32_t n);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Compound_Si(QRealPtr res, const QRealPtr x, const int32_t n);



/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sin(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Cos(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Cosm1(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Tan(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Csc(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sec(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Cot(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SinPi(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_CosPi(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_TanPi(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_CscPi(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SecPi(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_CotPi(QRealPtr res, const QRealPtr x);



/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sinh(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Cosh(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Tanh(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Csch(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sech(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Coth(QRealPtr res, const QRealPtr x);



/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Asin(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Acos(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Atan(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Atan2(QRealPtr res, const QRealPtr x, const QRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Acsc(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Asec(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Acot(QRealPtr res, const QRealPtr x);


/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Asinh(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Acosh(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Atanh(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Acsch(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Asech(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Acoth(QRealPtr res, const QRealPtr x);



/* Special functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Erf(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Erfc(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Tgamma(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Lgamma(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselJ0(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselJ1(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselJn(QRealPtr res, const int n, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselY0(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselY1(QRealPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselYn(QRealPtr res, const int n, const QRealPtr x);






/** ********************** Complex Basic Functions, extended precision ******************************** **/


MPNUMC_DLL_IMPORTEXPORT QCplxPtr __cdecl Lib_QCplx_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Clear(QCplxPtr x);


/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Set(QCplxPtr res, const QCplxPtr x);


/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Neg(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Add(QCplxPtr res, const QCplxPtr x, const QCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sub(QCplxPtr res, const QCplxPtr x, const QCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Mul(QCplxPtr res, const QCplxPtr x, const QCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Div(QCplxPtr res, const QCplxPtr x, const QCplxPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Add_QReal(QCplxPtr res, const QCplxPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sub_QReal(QCplxPtr res, const QCplxPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_QReal_Sub(QCplxPtr res, const QCplxPtr y, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Mul_QReal(QCplxPtr res, const QCplxPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Div_QReal(QCplxPtr res, const QCplxPtr x, const QRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_QReal_Div(QCplxPtr res, const QCplxPtr y, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Add_D(QCplxPtr res, const QCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sub_D(QCplxPtr res, const QCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_D_Sub(QCplxPtr res, const QCplxPtr y, const double x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Mul_D(QCplxPtr res, const QCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Div_D(QCplxPtr res, const QCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_D_Div(QCplxPtr res, const QCplxPtr y, const double x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Add_Si(QCplxPtr res, const QCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sub_Si(QCplxPtr res, const QCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Si_Sub(QCplxPtr res, const QCplxPtr y, const int32_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Mul_Si(QCplxPtr res, const QCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Div_Si(QCplxPtr res, const QCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Si_Div(QCplxPtr res, const QCplxPtr y, const int32_t x);




/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Set_Real(QCplxPtr res, const QRealPtr re);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Set2(QCplxPtr res, const QRealPtr re, const QRealPtr im);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Abs(QRealPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Arg(QRealPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Imag(QRealPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Real(QRealPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Conj(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Proj(QCplxPtr res, const QCplxPtr x);




/* Roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sqrt(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sqrt1pm1(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Rsqrt(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Cbrt(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Root_Si(QCplxPtr res, const QCplxPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Exp(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Expi(QCplxPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Exp2(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Exp10(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Expm1(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Exp2m1(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Exp10m1(QCplxPtr res, const QCplxPtr x);


/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Log(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Log2(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Log10(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Log1p(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Log2p1(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Log10p1(QCplxPtr res, const QCplxPtr x);




/* Power functions and roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Square(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Cube(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Pow(QCplxPtr res, const QCplxPtr x, const QCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Powm1(QCplxPtr res, const QCplxPtr x, const QCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Pow1p(QCplxPtr res, const QCplxPtr x, const QCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Pow1pm1(QCplxPtr res, const QCplxPtr x, const QCplxPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Pow_Si(QCplxPtr res, const QCplxPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Compound_Si(QCplxPtr res, const QCplxPtr x, const int32_t k);




/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sin(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Cos(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Tan(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Csc(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sec(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Cot(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_SinPi(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_CosPi(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_TanPi(QCplxPtr res, const QCplxPtr x);


/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sinh(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Cosh(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Tanh(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Csch(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Sech(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Coth(QCplxPtr res, const QCplxPtr x);



/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Asin(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Acos(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Atan(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Acsc(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Asec(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Acot(QCplxPtr res, const QCplxPtr x);



/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Asinh(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Acosh(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Atanh(QCplxPtr res, const QCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Acsch(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Asech(QCplxPtr res, const QCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QCplx_Acoth(QCplxPtr res, const QCplxPtr x);











//*********************** Boost Special functions , quadruple precision **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BernoulliB2n(QRealPtr res, const int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_TangentT2n(QRealPtr res, const int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Sqrt1pm1_Boost(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SinPi_Boost(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_CosPi_Boost(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SincPi(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SinhcPi(QRealPtr res, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Tgamma_(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Tgamma1pm1(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Lgamma_(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Digamma(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Trigamma(QRealPtr res, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Factorial(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_DoubleFactorial(QRealPtr res, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Erf_(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Erfc_(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Erf_inv(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Erfc_inv(QRealPtr res, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_AiryAi(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_AiryBi(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_AiryAiPrime(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_AiryBiPrime(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Aizero(QRealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Bizero(QRealPtr res, int n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ellint_1_K(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ellint_2_K(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Zeta(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ei(QRealPtr res, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LambertW0(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LambertWm1(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LambertW0Prime(QRealPtr res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LambertWm1Prime(QRealPtr res, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Agm(QRealPtr res, const QRealPtr a, const QRealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Powm1_Boost(QRealPtr res, const QRealPtr a, const QRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_TgammaRatio(QRealPtr res, const QRealPtr a, const QRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_TgammaDeltaRatio(QRealPtr res, const QRealPtr a, const QRealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Binomial(QRealPtr res, const QRealPtr n, const QRealPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_RisingFactorial(QRealPtr res, const QRealPtr x, const QRealPtr n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_FallingFactorial(QRealPtr res, const QRealPtr x, const QRealPtr n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselJ(QRealPtr res, const QRealPtr v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselY(QRealPtr res, const QRealPtr v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselI(QRealPtr res, const QRealPtr v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselK(QRealPtr res, const QRealPtr v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SphBessel(QRealPtr res, const unsigned v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SphNeumann(QRealPtr res, const unsigned v, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselJPrime(QRealPtr res, const QRealPtr v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselYPrime(QRealPtr res, const QRealPtr v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselIPrime(QRealPtr res, const QRealPtr v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselKPrime(QRealPtr res, const QRealPtr v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SphBesselPrime(QRealPtr res, const unsigned v, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SphNeumannPrime(QRealPtr res, const unsigned v, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselJZero(QRealPtr res, const QRealPtr v, const int m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BesselYZero(QRealPtr res, const QRealPtr v, const int m);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GammaP(QRealPtr res, const QRealPtr a, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GammaQ(QRealPtr res, const QRealPtr a, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_TgammaLower(QRealPtr res, const QRealPtr a, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_TgammaUpper(QRealPtr res, const QRealPtr a, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GammaPInv(QRealPtr res, const QRealPtr a, const QRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GammaQInv(QRealPtr res, const QRealPtr a, const QRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GammaPInva(QRealPtr res, const QRealPtr p, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GammaQInva(QRealPtr res, const QRealPtr q, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GammaPDerivative(QRealPtr res, const QRealPtr a, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Beta(QRealPtr res, const QRealPtr a, const QRealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LegendreP(QRealPtr res, int n, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LegendreQ(QRealPtr res, int n, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Laguerre(QRealPtr res, int n, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Hermite(QRealPtr res, int n, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ChebyshevT(QRealPtr res, int n, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ChebyshevU(QRealPtr res, int n, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Polygamma(QRealPtr res, int n, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_EllintRC(QRealPtr res, const QRealPtr x, const QRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ellint1F(QRealPtr res, const QRealPtr k, const QRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ellint2F(QRealPtr res, const QRealPtr k, const QRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ellint3K(QRealPtr res, const QRealPtr k, const QRealPtr n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiCD(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiCN(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiCS(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiDC(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiDN(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiDS(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiNC(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiND(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiNS(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiSC(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiSD(QRealPtr res, const QRealPtr k, const QRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiSN(QRealPtr res, const QRealPtr k, const QRealPtr u);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_expint(QRealPtr res, const unsigned n, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_OwenT(QRealPtr res, const QRealPtr h, const QRealPtr a);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBeta(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetac(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetaNonNormalized(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetacNonNormalized(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetaInv(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetacInv(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetaInva(QRealPtr res, const QRealPtr b, const QRealPtr x, const QRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetacInva(QRealPtr res, const QRealPtr b, const QRealPtr x, const QRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetaInvb(QRealPtr res, const QRealPtr a, const QRealPtr x, const QRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetacInvb(QRealPtr res, const QRealPtr a, const QRealPtr x, const QRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_IBetaDerivative(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LegendrePM(QRealPtr res, const int n, const int m, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LaguerreM(QRealPtr res, const int n, const int m, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_EllipticRF(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_EllipticRD(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_EllipticRG(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ellint3F(QRealPtr res, const QRealPtr k, const QRealPtr n, const QRealPtr phi);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Gegenbauer(QRealPtr res, const int n, const QRealPtr lambda, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Jacobi(QRealPtr res, const int n, const QRealPtr alpha, const QRealPtr beta, const QRealPtr x);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SphericalHarmonicR(QRealPtr res, const int n, const int m, const QRealPtr theta, const QRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SphericalHarmonicI(QRealPtr res, const int n, const int m, const QRealPtr theta, const QRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_EllipticRJ(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z, const QRealPtr p);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Hypergeo0F1(QRealPtr res, const QRealPtr b, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Hypergeo1F1(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Hypergeo1F1r(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LogHypergeo1F1(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiTheta1(QRealPtr res, const QRealPtr x, const QRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiTheta2(QRealPtr res, const QRealPtr x, const QRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiTheta3(QRealPtr res, const QRealPtr x, const QRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_JacobiTheta4(QRealPtr res, const QRealPtr x, const QRealPtr q);






//*********************** Boost Distributions, quadruple precision **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ArcsineDist(long Target, QRealPtr res, QRealPtr x, QRealPtr a, QRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BernoulliDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BetaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BinomialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n, QRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_CauchyDist(long Target, QRealPtr res, QRealPtr x, QRealPtr location, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Chi2Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ExponentialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lambda);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GumbelDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_FisherFDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mu, QRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GammaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GeometricDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_HypergeometricDist(long Target, QRealPtr res, QRealPtr x, uint64_t r, uint64_t n, uint64_t N);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_InverseChi2Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr df, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_InverseGammaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_WaldDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LaplaceDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LogisticDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LognormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_NegBinomialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n, QRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Chi2NcDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu, QRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_StudentTNcDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu, QRealPtr delta);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_FisherNcDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mu, QRealPtr nu, QRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BetaNcDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b, QRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_NormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr stdev);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ParetoDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_PoissonDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_RayleighDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SkewNormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr scale, QRealPtr shape);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_StudentTDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_TriangularDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lower, QRealPtr mode_, QRealPtr upper);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_WeibullDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_UniformDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lower, QRealPtr upper);




//*********************** New , quadruple precision **********************************

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Logaddexp(QRealPtr res, const QRealPtr a, const QRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_HyperexponentialDist(long Target, QRealPtr res, QRealPtr xqp, mpNumMatrixPtr l1, mpNumMatrixPtr l2);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_KolmogorovSmirnovDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_HoltsmarkDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LandauDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_MapAiryDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Saspoint5Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale);




//*********************** Extra **********************************

MPNUMC_DLL_IMPORTEXPORT void __cdecl ShowQuadNet(char* cstr, QRealPtr x);



//*********************** Boost Numerical Calculus, quadruple precision **********************************


typedef void(*QuadFuncPtr) (void*, void*);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BracketRoot(QRealPtr res1, QRealPtr res2, int* iter, QuadFuncPtr f1, QRealPtr guess_, QRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_NewtonRaphson(QRealPtr res,  int* iter, QuadFuncPtr f1, QuadFuncPtr f2, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Halley(QRealPtr res, int* iter, QuadFuncPtr f1, QuadFuncPtr f2, QuadFuncPtr f3, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Schroder(QRealPtr res, int* iter, QuadFuncPtr f1, QuadFuncPtr f2, QuadFuncPtr f3, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Brent_Minimum(QRealPtr res, QRealPtr resFx, int* iter, QuadFuncPtr f1, QRealPtr bracket_min_, QRealPtr bracket_max_, int bits, unsigned int maxit);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Trapezoidal(QRealPtr res1, QRealPtr res2, QRealPtr res3, QuadFuncPtr f1, QRealPtr a_, QRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GaussLegendre(QRealPtr res1, QRealPtr res3, QuadFuncPtr f1, QRealPtr a_, QRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GaussKronrod(QRealPtr res1, QRealPtr res2, QRealPtr res3, QuadFuncPtr f1, QRealPtr a_, QRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_TanhSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QuadFuncPtr f1, QRealPtr a_, QRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_SinhSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QuadFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ExpSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QuadFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ooura_Cos(QRealPtr res1, QRealPtr res2, QuadFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Ooura_Sin(QRealPtr res1, QRealPtr res2, QuadFuncPtr f1);







//*********************** Boost Odeint **********************************

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Const_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Const_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Const_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_);





MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Adaptive_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Adaptive_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Adaptive_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_);



//
//
//
////*********************** BoostEigen Optimization **********************************
//
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_LbfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr xPtr);
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_BfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr xPtr);
//
//
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_GradientDescentSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr xPtr);
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_QReal_ConjugatedGradientDescentSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr xPtr);
//
//
//






#endif // MPNUMC_QREAL_H_INCLUDED




