using System;
using ArbPrecNet;
using FixedPrecNet;

namespace Distributions
{



    static class DistFromBoost
    {

        // Dim AcbParamsNC As ArbMatC = apc_mat.set_ones(100, 1)
        private static ArbMatC AcbParamsNC = aflintc.mat_ones(100, 1);

        internal const int mp_df1_pos = 1;
        internal const int mp_df2_pos = 2;
        internal const int mp_nc_pos = 3;
        internal const int mp_order = 4;


        public static Arb Arb_Cauchy_pdf(Arb x, Arb a, Arb b, bool log)
        {
            var pi_inv = 1 / aflint.pi();
            var result = pi_inv * b / ((x - a) * (x - a) + b * b);
            return result;
        }


        public static Arb Arb_Cauchy_CDF(Arb x, Arb a, Arb b, bool lower_tail, bool log)
        {
            Arb result = new Arb(), pi_inv = new Arb();
            pi_inv = 1 / aflint.pi();
            result = 0.5d + pi_inv * aflint.atan((x - a) / b);
            return 1 - result;
        }


        public static Arb Arb_Cauchy_ICDF(Arb p, Arb a, Arb b, bool lower_tail, bool log)
        {
            Arb result = new Arb(), pi = new Arb();
            var half = aflint.t("0.5");
            pi = aflint.pi();
            if (p == half)
                return a;
            if (p < half)
                return a - b / aflint.tan(pi * p);
            else
                return a - b / aflint.tan(pi * (1 - p));
        }



