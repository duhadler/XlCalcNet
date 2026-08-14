#include <complex>
#include <iostream>
#include "w_elliptic.hpp"

#include "XSF.h"


#include <cmath>

#include "log_exp.h"

#include "bessel.h"
#include "airy.h"
#include "specfun.h"
#include "sici.h"
#include "fresnel.h"
#include "hyp2f1.h"

#include "Faddeeva/Faddeeva.hh"
#include "Carlson/ellint_carlson_cpp_lite/ellint_carlson.hh"

#include "polylog/Li.hpp"


static constexpr double ellip_rerr = 5e-16;


double add_double(double x, double y)
{
    return x + y;
}



double xsf_exprel(double x)
{
    return xsf::exprel(x);
}

// https://github.com/Expander/polylogarithm/tree/master

void xsf_cplx_polylog(int n, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = std::complex<double>(0, 0);

    res = polylogarithm::Li(n,z);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_weierstrass()
{
    w_elliptic::we<double> w(1,2);
    std::cout << w.P(1.2) << '\n';
    std::cout << w.P(std::complex<double>(1.2,3.4)) << '\n';
    std::cout << w.Pprime(1.2) << '\n';
    std::cout << w.Pprime(std::complex<double>(1.2,3.4)) << '\n';
    std::cout << w.zeta(0.12) << '\n';
    std::cout << w.zeta(std::complex<double>(1.2,3.4)) << '\n';
    std::cout << w.sigma(0.12) << '\n';
    std::cout << w.sigma(std::complex<double>(1.2,3.4)) << '\n';
    auto Pinv = w.Pinv(-4.);
    std::cout << Pinv[0] << '\n';
    std::cout << Pinv[1] << '\n';
    std::cout << w << '\n';
}




void xsf_weierstrass_p(double g2, double g3, double x, double* res)
{
    w_elliptic::we<double> w(g2,g3);
    *res = w.P(x);
}


void xsf_weierstrass_prime(double g2, double g3, double x, double* res)
{
    w_elliptic::we<double> w(g2,g3);
    *res = w.Pprime(x);
}


void xsf_weierstrass_zeta(double g2, double g3, double x, double* res)
{
    w_elliptic::we<double> w(g2,g3);
    *res = w.zeta(x);
}


void xsf_weierstrass_sigma(double g2, double g3, double x, double* res)
{
    w_elliptic::we<double> w(g2,g3);
    *res = w.sigma(x);
}


void xsf_cplx_weierstrass_p(double g2, double g3, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = std::complex<double>(0, 0);

    w_elliptic::we<double> w(g2,g3);
    res = w.P(z);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}

void xsf_cplx_weierstrass_pprime(double g2, double g3, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = std::complex<double>(0, 0);

    w_elliptic::we<double> w(g2,g3);
    res = w.Pprime(z);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}

void xsf_cplx_weierstrass_zeta(double g2, double g3, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = std::complex<double>(0, 0);

    w_elliptic::we<double> w(g2,g3);
    res = w.zeta(z);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}

void xsf_cplx_weierstrass_sigma(double g2, double g3, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = std::complex<double>(0, 0);

    w_elliptic::we<double> w(g2,g3);
    res = w.sigma(z);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}







void xsf_cplx_ellint_rc(double x_re, double x_im, double y_re, double y_im, double* res_re, double* res_im)
{
    std::complex<double> xx = std::complex<double>(x_re, x_im);
    std::complex<double> yy = std::complex<double>(y_re, y_im);
    std::complex<double> res = std::complex<double>(0, 0);

    ellint_carlson::rc(xx, yy, ellip_rerr, res);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_cplx_ellint_rd(double x_re, double x_im, double y_re, double y_im, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> xx = std::complex<double>(x_re, x_im);
    std::complex<double> yy = std::complex<double>(y_re, y_im);
    std::complex<double> zz = std::complex<double>(z_re, z_im);
    std::complex<double> res = std::complex<double>(0, 0);

    ellint_carlson::rd(xx, yy, zz, ellip_rerr, res);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_ellint_rf(double x_re, double x_im, double y_re, double y_im, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> xx = std::complex<double>(x_re, x_im);
    std::complex<double> yy = std::complex<double>(y_re, y_im);
    std::complex<double> zz = std::complex<double>(z_re, z_im);
    std::complex<double> res = std::complex<double>(0, 0);

    ellint_carlson::rf(xx, yy, zz, ellip_rerr, res);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_ellint_rg(double x_re, double x_im, double y_re, double y_im, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> xx = std::complex<double>(x_re, x_im);
    std::complex<double> yy = std::complex<double>(y_re, y_im);
    std::complex<double> zz = std::complex<double>(z_re, z_im);
    std::complex<double> res = std::complex<double>(0, 0);

    ellint_carlson::rg(xx, yy, zz, ellip_rerr, res);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_ellint_rj(double x_re, double x_im, double y_re, double y_im, double z_re, double z_im, double p_re, double p_im, double* res_re, double* res_im)
{
    std::complex<double> xx = std::complex<double>(x_re, x_im);
    std::complex<double> yy = std::complex<double>(y_re, y_im);
    std::complex<double> zz = std::complex<double>(z_re, z_im);
    std::complex<double> pp = std::complex<double>(p_re, p_im);
    std::complex<double> res = std::complex<double>(0, 0);

    ellint_carlson::rj(xx, yy, zz, pp, ellip_rerr, res);

    *res_re = std::real(res);
    *res_im = std::imag(res);
}


/* ************************* */


void xsf_cplx_w(double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = Faddeeva::w(z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_erfcx(double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = Faddeeva::erfcx(z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_erf(double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = Faddeeva::erf(z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_erfi(double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = Faddeeva::erfi(z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_erfc(double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = Faddeeva::erfc(z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_dawson(double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = Faddeeva::Dawson(z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}








/* ************************* */



void xsf_cplx_bessel_je(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_bessel_je(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_bessel_ye(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_bessel_ye(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_bessel_ie(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_bessel_ie(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_bessel_ke(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_bessel_ke(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_hankel_1e(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_hankel_1e(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


void xsf_cplx_hankel_2e(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_hankel_2e(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}





/* ************************* */



void xsf_cplx_bessel_j(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_bessel_j(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_cplx_bessel_y(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_bessel_y(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_cplx_bessel_i(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_bessel_i(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_cplx_bessel_k(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_bessel_k(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_cplx_hankel_1(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_hankel_1(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_cplx_hankel_2(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cyl_hankel_2(v, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}





/* ************************* */



// kode=1: plain; kode=2: exponential scaling;
void xsf_cplx_airyai(int kode, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res;
    xsf::airyai(kode, z, res);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


// kode=1: plain; kode=2: exponential scaling;
void xsf_cplx_airybi(int kode, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res;
    xsf::airybi(kode, z, res);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


// kode=1: plain; kode=2: exponential scaling;
void xsf_cplx_airyaip(int kode, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res;
    xsf::airyaip(kode, z, res);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}


// kode=1: plain; kode=2: exponential scaling;
void xsf_cplx_airybip(int kode, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res;
    xsf::airybip(kode, z, res);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}




/* ************************* */






void xsf_sf_cplx_chyp2f1(double a, double b, double c, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::chyp2f1(a, b, c, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_sf_cplx_chyp1f1(double a, double b, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::chyp1f1(a, b, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_sf_cplx_cerf(double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::cerf(z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}



void xsf_cplx_sici(double z_re, double z_im, double* si_re, double* si_im, double* ci_re, double* ci_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> si = std::complex<double>(0, 0);
    std::complex<double> ci = std::complex<double>(0, 0);
    xsf::sici(z, &si, &ci);
    *si_re = std::real(si);
    *si_im = std::imag(si);
    *ci_re = std::real(ci);
    *ci_im = std::imag(ci);
}


void xsf_cplx_fresnel(double z_re, double z_im, double* fs_re, double* fs_im, double* fc_re, double* fc_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> fs = std::complex<double>(0, 0);
    std::complex<double> fc = std::complex<double>(0, 0);
    xsf::fresnel(z, fs, fc);
    *fs_re = std::real(fs);
    *fs_im = std::imag(fs);
    *fc_re = std::real(fc);
    *fc_im = std::imag(fc);
}






void xsf_cplx_hyp2f1(double a, double b, double c, double z_re, double z_im, double* res_re, double* res_im)
{
    std::complex<double> z = std::complex<double>(z_re, z_im);
    std::complex<double> res = xsf::hyp2f1(a, b, c, z);
    *res_re = std::real(res);
    *res_im = std::imag(res);
}




