
#include "mpNumC_Main.h"
#include "BoostXReal.h"

#include "stdint.h"
#include <complex>
#include <vector>
#include <iostream>
#include <limits>
#include "float.h"

using namespace std;
using namespace std::numbers;





/** ********************** Real Basic Functions, extended precision ******************************** **/


long double* Lib_XReal_Init_Func()
{
	long double* x = NULL;
	x = (long double*)malloc(sizeof(long double));
	*x = -1.0L;
	return x;
}

void Lib_XReal_Clear(long double* x)
{
	free(x);
}



/* Input and output  */


void Lib_XReal_Set(long double* res, const long double* x)
{
	*res = (*x);
}
//
//void Lib_XReal_Set_Fmpq(long double* res, const FmpqPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	fmpq_get_mpfr (temp, (fmpq*)x, MPFR_RNDN);
//	*res = mpfr_get_ld(temp, MPFR_RNDN);
//    mpfr_clear(temp);
//}
//
//void Lib_XReal_Set_Arb(long double* res, const ArbPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	arf_get_mpfr(temp, arb_midref((arb_ptr)x), MPFR_RNDN);
//	*res = mpfr_get_ld(temp, MPFR_RNDN);
//	mpfr_clear(temp);
//}
//
//void Lib_XReal_Set_Arf(long double* res, const ArfPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	arf_get_mpfr(temp, (arf_ptr)x, MPFR_RNDN);
//	*res = mpfr_get_ld(temp, MPFR_RNDN);
//	mpfr_clear(temp);
//}
//
//void Lib_XReal_Set_Mpfi(long double* res, const MpfiPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//    mpfi_mid ((mpfr_ptr)temp, (mpfi_ptr)x);
//    *res = mpfr_get_ld(temp, MPFR_RNDN);
//	mpfr_clear(temp);
//}
//
//void Lib_XReal_Set_Mpfr(long double* res, const MpfrPtr x)
//{
//	*res = mpfr_get_ld((mpfr_ptr)x, MPFR_RNDN);
//}
//
//void Lib_XReal_Set_Mpd(long double* res, const MpdPtr x)
//{
//	char * src = mpd_to_sci((mpd_t *)x, 1);
//    *res = std::strtold(src, NULL);
//	free(src);
//}
//
//void Lib_XReal_Set_C34Real(long double* res, const YRealPtr x)
//{
////    char buffer[128];
////    Lib_CReal_Get_Str(buffer, x);
////    *res = std::strtold(buffer, NULL);
//}

void Lib_XReal_Set_QReal(long double* res, const QRealPtr x)
{
	*res = (*(__float128*)x);
}

void Lib_XReal_Set_LD(long double* res, const long double* x)
{
	*res = (*x);
}

void Lib_XReal_Set_D(long double* res, const double x)
{
	*res = x;
}

void Lib_XReal_Set_S(long double* res, const float* x)
{
	*res = (*x);
}


void Lib_XReal_Set_Si(long double* res, const int32_t x)
{
	*res = x;
}

void Lib_XReal_Set_Ui(long double* res, const uint32_t x)
{
	*res = x;
}

void Lib_XReal_Set_Si64(long double* res, const int64_t x)
{
	*res = x;
}

void Lib_XReal_Set_Ui64(long double* res, const uint64_t x)
{
	*res = x;
}


/* Missing: Lib_XReal_Get_Str */



void Lib_XReal_Set_Str(long double* res, const char * str)
{
    *res = std::strtold(str, NULL);
}

double Lib_XReal_Get_Double(long double* x)
{
    return *x;
}





/* Operator overloading vs raw arithmetic and comparisons  */


void Lib_XReal_Neg(long double* res, const long double* x)
{
	*res = -(*x);
}

void Lib_XReal_Add(long double* res, const long double* x, const long double* y)
{
	*res = (*x) + (*y);
}

void Lib_XReal_Sub(long double* res, const long double* x, const long double* y)
{
	*res = (*x) - (*y);
}

void Lib_XReal_Mul(long double* res, const long double* x, const long double* y)
{
	*res = (*x) * (*y);
}

void Lib_XReal_Div(long double* res, const long double* x, const long double* y)
{
	*res = (*x) / (*y);
}


void Lib_XReal_Add_D(long double* res, const long double* x, const double y)
{
	*res = (*x) + y;
}

void Lib_XReal_Sub_D(long double* res, const long double* x, const double y)
{
	*res = (*x) - y;
}

void Lib_XReal_D_Sub(long double* res, const long double* x, const double y)
{
	*res = y - (*x);
}

void Lib_XReal_Mul_D(long double* res, const long double* x, const double y)
{
	*res = (*x) * y;
}

void Lib_XReal_Div_D(long double* res, const long double* x, const double y)
{
	*res = (*x) / y;
}

void Lib_XReal_D_Div(long double* res, const long double* x, const double y)
{
	*res = y / (*x);
}



void Lib_XReal_Add_Si(long double* res, const long double* x, const int32_t y)
{
	*res = (*x) + y;
}

void Lib_XReal_Sub_Si(long double* res, const long double* x, const int32_t y)
{
	*res = (*x) - y;
}

void Lib_XReal_Si_Sub(long double* res, const long double* x, const int32_t y)
{
	*res = y - (*x);
}

void Lib_XReal_Mul_Si(long double* res, const long double* x, const int32_t y)
{
	*res = (*x) * y;
}

void Lib_XReal_Div_Si(long double* res, const long double* x, const int32_t y)
{
	*res = (*x) / y;
}

void Lib_XReal_Si_Div(long double* res, const long double* x, const int32_t y)
{
	*res = y / (*x);
}



int32_t Lib_XReal_LT(const long double* x, const long double* y)
{
	return (*x) < (*y);
}

int32_t Lib_XReal_GE(const long double* x, const long double* y)
{
	return (*x) >= (*y);
}

int32_t Lib_XReal_GT(const long double* x, const long double* y)
{
	return (*x) > (*y);
}

int32_t Lib_XReal_LE(const long double* x, const long double* y)
{
	return (*x) <= (*y);
}

int32_t Lib_XReal_EQ(const long double* x, const long double* y)
{
	return (*x) == (*y);
}

int32_t Lib_XReal_NE(const long double* x, const long double* y)
{
	return (*x) != (*y);
}







/* General functions for real numbers  */

void Lib_XReal_Fma(long double* res, const long double* x, const long double* y, const long double* z)
{
	*res = fmal( (*x) , (*y) , (*z) );
}

void Lib_XReal_Fmax(long double* res, const long double* x, const long double* y)
{
	*res = fmaxl( (*x) , (*y) );
}

void Lib_XReal_Fmin(long double* res, const long double* x, const long double* y)
{
	*res = fminl( (*x) , (*y) );
}





/* Machine constants and properties of numbers  */


void Lib_XReal_Zero(long double* res)
{
	*res = 0.0L;
}

void Lib_XReal_NegZero(long double* res)
{
	*res = -0.0L;
}

void Lib_XReal_One(long double* res)
{
	*res = 1.0L;
}

void Lib_XReal_Inf(long double* res)
{
	*res = (std::numeric_limits<long double>::infinity)();
}

void Lib_XReal_NegInf(long double* res)
{
	*res = -(std::numeric_limits<long double>::infinity)();
}

void Lib_XReal_Nan(long double* res)
{
	*res = std::numeric_limits<long double>::quiet_NaN();
}




/* Properties of numbers  */

int Lib_XReal_Signbit(const long double* x)
{
	return int(std::signbit(*x));
}

int Lib_XReal_Finite(const long double* x)
{
	return std::isfinite(*x);
}

int Lib_XReal_Isinf(const long double* x)
{
	return std::isinf(*x);
}

int Lib_XReal_Isposinf(const long double* x)
{
	return (std::isinf(*x) & (*x > 0.0));
}

int Lib_XReal_Isneginf(const long double* x)
{
	return (std::isinf(*x) & (*x < 0.0));
}

int Lib_XReal_Isnan(const long double* x)
{
	return std::isnan(*x);
}




int Lib_XReal_Iszero(const long double* x)
{
	return (std::abs(*x) == 0.0L);
}

int Lib_XReal_Isposzero(const long double* x)
{
	return ((int(std::signbit(*x)) == 0) & (std::abs(*x) == 0.0L));
}

