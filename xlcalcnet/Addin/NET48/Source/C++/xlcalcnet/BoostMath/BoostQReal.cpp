


// See also: https://www.boost.org/doc/libs/1_80_0/boost/math/tools/user.hpp

#include <boost/math/tools/user.hpp>


#include "BoostQReal.h"


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
    float128 result = 0; \
    std::pair<float128, float128> dist_pair; \
    float128 xqp1 = float128(*(__float128*)xqp); \
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
    (*(__float128*)res) = result.backend().value();

//    std::cout << "Target =  " << Target <<  ";  result =  " << result << std::endl;



#include <boost/math/tools/minima.hpp>
#include <boost/math/tools/roots.hpp>
#include <boost/math/tools/agm.hpp>
#include <tuple> // for std::tuple and std::make_tuple.


#include <boost/math/constants/constants.hpp>
#include <boost/math/special_functions.hpp>
#include <boost/math/distributions.hpp>
#include <boost/math/special_functions/logaddexp.hpp>

#include <boost/multiprecision/float128.hpp>
#include <boost/multiprecision/complex128.hpp>


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
//
//////*********************** Boost/CppOptLib **********************************
////
//using namespace Eigen;
//using namespace cppoptlib;
//typedef Matrix<float128, Dynamic, 1> state_type_vec;
//typedef state_type_vec* mpVectorPtr;
//
//
//
//class CppOptLibSolver : public Problem<float128>
//{
//    public:
//    using typename cppoptlib::Problem<float128>::TVector;
//    using typename cppoptlib::Problem<float128>::THessian;
//    CppOptLibSolver(QRealFuncPtr f1, QRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_)
//     {func1 = f1; func2 = f2;  matX = matX_ ; matGrad = matGrad_;};
//    float128 value(const TVector &x) {
//          *matX = x;
//          float128 norm = 0.0;
//          func1(matX, &(norm.backend().value()));
//          return norm;
//    }
//    void gradient(const TVector &x, TVector &grad) {
//        *matX = x;
//        *matGrad = grad;
//        func2(matX, matGrad);
//        grad = *matGrad;
//    }
//  QRealFuncPtr func1, func2;
//  mpVectorPtr matX, matGrad;
//};
//
//
//
//
//void LibQReal_LbfgsSolver(QRealFuncPtr f1, QRealFuncPtr f2, QStatePtr matX_, QStatePtr matGrad_, QStatePtr xPtr)
//{
// printf("LbfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    LbfgsSolver<CppOptLibSolver> solver;
//    float128 eps = std::numeric_limits<float128>::epsilon();
//    Criteria<float128> m_stop;
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
//void LibQReal_BfgsSolver(QRealFuncPtr f1, QRealFuncPtr f2, QStatePtr matX_, QStatePtr matGrad_, QStatePtr xPtr)
//{
// printf("BfgsSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    BfgsSolver<CppOptLibSolver> solver;
//    float128 eps = std::numeric_limits<float128>::epsilon();
//    Criteria<float128> m_stop;
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
//void LibQReal_GradientDescentSolver(QRealFuncPtr f1, QRealFuncPtr f2, QStatePtr matX_, QStatePtr matGrad_, QStatePtr xPtr)
//{
// printf("GradientDescentSolver");
//
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    GradientDescentSolver<CppOptLibSolver> solver;
//    float128 eps = std::numeric_limits<float128>::epsilon();
//    Criteria<float128> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//    solver.minimize(f, x);
//    (*(mpVectorPtr)matX_) = x;
//    //(*(mpVectorPtr)matNorm_)(0) = f(x);
//}
//
//
//void LibQReal_ConjugatedGradientDescentSolver(QRealFuncPtr f1, QRealFuncPtr f2, QStatePtr matX_, QStatePtr matGrad_, QStatePtr xPtr)
//{
// printf("ConjugatedGradientDescentSolver");
//    CppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_);
//    state_type_vec x = (*(mpVectorPtr)xPtr);
//    ConjugatedGradientDescentSolver<CppOptLibSolver> solver;
//    float128 eps = std::numeric_limits<float128>::epsilon();
//    Criteria<float128> m_stop;
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
typedef Matrix<float128, Dynamic, 1> state_type_vec;


struct Boost_LibQReal_Write
{
	Boost_LibQReal_Write(QAnyFuncPtr2 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, const float128 t)
	{
	    float128 fx = t;
		func1(&x, &(fx.backend().value()));
	}
	QAnyFuncPtr2 func1;
};


struct Boost_LibQReal_Func_Vec
{
	Boost_LibQReal_Func_Vec(QAnyFuncPtr3 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, state_type_vec &dxdt, float128 t) const
	{
	    float128 fx = t;
		func1(&x, &dxdt, &(fx.backend().value()));
	}
	QAnyFuncPtr3 func1;
};


/* Constant steppers */

void LibQReal_Const_RungeKutta4(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
	integrate_const(runge_kutta4<state_type_vec, float128>(), Boost_LibQReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibQReal_Write(f2));
}


void LibQReal_Const_RungeKuttaCashKarp54(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
	integrate_const(runge_kutta_cash_karp54<state_type_vec, float128>(), Boost_LibQReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibQReal_Write(f2));
}


void LibQReal_Const_RungeKuttaDopri5(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
	integrate_const(runge_kutta_dopri5<state_type_vec, float128>(), Boost_LibQReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibQReal_Write(f2));
}


void LibQReal_Const_RungeKuttaFehlberg78(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
	integrate_const(runge_kutta_fehlberg78<state_type_vec, float128>(), Boost_LibQReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibQReal_Write(f2));
}


void LibQReal_Const_AdamsBashforthMoulton(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
	integrate_const(adams_bashforth_moulton<5, state_type_vec, float128>(), Boost_LibQReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibQReal_Write(f2));
}


/* Adaptive steppers */

void LibQReal_Adaptive_RungeKuttaDopri5(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
    float128 eps_abs = float128(*(__float128*)eps_abs_);
    float128 eps_rel = float128(*(__float128*)eps_rel_);

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_dopri5<state_type_vec, float128>() ) , Boost_LibQReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibQReal_Write(f2));
}


