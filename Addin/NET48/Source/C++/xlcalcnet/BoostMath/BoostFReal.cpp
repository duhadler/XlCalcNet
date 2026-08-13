


// See also: https://www.boost.org/doc/libs/1_80_0/boost/math/tools/user.hpp

// Commented out: C:\msys64\home\Boost\boost\math\policies\policy.hpp, lines 747 - 748

#include <boost/math/tools/user.hpp>


#include "BoostFReal.h"


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
    double result = 0; \
    std::pair<double, double> dist_pair; \
    double xqp1 = *(double*)xqp; \
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
        default: {result =  std::numeric_limits<double>::quiet_NaN(); break;} \
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


//
//
//////*********************** Boost/CppOptLib **********************************
////
//using namespace Eigen;
//using namespace cppoptlib;
//typedef Matrix<double, Dynamic, 1> state_type_vec;
//typedef state_type_vec* mpVectorPtr;
//
//
//
//class CppOptLibSolver : public Problem<double>
//{
//    public:
//    using typename cppoptlib::Problem<double>::TVector;
//    using typename cppoptlib::Problem<double>::THessian;
//    CppOptLibSolver(FRealFuncPtr f1, FRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_)
//     {func1 = f1; func2 = f2;  matX = matX_ ; matGrad = matGrad_;};
//    double value(const TVector &x) {
//          *matX = x;
//          double norm = 0.0;
//          func1(matX, &norm);
//          return norm;
//    }
//    void gradient(const TVector &x, TVector &grad) {
//        *matX = x;
//        *matGrad = grad;
//        func2(matX, matGrad);
//        grad = *matGrad;
//    }
//  FRealFuncPtr func1, func2;
//  mpVectorPtr matX, matGrad, matNorm;
//};
//
//
//
//
//void LibFReal_LbfgsSolver(FRealFuncPtr f1, FRealFuncPtr f2, FStatePtr matX_, FStatePtr matGrad_, FStatePtr xPtr)
//{
// printf("LbfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    LbfgsSolver<CppOptLibSolver> solver;
//    double eps = std::numeric_limits<double>::epsilon();
//    Criteria<double> m_stop;
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
//void LibFReal_BfgsSolver(FRealFuncPtr f1, FRealFuncPtr f2, FStatePtr matX_, FStatePtr matGrad_, FStatePtr xPtr)
//{
// printf("BfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    BfgsSolver<CppOptLibSolver> solver;
//    double eps = std::numeric_limits<double>::epsilon();
//    Criteria<double> m_stop;
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
//void LibFReal_GradientDescentSolver(FRealFuncPtr f1, FRealFuncPtr f2, FStatePtr matX_, FStatePtr matGrad_, FStatePtr xPtr)
//{
// printf("GradientDescentSolver");
//
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    GradientDescentSolver<CppOptLibSolver> solver;
//    double eps = std::numeric_limits<double>::epsilon();
//    Criteria<double> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)matX_) = x;
//    //(*(mpVectorPtr)matNorm_)(0) = f(x);
//}
//
//
//void LibFReal_ConjugatedGradientDescentSolver(FRealFuncPtr f1, FRealFuncPtr f2, FStatePtr matX_, FStatePtr matGrad_, FStatePtr xPtr)
//{
// printf("ConjugatedGradientDescentSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    ConjugatedGradientDescentSolver<CppOptLibSolver> solver;
//    double eps = std::numeric_limits<double>::epsilon();
//    Criteria<double> m_stop;
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




//*********************** Boost Odeint **********************************

using namespace Eigen;
using namespace boost::numeric::odeint;
typedef Matrix<double, Dynamic, 1> state_type_vec;

struct Boost_LibFReal_Write
{
	Boost_LibFReal_Write(FAnyFuncPtr2 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, const double t)
	{
	    double fx = t;
		func1(&x, &fx);
	}
	FAnyFuncPtr2 func1;
};

struct Boost_LibFReal_Func_Vec
{
	Boost_LibFReal_Func_Vec(FAnyFuncPtr3 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, state_type_vec &dxdt, double t) const
	{
	    double fx = t;
		func1(&x, &dxdt, &fx);
	}
	FAnyFuncPtr3 func1;
};


/* Constant steppers */



void LibFReal_Const_RungeKutta4(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt)
{
	integrate_const(runge_kutta4<state_type_vec, double>(), Boost_LibFReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibFReal_Write(f2));
}


void LibFReal_Const_RungeKuttaCashKarp54(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt)
{
	integrate_const(runge_kutta_cash_karp54<state_type_vec, double>(), Boost_LibFReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibFReal_Write(f2));
}




