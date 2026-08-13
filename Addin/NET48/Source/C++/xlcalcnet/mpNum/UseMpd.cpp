//#define MPFR_WANT_FLOAT128
//#include "Helperfunctions.h"
#include <string.h>
#include <limits>
#include "mpdecimal.h"
#include <quadmath.h>
#include "mpNumC_Main.h"



#define  MaxValueInt64  std::numeric_limits<int64_t>::max()
#define  MinValueInt64  std::numeric_limits<int64_t>::min()

#define  MaxValueUInt64  std::numeric_limits<uint64_t>::max()
#define  MinValueUInt64  std::numeric_limits<uint64_t>::min()

#define  MaxValueInt32  std::numeric_limits<int32_t>::max()
#define  MinValueInt32  std::numeric_limits<int32_t>::min()

#define  MaxValueUInt32  std::numeric_limits<uint32_t>::max()
#define  MinValueUInt32  std::numeric_limits<uint32_t>::min()




typedef struct
{
	mpd_t* real;
	mpd_t* imag;
}
__Mpdc_struct;

typedef __Mpdc_struct Mpdc_t[1];
typedef __Mpdc_struct* mpdc_ptr;
typedef const __Mpdc_struct* Mpdc_srcptr;

#define Mpdc_realref(__x) (&(__x)->real)
#define Mpdc_imagref(__y) (&(__y)->imag)





int32_t int64_fits_int32(int64_t x)
{
	//printf("in int64_fits_int32;  %lld,  \n", x);
	int32_t res = 0;
	if ((x >= MinValueInt32) && (x <= MaxValueInt32)) res = 1;
	return res;
}


int32_t uint64_fits_uint32(uint64_t x)
{
	int32_t res = 0;
	if ((x >= MinValueUInt32) && (x <= MaxValueUInt32)) res = 1;
	return res;
}





//*********************** Mpd **********************************


/* **************** MPD ************************ */

mpd_context_t* mpd_globalctx()
    {
        static mpd_context_t* GlobalCtx = NULL;
        if (GlobalCtx == NULL)
        {
            GlobalCtx = (mpd_context_t*)malloc(sizeof(mpd_context_t));
            mpd_init(GlobalCtx, 34);
        }
        return GlobalCtx;
    }



void mpd_boost50context(mpd_context_t *ctx)
{
    ctx->prec=50;
    ctx->emax=67108864;
    ctx->emin=0 - ctx->emax;
    ctx->round=MPD_ROUND_HALF_EVEN;
    ctx->traps=0;
    ctx->status=0;
    ctx->newtrap=0;
    ctx->clamp=0;
    ctx->allcr=1;
}



void Lib_Mpd_BoostCppDecContext()
{
    mpd_boost50context( mpd_globalctx());
}



void Lib_Mpd_Defaultcontext()
{
    mpd_defaultcontext( mpd_globalctx());
}




void Lib_Mpd_Basiccontext()
{
    mpd_basiccontext( mpd_globalctx());
}


void Lib_Mpd_Maxcontext()
{
    mpd_maxcontext( mpd_globalctx());
}



void Lib_Mpd_Decimal32context()
{
    mpd_ieee_context( mpd_globalctx(), MPD_DECIMAL32);
}



void Lib_Mpd_Decimal64context()
{
    mpd_ieee_context( mpd_globalctx(), MPD_DECIMAL64);
}




void Lib_Mpd_Decimal128context()
{
    mpd_ieee_context( mpd_globalctx(), MPD_DECIMAL128);
}




int32_t Lib_Mpd_SetPrec(uint32_t prec)
{
    return mpd_qsetprec( mpd_globalctx(), prec);
}





int64_t Lib_Mpd_GetPrec()
{
    return mpd_getprec( mpd_globalctx());
}


int64_t Lib_Mpd_GetEmax()
{
    return mpd_getemax( mpd_globalctx());
}


int64_t Lib_Mpd_GetEmin()
{
    return mpd_getemin( mpd_globalctx());
}


int32_t Lib_Mpd_GetRound()
{
    return mpd_getround( mpd_globalctx());
}


uint32_t Lib_Mpd_GetTraps()
{
    return mpd_gettraps( mpd_globalctx());
}


uint32_t Lib_Mpd_GetStatus()
{
    return mpd_getstatus( mpd_globalctx());
}


uint32_t Lib_Mpd_GetClamp()
{
    return mpd_getclamp( mpd_globalctx());
}


uint32_t Lib_Mpd_GetCorrectRounding()
{
    return mpd_getcr( mpd_globalctx());
}


int64_t Lib_Mpd_GetEtiny()
{
    return mpd_etiny( mpd_globalctx());
}


int64_t Lib_Mpd_GetEtop()
{
    return mpd_etop( mpd_globalctx());
}




/* **************** These functions need to be amended to handle Nan, Inf etc ************************ */




int32_t decr_fits_uint64(mpd_t* x)
{
	int32_t res = 0;
	if (mpd_isfinite(x))
	{
		mpd_t* t;
		t = mpd_new(mpd_globalctx());
		mpd_set_u64(t, MinValueUInt64, mpd_globalctx());
		int lowerbound = mpd_cmp(x, t, mpd_globalctx());
		mpd_set_u64(t, MaxValueUInt64, mpd_globalctx());
		int upperbound = mpd_cmp(t, x, mpd_globalctx());
		mpd_del(t);
		res = ((lowerbound >= 0) && (upperbound >= 0));
		//printf("lowerbound: %i, upperbound: %i, res: %i \n", lowerbound, upperbound, res);
	}
	return res;
}


int32_t decr_fits_int64(mpd_t* x)
{
	int32_t res = 0;
	if (mpd_isfinite(x))
	{
		mpd_t* t;
		t = mpd_new(mpd_globalctx());
		mpd_set_i64(t, MinValueInt64, mpd_globalctx());
		int lowerbound = mpd_cmp(x, t, mpd_globalctx());
		mpd_set_i64(t, MaxValueInt64, mpd_globalctx());
		int upperbound = mpd_cmp(t, x, mpd_globalctx());
		mpd_del(t);
		res = ((lowerbound >= 0) && (upperbound >= 0));
		//printf("lowerbound: %i, upperbound: %i, res: %i \n", lowerbound, upperbound, res);
	}
	return res;
}



uint64_t decr_get_ui64(mpd_t* x)
{
	uint64_t res = 0;
	if (mpd_isfinite(x))
	{
		mpd_t* t;
		t = mpd_new(mpd_globalctx());
		mpd_round_to_int(t, x, mpd_globalctx());
		int fits = decr_fits_uint64(t);
		if (fits != 0) res = mpd_get_u64(t, mpd_globalctx());
		mpd_del(t);
	}
	return res;
}



int32_t decr_fits_uint32(mpd_t* x)
{
	int32_t res = 0;
	int fits = decr_fits_uint64(x);
	if (fits != 0)
	{
		int64_t res64 = decr_get_ui64(x);
		res = uint64_fits_uint32(res64);
	}
	return res;
}


int64_t decr_get_si64(mpd_t* x)
{
	int64_t res = 0;
	if (mpd_isfinite(x))
	{
		mpd_t* t;
		t = mpd_new(mpd_globalctx());
		mpd_round_to_int(t, x, mpd_globalctx());
		int fits = decr_fits_int64(t);
		if (fits != 0) res = mpd_get_i64(t, mpd_globalctx());
		mpd_del(t);
	}
	return res;
}


int32_t decr_fits_int32(mpd_t* x)
{
	int32_t res = 0;
	int fits = decr_fits_int64(x);
	if (fits != 0)
	{
		int64_t res64 = decr_get_si64(x);
		res = int64_fits_int32(res64);
	}
	//printf("in decr_fits_int32;   fits: %i, res: %i \n", fits, res);
	return res;
}


int32_t decr_get_si32(mpd_t* x)
{
	int32_t res = 0;
	int fits = decr_fits_int32(x);
	//printf("in decr_get_si32;   fits: %i, res: %i \n", fits, res);
	if (fits != 0) res = (int32_t)decr_get_si64(x);
	return res;
}


