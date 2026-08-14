


// See also: https://www.boost.org/doc/libs/1_80_0/boost/math/tools/user.hpp

// \home\MP64\math-boost\include\boost\math\tools\user.hpp

// Note: in exp_sinh_detail.hpp, line 229 changed to Real abterm1  [[maybe_unused]] = 1;

// Note: in fisher_f.hpp, line 247,  changed to    RealType x, y = 0;


#include <boost/math/tools/user.hpp>
#include <boost/math/tools/config.hpp>

#include "BoostOReal.h"

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
    cpp_bin_float_oct result = 0; \
    std::pair<cpp_bin_float_oct, cpp_bin_float_oct> dist_pair; \
    cpp_bin_float_oct xqp1 = cpp_bin_float_oct(*(cpp_bin_float_oct*)xqp); \
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
    (*(cpp_bin_float_oct*)res) = result;


#include <boost/math/tools/minima.hpp>
#include <boost/math/tools/roots.hpp>
#include <boost/math/tools/agm.hpp>
#include <tuple> // for std::tuple and std::make_tuple.
#include <boost/math/constants/constants.hpp>
#include <boost/math/special_functions.hpp>
#include <boost/math/special_functions/logaddexp.hpp>

#include <boost/math/distributions.hpp>
#include <boost/multiprecision/cpp_bin_float.hpp>

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
using namespace boost::multiprecision;
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
//////*********************** Boost/CppOptLib **********************************
////
//using namespace Eigen;
//using namespace cppoptlib;
//typedef Matrix<cpp_bin_float_oct, Dynamic, 1> state_type_vec;
//typedef state_type_vec* mpVectorPtr;
//
//
//
//class CppOptLibSolver : public Problem<cpp_bin_float_oct>
//{
//    public:
//    using typename cppoptlib::Problem<cpp_bin_float_oct>::TVector;
//    using typename cppoptlib::Problem<cpp_bin_float_oct>::THessian;
//    CppOptLibSolver(ORealFuncPtr f1, ORealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_)
//     {func1 = f1; func2 = f2;  matX = matX_ ; matGrad = matGrad_;};
//    cpp_bin_float_oct value(const TVector &x) {
//          *matX = x;
//          cpp_bin_float_oct norm = 0.0;
//          func1(matX, &norm);
//          return norm;
//    }
//    void gradient(const TVector &x, TVector &grad) {
//        *matX = x;
//        *matGrad = grad;
//        func2(matX, matGrad);
//        grad = *matGrad;
//    }
//  ORealFuncPtr func1, func2;
//  mpVectorPtr matX, matGrad, matNorm;
//};
//
//
//
//
//void LibOReal_LbfgsSolver(ORealFuncPtr f1, ORealFuncPtr f2, OStatePtr matX_, OStatePtr matGrad_, OStatePtr xPtr)
//{
// printf("LbfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    LbfgsSolver<CppOptLibSolver> solver;
//    cpp_bin_float_oct eps = std::numeric_limits<cpp_bin_float_oct>::epsilon();
//    Criteria<cpp_bin_float_oct> m_stop;
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
//void LibOReal_BfgsSolver(ORealFuncPtr f1, ORealFuncPtr f2, OStatePtr matX_, OStatePtr matGrad_, OStatePtr xPtr)
//{
// printf("BfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    BfgsSolver<CppOptLibSolver> solver;
//    cpp_bin_float_oct eps = std::numeric_limits<cpp_bin_float_oct>::epsilon();
//    Criteria<cpp_bin_float_oct> m_stop;
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
//void LibOReal_GradientDescentSolver(ORealFuncPtr f1, ORealFuncPtr f2, OStatePtr matX_, OStatePtr matGrad_, OStatePtr xPtr)
//{
// printf("GradientDescentSolver");
//
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    GradientDescentSolver<CppOptLibSolver> solver;
//    cpp_bin_float_oct eps = std::numeric_limits<cpp_bin_float_oct>::epsilon();
//    Criteria<cpp_bin_float_oct> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)matX_) = x;
//    //(*(mpVectorPtr)matNorm_)(0) = f(x);
//}
//
//
//void LibOReal_ConjugatedGradientDescentSolver(ORealFuncPtr f1, ORealFuncPtr f2, OStatePtr matX_, OStatePtr matGrad_, OStatePtr xPtr)
//{
// printf("ConjugatedGradientDescentSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    ConjugatedGradientDescentSolver<CppOptLibSolver> solver;
//    cpp_bin_float_oct eps = std::numeric_limits<cpp_bin_float_oct>::epsilon();
//    Criteria<cpp_bin_float_oct> m_stop;
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
typedef Matrix<cpp_bin_float_oct, Dynamic, 1> state_type_vec;
typedef state_type_vec* mpVectorPtr;


using namespace boost::numeric::odeint;

OStatePtr LibOReal_StateInit_Func_N(int N)
{
    mpVectorPtr x = new(state_type_vec);
    (*x).resize(N);
    (*x).setZero();
    return x;
}


void LibOReal_StateClear(OStatePtr x)
{
    delete ((mpVectorPtr)x);
}


void LibOReal_StateGetCoeff(ORealPtr res, long row, OStatePtr source)
{
    (*(cpp_bin_float_oct*)res) = (*(mpVectorPtr) source).coeff(row);
}



void LibOReal_StateSetCoeff(OStatePtr result, ORealPtr source, long row)
{
    (*(mpVectorPtr) result)(row) = *(cpp_bin_float_oct*)source;
}

void LibOReal_StateGetSize(long *result, OStatePtr x)
{
    *result = (long)(*(mpVectorPtr)x).size();
}







struct Boost_LibOReal_Write
{
	Boost_LibOReal_Write(OAnyFuncPtr2 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, const cpp_bin_float_oct t)
	{
	    cpp_bin_float_oct fx = t;
		func1(&x, &fx);
	}
	OAnyFuncPtr2 func1;
};


struct Boost_LibOReal_Func_Vec
{
	Boost_LibOReal_Func_Vec(OAnyFuncPtr3 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, state_type_vec &dxdt, cpp_bin_float_oct t) const
	{
	    cpp_bin_float_oct fx = t;
		func1(&x, &dxdt, &fx);
	}
	OAnyFuncPtr3 func1;
};




/* Constant steppers */

void LibOReal_Const_RungeKutta4(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
	integrate_const(runge_kutta4<state_type_vec, cpp_bin_float_oct>(), Boost_LibOReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibOReal_Write(f2));
}

void LibOReal_Const_RungeKuttaCashKarp54(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
	integrate_const(runge_kutta_cash_karp54<state_type_vec, cpp_bin_float_oct>(), Boost_LibOReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibOReal_Write(f2));
}

void LibOReal_Const_RungeKuttaDopri5(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
	integrate_const(runge_kutta_dopri5<state_type_vec, cpp_bin_float_oct>(), Boost_LibOReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibOReal_Write(f2));
}

void LibOReal_Const_RungeKuttaFehlberg78(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
	integrate_const(runge_kutta_fehlberg78<state_type_vec, cpp_bin_float_oct>(), Boost_LibOReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibOReal_Write(f2));
}

void LibOReal_Const_AdamsBashforthMoulton(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
	integrate_const(adams_bashforth_moulton<5, state_type_vec, cpp_bin_float_oct>(), Boost_LibOReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibOReal_Write(f2));
}


/* Adaptive steppers */

void LibOReal_Adaptive_RungeKuttaDopri5(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
    cpp_bin_float_oct eps_abs = *(cpp_bin_float_oct*)eps_abs_;
    cpp_bin_float_oct eps_rel = *(cpp_bin_float_oct*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_dopri5<state_type_vec, cpp_bin_float_oct>() ) , Boost_LibOReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibOReal_Write(f2));
}


void LibOReal_Adaptive_RungeKuttaCashKarp54(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
    cpp_bin_float_oct eps_abs = *(cpp_bin_float_oct*)eps_abs_;
    cpp_bin_float_oct eps_rel = *(cpp_bin_float_oct*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_cash_karp54<state_type_vec, cpp_bin_float_oct>() ) , Boost_LibOReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibOReal_Write(f2));
}


void LibOReal_Adaptive_RungeKuttaFehlberg78(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
    cpp_bin_float_oct eps_abs = *(cpp_bin_float_oct*)eps_abs_;
    cpp_bin_float_oct eps_rel = *(cpp_bin_float_oct*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_fehlberg78<state_type_vec, cpp_bin_float_oct>() ) , Boost_LibOReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibOReal_Write(f2));
}


void LibOReal_Adaptive_BulirschStoer(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
    cpp_bin_float_oct eps_abs = *(cpp_bin_float_oct*)eps_abs_;
    cpp_bin_float_oct eps_rel = *(cpp_bin_float_oct*)eps_rel_;

	bulirsch_stoer< state_type_vec, cpp_bin_float_oct > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibOReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibOReal_Write(f2));
}

/* Dense Output steppers */


void LibOReal_DenseOutput_Dopri5(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
    cpp_bin_float_oct eps_abs = *(cpp_bin_float_oct*)eps_abs_;
    cpp_bin_float_oct eps_rel = *(cpp_bin_float_oct*)eps_rel_;

    typedef runge_kutta_dopri5< state_type_vec, cpp_bin_float_oct > dopri5_type;
    typedef controlled_runge_kutta< dopri5_type > controlled_dopri5_type;
    typedef dense_output_runge_kutta< controlled_dopri5_type > dense_output_dopri5_type;
    dense_output_dopri5_type dopri5 = make_dense_output( eps_abs , eps_rel , dopri5_type() );
    integrate_adaptive( dopri5, Boost_LibOReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibOReal_Write(f2));
}


void LibOReal_DenseOutput_BulirschStoer(OAnyFuncPtr3 f1, OAnyFuncPtr2 f2, OStatePtr x, ORealPtr start_time_, ORealPtr end_time_, ORealPtr dt_, ORealPtr eps_abs_, ORealPtr eps_rel_)
{
    cpp_bin_float_oct start_time = *(cpp_bin_float_oct*)start_time_;
    cpp_bin_float_oct end_time = *(cpp_bin_float_oct*)end_time_;
    cpp_bin_float_oct dt = *(cpp_bin_float_oct*)dt_;
    cpp_bin_float_oct eps_abs = *(cpp_bin_float_oct*)eps_abs_;
    cpp_bin_float_oct eps_rel = *(cpp_bin_float_oct*)eps_rel_;

	bulirsch_stoer_dense_out< state_type_vec, cpp_bin_float_oct > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibOReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibOReal_Write(f2));
}







//*********************** Boost Numerical Calculus, OReal **********************************




struct ORealFunctor1
{
  ORealFunctor1(ORealFuncPtr f1):func1(f1) {}
  cpp_bin_float_oct operator()(cpp_bin_float_oct x)
  {
    cpp_bin_float_oct fx;
	func1( &x, &fx);
    return fx;
  }
private:
	ORealFuncPtr func1;
};


