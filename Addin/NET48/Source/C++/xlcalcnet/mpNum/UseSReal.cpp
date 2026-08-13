
#include "mpNumC_Main.h"
#include "BoostSReal.h"

#include "stdint.h"
#include <complex>
#include <limits>

using namespace std;
using namespace std::numbers;




/** ********************** Real Basic Functions, single precision ******************************** **/


float* Lib_SReal_Init_Func()
{
	float* x = NULL;
	x = (float*)malloc(sizeof(float));
	*x = 0.0f;
	return x;
}


void Lib_SReal_Clear(float* x)
{
	free(x);
}


/* Input and output  */


void Lib_SReal_Set(float* res, const float* x)
{
	*res = (*x);
}



void Lib_SReal_Set_QReal(float* res, const QRealPtr x)
{
	*res = (*(__float128*)x);
}

void Lib_SReal_Set_LD(float* res, const long double* x)
{
	*res = (*x);
}

void Lib_SReal_Set_D(float* res, const double x)
{
	*res = x;
}






void Lib_SReal_Set_Si(float* res, const int32_t x)
{
	*res = x;
}

void Lib_SReal_Set_Ui(float* res, const uint32_t x)
{
	*res = x;
}

void Lib_SReal_Set_Si64(float* res, const int64_t x)
{
	*res = x;
}

void Lib_SReal_Set_Ui64(float* res, const uint64_t x)
{
	*res = x;
}

void Lib_SReal_Get_Str(char * dest, const char* template1, const float* x)
{
    snprintf (dest, 128, "%1.6e", *x);
}

void Lib_SReal_Set_Str(float* res, const char * str)
{
    *res = std::strtof(str, NULL);
}

float Lib_SReal_Get_Single(float* x)
{
    return *x;
}





/* Operator overloading vs raw arithmetic and comparisons  */


void Lib_SReal_Neg(float* res, const float* x)
{
	*res = -(*x);
}

void Lib_SReal_Add(float* res, const float* x, const float* y)
{
	*res = (*x) + (*y);
}

void Lib_SReal_Sub(float* res, const float* x, const float* y)
{
	*res = (*x) - (*y);
}

void Lib_SReal_Mul(float* res, const float* x, const float* y)
{
	*res = (*x) * (*y);
}

void Lib_SReal_Div(float* res, const float* x, const float* y)
{
	*res = (*x) / (*y);
}


void Lib_SReal_Add_D(float* res, const float* x, const double y)
{
	*res = (*x) + y;
}

void Lib_SReal_Sub_D(float* res, const float* x, const double y)
{
	*res = (*x) - y;
}

void Lib_SReal_D_Sub(float* res, const float* x, const double y)
{
	*res = y - (*x);
}

void Lib_SReal_Mul_D(float* res, const float* x, const double y)
{
	*res = (*x) * y;
}

void Lib_SReal_Div_D(float* res, const float* x, const double y)
{
	*res = (*x) / y;
}

void Lib_SReal_D_Div(float* res, const float* x, const double y)
{
	*res = y / (*x);
}



void Lib_SReal_Add_Si(float* res, const float* x, const int32_t y)
{
	*res = (*x) + y;
}

void Lib_SReal_Sub_Si(float* res, const float* x, const int32_t y)
{
	*res = (*x) - y;
}

void Lib_SReal_Si_Sub(float* res, const float* x, const int32_t y)
{
	*res = y - (*x);
}

void Lib_SReal_Mul_Si(float* res, const float* x, const int32_t y)
{
	*res = (*x) * y;
}

void Lib_SReal_Div_Si(float* res, const float* x, const int32_t y)
{
	*res = (*x) / y;
}

void Lib_SReal_Si_Div(float* res, const float* x, const int32_t y)
{
	*res = y / (*x);
}



int32_t Lib_SReal_LT(const float* x, const float* y)
{
	return (*x) < (*y);
}

int32_t Lib_SReal_GE(const float* x, const float* y)
{
	return (*x) >= (*y);
}

int32_t Lib_SReal_GT(const float* x, const float* y)
{
	return (*x) > (*y);
}

int32_t Lib_SReal_LE(const float* x, const float* y)
{
	return (*x) <= (*y);
}

int32_t Lib_SReal_EQ(const float* x, const float* y)
{
	return (*x) == (*y);
}

int32_t Lib_SReal_NE(const float* x, const float* y)
{
	return (*x) != (*y);
}







/* General functions for real numbers  */

void Lib_SReal_Fma(float* res, const float* x, const float* y, const float* z)
{
	*res = fmaf( (*x) , (*y) , (*z) );
}

void Lib_SReal_Fmax(float* res, const float* x, const float* y)
{
	*res = fmaxf( (*x) , (*y) );
}

void Lib_SReal_Fmin(float* res, const float* x, const float* y)
{
	*res = fminf( (*x) , (*y) );
}





/* Machine constants and properties of numbers  */


void Lib_SReal_Zero(float* res)
{
	*res = 0.0f;
}

void Lib_SReal_NegZero(float* res)
{
	*res = -0.0f;
}

void Lib_SReal_One(float* res)
{
	*res = 1.0f;
}

void Lib_SReal_Inf(float* res)
{
	*res = (std::numeric_limits<float>::infinity)();
}

void Lib_SReal_NegInf(float* res)
{
	*res = -(std::numeric_limits<float>::infinity)();
}

void Lib_SReal_Nan(float* res)
{
	*res = std::numeric_limits<float>::quiet_NaN();
}




/* Properties of numbers  */

int Lib_SReal_Signbit(const float* x)
{
	return int(std::signbit(*x));
}

int Lib_SReal_Finite(const float* x)
{
	return std::isfinite(*x);
}

int Lib_SReal_Isinf(const float* x)
{
	return std::isinf(*x);
}

int Lib_SReal_Isposinf(const float* x)
{
	return (std::isinf(*x) & (*x > 0.0));
}

int Lib_SReal_Isneginf(const float* x)
{
	return (std::isinf(*x) & (*x < 0.0));
}

int Lib_SReal_Isnan(const float* x)
{
	return std::isnan(*x);
}


int Lib_SReal_Iszero(const float* x)
{
	return (std::abs(*x) == 0.0f);
}

int Lib_SReal_Isposzero(const float* x)
{
	return ((int(std::signbit(*x)) == 0) & (std::abs(*x) == 0.0f));
}

int Lib_SReal_Isnegzero(const float* x)
{
	return ((int(std::signbit(*x)) != 0) & (std::abs(*x) == 0.0f));
}

int Lib_SReal_Isone(const float* x)
{
	return (*x == 1.0f);
}

int Lib_SReal_Isinteger(const float* x)
{
	return (std::ceil(*x) == std::floor(*x));
}

int Lib_SReal_Isnumber(const float* x)
{
	return (!(std::isnan(*x) || (std::isinf(*x))));
}

int Lib_SReal_Isregular(const float* x)
{
	return (!(std::isnan(*x) || (std::isinf(*x) || (std::abs(*x) == 0.0f))));
}

int Lib_SReal_Isnormal(const float* x)
{
	return (std::isnormal(*x));
}

int Lib_SReal_Issubnormal(const float* x)
{
	return (std::fpclassify(*x)) == FP_SUBNORMAL;
}

int Lib_SReal_Isunordered(const float* x, const float* y)
{
	return (std::isunordered(*x, *y));
}




int Lib_SReal_FitsInt32(const float* x)
{
	return  ((*x <= std::numeric_limits<int32_t>::max()) &
             (*x >= std::numeric_limits<int32_t>::min()));
}

int Lib_SReal_FitsInt64(const float* x)
{
	return  ((*x <= std::numeric_limits<int64_t>::max()) &
             (*x >= std::numeric_limits<int64_t>::min()));
}

int Lib_SReal_FitsUInt32(const float* x)
{
	return  ((*x <= std::numeric_limits<uint32_t>::max()) &
             (*x >= std::numeric_limits<uint32_t>::min()));
}

