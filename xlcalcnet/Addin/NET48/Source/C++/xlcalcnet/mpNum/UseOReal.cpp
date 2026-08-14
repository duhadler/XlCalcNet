
#include "mpNumC_Main.h"
#include "BoostOReal.h"

#include "stdint.h"
#include <complex>
#include <limits>








/** ********************** Real Basic Functions, double precision ******************************** **/


ORealPtr Lib_OReal_Init_Func()
{
    return LibOReal_Init_Func();
}




void Lib_OReal_Clear(ORealPtr x)
{
    LibOReal_Clear(x);
}



/* Input and output  */


void Lib_OReal_Set(ORealPtr res, const ORealPtr x)
{
    LibOReal_Set(res, x);
}

void Lib_OReal_Set_OReal(ORealPtr res, const ORealPtr x)
{
    LibOReal_Set(res, x);
}



void Lib_OReal_Set_S(ORealPtr res, const float* x)
{
    LibOReal_Set_S(res,x);
}

void Lib_OReal_Set_D(ORealPtr res, const double x)
{
    LibOReal_Set_D(res,x);
}

void Lib_OReal_Set_LD(ORealPtr res, const long double* x)
{
    LibOReal_Set_LD(res,x);
}


void Lib_OReal_Get_S(float* res, const ORealPtr x)
{
    LibOReal_Get_S(res,x);
}

void Lib_OReal_Get_D(double* res, const ORealPtr x)
{
    LibOReal_Get_D(res,x);
}

void Lib_OReal_Get_LD(long double* res, const ORealPtr x)
{
    LibOReal_Get_LD(res,x);
}





void Lib_OReal_Set_Si(ORealPtr res, const int32_t x)
{
	LibOReal_Set_Si(res, x);
}

void Lib_OReal_Set_Ui(ORealPtr res, const uint32_t x)
{
	LibOReal_Set_Ui(res, x);
}

void Lib_OReal_Set_Si64(ORealPtr res, const int64_t x)
{
	LibOReal_Set_Si64(res, x);
}

void Lib_OReal_Set_Ui64(ORealPtr res, const uint64_t x)
{
	LibOReal_Set_Ui64(res, x);
}

void Lib_OReal_Set_Str(ORealPtr res, const char * str)
{
    LibOReal_Set_Str(res, str);
}

void Lib_OReal_Get_Str(char* cstr, const ORealPtr x)
{
    LibOReal_Get_Str(cstr, x);
}

void Lib_OReal_Get_HexStr(char* cstr, const ORealPtr x)
{
    LibOReal_Get_HexStr(cstr, x);
}






/* Operator overloading vs raw arithmetic and comparisons  */


void Lib_OReal_Neg(ORealPtr res, const ORealPtr x)
{
    LibOReal_Neg(res, x);
}

void Lib_OReal_Add(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Add(res, x, y);
}

void Lib_OReal_Sub(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Sub(res, x, y);
}

void Lib_OReal_Mul(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Mul(res, x, y);
}

void Lib_OReal_Div(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Div(res, x, y);
}

void Lib_OReal_Add_D(ORealPtr res, const ORealPtr x, const double y)
{
    LibOReal_Add_D(res, x, y);
}

void Lib_OReal_Sub_D(ORealPtr res, const ORealPtr x, const double y)
{
    LibOReal_Sub_D(res, x, y);
}

void Lib_OReal_D_Sub(ORealPtr res, const ORealPtr x, const double y)
{
    LibOReal_D_Sub(res, x, y);
}

void Lib_OReal_Mul_D(ORealPtr res, const ORealPtr x, const double y)
{
    LibOReal_Mul_D(res, x, y);
}

void Lib_OReal_Div_D(ORealPtr res, const ORealPtr x, const double y)
{
    LibOReal_Div_D(res, x, y);
}

void Lib_OReal_D_Div(ORealPtr res, const ORealPtr x, const double y)
{
    LibOReal_D_Div(res, x, y);
}

void Lib_OReal_Add_Si(ORealPtr res, const ORealPtr x, const int32_t y)
{
    LibOReal_Add_Si(res, x, y);
}

void Lib_OReal_Sub_Si(ORealPtr res, const ORealPtr x, const int32_t y)
{
    LibOReal_Sub_Si(res, x, y);
}

void Lib_OReal_Si_Sub(ORealPtr res, const ORealPtr x, const int32_t y)
{
    LibOReal_Si_Sub(res, x, y);
}

void Lib_OReal_Mul_Si(ORealPtr res, const ORealPtr x, const int32_t y)
{
    LibOReal_Mul_Si(res, x, y);
}

void Lib_OReal_Div_Si(ORealPtr res, const ORealPtr x, const int32_t y)
{
    LibOReal_Div_Si(res, x, y);
}

void Lib_OReal_Si_Div(ORealPtr res, const ORealPtr x, const int32_t y)
{
    LibOReal_Si_Div(res, x, y);
}


int32_t Lib_OReal_LT(const ORealPtr x, const ORealPtr y)
{
    return LibOReal_LT(x, y);
}

int32_t Lib_OReal_GE(const ORealPtr x, const ORealPtr y)
{
    return LibOReal_GE(x, y);
}

int32_t Lib_OReal_GT(const ORealPtr x, const ORealPtr y)
{
    return LibOReal_GT(x, y);
}

int32_t Lib_OReal_LE(const ORealPtr x, const ORealPtr y)
{
    return LibOReal_LE(x, y);
}

int32_t Lib_OReal_EQ(const ORealPtr x, const ORealPtr y)
{
    return LibOReal_EQ(x, y);
}

int32_t Lib_OReal_NE(const ORealPtr x, const ORealPtr y)
{
    return LibOReal_NE(x, y);
}










/* General functions for real numbers  */

void Lib_OReal_Fma(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z)
{
    LibOReal_Fma(res, x, y, z);
}

void Lib_OReal_Fmax(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Fmax(res, x, y);
}

void Lib_OReal_Fmin(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Fmin(res, x, y);
}




/* Machine constants */

void Lib_OReal_Zero(ORealPtr res)
{
    LibOReal_Zero(res);
}

void Lib_OReal_NegZero(ORealPtr res)
{
    LibOReal_NegZero(res);
}

void Lib_OReal_One(ORealPtr res)
{
    LibOReal_One(res);
}

void Lib_OReal_Inf(ORealPtr res)
{
    LibOReal_Inf(res);
}

void Lib_OReal_NegInf(ORealPtr res)
{
    LibOReal_NegInf(res);
}

void Lib_OReal_Nan(ORealPtr res)
{
    LibOReal_Nan(res);
}



/* Properties of numbers  */

int Lib_OReal_Signbit(const ORealPtr x)
{
    return LibOReal_Signbit(x);
}

int Lib_OReal_Finite(const ORealPtr x)
{
    return LibOReal_Finite(x);
}

int Lib_OReal_Isinf(const ORealPtr x)
{
    return LibOReal_Isinf(x);
}

int Lib_OReal_Isposinf(const ORealPtr x)
{
    return LibOReal_Isinf(x);
}

int Lib_OReal_Isneginf(const ORealPtr x)
{
    return LibOReal_Isneginf(x);
}

int Lib_OReal_Isnan(const ORealPtr x)
{
    return LibOReal_Isnan(x);
}





int Lib_OReal_Iszero(const ORealPtr x)
{
	return LibOReal_Iszero(x);
}

