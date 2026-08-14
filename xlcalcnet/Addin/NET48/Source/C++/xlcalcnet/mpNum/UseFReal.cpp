
#include "mpNumC_Main.h"
#include "BoostFReal.h"
//#include "BoostFReal_2.h"

#include "stdint.h"
#include <complex>
#include <vector>
#include <iostream>
#include <limits>
#include "float.h"
//#include "Helperfunctions.h"
#include <numbers>

using namespace std;
using namespace std::numbers;




/** ********************** Real Basic Functions, double precision ******************************** **/

//
//double* Lib_FReal_Init_Func()
//{
//	double* x = NULL;
//	x = (double*)malloc(sizeof(double));
//	*x = 0.0;
//	return x;
//}
//
//void Lib_FReal_Clear(double* x)
//{
//	free(x);
//}
//
//
//
///* Input and output  */
//
//
//void Lib_FReal_Set(double* res, const double* x)
//{
//	*res = (*x);
//}
//
////void Lib_FReal_Set_Fmpq(double* res, const FmpqPtr x)
////{
////    mpfr_t temp; mpfr_init(temp);
////	fmpq_get_mpfr (temp, (fmpq*)x, MPFR_RNDN);
////	*res = mpfr_get_ld(temp, MPFR_RNDN);
////    mpfr_clear(temp);
////}
////
////void Lib_FReal_Set_Arb(double* res, const ArbPtr x)
////{
////	*res = arf_get_d(arb_midref((arb_ptr)x), ARF_RND_NEAR);
////}
////
////void Lib_FReal_Set_Arf(double* res, const ArfPtr x)
////{
////	*res = arf_get_d((arf_ptr)x, ARF_RND_NEAR);
////}
////
////void Lib_FReal_Set_Mpfi(double* res, const MpfiPtr x)
////{
////	*res = mpfi_get_d((mpfi_ptr)x);
////}
////
////void Lib_FReal_Set_Mpfr(double* res, const MpfrPtr x)
////{
////	*res = mpfr_get_ld((mpfr_ptr)x, MPFR_RNDN);
////}
//
////void Lib_FReal_Set_Mpd(double* res, const MpdPtr x)
////{
////	char * src = mpd_to_sci((mpd_t *)x, 1);
////    *res = std::strtold(src, NULL);
////	free(src);
////}
//
//void Lib_FReal_Set_C34Real(double* res, const CRealPtr x)
//{
////    char buffer[128];
////    Lib_CReal_Get_Str(buffer, x);
////    *res = std::strtold(buffer, NULL);
//}

void Lib_FReal_Set_QReal(double* res, const QRealPtr x)
{
	*res = (*(__float128*)x);
}

void Lib_FReal_Set_LD(double* res, const double* x)
{
	*res = (*x);
}

//void Lib_FReal_Set_D(double* res, const double x)
//{
//	*res = x;
//}
//
//void Lib_FReal_Set_S(double* res, const float* x)
//{
//	*res = (*x);
//}
//
//
//
//
//
//
//
//
//
//
//
//void Lib_FReal_Set_Si(double* res, const int32_t x)
//{
//	*res = x;
//}
//
//void Lib_FReal_Set_Ui(double* res, const uint32_t x)
//{
//	*res = x;
//}
//
//void Lib_FReal_Set_Si64(double* res, const int64_t x)
//{
//	*res = x;
//}
//
//void Lib_FReal_Set_Ui64(double* res, const uint64_t x)
//{
//	*res = x;
//}
//
//void Lib_FReal_Get_Str(char * dest, const char* template1, const double* x)
//{
//    snprintf (dest, 128, "%1.14e", *x);
//}

void Lib_FReal_Set_Str(double* res, const char * str)
{
    *res = std::strtod(str, NULL);
}
//
//double Lib_FReal_Get_Double(double* x)
//{
//    return *x;
//}
//
//
//
//
//
///* Operator overloading vs raw arithmetic and comparisons  */
//
//void Lib_FReal_Neg(double* res, const double* x)
//{
//	*res = -(*x);
//}
//
//void Lib_FReal_Add(double* res, const double* x, const double* y)
//{
//	*res = (*x) + (*y);
//}
//
//void Lib_FReal_Sub(double* res, const double* x, const double* y)
//{
//	*res = (*x) - (*y);
//}
//
//void Lib_FReal_Mul(double* res, const double* x, const double* y)
//{
//	*res = (*x) * (*y);
//}
//
//void Lib_FReal_Div(double* res, const double* x, const double* y)
//{
//	*res = (*x) / (*y);
//}
//
//
//void Lib_FReal_Add_D(double* res, const double* x, const double y)
//{
//	*res = (*x) + y;
//}
//
//void Lib_FReal_Sub_D(double* res, const double* x, const double y)
//{
//	*res = (*x) - y;
//}
//
//void Lib_FReal_D_Sub(double* res, const double* x, const double y)
//{
//	*res = y - (*x);
//}
//
//void Lib_FReal_Mul_D(double* res, const double* x, const double y)
//{
//	*res = (*x) * y;
//}
//
//void Lib_FReal_Div_D(double* res, const double* x, const double y)
//{
//	*res = (*x) / y;
//}
//
//void Lib_FReal_D_Div(double* res, const double* x, const double y)
//{
//	*res = y / (*x);
//}
//
//
//
//void Lib_FReal_Add_Si(double* res, const double* x, const int32_t y)
//{
//	*res = (*x) + y;
//}
//
//void Lib_FReal_Sub_Si(double* res, const double* x, const int32_t y)
//{
//	*res = (*x) - y;
//}
//
//void Lib_FReal_Si_Sub(double* res, const double* x, const int32_t y)
//{
//	*res = y - (*x);
//}
//
//void Lib_FReal_Mul_Si(double* res, const double* x, const int32_t y)
//{
//	*res = (*x) * y;
//}
//
//void Lib_FReal_Div_Si(double* res, const double* x, const int32_t y)
//{
//	*res = (*x) / y;
//}
//
//void Lib_FReal_Si_Div(double* res, const double* x, const int32_t y)
//{
//	*res = y / (*x);
//}
//
//
//
//int32_t Lib_FReal_LT(const double* x, const double* y)
//{
//	return (*x) < (*y);
//}
//
//int32_t Lib_FReal_GE(const double* x, const double* y)
//{
//	return (*x) >= (*y);
//}
//
//int32_t Lib_FReal_GT(const double* x, const double* y)
//{
//	return (*x) > (*y);
//}
//
//int32_t Lib_FReal_LE(const double* x, const double* y)
//{
//	return (*x) <= (*y);
//}
//
//int32_t Lib_FReal_EQ(const double* x, const double* y)
//{
//	return (*x) == (*y);
//}
//
//int32_t Lib_FReal_NE(const double* x, const double* y)
//{
//	return (*x) != (*y);
//}
//
//
//
//
//
//
//
//
//
//
//
//
//
//



/* General functions for real numbers  */

void Lib_FReal_Fma(double* res, const double* x, const double* y, const double* z)
{
	*res = fma( (*x) , (*y) , (*z) );
}

void Lib_FReal_Fmax(double* res, const double* x, const double* y)
{
	*res = fmax( (*x) , (*y) );
}

void Lib_FReal_Fmin(double* res, const double* x, const double* y)
{
	*res = fmin( (*x) , (*y) );
}





/* Machine constants and properties of numbers  */


void Lib_FReal_Zero(double* res)
{
	*res = 0.0;
}

void Lib_FReal_NegZero(double* res)
{
	*res = -0.0;
}

void Lib_FReal_One(double* res)
{
	*res = 1.0;
}

void Lib_FReal_Inf(double* res)
{
	*res = (std::numeric_limits<double>::infinity)();
}

void Lib_FReal_NegInf(double* res)
{
	*res = -(std::numeric_limits<double>::infinity)();
}

void Lib_FReal_Nan(double* res)
{
	*res = std::numeric_limits<double>::quiet_NaN();
}




/* Properties of numbers  */

int Lib_FReal_Signbit(const double* x)
{
	return int(std::signbit(*x));
}

int Lib_FReal_Finite(const double* x)
{
	return std::isfinite(*x);
}

int Lib_FReal_Isinf(const double* x)
{
	return std::isinf(*x);
}

