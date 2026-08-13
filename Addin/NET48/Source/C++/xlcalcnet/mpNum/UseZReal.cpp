
#include "mpNumC_Main.h"
#include "BoostZReal.h"

#include "stdint.h"
#include <string.h>
#include <complex>
#include <limits>
#include "mpdecimal.h"








/** ********************** Real Basic Functions, double precision ******************************** **/


ZRealPtr Lib_ZReal_Init_Func()
{
    return LibZReal_Init_Func();
}




void Lib_ZReal_Clear(ZRealPtr x)
{
    LibZReal_Clear(x);
}



/* Input and output  */


void Lib_ZReal_Set(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Set(res, x);
}

//void Lib_ZReal_Set_Fmpq(ZRealPtr res, const FmpqPtr x)
//{
//    mpd_t* b;
//    b = mpd_new(mpd_globalctx());
//    decr_set_fmpq(b, (fmpq*)x);
//	char * str = mpd_to_sci(b, 1);
//	LibZReal_Set_Str(res, str);
//    mpd_del(b);
//	free(str);
//}
//
//void Lib_ZReal_Set_Arb(ZRealPtr res, const ArbPtr x)
//{
//	char * str = arb_get_str((arb_ptr)x, 51, ARB_STR_NO_RADIUS);
//	LibZReal_Set_Str(res, str);
//	free(str);
//}
//
//void Lib_ZReal_Set_Arf(ZRealPtr res, const ArfPtr x)
//{
//	arb_t temp; arb_init(temp);
//	arf_set(arb_midref(temp), (arf_ptr)x);
//	mag_zero(arb_radref(temp));
//	char * str = arb_get_str(temp, 51, ARB_STR_NO_RADIUS);
//	LibZReal_Set_Str(res, str);
//	free(str);
//	arb_clear(temp);
//}

//void Lib_ZReal_Set_Mpfi(ZRealPtr res, const MpfiPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	mpfi_mid (temp, (mpfi_ptr)x);
//	char * str = mpfr_get_str_extern("%.50RE", 51, temp);
//	LibZReal_Set_Str(res, str);
//	free(str);
//	mpfr_clear(temp);
//}
//
//void Lib_ZReal_Set_Mpfr(ZRealPtr res, const MpfrPtr x)
//{
//	char * str = mpfr_get_str_extern("%.50RE", 51, (mpfr_ptr)x);
//	LibZReal_Set_Str(res, str);
//	free(str);
//}

void Lib_ZReal_Set_Mpd(ZRealPtr res, const MpdPtr x)
{
	char * str = mpd_to_sci((mpd_t *)x, 1);
	LibZReal_Set_Str(res, str);
	free(str);
}

void Lib_ZReal_Set_ZReal(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Set(res, x);
}

void Lib_ZReal_Set_QReal(ZRealPtr res, QRealPtr x)
{
//    mpfr_t temp; mpfr_init2(temp, 128);
//    mpfr_set_float128 (temp, *(__float128*)x, MPFR_RNDN);
//	char * str = mpfr_get_str_extern("%.50RE", 46, temp);
//	LibZReal_Set_Str(res, str);
//	free(str);
//	mpfr_clear(temp);
}


void Lib_ZReal_Set_LD(ZRealPtr res, const long double* x)
{
    LibZReal_Set_LD(res,x);
}

void Lib_ZReal_Set_D(ZRealPtr res, const double x)
{
    LibZReal_Set_D(res,x);
}

void Lib_ZReal_Set_S(ZRealPtr res, const float* x)
{
    LibZReal_Set_S(res,x);
}

void Lib_ZReal_Set_Si(ZRealPtr res, const int32_t x)
{
	LibZReal_Set_Si(res, x);
}

void Lib_ZReal_Set_Ui(ZRealPtr res, const uint32_t x)
{
	LibZReal_Set_Ui(res, x);
}

void Lib_ZReal_Set_Si64(ZRealPtr res, const int64_t x)
{
	LibZReal_Set_Si64(res, x);
}

void Lib_ZReal_Set_Ui64(ZRealPtr res, const uint64_t x)
{
	LibZReal_Set_Ui64(res, x);
}

void Lib_ZReal_Set_Str(ZRealPtr res, const char * str)
{
    LibZReal_Set_Str(res, str);
}

void Lib_ZReal_Get_Str(char* cstr, const ZRealPtr x)
{
    LibZReal_Get_Str(cstr, x);
}



/* Operator overloading vs raw arithmetic and comparisons  */


void Lib_ZReal_Neg(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Neg(res, x);
}

void Lib_ZReal_Add(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Add(res, x, y);
}

void Lib_ZReal_Sub(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Sub(res, x, y);
}

void Lib_ZReal_Mul(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Mul(res, x, y);
}

void Lib_ZReal_Div(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Div(res, x, y);
}

void Lib_ZReal_Add_D(ZRealPtr res, const ZRealPtr x, const double y)
{
    LibZReal_Add_D(res, x, y);
}

void Lib_ZReal_Sub_D(ZRealPtr res, const ZRealPtr x, const double y)
{
    LibZReal_Sub_D(res, x, y);
}

void Lib_ZReal_D_Sub(ZRealPtr res, const ZRealPtr x, const double y)
{
    LibZReal_D_Sub(res, x, y);
}

void Lib_ZReal_Mul_D(ZRealPtr res, const ZRealPtr x, const double y)
{
    LibZReal_Mul_D(res, x, y);
}

void Lib_ZReal_Div_D(ZRealPtr res, const ZRealPtr x, const double y)
{
    LibZReal_Div_D(res, x, y);
}

void Lib_ZReal_D_Div(ZRealPtr res, const ZRealPtr x, const double y)
{
    LibZReal_D_Div(res, x, y);
}

void Lib_ZReal_Add_Si(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
    LibZReal_Add_Si(res, x, y);
}

void Lib_ZReal_Sub_Si(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
    LibZReal_Sub_Si(res, x, y);
}

void Lib_ZReal_Si_Sub(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
    LibZReal_Si_Sub(res, x, y);
}

void Lib_ZReal_Mul_Si(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
    LibZReal_Mul_Si(res, x, y);
}

void Lib_ZReal_Div_Si(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
    LibZReal_Div_Si(res, x, y);
}

void Lib_ZReal_Si_Div(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
    LibZReal_Si_Div(res, x, y);
}


int32_t Lib_ZReal_LT(const ZRealPtr x, const ZRealPtr y)
{
    return LibZReal_LT(x, y);
}

int32_t Lib_ZReal_GE(const ZRealPtr x, const ZRealPtr y)
{
    return LibZReal_GE(x, y);
}

int32_t Lib_ZReal_GT(const ZRealPtr x, const ZRealPtr y)
{
    return LibZReal_GT(x, y);
}

int32_t Lib_ZReal_LE(const ZRealPtr x, const ZRealPtr y)
{
    return LibZReal_LE(x, y);
}

int32_t Lib_ZReal_EQ(const ZRealPtr x, const ZRealPtr y)
{
    return LibZReal_EQ(x, y);
}

int32_t Lib_ZReal_NE(const ZRealPtr x, const ZRealPtr y)
{
    return LibZReal_NE(x, y);
}










/* General functions for real numbers  */

