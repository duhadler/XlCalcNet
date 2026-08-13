
#include "mpNumC_Main.h"
#include "BoostYReal.h"

#include "stdint.h"
#include <string.h>
#include <complex>
#include <limits>
#include "mpdecimal.h"








/** ********************** Real Basic Functions, double precision ******************************** **/


YRealPtr Lib_YReal_Init_Func()
{
    return LibYReal_Init_Func();
}




void Lib_YReal_Clear(YRealPtr x)
{
    LibYReal_Clear(x);
}



/* Input and output  */


void Lib_YReal_Set(YRealPtr res, const YRealPtr x)
{
    LibYReal_Set(res, x);
}

//void Lib_YReal_Set_Fmpq(YRealPtr res, const FmpqPtr x)
//{
//    mpd_t* b;
//    b = mpd_new(mpd_globalctx());
//    decr_set_fmpq(b, (fmpq*)x);
//	char * str = mpd_to_sci(b, 1);
//	LibYReal_Set_Str(res, str);
//    mpd_del(b);
//	free(str);
//}
//
//void Lib_YReal_Set_Arb(YRealPtr res, const ArbPtr x)
//{
//	char * str = arb_get_str((arb_ptr)x, 51, ARB_STR_NO_RADIUS);
//	LibYReal_Set_Str(res, str);
//	free(str);
//}
//
//void Lib_YReal_Set_Arf(YRealPtr res, const ArfPtr x)
//{
//	arb_t temp; arb_init(temp);
//	arf_set(arb_midref(temp), (arf_ptr)x);
//	mag_zero(arb_radref(temp));
//	char * str = arb_get_str(temp, 51, ARB_STR_NO_RADIUS);
//	LibYReal_Set_Str(res, str);
//	free(str);
//	arb_clear(temp);
//}

//void Lib_YReal_Set_Mpfi(YRealPtr res, const MpfiPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	mpfi_mid (temp, (mpfi_ptr)x);
//	char * str = mpfr_get_str_extern("%.50RE", 51, temp);
//	LibYReal_Set_Str(res, str);
//	free(str);
//	mpfr_clear(temp);
//}
//
//void Lib_YReal_Set_Mpfr(YRealPtr res, const MpfrPtr x)
//{
//	char * str = mpfr_get_str_extern("%.50RE", 51, (mpfr_ptr)x);
//	LibYReal_Set_Str(res, str);
//	free(str);
//}

void Lib_YReal_Set_Mpd(YRealPtr res, const MpdPtr x)
{
	char * str = mpd_to_sci((mpd_t *)x, 1);
	LibYReal_Set_Str(res, str);
	free(str);
}

void Lib_YReal_Set_YReal(YRealPtr res, const YRealPtr x)
{
    LibYReal_Set(res, x);
}

void Lib_YReal_Set_QReal(YRealPtr res, QRealPtr x)
{
//    mpfr_t temp; mpfr_init2(temp, 128);
//    mpfr_set_float128 (temp, *(__float128*)x, MPFR_RNDN);
//	char * str = mpfr_get_str_extern("%.50RE", 46, temp);
//	LibYReal_Set_Str(res, str);
//	free(str);
//	mpfr_clear(temp);
}


void Lib_YReal_Set_LD(YRealPtr res, const long double* x)
{
    LibYReal_Set_LD(res,x);
}

void Lib_YReal_Set_D(YRealPtr res, const double x)
{
    LibYReal_Set_D(res,x);
}

void Lib_YReal_Set_S(YRealPtr res, const float* x)
{
    LibYReal_Set_S(res,x);
}

void Lib_YReal_Set_Si(YRealPtr res, const int32_t x)
{
	LibYReal_Set_Si(res, x);
}

void Lib_YReal_Set_Ui(YRealPtr res, const uint32_t x)
{
	LibYReal_Set_Ui(res, x);
}

void Lib_YReal_Set_Si64(YRealPtr res, const int64_t x)
{
	LibYReal_Set_Si64(res, x);
}

void Lib_YReal_Set_Ui64(YRealPtr res, const uint64_t x)
{
	LibYReal_Set_Ui64(res, x);
}

void Lib_YReal_Set_Str(YRealPtr res, const char * str)
{
    LibYReal_Set_Str(res, str);
}

void Lib_YReal_Get_Str(char* cstr, const YRealPtr x)
{
    LibYReal_Get_Str(cstr, x);
}



/* Operator overloading vs raw arithmetic and comparisons  */


void Lib_YReal_Neg(YRealPtr res, const YRealPtr x)
{
    LibYReal_Neg(res, x);
}

void Lib_YReal_Add(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Add(res, x, y);
}

void Lib_YReal_Sub(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Sub(res, x, y);
}

void Lib_YReal_Mul(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Mul(res, x, y);
}

void Lib_YReal_Div(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Div(res, x, y);
}

void Lib_YReal_Add_D(YRealPtr res, const YRealPtr x, const double y)
{
    LibYReal_Add_D(res, x, y);
}

void Lib_YReal_Sub_D(YRealPtr res, const YRealPtr x, const double y)
{
    LibYReal_Sub_D(res, x, y);
}

void Lib_YReal_D_Sub(YRealPtr res, const YRealPtr x, const double y)
{
    LibYReal_D_Sub(res, x, y);
}

void Lib_YReal_Mul_D(YRealPtr res, const YRealPtr x, const double y)
{
    LibYReal_Mul_D(res, x, y);
}

void Lib_YReal_Div_D(YRealPtr res, const YRealPtr x, const double y)
{
    LibYReal_Div_D(res, x, y);
}

void Lib_YReal_D_Div(YRealPtr res, const YRealPtr x, const double y)
{
    LibYReal_D_Div(res, x, y);
}

void Lib_YReal_Add_Si(YRealPtr res, const YRealPtr x, const int32_t y)
{
    LibYReal_Add_Si(res, x, y);
}

void Lib_YReal_Sub_Si(YRealPtr res, const YRealPtr x, const int32_t y)
{
    LibYReal_Sub_Si(res, x, y);
}

void Lib_YReal_Si_Sub(YRealPtr res, const YRealPtr x, const int32_t y)
{
    LibYReal_Si_Sub(res, x, y);
}

void Lib_YReal_Mul_Si(YRealPtr res, const YRealPtr x, const int32_t y)
{
    LibYReal_Mul_Si(res, x, y);
}

void Lib_YReal_Div_Si(YRealPtr res, const YRealPtr x, const int32_t y)
{
    LibYReal_Div_Si(res, x, y);
}

void Lib_YReal_Si_Div(YRealPtr res, const YRealPtr x, const int32_t y)
{
    LibYReal_Si_Div(res, x, y);
}


int32_t Lib_YReal_LT(const YRealPtr x, const YRealPtr y)
{
    return LibYReal_LT(x, y);
}

int32_t Lib_YReal_GE(const YRealPtr x, const YRealPtr y)
{
    return LibYReal_GE(x, y);
}

int32_t Lib_YReal_GT(const YRealPtr x, const YRealPtr y)
{
    return LibYReal_GT(x, y);
}

int32_t Lib_YReal_LE(const YRealPtr x, const YRealPtr y)
{
    return LibYReal_LE(x, y);
}

int32_t Lib_YReal_EQ(const YRealPtr x, const YRealPtr y)
{
    return LibYReal_EQ(x, y);
}

int32_t Lib_YReal_NE(const YRealPtr x, const YRealPtr y)
{
    return LibYReal_NE(x, y);
}










/* General functions for real numbers  */

void Lib_YReal_Fma(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z)
{
    LibYReal_Fma(res, x, y, z);
}

void Lib_YReal_Fmax(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Fmax(res, x, y);
}

void Lib_YReal_Fmin(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Fmin(res, x, y);
}




/* Machine constants */

void Lib_YReal_Zero(YRealPtr res)
{
    LibYReal_Zero(res);
}

