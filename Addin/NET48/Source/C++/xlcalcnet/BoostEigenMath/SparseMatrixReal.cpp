//#include "stdafx.h"
#include "libEigenSparse.h"






mpSparseMatrixPtr EigenSparseLib_mpType_Init_Func(mpSparseMatrixPtr dummy)
{
    mpSparseMatrixPtr x = new(mpSparseMatrix);
    (*x).resize(1, 1);
    (*x).setZero();
    return x;
}


void EigenSparseLib_mpType_Init(mpSparseMatrixPtr* x)
{
    (*x) = new(mpSparseMatrix);
    (*(*x)).resize(1, 1);
    (*(*x)).setZero();
}


void EigenSparseLib_mpType_Clear(mpSparseMatrixPtr x)
{
    delete (x);
}





void EigenSparseLib_mpType_GetInfo(long *result, long what, mpSparseMatrix *x)
{
    switch (what) {
    case mp_const_size: *result = (long)(*x).size() ; break;
    case mp_const_rows: *result = (long)(*x).rows() ; break;
    case mp_const_cols: *result = (long)(*x).cols() ; break;
    }
}


void EigenSparseLib_mpType_DenseFromSparse(mpMatrix *result, mpSparseMatrix *source)
{
    (*result) = mpMatrix(*source);
}


void EigenSparseLib_mpType_SparseFromDense(mpSparseMatrix *result, mpMatrix *source)
{
    (*result) = (*source).sparseView();
}




void EigenSparseLib_mpType_PutBlock(mpSparseMatrix *result, long what, long i, long j, long p, long q, mpSparseMatrix *source)
{
	switch (what) {
		case mp_const_fullcopy: (*result) = (*source) ; break;
		case mp_const_leftCols: (*result).leftCols(q) = (*source) ; break;
		case mp_const_rightCols: (*result).rightCols(q) = (*source) ; break;
		case mp_const_middleCols: (*result).middleCols(p, q) = (*source) ; break;
	}
}



void EigenSparseLib_mpType_GetBlock(mpSparseMatrix *result, long what, long i, long j, long p, long q, mpSparseMatrix *source)
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



void EigenSparseLib_mpType_SetSpecialValue(mpSparseMatrix *result, long what, int32_t m, int32_t n)
{
	switch (what) {
		case mp_setZero: (*result).resize(m, n);(*result).setZero() ; break;
		case mp_setIdentity: (*result).resize(m, n);(*result).setIdentity() ; break;
		case mp_Resize: (*result).resize(m, n); (*result).setZero() ;break;
		case mp_conservativeResize: (*result).conservativeResize(m, n); break;
		break;
	}
}




void EigenSparseLib_mpType_SetSpecialValue2(mpSparseMatrix *result, long what, long Vertical, long Horizontal, long PartialMode, mpSparseMatrix *source)
{
	switch (what) {
//		case mp_asDiagonal: (*result) = (*source).col(0).asDiagonal(); break;
		case mp_adjoint: (*result) = (*source).adjoint(); break;
		case mp_conjugate: (*result) = (*source).conjugate(); break;
		case mp_transpose: (*result) = (*source).transpose(); break;
		break;
	}
}






void EigenSparseLib_mpType_BasicArithmetic(mpSparseMatrix *result, long what, mpSparseMatrix *x, mpSparseMatrix *y)
{
	mpType f = (*y).coeffRef(0,0);
	switch (what){
		case mp_const_plus: *result = (*x) + (*y); break;
		case mp_const_minus: *result = (*x) - (*y); break;
		case mp_const_cwiseProduct: *result = (*x).cwiseProduct(*y); break;
		case mp_const_cwiseQuotient: *result = (*x).cwiseQuotient(*y); break;
		case mp_const_MatrixProduct: (*result) = (*x) * (*y); break;
		case mp_const_DotProduct: (*result).coeffRef(0,0) = (*x).col(0).dot(((*y).col(0))); break;
		case mp_const_times_scalar: *result = f * (*x) ; break;
		case mp_const_div_scalar: *result = (1/f) * (*x) ; break;

	}
}





void EigenSparseLib_mpType_Stats(mpSparseMatrix *result, long what, long PartialMode, mpSparseMatrix *source)
{
	switch (what){
		case mp_const_sum:
		switch (PartialMode){
			case mp_const_full_matrix: (*result).coeffRef(0,0) = (*source).sum(); break;
		}
		break;
		case mp_const_squaredNorm:
		switch (PartialMode){
			case mp_const_full_matrix: (*result).coeffRef(0,0) = (*source).squaredNorm(); break;
		}
		break;
	}
}


