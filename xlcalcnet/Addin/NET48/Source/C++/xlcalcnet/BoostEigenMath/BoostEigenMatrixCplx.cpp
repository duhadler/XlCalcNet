#include "libBoostEigenDense.h"



static int32_t cplx_col_to_sort_by = 0;



template <class T>
bool complex_comparator_lt_abs(const complex<T> &lhs, const complex<T> &rhs) {
 return std::abs(lhs) < std::abs(rhs);
}


template <class T>
bool complex_comparator_gt_abs(const complex<T> &lhs, const complex<T> &rhs) {
 return std::abs(lhs) > std::abs(rhs);
}


template <class T>
bool complex_comparator_lt_real(const complex<T> &lhs, const complex<T> &rhs) {
 return real(lhs) == real(rhs) ? imag(lhs) < imag(rhs) : real(lhs) < real(rhs);
}


template <class T>
bool complex_comparator_gt_real(const complex<T> &lhs, const complex<T> &rhs) {
 return real(lhs) == real(rhs) ? imag(lhs) > imag(rhs) : real(lhs) > real(rhs);
}



template <class T>
bool complex_comparator_lt_imag(const complex<T> &lhs, const complex<T> &rhs) {
 return imag(lhs) == imag(rhs) ? real(lhs) < real(rhs) : imag(lhs) < imag(rhs);
}


template <class T>
bool complex_comparator_gt_imag(const complex<T> &lhs, const complex<T> &rhs) {
 return imag(lhs) == imag(rhs) ? real(lhs) > real(rhs) : imag(lhs) > imag(rhs);
}



template <typename ScalarType, typename Derived>
void Cplx_Sort(Eigen::MatrixBase<Derived> &xValues, int32_t SortOrder, int32_t SortCriterion)
{
     if (SortCriterion == mp_sort_by_abs )
     {
         if (SortOrder == mp_sort_ascending )
            {
                std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                          complex_comparator_lt_abs<ScalarType>);
            }
            else
            {
                std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                          complex_comparator_gt_abs<ScalarType>);
            }
     }
     if (SortCriterion == mp_sort_by_real )
     {
         if (SortOrder == mp_sort_ascending )
            {
                std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                          complex_comparator_lt_real<ScalarType>);
            }
            else
            {
                std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                          complex_comparator_gt_real<ScalarType>);
            }
     }
     if (SortCriterion == mp_sort_by_imag )
     {
         if (SortOrder == mp_sort_ascending )
            {
                std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                          complex_comparator_lt_imag<ScalarType>);
            }
            else
            {
                std::sort(xValues.derived().data(), xValues.derived().data()+xValues.derived().size(),
                          complex_comparator_gt_imag<ScalarType>);
            }
     }

}



void EigenLib_cplx_mpType_Sort(mpCplxMatrixPtr x, int32_t SortOrder, int32_t SortCriterion)
{
    Cplx_Sort<mpType>(*x, SortOrder, SortCriterion);
}



bool complex_comparator_by_col_lt_abs(const mpVectorC& lhs, const mpVectorC& rhs)
{
 return std::abs(lhs(cplx_col_to_sort_by)) < std::abs(rhs(cplx_col_to_sort_by));
}

bool complex_comparator_by_col_gt_abs(const mpVectorC& lhs, const mpVectorC& rhs)
{
 return std::abs(lhs(cplx_col_to_sort_by)) > std::abs(rhs(cplx_col_to_sort_by));
}


bool complex_comparator_by_col_lt_real(const mpVectorC& lhs, const mpVectorC& rhs)
{
 return real(lhs(cplx_col_to_sort_by)) == real(rhs(cplx_col_to_sort_by)) ?
    imag(lhs(cplx_col_to_sort_by)) < imag(rhs(cplx_col_to_sort_by)) :
    real(lhs(cplx_col_to_sort_by)) < real(rhs(cplx_col_to_sort_by));
}

bool complex_comparator_by_col_gt_real(const mpVectorC& lhs, const mpVectorC& rhs)
{
 return real(lhs(cplx_col_to_sort_by)) == real(rhs(cplx_col_to_sort_by)) ?
    imag(lhs(cplx_col_to_sort_by)) > imag(rhs(cplx_col_to_sort_by)) :
    real(lhs(cplx_col_to_sort_by)) > real(rhs(cplx_col_to_sort_by));
}


bool complex_comparator_by_col_lt_imag(const mpVectorC& lhs, const mpVectorC& rhs)
{
 return imag(lhs(cplx_col_to_sort_by)) == imag(rhs(cplx_col_to_sort_by)) ?
    real(lhs(cplx_col_to_sort_by)) < real(rhs(cplx_col_to_sort_by)) :
    imag(lhs(cplx_col_to_sort_by)) < imag(rhs(cplx_col_to_sort_by));
}

bool complex_comparator_by_col_gt_imag(const mpVectorC& lhs, const mpVectorC& rhs)
{
 return imag(lhs(cplx_col_to_sort_by)) == imag(rhs(cplx_col_to_sort_by)) ?
    real(lhs(cplx_col_to_sort_by)) > real(rhs(cplx_col_to_sort_by)) :
    imag(lhs(cplx_col_to_sort_by)) > imag(rhs(cplx_col_to_sort_by));
}



void EigenLib_cplx_mpType_SortRowsByColumn(mpCplxMatrixPtr A, int32_t ColumnToSortBy, int32_t SortOrder, int32_t SortCriterion)
{
    cplx_col_to_sort_by = ColumnToSortBy;
    std::vector<mpVectorC> vec;
    for (int64_t i = 0; i < (*A).rows(); ++i)
        vec.push_back((*A).row(i));

     if (SortCriterion == mp_sort_by_abs )
     {
        if (SortOrder == mp_sort_ascending)
        {
            std::sort(vec.begin(), vec.end(), &complex_comparator_by_col_lt_abs);
        }
        else
        {
            std::sort(vec.begin(), vec.end(), &complex_comparator_by_col_gt_abs);
        }
     }

     if (SortCriterion == mp_sort_by_real )
     {
        if (SortOrder == mp_sort_ascending)
        {
            std::sort(vec.begin(), vec.end(), &complex_comparator_by_col_lt_real);
        }
        else
        {
            std::sort(vec.begin(), vec.end(), &complex_comparator_by_col_gt_real);
        }
     }

     if (SortCriterion == mp_sort_by_imag )
     {
        if (SortOrder == mp_sort_ascending)
        {
            std::sort(vec.begin(), vec.end(), &complex_comparator_by_col_lt_imag);
        }
        else
        {
            std::sort(vec.begin(), vec.end(), &complex_comparator_by_col_gt_imag);
        }
     }

    for (int64_t i = 0; i < (*A).rows(); ++i)
        (*A).row(i) = vec[i];
}



// Change to remove NaN and Inf, check all values in a row
void EigenLib_cplx_mpType_Select_Rows(mpCplxMatrixPtr res, mpCplxMatrixPtr A)
{
    std::vector<mpVectorC> vec;
    int k = 0;
    for (int64_t i = 0; i < (*A).rows(); ++i)
    {
        if ( (isfinite(real((*A).coeff(i,0)))) && (isfinite(imag((*A).coeff(i,0)))) )
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


mpCplxMatrixPtr EigenLib_cplx_mpType_Init_Func(mpCplxMatrixPtr dummy)
{
    mpCplxMatrixPtr x = new(mpMatrixC);
    (*x).resize(1, 1);
    (*x).setZero();
    return x;
}


void EigenLib_cplx_mpType_Init(mpCplxMatrixPtr* x)
{
    (*x) = new(mpMatrixC);
    (*(*x)).resize(1, 1);
    (*(*x)).setZero();
}

void EigenLib_cplx_mpType_Clear(mpCplxMatrixPtr x)
{
    delete (x);
}



void EigenLib_cplx_mpType_GetInfo(long *result, long what, mpMatrixC *x)
{
    switch (what) {
    case mp_const_size: *result = (long)(*x).size() ; break;
    case mp_const_rows: *result = (long)(*x).rows() ; break;
    case mp_const_cols: *result = (long)(*x).cols() ; break;
    }
}





void EigenLib_cplx_mpType_PutBlock(mpMatrixC *result, long what, long i, long j, long p, long q, mpMatrixC *source)
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





void EigenLib_cplx_mpType_GetBlock(mpMatrixC *result, long what, long i, long j, long p, long q, mpMatrixC *source)
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






void EigenLib_cplx_mpType_SetSpecialValue(mpMatrixC *result, long what, int32_t m, int32_t n)
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
		case mp_setRandom_nm: (*result) =  mpMatrixC::Random(m, n); break;
		case mp_setRandomSymmetric:
		    {(*result) =  mpMatrixC::Random(m, m);
		    mpMatrixC y = (*result).transpose();
		    (*result) += y;}; break;
		case mp_setRandomSA: /* SA = SelfAdjoint = Hermitian for Complex Matrices*/
		    {
//		        printf("in mp_setRandomSA");
            (*result) =  mpMatrixC::Random(m, m);
		    mpMatrixC y = (*result).adjoint();
            (*result) += y;}; break;
		case mp_setRandomSAPosDef: /* SAPosDef = Hermitian Positive Definite for Complex Matrices*/
		    {
//		        printf("in mp_setRandomSAPosDef");
		        (*result) =  mpMatrixC::Random(m, m);
                mpMatrixC y = (*result).adjoint();
                (*result) += y;
                mpType x = m;
                for (int j = 0; j < m; j++) {
                    (*result)(j, j) += x;
                }
		    };
		    break;
//		case mp_FillLinear: {
//			(*result).resize(n, m);
//			for (int j = 0; j < (*result).rows(); j++) {
//				(*result)(j, 0) = (float) m + (j) * 1000;
//				for (int i = 1; i < (*result).cols(); i++) { (*result)(j, i) = (*result)(j, i - 1) + (mpType) n;}}
//			}
//		break;
		break;
	}
}





