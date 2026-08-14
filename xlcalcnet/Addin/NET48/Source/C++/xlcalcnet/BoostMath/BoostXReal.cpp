
#include <iostream>


// See also: https://www.boost.org/doc/libs/1_80_0/boost/math/tools/user.hpp

#include <boost/math/tools/user.hpp>


#include "BoostXReal.h"


#include "stdint.h"
#include <complex>
#include <vector>
#include <iostream>
#include <limits>
#include "float.h"

#define mp_const_dist_pdf 1
#define mp_const_dist_cdf_P 2
#define mp_const_dist_cdf_Q 3
#define mp_const_dist_Hazard 4
#define mp_const_dist_CHF 5
#define mp_const_dist_Pinv 6
#define mp_const_dist_Qinv 7
#define mp_const_dist_Mean 8
#define mp_const_dist_Median 9
#define mp_const_dist_Mode 10
#define mp_const_dist_Variance 11
#define mp_const_dist_Stdev 12
#define mp_const_dist_Skewness 13
#define mp_const_dist_Kurtosis 14
#define mp_const_dist_KurtosisExcess 15
#define mp_const_dist_support_left 16
#define mp_const_dist_support_right 17
#define mp_const_dist_range_left 18
#define mp_const_dist_range_right 19



#define MP_DIST_RETURN \
    long double result = 0; \
    std::pair<long double, long double> dist_pair; \
    long double xqp1 = *(long double*)xqp; \
    switch (Target){ \
        case mp_const_dist_pdf: { result =  pdf(dist, xqp1); break;} \
        case mp_const_dist_cdf_P: { result =  cdf(dist, xqp1); break;} \
        case mp_const_dist_cdf_Q:  { result =   cdf(complement(dist, xqp1)); break;} \
        case mp_const_dist_Hazard: {result =  hazard(dist, xqp1); break;} \
        case mp_const_dist_CHF: {result =  chf(dist, xqp1); break;} \
        case mp_const_dist_Pinv: {result =  quantile(dist, xqp1); break;} \
        case mp_const_dist_Qinv: {result =  quantile(complement(dist, xqp1)); break;} \
        case mp_const_dist_Mean: {result =  mean(dist); break;} \
        case mp_const_dist_Median: {result =  median(dist); break;} \
        case mp_const_dist_Mode: {result =  mode(dist); break;} \
        case mp_const_dist_Variance: {result =  variance(dist); break;} \
        case mp_const_dist_Stdev: {result =  standard_deviation(dist); break;} \
        case mp_const_dist_Skewness: {result =  skewness(dist); break;} \
        case mp_const_dist_Kurtosis: {result =  kurtosis(dist); break;} \
        case mp_const_dist_KurtosisExcess: {result =  kurtosis_excess(dist); break;} \
        case mp_const_dist_support_left: {dist_pair = support(dist); result =  dist_pair.first; break;} \
        case mp_const_dist_support_right: {dist_pair = support(dist); result =  dist_pair.second; break;} \
        case mp_const_dist_range_left: {dist_pair = range(dist); result =  dist_pair.first; break;} \
        case mp_const_dist_range_right: {dist_pair = range(dist); result =  dist_pair.second; break;} \
        default: {result =  std::numeric_limits<long double>::quiet_NaN(); break;} \
    }; \
    *res = result;

//    std::cout << "Target =  " << Target <<  ";  result =  " << result << std::endl;


#include <boost/math/tools/minima.hpp>
#include <boost/math/tools/roots.hpp>
#include <boost/math/tools/agm.hpp>
#include <tuple> // for std::tuple and std::make_tuple.

#include <boost/math/constants/constants.hpp>
#include <boost/math/special_functions.hpp>
#include <boost/math/special_functions/logaddexp.hpp>

#include <boost/math/distributions.hpp>

#include <boost/math/quadrature/trapezoidal.hpp>
#include <boost/math/quadrature/gauss.hpp>
#include <boost/math/quadrature/gauss_kronrod.hpp>
#include <boost/math/quadrature/tanh_sinh.hpp>
#include <boost/math/quadrature/exp_sinh.hpp>
#include <boost/math/quadrature/sinh_sinh.hpp>
#include <boost/math/quadrature/ooura_fourier_integrals.hpp>

#include <boost/numeric/odeint.hpp>
#include "boost/numeric/odeint/external/eigen/eigen.hpp"
#include <Eigen/Dense>

//#include "include/cppoptlib/meta.h"
//#include "include/cppoptlib/problem.h"
//#include "include/cppoptlib/solver/gradientdescentsolver.h"
//#include "include/cppoptlib/solver/conjugatedgradientdescentsolver.h"
//#include "include/cppoptlib/solver/bfgssolver.h"
//#include "include/cppoptlib/solver/lbfgssolver.h"


using namespace std;
using namespace boost::math;
using namespace boost::math::tools;

using boost::math::quadrature::trapezoidal;
using boost::math::quadrature::gauss;
using boost::math::quadrature::gauss_kronrod;
using boost::math::quadrature::tanh_sinh;
using boost::math::quadrature::sinh_sinh;
using boost::math::quadrature::exp_sinh;
using boost::math::quadrature::ooura_fourier_cos;
using boost::math::quadrature::ooura_fourier_sin;





