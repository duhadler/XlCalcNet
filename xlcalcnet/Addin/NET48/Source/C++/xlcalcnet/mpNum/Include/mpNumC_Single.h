

#ifndef MPNUMC_SINGLE_H_INCLUDED
#define MPNUMC_SINGLE_H_INCLUDED




//*********************** Boost Numerical Calculus, single precision, float **********************************


typedef float(*SingleFuncPtr) (float);


MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_BracketRoot(float* res1, float* res2, int* iter, SingleFuncPtr f1, float guess, float factor, bool is_rising, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_NewtonRaphson(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, float guess, float xmin, float xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_Halley(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3, float guess, float xmin, float xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_Schroder(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3, float guess, float xmin, float xmax, int get_digits, unsigned int maxit);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_Brent_Minimum(float* res, float* resFx, int* iter, SingleFuncPtr f1, float bracket_min, float bracket_max, int bits, unsigned int maxit);



MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_Trapezoidal(float* res1, float* res2, float* res3, SingleFuncPtr f1, float a, float b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_GaussLegendre(float* res1, float* res3, SingleFuncPtr f1, float a, float b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_GaussKronrod(float* res1, float* res2, float* res3, SingleFuncPtr f1, float a, float b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_TanhSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1, float* a, float* b);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_SinhSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_ExpSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_Ooura_Cos(float* res1, float* res2, SingleFuncPtr f1);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Single_Ooura_Sin(float* res1, float* res2, SingleFuncPtr f1);





#endif // MPNUMC_SINGLE_H_INCLUDED



