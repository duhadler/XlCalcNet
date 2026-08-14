


/* note: use mp4.verbosity to deal with "quiet", "errors", "warnings", and "full" */

/* note: use mp4.arb_prec = 1 to intmax */
/* note: use mp4.arb_dps = 1 to intmax */

/* note: use mp4.fmpz_format_base = 2 to 62 */
/* note: use mp4.mpfr_format_base = 2 to 32 */
/* note: use mp4.dbl_format_base = 2 to 16 */
/* note: use mp4.arb_format_base = 2 or 10 */

/* note: use mp4.arb_format_digits = 1 to +inf (=full) */
/* note: use mp4.arb_format_pretty = "disabled", "enabled"  */

/* note: use mp4.chop_mode to deal with chopping values near zero: "disabled", "enabled"  */
/* note: use mp4.chop_level to set the chopping threshold  */


/* note: use mp4.arb_auto_mode to deal with internal precision ("none", "jointly": only abs(z), "separately": re/im ) */
/* note: use mp4.arb_radius_mode to deal with arf routines incl. rounding: "disabled", "enabled"  */
/* note: use mp4.arb_usage to control arb usage when called from double or mpfr ("always", "backup") */
/* note: use mp4.amath_usage to control amath usage when called from double ("always", "backup") */

/* note: use mp4.matrix_mode to deal with "scalar", "array", "matrix", "sparsematrix", "polynomial", and "series" */
/* note: use mp4.series_n to set the length of series calculations from 1 to n */

/* note: modify rint parameters  to deal with rint-rounding: "truncate", "floor", "ceil", "nearest" */


#define mp_real 24
#define mp_cplx 25


#define mp_default_prec 0
#define mp_use_arb 1
#define mp_use_amath 2

#define mp_fft_fwd 0
#define mp_fft_inv 1
#define mp_fft_real_fwd 2
#define mp_fft_real_inv 3

#define mp_roots_to_monic_polynomial 0
#define mp_poly_eval 1
#define mp_poly_eval_complex 2
#define mp_polynomial_solver 3

#define mp_sort_ascending 0
#define mp_sort_descending 1

#define mp_sort_by_abs 0
#define mp_sort_by_real 1
#define mp_sort_by_imag 2


/* basic operand types */

#define mp_scalar 0
#define mp_eigen 1
#define mp_map 2
#define mp_poly 3
#define mp_sparse 4
#define mp_fft 5
#define mp_matrix_function 6
#define mp_poly2 7

#define mp_acb 0
#define mp_arb 1
#define mp_arb_arb 2

#define mp_mpci 3
#define mp_mpri 4
#define mp_mpri_mpri 5

//#define mp_xci 6
//#define mp_xri 7
//#define mp_xri_xri 8


#define mp_acf 9
#define mp_arf 10
#define mp_arf_arf 11


#define mp_dcf 12
#define mp_drf 13
#define mp_drf_drf 14

#define mp_mpcf 15
#define mp_mprf 16
#define mp_mprf_mprf 17

#define mp_fmpq 18
#define mp_fmpz 19
#define mp_fmpz_fmpz 20


#define mp_int32 30
#define mp_uint32 31
#define mp_int64 32
#define mp_uint64 33
#define mp_double2 34
#define mp_complex2 35

//#define mp_double 34
//#define mp_complex 35


#define mp_xrf 36
#define mp_xrf_xrf 37
#define mp_xcf 38

#define mp_ext 46
#define mp_ext_ext 47
#define mp_ext_cplx 48


#define mp_quad 56
#define mp_quad_quad 57
#define mp_quad_cplx 58

//#define mp_dquad 66
//#define mp_dquad_dquad 67
//#define mp_dquad_cplx 68


#define mp_string 40


/* ******************************************* */

#define mp_xrf_set 127
#define mp_xrf_get 128

#define mp_xcf_get_real_d 129
#define mp_xcf_get_imag_d 130

#define mp_xcf_from_rect 131
#define mp_xcf_from_polar 132

/* ******************************************* */

#define mp_sizeinbase10 133
#define mp_getstring 134


#define mp_fmpq_num 137
#define mp_fmpq_den 138

#define mp_mpcf_real 142
#define mp_mpcf_imag 143
#define mp_acf_real 144
#define mp_acf_imag 145
#define mp_acb_real 146
#define mp_acb_imag 147
#define mp_dcf_real 148
#define mp_dcf_imag 149

#define mp_arb_mid_get 156
#define mp_arb_rad_get 157
#define mp_arb_mid_set 158
#define mp_arb_rad_set 159

#define mp_arb_infimum 160
#define mp_arb_supremum 161
#define mp_arb_set_interval 162
#define mp_arb_set_union 163

//#define mp_mpri_get_mid 170
//#define mp_mpri_get_left 171
//#define mp_mpri_get_right 172
//#define mp_mpri_set_left 173
//#define mp_mpri_set_right 174
//
//#define mp_mpci_real 175
//#define mp_mpci_imag 176


//#define mp_xri_get_mid 180
//#define mp_xri_get_left 181
//#define mp_xri_get_right 182
//#define mp_xri_set_left 183
//#define mp_xri_set_right 184
//
//#define mp_xci_real 185
//#define mp_xci_imag 186


/* ******************************************* */
/* ******************************************* */
/* ******************************************* */


/* basic procedure types */

#define mp_reverse_offset 10
#define mp_set_scalar 0

#define mp_add 10
#define mp_sub 11
#define mp_mul 12
#define mp_div 13
#define mp_pow 14

#define mp_radd 20
#define mp_rsub 21
#define mp_rmul 22
#define mp_rdiv 23
#define mp_rpow 24








/***************************************/




/* 1 fmpz argument, returns 1 integer result*/
#define mp_fmpzfunc1_is_zero 0
#define mp_fmpzfunc1_is_one 1

#define mp_fmpzfunc1_is_nan 2  // should be added
#define mp_fmpzfunc1_is_posinf 3  // should be added
#define mp_fmpzfunc1_is_neginf 4  // should be added
#define mp_fmpzfunc1_is_finite 5  // should be added


#define mp_fmpzfunc1_is_odd 6  // Fmpz_Odd
#define mp_fmpzfunc1_is_even 7  // Fmpz_Even
#define mp_fmpzfunc1_sgn 8  // Fmpz_Sgn


#define mp_fmpzfunc2_is_perfect_power 40  // Fmpz_Perfect_Power
#define mp_fmpzfunc2_is_perfect_square 41  // Fmpz_Perfect_Square_P

#define mp_fmpzfunc1_is_probabprime_BPSW 42  // Fmpz_Is_Probabprime_BPSW
#define mp_fmpzfunc1_is_probabprime 43  // Fmpz_Is_Probabprime
#define mp_fmpzfunc1_is_prime_pseudosquare 44  // Fmpz_Is_Prime_Pseudosquare
#define mp_fmpzfunc1_is_prime 45  // Fmpz_Is_Prime
#define mp_fmpzfunc1_is_probabprime_lucas 46  // Fmpz_Is_Probabprime_Lucas

#define mp_fmpzfunc1_is_prime_aprcl 47
#define mp_fmpzfunc1_is_prime_jacobi 48
#define mp_fmpzfunc1_is_prime_gauss 49



#define mp_fmpzfunc1_popcount 50  // Fmpz_Popcount. change required: return value needs to be fmpz to allow for inf
#define mp_fmpzfunc2_tstbit 60  // Fmpz_Tstbit.

#define mp_fmpzfunc2_scan0 70  // Fmpz_Scan0 change required:  return value need to be fmpz to allow for inf
#define mp_fmpzfunc2_scan1 71  // Fmpz_Scan1 change required:  return value need to be fmpz to allow for inf




/* 2 fmpz arguments, returns 1 integer result */
#define mp_fmpzfunc2_is_divisible 1  // Fmpz_Divisible