void Lib_YReal_NegZero(YRealPtr res)
{
    LibYReal_NegZero(res);
}

void Lib_YReal_One(YRealPtr res)
{
    LibYReal_One(res);
}

void Lib_YReal_Inf(YRealPtr res)
{
    LibYReal_Inf(res);
}

void Lib_YReal_NegInf(YRealPtr res)
{
    LibYReal_NegInf(res);
}

void Lib_YReal_Nan(YRealPtr res)
{
    LibYReal_Nan(res);
}



/* Properties of numbers  */

int Lib_YReal_Signbit(const YRealPtr x)
{
    return LibYReal_Signbit(x);
}

int Lib_YReal_Finite(const YRealPtr x)
{
    return LibYReal_Finite(x);
}

int Lib_YReal_Isinf(const YRealPtr x)
{
    return LibYReal_Isinf(x);
}

int Lib_YReal_Isposinf(const YRealPtr x)
{
    return LibYReal_Isinf(x);
}

int Lib_YReal_Isneginf(const YRealPtr x)
{
    return LibYReal_Isneginf(x);
}

int Lib_YReal_Isnan(const YRealPtr x)
{
    return LibYReal_Isnan(x);
}





int Lib_YReal_Iszero(const YRealPtr x)
{
	return LibYReal_Iszero(x);
}

int Lib_YReal_Isposzero(const YRealPtr x)
{
	return  LibYReal_Isposzero(x);
}

int Lib_YReal_Isnegzero(const YRealPtr x)
{
	return LibYReal_Isnegzero(x);
}

int Lib_YReal_Isone(const YRealPtr x)
{
	return LibYReal_Isone(x);
}

int Lib_YReal_Isinteger(const YRealPtr x)
{
	return LibYReal_Isinteger(x);
}

int Lib_YReal_Isnumber(const YRealPtr x)
{
	return LibYReal_Isnumber(x);
}

int Lib_YReal_Isregular(const YRealPtr x)
{
	return LibYReal_Isregular(x);
}

int Lib_YReal_Isnormal(const YRealPtr x)
{
	return LibYReal_Isnormal(x);
}

int Lib_YReal_Issubnormal(const YRealPtr x)
{
	return LibYReal_Issubnormal(x);
}

int Lib_YReal_Isunordered(const YRealPtr x, const YRealPtr y)
{
	return LibYReal_Isunordered(x, y);
}







int Lib_YReal_FitsInt32(const YRealPtr x)
{
    return LibYReal_FitsInt32(x);
}

int Lib_YReal_FitsInt64(const YRealPtr x)
{
    return LibYReal_FitsInt64(x);
}

int Lib_YReal_FitsUInt32(const YRealPtr x)
{
    return LibYReal_FitsUInt32(x);
}

int Lib_YReal_FitsUInt64(const YRealPtr x)
{
    return LibYReal_FitsUInt64(x);
}






/* Integer Related Functions  */

void Lib_YReal_Nearbyint(YRealPtr res, const YRealPtr x)
{
    LibYReal_Nearbyint(res, x);
}

void Lib_YReal_Rint(YRealPtr res, const YRealPtr x)
{
    LibYReal_Rint(res, x);
}

long int Lib_YReal_Lrint(const YRealPtr x)
{
    return LibYReal_Lrint(x);
}

long long int Lib_YReal_Llrint(const YRealPtr x)
{
    return LibYReal_Llrint(x);
}

void Lib_YReal_Ceil(YRealPtr res, const YRealPtr x)
{
    LibYReal_Ceil(res, x);
}

void Lib_YReal_Floor(YRealPtr res, const YRealPtr x)
{
    LibYReal_Floor(res, x);
}

void Lib_YReal_Trunc(YRealPtr res, const YRealPtr x)
{
    LibYReal_Trunc(res, x);
}

void Lib_YReal_Round(YRealPtr res, const YRealPtr x)
{
    LibYReal_Round(res, x);
}

long int Lib_YReal_Lround(const YRealPtr x)
{
    return LibYReal_Lround(x);
}

long long int Lib_YReal_Llround(const YRealPtr x)
{
    return LibYReal_Llround(x);
}

int32_t Lib_YReal_ToInt32(const YRealPtr x)
{
    return LibYReal_ToInt32(x);
}

int64_t Lib_YReal_ToInt64(const YRealPtr x)
{
    return LibYReal_ToInt64(x);
}

uint32_t Lib_YReal_ToUInt32(const YRealPtr x)
{
    return LibYReal_ToInt32(x);
}

uint64_t Lib_YReal_ToUInt64(const YRealPtr x)
{
    return LibYReal_ToInt64(x);
}






/* Floating point functions for real numbers */

void Lib_YReal_Copysign(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Copysign(res, x, y);
}

void Lib_YReal_Frexp(YRealPtr res, const YRealPtr x, int* e)
{
    LibYReal_Frexp(res, x, e);
}


void Lib_YReal_Logb(YRealPtr res, const YRealPtr x)
{
    LibYReal_Logb(res, x);
}


int Lib_YReal_Ilogb(const YRealPtr x)
{
    return LibYReal_Ilogb(x);
}




void Lib_YReal_Ldexp(YRealPtr res, const YRealPtr x, const long int e)
{
    LibYReal_Ldexp(res, x, e);
}

void Lib_YReal_Scalbn(YRealPtr res, const YRealPtr x, const int e)
{
    LibYReal_Scalbn(res, x, e);
}


void Lib_YReal_Scalbln(YRealPtr res, const YRealPtr x, const long int e)
{
    LibYReal_Scalbln(res, x, e);
}


void Lib_YReal_Fdim(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Fdim(res, x, y);
}






/* Fraction and Remainder Related Functions  */

void Lib_YReal_Modf(YRealPtr frac, YRealPtr x, const YRealPtr iptr)
{
    LibYReal_Modf(frac, x, iptr);
}

void Lib_YReal_Fmod(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Fmod(res, x, y);
}

void Lib_YReal_Remainder(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Remainder(res, x, y);
}

void Lib_YReal_Remquo(YRealPtr res, const YRealPtr x, const YRealPtr y, int* e)
{
    LibYReal_Remquo(res, x, y, e);
}





/* Functions related to mantissa width and exponent range */

void Lib_YReal_Epsilon(YRealPtr res)
{
    LibYReal_Epsilon(res);
}

void Lib_YReal_Ulp(YRealPtr res, const YRealPtr x)
{
	LibYReal_Ulp(res, x);
}


void Lib_YReal_Max(YRealPtr res)
{
    LibYReal_Max(res);
}

void Lib_YReal_Lowest(YRealPtr res)
{
    LibYReal_Lowest(res);
}

void Lib_YReal_Min(YRealPtr res)
{
    LibYReal_Min(res);
}

void Lib_YReal_Nextabove(YRealPtr res, const YRealPtr x)
{
    LibYReal_Nextabove(res, x);
}

void Lib_YReal_Nextbelow(YRealPtr res, const YRealPtr x)
{
    LibYReal_Nextbelow(res, x);
}

void Lib_YReal_Nexttoward(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Nexttowards(res, x, y);
}








/* Mathematical Constants  */

void Lib_YReal_ConstDegree(YRealPtr res)
{
	LibYReal_Set_Str(res, "1.74532925199432957692369076848861271344287188854172545609719144017100911E-02");
}

void Lib_YReal_ConstPhi(YRealPtr res)
{
	LibYReal_Set_Str(res, "1.61803398874989484820458683436563811772030917980576286213544862270526046E+00");
}

void Lib_YReal_ConstLog2(YRealPtr res)
{
	LibYReal_Set_Str(res, "6.93147180559945309417232121458176568075500134360255254120680009493393622E-01");
}

void Lib_YReal_ConstLog10(YRealPtr res)
{
	LibYReal_Set_Str(res, "2.30258509299404568401799145468436420760110148862877297603332790096757261E+00");
}

