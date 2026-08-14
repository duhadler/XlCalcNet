


// See also: https://www.boost.org/doc/libs/1_80_0/boost/math/tools/user.hpp

// \home\MP64\math-boost\include\boost\math\tools\user.hpp

// Note: in exp_sinh_detail.hpp, line 229 changed to Real abterm1  [[maybe_unused]] = 1;

// Note: in fisher_f.hpp, line 247,  changed to    RealType x, y = 0;


#include <boost/math/tools/user.hpp>
#include <boost/math/tools/config.hpp>

#include "BoostZReal.h"

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
    cpp_dec_float_100 result = 0; \
    std::pair<cpp_dec_float_100, cpp_dec_float_100> dist_pair; \
    cpp_dec_float_100 xqp1 = cpp_dec_float_100(*(cpp_dec_float_100*)xqp); \
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
    (*(cpp_dec_float_100*)res) = result;


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
typedef Matrix<cpp_dec_float_100, Dynamic, 1> state_type_vec;
typedef state_type_vec* mpVectorPtr;


template<typename T>
class CppOptLibSolver : public Problem<T>
{
    public:
    using typename cppoptlib::Problem<T>::TVector;
    using typename cppoptlib::Problem<T>::THessian;
    CppOptLibSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_)
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
  ZRealFuncPtr func1, func2;
  mpVectorPtr matX, matGrad, matNorm;
};


void LibZReal_GradientDescentSolverSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr)
{
 printf("GradientDescentSolver");
    typedef   CppOptLibSolver<cpp_dec_float_100>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_, (mpVectorPtr)matNorm_);
    state_type_vec x = (*(mpVectorPtr)xPtr);
    GradientDescentSolver<TCppOptLibSolver> solver;
    cpp_dec_float_100 eps = std::numeric_limits<cpp_dec_float_100>::epsilon();
    Criteria<cpp_dec_float_100> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);
    solver.minimize(f, x);
    (*(mpVectorPtr)matX_) = x;
    (*(mpVectorPtr)matNorm_)(0) = f(x);
}


void LibZReal_ConjugatedGradientDescentSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr)
{
 printf("ConjugatedGradientDescentSolver");
    typedef   CppOptLibSolver<cpp_dec_float_100>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_, (mpVectorPtr)matNorm_);
    state_type_vec x = (*(mpVectorPtr)xPtr);
    ConjugatedGradientDescentSolver<TCppOptLibSolver> solver;
    cpp_dec_float_100 eps = std::numeric_limits<cpp_dec_float_100>::epsilon();
    Criteria<cpp_dec_float_100> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);
    solver.minimize(f, x);
    (*(mpVectorPtr)matX_) = x;
    (*(mpVectorPtr)matNorm_)(0) = f(x);
}




//void LibZReal_ConjugatedGradientDescentSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr)
//{
//
// printf("ConjugatedGradientDescentSolver");
//    typedef   CppOptLibSolver<cpp_dec_float_100>  TCppOptLibSolver;
//    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
//    state_type_vec x = (*xPtr);
//    ConjugatedGradientDescentSolver<TCppOptLibSolver> solver;
//
//    cpp_dec_float_100 eps = std::numeric_limits<cpp_dec_float_100>::epsilon();
//    Criteria<cpp_dec_float_100> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//
//    solver.minimize(f, x);
//
//    (*matX_) = x;
//    (*matNorm_)(0) = f(x);
//}




void LibZReal_BfgsSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr)
{
 printf("BfgsSolver");
    typedef   CppOptLibSolver<cpp_dec_float_100>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_, (mpVectorPtr)matNorm_);
    state_type_vec x = (*(mpVectorPtr)xPtr);
    BfgsSolver<TCppOptLibSolver> solver;
    cpp_dec_float_100 eps = std::numeric_limits<cpp_dec_float_100>::epsilon();
    Criteria<cpp_dec_float_100> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);
    solver.minimize(f, x);
    (*(mpVectorPtr)matX_) = x;
    (*(mpVectorPtr)matNorm_)(0) = f(x);
}


//void LibZReal_BfgsSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr)
//{
//
// printf("BfgsSolver");
//    typedef   CppOptLibSolver<cpp_dec_float_100>  TCppOptLibSolver;
//    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
//    state_type_vec x = (*xPtr);
//    BfgsSolver<TCppOptLibSolver> solver;
//
////    std::cout.precision(30);
//    cpp_dec_float_100 eps = std::numeric_limits<cpp_dec_float_100>::epsilon();
////    std::cout << "epsilon() = " << eps << std::endl;
////    std::cout << "\n";
//
//    Criteria<cpp_dec_float_100> m_stop;
//    m_stop.defaults();
//    m_stop.gradNorm = 1000 * eps;
//    solver.setStopCriteria(m_stop);
//
//    solver.minimize(f, x);
//
//    (*matX_) = x;
//    (*matNorm_)(0) = f(x);
//}




void LibZReal_LbfgsSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, DStatePtr matX_, DStatePtr matGrad_, DStatePtr matNorm_, DStatePtr xPtr)
{
 printf("LbfgsSolver");
    typedef   CppOptLibSolver<cpp_dec_float_100>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, (mpVectorPtr)matX_, (mpVectorPtr)matGrad_, (mpVectorPtr)matNorm_);
    state_type_vec x = (*(mpVectorPtr)xPtr);
    LbfgsSolver<TCppOptLibSolver> solver;
    cpp_dec_float_100 eps = std::numeric_limits<cpp_dec_float_100>::epsilon();
    Criteria<cpp_dec_float_100> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);
    solver.minimize(f, x);
    (*(mpVectorPtr)matX_) = x;
    (*(mpVectorPtr)matNorm_)(0) = f(x);
}


void LibZReal_LbfgsSolver(ZRealFuncPtr f1, ZRealFuncPtr f2, mpVectorPtr matX_, mpVectorPtr matGrad_, mpVectorPtr matNorm_, mpVectorPtr xPtr)
{

 printf("LbfgsSolver");
    typedef   CppOptLibSolver<cpp_dec_float_100>  TCppOptLibSolver;
    TCppOptLibSolver f(f1, f2, matX_, matGrad_, matNorm_);
    state_type_vec x = (*xPtr);
    LbfgsSolver<TCppOptLibSolver> solver;

    cpp_dec_float_100 eps = std::numeric_limits<cpp_dec_float_100>::epsilon();
    Criteria<cpp_dec_float_100> m_stop;
    m_stop.defaults();
    m_stop.gradNorm = 1000 * eps;
    solver.setStopCriteria(m_stop);

    solver.minimize(f, x);

    (*matX_) = x;
    (*matNorm_)(0) = f(x);
}








//*********************** Boost/CppOptLib **********************************

using namespace Eigen;
//using namespace cppoptlib;
typedef Matrix<cpp_dec_float_100, Dynamic, 1> state_type_vec;
typedef state_type_vec* mpVectorPtr;




//*********************** Boost Odeint **********************************

using namespace boost::numeric::odeint;

DStatePtr LibZReal_StateInit_Func_N(int N)
{
    mpVectorPtr x = new(state_type_vec);
    (*x).resize(N);
    (*x).setZero();
    return x;
}


void LibZReal_StateClear(DStatePtr x)
{
    delete ((mpVectorPtr)x);
}


void LibZReal_StateGetCoeff(ZRealPtr res, long row, DStatePtr source)
{
    (*(cpp_dec_float_100*)res) = (*(mpVectorPtr) source).coeff(row);
}



void LibZReal_StateSetCoeff(DStatePtr result, ZRealPtr source, long row)
{
    (*(mpVectorPtr) result)(row) = *(cpp_dec_float_100*)source;
}

void LibZReal_StateGetSize(long *result, DStatePtr x)
{
    *result = (long)(*(mpVectorPtr)x).size();
}







struct Boost_LibZReal_Write
{
	Boost_LibZReal_Write(DAnyFuncPtr2 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, const cpp_dec_float_100 t)
	{
	    cpp_dec_float_100 fx = t;
		func1(&x, &fx);
	}
	DAnyFuncPtr2 func1;
};


struct Boost_LibZReal_Func_Vec
{
	Boost_LibZReal_Func_Vec(DAnyFuncPtr3 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, state_type_vec &dxdt, cpp_dec_float_100 t) const
	{
	    cpp_dec_float_100 fx = t;
		func1(&x, &dxdt, &fx);
	}
	DAnyFuncPtr3 func1;
};




/* Constant steppers */

void LibZReal_Const_RungeKutta4(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
	integrate_const(runge_kutta4<state_type_vec, cpp_dec_float_100>(), Boost_LibZReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibZReal_Write(f2));
}

void LibZReal_Const_RungeKuttaCashKarp54(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
	integrate_const(runge_kutta_cash_karp54<state_type_vec, cpp_dec_float_100>(), Boost_LibZReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibZReal_Write(f2));
}

void LibZReal_Const_RungeKuttaDopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
	integrate_const(runge_kutta_dopri5<state_type_vec, cpp_dec_float_100>(), Boost_LibZReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibZReal_Write(f2));
}

void LibZReal_Const_RungeKuttaFehlberg78(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
	integrate_const(runge_kutta_fehlberg78<state_type_vec, cpp_dec_float_100>(), Boost_LibZReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibZReal_Write(f2));
}

void LibZReal_Const_AdamsBashforthMoulton(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
	integrate_const(adams_bashforth_moulton<5, state_type_vec, cpp_dec_float_100>(), Boost_LibZReal_Func_Vec(f1),
		*(state_type_vec*)x, start_time, end_time, dt, Boost_LibZReal_Write(f2));
}


/* Adaptive steppers */

void LibZReal_Adaptive_RungeKuttaDopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
    cpp_dec_float_100 eps_abs = *(cpp_dec_float_100*)eps_abs_;
    cpp_dec_float_100 eps_rel = *(cpp_dec_float_100*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_dopri5<state_type_vec, cpp_dec_float_100>() ) , Boost_LibZReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibZReal_Write(f2));
}


void LibZReal_Adaptive_RungeKuttaCashKarp54(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
    cpp_dec_float_100 eps_abs = *(cpp_dec_float_100*)eps_abs_;
    cpp_dec_float_100 eps_rel = *(cpp_dec_float_100*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_cash_karp54<state_type_vec, cpp_dec_float_100>() ) , Boost_LibZReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibZReal_Write(f2));
}


void LibZReal_Adaptive_RungeKuttaFehlberg78(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
    cpp_dec_float_100 eps_abs = *(cpp_dec_float_100*)eps_abs_;
    cpp_dec_float_100 eps_rel = *(cpp_dec_float_100*)eps_rel_;

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_fehlberg78<state_type_vec, cpp_dec_float_100>() ) , Boost_LibZReal_Func_Vec(f1) ,
        *(state_type_vec*)x, start_time , end_time , dt , Boost_LibZReal_Write(f2));
}