#define mp_fmpzfunc2_legendre_symbol 2  // Fmpz_Legendre
#define mp_fmpzfunc2_jacobi_symbol 3  // Fmpz_Jacobi
#define mp_fmpzfunc2_kronecker_extension 4  // Fmpz_Kronecker

#define mp_fmpzfunc2_hamdist 10  // Fmpz_Hamdist change required: return value needs to be fmpz


#define mp_fmpzfunc2_cmp 20  // Fmpz_Cmp
#define mp_fmpzfunc2_cmp_abs 21  // Fmpz_Cmpabs




/* 3 fmpz arguments, returns 1 integer result */
#define mp_fmpzfunc2_is_congruent 1  //Fmpz_Congruent_P
#define mp_fmpzfunc2_invert 2  // Fmpz_Invert:
#define mp_fmpzfunc2_remove 3  // Fmpz_Remove





/* 0 argument, returns 1 fmpz result */


#define mp_fmpzfunc0_nan 1 // should be added
#define mp_fmpzfunc0_posinf 2 // should be added
#define mp_fmpzfunc0_neginf 3 // should be added
#define mp_fmpzfunc0_zero 4 // should be added
#define mp_fmpzfunc0_poszero 5 // should be added
#define mp_fmpzfunc0_negzero 6 // should be added
#define mp_fmpzfunc0_one 7 // should be added

#define mp_fmpzfunc1_setbit 10  // Fmpz_Setbit.
#define mp_fmpzfunc1_clrbit 11  // Fmpz_Clrbit.
#define mp_fmpzfunc1_combit 12  // Fmpz_Combit.




/* 1 fmpz argument, returns 1 fmpz result */

#define mp_fmpzfunc1_swap 0  // Fmpz_Neg

#define mp_fmpzfunc1_neg 1  // Fmpz_Neg
#define mp_fmpzfunc1_abs 2  // Fmpz_Abs
#define mp_fmpzfunc1_sign 3  // needs to implemented
#define mp_fmpzfunc1_square 4  // should be added
#define mp_fmpzfunc1_sqrt 5  // Fmpz_Sqrt

#define mp_fmpzfunc1_complement 6  // Fmpz_Complement

#define mp_fmpzfunc1_randm 10
#define mp_fmpzfunc1_randtest_mod 11
#define mp_fmpzfunc1_randtest_mod_signed 12





/* 1 integer argument, returns 1 fmpz result */
#define mp_fmpzfunc1_fac_ui 1  // Fmpz_Fac_UI
#define mp_fmpzfunc1_2fac_ui 2  // Fmpz_2Fac_UI
#define mp_fmpzfunc1_primorial 3  // Fmpz_Primorial

#define mp_fmpzfunc1_fib_ui 4  // Fmpz_Fib_UI
#define mp_fmpzfunc1_lucnum_ui 5  // Fmpz_Lucnum_UI


#define mp_fmpzfunc1_randbits 10
#define mp_fmpzfunc1_randtest 11
#define mp_fmpzfunc1_randtest_unsigned 12
#define mp_fmpzfunc1_randtest_not_zero 13



/* 1 fmpz argument, , returns 2 fmpz results */
#define mp_fmpzfunc1_sqrtrem 1  // Fmpz_SqrtRem





 /* 2 fmpz arguments, returns 1 fmpz result */

#define mp_fmpzfunc2_cdiv_q 1  // Fmpz_Cdiv_Q
#define mp_fmpzfunc2_fdiv_q 2  // Fmpz_Fdiv_Q
#define mp_fmpzfunc2_tdiv_q 3  // Fmpz_Tdiv_Q


#define mp_fmpzfunc2_cdiv_r 4  // Fmpz_Cdiv_R
#define mp_fmpzfunc2_fdiv_r 5  // Fmpz_Fdiv_R
#define mp_fmpzfunc2_tdiv_r 6  // Fmpz_Tdiv_R


#define mp_fmpzfunc2_mod 10  // Fmpz_Mod
#define mp_fmpzfunc2_divexact 12  // Divexact

#define mp_fmpzfunc2_gcd 14  // Fmpz_Gcd
#define mp_fmpzfunc2_lcm 15  // Fmpz_Lcm


#define mp_fmpzfunc2_and 17  // Fmpz_And
#define mp_fmpzfunc2_or 18  // Fmpz_OR
#define mp_fmpzfunc2_xor 19  // Fmpz_XOR


#define mp_fmpzfunc2_addmul 30  // Fmpz_Addmul
#define mp_fmpzfunc2_submul 31  // Fmpz_Submul




 /* 2 arguments (first fmpz, second integer), returns 1 fmpz result */
#define mp_fmpzfunc2_mul_2exp 1  // Fmpz_Mul_2exp

#define mp_fmpzfunc2_cdiv_q_2exp 2  // Fmpz_Cdiv_Q_2exp
#define mp_fmpzfunc2_fdiv_q_2exp 3  // Fmpz_Fdiv_Q_2exp
#define mp_fmpzfunc2_tdiv_q_2exp 4  // Fmpz_Tdiv_Q_2exp

#define mp_fmpzfunc2_cdiv_r_2exp 5  // Fmpz_Cdiv_R_2exp
#define mp_fmpzfunc2_fdiv_r_2exp 6  // Fmpz_Fdiv_R_2exp
#define mp_fmpzfunc2_tdiv_r_2exp 7  // Fmpz_Tdiv_R_2exp

#define mp_fmpzfunc2_pow_ui 8  // Fmpz_Pow_Ui
#define mp_fmpzfunc2_root_ui 9   // NthRoot
#define mp_fmpzfunc2_bin_ui 10  // Fmpz_Bin_UI




 /* 2 integer arguments ( both ui), returns 1 fmpz result */
#define mp_fmpzfunc2_ui_pow_ui 1  // Fmpz_UI_Pow_Ui
#define mp_fmpzfunc2_mfac_ui_ui 2  // Fmpz_mFac_UIUI
#define mp_fmpzfunc2_bin_ui_ui 3  // Fmpz_Bin_UIUI


/* 2 arguments (first fmpz, second integer), returns 2 fmpz results */
#define mp_fmpzfunc2_rootrem 0  // Fmpz_Rootrem
#define mp_fmpzfunc2_fib2_ui 1  // Fmpz_Fib2_UI
#define mp_fmpzfunc2_lucnum2_ui 2  // Fmpz_Lucnum2_UI



/* 2 fmpz arguments, returns 2 fmpz results */
#define mp_fmpzfunc2_cdiv_qr 1   // Fmpz_Cdiv_QR
#define mp_fmpzfunc2_fdiv_qr 2   // Fmpz_Fdiv_QR
#define mp_fmpzfunc2_tdiv_qr 3   // Fmpz_Tdiv_QR

#define mp_fmpzfunc2_gcdinv 4   // Fmpz_Tdiv_QR




/* 3 fmpz arguments, returns 1 fmpz result */
#define mp_fmpzfunc2_powm 13  // Fmpz_Powm
#define mp_fmpzfunc3_fma 1
#define mp_fmpzfunc3_fms 2


/* 4 fmpz arguments, returns 1 fmpz result */
#define mp_fmpzfunc2_3_fmpz_xgcd 0   // we use here 2 input and 3 outpu instead of 4 input and  1 output






/* 1 complex argument, returns 1 integer result */
#define mp_cplxfunc1_is_zero 1
#define mp_cplxfunc1_is_one 2
#define mp_cplxfunc1_is_finite 3
#define mp_cplxfunc1_is_real 4



/* 2 complex arguments, returns 1 integer result */
#define mp_cplxfunc2_cmp 1
#define mp_cplxfunc2_cmp_abs 2
#define mp_cplxfunc2_eq 3
#define mp_cplxfunc2_ne 4


/* 0 argument, returns 1 complex result  */

    /* BEGIN: ONLY COMPLEX */
#define mp_cplxfunc0_onei 820
    /* END: ONLY COMPLEX */

#define mp_cplxfunc0_nan 800
#define mp_cplxfunc0_zero 806
#define mp_cplxfunc0_one 807


/* 1 complex argument, returns 1 complex result  */
    /* BEGIN: ONLY COMPLEX */
#define mp_cplxfunc1_exp_pi_i 1
    /* END: ONLY COMPLEX */

#define mp_cplxfunc1_square 10
#define mp_cplxfunc1_cube 11
#define mp_cplxfunc1_sqrt 12
#define mp_cplxfunc1_sqrt1pm1 13  /* to be added */

#define mp_cplxfunc1_rsqrt 14
#define mp_cplxfunc1_cbrt 15

#define mp_cplxfunc1_exp 16
#define mp_cplxfunc1_expm1 17
#define mp_cplxfunc1_exp10 18
#define mp_cplxfunc1_exp2 19

#define mp_cplxfunc1_log 20
#define mp_cplxfunc1_log1p 21
#define mp_cplxfunc1_log10 22
#define mp_cplxfunc1_log2 23

#define mp_cplxfunc2_lambertw 24


#define mp_cplxfunc1_sin 30
#define mp_cplxfunc1_cos 31
#define mp_cplxfunc1_tan 32

#define mp_cplxfunc1_csc 33
#define mp_cplxfunc1_sec 34
#define mp_cplxfunc1_cot 35


#define mp_cplxfunc1_sinh 40
#define mp_cplxfunc1_cosh 41
#define mp_cplxfunc1_tanh 42

#define mp_cplxfunc1_csch 43
#define mp_cplxfunc1_sech 44
#define mp_cplxfunc1_coth 45

#define mp_cplxfunc1_asin 50
#define mp_cplxfunc1_acos 51
#define mp_cplxfunc1_atan 52

#define mp_cplxfunc1_acsc 53
#define mp_cplxfunc1_asec 54
#define mp_cplxfunc1_acot 55


#define mp_cplxfunc1_asinh 60
#define mp_cplxfunc1_acosh 61
#define mp_cplxfunc1_atanh 62

#define mp_cplxfunc1_acsch 63
#define mp_cplxfunc1_asech 64
#define mp_cplxfunc1_acoth 65


#define mp_cplxfunc1_sinpi 70
#define mp_cplxfunc1_cospi 71
#define mp_cplxfunc1_tanpi 72
#define mp_cplxfunc1_cotpi 73

#define mp_cplxfunc1_sinc 74
#define mp_cplxfunc1_sinc_pi 75

#define mp_cplxfunc1_sqrt1px2 86
#define mp_cplxfunc1_sqrtp1m1 87
#define mp_cplxfunc1_sqrtx2m1 88
#define mp_cplxfunc1_sqrt1mx2 89


#define mp_cplxfunc1_gamma 90
#define mp_cplxfunc1_rgamma 91
#define mp_cplxfunc1_lgamma 92
#define mp_cplxfunc1_digamma 93
#define mp_cplxfunc1_zeta 94

#define mp_cplxfunc1_lambertw 24


#define mp_cplxfunc1_log_sin_pi 99

#define mp_cplxfunc1_erf 100
#define mp_cplxfunc1_erfc 101
#define mp_cplxfunc1_erfi 102
#define mp_cplxfunc1_ei 103
#define mp_cplxfunc1_si 104
#define mp_cplxfunc1_ci 105
#define mp_cplxfunc1_shi 106
#define mp_cplxfunc1_chi 107
#define mp_cplxfunc1_li 108
#define mp_cplxfunc1_lioffset 109

#define mp_cplxfunc1_ai 110
#define mp_cplxfunc1_aiprime 111
#define mp_cplxfunc1_bi 112
#define mp_cplxfunc1_biprime 113

#define mp_cplxfunc1_fresnelc 114
#define mp_cplxfunc1_fresnels 115

#define mp_cplxfunc1_riemann_siegel_theta 120
#define mp_cplxfunc1_sqrt1mz2 121

#define mp_cplxfunc1_dirichlet_xi 130
#define mp_cplxfunc1_dirichlet_eta 131
#define mp_cplxfunc1_dirichlet_hardy_z 132
#define mp_cplxfunc1_dirichlet_hardy_theta 133
#define mp_cplxfunc1_dirichlet_backlund_s 134
#define mp_cplxfunc1_dirichlet_zeta_nzeros 135




#define mp_cplxfunc1_j0 160 /* to be added */
#define mp_cplxfunc1_j1 161 /* to be added */
#define mp_cplxfunc1_y0 162 /* to be added */
#define mp_cplxfunc1_y1 163 /* to be added */


#define mp_cplxfunc1_ndens 200
#define mp_cplxfunc1_ndis 201


#define mp_cplxfunc1_swap 800   /* move swap to basic functions */

#define mp_cplxfunc1_neg 810
#define mp_cplxfunc1_conj 811
#define mp_cplxfunc1_proj 812
#define mp_cplxfunc1_sgn 813
#define mp_cplxfunc1_csgn 814


#define mp_cplxfunc1_barnesg 1001  // no special code for real
#define mp_cplxfunc1_lbarnesg 1002  // no special code for real
#define mp_cplxfunc1_agm1 1003  // no special code for real

#define mp_cplxfunc1_dilog 1004  // no special code for real

#define mp_cplxfunc1_modeta 1005  // no special code for real
#define mp_cplxfunc1_modj 1006  // no special code for real
#define mp_cplxfunc1_modlambda 1007  // no special code for real
#define mp_cplxfunc1_moddelta 1008  // no special code for real

#define mp_cplxfunc1_ellipk 1009  // no special code for real
#define mp_cplxfunc1_ellipe 1010  // no special code for real

#define mp_cplxfunc1_elliptic_invariant_g2 1020  //no special code for real argument
#define mp_cplxfunc1_elliptic_invariant_g3 1021  //no special code for real argument

#define mp_cplxfunc1_elliptic_root_e1 1022  //no special code for real argument
#define mp_cplxfunc1_elliptic_root_e2 1023  //no special code for real argument
#define mp_cplxfunc1_elliptic_root_e3 1024  //no special code for real argument




/* 1 real/complex argument , always returns 1 real result */
#define mp_cplxfunc1_abs 820
#define mp_cplxfunc1_arg 821
#define mp_cplxfunc1_norm 822
#define mp_cplxfunc1_real 823
#define mp_cplxfunc1_imag 824


/* 1 integer argument (ui), returns 1 complex  result*/
    /* BEGIN: ONLY COMPLEX */
#define mp_cplxfunc1_unit_root 1
#define mp_cplxfunc1_zeta_zero_ui 10

    /* END: ONLY COMPLEX */



/* 1 complex argument, returns 2 complex results  */
#define mp_cplxfunc1_2_exp_invexp 1
#define mp_cplxfunc1_2_sin_cos 2
#define mp_cplxfunc1_2_sin_cos_pi 3
#define mp_cplxfunc1_2_sinh_cosh 4
#define mp_cplxfunc1_2_airy_ai_bi 5
#define mp_cplxfunc1_2_airy_ai_bi_prime 6
#define mp_cplxfunc1_2_fresnel 7
#define mp_cplxfunc1_2_fresnel_r 8



/* 2 complex arguments, returns 1 complex result */
#define mp_cplxfunc2_mul 1
#define mp_cplxfunc2_div 2
#define mp_cplxfunc2_pow 3
#define mp_cplxfunc2_hurwitz_zeta 4
#define mp_cplxfunc2_rising 6

#define mp_cplxfunc2_agm 14

#define mp_cplxfunc2_polylog 15
#define mp_cplxfunc2_expint 16

