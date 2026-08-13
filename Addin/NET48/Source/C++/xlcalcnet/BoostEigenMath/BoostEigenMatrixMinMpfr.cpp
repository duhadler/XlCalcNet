#include <algorithm>
#include <vector>
#include <Eigen/StdVector>

#include "libBoostEigenDense.h"
#include <boost/multiprecision/mpfr.hpp>

using namespace boost::multiprecision;

/*  Begin   */



mpMatrixPtr EigenLib_Mpfr_Init_Func_N(int N, int digits)
{
    mpfr_float::default_precision(digits);  // in decimal digits
    mpMatrixPtr x = new(mpMatrix);
    (*x).resize(N, 1);
    (*x).setZero();
    return x;
}





void EigenLib_Mpfr_Clear(mpMatrixPtr x)
{
    delete (x);
}




void EigenLib_Mpfr_GetCoeff(mpfr_ptr res, long row, long col, mpMatrixPtr source, int digits)
{
    mpfr_float::default_precision(digits);  // in decimal digits
    mpfr_set((mpfr_ptr)res, (*(mpMatrixPtr) source).coeff(row,col).backend().data(), GMP_RNDN);
}



void EigenLib_Mpfr_SetCoeff(mpMatrixPtr result, mpfr_ptr source, long row, long col, int digits)
{
    mpfr_float::default_precision(digits);  // in decimal digits
    (*(mpMatrixPtr) result)(row,col) = mpfr_float((mpfr_ptr)source);
}