int Lib_FReal_Isposinf(const double* x)
{
	return (std::isinf(*x) & (*x > 0.0));
}

int Lib_FReal_Isneginf(const double* x)
{
	return (std::isinf(*x) & (*x < 0.0));
}

int Lib_FReal_Isnan(const double* x)
{
	return std::isnan(*x);
}


int Lib_FReal_Iszero(const double* x)
{
	return (std::abs(*x) == 0.0);
}

int Lib_FReal_Isposzero(const double* x)
{
	return ((int(std::signbit(*x)) == 0) & (std::abs(*x) == 0.0));
}

int Lib_FReal_Isnegzero(const double* x)
{
	return ((int(std::signbit(*x)) != 0) & (std::abs(*x) == 0.0));
}

int Lib_FReal_Isone(const double* x)
{
	return (*x == 1.0f);
}

int Lib_FReal_Isinteger(const double* x)
{
	return (std::ceil(*x) == std::floor(*x));
}

int Lib_FReal_Isnumber(const double* x)
{
	return (!(std::isnan(*x) || (std::isinf(*x))));
}

int Lib_FReal_Isregular(const double* x)
{
	return (!(std::isnan(*x) || (std::isinf(*x) || (std::abs(*x) == 0.0))));
}

int Lib_FReal_Isnormal(const double* x)
{
	return (std::isnormal(*x));
}

int Lib_FReal_Issubnormal(const double* x)
{
	return (std::fpclassify(*x)) == FP_SUBNORMAL;
}

int Lib_FReal_Isunordered(const double* x, const double* y)
{
	return (std::isunordered(*x, *y));
}









int Lib_FReal_FitsInt32(const double* x)
{
	return  ((*x <= std::numeric_limits<int32_t>::max()) &
             (*x >= std::numeric_limits<int32_t>::min()));
}

int Lib_FReal_FitsInt64(const double* x)
{
	return  ((*x <= std::numeric_limits<int64_t>::max()) &
             (*x >= std::numeric_limits<int64_t>::min()));
}

int Lib_FReal_FitsUInt32(const double* x)
{
	return  ((*x <= std::numeric_limits<uint32_t>::max()) &
             (*x >= std::numeric_limits<uint32_t>::min()));
}

int Lib_FReal_FitsUInt64(const double* x)
{
	return  ((*x <= std::numeric_limits<uint64_t>::max()) &
             (*x >= std::numeric_limits<uint64_t>::min()));
}





/* Integer Related Functions  */

void Lib_FReal_Nearbyint(double* res, const double* x)
{
	*res = nearbyint(*x);
}

void Lib_FReal_Rint(double* res, const double* x)
{
	*res = rint(*x);
}

long int Lib_FReal_Lrint(const double* x)
{
	return lrint(*x);
}

long long int Lib_FReal_Llrint(const double* x)
{
	return llrint(*x);
}


void Lib_FReal_Ceil(double* res, const double* x)
{
	*res = ceil(*x);
}

void Lib_FReal_Floor(double* res, const double* x)
{
	*res = floor(*x);
}

void Lib_FReal_Trunc(double* res, const double* x)
{
	*res = trunc(*x);
}

void Lib_FReal_Round(double* res, const double* x)
{
	*res = round(*x);
}

long int Lib_FReal_Lround(const double* x)
{
	return lround(*x);
}

long long int Lib_FReal_Llround(const double* x)
{
	return llround(*x);
}

int32_t Lib_FReal_ToInt32(const double* x)
{
    if (*x >= std::numeric_limits<int32_t>::max())
        return std::numeric_limits<int32_t>::max();
    else if (*x <= std::numeric_limits<int32_t>::min())
        return std::numeric_limits<int32_t>::min();
    else
        return (int32_t) (*x);
}

int64_t Lib_FReal_ToInt64(const double* x)
{
    if (*x >= std::numeric_limits<int64_t>::max())
        return std::numeric_limits<int64_t>::max();
    else if (*x <= std::numeric_limits<int64_t>::min())
        return std::numeric_limits<int64_t>::min();
    else
        return (int64_t) (*x);
}

uint32_t Lib_FReal_ToUInt32(const double* x)
{
    if (*x >= std::numeric_limits<uint32_t>::max())
        return std::numeric_limits<uint32_t>::max();
    else if (*x <= std::numeric_limits<uint32_t>::min())
        return std::numeric_limits<uint32_t>::min();
    else
        return (uint32_t) (*x);
}

uint64_t Lib_FReal_ToUInt64(const double* x)
{
    if (*x >= std::numeric_limits<uint64_t>::max())
        return std::numeric_limits<uint64_t>::max();
    else if (*x <= std::numeric_limits<uint64_t>::min())
        return std::numeric_limits<uint64_t>::min();
    else
        return (uint64_t) (*x);
}








/* Floating point functions for real numbers */

void Lib_FReal_Copysign(double* res, const double* x, const double* y)
{
	*res = copysign( (*x) , (*y) );
}

void Lib_FReal_Frexp(double* res, const double* x, int* e)
{
	*res = frexp(*(double*)x, e);
}

void Lib_FReal_Logb(double* res, const double* x)
{
	*res = logb(*(double*)x);
}

int Lib_FReal_Ilogb(const double* x)
{
	return ilogb(*x);
}

void Lib_FReal_Ldexp(double* res, const double* x, const int e)
{
	*res = ldexp(*x, e);
}

void Lib_FReal_Scalbn(double* res, const double* x, const int e)
{
	*res = scalbn(*x, e);
}

void Lib_FReal_Scalbln(double* res, const double* x, const long int e)
{
	*res = scalbln(*x, e);
}

void Lib_FReal_Fdim(double* res, const double* x, const double* y)
{
	*res = fdim( (*x) , (*y) );
}




/* Fraction and Remainder Related Functions  */

void Lib_FReal_Modf(double* frac, const double* x, double* iptr)
{
	*frac = modf(*x, iptr);
}

void Lib_FReal_Fmod(double* res, const double* x, const double* y)
{
	*res = fmod(*x , *y);
}

void Lib_FReal_Remainder(double* res, const double* x, const double* y)
{
	*res = remainder( (*x) , (*y) );
}

void Lib_FReal_Remquo(double* res, const double* x, const double* y, int* e)
{
	*res = remquo( (*x) , (*y), e );
}




/* Functions related to mantissa width and exponent range */

void Lib_FReal_Epsilon(double* res)
{
	*res = (std::numeric_limits<double>::epsilon)();
}

void Lib_FReal_Ulp(double* res, const double* x)
{
	LibFReal_Ulp(res, x);
}


void Lib_FReal_Max(double* res)
{
	*res = (std::numeric_limits<double>::max)();
}

void Lib_FReal_Lowest(double* res)
{
	*res = (std::numeric_limits<double>::lowest)();
}

void Lib_FReal_Min(double* res)
{
	*res = (std::numeric_limits<double>::min)();
}

void Lib_FReal_Nexttoward(double* res, const double* x, const double* y)
{
	*res = nexttoward( (*x) , (*y) );
}

void Lib_FReal_Nextabove(double* res, const double* x)
{
	*res = nexttoward( (*x) , (std::numeric_limits<double>::infinity)() );
}

void Lib_FReal_Nextbelow(double* res, const double* x)
{
	*res = nexttoward( (*x) , -(std::numeric_limits<double>::infinity)() );
}




/* Complex components  */

void Lib_FReal_Fabs(double* res, const double* x)
{
	*res = fabs(*x);
}

void Lib_FReal_Sign(double* res, const double* x)
{
	*res = (double)((*x > 0) - (*x < 0));
}






/* Mathematical Constants  */

void Lib_FReal_ConstDegree(double* res)
{
	*res = pi_v<double> / 180;
}

void Lib_FReal_ConstPhi(double* res)
{
	*res = phi_v<double>;
}

void Lib_FReal_ConstLog2(double* res)
{
	*res = ln2_v<double>;
}

void Lib_FReal_ConstLog10(double* res)
{
	*res = ln10_v<double>;
}

void Lib_FReal_ConstPi(double* res)
{
	*res = pi_v<double>;
}

void Lib_FReal_ConstE(double* res)
{
	*res = e_v<double>;
}

void Lib_FReal_ConstEulerGamma(double* res)
{
	*res = egamma_v<double>;
}

void Lib_FReal_ConstApery(double* res)
{
	*res = 1.2020569031595942853997381615114499914;
}

