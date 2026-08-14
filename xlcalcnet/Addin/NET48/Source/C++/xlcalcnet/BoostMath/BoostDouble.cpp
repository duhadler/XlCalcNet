


// See also: https://www.boost.org/doc/libs/1_82_0/boost/math/tools/user.hpp

#include <boost/math/tools/user.hpp>


#include "BoostDouble.h"


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


struct DoubleFunctor1
{
  DoubleFunctor1(DoubleFuncPtr f1):func1(f1) {}
  double operator()(double x)
  {
    double fx;
	fx = func1(x);
    return fx;
  }
private:
	DoubleFuncPtr func1;
};



struct DoubleFunctor2
{
	DoubleFunctor2(DoubleFuncPtr f1, DoubleFuncPtr f2) :func1(f1), func2(f2) {}
	std::pair<double, double> operator()(double x)
	{
		double fx, dx;
		fx = func1(x);
		dx = func2(x);
		return std::make_pair(fx, dx);
	}
private:
	DoubleFuncPtr func1, func2;
};



struct DoubleFunctor3
{
	DoubleFunctor3(DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3) :func1(f1), func2(f2), func3(f3) {}
	std::tuple<double, double, double> operator()(double x)
	{
		double fx, dx, d2x;
		fx = func1(x);
		dx = func2(x);
		d2x = func3(x);
		return std::make_tuple(fx, dx, d2x);
	}
private:
	DoubleFuncPtr func1, func2, func3;
};



void LibDouble_BracketRoot(double* res1, double* res2, int* iter, DoubleFuncPtr f1, double guess, double factor, bool is_rising, int get_digits, unsigned int maxit)
{
	boost::uintmax_t it = maxit;
	eps_tolerance<double> tol(get_digits);
	std::pair<double, double> r = bracket_and_solve_root(DoubleFunctor1(f1), guess, factor, is_rising, tol, it);
	double error = (r.second - r.first) / 2;
	double result = r.first + error;
    (*res1) =  result;
    (*res2) =  error;
    *iter = (int) it;
}



void LibDouble_NewtonRaphson(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
{
  boost::uintmax_t it = maxit;
  (*res) = newton_raphson_iterate(DoubleFunctor2(f1, f2), guess, xmin, xmax, get_digits, it);
  *iter = (int) it;
}



void LibDouble_Halley(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
{
  boost::uintmax_t it = maxit;
  (*res) = halley_iterate(DoubleFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
  *iter = (int) it;
}



void LibDouble_Schroder(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit)
{
  boost::uintmax_t it = maxit;
  (*res) = schroder_iterate(DoubleFunctor3(f1, f2, f3), guess, xmin, xmax, get_digits, it);
  *iter = (int) it;
}


void LibDouble_Brent_Minimum(double* res, double* resFx, int* iter, DoubleFuncPtr f1, double bracket_min, double bracket_max, int bits, unsigned int maxit)
{
    boost::uintmax_t it = maxit;
    std::pair<double, double> r = brent_find_minima(DoubleFunctor1(f1), bracket_min, bracket_max, bits, it);
    (*res) =  r.first;
    (*resFx) =  r.second;
    *iter = (int) it;
}




void LibDouble_Trapezoidal(double* res1, double* res2, double* res3, DoubleFuncPtr f1, double a, double b)
{
    auto f = [&f1](double x) { return f1(x); };
    size_t max_refinements = 24;
    double tol = sqrt(std::numeric_limits<double>::epsilon());
    double  error;
    double  L1;
    double result = trapezoidal(f, a, b, tol, max_refinements, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}




// 7, 15, 20, 25 and 30

void LibDouble_GaussLegendre(double* res1, double* res3, DoubleFuncPtr f1, double a, double b)
{
    auto f = [&f1](const double& t) { return f1(t); };
    double  L1 = 0.0;
    double result = gauss<double, 7>::integrate(f, a, b, &L1);
    (*res1) =  result;
    (*res3) =  L1/std::abs(result);
}




//15, 31, 41, 51 and 61

void LibDouble_GaussKronrod(double* res1, double* res2, double* res3, DoubleFuncPtr f1, double a, double b)
{
    auto f = [&f1](double t) { return f1(t); };
    unsigned max_depth = 15;
    double tol = sqrt(std::numeric_limits<double>::epsilon());
    double  error;
    double  L1 = 0.0;;
    double result = gauss_kronrod<double, 15>::integrate(f, a, b, max_depth, tol, &error, &L1);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
}



void LibDouble_TanhSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1, double a, double b)
{
    tanh_sinh<double> integrator;
    auto f = [&f1](double x) { return f1(x); };
    double termination = sqrt(std::numeric_limits<double>::epsilon());
    double  error;
    double  L1;
    std::size_t levels = 0;
    double result = integrator.integrate(f, a, b, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibDouble_SinhSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1)
{
    sinh_sinh<double> integrator;
    auto f = [&f1](double x) { return f1(x); };
    double termination = sqrt(std::numeric_limits<double>::epsilon());
    double  error = 0.0;
    double  L1 = 0.0;
    std::size_t levels = 0;
    double result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibDouble_ExpSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1)
{
    exp_sinh<double> integrator;
    auto f = [&f1](double x) { return f1(x); };
    double termination = sqrt(std::numeric_limits<double>::epsilon());
    double  error = 0.0;
    double  L1 = 0.0;
    std::size_t levels = 0;
    double result = integrator.integrate(f, termination, &error, &L1, &levels);
    (*res1) =  result;
    (*res2) =  error;
    (*res3) =  L1/std::abs(result);
    *levels_ = (int) levels;
}



void LibDouble_Ooura_Cos(double* res1, double* res2, DoubleFuncPtr f1)
{
    double omega = 1;
	const double tol = 2 * std::numeric_limits<double>::epsilon();
	auto integrator = ooura_fourier_cos<double>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](double x) { return f1(x); };
	std::pair<double, double> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



void LibDouble_Ooura_Sin(double* res1, double* res2, DoubleFuncPtr f1)
{
    double omega = 1;
	const double tol = 2 * std::numeric_limits<double>::epsilon();
	auto integrator = ooura_fourier_sin<double>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](double x) { return f1(x); };
	std::pair<double, double> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



void LibDouble_Ooura_Cos2(double* res1, double* res2, DoubleFuncPtr f1, double omega)
{
    //double omega = 1;
	const double tol = 2 * std::numeric_limits<double>::epsilon();
	auto integrator = ooura_fourier_cos<double>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](double x) { return f1(x); };
	std::pair<double, double> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}



void LibDouble_Ooura_Sin2(double* res1, double* res2, DoubleFuncPtr f1, double omega)
{
    //double omega = 1;
	const double tol = 2 * std::numeric_limits<double>::epsilon();
	auto integrator = ooura_fourier_sin<double>(tol, 8); // Loops or gets worse for more than 8.
    auto f = [&f1](double x) { return f1(x); };
	std::pair<double, double> r = integrator.integrate(f, omega);
    (*res1) =  r.first;
    (*res2) =  r.second;
}




//
//
//void TestCplxTGamma()
//{
//    std::complex<double> z(1.0, 2.0);
//    std::complex<double> result = boost::math::tgamma(z); // Nutzt intern Lanczos
//}