void LibZReal_Adaptive_BulirschStoer(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
    cpp_dec_float_100 eps_abs = *(cpp_dec_float_100*)eps_abs_;
    cpp_dec_float_100 eps_rel = *(cpp_dec_float_100*)eps_rel_;

	bulirsch_stoer< state_type_vec, cpp_dec_float_100 > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibZReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibZReal_Write(f2));
}

/* Dense Output steppers */


void LibZReal_DenseOutput_Dopri5(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
    cpp_dec_float_100 eps_abs = *(cpp_dec_float_100*)eps_abs_;
    cpp_dec_float_100 eps_rel = *(cpp_dec_float_100*)eps_rel_;

    typedef runge_kutta_dopri5< state_type_vec, cpp_dec_float_100 > dopri5_type;
    typedef controlled_runge_kutta< dopri5_type > controlled_dopri5_type;
    typedef dense_output_runge_kutta< controlled_dopri5_type > dense_output_dopri5_type;
    dense_output_dopri5_type dopri5 = make_dense_output( eps_abs , eps_rel , dopri5_type() );
    integrate_adaptive( dopri5, Boost_LibZReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibZReal_Write(f2));
}


void LibZReal_DenseOutput_BulirschStoer(DAnyFuncPtr3 f1, DAnyFuncPtr2 f2, DStatePtr x, ZRealPtr start_time_, ZRealPtr end_time_, ZRealPtr dt_, ZRealPtr eps_abs_, ZRealPtr eps_rel_)
{
    cpp_dec_float_100 start_time = *(cpp_dec_float_100*)start_time_;
    cpp_dec_float_100 end_time = *(cpp_dec_float_100*)end_time_;
    cpp_dec_float_100 dt = *(cpp_dec_float_100*)dt_;
    cpp_dec_float_100 eps_abs = *(cpp_dec_float_100*)eps_abs_;
    cpp_dec_float_100 eps_rel = *(cpp_dec_float_100*)eps_rel_;

	bulirsch_stoer_dense_out< state_type_vec, cpp_dec_float_100 > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_LibZReal_Func_Vec(f1),
        *(state_type_vec*)x, start_time, end_time, dt, Boost_LibZReal_Write(f2));
}







//*********************** Boost Numerical Calculus, ZReal **********************************




struct ZRealFunctor1
{
  ZRealFunctor1(ZRealFuncPtr f1):func1(f1) {}
  cpp_dec_float_100 operator()(cpp_dec_float_100 x)
  {
    cpp_dec_float_100 fx;
	func1( &x, &fx);
    return fx;
  }
private:
	ZRealFuncPtr func1;
};


struct ZRealFunctor2
{
  ZRealFunctor2(ZRealFuncPtr f1, ZRealFuncPtr f2):func1(f1), func2(f2) {}
  std::pair<cpp_dec_float_100, cpp_dec_float_100> operator()(cpp_dec_float_100 x)
  {
    cpp_dec_float_100 fx, dx;
	func1( &x, &fx);
	func2( &x, &dx);
    return std::make_pair(fx, dx);
  }
private:
	ZRealFuncPtr func1, func2;
};


struct ZRealFunctor3
{
  ZRealFunctor3(ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3):func1(f1), func2(f2), func3(f3) {}
  std::tuple<cpp_dec_float_100, cpp_dec_float_100, cpp_dec_float_100> operator()(cpp_dec_float_100 x)
  {
    cpp_dec_float_100 fx, dx, d2x;
	func1( &x, &fx);
	func2( &x, &dx);
	func3( &x, &d2x);
    return std::make_tuple(fx, dx, d2x);
  }
private:
	ZRealFuncPtr func1, func2, func3;
};



void LibZReal_BracketRoot(ZRealPtr res1, ZRealPtr res2, int* iter, ZRealFuncPtr f1, ZRealPtr guess_, ZRealPtr factor_, bool is_rising, int get_digits, unsigned int maxit)
{
    cpp_dec_float_100 guess = *(cpp_dec_float_100*)guess_;
    cpp_dec_float_100 factor = *(cpp_dec_float_100*)factor_;
	uintmax_t it = maxit;
	eps_tolerance<cpp_dec_float_100> tol(get_digits);
	std::pair<cpp_dec_float_100, cpp_dec_float_100> r = bracket_and_solve_root(ZRealFunctor1(f1), guess, factor, is_rising, tol, it);
	cpp_dec_float_100 error = (r.second - r.first) / 2;
	cpp_dec_float_100 result = r.first + error;
    (*(cpp_dec_float_100*)res1) = result;
    (*(cpp_dec_float_100*)res2) = error;
    *iter = (int) it;
}



void LibZReal_NewtonRaphson(ZRealPtr res,  int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_dec_float_100 guess = *(cpp_dec_float_100*)guess_;
    cpp_dec_float_100 xmin = *(cpp_dec_float_100*)xmin_;
    cpp_dec_float_100 xmax = *(cpp_dec_float_100*)xmax_;
    uintmax_t it = maxit;
    cpp_dec_float_100 result = newton_raphson_iterate(ZRealFunctor2(f1, f2), guess, xmin, xmax, get_digits, it);
    (*(cpp_dec_float_100*)res) = result;
    *iter = (int) it;
}



void LibZReal_Halley(ZRealPtr res, int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_dec_float_100 guess = *(cpp_dec_float_100*)guess_;
    cpp_dec_float_100 xmin = *(cpp_dec_float_100*)xmin_;
    cpp_dec_float_100 xmax = *(cpp_dec_float_100*)xmax_;
    uintmax_t it = maxit;
    cpp_dec_float_100 result = halley_iterate(ZRealFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
    (*(cpp_dec_float_100*)res) = result;
    *iter = (int) it;
}



void LibZReal_Schroder(ZRealPtr res, int* iter, ZRealFuncPtr f1, ZRealFuncPtr f2, ZRealFuncPtr f3, ZRealPtr guess_, ZRealPtr xmin_, ZRealPtr xmax_, int get_digits, unsigned int maxit)
{
    cpp_dec_float_100 guess = *(cpp_dec_float_100*)guess_;
    cpp_dec_float_100 xmin = *(cpp_dec_float_100*)xmin_;
    cpp_dec_float_100 xmax = *(cpp_dec_float_100*)xmax_;
    uintmax_t it = maxit;
    cpp_dec_float_100 result = schroder_iterate(ZRealFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
    (*(cpp_dec_float_100*)res) = result;
    *iter = (int) it;
}



void LibZReal_Brent_Minimum(ZRealPtr res, ZRealPtr resFx, int* iter, ZRealFuncPtr f1, ZRealPtr bracket_min_, ZRealPtr bracket_max_, int bits, unsigned int maxit)
{
    cpp_dec_float_100 bracket_min = *(cpp_dec_float_100*)bracket_min_;
    cpp_dec_float_100 bracket_max = *(cpp_dec_float_100*)bracket_max_;
    uintmax_t it = maxit;
    std::pair<cpp_dec_float_100, cpp_dec_float_100> r = brent_find_minima(ZRealFunctor1(f1), bracket_min, bracket_max, bits, it);
    (*(cpp_dec_float_100*)res) = r.first;
    (*(cpp_dec_float_100*)resFx) = r.second;
    *iter = (int) it;
}





void LibZReal_Trapezoidal(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_)
{
    cpp_dec_float_100 a = *(cpp_dec_float_100*)a_;
    cpp_dec_float_100 b = *(cpp_dec_float_100*)b_;
    cpp_dec_float_100 tol = sqrt(std::numeric_limits<cpp_dec_float_100>::epsilon());
    cpp_dec_float_100 error;
    cpp_dec_float_100 L1;
    size_t max_refinements = 24;
    auto f = [&f1](cpp_dec_float_100 x) {
        cpp_dec_float_100 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_100 result = trapezoidal(f, a, b, tol, max_refinements, &error, &L1);
    (*(cpp_dec_float_100*)res1) = result;
    (*(cpp_dec_float_100*)res2) = error;
    (*(cpp_dec_float_100*)res3) = (L1/fabs(result));
}



// 7, 15, 20, 25 and 30

void LibZReal_GaussLegendre(ZRealPtr res1, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_)
{
    cpp_dec_float_100 a = *(cpp_dec_float_100*)a_;
    cpp_dec_float_100 b = *(cpp_dec_float_100*)b_;
    cpp_dec_float_100 L1;
    auto f = [&f1](cpp_dec_float_100 x) {
        cpp_dec_float_100 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_100 result = gauss<cpp_dec_float_100, 7>::integrate(f, a, b, &L1);
    (*(cpp_dec_float_100*)res1) = result;
    (*(cpp_dec_float_100*)res3) = (L1/fabs(result));
}



//15, 31, 41, 51 and 61

void LibZReal_GaussKronrod(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_)
{
    cpp_dec_float_100 a = *(cpp_dec_float_100*)a_;
    cpp_dec_float_100 b = *(cpp_dec_float_100*)b_;
    cpp_dec_float_100 tol = sqrt(std::numeric_limits<cpp_dec_float_100>::epsilon());
    cpp_dec_float_100 error;
    cpp_dec_float_100 L1;
    unsigned max_depth = 15;
    auto f = [&f1](cpp_dec_float_100 x) {
        cpp_dec_float_100 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_100 result = gauss_kronrod<cpp_dec_float_100, 15>::integrate(f, a, b, max_depth, tol, &error, &L1);
    (*(cpp_dec_float_100*)res1) = result;
    (*(cpp_dec_float_100*)res2) = error;
    (*(cpp_dec_float_100*)res3) = (L1/fabs(result));
}



void LibZReal_TanhSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1, ZRealPtr a_, ZRealPtr b_)
{
    cpp_dec_float_100 a = *(cpp_dec_float_100*)a_;
    cpp_dec_float_100 b = *(cpp_dec_float_100*)b_;
    tanh_sinh<cpp_dec_float_100> integrator;
    auto f = [&f1](cpp_dec_float_100 x) {
        cpp_dec_float_100 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_100 termination = sqrt(std::numeric_limits<cpp_dec_float_100>::epsilon());
    cpp_dec_float_100  error;
    cpp_dec_float_100  L1;
    std::size_t levels = 0;
    cpp_dec_float_100 result = integrator.integrate(f, a, b, termination, &error, &L1, &levels);
    (*(cpp_dec_float_100*)res1) = result;
    (*(cpp_dec_float_100*)res2) = error;
    (*(cpp_dec_float_100*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}




void LibZReal_SinhSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1)
{
    sinh_sinh<cpp_dec_float_100> integrator;
    auto f = [&f1](cpp_dec_float_100 x) {
        cpp_dec_float_100 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_100 termination = sqrt(std::numeric_limits<cpp_dec_float_100>::epsilon());
    cpp_dec_float_100  error;
    cpp_dec_float_100  L1;
    std::size_t levels = 0;
    cpp_dec_float_100 result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*(cpp_dec_float_100*)res1) = result;
    (*(cpp_dec_float_100*)res2) = error;
    (*(cpp_dec_float_100*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}



void LibZReal_ExpSinh(ZRealPtr res1, ZRealPtr res2, ZRealPtr res3, int* levels_, ZRealFuncPtr f1)
{
    exp_sinh<cpp_dec_float_100> integrator;
    auto f = [&f1](cpp_dec_float_100 x) {
        cpp_dec_float_100 fx;
        f1( &x, &fx);
        return fx;
        };
    cpp_dec_float_100 termination = sqrt(std::numeric_limits<cpp_dec_float_100>::epsilon());
    cpp_dec_float_100  error;
    cpp_dec_float_100  L1;
    std::size_t levels = 0;
    cpp_dec_float_100 result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*(cpp_dec_float_100*)res1) = result;
    (*(cpp_dec_float_100*)res2) = error;
    (*(cpp_dec_float_100*)res3) = (L1/fabs(result));
    *levels_ = (int) levels;
}



void LibZReal_Ooura_Cos(ZRealPtr res1, ZRealPtr res2, ZRealFuncPtr f1)
{
    cpp_dec_float_100 omega = 1;
    cpp_dec_float_100 tol = 2 * sqrt(std::numeric_limits<cpp_dec_float_100>::epsilon());
	auto integrator = ooura_fourier_cos<cpp_dec_float_100>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](cpp_dec_float_100 x) {
        cpp_dec_float_100 fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<cpp_dec_float_100, cpp_dec_float_100> r = integrator.integrate(f, omega);
    (*(cpp_dec_float_100*)res1) =  r.first;
    (*(cpp_dec_float_100*)res2) =  r.second;
}



void LibZReal_Ooura_Sin(ZRealPtr res1, ZRealPtr res2, ZRealFuncPtr f1)
{
    cpp_dec_float_100 omega = 1;
    cpp_dec_float_100 tol = 2 * sqrt(std::numeric_limits<cpp_dec_float_100>::epsilon());
	auto integrator = ooura_fourier_sin<cpp_dec_float_100>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](cpp_dec_float_100 x) {
        cpp_dec_float_100 fx;
        f1( &x, &fx);
        return fx;
        };
	std::pair<cpp_dec_float_100, cpp_dec_float_100> r = integrator.integrate(f, omega);
    (*(cpp_dec_float_100*)res1) =  r.first;
    (*(cpp_dec_float_100*)res2) =  r.second;
}




//***********************  Boost Distributions, ZReal  **********************************


void LibZReal_ArcsineDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b)
{
    cpp_dec_float_100 a1 = *(cpp_dec_float_100*)a;
    cpp_dec_float_100 b1 = *(cpp_dec_float_100*)b;
    arcsine_distribution<cpp_dec_float_100> dist(a1, b1); MP_DIST_RETURN
}



void LibZReal_BernoulliDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr p)
{
    cpp_dec_float_100 p1 = *(cpp_dec_float_100*)p;
    bernoulli_distribution<cpp_dec_float_100> dist(p1); MP_DIST_RETURN
}



void LibZReal_BetaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b)
{
    cpp_dec_float_100 a1 = *(cpp_dec_float_100*)a;
    cpp_dec_float_100 b1 = *(cpp_dec_float_100*)b;
    beta_distribution<cpp_dec_float_100> dist(a1, b1); MP_DIST_RETURN
}



void LibZReal_BinomialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr n, ZRealPtr p)
{
    cpp_dec_float_100 n1 = *(cpp_dec_float_100*)n;
    cpp_dec_float_100 p1 = *(cpp_dec_float_100*)p;
    binomial_distribution<cpp_dec_float_100> dist(n1, p1); MP_DIST_RETURN
}



void LibZReal_CauchyDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    cpp_dec_float_100 location1 = *(cpp_dec_float_100*)location;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    cauchy_distribution<cpp_dec_float_100> dist(location1, scale1); MP_DIST_RETURN
}



void LibZReal_Chi2Dist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu)
{
    cpp_dec_float_100 nu1 = *(cpp_dec_float_100*)nu;
    chi_squared_distribution<cpp_dec_float_100> dist(nu1); MP_DIST_RETURN
}



