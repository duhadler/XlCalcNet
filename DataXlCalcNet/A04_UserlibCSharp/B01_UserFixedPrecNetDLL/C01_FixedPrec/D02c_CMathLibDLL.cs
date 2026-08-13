/* C# */

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the Complex data type
    /// </summary>
    public partial class m53libc
    {


#region FromJulia


        private static bool IsOdd(int n)
        {
            return n % 2 != 0;
        }

        private static Complex SignFlip(int m, Complex z)
        {
            return (m % 2 == 0) ? z : -z;
        }

//        private static bool IsInfinite(Complex z)
//        { return (math53.isinf(z.Real) || math53.isinf(z.Imaginary)); }

        private static Complex CotPi(Complex z)
        {
            return 1.0 / cmath53.tan(Math.PI * z);
        }




        public static Complex GenZeta(Complex s, Complex z)
        {
            //if (z == 1 || z == 0) return zeta(s);

            // handle nan cases
            if (Double.IsNaN(s.Real) || Double.IsNaN(z.Real))
            {
                return Double.IsNaN(s.Real) ? Double.NaN : Double.NaN + Double.NaN * Complex.ImaginaryOne;
            }

            Double x = z.Real;

            // annoying s = Inf case:
            if (IsInfinite(s))
            {
                if (s.Real == Double.PositiveInfinity)
                {
                    if (x > 1 || (x >= 0.5 ? Complex.Abs(z) > 1 : Complex.Abs(z - Math.Round(x)) > 1))
                    {
                        return Complex.Zero; // distance to poles is > 1
                    }
                    if ((x > 0) && z.Imaginary == 0 && s.Imaginary == 0) return Double.PositiveInfinity;
                }
                throw new ArgumentException("`s` must be finite.");  // nothing clever to return
            }

            Complex m = s - 1;
            Complex zeta = Complex.Zero;

            Double cutoff = 7 + m.Real + Math.Abs(m.Imaginary);
            if (x < cutoff)
            {
                // shift using recurrence formula
                Double xf = Math.Floor(x);
                int nx = (int)xf;
                int n = (int)Math.Ceiling(cutoff - nx);
                Complex minus_s = -s;

                if (nx < 0) // x < 0
                {
                    // need to use (-z)^(-s) recurrence to be correct for real z < 0
                    Complex minus_z = -z;
                    zeta += Complex.Pow(minus_z, minus_s); // ν = 0 term
                    if (xf != z.Real)
                    {
                        zeta += Complex.Pow(z - nx, minus_s);
                    }

                    if (s.Real > 0)
                    {
                        for (int ν = -nx - 1; ν <= -1; ν++)
                        {
                            Complex Zeta0 = zeta;
                            zeta += Complex.Pow(minus_z - ν, minus_s);
                            if (zeta == Zeta0) break; // prevent long loop for large -x > 0
                        }
                    }
                    else
                    {
                        for (int ν = 1; ν >= -nx - 1; ν--)
                        {
                            Complex Zeta0 = zeta;
                            zeta += Complex.Pow(minus_z - ν, minus_s);
                            if (zeta == Zeta0) break; // prevent long loop for large -x > 0
                        }
                    }
                }
                else // x ≥ 0 && z != 0
                {
                    zeta += Complex.Pow(z, minus_s);
                }

                if (s.Real > 0)
                {
                    for (int ν = Math.Max(1, 1 - nx); ν <= n - 1; ν++)
                    {
                        Complex Zeta0 = zeta;
                        zeta += Complex.Pow(z + ν, minus_s);
                        if (zeta == Zeta0) break; // prevent long loop for large m
                    }
                }
                else
                {
                    for (int ν = n - 1; ν >= Math.Max(1, 1 - nx); ν--)
                    {
                        Complex Zeta0 = zeta;
                        zeta += Complex.Pow(z + ν, minus_s);
                        if (zeta == Zeta0) break; // prevent long loop for large m
                    }
                }
                z += n;
            }

            Complex t = 1 / z;
            Complex w = Complex.Pow(t, m);
            zeta += w * (1 / m + 0.5 * t);

            t *= t; // 1/z^2

            Double[] p = new Double[] { 0.08333333333333333, -0.008333333333333333, 0.003968253968253968, -0.004166666666666667, 0.007575757575757576, -0.021092796092796094, 0.08333333333333333, -0.4432598039215686, 3.0539543302701198 };

            int k1 = p.Length;
            Complex ex = (m + 2 * k1 - 1) * (m + 2 * k1 - 2) * (p[k1 - 1] / ((2 * k1 - 1) * (2 * k1 - 2)));
            for (int k = k1 - 1; k >= 2; k--)
            {
                Double cdiv = 1.0 / ((2.0 * k - 1) * (2.0 * k - 2));
                ex = (cdiv * (m + 2 * k - 1) * (m + 2 * k - 2)) * (p[k - 1] + t * ex);
            }
            Complex pg = (m + 1) * (p[0] + t * ex);

            return zeta + w * t * pg;
        }





        private static Double[] CotDerivQ(int m)
        {
            if (m < 0)
                throw new ArgumentException("`m` must be nonnegative.");
            if (m == 0)
                return new Double[] { 1.0 };
            if (m == 1)
                return new Double[] { 1.0, 1.0 };
            Double[] q_ = CotDerivQ(m - 1);
            int d = q_.Length - 1;
            Double[] q;
            if (IsOdd(m - 1))
            {
                q = new Double[q_.Length];
                q[q.Length - 1] = d * q_[q_.Length - 1] * 2 / m;
                for (int i = 0; i < q.Length - 1; i++)
                    q[i] = ((i - 0) * q_[i] + (i + 1) * q_[i + 1]) * 2 / m;
            }
            else
            {
                q = new Double[q_.Length + 1];
                q[0] = q_[0] / m;
                q[q.Length - 1] = (1 + 2 * d) * q_[q_.Length - 1] / m;
                for (int i = 1; i < q.Length - 1; i++)
                    q[i] = ((1 + 2 * (i - 0)) * q_[i] + (1 + 2 * (i - 1)) * q_[i - 1]) / m;
            }
            return q;
        }

        private static Complex CotDeriv(int m, Complex z)
        {
            if (IsInfinite(z.Imaginary))
                return 0.0;
            if (m <= 0)
            {
                if (m == 0)
                    return Math.PI * CotPi(z);

                throw new ArgumentException("`m` must be nonnegative.");
            }
            if (m <= 100)
            {
                Double[] q = CotDerivQ(m);
                Complex x = CotPi(z);
                Complex y = x * x;
                Complex s = q[0] + q[1] * y;
                Complex t = y;
                for (int i = 2; i < q.Length; i++)
                {
                    t *= y;
                    s += q[i] * t;
                }
                return Complex.Pow(Math.PI, m + 1) * (m % 2 == 1 ? s : x * s);
            }
            else
            {
                //Console.WriteLine("in asymptotic");
                int p = m + 1;
                z -= Math.Round(z.Real);
                Complex s = 1.0 / Complex.Pow(z, p);
                int n = 1;
                Complex sO = Complex.Zero;
                while (s != sO)
                {
                    sO = s;
                    Complex a = Complex.Pow(z + n, p);
                    Complex b = Complex.Pow(z - n, p);
                    s += (a + b) / (a * b);
                    n += 1;
                }
                return s;
            }
        }


        public static Complex polygamma(int m, Complex z)
        {
            if (m == 0) return cmath53.psi(z);
            if (m < 0) return new Complex(Double.NaN, Double.NaN);
            Double s = m + 1;
            if (z.Real <= 0) // reflection formula
            {
                Complex ct = CotDeriv(m, z);
                return (GenZeta(s, 1 - z) + SignFlip(m, ct)) * (-cmath53.gamma(s));
            }
            else
            {
                return SignFlip(m, GenZeta(s, z) * (-cmath53.gamma(s)));
            }
        }

#endregion




    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion





