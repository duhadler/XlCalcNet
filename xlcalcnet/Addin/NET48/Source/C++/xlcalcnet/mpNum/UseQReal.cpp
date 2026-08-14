#include "mpNumC_Main.h"
#include "BoostQReal.h"


#include "stdint.h"
#include <complex>
#include <limits>
#include <quadmath.h>


using namespace std;


//
//__float128 cosm1q(__float128 x)
//{
//    if (fabsq(x) > (0.5Q))
//    {
//        return cosq(x) - (1.0Q);
//    }
//    else
//    {
//        __float128 res = sinq(x * (0.5Q));
//        return  -(2.0Q) * res * res;
//    }
//}
//
//

//
//
//__complex128 cplx_expm1q(__complex128 z)
//{
//    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
//	__float128 x = crealq(z);
//	__float128 y = cimagq(z);
//	__float128 resx = expm1q(x) * cosq(y) + cosm1q(y);
//	__float128 resy = expq(x) * sinq(y);
//    __complex128 res;
//    __real__ res = resx;
//    __imag__ res = resy;
//	return res;
//}
//
//
//
//__complex128  cplx_log1pq(__complex128 z)
//{
//    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
//    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
//    /* resy =  atan2(y, 1 + x); */
//	__float128 x = crealq(z);
//	__float128 y = cimagq(z);
//	__float128 resx = 0.0Q ;
//	if ( (fabsq(x) > 0.75Q) || (fabsq(y) > 0.75Q) || (x < -0.5Q) )
//    {
//        resx = logq(hypotq(1.0Q + x, y)) ;
//    }
//    else
//    {
//        resx = 0.5Q * log1pq(2.0Q * x + x*x + y*y);
//    }
//	__float128 resy = atan2q(y, 1.0Q + x);
//
//    __complex128 res;
//    __real__ res = resx;
//    __imag__ res = resy;
//	return res;
//}
//
//


int quad_signum(__float128 x)
{
	return ((x > 0) - (x < 0));
}

int quad_cmp(__float128 x, __float128 y)
{
	return quad_signum(x - y);
}


void Lib_QuadPtr_Swap(__float128* x, __float128* y)
{
	__float128 temp;
	temp = *x;
	*x = *y;
	*y = temp;
}



void quad_cplx_abs_from_real_and_imag(__float128* res, __float128* src_real, __float128* src_imag)
{
    __complex128 z;
    __real__ z = *src_real;
    __imag__ z = *src_imag;
    *res = cabsq(z);
}


void quad_cplx_sqrt_from_real_and_imag(__float128* res_real, __float128* res_imag, __float128* src_real, __float128* src_imag)
{
    __complex128 z, res;
    __real__ z = *src_real;
    __imag__ z = *src_imag;
    res = csqrtq(z);
	*res_real = crealq(res);
	*res_imag = cimagq(res);
}






/** ********************** Real Basic Functions, quadruple precision ******************************** **/


QRealPtr Lib_QReal_Init_Func()
{
	QRealPtr x = NULL;
	x = (__float128*)malloc(sizeof(__float128));
	(*(__float128*)x) = 0.0;
	return x;
}

void Lib_QReal_Clear(QRealPtr x)
{
	free(x);
}



/* Input and output  */


void Lib_QReal_Set(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (*(__float128*)x);
}

//void Lib_QReal_Set_Fmpq(QRealPtr res, const FmpqPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	fmpq_get_mpfr (temp, (fmpq*)x, MPFR_RNDN);
//	*(__float128*)res = mpfr_get_float128(temp, MPFR_RNDN);
//    mpfr_clear(temp);
//}
//
//void Lib_QReal_Set_Arb(QRealPtr res, const ArbPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	arf_get_mpfr(temp, arb_midref((arb_ptr)x), MPFR_RNDN);
//    *(__float128*)res = mpfr_get_float128(temp, MPFR_RNDN);
//	mpfr_clear(temp);
//}
//
//void Lib_QReal_Set_Arf(QRealPtr res, const ArfPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	arf_get_mpfr(temp, (arf_ptr)x, MPFR_RNDN);
//    *(__float128*)res = mpfr_get_float128(temp, MPFR_RNDN);
//	mpfr_clear(temp);
//}
//
//void Lib_QReal_Set_Mpfi(QRealPtr res, const MpfiPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//    mpfi_mid (temp, (mpfi_ptr)x);
//    *(__float128*)res = mpfr_get_float128(temp, MPFR_RNDN);
//	mpfr_clear(temp);
//}
//
//void Lib_QReal_Set_Mpfr(QRealPtr res, const MpfrPtr x)
//{
//    *(__float128*)res = mpfr_get_float128((mpfr_ptr)x, MPFR_RNDN);
//}
//
//
//void Lib_QReal_Set_Mpd(QRealPtr res, const MpdPtr x)
//{
//	char * src = mpd_to_sci((mpd_t *)x, 1);
//    (*(__float128*)res) = strtoflt128 (src, NULL);
//	free(src);
//}

//void Lib_QReal_Set_CReal(QRealPtr res, const CRealPtr x)
//{
//    char buffer[128];
//    Lib_CReal_Get_Str(buffer, x);
//    (*(__float128*)res) = strtoflt128 (buffer, NULL);
//}

void Lib_QReal_Set_QReal(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (*(__float128*)x);
}

void Lib_QReal_Set_LD(QRealPtr res, long double* x)
{
	(*(__float128*)res) = *x;
}

void Lib_QReal_Set_D(QRealPtr res, const double x)
{
	(*(__float128*)res) = x;
}

void Lib_QReal_Set_S(QRealPtr res, float* x)
{
	(*(__float128*)res) = *x;
}

void Lib_QReal_Set_Si(QRealPtr res, const int32_t x)
{
	(*(__float128*)res) = x;
}

void Lib_QReal_Set_Ui(QRealPtr res, const uint32_t x)
{
	(*(__float128*)res) = x;
}

void Lib_QReal_Set_Si64(QRealPtr res, const int64_t x)
{
	(*(__float128*)res) = x;
}

void Lib_QReal_Set_Ui64(QRealPtr res, const uint64_t x)
{
	(*(__float128*)res) = x;
}

// template1 = "%+-#*.34Qe"
void Lib_QReal_Get_Str(char * dest, const char *template1, const QRealPtr x)
{
    //quadmath_snprintf (dest, 128, "%Qg", (*(__float128*)x));
    quadmath_snprintf (dest, 128, "%-#*.34Qg", 46, (*(__float128*)x));
    //quadmath_snprintf (dest, 128, "%-#*.34Qe", 46, (*(__float128*)x));
    //quadmath_snprintf (dest, 128, "%+-#*.34Qe", 46, (*(__float128*)x));
    //quadmath_snprintf (dest, 128, template1, 46, (*(__float128*)x));
}


void Lib_QReal_Set_Str(QRealPtr res, const char * str)
{
    (*(__float128*)res) = strtoflt128 (str, NULL);
}







/* Operator overloading vs raw arithmetic and comparisons  */

void Lib_QReal_Neg(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = -(*(__float128*)x);
}

void Lib_QReal_Add(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = (*(__float128*)x) + (*(__float128*)y);
}

void Lib_QReal_Sub(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = (*(__float128*)x) - (*(__float128*)y);
}

void Lib_QReal_Mul(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = (*(__float128*)x) * (*(__float128*)y);
}

void Lib_QReal_Div(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = (*(__float128*)x) / (*(__float128*)y);
}


void Lib_QReal_Add_D(QRealPtr res, const QRealPtr x, const double y)
{
	(*(__float128*)res) = (*(__float128*)x) + y;
}

void Lib_QReal_Sub_D(QRealPtr res, const QRealPtr x, const double y)
{
	(*(__float128*)res) = (*(__float128*)x) - y;
}

void Lib_QReal_D_Sub(QRealPtr res, const QRealPtr x, const double y)
{
	(*(__float128*)res) =  y - (*(__float128*)x);
}

void Lib_QReal_Mul_D(QRealPtr res, const QRealPtr x, const double y)
{
	(*(__float128*)res) = (*(__float128*)x) * y;
}

void Lib_QReal_Div_D(QRealPtr res, const QRealPtr x, const double y)
{
	(*(__float128*)res) = (*(__float128*)x) / y;
}

void Lib_QReal_D_Div(QRealPtr res, const QRealPtr x, const double y)
{
	(*(__float128*)res) = y / (*(__float128*)x);
}



void Lib_QReal_Add_Si(QRealPtr res, const QRealPtr x, const int32_t y)
{
	(*(__float128*)res) = (*(__float128*)x) + y;
}

void Lib_QReal_Sub_Si(QRealPtr res, const QRealPtr x, const int32_t y)
{
	(*(__float128*)res) = (*(__float128*)x) - y;
}

