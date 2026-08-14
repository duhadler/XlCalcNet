#include <algorithm>
#include <vector>
#include <Eigen/StdVector>

#include "libBoostEigenDense.h"



/*  Begin   */

mpMatrixPtr EigenLib_mpType_Init_Func(mpMatrixPtr dummy)
{
    mpMatrixPtr x = new(mpMatrix);
    (*x).resize(1, 1);
    (*x).setZero();
    return x;
}


mpMatrixPtr EigenLib_mpType_Init_Func_N(mpMatrixPtr dummy, int N)
{
    mpMatrixPtr x = new(mpMatrix);
    (*x).resize(N, 1);
    (*x).setZero();
    return x;
}





void EigenLib_mpType_Clear(mpMatrixPtr x)
{
    delete (x);
}


