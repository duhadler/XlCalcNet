

#include "libBoostEigenDense.h"

#include <stdlib.h>
#include <string>
#include <complex>
#include <sstream>
#include <algorithm>
#include <map>
#include <iostream>
#include <vector>
#include <iterator>



using namespace std;

/********************************* maps **************************************************/


mpmapPtr MapLib_mpType_Init_Func(mpMatrixPtr dummy)
{
    mpmapPtr names =  new map<string, void*>;
    return names;
}




void MapLib_mpType_Clear(mpmapPtr names, mpMatrixPtr dummy)
{
    for(auto& x : (*(mpmapPtr)names))
    {
//        cout << x.first << ", " << x.second << endl;
//        Lib_Eigen_Dbl_Clear(x.second);
        EigenLib_mpType_Clear((mpMatrixPtr)(x.second));
    }
    (*(mpmapPtr)names).clear();
    free(names);
}





void MapLib_mpType_GetItemValue(mpMatrixPtr ptr, mpmapPtr names, char *s)
{
    string str = removeSpaces(string(s));
    int32_t exists =  (*(mpmapPtr)names).count(str);
    if (exists != 0)
    {
        *((mpMatrixPtr)ptr) = *((mpMatrixPtr)(*(mpmapPtr)names)[str]);
    }
    else
    {
        cout << str << ": not found" << '\n';
        ptr = EigenLib_mpType_Init_Func(NULL);
    }
}


mpmapPtr MapLib_cplx_mpType_Init_Func(mpCplxMatrixPtr dummy)
{
    mpmapPtr names =  new map<string, void*>;
    return names;
}



void MapLib_cplx_mpType_Clear(mpmapPtr names, mpCplxMatrixPtr dummy)
{
    for(auto& x : (*(mpmapPtr)names))
    {
//        cout << x.first << ", " << x.second << endl;
//        Lib_Eigen_Cplx_Clear(x.second);
        EigenLib_cplx_mpType_Clear((mpCplxMatrixPtr)(x.second));
    }
    (*(mpmapPtr)names).clear();
    free(names);
}



void MapLib_cplx_mpType_GetItemValue(mpCplxMatrixPtr ptr, mpmapPtr names, char *s)
{
    string str = removeSpaces(string(s));
    int32_t exists =  (*(mpmapPtr)names).count(str);
    if (exists != 0)
    {
        *((mpCplxMatrixPtr)ptr) = *((mpCplxMatrixPtr)(*(mpmapPtr)names)[str]);
    }
    else
    {
        cout << str << ": not found" << '\n';
        ptr = EigenLib_cplx_mpType_Init_Func(NULL);
    }
}



/********************************* real procs **************************************************/




void EigenLib_mpType_LLT2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
		LLT<mpMatrix> lltOfA((*A));
		if ((*names).count("info") != 0) {(*((mpMatrixPtr)(*names)["info"]))(0,0) = (int) lltOfA.info();}
		if ((*names).count("rcond") != 0) {(*((mpMatrixPtr)(*names)["rcond"]))(0,0) = lltOfA.rcond();}
		if ((*names).count("l") != 0) {*((mpMatrixPtr)(*names)["l"]) = lltOfA.matrixL();}
		if ((*names).count("u") != 0) {*((mpMatrixPtr)(*names)["u"]) = lltOfA.matrixU();}
		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = lltOfA.solve(*b);}
		if ((*names).count("inverse") != 0) {mpMatrix I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpMatrixPtr)(*names)["inverse"]) = lltOfA.solve(I_n);}
}



void EigenLib_mpType_LDLT2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
		LDLT<mpMatrix> ldltOfA((*A));
		if ((*names).count("l") != 0) {*((mpMatrixPtr)(*names)["l"]) = ldltOfA.matrixL();}
		if ((*names).count("u") != 0) {*((mpMatrixPtr)(*names)["u"]) = ldltOfA.matrixU();}
		if ((*names).count("d") != 0) {*((mpMatrixPtr)(*names)["d"]) = ldltOfA.vectorD().asDiagonal();}
		if ((*names).count("p") != 0) {*((mpMatrixPtr)(*names)["p"]) = PermutationMatrix<Dynamic>(ldltOfA.transpositionsP());}

		if ((*names).count("ispos") != 0) {(*((mpMatrixPtr)(*names)["ispos"]))(0,0) = ldltOfA.isPositive();}
		if ((*names).count("isneg") != 0) {(*((mpMatrixPtr)(*names)["isneg"]))(0,0) = ldltOfA.isNegative();}
		if ((*names).count("info") != 0) {(*((mpMatrixPtr)(*names)["info"]))(0,0) = (int) ldltOfA.info();}
		if ((*names).count("rcond") != 0) {(*((mpMatrixPtr)(*names)["rcond"]))(0,0) = ldltOfA.rcond();}

		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = ldltOfA.solve(*b);}
		if ((*names).count("inverse") != 0) {mpMatrix I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpMatrixPtr)(*names)["inverse"]) = ldltOfA.solve(I_n);}
}



void EigenLib_mpType_PartialPivLU2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
		PartialPivLU<mpMatrix> lu((*A));
		if ((*names).count("rcond") != 0) {(*((mpMatrixPtr)(*names)["rcond"]))(0,0) = lu.rcond();}
		if ((*names).count("lu") != 0) {*((mpMatrixPtr)(*names)["lu"]) = lu.matrixLU();}
		if ((*names).count("p") != 0) {*((mpMatrixPtr)(*names)["p"]) = lu.permutationP();}
		if ((*names).count("det") != 0) {(*((mpMatrixPtr)(*names)["det"]))(0,0) = lu.determinant();}
		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = lu.solve(*b);}
		if ((*names).count("inverse") != 0) {*((mpMatrixPtr)(*names)["inverse"]) = lu.inverse();}
}


void EigenLib_mpType_FullPivLU2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
		FullPivLU<mpMatrix> lu((*A));
		if ((*names).count("rcond") != 0) {(*((mpMatrixPtr)(*names)["rcond"]))(0,0) = lu.rcond();}
		if ((*names).count("lu") != 0) {*((mpMatrixPtr)(*names)["lu"]) = lu.matrixLU();}
		if ((*names).count("p") != 0) {*((mpMatrixPtr)(*names)["p"]) = lu.permutationP();}
		if ((*names).count("q") != 0) {*((mpMatrixPtr)(*names)["q"]) = lu.permutationQ();}
		if ((*names).count("isinjective") != 0) {(*((mpMatrixPtr)(*names)["isinjective"]))(0,0) = lu.isInjective();}
		if ((*names).count("isinvertible") != 0) {(*((mpMatrixPtr)(*names)["isinvertible"]))(0,0) = lu.isInvertible();}
		if ((*names).count("issurjective") != 0) {(*((mpMatrixPtr)(*names)["issurjective"]))(0,0) = lu.isSurjective();}
		if ((*names).count("det") != 0) {(*((mpMatrixPtr)(*names)["det"]))(0,0) = lu.determinant();}
		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = lu.solve(*b);}
		if ((*names).count("inverse") != 0) {*((mpMatrixPtr)(*names)["inverse"]) = lu.inverse();}
}



/* See https://forum.kde.org/viewtopic.php?f=74&t=102456 for sign of determinant with QR*/

void EigenLib_mpType_HouseholderQR2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
		HouseholderQR<mpMatrix> qr((*A));

		if ((*names).count("qr") != 0) {*((mpMatrixPtr)(*names)["qr"]) = qr.matrixQR();}
		if ((*names).count("householderq") != 0) { *((mpMatrixPtr)(*names)["householderq"]) = qr.householderQ(); }
		if ((*names).count("absdet") != 0) {(*((mpMatrixPtr)(*names)["absdet"]))(0,0) = qr.absDeterminant();}
		if ((*names).count("logabsdet") != 0) {(*((mpMatrixPtr)(*names)["logabsdet"]))(0,0) = qr.logAbsDeterminant();}
		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = qr.solve(*b);}
		if ((*names).count("inverse") != 0) {mpMatrix I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpMatrixPtr)(*names)["inverse"]) = qr.solve(I_n);}
}


void EigenLib_mpType_ColPivHouseholderQR2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
		ColPivHouseholderQR<mpMatrix> qr((*A));

		if ((*names).count("info") != 0) {(*((mpMatrixPtr)(*names)["info"]))(0,0) = (int) qr.info();}
		if ((*names).count("dimofkernel") != 0) {(*((mpMatrixPtr)(*names)["dimofkernel"]))(0,0) = (int) qr.dimensionOfKernel();}
		if ((*names).count("rank") != 0) {(*((mpMatrixPtr)(*names)["rank"]))(0,0) = (int) qr.rank();}
		if ((*names).count("nonzeropivots") != 0) {(*((mpMatrixPtr)(*names)["nonzeropivots"]))(0,0) = (int) qr.nonzeroPivots();}

		if ((*names).count("isinjective") != 0) {(*((mpMatrixPtr)(*names)["isinjective"]))(0,0) = qr.isInjective();}
		if ((*names).count("isinvertible") != 0) {(*((mpMatrixPtr)(*names)["isinvertible"]))(0,0) = qr.isInvertible();}
		if ((*names).count("issurjective") != 0) {(*((mpMatrixPtr)(*names)["issurjective"]))(0,0) = qr.isSurjective();}

		if ((*names).count("absdet") != 0) {(*((mpMatrixPtr)(*names)["absdet"]))(0,0) = qr.absDeterminant();}
		if ((*names).count("logabsdet") != 0) {(*((mpMatrixPtr)(*names)["logabsdet"]))(0,0) = qr.logAbsDeterminant();}
		if ((*names).count("maxpivot") != 0) {(*((mpMatrixPtr)(*names)["maxpivot"]))(0,0) = qr.maxPivot();}

		if ((*names).count("qr") != 0) {*((mpMatrixPtr)(*names)["qr"]) = qr.matrixQR();}
		if ((*names).count("r") != 0) {*((mpMatrixPtr)(*names)["r"]) = qr.matrixR();}
		if ((*names).count("householderq") != 0) {*((mpMatrixPtr)(*names)["householderq"]) = qr.householderQ();}
		if ((*names).count("hqnonzeros") != 0) {*((mpMatrixPtr)(*names)["hqnonzeros"]) = qr.householderQ().setLength(qr.nonzeroPivots());}
		if ((*names).count("permcols") != 0) {*((mpMatrixPtr)(*names)["permcols"]) = qr.colsPermutation();}

		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = qr.solve(*b);}
		if ((*names).count("inverse") != 0) {*((mpMatrixPtr)(*names)["inverse"]) = qr.inverse();}
}


void EigenLib_mpType_FullPivHouseholderQR2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
		FullPivHouseholderQR<mpMatrix> qr((*A));

		if ((*names).count("dimofkernel") != 0) {(*((mpMatrixPtr)(*names)["dimofkernel"]))(0,0) = (int) qr.dimensionOfKernel();}
		if ((*names).count("rank") != 0) {(*((mpMatrixPtr)(*names)["rank"]))(0,0) = (int) qr.rank();}
		if ((*names).count("nonzeropivots") != 0) {(*((mpMatrixPtr)(*names)["nonzeropivots"]))(0,0) = (int) qr.nonzeroPivots();}

		if ((*names).count("isinjective") != 0) {(*((mpMatrixPtr)(*names)["isinjective"]))(0,0) = qr.isInjective();}
		if ((*names).count("isinvertible") != 0) {(*((mpMatrixPtr)(*names)["isinvertible"]))(0,0) = qr.isInvertible();}
		if ((*names).count("issurjective") != 0) {(*((mpMatrixPtr)(*names)["issurjective"]))(0,0) = qr.isSurjective();}

		if ((*names).count("absdet") != 0) {(*((mpMatrixPtr)(*names)["absdet"]))(0,0) = qr.absDeterminant();}
		if ((*names).count("logabsdet") != 0) {(*((mpMatrixPtr)(*names)["logabsdet"]))(0,0) = qr.logAbsDeterminant();}
		if ((*names).count("maxpivot") != 0) {(*((mpMatrixPtr)(*names)["maxpivot"]))(0,0) = qr.maxPivot();}

		if ((*names).count("qr") != 0) {*((mpMatrixPtr)(*names)["qr"]) = qr.matrixQR();}
		if ((*names).count("q") != 0) {*((mpMatrixPtr)(*names)["q"]) = qr.matrixQ();}
		if ((*names).count("permcols") != 0) {*((mpMatrixPtr)(*names)["permcols"]) = qr.colsPermutation();}

		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = qr.solve(*b);}
		if ((*names).count("inverse") != 0) {*((mpMatrixPtr)(*names)["inverse"]) = qr.inverse();}
}

void EigenLib_mpType_COD2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
		CompleteOrthogonalDecomposition<mpMatrix> cod((*A));

		if ((*names).count("info") != 0) {(*((mpMatrixPtr)(*names)["info"]))(0,0) = (int) cod.info();}
		if ((*names).count("dimofkernel") != 0) {(*((mpMatrixPtr)(*names)["dimofkernel"]))(0,0) = (int) cod.dimensionOfKernel();}
		if ((*names).count("rank") != 0) {(*((mpMatrixPtr)(*names)["rank"]))(0,0) = (int) cod.rank();}
		if ((*names).count("nonzeropivots") != 0) {(*((mpMatrixPtr)(*names)["nonzeropivots"]))(0,0) = (int) cod.nonzeroPivots();}

		if ((*names).count("isinjective") != 0) {(*((mpMatrixPtr)(*names)["isinjective"]))(0,0) = cod.isInjective();}
		if ((*names).count("isinvertible") != 0) {(*((mpMatrixPtr)(*names)["isinvertible"]))(0,0) = cod.isInvertible();}
		if ((*names).count("issurjective") != 0) {(*((mpMatrixPtr)(*names)["issurjective"]))(0,0) = cod.isSurjective();}

		if ((*names).count("absdet") != 0) {(*((mpMatrixPtr)(*names)["absdet"]))(0,0) = cod.absDeterminant();}
		if ((*names).count("logabsdet") != 0) {(*((mpMatrixPtr)(*names)["logabsdet"]))(0,0) = cod.logAbsDeterminant();}
		if ((*names).count("maxpivot") != 0) {(*((mpMatrixPtr)(*names)["maxpivot"]))(0,0) = cod.maxPivot();}

		if ((*names).count("qtz") != 0) {*((mpMatrixPtr)(*names)["qtz"]) = cod.matrixQTZ();}
		if ((*names).count("t") != 0) {*((mpMatrixPtr)(*names)["t"]) = cod.matrixT();}
		if ((*names).count("z") != 0) {*((mpMatrixPtr)(*names)["z"]) = cod.matrixZ();}
		if ((*names).count("permcols") != 0) { *((mpMatrixPtr)(*names)["permcols"]) = cod.colsPermutation(); }

		if ((*names).count("householderq") != 0) {*((mpMatrixPtr)(*names)["householderq"]) = cod.householderQ();}
		if ((*names).count("hqnonzeros") != 0) {*((mpMatrixPtr)(*names)["hqnonzeros"]) = cod.householderQ().setLength(cod.nonzeroPivots());}

		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = cod.solve(*b);}
		if ((*names).count("pseudoinverse") != 0) {*((mpMatrixPtr)(*names)["pseudoinverse"]) = cod.pseudoInverse();}
}


void EigenLib_mpType_SVD2(mpmapPtr names,  mpMatrixPtr A)
{
        JacobiSVD<mpMatrix, HouseholderQRPreconditioner> svd((*A));
//		mpVector splus = svd.singularValues();
//		mpType absdet = 1;
//		mpType logabsdet = 0;
//		if (((*names).count("splus") != 0) || ((*names).count("absdet") != 0) || ((*names).count("logabsdet") != 0))
//		{
//			for (int i = 0; i < splus.rows(); i++) {
//				mpType s = splus[i];
//				absdet *= s;
//				logabsdet += log(s);
//				if (s != 0) { splus[i] = 1 / s; }
//				else { splus[i] = 0; }
//			}
//		}
		if ((*names).count("rank") != 0) {(*((mpMatrixPtr)(*names)["rank"]))(0,0) = (int) svd.rank();}
		if ((*names).count("nonzeros") != 0) {(*((mpMatrixPtr)(*names)["nonzeros"]))(0,0) = (int) svd.nonzeroSingularValues();}
		if ((*names).count("s") != 0) {*((mpMatrixPtr)(*names)["s"]) = svd.singularValues();}
//		if ((*names).count("splus") != 0) { *((mpMatrixPtr)(*names)["splus"]) = splus;}
//		if((*names).count("absdet") != 0) { (*((mpMatrixPtr)(*names)["absdet"]))(0, 0) = absdet; }
//		if ((*names).count("logabsdet") != 0) { (*((mpMatrixPtr)(*names)["logabsdet"]))(0, 0) = logabsdet; }
}



void EigenLib_mpType_SVD_Thin(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
        JacobiSVD<mpMatrix, ColPivHouseholderQRPreconditioner> svd((*A), ComputeThinU| ComputeThinV);
		if ((*names).count("rank") != 0) {(*((mpMatrixPtr)(*names)["rank"]))(0,0) = (int) svd.rank();}
		if ((*names).count("nonzeros") != 0) {(*((mpMatrixPtr)(*names)["nonzeros"]))(0,0) = (int) svd.nonzeroSingularValues();}
		if ((*names).count("s") != 0) {*((mpMatrixPtr)(*names)["s"]) = svd.singularValues();}
		if ((*names).count("u") != 0) {*((mpMatrixPtr)(*names)["u"]) = svd.matrixU();}
		if ((*names).count("v") != 0) {*((mpMatrixPtr)(*names)["v"]) = svd.matrixV();}
		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = svd.solve(*b);}
		if ((*names).count("pseudoinverse") != 0) {mpMatrix I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpMatrixPtr)(*names)["pseudoinverse"]) = svd.solve(I_n);}
//		{
//			mpVector splus = svd.singularValues();
//			for (int i = 0; i < splus.rows(); i++) {
//				mpType s = splus[i];
//				if (s != 0) { splus[i] = 1 / s; }
//				else { splus[i] = 0; }
//			}
//			*((mpMatrixPtr)(*names)["splus"]) = splus;
//		}
}


void EigenLib_mpType_SVD_Full(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr b)
{
        JacobiSVD<mpMatrix, FullPivHouseholderQRPreconditioner> svd((*A), ComputeFullU| ComputeFullV);
		if ((*names).count("rank") != 0) {(*((mpMatrixPtr)(*names)["rank"]))(0,0) = (int) svd.rank();}
		if ((*names).count("nonzeros") != 0) {(*((mpMatrixPtr)(*names)["nonzeros"]))(0,0) = (int) svd.nonzeroSingularValues();}
		if ((*names).count("s") != 0) {*((mpMatrixPtr)(*names)["s"]) = svd.singularValues();}
		if ((*names).count("u") != 0) {*((mpMatrixPtr)(*names)["u"]) = svd.matrixU();}
		if ((*names).count("v") != 0) {*((mpMatrixPtr)(*names)["v"]) = svd.matrixV();}
		if ((*names).count("x") != 0) {*((mpMatrixPtr)(*names)["x"]) = svd.solve(*b);}
		if ((*names).count("pseudoinverse") != 0) {mpMatrix I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpMatrixPtr)(*names)["pseudoinverse"]) = svd.solve(I_n);}
//		{
//			mpVector splus = svd.singularValues();
//			for (int i = 0; i < splus.rows(); i++) {
//				mpType s = splus[i];
//				if (s != 0) { splus[i] = 1 / s; }
//				else { splus[i] = 0; }
//			}
//			*((mpMatrixPtr)(*names)["splus"]) = splus;
//		}
}



void EigenLib_mpType_Hessenberg2(mpmapPtr names,  mpMatrixPtr A)
{
		HessenbergDecomposition<mpMatrix> hessOfA((*A));
		if ((*names).count("h") != 0) {*((mpMatrixPtr)(*names)["h"]) = hessOfA.matrixH();}
		if ((*names).count("q") != 0) {*((mpMatrixPtr)(*names)["q"]) = hessOfA.matrixQ();}
		if ((*names).count("hcoeff") != 0) {*((mpMatrixPtr)(*names)["hcoeff"]) = hessOfA.householderCoefficients();}
		if ((*names).count("packed") != 0) {*((mpMatrixPtr)(*names)["packed"]) = hessOfA.packedMatrix();}
}


void EigenLib_mpType_RealSchur2(mpmapPtr names,  mpMatrixPtr A)
{
    /* use options to set setIter */
    int setIter = 0;
    int getIter = 0;
//		RealSchur<mpMatrix> schur((*A));
		RealSchur<mpMatrix> schur(1);
		if (setIter != 0) {schur.setMaxIterations(setIter);}
//		schur.compute((*A), (U != NULL));
		schur.compute((*A), true);
        if (getIter != 0) {getIter = (int) schur.getMaxIterations ();}

		if ((*names).count("u") != 0) {*((mpMatrixPtr)(*names)["u"]) = schur.matrixU();}
		if ((*names).count("t") != 0) {*((mpMatrixPtr)(*names)["t"]) = schur.matrixT();}
}




void EigenLib_mpType_RealQZ2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr B)
{
		RealQZ<mpMatrix> qz((*A), (*B), true);
		if ((*names).count("s") != 0) {*((mpMatrixPtr)(*names)["s"]) = qz.matrixS();}
		if ((*names).count("t") != 0) {*((mpMatrixPtr)(*names)["t"]) = qz.matrixT();}
		if ((*names).count("q") != 0) {*((mpMatrixPtr)(*names)["q"]) = qz.matrixQ();}
		if ((*names).count("z") != 0) {*((mpMatrixPtr)(*names)["z"]) = qz.matrixZ();}
}



void EigenLib_mpType_Tridiagonalization2(mpmapPtr names,  mpMatrixPtr A)
{
		Tridiagonalization<mpMatrix> triOfA((*A));
		if ((*names).count("q") != 0) {*((mpMatrixPtr)(*names)["q"]) = triOfA.matrixQ();}
		if ((*names).count("t") != 0) {*((mpMatrixPtr)(*names)["t"]) = triOfA.matrixT();}
		if ((*names).count("packed") != 0) {*((mpMatrixPtr)(*names)["packed"]) = triOfA.packedMatrix();}
		if ((*names).count("hcoeff") != 0) {*((mpMatrixPtr)(*names)["hcoeff"]) = triOfA.householderCoefficients();}
		if ((*names).count("diag") != 0) {*((mpMatrixPtr)(*names)["diag"]) = triOfA.diagonal();}
		if ((*names).count("subdiag") != 0) {*((mpMatrixPtr)(*names)["subdiag"]) = triOfA.subDiagonal();}
}



void EigenLib_mpType_SelfAdjointEigenValuesFromTridiag2(mpmapPtr names, mpMatrixPtr diag, mpMatrixPtr subdiag)
{
        SelfAdjointEigenSolver<mpMatrix> es((*diag).size());
        es.computeFromTridiagonal((*diag), (*subdiag), EigenvaluesOnly);
		if ((*names).count("eval") != 0) {*((mpMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
}


void EigenLib_mpType_SelfAdjointEigenSystemFromTridiag2(mpmapPtr names, mpMatrixPtr diag, mpMatrixPtr subdiag)
{
        SelfAdjointEigenSolver<mpMatrix> es((*diag).size());
        es.computeFromTridiagonal((*diag), (*subdiag));
		if ((*names).count("eval") != 0) {*((mpMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpMatrixPtr)(*names)["evec"]) = es.eigenvectors();}
}

void EigenLib_mpType_SelfAdjointEigenValues2(mpmapPtr names,  mpMatrixPtr A)
{
        SelfAdjointEigenSolver<mpMatrix> es((*A), EigenvaluesOnly);
		if ((*names).count("eval") != 0) {*((mpMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
}


void EigenLib_mpType_SelfAdjointEigenSystem2(mpmapPtr names,  mpMatrixPtr A)
{
        SelfAdjointEigenSolver<mpMatrix> es((*A));
		if ((*names).count("eval") != 0) {*((mpMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpMatrixPtr)(*names)["evec"]) = es.eigenvectors();}
		if ((*names).count("invsqrt") != 0) {*((mpMatrixPtr)(*names)["invsqrt"]) = es.operatorInverseSqrt();}
		if ((*names).count("sqrt") != 0) {*((mpMatrixPtr)(*names)["sqrt"]) = es.operatorSqrt();}
}



void EigenLib_mpType_GeneralizedSelfAdjointEigenValues2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr B)
{
        GeneralizedSelfAdjointEigenSolver<mpMatrix> ges((*A), (*B), EigenvaluesOnly);
		if ((*names).count("eval") != 0) {*((mpMatrixPtr)(*names)["eval"]) = ges.eigenvalues();}
}


void EigenLib_mpType_GeneralizedSelfAdjointEigenSolver2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr B)
{
        GeneralizedSelfAdjointEigenSolver<mpMatrix> ges((*A), (*B));
		if ((*names).count("eval") != 0) {*((mpMatrixPtr)(*names)["eval"]) = ges.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpMatrixPtr)(*names)["evec"]) = ges.eigenvectors();}
}



void EigenLib_mpType_PseudoEigenSystem2(mpmapPtr names,  mpMatrixPtr A)
{
        EigenSolver<mpMatrix> es((*A), true);
		if ((*names).count("info") != 0) {(*((mpMatrixPtr)(*names)["info"]))(0,0) = (int) es.info();}
		if ((*names).count("pseudoeval") != 0) {*((mpMatrixPtr)(*names)["pseudoeval"]) = es.pseudoEigenvalueMatrix();}
		if ((*names).count("pseudoevec") != 0) {*((mpMatrixPtr)(*names)["pseudoevec"]) = es.pseudoEigenvectors();}
}




void EigenLib_mpType_MultipleResults(mpmapPtr names, int32_t what, string str2, mpMatrixPtr A, mpMatrixPtr b)
{
    string str = removeSpaces(str2);
    vector<string> v = split(str, ',');
    string all = getresultstring(what);
    bool allexist = true;
    for(uint32_t i = 0; i < v.size(); i++)
    {
//        cout << v[i] << "; ";
        string teststr = v[i] + string(";");
        size_t found=all.find(teststr);
        if (found==string::npos)
        {
            cout << v[i] << ": not found" << '\n';
            allexist = false;
            break;
        }
    }
    if (allexist)
    {
        for(uint32_t i = 0; i < v.size(); i++)
        {
            (*names)[v[i]] = EigenLib_mpType_Init_Func(NULL);
        }
        switch (what) {
            case mp_llt: EigenLib_mpType_LLT2(names, A, b); break;
            case mp_ldlt: EigenLib_mpType_LDLT2(names, A, b); break;

            case mp_partialPivLu: EigenLib_mpType_PartialPivLU2(names, A, b); break;
            case mp_fullPivLu: EigenLib_mpType_FullPivLU2(names, A, b); break;

            case mp_householderQr: EigenLib_mpType_HouseholderQR2(names, A, b); break;
            case mp_colPivHouseholderQr: EigenLib_mpType_ColPivHouseholderQR2(names, A, b); break;
            case mp_fullPivHouseholderQr: EigenLib_mpType_FullPivHouseholderQR2(names, A, b); break;
            case mp_COD: EigenLib_mpType_COD2(names, A, b); break;

            case mp_jacobiSvd: EigenLib_mpType_SVD2(names, A); break;
            case mp_jacobiSvdThin: EigenLib_mpType_SVD_Thin(names, A, b); break;
            case mp_jacobiSvdFull: EigenLib_mpType_SVD_Full(names, A, b); break;

            case mp_tridiag: EigenLib_mpType_Tridiagonalization2(names, A); break;
            case mp_hessenberg: EigenLib_mpType_Hessenberg2(names, A); break;
            case mp_schur: EigenLib_mpType_RealSchur2(names, A); break;
            case mp_realQZ: EigenLib_mpType_RealQZ2(names, A, b); break;

            case mp_SelfAdjointEigenValuesFromTridiag: EigenLib_mpType_SelfAdjointEigenValuesFromTridiag2(names, A, b); break;
            case mp_SelfAdjointEigenSystemFromTridiag: EigenLib_mpType_SelfAdjointEigenSystemFromTridiag2(names, A, b); break;
            case mp_SelfAdjointEigenValues: EigenLib_mpType_SelfAdjointEigenValues2(names, A); break;
            case mp_SelfAdjointEigenSystem: EigenLib_mpType_SelfAdjointEigenSystem2(names, A); break;

            case mp_GeneralizedSelfAdjointEigenValues: EigenLib_mpType_GeneralizedSelfAdjointEigenValues2(names, A, b); break;
            case mp_GeneralizedSelfAdjointEigenSolver: EigenLib_mpType_GeneralizedSelfAdjointEigenSolver2(names, A, b); break;

            case mp_PseudoEigenSystem: EigenLib_mpType_PseudoEigenSystem2(names, A); break;

            default: break;
        }
    }
    else
    {
        cout << "invalid input \n" << endl;
    }

}




/***************************************************************************************************************************/
/***************************************************************************************************************************/
/***************************************************************************************************************************/
/***************************************************************************************************************************/
/***************************************************************************************************************************/
/***************************************************************************************************************************/
/***************************************************************************************************************************/
/***************************************************************************************************************************/
/***************************************************************************************************************************/






/********************************* complex procs **************************************************/



void EigenLib_cplx_mpType_LLT2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
		LLT<mpMatrixC> lltOfA((*A));
		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) lltOfA.info();}
		if ((*names).count("rcond") != 0) {(*((mpCplxMatrixPtr)(*names)["rcond"]))(0,0) = lltOfA.rcond();}
		if ((*names).count("l") != 0) {*((mpCplxMatrixPtr)(*names)["l"]) = lltOfA.matrixL();}
		if ((*names).count("u") != 0) {*((mpCplxMatrixPtr)(*names)["u"]) = lltOfA.matrixU();}
		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = lltOfA.solve(*b);}
		if ((*names).count("inverse") != 0) {mpMatrixC I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpCplxMatrixPtr)(*names)["inverse"]) = lltOfA.solve(I_n);}
}




void EigenLib_cplx_mpType_LDLT2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
		LDLT<mpMatrixC> ldltOfA((*A));
		if ((*names).count("l") != 0) {*((mpCplxMatrixPtr)(*names)["l"]) = ldltOfA.matrixL();}
		if ((*names).count("u") != 0) {*((mpCplxMatrixPtr)(*names)["u"]) = ldltOfA.matrixU();}
		if ((*names).count("d") != 0) {*((mpCplxMatrixPtr)(*names)["d"]) = ldltOfA.vectorD().asDiagonal();}
		if ((*names).count("p") != 0) {*((mpCplxMatrixPtr)(*names)["p"]) = PermutationMatrix<Dynamic>(ldltOfA.transpositionsP());}

		if ((*names).count("ispos") != 0) {(*((mpCplxMatrixPtr)(*names)["ispos"]))(0,0) = ldltOfA.isPositive();}
		if ((*names).count("isneg") != 0) {(*((mpCplxMatrixPtr)(*names)["isneg"]))(0,0) = ldltOfA.isNegative();}
		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) ldltOfA.info();}
		if ((*names).count("rcond") != 0) {(*((mpCplxMatrixPtr)(*names)["rcond"]))(0,0) = ldltOfA.rcond();}

		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = ldltOfA.solve(*b);}
		if ((*names).count("inverse") != 0) {mpMatrixC I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpCplxMatrixPtr)(*names)["inverse"]) = ldltOfA.solve(I_n);}
}



void EigenLib_cplx_mpType_PartialPivLU2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
		PartialPivLU<mpMatrixC> lu((*A));
		if ((*names).count("rcond") != 0) {(*((mpCplxMatrixPtr)(*names)["rcond"]))(0,0) = lu.rcond();}
		if ((*names).count("lu") != 0) {*((mpCplxMatrixPtr)(*names)["lu"]) = lu.matrixLU();}
		if ((*names).count("p") != 0) {*((mpCplxMatrixPtr)(*names)["p"]) = lu.permutationP();}
		if ((*names).count("det") != 0) {(*((mpCplxMatrixPtr)(*names)["det"]))(0,0) = lu.determinant();}
		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = lu.solve(*b);}
		if ((*names).count("inverse") != 0) {*((mpCplxMatrixPtr)(*names)["inverse"]) = lu.inverse();}
}


void EigenLib_cplx_mpType_FullPivLU2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
		FullPivLU<mpMatrixC> lu((*A));
		if ((*names).count("rcond") != 0) {(*((mpCplxMatrixPtr)(*names)["rcond"]))(0,0) = lu.rcond();}
		if ((*names).count("lu") != 0) {*((mpCplxMatrixPtr)(*names)["lu"]) = lu.matrixLU();}
		if ((*names).count("p") != 0) {*((mpCplxMatrixPtr)(*names)["p"]) = lu.permutationP();}
		if ((*names).count("q") != 0) {*((mpCplxMatrixPtr)(*names)["q"]) = lu.permutationQ();}
		if ((*names).count("isinjective") != 0) {(*((mpCplxMatrixPtr)(*names)["isinjective"]))(0,0) = lu.isInjective();}
		if ((*names).count("isinvertible") != 0) {(*((mpCplxMatrixPtr)(*names)["isinvertible"]))(0,0) = lu.isInvertible();}
		if ((*names).count("issurjective") != 0) {(*((mpCplxMatrixPtr)(*names)["issurjective"]))(0,0) = lu.isSurjective();}
		if ((*names).count("det") != 0) {(*((mpCplxMatrixPtr)(*names)["det"]))(0,0) = lu.determinant();}
		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = lu.solve(*b);}
		if ((*names).count("inverse") != 0) {*((mpCplxMatrixPtr)(*names)["inverse"]) = lu.inverse();}
}



/* See https://forum.kde.org/viewtopic.php?f=74&t=102456 for sign of determinant with QR*/

void EigenLib_cplx_mpType_HouseholderQR2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
		HouseholderQR<mpMatrixC> qr((*A));

		if ((*names).count("qr") != 0) {*((mpCplxMatrixPtr)(*names)["qr"]) = qr.matrixQR();}
		if ((*names).count("householderq") != 0) { *((mpCplxMatrixPtr)(*names)["householderq"]) = qr.householderQ(); }
		if ((*names).count("absdet") != 0) {(*((mpCplxMatrixPtr)(*names)["absdet"]))(0,0) = qr.absDeterminant();}
		if ((*names).count("logabsdet") != 0) {(*((mpCplxMatrixPtr)(*names)["logabsdet"]))(0,0) = qr.logAbsDeterminant();}
		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = qr.solve(*b);}
		if ((*names).count("inverse") != 0) {mpMatrixC I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpCplxMatrixPtr)(*names)["inverse"]) = qr.solve(I_n);}
}


void EigenLib_cplx_mpType_ColPivHouseholderQR2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
		ColPivHouseholderQR<mpMatrixC> qr((*A));

		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) qr.info();}
		if ((*names).count("dimofkernel") != 0) {(*((mpCplxMatrixPtr)(*names)["dimofkernel"]))(0,0) = (int) qr.dimensionOfKernel();}
		if ((*names).count("rank") != 0) {(*((mpCplxMatrixPtr)(*names)["rank"]))(0,0) = (int) qr.rank();}
		if ((*names).count("nonzeropivots") != 0) {(*((mpCplxMatrixPtr)(*names)["nonzeropivots"]))(0,0) = (int) qr.nonzeroPivots();}

		if ((*names).count("isinjective") != 0) {(*((mpCplxMatrixPtr)(*names)["isinjective"]))(0,0) = qr.isInjective();}
		if ((*names).count("isinvertible") != 0) {(*((mpCplxMatrixPtr)(*names)["isinvertible"]))(0,0) = qr.isInvertible();}
		if ((*names).count("issurjective") != 0) {(*((mpCplxMatrixPtr)(*names)["issurjective"]))(0,0) = qr.isSurjective();}

		if ((*names).count("absdet") != 0) {(*((mpCplxMatrixPtr)(*names)["absdet"]))(0,0) = qr.absDeterminant();}
		if ((*names).count("logabsdet") != 0) {(*((mpCplxMatrixPtr)(*names)["logabsdet"]))(0,0) = qr.logAbsDeterminant();}
		if ((*names).count("maxpivot") != 0) {(*((mpCplxMatrixPtr)(*names)["maxpivot"]))(0,0) = qr.maxPivot();}

		if ((*names).count("qr") != 0) {*((mpCplxMatrixPtr)(*names)["qr"]) = qr.matrixQR();}
		if ((*names).count("r") != 0) {*((mpCplxMatrixPtr)(*names)["r"]) = qr.matrixR();}
		if ((*names).count("householderq") != 0) {*((mpCplxMatrixPtr)(*names)["householderq"]) = qr.householderQ();}
		if ((*names).count("hqnonzeros") != 0) {*((mpCplxMatrixPtr)(*names)["hqnonzeros"]) = qr.householderQ().setLength(qr.nonzeroPivots());}
		if ((*names).count("permcols") != 0) {*((mpCplxMatrixPtr)(*names)["permcols"]) = qr.colsPermutation();}

		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = qr.solve(*b);}
		if ((*names).count("inverse") != 0) {*((mpCplxMatrixPtr)(*names)["inverse"]) = qr.inverse();}
}