void Lib_ZReal_Fma(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z)
{
    LibZReal_Fma(res, x, y, z);
}

void Lib_ZReal_Fmax(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Fmax(res, x, y);
}

void Lib_ZReal_Fmin(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Fmin(res, x, y);
}




/* Machine constants */

void Lib_ZReal_Zero(ZRealPtr res)
{
    LibZReal_Zero(res);
}

void Lib_ZReal_NegZero(ZRealPtr res)
{
    LibZReal_NegZero(res);
}

void Lib_ZReal_One(ZRealPtr res)
{
    LibZReal_One(res);
}

void Lib_ZReal_Inf(ZRealPtr res)
{
    LibZReal_Inf(res);
}

void Lib_ZReal_NegInf(ZRealPtr res)
{
    LibZReal_NegInf(res);
}

void Lib_ZReal_Nan(ZRealPtr res)
{
    LibZReal_Nan(res);
}



/* Properties of numbers  */

int Lib_ZReal_Signbit(const ZRealPtr x)
{
    return LibZReal_Signbit(x);
}

int Lib_ZReal_Finite(const ZRealPtr x)
{
    return LibZReal_Finite(x);
}

int Lib_ZReal_Isinf(const ZRealPtr x)
{
    return LibZReal_Isinf(x);
}

int Lib_ZReal_Isposinf(const ZRealPtr x)
{
    return LibZReal_Isinf(x);
}

int Lib_ZReal_Isneginf(const ZRealPtr x)
{
    return LibZReal_Isneginf(x);
}

int Lib_ZReal_Isnan(const ZRealPtr x)
{
    return LibZReal_Isnan(x);
}





int Lib_ZReal_Iszero(const ZRealPtr x)
{
	return LibZReal_Iszero(x);
}

int Lib_ZReal_Isposzero(const ZRealPtr x)
{
	return  LibZReal_Isposzero(x);
}

int Lib_ZReal_Isnegzero(const ZRealPtr x)
{
	return LibZReal_Isnegzero(x);
}

int Lib_ZReal_Isone(const ZRealPtr x)
{
	return LibZReal_Isone(x);
}

int Lib_ZReal_Isinteger(const ZRealPtr x)
{
	return LibZReal_Isinteger(x);
}

int Lib_ZReal_Isnumber(const ZRealPtr x)
{
	return LibZReal_Isnumber(x);
}

int Lib_ZReal_Isregular(const ZRealPtr x)
{
	return LibZReal_Isregular(x);
}

int Lib_ZReal_Isnormal(const ZRealPtr x)
{
	return LibZReal_Isnormal(x);
}

int Lib_ZReal_Issubnormal(const ZRealPtr x)
{
	return LibZReal_Issubnormal(x);
}

int Lib_ZReal_Isunordered(const ZRealPtr x, const ZRealPtr y)
{
	return LibZReal_Isunordered(x, y);
}







int Lib_ZReal_FitsInt32(const ZRealPtr x)
{
    return LibZReal_FitsInt32(x);
}

int Lib_ZReal_FitsInt64(const ZRealPtr x)
{
    return LibZReal_FitsInt64(x);
}

int Lib_ZReal_FitsUInt32(const ZRealPtr x)
{
    return LibZReal_FitsUInt32(x);
}

int Lib_ZReal_FitsUInt64(const ZRealPtr x)
{
    return LibZReal_FitsUInt64(x);
}






/* Integer Related Functions  */

void Lib_ZReal_Nearbyint(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Nearbyint(res, x);
}

void Lib_ZReal_Rint(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Rint(res, x);
}

long int Lib_ZReal_Lrint(const ZRealPtr x)
{
    return LibZReal_Lrint(x);
}

long long int Lib_ZReal_Llrint(const ZRealPtr x)
{
    return LibZReal_Llrint(x);
}

void Lib_ZReal_Ceil(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Ceil(res, x);
}

void Lib_ZReal_Floor(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Floor(res, x);
}

void Lib_ZReal_Trunc(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Trunc(res, x);
}

void Lib_ZReal_Round(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Round(res, x);
}

long int Lib_ZReal_Lround(const ZRealPtr x)
{
    return LibZReal_Lround(x);
}

long long int Lib_ZReal_Llround(const ZRealPtr x)
{
    return LibZReal_Llround(x);
}

int32_t Lib_ZReal_ToInt32(const ZRealPtr x)
{
    return LibZReal_ToInt32(x);
}

int64_t Lib_ZReal_ToInt64(const ZRealPtr x)
{
    return LibZReal_ToInt64(x);
}

uint32_t Lib_ZReal_ToUInt32(const ZRealPtr x)
{
    return LibZReal_ToInt32(x);
}

uint64_t Lib_ZReal_ToUInt64(const ZRealPtr x)
{
    return LibZReal_ToInt64(x);
}






/* Floating point functions for real numbers */

void Lib_ZReal_Copysign(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Copysign(res, x, y);
}

void Lib_ZReal_Frexp(ZRealPtr res, const ZRealPtr x, int* e)
{
    LibZReal_Frexp(res, x, e);
}


void Lib_ZReal_Logb(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Logb(res, x);
}


int Lib_ZReal_Ilogb(const ZRealPtr x)
{
    return LibZReal_Ilogb(x);
}




void Lib_ZReal_Ldexp(ZRealPtr res, const ZRealPtr x, const long int e)
{
    LibZReal_Ldexp(res, x, e);
}

void Lib_ZReal_Scalbn(ZRealPtr res, const ZRealPtr x, const int e)
{
    LibZReal_Scalbn(res, x, e);
}


void Lib_ZReal_Scalbln(ZRealPtr res, const ZRealPtr x, const long int e)
{
    LibZReal_Scalbln(res, x, e);
}


void Lib_ZReal_Fdim(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Fdim(res, x, y);
}






/* Fraction and Remainder Related Functions  */

void Lib_ZReal_Modf(ZRealPtr frac, ZRealPtr x, const ZRealPtr iptr)
{
    LibZReal_Modf(frac, x, iptr);
}

void Lib_ZReal_Fmod(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Fmod(res, x, y);
}

void Lib_ZReal_Remainder(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Remainder(res, x, y);
}

void Lib_ZReal_Remquo(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, int* e)
{
    LibZReal_Remquo(res, x, y, e);
}





/* Functions related to mantissa width and exponent range */

void Lib_ZReal_Epsilon(ZRealPtr res)
{
    LibZReal_Epsilon(res);
}

void Lib_ZReal_Ulp(ZRealPtr res, const ZRealPtr x)
{
	LibZReal_Ulp(res, x);
}


void Lib_ZReal_Max(ZRealPtr res)
{
    LibZReal_Max(res);
}

void Lib_ZReal_Lowest(ZRealPtr res)
{
    LibZReal_Lowest(res);
}

void Lib_ZReal_Min(ZRealPtr res)
{
    LibZReal_Min(res);
}

void Lib_ZReal_Nextabove(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Nextabove(res, x);
}

void Lib_ZReal_Nextbelow(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Nextbelow(res, x);
}

void Lib_ZReal_Nexttoward(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Nexttowards(res, x, y);
}








/* Mathematical Constants  */

