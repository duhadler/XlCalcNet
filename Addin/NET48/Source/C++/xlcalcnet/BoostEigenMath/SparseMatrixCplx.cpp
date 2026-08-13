//#include "stdafx.h"
#include "libEigenSparse.h"



mpCplxSparseMatrixPtr EigenSparseLib_cplx_mpType_Init_Func(mpCplxSparseMatrixPtr dummy)
{
    mpCplxSparseMatrixPtr x = new(mpSparseMatrixC);
    (*x).resize(1, 1);
    (*x).setZero();
    return x;
}


void EigenSparseLib_cplx_mpType_Init(mpCplxSparseMatrixPtr* x)
{
    (*x) = new(mpSparseMatrixC);
    (*(*x)).resize(1, 1);
    (*(*x)).setZero();
}

void EigenSparseLib_cplx_mpType_Clear(mpCplxSparseMatrixPtr x)
{
    delete (x);
}




void EigenSparseLib_cplx_mpType_GetInfo(long *result, long what, mpSparseMatrixC *x)
{
    switch (what) {
    case mp_const_size: *result = (long)(*x).size() ; break;
    case mp_const_rows: *result = (long)(*x).rows() ; break;
    case mp_const_cols: *result = (long)(*x).cols() ; break;
    }
}



void EigenSparseLib_cplx_mpType_DenseFromSparse(mpMatrixC *result, mpSparseMatrixC *source)
{
    (*result) = mpMatrixC(*source);
}


void EigenSparseLib_cplx_mpType_SparseFromDense(mpSparseMatrixC *result, mpMatrixC *source)
{
    (*result) = (*source).sparseView();
}






void EigenSparseLib_cplx_mpType_PutBlock(mpSparseMatrixC *result, long what, long i, long j, long p, long q, mpSparseMatrixC *source)
{
	switch (what) {
		case mp_const_fullcopy: (*result) = (*source) ; break;
		case mp_const_leftCols: (*result).leftCols(q) = (*source) ; break;
		case mp_const_rightCols: (*result).rightCols(q) = (*source) ; break;
		case mp_const_middleCols: (*result).middleCols(p, q) = (*source) ; break;
	}
}





void EigenSparseLib_cplx_mpType_GetBlock(mpSparseMatrixC *result, long what, long i, long j, long p, long q, mpSparseMatrixC *source)
{
	switch (what) {
		case mp_const_block: (*result) = (*source).block(i, j, p, q); break;
		case mp_const_topLeftCorner: (*result) = (*source).topLeftCorner(p, q); break;
		case mp_const_bottomLeftCorner: (*result) = (*source).bottomLeftCorner(p, q); break;
		case mp_const_topRightCorner: (*result) = (*source).topRightCorner(p, q); break;
		case mp_const_bottomRightCorner: (*result) = (*source).bottomRightCorner(p, q); break;
		case mp_const_topRows: (*result) = (*source).topRows(q); break;
		case mp_const_bottomRows: (*result) = (*source).bottomRows(q); break;
		case mp_const_leftCols: (*result) = (*source).leftCols(q); break;
		case mp_const_rightCols: (*result) = (*source).rightCols(q); break;
//		case mp_const_diagonal: (*result) = (*source).diagonal(q); break;
		case mp_const_middleRows: (*result) = (*source).middleRows(p, q); break;
		case mp_const_middleCols: (*result) = (*source).middleCols(p, q); break;
		case mp_const_triangularView: {
			switch (q) {
				case mp_const_Upper: (*result) = (*source).triangularView<Eigen::Upper>() ; break;
				case mp_const_Lower: (*result) = (*source).triangularView<Eigen::Lower>(); break;
				case mp_const_StrictlyUpper: (*result) = (*source).triangularView<Eigen::StrictlyUpper>(); break;
				case mp_const_StrictlyLower: (*result) = (*source).triangularView<Eigen::StrictlyLower>(); break;
				case mp_const_UnitUpper: (*result) = (*source).triangularView<Eigen::UnitUpper>(); break;
				case mp_const_UnitLower: (*result) = (*source).triangularView<Eigen::UnitLower>(); break;
			}
		}
	}
}






void EigenSparseLib_cplx_mpType_SetSpecialValue(mpSparseMatrixC *result, long what, int32_t m, int32_t n)
{
	switch (what) {
		case mp_setZero: (*result).resize(m, n);(*result).setZero() ; break;
		case mp_setIdentity: (*result).resize(m, n);(*result).setIdentity() ; break;
		case mp_Resize: (*result).resize(m, n); (*result).setZero() ;break;
		case mp_conservativeResize: (*result).conservativeResize(m, n); break;
		break;
	}
}





void EigenSparseLib_cplx_mpType_SetSpecialValue2(mpSparseMatrixC *result, long what, long Vertical, long Horizontal, long PartialMode, mpSparseMatrixC *source)
{
	switch (what) {
//		case mp_asDiagonal: (*result) = (*source).col(0).asDiagonal(); break;
		case mp_adjoint: (*result) = (*source).adjoint(); break;
		case mp_conjugate: (*result) = (*source).conjugate(); break;
		case mp_transpose: (*result) = (*source).transpose(); break;
		break;
	}
}







void EigenSparseLib_cplx_mpType_BasicArithmetic(mpSparseMatrixC *result, long what, mpSparseMatrixC *x, mpSparseMatrixC *y)
{
	cplx_mpType f = (*y).coeffRef(0,0);
	switch (what){
		case mp_const_plus: *result = (*x) + (*y); break;
		case mp_const_minus: *result = (*x) - (*y); break;
		case mp_const_cwiseProduct: *result = (*x).cwiseProduct(*y); break;
		case mp_const_cwiseQuotient: *result = (*x).cwiseQuotient(*y); break;
		case mp_const_MatrixProduct: (*result) = (*x) * (*y); break;
		case mp_const_times_scalar: *result = f * (*x) ; break;
		case mp_const_div_scalar: (*result) = (*x) / f ; break;

	}
}


void EigenSparseLib_set_real_cplx_mpType(mpCplxSparseMatrixPtr CplxDestMatrix, mpSparseMatrix* RealSourceMatrix)
{
//    (*CplxDestMatrix).real() = (*RealSourceMatrix);
}

void EigenSparseLib_get_real_cplx_mpType(mpSparseMatrix* RealDestMatrix, mpCplxSparseMatrixPtr CplxSourceMatrix)
{
    (*RealDestMatrix) = (*CplxSourceMatrix).real();
}


void EigenSparseLib_set_imag_cplx_mpType(mpCplxSparseMatrixPtr CplxDestMatrix, mpSparseMatrix* RealSourceMatrix)
{
//    (*CplxDestMatrix).imag() = (*RealSourceMatrix);
}

void EigenSparseLib_get_imag_cplx_mpType(mpSparseMatrix* RealDestMatrix, mpCplxSparseMatrixPtr CplxSourceMatrix)
{
    (*RealDestMatrix) = (*CplxSourceMatrix).imag();
}
