
#include "mpNumC_Main.h"
#include "BoostDouble.h"




//*********************** Numerical Calculus **********************************





void Lib_Double_BracketRoot(double* res1, double* res2, int* iter, DoubleFuncPtr f1, double guess, double factor, bool is_rising, int get_digits, unsigned int maxit)
{
    LibDouble_BracketRoot(res1, res2, iter, f1, guess, factor, is_rising, get_digits, maxit);
}



void Lib_Double_NewtonRaphson(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
{
    LibDouble_NewtonRaphson(res, iter, f1, f2, guess, xmin, xmax, get_digits, maxit);
}



void Lib_Double_Halley(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
{
    LibDouble_Halley(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
}



void Lib_Double_Schroder(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
{
    LibDouble_Schroder(res, iter, f1, f2, f3, guess, xmin, xmax, get_digits, maxit);
}



void Lib_Double_Brent_Minimum(double* res, double* resFx, int* iter, DoubleFuncPtr f1, double bracket_min, double bracket_max, int bits, unsigned int maxit)
{
    LibDouble_Brent_Minimum(res, resFx, iter, f1, bracket_min, bracket_max, bits, maxit);
}




void Lib_Double_Trapezoidal(double* res1, double* res2, double* res3, DoubleFuncPtr f1, double a, double b)
{
    LibDouble_Trapezoidal(res1, res2, res3, f1, a, b);
}


// 7, 15, 20, 25 and 30

void Lib_Double_GaussLegendre(double* res1, double* res3, DoubleFuncPtr f1, double a, double b)
{
    LibDouble_GaussLegendre(res1, res3, f1, a, b);
}



//15, 31, 41, 51 and 61

void Lib_Double_GaussKronrod(double* res1, double* res2, double* res3, DoubleFuncPtr f1, double a, double b)
{
    LibDouble_GaussKronrod(res1, res2, res3, f1, a, b);
}



void Lib_Double_TanhSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1, double a, double b)
{
    LibDouble_TanhSinh(res1, res2, res3, levels_, f1, a, b);
}



void Lib_Double_SinhSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1)
{
    LibDouble_SinhSinh(res1, res2, res3, levels_, f1);
}



void Lib_Double_ExpSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1)
{
    LibDouble_ExpSinh(res1, res2, res3, levels_, f1);
}



void Lib_Double_Ooura_Cos(double* res1, double* res2, DoubleFuncPtr f1)
{
    LibDouble_Ooura_Cos(res1, res2, f1);
}



void Lib_Double_Ooura_Sin(double* res1, double* res2, DoubleFuncPtr f1)
{
    LibDouble_Ooura_Sin(res1, res2, f1);
}



void Lib_Double_Ooura_Cos2(double* res1, double* res2, DoubleFuncPtr f1, double omega)
{
    LibDouble_Ooura_Cos2(res1, res2, f1, omega);
}



void Lib_Double_Ooura_Sin2(double* res1, double* res2, DoubleFuncPtr f1, double omega)
{
    LibDouble_Ooura_Sin2(res1, res2, f1, omega);
}