int Lib_OReal_Isposzero(const ORealPtr x)
{
	return  LibOReal_Isposzero(x);
}

int Lib_OReal_Isnegzero(const ORealPtr x)
{
	return LibOReal_Isnegzero(x);
}

int Lib_OReal_Isone(const ORealPtr x)
{
	return LibOReal_Isone(x);
}

int Lib_OReal_Isinteger(const ORealPtr x)
{
	return LibOReal_Isinteger(x);
}

int Lib_OReal_Isnumber(const ORealPtr x)
{
	return LibOReal_Isnumber(x);
}

int Lib_OReal_Isregular(const ORealPtr x)
{
	return LibOReal_Isregular(x);
}

int Lib_OReal_Isnormal(const ORealPtr x)
{
	return LibOReal_Isnormal(x);
}

int Lib_OReal_Issubnormal(const ORealPtr x)
{
	return LibOReal_Issubnormal(x);
}

int Lib_OReal_Isunordered(const ORealPtr x, const ORealPtr y)
{
	return LibOReal_Isunordered(x, y);
}







int Lib_OReal_FitsInt32(const ORealPtr x)
{
    return LibOReal_FitsInt32(x);
}

int Lib_OReal_FitsInt64(const ORealPtr x)
{
    return LibOReal_FitsInt64(x);
}

int Lib_OReal_FitsUInt32(const ORealPtr x)
{
    return LibOReal_FitsUInt32(x);
}

int Lib_OReal_FitsUInt64(const ORealPtr x)
{
    return LibOReal_FitsUInt64(x);
}






/* Integer Related Functions  */

void Lib_OReal_Nearbyint(ORealPtr res, const ORealPtr x)
{
    LibOReal_Nearbyint(res, x);
}

void Lib_OReal_Rint(ORealPtr res, const ORealPtr x)
{
    LibOReal_Rint(res, x);
}

long int Lib_OReal_Lrint(const ORealPtr x)
{
    return LibOReal_Lrint(x);
}

long long int Lib_OReal_Llrint(const ORealPtr x)
{
    return LibOReal_Llrint(x);
}

void Lib_OReal_Ceil(ORealPtr res, const ORealPtr x)
{
    LibOReal_Ceil(res, x);
}

void Lib_OReal_Floor(ORealPtr res, const ORealPtr x)
{
    LibOReal_Floor(res, x);
}

void Lib_OReal_Trunc(ORealPtr res, const ORealPtr x)
{
    LibOReal_Trunc(res, x);
}

void Lib_OReal_Round(ORealPtr res, const ORealPtr x)
{
    LibOReal_Round(res, x);
}

long int Lib_OReal_Lround(const ORealPtr x)
{
    return LibOReal_Lround(x);
}

long long int Lib_OReal_Llround(const ORealPtr x)
{
    return LibOReal_Llround(x);
}

int32_t Lib_OReal_ToInt32(const ORealPtr x)
{
    return LibOReal_ToInt32(x);
}

int64_t Lib_OReal_ToInt64(const ORealPtr x)
{
    return LibOReal_ToInt64(x);
}

uint32_t Lib_OReal_ToUInt32(const ORealPtr x)
{
    return LibOReal_ToInt32(x);
}

uint64_t Lib_OReal_ToUInt64(const ORealPtr x)
{
    return LibOReal_ToInt64(x);
}






/* Floating point functions for real numbers */

void Lib_OReal_Copysign(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Copysign(res, x, y);
}

void Lib_OReal_Frexp(ORealPtr res, const ORealPtr x, int* e)
{
    LibOReal_Frexp(res, x, e);
}


void Lib_OReal_Logb(ORealPtr res, const ORealPtr x)
{
    LibOReal_Logb(res, x);
}


int Lib_OReal_Ilogb(const ORealPtr x)
{
    return LibOReal_Ilogb(x);
}




void Lib_OReal_Ldexp(ORealPtr res, const ORealPtr x, const long int e)
{
    LibOReal_Ldexp(res, x, e);
}

void Lib_OReal_Scalbn(ORealPtr res, const ORealPtr x, const int e)
{
    LibOReal_Scalbn(res, x, e);
}


void Lib_OReal_Scalbln(ORealPtr res, const ORealPtr x, const long int e)
{
    LibOReal_Scalbln(res, x, e);
}


void Lib_OReal_Fdim(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Fdim(res, x, y);
}






/* Fraction and Remainder Related Functions  */

void Lib_OReal_Modf(ORealPtr frac, ORealPtr x, const ORealPtr iptr)
{
    LibOReal_Modf(frac, x, iptr);
}

void Lib_OReal_Fmod(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Fmod(res, x, y);
}

void Lib_OReal_Remainder(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Remainder(res, x, y);
}

void Lib_OReal_Remquo(ORealPtr res, const ORealPtr x, const ORealPtr y, int* e)
{
    LibOReal_Remquo(res, x, y, e);
}





/* Functions related to mantissa width and exponent range */

void Lib_OReal_Epsilon(ORealPtr res)
{
    LibOReal_Epsilon(res);
}

void Lib_OReal_Ulp(ORealPtr res, const ORealPtr x)
{
	LibOReal_Ulp(res, x);
}


void Lib_OReal_Max(ORealPtr res)
{
    LibOReal_Max(res);
}

void Lib_OReal_Lowest(ORealPtr res)
{
    LibOReal_Lowest(res);
}

void Lib_OReal_Min(ORealPtr res)
{
    LibOReal_Min(res);
}

void Lib_OReal_Nextabove(ORealPtr res, const ORealPtr x)
{
    LibOReal_Nextabove(res, x);
}

void Lib_OReal_Nextbelow(ORealPtr res, const ORealPtr x)
{
    LibOReal_Nextbelow(res, x);
}

void Lib_OReal_Nexttoward(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Nexttowards(res, x, y);
}








/* Mathematical Constants  */

void Lib_OReal_ConstDegree(ORealPtr res)
{
	LibOReal_Set_Str(res, "1.74532925199432957692369076848861271344287188854172545609719144017100911E-02");
}

void Lib_OReal_ConstPhi(ORealPtr res)
{
	LibOReal_Set_Str(res, "1.61803398874989484820458683436563811772030917980576286213544862270526046E+00");
}

void Lib_OReal_ConstLog2(ORealPtr res)
{
	LibOReal_Set_Str(res, "6.93147180559945309417232121458176568075500134360255254120680009493393622E-01");
}

void Lib_OReal_ConstLog10(ORealPtr res)
{
	LibOReal_Set_Str(res, "2.30258509299404568401799145468436420760110148862877297603332790096757261E+00");
}

void Lib_OReal_ConstPi(ORealPtr res)
{
	LibOReal_Set_Str(res, "3.14159265358979323846264338327950288419716939937510582097494459230781641E+00");
}

void Lib_OReal_ConstE(ORealPtr res)
{
	LibOReal_Set_Str(res, "2.71828182845904523536028747135266249775724709369995957496696762772407663E+00");
}

void Lib_OReal_ConstEulerGamma(ORealPtr res)
{
	LibOReal_Set_Str(res, "5.77215664901532860606512090082402431042159335939923598805767234884867727E-01");
}

void Lib_OReal_ConstApery(ORealPtr res)
{
	LibOReal_Set_Str(res, "1.20205690315959428539973816151144999076498629234049888179227155534183820E+00");
}

