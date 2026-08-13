


// See also: https://www.boost.org/doc/libs/1_80_0/boost/math/tools/user.hpp

// \home\MP64\math-boost\include\boost\math\tools\user.hpp

// Note: in exp_sinh_detail.hpp, line 229 changed to Real abterm1  [[maybe_unused]] = 1;

// Note: in fisher_f.hpp, line 247,  changed to    RealType x, y = 0;


#include <boost/math/tools/user.hpp>
#include <boost/math/tools/config.hpp>

#include "BoostYReal.h"

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
    cpp_dec_float_50 result = 0; \
    std::pair<cpp_dec_float_50, cpp_dec_float_50> dist_pair; \
    cpp_dec_float_50 xqp1 = cpp_dec_float_50(*(cpp_dec_float_50*)xqp); \
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
    (*(cpp_dec_float_50*)res) = result;


#include <boost/math/tools/minima.hpp>
#include <boost/math/tools/roots.hpp>
#include <tuple> // for std::tuple and std::make_tuple.
#include <boost/math/constants/constants.hpp>
#include <boost/math/special_functions.hpp>
#include <boost/math/distributions.hpp>
#include <boost/multiprecision/cpp_dec_float.hpp>

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

#include "include/cppoptlib/meta.h"
#include "include/cppoptlib/problem.h"
#include "include/cppoptlib/solver/gradientdescentsolver.h"
#include "include/cppoptlib/solver/conjugatedgradientdescentsolver.h"
#include "include/cppoptlib/solver/bfgssolver.h"
#include "include/cppoptlib/solver/lbfgssolver.h"



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



//*********************** Boost/CppOptLib **********************************

using namespace Eigen;
using namespace cppoptlib;
typedef Matrix<cpp_dec_float_50, Dynamic, 1> state_type_vec;
typedef state_type_vec* mpVectorPtr;


template<typename T>
class CppOptLibSolver : public Problem<T>
{
    public:
    using typename cppoptlib::Problem<T>::TVector;
    using typename cppoptlib::Problem<T>::THessian;
    CppOptLibSolver(YRealFuncPtr f1, YRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_)
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
  YRealFuncPtr func1, func2;
  mpVectorPtr matX, matGrad, matNorm;
};


void LibYReal_GradientDescentSolverSolver(YRealFuncPtr f1, YRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr)
{
 printf("GradientDescentSolver");
    typedef   CppOptLibSolver<cpp_dec_float_50>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_, (mpVectorPtr)matNorm_);
    state_type_vec x = (*(mpVectorPtr)xPtr);
    GradientDescentSolver<TCppOptLibSolver> solver;
    cpp_dec_float_50 eps = std::numeric_limits<cpp_dec_float_50>::epsilon();
    Criteria<cpp_dec_float_50> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);
    solver.minimize(f, x);
    (*(mpVectorPtr)matX_) = x;
    (*(mpVectorPtr)matNorm_)(0) = f(x);
}


void LibYReal_ConjugatedGradientDescentSolver(YRealFuncPtr f1, YRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr)
{
 printf("ConjugatedGradientDescentSolver");
    typedef   CppOptLibSolver<cpp_dec_float_50>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_, (mpVectorPtr)matNorm_);
    state_type_vec x = (*(mpVectorPtr)xPtr);
    ConjugatedGradientDescentSolver<TCppOptLibSolver> solver;
    cpp_dec_float_50 eps = std::numeric_limits<cpp_dec_float_50>::epsilon();
    Criteria<cpp_dec_float_50> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);
    solver.minimize(f, x);
    (*(mpVectorPtr)matX_) = x;
    (*(mpVectorPtr)matNorm_)(0) = f(x);
}




//void LibYReal_ConjugatedGradientDescentSolver(YRealFuncPtr f1, YRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr)
//{
//
// printf("ConjugatedGradientDescentSolver");
//    typedef   CppOptLibSolver<cpp_dec_float_50>  TCppOptLibSolver;
//    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
//    state_type_vec x = (*xPtr);
//    ConjugatedGradientDescentSolver<TCppOptLibSolver> solver;
//
//    cpp_dec_float_50 eps = std::numeric_limits<cpp_dec_float_50>::epsilon();
//    Criteria<cpp_dec_float_50> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//
//    solver.minimize(f, x);
//
//    (*matX_) = x;
//    (*matNorm_)(0) = f(x);
//}




void LibYReal_BfgsSolver(YRealFuncPtr f1, YRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr)
{
 printf("BfgsSolver");
    typedef   CppOptLibSolver<cpp_dec_float_50>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_, (mpVectorPtr)matNorm_);
    state_type_vec x = (*(mpVectorPtr)xPtr);
    BfgsSolver<TCppOptLibSolver> solver;
    cpp_dec_float_50 eps = std::numeric_limits<cpp_dec_float_50>::epsilon();
    Criteria<cpp_dec_float_50> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);
    solver.minimize(f, x);
    (*(mpVectorPtr)matX_) = x;
    (*(mpVectorPtr)matNorm_)(0) = f(x);
}


//void LibYReal_BfgsSolver(YRealFuncPtr f1, YRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr)
//{
//
// printf("BfgsSolver");
//    typedef   CppOptLibSolver<cpp_dec_float_50>  TCppOptLibSolver;
//    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
//    state_type_vec x = (*xPtr);
//    BfgsSolver<TCppOptLibSolver> solver;
//
////    std::cout.precision(30);
//    cpp_dec_float_50 eps = std::numeric_limits<cpp_dec_float_50>::epsilon();
////    std::cout << "epsilon() = " << eps << std::endl;
////    std::cout << "\n";
//
//    Criteria<cpp_dec_float_50> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//
//    solver.minimize(f, x);
//
//    (*matX_) = x;
//    (*matNorm_)(0) = f(x);
//}




void LibYReal_LbfgsSolver(YRealFuncPtr f1, YRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr)
{
 printf("LbfgsSolver");
    typedef   CppOptLibSolver<cpp_dec_float_50>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_, (mpVectorPtr)matNorm_);
    state_type_vec x = (*(mpVectorPtr)xPtr);
    LbfgsSolver<TCppOptLibSolver> solver;
    cpp_dec_float_50 eps = std::numeric_limits<cpp_dec_float_50>::epsilon();
    Criteria<cpp_dec_float_50> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);
    solver.minimize(f, x);
    (*(mpVectorPtr)matX_) = x;
    (*(mpVectorPtr)matNorm_)(0) = f(x);
}


void LibYReal_LbfgsSolver(YRealFuncPtr f1, YRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr)
{

 printf("LbfgsSolver");
    typedef   CppOptLibSolver<cpp_dec_float_50>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
    state_type_vec x = (*xPtr);
    LbfgsSolver<TCppOptLibSolver> solver;

    cpp_dec_float_50 eps = std::numeric_limits<cpp_dec_float_50>::epsilon();
    Criteria<cpp_dec_float_50> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);

    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0) = f(x);
}







//*********************** Boost Odeint **********************************

using namespace boost::numeric::odeint;

DStatePtr LibYReal_StateInit_Func_N(int N)
{
    mpVectorPtr x = new(state_type_vec);
    (*x).resize(N);
    (*x).setZero();
    return x;
}


void LibYReal_StateClear(DStatePtr x)
{
    delete ((mpVectorPtr)x);
}


void LibYReal_StateGetCoeff(YRealPtr res, long row, DStatePtr source)
{
    (*(cpp_dec_float_50*)res) = (*(mpVectorPtr) source).coeff(row);
}



void LibYReal_StateSetCoeff(DStatePtr result, YRealPtr source, long row)
{
    (*(mpVectorPtr) result)(row) = *(cpp_dec_float_50*)source;
}

void LibYReal_StateGetSize(long *result, DStatePtr x)
{
    *result = (long)(*(mpVectorPtr)x).size();
}







struct Boost_LibYReal_Write
{
	Boost_LibYReal_Write(DAnyFuncPtr2 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, const cpp_dec_float_50 t)
	{
	    cpp_dec_float_50 fx = t;
		func1(&x, &fx);
	}
	DAnyFuncPtr2 func1;
};


struct Boost_LibYReal_Func_Vec
{
	Boost_LibYReal_Func_Vec(DAnyFuncPtr3 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, state_type_vec &dxdt, cpp_dec_float_50 t) const
	{
	    cpp_dec_float_50 fx = t;
		func1(&x, &dxdt, &fx);
	}
	DAnyFuncPtr3 func1;
};




/* Constant steppers */

void LibYReal_Const_RungeKutta4(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
	integrate_const(runge_kutta4<state_type_vec, cpp_dec_float_50>(), Boost_LibYReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibYReal_Write(f2));
}

void LibYReal_Const_RungeKuttaCashKarp54(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
	integrate_const(runge_kutta_cash_karp54<state_type_vec, cpp_dec_float_50>(), Boost_LibYReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibYReal_Write(f2));
}

void LibYReal_Const_RungeKuttaDopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
	integrate_const(runge_kutta_dopri5<state_type_vec, cpp_dec_float_50>(), Boost_LibYReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibYReal_Write(f2));
}

void LibYReal_Const_RungeKuttaFehlberg78(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
	integrate_const(runge_kutta_fehlberg78<state_type_vec, cpp_dec_float_50>(), Boost_LibYReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibYReal_Write(f2));
}

void LibYReal_Const_AdamsBashforthMoulton(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
	integrate_const(adams_bashforth_moulton<5, state_type_vec, cpp_dec_float_50>(), Boost_LibYReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibYReal_Write(f2));
}


/* Adaptive steppers */

void LibYReal_Adaptive_RungeKuttaDopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
    cpp_dec_float_50 eps_abs = *(cpp_dec_float_50*)eps_abs_;
    cpp_dec_float_50 eps_rel = *(cpp_dec_float_50*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_dopri5<state_type_vec, cpp_dec_float_50>() ) , Boost_LibYReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibYReal_Write(f2));
}


void LibYReal_Adaptive_RungeKuttaCashKarp54(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
    cpp_dec_float_50 eps_abs = *(cpp_dec_float_50*)eps_abs_;
    cpp_dec_float_50 eps_rel = *(cpp_dec_float_50*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_cash_karp54<state_type_vec, cpp_dec_float_50>() ) , Boost_LibYReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibYReal_Write(f2));
}


void LibYReal_Adaptive_RungeKuttaFehlberg78(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
    cpp_dec_float_50 eps_abs = *(cpp_dec_float_50*)eps_abs_;
    cpp_dec_float_50 eps_rel = *(cpp_dec_float_50*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_fehlberg78<state_type_vec, cpp_dec_float_50>() ) , Boost_LibYReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibYReal_Write(f2));
}


