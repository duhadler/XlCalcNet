
#ifdef Use_Float128
#include <boost/multiprecision/float128.hpp>
#endif

#ifdef Use_BinOct
#include <boost/multiprecision/cpp_bin_float.hpp>
#endif

#ifdef Use_Dec128
#include <boost/decimal.hpp>
#endif

#ifdef Use_Dec50
#include <boost/multiprecision/cpp_dec_float.hpp>
#endif

#ifdef Use_Mpfr
#include <boost/multiprecision/mpfr.hpp>
#endif


#include <mp_BoostEigenConstants.h>
#include "stdint.h"
#include <complex>
#include <vector>
#include <Eigen/Dense>
#include <Eigen/Eigenvalues>
#include <Eigen/Sparse>

using namespace Eigen;
using namespace std;



typedef map<string, void*>* mpmapPtr;


#ifndef mpType
    #define mpType
#endif // mpType



#ifdef Use_Single
    #undef mpType
    #define mpType float
#endif // Use_Single



#ifdef Use_Double
    #undef mpType
    #define mpType double
#endif // Use_Double



#ifdef Use_LongDouble
    #undef mpType
    #define mpType long double
#endif // Use_LongDouble



#ifdef Use_Float128
    #undef mpType
    #define mpType boost::multiprecision::float128
#endif // Use_Float128



#ifdef Use_BinOct
    #undef mpType
    #define mpType boost::multiprecision::cpp_bin_float_oct
#endif // Use_BinOct




#ifdef Use_Dec50
    #undef mpType
    #define mpType boost::multiprecision::cpp_dec_float_50
#endif // Use_Dec50



#ifdef Use_Mpfr
    #undef mpType
    #define mpType boost::multiprecision::mpfr_float
#endif // Use_Mpfr


#ifdef Use_MpAny
#include "MpAnyEigen.h"
#undef mpType
#define mpType mpAny::mpscalar
#endif // Use_MpAny


typedef void(*AnyFuncPtr) (const void*,const  void*);
typedef void(*AnyFuncPtr3) (const void*,const  void*,const  void*);

typedef void(*AnyFuncPtrInt32) (const void*,const  void*, const int32_t);

typedef complex<mpType>  cplx_mpType ;


typedef Matrix<mpType,Dynamic,1>  mpVector;
typedef Matrix<mpType, 1, Dynamic>  mpRowVector;
typedef Matrix<complex<mpType>,Dynamic,1>  mpVectorC;

typedef mpVector* mpVectorPtr;
typedef mpRowVector* mpRowVectorPtr;
typedef mpVectorC* mpCplxVectorPtr;


typedef Matrix<mpType,Dynamic,Dynamic>  mpMatrix;
typedef Matrix<complex<mpType>,Dynamic,Dynamic>  mpMatrixC;

typedef mpMatrix* mpMatrixPtr;
typedef mpMatrixC* mpCplxMatrixPtr;



typedef SparseVector<mpType>  mpSparseVector;
typedef SparseVector<complex<mpType>>  mpSparseVectorC;

typedef mpSparseVector* mpSparseVectorPtr;
typedef mpSparseVectorC* mpCplxSparseVectorPtr;


typedef SparseMatrix<mpType>  mpSparseMatrix;
typedef SparseMatrix<complex<mpType>>  mpSparseMatrixC;

typedef mpSparseMatrix* mpSparseMatrixPtr;
typedef mpSparseMatrixC* mpCplxSparseMatrixPtr;


vector<string> split(const string &s, char delim);
string removeSpaces(string str);
string getresultstring(int32_t what);


