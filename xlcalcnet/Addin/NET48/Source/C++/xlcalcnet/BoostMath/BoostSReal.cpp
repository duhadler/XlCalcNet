


// See also: https://www.boost.org/doc/libs/1_80_0/boost/math/tools/user.hpp

#include <boost/math/tools/user.hpp>


#include "BoostSReal.h"


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
    float result = 0; \
    std::pair<float, float> dist_pair; \
    float xqp1 = *(float*)xqp; \
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
        default: {result =  std::numeric_limits<float>::quiet_NaN(); break;} \
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
//typedef Matrix<float, Dynamic, 1> state_type_vec;
//typedef state_type_vec* mpVectorPtr;
//
//
//
//class CppOptLibSolver : public Problem<float>
//{
//    public:
//    using typename cppoptlib::Problem<float>::TVector;
//    using typename cppoptlib::Problem<float>::THessian;
//    CppOptLibSolver(SRealFuncPtr f1, SRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_)
//     {func1 = f1; func2 = f2;  matX = matX_ ; matGrad = matGrad_;};
//    float value(const TVector &x) {
//          *matX = x;
//          float norm = 0.0;
//          func1(matX, &norm);
//          return norm;
//    }
//    void gradient(const TVector &x, TVector &grad) {
//        *matX = x;
//        *matGrad = grad;
//        func2(matX, matGrad);
//        grad = *matGrad;
//    }
//  SRealFuncPtr func1, func2;
//  mpVectorPtr matX, matGrad, matNorm;
//};
//
//
//
//
//void LibSReal_LbfgsSolver(SRealFuncPtr f1, SRealFuncPtr f2, SStatePtr matX_, SStatePtr matGrad_, SStatePtr xPtr)
//{
// printf("LbfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    LbfgsSolver<CppOptLibSolver> solver;
//    float eps = std::numeric_limits<float>::epsilon();
//    Criteria<float> m_stop;
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
//void LibSReal_BfgsSolver(SRealFuncPtr f1, SRealFuncPtr f2, SStatePtr matX_, SStatePtr matGrad_, SStatePtr xPtr)
//{
// printf("BfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    BfgsSolver<CppOptLibSolver> solver;
//    float eps = std::numeric_limits<float>::epsilon();
//    Criteria<float> m_stop;
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
//void LibSReal_GradientDescentSolver(SRealFuncPtr f1, SRealFuncPtr f2, SStatePtr matX_, SStatePtr matGrad_, SStatePtr xPtr)
//{
// printf("GradientDescentSolver");
//
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    GradientDescentSolver<CppOptLibSolver> solver;
//    float eps = std::numeric_limits<float>::epsilon();
//    Criteria<float> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)matX_) = x;
//    //(*(mpVectorPtr)matNorm_)(0) = f(x);
//}
//
//
//void LibSReal_ConjugatedGradientDescentSolver(SRealFuncPtr f1, SRealFuncPtr f2, SStatePtr matX_, SStatePtr matGrad_, SStatePtr xPtr)
//{
// printf("ConjugatedGradientDescentSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    ConjugatedGradientDescentSolver<CppOptLibSolver> solver;
//    float eps = std::numeric_limits<float>::epsilon();
//    Criteria<float> m_stop;
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
typedef Matrix<float, Dynamic, 1> state_type_vec;

struct Boost_LibSReal_Write
{
	Boost_LibSReal_Write(SAnyFuncPtr2 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, const float t)
	{
	    float fx = t;
		func1(&x, &fx);
	}
	SAnyFuncPtr2 func1;
};

struct Boost_LibSReal_Func_Vec
{
	Boost_LibSReal_Func_Vec(SAnyFuncPtr3 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, state_type_vec &dxdt, float t) const
	{
	    float fx = t;
		func1(&x, &dxdt, &fx);
	}
	SAnyFuncPtr3 func1;
};


/* Constant steppers */



void LibSReal_Const_RungeKutta4(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt)
{
	integrate_const(runge_kutta4<state_type_vec, float>(), Boost_LibSReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibSReal_Write(f2));
}


void LibSReal_Const_RungeKuttaCashKarp54(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt)
{
	integrate_const(runge_kutta_cash_karp54<state_type_vec, float>(), Boost_LibSReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibSReal_Write(f2));
}




void LibSReal_Const_RungeKuttaDopri5(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt)
{
	integrate_const(runge_kutta_dopri5<state_type_vec, float>(), Boost_LibSReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibSReal_Write(f2));
}