void Lib_ZReal_ConstDegree(ZRealPtr res)
{
	LibZReal_Set_Str(res, "1.74532925199432957692369076848861271344287188854172545609719144017100911E-02");
}

void Lib_ZReal_ConstPhi(ZRealPtr res)
{
	LibZReal_Set_Str(res, "1.61803398874989484820458683436563811772030917980576286213544862270526046E+00");
}

void Lib_ZReal_ConstLog2(ZRealPtr res)
{
	LibZReal_Set_Str(res, "6.93147180559945309417232121458176568075500134360255254120680009493393622E-01");
}

void Lib_ZReal_ConstLog10(ZRealPtr res)
{
	LibZReal_Set_Str(res, "2.30258509299404568401799145468436420760110148862877297603332790096757261E+00");
}

void Lib_ZReal_ConstPi(ZRealPtr res)
{
	LibZReal_Set_Str(res, "3.14159265358979323846264338327950288419716939937510582097494459230781641E+00");
}

void Lib_ZReal_ConstE(ZRealPtr res)
{
	LibZReal_Set_Str(res, "2.71828182845904523536028747135266249775724709369995957496696762772407663E+00");
}

void Lib_ZReal_ConstEulerGamma(ZRealPtr res)
{
	LibZReal_Set_Str(res, "5.77215664901532860606512090082402431042159335939923598805767234884867727E-01");
}

void Lib_ZReal_ConstApery(ZRealPtr res)
{
	LibZReal_Set_Str(res, "1.20205690315959428539973816151144999076498629234049888179227155534183820E+00");
}

void Lib_ZReal_ConstCatalan(ZRealPtr res)
{
	LibZReal_Set_Str(res, "9.15965594177219015054603514932384110774149374281672134266498119621763020E-01");
}

void Lib_ZReal_ConstGlaisher(ZRealPtr res)
{
	LibZReal_Set_Str(res, "1.28242712910062263687534256886979172776768892732500119206374002174040631E+00");
}

void Lib_ZReal_ConstKhinchin(ZRealPtr res)
{
	LibZReal_Set_Str(res, "2.68545200106530644530971483548179569382038229399446295305115234555721886E+00");
}




/* Complex components  */

void Lib_ZReal_Fabs(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Fabs(res, x);
}

void Lib_ZReal_Sign(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Sign(res, x);
}





/* Roots and related functions  */

void Lib_ZReal_Sqrt(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Sqrt(res, x);
}

void Lib_ZReal_Sqrt1pm1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Sqrt1pm1(res, x);
}


void Lib_ZReal_Rsqrt(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Rsqrt(res, x);
}

void Lib_ZReal_Cbrt(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Cbrt(res, x);
}

void Lib_ZReal_Root_Si(ZRealPtr res, const ZRealPtr x, const int32_t k)
{
    LibZReal_Root_Si(res, x, k);
}




/* Exponential and related functions  */

void Lib_ZReal_Exp(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Exp(res, x);
}

void Lib_ZReal_Exp2(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Exp2(res, x);
}

void Lib_ZReal_Exp10(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Exp10(res, x);
}

void Lib_ZReal_Expm1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Expm1(res, x);
}

void Lib_ZReal_Exp2m1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Exp2m1(res, x);
}

void Lib_ZReal_Exp10m1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Exp10m1(res, x);
}



/* Logarithms and related functions  */


void Lib_ZReal_Log(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Log(res, x);
}

void Lib_ZReal_Log2(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Log2(res, x);
}

void Lib_ZReal_Log10(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Log10(res, x);
}

void Lib_ZReal_Log1p(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Log1p(res, x);
}

void Lib_ZReal_Log2p1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Log2p1(res, x);
}

void Lib_ZReal_Log10p1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Log10p1(res, x);
}



/* Power functions and roots  */

void Lib_ZReal_Square(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Square(res, x);
}

void Lib_ZReal_Cube(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Cube(res, x);
}


void Lib_ZReal_Hypot(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Hypot(res, x, y);
}

void Lib_ZReal_Pow(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Pow(res, x, y);
}

void Lib_ZReal_Powm1(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Powm1(res, x, y);
}


void Lib_ZReal_Pow1p(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Pow1p(res, x, y);
}

void Lib_ZReal_Pow1pm1(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Pow1pm1(res, x, y);
}


void Lib_ZReal_Pow_Si(ZRealPtr res, const ZRealPtr x, const int32_t k)
{
    LibZReal_Pow_Si(res, x, k);
}


void Lib_ZReal_Compound_Si(ZRealPtr res, const ZRealPtr x, const int32_t k)
{
    LibZReal_Compound_Si(res, x, k);
}



/* Trigonometric functions  */

void Lib_ZReal_Sin(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Sin(res, x);
}

void Lib_ZReal_Cos(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Cos(res, x);
}

void Lib_ZReal_Tan(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Tan(res, x);
}

void Lib_ZReal_Csc(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Csc(res, x);
}

void Lib_ZReal_Sec(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Sec(res, x);
}

void Lib_ZReal_Cot(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Cot(res, x);
}


void Lib_ZReal_SinPi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_SinPi(res, x);
}

void Lib_ZReal_CosPi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_CosPi(res, x);
}

void Lib_ZReal_TanPi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_TanPi(res, x);
}

void Lib_ZReal_CscPi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_CscPi(res, x);
}

void Lib_ZReal_SecPi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_SecPi(res, x);
}

void Lib_ZReal_CotPi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_CotPi(res, x);
}






/* Hyperbolic functions  */

void Lib_ZReal_Sinh(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Sinh(res, x);
}

void Lib_ZReal_Cosh(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Cosh(res, x);
}

void Lib_ZReal_Tanh(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Tanh(res, x);
}

void Lib_ZReal_Csch(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Csch(res, x);
}

void Lib_ZReal_Sech(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Sech(res, x);
}

void Lib_ZReal_Coth(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Coth(res, x);
}


/* Inverse trigonometric functions  */

void Lib_ZReal_Asin(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Asin(res, x);
}

void Lib_ZReal_Acos(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Acos(res, x);
}

void Lib_ZReal_Atan(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Atan(res, x);
}

void Lib_ZReal_Atan2(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_Atan2(res, x, y);
}

void Lib_ZReal_Acsc(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Acsc(res, x);
}

void Lib_ZReal_Asec(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Asec(res, x);
}

void Lib_ZReal_Acot(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Acot(res, x);
}



/* Inverse hyperbolic functions  */

void Lib_ZReal_Asinh(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Asinh(res, x);
}

void Lib_ZReal_Acosh(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Acosh(res, x);
}

void Lib_ZReal_Atanh(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Atanh(res, x);
}

void Lib_ZReal_Acsch(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Acsch(res, x);
}

void Lib_ZReal_Asech(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Asech(res, x);
}

void Lib_ZReal_Acoth(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Acoth(res, x);
}



/* Special functions  */

void Lib_ZReal_Erf(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Erf(res, x);
}

void Lib_ZReal_Erfc(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Erfc(res, x);
}

void Lib_ZReal_Tgamma(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Tgamma(res, x);
}

void Lib_ZReal_Lgamma(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Lgamma(res, x);
}

void Lib_ZReal_BesselJ0(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_J0(res, x);
}

void Lib_ZReal_BesselJ1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_J1(res, x);
}