int Lib_XReal_Isnegzero(const long double* x)
{
	return ((int(std::signbit(*x)) != 0) & (std::abs(*x) == 0.0L));
}

int Lib_XReal_Isone(const long double* x)
{
	return (*x == 1.0L);
}

int Lib_XReal_Isinteger(const long double* x)
{
	return (std::ceil(*x) == std::floor(*x));
}

int Lib_XReal_Isnumber(const long double* x)
{
	return (!(std::isnan(*x) || (std::isinf(*x))));
}

int Lib_XReal_Isregular(const long double* x)
{
	return (!(std::isnan(*x) || (std::isinf(*x) || (std::abs(*x) == 0.0L))));
}

int Lib_XReal_Isnormal(const long double* x)
{
	return (std::isnormal(*x));
}

int Lib_XReal_Issubnormal(const long double* x)
{
	return (std::fpclassify(*x)) == FP_SUBNORMAL;
}

int Lib_XReal_Isunordered(const long double* x, const long double* y)
{
	return (std::isunordered(*x, *y));
}



int Lib_XReal_FitsInt32(const long double* x)
{
	return  ((*x <= std::numeric_limits<int32_t>::max()) &
             (*x >= std::numeric_limits<int32_t>::min()));
}

int Lib_XReal_FitsInt64(const long double* x)
{
	return  ((*x <= std::numeric_limits<int64_t>::max()) &
             (*x >= std::numeric_limits<int64_t>::min()));
}

int Lib_XReal_FitsUInt32(const long double* x)
{
	return  ((*x <= std::numeric_limits<uint32_t>::max()) &
             (*x >= std::numeric_limits<uint32_t>::min()));
}

int Lib_XReal_FitsUInt64(const long double* x)
{
	return  ((*x <= std::numeric_limits<uint64_t>::max()) &
             (*x >= std::numeric_limits<uint64_t>::min()));
}





/* Integer Related Functions  */

void Lib_XReal_Nearbyint(long double* res, const long double* x)
{
	*res = nearbyintl(*x);
}

void Lib_XReal_Rint(long double* res, const long double* x)
{
	*res = rintl(*x);
}

long int Lib_XReal_Lrint(const long double* x)
{
	return lrintl(*x);
}

long long int Lib_XReal_Llrint(const long double* x)
{
	return llrintl(*x);
}


void Lib_XReal_Ceil(long double* res, const long double* x)
{
	*res = ceill(*x);
}

void Lib_XReal_Floor(long double* res, const long double* x)
{
	*res = floorl(*x);
}

void Lib_XReal_Trunc(long double* res, const long double* x)
{
	*res = truncl(*x);
}

void Lib_XReal_Round(long double* res, const long double* x)
{
	*res = roundl(*x);
}

long int Lib_XReal_Lround(const long double* x)
{
	return lroundl(*x);
}

long long int Lib_XReal_Llround(const long double* x)
{
	return llroundl(*x);
}

int32_t Lib_XReal_ToInt32(const long double* x)
{
    if (*x >= std::numeric_limits<int32_t>::max())
        return std::numeric_limits<int32_t>::max();
    else if (*x <= std::numeric_limits<int32_t>::min())
        return std::numeric_limits<int32_t>::min();
    else
        return (int32_t) (*x);
}

int64_t Lib_XReal_ToInt64(const long double* x)
{
    if (*x >= std::numeric_limits<int64_t>::max())
        return std::numeric_limits<int64_t>::max();
    else if (*x <= std::numeric_limits<int64_t>::min())
        return std::numeric_limits<int64_t>::min();
    else
        return (int64_t) (*x);
}

uint32_t Lib_XReal_ToUInt32(const long double* x)
{
    if (*x >= std::numeric_limits<uint32_t>::max())
        return std::numeric_limits<uint32_t>::max();
    else if (*x <= std::numeric_limits<uint32_t>::min())
        return std::numeric_limits<uint32_t>::min();
    else
        return (uint32_t) (*x);
}

uint64_t Lib_XReal_ToUInt64(const long double* x)
{
    if (*x >= std::numeric_limits<uint64_t>::max())
        return std::numeric_limits<uint64_t>::max();
    else if (*x <= std::numeric_limits<uint64_t>::min())
        return std::numeric_limits<uint64_t>::min();
    else
        return (uint64_t) (*x);
}








/* Floating point functions for real numbers */

void Lib_XReal_Copysign(long double* res, const long double* x, const long double* y)
{
	*res = copysignl( (*x) , (*y) );
}

void Lib_XReal_Frexp(long double* res, const long double* x, int* e)
{
	*res = frexpl(*(long double*)x, e);
}

void Lib_XReal_Logb(long double* res, const long double* x)
{
	*res = logbl(*(long double*)x);
}

int Lib_XReal_Ilogb(const long double* x)
{
	return ilogbl(*x);
}

void Lib_XReal_Ldexp(long double* res, const long double* x, const int e)
{
	*res = ldexpl(*x, e);
}

void Lib_XReal_Scalbln(long double* res, const long double* x, const long int e)
{
	*res = scalblnl(*x, e);
}

void Lib_XReal_Scalbn(long double* res, const long double* x, const int e)
{
	*res = scalbnl(*x, e);
}

void Lib_XReal_Fdim(long double* res, const long double* x, const long double* y)
{
	*res = fdiml( (*x) , (*y) );
}




/* Fraction and Remainder Related Functions  */

void Lib_XReal_Modf(long double* frac, const long double* x, long double* iptr)
{
	*frac = modfl(*x, iptr);
}

void Lib_XReal_Fmod(long double* res, const long double* x, const long double* y)
{
	*res = fmodl(*x , *y);
}

void Lib_XReal_Remainder(long double* res, const long double* x, const long double* y)
{
	*res = remainderl( (*x) , (*y) );
}

void Lib_XReal_Remquo(long double* res, const long double* x, const long double* y, int* e)
{
	*res = remquol( (*x) , (*y), e );
}




/* Functions related to mantissa width and exponent range */

void Lib_XReal_Epsilon(long double* res)
{
	*res = (std::numeric_limits<long double>::epsilon)();
}

void Lib_XReal_Ulp(long double* res, const long double* x)
{
	LibXReal_Ulp(res, x);
}

void Lib_XReal_Max(long double* res)
{
	*res = (std::numeric_limits<long double>::max)();
}

void Lib_XReal_Lowest(long double* res)
{
	*res = (std::numeric_limits<long double>::lowest)();
}

void Lib_XReal_Min(long double* res)
{
	*res = (std::numeric_limits<long double>::min)();
}

void Lib_XReal_Nexttoward(long double* res, const long double* x, const long double* y)
{
	*res = nexttowardl( (*x) , (*y) );
}

void Lib_XReal_Nextabove(long double* res, const long double* x)
{
	*res = nexttowardl( (*x) , (std::numeric_limits<long double>::infinity)() );
}

void Lib_XReal_Nextbelow(long double* res, const long double* x)
{
	*res = nexttowardl( (*x) , -(std::numeric_limits<long double>::infinity)() );
}




/* Complex components  */

void Lib_XReal_Fabs(long double* res, const long double* x)
{
	*res = fabsl(*x);
}

void Lib_XReal_Sign(long double* res, const long double* x)
{
	*res = (long double)((*x > 0) - (*x < 0));
}





/* Mathematical Constants  */

void Lib_XReal_ConstDegree(long double* res)
{
	*res = pi_v<long double> / 180;
}

void Lib_XReal_ConstPhi(long double* res)
{
	*res = phi_v<long double>;
}

void Lib_XReal_ConstLog2(long double* res)
{
	*res = ln2_v<long double>;
}

void Lib_XReal_ConstLog10(long double* res)
{
	*res = ln10_v<long double>;
}

void Lib_XReal_ConstPi(long double* res)
{
	*res = pi_v<long double>;
}

void Lib_XReal_ConstE(long double* res)
{
	*res = e_v<long double>;
}

void Lib_XReal_ConstEulerGamma(long double* res)
{
	*res = egamma_v<long double>;
}

void Lib_XReal_ConstApery(long double* res)
{
	*res = 1.2020569031595942853997381615114499914L;
}

void Lib_XReal_ConstCatalan(long double* res)
{
	*res = 0.91596559417721901505460351493238411094L;
}

void Lib_XReal_ConstGlaisher(long double* res)
{
	*res = 1.2824271291006226368753425688697917282L;
}