void Lib_YReal_ConstPi(YRealPtr res)
{
	LibYReal_Set_Str(res, "3.14159265358979323846264338327950288419716939937510582097494459230781641E+00");
}

void Lib_YReal_ConstE(YRealPtr res)
{
	LibYReal_Set_Str(res, "2.71828182845904523536028747135266249775724709369995957496696762772407663E+00");
}

void Lib_YReal_ConstEulerGamma(YRealPtr res)
{
	LibYReal_Set_Str(res, "5.77215664901532860606512090082402431042159335939923598805767234884867727E-01");
}

void Lib_YReal_ConstApery(YRealPtr res)
{
	LibYReal_Set_Str(res, "1.20205690315959428539973816151144999076498629234049888179227155534183820E+00");
}

void Lib_YReal_ConstCatalan(YRealPtr res)
{
	LibYReal_Set_Str(res, "9.15965594177219015054603514932384110774149374281672134266498119621763020E-01");
}

void Lib_YReal_ConstGlaisher(YRealPtr res)
{
	LibYReal_Set_Str(res, "1.28242712910062263687534256886979172776768892732500119206374002174040631E+00");
}

void Lib_YReal_ConstKhinchin(YRealPtr res)
{
	LibYReal_Set_Str(res, "2.68545200106530644530971483548179569382038229399446295305115234555721886E+00");
}




/* Complex components  */

void Lib_YReal_Fabs(YRealPtr res, const YRealPtr x)
{
    LibYReal_Fabs(res, x);
}

void Lib_YReal_Sign(YRealPtr res, const YRealPtr x)
{
    LibYReal_Sign(res, x);
}





/* Roots and related functions  */

void Lib_YReal_Sqrt(YRealPtr res, const YRealPtr x)
{
    LibYReal_Sqrt(res, x);
}

void Lib_YReal_Sqrt1pm1(YRealPtr res, const YRealPtr x)
{
    LibYReal_Sqrt1pm1(res, x);
}


void Lib_YReal_Rsqrt(YRealPtr res, const YRealPtr x)
{
    LibYReal_Rsqrt(res, x);
}

void Lib_YReal_Cbrt(YRealPtr res, const YRealPtr x)
{
    LibYReal_Cbrt(res, x);
}

void Lib_YReal_Root_Si(YRealPtr res, const YRealPtr x, const int32_t k)
{
    LibYReal_Root_Si(res, x, k);
}




/* Exponential and related functions  */

void Lib_YReal_Exp(YRealPtr res, const YRealPtr x)
{
    LibYReal_Exp(res, x);
}

void Lib_YReal_Exp2(YRealPtr res, const YRealPtr x)
{
    LibYReal_Exp2(res, x);
}

void Lib_YReal_Exp10(YRealPtr res, const YRealPtr x)
{
    LibYReal_Exp10(res, x);
}

void Lib_YReal_Expm1(YRealPtr res, const YRealPtr x)
{
    LibYReal_Expm1(res, x);
}

void Lib_YReal_Exp2m1(YRealPtr res, const YRealPtr x)
{
    LibYReal_Exp2m1(res, x);
}

void Lib_YReal_Exp10m1(YRealPtr res, const YRealPtr x)
{
    LibYReal_Exp10m1(res, x);
}



/* Logarithms and related functions  */


void Lib_YReal_Log(YRealPtr res, const YRealPtr x)
{
    LibYReal_Log(res, x);
}

void Lib_YReal_Log2(YRealPtr res, const YRealPtr x)
{
    LibYReal_Log2(res, x);
}

void Lib_YReal_Log10(YRealPtr res, const YRealPtr x)
{
    LibYReal_Log10(res, x);
}

void Lib_YReal_Log1p(YRealPtr res, const YRealPtr x)
{
    LibYReal_Log1p(res, x);
}

void Lib_YReal_Log2p1(YRealPtr res, const YRealPtr x)
{
    LibYReal_Log2p1(res, x);
}

void Lib_YReal_Log10p1(YRealPtr res, const YRealPtr x)
{
    LibYReal_Log10p1(res, x);
}



/* Power functions and roots  */

void Lib_YReal_Square(YRealPtr res, const YRealPtr x)
{
    LibYReal_Square(res, x);
}

void Lib_YReal_Cube(YRealPtr res, const YRealPtr x)
{
    LibYReal_Cube(res, x);
}


void Lib_YReal_Hypot(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Hypot(res, x, y);
}

void Lib_YReal_Pow(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Pow(res, x, y);
}

void Lib_YReal_Powm1(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Powm1(res, x, y);
}


void Lib_YReal_Pow1p(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Pow1p(res, x, y);
}

void Lib_YReal_Pow1pm1(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Pow1pm1(res, x, y);
}


void Lib_YReal_Pow_Si(YRealPtr res, const YRealPtr x, const int32_t k)
{
    LibYReal_Pow_Si(res, x, k);
}


void Lib_YReal_Compound_Si(YRealPtr res, const YRealPtr x, const int32_t k)
{
    LibYReal_Compound_Si(res, x, k);
}



/* Trigonometric functions  */

void Lib_YReal_Sin(YRealPtr res, const YRealPtr x)
{
    LibYReal_Sin(res, x);
}

void Lib_YReal_Cos(YRealPtr res, const YRealPtr x)
{
    LibYReal_Cos(res, x);
}

void Lib_YReal_Tan(YRealPtr res, const YRealPtr x)
{
    LibYReal_Tan(res, x);
}

void Lib_YReal_Csc(YRealPtr res, const YRealPtr x)
{
    LibYReal_Csc(res, x);
}

void Lib_YReal_Sec(YRealPtr res, const YRealPtr x)
{
    LibYReal_Sec(res, x);
}

void Lib_YReal_Cot(YRealPtr res, const YRealPtr x)
{
    LibYReal_Cot(res, x);
}


void Lib_YReal_SinPi(YRealPtr res, const YRealPtr x)
{
    LibYReal_SinPi(res, x);
}

void Lib_YReal_CosPi(YRealPtr res, const YRealPtr x)
{
    LibYReal_CosPi(res, x);
}

void Lib_YReal_TanPi(YRealPtr res, const YRealPtr x)
{
    LibYReal_TanPi(res, x);
}

void Lib_YReal_CscPi(YRealPtr res, const YRealPtr x)
{
    LibYReal_CscPi(res, x);
}

void Lib_YReal_SecPi(YRealPtr res, const YRealPtr x)
{
    LibYReal_SecPi(res, x);
}

void Lib_YReal_CotPi(YRealPtr res, const YRealPtr x)
{
    LibYReal_CotPi(res, x);
}






/* Hyperbolic functions  */

void Lib_YReal_Sinh(YRealPtr res, const YRealPtr x)
{
    LibYReal_Sinh(res, x);
}

void Lib_YReal_Cosh(YRealPtr res, const YRealPtr x)
{
    LibYReal_Cosh(res, x);
}

void Lib_YReal_Tanh(YRealPtr res, const YRealPtr x)
{
    LibYReal_Tanh(res, x);
}

void Lib_YReal_Csch(YRealPtr res, const YRealPtr x)
{
    LibYReal_Csch(res, x);
}

void Lib_YReal_Sech(YRealPtr res, const YRealPtr x)
{
    LibYReal_Sech(res, x);
}

void Lib_YReal_Coth(YRealPtr res, const YRealPtr x)
{
    LibYReal_Coth(res, x);
}


/* Inverse trigonometric functions  */

void Lib_YReal_Asin(YRealPtr res, const YRealPtr x)
{
    LibYReal_Asin(res, x);
}

void Lib_YReal_Acos(YRealPtr res, const YRealPtr x)
{
    LibYReal_Acos(res, x);
}

void Lib_YReal_Atan(YRealPtr res, const YRealPtr x)
{
    LibYReal_Atan(res, x);
}

void Lib_YReal_Atan2(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_Atan2(res, x, y);
}

void Lib_YReal_Acsc(YRealPtr res, const YRealPtr x)
{
    LibYReal_Acsc(res, x);
}

