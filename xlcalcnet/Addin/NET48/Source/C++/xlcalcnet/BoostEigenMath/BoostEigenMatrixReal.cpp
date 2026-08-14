#include <algorithm>
#include <vector>
#include <Eigen/StdVector>

#include "libBoostEigenDense.h"


static int32_t col_to_sort_by = 0;



template <typename ScalarType, typename Derived>
void Sort(Eigen::MatrixBase<Derived> &xValues)
{
std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size());
}



void EigenLib_mpType_Sort(mpMatrixPtr x)
{
    Sort<mpType>(*x);
}



template <typename T>
bool comparator_lt_abs(const T &lhs, const T &rhs) {
 //return std::abs(lhs) < std::abs(rhs);
 return abs(lhs) < abs(rhs);
}


template <typename T>
bool comparator_gt_abs(const T &lhs, const T &rhs) {
 //return std::abs(lhs) > std::abs(rhs);
 return abs(lhs) > abs(rhs);
}


template <typename T>
bool comparator_lt_real(const T &lhs, const T &rhs) {
 return (lhs) < (rhs);
}


template <typename T>
bool comparator_gt_real(const T &lhs, const T &rhs) {
 return (lhs) > (rhs);
}


template <typename ScalarType, typename Derived>
void Sort(Eigen::MatrixBase<Derived> &xValues, int32_t SortOrder, int32_t SortCriterion)
{
     if (SortCriterion == mp_sort_by_abs )
     {
        if (SortOrder == mp_sort_ascending)
        {
            std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                      &comparator_lt_abs<ScalarType>);
        }
        else
        {
            std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                      &comparator_gt_abs<ScalarType>);
        }
     }

     if ((SortCriterion == mp_sort_by_real) || (SortCriterion == mp_sort_by_imag))
     {
        if (SortOrder == mp_sort_ascending)
        {
            std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                      &comparator_lt_real<ScalarType>);
        }
        else
        {
            std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                      &comparator_gt_real<ScalarType>);
        }
     }
}


void EigenLib_mpType_Sort(mpMatrixPtr x, int32_t SortOrder, int32_t SortCriterion)
{
    Sort<mpType>(*x, SortOrder, SortCriterion);
}





bool compare_head_by_col_lt_abs(const mpVector& lhs, const mpVector& rhs)
{
    return abs(lhs(col_to_sort_by)) < abs(rhs(col_to_sort_by));
//    return std::abs(lhs(col_to_sort_by)) < std::abs(rhs(col_to_sort_by));
}

bool compare_head_by_col_gt_abs(const mpVector& lhs, const mpVector& rhs)
{
    return abs(lhs(col_to_sort_by)) > abs(rhs(col_to_sort_by));
//    return std::abs(lhs(col_to_sort_by)) > std::abs(rhs(col_to_sort_by));
}



bool compare_head_by_col_lt_real(const mpVector& lhs, const mpVector& rhs)
{
    return lhs(col_to_sort_by) < rhs(col_to_sort_by);
}

bool compare_head_by_col_gt_real(const mpVector& lhs, const mpVector& rhs)
{
    return lhs(col_to_sort_by) > rhs(col_to_sort_by);
}


void EigenLib_mpType_SortRowsByColumn(mpMatrixPtr A, int32_t ColumnToSortBy, int32_t SortOrder, int32_t SortCriterion)
{
    col_to_sort_by = ColumnToSortBy;
    std::vector<mpVector> vec;
    for (int64_t i = 0; i < (*A).rows(); ++i)
        vec.push_back((*A).row(i));

     if (SortCriterion == mp_sort_by_abs )
     {
        if (SortOrder == mp_sort_ascending)
        {
            std::sort(vec.begin(), vec.end(), &compare_head_by_col_lt_abs);
        }
        else
        {
            std::sort(vec.begin(), vec.end(), &compare_head_by_col_gt_abs);
        }
     }

     if ((SortCriterion == mp_sort_by_real) || (SortCriterion == mp_sort_by_imag))
     {
        if (SortOrder == mp_sort_ascending)
        {
            std::sort(vec.begin(), vec.end(), &compare_head_by_col_lt_real);
        }
        else
        {
            std::sort(vec.begin(), vec.end(), &compare_head_by_col_gt_real);
        }
     }

    for (int64_t i = 0; i < (*A).rows(); ++i)
        (*A).row(i) = vec[i];
}