////*********************** Boost/CppOptLib **********************************
//
//using namespace Eigen;
//using namespace cppoptlib;
//typedef Matrix<long double, Dynamic, 1> state_type_vec;
//typedef state_type_vec* mpVectorPtr;
//
//
//
//class CppOptLibSolver : public Problem<long double>
//{
//    public:
//    EIGEN_MAKE_ALIGNED_OPERATOR_NEW
//    using typename cppoptlib::Problem<long double>::TVector;
//    using typename cppoptlib::Problem<long double>::THessian;
//    CppOptLibSolver(XAnyFuncPtr2 f1, XAnyFuncPtr2 f2)
//     {func1 = f1; func2 = f2;};
//    long double value(const TVector &x) {
//          long double norm = 0.0;
//          std::cout << "norm before = " << norm << std::endl;
//          func1(&x, &norm);
//          std::cout << "norm after  = " << norm << std::endl;
//          return norm;
//    }
//    void gradient(const TVector &x, TVector &grad) {
//          std::cout << "x[0] before = " << x[0] << std::endl;
//          std::cout << "x[1] before = " << x[1] << std::endl;
//          std::cout << "grad[0] before = " << grad[0] << std::endl;
//          std::cout << "grad[1] before = " << grad[1] << std::endl;
//
//        func2(&x, &grad);
//
//          std::cout << "x[0] after = " << x[0] << std::endl;
//          std::cout << "x[1] after = " << x[1] << std::endl;
//          std::cout << "grad[0] after = " << grad[0] << std::endl;
//          std::cout << "grad[1] after = " << grad[1] << std::endl;
//
//    }
//  XAnyFuncPtr2 func1, func2;
//};
//
//
//
//
//void LibXReal_LbfgsSolver(XAnyFuncPtr2 f1, XAnyFuncPtr2 f2, XStatePtr xPtr)
//{
// printf("LbfgsSolver");
//    CppOptLibSolver f(f1, f2);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    LbfgsSolver<CppOptLibSolver> solver;
//    long double eps = std::numeric_limits<long double>::epsilon();
//    Criteria<long double> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)xPtr) = x;
//}

//
//
//
//class CppOptLibSolver : public Problem<long double>
//{
//    public:
//    using typename cppoptlib::Problem<long double>::TVector;
//    using typename cppoptlib::Problem<long double>::THessian;
//    CppOptLibSolver(XRealFuncPtr f1, XRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_)
//     {func1 = f1; func2 = f2;  matX = matX_ ; matGrad = matGrad_;};
//    long double value(const TVector &x) {
//          *matX = x;
//          long double norm = 0.0;
//          func1(matX, &norm);
//          return norm;
//    }
//    void gradient(const TVector &x, TVector &grad) {
//        *matX = x;
//        *matGrad = grad;
//        func2(matX, matGrad);
//        grad = *matGrad;
//    }
//  XRealFuncPtr func1, func2;
//  mpVectorPtr matX, matGrad, matNorm;
//};
//
//
//
//
//void LibXReal_LbfgsSolver(XRealFuncPtr f1, XRealFuncPtr f2, XStatePtr matX_, XStatePtr matGrad_, XStatePtr xPtr)
//{
// printf("LbfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    LbfgsSolver<CppOptLibSolver> solver;
//    long double eps = std::numeric_limits<long double>::epsilon();
//    Criteria<long double> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)matX_) = x;
//    //(*(mpVectorPtr)matNorm_)(0) = f(x);
//}
//
//
//
//
//
//
//
//void LibXReal_BfgsSolver(XRealFuncPtr f1, XRealFuncPtr f2, XStatePtr matX_, XStatePtr matGrad_, XStatePtr xPtr)
//{
// printf("BfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    BfgsSolver<CppOptLibSolver> solver;
//    long double eps = std::numeric_limits<long double>::epsilon();
//    Criteria<long double> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)matX_) = x;
//    //(*(mpVectorPtr)matNorm_)(0) = f(x);
//}
//
//
//
//
//
//
//
//void LibXReal_GradientDescentSolver(XRealFuncPtr f1, XRealFuncPtr f2, XStatePtr matX_, XStatePtr matGrad_, XStatePtr xPtr)
//{
// printf("GradientDescentSolver");
//
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    GradientDescentSolver<CppOptLibSolver> solver;
//    long double eps = std::numeric_limits<long double>::epsilon();
//    Criteria<long double> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)matX_) = x;
//    //(*(mpVectorPtr)matNorm_)(0) = f(x);
//}
//
//
//void LibXReal_ConjugatedGradientDescentSolver(XRealFuncPtr f1, XRealFuncPtr f2, XStatePtr matX_, XStatePtr matGrad_, XStatePtr xPtr)
//{
// printf("ConjugatedGradientDescentSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    ConjugatedGradientDescentSolver<CppOptLibSolver> solver;
//    long double eps = std::numeric_limits<long double>::epsilon();
//    Criteria<long double> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)matX_) = x;
//    //(*(mpVectorPtr)matNorm_)(0) = f(x);
//}
//
//
//
//




//*********************** Boost Odeint **********************************

using namespace Eigen;
using namespace boost::numeric::odeint;
typedef Matrix<long double, Dynamic, 1> state_type_vec;

struct Boost_LibXReal_Write
{
	Boost_LibXReal_Write(XAnyFuncPtr2 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, const long double t)
	{
	    long double fx = t;
		func1(&x, &fx);
	}
	XAnyFuncPtr2 func1;
};

struct Boost_LibXReal_Func_Vec
{
	Boost_LibXReal_Func_Vec(XAnyFuncPtr3 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, state_type_vec &dxdt, long double t) const
	{
	    long double fx = t;
		func1(&x, &dxdt, &fx);
	}
	XAnyFuncPtr3 func1;
};