void Lib_ZReal_BesselJn(ZRealPtr res, const int n, const ZRealPtr x)
{
    LibZReal_Jn(res, n, x);
}

void Lib_ZReal_BesselY0(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Y0(res, x);
}

void Lib_ZReal_BesselY1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Y1(res, x);
}

void Lib_ZReal_BesselYn(ZRealPtr res, const int n, const ZRealPtr x)
{
    LibZReal_Yn(res, n, x);
}







/** ********************** Complex Basic Functions, ZCplx ******************************** **/


void Lib_Eigen_ZCplx_GetCoeff(ZCplxPtr result, long row, long col, mpNumMatrixPtr SourceMatrix)
{
//	MpdcPtr res; res = Lib_Mpdc_Init_Func();
//	MpdPtr res_re; res_re = Lib_Mpd_Init_Func();
//	MpdPtr res_im; res_im = Lib_Mpd_Init_Func();
//
//	ZRealPtr result_re; result_re = Lib_ZReal_Init_Func();
//	ZRealPtr result_im; result_im = Lib_ZReal_Init_Func();
//
//    Lib_Eigen_MpAnyCplx_GetCoeff(res, row, col, SourceMatrix);
//
//    Lib_Mpdc_Real(res_re, res);
//    Lib_Mpdc_Imag(res_im, res);
//
//    Lib_ZReal_Set_Mpd(result_re, res_re);
//    Lib_ZReal_Set_Mpd(result_im, res_im);
//
//    Lib_ZCplx_Set2(result, result_re, result_im);
//
//    Lib_ZReal_Clear(result_re);
//    Lib_ZReal_Clear(result_im);
//
//    Lib_Mpd_Clear(res_re);
//    Lib_Mpd_Clear(res_im);
//	Lib_Mpdc_Clear(res);
}



void Lib_Eigen_ZCplx_SetCoeff(mpNumMatrixPtr result, ZCplxPtr source, long row, long col)
{
//	MpdcPtr src; src = Lib_Mpdc_Init_Func();
//	MpdPtr src_re; src_re = Lib_Mpd_Init_Func();
//	MpdPtr src_im; src_im = Lib_Mpd_Init_Func();
//
//	ZRealPtr source_re; source_re = Lib_ZReal_Init_Func();
//	ZRealPtr source_im; source_im = Lib_ZReal_Init_Func();
//
//	Lib_ZCplx_Real(source_re, source);
//    Lib_ZCplx_Imag(source_im, source);
//
//    Lib_Mpd_Set_ZReal(src_re, source_re);
//    Lib_Mpd_Set_ZReal(src_im, source_im);
//    Lib_Mpdc_Set2(src, src_re, src_im);
//
//    Lib_Eigen_MpAnyCplx_SetCoeff(result, src, row, col);
//
//    Lib_ZReal_Clear(source_re);
//    Lib_ZReal_Clear(source_im);
//
//    Lib_Mpd_Clear(src_re);
//    Lib_Mpd_Clear(src_im);
//	Lib_Mpdc_Clear(src);
}




ZCplxPtr Lib_ZCplx_Init_Func()
{
    return LibZCplx_Init_Func();
}


void Lib_ZCplx_Clear(ZCplxPtr x)
{
    LibZCplx_Clear(x);
}




/* Input and output  */


void Lib_ZCplx_Set(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Set(res, x);
}






/* Operator overloading vs raw arithmetic and comparisons  */

void Lib_ZCplx_Neg(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Neg(res, x);
}

void Lib_ZCplx_Add(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    LibZCplx_Add(res, x, y);
}

void Lib_ZCplx_Sub(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    LibZCplx_Sub(res, x, y);
}

void Lib_ZCplx_Mul(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    LibZCplx_Mul(res, x, y);
}

void Lib_ZCplx_Div(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    LibZCplx_Div(res, x, y);
}


void Lib_ZCplx_Add_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y)
{
    LibZCplx_Add_ZReal(res, x, y);
}

void Lib_ZCplx_Sub_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y)
{
    LibZCplx_Sub_ZReal(res, x, y);
}

void Lib_ZCplx_ZReal_Sub(ZCplxPtr res, const ZCplxPtr y, const ZRealPtr x)
{
    LibZCplx_ZReal_Sub(res, y, x);
}


void Lib_ZCplx_Mul_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y)
{
    LibZCplx_Mul_ZReal(res, x, y);
}

void Lib_ZCplx_Div_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y)
{
    LibZCplx_Div_ZReal(res, x, y);
}


void Lib_ZCplx_ZReal_Div(ZCplxPtr res, const ZCplxPtr y, const ZRealPtr x)
{
    LibZCplx_ZReal_Div(res, y, x);
}


void Lib_ZCplx_Add_D(ZCplxPtr res, const ZCplxPtr x, const double y)
{
    LibZCplx_Add_D(res, x, y);
}

void Lib_ZCplx_Sub_D(ZCplxPtr res, const ZCplxPtr x, const double y)
{
    LibZCplx_Sub_D(res, x, y);
}

void Lib_ZCplx_D_Sub(ZCplxPtr res, const ZCplxPtr y, const double x)
{
    LibZCplx_D_Sub(res, y, x);
}

void Lib_ZCplx_Mul_D(ZCplxPtr res, const ZCplxPtr x, const double y)
{
    LibZCplx_Mul_D(res, x, y);
}

void Lib_ZCplx_Div_D(ZCplxPtr res, const ZCplxPtr x, const double y)
{
    LibZCplx_Div_D(res, x, y);
}


void Lib_ZCplx_D_Div(ZCplxPtr res, const ZCplxPtr y, const double x)
{
    LibZCplx_D_Div(res, y, x);
}

void Lib_ZCplx_Add_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y)
{
    LibZCplx_Add_Si(res, x, y);
}

void Lib_ZCplx_Sub_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y)
{
    LibZCplx_Sub_Si(res, x, y);
}

void Lib_ZCplx_Si_Sub(ZCplxPtr res, const ZCplxPtr y, const int32_t x)
{
    LibZCplx_Si_Sub(res, y, x);
}

void Lib_ZCplx_Mul_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y)
{
    LibZCplx_Mul_Si(res, x, y);
}



/* Missing: Inv */



void Lib_ZCplx_Div_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y)
{
    LibZCplx_Div_Si(res, x, y);
}

void Lib_ZCplx_Si_Div(ZCplxPtr res, const ZCplxPtr y, const int32_t x)
{
    LibZCplx_Si_Div(res, y, x);
}
















/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void Lib_ZCplx_Set_Real(ZCplxPtr res, const ZRealPtr re)
{
    LibZCplx_Set_Real(res, re);
}

void Lib_ZCplx_Set2(ZCplxPtr res, const ZRealPtr re, const ZRealPtr im)
{
    LibZCplx_Set2(res, re, im);
}

void Lib_ZCplx_Abs(ZRealPtr res, const ZCplxPtr x)
{
    LibZCplx_Abs(res, x);
}

void Lib_ZCplx_Norm(ZRealPtr res, const ZCplxPtr x)
{
    LibZCplx_Abs(res, x);
}

void Lib_ZCplx_Arg(ZRealPtr res, const ZCplxPtr x)
{
    LibZCplx_Arg(res, x);
}