void LibSReal_Const_RungeKuttaFehlberg78(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt)
{
	integrate_const(runge_kutta_fehlberg78<state_type_vec, float>(), Boost_LibSReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibSReal_Write(f2));
}


void LibSReal_Const_AdamsBashforthMoulton(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt)
{
	integrate_const(adams_bashforth_moulton<5, state_type_vec, float>(), Boost_LibSReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibSReal_Write(f2));
}




/* Adaptive steppers */


void LibSReal_Adaptive_RungeKuttaDopri5(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_dopri5<state_type_vec, float>() ) , Boost_LibSReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibSReal_Write(f2));
}


void LibSReal_Adaptive_RungeKuttaCashKarp54(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_cash_karp54<state_type_vec, float>() ) , Boost_LibSReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt,  Boost_LibSReal_Write(f2));
}


void LibSReal_Adaptive_RungeKuttaFehlberg78(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_fehlberg78<state_type_vec, float>() ) , Boost_LibSReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibSReal_Write(f2));
}




void LibSReal_Adaptive_BulirschStoer(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel)
{
	bulirsch_stoer< state_type_vec, float > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibSReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibSReal_Write(f2));
}

/* Dense Output steppers */


void LibSReal_DenseOutput_Dopri5(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel)
{
    typedef runge_kutta_dopri5< state_type_vec, float > dopri5_type;
    typedef controlled_runge_kutta< dopri5_type > controlled_dopri5_type;
    typedef dense_output_runge_kutta< controlled_dopri5_type > dense_output_dopri5_type;
    dense_output_dopri5_type dopri5 = make_dense_output( eps_abs , eps_rel , dopri5_type() );
    integrate_adaptive( dopri5, Boost_LibSReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibSReal_Write(f2));
}



void LibSReal_DenseOutput_BulirschStoer(SAnyFuncPtr3 f1, SAnyFuncPtr2 f2, SStatePtr x, float start_time, float end_time, float dt, float eps_abs, float eps_rel)
{
	bulirsch_stoer_dense_out< state_type_vec, float > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibSReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibSReal_Write(f2));
}









//*********************** Numerical Calculus **********************************


struct SRealFunctor1
{
  SRealFunctor1(SRealFuncPtr f1):func1(f1) {}
  float operator()(float x)
  {
    float fx;
	func1( &x, &fx);
    return fx;
  }
private:
	SRealFuncPtr func1;
};



struct SRealFunctor2
{
  SRealFunctor2(SRealFuncPtr f1, SRealFuncPtr f2):func1(f1), func2(f2) {}
  std::pair<float, float> operator()(float x)
  {
    float fx, dx;
	func1( &x, &fx);
	func2( &x, &dx);
    return std::make_pair(fx, dx);
  }
private:
	SRealFuncPtr func1, func2;
};



struct SRealFunctor3
{
  SRealFunctor3(SRealFuncPtr f1, SRealFuncPtr f2, SRealFuncPtr f3):func1(f1), func2(f2), func3(f3) {}
  std::tuple<float, float, float> operator()(float x)
  {
    float fx, dx, d2x;
	func1( &x, &fx);
	func2( &x, &dx);
	func3( &x, &d2x);
    return std::make_tuple(fx, dx, d2x);
  }
private:
	SRealFuncPtr func1, func2, func3;
};



void LibSReal_BracketRoot(float* res1, float* res2, int* iter, SRealFuncPtr f1, float* guess, float* factor, bool is_rising, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    eps_tolerance<float> tol(get_digits);
    std::pair<float, float> r = bracket_and_solve_root(SRealFunctor1(f1), *guess, *factor, is_rising, tol, it);
	float error = (r.second - r.first) / 2;
	float result = r.first + error;
    (*res1) =  result;
    (*res2) =  error;
    *iter = (int) it;
}



