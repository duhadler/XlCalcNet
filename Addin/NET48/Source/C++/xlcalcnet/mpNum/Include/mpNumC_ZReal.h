
#ifndef MPNUMC_ZReal_H_INCLUDED
#define MPNUMC_ZReal_H_INCLUDED




/** ********************** Real Basic Functions, ZReal ******************************** **/


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_ZReal_GetCoeff(ZRealPtr result, long row, long col, mpNumMatrixPtr SourceMatrix);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_ZReal_SetCoeff(mpNumMatrixPtr result, ZRealPtr src, long row, long col);


MPNUMC_DLL_IMPORTEXPORT ZRealPtr __cdecl Lib_ZReal_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Clear(ZRealPtr x);



/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set(ZRealPtr res, const ZRealPtr x);

//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Fmpq(ZRealPtr res, const FmpqPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Arb(ZRealPtr res, const ArbPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Arf(ZRealPtr res, const ArfPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Mpfi(ZRealPtr res, const MpfiPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Mpfr(ZRealPtr res, const MpfrPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Mpd(ZRealPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_ZReal(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_QReal(ZRealPtr res, QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_LD(ZRealPtr res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_D(ZRealPtr res, const double x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_S(ZRealPtr res, const float* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Si(ZRealPtr res, const int32_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Ui(ZRealPtr res, const uint32_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Si64(ZRealPtr res, const int64_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Ui64(ZRealPtr res, const uint64_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Set_Str(ZRealPtr res, const char * str);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Get_Str(char* cstr, const ZRealPtr x);





