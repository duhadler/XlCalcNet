
#ifndef MPNUMC_XREAL_H_INCLUDED
#define MPNUMC_XREAL_H_INCLUDED

/** ********************** Real Basic Functions, extended precision ******************************** **/


MPNUMC_DLL_IMPORTEXPORT long double* __cdecl Lib_XReal_Init_Func();


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Clear(long double* x);



/* Input and output  */

// Assign x to res
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set(long double* res, const long double* x);

// Assign x to res
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Fmpq(long double* res, const FmpqPtr x);
//
//// Assign x to res
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Arb(long double* res, const long double* x);
//
//// Assign x to res
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Arf(long double* res, const ArfPtr x);
//
//// Assign x to res
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Mpfi(long double* res, const MpfiPtr x);
//
//// Assign x to res
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Mpfr(long double* res, const MpfrPtr x);
//
//// Assign x to res
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Mpd(long double* res, const MpdPtr x);

//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_C34Real(long double* res, const CRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_QReal(long double* res, const QRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_LD(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_D(long double* res, const double x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_S(long double* res, const float* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Si(long double* res, const int32_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Ui(long double* res, const uint32_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Si64(long double* res, const int64_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Ui64(long double* res, const uint64_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Set_Str(long double* res, const char * str);

MPNUMC_DLL_IMPORTEXPORT void __cdecl ShowExtNet(char* cstr, const long double* d); /* In Boost Extra */





