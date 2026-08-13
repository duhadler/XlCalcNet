
#ifndef MPNUMC_YReal_H_INCLUDED
#define MPNUMC_YReal_H_INCLUDED




/** ********************** Real Basic Functions, YReal ******************************** **/


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_YReal_GetCoeff(YRealPtr result, long row, long col, mpNumMatrixPtr SourceMatrix);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_YReal_SetCoeff(mpNumMatrixPtr result, YRealPtr src, long row, long col);


MPNUMC_DLL_IMPORTEXPORT YRealPtr __cdecl Lib_YReal_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Clear(YRealPtr x);



/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set(YRealPtr res, const YRealPtr x);

//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Fmpq(YRealPtr res, const FmpqPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Arb(YRealPtr res, const ArbPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Arf(YRealPtr res, const ArfPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Mpfi(YRealPtr res, const MpfiPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Mpfr(YRealPtr res, const MpfrPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Mpd(YRealPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_YReal(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_QReal(YRealPtr res, QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_LD(YRealPtr res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_D(YRealPtr res, const double x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_S(YRealPtr res, const float* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Si(YRealPtr res, const int32_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Ui(YRealPtr res, const uint32_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Si64(YRealPtr res, const int64_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Ui64(YRealPtr res, const uint64_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Set_Str(YRealPtr res, const char * str);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Get_Str(char* cstr, const YRealPtr x);