void Lib_YReal_Asec(YRealPtr res, const YRealPtr x)
{
    LibYReal_Asec(res, x);
}

void Lib_YReal_Acot(YRealPtr res, const YRealPtr x)
{
    LibYReal_Acot(res, x);
}



/* Inverse hyperbolic functions  */

void Lib_YReal_Asinh(YRealPtr res, const YRealPtr x)
{
    LibYReal_Asinh(res, x);
}

void Lib_YReal_Acosh(YRealPtr res, const YRealPtr x)
{
    LibYReal_Acosh(res, x);
}

void Lib_YReal_Atanh(YRealPtr res, const YRealPtr x)
{
    LibYReal_Atanh(res, x);
}

void Lib_YReal_Acsch(YRealPtr res, const YRealPtr x)
{
    LibYReal_Acsch(res, x);
}

void Lib_YReal_Asech(YRealPtr res, const YRealPtr x)
{
    LibYReal_Asech(res, x);
}

void Lib_YReal_Acoth(YRealPtr res, const YRealPtr x)
{
    LibYReal_Acoth(res, x);
}



/* Special functions  */

void Lib_YReal_Erf(YRealPtr res, const YRealPtr x)
{
    LibYReal_Erf(res, x);
}

void Lib_YReal_Erfc(YRealPtr res, const YRealPtr x)
{
    LibYReal_Erfc(res, x);
}

void Lib_YReal_Tgamma(YRealPtr res, const YRealPtr x)
{
    LibYReal_Tgamma(res, x);
}

void Lib_YReal_Lgamma(YRealPtr res, const YRealPtr x)
{
    LibYReal_Lgamma(res, x);
}

void Lib_YReal_BesselJ0(YRealPtr res, const YRealPtr x)
{
    LibYReal_J0(res, x);
}

void Lib_YReal_BesselJ1(YRealPtr res, const YRealPtr x)
{
    LibYReal_J1(res, x);
}

void Lib_YReal_BesselJn(YRealPtr res, const int n, const YRealPtr x)
{
    LibYReal_Jn(res, n, x);
}

void Lib_YReal_BesselY0(YRealPtr res, const YRealPtr x)
{
    LibYReal_Y0(res, x);
}

void Lib_YReal_BesselY1(YRealPtr res, const YRealPtr x)
{
    LibYReal_Y1(res, x);
}

void Lib_YReal_BesselYn(YRealPtr res, const int n, const YRealPtr x)
{
    LibYReal_Yn(res, n, x);
}







/** ********************** Complex Basic Functions, YCplx ******************************** **/


void Lib_Eigen_YCplx_GetCoeff(YCplxPtr result, long row, long col, mpNumMatrixPtr SourceMatrix)
{
//	MpdcPtr res; res = Lib_Mpdc_Init_Func();
//	MpdPtr res_re; res_re = Lib_Mpd_Init_Func();
//	MpdPtr res_im; res_im = Lib_Mpd_Init_Func();
//
//	YRealPtr result_re; result_re = Lib_YReal_Init_Func();
//	YRealPtr result_im; result_im = Lib_YReal_Init_Func();
//
//    Lib_Eigen_MpAnyCplx_GetCoeff(res, row, col, SourceMatrix);
//
//    Lib_Mpdc_Real(res_re, res);
//    Lib_Mpdc_Imag(res_im, res);
//
//    Lib_YReal_Set_Mpd(result_re, res_re);
//    Lib_YReal_Set_Mpd(result_im, res_im);
//
//    Lib_YCplx_Set2(result, result_re, result_im);
//
//    Lib_YReal_Clear(result_re);
//    Lib_YReal_Clear(result_im);
//
//    Lib_Mpd_Clear(res_re);
//    Lib_Mpd_Clear(res_im);
//	Lib_Mpdc_Clear(res);
}



void Lib_Eigen_YCplx_SetCoeff(mpNumMatrixPtr result, YCplxPtr source, long row, long col)
{
//	MpdcPtr src; src = Lib_Mpdc_Init_Func();
//	MpdPtr src_re; src_re = Lib_Mpd_Init_Func();
//	MpdPtr src_im; src_im = Lib_Mpd_Init_Func();
//
//	YRealPtr source_re; source_re = Lib_YReal_Init_Func();
//	YRealPtr source_im; source_im = Lib_YReal_Init_Func();
//
//	Lib_YCplx_Real(source_re, source);
//    Lib_YCplx_Imag(source_im, source);
//
//    Lib_Mpd_Set_YReal(src_re, source_re);
//    Lib_Mpd_Set_YReal(src_im, source_im);
//    Lib_Mpdc_Set2(src, src_re, src_im);
//
//    Lib_Eigen_MpAnyCplx_SetCoeff(result, src, row, col);
//
//    Lib_YReal_Clear(source_re);
//    Lib_YReal_Clear(source_im);
//
//    Lib_Mpd_Clear(src_re);
//    Lib_Mpd_Clear(src_im);
//	Lib_Mpdc_Clear(src);
}




YCplxPtr Lib_YCplx_Init_Func()
{
    return LibYCplx_Init_Func();
}


void Lib_YCplx_Clear(YCplxPtr x)
{
    LibYCplx_Clear(x);
}




/* Input and output  */


void Lib_YCplx_Set(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Set(res, x);
}






/* Operator overloading vs raw arithmetic and comparisons  */

void Lib_YCplx_Neg(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Neg(res, x);
}

void Lib_YCplx_Add(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    LibYCplx_Add(res, x, y);
}

void Lib_YCplx_Sub(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    LibYCplx_Sub(res, x, y);
}

void Lib_YCplx_Mul(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    LibYCplx_Mul(res, x, y);
}

void Lib_YCplx_Div(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    LibYCplx_Div(res, x, y);
}


void Lib_YCplx_Add_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y)
{
    LibYCplx_Add_YReal(res, x, y);
}

void Lib_YCplx_Sub_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y)
{
    LibYCplx_Sub_YReal(res, x, y);
}

void Lib_YCplx_YReal_Sub(YCplxPtr res, const YCplxPtr y, const YRealPtr x)
{
    LibYCplx_YReal_Sub(res, y, x);
}


void Lib_YCplx_Mul_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y)
{
    LibYCplx_Mul_YReal(res, x, y);
}

void Lib_YCplx_Div_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y)
{
    LibYCplx_Div_YReal(res, x, y);
}


void Lib_YCplx_YReal_Div(YCplxPtr res, const YCplxPtr y, const YRealPtr x)
{
    LibYCplx_YReal_Div(res, y, x);
}


void Lib_YCplx_Add_D(YCplxPtr res, const YCplxPtr x, const double y)
{
    LibYCplx_Add_D(res, x, y);
}

void Lib_YCplx_Sub_D(YCplxPtr res, const YCplxPtr x, const double y)
{
    LibYCplx_Sub_D(res, x, y);
}

void Lib_YCplx_D_Sub(YCplxPtr res, const YCplxPtr y, const double x)
{
    LibYCplx_D_Sub(res, y, x);
}

void Lib_YCplx_Mul_D(YCplxPtr res, const YCplxPtr x, const double y)
{
    LibYCplx_Mul_D(res, x, y);
}

void Lib_YCplx_Div_D(YCplxPtr res, const YCplxPtr x, const double y)
{
    LibYCplx_Div_D(res, x, y);
}


void Lib_YCplx_D_Div(YCplxPtr res, const YCplxPtr y, const double x)
{
    LibYCplx_D_Div(res, y, x);
}

void Lib_YCplx_Add_Si(YCplxPtr res, const YCplxPtr x, const int32_t y)
{
    LibYCplx_Add_Si(res, x, y);
}

void Lib_YCplx_Sub_Si(YCplxPtr res, const YCplxPtr x, const int32_t y)
{
    LibYCplx_Sub_Si(res, x, y);
}

