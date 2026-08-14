

#include "libBoostEigen.h"


// ************************** General Real Functions **********************************

void PrintSparseMatrix(mpSparseMatrix *M);


mpSparseMatrixPtr EigenSparseLib_mpType_Init_Func(mpSparseMatrixPtr dummy);
void EigenSparseLib_mpType_Init(mpSparseMatrixPtr* x);
void EigenSparseLib_mpType_Clear(mpSparseMatrixPtr x);

void EigenSparseLib_mpType_GetInfo(long *result, long what, mpSparseMatrix *x);
void EigenSparseLib_mpType_PutBlock(mpSparseMatrix *result, long what, long i, long j, long p, long q, mpSparseMatrix *source);
void EigenSparseLib_mpType_GetBlock(mpSparseMatrix *result, long what, long i, long j, long p, long q, mpSparseMatrix *source);
void EigenSparseLib_mpType_SetSpecialValue(mpSparseMatrix *result, long what, int32_t m, int32_t n);
void EigenSparseLib_mpType_SetSpecialValue2(mpSparseMatrix *result, long what, long Vertical, long Horizontal, long PartialMode, mpSparseMatrix *source);

void EigenSparseLib_mpType_BasicArithmetic(mpSparseMatrix *result, long what, mpSparseMatrix *x, mpSparseMatrix *y);
void EigenSparseLib_mpType_Stats(mpSparseMatrix *result, long what, long PartialMode, mpSparseMatrix *source);

void EigenSparseLib_mpType_DenseFromSparse(mpMatrix *result, mpSparseMatrix *source);
void EigenSparseLib_mpType_SparseFromDense(mpSparseMatrix *result, mpMatrix *source);

void EigenSparseLib_mpType_Solve(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b, long Decomposition);



// ************************** General Complex Functions **********************************

mpCplxSparseMatrixPtr EigenSparseLib_cplx_mpType_Init_Func(mpCplxSparseMatrixPtr dummy);

void EigenSparseLib_cplx_mpType_Init(mpCplxSparseMatrixPtr* x);
void EigenSparseLib_cplx_mpType_Clear(mpCplxSparseMatrixPtr x);

void EigenSparseLib_cplx_mpType_GetInfo(long *result, long what, mpSparseMatrixC *x);
void EigenSparseLib_cplx_mpType_PutBlock(mpSparseMatrixC *result, long what, long i, long j, long p, long q, mpSparseMatrixC *source);
void EigenSparseLib_cplx_mpType_GetBlock(mpSparseMatrixC *result, long what, long i, long j, long p, long q, mpSparseMatrixC *source);

void EigenSparseLib_cplx_mpType_SetSpecialValue(mpSparseMatrixC *result, long what, int32_t m, int32_t n);
void EigenSparseLib_cplx_mpType_SetSpecialValue2(mpSparseMatrixC *result, long what, long Vertical, long Horizontal, long PartialMode, mpSparseMatrixC *source);

void EigenSparseLib_cplx_mpType_BasicArithmetic(mpSparseMatrixC *result, long what, mpSparseMatrixC *x, mpSparseMatrixC *y);

void EigenSparseLib_cplx_mpType_DenseFromSparse(mpMatrixC *result, mpSparseMatrixC *source);
void EigenSparseLib_cplx_mpType_SparseFromDense(mpSparseMatrixC *result, mpMatrixC *source);

void EigenSparseLib_cplx_mpType_Solve(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b, long Decomposition);





