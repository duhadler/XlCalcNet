

#ifndef MPNUMC_DOUBLE_H_INCLUDED
#define MPNUMC_DOUBLE_H_INCLUDED




//*********************** Boost Numerical Calculus, double precision, Double **********************************


typedef double(*DoubleFuncPtr) (double);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_BracketRoot(double* res1, double* res2, int* iter, DoubleFuncPtr f1, double guess, double factor, bool is_rising, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_NewtonRaphson(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, double guess, double xmin, double xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_Halley(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_Schroder(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_Brent_Minimum(double* res, double* resFx, int* iter, DoubleFuncPtr f1, double bracket_min, double bracket_max, int bits, unsigned int maxit);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_Trapezoidal(double* res1, double* res2, double* res3, DoubleFuncPtr f1, double a, double b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_GaussLegendre(double* res1, double* res3, DoubleFuncPtr f1, double a, double b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_GaussKronrod(double* res1, double* res2, double* res3, DoubleFuncPtr f1, double a, double b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_TanhSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1, double a, double b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_SinhSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_ExpSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_Ooura_Cos(double* res1, double* res2, DoubleFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_Ooura_Sin(double* res1, double* res2, DoubleFuncPtr f1);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_Ooura_Cos2(double* res1, double* res2, DoubleFuncPtr f1, double omega);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Double_Ooura_Sin2(double* res1, double* res2, DoubleFuncPtr f1, double omega);




#endif // MPNUMC_DOUBLE_H_INCLUDED



