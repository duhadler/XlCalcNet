/* C# */

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
using System.Collections.Generic;
using System.Linq;
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the Complex data type
    /// </summary>
    public partial class m53libc
    {

#region EllipticFunctions


        // See: https://github.com/stla/EllipticFunctions.jl/blob/master/src/EllipticFunctions.jl




        private static bool iszero(Complex z)
        { return ((z.Real == 0.0) && (z.Imaginary == 0.0)); }


        private static bool IsInfinite(Complex z)
        { return (math53.isinf(z.Real) || math53.isinf(z.Imaginary)); }


        private static void validateq(Double q, string errorMessage = "|q| must be less than 1")
        {
            if (Math.Abs(q) >= 1.0)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        private static void validateq(Complex q, string errorMessage = "|q| must be less than 1")
        {
            if (Complex.Abs(q) >= 1.0)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        private static void validatetau(Complex tau, string errorMessage = "imag(tau) must be positive")
        {
            if (tau.Imaginary <= 0.0)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        private static Complex xcispi(Complex x)
        {
            return Complex.Exp(Complex.ImaginaryOne * (Math.PI * x));
        }


        private static Complex csqrt(Complex x)
        {
            return Complex.Sqrt(x);
        }

        private static bool areclose(Complex z1, Complex z2)
        {
            if (z1 == z2) return true;

            Double eps2 = Math.Pow(1.0E-15, 2.0);
            Double mod2Z2 = Complex.Abs(z2) * Complex.Abs(z2);
            Double maxMod2 = mod2Z2 < eps2 ? 1.0 : Math.Max(Complex.Abs(z1) * Complex.Abs(z1), mod2Z2);

            return Complex.Abs(z1 - z2) * Complex.Abs(z1 - z2) < 4.0 * eps2 * maxMod2;
        }

        private static Double modulo(Double a, Double p)
        {
            Double i = a > 0 ? Math.Floor(a / p) : Math.Ceiling(a / p);
            return a - i * p;
        }

        private static Complex calctheta3(Complex z, Complex tau)
        {
            Complex output = Complex.One;
            int n = 0;

            while (true)
            {
                n++;
                Complex qWeight =
                    Complex.Exp(n * Complex.ImaginaryOne * (Math.PI * (n * tau + 2.0 * z))) +
                    Complex.Exp(n * Complex.ImaginaryOne * (Math.PI * (n * tau - 2.0 * z)));
                output += qWeight;
                Double modulus = Complex.Abs(output);

                if (Double.IsNaN(modulus) || Double.IsInfinity(modulus))
                {
                    throw new Exception("nan or Infinity occurred in the summation: " + modulus);
                }
                else if (n >= 3 && areclose(output + qWeight, output))
                {
                    break;
                }
            }
            return Complex.Log(output);
        }

        private static Complex argtheta3(Complex z, Complex tau, int passes)
        {
            passes++;
            if (passes > 1000)
            {
                throw new Exception("Reached 1000 iterations (argtheta3).");
            }

            Double zImg = z.Imaginary;
            Double tauImg = tau.Imaginary;
            Double h = tauImg / 2.0;
            Complex zUse = new Complex(modulo(z.Real, 1.0), zImg);

            Complex output;
            if (zImg < -h)
            {
                output = argtheta3(-zUse, tau, passes);
            }
            else if (zImg >= h)
            {
                Double quotient = Math.Floor(zImg / tauImg + 0.5);
                Complex zMin = zUse - quotient * tau;
                output = -2.0 * Complex.ImaginaryOne * quotient * zMin * Math.PI +
                          argtheta3(zMin, tau, passes) -
                          Complex.ImaginaryOne * tau * quotient * quotient * Math.PI;
            }
            else
            {
                output = calctheta3(zUse, tau);
            }
            return output;
        }

        private static Complex dologtheta4(Complex z, Complex tau, int passes)
        {
            return dologtheta3(z + 0.5, tau, passes + 1);
        }

        private static Complex dologtheta3(Complex z, Complex tau, int passes)
        {
            passes++;
            Double tauReal = tau.Real;

            Double tau2Real;
            if (tauReal > 0.6)
            {
                tau2Real = modulo(tauReal + 1.0, 2.0) - 1.0;
            }
            else
            {
                tau2Real = modulo(tauReal - 1.0, 2.0) + 1.0;
            }

            Double tau2Img = tau.Imaginary;
            Complex tau2 = new Complex(tau2Real, tau2Img);
            Complex output;

            if (Complex.Abs(tau2) < 0.98 && tau2Img < 0.98)
            {
                Complex tauPrime = -1.0 / tau2;
                output =
                    Complex.ImaginaryOne * tauPrime * z * z * Math.PI +
                    dologtheta3(z * tauPrime, tauPrime, passes) -
                    Complex.Log(csqrt(tau2) / csqrt(Complex.One * Complex.One * Complex.ImaginaryOne));
            }
            else if (tau2Real >= 0.6)
            {
                output = dologtheta4(z, tau2 - 1.0, passes);
            }
            else if (tau2Real <= -0.6)
            {
                output = dologtheta4(z, tau2 + 1.0, passes);
            }
            else
            {
                output = argtheta3(z, tau2, 0);
            }
            return output;
        }

        private static Complex M(Complex z, Complex tau)
        {
            return Complex.ImaginaryOne * (z + tau / 4.0) * Math.PI;
        }

        private static Complex _l_jtheta2_raw(Complex z, Complex tau)
        {
            return M(z, tau) + dologtheta3(z + 0.5 * tau, tau, 0);
        }

        private static Complex _l_jtheta1_raw(Complex z, Complex tau)
        {
            return _l_jtheta2_raw(z - 0.5, tau);
        }

        private static Complex _ljtheta3_raw(Complex z, Complex tau)
        {
            return dologtheta3(z, tau, 0);
        }

        private static Complex _ljtheta4_raw(Complex z, Complex tau)
        {
            return dologtheta4(z, tau, 0);
        }

        public static Complex _jtheta2_raw(Complex z, Complex tau)
        {
            return Complex.Exp(_l_jtheta2_raw(z, tau));
        }

        public static Complex _jtheta1_raw(Complex z, Complex tau)
        {
            return Complex.Exp(_l_jtheta1_raw(z, tau));
        }


        public static Complex _jtheta3_raw(Complex z, Complex tau)
        {
            return Complex.Exp(_ljtheta3_raw(z, tau));
        }

        public static Complex _jtheta4_raw(Complex z, Complex tau)
        {
            return Complex.Exp(_ljtheta4_raw(z, tau));
        }

        public static Complex _jtheta1(Complex z, Complex tau)
        {
            return _jtheta1_raw(z * (1.0 / Math.PI), tau);
        }

        private static Complex _jtheta2(Complex z, Complex tau)
        {
            return _jtheta2_raw(z * (1.0 / Math.PI), tau);
        }

        private static Complex _jtheta3(Complex z, Complex tau)
        {
            return _jtheta3_raw(z * (1.0 / Math.PI), tau);
        }

        private static Complex _jtheta4(Complex z, Complex tau)
        {
            return _jtheta4_raw(z * (1.0 / Math.PI), tau);
        }

        private static Complex principal_log_branch(Complex z)
        {
            //return new Complex(z.Real, Math.IEEERemainder(z.Imaginary, 2 * Math.PI));
            double TwoPi = 2.0 * Math.PI;
            double realPart = z.Real;
            double imagPart = Math.Round(z.Imaginary / TwoPi) * TwoPi;
            double remImag = z.Imaginary - imagPart;
            return new Complex(realPart, remImag);
        }

        private static Complex _ljtheta1(Complex z, Complex tau)
        {
            return principal_log_branch(_l_jtheta1_raw(z * (1.0 / Math.PI), tau));
        }

        private static Complex _ljtheta2(Complex z, Complex tau)
        {
            return principal_log_branch(_l_jtheta2_raw(z * (1.0 / Math.PI), tau));
        }

        private static Complex _ljtheta3(Complex z, Complex tau)
        {
            return principal_log_branch(_ljtheta3_raw(z * (1.0 / Math.PI), tau));
        }

        private static Complex _ljtheta4(Complex z, Complex tau)
        {
            return principal_log_branch(_ljtheta4_raw(z * (1.0 / Math.PI), tau));
        }


        private const Double InvPi = 1.0 / Math.PI;


        private static Complex _jtheta_ab(Complex a, Complex b, Complex z, Complex tau)
        {
            Complex alpha = a * tau;
            Complex beta = b + z * (1.0 / Math.PI);
            //Complex C = Complex.Exp(Complex.ImaginaryOne * Math.PI * a * (alpha + 2 * beta));
            Complex C = xcispi(a * (alpha + 2.0 * beta));
            return C * _jtheta3_raw(alpha + beta, tau);
        }





        public static Complex _jtheta1dash(Complex z, Complex tau)
        {
            //Double t1 = tau.Real;
            Complex q = xcispi(tau);
            Complex output = Complex.Zero;
            Complex alternate = -Complex.One;
            Complex qSquared = q * q;
            Complex q2N = Complex.One;
            Complex qToNPlus1 = Complex.One;

            // strip out n=0
            alternate = -alternate;
            Complex k = Complex.One;
            output += alternate * qToNPlus1 * k * Complex.Cos(k * z);

            for (int n = 1; n <= 3000; n++)
            {
                q2N *= qSquared;
                qToNPlus1 *= q2N;
                alternate = -alternate;
                k = 2.0 * n + Complex.One;
                Complex outputNew = output + alternate * qToNPlus1 * k * Complex.Cos(k * z);
                if (areclose(output, outputNew))
                {
                    // !!! TODO: check formula !!!
                    return 2 * Complex.Sqrt(Complex.Sqrt(q)) * output;
                }
                output = outputNew;
            }
            throw new Exception("Reached 3000 iterations.");
        }


        private static Complex _etaDedekind(Complex tau)
        {
            Complex chi = 1.0 / tau;
            return xcispi(-chi / 12.0) *
                   _jtheta3_raw(-chi / 2.0 + 1.0 / 2.0, -3.0 * chi) / Complex.Sqrt(-tau * Complex.ImaginaryOne);
            //return xcispi(-chi / 12) *
            //       _jtheta3_raw(-chi / 2 + 1 / 2, -3 * chi) / Complex.Sqrt(-tau.Imaginary);
        }

        private static Complex _EisensteinE2(Complex tau)
        {
            Complex j3 = _jtheta3_raw(Complex.Zero, tau);
            Complex j4 = _jtheta4_raw(Complex.Zero, tau);

            Complex lbd = (_jtheta2_raw(Complex.Zero, tau) / j3);
            lbd = lbd * lbd * lbd * lbd;

            Complex j3sq = j3 * j3;
            Complex j4quad = j4 * j4 * j4 * j4;

            return 6 * EllipticE(lbd) * j3sq / Math.PI - j3sq * j3sq - j4quad;
        }

        private static Complex _jtheta1dash0(Complex tau)
        {
            Complex jab = _jtheta_ab(1.0 / (6.0 * Complex.One), 1.0 / 2.0, 0.0, 3.0 * tau);
            return -2.0 * Complex.ImaginaryOne * jab * jab * jab;
        }

        private static Complex _jtheta1dashdashdash0(Complex tau)
        {
            return -_jtheta1dash(0.0, tau) * _EisensteinE2(tau);
        }

        private static Complex _dljtheta1(Complex z, Complex tau)
        {
            return z == 0 ?
                _jtheta1dash0(tau) / _jtheta1_raw(0.0, tau) :
                _jtheta1dash(z, tau) / _jtheta1(z, tau);
        }

        public static Complex _E4(Complex tau)
        {
            Complex j2 = _jtheta2_raw(0, tau);
            Complex j28 = j2 * j2 * j2 * j2 * j2 * j2 * j2 * j2;
            Complex j3 = _jtheta3_raw(0, tau);
            Complex j38 = j3 * j3 * j3 * j3 * j3 * j3 * j3 * j3;
            Complex j4 = _jtheta4_raw(0, tau);
            Complex j48 = j4 * j4 * j4 * j4 * j4 * j4 * j4 * j4;
            return (j28 + j38 + j48) / 2.0;
        }

        public static Complex _E6(Complex tau)
        {
            Complex j2 = _jtheta2_raw(0, tau);
            Complex j3 = _jtheta3_raw(0, tau);
            Complex j4 = _jtheta4_raw(0, tau);
            Complex x3 = j3 * j3 * j3 * j3;
            Complex x4 = j4 * j4 * j4 * j4;
            return (x3 * x3 * x3 + x4 * x4 * x4 - 3.0 * j2 * j2 * j2 * j2 * j2 * j2 * j2 * j2 * (x3 + x4)) / 2.0;
        }


        public static Tuple<Complex, Complex> _omega1_and_tau_from_g2g3(Complex g2, Complex g3)
        {
            return _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3));

            //return _omega1_and_tau((g2, g3));
        }


        public static Complex _omega1_from_g2g3(Complex g2, Complex g3)
        {
            return _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3)).Item1;

            //return _omega1_and_tau((g2, g3)).Item1;
        }


        public static Complex _tau_from_g2g3(Complex g2, Complex g3)
        {
            return _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3)).Item2;

            //return _omega1_and_tau((g2, g3)).Item2;
        }



        public static Complex _omega1_from_real_g2g3(Double g2, Double g3)
        {
            return _omega1_and_tau(new Tuple<Complex, Complex>(new Complex(g2, 0), new Complex(g3, 0))).Item1;
        }


        public static Complex _tau_from_real_g2g3(Double g2, Double g3)
        {
            return _omega1_and_tau(new Tuple<Complex, Complex>(new Complex(g2, 0), new Complex(g3, 0))).Item2;

            //return _omega1_and_tau((new Complex(g2, 0), new Complex(g3, 0))).Item2;
        }


        private static Tuple<Complex, Complex> _omega1_and_tau(Tuple<Complex, Complex> g)
        {
            Complex g2 = g.Item1;
            Complex g3 = g.Item2;
            Complex omega1;
            Complex tau;

            if (g2 == 0)
            {
                double gam = math53.gamma(1.0 / 3.0);
                omega1 = gam * gam * gam * (1.0 / (4 * Math.PI)) / Complex.Pow(g3, 1.0 / 6.0);
                tau = 0.5 + Complex.ImaginaryOne * Math.Sqrt(3.0) / 2.0;
            }
            else
            {
                Complex g2Cube = g2 * g2 * g2;
                Complex j = 1728.0 * g2Cube / (g2Cube - 27.0 * g3 * g3);
                if (IsInfinite(j))
                {
                    new Tuple<Complex, Complex>(-Complex.ImaginaryOne * 0.5 * Math.PI / Math.Sqrt(3), new Complex(Double.PositiveInfinity, Double.PositiveInfinity));

                    //return (-Complex.ImaginaryOne * 0.5 * Math.PI / Math.Sqrt(3), new Complex(Double.PositiveInfinity, Double.PositiveInfinity));
                }
                tau = kleinjinv(j);
                if (g3 == 0)
                {
                    // !!! Check formula !!!
                    omega1 = Complex.ImaginaryOne * Math.PI * Complex.Sqrt(Complex.Sqrt(1.0 / g2 / 12 * _E4(tau)));
                }
                else
                {
                    Complex G6OverG4 = 2.0 * Math.PI * Math.PI / 21.0 * _E6(tau) / _E4(tau);
                    omega1 = Complex.Sqrt(7.0 * G6OverG4 * g2 / (12.0 * g3));
                }
            }
            return new Tuple<Complex, Complex>(omega1, tau);

            //return (omega1, tau);
        }

        private static Complex _g2_from_omega1_and_tau(Complex omega1, Complex tau)
        {
            Complex j2 = _jtheta2_raw(0, tau);
            Complex j3 = _jtheta3_raw(0, tau);
            return (4.0 / 3.0) * Complex.Pow(Math.PI / 2.0 / omega1, 4) * (j2 * j2 * j2 * j2 * j2 * j2 * j2 * j2 - (j2 * j3) * (j2 * j3) * (j2 * j3) * (j2 * j3) + j3 * j3 * j3 * j3 * j3 * j3 * j3 * j3);
        }

        private static Complex _wpFromTau(Complex z, Complex tau)
        {
            Complex j2 = _jtheta2_raw(0, tau);
            Complex j3 = _jtheta3_raw(0, tau);
            Complex j1 = _jtheta1_raw(z, tau);
            Complex j4 = _jtheta4_raw(z, tau);
            return Complex.Pow(Math.PI * j2 * j3 * j4 / j1, 2) - (Math.PI * Math.PI * (Complex.Pow(j2, 4) + Complex.Pow(j3, 4)) / 3.0);
        }


        private static Complex _wpDerivative(Complex z, Complex omega1, Complex tau)
        {
            Complex w1 = 2.0 * omega1 * (1.0 / Math.PI);
            Complex z1 = -z / (2.0 * omega1);
            Complex j1 = _jtheta1_raw(z1, tau);
            Complex j2 = _jtheta2_raw(z1, tau);
            Complex j3 = _jtheta3_raw(z1, tau);
            Complex j4 = _jtheta4_raw(z1, tau);
            Complex f = Complex.Pow(_jtheta1dash0(tau), 3) /
                         (_jtheta2_raw(0, tau) * _jtheta3_raw(0, tau) * _jtheta4_raw(0, tau) * Complex.Pow(j1, 3));
            return (2 / (w1 * w1 * w1)) * j2 * j3 * j4 * f;
        }

        public static Complex _thetaS(Complex z, Complex tau)
        {
            Complex j3sq = _jtheta3_raw(Complex.Zero, tau) * _jtheta3_raw(Complex.Zero, tau);
            Complex zPrime = z / j3sq * (1.0 / Math.PI);
            return j3sq * _jtheta1_raw(zPrime, tau) / _jtheta1dash0(tau);
        }

        public static Complex _thetaC(Complex z, Complex tau)
        {
            Complex zPrime = z / (_jtheta3_raw(Complex.Zero, tau) * _jtheta3_raw(Complex.Zero, tau)) * (1.0 / Math.PI);
            return _jtheta2_raw(zPrime, tau) / _jtheta2_raw(Complex.Zero, tau);
        }

        public static Complex _thetaN(Complex z, Complex tau)
        {
            Complex zPrime = z / (_jtheta3_raw(Complex.Zero, tau) * _jtheta3_raw(Complex.Zero, tau)) * (1.0 / Math.PI);
            return _jtheta4_raw(zPrime, tau) / _jtheta4_raw(Complex.Zero, tau);
        }

        public static Complex _thetaD(Complex z, Complex tau)
        {
            Complex j3 = _jtheta3_raw(Complex.Zero, tau);
            Complex zPrime = z / (j3 * j3) * (1.0 / Math.PI);
            return _jtheta3_raw(zPrime, tau) / j3;
        }

        public static Complex _tau_from_m(Complex m)
        {
            return Complex.ImaginaryOne * EllipticK(1 - m) / EllipticK(m);
        }

        private static Complex _check_and_get_tau_from_m(Complex? tau, Complex? m)
        {
            int nMissing = (tau == null ? 1 : 0) + (m == null ? 1 : 0);
            if (nMissing == 1)
                throw new ArgumentException("You must supply either `tau` or `m`.");

            if (tau != null)
            {
                validatetau(tau.Value);
            }
            else
            {
                tau = _tau_from_m(m.Value);
                validatetau(tau.Value);
            }
            return tau.Value;
        }




        // exports ####



        /// <summary>
        /// The nome `q` given the `tau` parameter.
        /// </summary>
        public static Complex qfromtau(Complex tau)
        {
            validatetau(tau);
            return xcispi(tau);
        }
        public static Complex _qfromtau(Complex tau)
        {
            //validatetau(tau);
            return xcispi(tau);
        }

        /// <summary>
        /// The `tau` parameter given the complex nome `q`.
        /// </summary>
        public static Complex taufromq(Complex q)
        {
            validateq(q);
            return -Complex.ImaginaryOne * (Complex.Log(q) / Math.PI);
        }

        public static Complex _taufromq(Complex q)
        {
            //validateq(q);
            return -Complex.ImaginaryOne * (Complex.Log(q) / Math.PI);
        }


        /// <summary>
        /// The `tau` parameter given the real nome `q`.
        /// </summary>
        public static Complex taufromq(Double q)
        {
            validateq(q);
            return q < 0 ? new Complex(1, -Math.Log(Math.Abs(q)) / Math.PI) : -Complex.ImaginaryOne * (Math.Log(q) / Math.PI);
        }




        /// <summary>
        /// Logarithm of the first Jacobi theta function.
        /// </summary>
        public static Complex ljtheta1(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _ljtheta1(z, tau);
        }

        /// <summary>
        /// First Jacobi theta function.
        /// </summary>
        public static Complex jtheta1(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _jtheta1(z, tau);
        }



        /// <summary>
        /// Logarithm of the second Jacobi theta function.
        /// </summary>
        public static Complex ljtheta2(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _ljtheta2(z, tau);
        }

        /// <summary>
        /// Second Jacobi theta function.
        /// </summary>
        public static Complex jtheta2(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _jtheta2(z, tau);
        }



        /// <summary>
        /// Logarithm of the third Jacobi theta function.
        /// </summary>
        public static Complex ljtheta3(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _ljtheta3(z, tau);
        }

        /// <summary>
        /// Third Jacobi theta function.
        /// </summary>
        public static Complex jtheta3(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _jtheta3(z, tau);
        }



        /// <summary>
        /// Logarithm of the fourth Jacobi theta function.
        /// </summary>
        public static Complex ljtheta4(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _ljtheta4(z, tau);
        }

        /// <summary>
        /// Fourth Jacobi theta function.
        /// </summary>
        public static Complex jtheta4(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _jtheta4(z, tau);
        }




        /// <summary>
        /// Jacobi theta function with characteristics. This is a family of functions parameterized by `a` and `b`, which contains the opposite of the first Jacobi theta function(`a= b = 0.5`), the second Jacobi theta function(`a= 0.5, b= 0`), the third Jacobi theta function(`a= b = 0`), and the fourth Jacobi theta function(`a= 0, b= 0.5`).
        /// </summary>
        public static Complex jtheta_ab(Complex a, Complex b, Complex z, Complex tau)
        {
            validatetau(tau);
            return _jtheta_ab(a, b, z, tau);
        }

        /// <summary>
        /// Derivative of the first Jacobi theta function.
        /// </summary>
        public static Complex jtheta1dash(Complex z, Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _jtheta1dash(z, tau);
        }

        /// <summary>
        /// Dedekind eta function.
        /// </summary>
        public static Complex etaDedekind(Complex tau)
        {
            validatetau(tau);
            return _etaDedekind(tau);
        }

        /// <summary>
        /// Lambda modular function.
        /// </summary>
        public static Complex lambda(Complex tau)
        {
            validatetau(tau);
            return Complex.Pow(_jtheta2_raw(0, tau) / _jtheta3_raw(0, tau), 4);
        }

        /// <summary>
        /// Klein j-invariant function.
        /// </summary>
        public static Complex kleinj(Complex tau)
        {
            validatetau(tau);
            Complex lbd = Complex.Pow(_jtheta2_raw(0, tau) / _jtheta3_raw(0, tau), 4);
            Complex x = lbd * (1.0 - lbd);
            return 256 * Complex.Pow(1 / x - 1, 2) * (1 - x); // 256 * (1-x)^3 / x^2
        }


        public static Complex CarlsonRF(Complex x, Complex y, Complex z)
        {
            bool xzero = x == Complex.Zero;
            bool yzero = y == Complex.Zero;
            bool zzero = z == Complex.Zero;
            if ((xzero ? 1 : 0) + (yzero ? 1 : 0) + (zzero ? 1 : 0) > 1)
                throw new ArgumentException("At most one of `x`, `y`, `z` can be 0.");

            Complex xx = x;
            Complex yy = y;
            Complex zz = z;

            //epsilon = Math.Pow(double.Epsilon, 4.0 / 3.0);
            double epsilon = 1E-12;

            double dx = double.MaxValue;
            double dy = double.MaxValue;
            double dz = double.MaxValue;

            while (dx > epsilon || dy > epsilon || dz > epsilon)
            {
                Complex lambda = Complex.Sqrt(xx) * Complex.Sqrt(yy) + Complex.Sqrt(yy) * Complex.Sqrt(zz) + Complex.Sqrt(zz) * Complex.Sqrt(xx);
                xx = (xx + lambda) / 4.0;
                yy = (yy + lambda) / 4.0;
                zz = (zz + lambda) / 4.0;
                Complex A = (xx + yy + zz) / 3.0;
                dx = Complex.Abs(1.0 - xx / A);
                dy = Complex.Abs(1.0 - yy / A);
                dz = Complex.Abs(1.0 - zz / A);
            }
            Complex Afinal = (xx + yy + zz) / 3.0;
            double dx2 = dx * dx;
            double dy2 = dy * dy;
            double dz2 = dz * dz;
            double E2 = Math.Sqrt(dx * dy) + Math.Sqrt(dy * dz) + Math.Sqrt(dz * dx);
            double E3 = Math.Sqrt(dy * dx * dz);
            return (1 - E2 / 10 + E3 / 14 + E2 * E2 / 24 - 3 * E2 * E3 / 44 - 5 * E2 * E2 * E2 / 208 +
                    3 * E3 * E3 / 104 + E2 * E2 * E3 / 16) / Complex.Sqrt(Afinal);
        }

        public static Complex CarlsonRC(Complex x, Complex y)
        {
            if (y == Complex.Zero)
                y = y + 1.0E-12;
            //throw new ArgumentException("`y` cannot be 0.");
            return CarlsonRF(x, y, y);
        }

        public static Complex CarlsonRD(Complex x, Complex y, Complex z)
        {
            bool xzero = x == Complex.Zero;
            bool yzero = y == Complex.Zero;
            bool zzero = z == Complex.Zero;
            if ((xzero ? 1 : 0) + (yzero ? 1 : 0) + (zzero ? 1 : 0) > 1)
                throw new ArgumentException("At most one of `x`, `y`, `z` can be 0.");

            Complex xx = x;
            Complex yy = y;
            Complex zz = z;

            double epsilon = Math.Pow(double.Epsilon, 4.0 / 3.0);
            epsilon = 1E-12;

            double dx = double.MaxValue;
            double dy = double.MaxValue;
            double dz = double.MaxValue;

            Complex s = Complex.Zero;
            Complex fac = Complex.One;
            Complex A = Complex.Zero;

            while (dx > epsilon || dy > epsilon || dz > epsilon)
            {
                Complex lambda = Complex.Sqrt(xx) * Complex.Sqrt(yy) + Complex.Sqrt(yy) * Complex.Sqrt(zz) + Complex.Sqrt(zz) * Complex.Sqrt(xx);
                s += fac / (Complex.Sqrt(zz) * (zz + lambda));
                fac /= 4.0;
                xx = (xx + lambda) / 4.0;
                yy = (yy + lambda) / 4.0;
                zz = (zz + lambda) / 4.0;
                A = (xx + yy + 3 * zz) / 5.0;
                dx = Complex.Abs(1.0 - xx / A);
                dy = Complex.Abs(1.0 - yy / A);
                dz = Complex.Abs(1.0 - zz / A);
                dx = dx * dx;
                dy = dy * dy;
                dz = dz * dz;
            }

            dx = Math.Sqrt(dx);
            dy = Math.Sqrt(dy);
            dz = Math.Sqrt(dz);

            double E2 = dx * dy + dy * dz + 3 * dz * dz + 2 * dz * dx + dx * dz + 2 * dy * dz;
            double E3 = dz * dz * dz + dx * dz * dz + 3 * dx * dy * dz + 2 * dy * dz * dz + dy * dz * dz + 2 * dx * dz * dz;
            double E4 = dy * dz * dz * dz + dx * dz * dz * dz + dx * dy * dz * dz + 2 * dx * dy * dz * dz;
            double E5 = dx * dy * dz * dz * dz;

            return 3 * s + fac * (1 - 3 * E2 / 14 + E3 / 6 + 9 * E2 * E2 / 88 - 3 * E4 / 22 -
                                  9 * E2 * E3 / 52 + 3 * E5 / 26 - E2 * E2 * E2 / 16 +
                                  3 * E3 * E3 / 40 + 3 * E2 * E4 / 20 + 45 * E2 * E2 * E3 / 272 -
                                  9 * (E3 * E4 + E2 * E5) / 68) / A / Complex.Sqrt(A);
        }

        public static Complex CarlsonRG(Complex x, Complex y, Complex z)
        {
            bool xzero = x == Complex.Zero;
            bool yzero = y == Complex.Zero;
            bool zzero = z == Complex.Zero;
            int nzeros = (xzero ? 1 : 0) + (yzero ? 1 : 0) + (zzero ? 1 : 0);

            if (nzeros == 3)
                return Complex.Zero;
            if (nzeros == 2)
                return Complex.Sqrt(x + y + z) / 2.0;
            if (zzero)
                return CarlsonRG(y, z, x);

            return (z * CarlsonRF(x, y, z) -
                    (x - z) * (y - z) * CarlsonRD(x, y, z) / 3.0 +
                    Complex.Sqrt(x) * Complex.Sqrt(y) / Complex.Sqrt(z)) / 2.0;
        }



        public static Complex CarlsonRJ(Complex x, Complex y, Complex z, Complex p)
        {
            bool xzero = x == Complex.Zero;
            bool yzero = y == Complex.Zero;
            bool zzero = z == Complex.Zero;
            bool pzero = p == Complex.Zero;
            int nzeros = (xzero ? 1 : 0) + (yzero ? 1 : 0) + (zzero ? 1 : 0) + (pzero ? 1 : 0);
            if (nzeros > 1)
                throw new ArgumentException("At most one of `x`, `y`, `z`, `p` can be 0.");

            // Promote to Complex (already Complex)
            Complex xx = x;
            Complex yy = y;
            Complex zz = z;
            Complex pp = p;

            // Determine the floating point type for epsilon
            double epsilon = Math.Pow(Math.Pow(2, -52), 3); // eps(T)^3 for double precision
            epsilon = 1E-12;


            Complex A0 = (xx + yy + zz + pp + pp) / 5.0;
            Complex A = A0;
            Complex delta = (pp - xx) * (pp - yy) * (pp - zz);
            int f = 1;
            double fac = 1.0;

            List<Complex> d = new List<Complex>();
            List<Complex> e = new List<Complex>();

            double maxAbsSquared = Math.Max(
                Math.Max((A - xx).Magnitude * (A - xx).Magnitude, (A - yy).Magnitude * (A - yy).Magnitude),
                Math.Max((A - zz).Magnitude * (A - zz).Magnitude, (A - pp).Magnitude * (A - pp).Magnitude)
            );

            double Q = Math.Pow(4.0 / epsilon, 1.0 / 3.0) * maxAbsSquared;

            while (A.Magnitude * A.Magnitude <= Q)
            {
                Complex sqrt_x = Complex.Sqrt(xx);
                Complex sqrt_y = Complex.Sqrt(yy);
                Complex sqrt_z = Complex.Sqrt(zz);
                Complex sqrt_p = Complex.Sqrt(pp);

                Complex dnew = (sqrt_p + sqrt_x) * (sqrt_p + sqrt_y) * (sqrt_p + sqrt_z);
                d.Add(dnew * f);
                e.Add(fac * delta / (dnew * dnew));
                f *= 4;
                fac /= 64.0;

                Complex lambda = sqrt_x * sqrt_y + sqrt_y * sqrt_z + sqrt_z * sqrt_x;
                xx = (xx + lambda) / 4.0;
                yy = (yy + lambda) / 4.0;
                zz = (zz + lambda) / 4.0;
                pp = (pp + lambda) / 4.0;
                A = (A + lambda) / 4.0;
                Q /= 16.0;
            }

            Complex M_1_fA = 1.0 / f / A;
            Complex X = (A0 - xx) * M_1_fA;
            Complex Y = (A0 - yy) * M_1_fA;
            Complex Z = (A0 - zz) * M_1_fA;
            Complex P = -(X + Y + Z) / 2.0;

            Complex E2 = X * Y + X * Z + Y * Z - 3.0 * P * P;
            Complex E3 = X * Y * Z + 2.0 * E2 * P + 4.0 * P * P * P;
            Complex E4 = P * (2.0 * X * Y * Z + E2 * P + 3.0 * P * P * P);
            Complex E5 = X * Y * Z * P * P;

            Complex g = (1.0 - 3.0 * E2 / 14.0 + E3 / 6.0 + 9.0 * E2 * E2 / 88.0 - 3.0 * E4 / 22.0 - 9.0 * E2 * E3 / 52.0 + 3.0 * E5 / 26.0)
                        / f / A / Complex.Sqrt(A);

            if (e.Count > 1)
            {
                Complex sum = Complex.Zero;
                for (int i = 0; i < e.Count; i++)
                {
                    Complex ei = e[i];
                    Complex term;
                    if (ei == Complex.Zero)
                    {
                        term = Complex.One;
                    }
                    else
                    {
                        term = Complex.Atan(Complex.Sqrt(ei)) / Complex.Sqrt(ei);
                    }
                    sum += term / d[i];
                }
                return 6.0 * sum;
            }
            else
            {
                return Complex.Zero;
            }
        }



        public static Complex Agm(Complex x, Complex y)
        {
            if (x + y == Complex.Zero || x == Complex.Zero || y == Complex.Zero)
            {
                return Complex.Zero;
            }

            Complex a = x;
            Complex b = y;

            while (!AreClose(a, b))
            {
                Complex a1 = (a + b) / 2.0;
                Complex b1 = Complex.Sqrt(a * b);
                if (AreClose(a, a1) && AreClose(b, b1))
                {
                    break;
                }
                a = a1;
                b = b1;
            }

            return (a + b) / 2.0;
        }

        private static bool AreClose(Complex a, Complex b, double tolerance = 1e-12)
        {
            return (a - b).Magnitude < tolerance;
        }


        public static Complex EllipticF(Complex phi, Complex m)
        {
            if (phi == Complex.Zero || double.IsInfinity(m.Real))
                return Complex.Zero;

            double rphi = phi.Real;
            double iphi = phi.Imaginary;
            double rm = m.Real;
            double im = m.Imaginary;

            if (rphi == 0 && double.IsInfinity(iphi) && im == 0 && rm > 0 && rm < 1)
            {
                double signImagPhi = Math.Sign(iphi);
                return signImagPhi * (EllipticF(Math.PI / 2, m) - EllipticF(Math.PI / 2, 1 / m) / Complex.Sqrt(m));
            }

            double rphiopi = rphi / Math.PI;

            if (Math.Abs(rphiopi) == 0.5 && m == Complex.One)
                return new Complex(double.NaN, double.NaN);

            if (rphiopi >= -0.5 && rphiopi <= 0.5)
            {
                if (m == Complex.One && Math.Abs(rphiopi) < 0.5)
                    //return Complex.Atanh(Complex.Sin(phi));
                    return cmath53.atanh(Complex.Sin(phi));

                if (m == Complex.Zero)
                    return phi;

                Complex sine = Complex.Sin(phi);
                if (double.IsInfinity(sine.Real) || double.IsInfinity(sine.Imaginary))
                    throw new ArgumentException("`sin(phi)` is not finite.");

                Complex sine2 = sine * sine;
                Complex cosine2 = Complex.One - sine2;
                Complex oneminusmsine2 = Complex.One - m * sine2;

                return sine * CarlsonRF(cosine2, oneminusmsine2, Complex.One);
            }

            int k;
            if (rphiopi > 0.5)
            {
                k = (int)Math.Ceiling(rphiopi - 0.5);
                phi -= k * Math.PI;
            }
            else
            {
                k = -(int)Math.Floor(0.5 - rphiopi);
                phi -= k * Math.PI;
            }

            return 2 * k * EllipticF(Math.PI / 2, m) + EllipticF(phi, m);
        }

        public static Complex EllipticK(Complex m)
        {
            return Math.PI * Complex.One / (2 * Agm(Complex.Sqrt(Complex.One - m), Complex.One));
        }

        public static Complex EllipticE(Complex phi, Complex m)
        {
            if (phi == Complex.Zero)
                return Complex.Zero;

            if (double.IsInfinity(m.Real) && m.Imaginary == 0)
                return new Complex(double.NaN, double.NaN);

            double rphiopi = phi.Real / Math.PI;

            if (rphiopi >= -0.5 && rphiopi <= 0.5)
            {
                if (m == Complex.Zero)
                    return phi;

                if (m == Complex.One)
                    return Complex.Sin(phi);

                Complex sine = Complex.Sin(phi);
                if (double.IsInfinity(sine.Real) || double.IsInfinity(sine.Imaginary))
                    throw new ArgumentException("`sin(phi)` is not finite.");

                Complex sine2 = sine * sine;
                Complex cosine2 = Complex.One - sine2;
                Complex oneminusmsine2 = Complex.One - m * sine2;

                return sine * (CarlsonRF(cosine2, oneminusmsine2, Complex.One) -
                               m * sine2 * CarlsonRD(cosine2, oneminusmsine2, Complex.One) / 3);
            }

            int k;
            if (rphiopi > 0.5)
            {
                k = (int)Math.Ceiling(rphiopi - 0.5);
                phi -= k * Math.PI;
            }
            else
            {
                k = -(int)Math.Floor(0.5 - rphiopi);
                phi -= k * Math.PI;
            }

            return 2 * k * EllipticE(Math.PI / 2, m) + EllipticE(phi, m);
        }

        public static Complex EllipticE(Complex m)
        {
            return EllipticE(Math.PI / 2, m);
        }

        // dflintc.m_elliptic_pi_inc(n:2, phi:dreal.pi()/2, m:z);
        // EllipticFunctions.EllipticE(n:2, phi:dreal.pi()/2, m:z);


        public static Complex EllipticPI(Complex phi, Complex n, Complex m)
        {
            if (phi == Complex.Zero || (double.IsInfinity(m.Real) && m.Imaginary == 0) ||
                (double.IsInfinity(n.Real) && n.Imaginary == 0))
                return Complex.Zero;

            Complex pio2 = Math.PI * Complex.One / 2;

            if ((phi == pio2) && (m == Complex.One) && (n.Imaginary == 0) && (n != Complex.One))
                return n.Real > 1 ? new Complex(double.NegativeInfinity, 0) : new Complex(double.PositiveInfinity, 0);

            if ((phi == pio2) && (n == Complex.One))
                return new Complex(double.NaN, double.NaN);

            if ((phi == pio2) && (m == Complex.Zero))
                return pio2 / Complex.Sqrt(Complex.One - n);

            if ((phi == pio2) && (n == m))
                return EllipticE(m) / (Complex.One - m);

            if ((phi == pio2) && (n == Complex.Zero))
                return EllipticK(m);

            double rphiopi = phi.Real / Math.PI;

            if ((rphiopi >= -0.5) && (rphiopi <= 0.5))
            {
                Complex sine = Complex.Sin(phi);
                if ((double.IsInfinity(sine.Real)) || (double.IsInfinity(sine.Imaginary)))
                    throw new ArgumentException("`sin(phi)` is not finite.");

                Complex sine2 = sine * sine;
                Complex cosine2 = Complex.One - sine2;
                Complex oneminusmsine2 = Complex.One - m * sine2;

                return sine * (CarlsonRF(cosine2, oneminusmsine2, Complex.One) +
                               n * sine2 * CarlsonRJ(cosine2, oneminusmsine2, Complex.One, Complex.One - n * sine2) / 3.0);
            }

            int k;
            if (rphiopi > 0.5)
            {
                k = (int)Math.Ceiling(rphiopi - 0.5);
                phi -= k * Math.PI;
                return 2.0 * k * EllipticPI(Math.PI / 2.0, n, m) + EllipticPI(phi, n, m);
            }

            k = -(int)Math.Floor(0.5 - rphiopi);
            phi -= k * Math.PI;
            return 2.0 * k * EllipticPI(Math.PI / 2, n, m) + EllipticPI(phi, n, m);
        }
        //}





        // Omitted: agm(x, y)




        /// <summary>
        /// Inverse of the Klein j-invariant function.
        /// </summary>
        /// <param name="j">real or complex number</param>
        public static Complex kleinjinv(Complex j)
        {
            Complex x;
            if (IsInfinite(j))
            {
                x = Complex.Zero;
            }
            else
            {
                Complex j2 = j * j;
                Complex j3 = j2 * j;
                Complex t = Complex.Pow((-j3 + 2304 * j2 + 12288 * Complex.Sqrt(3.0 * (1728.0 * j2 - j3)) - 884736.0 * j), 1.0 / 3.0);
                x = (1.0 / 768.0) * t - (1536.0 * j - j2) / (768.0 * t) + (1 - j / 768.0);
            }
            Complex lbd = -(-1 - Complex.Sqrt(1 - 4.0 * x)) / 2.0;
            return Complex.ImaginaryOne * cmath53.agm(1.0, Complex.Sqrt(1.0 - lbd)) / cmath53.agm(1.0, Complex.Sqrt(lbd));
        }





        /// <summary>
        /// Eisenstein E-series of weight 2.
        /// </summary>
        /// <param name="q">Nome</param>
        public static Complex EisensteinE2(Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _EisensteinE2(tau / 2.0);
        }

        /// <summary>
        /// Eisenstein E-series of weight 4.
        /// </summary>
        /// <param name="q">Nome</param>
        public static Complex EisensteinE4(Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _E4(tau / 2.0);
        }

        /// <summary>
        /// Eisenstein E-series of weight 6.
        /// </summary>
        /// <param name="q">Nome</param>
        public static Complex EisensteinE6(Complex q)
        {
            validateq(q);
            Complex tau = taufromq(q);
            return _E6(tau / 2.0);
        }

        /// <summary>
        /// Half-periods omega_1 and omega_2 from the elliptic invariants.
        /// </summary>
        /// <param name="g2">Weierstrass elliptic invariant, real or complex number</param>
        /// <param name="g3">Weierstrass elliptic invariant, real or complex number</param>
        public static Tuple<Complex, Complex> halfPeriods(Complex g2, Complex g3)
        {
            Complex omega1, tau;
            if (g2 == 0)
            {
                omega1 = math53.gamma(1.0 / 3.0) * math53.gamma(1.0 / 3.0) * math53.gamma(1.0 / 3.0) / (4.0 * Math.PI * Complex.Pow(g3, 1.0 / 6.0));
                tau = 0.5 + Complex.ImaginaryOne * Math.Sqrt(3.0) / 2.0;
            }
            else
            {
                Complex g2cube = Complex.Pow(g2, 3.0);
                Complex j = 1728.0 * g2cube / (g2cube - 27.0 * g3 * g3);
                if (IsInfinite(j))
                {
                    return new Tuple<Complex, Complex>(-Complex.ImaginaryOne * Math.PI / 2.0 / Math.Sqrt(3.0), new Complex(Double.PositiveInfinity, Double.PositiveInfinity));

                    //return (-Complex.ImaginaryOne * Math.PI / 2.0 / Math.Sqrt(3.0), new Complex(Double.PositiveInfinity, Double.PositiveInfinity));
                }
                tau = kleinjinv(j);
                if (g3 == 0)
                {
                    omega1 = Complex.ImaginaryOne * Math.PI * Complex.Sqrt(Complex.Sqrt(1.0 / g2 / 12.0 * _E4(tau)));
                }
                else
                {
                    Complex G6_over_G4 = 2.0 * Math.PI * Math.PI / 21.0 * _E6(tau) / _E4(tau);
                    omega1 = Complex.Sqrt(7.0 * G6_over_G4 * g2 / (12.0 * g3));
                }
            }
            return new Tuple<Complex, Complex>(omega1, tau * omega1);

            //return (omega1, tau * omega1);
        }

        /// <summary>
        /// Weierstrass elliptic invariants g_2 and g_3 from the half-periods.
        /// </summary>
        /// <param name="omega1">Weierstrass half period, real or complex number</param>
        /// <param name="omega2">Weierstrass half period, real or complex number</param>
        public static Tuple<Complex, Complex> ellipticInvariants(Complex omega1, Complex omega2)
        {
            Complex tau = omega2 / omega1;
            if (tau.Imaginary <= 0)
            {
                throw new ArgumentException("Invalid pair `(omega1, omega2)`.");
            }
            Complex j2 = _jtheta2_raw(0, tau);
            Complex j3 = _jtheta3_raw(0, tau);
            Complex g2 = (4.0 / 3.0) * Complex.Pow(Math.PI / (2.0 * omega1), 4) * (Complex.Pow(j2, 8) - (j2 * j3) * (j2 * j3) * (j2 * j3) * (j2 * j3)) + Complex.Pow(j3, 8);

            // !!! Check formula !!!
            Complex g3 = (8.0 / 27.0) * Complex.Pow(Math.PI / (2.0 * omega1), 6.0) * (Complex.Pow(j2, 12.0) - ((3.0 / 2.0 * j2 * j2 * j2 * j2 * j3 * j3) + (3.0 / 2.0 * j2 * j2 * j2 * j3 * j3 * j3 * j3)) + Complex.Pow(j3, 12.0));
            return new Tuple<Complex, Complex>(g2, g3);
            //return (g2, g3);
        }


        /// <summary>
        /// Weierstrass p-function. one and only one of the parameters `tau`, `omega` or `g` must be given.
        /// </summary>
        public static Complex wp(Complex z, Complex tau_, Complex omega1_, Complex omega2_, Complex g2_, Complex g3_, int derivative = 0, string UseWhat = "tau")
        {
            Complex omega1 = 0.0;
            Complex weier = 0;
            Complex weierPrime = 0;
            Complex tau = 0;

            if (derivative < 0 || derivative > 3)
                throw new ArgumentException("`derivative` must be between 0 and 3.");

            if (UseWhat == "tau")
            {
                tau = tau_;
                if (tau.Imaginary <= 0)
                    throw new ArgumentException("Invalid `tau`.");
                if (derivative != 1)
                {
                    weier = _wpFromTau(z, tau);
                    if (derivative == 0)
                        return weier;
                    if (derivative == 2)
                    {
                        Complex g2 = _g2_from_omega1_and_tau(omega1, tau);
                        return 6 * weier * weier - g2 / 2;
                    }
                }
                omega1 = 0.5;
            }

            if (UseWhat == "omega")
            {
                omega1 = omega1_;
                Complex omega2 = omega2_;
                tau = omega2 / omega1;
                if (tau.Imaginary <= 0)
                    throw new ArgumentException("Invalid `omega`.");
                if (derivative != 1)
                {
                    weier = _wpFromTau(z / omega1 / 2.0, tau) / (omega1 * omega1 * 4.0);
                    if (derivative == 0)
                        return weier;
                    if (derivative == 2)
                    {
                        Complex g2 = _g2_from_omega1_and_tau(omega1, tau);
                        return 6.0 * weier * weier - g2 / 2.0;
                    }
                }
            }

            if (UseWhat == "g2g3")
            {
                Complex g2 = g2_;
                Complex g3 = g3_;
                omega1 = _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3)).Item1;
                tau = _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3)).Item2;
                if (derivative != 1)
                {
                    weier = _wpFromTau(z / omega1 / 2.0, tau) / (omega1 * omega1 * 4.0);
                    if (derivative == 0)
                        return weier;
                    if (derivative == 2)
                    {
                        return 6.0 * weier * weier - g2 / 2.0;
                    }
                }
            }

            weierPrime = _wpDerivative(z, omega1, tau);
            if (derivative == 1)
                return weierPrime;
            return 12 * weier * weierPrime; // derivative = 3
        }


        /// <summary>
        /// Weierstrass sigma-function. one and only one of the parameters `tau`, `omega` or `g` must be given.
        /// </summary>
        public static Complex wsigma(Complex z, Complex tau_, Complex omega1_, Complex omega2_, Complex g2_, Complex g3_, int derivative = 0, string UseWhat = "tau")
        {
            Complex omega1 = 0;
            Complex tau = 0;

            //int nMissing = (tau == null ? 1 : 0) + (omega == null ? 1 : 0) + (g == null ? 1 : 0);
            //if (nMissing == 2)
            //    throw new ArgumentException("You must supply either `tau`, `omega` or `g`.");

            if (UseWhat == "tau")
            {
                tau = tau_;
                if (tau.Imaginary <= 0)
                    throw new ArgumentException("Invalid `tau`.");
                omega1 = 0.5;
            }
            else if (UseWhat == "omega")
            {
                omega1 = omega1_;
                Complex omega2 = omega2_;
                tau = omega2 / omega1;
                if (tau.Imaginary <= 0)
                    throw new ArgumentException("Invalid `omega`.");
            }
            else if (UseWhat == "g2g3")
            {
                Complex g2 = g2_;
                Complex g3 = g3_;
                omega1 = _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3)).Item1;
                tau = _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3)).Item2;
            }

            Complex w1 = -2.0 * omega1 / Math.PI;
            Complex j1 = _jtheta1(z / w1, tau);
            Complex f = _jtheta1dash0(tau);
            Complex h = -Math.PI / 6.0 / w1 * _jtheta1dashdashdash0(tau) / f;

            return w1 * Complex.Exp(h * z * z / w1 / Math.PI) * j1 / f;
        }


        /// <summary>
        /// Weierstrass zeta-function. one and only one of the parameters `tau`, `omega` or `g` must be given.
        /// </summary>
        public static Complex wzeta(Complex z, Complex tau_, Complex omega1_, Complex omega2_, Complex g2_, Complex g3_, int derivative = 0, string UseWhat = "tau")
        {
            Complex omega1 = 0;
            Complex omega2 = 0;
            Complex tau = 0;

            //int missingCount = (tau == null ? 1 : 0) + (omega == null ? 1 : 0) + (g == null ? 1 : 0);
            //if (missingCount == 2)
            //    throw new ArgumentException("You must supply either `tau`, `omega` or `g`.");

            if (UseWhat == "tau" || UseWhat == "omega")
            {
                if (UseWhat == "tau")
                {
                    tau = tau_;
                    if (tau.Imaginary <= 0)
                        throw new ArgumentException("Invalid `tau`.");
                    omega1 = 0.5;
                    omega2 = tau / 2.0;
                }
                else if (UseWhat == "omega")
                {
                    omega1 = omega1_;
                    omega2 = omega2_;
                    tau = omega2 / omega1;
                    if (tau.Imaginary <= 0)
                        throw new ArgumentException("Invalid `omega`.");
                }

                if (IsInfinite(omega1.Real) && (IsInfinite(omega2.Imaginary))) // i.e. g2=0 g3=0
                    return 1.0 / z;

                if (Complex.Abs(omega1.Real - Math.PI / Math.Sqrt(6.0)) < 1e-10 && (IsInfinite(omega2.Imaginary))) // i.e. g2=3 g3=1
                    return z / 2.0 + Math.Sqrt(3.0 / 2.0) / Complex.Tan(Math.Sqrt(3.0 / 2.0) * z);
            }

            if (UseWhat == "g2g3")
            {
                Complex g2 = g2_;
                Complex g3 = g3_;
                if ((g2 == 0) && g3 == 0)
                    return 1 / z;

                if ((g2 == 3) && g3 == 1)
                    return z / 2 + Math.Sqrt(3.0 / 2.0) / Complex.Tan(Math.Sqrt(3.0 / 2.0) * z);

                omega1 = _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3)).Item1;
                tau = _omega1_and_tau(new Tuple<Complex, Complex>(g2, g3)).Item2;
            }

            Complex w1 = -omega1 / Math.PI;
            Complex p = 1.0 / w1 / 2.0;
            Complex eta1 = p / 6.0 / w1 * _jtheta1dashdashdash0(tau) / _jtheta1dash0(tau);
            return -eta1 * z + p * _dljtheta1(p * z, tau);
        }



        /// <summary>
        /// Neville S-theta function. Only one of the parameters `tau` or `m` must be supplied.
        /// </summary>
        public static Complex thetaS(Complex z, Complex tau, Complex m, string UseWhat = "tau")
        {
            Complex tau2;
            tau2 = tau;
            if (UseWhat == "m") { tau2 = _tau_from_m(m); }
            return _thetaS(z, tau2);
        }

        public static Complex ThetaS_M(Complex z, Complex m)
        {
            Complex tau2 = _tau_from_m(m);
            return _thetaS(z, tau2);
        }

        public static Complex ThetaS_Tau(Complex z, Complex tau)
        {
            return _thetaS(z, tau);
        }


        /// <summary>
        /// Neville C-theta function. Only one of the parameters `tau` or `m` must be supplied.
        /// </summary>
        public static Complex thetaC(Complex z, Complex tau, Complex m, string UseWhat = "tau")
        {
            if (UseWhat == "m") { tau = _check_and_get_tau_from_m(tau, m); }
            return _thetaC(z, tau);
        }

        /// <summary>
        /// Neville D-theta function. Only one of the parameters `tau` or `m` must be supplied.
        /// </summary>
        public static Complex thetaD(Complex z, Complex tau, Complex m, string UseWhat = "tau")
        {
            if (UseWhat == "m") { tau = _check_and_get_tau_from_m(tau, m); }
            return _thetaD(z, tau);
        }

        /// <summary>
        /// Neville N-theta function. Only one of the parameters `tau` or `m` must be supplied.
        /// </summary>
        public static Complex thetaN(Complex z, Complex tau, Complex m, string UseWhat = "tau")
        {
            if (UseWhat == "m") { tau = _check_and_get_tau_from_m(tau, m); }
            return _thetaN(z, tau);
        }


        /// <summary>
        /// Jacobi elliptic functions. . Only one of the parameters `tau` or `m` must be supplied.
        /// </summary>
        public static Complex jellip(string kind, Complex u, Complex tau, Complex m, string UseWhat = "tau")
        {
            Complex num, den;
            if (kind.Length != 2)
            {
                throw new ArgumentException("The string `kind` must contain two characters.");
            }
            char f1 = kind[0];
            char f2 = kind[1];
            if (!("cdns".Contains(f1) && "cdns".Contains(f2)))
            {
                throw new ArgumentException("Invalid string `kind`.");
            }

            //tau = _check_and_get_tau_from_m(tau, m);
            if (UseWhat == "m") { tau = _check_and_get_tau_from_m(tau, m); }

            if (f1 == 'c')
            {
                num = _thetaC(u, tau);
            }
            else if (f1 == 'd')
            {
                num = _thetaD(u, tau);
            }
            else if (f1 == 'n')
            {
                num = _thetaN(u, tau);
            }
            else
            {
                num = _thetaS(u, tau);
            }
            if (f2 == 'c')
            {
                den = _thetaC(u, tau);
            }
            else if (f2 == 'd')
            {
                den = _thetaD(u, tau);
            }
            else if (f2 == 'n')
            {
                den = _thetaN(u, tau);
            }
            else
            {
                den = _thetaS(u, tau);
            }
            return num / den;
        }


        /// <summary>
        /// Amplitude function. Only one of the parameters `tau` or `m` must be supplied.
        /// </summary>
        public static Complex Am(Complex u, Complex tau, Complex m, string UseWhat = "tau")
        {
            Complex w = Complex.Asin(jellip("sn", u, tau, m, UseWhat));
            int k = (int)(Math.Round((u.Real) / Math.PI) + Math.Round((w.Real) / Math.PI));
            return Math.Pow(-1, k) * w + k * Math.PI;
        }



#endregion






    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion





