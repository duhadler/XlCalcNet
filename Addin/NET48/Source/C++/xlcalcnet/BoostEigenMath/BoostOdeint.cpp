
#include <iostream>
#include <boost/numeric/odeint.hpp>
#include "boost/numeric/odeint/external/eigen/eigen.hpp"
#ifdef Use_Float128
#include <boost/multiprecision/float128.hpp>
#endif
#ifdef Use_Dec50
#include <boost/multiprecision/cpp_dec_float.hpp>
#endif
#include "libBoostEigen.h"

using namespace boost::numeric::odeint;


typedef mpVector state_type_vec;


#ifdef Use_Double
struct Boost_Odeint_Write
{
	Boost_Odeint_Write(AnyFuncPtr f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, const mpType t)
	{
	    double fx = t;
		func1(&x, &fx);
	}
	AnyFuncPtr func1;
};

struct Boost_Odeint_Func_Vec
{
	Boost_Odeint_Func_Vec(AnyFuncPtr3 f1)
	{
		func1 = f1;
	}
	void operator()(const state_type_vec &x, state_type_vec &dxdt, mpType t) const
	{
	    double fx = t;
		func1(&x, &dxdt, &fx);
	}
	AnyFuncPtr3 func1;
};
#endif


#ifdef Use_LongDouble
struct Boost_Odeint_Write
{
	Boost_Odeint_Write(AnyFuncPtr f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, const mpType t)
	{
	    long double fx = t;
		func1(&x, &fx);
	}
	AnyFuncPtr func1;
};

struct Boost_Odeint_Func_Vec
{
	Boost_Odeint_Func_Vec(AnyFuncPtr3 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, state_type_vec &dxdt, mpType t) const
	{
	    long double fx = t;
		func1(&x, &dxdt, &fx);
	}
	AnyFuncPtr3 func1;
};
#endif


#ifdef Use_Float128
struct Boost_Odeint_Write
{
	Boost_Odeint_Write(AnyFuncPtr f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, const mpType t)
	{
	    boost::multiprecision::float128 fx = t;
		func1(&x, &(fx.backend().value()));
	}
	AnyFuncPtr func1;
};


struct Boost_Odeint_Func_Vec
{
	Boost_Odeint_Func_Vec(AnyFuncPtr3 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, state_type_vec &dxdt, mpType t) const
	{
	    boost::multiprecision::float128 fx = t;
		func1(&x, &dxdt, &(fx.backend().value()));
	}
	AnyFuncPtr3 func1;
};
#endif

#ifdef Use_Dec50
struct Boost_Odeint_Write
{
	Boost_Odeint_Write(AnyFuncPtr f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, const mpType t)
	{
	    boost::multiprecision::cpp_dec_float_50 fx = t;
		func1(&x, &fx);
	}
	AnyFuncPtr func1;
};


struct Boost_Odeint_Func_Vec
{
	Boost_Odeint_Func_Vec(AnyFuncPtr3 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, state_type_vec &dxdt, mpType t) const
	{
	    boost::multiprecision::cpp_dec_float_50 fx = t;
		func1(&x, &dxdt, &fx);
	}
	AnyFuncPtr3 func1;
};
#endif

#ifdef Use_Mpfr
struct Boost_Odeint_Write
{
	Boost_Odeint_Write(AnyFuncPtr f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, const mpType t)
	{
	    boost::multiprecision::mpfr_float fx = t;
		func1(&x, &(fx.backend().data()));
	}
	AnyFuncPtr func1;
};


struct Boost_Odeint_Func_Vec
{
	Boost_Odeint_Func_Vec(AnyFuncPtr3 f1)
	{
		func1 = f1;
	}

	void operator()(const state_type_vec &x, state_type_vec &dxdt, mpType t) const
	{
	    boost::multiprecision::mpfr_float fx = t;
		func1(&x, &dxdt, &(fx.backend().data()));
	}
	AnyFuncPtr3 func1;
};
#endif



/* Constant steppers */



void Odeint_Const_RungeKutta4(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt)
{
	integrate_const(runge_kutta4<state_type_vec, mpType>(), Boost_Odeint_Func_Vec(f1),
		*x, start_time, end_time, dt, Boost_Odeint_Write(f2));

}