int Lib_SReal_FitsUInt64(const float* x)
{
	return  ((*x <= std::numeric_limits<uint64_t>::max()) &
             (*x >= std::numeric_limits<uint64_t>::min()));
}




/* Integer Related Functions  */

void Lib_SReal_Nearbyint(float* res, const float* x)
{
	*res = nearbyintf(*x);
}

void Lib_SReal_Rint(float* res, const float* x)
{
	*res = rintf(*x);
}

long int Lib_SReal_Lrint(const float* x)
{
	return lrintf(*x);
}

long long int Lib_SReal_Llrint(const float* x)
{
	return llrintf(*x);
}


void Lib_SReal_Ceil(float* res, const float* x)
{
	*res = std::ceil(*x);
}

void Lib_SReal_Floor(float* res, const float* x)
{
	*res = std::floor(*x);
}

void Lib_SReal_Trunc(float* res, const float* x)
{
	*res = truncf(*x);
}

void Lib_SReal_Round(float* res, const float* x)
{
	*res = roundf(*x);
}

long int Lib_SReal_Lround(const float* x)
{
	return lroundf(*x);
}

long long int Lib_SReal_Llround(const float* x)
{
	return llroundf(*x);
}

int32_t Lib_SReal_ToInt32(const float* x)
{
    if (*x >= std::numeric_limits<int32_t>::max())
        return std::numeric_limits<int32_t>::max();
    else if (*x <= std::numeric_limits<int32_t>::min())
        return std::numeric_limits<int32_t>::min();
    else
        return (int32_t) (*x);
}

int64_t Lib_SReal_ToInt64(const float* x)
{
    if (*x >= std::numeric_limits<int64_t>::max())
        return std::numeric_limits<int64_t>::max();
    else if (*x <= std::numeric_limits<int64_t>::min())
        return std::numeric_limits<int64_t>::min();
    else
        return (int64_t) (*x);
}

uint32_t Lib_SReal_ToUInt32(const float* x)
{
    if (*x >= std::numeric_limits<uint32_t>::max())
        return std::numeric_limits<uint32_t>::max();
    else if (*x <= std::numeric_limits<uint32_t>::min())
        return std::numeric_limits<uint32_t>::min();
    else
        return (uint32_t) (*x);
}

uint64_t Lib_SReal_ToUInt64(const float* x)
{
    if (*x >= std::numeric_limits<uint64_t>::max())
        return std::numeric_limits<uint64_t>::max();
    else if (*x <= std::numeric_limits<uint64_t>::min())
        return std::numeric_limits<uint64_t>::min();
    else
        return (uint64_t) (*x);
}








/* Floating point functions for real numbers */

void Lib_SReal_Copysign(float* res, const float* x, const float* y)
{
	*res = copysignf( (*x) , (*y) );
}

void Lib_SReal_Frexp(float* res, const float* x, int* e)
{
	*res = frexpf(*(float*)x, e);
}

void Lib_SReal_Logb(float* res, const float* x)
{
	*res = logbf(*(float*)x);
}

int Lib_SReal_Ilogb(const float* x)
{
	return ilogbf(*x);
}

void Lib_SReal_Ldexp(float* res, const float* x, const int e)
{
	*res = ldexpf(*x, e);
}

void Lib_SReal_Scalbln(float* res, const float* x, const long int e)
{
	*res = scalblnf(*x, e);
}

void Lib_SReal_Scalbn(float* res, const float* x, const int e)
{
	*res = scalbnf(*x, e);
}

void Lib_SReal_Fdim(float* res, const float* x, const float* y)
{
	*res = fdimf( (*x) , (*y) );
}




/* Fraction and Remainder Related Functions  */

void Lib_SReal_Modf(float* frac, const float* x, float* iptr)
{
	*frac = modff(*x, iptr);
}

void Lib_SReal_Fmod(float* res, const float* x, const float* y)
{
	*res = fmodf(*x , *y);
}

void Lib_SReal_Remainder(float* res, const float* x, const float* y)
{
	*res = remainderf( (*x) , (*y) );
}

void Lib_SReal_Remquo(float* res, const float* x, const float* y, int* e)
{
	*res = remquof( (*x) , (*y), e );
}




/* Functions related to mantissa width and exponent range */

void Lib_SReal_Epsilon(float* res)
{
	*res = (std::numeric_limits<float>::epsilon)();
}

void Lib_SReal_Ulp(float* res, const float* x)
{
	LibSReal_Ulp(res, x);
}

void Lib_SReal_Max(float* res)
{
	*res = (std::numeric_limits<float>::max)();
}

void Lib_SReal_Lowest(float* res)
{
	*res = (std::numeric_limits<float>::lowest)();
}

void Lib_SReal_Min(float* res)
{
	*res = (std::numeric_limits<float>::min)();
}

void Lib_SReal_Nexttoward(float* res, const float* x, const float* y)
{
	*res = nexttowardf( (*x) , (*y) );
}

void Lib_SReal_Nextabove(float* res, const float* x)
{
	*res = nexttowardf( (*x) , (std::numeric_limits<float>::infinity)() );
}

void Lib_SReal_Nextbelow(float* res, const float* x)
{
	*res = nexttowardf( (*x) , -(std::numeric_limits<float>::infinity)() );
}




/* Complex components  */

void Lib_SReal_Fabs(float* res, const float* x)
{
	*res = fabs(*x);
}

void Lib_SReal_Sign(float* res, const float* x)
{
	*res = (float)((*x > 0) - (*x < 0));
}












/* Mathematical Constants  */


void Lib_SReal_ConstDegree(float* res)
{
	*res = pi_v<float> / 180;
}

void Lib_SReal_ConstPhi(float* res)
{
	*res = phi_v<float>;
}

void Lib_SReal_ConstLog2(float* res)
{
	*res = ln2_v<float>;
}

void Lib_SReal_ConstLog10(float* res)
{
	*res = ln10_v<float>;
}

void Lib_SReal_ConstPi(float* res)
{
	*res = pi_v<float>;
}

void Lib_SReal_ConstE(float* res)
{
	*res = e_v<float>;
}

void Lib_SReal_ConstEulerGamma(float* res)
{
	*res = egamma_v<float>;
}

void Lib_SReal_ConstApery(float* res)
{
	*res = 1.202056903159594f;
}

void Lib_SReal_ConstCatalan(float* res)
{
	*res = 0.915965594177219f;
}

void Lib_SReal_ConstGlaisher(float* res)
{
	*res = 1.282427129100622f;
}

void Lib_SReal_ConstKhinchin(float* res)
{
	*res = 2.685452001065306f;
}





/* Roots and related functions  */

void Lib_SReal_Sqrt(float* res, const float* x)
{
	*res = sqrtf(*x);
}

void Lib_SReal_Sqrt1pm1(float* res, const float* x)
{
    *res = expm1f(log1pf((*x)) * (0.5f));
}

void Lib_SReal_Rsqrt(float* res, const float* x)
{
	*res = (1.0f) / sqrtf(*x);
}

void Lib_SReal_Cbrt(float* res, const float* x)
{
	*res = cbrtf(*x);
}


void Lib_SReal_Root_Si(float* res, const float* x, const int32_t k)
{
	*res = powf(*x, (1.0f)/k);
}



/* Exponential and related functions  */

void Lib_SReal_Exp(float* res, const float* x)
{
	*res = expf(*x);
}

void Lib_SReal_Exp2(float* res, const float* x)
{
	*res = exp2f(*x);
}

void Lib_SReal_Exp10(float* res, const float* x)
{
    *res = expf((*x) * ln10_v<float>);
}

void Lib_SReal_Expm1(float* res, const float* x)
{
	*res = expm1f(*x);
}

void Lib_SReal_Exp2m1(float* res, const float* x)
{
	*res = expm1f((*x) * ln2_v<float>);
}

void Lib_SReal_Exp10m1(float* res, const float* x)
{
	*res = expm1f((*x) * ln10_v<float>);
}



/* Logarithms and related functions  */

void Lib_SReal_Log(float* res, const float* x)
{
	*res = logf(*x);
}