void EigenLib_cplx_mpType_FullPivHouseholderQR2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
		FullPivHouseholderQR<mpMatrixC> qr((*A));

		if ((*names).count("dimofkernel") != 0) {(*((mpCplxMatrixPtr)(*names)["dimofkernel"]))(0,0) = (int) qr.dimensionOfKernel();}
		if ((*names).count("rank") != 0) {(*((mpCplxMatrixPtr)(*names)["rank"]))(0,0) = (int) qr.rank();}
		if ((*names).count("nonzeropivots") != 0) {(*((mpCplxMatrixPtr)(*names)["nonzeropivots"]))(0,0) = (int) qr.nonzeroPivots();}

		if ((*names).count("isinjective") != 0) {(*((mpCplxMatrixPtr)(*names)["isinjective"]))(0,0) = qr.isInjective();}
		if ((*names).count("isinvertible") != 0) {(*((mpCplxMatrixPtr)(*names)["isinvertible"]))(0,0) = qr.isInvertible();}
		if ((*names).count("issurjective") != 0) {(*((mpCplxMatrixPtr)(*names)["issurjective"]))(0,0) = qr.isSurjective();}

		if ((*names).count("absdet") != 0) {(*((mpCplxMatrixPtr)(*names)["absdet"]))(0,0) = qr.absDeterminant();}
		if ((*names).count("logabsdet") != 0) {(*((mpCplxMatrixPtr)(*names)["logabsdet"]))(0,0) = qr.logAbsDeterminant();}
		if ((*names).count("maxpivot") != 0) {(*((mpCplxMatrixPtr)(*names)["maxpivot"]))(0,0) = qr.maxPivot();}

		if ((*names).count("qr") != 0) {*((mpCplxMatrixPtr)(*names)["qr"]) = qr.matrixQR();}
		if ((*names).count("q") != 0) {*((mpCplxMatrixPtr)(*names)["q"]) = qr.matrixQ();}
		if ((*names).count("permcols") != 0) {*((mpCplxMatrixPtr)(*names)["permcols"]) = qr.colsPermutation();}

		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = qr.solve(*b);}
		if ((*names).count("inverse") != 0) {*((mpCplxMatrixPtr)(*names)["inverse"]) = qr.inverse();}
}

void EigenLib_cplx_mpType_COD2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
		CompleteOrthogonalDecomposition<mpMatrixC> cod((*A));

		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) cod.info();}
		if ((*names).count("dimofkernel") != 0) {(*((mpCplxMatrixPtr)(*names)["dimofkernel"]))(0,0) = (int) cod.dimensionOfKernel();}
		if ((*names).count("rank") != 0) {(*((mpCplxMatrixPtr)(*names)["rank"]))(0,0) = (int) cod.rank();}
		if ((*names).count("nonzeropivots") != 0) {(*((mpCplxMatrixPtr)(*names)["nonzeropivots"]))(0,0) = (int) cod.nonzeroPivots();}

		if ((*names).count("isinjective") != 0) {(*((mpCplxMatrixPtr)(*names)["isinjective"]))(0,0) = cod.isInjective();}
		if ((*names).count("isinvertible") != 0) {(*((mpCplxMatrixPtr)(*names)["isinvertible"]))(0,0) = cod.isInvertible();}
		if ((*names).count("issurjective") != 0) {(*((mpCplxMatrixPtr)(*names)["issurjective"]))(0,0) = cod.isSurjective();}

		if ((*names).count("absdet") != 0) {(*((mpCplxMatrixPtr)(*names)["absdet"]))(0,0) = cod.absDeterminant();}
		if ((*names).count("logabsdet") != 0) {(*((mpCplxMatrixPtr)(*names)["logabsdet"]))(0,0) = cod.logAbsDeterminant();}
		if ((*names).count("maxpivot") != 0) {(*((mpCplxMatrixPtr)(*names)["maxpivot"]))(0,0) = cod.maxPivot();}

		if ((*names).count("qtz") != 0) {*((mpCplxMatrixPtr)(*names)["qtz"]) = cod.matrixQTZ();}
		if ((*names).count("t") != 0) {*((mpCplxMatrixPtr)(*names)["t"]) = cod.matrixT();}
		if ((*names).count("z") != 0) {*((mpCplxMatrixPtr)(*names)["z"]) = cod.matrixZ();}
		if ((*names).count("permcols") != 0) { *((mpCplxMatrixPtr)(*names)["permcols"]) = cod.colsPermutation(); }

		if ((*names).count("householderq") != 0) {*((mpCplxMatrixPtr)(*names)["householderq"]) = cod.householderQ();}
		if ((*names).count("hqnonzeros") != 0) {*((mpCplxMatrixPtr)(*names)["hqnonzeros"]) = cod.householderQ().setLength(cod.nonzeroPivots());}

		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = cod.solve(*b);}
		if ((*names).count("pseudoinverse") != 0) {*((mpCplxMatrixPtr)(*names)["pseudoinverse"]) = cod.pseudoInverse();}
}



void EigenLib_cplx_mpType_SVD2(mpmapPtr names,  mpCplxMatrixPtr A)
{
        JacobiSVD<mpMatrixC, ColPivHouseholderQRPreconditioner> svd((*A));
		if ((*names).count("rank") != 0) {(*((mpCplxMatrixPtr)(*names)["rank"]))(0,0) = (int) svd.rank();}
		if ((*names).count("nonzeros") != 0) {(*((mpCplxMatrixPtr)(*names)["nonzeros"]))(0,0) = (int) svd.nonzeroSingularValues();}
		if ((*names).count("s") != 0) {*((mpCplxMatrixPtr)(*names)["s"]) = svd.singularValues();}
//		if ((*names).count("splus") != 0)
//		{
//			mpVector splus = svd.singularValues();
//			for (int i = 0; i < splus.rows(); i++) {
//				mpType s = splus[i];
//				if (s != 0) { splus[i] = 1 / s; }
//				else { splus[i] = 0; }
//			}
//			*((mpCplxMatrixPtr)(*names)["splus"]) = splus;
//		}
}