void LibQReal_Adaptive_RungeKuttaCashKarp54(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
    float128 eps_abs = float128(*(__float128*)eps_abs_);
    float128 eps_rel = float128(*(__float128*)eps_rel_);

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_cash_karp54<state_type_vec, float128>() ) , Boost_LibQReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt,  Boost_LibQReal_Write(f2));
}


void LibQReal_Adaptive_RungeKuttaFehlberg78(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
    float128 eps_abs = float128(*(__float128*)eps_abs_);
    float128 eps_rel = float128(*(__float128*)eps_rel_);

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_fehlberg78<state_type_vec, float128>() ) , Boost_LibQReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibQReal_Write(f2));
}


void LibQReal_Adaptive_BulirschStoer(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
    float128 eps_abs = float128(*(__float128*)eps_abs_);
    float128 eps_rel = float128(*(__float128*)eps_rel_);

	bulirsch_stoer< state_type_vec, float128 > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibQReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibQReal_Write(f2));
}

/* Dense Output steppers */


void LibQReal_DenseOutput_Dopri5(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
    float128 eps_abs = float128(*(__float128*)eps_abs_);
    float128 eps_rel = float128(*(__float128*)eps_rel_);

    typedef runge_kutta_dopri5< state_type_vec, float128 > dopri5_type;
    typedef controlled_runge_kutta< dopri5_type > controlled_dopri5_type;
    typedef dense_output_runge_kutta< controlled_dopri5_type > dense_output_dopri5_type;
    dense_output_dopri5_type dopri5 = make_dense_output( eps_abs , eps_rel , dopri5_type() );
    integrate_adaptive( dopri5, Boost_LibQReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibQReal_Write(f2));
}



void LibQReal_DenseOutput_BulirschStoer(QAnyFuncPtr3 f1, QAnyFuncPtr2 f2, QStatePtr x, QRealPtr start_time_, QRealPtr end_time_, QRealPtr dt_, QRealPtr eps_abs_, QRealPtr eps_rel_)
{
    float128 start_time = float128(*(__float128*)start_time_);
    float128 end_time = float128(*(__float128*)end_time_);
    float128 dt = float128(*(__float128*)dt_);
    float128 eps_abs = float128(*(__float128*)eps_abs_);
    float128 eps_rel = float128(*(__float128*)eps_rel_);

	bulirsch_stoer_dense_out< state_type_vec, float128 > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibQReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibQReal_Write(f2));
}











//*********************** Boost Numerical Calculus, quadruple precision **********************************



struct QRealFunctor1
{
  QRealFunctor1(QRealFuncPtr f1):func1(f1) {}
  float128 operator()(float128 x)
  {
    float128 fx;
	func1( &(x.backend().value()), &(fx.backend().value()));
    return fx;
  }
private:
	QRealFuncPtr func1;
};


struct QRealFunctor2
{
  QRealFunctor2(QRealFuncPtr f1, QRealFuncPtr f2):func1(f1), func2(f2) {}
  std::pair<float128, float128> operator()(float128 x)
  {
    float128 fx, dx;
	func1( &(x.backend().value()), &(fx.backend().value()));
	func2( &(x.backend().value()), &(dx.backend().value()));
    return std::make_pair(fx, dx);
  }
private:
	QRealFuncPtr func1, func2;
};


struct QRealFunctor3
{
  QRealFunctor3(QRealFuncPtr f1, QRealFuncPtr f2, QRealFuncPtr f3):func1(f1), func2(f2), func3(f3) {}
  std::tuple<float128, float128, float128> operator()(float128 x)
  {
    float128 fx, dx, d2x;
	func1( &(x.backend().value()), &(fx.backend().value()));
	func2( &(x.backend().value()), &(dx.backend().value()));
	func3( &(x.backend().value()), &(d2x.backend().value()));
    return std::make_tuple(fx, dx, d2x);
  }
private:
	QRealFuncPtr func1, func2, func3;
};



void LibQReal_BracketRoot(QRealPtr res1, QRealPtr res2, int* iter, QRealFuncPtr f1, QRealPtr guess_, QRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    float128 guess = float128(*(__float128*)guess_);
    float128 factor = float128(*(__float128*)factor_);
	boost::uintmax_t it = maxit;
	eps_tolerance<float128> tol(get_digits);
	std::pair<float128, float128> r = bracket_and_solve_root(QRealFunctor1(f1), guess, factor, is_rising, tol, it);
	float128 error = (r.second - r.first) / 2;
	float128 result = r.first + error;
    (*(__float128*)res1) = result.backend().value();
    (*(__float128*)res2) = error.backend().value();
    *iter = (int) it;
}



void LibQReal_NewtonRaphson(QRealPtr res,  int* iter, QRealFuncPtr f1, QRealFuncPtr f2, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit)
{
    float128 guess = float128(*(__float128*)guess_);
    float128 xmin = float128(*(__float128*)xmin_);
    float128 xmax = float128(*(__float128*)xmax_);
    boost::uintmax_t it = maxit;
    float128 result = newton_raphson_iterate(QRealFunctor2(f1, f2), guess, xmin, xmax, get_digits, it);
    (*(__float128*)res) = result.backend().value();
    *iter = (int) it;
}



