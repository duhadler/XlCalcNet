
#include <boost/decimal.hpp>

#include "mpNumC_Main.h"
#include "BoostDReal.h"

#include "stdint.h"
#include <complex>
#include <vector>
#include <iostream>
#include <limits>


using namespace std;
using namespace std::numbers;
using namespace boost::decimal;




/** ********************** Real Basic Functions, extended precision ******************************** **/


DRealPtr Lib_DReal_Init_Func()
{
	DRealPtr x = NULL;
	x = (decimal128*)malloc(sizeof(decimal128));
	*(decimal128*)x = 0;
	return x;
}


void Lib_DReal_Clear(DRealPtr x)
{
	free(x);
}



void Lib_DReal_Get_Str(char* cstr, DRealPtr x)
{
    decimal128 d = *(decimal128*)x;
    std::stringstream ss;
    ss.precision(std::numeric_limits<decimal128>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}




void Lib_DReal_Set_Str(DRealPtr res, const char * str)
{
    (*(decimal128*)res) = boost::decimal::strtod128(str, NULL);
}




void Lib_DReal_Set(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (*(decimal128*)x);
}



void Lib_DReal_Neg(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = -(*(decimal128*)x);
}


void Lib_DReal_Set_S(DRealPtr res, const float* x)
{
	(*(decimal128*)res) = *x;
}


void Lib_DReal_Set_D(DRealPtr res, const double x)
{
	(*(decimal128*)res) = x;
}


void Lib_DReal_Set_LD(DRealPtr res, const long double* x)
{
	(*(decimal128*)res) = *x;
}



void Lib_DReal_Set_Si(DRealPtr res, const int32_t x)
{
	(*(decimal128*)res) = x;
}



void Lib_DReal_Set_Si64(DRealPtr res, const int64_t x)
{
	(*(decimal128*)res) = x;
}



void Lib_DReal_Set_Ui(DRealPtr res, const uint32_t x)
{
	(*(decimal128*)res) = x;
}



void Lib_DReal_Set_Ui64(DRealPtr res, const uint64_t x)
{
	(*(decimal128*)res) = x;
}









void Lib_DReal_Add(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = (*(decimal128*)x) + (*(decimal128*)y);
}


void Lib_DReal_Sub(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = (*(decimal128*)x) - (*(decimal128*)y);
}



void Lib_DReal_Mul(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = (*(decimal128*)x) * (*(decimal128*)y);
}



void Lib_DReal_Div(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = (*(decimal128*)x) / (*(decimal128*)y);
}








void Lib_DReal_Add_D(DRealPtr res, const DRealPtr x, const double y)
{
    decimal128 temp {y};
	(*(decimal128*)res) = (*(decimal128*)x) + temp;
}


void Lib_DReal_Sub_D(DRealPtr res, const DRealPtr x, const double y)
{
    decimal128 temp {y};
	(*(decimal128*)res) = (*(decimal128*)x) - temp;
}


void Lib_DReal_D_Sub(DRealPtr res, const DRealPtr x, const double y)
{
    decimal128 temp {y};
	(*(decimal128*)res) = temp - (*(decimal128*)x);
}


void Lib_DReal_Mul_D(DRealPtr res, const DRealPtr x, const double y)
{
    decimal128 temp {y};
	(*(decimal128*)res) = (*(decimal128*)x) * temp;
}


void Lib_DReal_Div_D(DRealPtr res, const DRealPtr x, const double y)
{
    decimal128 temp {y};
	(*(decimal128*)res) = (*(decimal128*)x) / temp;
}


void Lib_DReal_D_Div(DRealPtr res, const DRealPtr x, const double y)
{
    decimal128 temp {y};
	(*(decimal128*)res) = temp / (*(decimal128*)x);
}









void Lib_DReal_Add_Si(DRealPtr res, const DRealPtr x, const int32_t y)
{
	(*(decimal128*)res) = (*(decimal128*)x) + y;
}


void Lib_DReal_Sub_Si(DRealPtr res, const DRealPtr x, const int32_t y)
{
	(*(decimal128*)res) = (*(decimal128*)x) - y;
}


void Lib_DReal_Si_Sub(DRealPtr res, const DRealPtr x, const int32_t y)
{
	(*(decimal128*)res) = y - (*(decimal128*)x);
}


void Lib_DReal_Mul_Si(DRealPtr res, const DRealPtr x, const int32_t y)
{
	(*(decimal128*)res) = (*(decimal128*)x) * y;
}


void Lib_DReal_Div_Si(DRealPtr res, const DRealPtr x, const int32_t y)
{
	(*(decimal128*)res) = (*(decimal128*)x) / y;
}


void Lib_DReal_Si_Div(DRealPtr res, const DRealPtr x, const int32_t y)
{
	(*(decimal128*)res) = y / (*(decimal128*)x);
}







int32_t Lib_DReal_LT(const DRealPtr x, const DRealPtr y)
{
	return (*(decimal128*)x) < (*(decimal128*)y);
}


int32_t Lib_DReal_GE(const DRealPtr x, const DRealPtr y)
{
	return (*(decimal128*)x) >= (*(decimal128*)y);
}


int32_t Lib_DReal_GT(const DRealPtr x, const DRealPtr y)
{
	return (*(decimal128*)x) > (*(decimal128*)y);
}


int32_t Lib_DReal_LE(const DRealPtr x, const DRealPtr y)
{
	return (*(decimal128*)x) <= (*(decimal128*)y);
}


int32_t Lib_DReal_EQ(const DRealPtr x, const DRealPtr y)
{
	return (*(decimal128*)x) == (*(decimal128*)y);
}


int32_t Lib_DReal_NE(const DRealPtr x, const DRealPtr y)
{
	return (*(decimal128*)x) != (*(decimal128*)y);
}











/* General functions for real numbers  */


void Lib_DReal_Fma(DRealPtr res, const DRealPtr x, const DRealPtr y, const DRealPtr z)
{
	(*(decimal128*)res) = boost::decimal::fma( (*(decimal128*)x) , (*(decimal128*)y) , (*(decimal128*)z) );
}


void Lib_DReal_Fmax(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::fmax( (*(decimal128*)x) , (*(decimal128*)y) );
}


void Lib_DReal_Fmin(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::fmin( (*(decimal128*)x) , (*(decimal128*)y) );
}





/* Machine constants */


void Lib_DReal_Zero(DRealPtr res)
{
	(*(decimal128*)res) = 0.0;
}


void Lib_DReal_NegZero(DRealPtr res)
{
	(*(decimal128*)res) = -0.0;
}


void Lib_DReal_One(DRealPtr res)
{
	(*(decimal128*)res) = 1.0;
}


void Lib_DReal_Inf(DRealPtr res)
{
	(*(decimal128*)res) = std::numeric_limits<decimal128>::infinity();
}


void Lib_DReal_NegInf(DRealPtr res)
{
	(*(decimal128*)res) = -std::numeric_limits<decimal128>::infinity();
}


void Lib_DReal_Nan(DRealPtr res)
{
	(*(decimal128*)res) = std::numeric_limits<decimal128>::quiet_NaN();
}






/* Properties of numbers  */

int Lib_DReal_Signbit(const DRealPtr x)
{
	return boost::decimal::signbit(*(decimal128*)x);
}

int Lib_DReal_Finite(const DRealPtr x)
{
	return boost::decimal::isfinite(*(decimal128*)x);
}

int Lib_DReal_Isinf(const DRealPtr x)
{
	return boost::decimal::isinf(*(decimal128*)x);
}

int Lib_DReal_Isposinf(const DRealPtr x)
{
	return ((boost::decimal::isinf(*(decimal128*)x)) & (*(decimal128*)x > 0 ));
}

int Lib_DReal_Isneginf(const DRealPtr x)
{
	return ((boost::decimal::isinf(*(decimal128*)x)) & (*(decimal128*)x < 0 ));
}

int Lib_DReal_Isnan(const DRealPtr x)
{
	return boost::decimal::isnan(*(decimal128*)x);
}



int Lib_DReal_Iszero(const DRealPtr x)
{
	return (boost::decimal::abs(*(decimal128*)x) == 0);
}

int Lib_DReal_Isposzero(const DRealPtr x)
{
	return ((int(boost::decimal::signbit(*(decimal128*)x)) == 0) & (boost::decimal::abs(*(decimal128*)x) == 0));
}

int Lib_DReal_Isnegzero(const DRealPtr x)
{
	return ((int(boost::decimal::signbit(*(decimal128*)x)) != 0) & (boost::decimal::abs(*(decimal128*)x) == 0));
}

int Lib_DReal_Isone(const DRealPtr x)
{
	return (*(decimal128*)x == 1);
}

int Lib_DReal_Isinteger(const DRealPtr x)
{
	return (boost::decimal::ceil(*(decimal128*)x) == boost::decimal::floor(*(decimal128*)x));
}

int Lib_DReal_Isnumber(const DRealPtr x)
{
	return (!(boost::decimal::isnan(*(decimal128*)x) || (boost::decimal::isinf(*(decimal128*)x))));
}

int Lib_DReal_Isregular(const DRealPtr x)
{
	return (!(boost::decimal::isnan(*(decimal128*)x) || (boost::decimal::isinf(*(decimal128*)x) || (boost::decimal::abs(*(decimal128*)x) == 0))));
}

int Lib_DReal_Isnormal(const DRealPtr x)
{
	return (boost::decimal::isnormal(*(decimal128*)x));
}

int Lib_DReal_Issubnormal(const DRealPtr x)
{
    return 0;
}

int Lib_DReal_Isunordered(const DRealPtr x, const DRealPtr y)
{
	return (boost::decimal::isunordered(*(decimal128*)x, *(decimal128*)x));
}







int Lib_DReal_FitsInt32(const DRealPtr x)
{
	return  ((*(decimal128*)x <= std::numeric_limits<int32_t>::max()) &
             (*(decimal128*)x >= std::numeric_limits<int32_t>::min()));
}

int Lib_DReal_FitsInt64(const DRealPtr x)
{
	return  ((*(decimal128*)x <= std::numeric_limits<int64_t>::max()) &
             (*(decimal128*)x >= std::numeric_limits<int64_t>::min()));
}

int Lib_DReal_FitsUInt32(const DRealPtr x)
{
	return  ((*(decimal128*)x <= std::numeric_limits<uint32_t>::max()) &
             (*(decimal128*)x >= std::numeric_limits<uint32_t>::min()));
}

int Lib_DReal_FitsUInt64(const DRealPtr x)
{
	return  ((*(decimal128*)x <= std::numeric_limits<uint64_t>::max()) &
             (*(decimal128*)x >= std::numeric_limits<uint64_t>::min()));
}




/* Integer Related Functions  */

void Lib_DReal_Nearbyint(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::nearbyint(*(decimal128*)x);
}

void Lib_DReal_Rint(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::rint(*(decimal128*)x);
}

long int Lib_DReal_Lrint(const DRealPtr x)
{
	return boost::decimal::lrint(*(decimal128*)x);
}

long long int Lib_DReal_Llrint(const DRealPtr x)
{
	return boost::decimal::llrint(*(decimal128*)x);
}

void Lib_DReal_Ceil(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::ceil(*(decimal128*)x);
}

void Lib_DReal_Floor(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::floor(*(decimal128*)x);
}

void Lib_DReal_Trunc(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::trunc(*(decimal128*)x);
}

void Lib_DReal_Round(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::round(*(decimal128*)x);
}

long int Lib_DReal_Lround(const DRealPtr x)
{
	return boost::decimal::lround(*(decimal128*)x);
}

long long int Lib_DReal_Llround(const DRealPtr x)
{
	return boost::decimal::llround(*(decimal128*)x);
}



int32_t Lib_DReal_ToInt32(const DRealPtr x)
{
    if (*(decimal128*)x >= std::numeric_limits<int32_t>::max())
        return std::numeric_limits<int32_t>::max();
    else if (*(decimal128*)x <= std::numeric_limits<int32_t>::min())
        return std::numeric_limits<int32_t>::min();
    else
        return (int32_t) (*(__float128*)x);
}

int64_t Lib_DReal_ToInt64(const DRealPtr x)
{
    if (*(decimal128*)x >= std::numeric_limits<int64_t>::max())
        return std::numeric_limits<int64_t>::max();
    else if (*(decimal128*)x <= std::numeric_limits<int64_t>::min())
        return std::numeric_limits<int64_t>::min();
    else
        return (int64_t) (*(decimal128*)x);
}

uint32_t Lib_DReal_ToUInt32(const DRealPtr x)
{
    if (*(decimal128*)x >= std::numeric_limits<uint32_t>::max())
        return std::numeric_limits<uint32_t>::max();
    else if (*(decimal128*)x <= std::numeric_limits<uint32_t>::min())
        return std::numeric_limits<uint32_t>::min();
    else
        return (uint32_t) (*(decimal128*)x);
}

uint64_t Lib_DReal_ToUInt64(const DRealPtr x)
{
    if (*(decimal128*)x >= std::numeric_limits<uint64_t>::max())
        return std::numeric_limits<uint64_t>::max();
    else if (*(decimal128*)x <= std::numeric_limits<uint64_t>::min())
        return std::numeric_limits<uint64_t>::min();
    else
        return (uint64_t) (*(decimal128*)x);
}





/* Floating point functions for real numbers */

void Lib_DReal_Copysign(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::copysign( (*(decimal128*)x) , (*(decimal128*)y) );
}

void Lib_DReal_Frexp(DRealPtr res, const DRealPtr x, int* e)
{
	(*(decimal128*)res) = boost::decimal::frexp(*(decimal128*)x, e);
}

void Lib_DReal_Logb(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::logb(*(decimal128*)x);
}

int Lib_DReal_Ilogb(const DRealPtr x)
{
	return boost::decimal::ilogb(*(decimal128*)x);
}

void Lib_DReal_Ldexp(DRealPtr res, const DRealPtr x, const int e)
{
	(*(decimal128*)res) = boost::decimal::ldexp(*(decimal128*)x, e);
}

void Lib_DReal_Scalbn(DRealPtr res, const DRealPtr x, const int e)
{
	(*(decimal128*)res) = boost::decimal::scalbn(*(decimal128*)x, e);
}

void Lib_DReal_Scalbln(DRealPtr res, const DRealPtr x, const long int e)
{
	(*(decimal128*)res) = boost::decimal::scalbln(*(decimal128*)x, e);
}

void Lib_DReal_Fdim(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::fdim( (*(decimal128*)x) , (*(decimal128*)y) );
}



/* Fraction and Remainder Related Functions  */

void Lib_DReal_Modf(DRealPtr frac, const DRealPtr x, DRealPtr iptr)
{
	(*(decimal128*)frac) = boost::decimal::modf( (*(decimal128*)x) , (decimal128*)iptr );
}

void Lib_DReal_Fmod(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::fmod( (*(decimal128*)x) , (*(decimal128*)y) );
}

void Lib_DReal_Remainder(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::remainder( (*(decimal128*)x) , (*(decimal128*)y) );
}

void Lib_DReal_Remquo(DRealPtr res, const DRealPtr x, const DRealPtr y, int* e)
{
	(*(decimal128*)res) = boost::decimal::remquo( (*(decimal128*)x) , (*(decimal128*)y), e );
}




/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

void Lib_DReal_Epsilon(DRealPtr res)
{
	(*(decimal128*)res) = std::numeric_limits<decimal128>::epsilon();
}

void Lib_DReal_Max(DRealPtr res)
{
	(*(decimal128*)res) = std::numeric_limits<decimal128>::max();
}

void Lib_DReal_Min(DRealPtr res)
{
	(*(decimal128*)res) = std::numeric_limits<decimal128>::min();
}

void Lib_DReal_Lowest(DRealPtr res)
{
	(*(decimal128*)res) = std::numeric_limits<decimal128>::lowest();
}

void Lib_DReal_Nexttowards(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::nextafter( (*(decimal128*)x) , (*(decimal128*)y) );
}

void Lib_DReal_Nextabove(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::nextafter( (*(decimal128*)x) , std::numeric_limits<decimal128>::infinity() );
}

void Lib_DReal_Nextbelow(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::nextafter( (*(decimal128*)x) , -std::numeric_limits<decimal128>::infinity() );
}





/* Mathematical Constants  */

void Lib_DReal_ConstDegree(DRealPtr res)
{
	(*(decimal128*)res) = boost::decimal::numbers::pi_v<decimal128> / 180;
}

void Lib_DReal_ConstPhi(DRealPtr res)
{
	(*(decimal128*)res) = boost::decimal::numbers::phi_v<decimal128>;
}

void Lib_DReal_ConstLog2(DRealPtr res)
{
	(*(decimal128*)res) = boost::decimal::numbers::ln2_v<decimal128>;
}

void Lib_DReal_ConstLog10(DRealPtr res)
{
	(*(decimal128*)res) = boost::decimal::numbers::ln10_v<decimal128>;
}

void Lib_DReal_ConstPi(DRealPtr res)
{
	(*(decimal128*)res) = boost::decimal::numbers::pi_v<decimal128>;
}

void Lib_DReal_ConstE(DRealPtr res)
{
	(*(decimal128*)res) = boost::decimal::numbers::e_v<decimal128>;
}

void Lib_DReal_ConstEulerGamma(DRealPtr res)
{
	(*(decimal128*)res) = boost::decimal::numbers::egamma_v<decimal128>;
}

void Lib_DReal_ConstApery(DRealPtr res)
{
    const auto apery_128 {"1.2020569031595942853997381615114499914"_DL};
	(*(decimal128*)res) = apery_128;
}

void Lib_DReal_ConstCatalan(DRealPtr res)
{
    const auto catalan_128 {"0.91596559417721901505460351493238411094"_DL};
	(*(decimal128*)res) = catalan_128;
}

void Lib_DReal_ConstGlaisher(DRealPtr res)
{
    const auto glaisher_128 {"1.2824271291006226368753425688697917282"_DL};
	(*(decimal128*)res) = glaisher_128;
}

void Lib_DReal_ConstKhinchin(DRealPtr res)
{
    const auto khinchin_128 {"2.6854520010653064453097148354817956937"_DL};
	(*(decimal128*)res) = khinchin_128;
}






/* Complex components  */

void Lib_DReal_Fabs(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::fabs(*(decimal128*)x);
}

void Lib_DReal_Sign(DRealPtr res, const DRealPtr x)
{
    int temp = ((*(decimal128*)x > 0) - (*(decimal128*)x < 0));
	(*(decimal128*)res) = temp;
}





/* Roots and related functions  */


void Lib_DReal_Sqrt(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::sqrt(*(decimal128*)x);
}



void Lib_DReal_Rsqrt(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = 1 / boost::decimal::sqrt(*(decimal128*)x);
}


void Lib_DReal_Cbrt(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::cbrt(*(decimal128*)x);
}


void Lib_DReal_Root_Si(DRealPtr res, const DRealPtr x, const int32_t k_)
{
    decimal128 k = k_;
	(*(decimal128*)res) = boost::decimal::pow( (*(decimal128*)x) , (1) / k );
}




/* Exponential and related functions  */


void Lib_DReal_Exp(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::exp(*(decimal128*)x);
}


void Lib_DReal_Exp2(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::exp2(*(decimal128*)x);
}


void Lib_DReal_Exp10(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::exp( (*(decimal128*)x) * boost::decimal::numbers::ln10_v<decimal128> );
}


void Lib_DReal_Expm1(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::expm1(*(decimal128*)x);
}

void Lib_DReal_Exp2m1(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::expm1( (*(decimal128*)x) * boost::decimal::numbers::ln2_v<decimal128> );
}

void Lib_DReal_Exp10m1(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::expm1( (*(decimal128*)x) * boost::decimal::numbers::ln10_v<decimal128> );
}



/* Logarithms and related functions  */



void Lib_DReal_Log(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::log(*(decimal128*)x);
}


void Lib_DReal_Log2(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::log2(*(decimal128*)x);
}


void Lib_DReal_Log10(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::log10(*(decimal128*)x);
}


void Lib_DReal_Log1p(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::log1p(*(decimal128*)x);
}


void Lib_DReal_Log2p1(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::log1p(*(decimal128*)x) / boost::decimal::numbers::ln2_v<decimal128>;
}


void Lib_DReal_Log10p1(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::log1p(*(decimal128*)x) / boost::decimal::numbers::ln10_v<decimal128>;
}





/* Power functions  */



void Lib_DReal_Square(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (*(decimal128*)x) * (*(decimal128*)x);
}


void Lib_DReal_Cube(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (*(decimal128*)x) * (*(decimal128*)x) * (*(decimal128*)x);
}


void Lib_DReal_Hypot(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::hypot( (*(decimal128*)x) , (*(decimal128*)y) );
}


void Lib_DReal_Pow(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = pow( (*(decimal128*)x) , (*(decimal128*)y) );
}


// Powm1 from Boost


void Lib_DReal_Pow1p(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = exp(boost::decimal::log1p(*(decimal128*)x) * (*(decimal128*)y));
}


void Lib_DReal_Pow1pm1(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::expm1(boost::decimal::log1p(*(decimal128*)x) * (*(decimal128*)y));
}


void Lib_DReal_Pow_Si(DRealPtr res, const DRealPtr x, const int32_t k_)
{
    decimal128 k = k_;
	(*(decimal128*)res) = boost::decimal::pow( (*(decimal128*)x) , k );
}


void Lib_DReal_Compound_Si(DRealPtr res, const DRealPtr x, const int32_t k_)
{
    decimal128 k = k_;
	(*(decimal128*)res) = boost::decimal::pow( (1) + (*(decimal128*)x) , k );
}



/* Trigonometric functions  */




decimal128 cosm1(decimal128 x)
{
    decimal128 half  {5, -1};;
    //if (fabs(x) > 0.5)
    if (boost::decimal::fabs(x) > half)
    {
        return boost::decimal::cos(x) - 1;
    }
    else
    {
        decimal128 res = boost::decimal::sin((x)/2);
        return  -2 * res * res;
    }
}


void Lib_DReal_Cosm1(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = cosm1(*(decimal128*)x);
}



void Lib_DReal_Sin(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::sin(*(decimal128*)x);
}


void Lib_DReal_Cos(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::cos(*(decimal128*)x);
}


void Lib_DReal_Tan(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::tan(*(decimal128*)x);
}


void Lib_DReal_Csc(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (1) / boost::decimal::sin(*(decimal128*)x);
}


void Lib_DReal_Sec(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (1) / boost::decimal::cos(*(decimal128*)x);
}


void Lib_DReal_Cot(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (1) / boost::decimal::tan(*(decimal128*)x);
}




/* Hyperbolic functions  */


void Lib_DReal_Sinh(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::sinh(*(decimal128*)x);
}


void Lib_DReal_Cosh(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::cosh(*(decimal128*)x);
}


void Lib_DReal_Tanh(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::tanh(*(decimal128*)x);
}


void Lib_DReal_Csch(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (1) / boost::decimal::sinh(*(decimal128*)x);
}


void Lib_DReal_Sech(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (1) / boost::decimal::cosh(*(decimal128*)x);
}


void Lib_DReal_Coth(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = (1) / boost::decimal::tanh(*(decimal128*)x);
}



/* Inverse trigonometric functions  */


void Lib_DReal_Asin(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::asin(*(decimal128*)x);
}


void Lib_DReal_Acos(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::acos(*(decimal128*)x);
}


void Lib_DReal_Atan(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::atan(*(decimal128*)x);
}


void Lib_DReal_Atan2(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
	(*(decimal128*)res) = boost::decimal::atan2( (*(decimal128*)x) , (*(decimal128*)y) );
}


void Lib_DReal_Acsc(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::asin( (1) / (*(decimal128*)x) );
}


void Lib_DReal_Asec(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::acos( (1) / (*(decimal128*)x) );
}


void Lib_DReal_Acot(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::atan( (1) / (*(decimal128*)x) );
}




/* Inverse hyperbolic functions  */


void Lib_DReal_Asinh(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::asinh(*(decimal128*)x);
}


void Lib_DReal_Acosh(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::acosh(*(decimal128*)x);
}


void Lib_DReal_Atanh(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::atanh(*(decimal128*)x);
}


void Lib_DReal_Acsch(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::asinh( (1) / (*(decimal128*)x) );
}


void Lib_DReal_Asech(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::acosh( (1) / (*(decimal128*)x) );
}


void Lib_DReal_Acoth(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::atanh( (1) / (*(decimal128*)x) );
}



/* Special functions  */

void Lib_DReal_Erf(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::erf(*(decimal128*)x);
}

void Lib_DReal_Erfc(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::erfc(*(decimal128*)x);
}

void Lib_DReal_Tgamma(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::tgamma(*(decimal128*)x);
}

void Lib_DReal_Lgamma(DRealPtr res, const DRealPtr x)
{
	(*(decimal128*)res) = boost::decimal::lgamma(*(decimal128*)x);
}










//*********************** Complex **********************************


DCplxPtr Lib_DCplx_Init_Func()
{
	DCplxPtr x = NULL;
	x = (std::complex<decimal128>*) malloc(sizeof(std::complex<decimal128>));
	return x;
}


void Lib_DCplx_Clear(DCplxPtr x)
{
	free(x);
}




void Lib_DCplx_Get_Str_Real(char* cstr, DCplxPtr x)
{
    decimal128 d = (*(std::complex<decimal128>*) x).real();
    std::stringstream ss;
    ss.precision(std::numeric_limits<decimal128>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void Lib_DCplx_Get_Str_Imag(char* cstr, DCplxPtr x)
{
    decimal128 d = (*(std::complex<decimal128>*) x).imag();
    std::stringstream ss;
    ss.precision(std::numeric_limits<decimal128>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void Lib_DCplx_Neg(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = -(*(std::complex<decimal128>*) x);
}






void Lib_DCplx_Add(DCplxPtr res, const DCplxPtr x, const DCplxPtr y)
{
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) + (*(std::complex<decimal128>*) y);
}


void Lib_DCplx_Sub(DCplxPtr res, const DCplxPtr x, const DCplxPtr y)
{
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) - (*(std::complex<decimal128>*) y);
}


void Lib_DCplx_Mul(DCplxPtr res, const DCplxPtr x, const DCplxPtr y)
{
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) * (*(std::complex<decimal128>*) y);
}


void Lib_DCplx_Div(DCplxPtr res, const DCplxPtr x, const DCplxPtr y)
{
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) / (*(std::complex<decimal128>*) y);
}






void Lib_DCplx_Add_DReal(DCplxPtr res, const DCplxPtr x, const DRealPtr y)
{
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) + (*(decimal128*)y);
}



void Lib_DCplx_Sub_DReal(DCplxPtr res, const DCplxPtr x, const DRealPtr y)
{
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) - (*(decimal128*)y);
}


void Lib_DCplx_DReal_Sub(DCplxPtr res, const DCplxPtr y, const DRealPtr x)
{
	(*(std::complex<decimal128>*) res) =  (*(decimal128*)x) - (*(std::complex<decimal128>*) y);
}



void Lib_DCplx_Mul_DReal(DCplxPtr res, const DCplxPtr x, const DRealPtr y)
{
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) * (*(decimal128*)y);
}



void Lib_DCplx_Div_DReal(DCplxPtr res, const DCplxPtr x, const DRealPtr y)
{
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) / (*(decimal128*)y);
}


void Lib_DCplx_DReal_Div(DCplxPtr res, const DCplxPtr y, const DRealPtr x)
{
	(*(std::complex<decimal128>*) res) = (*(decimal128*)x) / (*(std::complex<decimal128>*) y);
}











void Lib_DCplx_Add_D(DCplxPtr res, const DCplxPtr x, const double y)
{
    decimal128 temp {y};
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) + temp;
}


void Lib_DCplx_Sub_D(DCplxPtr res, const DCplxPtr x, const double y)
{
    decimal128 temp {y};
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) - temp;
}


void Lib_DCplx_D_Sub(DCplxPtr res, const DCplxPtr y, const double x)
{
    decimal128 temp {x};
	(*(std::complex<decimal128>*) res) = temp - (*(std::complex<decimal128>*) y);
}


void Lib_DCplx_Mul_D(DCplxPtr res, const DCplxPtr x, const double y)
{
    decimal128 temp {y};
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) * temp;
}


void Lib_DCplx_Div_D(DCplxPtr res, const DCplxPtr x, const double y)
{
    decimal128 temp {y};
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) / temp;
}


void Lib_DCplx_D_Div(DCplxPtr res, const DCplxPtr y, const double x)
{
    decimal128 temp {x};
	(*(std::complex<decimal128>*) res) = temp / (*(std::complex<decimal128>*) y);
}













void Lib_DCplx_Add_Si(DCplxPtr res, const DCplxPtr x, const int32_t y)
{
    decimal128 temp = y;
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) + temp;
}


void Lib_DCplx_Sub_Si(DCplxPtr res, const DCplxPtr x, const int32_t y)
{
    decimal128 temp = y;
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) - temp;
}


void Lib_DCplx_Si_Sub(DCplxPtr res, const DCplxPtr y, const int32_t x)
{
    decimal128 temp = x;
	(*(std::complex<decimal128>*) res) = temp - (*(std::complex<decimal128>*) y);
}


void Lib_DCplx_Mul_Si(DCplxPtr res, const DCplxPtr x, const int32_t y)
{
    decimal128 temp = y;
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) * temp;
}


void Lib_DCplx_Div_Si(DCplxPtr res, const DCplxPtr x, const int32_t y)
{
    decimal128 temp = y;
	(*(std::complex<decimal128>*) res) = (*(std::complex<decimal128>*) x) / temp;
}


void Lib_DCplx_Si_Div(DCplxPtr res, const DCplxPtr y, const int32_t x)
{
    decimal128 temp = x;
	(*(std::complex<decimal128>*) res) = temp / (*(std::complex<decimal128>*) y);
}









/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */



void Lib_DCplx_Set(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res)  = (*(std::complex<decimal128>*) x);
}

void Lib_DCplx_Set_Real(DCplxPtr res, const DRealPtr re)
{
	(*(std::complex<decimal128>*) res) = std::complex<decimal128>(*(decimal128*)re, 0);
}

void Lib_DCplx_Set2(DCplxPtr res, const DRealPtr re, const DRealPtr im)
{
	(*(std::complex<decimal128>*) res) = std::complex<decimal128>(*(decimal128*)re, *(decimal128*)im);
}

void Lib_DCplx_Set2_Str2(DRealPtr res, const char * str_re, const char * str_im)
{
//    decimal128 re = static_cast<decimal128>(string(str_re));
//    decimal128 im = static_cast<decimal128>(string(str_im));
//	(*(std::complex<decimal128>*) res) = std::complex<decimal128>(re, im);
}


void Lib_DCplx_Abs(DRealPtr res, const DCplxPtr x)
{
	*(decimal128*)res = std::abs(*(std::complex<decimal128>*) x);
}

void Lib_DCplx_Arg(DRealPtr res, const DCplxPtr x)
{
	*(decimal128*)res = std::arg(*(std::complex<decimal128>*) x);
}

void Lib_DCplx_Imag(DRealPtr res, const DCplxPtr x)
{
	*(decimal128*)res = (*(std::complex<decimal128>*) x).imag();
}

void Lib_DCplx_Real(DRealPtr res, const DCplxPtr x)
{
	*(decimal128*)res = (*(std::complex<decimal128>*) x).real();
}


void Lib_DCplx_Conj(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::conj(*(std::complex<decimal128>*) x);
}

void Lib_DCplx_Proj(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::proj(*(std::complex<decimal128>*) x);
}






/* Roots  */



std::complex<decimal128> cplx_expm1(std::complex<decimal128> z)
{
    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
	decimal128 x = z.real();
	decimal128 y = z.imag();
	decimal128 resx =  boost::decimal::expm1(x) * boost::decimal::cos(y) + cosm1(y);
	decimal128 resy =  boost::decimal::exp(x) * boost::decimal::sin(y);
	return std::complex<decimal128>(resx, resy);
}




std::complex<decimal128> cplx_log1p(std::complex<decimal128> z)
{
    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
    /* resy =  atan2(y, 1 + x); */
    decimal128 Half {0.5};
    decimal128 HalfPQ {0.75};
	decimal128 x = z.real();
	decimal128 y = z.imag();
	decimal128 resx {0.0} ;
	if ( (boost::decimal::fabs(x) > HalfPQ) || (boost::decimal::fabs(y) > HalfPQ) || (x < -Half) )
    {
        resx = boost::decimal::log(boost::decimal::hypot(1 + x, y)) ;
    }
    else
    {
        resx = Half * boost::decimal::log1p(2*x + x*x + y*y);
    }
	decimal128 resy = boost::decimal::atan2(y, 1 + x); ;
	return std::complex<decimal128>(resx, resy);
}




void Lib_DCplx_Sqrt(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::sqrt(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Sqrt1pm1(DCplxPtr res, const DCplxPtr x)
{
    decimal128 Half {0.5};
    (*(std::complex<decimal128>*) res) = cplx_expm1(cplx_log1p(*(std::complex<decimal128>*) x) * Half);
}


void Lib_DCplx_Rsqrt(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) =One / std::sqrt(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Cbrt(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
    decimal128 Three = 3;
    decimal128 r = One / Three;
	(*(std::complex<decimal128>*) res) = std::pow(*(std::complex<decimal128>*) x, r);
}


void Lib_DCplx_Root_Si(DCplxPtr res, const DCplxPtr x, const int32_t k)
{
    decimal128 One = 1;
    decimal128 k_ = k;
    decimal128 r = One / k_;
	(*(std::complex<decimal128>*) res) = std::pow(*(std::complex<decimal128>*) x, r);
}





/* Exponential and related functions  */


void Lib_DCplx_Exp(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::exp(*(std::complex<decimal128>*) x);
}

void Lib_DCplx_Exp2(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::exp( (*(std::complex<decimal128>*) x)
                                                     * boost::decimal::numbers::ln2_v<decimal128> );
}

void Lib_DCplx_Exp10(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::exp( (*(std::complex<decimal128>*) x)
                                                     * boost::decimal::numbers::ln10_v<decimal128> );
}



void Lib_DCplx_Expm1(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = cplx_expm1(*(std::complex<decimal128>*) x);
}

void Lib_DCplx_Exp2m1(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = cplx_expm1( (*(std::complex<decimal128>*) x)
                                                     * boost::decimal::numbers::ln2_v<decimal128> );
}

void Lib_DCplx_Exp10m1(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = cplx_expm1( (*(std::complex<decimal128>*) x)
                                                     * boost::decimal::numbers::ln10_v<decimal128> );
}






/* Logarithms and related functions  */


void Lib_DCplx_Log(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::log(*(std::complex<decimal128>*) x);
}

void Lib_DCplx_Log2(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::log(*(std::complex<decimal128>*) x)
                                                    / boost::decimal::numbers::ln2_v<decimal128>;
}

void Lib_DCplx_Log10(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::log10(*(std::complex<decimal128>*) x)
                                                    / boost::decimal::numbers::ln10_v<decimal128>;
}


void Lib_DCplx_Log1p(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = cplx_log1p(*(std::complex<decimal128>*) x);
}

void Lib_DCplx_Log2p1(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = cplx_log1p(*(std::complex<decimal128>*) x)
                                                    / boost::decimal::numbers::ln2_v<decimal128>;
}

void Lib_DCplx_Log10p1(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = cplx_log1p(*(std::complex<decimal128>*) x)
                                                    / boost::decimal::numbers::ln10_v<decimal128>;
}





/* Power functions */


void Lib_DCplx_Square(DCplxPtr res, const DCplxPtr x)
{
    std::complex<decimal128> z = *(std::complex<decimal128>*) x;
	(*(std::complex<decimal128>*) res) =  z * z;
}


void Lib_DCplx_Cube(DCplxPtr res, const DCplxPtr x)
{
    std::complex<decimal128> z = *(std::complex<decimal128>*) x;
	(*(std::complex<decimal128>*) res) =  z * z * z;
}


void Lib_DCplx_Pow(DCplxPtr res, const DCplxPtr x, const DCplxPtr y)
{
	(*(std::complex<decimal128>*) res) = std::pow(*(std::complex<decimal128>*) x,
                                                 *(std::complex<decimal128>*) y);
}



void Lib_DCplx_Powm1(DCplxPtr res, const DCplxPtr x, const DCplxPtr y)
{
    (*(std::complex<decimal128>*) res) = cplx_expm1(std::log(*(std::complex<decimal128>*) x)
                                                           * (*(std::complex<decimal128>*) y));
}

void Lib_DCplx_Pow1p(DCplxPtr res, const DCplxPtr x, const DCplxPtr y)
{
    (*(std::complex<decimal128>*) res) = std::exp(cplx_log1p(*(std::complex<decimal128>*) x)
                                                         * (*(std::complex<decimal128>*) y));
}

void Lib_DCplx_Pow1pm1(DCplxPtr res, const DCplxPtr x, const DCplxPtr y)
{
    (*(std::complex<decimal128>*) res) = cplx_expm1(cplx_log1p(*(std::complex<decimal128>*) x)
                                                           * (*(std::complex<decimal128>*) y));
}




void Lib_DCplx_Pow_Si(DCplxPtr res, const DCplxPtr x, const int32_t k)
{
    decimal128 k_ = k;
	(*(std::complex<decimal128>*) res) = std::pow(*(std::complex<decimal128>*) x, k_);
}


void Lib_DCplx_Compound_Si(DCplxPtr res, const DCplxPtr x, const int32_t k)
{
    decimal128 One = 1;
    decimal128 k_ = k;
	(*(std::complex<decimal128>*) res) = std::pow(One + (*(std::complex<decimal128>*) x), k_);
}






/* Trigonometric functions  */


void Lib_DCplx_Sin(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::sin(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Cos(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::cos(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Tan(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::tan(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Csc(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = One / std::sin(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Sec(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = One /  std::cos(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Cot(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = One /  std::tan(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_SinPi(DCplxPtr res, const DCplxPtr x)
{
    // See mpfunlab/mathgp.py, lines 234 - 301

	//(*(std::complex<decimal128>*) res) = std::sin(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_CosPi(DCplxPtr res, const DCplxPtr x)
{
	//(*(std::complex<decimal128>*) res) = std::cos(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_TanPi(DCplxPtr res, const DCplxPtr x)
{
	//(*(std::complex<decimal128>*) res) = std::tan(*(std::complex<decimal128>*) x);
}





/* Hyperbolic functions  */


void Lib_DCplx_Sinh(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::sinh(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Cosh(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::cosh(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Tanh(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::tanh(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Csch(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = One / std::sinh(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Sech(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = One /  std::cosh(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Coth(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = One /  std::tanh(*(std::complex<decimal128>*) x);
}





/* Inverse trigonometric functions  */


void Lib_DCplx_Asin(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::asin(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Acos(DCplxPtr res, const DCplxPtr x)
{
    // see mpfunlab manual p. 357 relation to acosh

//	(*(std::complex<decimal128>*) res) = std::acos(*(std::complex<decimal128>*) x); // compiler error
}


void Lib_DCplx_Atan(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::atan(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Acsc(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = std::asin(One / (*(std::complex<decimal128>*) x));
}


//void Lib_DCplx_Asec(DCplxPtr res, const DCplxPtr x)
//{
//    decimal128 One = 1;
//	(*(std::complex<decimal128>*) res) = std::acos(One / (*(std::complex<decimal128>*) x)); // compiler error
//}


void Lib_DCplx_Acot(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = std::atan(One / (*(std::complex<decimal128>*) x));
}






/* Inverse hyperbolic functions  */


void Lib_DCplx_Asinh(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::asinh(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Acosh(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::acosh(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Atanh(DCplxPtr res, const DCplxPtr x)
{
	(*(std::complex<decimal128>*) res) = std::atanh(*(std::complex<decimal128>*) x);
}


void Lib_DCplx_Acsch(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = std::asinh(One / (*(std::complex<decimal128>*) x));
}


void Lib_DCplx_Asech(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = std::acosh(One / (*(std::complex<decimal128>*) x));
}


void Lib_DCplx_Acoth(DCplxPtr res, const DCplxPtr x)
{
    decimal128 One = 1;
	(*(std::complex<decimal128>*) res) = std::atanh(One / (*(std::complex<decimal128>*) x));
}














//*********************** Boost Special functions , DReal **********************************



void Lib_DReal_BernoulliB2n(DRealPtr res, const int n)
{
    LibDReal_BernoulliB2n(res, n);
}



void Lib_DReal_TangentT2n(DRealPtr res, const int n)
{
    LibDReal_TangentT2n(res, n);
}



void Lib_DReal_Sqrt1pm1_Boost(DRealPtr res, const DRealPtr x)
{
    LibDReal_Sqrt1pm1(res, x);
}



void Lib_DReal_SinPi_Boost(DRealPtr res, const DRealPtr x)
{
    LibDReal_SinPi(res, x);
}



void Lib_DReal_CosPi_Boost(DRealPtr res, const DRealPtr x)
{
    LibDReal_CosPi(res, x);
}



void Lib_DReal_SincPi(DRealPtr res, const DRealPtr x)
{
    LibDReal_SincPi(res, x);
}



void Lib_DReal_SinhcPi(DRealPtr res, const DRealPtr x)
{
    LibDReal_SinhcPi(res, x);
}



void Lib_DReal_Tgamma_(DRealPtr res, const DRealPtr x)
{
    LibDReal_Tgamma_(res, x);
}


void Lib_DReal_Tgamma1pm1(DRealPtr res, const DRealPtr x)
{
    LibDReal_Tgamma1pm1(res, x);
}



void Lib_DReal_Lgamma_(DRealPtr res, const DRealPtr x)
{
    LibDReal_Lgamma_(res, x);
}



void Lib_DReal_Digamma(DRealPtr res, const DRealPtr x)
{
    LibDReal_Digamma(res, x);
}



void Lib_DReal_Trigamma(DRealPtr res, const DRealPtr x)
{
    LibDReal_Trigamma(res, x);
}



void Lib_DReal_Factorial(DRealPtr res, const DRealPtr x)
{
    LibDReal_Factorial(res, x);
}



void Lib_DReal_DoubleFactorial(DRealPtr res, const DRealPtr x)
{
    LibDReal_DoubleFactorial(res, x);
}





void Lib_DReal_Erf_(DRealPtr res, const DRealPtr x)
{
    LibDReal_Erf_(res, x);
}



void Lib_DReal_Erfc_(DRealPtr res, const DRealPtr x)
{
    LibDReal_Erfc_(res, x);
}



void Lib_DReal_Erf_inv(DRealPtr res, const DRealPtr x)
{
    LibDReal_Erf_inv(res, x);
}



void Lib_DReal_Erfc_inv(DRealPtr res, const DRealPtr x)
{
    LibDReal_Erfc_inv(res, x);
}



void Lib_DReal_AiryAi(DRealPtr res, const DRealPtr x)
{
    LibDReal_AiryAi(res, x);
}



void Lib_DReal_AiryBi(DRealPtr res, const DRealPtr x)
{
    LibDReal_AiryBi(res, x);
}



void Lib_DReal_AiryAiPrime(DRealPtr res, const DRealPtr x)
{
    LibDReal_AiryAiPrime(res, x);
}



void Lib_DReal_AiryBiPrime(DRealPtr res, const DRealPtr x)
{
    LibDReal_AiryBiPrime(res, x);
}



void Lib_DReal_Aizero(DRealPtr res, const int n)
{
    LibDReal_Aizero(res, n);
}



void Lib_DReal_Bizero(DRealPtr res, const int n)
{
    LibDReal_Bizero(res, n);
}



void Lib_DReal_Ellint_1_K(DRealPtr res, const DRealPtr x)
{
    LibDReal_Ellint_1_K(res, x);
}



void Lib_DReal_Ellint_2_K(DRealPtr res, const DRealPtr x)
{
    LibDReal_Ellint_2_K(res, x);
}



void Lib_DReal_Zeta(DRealPtr res, const DRealPtr x)
{
    LibDReal_Zeta(res, x);
}



void Lib_DReal_Ei(DRealPtr res, const DRealPtr x)
{
    LibDReal_Ei(res, x);
}



void Lib_DReal_LambertW0(DRealPtr res, const DRealPtr x)
{
    LibDReal_LambertW0(res, x);
}


void Lib_DReal_LambertWm1(DRealPtr res, const DRealPtr x)
{
    LibDReal_LambertWm1(res, x);
}



void Lib_DReal_LambertW0Prime(DRealPtr res, const DRealPtr x)
{
    LibDReal_LambertW0Prime(res, x);
}


void Lib_DReal_LambertWm1Prime(DRealPtr res, const DRealPtr x)
{
    LibDReal_LambertWm1Prime(res, x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void Lib_DReal_Powm1_Boost(DRealPtr res, const DRealPtr a, const DRealPtr b)
{
    LibDReal_Powm1(res, a, b);
}



void Lib_DReal_TgammaRatio(DRealPtr res, const DRealPtr a, const DRealPtr b)
{
    LibDReal_TgammaRatio(res, a, b);
}



void Lib_DReal_TgammaDeltaRatio(DRealPtr res, const DRealPtr a, const DRealPtr b)
{
    LibDReal_TgammaDeltaRatio(res, a, b);
}



void Lib_DReal_Binomial(DRealPtr res, const DRealPtr n, const DRealPtr k)
{
    LibDReal_Binomial(res, n, k);
}

void Lib_DReal_RisingFactorial(DRealPtr res, const DRealPtr x, const DRealPtr n)
{
    LibDReal_RisingFactorial(res, x, n);
}




void Lib_DReal_FallingFactorial(DRealPtr res, const DRealPtr x, const DRealPtr n)
{
    LibDReal_FallingFactorial(res, x, n);
}




void Lib_DReal_BesselJ(DRealPtr res, const DRealPtr v, const DRealPtr x)
{
    LibDReal_BesselJ(res, v, x);
}



void Lib_DReal_BesselY(DRealPtr res, const DRealPtr v, const DRealPtr x)
{
    LibDReal_BesselY(res, v, x);
}



void Lib_DReal_BesselI(DRealPtr res, const DRealPtr v, const DRealPtr x)
{
    LibDReal_BesselI(res, v, x);
}



void Lib_DReal_BesselK(DRealPtr res, const DRealPtr v, const DRealPtr x)
{
    LibDReal_BesselK(res, v, x);
}



void Lib_DReal_SphBessel(DRealPtr res, const unsigned v, const DRealPtr x)
{
    LibDReal_SphBessel(res, v, x);
}



void Lib_DReal_SphNeumann(DRealPtr res, const unsigned v, const DRealPtr x)
{
    LibDReal_SphNeumann(res, v, x);
}





void Lib_DReal_BesselJPrime(DRealPtr res, const DRealPtr v, const DRealPtr x)
{
    LibDReal_BesselJPrime(res, v, x);
}



void Lib_DReal_BesselYPrime(DRealPtr res, const DRealPtr v, const DRealPtr x)
{
    LibDReal_BesselYPrime(res, v, x);
}



void Lib_DReal_BesselIPrime(DRealPtr res, const DRealPtr v, const DRealPtr x)
{
    LibDReal_BesselIPrime(res, v, x);
}



void Lib_DReal_BesselKPrime(DRealPtr res, const DRealPtr v, const DRealPtr x)
{
    LibDReal_BesselKPrime(res, v, x);
}



void Lib_DReal_SphBesselPrime(DRealPtr res, const unsigned v, const DRealPtr x)
{
    LibDReal_SphBesselPrime(res, v, x);
}



void Lib_DReal_SphNeumannPrime(DRealPtr res, const unsigned v, const DRealPtr x)
{
    LibDReal_SphNeumannPrime(res, v, x);
}





void Lib_DReal_BesselJZero(DRealPtr res, const DRealPtr v, const int m)
{
    LibDReal_BesselJZero(res, v, m);
}



void Lib_DReal_BesselYZero(DRealPtr res, const DRealPtr v, const int m)
{
    LibDReal_BesselYZero(res, v, m);
}





void Lib_DReal_GammaP(DRealPtr res, const DRealPtr a, const DRealPtr x)
{
    LibDReal_GammaP(res, a, x);
}


void Lib_DReal_GammaQ(DRealPtr res, const DRealPtr a, const DRealPtr x)
{
    LibDReal_GammaQ(res, a, x);
}


void Lib_DReal_TgammaLower(DRealPtr res, const DRealPtr a, const DRealPtr x)
{
    LibDReal_TgammaLower(res, a, x);
}


void Lib_DReal_TgammaUpper(DRealPtr res, const DRealPtr a, const DRealPtr x)
{
    LibDReal_TgammaUpper(res, a, x);
}




void Lib_DReal_GammaPInv(DRealPtr res, const DRealPtr a, const DRealPtr p)
{
    LibDReal_GammaPInv(res, a, p);
}


void Lib_DReal_GammaQInv(DRealPtr res, const DRealPtr a, const DRealPtr q)
{
    LibDReal_GammaQInv(res, a, q);
}


void Lib_DReal_GammaPInva(DRealPtr res, const DRealPtr x, const DRealPtr p)
{
    LibDReal_GammaPInva(res, x, p);
}


void Lib_DReal_GammaQInva(DRealPtr res, const DRealPtr x, const DRealPtr q)
{
    LibDReal_GammaQInva(res, x, q);
}



void Lib_DReal_GammaPDerivative(DRealPtr res, const DRealPtr a, const DRealPtr x)
{
    LibDReal_GammaPDerivative(res, a, x);
}


void Lib_DReal_Beta(DRealPtr res, const DRealPtr a, const DRealPtr b)
{
    LibDReal_Beta(res, a, b);
}









void Lib_DReal_LegendreP(DRealPtr res, int n, const DRealPtr x)
{
    LibDReal_LegendreP(res, n, x);
}



void Lib_DReal_LegendreQ(DRealPtr res, int n, const DRealPtr x)
{
    LibDReal_LegendreQ(res, n, x);
}



void Lib_DReal_Laguerre(DRealPtr res, int n, const DRealPtr x)
{
    LibDReal_Laguerre(res, n, x);
}



void Lib_DReal_Hermite(DRealPtr res, int n, const DRealPtr x)
{
    LibDReal_Hermite(res, n, x);
}



void Lib_DReal_ChebyshevT(DRealPtr res, int n, const DRealPtr x)
{
    LibDReal_ChebyshevT(res, n, x);
}


void Lib_DReal_ChebyshevU(DRealPtr res, int n, const DRealPtr x)
{
    LibDReal_ChebyshevU(res, n, x);
}



void Lib_DReal_Polygamma(DRealPtr res, int n, const DRealPtr x)
{
    LibDReal_Polygamma(res, n, x);
}





void Lib_DReal_EllintRC(DRealPtr res, const DRealPtr x, const DRealPtr y)
{
    LibDReal_EllintRC(res, x, y);
}


void Lib_DReal_Ellint1F(DRealPtr res, const DRealPtr k, const DRealPtr phi)
{
    LibDReal_Ellint1F(res, k, phi);
}


void Lib_DReal_Ellint2F(DRealPtr res, const DRealPtr k, const DRealPtr phi)
{
    LibDReal_Ellint2F(res, k, phi);
}


void Lib_DReal_Ellint3K(DRealPtr res, const DRealPtr k, const DRealPtr n)
{
    LibDReal_Ellint3K(res, k, n);
}




void Lib_DReal_JacobiCD(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiCD(res, k, u);
}


void Lib_DReal_JacobiCN(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiCN(res, k, u);
}


void Lib_DReal_JacobiCS(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiCS(res, k, u);
}


void Lib_DReal_JacobiDC(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiDC(res, k, u);
}


void Lib_DReal_JacobiDN(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiDN(res, k, u);
}


void Lib_DReal_JacobiDS(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiDS(res, k, u);
}


void Lib_DReal_JacobiNC(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiNC(res, k, u);
}


void Lib_DReal_JacobiND(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiND(res, k, u);
}


void Lib_DReal_JacobiNS(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiNS(res, k, u);
}


void Lib_DReal_JacobiSC(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiSC(res, k, u);
}


void Lib_DReal_JacobiSD(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiSD(res, k, u);
}


void Lib_DReal_JacobiSN(DRealPtr res, const DRealPtr k, const DRealPtr u)
{
    LibDReal_JacobiSN(res, k, u);
}



void Lib_DReal_expint(DRealPtr res, const unsigned n, const DRealPtr x)
{
    LibDReal_expint(res, n, x);
}




void Lib_DReal_OwenT(DRealPtr res, const DRealPtr h, const DRealPtr a)
{
    LibDReal_OwenT(res, h, a);
}





void Lib_DReal_IBeta(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr x)
{
    LibDReal_IBeta(res, a, b, x);
}


void Lib_DReal_IBetac(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr x)
{
    LibDReal_IBetac(res, a, b, x);
}


void Lib_DReal_IBetaNonNormalized(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr x)
{
    LibDReal_IBetaNonNormalized(res, a, b, x);
}


void Lib_DReal_IBetacNonNormalized(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr x)
{
    LibDReal_IBetacNonNormalized(res, a, b, x);
}


void Lib_DReal_IBetaInv(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr p)
{
    LibDReal_IBetaInv(res, a, b, p);
}


void Lib_DReal_IBetacInv(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr q)
{
    LibDReal_IBetacInv(res, a, b, q);
}


void Lib_DReal_IBetaInva(DRealPtr res, const DRealPtr b, const DRealPtr x, const DRealPtr p)
{
    LibDReal_IBetaInva(res, b, x, p);
}


void Lib_DReal_IBetacInva(DRealPtr res, const DRealPtr b, const DRealPtr x, const DRealPtr q)
{
    LibDReal_IBetacInva(res, b, x, q);
}


void Lib_DReal_IBetaInvb(DRealPtr res, const DRealPtr a, const DRealPtr x, const DRealPtr p)
{
    LibDReal_IBetaInvb(res, a, x, p);
}


void Lib_DReal_IBetacInvb(DRealPtr res, const DRealPtr a, const DRealPtr x, const DRealPtr q)
{
    LibDReal_IBetacInvb(res, a, x, q);
}


void Lib_DReal_IBetaDerivative(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr x)
{
    LibDReal_IBetaDerivative(res, a, b, x);
}




void Lib_DReal_LegendrePM(DRealPtr res, const int n, const int m, const DRealPtr x)
{
    LibDReal_LegendrePM(res, n, m, x);
}



void Lib_DReal_LaguerreM(DRealPtr res, const int n, const int m, const DRealPtr x)
{
    LibDReal_LaguerreM(res, n, m, x);
}





void Lib_DReal_EllipticRF(DRealPtr res, const DRealPtr x, const DRealPtr y, const DRealPtr z)
{
    LibDReal_EllipticRF(res, x, y, z);
}



void Lib_DReal_EllipticRD(DRealPtr res, const DRealPtr x, const DRealPtr y, const DRealPtr z)
{
    LibDReal_EllipticRD(res, x, y, z);
}



void Lib_DReal_Ellint3F(DRealPtr res, const DRealPtr k, const DRealPtr n, const DRealPtr phi)
{
    LibDReal_Ellint3F(res, k, n, phi);
}




void Lib_DReal_SphericalHarmonicR(DRealPtr res, const int n, const int m, const DRealPtr theta, const DRealPtr phi)
{
    LibDReal_SphericalHarmonicR(res, n, m, theta, phi);
}


void Lib_DReal_SphericalHarmonicI(DRealPtr res, const int n, const int m, const DRealPtr theta, const DRealPtr phi)
{
    LibDReal_SphericalHarmonicI(res, n, m, theta, phi);
}


void Lib_DReal_EllipticRJ(DRealPtr res, const DRealPtr x, const DRealPtr y, const DRealPtr z, const DRealPtr p)
{
    LibDReal_EllipticRJ(res, x, y, z, p);
}


// Hypergeometric and Theta Functions




void Lib_DReal_Hypergeo0F1(DRealPtr res, const DRealPtr b, const DRealPtr x)
{
    LibDReal_Hypergeo0F1(res, b, x);
}



void Lib_DReal_Hypergeo1F1(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr x)
{
    LibDReal_Hypergeo1F1(res, a, b, x);
}



void Lib_DReal_Hypergeo1F1r(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr x)
{
    LibDReal_Hypergeo1F1r(res, a, b, x);
}



void Lib_DReal_LogHypergeo1F1(DRealPtr res, const DRealPtr a, const DRealPtr b, const DRealPtr x)
{
    LibDReal_LogHypergeo1F1(res, a, b, x);
}





void Lib_DReal_JacobiTheta1(DRealPtr res, const DRealPtr x, const DRealPtr q)
{
    LibDReal_JacobiTheta1(res, x, q);
}


void Lib_DReal_JacobiTheta2(DRealPtr res, const DRealPtr x, const DRealPtr q)
{
    LibDReal_JacobiTheta2(res, x, q);
}


void Lib_DReal_JacobiTheta3(DRealPtr res, const DRealPtr x, const DRealPtr q)
{
    LibDReal_JacobiTheta3(res, x, q);
}


void Lib_DReal_JacobiTheta4(DRealPtr res, const DRealPtr x, const DRealPtr q)
{
    LibDReal_JacobiTheta4(res, x, q);
}






//***********************  Boost Distributions, DReal  **********************************


void Lib_DReal_ArcsineDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr a, DRealPtr b)
{
    LibDReal_ArcsineDist(Target, res, xqp, a, b);
}



void Lib_DReal_BernoulliDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr p)
{
    LibDReal_BernoulliDist(Target, res, xqp, p);
}



void Lib_DReal_BetaDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr a, DRealPtr b)
{
    LibDReal_BetaDist(Target, res, xqp, a, b);
}



void Lib_DReal_BinomialDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr n, DRealPtr p)
{
    LibDReal_BinomialDist(Target, res, xqp, n, p);
}



void Lib_DReal_CauchyDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr location, DRealPtr scale)
{
    LibDReal_CauchyDist(Target, res, xqp, location, scale);
}



void Lib_DReal_Chi2Dist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr nu)
{
    LibDReal_Chi2Dist(Target, res, xqp, nu);
}



void Lib_DReal_ExponentialDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr lambda)
{
    LibDReal_ExponentialDist(Target, res, xqp, lambda);
}



void Lib_DReal_ExtremeValueDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr location, DRealPtr scale)
{
    LibDReal_ExtremeValueDist(Target, res, xqp, location, scale);
}



void Lib_DReal_FisherFDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr mu, DRealPtr nu)
{
    LibDReal_FisherFDist(Target, res, xqp, mu, nu);
}



void Lib_DReal_GammaDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr shape, DRealPtr scale)
{
    LibDReal_GammaDist(Target, res, xqp, shape, scale);
}



void Lib_DReal_GeometricDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr p)
{
    LibDReal_GeometricDist(Target, res, xqp, p);
}



void Lib_DReal_HypergeometricDist(long Target, DRealPtr res, DRealPtr xqp, unsigned r, unsigned n, unsigned N)
{
    LibDReal_HypergeometricDist(Target, res, xqp, r, n, N);
}



void Lib_DReal_InverseChi2Dist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr df, DRealPtr scale)
{
    LibDReal_InverseChi2Dist(Target, res, xqp, df, scale);
}



void Lib_DReal_InverseGammaDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr shape, DRealPtr scale)
{
    LibDReal_InverseGammaDist(Target, res, xqp, shape, scale);
}



void Lib_DReal_WaldDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr mean_, DRealPtr scale)
{
    LibDReal_InverseGaussianDist(Target, res, xqp, mean_, scale);
}



void Lib_DReal_LaplaceDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr location, DRealPtr scale)
{
    LibDReal_LaplaceDist(Target, res, xqp, location, scale);
}



void Lib_DReal_LogisticDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr location, DRealPtr scale)
{
    LibDReal_LogisticDist(Target, res, xqp, location, scale);
}



void Lib_DReal_LognormalDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr location, DRealPtr scale)
{
    LibDReal_LognormalDist(Target, res, xqp, location, scale);
}



void Lib_DReal_NegBinomialDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr n, DRealPtr p)
{
    LibDReal_NegBinomialDist(Target, res, xqp, n, p);
}


void Lib_DReal_Chi2NcDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr nu, DRealPtr nc)
{
    LibDReal_Chi2NCDist(Target, res, xqp, nu, nc);
}


void Lib_DReal_StudentTNcDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr nu, DRealPtr delta)
{
    LibDReal_StudentTNCDist(Target, res, xqp, nu, delta);
}



void Lib_DReal_FisherNcDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr mu, DRealPtr nu, DRealPtr nc)
{
    LibDReal_FisherNCDist(Target, res, xqp, mu, nu, nc);
}



void Lib_DReal_BetaNcDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr a, DRealPtr b, DRealPtr nc)
{
    LibDReal_BetaNCDist(Target, res, xqp, a, b, nc);
}



void Lib_DReal_NormalDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr mean_, DRealPtr stdev)
{
    LibDReal_NormalDist(Target, res, xqp, mean_, stdev);
}



void Lib_DReal_ParetoDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr shape, DRealPtr scale)
{
    LibDReal_ParetoDist(Target, res, xqp, shape, scale);
}



void Lib_DReal_PoissonDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr nu)
{
    LibDReal_PoissonDist(Target, res, xqp, nu);
}



void Lib_DReal_RayleighDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr nu)
{
    LibDReal_RayleighDist(Target, res, xqp, nu);
}



void Lib_DReal_SkewNormalDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr mean_, DRealPtr scale, DRealPtr shape)
{
    LibDReal_SkewNormalDist(Target, res, xqp, mean_, scale, shape);
}



void Lib_DReal_StudentTDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr nu)
{
    LibDReal_StudentTDist(Target, res, xqp, nu);
}



void Lib_DReal_TriangularDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr lower, DRealPtr mode_, DRealPtr upper)
{
    LibDReal_TriangularDist(Target, res, xqp, lower, mode_, upper);
}



void Lib_DReal_WeibullDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr shape, DRealPtr scale)
{
    LibDReal_WeibullDist(Target, res, xqp, shape, scale);
}



void Lib_DReal_UniformDist(long Target, DRealPtr res, DRealPtr xqp, DRealPtr lower, DRealPtr upper)
{
    LibDReal_UniformDist(Target, res, xqp, lower, upper);
}





//*********************** Boost Numerical Calculus, DReal **********************************




void Lib_DReal_BracketRoot(DRealPtr res1, DRealPtr res2, int* iter, DRealFuncPtr f1, DRealPtr guess_, DRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    LibDReal_BracketRoot(res1, res2, iter, f1, guess_, factor_, is_rising, get_digits, maxit);
}



void Lib_DReal_NewtonRaphson(DRealPtr res,  int* iter, DRealFuncPtr f1, DRealFuncPtr f2, DRealPtr guess_, DRealPtr xmin_, DRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibDReal_NewtonRaphson(res, iter, f1, f2, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_DReal_Halley(DRealPtr res, int* iter, DRealFuncPtr f1, DRealFuncPtr f2, DRealFuncPtr f3, DRealPtr guess_, DRealPtr xmin_, DRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibDReal_Halley(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_DReal_Schroder(DRealPtr res, int* iter, DRealFuncPtr f1, DRealFuncPtr f2, DRealFuncPtr f3, DRealPtr guess_, DRealPtr xmin_, DRealPtr xmax_, int get_digits, unsigned int maxit)
{
    LibDReal_Schroder(res, iter, f1, f2, f3, guess_, xmin_, xmax_, get_digits, maxit);
}



void Lib_DReal_Brent_Minimum(DRealPtr res, DRealPtr resFx, int* iter, DRealFuncPtr f1, DRealPtr bracket_min_, DRealPtr bracket_max_, int bits, unsigned int maxit)
{
    LibDReal_Brent_Minimum(res, resFx, iter, f1, bracket_min_, bracket_max_, bits, maxit);
}





void Lib_DReal_Trapezoidal(DRealPtr res1, DRealPtr res2, DRealPtr res3, DRealFuncPtr f1, DRealPtr a_, DRealPtr b_)
{
    LibDReal_Trapezoidal(res1, res2, res3, f1, a_, b_);
}



// 7, 15, 20, 25 and 30

void Lib_DReal_GaussLegendre(DRealPtr res1, DRealPtr res3, DRealFuncPtr f1, DRealPtr a_, DRealPtr b_)
{
    LibDReal_GaussLegendre(res1, res3, f1, a_, b_);
}



//15, 31, 41, 51 and 61

void Lib_DReal_GaussKronrod(DRealPtr res1, DRealPtr res2, DRealPtr res3, DRealFuncPtr f1, DRealPtr a_, DRealPtr b_)
{
    LibDReal_GaussKronrod(res1, res2, res3, f1, a_, b_);
}



void Lib_DReal_TanhSinh(DRealPtr res1, DRealPtr res2, DRealPtr res3, int* levels_, DRealFuncPtr f1, DRealPtr a_, DRealPtr b_)
{
    LibDReal_TanhSinh(res1, res2, res3, levels_, f1, a_, b_);
}




void Lib_DReal_SinhSinh(DRealPtr res1, DRealPtr res2, DRealPtr res3, int* levels_, DRealFuncPtr f1)
{
    LibDReal_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_DReal_ExpSinh(DRealPtr res1, DRealPtr res2, DRealPtr res3, int* levels_, DRealFuncPtr f1)
{
    LibDReal_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_DReal_Ooura_Cos(DRealPtr res1, DRealPtr res2, DRealFuncPtr f1)
{
    LibDReal_Ooura_Cos(res1, res2, f1);
}



void Lib_DReal_Ooura_Sin(DRealPtr res1, DRealPtr res2, DRealFuncPtr f1)
{
    LibDReal_Ooura_Sin(res1, res2, f1);
}









//*********************** Boost Odeint **********************************


AnyPtr Lib_DReal_StateInit_Func_N(int N)
{
    return LibDReal_StateInit_Func_N(N);
}


void Lib_DReal_StateClear(mpNumMatrixPtr x)
{
    return LibDReal_StateClear((DStatePtr) x);
}


void Lib_DReal_StateGetCoeff(ScalarPtr res, long row, mpNumMatrixPtr source)
{
    LibDReal_StateGetCoeff((DRealPtr) res, row, (DStatePtr) source);
}

void Lib_DReal_StateSetCoeff(mpNumMatrixPtr result, ScalarPtr source, long row)
{
    LibDReal_StateSetCoeff((DStatePtr) result, (DRealPtr) source, row);
}


void Lib_DReal_StateGetSize(long *result, mpNumMatrixPtr x)
{
    LibDReal_StateGetSize(result, (DStatePtr)x);
}


void Lib_DReal_Const_RungeKutta4(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_)
{
    LibDReal_Const_RungeKutta4((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_DReal_Const_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_)
{
    LibDReal_Const_RungeKuttaCashKarp54((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_DReal_Const_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_)
{
    LibDReal_Const_RungeKuttaDopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_DReal_Const_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_)
{
    LibDReal_Const_RungeKuttaFehlberg78((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}

void Lib_DReal_Const_AdamsBashforthMoulton(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_)
{
    LibDReal_Const_AdamsBashforthMoulton((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_);
}


void Lib_DReal_Adaptive_RungeKuttaDopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_, DRealPtr eps_abs_, DRealPtr eps_rel_)
{
    LibDReal_Adaptive_RungeKuttaDopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_DReal_Adaptive_RungeKuttaCashKarp54(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_, DRealPtr eps_abs_, DRealPtr eps_rel_)
{
    LibDReal_Adaptive_RungeKuttaCashKarp54((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_DReal_Adaptive_RungeKuttaFehlberg78(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_, DRealPtr eps_abs_, DRealPtr eps_rel_)
{
    LibDReal_Adaptive_RungeKuttaFehlberg78((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_DReal_Adaptive_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_, DRealPtr eps_abs_, DRealPtr eps_rel_)
{
    LibDReal_Adaptive_BulirschStoer((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_DReal_DenseOutput_Dopri5(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_, DRealPtr eps_abs_, DRealPtr eps_rel_)
{
    LibDReal_DenseOutput_Dopri5((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}

void Lib_DReal_DenseOutput_BulirschStoer(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr x, DRealPtr start_time_, DRealPtr end_time_, DRealPtr dt_, DRealPtr eps_abs_, DRealPtr eps_rel_)
{
    LibDReal_DenseOutput_BulirschStoer((DAnyFuncPtr3)f1, (DAnyFuncPtr2)f2, (DStatePtr)x, start_time_, end_time_, dt_, eps_abs_, eps_rel_);
}