uint32_t decr_get_ui32(mpd_t* x)
{
	uint32_t res = 0;
	int fits = decr_fits_uint32(x);
	if (fits != 0) res = decr_get_ui64(x);
	return res;
}




/* the smallest eps such that x + eps != x */
void mpd_machine_epsilon_x(mpd_t* res, mpd_t* x, int32_t prec)
{
	mpd_t* xn;
	xn = mpd_new(mpd_globalctx());
	if (mpd_isnegative(x))
	{
		mpd_minus(xn, x, mpd_globalctx());
		mpd_next_plus(xn, xn, mpd_globalctx());
		mpd_add(res, xn, x, mpd_globalctx());
	}
	else
	{
		mpd_next_plus(xn, x, mpd_globalctx());
		mpd_sub(res, xn, x, mpd_globalctx());
	}
	mpd_del(xn);
}



/* at precision prec, the smallest eps such that 1 + eps != 1 */
void mpd_machine_epsilon_prec(mpd_t* res, int32_t prec)
{
	mpd_t* one; one = mpd_new(mpd_globalctx());
	mpd_set_i32(one, 1, mpd_globalctx());
	mpd_machine_epsilon_x(res, one, prec);
	mpd_del(one);
}



/* at precision prec, minval = 1/10 * 10^emin = 10^(emin - 1) */
void mpd_minval_prec(mpd_t* res, int32_t prec)
{
	int64_t emin1 = mpd_getemin(mpd_globalctx()) - 1;

	mpd_t* ten; ten = mpd_new(mpd_globalctx());
	mpd_set_i32(ten, 10, mpd_globalctx());

	mpd_t* mpd_emin; mpd_emin = mpd_new(mpd_globalctx());
	mpd_set_i64(mpd_emin, emin1, mpd_globalctx());

	mpd_pow(res, ten, mpd_emin, mpd_globalctx());

	mpd_del(mpd_emin);
	mpd_del(ten);
}


/* at precision prec, maxval = (1 - eps) * 10^emax, eps is machine epsilon */
void mpd_maxval_prec(mpd_t* res, int32_t prec)
{
    int isg34 = 0;
    mpd_ssize_t oldprec = mpd_getprec( mpd_globalctx());

    if (oldprec<34)
    {
        mpd_qsetprec( mpd_globalctx(), 34);
        isg34 = 1;
    }

	int64_t emax = mpd_getemax(mpd_globalctx());

	mpd_t* eps; eps = mpd_new(mpd_globalctx());
	mpd_machine_epsilon_prec(eps, prec);

	mpd_t* one_minus_eps; one_minus_eps = mpd_new(mpd_globalctx());
	mpd_sub_i32(one_minus_eps, eps, 1, mpd_globalctx());
	mpd_minus(one_minus_eps, one_minus_eps, mpd_globalctx());

	mpd_t* ten; ten = mpd_new(mpd_globalctx());
	mpd_set_i32(ten, 10, mpd_globalctx());

	mpd_t* mpd_emax; mpd_emax = mpd_new(mpd_globalctx());
	mpd_set_i64(mpd_emax, emax, mpd_globalctx());

	mpd_t* pow10; pow10 = mpd_new(mpd_globalctx());

	mpd_pow(pow10, ten, mpd_emax, mpd_globalctx());
	mpd_mul(res, pow10, one_minus_eps, mpd_globalctx());

	if (isg34 == 1)
    {
        mpd_qsetprec( mpd_globalctx(), oldprec);
        mpd_mul(res, pow10, one_minus_eps, mpd_globalctx());
    }
    else
    {
        mpd_mul(res, pow10, one_minus_eps, mpd_globalctx());
    }

	mpd_del(eps);
	mpd_del(one_minus_eps);
	mpd_del(mpd_emax);
	mpd_del(ten);
	mpd_del(pow10);

}




/** ********************** Real Basic Functions, Mpd ******************************** **/


MpdPtr Lib_Mpd_Init_Func()
{
	MpdPtr x;
	x = mpd_new(mpd_globalctx());
	mpd_set_i32((mpd_t*)x, 0, mpd_globalctx());
	return x;
}


void Lib_Mpd_Clear(MpdPtr x)
{
	mpd_del((mpd_t *)x);
}



void Lib_Mpd_Set(MpdPtr res, const MpdPtr x)
{
    mpd_copy( (mpd_t *) res, (mpd_t *) x, mpd_globalctx());
}




//void Lib_Mpd_Set_Fmpq(MpdPtr res, const FmpqPtr x)
//{
//    decr_set_fmpq((mpd_t *)res, (fmpq*)x);
//}
//
//
//void Lib_Mpd_Set_Arb(MpdPtr res, const ArbPtr x)
//{
//	char * str = arb_get_str((arb_ptr)x, (mpfr_get_default_prec() * 100) / 333, ARB_STR_NO_RADIUS);
//	mpd_set_string((mpd_t *)res, str, mpd_globalctx());
//	free(str);
//}
//
//void Lib_Mpd_Set_Arf(MpdPtr res, const ArfPtr x)
//{
//	arb_t temp; arb_init(temp);
//	arf_set(arb_midref(temp), (arf_ptr)x);
//	mag_zero(arb_radref(temp));
//	char * str = arb_get_str(temp, (mpfr_get_default_prec() * 100) / 333, ARB_STR_NO_RADIUS);
//	mpd_set_string((mpd_t *)res, str, mpd_globalctx());
//	free(str);
//	arb_clear(temp);
//}
//



//void Lib_Mpd_Set_Mpfi(MpdPtr res, const char *template1, const MpfiPtr x)
//{
//    mpfr_t temp; mpfr_init(temp);
//	mpfi_mid (temp, (mpfi_ptr)x);
//	char * str = mpfr_get_str_extern(template1, (mpfr_get_default_prec() * 100) / 333, temp);
//	mpd_set_string((mpd_t *)res, str, mpd_globalctx());
//	free(str);
//	mpfr_clear(temp);
//}
//
//
//
//
//
//void Lib_Mpd_Set_Mpfr(MpdPtr res, const char *template1, const MpfrPtr x)
//{
//	char * str = mpfr_get_str_extern(template1, (mpfr_get_default_prec() * 100) / 333, (mpfr_ptr)x);
//	mpd_set_string((mpd_t *)res, str, mpd_globalctx());
//	free(str);
//}
//


void Lib_Mpd_Set_Mpd(MpdPtr res, const MpdPtr x)
{
    mpd_copy( (mpd_t *) res, (mpd_t *) x, mpd_globalctx());
}

//
//
//
//void Lib_Mpd_Set_YReal(MpdPtr res, const YRealPtr x)
//{
//    char str[128];   //To hold . and null
//    Lib_YReal_Get_Str(str, x);
//	mpd_set_string((mpd_t *) res, str, mpd_globalctx());
//}
//
//


void Lib_Mpd_Set_QReal(MpdPtr res, const QRealPtr x)
{
    char str[128];   //To hold . and null
    quadmath_snprintf (str, 128, "%+-#*.34Qe", 46, (*(__float128*)x));
    mpd_set_string((mpd_t *) res, str, mpd_globalctx());
}



//void Lib_Mpd_Set_LD(MpdPtr res, const long double* x)
//{
//    char str[36];   //To hold . and null
//    sprintf(str,"%.19E", *x);
//	mpd_set_string((mpd_t *) res, str, mpd_globalctx());
//}


void Lib_Mpd_Set_D(MpdPtr res, const double d)
{
    char str[26];   //To hold . and null
    sprintf(str,"%.14E",d);
	mpd_set_string((mpd_t *) res, str, mpd_globalctx());
}


void Lib_Mpd_Set_S(MpdPtr res, const float* d)
{
    char str[26];   //To hold . and null
    sprintf(str,"%.7E", *d);
	mpd_set_string((mpd_t *) res, str, mpd_globalctx());
}


void Lib_Mpd_Set_Si(MpdPtr res, const int32_t a)
{
    mpd_set_i32( (mpd_t *) res, a, mpd_globalctx());
}


void Lib_Mpd_Set_Ui(MpdPtr res, const uint32_t a)
{
    mpd_set_u32( (mpd_t *) res, a, mpd_globalctx());
}


void Lib_Mpd_Set_Si64(MpdPtr res, const int64_t a)
{
    mpd_set_i64( (mpd_t *) res, a, mpd_globalctx());
}


void Lib_Mpd_Set_Ui64(MpdPtr res, const uint64_t a)
{
    mpd_set_u64( (mpd_t *) res, a, mpd_globalctx());
}


void Lib_Mpd_Set_Str(MpdPtr res, const char * str)
{
    mpd_set_string( (mpd_t *) res, str, mpd_globalctx());
}



uint32_t Lib_Mpd_SizeInBase10(const MpdPtr x)
{
    char *src = mpd_to_sci((mpd_t *) x, 1);
	uint32_t res = strlen(src) + 1;
    free(src);
    return res;
}



int64_t Lib_Mpd_Get_Str(char* dest, const MpdPtr x)
{
	char * src = mpd_to_sci((mpd_t *)x, 1);
	strcpy(dest, src);
	free(src);
	return 0;
}




int32_t Lib_Mpd_Cmp(const MpdPtr x, const MpdPtr y)
{
    return mpd_cmp((mpd_t *) x, (mpd_t *) y, mpd_globalctx());
}





int32_t Lib_Mpd_LT(const MpdPtr x, const MpdPtr y)
{
	int res = mpd_cmp((mpd_t *) x, (mpd_t *) y, mpd_globalctx());
	if (res<0) return 1; else return 0;
}


int32_t Lib_Mpd_GE(const MpdPtr x, const MpdPtr y)
{
	int res = mpd_cmp((mpd_t *) x, (mpd_t *) y, mpd_globalctx());
	if (res>=0) return 1; else return 0;
}


int32_t Lib_Mpd_GT(const MpdPtr x, const MpdPtr y)
{
	int res = mpd_cmp((mpd_t *) x, (mpd_t *) y, mpd_globalctx());
	if (res>0) return 1; else return 0;
}


int32_t Lib_Mpd_LE(const MpdPtr x, const MpdPtr y)
{
	int res = mpd_cmp((mpd_t *) x, (mpd_t *) y, mpd_globalctx());
	if (res<=0) return 1; else return 0;
}


int32_t Lib_Mpd_EQ(const MpdPtr x, const MpdPtr y)
{
	int res = mpd_cmp((mpd_t *) x, (mpd_t *) y, mpd_globalctx());
	if (res==0) return 1; else return 0;
}


int32_t Lib_Mpd_NE(const MpdPtr x, const MpdPtr y)
{
	int res = mpd_cmp((mpd_t *) x, (mpd_t *) y, mpd_globalctx());
	if (res!=0) return 1; else return 0;
}


void Lib_Mpd_Neg(MpdPtr f, MpdPtr g)
{
    mpd_minus( (mpd_t *) f,  (mpd_t *) g, mpd_globalctx());
}





void Lib_Mpd_Add(MpdPtr f, MpdPtr g, MpdPtr h)
{
    mpd_add( (mpd_t *) f,  (mpd_t *) g,  (mpd_t *) h, mpd_globalctx());
}


void Lib_Mpd_Sub(MpdPtr f, MpdPtr g, MpdPtr h)
{
    mpd_sub( (mpd_t *) f,  (mpd_t *) g,  (mpd_t *) h, mpd_globalctx());
}


void Lib_Mpd_Mul(MpdPtr x, MpdPtr y, MpdPtr z)
{
    mpd_mul( (mpd_t *) x,  (mpd_t *) y,  (mpd_t *) z, mpd_globalctx());
}


void Lib_Mpd_Div(MpdPtr x, MpdPtr y, MpdPtr z)
{
    mpd_div( (mpd_t *) x,  (mpd_t *) y,  (mpd_t *) z, mpd_globalctx());
}









void Lib_Mpd_Add_D(MpdPtr f, MpdPtr g, double d)
{
	mpd_t* t;
	t = mpd_new(mpd_globalctx());
	Lib_Mpd_Set_D(t, d);
	mpd_add((mpd_t *)f, (mpd_t *)g, t, mpd_globalctx());
	mpd_del((mpd_t *)t);
}



void Lib_Mpd_Sub_D(MpdPtr f, MpdPtr g, double d)
{
	mpd_t* t;
	t = mpd_new(mpd_globalctx());
	Lib_Mpd_Set_D(t, d);
	mpd_sub((mpd_t *)f, (mpd_t *)g, t, mpd_globalctx());
	mpd_del((mpd_t *)t);
}



void Lib_Mpd_D_Sub(MpdPtr f, MpdPtr g, double d)
{
	mpd_t* t;
	t = mpd_new(mpd_globalctx());
	Lib_Mpd_Set_D(t, d);
	mpd_sub((mpd_t *)f, t, (mpd_t *)g, mpd_globalctx());
	mpd_del((mpd_t *)t);
}



void Lib_Mpd_Mul_D(MpdPtr f, MpdPtr g, double d)
{
	mpd_t* t;
	t = mpd_new(mpd_globalctx());
	Lib_Mpd_Set_D(t, d);
	mpd_mul((mpd_t *)f, (mpd_t *)g, t, mpd_globalctx());
	mpd_del((mpd_t *)t);
}



void Lib_Mpd_Div_D(MpdPtr f, MpdPtr g, double d)
{
	mpd_t* t;
	t = mpd_new(mpd_globalctx());
	Lib_Mpd_Set_D(t, d);
	mpd_div((mpd_t *)f, (mpd_t *)g, t, mpd_globalctx());
	mpd_del((mpd_t *)t);
}



void Lib_Mpd_D_Div(MpdPtr f, MpdPtr g, double d)
{
	mpd_t* t;
	t = mpd_new(mpd_globalctx());
	Lib_Mpd_Set_D(t, d);
	mpd_div((mpd_t *)f, t, (mpd_t *)g, mpd_globalctx());
	mpd_del((mpd_t *)t);
}




void Lib_Mpd_Add_Si(MpdPtr f, MpdPtr g,  int32_t x)
{
    mpd_add_i32( (mpd_t *) f,  (mpd_t *) g,  x, mpd_globalctx());
}


void Lib_Mpd_Sub_Si(MpdPtr f, MpdPtr g,  int32_t x)
{
    mpd_sub_i32( (mpd_t *) f,  (mpd_t *) g,  x, mpd_globalctx());
}


void Lib_Mpd_Si_Sub(MpdPtr f, MpdPtr g, int32_t x)
{
    mpd_t* t;
    t =  mpd_new(mpd_globalctx());
    mpd_set_i32((mpd_t*) t, x, mpd_globalctx());
    mpd_sub((mpd_t *) f,  (mpd_t *) t, (mpd_t *) g, mpd_globalctx());
    mpd_del((mpd_t *) t);
}


void Lib_Mpd_Mul_Si(MpdPtr f, MpdPtr g,  int32_t x)
{
    mpd_mul_i32( (mpd_t *) f,  (mpd_t *) g,  x, mpd_globalctx());
}


void Lib_Mpd_Div_Si(MpdPtr f, MpdPtr g,  int32_t x)
{
    mpd_div_i32( (mpd_t *) f,  (mpd_t *) g,  x, mpd_globalctx());
}


void Lib_Mpd_Si_Div(MpdPtr f, MpdPtr g, int32_t x)
{
    mpd_t* t; t =  mpd_new(mpd_globalctx());
    mpd_set_i32((mpd_t*) t, x, mpd_globalctx());
    mpd_div((mpd_t *) f,  (mpd_t *) t, (mpd_t *) g, mpd_globalctx());
    mpd_del((mpd_t *) t);
}





/* General functions for real numbers  */

void Lib_Mpd_Fma(MpdPtr r, MpdPtr a, MpdPtr b, MpdPtr c)
{
    mpd_fma((mpd_t *) r,  (mpd_t *) a,  (mpd_t *) b,  (mpd_t *) c, mpd_globalctx());
}

