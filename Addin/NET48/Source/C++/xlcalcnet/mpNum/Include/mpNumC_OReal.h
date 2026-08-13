
#ifndef MPNUMC_OREAL_H_INCLUDED
#define MPNUMC_OREAL_H_INCLUDED




/** ********************** Real Basic Functions, OReal ******************************** **/

//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_OReal_GetCoeff(ORealPtr result, long row, long col, mpNumMatrixPtr SourceMatrix);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_OReal_SetCoeff(mpNumMatrixPtr result, ORealPtr src, long row, long col);


MPNUMC_DLL_IMPORTEXPORT ORealPtr __cdecl Lib_OReal_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Clear(ORealPtr x);



/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_OReal(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_QReal(ORealPtr res, QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_LD(ORealPtr res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_D(ORealPtr res, const double x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_S(ORealPtr res, const float* x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Get_S(float* res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Get_D(double* res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Get_LD(long double* res, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_Si(ORealPtr res, const int32_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_Ui(ORealPtr res, const uint32_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_Si64(ORealPtr res, const int64_t x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_Ui64(ORealPtr res, const uint64_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Set_Str(ORealPtr res, const char * str);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Get_Str(char* cstr, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Get_HexStr(char* cstr, const ORealPtr x);





/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Neg(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Add(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sub(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Mul(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Div(ORealPtr res, const ORealPtr x, const ORealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Add_D(ORealPtr res, const ORealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sub_D(ORealPtr res, const ORealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_D_Sub(ORealPtr res, const ORealPtr x, const double y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Mul_D(ORealPtr res, const ORealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Div_D(ORealPtr res, const ORealPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_D_Div(ORealPtr res, const ORealPtr x, const double y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Add_Si(ORealPtr res, const ORealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sub_Si(ORealPtr res, const ORealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Si_Sub(ORealPtr res, const ORealPtr x, const int32_t y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Mul_Si(ORealPtr res, const ORealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Div_Si(ORealPtr res, const ORealPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Si_Div(ORealPtr res, const ORealPtr x, const int32_t y);


MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_OReal_LT(const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_OReal_GE(const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_OReal_GT(const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_OReal_LE(const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_OReal_EQ(const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_OReal_NE(const ORealPtr x, const ORealPtr y);





/* General functions for real numbers  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Fma(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Fmax(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Fmin(ORealPtr res, const ORealPtr x, const ORealPtr y);



/* Machine constants */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Zero(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_NegZero(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_One(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Inf(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_NegInf(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Nan(ORealPtr res);



/* Properties of numbers  */

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Signbit(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Finite(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isinf(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isposinf(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isneginf(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isnan(const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Iszero(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isposzero(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isnegzero(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isone(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isinteger(const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isnumber(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isregular(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isnormal(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Issubnormal(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Isunordered(const ORealPtr x, const ORealPtr y);


MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_FitsInt32(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_FitsInt64(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_FitsUInt32(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_FitsUInt64(const ORealPtr x);




/* Integer Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Nearbyint(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Rint(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_OReal_Lrint(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_OReal_Llrint(const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ceil(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Floor(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Trunc(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Round(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_OReal_Lround(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_OReal_Llround(const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_OReal_ToInt32(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_OReal_ToInt64(const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl Lib_OReal_ToUInt32(const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT uint64_t __cdecl Lib_OReal_ToUInt64(const ORealPtr x);




/* Floating point functions for real numbers */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Copysign(ORealPtr res, const ORealPtr x, const ORealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Frexp(ORealPtr res, const ORealPtr x, int* e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Logb(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_OReal_Ilogb(const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ldexp(ORealPtr res, const ORealPtr x, const long int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Scalbn(ORealPtr res, const ORealPtr x, const int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Scalbln(ORealPtr res, const ORealPtr x, const long int e);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Fdim(ORealPtr res, const ORealPtr x, const ORealPtr y);


/* Fraction and Remainder Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Modf(ORealPtr frac, const ORealPtr x, ORealPtr iptr);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Fmod(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Remainder(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Remquo(ORealPtr res, const ORealPtr x, const ORealPtr y, int* e);



/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Epsilon(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ulp(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Max(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Lowest(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Min(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Nextabove(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Nextbelow(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Nexttoward(ORealPtr res, const ORealPtr x, const ORealPtr y);





/* Mathematical Constants  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstDegree(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstPhi(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstLog2(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstLog10(ORealPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstPi(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstE(ORealPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstEulerGamma(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstApery(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstCatalan(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstGlaisher(ORealPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConstKhinchin(ORealPtr res);




/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Fabs(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sign(ORealPtr res, const ORealPtr x);



/* Roots and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sqrt(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sqrt1pm1(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Rsqrt(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Cbrt(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Root_Si(ORealPtr res, const ORealPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Exp(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Exp2(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Exp10(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Expm1(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Exp2m1(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Exp10m1(ORealPtr res, const ORealPtr x);



/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Log(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Log2(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Log10(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Log1p(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Log2p1(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Log10p1(ORealPtr res, const ORealPtr x);



/* Power functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Square(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Cube(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Hypot(ORealPtr res, const ORealPtr x, const ORealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Pow(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Powm1(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Pow1p(ORealPtr res, const ORealPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Pow1pm1(ORealPtr res, const ORealPtr x, const ORealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Pow_Si(ORealPtr res, const ORealPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Compound_Si(ORealPtr res, const ORealPtr x, const int32_t k);


/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sin(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Cos(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Tan(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Csc(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sec(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Cot(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SinPi(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_CosPi(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_TanPi(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_CscPi(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SecPi(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_CotPi(ORealPtr res, const ORealPtr x);


/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sinh(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Cosh(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Tanh(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Csch(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sech(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Coth(ORealPtr res, const ORealPtr x);


/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Asin(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Acos(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Atan(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Atan2(ORealPtr res, const ORealPtr x, const ORealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Acsc(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Asec(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Acot(ORealPtr res, const ORealPtr x);



/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Asinh(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Acosh(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Atanh(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Acsch(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Asech(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Acoth(ORealPtr res, const ORealPtr x);



/* Special functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Erf(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Erfc(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Tgamma(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Lgamma(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselJ0(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselJ1(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselJn(ORealPtr res, const int n, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselY0(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselY1(ORealPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselYn(ORealPtr res, const int n, const ORealPtr x);




/** ********************** Complex Basic Functions, Dcplx ******************************** **/

//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_OCplx_GetCoeff(OCplxPtr result, long row, long col, mpNumMatrixPtr SourceMatrix);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_OCplx_SetCoeff(mpNumMatrixPtr result, OCplxPtr source, long row, long col);


MPNUMC_DLL_IMPORTEXPORT OCplxPtr __cdecl Lib_OCplx_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Clear(OCplxPtr x);


/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Set(OCplxPtr res, const OCplxPtr x);


/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Neg(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Add(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sub(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Mul(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Div(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Add_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sub_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_OReal_Sub(OCplxPtr res, const OCplxPtr y, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Mul_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Div_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_OReal_Div(OCplxPtr res, const OCplxPtr y, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Add_D(OCplxPtr res, const OCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sub_D(OCplxPtr res, const OCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_D_Sub(OCplxPtr res, const OCplxPtr y, const double x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Mul_D(OCplxPtr res, const OCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Div_D(OCplxPtr res, const OCplxPtr x, const double y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_D_Div(OCplxPtr res, const OCplxPtr y, const double x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Add_Si(OCplxPtr res, const OCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sub_Si(OCplxPtr res, const OCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Si_Sub(OCplxPtr res, const OCplxPtr y, const int32_t x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Mul_Si(OCplxPtr res, const OCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Div_Si(OCplxPtr res, const OCplxPtr x, const int32_t y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Si_Div(OCplxPtr res, const OCplxPtr y, const int32_t x);



/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Set_Real(OCplxPtr res, const ORealPtr re);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Set2(OCplxPtr res, const ORealPtr re, const ORealPtr im);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Norm(ORealPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Abs(ORealPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Arg(ORealPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Imag(ORealPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Real(ORealPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Conj(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Proj(OCplxPtr res, const OCplxPtr x);





/* Roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sqrt(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sqrt1pm1(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Rsqrt(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Cbrt(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Root_Si(OCplxPtr res, const OCplxPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Exp(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Expi(OCplxPtr res, const ORealPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Exp2(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Exp10(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Expm1(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Exp2m1(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Exp10m1(OCplxPtr res, const OCplxPtr x);


/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Log(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Log2(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Log10(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Log1p(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Log2p1(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Log10p1(OCplxPtr res, const OCplxPtr x);




/* Power functions and roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Square(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Cube(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Pow(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Powm1(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Pow1p(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Pow1pm1(OCplxPtr res, const OCplxPtr x, const OCplxPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Pow_Si(OCplxPtr res, const OCplxPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Compound_Si(OCplxPtr res, const OCplxPtr x, const int32_t k);



/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sin(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Cos(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Tan(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Csc(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sec(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Cot(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_SinPi(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_CosPi(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_TanPi(OCplxPtr res, const OCplxPtr x);


/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sinh(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Cosh(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Tanh(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Csch(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Sech(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Coth(OCplxPtr res, const OCplxPtr x);



/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Asin(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Acos(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Atan(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Acsc(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Asec(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Acot(OCplxPtr res, const OCplxPtr x);



/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Asinh(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Acosh(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Atanh(OCplxPtr res, const OCplxPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Acsch(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Asech(OCplxPtr res, const OCplxPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OCplx_Acoth(OCplxPtr res, const OCplxPtr x);













//*********************** Boost Special functions , OReal **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BernoulliB2n(ORealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_TangentT2n(ORealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Sqrt1pm1_Boost(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SinPi_Boost(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_CosPi_Boost(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SincPi(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SinhcPi(ORealPtr res, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Tgamma_(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Tgamma1pm1(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Lgamma_(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Digamma(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Trigamma(ORealPtr res, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Factorial(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_DoubleFactorial(ORealPtr res, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Erf_(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Erfc_(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Erf_inv(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Erfc_inv(ORealPtr res, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_AiryAi(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_AiryBi(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_AiryAiPrime(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_AiryBiPrime(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Aizero(ORealPtr res, int n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Bizero(ORealPtr res, int n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ellint_1_K(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ellint_2_K(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Zeta(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ei(ORealPtr res, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LambertW0(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LambertWm1(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LambertW0Prime(ORealPtr res, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LambertWm1Prime(ORealPtr res, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Agm(ORealPtr res, const ORealPtr a, const ORealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Powm1_Boost(ORealPtr res, const ORealPtr a, const ORealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_TgammaRatio(ORealPtr res, const ORealPtr a, const ORealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_TgammaDeltaRatio(ORealPtr res, const ORealPtr a, const ORealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Binomial(ORealPtr res, const ORealPtr n, const ORealPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_RisingFactorial(ORealPtr res, const ORealPtr x, const ORealPtr n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_FallingFactorial(ORealPtr res, const ORealPtr x, const ORealPtr n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselJ(ORealPtr res, const ORealPtr v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselY(ORealPtr res, const ORealPtr v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselI(ORealPtr res, const ORealPtr v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselK(ORealPtr res, const ORealPtr v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SphBessel(ORealPtr res, const unsigned v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SphNeumann(ORealPtr res, const unsigned v, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselJPrime(ORealPtr res, const ORealPtr v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselYPrime(ORealPtr res, const ORealPtr v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselIPrime(ORealPtr res, const ORealPtr v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselKPrime(ORealPtr res, const ORealPtr v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SphBesselPrime(ORealPtr res, const unsigned v, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SphNeumannPrime(ORealPtr res, const unsigned v, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselJZero(ORealPtr res, const ORealPtr v, const int m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BesselYZero(ORealPtr res, const ORealPtr v, const int m);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GammaP(ORealPtr res, const ORealPtr a, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GammaQ(ORealPtr res, const ORealPtr a, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_TgammaLower(ORealPtr res, const ORealPtr a, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_TgammaUpper(ORealPtr res, const ORealPtr a, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GammaPInv(ORealPtr res, const ORealPtr a, const ORealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GammaQInv(ORealPtr res, const ORealPtr a, const ORealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GammaPInva(ORealPtr res, const ORealPtr p, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GammaQInva(ORealPtr res, const ORealPtr q, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GammaPDerivative(ORealPtr res, const ORealPtr a, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Beta(ORealPtr res, const ORealPtr a, const ORealPtr b);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LegendreP(ORealPtr res, int n, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LegendreQ(ORealPtr res, int n, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Laguerre(ORealPtr res, int n, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Hermite(ORealPtr res, int n, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ChebyshevT(ORealPtr res, int n, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ChebyshevU(ORealPtr res, int n, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Polygamma(ORealPtr res, int n, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_EllintRC(ORealPtr res, const ORealPtr x, const ORealPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ellint1F(ORealPtr res, const ORealPtr k, const ORealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ellint2F(ORealPtr res, const ORealPtr k, const ORealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ellint3K(ORealPtr res, const ORealPtr k, const ORealPtr n);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiCD(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiCN(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiCS(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiDC(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiDN(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiDS(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiNC(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiND(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiNS(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiSC(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiSD(ORealPtr res, const ORealPtr k, const ORealPtr u);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiSN(ORealPtr res, const ORealPtr k, const ORealPtr u);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_expint(ORealPtr res, const unsigned n, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_OwenT(ORealPtr res, const ORealPtr h, const ORealPtr a);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBeta(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetac(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetaNonNormalized(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetacNonNormalized(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetaInv(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetacInv(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetaInva(ORealPtr res, const ORealPtr b, const ORealPtr x, const ORealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetacInva(ORealPtr res, const ORealPtr b, const ORealPtr x, const ORealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetaInvb(ORealPtr res, const ORealPtr a, const ORealPtr x, const ORealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetacInvb(ORealPtr res, const ORealPtr a, const ORealPtr x, const ORealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_IBetaDerivative(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LegendrePM(ORealPtr res, const int n, const int m, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LaguerreM(ORealPtr res, const int n, const int m, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_EllipticRF(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_EllipticRD(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_EllipticRG(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ellint3F(ORealPtr res, const ORealPtr k, const ORealPtr n, const ORealPtr phi);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Gegenbauer(ORealPtr res, const int n, const ORealPtr lambda, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Jacobi(ORealPtr res, const int n, const ORealPtr alpha, const ORealPtr beta, const ORealPtr x);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SphericalHarmonicR(ORealPtr res, const int n, const int m, const ORealPtr theta, const ORealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SphericalHarmonicI(ORealPtr res, const int n, const int m, const ORealPtr theta, const ORealPtr phi);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_EllipticRJ(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z, const ORealPtr p);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Hypergeo0F1(ORealPtr res, const ORealPtr b, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Hypergeo1F1(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Hypergeo1F1r(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LogHypergeo1F1(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiTheta1(ORealPtr res, const ORealPtr x, const ORealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiTheta2(ORealPtr res, const ORealPtr x, const ORealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiTheta3(ORealPtr res, const ORealPtr x, const ORealPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_JacobiTheta4(ORealPtr res, const ORealPtr x, const ORealPtr q);






//*********************** Boost Distributions, OReal **********************************


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ArcsineDist(long Target, ORealPtr res, ORealPtr x, ORealPtr a, ORealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BernoulliDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BetaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BinomialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n, ORealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_CauchyDist(long Target, ORealPtr res, ORealPtr x, ORealPtr location, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Chi2Dist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ExponentialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lambda);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GumbelDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_FisherFDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mu, ORealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GammaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GeometricDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_HypergeometricDist(long Target, ORealPtr res, ORealPtr x, uint64_t r, uint64_t n, uint64_t N);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_InverseChi2Dist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr df, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_InverseGammaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_WaldDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LaplaceDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LogisticDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LognormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_NegBinomialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n, ORealPtr p);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Chi2NcDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu, ORealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_StudentTNcDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu, ORealPtr delta);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_FisherNcDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mu, ORealPtr nu, ORealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BetaNcDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b, ORealPtr nc);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_NormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr stdev);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ParetoDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_PoissonDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_RayleighDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SkewNormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr scale, ORealPtr shape);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_StudentTDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_TriangularDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lower, ORealPtr mode_, ORealPtr upper);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_WeibullDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_UniformDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lower, ORealPtr upper);




//*********************** New , octuple precision **********************************

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Logaddexp(ORealPtr res, const ORealPtr a, const ORealPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_HyperexponentialDist(long Target, ORealPtr res, ORealPtr xqp, mpNumMatrixPtr l1, mpNumMatrixPtr l2);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_KolmogorovSmirnovDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n);







//*********************** Boost Numerical Calculus, OReal **********************************


typedef void(*ORealFuncPtr) (void*, void*);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BracketRoot(ORealPtr res1, ORealPtr res2, int* iter, ORealFuncPtr f1, ORealPtr guess_, ORealPtr factor_, bool is_rising, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_NewtonRaphson(ORealPtr res,  int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Halley(ORealPtr res, int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Schroder(ORealPtr res, int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Brent_Minimum(ORealPtr res, ORealPtr resFx, int* iter, ORealFuncPtr f1, ORealPtr bracket_min_, ORealPtr bracket_max_, int bits, unsigned int maxit);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Trapezoidal(ORealPtr res1, ORealPtr res2, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GaussLegendre(ORealPtr res1, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GaussKronrod(ORealPtr res1, ORealPtr res2, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_TanhSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_SinhSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ExpSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ooura_Cos(ORealPtr res1, ORealPtr res2, ORealFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Ooura_Sin(ORealPtr res1, ORealPtr res2, ORealFuncPtr f1);





//*********************** Boost Odeint **********************************

MPNUMC_DLL_IMPORTEXPORT AnyPtr __cdecl Lib_OReal_StateInit_Func_N(int N);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_StateClear(mpNumMatrixPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_StateGetCoeff(ScalarPtr res, long row, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_StateSetCoeff(mpNumMatrixPtr result, ScalarPtr source, long row);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_StateGetSize(long *result, mpNumMatrixPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Const_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Const_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Const_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_);




MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Adaptive_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Adaptive_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Adaptive_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_);



//
//
////*********************** BoostEigen Optimization **********************************
//
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_LbfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr xPtr);
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_BfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr xPtr);
//
//
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_GradientDescentSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr xPtr);
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_OReal_ConjugatedGradientDescentSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr xPtr);
//
//









#endif // MPNUMC_OREAL_H_INCLUDED