void Lib_FReal_ConstCatalan(double* res)
{
	*res = 0.91596559417721901505460351493238411094;
}

void Lib_FReal_ConstGlaisher(double* res)
{
	*res = 1.2824271291006226368753425688697917282;
}

void Lib_FReal_ConstKhinchin(double* res)
{
	*res = 2.6854520010653064453097148354817956937;
}





/* Roots and related functions  */

void Lib_FReal_Sqrt(double* res, const double* x)
{
	*res = sqrt(*x);
}

void Lib_FReal_Sqrt1pm1(double* res, const double* x)
{
    *res = expm1(log1p((*x))*0.5);
}

void Lib_FReal_Rsqrt(double* res, const double* x)
{
	*res = (1.0) / sqrt(*x);
}

void Lib_FReal_Cbrt(double* res, const double* x)
{
	*res = cbrt(*x);
}


void Lib_FReal_Root_Si(double* res, const double* x, const int32_t k)
{
	*res = pow(*x, (1.0)/k);
}



/* Exponential and related functions  */

void Lib_FReal_Exp(double* res, const double* x)
{
	*res = exp(*x);
}

void Lib_FReal_Exp2(double* res, const double* x)
{
	*res = exp2(*x);
}

void Lib_FReal_Exp10(double* res, const double* x)
{
    *res = exp((*x) * ln10_v<double>);
}

void Lib_FReal_Expm1(double* res, const double* x)
{
	*res = expm1(*x);
}

void Lib_FReal_Exp2m1(double* res, const double* x)
{
	*res = expm1((*x) * ln2_v<double>);
}

void Lib_FReal_Exp10m1(double* res, const double* x)
{
	*res = expm1((*x) * ln10_v<double>);
}



/* Logarithms and related functions  */

void Lib_FReal_Log(double* res, const double* x)
{
	*res = log(*x);
}

void Lib_FReal_Log2(double* res, const double* x)
{
	*res = log2(*x);
}

void Lib_FReal_Log10(double* res, const double* x)
{
	*res = log10(*x);
}

void Lib_FReal_Log1p(double* res, const double* x)
{
	*res = log1p(*x);
}

void Lib_FReal_Log2p1(double* res, const double* x)
{
	*res = log1p(*x) / ln2_v<double>;
}

void Lib_FReal_Log10p1(double* res, const double* x)
{
	*res = log1p(*x) / ln10_v<double>;
}




/* Power functions and roots  */

void Lib_FReal_Square(double* res, const double* x)
{
	*res = (*x) * (*x);
}

void Lib_FReal_Cube(double* res, const double* x)
{
	*res = (*x) * (*x) * (*x);
}



void Lib_FReal_Hypot(double* res, const double* x, const double* y)
{
	*res = hypot( (*x) , (*y) );
}

void Lib_FReal_Pow(double* res, const double* x, const double* y)
{
	*res = pow( (*x) , (*y) );
}

void Lib_FReal_Powm1(double* res, const double* x, const double* y)
{
    *res = expm1(log((*x)) * (*y));
}

void Lib_FReal_Pow1p(double* res, const double* x, const double* y)
{
    *res = exp(log1p((*x)) * (*y));
}

void Lib_FReal_Pow1pm1(double* res, const double* x, const double* y)
{
    *res = expm1(log1p((*x)) * (*y));
}

void Lib_FReal_Pow_Si(double* res, const double* x, const int32_t n)
{
	*res = pow( (*x) , n );
}

void Lib_FReal_Compound_Si(double* res, const double* x, const int32_t n)
{
	*res = pow((1.0) + (*x) , n );
}




/* Trigonometric functions  */

void Lib_FReal_Sin(double* res, const double* x)
{
	*res = sin(*x);
}

void Lib_FReal_Cos(double* res, const double* x)
{
	*res = cos(*x);
}


double cosm1(double x)
{
    if (std::abs(x) > 0.5)
    {
        return std::cos(x) - 1;
    }
    else
    {
        double res = std::sin((x)/2);
        return  -2 * res * res;
    }
}

void Lib_FReal_Cosm1(double* res, const double* x)
{
	*res = cosm1(*x);
}


void Lib_FReal_Tan(double* res, const double* x)
{
	*res = tan(*x);
}


void Lib_FReal_Csc(double* res, const double* x)
{
	*res = (1.0) / sin(*x);
}

void Lib_FReal_Sec(double* res, const double* x)
{
	*res = (1.0) / cos(*x);
}

void Lib_FReal_Cot(double* res, const double* x)
{
	*res = (1.0) / tan(*x);
}



void Lib_FReal_SinPi(double* res, const double* x)
{
    LibFReal_SinPi(res, x);
}

void Lib_FReal_CosPi(double* res, const double* x)
{
    LibFReal_CosPi(res, x);
}

void Lib_FReal_TanPi(double* res, const double* x)
{
    LibFReal_TanPi(res, x);
}



void Lib_FReal_CscPi(double* res, const double* x)
{
    LibFReal_CscPi(res, x);
}

void Lib_FReal_SecPi(double* res, const double* x)
{
    LibFReal_SecPi(res, x);
}

void Lib_FReal_CotPi(double* res, const double* x)
{
    LibFReal_CotPi(res, x);
}



/* Hyperbolic functions  */

void Lib_FReal_Sinh(double* res, const double* x)
{
	*res = sinh(*x);
}

void Lib_FReal_Cosh(double* res, const double* x)
{
	*res = cosh(*x);
}

void Lib_FReal_Tanh(double* res, const double* x)
{
	*res = tanh(*x);
}


void Lib_FReal_Csch(double* res, const double* x)
{
	*res = (1.0) / sinh(*x);
}

void Lib_FReal_Sech(double* res, const double* x)
{
	*res = (1.0) / cosh(*x);
}

void Lib_FReal_Coth(double* res, const double* x)
{
	*res = (1.0) / tanh(*x);
}







/* Inverse trigonometric functions  */

void Lib_FReal_Asin(double* res, const double* x)
{
	*res = asin(*x);
}

void Lib_FReal_Acos(double* res, const double* x)
{
	*res = acos(*x);
}

void Lib_FReal_Atan(double* res, const double* x)
{
	*res = atan(*x);
}

void Lib_FReal_Atan2(double* res, const double* x, const double* y)
{
	*res = atan2( (*x) , (*y) );
}


void Lib_FReal_Acsc(double* res, const double* x)
{
	*res = asin((1.0) / (*x));
}

void Lib_FReal_Asec(double* res, const double* x)
{
	*res = acos((1.0) / (*x));
}

void Lib_FReal_Acot(double* res, const double* x)
{
	*res = atan((1.0) / (*x));
}



/* Inverse hyperbolic functions  */

void Lib_FReal_Asinh(double* res, const double* x)
{
	*res = asinh(*x);
}

void Lib_FReal_Acosh(double* res, const double* x)
{
	*res = acosh(*x);
}

void Lib_FReal_Atanh(double* res, const double* x)
{
	*res = atanh(*x);
}


void Lib_FReal_Acsch(double* res, const double* x)
{
	*res = asinh((1.0) / (*x));
}

void Lib_FReal_Asech(double* res, const double* x)
{
	*res = acosh((1.0) / (*x));
}

void Lib_FReal_Acoth(double* res, const double* x)
{
	*res = atanh((1.0) / (*x));
}






/* Special functions  */

void Lib_FReal_Erf(double* res, const double* x)
{
	*res = erf(*x);
}

void Lib_FReal_Erfc(double* res, const double* x)
{
	*res = erfc(*x);
}

void Lib_FReal_Tgamma(double* res, const double* x)
{
	*res = tgamma(*x);
}

void Lib_FReal_Lgamma(double* res, const double* x)
{
	*res = lgamma(*x);
}

void Lib_FReal_BesselJ0(double* res, const double* x)
{
	*res = std::cyl_bessel_j(0.0, *x);
}

void Lib_FReal_BesselJ1(double* res, const double* x)
{
	*res = std::cyl_bessel_j(1.0, *x);
}

void Lib_FReal_BesselJn(double* res, const double* n, const double* x)
{
	*res = std::cyl_bessel_j(*n, *x);
}


void Lib_FReal_BesselY0(double* res, const double* x)
{
	*res = std::cyl_neumann(0.0, *x);
}

