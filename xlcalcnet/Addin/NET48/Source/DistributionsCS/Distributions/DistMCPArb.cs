using System;
using ArbPrecNet;

namespace Distributions
{




    static class DistMCPArb
    {

        // Dim AcbParams As ArbMatC = apc_mat.set_ones(100, 1)
        private static ArbMatC AcbParams = aflintc.mat_ones(100, 1);

        // Dim MpfrParams As MpfrMat = mreal_mat.set_ones(100, 1)
        private static MpfrMat MpfrParams = mreal.mat_ones(100, 1);

        // wolfram alpha: integrate sin(exp(x))/sqrt(x) from 0 to 2 = 1.50572...
        public static Arb DE_Integration(cbFuncApc func, ArbMatC @params, Arb a, Arb b, Arb epsabsStart, Arb alpha, Arb beta)
        {
            Console.WriteLine("DE_Integration");

            string ds = "";
            var p2 = aflint.pi() / 2;
            var pi = aflint.pi();
            Arb K = new Arb(), d = new Arb(), C1 = new Arb(), C2 = new Arb(), epsabs = new Arb(), h = new Arb(), n = new Arb(), hmin = new Arb(), C1Final = new Arb(), epsabsFinal = new Arb();
            double radX = 0.0, radY = 0.0;

            var nmin = aflint.t("1.0E1000000000000");
            // Console.WriteLine("nmin at start: {0}", nmin)
            Arb mu = new Arb(), nu = new Arb();
            if (alpha < beta)
            {
                mu = alpha;
                nu = beta;
            }
            else
            {
                mu = beta;
                nu = alpha;
            }

            // Determine optimal h and n
            for (int d1 = 1; d1 <= 26; d1++)
            {
                // For d1 As Integer = 10 To 16
                GetRectAndK(d1, ref radX, ref radY, ref ds);
                d = aflint.t(ds);
                // Console.WriteLine("radX: {0:f}, radY: {1:f}, d: {2:f}, , d1: {3}", radX, radY, d, d1)
                Arb radX_ = new Arb(), radY_ = new Arb();
                radX_ = aflint.t(radX);
                radY_ = aflint.t(radY);
                @params[DistFromBoost.mp_order] = aflintc.t(1);
                K = GetAcbK(func, @params, a.Mid, b.Mid, radX_, radY_);
                @params[DistFromBoost.mp_order] = aflintc.t(0);
                // Console.WriteLine("K: {0}", K)
                // C1 = (1 / mu) * 2 * K * (b - a) ^ (alpha + beta - 1)
                C1 = 1 / mu * 2 * K * aflint.pow(b - a, alpha + beta - 1);
                epsabs = epsabsStart / C1;
                // C2 = 2 / ((aflint.cos(p2 * aflint.sin(d))) ^ (alpha + beta) * aflint.cos(d))
                C2 = 2 / aflint.pow(aflint.cos(p2 * aflint.sin(d)), (alpha + beta) * aflint.cos(d));
                // Console.WriteLine("C1: {0}", C1)
                // Console.WriteLine("C2: {0}", C2)
                // Console.WriteLine("epsabs: {0}", epsabs)
                h = 2 * pi * d / aflint.log(1 + 2 * C2 / epsabs);
                n = 1 / h * aflint.log(2 / (pi * mu) * aflint.abs(aflint.log(2 * aflint.exp(p2 * nu) / epsabs)));
                if (n < 6)
                    n = aflint.t(6);
                // n = (1 / h) * aflint.log(2 / (pi * mu) * aflint.log(2 * aflint.exp(p2 * nu) / epsabs))

                // Console.WriteLine("h: {0} n: {1}, nmin: {2}, n < nmin: {3}, ", h, n, nmin, (n < nmin))
                n = aflint.abs(n);
                if (n < nmin)
                {
                    nmin = n;
                    hmin = h;
                    C1Final = C1;
                    epsabsFinal = epsabs;
                }
            }

            // Console.WriteLine("Final epsabs {0}: ", epsabsFinal)
            // Console.WriteLine("Final C1 {0:f}: ", C1Final)
            // Determine NN and MM if alpha <> beta
            // Console.WriteLine("hmin: {0}, nmin: {1:f}", hmin, nmin)
            int MM, NN;
            // MM = aflint.ceil(nmin).ToInt32 : NN = MM
            MM = aflint.lrint(aflint.ceil(nmin));
            NN = MM;
            // Console.WriteLine("n0: {0}", NN)
            if (mu == alpha)
            {
                // NN = NN - aflint.floor(aflint.log(beta / alpha) / hmin).ToInt32
                NN = NN - aflint.lrint(aflint.floor(aflint.log(beta / alpha) / hmin));
            }
            else
            {
                // MM = MM - aflint.floor(aflint.log(alpha / beta) / hmin).ToInt32
                MM = MM - aflint.lrint(aflint.floor(aflint.log(alpha / beta) / hmin));
            }
            Console.WriteLine("NN: {0}", NN);
            Console.WriteLine("MM: {0}", MM);


            // Perform actual integration
            Arb res = new Arb(), sum = new Arb(), u = new Arb(), t = new Arb(), f = new Arb(), PHI2 = new Arb(), c = new Arb(), b1 = new Arb(), b2 = new Arb();
            Arb x1 = new Arb(), e1 = new Arb(), e2 = new Arb(), e3 = new Arb(), fp1 = new Arb(), fm1 = new Arb(), su = new Arb(), cu = new Arb(), eu1 = new Arb(), eu2 = new Arb();
            int kk;
            sum = aflint.t(0);
            // c = p2 * ((b-a)/2) ^ (alpha+beta-1) 
            b1 = (b - a) / 2;
            b2 = (b + a) / 2;
            c = p2 * aflint.pow(b1, alpha + beta - 1);
            var loopTo = NN;
            for (kk = -MM; kk <= loopTo; kk++)
            {
                u = hmin * kk;
                eu1 = aflint.exp(u);
                eu2 = 1 / eu1;
                su = (eu1 - eu2) * 0.5d; // su = sinh(u)
                cu = (eu1 + eu2) * 0.5d; // cu = cosh(u)
                x1 = p2 * su;
                e1 = aflint.exp(x1); // e1 = exp(x1)
                e2 = 1 / e1; // e2 = exp(-x1)
                e3 = 1 / (e1 + e2);
                f = (e1 - e2) * e3; // f = tanh(x1) = (e1 - e2) / (e1 + e2)
                fp1 = 2 * e1 * e3; // 1+f = 2 * e1 / (e1 + e2)
                fm1 = 2 * e2 * e3; // 1-f = 2 * e2 / (e1 + e2)
                                   // PHI2 = c * aflint.cosh(u) * (aflint.abs(1+f))^alpha * (aflint.abs(1-f))^beta
                if (alpha != 1)
                    fp1 = aflint.pow(fp1, alpha);
                if (beta != 1)
                    fm1 = aflint.pow(fm1, beta);
                PHI2 = c * cu * fp1 * fm1;
                t = f * b1 + b2;
                // sum = sum + g(t) * PHI2
                // sum = sum + func(t, params).real * PHI2
                sum = sum + func(aflintc.t(t)).real * PHI2;
            }
            res = hmin * sum;
            Console.WriteLine("ED+ET: {0}", C1Final * epsabsFinal);
            Console.WriteLine("Int1: {0}", res);
            return res;
        }



