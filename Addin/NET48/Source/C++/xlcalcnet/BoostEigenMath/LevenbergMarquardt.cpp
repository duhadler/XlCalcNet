//#include "stdafx.h"

#include "libBoostEigenCalculus.h"
#include <stdio.h>

#include <unsupported/Eigen/NonLinearOptimization>

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



struct lmder_functor_ext : Functor<mpType>
{
    const int m_inputs, m_values;

    lmder_functor_ext(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matFvec_, mpMatrixPtr matFjac_,
                      int inputs, int values) : m_inputs(inputs), m_values(values)
     {func1 = f1; func2 = f2; matX = matX_ ; matFvec = matFvec_; matFjac = matFjac_;}

    int inputs() const { return m_inputs; }
    int values() const { return m_values; }

    int operator()(const mpVector &x, mpVector &fvec) const
    {
        printf("Calculating fvec\r\n");
        *matX = x;
        *matFvec = fvec;
        func1(matX, matFvec);
        fvec = *matFvec;
        return 0;
    }

    int df(const mpVector &x, mpMatrix &fjac) const
    {
        printf("Calculating fjac\r\n");
        *matX = x;
        *matFjac = fjac;
        func2(matX, matFjac);
        fjac = *matFjac;
        return 0;
    }
  AnyFuncPtr func1, func2;
  mpMatrixPtr matX, matFvec, matFjac;
};



void testLmder_ext(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matFvec_, mpMatrixPtr matFjac_, mpMatrixPtr matInput)
{
  printf(" \n");
  printf("Starting testLmder_ext\r\n");

  const int m=15, n=3;
  int info;
  mpType fnorm, covfac;
  mpVector x;

  /* the following starting values provide a rough fit. */
  x.setConstant(n, 1.);

  // do the computation
  lmder_functor_ext functor(f1, f2, matX_, matFvec_, matFjac_, n, m);
  LevenbergMarquardt<lmder_functor_ext, mpType> lm(functor);
  info = lm.minimize(x);

  printf("%d\n",info);

  // check return values
//  VERIFY_IS_EQUAL(info, 1);
//  VERIFY_IS_EQUAL(lm.nfev, 6);
//  VERIFY_IS_EQUAL(lm.njev, 5);

  // check norm
  fnorm = lm.fvec.blueNorm();

//#if defined(Use_Double)
//  printf("fnorm %.16E\r\n",fnorm);
//#else
//              double d = fnorm.toDouble();
//              printf("x %.16E\r\n",d);
//#endif


//  VERIFY_IS_APPROX(fnorm, 0.09063596);

//  // check x
//  mpVector x_ref(n);
//  x_ref << 0.08241058, 1.133037, 2.343695;
////  VERIFY_IS_APPROX(x, x_ref);
//
//    for (mpVector::Index k = 0; k < n; k++)
//    {
////#if defined(Use_Double)
//              printf("x %.16E\r\n",x[k]);
////#else
////              double d = x[k].toDouble();
////              printf("x %.16E\r\n",d);
////#endif
//    }


  // check covariance
  covfac = fnorm*fnorm/(m-n);
  internal::covar(lm.fjac, lm.permutation.indices()); // TODO : move this as a function of lm

  mpMatrix cov_ref(n,n);
  cov_ref <<
      0.0001531202,   0.002869941,  -0.002656662,
      0.002869941,    0.09480935,   -0.09098995,
      -0.002656662,   -0.09098995,    0.08778727;

//  std::cout << fjac*covfac << std::endl;

  mpMatrix cov;
  cov =  covfac*lm.fjac.topLeftCorner<n,n>();

//    for (int k = 0; k < n; k++)
//    {
//        for (int j = 0; j < n; j++)
//        {
////#if defined(Use_Double)
//            printf("cov %.16E\r\n",cov(k,j));
////#else
////            double d = cov(k,j).toDouble();
////            printf("cov %.16E\r\n",d);
////#endif
//        }
//    }

//  VERIFY_IS_APPROX( cov, cov_ref);
  // TODO: why isn't this allowed ? :
  // VERIFY_IS_APPROX( covfac*fjac.topLeftCorner<n,n>() , cov_ref);
}







