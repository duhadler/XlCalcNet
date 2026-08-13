#define Use_Single

#include "mpNumC_Main.h"

#include "libBoostEigenDense.h"
#include "libEigenSparse.h"


/**************************** Dense Matrix: General *********************************************************/


AnyPtr Lib_Eigen_SReal_Init_Func(int32_t mpCat, int32_t numType)
{
    mpNumMatrixPtr dummy = NULL;
    switch (mpCat) {

    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: return (mpNumMatrixPtr) EigenLib_cplx_mpType_Init_Func((mpCplxMatrixPtr) dummy); break;
            case mp_real: return (mpNumMatrixPtr) EigenLib_mpType_Init_Func((mpMatrixPtr) dummy); break;
            default: return NULL;  break;
            }
        }; break;

    case mp_map:   /* map */
        {
            switch (numType) {
            case mp_cplx: return MapLib_cplx_mpType_Init_Func((mpCplxMatrixPtr) dummy); break;
            case mp_real: return MapLib_mpType_Init_Func((mpMatrixPtr) dummy); break;
            default: return NULL;  break;
            }
        }; break;
     default: return NULL;  break;
    }
}




void Lib_Eigen_SReal_Clear(int32_t mpCat, int32_t numType, AnyPtr x)
{
    mpNumMatrixPtr dummy = NULL;
    switch (mpCat) {

    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx:  EigenLib_cplx_mpType_Clear((mpCplxMatrixPtr) x); break;
            case mp_real:  EigenLib_mpType_Clear((mpMatrixPtr) x); break;
            }
        }; break;

    case mp_map:   /* map */
        {
            switch (numType) {
            case mp_cplx:   MapLib_cplx_mpType_Clear((mpmapPtr) x, (mpCplxMatrixPtr) dummy); break;
            case mp_real:  MapLib_mpType_Clear((mpmapPtr) x, (mpMatrixPtr) dummy); break;
            }
        }; break;
    }
}




void Lib_Eigen_SReal_GetCoeff(ScalarResPtr result, long row, long col, mpNumMatrixPtr source)
{
    *((mpType*)result) = (*(mpMatrixPtr) source).coeff(row,col);
}




void Lib_Eigen_SReal_SetCoeff(mpNumMatrixPtr result, ScalarResPtr source, long row, long col)
{
    (*(mpMatrixPtr) result)(row,col) = *((mpType*)source);
}




void Lib_Eigen_SReal_Cplx_GetCoeff2(ScalarResPtr result1, ScalarResPtr result2, long row, long col, mpNumMatrixPtr source)
{
    std::complex<mpType> result = (*(mpCplxMatrixPtr)source).coeff(row, col);
    *((mpType*)result1) = result.real();
    *((mpType*)result2) = result.imag();
}



void Lib_Eigen_SReal_Cplx_SetCoeff2(mpNumMatrixPtr result, ScalarPtr source1, ScalarPtr source2, long row, long col)
{
    (*(mpCplxMatrixPtr)result)(row, col) = std::complex<mpType>(*((mpType*)source1), *((mpType*)source2));
}






uint32_t Lib_Eigen_SReal_GetInfo(int32_t mpCat, int32_t numType, long what, mpNumMatrixPtr Matrix)
{
    long result = 0;
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: EigenLib_cplx_mpType_GetInfo(&result, what, (mpCplxMatrixPtr) Matrix); break;
            case mp_real: EigenLib_mpType_GetInfo(&result, what, (mpMatrixPtr) Matrix); break;
            default: result = 0;  break;
            }
        }; break;
     default: result = 0;  break;
    }
    return result;
}



void Lib_Eigen_SReal_Get_Block(int32_t mpCat, int32_t numType, mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: EigenLib_cplx_mpType_GetBlock((mpCplxMatrixPtr) result, what, i, j, p, q, (mpCplxMatrixPtr) source); break;
            case mp_real: EigenLib_mpType_GetBlock((mpMatrixPtr) result, what, i, j, p, q, (mpMatrixPtr) source); break;
            }
        }; break;
    }
}