void Lib_XReal_ConstKhinchin(long double* res)
{
	*res = 2.6854520010653064453097148354817956937L;
}






/* Roots and related functions  */

void Lib_XReal_Sqrt(long double* res, const long double* x)
{
	*res = sqrtl(*x);
}

void Lib_XReal_Sqrt1pm1(long double* res, const long double* x)
{
    *res = expm1l(log1p((*x))*0.5);
}

void Lib_XReal_Rsqrt(long double* res, const long double* x)
{
	*res = (1.0L) / sqrtl(*x);
}

void Lib_XReal_Cbrt(long double* res, const long double* x)
{
	*res = cbrtl(*x);
}


void Lib_XReal_Root_Si(long double* res, const long double* x, const int32_t k)
{
	*res = powl(*x, (1.0L)/k);
}



/* Exponential and related functions  */

void Lib_XReal_Exp(long double* res, const long double* x)
{
	*res = expl(*x);
}

void Lib_XReal_Exp2(long double* res, const long double* x)
{
	*res = exp2l(*x);
}

void Lib_XReal_Exp10(long double* res, const long double* x)
{
    *res = expl((*x) * ln10_v<long double>);
}

void Lib_XReal_Expm1(long double* res, const long double* x)
{
	*res = expm1l(*x);
}

void Lib_XReal_Exp2m1(long double* res, const long double* x)
{
	*res = expm1l((*x) * ln2_v<long double>);
}

void Lib_XReal_Exp10m1(long double* res, const long double* x)
{
	*res = expm1l((*x) * ln10_v<long double>);
}



/* Logarithms and related functions  */

void Lib_XReal_Log(long double* res, const long double* x)
{
	*res = logl(*x);
}

void Lib_XReal_Log2(long double* res, const long double* x)
{
	*res = log2l(*x);
}

void Lib_XReal_Log10(long double* res, const long double* x)
{
	*res = log10l(*x);
}

void Lib_XReal_Log1p(long double* res, const long double* x)
{
	*res = log1pl(*x);
}

void Lib_XReal_Log2p1(long double* res, const long double* x)
{
	*res = log1pl(*x) / ln2_v<long double>;
}

void Lib_XReal_Log10p1(long double* res, const long double* x)
{
	*res = log1pl(*x) / ln10_v<long double>;
}




/* Power functions and roots  */

void Lib_XReal_Square(long double* res, const long double* x)
{
	*res = (*x) * (*x);
}

void Lib_XReal_Cube(long double* res, const long double* x)
{
	*res = (*x) * (*x) * (*x);
}



void Lib_XReal_Hypot(long double* res, const long double* x, const long double* y)
{
	*res = hypotl( (*x) , (*y) );
}

void Lib_XReal_Pow(long double* res, const long double* x, const long double* y)
{
	*res = powl( (*x) , (*y) );
}

void Lib_XReal_Powm1(long double* res, const long double* x, const long double* y)
{
    *res = expm1l(log((*x)) * (*y));
}

void Lib_XReal_Pow1p(long double* res, const long double* x, const long double* y)
{
    *res = expl(log1p((*x)) * (*y));
}

void Lib_XReal_Pow1pm1(long double* res, const long double* x, const long double* y)
{
    *res = expm1l(log1p((*x)) * (*y));
}

void Lib_XReal_Pow_Si(long double* res, const long double* x, const int32_t n)
{
	*res = powl( (*x) , n );
}

void Lib_XReal_Compound_Si(long double* res, const long double* x, const int32_t n)
{
	*res = powl((1.0L) + (*x) , n );
}




/* Trigonometric functions  */

void Lib_XReal_Sin(long double* res, const long double* x)
{
	*res = sinl(*x);
}

void Lib_XReal_Cos(long double* res, const long double* x)
{
	*res = cosl(*x);
}


long double cosm1l(long double x)
{
    if (std::abs(x) > 0.5)
    {
        return std::cos(x) - 1;
    }
    else
    {
        long double res = std::sin((x)/2);
        return  -2 * res * res;
    }
}

void Lib_XReal_Cosm1(long double* res, const long double* x)
{
	*res = cosm1l(*x);
}


void Lib_XReal_Tan(long double* res, const long double* x)
{
	*res = tanl(*x);
}


void Lib_XReal_Csc(long double* res, const long double* x)
{
	*res = (1.0L) / sinl(*x);
}

void Lib_XReal_Sec(long double* res, const long double* x)
{
	*res = (1.0L) / cosl(*x);
}

void Lib_XReal_Cot(long double* res, const long double* x)
{
	*res = (1.0L) / tanl(*x);
}



void Lib_XReal_SinPi(long double* res, const long double* x)
{
    LibXReal_SinPi(res, x);
}

void Lib_XReal_CosPi(long double* res, const long double* x)
{
    LibXReal_CosPi(res, x);
}

void Lib_XReal_TanPi(long double* res, const long double* x)
{
    LibXReal_TanPi(res, x);
}



void Lib_XReal_CscPi(long double* res, const long double* x)
{
    LibXReal_CscPi(res, x);
}

void Lib_XReal_SecPi(long double* res, const long double* x)
{
    LibXReal_SecPi(res, x);
}

void Lib_XReal_CotPi(long double* res, const long double* x)
{
    LibXReal_CotPi(res, x);
}



/* Hyperbolic functions  */

void Lib_XReal_Sinh(long double* res, const long double* x)
{
	*res = sinhl(*x);
}

void Lib_XReal_Cosh(long double* res, const long double* x)
{
	*res = coshl(*x);
}

void Lib_XReal_Tanh(long double* res, const long double* x)
{
	*res = tanhl(*x);
}


void Lib_XReal_Csch(long double* res, const long double* x)
{
	*res = (1.0L) / sinhl(*x);
}

void Lib_XReal_Sech(long double* res, const long double* x)
{
	*res = (1.0L) / coshl(*x);
}

void Lib_XReal_Coth(long double* res, const long double* x)
{
	*res = (1.0L) / tanhl(*x);
}







/* Inverse trigonometric functions  */

void Lib_XReal_Asin(long double* res, const long double* x)
{
	*res = asinl(*x);
}

void Lib_XReal_Acos(long double* res, const long double* x)
{
	*res = acosl(*x);
}

void Lib_XReal_Atan(long double* res, const long double* x)
{
	*res = atanl(*x);
}

void Lib_XReal_Atan2(long double* res, const long double* x, const long double* y)
{
	*res = atan2l( (*x) , (*y) );
}


void Lib_XReal_Acsc(long double* res, const long double* x)
{
	*res = asinl((1.0L) / (*x));
}

void Lib_XReal_Asec(long double* res, const long double* x)
{
	*res = acosl((1.0L) / (*x));
}

void Lib_XReal_Acot(long double* res, const long double* x)
{
	*res = atanl((1.0L) / (*x));
}



/* Inverse hyperbolic functions  */

void Lib_XReal_Asinh(long double* res, const long double* x)
{
	*res = asinhl(*x);
}

void Lib_XReal_Acosh(long double* res, const long double* x)
{
	*res = acoshl(*x);
}

void Lib_XReal_Atanh(long double* res, const long double* x)
{
	*res = atanhl(*x);
}


void Lib_XReal_Acsch(long double* res, const long double* x)
{
	*res = asinhl((1.0L) / (*x));
}

void Lib_XReal_Asech(long double* res, const long double* x)
{
	*res = acoshl((1.0L) / (*x));
}

void Lib_XReal_Acoth(long double* res, const long double* x)
{
	*res = atanhl((1.0L) / (*x));
}






/* Special functions  */

void Lib_XReal_Erf(long double* res, const long double* x)
{
	*res = erfl(*x);
}

void Lib_XReal_Erfc(long double* res, const long double* x)
{
	*res = erfcl(*x);
}

void Lib_XReal_Tgamma(long double* res, const long double* x)
{
	*res = tgammal(*x);
}

void Lib_XReal_Lgamma(long double* res, const long double* x)
{
	*res = lgammal(*x);
}



void Lib_XReal_BesselJ0(long double* res, const long double* x)
{
	*res = std::cyl_bessel_jl(0.0L, *x);
}

void Lib_XReal_BesselJ1(long double* res, const long double* x)
{
	*res = std::cyl_bessel_jl(1.0L, *x);
}