void Lib_YCplx_Si_Sub(YCplxPtr res, const YCplxPtr y, const int32_t x)
{
    LibYCplx_Si_Sub(res, y, x);
}

void Lib_YCplx_Mul_Si(YCplxPtr res, const YCplxPtr x, const int32_t y)
{
    LibYCplx_Mul_Si(res, x, y);
}



/* Missing: Inv */



void Lib_YCplx_Div_Si(YCplxPtr res, const YCplxPtr x, const int32_t y)
{
    LibYCplx_Div_Si(res, x, y);
}

void Lib_YCplx_Si_Div(YCplxPtr res, const YCplxPtr y, const int32_t x)
{
    LibYCplx_Si_Div(res, y, x);
}
















/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void Lib_YCplx_Set_Real(YCplxPtr res, const YRealPtr re)
{
    LibYCplx_Set_Real(res, re);
}

void Lib_YCplx_Set2(YCplxPtr res, const YRealPtr re, const YRealPtr im)
{
    LibYCplx_Set2(res, re, im);
}

void Lib_YCplx_Abs(YRealPtr res, const YCplxPtr x)
{
    LibYCplx_Abs(res, x);
}

void Lib_YCplx_Norm(YRealPtr res, const YCplxPtr x)
{
    LibYCplx_Abs(res, x);
}

void Lib_YCplx_Arg(YRealPtr res, const YCplxPtr x)
{
    LibYCplx_Arg(res, x);
}

void Lib_YCplx_Imag(YRealPtr res, const YCplxPtr x)
{
    LibYCplx_Imag(res, x);
}

void Lib_YCplx_Real(YRealPtr res, const YCplxPtr x)
{
    LibYCplx_Real(res, x);
}

void Lib_YCplx_Conj(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Conj(res, x);
}

void Lib_YCplx_Proj(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Proj(res, x);
}





/* Roots  */

void Lib_YCplx_Sqrt(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Sqrt(res, x);
}

void Lib_YCplx_Sqrt1pm1(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Sqrt1pm1(res, x);
}

void Lib_YCplx_Rsqrt(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Rsqrt(res, x);
}

void Lib_YCplx_Cbrt(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Cbrt(res, x);
}

void Lib_YCplx_Root_Si(YCplxPtr res, const YCplxPtr x, const int32_t k)
{
    LibYCplx_Root_Si(res, x, k);
}




/* Exponential and related functions  */

void Lib_YCplx_Exp(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Exp(res, x);
}


void Lib_YCplx_Exp2(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Exp2(res, x);
}

void Lib_YCplx_Exp10(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Exp10(res, x);
}


void Lib_YCplx_Expm1(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Expm1(res, x);
}

void Lib_YCplx_Exp2m1(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Exp2m1(res, x);
}

void Lib_YCplx_Exp10m1(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Exp10m1(res, x);
}



/* Logarithms and related functions  */

void Lib_YCplx_Log(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Log(res, x);
}

void Lib_YCplx_Log2(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Log2(res, x);
}

void Lib_YCplx_Log10(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Log10(res, x);
}

void Lib_YCplx_Log1p(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Log1p(res, x);
}

void Lib_YCplx_Log2p1(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Log2p1(res, x);
}

void Lib_YCplx_Log10p1(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Log10p1(res, x);
}




/* Power functions and roots  */

void Lib_YCplx_Square(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Square(res, x);
}

void Lib_YCplx_Cube(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Cube(res, x);
}

void Lib_YCplx_Pow(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    LibYCplx_Pow(res, x, y);
}


void Lib_YCplx_Powm1(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    LibYCplx_Powm1(res, x, y);
}

void Lib_YCplx_Pow1p(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    LibYCplx_Pow1p(res, x, y);
}

void Lib_YCplx_Pow1pm1(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    LibYCplx_Pow1pm1(res, x, y);
}


void Lib_YCplx_Pow_Si(YCplxPtr res, const YCplxPtr x, const int32_t k)
{
    LibYCplx_Pow_Si(res, x, k);
}

void Lib_YCplx_Compound_Si(YCplxPtr res, const YCplxPtr x, const int32_t k)
{
    LibYCplx_Compound_Si(res, x, k);
}





/* Trigonometric functions  */

void Lib_YCplx_Sin(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Sin(res, x);
}

void Lib_YCplx_Cos(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Cos(res, x);
}

void Lib_YCplx_Tan(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Tan(res, x);
}


void Lib_YCplx_Csc(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Csc(res, x);
}

void Lib_YCplx_Sec(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Sec(res, x);
}

void Lib_YCplx_Cot(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Cot(res, x);
}


void Lib_YCplx_SinPi(YCplxPtr res, const YCplxPtr x)
{
    //LibYCplx_SinPi(res, x);
}

void Lib_YCplx_CosPi(YCplxPtr res, const YCplxPtr x)
{
    //LibYCplx_CosPi(res, x);
}

void Lib_YCplx_TanPi(YCplxPtr res, const YCplxPtr x)
{
    //LibYCplx_TanPi(res, x);
}




/* Hyperbolic functions  */

void Lib_YCplx_Sinh(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Sinh(res, x);
}

void Lib_YCplx_Cosh(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Cosh(res, x);
}

void Lib_YCplx_Tanh(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Tanh(res, x);
}


void Lib_YCplx_Csch(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Csch(res, x);
}

void Lib_YCplx_Sech(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Sech(res, x);
}

void Lib_YCplx_Coth(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Coth(res, x);
}



/* Inverse trigonometric functions  */

void Lib_YCplx_Asin(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Asin(res, x);
}

void Lib_YCplx_Acos(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Acos(res, x);
}

void Lib_YCplx_Atan(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Atan(res, x);
}


void Lib_YCplx_Acsc(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Acsc(res, x);
}

void Lib_YCplx_Asec(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Asec(res, x);
}

void Lib_YCplx_Acot(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Acot(res, x);
}




/* Inverse hyperbolic functions  */

void Lib_YCplx_Asinh(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Asinh(res, x);
}

void Lib_YCplx_Acosh(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Acosh(res, x);
}

void Lib_YCplx_Atanh(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Atanh(res, x);
}


void Lib_YCplx_Acsch(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Acsch(res, x);
}

void Lib_YCplx_Asech(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Asech(res, x);
}

void Lib_YCplx_Acoth(YCplxPtr res, const YCplxPtr x)
{
    LibYCplx_Acoth(res, x);
}




















//*********************** Boost Special functions , YReal **********************************



void Lib_YReal_BernoulliB2n(YRealPtr res, const int n)
{
    LibYReal_BernoulliB2n(res, n);
}



void Lib_YReal_TangentT2n(YRealPtr res, const int n)
{
    LibYReal_TangentT2n(res, n);
}



void Lib_YReal_Sqrt1pm1_Boost(YRealPtr res, const YRealPtr x)
{
    LibYReal_Sqrt1pm1(res, x);
}



void Lib_YReal_SinPi_Boost(YRealPtr res, const YRealPtr x)
{
    LibYReal_SinPi(res, x);
}



void Lib_YReal_CosPi_Boost(YRealPtr res, const YRealPtr x)
{
    LibYReal_CosPi(res, x);
}



void Lib_YReal_SincPi(YRealPtr res, const YRealPtr x)
{
    LibYReal_SincPi(res, x);
}



void Lib_YReal_SinhcPi(YRealPtr res, const YRealPtr x)
{
    LibYReal_SinhcPi(res, x);
}



void Lib_YReal_Tgamma_(YRealPtr res, const YRealPtr x)
{
    LibYReal_Tgamma_(res, x);
}


void Lib_YReal_Tgamma1pm1(YRealPtr res, const YRealPtr x)
{
    LibYReal_Tgamma1pm1(res, x);
}



void Lib_YReal_Lgamma_(YRealPtr res, const YRealPtr x)
{
    LibYReal_Lgamma_(res, x);
}



void Lib_YReal_Digamma(YRealPtr res, const YRealPtr x)
{
    LibYReal_Digamma(res, x);
}