void Lib_SReal_Log2(float* res, const float* x)
{
	*res = log2f(*x);
}

void Lib_SReal_Log10(float* res, const float* x)
{
	*res = log10f(*x);
}

void Lib_SReal_Log1p(float* res, const float* x)
{
	*res = log1pf(*x);
}

void Lib_SReal_Log2p1(float* res, const float* x)
{
	*res = log1pf(*x) / ln2_v<float>;
}

void Lib_SReal_Log10p1(float* res, const float* x)
{
	*res = log1pf(*x) / ln10_v<float>;
}




/* Power functions and roots  */

void Lib_SReal_Square(float* res, const float* x)
{
	*res = (*x) * (*x);
}

void Lib_SReal_Cube(float* res, const float* x)
{
	*res = (*x) * (*x) * (*x);
}

void Lib_SReal_Hypot(float* res, const float* x, const float* y)
{
	*res = hypotf( (*x) , (*y) );
}



void Lib_SReal_Pow(float* res, const float* x, const float* y)
{
	*res = powf( (*x) , (*y) );
}

void Lib_SReal_Powm1(float* res, const float* x, const float* y)
{
    *res = expm1f(logf((*x)) * (*y));
}

void Lib_SReal_Pow1p(float* res, const float* x, const float* y)
{
    *res = expf(log1pf((*x)) * (*y));
}

void Lib_SReal_Pow1pm1(float* res, const float* x, const float* y)
{
    *res = expm1f(log1pf((*x)) * (*y));
}

void Lib_SReal_Pow_Si(float* res, const float* x, const int32_t n)
{
	*res = powf( (*x) , n );
}

void Lib_SReal_Compound_Si(float* res, const float* x, const int32_t n)
{
	*res = powf((1.0f) + (*x) , n );
}




/* Trigonometric functions  */

void Lib_SReal_Sin(float* res, const float* x)
{
	*res = sinf(*x);
}

void Lib_SReal_Cos(float* res, const float* x)
{
	*res = cosf(*x);
}


float cosm1f(float x)
{
    if (std::abs(x) > 0.5)
    {
        return std::cos(x) - 1;
    }
    else
    {
        float res = std::sin((x)/2);
        return  -2 * res * res;
    }
}

void Lib_SReal_Cosm1(float* res, const float* x)
{
	*res = cosm1f(*x);
}



void Lib_SReal_Tan(float* res, const float* x)
{
	*res = tanf(*x);
}


void Lib_SReal_Csc(float* res, const float* x)
{
	*res = (1.0f) / sinf(*x);
}

void Lib_SReal_Sec(float* res, const float* x)
{
	*res = (1.0f) / cosf(*x);
}

void Lib_SReal_Cot(float* res, const float* x)
{
	*res = (1.0f) / tanf(*x);
}



void Lib_SReal_SinPi(float* res, const float* x)
{
    LibSReal_SinPi(res, x);
}

void Lib_SReal_CosPi(float* res, const float* x)
{
    LibSReal_CosPi(res, x);
}

void Lib_SReal_TanPi(float* res, const float* x)
{
    LibSReal_TanPi(res, x);
}



void Lib_SReal_CscPi(float* res, const float* x)
{
    LibSReal_CscPi(res, x);
}

void Lib_SReal_SecPi(float* res, const float* x)
{
    LibSReal_SecPi(res, x);
}

void Lib_SReal_CotPi(float* res, const float* x)
{
    LibSReal_CotPi(res, x);
}



/* Hyperbolic functions  */

void Lib_SReal_Sinh(float* res, const float* x)
{
	*res = sinhf(*x);
}

void Lib_SReal_Cosh(float* res, const float* x)
{
	*res = coshf(*x);
}

void Lib_SReal_Tanh(float* res, const float* x)
{
	*res = tanhf(*x);
}


void Lib_SReal_Csch(float* res, const float* x)
{
	*res = (1.0f) / sinhf(*x);
}

void Lib_SReal_Sech(float* res, const float* x)
{
	*res = (1.0f) / coshf(*x);
}

void Lib_SReal_Coth(float* res, const float* x)
{
	*res = (1.0f) / tanhf(*x);
}







/* Inverse trigonometric functions  */

void Lib_SReal_Asin(float* res, const float* x)
{
	*res = asinf(*x);
}

void Lib_SReal_Acos(float* res, const float* x)
{
	*res = acosf(*x);
}

void Lib_SReal_Atan(float* res, const float* x)
{
	*res = atanf(*x);
}

void Lib_SReal_Atan2(float* res, const float* x, const float* y)
{
	*res = atan2f( (*x) , (*y) );
}


void Lib_SReal_Acsc(float* res, const float* x)
{
	*res = asinf((1.0f) / (*x));
}

void Lib_SReal_Asec(float* res, const float* x)
{
	*res = acosf((1.0f) / (*x));
}

void Lib_SReal_Acot(float* res, const float* x)
{
	*res = atanf((1.0f) / (*x));
}



/* Inverse hyperbolic functions  */

void Lib_SReal_Asinh(float* res, const float* x)
{
	*res = asinhf(*x);
}

void Lib_SReal_Acosh(float* res, const float* x)
{
	*res = acoshf(*x);
}

void Lib_SReal_Atanh(float* res, const float* x)
{
	*res = atanhf(*x);
}


void Lib_SReal_Acsch(float* res, const float* x)
{
	*res = asinhf((1.0f) / (*x));
}

void Lib_SReal_Asech(float* res, const float* x)
{
	*res = acoshf((1.0f) / (*x));
}

void Lib_SReal_Acoth(float* res, const float* x)
{
	*res = atanhf((1.0f) / (*x));
}







/* Special functions  */

void Lib_SReal_Erf(float* res, const float* x)
{
	*res = erff(*x);
}

void Lib_SReal_Erfc(float* res, const float* x)
{
	*res = erfcf(*x);
}


void Lib_SReal_Tgamma(float* res, const float* x)
{
	*res = tgammaf(*x);
}

void Lib_SReal_Lgamma(float* res, const float* x)
{
	*res = lgammaf(*x);
}

void Lib_SReal_BesselJ0(float* res, const float* x)
{
	*res = std::cyl_bessel_jf(0.0f, *x);
}

void Lib_SReal_BesselJ1(float* res, const float* x)
{
	*res = std::cyl_bessel_jf(1.0f, *x);
}

void Lib_SReal_BesselJn(float* res, const float* n, const float* x)
{
	*res = std::cyl_bessel_jf(*n, *x);
}


void Lib_SReal_BesselY0(float* res, const float* x)
{
	*res = std::cyl_neumannf(0.0f, *x);
}

void Lib_SReal_BesselY1(float* res, const float* x)
{
	*res = std::cyl_neumannf(1.0f, *x);
}

void Lib_SReal_BesselYn(float* res, const float* n, const float* x)
{
	*res = std::cyl_neumannf(*n, *x);
}











/** ********************** Complex Basic Functions, single precision ******************************** **/



SCplxPtr Lib_SCplx_Init_Func()
{
	SCplxPtr x = NULL;
	x = (std::complex<float>*) malloc(sizeof(std::complex<float>));
	return x;
}

void Lib_SCplx_Clear(SCplxPtr x)
{
	free(x);
}


/* Input and output  */

void Lib_SCplx_Set(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res)  = (*(std::complex<float>*) x);
}


/* Operator overloading vs raw arithmetic and comparisons  */

void Lib_SCplx_Neg(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = -(*(std::complex<float>*) x);
}

void Lib_SCplx_Add(SCplxPtr res, const SCplxPtr x, const SCplxPtr y)
{
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) + (*(std::complex<float>*) y);
}

void Lib_SCplx_Sub(SCplxPtr res, const SCplxPtr x, const SCplxPtr y)
{
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) - (*(std::complex<float>*) y);
}

void Lib_SCplx_Mul(SCplxPtr res, const SCplxPtr x, const SCplxPtr y)
{
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) * (*(std::complex<float>*) y);
}