/* Constant steppers */



void LibXReal_Const_RungeKutta4(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt)
{
	integrate_const(runge_kutta4<state_type_vec, long double>(), Boost_LibXReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibXReal_Write(f2));
}


void LibXReal_Const_RungeKuttaCashKarp54(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt)
{
	integrate_const(runge_kutta_cash_karp54<state_type_vec, long double>(), Boost_LibXReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibXReal_Write(f2));
}




void LibXReal_Const_RungeKuttaDopri5(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt)
{
	integrate_const(runge_kutta_dopri5<state_type_vec, long double>(), Boost_LibXReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibXReal_Write(f2));
}




void LibXReal_Const_RungeKuttaFehlberg78(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt)
{
	integrate_const(runge_kutta_fehlberg78<state_type_vec, long double>(), Boost_LibXReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibXReal_Write(f2));
}


void LibXReal_Const_AdamsBashforthMoulton(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt)
{
	integrate_const(adams_bashforth_moulton<5, state_type_vec, long double>(), Boost_LibXReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibXReal_Write(f2));
}




/* Adaptive steppers */


void LibXReal_Adaptive_RungeKuttaDopri5(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_dopri5<state_type_vec, long double>() ) , Boost_LibXReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibXReal_Write(f2));
}


void LibXReal_Adaptive_RungeKuttaCashKarp54(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_cash_karp54<state_type_vec, long double>() ) , Boost_LibXReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt,  Boost_LibXReal_Write(f2));
}


void LibXReal_Adaptive_RungeKuttaFehlberg78(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_fehlberg78<state_type_vec, long double>() ) , Boost_LibXReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibXReal_Write(f2));
}




void LibXReal_Adaptive_BulirschStoer(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel)
{
	bulirsch_stoer< state_type_vec, long double > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibXReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibXReal_Write(f2));
}

/* Dense Output steppers */


void LibXReal_DenseOutput_Dopri5(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel)
{
    typedef runge_kutta_dopri5< state_type_vec, long double > dopri5_type;
    typedef controlled_runge_kutta< dopri5_type > controlled_dopri5_type;
    typedef dense_output_runge_kutta< controlled_dopri5_type > dense_output_dopri5_type;
    dense_output_dopri5_type dopri5 = make_dense_output( eps_abs , eps_rel , dopri5_type() );
    integrate_adaptive( dopri5, Boost_LibXReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibXReal_Write(f2));
}



void LibXReal_DenseOutput_BulirschStoer(XAnyFuncPtr3 f1, XAnyFuncPtr2 f2, XStatePtr x, long double start_time, long double end_time, long double dt, long double eps_abs, long double eps_rel)
{
	bulirsch_stoer_dense_out< state_type_vec, long double > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibXReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibXReal_Write(f2));
}










//*********************** Extra **********************************


void LibXReal_Pi(long double* res)
{
	*res = boost::math::constants::pi<long double>();
}



void LibXReal_E(long double* res)
{
	*res = boost::math::constants::e<long double>();
}




void LibXReal_ShowExtNet(char* cstr, const long double* d)
{
    std::stringstream ss;
    ss.precision(std::numeric_limits<long double>::digits10+2);
    //ss << std::showpoint; // Append any trailing zeros.
    ss << *d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());

}


//*********************** Numerical Calculus **********************************



struct XRealFunctor1
{
  XRealFunctor1(XRealFuncPtr f1):func1(f1) {}
  long double operator()(long double x)
  {
    long double fx;
	func1( &x, &fx);
    return fx;
  }
private:
	XRealFuncPtr func1;
};



struct XRealFunctor2
{
  XRealFunctor2(XRealFuncPtr f1, XRealFuncPtr f2):func1(f1), func2(f2) {}
  std::pair<long double, long double> operator()(long double x)
  {
    long double fx, dx;
	func1( &x, &fx);
	func2( &x, &dx);
    return std::make_pair(fx, dx);
  }
private:
	XRealFuncPtr func1, func2;
};



struct XRealFunctor3
{
  XRealFunctor3(XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3):func1(f1), func2(f2), func3(f3) {}
  std::tuple<long double, long double, long double> operator()(long double x)
  {
    long double fx, dx, d2x;
	func1( &x, &fx);
	func2( &x, &dx);
	func3( &x, &d2x);
    return std::make_tuple(fx, dx, d2x);
  }
private:
	XRealFuncPtr func1, func2, func3;
};



void LibXReal_BracketRoot(long double* res1, long double* res2, int* iter, XRealFuncPtr f1, long double* guess, long double* factor, bool is_rising, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    eps_tolerance<long double> tol(get_digits);
    std::pair<long double, long double> r = bracket_and_solve_root(XRealFunctor1(f1), *guess, *factor, is_rising, tol, it);
	long double error = (r.second - r.first) / 2;
	long double result = r.first + error;
    (*res1) =  result;
    (*res2) =  error;
    *iter = (int) it;
}



