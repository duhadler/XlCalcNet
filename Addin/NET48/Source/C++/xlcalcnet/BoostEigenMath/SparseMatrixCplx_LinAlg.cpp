//#include "stdafx.h"
#include "libEigenSparse.h"



/* SPD */
void EigenSparseLib_cplx_mpType_Solve_ConjugateGradient(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b)
{
//ConjugateGradient<mpSparseMatrixC, Eigen::Upper> solver;
ConjugateGradient<mpSparseMatrixC> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* SPD */
void EigenSparseLib_cplx_mpType_Solve_SimplicialLLT(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b)
{
//SimplicialLLT<mpSparseMatrixC, Eigen::Upper> solver;
SimplicialLLT<mpSparseMatrixC> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* SPD */
void EigenSparseLib_cplx_mpType_Solve_SimplicialLDLT(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b)
{
//SimplicialLDLT <mpSparseMatrixC, Eigen::Upper> solver;
SimplicialLDLT <mpSparseMatrixC> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* Square */
void EigenSparseLib_cplx_mpType_Solve_SparseLU(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b)
{
SparseLU <mpSparseMatrixC> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}


/* Square */
/* In BiCGTAB.h changes were made at line 52    */
void EigenSparseLib_cplx_mpType_Solve_BiCGSTAB(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b)
{
BiCGSTAB<mpSparseMatrixC> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* Rectangular */
void EigenSparseLib_cplx_mpType_Solve_SparseQR(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b)
{
SparseQR<mpSparseMatrixC, COLAMDOrdering<int> > solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* Rectangular */
void EigenSparseLib_cplx_mpType_Solve_LeastSquaresConjugateGradient(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b)
{
LeastSquaresConjugateGradient<mpSparseMatrixC> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



void EigenSparseLib_cplx_mpType_Solve(mpMatrixC *x, mpSparseMatrixC *A, mpMatrixC *b, long Decomposition)
{
	switch (Decomposition) {
		case mp_llt: EigenSparseLib_cplx_mpType_Solve_SimplicialLLT(x, A, b); break;
		case mp_ldlt: EigenSparseLib_cplx_mpType_Solve_SimplicialLDLT(x, A, b); break;
		case mp_lu: EigenSparseLib_cplx_mpType_Solve_SparseLU(x, A, b); break;
		case mp_householderQr: EigenSparseLib_cplx_mpType_Solve_SparseQR(x, A, b); break;

		case mp_CG_Solver: EigenSparseLib_cplx_mpType_Solve_ConjugateGradient(x, A, b); break;
		case mp_LSCG_Solver: EigenSparseLib_cplx_mpType_Solve_LeastSquaresConjugateGradient(x, A, b); break;
		case mp_BiCGSTAB_Solver: EigenSparseLib_cplx_mpType_Solve_BiCGSTAB(x, A, b); break;

	}
}