void LibQReal_Halley(QRealPtr res, int* iter, QRealFuncPtr f1, QRealFuncPtr f2, QRealFuncPtr f3, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit)
{
    float128 guess = float128(*(__float128*)guess_);
    float128 xmin = float128(*(__float128*)xmin_);
    float128 xmax = float128(*(__float128*)xmax_);
    boost::uintmax_t it = maxit;
    float128 result = halley_iterate(QRealFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
    (*(__float128*)res) = result.backend().value();
    *iter = (int) it;
}



void LibQReal_Schroder(QRealPtr res, int* iter, QRealFuncPtr f1, QRealFuncPtr f2, QRealFuncPtr f3, QRealPtr guess_, QRealPtr xmin_, QRealPtr xmax_, int get_digits, unsigned int maxit)
{
    float128 guess = float128(*(__float128*)guess_);
    float128 xmin = float128(*(__float128*)xmin_);
    float128 xmax = float128(*(__float128*)xmax_);
    boost::uintmax_t it = maxit;
    float128 result = schroder_iterate(QRealFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
    (*(__float128*)res) = result.backend().value();
    *iter = (int) it;
}



void LibQReal_Brent_Minimum(QRealPtr res, QRealPtr resFx, int* iter, QRealFuncPtr f1, QRealPtr bracket_min_, QRealPtr bracket_max_, int bits, unsigned int maxit)
{
    float128 bracket_min = float128(*(__float128*)bracket_min_);
    float128 bracket_max = float128(*(__float128*)bracket_max_);
    boost::uintmax_t it = maxit;
    std::pair<float128, float128> r = brent_find_minima(QRealFunctor1(f1), bracket_min, bracket_max, bits, it);
    (*(__float128*)res) = r.first.backend().value();
    (*(__float128*)resFx) = r.second.backend().value();
    *iter = (int) it;
}





void LibQReal_Trapezoidal(QRealPtr res1, QRealPtr res2, QRealPtr res3, QRealFuncPtr f1, QRealPtr a_, QRealPtr b_)
{
    float128 a = float128(*(__float128*)a_);
    float128 b = float128(*(__float128*)b_);
    float128 tol = sqrt(std::numeric_limits<float128>::epsilon());
    float128 error;
    float128 L1;
    size_t max_refinements = 24;
    auto f = [&f1](float128 x) {
        float128 fx;
        f1( &(x.backend().value()), &(fx.backend().value()));
        return fx;
        };
    float128 result = trapezoidal(f, a, b, tol, max_refinements, &error, &L1);
    (*(__float128*)res1) = result.backend().value();
    (*(__float128*)res2) = error.backend().value();
    (*(__float128*)res3) = (L1/fabs(result)).backend().value();
}



// 7, 15, 20, 25 and 30

void LibQReal_GaussLegendre(QRealPtr res1, QRealPtr res3, QRealFuncPtr f1, QRealPtr a_, QRealPtr b_)
{
    float128 a = float128(*(__float128*)a_);
    float128 b = float128(*(__float128*)b_);
    float128 L1;
    auto f = [&f1](float128 x) {
        float128 fx;
        f1( &(x.backend().value()), &(fx.backend().value()));
        return fx;
        };
    float128 result = gauss<float128, 7>::integrate(f, a, b, &L1);
    (*(__float128*)res1) = result.backend().value();
    (*(__float128*)res3) = (L1/fabs(result)).backend().value();
}



//15, 31, 41, 51 and 61

void LibQReal_GaussKronrod(QRealPtr res1, QRealPtr res2, QRealPtr res3, QRealFuncPtr f1, QRealPtr a_, QRealPtr b_)
{
    float128 a = float128(*(__float128*)a_);
    float128 b = float128(*(__float128*)b_);
    float128 tol = sqrt(std::numeric_limits<float128>::epsilon());
    float128 error;
    float128 L1;
    unsigned max_depth = 15;
    auto f = [&f1](float128 x) {
        float128 fx;
        f1( &(x.backend().value()), &(fx.backend().value()));
        return fx;
        };
    float128 result = gauss_kronrod<float128, 15>::integrate(f, a, b, max_depth, tol, &error, &L1);
    (*(__float128*)res1) = result.backend().value();
    (*(__float128*)res2) = error.backend().value();
    (*(__float128*)res3) = (L1/fabs(result)).backend().value();
}



void LibQReal_TanhSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QRealFuncPtr f1, QRealPtr a_, QRealPtr b_)
{
    float128 a = float128(*(__float128*)a_);
    float128 b = float128(*(__float128*)b_);
    tanh_sinh<float128> integrator;
    auto f = [&f1](float128 x) {
        float128 fx;
        f1( &(x.backend().value()), &(fx.backend().value()));
        return fx;
        };
    float128 termination = sqrt(std::numeric_limits<float128>::epsilon());
    float128  error;
    float128  L1;
    std::size_t levels = 0;
    float128 result = integrator.integrate(f, a, b, termination, &error, &L1, &levels);
    (*(__float128*)res1) = result.backend().value();
    (*(__float128*)res2) = error.backend().value();
    (*(__float128*)res3) = (L1/fabs(result)).backend().value();
    *levels_ = (int) levels;
}




void LibQReal_SinhSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QRealFuncPtr f1)
{
    sinh_sinh<float128> integrator;
    auto f = [&f1](float128 x) {
        float128 fx;
        f1( &(x.backend().value()), &(fx.backend().value()));
        return fx;
        };
    float128 termination = sqrt(std::numeric_limits<float128>::epsilon());
    float128  error;
    float128  L1;
    std::size_t levels = 0;
    float128 result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*(__float128*)res1) = result.backend().value();
    (*(__float128*)res2) = error.backend().value();
    (*(__float128*)res3) = (L1/fabs(result)).backend().value();
    *levels_ = (int) levels;
}



void LibQReal_ExpSinh(QRealPtr res1, QRealPtr res2, QRealPtr res3, int* levels_, QRealFuncPtr f1)
{
    exp_sinh<float128> integrator;
    auto f = [&f1](float128 x) {
        float128 fx;
        f1( &(x.backend().value()), &(fx.backend().value()));
        return fx;
        };
    float128 termination = sqrt(std::numeric_limits<float128>::epsilon());
    float128  error;
    float128  L1;
    std::size_t levels = 0;
    float128 result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*(__float128*)res1) = result.backend().value();
    (*(__float128*)res2) = error.backend().value();
    (*(__float128*)res3) = (L1/fabs(result)).backend().value();
    *levels_ = (int) levels;
}



void LibQReal_Ooura_Cos(QRealPtr res1, QRealPtr res2, QRealFuncPtr f1)
{
    float128 omega = 1;
    float128 tol = 2 * sqrt(std::numeric_limits<float128>::epsilon());
	auto integrator = ooura_fourier_cos<float128>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](float128 x) {
        float128 fx;
        f1( &(x.backend().value()), &(fx.backend().value()));
        return fx;
        };
	std::pair<float128, float128> r = integrator.integrate(f, omega);
    (*(__float128*)res1) =  r.first.backend().value();
    (*(__float128*)res2) =  r.second.backend().value();
}