void Lib_FReal_BesselY1(double* res, const double* x)
{
	*res = std::cyl_neumann(1.0, *x);
}

void Lib_FReal_BesselYn(double* res, const double* n, const double* x)
{
	*res = std::cyl_neumann(*n, *x);
}








//*********************** Boost Special functions , double precision **********************************



void Lib_FReal_BernoulliB2n(double* res, const int n)
{
    LibFReal_BernoulliB2n(res, n);
}



void Lib_FReal_TangentT2n(double* res, const int n)
{
    LibFReal_TangentT2n(res, n);
}



void Lib_FReal_Sqrt1pm1_Boost(double* res, const double* x)
{
    LibFReal_Sqrt1pm1(res, x);
}



void Lib_FReal_SinPi_Boost(double* res, const double* x)
{
    LibFReal_SinPi(res, x);
}



void Lib_FReal_CosPi_Boost(double* res, const double* x)
{
    LibFReal_CosPi(res, x);
}



void Lib_FReal_SincPi(double* res, const double* x)
{
    LibFReal_SincPi(res, x);
}



void Lib_FReal_SinhcPi(double* res, const double* x)
{
    LibFReal_SinhcPi(res, x);
}



void Lib_FReal_Tgamma_(double* res, const double* x)
{
    LibFReal_Tgamma_(res, x);
}


void Lib_FReal_Tgamma1pm1(double* res, const double* x)
{
    LibFReal_Tgamma1pm1(res, x);
}



void Lib_FReal_Lgamma_(double* res, const double* x)
{
    LibFReal_Lgamma_(res, x);
}



void Lib_FReal_Digamma(double* res, const double* x)
{
    LibFReal_Digamma(res, x);
}



void Lib_FReal_Trigamma(double* res, const double* x)
{
    LibFReal_Trigamma(res, x);
}



void Lib_FReal_Factorial(double* res, const double* x)
{
    LibFReal_Factorial(res, x);
}



void Lib_FReal_DoubleFactorial(double* res, const double* x)
{
    LibFReal_DoubleFactorial(res, x);
}





void Lib_FReal_Erf_(double* res, const double* x)
{
    LibFReal_Erf_(res, x);
}



void Lib_FReal_Erfc_(double* res, const double* x)
{
    LibFReal_Erfc_(res, x);
}



void Lib_FReal_Erf_inv(double* res, const double* x)
{
    LibFReal_Erf_inv(res, x);
}



void Lib_FReal_Erfc_inv(double* res, const double* x)
{
    LibFReal_Erfc_inv(res, x);
}



void Lib_FReal_AiryAi(double* res, const double* x)
{
    LibFReal_AiryAi(res, x);
}



void Lib_FReal_AiryBi(double* res, const double* x)
{
    LibFReal_AiryBi(res, x);
}



void Lib_FReal_AiryAiPrime(double* res, const double* x)
{
    LibFReal_AiryAiPrime(res, x);
}



void Lib_FReal_AiryBiPrime(double* res, const double* x)
{
    LibFReal_AiryBiPrime(res, x);
}



void Lib_FReal_Aizero(double* res, const int n)
{
    LibFReal_Aizero(res, n);
}



void Lib_FReal_Bizero(double* res, const int n)
{
    LibFReal_Bizero(res, n);
}



void Lib_FReal_Ellint_1_K(double* res, const double* x)
{
    LibFReal_Ellint_1_K(res, x);
}



void Lib_FReal_Ellint_2_K(double* res, const double* x)
{
    LibFReal_Ellint_2_K(res, x);
}



void Lib_FReal_Zeta(double* res, const double* x)
{
    LibFReal_Zeta(res, x);
}



void Lib_FReal_Ei(double* res, const double* x)
{
    LibFReal_Ei(res, x);
}



void Lib_FReal_LambertW0(double* res, const double* x)
{
    LibFReal_LambertW0(res, x);
}


void Lib_FReal_LambertWm1(double* res, const double* x)
{
    LibFReal_LambertWm1(res, x);
}



void Lib_FReal_LambertW0Prime(double* res, const double* x)
{
    LibFReal_LambertW0Prime(res, x);
}