struct ORealFunctor2
{
  ORealFunctor2(ORealFuncPtr f1, ORealFuncPtr f2):func1(f1), func2(f2) {}
  std::pair<cpp_bin_float_oct, cpp_bin_float_oct> operator()(cpp_bin_float_oct x)
  {
    cpp_bin_float_oct fx, dx;
	func1( &x, &fx);
	func2( &x, &dx);
    return std::make_pair(fx, dx);
  }
private:
	ORealFuncPtr func1, func2;
};


struct ORealFunctor3
{
  ORealFunctor3(ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3):func1(f1), func2(f2), func3(f3) {}
  std::tuple<cpp_bin_float_oct, cpp_bin_float_oct, cpp_bin_float_oct> operator()(cpp_bin_float_oct x)
  {
    cpp_bin_float_oct fx, dx, d2x;
	func1( &x, &fx);
	func2( &x, &dx);
	func3( &x, &d2x);
    return std::make_tuple(fx, dx, d2x);
  }
private:
	ORealFuncPtr func1, func2, func3;
};



void LibOReal_BracketRoot(ORealPtr res1, ORealPtr res2, int* iter, ORealFuncPtr f1, ORealPtr guess_, ORealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    cpp_bin_float_oct guess = *(cpp_bin_float_oct*)guess_;
    cpp_bin_float_oct factor = *(cpp_bin_float_oct*)factor_;
	uintmax_t it = maxit;
	eps_tolerance<cpp_bin_float_oct> tol(get_digits);
	std::pair<cpp_bin_float_oct, cpp_bin_float_oct> r = bracket_and_solve_root(ORealFunctor1(f1), guess, factor, is_rising, tol, it);
	cpp_bin_float_oct error = (r.second - r.first) / 2;
	cpp_bin_float_oct result = r.first + error;
    (*(cpp_bin_float_oct*)res1) = result;
    (*(cpp_bin_float_oct*)res2) = error;
    *iter = (int) it;
}



void LibOReal_NewtonRaphson(ORealPtr res,  int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_bin_float_oct guess = *(cpp_bin_float_oct*)guess_;
    cpp_bin_float_oct xmin = *(cpp_bin_float_oct*)xmin_;
    cpp_bin_float_oct xmax = *(cpp_bin_float_oct*)xmax_;
    uintmax_t it = maxit;
    cpp_bin_float_oct result = newton_raphson_iterate(ORealFunctor2(f1, f2), guess, xmin, xmax, get_digits, it);
    (*(cpp_bin_float_oct*)res) = result;
    *iter = (int) it;
}



void LibOReal_Halley(ORealPtr res, int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_bin_float_oct guess = *(cpp_bin_float_oct*)guess_;
    cpp_bin_float_oct xmin = *(cpp_bin_float_oct*)xmin_;
    cpp_bin_float_oct xmax = *(cpp_bin_float_oct*)xmax_;
    uintmax_t it = maxit;
    cpp_bin_float_oct result = halley_iterate(ORealFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
    (*(cpp_bin_float_oct*)res) = result;
    *iter = (int) it;
}



void LibOReal_Schroder(ORealPtr res, int* iter, ORealFuncPtr f1, ORealFuncPtr f2, ORealFuncPtr f3, ORealPtr guess_, ORealPtr xmin_, ORealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_bin_float_oct guess = *(cpp_bin_float_oct*)guess_;
    cpp_bin_float_oct xmin = *(cpp_bin_float_oct*)xmin_;
    cpp_bin_float_oct xmax = *(cpp_bin_float_oct*)xmax_;
    uintmax_t it = maxit;
    cpp_bin_float_oct result = schroder_iterate(ORealFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
    (*(cpp_bin_float_oct*)res) = result;
    *iter = (int) it;
}



void LibOReal_Brent_Minimum(ORealPtr res, ORealPtr resFx, int* iter, ORealFuncPtr f1, ORealPtr bracket_min_, ORealPtr bracket_max_, int bits, unsigned int maxit)
{
    cpp_bin_float_oct bracket_min = *(cpp_bin_float_oct*)bracket_min_;
    cpp_bin_float_oct bracket_max = *(cpp_bin_float_oct*)bracket_max_;
    uintmax_t it = maxit;
    std::pair<cpp_bin_float_oct, cpp_bin_float_oct> r = brent_find_minima(ORealFunctor1(f1), bracket_min, bracket_max, bits, it);
    (*(cpp_bin_float_oct*)res) = r.first;
    (*(cpp_bin_float_oct*)resFx) = r.second;
    *iter = (int) it;
}





void LibOReal_Trapezoidal(ORealPtr res1, ORealPtr res2, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_)
{
    cpp_bin_float_oct a = *(cpp_bin_float_oct*)a_;
    cpp_bin_float_oct b = *(cpp_bin_float_oct*)b_;
    cpp_bin_float_oct tol = sqrt(std::numeric_limits<cpp_bin_float_oct>::epsilon());
    cpp_bin_float_oct error;
    cpp_bin_float_oct L1;
    size_t max_refinements = 24;
    auto f = [&f1](cpp_bin_float_oct x) {
        cpp_bin_float_oct fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_bin_float_oct result = trapezoidal(f, a, b, tol, max_refinements, &error, &L1);
    (*(cpp_bin_float_oct*)res1) = result;
    (*(cpp_bin_float_oct*)res2) = error;
    (*(cpp_bin_float_oct*)res3) = (L1/fabs(result));
}



// 7, 15, 20, 25 and 30

void LibOReal_GaussLegendre(ORealPtr res1, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_)
{
    cpp_bin_float_oct a = *(cpp_bin_float_oct*)a_;
    cpp_bin_float_oct b = *(cpp_bin_float_oct*)b_;
    cpp_bin_float_oct L1;
    auto f = [&f1](cpp_bin_float_oct x) {
        cpp_bin_float_oct fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_bin_float_oct result = gauss<cpp_bin_float_oct, 7>::integrate(f, a, b, &L1);
    (*(cpp_bin_float_oct*)res1) = result;
    (*(cpp_bin_float_oct*)res3) = (L1/fabs(result));
}



//15, 31, 41, 51 and 61

void LibOReal_GaussKronrod(ORealPtr res1, ORealPtr res2, ORealPtr res3, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_)
{
    cpp_bin_float_oct a = *(cpp_bin_float_oct*)a_;
    cpp_bin_float_oct b = *(cpp_bin_float_oct*)b_;
    cpp_bin_float_oct tol = sqrt(std::numeric_limits<cpp_bin_float_oct>::epsilon());
    cpp_bin_float_oct error;
    cpp_bin_float_oct L1;
    unsigned max_depth = 15;
    auto f = [&f1](cpp_bin_float_oct x) {
        cpp_bin_float_oct fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_bin_float_oct result = gauss_kronrod<cpp_bin_float_oct, 15>::integrate(f, a, b, max_depth, tol, &error, &L1);
    (*(cpp_bin_float_oct*)res1) = result;
    (*(cpp_bin_float_oct*)res2) = error;
    (*(cpp_bin_float_oct*)res3) = (L1/fabs(result));
}



void LibOReal_TanhSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1, ORealPtr a_, ORealPtr b_)
{
    cpp_bin_float_oct a = *(cpp_bin_float_oct*)a_;
    cpp_bin_float_oct b = *(cpp_bin_float_oct*)b_;
    tanh_sinh<cpp_bin_float_oct> integrator;
    auto f = [&f1](cpp_bin_float_oct x) {
        cpp_bin_float_oct fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_bin_float_oct termination = sqrt(std::numeric_limits<cpp_bin_float_oct>::epsilon());
    cpp_bin_float_oct  error;
    cpp_bin_float_oct  L1;
    std::size_t levels = 0;
    cpp_bin_float_oct result = integrator.integrate(f, a, b, termination, &error, &L1, &levels);
    (*(cpp_bin_float_oct*)res1) = result;
    (*(cpp_bin_float_oct*)res2) = error;
    (*(cpp_bin_float_oct*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}




void LibOReal_SinhSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1)
{
    sinh_sinh<cpp_bin_float_oct> integrator;
    auto f = [&f1](cpp_bin_float_oct x) {
        cpp_bin_float_oct fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_bin_float_oct termination = sqrt(std::numeric_limits<cpp_bin_float_oct>::epsilon());
    cpp_bin_float_oct  error;
    cpp_bin_float_oct  L1;
    std::size_t levels = 0;
    cpp_bin_float_oct result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*(cpp_bin_float_oct*)res1) = result;
    (*(cpp_bin_float_oct*)res2) = error;
    (*(cpp_bin_float_oct*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}



void LibOReal_ExpSinh(ORealPtr res1, ORealPtr res2, ORealPtr res3, int* levels_, ORealFuncPtr f1)
{
    exp_sinh<cpp_bin_float_oct> integrator;
    auto f = [&f1](cpp_bin_float_oct x) {
        cpp_bin_float_oct fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_bin_float_oct termination = sqrt(std::numeric_limits<cpp_bin_float_oct>::epsilon());
    cpp_bin_float_oct  error;
    cpp_bin_float_oct  L1;
    std::size_t levels = 0;
    cpp_bin_float_oct result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*(cpp_bin_float_oct*)res1) = result;
    (*(cpp_bin_float_oct*)res2) = error;
    (*(cpp_bin_float_oct*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}



void LibOReal_Ooura_Cos(ORealPtr res1, ORealPtr res2, ORealFuncPtr f1)
{
    cpp_bin_float_oct omega = 1;
    cpp_bin_float_oct tol = 2 * sqrt(std::numeric_limits<cpp_bin_float_oct>::epsilon());
	auto integrator = ooura_fourier_cos<cpp_bin_float_oct>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](cpp_bin_float_oct x) {
        cpp_bin_float_oct fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<cpp_bin_float_oct, cpp_bin_float_oct> r = integrator.integrate(f, omega);
    (*(cpp_bin_float_oct*)res1) =  r.first;
    (*(cpp_bin_float_oct*)res2) =  r.second;
}



void LibOReal_Ooura_Sin(ORealPtr res1, ORealPtr res2, ORealFuncPtr f1)
{
    cpp_bin_float_oct omega = 1;
    cpp_bin_float_oct tol = 2 * sqrt(std::numeric_limits<cpp_bin_float_oct>::epsilon());
	auto integrator = ooura_fourier_sin<cpp_bin_float_oct>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](cpp_bin_float_oct x) {
        cpp_bin_float_oct fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<cpp_bin_float_oct, cpp_bin_float_oct> r = integrator.integrate(f, omega);
    (*(cpp_bin_float_oct*)res1) =  r.first;
    (*(cpp_bin_float_oct*)res2) =  r.second;
}




//***********************  Boost Distributions, OReal  **********************************


void LibOReal_ArcsineDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b)
{
    cpp_bin_float_oct a1 = *(cpp_bin_float_oct*)a;
    cpp_bin_float_oct b1 = *(cpp_bin_float_oct*)b;
    arcsine_distribution<cpp_bin_float_oct> dist(a1, b1); MP_DIST_RETURN
}



void LibOReal_BernoulliDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr p)
{
    cpp_bin_float_oct p1 = *(cpp_bin_float_oct*)p;
    bernoulli_distribution<cpp_bin_float_oct> dist(p1); MP_DIST_RETURN
}



void LibOReal_BetaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b)
{
    cpp_bin_float_oct a1 = *(cpp_bin_float_oct*)a;
    cpp_bin_float_oct b1 = *(cpp_bin_float_oct*)b;
    beta_distribution<cpp_bin_float_oct> dist(a1, b1); MP_DIST_RETURN
}



void LibOReal_BinomialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n, ORealPtr p)
{
    cpp_bin_float_oct n1 = *(cpp_bin_float_oct*)n;
    cpp_bin_float_oct p1 = *(cpp_bin_float_oct*)p;
    binomial_distribution<cpp_bin_float_oct> dist(n1, p1); MP_DIST_RETURN
}



void LibOReal_CauchyDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    cpp_bin_float_oct location1 = *(cpp_bin_float_oct*)location;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    cauchy_distribution<cpp_bin_float_oct> dist(location1, scale1); MP_DIST_RETURN
}



void LibOReal_Chi2Dist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    chi_squared_distribution<cpp_bin_float_oct> dist(nu1); MP_DIST_RETURN
}



void LibOReal_ExponentialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lambda)
{
    cpp_bin_float_oct lambda1 = *(cpp_bin_float_oct*)lambda;
    exponential_distribution<cpp_bin_float_oct> dist(lambda1); MP_DIST_RETURN
}



void LibOReal_ExtremeValueDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    cpp_bin_float_oct location1 = *(cpp_bin_float_oct*)location;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    extreme_value_distribution<cpp_bin_float_oct> dist(location1, scale1); MP_DIST_RETURN
}



void LibOReal_FisherFDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mu, ORealPtr nu)
{
    cpp_bin_float_oct mu1 = *(cpp_bin_float_oct*)mu;
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    fisher_f_distribution<cpp_bin_float_oct> dist(mu1, nu1); MP_DIST_RETURN
}



void LibOReal_GammaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale)
{
    cpp_bin_float_oct shape1 = *(cpp_bin_float_oct*)shape;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    gamma_distribution<cpp_bin_float_oct> dist(shape1, scale1); MP_DIST_RETURN
}



