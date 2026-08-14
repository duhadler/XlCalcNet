

#include "libBoostEigen.h"



/**************************** Eigen Calculus *********************************************************/


//void testHybrj_ext(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matFvec_, mpMatrixPtr matFjac_, mpMatrixPtr matInput);
//void testLmder_ext(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matFvec_, mpMatrixPtr matFjac_, mpMatrixPtr matInput);

void EigenLib_mpType_CppOptLibDirect(long what, AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr, mpVectorPtr resPtr);



void demoLinearRegression();
void demoLogisticRegression();






