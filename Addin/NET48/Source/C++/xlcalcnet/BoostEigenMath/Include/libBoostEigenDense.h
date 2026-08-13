

#include "libBoostEigen.h"



void EigenLib_mpType_MultipleResults(mpmapPtr names, int32_t what, string str2, mpMatrixPtr A, mpMatrixPtr b);
void EigenLib_cplx_mpType_MultipleResults(mpmapPtr names, int32_t what, string str2, mpCplxMatrixPtr A, mpCplxMatrixPtr b);

mpmapPtr MapLib_mpType_Init_Func(mpMatrixPtr dummy);
mpmapPtr MapLib_cplx_mpType_Init_Func(mpCplxMatrixPtr dummy);
void MapLib_mpType_Clear(mpmapPtr names, mpMatrixPtr dummy);
void MapLib_cplx_mpType_Clear(mpmapPtr names, mpCplxMatrixPtr dummy);
void MapLib_mpType_GetItemValue(mpMatrixPtr ptr, mpmapPtr names, char *s);
void MapLib_cplx_mpType_GetItemValue(mpCplxMatrixPtr ptr, mpmapPtr names, char *s);



// ************************** General Functions **********************************

mpMatrixPtr EigenLib_mpType_Init_Func(mpMatrixPtr dummy);
void EigenLib_mpType_Init(mpMatrixPtr* x);
void EigenLib_mpType_Clear(mpMatrixPtr x);

void EigenLib_mpType_Sort(mpMatrixPtr x, int32_t SortOrder, int32_t SortCriterion);
void EigenLib_mpType_SortRowsByColumn(mpMatrixPtr A, int32_t ColumnToSortBy, int32_t SortOrder, int32_t SortCriterion);
void EigenLib_mpType_Select_Rows(mpMatrixPtr res, mpMatrixPtr A);



void EigenLib_mpType_GetInfo(long *result, long what, mpMatrix *x);
void EigenLib_mpType_PutBlock(mpMatrix *result, long what, long i, long j, long p, long q, mpMatrix *source);
void EigenLib_mpType_GetBlock(mpMatrix *result, long what, long i, long j, long p, long q, mpMatrix *source);
void EigenLib_mpType_SetSpecialValue(mpMatrix *result, long what, int32_t m, int32_t n);
void EigenLib_mpType_SetSpecialValue2(mpMatrix *result, long what, long Vertical, long Horizontal, long PartialMode, mpMatrix *source);

void EigenLib_mpType_Compare(long* result, long what, mpMatrix *x, mpMatrix *y);
void EigenLib_mpType_BasicArithmetic(mpMatrix *result, long what, mpMatrix *x, mpMatrix *y);
void EigenLib_mpType_Stats(mpMatrix *result, long what, long PartialMode, mpMatrix *source);
void EigenLib_mpType_Stats2(mpMatrix *result, long *res_IndexX, long *res_IndexY, long what, mpMatrix *source);





//***************************************************************
//***************************************************************

mpCplxMatrixPtr EigenLib_cplx_mpType_Init_Func(mpCplxMatrixPtr dummy);

void EigenLib_cplx_mpType_Init(mpCplxMatrixPtr* x);
void EigenLib_cplx_mpType_Clear(mpCplxMatrixPtr x);


void EigenLib_cplx_mpType_Sort(mpCplxMatrixPtr x, int32_t SortOrder, int32_t SortCriterion);
void EigenLib_cplx_mpType_SortRowsByColumn(mpCplxMatrixPtr A, int32_t ColumnToSortBy, int32_t SortOrder, int32_t SortCriterion);
void EigenLib_cplx_mpType_Select_Rows(mpCplxMatrixPtr res, mpCplxMatrixPtr A);

void EigenLib_cplx_mpType_GetInfo(long *result, long what, mpMatrixC *x);
void EigenLib_cplx_mpType_PutBlock(mpMatrixC *result, long what, long i, long j, long p, long q, mpMatrixC *source);
void EigenLib_cplx_mpType_GetBlock(mpMatrixC *result, long what, long i, long j, long p, long q, mpMatrixC *source);