void LibQReal_Ooura_Sin(QRealPtr res1, QRealPtr res2, QRealFuncPtr f1)
{
    float128 omega = 1;
    float128 tol = 2 * sqrt(std::numeric_limits<float128>::epsilon());
	auto integrator = ooura_fourier_sin<float128>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](float128 x) {
        float128 fx;
        f1( &(x.backend().value()), &(fx.backend().value()));
        return fx;
        };
	std::pair<float128, float128> r = integrator.integrate(f, omega);
    (*(__float128*)res1) =  r.first.backend().value();
    (*(__float128*)res2) =  r.second.backend().value();
}




//***********************  Boost Distributions, quadruple precision  **********************************


void LibQReal_ArcsineDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b)
{
    float128 a1 = float128(*(__float128*)a);
    float128 b1 = float128(*(__float128*)b);
    arcsine_distribution<float128> dist(a1, b1); MP_DIST_RETURN
}



void LibQReal_BernoulliDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr p)
{
    float128 p1 = float128(*(__float128*)p);
    bernoulli_distribution<float128> dist(p1); MP_DIST_RETURN
}



void LibQReal_BetaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b)
{
    float128 a1 = float128(*(__float128*)a);
    float128 b1 = float128(*(__float128*)b);
    beta_distribution<float128> dist(a1, b1); MP_DIST_RETURN
}



void LibQReal_BinomialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n, QRealPtr p)
{
    float128 n1 = float128(*(__float128*)n);
    float128 p1 = float128(*(__float128*)p);
    binomial_distribution<float128> dist(n1, p1); MP_DIST_RETURN
}



void LibQReal_CauchyDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    cauchy_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}



void LibQReal_Chi2Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    float128 nu1 = float128(*(__float128*)nu);
    chi_squared_distribution<float128> dist(nu1); MP_DIST_RETURN
}



void LibQReal_ExponentialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lambda)
{
    float128 lambda1 = float128(*(__float128*)lambda);
    exponential_distribution<float128> dist(lambda1); MP_DIST_RETURN
}



void LibQReal_ExtremeValueDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    extreme_value_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}



void LibQReal_FisherFDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mu, QRealPtr nu)
{
    float128 mu1 = float128(*(__float128*)mu);
    float128 nu1 = float128(*(__float128*)nu);
    fisher_f_distribution<float128> dist(mu1, nu1); MP_DIST_RETURN
}



void LibQReal_GammaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale)
{
    float128 shape1 = float128(*(__float128*)shape);
    float128 scale1 = float128(*(__float128*)scale);
    gamma_distribution<float128> dist(shape1, scale1); MP_DIST_RETURN
}



void LibQReal_GeometricDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr p)
{
    float128 p1 = float128(*(__float128*)p);
    geometric_distribution<float128> dist(p1); MP_DIST_RETURN
}



void LibQReal_HypergeometricDist(long Target, QRealPtr res, QRealPtr xqp, uint64_t r, uint64_t n, uint64_t N)
{
    hypergeometric_distribution<float128> dist(r, n, N); MP_DIST_RETURN
}



void LibQReal_InverseChi2Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr df, QRealPtr scale)
{
    float128 df1 = float128(*(__float128*)df);
    float128 scale1 = float128(*(__float128*)scale);
    inverse_chi_squared_distribution<float128> dist(df1, scale1); MP_DIST_RETURN
}



void LibQReal_InverseGammaDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale)
{
    float128 shape1 = float128(*(__float128*)shape);
    float128 scale1 = float128(*(__float128*)scale);
    inverse_gamma_distribution<float128> dist(shape1, scale1); MP_DIST_RETURN
}



void LibQReal_InverseGaussianDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr scale)
{
    float128 mean1 = float128(*(__float128*)mean_);
    float128 scale1 = float128(*(__float128*)scale);
    inverse_gaussian_distribution<float128> dist(mean1, scale1); MP_DIST_RETURN
}



void LibQReal_LaplaceDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    laplace_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}



void LibQReal_LogisticDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    logistic_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}



void LibQReal_LognormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    lognormal_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}



void LibQReal_NegBinomialDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr n, QRealPtr p)
{
    float128 n1 = float128(*(__float128*)n);
    float128 p1 = float128(*(__float128*)p);
    negative_binomial_distribution<float128> dist(n1, p1); MP_DIST_RETURN
}


void LibQReal_Chi2NCDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu, QRealPtr nc)
{
    float128 nu1 = float128(*(__float128*)nu);
    float128 nc1 = float128(*(__float128*)nc);
    non_central_chi_squared_distribution<float128> dist(nu1, nc1); MP_DIST_RETURN
}


void LibQReal_StudentTNCDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu, QRealPtr delta)
{
    float128 nu1 = float128(*(__float128*)nu);
    float128 delta1 = float128(*(__float128*)delta);
    non_central_t_distribution<float128> dist(nu1, delta1); MP_DIST_RETURN
}



void LibQReal_FisherNCDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mu, QRealPtr nu, QRealPtr nc)
{
    float128 mu1 = float128(*(__float128*)mu);
    float128 nu1 = float128(*(__float128*)nu);
    float128 nc1 = float128(*(__float128*)nc);
    non_central_f_distribution<float128> dist(mu1, nu1, nc1); MP_DIST_RETURN
}



void LibQReal_BetaNCDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr a, QRealPtr b, QRealPtr nc)
{
    float128 a1 = float128(*(__float128*)a);
    float128 b1 = float128(*(__float128*)b);
    float128 nc1 = float128(*(__float128*)nc);
    non_central_beta_distribution<float128> dist(a1, b1, nc1); MP_DIST_RETURN
}



void LibQReal_NormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr stdev)
{
    float128 mean1 = float128(*(__float128*)mean_);
    float128 stdev1 = float128(*(__float128*)stdev);
    normal_distribution<float128> dist(mean1, stdev1); MP_DIST_RETURN
}



void LibQReal_ParetoDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale)
{
    float128 shape1 = float128(*(__float128*)shape);
    float128 scale1 = float128(*(__float128*)scale);
    pareto_distribution<float128> dist(shape1, scale1); MP_DIST_RETURN
}



void LibQReal_PoissonDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    float128 nu1 = float128(*(__float128*)nu);
    poisson_distribution<float128> dist(nu1); MP_DIST_RETURN
}



void LibQReal_RayleighDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    float128 nu1 = float128(*(__float128*)nu);
    rayleigh_distribution<float128> dist(nu1); MP_DIST_RETURN
}



