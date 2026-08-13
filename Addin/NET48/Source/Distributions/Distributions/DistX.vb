Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet

'
Public Module DistX



    Friend Const mp_cdisx As Int32 = 1
    Friend Const mp_fdisx As Int32 = 2



    Function AdjustSign(UseLeftTail As Boolean, x As Double) As Double
        If (UseLeftTail) Then Return x Else Return -x
    End Function


    Sub BrentDouble(UseLeftTail As Boolean, IsExact As Boolean, IsGLM As Boolean, proc As Int32,
                               ByRef a As Double, ByRef b As Double, fa As Double, fb As Double,
                               t1 As Double, LogTarget As Double, Df1 As Double, Df2 As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        Dim LogRefTail As Double
        eps = 0.00000000000001
        iter = 0
        maxiter = 1000
        If fa * fb > 0 Then
            Console.WriteLine("f(a) und f(b) need to have different sign")
            Exit Sub
        End If
        c = a : fc = fa
        d = b - a : e = d
        While iter < maxiter
            iter = iter + 1
            If fb * fc > 0 Then
                c = a : fc = fa : d = b - a : e = d
            End If
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
                    d = m : e = m
                Else
                    s = fb / fa
                    If a = c Then
                        p = 2 * m * s : q = 1 - s
                    Else
                        q = fa / fc : r = fb / fc
                        p = s * (2 * m * q * (q - r) - (b - a) * (r - 1))
                        q = (q - 1) * (r - 1) * (s - 1)
                    End If
                    If p > 0 Then q = -q Else p = -p
                    s = e : e = d
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            Select Case proc
                Case mp_cdisx : LogRefTail = DistFromBoost.Arb_ChiSquare_CDF(aflint.t(b), aflint.t(Df1), UseLeftTail, True).AsDouble
                Case mp_fdisx : LogRefTail = DistFromBoost.Arb_F_CDF(aflint.t(b), aflint.t(Df1), aflint.t(Df2), UseLeftTail, True).AsDouble
                Case Else : LogRefTail = Double.NaN
            End Select
            fb = AdjustSign(UseLeftTail, LogTarget - LogRefTail)
            'Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        'Console.WriteLine("final: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub




    Function ndisx(LeftTailTarget As Double, RightTailTarget As Double) As Double
        Dim temp As Double
        If LeftTailTarget < RightTailTarget Then
            temp = ndisx1(LeftTailTarget, RightTailTarget)
        Else
            temp = ndisx1(RightTailTarget, LeftTailTarget)
        End If
        If LeftTailTarget > RightTailTarget Then temp = -temp
        Return temp
    End Function



    Function ndisx1(LeftTailTarget As Double, RightTailTarget As Double) As Double
        Dim split1 As Double = 0.425
        Dim split2 As Double = 5.0#
        Dim const1 As Double = 0.180625
        Dim const2 As Double = 1.6
        Dim a0 As Double = 3.38713287279637
        Dim A1 As Double = 133.141667891784
        Dim A2 As Double = 1971.59095030655
        Dim a3 As Double = 13731.6937655095
        Dim a4 As Double = 45921.9539315499
        Dim A5 As Double = 67265.7709270087
        Dim a6 As Double = 33430.5755835881
        Dim A7 As Double = 2509.08092873012
        Dim b1 As Double = 42.3133307016009
        Dim b2 As Double = 687.187007492058
        Dim B3 As Double = 5394.19602142475
        Dim b4 As Double = 21213.7943015866
        Dim B5 As Double = 39307.8958000927
        Dim B6 As Double = 28729.0857357219
        Dim B7 As Double = 5226.49527885285
        Dim C0 As Double = 1.42343711074968
        Dim C1 As Double = 4.63033784615655
        Dim c2 As Double = 5.76949722146069
        Dim c3 As Double = 3.6478483247632
        Dim c4 As Double = 1.27045825245237
        Dim c5 As Double = 0.241780725177451
        Dim c6 As Double = 0.0227238449892692
        Dim C7 As Double = 0.000774545014278341
        Dim d1 As Double = 2.05319162663776
        Dim d2 As Double = 1.6763848301838
        Dim D3 As Double = 0.6897673349851
        Dim D4 As Double = 0.14810397642748
        Dim D5 As Double = 0.0151986665636165
        Dim D6 As Double = 0.000547593808499535
        Dim D7 As Double = 0.00000000105075007164442
        Dim E0 As Double = 6.6579046435011
        Dim e1 As Double = 5.46378491116411
        Dim e2 As Double = 1.78482653991729
        Dim E3 As Double = 0.296560571828505
        Dim E4 As Double = 0.0265321895265761
        Dim E5 As Double = 0.00124266094738808
        Dim E6 As Double = 0.0000271155556874349
        Dim E7 As Double = 0.000000201033439929229
        Dim f1 As Double = 0.599832206555888
        Dim f2 As Double = 0.136929880922736
        Dim f3 As Double = 0.0148753612908506
        Dim f4 As Double = 0.000786869131145613
        Dim f5 As Double = 0.0000184631831751005
        Dim f6 As Double = 0.000000142151175831645
        Dim f7 As Double = 0.00000000000000204426310338994

        Dim ppnd16 As Double, r As Double
        Dim r0 As Double ' or Arb
        Dim Q = LeftTailTarget - 0.5  ' calculation done in Arb, result converted back to double
        If (Q < 0) Then r0 = LeftTailTarget Else r0 = RightTailTarget
        If r0 <= 0 Then Return Double.NaN '{     ifault=1}

        If (Math.Abs(Q) <= split1) Then
            r = const1 - Q * Q
            ppnd16 = Q * (((((((A7 * r + a6) * r + A5) * r + a4) * r + a3) * r + A2) * r + A1) * r + a0) /
                     (((((((B7 * r + B6) * r + B5) * r + b4) * r + B3) * r + b2) * r + b1) * r + 1)
            Return ppnd16
        Else
            'Console.WriteLine("in > split1")
            r = Math.Sqrt(-Math.Log(r0))  ' calculation done in Arb, result converted back to double
            If (r <= split2) Then
                r = r - const2
                ppnd16 = (((((((C7 * r + c6) * r + c5) * r + c4) * r + c3) * r + c2) * r + C1) * r + C0) /
                 (((((((D7 * r + D6) * r + D5) * r + D4) * r + D3) * r + d2) * r + d1) * r + 1)
            Else
                r = r - split2
                'Console.WriteLine("in r - split2")
                ppnd16 = (((((((E7 * r + E6) * r + E5) * r + E4) * r + E3) * r + e2) * r + e1) * r + E0) /
                  (((((((f7 * r + f6) * r + f5) * r + f4) * r + f3) * r + f2) * r + f1) * r + 1)
            End If
            If Q < 0 Then ppnd16 = -ppnd16
            Return ppnd16
        End If
    End Function







    'Function cdisx_approx(ByVal LeftTail As Double, ByVal RightTail As Double, ByVal n As Double) As Double
    '    Dim t As Double, d As Double, k As Double, a As Double, result As Double, UseLambert As Boolean
    '    Dim h As Double, L As Double, mean As Double, stdev As Double, u As Double
    '    Dim m As Double, m2 As Double, m3 As Double, g As Double, z As Double
    '    'If (n < 1) Then n = 1
    '    UseLambert = True
    '    a = 1 / (0.5 * (n + 2) - 1)
    '    k = LnGamma(0.5 * (n + 2))
    '    d = a * (Math.Log(LeftTail) + k)
    '    t = -a * Math.Exp(LeftTail + d)
    '    If Math.Abs(t) > 0.1 Then UseLambert = False
    '    If UseLambert Then
    '        result = -(((((125 * t - 64) * t + 36) * t - 24) * t + 24) * t) / (12 * a)  'Result = -2 * LambertW(t) / a
    '    Else
    '        z = ndisx(LeftTail, RightTail)
    '        m = 1 / n : m2 = m * m : m3 = m2 * m
    '        mean = (14580 - 1944 * m - 189 * m2 + 200 * m3) / 17496
    '        stdev = Math.Sqrt(Math.Abs(648 * m + 72 * m2 - 37 * m3)) / 108
    '        g = Math.Sqrt(0.5 * m3) / 162
    '        z = z - g + (z * g) * (z - (2 * z * z - 5) * g)
    '        L = 6 * (z * stdev + mean)
    '        h = dreal.cbrt(2 * (L + Math.Sqrt(13 + L * (L - 5))) - 5)
    '        u = 0.5 + 0.5 * h - 1.5 / h
    '        u = u * u * u
    '        result = n * u * u
    '    End If
    '    'Console.WriteLine("chisquare quantile: {0} ", result)
    '    Return Math.Abs(result)
    'End Function



    Function cdisx(LeftTail As Double, RightTail As Double, Df1 As Double) As Double
        Dim x1 As Double
        'If (LeftTail < 0.5) Then
        '    x1 = boost2.dist_chisq(LeftTail, Df1, 6)

        'Else
        '    x1 = boost2.dist_chisq(RightTail, Df1, 7)
        'End If
        'Console.WriteLine("x1: {0}", x1)
        Return dreal.dist_chi2(Df1).qtf(LeftTail)
    End Function


    Function gamma_p_inv_2(a As Double, p As Double) As Double
        Return cdisx(p, 1 - p, 2 * a) / 2
    End Function


    Function gamma_q_inv_2(a As Double, q As Double) As Double
        Return cdisx(1 - q, q, 2 * a) / 2
    End Function





    'Function fdisx_approx_2(ByVal l As Double, ByVal r As Double, ByVal m As Double, ByVal n As Double) As Double
    '    Dim z As Double, q As Double, d As Double, u As Double, v As Double, h As Double
    '    q = n - 1 + m / 2
    '    d = (m * m - 4) / (24 * q * q)
    '    z = cdisx_approx(l, r, m)
    '    z = z * (1 + d) + z * z * (d / (m + 2))
    '    h = -z / q
    '    u = Math.Exp(h)
    '    v = -dreal.expm1(h)
    '    Return (v / u) * (n / m)
    'End Function


    'Function fdisx_approx_1(ByVal l As Double, ByVal r As Double, ByVal m As Double, ByVal n As Double) As Double
    '    Dim u As Double, b As Double
    '    u = ndisx(l, r)
    '    If u < 0 Then b = 0.8 Else b = 0.4
    '    If ((m / n) < (1 - b * u / 4.7)) And (u <= n - 1) Then
    '        Return fdisx_approx_2(l, r, m, n)
    '    Else
    '        Return 1 / fdisx_approx_2(r, l, n, m)
    '    End If
    'End Function


    'Function fdisx_approx(ByVal L As Double, ByVal r As Double, ByVal m As Double, ByVal n As Double) As Double
    '    If m <= n Then
    '        Return fdisx_approx_1(L, r, m, n)
    '    Else
    '        Return 1 / fdisx_approx_1(r, L, n, m)
    '    End If
    'End Function







    Function fdisx(LeftTail As Double, RightTail As Double, Df1 As Double, Df2 As Double) As Double
        Dim x1 As Double

        'If (LeftTail < 0.5) Then
        '    x1 = boost2.dist_fisher_f(LeftTail, Df1, Df2, 6)
        'Else
        '    x1 = boost2.dist_fisher_f(RightTail, Df1, Df2, 7)
        'End If
        'Console.WriteLine("x1: {0}", x1)

        Return dreal.dist_fisher_f(Df1, Df2).qtf(LeftTail)
    End Function


    Sub betadisx(LeftTail As Double, RightTail As Double, a As Double, b As Double, ByRef x As Double, ByRef y As Double)
        Dim w = Math.Abs(fdisx(LeftTail, RightTail, 2 * a, 2 * b))
        x = a * w / (a * w + b) : y = b / (a * w + b)
    End Sub


    Function ibeta_inv_2(a As Double, b As Double, p As Double) As Double
        Dim x, y As Double
        betadisx(p, 1 - p, a, b, x, y)
        Return x
    End Function


    Function ibetac_inv_2(a As Double, b As Double, q As Double) As Double
        Dim x, y As Double
        betadisx(1 - q, q, a, b, x, y)
        Return x
    End Function



    Function Tdisx(LeftTail As Double, RightTail As Double,
n As Double) As Double
        Dim t As Double, Swapped As Boolean
        If LeftTail = 0.5 Then Return 0
        Swapped = False
        If LeftTail < 0.5 Then
            t = LeftTail
            LeftTail = RightTail
            RightTail = t
            Swapped = True
        End If
        RightTail = 2 * RightTail
        LeftTail = 1 - RightTail
        t = Math.Sqrt(fdisx(LeftTail, RightTail, 1, n))
        If Swapped Then t = -t
        Return t
    End Function





    Sub demoNdisx()
        'Dim LeftTail As Double = 0.001
        Dim LeftTail As Double = 0.999999
        Dim RightTail As Double = 1 - LeftTail
        'Dim RightTail As Double = 1.0E-220
        'Dim LeftTail As Double = 1 - RightTail
        Dim R1 As Double = ndisx(LeftTail, RightTail)
        Console.WriteLine("R1: {0} ", R1)
        Console.WriteLine("")
        'Dim R2 As Double = dreal.dist_qnorm(LeftTail, 0, 1, True, False)
        'Console.WriteLine("R2: {0} ", R2)
        Console.WriteLine("")
    End Sub


    Sub demoCdisx()
        Dim m As Double = 10.1
        'Dim LeftTail As Double = 0.001
        'Dim LeftTail As Double = 0.999999
        'Dim RightTail As Double = 1 - LeftTail
        Dim RightTail As Double = 1.0E-220
        Dim LeftTail As Double = 1 - RightTail
        Dim X0 As Double = cdisx(LeftTail, RightTail, m)
        Console.WriteLine("X0: {0} ", X0)
        'Dim L1 As Double = boost2.dist_chisq(X0, m, 2)
        'Console.WriteLine("L1: {0} ", L1)
        'Dim R1 As Double = boost2.dist_chisq(X0, m, 3)
        'Console.WriteLine("R1: {0} ", R1)
        Console.WriteLine("")
    End Sub


    Sub demoFdisx()
        Dim m As Double = 1.5
        Dim n As Double = 6
        Dim LeftTail As Double = 0.901
        Dim RightTail As Double = 1 - LeftTail
        'Dim RightTail As Double = 1.0E-220
        'Dim LeftTail As Double = 1 - RightTail
        Dim X0 As Double = fdisx(LeftTail, RightTail, m, n)
        Console.WriteLine("X0: {0} ", X0)
        'Dim L1 As Double = boost2.dist_fisher_f(X0, m, n, 2)
        'Console.WriteLine("L1: {0} ", L1)
        'Dim R1 As Double = boost2.dist_fisher_f(X0, m, n, 3)
        'Console.WriteLine("R1: {0} ", R1)

    End Sub


    Sub demoTdisx()
        Dim m As Double = 10.1
        'Dim LeftTail As Double = 0.001
        Dim LeftTail As Double = 0.999999
        Dim RightTail As Double = 1 - LeftTail
        'Dim RightTail As Double = 1.0E-220
        'Dim LeftTail As Double = 1 - RightTail
        Dim R1 As Double = Tdisx(LeftTail, RightTail, m)
        Console.WriteLine("R1: {0} ", R1)
        Console.WriteLine("")
        'Dim R2 As Double = dreal.dist_qt(LeftTail, m, True, False)
        'Console.WriteLine("R2: {0} ", R2)
        Console.WriteLine("")
    End Sub


    Sub demoBetadisx()
        Dim a As Double = 1.5
        Dim b As Double = 6
        Dim LeftTail As Double = 0.01
        Dim RightTail As Double = 1 - LeftTail
        Dim x, y As Double
        betadisx(LeftTail, RightTail, a, b, x, y)
        Console.WriteLine("x: {0}, y: {0} ", x, y)

        Console.WriteLine("")
        'Dim x1 = dreal.dist_qbeta(LeftTail, a, b, True, False)
        'Dim y1 = dreal.dist_qbeta(RightTail, a, b, False, False)
        'Console.WriteLine("x: {0}, y: {0} ", x1, y1)

    End Sub


    Sub demo_ibeta_inv()
        Dim a As Double = 1.5
        Dim b As Double = 6
        Dim p = 0.99
        Dim R0 = dreal.real_ibeta_inv(a, b, p)
        Console.WriteLine("R0: {0}", R0)

        Dim R1 = ibeta_inv_2(a, b, p)
        Console.WriteLine("R1: {0}", R1)
    End Sub


    Sub demo_ibetac_inv()
        Dim a As Double = 1.5
        Dim b As Double = 6
        Dim q = 0.99
        Dim R0 = dreal.real_ibetac_inv(a, b, q)
        Console.WriteLine("R0: {0}", R0)

        Dim R1 = ibetac_inv_2(a, b, q)
        Console.WriteLine("R1: {0}", R1)
    End Sub


    Sub demoGamma_p_inv()
        Dim a = 2
        Dim p = 0.99
        Dim R0 = dreal.real_gamma_p_inv(a, p)
        Console.WriteLine("R0: {0}", R0)

        Dim R1 = gamma_p_inv_2(a, p)
        Console.WriteLine("R1: {0}", R1)
    End Sub


    Sub demoGamma_q_inv()
        Dim a = 2
        Dim q = 0.99
        Dim R0 = dreal.real_gamma_q_inv(a, q)
        Console.WriteLine("R0: {0}", R0)

        Dim R1 = gamma_q_inv_2(a, q)
        Console.WriteLine("R1: {0}", R1)
    End Sub



End Module