void LibFReal_Const_RungeKuttaDopri5(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt)
{
	integrate_const(runge_kutta_dopri5<state_type_vec, double>(), Boost_LibFReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibFReal_Write(f2));
}




void LibFReal_Const_RungeKuttaFehlberg78(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt)
{
	integrate_const(runge_kutta_fehlberg78<state_type_vec, double>(), Boost_LibFReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibFReal_Write(f2));
}


void LibFReal_Const_AdamsBashforthMoulton(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt)
{
	integrate_const(adams_bashforth_moulton<5, state_type_vec, double>(), Boost_LibFReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibFReal_Write(f2));
}




/* Adaptive steppers */


void LibFReal_Adaptive_RungeKuttaDopri5(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_dopri5<state_type_vec, double>() ) , Boost_LibFReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibFReal_Write(f2));
}


void LibFReal_Adaptive_RungeKuttaCashKarp54(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_cash_karp54<state_type_vec, double>() ) , Boost_LibFReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt,  Boost_LibFReal_Write(f2));
}


void LibFReal_Adaptive_RungeKuttaFehlberg78(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_fehlberg78<state_type_vec, double>() ) , Boost_LibFReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibFReal_Write(f2));
}




void LibFReal_Adaptive_BulirschStoer(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel)
{
	bulirsch_stoer< state_type_vec, double > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibFReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibFReal_Write(f2));
}

/* Dense Output steppers */


void LibFReal_DenseOutput_Dopri5(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel)
{
    typedef runge_kutta_dopri5< state_type_vec, double > dopri5_type;
    typedef controlled_runge_kutta< dopri5_type > controlled_dopri5_type;
    typedef dense_output_runge_kutta< controlled_dopri5_type > dense_output_dopri5_type;
    dense_output_dopri5_type dopri5 = make_dense_output( eps_abs , eps_rel , dopri5_type() );
    integrate_adaptive( dopri5, Boost_LibFReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibFReal_Write(f2));
}



void LibFReal_DenseOutput_BulirschStoer(FAnyFuncPtr3 f1, FAnyFuncPtr2 f2, FStatePtr x, double start_time, double end_time, double dt, double eps_abs, double eps_rel)
{
	bulirsch_stoer_dense_out< state_type_vec, double > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibFReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibFReal_Write(f2));
}









//*********************** Numerical Calculus **********************************



struct FRealFunctor1
{
  FRealFunctor1(FRealFuncPtr f1):func1(f1) {}
  double operator()(double x)
  {
    double fx;
	func1( &x, &fx);
    return fx;
  }
private:
	FRealFuncPtr func1;
};

//
//
//struct FCplxFunctor1
//{
//  FCplxFunctor1(FRealFuncPtr f1):func1(f1) {}
//  double operator()(double x)
//  {
//    double fx_re;
//    double fx_im;
//	func1( &x, &fx_re, fx_im);
//    return fx;
//  }
//private:
//	FCplxFuncPtr func1;
//};
//
//



struct FRealFunctor2
{
  FRealFunctor2(FRealFuncPtr f1, FRealFuncPtr f2):func1(f1), func2(f2) {}
  std::pair<double, double> operator()(double x)
  {
    double fx, dx;
	func1( &x, &fx);
	func2( &x, &dx);
    return std::make_pair(fx, dx);
  }
private:
	FRealFuncPtr func1, func2;
};



struct FRealFunctor3
{
  FRealFunctor3(FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3):func1(f1), func2(f2), func3(f3) {}
  std::tuple<double, double, double> operator()(double x)
  {
    double fx, dx, d2x;
	func1( &x, &fx);
	func2( &x, &dx);
	func3( &x, &d2x);
    return std::make_tuple(fx, dx, d2x);
  }
private:
	FRealFuncPtr func1, func2, func3;
};



void LibFReal_BracketRoot(double* res1, double* res2, int* iter, FRealFuncPtr f1, double* guess, double* factor, bool is_rising, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    eps_tolerance<double> tol(get_digits);
    std::pair<double, double> r = bracket_and_solve_root(FRealFunctor1(f1), *guess, *factor, is_rising, tol, it);
	double error = (r.second - r.first) / 2;
	double result = r.first + error;
    (*res1) =  result;
    (*res2) =  error;
    *iter = (int) it;
}