void LibOReal_GeometricDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr p)
{
    cpp_bin_float_oct p1 = *(cpp_bin_float_oct*)p;
    geometric_distribution<cpp_bin_float_oct> dist(p1); MP_DIST_RETURN
}



void LibOReal_HypergeometricDist(long Target, ORealPtr res, ORealPtr xqp, uint64_t r, uint64_t n, uint64_t N)
{
    hypergeometric_distribution<cpp_bin_float_oct> dist(r, n, N); MP_DIST_RETURN
}



void LibOReal_InverseChi2Dist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr df, ORealPtr scale)
{
    cpp_bin_float_oct df1 = *(cpp_bin_float_oct*)df;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    inverse_chi_squared_distribution<cpp_bin_float_oct> dist(df1, scale1); MP_DIST_RETURN
}



void LibOReal_InverseGammaDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale)
{
    cpp_bin_float_oct shape1 = *(cpp_bin_float_oct*)shape;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    inverse_gamma_distribution<cpp_bin_float_oct> dist(shape1, scale1); MP_DIST_RETURN
}



void LibOReal_InverseGaussianDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr scale)
{
    cpp_bin_float_oct mean1 = *(cpp_bin_float_oct*)mean_;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    inverse_gaussian_distribution<cpp_bin_float_oct> dist(mean1, scale1); MP_DIST_RETURN
}



void LibOReal_LaplaceDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    cpp_bin_float_oct location1 = *(cpp_bin_float_oct*)location;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    laplace_distribution<cpp_bin_float_oct> dist(location1, scale1); MP_DIST_RETURN
}



void LibOReal_LogisticDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    cpp_bin_float_oct location1 = *(cpp_bin_float_oct*)location;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    logistic_distribution<cpp_bin_float_oct> dist(location1, scale1); MP_DIST_RETURN
}



void LibOReal_LognormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr location, ORealPtr scale)
{
    cpp_bin_float_oct location1 = *(cpp_bin_float_oct*)location;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    lognormal_distribution<cpp_bin_float_oct> dist(location1, scale1); MP_DIST_RETURN
}



void LibOReal_NegBinomialDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr n, ORealPtr p)
{
    cpp_bin_float_oct n1 = *(cpp_bin_float_oct*)n;
    cpp_bin_float_oct p1 = *(cpp_bin_float_oct*)p;
    negative_binomial_distribution<cpp_bin_float_oct> dist(n1, p1); MP_DIST_RETURN
}


void LibOReal_Chi2NCDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu, ORealPtr nc)
{
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    cpp_bin_float_oct nc1 = *(cpp_bin_float_oct*)nc;
    non_central_chi_squared_distribution<cpp_bin_float_oct> dist(nu1, nc1); MP_DIST_RETURN
}


void LibOReal_StudentTNCDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu, ORealPtr delta)
{
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    cpp_bin_float_oct delta1 = *(cpp_bin_float_oct*)delta;
    non_central_t_distribution<cpp_bin_float_oct> dist(nu1, delta1); MP_DIST_RETURN
}



void LibOReal_FisherNCDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mu, ORealPtr nu, ORealPtr nc)
{
    cpp_bin_float_oct mu1 = *(cpp_bin_float_oct*)mu;
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    cpp_bin_float_oct nc1 = *(cpp_bin_float_oct*)nc;
    non_central_f_distribution<cpp_bin_float_oct> dist(mu1, nu1, nc1); MP_DIST_RETURN
}



void LibOReal_BetaNCDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr a, ORealPtr b, ORealPtr nc)
{
    cpp_bin_float_oct a1 = *(cpp_bin_float_oct*)a;
    cpp_bin_float_oct b1 = *(cpp_bin_float_oct*)b;
    cpp_bin_float_oct nc1 = *(cpp_bin_float_oct*)nc;
    non_central_beta_distribution<cpp_bin_float_oct> dist(a1, b1, nc1); MP_DIST_RETURN
}



void LibOReal_NormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr stdev)
{
    cpp_bin_float_oct mean1 = *(cpp_bin_float_oct*)mean_;
    cpp_bin_float_oct stdev1 = *(cpp_bin_float_oct*)stdev;
    normal_distribution<cpp_bin_float_oct> dist(mean1, stdev1); MP_DIST_RETURN
}



void LibOReal_ParetoDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale)
{
    cpp_bin_float_oct shape1 = *(cpp_bin_float_oct*)shape;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    pareto_distribution<cpp_bin_float_oct> dist(shape1, scale1); MP_DIST_RETURN
}



void LibOReal_PoissonDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    poisson_distribution<cpp_bin_float_oct> dist(nu1); MP_DIST_RETURN
}



void LibOReal_RayleighDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    rayleigh_distribution<cpp_bin_float_oct> dist(nu1); MP_DIST_RETURN
}



void LibOReal_SkewNormalDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr mean_, ORealPtr scale, ORealPtr shape)
{
    cpp_bin_float_oct mean1 = *(cpp_bin_float_oct*)mean_;
    cpp_bin_float_oct shape1 = *(cpp_bin_float_oct*)shape;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    skew_normal_distribution<cpp_bin_float_oct> dist(mean1, scale1, shape1); MP_DIST_RETURN
}



void LibOReal_StudentTDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    students_t_distribution<cpp_bin_float_oct> dist(nu1); MP_DIST_RETURN
}



void LibOReal_TriangularDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lower, ORealPtr mode_, ORealPtr upper)
{
    cpp_bin_float_oct lower1 = *(cpp_bin_float_oct*)lower;
    cpp_bin_float_oct mode1 = *(cpp_bin_float_oct*)mode_;
    cpp_bin_float_oct upper1 = *(cpp_bin_float_oct*)upper;
    triangular_distribution<cpp_bin_float_oct> dist(lower1, mode1, upper1); MP_DIST_RETURN
}



void LibOReal_WeibullDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr shape, ORealPtr scale)
{
    cpp_bin_float_oct shape1 = *(cpp_bin_float_oct*)shape;
    cpp_bin_float_oct scale1 = *(cpp_bin_float_oct*)scale;
    weibull_distribution<cpp_bin_float_oct> dist(shape1, scale1); MP_DIST_RETURN
}



void LibOReal_UniformDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr lower, ORealPtr upper)
{
    cpp_bin_float_oct lower1 = *(cpp_bin_float_oct*)lower;
    cpp_bin_float_oct upper1 = *(cpp_bin_float_oct*)upper;
    uniform_distribution<cpp_bin_float_oct> dist(lower1, upper1); MP_DIST_RETURN
}



//*********************** New , octuple precision **********************************




void LibOReal_Logaddexp(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
	(*(cpp_bin_float_oct*)res) = logaddexp(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b));
}


void LibOReal_KolmogorovSmirnovDist(long Target, ORealPtr res, ORealPtr xqp, ORealPtr nu)
{
    cpp_bin_float_oct nu1 = *(cpp_bin_float_oct*)nu;
    kolmogorov_smirnov_distribution<cpp_bin_float_oct> dist(nu1); MP_DIST_RETURN
}



void LibOReal_HyperexponentialDist(long Target, ORealPtr res, ORealPtr xqp, OStatePtr l1, OStatePtr l2)
{
    hyperexponential_distribution<cpp_bin_float_oct> dist( *(state_type_vec*) l1, *(state_type_vec*) l2); MP_DIST_RETURN
}








//*********************** Boost Special functions , OReal **********************************




void LibOReal_Ulp(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = ulp(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_BernoulliB2n(ORealPtr res, const int n)
{
	(*(cpp_bin_float_oct*)res) = bernoulli_b2n<cpp_bin_float_oct>(n);
}



void LibOReal_TangentT2n(ORealPtr res, const int n)
{
	(*(cpp_bin_float_oct*)res) = tangent_t2n<cpp_bin_float_oct>(n);
}



void LibOReal_Sqrt1pm1(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sqrt1pm1(*(cpp_bin_float_oct*)x);
}



void LibOReal_SinPi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sin_pi(*(cpp_bin_float_oct*)x);
}

void LibOReal_CosPi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cos_pi(*(cpp_bin_float_oct*)x);
}

void LibOReal_TanPi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sin_pi(*(cpp_bin_float_oct*)x) / cos_pi(*(cpp_bin_float_oct*)x);
}



void LibOReal_CscPi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (1.0) / sin_pi(*(cpp_bin_float_oct*)x);
}

void LibOReal_SecPi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (1.0) / cos_pi(*(cpp_bin_float_oct*)x);
}

