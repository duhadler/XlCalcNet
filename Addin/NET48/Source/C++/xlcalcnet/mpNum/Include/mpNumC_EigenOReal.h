

#ifndef MPNUMC_EIGENOREAL_H_INCLUDED
#define MPNUMC_EIGENOREAL_H_INCLUDED




/**************************** Dense Matrix: General *********************************************************/

MPNUMC_DLL_IMPORTEXPORT AnyPtr  __cdecl Lib_Eigen_OReal_Init_Func(int32_t mpCat, int32_t mpType);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Clear(int32_t mpCat, int32_t mpType, AnyPtr x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_GetCoeff(ScalarResPtr result, long row, long col, mpNumMatrixPtr Matrix);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_SetCoeff(mpNumMatrixPtr Matrix, ScalarResPtr result, long row, long col);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Cplx_GetCoeff2(ScalarResPtr result1, ScalarResPtr result2, long row, long col, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Cplx_SetCoeff2(mpNumMatrixPtr result, ScalarPtr source1, ScalarPtr source2, long row, long col);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl  Lib_Eigen_OReal_GetInfo(int32_t mpCat, int32_t mpType, long what, mpNumMatrixPtr Matrix);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Get_Block(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Put_Block(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_SetSpecialValue(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long m, long n);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_SetSpecialValue2(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl  Lib_Eigen_OReal_Compare(int32_t mpCat, int32_t mpType, long what, mpNumMatrixPtr x, mpNumMatrixPtr y);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_ConvertRealCplx(mpNumMatrixPtr RMat, long what, mpNumMatrixPtr CMat);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Real_CplxScalarArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, ScalarPtr y_re, ScalarPtr y_im);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_BasicArithmetic(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Stats(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long PartialMode, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Stats2(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long *IndexX, long *IndexY, long what, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_Map_GetItemValue(int32_t mpCat, int32_t mpType, mpNumMatrixPtr ptr, MapPtr z, char *s);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_OReal_MultipleResults(int32_t mpCat, int32_t mpType, MapPtr z, int32_t what, char *s, mpNumMatrixPtr A, mpNumMatrixPtr b);

/**************************** Dense Matrix: Extras *********************************************************/

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_OReal_Sort(int32_t numType, mpNumMatrixPtr x, int32_t SortOrder, int32_t SortCriterion);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_SortRowsByColumn(int32_t numType, mpNumMatrixPtr A, int32_t ColumnToSortBy, int32_t SortOrder, int32_t SortCriterion);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Select_Rows(int32_t numType, mpNumMatrixPtr res, mpNumMatrixPtr A);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_Roots_To_MonicPolynomial(mpNumMatrixPtr polynomial_result, mpNumMatrixPtr roots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_Poly_Eval(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr roots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_Poly_Eval_Complex(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr cplxroots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_PolynomialSolver(mpNumMatrixPtr cplxroots_result, mpNumMatrixPtr polynomial_source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_OReal_Cplx_Roots_To_MonicPolynomial(mpNumMatrixPtr polynomial_result, mpNumMatrixPtr roots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_OReal_Cplx_Poly_Eval_Complex(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr roots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_OReal_Cplx_PolynomialSolver(mpNumMatrixPtr cplxroots_result, mpNumMatrixPtr polynomial_source);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Cplx_FFT_Fwd(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Cplx_FFT_Inv(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_FFT_Real_Fwd(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_FFT_Real_Inv(mpNumMatrixPtr result, mpNumMatrixPtr source);


/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_MatrixFunction(mpNumMatrixPtr result, long what, mpNumMatrixPtr A);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Cplx_MatrixFunction(mpNumMatrixPtr result, long what, mpNumMatrixPtr A);

/**************************** Eigen Calculus *********************************************************/

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_testHybrj_ext(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matFvec_, mpNumMatrixPtr matFjac_, mpNumMatrixPtr matInput);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_testLmder_ext(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matFvec_, mpNumMatrixPtr matFjac_, mpNumMatrixPtr matInput);


MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_CppOptLib1(int32_t what, FuncPtr f1, mpNumMatrixPtr matX_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_CppOptLib2(int32_t what, FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_CppOptLib3(int32_t what, FuncPtr f1, FuncPtr f2, FuncPtr f3, mpNumMatrixPtr matX_, mpNumMatrixPtr matHessian_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr);//




//MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_demoLinearRegression();
//MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_OReal_Real_demoLogisticRegression();




/****************************Sparse Real Matrix*********************************************************/

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_OReal_PrintSparseMatrix(mpNumMatrixPtr M);

MPNUMC_DLL_IMPORTEXPORT mpNumMatrixPtr __cdecl Lib_EigenSparse_OReal_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Clear(mpNumMatrixPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl  Lib_EigenSparse_OReal_GetInfo(long what, mpNumMatrixPtr SourceMatrix);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Get_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Put_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_SetSpecialValue(mpNumMatrixPtr result, long what, long m, long n);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_SetSpecialValue2(mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_BasicArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Stats(mpNumMatrixPtr result, long what, long PartialMode, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_OReal_Solve(mpNumMatrixPtr x, mpNumMatrixPtr A, mpNumMatrixPtr b, long Decomposition);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_OReal_DenseFromSparse(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_OReal_SparseFromDense(mpNumMatrixPtr result, mpNumMatrixPtr source);



/**************************** Eigen: Sparse Complex Matrix***********************************************/


MPNUMC_DLL_IMPORTEXPORT mpNumMatrixPtr __cdecl Lib_EigenSparse_OReal_Cplx_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Cplx_Clear(mpNumMatrixPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl  Lib_EigenSparse_OReal_Cplx_GetInfo(long what, mpNumMatrixPtr SourceMatrix);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Cplx_Get_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Cplx_Put_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Cplx_SetSpecialValue(mpNumMatrixPtr result, long what, long m, long n);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Cplx_SetSpecialValue2(mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_OReal_Cplx_BasicArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_OReal_Cplx_DenseFromSparse(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_OReal_Cplx_SparseFromDense(mpNumMatrixPtr result, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_OReal_Cplx_Solve(mpNumMatrixPtr x, mpNumMatrixPtr A, mpNumMatrixPtr b, long Decomposition);










#endif // MPNUMC_EIGENOREAL_H_INCLUDED