void Lib_Mpd_Fmax(MpdPtr result, MpdPtr a, MpdPtr b)
{
    mpd_max( (mpd_t *) result,  (mpd_t *) a,  (mpd_t *) b, mpd_globalctx());
}

void Lib_Mpd_Fmin(MpdPtr result, MpdPtr a, MpdPtr b)
{
    mpd_min( (mpd_t *) result,  (mpd_t *) a,  (mpd_t *) b, mpd_globalctx());
}





/* Machine constants and properties of numbers  */

void Lib_Mpd_Zero(MpdPtr a)
{
    mpd_zerocoeff((mpd_t *) a);
}

void Lib_Mpd_NegZero(MpdPtr a)
{
    mpd_zerocoeff((mpd_t *) a);
    mpd_set_negative((mpd_t *) a);
}

void Lib_Mpd_One(MpdPtr a)
{
    mpd_set_u32( (mpd_t *) a, 1, mpd_globalctx());
}

void Lib_Mpd_Inf(MpdPtr a)
{
    mpd_setspecial((mpd_t *) a, MPD_POS, MPD_INF);
}

void Lib_Mpd_NegInf(MpdPtr a)
{
    mpd_setspecial((mpd_t *) a, MPD_NEG, MPD_INF);
}

void Lib_Mpd_Nan(MpdPtr a)
{
    mpd_setspecial((mpd_t *) a, MPD_POS, MPD_NAN);
}




/* Properties of numbers  */

int32_t Lib_Mpd_Signbit(MpdPtr a)
{
    return mpd_sign((mpd_t *) a);
}

int32_t Lib_Mpd_Finite(MpdPtr a)
{
    return mpd_isfinite((mpd_t *) a);
}


int32_t Lib_Mpd_IsZero(MpdPtr a)
{
    return mpd_iszero((mpd_t *) a);
}


int32_t Lib_Mpd_IsInteger(MpdPtr a)
{
    return mpd_isinteger((mpd_t *) a);
}




int32_t Lib_Mpd_IsInf(MpdPtr a)
{
    return mpd_isinfinite((mpd_t *) a);
}

int32_t Lib_Mpd_Isposinf(MpdPtr a)
{
    return (mpd_isinfinite((mpd_t *) a) & (mpd_sign((mpd_t *) a) == 0));
}

int32_t Lib_Mpd_Isneginf(MpdPtr a)
{
    return (mpd_isinfinite((mpd_t *) a) & (mpd_sign((mpd_t *) a) > 0));
}



int32_t Lib_Mpd_IsNan(MpdPtr a)
{
    return mpd_isnan((mpd_t *) a);
}

int32_t Lib_Mpd_FitsInt32(const MpdPtr a)
{
    return decr_fits_int32((mpd_t *) a);
}

int32_t Lib_Mpd_FitsInt64(const MpdPtr a)
{
    return decr_fits_int64((mpd_t *) a);
}

int32_t Lib_Mpd_FitsUInt32(const MpdPtr a)
{
    return decr_fits_uint32((mpd_t *) a);
}

int32_t Lib_Mpd_FitsUInt64(const MpdPtr a)
{
    return decr_fits_uint64((mpd_t *) a);
}





/* Integer Related Functions  */

void Lib_Mpd_Nearbyint(MpdPtr result, const MpdPtr x)
{
    mpd_round_to_int( (mpd_t *) result,  (mpd_t *) x, mpd_globalctx());
}

void Lib_Mpd_Rint(MpdPtr result, const MpdPtr x)
{
    mpd_round_to_int( (mpd_t *) result,  (mpd_t *) x, mpd_globalctx());
}

long int Lib_Mpd_Lrint(const MpdPtr x)
{
    return decr_get_si32((mpd_t *) x);
}

long long int Lib_Mpd_Llrint(const MpdPtr x)
{
    return decr_get_si64((mpd_t *) x);
}


void Lib_Mpd_Ceil(MpdPtr result, const MpdPtr x)
{
    mpd_ceil( (mpd_t *) result,  (mpd_t *) x, mpd_globalctx());
}

void Lib_Mpd_Floor(MpdPtr result, const MpdPtr x)
{
    mpd_floor( (mpd_t *) result,  (mpd_t *) x, mpd_globalctx());
}

void Lib_Mpd_Trunc(MpdPtr result, const MpdPtr x)
{
    mpd_trunc( (mpd_t *) result,  (mpd_t *) x, mpd_globalctx());
}


void Lib_Mpd_Round(MpdPtr result, const MpdPtr x)
{
    mpd_round_to_int( (mpd_t *) result,  (mpd_t *) x, mpd_globalctx());
}

long int Lib_Mpd_Lround(const MpdPtr x)
{
    return decr_get_si32((mpd_t *) x);
}

long long int Lib_Mpd_Llround(const MpdPtr x)
{
    return decr_get_si64((mpd_t *) x);
}


int32_t Lib_Mpd_ToInt32(const MpdPtr x)
{
    return decr_get_si32((mpd_t *) x);
}

int64_t Mpd_ToInt64(const MpdPtr x)
{
    return decr_get_si64((mpd_t *) x);
}


uint32_t Lib_Mpd_ToUInt32(const MpdPtr x)
{
    return decr_get_ui32((mpd_t *) x);
}

uint64_t Mpd_ToUInt64(const MpdPtr x)
{
    return decr_get_ui64((mpd_t *) x);
}






/* Floating point functions for real numbers */

void Lib_Mpd_Copysign(MpdPtr result, MpdPtr x, MpdPtr y)
{
    mpd_copy( (mpd_t *) result, (mpd_t *) x, mpd_globalctx());
    mpd_signcpy((mpd_t *) result, (mpd_t *) y);
}



//void Lib_Arf_Set_Str(ArfPtr res, const char* s)
//{
//    arb_t xtemp; arb_init(xtemp);
//    arb_set_str((arb_ptr)xtemp, s, mpfr_get_default_prec());
//    arf_set((arf_ptr)res, arb_midref(xtemp));
//    arb_clear(xtemp);
//}
//
//
//
//
//
//void Lib_Arf_Set_Mpd(ArfPtr res, const MpdPtr x)
//{
//	char * src = mpd_to_sci((mpd_t *)x, 1);
//	Lib_Arf_Set_Str(res, src);
//	free(src);
//}



//void Lib_Mpd_Frexp(MpdPtr res, const MpdPtr x, long long int* e)
//{
//	arf_t ma, xa;
//	arf_init(ma); arf_init(xa);
//    fmpz_t fe; fmpz_init(fe);
//    Lib_Arf_Set_Mpd(xa, x);
//    arf_frexp(ma, fe, xa);
//    Lib_Mpd_Set_Arf(res, ma);
//    *e = fmpz_get_si(fe);
//    arf_clear(ma); arf_clear(xa);
//    fmpz_clear(fe);
//}


void Lib_Mpd_Logb(MpdPtr result, MpdPtr x)
{
    mpd_logb( (mpd_t *) result,  (mpd_t *) x, mpd_globalctx());
}




void Lib_Mpd_Ldexp(MpdPtr res, const MpdPtr x, const long int e)
{
    mpd_t* de; de = mpd_new(mpd_globalctx());
    mpd_set_i32((mpd_t*) de, e, mpd_globalctx());
    mpd_t* d2; d2 = mpd_new(mpd_globalctx());
    mpd_set_i32((mpd_t*) d2, 2, mpd_globalctx());
    mpd_t* p; p = mpd_new(mpd_globalctx());
    mpd_pow(p, d2, de, mpd_globalctx());
    mpd_mul( (mpd_t *) res,  (mpd_t *) x,  p, mpd_globalctx());
    mpd_del((mpd_t *) de);
    mpd_del((mpd_t *) d2);
    mpd_del((mpd_t *) p);
}

void Lib_Mpd_Scalbn(MpdPtr result, MpdPtr x, MpdPtr y)
{
    mpd_scaleb( (mpd_t *) result,  (mpd_t *) x, (mpd_t *) y, mpd_globalctx());
}