/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Neg(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Add(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sub(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Mul(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Div(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Add_D(ZRealPtr res, const ZRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sub_D(ZRealPtr res, const ZRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_D_Sub(ZRealPtr res, const ZRealPtr x, const double y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Mul_D(ZRealPtr res, const ZRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Div_D(ZRealPtr res, const ZRealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_D_Div(ZRealPtr res, const ZRealPtr x, const double y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Add_Si(ZRealPtr res, const ZRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sub_Si(ZRealPtr res, const ZRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Si_Sub(ZRealPtr res, const ZRealPtr x, const int32_t y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Mul_Si(ZRealPtr res, const ZRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Div_Si(ZRealPtr res, const ZRealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Si_Div(ZRealPtr res, const ZRealPtr x, const int32_t y);


MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_ZReal_LT(const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_ZReal_GE(const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_ZReal_GT(const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_ZReal_LE(const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_ZReal_EQ(const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_ZReal_NE(const ZRealPtr x, const ZRealPtr y);





/* General functions for real numbers  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Fma(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Fmax(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Fmin(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);



/* Machine constants */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Zero(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_NegZero(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_One(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Inf(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_NegInf(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Nan(ZRealPtr res);



/* Properties of numbers  */

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Signbit(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Finite(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isinf(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isposinf(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isneginf(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isnan(const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Iszero(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isposzero(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isnegzero(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isone(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isinteger(const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isnumber(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isregular(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isnormal(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Issubnormal(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Isunordered(const ZRealPtr x, const ZRealPtr y);


MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_FitsInt32(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_FitsInt64(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_FitsUInt32(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_FitsUInt64(const ZRealPtr x);




/* Integer Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Nearbyint(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Rint(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_ZReal_Lrint(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_ZReal_Llrint(const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ceil(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Floor(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Trunc(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Round(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_ZReal_Lround(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_ZReal_Llround(const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_ZReal_ToInt32(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_ZReal_ToInt64(const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl Lib_ZReal_ToUInt32(const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT uint64_t __cdecl Lib_ZReal_ToUInt64(const ZRealPtr x);




/* Floating point functions for real numbers */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Copysign(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Frexp(ZRealPtr res, const ZRealPtr x, long int* e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Logb(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_ZReal_Ilogb(const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ldexp(ZRealPtr res, const ZRealPtr x, const long int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Scalbn(ZRealPtr res, const ZRealPtr x, const int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Scalbln(ZRealPtr res, const ZRealPtr x, const long int e);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Fdim(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);


/* Fraction and Remainder Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Modf(ZRealPtr frac, const ZRealPtr x, ZRealPtr iptr);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Fmod(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Remainder(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Remquo(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, int* e);



/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Epsilon(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ulp(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Max(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Lowest(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Min(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Nextabove(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Nextbelow(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Nexttoward(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);





/* Mathematical Constants  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstDegree(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstPhi(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstLog2(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstLog10(ZRealPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstPi(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstE(ZRealPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstEulerGamma(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstApery(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstCatalan(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstGlaisher(ZRealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConstKhinchin(ZRealPtr res);




/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Fabs(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sign(ZRealPtr res, const ZRealPtr x);



/* Roots and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sqrt(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sqrt1pm1(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Rsqrt(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Cbrt(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Root_Si(ZRealPtr res, const ZRealPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Exp(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Exp2(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Exp10(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Expm1(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Exp2m1(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Exp10m1(ZRealPtr res, const ZRealPtr x);



/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Log(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Log2(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Log10(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Log1p(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Log2p1(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Log10p1(ZRealPtr res, const ZRealPtr x);



/* Power functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Square(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Cube(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Hypot(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Pow(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Powm1(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Pow1p(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Pow1pm1(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Pow_Si(ZRealPtr res, const ZRealPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Compound_Si(ZRealPtr res, const ZRealPtr x, const int32_t k);


/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sin(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Cos(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Tan(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Csc(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sec(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Cot(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SinPi(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_CosPi(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_TanPi(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_CscPi(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SecPi(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_CotPi(ZRealPtr res, const ZRealPtr x);


/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sinh(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Cosh(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Tanh(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Csch(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sech(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Coth(ZRealPtr res, const ZRealPtr x);


/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Asin(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Acos(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Atan(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Atan2(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Acsc(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Asec(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Acot(ZRealPtr res, const ZRealPtr x);



/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Asinh(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Acosh(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Atanh(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Acsch(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Asech(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Acoth(ZRealPtr res, const ZRealPtr x);



/* Special functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Erf(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Erfc(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Tgamma(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Lgamma(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselJ0(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselJ1(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselJn(ZRealPtr res, const int n, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselY0(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselY1(ZRealPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselYn(ZRealPtr res, const int n, const ZRealPtr x);




/** ********************** Complex Basic Functions, Dcplx ******************************** **/


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_ZCplx_GetCoeff(ZCplxPtr result, long row, long col, mpNumMatrixPtr SourceMatrix);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_ZCplx_SetCoeff(mpNumMatrixPtr result, ZCplxPtr source, long row, long col);


MPNUMC_DLL_IMPORTEXPORT ZCplxPtr __cdecl Lib_ZCplx_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Clear(ZCplxPtr x);


/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Set(ZCplxPtr res, const ZCplxPtr x);


/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Neg(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Add(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sub(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Mul(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Div(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Add_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sub_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_ZReal_Sub(ZCplxPtr res, const ZCplxPtr y, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Mul_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Div_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_ZReal_Div(ZCplxPtr res, const ZCplxPtr y, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Add_D(ZCplxPtr res, const ZCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sub_D(ZCplxPtr res, const ZCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_D_Sub(ZCplxPtr res, const ZCplxPtr y, const double x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Mul_D(ZCplxPtr res, const ZCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Div_D(ZCplxPtr res, const ZCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_D_Div(ZCplxPtr res, const ZCplxPtr y, const double x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Add_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sub_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Si_Sub(ZCplxPtr res, const ZCplxPtr y, const int32_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Mul_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Div_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Si_Div(ZCplxPtr res, const ZCplxPtr y, const int32_t x);



/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Set_Real(ZCplxPtr res, const ZRealPtr re);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Set2(ZCplxPtr res, const ZRealPtr re, const ZRealPtr im);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Norm(ZRealPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Abs(ZRealPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Arg(ZRealPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Imag(ZRealPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Real(ZRealPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Conj(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Proj(ZCplxPtr res, const ZCplxPtr x);





/* Roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sqrt(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sqrt1pm1(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Rsqrt(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Cbrt(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Root_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Exp(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Expi(ZCplxPtr res, const ZRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Exp2(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Exp10(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Expm1(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Exp2m1(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Exp10m1(ZCplxPtr res, const ZCplxPtr x);


/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Log(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Log2(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Log10(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Log1p(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Log2p1(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Log10p1(ZCplxPtr res, const ZCplxPtr x);




/* Power functions and roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Square(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Cube(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Pow(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Powm1(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Pow1p(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Pow1pm1(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Pow_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Compound_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k);



/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sin(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Cos(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Tan(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Csc(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sec(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Cot(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_SinPi(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_CosPi(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_TanPi(ZCplxPtr res, const ZCplxPtr x);


/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sinh(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Cosh(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Tanh(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Csch(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Sech(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Coth(ZCplxPtr res, const ZCplxPtr x);



/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Asin(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Acos(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Atan(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Acsc(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Asec(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Acot(ZCplxPtr res, const ZCplxPtr x);



/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Asinh(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Acosh(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Atanh(ZCplxPtr res, const ZCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Acsch(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Asech(ZCplxPtr res, const ZCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZCplx_Acoth(ZCplxPtr res, const ZCplxPtr x);











//*********************** Boost Special functions , ZReal **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BernoulliB2n(ZRealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_TangentT2n(ZRealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Sqrt1pm1_Boost(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SinPi_Boost(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_CosPi_Boost(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SincPi(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SinhcPi(ZRealPtr res, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Tgamma_(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Tgamma1pm1(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Lgamma_(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Digamma(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Trigamma(ZRealPtr res, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Factorial(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_DoubleFactorial(ZRealPtr res, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Erf_(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Erfc_(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Erf_inv(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Erfc_inv(ZRealPtr res, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_AiryAi(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_AiryBi(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_AiryAiPrime(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_AiryBiPrime(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Aizero(ZRealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Bizero(ZRealPtr res, int n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ellint_1_K(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ellint_2_K(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Zeta(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ei(ZRealPtr res, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LambertW0(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LambertWm1(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LambertW0Prime(ZRealPtr res, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LambertWm1Prime(ZRealPtr res, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Powm1_Boost(ZRealPtr res, const ZRealPtr a, const ZRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_TgammaRatio(ZRealPtr res, const ZRealPtr a, const ZRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_TgammaDeltaRatio(ZRealPtr res, const ZRealPtr a, const ZRealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Binomial(ZRealPtr res, const ZRealPtr n, const ZRealPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_RisingFactorial(ZRealPtr res, const ZRealPtr x, const ZRealPtr n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_FallingFactorial(ZRealPtr res, const ZRealPtr x, const ZRealPtr n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselJ(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselY(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselI(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselK(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SphBessel(ZRealPtr res, const unsigned v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SphNeumann(ZRealPtr res, const unsigned v, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselJPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselYPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselIPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselKPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SphBesselPrime(ZRealPtr res, const unsigned v, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SphNeumannPrime(ZRealPtr res, const unsigned v, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselJZero(ZRealPtr res, const ZRealPtr v, const int m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BesselYZero(ZRealPtr res, const ZRealPtr v, const int m);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GammaP(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GammaQ(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_TgammaLower(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_TgammaUpper(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GammaPInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GammaQInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GammaPInva(ZRealPtr res, const ZRealPtr p, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GammaQInva(ZRealPtr res, const ZRealPtr q, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GammaPDerivative(ZRealPtr res, const ZRealPtr a, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Beta(ZRealPtr res, const ZRealPtr a, const ZRealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LegendreP(ZRealPtr res, int n, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LegendreQ(ZRealPtr res, int n, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Laguerre(ZRealPtr res, int n, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Hermite(ZRealPtr res, int n, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ChebyshevT(ZRealPtr res, int n, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ChebyshevU(ZRealPtr res, int n, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Polygamma(ZRealPtr res, int n, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_EllintRC(ZRealPtr res, const ZRealPtr x, const ZRealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ellint1F(ZRealPtr res, const ZRealPtr k, const ZRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ellint2F(ZRealPtr res, const ZRealPtr k, const ZRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ellint3K(ZRealPtr res, const ZRealPtr k, const ZRealPtr n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiCD(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiCN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiCS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiDC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiDN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiDS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiNC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiND(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiNS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiSC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiSD(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiSN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_expint(ZRealPtr res, const unsigned n, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_OwenT(ZRealPtr res, const ZRealPtr h, const ZRealPtr a);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBeta(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetac(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetaNonNormalized(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetacNonNormalized(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetaInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetacInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetaInva(ZRealPtr res, const ZRealPtr b, const ZRealPtr x, const ZRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetacInva(ZRealPtr res, const ZRealPtr b, const ZRealPtr x, const ZRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetaInvb(ZRealPtr res, const ZRealPtr a, const ZRealPtr x, const ZRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetacInvb(ZRealPtr res, const ZRealPtr a, const ZRealPtr x, const ZRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_IBetaDerivative(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LegendrePM(ZRealPtr res, const int n, const int m, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LaguerreM(ZRealPtr res, const int n, const int m, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_EllipticRF(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_EllipticRD(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ellint3F(ZRealPtr res, const ZRealPtr k, const ZRealPtr n, const ZRealPtr phi);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SphericalHarmonicR(ZRealPtr res, const int n, const int m, const ZRealPtr theta, const ZRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SphericalHarmonicI(ZRealPtr res, const int n, const int m, const ZRealPtr theta, const ZRealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_EllipticRJ(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z, const ZRealPtr p);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Hypergeo0F1(ZRealPtr res, const ZRealPtr b, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Hypergeo1F1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Hypergeo1F1r(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LogHypergeo1F1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiTheta1(ZRealPtr res, const ZRealPtr x, const ZRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiTheta2(ZRealPtr res, const ZRealPtr x, const ZRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiTheta3(ZRealPtr res, const ZRealPtr x, const ZRealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_JacobiTheta4(ZRealPtr res, const ZRealPtr x, const ZRealPtr q);






//*********************** Boost Distributions, ZReal **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ArcsineDist(long Target, ZRealPtr res, ZRealPtr x, ZRealPtr a, ZRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BernoulliDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BetaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BinomialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr n, ZRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_CauchyDist(long Target, ZRealPtr res, ZRealPtr x, ZRealPtr location, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Chi2Dist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ExponentialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lambda);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ExtremeValueDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_FisherFDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mu, ZRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GammaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GeometricDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_HypergeometricDist(long Target, ZRealPtr res, ZRealPtr x, unsigned r, unsigned n, unsigned N);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_InverseChi2Dist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr df, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_InverseGammaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_WaldDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LaplaceDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LogisticDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LognormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_NegBinomialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr n, ZRealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Chi2NcDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu, ZRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_StudentTNcDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu, ZRealPtr delta);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_FisherNcDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mu, ZRealPtr nu, ZRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BetaNcDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b, ZRealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_NormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr stdev);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ParetoDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_PoissonDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_RayleighDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SkewNormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr scale, ZRealPtr shape);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_StudentTDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_TriangularDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lower, ZRealPtr mode_, ZRealPtr upper);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_WeibullDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_UniformDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lower, ZRealPtr upper);







//*********************** Boost Numerical Calculus, ZReal **********************************


typedef void(*ZRealFuncPtr) (void*, void*);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BracketRoot(ZRealPtr res1, ZRealPtr res2, int* iter, ZRealFuncPtr f1, ZRealPtr guess_, ZRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_NewtonRaphson(ZRealPtr res,  int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Halley(ZRealPtr res, int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Schroder(ZRealPtr res, int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Brent_Minimum(ZRealPtr res, ZRealPtr resFx, int* iter, ZRealFuncPtr f1, ZRealPtr bracket_min_, ZRealPtr bracket_max_, int bits, unsigned int maxit);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Trapezoidal(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GaussLegendre(ZRealPtr res1, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GaussKronrod(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_TanhSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_SinhSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ExpSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ooura_Cos(ZRealPtr res1, ZRealPtr res2, ZRealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Ooura_Sin(ZRealPtr res1, ZRealPtr res2, ZRealFuncPtr f1);





//*********************** Boost Odeint **********************************

MPNUMC_DLL_IMPORTEXPORT AnyPtr __cdecl Lib_ZReal_StateInit_Func_N(int N);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_StateClear(mpNumMatrixPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_StateGetCoeff(ScalarPtr res, long row, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_StateSetCoeff(mpNumMatrixPtr result, ScalarPtr source, long row);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_StateGetSize(long *result, mpNumMatrixPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Const_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Const_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Const_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_);




MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Adaptive_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Adaptive_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Adaptive_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_);







//*********************** BoostEigen Optimization **********************************

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_GradientDescentSolverSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_ConjugatedGradientDescentSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_BfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_ZReal_LbfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr);





#endif // MPNUMC_ZReal_H_INCLUDED