void EigenLib_cplx_mpType_SVD_Thin(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
        JacobiSVD<mpMatrixC, ColPivHouseholderQRPreconditioner> svd((*A), ComputeThinU| ComputeThinV);
		if ((*names).count("rank") != 0) {(*((mpCplxMatrixPtr)(*names)["rank"]))(0,0) = (int) svd.rank();}
		if ((*names).count("nonzeros") != 0) {(*((mpCplxMatrixPtr)(*names)["nonzeros"]))(0,0) = (int) svd.nonzeroSingularValues();}
		if ((*names).count("s") != 0) {*((mpCplxMatrixPtr)(*names)["s"]) =  svd.singularValues();}
		if ((*names).count("u") != 0) {*((mpCplxMatrixPtr)(*names)["u"]) = svd.matrixU();}
		if ((*names).count("v") != 0) {*((mpCplxMatrixPtr)(*names)["v"]) = svd.matrixV();}
		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = svd.solve(*b);}
		if ((*names).count("pseudoinverse") != 0) {mpMatrixC I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpCplxMatrixPtr)(*names)["pseudoinverse"]) = svd.solve(I_n);}
//		{
//			mpVector splus = svd.singularValues();
//			for (int i = 0; i < splus.rows(); i++) {
//				mpType s = splus[i];
//				if (s != 0) { splus[i] = 1 / s; }
//				else { splus[i] = 0; }
//			}
//			*((mpCplxMatrixPtr)(*names)["splus"]) = splus;
//		}
}


void EigenLib_cplx_mpType_SVD_Full(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
        JacobiSVD<mpMatrixC, FullPivHouseholderQRPreconditioner> svd((*A), ComputeFullU| ComputeFullV);
		if ((*names).count("rank") != 0) {(*((mpCplxMatrixPtr)(*names)["rank"]))(0,0) = (int) svd.rank();}
		if ((*names).count("nonzeros") != 0) {(*((mpCplxMatrixPtr)(*names)["nonzeros"]))(0,0) = (int) svd.nonzeroSingularValues();}
		if ((*names).count("s") != 0) {*((mpCplxMatrixPtr)(*names)["s"]) = svd.singularValues();}
		if ((*names).count("u") != 0) {*((mpCplxMatrixPtr)(*names)["u"]) = svd.matrixU();}
		if ((*names).count("v") != 0) {*((mpCplxMatrixPtr)(*names)["v"]) = svd.matrixV();}
		if ((*names).count("x") != 0) {*((mpCplxMatrixPtr)(*names)["x"]) = svd.solve(*b);}
		if ((*names).count("pseudoinverse") != 0) {mpMatrixC I_n; I_n.resizeLike(*A); I_n.setIdentity();
                                        *((mpCplxMatrixPtr)(*names)["pseudoinverse"]) = svd.solve(I_n);}
//		{
//			mpVector splus = svd.singularValues();
//			for (int i = 0; i < splus.rows(); i++) {
//				mpType s = splus[i];
//				if (s != 0) { splus[i] = 1 / s; }
//				else { splus[i] = 0; }
//			}
//			*((mpCplxMatrixPtr)(*names)["splus"]) = splus;
//		}
}



void EigenLib_cplx_mpType_Hessenberg2(mpmapPtr names,  mpCplxMatrixPtr A)
{
		HessenbergDecomposition<mpMatrixC> hessOfA((*A));
		if ((*names).count("h") != 0) {*((mpCplxMatrixPtr)(*names)["h"]) = hessOfA.matrixH();}
		if ((*names).count("q") != 0) {*((mpCplxMatrixPtr)(*names)["q"]) = hessOfA.matrixQ();}
		if ((*names).count("hcoeff") != 0) {*((mpCplxMatrixPtr)(*names)["hcoeff"]) = hessOfA.householderCoefficients();}
		if ((*names).count("packed") != 0) {*((mpCplxMatrixPtr)(*names)["packed"]) = hessOfA.packedMatrix();}
}


void EigenLib_cplx_mpType_ComplexSchur2(mpmapPtr names,  mpCplxMatrixPtr A)
{
    /* use options to set setIter */
    int setIter = 0;
    int getIter = 0;
//		RealSchur<mpMatrixC> schur((*A));
		ComplexSchur<mpMatrixC> schur(1);
		if (setIter != 0) {schur.setMaxIterations(setIter);}
//		schur.compute((*A), (U != NULL));
		schur.compute((*A), true);
        if (getIter != 0) {getIter = (int) schur.getMaxIterations ();}

		if ((*names).count("u") != 0) {*((mpCplxMatrixPtr)(*names)["u"]) = schur.matrixU();}
		if ((*names).count("t") != 0) {*((mpCplxMatrixPtr)(*names)["t"]) = schur.matrixT();}
}





void EigenLib_cplx_mpType_Tridiagonalization2(mpmapPtr names,  mpCplxMatrixPtr A)
{
		Tridiagonalization<mpMatrixC> triOfA((*A));
		if ((*names).count("q") != 0) {*((mpCplxMatrixPtr)(*names)["q"]) = triOfA.matrixQ();}
		if ((*names).count("t") != 0) {*((mpCplxMatrixPtr)(*names)["t"]) = triOfA.matrixT();}
		if ((*names).count("packed") != 0) {*((mpCplxMatrixPtr)(*names)["packed"]) = triOfA.packedMatrix();}
		if ((*names).count("hcoeff") != 0) {*((mpCplxMatrixPtr)(*names)["hcoeff"]) = triOfA.householderCoefficients();}
		if ((*names).count("diag") != 0) {*((mpCplxMatrixPtr)(*names)["diag"]) = triOfA.diagonal();}
		if ((*names).count("subdiag") != 0) {*((mpCplxMatrixPtr)(*names)["subdiag"]) = triOfA.subDiagonal();}
}



void EigenLib_cplx_mpType_SelfAdjointEigenValuesFromTridiag2(mpmapPtr names, mpCplxMatrixPtr diag, mpCplxMatrixPtr subdiag)
{
        SelfAdjointEigenSolver<mpMatrixC> es((*diag).size());
        es.computeFromTridiagonal((*diag).real(), (*subdiag).real(), EigenvaluesOnly);
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
}


void EigenLib_cplx_mpType_SelfAdjointEigenSystemFromTridiag2(mpmapPtr names, mpCplxMatrixPtr diag, mpCplxMatrixPtr subdiag)
{
        SelfAdjointEigenSolver<mpMatrixC> es((*diag).size());
        es.computeFromTridiagonal((*diag).real(), (*subdiag).real());
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpCplxMatrixPtr)(*names)["evec"]) = es.eigenvectors();}
}

void EigenLib_cplx_mpType_SelfAdjointEigenValues2(mpmapPtr names,  mpCplxMatrixPtr A)
{
        SelfAdjointEigenSolver<mpMatrixC> es((*A), EigenvaluesOnly);
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
}


void EigenLib_cplx_mpType_SelfAdjointEigenSystem2(mpmapPtr names,  mpCplxMatrixPtr A)
{
        SelfAdjointEigenSolver<mpMatrixC> es((*A));
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpCplxMatrixPtr)(*names)["evec"]) = es.eigenvectors();}
		if ((*names).count("invsqrt") != 0) {*((mpCplxMatrixPtr)(*names)["invsqrt"]) = es.operatorInverseSqrt();}
		if ((*names).count("sqrt") != 0) {*((mpCplxMatrixPtr)(*names)["sqrt"]) = es.operatorSqrt();}
}