void Lib_Eigen_SReal_Put_Block(int32_t mpCat, int32_t numType, mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: EigenLib_cplx_mpType_PutBlock((mpCplxMatrixPtr) result, what, i, j, p, q, (mpCplxMatrixPtr) source); break;
            case mp_real: EigenLib_mpType_PutBlock((mpMatrixPtr) result, what, i, j, p, q, (mpMatrixPtr) source); break;
            }
        }; break;
    }
}



void Lib_Eigen_SReal_SetSpecialValue(int32_t mpCat, int32_t numType, mpNumMatrixPtr result, long what, long m, long n)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: EigenLib_cplx_mpType_SetSpecialValue((mpCplxMatrixPtr) result, what, m, n); break;
            case mp_real: EigenLib_mpType_SetSpecialValue((mpMatrixPtr) result, what, m, n); break;
            }
        }; break;
    }
}



void Lib_Eigen_SReal_SetSpecialValue2(int32_t mpCat, int32_t numType, mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: EigenLib_cplx_mpType_SetSpecialValue2((mpCplxMatrixPtr) result, what, Vertical, Horizontal, PartialMode, (mpCplxMatrixPtr) source); break;
            case mp_real: EigenLib_mpType_SetSpecialValue2((mpMatrixPtr) result, what, Vertical, Horizontal, PartialMode, (mpMatrixPtr) source); break;
            }
        }; break;
    }
}



uint32_t Lib_Eigen_SReal_Compare(int32_t mpCat, int32_t numType, long what, mpNumMatrixPtr x, mpNumMatrixPtr y)
{
    long result;
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: EigenLib_cplx_mpType_Compare(&result, what, (mpCplxMatrixPtr) x, (mpCplxMatrixPtr) y); break;
            case mp_real: EigenLib_mpType_Compare(&result, what, (mpMatrixPtr) x, (mpMatrixPtr) y); break;
            default: result = 0;  break;
            }
        }; break;
     default: result = 0;  break;
    }
    return (uint32_t) result;
}






void Lib_Eigen_SReal_ConvertRealCplx(mpNumMatrixPtr RMat, long what, mpNumMatrixPtr CMat)
{
    EigenLib_ConvertRealCplx((mpMatrixPtr) RMat, what, (mpCplxMatrixPtr)CMat);
}




void Lib_Eigen_SReal_Real_CplxScalarArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, ScalarPtr y_re, ScalarPtr y_im)
{
    EigenLib__mpType_CplxScalarArithmetic((mpCplxMatrixPtr) result, what, (mpMatrixPtr) x, (mpType*) y_re, (mpType*) y_im);
}




/* *********************************************************************************** */





void Lib_Eigen_SReal_BasicArithmetic(int32_t mpCat, int32_t numType, mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: EigenLib_cplx_mpType_BasicArithmetic((mpCplxMatrixPtr) result, what, (mpCplxMatrixPtr) x, (mpCplxMatrixPtr) y); break;
            case mp_real: EigenLib_mpType_BasicArithmetic((mpMatrixPtr) result, what, (mpMatrixPtr) x, (mpMatrixPtr) y); break;
            }
        }; break;
    }
}





void Lib_Eigen_SReal_Stats(int32_t mpCat, int32_t numType, mpNumMatrixPtr result, long what, long PartialMode, mpNumMatrixPtr source)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_real: EigenLib_mpType_Stats((mpMatrixPtr) result, what, PartialMode, (mpMatrixPtr) source); break;
            }
        }; break;
    }
}




void Lib_Eigen_SReal_Stats2(int32_t mpCat, int32_t numType, mpNumMatrixPtr result, long *IndexX, long *IndexY, long what, mpNumMatrixPtr source)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_real: EigenLib_mpType_Stats2((mpMatrixPtr) result, IndexX, IndexY, what, (mpMatrixPtr) source); break;
            }
        }; break;
    }
}




