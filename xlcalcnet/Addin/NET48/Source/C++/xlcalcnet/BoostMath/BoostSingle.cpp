


// See also: https://www.boost.org/doc/libs/1_82_0/boost/math/tools/user.hpp

#include <boost/math/tools/user.hpp>


#include "BoostSingle.h"


#include "stdint.h"
#include <complex>
#include <vector>
#include <iostream>
#include <limits>
#include "float.h"


#include <boost/math/tools/minima.hpp>
#include <boost/math/tools/roots.hpp>
#include <tuple> // for std::tuple and std::make_tuple.


#include <boost/math/quadrature/trapezoidal.hpp>
#include <boost/math/quadrature/gauss.hpp>
#include <boost/math/quadrature/gauss_kronrod.hpp>
#include <boost/math/quadrature/tanh_sinh.hpp>
#include <boost/math/quadrature/exp_sinh.hpp>
#include <boost/math/quadrature/sinh_sinh.hpp>
#include <boost/math/quadrature/ooura_fourier_integrals.hpp>

//#include <Eigen/Dense>



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






//*********************** Numerical Calculus **********************************


struct SingleFunctor1
{
  SingleFunctor1(SingleFuncPtr f1):func1(f1) {}
  float operator()(float x)
  {
    float fx;
	fx = func1(x);
    return fx;
  }
private:
	SingleFuncPtr func1;
};



struct SingleFunctor2
{
	SingleFunctor2(SingleFuncPtr f1, SingleFuncPtr f2) :func1(f1), func2(f2) {}
	std::pair<float, float> operator()(float x)
	{
		float fx, dx;
		fx = func1(x);
		dx = func2(x);
		return std::make_pair(fx, dx);
	}
private:
	SingleFuncPtr func1, func2;
};



struct SingleFunctor3
{
	SingleFunctor3(SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3) :func1(f1), func2(f2), func3(f3) {}
	std::tuple<float, float, float> operator()(float x)
	{
		float fx, dx, d2x;
		fx = func1(x);
		dx = func2(x);
		d2x = func3(x);
		return std::make_tuple(fx, dx, d2x);
	}
private:
	SingleFuncPtr func1, func2, func3;
};



void LibSingle_BracketRoot(float* res1, float* res2, int* iter, SingleFuncPtr f1, float guess, float factor, bool is_rising, int get_digits, unsigned int maxit)
{
	boost::uintmax_t it = maxit;
	eps_tolerance<float> tol(get_digits);
	std::pair<float, float> r = bracket_and_solve_root(SingleFunctor1(f1), guess, factor, is_rising, tol, it);
	float error = (r.second - r.first) / 2;
	float result = r.first + error;
    (*res1) =  result;
    (*res2) =  error;
    *iter = (int) it;
}



void LibSingle_NewtonRaphson(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, float guess, float xmin, float xmax, int get_digits, unsigned int maxit)
{
  boost::uintmax_t it = maxit;
  (*res) = newton_raphson_iterate(SingleFunctor2(f1, f2), guess, xmin, xmax, get_digits, it);
  *iter = (int) it;
}



void LibSingle_Halley(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3, float guess, float xmin, float xmax, int get_digits, unsigned int maxit)
{
  boost::uintmax_t it = maxit;
  (*res) = halley_iterate(SingleFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
  *iter = (int) it;
}



void LibSingle_Schroder(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3, float guess, float xmin, float xmax, int get_digits, unsigned int maxit)
{
  boost::uintmax_t it = maxit;
  (*res) = schroder_iterate(SingleFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
  *iter = (int) it;
}


void LibSingle_Brent_Minimum(float* res, float* resFx, int* iter, SingleFuncPtr f1, float bracket_min, float bracket_max, int bits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    std::pair<float, float> r = brent_find_minima(SingleFunctor1(f1), bracket_min, bracket_max, bits, it);
    (*res) =  r.first;
    (*resFx) =  r.second;
    *iter = (int) it;
}




void LibSingle_Trapezoidal(float* res1, float* res2, float* res3, SingleFuncPtr f1, float a, float b)
{
    auto f = [&f1](float x) { return f1(x); };
    size_t max_refinements = 24;
    float tol = sqrt(std::numeric_limits<float>::epsilon());
    float  error;
    float  L1;
    float result = trapezoidal(f, a, b, tol, max_refinements, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}




// 7, 15, 20, 25 and 30

void LibSingle_GaussLegendre(float* res1, float* res3, SingleFuncPtr f1, float a, float b)
{
    auto f = [&f1](const float& t) { return f1(t); };
    float  L1 = 0.0;
    float result = gauss<float, 7>::integrate(f, a, b, &L1);
    (*res1) =  result;
    (*res3) =  L1/std::abs(result);
}




//15, 31, 41, 51 and 61

void LibSingle_GaussKronrod(float* res1, float* res2, float* res3, SingleFuncPtr f1, float a, float b)
{
    auto f = [&f1](float t) { return f1(t); };
    unsigned max_depth = 15;
    float tol = sqrt(std::numeric_limits<float>::epsilon());
    float  error;
    float  L1 = 0.0;;
    float result = gauss_kronrod<float, 15>::integrate(f, a, b, max_depth, tol, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}



void LibSingle_TanhSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1, float* a, float* b)
{
    tanh_sinh<float> integrator;
    auto f = [&f1](float x) { return f1(x); };
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



void LibSingle_SinhSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1)
{
    sinh_sinh<float> integrator;
    auto f = [&f1](float x) { return f1(x); };
    float termination = sqrt(std::numeric_limits<float>::epsilon());
    float  error = 0.0;
    float  L1 = 0.0;
    std::size_t levels = 0;
    float result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibSingle_ExpSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1)
{
    exp_sinh<float> integrator;
    auto f = [&f1](float x) { return f1(x); };
    float termination = sqrt(std::numeric_limits<float>::epsilon());
    float  error = 0.0;
    float  L1 = 0.0;
    std::size_t levels = 0;
    float result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibSingle_Ooura_Cos(float* res1, float* res2, SingleFuncPtr f1)
{
    float omega = 1;
	const float tol = 2 * std::numeric_limits<float>::epsilon();
	auto integrator = ooura_fourier_cos<float>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](float x) { return f1(x); };
	std::pair<float, float> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



void LibSingle_Ooura_Sin(float* res1, float* res2, SingleFuncPtr f1)
{
    float omega = 1;
	const float tol = 2 * std::numeric_limits<float>::epsilon();
	auto integrator = ooura_fourier_sin<float>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](float x) { return f1(x); };
	std::pair<float, float> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}


