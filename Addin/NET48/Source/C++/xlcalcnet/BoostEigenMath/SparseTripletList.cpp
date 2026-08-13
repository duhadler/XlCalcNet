//For now, we do not use version 1.x because of issues with multiple precision types

#include "libEigenSparse.h"

#include <Eigen/Core>
#include <Eigen/SparseCore>
#include <iostream>



//void MakeSparseMatrix()
//{
////    /* A band matrix with 1 on the main diagonal, 2 on the below-main subdiagonal,
////       and 3 on the above-main subdiagonal */
////
////    printf("in demoSpectraSparseSymEigsSolver \n");
////    const int n = 10;
//////    Eigen::SparseMatrix<double> M(n, n);
////    mpSparseMatrix M(n, n);
////
////
////    printf("before matrix creation \n");
////    M.reserve(Eigen::VectorXi::Constant(n, 3));
////    for(int i = 0; i < n; i++)
////    {
////        M.insert(i, i) = 1.0;
////        if(i > 0)
////            M.insert(i - 1, i) = 2.0;
////        if(i < n - 1)
////            M.insert(i + 1, i) = 2.0;
////    }
//}




void PrintSparseMatrix(mpSparseMatrix *M)
{

    printf("in PrintSparseMatrix \n");
    for (int k=0; k<(*M).outerSize(); ++k)
        for (SparseMatrix<mpType>::InnerIterator it((*M),k); it; ++it)
        {
#if !defined(Use_MpAny)
            std::cout << "row: " << it.row() << ", col: " << it.col()  << ", value: " << it.value() << std::endl;
#else
            std::cout << "row: " << it.row() << ", col: " << it.col()  << ", value: " << it.value().toDouble() << std::endl;
#endif // defined
        }
}



void SparseMatrixFromTripletList(mpSparseMatrix *M, mpMatrix *Source)
{
    printf("in SparseMatrixFromTripletList \n");
    typedef Eigen::Triplet<mpType> T;
    std::vector<T> tripletList;
    int32_t rows = 0;
    int32_t cols = 0;
    tripletList.reserve((*Source).rows() + 1);
    for(int k = 0; k < rows; k++)
    {
#if defined(Use_MpAny)
        int32_t i = (*Source).coeff(k, 0).toInt();
        if (i > rows) rows = i;
        int32_t j = (*Source).coeff(k, 1).toInt();
        if (j > cols) cols = j;
#else
        int32_t i = (int32_t) (*Source).coeff(k, 0);
        if (i > rows) rows = i;
        int32_t j = (int32_t) (*Source).coeff(k, 1);
        if (j > cols) cols = j;
#endif
        mpType v_ij = (*Source).coeff(k, 2);
        tripletList.push_back(T(i,j,v_ij));
    }
    (*M).resize(rows + 1,cols + 1);
    (*M).setFromTriplets(tripletList.begin(), tripletList.end());
}