void EigenLib_cplx_mpType_GeneralizedSelfAdjointEigenValues2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr B)
{
        GeneralizedSelfAdjointEigenSolver<mpMatrixC> ges((*A), (*B), EigenvaluesOnly);
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = ges.eigenvalues();}
}


void EigenLib_cplx_mpType_GeneralizedSelfAdjointEigenSolver2(mpmapPtr names,  mpCplxMatrixPtr A, mpCplxMatrixPtr B)
{
        GeneralizedSelfAdjointEigenSolver<mpMatrixC> ges((*A), (*B));
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = ges.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpCplxMatrixPtr)(*names)["evec"]) = ges.eigenvectors();}
}



void EigenLib_cplx_mpType_EigenValues2(mpmapPtr names,  mpCplxMatrixPtr A)
{
        ComplexEigenSolver<mpMatrixC> es((*A), false);
		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) es.info();}
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
}



void EigenLib_cplx_mpType_EigenSystem2(mpmapPtr names,  mpCplxMatrixPtr A)
{
        ComplexEigenSolver<mpMatrixC> es((*A), true);
		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) es.info();}
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpCplxMatrixPtr)(*names)["evec"]) = es.eigenvectors();}
}



void EigenLib_cplx_mpType_EigenValuesFromRealInput2(mpmapPtr names,  mpMatrixPtr A)
{
        EigenSolver<mpMatrix> es((*A), false);
		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) es.info();}
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
		if ((*names).count("pseudoeval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.pseudoEigenvalueMatrix();}
}



void EigenLib_cplx_mpType_EigenSystemFromRealInput2(mpmapPtr names,  mpMatrixPtr A)
{
        EigenSolver<mpMatrix> es((*A), true);
		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) es.info();}
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = es.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpCplxMatrixPtr)(*names)["evec"]) = es.eigenvectors();}
}


void EigenLib_cplx_mpType_GeneralizedEigenValuesFromRealInput2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr B)
{
		GeneralizedEigenSolver<mpMatrix> ges((*A), (*B), false);

		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) ges.info();}
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = ges.eigenvalues();}
}


void EigenLib_cplx_mpType_GeneralizedEigenSystemFromRealInput2(mpmapPtr names,  mpMatrixPtr A, mpMatrixPtr B)
{
		GeneralizedEigenSolver<mpMatrix> ges((*A), (*B), true);

		if ((*names).count("info") != 0) {(*((mpCplxMatrixPtr)(*names)["info"]))(0,0) = (int) ges.info();}
		if ((*names).count("eval") != 0) {*((mpCplxMatrixPtr)(*names)["eval"]) = ges.eigenvalues();}
		if ((*names).count("evec") != 0) {*((mpCplxMatrixPtr)(*names)["evec"]) = ges.eigenvectors();}
		if ((*names).count("alphas") != 0) {*((mpCplxMatrixPtr)(*names)["alphas"]) = ges.alphas();}
		if ((*names).count("betas") != 0) {*((mpCplxMatrixPtr)(*names)["betas"]) = ges.betas();}
}




void EigenLib_cplx_mpType_MultipleResults(mpmapPtr names, int32_t what, string str2, mpCplxMatrixPtr A, mpCplxMatrixPtr b)
{
    string str = removeSpaces(str2);
    vector<string> v = split(str, ',');
    string all = getresultstring(what);
    bool allexist = true;
    for(uint32_t i = 0; i < v.size(); i++)
    {
//        cout << v[i] << "; ";
        string teststr = v[i] + string(";");
        size_t found=all.find(teststr);
        if (found==string::npos)
        {
            cout << v[i] << ": not found" << '\n';
            allexist = false;
            break;
        }
    }
    if (allexist)
    {
        for(uint32_t i = 0; i < v.size(); i++)
        {
            (*names)[v[i]] = EigenLib_cplx_mpType_Init_Func(NULL);
        }

        switch (what) {
            case mp_llt: EigenLib_cplx_mpType_LLT2(names, A, b); break;
            case mp_ldlt: EigenLib_cplx_mpType_LDLT2(names, A, b); break;

            case mp_partialPivLu: EigenLib_cplx_mpType_PartialPivLU2(names, A, b); break;
            case mp_fullPivLu: EigenLib_cplx_mpType_FullPivLU2(names, A, b); break;

            case mp_householderQr: EigenLib_cplx_mpType_HouseholderQR2(names, A, b); break;
            case mp_colPivHouseholderQr: EigenLib_cplx_mpType_ColPivHouseholderQR2(names, A, b); break;
            case mp_fullPivHouseholderQr: EigenLib_cplx_mpType_FullPivHouseholderQR2(names, A, b); break;
            case mp_COD: EigenLib_cplx_mpType_COD2(names, A, b); break;

            case mp_jacobiSvd: EigenLib_cplx_mpType_SVD2(names, A); break;
            case mp_jacobiSvdThin: EigenLib_cplx_mpType_SVD_Thin(names, A, b); break;
            case mp_jacobiSvdFull: EigenLib_cplx_mpType_SVD_Full(names, A, b); break;

            case mp_tridiag: EigenLib_cplx_mpType_Tridiagonalization2(names, A); break;
            case mp_hessenberg: EigenLib_cplx_mpType_Hessenberg2(names, A); break;
            case mp_schur: EigenLib_cplx_mpType_ComplexSchur2(names, A); break;

            case mp_SelfAdjointEigenValuesFromTridiag: EigenLib_cplx_mpType_SelfAdjointEigenValuesFromTridiag2(names, A, b); break;
            case mp_SelfAdjointEigenSystemFromTridiag: EigenLib_cplx_mpType_SelfAdjointEigenSystemFromTridiag2(names, A, b); break;
            case mp_SelfAdjointEigenValues: EigenLib_cplx_mpType_SelfAdjointEigenValues2(names, A); break;
            case mp_SelfAdjointEigenSystem: EigenLib_cplx_mpType_SelfAdjointEigenSystem2(names, A); break;

            case mp_GeneralizedSelfAdjointEigenValues: EigenLib_cplx_mpType_GeneralizedSelfAdjointEigenValues2(names, A, b); break;
            case mp_GeneralizedSelfAdjointEigenSolver: EigenLib_cplx_mpType_GeneralizedSelfAdjointEigenSolver2(names, A, b); break;

            case mp_EigenValues: EigenLib_cplx_mpType_EigenValues2(names, A); break;
            case mp_EigenSystem: EigenLib_cplx_mpType_EigenSystem2(names, A); break;

            case mp_EigenValuesFromRealInput: EigenLib_cplx_mpType_EigenValuesFromRealInput2(names, (mpMatrixPtr) A); break;
            case mp_EigenSystemFromRealInput: EigenLib_cplx_mpType_EigenSystemFromRealInput2(names, (mpMatrixPtr) A); break;

            case mp_GeneralizedEigenValuesFromRealInput: EigenLib_cplx_mpType_GeneralizedEigenValuesFromRealInput2(names, (mpMatrixPtr) A, (mpMatrixPtr) b); break;
            case mp_GeneralizedEigenSystemFromRealInput: EigenLib_cplx_mpType_GeneralizedEigenSystemFromRealInput2(names, (mpMatrixPtr) A, (mpMatrixPtr) b); break;

            default: break;
        }
    }
    else
    {
        cout << "invalid input \n" << endl;
    }

}