void LibYReal_Adaptive_BulirschStoer(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
    cpp_dec_float_50 eps_abs = *(cpp_dec_float_50*)eps_abs_;
    cpp_dec_float_50 eps_rel = *(cpp_dec_float_50*)eps_rel_;

	bulirsch_stoer< state_type_vec, cpp_dec_float_50 > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibYReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibYReal_Write(f2));
}

/* Dense Output steppers */


void LibYReal_DenseOutput_Dopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
    cpp_dec_float_50 eps_abs = *(cpp_dec_float_50*)eps_abs_;
    cpp_dec_float_50 eps_rel = *(cpp_dec_float_50*)eps_rel_;

    typedef runge_kutta_dopri5< state_type_vec, cpp_dec_float_50 > dopri5_type;
    typedef controlled_runge_kutta< dopri5_type > controlled_dopri5_type;
    typedef dense_output_runge_kutta< controlled_dopri5_type > dense_output_dopri5_type;
    dense_output_dopri5_type dopri5 = make_dense_output( eps_abs , eps_rel , dopri5_type() );
    integrate_adaptive( dopri5, Boost_LibYReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibYReal_Write(f2));
}


void LibYReal_DenseOutput_BulirschStoer(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, YRealPtr start_time_, YRealPtr end_time_, YRealPtr dt_, YRealPtr eps_abs_, YRealPtr eps_rel_)
{
    cpp_dec_float_50 start_time = *(cpp_dec_float_50*)start_time_;
    cpp_dec_float_50 end_time = *(cpp_dec_float_50*)end_time_;
    cpp_dec_float_50 dt = *(cpp_dec_float_50*)dt_;
    cpp_dec_float_50 eps_abs = *(cpp_dec_float_50*)eps_abs_;
    cpp_dec_float_50 eps_rel = *(cpp_dec_float_50*)eps_rel_;

	bulirsch_stoer_dense_out< state_type_vec, cpp_dec_float_50 > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibYReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibYReal_Write(f2));
}







//*********************** Boost Numerical Calculus, YReal **********************************




struct YRealFunctor1
{
  YRealFunctor1(YRealFuncPtr f1):func1(f1) {}
  cpp_dec_float_50 operator()(cpp_dec_float_50 x)
  {
    cpp_dec_float_50 fx;
	func1( &x, &fx);
    return fx;
  }
private:
	YRealFuncPtr func1;
};


struct YRealFunctor2
{
  YRealFunctor2(YRealFuncPtr f1, YRealFuncPtr f2):func1(f1), func2(f2) {}
  std::pair<cpp_dec_float_50, cpp_dec_float_50> operator()(cpp_dec_float_50 x)
  {
    cpp_dec_float_50 fx, dx;
	func1( &x, &fx);
	func2( &x, &dx);
    return std::make_pair(fx, dx);
  }
private:
	YRealFuncPtr func1, func2;
};


struct YRealFunctor3
{
  YRealFunctor3(YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3):func1(f1), func2(f2), func3(f3) {}
  std::tuple<cpp_dec_float_50, cpp_dec_float_50, cpp_dec_float_50> operator()(cpp_dec_float_50 x)
  {
    cpp_dec_float_50 fx, dx, d2x;
	func1( &x, &fx);
	func2( &x, &dx);
	func3( &x, &d2x);
    return std::make_tuple(fx, dx, d2x);
  }
private:
	YRealFuncPtr func1, func2, func3;
};



void LibYReal_BracketRoot(YRealPtr res1, YRealPtr res2, int* iter, YRealFuncPtr f1, YRealPtr guess_, YRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    cpp_dec_float_50 guess = *(cpp_dec_float_50*)guess_;
    cpp_dec_float_50 factor = *(cpp_dec_float_50*)factor_;
	uintmax_t it = maxit;
	eps_tolerance<cpp_dec_float_50> tol(get_digits);
	std::pair<cpp_dec_float_50, cpp_dec_float_50> r = bracket_and_solve_root(YRealFunctor1(f1), guess, factor, is_rising, tol, it);
	cpp_dec_float_50 error = (r.second - r.first) / 2;
	cpp_dec_float_50 result = r.first + error;
    (*(cpp_dec_float_50*)res1) = result;
    (*(cpp_dec_float_50*)res2) = error;
    *iter = (int) it;
}



void LibYReal_NewtonRaphson(YRealPtr res,  int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_dec_float_50 guess = *(cpp_dec_float_50*)guess_;
    cpp_dec_float_50 xmin = *(cpp_dec_float_50*)xmin_;
    cpp_dec_float_50 xmax = *(cpp_dec_float_50*)xmax_;
    uintmax_t it = maxit;
    cpp_dec_float_50 result = newton_raphson_iterate(YRealFunctor2(f1, f2), guess, xmin, xmax, get_digits, it);
    (*(cpp_dec_float_50*)res) = result;
    *iter = (int) it;
}



void LibYReal_Halley(YRealPtr res, int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_dec_float_50 guess = *(cpp_dec_float_50*)guess_;
    cpp_dec_float_50 xmin = *(cpp_dec_float_50*)xmin_;
    cpp_dec_float_50 xmax = *(cpp_dec_float_50*)xmax_;
    uintmax_t it = maxit;
    cpp_dec_float_50 result = halley_iterate(YRealFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
    (*(cpp_dec_float_50*)res) = result;
    *iter = (int) it;
}



void LibYReal_Schroder(YRealPtr res, int* iter, YRealFuncPtr f1, YRealFuncPtr f2, YRealFuncPtr f3, YRealPtr guess_, YRealPtr xmin_, YRealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_dec_float_50 guess = *(cpp_dec_float_50*)guess_;
    cpp_dec_float_50 xmin = *(cpp_dec_float_50*)xmin_;
    cpp_dec_float_50 xmax = *(cpp_dec_float_50*)xmax_;
    uintmax_t it = maxit;
    cpp_dec_float_50 result = schroder_iterate(YRealFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
    (*(cpp_dec_float_50*)res) = result;
    *iter = (int) it;
}



void LibYReal_Brent_Minimum(YRealPtr res, YRealPtr resFx, int* iter, YRealFuncPtr f1, YRealPtr bracket_min_, YRealPtr bracket_max_, int bits, unsigned int maxit)
{
    cpp_dec_float_50 bracket_min = *(cpp_dec_float_50*)bracket_min_;
    cpp_dec_float_50 bracket_max = *(cpp_dec_float_50*)bracket_max_;
    uintmax_t it = maxit;
    std::pair<cpp_dec_float_50, cpp_dec_float_50> r = brent_find_minima(YRealFunctor1(f1), bracket_min, bracket_max, bits, it);
    (*(cpp_dec_float_50*)res) = r.first;
    (*(cpp_dec_float_50*)resFx) = r.second;
    *iter = (int) it;
}





void LibYReal_Trapezoidal(YRealPtr res1, YRealPtr res2, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_)
{
    cpp_dec_float_50 a = *(cpp_dec_float_50*)a_;
    cpp_dec_float_50 b = *(cpp_dec_float_50*)b_;
    cpp_dec_float_50 tol = sqrt(std::numeric_limits<cpp_dec_float_50>::epsilon());
    cpp_dec_float_50 error;
    cpp_dec_float_50 L1;
    size_t max_refinements = 24;
    auto f = [&f1](cpp_dec_float_50 x) {
        cpp_dec_float_50 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_50 result = trapezoidal(f, a, b, tol, max_refinements, &error, &L1);
    (*(cpp_dec_float_50*)res1) = result;
    (*(cpp_dec_float_50*)res2) = error;
    (*(cpp_dec_float_50*)res3) = (L1/fabs(result));
}



// 7, 15, 20, 25 and 30

void LibYReal_GaussLegendre(YRealPtr res1, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_)
{
    cpp_dec_float_50 a = *(cpp_dec_float_50*)a_;
    cpp_dec_float_50 b = *(cpp_dec_float_50*)b_;
    cpp_dec_float_50 L1;
    auto f = [&f1](cpp_dec_float_50 x) {
        cpp_dec_float_50 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_50 result = gauss<cpp_dec_float_50, 7>::integrate(f, a, b, &L1);
    (*(cpp_dec_float_50*)res1) = result;
    (*(cpp_dec_float_50*)res3) = (L1/fabs(result));
}



//15, 31, 41, 51 and 61

void LibYReal_GaussKronrod(YRealPtr res1, YRealPtr res2, YRealPtr res3, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_)
{
    cpp_dec_float_50 a = *(cpp_dec_float_50*)a_;
    cpp_dec_float_50 b = *(cpp_dec_float_50*)b_;
    cpp_dec_float_50 tol = sqrt(std::numeric_limits<cpp_dec_float_50>::epsilon());
    cpp_dec_float_50 error;
    cpp_dec_float_50 L1;
    unsigned max_depth = 15;
    auto f = [&f1](cpp_dec_float_50 x) {
        cpp_dec_float_50 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_50 result = gauss_kronrod<cpp_dec_float_50, 15>::integrate(f, a, b, max_depth, tol, &error, &L1);
    (*(cpp_dec_float_50*)res1) = result;
    (*(cpp_dec_float_50*)res2) = error;
    (*(cpp_dec_float_50*)res3) = (L1/fabs(result));
}



void LibYReal_TanhSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1, YRealPtr a_, YRealPtr b_)
{
    cpp_dec_float_50 a = *(cpp_dec_float_50*)a_;
    cpp_dec_float_50 b = *(cpp_dec_float_50*)b_;
    tanh_sinh<cpp_dec_float_50> integrator;
    auto f = [&f1](cpp_dec_float_50 x) {
        cpp_dec_float_50 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_50 termination = sqrt(std::numeric_limits<cpp_dec_float_50>::epsilon());
    cpp_dec_float_50  error;
    cpp_dec_float_50  L1;
    std::size_t levels = 0;
    cpp_dec_float_50 result = integrator.integrate(f, a, b, termination, &error, &L1, &levels);
    (*(cpp_dec_float_50*)res1) = result;
    (*(cpp_dec_float_50*)res2) = error;
    (*(cpp_dec_float_50*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}




void LibYReal_SinhSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1)
{
    sinh_sinh<cpp_dec_float_50> integrator;
    auto f = [&f1](cpp_dec_float_50 x) {
        cpp_dec_float_50 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_50 termination = sqrt(std::numeric_limits<cpp_dec_float_50>::epsilon());
    cpp_dec_float_50  error;
    cpp_dec_float_50  L1;
    std::size_t levels = 0;
    cpp_dec_float_50 result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*(cpp_dec_float_50*)res1) = result;
    (*(cpp_dec_float_50*)res2) = error;
    (*(cpp_dec_float_50*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}



void LibYReal_ExpSinh(YRealPtr res1, YRealPtr res2, YRealPtr res3, int* levels_, YRealFuncPtr f1)
{
    exp_sinh<cpp_dec_float_50> integrator;
    auto f = [&f1](cpp_dec_float_50 x) {
        cpp_dec_float_50 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_50 termination = sqrt(std::numeric_limits<cpp_dec_float_50>::epsilon());
    cpp_dec_float_50  error;
    cpp_dec_float_50  L1;
    std::size_t levels = 0;
    cpp_dec_float_50 result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*(cpp_dec_float_50*)res1) = result;
    (*(cpp_dec_float_50*)res2) = error;
    (*(cpp_dec_float_50*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}



void LibYReal_Ooura_Cos(YRealPtr res1, YRealPtr res2, YRealFuncPtr f1)
{
    cpp_dec_float_50 omega = 1;
    cpp_dec_float_50 tol = 2 * sqrt(std::numeric_limits<cpp_dec_float_50>::epsilon());
	auto integrator = ooura_fourier_cos<cpp_dec_float_50>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](cpp_dec_float_50 x) {
        cpp_dec_float_50 fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<cpp_dec_float_50, cpp_dec_float_50> r = integrator.integrate(f, omega);
    (*(cpp_dec_float_50*)res1) =  r.first;
    (*(cpp_dec_float_50*)res2) =  r.second;
}



void LibYReal_Ooura_Sin(YRealPtr res1, YRealPtr res2, YRealFuncPtr f1)
{
    cpp_dec_float_50 omega = 1;
    cpp_dec_float_50 tol = 2 * sqrt(std::numeric_limits<cpp_dec_float_50>::epsilon());
	auto integrator = ooura_fourier_sin<cpp_dec_float_50>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](cpp_dec_float_50 x) {
        cpp_dec_float_50 fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<cpp_dec_float_50, cpp_dec_float_50> r = integrator.integrate(f, omega);
    (*(cpp_dec_float_50*)res1) =  r.first;
    (*(cpp_dec_float_50*)res2) =  r.second;
}




//***********************  Boost Distributions, YReal  **********************************


void LibYReal_ArcsineDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b)
{
    cpp_dec_float_50 a1 = *(cpp_dec_float_50*)a;
    cpp_dec_float_50 b1 = *(cpp_dec_float_50*)b;
    arcsine_distribution<cpp_dec_float_50> dist(a1, b1); MP_DIST_RETURN
}



void LibYReal_BernoulliDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr p)
{
    cpp_dec_float_50 p1 = *(cpp_dec_float_50*)p;
    bernoulli_distribution<cpp_dec_float_50> dist(p1); MP_DIST_RETURN
}



void LibYReal_BetaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b)
{
    cpp_dec_float_50 a1 = *(cpp_dec_float_50*)a;
    cpp_dec_float_50 b1 = *(cpp_dec_float_50*)b;
    beta_distribution<cpp_dec_float_50> dist(a1, b1); MP_DIST_RETURN
}



void LibYReal_BinomialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr n, YRealPtr p)
{
    cpp_dec_float_50 n1 = *(cpp_dec_float_50*)n;
    cpp_dec_float_50 p1 = *(cpp_dec_float_50*)p;
    binomial_distribution<cpp_dec_float_50> dist(n1, p1); MP_DIST_RETURN
}



void LibYReal_CauchyDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    cpp_dec_float_50 location1 = *(cpp_dec_float_50*)location;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    cauchy_distribution<cpp_dec_float_50> dist(location1, scale1); MP_DIST_RETURN
}



void LibYReal_Chi2Dist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu)
{
    cpp_dec_float_50 nu1 = *(cpp_dec_float_50*)nu;
    chi_squared_distribution<cpp_dec_float_50> dist(nu1); MP_DIST_RETURN
}



void LibYReal_ExponentialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lambda)
{
    cpp_dec_float_50 lambda1 = *(cpp_dec_float_50*)lambda;
    exponential_distribution<cpp_dec_float_50> dist(lambda1); MP_DIST_RETURN
}



void LibYReal_ExtremeValueDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    cpp_dec_float_50 location1 = *(cpp_dec_float_50*)location;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    extreme_value_distribution<cpp_dec_float_50> dist(location1, scale1); MP_DIST_RETURN
}



void LibYReal_FisherFDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mu, YRealPtr nu)
{
    cpp_dec_float_50 mu1 = *(cpp_dec_float_50*)mu;
    cpp_dec_float_50 nu1 = *(cpp_dec_float_50*)nu;
    fisher_f_distribution<cpp_dec_float_50> dist(mu1, nu1); MP_DIST_RETURN
}



void LibYReal_GammaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale)
{
    cpp_dec_float_50 shape1 = *(cpp_dec_float_50*)shape;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    gamma_distribution<cpp_dec_float_50> dist(shape1, scale1); MP_DIST_RETURN
}



