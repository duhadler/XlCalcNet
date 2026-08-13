//#include "stdafx.h"
#include "libEigenSparse.h"



/* SPD */
void EigenSparseLib_mpType_Solve_ConjugateGradient(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b)
{
//ConjugateGradient<mpSparseMatrix, Eigen::Upper> solver;
ConjugateGradient<mpSparseMatrix> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* SPD */
void EigenSparseLib_mpType_Solve_SimplicialLLT(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b)
{
//SimplicialLLT<mpSparseMatrix, Eigen::Upper> solver;
SimplicialLLT<mpSparseMatrix> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* SPD */
void EigenSparseLib_mpType_Solve_SimplicialLDLT(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b)
{
//SimplicialLDLT <mpSparseMatrix, Eigen::Upper> solver;
SimplicialLDLT <mpSparseMatrix> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* Square */
void EigenSparseLib_mpType_Solve_SparseLU(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b)
{
SparseLU <mpSparseMatrix> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}


/* Square */
void EigenSparseLib_mpType_Solve_BiCGSTAB(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b)
{
BiCGSTAB<mpSparseMatrix> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* Rectangular */
void EigenSparseLib_mpType_Solve_SparseQR(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b)
{
SparseQR<mpSparseMatrix, COLAMDOrdering<int> > solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



/* Rectangular */
void EigenSparseLib_mpType_Solve_LeastSquaresConjugateGradient(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b)
{
LeastSquaresConjugateGradient<mpSparseMatrix> solver;
solver.compute(*A);
(*x) = solver.solve(*b);
}



void EigenSparseLib_mpType_Solve(mpMatrix *x, mpSparseMatrix *A, mpMatrix *b, long Decomposition)
{
	switch (Decomposition) {
		case mp_llt: EigenSparseLib_mpType_Solve_SimplicialLLT(x, A, b); break;
		case mp_ldlt: EigenSparseLib_mpType_Solve_SimplicialLDLT(x, A, b); break;
		case mp_lu: EigenSparseLib_mpType_Solve_SparseLU(x, A, b); break;
		case mp_householderQr: EigenSparseLib_mpType_Solve_SparseQR(x, A, b); break;

		case mp_CG_Solver: EigenSparseLib_mpType_Solve_ConjugateGradient(x, A, b); break;
		case mp_LSCG_Solver: EigenSparseLib_mpType_Solve_LeastSquaresConjugateGradient(x, A, b); break;
		case mp_BiCGSTAB_Solver: EigenSparseLib_mpType_Solve_BiCGSTAB(x, A, b); break;

	}
}



