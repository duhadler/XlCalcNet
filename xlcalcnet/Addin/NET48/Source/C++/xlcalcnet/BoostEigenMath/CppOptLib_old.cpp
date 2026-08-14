#include "libBoostEigenCalculus.h"

#include <iostream>
#include "include/cppoptlib/meta.h"
#include "include/cppoptlib/problem.h"
#include "include/cppoptlib/boundedproblem.h"
#include "include/cppoptlib/solver/bfgssolver.h"
#include "include/cppoptlib/solver/conjugatedgradientdescentsolver.h"
#include "include/cppoptlib/solver/gradientdescentsolver.h"
#include "include/cppoptlib/solver/lbfgssolver.h"

#include "include/cppoptlib/solver/neldermeadsolver.h"
#include "include/cppoptlib/solver/newtondescentsolver.h"
#include "include/cppoptlib/solver/lbfgsbsolver.h"
#include "include/cppoptlib/solver/cmaessolver.h"

using namespace cppoptlib;




template<typename T>
class CppOptLibSolver : public Problem<T>
{
    public:
    using typename cppoptlib::Problem<T>::TVector;
    using typename cppoptlib::Problem<T>::THessian;

    CppOptLibSolver(AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_)
     {func1 = f1; func2 = f2;  matX = matX_ ; matGrad = matGrad_; matNorm = matNorm_; };

    T value(const TVector &x) {
          *matX = x;
          func1(matX, matNorm);
          T norm = (*matNorm)(0);
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
  mpVectorPtr matX, matGrad, matNorm;
};



void EigenLib_mpType_BfgsSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr, mpVectorPtr resPtr)
{

 printf("BfgsSolver");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
    mpVector x = (*xPtr);
    BfgsSolver<TCppOptLibSolver> solver;

//    std::cout.precision(30);
    mpType eps = std::numeric_limits<mpType>::epsilon();
//    std::cout << "epsilon() = " << eps << std::endl;
//    std::cout << "\n";

    Criteria<mpType> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);

    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0) = f(x);
}



void EigenLib_mpType_ConjugatedGradientDescentSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr, mpVectorPtr resPtr)
{

 printf("ConjugatedGradientDescentSolver");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
    mpVector x = (*xPtr);
    ConjugatedGradientDescentSolver<TCppOptLibSolver> solver;

    mpType eps = std::numeric_limits<mpType>::epsilon();
    Criteria<mpType> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);

    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0) = f(x);
}



void EigenLib_mpType_GradientDescentSolverSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr, mpVectorPtr resPtr)
{

 printf("GradientDescentSolver");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
    mpVector x = (*xPtr);
    GradientDescentSolver<TCppOptLibSolver> solver;

    mpType eps = std::numeric_limits<mpType>::epsilon();
    Criteria<mpType> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);

    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0) = f(x);
}




void EigenLib_mpType_LbfgsSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr, mpVectorPtr resPtr)
{

 printf("LbfgsSolver");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
    mpVector x = (*xPtr);
    LbfgsSolver<TCppOptLibSolver> solver;

    mpType eps = std::numeric_limits<mpType>::epsilon();
    Criteria<mpType> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);

    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0) = f(x);
}


#ifdef Use_Double


void EigenLib_mpType_CMAesSolverSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr, mpVectorPtr resPtr)
{

 printf("CMAesSolver");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
    mpVector x = (*xPtr);
    CMAesSolver<TCppOptLibSolver> solver;

//    mpType eps = std::numeric_limits<mpType>::epsilon();
    Criteria<mpType> m_stop;
    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);

    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0) = f(x);
}




void EigenLib_mpType_NelderMeadSolver3Direct(AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr, mpVectorPtr resPtr)
{

 printf("NelderMeadSolver");
    typedef   CppOptLibSolver<mpType>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
    mpVector x = (*xPtr);
    NelderMeadSolver<TCppOptLibSolver> solver;

//    mpType eps = std::numeric_limits<mpType>::epsilon();
    Criteria<mpType> m_stop;
    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);

    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0) = f(x);
}



#endif // Use_Double