void Lib_OReal_ConstCatalan(ORealPtr res)
{
	LibOReal_Set_Str(res, "9.15965594177219015054603514932384110774149374281672134266498119621763020E-01");
}

void Lib_OReal_ConstGlaisher(ORealPtr res)
{
	LibOReal_Set_Str(res, "1.28242712910062263687534256886979172776768892732500119206374002174040631E+00");
}

void Lib_OReal_ConstKhinchin(ORealPtr res)
{
	LibOReal_Set_Str(res, "2.68545200106530644530971483548179569382038229399446295305115234555721886E+00");
}




/* Complex components  */

void Lib_OReal_Fabs(ORealPtr res, const ORealPtr x)
{
    LibOReal_Fabs(res, x);
}

void Lib_OReal_Sign(ORealPtr res, const ORealPtr x)
{
    LibOReal_Sign(res, x);
}





/* Roots and related functions  */

void Lib_OReal_Sqrt(ORealPtr res, const ORealPtr x)
{
    LibOReal_Sqrt(res, x);
}

void Lib_OReal_Sqrt1pm1(ORealPtr res, const ORealPtr x)
{
    LibOReal_Sqrt1pm1(res, x);
}


void Lib_OReal_Rsqrt(ORealPtr res, const ORealPtr x)
{
    LibOReal_Rsqrt(res, x);
}

void Lib_OReal_Cbrt(ORealPtr res, const ORealPtr x)
{
    LibOReal_Cbrt(res, x);
}

void Lib_OReal_Root_Si(ORealPtr res, const ORealPtr x, const int32_t k)
{
    LibOReal_Root_Si(res, x, k);
}




/* Exponential and related functions  */

void Lib_OReal_Exp(ORealPtr res, const ORealPtr x)
{
    LibOReal_Exp(res, x);
}

void Lib_OReal_Exp2(ORealPtr res, const ORealPtr x)
{
    LibOReal_Exp2(res, x);
}

void Lib_OReal_Exp10(ORealPtr res, const ORealPtr x)
{
    LibOReal_Exp10(res, x);
}

void Lib_OReal_Expm1(ORealPtr res, const ORealPtr x)
{
    LibOReal_Expm1(res, x);
}

void Lib_OReal_Exp2m1(ORealPtr res, const ORealPtr x)
{
    LibOReal_Exp2m1(res, x);
}

void Lib_OReal_Exp10m1(ORealPtr res, const ORealPtr x)
{
    LibOReal_Exp10m1(res, x);
}



/* Logarithms and related functions  */


void Lib_OReal_Log(ORealPtr res, const ORealPtr x)
{
    LibOReal_Log(res, x);
}

void Lib_OReal_Log2(ORealPtr res, const ORealPtr x)
{
    LibOReal_Log2(res, x);
}

void Lib_OReal_Log10(ORealPtr res, const ORealPtr x)
{
    LibOReal_Log10(res, x);
}

void Lib_OReal_Log1p(ORealPtr res, const ORealPtr x)
{
    LibOReal_Log1p(res, x);
}

void Lib_OReal_Log2p1(ORealPtr res, const ORealPtr x)
{
    LibOReal_Log2p1(res, x);
}

void Lib_OReal_Log10p1(ORealPtr res, const ORealPtr x)
{
    LibOReal_Log10p1(res, x);
}



/* Power functions and roots  */

void Lib_OReal_Square(ORealPtr res, const ORealPtr x)
{
    LibOReal_Square(res, x);
}

void Lib_OReal_Cube(ORealPtr res, const ORealPtr x)
{
    LibOReal_Cube(res, x);
}


void Lib_OReal_Hypot(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Hypot(res, x, y);
}

void Lib_OReal_Pow(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Pow(res, x, y);
}

void Lib_OReal_Powm1(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Powm1(res, x, y);
}


void Lib_OReal_Pow1p(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Pow1p(res, x, y);
}

void Lib_OReal_Pow1pm1(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Pow1pm1(res, x, y);
}


void Lib_OReal_Pow_Si(ORealPtr res, const ORealPtr x, const int32_t k)
{
    LibOReal_Pow_Si(res, x, k);
}


void Lib_OReal_Compound_Si(ORealPtr res, const ORealPtr x, const int32_t k)
{
    LibOReal_Compound_Si(res, x, k);
}



/* Trigonometric functions  */

void Lib_OReal_Sin(ORealPtr res, const ORealPtr x)
{
    LibOReal_Sin(res, x);
}

void Lib_OReal_Cos(ORealPtr res, const ORealPtr x)
{
    LibOReal_Cos(res, x);
}

void Lib_OReal_Tan(ORealPtr res, const ORealPtr x)
{
    LibOReal_Tan(res, x);
}

void Lib_OReal_Csc(ORealPtr res, const ORealPtr x)
{
    LibOReal_Csc(res, x);
}

void Lib_OReal_Sec(ORealPtr res, const ORealPtr x)
{
    LibOReal_Sec(res, x);
}

void Lib_OReal_Cot(ORealPtr res, const ORealPtr x)
{
    LibOReal_Cot(res, x);
}


void Lib_OReal_SinPi(ORealPtr res, const ORealPtr x)
{
    LibOReal_SinPi(res, x);
}

void Lib_OReal_CosPi(ORealPtr res, const ORealPtr x)
{
    LibOReal_CosPi(res, x);
}

void Lib_OReal_TanPi(ORealPtr res, const ORealPtr x)
{
    LibOReal_TanPi(res, x);
}

void Lib_OReal_CscPi(ORealPtr res, const ORealPtr x)
{
    LibOReal_CscPi(res, x);
}

void Lib_OReal_SecPi(ORealPtr res, const ORealPtr x)
{
    LibOReal_SecPi(res, x);
}

void Lib_OReal_CotPi(ORealPtr res, const ORealPtr x)
{
    LibOReal_CotPi(res, x);
}






/* Hyperbolic functions  */

void Lib_OReal_Sinh(ORealPtr res, const ORealPtr x)
{
    LibOReal_Sinh(res, x);
}

void Lib_OReal_Cosh(ORealPtr res, const ORealPtr x)
{
    LibOReal_Cosh(res, x);
}

void Lib_OReal_Tanh(ORealPtr res, const ORealPtr x)
{
    LibOReal_Tanh(res, x);
}

void Lib_OReal_Csch(ORealPtr res, const ORealPtr x)
{
    LibOReal_Csch(res, x);
}

void Lib_OReal_Sech(ORealPtr res, const ORealPtr x)
{
    LibOReal_Sech(res, x);
}

void Lib_OReal_Coth(ORealPtr res, const ORealPtr x)
{
    LibOReal_Coth(res, x);
}


/* Inverse trigonometric functions  */

void Lib_OReal_Asin(ORealPtr res, const ORealPtr x)
{
    LibOReal_Asin(res, x);
}

void Lib_OReal_Acos(ORealPtr res, const ORealPtr x)
{
    LibOReal_Acos(res, x);
}

void Lib_OReal_Atan(ORealPtr res, const ORealPtr x)
{
    LibOReal_Atan(res, x);
}

void Lib_OReal_Atan2(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_Atan2(res, x, y);
}

void Lib_OReal_Acsc(ORealPtr res, const ORealPtr x)
{
    LibOReal_Acsc(res, x);
}