void Lib_XReal_BesselJn(long double* res, const long double* n, const long double* x)
{
	*res = std::cyl_bessel_jl(*n, *x);
}


void Lib_XReal_BesselY0(long double* res, const long double* x)
{
	*res = std::cyl_neumannl(0.0L, *x);
}

void Lib_XReal_BesselY1(long double* res, const long double* x)
{
	*res = std::cyl_neumannl(1.0L, *x);
}

void Lib_XReal_BesselYn(long double* res, const long double* n, const long double* x)
{
	*res = std::cyl_neumannl(*n, *x);
}












/** ********************** Complex Basic Functions, extended precision ******************************** **/



XCplxPtr Lib_XCplx_Init_Func()
{
	XCplxPtr x = NULL;
	x = (std::complex<long double>*) malloc(sizeof(std::complex<long double>));
	return x;
}

void Lib_XCplx_Clear(XCplxPtr x)
{
	free(x);
}


/* Input and output  */

void Lib_XCplx_Set(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res)  = (*(std::complex<long double>*) x);
}


/* Operator overloading vs raw arithmetic and comparisons  */

void Lib_XCplx_Neg(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = -(*(std::complex<long double>*) x);
}

void Lib_XCplx_Add(XCplxPtr res, const XCplxPtr x, const XCplxPtr y)
{
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) + (*(std::complex<long double>*) y);
}

void Lib_XCplx_Sub(XCplxPtr res, const XCplxPtr x, const XCplxPtr y)
{
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) - (*(std::complex<long double>*) y);
}

void Lib_XCplx_Mul(XCplxPtr res, const XCplxPtr x, const XCplxPtr y)
{
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) * (*(std::complex<long double>*) y);
}

void Lib_XCplx_Div(XCplxPtr res, const XCplxPtr x, const XCplxPtr y)
{
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) / (*(std::complex<long double>*) y);
}


void Lib_XCplx_Add_XReal(XCplxPtr res, const XCplxPtr x, const long double* y)
{
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) + (*y);
}

void Lib_XCplx_Sub_XReal(XCplxPtr res, const XCplxPtr x, const long double* y)
{
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) - (*y);
}

void Lib_XCplx_XReal_Sub(XCplxPtr res, const XCplxPtr y, const long double* x)
{
	(*(std::complex<long double>*) res) = (*x) - (*(std::complex<long double>*) y);
}

void Lib_XCplx_Mul_XReal(XCplxPtr res, const XCplxPtr x, const long double* y)
{
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) * (*y);
}

void Lib_XCplx_Div_XReal(XCplxPtr res, const XCplxPtr x, const long double* y)
{
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) / (*y);
}

void Lib_XCplx_XReal_Div(XCplxPtr res, const XCplxPtr y, const long double* x)
{
	(*(std::complex<long double>*) res) = (*x) / (*(std::complex<long double>*) y);
}


void Lib_XCplx_Add_D(XCplxPtr res, const XCplxPtr x, const double y)
{
    long double temp = y;
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) + temp;
}

void Lib_XCplx_Sub_D(XCplxPtr res, const XCplxPtr x, const double y)
{
    long double temp = y;
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) - temp;
}

void Lib_XCplx_D_Sub(XCplxPtr res, const XCplxPtr y, const double x)
{
    long double temp = x;
	(*(std::complex<long double>*) res) = temp - (*(std::complex<long double>*) y);
}

void Lib_XCplx_Mul_D(XCplxPtr res, const XCplxPtr x, const double y)
{
    long double temp = y;
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) * temp;
}

void Lib_XCplx_Div_D(XCplxPtr res, const XCplxPtr x, const double y)
{
    long double temp = y;
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) / temp;
}

void Lib_XCplx_D_Div(XCplxPtr res, const XCplxPtr y, const double x)
{
    long double temp = x;
	(*(std::complex<long double>*) res) = temp / (*(std::complex<long double>*) y);
}


void Lib_XCplx_Add_Si(XCplxPtr res, const XCplxPtr x, const int32_t y)
{
    long double temp = y;
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) + temp;
}

void Lib_XCplx_Sub_Si(XCplxPtr res, const XCplxPtr x, const int32_t y)
{
    long double temp = y;
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) - temp;
}

void Lib_XCplx_Si_Sub(XCplxPtr res, const XCplxPtr y, const int32_t x)
{
    long double temp = x;
	(*(std::complex<long double>*) res) = temp - (*(std::complex<long double>*) y);
}

void Lib_XCplx_Mul_Si(XCplxPtr res, const XCplxPtr x, const int32_t y)
{
    long double temp = y;
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) * temp;
}

void Lib_XCplx_Div_Si(XCplxPtr res, const XCplxPtr x, const int32_t y)
{
    long double temp = y;
	(*(std::complex<long double>*) res) = (*(std::complex<long double>*) x) / temp;
}

void Lib_XCplx_Si_Div(XCplxPtr res, const XCplxPtr y, const int32_t x)
{
    long double temp = x;
	(*(std::complex<long double>*) res) = temp / (*(std::complex<long double>*) y);
}



/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void Lib_XCplx_Set_Real(XCplxPtr res, const long double* re)
{
	(*(std::complex<long double>*) res) = std::complex<long double>(*re, 0);
}

void Lib_XCplx_Set2(XCplxPtr res, const long double* re, const long double* im)
{
	(*(std::complex<long double>*) res) = std::complex<long double>(*re, *im);
}


void Lib_XCplx_Abs(long double* res, const XCplxPtr x)
{
	*res = std::abs(*(std::complex<long double>*) x);
}

void Lib_XCplx_Arg(long double* res, const XCplxPtr x)
{
	*res = std::arg(*(std::complex<long double>*) x);
}

void Lib_XCplx_Imag(long double* res, const XCplxPtr x)
{
	*res = (*(std::complex<long double>*) x).imag();
}

void Lib_XCplx_Real(long double* res, const XCplxPtr x)
{
	*res = (*(std::complex<long double>*) x).real();
}

void Lib_XCplx_Conj(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::conj(*(std::complex<long double>*) x);
}

void Lib_XCplx_Proj(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::proj(*(std::complex<long double>*) x);
}






/* Roots  */


std::complex<long double> cplx_expm1l(std::complex<long double> z)
{
    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
	long double x = z.real();
	long double y = z.imag();
	long double resx =  std::expm1(x) * std::cos(y) + cosm1l(y);
	long double resy =  std::exp(x) * std::sin(y);
	return std::complex<long double>(resx, resy);
}

std::complex<long double> cplx_log1pl(std::complex<long double> z)
{
    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
    /* resy =  atan2(y, 1 + x); */
	long double x = z.real();
	long double y = z.imag();
	long double resx = 0.0 ;
	if ( (std::abs(x) > 0.75) || (std::abs(y) > 0.75) || (x < -0.5) )
    {
        resx = std::log(std::hypot(1 + x, y)) ;
    }
    else
    {
        resx = 0.5 * std::log1p(2*x + x*x + y*y);
    }
	long double resy = std::atan2(y, 1 + x);
	return std::complex<long double>(resx, resy);
}


void Lib_XCplx_Sqrt(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::sqrt(*(std::complex<long double>*) x);
}


void Lib_XCplx_Sqrt1pm1(XCplxPtr res, const XCplxPtr x)
{
    (*(std::complex<long double>*) res) = cplx_expm1l(cplx_log1pl(*(std::complex<long double>*) x) * (0.5L));
}


void Lib_XCplx_Rsqrt(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = (1.0L) / std::sqrt(*(std::complex<long double>*) x);
}


void Lib_XCplx_Cbrt(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::pow(*(std::complex<long double>*) x, (1.0L)/(3.0L));
}


void Lib_XCplx_Root_Si(XCplxPtr res, const XCplxPtr x, const int32_t k)
{
	(*(std::complex<long double>*) res) = std::pow(*(std::complex<long double>*) x, (1.0L)/k);
}




/* Exponential and related functions  */

void Lib_XCplx_Exp(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::exp(*(std::complex<long double>*) x);
}


void Lib_XCplx_Exp2(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::exp( (*(std::complex<long double>*) x) * ln2_v<long double>);
}


void Lib_XCplx_Exp10(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::exp( (*(std::complex<long double>*) x) * ln10_v<long double>);
}


void Lib_XCplx_Expm1(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) =  cplx_expm1l(*(std::complex<long double>*) x);
}


