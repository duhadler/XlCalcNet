#include "libBoostEigenCalculus.h"

#include <iostream>
#include "cppoptlib/meta.h"
#include "cppoptlib/problem.h"
#include "cppoptlib/boundedproblem.h"
#include "cppoptlib/solver/bfgssolver.h"
#include "cppoptlib/solver/cmaessolver.h"
#include "cppoptlib/solver/conjugatedgradientdescentsolver.h"
#include "cppoptlib/solver/gradientdescentsolver.h"
#include "cppoptlib/solver/lbfgsbsolver.h"
#include "cppoptlib/solver/lbfgssolver.h"
#include "cppoptlib/solver/neldermeadsolver.h"
#include "cppoptlib/solver/newtondescentsolver.h"


using namespace cppoptlib;


template<typename T>
class BoundedCppOptLibSolver : public BoundedProblem<T>
{
    public:
    using Superclass = BoundedProblem<T>;
    using typename Superclass::TVector;
    using TMatrix = typename Superclass::THessian;

    BoundedCppOptLibSolver(AnyFuncPtr f1, AnyFuncPtr f2, int matXrows, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_) : Superclass(matXrows)
    {func1 = f1; func2 = f2;  matX = matX_ ; matGrad = matGrad_; matNorm = matNorm_; };

    T value(const TVector &x) {
        *matX = x;
        func1(matX, matNorm);
        T norm = (*matNorm)(0,0);
        return norm;
    }

    void gradient(const TVector &x, TVector &grad) {
        *matX = x;
        *matGrad = grad;
        func2(matX, matGrad);
        grad = *matGrad;
    }



//private:
  AnyFuncPtr func1, func2;
  mpMatrixPtr matX, matGrad, matNorm;
};



void EigenLib_mpType_LbfgsbSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{

 printf("before CppOptLibSolverDirect");
    typedef   BoundedCppOptLibSolver<mpType>  TBoundedCppOptLibSolver;

    TBoundedCppOptLibSolver f(f1, f2, (*matX_).rows(), matX_, matGrad_, matNorm_);

 printf("before mpVector x");
    mpVector x = (*xPtr);

 printf("before LbfgsbSolver");
    LbfgsbSolver<TBoundedCppOptLibSolver> solver;
    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0,0) = f(x);
}



template<typename T>
class CppOptLibSolver : public Problem<T>
{
    public:
    using typename cppoptlib::Problem<T>::TVector;
    using typename cppoptlib::Problem<T>::THessian;

    CppOptLibSolver(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_)
     {func1 = f1; func2 = f2;  matX = matX_ ; matGrad = matGrad_; matNorm = matNorm_; };

    T value(const TVector &x) {
          *matX = x;
          func1(matX, matNorm);
          T norm = (*matNorm)(0,0);
          return norm;
    }

    void gradient(const TVector &x, TVector &grad) {
        *matX = x;
        *matGrad = grad;
        func2(matX, matGrad);
        grad = *matGrad;
    }

//    void hessian(const TVector &x, THessian &hessian) {
//        hessian(0, 0) = 1200 * x[0] * x[0] - 400 * x[1] + 1;
//        hessian(0, 1) = -400 * x[0];
//        hessian(1, 0) = -400 * x[0];
//        hessian(1, 1) = 200;
//    }
//private:
  AnyFuncPtr func1, func2;
  mpMatrixPtr matX, matGrad, matNorm;
};



void EigenLib_mpType_BfgsSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{

 printf("before CppOptLibSolverDirect");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);

 printf("before mpVector x");
    mpVector x = (*xPtr);

 printf("before BfgsSolver");
    BfgsSolver<TCppOptLibSolver> solver;
    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0,0) = f(x);
}




void EigenLib_mpType_CMAesSolverSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{

 printf("before CppOptLibSolverDirect");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);

 printf("before mpVector x");
    mpVector x = (*xPtr);

 printf("before CMAesSolver");
    CMAesSolver<TCppOptLibSolver> solver;
    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0,0) = f(x);
}



void EigenLib_mpType_ConjugatedGradientDescentSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{

 printf("before CppOptLibSolverDirect");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);

 printf("before mpVector x");
    mpVector x = (*xPtr);

 printf("before ConjugatedGradientDescentSolver");
    ConjugatedGradientDescentSolver<TCppOptLibSolver> solver;
    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0,0) = f(x);
}