void Lib_SCplx_Div(SCplxPtr res, const SCplxPtr x, const SCplxPtr y)
{
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) / (*(std::complex<float>*) y);
}


void Lib_SCplx_Add_SReal(SCplxPtr res, const SCplxPtr x, const float* y)
{
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) + (*y);
}

void Lib_SCplx_Sub_SReal(SCplxPtr res, const SCplxPtr x, const float* y)
{
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) - (*y);
}

void Lib_SCplx_SReal_Sub(SCplxPtr res, const SCplxPtr y, const float* x)
{
	(*(std::complex<float>*) res) = (*x) - (*(std::complex<float>*) y);
}


void Lib_SCplx_Mul_SReal(SCplxPtr res, const SCplxPtr x, const float* y)
{
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) * (*y);
}

void Lib_SCplx_Div_SReal(SCplxPtr res, const SCplxPtr x, const float* y)
{
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) / (*y);
}

void Lib_SCplx_SReal_Div(SCplxPtr res, const SCplxPtr y, const float* x)
{
	(*(std::complex<float>*) res) = (*x) / (*(std::complex<float>*) y);
}


void Lib_SCplx_Add_D(SCplxPtr res, const SCplxPtr x, const double y)
{
    float temp = y;
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) + temp;
}

void Lib_SCplx_Sub_D(SCplxPtr res, const SCplxPtr x, const double y)
{
    float temp = y;
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) - temp;
}

void Lib_SCplx_D_Sub(SCplxPtr res, const SCplxPtr y, const double x)
{
    float temp = x;
	(*(std::complex<float>*) res) = temp - (*(std::complex<float>*) y);
}


void Lib_SCplx_Mul_D(SCplxPtr res, const SCplxPtr x, const double y)
{
    float temp = y;
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) * temp;
}

void Lib_SCplx_Div_D(SCplxPtr res, const SCplxPtr x, const double y)
{
    float temp = y;
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) / temp;
}

void Lib_SCplx_D_Div(SCplxPtr res, const SCplxPtr y, const double x)
{
    float temp = x;
	(*(std::complex<float>*) res) = temp / (*(std::complex<float>*) y);
}


void Lib_SCplx_Add_Si(SCplxPtr res, const SCplxPtr x, const int32_t y)
{
    float temp = y;
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) + temp;
}

void Lib_SCplx_Sub_Si(SCplxPtr res, const SCplxPtr x, const int32_t y)
{
    float temp = y;
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) - temp;
}

void Lib_SCplx_Si_Sub(SCplxPtr res, const SCplxPtr y, const int32_t x)
{
    float temp = x;
	(*(std::complex<float>*) res) = temp - (*(std::complex<float>*) y);
}


void Lib_SCplx_Mul_Si(SCplxPtr res, const SCplxPtr x, const int32_t y)
{
    float temp = y;
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) * temp;
}

void Lib_SCplx_Div_Si(SCplxPtr res, const SCplxPtr x, const int32_t y)
{
    float temp = y;
	(*(std::complex<float>*) res) = (*(std::complex<float>*) x) / temp;
}

void Lib_SCplx_Si_Div(SCplxPtr res, const SCplxPtr y, const int32_t x)
{
    float temp = x;
	(*(std::complex<float>*) res) = temp / (*(std::complex<float>*) y);
}



/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void Lib_SCplx_Set_Real(SCplxPtr res, const float* re)
{
	(*(std::complex<float>*) res) = std::complex<float>(*re, 0.0f);
}

void Lib_SCplx_Set2(SCplxPtr res, const float* re, const float* im)
{
	(*(std::complex<float>*) res) = std::complex<float>(*re, *im);
}


void Lib_SCplx_Abs(float* res, const SCplxPtr x)
{
	*res = std::abs(*(std::complex<float>*) x);
}

void Lib_SCplx_Arg(float* res, const SCplxPtr x)
{
	*res = std::arg(*(std::complex<float>*) x);
}

void Lib_SCplx_Imag(float* res, const SCplxPtr x)
{
	*res = (*(std::complex<float>*) x).imag();
}

void Lib_SCplx_Real(float* res, const SCplxPtr x)
{
	*res = (*(std::complex<float>*) x).real();
}

void Lib_SCplx_Conj(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::conj(*(std::complex<float>*) x);
}

void Lib_SCplx_Proj(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::proj(*(std::complex<float>*) x);
}





/* Roots  */


std::complex<float> cplx_expm1f(std::complex<float> z)
{
    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
	float x = z.real();
	float y = z.imag();
	float resx =  std::expm1(x) * std::cos(y) + cosm1f(y);
	float resy =  std::exp(x) * std::sin(y);
	return std::complex<float>(resx, resy);
}



std::complex<float> cplx_log1pf(std::complex<float> z)
{
    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
    /* resy =  atan2(y, 1 + x); */
	float x = z.real();
	float y = z.imag();
	float resx = 0.0 ;
	if ( (std::abs(x) > 0.75) || (std::abs(y) > 0.75) || (x < -0.5) )
    {
        resx = std::log(std::hypot(1 + x, y)) ;
    }
    else
    {
        resx = 0.5 * std::log1p(2*x + x*x + y*y);
    }
	float resy = std::atan2(y, 1 + x); ;
	return std::complex<float>(resx, resy);
}


void Lib_SCplx_Sqrt(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::sqrt(*(std::complex<float>*) x);
}


void Lib_SCplx_Sqrt1pm1(SCplxPtr res, const SCplxPtr x)
{
    (*(std::complex<float>*) res) = cplx_expm1f(cplx_log1pf(*(std::complex<float>*) x) * (0.5f));
}


void Lib_SCplx_Rsqrt(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = (1.0f) / std::sqrt(*(std::complex<float>*) x);
}


void Lib_SCplx_Cbrt(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::pow(*(std::complex<float>*) x, (1.0f)/(3.0f));
}


void Lib_SCplx_Root_Si(SCplxPtr res, const SCplxPtr x, const int32_t k)
{
	(*(std::complex<float>*) res) = std::pow(*(std::complex<float>*) x, (1.0f)/k);
}




/* Exponential and related functions  */

void Lib_SCplx_Exp(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::exp(*(std::complex<float>*) x);
}


void Lib_SCplx_Exp2(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::exp( (*(std::complex<float>*) x) * ln2_v<float>);
}


void Lib_SCplx_Exp10(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::exp( (*(std::complex<float>*) x) * ln10_v<float>);
}


void Lib_SCplx_Expm1(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) =  cplx_expm1f(*(std::complex<float>*) x);
}


void Lib_SCplx_Exp2m1(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) =  cplx_expm1f((*(std::complex<float>*) x) * ln2_v<float>);
}


void Lib_SCplx_Exp10m1(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) =  cplx_expm1f((*(std::complex<float>*) x) * ln10_v<float>);
}



/* Logarithms and related functions  */

void Lib_SCplx_Log(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::log(*(std::complex<float>*) x);
}

void Lib_SCplx_Log2(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::log(*(std::complex<float>*) x) / ln2_v<float>;
}

void Lib_SCplx_Log10(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::log10(*(std::complex<float>*) x);
}

void Lib_SCplx_Log1p(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = cplx_log1pf(*(std::complex<float>*) x);
}

void Lib_SCplx_Log2p1(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = cplx_log1pf(*(std::complex<float>*) x) / ln2_v<float>;
}

void Lib_SCplx_Log10p1(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = cplx_log1pf(*(std::complex<float>*) x) / ln10_v<float>;
}





/* Power functions */

void Lib_SCplx_Square(SCplxPtr res, const SCplxPtr x)
{
    std::complex<float> z = *(std::complex<float>*) x;
	(*(std::complex<float>*) res) = z * z;
}

void Lib_SCplx_Cube(SCplxPtr res, const SCplxPtr x)
{
    std::complex<float> z = *(std::complex<float>*) x;
	(*(std::complex<float>*) res) = z * z * z;
}

void Lib_SCplx_Pow(SCplxPtr res, const SCplxPtr x, const SCplxPtr y)
{
	(*(std::complex<float>*) res) = std::pow(*(std::complex<float>*) x, *(std::complex<float>*) y);
}

