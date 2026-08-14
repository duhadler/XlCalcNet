#include <algorithm>
#include <vector>
#include <Eigen/StdVector>

#include "libBoostEigenDense.h"
#include <boost/multiprecision/cpp_dec_float.hpp>

using namespace boost::multiprecision;



/*  Begin   */

typedef void* DRealPtr;

mpMatrixPtr EigenLib_Dec50_Init_Func_N(int N)
{
    mpMatrixPtr x = new(mpMatrix);
    (*x).resize(N, 1);
    (*x).setZero();
    return x;
}





void EigenLib_Dec50_Clear(mpMatrixPtr x)
{
    delete ((mpMatrixPtr)x);
}




void EigenLib_Dec50_GetCoeff(DRealPtr res, long row, long col, mpMatrixPtr source, int digits)
{
    (*(cpp_dec_float_50*)res) = (*(mpMatrixPtr) source).coeff(row,col);
}



void EigenLib_Dec50_SetCoeff(mpMatrixPtr result, DRealPtr source, long row, long col, int digits)
{
    (*(mpMatrixPtr) result)(row,col) = *(cpp_dec_float_50*)source;
}