#define mp_cplxfunc2_besselj 17
#define mp_cplxfunc2_bessely 18
#define mp_cplxfunc2_besseli 19
#define mp_cplxfunc2_besselk 20

#define mp_cplxfunc2_hyp0f1 21
#define mp_cplxfunc2_hyp0f1r 22

#define mp_cplxfunc2_chebyt 25
#define mp_cplxfunc2_chebyu 26
#define mp_cplxfunc2_hermiteh 27

#define mp_cplxfunc2_gamma_upper 30
#define mp_cplxfunc2_gamma_upper_r 31
#define mp_cplxfunc2_gamma_lower 32
#define mp_cplxfunc2_gamma_lower_r 33
#define mp_cplxfunc2_beta 34

#define mp_cplxfunc2_logbase 50


#define mp_cplxfunc2_gamma_p_derivative 60
#define mp_cplxfunc2_gamma_p 61
#define mp_cplxfunc2_gamma_q 62


#define mp_cplxfunc2_polygamma 1001  //no special code for real argument

#define mp_cplxfunc2_theta1 1002  //no special code for real argument
#define mp_cplxfunc2_theta2 1003  //no special code for real argument
#define mp_cplxfunc2_theta3 1004  //no special code for real argument
#define mp_cplxfunc2_theta4 1005  //no special code for real argument

#define mp_cplxfunc2_ellipp 1006  // Weierstrass  //no special code for real argument

#define mp_cplxfunc2_elliptic_f 1007  //no special code for real argument
#define mp_cplxfunc2_elliptic_e_inc 1008  //no special code for real argument
#define mp_cplxfunc2_elliptic_pi 1009  //no special code for real argument
#define mp_cplxfunc2_elliptic_rc 1010  //no special code for real argument


#define mp_cplxfunc2_elliptic_p 1025  //no special code for real argument
#define mp_cplxfunc2_elliptic_inv_p 1026  //no special code for real argument
#define mp_cplxfunc2_elliptic_zeta 1027  //no special code for real argument
#define mp_cplxfunc2_elliptic_sigma 1028  //no special code for real argument
#define mp_cplxfunc2_elliptic_p_prime 1029  //no special code for real argument




/* 2 arguments (first complex, second integer), returns 1 complex result  */
#define mp_cplxfunc2_root_ui 1
#define mp_cplxfunc2_rising_ui 2

#define mp_cplxfunc2_bernoulli_poly_ui 4
#define mp_cplxfunc2_chebyt_ui 5
#define mp_cplxfunc2_chebyu_ui 6

#define mp_cplxfunc2_lambertw_ui 10
#define mp_cplxfunc2_stieltjes_ui 11


/* 2 complex arguments (one of which is ui), returns 2 complex result  */
#define mp_cplxfunc2_rising2_ui 1
#define mp_cplxfunc2_chebyt2_ui 2
#define mp_cplxfunc2_chebyu2_ui 3


/* 2 complex arguments, returns 2 complex results  */
#define mp_cplxfunc2_bessel_jy 1


/* 3 complex arguments, returns 1 complex result*/
#define mp_cplxfunc3_hyperu 1
#define mp_cplxfunc3_hyp1f1 2
#define mp_cplxfunc3_hyp1f1r 3

#define mp_cplxfunc3_gegenbauerc 4
#define mp_cplxfunc3_laguerrel 5
#define mp_cplxfunc3_legenp 6
#define mp_cplxfunc3_legenpv 7
#define mp_cplxfunc3_legenq 8
#define mp_cplxfunc3_legenqv 9

#define mp_cplxfunc3_beta_lower 10
#define mp_cplxfunc3_beta_lower_r 11


#define mp_cplxfunc3_ibeta_derivative 20
#define mp_cplxfunc3_ibeta 21
#define mp_cplxfunc3_ibetac 22


#define mp_cplxfunc3_fma 800 /* to be added */
#define mp_cplxfunc3_fms 801 /* to be added */


#define mp_cplxfunc3_elliptic_pi_inc 1001  //no special code for real argument
#define mp_cplxfunc3_elliptic_rf 1002  //no special code for real argument
#define mp_cplxfunc3_elliptic_rg 1003  //no special code for real argument
#define mp_cplxfunc3_elliptic_rd 1004  //no special code for real argument


#define mp_cplxfunc3_coulomb_f 1011  //no special code for real argument
#define mp_cplxfunc3_coulomb_g 1012  //no special code for real argument
#define mp_cplxfunc3_coulomb_hpos 1013  //no special code for real argument
#define mp_cplxfunc3_coulomb_hneg 1014  //no special code for real argument

#define mp_cplxfunc3_lerch_phi 1015  //no special code for real argument


/* 4 complex arguments, returns 1 complex result */
#define mp_cplxfunc4_hyp2f1 1
#define mp_cplxfunc4_hyp2f1r 2
#define mp_cplxfunc4_jacobip 3
#define mp_cplxfunc4_hyp1f2 4
#define mp_cplxfunc4_hyp1f2r 5

#define mp_cplxfunc4_elliptic_rj 1001  //no special code for real argument
#define mp_cplxfunc4_spherical_y 1002  //no special code for real argument

#define mp_cplxfunc4_theta_jet 1010  //no special code for real argument


//



#define mp_realfunc_limit 1000
#define mp_realfunc_limit_native 800






/* 1 real argument, returns 1 integer result*/
#define mp_realfunc1_is_zero 1
#define mp_realfunc1_is_one 2
#define mp_realfunc1_is_finite 3   // = regular_p or is_zero
#define mp_realfunc1_is_real 4  /* to be added */

    /* BEGIN: ONLY REAL */
#define mp_realfunc1_is_nan 11
#define mp_realfunc1_is_infinite 12
#define mp_realfunc1_is_number 13
#define mp_realfunc1_is_regular 15
#define mp_realfunc1_is_integer 16
#define mp_realfunc1_has_signbit 18


#define mp_realfunc1_fits_big_integer 21
#define mp_realfunc1_fits_oa_decimal 22
#define mp_realfunc1_fits_uint32 25
#define mp_realfunc1_fits_int32 26
#define mp_realfunc1_fits_uint64 27
#define mp_realfunc1_fits_int64 28
    /* END: ONLY REAL */

/* 2 real arguments, returns 1 integer result */
#define mp_realfunc2_cmp 1
#define mp_realfunc2_cmp_abs 2
#define mp_realfunc2_same_quantum 3

#define mp_realfunc2_eq 4  /* to be added */
#define mp_realfunc2_ne 5  /* to be added */


    /* BEGIN: ONLY REAL */
#define mp_realfunc2_greater_p 11
#define mp_realfunc2_greaterequal_p 12
#define mp_realfunc2_less_p 13
#define mp_realfunc2_lessequal_p 14
#define mp_realfunc2_equal_p 15
#define mp_realfunc2_lessgreater_p 16
#define mp_realfunc2_unordered_p 17
    /* END: ONLY REAL */


/* 0 argument, returns 1 real result */

    /* BEGIN: ONLY REAL */
#define mp_realfunc0_pi 1
#define mp_realfunc0_sqrt_pi 2
#define mp_realfunc0_log_sqrt2pi 3
#define mp_realfunc0_log2 4
#define mp_realfunc0_log10 5
#define mp_realfunc0_euler 6
#define mp_realfunc0_catalan 7
#define mp_realfunc0_e 8
#define mp_realfunc0_khinchin 9
#define mp_realfunc0_glaisher 10
#define mp_realfunc0_apery 11

#define mp_realfunc0_posinf 801
#define mp_realfunc0_neginf 802
#define mp_realfunc0_poszero 803
#define mp_realfunc0_negzero 804
#define mp_realfunc0_zero_pm_inf 805

#define mp_realfunc0_machine_epsilon 811
#define mp_realfunc0_maxval 812
#define mp_realfunc0_minval 813
    /* END: ONLY REAL */