void Lib_YReal_Trigamma(YRealPtr res, const YRealPtr x)
{
    LibYReal_Trigamma(res, x);
}



void Lib_YReal_Factorial(YRealPtr res, const YRealPtr x)
{
    LibYReal_Factorial(res, x);
}



void Lib_YReal_DoubleFactorial(YRealPtr res, const YRealPtr x)
{
    LibYReal_DoubleFactorial(res, x);
}





void Lib_YReal_Erf_(YRealPtr res, const YRealPtr x)
{
    LibYReal_Erf_(res, x);
}



void Lib_YReal_Erfc_(YRealPtr res, const YRealPtr x)
{
    LibYReal_Erfc_(res, x);
}



void Lib_YReal_Erf_inv(YRealPtr res, const YRealPtr x)
{
    LibYReal_Erf_inv(res, x);
}



void Lib_YReal_Erfc_inv(YRealPtr res, const YRealPtr x)
{
    LibYReal_Erfc_inv(res, x);
}



void Lib_YReal_AiryAi(YRealPtr res, const YRealPtr x)
{
    LibYReal_AiryAi(res, x);
}



void Lib_YReal_AiryBi(YRealPtr res, const YRealPtr x)
{
    LibYReal_AiryBi(res, x);
}



void Lib_YReal_AiryAiPrime(YRealPtr res, const YRealPtr x)
{
    LibYReal_AiryAiPrime(res, x);
}



void Lib_YReal_AiryBiPrime(YRealPtr res, const YRealPtr x)
{
    LibYReal_AiryBiPrime(res, x);
}



void Lib_YReal_Aizero(YRealPtr res, const int n)
{
    LibYReal_Aizero(res, n);
}



void Lib_YReal_Bizero(YRealPtr res, const int n)
{
    LibYReal_Bizero(res, n);
}



void Lib_YReal_Ellint_1_K(YRealPtr res, const YRealPtr x)
{
    LibYReal_Ellint_1_K(res, x);
}



void Lib_YReal_Ellint_2_K(YRealPtr res, const YRealPtr x)
{
    LibYReal_Ellint_2_K(res, x);
}



void Lib_YReal_Zeta(YRealPtr res, const YRealPtr x)
{
    LibYReal_Zeta(res, x);
}



void Lib_YReal_Ei(YRealPtr res, const YRealPtr x)
{
    LibYReal_Ei(res, x);
}



void Lib_YReal_LambertW0(YRealPtr res, const YRealPtr x)
{
    LibYReal_LambertW0(res, x);
}


void Lib_YReal_LambertWm1(YRealPtr res, const YRealPtr x)
{
    LibYReal_LambertWm1(res, x);
}



void Lib_YReal_LambertW0Prime(YRealPtr res, const YRealPtr x)
{
    LibYReal_LambertW0Prime(res, x);
}


