

#include "libBoostEigenDense.h"
#include <iostream>


#include <NonlinearOptimization/NonlinearOptimization>


//using std::sqrt;
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
//  mpType fnorm, covfac;
  mpVector x;
  /* the following starting values provide a rough fit. */
  x.setConstant(n, 1.);
  // do the computation
  lmder_functor_ext functor(f1, f2, matX_, matFvec_, matFjac_, n, m);
  LevenbergMarquardt<lmder_functor_ext, mpType> lm(functor);
  info = lm.minimize(x);
  printf("%d\n",info);
}



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
}


/* ************************************************************************************************** */


//#include <unsupported/Eigen/Polynomials>

#include <Polynomials/Polynomials>


void EigenLib_mpType_Roots_To_MonicPolynomial(mpMatrixPtr polynomial_result, mpMatrixPtr roots_source)
{
    mpVector roots = (*roots_source);
    mpVector polynomial;
    roots_to_monicPolynomial(roots, polynomial);
    (*polynomial_result) = polynomial;
}


void EigenLib_mpType_Poly_Eval(mpMatrixPtr evaluation_result, mpMatrixPtr polynomial_source, mpMatrixPtr roots_source)
{
    mpVector roots = (*roots_source);
    mpVector polynomial = (*polynomial_source);
    int n = (roots_source)->rows();
    mpVector evaluation;
    evaluation.resize(n);
    for( int i=0; i<n; ++i ) {evaluation[i] = poly_eval(polynomial, roots[i]);}
    (*evaluation_result) = evaluation;
}


void EigenLib_mpType_Poly_Eval_Complex(mpCplxMatrixPtr evaluation_result, mpMatrixPtr polynomial_source, mpCplxMatrixPtr roots_source)
{
    mpVectorC roots = (*roots_source);
    mpVector polynomial = (*polynomial_source);
    int n = (roots_source)->rows();
    mpVectorC evaluation;
    evaluation.resize(n);
    for( int i=0; i<n; ++i ) {evaluation[i] = poly_eval(polynomial, roots[i]);}
    (*evaluation_result) = evaluation;
}


void EigenLib_mpType_PolynomialSolver(mpCplxMatrixPtr cplxroots_result, mpMatrixPtr polynomial_source)
{
    mpVector polynomial = (*polynomial_source);
    PolynomialSolver<mpType,Dynamic> psolve( polynomial );
    mpVectorC cplxroots;
    cplxroots = psolve.roots();
    (*cplxroots_result) = cplxroots;
}



void EigenLib_cplx_mpType_Poly_Eval_Complex(mpCplxMatrixPtr evaluation_result, mpCplxMatrixPtr polynomial_source, mpCplxMatrixPtr roots_source)
{
    mpVectorC roots = (*roots_source);
    mpVectorC polynomial = (*polynomial_source);
    int n = (roots_source)->rows();
    mpVectorC evaluation;
    evaluation.resize(n);
    for( int i=0; i<n; ++i ) {evaluation[i] = poly_eval(polynomial, roots[i]);}
    (*evaluation_result) = evaluation;
}




void EigenLib_cplx_mpType_Roots_To_MonicPolynomial(mpCplxMatrixPtr polynomial_result, mpCplxMatrixPtr roots_source)
{
    mpVectorC roots = (*roots_source);
    mpVectorC polynomial;
    roots_to_monicPolynomial(roots, polynomial);
    (*polynomial_result) = polynomial;
}




void EigenLib_cplx_mpType_PolynomialSolver(mpCplxMatrixPtr cplxroots_result, mpCplxMatrixPtr polynomial_source)
{
    mpVectorC polynomial = (*polynomial_source);
    PolynomialSolver<complex<mpType>,Dynamic> psolve( polynomial );
    mpVectorC cplxroots;
    cplxroots = psolve.roots();
    (*cplxroots_result) = cplxroots;
}





//#include <unsupported/Eigen/FFT>

#include <FFT/FFT>


void EigenLib_cplx_mpType_FFT_fwd(mpCplxMatrixPtr fft_result, mpCplxMatrixPtr fft_source)
{
    FFT<mpType> fft;
    mpVectorC source = (*fft_source);
    mpVectorC result;
    fft.fwd(result, source);
    (*fft_result) = result;
}


void EigenLib_cplx_mpType_FFT_inv(mpCplxMatrixPtr fft_result,  mpCplxMatrixPtr fft_source)
{
    FFT<mpType> fft;
    mpVectorC source = (*fft_source);
    mpVectorC result;
    fft.inv(result, source);
    (*fft_result) = result;
}



void EigenLib_mpType_FFT_real_fwd(mpCplxMatrixPtr fft_result, mpMatrixPtr fft_source)
{
    FFT<mpType> fft;
    mpVector source = (*fft_source);
    mpVectorC result;
    fft.fwd(result, source);
    (*fft_result) = result;
}


void EigenLib_mpType_FFT_real_inv(mpMatrixPtr fft_result,  mpCplxMatrixPtr fft_source)
{
    FFT<mpType> fft;
    mpVectorC source = (*fft_source);
    mpVector result;
    fft.inv(result, source);
    (*fft_result) = result;
}



//
//
//
//
//#ifndef Use_BinOct
//
//
//
////#include <unsupported/Eigen/MatrixFunctions>
//
//#include <MatrixFunctions/MatrixFunctions>
//
//
//void EigenLib_mpType_MatrixFunction(mpMatrix *result, long what, mpMatrix *A){
//
//    switch (what) {
//    case mp_matrix_exp: *result =  (*A).exp(); break;
//    case mp_matrix_sin: *result =  (*A).sin(); break;
//    case mp_matrix_cos: *result = (*A).cos(); break;
//    case mp_matrix_sinh: *result = (*A).sinh(); break;
//    case mp_matrix_cosh: *result = (*A).cosh(); break;
//    case mp_matrix_sqrt: *result = (*A).sqrt(); break;
//    case mp_matrix_log: *result = (*A).log(); break;
//    }
//}
//
//
//
//void EigenLib_cplx_mpType_MatrixFunction(mpMatrixC *result, long what, mpMatrixC *A){
//
//    switch (what) {
//    case mp_matrix_exp: *result =  (*A).exp(); break;
//    case mp_matrix_sin: *result =  (*A).sin(); break;
//    case mp_matrix_cos: *result = (*A).cos(); break;
//    case mp_matrix_sinh: *result = (*A).sinh(); break;
//    case mp_matrix_cosh: *result = (*A).cosh(); break;
//    case mp_matrix_sqrt: *result = (*A).sqrt(); break;
//    case mp_matrix_log: *result = (*A).log(); break;
//    }
//}
//
//
//#endif // Use_BinOct
//
//