void Lib_QReal_Si_Sub(QRealPtr res, const QRealPtr x, const int32_t y)
{
	(*(__float128*)res) =  y - (*(__float128*)x);
}

void Lib_QReal_Mul_Si(QRealPtr res, const QRealPtr x, const int32_t y)
{
	(*(__float128*)res) = (*(__float128*)x) * y;
}

void Lib_QReal_Div_Si(QRealPtr res, const QRealPtr x, const int32_t y)
{
	(*(__float128*)res) = (*(__float128*)x) / y;
}

void Lib_QReal_Si_Div(QRealPtr res, const QRealPtr x, const int32_t y)
{
	(*(__float128*)res) = y / (*(__float128*)x);
}



int32_t Lib_QReal_LT(const QRealPtr x, const QRealPtr y)
{
	return (*(__float128*)x) < (*(__float128*)y);
}

int32_t Lib_QReal_GE(const QRealPtr x, const QRealPtr y)
{
	return (*(__float128*)x) >= (*(__float128*)y);
}

int32_t Lib_QReal_GT(const QRealPtr x, const QRealPtr y)
{
	return (*(__float128*)x) > (*(__float128*)y);
}

int32_t Lib_QReal_LE(const QRealPtr x, const QRealPtr y)
{
	return (*(__float128*)x) <= (*(__float128*)y);
}

int32_t Lib_QReal_EQ(const QRealPtr x, const QRealPtr y)
{
	return (*(__float128*)x) == (*(__float128*)y);
}

int32_t Lib_QReal_NE(const QRealPtr x, const QRealPtr y)
{
	return (*(__float128*)x) != (*(__float128*)y);
}







/* General functions for real numbers  */

void Lib_QReal_Fma(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z)
{
	(*(__float128*)res) = fmaq( (*(__float128*)x) , (*(__float128*)y) , (*(__float128*)z) );
}

void Lib_QReal_Fmax(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = fmaxq( (*(__float128*)x) , (*(__float128*)y) );
}

void Lib_QReal_Fmin(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = fminq( (*(__float128*)x) , (*(__float128*)y) );
}



/* Machine constants */

void Lib_QReal_Zero(QRealPtr res)
{
    (*(__float128*)res) = 0.0Q;
}

void Lib_QReal_NegZero(QRealPtr res)
{
    (*(__float128*)res) = -0.0Q;
}

void Lib_QReal_One(QRealPtr res)
{
    (*(__float128*)res) = 1.0Q;
}

void Lib_QReal_Inf(QRealPtr res)
{
    LibQReal_Inf(res);
}

void Lib_QReal_NegInf(QRealPtr res)
{
    LibQReal_NegInf(res);
}

void Lib_QReal_Nan(QRealPtr res)
{
    LibQReal_Nan(res);
}




/* Properties of numbers  */

int Lib_QReal_Signbit(const QRealPtr x)
{
	return signbitq(*(__float128*)x);
}

int Lib_QReal_Finite(const QRealPtr x)
{
	return finiteq(*(__float128*)x);
}

int Lib_QReal_Isinf(const QRealPtr x)
{
	return isinfq(*(__float128*)x);
}

int Lib_QReal_Isposinf(const QRealPtr x)
{
	return (isinfq(*(__float128*)x) & (*(__float128*)x > 0.0Q));
}

int Lib_QReal_Isneginf(const QRealPtr x)
{
	return (isinfq(*(__float128*)x) & (*(__float128*)x < 0.0Q));
}

int Lib_QReal_Isnan(const QRealPtr x)
{
	return isnanq(*(__float128*)x);
}




int Lib_QReal_Iszero(const QRealPtr x)
{
	return (fabsq(*(__float128*)x) == 0.0Q);
}

int Lib_QReal_Isposzero(const QRealPtr x)
{
	return ((signbitq(*(__float128*)x) == 0) && (fabsq(*(__float128*)x) == 0.0Q));
}

int Lib_QReal_Isnegzero(const QRealPtr x)
{
	return ((signbitq(*(__float128*)x) != 0) & (fabsq(*(__float128*)x) == 0.0Q));
}

int Lib_QReal_Isone(const QRealPtr x)
{
	return ((*(__float128*)x) == 1.0Q);
}

int Lib_QReal_Isinteger(const QRealPtr x)
{
	return (ceilq(*(__float128*)x) == floorq(*(__float128*)x));
}

int Lib_QReal_Isnumber(const QRealPtr x)
{
	return (!(isnanq(*(__float128*)x) || isinfq(*(__float128*)x)));
}

int Lib_QReal_Isregular(const QRealPtr x)
{
	return (!(isnanq(*(__float128*)x) || isinfq(*(__float128*)x) || (fabsq(*(__float128*)x) == 0.0Q)));
}

int Lib_QReal_Isnormal(const QRealPtr x)
{
	return LibQReal_Isnormal(x);
}

int Lib_QReal_Issubnormal(const QRealPtr x)
{
	return LibQReal_Issubnormal(x);
}

int Lib_QReal_Isunordered(const QRealPtr x, const QRealPtr y)
{
	return (isnanq(*(__float128*)x) || isnanq(*(__float128*)y) );
}




int Lib_QReal_FitsInt32(const QRealPtr x)
{
	return  ((*(__float128*)x <= std::numeric_limits<int32_t>::max()) &
             (*(__float128*)x >= std::numeric_limits<int32_t>::min()));
}

int Lib_QReal_FitsInt64(const QRealPtr x)
{
	return  ((*(__float128*)x <= std::numeric_limits<int64_t>::max()) &
             (*(__float128*)x >= std::numeric_limits<int64_t>::min()));
}

int Lib_QReal_FitsUInt32(const QRealPtr x)
{
	return  ((*(__float128*)x <= std::numeric_limits<uint32_t>::max()) &
             (*(__float128*)x >= std::numeric_limits<uint32_t>::min()));
}

int Lib_QReal_FitsUInt64(const QRealPtr x)
{
	return  ((*(__float128*)x <= std::numeric_limits<uint64_t>::max()) &
             (*(__float128*)x >= std::numeric_limits<uint64_t>::min()));
}








/* Integer Related Functions  */

void Lib_QReal_Nearbyint(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = nearbyintq(*(__float128*)x);
}

void Lib_QReal_Rint(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = rintq(*(__float128*)x);
}

long int Lib_QReal_Lrint(const QRealPtr x)
{
	return lrintq(*(__float128*)x);
}

long long int Lib_QReal_Llrint(const QRealPtr x)
{
	return llrintq(*(__float128*)x);
}

void Lib_QReal_Ceil(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = ceilq(*(__float128*)x);
}

void Lib_QReal_Floor(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = floorq(*(__float128*)x);
}

long int Lib_QReal_Lround(const QRealPtr x)
{
	return lroundq(*(__float128*)x);
}

void Lib_QReal_Round(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = roundq(*(__float128*)x);
}

long long int Lib_QReal_Llround(const QRealPtr x)
{
	return llroundq(*(__float128*)x);
}

void Lib_QReal_Trunc(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = truncq(*(__float128*)x);
}

int32_t Lib_QReal_ToInt32(const QRealPtr x)
{
    if (*(__float128*)x >= std::numeric_limits<int32_t>::max())
        return std::numeric_limits<int32_t>::max();
    else if (*(__float128*)x <= std::numeric_limits<int32_t>::min())
        return std::numeric_limits<int32_t>::min();
    else
        return (int32_t) (*(__float128*)x);
}

int64_t Lib_QReal_ToInt64(const QRealPtr x)
{
    if (*(__float128*)x >= std::numeric_limits<int64_t>::max())
        return std::numeric_limits<int64_t>::max();
    else if (*(__float128*)x <= std::numeric_limits<int64_t>::min())
        return std::numeric_limits<int64_t>::min();
    else
        return (int64_t) (*(__float128*)x);
}

uint32_t Lib_QReal_ToUInt32(const QRealPtr x)
{
    if (*(__float128*)x >= std::numeric_limits<uint32_t>::max())
        return std::numeric_limits<uint32_t>::max();
    else if (*(__float128*)x <= std::numeric_limits<uint32_t>::min())
        return std::numeric_limits<uint32_t>::min();
    else
        return (uint32_t) (*(__float128*)x);
}

uint64_t Lib_QReal_ToUInt64(const QRealPtr x)
{
    if (*(__float128*)x >= std::numeric_limits<uint64_t>::max())
        return std::numeric_limits<uint64_t>::max();
    else if (*(__float128*)x <= std::numeric_limits<uint64_t>::min())
        return std::numeric_limits<uint64_t>::min();
    else
        return (uint64_t) (*(__float128*)x);
}






