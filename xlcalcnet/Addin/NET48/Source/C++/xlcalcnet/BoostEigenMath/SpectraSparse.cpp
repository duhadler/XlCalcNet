//For now, we do not use version 1.x because of issues with multiple precision types

#include "libEigenSparse.h"

#include <Eigen/Core>
#include <Eigen/SparseCore>
#include <SymEigsSolver.h>
#include <GenEigsSolver.h>
#include <SymEigsShiftSolver.h>
#include <MatOp/SparseSymMatProd.h>
#include <MatOp/SparseGenMatProd.h>
#include <MatOp/SparseSymShiftSolve.h>

using namespace Spectra;





/* nev must satisfy 1 <= nev <= n - 2, n is the size of matrix */
/* ncv must satisfy nev + 2 <= ncv <= n, n is the size of matrix */

void SpectraSparseSymEigsSolver(mpMatrix *eval , mpMatrix *evec , mpSparseMatrix *M, int32_t nev, int32_t ncv)
{
    printf("in SpectraDenseGenEigsSolver \n");
    SparseSymMatProd<mpType> op(*M);
    SymEigsSolver< mpType, LARGEST_ALGE, SparseSymMatProd<mpType> > eigs(&op, nev, ncv);
    eigs.init();
//    int nconv = eigs.compute();
    printf("before eigs.compute \n");
    eigs.compute();
    if(eigs.info() == SUCCESSFUL)
    {
        printf("after success \n");
        *eval = eigs.eigenvalues();
        *evec = eigs.eigenvectors();
    }
}


/* nev must satisfy 1 <= nev <= n - 2, n is the size of matrix */
/* ncv must satisfy nev + 2 <= ncv <= n, n is the size of matrix */

void SpectraSparseGenEigsSolver(mpMatrixC *eval , mpMatrixC *evec, mpSparseMatrix *M, int32_t nev, int32_t ncv)
{
    printf("in SpectraSparseGenEigsSolver \n");
    SparseGenMatProd<mpType> op(*M);
    GenEigsSolver< mpType, LARGEST_MAGN, SparseGenMatProd<mpType> > eigs(&op, nev, ncv);
    eigs.init();
//    int nconv = eigs.compute();
    printf("before eigs.compute \n");
    eigs.compute();
    if(eigs.info() == SUCCESSFUL)
    {
        printf("after success \n");
        *eval = eigs.eigenvalues();
        *evec = eigs.eigenvectors();
    }
}



/* nev must satisfy 1 <= nev <= n - 2, n is the size of matrix */
/* ncv must satisfy nev + 2 <= ncv <= n, n is the size of matrix */

void SpectraSparseSymShiftSolver(mpMatrix *eval , mpMatrix *evec, mpSparseMatrix *M, int32_t nev, int32_t ncv)
{
    SparseSymShiftSolve<mpType> op(*M);
    SymEigsShiftSolver< mpType, LARGEST_MAGN, SparseSymShiftSolve<mpType> > eigs(&op, nev, ncv, 0.0);

    eigs.init();
    eigs.compute();
    if(eigs.info() == SUCCESSFUL)
    {
        *eval = eigs.eigenvalues();
        *evec = eigs.eigenvectors();
    }
}