        public static void GetRectAndK(int d1, ref double radX, ref double radY, ref string ds)
        {
            switch (d1)
            {
                case 1:
                    {
                        radX = 165.2d;
                        radY = 254.3d;
                        ds = "1.5";
                        break;
                    }
                case 2:
                    {
                        radX = 28.375d;
                        radY = 43.75d;
                        ds = "1.4";
                        break;
                    }
                case 3:
                    {
                        radX = 11.3d;
                        radY = 17.46d;
                        ds = "1.3";
                        break;
                    }
                case 4:
                    {
                        radX = 6.06d;
                        radY = 9.34d;
                        ds = "1.2";
                        break;
                    }
                case 5:
                    {
                        radX = 3.8d;
                        radY = 5.795d;
                        ds = "1.1";
                        break;
                    }
                case 6:
                    {
                        radX = 2.633d;
                        radY = 3.933d;
                        ds = "1.0";
                        break;
                    }

                case 7:
                    {
                        radX = 1.968d;
                        radY = 2.826d;
                        ds = "0.9";
                        break;
                    }
                case 8:
                    {
                        radX = 1.566d;
                        radY = 2.103d;
                        ds = "0.8";
                        break;
                    }
                case 9:
                    {
                        radX = 1.312d;
                        radY = 1.5994d;
                        ds = "0.7";
                        break;
                    }
                case 10:
                    {
                        radX = 1.1552d;
                        radY = 1.2276d;
                        ds = "0.6";
                        break;
                    }
                case 11:
                    {
                        radX = 1.065d;
                        radY = 0.937d;
                        ds = "0.5";
                        break;
                    }
                case 12:
                    {
                        radX = 1.0197d;
                        radY = 0.702d;
                        ds = "0.4";
                        break;
                    }
                case 13:
                    {
                        radX = 1.0032d;
                        radY = 0.5008d;
                        ds = "0.3";
                        break;
                    }
                case 14:
                    {
                        radX = 1.001d;
                        radY = 0.41d;
                        ds = "0.25";
                        break;
                    }
                case 15:
                    {
                        radX = 1.001d;
                        radY = 0.3228d;
                        ds = "0.2";
                        break;
                    }
                case 16:
                    {
                        radX = 1.001d;
                        radY = 0.199d;
                        ds = "0.125";
                        break;
                    }
                case 17:
                    {
                        radX = 1.001d;
                        radY = 0.1584d;
                        ds = "0.1";
                        break;
                    }

                case 18:
                    {
                        radX = 1.001d;
                        radY = 0.1423d;
                        ds = "0.09";
                        break;
                    }
                case 19:
                    {
                        radX = 1.001d;
                        radY = 0.1263d;
                        ds = "0.08";
                        break;
                    }
                case 20:
                    {
                        radX = 1.001d;
                        radY = 0.11037d;
                        ds = "0.07";
                        break;
                    }
                case 21:
                    {
                        radX = 1.001d;
                        radY = 0.09456d;
                        ds = "0.06";
                        break;
                    }
                case 22:
                    {
                        radX = 1.001d;
                        radY = 0.0787d;
                        ds = "0.05";
                        break;
                    }
                case 23:
                    {
                        radX = 1.001d;
                        radY = 0.06296d;
                        ds = "0.04";
                        break;
                    }
                case 24:
                    {
                        radX = 1.001d;
                        radY = 0.0472d;
                        ds = "0.03";
                        break;
                    }
                case 25:
                    {
                        radX = 1.001d;
                        radY = 0.03145d;
                        ds = "0.02";
                        break;
                    }
                case 26:
                    {
                        radX = 1.0d;
                        radY = 0.01572d;
                        ds = "0.01";
                        break;
                    }

                default:
                    {

                        Console.WriteLine("Error");
                        break;
                    }
            }


        }



        public static Arb GetAcbK(cbFuncApc func, ArbMatC @params, Arb a, Arb b, Arb radX, Arb radY)
        {
            ArbC x = new ArbC(), x1 = new ArbC(), z = new ArbC();
            Arb ba2 = new Arb(), av = new Arb(), x_re = new Arb(), x_im = new Arb();
            ba2 = (b - a) / 2;
            x_re.Mid = (b + a) / 2;
            x_re.Rad = ba2 * radX;
            x_im.Mid = aflint.t(0);
            x_im.Rad = ba2 * radY;
            x = aflintc.t(x_re, x_im);
            // x.real = x_re
            // x.imag = x_im
            // Console.WriteLine("x.real.Infimum: {0}, x.real.Supremum: {1}", x.real.Infimum, x.real.Supremum)
            // Console.WriteLine("x.imag.Infimum: {0}, x.imag.Supremum: {1}", x.imag.Infimum, x.imag.Supremum)
            z = func(x);
            // z = func(x, params)
            // Console.WriteLine("x: {0}, z: {1}", x, z)
            av = aflintc.abs(z);
            // Console.WriteLine("x: {0}, z: {1}, av: {2}", x, z, av)

            return av.Supremum();
        }