#define mp_realfunc0_nan 800
#define mp_realfunc0_zero 806
#define mp_realfunc0_one 807



/* 1 real argument, returns 1 real result */

    /* BEGIN: ONLY REAL */
#define mp_realfunc1_frac 860
#define mp_realfunc1_ceil 861
#define mp_realfunc1_floor 862
#define mp_realfunc1_round 863
#define mp_realfunc1_trunc 864

#define mp_realfunc1_rint 870
#define mp_realfunc1_rint_ceil 871
#define mp_realfunc1_rint_floor 872
#define mp_realfunc1_rint_round 873
#define mp_realfunc1_rint_trunc 874

#define mp_realfunc2_nextabove 880
#define mp_realfunc2_nextbelow 881

#define mp_realfunc2_reduce 882
	/* END: ONLY REAL */

#define mp_realfunc1_square 10
#define mp_realfunc1_cube 11
#define mp_realfunc1_sqrt 12
#define mp_realfunc1_sqrt1pm1 13

#define mp_realfunc1_rsqrt 14
#define mp_realfunc1_cbrt 15

#define mp_realfunc1_exp 16
#define mp_realfunc1_expm1 17
#define mp_realfunc1_exp10 18
#define mp_realfunc1_exp2 19

#define mp_realfunc1_log 20
#define mp_realfunc1_log1p 21
#define mp_realfunc1_log10 22
#define mp_realfunc1_log2 23

#define mp_realfunc2_lambertw 24

#define mp_realfunc1_expx2m1 25
#define mp_realfunc1_expmx2 26
#define mp_realfunc1_expmx2m1 27
#define mp_realfunc1_ln_sin 28
#define mp_realfunc1_ln_cos 29

#define mp_realfunc1_sin 30
#define mp_realfunc1_cos 31
#define mp_realfunc1_tan 32

#define mp_realfunc1_csc 33
#define mp_realfunc1_sec 34
#define mp_realfunc1_cot 35


#define mp_realfunc1_sinh 40
#define mp_realfunc1_cosh 41
#define mp_realfunc1_tanh 42

#define mp_realfunc1_csch 43
#define mp_realfunc1_sech 44
#define mp_realfunc1_coth 45

#define mp_realfunc1_asin 50
#define mp_realfunc1_acos 51
#define mp_realfunc1_atan 52

#define mp_realfunc1_acsc 53
#define mp_realfunc1_asec 54
#define mp_realfunc1_acot 55


#define mp_realfunc1_asinh 60
#define mp_realfunc1_acosh 61
#define mp_realfunc1_atanh 62

#define mp_realfunc1_acsch 63
#define mp_realfunc1_asech 64
#define mp_realfunc1_acoth 65

#define mp_realfunc1_acoshp1 66

#define mp_realfunc1_sinpi 70
#define mp_realfunc1_cospi 71
#define mp_realfunc1_tanpi 72
#define mp_realfunc1_cotpi 73

#define mp_realfunc1_sinc 74
#define mp_realfunc1_sinc_pi 75
#define mp_realfunc1_sinhc_pi 76 /* to be added */

#define mp_realfunc1_sqrt1px2 86
#define mp_realfunc1_sqrtp1m1 87
#define mp_realfunc1_sqrtx2m1 88
#define mp_realfunc1_sqrt1mx2 89


#define mp_realfunc1_gamma 90
#define mp_realfunc1_rgamma 91
#define mp_realfunc1_lgamma 92
#define mp_realfunc1_digamma 93
#define mp_realfunc1_zeta 94

#define mp_realfunc1_gamma1pm1 95


#define mp_realfunc1_log_sin_pi 99 /* to be added */

#define mp_realfunc1_erf 100
#define mp_realfunc1_erfc 101
#define mp_realfunc1_erfi 102
#define mp_realfunc1_ei 103
#define mp_realfunc1_si 104
#define mp_realfunc1_ci 105
#define mp_realfunc1_shi 106
#define mp_realfunc1_chi 107
#define mp_realfunc1_li 108
#define mp_realfunc1_lioffset 109

#define mp_realfunc1_ai 110
#define mp_realfunc1_aiprime 111
#define mp_realfunc1_bi 112
#define mp_realfunc1_biprime 113

#define mp_realfunc1_fresnelc 114
#define mp_realfunc1_fresnels 115

#define mp_realfunc1_erf_inv 120
#define mp_realfunc1_erfc_inv 121

#define mp_realfunc1_aizero 122
#define mp_realfunc1_bizero 123

#define mp_realfunc1_dirichlet_xi 130
#define mp_realfunc1_dirichlet_eta 131
#define mp_realfunc1_dirichlet_hardy_z 132
#define mp_realfunc1_dirichlet_hardy_theta 133
#define mp_realfunc1_dirichlet_backlund_s 134
#define mp_realfunc1_dirichlet_zeta_nzeros 135


#define mp_realfunc1_j0 160
#define mp_realfunc1_j1 161
#define mp_realfunc1_y0 162
#define mp_realfunc1_y1 163

#define mp_realfunc1_ndens 200
#define mp_realfunc1_ndis 201

#define mp_realfunc1_ellint_1_K 202
#define mp_realfunc1_ellint_2_K 203


#define mp_realfunc1_swap 800  /* move swap to basic functions */

#define mp_realfunc1_neg 810
#define mp_realfunc1_conj 811 /* to be added */
#define mp_realfunc1_proj 812 /* to be added */
#define mp_realfunc1_sgn 813
#define mp_realfunc1_csgn 814 /* to be added */


#define mp_realfunc1_barnesg 1001  // no special code for real
#define mp_realfunc1_lbarnesg 1002  // no special code for real
#define mp_realfunc1_agm1 1003  // no special code for real

#define mp_realfunc1_dilog 1004  // no special code for real

#define mp_realfunc1_modeta 1005  // no special code for real
#define mp_realfunc1_modj 1006  // no special code for real
#define mp_realfunc1_modlambda 1007  // no special code for real
#define mp_realfunc1_moddelta 1008  // no special code for real

#define mp_realfunc1_ellipk 1009  // no special code for real
#define mp_realfunc1_ellipe 1010  // no special code for real



/* 1 real/complex argument , always returns 1 real result */
#define mp_realfunc1_abs 820
#define mp_realfunc1_arg 821  /* to be added */
#define mp_realfunc1_norm 822
#define mp_realfunc1_real 823
#define mp_realfunc1_imag 824



/* 1 integer argument, returns 1 real result */
    /* BEGIN: ONLY REAL */
#define mp_realfunc1_fac_ui 1
#define mp_realfunc1_doublefac_ui 2
#define mp_realfunc1_sqrt_ui 3
#define mp_realfunc1_zeta_ui 4
#define mp_realfunc1_bernoulli_ui 5
#define mp_realfunc1_fib_ui 6
#define mp_realfunc1_bell_ui 7
#define mp_realfunc1_euler_number_ui 8
#define mp_realfunc1_partitions_ui 9
#define mp_realfunc1_zeta_zero_ui 10
#define mp_realfunc1_gram_point_ui 11



    /* END: ONLY REAL */



/* 1 real argument, , returns 2 real results */

    /* BEGIN: ONLY REAL */
#define mp_realfunc1_2_modf 800
#define mp_realfunc1_2_frexp 801
#define mp_realfunc1_2_lgamma_sign 802
    /* END: ONLY REAL */

#define mp_realfunc1_2_exp_invexp 1
#define mp_realfunc1_2_sin_cos 2
#define mp_realfunc1_2_sin_cos_pi 3
#define mp_realfunc1_2_sinh_cosh 4
#define mp_realfunc1_2_airy_ai_bi 5
#define mp_realfunc1_2_airy_ai_bi_prime 6
#define mp_realfunc1_2_fresnel 7
#define mp_realfunc1_2_fresnel_r 8



 /* 2 real arguments, returns 1 real result */
    /* BEGIN: ONLY REAL */