void Lib_Eigen_SReal_Map_GetItemValue(int32_t mpCat, int32_t numType, mpNumMatrixPtr ptr, MapPtr names, char *s)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
        switch (numType) {
        case mp_cplx: MapLib_cplx_mpType_GetItemValue((mpCplxMatrixPtr) ptr, (mpmapPtr) names, s); break;
        case mp_real: MapLib_mpType_GetItemValue((mpMatrixPtr) ptr, (mpmapPtr) names, s); break;
        }
        }; break;
    }
}



void Lib_Eigen_SReal_MultipleResults(int32_t mpCat, int32_t numType, MapPtr z, int32_t what, char *s, mpNumMatrixPtr A, mpNumMatrixPtr b)
{
    switch (mpCat) {
    case mp_eigen:  /* eigen */
        {
            switch (numType) {
            case mp_cplx: EigenLib_cplx_mpType_MultipleResults((mpmapPtr)z, what, string(s), (mpCplxMatrixPtr) A, (mpCplxMatrixPtr) b); break;
            case mp_real: EigenLib_mpType_MultipleResults((mpmapPtr)z, what, string(s), (mpMatrixPtr) A, (mpMatrixPtr) b);
             break;


            }
        }; break;
    }
}




/**************************** Dense Matrix: Extras *********************************************************/




void Lib_Eigen_SReal_Sort(int32_t numType, mpNumMatrixPtr x, int32_t SortOrder, int32_t SortCriterion)
{
    switch (numType) {
    case mp_cplx: EigenLib_cplx_mpType_Sort((mpCplxMatrixPtr) x, SortOrder, SortCriterion); break;
    case mp_real: EigenLib_mpType_Sort((mpMatrixPtr) x, SortOrder, SortCriterion); break;
    }
}



void Lib_Eigen_SReal_SortRowsByColumn(int32_t numType, mpNumMatrixPtr A, int32_t ColumnToSortBy, int32_t SortOrder, int32_t SortCriterion)
{
    switch (numType) {
    case mp_cplx: EigenLib_cplx_mpType_SortRowsByColumn((mpCplxMatrixPtr) A, ColumnToSortBy, SortOrder, SortCriterion); break;
    case mp_real: EigenLib_mpType_SortRowsByColumn((mpMatrixPtr) A, ColumnToSortBy, SortOrder, SortCriterion); break;
    }
}



void Lib_Eigen_SReal_Select_Rows(int32_t numType, mpNumMatrixPtr res, mpNumMatrixPtr A)
{
    switch (numType) {
    case mp_cplx: EigenLib_cplx_mpType_Select_Rows((mpCplxMatrixPtr) res, (mpCplxMatrixPtr) A); break;
    case mp_real: EigenLib_mpType_Select_Rows((mpMatrixPtr) res, (mpMatrixPtr) A); break;
    }
}



/* *********************************************************************************** */


void Lib_Eigen_SReal_Real_Roots_To_MonicPolynomial(mpNumMatrixPtr polynomial_result, mpNumMatrixPtr roots_source)
{
    EigenLib_mpType_Roots_To_MonicPolynomial((mpMatrixPtr) polynomial_result, (mpMatrixPtr) roots_source);
}



void Lib_Eigen_SReal_Real_Poly_Eval(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr roots_source)
{
    EigenLib_mpType_Poly_Eval((mpMatrixPtr) evaluation_result, (mpMatrixPtr) polynomial_source, (mpMatrixPtr) roots_source);
}



void Lib_Eigen_SReal_Real_Poly_Eval_Complex(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr cplxroots_source)
{
    EigenLib_mpType_Poly_Eval_Complex((mpCplxMatrixPtr) evaluation_result, (mpMatrixPtr) polynomial_source, (mpCplxMatrixPtr) cplxroots_source);
}



void Lib_Eigen_SReal_Real_PolynomialSolver(mpNumMatrixPtr cplxroots_result, mpNumMatrixPtr polynomial_source)
{
    EigenLib_mpType_PolynomialSolver((mpCplxMatrixPtr) cplxroots_result, (mpMatrixPtr) polynomial_source);
}