        // **********************************************************************************************************    
        // **********************************************************************************************************    


        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If Win64 Then
        */
        public static void WrapperParams_GL_Outer(IntPtr fxPtr, IntPtr xPtr, IntPtr paramsPtr, ulong order, ulong prec)
        {
            /* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            *//* TODO ERROR: Skipped DisabledTextTrivia
                    Sub WrapperParams_GL_Outer(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt32, ByVal prec As UInt32)
            *//* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */        // Dim old_prec = mp4.getprec()
                      // Console.WriteLine("In WrapperParams_GL_Outer: order: {0}, prec: {1}, paramsPtr: {2}", order, prec, paramsPtr)
                      // mp4.setprec(CUInt(prec))
                      // Dim x As New ArbC(xPtr, True)
                      // Dim fx As New ArbC()
                      // fx = AcbIntegrand_Outer(x, Nothing)
                      // fx.CopyToPtr(fxPtr)
                      // mp4.setprec(old_prec)
        }


        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If Win64 Then
        */
        public static void WrapperParams_GL_Inner(IntPtr fxPtr, IntPtr xPtr, IntPtr paramsPtr, ulong order, ulong prec)
        {
            /* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            *//* TODO ERROR: Skipped DisabledTextTrivia
                    Sub WrapperParams_GL_Inner(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt32, ByVal prec As UInt32)
            *//* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */        // Dim old_prec = mp4.getprec()
                      // mp4.setprec(CUInt(prec))
                      // Dim x As New ArbC(xPtr, True)
                      // Dim fx As New ArbC()
                      // fx = AcbIntegrand_Inner(x, Nothing)
                      // fx.CopyToPtr(fxPtr)
                      // mp4.setprec(old_prec)
        }




        public static ArbC RumpAcb_old(ArbC x, ArbMatC @params)
        {
            return aflintc.sin(x + aflintc.exp(x));
        }




        public static void DemoAcbIntegrationRumpExample_GL_old()
        {
            // mp4.setprec(100)
            AcbParams[0] = aflintc.t(mp_integral_Rump);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 2U;
            a = aflintc.t(0);
            b = aflintc.t(8);
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
        }


        public static ArbC RumpAcb(ArbC r, ArbMatC @params)
        {
            var a = aflint.t("1000000");
            var z = a - 4000;
            var f = aflintc.exp(-r);
            var c = 1 + f;
            // Dim d = c ^ -(a + 1)
            var d = aflint.pow(c, -(a + 1));
            var e = aflintc.exp(-z / c);
            var result = d * e * f;
            // result = result * z ^ a / aflintc.gamma(a)
            result = result * aflint.pow(z, a) / aflintc.gamma(a);
            return result;
        }




        public static void DemoAcbIntegrationRumpExample_GL()
        {
            ArbPrec.SetDps(40);
            AcbParams[0] = aflintc.t(mp_integral_Rump);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 1U;
            a = aflintc.t(5.2d);
            b = aflintc.t(40);
            // Dim rel_goal As UInt32 = workinmrealec
            // Dim abs_tol_bits As UInt32 = workinmrealec
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
        }





        public static ArbC AcbSinExp(ArbC t, ArbMatC @params)
        {
            return aflintc.sin(aflintc.exp(t));
        }



        public static void DemoAcbSinExpIntegration_DE()
        {
            ArbPrec.SetDps(40);
            AcbParams[0] = aflintc.t(mp_integral_AcbSinExp_DE);
            Arb a = new Arb(), b = new Arb(), epsabsStart = new Arb(), alpha = new Arb(), beta = new Arb();
            // a = 0.0 : b = 2.0 : alpha = 0.5 : beta = 1.0 ' alpha = 0.5 to compensate for omitting division by sqrt(x)
            // epsabsStart = "1.0E-30"
            // DE_Integration(AddressOf AcbIntegrand_Outer, AcbParams, a, b, epsabsStart, alpha, beta)
        }




        public static ArbC cf_chisquared(Arb k, ArbC t)
        {
            var ione = new ArbC();
            ione = aflintc.onei();
            // ione.real = 0
            // ione.imag = 1
            // Return (1 - 2 * ione * t) ^ (-k / 2)
            return aflintc.pow(1 - 2 * ione * t, -k / 2);
        }


        public static ArbC g_chisquared(ArbC t, ArbMatC @params)
        {
            Arb k = new Arb(), x = new Arb();
            k = aflint.t(10000);
            x = k - 500;
            ArbC result = new ArbC(), phi = new ArbC(), z = new ArbC(), ione = new ArbC();
            ione = aflintc.onei();
            // ione.real = 0
            // ione.imag = 1
            phi = cf_chisquared(k, t);
            z = aflintc.exp(-ione * t * x) * phi;
            result = z.imag / t;
            return result;
        }


        public static ArbC g_chisquared_u2(ArbC u, ArbMatC @params)
        {
            ArbC t = new ArbC(), g = new ArbC(), result = new ArbC();
            t = u / (1 - u);
            g = g_chisquared(t, @params);
            result = g / ((1 - u) * (1 - u));
            return result;
        }



        public static void Demo_g_chisquared_GL()
        {
            //uint p = 2U;
            // mp4.setprec(100)
            AcbParams[0] = aflintc.t(mp_integral_g_chisquared);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 1U;
            a = aflintc.t("1E-30");
            b = aflintc.t(0.9999999999d);
            // b = 0.1
            // Dim rel_goal As UInt32 = workinmrealec \ p
            // Dim abs_tol_bits As UInt32 = workinmrealec \ p
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            var s1 = s / aflint.pi();
            Console.WriteLine("Integral/pi: {0}", s1);
            var result = 0.5d - s1;
            Console.WriteLine("Result: {0}", result);
        }





        public static ArbC cf_betaflintproduct(ArbC t, int p, ArbMat b, ArbMat c)
        {
            ArbC ione = new ArbC(), result = new ArbC(), bk = new ArbC(), dk = new ArbC(), g1 = new ArbC(), g2 = new ArbC(), g3 = new ArbC(), g4 = new ArbC(), prod1 = new ArbC();
            result = aflintc.t(1);
            ione = aflintc.onei();
            // ione.real = 0
            // ione.imag = 1
            for (int k = 1, loopTo = p; k <= loopTo; k++)
            {
                bk = aflintc.t(b[k]);
                dk = aflintc.t(c[k]);
                g1 = aflintc.gamma(bk - ione * t);
                g2 = aflintc.gamma(dk);
                g3 = aflintc.gamma(bk);
                g4 = aflintc.gamma(dk - ione * t);
                prod1 = g1 * g2 / (g3 * g4);
                result = result * prod1;
            }
            return result;
        }


        public static ArbC g_betaflintproduct(ArbC t, ArbMatC @params)
        {
            Arb n = new Arb(), x = new Arb();
            x = aflint.t(4.5292648821553d);
            int p = 4;
            int f1 = 7 - 1;
            n = aflint.t(20 - 7);
            ArbMat b = new ArbMat(), c = new ArbMat();
            b.Resize(p + 1, 1);
            c.Resize(p + 1, 1);
            for (int i = 1, loopTo = p; i <= loopTo; i++)
            {
                b[i] = (n - i + 1) / 2;
                c[i] = b[i] + f1 / 2d;
            }
            ArbC result = new ArbC(), phi = new ArbC(), z = new ArbC(), ione = new ArbC();
            ione = aflintc.onei();
            // ione.real = 0
            // ione.imag = 1
            phi = cf_betaflintproduct(t, p, b, c);
            z = aflintc.exp(-ione * t * x) * phi;
            result = z.imag / t;
            return result;
        }