void Lib_XCplx_Exp2m1(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) =  cplx_expm1l((*(std::complex<long double>*) x) * ln2_v<long double>);
}


void Lib_XCplx_Exp10m1(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) =  cplx_expm1l((*(std::complex<long double>*) x) * ln10_v<long double>);
}



/* Logarithms and related functions  */

void Lib_XCplx_Log(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::log(*(std::complex<long double>*) x);
}

void Lib_XCplx_Log2(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::log(*(std::complex<long double>*) x) / ln2_v<long double>;
}

void Lib_XCplx_Log10(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::log10(*(std::complex<long double>*) x);
}

void Lib_XCplx_Log1p(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = cplx_log1pl(*(std::complex<long double>*) x);
}

void Lib_XCplx_Log2p1(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = cplx_log1pl(*(std::complex<long double>*) x) / ln2_v<long double>;
}

void Lib_XCplx_Log10p1(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = cplx_log1pl(*(std::complex<long double>*) x) / ln10_v<long double>;
}





/* Power functions */

void Lib_XCplx_Square(XCplxPtr res, const XCplxPtr x)
{
    std::complex<long double> z = *(std::complex<long double>*) x;
	(*(std::complex<long double>*) res) = z * z;
}

void Lib_XCplx_Cube(XCplxPtr res, const XCplxPtr x)
{
    std::complex<long double> z = *(std::complex<long double>*) x;
	(*(std::complex<long double>*) res) = z * z * z;
}

void Lib_XCplx_Pow(XCplxPtr res, const XCplxPtr x, const XCplxPtr y)
{
	(*(std::complex<long double>*) res) = std::pow(*(std::complex<long double>*) x, *(std::complex<long double>*) y);
}

void Lib_XCplx_Powm1(XCplxPtr res, const XCplxPtr x, const XCplxPtr y)
{
    (*(std::complex<long double>*) res) = cplx_expm1l(std::log(*(std::complex<long double>*) x) * (*(std::complex<long double>*) y));
}

void Lib_XCplx_Pow1p(XCplxPtr res, const XCplxPtr x, const XCplxPtr y)
{
    (*(std::complex<long double>*) res) = std::exp(cplx_log1pl(*(std::complex<long double>*) x) * (*(std::complex<long double>*) y));
}

void Lib_XCplx_Pow1pm1(XCplxPtr res, const XCplxPtr x, const XCplxPtr y)
{
    (*(std::complex<long double>*) res) = cplx_expm1l(cplx_log1pl(*(std::complex<long double>*) x) * (*(std::complex<long double>*) y));
}

void Lib_XCplx_Pow_Si(XCplxPtr res, const XCplxPtr x, const int32_t k)
{
	(*(std::complex<long double>*) res) = std::pow(*(std::complex<long double>*) x, k);
}

void Lib_XCplx_Compound_Si(XCplxPtr res, const XCplxPtr x, const int32_t k)
{
	(*(std::complex<long double>*) res) = std::pow((1.0L) + (*(std::complex<long double>*) x), k);
}





/* Trigonometric functions  */

void Lib_XCplx_Sin(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::sin(*(std::complex<long double>*) x);
}

void Lib_XCplx_Cos(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::cos(*(std::complex<long double>*) x);
}

void Lib_XCplx_Tan(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::tan(*(std::complex<long double>*) x);
}

void Lib_XCplx_Csc(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = (1.0L) / std::sin(*(std::complex<long double>*) x);
}

void Lib_XCplx_Sec(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = (1.0L) / std::cos(*(std::complex<long double>*) x);
}

void Lib_XCplx_Cot(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = (1.0L) / std::tan(*(std::complex<long double>*) x);
}



void Lib_XCplx_SinPi(XCplxPtr res, const XCplxPtr z)
{
//	(*(std::complex<long double>*) res) = std::sin(*(std::complex<long double>*) x);
}

void Lib_XCplx_CosPi(XCplxPtr res, const XCplxPtr x)
{
//	(*(std::complex<long double>*) res) = std::cos(*(std::complex<long double>*) x);
}

void Lib_XCplx_TanPi(XCplxPtr res, const XCplxPtr x)
{
//	(*(std::complex<long double>*) res) = std::tan(*(std::complex<long double>*) x);
}




/* Hyperbolic functions  */

void Lib_XCplx_Sinh(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::sinh(*(std::complex<long double>*) x);
}

void Lib_XCplx_Cosh(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::cosh(*(std::complex<long double>*) x);
}

void Lib_XCplx_Tanh(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::tanh(*(std::complex<long double>*) x);
}

void Lib_XCplx_Csch(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = (1.0L) / std::sinh(*(std::complex<long double>*) x);
}

void Lib_XCplx_Sech(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = (1.0L) / std::cosh(*(std::complex<long double>*) x);
}

void Lib_XCplx_Coth(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = (1.0L) / std::tanh(*(std::complex<long double>*) x);
}





/* Inverse trigonometric functions  */

void Lib_XCplx_Asin(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::asin(*(std::complex<long double>*) x);
}

void Lib_XCplx_Acos(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::acos(*(std::complex<long double>*) x);
}

void Lib_XCplx_Atan(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::atan(*(std::complex<long double>*) x);
}


void Lib_XCplx_Acsc(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::asin((1.0L) / (*(std::complex<long double>*) x));
}

void Lib_XCplx_Asec(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::acos((1.0L) / (*(std::complex<long double>*) x));
}

void Lib_XCplx_Acot(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::atan((1.0L) / (*(std::complex<long double>*) x));
}






/* Inverse hyperbolic functions  */

void Lib_XCplx_Asinh(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::asinh(*(std::complex<long double>*) x);
}

void Lib_XCplx_Acosh(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::acosh(*(std::complex<long double>*) x);
}

void Lib_XCplx_Atanh(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::atanh(*(std::complex<long double>*) x);
}



void Lib_XCplx_Acsch(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::asinh((1.0L) / (*(std::complex<long double>*) x));
}

void Lib_XCplx_Asech(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::acosh((1.0L) / (*(std::complex<long double>*) x));
}

void Lib_XCplx_Acoth(XCplxPtr res, const XCplxPtr x)
{
	(*(std::complex<long double>*) res) = std::atanh((1.0L) / (*(std::complex<long double>*) x));
}















//*********************** Boost Special functions , extended precision **********************************



void Lib_XReal_BernoulliB2n(long double* res, const int n)
{
    LibXReal_BernoulliB2n(res, n);
}



void Lib_XReal_TangentT2n(long double* res, const int n)
{
    LibXReal_TangentT2n(res, n);
}



void Lib_XReal_Sqrt1pm1_Boost(long double* res, const long double* x)
{
    LibXReal_Sqrt1pm1(res, x);
}



void Lib_XReal_SinPi_Boost(long double* res, const long double* x)
{
    LibXReal_SinPi(res, x);
}



void Lib_XReal_CosPi_Boost(long double* res, const long double* x)
{
    LibXReal_CosPi(res, x);
}



void Lib_XReal_SincPi(long double* res, const long double* x)
{
    LibXReal_SincPi(res, x);
}



void Lib_XReal_SinhcPi(long double* res, const long double* x)
{
    LibXReal_SinhcPi(res, x);
}



void Lib_XReal_Tgamma_(long double* res, const long double* x)
{
    LibXReal_Tgamma_(res, x);
}


void Lib_XReal_Tgamma1pm1(long double* res, const long double* x)
{
    LibXReal_Tgamma1pm1(res, x);
}



void Lib_XReal_Lgamma_(long double* res, const long double* x)
{
    LibXReal_Lgamma_(res, x);
}



void Lib_XReal_Digamma(long double* res, const long double* x)
{
    LibXReal_Digamma(res, x);
}



void Lib_XReal_Trigamma(long double* res, const long double* x)
{
    LibXReal_Trigamma(res, x);
}



void Lib_XReal_Factorial(long double* res, const long double* x)
{
    LibXReal_Factorial(res, x);
}



void Lib_XReal_DoubleFactorial(long double* res, const long double* x)
{
    LibXReal_DoubleFactorial(res, x);
}





void Lib_XReal_Erf_(long double* res, const long double* x)
{
    LibXReal_Erf_(res, x);
}



void Lib_XReal_Erfc_(long double* res, const long double* x)
{
    LibXReal_Erfc_(res, x);
}