void Lib_OReal_Asec(ORealPtr res, const ORealPtr x)
{
    LibOReal_Asec(res, x);
}

void Lib_OReal_Acot(ORealPtr res, const ORealPtr x)
{
    LibOReal_Acot(res, x);
}



/* Inverse hyperbolic functions  */

void Lib_OReal_Asinh(ORealPtr res, const ORealPtr x)
{
    LibOReal_Asinh(res, x);
}

void Lib_OReal_Acosh(ORealPtr res, const ORealPtr x)
{
    LibOReal_Acosh(res, x);
}

void Lib_OReal_Atanh(ORealPtr res, const ORealPtr x)
{
    LibOReal_Atanh(res, x);
}

void Lib_OReal_Acsch(ORealPtr res, const ORealPtr x)
{
    LibOReal_Acsch(res, x);
}

void Lib_OReal_Asech(ORealPtr res, const ORealPtr x)
{
    LibOReal_Asech(res, x);
}

void Lib_OReal_Acoth(ORealPtr res, const ORealPtr x)
{
    LibOReal_Acoth(res, x);
}



/* Special functions  */

void Lib_OReal_Erf(ORealPtr res, const ORealPtr x)
{
    LibOReal_Erf(res, x);
}

void Lib_OReal_Erfc(ORealPtr res, const ORealPtr x)
{
    LibOReal_Erfc(res, x);
}

void Lib_OReal_Tgamma(ORealPtr res, const ORealPtr x)
{
    LibOReal_Tgamma(res, x);
}

void Lib_OReal_Lgamma(ORealPtr res, const ORealPtr x)
{
    LibOReal_Lgamma(res, x);
}

void Lib_OReal_BesselJ0(ORealPtr res, const ORealPtr x)
{
    LibOReal_J0(res, x);
}

void Lib_OReal_BesselJ1(ORealPtr res, const ORealPtr x)
{
    LibOReal_J1(res, x);
}

void Lib_OReal_BesselJn(ORealPtr res, const int n, const ORealPtr x)
{
    LibOReal_Jn(res, n, x);
}

void Lib_OReal_BesselY0(ORealPtr res, const ORealPtr x)
{
    LibOReal_Y0(res, x);
}

void Lib_OReal_BesselY1(ORealPtr res, const ORealPtr x)
{
    LibOReal_Y1(res, x);
}

void Lib_OReal_BesselYn(ORealPtr res, const int n, const ORealPtr x)
{
    LibOReal_Yn(res, n, x);
}







/** ********************** Complex Basic Functions, OCplx ******************************** **/


OCplxPtr Lib_OCplx_Init_Func()
{
    return LibOCplx_Init_Func();
}


void Lib_OCplx_Clear(OCplxPtr x)
{
    LibOCplx_Clear(x);
}




/* Input and output  */


void Lib_OCplx_Set(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Set(res, x);
}






/* Operator overloading vs raw arithmetic and comparisons  */

void Lib_OCplx_Neg(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Neg(res, x);
}

void Lib_OCplx_Add(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    LibOCplx_Add(res, x, y);
}

void Lib_OCplx_Sub(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    LibOCplx_Sub(res, x, y);
}

void Lib_OCplx_Mul(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    LibOCplx_Mul(res, x, y);
}

void Lib_OCplx_Div(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    LibOCplx_Div(res, x, y);
}


void Lib_OCplx_Add_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y)
{
    LibOCplx_Add_OReal(res, x, y);
}

void Lib_OCplx_Sub_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y)
{
    LibOCplx_Sub_OReal(res, x, y);
}

void Lib_OCplx_OReal_Sub(OCplxPtr res, const OCplxPtr y, const ORealPtr x)
{
    LibOCplx_OReal_Sub(res, y, x);
}


void Lib_OCplx_Mul_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y)
{
    LibOCplx_Mul_OReal(res, x, y);
}

void Lib_OCplx_Div_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y)
{
    LibOCplx_Div_OReal(res, x, y);
}


void Lib_OCplx_OReal_Div(OCplxPtr res, const OCplxPtr y, const ORealPtr x)
{
    LibOCplx_OReal_Div(res, y, x);
}


void Lib_OCplx_Add_D(OCplxPtr res, const OCplxPtr x, const double y)
{
    LibOCplx_Add_D(res, x, y);
}

void Lib_OCplx_Sub_D(OCplxPtr res, const OCplxPtr x, const double y)
{
    LibOCplx_Sub_D(res, x, y);
}

void Lib_OCplx_D_Sub(OCplxPtr res, const OCplxPtr y, const double x)
{
    LibOCplx_D_Sub(res, y, x);
}

void Lib_OCplx_Mul_D(OCplxPtr res, const OCplxPtr x, const double y)
{
    LibOCplx_Mul_D(res, x, y);
}

void Lib_OCplx_Div_D(OCplxPtr res, const OCplxPtr x, const double y)
{
    LibOCplx_Div_D(res, x, y);
}


void Lib_OCplx_D_Div(OCplxPtr res, const OCplxPtr y, const double x)
{
    LibOCplx_D_Div(res, y, x);
}

void Lib_OCplx_Add_Si(OCplxPtr res, const OCplxPtr x, const int32_t y)
{
    LibOCplx_Add_Si(res, x, y);
}

void Lib_OCplx_Sub_Si(OCplxPtr res, const OCplxPtr x, const int32_t y)
{
    LibOCplx_Sub_Si(res, x, y);
}

void Lib_OCplx_Si_Sub(OCplxPtr res, const OCplxPtr y, const int32_t x)
{
    LibOCplx_Si_Sub(res, y, x);
}

void Lib_OCplx_Mul_Si(OCplxPtr res, const OCplxPtr x, const int32_t y)
{
    LibOCplx_Mul_Si(res, x, y);
}



/* Missing: Inv */



void Lib_OCplx_Div_Si(OCplxPtr res, const OCplxPtr x, const int32_t y)
{
    LibOCplx_Div_Si(res, x, y);
}

void Lib_OCplx_Si_Div(OCplxPtr res, const OCplxPtr y, const int32_t x)
{
    LibOCplx_Si_Div(res, y, x);
}
















/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void Lib_OCplx_Set_Real(OCplxPtr res, const ORealPtr re)
{
    LibOCplx_Set_Real(res, re);
}

void Lib_OCplx_Set2(OCplxPtr res, const ORealPtr re, const ORealPtr im)
{
    LibOCplx_Set2(res, re, im);
}

void Lib_OCplx_Abs(ORealPtr res, const OCplxPtr x)
{
    LibOCplx_Abs(res, x);
}

void Lib_OCplx_Norm(ORealPtr res, const OCplxPtr x)
{
    LibOCplx_Abs(res, x);
}

void Lib_OCplx_Arg(ORealPtr res, const OCplxPtr x)
{
    LibOCplx_Arg(res, x);
}

void Lib_OCplx_Imag(ORealPtr res, const OCplxPtr x)
{
    LibOCplx_Imag(res, x);
}

void Lib_OCplx_Real(ORealPtr res, const OCplxPtr x)
{
    LibOCplx_Real(res, x);
}

void Lib_OCplx_Conj(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Conj(res, x);
}

void Lib_OCplx_Proj(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Proj(res, x);
}





/* Roots  */

void Lib_OCplx_Sqrt(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Sqrt(res, x);
}

void Lib_OCplx_Sqrt1pm1(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Sqrt1pm1(res, x);
}

