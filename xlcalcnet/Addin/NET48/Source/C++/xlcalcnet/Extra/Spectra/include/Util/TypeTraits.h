// Copyright (C) 2018 Yixuan Qiu <yixuan.qiu@cos.name>
//
// This Source Code Form is subject to the terms of the Mozilla
// Public License v. 2.0. If a copy of the MPL was not distributed
// with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

#ifndef TYPE_TRAITS_H
#define TYPE_TRAITS_H

#include <Eigen/Core>
#include <limits>

//#include <iostream>


/// \cond

namespace Spectra {


// For a real value type "Scalar", we want to know its smallest
// positive value, i.e., std::numeric_limits<Scalar>::min().
// However, we must take non-standard value types into account,
// so we rely on Eigen::NumTraits.
//
// Eigen::NumTraits has defined epsilon() and lowest(), but
// lowest() means negative highest(), which is a very small
// negative value.
//
// Therefore, we manually define this limit, and use eplison()^3
// to mimic it for non-standard types.

#ifdef Use_Mpfr
#include <boost/multiprecision/mpfr.hpp>
#include <boost/math/special_functions/hypot.hpp>
using boost::multiprecision::mpfr_float;
#endif


#ifdef Use_Dec50
#include <boost/multiprecision/cpp_dec_float.hpp>
#include <boost/math/special_functions/hypot.hpp>
using boost::multiprecision::cpp_dec_float_50;
#endif


#ifdef Use_Float128
#include <boost/multiprecision/float128.hpp>
#include <boost/math/special_functions/hypot.hpp>
using boost::multiprecision::float128;
#endif


// Generic definition
template <typename Scalar>
struct TypeTraits
{
    static inline Scalar min()
    {
        return Eigen::numext::pow(Eigen::NumTraits<Scalar>::epsilon(), Scalar(3));
    }
};



// Full specialization

#ifdef Use_Mpfr
template <>
struct TypeTraits<mpfr_float>
{
    static inline mpfr_float min()
    {
        return std::numeric_limits<mpfr_float>::min();
    }

    static inline mpfr_float hypot(mpfr_float a, mpfr_float b)
    {
        return boost::math::hypot(a, b);
    }
};
#endif

#ifdef Use_Dec50
template <>
struct TypeTraits<cpp_dec_float_50>
{
    static inline cpp_dec_float_50 min()
    {
        return std::numeric_limits<cpp_dec_float_50>::min();
    }

    static inline cpp_dec_float_50 hypot(cpp_dec_float_50 a, cpp_dec_float_50 b)
    {
        return boost::math::hypot(a, b);
    }
};
#endif


#ifdef Use_Float128
template <>
struct TypeTraits<float128>
{
    static inline float128 min()
    {
        return std::numeric_limits<float128>::min();
    }

    static inline float128 hypot(float128 a, float128 b)
    {
        return boost::math::hypot(a, b);
    }
};
#endif





template <>
struct TypeTraits<float>
{
    static inline float min()
    {
        return std::numeric_limits<float>::min();
    }

    static inline float hypot(float a, float b)
    {
        return std::sqrt(a*a + b*b);
    }
};

template <>
struct TypeTraits<double>
{
    static inline double min()
    {
        return std::numeric_limits<double>::min();
    }

    static inline double hypot(double a, double b)
    {
        return std::sqrt(a*a + b*b);
    }

};

template <>
struct TypeTraits<long double>
{
    static inline long double min()
    {
        return std::numeric_limits<long double>::min();
    }

    static inline long double hypot(long double a, long double b)
    {
        return std::sqrt(a*a + b*b);
    }


};


} // namespace Spectra

/// \endcond

#endif // TYPE_TRAITS_H