void EigenLib_mpType_CppOptLibDirect(long what, AnyFuncPtr f1, AnyFuncPtr f2, mpVectorPtr matX, mpVectorPtr matGrad, mpVectorPtr matNorm, mpVectorPtr xPtr, mpVectorPtr resPtr)
{
    std::cout << "start in EigenLib_mpType_CppOptLibDirect:  " << what << std::endl;
	switch (what) {
		case mp_gradient_descent_solver: EigenLib_mpType_GradientDescentSolverSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_conjugated_gradient_descent_solver:EigenLib_mpType_ConjugatedGradientDescentSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_bfgs_solver: EigenLib_mpType_BfgsSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_lbfgs_solver: EigenLib_mpType_LbfgsSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;

#ifdef Use_Double
		case mp_cma_es_solver: EigenLib_mpType_CMAesSolverSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
		case mp_nelder_mead_solver: EigenLib_mpType_NelderMeadSolver3Direct(f1, f2, matX, matGrad, matNorm, xPtr,resPtr ); break;
#endif // Use_Double
	}
}




#ifdef Use_Double



/* we define a new problem for optimizing the rosenbrock function
 we use a templated-class rather than "auto"-lambda function for a clean architecture */

template<typename T>
class LinearRegression : public cppoptlib::Problem<T> {
  public:
    using typename cppoptlib::Problem<T>::TVector;
    using MatrixType = Eigen::Matrix<T, Eigen::Dynamic, Eigen::Dynamic>;

  protected:
    const MatrixType X;
    const TVector y;
    const MatrixType XX;

  public:
    LinearRegression(const MatrixType &X_, const TVector &y_) : X(X_), y(y_), XX(X_.transpose()*X_) {}

    T value(const TVector &beta) {
        return 0.5*(X*beta-y).squaredNorm();
    }

    void gradient(const TVector &beta, TVector &grad) {
        grad = XX*beta - X.transpose()*y;
    }
};

void demoLinearRegression(void) {
    typedef LinearRegression<double> TLinearRegression;
    typedef typename TLinearRegression::TVector TVector;
    typedef typename TLinearRegression::MatrixType MatrixType;

    // create true model
    TVector true_beta = TVector::Random(4);

    // create data
    MatrixType X = MatrixType::Random(50, 4);
    TVector y = X*true_beta;

    // perform linear regression
    TLinearRegression f(X, y);

    TVector beta = TVector::Random(4);
    std::cout << "start in   " << beta.transpose() << std::endl;
    cppoptlib::BfgsSolver<TLinearRegression> solver;
    solver.minimize(f, beta);

    std::cout << "result     " << beta.transpose() << std::endl;
    std::cout << "true model " << true_beta.transpose() << std::endl;


}




// to use this library just use the namespace "cppoptlib"
namespace cppoptlib {

// we define a new problem for optimizing the rosenbrock function
// we use a templated-class rather than "auto"-lambda function for a clean architecture
template<typename T>
class LogisticRegression : public Problem<T> {
  public:
    using typename Problem<T>::TVector;
    using MatrixType = Eigen::Matrix<T, Eigen::Dynamic, Eigen::Dynamic>;
    const MatrixType X;
    const TVector y;
    const MatrixType XX;

    LogisticRegression(const MatrixType &X_, const TVector y_) : X(X_), y(y_), XX(X_.transpose()*X_) {}

    T value(const TVector &beta) {
        return (1.0/(1.0 + exp(-(X*beta).array())) - y.array()).matrix().squaredNorm();
    }

    void gradient(const TVector &beta, TVector &grad) {
        const TVector p = 1.0/(1.0 + exp(-(X*beta).array()));
        grad = X.transpose()*(p-y);
    }
};

}


void demoLogisticRegression() {
    typedef double T;
    typedef cppoptlib::LogisticRegression<T> LogReg;
    typedef typename LogReg::TVector TVector;
    typedef typename LogReg::MatrixType MatrixType;
//    srand((unsigned int) time(0));

    // create true model
    TVector true_beta = TVector::Random(4);

    // create data
    MatrixType X = MatrixType::Random(50, 4);
    TVector y = 1.0/(1.0 + exp(-(X*true_beta).array()));

    // perform logistic regression
    LogReg f(X, y);

    TVector beta = TVector::Random(4);
    std::cout << "start in   " << beta.transpose() << std::endl;
    cppoptlib::BfgsSolver<LogReg> solver;
    solver.minimize(f, beta);

    std::cout << "result     " << beta.transpose() << std::endl;
    std::cout << "true model " << true_beta.transpose() << std::endl;


}


#endif // Use_Double