#define mp_realfunc2_fdim 800
#define mp_realfunc2_fmod 802
#define mp_realfunc2_remainder 803

#define mp_realfunc2_fmax 804
#define mp_realfunc2_fmin 805

#define mp_realfunc2_nexttoward 806
#define mp_realfunc2_copysign 807

#define mp_realfunc2_hypot 811
#define mp_realfunc2_atan2 812

#define mp_realfunc2_quantize 815

	/* END: ONLY REAL */

#define mp_realfunc2_mul 1
#define mp_realfunc2_div 2
#define mp_realfunc2_pow 3
#define mp_realfunc2_hurwitz_zeta 4
#define mp_realfunc2_rising 6

#define mp_realfunc2_x2py2 7
#define mp_realfunc2_x2my2 8
#define mp_realfunc2_sqrtx2y2 9
#define mp_realfunc2_ln_sqrtx2y2 10
#define mp_realfunc2_ln_sqrtxp1_2y2 11

#define mp_realfunc2_powm1 13  /* to be added */


#define mp_realfunc2_agm 14

#define mp_realfunc2_polylog 15
#define mp_realfunc2_expint 16

#define mp_realfunc2_besselj 17
#define mp_realfunc2_bessely 18
#define mp_realfunc2_besseli 19
#define mp_realfunc2_besselk 20

#define mp_realfunc2_hyp0f1 21
#define mp_realfunc2_hyp0f1r 22

#define mp_realfunc2_chebyt 25
#define mp_realfunc2_chebyu 26
#define mp_realfunc2_hermiteh 27

#define mp_realfunc2_gamma_upper 30
#define mp_realfunc2_gamma_upper_r 31
#define mp_realfunc2_gamma_lower 32
#define mp_realfunc2_gamma_lower_r 33
#define mp_realfunc2_beta 34


#define mp_realfunc2_gamma_ratio 35 /* to be added */
#define mp_realfunc2_tgamma_delta_ratio 36 /* to be added */
#define mp_realfunc2_falling 37
#define mp_realfunc2_bin_coeff 38


#define mp_realfunc2_union 50

#define mp_realfunc2_gamma_p_derivative 60
#define mp_realfunc2_gamma_p 61
#define mp_realfunc2_gamma_q 62

#define mp_realfunc2_sph_bessel 70
#define mp_realfunc2_sph_neumann 71

#define mp_realfunc2_besselj_prime 72
#define mp_realfunc2_bessely_prime 73
#define mp_realfunc2_besseli_prime 74
#define mp_realfunc2_besselk_prime 75
#define mp_realfunc2_sph_bessel_prime 76
#define mp_realfunc2_sph_neumann_prime 77

#define mp_realfunc2_cyl_bessel_j_zero 78
#define mp_realfunc2_cyl_neumann_zero 79




#define mp_realfunc2_gamma_p_inv 100
#define mp_realfunc2_gamma_q_inv 101
#define mp_realfunc2_gamma_p_inva 102
#define mp_realfunc2_gamma_q_inva 103

#define mp_realfunc2_legendre_p 110
#define mp_realfunc2_legendre_q 111
#define mp_realfunc2_laguerre 112
#define mp_realfunc2_hermite 113

#define mp_realfunc2_expint_n 114
#define mp_realfunc2_owens_t 115

#define mp_realfunc2_ellint_rc 120
#define mp_realfunc2_ellint_1_F 121
#define mp_realfunc2_ellint_2_F 122
#define mp_realfunc2_ellint_3_K 123

#define mp_realfunc2_jacobi_cd 130
#define mp_realfunc2_jacobi_cn 131
#define mp_realfunc2_jacobi_cs 132
#define mp_realfunc2_jacobi_dc 133
#define mp_realfunc2_jacobi_dn 134
#define mp_realfunc2_jacobi_ds 135
#define mp_realfunc2_jacobi_nc 136
#define mp_realfunc2_jacobi_nd 137
#define mp_realfunc2_jacobi_ns 138
#define mp_realfunc2_jacobi_sc 139
#define mp_realfunc2_jacobi_sd 140
#define mp_realfunc2_jacobi_sn 141


#define mp_realfunc2_polygamma 1001  //no special code for real argument

#define mp_realfunc2_theta1 1002  //no special code for real argument
#define mp_realfunc2_theta2 1003  //no special code for real argument
#define mp_realfunc2_theta3 1004  //no special code for real argument
#define mp_realfunc2_theta4 1005  //no special code for real argument

#define mp_realfunc2_ellipp 1006  // Weierstrass  //no special code for real argument

#define mp_realfunc2_elliptic_f 1007  //no special code for real argument
#define mp_realfunc2_elliptic_e_inc 1008  //no special code for real argument
#define mp_realfunc2_elliptic_pi 1009  //no special code for real argument
#define mp_realfunc2_elliptic_rc 1010  //no special code for real argument

#define mp_realfunc3_coulomb_f 1011  //no special code for real argument
#define mp_realfunc3_coulomb_g 1012  //no special code for real argument



 /* 2 arguments (first real, second integer), returns 1 real result */
    /* BEGIN: ONLY REAL */
#define mp_realfunc2_bin_ui 804

#define mp_realfunc2_bessel_jn 800
#define mp_realfunc2_bessel_yn 801

#define mp_realfunc2_ldexp_ui 803  /* incorrect implementation in mpfr */
    /* END: ONLY REAL */

#define mp_realfunc2_root_ui 1
#define mp_realfunc2_rising_ui 2

#define mp_realfunc2_pow_si 3


#define mp_realfunc2_bernoulli_poly_ui 4
#define mp_realfunc2_chebyt_ui 5
#define mp_realfunc2_chebyu_ui 6

#define mp_realfunc2_lambertw_ui 10
#define mp_realfunc2_stieltjes_ui 11


#define mp_realfunc2_mul_2si 20  /* needs to be implemented outside mpfr */
#define mp_realfunc2_div_2si 21  /* needs to be implemented outside mpfr */



 /* 2 integer arguments ( both ui), returns 1 real result */
    /* BEGIN: ONLY REAL */
#define mp_realfunc2_bin_ui_ui 1
#define mp_realfunc2_pow_ui_ui 2  /* needs to be implemented poperly in and outside mpfr */

    /* BEGIN: ONLY REAL */


/* 2 arguments (first real, second integer), returns 2 results */
#define mp_realfunc2_rising2_ui 1
#define mp_realfunc2_chebyt2_ui 2
#define mp_realfunc2_chebyu2_ui 3


/* 2 real arguments, returns 2 real results */
    /* BEGIN: ONLY REAL */
#define mp_realfunc2_remquo 802
#define mp_realfunc2_fmodquo 803
    /* BEGIN: ONLY REAL */
#define mp_realfunc2_bessel_jy 1



/* 3 real arguments, returns 1 real result */
#define mp_realfunc3_hyperu 1
#define mp_realfunc3_hyp1f1 2
#define mp_realfunc3_hyp1f1r 3

#define mp_realfunc3_gegenbauerc 4
#define mp_realfunc3_laguerrel 5
#define mp_realfunc3_legenp 6
#define mp_realfunc3_legenpv 7
#define mp_realfunc3_legenq 8
#define mp_realfunc3_legenqv 9

#define mp_realfunc3_beta_lower 10
#define mp_realfunc3_beta_lower_r 11


#define mp_realfunc3_ibeta_derivative 20
#define mp_realfunc3_ibeta 21
#define mp_realfunc3_ibetac 22


