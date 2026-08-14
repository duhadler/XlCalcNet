//For now, we do not use version 1.x because of issues with multiple precision types

#include "libEigenSparse.h"

#include <Eigen/Core>
#include <SymEigsSolver.h>  // Also includes <MatOp/DenseSymMatProd.h>
#include <GenEigsSolver.h>  // Also includes <MatOp/DenseGenMatProd.h>
#include <SymEigsShiftSolver.h>  // Also includes <MatOp/DenseSymShiftSolve.h>
#include <iostream>

using namespace Spectra;




/* nev must satisfy 1 <= nev <= n - 2, n is the size of matrix */
/* ncv must satisfy nev + 2 <= ncv <= n, n is the size of matrix */

void SpectraDenseSymEigsSolver(mpMatrix *eval , mpMatrix *evec , mpMatrix *M, int32_t nev, int32_t ncv)
{
    printf("in SpectraDenseGenEigsSolver \n");
    DenseSymMatProd<mpType> op(*M);
    SymEigsSolver< mpType, LARGEST_ALGE, DenseSymMatProd<mpType> > eigs(&op, nev, ncv);
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

void SpectraDenseGenEigsSolver(mpMatrixC *eval , mpMatrixC *evec, mpMatrix *M, int32_t nev, int32_t ncv)
{
    printf("in SpectraDenseGenEigsSolver \n");
    DenseGenMatProd<mpType> op(*M);
    GenEigsSolver< mpType, LARGEST_MAGN, DenseGenMatProd<mpType> > eigs(&op, nev, ncv);
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

void SpectraDenseSymShiftSolver(mpMatrix *eval , mpMatrix *evec, mpMatrix *M, int32_t nev, int32_t ncv)
{
    printf("in SpectraDenseSymShiftSolver \n");
    DenseSymShiftSolve<mpType> op(*M);
    SymEigsShiftSolver< mpType, LARGEST_MAGN, DenseSymShiftSolve<mpType> > eigs(&op, nev, ncv, 0.0);
    printf("before eigs.init(); \n");
    eigs.init();
    printf("before eigs.compute \n");
    eigs.compute();

    if(eigs.info() == SUCCESSFUL)
    {
        printf("after success \n");
        *eval = eigs.eigenvalues();
        *evec = eigs.eigenvectors();
    }
}