void EigenLib_mpType_GradientDescentSolverSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{

 printf("before CppOptLibSolverDirect");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);

 printf("before mpVector x");
    mpVector x = (*xPtr);

 printf("before GradientDescentSolver");
    GradientDescentSolver<TCppOptLibSolver> solver;
    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0,0) = f(x);
}




void EigenLib_mpType_LbfgsSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{

 printf("before CppOptLibSolverDirect");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);

 printf("before mpVector x");
    mpVector x = (*xPtr);

 printf("before LbfgsSolver");
    LbfgsSolver<TCppOptLibSolver> solver;
    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0,0) = f(x);
}



void EigenLib_mpType_NewtonDescentSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{

 printf("before CppOptLibSolverDirect");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);

 printf("before mpVector x");
    mpVector x = (*xPtr);

 printf("before NewtonDescentSolver");
    NewtonDescentSolver<TCppOptLibSolver> solver;
    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0,0) = f(x);
}



void EigenLib_mpType_NelderMeadSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX_, mpMatrixPtr matGrad_, mpMatrixPtr matNorm_, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{

 printf("before CppOptLibSolverDirect");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);

 printf("before mpVector x");
    mpVector x = (*xPtr);

 printf("before NelderMeadSolver");
    NelderMeadSolver<TCppOptLibSolver> solver;
    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0,0) = f(x);
}







void EigenLib_mpType_CppOptLibDirect(long what, AnyFuncPtr f1, AnyFuncPtr f2, mpMatrixPtr matX, mpMatrixPtr matGrad, mpMatrixPtr matNorm, mpMatrixPtr xPtr, mpMatrixPtr resPtr)
{
	switch (what) {
		case mp_bfgs_solver: EigenLib_mpType_BfgsSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_cma_es_solver: EigenLib_mpType_CMAesSolverSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_conjugated_gradient_descent_solver:EigenLib_mpType_ConjugatedGradientDescentSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_gradient_descent_solver: EigenLib_mpType_GradientDescentSolverSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_lbfgs_b_solver: EigenLib_mpType_LbfgsbSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_lbfgs_solver: EigenLib_mpType_LbfgsSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_newton_descent_solver:EigenLib_mpType_NewtonDescentSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_nelder_mead_solver: EigenLib_mpType_NelderMeadSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
	}
}



//
//
///* we define a new problem for optimizing the rosenbrock function
// we use a templated-class rather than "auto"-lambda function for a clean architecture */
//
//template<typename T>
//class LinearRegression : public cppoptlib::Problem<T> {
//  public:
//    using typename cppoptlib::Problem<T>::TVector;
//    using MatrixType = Eigen::Matrix<T, Eigen::Dynamic, Eigen::Dynamic>;
//
//  protected:
//    const MatrixType X;
//    const TVector y;
//    const MatrixType XX;
//
//  public:
//    LinearRegression(const MatrixType &X_, const TVector &y_) : X(X_), y(y_), XX(X_.transpose()*X_) {}
//
//    T value(const TVector &beta) {
//        return 0.5*(X*beta-y).squaredNorm();
//    }
//
//    void gradient(const TVector &beta, TVector &grad) {
//        grad = XX*beta - X.transpose()*y;
//    }
//};
//
//void demoLinearRegression(void) {
//    typedef LinearRegression<double> TLinearRegression;
//    typedef typename TLinearRegression::TVector TVector;
//    typedef typename TLinearRegression::MatrixType MatrixType;
//
//    // create true model
//    TVector true_beta = TVector::Random(4);
//
//    // create data
//    MatrixType X = MatrixType::Random(50, 4);
//    TVector y = X*true_beta;
//
//    // perform linear regression
//    TLinearRegression f(X, y);
//
//    TVector beta = TVector::Random(4);
//    std::cout << "start in   " << beta.transpose() << std::endl;
//    cppoptlib::BfgsSolver<TLinearRegression> solver;
//    solver.minimize(f, beta);
//
//    std::cout << "result     " << beta.transpose() << std::endl;
//    std::cout << "true model " << true_beta.transpose() << std::endl;
//
//
//}
//


