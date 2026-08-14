#include "libBoostEigenDense.h"



void EigenLib_ConvertRealCplx(mpMatrix *RMat, int32_t what, mpMatrixC *CMat)
{
    switch (what) {
        case mp_conv_set_real_to_complex_dbl: (*CMat).real() = (*RMat); break;
        case mp_conv_get_real_from_complex_dbl: (*RMat) = (*CMat).real(); break;

        case mp_conv_set_imag_to_complex_dbl: (*CMat).imag() = (*RMat); break;
        case mp_conv_get_imag_from_complex_dbl: (*RMat) = (*CMat).imag(); break;
    }
}




void EigenLib__mpType_CplxScalarArithmetic(mpMatrixC *result, long what, mpMatrix *x, mpType *f_re, mpType *f_im)
{
    cplx_mpType f = std::complex<mpType>(*f_re, *f_im);
	switch (what){
		case mp_const_plus_scalar: *result = f + (*x).array() ; break;
		case mp_const_minus_scalar: *result = -f + (*x).array() ; break;
		case mp_const_times_scalar: *result = f * (*x).array() ; break;
		case mp_const_div_scalar: (*result) = (*x) / f ; break;
	}
}


