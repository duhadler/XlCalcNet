Imports System
Imports System.Numerics
Imports System.Diagnostics
'Imports mpFunLabNET



Module DistMain




    Sub LugannaniRice(w As Double, U As Double, k2 As Double, k3 As Double,
        k4 As Double, ByRef density As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim w1 As Double, U1 As Double, Adj1 As Double, Adj As Double
        w1 = 1 / w
        U1 = 1 / U
        k3 = k3 / (k2 * Math.Sqrt(k2))
        k4 = k4 / (k2 * k2)
        Adj1 = (0.125 * k4 - 5 * k3 * k3 / 24)
        Adj = U1 * Adj1 - (U1 * U1 * U1) - (0.5 * k3 * U1 * U1) + (w1 * w1 * w1)

        Call ndis2(False, w, LeftTail, RightTail, density)
        'Console.WriteLine("LeftTail0: {0}", LeftTail)
        Dim LeftTail1 = LeftTail + density * (w1 - U1)
        Dim Diff0 = LeftTail1 - LeftTail
        'Console.WriteLine("LeftTail1: {0}", LeftTail1)
        LeftTail = LeftTail + density * (w1 - U1 - Adj)
        'Console.WriteLine("LeftTail2: {0}", LeftTail)
        Dim Diff1 = LeftTail - LeftTail1

        'Console.WriteLine("Diff0: {0}", Diff0)
        'Console.WriteLine("Diff1: {0}", Diff1)

        'Console.WriteLine("w1^3: {0}", density * w1 * w1 * w1)

        RightTail = RightTail - density * (w1 - U1 - Adj)

        'Console.WriteLine("w1: {0}, u1: {1}", w1, U1)
        'Console.WriteLine("density * Adjustment1: {0}", density * (w1 - U1))
        'Console.WriteLine("density * Adjustment2: {0}", density * (-Adj))
        'density = density * S * U1 * v2 * (t2 * v2 + N2) * (1 - 2 * Adj1 / 3)

    End Sub



    Function JensenR(w As Double, U As Double) As Double
        JensenR = w + (1 / w) * Math.Log(U / w)
    End Function


    Sub Jensen(w As Double, U As Double)
        Dim r As Double, lefttail1 As Double, RightTail1 As Double, density1 As Double
        r = JensenR(w, U)
        Call ndis2(False, r, lefttail1, RightTail1, density1)
        Console.WriteLine("Lr_s: {0}, R: {1}", lefttail1, RightTail1)
    End Sub



    Sub SwapTails(ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim temp As Double
        temp = LeftTail
        LeftTail = RightTail
        RightTail = temp
    End Sub

    Function LogZPlusA(z As Double, a As Double) As Double
        ' LogZPlusA = log(z+a) - log(a) for a>>z
        Dim y As Double, S1 As Double, s2 As Double, s3 As Double, i As Double
        y = z / (2 * a + z)
        S1 = y : s2 = S1 : i = 1
        y = y * y
        Do
            i = i + 2
            s2 = s2 * y
            s3 = s2 / i
            S1 = S1 + s3
        Loop Until S1 = S1 + s3
        '  Debug.Print "Iterations:", (i - 1) / 2
        LogZPlusA = 2 * S1
    End Function

    Function LnGamma(z As Double) As Double
        Dim bb(0 To 10) As Double
        Dim ln2pi As Double, lnz As Double, a As Double, z3 As Double
        Dim z2 As Double, sum2 As Double, sum As Double
        Dim i As Integer
        bb(1) = -0.00277777777777778
        bb(2) = 0.000793650793650794
        bb(3) = -0.000595238095238095
        bb(4) = 0.000841750841750842
        bb(5) = -0.00191752691752692
        bb(6) = 0.00641025641025641
        bb(7) = -0.0295506535947712
        bb(8) = 0.179644372368831
        bb(9) = -1.3924322169059
        bb(10) = 13.4028640441684
        a = 1.0#
        While (z < 15.0#)
            a = a * z
            z = z + 1.0#
        End While


        lnz = (z - 0.5) * Math.Log(z)
        ln2pi = 0.918938533204673
        z2 = 1.0# / (1.0# * z * z)
        sum2 = 1.0# / (12.0# * z)
        i = 0
        z3 = 1.0# / z
        Do
            i = i + 1
            z3 = z3 * z2
            sum = sum2
            sum2 = sum + bb(i) * z3
        Loop Until ((sum2 = sum) Or (i > 9))
        sum2 = sum2 + lnz - z
        sum2 = sum2 + ln2pi
        LnGamma = sum2 - Math.Log(a)
    End Function

    Function LnGammaZPLusA(z As Double, a As Double) As Double
        Dim bb(0 To 10) As Double
        Dim lnz As Double
        'Dim a1 As Double, za1 As Double, aza1 As Double
        'Dim a2 As Double, za2 As Double, aza2 As Double
        Dim sum2 As Double, sum3 As Double, sum As Double, d1 As Double
        Dim i As Integer, j As Integer, k As Integer, n As Integer
        Dim C(0 To 30) As Double, d(0 To 30) As Double, e(0 To 30) As Double
        bb(1) = -0.00277777777777778
        bb(2) = 0.000793650793650794
        bb(3) = -0.000595238095238095
        bb(4) = 0.000841750841750842
        bb(5) = -0.00191752691752692
        bb(6) = 0.00641025641025641
        bb(7) = -0.0295506535947712
        bb(8) = 0.179644372368831
        bb(9) = -1.3924322169059
        bb(10) = 13.4028640441684
        d1 = LogZPlusA(z, a)
        lnz = (z + a - 0.5) * d1 + z * Math.Log(a) - z
        'a1 = a
        'za1 = z + a
        'aza1 = a * (z + a)
        'a2 = a1 * a1
        'za2 = za1 * za1
        'aza2 = aza1 * aza1
        'sum2 = -z / (12# * aza1)
        'i = 0
        'Do
        '  i = i + 1
        '  a1 = a1 * a2
        '  za1 = za1 * za2
        '  aza1 = aza1 * aza2
        '  sum = sum2
        '  sum3 = bb(i) * (a1 - za1) / aza1
        '  Debug.Print i, sum3
        '  sum2 = sum + sum3
        'Loop Until ((sum2 = sum) Or (i > 9))
        'Debug.Print "sum2, lnz:", sum2, lnz

        sum2 = -z / (12.0# * a * (z + a))
        i = 0 : n = 1 : C(0) = 1 : C(1) = 1
        d(0) = 1 : e(0) = 1
        d(1) = 1 / (z + a) : e(1) = z / (a * (z + a))
        Do
            i = i + 1
            For k = 1 To 2
                n = n + 1 : C(n) = 1
                For j = n - 1 To 1 Step -1
                    C(j) = C(j) + C(j - 1)
                Next j
                d(n) = d(n - 1) * d(1)
                e(n) = e(n - 1) * e(1)
            Next k
            sum3 = 0
            For j = 1 To n
                sum3 = sum3 + C(j) * d(n - j) * e(j)
            Next j
            sum3 = -bb(i) * sum3
            sum = sum2
            sum2 = sum2 + sum3
        Loop Until ((sum2 = sum) Or (i > 9))
        sum2 = sum2 + lnz
        LnGammaZPLusA = sum2
    End Function

    Function Lnbeta1(a As Double, b As Double) As Double
        Dim t As Double
        t = LnGamma(a)
        t = t + LnGamma(b)
        Lnbeta1 = t - LnGamma(a + b)
    End Function

    Function Lnbeta(a As Double, b As Double) As Double
        Dim l2 As Double
        '  L1 = Lnbeta1(a, b)
        l2 = LnBeta2(a, b)
        '  Debug.Print "a,b,1,2: ", a, b, L1, L2
        Lnbeta = l2
    End Function

    Function LnBeta2(a As Double, b As Double) As Double
        Dim t As Double
        If a > b Then Call SwapTails(a, b)
        If a < (b / 100) Then
            t = LnGamma(a) - LnGammaZPLusA(a, b)
        Else
            t = Lnbeta1(a, b)
        End If
        LnBeta2 = t
    End Function

    Function Bn0(n As Integer) As Double
        Dim ln2pi As Double
        ln2pi = 1.83787706640935
        Dim b1(0 To 15) As Double
        Dim lnk(0 To 2) As Double
        Dim S1 As Double, sign As Double, sum As Double
        Dim k As Integer
        '  If b1(0) = 0 Then
        b1(0) = 1.0#
        b1(1) = 0.166666666666667
        b1(2) = -0.0333333333333333
        b1(3) = 0.0238095238095238
        b1(4) = -0.0333333333333333
        b1(5) = 0.0757575757575758
        b1(6) = -0.253113553113553
        b1(7) = 1.16666666666667
        b1(8) = -7.0921568627451
        b1(9) = 54.9711779448622
        b1(10) = -529.124242424242
        b1(11) = 6192.1231884058
        b1(12) = -86580.2531135531
        b1(13) = 1425517.16666667
        b1(14) = -27298231.0678161
        b1(15) = 601580873.900642

        lnk(0) = 0.693147180559945
        lnk(1) = 1.09861228866811
        lnk(2) = 1.38629436111989
        '   End If
        If n = 1 Then
            Bn0 = -0.5
            Exit Function
        End If
        If ((n Mod 2) > 0) Then
            Bn0 = 0
            Exit Function
        End If
        If n <= 30 Then
            Bn0 = b1(n \ 2)
            Exit Function
        End If
        If (((n \ 2) Mod 2) > 0) Then
            sign = 1
        Else
            sign = -1
        End If
        sum = 1
        k = 0
        Do
            S1 = Math.Exp(-lnk(k) * n)
            sum = sum + S1
            k = k + 1
        Loop Until (S1 / sum) < 0.0000000000000001
        S1 = LnGamma(n + 1)
        S1 = S1 - n * ln2pi
        S1 = Math.Exp(S1) * sum
        Bn0 = 2 * sign * S1
    End Function

    Function Bernoulli(n As Integer, h As Double) As Double
        Dim hn As Double, Bin As Double, sum As Double
        Dim i As Integer, k As Integer
        If h = 0 Then
            Bernoulli = Bn0(n)
            Exit Function
        End If
        sum = 0
        Bin = 1
        hn = 1
        For i = 1 To n
            hn = hn * h
        Next i
        For k = 0 To n
            sum = sum + Bin * Bn0(k) * hn
            Bin = Bin / (k + 1) * (n - k)
            hn = hn / h
        Next k
        Bernoulli = sum
    End Function



    Function cdens(n As Double, X As Double) As Double
        Dim b As Double, m As Double, LastLngamma As Double
        b = n / 2.0
        m = X / 2.0
        If (X <= 0.0) Then
            cdens = 0.0
        Else
            LastLngamma = LnGamma(b)
            cdens = 0.5 * Math.Exp(Math.Log(m) * (b - 1.0) - LastLngamma - m)
        End If
    End Function



    Sub gamma_p_q(b As Double, M As Double, ByRef LeftTail As Double,
      ByRef RightTail As Double, ByRef density As Double)
        Dim j As Integer, i As Integer
        Dim sum(0 To 2) As Double
        Dim eps As Double, k As Double
        Dim xsum As Double, a0 As Double, A1 As Double, A2 As Double
        Dim an As Double, b0 As Double, b1 As Double, b2 As Double, bn As Double
        Dim MinRelError As Double
        Dim c3 As Boolean
        MinRelError = 0.0000000000000001
        If (M <= 0.0) Then
            LeftTail = 0.0
            RightTail = 1.0
            density = 0.0
            Exit Sub
        End If
        'density = cdens(n, X)
        density = cdens(2 * b, 2 * M)
        'If ((X <= 12.0) Or (X <= n)) Then
        If (M <= b - 0.5) Then
            c3 = True  ' LeftTail probability
        Else
            c3 = False  ' RightTail probability
        End If
        'b = n / 2.0
        'm = X / 2.0
        k = 2.0 * density
        a0 = 1.0
        b0 = 1.0
        bn = 0.0
        j = 0
        sum(0) = 1.0
        sum(1) = 1.0
        If c3 Then
            k = k * M / b
            A1 = b + 1.0 - M
            b1 = b + 1.0
            bn = b + 1.0
        Else
            A1 = M + 1.0 - b
            b1 = M
        End If
        Do
            j = j + 1
            For i = 0 To 1
                If c3 Then
                    If i = 1 Then
                        an = -(b + j) * M
                    Else
                        an = j * M
                    End If
                    bn = bn + 1.0#
                Else
                    If i = 1 Then
                        an = j + 1.0 - b
                        bn = M
                    Else
                        an = j
                        bn = 1.0
                    End If
                End If
                A2 = bn * A1 + an * a0
                b2 = bn * b1 + an * b0
                A2 = A2 / b2
                A1 = A1 / b2
                b1 = b1 / b2
                b2 = 1.0
                a0 = A1
                A1 = A2
                b0 = b1
                b1 = b2
                sum(i) = A2
            Next i
            xsum = (sum(0) + sum(1)) * 0.5
            eps = (sum(0) - sum(1)) / xsum
        Loop Until (Math.Abs(eps) < MinRelError)
        k = k / xsum
        LeftTail = 1.0 - k
        RightTail = k
        If c3 Then
            Call SwapTails(LeftTail, RightTail)
        End If
    End Sub

    Sub cdis2(n As Double, X As Double, ByRef LeftTail As Double, ByRef RightTail As Double, ByRef density As Double)
        Dim j As Integer, i As Integer
        Dim sum(0 To 2) As Double
        Dim eps As Double, m As Double, b As Double, k As Double
        Dim xsum As Double, a0 As Double, A1 As Double, A2 As Double
        Dim an As Double, b0 As Double, b1 As Double, b2 As Double, bn As Double
        Dim MinRelError As Double
        Dim c3 As Boolean
        MinRelError = 0.0000000000000001
        If (X <= 0.0) Then
            LeftTail = 0.0
            RightTail = 1.0
            density = 0.0
            Exit Sub
        End If
        density = cdens(n, X)
        'If ((X <= 12.0) Or (X <= n)) Then
        If (X <= n - 1) Then
            c3 = True  ' LeftTail probability
        Else
            c3 = False  ' RightTail probability
        End If
        b = n / 2.0
        m = X / 2.0
        k = 2.0 * density
        a0 = 1.0
        b0 = 1.0
        bn = 0.0
        j = 0
        sum(0) = 1.0
        sum(1) = 1.0
        If c3 Then
            k = k * m / b
            A1 = b + 1.0 - m
            b1 = b + 1.0
            bn = b + 1.0
        Else
            A1 = m + 1.0 - b
            b1 = m
        End If
        Do
            j = j + 1
            For i = 0 To 1
                If c3 Then
                    If i = 1 Then
                        an = -(b + j) * m
                    Else
                        an = j * m
                    End If
                    bn = bn + 1.0#
                Else
                    If i = 1 Then
                        an = j + 1.0 - b
                        bn = m
                    Else
                        an = j
                        bn = 1.0
                    End If
                End If
                A2 = bn * A1 + an * a0
                b2 = bn * b1 + an * b0
                A2 = A2 / b2
                A1 = A1 / b2
                b1 = b1 / b2
                b2 = 1.0
                a0 = A1
                A1 = A2
                b0 = b1
                b1 = b2
                sum(i) = A2
            Next i
            xsum = (sum(0) + sum(1)) * 0.5
            eps = (sum(0) - sum(1)) / xsum
        Loop Until (Math.Abs(eps) < MinRelError)
        k = k / xsum
        LeftTail = 1.0 - k
        RightTail = k
        If c3 Then
            Call SwapTails(LeftTail, RightTail)
        End If
    End Sub



    Function cdis(n As Double, X As Double) As Double
        Dim LeftTail As Double, RightTail As Double, density As Double
        Call cdis2(n, X, LeftTail, RightTail, density)
        cdis = LeftTail
    End Function





    Sub betadis_(a As Double, b As Double, Q As Double, p As Double, ByRef LeftTail As Double, ByRef RightTail As Double, ByRef density As Double)
        'Dim fit As Boolean
        Dim j As Integer, i As Integer
        Dim sum(0 To 1) As Double
        Dim eps As Double, qp As Double, k As Double
        Dim xsum As Double
        Dim a0 As Double, A1 As Double, A2 As Double, an As Double
        Dim b0 As Double, b1 As Double, b2 As Double, bn As Double
        'Dim X As Double, limit As Double
        Dim MinRelError As Double
        MinRelError = 0.00000000000001
        If (Q <= 0) Then
            LeftTail = 0
            RightTail = 1
            density = 0
            Exit Sub
        End If
        If (p <= 0) Then
            LeftTail = 1
            RightTail = 0
            density = 0
            Exit Sub
        End If
        '  k = LnGamma(a + b) - LnGamma(a) - LnGamma(b)
        k = -Lnbeta(a, b)
        k = k + (b - 1) * Math.Log(p) + (a - 1) * Math.Log(Q)
        density = Math.Exp(k)
        'X = (b * Q) / (a * p)
        'limit = 4.5 - a
        'If limit < 1 Then
        '    limit = 1
        'End If
        'fit = (X < limit)
        'If Not fit Then
        '    Call SwapTails(a, b)
        '    Call SwapTails(p, Q)
        'End If
        qp = Q / p
        a0 = 1
        A1 = a + 1 - (b - 1) * qp
        b0 = 1
        b1 = a + 1
        j = 0
        bn = a + 1
        sum(0) = 1
        sum(1) = 1
        Do
            j = j + 1
            For i = 0 To 1
                If i = 1 Then
                    an = -(a + j) * (b - j - 1) * qp
                Else
                    an = j * (a + b - 1 + j) * qp
                End If
                bn = bn + 1
                A2 = bn * A1 + an * a0
                b2 = bn * b1 + an * b0
                A2 = A2 / b2
                A1 = A1 / b2
                b1 = b1 / b2
                b2 = 1
                a0 = A1
                A1 = A2
                b0 = b1
                b1 = b2
                sum(i) = A2
            Next i
            xsum = (sum(0) + sum(1)) * 0.5
            eps = Math.Abs(sum(0) - sum(1)) / xsum
        Loop Until (eps < MinRelError)
        'RightTail = density * Q / (a * xsum)
        'LeftTail = 1 - RightTail

        LeftTail = density * Q / (a * xsum)
        RightTail = 1 - LeftTail


        'If fit Then
        'Call SwapTails(LeftTail, RightTail)
        'End If
    End Sub


    Sub betadis(a As Double, b As Double, q As Double, p As Double, ByRef L As Double, ByRef R As Double, ByRef density As Double)
        Dim NeedToConvert As Boolean, Temp As Double
        NeedToConvert = Not ((b - 0.5) <= (a + b - 1) * p)
        Console.WriteLine("NeedToConvert: {0}", NeedToConvert)
        If NeedToConvert Then
            Temp = a : a = b : b = Temp
            Temp = q : q = p : p = Temp
        End If
        betadis_(a, b, q, p, L, R, density)
        If NeedToConvert Then
            Temp = L : L = R : R = Temp
        End If
    End Sub



    Function Fdis(m As Double, n As Double, a As Double) As Double
        Dim X As Double, y As Double, p As Double, Q As Double
        Dim density As Double, LeftTail As Double, RightTail As Double
        If a <= 0 Then
            Fdis = 0
            Exit Function
        End If
        X = m * a / (m * a + n)
        y = n / (m * a + n)
        p = m / 2
        Q = n / 2
        Call betadis(p, Q, X, y, LeftTail, RightTail, density)
        Fdis = RightTail
    End Function

    Sub Fdis_a(m As Double, n As Double, a As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim X As Double, y As Double, p As Double, Q As Double
        Dim density As Double
        If a <= 0 Then
            LeftTail = 0
            RightTail = 1
            Exit Sub
        End If
        X = m * a / (m * a + n)
        y = n / (m * a + n)
        p = m / 2
        Q = n / 2
        Call betadis(p, Q, X, y, LeftTail, RightTail, density)
    End Sub



    Function tdis(n As Double, t As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Dim temp As Double
        If t = 0 Then
            LeftTail = 0.5
            RightTail = 0.5
            tdis = 0.5
            Exit Function
        End If
        Call Fdis_a(1, n, t * t, LeftTail, RightTail)
        RightTail = RightTail / 2
        LeftTail = 1 - RightTail
        'Debug.Print LeftTail, RightTail
        If t < 0 Then
            temp = LeftTail
            LeftTail = RightTail
            RightTail = temp
        End If
        tdis = LeftTail
    End Function



    Function ndens(X As Double) As Double
        Return 0.398942280401433 * Math.Exp(-X * X / 2)
    End Function


    Sub ndis2(UseLog As Boolean, X As Double, ByRef LeftTail As Double, ByRef RightTail As Double, ByRef density As Double)
        Dim sqrt2pi As Double
        sqrt2pi = 0.398942280401433
        Dim i As Double, m As Double, x2 As Double, S1 As Double, s2 As Double
        Dim t As Double, A1 As Double, A2 As Double, b1 As Double, b2 As Double
        Dim sign As Boolean
        If X = 0 Then
            LeftTail = 0.5
            density = sqrt2pi
            If UseLog Then
                LeftTail = Math.Log(LeftTail)
                density = Math.Log(density)
            End If
            RightTail = LeftTail : Exit Sub
        End If
        sign = False : x2 = X * X
        density = Math.Exp(-x2 * 0.5) * sqrt2pi

        If X < 0 Then X = -X : sign = True
        If X < 2.5 Then
            S1 = X : s2 = X : m = 1
            Do : m = m + 2
                s2 = s2 * x2 / m
                S1 = S1 + s2
            Loop Until (s2 < S1 * 0.0000000000000001)
            LeftTail = 0.5 + S1 * density
            If UseLog Then
                RightTail = Math.Log(1 - LeftTail)
                LeftTail = Math.Log(LeftTail)
            Else
                RightTail = 1 - LeftTail
            End If
        Else
            A1 = 1 : A2 = X : b1 = X : b2 = x2 + 1 : i = 1
            Do : i = i + 1
                t = A2 : A2 = X * A2 + i * A1 : A1 = t
                t = b2 : b2 = X * b2 + i * b1 : b1 = t
            Loop Until (A2 * b1 = b2 * A1)
            If UseLog Then
                RightTail = (-x2 / 2) + Math.Log(sqrt2pi * A2 / b2)
                LeftTail = LogZPlusA(-Math.Exp(RightTail), 1)
            Else
                RightTail = density * A2 / b2
                LeftTail = 1 - RightTail
            End If
        End If
        If sign Then Call SwapTails(LeftTail, RightTail)
        If UseLog Then density = (-x2 * 0.5) + Math.Log(sqrt2pi)
    End Sub

    Public Function ndis(X As Double) As Double
        Dim LeftTail As Double, RightTail As Double, density As Double
        Call ndis2(False, X, LeftTail, RightTail, density)
        Return LeftTail
    End Function




    Function tdens(n As Double, X As Double) As Double
        Dim C As Double, h As Double
        C = (1 + X * X / n)
        h = Math.Exp(LnGamma((n + 1) / 2) - LnGamma(n / 2)) / Math.Sqrt(Math.PI) / Math.Sqrt(n)
        tdens = h * C ^ (-(n / 2 + 1 / 2))
    End Function



    Function cdisOwen(n As Long, X As Double) As Double
        Dim C As Double, F As Double, k As Long, i As Long
        C = -Math.Exp(-X / 2)
        F = 1
        k = n Mod 2
        If k <> 0 Then
            C = C * Math.Sqrt(2 * X / Math.PI)    ' C=ndens(x)
            F = 1 - 2 * ndis(-Math.Sqrt(X))
        End If
        k = k + 2
        For i = k To n Step 2
            F = F + C
            C = C * X / i
        Next i
        cdisOwen = F
    End Function


    Function tdisOwen(X As Double, n As Long) As Double
        Dim a As Double, b As Double, C As Double, F As Double, k As Long, i As Long
        a = X / Math.Sqrt(n)
        b = 1 + a * a
        k = n Mod 2
        If k <> 0 Then
            C = a / (b * Math.PI)
            F = 0.5 + Math.Atan(a) / Math.PI
        Else
            C = a / (2 * Math.Sqrt(b))
            F = 0.5
        End If
        k = k + 2
        For i = k To n Step 2
            F = F + C
            C = C * (1 - 1 / i) / b
        Next i
        tdisOwen = F
    End Function


    '    Function FdisOwen(ByVal m As Long, ByVal n As Double, ByVal X As Double) As Double
    Function FdisOwen(m As Long, n As Long, X As Double) As Double
        Dim U As Double, sum As Double, a As Double, z As Double
        Dim result As Double, i As Long, k As Long
        k = m Mod 2
        If k = 0 Then
            z = n / (n + m * X)
            result = z ^ (n / 2)
            If m > 2 Then
                U = 1 - z
                sum = 1 : a = 1
                For i = 1 To (m - 2) \ 2
                    a = a * U * (2 * i + n - 2) / (2 * i)
                    sum = sum + a
                Next i
                result = result * sum
            End If
        Else
            z = Math.Sqrt(m * X)
            '      result = 2 * tdis(n, -z, L, r)
            result = 2 * tdisOwen(-z, n)
            If m > 1 Then
                U = z * z / (z * z + n)
                sum = z : a = z
                For i = 2 To (m - 1) \ 2
                    a = a * U * (2 * i + n - 3) / (2 * i - 1)
                    sum = sum + a
                Next i
                result = result + 2 * sum * tdens(n, z)
            End If
        End If
        FdisOwen = result
    End Function





    Sub BetaDisdemo()
        Dim a As Double, b As Double, q As Double, p As Double, L As Double, R As Double, density As Double, x As Double
        'Dim NeedToConvert As Boolean, Temp As Double
        x = 0.48
        a = 1124.1
        b = 1114.1
        q = x
        p = 1 - x
        betadis(a, b, q, p, L, R, density)
        Console.WriteLine("L: " & L.ToString() & "   R: " & R.ToString() & "   density: " & density.ToString())
    End Sub


    Sub demoLnGamma()
        Dim a As Double, b As Double
        Dim lnG As Double, lnB As Double
        a = 1000000000
        b = 1000000000
        lnG = LnGamma(a)
        lnB = Lnbeta(a, b)
        Console.WriteLine("lnG: " & lnG.ToString() & "   lnB: " & lnB.ToString())
    End Sub



    Sub DemoCdis()
        Dim n As Double, X As Double
        Dim LeftTail As Double, RightTail As Double, density As Double
        n = 13300.1
        X = 13300.95
        Call cdis2(n, X, LeftTail, RightTail, density)
        Console.WriteLine("LeftTail: " & LeftTail.ToString() & "   RightTail: " & RightTail.ToString() & "   density: " & density.ToString())

    End Sub



    Sub Demo_gamma_p()
        Console.WriteLine("Hello DemoGammaP")
        Dim a As Double, x As Double
        Dim LeftTail As Double, RightTail As Double, density As Double
        a = 1123.1
        x = 134.1
        Call gamma_p_q(a, x, LeftTail, RightTail, density)
        Console.WriteLine("LeftTail: " & LeftTail.ToString() & "   RightTail: " & RightTail.ToString() & "   density: " & density.ToString())

    End Sub







'    Sub apr_Kendall_Cumulants_Raw(Order As Integer, n As Integer, kappa As apr_mat_t)
'        Dim nl As Int32
'        kappa.resize(Order + 1, 1)
'        Call KendallCumArb(n, Order, kappa, nl)  'Kendall  
'        Console.WriteLine("nl: {0}", nl)
'
'        Dim i As Int32 = 0
'        Dim d As apr_t = 1
'        For i = 1 To Order
'            d = 2 * d
'            'Dim adj = d * apr.bernoulli_ui(i) / i
'            Dim adj = 0
'            If (i = 1) Or (i Mod 2 = 0) Then
'                'Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
'            End If
'            'If (i > 0) Then kappa(i) = kappa(i) - adj
'            If (i > 0) Then kappa(i) = kappa(i) / (2 ^ 0)
'            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
'        Next i
'
'
'        Dim mean = kappa(1)
'        Dim sigma = apr.sqrt(kappa(2))
'        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
'    End Sub
'
'
'    Function Kendall_Get_Saddlepoint_By_Cumulants(x As apr_t, Order As Int32, kappa As apr_mat_t) As apr_t
'        Dim s = (x - kappa(1)) / kappa(2)
'        Dim RelErr = apr.t("1")
'        Do
'            'Console.WriteLine("s1: {0}", s)
'            Dim deriv = 1
'            Dim fx = x - apr_Kendall_CGF_By_Cumulants(1, Order, s, kappa)
'            RelErr = apr.abs((fx) / x)
'            'Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
'            'Console.WriteLine("fx: {0}", fx)
'            Dim dfx = apr_Kendall_CGF_By_Cumulants(2, Order, s, kappa)
'            'Console.WriteLine("dfx: {0}", dfx)
'            Dim adj = fx / dfx
'            'Console.WriteLine("adj: {0}", adj)
'            s = s + adj
'        Loop Until (RelErr < apr.get_tol())
'        Return s
'    End Function
'
'
'
'
'
'    Function apr_Kendall_CGF_By_Cumulants(deriv As Integer, Order As Integer, s As apr_t, kappa As apr_mat_t) As apr_t
'        Dim s1 = apr.t("1")
'        Dim sum = apr.t("0")
'        If deriv > 0 Then
'            sum = kappa(deriv)
'        End If
'        Dim count As Int32
'        Dim RelErr = apr.t("1")
'        For i = 1 To Order - deriv
'            count = count + 1
'            s1 = s1 * s
'            Dim k = kappa(i + deriv)
'            Dim summand = k * s1 / apr.gamma(i + 1)
'            sum = sum + summand
'            If (i = 1) Or ((i + deriv) Mod 2 = 0) Then
'                'Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
'            End If
'            If (((i + deriv) Mod 2) = 0) Then
'                RelErr = apr.abs(summand / sum)
'                'Console.WriteLine("RelErr: {0}", RelErr)
'                If RelErr < apr.get_tol() Then Exit For
'            End If
'        Next i
'        'Console.WriteLine("count: {0}", count)
'        'Console.WriteLine("result1: {0}", sum)
'        Return sum
'    End Function



'    Sub Demo_Kendall_Saddlepoint_By_Cumulants()
'        mp4.setdps(140)
'        Dim kappa As New apr_mat_t
'        Dim Order = 464 '128 '96 '64 '32      ' multiple of 4
'        Dim n = 80
'        Dim x = apr.t("1578")
'
'        apr_Kendall_Cumulants(Order, n, kappa)
'        Dim s = (x - kappa(1)) / kappa(2)
'        Dim RelErr = apr.t("1")
'        Do
'            'Console.WriteLine("")
'            Console.WriteLine("s1: {0}", s)
'            Dim deriv = 1
'            Dim fx = x - apr_Kendall_CGF_By_Cumulants(1, Order, s, kappa)
'            RelErr = apr.abs((fx) / x)
'            Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
'            'Console.WriteLine("fx: {0}", fx)
'            Dim dfx = apr_Kendall_CGF_By_Cumulants(2, Order, s, kappa)
'            'Console.WriteLine("dfx: {0}", dfx)
'            Dim adj = fx / dfx
'            'Console.WriteLine("adj: {0}", adj)
'            s = s + adj
'        Loop Until (RelErr < apr.get_tol())
'    End Sub
'
'
'
'    Sub apr_Kendall_Cumulants(Order As Integer, n As Integer, kappa As apr_mat_t)
'        Dim nl As Int32
'        kappa.resize(Order + 1, 1)
'        Call KendallCumArb(n, Order, kappa, nl)  'Kendall  
'        Console.WriteLine("nl: {0}", nl)
'
'        Dim i As Int32 = 0
'        Dim d As apr_t = 1
'        For i = 1 To Order
'            d = 2 * d
'            Dim adj = d * apr.bernoulli_ui(i) / i
'            If (i = 1) Or (i Mod 2 = 0) Then
'                'Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
'            End If
'            If (i > 0) Then kappa(i) = kappa(i) - adj
'            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
'        Next i
'
'
'        Dim mean = kappa(1)
'        Dim sigma = apr.sqrt(kappa(2))
'        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
'    End Sub
'
'
'
'
'    Sub Demo_Kendall_CDF_SPA()
'        mp4.setdps(40)
'        Dim kappa As New apr_mat_t
'        Dim Order = 864 '128 '96 '64 '32      ' multiple of 4
'        Dim n = 80
'        Dim x = apr.t("1278")
'        'Dim x = apr.t("1606")
'        'Dim x = apr.t("40")
'
'        Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2)
'
'        apr_Kendall_Cumulants(Order, n, kappa)
'        Dim s = Kendall_Get_Saddlepoint_By_Cumulants(x, Order, kappa)
'        Console.WriteLine("s: {0}", s)
'
'        Dim K_Order As Int32 = 18
'        Dim K(K_Order + 1) As apr_t
'        For j = 0 To K_Order
'            K(j) = apr_Kendall_CGF_By_Cumulants(j, Order, s, kappa)
'            Console.WriteLine("j: {0}, K(s): {1}", j, K(j))
'        Next
'
'        Console.WriteLine("")
'        Dim density, LeftTail, Righttail As New apr_t
'        apr_LugannaniRiceNew(K_Order, K, s, density, LeftTail, Righttail)
'
'    End Sub
'
'
'
'    Sub Demo_Kendall_CGF_By_Cumulants()
'        mp4.setdps(240)
'        Dim kappa As New apr_mat_t
'        Dim Order = 464 '128 '96 '64 '32      ' multiple of 4
'        Dim n = 80
'        Dim x = apr.t("622")
'        Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2)
'
'        'apr_Kendall_Cumulants(Order, n, kappa)
'        apr_Kendall_Cumulants_Raw(Order, n, kappa)
'        Dim s = (x - kappa(1)) / kappa(2)
'        s = 0.01
'        Dim limit = apr.const_pi() / n
'        Console.WriteLine("limit: {0}", limit)
'        Console.WriteLine("s: {0}", s)
'        Console.WriteLine("Kappa(1): {0}", kappa(1))
'        Console.WriteLine("Kappa(2): {0}", kappa(2))
'
'        Dim RelErr = apr.t("1")
'
'        'Dim k1 = apr_Kendall_CGF_By_Cumulants(1, Order, 0, kappa)
'        'Console.WriteLine("k1: {0}", k1)
'
'        Dim fx_new = apr_Kendall_CGF_By_Cumulants(0, Order, s, kappa)
'        Console.WriteLine("fx1: {0}", fx_new)
'
'
'    End Sub





    Sub DemoMCP()
        'DemoModulus()
        'DemoDunnett()
        'DemoRange()
        demoMCP2()
        'DemoMCP3()

    End Sub


    Sub DemoMultivariate()

        ' TEST BASED ON BETAPROD
        'NewTestWilksU()
        'NewTestR0KSetsDis()
        'NewTestR0DisX()
        'NewTestMauchly()
        'NewTestLvcDisX()
        'NewTestLvcmDisX()
        'NewTestEqualCovarianceMatricesSameSampleSize()


        ' TESTS BASED ON BOX-DAVIS
        'Lvc0demo()
        'Lvcmdemo()
        'Bartlettdemo()
        'NewBartlett_BoxDavis()

        'EqualDistributions_Anderson()
        'NewEqualDistributions_Anderson()

        'EqualDistributions_Perlman()
        NewEqualDistributions_Perlman()


        'DemoUdisx()
        'Udisdemo()

        'NewTestWilksUArb()


        'RoyDemo()
        'RoyDemoAnderson()

        'DemoGLMPower()

        'DemoOmega_V()
        'DemoOmega_T()
        'DemoCalcHotellingArb()
        'DemoCalcPillaiArb()

        'CornishEdgeworthDemo()




        'Console.WriteLine("Hello EqualDistributions")
        'EqualDistributions()


        'NewBartlett()
        'Console.WriteLine("")
        'Console.WriteLine("Hello Bartlettdemo")
        'Bartlettdemo()



        ''Test for R0
        'DemoTestR0()

        'Console.WriteLine("")
        'Console.WriteLine("Hello DemoTestR0KSets")
        'DemoTestR0KSets()

        'Console.WriteLine("")
        'Console.WriteLine("Hello Udis2demo")
        'Udis2demo()

        'DemoTestGeneralKSets()
        'Udis3demo()

        'DemoTestMauchley()
        'Console.WriteLine("")
        'Console.WriteLine("Hello Mauchlydemo")
        'Mauchlydemo()



        'Lvcdemo()
        'Lvcmdemo()

        'DemoTestBartlett()
        'Console.WriteLine("")
        'Console.WriteLine("Hello Bartlettdemo")
        'Bartlettdemo()


        'UdisdemoArb()
    End Sub


Sub DemoDistMain()
        'DemoMCP()
        'DemoNoncentral()

        'mp4.setdps(15)
        'mp4.setdps(30)

        DemoMultivariate()


        'DE_Int_Main()




        'apr_DemoNoncentral()

        'BetaDisdemo()
        'Demo_arb_ibeta()
        'demoNemes()
        'DemoCdis()
        'Demo_gamma_p()
        'DemoGamma_Arb_p()

        'DemoMCPArb()

        '        TestHypergeometric1F1Matrix()
        '        TestHypergeometric2F1Matrix()
        'DemoGLMPower()



        'demoParis()

        'demoNdisxArb()
        'demoCdisxArb()
        'demoFdisxArb()
        'demoTdisxArb()
        'demoBetadisxArb()


        'Demo_ibeta()
        'Demo_ibetac()

        'DemoGamma_p()
        'DemoGamma_q()

        '        Demo_Wilcoxon_CGF_By_Cumulants()
        '        Demo_Wilcoxon_CDF_SPA()
        'Demo_Wilcoxon_CDF_SPA_By_Cumulants()

        '        Demo_Kendall_CGF_By_Cumulants()
        '        Demo_Kendall_CDF_SPA()



        'Demo_MannWhitney_CDF_SPA_By_Cumulants()
        'Demo_MannWhitney_CDF_SPA()


        'Demo_MannWhitney_Saddlepoint_By_CGF()
        'Demo_MannWhitney_Saddlepoint_By_Cumulants()

        '        Demo_MannWhitney_CGF()
        'Demo_MannWhitney_CGF_By_Cumulants()
        'MannWhitneyInversCornishDemoArb()
        'TerpstaCornishDemoArb()
        'MannWhitneyCornishDemoArb()
        'KendallCornishDemoArb()

        'Demo_Kendall_Saddlepoint_By_Cumulants()
        'Demo_Saddlepoint_By_Cumulants()
        'CornishEdgeworthDemoArb()
        'DemoKendallCalcArb()

        'apr_DemoNoncentral()


        'DemoShanks()
        'KendallInversCornishEdgeworthDemo()

        'DemoUdisx()

        'Udisdemo()

        'DemoUdisx()

        'Demo_g_betaproduct_GL()
        'Demo_g_chisquared_GL()
        'DemoNoncentral()
        'TestNonCentralChi2()
        'DemoAcbIntegrationChiSquare()
        'DemoAcbIntegrationGammaStar()
        'DemoNoncentralCDF()


        'demo_ibeta_invArb()
        'demo_ibetac_invArb()
        'demoGamma_p_invArb()
        'demoGamma_q_invArb()

        'demo_ibeta_inv()
        'demo_ibetac_inv()
        'demoGamma_q_inv()
        'demoGamma_p_inv()
        'demoNdisx()
        'demoCdisx()
        'demoFdisx()
        'demoTdisx()
        'demoBetadisx()

        'DemoQuantileR2()
        'DemoNoncentralityR2()
        'DemoSampleSizeR2()

        'demo_tdisn_samplesize()
        'demo_samplesize_rho()
        'DemoRhoExplicit()
        'DemoQuantileNoncentralChisquare()
        'Demo_ChiSquare_Lambda()
        'demo_tdisn_delta()
        'demo_tdisnx()
        'DemoMarcumQ()
        'DemoDoublyTdisn()
        'DemoDoublyFdisn()

        'DemoNoncentralCDF()
        'DemoNoncentralPdf()
        'DemoDistFromBoost()
        'DemoMCPArb()
        'DemoMilton()
        'Kruskaldemo2()
        'DemoFriedman()
        'demoMCP2()

        'DemoArbInt()
        'DemoMpfrSolverBoost()
        'DemoDblSolverBoost()

        '        DemoMCP()

        '        DemondisxArb()

        '        KendallInversCornishEdgeworthDemo()

        'KendallCornishDemoArb()
        'WilcoxonCornishDemoArb()
        'MannWhitneyCornishDemoArb()
        'PageCornishDemoArb()
        'TerpstaCornishDemoArb()

        'KendallInversCornishDemoArb()
        'WilcoxonInversCornishDemoArb()
        'MannWhitneyInversCornishDemoArb()        
        'PageInversCornishDemoArb()
        'TerpstaInversCornishDemoArb2()

        '        InversCornishEdgeworthDemo()
        '        ListNullCDFbyCumDemo()
        '        DemoNoncentral()


        'DemoPageCalcArb()
        'DemoQuadePageCalcArb()
        'DemoWilcoxonCalcArb()

        'DemoSignCalcArb()
        'WilcoxonCornishDemoArb()
        'DemoTerpstaCalcArb()
        'DemoMannWhitneyCalcArb()


    End Sub


End Module