        public static ArbC g_betaflintproduct_u2(ArbC u, ArbMatC @params)
        {
            ArbC t = new ArbC(), g = new ArbC(), result = new ArbC();
            t = u / (1 - u);
            g = g_betaflintproduct(t, @params);
            result = g / ((1 - u) * (1 - u));
            return result;
        }


        public static ArbC g_betaflintproduct_u(ArbC u, ArbMatC @params)
        {
            ArbC t = new ArbC(), g = new ArbC(), result = new ArbC();
            t = (1 - u) / u;
            g = g_betaflintproduct(t, @params);
            result = g / (u * u);
            return result;
        }


        public static void Demo_g_betaflintproduct_GL()
        {
            //uint p = 2U;
            // mp4.setprec(100)
            AcbParams[0] = aflintc.t(mp_integral_g_betaflintproduct);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            // Dim workinmrealec As UInt32 = mp4.getprec()
            //uint verbose = 1U;
            // a = aflint.t("1E-30")
            // b = 0.9999999999
            a = aflintc.t("1E-30");
            b = aflintc.t(100);
            // b = 0.1
            // Dim rel_goal As UInt32 = workinmrealec \ p
            // Dim abs_tol_bits As UInt32 = workinmrealec \ p
            //uint eval_limit = 0U;
            // s = aflintc.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
            // Console.WriteLine("Integral: {0}", s)
            var s1 = s / aflint.pi();
            Console.WriteLine("Integral/pi: {0}", s1);
            var result = 0.5d - s1;
            Console.WriteLine("Result: {0}", result);

        }





        // **********************************************************************************************************    
        // **********************************************************************************************************    
        // **********************************************************************************************************    
        // **********************************************************************************************************    





        internal const int mp_proc_outer_pos = 0;
        internal const int mp_mreal_function_choice_outer_pos = 1;
        internal const int mp_abs_error_pos = 2;
        internal const int mp_k_pos = 3;
        internal const int mp_n_pos = 4;
        internal const int mp_crit_outer_pos = 5;
        internal const int mp_crit_inner_pos = 6;
        internal const int mp_proc_inner_pos = 7;
        internal const int mp_mreal_function_choice_inner_pos = 8;
        internal const int mp_mu_start_pos = 9;




        internal const int mp_integral_studentized_maximum = 0;
        internal const int mp_integral_studentized_maxmodulus = 1;
        internal const int mp_integral_normal_range = 2;
        internal const int mp_integral_studentized_range = 3;
        internal const int mp_integral_normal_dunnett1 = 4;
        internal const int mp_integral_studentized_dunnett1 = 5;
        internal const int mp_integral_normal_dunnett2 = 6;
        internal const int mp_integral_studentized_dunnett2 = 7;
        internal const int mp_integral_Rump = 8;
        internal const int mp_integral_AcbSinExp_DE = 9;
        internal const int mp_integral_AcbSinExp_GL = 10;
        internal const int mp_integral_normal_maximum = 12;
        internal const int mp_integral_normal_maxmodulus = 13;
        internal const int mp_integral_normal_mcm1 = 14;
        internal const int mp_integral_normal_mcm2 = 15;

        internal const int mp_integral_chisquare_nc = 15;
        internal const int mp_integral_t_nc = 16;
        internal const int mp_integral_f_nc = 17;
        internal const int mp_integral_beta_nc = 18;
        internal const int mp_integral_rho = 19;
        internal const int mp_integral_rho2 = 20;
        internal const int mp_integral_chisquare = 21;

        internal const int mp_integral_gammastar = 22;
        internal const int mp_integral_gammastar2 = 23;
        internal const int mp_integral_g_chisquared = 24;
        internal const int mp_integral_g_betaflintproduct = 25;



        // **********************************************************************************************************    

        public static Mpfr MpfrCalcParams_Outer(Mpfr x, MpfrMat mreal_params)
        {
            // Dim params = aflintc.mat_t(mreal_params)
            // Dim resacb = AcbIntegrand_Outer(aflintc.t(x), params)
            var resapc = AcbIntegrand_Outer(aflintc.t(x), null);
            return mreal.t(resapc.real);
        }


        public static void FuncMpfrParams_Outer(IntPtr xPtr, IntPtr paramsPtr, IntPtr fxPtr)
        {
            // Dim x As New Mpfr(xPtr, True)
            var fx = new Mpfr();
            // Dim params As New MpfrMat()
            // Dim tparamsPtr As IntPtr : tparamsPtr = params.mpPtr : params.mpPtr = paramsPtr

            // Dim proc As Int32 = MpfrParams(mp_mreal_function_choice_outer_pos).ToInt32
            int proc = 1;
            var AbsCDFErr = MpfrParams[mp_abs_error_pos];

            switch (proc)
            {
                default:
                    {
                        // Case 0 : fx = -MpfrCalcParams_Outer(x, MpfrParams)
                        // Case 1 : fx = (MpfrCalcParams_Outer(x, MpfrParams) * mreal.abs(x)) - AbsCDFErr
                        // Case 2 : fx = -MpfrCalcParams_Outer(x, MpfrParams) * x * x
                        // Case 3 : fx = ((MpfrCalcParams_Outer(x, MpfrParams) * x * x) * (1 / x)) - AbsCDFErr
                        fx = mreal.nan();
                        break;
                    }
            }

            // Console.WriteLine("Outer: x: {0}, f(x): {1}", x, fx)
            // paramsPtr = params.mpPtr : params.mpPtr = tparamsPtr
            // 'fx.CopyToPtr(fxPtr)
        }


        // Sub MpfrSolverBoost_Outer(bracket_min As Mpfr, bracket_max As Mpfr, params2 As MpfrMat, ByRef Max_Simple As Mpfr, ByRef LeftBorder As Mpfr, ByRef RightBorder As Mpfr)
        // '        mp4.setprec(100)

        // Dim result As New Mpfr
        // 'Dim get_digits As Int32 = CInt(getprec()) - 5, maxit As UInt32 = 100
        // Dim get_digits As Int32 = 10, maxit As UInt32 = 100

        // MpfrParams(mp_mreal_function_choice_outer_pos) = 0
        // 'Dim bits As Int32 = CInt(getprec()) - 5
        // Dim bits As Int32 = 10
        // '        bracket_max = 100.0
        // '        Console.WriteLine("Outer: Brent_MinimumParams: Max_Simple")
        // Max_Simple = mpfrCallback.Brent_MinimumParams(AddressOf FuncMpfrParams_Outer, MpfrParams, bracket_min, bracket_max, bits, maxit)
        // Console.WriteLine("Outer: Max_Simple: {0}", Max_Simple)