void LibFReal_NewtonRaphson(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    double result = newton_raphson_iterate(FRealFunctor2(f1, f2), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibFReal_Halley(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    double result = halley_iterate(FRealFunctor3(f1, f2, f3), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibFReal_Schroder(double* res,  int* iter, FRealFuncPtr f1, FRealFuncPtr f2, FRealFuncPtr f3, double* guess, double* xmin, double* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    double result = schroder_iterate(FRealFunctor3(f1, f2, f3), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibFReal_Brent_Minimum(double* res, double* resFx, int* iter, FRealFuncPtr f1, double* bracket_min, double* bracket_max, int bits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    std::pair<double, double> r = brent_find_minima(FRealFunctor1(f1), *bracket_min, *bracket_max, bits, it);
    (*res) =  r.first;
    (*resFx) =  r.second;
    *iter = (int) it;
}




void LibFReal_Trapezoidal(double* res1, double* res2, double* res3, FRealFuncPtr f1, double* a, double* b)
{
    auto f = [&f1](double x) {
        double fx;
        f1( &x, &fx);
        return fx;
        };
    size_t max_refinements = 24;
    double tol = sqrt(std::numeric_limits<double>::epsilon());
    double  error;
    double  L1;
    double result = trapezoidal(f, *a, *b, tol, max_refinements, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}


// 7, 15, 20, 25 and 30

void LibFReal_GaussLegendre(double* res1, double* res3, FRealFuncPtr f1, double* a, double* b)
{
    auto f = [&f1](double x) {
        double fx;
        f1( &x, &fx);
        return fx;
        };
    double  L1;
    double result = gauss<double, 7>::integrate(f, *a, *b, &L1);
    (*res1) =  result;
    (*res3) =  L1/std::abs(result);
}



//15, 31, 41, 51 and 61

void LibFReal_GaussKronrod(double* res1, double* res2, double* res3, FRealFuncPtr f1, double* a, double* b)
{
    auto f = [&f1](double x) {
        double fx;
        f1( &x, &fx);
        return fx;
        };
    unsigned max_depth = 15;
    double tol = sqrt(std::numeric_limits<double>::epsilon());
    double  error;
    double  L1;
    double result = gauss_kronrod<double, 15>::integrate(f, *a, *b, max_depth, tol, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}



void LibFReal_TanhSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1, double* a, double* b)
{
    tanh_sinh<double> integrator;
    auto f = [&f1](double x) {
        double fx;
        f1( &x, &fx);
        return fx;
        };
    double termination = sqrt(std::numeric_limits<double>::epsilon());
    double  error;
    double  L1;
    std::size_t levels = 0;
    double result = integrator.integrate(f, *a, *b, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibFReal_SinhSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1)
{
    sinh_sinh<double> integrator;
    auto f = [&f1](double x) {
        double fx;
        f1( &x, &fx);
        return fx;
        };
    double termination = sqrt(std::numeric_limits<double>::epsilon());
    double  error;
    double  L1;
    std::size_t levels = 0;
    double result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibFReal_ExpSinh(double* res1, double* res2, double* res3, int* levels_, FRealFuncPtr f1)
{
    exp_sinh<double> integrator;
    auto f = [&f1](double x) {
        double fx;
        f1( &x, &fx);
        return fx;
        };
    double termination = sqrt(std::numeric_limits<double>::epsilon());
    double  error;
    double  L1;
    std::size_t levels = 0;
    double result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibFReal_Ooura_Cos(double* res1, double* res2, FRealFuncPtr f1)
{
    double omega = 1;
	const double tol = 2 * std::numeric_limits<double>::epsilon();
	auto integrator = ooura_fourier_cos<double>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](double x) {
        double fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<double, double> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



void LibFReal_Ooura_Sin(double* res1, double* res2, FRealFuncPtr f1)
{
    double omega = 1;
	const double tol = 2 * std::numeric_limits<double>::epsilon();
	auto integrator = ooura_fourier_sin<double>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](double x) {
        double fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<double, double> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



//*********************** Distributions **********************************


void LibFReal_ArcsineDist(long Target, double* res, double* xqp, double* a, double* b)
{
    arcsine_distribution<double> dist(*a, *b); MP_DIST_RETURN
}


void LibFReal_BernoulliDist(long Target, double* res, double* xqp, double* p)
{
    bernoulli_distribution<double> dist(*p); MP_DIST_RETURN
}


void LibFReal_BetaDist(long Target, double* res, double* xqp, double* a, double* b)
{
    beta_distribution<double> dist(*a, *b); MP_DIST_RETURN
}


void LibFReal_BinomialDist(long Target, double* res, double* xqp, double* n, double* p)
{
    binomial_distribution<double> dist(*n, *p); MP_DIST_RETURN
}


void LibFReal_CauchyDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    cauchy_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}


void LibFReal_Chi2Dist(long Target, double* res, double* xqp, double* nu)
{
    chi_squared_distribution<double> dist(*nu); MP_DIST_RETURN
}

void LibFReal_ExponentialDist(long Target, double* res, double* xqp, double* lambda)
{
    exponential_distribution<double> dist(*lambda); MP_DIST_RETURN
}


void LibFReal_ExtremeValueDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    extreme_value_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}


void LibFReal_FisherFDist(long Target, double* res, double* xqp, double* mu, double* nu)
{
    fisher_f_distribution<double> dist(*mu, *nu); MP_DIST_RETURN
}


void LibFReal_GammaDist(long Target, double* res, double* xqp, double* shape, double* scale)
{
    gamma_distribution<double> dist(*shape, *scale); MP_DIST_RETURN
}


void LibFReal_GeometricDist(long Target, double* res, double* xqp, double* p)
{
    geometric_distribution<double> dist(*p); MP_DIST_RETURN
}


void LibFReal_HypergeometricDist(long Target, double* res, double* xqp, uint64_t r, uint64_t n, uint64_t N)
{
    hypergeometric_distribution<double> dist(r, n, N); MP_DIST_RETURN
}


void LibFReal_InverseChi2Dist(long Target, double* res, double* xqp, double* df, double* scale)
{
    inverse_chi_squared_distribution<double> dist(*df, *scale); MP_DIST_RETURN
}



void LibFReal_InverseGammaDist(long Target, double* res, double* xqp, double* shape, double* scale)
{
    inverse_gamma_distribution<double> dist(*shape, *scale); MP_DIST_RETURN
}


void LibFReal_InverseGaussianDist(long Target, double* res, double* xqp, double* mean_, double* scale)
{
    inverse_gaussian_distribution<double> dist(*mean_, *scale); MP_DIST_RETURN
}


void LibFReal_LaplaceDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    laplace_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}


void LibFReal_LogisticDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    logistic_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}


void LibFReal_LognormalDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    lognormal_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}


void LibFReal_NegBinomialDist(long Target, double* res, double* xqp, double* n, double* p)
{
    negative_binomial_distribution<double> dist(*n, *p); MP_DIST_RETURN
}


void LibFReal_Chi2NCDist(long Target, double* res, double* xqp, double* nu, double* nc)
{
    non_central_chi_squared_distribution<double> dist(*nu, *nc); MP_DIST_RETURN
}


void LibFReal_StudentTNCDist(long Target, double* res, double* xqp, double* nu, double* delta)
{
    non_central_t_distribution<double> dist(*nu, *delta); MP_DIST_RETURN
}


void LibFReal_FisherNCDist(long Target, double* res, double* xqp, double* mu, double* nu, double* nc)
{
    non_central_f_distribution<double> dist(*mu, *nu, *nc); MP_DIST_RETURN
}


void LibFReal_BetaNCDist(long Target, double* res, double* xqp, double* a, double* b, double* nc)
{
    non_central_beta_distribution<double> dist(*a, *b, *nc); MP_DIST_RETURN
}


void LibFReal_NormalDist(long Target, double* res, double* xqp, double* mean_, double* stdev)
{
    normal_distribution<double> dist(*mean_, *stdev); MP_DIST_RETURN
}


void LibFReal_ParetoDist(long Target, double* res, double* xqp, double* shape, double* scale)
{
    pareto_distribution<double> dist(*shape, *scale); MP_DIST_RETURN
}


void LibFReal_PoissonDist(long Target, double* res, double* xqp, double* nu)
{
    poisson_distribution<double> dist(*nu); MP_DIST_RETURN
}


void LibFReal_RayleighDist(long Target, double* res, double* xqp, double* nu)
{
    rayleigh_distribution<double> dist(*nu); MP_DIST_RETURN
}


void LibFReal_SkewNormalDist(long Target, double* res, double* xqp, double* mean_, double* scale, double* shape)
{
    skew_normal_distribution<double> dist(*mean_, *scale, *shape); MP_DIST_RETURN
}


void LibFReal_StudentTDist(long Target, double* res, double* xqp, double* nu)
{
    students_t_distribution<double> dist(*nu); MP_DIST_RETURN
}


void LibFReal_TriangularDist(long Target, double* res, double* xqp, double* lower, double* mode_, double* upper)
{
    triangular_distribution<double> dist(*lower, *mode_, *upper); MP_DIST_RETURN
}


void LibFReal_WeibullDist(long Target, double* res, double* xqp, double* shape, double* scale)
{
    weibull_distribution<double> dist(*shape, *scale); MP_DIST_RETURN
}


void LibFReal_UniformDist(long Target, double* res, double* xqp, double* lower, double* upper)
{
    uniform_distribution<double> dist(*lower, *upper); MP_DIST_RETURN
}




//*********************** New , double precision **********************************



void LibFReal_Logaddexp(double* res, const double* a, const double* b)
{
	*res = logaddexp(*a, *b);
}



void LibFReal_HyperexponentialDist(long Target, double* res, double* xqp, FStatePtr l1, FStatePtr l2)
{

    hyperexponential_distribution<double> dist( *(state_type_vec*) l1, *(state_type_vec*) l2); MP_DIST_RETURN
}


void LibFReal_KolmogorovSmirnovDist(long Target, double* res, double* xqp, double* n)
{
    kolmogorov_smirnov_distribution<double> dist(*n); MP_DIST_RETURN
}


void LibFReal_HoltsmarkDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    holtsmark_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}


void LibFReal_LandauDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    landau_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}


void LibFReal_MapAiryDist(long Target, double* res, double* xqp, double* location, double* scale)
{
    mapairy_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}


void LibFReal_Saspoint5Dist(long Target, double* res, double* xqp, double* location, double* scale)
{
    saspoint5_distribution<double> dist(*location, *scale); MP_DIST_RETURN
}










//*********************** Boost Special functions , double precision **********************************



void LibFReal_Ulp(double* res, const double* x)
{
	*res = ulp(*x);
}



void LibFReal_BernoulliB2n(double* res, const int n)
{
	*res = bernoulli_b2n<double>(n);
}



void LibFReal_TangentT2n(double* res, const int n)
{
	*res = tangent_t2n<double>(n);
}



void LibFReal_Sqrt1pm1(double* res, const double* x)
{
	*res = sqrt1pm1(*x);
}



void LibFReal_SinPi(double* res, const double* x)
{
	*res = sin_pi(*x);
}

void LibFReal_CosPi(double* res, const double* x)
{
	*res = cos_pi(*x);
}

void LibFReal_TanPi(double* res, const double* x)
{
	*res = sin_pi(*x) / cos_pi(*x);
}



void LibFReal_CscPi(double* res, const double* x)
{
	*res = (1.0) / sin_pi(*x);
}

void LibFReal_SecPi(double* res, const double* x)
{
	*res = (1.0) / cos_pi(*x);
}

void LibFReal_CotPi(double* res, const double* x)
{
	*res = cos_pi(*x) / sin_pi(*x);
}



void LibFReal_SincPi(double* res, const double* x)
{
	*res = sinc_pi(*x);
}



void LibFReal_SinhcPi(double* res, const double* x)
{
	*res = sinhc_pi(*x);
}



void LibFReal_Tgamma_(double* res, const double* x)
{
	*res = tgamma(*x);
}


void LibFReal_Tgamma1pm1(double* res, const double* x)
{
	*res = tgamma1pm1(*x);
}



void LibFReal_Lgamma_(double* res, const double* x)
{
	*res = lgamma(*x);
}



void LibFReal_Digamma(double* res, const double* x)
{
	*res = digamma(*x);
}



void LibFReal_Trigamma(double* res, const double* x)
{
	*res = trigamma(*x);
}



void LibFReal_Factorial(double* res, const double* x)
{
    double xt = *x;
    double result = tgamma(xt + 1);
	*res = result;
}



void LibFReal_DoubleFactorial(double* res, const double* x)
{
    double xt = *x;
    double xt2 = xt/2;
    double t1 = (cos_pi(xt)-1)/4;
    double pi2 = constants::half_pi<double>();
    double t2 = pow(pi2, t1);
    double result = exp2(xt2) * t2 * tgamma(xt2+1);
	*res = result;
}





void LibFReal_Erf_(double* res, const double* x)
{
	*res = erf(*x);
}



void LibFReal_Erfc_(double* res, const double* x)
{
	*res = erfc(*x);
}



void LibFReal_Erf_inv(double* res, const double* x)
{
	*res = erf_inv(*x);
}



void LibFReal_Erfc_inv(double* res, const double* x)
{
	*res = erfc_inv(*x);
}



void LibFReal_AiryAi(double* res, const double* x)
{
	*res = airy_ai(*x);
}



void LibFReal_AiryBi(double* res, const double* x)
{
	*res = airy_bi(*x);
}



void LibFReal_AiryAiPrime(double* res, const double* x)
{
	*res = airy_ai_prime(*x);
}



void LibFReal_AiryBiPrime(double* res, const double* x)
{
	*res = airy_bi_prime(*x);
}



void LibFReal_Aizero(double* res, const int n)
{
	*res = airy_ai_zero<double>(n);
}



void LibFReal_Bizero(double* res, const int n)
{
	*res = airy_bi_zero<double>(n);
}



void LibFReal_Ellint_1_K(double* res, const double* x)
{
	*res = ellint_1(*x);
}



void LibFReal_Ellint_2_K(double* res, const double* x)
{
	*res = ellint_2(*x);
}



void LibFReal_Zeta(double* res, const double* x)
{
	*res = zeta(*x);
}



void LibFReal_Ei(double* res, const double* x)
{
	*res = boost::math::expint(*x);
}



void LibFReal_LambertW0(double* res, const double* x)
{
	*res = lambert_w0(*x);
}


void LibFReal_LambertWm1(double* res, const double* x)
{
	*res = lambert_wm1(*x);
}



void LibFReal_LambertW0Prime(double* res, const double* x)
{
	*res = lambert_w0_prime(*x);
}


void LibFReal_LambertWm1Prime(double* res, const double* x)
{
	*res = lambert_wm1_prime(*x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



void LibFReal_Agm(double* res, const double* a, const double* b)
{
	*res = agm(*a, *b);
}






void LibFReal_Powm1(double* res, const double* a, const double* b)
{
	*res = powm1(*a, *b);
}



void LibFReal_TgammaRatio(double* res, const double* a, const double* b)
{
	*res = tgamma_ratio(*a, *b);
}



void LibFReal_TgammaDeltaRatio(double* res, const double* a, const double* b)
{
	*res = tgamma_delta_ratio(*a, *b);
}



void LibFReal_Binomial(double* res, const double* n, const double* k)
{
    double nt = *n;
    double kt = *k;
    double result = tgamma(nt+1) / ( tgamma(kt+1) * tgamma(nt-kt+1) );
	*res = result;
}

void LibFReal_RisingFactorial(double* res, const double* x, const double* n)
{
    double xt = *x;
    double nt = *n;
    double result = tgamma(xt+nt) / tgamma(xt);
	*res = result;
}




void LibFReal_FallingFactorial(double* res, const double* x, const double* n)
{
    double xt = *x;
    double nt = *n;
    double result = tgamma(xt+1) / tgamma(xt-nt+1);
	*res = result;
}




void LibFReal_BesselJ(double* res, const double* v, const double* x)
{
	*res = boost::math::cyl_bessel_j(*v, *x);
}



void LibFReal_BesselY(double* res, const double* v, const double* x)
{
	*res = boost::math::cyl_neumann(*v, *x);
}



void LibFReal_BesselI(double* res, const double* v, const double* x)
{
	*res = boost::math::cyl_bessel_i(*v, *x);
}



void LibFReal_BesselK(double* res, const double* v, const double* x)
{
	*res = boost::math::cyl_bessel_k(*v, *x);
}



void LibFReal_SphBessel(double* res, const unsigned v, const double* x)
{
	*res = boost::math::sph_bessel(v, *x);
}



void LibFReal_SphNeumann(double* res, const unsigned v, const double* x)
{
	*res = boost::math::sph_neumann(v, *x);
}





void LibFReal_BesselJPrime(double* res, const double* v, const double* x)
{
	*res = cyl_bessel_j_prime(*v, *x);
}



void LibFReal_BesselYPrime(double* res, const double* v, const double* x)
{
	*res = cyl_neumann_prime(*v, *x);
}



void LibFReal_BesselIPrime(double* res, const double* v, const double* x)
{
	*res = cyl_bessel_i_prime(*v, *x);
}



void LibFReal_BesselKPrime(double* res, const double* v, const double* x)
{
	*res = cyl_bessel_k_prime(*v, *x);
}



void LibFReal_SphBesselPrime(double* res, const unsigned v, const double* x)
{
	*res = sph_bessel_prime(v, *x);
}



void LibFReal_SphNeumannPrime(double* res, const unsigned v, const double* x)
{
	*res = sph_neumann_prime(v, *x);
}





void LibFReal_BesselJZero(double* res, const double* v, const int m)
{
	*res = cyl_bessel_j_zero(*v, m);
}



void LibFReal_BesselYZero(double* res, const double* v, const int m)
{
	*res = cyl_neumann_zero(*v, m);
}





void LibFReal_GammaP(double* res, const double* a, const double* x)
{
	*res = gamma_p(*a, *x);
}


void LibFReal_GammaQ(double* res, const double* a, const double* x)
{
	*res = gamma_q(*a, *x);
}


void LibFReal_TgammaLower(double* res, const double* a, const double* x)
{
	*res = tgamma_lower(*a, *x);
}


void LibFReal_TgammaUpper(double* res, const double* a, const double* x)
{
	*res = tgamma(*a, *x);
}




void LibFReal_GammaPInv(double* res, const double* a, const double* p)
{
	*res = gamma_p_inv(*a, *p);
}


void LibFReal_GammaQInv(double* res, const double* a, const double* q)
{
	*res = gamma_q_inv(*a, *q);
}


void LibFReal_GammaPInva(double* res, const double* x, const double* p)
{
	*res = gamma_p_inva(*x, *p);
}


void LibFReal_GammaQInva(double* res, const double* x, const double* q)
{
	*res = gamma_q_inva(*x, *q);
}



void LibFReal_GammaPDerivative(double* res, const double* a, const double* x)
{
	*res = gamma_p_derivative(*a, *x);
}


void LibFReal_Beta(double* res, const double* a, const double* b)
{
	*res = boost::math::beta(*a, *b);
}









void LibFReal_LegendreP(double* res, int n, const double* x)
{
	*res = legendre_p(n, *x);
}



void LibFReal_LegendreQ(double* res, int n, const double* x)
{
	*res = legendre_q(n, *x);
}



void LibFReal_Laguerre(double* res, int n, const double* x)
{
	*res = boost::math::laguerre(n, *x);
}



void LibFReal_Hermite(double* res, int n, const double* x)
{
	*res = boost::math::hermite(n, *x);
}



void LibFReal_ChebyshevT(double* res, int n, const double* x)
{
	*res = chebyshev_t(n, *x);
}


void LibFReal_ChebyshevU(double* res, int n, const double* x)
{
	*res = chebyshev_u(n, *x);
}



void LibFReal_Polygamma(double* res, int n, const double* x)
{
	*res = polygamma(n, *x);
}





void LibFReal_EllintRC(double* res, const double* x, const double* y)
{
	*res = ellint_rc(*x, *y);
}


void LibFReal_Ellint1F(double* res, const double* k, const double* phi)
{
	*res = boost::math::ellint_1(*k, *phi);
}


void LibFReal_Ellint2F(double* res, const double* k, const double* phi)
{
	*res = boost::math::ellint_2(*k, *phi);
}


void LibFReal_Ellint3K(double* res, const double* k, const double* n)
{
	*res = ellint_3(*k, *n);
}




void LibFReal_JacobiCD(double* res, const double* k, const double* u)
{
	*res = jacobi_cd(*k, *u);
}


void LibFReal_JacobiCN(double* res, const double* k, const double* u)
{
	*res = jacobi_cn(*k, *u);
}


void LibFReal_JacobiCS(double* res, const double* k, const double* u)
{
	*res = jacobi_cs(*k, *u);
}


void LibFReal_JacobiDC(double* res, const double* k, const double* u)
{
	*res = jacobi_dc(*k, *u);
}


void LibFReal_JacobiDN(double* res, const double* k, const double* u)
{
	*res = jacobi_dn(*k, *u);
}


void LibFReal_JacobiDS(double* res, const double* k, const double* u)
{
	*res = jacobi_ds(*k, *u);
}


void LibFReal_JacobiNC(double* res, const double* k, const double* u)
{
	*res = jacobi_nc(*k, *u);
}


void LibFReal_JacobiND(double* res, const double* k, const double* u)
{
	*res = jacobi_nd(*k, *u);
}


void LibFReal_JacobiNS(double* res, const double* k, const double* u)
{
	*res = jacobi_ns(*k, *u);
}


void LibFReal_JacobiSC(double* res, const double* k, const double* u)
{
	*res = jacobi_sc(*k, *u);
}


void LibFReal_JacobiSD(double* res, const double* k, const double* u)
{
	*res = jacobi_sd(*k, *u);
}


void LibFReal_JacobiSN(double* res, const double* k, const double* u)
{
	*res = jacobi_sn(*k, *u);
}



void LibFReal_expint(double* res, const unsigned n, const double* x)
{
	*res = expint(n, *x);
}




void LibFReal_OwenT(double* res, const double* h, const double* a)
{
	*res = owens_t(*h, *a);
}





void LibFReal_IBeta(double* res, const double* a, const double* b, const double* x)
{
	*res = ibeta(*a, *b, *x);
}


void LibFReal_IBetac(double* res, const double* a, const double* b, const double* x)
{
	*res = ibetac(*a, *b, *x);
}


void LibFReal_IBetaNonNormalized(double* res, const double* a, const double* b, const double* x)
{
	*res = beta(*a, *b, *x);
}


void LibFReal_IBetacNonNormalized(double* res, const double* a, const double* b, const double* x)
{
	*res = betac(*a, *b, *x);
}


void LibFReal_IBetaInv(double* res, const double* a, const double* b, const double* p)
{
	*res = ibeta_inv(*a, *b, *p);
}


void LibFReal_IBetacInv(double* res, const double* a, const double* b, const double* q)
{
	*res = ibetac_inv(*a, *b, *q);
}


void LibFReal_IBetaInva(double* res, const double* b, const double* x, const double* p)
{
	*res = ibeta_inva(*b, *x, *p);
}


void LibFReal_IBetacInva(double* res, const double* b, const double* x, const double* q)
{
	*res = ibetac_inva(*b, *x, *q);
}


void LibFReal_IBetaInvb(double* res, const double* a, const double* x, const double* p)
{
	*res = ibeta_invb(*a, *x, *p);
}


void LibFReal_IBetacInvb(double* res, const double* a, const double* x, const double* q)
{
	*res = ibetac_invb(*a, *x, *q);
}


void LibFReal_IBetaDerivative(double* res, const double* a, const double* b, const double* x)
{
	*res = ibeta_derivative(*a, *b, *x);
}




void LibFReal_LegendrePM(double* res, const int n, const int m, const double* x)
{
	*res = legendre_p(n, m, *x);
}



void LibFReal_LaguerreM(double* res, const int n, const int m, const double* x)
{
	*res = laguerre(n, m, *x);
}





void LibFReal_EllipticRF(double* res, const double* x, const double* y, const double* z)
{
	*res = ellint_rf(*x, *y, *z);
}



void LibFReal_EllipticRD(double* res, const double* x, const double* y, const double* z)
{
	*res = ellint_rd(*x, *y, *z);
}



void LibFReal_EllipticRG(double* res, const double* x, const double* y, const double* z)
{
	*res = ellint_rg(*x, *y, *z);
}



void LibFReal_Ellint3F(double* res, const double* k, const double* n, const double* phi)
{
	*res = boost::math::ellint_3(*k, *n, *phi);
}




void LibFReal_Gegenbauer(double* res, const int n, const double* lambda, const double* x)
{
	*res = boost::math::gegenbauer(n, *lambda, *x);
}



void LibFReal_Jacobi(double* res, const int n, const double* alpha, const double* beta, const double* x)
{
	*res = boost::math::jacobi(n, *alpha, *beta, *x);
}






void LibFReal_SphericalHarmonicR(double* res, const int n, const int m, const double* theta, const double* phi)
{
	*res = spherical_harmonic_r(n, m, *theta, *phi);
}


void LibFReal_SphericalHarmonicI(double* res, const int n, const int m, const double* theta, const double* phi)
{
	*res = spherical_harmonic_i(n, m, *theta, *phi);
}


void LibFReal_EllipticRJ(double* res, const double* x, const double* y, const double* z, const double* p)
{
	*res = ellint_rj(*x, *y, *z, *p);
}


// Hypergeometric and Theta Functions




void LibFReal_Hypergeo0F1(double* res, const double* b, const double* x)
{
	*res = hypergeometric_0F1(*b, *x);
}



void LibFReal_Hypergeo1F1(double* res, const double* a, const double* b, const double* x)
{
	*res = hypergeometric_1F1(*a, *b, *x);
}



void LibFReal_Hypergeo1F1r(double* res, const double* a, const double* b, const double* x)
{
	*res = hypergeometric_1F1_regularized(*a, *b, *x);
}



void LibFReal_LogHypergeo1F1(double* res, const double* a, const double* b, const double* x)
{
	*res = log_hypergeometric_1F1(*a, *b, *x);
}





void LibFReal_JacobiTheta1(double* res, const double* x, const double* q)
{
	*res = jacobi_theta1(*x, *q);
}


void LibFReal_JacobiTheta2(double* res, const double* x, const double* q)
{
	*res = jacobi_theta2(*x, *q);
}


void LibFReal_JacobiTheta3(double* res, const double* x, const double* q)
{
	*res = jacobi_theta3(*x, *q);
}


void LibFReal_JacobiTheta4(double* res, const double* x, const double* q)
{
	*res = jacobi_theta4(*x, *q);
}


