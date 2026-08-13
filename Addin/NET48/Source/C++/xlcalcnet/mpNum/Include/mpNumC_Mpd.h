

#ifndef MPNUMC_MPD_H_INCLUDED
#define MPNUMC_MPD_H_INCLUDED

// See also: https://www.bytereef.org/mpdecimal/doc/libmpdec/index.html

MPNUMC_DLL_IMPORTEXPORT int32_t  __cdecl Lib_Mpd_SetPrec(uint32_t prec);  /* EXPORT */
//
// Decimal128context: (line 254)

/** ********************** Real Basic Functions, Mpd ******************************** **/


MPNUMC_DLL_IMPORTEXPORT MpdPtr __cdecl Lib_Mpd_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Clear(MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Defaultcontext();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Basiccontext();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Maxcontext();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Decimal32context();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Decimal64context();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Decimal128context();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_BoostCppDecContext();

MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_Mpd_GetPrec();
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_Mpd_GetEmax();
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_Mpd_GetEmin();
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_Mpd_GetEtiny();
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Lib_Mpd_GetEtop();



/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set(MpdPtr res, const MpdPtr x);

//MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Fmpq(MpdPtr res, const FmpqPtr x);
//MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Arb(MpdPtr res, const ArbPtr x);
//MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Arf(MpdPtr res, const ArfPtr x);
//MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Mpfi(MpdPtr res, const char *template1, const MpfiPtr x);
//MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Mpfr(MpdPtr res, const char *template1, const MpfrPtr x);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Mpd(MpdPtr res, const MpdPtr x);
//MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_CReal(MpdPtr res, const CRealPtr x);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_QReal(MpdPtr res, const QRealPtr x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_LD(MpdPtr res, const long double* x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_D(MpdPtr res, const double d);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_S(MpdPtr res, const float* d);


MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Si(MpdPtr res, const int32_t a);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Ui(MpdPtr res, const uint32_t a);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Si64(MpdPtr res, const int64_t a);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Ui64(MpdPtr res, const uint64_t a);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Str(MpdPtr x, const char * str);
MPNUMC_DLL_IMPORTEXPORT uint32_t  __cdecl Lib_Mpd_SizeInBase10(const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT int64_t  __cdecl Lib_Mpd_Get_Str(char* dest, const MpdPtr x);



/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Neg(MpdPtr f, MpdPtr g);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Add(MpdPtr x, MpdPtr y, MpdPtr z);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Sub(MpdPtr x, MpdPtr y, MpdPtr z);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Mul(MpdPtr x, MpdPtr y, MpdPtr z);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Div(MpdPtr x, MpdPtr y, MpdPtr z);


MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Add_D(MpdPtr f, MpdPtr g, double x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Sub_D(MpdPtr f, MpdPtr g, double x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_D_Sub(MpdPtr f, MpdPtr g, double x);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Mul_D(MpdPtr f, MpdPtr g, double x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Div_D(MpdPtr f, MpdPtr g, double x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_D_Div(MpdPtr f, MpdPtr g, double x);


MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Add_Si(MpdPtr f, MpdPtr g, int32_t x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Sub_Si(MpdPtr f, MpdPtr g, int32_t x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Si_Sub(MpdPtr f, MpdPtr g, int32_t x);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Mul_Si(MpdPtr f, MpdPtr g, int32_t x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Div_Si(MpdPtr f, MpdPtr g, int32_t x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Si_Div(MpdPtr f, MpdPtr g, int32_t x);


MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_LT(const MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_GE(const MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_GT(const MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_LE(const MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_EQ(const MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_NE(const MpdPtr x, const MpdPtr y);



/* General functions for real numbers  */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Fma(MpdPtr r, MpdPtr a, MpdPtr b, MpdPtr c);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Fmax(MpdPtr result, MpdPtr a, MpdPtr b);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Fmin(MpdPtr result, MpdPtr a, MpdPtr b);



/* Machine constants */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Zero(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_NegZero(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_One(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Inf(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_NegInf(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Nan(MpdPtr a);



/* Properties of numbers  */

MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_Signbit(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_Finite(MpdPtr a);



MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_IsInf(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_Isposinf(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_Isneginf(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_IsNan(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_IsInteger(MpdPtr a);





MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_FitsInt32(const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_FitsInt64(const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_FitsUInt32(const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_FitsUInt64(const MpdPtr x);




/* Integer Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Nearbyint(MpdPtr result, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Rint(MpdPtr result, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_Mpd_Lrint(const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_Mpd_Llrint(const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Ceil(MpdPtr result, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Floor(MpdPtr result, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Trunc(MpdPtr result, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Round(MpdPtr result, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT long int __cdecl Lib_Mpd_Lround(const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT long long int __cdecl Lib_Mpd_Llround(const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_ToInt32(const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT int64_t __cdecl Mpd_ToInt64(const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl Lib_Mpd_ToUInt32(const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT uint64_t __cdecl Mpd_ToUInt64(const MpdPtr x);




/* Floating point functions for real numbers */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Copysign(MpdPtr result, MpdPtr x, MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Frexp(MpdPtr res, const MpdPtr x, long long int* e);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Logb(MpdPtr result, MpdPtr x); /* TODO */
MPNUMC_DLL_IMPORTEXPORT int __cdecl Lib_FReal_Ilogb(const double* x);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Ldexp(MpdPtr res, const MpdPtr x, const long int e);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Scalbn(MpdPtr result, MpdPtr x, MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Scalbln(MpdPtr result, MpdPtr x, MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Fdim(MpdPtr res, const MpdPtr x, const MpdPtr y);


/* Fraction and Remainder Related Functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Modf(MpdPtr frac, const MpdPtr x, MpdPtr iptr);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Fmod(MpdPtr q, MpdPtr x, MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Remainder(MpdPtr q, MpdPtr x, MpdPtr y);
/* not included: Remquo */



/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Epsilon(MpdPtr res, int32_t prec);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Ulp(MpdPtr res, MpdPtr x, int32_t prec);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Max(MpdPtr res, int32_t prec);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Lowest(MpdPtr res, int32_t prec);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Min(MpdPtr res, int32_t prec);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Nextbelow(MpdPtr x, MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Nextabove(MpdPtr x, MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Next_Toward(MpdPtr result, MpdPtr a, MpdPtr b);



/* Mathematical Constants  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstDegree(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstPhi(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstLog2(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstLog10(MpdPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstPi(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstE(MpdPtr res);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstEulerGamma(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstApery(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstCatalan(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstGlaisher(MpdPtr res);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_ConstKhinchin(MpdPtr res);


/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Fabs(MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Sign(MpdPtr res, const MpdPtr x);




/* Roots and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Sqrt(MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Sqrt1pm1(MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Rsqrt(MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Cbrt(MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Root_Si(MpdPtr res, const MpdPtr x, const int32_t k);



/* Exponential and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Exp(MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Exp2(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Exp10(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Expm1(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Exp2m1(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Exp10m1(MpdPtr res, const MpdPtr x);



/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Log(MpdPtr x, const MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Log2(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Log10(MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Log1p(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Log2p1(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Log10p1(MpdPtr res, const MpdPtr x);



/* Power functions and roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Square(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Cube(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Hypot(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Pow(MpdPtr x, const MpdPtr y, const MpdPtr z);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Powm1(MpdPtr x, const MpdPtr y, const MpdPtr z);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Pow1p(MpdPtr x, const MpdPtr y, const MpdPtr z);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Pow1pm1(MpdPtr x, const MpdPtr y, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Pow_Si(MpdPtr res, const MpdPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Compound_Si(MpdPtr res, const MpdPtr x, const int32_t k);



/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Sin(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Cos(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Tan(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Csc(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Sec(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Cot(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_SinPi(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_CosPi(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_TanPi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_CscPi(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_SecPi(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_CotPi(MpdPtr res, const MpdPtr x);




/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Sinh(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Cosh(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Tanh(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Csch(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Sech(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Coth(MpdPtr res, const MpdPtr x);



/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Asin(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Acos(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Atan(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Atan2(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Acsc(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Asec(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Acot(MpdPtr res, const MpdPtr x);


/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Asinh(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Acosh(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Atanh(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Acsch(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Asech(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Acoth(MpdPtr res, const MpdPtr x);


/* Special functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Erf(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Erfc(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Tgamma(MpdPtr res, const MpdPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Lgamma(MpdPtr res, const MpdPtr x);




/** ********************** Complex Basic Functions, Lib_Mpdc_Set ******************************** **/


MPNUMC_DLL_IMPORTEXPORT MpdcPtr __cdecl Lib_Mpdc_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Clear(MpdcPtr x);


/* Input and output  */

MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set(MpdcPtr res, MpdcPtr x);


/* Operator overloading vs raw arithmetic and comparisons  */

MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Neg(MpdcPtr res, MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Add(MpdcPtr res, MpdcPtr x, MpdcPtr y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Sub(MpdcPtr res, MpdcPtr x, MpdcPtr y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Mul(MpdcPtr res, MpdcPtr x, MpdcPtr y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Div(MpdcPtr res, MpdcPtr x, MpdcPtr y);


MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Si(MpdcPtr res, int32_t x_re);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Ui(MpdcPtr res, uint32_t x_re);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Si64(MpdcPtr res, int64_t x_re);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Ui64(MpdcPtr res, uint64_t x_re);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_D(MpdcPtr res, double x_re);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Str(MpdcPtr res, const char * x_re);

MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Si_Si(MpdcPtr res, int32_t x_re, int32_t x_im);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Ui_Ui(MpdcPtr res, uint32_t x_re, uint32_t x_im);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Si64_Si64(MpdcPtr res, int64_t x_re, int64_t x_im);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Ui64_Ui64(MpdcPtr res, uint64_t x_re, uint64_t x_im);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_D_D(MpdcPtr res, double x_re, double x_im);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Str_Str(MpdcPtr res, const char * x_re, const char * x_im);

MPNUMC_DLL_IMPORTEXPORT  int32_t  __cdecl Lib_Mpdc_Cmp(MpdcPtr x, MpdcPtr y);


MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Add_Mpd(MpdcPtr res, MpdcPtr x, MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Sub_Mpd(MpdcPtr res, MpdcPtr x, MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Mpd_Sub(MpdcPtr res, MpdcPtr y, MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Mul_Mpd(MpdcPtr res, MpdcPtr x, MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Div_Mpd(MpdcPtr res, MpdcPtr x, MpdPtr y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Mpd_Div(MpdcPtr res, MpdcPtr y, MpdPtr x);


MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Add_D(MpdcPtr res, MpdcPtr x, double y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Sub_D(MpdcPtr res, MpdcPtr x, double y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_D_Sub(MpdcPtr res, MpdcPtr x, double y);

MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Mul_D(MpdcPtr res, MpdcPtr x, double y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Div_D(MpdcPtr res, MpdcPtr x, double y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_D_Div(MpdcPtr res, MpdcPtr y, double x);


MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Add_Si(MpdcPtr res, MpdcPtr x, int32_t y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Sub_Si(MpdcPtr res, MpdcPtr x, int32_t y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Si_Sub(MpdcPtr res, MpdcPtr x, int32_t y);

MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Mul_Si(MpdcPtr res, MpdcPtr x, int32_t y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Div_Si(MpdcPtr res, MpdcPtr x, int32_t y);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Si_Div(MpdcPtr res, MpdcPtr y, int32_t x);





/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Mathematical Constants  */

//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Onei(MpfcPtr res); /* TODO */



/* Complex components  */

MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set_Real(MpdcPtr res, MpdPtr x_re);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Set2(MpdcPtr res, MpdPtr x_re, MpdPtr x_im);

//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Abs(MpfrPtr res, const MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Arg(MpfrPtr res, const MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Real(MpdPtr res, MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpdc_Imag(MpdPtr res, MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Conj(MpdcPtr res, const MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Proj(MpdcPtr res, const MpdcPtr x);





/* Roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Sqrt(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Sqrt1pm1(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Rsqrt(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Cbrt(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Root_Si(MpdcPtr res, const MpdcPtr x, const int32_t k);



/* Exponential and related functions  */

//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Exp(MpdcPtr res, const MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Expi(MpdcPtr res, const MpfrPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Exp2(MpdcPtr res, const MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Exp10(MpdcPtr res, const MpdcPtr x);
//
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Expm1(MpdcPtr res, const MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Exp2m1(MpdcPtr res, const MpdcPtr x);
//MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Exp10m1(MpdcPtr res, const MpdcPtr x);




/* Logarithms and related functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Log(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Log2(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Log10(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Log1p(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Log2p1(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Log10p1(MpdcPtr res, const MpdcPtr x);



/* Power functions and roots  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Square(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Cube(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Pow(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Powm1(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Pow1p(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Pow1pm1(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Pow_Si(MpdcPtr res, const MpdcPtr x, const int32_t k);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Compound_Si(MpdcPtr res, const MpdcPtr x, const int32_t k);



/* Trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Sin(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Cos(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Tan(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Csc(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Sec(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Cot(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_SinPi(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_CosPi(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_TanPi(MpdcPtr res, const MpdcPtr x);




/* Hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Sinh(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Cosh(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Tanh(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Csch(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Sech(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Coth(MpdcPtr res, const MpdcPtr x);




/* Inverse trigonometric functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Asin(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acos(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Atan(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acsc(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Asec(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acot(MpdcPtr res, const MpdcPtr x);




/* Inverse hyperbolic functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Asinh(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acosh(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Atanh(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acsch(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Asech(MpdcPtr res, const MpdcPtr x);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acoth(MpdcPtr res, const MpdcPtr x);







/* Extra functions for Mpd  */


MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Lib_Mpd_IsSpecial(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_IsZero(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_Arith_Sign(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT int32_t __cdecl Lib_Mpd_IsNormal(MpdPtr result);

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Set_Pos_Nan(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpd_Set_Zerocoeff(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpd_Set_NegativeZerocoeff(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT  void  __cdecl Lib_Mpd_Set_One(MpdPtr a);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Machine_Epsilon_X(MpdPtr res, MpdPtr x, int32_t prec);

// Set result to the number that is equal in value to a, but has the exponent of b.
 MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Quantize(MpdPtr result, MpdPtr a, MpdPtr b);  /* EXPORT */

// Set result to the number that is equal in value to a, but has the exponent exp. Special numbers are copied without signaling.
 MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Rescale(MpdPtr result, MpdPtr a, int32_t exp);  /* EXPORT */

// Return 1 if a and b have the same exponent, 0 otherwise.
 MPNUMC_DLL_IMPORTEXPORT int32_t  __cdecl Lib_Mpd_Same_Quantum(MpdPtr a, MpdPtr b);  /* EXPORT */

// If a is finite after applying rounding and overflow/underflow checks, result is set to the simplest form of a
// with all trailing zeros removed.
 MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Reduce(MpdPtr result, MpdPtr a);

// Similar to Lib_FReal_Remainder, but with nearest integer
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Rem_Near(MpdPtr q, MpdPtr a, MpdPtr b);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Mpd_Frac(MpdPtr result, MpdPtr a);














//*********************** Flint **********************************


//////////////////////////////////////////////////////
//// Mpd_Arb functions
//////////////////////////////////////////////////////




/* Roots and quadratic, cubic, and quartic equations */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Sqrt(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Rsqrt(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Cbrt(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Sqrt1pm1(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Root_Si(MpdPtr res, const MpdPtr x, const int32_t n);



/* Exponential and related functions */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Exp(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Exp10(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Exp2(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Expm1(MpdPtr res, const MpdPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Exp10m1(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Exp2m1(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_ExpRel(MpdPtr res, const MpdPtr x);





/* Logarithms and related functions */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Logbase(MpdPtr res, const MpdPtr x, const MpdPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Log(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Log10(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Log2(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Log1p(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Log10p1(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Log2p1(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Log1mexp(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LambertW0(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LambertWm1(MpdPtr res, const MpdPtr x);





/* Power functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Square(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Cube(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypot(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Pow_ui(MpdPtr res, const MpdPtr x, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Pow(MpdPtr res, const MpdPtr x, const MpdPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Powm1(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Pow1p(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Pow1pm1(MpdPtr res, const MpdPtr x, const MpdPtr y);



/* Trigonometric and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Sin(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Cos(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Tan(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Cot(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Csc(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Sec(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Sinc(MpdPtr res, const MpdPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_SinPi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_CosPi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_TanPi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_CotPi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_SincPi(MpdPtr res, const MpdPtr x);


/* Hyperbolic functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Sinh(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Cosh(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Tanh(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Coth(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Csch(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Sech(MpdPtr res, const MpdPtr x);




/* Inverse trigonometric functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Asin(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Acos(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Atan2(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Atan(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Acot(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Acsc(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Asec(MpdPtr res, const MpdPtr x);




/* Inverse hyperbolic functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Asinh(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Acosh(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Atanh(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Acoth(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Acsch(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Asech(MpdPtr res, const MpdPtr x);





/* Legendre elliptic integrals (elliptic parameter m) */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_MEllipticK(MpdcPtr res, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_MEllipticE(MpdcPtr res, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_MEllipticPi(MpdPtr res, const MpdPtr n, const MpdPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_MEllipticF(MpdPtr res, const MpdPtr phi, const MpdPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_MEllipticEInc(MpdPtr res, const MpdPtr phi, const MpdPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_MEllipticPiInc(MpdPtr res, const MpdPtr n, const MpdPtr phi, const MpdPtr m);



/* Legendre elliptic integrals (elliptic modulus k), and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_EllipticK(MpdcPtr res, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_EllipticE(MpdcPtr res, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_EllipticPi(MpdPtr res, const MpdPtr n, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_EllipticF(MpdPtr res, const MpdPtr phi, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_EllipticEInc(MpdPtr res, const MpdPtr phi, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_EllipticPiInc(MpdPtr res, const MpdPtr n, const MpdPtr phi, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Agm(MpdPtr res, const MpdPtr x, const MpdPtr y);



/* Carlson symmetric elliptic integrals */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Elliptic_RC(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Elliptic_RF(MpdPtr res, const MpdPtr x, const MpdPtr y, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Elliptic_RG(MpdPtr res, const MpdPtr x, const MpdPtr y, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Elliptic_RD(MpdPtr res, const MpdPtr x, const MpdPtr y, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Elliptic_RJ(MpdPtr res, const MpdPtr x, const MpdPtr y, const MpdPtr z, const MpdPtr w);




/* Jacobi theta functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Theta1Q(MpdPtr res, const MpdPtr z, const MpdPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Theta2Q(MpdPtr res, const MpdPtr z, const MpdPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Theta3Q(MpdPtr res, const MpdPtr z, const MpdPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Theta4Q(MpdPtr res, const MpdPtr z, const MpdPtr q);



/* Jacobi elliptic functions */



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiSN(MpdPtr res, const MpdPtr u, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiCN(MpdPtr res, const MpdPtr u, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiDN(MpdPtr res, const MpdPtr u, const MpdPtr k);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiNS(MpdPtr res, const MpdPtr u, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiNC(MpdPtr res, const MpdPtr u, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiND(MpdPtr res, const MpdPtr u, const MpdPtr k);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiSC(MpdPtr res, const MpdPtr u, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiSD(MpdPtr res, const MpdPtr u, const MpdPtr k);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiDC(MpdPtr res, const MpdPtr u, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiDS(MpdPtr res, const MpdPtr u, const MpdPtr k);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiCS(MpdPtr res, const MpdPtr u, const MpdPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiCD(MpdPtr res, const MpdPtr u, const MpdPtr k);







/* Weierstrass elliptic functions, in terms of half-period omega1 and elliptic period ratio tau */





/* Weierstrass elliptic functions, in terms of (real) lattice invariants g2, g3 */




/* Lerch’s transcendent: overview */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LerchPhi(MpdPtr res, const MpdPtr z, const MpdPtr s, const MpdPtr a);




/* Polygamma functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Polygamma(MpdPtr res, const MpdPtr s, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Digamma(MpdPtr res, const MpdPtr x);




/* Polylogarithms and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Polylog(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Dilog(MpdPtr res, const MpdPtr x);





/* Hurwitz zeta function and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_HurwitzZeta(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Bernoulli_ui(MpdPtr res, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BernoulliPoly_ui(MpdPtr res, const MpdPtr x, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Euler_ui(MpdPtr res, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BarnesG(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LogBarnesG(MpdcPtr res, const MpdcPtr x);




/* Riemann zeta function, and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Zeta(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BacklundS(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_GramPoint_ui(MpdPtr res, const int32_t n);




/* Additional numbertheoretic functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Bell_ui(MpdPtr res, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Partitions_ui(MpdPtr res, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Primorial_ui(MpdPtr res, const int32_t n);





/* Confluent Hypergeometric Limit Function 0F1, overview */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypgeom0F1(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypgeom0F1r(MpdPtr res, const MpdPtr x, const MpdPtr y);




/* Bessel functions and modified Bessel functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BesselJ(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BesselY(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BesselI(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BesselK(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BesselIScaled(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BesselKScaled(MpdPtr res, const MpdPtr x, const MpdPtr y);



/* Spherical Bessel functions  */




/* Airy functions  */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_AiryAi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_AiryAiPrime(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_AiryBi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_AiryBiPrime(MpdPtr res, const MpdPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_AiryAiZero(MpdPtr res, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_AiryAiPrimeZero(MpdPtr res, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_AiryBiZero(MpdPtr res, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_AiryBiPrimeZero(MpdPtr res, const int32_t n);



/* Kelvin functions  */





/* Kummer’s Confluent Hypergeometric Function 1F1 */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypgeom1F1(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypgeom1F1r(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_HypgeomU(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);




/* Gamma function and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Gamma(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Rgamma(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Lgamma(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_RisingFactorial(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Beta(MpdPtr res, const MpdPtr x, const MpdPtr y);



/* Incomplete gamma functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_GammaUpper(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_GammaQ(MpdPtr res, const MpdPtr x, const MpdPtr y);

// Missing: Tricomi

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_GammaLower(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_GammaP(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_GammaPPrime(MpdPtr res, const MpdPtr x, const MpdPtr y);



/* Error function and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Erf(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Erfc(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_ErfInv(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_ErfcInv(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Erfi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_FresnelC(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_FresnelS(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Ndens(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Ndis(MpdPtr res, const MpdPtr x);





/* Exponential integrals and related functions */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_ExpIntegralE(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_ExpIntegralEi(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_SinIntegral(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_CosIntegral(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_SinhIntegral(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_CoshIntegral(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LogIntegral(MpdPtr res, const MpdPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LogIntegralOffset(MpdPtr res, const MpdPtr x);



/* 1F1: Orthogonal polynomials */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_HermiteH(MpdPtr res, const MpdPtr x, const MpdPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LaguerreL(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);




/* 1F1: Coulomb functions */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_CoulombF(MpdPtr res, const MpdPtr l, const MpdPtr eta, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_CoulombG(MpdPtr res, const MpdPtr l, const MpdPtr eta, const MpdPtr z);




/* 1F1: Whittaker functions */




/* 1F1: Parabolic cylinder functions */





/* Gauss Hypergeometric Function 2F1, overview */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypgeom2F1(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr c, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypgeom2F1r(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr c, const MpdPtr z);





/* 2F1: Orthogonal polynomials */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_ChebyshevT(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_ChebyshevU(MpdPtr res, const MpdPtr x, const MpdPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_GegenbauerC(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_JacobiP(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr c, const MpdPtr z);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LegendreP(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LegendrePv(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LegendreQ(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_LegendreQv(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);




/* 2F1: Incomplete Beta Function */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_BetaLower(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Ibeta(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Ibetac(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_IbetaPrime(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr z);




/* Hypergeometric Function 1F2, overview */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypgeom1F2(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr c, const MpdPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpd_Arb_Hypgeom1F2r(MpdPtr res, const MpdPtr a, const MpdPtr b, const MpdPtr c, const MpdPtr z);








//////////////////////////////////////////////////////
//// Mpdc_Acb functions
//////////////////////////////////////////////////////



/* Roots and quadratic, cubic, and quartic equations */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Sqrt(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Rsqrt(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Cbrt(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Sqrt1pm1(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_UnitRoot_ui(MpdcPtr res, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Root_Si(MpdcPtr res, const MpdcPtr x, const int32_t n);




/* Exponential and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Exp(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Expj(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Expjpi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Exp10(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Exp2(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Expm1(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Exp10m1(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Exp2m1(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ExpRel(MpdcPtr res, const MpdcPtr x);





/* Logarithms and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Logbase(MpdcPtr res, const MpdcPtr x, const MpdcPtr b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Log(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Log10(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Log2(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Log1p(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Log10p1(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Log2p1(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LambertW_ui(MpdcPtr res, const MpdcPtr x, const int32_t n);




/* Power functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Square(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Cube(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypot(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Pow_si(MpdcPtr res, const MpdcPtr x, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Pow(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Powm1(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Pow1p(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Pow1pm1(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);





/* Trigonometric and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Sin(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Cos(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Tan(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Csc(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Sec(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Cot(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Sinc(MpdcPtr res, const MpdcPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_SinPi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CosPi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_TanPi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CotPi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_SincPi(MpdcPtr res, const MpdcPtr x);






/* Hyperbolic functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Sinh(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Cosh(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Tanh(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Csch(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Sech(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Coth(MpdcPtr res, const MpdcPtr x);





/* Inverse trigonometric functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Asin(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Acos(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Atan(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Acsc(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Asec(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Acot(MpdcPtr res, const MpdcPtr x);





/* Inverse hyperbolic functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Asinh(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Acosh(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Atanh(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Acsch(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Asech(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Acoth(MpdcPtr res, const MpdcPtr x);








/* Legendre elliptic integrals (elliptic parameter m) */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_MEllipticK(MpdcPtr res, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_MEllipticE(MpdcPtr res, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_MEllipticPi(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_MEllipticF(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_MEllipticEInc(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_MEllipticPiInc(MpdcPtr res, const MpdcPtr n, const MpdcPtr phi, const MpdcPtr m);




/* Legendre elliptic integrals (elliptic modulus k), and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticK(MpdcPtr res, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticE(MpdcPtr res, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticPi(MpdcPtr res, const MpdcPtr phi, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticF(MpdcPtr res, const MpdcPtr phi, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticEInc(MpdcPtr res, const MpdcPtr phi, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticPiInc(MpdcPtr res, const MpdcPtr n, const MpdcPtr phi, const MpdcPtr k);




MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Agm(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);




/* Carlson symmetric elliptic integrals */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Elliptic_RC(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Elliptic_RF(MpdcPtr res, const MpdcPtr x, const MpdcPtr y, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Elliptic_RG(MpdcPtr res, const MpdcPtr x, const MpdcPtr y, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Elliptic_RD(MpdcPtr res, const MpdcPtr x, const MpdcPtr y, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Elliptic_RJ(MpdcPtr res, const MpdcPtr x, const MpdcPtr y, const MpdcPtr z, const MpdcPtr w);





/* Jacobi theta functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Theta1Q(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Theta2Q(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Theta3Q(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Theta4Q(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Theta1Tau(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Theta2Tau(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Theta3Tau(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Theta4Tau(MpdcPtr res, const MpdcPtr phi, const MpdcPtr m);




/* Jacobi elliptic functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_QfromK(MpdcPtr res, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_TfromUQ(MpdcPtr res, const MpdcPtr u, const MpdcPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_SnTQ(MpdcPtr res, const MpdcPtr t, const MpdcPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CnTQ(MpdcPtr res, const MpdcPtr t, const MpdcPtr q);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_DnTQ(MpdcPtr res, const MpdcPtr t, const MpdcPtr q);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiSN(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiCN(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiDN(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiNS(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiNC(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiND(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiSC(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiSD(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiDC(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiDS(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiCS(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiCD(MpdcPtr res, const MpdcPtr u, const MpdcPtr k);






/* Weierstrass elliptic functions, in terms of half-period omega1 and elliptic period ratio tau */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_WeierstrassP(MpdcPtr res, const MpdcPtr z, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_WeierstrassPInv(MpdcPtr res, const MpdcPtr z, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_WeierstrassPZeta(MpdcPtr res, const MpdcPtr z, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_WeierstrassPSigma(MpdcPtr res, const MpdcPtr z, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_WeierstrassPPrime(MpdcPtr res, const MpdcPtr z, const MpdcPtr tau);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticInvariantG2(MpdcPtr res, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticInvariantG3(MpdcPtr res, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticRootE1(MpdcPtr res, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticRootE2(MpdcPtr res, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EllipticRootE3(MpdcPtr res, const MpdcPtr tau);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_DedekindEta(MpdcPtr res, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_KleinJ(MpdcPtr res, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ModularLambda(MpdcPtr res, const MpdcPtr tau);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ModularDelta(MpdcPtr res, const MpdcPtr tau);





/* Weierstrass elliptic functions, in terms of (real) lattice invariants g2, g3 */





/* Lerch’s transcendent: overview */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LerchPhi(MpdcPtr res, const MpdcPtr z, const MpdcPtr s, const MpdcPtr a);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LerchZeta(MpdcPtr res, const MpdcPtr lambda1, const MpdcPtr alpha, const MpdcPtr s);




/* Polygamma functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Polygamma(MpdcPtr res, const MpdcPtr s, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Trigamma(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Digamma(MpdcPtr res, const MpdcPtr x);




/* Polylogarithms and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Polylog(MpdcPtr res, const MpdcPtr s, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Trilog(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Dilog(MpdcPtr res, const MpdcPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ClausenSin(MpdcPtr res, const MpdcPtr s, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ClausenCos(MpdcPtr res, const MpdcPtr s, const MpdcPtr z);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Clausen2(MpdcPtr res, const MpdcPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BoseEinstein(MpdcPtr res, const MpdcPtr s, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_FermiDirac(MpdcPtr res, const MpdcPtr s, const MpdcPtr z);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LegendreChi(MpdcPtr res, const MpdcPtr s, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_InverseTanIntegral(MpdcPtr res, const MpdcPtr s, const MpdcPtr z);





/* Hurwitz zeta function and related functions */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_HurwitzZeta(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Stieltjes_ui(MpdcPtr res, const MpdcPtr x, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BernoulliPoly_ui(MpdcPtr res, const MpdcPtr x, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Harmonic(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Harmonic2(MpdcPtr res, const MpdcPtr z, const MpdcPtr r);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_EulerPoly_ui(MpdcPtr res, const MpdcPtr x, const int32_t n);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hyperfactorial(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Superfactorial(MpdcPtr res, const MpdcPtr x);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BarnesG(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LogBarnesG(MpdcPtr res, const MpdcPtr x);




/* Riemann zeta function, and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Zeta(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Zetam1(MpdcPtr res, const MpdcPtr x);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_DirichletXi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_DirichletEta(MpdcPtr res, const MpdcPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_DirichletEtam1(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_DirichletBeta(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_DirichletLambda(MpdcPtr res, const MpdcPtr x);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_HardyZ(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_HardyTheta(MpdcPtr res, const MpdcPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ZetaZero_ui(MpdcPtr res, const int32_t n);



/* Additional numbertheoretic functions */





/* Confluent Hypergeometric Limit Function 0F1, overview */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypgeom0F1(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypgeom0F1r(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);




/* Bessel functions and modified Bessel functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BesselJ(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BesselY(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BesselI(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BesselK(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BesselIScaled(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BesselKScaled(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);





/* Spherical Bessel functions  */



/* Airy functions  */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_AiryAi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_AiryAiPrime(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_AiryBi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_AiryBiPrime(MpdcPtr res, const MpdcPtr x);




/* Kelvin functions  */




/* Kummer’s Confluent Hypergeometric Function 1F1 */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_HypgeomU(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypgeom1F1(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypgeom1F1r(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);






/* Gamma function and related functions */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Gamma(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Rgamma(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Lgamma(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_RisingFactorial(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Beta(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);




/* Incomplete gamma functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_GammaUpper(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_GammaLower(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_GammaPPrime(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_GammaP(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_GammaQ(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);





/* Error function and related functions */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Erf(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Erfc(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Erfi(MpdcPtr res, const MpdcPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_FresnelC(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_FresnelS(MpdcPtr res, const MpdcPtr x);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Ndens(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Ndis(MpdcPtr res, const MpdcPtr x);




/* Exponential integrals and related functions */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ExpIntegralE(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ExpIntegralEi(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_SinIntegral(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CosIntegral(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_SinhIntegral(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CoshIntegral(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LogIntegral(MpdcPtr res, const MpdcPtr x);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LogIntegralOffset(MpdcPtr res, const MpdcPtr x);





/* 1F1: Orthogonal polynomials */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_HermiteH(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LaguerreL(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);






/* 1F1: Coulomb functions */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CoulombF(MpdcPtr res, const MpdcPtr l, const MpdcPtr eta, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CoulombG(MpdcPtr res, const MpdcPtr l, const MpdcPtr eta, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CoulombHpos(MpdcPtr res, const MpdcPtr l, const MpdcPtr eta, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_CoulombHneg(MpdcPtr res, const MpdcPtr l, const MpdcPtr eta, const MpdcPtr z);






/* 1F1: Whittaker functions */




/* 1F1: Parabolic cylinder functions */





/* Gauss Hypergeometric Function 2F1, overview */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypgeom2F1(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr c, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypgeom2F1r(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr c, const MpdcPtr z);




/* 2F1: Orthogonal polynomials */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ChebyshevT(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_ChebyshevU(MpdcPtr res, const MpdcPtr x, const MpdcPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_GegenbauerC(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_JacobiP(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr c, const MpdcPtr z);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LegendreP(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LegendrePv(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LegendreQ(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_LegendreQv(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_SphericalY(MpdcPtr res, const MpdcPtr n, const MpdcPtr m, const MpdcPtr theta, const MpdcPtr phi);





/* 2F1: Incomplete Beta Function */


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_BetaLower(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Ibeta(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Ibetac(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_IbetaPrime(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr z);





/* Hypergeometric Function 1F2, overview */

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypgeom1F2(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr c, const MpdcPtr z);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Mpdc_Acb_Hypgeom1F2r(MpdcPtr res, const MpdcPtr a, const MpdcPtr b, const MpdcPtr c, const MpdcPtr z);













#endif // MPNUMC_MPD_H_INCLUDED