        // MpfrParams(mp_mreal_function_choice_outer_pos) = 1
        // Dim guess, factor As New Mpfr
        // guess = Max_Simple / 1.02
        // factor = 1.2
        // Dim is_rising As Boolean = True
        // '        Console.WriteLine("Outer: BracketRoot")
        // LeftBorder = mpfrCallback.BracketRootParams(AddressOf FuncMpfrParams_Outer, MpfrParams, guess, factor, is_rising, get_digits, 2000)
        // Console.WriteLine("Outer: LeftBorder: {0}", LeftBorder)


        // Dim Max_X2 As New Mpfr
        // MpfrParams(mp_mreal_function_choice_outer_pos) = 2
        // bracket_min = Max_Simple
        // bracket_max = Max_Simple + 1
        // '        bracket_max = 100.0
        // '        Console.WriteLine("Outer: Brent_MinimumParams: Max_X2")
        // Max_X2 = mpfrCallback.Brent_MinimumParams(AddressOf FuncMpfrParams_Outer, MpfrParams, bracket_min, bracket_max, bits, maxit)
        // Console.WriteLine("Outer: Max_X2: {0}", Max_X2)

        // MpfrParams(mp_mreal_function_choice_outer_pos) = 3
        // guess = Max_X2 * 1.02
        // factor = 1.2
        // is_rising = False
        // '        Console.WriteLine("Outer: BracketRoot")
        // RightBorder = mpfrCallback.BracketRootParams(AddressOf FuncMpfrParams_Outer, MpfrParams, guess, factor, is_rising, get_digits, maxit)
        // Console.WriteLine("Outer: RightBorder: {0}", RightBorder)

        // End Sub


        // **********************************************************************************************************    

        public static Mpfr MpfrCalcParams_Inner(Mpfr x, MpfrMat mreal_params)
        {
            // Dim params = aflintc.mat_t(mreal_params)
            // Dim resacb = AcbIntegrand_Inner(aflintc.t(x), params)
            var resapc = AcbIntegrand_Inner(aflintc.t(x), null);
            return mreal.t(resapc.real);
        }


        public static void FuncMpfrParams_Inner(IntPtr xPtr, IntPtr paramsPtr, IntPtr fxPtr)
        {
            // Dim x As New Mpfr(xPtr, True)
            var fx = new Mpfr();
            // Dim params As New MpfrMat()
            // Dim tparamsPtr As IntPtr : tparamsPtr = params.mpPtr : params.mpPtr = paramsPtr

            // Dim proc As Int32 = MpfrParams(mp_mreal_function_choice_inner_pos).ToInt32
            int proc = 1;
            var AbsCDFErr = MpfrParams[mp_abs_error_pos];

            switch (proc)
            {
                default:
                    {
                        // Case 0 : fx = -MpfrCalcParams_Inner(x, MpfrParams)
                        // Case 1 : fx = (MpfrCalcParams_Inner(x, MpfrParams) * mreal.abs(x)) - AbsCDFErr
                        // Case 2 : fx = -MpfrCalcParams_Inner(x, MpfrParams) * x * x
                        // Case 3 : fx = ((MpfrCalcParams_Inner(x, MpfrParams) * x * x) * (1 / x)) - AbsCDFErr
                        fx = mreal.nan();
                        break;
                    }
            }

            // Console.WriteLine("Inner: x: {0}, f(x): {1}", x, fx)
            // paramsPtr = params.mpPtr : params.mpPtr = tparamsPtr
            // fx.CopyToPtr(fxPtr)
        }



        // Sub MpfrSolverBoost_Inner(bracket_min As Mpfr, bracket_max As Mpfr, params2 As MpfrMat, ByRef Max_Simple As Mpfr, ByRef LeftBorder As Mpfr, ByRef RightBorder As Mpfr)

        // 'Dim get_digits As Int32 = CInt(getprec()) - 5, maxit As UInt32 = 25
        // 'Dim bits As Int32 = CInt(getprec()) - 5

        // Dim get_digits As Int32 = 10, maxit As UInt32 = 25
        // Dim bits As Int32 = 10

        // MpfrParams(mp_mreal_function_choice_inner_pos) = 0
        // '        bracket_max = 100.0
        // '        Console.WriteLine("Inner: Brent_MinimumParams: Max_Simple")
        // Max_Simple = mpfrCallback.Brent_MinimumParams(AddressOf FuncMpfrParams_Inner, MpfrParams, bracket_min, bracket_max, bits, maxit)
        // Console.WriteLine("Inner: Max_Simple: {0}", Max_Simple)

        // MpfrParams(mp_mreal_function_choice_inner_pos) = 1
        // Dim guess, factor As New Mpfr
        // guess = -1
        // factor = 1.2
        // Dim is_rising As Boolean = True
        // '        Console.WriteLine("Inner: BracketRoot")
        // LeftBorder = mpfrCallback.BracketRootParams(AddressOf FuncMpfrParams_Inner, MpfrParams, guess, factor, is_rising, get_digits, 200)
        // Console.WriteLine("Inner: LeftBorder: {0}", LeftBorder)


        // Dim Max_X2 As New Mpfr
        // MpfrParams(mp_mreal_function_choice_inner_pos) = 2
        // bracket_min = Max_Simple
        // bracket_max = Max_Simple + 1
        // '        bracket_max = 100.0
        // '        Console.WriteLine("Inner: Brent_MinimumParams: Max_X2")
        // Max_X2 = mpfrCallback.Brent_MinimumParams(AddressOf FuncMpfrParams_Inner, MpfrParams, bracket_min, bracket_max, bits, maxit)
        // Console.WriteLine("Inner: Max_X2: {0}", Max_X2)

        // MpfrParams(mp_mreal_function_choice_inner_pos) = 3
        // guess = Max_X2 * 1.02
        // factor = 1.2
        // is_rising = False
        // '        Console.WriteLine("Inner: BracketRoot")
        // RightBorder = mpfrCallback.BracketRootParams(AddressOf FuncMpfrParams_Inner, MpfrParams, guess, factor, is_rising, get_digits, maxit)
        // Console.WriteLine("Inner: RightBorder: {0}", RightBorder)

        // End Sub

        // **********************************************************************************************************    



