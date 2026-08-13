using System;
using Microsoft.VisualBasic;

namespace NewDistrib
{
    // Imports mpFunLabNET
    // Imports fpFunLabNET




    static class DistWilks
    {



        private const int jmax = 6000;



        public static void WilksExact2(int p, int f1, double f2, double l, ref double LeftTail, ref double Righttail)
        {
            int i;
            double[] b;
            double[] c;
            b = new double[p + 1];
            c = new double[p + 1];
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                b[i] = (f2 - i + 1d) / 2d;
                c[i] = b[i] + f1 / 2d;
            }
            DistBoxDavis.BetaProdDis2(p, b, c, l, ref LeftTail, ref Righttail);
        }



        public static double WilksExactX2(double LeftTail, double Righttail, int p, int f1, double f2)
        {
            int i;
            double[] b;
            double[] c;
            b = new double[p + 1];
            c = new double[p + 1];
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                b[i] = (f2 - i + 1d) / 2d;
                c[i] = b[i] + f1 / 2d;
            }
            return DistBoxDavis.BetaProdDisX2(LeftTail, Righttail, p, b, c);
        }





        // Sub TestMauchleyDis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 2 To p
        // b(j - 1) = (n - j) / 2
        // c(j - 1) = b(j - 1) + (j - 1) / p + (j - 1) / 2
        // 'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
        // End Sub


        // Function TestMauchleyDisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 2 To p
        // b(j - 1) = (n + 1 - j) / 2
        // c(j - 1) = b(j - 1) + (j - 1) / p + (j - 1) / 2
        // 'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // Return BetaProdDisX2(LeftTail, Righttail, p - 1, b, c)
        // End Function


        // 'Note: In Coelho_2012c, equation 32, n is sample size (not n+1, as we use it here)
        // Sub DemoTestMauchley()
        // '  p: # of variables in 1. set
        // '  n: # of cases-1 }      
        // Dim p, n As Int32
        // Dim LeftTail, RightTail, result2, resultM As Double
        // Dim LeftTail2, RightTail2 As Double
        // p = 15  ' number of variables
        // n = 125    ' n+1 is sample size
        // LeftTail = 0.9
        // RightTail = 1 - LeftTail

        // result2 = TestMauchleyDisX(LeftTail, RightTail, p, n)
        // Console.WriteLine("result2: {0}", result2)
        // resultM = -n * Math.Log(result2)
        // Console.WriteLine("resultM: {0}", resultM)

        // TestMauchleyDis(p, n, result2, LeftTail2, RightTail2)
        // Console.WriteLine("LeftTail2: {0}", LeftTail2)

        // End Sub


        // Sub TestWilksLvcm0Dis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 2 To p
        // b(j - 1) = (n - j) / 2
        // c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
        // 'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // b(p) = (n - 1) / 2
        // c(p) = b(p) + 1 / 2
        // Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
        // End Sub


        // Function TestWilksLvcm0DisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 2 To p
        // b(j - 1) = (n - j) / 2
        // c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
        // 'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // b(p) = (n - 1) / 2
        // c(p) = b(p) + 1 / 2
        // Return BetaProdDisX2(LeftTail, Righttail, p, b, c)
        // End Function


        // 'Note: In Coelho_2016, equation 55, n is sample size 
        // ' Tables are on page 10
        // Sub DemoTestWilksLvcm0()
        // '  p: # of variables in 1. set
        // '  n: # of cases-0 }      
        // Dim p, n As Int32
        // Dim LeftTail, RightTail, result2, resultM As Double
        // Dim LeftTail2, RightTail2 As Double
        // p = 15  ' number of variables
        // n = 65   ' n is sample size
        // LeftTail = 0.99
        // RightTail = 1 - LeftTail

        // result2 = TestWilksLvcm0DisX(LeftTail, RightTail, p, n)
        // Console.WriteLine("result2: {0}", result2)
        // resultM = -(n) * Math.Log(result2)
        // Console.WriteLine("resultM: {0}", resultM)

        // TestWilksLvcm0Dis(p, n, result2, LeftTail2, RightTail2)
        // Console.WriteLine("LeftTail2: {0}", LeftTail2)

        // End Sub


        // Sub TestWilksLvcmDis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 2 To p
        // b(j - 1) = (n - j) / 2
        // c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
        // 'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
        // End Sub


        // Function TestWilksLvcmDisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 2 To p
        // b(j - 1) = (n - j) / 2
        // c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
        // 'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // Return BetaProdDisX2(LeftTail, Righttail, p - 1, b, c)
        // End Function


        // 'Note: In Coelho_2016, equation 32, n is sample size 
        // ' Tables are on page 10
        // Sub DemoTestWilksLvcm()
        // '  p: # of variables in 1. set
        // '  n: # of cases-0 }      
        // Dim p, n As Int32
        // Dim LeftTail, RightTail, result2, resultM As Double
        // Dim LeftTail2, RightTail2 As Double
        // p = 15  ' number of variables
        // n = 65   ' n is sample size
        // LeftTail = 0.99
        // RightTail = 1 - LeftTail

        // result2 = TestWilksLvcmDisX(LeftTail, RightTail, p, n)
        // Console.WriteLine("result2: {0}", result2)
        // resultM = -(n) * Math.Log(result2)
        // Console.WriteLine("resultM: {0}", resultM)

        // TestWilksLvcmDis(p, n, result2, LeftTail2, RightTail2)
        // Console.WriteLine("LeftTail2: {0}", LeftTail2)

        // End Sub

        // Sub TestWilksLvcDis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 2 To p
        // b(j - 1) = (n - j) / 2
        // c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j - 1) / 2
        // 'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
        // End Sub


        // Function TestWilksLvcDisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 2 To p
        // b(j - 1) = (n - j) / 2
        // c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j - 1) / 2
        // 'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // Return BetaProdDisX2(LeftTail, Righttail, p - 1, b, c)
        // End Function


        // 'Note: In Coelho_2016, equation 53, n is sample size 
        // ' Tables are on page 10
        // Sub DemoTestWilksLvc()
        // '  p: # of variables in 1. set
        // '  n: # of cases-0 }      
        // Dim p, n As Int32
        // Dim LeftTail, RightTail, result2, resultM As Double
        // Dim LeftTail2, RightTail2 As Double
        // p = 15 ' number of variables
        // n = 65   ' n is sample size
        // LeftTail = 0.99
        // RightTail = 1 - LeftTail

        // result2 = TestWilksLvcDisX(LeftTail, RightTail, p, n)
        // Console.WriteLine("result2: {0}", result2)
        // resultM = -(n) * Math.Log(result2)
        // Console.WriteLine("resultM: {0}", resultM)

        // TestWilksLvcDis(p, n, result2, LeftTail2, RightTail2)
        // Console.WriteLine("LeftTail2: {0}", LeftTail2)

        // End Sub





        // Sub TestR0Dis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 1 To p - 1
        // b(j) = (n - p + j) / 2
        // c(j) = b(j) + (p - j) / 2
        // Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
        // End Sub


        // Function TestR0DisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
        // Dim j As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p) : ReDim c(p)
        // For j = 1 To p - 1
        // b(j) = (n - p + j) / 2
        // c(j) = b(j) + (p - j) / 2
        // Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        // Next j
        // Return BetaProdDisX2(LeftTail, Righttail, p - 1, b, c)
        // End Function



        // 'Coelho_2012, equation 9, n + 1 is sample size
        // Sub DemoTestR0()
        // '  p: # of variables in 1. set
        // '  n: # of cases-1 }      
        // Dim p, n As Int32
        // Dim LeftTail, RightTail, result2, resultM As Double
        // Dim LeftTail2, RightTail2 As Double
        // p = 5  ' number of variables
        // n = 25 - 1   'Coelho_2012, equation 9, n + 1 is sample size
        // LeftTail = 0.9
        // RightTail = 1 - LeftTail

        // result2 = TestR0DisX(LeftTail, RightTail, p, n)
        // Console.WriteLine("result2: {0}", result2)
        // resultM = -n * Math.Log(result2)
        // Console.WriteLine("resultM: {0}", resultM)

        // TestR0Dis(p, n, result2, LeftTail2, RightTail2)
        // Console.WriteLine("LeftTail2: {0}", LeftTail2)

        // End Sub



        // Sub TestR0KSetsDis(k As Integer, p() As Integer, n As Integer, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        // Dim i, j, m, pmax As Integer
        // Dim pp() As Int32
        // ReDim pp(k)
        // pp(k) = 0
        // pmax = 0
        // For i = k - 1 To 1 Step -1
        // pp(i) = pp(i + 1) + p(i)
        // pmax = pmax + p(i)
        // Next i
        // Dim b() As Double, c() As Double
        // ReDim b(pmax) : ReDim c(pmax)
        // m = 0
        // For i = 1 To k - 1
        // For j = 1 To p(i)
        // m = m + 1
        // b(m) = (n + 1 - pp(i) - j) / 2
        // c(m) = b(m) + pp(i) / 2
        // Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
        // Next j
        // Next i
        // Call BetaProdDis2(m, b, c, l, LeftTail, Righttail)
        // End Sub



        // Function TestR0KSetsDisX(LeftTail As Double, Righttail As Double, k As Integer, p() As Integer, n As Integer) As Double
        // Dim i, j, m, pmax As Integer
        // Dim pp() As Int32
        // ReDim pp(k)
        // pp(k) = 0
        // pmax = 0
        // For i = k - 1 To 1 Step -1
        // pp(i) = pp(i + 1) + p(i)
        // pmax = pmax + p(i)
        // Next i
        // Dim b() As Double, c() As Double
        // ReDim b(pmax) : ReDim c(pmax)
        // m = 0
        // For i = 1 To k - 1
        // For j = 1 To p(i)
        // m = m + 1
        // b(m) = (n + 1 - pp(i) - j) / 2
        // c(m) = b(m) + pp(i) / 2
        // Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
        // Next j
        // Next i
        // Return BetaProdDisX2(LeftTail, Righttail, m, b, c)
        // End Function



        // Sub TestBartlettDis(p As Integer, q As Integer, n As Integer, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        // Dim j, k, m As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p * q) : ReDim c(p * q)
        // m = 0
        // For j = 1 To p
        // For k = 1 To q
        // If (j = 1 And k = 1) Then
        // 'Console.WriteLine("The item (j = 1 And k = 1) needs to be omitted")
        // Else
        // m = m + 1
        // b(m) = (n + 1 - j) / 2
        // c(m) = b(m) + (j * (q - 1) + 2 * k - 1 - q) / (2 * q)
        // 'Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
        // End If
        // Next k
        // Next j
        // Call BetaProdDis2(m, b, c, l, LeftTail, Righttail)
        // End Sub



        // Function TestBartlettDisX(LeftTail As Double, Righttail As Double, p As Integer, q As Integer, n As Integer) As Double
        // Dim j, k, m As Integer
        // Dim b() As Double, c() As Double
        // ReDim b(p * q) : ReDim c(p * q)
        // m = 0
        // For j = 1 To p
        // For k = 1 To q
        // If (j = 1 And k = 1) Then
        // Console.WriteLine("The item (j = 1 And k = 1) needs to be omitted")
        // Else
        // m = m + 1
        // b(m) = (n + 1 - j) / 2
        // c(m) = b(m) + (j * (q - 1) + 2 * k - 1 - q) / (2 * q)
        // Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
        // End If
        // Next k
        // Next j
        // Return BetaProdDisX2(LeftTail, Righttail, m, b, c)
        // End Function


        // 'Note: In Coelho_2012c, equation 30, n is sample size (not n+1, as we use it here)
        // Sub DemoTestBartlett()
        // '  p: # of variables in 1. set
        // '  n: # of cases-1 }      
        // Dim n As Int32, p As Int32, k As Int32
        // Dim LeftTail, RightTail, result2, resultM As Double
        // Dim LeftTail2, RightTail2 As Double
        // p = 3
        // k = 5
        // n = 15 ' n + 1 is sample size
        // LeftTail = 0.95
        // RightTail = 1 - LeftTail

        // result2 = TestBartlettDisX(LeftTail, RightTail, p, k, n)
        // Console.WriteLine("result2: {0}", result2)
        // resultM = -n * Math.Log(result2)
        // Console.WriteLine("resultM: {0}", resultM)

        // TestBartlettDis(p, k, n, result2, LeftTail2, RightTail2)
        // Console.WriteLine("LeftTail2: {0}", LeftTail2)

        // End Sub



        public static double GammaP(int p, double x)
        {
            double GammaPRet = default;
            const double pi = 3.14159265358979d;
            int i;
            double prod;
            double k;
            prod = 1d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
                // prod = prod * xpr.gamma(x - 0.5 * (i - 1))
                prod = prod * boost2.gamma(x - 0.5d * (i - 1));
            k = Math.Pow(pi, p * (p - 1) / 4d);
            GammaPRet = k * prod;
            return GammaPRet;
        }



        public static double LnGammaP(int p, double x)
        {
            const double pi = 3.14159265358979d;
            int i;
            double sum;
            double k;
            sum = 0d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
                sum = sum + DistMain.LnGamma(x - 0.5d * (i - 1));
            // K = Log(pi ^ (p * (p - 1) / 4))
            k = Math.Log(pi) * (p * (p - 1) / 4d);

            return k + sum;
        }


        public static void TestGammaP()
        {
            int p;
            double x;
            double Result;
            p = 1;
            x = 14d;
            Result = LnGammaP(p, x);
            Console.WriteLine("lnG", Math.Exp(Result));
        }



        public static double Hypergeometric2F1Matrix(int p, double a, double b, double c, double[] x)
        {
            double k;
            double[] y;
            double tau;
            double[] s;
            int i;
            int j;
            double prod;
            double R21;
            double Result;

            y = new double[p + 1];
            s = new double[p + 1];
            prod = 1d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                tau = x[i] * (b - a) - c;
                y[i] = 2d * a / (Math.Sqrt(tau * tau - 4d * a * x[i] * (c - b)) - tau);
                s[i] = x[i] * y[i] * (1d - y[i]) / (1d - x[i] * y[i]);
                prod = prod * (Math.Pow(y[i] / a, a) * Math.Pow((1d - y[i]) / (c - a), c - a) * Math.Pow(1d - x[i] * y[i], -b));
            }
            R21 = 1d;
            var loopTo1 = p;
            for (i = 1; i <= loopTo1; i++)
            {
                var loopTo2 = p;
                for (j = i; j <= loopTo2; j++)
                    R21 = R21 * (y[i] * y[j] / a + (1d - y[i]) * (1d - y[j]) / (c - a) - b * s[i] * s[j] / (a * (c - a)));
            }
            k = Math.Pow(c, p * c - p * (p + 1) / 4d);
            Result = k * prod / Math.Sqrt(R21);
            // Debug.Print k, p, x(p)

            return Result;
        }

        public static void TestHypergeometric2F1Matrix()
        {
            int p;
            double a;
            double b;
            double c;
            double[] x;
            double Result;
            p = 3;
            a = 3d;
            b = 2.5d;
            c = 1.5d;
            x = new double[p + 1];
            x[1] = 1.0d / 5.0d;
            x[2] = 2.0d / 5.0d;
            x[3] = 3.0d / 5.0d;
            Result = Hypergeometric2F1Matrix(p, a, b, c, x);
            Console.WriteLine("Result: {0}", Result);
        }



        public static double LnHypergeometric1F1Matrix(int p, double a, double b, double[] x)
        {
            //double k;
            double[] y;
            double tau;
            int i;
            int j;
            //double prod;
            double r11;
            double Result;
            var sum = default(double);
            double LogK;

            y = new double[p + 1];
            //double prod = 1d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                tau = b - x[i];
                y[i] = 2d * a / (tau + Math.Sqrt(tau * tau + 4d * a * x[i]));
                // Prod = Prod * (((y(i) / a) ^ a) * (((1 - y(i)) / (b - a)) ^ (b - a)) * Exp(x(i) * y(i)))
                sum = sum + (Math.Log(y[i] / a) * a + Math.Log((1d - y[i]) / (b - a)) * (b - a) + x[i] * y[i]);

            }
            r11 = 1d;
            var loopTo1 = p;
            for (i = 1; i <= loopTo1; i++)
            {
                var loopTo2 = p;
                for (j = i; j <= loopTo2; j++)
                    r11 = r11 * (y[i] * y[j] / a + (1d - y[i]) * (1d - y[j]) / (b - a));
            }
            // K = b ^ (p * b - p * (p + 1) / 4)

            LogK = Math.Log(b) * (p * b - p * (p + 1) / 4d);

            // Result = K * Prod / Sqr(R11)

            Result = LogK + sum - Math.Log(Math.Sqrt(r11));
            // Debug.Print K, p, x(p)

            return Result;
        }



        public static double Hypergeometric1F1Matrix(int p, double a, double b, double[] x)
        {
            double k;
            double[] y;
            double tau;
            int i;
            int j;
            double prod;
            double r11;
            double Result;
            var sum = default(double);
            double LogK;

            y = new double[p + 1];
            prod = 1d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                tau = b - x[i];
                y[i] = 2d * a / (tau + Math.Sqrt(tau * tau + 4d * a * x[i]));
                prod = prod * (Math.Pow(y[i] / a, a) * Math.Pow((1d - y[i]) / (b - a), b - a) * Math.Exp(x[i] * y[i]));
                sum = sum + (Math.Log(y[i] / a) * a + Math.Log((1d - y[i]) / (b - a)) * (b - a) + x[i] * y[i]);

            }
            r11 = 1d;
            var loopTo1 = p;
            for (i = 1; i <= loopTo1; i++)
            {
                var loopTo2 = p;
                for (j = i; j <= loopTo2; j++)
                    r11 = r11 * (y[i] * y[j] / a + (1d - y[i]) * (1d - y[j]) / (b - a));
            }
            k = Math.Pow(b, p * b - p * (p + 1) / 4d);

            LogK = Math.Log(b) * (p * b - p * (p + 1) / 4d);

            Result = k * prod / Math.Sqrt(r11);

            Result = Math.Exp(LogK + sum) / Math.Sqrt(r11);
            // Debug.Print K, p, x(p)

            return Result;
        }


        public static void TestHypergeometric1F1Matrix()
        {
            int p;
            double a;
            double b;
            double[] x;
            double Result;
            p = 2;
            a = 61d;
            b = 2d;
            x = new double[p + 1];
            x[1] = 1.34d;
            x[p] = 2.72d;
            Result = Hypergeometric1F1Matrix(p, a, b, x);
            Console.WriteLine("Result: {0}", Result);
        }




        public static double Hypergeometric0F1Matrix(int p, double n, double[] x)
        {
            double k;
            double[] y;
            double tau;
            int i;
            int j;
            double prod;
            double r11;
            double Result;

            y = new double[p + 1]; // : ReDim s(p)
            prod = 1d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                tau = 2d * x[i] / n;
                y[i] = tau / (1d + Math.Sqrt(tau * tau + 1d));
                prod = prod * (Math.Pow(1d - y[i], n / 2d) * Math.Exp(x[i] * y[i]));
            }
            r11 = 1d;
            var loopTo1 = p;
            for (i = 1; i <= loopTo1; i++)
            {
                var loopTo2 = p;
                for (j = i; j <= loopTo2; j++)
                    r11 = r11 * (1d - y[i] * y[j] * y[i] * y[j]);
            }
            k = 1d;
            Result = k * prod / Math.Sqrt(r11);
            // Debug.Print k, p, x(p)

            return Result;
        }


        public static void TestHypergeometric0F1Matrix()
        {
            int p;
            double n;
            double[] x;
            double Result;
            p = 2;
            n = 61d;
            x = new double[p + 1];
            x[1] = 1.34d;
            x[p] = 2.72d;
            Result = Hypergeometric0F1Matrix(p, n, x);
            Console.WriteLine("Result: {0}", Result);
        }






        public static void DemoGLMPower()
        {
            // p: # of variables in 1. set
            // q: # of variables in 2. set
            // n: # of cases-1 }      
            int p, q, n;
            double x, LeftTail, RightTail, Left1;

            p = 4;
            q = 6;
            n = 80 + q;
            LeftTail = 0.95d;
            RightTail = 1d - LeftTail;

            double[] Omega2 = new double[] { 0d, 0d, 0d, 0d, 0d };
            // Dim Omega() As Double = {0.0, 1.0, 1.0, 1.0}
            double[] Omega = new double[] { 0.0d, 11.0d, 1.0d, 1.0d };
            Omega[0] = 27d;

            Console.WriteLine("");
            Console.WriteLine("grdis");
            x = GRDisX(LeftTail, RightTail, p, q, n - q);
            Console.WriteLine("x: {0}", x);

            Left1 = GRDisN(false, "GLM", p, q, n - q, x, Omega2);
            Console.WriteLine("Null:: {0}", Left1);

            Left1 = GRDisN(false, "CORR", p, q, n - q, x, Omega);
            Console.WriteLine("CORR:: {0}", Left1);

            Left1 = GRDisN(false, "GLM", p, q, n - q, x, Omega);
            Console.WriteLine("GLM: : {0}", Left1);


            Console.WriteLine("");
            Console.WriteLine("udis");
            x = Udisx(LeftTail, RightTail, p, q, n - q);
            Console.WriteLine("x: {0}", x);

            Left1 = UdisN("GLM", p, q, n - q, x, Omega2);
            Console.WriteLine("Null:: {0}", Left1);

            Left1 = UdisN("CORR", p, q, n - q, x, Omega);
            Console.WriteLine("CORR:: {0}", Left1);

            Left1 = UdisN("GLM", p, q, n - q, x, Omega);
            Console.WriteLine("GLM: : {0}", Left1);


            Console.WriteLine("");
            Console.WriteLine("t2dis");
            x = DistPillaiHotelling.T2disX(LeftTail, RightTail, p, q, n - q);
            Console.WriteLine("x: {0}", x);

            Left1 = T2disN("GLM", p, q, n - q, x, Omega2);
            Console.WriteLine("Null:: {0}", Left1);

            Left1 = T2disN("CORR", p, q, n - q, x, Omega);
            Console.WriteLine("CORR:: {0}", Left1);

            Left1 = T2disN("GLM", p, q, n - q, x, Omega);
            Console.WriteLine("GLM: : {0}", Left1);

            Console.WriteLine("");
            Console.WriteLine("vdis");
            x = DistPillaiHotelling.VdisX(LeftTail, RightTail, p, q, n - q);
            Console.WriteLine("x: {0}", x);

            Left1 = VdisN("GLM", p, q, n - q, x, Omega2);
            Console.WriteLine("Null:: {0}", Left1);

            Left1 = VdisN("CORR", p, q, n - q, x, Omega);
            Console.WriteLine("CORR:: {0}", Left1);

            Left1 = VdisN("GLM", p, q, n - q, x, Omega);
            Console.WriteLine("GLM: : {0}", Left1);

        }




        public static void DemoUdisx()
        {
            // p: # of variables in 1. set
            // q: # of variables in 2. set
            // n: # of cases-1 }      
            int p, q, n;
            double LeftTail, RightTail, resultX, resultM;
            //double result2, Left1, Right1;

            // p = 14
            // q = 8
            // 'n = 125 + 7
            // n = 125

            p = 4;
            q = 7;
            // n = 125 + 7
            n = 100;

            LeftTail = 0.9d;
            RightTail = 1d - LeftTail;
            resultX = Udisx(LeftTail, RightTail, p, q - 1, n - q);
            Console.WriteLine("resultX: {0}", resultX);
            double resultL = -Math.Log(resultX);
            Console.WriteLine("resultL: {0}", resultL);

            resultM = -n * Math.Log(resultX);
            Console.WriteLine("resultM: {0}", resultM);




            // WilksExact2(p, q - 1, n - q, resultX, Left1, Right1)
            // Console.WriteLine("WilksExact2: {0}", Left1)

            // Dim resultWX = WilksExactX2(LeftTail, RightTail, p, q - 1, n - q)
            // Console.WriteLine("resultWX: {0}", resultWX)

            // 'Dim WilksdisLeft1 = Wilksdis(p, q, n - q, resultWX)
            // Dim WilksdisLeft1 = Wilksdis(p, q - 1, n - q, resultWX)
            // Console.WriteLine("WilksdisLeft1: {0}", WilksdisLeft1)



        }


        public static double Udisx(double LeftTail, double Righttail, double p, double q, double n)
        {
            double UdisxRet = default;
            // p: # of variables in 1. set
            // q: # of variables in 2. set
            // n: # of cases-1-q }
            double F;
            double m;
            double pq;
            double s;
            double l;
            if (n < p | LeftTail <= 0d | Righttail >= 1d)
            {
                UdisxRet = 0d;
                return UdisxRet;
            }
            pq = p * q;
            s = p * p + q * q - 5d;
            if (s != 0d)
                s = (pq * pq - 4d) / s;
            else
                s = 1d;
            if (s < 0d)
                s = 1d;
            else
                s = Math.Sqrt(s);
            m = s * (n - (p + 1d - q) / 2d) - (pq - 2d) / 2d;
            // F = fdisx(LeftTail, Righttail, pq, m)
            // F = xpr.dist_qf(LeftTail, pq, m, True)
            F = boost2.dist_fisher_f(LeftTail, pq, m, 6d);
            l = 1.0d / (1d + pq * F / m);
            UdisxRet = Math.Exp(s * Math.Log(l));
            return UdisxRet;
        }



        public static double Wilksdis(double p, double q, double n, double l1)
        {
            double WilksdisRet = default;
            double LeftTail;
            //double Righttail;
            var l2 = default(double);
            var r2 = default(double);
            // { p: # of variables in 1. set
            // q: # of variables in 2. set
            // n: # of cases-1 }
            double F;
            double m;
            double pq;
            double s;
            double l;
            if (n < p | l1 < 0d)
            {
                LeftTail = 0d;
                //Righttail = 1d;
                WilksdisRet = LeftTail;
                return WilksdisRet;
            }
            if (l1 >= 1d)
            {
                LeftTail = 1d;
                //Righttail = 0d;
                WilksdisRet = LeftTail;
                return WilksdisRet;
            }
            pq = p * q;
            s = p * p + q * q - 5d;
            if (s != 0d)
                s = (pq * pq - 4d) / s;
            else
                s = 1d;
            if (s < 0d)
                s = 1d;
            else
                s = Math.Sqrt(s);
            // printout('S2: ' + StrN(S*S,12,8))
            l = Math.Exp(Math.Log(l1) / s);
            m = s * (n - (p + 1d - q) / 2d) - (pq - 2d) / 2d;
            F = m * (1d - l) / (pq * l);
            DistN.Fdisn2(pq, m, F, 0d, ref l2, ref r2);
            Console.WriteLine("l2: {0}, r2: {1}", l2, r2);
            return l2;

        }



        public static void Kulp2(bool IsRho, int p, double f2, double f1, double lambda, double[] sigma, double LeftTail, double Righttail)
        {
            var Beta = new double[4];
            double g1;
            double g2;
            double g3;
            double u;
            double delta;
            double m1;
            double v;
            double a;
            double s2;
            double s;
            double d1;
            double sum;
            double sum1;
            double sig1;
            double sig12;
            double sig2;
            double l;
            double r2;
            int i;
            sig1 = 0d;
            sig2 = 0d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                sig1 = sig1 + sigma[i];
                sig2 = sig2 + Math.Sqrt(sigma[i]);
            }
            sig1 = sig1 / 2d;
            sig2 = sig2 / 4d;
            sig12 = Math.Sqrt(sig1);
            delta = (p - f2 + 1d) / 4d;
            m1 = (f1 - 2d * delta) / 2d;
            v = p * f2 / 2d;
            a = (1d - v) / 2d;
            if (p * f2 <= 2d)
                s2 = 1d;
            else
                s2 = (Math.Sqrt(p * f2) - 4d) / (p * p + f2 * f2 - 5d);
            s = Math.Sqrt(s2);
            u = Math.Exp(Math.Log(lambda) / s);
            d1 = 2d * delta + f2;
            //d1 = d1;
            g1 = sig1 * (d1 - (v + 1d) / s) / 2d;
            g2 = (-sig1 * (d1 - (v + 1d) / s) + sig2 - sig12 / s) / 2d;
            g3 = -(sig2 - sig12 / s) / 2d;
            l = 2d * sig1;
            for (i = 0; i <= 3; i++)
            {
                // {    BetaDisN(v+i,m1*s+a,1-u,u,l,LeftTail,RightTail)}
                r2 = l / (2d * (m1 * s + a) + l);
                DistN.R2DisN(IsRho, 2d * (v + i), 2d * (m1 * s + a), 1d - u, r2, ref LeftTail, ref Righttail);
                Beta[i] = LeftTail;
            }
            sum = Beta[0];
            sum1 = 0d;
            Console.WriteLine("sum0: {0}", sum);
            if (sig1 >= 0d)
            {
                sum1 = 1d / m1 * (g1 * Beta[1] + g2 * Beta[2] + g3 * Beta[3]);
                if (IsRho)
                    sum1 = 2.5d * sum1;
                Console.WriteLine("sum1: {0}", sum1);
            }
            LeftTail = sum + sum1;
            Righttail = 1d - LeftTail;
        }



        public static void Fangdis(int pp, int qq, double n, double l1, ref double LeftTail, ref double Righttail)
        {
            // { p as  # of variables in 1. set
            // q as  # of variables in 2. set
            // n as  # of cases-1 }
            double v;
            double delta;
            double s2;
            double Ar2;
            double sum1;
            double sum2;
            int d;
            int b;
            int i;
            int j;
            var p = new int[11];

            if (n < pp | l1 <= 0d)
            {
                LeftTail = 0d;
                Righttail = 1d;
                return;
            }
            if (l1 >= 1d)
            {
                LeftTail = 1d;
                Righttail = 0d;
                return;
            }
            d = 2;
            p[1] = pp;
            p[2] = qq;

            // p(1) = Int(pp + 0.5)
            // p(2) = Int(qq + 0.5)

            b = 0;
            v = 0d;
            var loopTo = d;
            for (i = 1; i <= loopTo; i++)
                b = b + p[i];
            var loopTo1 = d;
            for (i = 1; i <= loopTo1; i++)
                v = v + p[i] * (p[i] + 1);
            v = 0.5d * (b * (b + 1) - v);
            delta = 0d;
            var loopTo2 = d;
            for (i = 1; i <= loopTo2; i++)
                delta = delta + p[i] * (p[i] + 1) * (2 * p[i] + 1);
            delta = (-delta - 6d * v + b * (b + 1) * (2 * b + 1)) / (12d * v);
            // m=n-delta
            // a=(1-v)/2
            // Calc Ar
            sum1 = 0d;
            sum2 = 0d;
            var loopTo3 = d;
            for (i = 1; i <= loopTo3; i++)
            {
                var loopTo4 = p[i];
                for (j = 1; j <= loopTo4; j++)
                    sum1 = sum1 + DistBoxDavis.B3(delta - j + 1d);
            }
            var loopTo5 = b;
            for (i = 1; i <= loopTo5; i++)
                sum2 = sum2 + DistBoxDavis.B3(delta - i + 1d);
            Ar2 = -(sum1 - sum2) / (2 * 3);
            if (Ar2 == 0d)
                s2 = 1d;
            else
                s2 = v * (1d - v * v) / (24d * Ar2);
            Console.WriteLine("S2: {0}", s2);
        }



        public static void WilksExact(int p, int f1, double f2, double l, ref double LeftTail, ref double Righttail)
        {
            int i;
            double[] b;
            double[] c;
            b = new double[p + 1];
            c = new double[p + 1];
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                b[i] = (f2 - i + 1d) / 2d;
                c[i] = b[i] + f1 / 2d;
                Console.WriteLine("i: {0}, b(i): {1}, c(i): {2}", i, b[i], c[i]);
            }
            BetaProdDis(p, b, c, l, ref LeftTail, ref Righttail);
        }


        // {Algorithm for sigma by Tang, 1984}
        public static void CalcSigma2(int r, ref double[] HH, ref double[,] sigma, int p, ref double[] F, ref double[] m)
        {
            double sum;
            double d;
            int k;
            int s;
            if (r > 0)
                sigma[1, r] = 0d;
            var loopTo = p;
            for (k = 2; k <= loopTo; k++)
            {
                sum = 0d;
                d = 1d;
                var loopTo1 = r;
                for (s = 0; s <= loopTo1; s++)
                {
                    sum = sum + d * sigma[k - 1, r - s];
                    d = d * (m[k] + s) / (s + 1);
                }
                sigma[k, r] = HH[k] * sum;
            }
            var loopTo2 = p;
            for (k = 2; k <= loopTo2; k++)
                HH[k] = HH[k] * (F[k - 1] + r) / (F[k] + r);
        } // (*CalcSigma*)


        // {Exact cdf, algorithm using beta, by Tang, 1984}
        public static void BetaProdDis(int p, double[] b, double[] c, double x, ref double LeftTail, ref double Righttail)
        {

            int i;
            int j;
            double[] HH;
            double[] F;
            double[] m;      // r3feld
            double KBetaStart;
            double KBeta;
            double k;
            double sum;
            double summand;
            double RelError;
            double f1;
            double f2;
            double FAX;
            var density = default(double);
            double ax;
            double FIBeta;
            double[,] sigma;  // SFeld

            F = new double[p + 1];
            m = new double[p + 1];
            HH = new double[p + 1];

            sigma = new double[p + 1, 6001];
            // For i = 1 To p
            // New(sigma(i))
            // End
            k = 0d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                k = k + DistMain.LnGamma(c[i]);
                k = k - DistMain.LnGamma(b[i]);
            }
            k = Math.Exp(k);
            F[1] = c[1] - b[1];
            m[1] = 0d;
            var loopTo1 = p;
            for (i = 2; i <= loopTo1; i++)
            {
                F[i] = F[i - 1] + c[i] - b[i];
                m[i] = c[i] - b[i - 1];
            }
            sigma[1, 0] = 1.0d / Math.Exp(DistMain.LnGamma(F[1]));
            var loopTo2 = p;
            for (i = 2; i <= loopTo2; i++)
                HH[i] = Math.Exp(DistMain.LnGamma(F[i - 1]) - DistMain.LnGamma(F[i]));
            f1 = b[p];
            f2 = F[p];
            sum = 0d;
            j = 0;
            RelError = 1d;
            KBetaStart = Math.Exp(DistMain.Lnbeta(f1, f2));
            KBeta = 1d;
            DistMain.betadis(f1, f2, x, 1d - x, ref LeftTail, ref Righttail, ref density);
            FIBeta = Math.Exp(DistMain.LnGamma(f1 + f2) - DistMain.LnGamma(f2 + 1d) - DistMain.LnGamma(f1));
            ax = Math.Exp(f1 * Math.Log(x) + f2 * Math.Log(1d - x));
            FAX = FIBeta * ax;
            while (j <= jmax & RelError >= 0.0000000000000001d)
            {
                CalcSigma2(j, ref HH, ref sigma, p, ref F, ref m);
                // {Betadis(f1,f2+j,x,1-x,Left,RightTail)}
                summand = KBeta * LeftTail * Math.Pow(sigma[p, j], j);    // need to check sigma (j, j) indices!!!!
                sum = sum + summand;
                RelError = summand / sum;

                Console.WriteLine("j: {0},  RelError: {1}", j, RelError);
                LeftTail = LeftTail + FAX;
                FAX = FAX * (1d - x) * (f1 + f2 + j) / (f2 + j + 1d);
                KBeta = KBeta * (f2 + j) / (f1 + f2 + j);
                j = j + 1;
            }
            // For i = 1 To p
            // dispose (sigma(i))
            // End
            Righttail = KBetaStart * sum * k;
            LeftTail = 1d - Righttail;
        }





        // {Exact cdf, algorithm using chi2, by Tang}
        public static void BetaProdDis5(bool first, bool odd_f1, int p, double[] b, double[] c, double x, double LeftTail, double Righttail)
        {
            const int Rmax = 100;
            //const int pmax = 10;

            int j1;
            int k;
            int r;
            int i;
            int j;
            double sum;
            double cc;
            double nu;
            double[] q;
            double[] l;
            double ar;
            double RelError;
            var density = default(double);
            double faktor;
            var LeftTail2 = default(double);
            var RightTail2 = default(double);
            double sign;
            double a;
            double m2;
            double sum2;
            double summand2;
            int[] d;
            double[,] sb;
            double[] bb;
            bool UseBernoulli;
            bool UseFullChi2;
            bool UseLnGamma;
            double Kp;
            q = new double[101];
            l = new double[101];
            d = new int[11];
            sb = new double[11, 10001];
            bb = new double[11];
            Kp = 1d;
            UseBernoulli = false;
            UseFullChi2 = false;
            UseLnGamma = false;
            x = -Math.Log(x);
            cc = 0d;
            nu = 0d;
            m2 = 0d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                nu = nu + c[i] - b[i];
                m2 = m2 + Math.Pow(c[i], 2d) - Math.Pow(b[i], 2d);
            }
            a = 0.5d * (m2 / nu - 1d);

            if (!UseBernoulli)
            {
                var loopTo1 = p;
                for (j = 1; j <= loopTo1; j++)
                {
                    if (odd_f1)
                    {
                        if (j % 2 != 0)
                            j1 = j + 1;
                        else
                            j1 = j - 1;
                    }
                    else
                    {
                        j1 = j;
                    }
                    bb[j] = b[j1] - a;

                    double temp = Conversion.Int(c[j] - b[j1] + 0.5d);
                    d[j] = Convert.ToInt32(temp);

                    // d(j) = Int(c(j) - b(j1) + 0.5)

                    // new(sb(j))
                    var loopTo2 = d[j];
                    for (k = 0; k <= loopTo2; k++)
                        sb[j, k] = 1d;
                }
            }

            if (UseLnGamma)
            {
                var loopTo3 = p;
                for (i = 1; i <= loopTo3; i++)
                {
                    cc = cc + DistMain.LnGamma(c[i]);
                    cc = cc - DistMain.LnGamma(b[i]);
                }
                faktor = Math.Exp(cc - Math.Log(a) * nu);
            }
            else
            {
                if (!first)
                {
                    Kp = Kp * (c[1] - 1d);
                }
                else
                {
                    Kp = 1d;
                    var loopTo4 = p;
                    for (j = 1; j <= loopTo4; j++)
                    {
                        var loopTo5 = d[j] - 1;
                        for (k = 0; k <= loopTo5; k++)
                            Kp = Kp * (bb[j] + k + a);
                    }
                }
                faktor = Kp * Math.Exp(-Math.Log(a) * nu);
            }

            DistMain.cdis2(2d * nu, 2d * a * x, ref LeftTail2, ref RightTail2, ref density);
            sum2 = LeftTail2;
            RelError = 1d;
            r = 1;
            ar = 1d;
            l[0] = 1d;


            while ((RelError > 0.0000000000000001d | (r + 1) % 2 != 0 | r < 10) & r < Rmax)
            {
                if (UseFullChi2)
                {
                    DistMain.cdis2(2d * (nu + r), 2d * a * x, ref LeftTail2, ref RightTail2, ref density);
                }
                else
                {
                    density = density * (2d * a * x) / (2d * (nu + r - 1d));
                    LeftTail2 = LeftTail2 - 2d * density;
                }
                ar = ar / a;
                if ((r + 1) % 2 != 0)
                    sign = -1;
                else
                    sign = 1d;
                if (UseBernoulli)
                {
                    sum = 0d;
                    var loopTo6 = p;
                    for (j = 1; j <= loopTo6; j++)
                        sum = sum + DistMain.Bernoulli(r + 1, b[j] - a) - DistMain.Bernoulli(r + 1, c[j] - a);
                    q[r] = sign * sum / (r * (r + 1));
                }
                else
                {
                    sum = 0d;
                    var loopTo7 = p;
                    for (j = 1; j <= loopTo7; j++)
                    {
                        var loopTo8 = d[j] - 1;
                        for (k = 0; k <= loopTo8; k++)
                        {
                            sb[j, k] = sb[j, k] * (bb[j] + k);
                            sum = sum + sb[j, k];
                        }
                    }
                    q[r] = -sign * sum / r;
                }
                sum = 0d;
                var loopTo9 = r;
                for (k = 1; k <= loopTo9; k++)
                    sum = sum + k * q[k] * l[r - k];
                l[r] = sum / r;
                summand2 = LeftTail2 * l[r] * ar;
                sum2 = sum2 + summand2;
                RelError = summand2 / sum2;
                Console.WriteLine("r: {0}, LeftTail2: {1}, q(r) * ar: {2}, RelError: {3}, ", r, LeftTail2, q[r] * ar, RelError);
                r = r + 1;
            }
            LeftTail = faktor * sum2;
            Righttail = 1d - LeftTail;
        }


        public static void WilksExactN2(bool IsRho, int p, int f1, double f2, double l, double lambda, double LeftTail, double Righttail)
        {
            int k;
            int i;
            double[] b;
            double[] c;
            double summand;
            double RelError;
            double sum;
            double Factor;
            double ck;
            double n2;
            double Rho2;
            bool IsOdd_f1;
            const double pi = 3.14159265358979d;

            b = new double[p + 1 + 1];
            c = new double[p + 1 + 1];
            if (p > f1)
            {
                Console.WriteLine("WilksExact: p must be <= f1");
                return;
            }
            if (l <= Math.Exp(-2 * pi))
            {
                Console.WriteLine("WilksExact: L must be > exp(-2*pi)");
                return;
            }
            IsOdd_f1 = f1 % 2 != 0;
            lambda = lambda / 2d;
            Rho2 = 2d * lambda / (2d * lambda + f2);
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                b[i] = (f2 - i + 1d) / 2d;
                c[i] = b[i] + f1 / 2d;
            }
            ck = c[1];
            n2 = c[1];
            // {  BetaProdDis2(p,b,c,L,LeftTail,RightTail)}
            BetaProdDis5(true, IsOdd_f1, p, b, c, l, LeftTail, Righttail);
            sum = LeftTail;
            if (lambda > 0d)
                RelError = 1d;
            else
                RelError = 0d;
            k = 0;
            Factor = 1d;
            while (RelError > 0.0000000000000001d)
            {
                k = k + 1;
                c[1] = ck + k;
                if (IsRho)
                {
                    Factor = Factor * (n2 + k - 1d) * Rho2 / k;
                }
                else
                {
                    Factor = Factor * lambda / k;
                }
                // {    BetaProdDis2(p,b,c,L,LeftTail,RightTail)}
                BetaProdDis5(false, IsOdd_f1, p, b, c, l, LeftTail, Righttail);
                summand = LeftTail * Factor;
                sum = sum + summand;
                if (sum != 0d)
                    RelError = summand / sum;
                Console.WriteLine("k: {0}, sum: {1}, RelError: {2}, ", k, sum, RelError);
            }

            Console.WriteLine("Wilks Lambda, exact: {0} terms were used", k);
            if (IsRho)
            {
                LeftTail = Math.Exp(Math.Log(1d - Rho2) * n2) * sum;
            }
            else
            {
                LeftTail = Math.Exp(-lambda) * sum;
            }
            Righttail = 1d - LeftTail;
        }







        public static double R2DisX0(double LeftTail, double Righttail, double a, double b)
        {
            double R2DisX0Ret = default;
            double x;
            double y;
            double w;
            w = DistX.fdisx(LeftTail, Righttail, a, b);
            x = a * w / (a * w + b);
            y = b / (a * w + b);
            R2DisX0Ret = x;
            return R2DisX0Ret;
        }



        public static double GRDisX(double LeftTail, double Righttail, int p, double m, double n)
        {
            double GRDisXRet = default;
            double x; // , y As Double
            LeftTail = Math.Exp(Math.Log(LeftTail) / p);
            Righttail = 1d - LeftTail;
            x = R2DisX0(LeftTail, Righttail, m, n);
            GRDisXRet = x;
            return GRDisXRet;
        }




        // Roy's Greatest Root
        // Noncentral distribution function
        public static double GRDisN(bool IsRho, string Model, int p, double m, double n, double x, double[] omega)
        {
            double GRDisNRet = default;
            double result;
            double Left1;
            double rho;
            int i;
            bool IsGLM;
            var LeftTail = default(double);
            var Righttail = default(double);
            result = 1d;
            if (Model == "GLM")
                IsGLM = true;
            else
                IsGLM = false;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                // If IsRho Then rho = omega(i) Else rho = omega(i) / (n + omega(i))
                if (IsRho)
                    rho = omega[i - 1];
                else
                    rho = omega[i - 1] / (n + omega[i - 1]);
                DistN.R2DisN(IsGLM, m, n, x, rho, ref LeftTail, ref Righttail);
                Left1 = LeftTail;
                result = result * Left1;
            }
            GRDisNRet = result;
            return GRDisNRet;
        }

        // Wilk's U
        // Noncentral distribution function
        public static double UdisN(string Model, int p, double q, double n, double x, double[] omega)
        {
            double UdisNRet = default;
            var LeftTail = default(double);
            var Righttail = default(double); // , i As Integer
            bool IsRho;
            // Dim omega1(0 To 100) As Double
            IsRho = false;
            // For i = 1 To p
            // omega1(i) = omega(i)
            // Next i
            UT2VGRdisN(1, IsRho, Model, p, q, n, x, ref LeftTail, ref Righttail, omega);
            UdisNRet = LeftTail;
            return UdisNRet;
        }

        // Hotelling's T²
        // Noncentral distribution function
        public static double T2disN(string Model, int p, double q, double n, double x, double[] omega)
        {
            double T2disNRet = default;
            var LeftTail = default(double);
            var Righttail = default(double); // , i As Integer
            bool IsRho;
            // Dim omega1(0 To 100) As Double
            IsRho = false;
            // For i = 1 To p
            // omega1(i) = omega(i)
            // Next i
            UT2VGRdisN(2, IsRho, Model, p, q, n, x, ref LeftTail, ref Righttail, omega);
            T2disNRet = LeftTail;
            return T2disNRet;
        }

        // Pillai 's V
        // Noncentral distribution function
        public static double VdisN(string Model, int p, double q, double n, double x, double[] omega)
        {
            double VdisNRet = default;
            var LeftTail = default(double);
            var Righttail = default(double); // , i As Integer
            bool IsRho;
            // Dim omega1(0 To 100) As Double
            IsRho = false;
            // For i = 1 To p
            // omega1(i) = omega(i)
            // Next i
            UT2VGRdisN(3, IsRho, Model, p, q, n, x, ref LeftTail, ref Righttail, omega);
            VdisNRet = LeftTail;
            return VdisNRet;
        }


        public static void UT2VGRdisN(int dis, bool IsRho, string Model, int p, double q, double n, double x, ref double LeftTail, ref double Righttail, double[] omega)
        {
            var a = new double[5];
            var b = new double[9];
            var c = new double[10];
            var left = new double[10];
            var Right = new double[10];
            double o1;
            double o2;
            double o3;
            double o4;
            double f2;
            double F;
            double sum0;
            double sum1;
            double sum2;
            double sum3;
            double o12;
            double o13;
            double o22;
            double o23;
            int i;
            double g3;
            double G;
            double g2;
            double L0;
            double l1;
            double l2;
            double l3;
            double l4;
            double m;
            double omeg;
            double q2;
            double p2;
            double r;
            var l = default(double);
            double s;
            double S1;
            double s2;
            double s3;
            double s12;
            double p2p;
            double H1;
            double h;
            double q3;
            double p3;
            double p4;
            double q4;
            double p1;
            double s22;
            bool show;
            string OutStr;
            var x0 = new double[11];
            var t0 = new double[11];

            show = false;
            if (dis == 1)
            {
                l = (q - p - 1d) / 2d;
                m = n + l;
                x = -m * Math.Log(x);
            }
            else
            {
                if (dis == 2)
                {
                    if (Model == "GLM")
                    {
                        m = n - p - 1d;
                    }
                    else
                    {
                        m = n;
                    }
                }
                else
                {
                    m = n + q;
                }
                x = x * m;
            }

            o1 = 0d;
            o2 = 0d;
            o3 = 0d;
            o4 = 0d;
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                // omeg = omega(i)
                omeg = omega[i - 1];
                // {if the nc parameter is given as canonical correlation}
                if (IsRho)
                    omeg = n * omeg / (1d - omeg);
                if (!(Model == "GLM") & dis == 3)
                    omeg = n * omeg / (n - q + omeg);
                o1 = o1 + omeg;
                o2 = o2 + Math.Pow(omeg, 2d);
                o3 = o3 + omeg * Math.Pow(omeg, 2d);
                o4 = o4 + Math.Pow(omeg, 4d);
                // Console.WriteLine("omeg: {0}", omeg)
            }
            // Console.WriteLine("o1: {0}", o1)
            o1 = o1 / 2d;
            o2 = o2 / 4d;
            o3 = o3 / 8d;
            o4 = o4 / 16d;
            o12 = Math.Pow(o1, 2d);
            o13 = o1 * o12;
            o22 = Math.Pow(o2, 2d);
            o23 = o2 * o22;

            F = p * q;
            f2 = F * F;
            p2 = p * p;
            q2 = q * q;
            G = p + q + 1d;
            g2 = G * G;
            g3 = g2 * G;
            s = (p + q + 1d) / 4d;
            s2 = s * s;
            s3 = s * s2;
            r = F * (p2 + q2 - 5d) / 48d;

            // Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
            L0 = (3d * F - 8d) * g2 + 4d * G + 4d * (F + 2d);
            l1 = -12 * F * g2;
            l2 = 6d * (3d * F + 8d) * g2;
            l3 = -4 * ((3d * F + 16d) * g2 + 4d * G + 4d * (F + 2d));
            l4 = 3d * ((F + 8d) * g2 + 4d * G + 4d * (F + 2d));

            switch (dis)
            {
                case 1:
                    {
                        if (show)
                            Console.WriteLine("Udis");
                        // Fujikoshi (1973), Ann. Inst. Math. Statist., 25, p. 423
                        if (Model == "GLM")
                        {
                            if (show)
                                Console.WriteLine("GLM");
                            a[0] = 0d;
                            a[1] = 2d * s * o1;
                            a[2] = -(2d * s * o1 - o2);
                            a[3] = -o2;
                            a[4] = 0d;

                            b[0] = -r;
                            b[1] = 0d;
                            b[2] = r - 4d * s2 * o1 + 2d * s2 * o12 + 2d * s * o2;
                            b[3] = 4d * s2 * o1 - (1d + 4d * s2) * o12 - (1d + 8d * s) * o2 + 2d * s * o1 * o2 + 4d / 3d * o3;
                            b[4] = (1d + 2d * s2) * o12 + (1d + 6d * s) * o2 - 4d * s * o1 * o2 - 4d * o3 + o22 / 2d;
                            b[5] = 2d * s * o1 * o2 + 8d / 3d * o3 - o22;
                            b[6] = o22 / 2d;
                            b[7] = 0d;
                            b[8] = 0d;

                            c[0] = 0d;
                            c[1] = 2d * r * s * o1;
                            c[2] = -r * (2d * s * o1 - o2);
                            c[3] = -2 * s * (r + 4d * s2) * o1 + 2d * s * (1d + 4d * s2) * o12 + (-r + 2d * s + 12d * s2) * o2 - 4d / 3d * s3 * o13 - 4d * s2 * o1 * o2 - 8d / 3d * s * o3;
                            c[4] = 2d * s * (r + 4d * s2) * o1 - (1d + 10d * s + 16d * s3) * o12 - (3d + r + 10d * s + 36d * s2) * o2 + 2d * s * (1d + 2d * s2) * o13 + 2d * (2d + s + 12d * s2) * o1 * o2 + 4d * (1d + 6d * s) * o3 - 2d * s2 * o12 * o2 - 2d * s * o22 - 8d / 3d * s * o1 * o3 - 2d * o4;

                            c[5] = (1d + 8d * s + 8d * s3) * o12 + (3d + r + 8d * s + 24d * s2) * o2 - 4d * s * (1d + s2) * o13 - 4d * (3d + s + 9d * s2) * o1 * o2 - 12d * (1d + 4d * s) * o3 + (1d + 6d * s2) * o12 * o2 + (1d + 10d * s) * o22 + 32d / 3d * s * o1 * o3 + 12d * o4 - 4d / 3d * o2 * o3 - s * o1 * o22;
                            c[6] = s * (2d + 4d / 3d * s2) * o13 + 2d * (4d + s + 8d * s2) * o1 * o2 + 8d * (1d + 10d / 3d * s) * o3 - 2d * (1d + 3d * s2) * o12 * o2 - 2d * (1d + 7d * s) * o22 - 40d / 3d * s * o1 * o3 - 20d * o4 + 16d / 3d * o2 * o3 + 3d * s * o1 * o22 - 1d / 6d * o23;
                            c[7] = (1d + 2d * s2) * o12 * o2 + (1d + 6d * s) * o22 + 16d / 3d * s * o1 * o3 + 10d * o4 - 20d / 3d * o2 * o3 - 3d * s * o1 * o22 + 1d / 2d * o23;
                            c[8] = 8d / 3d * o2 * o3 + s * o1 * o22 - 1d / 2d * o23;
                            c[9] = 1d / 6d * o23;
                        }

                        else
                        {
                            if (show)
                                Console.WriteLine("CORR");
                            a[0] = -q * o1 + o2;
                            a[1] = (2d * s + q) * o1 - 2d * o2;
                            a[2] = -2 * s * o1 + 2d * o2;
                            a[3] = -o2;
                            a[4] = 0d;

                            b[0] = -r - q * l * o1 + (q + l) * o2 + 0.5d * q * q * o12 - 4d * o3 / 3d - q * o1 * o2 + 0.5d * o22;
                            b[1] = q2 * o1 - 4d * q * o2 - q * (q + 2d * s) * o12 + 4d * o3 + (3d * q + 2d * s) * o1 * o2 - 2d * o22;
                            b[2] = r - 2d * s * (q + 2d * s) * o1 + (2 * p + 6d * q + 3d) * o2 + (0.5d * l * l + 6d * q * s + 1d) * o12 - 8d * o3 - (4d * q + 6d * s) * o1 * o2 + 4d * o22;
                            b[3] = 4d * s2 * o1 - (3 * p + 5d * q + 5d) * o2 - (4d * s2 + 2d * q * s + 2d) * o12 + 32d * o3 / 3d + (3d * q + 8d * s) * o1 * o2 - 5d * o22;
                            b[4] = (6d * s + 1d) * o2 + (2d * s2 + 1d) * o12 - 8d * o3 - (q + 6d * s) * o1 * o2 + 4d * o22;
                            b[5] = 8d * o3 / 3d + 2d * s * o1 * o2 - 2d * o22;
                            b[6] = 0.5d * o22;
                            b[7] = 0d;
                            b[8] = 0d;

                            for (i = 0; i <= 9; i++)
                                c[i] = 0d;
                        }

                        break;
                    }

                case 2:
                    {
                        if (show)
                            Console.WriteLine("T2dis");
                        // Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
                        if (Model == "GLM")
                        {
                            if (show)
                                Console.WriteLine("GLM");
                            a[0] = F * G;
                            a[1] = -2 * G * (F - 2d * o1);
                            a[2] = F * G - 8d * G * o1 + 4d * o2;
                            a[3] = 4d * (G * o1 - 2d * o2);
                            a[4] = 4d * o2;

                            b[0] = F * L0;
                            b[1] = l1 * (F - 2d * o1);
                            b[2] = F * l2 + 2d * (l1 - 2d * l2) * o1 + 48d * g2 * o12 + 24d * (F + 4d) * G * o2;
                            b[3] = F * l3 + 2d * (2d * l2 - 3d * l3) * o1 - 192d * (g2 + 1d) * o12 - 96d * ((F + 8d) * G + 2d) * o2 + 96d * G * o1 * o2 + 128d * o3;
                            b[4] = F * l4 + 2d * (3d * l3 - 4d * l4) * o1 + 96d * (3d * g2 + 7d) * o12 + 48d * (3d * (F + 12d) * G + 14d) * o2 - 384d * G * o1 * o2 - 768d * o3 + 48d * o22;
                            b[5] = 8d * l4 * o1 - 192d * (g2 + 4d) * o12 - 96d * ((F + 16d) * G + 8d) * o2 + 576d * G * o1 * o2 + 1536d * o3 - 192d * o22;
                            b[6] = 48d * (g2 + 6d) * o12 + 24d * ((F + 20d) * G + 12d) * o2 - 384d * G * o1 * o2 - 1280d * o3 + 288d * o22;
                            b[7] = 96d * G * o1 * o2 + 384d * o3 - 192d * o22;
                            b[8] = 48d * o22;
                        }

                        else
                        {
                            if (show)
                                Console.WriteLine("CORR");
                            S1 = o1 * 2d;
                            s2 = o2 * 4d;
                            s3 = o3 * 8d;
                            s12 = S1 * S1;
                            s22 = s2 * s2;
                            p1 = p + 1;
                            p3 = p2 * p;
                            p4 = p3 * p;
                            q3 = q2 * q;
                            q4 = q3 * q;
                            h = q * p1;
                            H1 = 2d * q + p1;
                            p2p = p2 + p;

                            a[0] = q * p * (q - p - 1d) - 2d * q * S1 + s2;
                            a[1] = -2 * q2 * p + 4d * q * S1 - 2d * s2;
                            a[2] = q * p * (q + p + 1d) - 2d * (2d * q + p + 1d) * S1 + 2d * s2;
                            a[3] = 2d * (q + p + 1d) * S1 - 2d * s2;
                            a[4] = s2;
                            b[0] = q * p * (3d * q * p3 - 2d * (3d * q2 - 3d * q + 4d) * p2 + 3d * (q3 - 2d * q2 + 5d * q - 4d) * p - 8d * q2 + 12d * q + 4d) - 12d * q2 * p * (q - p - 1d) * S1 - 6d * q * (p2 - q * p + p - 4d) * s2 + 12d * q2 * s12 - 16d * s3 - 12d * q * S1 * s2 + 3d * s22;


                            b[1] = -12 * q3 * p2 * (q - p - 1d) - 24d * q2 * (p2 - 2d * q * p + p - 2d) * S1 + 12d * q * (p2 - 2d * q * p + p - 8d) * s2 - 48d * q2 * s12 + 48d * s3 + 48d * q * S1 * s2 - 12d * s22;

                            b[2] = -6 * q2 * p4 - 12d * q2 * p3 + 18d * q2 * (q2 + 1d) * p2 + 24d * q2 * (2d * q + 1d) * p + 12d * q * (p3 + 2d * p2 - 7d * (q2 + 1d) * p - 16d * q - 8d) * S1 - 6d * (q * p2 - (7d * q2 - q + 8d) * p - 40d * q - 12d) * s2 + 24d * (q * p + 4d * q2 + q + 1d) * s12 - 12d * (p + 8d * q + 1d) * S1 * s2 - 96d * s3 + 24d * s22;

                            b[3] = -(12d * q3 + 16d * q) * p3 - (12d * q4 + 12d * q3 + 96d * q2 + 48d * q) * p2 - (64d * q3 + 96d * q2 + 64d * q) * p + 12d * (-q * p3 + (4d * q2 - 2d * q + 4d) * p2 + (7d * q3 + 4d * q2 + 31d * q + 12d) * p + 4d * (7d * q2 + 8d * q + 4d)) * S1 - 48d * ((q2 + 3d) * p + 9d * q + 5d) * s2 - 24d * (3d * q * p + 5d * q2 + 3d * q + 4d) * s12 + 176d * s3 + 12d * (3 * p + 11d * q + 3d) * S1 * s2 - 36d * s22;



                            b[4] = 3d * q2 * p4 + (6d * q3 + 6d * q2 + 24d * q) * p3 + (3d * q4 + 6d * q3 + 63d * q2 + 60d * q) * p2 + (24d * q3 + 60d * q2 + 60d * q) * p - 12d * (q * p3 + (5d * q2 + 2d * q + 12d) * p2 + (4d * q3 + 5d * q2 + 45d * q + 32d) * p + 4d * (6d * q2 + 11d * q + 9d)) * S1 + 6d * (q * p2 + (7d * q2 + q + 44d) * p + 88d * q + 76d) * s2 + 12d * (p2 + 2d * (4d * q + 1d) * p + 8d * q2 + 8d * q + 17d) * s12 - 12d * (4 * p + 11d * q + 4d) * S1 * s2 - 240d * s3 + 42d * s22;




                            b[5] = (12d * q * p3 + 24d * (q2 + q + 4d) * p2 + 12d * (q3 + 2d * q2 + 21d * q + 20d) * p + 48d * (2d * q2 + 5d * q + 5d)) * S1 - 12d * (q * p2 + (2d * q2 + q + 24d) * p + 32d * q + 40d) * s2 - 24d * (p2 + (3d * q + 2d) * p + 2d * q2 + 3d * q + 9d) * s12 + 240d * s3 + 48d * (p + 2d * q + 1d) * S1 * s2 - 36d * s22;


                            b[6] = (6d * q * p2 + 6d * (q2 + q + 20d) * p + 120d * q + 192d) * s2 + (12d * p2 + 24d * (q + 1d) * p + 12d * (q2 + 2d * q + 7d)) * s12 - 12d * (3 * p + 4d * q + 3d) * S1 * s2 - 160d * s3 + 24d * s22;

                            b[7] = 48d * s3 + 12d * (q + p + 1d) * S1 * s2 - 12d * s22;
                            b[8] = 3d * s22;
                        }

                        break;
                    }

                case 3:
                    {
                        // Pillai's V, Manova
                        // Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
                        if (show)
                            Console.WriteLine("Vdis");
                        if (Model == "GLM")
                        {
                            if (show)
                                Console.WriteLine("GLM");
                            a[0] = -F * G;
                            a[1] = 2d * F * G;
                            a[2] = -F * G + 4d * G * o1 + 4d * o2;
                            a[3] = -4 * G * o1;
                            a[4] = -4 * o2;

                            b[0] = F * L0;
                            b[1] = F * l1;
                            b[2] = F * l2 + 2d * l1 * o1 - 24d * F * G * o2;
                            b[3] = F * l3 + 4d * l2 * o1 + 48d * (F + 4d) * G * o2 + 128d * o3;
                            b[4] = F * l4 + 6d * l3 * o1 + 48d * (g2 - 2d) * o12 - 96d * (G + 1d) * o2 + 96d * G * o1 * o2 + 48d * o22;
                            b[5] = 8d * (l4 * o1 - 12d * (g2 + 2d) * o12 - 6d * ((F + 12d) * G + 4d) * o2 - 12d * G * o1 * o2 - 48d * o3);
                            b[6] = 8d * (6d * (g2 + 6d) * o12 + 3d * ((F + 20d) * G + 12d) * o2 - 12d * G * o1 * o2 - 16d * o3 - 12d * o22);
                            b[7] = 96d * (G * o1 * o2 + 4d * o3);
                            b[8] = 48d * o22;
                        }
                        else
                        {
                            if (show)
                                Console.WriteLine("CORR");
                            a[0] = -F * G - 4d * o2;
                            a[1] = 2d * F * G;
                            a[2] = -F * G + 4d * G * o1 + 8d * o2;
                            a[3] = -4 * G * o1;
                            a[4] = -4 * o2;
                            b[0] = F * L0 + 24d * F * G * o2 - 128d * o3 + 48d * o22;
                            b[1] = F * l1 - 48d * F * G * o2;
                            b[2] = F * l2 + 2d * l1 * o1 + 96d * o12 - 24d * (q * p2 + q * (q + 1d) * p - 4d) * o2 - 96d * G * o1 * o2 - 192d * o22;
                            b[3] = F * l3 + 4d * l2 * o1 + 96d * (q * p2 + (q2 + q + 4d) * p + 4d * (q + 1d)) * o2 + 96d * G * o1 * o2 + 640d * o3;
                            b[4] = F * l4 + 6d * l3 * o1 + 48d * (p2 + 2d * (q + 1d) * p + q2 + 2d * q - 3d) * o12 - 24d * (q * p2 + (q2 + q + 12d) * p + 4d * (3d * q + 5d)) * o2 + 192d * G * o1 * o2 + 288d * o22;

                            b[5] = 8d * l4 * o1 - 96d * (p2 + 2d * (q + 1d) * p + q2 + 2d * q + 3d) * o12 - 48d * (q * p2 + (q2 + q + 12d) * p + 4d * (3d * q + 4d)) * o2 - 192d * G * o1 * o2 - 768d * o3;

                            b[6] = 48d * (p2 + 2d * (q + 1d) * p + q2 + 2d * q + 7d) * o12 + 24d * (q * p2 + (q2 + q + 20d) * p + 4d * (5d * q + 8d)) * o2 - 96d * G * o1 * o2 - 128d * o3 - 192d * o22;

                            b[7] = 96d * (G * o1 * o2 + 4d * o3);
                            b[8] = 48d * o22;
                        }

                        break;
                    }
            }

            if (o1 == 0d & dis != 1)
            {
                c[0] = G * ((f2 - 8d * F + 16d) * g2 + 4d * (F - 4d) * G + 4d * (f2 - 2d * F - 8d));
                c[1] = -2 * F * G * L0;
                c[2] = F * G * (5d * (3d * F + 8d) * g2 + 4d * G + 4d * (F + 2d));
                c[3] = -(4d * G * (5d * (f2 + 8d * F + 16d) * g2 + 4d * (F + 4d) * G + 4d * (f2 + 6d * F + 8d)));
                c[4] = 5d * (3d * f2 + 40d * F + 144d) * g3 + 4d * (11d * F + 108d) * g2 + 4d * (11d * f2 + 130d * F + 288d) * G + 96d * (F + 2d);
                c[5] = -(2d * ((3d * f2 + 56d * F + 288d) * g3 + 4d * (5d * F + 72d) * g2 + 4d * (5d * f2 + 82d * F + 216d) * G + 96d * (F + 2d)));
                c[6] = (f2 + 24d * F + 160d) * g3 + 4d * (3d * F + 56d) * g2 + 4d * (3d * f2 + 62d * F + 184d) * G + 96d * (F + 2d);
                c[7] = 0d;
                c[8] = 0d;
                c[9] = 0d;
            }

            for (i = 0; i <= 9; i++)
            {
                DistN.Cdisn2(F + 2 * i, x, 2d * o1, ref LeftTail, ref Righttail);
                left[i] = LeftTail;
            }

            sum0 = left[0];
            if (show)
            {
                OutStr = Conversion.Str(sum0);
                OutStr = "sum0:  " + OutStr;
                Console.WriteLine(OutStr);
            }
            sum1 = 0d;
            for (i = 0; i <= 4; i++)
                sum1 = sum1 + a[i] * left[i];
            sum1 = sum1 / m;
            if (dis != 1)
                sum1 = sum1 / 4d;
            if (show)
            {
                OutStr = Conversion.Str(sum1);
                OutStr = "sum1:  " + OutStr;
                Console.WriteLine(OutStr);
            }

            sum2 = 0d;
            for (i = 0; i <= 8; i++)
                sum2 = sum2 + b[i] * left[i];
            sum2 = sum2 / (m * m);
            if (dis != 1)
                sum2 = sum2 / 96d;

            if (show)
            {
                OutStr = Conversion.Str(sum2);
                OutStr = "sum2:  " + OutStr;
                Console.WriteLine(OutStr);
            }

            sum3 = 0d;
            if (o1 == 0d | dis == 1 & Model == "GLM")
            {
                for (i = 0; i <= 9; i++)
                    sum3 = sum3 + c[i] * left[i];
            }
            sum3 = sum3 / (m * m * m);
            if (dis != 1)
                sum3 = F * sum3 / 384d;
            if (dis == 3 | dis == 1)
                sum3 = -sum3;
            if (show)
            {
                OutStr = Conversion.Str(sum3);
                OutStr = "sum3:  " + OutStr;
                Console.WriteLine(OutStr);
            }
            // If (sum0 * sum1 * sum2) <> 0 Then
            // t0(0) = -Abs(sum0):: x0(0) = -1
            // t0(1) = -Abs(sum1):: x0(1) = -1 / Sqr(m)
            // t0(2) = -Abs(sum2):: x0(2) = -1 / (m)
            // t0(3) = Abs(sum2):: x0(3) = 1 / (m)
            // t0(4) = Abs(sum1):: x0(4) = 1 / Sqr(m)
            // t0(5) = Abs(sum0):: x0(5) = 1
            // result = interpolate(True, 1 / (m * Sqr(m)), 0, 5, x0(), t0())
            // If ((sum1 < 0) And (sum2 < 0)) Then result = -result
            // If show Then Debug.Print "Result   :", result
            // End If
            LeftTail = sum0 + sum1 + sum2 + sum3;
            // If (LeftTail + sum1 < 1) And (LeftTail + sum1 > 0) Then LeftTail = LeftTail + sum1
            // If (LeftTail + sum2 < 1) And (LeftTail + sum2 > 0) Then LeftTail = LeftTail + sum2
            // If (LeftTail + sum3 < 1) And (LeftTail + sum3 > 0) Then LeftTail = LeftTail + sum3
            Righttail = 1d - LeftTail;
            // If show Then Debug.Print "New:", LeftTail + result
            // Console.WriteLine("LeftTail: {0}, Righttail: {1}", LeftTail, Righttail)
        }




    }
}