void LibSReal_NewtonRaphson(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    float result = newton_raphson_iterate(SRealFunctor2(f1, f2), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibSReal_Halley(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, SRealFuncPtr f3, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    float result = halley_iterate(SRealFunctor3(f1, f2, f3), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibSReal_Schroder(float* res,  int* iter, SRealFuncPtr f1, SRealFuncPtr f2, SRealFuncPtr f3, float* guess, float* xmin, float* xmax, int get_digits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    float result = schroder_iterate(SRealFunctor3(f1, f2, f3), *guess, *xmin, *xmax, get_digits, it);
    (*res) =  result;
    *iter = (int) it;
}



void LibSReal_Brent_Minimum(float* res, float* resFx, int* iter, SRealFuncPtr f1, float* bracket_min, float* bracket_max, int bits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    std::pair<float, float> r = brent_find_minima(SRealFunctor1(f1), *bracket_min, *bracket_max, bits, it);
    (*res) =  r.first;
    (*resFx) =  r.second;
    *iter = (int) it;
}




void LibSReal_Trapezoidal(float* res1, float* res2, float* res3, SRealFuncPtr f1, float* a, float* b)
{
    auto f = [&f1](float x) {
        float fx;
        f1( &x, &fx);
        return fx;
        };
    size_t max_refinements = 24;
    float tol = sqrt(std::numeric_limits<float>::epsilon());
    float  error;
    float  L1;
    float result = trapezoidal(f, *a, *b, tol, max_refinements, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}


// 7, 15, 20, 25 and 30

void LibSReal_GaussLegendre(float* res1, float* res3, SRealFuncPtr f1, float* a, float* b)
{
    auto f = [&f1](float x) {
        float fx;
        f1( &x, &fx);
        return fx;
        };
    float  L1;
    float result = gauss<float, 7>::integrate(f, *a, *b, &L1);
    (*res1) =  result;
    (*res3) =  L1/std::abs(result);
}



//15, 31, 41, 51 and 61

void LibSReal_GaussKronrod(float* res1, float* res2, float* res3, SRealFuncPtr f1, float* a, float* b)
{
    auto f = [&f1](float x) {
        float fx;
        f1( &x, &fx);
        return fx;
        };
    unsigned max_depth = 15;
    float tol = sqrt(std::numeric_limits<float>::epsilon());
    float  error;
    float  L1;
    float result = gauss_kronrod<float, 15>::integrate(f, *a, *b, max_depth, tol, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}



void LibSReal_TanhSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1, float* a, float* b)
{
    tanh_sinh<float> integrator;
    auto f = [&f1](float x) {
        float fx;
        f1( &x, &fx);
        return fx;
        };
    float termination = sqrt(std::numeric_limits<float>::epsilon());
    float  error;
    float  L1;
    std::size_t levels = 0;
    float result = integrator.integrate(f, *a, *b, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibSReal_SinhSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1)
{
    sinh_sinh<float> integrator;
    auto f = [&f1](float x) {
        float fx;
        f1( &x, &fx);
        return fx;
        };
    float termination = sqrt(std::numeric_limits<float>::epsilon());
    float  error;
    float  L1;
    std::size_t levels = 0;
    float result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibSReal_ExpSinh(float* res1, float* res2, float* res3, int* levels_, SRealFuncPtr f1)
{
    exp_sinh<float> integrator;
    auto f = [&f1](float x) {
        float fx;
        f1( &x, &fx);
        return fx;
        };
    float termination = sqrt(std::numeric_limits<float>::epsilon());
    float  error;
    float  L1;
    std::size_t levels = 0;
    float result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibSReal_Ooura_Cos(float* res1, float* res2, SRealFuncPtr f1)
{
    float omega = 1;
	const float tol = 2 * std::numeric_limits<float>::epsilon();
	auto integrator = ooura_fourier_cos<float>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](float x) {
        float fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<float, float> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



void LibSReal_Ooura_Sin(float* res1, float* res2, SRealFuncPtr f1)
{
    float omega = 1;
	const float tol = 2 * std::numeric_limits<float>::epsilon();
	auto integrator = ooura_fourier_sin<float>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](float x) {
        float fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<float, float> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}




//*********************** Distributions **********************************


void LibSReal_ArcsineDist(long Target, float* res, float* xqp, float* a, float* b)
{
    arcsine_distribution<float> dist(*a, *b); MP_DIST_RETURN
}


void LibSReal_BernoulliDist(long Target, float* res, float* xqp, float* p)
{
    bernoulli_distribution<float> dist(*p); MP_DIST_RETURN
}


void LibSReal_BetaDist(long Target, float* res, float* xqp, float* a, float* b)
{
    beta_distribution<float> dist(*a, *b); MP_DIST_RETURN
}


void LibSReal_BinomialDist(long Target, float* res, float* xqp, float* n, float* p)
{
    binomial_distribution<float> dist(*n, *p); MP_DIST_RETURN
}


void LibSReal_CauchyDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    cauchy_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}


void LibSReal_Chi2Dist(long Target, float* res, float* xqp, float* nu)
{
    chi_squared_distribution<float> dist(*nu); MP_DIST_RETURN
}

void LibSReal_ExponentialDist(long Target, float* res, float* xqp, float* lambda)
{
    exponential_distribution<float> dist(*lambda); MP_DIST_RETURN
}


void LibSReal_ExtremeValueDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    extreme_value_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}


void LibSReal_FisherFDist(long Target, float* res, float* xqp, float* mu, float* nu)
{
    fisher_f_distribution<float> dist(*mu, *nu); MP_DIST_RETURN
}


void LibSReal_GammaDist(long Target, float* res, float* xqp, float* shape, float* scale)
{
    gamma_distribution<float> dist(*shape, *scale); MP_DIST_RETURN
}


void LibSReal_GeometricDist(long Target, float* res, float* xqp, float* p)
{
    geometric_distribution<float> dist(*p); MP_DIST_RETURN
}


void LibSReal_HypergeometricDist(long Target, float* res, float* xqp, uint64_t r, uint64_t n, uint64_t N)
{
    hypergeometric_distribution<float> dist(r, n, N); MP_DIST_RETURN
}


void LibSReal_InverseChi2Dist(long Target, float* res, float* xqp, float* df, float* scale)
{
    inverse_chi_squared_distribution<float> dist(*df, *scale); MP_DIST_RETURN
}



void LibSReal_InverseGammaDist(long Target, float* res, float* xqp, float* shape, float* scale)
{
    inverse_gamma_distribution<float> dist(*shape, *scale); MP_DIST_RETURN
}


void LibSReal_InverseGaussianDist(long Target, float* res, float* xqp, float* mean_, float* scale)
{
    inverse_gaussian_distribution<float> dist(*mean_, *scale); MP_DIST_RETURN
}


void LibSReal_LaplaceDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    laplace_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}


void LibSReal_LogisticDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    logistic_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}


void LibSReal_LognormalDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    lognormal_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}


void LibSReal_NegBinomialDist(long Target, float* res, float* xqp, float* n, float* p)
{
    negative_binomial_distribution<float> dist(*n, *p); MP_DIST_RETURN
}


void LibSReal_Chi2NCDist(long Target, float* res, float* xqp, float* nu, float* nc)
{
    non_central_chi_squared_distribution<float> dist(*nu, *nc); MP_DIST_RETURN
}


void LibSReal_StudentTNCDist(long Target, float* res, float* xqp, float* nu, float* delta)
{
    non_central_t_distribution<float> dist(*nu, *delta); MP_DIST_RETURN
}


void LibSReal_FisherNCDist(long Target, float* res, float* xqp, float* mu, float* nu, float* nc)
{
    non_central_f_distribution<float> dist(*mu, *nu, *nc); MP_DIST_RETURN
}


void LibSReal_BetaNCDist(long Target, float* res, float* xqp, float* a, float* b, float* nc)
{
    non_central_beta_distribution<float> dist(*a, *b, *nc); MP_DIST_RETURN
}


void LibSReal_NormalDist(long Target, float* res, float* xqp, float* mean_, float* stdev)
{
    normal_distribution<float> dist(*mean_, *stdev); MP_DIST_RETURN
}


void LibSReal_ParetoDist(long Target, float* res, float* xqp, float* shape, float* scale)
{
    pareto_distribution<float> dist(*shape, *scale); MP_DIST_RETURN
}


void LibSReal_PoissonDist(long Target, float* res, float* xqp, float* nu)
{
    poisson_distribution<float> dist(*nu); MP_DIST_RETURN
}


void LibSReal_RayleighDist(long Target, float* res, float* xqp, float* nu)
{
    rayleigh_distribution<float> dist(*nu); MP_DIST_RETURN
}


void LibSReal_SkewNormalDist(long Target, float* res, float* xqp, float* mean_, float* scale, float* shape)
{
    skew_normal_distribution<float> dist(*mean_, *scale, *shape); MP_DIST_RETURN
}


void LibSReal_StudentTDist(long Target, float* res, float* xqp, float* nu)
{
    students_t_distribution<float> dist(*nu); MP_DIST_RETURN
}


void LibSReal_TriangularDist(long Target, float* res, float* xqp, float* lower, float* mode_, float* upper)
{
    triangular_distribution<float> dist(*lower, *mode_, *upper); MP_DIST_RETURN
}


void LibSReal_WeibullDist(long Target, float* res, float* xqp, float* shape, float* scale)
{
    weibull_distribution<float> dist(*shape, *scale); MP_DIST_RETURN
}


void LibSReal_UniformDist(long Target, float* res, float* xqp, float* lower, float* upper)
{
    uniform_distribution<float> dist(*lower, *upper); MP_DIST_RETURN
}





//*********************** New , float precision **********************************



void LibSReal_Logaddexp(float* res, const float* a, const float* b)
{
	*res = logaddexp(*a, *b);
}



void LibSReal_HyperexponentialDist(long Target, float* res, float* xqp, SStatePtr l1, SStatePtr l2)
{

    hyperexponential_distribution<float> dist( *(state_type_vec*) l1, *(state_type_vec*) l2); MP_DIST_RETURN
}


void LibSReal_KolmogorovSmirnovDist(long Target, float* res, float* xqp, float* n)
{
    kolmogorov_smirnov_distribution<float> dist(*n); MP_DIST_RETURN
}


void LibSReal_HoltsmarkDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    holtsmark_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}


void LibSReal_LandauDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    landau_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}


void LibSReal_MapAiryDist(long Target, float* res, float* xqp, float* location, float* scale)
{
    mapairy_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}


void LibSReal_Saspoint5Dist(long Target, float* res, float* xqp, float* location, float* scale)
{
    saspoint5_distribution<float> dist(*location, *scale); MP_DIST_RETURN
}














//*********************** Boost Special functions , single precision **********************************



void LibSReal_Ulp(float* res, const float* x)
{
	*res = ulp(*x);
}



void LibSReal_BernoulliB2n(float* res, const int n)
{
	*res = bernoulli_b2n<float>(n);
}



void LibSReal_TangentT2n(float* res, const int n)
{
	*res = tangent_t2n<float>(n);
}



void LibSReal_Sqrt1pm1(float* res, const float* x)
{
	*res = sqrt1pm1(*x);
}





void LibSReal_SinPi(float* res, const float* x)
{
	*res = sin_pi(*x);
}

void LibSReal_CosPi(float* res, const float* x)
{
	*res = cos_pi(*x);
}

void LibSReal_TanPi(float* res, const float* x)
{
	*res = sin_pi(*x) / cos_pi(*x);
}



void LibSReal_CscPi(float* res, const float* x)
{
	*res = (1.0f) / sin_pi(*x);
}

void LibSReal_SecPi(float* res, const float* x)
{
	*res = (1.0f) / cos_pi(*x);
}

void LibSReal_CotPi(float* res, const float* x)
{
	*res = cos_pi(*x) / sin_pi(*x);
}







void LibSReal_SincPi(float* res, const float* x)
{
	*res = sinc_pi(*x);
}



void LibSReal_SinhcPi(float* res, const float* x)
{
	*res = sinhc_pi(*x);
}



void LibSReal_Tgamma_(float* res, const float* x)
{
	*res = tgamma(*x);
}


void LibSReal_Tgamma1pm1(float* res, const float* x)
{
	*res = tgamma1pm1(*x);
}



void LibSReal_Lgamma_(float* res, const float* x)
{
	*res = lgamma(*x);
}



void LibSReal_Digamma(float* res, const float* x)
{
	*res = digamma(*x);
}



void LibSReal_Trigamma(float* res, const float* x)
{
	*res = trigamma(*x);
}



void LibSReal_Factorial(float* res, const float* x)
{
    float xt = *x;
    float result = tgamma(xt + 1);
	*res = result;
}



void LibSReal_DoubleFactorial(float* res, const float* x)
{
    float xt = *x;
    float xt2 = xt/2;
    float t1 = (cos_pi(xt)-1)/4;
    float pi2 = constants::half_pi<float>();
    float t2 = pow(pi2, t1);
    float result = exp2(xt2) * t2 * tgamma(xt2+1);
	*res = result;
}





void LibSReal_Erf_(float* res, const float* x)
{
	*res = erf(*x);
}



void LibSReal_Erfc_(float* res, const float* x)
{
	*res = erfc(*x);
}



void LibSReal_Erf_inv(float* res, const float* x)
{
	*res = erf_inv(*x);
}



void LibSReal_Erfc_inv(float* res, const float* x)
{
	*res = erfc_inv(*x);
}



void LibSReal_AiryAi(float* res, const float* x)
{
	*res = airy_ai(*x);
}



void LibSReal_AiryBi(float* res, const float* x)
{
	*res = airy_bi(*x);
}



void LibSReal_AiryAiPrime(float* res, const float* x)
{
	*res = airy_ai_prime(*x);
}



void LibSReal_AiryBiPrime(float* res, const float* x)
{
	*res = airy_bi_prime(*x);
}



void LibSReal_Aizero(float* res, const int n)
{
	*res = airy_ai_zero<float>(n);
}



void LibSReal_Bizero(float* res, const int n)
{
	*res = airy_bi_zero<float>(n);
}



void LibSReal_Ellint_1_K(float* res, const float* x)
{
	*res = ellint_1(*x);
}



void LibSReal_Ellint_2_K(float* res, const float* x)
{
	*res = ellint_2(*x);
}



void LibSReal_Zeta(float* res, const float* x)
{
	*res = zeta(*x);
}



void LibSReal_Ei(float* res, const float* x)
{
	*res = boost::math::expint(*x);
}



void LibSReal_LambertW0(float* res, const float* x)
{
	*res = lambert_w0(*x);
}


void LibSReal_LambertWm1(float* res, const float* x)
{
	*res = lambert_wm1(*x);
}



void LibSReal_LambertW0Prime(float* res, const float* x)
{
	*res = lambert_w0_prime(*x);
}


void LibSReal_LambertWm1Prime(float* res, const float* x)
{
	*res = lambert_wm1_prime(*x);
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void LibSReal_Agm(float* res, const float* a, const float* b)
{
	*res = agm(*a, *b);
}




void LibSReal_Powm1(float* res, const float* a, const float* b)
{
	*res = powm1(*a, *b);
}



void LibSReal_TgammaRatio(float* res, const float* a, const float* b)
{
	*res = tgamma_ratio(*a, *b);
}



void LibSReal_TgammaDeltaRatio(float* res, const float* a, const float* b)
{
	*res = tgamma_delta_ratio(*a, *b);
}



void LibSReal_Binomial(float* res, const float* n, const float* k)
{
    float nt = *n;
    float kt = *k;
    float result = tgamma(nt+1) / ( tgamma(kt+1) * tgamma(nt-kt+1) );
	*res = result;
}

void LibSReal_RisingFactorial(float* res, const float* x, const float* n)
{
    float xt = *x;
    float nt = *n;
    float result = tgamma(xt+nt) / tgamma(xt);
	*res = result;
}




void LibSReal_FallingFactorial(float* res, const float* x, const float* n)
{
    float xt = *x;
    float nt = *n;
    float result = tgamma(xt+1) / tgamma(xt-nt+1);
	*res = result;
}




void LibSReal_BesselJ(float* res, const float* v, const float* x)
{
	*res = boost::math::cyl_bessel_j(*v, *x);
}



void LibSReal_BesselY(float* res, const float* v, const float* x)
{
	*res = boost::math::cyl_neumann(*v, *x);
}



void LibSReal_BesselI(float* res, const float* v, const float* x)
{
	*res = boost::math::cyl_bessel_i(*v, *x);
}



void LibSReal_BesselK(float* res, const float* v, const float* x)
{
	*res = boost::math::cyl_bessel_k(*v, *x);
}



void LibSReal_SphBessel(float* res, const unsigned v, const float* x)
{
	*res = boost::math::sph_bessel(v, *x);
}



void LibSReal_SphNeumann(float* res, const unsigned v, const float* x)
{
	*res = boost::math::sph_neumann(v, *x);
}





void LibSReal_BesselJPrime(float* res, const float* v, const float* x)
{
	*res = cyl_bessel_j_prime(*v, *x);
}



void LibSReal_BesselYPrime(float* res, const float* v, const float* x)
{
	*res = cyl_neumann_prime(*v, *x);
}



void LibSReal_BesselIPrime(float* res, const float* v, const float* x)
{
	*res = cyl_bessel_i_prime(*v, *x);
}



void LibSReal_BesselKPrime(float* res, const float* v, const float* x)
{
	*res = cyl_bessel_k_prime(*v, *x);
}



void LibSReal_SphBesselPrime(float* res, const unsigned v, const float* x)
{
	*res = sph_bessel_prime(v, *x);
}



void LibSReal_SphNeumannPrime(float* res, const unsigned v, const float* x)
{
	*res = sph_neumann_prime(v, *x);
}





void LibSReal_BesselJZero(float* res, const float* v, const int m)
{
	*res = cyl_bessel_j_zero(*v, m);
}



void LibSReal_BesselYZero(float* res, const float* v, const int m)
{
	*res = cyl_neumann_zero(*v, m);
}





void LibSReal_GammaP(float* res, const float* a, const float* x)
{
	*res = gamma_p(*a, *x);
}


void LibSReal_GammaQ(float* res, const float* a, const float* x)
{
	*res = gamma_q(*a, *x);
}


void LibSReal_TgammaLower(float* res, const float* a, const float* x)
{
	*res = tgamma_lower(*a, *x);
}


void LibSReal_TgammaUpper(float* res, const float* a, const float* x)
{
	*res = tgamma(*a, *x);
}




void LibSReal_GammaPInv(float* res, const float* a, const float* p)
{
	*res = gamma_p_inv(*a, *p);
}


void LibSReal_GammaQInv(float* res, const float* a, const float* q)
{
	*res = gamma_q_inv(*a, *q);
}


void LibSReal_GammaPInva(float* res, const float* x, const float* p)
{
	*res = gamma_p_inva(*x, *p);
}


void LibSReal_GammaQInva(float* res, const float* x, const float* q)
{
	*res = gamma_q_inva(*x, *q);
}



void LibSReal_GammaPDerivative(float* res, const float* a, const float* x)
{
	*res = gamma_p_derivative(*a, *x);
}


void LibSReal_Beta(float* res, const float* a, const float* b)
{
	*res = boost::math::beta(*a, *b);
}









void LibSReal_LegendreP(float* res, int n, const float* x)
{
	*res = legendre_p(n, *x);
}



void LibSReal_LegendreQ(float* res, int n, const float* x)
{
	*res = legendre_q(n, *x);
}



void LibSReal_Laguerre(float* res, int n, const float* x)
{
	*res = boost::math::laguerre(n, *x);
}



void LibSReal_Hermite(float* res, int n, const float* x)
{
	*res = boost::math::hermite(n, *x);
}



void LibSReal_ChebyshevT(float* res, int n, const float* x)
{
	*res = chebyshev_t(n, *x);
}


void LibSReal_ChebyshevU(float* res, int n, const float* x)
{
	*res = chebyshev_u(n, *x);
}



void LibSReal_Polygamma(float* res, int n, const float* x)
{
	*res = polygamma(n, *x);
}





void LibSReal_EllintRC(float* res, const float* x, const float* y)
{
	*res = ellint_rc(*x, *y);
}


void LibSReal_Ellint1F(float* res, const float* k, const float* phi)
{
	*res = boost::math::ellint_1(*k, *phi);
}


void LibSReal_Ellint2F(float* res, const float* k, const float* phi)
{
	*res = boost::math::ellint_2(*k, *phi);
}


void LibSReal_Ellint3K(float* res, const float* k, const float* n)
{
	*res = ellint_3(*k, *n);
}




void LibSReal_JacobiCD(float* res, const float* k, const float* u)
{
	*res = jacobi_cd(*k, *u);
}


void LibSReal_JacobiCN(float* res, const float* k, const float* u)
{
	*res = jacobi_cn(*k, *u);
}


void LibSReal_JacobiCS(float* res, const float* k, const float* u)
{
	*res = jacobi_cs(*k, *u);
}


void LibSReal_JacobiDC(float* res, const float* k, const float* u)
{
	*res = jacobi_dc(*k, *u);
}


void LibSReal_JacobiDN(float* res, const float* k, const float* u)
{
	*res = jacobi_dn(*k, *u);
}


void LibSReal_JacobiDS(float* res, const float* k, const float* u)
{
	*res = jacobi_ds(*k, *u);
}


void LibSReal_JacobiNC(float* res, const float* k, const float* u)
{
	*res = jacobi_nc(*k, *u);
}


void LibSReal_JacobiND(float* res, const float* k, const float* u)
{
	*res = jacobi_nd(*k, *u);
}


void LibSReal_JacobiNS(float* res, const float* k, const float* u)
{
	*res = jacobi_ns(*k, *u);
}


void LibSReal_JacobiSC(float* res, const float* k, const float* u)
{
	*res = jacobi_sc(*k, *u);
}


void LibSReal_JacobiSD(float* res, const float* k, const float* u)
{
	*res = jacobi_sd(*k, *u);
}


void LibSReal_JacobiSN(float* res, const float* k, const float* u)
{
	*res = jacobi_sn(*k, *u);
}



void LibSReal_expint(float* res, const unsigned n, const float* x)
{
	*res = expint(n, *x);
}




void LibSReal_OwenT(float* res, const float* h, const float* a)
{
	*res = owens_t(*h, *a);
}





void LibSReal_IBeta(float* res, const float* a, const float* b, const float* x)
{
	*res = ibeta(*a, *b, *x);
}


void LibSReal_IBetac(float* res, const float* a, const float* b, const float* x)
{
	*res = ibetac(*a, *b, *x);
}


void LibSReal_IBetaNonNormalized(float* res, const float* a, const float* b, const float* x)
{
	*res = beta(*a, *b, *x);
}


void LibSReal_IBetacNonNormalized(float* res, const float* a, const float* b, const float* x)
{
	*res = betac(*a, *b, *x);
}


void LibSReal_IBetaInv(float* res, const float* a, const float* b, const float* p)
{
	*res = ibeta_inv(*a, *b, *p);
}


void LibSReal_IBetacInv(float* res, const float* a, const float* b, const float* q)
{
	*res = ibetac_inv(*a, *b, *q);
}


void LibSReal_IBetaInva(float* res, const float* b, const float* x, const float* p)
{
	*res = ibeta_inva(*b, *x, *p);
}


void LibSReal_IBetacInva(float* res, const float* b, const float* x, const float* q)
{
	*res = ibetac_inva(*b, *x, *q);
}


void LibSReal_IBetaInvb(float* res, const float* a, const float* x, const float* p)
{
	*res = ibeta_invb(*a, *x, *p);
}


void LibSReal_IBetacInvb(float* res, const float* a, const float* x, const float* q)
{
	*res = ibetac_invb(*a, *x, *q);
}


void LibSReal_IBetaDerivative(float* res, const float* a, const float* b, const float* x)
{
	*res = ibeta_derivative(*a, *b, *x);
}




void LibSReal_LegendrePM(float* res, const int n, const int m, const float* x)
{
	*res = legendre_p(n, m, *x);
}



void LibSReal_LaguerreM(float* res, const int n, const int m, const float* x)
{
	*res = laguerre(n, m, *x);
}





void LibSReal_EllipticRF(float* res, const float* x, const float* y, const float* z)
{
	*res = ellint_rf(*x, *y, *z);
}



void LibSReal_EllipticRD(float* res, const float* x, const float* y, const float* z)
{
	*res = ellint_rd(*x, *y, *z);
}



void LibSReal_EllipticRG(float* res, const float* x, const float* y, const float* z)
{
	*res = ellint_rg(*x, *y, *z);
}



void LibSReal_Ellint3F(float* res, const float* k, const float* n, const float* phi)
{
	*res = boost::math::ellint_3(*k, *n, *phi);
}



void LibSReal_Gegenbauer(float* res, const int n, const float* lambda, const float* x)
{
	*res = boost::math::gegenbauer(n, *lambda, *x);
}



void LibSReal_Jacobi(float* res, const int n, const float* alpha, const float* beta, const float* x)
{
	*res = boost::math::jacobi(n, *alpha, *beta, *x);
}




void LibSReal_SphericalHarmonicR(float* res, const int n, const int m, const float* theta, const float* phi)
{
	*res = spherical_harmonic_r(n, m, *theta, *phi);
}


void LibSReal_SphericalHarmonicI(float* res, const int n, const int m, const float* theta, const float* phi)
{
	*res = spherical_harmonic_i(n, m, *theta, *phi);
}


void LibSReal_EllipticRJ(float* res, const float* x, const float* y, const float* z, const float* p)
{
	*res = ellint_rj(*x, *y, *z, *p);
}


// Hypergeometric and Theta Functions




void LibSReal_Hypergeo0F1(float* res, const float* b, const float* x)
{
	*res = hypergeometric_0F1(*b, *x);
}



void LibSReal_Hypergeo1F1(float* res, const float* a, const float* b, const float* x)
{
	*res = hypergeometric_1F1(*a, *b, *x);
}



void LibSReal_Hypergeo1F1r(float* res, const float* a, const float* b, const float* x)
{
	*res = hypergeometric_1F1_regularized(*a, *b, *x);
}



void LibSReal_LogHypergeo1F1(float* res, const float* a, const float* b, const float* x)
{
	*res = log_hypergeometric_1F1(*a, *b, *x);
}





void LibSReal_JacobiTheta1(float* res, const float* x, const float* q)
{
	*res = jacobi_theta1(*x, *q);
}


void LibSReal_JacobiTheta2(float* res, const float* x, const float* q)
{
	*res = jacobi_theta2(*x, *q);
}


void LibSReal_JacobiTheta3(float* res, const float* x, const float* q)
{
	*res = jacobi_theta3(*x, *q);
}


void LibSReal_JacobiTheta4(float* res, const float* x, const float* q)
{
	*res = jacobi_theta4(*x, *q);
}