// Change to remove NaN and Inf, check all values in a row
void EigenLib_mpType_Select_Rows(mpMatrixPtr res, mpMatrixPtr A)
{
    std::vector<mpVector> vec;
    int k = 0;
    for (int64_t i = 0; i < (*A).rows(); ++i)
    {
//        if ((*A).coeff(i,0) < -0.5)
        if (isfinite((*A).coeff(i,0)))
        {
            vec.push_back((*A).row(i));
            k = k + 1;
        }
    }

    (*res).resize(k, (*A).cols());
    k = 0;
    for (auto row : vec)
    {
        (*res).row(k) = row;
        k = k + 1;
    }
}



/*  Begin   */

mpMatrixPtr EigenLib_mpType_Init_Func(mpMatrixPtr dummy)
{
    mpMatrixPtr x = new(mpMatrix);
    (*x).resize(1, 1);
    (*x).setZero();
    return x;
}


void EigenLib_mpType_Init(mpMatrixPtr* x)
{
    (*x) = new(mpMatrix);
    (*(*x)).resize(1, 1);
    (*(*x)).setZero();
}


void EigenLib_mpType_Clear(mpMatrixPtr x)
{
    delete (x);
}



void EigenLib_mpType_GetInfo(long *result, long what, mpMatrix *x)
{
    switch (what) {
    case mp_const_size: *result = (long)(*x).size() ; break;
    case mp_const_rows: *result = (long)(*x).rows() ; break;
    case mp_const_cols: *result = (long)(*x).cols() ; break;
    }
}








void EigenLib_mpType_PutBlock(mpMatrix *result, long what, long i, long j, long p, long q, mpMatrix *source)
{
	switch (what) {
		case mp_const_fullcopy: (*result) = (*source) ; break;
		case mp_const_block: (*result).block(i, j, p, q) = (*source) ; break;
		case mp_const_topLeftCorner: (*result).topLeftCorner(p, q) = (*source) ; break;
		case mp_const_bottomLeftCorner: (*result).bottomLeftCorner(p, q) = (*source) ; break;
		case mp_const_topRightCorner: (*result).topRightCorner(p, q) = (*source) ; break;
		case mp_const_bottomRightCorner: (*result).bottomRightCorner(p, q) = (*source) ; break;
		case mp_const_topRows: (*result).topRows(q) = (*source) ; break;
		case mp_const_bottomRows: (*result).bottomRows(q) = (*source) ; break;
		case mp_const_leftCols: (*result).leftCols(q) = (*source) ; break;
		case mp_const_rightCols: (*result).rightCols(q) = (*source) ; break;
		case mp_const_diagonal: (*result).diagonal(q) = (*source) ; break;
		case mp_const_middleRows: (*result).middleRows(p, q) = (*source) ; break;
		case mp_const_middleCols: (*result).middleCols(p, q) = (*source) ; break;
		case mp_const_triangularView: {
			switch (q) {
				case mp_const_Upper: (*result).triangularView<Eigen::Upper>() = (*source) ; break;
				case mp_const_Lower: (*result).triangularView<Eigen::Lower>() = (*source) ; break;
				case mp_const_StrictlyUpper: (*result).triangularView<Eigen::StrictlyUpper>() = (*source) ; break;
				case mp_const_StrictlyLower: (*result).triangularView<Eigen::StrictlyLower>() = (*source) ; break;
				case mp_const_UnitUpper: (*result).triangularView<Eigen::UnitUpper>() = (*source) ; break;
				case mp_const_UnitLower: (*result).triangularView<Eigen::UnitLower>() = (*source) ; break;
			}
		}
	}
}