/* Floating point functions for real numbers */


void Lib_QReal_Copysign(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = copysignq( (*(__float128*)x) , (*(__float128*)y) );
}

void Lib_QReal_Frexp(QRealPtr res, const QRealPtr x, int* e)
{
	(*(__float128*)res) = frexpq(*(__float128*)x, e);
}

void Lib_QReal_Logb(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = logbq(*(__float128*)x);
}

int Lib_QReal_Ilogb(const QRealPtr x)
{
	return ilogbq(*(__float128*)x);
}

void Lib_QReal_Ldexp(QRealPtr res, const QRealPtr x, const int e)
{
	(*(__float128*)res) = ldexpq(*(__float128*)x, e);
}

void Lib_QReal_Scalbn(QRealPtr res, const QRealPtr x, const int e)
{
	(*(__float128*)res) = scalbnq(*(__float128*)x, e);
}

void Lib_QReal_Scalbln(QRealPtr res, const QRealPtr x, const long int e)
{
	(*(__float128*)res) = scalblnq(*(__float128*)x, e);
}

void Lib_QReal_Fdim(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = fdimq( (*(__float128*)x) , (*(__float128*)y) );
}










/* Fraction and Remainder Related Functions  */

void Lib_QReal_Modf(QRealPtr frac, const QRealPtr x, QRealPtr iptr)
{
	(*(__float128*)frac) = modfq( (*(__float128*)x) , (__float128*)iptr );
}

void Lib_QReal_Fmod(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = fmodq( (*(__float128*)x) , (*(__float128*)y) );
}

void Lib_QReal_Remainder(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = remainderq( (*(__float128*)x) , (*(__float128*)y) );
}

void Lib_QReal_Remquo(QRealPtr res, const QRealPtr x, const QRealPtr y, int* e)
{
	(*(__float128*)res) = remquoq( (*(__float128*)x) , (*(__float128*)y), e );
}



/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */


void Lib_QReal_Epsilon(QRealPtr res)
{
	(*(__float128*)res) = FLT128_EPSILON;
}


void Lib_QReal_Ulp(QRealPtr res, const QRealPtr x)
{
	LibQReal_Ulp(res, x);
}


void Lib_QReal_Max(QRealPtr res)
{
	(*(__float128*)res) = FLT128_MAX;
}

void Lib_QReal_Lowest(QRealPtr res)
{
    LibQReal_Lowest(res);
}

void Lib_QReal_Min(QRealPtr res)
{
	(*(__float128*)res) = FLT128_MIN;
}

void Lib_QReal_Nextabove(QRealPtr res, const QRealPtr x)
{
    LibQReal_Nextabove(res, x);
}

void Lib_QReal_Nextbelow(QRealPtr res, const QRealPtr x)
{
    LibQReal_Nextbelow(res, x);
}

void Lib_QReal_Nexttoward(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
    LibQReal_Nexttowards(res, x, y);
}



/* Complex components  */

void Lib_QReal_Fabs(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = fabsq(*(__float128*)x);
}

void Lib_QReal_Sign(QRealPtr res, const QRealPtr x)
{
    int temp = ((*(__float128*)x > 0) - (*(__float128*)x < 0));
	(*(__float128*)res) = temp;
}










/* Mathematical Constants  */

void Lib_QReal_ConstDegree(QRealPtr res)
{
	(*(__float128*)res) = 0.017453292519943295769236907684886127138Q;
}

void Lib_QReal_ConstPhi(QRealPtr res)
{
	(*(__float128*)res) = 1.6180339887498948482045868343656381176Q;
}

void Lib_QReal_ConstLog2(QRealPtr res)
{
//	(*(__float128*)res) = 0.69314718055994530941723212145817656831Q;
	(*(__float128*)res) = M_LN2q;
}

void Lib_QReal_ConstLog10(QRealPtr res)
{
//	(*(__float128*)res) = 2.3025850929940456840179914546843642071Q;
	(*(__float128*)res) = M_LN10q;
}


void Lib_QReal_ConstPi(QRealPtr res)
{
	(*(__float128*)res) = M_PIq;
}

void Lib_QReal_ConstE(QRealPtr res)
{
	(*(__float128*)res) = M_Eq;
}


void Lib_QReal_ConstEulerGamma(QRealPtr res)
{
	(*(__float128*)res) = 0.57721566490153286060651209008240243079Q;
}

void Lib_QReal_ConstApery(QRealPtr res)
{
	(*(__float128*)res) = 1.2020569031595942853997381615114499914Q;
}

void Lib_QReal_ConstCatalan(QRealPtr res)
{
	(*(__float128*)res) = 0.91596559417721901505460351493238411094Q;
}

void Lib_QReal_ConstGlaisher(QRealPtr res)
{
	(*(__float128*)res) = 1.2824271291006226368753425688697917282Q;
}

void Lib_QReal_ConstKhinchin(QRealPtr res)
{
	(*(__float128*)res) = 2.6854520010653064453097148354817956937Q;
}





/* Roots and related functions  */

void Lib_QReal_Sqrt(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = sqrtq(*(__float128*)x);
}

void Lib_QReal_Sqrt1pm1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = expm1q(log1pq((*(__float128*)x) * (0.5Q)));
}

void Lib_QReal_Rsqrt(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0Q) / sqrtq(*(__float128*)x);
}

void Lib_QReal_Cbrt(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = cbrtq(*(__float128*)x);
}

void Lib_QReal_Root_Si(QRealPtr res, const QRealPtr x, const int32_t k)
{
	(*(__float128*)res) = powq((*(__float128*)x), (1.0Q)/k);
}



/* Exponential and related functions  */

void Lib_QReal_Exp(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = expq(*(__float128*)x);
}

void Lib_QReal_Exp2(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = exp2q(*(__float128*)x);
}

void Lib_QReal_Exp10(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = expq((*(__float128*)x) * M_LN10q);
}

void Lib_QReal_Expm1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = expm1q(*(__float128*)x);
}

void Lib_QReal_Exp2m1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = expm1q( (*(__float128*)x) * M_LN2q );
}

void Lib_QReal_Exp10m1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = expm1q( (*(__float128*)x) * M_LN10q );
}



/* Logarithms and related functions  */

void Lib_QReal_Log(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = logq(*(__float128*)x);
}

void Lib_QReal_Log2(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = log2q(*(__float128*)x);
}

void Lib_QReal_Log10(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = log10q(*(__float128*)x);
}

void Lib_QReal_Log1p(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = log1pq(*(__float128*)x);
}

void Lib_QReal_Log2p1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = log1pq(*(__float128*)x) / M_LN2q;
}

void Lib_QReal_Log10p1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = log1pq(*(__float128*)x) / M_LN10q;
}




/* Power functions and roots  */


void Lib_QReal_Square(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (*(__float128*)x) * (*(__float128*)x);
}

void Lib_QReal_Cube(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (*(__float128*)x) * (*(__float128*)x) * (*(__float128*)x);
}

void Lib_QReal_Hypot(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = hypotq( (*(__float128*)x) , (*(__float128*)y) );
}



void Lib_QReal_Pow(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = powq( (*(__float128*)x) , (*(__float128*)y) );
}


void Lib_QReal_Powm1(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = expm1q(logq(*(__float128*)x) * (*(__float128*)y));
}


void Lib_QReal_Pow1p(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = expq(log1pq(*(__float128*)x) * (*(__float128*)y));
}


void Lib_QReal_Pow1pm1(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = expm1q(log1pq(*(__float128*)x) * (*(__float128*)y));
}


void Lib_QReal_Pow_Si(QRealPtr res, const QRealPtr x, const int32_t n)
{
	(*(__float128*)res) = powq((*(__float128*)x) , n);
}


void Lib_QReal_Compound_Si(QRealPtr res, const QRealPtr x, const int32_t n)
{
	(*(__float128*)res) = powq((1.0Q) + (*(__float128*)x) , n);
}








/* Trigonometric functions  */

void Lib_QReal_Sin(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = sinq(*(__float128*)x);
}

void Lib_QReal_Cos(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = cosq(*(__float128*)x);
}


__float128 cosm1q(__float128 x)
{
    if (fabsq(x) > (0.5Q))
    {
        return cosq(x) - (1.0Q);
    }
    else
    {
        __float128 res = sinq(x * (0.5Q));
        return  -(2.0Q) * res * res;
    }
}

void Lib_QReal_Cosm1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = cosm1q(*(__float128*)x);
}


void Lib_QReal_Tan(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = tanq(*(__float128*)x);
}


void Lib_QReal_Csc(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0Q) / sinq(*(__float128*)x);
}

void Lib_QReal_Sec(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0Q) / cosq(*(__float128*)x);
}