void Lib_Eigen_SReal_Cplx_Roots_To_MonicPolynomial(mpNumMatrixPtr polynomial_result, mpNumMatrixPtr roots_source)
{
    EigenLib_cplx_mpType_Roots_To_MonicPolynomial((mpCplxMatrixPtr) polynomial_result, (mpCplxMatrixPtr) roots_source);
}


void Lib_Eigen_SReal_Cplx_Poly_Eval_Complex(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr roots_source)
{
    EigenLib_cplx_mpType_Poly_Eval_Complex((mpCplxMatrixPtr) evaluation_result, (mpCplxMatrixPtr) polynomial_source, (mpCplxMatrixPtr) roots_source);;
}


void Lib_Eigen_SReal_Cplx_PolynomialSolver(mpNumMatrixPtr cplxroots_result, mpNumMatrixPtr polynomial_source)
{
    EigenLib_cplx_mpType_PolynomialSolver((mpCplxMatrixPtr) cplxroots_result, (mpCplxMatrixPtr) polynomial_source);
}



/* *********************************************************************************** */




void Lib_Eigen_SReal_Cplx_FFT_Fwd(mpNumMatrixPtr result, mpNumMatrixPtr source)
{
    EigenLib_cplx_mpType_FFT_fwd((mpCplxMatrixPtr) result, (mpCplxMatrixPtr) source);
}


void Lib_Eigen_SReal_Cplx_FFT_Inv(mpNumMatrixPtr result, mpNumMatrixPtr source)
{
    EigenLib_cplx_mpType_FFT_inv((mpCplxMatrixPtr) result, (mpCplxMatrixPtr) source);
}





void Lib_Eigen_SReal_Real_FFT_Real_Fwd(mpNumMatrixPtr result, mpNumMatrixPtr source)
{
    EigenLib_mpType_FFT_real_fwd((mpCplxMatrixPtr) result, (mpMatrixPtr) source);
}


void Lib_Eigen_SReal_Real_FFT_Real_Inv(mpNumMatrixPtr result, mpNumMatrixPtr source)
{
    EigenLib_mpType_FFT_real_inv((mpMatrixPtr) result, (mpCplxMatrixPtr) source);
}





/* *********************************************************************************** */


//
//
//
//void Lib_Eigen_SReal_Real_MatrixFunction(mpNumMatrixPtr result, long what, mpNumMatrixPtr A)
//{
//    EigenLib_mpType_MatrixFunction((mpMatrixPtr) result, what, (mpMatrixPtr) A);
//}
//
//
//
//
//void Lib_Eigen_SReal_Cplx_MatrixFunction(mpNumMatrixPtr result, long what, mpNumMatrixPtr A)
//{
//    EigenLib_cplx_mpType_MatrixFunction((mpCplxMatrixPtr) result, what, (mpCplxMatrixPtr) A);
//}
//
//



/* *********************************************************************************** */







void Lib_Eigen_SReal_Real_testHybrj_ext(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matFvec_, mpNumMatrixPtr matFjac_, mpNumMatrixPtr matInput)
{
    testHybrj_ext((AnyFuncPtr)  f1, (AnyFuncPtr)  f2, (mpMatrixPtr) matX_, (mpMatrixPtr) matFvec_, (mpMatrixPtr) matFjac_, (mpMatrixPtr) matInput);
}



void Lib_Eigen_SReal_Real_testLmder_ext(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matFvec_, mpNumMatrixPtr matFjac_, mpNumMatrixPtr matInput)
{
    testLmder_ext((AnyFuncPtr)  f1, (AnyFuncPtr)  f2, (mpMatrixPtr) matX_, (mpMatrixPtr) matFvec_, (mpMatrixPtr) matFjac_, (mpMatrixPtr) matInput);
}