        public static ArbC AcbIntegrand_Outer(ArbC x, ArbMatC params2)
        {
            // Console.WriteLine("Before Read: params.mpPtr: {0}", AcbParams.mpPtr)
            // Dim proc_outer As Int32 = AcbParams(mp_proc_outer_pos).real.ToInt32
            int proc_outer = 1;
            Console.WriteLine("After  Read: params.mpPtr: {0}, proc_outer: {1}", AcbParams.mpPtr, proc_outer);
            // Dim proc_outer As Int32 = 8
            var fx = new ArbC();
            switch (proc_outer)
            {
                case mp_integral_studentized_maximum:
                    {
                        fx = Studentize(x, AcbParams);   // 0
                        break;
                    }
                case mp_integral_studentized_maxmodulus:
                    {
                        fx = Studentize(x, AcbParams);   // 1
                        break;
                    }
                case mp_integral_studentized_range:
                    {
                        fx = Studentize(x, AcbParams);   // 3
                        break;
                    }
                case mp_integral_studentized_dunnett1:
                    {
                        fx = Studentize(x, AcbParams);  // 5
                        break;
                    }
                case mp_integral_studentized_dunnett2:
                    {
                        fx = Studentize(x, AcbParams);   // 7
                        break;
                    }

                case mp_integral_Rump:
                    {
                        fx = RumpAcb(x, AcbParams);  // 8
                        break;
                    }
                case mp_integral_g_chisquared:
                    {
                        fx = g_chisquared_u2(x, AcbParams);  // 24
                        break;
                    }
                // Case mp_integral_g_betaflintproduct : fx = g_betaflintproduct_u2(x, AcbParams)
                case mp_integral_g_betaflintproduct:
                    {
                        fx = g_betaflintproduct(x, AcbParams);  // 25
                        break;
                    }
                case mp_integral_AcbSinExp_DE:
                    {
                        fx = AcbSinExp(x, AcbParams);  // 9
                        break;
                    }
                case mp_integral_AcbSinExp_GL:
                    {
                        fx = AcbSinExp(x, AcbParams) / aflintc.sqrt(x);  // 10
                        break;
                    }

                default:
                    {
                        Console.WriteLine("!!!! Error AcbIntegrand_Outer !!!!!)");
                        fx = aflintc.nan();
                        break;
                    }
            }
            // Console.WriteLine("fx: {0}", fx)
            return fx;
        }


        public static ArbC AcbIntegrand_Inner(ArbC x, ArbMatC params2)
        {
            // Dim proc_inner As Int32 = AcbParams(mp_proc_inner_pos).real.ToInt32
            int proc_inner = 1;
            var fx = new ArbC();
            switch (proc_inner)
            {
                case mp_integral_normal_range:
                    {
                        fx = AcbNormalRange(x, AcbParams);
                        break;
                    }
                case mp_integral_normal_dunnett1:
                    {
                        fx = AcbNormalDunnett1(x, AcbParams);
                        break;
                    }
                case mp_integral_normal_dunnett2:
                    {
                        fx = AcbNormalDunnett2(x, AcbParams);
                        break;
                    }
                case mp_integral_normal_mcm1:
                    {
                        fx = AcbNormalMCM1(x, AcbParams);
                        break;
                    }
                case mp_integral_normal_mcm2:
                    {
                        fx = AcbNormalMCM2(x, AcbParams);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("!!!! Error AcbIntegrand_Inner !!!!!)");
                        fx = aflintc.nan();
                        break;
                    }
            }
            // Console.WriteLine("fx: {0}", fx)
            return fx;
        }






        // **********************************************************************************************************    
        // **********************************************************************************************************    



        public static ArbC NdisAcb(ArbC x)
        {
            return aflintc.ndis(x);
        }


        public static ArbC NdensAcb(ArbC x)
        {
            return aflintc.ndens(x);
        }





        public static ArbC NormalMaxModulus(ArbMatC params2)
        {
            ArbC res = new ArbC(), delta = new ArbC();
            // Dim proc_inner As Int32 = AcbParams(mp_proc_inner_pos).real.ToInt32
            // Dim k As Int32 = AcbParams(mp_k_pos).real.ToInt32
            int proc_inner = 1;
            int k = 1;
            var x = AcbParams[mp_crit_inner_pos];
            res = aflintc.t(1.0d);
            for (int i = 0, loopTo = k - 1; i <= loopTo; i++)
            {
                delta = AcbParams[i + mp_mu_start_pos];
                switch (proc_inner)
                {
                    case mp_integral_normal_maximum:
                        {
                            res = res * NdisAcb(x - delta);
                            break;
                        }
                    case mp_integral_normal_maxmodulus:
                        {
                            res = res * (NdisAcb(x - delta) - NdisAcb(-x - delta));
                            break;
                        }

                    default:
                        {
                            res = aflintc.nan();
                            break;
                        }
                }
            }
            return res;
        }




        public static ArbC AcbNormalDunnett1(ArbC y, ArbMatC params2)
        {
            ArbC rho = new ArbC(), k = new ArbC(), x = new ArbC(), d = new ArbC();
            k = AcbParams[mp_k_pos];
            x = AcbParams[mp_crit_inner_pos];  // critical value for inner integration
            rho = aflintc.t("0.5");
            d = NdisAcb((x + y * aflintc.sqrt(rho)) / aflintc.sqrt(1 - rho));
            d = aflintc.pow(d, k);
            d = d * NdensAcb(y);
            // Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
            return d;
        }



        public static ArbC AcbNormalDunnett2(ArbC y, ArbMatC params2)
        {
            ArbC rho = new ArbC(), k = new ArbC(), x = new ArbC(), d1 = new ArbC(), d2 = new ArbC(), d = new ArbC();
            k = AcbParams[mp_k_pos];
            x = AcbParams[mp_crit_inner_pos];  // critical value for inner integration
            rho = aflintc.t("0.5");
            d1 = NdisAcb((x + y * aflintc.sqrt(rho)) / aflintc.sqrt(1 - rho));
            d2 = NdisAcb((-x + y * aflintc.sqrt(rho)) / aflintc.sqrt(1 - rho));
            d = aflintc.pow(d1 - d2, k);
            d = d * NdensAcb(y);
            // Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
            return d;
        }


        // Multiple comparisons with the mean: see Soong 2001
        public static ArbC AcbNormalMCM1(ArbC y, ArbMatC params2)
        {
            ArbC rho = new ArbC(), k = new ArbC(), x = new ArbC(), d = new ArbC();
            k = AcbParams[mp_k_pos];
            x = AcbParams[mp_crit_inner_pos];  // critical value for inner integration
                                               // rho = aflintc.t("0.5")
            rho = -1 / k;
            d = NdisAcb((x + y * aflintc.sqrt(rho)) / aflintc.sqrt(1 - rho));
            d = aflintc.pow(d, k);
            d = d * NdensAcb(y);
            // Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
            return d;
        }