void LibOReal_CotPi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cos_pi(*(cpp_bin_float_oct*)x) / sin_pi(*(cpp_bin_float_oct*)x);
}




void LibOReal_SincPi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sinc_pi(*(cpp_bin_float_oct*)x);
}



void LibOReal_SinhcPi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sinhc_pi(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Tgamma_(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = tgamma(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_Tgamma1pm1(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = tgamma1pm1(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Lgamma_(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = lgamma(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Digamma(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = digamma(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Trigamma(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = trigamma(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Factorial(ORealPtr res, const ORealPtr x)
{
    cpp_bin_float_oct xt = cpp_bin_float_oct(*(cpp_bin_float_oct*)x);
    cpp_bin_float_oct result = tgamma(xt + 1);
	(*(cpp_bin_float_oct*)res) = result;
}



void LibOReal_DoubleFactorial(ORealPtr res, const ORealPtr x)
{
    cpp_bin_float_oct xt = cpp_bin_float_oct(*(cpp_bin_float_oct*)x);
    cpp_bin_float_oct xt2 = xt/2;
    cpp_bin_float_oct t1 = (cos_pi(xt)-1)/4;
    cpp_bin_float_oct pi2 = constants::half_pi<cpp_bin_float_oct>();
    cpp_bin_float_oct t2 = pow(pi2, t1);
    cpp_bin_float_oct result = exp2(xt2) * t2 * tgamma(xt2+1);
	(*(cpp_bin_float_oct*)res) = result;
}





void LibOReal_Erf_(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = erf(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Erfc_(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = erfc(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Erf_inv(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = erf_inv(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Erfc_inv(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = erfc_inv(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_AiryAi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = airy_ai(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_AiryBi(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = airy_bi(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_AiryAiPrime(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = airy_ai_prime(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_AiryBiPrime(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = airy_bi_prime(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Aizero(ORealPtr res, const int n)
{
	(*(cpp_bin_float_oct*)res) = airy_ai_zero<cpp_bin_float_oct>(n);
}



void LibOReal_Bizero(ORealPtr res, const int n)
{
	(*(cpp_bin_float_oct*)res) = airy_bi_zero<cpp_bin_float_oct>(n);
}



void LibOReal_Ellint_1_K(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = ellint_1(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Ellint_2_K(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = ellint_2(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Zeta(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = zeta(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Ei(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = expint(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_LambertW0(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = lambert_w0(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_LambertWm1(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = lambert_wm1(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_LambertW0Prime(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = lambert_w0_prime(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_LambertWm1Prime(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = lambert_wm1_prime(cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void LibOReal_Agm(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
	(*(cpp_bin_float_oct*)res) = agm(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b));
}




void LibOReal_Powm1(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
	(*(cpp_bin_float_oct*)res) = powm1(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b));
}



void LibOReal_TgammaRatio(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
	(*(cpp_bin_float_oct*)res) = tgamma_ratio(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b));
}



void LibOReal_TgammaDeltaRatio(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
	(*(cpp_bin_float_oct*)res) = tgamma_delta_ratio(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b));
}



void LibOReal_Binomial(ORealPtr res, const ORealPtr n, const ORealPtr k)
{
    cpp_bin_float_oct nt = cpp_bin_float_oct(*(cpp_bin_float_oct*)n);
    cpp_bin_float_oct kt = cpp_bin_float_oct(*(cpp_bin_float_oct*)k);
    cpp_bin_float_oct result = tgamma(nt+1) / ( tgamma(kt+1) * tgamma(nt-kt+1) );
	(*(cpp_bin_float_oct*)res) = result;
}

void LibOReal_RisingFactorial(ORealPtr res, const ORealPtr x, const ORealPtr n)
{
    cpp_bin_float_oct xt = cpp_bin_float_oct(*(cpp_bin_float_oct*)x);
    cpp_bin_float_oct nt = cpp_bin_float_oct(*(cpp_bin_float_oct*)n);
    cpp_bin_float_oct result = tgamma(xt+nt) / tgamma(xt);
	(*(cpp_bin_float_oct*)res) = result;
}




void LibOReal_FallingFactorial(ORealPtr res, const ORealPtr x, const ORealPtr n)
{
    cpp_bin_float_oct xt = cpp_bin_float_oct(*(cpp_bin_float_oct*)x);
    cpp_bin_float_oct nt = cpp_bin_float_oct(*(cpp_bin_float_oct*)n);
    cpp_bin_float_oct result = tgamma(xt+1) / tgamma(xt-nt+1);
	(*(cpp_bin_float_oct*)res) = result;
}




void LibOReal_BesselJ(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cyl_bessel_j(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_BesselY(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cyl_neumann(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_BesselI(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cyl_bessel_i(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_BesselK(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cyl_bessel_k(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_SphBessel(ORealPtr res, const unsigned v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sph_bessel(v, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_SphNeumann(ORealPtr res, const unsigned v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sph_neumann(v, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}





void LibOReal_BesselJPrime(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cyl_bessel_j_prime(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_BesselYPrime(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cyl_neumann_prime(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_BesselIPrime(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cyl_bessel_i_prime(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_BesselKPrime(ORealPtr res, const ORealPtr v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cyl_bessel_k_prime(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_SphBesselPrime(ORealPtr res, const unsigned v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sph_bessel_prime(v, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_SphNeumannPrime(ORealPtr res, const unsigned v, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sph_neumann_prime(v, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}





void LibOReal_BesselJZero(ORealPtr res, const ORealPtr v, const int m)
{
	(*(cpp_bin_float_oct*)res) = cyl_bessel_j_zero(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), m);
}



void LibOReal_BesselYZero(ORealPtr res, const ORealPtr v, const int m)
{
	(*(cpp_bin_float_oct*)res) = cyl_neumann_zero(cpp_bin_float_oct(*(cpp_bin_float_oct*)v), m);
}





void LibOReal_GammaP(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = gamma_p(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_GammaQ(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = gamma_q(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_TgammaLower(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = tgamma_lower(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_TgammaUpper(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = tgamma(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}




void LibOReal_GammaPInv(ORealPtr res, const ORealPtr a, const ORealPtr p)
{
	(*(cpp_bin_float_oct*)res) = gamma_p_inv(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)p));
}


void LibOReal_GammaQInv(ORealPtr res, const ORealPtr a, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = gamma_q_inv(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}


void LibOReal_GammaPInva(ORealPtr res, const ORealPtr x, const ORealPtr p)
{
	(*(cpp_bin_float_oct*)res) = gamma_p_inva(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)p));
}


void LibOReal_GammaQInva(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = gamma_q_inva(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}



void LibOReal_GammaPDerivative(ORealPtr res, const ORealPtr a, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = gamma_p_derivative(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_Beta(ORealPtr res, const ORealPtr a, const ORealPtr b)
{
	(*(cpp_bin_float_oct*)res) = beta(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b));
}









void LibOReal_LegendreP(ORealPtr res, int n, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = legendre_p(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_LegendreQ(ORealPtr res, int n, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = legendre_q(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Laguerre(ORealPtr res, int n, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = laguerre(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Hermite(ORealPtr res, int n, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = hermite(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_ChebyshevT(ORealPtr res, int n, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = chebyshev_t(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_ChebyshevU(ORealPtr res, int n, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = chebyshev_u(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Polygamma(ORealPtr res, int n, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = polygamma(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}





void LibOReal_EllintRC(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = ellint_rc(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)y));
}


void LibOReal_Ellint1F(ORealPtr res, const ORealPtr k, const ORealPtr phi)
{
	(*(cpp_bin_float_oct*)res) = ellint_1(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)phi));
}


void LibOReal_Ellint2F(ORealPtr res, const ORealPtr k, const ORealPtr phi)
{
	(*(cpp_bin_float_oct*)res) = ellint_2(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)phi));
}


void LibOReal_Ellint3K(ORealPtr res, const ORealPtr k, const ORealPtr n)
{
	(*(cpp_bin_float_oct*)res) = ellint_3(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)n));
}




void LibOReal_JacobiCD(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_cd(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiCN(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_cn(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiCS(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_cs(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiDC(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_dc(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiDN(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_dn(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiDS(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_ds(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiNC(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_nc(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiND(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_nd(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiNS(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_ns(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiSC(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_sc(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiSD(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_sd(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}


void LibOReal_JacobiSN(ORealPtr res, const ORealPtr k, const ORealPtr u)
{
	(*(cpp_bin_float_oct*)res) = jacobi_sn(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)u));
}



void LibOReal_expint(ORealPtr res, const unsigned n, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = expint(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}




void LibOReal_OwenT(ORealPtr res, const ORealPtr h, const ORealPtr a)
{
	(*(cpp_bin_float_oct*)res) = owens_t(cpp_bin_float_oct(*(cpp_bin_float_oct*)h), cpp_bin_float_oct(*(cpp_bin_float_oct*)a));
}





void LibOReal_IBeta(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = ibeta(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_IBetac(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = ibetac(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_IBetaNonNormalized(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = beta(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_IBetacNonNormalized(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = betac(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}


void LibOReal_IBetaInv(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr p)
{
	(*(cpp_bin_float_oct*)res) = ibeta_inv(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)p));
}


void LibOReal_IBetacInv(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = ibetac_inv(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}


void LibOReal_IBetaInva(ORealPtr res, const ORealPtr b, const ORealPtr x, const ORealPtr p)
{
	(*(cpp_bin_float_oct*)res) = ibeta_inva(cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)p));
}


void LibOReal_IBetacInva(ORealPtr res, const ORealPtr b, const ORealPtr x, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = ibetac_inva(cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}


void LibOReal_IBetaInvb(ORealPtr res, const ORealPtr a, const ORealPtr x, const ORealPtr p)
{
	(*(cpp_bin_float_oct*)res) = ibeta_invb(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)p));
}


void LibOReal_IBetacInvb(ORealPtr res, const ORealPtr a, const ORealPtr x, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = ibetac_invb(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}


void LibOReal_IBetaDerivative(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = ibeta_derivative(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}




void LibOReal_LegendrePM(ORealPtr res, const int n, const int m, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = legendre_p(n, m, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_LaguerreM(ORealPtr res, const int n, const int m, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = laguerre(n, m, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}





void LibOReal_EllipticRF(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z)
{
	(*(cpp_bin_float_oct*)res) = ellint_rf(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)y), cpp_bin_float_oct(*(cpp_bin_float_oct*)z));
}



void LibOReal_EllipticRD(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z)
{
	(*(cpp_bin_float_oct*)res) = ellint_rd(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)y), cpp_bin_float_oct(*(cpp_bin_float_oct*)z));
}



void LibOReal_EllipticRG(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z)
{
	(*(cpp_bin_float_oct*)res) = ellint_rg(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)y), cpp_bin_float_oct(*(cpp_bin_float_oct*)z));
}



void LibOReal_Ellint3F(ORealPtr res, const ORealPtr k, const ORealPtr n, const ORealPtr phi)
{
	(*(cpp_bin_float_oct*)res) = ellint_3(cpp_bin_float_oct(*(cpp_bin_float_oct*)k), cpp_bin_float_oct(*(cpp_bin_float_oct*)n), cpp_bin_float_oct(*(cpp_bin_float_oct*)phi));
}





void LibOReal_Gegenbauer(ORealPtr res, const int n, const ORealPtr lambda, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = gegenbauer(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)lambda), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}




void LibOReal_Jacobi(ORealPtr res, const int n, const ORealPtr alpha, const ORealPtr beta, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = jacobi(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)alpha), cpp_bin_float_oct(*(cpp_bin_float_oct*)beta), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}




void LibOReal_SphericalHarmonicR(ORealPtr res, const int n, const int m, const ORealPtr theta, const ORealPtr phi)
{
	(*(cpp_bin_float_oct*)res) = spherical_harmonic_r(n, m, cpp_bin_float_oct(*(cpp_bin_float_oct*)theta), cpp_bin_float_oct(*(cpp_bin_float_oct*)phi));
}


void LibOReal_SphericalHarmonicI(ORealPtr res, const int n, const int m, const ORealPtr theta, const ORealPtr phi)
{
	(*(cpp_bin_float_oct*)res) = spherical_harmonic_i(n, m, cpp_bin_float_oct(*(cpp_bin_float_oct*)theta), cpp_bin_float_oct(*(cpp_bin_float_oct*)phi));
}


void LibOReal_EllipticRJ(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z, const ORealPtr p)
{
	(*(cpp_bin_float_oct*)res) = ellint_rj(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)y), cpp_bin_float_oct(*(cpp_bin_float_oct*)z), cpp_bin_float_oct(*(cpp_bin_float_oct*)p));
}


// Hypergeometric and Theta Functions




void LibOReal_Hypergeo0F1(ORealPtr res, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = hypergeometric_0F1(cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Hypergeo1F1(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = hypergeometric_1F1(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_Hypergeo1F1r(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = hypergeometric_1F1_regularized(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}



void LibOReal_LogHypergeo1F1(ORealPtr res, const ORealPtr a, const ORealPtr b, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = log_hypergeometric_1F1(cpp_bin_float_oct(*(cpp_bin_float_oct*)a), cpp_bin_float_oct(*(cpp_bin_float_oct*)b), cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}





void LibOReal_JacobiTheta1(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = jacobi_theta1(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}


void LibOReal_JacobiTheta2(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = jacobi_theta2(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}


void LibOReal_JacobiTheta3(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = jacobi_theta3(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}


void LibOReal_JacobiTheta4(ORealPtr res, const ORealPtr x, const ORealPtr q)
{
	(*(cpp_bin_float_oct*)res) = jacobi_theta4(cpp_bin_float_oct(*(cpp_bin_float_oct*)x), cpp_bin_float_oct(*(cpp_bin_float_oct*)q));
}












//*********************** Real **********************************


ORealPtr LibOReal_Init_Func()
{
	ORealPtr x = NULL;
	x = (cpp_bin_float_oct*)malloc(sizeof(cpp_bin_float_oct));
	*(cpp_bin_float_oct*)x = 0;
	return x;
}


void LibOReal_Clear(ORealPtr x)
{
	free(x);
}


void LibOReal_Get_Str(char* cstr, ORealPtr x)
{
    cpp_bin_float_oct d = *(cpp_bin_float_oct*)x;
    std::stringstream ss;
    //ss.precision(std::numeric_limits<cpp_bin_float_oct>::digits10+2);
    ss.precision(std::numeric_limits<cpp_bin_float_oct>::digits10+0);
    //ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void LibOReal_Get_HexStr(char* cstr, ORealPtr x)
{
    cpp_bin_float_oct d = *(cpp_bin_float_oct*)x;
    std::stringstream ss;
    ss.precision(20);
    //ss.precision(std::numeric_limits<cpp_bin_float_oct>::digits10+2);
    //ss << std::showpoint; // Append any trailing zeros.
    ss << std::hexfloat; // using hexadecimal format.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}





void LibOReal_Set_Str(ORealPtr res, const char * str)
{

    (*(cpp_bin_float_oct*)res) = static_cast<cpp_bin_float_oct>(string(str));
}




void LibOReal_Set(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x);
}



void LibOReal_Neg(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = -(*(cpp_bin_float_oct*)x);
}


void LibOReal_Set_S(ORealPtr res, const float* x)
{
	(*(cpp_bin_float_oct*)res) = *x;
}


void LibOReal_Set_D(ORealPtr res, const double x)
{
	(*(cpp_bin_float_oct*)res) = x;
}


void LibOReal_Set_LD(ORealPtr res, const long double* x)
{
	(*(cpp_bin_float_oct*)res) = *x;
}





void LibOReal_Get_S(float* res, const ORealPtr x)
{
	*res = (float)(*(cpp_bin_float_oct*)x);
}


void LibOReal_Get_D(double* res, const ORealPtr x)
{
	*res = (double)(*(cpp_bin_float_oct*)x);
}


void LibOReal_Get_LD(long double* res, const ORealPtr x)
{
	*res = (long double)(*(cpp_bin_float_oct*)x);
}



void LibOReal_Set_Si(ORealPtr res, const int32_t x)
{
	(*(cpp_bin_float_oct*)res) = x;
}



void LibOReal_Set_Si64(ORealPtr res, const int64_t x)
{
	(*(cpp_bin_float_oct*)res) = x;
}



void LibOReal_Set_Ui(ORealPtr res, const uint32_t x)
{
	(*(cpp_bin_float_oct*)res) = x;
}



void LibOReal_Set_Ui64(ORealPtr res, const uint64_t x)
{
	(*(cpp_bin_float_oct*)res) = x;
}









void LibOReal_Add(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) + (*(cpp_bin_float_oct*)y);
}


void LibOReal_Sub(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) - (*(cpp_bin_float_oct*)y);
}



void LibOReal_Mul(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) * (*(cpp_bin_float_oct*)y);
}



void LibOReal_Div(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) / (*(cpp_bin_float_oct*)y);
}








void LibOReal_Add_D(ORealPtr res, const ORealPtr x, const double y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) + y;
}


void LibOReal_Sub_D(ORealPtr res, const ORealPtr x, const double y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) - y;
}


void LibOReal_D_Sub(ORealPtr res, const ORealPtr x, const double y)
{
	(*(cpp_bin_float_oct*)res) = y - (*(cpp_bin_float_oct*)x);
}


void LibOReal_Mul_D(ORealPtr res, const ORealPtr x, const double y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) * y;
}


void LibOReal_Div_D(ORealPtr res, const ORealPtr x, const double y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) / y;
}


void LibOReal_D_Div(ORealPtr res, const ORealPtr x, const double y)
{
	(*(cpp_bin_float_oct*)res) = y / (*(cpp_bin_float_oct*)x);
}









void LibOReal_Add_Si(ORealPtr res, const ORealPtr x, const int32_t y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) + y;
}


void LibOReal_Sub_Si(ORealPtr res, const ORealPtr x, const int32_t y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) - y;
}


void LibOReal_Si_Sub(ORealPtr res, const ORealPtr x, const int32_t y)
{
	(*(cpp_bin_float_oct*)res) = y - (*(cpp_bin_float_oct*)x);
}


void LibOReal_Mul_Si(ORealPtr res, const ORealPtr x, const int32_t y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) * y;
}


void LibOReal_Div_Si(ORealPtr res, const ORealPtr x, const int32_t y)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) / y;
}


void LibOReal_Si_Div(ORealPtr res, const ORealPtr x, const int32_t y)
{
	(*(cpp_bin_float_oct*)res) = y / (*(cpp_bin_float_oct*)x);
}







int32_t LibOReal_LT(const ORealPtr x, const ORealPtr y)
{
	return (*(cpp_bin_float_oct*)x) < (*(cpp_bin_float_oct*)y);
}


int32_t LibOReal_GE(const ORealPtr x, const ORealPtr y)
{
	return (*(cpp_bin_float_oct*)x) >= (*(cpp_bin_float_oct*)y);
}


int32_t LibOReal_GT(const ORealPtr x, const ORealPtr y)
{
	return (*(cpp_bin_float_oct*)x) > (*(cpp_bin_float_oct*)y);
}


int32_t LibOReal_LE(const ORealPtr x, const ORealPtr y)
{
	return (*(cpp_bin_float_oct*)x) <= (*(cpp_bin_float_oct*)y);
}


int32_t LibOReal_EQ(const ORealPtr x, const ORealPtr y)
{
	return (*(cpp_bin_float_oct*)x) == (*(cpp_bin_float_oct*)y);
}


int32_t LibOReal_NE(const ORealPtr x, const ORealPtr y)
{
	return (*(cpp_bin_float_oct*)x) != (*(cpp_bin_float_oct*)y);
}











/* General functions for real numbers  */


void LibOReal_Fma(ORealPtr res, const ORealPtr x, const ORealPtr y, const ORealPtr z)
{
	(*(cpp_bin_float_oct*)res) = fma( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) , (*(cpp_bin_float_oct*)z) );
}


void LibOReal_Fmax(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = fmax( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}


void LibOReal_Fmin(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = fmin( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}





/* Machine constants */


void LibOReal_Zero(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = 0.0;
}


void LibOReal_NegZero(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = -0.0;
}


void LibOReal_One(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = 1.0;
}


void LibOReal_Inf(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = std::numeric_limits<cpp_bin_float_oct>::infinity();
}


void LibOReal_NegInf(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = -std::numeric_limits<cpp_bin_float_oct>::infinity();
}


void LibOReal_Nan(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = std::numeric_limits<cpp_bin_float_oct>::quiet_NaN();
}






/* Properties of numbers  */

int LibOReal_Signbit(const ORealPtr x)
{
	return signbit(*(cpp_bin_float_oct*)x);
}

int LibOReal_Finite(const ORealPtr x)
{
	return isfinite(*(cpp_bin_float_oct*)x);
}

int LibOReal_Isinf(const ORealPtr x)
{
	return isinf(*(cpp_bin_float_oct*)x);
}

int LibOReal_Isposinf(const ORealPtr x)
{
	return ((isinf(*(cpp_bin_float_oct*)x)) & (*(cpp_bin_float_oct*)x > 0 ));
}

int LibOReal_Isneginf(const ORealPtr x)
{
	return ((isinf(*(cpp_bin_float_oct*)x)) & (*(cpp_bin_float_oct*)x < 0 ));
}

int LibOReal_Isnan(const ORealPtr x)
{
	return isnan(*(cpp_bin_float_oct*)x);
}



int LibOReal_Iszero(const ORealPtr x)
{
	return (abs(*(cpp_bin_float_oct*)x) == 0.0);
}

int LibOReal_Isposzero(const ORealPtr x)
{
	return ((int(signbit(*(cpp_bin_float_oct*)x)) == 0) & (abs(*(cpp_bin_float_oct*)x) == 0.0));
}

int LibOReal_Isnegzero(const ORealPtr x)
{
	return ((int(signbit(*(cpp_bin_float_oct*)x)) != 0) & (abs(*(cpp_bin_float_oct*)x) == 0.0));
}

int LibOReal_Isone(const ORealPtr x)
{
	return (*(cpp_bin_float_oct*)x == 1.0);
}

int LibOReal_Isinteger(const ORealPtr x)
{
	return (ceil(*(cpp_bin_float_oct*)x) == floor(*(cpp_bin_float_oct*)x));
}

int LibOReal_Isnumber(const ORealPtr x)
{
	return (!(isnan(*(cpp_bin_float_oct*)x) || (isinf(*(cpp_bin_float_oct*)x))));
}

int LibOReal_Isregular(const ORealPtr x)
{
	return (!(isnan(*(cpp_bin_float_oct*)x) || (isinf(*(cpp_bin_float_oct*)x) || (abs(*(cpp_bin_float_oct*)x) == 0.0))));
}

int LibOReal_Isnormal(const ORealPtr x)
{
	return (isnormal(*(cpp_bin_float_oct*)x));
}

int LibOReal_Issubnormal(const ORealPtr x)
{
	return (fpclassify(*(cpp_bin_float_oct*)x)) == FP_SUBNORMAL;
}

int LibOReal_Isunordered(const ORealPtr x, const ORealPtr y)
{
	return (isunordered(*(cpp_bin_float_oct*)x, *(cpp_bin_float_oct*)x));
}







int LibOReal_FitsInt32(const ORealPtr x)
{
	return  ((*(cpp_bin_float_oct*)x <= std::numeric_limits<int32_t>::max()) &
             (*(cpp_bin_float_oct*)x >= std::numeric_limits<int32_t>::min()));
}

int LibOReal_FitsInt64(const ORealPtr x)
{
	return  ((*(cpp_bin_float_oct*)x <= std::numeric_limits<int64_t>::max()) &
             (*(cpp_bin_float_oct*)x >= std::numeric_limits<int64_t>::min()));
}

int LibOReal_FitsUInt32(const ORealPtr x)
{
	return  ((*(cpp_bin_float_oct*)x <= std::numeric_limits<uint32_t>::max()) &
             (*(cpp_bin_float_oct*)x >= std::numeric_limits<uint32_t>::min()));
}

int LibOReal_FitsUInt64(const ORealPtr x)
{
	return  ((*(cpp_bin_float_oct*)x <= std::numeric_limits<uint64_t>::max()) &
             (*(cpp_bin_float_oct*)x >= std::numeric_limits<uint64_t>::min()));
}




/* Integer Related Functions  */

void LibOReal_Nearbyint(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = nearbyint(*(cpp_bin_float_oct*)x);
}

void LibOReal_Rint(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = rint(*(cpp_bin_float_oct*)x);
}

long int LibOReal_Lrint(const ORealPtr x)
{
	return lrint(*(cpp_bin_float_oct*)x);
}

long long int LibOReal_Llrint(const ORealPtr x)
{
	return llrint(*(cpp_bin_float_oct*)x);
}

void LibOReal_Ceil(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = ceil(*(cpp_bin_float_oct*)x);
}

void LibOReal_Floor(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = floor(*(cpp_bin_float_oct*)x);
}

void LibOReal_Trunc(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = trunc(*(cpp_bin_float_oct*)x);
}

void LibOReal_Round(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = round(*(cpp_bin_float_oct*)x);
}

long int LibOReal_Lround(const ORealPtr x)
{
	return lround(*(cpp_bin_float_oct*)x);
}

long long int LibOReal_Llround(const ORealPtr x)
{
	return llround(*(cpp_bin_float_oct*)x);
}



int32_t LibOReal_ToInt32(const ORealPtr x)
{
    if (*(cpp_bin_float_oct*)x >= std::numeric_limits<int32_t>::max())
        return std::numeric_limits<int32_t>::max();
    else if (*(cpp_bin_float_oct*)x <= std::numeric_limits<int32_t>::min())
        return std::numeric_limits<int32_t>::min();
    else
        return (int32_t) (*(__float128*)x);
}

int64_t LibOReal_ToInt64(const ORealPtr x)
{
    if (*(cpp_bin_float_oct*)x >= std::numeric_limits<int64_t>::max())
        return std::numeric_limits<int64_t>::max();
    else if (*(cpp_bin_float_oct*)x <= std::numeric_limits<int64_t>::min())
        return std::numeric_limits<int64_t>::min();
    else
        return (int64_t) (*(cpp_bin_float_oct*)x);
}

uint32_t LibOReal_ToUInt32(const ORealPtr x)
{
    if (*(cpp_bin_float_oct*)x >= std::numeric_limits<uint32_t>::max())
        return std::numeric_limits<uint32_t>::max();
    else if (*(cpp_bin_float_oct*)x <= std::numeric_limits<uint32_t>::min())
        return std::numeric_limits<uint32_t>::min();
    else
        return (uint32_t) (*(cpp_bin_float_oct*)x);
}

uint64_t LibOReal_ToUInt64(const ORealPtr x)
{
    if (*(cpp_bin_float_oct*)x >= std::numeric_limits<uint64_t>::max())
        return std::numeric_limits<uint64_t>::max();
    else if (*(cpp_bin_float_oct*)x <= std::numeric_limits<uint64_t>::min())
        return std::numeric_limits<uint64_t>::min();
    else
        return (uint64_t) (*(cpp_bin_float_oct*)x);
}





/* Floating point functions for real numbers */

void LibOReal_Copysign(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = copysign( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}

void LibOReal_Frexp(ORealPtr res, const ORealPtr x, int* e)
{
	(*(cpp_bin_float_oct*)res) = frexp(*(cpp_bin_float_oct*)x, e);
}

void LibOReal_Logb(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = logb(*(cpp_bin_float_oct*)x);
}

int LibOReal_Ilogb(const ORealPtr x)
{
	return ilogb(*(cpp_bin_float_oct*)x);
}

void LibOReal_Ldexp(ORealPtr res, const ORealPtr x, const int e)
{
	(*(cpp_bin_float_oct*)res) = ldexp(*(cpp_bin_float_oct*)x, e);
}

void LibOReal_Scalbn(ORealPtr res, const ORealPtr x, const int e)
{
	(*(cpp_bin_float_oct*)res) = scalbn(*(cpp_bin_float_oct*)x, e);
}

void LibOReal_Scalbln(ORealPtr res, const ORealPtr x, const long int e)
{
	(*(cpp_bin_float_oct*)res) = scalbln(*(cpp_bin_float_oct*)x, e);
}

void LibOReal_Fdim(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = fdim( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}



/* Fraction and Remainder Related Functions  */

void LibOReal_Modf(ORealPtr frac, const ORealPtr x, ORealPtr iptr)
{
	(*(cpp_bin_float_oct*)frac) = modf( (*(cpp_bin_float_oct*)x) , (cpp_bin_float_oct*)iptr );
}

void LibOReal_Fmod(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = fmod( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}

void LibOReal_Remainder(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = remainder( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}

void LibOReal_Remquo(ORealPtr res, const ORealPtr x, const ORealPtr y, int* e)
{
	(*(cpp_bin_float_oct*)res) = remquo( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y), e );
}




/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

void LibOReal_Epsilon(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = std::numeric_limits<cpp_bin_float_oct>::epsilon();
}

void LibOReal_Max(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = std::numeric_limits<cpp_bin_float_oct>::max();
}

void LibOReal_Min(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = std::numeric_limits<cpp_bin_float_oct>::min();
}

void LibOReal_Lowest(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = std::numeric_limits<cpp_bin_float_oct>::lowest();
}

void LibOReal_Nexttowards(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = nextafter( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}

void LibOReal_Nextabove(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = nextafter( (*(cpp_bin_float_oct*)x) , std::numeric_limits<cpp_bin_float_oct>::infinity() );
}

void LibOReal_Nextbelow(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = nextafter( (*(cpp_bin_float_oct*)x) , -std::numeric_limits<cpp_bin_float_oct>::infinity() );
}





/* Complex components  */

void LibOReal_Fabs(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = fabs(*(cpp_bin_float_oct*)x);
}

void LibOReal_Sign(ORealPtr res, const ORealPtr x)
{
    int temp = ((*(cpp_bin_float_oct*)x > 0) - (*(cpp_bin_float_oct*)x < 0));
	(*(cpp_bin_float_oct*)res) = temp;
}





/* Mathematical Constants  */

void LibOReal_Pi(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = constants::pi<cpp_bin_float_oct>();
}

void LibOReal_E(ORealPtr res)
{
	(*(cpp_bin_float_oct*)res) = constants::e<cpp_bin_float_oct>();
}




























/* Roots and related functions  */


void LibOReal_Sqrt(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sqrt(*(cpp_bin_float_oct*)x);
}

// Sqrt1pm1 from Boost


void LibOReal_Rsqrt(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = 1 / sqrt(*(cpp_bin_float_oct*)x);
}


void LibOReal_Cbrt(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cbrt(*(cpp_bin_float_oct*)x);
}


void LibOReal_Root_Si(ORealPtr res, const ORealPtr x, const int32_t k_)
{
    cpp_bin_float_oct k = k_;
	(*(cpp_bin_float_oct*)res) = pow( (*(cpp_bin_float_oct*)x) , (1.0) / k );
}




/* Exponential and related functions  */


void LibOReal_Exp(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = exp(*(cpp_bin_float_oct*)x);
}


void LibOReal_Exp2(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = exp2(*(cpp_bin_float_oct*)x);
}


void LibOReal_Exp10(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = exp( (*(cpp_bin_float_oct*)x) * constants::ln_ten<cpp_bin_float_oct>() );
}


void LibOReal_Expm1(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = expm1(*(cpp_bin_float_oct*)x);
}

void LibOReal_Exp2m1(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = expm1( (*(cpp_bin_float_oct*)x) * constants::ln_two<cpp_bin_float_oct>() );
}

void LibOReal_Exp10m1(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = expm1( (*(cpp_bin_float_oct*)x) * constants::ln_ten<cpp_bin_float_oct>() );
}



/* Logarithms and related functions  */



void LibOReal_Log(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = log(*(cpp_bin_float_oct*)x);
}


void LibOReal_Log2(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = log2(*(cpp_bin_float_oct*)x);
}


void LibOReal_Log10(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = log10(*(cpp_bin_float_oct*)x);
}


void LibOReal_Log1p(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = log1p(*(cpp_bin_float_oct*)x);
}


void LibOReal_Log2p1(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = log1p(*(cpp_bin_float_oct*)x) / constants::ln_two<cpp_bin_float_oct>();
}


void LibOReal_Log10p1(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = log1p(*(cpp_bin_float_oct*)x) / constants::ln_ten<cpp_bin_float_oct>();
}





/* Power functions  */



void LibOReal_Square(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) * (*(cpp_bin_float_oct*)x);
}


void LibOReal_Cube(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (*(cpp_bin_float_oct*)x) * (*(cpp_bin_float_oct*)x) * (*(cpp_bin_float_oct*)x);
}


void LibOReal_Hypot(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = hypot( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}


void LibOReal_Pow(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = pow( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}


// Powm1 from Boost


void LibOReal_Pow1p(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = exp(log1p(*(cpp_bin_float_oct*)x) * (*(cpp_bin_float_oct*)y));
}


void LibOReal_Pow1pm1(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = expm1(log1p(*(cpp_bin_float_oct*)x) * (*(cpp_bin_float_oct*)y));
}


void LibOReal_Pow_Si(ORealPtr res, const ORealPtr x, const int32_t k_)
{
    cpp_bin_float_oct k = k_;
	(*(cpp_bin_float_oct*)res) = pow( (*(cpp_bin_float_oct*)x) , k );
}


void LibOReal_Compound_Si(ORealPtr res, const ORealPtr x, const int32_t k_)
{
    cpp_bin_float_oct k = k_;
	(*(cpp_bin_float_oct*)res) = pow( (1.0) + (*(cpp_bin_float_oct*)x) , k );
}



/* Trigonometric functions  */




cpp_bin_float_oct cosm1(cpp_bin_float_oct x)
{
    if (fabs(x) > 0.5)
    {
        return cos(x) - 1;
    }
    else
    {
        cpp_bin_float_oct res = sin((x)/2);
        return  -2 * res * res;
    }
}





void LibOReal_Sin(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sin(*(cpp_bin_float_oct*)x);
}


void LibOReal_Cos(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cos(*(cpp_bin_float_oct*)x);
}


void LibOReal_Tan(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = tan(*(cpp_bin_float_oct*)x);
}


void LibOReal_Csc(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (1.0) / sin(*(cpp_bin_float_oct*)x);
}


void LibOReal_Sec(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (1.0) / cos(*(cpp_bin_float_oct*)x);
}


void LibOReal_Cot(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (1.0) / tan(*(cpp_bin_float_oct*)x);
}




/* Hyperbolic functions  */


void LibOReal_Sinh(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = sinh(*(cpp_bin_float_oct*)x);
}


void LibOReal_Cosh(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = cosh(*(cpp_bin_float_oct*)x);
}


void LibOReal_Tanh(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = tanh(*(cpp_bin_float_oct*)x);
}


void LibOReal_Csch(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (1.0) / sinh(*(cpp_bin_float_oct*)x);
}


void LibOReal_Sech(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (1.0) / cosh(*(cpp_bin_float_oct*)x);
}


void LibOReal_Coth(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = (1.0) / tanh(*(cpp_bin_float_oct*)x);
}



/* Inverse trigonometric functions  */


void LibOReal_Asin(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = asin(*(cpp_bin_float_oct*)x);
}


void LibOReal_Acos(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = acos(*(cpp_bin_float_oct*)x);
}


void LibOReal_Atan(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = atan(*(cpp_bin_float_oct*)x);
}


void LibOReal_Atan2(ORealPtr res, const ORealPtr x, const ORealPtr y)
{
	(*(cpp_bin_float_oct*)res) = atan2( (*(cpp_bin_float_oct*)x) , (*(cpp_bin_float_oct*)y) );
}


void LibOReal_Acsc(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = asin( (1.0) / (*(cpp_bin_float_oct*)x) );
}


void LibOReal_Asec(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = acos( (1.0) / (*(cpp_bin_float_oct*)x) );
}


void LibOReal_Acot(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = atan( (1.0) / (*(cpp_bin_float_oct*)x) );
}




/* Inverse hyperbolic functions  */


void LibOReal_Asinh(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = asinh(*(cpp_bin_float_oct*)x);
}


void LibOReal_Acosh(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = acosh(*(cpp_bin_float_oct*)x);
}


void LibOReal_Atanh(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = atanh(*(cpp_bin_float_oct*)x);
}


void LibOReal_Acsch(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = asinh( (1.0) / (*(cpp_bin_float_oct*)x) );
}


void LibOReal_Asech(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = acosh( (1.0) / (*(cpp_bin_float_oct*)x) );
}


void LibOReal_Acoth(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = atanh( (1.0) / (*(cpp_bin_float_oct*)x) );
}



/* Special functions  */

void LibOReal_Erf(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = erf(*(cpp_bin_float_oct*)x);
}

void LibOReal_Erfc(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = erfc(*(cpp_bin_float_oct*)x);
}

void LibOReal_Tgamma(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = tgamma(*(cpp_bin_float_oct*)x);
}

void LibOReal_Lgamma(ORealPtr res, const ORealPtr x)
{
	(*(cpp_bin_float_oct*)res) = lgamma(*(cpp_bin_float_oct*)x);
}

void LibOReal_J0(ORealPtr res, const ORealPtr x)
{
    cpp_bin_float_oct n = 0;
	(*(cpp_bin_float_oct*)res) = cyl_bessel_j(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}

void LibOReal_J1(ORealPtr res, const ORealPtr x)
{
    cpp_bin_float_oct n = 1;
	(*(cpp_bin_float_oct*)res) = cyl_bessel_j(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}

void LibOReal_Jn(ORealPtr res, const int n_, const ORealPtr x)
{
    cpp_bin_float_oct n = n_;
	(*(cpp_bin_float_oct*)res) = cyl_bessel_j(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}

void LibOReal_Y0(ORealPtr res, const ORealPtr x)
{
    cpp_bin_float_oct n = 0;
	(*(cpp_bin_float_oct*)res) = cyl_neumann(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}

void LibOReal_Y1(ORealPtr res, const ORealPtr x)
{
    cpp_bin_float_oct n = 1;
	(*(cpp_bin_float_oct*)res) = cyl_neumann(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}

void LibOReal_Yn(ORealPtr res, const int n_, const ORealPtr x)
{
    cpp_bin_float_oct n = n_;
	(*(cpp_bin_float_oct*)res) = cyl_bessel_j(n, cpp_bin_float_oct(*(cpp_bin_float_oct*)x));
}
























//*********************** Complex **********************************


OCplxPtr LibOCplx_Init_Func()
{
	OCplxPtr x = NULL;
	x = (std::complex<cpp_bin_float_oct>*) malloc(sizeof(std::complex<cpp_bin_float_oct>));
	return x;
}


void LibOCplx_Clear(OCplxPtr x)
{
	free(x);
}




void LibOCplx_Get_Str_Real(char* cstr, OCplxPtr x)
{
    cpp_bin_float_oct d = (*(std::complex<cpp_bin_float_oct>*) x).real();
    std::stringstream ss;
    ss.precision(std::numeric_limits<cpp_bin_float_oct>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void LibOCplx_Get_Str_Imag(char* cstr, OCplxPtr x)
{
    cpp_bin_float_oct d = (*(std::complex<cpp_bin_float_oct>*) x).imag();
    std::stringstream ss;
    ss.precision(std::numeric_limits<cpp_bin_float_oct>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void LibOCplx_Neg(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = -(*(std::complex<cpp_bin_float_oct>*) x);
}






void LibOCplx_Add(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) + (*(std::complex<cpp_bin_float_oct>*) y);
}


void LibOCplx_Sub(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) - (*(std::complex<cpp_bin_float_oct>*) y);
}


void LibOCplx_Mul(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) * (*(std::complex<cpp_bin_float_oct>*) y);
}


void LibOCplx_Div(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) / (*(std::complex<cpp_bin_float_oct>*) y);
}






void LibOCplx_Add_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) + (*(cpp_bin_float_oct*)y);
}



void LibOCplx_Sub_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) - (*(cpp_bin_float_oct*)y);
}


void LibOCplx_OReal_Sub(OCplxPtr res, const OCplxPtr y, const ORealPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) =  (*(cpp_bin_float_oct*)x) - (*(std::complex<cpp_bin_float_oct>*) y);
}



void LibOCplx_Mul_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) * (*(cpp_bin_float_oct*)y);
}



void LibOCplx_Div_OReal(OCplxPtr res, const OCplxPtr x, const ORealPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) / (*(cpp_bin_float_oct*)y);
}


void LibOCplx_OReal_Div(OCplxPtr res, const OCplxPtr y, const ORealPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(cpp_bin_float_oct*)x) / (*(std::complex<cpp_bin_float_oct>*) y);
}











void LibOCplx_Add_D(OCplxPtr res, const OCplxPtr x, const double y)
{
    cpp_bin_float_oct temp = y;
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) + temp;
}


void LibOCplx_Sub_D(OCplxPtr res, const OCplxPtr x, const double y)
{
    cpp_bin_float_oct temp = y;
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) - temp;
}


void LibOCplx_D_Sub(OCplxPtr res, const OCplxPtr y, const double x)
{
    cpp_bin_float_oct temp = x;
	(*(std::complex<cpp_bin_float_oct>*) res) = temp - (*(std::complex<cpp_bin_float_oct>*) y);
}


void LibOCplx_Mul_D(OCplxPtr res, const OCplxPtr x, const double y)
{
    cpp_bin_float_oct temp = y;
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) * temp;
}


void LibOCplx_Div_D(OCplxPtr res, const OCplxPtr x, const double y)
{
    cpp_bin_float_oct temp = y;
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) / temp;
}


void LibOCplx_D_Div(OCplxPtr res, const OCplxPtr y, const double x)
{
    cpp_bin_float_oct temp = x;
	(*(std::complex<cpp_bin_float_oct>*) res) = temp / (*(std::complex<cpp_bin_float_oct>*) y);
}













void LibOCplx_Add_Si(OCplxPtr res, const OCplxPtr x, const int32_t y)
{
    cpp_bin_float_oct temp = y;
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) + temp;
}


void LibOCplx_Sub_Si(OCplxPtr res, const OCplxPtr x, const int32_t y)
{
    cpp_bin_float_oct temp = y;
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) - temp;
}


void LibOCplx_Si_Sub(OCplxPtr res, const OCplxPtr y, const int32_t x)
{
    cpp_bin_float_oct temp = x;
	(*(std::complex<cpp_bin_float_oct>*) res) = temp - (*(std::complex<cpp_bin_float_oct>*) y);
}


void LibOCplx_Mul_Si(OCplxPtr res, const OCplxPtr x, const int32_t y)
{
    cpp_bin_float_oct temp = y;
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) * temp;
}


void LibOCplx_Div_Si(OCplxPtr res, const OCplxPtr x, const int32_t y)
{
    cpp_bin_float_oct temp = y;
	(*(std::complex<cpp_bin_float_oct>*) res) = (*(std::complex<cpp_bin_float_oct>*) x) / temp;
}


void LibOCplx_Si_Div(OCplxPtr res, const OCplxPtr y, const int32_t x)
{
    cpp_bin_float_oct temp = x;
	(*(std::complex<cpp_bin_float_oct>*) res) = temp / (*(std::complex<cpp_bin_float_oct>*) y);
}









/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */



void LibOCplx_Set(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res)  = (*(std::complex<cpp_bin_float_oct>*) x);
}

void LibOCplx_Set_Real(OCplxPtr res, const ORealPtr re)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::complex<cpp_bin_float_oct>(*(cpp_bin_float_oct*)re, 0);
}

void LibOCplx_Set2(OCplxPtr res, const ORealPtr re, const ORealPtr im)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::complex<cpp_bin_float_oct>(*(cpp_bin_float_oct*)re, *(cpp_bin_float_oct*)im);
}

void LibOCplx_Set2_Str2(ORealPtr res, const char * str_re, const char * str_im)
{
    cpp_bin_float_oct re = static_cast<cpp_bin_float_oct>(string(str_re));
    cpp_bin_float_oct im = static_cast<cpp_bin_float_oct>(string(str_im));
	(*(std::complex<cpp_bin_float_oct>*) res) = std::complex<cpp_bin_float_oct>(re, im);
}


void LibOCplx_Abs(ORealPtr res, const OCplxPtr x)
{
	*(cpp_bin_float_oct*)res = std::abs(*(std::complex<cpp_bin_float_oct>*) x);
}

void LibOCplx_Arg(ORealPtr res, const OCplxPtr x)
{
	*(cpp_bin_float_oct*)res = std::arg(*(std::complex<cpp_bin_float_oct>*) x);
}

void LibOCplx_Imag(ORealPtr res, const OCplxPtr x)
{
	*(cpp_bin_float_oct*)res = (*(std::complex<cpp_bin_float_oct>*) x).imag();
}

void LibOCplx_Real(ORealPtr res, const OCplxPtr x)
{
	*(cpp_bin_float_oct*)res = (*(std::complex<cpp_bin_float_oct>*) x).real();
}


void LibOCplx_Conj(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::conj(*(std::complex<cpp_bin_float_oct>*) x);
}

void LibOCplx_Proj(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::proj(*(std::complex<cpp_bin_float_oct>*) x);
}






/* Roots  */



std::complex<cpp_bin_float_oct> cplx_expm1(std::complex<cpp_bin_float_oct> z)
{
    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
	cpp_bin_float_oct x = z.real();
	cpp_bin_float_oct y = z.imag();
	cpp_bin_float_oct resx =  expm1(x) * cos(y) + cosm1(y);
	cpp_bin_float_oct resy =  exp(x) * sin(y);
	return std::complex<cpp_bin_float_oct>(resx, resy);
}



std::complex<cpp_bin_float_oct> cplx_log1p(std::complex<cpp_bin_float_oct> z)
{
    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
    /* resy =  atan2(y, 1 + x); */
	cpp_bin_float_oct x = z.real();
	cpp_bin_float_oct y = z.imag();
	cpp_bin_float_oct resx = 0.0 ;
	if ( (fabs(x) > 0.75) || (fabs(y) > 0.75) || (x < -0.5) )
    {
        resx = log(hypot(1 + x, y)) ;
    }
    else
    {
        resx = 0.5 * log1p(2*x + x*x + y*y);
    }
	cpp_bin_float_oct resy = atan2(y, 1 + x); ;
	return std::complex<cpp_bin_float_oct>(resx, resy);
}



void LibOCplx_Sqrt(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::sqrt(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Sqrt1pm1(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct Half = 0.5;
    (*(std::complex<cpp_bin_float_oct>*) res) = cplx_expm1(cplx_log1p(*(std::complex<cpp_bin_float_oct>*) x) * Half);
}


void LibOCplx_Rsqrt(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) =One / std::sqrt(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Cbrt(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
    cpp_bin_float_oct Three = 3;
    cpp_bin_float_oct r = One / Three;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::pow(*(std::complex<cpp_bin_float_oct>*) x, r);
}


void LibOCplx_Root_Si(OCplxPtr res, const OCplxPtr x, const int32_t k)
{
    cpp_bin_float_oct One = 1;
    cpp_bin_float_oct k_ = k;
    cpp_bin_float_oct r = One / k_;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::pow(*(std::complex<cpp_bin_float_oct>*) x, r);
}





/* Exponential and related functions  */


void LibOCplx_Exp(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::exp(*(std::complex<cpp_bin_float_oct>*) x);
}

void LibOCplx_Exp2(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::exp( (*(std::complex<cpp_bin_float_oct>*) x)
                                                     * constants::ln_two<cpp_bin_float_oct>() );
}

void LibOCplx_Exp10(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::exp( (*(std::complex<cpp_bin_float_oct>*) x)
                                                     * constants::ln_ten<cpp_bin_float_oct>() );
}



void LibOCplx_Expm1(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = cplx_expm1(*(std::complex<cpp_bin_float_oct>*) x);
}

void LibOCplx_Exp2m1(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = cplx_expm1( (*(std::complex<cpp_bin_float_oct>*) x)
                                                     * constants::ln_two<cpp_bin_float_oct>() );
}

void LibOCplx_Exp10m1(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = cplx_expm1( (*(std::complex<cpp_bin_float_oct>*) x)
                                                     * constants::ln_ten<cpp_bin_float_oct>() );
}






/* Logarithms and related functions  */


void LibOCplx_Log(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::log(*(std::complex<cpp_bin_float_oct>*) x);
}

void LibOCplx_Log2(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::log(*(std::complex<cpp_bin_float_oct>*) x)
                                                    / constants::ln_two<cpp_bin_float_oct>();
}

void LibOCplx_Log10(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::log10(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Log1p(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = cplx_log1p(*(std::complex<cpp_bin_float_oct>*) x);
}

void LibOCplx_Log2p1(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = cplx_log1p(*(std::complex<cpp_bin_float_oct>*) x)
                                                    / constants::ln_two<cpp_bin_float_oct>();
}

void LibOCplx_Log10p1(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = cplx_log1p(*(std::complex<cpp_bin_float_oct>*) x)
                                                    / constants::ln_two<cpp_bin_float_oct>();
}





/* Power functions */


void LibOCplx_Square(OCplxPtr res, const OCplxPtr x)
{
    std::complex<cpp_bin_float_oct> z = *(std::complex<cpp_bin_float_oct>*) x;
	(*(std::complex<cpp_bin_float_oct>*) res) =  z * z;
}


void LibOCplx_Cube(OCplxPtr res, const OCplxPtr x)
{
    std::complex<cpp_bin_float_oct> z = *(std::complex<cpp_bin_float_oct>*) x;
	(*(std::complex<cpp_bin_float_oct>*) res) =  z * z * z;
}


void LibOCplx_Pow(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::pow(*(std::complex<cpp_bin_float_oct>*) x,
                                                 *(std::complex<cpp_bin_float_oct>*) y);
}



void LibOCplx_Powm1(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    (*(std::complex<cpp_bin_float_oct>*) res) = cplx_expm1(std::log(*(std::complex<cpp_bin_float_oct>*) x)
                                                           * (*(std::complex<cpp_bin_float_oct>*) y));
}

void LibOCplx_Pow1p(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    (*(std::complex<cpp_bin_float_oct>*) res) = std::exp(cplx_log1p(*(std::complex<cpp_bin_float_oct>*) x)
                                                         * (*(std::complex<cpp_bin_float_oct>*) y));
}

void LibOCplx_Pow1pm1(OCplxPtr res, const OCplxPtr x, const OCplxPtr y)
{
    (*(std::complex<cpp_bin_float_oct>*) res) = cplx_expm1(cplx_log1p(*(std::complex<cpp_bin_float_oct>*) x)
                                                           * (*(std::complex<cpp_bin_float_oct>*) y));
}




void LibOCplx_Pow_Si(OCplxPtr res, const OCplxPtr x, const int32_t k)
{
    cpp_bin_float_oct k_ = k;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::pow(*(std::complex<cpp_bin_float_oct>*) x, k_);
}


void LibOCplx_Compound_Si(OCplxPtr res, const OCplxPtr x, const int32_t k)
{
    cpp_bin_float_oct One = 1;
    cpp_bin_float_oct k_ = k;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::pow(One + (*(std::complex<cpp_bin_float_oct>*) x), k_);
}






/* Trigonometric functions  */


void LibOCplx_Sin(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::sin(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Cos(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::cos(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Tan(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::tan(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Csc(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = One / std::sin(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Sec(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = One /  std::cos(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Cot(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = One /  std::tan(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_SinPi(OCplxPtr res, const OCplxPtr x)
{
	//(*(std::complex<cpp_bin_float_oct>*) res) = std::sin(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_CosPi(OCplxPtr res, const OCplxPtr x)
{
	//(*(std::complex<cpp_bin_float_oct>*) res) = std::cos(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_TanPi(OCplxPtr res, const OCplxPtr x)
{
	//(*(std::complex<cpp_bin_float_oct>*) res) = std::tan(*(std::complex<cpp_bin_float_oct>*) x);
}





/* Hyperbolic functions  */


void LibOCplx_Sinh(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::sinh(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Cosh(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::cosh(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Tanh(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::tanh(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Csch(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = One / std::sinh(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Sech(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = One /  std::cosh(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Coth(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = One /  std::tanh(*(std::complex<cpp_bin_float_oct>*) x);
}





/* Inverse trigonometric functions  */


void LibOCplx_Asin(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::asin(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Acos(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::acos(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Atan(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::atan(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Acsc(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::asin(One / (*(std::complex<cpp_bin_float_oct>*) x));
}


void LibOCplx_Asec(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::acos(One / (*(std::complex<cpp_bin_float_oct>*) x));
}


void LibOCplx_Acot(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::atan(One / (*(std::complex<cpp_bin_float_oct>*) x));
}






/* Inverse hyperbolic functions  */


void LibOCplx_Asinh(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::asinh(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Acosh(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::acosh(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Atanh(OCplxPtr res, const OCplxPtr x)
{
	(*(std::complex<cpp_bin_float_oct>*) res) = std::atanh(*(std::complex<cpp_bin_float_oct>*) x);
}


void LibOCplx_Acsch(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::asinh(One / (*(std::complex<cpp_bin_float_oct>*) x));
}


void LibOCplx_Asech(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::acosh(One / (*(std::complex<cpp_bin_float_oct>*) x));
}


void LibOCplx_Acoth(OCplxPtr res, const OCplxPtr x)
{
    cpp_bin_float_oct One = 1;
	(*(std::complex<cpp_bin_float_oct>*) res) = std::atanh(One / (*(std::complex<cpp_bin_float_oct>*) x));
}


//
//
//void LibOCplx_Tgamma(OCplxPtr res, const OCplxPtr x)
//{
//    cpp_bin_float_oct One = 1;
//	(*(std::complex<cpp_bin_float_oct>*) res) = boost::math::tgamma(*(std::complex<cpp_bin_float_oct>*) x);
//}
//
//