void Lib_OCplx_Rsqrt(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Rsqrt(res, x);
}

void Lib_OCplx_Cbrt(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Cbrt(res, x);
}

void Lib_OCplx_Root_Si(OCplxPtr res, const OCplxPtr x, const int32_t k)
{
    LibOCplx_Root_Si(res, x, k);
}




/* Exponential and related functions  */

void Lib_OCplx_Exp(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Exp(res, x);
}


void Lib_OCplx_Exp2(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Exp2(res, x);
}

void Lib_OCplx_Exp10(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Exp10(res, x);
}


void Lib_OCplx_Expm1(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Expm1(res, x);
}

void Lib_OCplx_Exp2m1(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Exp2m1(res, x);
}

void Lib_OCplx_Exp10m1(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Exp10m1(res, x);
}



/* Logarithms and related functions  */

void Lib_OCplx_Log(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Log(res, x);
}

void Lib_OCplx_Log2(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Log2(res, x);
}

void Lib_OCplx_Log10(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Log10(res, x);
}

void Lib_OCplx_Log1p(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Log1p(res, x);
}

void Lib_OCplx_Log2p1(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Log2p1(res, x);
}

void Lib_OCplx_Log10p1(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Log10p1(res, x);
}




/* Power functions and roots  */

void Lib_OCplx_Square(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Square(res, x);
}

void Lib_OCplx_Cube(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Cube(res, x);
}

void Lib_OCplx_Pow(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    LibOCplx_Pow(res, x, y);
}


void Lib_OCplx_Powm1(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    LibOCplx_Powm1(res, x, y);
}

void Lib_OCplx_Pow1p(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    LibOCplx_Pow1p(res, x, y);
}

void Lib_OCplx_Pow1pm1(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    LibOCplx_Pow1pm1(res, x, y);
}


void Lib_OCplx_Pow_Si(OCplxPtr res, const OCplxPtr x, const int32_t k)
{
    LibOCplx_Pow_Si(res, x, k);
}

void Lib_OCplx_Compound_Si(OCplxPtr res, const OCplxPtr x, const int32_t k)
{
    LibOCplx_Compound_Si(res, x, k);
}





/* Trigonometric functions  */

void Lib_OCplx_Sin(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Sin(res, x);
}

void Lib_OCplx_Cos(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Cos(res, x);
}

void Lib_OCplx_Tan(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Tan(res, x);
}


void Lib_OCplx_Csc(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Csc(res, x);
}

void Lib_OCplx_Sec(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Sec(res, x);
}

void Lib_OCplx_Cot(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Cot(res, x);
}


void Lib_OCplx_SinPi(OCplxPtr res, const OCplxPtr x)
{
    //LibOCplx_SinPi(res, x);
}

void Lib_OCplx_CosPi(OCplxPtr res, const OCplxPtr x)
{
    //LibOCplx_CosPi(res, x);
}

void Lib_OCplx_TanPi(OCplxPtr res, const OCplxPtr x)
{
    //LibOCplx_TanPi(res, x);
}




/* Hyperbolic functions  */

void Lib_OCplx_Sinh(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Sinh(res, x);
}

void Lib_OCplx_Cosh(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Cosh(res, x);
}

void Lib_OCplx_Tanh(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Tanh(res, x);
}


void Lib_OCplx_Csch(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Csch(res, x);
}

void Lib_OCplx_Sech(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Sech(res, x);
}

void Lib_OCplx_Coth(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Coth(res, x);
}



/* Inverse trigonometric functions  */

void Lib_OCplx_Asin(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Asin(res, x);
}

void Lib_OCplx_Acos(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Acos(res, x);
}

void Lib_OCplx_Atan(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Atan(res, x);
}


void Lib_OCplx_Acsc(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Acsc(res, x);
}

void Lib_OCplx_Asec(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Asec(res, x);
}

void Lib_OCplx_Acot(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Acot(res, x);
}




/* Inverse hyperbolic functions  */

void Lib_OCplx_Asinh(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Asinh(res, x);
}

void Lib_OCplx_Acosh(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Acosh(res, x);
}

void Lib_OCplx_Atanh(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Atanh(res, x);
}


void Lib_OCplx_Acsch(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Acsch(res, x);
}

void Lib_OCplx_Asech(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Asech(res, x);
}

void Lib_OCplx_Acoth(OCplxPtr res, const OCplxPtr x)
{
    LibOCplx_Acoth(res, x);
}









//*********************** Boost Special functions , OReal **********************************



void Lib_OReal_BernoulliB2n(ORealPtr res, const int n)
{
    LibOReal_BernoulliB2n(res, n);
}



void Lib_OReal_TangentT2n(ORealPtr res, const int n)
{
    LibOReal_TangentT2n(res, n);
}



void Lib_OReal_Sqrt1pm1_Boost(ORealPtr res, const ORealPtr x)
{
    LibOReal_Sqrt1pm1(res, x);
}



void Lib_OReal_SinPi_Boost(ORealPtr res, const ORealPtr x)
{
    LibOReal_SinPi(res, x);
}



void Lib_OReal_CosPi_Boost(ORealPtr res, const ORealPtr x)
{
    LibOReal_CosPi(res, x);
}



void Lib_OReal_SincPi(ORealPtr res, const ORealPtr x)
{
    LibOReal_SincPi(res, x);
}



void Lib_OReal_SinhcPi(ORealPtr res, const ORealPtr x)
{
    LibOReal_SinhcPi(res, x);
}



void Lib_OReal_Tgamma_(ORealPtr res, const ORealPtr x)
{
    LibOReal_Tgamma_(res, x);
}


void Lib_OReal_Tgamma1pm1(ORealPtr res, const ORealPtr x)
{
    LibOReal_Tgamma1pm1(res, x);
}



void Lib_OReal_Lgamma_(ORealPtr res, const ORealPtr x)
{
    LibOReal_Lgamma_(res, x);
}



void Lib_OReal_Digamma(ORealPtr res, const ORealPtr x)
{
    LibOReal_Digamma(res, x);
}



void Lib_OReal_Trigamma(ORealPtr res, const ORealPtr x)
{
    LibOReal_Trigamma(res, x);
}



void Lib_OReal_Factorial(ORealPtr res, const ORealPtr x)
{
    LibOReal_Factorial(res, x);
}



void Lib_OReal_DoubleFactorial(ORealPtr res, const ORealPtr x)
{
    LibOReal_DoubleFactorial(res, x);
}





void Lib_OReal_Erf_(ORealPtr res, const ORealPtr x)
{
    LibOReal_Erf_(res, x);
}



void Lib_OReal_Erfc_(ORealPtr res, const ORealPtr x)
{
    LibOReal_Erfc_(res, x);
}



void Lib_OReal_Erf_inv(ORealPtr res, const ORealPtr x)
{
    LibOReal_Erf_inv(res, x);
}



void Lib_OReal_Erfc_inv(ORealPtr res, const ORealPtr x)
{
    LibOReal_Erfc_inv(res, x);
}



void Lib_OReal_AiryAi(ORealPtr res, const ORealPtr x)
{
    LibOReal_AiryAi(res, x);
}



void Lib_OReal_AiryBi(ORealPtr res, const ORealPtr x)
{
    LibOReal_AiryBi(res, x);
}



void Lib_OReal_AiryAiPrime(ORealPtr res, const ORealPtr x)
{
    LibOReal_AiryAiPrime(res, x);
}