void Lib_SCplx_Powm1(SCplxPtr res, const SCplxPtr x, const SCplxPtr y)
{
    (*(std::complex<float>*) res) = cplx_expm1f(std::log(*(std::complex<float>*) x) * (*(std::complex<float>*) y));
}

void Lib_SCplx_Pow1p(SCplxPtr res, const SCplxPtr x, const SCplxPtr y)
{
    (*(std::complex<float>*) res) = std::exp(cplx_log1pf(*(std::complex<float>*) x) * (*(std::complex<float>*) y));
}

void Lib_SCplx_Pow1pm1(SCplxPtr res, const SCplxPtr x, const SCplxPtr y)
{
    (*(std::complex<float>*) res) = cplx_expm1f(cplx_log1pf(*(std::complex<float>*) x) * (*(std::complex<float>*) y));
}

void Lib_SCplx_Pow_Si(SCplxPtr res, const SCplxPtr x, const int32_t k)
{
	(*(std::complex<float>*) res) = std::pow(*(std::complex<float>*) x, k);
}

void Lib_SCplx_Compound_Si(SCplxPtr res, const SCplxPtr x, const int32_t k)
{
	(*(std::complex<float>*) res) = std::pow((1.0f) + (*(std::complex<float>*) x), k);
}





/* Trigonometric functions  */

void Lib_SCplx_Sin(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::sin(*(std::complex<float>*) x);
}

void Lib_SCplx_Cos(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::cos(*(std::complex<float>*) x);
}

void Lib_SCplx_Tan(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::tan(*(std::complex<float>*) x);
}

void Lib_SCplx_Csc(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = (1.0f) / std::sin(*(std::complex<float>*) x);
}

void Lib_SCplx_Sec(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = (1.0f) / std::cos(*(std::complex<float>*) x);
}

void Lib_SCplx_Cot(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = (1.0f) / std::tan(*(std::complex<float>*) x);
}



void Lib_SCplx_SinPi(SCplxPtr res, const SCplxPtr z)
{
//	(*(std::complex<float>*) res) = std::sin(*(std::complex<float>*) x);
}

void Lib_SCplx_CosPi(SCplxPtr res, const SCplxPtr x)
{
//	(*(std::complex<float>*) res) = std::cos(*(std::complex<float>*) x);
}

void Lib_SCplx_TanPi(SCplxPtr res, const SCplxPtr x)
{
//	(*(std::complex<float>*) res) = std::tan(*(std::complex<float>*) x);
}




/* Hyperbolic functions  */

void Lib_SCplx_Sinh(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::sinh(*(std::complex<float>*) x);
}

void Lib_SCplx_Cosh(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::cosh(*(std::complex<float>*) x);
}

void Lib_SCplx_Tanh(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::tanh(*(std::complex<float>*) x);
}

void Lib_SCplx_Csch(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = (1.0f) / std::sinh(*(std::complex<float>*) x);
}

void Lib_SCplx_Sech(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = (1.0f) / std::cosh(*(std::complex<float>*) x);
}

void Lib_SCplx_Coth(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = (1.0f) / std::tanh(*(std::complex<float>*) x);
}





/* Inverse trigonometric functions  */

void Lib_SCplx_Asin(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::asin(*(std::complex<float>*) x);
}

void Lib_SCplx_Acos(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::acos(*(std::complex<float>*) x);
}

void Lib_SCplx_Atan(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::atan(*(std::complex<float>*) x);
}


void Lib_SCplx_Acsc(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::asin((1.0f) / (*(std::complex<float>*) x));
}

void Lib_SCplx_Asec(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::acos((1.0f) / (*(std::complex<float>*) x));
}

void Lib_SCplx_Acot(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::atan((1.0f) / (*(std::complex<float>*) x));
}






/* Inverse hyperbolic functions  */

void Lib_SCplx_Asinh(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::asinh(*(std::complex<float>*) x);
}

void Lib_SCplx_Acosh(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::acosh(*(std::complex<float>*) x);
}

void Lib_SCplx_Atanh(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::atanh(*(std::complex<float>*) x);
}



void Lib_SCplx_Acsch(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::asinh((1.0f) / (*(std::complex<float>*) x));
}

void Lib_SCplx_Asech(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::acosh((1.0f) / (*(std::complex<float>*) x));
}

void Lib_SCplx_Acoth(SCplxPtr res, const SCplxPtr x)
{
	(*(std::complex<float>*) res) = std::atanh((1.0f) / (*(std::complex<float>*) x));
}





















//*********************** Boost Special functions, float precision **********************************



void Lib_SReal_BernoulliB2n(float* res, const int n)
{
    LibSReal_BernoulliB2n(res, n);
}



void Lib_SReal_TangentT2n(float* res, const int n)
{
    LibSReal_TangentT2n(res, n);
}



void Lib_SReal_Sqrt1pm1_Boost(float* res, const float* x)
{
    LibSReal_Sqrt1pm1(res, x);
}



void Lib_SReal_SinPi_Boost(float* res, const float* x)
{
    LibSReal_SinPi(res, x);
}



void Lib_SReal_CosPi_Boost(float* res, const float* x)
{
    LibSReal_CosPi(res, x);
}



void Lib_SReal_SincPi(float* res, const float* x)
{
    LibSReal_SincPi(res, x);
}



void Lib_SReal_SinhcPi(float* res, const float* x)
{
    LibSReal_SinhcPi(res, x);
}



void Lib_SReal_Tgamma_(float* res, const float* x)
{
    LibSReal_Tgamma_(res, x);
}


void Lib_SReal_Tgamma1pm1(float* res, const float* x)
{
    LibSReal_Tgamma1pm1(res, x);
}



void Lib_SReal_Lgamma_(float* res, const float* x)
{
    LibSReal_Lgamma_(res, x);
}



void Lib_SReal_Digamma(float* res, const float* x)
{
    LibSReal_Digamma(res, x);
}



void Lib_SReal_Trigamma(float* res, const float* x)
{
    LibSReal_Trigamma(res, x);
}



void Lib_SReal_Factorial(float* res, const float* x)
{
    LibSReal_Factorial(res, x);
}



void Lib_SReal_DoubleFactorial(float* res, const float* x)
{
    LibSReal_DoubleFactorial(res, x);
}





void Lib_SReal_Erf_(float* res, const float* x)
{
    LibSReal_Erf_(res, x);
}



void Lib_SReal_Erfc_(float* res, const float* x)
{
    LibSReal_Erfc_(res, x);
}



void Lib_SReal_Erf_inv(float* res, const float* x)
{
    LibSReal_Erf_inv(res, x);
}



void Lib_SReal_Erfc_inv(float* res, const float* x)
{
    LibSReal_Erfc_inv(res, x);
}



void Lib_SReal_AiryAi(float* res, const float* x)
{
    LibSReal_AiryAi(res, x);
}



void Lib_SReal_AiryBi(float* res, const float* x)
{
    LibSReal_AiryBi(res, x);
}



void Lib_SReal_AiryAiPrime(float* res, const float* x)
{
    LibSReal_AiryAiPrime(res, x);
}



void Lib_SReal_AiryBiPrime(float* res, const float* x)
{
    LibSReal_AiryBiPrime(res, x);
}



void Lib_SReal_Aizero(float* res, const int n)
{
    LibSReal_Aizero(res, n);
}



void Lib_SReal_Bizero(float* res, const int n)
{
    LibSReal_Bizero(res, n);
}



void Lib_SReal_Ellint_1_K(float* res, const float* x)
{
    LibSReal_Ellint_1_K(res, x);
}



void Lib_SReal_Ellint_2_K(float* res, const float* x)
{
    LibSReal_Ellint_2_K(res, x);
}



void Lib_SReal_Zeta(float* res, const float* x)
{
    LibSReal_Zeta(res, x);
}



void Lib_SReal_Ei(float* res, const float* x)
{
    LibSReal_Ei(res, x);
}