void LibQReal_SkewNormalDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr mean_, QRealPtr scale, QRealPtr shape)
{
    float128 mean1 = float128(*(__float128*)mean_);
    float128 shape1 = float128(*(__float128*)shape);
    float128 scale1 = float128(*(__float128*)scale);
    skew_normal_distribution<float128> dist(mean1, scale1, shape1); MP_DIST_RETURN
}



void LibQReal_StudentTDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    float128 nu1 = float128(*(__float128*)nu);
    students_t_distribution<float128> dist(nu1); MP_DIST_RETURN
}



void LibQReal_TriangularDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lower, QRealPtr mode_, QRealPtr upper)
{
    float128 lower1 = float128(*(__float128*)lower);
    float128 mode1 = float128(*(__float128*)mode_);
    float128 upper1 = float128(*(__float128*)upper);
    triangular_distribution<float128> dist(lower1, mode1, upper1); MP_DIST_RETURN
}



void LibQReal_WeibullDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr shape, QRealPtr scale)
{
    float128 shape1 = float128(*(__float128*)shape);
    float128 scale1 = float128(*(__float128*)scale);
    weibull_distribution<float128> dist(shape1, scale1); MP_DIST_RETURN
}



void LibQReal_UniformDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr lower, QRealPtr upper)
{
    float128 lower1 = float128(*(__float128*)lower);
    float128 upper1 = float128(*(__float128*)upper);
    uniform_distribution<float128> dist(lower1, upper1); MP_DIST_RETURN
}



//*********************** New , quadruple precision **********************************





void LibQReal_Logaddexp(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
	(*(__float128*)res) = logaddexp(float128(*(__float128*)a), float128(*(__float128*)b)).backend().value();
}




void LibQReal_KolmogorovSmirnovDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr nu)
{
    float128 nu1 = float128(*(__float128*)nu);
    kolmogorov_smirnov_distribution<float128> dist(nu1); MP_DIST_RETURN
}



void LibQReal_HyperexponentialDist(long Target, QRealPtr res, QRealPtr xqp, QStatePtr l1, QStatePtr l2)
{
    hyperexponential_distribution<float128> dist( *(state_type_vec*) l1, *(state_type_vec*) l2); MP_DIST_RETURN
}


void LibQReal_HoltsmarkDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    holtsmark_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}


void LibQReal_LandauDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    landau_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}


void LibQReal_MapAiryDist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    mapairy_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}


void LibQReal_Saspoint5Dist(long Target, QRealPtr res, QRealPtr xqp, QRealPtr location, QRealPtr scale)
{
    float128 location1 = float128(*(__float128*)location);
    float128 scale1 = float128(*(__float128*)scale);
    saspoint5_distribution<float128> dist(location1, scale1); MP_DIST_RETURN
}





//*********************** Boost Special functions , octuple precision **********************************



void LibQReal_Ulp(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = ulp(float128(*(__float128*)x)).backend().value();
}


void LibQReal_BernoulliB2n(QRealPtr res, const int n)
{
	(*(__float128*)res) = bernoulli_b2n<float128>(n).backend().value();
}



void LibQReal_TangentT2n(QRealPtr res, const int n)
{
	(*(__float128*)res) = tangent_t2n<float128>(n).backend().value();
}



void LibQReal_Sqrt1pm1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = sqrt1pm1(float128(*(__float128*)x)).backend().value();
}





void LibQReal_SinPi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = sin_pi(float128(*(__float128*)x)).backend().value();
}



void LibQReal_CosPi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = cos_pi(float128(*(__float128*)x)).backend().value();
}



void LibQReal_TanPi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = sin_pi(float128(*(__float128*)x)).backend().value()
                        / cos_pi(float128(*(__float128*)x)).backend().value();
}



void LibQReal_CscPi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0) / sin_pi(float128(*(__float128*)x)).backend().value();
}



void LibQReal_SecPi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = (1.0) / cos_pi(float128(*(__float128*)x)).backend().value();
}



void LibQReal_CotPi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = cos_pi(float128(*(__float128*)x)).backend().value()
                        / sin_pi(float128(*(__float128*)x)).backend().value();
}






void LibQReal_SincPi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = sinc_pi(float128(*(__float128*)x)).backend().value();
}