void Lib_XReal_Erf_inv(long double* res, const long double* x)
{
    LibXReal_Erf_inv(res, x);
}



void Lib_XReal_Erfc_inv(long double* res, const long double* x)
{
    LibXReal_Erfc_inv(res, x);
}



void Lib_XReal_AiryAi(long double* res, const long double* x)
{
    LibXReal_AiryAi(res, x);
}



void Lib_XReal_AiryBi(long double* res, const long double* x)
{
    LibXReal_AiryBi(res, x);
}



void Lib_XReal_AiryAiPrime(long double* res, const long double* x)
{
    LibXReal_AiryAiPrime(res, x);
}



void Lib_XReal_AiryBiPrime(long double* res, const long double* x)
{
    LibXReal_AiryBiPrime(res, x);
}



void Lib_XReal_Aizero(long double* res, const int n)
{
    LibXReal_Aizero(res, n);
}



void Lib_XReal_Bizero(long double* res, const int n)
{
    LibXReal_Bizero(res, n);
}



void Lib_XReal_Ellint_1_K(long double* res, const long double* x)
{
    LibXReal_Ellint_1_K(res, x);
}



void Lib_XReal_Ellint_2_K(long double* res, const long double* x)
{
    LibXReal_Ellint_2_K(res, x);
}



void Lib_XReal_Zeta(long double* res, const long double* x)
{
    LibXReal_Zeta(res, x);
}



void Lib_XReal_Ei(long double* res, const long double* x)
{
    LibXReal_Ei(res, x);
}



void Lib_XReal_LambertW0(long double* res, const long double* x)
{
    LibXReal_LambertW0(res, x);
}


void Lib_XReal_LambertWm1(long double* res, const long double* x)
{
    LibXReal_LambertWm1(res, x);
}



void Lib_XReal_LambertW0Prime(long double* res, const long double* x)
{
    LibXReal_LambertW0Prime(res, x);
}