void Lib_SReal_LambertW0(float* res, const float* x)
{
    LibSReal_LambertW0(res, x);
}


void Lib_SReal_LambertWm1(float* res, const float* x)
{
    LibSReal_LambertWm1(res, x);
}



void Lib_SReal_LambertW0Prime(float* res, const float* x)
{
    LibSReal_LambertW0Prime(res, x);
}


void Lib_SReal_LambertWm1Prime(float* res, const float* x)
{
    LibSReal_LambertWm1Prime(res, x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void Lib_SReal_Agm(float* res, const float* a, const float* b)
{
    LibSReal_Agm(res, a, b);
}




void Lib_SReal_Powm1_Boost(float* res, const float* a, const float* b)
{
    LibSReal_Powm1(res, a, b);
}



void Lib_SReal_TgammaRatio(float* res, const float* a, const float* b)
{
    LibSReal_TgammaRatio(res, a, b);
}



void Lib_SReal_TgammaDeltaRatio(float* res, const float* a, const float* b)
{
    LibSReal_TgammaDeltaRatio(res, a, b);
}



void Lib_SReal_Binomial(float* res, const float* n, const float* k)
{
    LibSReal_Binomial(res, n, k);
}

void Lib_SReal_RisingFactorial(float* res, const float* x, const float* n)
{
    LibSReal_RisingFactorial(res, x, n);
}




void Lib_SReal_FallingFactorial(float* res, const float* x, const float* n)
{
    LibSReal_FallingFactorial(res, x, n);
}




void Lib_SReal_BesselJ(float* res, const float* v, const float* x)
{
    LibSReal_BesselJ(res, v, x);
}



void Lib_SReal_BesselY(float* res, const float* v, const float* x)
{
    LibSReal_BesselY(res, v, x);
}



void Lib_SReal_BesselI(float* res, const float* v, const float* x)
{
    LibSReal_BesselI(res, v, x);
}



void Lib_SReal_BesselK(float* res, const float* v, const float* x)
{
    LibSReal_BesselK(res, v, x);
}



void Lib_SReal_SphBessel(float* res, const unsigned v, const float* x)
{
    LibSReal_SphBessel(res, v, x);
}



void Lib_SReal_SphNeumann(float* res, const unsigned v, const float* x)
{
    LibSReal_SphNeumann(res, v, x);
}





void Lib_SReal_BesselJPrime(float* res, const float* v, const float* x)
{
    LibSReal_BesselJPrime(res, v, x);
}



void Lib_SReal_BesselYPrime(float* res, const float* v, const float* x)
{
    LibSReal_BesselYPrime(res, v, x);
}



void Lib_SReal_BesselIPrime(float* res, const float* v, const float* x)
{
    LibSReal_BesselIPrime(res, v, x);
}



void Lib_SReal_BesselKPrime(float* res, const float* v, const float* x)
{
    LibSReal_BesselKPrime(res, v, x);
}



void Lib_SReal_SphBesselPrime(float* res, const unsigned v, const float* x)
{
    LibSReal_SphBesselPrime(res, v, x);
}



void Lib_SReal_SphNeumannPrime(float* res, const unsigned v, const float* x)
{
    LibSReal_SphNeumannPrime(res, v, x);
}





void Lib_SReal_BesselJZero(float* res, const float* v, const int m)
{
    LibSReal_BesselJZero(res, v, m);
}



void Lib_SReal_BesselYZero(float* res, const float* v, const int m)
{
    LibSReal_BesselYZero(res, v, m);
}





void Lib_SReal_GammaP(float* res, const float* a, const float* x)
{
    LibSReal_GammaP(res, a, x);
}


void Lib_SReal_GammaQ(float* res, const float* a, const float* x)
{
    LibSReal_GammaQ(res, a, x);
}


void Lib_SReal_TgammaLower(float* res, const float* a, const float* x)
{
    LibSReal_TgammaLower(res, a, x);
}


void Lib_SReal_TgammaUpper(float* res, const float* a, const float* x)
{
    LibSReal_TgammaUpper(res, a, x);
}




void Lib_SReal_GammaPInv(float* res, const float* a, const float* p)
{
    LibSReal_GammaPInv(res, a, p);
}


void Lib_SReal_GammaQInv(float* res, const float* a, const float* q)
{
    LibSReal_GammaQInv(res, a, q);
}


void Lib_SReal_GammaPInva(float* res, const float* x, const float* p)
{
    LibSReal_GammaPInva(res, x, p);
}


void Lib_SReal_GammaQInva(float* res, const float* x, const float* q)
{
    LibSReal_GammaQInva(res, x, q);
}



void Lib_SReal_GammaPDerivative(float* res, const float* a, const float* x)
{
    LibSReal_GammaPDerivative(res, a, x);
}


void Lib_SReal_Beta(float* res, const float* a, const float* b)
{
    LibSReal_Beta(res, a, b);
}









void Lib_SReal_LegendreP(float* res, int n, const float* x)
{
    LibSReal_LegendreP(res, n, x);
}



void Lib_SReal_LegendreQ(float* res, int n, const float* x)
{
    LibSReal_LegendreQ(res, n, x);
}



void Lib_SReal_Laguerre(float* res, int n, const float* x)
{
    LibSReal_Laguerre(res, n, x);
}



void Lib_SReal_Hermite(float* res, int n, const float* x)
{
    LibSReal_Hermite(res, n, x);
}



void Lib_SReal_ChebyshevT(float* res, int n, const float* x)
{
    LibSReal_ChebyshevT(res, n, x);
}


void Lib_SReal_ChebyshevU(float* res, int n, const float* x)
{
    LibSReal_ChebyshevU(res, n, x);
}



void Lib_SReal_Polygamma(float* res, int n, const float* x)
{
    LibSReal_Polygamma(res, n, x);
}





void Lib_SReal_EllintRC(float* res, const float* x, const float* y)
{
    LibSReal_EllintRC(res, x, y);
}


void Lib_SReal_Ellint1F(float* res, const float* k, const float* phi)
{
    LibSReal_Ellint1F(res, k, phi);
}


void Lib_SReal_Ellint2F(float* res, const float* k, const float* phi)
{
    LibSReal_Ellint2F(res, k, phi);
}


void Lib_SReal_Ellint3K(float* res, const float* k, const float* n)
{
    LibSReal_Ellint3K(res, k, n);
}




void Lib_SReal_JacobiCD(float* res, const float* k, const float* u)
{
    LibSReal_JacobiCD(res, k, u);
}


void Lib_SReal_JacobiCN(float* res, const float* k, const float* u)
{
    LibSReal_JacobiCN(res, k, u);
}


void Lib_SReal_JacobiCS(float* res, const float* k, const float* u)
{
    LibSReal_JacobiCS(res, k, u);
}


void Lib_SReal_JacobiDC(float* res, const float* k, const float* u)
{
    LibSReal_JacobiDC(res, k, u);
}


void Lib_SReal_JacobiDN(float* res, const float* k, const float* u)
{
    LibSReal_JacobiDN(res, k, u);
}


void Lib_SReal_JacobiDS(float* res, const float* k, const float* u)
{
    LibSReal_JacobiDS(res, k, u);
}


void Lib_SReal_JacobiNC(float* res, const float* k, const float* u)
{
    LibSReal_JacobiNC(res, k, u);
}


void Lib_SReal_JacobiND(float* res, const float* k, const float* u)
{
    LibSReal_JacobiND(res, k, u);
}


void Lib_SReal_JacobiNS(float* res, const float* k, const float* u)
{
    LibSReal_JacobiNS(res, k, u);
}


void Lib_SReal_JacobiSC(float* res, const float* k, const float* u)
{
    LibSReal_JacobiSC(res, k, u);
}


void Lib_SReal_JacobiSD(float* res, const float* k, const float* u)
{
    LibSReal_JacobiSD(res, k, u);
}


void Lib_SReal_JacobiSN(float* res, const float* k, const float* u)
{
    LibSReal_JacobiSN(res, k, u);
}



void Lib_SReal_expint(float* res, const unsigned n, const float* x)
{
    LibSReal_expint(res, n, x);
}




void Lib_SReal_OwenT(float* res, const float* h, const float* a)
{
    LibSReal_OwenT(res, h, a);
}





void Lib_SReal_IBeta(float* res, const float* a, const float* b, const float* x)
{
    LibSReal_IBeta(res, a, b, x);
}


void Lib_SReal_IBetac(float* res, const float* a, const float* b, const float* x)
{
    LibSReal_IBetac(res, a, b, x);
}


void Lib_SReal_IBetaNonNormalized(float* res, const float* a, const float* b, const float* x)
{
    LibSReal_IBetaNonNormalized(res, a, b, x);
}


void Lib_SReal_IBetacNonNormalized(float* res, const float* a, const float* b, const float* x)
{
    LibSReal_IBetacNonNormalized(res, a, b, x);
}


void Lib_SReal_IBetaInv(float* res, const float* a, const float* b, const float* p)
{
    LibSReal_IBetaInv(res, a, b, p);
}


void Lib_SReal_IBetacInv(float* res, const float* a, const float* b, const float* q)
{
    LibSReal_IBetacInv(res, a, b, q);
}


void Lib_SReal_IBetaInva(float* res, const float* b, const float* x, const float* p)
{
    LibSReal_IBetaInva(res, b, x, p);
}


void Lib_SReal_IBetacInva(float* res, const float* b, const float* x, const float* q)
{
    LibSReal_IBetacInva(res, b, x, q);
}


void Lib_SReal_IBetaInvb(float* res, const float* a, const float* x, const float* p)
{
    LibSReal_IBetaInvb(res, a, x, p);
}


void Lib_SReal_IBetacInvb(float* res, const float* a, const float* x, const float* q)
{
    LibSReal_IBetacInvb(res, a, x, q);
}


void Lib_SReal_IBetaDerivative(float* res, const float* a, const float* b, const float* x)
{
    LibSReal_IBetaDerivative(res, a, b, x);
}




void Lib_SReal_LegendrePM(float* res, const int n, const int m, const float* x)
{
    LibSReal_LegendrePM(res, n, m, x);
}



void Lib_SReal_LaguerreM(float* res, const int n, const int m, const float* x)
{
    LibSReal_LaguerreM(res, n, m, x);
}





void Lib_SReal_EllipticRF(float* res, const float* x, const float* y, const float* z)
{
    LibSReal_EllipticRF(res, x, y, z);
}



void Lib_SReal_EllipticRD(float* res, const float* x, const float* y, const float* z)
{
    LibSReal_EllipticRD(res, x, y, z);
}



void Lib_SReal_EllipticRG(float* res, const float* x, const float* y, const float* z)
{
    LibSReal_EllipticRG(res, x, y, z);
}



void Lib_SReal_Ellint3F(float* res, const float* k, const float* n, const float* phi)
{
    LibSReal_Ellint3F(res, k, n, phi);
}



void Lib_SReal_Gegenbauer(float* res, const int n, const float* lambda, const float* x)
{
    LibSReal_Gegenbauer(res, n, lambda, x);
}



void Lib_SReal_Jacobi(float* res, const int n, const float* alpha, const float* beta, const float* x)
{
    LibSReal_Jacobi(res, n, alpha, beta, x);
}






void Lib_SReal_SphericalHarmonicR(float* res, const int n, const int m, const float* theta, const float* phi)
{
    LibSReal_SphericalHarmonicR(res, n, m, theta, phi);
}


void Lib_SReal_SphericalHarmonicI(float* res, const int n, const int m, const float* theta, const float* phi)
{
    LibSReal_SphericalHarmonicI(res, n, m, theta, phi);
}


void Lib_SReal_EllipticRJ(float* res, const float* x, const float* y, const float* z, const float* p)
{
    LibSReal_EllipticRJ(res, x, y, z, p);
}


// Hypergeometric and Theta Functions




void Lib_SReal_Hypergeo0F1(float* res, const float* b, const float* x)
{
    LibSReal_Hypergeo0F1(res, b, x);
}



void Lib_SReal_Hypergeo1F1(float* res, const float* a, const float* b, const float* x)
{
    LibSReal_Hypergeo1F1(res, a, b, x);
}



void Lib_SReal_Hypergeo1F1r(float* res, const float* a, const float* b, const float* x)
{
    LibSReal_Hypergeo1F1r(res, a, b, x);
}



void Lib_SReal_LogHypergeo1F1(float* res, const float* a, const float* b, const float* x)
{
    LibSReal_LogHypergeo1F1(res, a, b, x);
}





void Lib_SReal_JacobiTheta1(float* res, const float* x, const float* q)
{
    LibSReal_JacobiTheta1(res, x, q);
}


void Lib_SReal_JacobiTheta2(float* res, const float* x, const float* q)
{
    LibSReal_JacobiTheta2(res, x, q);
}


void Lib_SReal_JacobiTheta3(float* res, const float* x, const float* q)
{
    LibSReal_JacobiTheta3(res, x, q);
}


void Lib_SReal_JacobiTheta4(float* res, const float* x, const float* q)
{
    LibSReal_JacobiTheta4(res, x, q);
}






//*********************** Distributions, float precision  **********************************


void Lib_SReal_ArcsineDist(long Target, float* res, float* xqp, float* a, float* b)
{
    LibSReal_ArcsineDist(Target, res, xqp, a, b);
}


void Lib_SReal_BernoulliDist(long Target, float* res, float* xqp, float* p)
{
    LibSReal_BernoulliDist(Target, res, xqp, p);
}


void Lib_SReal_BetaDist(long Target, float* res, float* xqp, float* a, float* b)
{
    LibSReal_BetaDist(Target, res, xqp, a, b);
}


void Lib_SReal_BinomialDist(long Target, float* res, float* xqp, float* n, float* p)
{
    LibSReal_BinomialDist(Target, res, xqp, n, p);
}


void Lib_SReal_CauchyDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_CauchyDist(Target, res, xqp, location, scale);
}


void Lib_SReal_Chi2Dist(long Target, float* res, float* xqp, float* nu)
{
    LibSReal_Chi2Dist(Target, res, xqp, nu);
}

void Lib_SReal_ExponentialDist(long Target, float* res, float* xqp, float* lambda)
{
    LibSReal_ExponentialDist(Target, res, xqp, lambda);
}


void Lib_SReal_GumbelDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_ExtremeValueDist(Target, res, xqp, location, scale);
}