void Lib_ZCplx_Imag(ZRealPtr res, const ZCplxPtr x)
{
    LibZCplx_Imag(res, x);
}

void Lib_ZCplx_Real(ZRealPtr res, const ZCplxPtr x)
{
    LibZCplx_Real(res, x);
}

void Lib_ZCplx_Conj(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Conj(res, x);
}

void Lib_ZCplx_Proj(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Proj(res, x);
}





/* Roots  */

void Lib_ZCplx_Sqrt(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Sqrt(res, x);
}

void Lib_ZCplx_Sqrt1pm1(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Sqrt1pm1(res, x);
}

void Lib_ZCplx_Rsqrt(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Rsqrt(res, x);
}

void Lib_ZCplx_Cbrt(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Cbrt(res, x);
}

void Lib_ZCplx_Root_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k)
{
    LibZCplx_Root_Si(res, x, k);
}




/* Exponential and related functions  */

void Lib_ZCplx_Exp(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Exp(res, x);
}


void Lib_ZCplx_Exp2(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Exp2(res, x);
}

void Lib_ZCplx_Exp10(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Exp10(res, x);
}


void Lib_ZCplx_Expm1(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Expm1(res, x);
}

void Lib_ZCplx_Exp2m1(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Exp2m1(res, x);
}

void Lib_ZCplx_Exp10m1(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Exp10m1(res, x);
}



/* Logarithms and related functions  */

void Lib_ZCplx_Log(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Log(res, x);
}

void Lib_ZCplx_Log2(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Log2(res, x);
}

void Lib_ZCplx_Log10(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Log10(res, x);
}

void Lib_ZCplx_Log1p(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Log1p(res, x);
}

void Lib_ZCplx_Log2p1(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Log2p1(res, x);
}

void Lib_ZCplx_Log10p1(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Log10p1(res, x);
}




/* Power functions and roots  */

void Lib_ZCplx_Square(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Square(res, x);
}

void Lib_ZCplx_Cube(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Cube(res, x);
}

void Lib_ZCplx_Pow(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    LibZCplx_Pow(res, x, y);
}


void Lib_ZCplx_Powm1(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    LibZCplx_Powm1(res, x, y);
}

void Lib_ZCplx_Pow1p(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    LibZCplx_Pow1p(res, x, y);
}

void Lib_ZCplx_Pow1pm1(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    LibZCplx_Pow1pm1(res, x, y);
}


void Lib_ZCplx_Pow_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k)
{
    LibZCplx_Pow_Si(res, x, k);
}

void Lib_ZCplx_Compound_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k)
{
    LibZCplx_Compound_Si(res, x, k);
}





/* Trigonometric functions  */

void Lib_ZCplx_Sin(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Sin(res, x);
}

void Lib_ZCplx_Cos(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Cos(res, x);
}

void Lib_ZCplx_Tan(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Tan(res, x);
}


void Lib_ZCplx_Csc(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Csc(res, x);
}

void Lib_ZCplx_Sec(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Sec(res, x);
}

void Lib_ZCplx_Cot(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Cot(res, x);
}


void Lib_ZCplx_SinPi(ZCplxPtr res, const ZCplxPtr x)
{
    //LibZCplx_SinPi(res, x);
}

void Lib_ZCplx_CosPi(ZCplxPtr res, const ZCplxPtr x)
{
    //LibZCplx_CosPi(res, x);
}

void Lib_ZCplx_TanPi(ZCplxPtr res, const ZCplxPtr x)
{
    //LibZCplx_TanPi(res, x);
}




/* Hyperbolic functions  */

void Lib_ZCplx_Sinh(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Sinh(res, x);
}

void Lib_ZCplx_Cosh(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Cosh(res, x);
}

void Lib_ZCplx_Tanh(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Tanh(res, x);
}


void Lib_ZCplx_Csch(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Csch(res, x);
}

void Lib_ZCplx_Sech(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Sech(res, x);
}

void Lib_ZCplx_Coth(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Coth(res, x);
}



/* Inverse trigonometric functions  */

void Lib_ZCplx_Asin(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Asin(res, x);
}

void Lib_ZCplx_Acos(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Acos(res, x);
}

void Lib_ZCplx_Atan(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Atan(res, x);
}


void Lib_ZCplx_Acsc(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Acsc(res, x);
}

void Lib_ZCplx_Asec(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Asec(res, x);
}

void Lib_ZCplx_Acot(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Acot(res, x);
}




/* Inverse hyperbolic functions  */

void Lib_ZCplx_Asinh(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Asinh(res, x);
}

void Lib_ZCplx_Acosh(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Acosh(res, x);
}

void Lib_ZCplx_Atanh(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Atanh(res, x);
}


void Lib_ZCplx_Acsch(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Acsch(res, x);
}

void Lib_ZCplx_Asech(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Asech(res, x);
}

void Lib_ZCplx_Acoth(ZCplxPtr res, const ZCplxPtr x)
{
    LibZCplx_Acoth(res, x);
}




















//*********************** Boost Special functions , ZReal **********************************



void Lib_ZReal_BernoulliB2n(ZRealPtr res, const int n)
{
    LibZReal_BernoulliB2n(res, n);
}



void Lib_ZReal_TangentT2n(ZRealPtr res, const int n)
{
    LibZReal_TangentT2n(res, n);
}



void Lib_ZReal_Sqrt1pm1_Boost(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Sqrt1pm1(res, x);
}



void Lib_ZReal_SinPi_Boost(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_SinPi(res, x);
}



void Lib_ZReal_CosPi_Boost(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_CosPi(res, x);
}



void Lib_ZReal_SincPi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_SincPi(res, x);
}



void Lib_ZReal_SinhcPi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_SinhcPi(res, x);
}



void Lib_ZReal_Tgamma_(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Tgamma_(res, x);
}


void Lib_ZReal_Tgamma1pm1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Tgamma1pm1(res, x);
}



void Lib_ZReal_Lgamma_(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Lgamma_(res, x);
}



void Lib_ZReal_Digamma(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Digamma(res, x);
}



void Lib_ZReal_Trigamma(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Trigamma(res, x);
}



void Lib_ZReal_Factorial(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Factorial(res, x);
}



void Lib_ZReal_DoubleFactorial(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_DoubleFactorial(res, x);
}





void Lib_ZReal_Erf_(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Erf_(res, x);
}



void Lib_ZReal_Erfc_(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Erfc_(res, x);
}



void Lib_ZReal_Erf_inv(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Erf_inv(res, x);
}



void Lib_ZReal_Erfc_inv(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Erfc_inv(res, x);
}



void Lib_ZReal_AiryAi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_AiryAi(res, x);
}



void Lib_ZReal_AiryBi(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_AiryBi(res, x);
}



void Lib_ZReal_AiryAiPrime(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_AiryAiPrime(res, x);
}



void Lib_ZReal_AiryBiPrime(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_AiryBiPrime(res, x);
}



void Lib_ZReal_Aizero(ZRealPtr res, const int n)
{
    LibZReal_Aizero(res, n);
}



void Lib_ZReal_Bizero(ZRealPtr res, const int n)
{
    LibZReal_Bizero(res, n);
}



void Lib_ZReal_Ellint_1_K(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Ellint_1_K(res, x);
}