void LibQReal_SinhcPi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = sinhc_pi(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Tgamma_(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = tgamma(float128(*(__float128*)x)).backend().value();
}


void LibQReal_Tgamma1pm1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = tgamma1pm1(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Lgamma_(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = lgamma(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Digamma(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = digamma(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Trigamma(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = trigamma(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Factorial(QRealPtr res, const QRealPtr x)
{
    float128 xt = float128(*(__float128*)x);
    float128 result = tgamma(xt + 1);
	(*(__float128*)res) = result.backend().value();
}



void LibQReal_DoubleFactorial(QRealPtr res, const QRealPtr x)
{
    float128 xt = float128(*(__float128*)x);
    float128 xt2 = xt/2;
    float128 t1 = (cos_pi(xt)-1)/4;
    float128 pi2 = constants::half_pi<float128>();
    float128 t2 = pow(pi2, t1);
    float128 result = exp2(xt2) * t2 * tgamma(xt2+1);
	(*(__float128*)res) = result.backend().value();
}





void LibQReal_Erf_(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = erf(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Erfc_(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = erfc(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Erf_inv(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = erf_inv(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Erfc_inv(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = erfc_inv(float128(*(__float128*)x)).backend().value();
}



void LibQReal_AiryAi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = airy_ai(float128(*(__float128*)x)).backend().value();
}



void LibQReal_AiryBi(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = airy_bi(float128(*(__float128*)x)).backend().value();
}



void LibQReal_AiryAiPrime(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = airy_ai_prime(float128(*(__float128*)x)).backend().value();
}



void LibQReal_AiryBiPrime(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = airy_bi_prime(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Aizero(QRealPtr res, const int n)
{
	(*(__float128*)res) = airy_ai_zero<float128>(n).backend().value();
}



void LibQReal_Bizero(QRealPtr res, const int n)
{
	(*(__float128*)res) = airy_bi_zero<float128>(n).backend().value();
}



void LibQReal_Ellint_1_K(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = ellint_1(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Ellint_2_K(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = ellint_2(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Zeta(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = zeta(float128(*(__float128*)x)).backend().value();
}



void LibQReal_Ei(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = expint(float128(*(__float128*)x)).backend().value();
}



void LibQReal_LambertW0(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = lambert_w0(float128(*(__float128*)x)).backend().value();
}


void LibQReal_LambertWm1(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = lambert_wm1(float128(*(__float128*)x)).backend().value();
}



void LibQReal_LambertW0Prime(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = lambert_w0_prime(float128(*(__float128*)x)).backend().value();
}


void LibQReal_LambertWm1Prime(QRealPtr res, const QRealPtr x)
{
	(*(__float128*)res) = lambert_wm1_prime(float128(*(__float128*)x)).backend().value();
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void LibQReal_Agm(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
	(*(__float128*)res) = agm(float128(*(__float128*)a), float128(*(__float128*)b)).backend().value();
}





void LibQReal_Powm1(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
	(*(__float128*)res) = powm1(float128(*(__float128*)a), float128(*(__float128*)b)).backend().value();
}



void LibQReal_TgammaRatio(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
	(*(__float128*)res) = tgamma_ratio(float128(*(__float128*)a), float128(*(__float128*)b)).backend().value();
}



void LibQReal_TgammaDeltaRatio(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
	(*(__float128*)res) = tgamma_delta_ratio(float128(*(__float128*)a), float128(*(__float128*)b)).backend().value();
}



void LibQReal_Binomial(QRealPtr res, const QRealPtr n, const QRealPtr k)
{
    float128 nt = float128(*(__float128*)n);
    float128 kt = float128(*(__float128*)k);
    float128 result = tgamma(nt+1) / ( tgamma(kt+1) * tgamma(nt-kt+1) );
	(*(__float128*)res) = result.backend().value();
}

void LibQReal_RisingFactorial(QRealPtr res, const QRealPtr x, const QRealPtr n)
{
    float128 xt = float128(*(__float128*)x);
    float128 nt = float128(*(__float128*)n);
    float128 result = tgamma(xt+nt) / tgamma(xt);
	(*(__float128*)res) = result.backend().value();
}




void LibQReal_FallingFactorial(QRealPtr res, const QRealPtr x, const QRealPtr n)
{
    float128 xt = float128(*(__float128*)x);
    float128 nt = float128(*(__float128*)n);
    float128 result = tgamma(xt+1) / tgamma(xt-nt+1);
	(*(__float128*)res) = result.backend().value();
}




void LibQReal_BesselJ(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
	(*(__float128*)res) = cyl_bessel_j(float128(*(__float128*)v), float128(*(__float128*)x)).backend().value();
}



void LibQReal_BesselY(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
	(*(__float128*)res) = cyl_neumann(float128(*(__float128*)v), float128(*(__float128*)x)).backend().value();
}



void LibQReal_BesselI(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
	(*(__float128*)res) = cyl_bessel_i(float128(*(__float128*)v), float128(*(__float128*)x)).backend().value();
}



void LibQReal_BesselK(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
	(*(__float128*)res) = cyl_bessel_k(float128(*(__float128*)v), float128(*(__float128*)x)).backend().value();
}



void LibQReal_SphBessel(QRealPtr res, const unsigned v, const QRealPtr x)
{
	(*(__float128*)res) = sph_bessel(v, float128(*(__float128*)x)).backend().value();
}



void LibQReal_SphNeumann(QRealPtr res, const unsigned v, const QRealPtr x)
{
	(*(__float128*)res) = sph_neumann(v, float128(*(__float128*)x)).backend().value();
}





void LibQReal_BesselJPrime(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
	(*(__float128*)res) = cyl_bessel_j_prime(float128(*(__float128*)v), float128(*(__float128*)x)).backend().value();
}



void LibQReal_BesselYPrime(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
	(*(__float128*)res) = cyl_neumann_prime(float128(*(__float128*)v), float128(*(__float128*)x)).backend().value();
}



void LibQReal_BesselIPrime(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
	(*(__float128*)res) = cyl_bessel_i_prime(float128(*(__float128*)v), float128(*(__float128*)x)).backend().value();
}



void LibQReal_BesselKPrime(QRealPtr res, const QRealPtr v, const QRealPtr x)
{
	(*(__float128*)res) = cyl_bessel_k_prime(float128(*(__float128*)v), float128(*(__float128*)x)).backend().value();
}



void LibQReal_SphBesselPrime(QRealPtr res, const unsigned v, const QRealPtr x)
{
	(*(__float128*)res) = sph_bessel_prime(v, float128(*(__float128*)x)).backend().value();
}



void LibQReal_SphNeumannPrime(QRealPtr res, const unsigned v, const QRealPtr x)
{
	(*(__float128*)res) = sph_neumann_prime(v, float128(*(__float128*)x)).backend().value();
}





void LibQReal_BesselJZero(QRealPtr res, const QRealPtr v, const int m)
{
	(*(__float128*)res) = cyl_bessel_j_zero(float128(*(__float128*)v), m).backend().value();
}



void LibQReal_BesselYZero(QRealPtr res, const QRealPtr v, const int m)
{
	(*(__float128*)res) = cyl_neumann_zero(float128(*(__float128*)v), m).backend().value();
}





void LibQReal_GammaP(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
	(*(__float128*)res) = gamma_p(float128(*(__float128*)a), float128(*(__float128*)x)).backend().value();
}


void LibQReal_GammaQ(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
	(*(__float128*)res) = gamma_q(float128(*(__float128*)a), float128(*(__float128*)x)).backend().value();
}


void LibQReal_TgammaLower(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
	(*(__float128*)res) = tgamma_lower(float128(*(__float128*)a), float128(*(__float128*)x)).backend().value();
}


void LibQReal_TgammaUpper(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
	(*(__float128*)res) = tgamma(float128(*(__float128*)a), float128(*(__float128*)x)).backend().value();
}




void LibQReal_GammaPInv(QRealPtr res, const QRealPtr a, const QRealPtr p)
{
	(*(__float128*)res) = gamma_p_inv(float128(*(__float128*)a), float128(*(__float128*)p)).backend().value();
}


void LibQReal_GammaQInv(QRealPtr res, const QRealPtr a, const QRealPtr q)
{
	(*(__float128*)res) = gamma_q_inv(float128(*(__float128*)a), float128(*(__float128*)q)).backend().value();
}


void LibQReal_GammaPInva(QRealPtr res, const QRealPtr x, const QRealPtr p)
{
	(*(__float128*)res) = gamma_p_inva(float128(*(__float128*)x), float128(*(__float128*)p)).backend().value();
}


void LibQReal_GammaQInva(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
	(*(__float128*)res) = gamma_q_inva(float128(*(__float128*)x), float128(*(__float128*)q)).backend().value();
}



void LibQReal_GammaPDerivative(QRealPtr res, const QRealPtr a, const QRealPtr x)
{
	(*(__float128*)res) = gamma_p_derivative(float128(*(__float128*)a), float128(*(__float128*)x)).backend().value();
}


void LibQReal_Beta(QRealPtr res, const QRealPtr a, const QRealPtr b)
{
	(*(__float128*)res) = beta(float128(*(__float128*)a), float128(*(__float128*)b)).backend().value();
}









void LibQReal_LegendreP(QRealPtr res, int n, const QRealPtr x)
{
	(*(__float128*)res) = legendre_p(n, float128(*(__float128*)x)).backend().value();
}



void LibQReal_LegendreQ(QRealPtr res, int n, const QRealPtr x)
{
	(*(__float128*)res) = legendre_q(n, float128(*(__float128*)x)).backend().value();
}



void LibQReal_Laguerre(QRealPtr res, int n, const QRealPtr x)
{
	(*(__float128*)res) = laguerre(n, float128(*(__float128*)x)).backend().value();
}



void LibQReal_Hermite(QRealPtr res, int n, const QRealPtr x)
{
	(*(__float128*)res) = hermite(n, float128(*(__float128*)x)).backend().value();
}



void LibQReal_ChebyshevT(QRealPtr res, int n, const QRealPtr x)
{
	(*(__float128*)res) = chebyshev_t(n, float128(*(__float128*)x)).backend().value();
}


void LibQReal_ChebyshevU(QRealPtr res, int n, const QRealPtr x)
{
	(*(__float128*)res) = chebyshev_u(n, float128(*(__float128*)x)).backend().value();
}



void LibQReal_Polygamma(QRealPtr res, int n, const QRealPtr x)
{
	(*(__float128*)res) = polygamma(n, float128(*(__float128*)x)).backend().value();
}





void LibQReal_EllintRC(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	(*(__float128*)res) = ellint_rc(float128(*(__float128*)x), float128(*(__float128*)y)).backend().value();
}


void LibQReal_Ellint1F(QRealPtr res, const QRealPtr k, const QRealPtr phi)
{
	(*(__float128*)res) = ellint_1(float128(*(__float128*)k), float128(*(__float128*)phi)).backend().value();
}


void LibQReal_Ellint2F(QRealPtr res, const QRealPtr k, const QRealPtr phi)
{
	(*(__float128*)res) = ellint_2(float128(*(__float128*)k), float128(*(__float128*)phi)).backend().value();
}


void LibQReal_Ellint3K(QRealPtr res, const QRealPtr k, const QRealPtr n)
{
	(*(__float128*)res) = ellint_3(float128(*(__float128*)k), float128(*(__float128*)n)).backend().value();
}




void LibQReal_JacobiCD(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_cd(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiCN(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_cn(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiCS(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_cs(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiDC(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_dc(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiDN(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_dn(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiDS(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_ds(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiNC(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_nc(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiND(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_nd(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiNS(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_ns(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiSC(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_sc(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiSD(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_sd(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}


void LibQReal_JacobiSN(QRealPtr res, const QRealPtr k, const QRealPtr u)
{
	(*(__float128*)res) = jacobi_sn(float128(*(__float128*)k), float128(*(__float128*)u)).backend().value();
}



void LibQReal_expint(QRealPtr res, const unsigned n, const QRealPtr x)
{
	(*(__float128*)res) = expint(n, float128(*(__float128*)x)).backend().value();
}




void LibQReal_OwenT(QRealPtr res, const QRealPtr h, const QRealPtr a)
{
	(*(__float128*)res) = owens_t(float128(*(__float128*)h), float128(*(__float128*)a)).backend().value();
}





void LibQReal_IBeta(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = ibeta(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}


void LibQReal_IBetac(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = ibetac(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}


void LibQReal_IBetaNonNormalized(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = beta(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}


void LibQReal_IBetacNonNormalized(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = betac(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}


void LibQReal_IBetaInv(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr p)
{
	(*(__float128*)res) = ibeta_inv(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)p)).backend().value();
}


void LibQReal_IBetacInv(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr q)
{
	(*(__float128*)res) = ibetac_inv(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)q)).backend().value();
}


void LibQReal_IBetaInva(QRealPtr res, const QRealPtr b, const QRealPtr x, const QRealPtr p)
{
	(*(__float128*)res) = ibeta_inva(float128(*(__float128*)b), float128(*(__float128*)x), float128(*(__float128*)p)).backend().value();
}


void LibQReal_IBetacInva(QRealPtr res, const QRealPtr b, const QRealPtr x, const QRealPtr q)
{
	(*(__float128*)res) = ibetac_inva(float128(*(__float128*)b), float128(*(__float128*)x), float128(*(__float128*)q)).backend().value();
}


void LibQReal_IBetaInvb(QRealPtr res, const QRealPtr a, const QRealPtr x, const QRealPtr p)
{
	(*(__float128*)res) = ibeta_invb(float128(*(__float128*)a), float128(*(__float128*)x), float128(*(__float128*)p)).backend().value();
}


void LibQReal_IBetacInvb(QRealPtr res, const QRealPtr a, const QRealPtr x, const QRealPtr q)
{
	(*(__float128*)res) = ibetac_invb(float128(*(__float128*)a), float128(*(__float128*)x), float128(*(__float128*)q)).backend().value();
}


void LibQReal_IBetaDerivative(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = ibeta_derivative(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}




void LibQReal_LegendrePM(QRealPtr res, const int n, const int m, const QRealPtr x)
{
	(*(__float128*)res) = legendre_p(n, m, float128(*(__float128*)x)).backend().value();
}



void LibQReal_LaguerreM(QRealPtr res, const int n, const int m, const QRealPtr x)
{
	(*(__float128*)res) = laguerre(n, m, float128(*(__float128*)x)).backend().value();
}





void LibQReal_EllipticRF(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z)
{
	(*(__float128*)res) = ellint_rf(float128(*(__float128*)x), float128(*(__float128*)y), float128(*(__float128*)z)).backend().value();
}



void LibQReal_EllipticRD(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z)
{
	(*(__float128*)res) = ellint_rd(float128(*(__float128*)x), float128(*(__float128*)y), float128(*(__float128*)z)).backend().value();
}



void LibQReal_EllipticRG(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z)
{
	(*(__float128*)res) = ellint_rg(float128(*(__float128*)x), float128(*(__float128*)y), float128(*(__float128*)z)).backend().value();
}



void LibQReal_Ellint3F(QRealPtr res, const QRealPtr k, const QRealPtr n, const QRealPtr phi)
{
	(*(__float128*)res) = ellint_3(float128(*(__float128*)k), float128(*(__float128*)n), float128(*(__float128*)phi)).backend().value();
}




void LibQReal_Gegenbauer(QRealPtr res, const int n, const QRealPtr lambda, const QRealPtr x)
{
	(*(__float128*)res) = boost::math::gegenbauer(n, float128(*(__float128*)lambda), float128(*(__float128*)x)).backend().value();;
}



void LibQReal_Jacobi(QRealPtr res, const int n, const QRealPtr alpha, const QRealPtr beta, const QRealPtr x)
{
	(*(__float128*)res) = boost::math::jacobi(n, float128(*(__float128*)alpha), float128(*(__float128*)beta), float128(*(__float128*)x)).backend().value();;
}







void LibQReal_SphericalHarmonicR(QRealPtr res, const int n, const int m, const QRealPtr theta, const QRealPtr phi)
{
	(*(__float128*)res) = spherical_harmonic_r(n, m, float128(*(__float128*)theta), float128(*(__float128*)phi)).backend().value();
}


void LibQReal_SphericalHarmonicI(QRealPtr res, const int n, const int m, const QRealPtr theta, const QRealPtr phi)
{
	(*(__float128*)res) = spherical_harmonic_i(n, m, float128(*(__float128*)theta), float128(*(__float128*)phi)).backend().value();
}


void LibQReal_EllipticRJ(QRealPtr res, const QRealPtr x, const QRealPtr y, const QRealPtr z, const QRealPtr p)
{
	(*(__float128*)res) = ellint_rj(float128(*(__float128*)x), float128(*(__float128*)y), float128(*(__float128*)z), float128(*(__float128*)p)).backend().value();
}


// Hypergeometric and Theta Functions




void LibQReal_Hypergeo0F1(QRealPtr res, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = hypergeometric_0F1(float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}



void LibQReal_Hypergeo1F1(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = hypergeometric_1F1(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}



void LibQReal_Hypergeo1F1r(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = hypergeometric_1F1_regularized(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}



void LibQReal_LogHypergeo1F1(QRealPtr res, const QRealPtr a, const QRealPtr b, const QRealPtr x)
{
	(*(__float128*)res) = log_hypergeometric_1F1(float128(*(__float128*)a), float128(*(__float128*)b), float128(*(__float128*)x)).backend().value();
}





void LibQReal_JacobiTheta1(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
	(*(__float128*)res) = jacobi_theta1(float128(*(__float128*)x), float128(*(__float128*)q)).backend().value();
}


void LibQReal_JacobiTheta2(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
	(*(__float128*)res) = jacobi_theta2(float128(*(__float128*)x), float128(*(__float128*)q)).backend().value();
}


void LibQReal_JacobiTheta3(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
	(*(__float128*)res) = jacobi_theta3(float128(*(__float128*)x), float128(*(__float128*)q)).backend().value();
}


void LibQReal_JacobiTheta4(QRealPtr res, const QRealPtr x, const QRealPtr q)
{
	(*(__float128*)res) = jacobi_theta4(float128(*(__float128*)x), float128(*(__float128*)q)).backend().value();
}






//*********************** Extra, quadruple precision **********************************





void LibQReal_ShowQuadNet(char* cstr, QRealPtr x)
{
    float128 x1 = (*(float128*)x);
    std::stringstream ss;
    ss.precision(std::numeric_limits<float128>::digits10+0);
    //ss << std::showpoint; // Append any trailing zeros.
    ss << x1 ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}





void LibQReal_Inf(QRealPtr res)
{
    float128 inf = std::numeric_limits<float128>::infinity();
	(*(__float128*)res) = inf.backend().value();
}


void LibQReal_NegInf(QRealPtr res)
{
    float128 neginf = -std::numeric_limits<float128>::infinity();
	(*(__float128*)res) = neginf.backend().value();
}


void LibQReal_Nan(QRealPtr res)
{
    float128 NaN = std::numeric_limits<float128>::quiet_NaN();
	(*(__float128*)res) = NaN.backend().value();
}


void LibQReal_Lowest(QRealPtr res)
{
	float128 low = (std::numeric_limits<float128>::lowest)();
	(*(__float128*)res) = low.backend().value();
}



int LibQReal_Isnormal(QRealPtr x)
{
    float128 x1 = (*(float128*)x);
    return boost::math::isnormal<float128>(x1);
}



int LibQReal_Issubnormal(QRealPtr x)
{
    float128 x1 = (*(float128*)x);
    return boost::math::fpclassify<float128>(x1) == FP_SUBNORMAL;
}





void LibQReal_Nextafter(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	float128 res1 = nextafter( (*(float128*)x) , (*(float128*)y) );
	(*(__float128*)res) = res1.backend().value();
}


void LibQReal_Nexttowards(QRealPtr res, const QRealPtr x, const QRealPtr y)
{
	float128 res1 = nextafter( (*(float128*)x) , (*(float128*)y) );
	(*(__float128*)res) = res1.backend().value();
}


void LibQReal_Nextabove(QRealPtr res, const QRealPtr x)
{
	float128 res1 = nextafter( (*(float128*)x) , std::numeric_limits<float128>::infinity() );
	(*(__float128*)res) = res1.backend().value();
}


void LibQReal_Nextbelow(QRealPtr res, const QRealPtr x)
{
	float128 res1 = nextafter( (*(float128*)x) , -std::numeric_limits<float128>::infinity() );
	(*(__float128*)res) = res1.backend().value();
}