        // Multiple comparisons with the mean: see Soong 2001
        public static ArbC AcbNormalMCM2(ArbC y, ArbMatC params2)
        {
            ArbC rho = new ArbC(), k = new ArbC(), x = new ArbC(), d1 = new ArbC(), d2 = new ArbC(), d = new ArbC();
            k = AcbParams[mp_k_pos];
            x = AcbParams[mp_crit_inner_pos];  // critical value for inner integration
                                               // rho = aflintc.t("0.5")
            rho = -1 / k;
            d1 = NdisAcb((x + y * aflintc.sqrt(rho)) / aflintc.sqrt(1 - rho));
            d2 = NdisAcb((-x + y * aflintc.sqrt(rho)) / aflintc.sqrt(1 - rho));
            d = aflintc.pow(d1 - d2, k);
            d = d * NdensAcb(y);
            // Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
            return d;
        }


        public static ArbC AcbNormalRange(ArbC y, ArbMatC params2)
        {
            ArbC k = new ArbC(), x = new ArbC(), d1 = new ArbC(), d2 = new ArbC(), d = new ArbC();
            k = AcbParams[mp_k_pos] + 1;
            x = AcbParams[mp_crit_inner_pos] * aflintc.sqrt(aflintc.t("2"));  // critical value for inner integration
            d1 = NdisAcb(y);
            d2 = NdisAcb(y - x);
            d = k * aflintc.pow(d1 - d2, k - 1);
            d = d * NdensAcb(y);
            // Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
            return d;
        }



        public static ArbC Studentize(ArbC x, ArbMatC params2)
        {
            ArbC n = new ArbC(), c = new ArbC(), a = new ArbC(), b = new ArbC(), res1 = new ArbC(), res2 = new ArbC(), fx = new ArbC();
            // Dim proc_outer As Int32 = AcbParams(mp_proc_outer_pos).real.ToInt32
            // Dim k As Int32 = AcbParams(mp_k_pos).real.ToInt32
            int proc_outer = 1;
            //int k = 1;
            n = AcbParams[mp_n_pos];
            c = AcbParams[mp_crit_outer_pos];
            AcbParams[mp_crit_inner_pos] = c * x;
            switch (proc_outer)
            {
                case mp_integral_studentized_maximum:
                    {
                        res1 = NormalMaxModulus(AcbParams);
                        break;
                    }
                case mp_integral_studentized_maxmodulus:
                    {
                        res1 = NormalMaxModulus(AcbParams);
                        break;
                    }

                default:
                    {
                        // Case mp_integral_studentized_dunnett1 : res1 = MultivariateNormalIntegral(AcbParams)
                        // Case mp_integral_studentized_dunnett2 : res1 = MultivariateNormalIntegral(AcbParams)
                        // Case mp_integral_studentized_range : res1 = MultivariateNormalIntegral(AcbParams)
                        res1 = aflintc.nan();
                        break;
                    }
            }
            // res1 = 1
            // a = n ^ (n / 2) * x ^ (n - 1) * aflintc.exp(-n * x * x / 2)
            a = aflintc.pow(n, n / 2) * aflintc.pow(x, n - 1) * aflintc.exp(-n * x * x / 2);
            // b = 2 ^ ((n - 1) / 2) * aflintc.gamma(n / 2) / aflintc.sqrt(2)
            b = aflintc.pow(2, (n - 1) / 2) * aflintc.gamma(n / 2) / aflintc.sqrt(2);
            res2 = a / b;
            fx = res1 * res2;
            // Console.WriteLine("x: {0}, cx: {1}, res1: {2}, res1*res2: {3}", x, c*x, res1, fx)
            return fx;
        }



        // Public Function MultivariateNormalIntegral(params2 As ArbMatC) As ArbC
        // Dim Max_Simple As New Mpfr
        // Dim LeftBorder As New Mpfr
        // Dim RightBorder As New Mpfr

        // Dim x = AcbParams(mp_crit_inner_pos)

        // Dim x0 As Arb
        // x0 = x.real.mid
        // AcbParams(mp_crit_inner_pos) = x0
        // Console.WriteLine("x0: {0}", x0)
        // Console.WriteLine("")

        // MpfrParams = mreal_mat.t(AcbParams.real)
        // Dim bracket_min, bracket_max As New Mpfr
        // bracket_min = -10.0
        // bracket_max = 10.0
        // MpfrSolverBoost_Inner(bracket_min, bracket_max, MpfrParams, Max_Simple, LeftBorder, RightBorder)
        // AcbParams(mp_crit_inner_pos) = x
        // Console.WriteLine("x: {0}", x)

        // Dim peak, a, b As New ArbC
        // peak = aflintc.t(Max_Simple)
        // a = aflintc.t(LeftBorder)
        // b = aflintc.t(RightBorder)

        // '        Console.WriteLine("Inner: x: {0}, a: {1}, b: {2}", x, a, b)
        // Dim workinmrealec As UInt32 = mp4.getprec()
        // Dim verbose As UInt32 = 2
        // Dim rel_goal As UInt32 = CUInt(workinmrealec)
        // Dim abs_tol_bits As UInt32 = CUInt(workinmrealec)
        // '        Dim rel_goal As UInt32 = CUInt( workinmrealec \ 2)
        // '        Dim abs_tol_bits As UInt32 = CUInt( workinmrealec \ 2)
        // Dim eval_limit As UInt32 = 0
        // 'Dim I1_GL = aflintc.gl_integration(AddressOf WrapperParams_GL_Inner, a, b, params, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        // Dim I1_GL = aflintc.gl_integration(AddressOf WrapperParams_GL_Inner, a, b, AcbParams, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        // '        Console.WriteLine("Inner Integral_GL:{0}", I1_GL)
        // '        Dim av = aflintc.abs(I1_GL)
        // '        Console.WriteLine("av:  {0}, av.supremum(): {1}, ", av, av.supremum())
        // Return I1_GL
        // End Function



        // Public Sub DemoMultivariateNormalIntegration()
        // ArbPrec.SetDps(40)

        // Dim n, x, RelErr As New ArbC
        // Dim k, inner_proc As Int32
        // Dim k1 As Double = 1.0

        // 'inner_proc = mp_integral_normal_dunnett1
        // 'inner_proc = mp_integral_normal_dunnett2
        // 'inner_proc = mp_integral_normal_range
        // 'inner_proc = mp_integral_normal_mcm1
        // inner_proc = mp_integral_normal_mcm2