void Lib_SReal_FisherFDist(long Target, float* res, float* xqp, float* mu, float* nu)
{
    LibSReal_FisherFDist(Target, res, xqp, mu, nu);
}


void Lib_SReal_GammaDist(long Target, float* res, float* xqp, float* shape, float* scale)
{
    LibSReal_GammaDist(Target, res, xqp, shape, scale);
}


void Lib_SReal_GeometricDist(long Target, float* res, float* xqp, float* p)
{
    LibSReal_GeometricDist(Target, res, xqp, p);
}


void Lib_SReal_HypergeometricDist(long Target, float* res, float* xqp, uint64_t r, uint64_t n, uint64_t N)
{
    LibSReal_HypergeometricDist(Target, res, xqp, r, n, N);
}


void Lib_SReal_InverseChi2Dist(long Target, float* res, float* xqp, float* df, float* scale)
{
    LibSReal_InverseChi2Dist(Target, res, xqp, df, scale);
}



void Lib_SReal_InverseGammaDist(long Target, float* res, float* xqp, float* shape, float* scale)
{
    LibSReal_InverseGammaDist(Target, res, xqp, shape, scale);
}


void Lib_SReal_WaldDist(long Target, float* res, float* xqp, float* mean_, float* scale)
{
    LibSReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
}


void Lib_SReal_LaplaceDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_LaplaceDist(Target, res, xqp, location, scale);
}


void Lib_SReal_LogisticDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_LogisticDist(Target, res, xqp, location, scale);
}


void Lib_SReal_LognormalDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_LognormalDist(Target, res, xqp, location, scale);
}


