

#ifndef MPNUMC_EIGENQREAL_H_INCLUDED
#define MPNUMC_EIGENQREAL_H_INCLUDED




/**************************** Dense Matrix: General *********************************************************/

MPNUMC_DLL_IMPORTEXPORT AnyPtr  __cdecl Lib_Eigen_QReal_Init_Func(int32_t mpCat, int32_t mpType);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Clear(int32_t mpCat, int32_t mpType, AnyPtr x);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_GetCoeff(ScalarResPtr result, long row, long col, mpNumMatrixPtr Matrix);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_SetCoeff(mpNumMatrixPtr Matrix, ScalarResPtr result, long row, long col);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Cplx_GetCoeff2(ScalarResPtr result1, ScalarResPtr result2, long row, long col, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Cplx_SetCoeff2(mpNumMatrixPtr result, ScalarPtr source1, ScalarPtr source2, long row, long col);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl  Lib_Eigen_QReal_GetInfo(int32_t mpCat, int32_t mpType, long what, mpNumMatrixPtr Matrix);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Get_Block(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Put_Block(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_SetSpecialValue(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long m, long n);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_SetSpecialValue2(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl  Lib_Eigen_QReal_Compare(int32_t mpCat, int32_t mpType, long what, mpNumMatrixPtr x, mpNumMatrixPtr y);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_ConvertRealCplx(mpNumMatrixPtr RMat, long what, mpNumMatrixPtr CMat);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Real_CplxScalarArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, ScalarPtr y_re, ScalarPtr y_im);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_BasicArithmetic(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Stats(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long what, long PartialMode, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Stats2(int32_t mpCat, int32_t mpType, mpNumMatrixPtr result, long *IndexX, long *IndexY, long what, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_Map_GetItemValue(int32_t mpCat, int32_t mpType, mpNumMatrixPtr ptr, MapPtr z, char *s);
MPNUMC_DLL_IMPORTEXPORT void  __cdecl Lib_Eigen_QReal_MultipleResults(int32_t mpCat, int32_t mpType, MapPtr z, int32_t what, char *s, mpNumMatrixPtr A, mpNumMatrixPtr b);

/**************************** Dense Matrix: Extras *********************************************************/

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_QReal_Sort(int32_t numType, mpNumMatrixPtr x, int32_t SortOrder, int32_t SortCriterion);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_SortRowsByColumn(int32_t numType, mpNumMatrixPtr A, int32_t ColumnToSortBy, int32_t SortOrder, int32_t SortCriterion);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Select_Rows(int32_t numType, mpNumMatrixPtr res, mpNumMatrixPtr A);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_Roots_To_MonicPolynomial(mpNumMatrixPtr polynomial_result, mpNumMatrixPtr roots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_Poly_Eval(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr roots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_Poly_Eval_Complex(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr cplxroots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_PolynomialSolver(mpNumMatrixPtr cplxroots_result, mpNumMatrixPtr polynomial_source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_QReal_Cplx_Roots_To_MonicPolynomial(mpNumMatrixPtr polynomial_result, mpNumMatrixPtr roots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_QReal_Cplx_Poly_Eval_Complex(mpNumMatrixPtr evaluation_result, mpNumMatrixPtr polynomial_source, mpNumMatrixPtr roots_source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl Lib_Eigen_QReal_Cplx_PolynomialSolver(mpNumMatrixPtr cplxroots_result, mpNumMatrixPtr polynomial_source);

/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Cplx_FFT_Fwd(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Cplx_FFT_Inv(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_FFT_Real_Fwd(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_FFT_Real_Inv(mpNumMatrixPtr result, mpNumMatrixPtr source);


/* *********************************************************************************** */

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_MatrixFunction(mpNumMatrixPtr result, long what, mpNumMatrixPtr A);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Cplx_MatrixFunction(mpNumMatrixPtr result, long what, mpNumMatrixPtr A);

/**************************** Eigen Calculus *********************************************************/

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_testHybrj_ext(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matFvec_, mpNumMatrixPtr matFjac_, mpNumMatrixPtr matInput);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_testLmder_ext(FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matFvec_, mpNumMatrixPtr matFjac_, mpNumMatrixPtr matInput);


MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_CppOptLib1(int32_t what, FuncPtr f1, mpNumMatrixPtr matX_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_CppOptLib2(int32_t what, FuncPtr f1, FuncPtr f2, mpNumMatrixPtr matX_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_CppOptLib3(int32_t what, FuncPtr f1, FuncPtr f2, FuncPtr f3, mpNumMatrixPtr matX_, mpNumMatrixPtr matHessian_, mpNumMatrixPtr matGrad_, mpNumMatrixPtr matNorm_, mpNumMatrixPtr xPtr, mpNumMatrixPtr resPtr);//




//MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_demoLinearRegression();
//MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_demoLogisticRegression();
//MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_Eigen_QReal_Real_demoNonNegativeLeastSquares();




/****************************Sparse Real Matrix*********************************************************/

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_QReal_PrintSparseMatrix(mpNumMatrixPtr M);

MPNUMC_DLL_IMPORTEXPORT mpNumMatrixPtr __cdecl Lib_EigenSparse_QReal_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Clear(mpNumMatrixPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl  Lib_EigenSparse_QReal_GetInfo(long what, mpNumMatrixPtr SourceMatrix);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Get_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Put_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_SetSpecialValue(mpNumMatrixPtr result, long what, long m, long n);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_SetSpecialValue2(mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_BasicArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Stats(mpNumMatrixPtr result, long what, long PartialMode, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_QReal_Solve(mpNumMatrixPtr x, mpNumMatrixPtr A, mpNumMatrixPtr b, long Decomposition);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_QReal_DenseFromSparse(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_QReal_SparseFromDense(mpNumMatrixPtr result, mpNumMatrixPtr source);



/**************************** Eigen: Sparse Complex Matrix***********************************************/


MPNUMC_DLL_IMPORTEXPORT mpNumMatrixPtr __cdecl Lib_EigenSparse_QReal_Cplx_Init_Func();
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Cplx_Clear(mpNumMatrixPtr x);

MPNUMC_DLL_IMPORTEXPORT uint32_t __cdecl  Lib_EigenSparse_QReal_Cplx_GetInfo(long what, mpNumMatrixPtr SourceMatrix);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Cplx_Get_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Cplx_Put_Block(mpNumMatrixPtr result, long what, long i, long j, long p, long q, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpNumMatrixPtr result, long what, long m, long n);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(mpNumMatrixPtr result, long what, long Vertical, long Horizontal, long PartialMode, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  Lib_EigenSparse_QReal_Cplx_BasicArithmetic(mpNumMatrixPtr result, long what, mpNumMatrixPtr x, mpNumMatrixPtr y);


MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_QReal_Cplx_DenseFromSparse(mpNumMatrixPtr result, mpNumMatrixPtr source);
MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_QReal_Cplx_SparseFromDense(mpNumMatrixPtr result, mpNumMatrixPtr source);

MPNUMC_DLL_IMPORTEXPORT void __cdecl  EigenSparseLib_QReal_Cplx_Solve(mpNumMatrixPtr x, mpNumMatrixPtr A, mpNumMatrixPtr b, long Decomposition);





#endif // MPNUMC_EIGENQREAL_H_INCLUDED