        // x = aflintc.t("3.088")
        // RelErr = aflintc.t("1.0E-20")
        // k = 5 ' number of groups - 1
        // If ((inner_proc = mp_integral_normal_mcm1) And (k > 1)) Then
        // k1 = Math.Sqrt(k / (k - 1)) ' assumes k > 1; this factor is required to match for the tables of Nair 1948 and Grubbs 1950
        // End If
        // Console.WriteLine("k1: {0}", k1)
        // x = k1 * x
        // Dim x_re, x_im As Arb
        // x_re = 0
        // x_im = 0
        // x_re.mid = x.real
        // x_re.rad = 4.5
        // x_im.mid = x.imag
        // x_im.rad = 4.5
        // '        x.real = x_re
        // '        x.imag = x_im


        // 'Dim params As New ArbMatC
        // 'params = aflintc.mat_set_zero(mp_mu_start_pos + k, 1)
        // AcbParams(mp_proc_outer_pos) = 0
        // AcbParams(mp_mreal_function_choice_outer_pos) = 0 ' placeholder for proc outer integration
        // '        params(mp_abs_error_pos) = AbsCDFErr
        // AcbParams(mp_abs_error_pos) = RelErr

        // AcbParams(mp_k_pos) = k
        // AcbParams(mp_n_pos) = 0   ' placeholder for error df for outer integration
        // AcbParams(mp_crit_outer_pos) = 0   ' critical value for outer integration
        // AcbParams(mp_crit_inner_pos) = x   ' critical value for inner integration
        // AcbParams(mp_proc_inner_pos) = inner_proc
        // AcbParams(mp_mreal_function_choice_inner_pos) = 0 ' placeholder for proc inner integration

        // 'Dim result = MultivariateNormalIntegral(params)
        // Dim result = MultivariateNormalIntegral(Nothing)
        // Console.WriteLine("result DemoMultivariateNormalIntegration: {0}", result)
        // End Sub




        // Public Sub DemoStudentizedIntegration()
        // ArbPrec.SetDps(40)

        // Dim n, c, RelErr, AbsCDFErr As New ArbC
        // Dim proc_outer, proc_inner, k As Int32
        // 'proc_outer = mp_integral_studentized_maximum
        // proc_outer = mp_integral_studentized_maxmodulus
        // 'proc_outer = mp_integral_studentized_dunnett1
        // '        proc_outer = mp_integral_studentized_dunnett2
        // '        proc_outer = mp_integral_studentized_range

        // Select Case proc_outer
        // Case mp_integral_studentized_maximum : proc_inner = mp_integral_normal_maximum
        // Case mp_integral_studentized_maxmodulus : proc_inner = mp_integral_normal_maxmodulus
        // Case mp_integral_studentized_dunnett1 : proc_inner = mp_integral_normal_dunnett1
        // Case mp_integral_studentized_dunnett2 : proc_inner = mp_integral_normal_dunnett2
        // Case mp_integral_studentized_range : proc_inner = mp_integral_normal_range
        // Case Else : proc_inner = 0
        // End Select

        // k = 4 ' number of normal variables
        // n = aflintc.t("1.0")
        // c = aflintc.t("3.1")
        // RelErr = aflintc.t("1.0E-10")

        // Dim mu = apc_mat.set_zero(k, 1)
        // mu(0) = 0
        // mu(1) = 0
        // mu(2) = 0

        // AbsCDFErr = RelErr

        // 'Dim params = aflintc.mat_set_zero(mp_mu_start_pos + k, 1)
        // AcbParams(mp_proc_outer_pos) = proc_outer   ' proc for inner integratio
        // AcbParams(mp_mreal_function_choice_outer_pos) = 0   ' placeholder for function choice in mprf
        // AcbParams(mp_abs_error_pos) = AbsCDFErr  '  target absolute error for outer integral
        // AcbParams(mp_k_pos) = k   ' number of groups
        // AcbParams(mp_n_pos) = n   ' error df
        // AcbParams(mp_crit_outer_pos) = c   ' critical value for outer integration
        // AcbParams(mp_crit_inner_pos) = 0   ' critical value for inner integration
        // AcbParams(mp_proc_inner_pos) = proc_inner   ' proc for inner integration
        // AcbParams(mp_mreal_function_choice_inner_pos) = 0    ' function choice in mprf placeholder for proc inner integration
        // For i = 0 To (k - 1)
        // AcbParams(mp_mu_start_pos + i) = mu(i)
        // Next

        // Dim Max_Simple As New Mpfr
        // Dim LeftBorder As New Mpfr
        // Dim RightBorder As New Mpfr

        // 'Dim mreal_params = mreal.mat_t(params.real)
        // MpfrParams = mreal_mat.t(AcbParams.real)
        // Dim bracket_min, bracket_max As New Mpfr
        // Dim peak, a, b As New Arb

        // bracket_min = 0.0
        // bracket_max = 10.0
        // MpfrSolverBoost_Outer(bracket_min, bracket_max, MpfrParams, Max_Simple, LeftBorder, RightBorder)
        // peak = aflint.t(Max_Simple)
        // a = aflint.t(LeftBorder)
        // b = aflint.t(RightBorder)

        // peak = aflint.t("1.0")
        // a = aflint.t("1E-10")
        // b = aflint.t("5")

        // Dim workinmrealec As UInt32 = mp4.getprec()
        // Console.WriteLine("workinmrealec : {0}", workinmrealec)
        // Dim verbose As UInt32 = 2
        // Dim rel_goal As UInt32 = workinmrealec
        // Dim abs_tol_bits As UInt32 = workinmrealec
        // Dim eval_limit As UInt32 = 0
        // Dim I1_GL = aflintc.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        // '        Dim I1_GL = aflintc.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, params, workinmrealec, verbose, rel_goal, abs_tol_bits)
        // Console.WriteLine("Outer Integral_GL:{0}", I1_GL)
        // End Sub



        // Note: There are still a lot of issues with getting the right balance with:
        // mp4.setprec(100)
        // Dim eval_limit As UInt32 = 0
        // This can easily cause crashes in form of seg faults




        public static void DemoMCPArb()
        {
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If Win64 Then
            */
            Console.WriteLine("Running 64 bit");
            /* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            *//* TODO ERROR: Skipped DisabledTextTrivia
                    Console.WriteLine("Running 32 bit")
            *//* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */

            // DemoAcbIntegrationRumpExample_GL()
            // DemoAcbIntegrationRumpExample_GL_old()
            DemoAcbSinExpIntegration_DE();

            // DemoStudentizedIntegration()
            // DemoMultivariateNormalIntegration()

        }









    }
}