void Lib_XReal_LambertWm1Prime(long double* res, const long double* x)
{
    LibXReal_LambertWm1Prime(res, x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void Lib_XReal_Agm(long double* res, const long double* a, const long double* b)
{
    LibXReal_Agm(res, a, b);
}




void Lib_XReal_Powm1_Boost(long double* res, const long double* a, const long double* b)
{
    LibXReal_Powm1(res, a, b);
}



void Lib_XReal_TgammaRatio(long double* res, const long double* a, const long double* b)
{
    LibXReal_TgammaRatio(res, a, b);
}



void Lib_XReal_TgammaDeltaRatio(long double* res, const long double* a, const long double* b)
{
    LibXReal_TgammaDeltaRatio(res, a, b);
}



void Lib_XReal_Binomial(long double* res, const long double* n, const long double* k)
{
    LibXReal_Binomial(res, n, k);
}

void Lib_XReal_RisingFactorial(long double* res, const long double* x, const long double* n)
{
    LibXReal_RisingFactorial(res, x, n);
}




void Lib_XReal_FallingFactorial(long double* res, const long double* x, const long double* n)
{
    LibXReal_FallingFactorial(res, x, n);
}




void Lib_XReal_BesselJ(long double* res, const long double* v, const long double* x)
{
    LibXReal_BesselJ(res, v, x);
}



void Lib_XReal_BesselY(long double* res, const long double* v, const long double* x)
{
    LibXReal_BesselY(res, v, x);
}



void Lib_XReal_BesselI(long double* res, const long double* v, const long double* x)
{
    LibXReal_BesselI(res, v, x);
}



void Lib_XReal_BesselK(long double* res, const long double* v, const long double* x)
{
    LibXReal_BesselK(res, v, x);
}



void Lib_XReal_SphBessel(long double* res, const unsigned v, const long double* x)
{
    LibXReal_SphBessel(res, v, x);
}



void Lib_XReal_SphNeumann(long double* res, const unsigned v, const long double* x)
{
    LibXReal_SphNeumann(res, v, x);
}





void Lib_XReal_BesselJPrime(long double* res, const long double* v, const long double* x)
{
    LibXReal_BesselJPrime(res, v, x);
}



void Lib_XReal_BesselYPrime(long double* res, const long double* v, const long double* x)
{
    LibXReal_BesselYPrime(res, v, x);
}



void Lib_XReal_BesselIPrime(long double* res, const long double* v, const long double* x)
{
    LibXReal_BesselIPrime(res, v, x);
}



void Lib_XReal_BesselKPrime(long double* res, const long double* v, const long double* x)
{
    LibXReal_BesselKPrime(res, v, x);
}



void Lib_XReal_SphBesselPrime(long double* res, const unsigned v, const long double* x)
{
    LibXReal_SphBesselPrime(res, v, x);
}



void Lib_XReal_SphNeumannPrime(long double* res, const unsigned v, const long double* x)
{
    LibXReal_SphNeumannPrime(res, v, x);
}





void Lib_XReal_BesselJZero(long double* res, const long double* v, const int m)
{
    LibXReal_BesselJZero(res, v, m);
}



void Lib_XReal_BesselYZero(long double* res, const long double* v, const int m)
{
    LibXReal_BesselYZero(res, v, m);
}





void Lib_XReal_GammaP(long double* res, const long double* a, const long double* x)
{
    LibXReal_GammaP(res, a, x);
}


void Lib_XReal_GammaQ(long double* res, const long double* a, const long double* x)
{
    LibXReal_GammaQ(res, a, x);
}


void Lib_XReal_TgammaLower(long double* res, const long double* a, const long double* x)
{
    LibXReal_TgammaLower(res, a, x);
}


void Lib_XReal_TgammaUpper(long double* res, const long double* a, const long double* x)
{
    LibXReal_TgammaUpper(res, a, x);
}




void Lib_XReal_GammaPInv(long double* res, const long double* a, const long double* p)
{
    LibXReal_GammaPInv(res, a, p);
}


void Lib_XReal_GammaQInv(long double* res, const long double* a, const long double* q)
{
    LibXReal_GammaQInv(res, a, q);
}


void Lib_XReal_GammaPInva(long double* res, const long double* x, const long double* p)
{
    LibXReal_GammaPInva(res, x, p);
}


void Lib_XReal_GammaQInva(long double* res, const long double* x, const long double* q)
{
    LibXReal_GammaQInva(res, x, q);
}



void Lib_XReal_GammaPDerivative(long double* res, const long double* a, const long double* x)
{
    LibXReal_GammaPDerivative(res, a, x);
}


void Lib_XReal_Beta(long double* res, const long double* a, const long double* b)
{
    LibXReal_Beta(res, a, b);
}









void Lib_XReal_LegendreP(long double* res, int n, const long double* x)
{
    LibXReal_LegendreP(res, n, x);
}



void Lib_XReal_LegendreQ(long double* res, int n, const long double* x)
{
    LibXReal_LegendreQ(res, n, x);
}



void Lib_XReal_Laguerre(long double* res, int n, const long double* x)
{
    LibXReal_Laguerre(res, n, x);
}



void Lib_XReal_Hermite(long double* res, int n, const long double* x)
{
    LibXReal_Hermite(res, n, x);
}



void Lib_XReal_ChebyshevT(long double* res, int n, const long double* x)
{
    LibXReal_ChebyshevT(res, n, x);
}


void Lib_XReal_ChebyshevU(long double* res, int n, const long double* x)
{
    LibXReal_ChebyshevU(res, n, x);
}



void Lib_XReal_Polygamma(long double* res, int n, const long double* x)
{
    LibXReal_Polygamma(res, n, x);
}





void Lib_XReal_EllintRC(long double* res, const long double* x, const long double* y)
{
    LibXReal_EllintRC(res, x, y);
}


void Lib_XReal_Ellint1F(long double* res, const long double* k, const long double* phi)
{
    LibXReal_Ellint1F(res, k, phi);
}


void Lib_XReal_Ellint2F(long double* res, const long double* k, const long double* phi)
{
    LibXReal_Ellint2F(res, k, phi);
}


void Lib_XReal_Ellint3K(long double* res, const long double* k, const long double* n)
{
    LibXReal_Ellint3K(res, k, n);
}




void Lib_XReal_JacobiCD(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiCD(res, k, u);
}


void Lib_XReal_JacobiCN(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiCN(res, k, u);
}


void Lib_XReal_JacobiCS(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiCS(res, k, u);
}


void Lib_XReal_JacobiDC(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiDC(res, k, u);
}


void Lib_XReal_JacobiDN(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiDN(res, k, u);
}


void Lib_XReal_JacobiDS(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiDS(res, k, u);
}


void Lib_XReal_JacobiNC(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiNC(res, k, u);
}


void Lib_XReal_JacobiND(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiND(res, k, u);
}


void Lib_XReal_JacobiNS(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiNS(res, k, u);
}


void Lib_XReal_JacobiSC(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiSC(res, k, u);
}


void Lib_XReal_JacobiSD(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiSD(res, k, u);
}


void Lib_XReal_JacobiSN(long double* res, const long double* k, const long double* u)
{
    LibXReal_JacobiSN(res, k, u);
}



void Lib_XReal_expint(long double* res, const unsigned n, const long double* x)
{
    LibXReal_expint(res, n, x);
}




void Lib_XReal_OwenT(long double* res, const long double* h, const long double* a)
{
    LibXReal_OwenT(res, h, a);
}





void Lib_XReal_IBeta(long double* res, const long double* a, const long double* b, const long double* x)
{
    LibXReal_IBeta(res, a, b, x);
}


void Lib_XReal_IBetac(long double* res, const long double* a, const long double* b, const long double* x)
{
    LibXReal_IBetac(res, a, b, x);
}


void Lib_XReal_IBetaNonNormalized(long double* res, const long double* a, const long double* b, const long double* x)
{
    LibXReal_IBetaNonNormalized(res, a, b, x);
}


void Lib_XReal_IBetacNonNormalized(long double* res, const long double* a, const long double* b, const long double* x)
{
    LibXReal_IBetacNonNormalized(res, a, b, x);
}


void Lib_XReal_IBetaInv(long double* res, const long double* a, const long double* b, const long double* p)
{
    LibXReal_IBetaInv(res, a, b, p);
}


void Lib_XReal_IBetacInv(long double* res, const long double* a, const long double* b, const long double* q)
{
    LibXReal_IBetacInv(res, a, b, q);
}


void Lib_XReal_IBetaInva(long double* res, const long double* b, const long double* x, const long double* p)
{
    LibXReal_IBetaInva(res, b, x, p);
}


void Lib_XReal_IBetacInva(long double* res, const long double* b, const long double* x, const long double* q)
{
    LibXReal_IBetacInva(res, b, x, q);
}


void Lib_XReal_IBetaInvb(long double* res, const long double* a, const long double* x, const long double* p)
{
    LibXReal_IBetaInvb(res, a, x, p);
}


void Lib_XReal_IBetacInvb(long double* res, const long double* a, const long double* x, const long double* q)
{
    LibXReal_IBetacInvb(res, a, x, q);
}


void Lib_XReal_IBetaDerivative(long double* res, const long double* a, const long double* b, const long double* x)
{
    LibXReal_IBetaDerivative(res, a, b, x);
}




void Lib_XReal_LegendrePM(long double* res, const int n, const int m, const long double* x)
{
    LibXReal_LegendrePM(res, n, m, x);
}



void Lib_XReal_LaguerreM(long double* res, const int n, const int m, const long double* x)
{
    LibXReal_LaguerreM(res, n, m, x);
}





void Lib_XReal_EllipticRF(long double* res, const long double* x, const long double* y, const long double* z)
{
    LibXReal_EllipticRF(res, x, y, z);
}



void Lib_XReal_EllipticRD(long double* res, const long double* x, const long double* y, const long double* z)
{
    LibXReal_EllipticRD(res, x, y, z);
}



void Lib_XReal_EllipticRG(long double* res, const long double* x, const long double* y, const long double* z)
{
    LibXReal_EllipticRG(res, x, y, z);
}



void Lib_XReal_Ellint3F(long double* res, const long double* k, const long double* n, const long double* phi)
{
    LibXReal_Ellint3F(res, k, n, phi);
}




void Lib_XReal_Gegenbauer(long double* res, const int n, const long double* lambda, const long double* x)
{
    LibXReal_Gegenbauer(res, n, lambda, x);
}


void Lib_XReal_Jacobi(long double* res, const int n, const long double* alpha, const long double* beta, const long double* x)
{
    LibXReal_Jacobi(res, n, alpha, beta, x);
}









void Lib_XReal_SphericalHarmonicR(long double* res, const int n, const int m, const long double* theta, const long double* phi)
{
    LibXReal_SphericalHarmonicR(res, n, m, theta, phi);
}


void Lib_XReal_SphericalHarmonicI(long double* res, const int n, const int m, const long double* theta, const long double* phi)
{
    LibXReal_SphericalHarmonicI(res, n, m, theta, phi);
}


void Lib_XReal_EllipticRJ(long double* res, const long double* x, const long double* y, const long double* z, const long double* p)
{
    LibXReal_EllipticRJ(res, x, y, z, p);
}


// Hypergeometric and Theta Functions




void Lib_XReal_Hypergeo0F1(long double* res, const long double* b, const long double* x)
{
    LibXReal_Hypergeo0F1(res, b, x);
}



void Lib_XReal_Hypergeo1F1(long double* res, const long double* a, const long double* b, const long double* x)
{
    LibXReal_Hypergeo1F1(res, a, b, x);
}



void Lib_XReal_Hypergeo1F1r(long double* res, const long double* a, const long double* b, const long double* x)
{
    LibXReal_Hypergeo1F1r(res, a, b, x);
}



void Lib_XReal_LogHypergeo1F1(long double* res, const long double* a, const long double* b, const long double* x)
{
    LibXReal_LogHypergeo1F1(res, a, b, x);
}





void Lib_XReal_JacobiTheta1(long double* res, const long double* x, const long double* q)
{
    LibXReal_JacobiTheta1(res, x, q);
}


void Lib_XReal_JacobiTheta2(long double* res, const long double* x, const long double* q)
{
    LibXReal_JacobiTheta2(res, x, q);
}


void Lib_XReal_JacobiTheta3(long double* res, const long double* x, const long double* q)
{
    LibXReal_JacobiTheta3(res, x, q);
}


void Lib_XReal_JacobiTheta4(long double* res, const long double* x, const long double* q)
{
    LibXReal_JacobiTheta4(res, x, q);
}





//*********************** Distributions **********************************


void Lib_XReal_ArcsineDist(long Target, long double* res, long double* xqp, long double* a, long double* b)
{
    LibXReal_ArcsineDist(Target, res, xqp, a, b);
}


void Lib_XReal_BernoulliDist(long Target, long double* res, long double* xqp, long double* p)
{
    LibXReal_BernoulliDist(Target, res, xqp, p);
}


void Lib_XReal_BetaDist(long Target, long double* res, long double* xqp, long double* a, long double* b)
{
    LibXReal_BetaDist(Target, res, xqp, a, b);
}


void Lib_XReal_BinomialDist(long Target, long double* res, long double* xqp, long double* n, long double* p)
{
    LibXReal_BinomialDist(Target, res, xqp, n, p);
}


void Lib_XReal_CauchyDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_CauchyDist(Target, res, xqp, location, scale);
}


void Lib_XReal_Chi2Dist(long Target, long double* res, long double* xqp, long double* nu)
{
    LibXReal_Chi2Dist(Target, res, xqp, nu);
}

void Lib_XReal_ExponentialDist(long Target, long double* res, long double* xqp, long double* lambda)
{
    LibXReal_ExponentialDist(Target, res, xqp, lambda);
}


void Lib_XReal_GumbelDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_ExtremeValueDist(Target, res, xqp, location, scale);
}


void Lib_XReal_FisherFDist(long Target, long double* res, long double* xqp, long double* mu, long double* nu)
{
    LibXReal_FisherFDist(Target, res, xqp, mu, nu);
}


void Lib_XReal_GammaDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale)
{
    LibXReal_GammaDist(Target, res, xqp, shape, scale);
}


void Lib_XReal_GeometricDist(long Target, long double* res, long double* xqp, long double* p)
{
    LibXReal_GeometricDist(Target, res, xqp, p);
}


void Lib_XReal_HypergeometricDist(long Target, long double* res, long double* xqp, uint64_t r, uint64_t n, uint64_t N)
{
    LibXReal_HypergeometricDist(Target, res, xqp, r, n, N);
}


void Lib_XReal_InverseChi2Dist(long Target, long double* res, long double* xqp, long double* df, long double* scale)
{
    LibXReal_InverseChi2Dist(Target, res, xqp, df, scale);
}