void Lib_QReal_Cot(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0Q) / tanq(*(__float128*)x);
}



void Lib_QReal_SinPi(QRealPtr res, const QRealPtr x)
{
    LibQReal_SinPi(res, x);
}

void Lib_QReal_CosPi(QRealPtr res, const QRealPtr x)
{
    LibQReal_CosPi(res, x);
}

void Lib_QReal_TanPi(QRealPtr res, const QRealPtr x)
{
    LibQReal_TanPi(res, x);
}



void Lib_QReal_CscPi(QRealPtr res, const QRealPtr x)
{
    LibQReal_CscPi(res, x);
}

void Lib_QReal_SecPi(QRealPtr res, const QRealPtr x)
{
    LibQReal_SecPi(res, x);
}

void Lib_QReal_CotPi(QRealPtr res, const QRealPtr x)
{
    LibQReal_CotPi(res, x);
}





/* Hyperbolic functions  */

void Lib_QReal_Sinh(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = sinhq(*(__float128*)x);
}

void Lib_QReal_Cosh(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = coshq(*(__float128*)x);
}

void Lib_QReal_Tanh(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = tanhq(*(__float128*)x);
}


void Lib_QReal_Csch(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0Q) / sinhq(*(__float128*)x);
}

void Lib_QReal_Sech(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0Q) / coshq(*(__float128*)x);
}

void Lib_QReal_Coth(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0Q) / tanhq(*(__float128*)x);
}





/* Inverse trigonometric functions  */

void Lib_QReal_Asin(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = asinq(*(__float128*)x);
}

void Lib_QReal_Acos(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = acosq(*(__float128*)x);
}

void Lib_QReal_Atan(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = atanq(*(__float128*)x);
}

void Lib_QReal_Atan2(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = atan2q( (*(__float128*)x) , (*(__float128*)y) );
}



void Lib_QReal_Acsc(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = asinq((1.0Q) / *(__float128*)x);
}

void Lib_QReal_Asec(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = acosq((1.0Q) / *(__float128*)x);
}

void Lib_QReal_Acot(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = atanq((1.0Q) / *(__float128*)x);
}




/* Inverse hyperbolic functions  */

void Lib_QReal_Asinh(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = asinhq(*(__float128*)x);
}

void Lib_QReal_Acosh(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = acoshq(*(__float128*)x);
}

void Lib_QReal_Atanh(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = atanhq(*(__float128*)x);
}



void Lib_QReal_Acsch(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = asinhq((1.0Q) / *(__float128*)x);
}

void Lib_QReal_Asech(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = acoshq((1.0Q) / *(__float128*)x);
}

void Lib_QReal_Acoth(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = atanhq((1.0Q) / *(__float128*)x);
}


/* Special functions  */

void Lib_QReal_Erf(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = erfq(*(__float128*)x);
}

void Lib_QReal_Erfc(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = erfcq(*(__float128*)x);
}

void Lib_QReal_Tgamma(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = tgammaq(*(__float128*)x);
}

void Lib_QReal_Lgamma(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = lgammaq(*(__float128*)x);
}


void Lib_QReal_BesselJ0(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = j0q(*(__float128*)x);
}

void Lib_QReal_BesselJ1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = j1q(*(__float128*)x);
}

void Lib_QReal_BesselJn(QRealPtr res, const int n, const QRealPtr x)
{
	(*(__float128*)res) = jnq(n, *(__float128*)x);
}


void Lib_QReal_BesselY0(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = y0q(*(__float128*)x);
}

void Lib_QReal_BesselY1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = y1q(*(__float128*)x);
}

void Lib_QReal_BesselYn(QRealPtr res, const int n, const QRealPtr x)
{
	(*(__float128*)res) = ynq(n, *(__float128*)x);
}







/** ********************** Complex Basic Functions, quadruple precision ******************************** **/



QCplxPtr Lib_QCplx_Init_Func()
{
	QCplxPtr x = NULL;
	x = (__complex128*)malloc(sizeof(__complex128));
	return x;
}

void Lib_QCplx_Clear(QCplxPtr x)
{
	free(x);
}


/* Input and output  */

void Lib_QCplx_Set(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (*(__complex128*)x);
}


/* Operator overloading vs raw arithmetic and comparisons  */

void Lib_QCplx_Neg(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = -(*(__complex128*)x);
}

void Lib_QCplx_Add(QCplxPtr res, const QCplxPtr x, const QCplxPtr y)
{
	(*(__complex128*)res) = (*(__complex128*)x) + (*(__complex128*)y);
}

void Lib_QCplx_Sub(QCplxPtr res, const QCplxPtr x, const QCplxPtr y)
{
	(*(__complex128*)res) = (*(__complex128*)x) - (*(__complex128*)y);
}

void Lib_QCplx_Mul(QCplxPtr res, const QCplxPtr x, const QCplxPtr y)
{
	(*(__complex128*)res) = (*(__complex128*)x) * (*(__complex128*)y);
}

void Lib_QCplx_Div(QCplxPtr res, const QCplxPtr x, const QCplxPtr y)
{
	(*(__complex128*)res) = (*(__complex128*)x) / (*(__complex128*)y);
}


void Lib_QCplx_Add_QReal(QCplxPtr res, const QCplxPtr x, const QRealPtr y)
{
	(*(__complex128*)res) = (*(__complex128*)x) + (*(__float128*)y);
}

void Lib_QCplx_Sub_QReal(QCplxPtr res, const QCplxPtr x, const QRealPtr y)
{
	(*(__complex128*)res) = (*(__complex128*)x) - (*(__float128*)y);
}

void Lib_QCplx_QReal_Sub(QCplxPtr res, const QCplxPtr y, const QRealPtr x)
{
	(*(__complex128*)res) =  (*(__float128*)x) - (*(__complex128*)y);
}

void Lib_QCplx_Mul_QReal(QCplxPtr res, const QCplxPtr x, const QRealPtr y)
{
	(*(__complex128*)res) = (*(__complex128*)x) * (*(__float128*)y);
}

void Lib_QCplx_Div_QReal(QCplxPtr res, const QCplxPtr x, const QRealPtr y)
{
	(*(__complex128*)res) = (*(__complex128*)x) / (*(__float128*)y);
}

void Lib_QCplx_QReal_Div(QCplxPtr res, const QCplxPtr y, const QRealPtr x)
{
	(*(__complex128*)res) = (*(__float128*)x) /(*(__complex128*)y);
}


void Lib_QCplx_Add_D(QCplxPtr res, const QCplxPtr x, const double y)
{
	(*(__complex128*)res) = (*(__complex128*)x) + y;
}

void Lib_QCplx_Sub_D(QCplxPtr res, const QCplxPtr x, const double y)
{
	(*(__complex128*)res) = (*(__complex128*)x) - y;
}

void Lib_QCplx_D_Sub(QCplxPtr res, const QCplxPtr y, const double x)
{
	(*(__complex128*)res) = x - (*(__complex128*)y);
}

void Lib_QCplx_Mul_D(QCplxPtr res, const QCplxPtr x, const double y)
{
	(*(__complex128*)res) = (*(__complex128*)x) * y;
}

void Lib_QCplx_Div_D(QCplxPtr res, const QCplxPtr x, const double y)
{
	(*(__complex128*)res) = (*(__complex128*)x) / y;
}

void Lib_QCplx_D_Div(QCplxPtr res, const QCplxPtr y, const double x)
{
	(*(__complex128*)res) = x / (*(__complex128*)y);
}








void Lib_QCplx_Add_Si(QCplxPtr res, const QCplxPtr x, const int32_t y)
{
	(*(__complex128*)res) = (*(__complex128*)x) + y;
}


void Lib_QCplx_Sub_Si(QCplxPtr res, const QCplxPtr x, const int32_t y)
{
	(*(__complex128*)res) = (*(__complex128*)x) - y;
}


void Lib_QCplx_Si_Sub(QCplxPtr res, const QCplxPtr y, const int32_t x)
{
	(*(__complex128*)res) = x - (*(__complex128*)y);
}


void Lib_QCplx_Mul_Si(QCplxPtr res, const QCplxPtr x, const int32_t y)
{
	(*(__complex128*)res) = (*(__complex128*)x) * y;
}


void Lib_QCplx_Div_Si(QCplxPtr res, const QCplxPtr x, const int32_t y)
{
	(*(__complex128*)res) = (*(__complex128*)x) / y;
}


void Lib_QCplx_Si_Div(QCplxPtr res, const QCplxPtr y, const int32_t x)
{
	(*(__complex128*)res) = x / (*(__complex128*)y);
}




/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */

void Lib_QCplx_Set_Real(QCplxPtr res, const QRealPtr re)
{
    __complex128 z;
    __real__ z = (*(__float128*)re);
    __imag__ z = 0;

	(*(__complex128*)res) = z;
}

