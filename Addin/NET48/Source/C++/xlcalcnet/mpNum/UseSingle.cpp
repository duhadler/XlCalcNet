
#include "mpNumC_Main.h"
#include "BoostSingle.h"




//*********************** Numerical Calculus **********************************





void Lib_Single_BracketRoot(float* res1, float* res2, int* iter, SingleFuncPtr f1, float guess, float factor, bool is_rising, int get_digits, unsigned int maxit)
{
    LibSingle_BracketRoot(res1, res2, iter, f1, guess, factor, is_rising, get_digits, maxit);
}



void Lib_Single_NewtonRaphson(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, float guess, float xmin, float xmax, int get_digits, unsigned int maxit)
{
    LibSingle_NewtonRaphson(res, iter, f1, f2, guess, xmin, xmax, get_digits, maxit);
}



void Lib_Single_Halley(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3, float guess, float xmin, float xmax, int get_digits, unsigned int maxit)
{
    LibSingle_Halley(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
}



void Lib_Single_Schroder(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3, float guess, float xmin, float xmax, int get_digits, unsigned int maxit)
{
    LibSingle_Schroder(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
}



void Lib_Single_Brent_Minimum(float* res, float* resFx, int* iter, SingleFuncPtr f1, float bracket_min, float bracket_max, int bits, unsigned int maxit)
{
    LibSingle_Brent_Minimum(res, resFx, iter, f1, bracket_min, bracket_max, bits, maxit);
}




void Lib_Single_Trapezoidal(float* res1, float* res2, float* res3, SingleFuncPtr f1, float a, float b)
{
    LibSingle_Trapezoidal(res1, res2, res3, f1, a, b);
}


// 7, 15, 20, 25 and 30

void Lib_Single_GaussLegendre(float* res1, float* res3, SingleFuncPtr f1, float a, float b)
{
    LibSingle_GaussLegendre(res1, res3, f1, a, b);
}



//15, 31, 41, 51 and 61

void Lib_Single_GaussKronrod(float* res1, float* res2, float* res3, SingleFuncPtr f1, float a, float b)
{
    LibSingle_GaussKronrod(res1, res2, res3, f1, a, b);
}



void Lib_Single_TanhSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1, float* a, float* b)
{
    LibSingle_TanhSinh(res1, res2, res3, levels_, f1, a, b);
}



void Lib_Single_SinhSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1)
{
    LibSingle_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_Single_ExpSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1)
{
    LibSingle_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_Single_Ooura_Cos(float* res1, float* res2, SingleFuncPtr f1)
{
    LibSingle_Ooura_Cos(res1, res2, f1);
}



void Lib_Single_Ooura_Sin(float* res1, float* res2, SingleFuncPtr f1)
{
    LibSingle_Ooura_Sin(res1, res2, f1);
}