//
//// to use this library just use the namespace "cppoptlib"
//namespace cppoptlib {
//
//// we define a new problem for optimizing the rosenbrock function
//// we use a templated-class rather than "auto"-lambda function for a clean architecture
//template<typename T>
//class LogisticRegression : public Problem<T> {
//  public:
//    using typename Problem<T>::TVector;
//    using MatrixType = Eigen::Matrix<T, Eigen::Dynamic, Eigen::Dynamic>;
//    const MatrixType X;
//    const TVector y;
//    const MatrixType XX;
//
//    LogisticRegression(const MatrixType &X_, const TVector y_) : X(X_), y(y_), XX(X_.transpose()*X_) {}
//
//    T value(const TVector &beta) {
//        return (1.0/(1.0 + exp(-(X*beta).array())) - y.array()).matrix().squaredNorm();
//    }
//
//    void gradient(const TVector &beta, TVector &grad) {
//        const TVector p = 1.0/(1.0 + exp(-(X*beta).array()));
//        grad = X.transpose()*(p-y);
//    }
//};
//
//}

//
//void demoLogisticRegression() {
//    typedef double T;
//    typedef cppoptlib::LogisticRegression<T> LogReg;
//    typedef typename LogReg::TVector TVector;
//    typedef typename LogReg::MatrixType MatrixType;
////    srand((unsigned int) time(0));
//
//    // create true model
//    TVector true_beta = TVector::Random(4);
//
//    // create data
//    MatrixType X = MatrixType::Random(50, 4);
//    TVector y = 1.0/(1.0 + exp(-(X*true_beta).array()));
//
//    // perform logistic regression
//    LogReg f(X, y);
//
//    TVector beta = TVector::Random(4);
//    std::cout << "start in   " << beta.transpose() << std::endl;
//    cppoptlib::BfgsSolver<LogReg> solver;
//    solver.minimize(f, beta);
//
//    std::cout << "result     " << beta.transpose() << std::endl;
//    std::cout << "true model " << true_beta.transpose() << std::endl;
//
//
//}

//
//
//// to use CppNumericalSolvers just use the namespace "cppoptlib"
//namespace cppoptlib {
//
//// we will solve ||Xb-y|| s.t. b>=0
//template<typename T>
//class NonNegativeLeastSquares : public BoundedProblem<T> {
//  public:
//    using Superclass = BoundedProblem<T>;
//    using typename Superclass::TVector;
//    using TMatrix = typename Superclass::THessian;
//
//    const TMatrix X;
//    const TVector y;
//
//  public:
//    NonNegativeLeastSquares(const TMatrix &X_, const TVector y_) :
//        Superclass(X_.rows()),
//        X(X_), y(y_) {}
//
//    T value(const TVector &beta) {
//        return (X*beta-y).dot(X*beta-y);
//    }
//
//    void gradient(const TVector &beta, TVector &grad) {
//        grad = X.transpose()*2*(X*beta-y);
//    }
//};
//
//}



//
//void demoNonNegativeLeastSquares() {
//
//    const size_t DIM = 4;
//    const size_t NUM = 10;
//    typedef double T;
//    typedef cppoptlib::NonNegativeLeastSquares<T> TNNLS;
//    typedef typename TNNLS::TVector TVector;
//    typedef typename TNNLS::TMatrix TMatrix;
//
//    // create model X*b for arbitrary b
//    TMatrix X         = TMatrix::Random(NUM, DIM);
//    TVector true_beta = TVector::Random(DIM);
//    TMatrix y         = X*true_beta;
//
//    // perform non-negative least squares
//    TNNLS f(X, y);
//
//    f.setLowerBound(TVector::Zero(DIM));
//    // create initial guess (make sure it's valid >= 0)
//    TVector beta = TVector::Random(DIM);
//    beta = (beta.array() < 0).select(-beta, beta);
//    std::cout << "true b  = " << true_beta.transpose() << "\tloss:" << f(true_beta) << std::endl;
//    std::cout << "start b = " << beta.transpose() << "\tloss:" << f(beta) << std::endl;
//    // init L-BFGS-B for box-constrained solving
//    cppoptlib::LbfgsbSolver<TNNLS> solver;
//    solver.minimize(f, beta);
//    std::cout << "final b = " << beta.transpose() << "\tloss:" << f(beta) << std::endl;
//
//
//}
//










