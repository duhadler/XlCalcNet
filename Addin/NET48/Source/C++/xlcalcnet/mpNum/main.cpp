////#include "stdafx.h"
//
//
//#include "stdint.h"
//#include <complex>
//#include <vector>
//#include <iostream>
//#include <limits>
//#include <string>
//
//#include <mp_BoostEigenConstants.h>
//#include <mpNumC_Short.h>
//#include <mpNumC_Scalar.h>
//#include "Helperfunctions.h"
////#include <quadmath.h>
//
//#include <chrono>
//#include <thread>
//
//void f()
//{
//    std::this_thread::sleep_for(std::chrono::seconds(1));
//}
//
//
//
//int main()
//{
//
//
//	std::cout << "Hello World!\n";
//    std::string str ("Test string");
//    std::cout << "max_size: " << str.max_size() << "\n";	double x, Result;
//	std::cout.precision(std::numeric_limits<double>::digits10);
//	std::cout << std::scientific << std::showpoint; // Append any trailing zeros.
//
//
//	int32_t what, wp;
//	wp = 53;
//	what = mp_realfunc1_exp;
//	x = 1.0;
//    Lib_Scalar_func1(mp_xrf, &Result, what, wp, &x);
//    std::cout << "Result: " << Result << std::endl;
//
//
//    /********************* matrix xrf**************************/
//
//    auto t1a = std::chrono::high_resolution_clock::now();
//
//	//double Coeff;
//
//	int32_t mpCat, mpType;
//	mpCat = mp_eigen;
//	mpType = mp_xrf;
//    mpNumMatrixPtr matA = Lib_Init_Func(mpCat, mpType);
//    mpNumMatrixPtr matB = Lib_Init_Func(mpCat, mpType);
//    mpNumMatrixPtr matC = Lib_Init_Func(mpCat, mpType);
//
//
//    int m = 400;
//    int n = m;
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matA, mp_setRandom_nm, m, n);
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matB, mp_setRandom_nm, m, n);
//
//    Lib_Eigen_BasicArithmetic(mpCat, mpType, matC, mp_const_MatrixProduct, matA, matB);
//
//
////    int row = 0;
////    int col = 0;
////    for (row = 0; row < m; row++) {
////        for (col = 0; col < n; col++) {
////            Lib_Eigen_GetCoeff_(mpType, &Coeff, row, col, matA);
////            std::cout << "Coeff(" << row << ", " << col << "): " << Coeff << std::endl;
////        }
////    }
//
//    Lib_Clear(mpCat, mpType, matA);
//    Lib_Clear(mpCat, mpType, matB);
//    Lib_Clear(mpCat, mpType, matC);
//
//    auto t2a = std::chrono::high_resolution_clock::now();
//    std::cout << "f() took "
//              << std::chrono::duration_cast<std::chrono::milliseconds>(t2a-t1a).count()
//              << " milliseconds\n";
//
//
//
//
//    /********************* matrix ext **************************/
//
//    auto t1b = std::chrono::high_resolution_clock::now();
//
//
//    std::cout << "\n\nmatrix extended" << std::endl;
//    std::cout << "sizeof(long double)" << sizeof(long double) << std::endl;
//    std::cout.precision(std::numeric_limits<long double>::digits10);
//
//
//	//long double CoeffExt = 1.1;
//
//	mpCat = mp_eigen;
//	mpType = mp_ext;
//    matA = Lib_Init_Func(mpCat, mpType);
//    matB = Lib_Init_Func(mpCat, mpType);
//    matC = Lib_Init_Func(mpCat, mpType);
//
//
////    m = 400;
////    n = 400;
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matA, mp_setRandom_nm, m, n);
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matB, mp_setRandom_nm, m, n);
//
//    Lib_Eigen_BasicArithmetic(mpCat, mpType, matC, mp_const_MatrixProduct, matA, matB);
//
//
//
////    row = 0;
////    col = 0;
////    for (row = 0; row < m; row++) {
////        for (col = 0; col < n; col++) {
////            Lib_Eigen_GetCoeff_(mpType, &CoeffExt, row, col, matA);
////            std::cout << "Coeff(" << row << ", " << col << "): " << CoeffExt << std::endl;
////        }
////    }
//
//    Lib_Clear(mpCat, mpType, matA);
//    Lib_Clear(mpCat, mpType, matB);
//    Lib_Clear(mpCat, mpType, matC);
//
//    auto t2b = std::chrono::high_resolution_clock::now();
//    std::cout << "f() took "
//              << std::chrono::duration_cast<std::chrono::milliseconds>(t2b-t1b).count()
//              << " milliseconds\n";
//
//
//
//
//
//    /********************* matrix quad **************************/
//
//    auto t1c = std::chrono::high_resolution_clock::now();
//
//
//    std::cout << "\n\nmatrix quad" << std::endl;
//    std::cout << "sizeof(__float128)" << sizeof(__float128) << std::endl;
//    std::cout.precision(std::numeric_limits<__float128>::digits10);
//
//
//	//__float128 CoeffQuad = 1.1;
//
//	mpCat = mp_eigen;
//	mpType = mp_quad;
//    matA = Lib_Init_Func(mpCat, mpType);
//    matB = Lib_Init_Func(mpCat, mpType);
//    matC = Lib_Init_Func(mpCat, mpType);
//
//
////    m = 400;
////    n = 400;
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matA, mp_setRandom_nm, m, n);
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matB, mp_setRandom_nm, m, n);
//
//    Lib_Eigen_BasicArithmetic(mpCat, mpType, matC, mp_const_MatrixProduct, matA, matB);
//
//
////    row = 0;
////    col = 0;
////    int width = 46;
////    char buf[128];
////
////    for (row = 0; row < m; row++) {
////        for (col = 0; col < n; col++) {
////            Lib_Eigen_GetCoeff_(mpType, &CoeffQuad, row, col, matA);
////            quadmath_snprintf (buf, sizeof buf, "%+-#*.32Qe", width, CoeffQuad);
////            std::cout << "Coeff(" << row << ", " << col << "): " << buf << std::endl;
////        }
////    }
//
//    Lib_Clear(mpCat, mpType, matA);
//    Lib_Clear(mpCat, mpType, matB);
//    Lib_Clear(mpCat, mpType, matC);
//
//    auto t2c = std::chrono::high_resolution_clock::now();
//    std::cout << "f() took "
//              << std::chrono::duration_cast<std::chrono::milliseconds>(t2c-t1c).count()
//              << " milliseconds\n";
//
//
//
//
//    /********************* matrix mpfr **************************/
//
//    auto t1d = std::chrono::high_resolution_clock::now();
//
//    std::cout << "\n\nmatrix mpfr, prec = 113 bits" << std::endl;
//    std::cout << "sizeof(mpfr_t)" << sizeof(mpfr_t) << std::endl;
////    std::cout << "sizeof(mpfi_t)" << sizeof(mpfi_t) << std::endl;
//    std::cout << "sizeof(arb_t)" << sizeof(arb_t) << std::endl;
//    std::cout << "sizeof(fmpz_t)" << sizeof(fmpz_t) << std::endl;
//    std::cout << "sizeof(fmpq_t)" << sizeof(fmpq_t) << std::endl;
//
//	//int32_t mpCat, mpType;
//	mpCat = mp_eigen;
//	mpType = mp_mprf;
//
//	Lib_Set_Default(mp_default_prec, 113);
//	//Lib_Set_Default(mp_default_prec, 80);
//
//    matA = Lib_Init_Func(mpCat, mpType);
//    matB = Lib_Init_Func(mpCat, mpType);
//    matC = Lib_Init_Func(mpCat, mpType);
//
////    m = 400;
////    n = 400;
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matA, mp_setRandom_nm, m, n);
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matB, mp_setRandom_nm, m, n);
//
//    Lib_Eigen_BasicArithmetic(mpCat, mpType, matC, mp_const_MatrixProduct, matA, matB);
//
//
//
////    row = 0;
////    col = 0;
////    mpfr_t mpfr_coeff; mpfr_init(mpfr_coeff);
////    for (row = 0; row < m; row++) {
////        for (col = 0; col < n; col++) {
////            Lib_Eigen_GetCoeff_(mpType, mpfr_coeff, row, col, matA);
////            //Lib_Basic_Scalar_Str_Extern(mp_mprf, "%.RE", 200, 0, mpfr_coeff);
////            char* str1 = Lib_Basic_Scalar_Str_Extern(mp_mprf, "%.RE", 60, 0, mpfr_coeff);
////            std::cout << "Coeff(" << row << ", " << col << "): "<< str1 << std::endl;
////        }
////    }
//
//    Lib_Clear(mpCat, mpType, matA);
//    Lib_Clear(mpCat, mpType, matB);
//    Lib_Clear(mpCat, mpType, matC);
//
//    auto t2d = std::chrono::high_resolution_clock::now();
//    std::cout << "f() took "
//              << std::chrono::duration_cast<std::chrono::milliseconds>(t2d-t1d).count()
//              << " milliseconds\n";
//
//
//
//
//
//    /********************* matrix mpfr **************************/
//
//    auto t1e = std::chrono::high_resolution_clock::now();
//
//    std::cout << "\n\nmatrix mpfr, prec = 64 bits" << std::endl;
//    std::cout << "sizeof(mpfr_t)" << sizeof(mpfr_t) << std::endl;
////    std::cout << "sizeof(mpfi_t)" << sizeof(mpfi_t) << std::endl;
//    std::cout << "sizeof(arb_t)" << sizeof(arb_t) << std::endl;
//    std::cout << "sizeof(fmpz_t)" << sizeof(fmpz_t) << std::endl;
//    std::cout << "sizeof(fmpq_t)" << sizeof(fmpq_t) << std::endl;
//
//	//int32_t mpCat, mpType;
//	mpCat = mp_eigen;
//	mpType = mp_mprf;
//
//	//Lib_Set_Default(mp_default_prec, 127);
//	Lib_Set_Default(mp_default_prec, 127);
//
//    matA = Lib_Init_Func(mpCat, mpType);
//    matB = Lib_Init_Func(mpCat, mpType);
//    matC = Lib_Init_Func(mpCat, mpType);
//
////    m = 400;
////    n = 400;
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matA, mp_setRandom_nm, m, n);
//    Lib_Eigen_SetSpecialValue(mpCat, mpType, matB, mp_setRandom_nm, m, n);
//
//    Lib_Eigen_BasicArithmetic(mpCat, mpType, matC, mp_const_MatrixProduct, matA, matB);
//
//
//
////    row = 0;
////    col = 0;
////    mpfr_t mpfr_coeff; mpfr_init(mpfr_coeff);
////    for (row = 0; row < m; row++) {
////        for (col = 0; col < n; col++) {
////            Lib_Eigen_GetCoeff_(mpType, mpfr_coeff, row, col, matA);
////            //Lib_Basic_Scalar_Str_Extern(mp_mprf, "%.RE", 200, 0, mpfr_coeff);
////            char* str1 = Lib_Basic_Scalar_Str_Extern(mp_mprf, "%.RE", 60, 0, mpfr_coeff);
////            std::cout << "Coeff(" << row << ", " << col << "): "<< str1 << std::endl;
////        }
////    }
//
//    Lib_Clear(mpCat, mpType, matA);
//    Lib_Clear(mpCat, mpType, matB);
//    Lib_Clear(mpCat, mpType, matC);
//
//    auto t2e = std::chrono::high_resolution_clock::now();
//    std::cout << "f() took "
//              << std::chrono::duration_cast<std::chrono::milliseconds>(t2e-t1e).count()
//              << " milliseconds\n";
//
//
//
//
//}