void Lib_OReal_AiryBiPrime(ORealPtr res, const ORealPtr x)
{
    LibOReal_AiryBiPrime(res, x);
}



void Lib_OReal_Aizero(ORealPtr res, const int n)
{
    LibOReal_Aizero(res, n);
}



void Lib_OReal_Bizero(ORealPtr res, const int n)
{
    LibOReal_Bizero(res, n);
}



void Lib_OReal_Ellint_1_K(ORealPtr res, const ORealPtr x)
{
    LibOReal_Ellint_1_K(res, x);
}



void Lib_OReal_Ellint_2_K(ORealPtr res, const ORealPtr x)
{
    LibOReal_Ellint_2_K(res, x);
}



void Lib_OReal_Zeta(ORealPtr res, const ORealPtr x)
{
    LibOReal_Zeta(res, x);
}



void Lib_OReal_Ei(ORealPtr res, const ORealPtr x)
{
    LibOReal_Ei(res, x);
}



void Lib_OReal_LambertW0(ORealPtr res, const ORealPtr x)
{
    LibOReal_LambertW0(res, x);
}


void Lib_OReal_LambertWm1(ORealPtr res, const ORealPtr x)
{
    LibOReal_LambertWm1(res, x);
}



void Lib_OReal_LambertW0Prime(ORealPtr res, const ORealPtr x)
{
    LibOReal_LambertW0Prime(res, x);
}