void Lib_FReal_LambertWm1Prime(double* res, const double* x)
{
    LibFReal_LambertWm1Prime(res, x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void Lib_FReal_Agm(double* res, const double* a, const double* b)
{
    LibFReal_Agm(res, a, b);
}




void Lib_FReal_Powm1_Boost(double* res, const double* a, const double* b)
{
    LibFReal_Powm1(res, a, b);
}



void Lib_FReal_TgammaRatio(double* res, const double* a, const double* b)
{
    LibFReal_TgammaRatio(res, a, b);
}



void Lib_FReal_TgammaDeltaRatio(double* res, const double* a, const double* b)
{
    LibFReal_TgammaDeltaRatio(res, a, b);
}



void Lib_FReal_Binomial(double* res, const double* n, const double* k)
{
    LibFReal_Binomial(res, n, k);
}

void Lib_FReal_RisingFactorial(double* res, const double* x, const double* n)
{
    LibFReal_RisingFactorial(res, x, n);
}




void Lib_FReal_FallingFactorial(double* res, const double* x, const double* n)
{
    LibFReal_FallingFactorial(res, x, n);
}




void Lib_FReal_BesselJ(double* res, const double* v, const double* x)
{
    LibFReal_BesselJ(res, v, x);
}



void Lib_FReal_BesselY(double* res, const double* v, const double* x)
{
    LibFReal_BesselY(res, v, x);
}



void Lib_FReal_BesselI(double* res, const double* v, const double* x)
{
    LibFReal_BesselI(res, v, x);
}



void Lib_FReal_BesselK(double* res, const double* v, const double* x)
{
    LibFReal_BesselK(res, v, x);
}



void Lib_FReal_SphBessel(double* res, const unsigned v, const double* x)
{
    LibFReal_SphBessel(res, v, x);
}



void Lib_FReal_SphNeumann(double* res, const unsigned v, const double* x)
{
    LibFReal_SphNeumann(res, v, x);
}





void Lib_FReal_BesselJPrime(double* res, const double* v, const double* x)
{
    LibFReal_BesselJPrime(res, v, x);
}



void Lib_FReal_BesselYPrime(double* res, const double* v, const double* x)
{
    LibFReal_BesselYPrime(res, v, x);
}



void Lib_FReal_BesselIPrime(double* res, const double* v, const double* x)
{
    LibFReal_BesselIPrime(res, v, x);
}



void Lib_FReal_BesselKPrime(double* res, const double* v, const double* x)
{
    LibFReal_BesselKPrime(res, v, x);
}



void Lib_FReal_SphBesselPrime(double* res, const unsigned v, const double* x)
{
    LibFReal_SphBesselPrime(res, v, x);
}



void Lib_FReal_SphNeumannPrime(double* res, const unsigned v, const double* x)
{
    LibFReal_SphNeumannPrime(res, v, x);
}





void Lib_FReal_BesselJZero(double* res, const double* v, const int m)
{
    LibFReal_BesselJZero(res, v, m);
}



void Lib_FReal_BesselYZero(double* res, const double* v, const int m)
{
    LibFReal_BesselYZero(res, v, m);
}





void Lib_FReal_GammaP(double* res, const double* a, const double* x)
{
    LibFReal_GammaP(res, a, x);
}


void Lib_FReal_GammaQ(double* res, const double* a, const double* x)
{
    LibFReal_GammaQ(res, a, x);
}


void Lib_FReal_TgammaLower(double* res, const double* a, const double* x)
{
    LibFReal_TgammaLower(res, a, x);
}


void Lib_FReal_TgammaUpper(double* res, const double* a, const double* x)
{
    LibFReal_TgammaUpper(res, a, x);
}




void Lib_FReal_GammaPInv(double* res, const double* a, const double* p)
{
    LibFReal_GammaPInv(res, a, p);
}


void Lib_FReal_GammaQInv(double* res, const double* a, const double* q)
{
    LibFReal_GammaQInv(res, a, q);
}


void Lib_FReal_GammaPInva(double* res, const double* x, const double* p)
{
    LibFReal_GammaPInva(res, x, p);
}


void Lib_FReal_GammaQInva(double* res, const double* x, const double* q)
{
    LibFReal_GammaQInva(res, x, q);
}



void Lib_FReal_GammaPDerivative(double* res, const double* a, const double* x)
{
    LibFReal_GammaPDerivative(res, a, x);
}


void Lib_FReal_Beta(double* res, const double* a, const double* b)
{
    LibFReal_Beta(res, a, b);
}









void Lib_FReal_LegendreP(double* res, int n, const double* x)
{
    LibFReal_LegendreP(res, n, x);
}



void Lib_FReal_LegendreQ(double* res, int n, const double* x)
{
    LibFReal_LegendreQ(res, n, x);
}



void Lib_FReal_Laguerre(double* res, int n, const double* x)
{
    LibFReal_Laguerre(res, n, x);
}



void Lib_FReal_Hermite(double* res, int n, const double* x)
{
    LibFReal_Hermite(res, n, x);
}



void Lib_FReal_ChebyshevT(double* res, int n, const double* x)
{
    LibFReal_ChebyshevT(res, n, x);
}


void Lib_FReal_ChebyshevU(double* res, int n, const double* x)
{
    LibFReal_ChebyshevU(res, n, x);
}



void Lib_FReal_Polygamma(double* res, int n, const double* x)
{
    LibFReal_Polygamma(res, n, x);
}





void Lib_FReal_EllintRC(double* res, const double* x, const double* y)
{
    LibFReal_EllintRC(res, x, y);
}


void Lib_FReal_Ellint1F(double* res, const double* k, const double* phi)
{
    LibFReal_Ellint1F(res, k, phi);
}


void Lib_FReal_Ellint2F(double* res, const double* k, const double* phi)
{
    LibFReal_Ellint2F(res, k, phi);
}


void Lib_FReal_Ellint3K(double* res, const double* k, const double* n)
{
    LibFReal_Ellint3K(res, k, n);
}




void Lib_FReal_JacobiCD(double* res, const double* k, const double* u)
{
    LibFReal_JacobiCD(res, k, u);
}


void Lib_FReal_JacobiCN(double* res, const double* k, const double* u)
{
    LibFReal_JacobiCN(res, k, u);
}


void Lib_FReal_JacobiCS(double* res, const double* k, const double* u)
{
    LibFReal_JacobiCS(res, k, u);
}


void Lib_FReal_JacobiDC(double* res, const double* k, const double* u)
{
    LibFReal_JacobiDC(res, k, u);
}


void Lib_FReal_JacobiDN(double* res, const double* k, const double* u)
{
    LibFReal_JacobiDN(res, k, u);
}


void Lib_FReal_JacobiDS(double* res, const double* k, const double* u)
{
    LibFReal_JacobiDS(res, k, u);
}


void Lib_FReal_JacobiNC(double* res, const double* k, const double* u)
{
    LibFReal_JacobiNC(res, k, u);
}


void Lib_FReal_JacobiND(double* res, const double* k, const double* u)
{
    LibFReal_JacobiND(res, k, u);
}


void Lib_FReal_JacobiNS(double* res, const double* k, const double* u)
{
    LibFReal_JacobiNS(res, k, u);
}


void Lib_FReal_JacobiSC(double* res, const double* k, const double* u)
{
    LibFReal_JacobiSC(res, k, u);
}


void Lib_FReal_JacobiSD(double* res, const double* k, const double* u)
{
    LibFReal_JacobiSD(res, k, u);
}


void Lib_FReal_JacobiSN(double* res, const double* k, const double* u)
{
    LibFReal_JacobiSN(res, k, u);
}



void Lib_FReal_expint(double* res, const unsigned n, const double* x)
{
    LibFReal_expint(res, n, x);
}




void Lib_FReal_OwenT(double* res, const double* h, const double* a)
{
    LibFReal_OwenT(res, h, a);
}





void Lib_FReal_IBeta(double* res, const double* a, const double* b, const double* x)
{
    LibFReal_IBeta(res, a, b, x);
}


void Lib_FReal_IBetac(double* res, const double* a, const double* b, const double* x)
{
    LibFReal_IBetac(res, a, b, x);
}


void Lib_FReal_IBetaNonNormalized(double* res, const double* a, const double* b, const double* x)
{
    LibFReal_IBetaNonNormalized(res, a, b, x);
}


void Lib_FReal_IBetacNonNormalized(double* res, const double* a, const double* b, const double* x)
{
    LibFReal_IBetacNonNormalized(res, a, b, x);
}


void Lib_FReal_IBetaInv(double* res, const double* a, const double* b, const double* p)
{
    LibFReal_IBetaInv(res, a, b, p);
}


void Lib_FReal_IBetacInv(double* res, const double* a, const double* b, const double* q)
{
    LibFReal_IBetacInv(res, a, b, q);
}


void Lib_FReal_IBetaInva(double* res, const double* b, const double* x, const double* p)
{
    LibFReal_IBetaInva(res, b, x, p);
}


void Lib_FReal_IBetacInva(double* res, const double* b, const double* x, const double* q)
{
    LibFReal_IBetacInva(res, b, x, q);
}


void Lib_FReal_IBetaInvb(double* res, const double* a, const double* x, const double* p)
{
    LibFReal_IBetaInvb(res, a, x, p);
}


void Lib_FReal_IBetacInvb(double* res, const double* a, const double* x, const double* q)
{
    LibFReal_IBetacInvb(res, a, x, q);
}


void Lib_FReal_IBetaDerivative(double* res, const double* a, const double* b, const double* x)
{
    LibFReal_IBetaDerivative(res, a, b, x);
}




void Lib_FReal_LegendrePM(double* res, const int n, const int m, const double* x)
{
    LibFReal_LegendrePM(res, n, m, x);
}



void Lib_FReal_LaguerreM(double* res, const int n, const int m, const double* x)
{
    LibFReal_LaguerreM(res, n, m, x);
}





void Lib_FReal_EllipticRF(double* res, const double* x, const double* y, const double* z)
{
    LibFReal_EllipticRF(res, x, y, z);
}



void Lib_FReal_EllipticRD(double* res, const double* x, const double* y, const double* z)
{
    LibFReal_EllipticRD(res, x, y, z);
}



void Lib_FReal_EllipticRG(double* res, const double* x, const double* y, const double* z)
{
    LibFReal_EllipticRG(res, x, y, z);
}



void Lib_FReal_Ellint3F(double* res, const double* k, const double* n, const double* phi)
{
    LibFReal_Ellint3F(res, k, n, phi);
}




void Lib_FReal_Gegenbauer(double* res, const int n, const double* lambda, const double* x)
{
    LibFReal_Gegenbauer(res, n, lambda, x);
}


void Lib_FReal_Jacobi(double* res, const int n, const double* alpha, const double* beta, const double* x)
{
    LibFReal_Jacobi(res, n, alpha, beta, x);
}





void Lib_FReal_SphericalHarmonicR(double* res, const int n, const int m, const double* theta, const double* phi)
{
    LibFReal_SphericalHarmonicR(res, n, m, theta, phi);
}


void Lib_FReal_SphericalHarmonicI(double* res, const int n, const int m, const double* theta, const double* phi)
{
    LibFReal_SphericalHarmonicI(res, n, m, theta, phi);
}


void Lib_FReal_EllipticRJ(double* res, const double* x, const double* y, const double* z, const double* p)
{
    LibFReal_EllipticRJ(res, x, y, z, p);
}


// Hypergeometric and Theta Functions




void Lib_FReal_Hypergeo0F1(double* res, const double* b, const double* x)
{
    LibFReal_Hypergeo0F1(res, b, x);
}



void Lib_FReal_Hypergeo1F1(double* res, const double* a, const double* b, const double* x)
{
    LibFReal_Hypergeo1F1(res, a, b, x);
}



void Lib_FReal_Hypergeo1F1r(double* res, const double* a, const double* b, const double* x)
{
    LibFReal_Hypergeo1F1r(res, a, b, x);
}



void Lib_FReal_LogHypergeo1F1(double* res, const double* a, const double* b, const double* x)
{
    LibFReal_LogHypergeo1F1(res, a, b, x);
}





void Lib_FReal_JacobiTheta1(double* res, const double* x, const double* q)
{
    LibFReal_JacobiTheta1(res, x, q);
}


void Lib_FReal_JacobiTheta2(double* res, const double* x, const double* q)
{
    LibFReal_JacobiTheta2(res, x, q);
}


void Lib_FReal_JacobiTheta3(double* res, const double* x, const double* q)
{
    LibFReal_JacobiTheta3(res, x, q);
}


void Lib_FReal_JacobiTheta4(double* res, const double* x, const double* q)
{
    LibFReal_JacobiTheta4(res, x, q);
}






//*********************** Distributions **********************************


void Lib_FReal_ArcsineDist(long Target, double* res, double* xqp, double* a, double* b)
{
    LibFReal_ArcsineDist(Target, res, xqp, a, b);
}


void Lib_FReal_BernoulliDist(long Target, double* res, double* xqp, double* p)
{
    LibFReal_BernoulliDist(Target, res, xqp, p);
}


void Lib_FReal_BetaDist(long Target, double* res, double* xqp, double* a, double* b)
{
    LibFReal_BetaDist(Target, res, xqp, a, b);
}


void Lib_FReal_BinomialDist(long Target, double* res, double* xqp, double* n, double* p)
{
    LibFReal_BinomialDist(Target, res, xqp, n, p);
}


void Lib_FReal_CauchyDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_CauchyDist(Target, res, xqp, location, scale);
}


void Lib_FReal_Chi2Dist(long Target, double* res, double* xqp, double* nu)
{
    LibFReal_Chi2Dist(Target, res, xqp, nu);
}

void Lib_FReal_ExponentialDist(long Target, double* res, double* xqp, double* lambda)
{
    LibFReal_ExponentialDist(Target, res, xqp, lambda);
}


void Lib_FReal_GumbelDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_ExtremeValueDist(Target, res, xqp, location, scale);
}