void Lib_ZReal_Ellint_2_K(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Ellint_2_K(res, x);
}



void Lib_ZReal_Zeta(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Zeta(res, x);
}



void Lib_ZReal_Ei(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_Ei(res, x);
}



void Lib_ZReal_LambertW0(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_LambertW0(res, x);
}


void Lib_ZReal_LambertWm1(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_LambertWm1(res, x);
}



void Lib_ZReal_LambertW0Prime(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_LambertW0Prime(res, x);
}


void Lib_ZReal_LambertWm1Prime(ZRealPtr res, const ZRealPtr x)
{
    LibZReal_LambertWm1Prime(res, x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void Lib_ZReal_Powm1_Boost(ZRealPtr res, const ZRealPtr a, const ZRealPtr b)
{
    LibZReal_Powm1(res, a, b);
}



void Lib_ZReal_TgammaRatio(ZRealPtr res, const ZRealPtr a, const ZRealPtr b)
{
    LibZReal_TgammaRatio(res, a, b);
}



void Lib_ZReal_TgammaDeltaRatio(ZRealPtr res, const ZRealPtr a, const ZRealPtr b)
{
    LibZReal_TgammaDeltaRatio(res, a, b);
}



void Lib_ZReal_Binomial(ZRealPtr res, const ZRealPtr n, const ZRealPtr k)
{
    LibZReal_Binomial(res, n, k);
}

void Lib_ZReal_RisingFactorial(ZRealPtr res, const ZRealPtr x, const ZRealPtr n)
{
    LibZReal_RisingFactorial(res, x, n);
}




void Lib_ZReal_FallingFactorial(ZRealPtr res, const ZRealPtr x, const ZRealPtr n)
{
    LibZReal_FallingFactorial(res, x, n);
}




void Lib_ZReal_BesselJ(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
    LibZReal_BesselJ(res, v, x);
}



void Lib_ZReal_BesselY(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
    LibZReal_BesselY(res, v, x);
}



void Lib_ZReal_BesselI(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
    LibZReal_BesselI(res, v, x);
}



void Lib_ZReal_BesselK(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
    LibZReal_BesselK(res, v, x);
}



void Lib_ZReal_SphBessel(ZRealPtr res, const unsigned v, const ZRealPtr x)
{
    LibZReal_SphBessel(res, v, x);
}



void Lib_ZReal_SphNeumann(ZRealPtr res, const unsigned v, const ZRealPtr x)
{
    LibZReal_SphNeumann(res, v, x);
}





void Lib_ZReal_BesselJPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
    LibZReal_BesselJPrime(res, v, x);
}



void Lib_ZReal_BesselYPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
    LibZReal_BesselYPrime(res, v, x);
}



void Lib_ZReal_BesselIPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
    LibZReal_BesselIPrime(res, v, x);
}



void Lib_ZReal_BesselKPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
    LibZReal_BesselKPrime(res, v, x);
}



void Lib_ZReal_SphBesselPrime(ZRealPtr res, const unsigned v, const ZRealPtr x)
{
    LibZReal_SphBesselPrime(res, v, x);
}



void Lib_ZReal_SphNeumannPrime(ZRealPtr res, const unsigned v, const ZRealPtr x)
{
    LibZReal_SphNeumannPrime(res, v, x);
}





void Lib_ZReal_BesselJZero(ZRealPtr res, const ZRealPtr v, const int m)
{
    LibZReal_BesselJZero(res, v, m);
}



void Lib_ZReal_BesselYZero(ZRealPtr res, const ZRealPtr v, const int m)
{
    LibZReal_BesselYZero(res, v, m);
}





void Lib_ZReal_GammaP(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
    LibZReal_GammaP(res, a, x);
}


void Lib_ZReal_GammaQ(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
    LibZReal_GammaQ(res, a, x);
}


void Lib_ZReal_TgammaLower(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
    LibZReal_TgammaLower(res, a, x);
}


void Lib_ZReal_TgammaUpper(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
    LibZReal_TgammaUpper(res, a, x);
}




void Lib_ZReal_GammaPInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr p)
{
    LibZReal_GammaPInv(res, a, p);
}


void Lib_ZReal_GammaQInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr q)
{
    LibZReal_GammaQInv(res, a, q);
}


void Lib_ZReal_GammaPInva(ZRealPtr res, const ZRealPtr x, const ZRealPtr p)
{
    LibZReal_GammaPInva(res, x, p);
}


void Lib_ZReal_GammaQInva(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
    LibZReal_GammaQInva(res, x, q);
}



void Lib_ZReal_GammaPDerivative(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
    LibZReal_GammaPDerivative(res, a, x);
}


void Lib_ZReal_Beta(ZRealPtr res, const ZRealPtr a, const ZRealPtr b)
{
    LibZReal_Beta(res, a, b);
}









void Lib_ZReal_LegendreP(ZRealPtr res, int n, const ZRealPtr x)
{
    LibZReal_LegendreP(res, n, x);
}



void Lib_ZReal_LegendreQ(ZRealPtr res, int n, const ZRealPtr x)
{
    LibZReal_LegendreQ(res, n, x);
}



void Lib_ZReal_Laguerre(ZRealPtr res, int n, const ZRealPtr x)
{
    LibZReal_Laguerre(res, n, x);
}



void Lib_ZReal_Hermite(ZRealPtr res, int n, const ZRealPtr x)
{
    LibZReal_Hermite(res, n, x);
}



void Lib_ZReal_ChebyshevT(ZRealPtr res, int n, const ZRealPtr x)
{
    LibZReal_ChebyshevT(res, n, x);
}


void Lib_ZReal_ChebyshevU(ZRealPtr res, int n, const ZRealPtr x)
{
    LibZReal_ChebyshevU(res, n, x);
}



void Lib_ZReal_Polygamma(ZRealPtr res, int n, const ZRealPtr x)
{
    LibZReal_Polygamma(res, n, x);
}





void Lib_ZReal_EllintRC(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
    LibZReal_EllintRC(res, x, y);
}


void Lib_ZReal_Ellint1F(ZRealPtr res, const ZRealPtr k, const ZRealPtr phi)
{
    LibZReal_Ellint1F(res, k, phi);
}


void Lib_ZReal_Ellint2F(ZRealPtr res, const ZRealPtr k, const ZRealPtr phi)
{
    LibZReal_Ellint2F(res, k, phi);
}


void Lib_ZReal_Ellint3K(ZRealPtr res, const ZRealPtr k, const ZRealPtr n)
{
    LibZReal_Ellint3K(res, k, n);
}




void Lib_ZReal_JacobiCD(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiCD(res, k, u);
}


void Lib_ZReal_JacobiCN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiCN(res, k, u);
}


void Lib_ZReal_JacobiCS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiCS(res, k, u);
}


void Lib_ZReal_JacobiDC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiDC(res, k, u);
}


void Lib_ZReal_JacobiDN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiDN(res, k, u);
}


void Lib_ZReal_JacobiDS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiDS(res, k, u);
}


void Lib_ZReal_JacobiNC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiNC(res, k, u);
}


void Lib_ZReal_JacobiND(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiND(res, k, u);
}


void Lib_ZReal_JacobiNS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiNS(res, k, u);
}