void EigenLib_mpType_GetBlock(mpMatrix *result, long what, long i, long j, long p, long q, mpMatrix *source)
{
	switch (what) {
		case mp_const_fullcopy: (*result) = (*source); break;
		case mp_const_fullnegcopy: (*result) = -(*source); break;
		case mp_const_block: (*result) = (*source).block(i, j, p, q); break;
		case mp_const_topLeftCorner: (*result) = (*source).topLeftCorner(p, q); break;
		case mp_const_bottomLeftCorner: (*result) = (*source).bottomLeftCorner(p, q); break;
		case mp_const_topRightCorner: (*result) = (*source).topRightCorner(p, q); break;
		case mp_const_bottomRightCorner: (*result) = (*source).bottomRightCorner(p, q); break;
		case mp_const_topRows: (*result) = (*source).topRows(q); break;
		case mp_const_bottomRows: (*result) = (*source).bottomRows(q); break;
		case mp_const_leftCols: (*result) = (*source).leftCols(q); break;
		case mp_const_rightCols: (*result) = (*source).rightCols(q); break;
		case mp_const_diagonal: (*result) = (*source).diagonal(q); break;
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



void EigenLib_mpType_SetSpecialValue(mpMatrix *result, long what, int32_t m, int32_t n)
{
	switch (what) {
		case mp_setZero: (*result).resize(m, n);(*result).setZero() ; break;
		case mp_setOnes: (*result).resize(m, n);(*result).setOnes() ; break;
		case mp_setIdentity: (*result).resize(m, n);(*result).setIdentity() ; break;
		case mp_setRandom: (*result).resize(m, n);(*result).setRandom() ; break;
		case mp_transposeInPlace: (*result).transposeInPlace() ; break;
		case mp_reverseInPlace: (*result).reverseInPlace() ; break;
		case mp_Resize: (*result).resize(m, n); (*result).setZero() ;break;
		case mp_conservativeResize: (*result).conservativeResize(m, n); break;
		case mp_setRandom_nm: (*result) =  mpMatrix::Random(m, n); break;
		case mp_setRandomSymmetric:
		    {(*result) =  mpMatrix::Random(m, m);
		    mpMatrix y = (*result).transpose();
		    (*result) += y;}; break;
		case mp_setRandomSA:  /* SA = SelfAdjoint = Symmetric for Real Matrices*/
            {(*result) =  mpMatrix::Random(m, m);
		    mpMatrix y = (*result).adjoint();
            (*result) += y;}; break;
		case mp_setRandomSAPosDef:  /* SAPosDef = Symmetric Positive Definite for Real Matrices*/
		    {(*result) = mpMatrix::Random(m, m);
		    mpMatrix y = (*result).adjoint();
            (*result) *= y;}; break;
		case mp_FillLinear: {
			(*result).resize(n, m);
//			for (int j = 0; j < (*result).rows(); j++) {
//				(*result)(j, 0) = (float) m + (j) * 1000;
//				for (int i = 1; i < (*result).cols(); i++) { (*result)(j, i) = (*result)(j, i - 1) + n;}}
			}
		break;
		break;
	}
}




void EigenLib_mpType_SetSpecialValue2(mpMatrix *result, long what, long Vertical, long Horizontal, long PartialMode, mpMatrix *source)
{
	switch (what) {
		case mp_asDiagonal: (*result) = (*source).col(0).asDiagonal(); break;
		case mp_adjoint: (*result) = (*source).adjoint(); break;
		case mp_conjugate: (*result) = (*source).conjugate(); break;
		case mp_transpose: (*result) = (*source).transpose(); break;
		case mp_reverse: {
			switch (PartialMode) {
				case mp_const_full_matrix: (*result) = (*source).reverse();break;
				case mp_const_rowwise: (*result) = (*source).rowwise().reverse();break;
				case mp_const_colwise: (*result) = (*source).colwise().reverse();break;
			}
		}
		break;
		case mp_replicate: {
			switch (PartialMode) {
				case mp_const_full_matrix: (*result) = (*source).replicate(Vertical, Horizontal);break;
				case mp_const_rowwise: (*result) = (*source).rowwise().replicate(Vertical);break;
				case mp_const_colwise: (*result) = (*source).colwise().replicate(Horizontal);break;
			}
		}
		break;
		case mp_ResizeLike: (*result).resizeLike(*source) ; break;
		break;
	}
}



void EigenLib_mpType_Compare(long* result, long what, mpMatrix *x, mpMatrix *y)
{
	switch (what) {
		case mp_const_GT: *result = (long) ((*x).array()  >   (*y).array()).count(); break;
		case mp_const_LT: *result = (long) ((*x).array()  <   (*y).array()).count(); break;
		case mp_const_LE: *result = (long) ((*x).array()  <=   (*y).array()).count(); break;
		case mp_const_GE: *result = (long) ((*x).array()  >=   (*y).array()).count(); break;
		case mp_const_EQ: *result = (long) ((*x).array()  ==   (*y).array()).count(); break;
		case mp_const_NE: *result = (long) ((*x).array()  !=   (*y).array()).count(); break;
	}
}






void EigenLib_mpType_Stats(mpMatrix *result, long what, long PartialMode, mpMatrix *source)
{
	switch (what){
		case mp_const_sum:
		switch (PartialMode){
			case mp_const_full_matrix: (*result)(0,0) = (*source).sum(); break;
			case mp_const_rowwise: (*result) = (*source).rowwise().sum(); break;
			case mp_const_colwise: (*result) = (*source).colwise().sum(); break;
		}
		break;
		case mp_const_prod:
		switch (PartialMode){
			case mp_const_full_matrix: (*result)(0,0) = (*source).prod(); break;
			case mp_const_rowwise: (*result) = (*source).rowwise().prod(); break;
			case mp_const_colwise: (*result) = (*source).colwise().prod(); break;
		}
		break;
		case mp_const_mean:
		switch (PartialMode){
			case mp_const_full_matrix: (*result)(0,0) = (*source).mean(); break;
			case mp_const_rowwise: (*result) = (*source).rowwise().mean(); break;
			case mp_const_colwise: (*result) = (*source).colwise().mean(); break;
		}
		break;
		case mp_const_minCoeff:
		switch (PartialMode){
			case mp_const_full_matrix: (*result)(0,0) = (*source).minCoeff(); break;
			case mp_const_rowwise: (*result) = (*source).rowwise().minCoeff(); break;
			case mp_const_colwise: (*result) = (*source).colwise().minCoeff(); break;
		}
		break;
		case mp_const_maxCoeff:
		switch (PartialMode){
			case mp_const_full_matrix: (*result)(0,0) = (*source).maxCoeff(); break;
			case mp_const_rowwise: (*result) = (*source).rowwise().maxCoeff(); break;
			case mp_const_colwise: (*result) = (*source).colwise().maxCoeff(); break;
		}
		break;
		case mp_const_squaredNorm:
		switch (PartialMode){
			case mp_const_full_matrix: (*result)(0,0) = (*source).squaredNorm(); break;
			case mp_const_rowwise: (*result) = (*source).rowwise().squaredNorm(); break;
			case mp_const_colwise: (*result) = (*source).colwise().squaredNorm(); break;
		}
		break;
		case mp_const_Norm:
		switch (PartialMode){
			case mp_const_full_matrix: (*result)(0,0) = (*source).norm(); break;
			case mp_const_rowwise: (*result) = (*source).rowwise().norm(); break;
			case mp_const_colwise: (*result) = (*source).colwise().norm(); break;
		}
		break;
	}
}



void EigenLib_mpType_Stats2(mpMatrix *result, long *res_IndexX, long *res_IndexY, long what, mpMatrix *source)
{
	mpMatrix::Index mRow=0, mCol=0;
	switch (what){
		case mp_const_minCoeff_Index: (*result)(0,0) = (*source).minCoeff(&mRow, &mCol); break;
		case mp_const_maxCoeff_Index: (*result)(0,0) = (*source).maxCoeff(&mRow, &mCol); break;
	}
	*res_IndexX = long(mRow); *res_IndexY = long(mCol);
}



void EigenLib_mpType_BasicArithmetic(mpMatrix *result, long what, mpMatrix *x, mpMatrix *y)
{
	if ((what >= mp_mat_det) && (what <= mp_mat_solve))
    {
        PartialPivLU<mpMatrix> lu((*x));
        switch (what){
            case mp_mat_det: (*result)(0,0) = lu.determinant(); break;
            case mp_mat_rcond: (*result)(0,0) = lu.rcond(); break;
            case mp_mat_inverse: *result = lu.inverse(); break;
            case mp_mat_solve: *result = lu.solve(*y); break;
        }
	}
    else
    {
        mpType f = (*y)(0,0);
		mpType one = 1;
        switch (what){

            case mp_const_plus_scalar: *result = f + (*x).array() ; break;
            case mp_const_minus_scalar: *result = -f + (*x).array() ; break;
            case mp_const_times_scalar: *result = f * (*x).array() ; break;
			case mp_const_div_scalar: *result = (*x).array() / f; break;

            case mp_const_plus: *result = (*x) + (*y); break;
            case mp_const_minus: *result = (*x) - (*y); break;
            case mp_const_cwiseProduct: *result = (*x).cwiseProduct(*y); break;
            case mp_const_cwiseQuotient: *result = (*x).cwiseQuotient(*y); break;
            case mp_const_MatrixProduct: (*result) = (*x) * (*y); break;
            case mp_const_DotProduct: (*result)(0,0) = (*x).col(0).dot(((*y).col(0))); break;

			case mp_const_diag_prod_left: (*result) = (*x).col(0).asDiagonal() * (*y); break;
			case mp_const_diag_prod_right: (*result) = (*x) * (*y).col(0).asDiagonal(); break;

			case mp_const_sa_lower_prod_left: (*result) = (*x).selfadjointView<Lower>() * (*y); break;
			case mp_const_sa_lower_prod_right: (*result) = (*x) * (*y).selfadjointView<Lower>(); break;
			case mp_const_sa_upper_prod_left: (*result) = (*x).selfadjointView<Upper>() * (*y); break;
			case mp_const_sa_upper_prod_right: (*result) = (*x) * (*y).selfadjointView<Upper>(); break;

			case mp_const_lower_tria_prod_left: (*result) = (*x).triangularView<Lower>() * (*y); break;
			case mp_const_lower_tria_prod_right: (*result) = (*x) * (*y).triangularView<Lower>(); break;
			case mp_const_upper_tria_prod_left: (*result) = (*x).triangularView<Upper>() * (*y); break;
			case mp_const_upper_tria_prod_right: (*result) = (*x) * (*y).triangularView<Upper>(); break;

			case mp_const_strictly_lower_tria_prod_left: (*result) = (*x).triangularView<StrictlyLower>() * (*y); break;
			case mp_const_strictly_lower_tria_prod_right: (*result) = (*x) * (*y).triangularView<StrictlyLower>(); break;
			case mp_const_strictly_upper_tria_prod_left: (*result) = (*x).triangularView<StrictlyUpper>() * (*y); break;
			case mp_const_strictly_upper_tria_prod_right: (*result) = (*x) * (*y).triangularView<StrictlyUpper>(); break;

			case mp_const_unit_lower_tria_prod_left: (*result) = (*x).triangularView<UnitLower>() * (*y); break;
			case mp_const_unit_lower_tria_prod_right: (*result) = (*x) * (*y).triangularView<UnitLower>(); break;
			case mp_const_unit_upper_tria_prod_left: (*result) = (*x).triangularView<UnitUpper>() * (*y); break;
			case mp_const_unit_upper_tria_prod_right: (*result) = (*x) * (*y).triangularView<UnitUpper>(); break;


			case mp_const_lower_tria_solve: (*result) = (*x).triangularView<Lower>().solve(*y); break;
			case mp_const_upper_tria_solve: (*result) = (*x).triangularView<Upper>().solve(*y); break;
			case mp_const_unit_lower_tria_solve: (*result) = (*x).triangularView<UnitLower>().solve(*y); break;
			case mp_const_unit_upper_tria_solve: (*result) = (*x).triangularView<UnitUpper>().solve(*y); break;


            case mp_const_concat_horizontal: (*result).resize((*x).rows(), (*x).cols()+(*y).cols());
                                             (*result) << (*x), (*y); break;
            case mp_const_concat_vertical: (*result).resize((*x).rows()+(*y).rows(), (*x).cols());
                                            (*result) << (*x), (*y); break;

			case mp_const_variance:
			{
				mpMatrix temp = (*x).rowwise() - (*x).colwise().mean(); /* x returns the centered input matrix*/
				mpMatrix tempcol = temp.colwise().squaredNorm() / (int)((*y).rows() - 1); /* x returns the variance percol of temp*/
				(*result) = tempcol;
			}
				break;

			case mp_const_stdev:
			{
				mpMatrix temp = (*x).rowwise() - (*x).colwise().mean(); /* x returns the centered input matrix*/
				mpMatrix tempcol = temp.colwise().norm() / sqrt(one * ((*y).rows() - one)); /* x returns the stdev percol of temp*/
				(*result) = tempcol;
			}
				break;

			case mp_const_centered:
			{
				mpMatrix temp = (*x).rowwise() - (*x).colwise().mean(); /* x returns the centered input matrix*/
				(*result) = temp;
			}
				break;

			case mp_const_standardized:
			{
				mpMatrix temp = (*x).rowwise() - (*x).colwise().mean(); /* x returns the centered input matrix*/
				mpRowVector tempcol = temp.colwise().norm() / sqrt(one * ((*y).rows() - one));
				mpMatrix temp2 = temp.array().rowwise() / tempcol.array();
				(*result) = temp2; /* x returns the standardized matrix*/
			}
				break;

			case mp_const_covariance:
			{
				mpMatrix temp = (*x).rowwise() - (*x).colwise().mean(); /* x returns the centered input matrix*/
				mpMatrix temp2;
				temp2.resize((*x).cols(), (*x).cols());
				temp2.triangularView<Upper>() = (temp.adjoint() * temp) / (int)((temp).rows() - 1);
				temp2.triangularView<StrictlyLower>() = temp2.triangularView<StrictlyUpper>().transpose();
				(*result) = temp2;
			}
				break;

			case mp_const_correlation:
			{
				mpMatrix temp = (*x).rowwise() - (*x).colwise().mean(); /* x returns the centered input matrix*/
				mpRowVector tempcol = temp.colwise().norm() / sqrt(one * ((*y).rows() - one));
				mpMatrix temp1 = temp.array().rowwise() / tempcol.array();
				mpMatrix temp2;
				temp2.resize((*x).cols(), (*x).cols());
				temp2.triangularView<Upper>() = (temp1.adjoint() * temp1) / (int)((temp1).rows() - 1);
				temp2.triangularView<StrictlyLower>() = temp2.triangularView<StrictlyUpper>().transpose();
				(*result) = temp2;
			}
				break;

			case mp_const_crossproducts:
			{
				mpMatrix temp;
				temp.resize((*x).cols(), (*x).cols());
				temp.triangularView<Upper>() = ((*x).adjoint() * (*x));
				temp.triangularView<StrictlyLower>() = temp.triangularView<StrictlyUpper>().transpose();
				(*result) = temp;
			}
				break;

			case mp_const_A_S_AT:
				// y = A; S = x
			{
				mpMatrix temp;
				temp.resize((*x).cols(), (*x).cols());
				temp.triangularView<Upper>() = (*y) * (*x).selfadjointView<Upper>() * (*y).transpose();
				temp.triangularView<StrictlyLower>() = temp.triangularView<StrictlyUpper>().transpose();
				(*result) = temp;
			}
				break;

			case mp_const_SYR2K:
			{
				mpMatrix temp;
				temp.resize((*x).cols(), (*x).cols());
				temp.triangularView<Upper>() = (*x) * (*y).transpose() + (*y) * (*x).transpose();
				temp.triangularView<StrictlyLower>() = temp.triangularView<StrictlyUpper>().transpose();
				(*result) = temp;
			}
				break;
        }
	}
}