void LibZReal_ExponentialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lambda)
{
    cpp_dec_float_100 lambda1 = *(cpp_dec_float_100*)lambda;
    exponential_distribution<cpp_dec_float_100> dist(lambda1); MP_DIST_RETURN
}



void LibZReal_ExtremeValueDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    cpp_dec_float_100 location1 = *(cpp_dec_float_100*)location;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    extreme_value_distribution<cpp_dec_float_100> dist(location1, scale1); MP_DIST_RETURN
}



void LibZReal_FisherFDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mu, ZRealPtr nu)
{
    cpp_dec_float_100 mu1 = *(cpp_dec_float_100*)mu;
    cpp_dec_float_100 nu1 = *(cpp_dec_float_100*)nu;
    fisher_f_distribution<cpp_dec_float_100> dist(mu1, nu1); MP_DIST_RETURN
}



void LibZReal_GammaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale)
{
    cpp_dec_float_100 shape1 = *(cpp_dec_float_100*)shape;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    gamma_distribution<cpp_dec_float_100> dist(shape1, scale1); MP_DIST_RETURN
}



void LibZReal_GeometricDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr p)
{
    cpp_dec_float_100 p1 = *(cpp_dec_float_100*)p;
    geometric_distribution<cpp_dec_float_100> dist(p1); MP_DIST_RETURN
}



void LibZReal_HypergeometricDist(long Target, ZRealPtr res, ZRealPtr xqp, unsigned r, unsigned n, unsigned N)
{
    hypergeometric_distribution<cpp_dec_float_100> dist(r, n, N); MP_DIST_RETURN
}



void LibZReal_InverseChi2Dist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr df, ZRealPtr scale)
{
    cpp_dec_float_100 df1 = *(cpp_dec_float_100*)df;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    inverse_chi_squared_distribution<cpp_dec_float_100> dist(df1, scale1); MP_DIST_RETURN
}



void LibZReal_InverseGammaDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale)
{
    cpp_dec_float_100 shape1 = *(cpp_dec_float_100*)shape;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    inverse_gamma_distribution<cpp_dec_float_100> dist(shape1, scale1); MP_DIST_RETURN
}



void LibZReal_InverseGaussianDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr scale)
{
    cpp_dec_float_100 mean1 = *(cpp_dec_float_100*)mean_;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    inverse_gaussian_distribution<cpp_dec_float_100> dist(mean1, scale1); MP_DIST_RETURN
}



void LibZReal_LaplaceDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    cpp_dec_float_100 location1 = *(cpp_dec_float_100*)location;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    laplace_distribution<cpp_dec_float_100> dist(location1, scale1); MP_DIST_RETURN
}



void LibZReal_LogisticDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    cpp_dec_float_100 location1 = *(cpp_dec_float_100*)location;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    logistic_distribution<cpp_dec_float_100> dist(location1, scale1); MP_DIST_RETURN
}



void LibZReal_LognormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr location, ZRealPtr scale)
{
    cpp_dec_float_100 location1 = *(cpp_dec_float_100*)location;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    lognormal_distribution<cpp_dec_float_100> dist(location1, scale1); MP_DIST_RETURN
}



void LibZReal_NegBinomialDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr n, ZRealPtr p)
{
    cpp_dec_float_100 n1 = *(cpp_dec_float_100*)n;
    cpp_dec_float_100 p1 = *(cpp_dec_float_100*)p;
    negative_binomial_distribution<cpp_dec_float_100> dist(n1, p1); MP_DIST_RETURN
}


void LibZReal_Chi2NCDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu, ZRealPtr nc)
{
    cpp_dec_float_100 nu1 = *(cpp_dec_float_100*)nu;
    cpp_dec_float_100 nc1 = *(cpp_dec_float_100*)nc;
    non_central_chi_squared_distribution<cpp_dec_float_100> dist(nu1, nc1); MP_DIST_RETURN
}


void LibZReal_StudentTNCDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu, ZRealPtr delta)
{
    cpp_dec_float_100 nu1 = *(cpp_dec_float_100*)nu;
    cpp_dec_float_100 delta1 = *(cpp_dec_float_100*)delta;
    non_central_t_distribution<cpp_dec_float_100> dist(nu1, delta1); MP_DIST_RETURN
}



void LibZReal_FisherNCDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mu, ZRealPtr nu, ZRealPtr nc)
{
    cpp_dec_float_100 mu1 = *(cpp_dec_float_100*)mu;
    cpp_dec_float_100 nu1 = *(cpp_dec_float_100*)nu;
    cpp_dec_float_100 nc1 = *(cpp_dec_float_100*)nc;
    non_central_f_distribution<cpp_dec_float_100> dist(mu1, nu1, nc1); MP_DIST_RETURN
}



void LibZReal_BetaNCDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr a, ZRealPtr b, ZRealPtr nc)
{
    cpp_dec_float_100 a1 = *(cpp_dec_float_100*)a;
    cpp_dec_float_100 b1 = *(cpp_dec_float_100*)b;
    cpp_dec_float_100 nc1 = *(cpp_dec_float_100*)nc;
    non_central_beta_distribution<cpp_dec_float_100> dist(a1, b1, nc1); MP_DIST_RETURN
}



void LibZReal_NormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr stdev)
{
    cpp_dec_float_100 mean1 = *(cpp_dec_float_100*)mean_;
    cpp_dec_float_100 stdev1 = *(cpp_dec_float_100*)stdev;
    normal_distribution<cpp_dec_float_100> dist(mean1, stdev1); MP_DIST_RETURN
}



void LibZReal_ParetoDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale)
{
    cpp_dec_float_100 shape1 = *(cpp_dec_float_100*)shape;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    pareto_distribution<cpp_dec_float_100> dist(shape1, scale1); MP_DIST_RETURN
}



void LibZReal_PoissonDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu)
{
    cpp_dec_float_100 nu1 = *(cpp_dec_float_100*)nu;
    poisson_distribution<cpp_dec_float_100> dist(nu1); MP_DIST_RETURN
}



void LibZReal_RayleighDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu)
{
    cpp_dec_float_100 nu1 = *(cpp_dec_float_100*)nu;
    rayleigh_distribution<cpp_dec_float_100> dist(nu1); MP_DIST_RETURN
}



void LibZReal_SkewNormalDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr mean_, ZRealPtr scale, ZRealPtr shape)
{
    cpp_dec_float_100 mean1 = *(cpp_dec_float_100*)mean_;
    cpp_dec_float_100 shape1 = *(cpp_dec_float_100*)shape;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    skew_normal_distribution<cpp_dec_float_100> dist(mean1, scale1, shape1); MP_DIST_RETURN
}



void LibZReal_StudentTDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr nu)
{
    cpp_dec_float_100 nu1 = *(cpp_dec_float_100*)nu;
    students_t_distribution<cpp_dec_float_100> dist(nu1); MP_DIST_RETURN
}



void LibZReal_TriangularDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lower, ZRealPtr mode_, ZRealPtr upper)
{
    cpp_dec_float_100 lower1 = *(cpp_dec_float_100*)lower;
    cpp_dec_float_100 mode1 = *(cpp_dec_float_100*)mode_;
    cpp_dec_float_100 upper1 = *(cpp_dec_float_100*)upper;
    triangular_distribution<cpp_dec_float_100> dist(lower1, mode1, upper1); MP_DIST_RETURN
}