void EigenLib_cplx_mpType_SetSpecialValue2(mpMatrixC *result, long what, long Vertical, long Horizontal, long PartialMode, mpMatrixC *source)
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



void EigenLib_cplx_mpType_Compare(long* result, long what, mpMatrixC *x, mpMatrixC *y)
{
	switch (what) {
		case mp_const_EQ:  *result = (long) ((*x).array()  ==   (*y).array()).count(); break;
		case mp_const_NE:  *result = (long) ((*x).array()  !=   (*y).array()).count(); break;
	}
}




void EigenLib_cplx_mpType_Stats(mpMatrixC* result, long what, long PartialMode, mpMatrixC* source)
{
    switch (what) {
    case mp_const_sum:
        switch (PartialMode) {
        case mp_const_full_matrix: (*result)(0, 0) = (*source).sum(); break;
        case mp_const_rowwise: (*result) = (*source).rowwise().sum(); break;
        case mp_const_colwise: (*result) = (*source).colwise().sum(); break;
        }
        break;
    case mp_const_prod:
        switch (PartialMode) {
        case mp_const_full_matrix: (*result)(0, 0) = (*source).prod(); break;
        case mp_const_rowwise: (*result) = (*source).rowwise().prod(); break;
        case mp_const_colwise: (*result) = (*source).colwise().prod(); break;
        }
        break;
    case mp_const_mean:
        switch (PartialMode) {
        case mp_const_full_matrix: (*result)(0, 0) = (*source).mean(); break;
        case mp_const_rowwise: (*result) = (*source).rowwise().mean(); break;
        case mp_const_colwise: (*result) = (*source).colwise().mean(); break;
        }
        break;
    case mp_const_squaredNorm:
        switch (PartialMode) {
        case mp_const_full_matrix: (*result)(0, 0) = (*source).squaredNorm(); break;
        case mp_const_rowwise: (*result) = (*source).rowwise().squaredNorm(); break;
        case mp_const_colwise: (*result) = (*source).colwise().squaredNorm(); break;
        }
        break;
    case mp_const_Norm:
        switch (PartialMode) {
        case mp_const_full_matrix: (*result)(0, 0) = (*source).norm(); break;
        case mp_const_rowwise: (*result) = (*source).rowwise().norm(); break;
        case mp_const_colwise: (*result) = (*source).colwise().norm(); break;
        }
        break;
    }
}





void EigenLib_cplx_mpType_BasicArithmetic(mpMatrixC *result, long what, mpMatrixC *x, mpMatrixC *y)
{
	if ((what >= mp_mat_det) && (what <= mp_mat_solve))
    {
        PartialPivLU<mpMatrixC> lu((*x));
        switch (what){
            case mp_mat_det: (*result)(0,0) = lu.determinant(); break;
            case mp_mat_rcond: (*result)(0,0) = lu.rcond(); break;
            case mp_mat_inverse: *result = lu.inverse(); break;
            case mp_mat_solve: *result = lu.solve(*y); break;
        }
    }
    else
    {
        cplx_mpType f = (*y)(0,0);
        switch (what){

            case mp_const_plus_scalar: *result = f + (*x).array() ; break;
            case mp_const_minus_scalar: *result = -f + (*x).array() ; break;
            case mp_const_times_scalar: *result = f * (*x).array() ; break;
            case mp_const_div_scalar: (*result) = (*x) / f ; break;

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
        }
	}
}