void Lib_ZReal_JacobiSC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiSC(res, k, u);
}


void Lib_ZReal_JacobiSD(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiSD(res, k, u);
}


void Lib_ZReal_JacobiSN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
    LibZReal_JacobiSN(res, k, u);
}



void Lib_ZReal_expint(ZRealPtr res, const unsigned n, const ZRealPtr x)
{
    LibZReal_expint(res, n, x);
}




void Lib_ZReal_OwenT(ZRealPtr res, const ZRealPtr h, const ZRealPtr a)
{
    LibZReal_OwenT(res, h, a);
}





void Lib_ZReal_IBeta(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_IBeta(res, a, b, x);
}


void Lib_ZReal_IBetac(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_IBetac(res, a, b, x);
}


void Lib_ZReal_IBetaNonNormalized(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_IBetaNonNormalized(res, a, b, x);
}


void Lib_ZReal_IBetacNonNormalized(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_IBetacNonNormalized(res, a, b, x);
}


void Lib_ZReal_IBetaInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr p)
{
    LibZReal_IBetaInv(res, a, b, p);
}


void Lib_ZReal_IBetacInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr q)
{
    LibZReal_IBetacInv(res, a, b, q);
}


void Lib_ZReal_IBetaInva(ZRealPtr res, const ZRealPtr b, const ZRealPtr x, const ZRealPtr p)
{
    LibZReal_IBetaInva(res, b, x, p);
}


void Lib_ZReal_IBetacInva(ZRealPtr res, const ZRealPtr b, const ZRealPtr x, const ZRealPtr q)
{
    LibZReal_IBetacInva(res, b, x, q);
}


void Lib_ZReal_IBetaInvb(ZRealPtr res, const ZRealPtr a, const ZRealPtr x, const ZRealPtr p)
{
    LibZReal_IBetaInvb(res, a, x, p);
}


void Lib_ZReal_IBetacInvb(ZRealPtr res, const ZRealPtr a, const ZRealPtr x, const ZRealPtr q)
{
    LibZReal_IBetacInvb(res, a, x, q);
}


void Lib_ZReal_IBetaDerivative(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_IBetaDerivative(res, a, b, x);
}




void Lib_ZReal_LegendrePM(ZRealPtr res, const int n, const int m, const ZRealPtr x)
{
    LibZReal_LegendrePM(res, n, m, x);
}



void Lib_ZReal_LaguerreM(ZRealPtr res, const int n, const int m, const ZRealPtr x)
{
    LibZReal_LaguerreM(res, n, m, x);
}





void Lib_ZReal_EllipticRF(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z)
{
    LibZReal_EllipticRF(res, x, y, z);
}



void Lib_ZReal_EllipticRD(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z)
{
    LibZReal_EllipticRD(res, x, y, z);
}



void Lib_ZReal_Ellint3F(ZRealPtr res, const ZRealPtr k, const ZRealPtr n, const ZRealPtr phi)
{
    LibZReal_Ellint3F(res, k, n, phi);
}




void Lib_ZReal_SphericalHarmonicR(ZRealPtr res, const int n, const int m, const ZRealPtr theta, const ZRealPtr phi)
{
    LibZReal_SphericalHarmonicR(res, n, m, theta, phi);
}


void Lib_ZReal_SphericalHarmonicI(ZRealPtr res, const int n, const int m, const ZRealPtr theta, const ZRealPtr phi)
{
    LibZReal_SphericalHarmonicI(res, n, m, theta, phi);
}


void Lib_ZReal_EllipticRJ(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z, const ZRealPtr p)
{
    LibZReal_EllipticRJ(res, x, y, z, p);
}


// Hypergeometric and Theta Functions




void Lib_ZReal_Hypergeo0F1(ZRealPtr res, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_Hypergeo0F1(res, b, x);
}



void Lib_ZReal_Hypergeo1F1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_Hypergeo1F1(res, a, b, x);
}



void Lib_ZReal_Hypergeo1F1r(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_Hypergeo1F1r(res, a, b, x);
}



void Lib_ZReal_LogHypergeo1F1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
    LibZReal_LogHypergeo1F1(res, a, b, x);
}





void Lib_ZReal_JacobiTheta1(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
    LibZReal_JacobiTheta1(res, x, q);
}


void Lib_ZReal_JacobiTheta2(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
    LibZReal_JacobiTheta2(res, x, q);
}


void Lib_ZReal_JacobiTheta3(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
    LibZReal_JacobiTheta3(res, x, q);
}


void Lib_ZReal_JacobiTheta4(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
    LibZReal_JacobiTheta4(res, x, q);
}






//***********************  Boost Distributions, ZReal  **********************************


void Lib_ZReal_ArcsineDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b)
{
    LibZReal_ArcsineDist(Target, res, xqp, a, b);
}



void Lib_ZReal_BernoulliDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr p)
{
    LibZReal_BernoulliDist(Target, res, xqp, p);
}



void Lib_ZReal_BetaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b)
{
    LibZReal_BetaDist(Target, res, xqp, a, b);
}



void Lib_ZReal_BinomialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr n, ZRealPtr p)
{
    LibZReal_BinomialDist(Target, res, xqp, n, p);
}



void Lib_ZReal_CauchyDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    LibZReal_CauchyDist(Target, res, xqp, location, scale);
}



void Lib_ZReal_Chi2Dist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu)
{
    LibZReal_Chi2Dist(Target, res, xqp, nu);
}



void Lib_ZReal_ExponentialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lambda)
{
    LibZReal_ExponentialDist(Target, res, xqp, lambda);
}



void Lib_ZReal_ExtremeValueDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    LibZReal_ExtremeValueDist(Target, res, xqp, location, scale);
}



void Lib_ZReal_FisherFDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mu, ZRealPtr nu)
{
    LibZReal_FisherFDist(Target, res, xqp, mu, nu);
}



void Lib_ZReal_GammaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale)
{
    LibZReal_GammaDist(Target, res, xqp, shape, scale);
}



void Lib_ZReal_GeometricDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr p)
{
    LibZReal_GeometricDist(Target, res, xqp, p);
}



void Lib_ZReal_HypergeometricDist(long Target, ZRealPtr res, ZRealPtr xqp, unsigned r, unsigned n, unsigned N)
{
    LibZReal_HypergeometricDist(Target, res, xqp, r, n, N);
}



void Lib_ZReal_InverseChi2Dist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr df, ZRealPtr scale)
{
    LibZReal_InverseChi2Dist(Target, res, xqp, df, scale);
}



void Lib_ZReal_InverseGammaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale)
{
    LibZReal_InverseGammaDist(Target, res, xqp, shape, scale);
}



void Lib_ZReal_WaldDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr scale)
{
    LibZReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
}



void Lib_ZReal_LaplaceDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    LibZReal_LaplaceDist(Target, res, xqp, location, scale);
}



void Lib_ZReal_LogisticDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    LibZReal_LogisticDist(Target, res, xqp, location, scale);
}



void Lib_ZReal_LognormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    LibZReal_LognormalDist(Target, res, xqp, location, scale);
}



void Lib_ZReal_NegBinomialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr n, ZRealPtr p)
{
    LibZReal_NegBinomialDist(Target, res, xqp, n, p);
}