void LibYReal_GeometricDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr p)
{
    cpp_dec_float_50 p1 = *(cpp_dec_float_50*)p;
    geometric_distribution<cpp_dec_float_50> dist(p1); MP_DIST_RETURN
}



void LibYReal_HypergeometricDist(long Target, YRealPtr res, YRealPtr xqp, unsigned r, unsigned n, unsigned N)
{
    hypergeometric_distribution<cpp_dec_float_50> dist(r, n, N); MP_DIST_RETURN
}



void LibYReal_InverseChi2Dist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr df, YRealPtr scale)
{
    cpp_dec_float_50 df1 = *(cpp_dec_float_50*)df;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    inverse_chi_squared_distribution<cpp_dec_float_50> dist(df1, scale1); MP_DIST_RETURN
}



void LibYReal_InverseGammaDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale)
{
    cpp_dec_float_50 shape1 = *(cpp_dec_float_50*)shape;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    inverse_gamma_distribution<cpp_dec_float_50> dist(shape1, scale1); MP_DIST_RETURN
}



void LibYReal_InverseGaussianDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr scale)
{
    cpp_dec_float_50 mean1 = *(cpp_dec_float_50*)mean_;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    inverse_gaussian_distribution<cpp_dec_float_50> dist(mean1, scale1); MP_DIST_RETURN
}



void LibYReal_LaplaceDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    cpp_dec_float_50 location1 = *(cpp_dec_float_50*)location;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    laplace_distribution<cpp_dec_float_50> dist(location1, scale1); MP_DIST_RETURN
}



void LibYReal_LogisticDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    cpp_dec_float_50 location1 = *(cpp_dec_float_50*)location;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    logistic_distribution<cpp_dec_float_50> dist(location1, scale1); MP_DIST_RETURN
}



void LibYReal_LognormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr location, YRealPtr scale)
{
    cpp_dec_float_50 location1 = *(cpp_dec_float_50*)location;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    lognormal_distribution<cpp_dec_float_50> dist(location1, scale1); MP_DIST_RETURN
}



void LibYReal_NegBinomialDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr n, YRealPtr p)
{
    cpp_dec_float_50 n1 = *(cpp_dec_float_50*)n;
    cpp_dec_float_50 p1 = *(cpp_dec_float_50*)p;
    negative_binomial_distribution<cpp_dec_float_50> dist(n1, p1); MP_DIST_RETURN
}


void LibYReal_Chi2NCDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu, YRealPtr nc)
{
    cpp_dec_float_50 nu1 = *(cpp_dec_float_50*)nu;
    cpp_dec_float_50 nc1 = *(cpp_dec_float_50*)nc;
    non_central_chi_squared_distribution<cpp_dec_float_50> dist(nu1, nc1); MP_DIST_RETURN
}


void LibYReal_StudentTNCDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu, YRealPtr delta)
{
    cpp_dec_float_50 nu1 = *(cpp_dec_float_50*)nu;
    cpp_dec_float_50 delta1 = *(cpp_dec_float_50*)delta;
    non_central_t_distribution<cpp_dec_float_50> dist(nu1, delta1); MP_DIST_RETURN
}



void LibYReal_FisherNCDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mu, YRealPtr nu, YRealPtr nc)
{
    cpp_dec_float_50 mu1 = *(cpp_dec_float_50*)mu;
    cpp_dec_float_50 nu1 = *(cpp_dec_float_50*)nu;
    cpp_dec_float_50 nc1 = *(cpp_dec_float_50*)nc;
    non_central_f_distribution<cpp_dec_float_50> dist(mu1, nu1, nc1); MP_DIST_RETURN
}



void LibYReal_BetaNCDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr a, YRealPtr b, YRealPtr nc)
{
    cpp_dec_float_50 a1 = *(cpp_dec_float_50*)a;
    cpp_dec_float_50 b1 = *(cpp_dec_float_50*)b;
    cpp_dec_float_50 nc1 = *(cpp_dec_float_50*)nc;
    non_central_beta_distribution<cpp_dec_float_50> dist(a1, b1, nc1); MP_DIST_RETURN
}



void LibYReal_NormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr stdev)
{
    cpp_dec_float_50 mean1 = *(cpp_dec_float_50*)mean_;
    cpp_dec_float_50 stdev1 = *(cpp_dec_float_50*)stdev;
    normal_distribution<cpp_dec_float_50> dist(mean1, stdev1); MP_DIST_RETURN
}



void LibYReal_ParetoDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale)
{
    cpp_dec_float_50 shape1 = *(cpp_dec_float_50*)shape;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    pareto_distribution<cpp_dec_float_50> dist(shape1, scale1); MP_DIST_RETURN
}



void LibYReal_PoissonDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu)
{
    cpp_dec_float_50 nu1 = *(cpp_dec_float_50*)nu;
    poisson_distribution<cpp_dec_float_50> dist(nu1); MP_DIST_RETURN
}



void LibYReal_RayleighDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu)
{
    cpp_dec_float_50 nu1 = *(cpp_dec_float_50*)nu;
    rayleigh_distribution<cpp_dec_float_50> dist(nu1); MP_DIST_RETURN
}



void LibYReal_SkewNormalDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr mean_, YRealPtr scale, YRealPtr shape)
{
    cpp_dec_float_50 mean1 = *(cpp_dec_float_50*)mean_;
    cpp_dec_float_50 shape1 = *(cpp_dec_float_50*)shape;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    skew_normal_distribution<cpp_dec_float_50> dist(mean1, scale1, shape1); MP_DIST_RETURN
}



void LibYReal_StudentTDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr nu)
{
    cpp_dec_float_50 nu1 = *(cpp_dec_float_50*)nu;
    students_t_distribution<cpp_dec_float_50> dist(nu1); MP_DIST_RETURN
}



void LibYReal_TriangularDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lower, YRealPtr mode_, YRealPtr upper)
{
    cpp_dec_float_50 lower1 = *(cpp_dec_float_50*)lower;
    cpp_dec_float_50 mode1 = *(cpp_dec_float_50*)mode_;
    cpp_dec_float_50 upper1 = *(cpp_dec_float_50*)upper;
    triangular_distribution<cpp_dec_float_50> dist(lower1, mode1, upper1); MP_DIST_RETURN
}