void Lib_OReal_LambertWm1Prime(ORealPtr res, const ORealPtr x)
{
    LibOReal_LambertWm1Prime(res, x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void Lib_OReal_Agm(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
    LibOReal_Agm(res, a, b);
}




void Lib_OReal_Powm1_Boost(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
    LibOReal_Powm1(res, a, b);
}



void Lib_OReal_TgammaRatio(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
    LibOReal_TgammaRatio(res, a, b);
}



void Lib_OReal_TgammaDeltaRatio(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
    LibOReal_TgammaDeltaRatio(res, a, b);
}



void Lib_OReal_Binomial(ORealPtr res, const ORealPtr n, const ORealPtr k)
{
    LibOReal_Binomial(res, n, k);
}

void Lib_OReal_RisingFactorial(ORealPtr res, const ORealPtr x, const ORealPtr n)
{
    LibOReal_RisingFactorial(res, x, n);
}




void Lib_OReal_FallingFactorial(ORealPtr res, const ORealPtr x, const ORealPtr n)
{
    LibOReal_FallingFactorial(res, x, n);
}




void Lib_OReal_BesselJ(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
    LibOReal_BesselJ(res, v, x);
}



void Lib_OReal_BesselY(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
    LibOReal_BesselY(res, v, x);
}



void Lib_OReal_BesselI(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
    LibOReal_BesselI(res, v, x);
}



void Lib_OReal_BesselK(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
    LibOReal_BesselK(res, v, x);
}



void Lib_OReal_SphBessel(ORealPtr res, const unsigned v, const ORealPtr x)
{
    LibOReal_SphBessel(res, v, x);
}



void Lib_OReal_SphNeumann(ORealPtr res, const unsigned v, const ORealPtr x)
{
    LibOReal_SphNeumann(res, v, x);
}





void Lib_OReal_BesselJPrime(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
    LibOReal_BesselJPrime(res, v, x);
}



void Lib_OReal_BesselYPrime(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
    LibOReal_BesselYPrime(res, v, x);
}



void Lib_OReal_BesselIPrime(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
    LibOReal_BesselIPrime(res, v, x);
}



void Lib_OReal_BesselKPrime(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
    LibOReal_BesselKPrime(res, v, x);
}



void Lib_OReal_SphBesselPrime(ORealPtr res, const unsigned v, const ORealPtr x)
{
    LibOReal_SphBesselPrime(res, v, x);
}



void Lib_OReal_SphNeumannPrime(ORealPtr res, const unsigned v, const ORealPtr x)
{
    LibOReal_SphNeumannPrime(res, v, x);
}





void Lib_OReal_BesselJZero(ORealPtr res, const ORealPtr v, const int m)
{
    LibOReal_BesselJZero(res, v, m);
}



void Lib_OReal_BesselYZero(ORealPtr res, const ORealPtr v, const int m)
{
    LibOReal_BesselYZero(res, v, m);
}





void Lib_OReal_GammaP(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
    LibOReal_GammaP(res, a, x);
}


void Lib_OReal_GammaQ(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
    LibOReal_GammaQ(res, a, x);
}


void Lib_OReal_TgammaLower(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
    LibOReal_TgammaLower(res, a, x);
}


void Lib_OReal_TgammaUpper(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
    LibOReal_TgammaUpper(res, a, x);
}




void Lib_OReal_GammaPInv(ORealPtr res, const ORealPtr a, const ORealPtr p)
{
    LibOReal_GammaPInv(res, a, p);
}


void Lib_OReal_GammaQInv(ORealPtr res, const ORealPtr a, const ORealPtr q)
{
    LibOReal_GammaQInv(res, a, q);
}


void Lib_OReal_GammaPInva(ORealPtr res, const ORealPtr x, const ORealPtr p)
{
    LibOReal_GammaPInva(res, x, p);
}


void Lib_OReal_GammaQInva(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
    LibOReal_GammaQInva(res, x, q);
}



void Lib_OReal_GammaPDerivative(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
    LibOReal_GammaPDerivative(res, a, x);
}


void Lib_OReal_Beta(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
    LibOReal_Beta(res, a, b);
}









void Lib_OReal_LegendreP(ORealPtr res, int n, const ORealPtr x)
{
    LibOReal_LegendreP(res, n, x);
}



void Lib_OReal_LegendreQ(ORealPtr res, int n, const ORealPtr x)
{
    LibOReal_LegendreQ(res, n, x);
}



void Lib_OReal_Laguerre(ORealPtr res, int n, const ORealPtr x)
{
    LibOReal_Laguerre(res, n, x);
}



void Lib_OReal_Hermite(ORealPtr res, int n, const ORealPtr x)
{
    LibOReal_Hermite(res, n, x);
}



void Lib_OReal_ChebyshevT(ORealPtr res, int n, const ORealPtr x)
{
    LibOReal_ChebyshevT(res, n, x);
}


void Lib_OReal_ChebyshevU(ORealPtr res, int n, const ORealPtr x)
{
    LibOReal_ChebyshevU(res, n, x);
}



void Lib_OReal_Polygamma(ORealPtr res, int n, const ORealPtr x)
{
    LibOReal_Polygamma(res, n, x);
}





void Lib_OReal_EllintRC(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
    LibOReal_EllintRC(res, x, y);
}


void Lib_OReal_Ellint1F(ORealPtr res, const ORealPtr k, const ORealPtr phi)
{
    LibOReal_Ellint1F(res, k, phi);
}


void Lib_OReal_Ellint2F(ORealPtr res, const ORealPtr k, const ORealPtr phi)
{
    LibOReal_Ellint2F(res, k, phi);
}


void Lib_OReal_Ellint3K(ORealPtr res, const ORealPtr k, const ORealPtr n)
{
    LibOReal_Ellint3K(res, k, n);
}




void Lib_OReal_JacobiCD(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiCD(res, k, u);
}


void Lib_OReal_JacobiCN(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiCN(res, k, u);
}


void Lib_OReal_JacobiCS(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiCS(res, k, u);
}


void Lib_OReal_JacobiDC(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiDC(res, k, u);
}


void Lib_OReal_JacobiDN(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiDN(res, k, u);
}


void Lib_OReal_JacobiDS(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiDS(res, k, u);
}


void Lib_OReal_JacobiNC(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiNC(res, k, u);
}


void Lib_OReal_JacobiND(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiND(res, k, u);
}


void Lib_OReal_JacobiNS(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiNS(res, k, u);
}


void Lib_OReal_JacobiSC(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiSC(res, k, u);
}


void Lib_OReal_JacobiSD(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiSD(res, k, u);
}


void Lib_OReal_JacobiSN(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
    LibOReal_JacobiSN(res, k, u);
}



void Lib_OReal_expint(ORealPtr res, const unsigned n, const ORealPtr x)
{
    LibOReal_expint(res, n, x);
}




void Lib_OReal_OwenT(ORealPtr res, const ORealPtr h, const ORealPtr a)
{
    LibOReal_OwenT(res, h, a);
}





void Lib_OReal_IBeta(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
    LibOReal_IBeta(res, a, b, x);
}


void Lib_OReal_IBetac(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
    LibOReal_IBetac(res, a, b, x);
}


void Lib_OReal_IBetaNonNormalized(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
    LibOReal_IBetaNonNormalized(res, a, b, x);
}


void Lib_OReal_IBetacNonNormalized(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
    LibOReal_IBetacNonNormalized(res, a, b, x);
}


void Lib_OReal_IBetaInv(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr p)
{
    LibOReal_IBetaInv(res, a, b, p);
}


void Lib_OReal_IBetacInv(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr q)
{
    LibOReal_IBetacInv(res, a, b, q);
}


void Lib_OReal_IBetaInva(ORealPtr res, const ORealPtr b, const ORealPtr x, const ORealPtr p)
{
    LibOReal_IBetaInva(res, b, x, p);
}


void Lib_OReal_IBetacInva(ORealPtr res, const ORealPtr b, const ORealPtr x, const ORealPtr q)
{
    LibOReal_IBetacInva(res, b, x, q);
}


void Lib_OReal_IBetaInvb(ORealPtr res, const ORealPtr a, const ORealPtr x, const ORealPtr p)
{
    LibOReal_IBetaInvb(res, a, x, p);
}


void Lib_OReal_IBetacInvb(ORealPtr res, const ORealPtr a, const ORealPtr x, const ORealPtr q)
{
    LibOReal_IBetacInvb(res, a, x, q);
}


void Lib_OReal_IBetaDerivative(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
    LibOReal_IBetaDerivative(res, a, b, x);
}




void Lib_OReal_LegendrePM(ORealPtr res, const int n, const int m, const ORealPtr x)
{
    LibOReal_LegendrePM(res, n, m, x);
}



void Lib_OReal_LaguerreM(ORealPtr res, const int n, const int m, const ORealPtr x)
{
    LibOReal_LaguerreM(res, n, m, x);
}





void Lib_OReal_EllipticRF(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z)
{
    LibOReal_EllipticRF(res, x, y, z);
}



void Lib_OReal_EllipticRD(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z)
{
    LibOReal_EllipticRD(res, x, y, z);
}



void Lib_OReal_EllipticRG(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z)
{
    LibOReal_EllipticRG(res, x, y, z);
}



void Lib_OReal_Ellint3F(ORealPtr res, const ORealPtr k, const ORealPtr n, const ORealPtr phi)
{
    LibOReal_Ellint3F(res, k, n, phi);
}




void Lib_OReal_Gegenbauer(ORealPtr res, const int n, const ORealPtr lambda, const ORealPtr x)
{
    LibOReal_Gegenbauer(res, n, lambda, x);
}



void Lib_OReal_Jacobi(ORealPtr res, const int n, const ORealPtr alpha, const ORealPtr beta, const ORealPtr x)
{
    LibOReal_Jacobi(res, n, alpha, beta, x);
}





void Lib_OReal_SphericalHarmonicR(ORealPtr res, const int n, const int m, const ORealPtr theta, const ORealPtr phi)
{
    LibOReal_SphericalHarmonicR(res, n, m, theta, phi);
}


void Lib_OReal_SphericalHarmonicI(ORealPtr res, const int n, const int m, const ORealPtr theta, const ORealPtr phi)
{
    LibOReal_SphericalHarmonicI(res, n, m, theta, phi);
}


void Lib_OReal_EllipticRJ(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z, const ORealPtr p)
{
    LibOReal_EllipticRJ(res, x, y, z, p);
}


// Hypergeometric and Theta Functions




void Lib_OReal_Hypergeo0F1(ORealPtr res, const ORealPtr b, const ORealPtr x)
{
    LibOReal_Hypergeo0F1(res, b, x);
}



void Lib_OReal_Hypergeo1F1(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
    LibOReal_Hypergeo1F1(res, a, b, x);
}



void Lib_OReal_Hypergeo1F1r(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
    LibOReal_Hypergeo1F1r(res, a, b, x);
}



void Lib_OReal_LogHypergeo1F1(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
    LibOReal_LogHypergeo1F1(res, a, b, x);
}





void Lib_OReal_JacobiTheta1(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
    LibOReal_JacobiTheta1(res, x, q);
}


void Lib_OReal_JacobiTheta2(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
    LibOReal_JacobiTheta2(res, x, q);
}


void Lib_OReal_JacobiTheta3(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
    LibOReal_JacobiTheta3(res, x, q);
}


void Lib_OReal_JacobiTheta4(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
    LibOReal_JacobiTheta4(res, x, q);
}






//***********************  Boost Distributions, OReal  **********************************


void Lib_OReal_ArcsineDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b)
{
    LibOReal_ArcsineDist(Target, res, xqp, a, b);
}



void Lib_OReal_BernoulliDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr p)
{
    LibOReal_BernoulliDist(Target, res, xqp, p);
}



void Lib_OReal_BetaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b)
{
    LibOReal_BetaDist(Target, res, xqp, a, b);
}



void Lib_OReal_BinomialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n, ORealPtr p)
{
    LibOReal_BinomialDist(Target, res, xqp, n, p);
}



void Lib_OReal_CauchyDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    LibOReal_CauchyDist(Target, res, xqp, location, scale);
}



void Lib_OReal_Chi2Dist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    LibOReal_Chi2Dist(Target, res, xqp, nu);
}



void Lib_OReal_ExponentialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lambda)
{
    LibOReal_ExponentialDist(Target, res, xqp, lambda);
}



void Lib_OReal_GumbelDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    LibOReal_ExtremeValueDist(Target, res, xqp, location, scale);
}



void Lib_OReal_FisherFDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mu, ORealPtr nu)
{
    LibOReal_FisherFDist(Target, res, xqp, mu, nu);
}



void Lib_OReal_GammaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale)
{
    LibOReal_GammaDist(Target, res, xqp, shape, scale);
}



void Lib_OReal_GeometricDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr p)
{
    LibOReal_GeometricDist(Target, res, xqp, p);
}



void Lib_OReal_HypergeometricDist(long Target, ORealPtr res, ORealPtr xqp, uint64_t r, uint64_t n, uint64_t N)
{
    LibOReal_HypergeometricDist(Target, res, xqp, r, n, N);
}