void Lib_Eigen_SReal_Real_CppOptLib1(int32_t what, FuncPtr f1, mpNumMatrixPtr matX_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr)
{
    EigenLib_mpType_CppOptLibDirect1(what, (AnyFuncPtr) f1, (mpMatrixPtr) matX_, (mpMatrixPtr) matNorm_, (mpMatrixPtr) xPtr, (mpMatrixPtr) resPtr);
}



void Lib_Eigen_SReal_Real_CppOptLib2(int32_t what, FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr)
{
    EigenLib_mpType_CppOptLibDirect2(what, (AnyFuncPtr) f1, (AnyFuncPtr) f2, (mpMatrixPtr) matX_, (mpMatrixPtr) matGrad_, (mpMatrixPtr) matNorm_, (mpMatrixPtr) xPtr, (mpMatrixPtr) resPtr);
}




void Lib_Eigen_SReal_Real_CppOptLib3(int32_t what, FuncPtr f1, FuncPtr f2, FuncPtr f3, mpNumMatrixPtr matX_, mpNumMatrixPtr matHessian_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr)
{
    EigenLib_mpType_CppOptLibDirect3(what, (AnyFuncPtr) f1, (AnyFuncPtr) f2, (AnyFuncPtr) f3, (mpMatrixPtr) matX_, (mpMatrixPtr) matHessian_, (mpMatrixPtr) matGrad_, (mpMatrixPtr) matNorm_, (mpMatrixPtr) xPtr, (mpMatrixPtr) resPtr);
}





/**************************** Sparse Real Matrix ********************************************************/



mpNumMatrixPtr Lib_EigenSparse_SReal_Init_Func()
{
    mpNumMatrixPtr dummy = NULL;
    return (mpNumMatrixPtr) EigenSparseLib_mpType_Init_Func((mpSparseMatrixPtr) dummy);
}


void Lib_EigenSparse_SReal_Clear(mpNumMatrixPtr x)
{
    EigenSparseLib_mpType_Clear((mpSparseMatrixPtr) x);
}


uint32_t Lib_EigenSparse_SReal_GetInfo(long what, mpNumMatrixPtr SparseMatrix)
{
     long result;
     EigenSparseLib_mpType_GetInfo(&result, what, (mpSparseMatrixPtr) SparseMatrix);
     return result;
}



void Lib_EigenSparse_SReal_Get_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source)
{
    EigenSparseLib_mpType_GetBlock((mpSparseMatrixPtr) result, what, i, j, p, q, (mpSparseMatrixPtr) source);
}


void Lib_EigenSparse_SReal_Put_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source)
{
    EigenSparseLib_mpType_PutBlock((mpSparseMatrixPtr) result, what, i, j, p, q, (mpSparseMatrixPtr) source);
}




void Lib_EigenSparse_SReal_SetSpecialValue(mpNumMatrixPtr xPtr, long what, long m, long n)
{
    EigenSparseLib_mpType_SetSpecialValue((mpSparseMatrixPtr) xPtr, what, m, n);
}



void Lib_EigenSparse_SReal_SetSpecialValue2(mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source)
{
    EigenSparseLib_mpType_SetSpecialValue2((mpSparseMatrixPtr) result, what, Vertical, Horizontal, PartialMode, (mpSparseMatrixPtr) source);
}




void Lib_EigenSparse_SReal_BasicArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y)
{
    EigenSparseLib_mpType_BasicArithmetic((mpSparseMatrixPtr) result, what, (mpSparseMatrixPtr) x, (mpSparseMatrixPtr) y);
}




void Lib_EigenSparse_SReal_Stats(mpNumMatrixPtr result, long what, long PartialMode, mpNumMatrixPtr source)
{
    EigenSparseLib_mpType_Stats((mpSparseMatrixPtr) result, what, PartialMode, (mpSparseMatrixPtr) source);
}



void EigenSparseLib_SReal_DenseFromSparse(mpNumMatrixPtr result, mpNumMatrixPtr source)
{
    EigenSparseLib_mpType_DenseFromSparse((mpMatrixPtr) result, (mpSparseMatrixPtr) source);
}


