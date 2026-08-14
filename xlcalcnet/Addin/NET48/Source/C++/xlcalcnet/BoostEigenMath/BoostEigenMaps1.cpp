

#include "libBoostEigenDense.h"

#include <stdlib.h>
#include <string>
#include <complex>
#include <sstream>
#include <algorithm>
#include <map>
#include <iostream>
#include <vector>
#include <iterator>



using namespace std;




/******************** maps1 ***************************/


template<typename Out>
void split(const string &s, char delim, Out result) {
    stringstream ss(s);
    string item;
    while (getline(ss, item, delim)) {
        *(result++) = item;
    }
}


vector<string> split(const string &s, char delim)
 {
    vector<string> elems;
    split(s, delim, back_inserter(elems));
    return elems;
}



string removeSpaces(string str)
{
    str.erase(remove(str.begin(), str.end(), ' '), str.end());
    transform(str.begin(), str.end(), str.begin(), ::tolower);
    return str;
}

string getresultstring(int32_t what)
{
    switch (what) {
        case mp_llt: return "info;rcond;l;u;x;inverse;"; break;
        case mp_ldlt: return "info;rcond;l;u;d;p;ispos;isneg;x;inverse;"; break;

        case mp_partialPivLu: return "rcond;lu;p;det;x;inverse;"; break;
        case mp_fullPivLu: return "rcond;lu;p;q;isinjective;isinvertible;issurjective;det;x;inverse;"; break;

        case mp_householderQr: return "qr;absdet;logabsdet;x;inverse;"; break;
        case mp_colPivHouseholderQr: return "info;dimofkernel;rank;nonzeropivots;qr;r;householderq;hqnonzeros;permcols;isinjective;isinvertible;issurjective;absdet;logabsdet;maxpivot;x;inverse;"; break;
        case mp_fullPivHouseholderQr: return "dimofkernel;rank;nonzeropivots;qr;q;permcols;isinjective;isinvertible;issurjective;absdet;logabsdet;maxpivot;x;inverse;"; break;
        case mp_COD: return "info;dimofkernel;rank;nonzeropivots;qtz;t;z;householderq;hqnonzeros;isinjective;isinvertible;issurjective;absdet;logabsdet;maxpivot;x;pseudoinverse;"; break;

        case mp_jacobiSvd: return "rank;nonzeros;s;splus;absdet;logabsdet;"; break;
        case mp_jacobiSvdThin: return "rank;nonzeros;s;u;v;x;pseudoinverse;splus;"; break;
        case mp_jacobiSvdFull: return "rank;nonzeros;s;u;v;x;pseudoinverse;splus;"; break;

        case mp_tridiag: return "q;t;hcoeff;packed;diag;subdiag;"; break;
        case mp_hessenberg: return "h;q;hcoeff;packed;"; break;
        case mp_schur: return "u;t;"; break;
        case mp_realQZ: return "s;t;q;z;"; break;

        case mp_SelfAdjointEigenValuesFromTridiag: return "eval;"; break;
        case mp_SelfAdjointEigenSystemFromTridiag: return "eval;evec;"; break;

        case mp_SelfAdjointEigenValues: return "eval;"; break;
        case mp_SelfAdjointEigenSystem: return "eval;evec;invsqrt;sqrt;"; break;

        case mp_GeneralizedSelfAdjointEigenValues: return "eval;"; break;
        case mp_GeneralizedSelfAdjointEigenSolver: return "eval;evec;"; break;

        case mp_EigenValues: return "info;eval;"; break;
        case mp_EigenSystem: return "info;eval;evec;"; break;

        case mp_EigenValuesFromRealInput: return "info;eval;"; break;
        case mp_EigenSystemFromRealInput: return "info;eval;evec;"; break;

        case mp_PseudoEigenSystem: return "info;pseudoeval;pseudoevec;"; break;

        case mp_GeneralizedEigenValuesFromRealInput: return "info;eval;"; break;
        case mp_GeneralizedEigenSystemFromRealInput: return "info;eval;evec;alphas;betas"; break;

        default: return "";
    }
}