void LibZReal_WeibullDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr shape, ZRealPtr scale)
{
    cpp_dec_float_100 shape1 = *(cpp_dec_float_100*)shape;
    cpp_dec_float_100 scale1 = *(cpp_dec_float_100*)scale;
    weibull_distribution<cpp_dec_float_100> dist(shape1, scale1); MP_DIST_RETURN
}



void LibZReal_UniformDist(long Target, ZRealPtr res, ZRealPtr xqp, ZRealPtr lower, ZRealPtr upper)
{
    cpp_dec_float_100 lower1 = *(cpp_dec_float_100*)lower;
    cpp_dec_float_100 upper1 = *(cpp_dec_float_100*)upper;
    uniform_distribution<cpp_dec_float_100> dist(lower1, upper1); MP_DIST_RETURN
}





//*********************** Boost Special functions , ZReal **********************************




void LibZReal_Ulp(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = ulp(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_BernoulliB2n(ZRealPtr res, const int n)
{
	(*(cpp_dec_float_100*)res) = bernoulli_b2n<cpp_dec_float_100>(n);
}



void LibZReal_TangentT2n(ZRealPtr res, const int n)
{
	(*(cpp_dec_float_100*)res) = tangent_t2n<cpp_dec_float_100>(n);
}



void LibZReal_Sqrt1pm1(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sqrt1pm1(*(cpp_dec_float_100*)x);
}



void LibZReal_SinPi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sin_pi(*(cpp_dec_float_100*)x);
}

void LibZReal_CosPi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cos_pi(*(cpp_dec_float_100*)x);
}

void LibZReal_TanPi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sin_pi(*(cpp_dec_float_100*)x) / cos_pi(*(cpp_dec_float_100*)x);
}



void LibZReal_CscPi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (1.0) / sin_pi(*(cpp_dec_float_100*)x);
}

void LibZReal_SecPi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (1.0) / cos_pi(*(cpp_dec_float_100*)x);
}

void LibZReal_CotPi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cos_pi(*(cpp_dec_float_100*)x) / sin_pi(*(cpp_dec_float_100*)x);
}




void LibZReal_SincPi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sinc_pi(*(cpp_dec_float_100*)x);
}