void EigenLib_cplx_mpType_SetSpecialValue(mpMatrixC *result, long what, int32_t m, int32_t n);
void EigenLib_cplx_mpType_SetSpecialValue2(mpMatrixC *result, long what, long Vertical, long Horizontal, long PartialMode, mpMatrixC *source);

void EigenLib_cplx_mpType_Compare(long* result, long what, mpMatrixC *x, mpMatrixC *y);
void EigenLib_cplx_mpType_BasicArithmetic(mpMatrixC *result, long what, mpMatrixC *x, mpMatrixC *y);

void EigenLib_cplx_mpType_Stats(mpMatrixC* result, long what, long PartialMode, mpMatrixC* source);
void EigenLib_ConvertRealCplx(mpMatrix *RMat, int32_t what, mpMatrixC *CMat);
void EigenLib__mpType_CplxScalarArithmetic(mpMatrixC *result, long what, mpMatrix *x, mpType *f_re, mpType *f_im);

//************************Nonlinear Optimization***************************************


void testHybrj_ext(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matFvec_, mpMatrixPtr matFjac_, mpMatrixPtr matInput);
void testLmder_ext(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matFvec_, mpMatrixPtr matFjac_, mpMatrixPtr matInput);


//************************FFT***************************************


void EigenLib_cplx_mpType_FFT_fwd(mpCplxMatrixPtr fft_result, mpCplxMatrixPtr fft_source);
void EigenLib_cplx_mpType_FFT_inv(mpCplxMatrixPtr fft_result,  mpCplxMatrixPtr fft_source);

void EigenLib_mpType_FFT_real_fwd(mpCplxMatrixPtr fft_result, mpMatrixPtr fft_source);
void EigenLib_mpType_FFT_real_inv(mpMatrixPtr fft_result,  mpCplxMatrixPtr fft_source);



//************************Matrix Functions***************************************

void EigenLib_mpType_MatrixFunction(mpMatrix *result, long what, mpMatrix *A);
void EigenLib_cplx_mpType_MatrixFunction(mpMatrixC *result, long what, mpMatrixC *A);




//************************Polynomials***************************************

void EigenLib_mpType_Roots_To_MonicPolynomial(mpMatrixPtr polynomial_result, mpMatrixPtr roots_source);
void EigenLib_mpType_Poly_Eval(mpMatrixPtr evaluation_result, mpMatrixPtr polynomial_source, mpMatrixPtr roots_source);
void EigenLib_mpType_Poly_Eval_Complex(mpCplxMatrixPtr evaluation_result, mpMatrixPtr polynomial_source, mpCplxMatrixPtr roots_source);
void EigenLib_mpType_PolynomialSolver(mpCplxMatrixPtr cplxroots_result, mpMatrixPtr polynomial_source);

void EigenLib_cplx_mpType_Roots_To_MonicPolynomial(mpCplxMatrixPtr polynomial_result, mpCplxMatrixPtr roots_source);
void EigenLib_cplx_mpType_Poly_Eval_Complex(mpCplxMatrixPtr evaluation_result, mpCplxMatrixPtr polynomial_source, mpCplxMatrixPtr roots_source);
void EigenLib_cplx_mpType_PolynomialSolver(mpCplxMatrixPtr cplxroots_result, mpCplxMatrixPtr polynomial_source);





/**************************** Eigen Calculus *********************************************************/

void EigenLib_mpType_CppOptLibDirect1(long what, AnyFuncPtr f1, mpMatrixPtr matX, mpMatrixPtr matNorm, mpMatrixPtr xPtr, mpMatrixPtr resPtr);

void EigenLib_mpType_CppOptLibDirect2(long what, AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr);

void EigenLib_mpType_CppOptLibDirect3(long what, AnyFuncPtr f1, AnyFuncPtr f2, AnyFuncPtr f3, mpMatrixPtr matX, mpMatrixPtr matHessian, mpMatrixPtr matGrad, mpMatrixPtr matNorm, mpMatrixPtr xPtr, mpMatrixPtr resPtr);


//void demoLinearRegression();
//void demoLogisticRegression();