void Lib_QCplx_Set2(QCplxPtr res, const QRealPtr re, const QRealPtr im)
{
    __complex128 z;
    __real__ z = (*(__float128*)re);
    __imag__ z = (*(__float128*)im);

	(*(__complex128*)res) = z;
}

void Lib_QCplx_Set2a(QCplxPtr res, const QRealPtr re, const QRealPtr im)
{
    __real__ (*(__complex128*)res) = (*(__float128*)re);
    __imag__ (*(__complex128*)res) = (*(__float128*)im);
}

void Lib_QCplx_Abs(QRealPtr res, const QCplxPtr x)
{
	(*(__float128*)res) = cabsq(*(__complex128*)x);
}

void Lib_QCplx_Arg(QRealPtr res, const QCplxPtr x)
{
	(*(__float128*)res) = cargq(*(__complex128*)x);
}

void Lib_QCplx_Imag(QRealPtr res, const QCplxPtr x)
{
	(*(__float128*)res) = cimagq(*(__complex128*)x);
}

void Lib_QCplx_Real(QRealPtr res, const QCplxPtr x)
{
	(*(__float128*)res) = crealq(*(__complex128*)x);
}

void Lib_QCplx_Conj(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = conjq(*(__complex128*)x);
}

void Lib_QCplx_Proj(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cprojq(*(__complex128*)x);
}





/* Roots  */


__complex128 cplx_expm1q(__complex128 z)
{
    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
	__float128 x = crealq(z);
	__float128 y = cimagq(z);
	__float128 resx = expm1q(x) * cosq(y) + cosm1q(y);
	__float128 resy = expq(x) * sinq(y);
    __complex128 res;
    __real__ res = resx;
    __imag__ res = resy;
	return res;
}

__complex128  cplx_log1pq(__complex128 z)
{
    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
    /* resy =  atan2(y, 1 + x); */
	__float128 x = crealq(z);
	__float128 y = cimagq(z);
	__float128 resx = 0.0Q ;
	if ( (fabsq(x) > 0.75Q) || (fabsq(y) > 0.75Q) || (x < -0.5Q) )
    {
        resx = logq(hypotq(1.0Q + x, y)) ;
    }
    else
    {
        resx = 0.5Q * log1pq(2.0Q * x + x*x + y*y);
    }
	__float128 resy = atan2q(y, 1.0Q + x);

    __complex128 res;
    __real__ res = resx;
    __imag__ res = resy;
	return res;
}


void Lib_QCplx_Sqrt(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = csqrtq(*(__complex128*)x);
}

void Lib_QCplx_Sqrt1pm1(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cplx_expm1q(cplx_log1pq(*(__complex128*)x) * (0.5Q));
}

void Lib_QCplx_Rsqrt(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (1.0Q) / csqrtq(*(__complex128*)x);
}

void Lib_QCplx_Cbrt(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cpowq( (*(__complex128*)x) , (1.0Q)/(3.0Q));
}

void Lib_QCplx_Root_Si(QCplxPtr res, const QCplxPtr x, const int32_t k)
{
	(*(__complex128*)res) = cpowq( (*(__complex128*)x) , (1.0Q)/k);
}




/* Exponential and related functions  */

void Lib_QCplx_Exp(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cexpq(*(__complex128*)x);
}

void Lib_QCplx_Expi(QCplxPtr res, const QRealPtr x)
{
	(*(__complex128*)res) = cexpiq(*(__float128*)x);
}

void Lib_QCplx_Exp2(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cexpq( (*(__complex128*)x) * M_LN2q );
}

void Lib_QCplx_Exp10(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cexpq( (*(__complex128*)x) * M_LN10q );
}

void Lib_QCplx_Expm1(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cplx_expm1q(*(__complex128*)x);
}

void Lib_QCplx_Exp2m1(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cplx_expm1q( (*(__complex128*)x) * M_LN2q );
}

void Lib_QCplx_Exp10m1(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cplx_expm1q( (*(__complex128*)x) * M_LN10q );
}




/* Logarithms and related functions  */

void Lib_QCplx_Log(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = clogq(*(__complex128*)x);
}

void Lib_QCplx_Log2(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = clogq(*(__complex128*)x) / M_LN2q;
}

void Lib_QCplx_Log10(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = clog10q(*(__complex128*)x);
}


void Lib_QCplx_Log1p(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cplx_log1pq(*(__complex128*)x);
}

void Lib_QCplx_Log2p1(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cplx_log1pq(*(__complex128*)x) / M_LN2q;
}

void Lib_QCplx_Log10p1(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cplx_log1pq(*(__complex128*)x) / M_LN10q;
}





/* Power functions and roots  */


void Lib_QCplx_Square(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (*(__complex128*)x) * (*(__complex128*)x);
}

void Lib_QCplx_Cube(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (*(__complex128*)x) * (*(__complex128*)x) * (*(__complex128*)x);
}


void Lib_QCplx_Pow(QCplxPtr res, const QCplxPtr x, const QCplxPtr y)
{
	(*(__complex128*)res) = cpowq( (*(__complex128*)x), (*(__complex128*)y) );
}

void Lib_QCplx_Powm1(QCplxPtr res, const QCplxPtr x, const QCplxPtr y)
{
    (*(__complex128*)res) = cplx_expm1q(clogq(*(__complex128*)x) * (*(__complex128*)y));
}

void Lib_QCplx_Pow1p(QCplxPtr res, const QCplxPtr x, const QCplxPtr y)
{
    (*(__complex128*)res) = cexpq(cplx_log1pq(*(__complex128*)x) * (*(__complex128*)y));
}

void Lib_QCplx_Pow1pm1(QCplxPtr res, const QCplxPtr x, const QCplxPtr y)
{
    (*(__complex128*)res) = cplx_expm1q(cplx_log1pq(*(__complex128*)x) * (*(__complex128*)y));
}


void Lib_QCplx_Pow_Si(QCplxPtr res, const QCplxPtr x, const int32_t k)
{
	(*(__complex128*)res) = cpowq( (*(__complex128*)x), k);
}

void Lib_QCplx_Compound_Si(QCplxPtr res, const QCplxPtr x, const int32_t k)
{
	(*(__complex128*)res) = cpowq((1.0Q) + (*(__complex128*)x), k);
}






/* Trigonometric functions  */

void Lib_QCplx_Sin(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = csinq(*(__complex128*)x);
}

void Lib_QCplx_Cos(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = ccosq (*(__complex128*)x);
}


void Lib_QCplx_Tan(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = ctanq(*(__complex128*)x);
}


void Lib_QCplx_Csc(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (1.0Q) / csinq(*(__complex128*)x);
}

void Lib_QCplx_Sec(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (1.0Q) / ccosq (*(__complex128*)x);
}


void Lib_QCplx_Cot(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (1.0Q) / ctanq(*(__complex128*)x);
}



void Lib_QCplx_SinPi(QCplxPtr res, const QCplxPtr x)
{
//	(*(__complex128*)res) = csinq(*(__complex128*)x);
}

void Lib_QCplx_CosPi(QCplxPtr res, const QCplxPtr x)
{
//	(*(__complex128*)res) = ccosq (*(__complex128*)x);
}


void Lib_QCplx_TanPi(QCplxPtr res, const QCplxPtr x)
{
//	(*(__complex128*)res) = ctanq(*(__complex128*)x);
}





/* Hyperbolic functions  */

void Lib_QCplx_Sinh(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = csinhq(*(__complex128*)x);
}

void Lib_QCplx_Cosh(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = ccoshq (*(__complex128*)x);
}

void Lib_QCplx_Tanh(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = ctanhq(*(__complex128*)x);
}


void Lib_QCplx_Csch(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (1.0Q) / csinhq(*(__complex128*)x);
}

void Lib_QCplx_Sech(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (1.0Q) / ccoshq (*(__complex128*)x);
}

void Lib_QCplx_Coth(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = (1.0Q) / ctanhq(*(__complex128*)x);
}





/* Inverse trigonometric functions  */

void Lib_QCplx_Asin(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = casinq(*(__complex128*)x);
}

void Lib_QCplx_Acos(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cacosq(*(__complex128*)x);
}

void Lib_QCplx_Atan(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = catanq(*(__complex128*)x);
}


void Lib_QCplx_Acsc(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = casinq((1.0Q) / (*(__complex128*)x));
}

void Lib_QCplx_Asec(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cacosq((1.0Q) / (*(__complex128*)x));
}

void Lib_QCplx_Acot(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = catanq((1.0Q) / (*(__complex128*)x));
}




/* Inverse hyperbolic functions  */