void LibZReal_SinhcPi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sinhc_pi(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Tgamma_(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = tgamma(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_Tgamma1pm1(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = tgamma1pm1(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Lgamma_(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = lgamma(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Digamma(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = digamma(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Trigamma(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = trigamma(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Factorial(ZRealPtr res, const ZRealPtr x)
{
    cpp_dec_float_100 xt = cpp_dec_float_100(*(cpp_dec_float_100*)x);
    cpp_dec_float_100 result = tgamma(xt + 1);
	(*(cpp_dec_float_100*)res) = result;
}



void LibZReal_DoubleFactorial(ZRealPtr res, const ZRealPtr x)
{
    cpp_dec_float_100 xt = cpp_dec_float_100(*(cpp_dec_float_100*)x);
    cpp_dec_float_100 xt2 = xt/2;
    cpp_dec_float_100 t1 = (cos_pi(xt)-1)/4;
    cpp_dec_float_100 pi2 = constants::half_pi<cpp_dec_float_100>();
    cpp_dec_float_100 t2 = pow(pi2, t1);
    cpp_dec_float_100 result = exp2(xt2) * t2 * tgamma(xt2+1);
	(*(cpp_dec_float_100*)res) = result;
}





void LibZReal_Erf_(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = erf(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Erfc_(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = erfc(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Erf_inv(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = erf_inv(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Erfc_inv(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = erfc_inv(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_AiryAi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = airy_ai(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_AiryBi(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = airy_bi(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_AiryAiPrime(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = airy_ai_prime(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_AiryBiPrime(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = airy_bi_prime(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Aizero(ZRealPtr res, const int n)
{
	(*(cpp_dec_float_100*)res) = airy_ai_zero<cpp_dec_float_100>(n);
}



void LibZReal_Bizero(ZRealPtr res, const int n)
{
	(*(cpp_dec_float_100*)res) = airy_bi_zero<cpp_dec_float_100>(n);
}



void LibZReal_Ellint_1_K(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = ellint_1(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Ellint_2_K(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = ellint_2(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Zeta(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = zeta(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Ei(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = expint(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_LambertW0(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = lambert_w0(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_LambertWm1(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = lambert_wm1(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_LambertW0Prime(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = lambert_w0_prime(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_LambertWm1Prime(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = lambert_wm1_prime(cpp_dec_float_100(*(cpp_dec_float_100*)x));
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void LibZReal_Powm1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b)
{
	(*(cpp_dec_float_100*)res) = powm1(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b));
}



void LibZReal_TgammaRatio(ZRealPtr res, const ZRealPtr a, const ZRealPtr b)
{
	(*(cpp_dec_float_100*)res) = tgamma_ratio(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b));
}



void LibZReal_TgammaDeltaRatio(ZRealPtr res, const ZRealPtr a, const ZRealPtr b)
{
	(*(cpp_dec_float_100*)res) = tgamma_delta_ratio(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b));
}



void LibZReal_Binomial(ZRealPtr res, const ZRealPtr n, const ZRealPtr k)
{
    cpp_dec_float_100 nt = cpp_dec_float_100(*(cpp_dec_float_100*)n);
    cpp_dec_float_100 kt = cpp_dec_float_100(*(cpp_dec_float_100*)k);
    cpp_dec_float_100 result = tgamma(nt+1) / ( tgamma(nt+1) * tgamma(nt-kt+1) );
	(*(cpp_dec_float_100*)res) = result;
}

void LibZReal_RisingFactorial(ZRealPtr res, const ZRealPtr x, const ZRealPtr n)
{
    cpp_dec_float_100 xt = cpp_dec_float_100(*(cpp_dec_float_100*)x);
    cpp_dec_float_100 nt = cpp_dec_float_100(*(cpp_dec_float_100*)n);
    cpp_dec_float_100 result = tgamma(xt+nt) / tgamma(xt);
	(*(cpp_dec_float_100*)res) = result;
}




void LibZReal_FallingFactorial(ZRealPtr res, const ZRealPtr x, const ZRealPtr n)
{
    cpp_dec_float_100 xt = cpp_dec_float_100(*(cpp_dec_float_100*)x);
    cpp_dec_float_100 nt = cpp_dec_float_100(*(cpp_dec_float_100*)n);
    cpp_dec_float_100 result = tgamma(xt+1) / tgamma(xt-nt+1);
	(*(cpp_dec_float_100*)res) = result;
}




void LibZReal_BesselJ(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cyl_bessel_j(cpp_dec_float_100(*(cpp_dec_float_100*)v), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_BesselY(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cyl_neumann(cpp_dec_float_100(*(cpp_dec_float_100*)v), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_BesselI(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cyl_bessel_i(cpp_dec_float_100(*(cpp_dec_float_100*)v), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_BesselK(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cyl_bessel_k(cpp_dec_float_100(*(cpp_dec_float_100*)v), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_SphBessel(ZRealPtr res, const unsigned v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sph_bessel(v, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_SphNeumann(ZRealPtr res, const unsigned v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sph_neumann(v, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}





void LibZReal_BesselJPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cyl_bessel_j_prime(cpp_dec_float_100(*(cpp_dec_float_100*)v), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_BesselYPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cyl_neumann_prime(cpp_dec_float_100(*(cpp_dec_float_100*)v), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_BesselIPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cyl_bessel_i_prime(cpp_dec_float_100(*(cpp_dec_float_100*)v), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_BesselKPrime(ZRealPtr res, const ZRealPtr v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cyl_bessel_k_prime(cpp_dec_float_100(*(cpp_dec_float_100*)v), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_SphBesselPrime(ZRealPtr res, const unsigned v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sph_bessel_prime(v, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_SphNeumannPrime(ZRealPtr res, const unsigned v, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sph_neumann_prime(v, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}





void LibZReal_BesselJZero(ZRealPtr res, const ZRealPtr v, const int m)
{
	(*(cpp_dec_float_100*)res) = cyl_bessel_j_zero(cpp_dec_float_100(*(cpp_dec_float_100*)v), m);
}



void LibZReal_BesselYZero(ZRealPtr res, const ZRealPtr v, const int m)
{
	(*(cpp_dec_float_100*)res) = cyl_neumann_zero(cpp_dec_float_100(*(cpp_dec_float_100*)v), m);
}





void LibZReal_GammaP(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = gamma_p(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_GammaQ(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = gamma_q(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_TgammaLower(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = tgamma_lower(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_TgammaUpper(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = tgamma(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}




void LibZReal_GammaPInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr p)
{
	(*(cpp_dec_float_100*)res) = gamma_p_inv(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)p));
}


void LibZReal_GammaQInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = gamma_q_inv(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}


void LibZReal_GammaPInva(ZRealPtr res, const ZRealPtr x, const ZRealPtr p)
{
	(*(cpp_dec_float_100*)res) = gamma_p_inva(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)p));
}


void LibZReal_GammaQInva(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = gamma_q_inva(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}



void LibZReal_GammaPDerivative(ZRealPtr res, const ZRealPtr a, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = gamma_p_derivative(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_Beta(ZRealPtr res, const ZRealPtr a, const ZRealPtr b)
{
	(*(cpp_dec_float_100*)res) = beta(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b));
}









void LibZReal_LegendreP(ZRealPtr res, int n, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = legendre_p(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_LegendreQ(ZRealPtr res, int n, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = legendre_q(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Laguerre(ZRealPtr res, int n, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = laguerre(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Hermite(ZRealPtr res, int n, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = hermite(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_ChebyshevT(ZRealPtr res, int n, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = chebyshev_t(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_ChebyshevU(ZRealPtr res, int n, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = chebyshev_u(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Polygamma(ZRealPtr res, int n, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = polygamma(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}





void LibZReal_EllintRC(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = ellint_rc(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)y));
}


void LibZReal_Ellint1F(ZRealPtr res, const ZRealPtr k, const ZRealPtr phi)
{
	(*(cpp_dec_float_100*)res) = ellint_1(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)phi));
}


void LibZReal_Ellint2F(ZRealPtr res, const ZRealPtr k, const ZRealPtr phi)
{
	(*(cpp_dec_float_100*)res) = ellint_2(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)phi));
}


void LibZReal_Ellint3K(ZRealPtr res, const ZRealPtr k, const ZRealPtr n)
{
	(*(cpp_dec_float_100*)res) = ellint_3(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)n));
}




void LibZReal_JacobiCD(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_cd(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiCN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_cn(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiCS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_cs(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiDC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_dc(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiDN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_dn(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiDS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_ds(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiNC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_nc(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiND(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_nd(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiNS(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_ns(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiSC(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_sc(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiSD(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_sd(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}


void LibZReal_JacobiSN(ZRealPtr res, const ZRealPtr k, const ZRealPtr u)
{
	(*(cpp_dec_float_100*)res) = jacobi_sn(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)u));
}



void LibZReal_expint(ZRealPtr res, const unsigned n, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = expint(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}




void LibZReal_OwenT(ZRealPtr res, const ZRealPtr h, const ZRealPtr a)
{
	(*(cpp_dec_float_100*)res) = owens_t(cpp_dec_float_100(*(cpp_dec_float_100*)h), cpp_dec_float_100(*(cpp_dec_float_100*)a));
}





void LibZReal_IBeta(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = ibeta(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_IBetac(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = ibetac(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_IBetaNonNormalized(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = beta(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_IBetacNonNormalized(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = betac(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}


void LibZReal_IBetaInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr p)
{
	(*(cpp_dec_float_100*)res) = ibeta_inv(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)p));
}


void LibZReal_IBetacInv(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = ibetac_inv(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}


void LibZReal_IBetaInva(ZRealPtr res, const ZRealPtr b, const ZRealPtr x, const ZRealPtr p)
{
	(*(cpp_dec_float_100*)res) = ibeta_inva(cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)p));
}


void LibZReal_IBetacInva(ZRealPtr res, const ZRealPtr b, const ZRealPtr x, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = ibetac_inva(cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}


void LibZReal_IBetaInvb(ZRealPtr res, const ZRealPtr a, const ZRealPtr x, const ZRealPtr p)
{
	(*(cpp_dec_float_100*)res) = ibeta_invb(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)p));
}


void LibZReal_IBetacInvb(ZRealPtr res, const ZRealPtr a, const ZRealPtr x, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = ibetac_invb(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}


void LibZReal_IBetaDerivative(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = ibeta_derivative(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}




void LibZReal_LegendrePM(ZRealPtr res, const int n, const int m, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = legendre_p(n, m, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_LaguerreM(ZRealPtr res, const int n, const int m, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = laguerre(n, m, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}





void LibZReal_EllipticRF(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z)
{
	(*(cpp_dec_float_100*)res) = ellint_rf(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)y), cpp_dec_float_100(*(cpp_dec_float_100*)z));
}



void LibZReal_EllipticRD(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z)
{
	(*(cpp_dec_float_100*)res) = ellint_rd(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)y), cpp_dec_float_100(*(cpp_dec_float_100*)z));
}



void LibZReal_Ellint3F(ZRealPtr res, const ZRealPtr k, const ZRealPtr n, const ZRealPtr phi)
{
	(*(cpp_dec_float_100*)res) = ellint_3(cpp_dec_float_100(*(cpp_dec_float_100*)k), cpp_dec_float_100(*(cpp_dec_float_100*)n), cpp_dec_float_100(*(cpp_dec_float_100*)phi));
}




void LibZReal_SphericalHarmonicR(ZRealPtr res, const int n, const int m, const ZRealPtr theta, const ZRealPtr phi)
{
	(*(cpp_dec_float_100*)res) = spherical_harmonic_r(n, m, cpp_dec_float_100(*(cpp_dec_float_100*)theta), cpp_dec_float_100(*(cpp_dec_float_100*)phi));
}


void LibZReal_SphericalHarmonicI(ZRealPtr res, const int n, const int m, const ZRealPtr theta, const ZRealPtr phi)
{
	(*(cpp_dec_float_100*)res) = spherical_harmonic_i(n, m, cpp_dec_float_100(*(cpp_dec_float_100*)theta), cpp_dec_float_100(*(cpp_dec_float_100*)phi));
}


void LibZReal_EllipticRJ(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z, const ZRealPtr p)
{
	(*(cpp_dec_float_100*)res) = ellint_rj(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)y), cpp_dec_float_100(*(cpp_dec_float_100*)z), cpp_dec_float_100(*(cpp_dec_float_100*)p));
}


// Hypergeometric and Theta Functions




void LibZReal_Hypergeo0F1(ZRealPtr res, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = hypergeometric_0F1(cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Hypergeo1F1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = hypergeometric_1F1(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_Hypergeo1F1r(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = hypergeometric_1F1_regularized(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}



void LibZReal_LogHypergeo1F1(ZRealPtr res, const ZRealPtr a, const ZRealPtr b, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = log_hypergeometric_1F1(cpp_dec_float_100(*(cpp_dec_float_100*)a), cpp_dec_float_100(*(cpp_dec_float_100*)b), cpp_dec_float_100(*(cpp_dec_float_100*)x));
}





void LibZReal_JacobiTheta1(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = jacobi_theta1(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}


void LibZReal_JacobiTheta2(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = jacobi_theta2(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}


void LibZReal_JacobiTheta3(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = jacobi_theta3(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}


void LibZReal_JacobiTheta4(ZRealPtr res, const ZRealPtr x, const ZRealPtr q)
{
	(*(cpp_dec_float_100*)res) = jacobi_theta4(cpp_dec_float_100(*(cpp_dec_float_100*)x), cpp_dec_float_100(*(cpp_dec_float_100*)q));
}












//*********************** Real **********************************


ZRealPtr LibZReal_Init_Func()
{
	ZRealPtr x = NULL;
	x = (cpp_dec_float_100*)malloc(sizeof(cpp_dec_float_100));
	*(cpp_dec_float_100*)x = 0;
	return x;
}


void LibZReal_Clear(ZRealPtr x)
{
	free(x);
}


void LibZReal_Get_Str(char* cstr, ZRealPtr x)
{
    cpp_dec_float_100 d = *(cpp_dec_float_100*)x;
    std::stringstream ss;
    ss.precision(std::numeric_limits<cpp_dec_float_100>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}




void LibZReal_Set_Str(ZRealPtr res, const char * str)
{

    (*(cpp_dec_float_100*)res) = static_cast<cpp_dec_float_100>(string(str));
}




void LibZReal_Set(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x);
}



void LibZReal_Neg(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = -(*(cpp_dec_float_100*)x);
}


void LibZReal_Set_S(ZRealPtr res, const float* x)
{
	(*(cpp_dec_float_100*)res) = *x;
}


void LibZReal_Set_D(ZRealPtr res, const double x)
{
	(*(cpp_dec_float_100*)res) = x;
}


void LibZReal_Set_LD(ZRealPtr res, const long double* x)
{
	(*(cpp_dec_float_100*)res) = *x;
}



void LibZReal_Set_Si(ZRealPtr res, const int32_t x)
{
	(*(cpp_dec_float_100*)res) = x;
}



void LibZReal_Set_Si64(ZRealPtr res, const int64_t x)
{
	(*(cpp_dec_float_100*)res) = x;
}



void LibZReal_Set_Ui(ZRealPtr res, const uint32_t x)
{
	(*(cpp_dec_float_100*)res) = x;
}



void LibZReal_Set_Ui64(ZRealPtr res, const uint64_t x)
{
	(*(cpp_dec_float_100*)res) = x;
}









void LibZReal_Add(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) + (*(cpp_dec_float_100*)y);
}


void LibZReal_Sub(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) - (*(cpp_dec_float_100*)y);
}



void LibZReal_Mul(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) * (*(cpp_dec_float_100*)y);
}



void LibZReal_Div(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) / (*(cpp_dec_float_100*)y);
}








void LibZReal_Add_D(ZRealPtr res, const ZRealPtr x, const double y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) + y;
}


void LibZReal_Sub_D(ZRealPtr res, const ZRealPtr x, const double y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) - y;
}


void LibZReal_D_Sub(ZRealPtr res, const ZRealPtr x, const double y)
{
	(*(cpp_dec_float_100*)res) = y - (*(cpp_dec_float_100*)x);
}


void LibZReal_Mul_D(ZRealPtr res, const ZRealPtr x, const double y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) * y;
}


void LibZReal_Div_D(ZRealPtr res, const ZRealPtr x, const double y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) / y;
}


void LibZReal_D_Div(ZRealPtr res, const ZRealPtr x, const double y)
{
	(*(cpp_dec_float_100*)res) = y / (*(cpp_dec_float_100*)x);
}









void LibZReal_Add_Si(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) + y;
}


void LibZReal_Sub_Si(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) - y;
}


void LibZReal_Si_Sub(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_100*)res) = y - (*(cpp_dec_float_100*)x);
}


void LibZReal_Mul_Si(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) * y;
}


void LibZReal_Div_Si(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) / y;
}


void LibZReal_Si_Div(ZRealPtr res, const ZRealPtr x, const int32_t y)
{
	(*(cpp_dec_float_100*)res) = y / (*(cpp_dec_float_100*)x);
}







int32_t LibZReal_LT(const ZRealPtr x, const ZRealPtr y)
{
	return (*(cpp_dec_float_100*)x) < (*(cpp_dec_float_100*)y);
}


int32_t LibZReal_GE(const ZRealPtr x, const ZRealPtr y)
{
	return (*(cpp_dec_float_100*)x) >= (*(cpp_dec_float_100*)y);
}


int32_t LibZReal_GT(const ZRealPtr x, const ZRealPtr y)
{
	return (*(cpp_dec_float_100*)x) > (*(cpp_dec_float_100*)y);
}


int32_t LibZReal_LE(const ZRealPtr x, const ZRealPtr y)
{
	return (*(cpp_dec_float_100*)x) <= (*(cpp_dec_float_100*)y);
}


int32_t LibZReal_EQ(const ZRealPtr x, const ZRealPtr y)
{
	return (*(cpp_dec_float_100*)x) == (*(cpp_dec_float_100*)y);
}


int32_t LibZReal_NE(const ZRealPtr x, const ZRealPtr y)
{
	return (*(cpp_dec_float_100*)x) != (*(cpp_dec_float_100*)y);
}











/* General functions for real numbers  */


void LibZReal_Fma(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, const ZRealPtr z)
{
	(*(cpp_dec_float_100*)res) = fma( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) , (*(cpp_dec_float_100*)z) );
}


void LibZReal_Fmax(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = fmax( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}


void LibZReal_Fmin(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = fmin( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}





/* Machine constants */


void LibZReal_Zero(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = 0.0;
}


void LibZReal_NegZero(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = -0.0;
}


void LibZReal_One(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = 1.0;
}


void LibZReal_Inf(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = std::numeric_limits<cpp_dec_float_100>::infinity();
}


void LibZReal_NegInf(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = -std::numeric_limits<cpp_dec_float_100>::infinity();
}


void LibZReal_Nan(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = std::numeric_limits<cpp_dec_float_100>::quiet_NaN();
}






/* Properties of numbers  */

int LibZReal_Signbit(const ZRealPtr x)
{
	return signbit(*(cpp_dec_float_100*)x);
}

int LibZReal_Finite(const ZRealPtr x)
{
	return isfinite(*(cpp_dec_float_100*)x);
}

int LibZReal_Isinf(const ZRealPtr x)
{
	return isinf(*(cpp_dec_float_100*)x);
}

int LibZReal_Isposinf(const ZRealPtr x)
{
	return ((isinf(*(cpp_dec_float_100*)x)) & (*(cpp_dec_float_100*)x > 0 ));
}

int LibZReal_Isneginf(const ZRealPtr x)
{
	return ((isinf(*(cpp_dec_float_100*)x)) & (*(cpp_dec_float_100*)x < 0 ));
}

int LibZReal_Isnan(const ZRealPtr x)
{
	return isnan(*(cpp_dec_float_100*)x);
}



int LibZReal_Iszero(const ZRealPtr x)
{
	return (abs(*(cpp_dec_float_100*)x) == 0.0);
}

int LibZReal_Isposzero(const ZRealPtr x)
{
	return ((int(signbit(*(cpp_dec_float_100*)x)) == 0) & (abs(*(cpp_dec_float_100*)x) == 0.0));
}

int LibZReal_Isnegzero(const ZRealPtr x)
{
	return ((int(signbit(*(cpp_dec_float_100*)x)) != 0) & (abs(*(cpp_dec_float_100*)x) == 0.0));
}

int LibZReal_Isone(const ZRealPtr x)
{
	return (*(cpp_dec_float_100*)x == 1.0);
}

int LibZReal_Isinteger(const ZRealPtr x)
{
	return (ceil(*(cpp_dec_float_100*)x) == floor(*(cpp_dec_float_100*)x));
}

int LibZReal_Isnumber(const ZRealPtr x)
{
	return (!(isnan(*(cpp_dec_float_100*)x) || (isinf(*(cpp_dec_float_100*)x))));
}

int LibZReal_Isregular(const ZRealPtr x)
{
	return (!(isnan(*(cpp_dec_float_100*)x) || (isinf(*(cpp_dec_float_100*)x) || (abs(*(cpp_dec_float_100*)x) == 0.0))));
}

int LibZReal_Isnormal(const ZRealPtr x)
{
	return (isnormal(*(cpp_dec_float_100*)x));
}

int LibZReal_Issubnormal(const ZRealPtr x)
{
	return (fpclassify(*(cpp_dec_float_100*)x)) == FP_SUBNORMAL;
}

int LibZReal_Isunordered(const ZRealPtr x, const ZRealPtr y)
{
	return (isunordered(*(cpp_dec_float_100*)x, *(cpp_dec_float_100*)x));
}







int LibZReal_FitsInt32(const ZRealPtr x)
{
	return  ((*(cpp_dec_float_100*)x <= std::numeric_limits<int32_t>::max()) &
             (*(cpp_dec_float_100*)x >= std::numeric_limits<int32_t>::min()));
}

int LibZReal_FitsInt64(const ZRealPtr x)
{
	return  ((*(cpp_dec_float_100*)x <= std::numeric_limits<int64_t>::max()) &
             (*(cpp_dec_float_100*)x >= std::numeric_limits<int64_t>::min()));
}

int LibZReal_FitsUInt32(const ZRealPtr x)
{
	return  ((*(cpp_dec_float_100*)x <= std::numeric_limits<uint32_t>::max()) &
             (*(cpp_dec_float_100*)x >= std::numeric_limits<uint32_t>::min()));
}

int LibZReal_FitsUInt64(const ZRealPtr x)
{
	return  ((*(cpp_dec_float_100*)x <= std::numeric_limits<uint64_t>::max()) &
             (*(cpp_dec_float_100*)x >= std::numeric_limits<uint64_t>::min()));
}




/* Integer Related Functions  */

void LibZReal_Nearbyint(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = nearbyint(*(cpp_dec_float_100*)x);
}

void LibZReal_Rint(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = rint(*(cpp_dec_float_100*)x);
}

long int LibZReal_Lrint(const ZRealPtr x)
{
	return lrint(*(cpp_dec_float_100*)x);
}

long long int LibZReal_Llrint(const ZRealPtr x)
{
	return llrint(*(cpp_dec_float_100*)x);
}

void LibZReal_Ceil(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = ceil(*(cpp_dec_float_100*)x);
}

void LibZReal_Floor(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = floor(*(cpp_dec_float_100*)x);
}

void LibZReal_Trunc(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = trunc(*(cpp_dec_float_100*)x);
}

void LibZReal_Round(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = round(*(cpp_dec_float_100*)x);
}

long int LibZReal_Lround(const ZRealPtr x)
{
	return lround(*(cpp_dec_float_100*)x);
}

long long int LibZReal_Llround(const ZRealPtr x)
{
	return llround(*(cpp_dec_float_100*)x);
}



int32_t LibZReal_ToInt32(const ZRealPtr x)
{
    if (*(cpp_dec_float_100*)x >= std::numeric_limits<int32_t>::max())
        return std::numeric_limits<int32_t>::max();
    else if (*(cpp_dec_float_100*)x <= std::numeric_limits<int32_t>::min())
        return std::numeric_limits<int32_t>::min();
    else
        return (int32_t) (*(__float128*)x);
}

int64_t LibZReal_ToInt64(const ZRealPtr x)
{
    if (*(cpp_dec_float_100*)x >= std::numeric_limits<int64_t>::max())
        return std::numeric_limits<int64_t>::max();
    else if (*(cpp_dec_float_100*)x <= std::numeric_limits<int64_t>::min())
        return std::numeric_limits<int64_t>::min();
    else
        return (int64_t) (*(cpp_dec_float_100*)x);
}

uint32_t LibZReal_ToUInt32(const ZRealPtr x)
{
    if (*(cpp_dec_float_100*)x >= std::numeric_limits<uint32_t>::max())
        return std::numeric_limits<uint32_t>::max();
    else if (*(cpp_dec_float_100*)x <= std::numeric_limits<uint32_t>::min())
        return std::numeric_limits<uint32_t>::min();
    else
        return (uint32_t) (*(cpp_dec_float_100*)x);
}

uint64_t LibZReal_ToUInt64(const ZRealPtr x)
{
    if (*(cpp_dec_float_100*)x >= std::numeric_limits<uint64_t>::max())
        return std::numeric_limits<uint64_t>::max();
    else if (*(cpp_dec_float_100*)x <= std::numeric_limits<uint64_t>::min())
        return std::numeric_limits<uint64_t>::min();
    else
        return (uint64_t) (*(cpp_dec_float_100*)x);
}





/* Floating point functions for real numbers */

void LibZReal_Copysign(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = copysign( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}

void LibZReal_Frexp(ZRealPtr res, const ZRealPtr x, int* e)
{
	(*(cpp_dec_float_100*)res) = frexp(*(cpp_dec_float_100*)x, e);
}

void LibZReal_Logb(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = logb(*(cpp_dec_float_100*)x);
}

int LibZReal_Ilogb(const ZRealPtr x)
{
	return ilogb(*(cpp_dec_float_100*)x);
}

void LibZReal_Ldexp(ZRealPtr res, const ZRealPtr x, const int e)
{
	(*(cpp_dec_float_100*)res) = ldexp(*(cpp_dec_float_100*)x, e);
}

void LibZReal_Scalbn(ZRealPtr res, const ZRealPtr x, const int e)
{
	(*(cpp_dec_float_100*)res) = scalbn(*(cpp_dec_float_100*)x, e);
}

void LibZReal_Scalbln(ZRealPtr res, const ZRealPtr x, const long int e)
{
	(*(cpp_dec_float_100*)res) = scalbln(*(cpp_dec_float_100*)x, e);
}

void LibZReal_Fdim(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = fdim( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}



/* Fraction and Remainder Related Functions  */

void LibZReal_Modf(ZRealPtr frac, const ZRealPtr x, ZRealPtr iptr)
{
	(*(cpp_dec_float_100*)frac) = modf( (*(cpp_dec_float_100*)x) , (cpp_dec_float_100*)iptr );
}

void LibZReal_Fmod(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = fmod( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}

void LibZReal_Remainder(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = remainder( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}

void LibZReal_Remquo(ZRealPtr res, const ZRealPtr x, const ZRealPtr y, int* e)
{
	(*(cpp_dec_float_100*)res) = remquo( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y), e );
}




/* Functions related to mantissa width and exponent range (MReal, BigDecimal) */

void LibZReal_Epsilon(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = std::numeric_limits<cpp_dec_float_100>::epsilon();
}

void LibZReal_Max(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = std::numeric_limits<cpp_dec_float_100>::max();
}

void LibZReal_Min(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = std::numeric_limits<cpp_dec_float_100>::min();
}

void LibZReal_Lowest(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = std::numeric_limits<cpp_dec_float_100>::lowest();
}

void LibZReal_Nexttowards(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = nextafter( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}

void LibZReal_Nextabove(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = nextafter( (*(cpp_dec_float_100*)x) , std::numeric_limits<cpp_dec_float_100>::infinity() );
}

void LibZReal_Nextbelow(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = nextafter( (*(cpp_dec_float_100*)x) , -std::numeric_limits<cpp_dec_float_100>::infinity() );
}





/* Complex components  */

void LibZReal_Fabs(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = fabs(*(cpp_dec_float_100*)x);
}

void LibZReal_Sign(ZRealPtr res, const ZRealPtr x)
{
    int temp = ((*(cpp_dec_float_100*)x > 0) - (*(cpp_dec_float_100*)x < 0));
	(*(cpp_dec_float_100*)res) = temp;
}





/* Mathematical Constants  */

void LibZReal_Pi(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = constants::pi<cpp_dec_float_100>();
}

void LibZReal_E(ZRealPtr res)
{
	(*(cpp_dec_float_100*)res) = constants::e<cpp_dec_float_100>();
}




























/* Roots and related functions  */


void LibZReal_Sqrt(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sqrt(*(cpp_dec_float_100*)x);
}

// Sqrt1pm1 from Boost


void LibZReal_Rsqrt(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = 1 / sqrt(*(cpp_dec_float_100*)x);
}


void LibZReal_Cbrt(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cbrt(*(cpp_dec_float_100*)x);
}


void LibZReal_Root_Si(ZRealPtr res, const ZRealPtr x, const int32_t k_)
{
    cpp_dec_float_100 k = k_;
	(*(cpp_dec_float_100*)res) = pow( (*(cpp_dec_float_100*)x) , (1.0) / k );
}




/* Exponential and related functions  */


void LibZReal_Exp(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = exp(*(cpp_dec_float_100*)x);
}


void LibZReal_Exp2(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = exp2(*(cpp_dec_float_100*)x);
}


void LibZReal_Exp10(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = exp( (*(cpp_dec_float_100*)x) * constants::ln_ten<cpp_dec_float_100>() );
}


void LibZReal_Expm1(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = expm1(*(cpp_dec_float_100*)x);
}

void LibZReal_Exp2m1(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = expm1( (*(cpp_dec_float_100*)x) * constants::ln_two<cpp_dec_float_100>() );
}

void LibZReal_Exp10m1(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = expm1( (*(cpp_dec_float_100*)x) * constants::ln_ten<cpp_dec_float_100>() );
}



/* Logarithms and related functions  */



void LibZReal_Log(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = log(*(cpp_dec_float_100*)x);
}


void LibZReal_Log2(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = log2(*(cpp_dec_float_100*)x);
}


void LibZReal_Log10(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = log10(*(cpp_dec_float_100*)x);
}


void LibZReal_Log1p(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = log1p(*(cpp_dec_float_100*)x);
}


void LibZReal_Log2p1(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = log1p(*(cpp_dec_float_100*)x) / constants::ln_two<cpp_dec_float_100>();
}


void LibZReal_Log10p1(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = log1p(*(cpp_dec_float_100*)x) / constants::ln_ten<cpp_dec_float_100>();
}





/* Power functions  */



void LibZReal_Square(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) * (*(cpp_dec_float_100*)x);
}


void LibZReal_Cube(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (*(cpp_dec_float_100*)x) * (*(cpp_dec_float_100*)x) * (*(cpp_dec_float_100*)x);
}


void LibZReal_Hypot(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = hypot( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}


void LibZReal_Pow(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = pow( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}


// Powm1 from Boost


void LibZReal_Pow1p(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = exp(log1p(*(cpp_dec_float_100*)x) * (*(cpp_dec_float_100*)y));
}


void LibZReal_Pow1pm1(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = expm1(log1p(*(cpp_dec_float_100*)x) * (*(cpp_dec_float_100*)y));
}


void LibZReal_Pow_Si(ZRealPtr res, const ZRealPtr x, const int32_t k_)
{
    cpp_dec_float_100 k = k_;
	(*(cpp_dec_float_100*)res) = pow( (*(cpp_dec_float_100*)x) , k );
}


void LibZReal_Compound_Si(ZRealPtr res, const ZRealPtr x, const int32_t k_)
{
    cpp_dec_float_100 k = k_;
	(*(cpp_dec_float_100*)res) = pow( (1.0) + (*(cpp_dec_float_100*)x) , k );
}



/* Trigonometric functions  */




cpp_dec_float_100 cosm1(cpp_dec_float_100 x)
{
    if (fabs(x) > 0.5)
    {
        return cos(x) - 1;
    }
    else
    {
        cpp_dec_float_100 res = sin((x)/2);
        return  -2 * res * res;
    }
}





void LibZReal_Sin(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sin(*(cpp_dec_float_100*)x);
}


void LibZReal_Cos(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cos(*(cpp_dec_float_100*)x);
}


void LibZReal_Tan(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = tan(*(cpp_dec_float_100*)x);
}


void LibZReal_Csc(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (1.0) / sin(*(cpp_dec_float_100*)x);
}


void LibZReal_Sec(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (1.0) / cos(*(cpp_dec_float_100*)x);
}


void LibZReal_Cot(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (1.0) / tan(*(cpp_dec_float_100*)x);
}




/* Hyperbolic functions  */


void LibZReal_Sinh(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = sinh(*(cpp_dec_float_100*)x);
}


void LibZReal_Cosh(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = cosh(*(cpp_dec_float_100*)x);
}


void LibZReal_Tanh(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = tanh(*(cpp_dec_float_100*)x);
}


void LibZReal_Csch(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (1.0) / sinh(*(cpp_dec_float_100*)x);
}


void LibZReal_Sech(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (1.0) / cosh(*(cpp_dec_float_100*)x);
}


void LibZReal_Coth(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = (1.0) / tanh(*(cpp_dec_float_100*)x);
}



/* Inverse trigonometric functions  */


void LibZReal_Asin(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = asin(*(cpp_dec_float_100*)x);
}


void LibZReal_Acos(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = acos(*(cpp_dec_float_100*)x);
}


void LibZReal_Atan(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = atan(*(cpp_dec_float_100*)x);
}


void LibZReal_Atan2(ZRealPtr res, const ZRealPtr x, const ZRealPtr y)
{
	(*(cpp_dec_float_100*)res) = atan2( (*(cpp_dec_float_100*)x) , (*(cpp_dec_float_100*)y) );
}


void LibZReal_Acsc(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = asin( (1.0) / (*(cpp_dec_float_100*)x) );
}


void LibZReal_Asec(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = acos( (1.0) / (*(cpp_dec_float_100*)x) );
}


void LibZReal_Acot(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = atan( (1.0) / (*(cpp_dec_float_100*)x) );
}




/* Inverse hyperbolic functions  */


void LibZReal_Asinh(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = asinh(*(cpp_dec_float_100*)x);
}


void LibZReal_Acosh(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = acosh(*(cpp_dec_float_100*)x);
}


void LibZReal_Atanh(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = atanh(*(cpp_dec_float_100*)x);
}


void LibZReal_Acsch(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = asinh( (1.0) / (*(cpp_dec_float_100*)x) );
}


void LibZReal_Asech(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = acosh( (1.0) / (*(cpp_dec_float_100*)x) );
}


void LibZReal_Acoth(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = atanh( (1.0) / (*(cpp_dec_float_100*)x) );
}



/* Special functions  */

void LibZReal_Erf(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = erf(*(cpp_dec_float_100*)x);
}

void LibZReal_Erfc(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = erfc(*(cpp_dec_float_100*)x);
}

void LibZReal_Tgamma(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = tgamma(*(cpp_dec_float_100*)x);
}

void LibZReal_Lgamma(ZRealPtr res, const ZRealPtr x)
{
	(*(cpp_dec_float_100*)res) = lgamma(*(cpp_dec_float_100*)x);
}

void LibZReal_J0(ZRealPtr res, const ZRealPtr x)
{
    cpp_dec_float_100 n = 0;
	(*(cpp_dec_float_100*)res) = cyl_bessel_j(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}

void LibZReal_J1(ZRealPtr res, const ZRealPtr x)
{
    cpp_dec_float_100 n = 1;
	(*(cpp_dec_float_100*)res) = cyl_bessel_j(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}

void LibZReal_Jn(ZRealPtr res, const int n_, const ZRealPtr x)
{
    cpp_dec_float_100 n = n_;
	(*(cpp_dec_float_100*)res) = cyl_bessel_j(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}

void LibZReal_Y0(ZRealPtr res, const ZRealPtr x)
{
    cpp_dec_float_100 n = 0;
	(*(cpp_dec_float_100*)res) = cyl_neumann(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}

void LibZReal_Y1(ZRealPtr res, const ZRealPtr x)
{
    cpp_dec_float_100 n = 1;
	(*(cpp_dec_float_100*)res) = cyl_neumann(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}

void LibZReal_Yn(ZRealPtr res, const int n_, const ZRealPtr x)
{
    cpp_dec_float_100 n = n_;
	(*(cpp_dec_float_100*)res) = cyl_bessel_j(n, cpp_dec_float_100(*(cpp_dec_float_100*)x));
}
























//*********************** Complex **********************************


ZCplxPtr LibZCplx_Init_Func()
{
	ZCplxPtr x = NULL;
	x = (std::complex<cpp_dec_float_100>*) malloc(sizeof(std::complex<cpp_dec_float_100>));
	return x;
}


void LibZCplx_Clear(ZCplxPtr x)
{
	free(x);
}




void LibZCplx_Get_Str_Real(char* cstr, ZCplxPtr x)
{
    cpp_dec_float_100 d = (*(std::complex<cpp_dec_float_100>*) x).real();
    std::stringstream ss;
    ss.precision(std::numeric_limits<cpp_dec_float_100>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void LibZCplx_Get_Str_Imag(char* cstr, ZCplxPtr x)
{
    cpp_dec_float_100 d = (*(std::complex<cpp_dec_float_100>*) x).imag();
    std::stringstream ss;
    ss.precision(std::numeric_limits<cpp_dec_float_100>::digits10+2);
    ss << std::showpoint; // Append any trailing zeros.
    ss << d ;
    string str = ss.str();
    std::strcpy (cstr, str.c_str());
}



void LibZCplx_Neg(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = -(*(std::complex<cpp_dec_float_100>*) x);
}






void LibZCplx_Add(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) + (*(std::complex<cpp_dec_float_100>*) y);
}


void LibZCplx_Sub(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) - (*(std::complex<cpp_dec_float_100>*) y);
}


void LibZCplx_Mul(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) * (*(std::complex<cpp_dec_float_100>*) y);
}


void LibZCplx_Div(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) / (*(std::complex<cpp_dec_float_100>*) y);
}






void LibZCplx_Add_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) + (*(cpp_dec_float_100*)y);
}



void LibZCplx_Sub_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) - (*(cpp_dec_float_100*)y);
}


void LibZCplx_ZReal_Sub(ZCplxPtr res, const ZCplxPtr y, const ZRealPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) =  (*(cpp_dec_float_100*)x) - (*(std::complex<cpp_dec_float_100>*) y);
}



void LibZCplx_Mul_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) * (*(cpp_dec_float_100*)y);
}



void LibZCplx_Div_ZReal(ZCplxPtr res, const ZCplxPtr x, const ZRealPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) / (*(cpp_dec_float_100*)y);
}


void LibZCplx_ZReal_Div(ZCplxPtr res, const ZCplxPtr y, const ZRealPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = (*(cpp_dec_float_100*)x) / (*(std::complex<cpp_dec_float_100>*) y);
}











void LibZCplx_Add_D(ZCplxPtr res, const ZCplxPtr x, const double y)
{
    cpp_dec_float_100 temp = y;
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) + temp;
}


void LibZCplx_Sub_D(ZCplxPtr res, const ZCplxPtr x, const double y)
{
    cpp_dec_float_100 temp = y;
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) - temp;
}


void LibZCplx_D_Sub(ZCplxPtr res, const ZCplxPtr y, const double x)
{
    cpp_dec_float_100 temp = x;
	(*(std::complex<cpp_dec_float_100>*) res) = temp - (*(std::complex<cpp_dec_float_100>*) y);
}


void LibZCplx_Mul_D(ZCplxPtr res, const ZCplxPtr x, const double y)
{
    cpp_dec_float_100 temp = y;
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) * temp;
}


void LibZCplx_Div_D(ZCplxPtr res, const ZCplxPtr x, const double y)
{
    cpp_dec_float_100 temp = y;
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) / temp;
}


void LibZCplx_D_Div(ZCplxPtr res, const ZCplxPtr y, const double x)
{
    cpp_dec_float_100 temp = x;
	(*(std::complex<cpp_dec_float_100>*) res) = temp / (*(std::complex<cpp_dec_float_100>*) y);
}













void LibZCplx_Add_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y)
{
    cpp_dec_float_100 temp = y;
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) + temp;
}


void LibZCplx_Sub_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y)
{
    cpp_dec_float_100 temp = y;
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) - temp;
}


void LibZCplx_Si_Sub(ZCplxPtr res, const ZCplxPtr y, const int32_t x)
{
    cpp_dec_float_100 temp = x;
	(*(std::complex<cpp_dec_float_100>*) res) = temp - (*(std::complex<cpp_dec_float_100>*) y);
}


void LibZCplx_Mul_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y)
{
    cpp_dec_float_100 temp = y;
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) * temp;
}


void LibZCplx_Div_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t y)
{
    cpp_dec_float_100 temp = y;
	(*(std::complex<cpp_dec_float_100>*) res) = (*(std::complex<cpp_dec_float_100>*) x) / temp;
}


void LibZCplx_Si_Div(ZCplxPtr res, const ZCplxPtr y, const int32_t x)
{
    cpp_dec_float_100 temp = x;
	(*(std::complex<cpp_dec_float_100>*) res) = temp / (*(std::complex<cpp_dec_float_100>*) y);
}









/* Floating point functions for real numbers  */

/* Integer and Remainder Related Functions  */

/* Machine constants and properties of numbers  */

/* Complex components  */



void LibZCplx_Set(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res)  = (*(std::complex<cpp_dec_float_100>*) x);
}

void LibZCplx_Set_Real(ZCplxPtr res, const ZRealPtr re)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::complex<cpp_dec_float_100>(*(cpp_dec_float_100*)re, 0);
}

void LibZCplx_Set2(ZCplxPtr res, const ZRealPtr re, const ZRealPtr im)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::complex<cpp_dec_float_100>(*(cpp_dec_float_100*)re, *(cpp_dec_float_100*)im);
}

void LibZCplx_Set2_Str2(ZRealPtr res, const char * str_re, const char * str_im)
{
    cpp_dec_float_100 re = static_cast<cpp_dec_float_100>(string(str_re));
    cpp_dec_float_100 im = static_cast<cpp_dec_float_100>(string(str_im));
	(*(std::complex<cpp_dec_float_100>*) res) = std::complex<cpp_dec_float_100>(re, im);
}


void LibZCplx_Abs(ZRealPtr res, const ZCplxPtr x)
{
	*(cpp_dec_float_100*)res = std::abs(*(std::complex<cpp_dec_float_100>*) x);
}

void LibZCplx_Arg(ZRealPtr res, const ZCplxPtr x)
{
	*(cpp_dec_float_100*)res = std::arg(*(std::complex<cpp_dec_float_100>*) x);
}

void LibZCplx_Imag(ZRealPtr res, const ZCplxPtr x)
{
	*(cpp_dec_float_100*)res = (*(std::complex<cpp_dec_float_100>*) x).imag();
}

void LibZCplx_Real(ZRealPtr res, const ZCplxPtr x)
{
	*(cpp_dec_float_100*)res = (*(std::complex<cpp_dec_float_100>*) x).real();
}


void LibZCplx_Conj(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::conj(*(std::complex<cpp_dec_float_100>*) x);
}

void LibZCplx_Proj(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::proj(*(std::complex<cpp_dec_float_100>*) x);
}






/* Roots  */



std::complex<cpp_dec_float_100> cplx_expm1(std::complex<cpp_dec_float_100> z)
{
    /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
	cpp_dec_float_100 x = z.real();
	cpp_dec_float_100 y = z.imag();
	cpp_dec_float_100 resx =  expm1(x) * cos(y) + cosm1(y);
	cpp_dec_float_100 resy =  exp(x) * sin(y);
	return std::complex<cpp_dec_float_100>(resx, resy);
}



std::complex<cpp_dec_float_100> cplx_log1p(std::complex<cpp_dec_float_100> z)
{
    /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
    /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
    /* resy =  atan2(y, 1 + x); */
	cpp_dec_float_100 x = z.real();
	cpp_dec_float_100 y = z.imag();
	cpp_dec_float_100 resx = 0.0 ;
	if ( (fabs(x) > 0.75) || (fabs(y) > 0.75) || (x < -0.5) )
    {
        resx = log(hypot(1 + x, y)) ;
    }
    else
    {
        resx = 0.5 * log1p(2*x + x*x + y*y);
    }
	cpp_dec_float_100 resy = atan2(y, 1 + x); ;
	return std::complex<cpp_dec_float_100>(resx, resy);
}



void LibZCplx_Sqrt(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::sqrt(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Sqrt1pm1(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 Half = 0.5;
    (*(std::complex<cpp_dec_float_100>*) res) = cplx_expm1(cplx_log1p(*(std::complex<cpp_dec_float_100>*) x) * Half);
}


void LibZCplx_Rsqrt(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) =One / std::sqrt(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Cbrt(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
    cpp_dec_float_100 Three = 3;
    cpp_dec_float_100 r = One / Three;
	(*(std::complex<cpp_dec_float_100>*) res) = std::pow(*(std::complex<cpp_dec_float_100>*) x, r);
}


void LibZCplx_Root_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k)
{
    cpp_dec_float_100 One = 1;
    cpp_dec_float_100 k_ = k;
    cpp_dec_float_100 r = One / k_;
	(*(std::complex<cpp_dec_float_100>*) res) = std::pow(*(std::complex<cpp_dec_float_100>*) x, r);
}





/* Exponential and related functions  */


void LibZCplx_Exp(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::exp(*(std::complex<cpp_dec_float_100>*) x);
}

void LibZCplx_Exp2(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::exp( (*(std::complex<cpp_dec_float_100>*) x)
                                                     * constants::ln_two<cpp_dec_float_100>() );
}

void LibZCplx_Exp10(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::exp( (*(std::complex<cpp_dec_float_100>*) x)
                                                     * constants::ln_ten<cpp_dec_float_100>() );
}



void LibZCplx_Expm1(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = cplx_expm1(*(std::complex<cpp_dec_float_100>*) x);
}

void LibZCplx_Exp2m1(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = cplx_expm1( (*(std::complex<cpp_dec_float_100>*) x)
                                                     * constants::ln_two<cpp_dec_float_100>() );
}

void LibZCplx_Exp10m1(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = cplx_expm1( (*(std::complex<cpp_dec_float_100>*) x)
                                                     * constants::ln_ten<cpp_dec_float_100>() );
}






/* Logarithms and related functions  */


void LibZCplx_Log(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::log(*(std::complex<cpp_dec_float_100>*) x);
}

void LibZCplx_Log2(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::log(*(std::complex<cpp_dec_float_100>*) x)
                                                    / constants::ln_two<cpp_dec_float_100>();
}

void LibZCplx_Log10(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::log10(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Log1p(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = cplx_log1p(*(std::complex<cpp_dec_float_100>*) x);
}

void LibZCplx_Log2p1(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = cplx_log1p(*(std::complex<cpp_dec_float_100>*) x)
                                                    / constants::ln_two<cpp_dec_float_100>();
}

void LibZCplx_Log10p1(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = cplx_log1p(*(std::complex<cpp_dec_float_100>*) x)
                                                    / constants::ln_two<cpp_dec_float_100>();
}





/* Power functions */


void LibZCplx_Square(ZCplxPtr res, const ZCplxPtr x)
{
    std::complex<cpp_dec_float_100> z = *(std::complex<cpp_dec_float_100>*) x;
	(*(std::complex<cpp_dec_float_100>*) res) =  z * z;
}


void LibZCplx_Cube(ZCplxPtr res, const ZCplxPtr x)
{
    std::complex<cpp_dec_float_100> z = *(std::complex<cpp_dec_float_100>*) x;
	(*(std::complex<cpp_dec_float_100>*) res) =  z * z * z;
}


void LibZCplx_Pow(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::pow(*(std::complex<cpp_dec_float_100>*) x,
                                                 *(std::complex<cpp_dec_float_100>*) y);
}



void LibZCplx_Powm1(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    (*(std::complex<cpp_dec_float_100>*) res) = cplx_expm1(std::log(*(std::complex<cpp_dec_float_100>*) x)
                                                           * (*(std::complex<cpp_dec_float_100>*) y));
}

void LibZCplx_Pow1p(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    (*(std::complex<cpp_dec_float_100>*) res) = std::exp(cplx_log1p(*(std::complex<cpp_dec_float_100>*) x)
                                                         * (*(std::complex<cpp_dec_float_100>*) y));
}

void LibZCplx_Pow1pm1(ZCplxPtr res, const ZCplxPtr x, const ZCplxPtr y)
{
    (*(std::complex<cpp_dec_float_100>*) res) = cplx_expm1(cplx_log1p(*(std::complex<cpp_dec_float_100>*) x)
                                                           * (*(std::complex<cpp_dec_float_100>*) y));
}




void LibZCplx_Pow_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k)
{
    cpp_dec_float_100 k_ = k;
	(*(std::complex<cpp_dec_float_100>*) res) = std::pow(*(std::complex<cpp_dec_float_100>*) x, k_);
}


void LibZCplx_Compound_Si(ZCplxPtr res, const ZCplxPtr x, const int32_t k)
{
    cpp_dec_float_100 One = 1;
    cpp_dec_float_100 k_ = k;
	(*(std::complex<cpp_dec_float_100>*) res) = std::pow(One + (*(std::complex<cpp_dec_float_100>*) x), k_);
}






/* Trigonometric functions  */


void LibZCplx_Sin(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::sin(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Cos(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::cos(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Tan(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::tan(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Csc(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = One / std::sin(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Sec(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = One /  std::cos(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Cot(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = One /  std::tan(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_SinPi(ZCplxPtr res, const ZCplxPtr x)
{
	//(*(std::complex<cpp_dec_float_100>*) res) = std::sin(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_CosPi(ZCplxPtr res, const ZCplxPtr x)
{
	//(*(std::complex<cpp_dec_float_100>*) res) = std::cos(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_TanPi(ZCplxPtr res, const ZCplxPtr x)
{
	//(*(std::complex<cpp_dec_float_100>*) res) = std::tan(*(std::complex<cpp_dec_float_100>*) x);
}





/* Hyperbolic functions  */


void LibZCplx_Sinh(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::sinh(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Cosh(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::cosh(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Tanh(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::tanh(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Csch(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = One / std::sinh(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Sech(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = One /  std::cosh(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Coth(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = One /  std::tanh(*(std::complex<cpp_dec_float_100>*) x);
}





/* Inverse trigonometric functions  */


void LibZCplx_Asin(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::asin(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Acos(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::acos(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Atan(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::atan(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Acsc(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = std::asin(One / (*(std::complex<cpp_dec_float_100>*) x));
}


void LibZCplx_Asec(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = std::acos(One / (*(std::complex<cpp_dec_float_100>*) x));
}


void LibZCplx_Acot(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = std::atan(One / (*(std::complex<cpp_dec_float_100>*) x));
}






/* Inverse hyperbolic functions  */


void LibZCplx_Asinh(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::asinh(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Acosh(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::acosh(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Atanh(ZCplxPtr res, const ZCplxPtr x)
{
	(*(std::complex<cpp_dec_float_100>*) res) = std::atanh(*(std::complex<cpp_dec_float_100>*) x);
}


void LibZCplx_Acsch(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = std::asinh(One / (*(std::complex<cpp_dec_float_100>*) x));
}


void LibZCplx_Asech(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = std::acosh(One / (*(std::complex<cpp_dec_float_100>*) x));
}


void LibZCplx_Acoth(ZCplxPtr res, const ZCplxPtr x)
{
    cpp_dec_float_100 One = 1;
	(*(std::complex<cpp_dec_float_100>*) res) = std::atanh(One / (*(std::complex<cpp_dec_float_100>*) x));
}