void LibYReal_WeibullDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr shape, YRealPtr scale)
{
    cpp_dec_float_50 shape1 = *(cpp_dec_float_50*)shape;
    cpp_dec_float_50 scale1 = *(cpp_dec_float_50*)scale;
    weibull_distribution<cpp_dec_float_50> dist(shape1, scale1); MP_DIST_RETURN
}



void LibYReal_UniformDist(long Target, YRealPtr res, YRealPtr xqp, YRealPtr lower, YRealPtr upper)
{
    cpp_dec_float_50 lower1 = *(cpp_dec_float_50*)lower;
    cpp_dec_float_50 upper1 = *(cpp_dec_float_50*)upper;
    uniform_distribution<cpp_dec_float_50> dist(lower1, upper1); MP_DIST_RETURN
}





//*********************** Boost Special functions , YReal **********************************




void LibYReal_Ulp(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = ulp(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_BernoulliB2n(YRealPtr res, const int n)
{
	(*(cpp_dec_float_50*)res) = bernoulli_b2n<cpp_dec_float_50>(n);
}



void LibYReal_TangentT2n(YRealPtr res, const int n)
{
	(*(cpp_dec_float_50*)res) = tangent_t2n<cpp_dec_float_50>(n);
}



void LibYReal_Sqrt1pm1(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sqrt1pm1(*(cpp_dec_float_50*)x);
}



void LibYReal_SinPi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sin_pi(*(cpp_dec_float_50*)x);
}

void LibYReal_CosPi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cos_pi(*(cpp_dec_float_50*)x);
}

void LibYReal_TanPi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sin_pi(*(cpp_dec_float_50*)x) / cos_pi(*(cpp_dec_float_50*)x);
}



void LibYReal_CscPi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (1.0) / sin_pi(*(cpp_dec_float_50*)x);
}

void LibYReal_SecPi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (1.0) / cos_pi(*(cpp_dec_float_50*)x);
}

void LibYReal_CotPi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cos_pi(*(cpp_dec_float_50*)x) / sin_pi(*(cpp_dec_float_50*)x);
}




void LibYReal_SincPi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sinc_pi(*(cpp_dec_float_50*)x);
}