void Lib_FReal_FisherFDist(long Target, double* res, double* xqp, double* mu, double* nu)
{
    LibFReal_FisherFDist(Target, res, xqp, mu, nu);
}


void Lib_FReal_GammaDist(long Target, double* res, double* xqp, double* shape, double* scale)
{
    LibFReal_GammaDist(Target, res, xqp, shape, scale);
}


void Lib_FReal_GeometricDist(long Target, double* res, double* xqp, double* p)
{
    LibFReal_GeometricDist(Target, res, xqp, p);
}


void Lib_FReal_HypergeometricDist(long Target, double* res, double* xqp, uint64_t r, uint64_t n, uint64_t N)
{
    LibFReal_HypergeometricDist(Target, res, xqp, r, n, N);
}


void Lib_FReal_InverseChi2Dist(long Target, double* res, double* xqp, double* df, double* scale)
{
    LibFReal_InverseChi2Dist(Target, res, xqp, df, scale);
}



void Lib_FReal_InverseGammaDist(long Target, double* res, double* xqp, double* shape, double* scale)
{
    LibFReal_InverseGammaDist(Target, res, xqp, shape, scale);
}


void Lib_FReal_WaldDist(long Target, double* res, double* xqp, double* mean_, double* scale)
{
    LibFReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
}


void Lib_FReal_LaplaceDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_LaplaceDist(Target, res, xqp, location, scale);
}


void Lib_FReal_LogisticDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_LogisticDist(Target, res, xqp, location, scale);
}


void Lib_FReal_LognormalDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_LognormalDist(Target, res, xqp, location, scale);
}


void Lib_FReal_NegBinomialDist(long Target, double* res, double* xqp, double* n, double* p)
{
    LibFReal_NegBinomialDist(Target, res, xqp, n, p);
}


void Lib_FReal_Chi2NcDist(long Target, double* res, double* xqp, double* nu, double* nc)
{
    LibFReal_Chi2NCDist(Target, res, xqp, nu, nc);
}


void Lib_FReal_StudentTNcDist(long Target, double* res, double* xqp, double* nu, double* delta)
{
    LibFReal_StudentTNCDist(Target, res, xqp, nu, delta);
}


void Lib_FReal_FisherNcDist(long Target, double* res, double* xqp, double* mu, double* nu, double* nc)
{
    LibFReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
}


void Lib_FReal_BetaNcDist(long Target, double* res, double* xqp, double* a, double* b, double* nc)
{
    LibFReal_BetaNCDist(Target, res, xqp, a, b, nc);
}


void Lib_FReal_NormalDist(long Target, double* res, double* xqp, double* mean_, double* stdev)
{
    LibFReal_NormalDist(Target, res, xqp, mean_, stdev);
}


void Lib_FReal_ParetoDist(long Target, double* res, double* xqp, double* shape, double* scale)
{
    LibFReal_ParetoDist(Target, res, xqp, shape, scale);
}


void Lib_FReal_PoissonDist(long Target, double* res, double* xqp, double* nu)
{
    LibFReal_PoissonDist(Target, res, xqp, nu);
}


void Lib_FReal_RayleighDist(long Target, double* res, double* xqp, double* nu)
{
    LibFReal_RayleighDist(Target, res, xqp, nu);
}


void Lib_FReal_SkewNormalDist(long Target, double* res, double* xqp, double* mean_, double* scale, double* shape)
{
    LibFReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
}


void Lib_FReal_StudentTDist(long Target, double* res, double* xqp, double* nu)
{
    LibFReal_StudentTDist(Target, res, xqp, nu);
}


void Lib_FReal_TriangularDist(long Target, double* res, double* xqp, double* lower, double* mode_, double* upper)
{
    LibFReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
}


void Lib_FReal_WeibullDist(long Target, double* res, double* xqp, double* shape, double* scale)
{
    LibFReal_WeibullDist(Target, res, xqp, shape, scale);
}


void Lib_FReal_UniformDist(long Target, double* res, double* xqp, double* lower, double* upper)
{
    LibFReal_UniformDist(Target, res, xqp, lower, upper);
}





//*********************** New , double precision **********************************




void Lib_FReal_Logaddexp(double* res, const double* a, const double* b)
{
    LibFReal_Logaddexp(res, a, b);
}



void Lib_FReal_HyperexponentialDist(long Target, double* res, double* xqp, mpNumMatrixPtr l1, mpNumMatrixPtr l2)
{
    LibFReal_HyperexponentialDist(Target, res, xqp, (FStatePtr)l1, (FStatePtr)l2);
}


void Lib_FReal_KolmogorovSmirnovDist(long Target, double* res, double* xqp, double* n)
{
    LibFReal_KolmogorovSmirnovDist(Target, res, xqp, n);
}


void Lib_FReal_HoltsmarkDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_HoltsmarkDist(Target, res, xqp, location, scale);
}


void Lib_FReal_LandauDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_LandauDist(Target, res, xqp, location, scale);
}


void Lib_FReal_MapAiryDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_MapAiryDist(Target, res, xqp, location, scale);
}


void Lib_FReal_Saspoint5Dist(long Target, double* res, double* xqp, double* location, double* scale)
{
    LibFReal_Saspoint5Dist(Target, res, xqp, location, scale);
}






































/** ********************** Complex Basic Functions, double precision ******************************** **/



FCplxPtr Lib_FCplx_Init_Func()
{
	FCplxPtr x = NULL;
	x = (std::complex<double>*) malloc(sizeof(std::complex<double>));
	return x;
}


void Lib_FCplx_Clear(FCplxPtr x)
{
	free(x);
}





/* Input and output  */

void Lib_FCplx_Set(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res)  = (*(std::complex<double>*) x);
}





/* Operator overloading vs raw arithmetic and comparisons  */

void Lib_FCplx_Neg(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = -(*(std::complex<double>*) x);
}

void Lib_FCplx_Add(FCplxPtr res, const FCplxPtr x, const FCplxPtr y)
{
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) + (*(std::complex<double>*) y);
}

void Lib_FCplx_Sub(FCplxPtr res, const FCplxPtr x, const FCplxPtr y)
{
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) - (*(std::complex<double>*) y);
}

void Lib_FCplx_Mul(FCplxPtr res, const FCplxPtr x, const FCplxPtr y)
{
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) * (*(std::complex<double>*) y);
}

void Lib_FCplx_Div(FCplxPtr res, const FCplxPtr x, const FCplxPtr y)
{
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) / (*(std::complex<double>*) y);
}


void Lib_FCplx_Add_FReal(FCplxPtr res, const FCplxPtr x, const double* y)
{
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) + (*y);
}

void Lib_FCplx_Sub_FReal(FCplxPtr res, const FCplxPtr x, const double* y)
{
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) - (*y);
}