void Odeint_Const_RungeKuttaCashKarp54(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt)
{
	integrate_const(runge_kutta_cash_karp54<state_type_vec, mpType>(), Boost_Odeint_Func_Vec(f1),
		*x, start_time, end_time, dt, Boost_Odeint_Write(f2));
}




void Odeint_Const_RungeKuttaDopri5(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt)
{
	integrate_const(runge_kutta_dopri5<state_type_vec, mpType>(), Boost_Odeint_Func_Vec(f1),
		*x, start_time, end_time, dt, Boost_Odeint_Write(f2));
}




void Odeint_Const_RungeKuttaFehlberg78(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt)
{
	integrate_const(runge_kutta_fehlberg78<state_type_vec, mpType>(), Boost_Odeint_Func_Vec(f1),
		*x, start_time, end_time, dt, Boost_Odeint_Write(f2));
}






void Odeint_Const_AdamsBashforthMoulton(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt)
{
	integrate_const(adams_bashforth_moulton<5, state_type_vec, mpType>(), Boost_Odeint_Func_Vec(f1),
		*x, start_time, end_time, dt, Boost_Odeint_Write(f2));
}




/* Adaptive steppers */


void Odeint_Adaptive_RungeKuttaDopri5(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt, mpType eps_abs, mpType eps_rel)
{
    // use dopri5 with stepsize control and allowed errors 10^-12, integrate t=1...10
//    integrate_adaptive( make_controlled( 1E-12 , 1E-12 , runge_kutta_dopri5< double >() ) , rhs , xx , 1.0 , 10.0 , 0.1 , write_cout );

    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_dopri5<state_type_vec, mpType>() ) , Boost_Odeint_Func_Vec(f1) , *x , start_time , end_time , dt , Boost_Odeint_Write(f2));
}


void Odeint_Adaptive_RungeKuttaCashKarp54(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt, mpType eps_abs, mpType eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_cash_karp54<state_type_vec, mpType>() ) , Boost_Odeint_Func_Vec(f1) , *x , start_time , end_time , dt,  Boost_Odeint_Write(f2));
}


void Odeint_Adaptive_RungeKuttaFehlberg78(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt, mpType eps_abs, mpType eps_rel)
{
    integrate_adaptive( make_controlled( eps_abs , eps_rel , runge_kutta_fehlberg78<state_type_vec, mpType>() ) , Boost_Odeint_Func_Vec(f1) , *x , start_time , end_time , dt , Boost_Odeint_Write(f2));
}




void Odeint_Adaptive_BulirschStoer(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt, mpType eps_abs, mpType eps_rel)
{
	bulirsch_stoer< state_type_vec, mpType > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_Odeint_Func_Vec(f1), *x, start_time, end_time, dt, Boost_Odeint_Write(f2));
}

/* Dense Output steppers */


void Odeint_DenseOutput_Dopri5(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt, mpType eps_abs, mpType eps_rel)
{
    typedef runge_kutta_dopri5< state_type_vec, mpType > dopri5_type;
    typedef controlled_runge_kutta< dopri5_type > controlled_dopri5_type;
    typedef dense_output_runge_kutta< controlled_dopri5_type > dense_output_dopri5_type;
    dense_output_dopri5_type dopri5 = make_dense_output( eps_abs , eps_rel , dopri5_type() );
    integrate_adaptive( dopri5, Boost_Odeint_Func_Vec(f1), *x, start_time, end_time, dt, Boost_Odeint_Write(f2));
}



void Odeint_DenseOutput_BulirschStoer(AnyFuncPtr3 f1, AnyFuncPtr f2, mpVectorPtr x, mpType start_time, mpType end_time, mpType dt, mpType eps_abs, mpType eps_rel)
{
	bulirsch_stoer_dense_out< state_type_vec, mpType > stepper( eps_abs , eps_rel , 0.0 , 0.0 );
    integrate_adaptive( stepper, Boost_Odeint_Func_Vec(f1), *x, start_time, end_time, dt, Boost_Odeint_Write(f2));
}