void Lib_ZReal_Chi2NcDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu, ZRealPtr nc)
{
    LibZReal_Chi2NCDist(Target, res, xqp, nu, nc);
}


void Lib_ZReal_StudentTNcDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu, ZRealPtr delta)
{
    LibZReal_StudentTNCDist(Target, res, xqp, nu, delta);
}



void Lib_ZReal_FisherNcDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mu, ZRealPtr nu, ZRealPtr nc)
{
    LibZReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
}



void Lib_ZReal_BetaNcDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b, ZRealPtr nc)
{
    LibZReal_BetaNCDist(Target, res, xqp, a, b, nc);
}



void Lib_ZReal_NormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr stdev)
{
    LibZReal_NormalDist(Target, res, xqp, mean_, stdev);
}



void Lib_ZReal_ParetoDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale)
{
    LibZReal_ParetoDist(Target, res, xqp, shape, scale);
}



void Lib_ZReal_PoissonDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu)
{
    LibZReal_PoissonDist(Target, res, xqp, nu);
}



void Lib_ZReal_RayleighDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu)
{
    LibZReal_RayleighDist(Target, res, xqp, nu);
}



void Lib_ZReal_SkewNormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr scale, ZRealPtr shape)
{
    LibZReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
}



void Lib_ZReal_StudentTDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu)
{
    LibZReal_StudentTDist(Target, res, xqp, nu);
}



void Lib_ZReal_TriangularDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lower, ZRealPtr mode_, ZRealPtr upper)
{
    LibZReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
}



void Lib_ZReal_WeibullDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale)
{
    LibZReal_WeibullDist(Target, res, xqp, shape, scale);
}



void Lib_ZReal_UniformDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lower, ZRealPtr upper)
{
    LibZReal_UniformDist(Target, res, xqp, lower, upper);
}





//*********************** Boost Numerical Calculus, ZReal **********************************




void Lib_ZReal_BracketRoot(ZRealPtr res1, ZRealPtr res2, int* iter, ZRealFuncPtr f1, ZRealPtr guess_, ZRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    LibZReal_BracketRoot(res1, res2, iter, f1, guess_, factor_, is_rising, get_digits, maxit);
}



void Lib_ZReal_NewtonRaphson(ZRealPtr res,  int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibZReal_NewtonRaphson(res, iter, f1, f2, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_ZReal_Halley(ZRealPtr res, int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibZReal_Halley(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_ZReal_Schroder(ZRealPtr res, int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibZReal_Schroder(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_ZReal_Brent_Minimum(ZRealPtr res, ZRealPtr resFx, int* iter, ZRealFuncPtr f1, ZRealPtr bracket_min_, ZRealPtr bracket_max_, int bits, unsigned int maxit)
{
    LibZReal_Brent_Minimum(res, resFx, iter, f1, bracket_min_, bracket_max_, bits, maxit);
}





void Lib_ZReal_Trapezoidal(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_)
{
    LibZReal_Trapezoidal(res1, res2, res3, f1, a_, b_);
}



// 7, 15, 20, 25 and 30

void Lib_ZReal_GaussLegendre(ZRealPtr res1, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_)
{
    LibZReal_GaussLegendre(res1, res3, f1, a_, b_);
}



//15, 31, 41, 51 and 61

void Lib_ZReal_GaussKronrod(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_)
{
    LibZReal_GaussKronrod(res1, res2, res3, f1, a_, b_);
}



void Lib_ZReal_TanhSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_)
{
    LibZReal_TanhSinh(res1, res2, res3, levels_, f1, a_, b_);
}




void Lib_ZReal_SinhSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1)
{
    LibZReal_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_ZReal_ExpSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1)
{
    LibZReal_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_ZReal_Ooura_Cos(ZRealPtr res1, ZRealPtr res2, ZRealFuncPtr f1)
{
    LibZReal_Ooura_Cos(res1, res2, f1);
}



void Lib_ZReal_Ooura_Sin(ZRealPtr res1, ZRealPtr res2, ZRealFuncPtr f1)
{
    LibZReal_Ooura_Sin(res1, res2, f1);
}









//*********************** Boost Odeint **********************************


AnyPtr Lib_ZReal_StateInit_Func_N(int N)
{
    return LibZReal_StateInit_Func_N(N);
}


void Lib_ZReal_StateClear(mpNumMatrixPtr x)
{
    return LibZReal_StateClear((DStatePtr) x);
}


void Lib_ZReal_StateGetCoeff(ScalarPtr res, long row, mpNumMatrixPtr source)
{
    LibZReal_StateGetCoeff((ZRealPtr) res, row, (DStatePtr) source);
}

void Lib_ZReal_StateSetCoeff(mpNumMatrixPtr result, ScalarPtr source, long row)
{
    LibZReal_StateSetCoeff((DStatePtr) result, (ZRealPtr) source, row);
}


void Lib_ZReal_StateGetSize(long *result, mpNumMatrixPtr x)
{
    LibZReal_StateGetSize(result, (DStatePtr)x);
}


void Lib_ZReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    LibZReal_Const_RungeKutta4((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_ZReal_Const_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    LibZReal_Const_RungeKuttaCashKarp54((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_ZReal_Const_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    LibZReal_Const_RungeKuttaDopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_ZReal_Const_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    LibZReal_Const_RungeKuttaFehlberg78((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_ZReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    LibZReal_Const_AdamsBashforthMoulton((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}


void Lib_ZReal_Adaptive_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    LibZReal_Adaptive_RungeKuttaDopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_ZReal_Adaptive_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    LibZReal_Adaptive_RungeKuttaCashKarp54((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_ZReal_Adaptive_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    LibZReal_Adaptive_RungeKuttaFehlberg78((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_ZReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    LibZReal_Adaptive_BulirschStoer((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_ZReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    LibZReal_DenseOutput_Dopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_ZReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    LibZReal_DenseOutput_BulirschStoer((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}







//*********************** Boost/CppOptLib **********************************


void Lib_ZReal_GradientDescentSolverSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr)
{
    LibZReal_GradientDescentSolverSolver((ZRealFuncPtr) f1, (ZRealFuncPtr) f2, (DStatePtr) matX_, (DStatePtr) matGrad_, (DStatePtr) matNorm_, (DStatePtr) xPtr);
}


void Lib_ZReal_ConjugatedGradientDescentSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr)
{
    LibZReal_ConjugatedGradientDescentSolver((ZRealFuncPtr) f1, (ZRealFuncPtr) f2, (DStatePtr) matX_, (DStatePtr) matGrad_, (DStatePtr) matNorm_, (DStatePtr) xPtr);
}


void Lib_ZReal_BfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr)
{
    LibZReal_BfgsSolver((ZRealFuncPtr) f1, (ZRealFuncPtr) f2, (DStatePtr) matX_, (DStatePtr) matGrad_, (DStatePtr) matNorm_, (DStatePtr) xPtr);
}


void Lib_ZReal_LbfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr)
{
    LibZReal_LbfgsSolver((ZRealFuncPtr) f1, (ZRealFuncPtr) f2, (DStatePtr) matX_, (DStatePtr) matGrad_, (DStatePtr) matNorm_, (DStatePtr) xPtr);
}











