#define mp_realfunc3_ibeta_non_normalized 23
#define mp_realfunc3_ibetac_non_normalized 24
#define mp_realfunc3_ibeta_inv 25
#define mp_realfunc3_ibetac_inv 26
#define mp_realfunc3_ibeta_inva 27
#define mp_realfunc3_ibetac_inva 28
#define mp_realfunc3_ibeta_invb 29
#define mp_realfunc3_ibetac_invb 30

#define mp_realfunc3_legendre_p_m 50
#define mp_realfunc3_laguerre_m 51

#define mp_realfunc3_ellint_rf 60
#define mp_realfunc3_ellint_rd 61
#define mp_realfunc3_ellint_3_F 62

#define mp_realfunc3_Bernoullidist 70
#define mp_realfunc3_Cdist 71
#define mp_realfunc3_Exponentialdist 72
#define mp_realfunc3_Geometricdist 73
#define mp_realfunc3_Poissondist 74
#define mp_realfunc3_Rayleighdist 75
#define mp_realfunc3_Tdist 76


#define mp_realfunc3_fma 800
#define mp_realfunc3_fms 801



#define mp_realfunc3_elliptic_pi_inc 1001  //no special code for real argument
#define mp_realfunc3_elliptic_rf 1002  //no special code for real argument
#define mp_realfunc3_elliptic_rg 1003  //no special code for real argument
#define mp_realfunc3_elliptic_rd 1004  //no special code for real argument



/* 4 real arguments, returns 1 real result */
#define mp_realfunc4_hyp2f1 1
#define mp_realfunc4_hyp2f1r 2
#define mp_realfunc4_jacobip 3

#define mp_realfunc4_hyp1f2 4
#define mp_realfunc4_hyp1f2r 5

#define mp_realfunc4_legendre_next 10
#define mp_realfunc4_laguerre_next 11
#define mp_realfunc4_hermite_next 12

#define mp_realfunc4_spherical_harmonic_r 13
#define mp_realfunc4_spherical_harmonic_i 14

#define mp_realfunc4_ellint_rj 15


#define mp_realfunc4_Betadist 50
#define mp_realfunc4_Binomialdist 51
#define mp_realfunc4_Cauchydist 52
#define mp_realfunc4_Extreme_valuedist 53
#define mp_realfunc4_Fdist 54
#define mp_realfunc4_Gammadist 55
#define mp_realfunc4_inversechisquareddist 56
#define mp_realfunc4_Inversegammadist 57
#define mp_realfunc4_Inversegaussiandist 58
#define mp_realfunc4_Laplacedist 59
#define mp_realfunc4_Logisticdist 60
#define mp_realfunc4_Lognormaldist 61
#define mp_realfunc4_Negative_Binomialdist 62
#define mp_realfunc4_Ndist 63
#define mp_realfunc4_paretodist 64
#define mp_realfunc4_Weibulldist 65
#define mp_realfunc4_UniformSmallIntdist 66
#define mp_realfunc4_UniformIntdist 67
#define mp_realfunc4_Uniformdist 68
#define mp_realfunc4_Cdistn 69
#define mp_realfunc4_Tdistn 70



#define mp_realfunc4_elliptic_rj 1001  //no special code for real argument



/* 5 real arguments, returns 1 real result */
#define mp_realfunc5_legendre_next_m 1
#define mp_realfunc5_laguerre_next_m 2

#define mp_realfunc5_Hypergeometricdist 150
#define mp_realfunc5_Triangulardist 151
#define mp_realfunc5_Fdistn 152
#define mp_realfunc5_Betadistn 153
#define mp_realfunc5_Skewnormaldist 154


/* output of statistical distributions */
#define mp_const_pdf 1
#define mp_const_cdf_P 2
#define mp_const_cdf_Q 3
#define mp_const_cdf_Hazard 4
#define mp_const_cdf_CHF 5
#define mp_const_cdf_Pinv 6
#define mp_const_cdf_Qinv 7
#define mp_const_cdf_Mean 8
#define mp_const_cdf_Median 9
#define mp_const_cdf_Mode 10
#define mp_const_cdf_Variance 11
#define mp_const_cdf_Stdev 12
#define mp_const_cdf_Skewness 13
#define mp_const_cdf_Kurtosis 14
#define mp_const_cdf_KurtosisExcess 15















/* generators of random numbers */

#define mp_random_taus88 0
#define mp_random_mt19937 1
#define mp_random_lagged_fibonacci44497 2
#define mp_random_ranlux4 3

/* matrix conversions*/
#define mp_conv_mat_dense_from_dense 1
#define mp_conv_poly_from_poly 2
#define mp_conv_mat_from_poly 3
#define mp_conv_poly_from_mat 4

#define mp_conv_mat_set_real_part_in_complex 5
#define mp_conv_mat_get_real_part_from_complex 6

#define mp_conv_mat_set_imag_part_in_complex 7
#define mp_conv_mat_get_imag_part_from_complex 8

#define mp_conv_mat_sparse_from_dense 9
#define mp_conv_mat_dense_from_sparse 10
#define mp_conv_mat_tripletlist_from_sparse 11



/* matrix complex-real conversions*/


#define mp_conv_set_real_to_complex_arb 310
#define mp_conv_get_real_from_complex_arb 311

#define mp_conv_set_imag_to_complex_arb 320
#define mp_conv_get_imag_from_complex_arb 321


#define mp_conv_set_real_to_complex_mpfr 330
#define mp_conv_get_real_from_complex_mpfr 331

#define mp_conv_set_imag_to_complex_mpfr 340
#define mp_conv_get_imag_from_complex_mpfr 341


#define mp_conv_set_real_to_complex_dbl 350
#define mp_conv_get_real_from_complex_dbl 351

#define mp_conv_set_imag_to_complex_dbl 360
#define mp_conv_get_imag_from_complex_dbl 361



/* matrix housekeeping functions*/
#define mp_const_fullcopy 0
#define mp_const_block 1
#define mp_const_topLeftCorner 2
#define mp_const_bottomLeftCorner 3
#define mp_const_topRightCorner 4
#define mp_const_bottomRightCorner 5
#define mp_const_topRows 6
#define mp_const_bottomRows 7
#define mp_const_leftCols 8
#define mp_const_rightCols 9
#define mp_const_diagonal 10
#define mp_const_middleRows 11
#define mp_const_middleCols 12
#define mp_const_triangularView 13
#define mp_const_fullnegcopy 14

#define mp_const_Upper 1
#define mp_const_Lower 2
#define mp_const_StrictlyUpper 3
#define mp_const_StrictlyLower 4
#define mp_const_UnitUpper 5
#define mp_const_UnitLower 6


#define mp_const_size 1
#define mp_const_rows 2
#define mp_const_cols 3


#define mp_setZero 1
#define mp_setOnes 2
#define mp_setIdentity 3
#define mp_setRandom 4
#define mp_transposeInPlace 5
#define mp_reverseInPlace 6
#define mp_Resize 7
#define mp_conservativeResize 8
#define mp_setRandom_nm 9
#define mp_FillLinear 10
#define mp_setNan 11
#define mp_setInfinity 12
#define mp_setMinusInfinity 13
#define mp_setMinusZero 14
#define mp_setRandomSymmetric 15
#define mp_setRandomSA 16
#define mp_setRandomSAPosDef 17


#define mp_asDiagonal 1
#define mp_adjoint 2
#define mp_conjugate 3
#define mp_transpose 4
#define mp_reverse 5
#define mp_replicate 6
#define mp_ResizeLike 7
#define mp_RandomMatrix 8
#define mp_RandomSymmetricMatrix 9


#define mp_const_full_matrix 1
#define mp_const_rowwise 2
#define mp_const_colwise 3



#define mp_const_plus 1
#define mp_const_minus 2
#define mp_const_cwiseProduct 3
#define mp_const_cwiseQuotient 4
#define mp_const_MatrixProduct 5
#define mp_const_DotProduct 6