void LibYReal_SinhcPi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sinhc_pi(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Tgamma_(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = tgamma(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_Tgamma1pm1(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = tgamma1pm1(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Lgamma_(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = lgamma(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Digamma(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = digamma(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Trigamma(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = trigamma(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Factorial(YRealPtr res, const YRealPtr x)
{
    cpp_dec_float_50 xt = cpp_dec_float_50(*(cpp_dec_float_50*)x);
    cpp_dec_float_50 result = tgamma(xt + 1);
	(*(cpp_dec_float_50*)res) = result;
}



void LibYReal_DoubleFactorial(YRealPtr res, const YRealPtr x)
{
    cpp_dec_float_50 xt = cpp_dec_float_50(*(cpp_dec_float_50*)x);
    cpp_dec_float_50 xt2 = xt/2;
    cpp_dec_float_50 t1 = (cos_pi(xt)-1)/4;
    cpp_dec_float_50 pi2 = constants::half_pi<cpp_dec_float_50>();
    cpp_dec_float_50 t2 = pow(pi2, t1);
    cpp_dec_float_50 result = exp2(xt2) * t2 * tgamma(xt2+1);
	(*(cpp_dec_float_50*)res) = result;
}





void LibYReal_Erf_(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = erf(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Erfc_(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = erfc(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Erf_inv(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = erf_inv(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Erfc_inv(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = erfc_inv(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_AiryAi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = airy_ai(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_AiryBi(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = airy_bi(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_AiryAiPrime(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = airy_ai_prime(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_AiryBiPrime(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = airy_bi_prime(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Aizero(YRealPtr res, const int n)
{
	(*(cpp_dec_float_50*)res) = airy_ai_zero<cpp_dec_float_50>(n);
}



void LibYReal_Bizero(YRealPtr res, const int n)
{
	(*(cpp_dec_float_50*)res) = airy_bi_zero<cpp_dec_float_50>(n);
}



void LibYReal_Ellint_1_K(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = ellint_1(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Ellint_2_K(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = ellint_2(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Zeta(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = zeta(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Ei(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = expint(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_LambertW0(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = lambert_w0(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_LambertWm1(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = lambert_wm1(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_LambertW0Prime(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = lambert_w0_prime(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_LambertWm1Prime(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = lambert_wm1_prime(cpp_dec_float_50(*(cpp_dec_float_50*)x));
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void LibYReal_Powm1(YRealPtr res, const YRealPtr a, const YRealPtr b)
{
	(*(cpp_dec_float_50*)res) = powm1(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b));
}



void LibYReal_TgammaRatio(YRealPtr res, const YRealPtr a, const YRealPtr b)
{
	(*(cpp_dec_float_50*)res) = tgamma_ratio(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b));
}



void LibYReal_TgammaDeltaRatio(YRealPtr res, const YRealPtr a, const YRealPtr b)
{
	(*(cpp_dec_float_50*)res) = tgamma_delta_ratio(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b));
}



void LibYReal_Binomial(YRealPtr res, const YRealPtr n, const YRealPtr k)
{
    cpp_dec_float_50 nt = cpp_dec_float_50(*(cpp_dec_float_50*)n);
    cpp_dec_float_50 kt = cpp_dec_float_50(*(cpp_dec_float_50*)k);
    cpp_dec_float_50 result = tgamma(nt+1) / ( tgamma(nt+1) * tgamma(nt-kt+1) );
	(*(cpp_dec_float_50*)res) = result;
}

void LibYReal_RisingFactorial(YRealPtr res, const YRealPtr x, const YRealPtr n)
{
    cpp_dec_float_50 xt = cpp_dec_float_50(*(cpp_dec_float_50*)x);
    cpp_dec_float_50 nt = cpp_dec_float_50(*(cpp_dec_float_50*)n);
    cpp_dec_float_50 result = tgamma(xt+nt) / tgamma(xt);
	(*(cpp_dec_float_50*)res) = result;
}




void LibYReal_FallingFactorial(YRealPtr res, const YRealPtr x, const YRealPtr n)
{
    cpp_dec_float_50 xt = cpp_dec_float_50(*(cpp_dec_float_50*)x);
    cpp_dec_float_50 nt = cpp_dec_float_50(*(cpp_dec_float_50*)n);
    cpp_dec_float_50 result = tgamma(xt+1) / tgamma(xt-nt+1);
	(*(cpp_dec_float_50*)res) = result;
}




void LibYReal_BesselJ(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cyl_bessel_j(cpp_dec_float_50(*(cpp_dec_float_50*)v), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_BesselY(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cyl_neumann(cpp_dec_float_50(*(cpp_dec_float_50*)v), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_BesselI(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cyl_bessel_i(cpp_dec_float_50(*(cpp_dec_float_50*)v), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_BesselK(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cyl_bessel_k(cpp_dec_float_50(*(cpp_dec_float_50*)v), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_SphBessel(YRealPtr res, const unsigned v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sph_bessel(v, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_SphNeumann(YRealPtr res, const unsigned v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sph_neumann(v, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}





void LibYReal_BesselJPrime(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cyl_bessel_j_prime(cpp_dec_float_50(*(cpp_dec_float_50*)v), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_BesselYPrime(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cyl_neumann_prime(cpp_dec_float_50(*(cpp_dec_float_50*)v), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_BesselIPrime(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cyl_bessel_i_prime(cpp_dec_float_50(*(cpp_dec_float_50*)v), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_BesselKPrime(YRealPtr res, const YRealPtr v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cyl_bessel_k_prime(cpp_dec_float_50(*(cpp_dec_float_50*)v), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_SphBesselPrime(YRealPtr res, const unsigned v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sph_bessel_prime(v, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_SphNeumannPrime(YRealPtr res, const unsigned v, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sph_neumann_prime(v, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}





void LibYReal_BesselJZero(YRealPtr res, const YRealPtr v, const int m)
{
	(*(cpp_dec_float_50*)res) = cyl_bessel_j_zero(cpp_dec_float_50(*(cpp_dec_float_50*)v), m);
}



void LibYReal_BesselYZero(YRealPtr res, const YRealPtr v, const int m)
{
	(*(cpp_dec_float_50*)res) = cyl_neumann_zero(cpp_dec_float_50(*(cpp_dec_float_50*)v), m);
}





void LibYReal_GammaP(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = gamma_p(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_GammaQ(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = gamma_q(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_TgammaLower(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = tgamma_lower(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_TgammaUpper(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = tgamma(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}




void LibYReal_GammaPInv(YRealPtr res, const YRealPtr a, const YRealPtr p)
{
	(*(cpp_dec_float_50*)res) = gamma_p_inv(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)p));
}


void LibYReal_GammaQInv(YRealPtr res, const YRealPtr a, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = gamma_q_inv(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}


void LibYReal_GammaPInva(YRealPtr res, const YRealPtr x, const YRealPtr p)
{
	(*(cpp_dec_float_50*)res) = gamma_p_inva(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)p));
}


void LibYReal_GammaQInva(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = gamma_q_inva(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}



void LibYReal_GammaPDerivative(YRealPtr res, const YRealPtr a, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = gamma_p_derivative(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_Beta(YRealPtr res, const YRealPtr a, const YRealPtr b)
{
	(*(cpp_dec_float_50*)res) = beta(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b));
}









void LibYReal_LegendreP(YRealPtr res, int n, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = legendre_p(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_LegendreQ(YRealPtr res, int n, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = legendre_q(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Laguerre(YRealPtr res, int n, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = laguerre(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Hermite(YRealPtr res, int n, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = hermite(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_ChebyshevT(YRealPtr res, int n, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = chebyshev_t(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_ChebyshevU(YRealPtr res, int n, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = chebyshev_u(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Polygamma(YRealPtr res, int n, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = polygamma(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}





void LibYReal_EllintRC(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = ellint_rc(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)y));
}


void LibYReal_Ellint1F(YRealPtr res, const YRealPtr k, const YRealPtr phi)
{
	(*(cpp_dec_float_50*)res) = ellint_1(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)phi));
}


void LibYReal_Ellint2F(YRealPtr res, const YRealPtr k, const YRealPtr phi)
{
	(*(cpp_dec_float_50*)res) = ellint_2(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)phi));
}


void LibYReal_Ellint3K(YRealPtr res, const YRealPtr k, const YRealPtr n)
{
	(*(cpp_dec_float_50*)res) = ellint_3(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)n));
}




void LibYReal_JacobiCD(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_cd(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiCN(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_cn(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiCS(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_cs(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiDC(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_dc(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiDN(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_dn(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiDS(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_ds(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiNC(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_nc(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiND(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_nd(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiNS(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_ns(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiSC(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_sc(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiSD(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_sd(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}


void LibYReal_JacobiSN(YRealPtr res, const YRealPtr k, const YRealPtr u)
{
	(*(cpp_dec_float_50*)res) = jacobi_sn(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)u));
}



void LibYReal_expint(YRealPtr res, const unsigned n, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = expint(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}




void LibYReal_OwenT(YRealPtr res, const YRealPtr h, const YRealPtr a)
{
	(*(cpp_dec_float_50*)res) = owens_t(cpp_dec_float_50(*(cpp_dec_float_50*)h), cpp_dec_float_50(*(cpp_dec_float_50*)a));
}





void LibYReal_IBeta(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = ibeta(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_IBetac(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = ibetac(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_IBetaNonNormalized(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = beta(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_IBetacNonNormalized(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = betac(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}


void LibYReal_IBetaInv(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr p)
{
	(*(cpp_dec_float_50*)res) = ibeta_inv(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)p));
}


void LibYReal_IBetacInv(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = ibetac_inv(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}


void LibYReal_IBetaInva(YRealPtr res, const YRealPtr b, const YRealPtr x, const YRealPtr p)
{
	(*(cpp_dec_float_50*)res) = ibeta_inva(cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)p));
}


void LibYReal_IBetacInva(YRealPtr res, const YRealPtr b, const YRealPtr x, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = ibetac_inva(cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}


void LibYReal_IBetaInvb(YRealPtr res, const YRealPtr a, const YRealPtr x, const YRealPtr p)
{
	(*(cpp_dec_float_50*)res) = ibeta_invb(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)p));
}


void LibYReal_IBetacInvb(YRealPtr res, const YRealPtr a, const YRealPtr x, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = ibetac_invb(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}


void LibYReal_IBetaDerivative(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = ibeta_derivative(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}




void LibYReal_LegendrePM(YRealPtr res, const int n, const int m, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = legendre_p(n, m, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_LaguerreM(YRealPtr res, const int n, const int m, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = laguerre(n, m, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}





void LibYReal_EllipticRF(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z)
{
	(*(cpp_dec_float_50*)res) = ellint_rf(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)y), cpp_dec_float_50(*(cpp_dec_float_50*)z));
}



void LibYReal_EllipticRD(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z)
{
	(*(cpp_dec_float_50*)res) = ellint_rd(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)y), cpp_dec_float_50(*(cpp_dec_float_50*)z));
}



void LibYReal_Ellint3F(YRealPtr res, const YRealPtr k, const YRealPtr n, const YRealPtr phi)
{
	(*(cpp_dec_float_50*)res) = ellint_3(cpp_dec_float_50(*(cpp_dec_float_50*)k), cpp_dec_float_50(*(cpp_dec_float_50*)n), cpp_dec_float_50(*(cpp_dec_float_50*)phi));
}




void LibYReal_SphericalHarmonicR(YRealPtr res, const int n, const int m, const YRealPtr theta, const YRealPtr phi)
{
	(*(cpp_dec_float_50*)res) = spherical_harmonic_r(n, m, cpp_dec_float_50(*(cpp_dec_float_50*)theta), cpp_dec_float_50(*(cpp_dec_float_50*)phi));
}


void LibYReal_SphericalHarmonicI(YRealPtr res, const int n, const int m, const YRealPtr theta, const YRealPtr phi)
{
	(*(cpp_dec_float_50*)res) = spherical_harmonic_i(n, m, cpp_dec_float_50(*(cpp_dec_float_50*)theta), cpp_dec_float_50(*(cpp_dec_float_50*)phi));
}


void LibYReal_EllipticRJ(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z, const YRealPtr p)
{
	(*(cpp_dec_float_50*)res) = ellint_rj(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)y), cpp_dec_float_50(*(cpp_dec_float_50*)z), cpp_dec_float_50(*(cpp_dec_float_50*)p));
}


// Hypergeometric and Theta Functions




void LibYReal_Hypergeo0F1(YRealPtr res, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = hypergeometric_0F1(cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Hypergeo1F1(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = hypergeometric_1F1(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_Hypergeo1F1r(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = hypergeometric_1F1_regularized(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}



void LibYReal_LogHypergeo1F1(YRealPtr res, const YRealPtr a, const YRealPtr b, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = log_hypergeometric_1F1(cpp_dec_float_50(*(cpp_dec_float_50*)a), cpp_dec_float_50(*(cpp_dec_float_50*)b), cpp_dec_float_50(*(cpp_dec_float_50*)x));
}





void LibYReal_JacobiTheta1(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = jacobi_theta1(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}


void LibYReal_JacobiTheta2(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = jacobi_theta2(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}


void LibYReal_JacobiTheta3(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = jacobi_theta3(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}


void LibYReal_JacobiTheta4(YRealPtr res, const YRealPtr x, const YRealPtr q)
{
	(*(cpp_dec_float_50*)res) = jacobi_theta4(cpp_dec_float_50(*(cpp_dec_float_50*)x), cpp_dec_float_50(*(cpp_dec_float_50*)q));
}












//*********************** Real **********************************


YRealPtr LibYReal_Init_Func()
{
	YRealPtr x = NULL;
	x = (cpp_dec_float_50*)malloc(sizeof(cpp_dec_float_50));
	*(cpp_dec_float_50*)x = 0;
	return x;
}


void LibYReal_Clear(YRealPtr x)
{
	free(x);
}


void LibYReal_Get_Str(char* cstr, YRealPtr x)
{
    cpp_dec_float_50 d = *(cpp_dec_float_50*)x;
    std::stringstream ss;
    ss.precision(std::numeric_limits<cpp_dec_float_50>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}




void LibYReal_Set_Str(YRealPtr res, const char * str)
{

    (*(cpp_dec_float_50*)res) = static_cast<cpp_dec_float_50>(string(str));
}




void LibYReal_Set(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x);
}



void LibYReal_Neg(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = -(*(cpp_dec_float_50*)x);
}


void LibYReal_Set_S(YRealPtr res, const float* x)
{
	(*(cpp_dec_float_50*)res) = *x;
}


void LibYReal_Set_D(YRealPtr res, const double x)
{
	(*(cpp_dec_float_50*)res) = x;
}


void LibYReal_Set_LD(YRealPtr res, const long double* x)
{
	(*(cpp_dec_float_50*)res) = *x;
}



void LibYReal_Set_Si(YRealPtr res, const int32_t x)
{
	(*(cpp_dec_float_50*)res) = x;
}



void LibYReal_Set_Si64(YRealPtr res, const int64_t x)
{
	(*(cpp_dec_float_50*)res) = x;
}



void LibYReal_Set_Ui(YRealPtr res, const uint32_t x)
{
	(*(cpp_dec_float_50*)res) = x;
}



void LibYReal_Set_Ui64(YRealPtr res, const uint64_t x)
{
	(*(cpp_dec_float_50*)res) = x;
}









void LibYReal_Add(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) + (*(cpp_dec_float_50*)y);
}


void LibYReal_Sub(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) - (*(cpp_dec_float_50*)y);
}



void LibYReal_Mul(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) * (*(cpp_dec_float_50*)y);
}



void LibYReal_Div(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) / (*(cpp_dec_float_50*)y);
}








void LibYReal_Add_D(YRealPtr res, const YRealPtr x, const double y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) + y;
}


void LibYReal_Sub_D(YRealPtr res, const YRealPtr x, const double y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) - y;
}


void LibYReal_D_Sub(YRealPtr res, const YRealPtr x, const double y)
{
	(*(cpp_dec_float_50*)res) = y - (*(cpp_dec_float_50*)x);
}


void LibYReal_Mul_D(YRealPtr res, const YRealPtr x, const double y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) * y;
}


void LibYReal_Div_D(YRealPtr res, const YRealPtr x, const double y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) / y;
}


void LibYReal_D_Div(YRealPtr res, const YRealPtr x, const double y)
{
	(*(cpp_dec_float_50*)res) = y / (*(cpp_dec_float_50*)x);
}









void LibYReal_Add_Si(YRealPtr res, const YRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) + y;
}


void LibYReal_Sub_Si(YRealPtr res, const YRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) - y;
}


void LibYReal_Si_Sub(YRealPtr res, const YRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_50*)res) = y - (*(cpp_dec_float_50*)x);
}


void LibYReal_Mul_Si(YRealPtr res, const YRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) * y;
}


void LibYReal_Div_Si(YRealPtr res, const YRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) / y;
}


void LibYReal_Si_Div(YRealPtr res, const YRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_50*)res) = y / (*(cpp_dec_float_50*)x);
}







int32_t LibYReal_LT(const YRealPtr x, const YRealPtr y)
{
	return (*(cpp_dec_float_50*)x) < (*(cpp_dec_float_50*)y);
}


int32_t LibYReal_GE(const YRealPtr x, const YRealPtr y)
{
	return (*(cpp_dec_float_50*)x) >= (*(cpp_dec_float_50*)y);
}


int32_t LibYReal_GT(const YRealPtr x, const YRealPtr y)
{
	return (*(cpp_dec_float_50*)x) > (*(cpp_dec_float_50*)y);
}


int32_t LibYReal_LE(const YRealPtr x, const YRealPtr y)
{
	return (*(cpp_dec_float_50*)x) <= (*(cpp_dec_float_50*)y);
}


int32_t LibYReal_EQ(const YRealPtr x, const YRealPtr y)
{
	return (*(cpp_dec_float_50*)x) == (*(cpp_dec_float_50*)y);
}


int32_t LibYReal_NE(const YRealPtr x, const YRealPtr y)
{
	return (*(cpp_dec_float_50*)x) != (*(cpp_dec_float_50*)y);
}











/* General functions for real numbers  */


void LibYReal_Fma(YRealPtr res, const YRealPtr x, const YRealPtr y, const YRealPtr z)
{
	(*(cpp_dec_float_50*)res) = fma( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) , (*(cpp_dec_float_50*)z) );
}


void LibYReal_Fmax(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = fmax( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}


void LibYReal_Fmin(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = fmin( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}





/* Machine constants */


void LibYReal_Zero(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = 0.0;
}


void LibYReal_NegZero(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = -0.0;
}


void LibYReal_One(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = 1.0;
}


void LibYReal_Inf(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = std::numeric_limits<cpp_dec_float_50>::infinity();
}


void LibYReal_NegInf(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = -std::numeric_limits<cpp_dec_float_50>::infinity();
}


void LibYReal_Nan(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = std::numeric_limits<cpp_dec_float_50>::quiet_NaN();
}






/* Properties of numbers  */

int LibYReal_Signbit(const YRealPtr x)
{
	return signbit(*(cpp_dec_float_50*)x);
}

int LibYReal_Finite(const YRealPtr x)
{
	return isfinite(*(cpp_dec_float_50*)x);
}

int LibYReal_Isinf(const YRealPtr x)
{
	return isinf(*(cpp_dec_float_50*)x);
}

int LibYReal_Isposinf(const YRealPtr x)
{
	return ((isinf(*(cpp_dec_float_50*)x)) & (*(cpp_dec_float_50*)x > 0 ));
}

int LibYReal_Isneginf(const YRealPtr x)
{
	return ((isinf(*(cpp_dec_float_50*)x)) & (*(cpp_dec_float_50*)x < 0 ));
}

int LibYReal_Isnan(const YRealPtr x)
{
	return isnan(*(cpp_dec_float_50*)x);
}



int LibYReal_Iszero(const YRealPtr x)
{
	return (abs(*(cpp_dec_float_50*)x) == 0.0);
}

int LibYReal_Isposzero(const YRealPtr x)
{
	return ((int(signbit(*(cpp_dec_float_50*)x)) == 0) & (abs(*(cpp_dec_float_50*)x) == 0.0));
}

int LibYReal_Isnegzero(const YRealPtr x)
{
	return ((int(signbit(*(cpp_dec_float_50*)x)) != 0) & (abs(*(cpp_dec_float_50*)x) == 0.0));
}

int LibYReal_Isone(const YRealPtr x)
{
	return (*(cpp_dec_float_50*)x == 1.0);
}

int LibYReal_Isinteger(const YRealPtr x)
{
	return (ceil(*(cpp_dec_float_50*)x) == floor(*(cpp_dec_float_50*)x));
}

int LibYReal_Isnumber(const YRealPtr x)
{
	return (!(isnan(*(cpp_dec_float_50*)x) || (isinf(*(cpp_dec_float_50*)x))));
}

int LibYReal_Isregular(const YRealPtr x)
{
	return (!(isnan(*(cpp_dec_float_50*)x) || (isinf(*(cpp_dec_float_50*)x) || (abs(*(cpp_dec_float_50*)x) == 0.0))));
}

int LibYReal_Isnormal(const YRealPtr x)
{
	return (isnormal(*(cpp_dec_float_50*)x));
}

int LibYReal_Issubnormal(const YRealPtr x)
{
	return (fpclassify(*(cpp_dec_float_50*)x)) == FP_SUBNORMAL;
}

int LibYReal_Isunordered(const YRealPtr x, const YRealPtr y)
{
	return (isunordered(*(cpp_dec_float_50*)x, *(cpp_dec_float_50*)x));
}







int LibYReal_FitsInt32(const YRealPtr x)
{
	return  ((*(cpp_dec_float_50*)x <= std::numeric_limits<int32_t>::max()) &
             (*(cpp_dec_float_50*)x >= std::numeric_limits<int32_t>::min()));
}

int LibYReal_FitsInt64(const YRealPtr x)
{
	return  ((*(cpp_dec_float_50*)x <= std::numeric_limits<int64_t>::max()) &
             (*(cpp_dec_float_50*)x >= std::numeric_limits<int64_t>::min()));
}

int LibYReal_FitsUInt32(const YRealPtr x)
{
	return  ((*(cpp_dec_float_50*)x <= std::numeric_limits<uint32_t>::max()) &
             (*(cpp_dec_float_50*)x >= std::numeric_limits<uint32_t>::min()));
}

int LibYReal_FitsUInt64(const YRealPtr x)
{
	return  ((*(cpp_dec_float_50*)x <= std::numeric_limits<uint64_t>::max()) &
             (*(cpp_dec_float_50*)x >= std::numeric_limits<uint64_t>::min()));
}




/* Integer Related Functions  */

void LibYReal_Nearbyint(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = nearbyint(*(cpp_dec_float_50*)x);
}

void LibYReal_Rint(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = rint(*(cpp_dec_float_50*)x);
}

long int LibYReal_Lrint(const YRealPtr x)
{
	return lrint(*(cpp_dec_float_50*)x);
}

long long int LibYReal_Llrint(const YRealPtr x)
{
	return llrint(*(cpp_dec_float_50*)x);
}

void LibYReal_Ceil(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = ceil(*(cpp_dec_float_50*)x);
}

void LibYReal_Floor(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = floor(*(cpp_dec_float_50*)x);
}

void LibYReal_Trunc(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = trunc(*(cpp_dec_float_50*)x);
}

void LibYReal_Round(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = round(*(cpp_dec_float_50*)x);
}

long int LibYReal_Lround(const YRealPtr x)
{
	return lround(*(cpp_dec_float_50*)x);
}

long long int LibYReal_Llround(const YRealPtr x)
{
	return llround(*(cpp_dec_float_50*)x);
}



int32_t LibYReal_ToInt32(const YRealPtr x)
{
    if (*(cpp_dec_float_50*)x >= std::numeric_limits<int32_t>::max())
        return std::numeric_limits<int32_t>::max();
    else if (*(cpp_dec_float_50*)x <= std::numeric_limits<int32_t>::min())
        return std::numeric_limits<int32_t>::min();
    else
        return (int32_t) (*(__float128*)x);
}

int64_t LibYReal_ToInt64(const YRealPtr x)
{
    if (*(cpp_dec_float_50*)x >= std::numeric_limits<int64_t>::max())
        return std::numeric_limits<int64_t>::max();
    else if (*(cpp_dec_float_50*)x <= std::numeric_limits<int64_t>::min())
        return std::numeric_limits<int64_t>::min();
    else
        return (int64_t) (*(cpp_dec_float_50*)x);
}

uint32_t LibYReal_ToUInt32(const YRealPtr x)
{
    if (*(cpp_dec_float_50*)x >= std::numeric_limits<uint32_t>::max())
        return std::numeric_limits<uint32_t>::max();
    else if (*(cpp_dec_float_50*)x <= std::numeric_limits<uint32_t>::min())
        return std::numeric_limits<uint32_t>::min();
    else
        return (uint32_t) (*(cpp_dec_float_50*)x);
}

uint64_t LibYReal_ToUInt64(const YRealPtr x)
{
    if (*(cpp_dec_float_50*)x >= std::numeric_limits<uint64_t>::max())
        return std::numeric_limits<uint64_t>::max();
    else if (*(cpp_dec_float_50*)x <= std::numeric_limits<uint64_t>::min())
        return std::numeric_limits<uint64_t>::min();
    else
        return (uint64_t) (*(cpp_dec_float_50*)x);
}





/* Floating point functions for real numbers */

void LibYReal_Copysign(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = copysign( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}

void LibYReal_Frexp(YRealPtr res, const YRealPtr x, int* e)
{
	(*(cpp_dec_float_50*)res) = frexp(*(cpp_dec_float_50*)x, e);
}

void LibYReal_Logb(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = logb(*(cpp_dec_float_50*)x);
}

int LibYReal_Ilogb(const YRealPtr x)
{
	return ilogb(*(cpp_dec_float_50*)x);
}

void LibYReal_Ldexp(YRealPtr res, const YRealPtr x, const int e)
{
	(*(cpp_dec_float_50*)res) = ldexp(*(cpp_dec_float_50*)x, e);
}

void LibYReal_Scalbn(YRealPtr res, const YRealPtr x, const int e)
{
	(*(cpp_dec_float_50*)res) = scalbn(*(cpp_dec_float_50*)x, e);
}

void LibYReal_Scalbln(YRealPtr res, const YRealPtr x, const long int e)
{
	(*(cpp_dec_float_50*)res) = scalbln(*(cpp_dec_float_50*)x, e);
}

void LibYReal_Fdim(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = fdim( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}



/* Fraction and Remainder Related Functions  */

void LibYReal_Modf(YRealPtr frac, const YRealPtr x, YRealPtr iptr)
{
	(*(cpp_dec_float_50*)frac) = modf( (*(cpp_dec_float_50*)x) , (cpp_dec_float_50*)iptr );
}

void LibYReal_Fmod(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = fmod( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}

void LibYReal_Remainder(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = remainder( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}

void LibYReal_Remquo(YRealPtr res, const YRealPtr x, const YRealPtr y, int* e)
{
	(*(cpp_dec_float_50*)res) = remquo( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y), e );
}




/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

void LibYReal_Epsilon(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = std::numeric_limits<cpp_dec_float_50>::epsilon();
}

void LibYReal_Max(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = std::numeric_limits<cpp_dec_float_50>::max();
}

void LibYReal_Min(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = std::numeric_limits<cpp_dec_float_50>::min();
}

void LibYReal_Lowest(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = std::numeric_limits<cpp_dec_float_50>::lowest();
}

void LibYReal_Nexttowards(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = nextafter( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}

void LibYReal_Nextabove(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = nextafter( (*(cpp_dec_float_50*)x) , std::numeric_limits<cpp_dec_float_50>::infinity() );
}

void LibYReal_Nextbelow(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = nextafter( (*(cpp_dec_float_50*)x) , -std::numeric_limits<cpp_dec_float_50>::infinity() );
}





/* Complex components  */

void LibYReal_Fabs(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = fabs(*(cpp_dec_float_50*)x);
}

void LibYReal_Sign(YRealPtr res, const YRealPtr x)
{
    int temp = ((*(cpp_dec_float_50*)x > 0) - (*(cpp_dec_float_50*)x < 0));
	(*(cpp_dec_float_50*)res) = temp;
}





/* Mathematical Constants  */

void LibYReal_Pi(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = constants::pi<cpp_dec_float_50>();
}

void LibYReal_E(YRealPtr res)
{
	(*(cpp_dec_float_50*)res) = constants::e<cpp_dec_float_50>();
}




























/* Roots and related functions  */


void LibYReal_Sqrt(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sqrt(*(cpp_dec_float_50*)x);
}

// Sqrt1pm1 from Boost


void LibYReal_Rsqrt(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = 1 / sqrt(*(cpp_dec_float_50*)x);
}


void LibYReal_Cbrt(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cbrt(*(cpp_dec_float_50*)x);
}


void LibYReal_Root_Si(YRealPtr res, const YRealPtr x, const int32_t k_)
{
    cpp_dec_float_50 k = k_;
	(*(cpp_dec_float_50*)res) = pow( (*(cpp_dec_float_50*)x) , (1.0) / k );
}




/* Exponential and related functions  */


void LibYReal_Exp(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = exp(*(cpp_dec_float_50*)x);
}


void LibYReal_Exp2(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = exp2(*(cpp_dec_float_50*)x);
}


void LibYReal_Exp10(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = exp( (*(cpp_dec_float_50*)x) * constants::ln_ten<cpp_dec_float_50>() );
}


void LibYReal_Expm1(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = expm1(*(cpp_dec_float_50*)x);
}

void LibYReal_Exp2m1(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = expm1( (*(cpp_dec_float_50*)x) * constants::ln_two<cpp_dec_float_50>() );
}

void LibYReal_Exp10m1(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = expm1( (*(cpp_dec_float_50*)x) * constants::ln_ten<cpp_dec_float_50>() );
}



/* Logarithms and related functions  */



void LibYReal_Log(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = log(*(cpp_dec_float_50*)x);
}


void LibYReal_Log2(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = log2(*(cpp_dec_float_50*)x);
}


void LibYReal_Log10(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = log10(*(cpp_dec_float_50*)x);
}


void LibYReal_Log1p(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = log1p(*(cpp_dec_float_50*)x);
}


void LibYReal_Log2p1(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = log1p(*(cpp_dec_float_50*)x) / constants::ln_two<cpp_dec_float_50>();
}


void LibYReal_Log10p1(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = log1p(*(cpp_dec_float_50*)x) / constants::ln_ten<cpp_dec_float_50>();
}





/* Power functions  */



void LibYReal_Square(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) * (*(cpp_dec_float_50*)x);
}


void LibYReal_Cube(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (*(cpp_dec_float_50*)x) * (*(cpp_dec_float_50*)x) * (*(cpp_dec_float_50*)x);
}


void LibYReal_Hypot(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = hypot( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}


void LibYReal_Pow(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = pow( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}


// Powm1 from Boost


void LibYReal_Pow1p(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = exp(log1p(*(cpp_dec_float_50*)x) * (*(cpp_dec_float_50*)y));
}


void LibYReal_Pow1pm1(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = expm1(log1p(*(cpp_dec_float_50*)x) * (*(cpp_dec_float_50*)y));
}


void LibYReal_Pow_Si(YRealPtr res, const YRealPtr x, const int32_t k_)
{
    cpp_dec_float_50 k = k_;
	(*(cpp_dec_float_50*)res) = pow( (*(cpp_dec_float_50*)x) , k );
}


void LibYReal_Compound_Si(YRealPtr res, const YRealPtr x, const int32_t k_)
{
    cpp_dec_float_50 k = k_;
	(*(cpp_dec_float_50*)res) = pow( (1.0) + (*(cpp_dec_float_50*)x) , k );
}



/* Trigonometric functions  */




cpp_dec_float_50 cosm1(cpp_dec_float_50 x)
{
    if (fabs(x) > 0.5)
    {
        return cos(x) - 1;
    }
    else
    {
        cpp_dec_float_50 res = sin((x)/2);
        return  -2 * res * res;
    }
}





void LibYReal_Sin(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sin(*(cpp_dec_float_50*)x);
}


void LibYReal_Cos(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cos(*(cpp_dec_float_50*)x);
}


void LibYReal_Tan(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = tan(*(cpp_dec_float_50*)x);
}


void LibYReal_Csc(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (1.0) / sin(*(cpp_dec_float_50*)x);
}


void LibYReal_Sec(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (1.0) / cos(*(cpp_dec_float_50*)x);
}


void LibYReal_Cot(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (1.0) / tan(*(cpp_dec_float_50*)x);
}




/* Hyperbolic functions  */


void LibYReal_Sinh(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = sinh(*(cpp_dec_float_50*)x);
}


void LibYReal_Cosh(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = cosh(*(cpp_dec_float_50*)x);
}


void LibYReal_Tanh(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = tanh(*(cpp_dec_float_50*)x);
}


void LibYReal_Csch(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (1.0) / sinh(*(cpp_dec_float_50*)x);
}


void LibYReal_Sech(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (1.0) / cosh(*(cpp_dec_float_50*)x);
}


void LibYReal_Coth(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = (1.0) / tanh(*(cpp_dec_float_50*)x);
}



/* Inverse trigonometric functions  */


void LibYReal_Asin(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = asin(*(cpp_dec_float_50*)x);
}


void LibYReal_Acos(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = acos(*(cpp_dec_float_50*)x);
}


void LibYReal_Atan(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = atan(*(cpp_dec_float_50*)x);
}


void LibYReal_Atan2(YRealPtr res, const YRealPtr x, const YRealPtr y)
{
	(*(cpp_dec_float_50*)res) = atan2( (*(cpp_dec_float_50*)x) , (*(cpp_dec_float_50*)y) );
}


void LibYReal_Acsc(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = asin( (1.0) / (*(cpp_dec_float_50*)x) );
}


void LibYReal_Asec(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = acos( (1.0) / (*(cpp_dec_float_50*)x) );
}


void LibYReal_Acot(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = atan( (1.0) / (*(cpp_dec_float_50*)x) );
}




/* Inverse hyperbolic functions  */


void LibYReal_Asinh(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = asinh(*(cpp_dec_float_50*)x);
}


void LibYReal_Acosh(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = acosh(*(cpp_dec_float_50*)x);
}


void LibYReal_Atanh(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = atanh(*(cpp_dec_float_50*)x);
}


void LibYReal_Acsch(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = asinh( (1.0) / (*(cpp_dec_float_50*)x) );
}


void LibYReal_Asech(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = acosh( (1.0) / (*(cpp_dec_float_50*)x) );
}


void LibYReal_Acoth(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = atanh( (1.0) / (*(cpp_dec_float_50*)x) );
}



/* Special functions  */

void LibYReal_Erf(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = erf(*(cpp_dec_float_50*)x);
}

void LibYReal_Erfc(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = erfc(*(cpp_dec_float_50*)x);
}

void LibYReal_Tgamma(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = tgamma(*(cpp_dec_float_50*)x);
}

void LibYReal_Lgamma(YRealPtr res, const YRealPtr x)
{
	(*(cpp_dec_float_50*)res) = lgamma(*(cpp_dec_float_50*)x);
}

void LibYReal_J0(YRealPtr res, const YRealPtr x)
{
    cpp_dec_float_50 n = 0;
	(*(cpp_dec_float_50*)res) = cyl_bessel_j(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}

void LibYReal_J1(YRealPtr res, const YRealPtr x)
{
    cpp_dec_float_50 n = 1;
	(*(cpp_dec_float_50*)res) = cyl_bessel_j(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}

void LibYReal_Jn(YRealPtr res, const int n_, const YRealPtr x)
{
    cpp_dec_float_50 n = n_;
	(*(cpp_dec_float_50*)res) = cyl_bessel_j(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}

void LibYReal_Y0(YRealPtr res, const YRealPtr x)
{
    cpp_dec_float_50 n = 0;
	(*(cpp_dec_float_50*)res) = cyl_neumann(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}

void LibYReal_Y1(YRealPtr res, const YRealPtr x)
{
    cpp_dec_float_50 n = 1;
	(*(cpp_dec_float_50*)res) = cyl_neumann(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}

void LibYReal_Yn(YRealPtr res, const int n_, const YRealPtr x)
{
    cpp_dec_float_50 n = n_;
	(*(cpp_dec_float_50*)res) = cyl_bessel_j(n, cpp_dec_float_50(*(cpp_dec_float_50*)x));
}
























//*********************** Complex **********************************


YCplxPtr LibYCplx_Init_Func()
{
	YCplxPtr x = NULL;
	x = (std::complex<cpp_dec_float_50>*) malloc(sizeof(std::complex<cpp_dec_float_50>));
	return x;
}


void LibYCplx_Clear(YCplxPtr x)
{
	free(x);
}




void LibYCplx_Get_Str_Real(char* cstr, YCplxPtr x)
{
    cpp_dec_float_50 d = (*(std::complex<cpp_dec_float_50>*) x).real();
    std::stringstream ss;
    ss.precision(std::numeric_limits<cpp_dec_float_50>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void LibYCplx_Get_Str_Imag(char* cstr, YCplxPtr x)
{
    cpp_dec_float_50 d = (*(std::complex<cpp_dec_float_50>*) x).imag();
    std::stringstream ss;
    ss.precision(std::numeric_limits<cpp_dec_float_50>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void LibYCplx_Neg(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = -(*(std::complex<cpp_dec_float_50>*) x);
}






void LibYCplx_Add(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) + (*(std::complex<cpp_dec_float_50>*) y);
}


void LibYCplx_Sub(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) - (*(std::complex<cpp_dec_float_50>*) y);
}


void LibYCplx_Mul(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) * (*(std::complex<cpp_dec_float_50>*) y);
}


void LibYCplx_Div(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) / (*(std::complex<cpp_dec_float_50>*) y);
}






void LibYCplx_Add_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) + (*(cpp_dec_float_50*)y);
}



void LibYCplx_Sub_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) - (*(cpp_dec_float_50*)y);
}


void LibYCplx_YReal_Sub(YCplxPtr res, const YCplxPtr y, const YRealPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) =  (*(cpp_dec_float_50*)x) - (*(std::complex<cpp_dec_float_50>*) y);
}



void LibYCplx_Mul_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) * (*(cpp_dec_float_50*)y);
}



void LibYCplx_Div_YReal(YCplxPtr res, const YCplxPtr x, const YRealPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) / (*(cpp_dec_float_50*)y);
}


void LibYCplx_YReal_Div(YCplxPtr res, const YCplxPtr y, const YRealPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = (*(cpp_dec_float_50*)x) / (*(std::complex<cpp_dec_float_50>*) y);
}











void LibYCplx_Add_D(YCplxPtr res, const YCplxPtr x, const double y)
{
    cpp_dec_float_50 temp = y;
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) + temp;
}


void LibYCplx_Sub_D(YCplxPtr res, const YCplxPtr x, const double y)
{
    cpp_dec_float_50 temp = y;
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) - temp;
}


void LibYCplx_D_Sub(YCplxPtr res, const YCplxPtr y, const double x)
{
    cpp_dec_float_50 temp = x;
	(*(std::complex<cpp_dec_float_50>*) res) = temp - (*(std::complex<cpp_dec_float_50>*) y);
}


void LibYCplx_Mul_D(YCplxPtr res, const YCplxPtr x, const double y)
{
    cpp_dec_float_50 temp = y;
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) * temp;
}


void LibYCplx_Div_D(YCplxPtr res, const YCplxPtr x, const double y)
{
    cpp_dec_float_50 temp = y;
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) / temp;
}


void LibYCplx_D_Div(YCplxPtr res, const YCplxPtr y, const double x)
{
    cpp_dec_float_50 temp = x;
	(*(std::complex<cpp_dec_float_50>*) res) = temp / (*(std::complex<cpp_dec_float_50>*) y);
}













void LibYCplx_Add_Si(YCplxPtr res, const YCplxPtr x, const int32_t y)
{
    cpp_dec_float_50 temp = y;
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) + temp;
}


void LibYCplx_Sub_Si(YCplxPtr res, const YCplxPtr x, const int32_t y)
{
    cpp_dec_float_50 temp = y;
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) - temp;
}


void LibYCplx_Si_Sub(YCplxPtr res, const YCplxPtr y, const int32_t x)
{
    cpp_dec_float_50 temp = x;
	(*(std::complex<cpp_dec_float_50>*) res) = temp - (*(std::complex<cpp_dec_float_50>*) y);
}


void LibYCplx_Mul_Si(YCplxPtr res, const YCplxPtr x, const int32_t y)
{
    cpp_dec_float_50 temp = y;
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) * temp;
}


void LibYCplx_Div_Si(YCplxPtr res, const YCplxPtr x, const int32_t y)
{
    cpp_dec_float_50 temp = y;
	(*(std::complex<cpp_dec_float_50>*) res) = (*(std::complex<cpp_dec_float_50>*) x) / temp;
}


void LibYCplx_Si_Div(YCplxPtr res, const YCplxPtr y, const int32_t x)
{
    cpp_dec_float_50 temp = x;
	(*(std::complex<cpp_dec_float_50>*) res) = temp / (*(std::complex<cpp_dec_float_50>*) y);
}









/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */



void LibYCplx_Set(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res)  = (*(std::complex<cpp_dec_float_50>*) x);
}

void LibYCplx_Set_Real(YCplxPtr res, const YRealPtr re)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::complex<cpp_dec_float_50>(*(cpp_dec_float_50*)re, 0);
}

void LibYCplx_Set2(YCplxPtr res, const YRealPtr re, const YRealPtr im)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::complex<cpp_dec_float_50>(*(cpp_dec_float_50*)re, *(cpp_dec_float_50*)im);
}

void LibYCplx_Set2_Str2(YRealPtr res, const char * str_re, const char * str_im)
{
    cpp_dec_float_50 re = static_cast<cpp_dec_float_50>(string(str_re));
    cpp_dec_float_50 im = static_cast<cpp_dec_float_50>(string(str_im));
	(*(std::complex<cpp_dec_float_50>*) res) = std::complex<cpp_dec_float_50>(re, im);
}


void LibYCplx_Abs(YRealPtr res, const YCplxPtr x)
{
	*(cpp_dec_float_50*)res = std::abs(*(std::complex<cpp_dec_float_50>*) x);
}

void LibYCplx_Arg(YRealPtr res, const YCplxPtr x)
{
	*(cpp_dec_float_50*)res = std::arg(*(std::complex<cpp_dec_float_50>*) x);
}

void LibYCplx_Imag(YRealPtr res, const YCplxPtr x)
{
	*(cpp_dec_float_50*)res = (*(std::complex<cpp_dec_float_50>*) x).imag();
}

void LibYCplx_Real(YRealPtr res, const YCplxPtr x)
{
	*(cpp_dec_float_50*)res = (*(std::complex<cpp_dec_float_50>*) x).real();
}


void LibYCplx_Conj(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::conj(*(std::complex<cpp_dec_float_50>*) x);
}

void LibYCplx_Proj(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::proj(*(std::complex<cpp_dec_float_50>*) x);
}






/* Roots  */



std::complex<cpp_dec_float_50> cplx_expm1(std::complex<cpp_dec_float_50> z)
{
    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
	cpp_dec_float_50 x = z.real();
	cpp_dec_float_50 y = z.imag();
	cpp_dec_float_50 resx =  expm1(x) * cos(y) + cosm1(y);
	cpp_dec_float_50 resy =  exp(x) * sin(y);
	return std::complex<cpp_dec_float_50>(resx, resy);
}



std::complex<cpp_dec_float_50> cplx_log1p(std::complex<cpp_dec_float_50> z)
{
    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
    /* resy =  atan2(y, 1 + x); */
	cpp_dec_float_50 x = z.real();
	cpp_dec_float_50 y = z.imag();
	cpp_dec_float_50 resx = 0.0 ;
	if ( (fabs(x) > 0.75) || (fabs(y) > 0.75) || (x < -0.5) )
    {
        resx = log(hypot(1 + x, y)) ;
    }
    else
    {
        resx = 0.5 * log1p(2*x + x*x + y*y);
    }
	cpp_dec_float_50 resy = atan2(y, 1 + x); ;
	return std::complex<cpp_dec_float_50>(resx, resy);
}



void LibYCplx_Sqrt(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::sqrt(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Sqrt1pm1(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 Half = 0.5;
    (*(std::complex<cpp_dec_float_50>*) res) = cplx_expm1(cplx_log1p(*(std::complex<cpp_dec_float_50>*) x) * Half);
}


void LibYCplx_Rsqrt(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) =One / std::sqrt(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Cbrt(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
    cpp_dec_float_50 Three = 3;
    cpp_dec_float_50 r = One / Three;
	(*(std::complex<cpp_dec_float_50>*) res) = std::pow(*(std::complex<cpp_dec_float_50>*) x, r);
}


void LibYCplx_Root_Si(YCplxPtr res, const YCplxPtr x, const int32_t k)
{
    cpp_dec_float_50 One = 1;
    cpp_dec_float_50 k_ = k;
    cpp_dec_float_50 r = One / k_;
	(*(std::complex<cpp_dec_float_50>*) res) = std::pow(*(std::complex<cpp_dec_float_50>*) x, r);
}





/* Exponential and related functions  */


void LibYCplx_Exp(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::exp(*(std::complex<cpp_dec_float_50>*) x);
}

void LibYCplx_Exp2(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::exp( (*(std::complex<cpp_dec_float_50>*) x)
                                                     * constants::ln_two<cpp_dec_float_50>() );
}

void LibYCplx_Exp10(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::exp( (*(std::complex<cpp_dec_float_50>*) x)
                                                     * constants::ln_ten<cpp_dec_float_50>() );
}



void LibYCplx_Expm1(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = cplx_expm1(*(std::complex<cpp_dec_float_50>*) x);
}

void LibYCplx_Exp2m1(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = cplx_expm1( (*(std::complex<cpp_dec_float_50>*) x)
                                                     * constants::ln_two<cpp_dec_float_50>() );
}

void LibYCplx_Exp10m1(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = cplx_expm1( (*(std::complex<cpp_dec_float_50>*) x)
                                                     * constants::ln_ten<cpp_dec_float_50>() );
}






/* Logarithms and related functions  */


void LibYCplx_Log(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::log(*(std::complex<cpp_dec_float_50>*) x);
}

void LibYCplx_Log2(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::log(*(std::complex<cpp_dec_float_50>*) x)
                                                    / constants::ln_two<cpp_dec_float_50>();
}

void LibYCplx_Log10(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::log10(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Log1p(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = cplx_log1p(*(std::complex<cpp_dec_float_50>*) x);
}

void LibYCplx_Log2p1(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = cplx_log1p(*(std::complex<cpp_dec_float_50>*) x)
                                                    / constants::ln_two<cpp_dec_float_50>();
}

void LibYCplx_Log10p1(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = cplx_log1p(*(std::complex<cpp_dec_float_50>*) x)
                                                    / constants::ln_two<cpp_dec_float_50>();
}





/* Power functions */


void LibYCplx_Square(YCplxPtr res, const YCplxPtr x)
{
    std::complex<cpp_dec_float_50> z = *(std::complex<cpp_dec_float_50>*) x;
	(*(std::complex<cpp_dec_float_50>*) res) =  z * z;
}


void LibYCplx_Cube(YCplxPtr res, const YCplxPtr x)
{
    std::complex<cpp_dec_float_50> z = *(std::complex<cpp_dec_float_50>*) x;
	(*(std::complex<cpp_dec_float_50>*) res) =  z * z * z;
}


void LibYCplx_Pow(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::pow(*(std::complex<cpp_dec_float_50>*) x,
                                                 *(std::complex<cpp_dec_float_50>*) y);
}



void LibYCplx_Powm1(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    (*(std::complex<cpp_dec_float_50>*) res) = cplx_expm1(std::log(*(std::complex<cpp_dec_float_50>*) x)
                                                           * (*(std::complex<cpp_dec_float_50>*) y));
}

void LibYCplx_Pow1p(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    (*(std::complex<cpp_dec_float_50>*) res) = std::exp(cplx_log1p(*(std::complex<cpp_dec_float_50>*) x)
                                                         * (*(std::complex<cpp_dec_float_50>*) y));
}

void LibYCplx_Pow1pm1(YCplxPtr res, const YCplxPtr x, const YCplxPtr y)
{
    (*(std::complex<cpp_dec_float_50>*) res) = cplx_expm1(cplx_log1p(*(std::complex<cpp_dec_float_50>*) x)
                                                           * (*(std::complex<cpp_dec_float_50>*) y));
}




void LibYCplx_Pow_Si(YCplxPtr res, const YCplxPtr x, const int32_t k)
{
    cpp_dec_float_50 k_ = k;
	(*(std::complex<cpp_dec_float_50>*) res) = std::pow(*(std::complex<cpp_dec_float_50>*) x, k_);
}


void LibYCplx_Compound_Si(YCplxPtr res, const YCplxPtr x, const int32_t k)
{
    cpp_dec_float_50 One = 1;
    cpp_dec_float_50 k_ = k;
	(*(std::complex<cpp_dec_float_50>*) res) = std::pow(One + (*(std::complex<cpp_dec_float_50>*) x), k_);
}






/* Trigonometric functions  */


void LibYCplx_Sin(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::sin(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Cos(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::cos(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Tan(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::tan(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Csc(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = One / std::sin(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Sec(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = One /  std::cos(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Cot(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = One /  std::tan(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_SinPi(YCplxPtr res, const YCplxPtr x)
{
	//(*(std::complex<cpp_dec_float_50>*) res) = std::sin(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_CosPi(YCplxPtr res, const YCplxPtr x)
{
	//(*(std::complex<cpp_dec_float_50>*) res) = std::cos(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_TanPi(YCplxPtr res, const YCplxPtr x)
{
	//(*(std::complex<cpp_dec_float_50>*) res) = std::tan(*(std::complex<cpp_dec_float_50>*) x);
}





/* Hyperbolic functions  */


void LibYCplx_Sinh(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::sinh(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Cosh(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::cosh(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Tanh(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::tanh(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Csch(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = One / std::sinh(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Sech(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = One /  std::cosh(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Coth(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = One /  std::tanh(*(std::complex<cpp_dec_float_50>*) x);
}





/* Inverse trigonometric functions  */


void LibYCplx_Asin(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::asin(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Acos(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::acos(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Atan(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::atan(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Acsc(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = std::asin(One / (*(std::complex<cpp_dec_float_50>*) x));
}


void LibYCplx_Asec(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = std::acos(One / (*(std::complex<cpp_dec_float_50>*) x));
}


void LibYCplx_Acot(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = std::atan(One / (*(std::complex<cpp_dec_float_50>*) x));
}






/* Inverse hyperbolic functions  */


void LibYCplx_Asinh(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::asinh(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Acosh(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::acosh(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Atanh(YCplxPtr res, const YCplxPtr x)
{
	(*(std::complex<cpp_dec_float_50>*) res) = std::atanh(*(std::complex<cpp_dec_float_50>*) x);
}


void LibYCplx_Acsch(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = std::asinh(One / (*(std::complex<cpp_dec_float_50>*) x));
}


void LibYCplx_Asech(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = std::acosh(One / (*(std::complex<cpp_dec_float_50>*) x));
}


void LibYCplx_Acoth(YCplxPtr res, const YCplxPtr x)
{
    cpp_dec_float_50 One = 1;
	(*(std::complex<cpp_dec_float_50>*) res) = std::atanh(One / (*(std::complex<cpp_dec_float_50>*) x));
}