void EigenSparseLib_SReal_SparseFromDense(mpNumMatrixPtr result, mpNumMatrixPtr source)
{
    EigenSparseLib_mpType_SparseFromDense((mpSparseMatrixPtr) result, (mpMatrixPtr) source);
}


void EigenSparseLib_SReal_Solve(mpNumMatrixPtr x, mpNumMatrixPtr A, mpNumMatrixPtr b, long Decomposition)
{
    EigenSparseLib_mpType_Solve((mpMatrixPtr) x, (mpSparseMatrixPtr) A, (mpMatrixPtr) b, Decomposition);
}





void Lib_SReal_PrintSparseMatrix(mpNumMatrixPtr M)
{
    PrintSparseMatrix( (mpSparseMatrixPtr) M);
}





//****************************Sparse Complex Matrix*********************************************************



mpNumMatrixPtr Lib_EigenSparse_SReal_Cplx_Init_Func()
{
    mpNumMatrixPtr dummy = NULL;
    return (mpNumMatrixPtr) EigenSparseLib_cplx_mpType_Init_Func((mpCplxSparseMatrixPtr) dummy);
}


void Lib_EigenSparse_SReal_Cplx_Clear(mpNumMatrixPtr x)
{
    EigenSparseLib_cplx_mpType_Clear((mpCplxSparseMatrixPtr) x);
}


uint32_t Lib_EigenSparse_SReal_Cplx_GetInfo(long what, mpNumMatrixPtr SparseMatrix)
{
     long result;
     EigenSparseLib_cplx_mpType_GetInfo(&result, what, (mpCplxSparseMatrixPtr) SparseMatrix);
     return result;
}



void Lib_EigenSparse_SReal_Cplx_Get_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source)
{
    EigenSparseLib_cplx_mpType_GetBlock((mpCplxSparseMatrixPtr) result, what, i, j, p, q, (mpCplxSparseMatrixPtr) source);
}


void Lib_EigenSparse_SReal_Cplx_Put_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source)
{
    EigenSparseLib_cplx_mpType_PutBlock((mpCplxSparseMatrixPtr) result, what, i, j, p, q, (mpCplxSparseMatrixPtr) source);
}




void Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpNumMatrixPtr xPtr, long what, long m, long n)
{
    EigenSparseLib_cplx_mpType_SetSpecialValue((mpCplxSparseMatrixPtr) xPtr, what, m, n);
}



void Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source)
{
    EigenSparseLib_cplx_mpType_SetSpecialValue2((mpCplxSparseMatrixPtr) result, what, Vertical, Horizontal, PartialMode, (mpCplxSparseMatrixPtr) source);
}




void Lib_EigenSparse_SReal_Cplx_BasicArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y)
{
    EigenSparseLib_cplx_mpType_BasicArithmetic((mpCplxSparseMatrixPtr) result, what, (mpCplxSparseMatrixPtr) x, (mpCplxSparseMatrixPtr) y);
}





void EigenSparseLib_SReal_Cplx_DenseFromSparse(mpNumMatrixPtr result, mpNumMatrixPtr source)
{
    EigenSparseLib_cplx_mpType_DenseFromSparse((mpCplxMatrixPtr) result, (mpCplxSparseMatrixPtr) source);
}


void EigenSparseLib_SReal_Cplx_SparseFromDense(mpNumMatrixPtr result, mpNumMatrixPtr source)
{
    EigenSparseLib_cplx_mpType_SparseFromDense((mpCplxSparseMatrixPtr) result, (mpCplxMatrixPtr) source);
}




void EigenSparseLib_SReal_Cplx_Solve(mpNumMatrixPtr x, mpNumMatrixPtr A, mpNumMatrixPtr b, long Decomposition)
{
    EigenSparseLib_cplx_mpType_Solve((mpCplxMatrixPtr) x, (mpCplxSparseMatrixPtr) A, (mpCplxMatrixPtr) b, Decomposition);
}





