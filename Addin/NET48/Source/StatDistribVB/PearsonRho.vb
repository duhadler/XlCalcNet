Imports System
Imports System.Numerics
Imports System.Diagnostics
'Imports mpFunLabNET


Module DemoPearsonDouble





    '**********************************************************************
    'Pearson's rho cdf
    ''**********************************************************************

#Region "PearsonRho"

    'Algorithm by Hotelling, 1953
    Sub RhoDisN2_2(n As Double, r As Double, rho As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim a As Double ', LeftTail2 As Double
        Dim gf As Double, A1 As Double, sum3 As Double, summand As Double, RelError2 As Double
        Dim m As Integer, k As Integer, smax As Integer, j As Integer, S As Integer
        Dim RelError As Double, Q As Double, BK As Double, sign As Double, t2 As Double
        Dim X As Double, y As Double, sum As Double, sum2 As Double, Factor As Double, TWO As Double
        Dim fs(0 To 1) As Double, Betas(0 To 1) As Double, Dens(0 To 1) As Double
        Dim IBeta() As Double, nk() As Double
        Dim Swapped As Boolean, slimit As Integer, mlimit As Integer
        slimit = 100
        mlimit = 10

        ReDim IBeta(slimit)
        ReDim nk(mlimit)
        Swapped = False
        If rho > r Then
            r = -r
            rho = -rho
            Swapped = True
        End If
        n = n - 1
        smax = -1
        Q = (n - 1) * 0.398942280401433
        Q = Q * Math.Exp(LnGamma(n) - LnGamma(n + 0.5))
        X = ((r - rho) / (1 - rho * r))
        X = X * X
        y = 1 - X
        Factor = 1
        A1 = 1 - rho * rho
        a = 1
        TWO = 1
        RelError = 1
        m = 0
        sum3 = 0
        sum = 0
        While Math.Abs(RelError) > 0.0000000001
            S = 0
            gf = 1
            RelError2 = 1
            While (Math.Abs(RelError2) > 0.0000000001)
                If S > smax Then
                    smax = S
                    If smax > slimit Then
                        slimit = 2 * slimit
                        ReDim Preserve IBeta(slimit)
                    End If
                    If (S Mod 2 <> 0) Then j = 1 Else j = 0
                    If S <= 1 Then
                        Call betadis((S + 1) / 2, (n - 1) / 2, X, y, LeftTail, Betas(j), Dens(j))
                        fs(j) = Math.Exp(Lnbeta((S + 1) / 2, (n - 1) / 2))
                        Dens(j) = 2 * y * Dens(j)
                    Else
                        fs(j) = fs(j) * (S - 1) / (n + S - 2)
                        Dens(j) = Dens(j) * X / (S - 1)
                        Betas(j) = Betas(j) + Dens(j)
                        Dens(j) = Dens(j) * (n + S - 2)
                    End If
                    IBeta(S) = Betas(j) * fs(j)
                End If
                If S = 0 Then
                    sum3 = IBeta(0)
                Else
                    gf = gf * rho * (1.5 - m - S) / S
                    summand = gf * IBeta(S)
                    sum3 = sum3 + summand
                    If sum3 <> 0 Then RelError2 = summand / sum3
                End If
                S = S + 1
            End While
            nk(m) = a * sum3 / 2
            a = a * A1
            If m = 0 Then
                sum = nk(0)
            Else
                TWO = TWO * 2
                Factor = Factor * (2.0# * m - 1) * (2.0# * m - 1) / (m * 4 * (2 * n + 2 * m - 1))
                sum2 = TWO * nk(0)
                t2 = TWO
                sign = -1
                BK = 1
                For k = 1 To m
                    BK = BK * (m - k + 1) / k
                    t2 = t2 / 2
                    sum2 = sum2 + sign * BK * t2 * nk(k)
                    sign = -sign
                Next k
                sum2 = Factor * sum2
                sum = sum + sum2
                RelError = sum2 / sum
            End If
            m = m + 1
            If m > mlimit Then
                mlimit = 2 * mlimit
                ReDim Preserve nk(mlimit)
            End If
        End While
        '  Debug.Print "smax,m", smax, m, slimit, mlimit
        RightTail = Q * sum
        LeftTail = 1 - RightTail
        If Swapped Then
            sum = RightTail
            RightTail = LeftTail
            LeftTail = sum
        End If
        Erase IBeta
        Erase nk
        '  Debug.Print "slimit: ", slimit, "mlimit:", mlimit
    End Sub



    Sub RhoDisN1_2(n As Integer, r As Double, rho As Double,
      LeftTail As Double, RightTail As Double)
        Dim delta As Double, t As Double, result As Double
        t = r * Math.Sqrt((n - 2) / (1 - r * r))
        delta = rho * Math.Sqrt((n - 2) / (1 - rho * rho))
        '   result = tdisn(n - 2, t, delta, LeftTail, RightTail)
        result = tdisnOwen(n - 2, t, delta, LeftTail, RightTail)

    End Sub





    Function CornishFisher4_kappa_2(z As Double, k1 As Double, k2 As Double, k3 As Double, k4 As Double) As Double
        Dim U As Double, u2 As Double, u3 As Double, X As Double, g1 As Double, g2 As Double
        g1 = k3 / (Math.Sqrt(k2) * k2)
        g2 = k4 / (k2 * k2)
        U = (z - k1) / Math.Sqrt(k2)
        u2 = U * U : u3 = U * u2
        X = U - (u2 - 1) * g1 / 6 - (u3 - 3 * U) * g2 / 24 + (4 * u3 - 7 * U) * g1 * g1 / 36
        Return ndis(X)
    End Function


    Function CornishFisher4_kappa_X_2(LeftTail As Double, RightTail As Double, k1 As Double, k2 As Double, k3 As Double, k4 As Double) As Double
        Dim U As Double, u2 As Double, u3 As Double, X As Double, g1 As Double, g2 As Double
        g1 = k3 / (Math.Sqrt(k2) * k2)
        g2 = k4 / (k2 * k2)
        U = ndisx(LeftTail, RightTail)
        u2 = U * U : u3 = U * u2
        X = U + (u2 - 1) * g1 / 6 + (u3 - 3 * U) * g2 / 24 + (2 * u3 - 5 * U) * g1 * g1 / 36
        Return k1 + Math.Sqrt(k2) * X
    End Function


    Function Fisher_kappa_X_2(LeftTail As Double, RightTail As Double, n As Double, rho As Double) As Double
        Dim Rho2 As Double, rho3 As Double, rho4 As Double, N1 As Double, N2 As Double, n3 As Double
        Dim k1 As Double, k2 As Double, k3 As Double, k4 As Double, y As Double ', e As Double
        ' Note: n = sample size
        N1 = n - 1
        N2 = N1 * N1
        n3 = N2 * N1
        Rho2 = rho * rho
        rho3 = Rho2 * rho
        rho4 = Rho2 * Rho2
        k1 = 0.5 * Math.Log((1 + rho) / (1 - rho)) + rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1)
        k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1
        k3 = rho3 / n3
        k4 = 2 / n3
        y = CornishFisher4_kappa_X_2(LeftTail, RightTail, k1, k2, k3, k4)
        Return zTransformInverse(y)
    End Function


    Function zTransformInverse_2(y As Double) As Double
        y = Math.Exp(2 * y)
        Return (y - 1) / (y + 1)
    End Function


    Function zTransform_2(r As Double) As Double
        Return 0.5 * Math.Log((1 + r) / (1 - r))
    End Function


    Function Fisher_simple_2(r As Double, n As Double, rho As Double) As Double
        Dim X As Double, Result As Double
        X = (zTransform_2(r) - zTransform_2(rho)) * Math.Sqrt(n - 3)
        Result = ndis(X)
        Return Result
    End Function



    Function Fisher_simple_X_2(LeftTail As Double, RightTail As Double, n As Double, rho As Double) As Double
        Dim k1 As Double, U As Double, y As Double ', e As Double
        U = ndisx(LeftTail, RightTail)
        k1 = zTransform_2(rho)
        '  k1 = 0.5 * Log((1 + rho) / (1 - rho))
        y = U / Math.Sqrt(n - 3) + k1
        Return zTransformInverse_2(y)
    End Function

    Function Fisher_kappa_2(r As Double, n As Double, rho As Double) As Double
        Dim Rho2 As Double, rho3 As Double, rho4 As Double, N1 As Double, N2 As Double, n3 As Double
        Dim z As Double, k1 As Double, k2 As Double, k3 As Double, k4 As Double
        ' Note: n = sample size
        N1 = n - 1
        N2 = N1 * N1
        n3 = N2 * N1
        Rho2 = rho * rho
        rho3 = Rho2 * rho
        rho4 = Rho2 * Rho2
        z = 0.5 * Math.Log((1 + r) / (1 - r))
        k1 = 0.5 * Math.Log((1 + rho) / (1 - rho)) + rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1)
        k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1
        k3 = rho3 / n3
        k4 = 2 / n3
        Return CornishFisher4_kappa2_2(z, k1, k2, k3, k4, 0)
    End Function


    Function CornishFisher4_kappa2_2(z As Double, k1 As Double, k2 As Double, k3 As Double, k4 As Double, k6 As Double) As Double
        Dim U As Double, u2 As Double, u3 As Double, u4 As Double, u5 As Double, X As Double, g1 As Double, g2 As Double, g4 As Double
        g1 = k3 / (Math.Sqrt(k2) * k2)
        g2 = k4 / (k2 * k2)
        g4 = k6 / (k2 * k2 * k2)
        U = (z - k1) / Math.Sqrt(k2)
        u2 = U * U : u3 = U * u2 : u5 = u3 * u2 : u4 = u2 * u2
        X = U - (u2 - 1) * g1 / 6 - (u3 - 3 * U) * g2 / 24 + (4 * u3 - 7 * U) * g1 * g1 / 36
        X = X + (11 * u4 - 42 * u2 + 15) * g1 * g2 / 144
        X = X - (u5 - 10 * u3 + 15 * U) * g4 / 720
        Return ndis(X)
    End Function


    Function Fisher_kappa2_2(r As Double, n As Double, rho As Double) As Double
        Dim Rho2 As Double, rho3 As Double, rho4 As Double, N1 As Double, N2 As Double, n3 As Double
        Dim z As Double, k1 As Double, k2 As Double, k3 As Double, k4 As Double, k6 As Double
        ' Note: n = sample size
        N1 = n - 1
        N2 = N1 * N1
        n3 = N2 * N1
        Rho2 = rho * rho
        rho3 = Rho2 * rho
        rho4 = Rho2 * Rho2
        z = 0.5 * Math.Log((1 + r) / (1 - r)) - 0.5 * Math.Log((1 + rho) / (1 - rho))
        k1 = rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1)
        k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1
        k3 = rho3 / n3
        k4 = 2 / n3 + 3 * (4 - rho4) / (N2 * N2)
        k6 = 24 / (n3 * N2)
        k6 = 0
        Return CornishFisher4_kappa2_2(z, k1, k2, k3, k4, k6)
    End Function





    Sub DemoRhoExplicit_2()
        Dim n As Integer, r As Double, rho As Double, result As Double
        Dim LeftTail As Double, density As Double
        ' Smallest N: N = 3
        n = 6
        r = 0.1
        rho = 0.99
        result = RhoExplicit(n, r, rho)
        '  Call RhoDisN2(n, r, rho, LeftTail, RightTail)
        '  Debug.Print LeftTail, RightTail
        Console.WriteLine("result: {0}, result / LeftTail: {1}", result, result / LeftTail)
        density = RhoDensity(n, r, rho)
        Console.WriteLine("density: {0}", density)
    End Sub


    Function RhoDensity_2(n As Long, r As Double, rho As Double) As Double
        Dim w As Double, t As Double
        Dim X As Double, x2 As Double, r2 As Double, Rho2 As Double, U As Double, k1 As Double
        Dim A2 As Double, a As Double, c2 As Double, C As Double, b2 As Double, b As Double
        Dim ACTerm As Double, density As Double

        Const Pi = 3.14159265358979
        r2 = r * r : Rho2 = rho * rho
        X = r * rho : x2 = X * X : w = 0.5 * (1 + X)
        A2 = 1 - Rho2 : a = Math.Sqrt(A2)
        c2 = 1 - r2 : C = Math.Sqrt(c2)
        b2 = 1 - x2 : b = Math.Sqrt(b2)
        U = Math.Acos(-X) / b

        t = t1(n, w)
        k1 = ((n - 2) / Math.Sqrt(2 * Pi)) * Math.Exp(LnGamma(n - 1) - LnGamma(n - 0.5))
        ACTerm = Math.Exp(Math.Log(a) * (n - 1) + Math.Log(C) * (n - 4) + Math.Log(1 - X) * (1.5 - n))
        density = k1 * ACTerm * t
        Return density

    End Function


    'Hypergeometric function for density of pearson's rho
    Function t1_2(n As Double, w As Double) As Double
        Dim i As Integer, A1 As Double, C1 As Double, m1 As Double, sum As Double, RelErr As Double
        A1 = 0.5
        C1 = n - 0.5
        m1 = 0.25 * w / C1
        sum = 1 + m1
        i = 1
        Do
            i = i + 1
            A1 = A1 + 1
            C1 = C1 + 1
            m1 = m1 * A1 * A1 * w / (C1 * i)
            sum = sum + m1
            RelErr = m1 / sum
            '  Debug.Print i, sum, M1, M1 / sum
        Loop Until RelErr < 0.0000000000000001
        Return sum
    End Function



    Function RhoExplicit_2(n As Integer, r As Double, rho As Double) As Double
        Dim F() As Double, d() As Double
        Dim sum1 As Double, sum2 As Double, sum3 As Double, sum31 As Double, sum32 As Double
        Dim X As Double, x2 As Double, r2 As Double, Rho2 As Double, U As Double
        Dim A2 As Double, a As Double, c2 As Double, C As Double, b2 As Double, b As Double
        Dim d1 As Double, f6 As Double, f6u As Double, result As Double
        Dim k As Integer, k1 As Integer, k4 As Integer
        Const Pi = 3.14159265358979
        r2 = r * r : Rho2 = rho * rho
        X = r * rho : x2 = X * X
        A2 = 1 - Rho2 : a = Math.Sqrt(A2)
        c2 = 1 - r2 : C = Math.Sqrt(c2)
        b2 = 1 - x2 : b = Math.Sqrt(b2)
        U = Math.Acos(-X) / b
        ReDim F(n)
        ReDim d(n)

        If (n Mod 2) <> 0 Then
            k1 = 2
            d1 = Math.Acos(-r) / Pi
            result = d1 - (rho * C * U) / Pi
            If (n = 3) Then Return result : Exit Function Else : F(1 + k1) = result
            result = d1 + ((x2 + 2 - 3 * Rho2) * r * C * A2 + (Rho2 - 3 + 2 * Rho2 * x2) * rho * c2 * C * U) / (2 * Pi * b2 * b2)
            If (n = 5) Then Return result : Exit Function Else : F(3 + k1) = result
        Else
            k1 = 3
            d1 = Math.Acos(rho) / Pi
            result = d1 + (-rho * a * c2 + r * A2 * a * U) / (Pi * b2)
            If (n = 4) Then Return result : Exit Function Else : F(1 + k1) = result
            f6 = (X * r * (2 * x2 + 13) - 2 * rho * (4 * x2 * x2 + 6 * x2 + 5) + Rho2 * rho * (11 * x2 + 4)) * a * c2
            f6u = ((-r2 + 3) + 2 * x2 * (-2 * r2 + 1)) * r * A2 * A2 * a * U
            result = d1 + (f6 + 3 * f6u) / (6 * Pi * b2 * b2 * b2)
            If (n = 6) Then Return result : Exit Function Else : F(3 + k1) = result
        End If

        d(3) = A2 * (1 + X * U) / (Pi * b2 * C)
        d(4) = A2 * a * (b2 * U + 3 * X * (1 + X * U)) / (b2 * b2 * Pi)

        ' This is calculating the density
        For k = 5 To n
            d(k) = (a * C * X * d(k - 1) * (2 * k - 5) / (k - 3) + A2 * c2 * d(k - 2) * (k - 3) / (k - 4)) / b2
        Next k

        ' This is calculating the CDF
        For k = k1 + 5 To n Step 2
            k4 = k - 4
            sum1 = (2 * k4 * Rho2 - k + 5) * F(k - 2)
            sum2 = (k - 5) * A2 * F(k4)
            sum31 = rho * (k4 * a * C - (2 * k - 9) * b2 / (a * C)) * d(k - 1) / k4
            k4 = k4 * k4
            sum32 = r * (k4 + (3 * k * (k - 8) + 47) * Rho2) * d(k - 2) / k4
            sum3 = (sum31 + sum32)
            F(k) = (sum1 + sum2 + sum3) / ((k - 3) * Rho2)
            '  Debug.Print k, F(k + 5), sum1, sum2, sum31, sum32, (sum31 + sum32) / sum31
        Next k


        Return F(n)
    End Function



    ' Algorithm by Guenther
    Sub RhoDisN5_2(n As Double, r As Double, rho As Double, LeftTail As Double, RightTail As Double)
        Const Pi = 3.14159265358979
        Dim sign As Double, r2 As Double, Rho2 As Double, Left1 As Double, Right1 As Double
        Dim RelError As Double, summand As Double, sum0 As Double, sum1 As Double,
            sum2 As Double, k1 As Double, k2 As Double, density As Double
        Dim j As Long
        Dim sum4 As Double, sum3 As Double, RelError3 As Double
        Rho2 = rho * rho
        r2 = r * r
        If rho < 0 Then sign = -1 Else If rho > 0 Then sign = 1 Else sign = 0
        Call betadis(1 / 2, (n - 1) / 2, Rho2, 1 - Rho2, Left1, Right1, density)
        sum0 = 0.5 * (1 + sign * Left1)
        If r = 0 Then
            RightTail = sum0
            LeftTail = 1 - RightTail
            Exit Sub
        End If
        k1 = 0.5 * Math.Exp(Math.Log(1 - Rho2) * (n - 1) / 2)
        Call betadis(1 / 2, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
        sum1 = k1 * Left1
        sum3 = k1 * Right1
        j = 0 : RelError = 1 : RelError3 = 1
        While RelError > 0.00000000000001
            j = j + 1
            k1 = ((2 * j + n - 3) / (2 * j)) * Rho2 * k1
            Call betadis((2 * j + 1) / 2, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
            summand = k1 * Left1
            sum1 = sum1 + summand
            RelError = summand / sum1
            summand = k1 * Right1
            sum3 = sum3 + summand
            If sum3 <> 0 Then RelError3 = summand / sum3
            '    Debug.Print j, sum1, RelError, Left1
            '    Debug.Print j, sum3, RelError3, Right1
        End While
        '  Debug.Print "Gunther j1:", j
        If rho = 0 Then
            sum2 = 0 : sum4 = 0
        Else
            k2 = rho / Math.Sqrt(Pi) * Math.Exp(LnGamma(n / 2) - LnGamma((n - 1) / 2) + Math.Log(1 - Rho2) * (n - 1) / 2)
            Call betadis(1, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
            sum2 = k2 * Left1
            sum4 = k2 * Right1
            j = 0 : RelError = 1 : RelError3 = 1
            While RelError > 0.00000000000001
                j = j + 1
                k2 = ((2 * j + n - 2) / (2 * j + 1)) * Rho2 * k2
                Call betadis(j + 1, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
                summand = k2 * Left1
                sum2 = sum2 + summand
                If sum2 <> 0 Then RelError = summand / sum2
                summand = k2 * Right1
                sum4 = sum4 + summand
                If sum4 <> 0 Then RelError3 = summand / sum4
                '    Debug.Print j, sum2, RelError, Left1
                '    Debug.Print j, sum4, RelError3, Right1
            End While
            '  Debug.Print "j2:"; j
        End If
        '  Debug.Print "sum0:", 1 - sum0, sum0
        '  Debug.Print "sum1:", sum1, sum2, sum1 + sum2
        '  Debug.Print "sum3:", sum3, sum4, sum3 + sum4
        '  Debug.Print "sum5:", , sum1 + sum3, sum2 + sum4
        RightTail = sum0 - (sum1 + sum2)
        LeftTail = (1 - sum0) + (sum1 + sum2)
    End Sub



    Sub demoRho_Guenther_2()
        Dim result As Double, n As Integer, rho As Double, r As Double ', X As Double, y As Double
        Dim LeftTail As Double, RightTail As Double ', l2 As Double, r2 As Double
        n = 7
        r = 0.236
        rho = 0.9
        RightTail = 0.05
        LeftTail = 1 - RightTail
        '  r = RhoDisX0(LeftTail, RightTail, n)
        Console.WriteLine("r: {0}", r)
        Call RhoDisN_Guenther(n, r, rho, LeftTail, RightTail)
        Console.WriteLine("Guenther: {0}, {1} ", LeftTail, RightTail)
        '  Debug.Print ndisx(LeftTail, RightTail)
        '  LeftTail = tdisn(N - 2, R * Sqr((N - 2) / (1 - R * R)), 0, L2, R2)
        '  RightTail = 1 - LeftTail
        '  Debug.Print LeftTail, RightTail
        '  Call RhoDisN2(n, r, rho, LeftTail, RightTail)
        '  Debug.Print "Hotelling: ", LeftTail, RightTail
        LeftTail = RhoExplicit(n, r, rho)
        Console.WriteLine("RhoExplicit: {0}, {1} ", LeftTail, 1 - LeftTail)

        '    result = Rhodis_B(r, n, rho)
        '  Debug.Print "Fisherb:  ", result
        '    result = Rhodis_B_2(r, n, rho)
        '  Debug.Print "Fisherb2:  ", result
        '
        'result = Fisher_kappa(r, n, rho)
        'Console.WriteLine("Fisherk: {0} ", result)
        'result = Fisher_kappa2(r, n, rho)
        'Console.WriteLine("Fisherk2: {0} ", result)

    End Sub


#End Region


    ' Confidence interval upper limit
    Sub demordisn_nc_2()
        Dim LeftTail As Double, RightTail As Double, n As Double ', d As Double, t As Double, p As Double, t2 As Double, p2 As Double
        Dim z As Double, RefTail As Double ', CDF As Double, PDF As Double, i As Long, RelErr As Double
        Dim rho_alpha As Double, rho As Double, rTail As Double ', d_rho  As Double, t_delta As Double
        LeftTail = 0.99
        RightTail = 1 - LeftTail
        If LeftTail < 0.5 Then RefTail = LeftTail Else RefTail = RightTail
        z = ndisx(LeftTail, RightTail)
        n = 14
        rho = 0.6

        'Debug.Print "****************************************************************"

        rho_alpha = Rhodis_NC_2(n, rho, LeftTail, RightTail)
        Console.WriteLine("rho_alpha W: {0}, {1}, {2}, {3}", rho_alpha, 1 - rho_alpha, LeftTail, RightTail)

        rTail = RhoDis_W_2(rho, n, rho_alpha)
        Console.WriteLine("rTail: {0}", rTail)


    End Sub





    'These approximations are sensitive to whether rho and or r are negative. Still need to figure out the details!!!

    'Algorithm by Winterbottom, 1980
    Function RhoDis_W_2(r As Double, n As Double, rho As Double) As Double
        Dim y As Double, m As Double, w As Double, r2 As Double, r3 As Double, r4 As Double, m2 As Double
        Dim w2 As Double, w3 As Double, w5 As Double
        r2 = r * r : r3 = r2 * r
        r4 = r2 * r2
        m = n - 1
        m2 = m * m
        w = (zTransform(r) - zTransform(rho))
        w2 = w * w : w3 = w2 * w : w5 = w2 * w3
        y = -r / (2 * m) - (3 * r + r3) / (12 * m2)
        y = y + (1 - (1 + r2) / (4 * m) + (3 - 11 * r4) / (96 * m2)) * w
        y = y + ((3 * r - 4 * r3) / (24 * m)) * w2
        y = y - ((1 / 12) - (2 + 7 * r2 - 6 * r4) / (48 * m)) * w3
        y = y + (3 / 160) * w5
        Return ndis(Math.Sqrt(m) * y)
    End Function



    'Algorithm by Winterbottom, 1980
    Function Rhodisx_W_2(LeftTail As Double, RightTail As Double, n As Double, rho As Double) As Double
        Dim y As Double, X As Double, m As Double, m2 As Double, m12 As Double, m32 As Double, m52 As Double
        Dim Rho2 As Double, rho3 As Double, rho4 As Double, z As Double, x2 As Double, x3 As Double, x4 As Double, x5 As Double
        X = ndisx(LeftTail, RightTail)
        z = zTransform_2(rho)
        '  z = 0.5 * Log((1 + rho) / (1 - rho))
        m = n - 1
        m2 = m * m : m12 = Math.Sqrt(m) : m32 = m * m12 : m52 = m2 * m12
        x2 = X * X : x3 = x2 * X : x4 = x3 * X : x5 = x4 * X
        Rho2 = rho * rho : rho3 = Rho2 * rho : rho4 = rho3 * rho
        y = z + X / m12 + rho / (2 * m)
        y = y + (x3 + 3 * (3 - Rho2) * X) / (12 * m32)
        y = y + (4 * rho3 * x2 - rho3 + 15 * rho) / (24 * m2)
        y = y + (x5 + (-60 * rho4 + 30 * Rho2 + 80) * x3 + (45 * rho4 - 21 * Rho2 + 375) * X) / (480 * m52)
        Return zTransformInverse_2(y)
        '  Rhodisx_W = (Exp(2 * y) - 1) / (Exp(2 * y) + 1)
    End Function



    'Algorithm by Winterbottom, 1980
    'Confidence interval upper limit
    Function Rhodis_NC_2(n As Double, r As Double, LeftTail As Double, RightTail As Double) As Double
        Dim y As Double, X As Double, m As Double, m2 As Double, m12 As Double, m32 As Double, m52 As Double
        Dim r2 As Double, r3 As Double, r4 As Double, z As Double, x2 As Double, x3 As Double, x4 As Double, x5 As Double
        X = ndisx(LeftTail, RightTail)
        z = zTransform_2(r)
        '  z = 0.5 * Log((1 + r) / (1 - r))
        m = n - 1
        m2 = m * m : m12 = Math.Sqrt(m) : m32 = m * m12 : m52 = m2 * m12
        x2 = X * X : x3 = x2 * X : x4 = x3 * X : x5 = x4 * X
        r2 = r * r : r3 = r2 * r : r4 = r3 * r
        y = z + X / m12 - r / (2 * m)
        y = y + (x3 + 3 * (1 + r2) * X) / (12 * m32)
        y = y - (4 * r3 * x2 + 5 * r3 + 9 * r) / (24 * m2)
        y = y + (x5 + (60 * r4 - 30 * r2 + 20) * x3 + (165 * r4 + 30 * r2 + 15) * X) / (480 * m52)
        Return zTransformInverse_2(y)
        '  Rhodis_NC = (Exp(2 * y) - 1) / (Exp(2 * y) + 1)
    End Function



    Function Rhodis_B(n As Double, r As Double, rho As Double) As Double
        Dim m2 As Double, m1 As Double, m3 As Double, m4 As Double, m5 As Double
        Dim r2 As Double, r3 As Double, r4 As Double, F As Double
        Dim a As Double, b As Double, C As Double, d As Double
        Dim X As Double, p As Double, k As Double
        m2 = 1 / (n - 1) : m1 = Math.Sqrt(m2) : m3 = m2 * m1 : m4 = m2 * m2 : m5 = m2 * m3
        r2 = r * r : r3 = r2 * r : r4 = r3 * r : F = 1.2

        a = m3 / 12 + (6 * r4 - 3 * r2 + 2 * F) * m5 / 48
        b = -r3 * m4 / 6
        C = m1 + (1 + r2) * m3 / 4 + (11 * r4 + 2 * r2 + 1) * m5 / 32
        d = r * m2 / 2 + (5 * r3 + 9 * r) * m4 / 24
        d = 0.5 * Math.Log((1 + rho) / (1 - rho)) - 0.5 * Math.Log((1 + r) / (1 - r)) + d

        b = b / a : C = C / a : d = d / a
        d = d + b * C / 3 - 2 * b * b * b / 27
        C = C - b * b / 3
        p = Math.Sqrt(Math.Abs((12 * C * C * C + 81 * d * d))) 'revise if negative
        k = (108 * d + 12 * p) ^ (1 / 3)
        X = k / 6 - 2 * C / k - b / 3
        Return ndis(-X)
    End Function


    Sub DemoFisher_kappa_X_2()
        Dim LeftTail As Double, RightTail As Double, r As Double
        Dim n As Integer, rho As Double, result As Double
        Dim lefttail1 As Double ', RightTail1 As Double
        'mp4.setdps(40)

        'An example, where E fails in double precision, producing a negative value
        '  n = 44
        '  rho = 0.9999999714
        '  LeftTail = 5E-10
        '  RightTail = 1 - LeftTail

        'An example, where F fails in double precision, producing a 1E+20 relative error
        '  n = 14
        '  rho = 0.9999999714
        '  LeftTail = 5E-20
        '  RightTail = 1 - LeftTail

        n = 28
        rho = 0.99
        LeftTail = 0.0005
        RightTail = 1 - LeftTail


        '  Console.WriteLine( "----------------------")
        '  r = Fisher_simple_X_2(LeftTail, RightTail, n, rho)
        '  Console.WriteLine( "r_alpha: {0}, {1}", r, 1 - r)
        '  result = Fisher_simple_2(r, n, rho)
        '  Console.WriteLine("LeftTail S: {0} ", result)
        '  
        '  lefttail1 = RhoExplicit_2(n, r, rho)
        '  Console.WriteLine("LeftTail E: {0}", lefttail1)
        '
        '  
        '  Console.WriteLine( "----------------------")
        '  r = Fisher_kappa_X_2(LeftTail, RightTail, n, rho)
        '  Console.WriteLine( "r_alpha: {0}, {1}", r, 1 - r)
        '  result = Fisher_kappa_2(r, n, rho)
        '  Console.WriteLine("LeftTail F: {0}", result)
        '  
        '  lefttail1 = RhoExplicit_2(n, r, rho)
        '  Console.WriteLine("LeftTail E: {0}", lefttail1)


        Console.WriteLine("----------------------")
        r = Rhodisx_W_2(LeftTail, RightTail, n, rho)
        Console.WriteLine("r_alpha B: {0}, {1}", r, 1 - r)
        lefttail1 = Rhodis_B(n, r, rho)
        Console.WriteLine("LeftTail B: {0}", lefttail1)

        Dim r2 As Double = Rhodisx_W_2(lefttail1, 1 - lefttail1, n, rho)
        Dim lefttail2 As Double = Rhodis_B(n, r2, rho)
        Console.WriteLine("LeftTail2B: {0}", lefttail2)
        Dim p1, p2 As Double
        p1 = Math.Log(lefttail1) + Math.Log(lefttail2)
        p2 = Math.Exp(p1 / 2)
        Console.WriteLine("LeftTail2C: {0}", p2)


        lefttail1 = RhoExplicit_2(n, r, rho)
        Console.WriteLine("LeftTail E: {0}", lefttail1)


'        Dim LeftMpfr As New gpr_t
'        LeftMpfr = RhoExplicit_Mpfr(n, r, rho)
'        Console.WriteLine("LeftTail M: {0}", LeftMpfr)



'        Dim LeftArb As New apr_t
'        LeftArb = RhoExplicit_Arb(n, r, rho)
'        Console.WriteLine("LeftTailA: {0}", LeftArb)

        'Dim rs As String = r.ToString()
        'Dim rhos As String = rho.ToString()



        'LeftMpfr = RhoExplicit_Mpfr(n, rs, rhos)
        'Console.WriteLine("LeftTail M: {0}", LeftMpfr)




        'LeftArb = RhoExplicit_Arb(n, rs, rhos)
        'Console.WriteLine("LeftTailA: {0}", LeftArb)

        'result = Fisher_simple_2(r, n, rho)
        'Console.WriteLine("LeftTail S: {0} ", result)

        'result = Fisher_kappa_2(r, n, rho)
        'Console.WriteLine("LeftTail F: {0}", result)

    End Sub



    Sub DemoPearsonDoubleProcs()
        Console.WriteLine("In Pearson")
        DemoFisher_kappa_X_2()
        '    demordisn_nc_2()

    End Sub



End Module