void Lib_QCplx_Asinh(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = casinhq(*(__complex128*)x);
}

void Lib_QCplx_Acosh(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cacoshq(*(__complex128*)x);
}

void Lib_QCplx_Atanh(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = catanhq(*(__complex128*)x);
}


void Lib_QCplx_Acsch(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = casinhq((1.0Q) / (*(__complex128*)x));
}

void Lib_QCplx_Asech(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = cacoshq((1.0Q) / (*(__complex128*)x));
}

void Lib_QCplx_Acoth(QCplxPtr res, const QCplxPtr x)
{
	(*(__complex128*)res) = catanhq((1.0Q) / (*(__complex128*)x));
}























//*********************** Boost Special functions , quadruple precision **********************************



void Lib_QReal_BernoulliB2n(QRealPtr res, const int n)
{
    LibQReal_BernoulliB2n(res, n);
}



void Lib_QReal_TangentT2n(QRealPtr res, const int n)
{
    LibQReal_TangentT2n(res, n);
}



void Lib_QReal_Sqrt1pm1_Boost(QRealPtr res, const QRealPtr x)
{
    LibQReal_Sqrt1pm1(res, x);
}



void Lib_QReal_SinPi_Boost(QRealPtr res, const QRealPtr x)
{
    LibQReal_SinPi(res, x);
}



void Lib_QReal_CosPi_Boost(QRealPtr res, const QRealPtr x)
{
    LibQReal_CosPi(res, x);
}



void Lib_QReal_SincPi(QRealPtr res, const QRealPtr x)
{
    LibQReal_SincPi(res, x);
}



void Lib_QReal_SinhcPi(QRealPtr res, const QRealPtr x)
{
    LibQReal_SinhcPi(res, x);
}



void Lib_QReal_Tgamma_(QRealPtr res, const QRealPtr x)
{
    LibQReal_Tgamma_(res, x);
}


void Lib_QReal_Tgamma1pm1(QRealPtr res, const QRealPtr x)
{
    LibQReal_Tgamma1pm1(res, x);
}



void Lib_QReal_Lgamma_(QRealPtr res, const QRealPtr x)
{
    LibQReal_Lgamma_(res, x);
}



void Lib_QReal_Digamma(QRealPtr res, const QRealPtr x)
{
    LibQReal_Digamma(res, x);
}



void Lib_QReal_Trigamma(QRealPtr res, const QRealPtr x)
{
    LibQReal_Trigamma(res, x);
}



void Lib_QReal_Factorial(QRealPtr res, const QRealPtr x)
{
    LibQReal_Factorial(res, x);
}



void Lib_QReal_DoubleFactorial(QRealPtr res, const QRealPtr x)
{
    LibQReal_DoubleFactorial(res, x);
}





void Lib_QReal_Erf_(QRealPtr res, const QRealPtr x)
{
    LibQReal_Erf_(res, x);
}



void Lib_QReal_Erfc_(QRealPtr res, const QRealPtr x)
{
    LibQReal_Erfc_(res, x);
}



void Lib_QReal_Erf_inv(QRealPtr res, const QRealPtr x)
{
    LibQReal_Erf_inv(res, x);
}



void Lib_QReal_Erfc_inv(QRealPtr res, const QRealPtr x)
{
    LibQReal_Erfc_inv(res, x);
}



void Lib_QReal_AiryAi(QRealPtr res, const QRealPtr x)
{
    LibQReal_AiryAi(res, x);
}



void Lib_QReal_AiryBi(QRealPtr res, const QRealPtr x)
{
    LibQReal_AiryBi(res, x);
}



void Lib_QReal_AiryAiPrime(QRealPtr res, const QRealPtr x)
{
    LibQReal_AiryAiPrime(res, x);
}



void Lib_QReal_AiryBiPrime(QRealPtr res, const QRealPtr x)
{
    LibQReal_AiryBiPrime(res, x);
}



void Lib_QReal_Aizero(QRealPtr res, const int n)
{
    LibQReal_Aizero(res, n);
}



void Lib_QReal_Bizero(QRealPtr res, const int n)
{
    LibQReal_Bizero(res, n);
}



void Lib_QReal_Ellint_1_K(QRealPtr res, const QRealPtr x)
{
    LibQReal_Ellint_1_K(res, x);
}



void Lib_QReal_Ellint_2_K(QRealPtr res, const QRealPtr x)
{
    LibQReal_Ellint_2_K(res, x);
}



void Lib_QReal_Zeta(QRealPtr res, const QRealPtr x)
{
    LibQReal_Zeta(res, x);
}



void Lib_QReal_Ei(QRealPtr res, const QRealPtr x)
{
    LibQReal_Ei(res, x);
}



void Lib_QReal_LambertW0(QRealPtr res, const QRealPtr x)
{
    LibQReal_LambertW0(res, x);
}


void Lib_QReal_LambertWm1(QRealPtr res, const QRealPtr x)
{
    LibQReal_LambertWm1(res, x);
}



void Lib_QReal_LambertW0Prime(QRealPtr res, const QRealPtr x)
{
    LibQReal_LambertW0Prime(res, x);
}