void Lib_FCplx_FReal_Sub(FCplxPtr res, const FCplxPtr y, const double* x)
{
	(*(std::complex<double>*) res) = (*x) - (*(std::complex<double>*) y);
}

void Lib_FCplx_Mul_FReal(FCplxPtr res, const FCplxPtr x, const double* y)
{
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) * (*y);
}

void Lib_FCplx_Div_FReal(FCplxPtr res, const FCplxPtr x, const double* y)
{
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) / (*y);
}

void Lib_FCplx_FReal_Div(FCplxPtr res, const FCplxPtr y, const double* x)
{
	(*(std::complex<double>*) res) = (*x) / (*(std::complex<double>*) y);
}


void Lib_FCplx_Add_D(FCplxPtr res, const FCplxPtr x, const double y)
{
    double temp = y;
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) + temp;
}

void Lib_FCplx_Sub_D(FCplxPtr res, const FCplxPtr x, const double y)
{
    double temp = y;
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) - temp;
}

void Lib_FCplx_D_Sub(FCplxPtr res, const FCplxPtr y, const double x)
{
    double temp = x;
	(*(std::complex<double>*) res) = temp - (*(std::complex<double>*) y);
}

void Lib_FCplx_Mul_D(FCplxPtr res, const FCplxPtr x, const double y)
{
    double temp = y;
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) * temp;
}

void Lib_FCplx_Div_D(FCplxPtr res, const FCplxPtr x, const double y)
{
    double temp = y;
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) / temp;
}

void Lib_FCplx_D_Div(FCplxPtr res, const FCplxPtr y, const double x)
{
    double temp = x;
	(*(std::complex<double>*) res) = temp / (*(std::complex<double>*) y);
}



void Lib_FCplx_Add_Si(FCplxPtr res, const FCplxPtr x, const int32_t y)
{
    double temp = y;
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) + temp;
}

void Lib_FCplx_Sub_Si(FCplxPtr res, const FCplxPtr x, const int32_t y)
{
    double temp = y;
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) - temp;
}

void Lib_FCplx_Si_Sub(FCplxPtr res, const FCplxPtr y, const int32_t x)
{
    double temp = x;
	(*(std::complex<double>*) res) = temp - (*(std::complex<double>*) y);
}

void Lib_FCplx_Mul_Si(FCplxPtr res, const FCplxPtr x, const int32_t y)
{
    double temp = y;
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) * temp;
}



/* Missing: Inv */


void Lib_FCplx_Div_Si(FCplxPtr res, const FCplxPtr x, const int32_t y)
{
    double temp = y;
	(*(std::complex<double>*) res) = (*(std::complex<double>*) x) / temp;
}

void Lib_FCplx_Si_Div(FCplxPtr res, const FCplxPtr y, const int32_t x)
{
    double temp = x;
	(*(std::complex<double>*) res) = temp / (*(std::complex<double>*) y);
}








/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void Lib_FCplx_Set_Real(FCplxPtr res, const double* re)
{
	(*(std::complex<double>*) res) = std::complex<double>(*re, 0);
}

void Lib_FCplx_Set2(FCplxPtr res, const double* re, const double* im)
{
	(*(std::complex<double>*) res) = std::complex<double>(*re, *im);
}






void Lib_FCplx_Abs(double* res, const FCplxPtr x)
{
	*res = std::abs(*(std::complex<double>*) x);
}

void Lib_FCplx_Arg(double* res, const FCplxPtr x)
{
	*res = std::arg(*(std::complex<double>*) x);
}

void Lib_FCplx_Imag(double* res, const FCplxPtr x)
{
	*res = (*(std::complex<double>*) x).imag();
}

void Lib_FCplx_Real(double* res, const FCplxPtr x)
{
	*res = (*(std::complex<double>*) x).real();
}

void Lib_FCplx_Conj(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::conj(*(std::complex<double>*) x);
}

void Lib_FCplx_Proj(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::proj(*(std::complex<double>*) x);
}




/* Roots  */


std::complex<double> cplx_expm1(std::complex<double> z)
{
    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
	double x = z.real();
	double y = z.imag();
	double resx =  std::expm1(x) * std::cos(y) + cosm1(y);
	double resy =  std::exp(x) * std::sin(y);
	return std::complex<double>(resx, resy);
}


std::complex<double> cplx_log1p(std::complex<double> z)
{
    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
    /* resy =  atan2(y, 1 + x); */
	double x = z.real();
	double y = z.imag();
	double resx = 0.0 ;
	if ( (std::abs(x) > 0.75) || (std::abs(y) > 0.75) || (x < -0.5) )
    {
        resx = std::log(std::hypot(1 + x, y)) ;
    }
    else
    {
        resx = 0.5 * std::log1p(2*x + x*x + y*y);
    }
	double resy = std::atan2(y, 1 + x); ;
	return std::complex<double>(resx, resy);
}


void Lib_FCplx_Sqrt(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::sqrt(*(std::complex<double>*) x);
}


void Lib_FCplx_Sqrt1pm1(FCplxPtr res, const FCplxPtr x)
{
    (*(std::complex<double>*) res) = cplx_expm1(cplx_log1p(*(std::complex<double>*) x) * 0.5);
}


void Lib_FCplx_Rsqrt(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = (1.0) / std::sqrt(*(std::complex<double>*) x);
}


void Lib_FCplx_Cbrt(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::pow(*(std::complex<double>*) x, (1.0)/3);
}


void Lib_FCplx_Root_Si(FCplxPtr res, const FCplxPtr x, const int32_t k)
{
	(*(std::complex<double>*) res) = std::pow(*(std::complex<double>*) x, (1.0)/k);
}




/* Exponential and related functions  */

void Lib_FCplx_Exp(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::exp(*(std::complex<double>*) x);
}


void Lib_FCplx_Exp2(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::exp( (*(std::complex<double>*) x) * ln2_v<double>);
}


void Lib_FCplx_Exp10(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::exp( (*(std::complex<double>*) x) * ln10_v<double>);
}


void Lib_FCplx_Expm1(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) =  cplx_expm1(*(std::complex<double>*) x);
}


void Lib_FCplx_Exp2m1(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) =  cplx_expm1((*(std::complex<double>*) x) * ln2_v<double>);
}


void Lib_FCplx_Exp10m1(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) =  cplx_expm1((*(std::complex<double>*) x) * ln10_v<double>);
}



/* Logarithms and related functions  */

void Lib_FCplx_Log(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::log(*(std::complex<double>*) x);
}

void Lib_FCplx_Log2(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::log(*(std::complex<double>*) x) / ln2_v<double>;
}

void Lib_FCplx_Log10(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::log10(*(std::complex<double>*) x);
}

void Lib_FCplx_Log1p(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = cplx_log1p(*(std::complex<double>*) x);
}

void Lib_FCplx_Log2p1(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = cplx_log1p(*(std::complex<double>*) x) / ln2_v<double>;
}

void Lib_FCplx_Log10p1(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = cplx_log1p(*(std::complex<double>*) x) / ln10_v<double>;
}





/* Power functions */

void Lib_FCplx_Square(FCplxPtr res, const FCplxPtr x)
{
    std::complex<double> z = *(std::complex<double>*) x;
	(*(std::complex<double>*) res) = z * z;
}

void Lib_FCplx_Cube(FCplxPtr res, const FCplxPtr x)
{
    std::complex<double> z = *(std::complex<double>*) x;
	(*(std::complex<double>*) res) = z * z * z;
}

void Lib_FCplx_Pow(FCplxPtr res, const FCplxPtr x, const FCplxPtr y)
{
	(*(std::complex<double>*) res) = std::pow(*(std::complex<double>*) x, *(std::complex<double>*) y);
}

void Lib_FCplx_Powm1(FCplxPtr res, const FCplxPtr x, const FCplxPtr y)
{
    (*(std::complex<double>*) res) = cplx_expm1(std::log(*(std::complex<double>*) x) * (*(std::complex<double>*) y));
}

void Lib_FCplx_Pow1p(FCplxPtr res, const FCplxPtr x, const FCplxPtr y)
{
    (*(std::complex<double>*) res) = std::exp(cplx_log1p(*(std::complex<double>*) x) * (*(std::complex<double>*) y));
}

