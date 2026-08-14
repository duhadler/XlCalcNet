#pragma once

#ifndef MPNUMC_H_INCLUDED
#define MPNUMC_H_INCLUDED

#include <stdint.h>


typedef void* AnyPtr;

typedef const void* FuncPtr;

typedef const void* ScalarPtr;
typedef void* ScalarResPtr;
typedef void* MapPtr;

typedef void* mpNumMatrixPtr;

typedef void* DblPtr;
typedef void* ExtPtr;
typedef void* QuadPtr;;



typedef void* SRealPtr;;
typedef void* SCplxPtr;;

typedef void* FRealPtr;;
typedef void* FCplxPtr;


typedef void* XRealPtr;;
typedef void* XCplxPtr;;

typedef void* QRealPtr;;
typedef void* QCplxPtr;;


typedef void* ORealPtr;;
typedef void* OCplxPtr;;

typedef void* MpdPtr;
typedef void* MpdcPtr;



typedef void* CplxPtr;



#define MPNUMC_DLL_IMPORTEXPORT

#ifndef _WIN32
    #define __cdecl
#endif


#ifdef _WIN32

    #if defined (BUILD_MPNUMC_DLL)
        #undef MPNUMC_DLL_IMPORTEXPORT
        #define MPNUMC_DLL_IMPORTEXPORT __declspec( dllexport )
    #elif defined (USE_MPNUMC_DLL)
        #undef MPNUMC_DLL_IMPORTEXPORT
        #define MPNUMC_DLL_IMPORTEXPORT __declspec( dllimport )
    #endif

#endif



#ifdef __cplusplus
extern "C"
{
#endif





#include "mpNumC_Double.h"

#include "mpNumC_EigenFReal.h"

#include "mpNumC_EigenOReal.h"

#include "mpNumC_EigenQReal.h"

#include "mpNumC_EigenSReal.h"

#include "mpNumC_EigenXReal.h"


#include "mpNumC_FReal.h"

#include "mpNumC_OReal.h"

#include "mpNumC_QReal.h"

#include "mpNumC_SReal.h"

#include "mpNumC_XReal.h"

#include "mpNumC_XSF.h"


#ifdef __cplusplus
}
#endif


#endif // MPNUM_H_INCLUDED