void LibXReal_NewtonRaphson(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    long double result = newton_raphson_iterate(XRealFunctor2(f1, f2), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibXReal_Halley(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    long double result = halley_iterate(XRealFunctor3(f1, f2, f3), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibXReal_Schroder(long double* res,  int* iter, XRealFuncPtr f1, XRealFuncPtr f2, XRealFuncPtr f3, long double* guess, long double* xmin, long double* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    long double result = schroder_iterate(XRealFunctor3(f1, f2, f3), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibXReal_Brent_Minimum(long double* res, long double* resFx, int* iter, XRealFuncPtr f1, long double* bracket_min, long double* bracket_max, int bits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    std::pair<long double, long double> r = brent_find_minima(XRealFunctor1(f1), *bracket_min, *bracket_max, bits, it);
    (*res) =  r.first;
    (*resFx) =  r.second;
    *iter = (int) it;
}




void LibXReal_Trapezoidal(long double* res1, long double* res2, long double* res3, XRealFuncPtr f1, long double* a, long double* b)
{
    auto f = [&f1](long double x) {
        long double fx;
        f1( &x, &fx);
        return fx;
        };
    size_t max_refinements = 24;
    long double tol = sqrt(std::numeric_limits<long double>::epsilon());
    long double  error;
    long double  L1;
    long double result = trapezoidal(f, *a, *b, tol, max_refinements, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}


// 7, 15, 20, 25 and 30

void LibXReal_GaussLegendre(long double* res1, long double* res3, XRealFuncPtr f1, long double* a, long double* b)
{
    auto f = [&f1](long double x) {
        long double fx;
        f1( &x, &fx);
        return fx;
        };
    long double  L1;
    long double result = gauss<long double, 7>::integrate(f, *a, *b, &L1);
    (*res1) =  result;
    (*res3) =  L1/std::abs(result);
}



//15, 31, 41, 51 and 61

void LibXReal_GaussKronrod(long double* res1, long double* res2, long double* res3, XRealFuncPtr f1, long double* a, long double* b)
{
    auto f = [&f1](long double x) {
        long double fx;
        f1( &x, &fx);
        return fx;
        };
    unsigned max_depth = 15;
    long double tol = sqrt(std::numeric_limits<long double>::epsilon());
    long double  error;
    long double  L1;
    long double result = gauss_kronrod<long double, 15>::integrate(f, *a, *b, max_depth, tol, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}



void LibXReal_TanhSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1, long double* a, long double* b)
{
    tanh_sinh<long double> integrator;
    auto f = [&f1](long double x) {
        long double fx;
        f1( &x, &fx);
        return fx;
        };
    long double termination = sqrt(std::numeric_limits<long double>::epsilon());
    long double  error;
    long double  L1;
    std::size_t levels = 0;
    long double result = integrator.integrate(f, *a, *b, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibXReal_SinhSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1)
{
    sinh_sinh<long double> integrator;
    auto f = [&f1](long double x) {
        long double fx;
        f1( &x, &fx);
        return fx;
        };
    long double termination = sqrt(std::numeric_limits<long double>::epsilon());
    long double  error;
    long double  L1;
    std::size_t levels = 0;
    long double result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibXReal_ExpSinh(long double* res1, long double* res2, long double* res3, int* levels_, XRealFuncPtr f1)
{
    exp_sinh<long double> integrator;
    auto f = [&f1](long double x) {
        long double fx;
        f1( &x, &fx);
        return fx;
        };
    long double termination = sqrt(std::numeric_limits<long double>::epsilon());
    long double  error;
    long double  L1;
    std::size_t levels = 0;
    long double result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibXReal_Ooura_Cos(long double* res1, long double* res2, XRealFuncPtr f1)
{
    long double omega = 1;
	const long double tol = 2 * std::numeric_limits<long double>::epsilon();
	auto integrator = ooura_fourier_cos<long double>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](long double x) {
        long double fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<long double, long double> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



void LibXReal_Ooura_Sin(long double* res1, long double* res2, XRealFuncPtr f1)
{
    long double omega = 1;
	const long double tol = 2 * std::numeric_limits<long double>::epsilon();
	auto integrator = ooura_fourier_sin<long double>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](long double x) {
        long double fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<long double, long double> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



//*********************** Distributions **********************************


void LibXReal_ArcsineDist(long Target, long double* res, long double* xqp, long double* a, long double* b)
{
    arcsine_distribution<long double> dist(*a, *b); MP_DIST_RETURN
}


void LibXReal_BernoulliDist(long Target, long double* res, long double* xqp, long double* p)
{
    bernoulli_distribution<long double> dist(*p); MP_DIST_RETURN
}


void LibXReal_BetaDist(long Target, long double* res, long double* xqp, long double* a, long double* b)
{
    beta_distribution<long double> dist(*a, *b); MP_DIST_RETURN
}


void LibXReal_BinomialDist(long Target, long double* res, long double* xqp, long double* n, long double* p)
{
    binomial_distribution<long double> dist(*n, *p); MP_DIST_RETURN
}


void LibXReal_CauchyDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    cauchy_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}


void LibXReal_Chi2Dist(long Target, long double* res, long double* xqp, long double* nu)
{
    chi_squared_distribution<long double> dist(*nu); MP_DIST_RETURN
}

void LibXReal_ExponentialDist(long Target, long double* res, long double* xqp, long double* lambda)
{
    exponential_distribution<long double> dist(*lambda); MP_DIST_RETURN
}


void LibXReal_ExtremeValueDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    extreme_value_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}


void LibXReal_FisherFDist(long Target, long double* res, long double* xqp, long double* mu, long double* nu)
{
    fisher_f_distribution<long double> dist(*mu, *nu); MP_DIST_RETURN
}


void LibXReal_GammaDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale)
{
    gamma_distribution<long double> dist(*shape, *scale); MP_DIST_RETURN
}


void LibXReal_GeometricDist(long Target, long double* res, long double* xqp, long double* p)
{
    geometric_distribution<long double> dist(*p); MP_DIST_RETURN
}


void LibXReal_HypergeometricDist(long Target, long double* res, long double* xqp, uint64_t r, uint64_t n, uint64_t N)
{
    hypergeometric_distribution<long double> dist(r, n, N); MP_DIST_RETURN
}


void LibXReal_InverseChi2Dist(long Target, long double* res, long double* xqp, long double* df, long double* scale)
{
    inverse_chi_squared_distribution<long double> dist(*df, *scale); MP_DIST_RETURN
}



void LibXReal_InverseGammaDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale)
{
    inverse_gamma_distribution<long double> dist(*shape, *scale); MP_DIST_RETURN
}


void LibXReal_InverseGaussianDist(long Target, long double* res, long double* xqp, long double* mean_, long double* scale)
{
    inverse_gaussian_distribution<long double> dist(*mean_, *scale); MP_DIST_RETURN
}


void LibXReal_LaplaceDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    laplace_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}


void LibXReal_LogisticDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    logistic_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}


void LibXReal_LognormalDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    lognormal_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}


void LibXReal_NegBinomialDist(long Target, long double* res, long double* xqp, long double* n, long double* p)
{
    negative_binomial_distribution<long double> dist(*n, *p); MP_DIST_RETURN
}


void LibXReal_Chi2NCDist(long Target, long double* res, long double* xqp, long double* nu, long double* nc)
{
    non_central_chi_squared_distribution<long double> dist(*nu, *nc); MP_DIST_RETURN
}


void LibXReal_StudentTNCDist(long Target, long double* res, long double* xqp, long double* nu, long double* delta)
{
    non_central_t_distribution<long double> dist(*nu, *delta); MP_DIST_RETURN
}


void LibXReal_FisherNCDist(long Target, long double* res, long double* xqp, long double* mu, long double* nu, long double* nc)
{
    non_central_f_distribution<long double> dist(*mu, *nu, *nc); MP_DIST_RETURN
}


void LibXReal_BetaNCDist(long Target, long double* res, long double* xqp, long double* a, long double* b, long double* nc)
{
    non_central_beta_distribution<long double> dist(*a, *b, *nc); MP_DIST_RETURN
}


void LibXReal_NormalDist(long Target, long double* res, long double* xqp, long double* mean_, long double* stdev)
{
    normal_distribution<long double> dist(*mean_, *stdev); MP_DIST_RETURN
}


void LibXReal_ParetoDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale)
{
    pareto_distribution<long double> dist(*shape, *scale); MP_DIST_RETURN
}


void LibXReal_PoissonDist(long Target, long double* res, long double* xqp, long double* nu)
{
    poisson_distribution<long double> dist(*nu); MP_DIST_RETURN
}


void LibXReal_RayleighDist(long Target, long double* res, long double* xqp, long double* nu)
{
    rayleigh_distribution<long double> dist(*nu); MP_DIST_RETURN
}


void LibXReal_SkewNormalDist(long Target, long double* res, long double* xqp, long double* mean_, long double* scale, long double* shape)
{
    skew_normal_distribution<long double> dist(*mean_, *scale, *shape); MP_DIST_RETURN
}


void LibXReal_StudentTDist(long Target, long double* res, long double* xqp, long double* nu)
{
    students_t_distribution<long double> dist(*nu); MP_DIST_RETURN
}


void LibXReal_TriangularDist(long Target, long double* res, long double* xqp, long double* lower, long double* mode_, long double* upper)
{
    triangular_distribution<long double> dist(*lower, *mode_, *upper); MP_DIST_RETURN
}


void LibXReal_WeibullDist(long Target, long double* res, long double* xqp, long double* shape, long double* scale)
{
    weibull_distribution<long double> dist(*shape, *scale); MP_DIST_RETURN
}


void LibXReal_UniformDist(long Target, long double* res, long double* xqp, long double* lower, long double* upper)
{
    uniform_distribution<long double> dist(*lower, *upper); MP_DIST_RETURN
}




//*********************** New , long double precision **********************************



void LibXReal_Logaddexp(long double* res, const long double* a, const long double* b)
{
	*res = logaddexp(*a, *b);
}



void LibXReal_HyperexponentialDist(long Target, long double* res, long double* xqp, XStatePtr l1, XStatePtr l2)
{

    hyperexponential_distribution<long double> dist( *(state_type_vec*) l1, *(state_type_vec*) l2); MP_DIST_RETURN
}


void LibXReal_KolmogorovSmirnovDist(long Target, long double* res, long double* xqp, long double* n)
{
    kolmogorov_smirnov_distribution<long double> dist(*n); MP_DIST_RETURN
}


void LibXReal_HoltsmarkDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    holtsmark_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}


void LibXReal_LandauDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    landau_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}


void LibXReal_MapAiryDist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    mapairy_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}


void LibXReal_Saspoint5Dist(long Target, long double* res, long double* xqp, long double* location, long double* scale)
{
    saspoint5_distribution<long double> dist(*location, *scale); MP_DIST_RETURN
}

















//*********************** Boost Special functions , extended precision **********************************



void LibXReal_Ulp(long double* res, const long double* x)
{
	*res = ulp(*x);
}


void LibXReal_BernoulliB2n(long double* res, const int n)
{
	*res = bernoulli_b2n<long double>(n);
}



void LibXReal_TangentT2n(long double* res, const int n)
{
	*res = tangent_t2n<long double>(n);
}



void LibXReal_Sqrt1pm1(long double* res, const long double* x)
{
	*res = sqrt1pm1(*x);
}






void LibXReal_SinPi(long double* res, const long double* x)
{
	*res = sin_pi(*x);
}

void LibXReal_CosPi(long double* res, const long double* x)
{
	*res = cos_pi(*x);
}

void LibXReal_TanPi(long double* res, const long double* x)
{
	*res = sin_pi(*x) / cos_pi(*x);
}



void LibXReal_CscPi(long double* res, const long double* x)
{
	*res = (1.0) / sin_pi(*x);
}

void LibXReal_SecPi(long double* res, const long double* x)
{
	*res = (1.0) / cos_pi(*x);
}

void LibXReal_CotPi(long double* res, const long double* x)
{
	*res = cos_pi(*x) / sin_pi(*x);
}





void LibXReal_SincPi(long double* res, const long double* x)
{
	*res = sinc_pi(*x);
}



void LibXReal_SinhcPi(long double* res, const long double* x)
{
	*res = sinhc_pi(*x);
}



void LibXReal_Tgamma_(long double* res, const long double* x)
{
	*res = tgamma(*x);
}


void LibXReal_Tgamma1pm1(long double* res, const long double* x)
{
	*res = tgamma1pm1(*x);
}



void LibXReal_Lgamma_(long double* res, const long double* x)
{
	*res = lgamma(*x);
}



void LibXReal_Digamma(long double* res, const long double* x)
{
	*res = digamma(*x);
}



void LibXReal_Trigamma(long double* res, const long double* x)
{
	*res = trigamma(*x);
}



void LibXReal_Factorial(long double* res, const long double* x)
{
    long double xt = *x;
    long double result = tgamma(xt + 1);
	*res = result;
}



void LibXReal_DoubleFactorial(long double* res, const long double* x)
{
    long double xt = *x;
    long double xt2 = xt/2;
    long double t1 = (cos_pi(xt)-1)/4;
    long double pi2 = constants::half_pi<long double>();
    long double t2 = pow(pi2, t1);
    long double result = exp2(xt2) * t2 * tgamma(xt2+1);
	*res = result;
}





void LibXReal_Erf_(long double* res, const long double* x)
{
	*res = erf(*x);
}



void LibXReal_Erfc_(long double* res, const long double* x)
{
	*res = erfc(*x);
}



void LibXReal_Erf_inv(long double* res, const long double* x)
{
	*res = erf_inv(*x);
}



void LibXReal_Erfc_inv(long double* res, const long double* x)
{
	*res = erfc_inv(*x);
}



void LibXReal_AiryAi(long double* res, const long double* x)
{
	*res = airy_ai(*x);
}



void LibXReal_AiryBi(long double* res, const long double* x)
{
	*res = airy_bi(*x);
}



void LibXReal_AiryAiPrime(long double* res, const long double* x)
{
	*res = airy_ai_prime(*x);
}



void LibXReal_AiryBiPrime(long double* res, const long double* x)
{
	*res = airy_bi_prime(*x);
}



void LibXReal_Aizero(long double* res, const int n)
{
	*res = airy_ai_zero<long double>(n);
}



void LibXReal_Bizero(long double* res, const int n)
{
	*res = airy_bi_zero<long double>(n);
}



void LibXReal_Ellint_1_K(long double* res, const long double* x)
{
	*res = ellint_1(*x);
}



void LibXReal_Ellint_2_K(long double* res, const long double* x)
{
	*res = ellint_2(*x);
}



void LibXReal_Zeta(long double* res, const long double* x)
{
	*res = zeta(*x);
}



void LibXReal_Ei(long double* res, const long double* x)
{
	*res = boost::math::expint(*x);
}



void LibXReal_LambertW0(long double* res, const long double* x)
{
	*res = lambert_w0(*x);
}


void LibXReal_LambertWm1(long double* res, const long double* x)
{
	*res = lambert_wm1(*x);
}



void LibXReal_LambertW0Prime(long double* res, const long double* x)
{
	*res = lambert_w0_prime(*x);
}


void LibXReal_LambertWm1Prime(long double* res, const long double* x)
{
	*res = lambert_wm1_prime(*x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void LibXReal_Agm(long double* res, const long double* a, const long double* b)
{
	*res = agm(*a, *b);
}




void LibXReal_Powm1(long double* res, const long double* a, const long double* b)
{
	*res = powm1(*a, *b);
}



void LibXReal_TgammaRatio(long double* res, const long double* a, const long double* b)
{
	*res = tgamma_ratio(*a, *b);
}



void LibXReal_TgammaDeltaRatio(long double* res, const long double* a, const long double* b)
{
	*res = tgamma_delta_ratio(*a, *b);
}



void LibXReal_Binomial(long double* res, const long double* n, const long double* k)
{
    long double nt = *n;
    long double kt = *k;
    long double result = tgamma(nt+1) / ( tgamma(kt+1) * tgamma(nt-kt+1) );
	*res = result;
}

void LibXReal_RisingFactorial(long double* res, const long double* x, const long double* n)
{
    long double xt = *x;
    long double nt = *n;
    long double result = tgamma(xt+nt) / tgamma(xt);
	*res = result;
}




void LibXReal_FallingFactorial(long double* res, const long double* x, const long double* n)
{
    long double xt = *x;
    long double nt = *n;
    long double result = tgamma(xt+1) / tgamma(xt-nt+1);
	*res = result;
}




void LibXReal_BesselJ(long double* res, const long double* v, const long double* x)
{
	*res = boost::math::cyl_bessel_j(*v, *x);
}



void LibXReal_BesselY(long double* res, const long double* v, const long double* x)
{
	*res = boost::math::cyl_neumann(*v, *x);
}



void LibXReal_BesselI(long double* res, const long double* v, const long double* x)
{
	*res = boost::math::cyl_bessel_i(*v, *x);
}



void LibXReal_BesselK(long double* res, const long double* v, const long double* x)
{
	*res = boost::math::cyl_bessel_k(*v, *x);
}



void LibXReal_SphBessel(long double* res, const unsigned v, const long double* x)
{
	*res = boost::math::sph_bessel(v, *x);
}



void LibXReal_SphNeumann(long double* res, const unsigned v, const long double* x)
{
	*res = boost::math::sph_neumann(v, *x);
}





void LibXReal_BesselJPrime(long double* res, const long double* v, const long double* x)
{
	*res = cyl_bessel_j_prime(*v, *x);
}



void LibXReal_BesselYPrime(long double* res, const long double* v, const long double* x)
{
	*res = cyl_neumann_prime(*v, *x);
}



void LibXReal_BesselIPrime(long double* res, const long double* v, const long double* x)
{
	*res = cyl_bessel_i_prime(*v, *x);
}



void LibXReal_BesselKPrime(long double* res, const long double* v, const long double* x)
{
	*res = cyl_bessel_k_prime(*v, *x);
}



void LibXReal_SphBesselPrime(long double* res, const unsigned v, const long double* x)
{
	*res = sph_bessel_prime(v, *x);
}



void LibXReal_SphNeumannPrime(long double* res, const unsigned v, const long double* x)
{
	*res = sph_neumann_prime(v, *x);
}





void LibXReal_BesselJZero(long double* res, const long double* v, const int m)
{
	*res = cyl_bessel_j_zero(*v, m);
}



void LibXReal_BesselYZero(long double* res, const long double* v, const int m)
{
	*res = cyl_neumann_zero(*v, m);
}





void LibXReal_GammaP(long double* res, const long double* a, const long double* x)
{
	*res = gamma_p(*a, *x);
}


void LibXReal_GammaQ(long double* res, const long double* a, const long double* x)
{
	*res = gamma_q(*a, *x);
}


void LibXReal_TgammaLower(long double* res, const long double* a, const long double* x)
{
	*res = tgamma_lower(*a, *x);
}


void LibXReal_TgammaUpper(long double* res, const long double* a, const long double* x)
{
	*res = tgamma(*a, *x);
}




void LibXReal_GammaPInv(long double* res, const long double* a, const long double* p)
{
	*res = gamma_p_inv(*a, *p);
}


void LibXReal_GammaQInv(long double* res, const long double* a, const long double* q)
{
	*res = gamma_q_inv(*a, *q);
}


void LibXReal_GammaPInva(long double* res, const long double* x, const long double* p)
{
	*res = gamma_p_inva(*x, *p);
}


void LibXReal_GammaQInva(long double* res, const long double* x, const long double* q)
{
	*res = gamma_q_inva(*x, *q);
}



void LibXReal_GammaPDerivative(long double* res, const long double* a, const long double* x)
{
	*res = gamma_p_derivative(*a, *x);
}


void LibXReal_Beta(long double* res, const long double* a, const long double* b)
{
	*res = boost::math::beta(*a, *b);
}









void LibXReal_LegendreP(long double* res, int n, const long double* x)
{
	*res = legendre_p(n, *x);
}



void LibXReal_LegendreQ(long double* res, int n, const long double* x)
{
	*res = legendre_q(n, *x);
}



void LibXReal_Laguerre(long double* res, int n, const long double* x)
{
	*res = boost::math::laguerre(n, *x);
}



void LibXReal_Hermite(long double* res, int n, const long double* x)
{
	*res = boost::math::hermite(n, *x);
}



void LibXReal_ChebyshevT(long double* res, int n, const long double* x)
{
	*res = chebyshev_t(n, *x);
}


void LibXReal_ChebyshevU(long double* res, int n, const long double* x)
{
	*res = chebyshev_u(n, *x);
}



void LibXReal_Polygamma(long double* res, int n, const long double* x)
{
	*res = polygamma(n, *x);
}





void LibXReal_EllintRC(long double* res, const long double* x, const long double* y)
{
	*res = ellint_rc(*x, *y);
}


void LibXReal_Ellint1F(long double* res, const long double* k, const long double* phi)
{
	*res = boost::math::ellint_1(*k, *phi);
}


void LibXReal_Ellint2F(long double* res, const long double* k, const long double* phi)
{
	*res = boost::math::ellint_2(*k, *phi);
}


void LibXReal_Ellint3K(long double* res, const long double* k, const long double* n)
{
	*res = ellint_3(*k, *n);
}




void LibXReal_JacobiCD(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_cd(*k, *u);
}


void LibXReal_JacobiCN(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_cn(*k, *u);
}


void LibXReal_JacobiCS(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_cs(*k, *u);
}


void LibXReal_JacobiDC(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_dc(*k, *u);
}


void LibXReal_JacobiDN(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_dn(*k, *u);
}


void LibXReal_JacobiDS(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_ds(*k, *u);
}


void LibXReal_JacobiNC(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_nc(*k, *u);
}


void LibXReal_JacobiND(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_nd(*k, *u);
}


void LibXReal_JacobiNS(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_ns(*k, *u);
}


void LibXReal_JacobiSC(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_sc(*k, *u);
}


void LibXReal_JacobiSD(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_sd(*k, *u);
}


void LibXReal_JacobiSN(long double* res, const long double* k, const long double* u)
{
	*res = jacobi_sn(*k, *u);
}



void LibXReal_expint(long double* res, const unsigned n, const long double* x)
{
	*res = expint(n, *x);
}




void LibXReal_OwenT(long double* res, const long double* h, const long double* a)
{
	*res = owens_t(*h, *a);
}





void LibXReal_IBeta(long double* res, const long double* a, const long double* b, const long double* x)
{
	*res = ibeta(*a, *b, *x);
}


void LibXReal_IBetac(long double* res, const long double* a, const long double* b, const long double* x)
{
	*res = ibetac(*a, *b, *x);
}


void LibXReal_IBetaNonNormalized(long double* res, const long double* a, const long double* b, const long double* x)
{
	*res = beta(*a, *b, *x);
}


void LibXReal_IBetacNonNormalized(long double* res, const long double* a, const long double* b, const long double* x)
{
	*res = betac(*a, *b, *x);
}


void LibXReal_IBetaInv(long double* res, const long double* a, const long double* b, const long double* p)
{
	*res = ibeta_inv(*a, *b, *p);
}


void LibXReal_IBetacInv(long double* res, const long double* a, const long double* b, const long double* q)
{
	*res = ibetac_inv(*a, *b, *q);
}


void LibXReal_IBetaInva(long double* res, const long double* b, const long double* x, const long double* p)
{
	*res = ibeta_inva(*b, *x, *p);
}


void LibXReal_IBetacInva(long double* res, const long double* b, const long double* x, const long double* q)
{
	*res = ibetac_inva(*b, *x, *q);
}


void LibXReal_IBetaInvb(long double* res, const long double* a, const long double* x, const long double* p)
{
	*res = ibeta_invb(*a, *x, *p);
}


void LibXReal_IBetacInvb(long double* res, const long double* a, const long double* x, const long double* q)
{
	*res = ibetac_invb(*a, *x, *q);
}


void LibXReal_IBetaDerivative(long double* res, const long double* a, const long double* b, const long double* x)
{
	*res = ibeta_derivative(*a, *b, *x);
}




void LibXReal_LegendrePM(long double* res, const int n, const int m, const long double* x)
{
	*res = legendre_p(n, m, *x);
}



void LibXReal_LaguerreM(long double* res, const int n, const int m, const long double* x)
{
	*res = laguerre(n, m, *x);
}





void LibXReal_EllipticRF(long double* res, const long double* x, const long double* y, const long double* z)
{
	*res = ellint_rf(*x, *y, *z);
}



void LibXReal_EllipticRD(long double* res, const long double* x, const long double* y, const long double* z)
{
	*res = ellint_rd(*x, *y, *z);
}



void LibXReal_EllipticRG(long double* res, const long double* x, const long double* y, const long double* z)
{
	*res = ellint_rg(*x, *y, *z);
}



void LibXReal_Ellint3F(long double* res, const long double* k, const long double* n, const long double* phi)
{
	*res = boost::math::ellint_3(*k, *n, *phi);
}



void LibXReal_Gegenbauer(long double* res, const int n, const long double* lambda, const long double* x)
{
	*res = boost::math::gegenbauer(n, *lambda, *x);
}



void LibXReal_Jacobi(long double* res, const int n, const long double* alpha, const long double* beta, const long double* x)
{
	*res = boost::math::jacobi(n, *alpha, *beta, *x);
}




void LibXReal_SphericalHarmonicR(long double* res, const int n, const int m, const long double* theta, const long double* phi)
{
	*res = spherical_harmonic_r(n, m, *theta, *phi);
}


void LibXReal_SphericalHarmonicI(long double* res, const int n, const int m, const long double* theta, const long double* phi)
{
	*res = spherical_harmonic_i(n, m, *theta, *phi);
}


void LibXReal_EllipticRJ(long double* res, const long double* x, const long double* y, const long double* z, const long double* p)
{
	*res = ellint_rj(*x, *y, *z, *p);
}


// Hypergeometric and Theta Functions




void LibXReal_Hypergeo0F1(long double* res, const long double* b, const long double* x)
{
	*res = hypergeometric_0F1(*b, *x);
}



void LibXReal_Hypergeo1F1(long double* res, const long double* a, const long double* b, const long double* x)
{
	*res = hypergeometric_1F1(*a, *b, *x);
}



void LibXReal_Hypergeo1F1r(long double* res, const long double* a, const long double* b, const long double* x)
{
	*res = hypergeometric_1F1_regularized(*a, *b, *x);
}



void LibXReal_LogHypergeo1F1(long double* res, const long double* a, const long double* b, const long double* x)
{
	*res = log_hypergeometric_1F1(*a, *b, *x);
}





void LibXReal_JacobiTheta1(long double* res, const long double* x, const long double* q)
{
	*res = jacobi_theta1(*x, *q);
}


void LibXReal_JacobiTheta2(long double* res, const long double* x, const long double* q)
{
	*res = jacobi_theta2(*x, *q);
}


void LibXReal_JacobiTheta3(long double* res, const long double* x, const long double* q)
{
	*res = jacobi_theta3(*x, *q);
}


void LibXReal_JacobiTheta4(long double* res, const long double* x, const long double* q)
{
	*res = jacobi_theta4(*x, *q);
}