void Lib_QReal_LambertWm1Prime(QRealPtr res, const QRealPtr x)
{
    LibQReal_LambertWm1Prime(res, x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void Lib_QReal_Agm(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
    LibQReal_Agm(res, a, b);
}




void Lib_QReal_Powm1_Boost(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
    LibQReal_Powm1(res, a, b);
}



void Lib_QReal_TgammaRatio(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
    LibQReal_TgammaRatio(res, a, b);
}



void Lib_QReal_TgammaDeltaRatio(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
    LibQReal_TgammaDeltaRatio(res, a, b);
}



void Lib_QReal_Binomial(QRealPtr res, const QRealPtr n, const QRealPtr k)
{
    LibQReal_Binomial(res, n, k);
}

void Lib_QReal_RisingFactorial(QRealPtr res, const QRealPtr x, const QRealPtr n)
{
    LibQReal_RisingFactorial(res, x, n);
}




void Lib_QReal_FallingFactorial(QRealPtr res, const QRealPtr x, const QRealPtr n)
{
    LibQReal_FallingFactorial(res, x, n);
}




void Lib_QReal_BesselJ(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
    LibQReal_BesselJ(res, v, x);
}



void Lib_QReal_BesselY(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
    LibQReal_BesselY(res, v, x);
}



void Lib_QReal_BesselI(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
    LibQReal_BesselI(res, v, x);
}



void Lib_QReal_BesselK(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
    LibQReal_BesselK(res, v, x);
}



void Lib_QReal_SphBessel(QRealPtr res, const unsigned v, const QRealPtr x)
{
    LibQReal_SphBessel(res, v, x);
}



void Lib_QReal_SphNeumann(QRealPtr res, const unsigned v, const QRealPtr x)
{
    LibQReal_SphNeumann(res, v, x);
}





void Lib_QReal_BesselJPrime(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
    LibQReal_BesselJPrime(res, v, x);
}



void Lib_QReal_BesselYPrime(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
    LibQReal_BesselYPrime(res, v, x);
}



void Lib_QReal_BesselIPrime(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
    LibQReal_BesselIPrime(res, v, x);
}



void Lib_QReal_BesselKPrime(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
    LibQReal_BesselKPrime(res, v, x);
}



void Lib_QReal_SphBesselPrime(QRealPtr res, const unsigned v, const QRealPtr x)
{
    LibQReal_SphBesselPrime(res, v, x);
}



void Lib_QReal_SphNeumannPrime(QRealPtr res, const unsigned v, const QRealPtr x)
{
    LibQReal_SphNeumannPrime(res, v, x);
}





void Lib_QReal_BesselJZero(QRealPtr res, const QRealPtr v, const int m)
{
    LibQReal_BesselJZero(res, v, m);
}



void Lib_QReal_BesselYZero(QRealPtr res, const QRealPtr v, const int m)
{
    LibQReal_BesselYZero(res, v, m);
}





void Lib_QReal_GammaP(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
    LibQReal_GammaP(res, a, x);
}


void Lib_QReal_GammaQ(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
    LibQReal_GammaQ(res, a, x);
}


void Lib_QReal_TgammaLower(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
    LibQReal_TgammaLower(res, a, x);
}


void Lib_QReal_TgammaUpper(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
    LibQReal_TgammaUpper(res, a, x);
}




void Lib_QReal_GammaPInv(QRealPtr res, const QRealPtr a, const QRealPtr p)
{
    LibQReal_GammaPInv(res, a, p);
}


void Lib_QReal_GammaQInv(QRealPtr res, const QRealPtr a, const QRealPtr q)
{
    LibQReal_GammaQInv(res, a, q);
}


void Lib_QReal_GammaPInva(QRealPtr res, const QRealPtr x, const QRealPtr p)
{
    LibQReal_GammaPInva(res, x, p);
}


void Lib_QReal_GammaQInva(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
    LibQReal_GammaQInva(res, x, q);
}



void Lib_QReal_GammaPDerivative(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
    LibQReal_GammaPDerivative(res, a, x);
}


void Lib_QReal_Beta(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
    LibQReal_Beta(res, a, b);
}









void Lib_QReal_LegendreP(QRealPtr res, int n, const QRealPtr x)
{
    LibQReal_LegendreP(res, n, x);
}



void Lib_QReal_LegendreQ(QRealPtr res, int n, const QRealPtr x)
{
    LibQReal_LegendreQ(res, n, x);
}



void Lib_QReal_Laguerre(QRealPtr res, int n, const QRealPtr x)
{
    LibQReal_Laguerre(res, n, x);
}



void Lib_QReal_Hermite(QRealPtr res, int n, const QRealPtr x)
{
    LibQReal_Hermite(res, n, x);
}



void Lib_QReal_ChebyshevT(QRealPtr res, int n, const QRealPtr x)
{
    LibQReal_ChebyshevT(res, n, x);
}


void Lib_QReal_ChebyshevU(QRealPtr res, int n, const QRealPtr x)
{
    LibQReal_ChebyshevU(res, n, x);
}



void Lib_QReal_Polygamma(QRealPtr res, int n, const QRealPtr x)
{
    LibQReal_Polygamma(res, n, x);
}





void Lib_QReal_EllintRC(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
    LibQReal_EllintRC(res, x, y);
}


void Lib_QReal_Ellint1F(QRealPtr res, const QRealPtr k, const QRealPtr phi)
{
    LibQReal_Ellint1F(res, k, phi);
}


void Lib_QReal_Ellint2F(QRealPtr res, const QRealPtr k, const QRealPtr phi)
{
    LibQReal_Ellint2F(res, k, phi);
}


void Lib_QReal_Ellint3K(QRealPtr res, const QRealPtr k, const QRealPtr n)
{
    LibQReal_Ellint3K(res, k, n);
}




void Lib_QReal_JacobiCD(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiCD(res, k, u);
}


void Lib_QReal_JacobiCN(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiCN(res, k, u);
}


void Lib_QReal_JacobiCS(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiCS(res, k, u);
}


void Lib_QReal_JacobiDC(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiDC(res, k, u);
}


void Lib_QReal_JacobiDN(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiDN(res, k, u);
}


void Lib_QReal_JacobiDS(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiDS(res, k, u);
}


void Lib_QReal_JacobiNC(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiNC(res, k, u);
}


void Lib_QReal_JacobiND(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiND(res, k, u);
}


void Lib_QReal_JacobiNS(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiNS(res, k, u);
}


void Lib_QReal_JacobiSC(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiSC(res, k, u);
}


void Lib_QReal_JacobiSD(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiSD(res, k, u);
}


void Lib_QReal_JacobiSN(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
    LibQReal_JacobiSN(res, k, u);
}



void Lib_QReal_expint(QRealPtr res, const unsigned n, const QRealPtr x)
{
    LibQReal_expint(res, n, x);
}




void Lib_QReal_OwenT(QRealPtr res, const QRealPtr h, const QRealPtr a)
{
    LibQReal_OwenT(res, h, a);
}





void Lib_QReal_IBeta(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
    LibQReal_IBeta(res, a, b, x);
}


void Lib_QReal_IBetac(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
    LibQReal_IBetac(res, a, b, x);
}


void Lib_QReal_IBetaNonNormalized(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
    LibQReal_IBetaNonNormalized(res, a, b, x);
}


void Lib_QReal_IBetacNonNormalized(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
    LibQReal_IBetacNonNormalized(res, a, b, x);
}


void Lib_QReal_IBetaInv(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr p)
{
    LibQReal_IBetaInv(res, a, b, p);
}


void Lib_QReal_IBetacInv(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr q)
{
    LibQReal_IBetacInv(res, a, b, q);
}


void Lib_QReal_IBetaInva(QRealPtr res, const QRealPtr b, const QRealPtr x, const QRealPtr p)
{
    LibQReal_IBetaInva(res, b, x, p);
}


void Lib_QReal_IBetacInva(QRealPtr res, const QRealPtr b, const QRealPtr x, const QRealPtr q)
{
    LibQReal_IBetacInva(res, b, x, q);
}


void Lib_QReal_IBetaInvb(QRealPtr res, const QRealPtr a, const QRealPtr x, const QRealPtr p)
{
    LibQReal_IBetaInvb(res, a, x, p);
}


void Lib_QReal_IBetacInvb(QRealPtr res, const QRealPtr a, const QRealPtr x, const QRealPtr q)
{
    LibQReal_IBetacInvb(res, a, x, q);
}


void Lib_QReal_IBetaDerivative(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
    LibQReal_IBetaDerivative(res, a, b, x);
}




void Lib_QReal_LegendrePM(QRealPtr res, const int n, const int m, const QRealPtr x)
{
    LibQReal_LegendrePM(res, n, m, x);
}



void Lib_QReal_LaguerreM(QRealPtr res, const int n, const int m, const QRealPtr x)
{
    LibQReal_LaguerreM(res, n, m, x);
}





void Lib_QReal_EllipticRF(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z)
{
    LibQReal_EllipticRF(res, x, y, z);
}



void Lib_QReal_EllipticRD(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z)
{
    LibQReal_EllipticRD(res, x, y, z);
}



void Lib_QReal_EllipticRG(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z)
{
    LibQReal_EllipticRG(res, x, y, z);
}



void Lib_QReal_Ellint3F(QRealPtr res, const QRealPtr k, const QRealPtr n, const QRealPtr phi)
{
    LibQReal_Ellint3F(res, k, n, phi);
}




void Lib_QReal_Gegenbauer(QRealPtr res, const int n, const QRealPtr lambda, const QRealPtr x)
{
    LibQReal_Gegenbauer(res, n, lambda, x);
}


void Lib_QReal_Jacobi(QRealPtr res, const int n, const QRealPtr alpha, const QRealPtr beta, const QRealPtr x)
{
    LibQReal_Jacobi(res, n, alpha, beta, x);
}




void Lib_QReal_SphericalHarmonicR(QRealPtr res, const int n, const int m, const QRealPtr theta, const QRealPtr phi)
{
    LibQReal_SphericalHarmonicR(res, n, m, theta, phi);
}


void Lib_QReal_SphericalHarmonicI(QRealPtr res, const int n, const int m, const QRealPtr theta, const QRealPtr phi)
{
    LibQReal_SphericalHarmonicI(res, n, m, theta, phi);
}


void Lib_QReal_EllipticRJ(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z, const QRealPtr p)
{
    LibQReal_EllipticRJ(res, x, y, z, p);
}


// Hypergeometric and Theta Functions




void Lib_QReal_Hypergeo0F1(QRealPtr res, const QRealPtr b, const QRealPtr x)
{
    LibQReal_Hypergeo0F1(res, b, x);
}



void Lib_QReal_Hypergeo1F1(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
    LibQReal_Hypergeo1F1(res, a, b, x);
}



void Lib_QReal_Hypergeo1F1r(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
    LibQReal_Hypergeo1F1r(res, a, b, x);
}



void Lib_QReal_LogHypergeo1F1(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
    LibQReal_LogHypergeo1F1(res, a, b, x);
}





void Lib_QReal_JacobiTheta1(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
    LibQReal_JacobiTheta1(res, x, q);
}


void Lib_QReal_JacobiTheta2(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
    LibQReal_JacobiTheta2(res, x, q);
}


void Lib_QReal_JacobiTheta3(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
    LibQReal_JacobiTheta3(res, x, q);
}


void Lib_QReal_JacobiTheta4(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
    LibQReal_JacobiTheta4(res, x, q);
}




//***********************  Boost Distributions, quadruple precision  **********************************


void Lib_QReal_ArcsineDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b)
{
    LibQReal_ArcsineDist(Target, res, xqp, a, b);
}



void Lib_QReal_BernoulliDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr p)
{
    LibQReal_BernoulliDist(Target, res, xqp, p);
}



void Lib_QReal_BetaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b)
{
    LibQReal_BetaDist(Target, res, xqp, a, b);
}



void Lib_QReal_BinomialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n, QRealPtr p)
{
    LibQReal_BinomialDist(Target, res, xqp, n, p);
}



void Lib_QReal_CauchyDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_CauchyDist(Target, res, xqp, location, scale);
}



void Lib_QReal_Chi2Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    LibQReal_Chi2Dist(Target, res, xqp, nu);
}



void Lib_QReal_ExponentialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lambda)
{
    LibQReal_ExponentialDist(Target, res, xqp, lambda);
}