void Lib_YReal_LambertWm1Prime(YRealPtr res, const YRealPtr x)
{
    LibYReal_LambertWm1Prime(res, x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void Lib_YReal_Powm1_Boost(YRealPtr res, const YRealPtr a, const YRealPtr b)
{
    LibYReal_Powm1(res, a, b);
}



void Lib_YReal_TgammaRatio(YRealPtr res, const YRealPtr a, const YRealPtr b)
{
    LibYReal_TgammaRatio(res, a, b);
}



void Lib_YReal_TgammaDeltaRatio(YRealPtr res, const YRealPtr a, const YRealPtr b)
{
    LibYReal_TgammaDeltaRatio(res, a, b);
}



void Lib_YReal_Binomial(YRealPtr res, const YRealPtr n, const YRealPtr k)
{
    LibYReal_Binomial(res, n, k);
}

void Lib_YReal_RisingFactorial(YRealPtr res, const YRealPtr x, const YRealPtr n)
{
    LibYReal_RisingFactorial(res, x, n);
}




void Lib_YReal_FallingFactorial(YRealPtr res, const YRealPtr x, const YRealPtr n)
{
    LibYReal_FallingFactorial(res, x, n);
}




void Lib_YReal_BesselJ(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
    LibYReal_BesselJ(res, v, x);
}



void Lib_YReal_BesselY(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
    LibYReal_BesselY(res, v, x);
}



void Lib_YReal_BesselI(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
    LibYReal_BesselI(res, v, x);
}



void Lib_YReal_BesselK(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
    LibYReal_BesselK(res, v, x);
}



void Lib_YReal_SphBessel(YRealPtr res, const unsigned v, const YRealPtr x)
{
    LibYReal_SphBessel(res, v, x);
}



void Lib_YReal_SphNeumann(YRealPtr res, const unsigned v, const YRealPtr x)
{
    LibYReal_SphNeumann(res, v, x);
}





void Lib_YReal_BesselJPrime(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
    LibYReal_BesselJPrime(res, v, x);
}



void Lib_YReal_BesselYPrime(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
    LibYReal_BesselYPrime(res, v, x);
}



void Lib_YReal_BesselIPrime(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
    LibYReal_BesselIPrime(res, v, x);
}



void Lib_YReal_BesselKPrime(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
    LibYReal_BesselKPrime(res, v, x);
}



void Lib_YReal_SphBesselPrime(YRealPtr res, const unsigned v, const YRealPtr x)
{
    LibYReal_SphBesselPrime(res, v, x);
}



void Lib_YReal_SphNeumannPrime(YRealPtr res, const unsigned v, const YRealPtr x)
{
    LibYReal_SphNeumannPrime(res, v, x);
}





void Lib_YReal_BesselJZero(YRealPtr res, const YRealPtr v, const int m)
{
    LibYReal_BesselJZero(res, v, m);
}



void Lib_YReal_BesselYZero(YRealPtr res, const YRealPtr v, const int m)
{
    LibYReal_BesselYZero(res, v, m);
}





void Lib_YReal_GammaP(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
    LibYReal_GammaP(res, a, x);
}


void Lib_YReal_GammaQ(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
    LibYReal_GammaQ(res, a, x);
}


void Lib_YReal_TgammaLower(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
    LibYReal_TgammaLower(res, a, x);
}


void Lib_YReal_TgammaUpper(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
    LibYReal_TgammaUpper(res, a, x);
}




void Lib_YReal_GammaPInv(YRealPtr res, const YRealPtr a, const YRealPtr p)
{
    LibYReal_GammaPInv(res, a, p);
}


void Lib_YReal_GammaQInv(YRealPtr res, const YRealPtr a, const YRealPtr q)
{
    LibYReal_GammaQInv(res, a, q);
}


void Lib_YReal_GammaPInva(YRealPtr res, const YRealPtr x, const YRealPtr p)
{
    LibYReal_GammaPInva(res, x, p);
}


void Lib_YReal_GammaQInva(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
    LibYReal_GammaQInva(res, x, q);
}



void Lib_YReal_GammaPDerivative(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
    LibYReal_GammaPDerivative(res, a, x);
}


void Lib_YReal_Beta(YRealPtr res, const YRealPtr a, const YRealPtr b)
{
    LibYReal_Beta(res, a, b);
}









void Lib_YReal_LegendreP(YRealPtr res, int n, const YRealPtr x)
{
    LibYReal_LegendreP(res, n, x);
}



void Lib_YReal_LegendreQ(YRealPtr res, int n, const YRealPtr x)
{
    LibYReal_LegendreQ(res, n, x);
}



void Lib_YReal_Laguerre(YRealPtr res, int n, const YRealPtr x)
{
    LibYReal_Laguerre(res, n, x);
}



void Lib_YReal_Hermite(YRealPtr res, int n, const YRealPtr x)
{
    LibYReal_Hermite(res, n, x);
}



void Lib_YReal_ChebyshevT(YRealPtr res, int n, const YRealPtr x)
{
    LibYReal_ChebyshevT(res, n, x);
}


void Lib_YReal_ChebyshevU(YRealPtr res, int n, const YRealPtr x)
{
    LibYReal_ChebyshevU(res, n, x);
}



void Lib_YReal_Polygamma(YRealPtr res, int n, const YRealPtr x)
{
    LibYReal_Polygamma(res, n, x);
}





void Lib_YReal_EllintRC(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
    LibYReal_EllintRC(res, x, y);
}


void Lib_YReal_Ellint1F(YRealPtr res, const YRealPtr k, const YRealPtr phi)
{
    LibYReal_Ellint1F(res, k, phi);
}


void Lib_YReal_Ellint2F(YRealPtr res, const YRealPtr k, const YRealPtr phi)
{
    LibYReal_Ellint2F(res, k, phi);
}


void Lib_YReal_Ellint3K(YRealPtr res, const YRealPtr k, const YRealPtr n)
{
    LibYReal_Ellint3K(res, k, n);
}




void Lib_YReal_JacobiCD(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiCD(res, k, u);
}


void Lib_YReal_JacobiCN(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiCN(res, k, u);
}


void Lib_YReal_JacobiCS(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiCS(res, k, u);
}


void Lib_YReal_JacobiDC(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiDC(res, k, u);
}


void Lib_YReal_JacobiDN(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiDN(res, k, u);
}


void Lib_YReal_JacobiDS(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiDS(res, k, u);
}


void Lib_YReal_JacobiNC(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiNC(res, k, u);
}


void Lib_YReal_JacobiND(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiND(res, k, u);
}


void Lib_YReal_JacobiNS(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiNS(res, k, u);
}


void Lib_YReal_JacobiSC(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiSC(res, k, u);
}


void Lib_YReal_JacobiSD(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiSD(res, k, u);
}


void Lib_YReal_JacobiSN(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
    LibYReal_JacobiSN(res, k, u);
}



void Lib_YReal_expint(YRealPtr res, const unsigned n, const YRealPtr x)
{
    LibYReal_expint(res, n, x);
}




void Lib_YReal_OwenT(YRealPtr res, const YRealPtr h, const YRealPtr a)
{
    LibYReal_OwenT(res, h, a);
}





void Lib_YReal_IBeta(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
    LibYReal_IBeta(res, a, b, x);
}


void Lib_YReal_IBetac(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
    LibYReal_IBetac(res, a, b, x);
}


void Lib_YReal_IBetaNonNormalized(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
    LibYReal_IBetaNonNormalized(res, a, b, x);
}


void Lib_YReal_IBetacNonNormalized(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
    LibYReal_IBetacNonNormalized(res, a, b, x);
}


void Lib_YReal_IBetaInv(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr p)
{
    LibYReal_IBetaInv(res, a, b, p);
}


void Lib_YReal_IBetacInv(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr q)
{
    LibYReal_IBetacInv(res, a, b, q);
}


void Lib_YReal_IBetaInva(YRealPtr res, const YRealPtr b, const YRealPtr x, const YRealPtr p)
{
    LibYReal_IBetaInva(res, b, x, p);
}


void Lib_YReal_IBetacInva(YRealPtr res, const YRealPtr b, const YRealPtr x, const YRealPtr q)
{
    LibYReal_IBetacInva(res, b, x, q);
}


void Lib_YReal_IBetaInvb(YRealPtr res, const YRealPtr a, const YRealPtr x, const YRealPtr p)
{
    LibYReal_IBetaInvb(res, a, x, p);
}


void Lib_YReal_IBetacInvb(YRealPtr res, const YRealPtr a, const YRealPtr x, const YRealPtr q)
{
    LibYReal_IBetacInvb(res, a, x, q);
}


void Lib_YReal_IBetaDerivative(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
    LibYReal_IBetaDerivative(res, a, b, x);
}




void Lib_YReal_LegendrePM(YRealPtr res, const int n, const int m, const YRealPtr x)
{
    LibYReal_LegendrePM(res, n, m, x);
}



void Lib_YReal_LaguerreM(YRealPtr res, const int n, const int m, const YRealPtr x)
{
    LibYReal_LaguerreM(res, n, m, x);
}





void Lib_YReal_EllipticRF(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z)
{
    LibYReal_EllipticRF(res, x, y, z);
}



void Lib_YReal_EllipticRD(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z)
{
    LibYReal_EllipticRD(res, x, y, z);
}



void Lib_YReal_Ellint3F(YRealPtr res, const YRealPtr k, const YRealPtr n, const YRealPtr phi)
{
    LibYReal_Ellint3F(res, k, n, phi);
}




void Lib_YReal_SphericalHarmonicR(YRealPtr res, const int n, const int m, const YRealPtr theta, const YRealPtr phi)
{
    LibYReal_SphericalHarmonicR(res, n, m, theta, phi);
}


void Lib_YReal_SphericalHarmonicI(YRealPtr res, const int n, const int m, const YRealPtr theta, const YRealPtr phi)
{
    LibYReal_SphericalHarmonicI(res, n, m, theta, phi);
}


void Lib_YReal_EllipticRJ(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z, const YRealPtr p)
{
    LibYReal_EllipticRJ(res, x, y, z, p);
}


// Hypergeometric and Theta Functions




void Lib_YReal_Hypergeo0F1(YRealPtr res, const YRealPtr b, const YRealPtr x)
{
    LibYReal_Hypergeo0F1(res, b, x);
}



void Lib_YReal_Hypergeo1F1(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
    LibYReal_Hypergeo1F1(res, a, b, x);
}



void Lib_YReal_Hypergeo1F1r(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
    LibYReal_Hypergeo1F1r(res, a, b, x);
}



void Lib_YReal_LogHypergeo1F1(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
    LibYReal_LogHypergeo1F1(res, a, b, x);
}





void Lib_YReal_JacobiTheta1(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
    LibYReal_JacobiTheta1(res, x, q);
}


void Lib_YReal_JacobiTheta2(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
    LibYReal_JacobiTheta2(res, x, q);
}


void Lib_YReal_JacobiTheta3(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
    LibYReal_JacobiTheta3(res, x, q);
}


void Lib_YReal_JacobiTheta4(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
    LibYReal_JacobiTheta4(res, x, q);
}






//***********************  Boost Distributions, YReal  **********************************


void Lib_YReal_ArcsineDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b)
{
    LibYReal_ArcsineDist(Target, res, xqp, a, b);
}



void Lib_YReal_BernoulliDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr p)
{
    LibYReal_BernoulliDist(Target, res, xqp, p);
}



void Lib_YReal_BetaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b)
{
    LibYReal_BetaDist(Target, res, xqp, a, b);
}



void Lib_YReal_BinomialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr n, YRealPtr p)
{
    LibYReal_BinomialDist(Target, res, xqp, n, p);
}



void Lib_YReal_CauchyDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    LibYReal_CauchyDist(Target, res, xqp, location, scale);
}



void Lib_YReal_Chi2Dist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu)
{
    LibYReal_Chi2Dist(Target, res, xqp, nu);
}



void Lib_YReal_ExponentialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lambda)
{
    LibYReal_ExponentialDist(Target, res, xqp, lambda);
}



void Lib_YReal_ExtremeValueDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    LibYReal_ExtremeValueDist(Target, res, xqp, location, scale);
}



void Lib_YReal_FisherFDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mu, YRealPtr nu)
{
    LibYReal_FisherFDist(Target, res, xqp, mu, nu);
}



void Lib_YReal_GammaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale)
{
    LibYReal_GammaDist(Target, res, xqp, shape, scale);
}



void Lib_YReal_GeometricDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr p)
{
    LibYReal_GeometricDist(Target, res, xqp, p);
}



void Lib_YReal_HypergeometricDist(long Target, YRealPtr res, YRealPtr xqp, unsigned r, unsigned n, unsigned N)
{
    LibYReal_HypergeometricDist(Target, res, xqp, r, n, N);
}