void Lib_FCplx_Pow1pm1(FCplxPtr res, const FCplxPtr x, const FCplxPtr y)
{
    (*(std::complex<double>*) res) = cplx_expm1(cplx_log1p(*(std::complex<double>*) x) * (*(std::complex<double>*) y));
}

void Lib_FCplx_Pow_Si(FCplxPtr res, const FCplxPtr x, const int32_t k)
{
	(*(std::complex<double>*) res) = std::pow(*(std::complex<double>*) x, k);
}

void Lib_FCplx_Compound_Si(FCplxPtr res, const FCplxPtr x, const int32_t k)
{
	(*(std::complex<double>*) res) = std::pow((1.0) + (*(std::complex<double>*) x), k);
}





/* Trigonometric functions  */

void Lib_FCplx_Sin(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::sin(*(std::complex<double>*) x);
}

void Lib_FCplx_Cos(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::cos(*(std::complex<double>*) x);
}

void Lib_FCplx_Tan(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::tan(*(std::complex<double>*) x);
}

void Lib_FCplx_Csc(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = (1.0) / std::sin(*(std::complex<double>*) x);
}

void Lib_FCplx_Sec(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = (1.0) / std::cos(*(std::complex<double>*) x);
}

void Lib_FCplx_Cot(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = (1.0) / std::tan(*(std::complex<double>*) x);
}



void Lib_FCplx_SinPi(FCplxPtr res, const FCplxPtr z)
{
//	(*(std::complex<double>*) res) = std::sin(*(std::complex<double>*) x);
}

void Lib_FCplx_CosPi(FCplxPtr res, const FCplxPtr x)
{
//	(*(std::complex<double>*) res) = std::cos(*(std::complex<double>*) x);
}

void Lib_FCplx_TanPi(FCplxPtr res, const FCplxPtr x)
{
//	(*(std::complex<double>*) res) = std::tan(*(std::complex<double>*) x);
}




/* Hyperbolic functions  */

void Lib_FCplx_Sinh(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::sinh(*(std::complex<double>*) x);
}

void Lib_FCplx_Cosh(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::cosh(*(std::complex<double>*) x);
}

void Lib_FCplx_Tanh(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::tanh(*(std::complex<double>*) x);
}

void Lib_FCplx_Csch(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = (1.0) / std::sinh(*(std::complex<double>*) x);
}

void Lib_FCplx_Sech(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = (1.0) / std::cosh(*(std::complex<double>*) x);
}

void Lib_FCplx_Coth(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = (1.0) / std::tanh(*(std::complex<double>*) x);
}





/* Inverse trigonometric functions  */

void Lib_FCplx_Asin(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::asin(*(std::complex<double>*) x);
}

void Lib_FCplx_Acos(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::acos(*(std::complex<double>*) x);
}

void Lib_FCplx_Atan(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::atan(*(std::complex<double>*) x);
}


void Lib_FCplx_Acsc(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::asin((1.0) / (*(std::complex<double>*) x));
}

void Lib_FCplx_Asec(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::acos((1.0) / (*(std::complex<double>*) x));
}

void Lib_FCplx_Acot(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::atan((1.0) / (*(std::complex<double>*) x));
}






/* Inverse hyperbolic functions  */

void Lib_FCplx_Asinh(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::asinh(*(std::complex<double>*) x);
}

void Lib_FCplx_Acosh(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::acosh(*(std::complex<double>*) x);
}

void Lib_FCplx_Atanh(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::atanh(*(std::complex<double>*) x);
}



void Lib_FCplx_Acsch(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::asinh((1.0) / (*(std::complex<double>*) x));
}

void Lib_FCplx_Asech(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::acosh((1.0) / (*(std::complex<double>*) x));
}

void Lib_FCplx_Acoth(FCplxPtr res, const FCplxPtr x)
{
	(*(std::complex<double>*) res) = std::atanh((1.0) / (*(std::complex<double>*) x));
}

















//*********************** Boost Numerical Calculus, double precision **********************************

//
//
//
//
//void Lib_FReal_BracketRoot(double* res1, double* res2, int* iter, FRealFuncPtr f1, double* guess, double* factor, bool is_rising, int get_digits, unsigned int maxit)
//{
//    LibFReal_BracketRoot(res1, res2, iter, f1, guess, factor, is_rising, get_digits, maxit);
//}
//
//
//
//void Lib_FReal_NewtonRaphson(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit)
//{
//    LibFReal_NewtonRaphson(res, iter, f1, f2, guess, xmin, xmax, get_digits, maxit);
//}
//
//
//
//void Lib_FReal_Halley(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit)
//{
//    LibFReal_Halley(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
//}
//
//
//
//void Lib_FReal_Schroder(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit)
//{
//    LibFReal_Schroder(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
//}
//
//
//
//void Lib_FReal_Brent_Minimum(double* res, double* resFx, int* iter, FRealFuncPtr f1, double* bracket_min, double* bracket_max, int bits, unsigned int maxit)
//{
//    LibFReal_Brent_Minimum(res, resFx, iter, f1, bracket_min, bracket_max, bits, maxit);
//}
//
//
//
//
//void Lib_FReal_Trapezoidal(double* res1, double* res2, double* res3, FRealFuncPtr f1, double* a, double* b)
//{
//    LibFReal_Trapezoidal(res1, res2, res3, f1, a, b);
//}
//
//
//// 7, 15, 20, 25 and 30
//
//void Lib_FReal_GaussLegendre(double* res1, double* res3, FRealFuncPtr f1, double* a, double* b)
//{
//    LibFReal_GaussLegendre(res1, res3, f1, a, b);
//}
//
//
//
////15, 31, 41, 51 and 61
//
//void Lib_FReal_GaussKronrod(double* res1, double* res2, double* res3, FRealFuncPtr f1, double* a, double* b)
//{
//    LibFReal_GaussKronrod(res1, res2, res3, f1, a, b);
//}
//
//
//
//void Lib_FReal_TanhSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1, double* a, double* b)
//{
//    LibFReal_TanhSinh(res1, res2, res3, levels_, f1, a, b);
//}
//
//
//
//void Lib_FReal_SinhSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1)
//{
//    LibFReal_SinhSinh(res1, res2, res3, levels_, f1);
//}
//
//
//
//void Lib_FReal_ExpSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1)
//{
//    LibFReal_ExpSinh(res1, res2, res3, levels_, f1);
//}
//
//
//
//void Lib_FReal_Ooura_Cos(double* res1, double* res2, FRealFuncPtr f1)
//{
//    LibFReal_Ooura_Cos(res1, res2, f1);
//}
//
//
//
//void Lib_FReal_Ooura_Sin(double* res1, double* res2, FRealFuncPtr f1)
//{
//    LibFReal_Ooura_Sin(res1, res2, f1);
//}
//
//
//
//






//*********************** Boost Odeint **********************************


void Lib_FReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt)
{
	LibFReal_Const_RungeKutta4((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_FReal_Const_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt)
{
	LibFReal_Const_RungeKuttaCashKarp54((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_FReal_Const_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt)
{
	LibFReal_Const_RungeKuttaDopri5((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_FReal_Const_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt)
{
	LibFReal_Const_RungeKuttaFehlberg78((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_FReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt)
{
	LibFReal_Const_AdamsBashforthMoulton((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt);
}



void Lib_FReal_Adaptive_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt, double* eps_abs, double* eps_rel)
{
	LibFReal_Adaptive_RungeKuttaDopri5((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_FReal_Adaptive_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt, double* eps_abs, double* eps_rel)
{
	LibFReal_Adaptive_RungeKuttaCashKarp54((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_FReal_Adaptive_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt, double* eps_abs, double* eps_rel)
{
	LibFReal_Adaptive_RungeKuttaFehlberg78((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_FReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt, double* eps_abs, double* eps_rel)
{
	LibFReal_Adaptive_BulirschStoer((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_FReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt, double* eps_abs, double* eps_rel)
{
	LibFReal_DenseOutput_Dopri5((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}


void Lib_FReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, double* start_time, double* end_time, double* dt, double* eps_abs, double* eps_rel)
{
	LibFReal_DenseOutput_BulirschStoer((FAnyFuncPtr3)f1, (FAnyFuncPtr2)f2, (FStatePtr)matX, *start_time, *end_time, *dt, *eps_abs, *eps_rel);
}






