/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Neg(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Add(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sub(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Mul(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Div(YRealPtr res, const YRealPtr x, const YRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Add_D(YRealPtr res, const YRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sub_D(YRealPtr res, const YRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_D_Sub(YRealPtr res, const YRealPtr x, const double y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Mul_D(YRealPtr res, const YRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Div_D(YRealPtr res, const YRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_D_Div(YRealPtr res, const YRealPtr x, const double y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Add_Si(YRealPtr res, const YRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sub_Si(YRealPtr res, const YRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Si_Sub(YRealPtr res, const YRealPtr x, const int32_t y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Mul_Si(YRealPtr res, const YRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Div_Si(YRealPtr res, const YRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Si_Div(YRealPtr res, const YRealPtr x, const int32_t y);


MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_YReal_LT(const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_YReal_GE(const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_YReal_GT(const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_YReal_LE(const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_YReal_EQ(const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_YReal_NE(const YRealPtr x, const YRealPtr y);





/* General functions for real numbers  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Fma(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Fmax(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Fmin(YRealPtr res, const YRealPtr x, const YRealPtr y);



/* Machine constants */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Zero(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_NegZero(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_One(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Inf(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_NegInf(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Nan(YRealPtr res);



/* Properties of numbers  */

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Signbit(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Finite(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isinf(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isposinf(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isneginf(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isnan(const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Iszero(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isposzero(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isnegzero(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isone(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isinteger(const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isnumber(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isregular(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isnormal(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Issubnormal(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Isunordered(const YRealPtr x, const YRealPtr y);


MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_FitsInt32(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_FitsInt64(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_FitsUInt32(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_FitsUInt64(const YRealPtr x);




/* Integer Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Nearbyint(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Rint(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_YReal_Lrint(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_YReal_Llrint(const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ceil(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Floor(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Trunc(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Round(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_YReal_Lround(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_YReal_Llround(const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_YReal_ToInt32(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_YReal_ToInt64(const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl Lib_YReal_ToUInt32(const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT uint64_t __cdecl Lib_YReal_ToUInt64(const YRealPtr x);




/* Floating point functions for real numbers */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Copysign(YRealPtr res, const YRealPtr x, const YRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Frexp(YRealPtr res, const YRealPtr x, long int* e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Logb(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_YReal_Ilogb(const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ldexp(YRealPtr res, const YRealPtr x, const long int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Scalbn(YRealPtr res, const YRealPtr x, const int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Scalbln(YRealPtr res, const YRealPtr x, const long int e);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Fdim(YRealPtr res, const YRealPtr x, const YRealPtr y);


/* Fraction and Remainder Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Modf(YRealPtr frac, const YRealPtr x, YRealPtr iptr);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Fmod(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Remainder(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Remquo(YRealPtr res, const YRealPtr x, const YRealPtr y, int* e);



/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Epsilon(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ulp(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Max(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Lowest(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Min(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Nextabove(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Nextbelow(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Nexttoward(YRealPtr res, const YRealPtr x, const YRealPtr y);





/* Mathematical Constants  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstDegree(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstPhi(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstLog2(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstLog10(YRealPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstPi(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstE(YRealPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstEulerGamma(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstApery(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstCatalan(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstGlaisher(YRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConstKhinchin(YRealPtr res);




/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Fabs(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sign(YRealPtr res, const YRealPtr x);



/* Roots and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sqrt(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sqrt1pm1(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Rsqrt(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Cbrt(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Root_Si(YRealPtr res, const YRealPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Exp(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Exp2(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Exp10(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Expm1(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Exp2m1(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Exp10m1(YRealPtr res, const YRealPtr x);



/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Log(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Log2(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Log10(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Log1p(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Log2p1(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Log10p1(YRealPtr res, const YRealPtr x);



/* Power functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Square(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Cube(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Hypot(YRealPtr res, const YRealPtr x, const YRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Pow(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Powm1(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Pow1p(YRealPtr res, const YRealPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Pow1pm1(YRealPtr res, const YRealPtr x, const YRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Pow_Si(YRealPtr res, const YRealPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Compound_Si(YRealPtr res, const YRealPtr x, const int32_t k);


/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sin(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Cos(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Tan(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Csc(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sec(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Cot(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SinPi(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_CosPi(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_TanPi(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_CscPi(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SecPi(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_CotPi(YRealPtr res, const YRealPtr x);


/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sinh(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Cosh(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Tanh(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Csch(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sech(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Coth(YRealPtr res, const YRealPtr x);


/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Asin(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Acos(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Atan(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Atan2(YRealPtr res, const YRealPtr x, const YRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Acsc(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Asec(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Acot(YRealPtr res, const YRealPtr x);



/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Asinh(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Acosh(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Atanh(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Acsch(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Asech(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Acoth(YRealPtr res, const YRealPtr x);



/* Special functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Erf(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Erfc(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Tgamma(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Lgamma(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselJ0(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselJ1(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselJn(YRealPtr res, const int n, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselY0(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselY1(YRealPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselYn(YRealPtr res, const int n, const YRealPtr x);




/** ********************** Complex Basic Functions, Dcplx ******************************** **/


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_YCplx_GetCoeff(YCplxPtr result, long row, long col, mpNumMatrixPtr SourceMatrix);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_YCplx_SetCoeff(mpNumMatrixPtr result, YCplxPtr source, long row, long col);


MPNUMC_DLL_IMPORTEXPORT YCplxPtr __cdecl Lib_YCplx_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Clear(YCplxPtr x);


/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Set(YCplxPtr res, const YCplxPtr x);


/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Neg(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Add(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sub(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Mul(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Div(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Add_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sub_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_YReal_Sub(YCplxPtr res, const YCplxPtr y, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Mul_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Div_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_YReal_Div(YCplxPtr res, const YCplxPtr y, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Add_D(YCplxPtr res, const YCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sub_D(YCplxPtr res, const YCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_D_Sub(YCplxPtr res, const YCplxPtr y, const double x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Mul_D(YCplxPtr res, const YCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Div_D(YCplxPtr res, const YCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_D_Div(YCplxPtr res, const YCplxPtr y, const double x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Add_Si(YCplxPtr res, const YCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sub_Si(YCplxPtr res, const YCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Si_Sub(YCplxPtr res, const YCplxPtr y, const int32_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Mul_Si(YCplxPtr res, const YCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Div_Si(YCplxPtr res, const YCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Si_Div(YCplxPtr res, const YCplxPtr y, const int32_t x);



/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Set_Real(YCplxPtr res, const YRealPtr re);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Set2(YCplxPtr res, const YRealPtr re, const YRealPtr im);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Norm(YRealPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Abs(YRealPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Arg(YRealPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Imag(YRealPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Real(YRealPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Conj(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Proj(YCplxPtr res, const YCplxPtr x);





/* Roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sqrt(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sqrt1pm1(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Rsqrt(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Cbrt(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Root_Si(YCplxPtr res, const YCplxPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Exp(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Expi(YCplxPtr res, const YRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Exp2(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Exp10(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Expm1(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Exp2m1(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Exp10m1(YCplxPtr res, const YCplxPtr x);


/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Log(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Log2(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Log10(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Log1p(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Log2p1(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Log10p1(YCplxPtr res, const YCplxPtr x);




/* Power functions and roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Square(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Cube(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Pow(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Powm1(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Pow1p(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Pow1pm1(YCplxPtr res, const YCplxPtr x, const YCplxPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Pow_Si(YCplxPtr res, const YCplxPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Compound_Si(YCplxPtr res, const YCplxPtr x, const int32_t k);



/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sin(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Cos(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Tan(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Csc(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sec(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Cot(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_SinPi(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_CosPi(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_TanPi(YCplxPtr res, const YCplxPtr x);


/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sinh(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Cosh(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Tanh(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Csch(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Sech(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Coth(YCplxPtr res, const YCplxPtr x);



/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Asin(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Acos(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Atan(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Acsc(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Asec(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Acot(YCplxPtr res, const YCplxPtr x);



/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Asinh(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Acosh(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Atanh(YCplxPtr res, const YCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Acsch(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Asech(YCplxPtr res, const YCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YCplx_Acoth(YCplxPtr res, const YCplxPtr x);











//*********************** Boost Special functions , YReal **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BernoulliB2n(YRealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_TangentT2n(YRealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Sqrt1pm1_Boost(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SinPi_Boost(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_CosPi_Boost(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SincPi(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SinhcPi(YRealPtr res, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Tgamma_(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Tgamma1pm1(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Lgamma_(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Digamma(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Trigamma(YRealPtr res, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Factorial(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_DoubleFactorial(YRealPtr res, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Erf_(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Erfc_(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Erf_inv(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Erfc_inv(YRealPtr res, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_AiryAi(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_AiryBi(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_AiryAiPrime(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_AiryBiPrime(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Aizero(YRealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Bizero(YRealPtr res, int n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ellint_1_K(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ellint_2_K(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Zeta(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ei(YRealPtr res, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LambertW0(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LambertWm1(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LambertW0Prime(YRealPtr res, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LambertWm1Prime(YRealPtr res, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Powm1_Boost(YRealPtr res, const YRealPtr a, const YRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_TgammaRatio(YRealPtr res, const YRealPtr a, const YRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_TgammaDeltaRatio(YRealPtr res, const YRealPtr a, const YRealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Binomial(YRealPtr res, const YRealPtr n, const YRealPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_RisingFactorial(YRealPtr res, const YRealPtr x, const YRealPtr n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_FallingFactorial(YRealPtr res, const YRealPtr x, const YRealPtr n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselJ(YRealPtr res, const YRealPtr v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselY(YRealPtr res, const YRealPtr v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselI(YRealPtr res, const YRealPtr v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselK(YRealPtr res, const YRealPtr v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SphBessel(YRealPtr res, const unsigned v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SphNeumann(YRealPtr res, const unsigned v, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselJPrime(YRealPtr res, const YRealPtr v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselYPrime(YRealPtr res, const YRealPtr v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselIPrime(YRealPtr res, const YRealPtr v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselKPrime(YRealPtr res, const YRealPtr v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SphBesselPrime(YRealPtr res, const unsigned v, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SphNeumannPrime(YRealPtr res, const unsigned v, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselJZero(YRealPtr res, const YRealPtr v, const int m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BesselYZero(YRealPtr res, const YRealPtr v, const int m);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GammaP(YRealPtr res, const YRealPtr a, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GammaQ(YRealPtr res, const YRealPtr a, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_TgammaLower(YRealPtr res, const YRealPtr a, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_TgammaUpper(YRealPtr res, const YRealPtr a, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GammaPInv(YRealPtr res, const YRealPtr a, const YRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GammaQInv(YRealPtr res, const YRealPtr a, const YRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GammaPInva(YRealPtr res, const YRealPtr p, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GammaQInva(YRealPtr res, const YRealPtr q, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GammaPDerivative(YRealPtr res, const YRealPtr a, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Beta(YRealPtr res, const YRealPtr a, const YRealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LegendreP(YRealPtr res, int n, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LegendreQ(YRealPtr res, int n, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Laguerre(YRealPtr res, int n, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Hermite(YRealPtr res, int n, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ChebyshevT(YRealPtr res, int n, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ChebyshevU(YRealPtr res, int n, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Polygamma(YRealPtr res, int n, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_EllintRC(YRealPtr res, const YRealPtr x, const YRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ellint1F(YRealPtr res, const YRealPtr k, const YRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ellint2F(YRealPtr res, const YRealPtr k, const YRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ellint3K(YRealPtr res, const YRealPtr k, const YRealPtr n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiCD(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiCN(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiCS(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiDC(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiDN(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiDS(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiNC(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiND(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiNS(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiSC(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiSD(YRealPtr res, const YRealPtr k, const YRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiSN(YRealPtr res, const YRealPtr k, const YRealPtr u);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_expint(YRealPtr res, const unsigned n, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_OwenT(YRealPtr res, const YRealPtr h, const YRealPtr a);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBeta(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetac(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetaNonNormalized(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetacNonNormalized(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetaInv(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetacInv(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetaInva(YRealPtr res, const YRealPtr b, const YRealPtr x, const YRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetacInva(YRealPtr res, const YRealPtr b, const YRealPtr x, const YRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetaInvb(YRealPtr res, const YRealPtr a, const YRealPtr x, const YRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetacInvb(YRealPtr res, const YRealPtr a, const YRealPtr x, const YRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_IBetaDerivative(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LegendrePM(YRealPtr res, const int n, const int m, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LaguerreM(YRealPtr res, const int n, const int m, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_EllipticRF(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_EllipticRD(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ellint3F(YRealPtr res, const YRealPtr k, const YRealPtr n, const YRealPtr phi);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SphericalHarmonicR(YRealPtr res, const int n, const int m, const YRealPtr theta, const YRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SphericalHarmonicI(YRealPtr res, const int n, const int m, const YRealPtr theta, const YRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_EllipticRJ(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z, const YRealPtr p);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Hypergeo0F1(YRealPtr res, const YRealPtr b, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Hypergeo1F1(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Hypergeo1F1r(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LogHypergeo1F1(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiTheta1(YRealPtr res, const YRealPtr x, const YRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiTheta2(YRealPtr res, const YRealPtr x, const YRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiTheta3(YRealPtr res, const YRealPtr x, const YRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_JacobiTheta4(YRealPtr res, const YRealPtr x, const YRealPtr q);






//*********************** Boost Distributions, YReal **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ArcsineDist(long Target, YRealPtr res, YRealPtr x, YRealPtr a, YRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BernoulliDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BetaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BinomialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr n, YRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_CauchyDist(long Target, YRealPtr res, YRealPtr x, YRealPtr location, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Chi2Dist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ExponentialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lambda);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ExtremeValueDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_FisherFDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mu, YRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GammaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GeometricDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_HypergeometricDist(long Target, YRealPtr res, YRealPtr x, unsigned r, unsigned n, unsigned N);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_InverseChi2Dist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr df, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_InverseGammaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_WaldDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LaplaceDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LogisticDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LognormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_NegBinomialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr n, YRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Chi2NcDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu, YRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_StudentTNcDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu, YRealPtr delta);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_FisherNcDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mu, YRealPtr nu, YRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BetaNcDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b, YRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_NormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr stdev);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ParetoDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_PoissonDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_RayleighDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SkewNormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr scale, YRealPtr shape);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_StudentTDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_TriangularDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lower, YRealPtr mode_, YRealPtr upper);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_WeibullDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_UniformDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lower, YRealPtr upper);







//*********************** Boost Numerical Calculus, YReal **********************************


typedef void(*YRealFuncPtr) (void*, void*);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BracketRoot(YRealPtr res1, YRealPtr res2, int* iter, YRealFuncPtr f1, YRealPtr guess_, YRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_NewtonRaphson(YRealPtr res,  int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Halley(YRealPtr res, int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Schroder(YRealPtr res, int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Brent_Minimum(YRealPtr res, YRealPtr resFx, int* iter, YRealFuncPtr f1, YRealPtr bracket_min_, YRealPtr bracket_max_, int bits, unsigned int maxit);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Trapezoidal(YRealPtr res1, YRealPtr res2, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GaussLegendre(YRealPtr res1, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GaussKronrod(YRealPtr res1, YRealPtr res2, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_TanhSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_SinhSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ExpSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ooura_Cos(YRealPtr res1, YRealPtr res2, YRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Ooura_Sin(YRealPtr res1, YRealPtr res2, YRealFuncPtr f1);





//*********************** Boost Odeint **********************************

MPNUMC_DLL_IMPORTEXPORT AnyPtr __cdecl Lib_YReal_StateInit_Func_N(int N);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_StateClear(mpNumMatrixPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_StateGetCoeff(ScalarPtr res, long row, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_StateSetCoeff(mpNumMatrixPtr result, ScalarPtr source, long row);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_StateGetSize(long *result, mpNumMatrixPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Const_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Const_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Const_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_);




MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Adaptive_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Adaptive_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Adaptive_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_);







//*********************** BoostEigen Optimization **********************************

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_GradientDescentSolverSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_ConjugatedGradientDescentSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_BfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_YReal_LbfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr);





#endif // MPNUMC_YReal_H_INCLUDED








