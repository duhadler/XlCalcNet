


// Copyright (C) 2009 Thomas Capricelli <orzel@freehackers.org>

#include "libBoostEigenCalculus.h"
#include <stdio.h>


#include <unsupported/Eigen/NonLinearOptimization_Float128>


// This disables some useless Warnings on MSVC.
// It is intended to be done for this test only.
#include <Eigen/src/Core/util/DisableStupidWarnings.h>

using std::sqrt;



// Generic functor
template<typename _Scalar, int NX=Dynamic, int NY=Dynamic>
struct Functor
{
  typedef _Scalar Scalar;
  enum {
    InputsAtCompileTime = NX,
    ValuesAtCompileTime = NY
  };
  typedef Matrix<Scalar,InputsAtCompileTime,1> InputType;
  typedef Matrix<Scalar,ValuesAtCompileTime,1> ValueType;
  typedef Matrix<Scalar,ValuesAtCompileTime,InputsAtCompileTime> JacobianType;
};




struct hybrj_functor_ext : Functor<mpType>
{
    hybrj_functor_ext(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matFvec_, mpMatrixPtr matFjac_)
     {func1 = f1; func2 = f2; matX = matX_ ; matFvec = matFvec_; matFjac = matFjac_;}

    int operator()(const mpVector &x, mpVector &fvec) const
    {
        printf("testHybrj1_ext: Calculating fvec\r\n");
        *matX = x;
        *matFvec = fvec;
        func1(matX, matFvec);
        fvec = *matFvec;
        return 0;
    }

    int df(const mpVector &x, mpMatrix &fjac)
    {
        printf("testHybrj1_ext: Calculating fjac\r\n");
        *matX = x;
        *matFjac = fjac;
        func2(matX, matFjac);
        fjac = *matFjac;
        return 0;
    }

  AnyFuncPtr func1, func2;
  mpMatrixPtr matX, matFvec, matFjac;

};



void testHybrj_ext(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matFvec_, mpMatrixPtr matFjac_, mpMatrixPtr matInput)
{
  printf(" \n");
  printf("Starting testHybrj_ext\r\n");

  const int n=9;
  int info;
  mpVector x(n);

  /* the following starting values provide a rough fit. */
  x.setConstant(n, -1.);


  // do the computation
  hybrj_functor_ext functor(f1, f2, matX_, matFvec_, matFjac_);
  HybridNonLinearSolver<hybrj_functor_ext, mpType> solver(functor);
  solver.diag.setConstant(n, 1.);
  solver.useExternalScaling = true;
  info = solver.solve(x);
  printf("info: %d\n",info);

  // check return value
//  VERIFY_IS_EQUAL(info, 1);
//  VERIFY_IS_EQUAL(solver.nfev, 11);
//  VERIFY_IS_EQUAL(solver.njev, 1);

//  mpType norm = solver.fvec.blueNorm();
//#if defined(Use_Double)
  // printf("nnorm %.16E\r\n",norm);
//#else
//              double d = norm.toDouble();
//              printf("x %.16E\r\n",d);
//#endif

  // check norm
//  VERIFY_IS_APPROX(solver.fvec.blueNorm(), 1.192636e-08);


// check x
  mpVector x_ref(n);
  x_ref <<
     -0.5706545,    -0.6816283,    -0.7017325,
     -0.7042129,     -0.701369,    -0.6918656,
     -0.665792,    -0.5960342,    -0.4164121;
//  VERIFY_IS_APPROX(x, x_ref);
    for (mpVector::Index k = 0; k < n; k++)
        {
//#if defined(Use_Double)
 //             printf("x %.16E\r\n",x[k]);
//#else
//              double d = x[k].toDouble();
//              printf("x %.16E\r\n",d);
//#endif
        }

}