/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Neg(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Add(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sub(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Mul(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Div(long double* res, const long double* x, const long double* y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Add_D(long double* res, const long double* x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sub_D(long double* res, const long double* x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_D_Sub(long double* res, const long double* x, const double y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Mul_D(long double* res, const long double* x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Div_D(long double* res, const long double* x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_D_Div(long double* res, const long double* x, const double y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Add_Si(long double* res, const long double* x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sub_Si(long double* res, const long double* x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Si_Sub(long double* res, const long double* x, const int32_t y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Mul_Si(long double* res, const long double* x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Div_Si(long double* res, const long double* x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Si_Div(long double* res, const long double* x, const int32_t y);


MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_XReal_LT(const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_XReal_GE(const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_XReal_GT(const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_XReal_LE(const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_XReal_EQ(const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_XReal_NE(const long double* x, const long double* y);





/* General functions for real numbers  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Fma(long double* res, const long double* x, const long double* y, const long double* z);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Fmax(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Fmin(long double* res, const long double* x, const long double* y);



/* Machine constants and properties of numbers  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Zero(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_NegZero(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_One(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Inf(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_NegInf(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Nan(long double* res);



/* Properties of numbers  */

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Signbit(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Finite(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isinf(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isposinf(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isneginf(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isnan(const long double* x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Iszero(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isposzero(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isnegzero(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isone(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isinteger(const long double* x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isnumber(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isregular(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isnormal(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Issubnormal(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Isunordered(const long double* x, const long double* y);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_FitsInt32(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_FitsInt64(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_FitsUInt32(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_FitsUInt64(const long double* x);




/* Integer Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Nearbyint(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Rint(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_XReal_Lrint(const long double* x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_XReal_Llrint(const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ceil(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Floor(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Trunc(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Round(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_XReal_Lround(const long double* x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_XReal_Llround(const long double* x);

MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_XReal_ToInt32(const long double* x);
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_XReal_ToInt64(const long double* x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl Lib_XReal_ToUInt32(const long double* x);
MPNUMC_DLL_IMPORTEXPORT uint64_t __cdecl Lib_XReal_ToUInt64(const long double* x);


/* Floating point functions for real numbers */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Copysign(long double* res, const long double* x, const long double* y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Frexp(long double* res, const long double* x, int* e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Logb(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_XReal_Ilogb(const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ldexp(long double* res, const long double* x, const int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Scalbln(long double* res, const long double* x, const long int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Scalbn(long double* res, const long double* x, const int e);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Fdim(long double* res, const long double* x, const long double* y);


/* Fraction and Remainder Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Modf(long double* frac, const long double* x, long double* iptr);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Fmod(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Remainder(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Remquo(long double* res, const long double* x, const long double* y, int* e);



/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Epsilon(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ulp(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Max(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Lowest(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Min(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Nexttoward(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Nextabove(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Nextbelow(long double* res, const long double* x);



/* Mathematical Constants  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstDegree(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstPhi(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstLog2(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstLog10(long double* res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstPi(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstE(long double* res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstEulerGamma(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstApery(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstCatalan(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstGlaisher(long double* res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ConstKhinchin(long double* res);




/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Fabs(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sign(long double* res, const long double* x);




/* Roots and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sqrt(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sqrt1pm1(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Rsqrt(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Cbrt(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Root_Si(long double* res, const long double* x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Exp(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Exp2(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Exp10(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Expm1(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Exp2m1(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Exp10m1(long double* res, const long double* x);


/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Log(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Log2(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Log10(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Log1p(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Log2p1(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Log10p1(long double* res, const long double* x);



/* Power functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Square(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Cube(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Hypot(long double* res, const long double* x, const long double* y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Pow(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Powm1(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Pow1p(long double* res, const long double* x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Pow1pm1(long double* res, const long double* x, const long double* y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Pow_Si(long double* res, const long double* x, const int32_t n);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Compound_Si(long double* res, const long double* x, const int32_t n);



/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sin(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Cos(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Cosm1(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Tan(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Csc(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sec(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Cot(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SinPi(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_CosPi(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_TanPi(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_CscPi(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SecPi(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_CotPi(long double* res, const long double* x);



/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sinh(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Cosh(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Tanh(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Csch(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sech(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Coth(long double* res, const long double* x);



/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Asin(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Acos(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Atan(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Atan2(long double* res, const long double* x, const long double* y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Acsc(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Asec(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Acot(long double* res, const long double* x);


/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Asinh(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Acosh(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Atanh(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Acsch(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Asech(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Acoth(long double* res, const long double* x);




/* Special functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Erf(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Erfc(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Tgamma(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Lgamma(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselJ0(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselJ1(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselJn(long double* res, const long double* n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselY0(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselY1(long double* res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselYn(long double* res, const long double* n, const long double* x);









/** ********************** Complex Basic Functions, extended precision ******************************** **/


MPNUMC_DLL_IMPORTEXPORT XCplxPtr __cdecl Lib_XCplx_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Clear(XCplxPtr x);


/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Set(XCplxPtr res, const XCplxPtr x);


/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Neg(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Add(XCplxPtr res, const XCplxPtr x, const XCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sub(XCplxPtr res, const XCplxPtr x, const XCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Mul(XCplxPtr res, const XCplxPtr x, const XCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Div(XCplxPtr res, const XCplxPtr x, const XCplxPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Add_XReal(XCplxPtr res, const XCplxPtr x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sub_XReal(XCplxPtr res, const XCplxPtr x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_XReal_Sub(XCplxPtr res, const XCplxPtr y, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Mul_XReal(XCplxPtr res, const XCplxPtr x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Div_XReal(XCplxPtr res, const XCplxPtr x, const long double* y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_XReal_Div(XCplxPtr res, const XCplxPtr y, const long double* x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Add_D(XCplxPtr res, const XCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sub_D(XCplxPtr res, const XCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_D_Sub(XCplxPtr res, const XCplxPtr y, const double x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Mul_D(XCplxPtr res, const XCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Div_D(XCplxPtr res, const XCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_D_Div(XCplxPtr res, const XCplxPtr y, const double x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Add_Si(XCplxPtr res, const XCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sub_Si(XCplxPtr res, const XCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Si_Sub(XCplxPtr res, const XCplxPtr y, const int32_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Mul_Si(XCplxPtr res, const XCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Div_Si(XCplxPtr res, const XCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Si_Div(XCplxPtr res, const XCplxPtr y, const int32_t x);




/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Set_Real(XCplxPtr res, const long double* re);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Set2(XCplxPtr res, const long double* re, const long double* im);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Abs(long double* res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Arg(long double* res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Imag(long double* res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Real(long double* res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Conj(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Proj(XCplxPtr res, const XCplxPtr x);





/* Roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sqrt(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sqrt1pm1(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Rsqrt(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Cbrt(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Root_Si(XCplxPtr res, const XCplxPtr x, const int32_t k);

// MISSING: sqrt1pmx

// MISSING: cuberoot

// MISSING: surd

// MISSING: unitroot


/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Exp(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Exp2(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Exp10(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Expm1(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Exp2m1(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Exp10m1(XCplxPtr res, const XCplxPtr x);

// MISSING: expj

// MISSING: expjpi



/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Log(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Log2(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Log10(XCplxPtr res, const XCplxPtr x);

// MISSING: logbase(x, b)

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Log1p(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Log2p1(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Log10p1(XCplxPtr res, const XCplxPtr x);




/* Power functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Square(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Cube(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Pow(XCplxPtr res, const XCplxPtr x, const XCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Powm1(XCplxPtr res, const XCplxPtr x, const XCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Pow1p(XCplxPtr res, const XCplxPtr x, const XCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Pow1pm1(XCplxPtr res, const XCplxPtr x, const XCplxPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Pow_Si(XCplxPtr res, const XCplxPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Compound_Si(XCplxPtr res, const XCplxPtr x, const int32_t k);



/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sin(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Cos(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Tan(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Csc(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sec(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Cot(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_SinPi(XCplxPtr res, const XCplxPtr x); /* TODO */
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_CosPi(XCplxPtr res, const XCplxPtr x); /* TODO */
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_TanPi(XCplxPtr res, const XCplxPtr x); /* TODO */


/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sinh(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Cosh(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Tanh(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Csch(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Sech(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Coth(XCplxPtr res, const XCplxPtr x);


/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Asin(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Acos(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Atan(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Acsc(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Asec(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Acot(XCplxPtr res, const XCplxPtr x);



/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Asinh(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Acosh(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Atanh(XCplxPtr res, const XCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Acsch(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Asech(XCplxPtr res, const XCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XCplx_Acoth(XCplxPtr res, const XCplxPtr x);
















//*********************** Boost Special functions , extended precision **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BernoulliB2n(long double* res, const int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_TangentT2n(long double* res, const int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Sqrt1pm1_Boost(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SinPi_Boost(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_CosPi_Boost(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SincPi(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SinhcPi(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Tgamma_(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Tgamma1pm1(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Digamma(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Lgamma_(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Trigamma(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Factorial(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_DoubleFactorial(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Erf_(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Erfc_(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Erf_inv(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Erfc_inv(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_AiryAi(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_AiryBi(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_AiryAiPrime(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_AiryBiPrime(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Aizero(long double* res, const int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Bizero(long double* res, const int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ellint_1_K(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ellint_2_K(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Zeta(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ei(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LambertW0(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LambertWm1(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LambertW0Prime(long double* res, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LambertWm1Prime(long double* res, const long double* x);





MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Agm(long double* res, const long double* a, const long double* b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Powm1_Boost(long double* res, const long double* a, const long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_TgammaRatio(long double* res, const long double* a, const long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_TgammaDeltaRatio(long double* res, const long double* a, const long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Binomial(long double* res, const long double* n, const long double* k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_RisingFactorial(long double* res, const long double* x, const long double* n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_FallingFactorial(long double* res, const long double* x, const long double* n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselJ(long double* res, const long double* v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselY(long double* res, const long double* v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselI(long double* res, const long double* v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselK(long double* res, const long double* v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SphBessel(long double* res, const unsigned v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SphNeumann(long double* res, const unsigned v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselJPrime(long double* res, const long double* v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselYPrime(long double* res, const long double* v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselIPrime(long double* res, const long double* v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselKPrime(long double* res, const long double* v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SphBesselPrime(long double* res, const unsigned v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SphNeumannPrime(long double* res, const unsigned v, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselJZero(long double* res, const long double* v, const int m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BesselYZero(long double* res, const long double* v, const int m);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GammaP(long double* res, const long double* a, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GammaQ(long double* res, const long double* a, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_TgammaLower(long double* res, const long double* a, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_TgammaUpper(long double* res, const long double* a, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GammaPInv(long double* res, const long double* a, const long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GammaQInv(long double* res, const long double* a, const long double* q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GammaPInva(long double* res, const long double* x, const long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GammaQInva(long double* res, const long double* x, const long double* q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GammaPDerivative(long double* res, const long double* a, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Beta(long double* res, const long double* a, const long double* b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LegendreP(long double* res, int n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LegendreQ(long double* res, int n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Laguerre(long double* res, int n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Hermite(long double* res, int n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ChebyshevT(long double* res, int n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ChebyshevU(long double* res, int n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Polygamma(long double* res, int n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_EllintRC(long double* res, const long double* x, const long double* y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ellint1F(long double* res, const long double* k, const long double* phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ellint2F(long double* res, const long double* k, const long double* phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ellint3K(long double* res, const long double* k, const long double* n);




MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiCD(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiCN(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiCS(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiDC(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiDN(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiDS(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiNC(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiND(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiNS(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiSC(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiSD(long double* res, const long double* k, const long double* u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiSN(long double* res, const long double* k, const long double* u);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_expint(long double* res, const unsigned n, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_OwenT(long double* res, const long double* h, const long double* a);





MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBeta(long double* res, const long double* a, const long double* b, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetac(long double* res, const long double* a, const long double* b, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetaNonNormalized(long double* res, const long double* a, const long double* b, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetacNonNormalized(long double* res, const long double* a, const long double* b, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetaInv(long double* res, const long double* a, const long double* b, const long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetacInv(long double* res, const long double* a, const long double* b, const long double* q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetaInva(long double* res, const long double* b, const long double* x, const long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetacInva(long double* res, const long double* b, const long double* x, const long double* q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetaInvb(long double* res, const long double* a, const long double* x, const long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetacInvb(long double* res, const long double* a, const long double* x, const long double* q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_IBetaDerivative(long double* res, const long double* a, const long double* b, const long double* x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LegendrePM(long double* res, const int n, const int m, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LaguerreM(long double* res, const int n, const int m, const long double* x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_EllipticRF(long double* res, const long double* x, const long double* y, const long double* z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_EllipticRD(long double* res, const long double* x, const long double* y, const long double* z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_EllipticRG(long double* res, const long double* x, const long double* y, const long double* z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ellint3F(long double* res, const long double* k, const long double* n, const long double* phi);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Gegenbauer(long double* res, const int n, const long double* lambda, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Jacobi(long double* res, const int n, const long double* alpha, const long double* beta, const long double* x);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SphericalHarmonicR(long double* res, const int n, const int m, const long double* theta, const long double* phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SphericalHarmonicI(long double* res, const int n, const int m, const long double* theta, const long double* phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_EllipticRJ(long double* res, const long double* x, const long double* y, const long double* z, const long double* p);



// Hypergeometric and Theta Functions



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Hypergeo0F1(long double* res, const long double* b, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Hypergeo1F1(long double* res, const long double* a, const long double* b, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Hypergeo1F1r(long double* res, const long double* a, const long double* b, const long double* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LogHypergeo1F1(long double* res, const long double* a, const long double* b, const long double* x);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiTheta1(long double* res, const long double* x, const long double* q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiTheta2(long double* res, const long double* x, const long double* q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiTheta3(long double* res, const long double* x, const long double* q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_JacobiTheta4(long double* res, const long double* x, const long double* q);






//*********************** Boost Distributions, extended precision **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ArcsineDist(long Target, long double* res, long double* xqp, long double* a, long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BernoulliDist(long Target, long double* res, long double* xqp, long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BetaDist(long Target, long double* res, long double* xqp, long double* a, long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BinomialDist(long Target, long double* res, long double* xqp, long double* n, long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_CauchyDist(long Target, long double* res, long double* x, long double* location, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Chi2Dist(long Target, long double* res, long double* xqp, long double* nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ExponentialDist(long Target, long double* res, long double* xqp, long double* lambda);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GumbelDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_FisherFDist(long Target, long double* res, long double* xqp, long double* mu, long double* nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GammaDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GeometricDist(long Target, long double* res, long double* xqp, long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_HypergeometricDist(long Target, long double* res, long double* x, uint64_t r, uint64_t n, uint64_t N);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_InverseChi2Dist(long Target, long double* res, long double* xqp, long double* df, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_InverseGammaDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_WaldDist(long Target, long double* res, long double* xqp, long double* mean_, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LaplaceDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LogisticDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LognormalDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_NegBinomialDist(long Target, long double* res, long double* xqp, long double* n, long double* p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Chi2NcDist(long Target, long double* res, long double* xqp, long double* nu, long double* nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_StudentTNcDist(long Target, long double* res, long double* xqp, long double* nu, long double* delta);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_FisherNcDist(long Target, long double* res, long double* xqp, long double* mu, long double* nu, long double* nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BetaNcDist(long Target, long double* res, long double* xqp, long double* a, long double* b, long double* nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_NormalDist(long Target, long double* res, long double* xqp, long double* mean_, long double* stdev);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ParetoDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_PoissonDist(long Target, long double* res, long double* xqp, long double* nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_RayleighDist(long Target, long double* res, long double* xqp, long double* nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SkewNormalDist(long Target, long double* res, long double* xqp, long double* mean_, long double* scale, long double* shape);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_StudentTDist(long Target, long double* res, long double* xqp, long double* nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_TriangularDist(long Target, long double* res, long double* xqp, long double* lower, long double* mode_, long double* upper);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_WeibullDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_UniformDist(long Target, long double* res, long double* xqp, long double* lower, long double* upper);




MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Logaddexp(long double* res, const long double* a, const long double* b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_HyperexponentialDist(long Target, long double* res, long double* xqp, mpNumMatrixPtr l1, mpNumMatrixPtr l2);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_KolmogorovSmirnovDist(long Target, long double* res, long double* xqp, long double* n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_HoltsmarkDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_LandauDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_MapAiryDist(long Target, long double* res, long double* xqp, long double* location, long double* scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Saspoint5Dist(long Target, long double* res, long double* xqp, long double* location, long double* scale);













//*********************** Boost Numerical Calculus, extended precision **********************************


typedef void(*XRealFuncPtr) (void*, void*);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_BracketRoot(long double* res1, long double* res2, int* iter, XRealFuncPtr f1, long double* guess, long double* factor, bool is_rising, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_NewtonRaphson(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Halley(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Schroder(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Brent_Minimum(long double* res, long double* resFx, int* iter, XRealFuncPtr f1, long double* bracket_min, long double* bracket_max, int bits, unsigned int maxit);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Trapezoidal(long double* res1, long double* res2, long double* res3, XRealFuncPtr f1, long double* a, long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GaussLegendre(long double* res1, long double* res3, XRealFuncPtr f1, long double* a, long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_GaussKronrod(long double* res1, long double* res2, long double* res3, XRealFuncPtr f1, long double* a, long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_TanhSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1, long double* a, long double* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_SinhSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_ExpSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ooura_Cos(long double* res1, long double* res2, XRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Ooura_Sin(long double* res1, long double* res2, XRealFuncPtr f1);










//*********************** Boost Odeint, extended precision **********************************

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Const_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Const_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Const_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Adaptive_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Adaptive_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Adaptive_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_XReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel);











#endif // MPNUMC_XREAL_H_INCLUDED