void Lib_OReal_InverseChi2Dist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr df, ORealPtr scale)
{
    LibOReal_InverseChi2Dist(Target, res, xqp, df, scale);
}



void Lib_OReal_InverseGammaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale)
{
    LibOReal_InverseGammaDist(Target, res, xqp, shape, scale);
}



void Lib_OReal_WaldDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr scale)
{
    LibOReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
}



void Lib_OReal_LaplaceDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    LibOReal_LaplaceDist(Target, res, xqp, location, scale);
}



void Lib_OReal_LogisticDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    LibOReal_LogisticDist(Target, res, xqp, location, scale);
}



void Lib_OReal_LognormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    LibOReal_LognormalDist(Target, res, xqp, location, scale);
}



void Lib_OReal_NegBinomialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n, ORealPtr p)
{
    LibOReal_NegBinomialDist(Target, res, xqp, n, p);
}


void Lib_OReal_Chi2NcDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu, ORealPtr nc)
{
    LibOReal_Chi2NCDist(Target, res, xqp, nu, nc);
}


void Lib_OReal_StudentTNcDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu, ORealPtr delta)
{
    LibOReal_StudentTNCDist(Target, res, xqp, nu, delta);
}



void Lib_OReal_FisherNcDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mu, ORealPtr nu, ORealPtr nc)
{
    LibOReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
}



void Lib_OReal_BetaNcDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b, ORealPtr nc)
{
    LibOReal_BetaNCDist(Target, res, xqp, a, b, nc);
}



void Lib_OReal_NormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr stdev)
{
    LibOReal_NormalDist(Target, res, xqp, mean_, stdev);
}



void Lib_OReal_ParetoDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale)
{
    LibOReal_ParetoDist(Target, res, xqp, shape, scale);
}



void Lib_OReal_PoissonDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    LibOReal_PoissonDist(Target, res, xqp, nu);
}



void Lib_OReal_RayleighDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    LibOReal_RayleighDist(Target, res, xqp, nu);
}



void Lib_OReal_SkewNormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr scale, ORealPtr shape)
{
    LibOReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
}



void Lib_OReal_StudentTDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    LibOReal_StudentTDist(Target, res, xqp, nu);
}



void Lib_OReal_TriangularDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lower, ORealPtr mode_, ORealPtr upper)
{
    LibOReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
}



void Lib_OReal_WeibullDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale)
{
    LibOReal_WeibullDist(Target, res, xqp, shape, scale);
}



void Lib_OReal_UniformDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lower, ORealPtr upper)
{
    LibOReal_UniformDist(Target, res, xqp, lower, upper);
}



//*********************** New , octuple precision **********************************




void Lib_OReal_Logaddexp(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
    LibOReal_Logaddexp(res, a, b);
}



void Lib_OReal_HyperexponentialDist(long Target, ORealPtr res, ORealPtr xqp, mpNumMatrixPtr l1, mpNumMatrixPtr l2)
{
    LibOReal_HyperexponentialDist(Target, res, xqp, (OStatePtr)l1, (OStatePtr)l2);
}



void Lib_OReal_KolmogorovSmirnovDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n)
{
    LibOReal_KolmogorovSmirnovDist(Target, res, xqp, n);
}







//*********************** Boost Numerical Calculus, OReal **********************************




void Lib_OReal_BracketRoot(ORealPtr res1, ORealPtr res2, int* iter, ORealFuncPtr f1, ORealPtr guess_, ORealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    LibOReal_BracketRoot(res1, res2, iter, f1, guess_, factor_, is_rising, get_digits, maxit);
}



void Lib_OReal_NewtonRaphson(ORealPtr res,  int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibOReal_NewtonRaphson(res, iter, f1, f2, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_OReal_Halley(ORealPtr res, int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibOReal_Halley(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_OReal_Schroder(ORealPtr res, int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibOReal_Schroder(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_OReal_Brent_Minimum(ORealPtr res, ORealPtr resFx, int* iter, ORealFuncPtr f1, ORealPtr bracket_min_, ORealPtr bracket_max_, int bits, unsigned int maxit)
{
    LibOReal_Brent_Minimum(res, resFx, iter, f1, bracket_min_, bracket_max_, bits, maxit);
}





void Lib_OReal_Trapezoidal(ORealPtr res1, ORealPtr res2, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_)
{
    LibOReal_Trapezoidal(res1, res2, res3, f1, a_, b_);
}



// 7, 15, 20, 25 and 30

void Lib_OReal_GaussLegendre(ORealPtr res1, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_)
{
    LibOReal_GaussLegendre(res1, res3, f1, a_, b_);
}



//15, 31, 41, 51 and 61

void Lib_OReal_GaussKronrod(ORealPtr res1, ORealPtr res2, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_)
{
    LibOReal_GaussKronrod(res1, res2, res3, f1, a_, b_);
}



void Lib_OReal_TanhSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_)
{
    LibOReal_TanhSinh(res1, res2, res3, levels_, f1, a_, b_);
}




void Lib_OReal_SinhSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1)
{
    LibOReal_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_OReal_ExpSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1)
{
    LibOReal_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_OReal_Ooura_Cos(ORealPtr res1, ORealPtr res2, ORealFuncPtr f1)
{
    LibOReal_Ooura_Cos(res1, res2, f1);
}



void Lib_OReal_Ooura_Sin(ORealPtr res1, ORealPtr res2, ORealFuncPtr f1)
{
    LibOReal_Ooura_Sin(res1, res2, f1);
}









//*********************** Boost Odeint **********************************


AnyPtr Lib_OReal_StateInit_Func_N(int N)
{
    return LibOReal_StateInit_Func_N(N);
}


void Lib_OReal_StateClear(mpNumMatrixPtr x)
{
    return LibOReal_StateClear((OStatePtr) x);
}


void Lib_OReal_StateGetCoeff(ScalarPtr res, long row, mpNumMatrixPtr source)
{
    LibOReal_StateGetCoeff((ORealPtr) res, row, (OStatePtr) source);
}

void Lib_OReal_StateSetCoeff(mpNumMatrixPtr result, ScalarPtr source, long row)
{
    LibOReal_StateSetCoeff((OStatePtr) result, (ORealPtr) source, row);
}


void Lib_OReal_StateGetSize(long *result, mpNumMatrixPtr x)
{
    LibOReal_StateGetSize(result, (OStatePtr)x);
}


void Lib_OReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    LibOReal_Const_RungeKutta4((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_OReal_Const_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    LibOReal_Const_RungeKuttaCashKarp54((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_OReal_Const_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    LibOReal_Const_RungeKuttaDopri5((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_OReal_Const_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    LibOReal_Const_RungeKuttaFehlberg78((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_OReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    LibOReal_Const_AdamsBashforthMoulton((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_);
}


void Lib_OReal_Adaptive_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    LibOReal_Adaptive_RungeKuttaDopri5((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_OReal_Adaptive_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    LibOReal_Adaptive_RungeKuttaCashKarp54((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_OReal_Adaptive_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    LibOReal_Adaptive_RungeKuttaFehlberg78((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_OReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    LibOReal_Adaptive_BulirschStoer((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_OReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    LibOReal_DenseOutput_Dopri5((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_OReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    LibOReal_DenseOutput_BulirschStoer((OAnyFuncPtr3)f1, (OAnyFuncPtr2)f2, (OStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}



