        public static Arb Arb_Exp_pdf(Arb x, Arb lambda, bool log_p)
        {
            var result = new Arb();
            result = lambda * aflint.exp(-lambda * x);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Exp_CDF(Arb x, Arb lambda, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = -aflint.expm1(-x * lambda);
            else
                result = aflint.exp(-x * lambda);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Exp_ICDF(Arb prob, Arb lambda, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), p = new Arb();
            if (log_p)
                p = aflint.exp(prob);
            else
                p = prob;
            if (lower_tail)
                result = -aflint.log1p(-p) / lambda;
            else
                result = -aflint.log(p) / lambda;
            return result;
        }


        public static Arb Arb_Gumbel_pdf(Arb x, Arb a, Arb b, bool log_p)
        {
            Arb result = new Arb(), c = new Arb();
            c = aflint.exp(-(x - a) / b);
            result = c * aflint.exp(-c) / b;
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Gumbel_CDF(Arb x, Arb a, Arb b, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), c = new Arb();
            c = aflint.exp(-(x - a) / b);
            if (lower_tail)
                result = aflint.exp(-c);
            else
                result = -aflint.expm1(-c);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Gumbel_ICDF(Arb prob, Arb a, Arb b, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), p = new Arb();
            if (log_p)
                p = aflint.exp(prob);
            else
                p = prob;
            if (lower_tail)
                result = a - aflint.log(-aflint.log(p)) * b;
            else
                result = a - aflint.log(-aflint.log1p(-p)) * b;
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Geom_pdf(Arb k, Arb p, bool log_p)
        {
            var result = new Arb();
            result = p * aflint.exp(k * aflint.log1p(-p));
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Geom_CDF(Arb k, Arb p, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            // If lower_tail Then result = 1 - (1 - p) ^ (k + 1) Else result = aflint.exp(aflint.log1p(-p) * (k + 1))
            if (lower_tail)
                result = 1 - aflint.pow(1 - p, k + 1);
            else
                result = aflint.exp(aflint.log1p(-p) * (k + 1));
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Geom_ICDF(Arb prob, Arb p, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), prob1 = new Arb();
            if (log_p)
                prob1 = aflint.exp(prob);
            else
                prob1 = prob;
            if (lower_tail)
                result = aflint.log1p(-prob1) / aflint.log1p(-p) - 1;
            else
                result = aflint.log(prob1) / aflint.log1p(-p) - 1;
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_InvGauss_pdf(Arb x, Arb mu, Arb lambda, bool log_p)
        {
            Arb result = new Arb(), pi = new Arb();
            pi = aflint.pi();
            result = aflint.sqrt(lambda / (2 * pi * x * x * x)) * aflint.exp(-lambda * (x - mu) * (x - mu) / (2 * mu * mu * x));
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_InvGauss_CDF(Arb x, Arb mean, Arb scale, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), cdf1 = new Arb(), cdf2 = new Arb(), cdf = new Arb();
            Arb n0 = new Arb(), n1 = new Arb(), n3 = new Arb(), n4 = new Arb(), expfactor = new Arb();
            n0 = aflint.sqrt(scale / x);
            n0 *= x / mean - 1;
            // n1 = aflint.ndist(n0)
            expfactor = aflint.exp(2 * scale / mean);
            n3 = -aflint.sqrt(scale / x);
            n3 *= x / mean + 1;
            // n4 = aflint.ndist(n3)
            cdf = n1 + expfactor * n4;

            // normal_distribution<RealType> n01;
            // RealType n0 = sqrt(scale / x);
            // n0 *= ((x / mean) -1);
            // RealType cdf_1 = cdf(complement(n01, n0));
            // 
            // RealType expfactor = exp(2 * scale / mean);
            // RealType n3 = - sqrt(scale / x);
            // n3 *= (x / mean) + 1;
            // 
            // //RealType n5 = +sqrt(scale/x) * ((x /mean) + 1); // note now positive sign.
            // RealType n6 = cdf(complement(n01, +sqrt(scale/x) * ((x /mean) + 1)));
            // // RealType n4 = cdf(n01, n3); // = 
            // result = cdf_1 - expfactor * n6; 
            // return result;


            if (lower_tail)
                result = cdf;
            else
                result = 1 - cdf;
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Laplace_pdf(Arb x, Arb location, Arb scale, bool log_p)
        {
            Arb result = new Arb(), exponent = new Arb();
            exponent = x - location;
            if (exponent > 0)
                exponent = -exponent;
            exponent /= scale;
            result = aflint.exp(exponent);
            result /= 2 * scale;
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Laplace_CDF(Arb x, Arb location, Arb scale, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), cdf1 = new Arb(), cdf2 = new Arb();
            if (x < location)
                cdf1 = aflint.exp((x - location) / scale) / 2;
            else
                cdf1 = 1 - aflint.exp((location - x) / scale) / 2;
            if (-x < -location)
                cdf2 = aflint.exp((-x + location) / scale) / 2;
            else
                cdf2 = 1 - aflint.exp((-location + x) / scale) / 2;
            if (lower_tail)
                result = cdf1;
            else
                result = cdf2;
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static Arb Arb_Laplace_ICDF(Arb prob, Arb location, Arb scale, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), prob1 = new Arb(), q = new Arb(), ICDF1 = new Arb(), ICDF2 = new Arb();
            if (log_p)
                prob1 = aflint.exp(prob);
            else
                prob1 = prob;
            q = 1 - prob1;
            if (prob1 - 0.5d < 0)
                ICDF1 = location + scale * aflint.log(prob1 * 2);
            else
                ICDF1 = location - scale * aflint.log(-prob1 * 2 + 2);
            if (0.5d - q < 0)
                ICDF2 = location + scale * aflint.log(-q * 2 + 2);
            else
                ICDF2 = location - scale * aflint.log(q * 2);
            if (lower_tail)
                result = ICDF1;
            else
                result = ICDF2;
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Logistic_pdf(Arb x, Arb location, Arb scale, bool log_p)
        {
            Arb result = new Arb(), c = new Arb();
            c = aflint.exp(-(x - location) / scale);
            // result = c / (scale * (1 + c) ^ 2)
            result = c / (scale * aflint.pow(1 + c, 2));
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Logistic_CDF(Arb x, Arb location, Arb scale, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = 1 / (1 + aflint.exp(-(x - location) / scale));
            else
                result = 1 / (1 + aflint.exp((x - location) / scale));
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Logistic_ICDF(Arb prob, Arb location, Arb scale, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), prob1 = new Arb();
            if (log_p)
                prob1 = aflint.exp(prob);
            else
                prob1 = prob;
            if (lower_tail)
                result = location - scale * aflint.log(1 / (prob1 - 1));
            else
                result = location + scale * aflint.log(prob1 / (1 - prob1));
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_LogNormal_pdf(Arb x, Arb mu, Arb sigma, bool log_p)
        {
            Arb result = new Arb(), exponent = new Arb(), pi = new Arb();
            pi = aflint.pi();
            exponent = aflint.log(x) - mu;
            exponent *= -exponent;
            exponent /= 2 * sigma * sigma;
            result = aflint.exp(exponent);
            result /= sigma * aflint.sqrt(2 * pi) * x;
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_LogNormal_CDF(Arb x, Arb mu, Arb sigma, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            result = Arb_Normal_CDF(aflint.log(x), mu, sigma, lower_tail, log_p);
            return result;
        }



        public static Arb Arb_Normal_pdf(Arb x, Arb mu, Arb sigma, bool log_p)
        {
            Arb result = new Arb(), exponent = new Arb(), pi = new Arb();
            result = aflint.exp(-(x - mu) * (x - mu) / (2 * sigma * sigma)) / (sigma * aflint.sqrt(2 * aflint.pi()));
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Normal_CDF(Arb x, Arb mu, Arb sigma, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
            {
                result = 0.5d * aflint.erfc(-(x - mu) / (sigma * aflint.sqrt(2)));
            }
            else
            {
                result = 0.5d * aflint.erfc((x - mu) / (sigma * aflint.sqrt(2)));
            }
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static ArbC Acb_Beta_pdf(ArbC x, ArbC a, ArbC b, bool log_p)
        {
            var result = new ArbC();

            // Not yet implemented !!!
            result = aflintc.ibeta_derivative(a, b, x);
            if (log_p)
                result = aflintc.log(result);
            return result;
        }



        public static Arb Arb_Beta_pdf(Arb x, Arb a, Arb b, bool log_p)
        {
            var result = new Arb();

            // Not yet implemented !!!
            result = aflint.ibeta_derivative(a, b, x);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Beta_CDF(Arb x, Arb a, Arb b, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = aflint.ibeta(a, b, x);
            else
                result = aflint.ibetac(a, b, x);
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static Arb Arb_Binom_pdf(Arb k, Arb n, Arb p, bool log_p)
        {
            var result = new Arb();
            result = aflint.ibeta_derivative(k + 1, n - k + 1, p) / (n + 1);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Binom_CDF(Arb k, Arb n, Arb p, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = aflint.ibetac(k + 1, n - k, p);
            else
                result = aflint.ibeta(k + 1, n - k, p);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_ChiSquare_pdf(Arb x, Arb nu, bool log_p)
        {
            var result = new Arb();
            result = aflint.gamma_p_derivative(nu / 2, x / 2) / 2;
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static ArbC Acb_ChiSquare_pdf(ArbC x, ArbC nu, bool log_p)
        {
            var result = new ArbC();
            result = aflintc.gamma_p_derivative(nu / 2, x / 2) / 2;
            if (log_p)
                result = aflintc.log(result);
            return result;
        }




        public static Arb Arb_ChiSquare_CDF(Arb x, Arb nu, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            // Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
            if (lower_tail)
                result = aflint.gamma_p(nu / 2, x / 2);
            else
                result = aflint.gamma_q(nu / 2, x / 2);
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        // Function Arb_ChiSquare_CDF(x As Arb, nu As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        // Dim result As New Arb
        // ' Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
        // Dim LeftTail As Arb, RightTail As Arb, density As Arb
        // cdis2(nu, x, LeftTail, RightTail, density)
        // If lower_tail Then result = LeftTail Else result = RightTail
        // If log_p Then result = aflint.log(result)
        // Return result
        // End Function



        public static ArbC Acb_F_pdf(ArbC x, ArbC df1, ArbC df2, bool log_p)
        {
            ArbC result = new ArbC(), v1x = new ArbC();
            v1x = df1 * x;
            if (aflintc.abs(v1x) > aflintc.abs(df2))
            {
                result = df2 * df1 / ((df2 + v1x) * (df2 + v1x));
                result *= aflintc.ibeta_derivative(df2 / 2, df1 / 2, df2 / (df2 + v1x));
            }
            else
            {
                result = df2 + df1 * x;
                result = (result * df1 - x * df1 * df1) / (result * result);
                result *= aflintc.ibeta_derivative(df1 / 2, df2 / 2, v1x / (df2 + v1x));
            }
            if (log_p)
                result = aflintc.log(result);
            return result;
        }


        public static Arb Arb_F_pdf(Arb x, Arb df1, Arb df2, bool log_p)
        {
            Arb result = new Arb(), v1x = new Arb();
            v1x = df1 * x;
            if (aflint.abs(v1x) > aflint.abs(df2))
            {
                result = df2 * df1 / ((df2 + v1x) * (df2 + v1x));
                result *= aflint.ibeta_derivative(df2 / 2, df1 / 2, df2 / (df2 + v1x));
            }
            else
            {
                result = df2 + df1 * x;
                result = (result * df1 - x * df1 * df1) / (result * result);
                result *= aflint.ibeta_derivative(df1 / 2, df2 / 2, v1x / (df2 + v1x));
            }
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_F_CDF(Arb x, Arb df1, Arb df2, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), v1x = new Arb(), cdf1 = new Arb(), cdf2 = new Arb();
            // Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
            v1x = df1 * x;
            if (v1x > df2)
            {
                cdf1 = aflint.ibetac(df2 / 2, df1 / 2, df2 / (df2 + v1x));
            }
            else
            {
                cdf1 = aflint.ibeta(df1 / 2, df2 / 2, v1x / (df2 + v1x));
            }

            if (v1x > df2)
            {
                cdf2 = aflint.ibeta(df2 / 2, df1 / 2, df2 / (df2 + v1x));
            }
            else
            {
                cdf2 = aflint.ibetac(df1 / 2, df2 / 2, v1x / (df2 + v1x));
            }

            if (lower_tail)
                result = cdf1;
            else
                result = cdf2;
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static Arb Arb_Gamma_pdf(Arb x, Arb k, Arb theta, bool log_p)
        {
            var result = new Arb();
            result = aflint.gamma_p_derivative(k, x / theta) / theta;
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Gamma_CDF(Arb x, Arb k, Arb theta, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = aflint.gamma_p(k, x / theta);
            else
                result = aflint.gamma_q(k, x / theta);
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static Arb Arb_Invchisq_pdf(Arb x, Arb df, Arb scale, bool log_p)
        {
            var result = new Arb();
            result = df * scale / 2 / x;
            result = aflint.gamma_p_derivative(df / 2, result) * df * scale / 2;
            result /= x * x;
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Invchisq_CDF(Arb x, Arb df, Arb scale, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = aflint.gamma_q(df / 2, df * (scale / 2) / x);
            else
                result = aflint.gamma_p(df / 2, df * scale / 2 / x);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_InvGamma_pdf(Arb x, Arb shape, Arb scale, bool log_p)
        {
            var result = new Arb();
            result = aflint.pow(scale, shape) * aflint.pow(x, -shape - 1) * aflint.exp(-scale / x) / aflint.gamma(shape);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_InvGamma_CDF(Arb x, Arb shape, Arb scale, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = aflint.gamma_q(shape, scale / x);
            else
                result = aflint.gamma_p(shape, scale / x);
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static Arb Arb_Nbinom_pdf(Arb k, Arb r, Arb p, bool log_p)
        {
            var result = new Arb();
            result = p / (r + k) * aflint.ibeta_derivative(r, k + 1, p);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Nbinom_CDF(Arb k, Arb r, Arb p, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = aflint.ibeta(r, k + 1, p);
            else
                result = aflint.ibetac(r, k + 1, p);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_T_pdf(Arb x, Arb df, bool log_p)
        {
            Arb result = new Arb(), basem1 = new Arb();
            var E8 = aflint.t(0.125d);
            basem1 = x * x / df;
            if (basem1 < E8)
            {
                result = aflint.exp(-aflint.log1p(basem1) * (1 + df) / 2);
            }
            else
            {
                result = aflint.pow(1 / (1 + basem1), (df + 1) / 2);
            }
            result /= aflint.sqrt(df) * aflint.beta(df / 2, 0.5d);

            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_T_CDF(Arb x, Arb df, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), x2 = new Arb(), z = new Arb(), probability = new Arb(), cdf1 = new Arb(), cdf2 = new Arb();

            x2 = x * x;
            if (df > 2 * x2)
            {
                z = x2 / (df + x2);
                probability = aflint.ibetac(0.5d, df / 2, z) / 2;
            }
            else
            {
                z = df / (df + x2);
                probability = aflint.ibeta(df / 2, 0.5d, z) / 2;
            }
            if (x > 0)
                cdf1 = 1 - probability;
            else
                cdf1 = probability;
            if (x > 0)
                cdf2 = probability;
            else
                cdf2 = 1 - probability;

            if (lower_tail)
                result = cdf1;
            else
                result = cdf2;
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Pareto_pdf(Arb x, Arb scale, Arb shape, bool log_p)
        {
            Arb result = new Arb(), c = new Arb();
            if (x < scale)
                result = aflint.t(0);
            else
                result = shape * aflint.pow(scale, shape) / aflint.pow(x, shape + 1);
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Pareto_CDF(Arb x, Arb scale, Arb shape, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = 1 - aflint.pow(scale / x, shape);
            else
                result = aflint.pow(scale / x, shape);
            // If lower_tail Then result = 1 - (scale / x) ^ shape Else result = (scale / x) ^ shape
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Pareto_ICDF(Arb prob, Arb scale, Arb shape, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), prob1 = new Arb();
            if (log_p)
                prob1 = aflint.exp(prob);
            else
                prob1 = prob;
            if (lower_tail)
                result = scale / aflint.pow(1 - prob1, 1 / shape);
            else
                result = scale / aflint.pow(1 - prob1, 1 / shape);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Poisson_pdf(Arb k, Arb mean, bool log_p)
        {
            var result = new Arb();
            result = aflint.gamma_p_derivative(k + 1, mean);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Poisson_CDF(Arb k, Arb mean, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = aflint.gamma_q(k + 1, mean);
            else
                result = aflint.gamma_p(k + 1, mean);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_RayLeigh_pdf(Arb x, Arb sigma, bool log_p)
        {
            Arb result = new Arb(), sigmasqr = new Arb();
            sigmasqr = sigma * sigma;
            result = x * aflint.exp(-(x * x) / (2 * sigmasqr)) / sigmasqr;
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_RayLeigh_CDF(Arb x, Arb sigma, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = aflint.expm1(-x * x / (2 * sigma * sigma));
            else
                result = aflint.exp(-(x * x) / (2 * sigma * sigma));
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_RayLeigh_ICDF(Arb prob, Arb sigma, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), prob1 = new Arb();
            if (log_p)
                prob1 = aflint.exp(prob);
            else
                prob1 = prob;
            if (lower_tail)
                result = aflint.sqrt(-2 * sigma * sigma * aflint.log1p(-prob1));
            else
                result = aflint.sqrt(-2 * sigma * sigma * aflint.log(1 - prob1));
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static Arb Arb_Weibull_pdf(Arb x, Arb shape, Arb scale, bool log_p)
        {
            Arb result = new Arb(), c = new Arb();
            result = aflint.exp(-aflint.pow(x / scale, shape));
            result *= aflint.pow(x / scale, shape - 1) * shape / scale;
            if (log_p)
                result = aflint.log(result);
            return result;
        }



        public static Arb Arb_Weibull_CDF(Arb x, Arb shape, Arb scale, bool lower_tail, bool log_p)
        {
            var result = new Arb();
            if (lower_tail)
                result = -aflint.expm1(-aflint.pow(x / scale, shape));
            else
                result = aflint.exp(-aflint.pow(x / scale, shape));
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Weibull_ICDF(Arb prob, Arb shape, Arb scale, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), prob1 = new Arb();
            if (log_p)
                prob1 = aflint.exp(prob);
            else
                prob1 = prob;
            if (lower_tail)
                result = scale * aflint.pow(-aflint.log1p(-prob1), 1 / shape);
            else
                result = scale * aflint.pow(-aflint.log(1 - prob1), 1 / shape);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Uniform_pdf(Arb x, Arb lower, Arb upper, bool log_p)
        {
            var result = new Arb();
            if (x < lower | x > upper)
                result = aflint.t(0);
            else
                result = 1 / (upper - lower);
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Uniform_CDF(Arb x, Arb lower, Arb upper, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), cdf1 = new Arb(), cdf2 = new Arb();
            if (x < lower | x > upper)
            {
                if (x < lower)
                {
                    cdf1 = aflint.t(0);
                    cdf2 = aflint.t(1);
                }
                else
                {
                    cdf1 = aflint.t(1);
                    cdf2 = aflint.t(0);
                }
            }
            else
            {
                cdf1 = (x - lower) / (upper - lower);
                cdf2 = (upper - x) / (upper - lower);
            }
            if (lower_tail)
                result = cdf1;
            else
                result = cdf2;
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static Arb Arb_Uniform_ICDF(Arb prob, Arb lower, Arb upper, bool lower_tail, bool log_p)
        {
            Arb result = new Arb(), prob1 = new Arb(), icdf1 = new Arb(), icdf2 = new Arb();
            if (log_p)
                prob1 = aflint.exp(prob);
            else
                prob1 = prob;
            if (prob1 == 0 | prob1 == 0)
            {
                if (prob1 == 0)
                {
                    icdf1 = lower;
                    icdf2 = upper;
                }
                else
                {
                    icdf1 = upper;
                    icdf2 = lower;
                }
            }
            else
            {
                icdf1 = prob1 * (upper - lower) + lower;
                icdf2 = -(1 - prob1) * (upper - lower) + upper;
            }
            if (lower_tail)
                result = icdf1;
            else
                result = icdf2;
            if (log_p)
                result = aflint.log(result);
            return result;
        }

        public static ArbC Acb_GammaStar(ArbC t, ArbC nu, ArbC z)
        {
            ArbC d = new ArbC(), c = new ArbC(), result = new ArbC();
            c = aflint.pow(z, nu) / aflintc.gamma(nu);
            d = aflint.pow(t, nu - 1) * aflintc.exp(-z * t);
            result = c * d;
            return result;
        }


        public static ArbC Acb_GammaStar2(ArbC t, ArbC nu, ArbC z, ArbC a)
        {
            ArbC d = new ArbC(), c = new ArbC(), result = new ArbC();
            c = aflint.pow(z, nu) / aflintc.gamma(nu);
            d = aflintc.exp(-z * t);
            result = c * d;
            return result;
        }


        // Function AcbIntegrand_NC(x As ArbC, params2 As ArbMatC) As ArbC
        public static ArbC AcbIntegrand_NC(ArbC x, ArbMatC params2)
        {
            // Dim proc_outer As Int32 = AcbParamsNC(mp_proc_outer_pos).real.ToInt32
            int proc_outer = aflint.lrint(AcbParamsNC[DistMCPArb.mp_proc_outer_pos].real);
            var fx = new ArbC();
            var df1 = AcbParamsNC[mp_df1_pos];
            var df2 = AcbParamsNC[mp_df2_pos];
            var nc = AcbParamsNC[mp_nc_pos];
            switch (proc_outer)
            {
                case DistMCPArb.mp_integral_chisquare_nc:
                    {
                        fx = Acb_ChiSquare_NC_pdf(x, df1, nc, false);
                        break;
                    }
                case DistMCPArb.mp_integral_chisquare:
                    {
                        fx = Acb_ChiSquare_pdf(x, df1, false);
                        break;
                    }
                case DistMCPArb.mp_integral_gammastar:
                    {
                        fx = Acb_GammaStar(x, df1, df2);
                        break;
                    }
                case DistMCPArb.mp_integral_gammastar2:
                    {
                        fx = Acb_GammaStar2(x, df1, df2, nc);
                        break;
                    }
                case DistMCPArb.mp_integral_t_nc:
                    {
                        fx = Acb_T_NC_pdf(x, df1, nc, false);
                        break;
                    }
                case DistMCPArb.mp_integral_f_nc:
                    {
                        fx = Acb_F_NC_pdf(x, df1, df2, nc, false);
                        break;
                    }
                case DistMCPArb.mp_integral_beta_nc:
                    {
                        fx = Acb_Beta_NC_pdf(x, df1, df2, nc, false);
                        break;
                    }
                // Case mp_integral_rho : fx = Acb_Rho_pdf(df1.real.ToInt32, x, nc)
                case DistMCPArb.mp_integral_rho:
                    {
                        fx = Acb_Rho_pdf(aflint.lrint(df1.real), x, nc);
                        break;
                    }
                case DistMCPArb.mp_integral_rho2:
                    {
                        fx = Acb_Rho2_pdf(x, df1, df2, nc, false);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("!!!! Error AcbIntegrand_NC !!!!!)");
                        fx = aflintc.nan();
                        break;
                    }
            }
            // Console.WriteLine("fx: {0}", fx)
            return fx;
        }

        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If Win64 Then
        */
        public static void WrapperParams_GL_NC(IntPtr fxPtr, IntPtr xPtr, IntPtr paramsPtr, ulong order, ulong prec)
        {
            /* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            *//* TODO ERROR: Skipped DisabledTextTrivia
                    Sub WrapperParams_GL_NC(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt32, ByVal prec As UInt32)
            *//* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */        // Dim old_prec = mp4.getprec()
                      // Console.WriteLine("In WrapperParams_GL_Outer: order: {0}, prec: {1}, paramsPtr: {2}", order, prec, paramsPtr)
                      // mp4.setprec(CUInt(prec))
                      // Dim x As New ArbC(xPtr, True)
                      // Dim fx As New ArbC()
                      // fx = AcbIntegrand_NC(x, Nothing)
                      // fx.CopyToPtr(fxPtr)
                      // mp4.setprec(old_prec)
        }


        public static void DemoAcbIntegrationChiSquare()
        {
            // mp4.setprec(400)
            AcbParamsNC[0] = aflintc.t(DistMCPArb.mp_integral_chisquare);
            int x = 5000000 - 0;
            int nu = 5000000;
            //int lambda = 0;
            // Dim result = dreal.dist_pchisq(x, nu, True)
            // Console.WriteLine("    result: {0}", result)


            AcbParamsNC[mp_df1_pos] = aflintc.t(nu);
            AcbParamsNC[mp_nc_pos] = aflintc.t(0);
            // Dim s, a, b As New ArbC
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 2U;
            var a = aflint.t(0);
            var b = aflint.t(x);
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint rel_goal = 150U;
            //uint abs_tol_bits = 150U;
            //uint eval_limit = 0U;
            // Dim s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            // Dim alpha = 1
            // Dim beta = 1
            // Dim epsabsStart = aflint.t("1.0E-15")
            // epsabsStart = epsabsStart * result
            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)
        }

        public static void DemoAcbIntegrationGammaStar()
        {
            // mp4.setprec(400)
            AcbParamsNC[0] = aflintc.t(DistMCPArb.mp_integral_gammastar);
            int z = 49999;
            int nu = 50000;
            //int lambda = 0;
            var result = new Arb();
            // Dim result = dreal.dist_pchisq(X, nu, True)
            // Console.WriteLine("    result: {0}", result)


            AcbParamsNC[mp_df1_pos] = aflintc.t(nu);
            AcbParamsNC[mp_df2_pos] = aflintc.t(z);
            // Dim s, a, b As New ArbC
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 1U;
            //double a = 0.0d;
            //double b = 1.0d;
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint rel_goal = 153U;
            //uint abs_tol_bits = 153U;
            //uint eval_limit = 0U;
            // Dim s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)


            // Dim alpha = 0.999
            // Dim beta = 1.0
            // a = 0.95
            // b = 1.0
            // Dim epsabsStart = aflint.t("1.0E-15")
            // epsabsStart = epsabsStart '* result
            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)

            // a = 0.8
            // b = 0.9
            // epsabsStart = epsabsStart '* result
            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)

            // a = 0.9
            // b = 1.0
            // epsabsStart = epsabsStart '* result
            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)


            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, 0, 0.5, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)

            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, 0.5, 1.0, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)


            // AcbParamsNC(0) = mp_integral_gammastar2
            // a = 0.0
            // b = 1.0
            // AcbParamsNC(mp_nc_pos) = a
            // alpha = nu
            // beta = 1
            // epsabsStart = aflint.t("1.0E-15")
            // epsabsStart = epsabsStart '* result
            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)

            // a = 0.0
            // b = 0.5
            // AcbParamsNC(mp_nc_pos) = a
            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)

            // a = 0.5
            // b = 1.0
            // AcbParamsNC(mp_nc_pos) = a
            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)

        }


        public static void DemoAcbIntegrationChiSquareNC()
        {
            // mp4.setprec(100)
            AcbParamsNC[0] = aflintc.t(DistMCPArb.mp_integral_chisquare_nc);
            int x = 1050;
            int nu = 80;
            int lambda = 850;
            // Dim result = dreal.dist_pchisq_nc(x, nu, lambda, True)
            // Console.WriteLine("    result: {0}", result)


            AcbParamsNC[mp_df1_pos] = aflintc.t(nu);
            AcbParamsNC[mp_nc_pos] = aflintc.t(lambda);
            // Dim s, a, b As New ArbC
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 2U;
            var a = aflint.t(899);
            var b = aflint.t(x);
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint eval_limit = 0U;
            // Dim s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            //int alpha = 1;
            //int beta = 1;
            //var epsabsStart = aflint.t("1.0E-15");
            // epsabsStart = epsabsStart * result.value
            // DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
            // Console.WriteLine("result:{0}", result)
        }


        public static bool Includesmode(ArbC x, ArbC nu, ArbC lambda)
        {
            if (x.real.Infimum() < lambda.real.Infimum() & x.real.Supremum() > lambda.real.Supremum())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static ArbC Acb_ChiSquare_NC_pdf(ArbC x, ArbC nu, ArbC lambda, bool log_p)
        {
            int order = aflint.lrint(AcbParamsNC[mp_order].real);
            var result = new ArbC();
            Console.WriteLine("Order: {0}", order);
            if (order == 1)
            {
                if (Includesmode(x, nu, lambda))
                {
                    return aflintc.nan();
                    //// Else
                    //var x1 = new ArbC();
                    //x1 = x;
                    //Arb x1_re = new Arb(), x1_im = new Arb(), av1 = new Arb();
                    //x1_re.Mid = x.real.Supremum();
                    //x1_re.Rad = aflint.t(0);
                    //x1_im.Mid = x.imag.Supremum();
                    //x1_im.Rad = aflint.t(0);
                    //x1 = aflintc.t(x1_re, x1_im);
                    //// x1.real = x1_re
                    //// x1.imag = x1_im
                    //var dens0 = Acb_ChiSquare_pdf(x1, nu, false);
                    //var hyper = aflintc.hyperg_0f1(nu / 2, lambda * x1 / 4);
                    //result = dens0 * aflintc.exp(-lambda / 2) * hyper;
                    //if (log_p)
                    //    result = aflintc.log(result);
                }
            }
            else
            {
                var dens0 = Acb_ChiSquare_pdf(x, nu, false);
                var hyper = aflintc.hyperg_0f1(nu / 2, lambda * x / 4);
                result = dens0 * aflintc.exp(-lambda / 2) * hyper;
                if (log_p)
                    result = aflintc.log(result);

            }
            return result;
        }


        public static Arb Arb_ChiSquare_NC_pdf(Arb x, Arb nu, Arb lambda, bool log_p)
        {
            var dens0 = Arb_ChiSquare_pdf(x, nu, false);
            var hyper = aflint.hyperg_0f1(nu / 2, lambda * x / 4);
            var result = dens0 * aflint.exp(-lambda / 2) * hyper;
            if (log_p)
                result = aflint.log(result);
            return result;
        }

        public static void DemoChiSquareDensity()
        {
            Arb x = new Arb(), nu = new Arb(), lambda = new Arb(), result = new Arb(), dens0 = new Arb(), hyper = new Arb();
            x = aflint.t(12);
            nu = aflint.t(10);
            lambda = aflint.t(3);
            // result = aflint.t(dreal.dist_dchisq_nc(x.AsDouble, nu.AsDouble, lambda.AsDouble))
            // Console.WriteLine("   result: {0}", result)
            result = Arb_ChiSquare_NC_pdf(x, nu, lambda, false);
            Console.WriteLine("   result: {0}", result);
            // Dim resultc = Acb_ChiSquare_NC_pdf(x, nu, lambda, False)
            // Console.WriteLine("   resultc: {0}", resultc)
        }



        public static void DemoAcbIntegrationTNC()
        {
            // mp4.setprec(100)
            AcbParamsNC[0] = aflintc.t(DistMCPArb.mp_integral_t_nc);
            int x = 4;
            int nu = 20;
            int lambda = 5;
            AcbParamsNC[mp_df1_pos] = aflintc.t(nu);
            AcbParamsNC[mp_nc_pos] = aflintc.t(lambda);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            uint workinmrealec = 100U;
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 2U;
            a = aflintc.t(0);
            b = aflintc.t(x);
            uint rel_goal = workinmrealec;
            uint abs_tol_bits = workinmrealec;
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            // Dim resultint = NdisAcb(-lambda) + s
            // Console.WriteLine("resultint:{0}", resultint)
            // Dim result = dreal.dist_pt_nc(x, nu, lambda, True)
            // Console.WriteLine("    result: {0}", result)
        }


        public static ArbC Acb_T_NC_pdf(ArbC x, ArbC n, ArbC delta, bool log_p)
        {
            var m = n / 2;
            var a = n + x * x;
            var d2 = delta * delta;
            var y2 = d2 * x * x / (2 * a);
            var K1 = aflintc.pow(n, m) * aflintc.gamma(n + 1) * aflintc.exp(-0.5d * d2) / (aflintc.pow(2, n) * aflintc.pow(a, m) * aflintc.gamma(m));
            var LSide = aflintc.sqrt(2) * delta * x * aflintc.hyperg_1f1(m + 1, 3d / 2d, y2) / (a * aflintc.gamma(m + 0.5d));
            var RSide = aflintc.hyperg_1f1(m + 0.5d, 0.5d, y2) / (aflintc.sqrt(a) * aflintc.gamma(m + 1));
            var sum = LSide + RSide;
            var result = K1 * sum;
            // Console.WriteLine("result from Acb_T_NC_pdf: ", result)
            if (log_p)
                result = aflintc.log(result);
            return result;
        }


        public static Arb Arb_T_NC_pdf(Arb x, Arb n, Arb delta, bool log_p)
        {
            var m = n / 2;
            var a = n + x * x;
            var d2 = delta * delta;
            var y2 = d2 * x * x / (2 * a);
            var K1 = aflint.pow(n, m) * aflint.gamma(n + 1) * aflint.exp(-0.5d * d2) / (aflint.pow(2, n) * aflint.pow(a, m) * aflint.gamma(m));
            var LSide = aflint.sqrt(2) * delta * x * aflint.hyperg_1f1(m + 1, 3d / 2d, y2) / (a * aflint.gamma(m + 0.5d));
            var RSide = aflint.hyperg_1f1(m + 0.5d, 0.5d, y2) / (aflint.sqrt(a) * aflint.gamma(m + 1));
            var sum = LSide + RSide;
            var result = K1 * sum;
            if (log_p)
                result = aflint.log(result);
            return result;
        }


        public static void DemoTDensity()
        {
            ArbPrec.SetDps(100);
            Arb x = new Arb(), n = new Arb(), delta = new Arb(), result = new Arb();
            var arbresult = new Arb();
            x = aflint.t(4);
            n = aflint.t(13);
            delta = aflint.t(10);
            // result = aflint.t(dreal.dist_dt_nc(x.AsDouble, n.AsDouble, delta.AsDouble))
            Console.WriteLine("   result: {0}", result);
            result = Arb_T_NC_pdf(x, n, delta, false);
            Console.WriteLine("   result: {0}", result);
            // Dim resultc = Acb_T_NC_pdf(x, n, delta, False)
            // Console.WriteLine("   resultc: {0}", resultc)
        }



        public static void DemoAcbIntegrationFNC()
        {
            // mp4.setprec(100)
            AcbParamsNC[0] = aflintc.t(DistMCPArb.mp_integral_f_nc);
            int x = 3;
            int m = 10;
            int n = 20;
            int lambda = 15;
            AcbParamsNC[mp_df1_pos] = aflintc.t(m);
            AcbParamsNC[mp_df2_pos] = aflintc.t(n);
            AcbParamsNC[mp_nc_pos] = aflintc.t(lambda);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 2U;
            a = aflintc.t(0);
            b = aflintc.t(x);
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            // Dim result = dreal.dist_pf_nc(x, m, n, lambda, True)
            // Console.WriteLine("    result: {0}", result)
        }





        public static ArbC Acb_F_NC_pdf(ArbC x, ArbC m, ArbC n, ArbC lambda, bool log_p)
        {
            var dens0 = Acb_F_pdf(x, m, n, false);
            var hyper = aflintc.hyperg_1f1(0.5d * (m + n), 0.5d * m, m * x * lambda / (2 * (n + m * x)));
            var result = dens0 * aflintc.exp(-lambda / 2) * hyper;
            // Console.WriteLine("result from Acb_F_NC_pdf: {0}", result)

            if (log_p)
                result = aflintc.log(result);
            return result;
        }


        public static Arb Arb_F_NC_pdf(Arb x, Arb m, Arb n, Arb lambda, bool log_p)
        {
            var dens0 = Arb_F_pdf(x, m, n, false);
            var hyper = aflint.hyperg_1f1(0.5d * (m + n), 0.5d * m, m * x * lambda / (2 * (n + m * x)));
            var result = dens0 * aflint.exp(-lambda / 2) * hyper;
            if (log_p)
                result = aflint.log(result);
            return result;
        }

        public static void DemoFDensity()
        {
            Arb x = new Arb(), m = new Arb(), n = new Arb(), lambda = new Arb(), result = new Arb();
            Arb arbresult = new Arb(), dens0 = new Arb(), hyper = new Arb();
            x = aflint.t(2);
            m = aflint.t(10);
            n = aflint.t(20);
            lambda = aflint.t(3);
            // result = aflint.t(dreal.dist_df_nc(x.AsDouble, m.AsDouble, n.AsDouble, lambda.AsDouble))
            // Console.WriteLine("   result: {0}", result)
            result = Arb_F_NC_pdf(x, m, n, lambda, false);
            Console.WriteLine("   result: {0}", result);
            // Dim resultc = Acb_F_NC_pdf(x, m, n, lambda, False)
            // Console.WriteLine("   resultc: {0}", resultc)
        }




        public static void DemoAcbIntegrationBetaNC()
        {
            // mp4.setprec(100)
            AcbParamsNC[0] = aflintc.t(DistMCPArb.mp_integral_beta_nc);
            double x = 0.5d;
            int alpha = 10;
            int beta = 20;
            int lambda = 30;
            AcbParamsNC[mp_df1_pos] = aflintc.t(alpha);
            AcbParamsNC[mp_df2_pos] = aflintc.t(beta);
            AcbParamsNC[mp_nc_pos] = aflintc.t(lambda);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 2U;
            a = aflintc.t(0);
            b = aflintc.t(x);
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            // Dim result = dreal.dist_pbeta_nc(x, alpha, beta, lambda, True)
            // Console.WriteLine("    result: {0}", result)
        }


        public static ArbC Acb_Beta_NC_pdf(ArbC x, ArbC a, ArbC b, ArbC lambda, bool log_p)
        {
            var dens0 = Acb_Beta_pdf(x, a, b, false);
            var hyper = aflintc.hyperg_1f1(a + b, a, x * lambda / 2);
            var result = dens0 * aflintc.exp(-lambda / 2) * hyper;
            // Console.WriteLine("result from Acb_F_NC_pdf: {0}", result)

            if (log_p)
                result = aflintc.log(result);
            return result;
        }


        public static Arb Arb_Beta_NC_pdf(Arb x, Arb a, Arb b, Arb lambda, bool log_p)
        {
            var dens0 = Arb_Beta_pdf(x, a, b, false);
            var hyper = aflint.hyperg_1f1(a + b, a, x * lambda / 2);
            var result = dens0 * aflint.exp(-lambda / 2) * hyper;
            if (log_p)
                result = aflint.log(result);
            return result;
        }




        public static void DemoBetaDensity()
        {
            Arb x = new Arb(), a = new Arb(), b = new Arb(), lambda = new Arb(), result = new Arb();
            Arb arbresult = new Arb(), dens0 = new Arb(), hyper = new Arb();
            x = aflint.t(0.5d);
            a = aflint.t(10);
            b = aflint.t(20);
            lambda = aflint.t(3);
            // result = aflint.t(dreal.dist_dbeta_nc(x.AsDouble, a.AsDouble, b.AsDouble, lambda.AsDouble))
            // Console.WriteLine("   result: {0}", result)
            result = Arb_Beta_NC_pdf(x, a, b, lambda, false);
            Console.WriteLine("   result: {0}", result);
            // Dim resultc = Acb_Beta_NC_pdf(x, a, b, lambda, False)
            // Console.WriteLine("   resultc: {0}", resultc)
        }



        public static void DemoAcbIntegrationRho()
        {
            // mp4.setprec(100)
            AcbParamsNC[0] = aflintc.t(DistMCPArb.mp_integral_rho);
            var r = aflint.t(0.9d);
            var N = aflint.t(25);  // 35 already crashes
            var rho = aflint.t(0.9d);
            AcbParamsNC[mp_df1_pos] = aflintc.t(N);
            AcbParamsNC[mp_nc_pos] = aflintc.t(rho);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 2U;
            a = aflintc.t(0);
            b = aflintc.t(r);
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            var Pr0 = aflint.ibeta(0.5d, 0.5d * (N - 1), rho * rho);
            Pr0 = 0.5d * (1 + aflint.sign(rho) * Pr0);
            var resultint = 1 - (Pr0 - s);
            Console.WriteLine("resultint:{0}", resultint);
            var result = DemoPearsonArb.RhoExplicit_Arb(aflint.lrint(N), r, rho);
            Console.WriteLine("   result: {0}", result);
            double LeftTail = 0.0, RightTail = 0.0;
            DistN.RhoDisN_Guenther(N.AsDouble(), r.AsDouble(), rho.AsDouble(), ref LeftTail, ref RightTail);
            Console.WriteLine("LeftTail:   {0}, RightTail: {1}", LeftTail, RightTail);

        }


        public static ArbC Acb_Rho_pdf(long n, ArbC r, ArbC rho)
        {
            ArbC w;
            ArbC t;
            ArbC x;
            ArbC x2;
            ArbC r2;
            ArbC Rho2;
            ArbC U;
            ArbC k1;
            ArbC A2;
            ArbC a;
            ArbC c2;
            ArbC C;
            ArbC b2;
            ArbC b;
            ArbC ACTerm;
            ArbC density;
            r2 = r * r;
            Rho2 = rho * rho;
            x = r * rho;
            x2 = x * x;
            w = 0.5d * (1 + x);
            A2 = 1 - Rho2;
            a = aflintc.sqrt(A2);
            c2 = 1 - r2;
            C = aflintc.sqrt(c2);
            b2 = 1 - x2;
            b = aflintc.sqrt(b2);
            U = aflintc.acos(-x) / b;
            k1 = (n - 2L) / aflintc.sqrt(2 * aflint.pi()) * aflintc.exp(aflintc.lgamma(n - 1L) - aflintc.lgamma(n - 0.5d));
            ACTerm = aflintc.exp(aflintc.log(a) * (n - 1L) + aflintc.log(C) * (n - 4L) + aflintc.log(1 - x) * (1.5d - n));
            t = aflintc.hyperg_2f1(0.5d, 0.5d, n - 0.5d, w);
            density = k1 * ACTerm * t;
            return density;
        }

        public static Arb Arb_Rho_pdf(long n, Arb r, Arb rho)
        {
            Arb w;
            Arb t;
            Arb x;
            Arb x2;
            Arb r2;
            Arb Rho2;
            Arb U;
            Arb k1;
            Arb A2;
            Arb a;
            Arb c2;
            Arb C;
            Arb b2;
            Arb b;
            Arb ACTerm;
            Arb density;
            r2 = r * r;
            Rho2 = rho * rho;
            x = r * rho;
            x2 = x * x;
            w = 0.5d * (1 + x);
            A2 = 1 - Rho2;
            a = aflint.sqrt(A2);
            c2 = 1 - r2;
            C = aflint.sqrt(c2);
            b2 = 1 - x2;
            b = aflint.sqrt(b2);
            U = aflint.acos(-x) / b;
            k1 = (n - 2L) / aflint.sqrt(2 * aflint.pi()) * aflint.exp(aflint.lgamma(n - 1L) - aflint.lgamma(n - 0.5d));
            ACTerm = aflint.exp(aflint.log(a) * (n - 1L) + aflint.log(C) * (n - 4L) + aflint.log(1 - x) * (1.5d - n));
            t = aflint.hyperg_2f1(0.5d, 0.5d, n - 0.5d, w);
            density = k1 * ACTerm * t;
            return density;
        }

        public static void DemoPearsonRhoDensity()
        {
            long n;
            Arb r = new Arb(), rho = new Arb(), result = new Arb();
            n = 10L;
            r = aflint.t(0.5d);
            rho = aflint.t(0.25d);
            result = aflint.t(DemoPearsonDouble.RhoDensity_2(n, r.AsDouble(), rho.AsDouble()));
            Console.WriteLine("     result: {0}", result);
            result = Arb_Rho_pdf(n, r, rho);
            Console.WriteLine("     result: {0}", result);
            var resultc = Acb_Rho_pdf(n, aflintc.t(r), aflintc.t(rho));
            Console.WriteLine("   resultc: {0}", resultc);
            var resultd = DemoPearsonArb.RhoDensityDirect((int)n, r, rho);
            Console.WriteLine("    resultd: {0}", resultd);
            var resulte = DemoPearsonArb.Acb_RhoDensityDirect((int)n, aflintc.t(r), aflintc.t(rho));
            Console.WriteLine("   resulte: {0}", resulte);
        }



        public static void DemoAcbIntegrationRho2()
        {
            // mp4.setprec(100)
            AcbParamsNC[0] = aflintc.t(DistMCPArb.mp_integral_rho2);
            double R2 = 0.41d;
            int p = 4;
            int N = 100;  // crashes for 1000
            double Rho2 = 0.3d;
            AcbParamsNC[mp_df1_pos] = aflintc.t(p);
            AcbParamsNC[mp_df2_pos] = aflintc.t(N);
            AcbParamsNC[mp_nc_pos] = aflintc.t(Rho2);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 2U;
            a = aflintc.t(0);
            b = aflintc.t(R2);
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            double result = DistN.Rho2DisN8(false, p, N, R2, Rho2);
            Console.WriteLine("    result: {0}", result);
        }

        public static ArbC Acb_Rho2_pdf(ArbC x, ArbC p, ArbC N, ArbC rho2, bool log_p)
        {
            // see Gurland 1968
            var PP = p + 1;
            var NN = N + p + 1;
            var n1 = NN - 1;
            var dens0 = Acb_Beta_pdf(x, 0.5d * (PP - 1), 0.5d * (NN - PP), false);
            var hyper = aflintc.hyperg_2f1(0.5d * n1, 0.5d * n1, 0.5d * (PP - 1), rho2 * x);
            // Dim result = dens0 * (1 - rho2) ^ (n1 / 2) * hyper
            var result = dens0 * aflintc.pow(1 - rho2, n1 / 2) * hyper;
            if (log_p)
                result = aflintc.log(result);
            return result;
        }


        public static Arb Arb_Rho2_pdf(Arb x, Arb p, Arb N, Arb rho2, bool log_p)
        {
            // see Gurland 1968
            var PP = p + 1;
            var NN = N + p + 1;
            var n1 = NN - 1;
            var dens0 = Arb_Beta_pdf(x, 0.5d * (PP - 1), 0.5d * (NN - PP), false);
            var hyper = aflint.hyperg_2f1(0.5d * n1, 0.5d * n1, 0.5d * (PP - 1), rho2 * x);
            var result = dens0 * aflint.pow(1 - rho2, n1 / 2) * hyper;
            if (log_p)
                result = aflint.log(result);
            return result;
        }

        public static void DemoR2Density()
        {
            double result1d, result2d;
            double p, n;
            Arb x = new Arb(), rho2 = new Arb(), result1 = new Arb(), result2 = new Arb(), xdiff = new Arb(), dens = new Arb();
            p = 11d;
            n = 20d;
            x = aflint.t(0.125d);
            rho2 = aflint.t(0.25d);
            xdiff = aflint.t(0.000001d);
            result1d = DistN.Rho2DisN8(false, p, n, x.AsDouble(), rho2.AsDouble());
            // Console.WriteLine("   result1: {0}", result1)
            result2d = DistN.Rho2DisN8(false, p, n, x.AsDouble() + xdiff.AsDouble(), rho2.AsDouble());
            // Console.WriteLine("   result2: {0}", result2)
            dens = (result2d - result1d) / xdiff;
            Console.WriteLine("     dens: {0}", dens);

            var result = Arb_Rho2_pdf(x, aflint.t(p), aflint.t(n), rho2, false);
            Console.WriteLine("   result: {0}", result);
            var resultc = Acb_Rho2_pdf(aflintc.t(x), aflintc.t(p), aflintc.t(n), aflintc.t(rho2), false);
            Console.WriteLine("   resultc: {0}", resultc);
        }


        public static void DemoNoncentralPdf()
        {
            DemoChiSquareDensity();
            DemoTDensity();
            DemoFDensity();
            DemoBetaDensity();
            DemoPearsonRhoDensity();
            DemoR2Density();
        }

        public static void DemoNoncentralCDF()
        {
            DemoAcbIntegrationChiSquare();
            DemoAcbIntegrationChiSquareNC();
            DemoAcbIntegrationTNC();
            DemoAcbIntegrationFNC();
            DemoAcbIntegrationBetaNC();
            DemoAcbIntegrationRho();
            DemoAcbIntegrationRho2();
        }


        public static void DemoDistFromBoost()
        {
            ArbPrec.SetDps(30);
            double x, y, a, b;
            a = 12d;
            x = 13.125d;

            var a_arb = aflint.t(a);
            var x_arb = aflint.t(x);

            Console.WriteLine("aflint.gamma_p_derivative:   {0}", aflint.gamma_p_derivative(a_arb, x_arb));
            Console.WriteLine("boost.gamma_p_derivative:  {0}", dreal.real_gamma_p_prime(a, x));

            Console.WriteLine("gamma_lower_r: {0}", aflint.real_gamma_lower(a_arb, x_arb));
            Console.WriteLine("boost.gamma_p:  {0}", dreal.real_gamma_lower(a, x));
            Console.WriteLine("gamma_upper_r: {0}", aflint.real_gamma_upper(a, x));
            Console.WriteLine("boost.gamma_q:  {0}", dreal.real_gamma_upper(a, x));
            Console.WriteLine("");

            x = 0.25d;
            y = 1d - x;
            a = 12d;
            b = 23d;

            x_arb = aflint.t(x);
            var y_arb = aflint.t(y);
            a_arb = aflint.t(a);
            var b_arb = aflint.t(b);


            Console.WriteLine("beta:        {0}", aflint.real_beta(a, b));
            Console.WriteLine("boost.beta:   {0}", dreal.real_beta(a, b));
            Console.WriteLine("aflint.ibeta_derivative:   {0}", aflint.real_ibeta_prime(a, b, x));
            Console.WriteLine("boost.ibeta_derivative:  {0}", dreal.real_ibeta_prime(a, b, x));
            Console.WriteLine("aflint.ibeta:   {0}", aflint.real_ibeta(a, b, x));
            Console.WriteLine("boost.ibeta:  {0}", dreal.real_ibeta(a, b, x));
            Console.WriteLine("aflint.ibetac:  {0}", aflint.real_ibetac(a, b, x));
            Console.WriteLine("boost.ibetac: {0}", dreal.real_ibetac(a, b, x));
            Console.WriteLine("");

            // Console.WriteLine("dbeta(x=0.77, a=10.6, b=1.8):  {0}", dreal.dist_dbeta(0.5, 10.6, 1.8, False))
            Console.WriteLine("dbeta(x=0.77, a=10.6, b=1.8): {0}", Arb_Beta_pdf(aflint.t(0.5d), aflint.t(10.6d), aflint.t(1.8d), false));
            // Console.WriteLine("pbeta(x=0.77, a=10.6, b=1.8):  {0}", dreal.dist_pbeta(0.5, 10.6, 1.8, False, False))
            Console.WriteLine("pbeta(x=0.77, a=10.6, b=1.8): {0}", Arb_Beta_CDF(aflint.t(0.5d), aflint.t(10.6d), aflint.t(1.8d), false, false));
            // Console.WriteLine("qbeta(p=0.5, a=10.6, b=1.8): {0}", dreal.dist_qbeta(0.5, 10.6, 1.8, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dbinom(k=7, n=11, p=0.1):  {0}", dreal.dist_dbinom(7, 11, 0.125, False))
            Console.WriteLine("dbinom(k=7, n=11, p=0.1): {0}", Arb_Binom_pdf(aflint.t(7), aflint.t(11), aflint.t(0.125d), false));
            // Console.WriteLine("pbinom(k=7, n=11, p=0.1):  {0}", dreal.dist_pbinom(7, 11, 0.125, False, False))
            Console.WriteLine("pbinom(k=7, n=11, p=0.1): {0}", Arb_Binom_CDF(aflint.t(7), aflint.t(11), aflint.t(0.125d), false, false));
            // Console.WriteLine("qbinom(p=0.5, size=11, prob=0.1): {0}", dreal.dist_qbinom(0.5, 11, 0.4, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5):  {0}", dreal.dist_dcauchy(10.2, 0.0, 0.5, False))
            Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5): {0}", Arb_Cauchy_pdf(aflint.t(10.2d), aflint.t(0.0d), aflint.t(0.5d), false));
            // Console.WriteLine("pcauchy(x=10.2, a=0.0, b=0.5):  {0}", dreal.dist_pcauchy(10.2, 0.0, 0.5, False, False))
            Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5): {0}", Arb_Cauchy_CDF(aflint.t(10.2d), aflint.t(0.0d), aflint.t(0.5d), false, false));
            // Console.WriteLine("qcauchy(p=0.75, a=10.125, b=0.5): {0}", dreal.dist_qcauchy(0.75, 10.125, 0.5, False, False))
            Console.WriteLine("dcauchy(p=0.75, a=10.125, b=0.5): {0}", Arb_Cauchy_ICDF(aflint.t(0.75d), aflint.t(10.125d), aflint.t(0.5d), false, false));
            Console.WriteLine("");

            // Console.WriteLine("dchisq(x=10.2, nu=10.0):  {0}", dreal.dist_dchisq(10.2, 10.0, False))
            Console.WriteLine("dchisq(x=10.2, nu=10.0): {0}", Arb_ChiSquare_pdf(aflint.t(10.2d), aflint.t(10.0d), false));
            // Console.WriteLine("pchisq(x=10.2, nu=10.0):  {0}", dreal.dist_pchisq(10.2, 10.0, False, False))
            Console.WriteLine("pchisq(x=10.2, nu=10.0): {0}", Arb_ChiSquare_CDF(aflint.t(10.2d), aflint.t(10.0d), false, false));
            // Console.WriteLine("qchisq(p=0.5, nu=10.0): {0}", dreal.dist_qchisq(0.5, 10.0, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dexp(x=10.2, lambda=10.0):  {0}", dreal.dist_dexp(10.25, 10.125, False))
            Console.WriteLine("dexp(x=10.2, lambda=10.0): {0}", Arb_Exp_pdf(aflint.t(10.25d), aflint.t(10.125d), false));
            // Console.WriteLine("pexp(x=10.2, lambda=10.0):  {0}", dreal.dist_pexp(10.25, 10.125, False, False))
            Console.WriteLine("pexp(x=10.2, lambda=10.0): {0}", Arb_Exp_CDF(aflint.t(10.25d), aflint.t(10.125d), false, false));
            // Console.WriteLine("qexp(p=0.5, lambda=10.0):  {0}", dreal.dist_qexp(aflint.t(0.5), aflint.t(10.0), False, False))
            Console.WriteLine("qexp(p=0.5, lambda=10.0): {0}", Arb_Exp_ICDF(aflint.t(0.5d), aflint.t(10.0d), false, false));
            Console.WriteLine("");

            // Console.WriteLine("dgumbel(x=10.2, a=2.0, b=0.5):  {0}", dreal.dist_dgumbel(10.25, 2.0, 0.5, False))
            Console.WriteLine("dgumbel(x=10.2, a=2.0, b=0.5): {0}", Arb_Gumbel_pdf(aflint.t(10.25d), aflint.t(2.0d), aflint.t(0.5d), false));
            // Console.WriteLine("pgumbel(x=10.2, a=2.0, b=0.5):  {0}", dreal.dist_pgumbel(10.25, 2.0, 0.5, False, False))
            Console.WriteLine("pgumbel(x=10.2, a=2.0, b=0.5): {0}", Arb_Gumbel_CDF(aflint.t(10.25d), aflint.t(2.0d), aflint.t(0.5d), false, false));
            // Console.WriteLine("qgumbel(p=0.5, a=2.0, b=0.5):  {0}", dreal.dist_qgumbel(0.5, 2.0, 0.5, False, False))
            Console.WriteLine("qgumbel(p=0.5, a=2.0, b=0.5): {0}", Arb_Gumbel_ICDF(aflint.t(0.5d), aflint.t(2.0d), aflint.t(0.5d), false, false));
            Console.WriteLine("");

            // Console.WriteLine("df(x=10.77, a=10.6, b=1.8):  {0}", dreal.dist_df(10.5, 10.6, 1.8, False))
            Console.WriteLine("df(x=10.77, a=10.6, b=1.8): {0}", Arb_F_pdf(aflint.t(10.5d), aflint.t(10.6d), aflint.t(1.8d), false));
            // Console.WriteLine("pf(x=10.77, a=10.6, b=1.8):  {0}", dreal.dist_pf(10.5, 10.6, 1.8, False, False))
            Console.WriteLine("pf(x=10.77, a=10.6, b=1.8): {0}", Arb_F_CDF(aflint.t(10.5d), aflint.t(10.6d), aflint.t(1.8d), false, false));
            // Console.WriteLine("qf(p=0.5, a=10.6, b=1.8): {0}", dreal.dist_qf(0.5, 10.6, 1.8, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dgamma(x=10.77, a=10.6, b=1.8):  {0}", dreal.dist_dgamma(10.5, 10.6, 1.8, False))
            Console.WriteLine("dgamma(x=10.77, a=10.6, b=1.8): {0}", Arb_Gamma_pdf(aflint.t(10.5d), aflint.t(10.6d), aflint.t(1.8d), false));
            // Console.WriteLine("pgamma(x=10.77, a=10.6, b=1.8):  {0}", dreal.dist_pgamma(10.5, 10.6, 1.8, False, False))
            Console.WriteLine("pgamma(x=10.77, a=10.6, b=1.8): {0}", Arb_Gamma_CDF(aflint.t(10.5d), aflint.t(10.6d), aflint.t(1.8d), false, false));
            // Console.WriteLine("qgamma(p=0.5, a=10.6, b=1.8): {0}", dreal.dist_qgamma(0.5, 10.6, 1.8, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dgeom(x=2, lambda=0.125:  {0}", dreal.dist_dgeom(2, 0.75, False))
            Console.WriteLine("dgeom(x=2, lambda=0.125: {0}", Arb_Geom_pdf(aflint.t(2), aflint.t(0.75d), false));
            // Console.WriteLine("pgeom(x=2, lambda=0.1:  {0}", dreal.dist_pgeom(2, 0.75, False, False))
            Console.WriteLine("pgeom(x=2, lambda=0.1: {0}", Arb_Geom_CDF(aflint.t(2), aflint.t(0.75d), false, false));
            // Console.WriteLine("qgeom(p=0.5, lambda=0.1:  {0}", dreal.dist_qgeom(aflint.t(0.5), aflint.t(0.1), False, False))
            Console.WriteLine("qgeom(p=0.5, lambda=0.1: {0}", Arb_Geom_ICDF(aflint.t(0.5d), aflint.t(0.1d), false, false));
            Console.WriteLine("");

            // Console.WriteLine("dinvchisq(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_dinvchisq(1.5, 2.0, 3.0, False))
            Console.WriteLine("dinvchisq(x=11.5, df=2.0, scale=3.0): {0}", Arb_Invchisq_pdf(aflint.t(1.5d), aflint.t(2.0d), aflint.t(3.0d), false));
            // Console.WriteLine("pinvchisq(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_pinvchisq(1.5, 2.0, 3.0, False, False))
            Console.WriteLine("pinvchisq(x=11.5, df=2.0, scale=3.0): {0}", Arb_Invchisq_CDF(aflint.t(1.5d), aflint.t(2.0d), aflint.t(3.0d), false, false));
            // Console.WriteLine("qinvchisq(p=0.5, df=2.0, scale=3.0): {0}", dreal.dist_qinvchisq(0.5, 2.0, 3.0, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dinvgamma(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_dinvgamma(1.5, 2.0, 3.0, False))
            Console.WriteLine("dinvgamma(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGamma_pdf(aflint.t(1.5d), aflint.t(2.0d), aflint.t(3.0d), false));
            // Console.WriteLine("pinvgamma(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_pinvgamma(1.5, 2.0, 3.0, False, False))
            Console.WriteLine("pinvgamma(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGamma_CDF(aflint.t(1.5d), aflint.t(2.0d), aflint.t(3.0d), false, false));
            // Console.WriteLine("qinvgamma(p=0.5, df=2.0, scale=3.0): {0}", dreal.dist_qinvgamma(0.5, 2.0, 3.0, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dinvgauss(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_dinvgauss(1.5, 2.0, 3.0, False))
            Console.WriteLine("dinvgauss(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGauss_pdf(aflint.t(1.5d), aflint.t(2.0d), aflint.t(3.0d), false));
            // Console.WriteLine("pinvgauss(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_pinvgauss(1.5, 2.0, 3.0, False, False))
            Console.WriteLine("pinvgauss(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGauss_CDF(aflint.t(1.5d), aflint.t(2.0d), aflint.t(3.0d), false, false));
            // Console.WriteLine("qinvgauss(p=0.5, df=2.0, scale=3.0): {0}", dreal.dist_pinvgauss(0.5, 2.0, 3.0, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dlaplace(x=5.7, a=-5.0, b=4.0):  {0}", dreal.dist_dlaplace(5.7, -5.0, 4.0, False))
            Console.WriteLine("dlaplace(x=5.7, a=-5.0, b=4.0): {0}", Arb_Laplace_pdf(aflint.t(5.7d), aflint.t(-5.0d), aflint.t(4.0d), false));
            // Console.WriteLine("plaplace(x=5.7, a=-5.0, b=4.0):  {0}", dreal.dist_plaplace(5.7, -5.0, 4.0, False, False))
            Console.WriteLine("plaplace(x=5.7, a=-5.0, b=4.0): {0}", Arb_Laplace_CDF(aflint.t(5.7d), aflint.t(-5.0d), aflint.t(4.0d), false, false));
            // Console.WriteLine("qlaplace(p=0.5, a=-5.0, b=4.0):  {0}", dreal.dist_qlaplace(0.6, -5.0, 4.0, False, False))
            Console.WriteLine("qlaplace(p=0.5, a=-5.0, b=4.0): {0}", Arb_Laplace_ICDF(aflint.t(0.6d), aflint.t(-5.0d), aflint.t(4.0d), false, false));
            Console.WriteLine("");

            // Console.WriteLine("dlogis(x=4.3, a=9.1, b=3.2):  {0}", dreal.dist_dlogis(4.3, 9.1, 3.2, False))
            Console.WriteLine("dlogis(x=4.3, a=9.1, b=3.2): {0}", Arb_Logistic_pdf(aflint.t(4.3d), aflint.t(9.1d), aflint.t(3.2d), false));
            // Console.WriteLine("plogis(x=4.3, a=9.1, b=3.2):  {0}", dreal.dist_plogis(4.3, 9.1, 3.2, False, False))
            Console.WriteLine("plogis(x=4.3, a=9.1, b=3.2): {0}", Arb_Logistic_CDF(aflint.t(4.3d), aflint.t(9.1d), aflint.t(3.2d), false, false));
            // Console.WriteLine("qlogis(p=0.5, a=9.1, b=3.2):  {0}", dreal.dist_qlogis(0.5, 9.1, 3.2, False, False))
            Console.WriteLine("qlogis(p=0.5, a=9.1, b=3.2): {0}", Arb_Logistic_ICDF(aflint.t(0.5d), aflint.t(9.1d), aflint.t(3.2d), false, false));
            Console.WriteLine("");

            // Console.WriteLine("dlnorm(x=0.4, a=0.0, b=1.0):  {0}", dreal.dist_dlnorm(0.4, 3.0, 1.0, False))
            Console.WriteLine("dlnorm(x=0.4, a=0.0, b=1.0): {0}", Arb_LogNormal_pdf(aflint.t(0.4d), aflint.t(3.0d), aflint.t(1.0d), false));
            // Console.WriteLine("plnorm(x=0.4, a=0.0, b=1.0): {0}", dreal.dist_plnorm(0.4, 3.0, 1.0, False, False))
            Console.WriteLine("plnorm(x=0.4, a=0.0, b=1.0): {0}", Arb_LogNormal_CDF(aflint.t(0.4d), aflint.t(3.0d), aflint.t(1.0d), false, false));
            // Console.WriteLine("qlnorm(p=0.5, a=0.0, b=1.0): {0}", dreal.dist_qlnorm(0.5, 3.0, 1.0, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dnbinom(x=4, a=20, prob=0.7):  {0}", dreal.dist_dnbinom(4, 20, 0.7, False))
            Console.WriteLine("dnbinom(x=4, a=20, prob=0.7): {0}", Arb_Nbinom_pdf(aflint.t(4), aflint.t(20), aflint.t(0.7d), false));
            // Console.WriteLine("pnbinom(x=4, a=20, prob=0.7):  {0}", dreal.dist_pnbinom(4, 20, 0.7, False, False))
            Console.WriteLine("pnbinom(x=4, a=20, prob=0.7): {0}", Arb_Nbinom_CDF(aflint.t(4), aflint.t(20), aflint.t(0.7d), false, false));
            // Console.WriteLine("qnbinom(p=0.5, a=20, prob=0.7): {0}", dreal.dist_qnbinom(0.5, 20, 0.7, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dnorm(x=0.4, mu=-2.0, std=0.5):  {0}", dreal.dist_dnorm(0.4, -2.0, 0.5, False))
            Console.WriteLine("dnorm(x=0.4, mu=-2.0, std=0.5): {0}", Arb_Normal_pdf(aflint.t(0.4d), aflint.t(-2.0d), aflint.t(0.5d), false));
            // Console.WriteLine("pnorm(x=0.4, mu=-2.0, std=0.5):  {0}", dreal.dist_pnorm(0.4, -2.0, 0.5, False, False))
            Console.WriteLine("pnorm(x=0.4, mu=-2.0, std=0.5): {0}", Arb_Normal_CDF(aflint.t(0.4d), aflint.t(-2.0d), aflint.t(0.5d), false, false));
            // Console.WriteLine("qnorm(p=0.5, mu=-2.0, std=0.5): {0}", dreal.dist_qnorm(0.5, -2.0, 0.5, False, False))
            Console.WriteLine("");

            // Console.WriteLine("dpareto(x=3.4, shape=3.0, scale=1.0):  {0}", dreal.dist_dpareto(3.4, 3.0, 1.0, False))
            Console.WriteLine("dpareto(x=3.4, shape=3.0, scale=1.0): {0}", Arb_Pareto_pdf(aflint.t(3.4d), aflint.t(3.0d), aflint.t(1.0d), false));
            // Console.WriteLine("ppareto(x=3.4, shape=3.0, scale=1.0):  {0}", dreal.dist_ppareto(3.4, 3.0, 1.0, False, False))
            Console.WriteLine("ppareto(x=3.4, shape=3.0, scale=1.0): {0}", Arb_Pareto_CDF(aflint.t(3.4d), aflint.t(3.0d), aflint.t(1.0d), false, false));
            // Console.WriteLine("qpareto(p=0.5, shape=3.0, scale=1.0):  {0}", dreal.dist_qpareto(0.5, 3.0, 1.0, False, False))
            Console.WriteLine("qpareto(p=0.5, shape=3.0, scale=1.0): {0}", Arb_Pareto_ICDF(aflint.t(0.5d), aflint.t(3.0d), aflint.t(1.0d), false, false));
            Console.WriteLine("");

            // Console.WriteLine("dpois(x=11, lambda=4.0):  {0}", dreal.dist_dpois(11, 4.0, False))
            Console.WriteLine("dpois(x=11, lambda=4.0): {0}", Arb_Poisson_pdf(aflint.t(11), aflint.t(4.0d), false));
            // Console.WriteLine("ppois(x=11, lambda=4.0):  {0}", dreal.dist_ppois(11, 4.0, False, False))
            Console.WriteLine("ppois(x=11, lambda=4.0): {0}", Arb_Poisson_CDF(aflint.t(11), aflint.t(4.0d), false, false));
            // Console.WriteLine("qpois(p=0.5, lambda=4.0): {0}", dreal.dist_ppois(0.5, 4.0, False, False))
            Console.WriteLine("");

            // Console.WriteLine("drayleigh(x=6.3, nu=1.1):  {0}", dreal.dist_drayleigh(6.3, 1.1, False))
            Console.WriteLine("drayleigh(x=6.3, nu=1.1): {0}", Arb_RayLeigh_pdf(aflint.t(6.3d), aflint.t(1.1d), false));
            // Console.WriteLine("prayleigh(x=6.3, nu=1.1):  {0}", dreal.dist_prayleigh(aflint.t(6.3), aflint.t(1.1), False, False))
            Console.WriteLine("prayleigh(x=6.3, nu=1.1): {0}", Arb_RayLeigh_CDF(aflint.t(6.3d), aflint.t(1.1d), false, false));
            // Console.WriteLine("qrayleigh(p=0.5, nu=1.1):  {0}", dreal.dist_qrayleigh(aflint.t(0.5), aflint.t(1.1), False, False))
            Console.WriteLine("qrayleigh(p=0.5, nu=1.1): {0}", Arb_RayLeigh_ICDF(aflint.t(0.5d), aflint.t(1.1d), false, false));
            Console.WriteLine("");



            // Console.WriteLine("dt(x=11, nu=5.0):  {0}", dreal.dist_dt(11, 6.0, False))
            Console.WriteLine("dt(x=11, nu=5.0): {0}", Arb_T_pdf(aflint.t(11), aflint.t(6.0d), false));
            // Console.WriteLine("pt(x=11, nu=5.0):  {0}", dreal.dist_pt(11, 6.0, False, False))
            Console.WriteLine("pt(x=11, nu=5.0): {0}", Arb_T_CDF(aflint.t(11), aflint.t(6.0d), false, false));
            // Console.WriteLine("qt(p=0.5, nu=5.0): {0}", dreal.dist_qt(0.5, 6.0, False, False))
            Console.WriteLine("");

            // 'Console.WriteLine("dtriangular(x=0.77, lower=0.0, mode=1.0, upper=4.0): {0}", dreal.dist_dtriangular(0.77, -2, 0, 3, False))
            // 'Console.WriteLine("ptriangular(x=0.77, lower=0.0, mode=1.0, upper=4.0): {0}", dreal.dist_ptriangular(0.77, -2, 0, 3, False, False))
            // 'Console.WriteLine("qtriangular(p=0.5, lower=0.0, mode=1.0, upper=4.0): {0}", dreal.dist_qtriangular(0.5, -2, 0, 3, False, False))
            // 'Console.WriteLine("")

            // Console.WriteLine("dunif(x=0.77, lower=-2.0,  upper=3.0):  {0}", dreal.dist_dunif(0.77, -2, 3, False))
            Console.WriteLine("dunif(x=0.77, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_pdf(aflint.t(0.77d), aflint.t(-2), aflint.t(3), false));
            // Console.WriteLine("punif(x=0.77, lower=-2.0,  upper=3.0):  {0}", dreal.dist_punif(0.77, -2, 3, False, False))
            Console.WriteLine("punif(x=0.77, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_CDF(aflint.t(0.77d), aflint.t(-2), aflint.t(3), false, false));
            // Console.WriteLine("qunif(p=0.5, lower=-2.0,  upper=3.0): {0}", dreal.dist_qunif(0.5, -2, 3, False, False))
            Console.WriteLine("qunif(p=0.5, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_ICDF(aflint.t(0.5d), aflint.t(-2), aflint.t(3), false, false));
            Console.WriteLine("");

            // Console.WriteLine("dweibull(x=0.77, shape=0.5, scale=1.0):  {0}", dreal.dist_dweibull(0.77, 0.5, 1, False))
            Console.WriteLine("dweibull(x=0.77, shape=0.5, scale=1.0): {0}", Arb_Weibull_pdf(aflint.t(0.77d), aflint.t(0.5d), aflint.t(1), false));
            // Console.WriteLine("pweibull(x=0.77, shape=0.5, scale=1.0):  {0}", dreal.dist_pweibull(0.77, 0.5, 1, False, False))
            Console.WriteLine("pweibull(x=0.77, shape=0.5, scale=1.0): {0}", Arb_Weibull_CDF(aflint.t(0.77d), aflint.t(0.5d), aflint.t(1), false, false));
            // Console.WriteLine("qweibull(p=0.5, shape=0.5, scale=1.0):  {0}", dreal.dist_qweibull(0.5, 0.5, 1, False, False))
            Console.WriteLine("qweibull(p=0.5, shape=0.5, scale=1.0): {0}", Arb_Weibull_ICDF(aflint.t(0.5d), aflint.t(0.5d), aflint.t(1), false, false));
            Console.WriteLine("");


            // ****************************************************************************************		
            // ****************************************************************************************		


            // Console.WriteLine("dhyper(x=10, r=50, n=30, NN=500): {0}", dreal.dist_dhyper(10, 50, 30, 500, False))
            // Console.WriteLine("phyper(x=10, r=50, n=30, NN=500): {0}", dreal.dist_phyper(10, 50, 30, 500, False, False))
            // Console.WriteLine("qhyper(p=0.5, r=50, n=30, NN=500): {0}", dreal.dist_qhyper(0.5, 50, 30, 500, False, False))
            // Console.WriteLine("")


            // Console.WriteLine("dskewnormal(x=0.77, a=0.0, b=1.0, nc=4.0): {0}", dreal.dist_dskewnormal(0.77, 0, 1, 4, False))
            // Console.WriteLine("pskewnormal(x=0.77, a=0.0, b=1.0, nc=4.0): {0}", dreal.dist_pskewnormal(0.77, 0, 1, 4, False, False))
            // Console.WriteLine("qskewnormal(p=0.5, a=0.0, b=1.0, nc=4.0): {0}", dreal.dist_qskewnormal(0.5, 0, 1, 4, False, False))
            // Console.WriteLine("")


            // Console.WriteLine("dbeta_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_dbeta_nc(0.77, 3.0, 12.0, 30.0, False))
            // Console.WriteLine("pbeta_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_pbeta_nc(0.77, 3.0, 12.0, 30.0, False, False))
            // Console.WriteLine("qbeta_nc(p=0.5, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_qbeta_nc(0.5, 3.0, 12.0, 30.0, False, False))
            // Console.WriteLine("")

            // Console.WriteLine("dchisq_nc(x=4.23, nu=3.0,  nc=30.0): {0}", dreal.dist_dchisq_nc(4.23, 3.0, 30.0, False))
            // Console.WriteLine("pchisq_nc(x=4.23, nu=3.0,  nc=30.0): {0}", dreal.dist_pchisq_nc(4.23, 3.0, 30.0, False, False))
            // Console.WriteLine("qbinom(p=0.5, size=11, prob=0.1): {0}", dreal.dist_qbinom(0.5, 11, 0.4, False, False))
            // Console.WriteLine("")

            // Console.WriteLine("df_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_df_nc(0.77, 3.0, 12.0, 30.0, False))
            // Console.WriteLine("pf_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_pf_nc(0.77, 3.0, 12.0, 30.0, False, False))
            // Console.WriteLine("qf_nc(p=0.5, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_qf_nc(0.5, 3.0, 12.0, 30.0, False, False))
            // Console.WriteLine("")

            // Console.WriteLine("dt_nc(x=4.23, nu=2.0,  nc=-5.0): {0}", dreal.dist_dt_nc(4.23, 2.0, -5.0, False))
            // Console.WriteLine("pt_nc(x=4.23, nu=2.0,  nc=-5.0): {0}", dreal.dist_pt_nc(4.23, 2.0, -5.0, False, False))
            // Console.WriteLine("qt_nc(p=0.5, nu=2.0,  nc=-5.0): {0}", dreal.dist_qt_nc(0.5, 2.0, -5.0, False, False))
            // Console.WriteLine("")


        }





    }
}