void Lib_Mpd_Scalbln(MpdPtr result, MpdPtr x, MpdPtr y)
{
    mpd_scaleb( (mpd_t *) result,  (mpd_t *) x, (mpd_t *) y, mpd_globalctx());
}


void Lib_Mpd_Fdim(MpdPtr res, const MpdPtr x, const MpdPtr y)
{
    mpd_t* result; result = mpd_new(mpd_globalctx());
    int c = mpd_compare(result, (mpd_t *) x, (mpd_t *) y, mpd_globalctx());
    if ((c == 0) || (c == -1))
    {
        mpd_zerocoeff((mpd_t *) res);
    }
    else if (c == 1)
    {
        mpd_sub((mpd_t *) res, (mpd_t *) x, (mpd_t *) y, mpd_globalctx());
    }
    else
    {
        mpd_setspecial((mpd_t *) res, MPD_POS, MPD_NAN);
    }
    mpd_del((mpd_t *) result);
}





/* Fraction and Remainder Related Functions  */

void Lib_Mpd_Modf(MpdPtr frac, const MpdPtr x, MpdPtr iptr)
{
    mpd_trunc((mpd_t *)iptr, (mpd_t *)x, mpd_globalctx());
    mpd_sub( (mpd_t *)frac, (mpd_t *)x,  (mpd_t *)iptr, mpd_globalctx());
}

void Lib_Mpd_Fmod(MpdPtr res, MpdPtr x, MpdPtr y)
{
    mpd_rem( (mpd_t *) res,  (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}

void Lib_Mpd_Remainder(MpdPtr res, MpdPtr x, MpdPtr y)
{
    mpd_rem_near( (mpd_t *) res,  (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}





/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

void Lib_Mpd_Epsilon(MpdPtr res, int32_t prec)
{
	mpd_machine_epsilon_prec((mpd_t *)res, prec);
}

void Lib_Mpd_Ulp(MpdPtr res, MpdPtr x, int32_t prec)
{
	mpd_machine_epsilon_x((mpd_t *)res, (mpd_t *)x, prec);
}


void Lib_Mpd_Max(MpdPtr res, int32_t prec)
{
	mpd_maxval_prec((mpd_t *)res, prec);
}

void Lib_Mpd_Min(MpdPtr res, int32_t prec)
{
	mpd_minval_prec((mpd_t *)res, prec);
}

void Lib_Mpd_Lowest(MpdPtr res, int32_t prec)
{
	mpd_maxval_prec((mpd_t *)res, prec);
	mpd_minus((mpd_t *)res, (mpd_t *)res, mpd_globalctx());
}

void Lib_Mpd_Nextbelow(MpdPtr x, MpdPtr y)
{
    mpd_next_minus( (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}

void Lib_Mpd_Nextabove(MpdPtr x, MpdPtr y)
{
    mpd_next_plus( (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}

void Lib_Mpd_Next_Toward(MpdPtr result, MpdPtr a, MpdPtr b)
{
    mpd_next_toward( (mpd_t *) result,  (mpd_t *) a, (mpd_t *) b, mpd_globalctx());
}





/* Mathematical Constants  */

//void Lib_Mpd_ConstDegree(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_degree_, res);
//}
//
//void Lib_Mpd_ConstPhi(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_phi_, res);
//}
//
//void Lib_Mpd_ConstLog2(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_log2, res);
//}
//
//void Lib_Mpd_ConstLog10(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_log10, res);
//}
//
//
//void Lib_Mpd_ConstPi(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_pi, res);
//}
//
//void Lib_Mpd_ConstE(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_e, res);
//}
//
//
//void Lib_Mpd_ConstEulerGamma(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_euler, res);
//}
//
//void Lib_Mpd_ConstApery(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_apery, res);
//}
//
//void Lib_Mpd_ConstCatalan(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_catalan, res);
//}
//
//void Lib_Mpd_ConstGlaisher(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_glaisher, res);
//}
//
//void Lib_Mpd_ConstKhinchin(MpdPtr res)
//{
//    Mpd_Arb_Realfunc0_Prec(arb_const_khinchin, res);
//}
//
//



/* Complex components  */

void Lib_Mpd_Fabs(MpdPtr x, const MpdPtr y)
{
    mpd_abs( (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}

void Lib_Mpd_Sign(MpdPtr res, const MpdPtr a)
{
    int32_t temp = mpd_arith_sign((mpd_t *) a);
    mpd_set_i32( (mpd_t *) res, temp, mpd_globalctx());
}





/* Roots and related functions  */

void Lib_Mpd_Sqrt(MpdPtr x, const MpdPtr y)
{
    mpd_sqrt( (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}

//void Lib_Mpd_Sqrt1pm1(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_sqrt1pm1, res, x);
//}

void Lib_Mpd_Rsqrt(MpdPtr x, const MpdPtr y)
{
    mpd_invroot( (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}

//void Lib_Mpd_Cbrt(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_cbrt, res, x);
//}
//
//void Lib_Root_Si(MpdPtr res, const MpdPtr x, const int32_t n)
//{
//    Mpd_Arb_Realfunc1Int32_Prec(arb_root_si_, res, x, n);
//}





/* Exponential and related functions  */


void Lib_Mpd_Exp(MpdPtr x, const MpdPtr y)
{
    mpd_exp( (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}


//void Lib_Mpd_Exp2(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_exp2_, res, x);
//}
//
//
//void Lib_Mpd_Exp10(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_exp10_, res, x);
//}
//
//
//void Lib_Mpd_Expm1(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_expm1, res, x);
//}
//
//
//void Lib_Mpd_Exp10m1(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_exp10m1_, res, x);
//}
//
//
//void Lib_Mpd_Exp2m1(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_exp2m1_, res, x);
//}





/* Logarithms and related functions  */


void Lib_Mpd_Log(MpdPtr x, const MpdPtr y)
{
    mpd_ln( (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}


//void Lib_Mpd_Log2(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_log2, res, x);
//}


void Lib_Mpd_Log10(MpdPtr x, const MpdPtr y)
{
    mpd_log10( (mpd_t *) x,  (mpd_t *) y, mpd_globalctx());
}


//void Lib_Mpd_Log1p(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_log1p, res, x);
//}
//
//
//void Lib_Mpd_Log10p1(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_log10p1_, res, x);
//}
//
//
//void Lib_Mpd_Log2p1(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_log2p1_, res, x);
//}



/* Power functions and roots  */


//void Lib_Mpd_Square(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_sqr, res, x);
//}
//
//void Lib_Mpd_Cube(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_cube_, res, x);
//}
//
//void Lib_Mpd_Hypot(MpdPtr res, const MpdPtr x, const MpdPtr y)
//{
//    Mpd_Arb_Realfunc2_Prec(arb_hypot, res, x, y);
//}

void Lib_Mpd_Pow(MpdPtr x, const MpdPtr y, const MpdPtr z)
{
    mpd_pow( (mpd_t *) x,  (mpd_t *) y,  (mpd_t *) z, mpd_globalctx());
}

//
//void Lib_Mpd_Powm1(MpdPtr res, const MpdPtr x, const MpdPtr y)
//{
//    Mpd_Arb_Realfunc2_Prec(arb_powm1_, res, x, y);
//}
//

//void Lib_Mpd_Pow1p(MpdPtr res, const MpdPtr x, const MpdPtr y)
//{
//    Mpd_Arb_Realfunc2_Prec(arb_pow1p_, res, x, y);
//}
//
//
//void Lib_Mpd_Pow1pm1(MpdPtr res, const MpdPtr x, const MpdPtr y)
//{
//    Mpd_Arb_Realfunc2_Prec(arb_pow1pm1_, res, x, y);
//}
//
//void Lib_Mpd_Pow_Si(MpdPtr res, const MpdPtr x, const int32_t n)
//{
//    Mpd_Arb_Realfunc1Int32_Prec(arb_pow_si_, res, x, n);
//}
//
//void Lib_Mpd_Compound_Si(MpdPtr res, const MpdPtr x, const int32_t n)
//{
//    Mpd_Arb_Realfunc1Int32_Prec(arb_compound_si_, res, x, n);
//}
//









/* Trigonometric functions  */


//void Lib_Mpd_Sin(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_sin, res, x);
//}
//
//
//void Lib_Mpd_Cos(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_cos, res, x);
//}
//
//
//void Lib_Mpd_Tan(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_tan, res, x);
//}
//
//
//void Lib_Mpd_Csc(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_csc, res, x);
//}
//
//
//void Lib_Mpd_Sec(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_sec, res, x);
//}
//
//
//void Lib_Mpd_Cot(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_cot, res, x);
//}
//
//
//void Lib_Mpd_SinPi(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_sin_pi, res, x);
//}
//
//
//void Lib_Mpd_CosPi(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_cos_pi, res, x);
//}
//
//
//void Lib_Mpd_TanPi(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_tan_pi, res, x);
//}
//
//
//void Lib_Mpd_CscPi(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_csc_pi, res, x);
//}
//
//
//void Lib_Mpd_SecPi(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_sec_pi_, res, x);
//}
//
//
//void Lib_Mpd_CotPi(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_cot_pi, res, x);
//}



/* Hyperbolic functions  */


//void Lib_Mpd_Sinh(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_sinh, res, x);
//}
//
//
//void Lib_Mpd_Cosh(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_cosh, res, x);
//}
//
//
//void Lib_Mpd_Tanh(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_tanh, res, x);
//}
//
//
//void Lib_Mpd_Csch(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_csch, res, x);
//}
//
//
//void Lib_Mpd_Sech(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_sech, res, x);
//}
//
//
//void Lib_Mpd_Coth(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_coth, res, x);
//}


//
//
///* Inverse trigonometric functions  */
//
//
//void Lib_Mpd_Asin(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_asin, res, x);
//}
//
//
//void Lib_Mpd_Acos(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_acos, res, x);
//}
//
//
//void Lib_Mpd_Atan(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_atan, res, x);
//}
//
//
//void Lib_Mpd_Atan2(MpdPtr res, const MpdPtr x, const MpdPtr y)
//{
//    Mpd_Arb_Realfunc2_Prec(arb_atan2, res, x, y);
//}
//
//
//void Lib_Mpd_Acsc(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_acsc, res, x);
//}
//
//
//void Lib_Mpd_Asec(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_asec, res, x);
//}
//
//
//void Lib_Mpd_Acot(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_acot, res, x);
//}
//
//
//
///* Inverse hyperbolic functions  */
//
//
//void Lib_Mpd_Asinh(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_asinh, res, x);
//}
//
//
//void Lib_Mpd_Acosh(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_acosh, res, x);
//}
//
//
//void Lib_Mpd_Atanh(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_atanh, res, x);
//}
//
//void Lib_Mpd_Acsch(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_acsch, res, x);
//}
//
//
//void Lib_Mpd_Asech(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_asech, res, x);
//}
//
//
//void Lib_Mpd_Acoth(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_acoth, res, x);
//}
//
//
//
///* Special functions  */
//
//
//
//void Lib_Mpd_Erf(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_hypgeom_erf, res, x);
//}
//
//
//void Lib_Mpd_Erfc(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_hypgeom_erfc, res, x);
//}
//
//
//void Lib_Mpd_Tgamma(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_gamma, res, x);
//}
//
//
//void Lib_Mpd_Lgamma(MpdPtr res, const MpdPtr x)
//{
//    Mpd_Arb_Realfunc1_Prec(arb_lgamma, res, x);
//}
//
//
//
//
//




//*********************** Complex **********************************




MpdcPtr Lib_Mpdc_Init_Func()
{
	mpdc_ptr x;
	x = (mpdc_ptr)malloc(sizeof(__Mpdc_struct));
	x->real = mpd_new(mpd_globalctx());
	mpd_set_i32(x->real, 0, mpd_globalctx());
	x->imag = mpd_new(mpd_globalctx());
	mpd_set_i32(x->imag, 0, mpd_globalctx());
	return x;
}


void Lib_Mpdc_Clear(MpdcPtr x)
{
	mpd_del(((mpdc_ptr)x)->real);
	mpd_del(((mpdc_ptr)x)->imag);
	free(x);
}




void Lib_Mpdc_Set(MpdcPtr res, MpdcPtr x)
{
	mpd_copy(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, mpd_globalctx());
	mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}


void Lib_Mpdc_Set_Si(MpdcPtr res, int32_t x_re)
{
	mpd_set_i32(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_i32(((mpdc_ptr)res)->imag, 0, mpd_globalctx());
}



void Lib_Mpdc_Set_Ui(MpdcPtr res, uint32_t x_re)
{
	mpd_set_u32(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_u32(((mpdc_ptr)res)->imag, 0, mpd_globalctx());
}


void Lib_Mpdc_Set_Si64(MpdcPtr res, int64_t x_re)
{
	mpd_set_i64(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_i64(((mpdc_ptr)res)->imag, 0, mpd_globalctx());
}



void Lib_Mpdc_Set_Ui64(MpdcPtr res, uint64_t x_re)
{
	mpd_set_u64(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_u64(((mpdc_ptr)res)->imag, 0, mpd_globalctx());
}



void Lib_Mpdc_Set_D(MpdcPtr res, double x_re)
{
	char my_string[26];   //To hold . and null
	sprintf(my_string, "%.15E", x_re);
	mpd_set_string(((mpdc_ptr)res)->real, my_string, mpd_globalctx());
	mpd_set_u32(((mpdc_ptr)res)->imag, 0, mpd_globalctx());
}


void Lib_Mpdc_Set_Str(MpdcPtr res, const char * x_re)
{
	mpd_set_string(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_u32(((mpdc_ptr)res)->imag, 0, mpd_globalctx());
}


void Lib_Mpdc_Set_Si_Si(MpdcPtr res, int32_t x_re, int32_t x_im)
{
	mpd_set_i32(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_i32(((mpdc_ptr)res)->imag, x_im, mpd_globalctx());
}


void Lib_Mpdc_Set_Ui_Ui(MpdcPtr res, uint32_t x_re, uint32_t x_im)
{
	mpd_set_u32(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_u32(((mpdc_ptr)res)->imag, x_im, mpd_globalctx());
}


void Lib_Mpdc_Set_Si64_Si64(MpdcPtr res, int64_t x_re, int64_t x_im)
{
	mpd_set_i64(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_i64(((mpdc_ptr)res)->imag, x_im, mpd_globalctx());
}


void Lib_Mpdc_Set_Ui64_Ui64(MpdcPtr res, uint64_t x_re, uint64_t x_im)
{
	mpd_set_i64(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_i64(((mpdc_ptr)res)->imag, x_im, mpd_globalctx());
}



void Lib_Mpdc_Set_D_D(MpdcPtr res, double x_re, double x_im)
{
	char my_string1[26];   //To hold . and null
	sprintf(my_string1, "%.15E", x_re);
	mpd_set_string(((mpdc_ptr)res)->real, my_string1, mpd_globalctx());

	char my_string2[26];   //To hold . and null
	sprintf(my_string2, "%.15E", x_im);
	mpd_set_string(((mpdc_ptr)res)->imag, my_string2, mpd_globalctx());
}



void Lib_Mpdc_Set_Str_Str(MpdcPtr res, const char * x_re, const char * x_im)
{
	mpd_set_string(((mpdc_ptr)res)->real, x_re, mpd_globalctx());
	mpd_set_string(((mpdc_ptr)res)->imag, x_im, mpd_globalctx());
}




int32_t Lib_Mpdc_Cmp(MpdcPtr x, MpdcPtr y)
{
	int32_t rc_re = mpd_cmp(((mpdc_ptr)x)->real, ((mpdc_ptr)y)->real, mpd_globalctx());
	int32_t rc_im = mpd_cmp(((mpdc_ptr)x)->imag, ((mpdc_ptr)y)->imag, mpd_globalctx());
	return ((rc_re == 0) && (rc_im == 0));
}



void Lib_Mpdc_Neg(MpdcPtr res, MpdcPtr x)
{
	mpd_minus(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, mpd_globalctx());
	mpd_minus(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}




void Lib_Mpdc_Add(MpdcPtr res, MpdcPtr x, MpdcPtr y)
{
	mpd_add(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, ((mpdc_ptr)y)->real, mpd_globalctx());
	mpd_add(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, ((mpdc_ptr)y)->imag, mpd_globalctx());
}


void Lib_Mpdc_Sub(MpdcPtr res, MpdcPtr x, MpdcPtr y)
{
	mpd_sub(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, ((mpdc_ptr)y)->real, mpd_globalctx());
	mpd_sub(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, ((mpdc_ptr)y)->imag, mpd_globalctx());
}


//void Lib_Mpdc_Mul(MpdcPtr res, MpdcPtr x, MpdcPtr y)
//{
//	Mpdc_Cplxfunc2(res, mp_cplxfunc2_mul, mpfr_get_default_prec(), x, y);
//}
//
//
//void Lib_Mpdc_Div(MpdcPtr res, MpdcPtr x, MpdcPtr y)
//{
//	Mpdc_Cplxfunc2(res, mp_cplxfunc2_div, mpfr_get_default_prec(), x, y);
//}




void Lib_Mpdc_Add_Mpd(MpdcPtr res, MpdcPtr x, MpdPtr y)
{
	mpd_add(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, (mpd_t *) y, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}



void Lib_Mpdc_Sub_Mpd(MpdcPtr res, MpdcPtr x, MpdPtr y)
{
	mpd_sub(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, (mpd_t *) y, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}


void Lib_Mpdc_Mpd_Sub(MpdcPtr res, MpdcPtr y, MpdPtr x)
{
	mpd_sub(((mpdc_ptr)res)->real, (mpd_t *) x, ((mpdc_ptr)y)->real, mpd_globalctx());
    mpd_minus(((mpdc_ptr)res)->imag, ((mpdc_ptr)y)->imag, mpd_globalctx());
}



void Lib_Mpdc_Mul_Mpd(MpdcPtr res, MpdcPtr x, MpdPtr y)
{
	mpd_mul(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, (mpd_t *) y, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}


void Lib_Mpdc_Div_Mpd(MpdcPtr res, MpdcPtr x, MpdPtr y)
{
	mpd_div(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, (mpd_t *) y, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}

//
//void Lib_Mpdc_Mpd_Div(MpdcPtr res, MpdcPtr y, MpdPtr x)
//{
//    MpdcPtr temp = Lib_Mpdc_Init_Func();
//    mpd_copy(((mpdc_ptr)temp)->real, (mpd_t *) x, mpd_globalctx());
//	Mpdc_Cplxfunc2(res, mp_cplxfunc2_div, mpfr_get_default_prec(), temp, y);
//    Lib_Mpdc_Clear(temp);
//}
//





void Lib_Mpdc_Add_D(MpdcPtr res, MpdcPtr x, double y)
{
	mpd_t* t; t = mpd_new(mpd_globalctx()); Lib_Mpd_Set_D(t, y);
	mpd_add(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, t, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
	mpd_del((mpd_t *)t);
}



void Lib_Mpdc_Sub_D(MpdcPtr res, MpdcPtr x, double y)
{
	mpd_t* t; t = mpd_new(mpd_globalctx()); Lib_Mpd_Set_D(t, y);
	mpd_sub(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, t, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
	mpd_del((mpd_t *)t);
}


void Lib_Mpdc_D_Sub(MpdcPtr res, MpdcPtr y, double x)
{
	mpd_t* t; t = mpd_new(mpd_globalctx()); Lib_Mpd_Set_D(t, x);
	mpd_sub(((mpdc_ptr)res)->real, t, ((mpdc_ptr)y)->real, mpd_globalctx());
    mpd_minus(((mpdc_ptr)res)->imag, ((mpdc_ptr)y)->imag, mpd_globalctx());
	mpd_del((mpd_t *)t);
}



void Lib_Mpdc_Mul_D(MpdcPtr res, MpdcPtr x, double y)
{
	mpd_t* t; t = mpd_new(mpd_globalctx()); Lib_Mpd_Set_D(t, y);
	mpd_mul(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, t, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
	mpd_del((mpd_t *)t);
}


void Lib_Mpdc_Div_D(MpdcPtr res, MpdcPtr x, double y)
{
	mpd_t* t; t = mpd_new(mpd_globalctx()); Lib_Mpd_Set_D(t, y);
	mpd_div(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, t, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
	mpd_del((mpd_t *)t);
}

//
//void Lib_Mpdc_D_Div(MpdcPtr res, MpdcPtr y, double x)
//{
//	mpd_t* t; t = mpd_new(mpd_globalctx()); Lib_Mpd_Set_D(t, x);
//    MpdcPtr temp = Lib_Mpdc_Init_Func();
//    mpd_copy(((mpdc_ptr)temp)->real, t, mpd_globalctx());
//	Mpdc_Cplxfunc2(res, mp_cplxfunc2_div, mpfr_get_default_prec(), temp, y);
//    Lib_Mpdc_Clear(temp);
//	mpd_del((mpd_t *)t);
//}
//





void Lib_Mpdc_Add_Si(MpdcPtr res, MpdcPtr x, int32_t y)
{
	mpd_add_i32(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, y, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}


void Lib_Mpdc_Sub_Si(MpdcPtr res, MpdcPtr x, int32_t y)
{
	mpd_sub_i32(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, y, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}


void Lib_Mpdc_Si_Sub(MpdcPtr res, MpdcPtr y, int32_t x)
{
	mpd_sub_i32(((mpdc_ptr)res)->real, ((mpdc_ptr)y)->real, x, mpd_globalctx());
    mpd_minus(((mpdc_ptr)res)->imag, ((mpdc_ptr)y)->imag, mpd_globalctx());
}


void Lib_Mpdc_Mul_Si(MpdcPtr res, MpdcPtr x, int32_t y)
{
	mpd_mul_i32(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, y, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}


void Lib_Mpdc_Div_Si(MpdcPtr res, MpdcPtr x, int32_t y)
{
	mpd_div_i32(((mpdc_ptr)res)->real, ((mpdc_ptr)x)->real, y, mpd_globalctx());
    mpd_copy(((mpdc_ptr)res)->imag, ((mpdc_ptr)x)->imag, mpd_globalctx());
}

//
//void Lib_Mpdc_Si_Div(MpdcPtr res, MpdcPtr y, int32_t x)
//{
//    MpdcPtr temp = Lib_Mpdc_Init_Func();
//    mpd_set_i32(((mpdc_ptr)temp)->real,  x, mpd_globalctx());
//	Mpdc_Cplxfunc2(res, mp_cplxfunc2_div, mpfr_get_default_prec(), temp, y);
//    Lib_Mpdc_Clear(temp);
//}
//





/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */


/* Mathematical Constants  */




/* Complex components  */

void Lib_Mpdc_Set_Real(MpdcPtr res, MpdPtr x_re)
{
	mpd_copy(((mpdc_ptr)res)->real, ((mpd_t*)x_re), mpd_globalctx());
	mpd_set_i32(((mpdc_ptr)res)->imag, 0, mpd_globalctx());
}

void Lib_Mpdc_Set2(MpdcPtr res, MpdPtr x_re, MpdPtr x_im)
{
	mpd_copy(((mpdc_ptr)res)->real, ((mpd_t*)x_re), mpd_globalctx());
	mpd_copy(((mpdc_ptr)res)->imag, ((mpd_t*)x_im), mpd_globalctx());
}

/* TODO */
void Lib_Mpdc_Abs(MpdPtr res, MpdcPtr x)
{
	mpd_copy((mpd_t *)res, ((mpdc_ptr)x)->real, mpd_globalctx());
}

/* TODO */
void Lib_Mpdc_Arg(MpdPtr res, MpdcPtr x)
{
	mpd_copy((mpd_t *)res, ((mpdc_ptr)x)->imag, mpd_globalctx());
}

void Lib_Mpdc_Real(MpdPtr res, MpdcPtr x)
{
	mpd_copy((mpd_t *)res, ((mpdc_ptr)x)->real, mpd_globalctx());
}

void Lib_Mpdc_Imag(MpdPtr res, MpdcPtr x)
{
	mpd_copy((mpd_t *)res, ((mpdc_ptr)x)->imag, mpd_globalctx());
}

/* TODO */
void Lib_Mpdc_Conj(MpdPtr res, MpdcPtr x)
{
	mpd_copy((mpd_t *)res, ((mpdc_ptr)x)->real, mpd_globalctx());
}

/* TODO */
void Lib_Mpdc_Proj(MpdPtr res, MpdcPtr x)
{
	mpd_copy((mpd_t *)res, ((mpdc_ptr)x)->imag, mpd_globalctx());
}






/* Roots and related functions  */

//void Lib_Mpdc_Sqrt(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_sqrt, res, x);
//}
//
//void Lib_Mpdc_Sqrt1pm1(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_sqrt1pm1, res, x);
//}
//
//void Lib_Mpdc_Rsqrt(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_rsqrt, res, x);
//}
//
//void Lib_Mpdc_Cbrt(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_cbrt, res, x);
//}
//
//
//void Lib_Mpdc_Root_Si(MpdcPtr res, const MpdcPtr x, const int32_t n)
//{
//    Mpdc_Acb_Cplxfunc1Int32_Prec(acb_root_si_, res, x, n);
//}
//


/* Exponential and related functions  */


//void Lib_Mpdc_Exp(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_exp, res, x);
//}
//
//void Lib_Mpdc_Expi(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_expj_, res, x);
//}
//
//void Lib_Mpdc_Exp2(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_exp2_, res, x);
//}
//
//void Lib_Mpdc_Exp10(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_exp10_, res, x);
//}
//
//
//
//void Lib_Mpdc_Expm1(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_expm1, res, x);
//}
//
//void Lib_Mpdc_Exp2m1(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_exp2_, res, x);
//}
//
//void Lib_Mpdc_Exp10m1(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_exp10m1_, res, x);
//}
//
//
//
//
//
///* Logarithms and related functions  */
//
//void Lib_Mpdc_Log(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_log, res, x);
//}
//
//void Lib_Mpdc_Log2(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_log2_, res, x);
//}
//
//void Lib_Mpdc_Log10(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_log10_, res, x);
//}
//
//
//
//
//void Lib_Mpdc_Log1p(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_log1p, res, x);
//}
//
//void Lib_Mpdc_Log2p1(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_log2p1_, res, x);
//}
//
//void Lib_Mpdc_Log10p1(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_log10p1_, res, x);
//}
//
//
//
//
//
///* Power functions and roots  */
//
//
//void Lib_Mpdc_Square(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_sqr, res, x);
//}
//
//
//void Lib_Mpdc_Cube(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_cube, res, x);
//}
//
//
//
//void Lib_Mpdc_Pow(MpdcPtr res, const MpdcPtr x, const MpdcPtr y)
//{
//    Mpdc_Acb_Cplxfunc2_Prec(acb_pow, res, x, y);
//}
//
//
//void Lib_Mpdc_Powm1(MpdcPtr res, const MpdcPtr x, const MpdcPtr y)
//{
//    Mpdc_Acb_Cplxfunc2_Prec(acb_powm1_, res, x, y);
//}
//
//
//void Lib_Mpdc_Pow1p(MpdcPtr res, const MpdcPtr x, const MpdcPtr y)
//{
//    Mpdc_Acb_Cplxfunc2_Prec(acb_pow1p_, res, x, y);
//}
//
//
//void Lib_Mpdc_Pow1pm1(MpdcPtr res, const MpdcPtr x, const MpdcPtr y)
//{
//    Mpdc_Acb_Cplxfunc2_Prec(acb_pow1pm1_, res, x, y);
//}
//
//
//
//void Lib_Mpdc_Pow_Si(MpdcPtr res, const MpdcPtr x, const int32_t n)
//{
//    Mpdc_Acb_Cplxfunc1Int32_Prec(acb_pow_si_, res, x, n);
//}
//
//
//void Lib_Mpdc_Compound_Si(MpdcPtr res, const MpdcPtr x, const int32_t n)
//{
//    Mpdc_Acb_Cplxfunc1Int32_Prec(acb_compound_si_, res, x, n);
//}
//
//
//
//
//
//
///* Trigonometric functions  */
//
//void Lib_Mpdc_Sin(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_sin, res, x);
//}
//
//void Lib_Mpdc_Cos(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_cos, res, x);
//}
//
//void Lib_Mpdc_Tan(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_tan, res, x);
//}
//
//
//void Lib_Mpdc_Csc(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_csc, res, x);
//}
//
//
//void Lib_Mpdc_Sec(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_sec, res, x);
//}
//
//
//void Lib_Mpdc_Cot(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_cot, res, x);
//}
//
//
//void Lib_Mpdc_SinPi(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_sin_pi, res, x);
//}
//
//
//void Lib_Mpdc_CosPi(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_cos_pi, res, x);
//}
//
//
//void Lib_Mpdc_TanPi(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_tan_pi, res, x);
//}
//
//
//
//
//
///* Hyperbolic functions  */
//
//void Lib_Mpdc_Sinh(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_sinh, res, x);
//}
//
//void Lib_Mpdc_Cosh(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_cosh, res, x);
//}
//
//void Lib_Mpdc_Tanh(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_tanh, res, x);
//}
//
//
//void Lib_Mpdc_Csch(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_csch, res, x);
//}
//
//
//void Lib_Mpdc_Sech(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_sech, res, x);
//}
//
//
//void Lib_Mpdc_Coth(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_coth, res, x);
//}
//
//
//
//
///* Inverse trigonometric functions  */
//
//void Lib_Mpdc_Asin(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_asin, res, x);
//}
//
//void Lib_Mpdc_Acos(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_acos, res, x);
//}
//
//void Lib_Mpdc_Atan(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_atan, res, x);
//}
//
//
//
//void Lib_Mpdc_Acsc(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_acsc, res, x);
//}
//
//
//void Lib_Mpdc_Asec(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_asec, res, x);
//}
//
//
//void Lib_Mpdc_Acot(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_acot, res, x);
//}
//
//
//
//
//
//
//
//
///* Inverse hyperbolic functions  */
//
//void Lib_Mpdc_Asinh(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_asinh, res, x);
//}
//
//void Lib_Mpdc_Acosh(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_acosh, res, x);
//}
//
//void Lib_Mpdc_Atanh(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_atanh, res, x);
//}
//
//
//void Lib_Mpdc_Acsch(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_acsch, res, x);
//}
//
//
//void Lib_Mpdc_Asech(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_asech, res, x);
//}
//
//
//void Lib_Mpdc_Acoth(MpdcPtr res, const MpdcPtr x)
//{
//    Mpdc_Acb_Cplxfunc1_Prec(acb_acoth, res, x);
//}
//
//





/* Extra functions for Mpd  */




int32_t Lib_Mpd_IsSpecial(MpdPtr a)
{
    return mpd_isspecial((mpd_t *) a);
}

int32_t Lib_Mpd_IsNormal(MpdPtr result)
{
    return mpd_isnormal( (mpd_t *) result, mpd_globalctx());
}






void Lib_Mpd_Quantize(MpdPtr result, MpdPtr a, MpdPtr b)
{
    mpd_quantize( (mpd_t *) result,  (mpd_t *) a, (mpd_t *) b, mpd_globalctx());
}


void Lib_Mpd_Rescale(MpdPtr result, MpdPtr a, int32_t exp)
{
    mpd_rescale( (mpd_t *) result,  (mpd_t *) a, exp, mpd_globalctx());
}


int32_t Lib_Mpd_Same_Quantum(MpdPtr a, MpdPtr b)
{
    return mpd_same_quantum((mpd_t *) a, (mpd_t *) b);
}


void Lib_Mpd_Reduce(MpdPtr result, MpdPtr a)
{
    mpd_reduce( (mpd_t *) result,  (mpd_t *) a, mpd_globalctx());
}



