void Lib_XReal_InverseGammaDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale)
{
    LibXReal_InverseGammaDist(Target, res, xqp, shape, scale);
}


void Lib_XReal_WaldDist(long Target, long double* res, long double* xqp, long double* mean_, long double* scale)
{
    LibXReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
}


void Lib_XReal_LaplaceDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_LaplaceDist(Target, res, xqp, location, scale);
}


void Lib_XReal_LogisticDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_LogisticDist(Target, res, xqp, location, scale);
}


void Lib_XReal_LognormalDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_LognormalDist(Target, res, xqp, location, scale);
}


void Lib_XReal_NegBinomialDist(long Target, long double* res, long double* xqp, long double* n, long double* p)
{
    LibXReal_NegBinomialDist(Target, res, xqp, n, p);
}


void Lib_XReal_Chi2NcDist(long Target, long double* res, long double* xqp, long double* nu, long double* nc)
{
    LibXReal_Chi2NCDist(Target, res, xqp, nu, nc);
}


void Lib_XReal_StudentTNcDist(long Target, long double* res, long double* xqp, long double* nu, long double* delta)
{
    LibXReal_StudentTNCDist(Target, res, xqp, nu, delta);
}


void Lib_XReal_FisherNcDist(long Target, long double* res, long double* xqp, long double* mu, long double* nu, long double* nc)
{
    LibXReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
}


void Lib_XReal_BetaNcDist(long Target, long double* res, long double* xqp, long double* a, long double* b, long double* nc)
{
    LibXReal_BetaNCDist(Target, res, xqp, a, b, nc);
}


void Lib_XReal_NormalDist(long Target, long double* res, long double* xqp, long double* mean_, long double* stdev)
{
    LibXReal_NormalDist(Target, res, xqp, mean_, stdev);
}


void Lib_XReal_ParetoDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale)
{
    LibXReal_ParetoDist(Target, res, xqp, shape, scale);
}


void Lib_XReal_PoissonDist(long Target, long double* res, long double* xqp, long double* nu)
{
    LibXReal_PoissonDist(Target, res, xqp, nu);
}


void Lib_XReal_RayleighDist(long Target, long double* res, long double* xqp, long double* nu)
{
    LibXReal_RayleighDist(Target, res, xqp, nu);
}


void Lib_XReal_SkewNormalDist(long Target, long double* res, long double* xqp, long double* mean_, long double* scale, long double* shape)
{
    LibXReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
}


void Lib_XReal_StudentTDist(long Target, long double* res, long double* xqp, long double* nu)
{
    LibXReal_StudentTDist(Target, res, xqp, nu);
}


void Lib_XReal_TriangularDist(long Target, long double* res, long double* xqp, long double* lower, long double* mode_, long double* upper)
{
    LibXReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
}


void Lib_XReal_WeibullDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale)
{
    LibXReal_WeibullDist(Target, res, xqp, shape, scale);
}


void Lib_XReal_UniformDist(long Target, long double* res, long double* xqp, long double* lower, long double* upper)
{
    LibXReal_UniformDist(Target, res, xqp, lower, upper);
}





//*********************** New , extended precision **********************************




void Lib_XReal_Logaddexp(long double* res, const long double* a, const long double* b)
{
    LibXReal_Logaddexp(res, a, b);
}



void Lib_XReal_HyperexponentialDist(long Target, long double* res, long double* xqp, mpNumMatrixPtr l1, mpNumMatrixPtr l2)
{
    LibXReal_HyperexponentialDist(Target, res, xqp, (XStatePtr)l1, (XStatePtr)l2);
}


void Lib_XReal_KolmogorovSmirnovDist(long Target, long double* res, long double* xqp, long double* n)
{
    LibXReal_KolmogorovSmirnovDist(Target, res, xqp, n);
}


void Lib_XReal_HoltsmarkDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_HoltsmarkDist(Target, res, xqp, location, scale);
}


void Lib_XReal_LandauDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_LandauDist(Target, res, xqp, location, scale);
}


void Lib_XReal_MapAiryDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_MapAiryDist(Target, res, xqp, location, scale);
}


void Lib_XReal_Saspoint5Dist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    LibXReal_Saspoint5Dist(Target, res, xqp, location, scale);
}










//*********************** Extra **********************************




void Lib_XReal_Pi(long double* res)
{
	LibXReal_Pi(res);
}



void Lib_XReal_E(long double* res)
{
	LibXReal_E(res);
}


void ShowExtNet(char* cstr, const long double* d)
{
    LibXReal_ShowExtNet(cstr, d);
}



//*********************** Numerical Calculus **********************************





void Lib_XReal_BracketRoot(long double* res1, long double* res2, int* iter, XRealFuncPtr f1, long double* guess, long double* factor, bool is_rising, int get_digits, unsigned int maxit)
{
    LibXReal_BracketRoot(res1, res2, iter, f1, guess, factor, is_rising, get_digits, maxit);
}



void Lib_XReal_NewtonRaphson(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit)
{
    LibXReal_NewtonRaphson(res, iter, f1, f2, guess, xmin, xmax, get_digits, maxit);
}



void Lib_XReal_Halley(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit)
{
    LibXReal_Halley(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
}



void Lib_XReal_Schroder(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit)
{
    LibXReal_Schroder(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
}



void Lib_XReal_Brent_Minimum(long double* res, long double* resFx, int* iter, XRealFuncPtr f1, long double* bracket_min, long double* bracket_max, int bits, unsigned int maxit)
{
    LibXReal_Brent_Minimum(res, resFx, iter, f1, bracket_min, bracket_max, bits, maxit);
}




void Lib_XReal_Trapezoidal(long double* res1, long double* res2, long double* res3, XRealFuncPtr f1, long double* a, long double* b)
{
    LibXReal_Trapezoidal(res1, res2, res3, f1, a, b);
}


// 7, 15, 20, 25 and 30

void Lib_XReal_GaussLegendre(long double* res1, long double* res3, XRealFuncPtr f1, long double* a, long double* b)
{
    LibXReal_GaussLegendre(res1, res3, f1, a, b);
}



//15, 31, 41, 51 and 61

void Lib_XReal_GaussKronrod(long double* res1, long double* res2, long double* res3, XRealFuncPtr f1, long double* a, long double* b)
{
    LibXReal_GaussKronrod(res1, res2, res3, f1, a, b);
}



void Lib_XReal_TanhSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1, long double* a, long double* b)
{
    LibXReal_TanhSinh(res1, res2, res3, levels_, f1, a, b);
}



void Lib_XReal_SinhSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1)
{
    LibXReal_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_XReal_ExpSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1)
{
    LibXReal_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_XReal_Ooura_Cos(long double* res1, long double* res2, XRealFuncPtr f1)
{
    LibXReal_Ooura_Cos(res1, res2, f1);
}



void Lib_XReal_Ooura_Sin(long double* res1, long double* res2, XRealFuncPtr f1)
{
    LibXReal_Ooura_Sin(res1, res2, f1);
}




//*********************** Boost Odeint **********************************


void Lib_XReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt)
{
	LibXReal_Const_RungeKutta4((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_XReal_Const_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt)
{
	LibXReal_Const_RungeKuttaCashKarp54((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_XReal_Const_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt)
{
	LibXReal_Const_RungeKuttaDopri5((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_XReal_Const_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt)
{
	LibXReal_Const_RungeKuttaFehlberg78((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_XReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt)
{
	LibXReal_Const_AdamsBashforthMoulton((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt);
}



void Lib_XReal_Adaptive_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel)
{
	LibXReal_Adaptive_RungeKuttaDopri5((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_XReal_Adaptive_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel)
{
	LibXReal_Adaptive_RungeKuttaCashKarp54((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_XReal_Adaptive_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel)
{
	LibXReal_Adaptive_RungeKuttaFehlberg78((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_XReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel)
{
	LibXReal_Adaptive_BulirschStoer((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_XReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel)
{
	LibXReal_DenseOutput_Dopri5((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_XReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, long double* start_time, long double* end_time, long double* dt, long double* eps_abs, long double* eps_rel)
{
	LibXReal_DenseOutput_BulirschStoer((XAnyFuncPtr3)f1, (XAnyFuncPtr2)f2, (XStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}

