void Lib_QReal_GumbelDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_ExtremeValueDist(Target, res, xqp, location, scale);
}



void Lib_QReal_FisherFDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mu, QRealPtr nu)
{
    LibQReal_FisherFDist(Target, res, xqp, mu, nu);
}



void Lib_QReal_GammaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale)
{
    LibQReal_GammaDist(Target, res, xqp, shape, scale);
}



void Lib_QReal_GeometricDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr p)
{
    LibQReal_GeometricDist(Target, res, xqp, p);
}



void Lib_QReal_HypergeometricDist(long Target, QRealPtr res, QRealPtr xqp, uint64_t r, uint64_t n, uint64_t N)
{
    LibQReal_HypergeometricDist(Target, res, xqp, r, n, N);
}



void Lib_QReal_InverseChi2Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr df, QRealPtr scale)
{
    LibQReal_InverseChi2Dist(Target, res, xqp, df, scale);
}



void Lib_QReal_InverseGammaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale)
{
    LibQReal_InverseGammaDist(Target, res, xqp, shape, scale);
}



void Lib_QReal_WaldDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr scale)
{
    LibQReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
}



void Lib_QReal_LaplaceDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_LaplaceDist(Target, res, xqp, location, scale);
}



void Lib_QReal_LogisticDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_LogisticDist(Target, res, xqp, location, scale);
}



void Lib_QReal_LognormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_LognormalDist(Target, res, xqp, location, scale);
}



void Lib_QReal_NegBinomialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n, QRealPtr p)
{
    LibQReal_NegBinomialDist(Target, res, xqp, n, p);
}


void Lib_QReal_Chi2NcDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu, QRealPtr nc)
{
    LibQReal_Chi2NCDist(Target, res, xqp, nu, nc);
}


void Lib_QReal_StudentTNcDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu, QRealPtr delta)
{
    LibQReal_StudentTNCDist(Target, res, xqp, nu, delta);
}



void Lib_QReal_FisherNcDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mu, QRealPtr nu, QRealPtr nc)
{
    LibQReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
}



void Lib_QReal_BetaNcDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b, QRealPtr nc)
{
    LibQReal_BetaNCDist(Target, res, xqp, a, b, nc);
}



void Lib_QReal_NormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr stdev)
{
    LibQReal_NormalDist(Target, res, xqp, mean_, stdev);
}



void Lib_QReal_ParetoDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale)
{
    LibQReal_ParetoDist(Target, res, xqp, shape, scale);
}



void Lib_QReal_PoissonDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    LibQReal_PoissonDist(Target, res, xqp, nu);
}



void Lib_QReal_RayleighDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    LibQReal_RayleighDist(Target, res, xqp, nu);
}



void Lib_QReal_SkewNormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr scale, QRealPtr shape)
{
    LibQReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
}



void Lib_QReal_StudentTDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    LibQReal_StudentTDist(Target, res, xqp, nu);
}



void Lib_QReal_TriangularDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lower, QRealPtr mode_, QRealPtr upper)
{
    LibQReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
}



void Lib_QReal_WeibullDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale)
{
    LibQReal_WeibullDist(Target, res, xqp, shape, scale);
}



void Lib_QReal_UniformDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lower, QRealPtr upper)
{
    LibQReal_UniformDist(Target, res, xqp, lower, upper);
}



//*********************** New , quadruple precision **********************************




void Lib_QReal_Logaddexp(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
    LibQReal_Logaddexp(res, a, b);
}



void Lib_QReal_HyperexponentialDist(long Target, QRealPtr res, QRealPtr xqp, mpNumMatrixPtr l1, mpNumMatrixPtr l2)
{
    LibQReal_HyperexponentialDist(Target, res, xqp, (QStatePtr)l1, (QStatePtr)l2);
}



void Lib_QReal_KolmogorovSmirnovDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n)
{
    LibQReal_KolmogorovSmirnovDist(Target, res, xqp, n);
}


void Lib_QReal_HoltsmarkDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_HoltsmarkDist(Target, res, xqp, location, scale);
}


void Lib_QReal_LandauDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_LandauDist(Target, res, xqp, location, scale);
}


void Lib_QReal_MapAiryDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_MapAiryDist(Target, res, xqp, location, scale);
}


void Lib_QReal_Saspoint5Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    LibQReal_Saspoint5Dist(Target, res, xqp, location, scale);
}







//*********************** Extra **********************************





void ShowQuadNet(char* cstr, QRealPtr x)
{
    LibQReal_ShowQuadNet(cstr, x);
}





//*********************** Boost Numerical Calculus, quadruple precision **********************************




void Lib_QReal_BracketRoot(QRealPtr res1, QRealPtr res2, int* iter, QuadFuncPtr f1, QRealPtr guess_, QRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    LibQReal_BracketRoot(res1, res2, iter, f1, guess_, factor_, is_rising, get_digits, maxit);
}



void Lib_QReal_NewtonRaphson(QRealPtr res,  int* iter, QuadFuncPtr f1, QuadFuncPtr f2, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibQReal_NewtonRaphson(res, iter, f1, f2, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_QReal_Halley(QRealPtr res, int* iter, QuadFuncPtr f1, QuadFuncPtr f2, QuadFuncPtr f3, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibQReal_Halley(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_QReal_Schroder(QRealPtr res, int* iter, QuadFuncPtr f1, QuadFuncPtr f2, QuadFuncPtr f3, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibQReal_Schroder(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_QReal_Brent_Minimum(QRealPtr res, QRealPtr resFx, int* iter, QuadFuncPtr f1, QRealPtr bracket_min_, QRealPtr bracket_max_, int bits, unsigned int maxit)
{
    LibQReal_Brent_Minimum(res, resFx, iter, f1, bracket_min_, bracket_max_, bits, maxit);
}




void Lib_QReal_Trapezoidal(QRealPtr res1, QRealPtr res2, QRealPtr res3, QuadFuncPtr f1, QRealPtr a_, QRealPtr b_)
{
    LibQReal_Trapezoidal(res1, res2, res3, f1, a_, b_);
}



// 7, 15, 20, 25 and 30

void Lib_QReal_GaussLegendre(QRealPtr res1, QRealPtr res3, QuadFuncPtr f1, QRealPtr a_, QRealPtr b_)
{
    LibQReal_GaussLegendre(res1, res3, f1, a_, b_);
}




//15, 31, 41, 51 and 61

void Lib_QReal_GaussKronrod(QRealPtr res1, QRealPtr res2, QRealPtr res3, QuadFuncPtr f1, QRealPtr a_, QRealPtr b_)
{
    LibQReal_GaussKronrod(res1, res2, res3, f1, a_, b_);
}



void Lib_QReal_TanhSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QuadFuncPtr f1, QRealPtr a_, QRealPtr b_)
{
    LibQReal_TanhSinh(res1, res2, res3, levels_, f1, a_, b_);
}




void Lib_QReal_SinhSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QuadFuncPtr f1)
{
    LibQReal_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_QReal_ExpSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QuadFuncPtr f1)
{
    LibQReal_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_QReal_Ooura_Cos(QRealPtr res1, QRealPtr res2, QuadFuncPtr f1)
{
    LibQReal_Ooura_Cos(res1, res2, f1);
}



void Lib_QReal_Ooura_Sin(QRealPtr res1, QRealPtr res2, QuadFuncPtr f1)
{
    LibQReal_Ooura_Sin(res1, res2, f1);
}





//*********************** Boost Odeint **********************************



void Lib_QReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    LibQReal_Const_RungeKutta4((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_);
}


void Lib_QReal_Const_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    LibQReal_Const_RungeKuttaCashKarp54((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_);
}


void Lib_QReal_Const_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    LibQReal_Const_RungeKuttaDopri5((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_);
}


void Lib_QReal_Const_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    LibQReal_Const_RungeKuttaFehlberg78((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_);
}


void Lib_QReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    LibQReal_Const_AdamsBashforthMoulton((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_);
}






void Lib_QReal_Adaptive_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    LibQReal_Adaptive_RungeKuttaDopri5((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}


void Lib_QReal_Adaptive_CashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    LibQReal_Adaptive_RungeKuttaCashKarp54((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}


void Lib_QReal_Adaptive_Fehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    LibQReal_Adaptive_RungeKuttaFehlberg78((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}


void Lib_QReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    LibQReal_Adaptive_BulirschStoer((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}


void Lib_QReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    LibQReal_DenseOutput_Dopri5((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}


void Lib_QReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    LibQReal_DenseOutput_BulirschStoer((QAnyFuncPtr3)f1, (QAnyFuncPtr2)f2, (QStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}