void Lib_SReal_NegBinomialDist(long Target, float* res, float* xqp, float* n, float* p)
{
    LibSReal_NegBinomialDist(Target, res, xqp, n, p);
}


void Lib_SReal_Chi2NcDist(long Target, float* res, float* xqp, float* nu, float* nc)
{
    LibSReal_Chi2NCDist(Target, res, xqp, nu, nc);
}


void Lib_SReal_StudentTNcDist(long Target, float* res, float* xqp, float* nu, float* delta)
{
    LibSReal_StudentTNCDist(Target, res, xqp, nu, delta);
}


void Lib_SReal_FisherNcDist(long Target, float* res, float* xqp, float* mu, float* nu, float* nc)
{
    LibSReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
}


void Lib_SReal_BetaNcDist(long Target, float* res, float* xqp, float* a, float* b, float* nc)
{
    LibSReal_BetaNCDist(Target, res, xqp, a, b, nc);
}


void Lib_SReal_NormalDist(long Target, float* res, float* xqp, float* mean_, float* stdev)
{
    LibSReal_NormalDist(Target, res, xqp, mean_, stdev);
}


void Lib_SReal_ParetoDist(long Target, float* res, float* xqp, float* shape, float* scale)
{
    LibSReal_ParetoDist(Target, res, xqp, shape, scale);
}


void Lib_SReal_PoissonDist(long Target, float* res, float* xqp, float* nu)
{
    LibSReal_PoissonDist(Target, res, xqp, nu);
}


void Lib_SReal_RayleighDist(long Target, float* res, float* xqp, float* nu)
{
    LibSReal_RayleighDist(Target, res, xqp, nu);
}


void Lib_SReal_SkewNormalDist(long Target, float* res, float* xqp, float* mean_, float* scale, float* shape)
{
    LibSReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
}


void Lib_SReal_StudentTDist(long Target, float* res, float* xqp, float* nu)
{
    LibSReal_StudentTDist(Target, res, xqp, nu);
}


void Lib_SReal_TriangularDist(long Target, float* res, float* xqp, float* lower, float* mode_, float* upper)
{
    LibSReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
}


void Lib_SReal_WeibullDist(long Target, float* res, float* xqp, float* shape, float* scale)
{
    LibSReal_WeibullDist(Target, res, xqp, shape, scale);
}


void Lib_SReal_UniformDist(long Target, float* res, float* xqp, float* lower, float* upper)
{
    LibSReal_UniformDist(Target, res, xqp, lower, upper);
}




//*********************** New , double precision **********************************




void Lib_SReal_Logaddexp(float* res, const float* a, const float* b)
{
    LibSReal_Logaddexp(res, a, b);
}



void Lib_SReal_HyperexponentialDist(long Target, float* res, float* xqp, mpNumMatrixPtr l1, mpNumMatrixPtr l2)
{
    LibSReal_HyperexponentialDist(Target, res, xqp, (SStatePtr)l1, (SStatePtr)l2);
}


void Lib_SReal_KolmogorovSmirnovDist(long Target, float* res, float* xqp, float* n)
{
    LibSReal_KolmogorovSmirnovDist(Target, res, xqp, n);
}


void Lib_SReal_HoltsmarkDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_HoltsmarkDist(Target, res, xqp, location, scale);
}


void Lib_SReal_LandauDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_LandauDist(Target, res, xqp, location, scale);
}


void Lib_SReal_MapAiryDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_MapAiryDist(Target, res, xqp, location, scale);
}


void Lib_SReal_Saspoint5Dist(long Target, float* res, float* xqp, float* location, float* scale)
{
    LibSReal_Saspoint5Dist(Target, res, xqp, location, scale);
}














//*********************** Numerical Calculus, float precision  **********************************




void Lib_SReal_BracketRoot(float* res1, float* res2, int* iter, SRealFuncPtr f1, float* guess, float* factor, bool is_rising, int get_digits, unsigned int maxit)
{
    LibSReal_BracketRoot(res1, res2, iter, f1, guess, factor, is_rising, get_digits, maxit);
}



void Lib_SReal_NewtonRaphson(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit)
{
    LibSReal_NewtonRaphson(res, iter, f1, f2, guess, xmin, xmax, get_digits, maxit);
}



void Lib_SReal_Halley(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, SRealFuncPtr f3, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit)
{
    LibSReal_Halley(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
}



void Lib_SReal_Schroder(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, SRealFuncPtr f3, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit)
{
    LibSReal_Schroder(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
}



void Lib_SReal_Brent_Minimum(float* res, float* resFx, int* iter, SRealFuncPtr f1, float* bracket_min, float* bracket_max, int bits, unsigned int maxit)
{
    LibSReal_Brent_Minimum(res, resFx, iter, f1, bracket_min, bracket_max, bits, maxit);
}




void Lib_SReal_Trapezoidal(float* res1, float* res2, float* res3, SRealFuncPtr f1, float* a, float* b)
{
    LibSReal_Trapezoidal(res1, res2, res3, f1, a, b);
}



// 7, 15, 20, 25 and 30

void Lib_SReal_GaussLegendre(float* res1, float* res3, SRealFuncPtr f1, float* a, float* b)
{
    LibSReal_GaussLegendre(res1, res3, f1, a, b);
}




//15, 31, 41, 51 and 61

void Lib_SReal_GaussKronrod(float* res1, float* res2, float* res3, SRealFuncPtr f1, float* a, float* b)
{
    LibSReal_GaussKronrod(res1, res2, res3, f1, a, b);
}



void Lib_SReal_TanhSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1, float* a, float* b)
{
    LibSReal_TanhSinh(res1, res2, res3, levels_, f1, a, b);
}



void Lib_SReal_SinhSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1)
{
    LibSReal_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_SReal_ExpSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1)
{
    LibSReal_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_SReal_Ooura_Cos(float* res1, float* res2, SRealFuncPtr f1)
{
    LibSReal_Ooura_Cos(res1, res2, f1);
}



void Lib_SReal_Ooura_Sin(float* res1, float* res2, SRealFuncPtr f1)
{
    LibSReal_Ooura_Sin(res1, res2, f1);
}






//*********************** Boost Odeint **********************************


void Lib_SReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt)
{
	LibSReal_Const_RungeKutta4((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_SReal_Const_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt)
{
	LibSReal_Const_RungeKuttaCashKarp54((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_SReal_Const_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt)
{
	LibSReal_Const_RungeKuttaDopri5((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_SReal_Const_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt)
{
	LibSReal_Const_RungeKuttaFehlberg78((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt);
}


void Lib_SReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt)
{
	LibSReal_Const_AdamsBashforthMoulton((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt);
}





void Lib_SReal_Adaptive_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt, float* eps_abs, float* eps_rel)
{
	LibSReal_Adaptive_RungeKuttaDopri5((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt,     *eps_abs , *eps_rel);
}


void Lib_SReal_Adaptive_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt, float* eps_abs, float* eps_rel)
{
	LibSReal_Adaptive_RungeKuttaCashKarp54((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt, *eps_abs , *eps_rel);
}


void Lib_SReal_Adaptive_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt, float* eps_abs, float* eps_rel)
{
	LibSReal_Adaptive_RungeKuttaFehlberg78((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt, *eps_abs , *eps_rel);
}


void Lib_SReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt, float* eps_abs, float* eps_rel)
{
	LibSReal_Adaptive_BulirschStoer((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt, *eps_abs , *eps_rel);
}



void Lib_SReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt, float* eps_abs, float* eps_rel)
{
	LibSReal_DenseOutput_Dopri5((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt, *eps_abs , *eps_rel);
}


void Lib_SReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX, float* start_time, float* end_time, float* dt, float* eps_abs, float* eps_rel)
{
	LibSReal_DenseOutput_BulirschStoer((SAnyFuncPtr3)f1, (SAnyFuncPtr2)f2, (SStatePtr)matX, *start_time, *end_time, *dt, *eps_abs , *eps_rel);
}














































