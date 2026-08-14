//#include "BoostDouble.h"
#include "XSF.h"
#include "mpNumC_Main.h"




//*********************** Complex **********************************




void Lib_xsf_cplx_polylog(int n, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_polylog(n, z_re, z_im, res_re, res_im);
}



void Lib_xsf_weierstrass_p(double g2, double g3, double x, double* res)
{
    xsf_weierstrass_p(g2, g3, x, res);
}

void Lib_xsf_weierstrass_pprime(double g2, double g3, double x, double* res)
{
    xsf_weierstrass_p(g2, g3, x, res);
}

void Lib_xsf_weierstrass_zeta(double g2, double g3, double x, double* res)
{
    xsf_weierstrass_zeta(g2, g3, x, res);
}

void Lib_xsf_weierstrass_sigma(double g2, double g3, double x, double* res)
{
    xsf_weierstrass_sigma(g2, g3, x, res);
}



void Lib_xsf_cplx_weierstrass_p(double g2, double g3, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_weierstrass_p(g2, g3, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_weierstrass_pprime(double g2, double g3, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_weierstrass_pprime(g2, g3, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_weierstrass_zeta(double g2, double g3, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_weierstrass_zeta(g2, g3, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_weierstrass_sigma(double g2, double g3, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_weierstrass_sigma(g2, g3, z_re, z_im, res_re, res_im);
}




void Lib_xsf_cplx_ellint_rc(double x_re, double x_im, double y_re, double y_im, double* res_re, double* res_im)
{
    xsf_cplx_ellint_rc(x_re, x_im, y_re, y_im, res_re, res_im);
}

void Lib_xsf_cplx_ellint_rd(double x_re, double x_im, double y_re, double y_im, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_ellint_rd(x_re, x_im, y_re, y_im, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_ellint_rf(double x_re, double x_im, double y_re, double y_im, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_ellint_rf(x_re, x_im, y_re, y_im, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_ellint_rg(double x_re, double x_im, double y_re, double y_im, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_ellint_rg(x_re, x_im, y_re, y_im, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_ellint_rj(double x_re, double x_im, double y_re, double y_im, double z_re, double z_im, double p_re, double p_im, double* res_re, double* res_im)
{
    xsf_cplx_ellint_rj(x_re, x_im, y_re, y_im, z_re, z_im, p_re, p_im, res_re, res_im);
}





void Lib_xsf_cplx_w(double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_w(z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_erfcx(double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_erfcx(z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_erf(double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_erf(z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_erfi(double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_erfi(z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_erfc(double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_erfc(z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_dawson(double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_dawson(z_re, z_im, res_re, res_im);
}





void Lib_xsf_cplx_bessel_je(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_bessel_je(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_bessel_ye(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_bessel_ye(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_bessel_ie(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_bessel_ie(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_bessel_ke(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_bessel_ke(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_hankel_1e(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_hankel_1e(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_hankel_2e(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_hankel_2e(v, z_re, z_im, res_re, res_im);
}





void Lib_xsf_cplx_bessel_j(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_bessel_j(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_bessel_y(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_bessel_y(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_bessel_i(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_bessel_i(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_bessel_k(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_bessel_k(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_hankel_1(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_hankel_1(v, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_hankel_2(double v, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_hankel_2(v, z_re, z_im, res_re, res_im);
}





void Lib_xsf_cplx_airyai(int kode, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_airyai(kode, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_airybi(int kode, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_airybi(kode, z_re, z_im, res_re, res_im);
}

void Lib_xsf_cplx_airyaip(int kode, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_airyaip(kode, z_re, z_im, res_re, res_im);
}

void Libxsf_cplx_airybip(int kode, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_airybip(kode, z_re, z_im, res_re, res_im);
}





void Lib_xsf_cplx_hyp2f1(double a, double b, double c, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_cplx_hyp2f1(a, b, c, z_re, z_im, res_re, res_im);
}


void Lib_xsf_sf_cplx_chyp2f1(double a, double b, double c, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_sf_cplx_chyp2f1(a, b, c, z_re, z_im, res_re, res_im);
}


void Lib_xsf_sf_cplx_chyp1f1(double a, double b, double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_sf_cplx_chyp1f1(a, b, z_re, z_im, res_re, res_im);
}


void Lib_xsf_sf_cplx_cerf(double z_re, double z_im, double* res_re, double* res_im)
{
    xsf_sf_cplx_cerf(z_re, z_im, res_re, res_im);
}





void Lib_xsf_cplx_sici(double z_re, double z_im, double* si_re, double* si_im, double* ci_re, double* ci_im)
{
    xsf_cplx_sici(z_re, z_im, si_re, si_im, ci_re, ci_im);
}

void Lib_xsf_cplx_fresnel(double z_re, double z_im, double* fs_re, double* fs_im, double* fc_re, double* fc_im)
{
    xsf_cplx_fresnel(z_re, z_im, fs_re, fs_im, fc_re, fc_im);
}
















