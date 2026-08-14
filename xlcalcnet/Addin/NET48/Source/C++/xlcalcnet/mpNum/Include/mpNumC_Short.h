//#pragma once
//
//
//#ifndef MPNUMC_SHORT_H_INCLUDED
//#define MPNUMC_SHORT_H_INCLUDED
//
//#include <stdint.h>
//#include <mp_BoostEigenConstants.h>
//
//typedef void* AnyPtr;
//
//typedef const void* FuncPtr;
//
//typedef const void* ScalarPtr;
//typedef void* ScalarResPtr;
//typedef void* MapPtr;
//
//typedef void* mpNumMatrixPtr;
//typedef void* GmpRandPtr;
//
//typedef void* DblPtr;
//typedef void* ExtPtr;
//typedef void* QuadPtr;;
//typedef void* DRealPtr;;
//
//typedef void* CplxPtr;
//
//
//typedef void* MpfrPtr;
//typedef void* MpfcPtr;
//
//typedef void* MpfiPtr;
//typedef void* MpciPtr;
//
//
//typedef void* DecrPtr;
//typedef void* DeccPtr;
//
//typedef void* FlintRandPtr;
//typedef void* FmpzPtr;
//typedef void* FmpqPtr;
//
//typedef void* MpdPtr;
//
//typedef void* ArfPtr;
//typedef void* AcfPtr;
//
//typedef void* ArbPtr;
//typedef void* AcbPtr;
//
//typedef void* FmpzMatPtr;
//typedef void* FmpqMatPtr;
//typedef void* ArbMatPtr;
//typedef void* AcbMatPtr;
//
//typedef void* FmpzPolyPtr;
//typedef void* FmpqPolyPtr;
//typedef void* ArbPolyPtr;
//typedef void* AcbPolyPtr;
//
//typedef void* FmpzPoly2Ptr;
//typedef void* FmpqPoly2Ptr;
//typedef void* ArbPoly2Ptr;
//typedef void* AcbPoly2Ptr;
//typedef void* MpfrPoly2Ptr;
//typedef void* MpfrPoly2Ptr;
//
//
//#define MPNUMC_DLL_IMPORTEXPORT
//
//#ifndef _WIN32
//    #define __cdecl
//#endif
//
//
//#ifdef _WIN32
//
//    #if defined (BUILD_MPNUMC_DLL)
//        #undef MPNUMC_DLL_IMPORTEXPORT
//        #define MPNUMC_DLL_IMPORTEXPORT __declspec( dllexport )
//    #elif defined (USE_MPNUMC_DLL)
//        #undef MPNUMC_DLL_IMPORTEXPORT
//        #define MPNUMC_DLL_IMPORTEXPORT __declspec( dllimport )
//    #endif
//
//#endif
//
//
//
//#ifdef __cplusplus
//extern "C"
//{
//#endif
//
//#include "mpNumC_FReal.h"
//
//#include "mpNumC_Scalar.h"
//#include "mpNumC_Polynomials.h"
//#include "mpNumC_Mpfr.h"
//#include "mpNumC_Mpfi.h"
//
//#include "mpNumC_Arb.h"
//
//
//#ifdef __cplusplus
//}
//#endif
//
//
//#endif // MPNUMC_SHORT_H_INCLUDED