#define mp_const_plus_scalar 7
#define mp_const_minus_scalar 8
#define mp_const_times_scalar 9
#define mp_const_div_scalar 10

#define mp_mat_det 11
#define mp_mat_rcond 12
#define mp_mat_inverse 13
#define mp_mat_solve 14


#define mp_const_concat_horizontal 20
#define mp_const_concat_vertical 21

#define mp_const_diag_prod_left 30
#define mp_const_diag_prod_right 31

#define mp_const_sa_lower_prod_left 32
#define mp_const_sa_lower_prod_right 33
#define mp_const_sa_upper_prod_left 34
#define mp_const_sa_upper_prod_right 35


#define mp_const_lower_tria_prod_left 36
#define mp_const_lower_tria_prod_right 37
#define mp_const_upper_tria_prod_left 38
#define mp_const_upper_tria_prod_right 39

#define mp_const_strictly_lower_tria_prod_left 40
#define mp_const_strictly_lower_tria_prod_right 41
#define mp_const_strictly_upper_tria_prod_left 42
#define mp_const_strictly_upper_tria_prod_right 43

#define mp_const_unit_lower_tria_prod_left 44
#define mp_const_unit_lower_tria_prod_right 45
#define mp_const_unit_upper_tria_prod_left 46
#define mp_const_unit_upper_tria_prod_right 47


#define mp_const_lower_tria_solve 50
#define mp_const_upper_tria_solve 51
#define mp_const_unit_lower_tria_solve 52
#define mp_const_unit_upper_tria_solve 53

#define mp_const_variance 100
#define mp_const_stdev 101
#define mp_const_centered 102
#define mp_const_standardized 103
#define mp_const_covariance 104
#define mp_const_correlation 105
#define mp_const_crossproducts 106
#define mp_const_A_S_AT 107
#define mp_const_SYR2K 108



#define mp_const_GT 1
#define mp_const_LT 2
#define mp_const_LE 3
#define mp_const_GE 4
#define mp_const_EQ 5
#define mp_const_NE 6

#define mp_const_All 1
#define mp_const_Any 2
#define mp_const_Count 3


#define mp_const_minCoeff_Index 1
#define mp_const_maxCoeff_Index 2


#define mp_const_sum 1
#define mp_const_prod 2
#define mp_const_mean 3
#define mp_const_minCoeff 4
#define mp_const_maxCoeff 5
#define mp_const_squaredNorm 6
#define mp_const_Norm 7
#define mp_const_stableNorm 8
#define mp_const_lpNorm1 9
#define mp_const_lpNormInf 10



/* BLAS support*/
#define mp_gemm 1
#define mp_symm 2
#define mp_hemm 3
#define mp_trmm 4
#define mp_trsm 5
#define mp_syrk 6
#define mp_herk 7
#define mp_syr2k 8
#define mp_her2k 9

#define mp_symm_hemm 10
#define mp_syrk_herk 11
#define mp_syr2k_her2k 12


/* basic linear algebra */
#define mp_linalg_solve 1
#define mp_linalg_det 2
#define mp_linalg_inverse 3
#define mp_linalg_rank 4
#define mp_linalg_charpol 5
#define mp_linalg_trace 6
#define mp_linalg_exp 7
#define mp_linalg_mul 8


/* sparse eigenvalues */
#define mp_spectra_sym 1
#define mp_spectra_symshift 2
#define mp_spectra_gen 3


/* linear decompositions*/
#define mp_lu 1
#define mp_partialPivLu 2
#define mp_fullPivLu 3
#define mp_householderQr 4
#define mp_colPivHouseholderQr 5
#define mp_fullPivHouseholderQr 6
#define mp_llt 7
#define mp_ldlt 8
#define mp_jacobiSvd 9
#define mp_CG_Solver 10
#define mp_LSCG_Solver 11
#define mp_BiCGSTAB_Solver 12
#define mp_COD 13
#define mp_jacobiSvdThin 14
#define mp_jacobiSvdFull 15


/* helper decompositions*/
#define mp_hessenberg 100
#define mp_schur 101
#define mp_realQZ 102
#define mp_tridiag 103

#define mp_SelfAdjointEigenValuesFromTridiag 104
#define mp_SelfAdjointEigenSystemFromTridiag 105
#define mp_SelfAdjointEigenValues 106
#define mp_SelfAdjointEigenSystem 107

#define mp_GeneralizedSelfAdjointEigenValues 108
#define mp_GeneralizedSelfAdjointEigenSolver 109

#define mp_EigenValues 110
#define mp_EigenSystem 111

#define mp_EigenValuesFromRealInput 112
#define mp_EigenSystemFromRealInput 113

#define mp_PseudoEigenSystem 115

#define mp_GeneralizedEigenValuesFromRealInput 116
#define mp_GeneralizedEigenSystemFromRealInput 117






/* functions of matrix arguments*/
#define mp_matrix_exp 0
#define mp_matrix_sin 1
#define mp_matrix_cos 2
#define mp_matrix_sinh 3
#define mp_matrix_cosh 4
#define mp_matrix_sqrt 5
#define mp_matrix_log 6
#define mp_matrix_pow 7

/* matrix cppoptlib functions*/
#define mp_bfgs_solver 0
#define mp_cma_es_solver 1
#define mp_conjugated_gradient_descent_solver 2
#define mp_gradient_descent_solver 3
#define mp_lbfgs_b_solver 4
#define mp_lbfgs_solver 5
#define mp_nelder_mead_solver 6
#define mp_newton_descent_solver 7


/* polynomial functions*/

/* 1 poly input, inplace */
#define mp_poly_normalize 0

#define mp_poly_length 1
#define mp_poly_degree 2


/* 1 poly input, 1 poly output */

#define mp_poly_set_coeff 3
#define mp_poly_get_coeff 6

#define mp_poly_set 8
#define mp_poly_neg 10




/* 2 inputs (1 poly, 1 integer), 1 poly output */
#define mp_poly_shift_left 11
#define mp_poly_shift_right 12
#define mp_poly_inv_series 13
#define mp_poly_revert_series 14
#define mp_poly_resize 15
#define mp_poly_truncate 16
#define mp_poly_majorant 17




/* 2 inputs (1 poly, 1 scalar), 1 poly output */

#define mp_poly_randtest 21

#define mp_poly_scalar_mul 22
#define mp_poly_scalar_div 23
#define mp_poly_pow_ui 24
#define mp_poly_taylor_shift 25

#define mp_poly_swap 26
#define mp_poly_equal 27


/* 2 poly inputs, 1 poly output */
#define mp_poly_add 30
#define mp_poly_sub 31
#define mp_poly_mul 32
#define mp_poly_div 33

#define mp_poly_compose 34
#define mp_poly_product_roots 35
#define mp_poly_derivative 36
#define mp_poly_integral 37

#define mp_poly_mul_classical 38
#define mp_poly_mul_KS 39
#define mp_poly_mul_SS 40

#define mp_poly_evaluate 41
#define mp_poly_evaluate2 42
#define mp_poly_evaluate_vec_iter 43
#define mp_poly_evaluate_vec_fast 44

#define mp_poly_find_roots 45

#define mp_poly_interpolate_newton 46
#define mp_poly_interpolate_barycentric 47
#define mp_poly_interpolate_fast 48

#define mp_poly_borel_transform 49
#define mp_poly_inv_borel_transform 50

#define mp_poly_fmpz_interpolate_fmpz_vec 51
#define mp_poly_fmpq_interpolate_fmpz_vec 52


/* 3 inputs(2 poly, 1 integer) , 1 poly output */

#define mp_poly_add_series 60
#define mp_poly_sub_series 61
#define mp_poly_mul_series 62
#define mp_poly_div_series 63

#define mp_poly_compose_series 55



/* 2 poly inputs, 2 poly output */
#define mp_poly_div_rem 70