void Lib_YReal_InverseChi2Dist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr df, YRealPtr scale)
{
    LibYReal_InverseChi2Dist(Target, res, xqp, df, scale);
}



void Lib_YReal_InverseGammaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale)
{
    LibYReal_InverseGammaDist(Target, res, xqp, shape, scale);
}



void Lib_YReal_WaldDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr scale)
{
    LibYReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
}



void Lib_YReal_LaplaceDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    LibYReal_LaplaceDist(Target, res, xqp, location, scale);
}



void Lib_YReal_LogisticDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    LibYReal_LogisticDist(Target, res, xqp, location, scale);
}



void Lib_YReal_LognormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    LibYReal_LognormalDist(Target, res, xqp, location, scale);
}



void Lib_YReal_NegBinomialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr n, YRealPtr p)
{
    LibYReal_NegBinomialDist(Target, res, xqp, n, p);
}


void Lib_YReal_Chi2NcDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu, YRealPtr nc)
{
    LibYReal_Chi2NCDist(Target, res, xqp, nu, nc);
}


void Lib_YReal_StudentTNcDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu, YRealPtr delta)
{
    LibYReal_StudentTNCDist(Target, res, xqp, nu, delta);
}



void Lib_YReal_FisherNcDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mu, YRealPtr nu, YRealPtr nc)
{
    LibYReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
}



void Lib_YReal_BetaNcDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b, YRealPtr nc)
{
    LibYReal_BetaNCDist(Target, res, xqp, a, b, nc);
}



void Lib_YReal_NormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr stdev)
{
    LibYReal_NormalDist(Target, res, xqp, mean_, stdev);
}



void Lib_YReal_ParetoDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale)
{
    LibYReal_ParetoDist(Target, res, xqp, shape, scale);
}



void Lib_YReal_PoissonDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu)
{
    LibYReal_PoissonDist(Target, res, xqp, nu);
}



void Lib_YReal_RayleighDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu)
{
    LibYReal_RayleighDist(Target, res, xqp, nu);
}



void Lib_YReal_SkewNormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr scale, YRealPtr shape)
{
    LibYReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
}



void Lib_YReal_StudentTDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu)
{
    LibYReal_StudentTDist(Target, res, xqp, nu);
}



void Lib_YReal_TriangularDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lower, YRealPtr mode_, YRealPtr upper)
{
    LibYReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
}



void Lib_YReal_WeibullDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale)
{
    LibYReal_WeibullDist(Target, res, xqp, shape, scale);
}



void Lib_YReal_UniformDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lower, YRealPtr upper)
{
    LibYReal_UniformDist(Target, res, xqp, lower, upper);
}





//*********************** Boost Numerical Calculus, YReal **********************************




void Lib_YReal_BracketRoot(YRealPtr res1, YRealPtr res2, int* iter, YRealFuncPtr f1, YRealPtr guess_, YRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    LibYReal_BracketRoot(res1, res2, iter, f1, guess_, factor_, is_rising, get_digits, maxit);
}



void Lib_YReal_NewtonRaphson(YRealPtr res,  int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibYReal_NewtonRaphson(res, iter, f1, f2, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_YReal_Halley(YRealPtr res, int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibYReal_Halley(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_YReal_Schroder(YRealPtr res, int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibYReal_Schroder(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_YReal_Brent_Minimum(YRealPtr res, YRealPtr resFx, int* iter, YRealFuncPtr f1, YRealPtr bracket_min_, YRealPtr bracket_max_, int bits, unsigned int maxit)
{
    LibYReal_Brent_Minimum(res, resFx, iter, f1, bracket_min_, bracket_max_, bits, maxit);
}





void Lib_YReal_Trapezoidal(YRealPtr res1, YRealPtr res2, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_)
{
    LibYReal_Trapezoidal(res1, res2, res3, f1, a_, b_);
}



// 7, 15, 20, 25 and 30

void Lib_YReal_GaussLegendre(YRealPtr res1, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_)
{
    LibYReal_GaussLegendre(res1, res3, f1, a_, b_);
}



//15, 31, 41, 51 and 61

void Lib_YReal_GaussKronrod(YRealPtr res1, YRealPtr res2, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_)
{
    LibYReal_GaussKronrod(res1, res2, res3, f1, a_, b_);
}



void Lib_YReal_TanhSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_)
{
    LibYReal_TanhSinh(res1, res2, res3, levels_, f1, a_, b_);
}




void Lib_YReal_SinhSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1)
{
    LibYReal_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_YReal_ExpSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1)
{
    LibYReal_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_YReal_Ooura_Cos(YRealPtr res1, YRealPtr res2, YRealFuncPtr f1)
{
    LibYReal_Ooura_Cos(res1, res2, f1);
}



void Lib_YReal_Ooura_Sin(YRealPtr res1, YRealPtr res2, YRealFuncPtr f1)
{
    LibYReal_Ooura_Sin(res1, res2, f1);
}









//*********************** Boost Odeint **********************************


AnyPtr Lib_YReal_StateInit_Func_N(int N)
{
    return LibYReal_StateInit_Func_N(N);
}


void Lib_YReal_StateClear(mpNumMatrixPtr x)
{
    return LibYReal_StateClear((DStatePtr) x);
}


void Lib_YReal_StateGetCoeff(ScalarPtr res, long row, mpNumMatrixPtr source)
{
    LibYReal_StateGetCoeff((YRealPtr) res, row, (DStatePtr) source);
}

void Lib_YReal_StateSetCoeff(mpNumMatrixPtr result, ScalarPtr source, long row)
{
    LibYReal_StateSetCoeff((DStatePtr) result, (YRealPtr) source, row);
}


void Lib_YReal_StateGetSize(long *result, mpNumMatrixPtr x)
{
    LibYReal_StateGetSize(result, (DStatePtr)x);
}


void Lib_YReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    LibYReal_Const_RungeKutta4((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_YReal_Const_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    LibYReal_Const_RungeKuttaCashKarp54((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_YReal_Const_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    LibYReal_Const_RungeKuttaDopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_YReal_Const_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    LibYReal_Const_RungeKuttaFehlberg78((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_YReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    LibYReal_Const_AdamsBashforthMoulton((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}


void Lib_YReal_Adaptive_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    LibYReal_Adaptive_RungeKuttaDopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_YReal_Adaptive_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    LibYReal_Adaptive_RungeKuttaCashKarp54((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_YReal_Adaptive_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    LibYReal_Adaptive_RungeKuttaFehlberg78((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_YReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    LibYReal_Adaptive_BulirschStoer((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_YReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    LibYReal_DenseOutput_Dopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_YReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    LibYReal_DenseOutput_BulirschStoer((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}







//*********************** Boost/CppOptLib **********************************


void Lib_YReal_GradientDescentSolverSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr)
{
    LibYReal_GradientDescentSolverSolver((YRealFuncPtr) f1, (YRealFuncPtr) f2, (DStatePtr) matX_, (DStatePtr) matGrad_, (DStatePtr) matNorm_, (DStatePtr) xPtr);
}


void Lib_YReal_ConjugatedGradientDescentSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr)
{
    LibYReal_ConjugatedGradientDescentSolver((YRealFuncPtr) f1, (YRealFuncPtr) f2, (DStatePtr) matX_, (DStatePtr) matGrad_, (DStatePtr) matNorm_, (DStatePtr) xPtr);
}


void Lib_YReal_BfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr)
{
    LibYReal_BfgsSolver((YRealFuncPtr) f1, (YRealFuncPtr) f2, (DStatePtr) matX_, (DStatePtr) matGrad_, (DStatePtr) matNorm_, (DStatePtr) xPtr);
}


void Lib_YReal_LbfgsSolver(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr)
{
    LibYReal_LbfgsSolver((YRealFuncPtr) f1, (YRealFuncPtr) f2, (DStatePtr) matX_, (DStatePtr) matGrad_, (DStatePtr) matNorm_, (DStatePtr) xPtr);
}








































