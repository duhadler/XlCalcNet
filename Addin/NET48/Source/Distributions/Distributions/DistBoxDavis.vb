Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet


Module DistBoxDavis



    Sub BoxFApprox(result As String, f1 As Double, ByRef m As Double, omeg1 As Double, omeg2 As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim f2 As Double, A1 As Double, A2 As Double, C As Double, b As Double, x As Double
        A1 = 2 * omeg1 / f1 : A2 = 4 * omeg2 / f1
        C = A2 - A1 * A1
        x = 1
        If C > 0 Then
            f2 = (f1 + 2) / C : b = f1 / (1 - A1 - f1 / f2)
            If result = "PValue" Then x = m / b
        Else
            f2 = -(f1 + 2) / C : b = f2 / (1 - A1 + 2.0# / f2)
            If result = "PValue" Then x = f2 * m / (f1 * (b - m))
        End If
        If result = "PValue" Then
            '    LeftTail = Fdisn(f1, f2, x, 0, l1, r1)
            '    RightTail = 1 - LeftTail
            LeftTail = Fdisn2(f1, f2, x, 0, LeftTail, RightTail)
        Else
            x = Fdisx(f1, f2, LeftTail, RightTail)
            If C > 0 Then m = x * b Else m = b / (f2 / (f1 * x) + 1)
        End If
    End Sub


    Sub DavisPercentile(f As Double, ByRef x As Double, LeftTail As Double, RightTail As Double, rho As Double, o() As Double)
        Dim p1 As Double, p2 As Double, p3 As Double, p4 As Double, P5 As Double, p6 As Double, P7 As Double, P22 As Double, P32 As Double, P42 As Double, P33 As Double, P222 As Double, P52 As Double, P43 As Double, P322 As Double,
            f2 As Double, f3 As Double, f4 As Double, f5 As Double, f6 As Double, f7 As Double,
            f12 As Double, f13 As Double, f22 As Double,
            S1 As Double, u As Double, u2 As Double, u3 As Double, u4 As Double, u5 As Double, u6 As Double, u7 As Double,
            sum As Double, s(7) As Double, i As Integer, show As Boolean
        show = True
        Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail)
        u = cdisx(LeftTail, RightTail, f)
        Console.WriteLine("u: {0}", u)
        f2 = f * (f + 2) : f3 = f2 * (f + 4) : f4 = f3 * (f + 6) : f5 = f4 * (f + 8)
        f6 = f5 * (f + 10)
        f7 = f6 * (f + 12) : f12 = f * f : f13 = f12 * f : f22 = f2 * f2
        u2 = u * u : u3 = u * u2 : u4 = u * u3 : u5 = u * u4 : u6 = u * u5 : u7 = u * u6
        S1 = u2 * (3 * f + 4 * 2 - 2) / (f2 * f2) _
           + u3 * (3 * f + 4 * 3 - 2) / (f2 * f3) _
           + u4 * (3 * f + 4 * 4 - 2) / (f2 * f4) _
           + u5 * (3 * f + 4 * 5 - 2) / (f2 * f5)
        p1 = u / f
        p2 = p1 + u2 / f2
        p3 = p2 + u3 / f3
        p4 = p3 + u4 / f4
        P5 = p4 + u5 / f5
        p6 = P5 + u6 / f6
        P7 = p6 + u7 / f7
        P22 = -8 * u4 * (f + 3) / (f2 * f4) + 8 * u3 / (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12
        P32 = -12 * u5 * (f + 4) / (f2 * f5) - 2 * u4 * (f - 6) / (f2 * f4) + 2 * u3 * (3 * f + 10) / (f2 * f3) _
                 + 6 * u2 / (f * f2) + 2 * u / f12
        P42 = -16 * u6 * (f + 5) / (f2 * f6) - 4 * u5 * (f - 4) / (f2 * f5) + 2 * u4 * (3 * f + 14) / (f2 * f4) _
                 + 2 * u3 * (3 * f + 10) / (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12
        P33 = -6 * u6 * (3 * f12 + 30 * f + 80) / (f3 * f6) - 6 * u5 * (f2 + 2 * f - 16) / (f3 * f5) + 4 * u4 * (f + 12) / (f2 * f4) _
                 + 4 * u3 * (3 * f + 8) / (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12
        P222 = 32 * u6 * (7 * f12 + 62 * f + 120) / (f22 * f6) - 32 * u5 * (2 * f12 + 37 * f + 96) / (f22 * f5) - 8 * u4 _
                 * (23 * f12 + 124 * f + 132) / (f22 * f4) - 8 * u3 * (f - 10) /
                 (f * f2 * f3) + 28 * u2 / (f12 * f2) + 4 * u / f13
        P52 = -20 * u7 * (f + 6) / (f2 * f7) - 2 * u6 * (3 * f - 10) / (f2 * f6) + S1 + 2 * u / f12
        P43 = -24 * u7 * (f2 + 12 * f + 40) / (f3 * f7) - 2 * u6 * (5 * f2 + 18 * f - 80) / (f3 * f6) _
              + 2 * u5 * (f2 + 42 * f + 176) / (f3 * f5) + 4 * u4 * (3 * f + 16) / (f2 * f4) + 4 * u3 * (3 * f + 8) / (f2 * f3) _
              + 6 * u2 / (f * f2) + 2 * u / f12
        P322 = 192 * u7 * (2 * f13 + 31 * f12 + 154 * f + 240) / (f2 * f3 * f7) _
              - 16 * u6 * (4 * f13 + 153 * f12 + 1106 * f + 2160) / (f2 * f3 * f6) - 8 * u5 * (35 * f3 _
              + 420 * f12 + 1540 * f + 1632) / (f2 * f3 * f5) - 4 * u4 * (25 * f12 + 80 * f + 12) / (f22 * f4) _
              + 4 * u3 * (7 * f + 38) / (f * f2 * f3) + 28 * u2 / (f12 * f3) + 4 * u / f13
        s(2) = o(2) * p2
        s(3) = o(3) * p3
        s(4) = o(4) * p4 + 0.5 * (o(2) ^ 2) * P22
        s(5) = o(5) * P5 + o(3) * o(2) * P32
        s(6) = o(6) * p6 + o(4) * o(2) * P42 + 0.5 * (o(3) ^ 2) * P33 _
                      + o(2) * o(2) * o(2) * P222 / 6
        s(7) = o(7) * P7 + o(5) * o(2) * P52 + o(4) * o(3) * P43 _
                      + 0.5 * o(3) * (o(2) ^ 2) * P322
        sum = 0
        If show Then Console.WriteLine("u: {0}", u)
        For i = 2 To 7
            sum = sum + s(i)
            If show Then Console.WriteLine("i: {0}, sum: {1}, s(i): {2}", i, sum, s(i))
        Next i
        x = u + 2 * sum
        Console.WriteLine("resultM in DavisPercentile: {0}", x)
        Console.WriteLine("resultM/rho in DavisPercentile: {0}", x / rho)
        'x = x / rho
    End Sub


    Function Delta(s As Integer, p As Integer) As Double
        Dim sum As Double, j As Integer
        sum = 0
        For j = 0 To p - 1
            sum = sum + Bernoulli(s, -j / 2)
        Next j
        Delta = -sum * (s + 1) / 2
    End Function


    Sub Box(cmax As Integer, C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
    C_dfErrCount As Integer, ByRef C_x As Double, C_XScale As String, C_Algorithm As String,
    C_Result As String, C_LeftTail As Double, C_RightTail As Double)
        Dim sum As Double, Mur As Double, z As Double, f As Double, b As Double, mu As Double, rho As Double
        Dim S1 As Double, s2 As Double, s3 As Double, sigma2 As Double, sigma3 As Double
        Dim k As Integer, p As Integer, j As Integer, r As Integer, s As Integer, i As Integer
        Dim ss(100) As Double, omega(100) As Double
        Dim BK As Double, ks As Double, TWO As Double, nu As Double, n As Double
        Dim rhor As Double, NS As Double, ps As Double
        Dim d(100) As Double, Beta(100) As Double, nr(100) As Double

        b = 1 : S1 = 1 : p = 1 : Mur = 1 : s2 = 1 : k = 1
        n = 1 : rho = 1 : mu = 1 : nu = 1 : TWO = 1 : ks = 1
        f = 1.0 : rhor = 1 : NS = 1 : ps = 1
        Select Case C_Dis

'Independence of sets of variates
' (*************************************************************
'  *  Note: P.dfErr(1) is equivalent to the sample size       *
'  *        to make results match those of the UDIS            *
'  *        sub, use                                     *
'  *        UDisX(P.dfVar(1),P.dfVar(2),P.dfErr(1)-P.dfVar(2), *
'  *        P.x,P.LeftTail,P.RightTail)                       *
'  *************************************************************)
            Case "U1DIS"
                S1 = 0 : s2 = 0 : s3 = 0 : ss(0) = 0
                For i = 1 To C_dfVarCount
                    ss(i) = C_dfVar(i) + ss(i - 1)
                    S1 = S1 + C_dfVar(i)
                    s2 = s2 + (C_dfVar(i) ^ 2)
                    s3 = s3 + C_dfVar(i) * (C_dfVar(i) ^ 2)
                Next i
                sigma2 = (S1) ^ 2 - s2
                sigma3 = S1 * (S1) ^ 2 - s3
                f = sigma2 / 2
                n = C_dfErr(1)
                rho = 1 - (2 * sigma3 + 3 * sigma2) / (12 * f * n)
                z = rho * C_x
                Console.WriteLine("C_x: {0}, z: {1}, rho: {2}", C_x, z, rho)
                b = n * (1 - rho)
                mu = n * rho
                Mur = -mu / 2

            Case "U2DIS"
                S1 = 0 : s2 = 0 : s3 = 0 : ss(0) = 0
                For i = 1 To C_dfVarCount
                    ss(i) = C_dfVar(i) + ss(i - 1)
                    S1 = S1 + C_dfVar(i)
                    s2 = s2 + (C_dfVar(i) ^ 2)
                    s3 = s3 + C_dfVar(i) * (C_dfVar(i) ^ 2)
                Next i
                sigma2 = (S1) ^ 2 - s2
                sigma3 = S1 * (S1) ^ 2 - s3
                f = sigma2 / 2
                n = C_dfErr(1)
                rho = 1 - (2 * sigma3 + 3 * sigma2) / (12 * f * n)
                z = rho * C_x
                Console.WriteLine("C_x: {0}, z: {1}, rho: {2}", C_x, z, rho)
                b = n * (1 - rho)
                mu = n * rho
                Mur = -mu / 2

' Bartlett Test
            Case "L1DIS"
                k = C_dfErrCount : p = C_dfVar(1)
                S1 = 0 : s2 = 0 : n = 0
                For i = 1 To k
                    n = n + C_dfErr(i)
                    S1 = S1 + 1.0 / C_dfErr(i)
                    s2 = s2 + (1.0 / C_dfErr(i)) ^ 2
                    nr(i) = 1
                Next i
                S1 = S1 - 1.0 / n
                rho = 1 - S1 * (2 * p * p + 3 * p - 1) / (6 * (p + 1) * (k - 1))
                nu = n / k : b = (1 - rho) * nu : mu = -rho * nu : f = (k - 1) * p * (p + 1) / 2
                z = rho * C_x
                TWO = 2
                ks = k
                d(1) = TWO * (1 - 1.0 / ks) * Delta(1, p)
                Beta(0) = 1
                Mur = mu
                Console.WriteLine("rho: {0}", rho)

' Equality of normal distributions
            Case "L2DIS"
                k = C_dfErrCount : p = C_dfVar(1)
                S1 = 0 : s2 = 0 : n = 0
                For i = 1 To k
                    n = n + C_dfErr(i)
                Next i
                For i = 1 To k
                    S1 = S1 + 1 / C_dfErr(i)
                    s2 = s2 + (1 / C_dfErr(i)) ^ 2
                Next i
                f = p * (p + 3) * (k - 1) / 2
                rho = 1 - (S1 - 1 / n) * (2.0 * p * p + 9 * p + 11) / (6 * (k - 1) * (p + 3))
                mu = n * rho
                z = rho * C_x
                Console.WriteLine("s2: {0}", s2)
                Console.WriteLine("f: {0}", f)
                Console.WriteLine("rho: {0}", rho)
                'If C_XScale = "CHI2RHO" Then z = z / rho

' Mauchley test for sphericity
            Case "LSDIS"
                p = C_dfVar(1)
                n = C_dfErr(1)
                rho = 1 - (2 * p * p + p + 2.0) / (6 * p * n)
                f = (p - 1) * (p + 2.0) / 2
                z = rho * C_x : b = 1 - rho
                NS = 1 : ps = 1
                rhor = rho
                d(1) = Delta(1, p) - 0.5
                Beta(0) = 1

' Test for a given covariance matrix
            Case "LVCDIS"
                p = C_dfVar(1)
                n = C_dfErr(1)
                rho = 1 - (2 * p * p + 3 * p - 1.0) / (6 * n * (p + 1))
                f = p * (p + 1) / 2
                z = rho * C_x
                NS = 1 : b = 1 - rho
                rhor = rho
                d(1) = Delta(1, p)
                Beta(0) = 1

' Test for a given covariance matrix and mean vector
            Case "LVCMDIS"
                p = C_dfVar(1)
                n = C_dfErr(1)
                rho = 1 - (2 * p * p + 9 * p + 11.0) / (6 * n * (p + 3))
                f = p * (p + 3) / 2
                z = rho * C_x
                NS = 1 : b = 1 - rho - 1.0 / n
                TWO = 4
                rhor = rho
                d(1) = Delta(1, p) + p * 2.0 / TWO
                Beta(0) = 1

        End Select


        If (C_Algorithm = "CHI2") Or (C_Algorithm = "DEF") Then
            cmax = cmax
        Else
            rho = 1 : cmax = 2
        End If
        For r = 1 To cmax
            Select Case C_Dis

'Independence of sets of variates
                Case "U1DIS"
                    sum = 0
                    For i = 2 To C_dfVarCount
                        For j = 0 To C_dfVar(i) - 1
                            sum = sum + Bernoulli(r + 1, (b - j) / 2) - Bernoulli(r + 1, (b - ss(i - 1) - j) / 2)
                        Next j
                    Next i
                    omega(r) = sum / (r * (r + 1) * Mur)
                    Mur = -Mur * mu / 2

                Case "U2DIS"
                    sum = 0
                    For i = 2 To C_dfVarCount
                        For j = 0 To C_dfVar(i) - 1
                            sum = sum + Bernoulli(r + 1, (b - j) / 2) - Bernoulli(r + 1, (b - ss(i - 1) - j) / 2)
                        Next j
                    Next i
                    omega(r) = sum / (r * (r + 1) * Mur)
                    Mur = -Mur * mu / 2

' Bartlett Test
                Case "L1DIS"
                    TWO = 2 * TWO
                    ks = ks * k
                    sum = 0
                    For i = 1 To k
                        nr(i) = nr(i) * nu / C_dfErr(i)
                        sum = sum + nr(i)
                    Next i
                    d(r + 1) = TWO * (sum / k - 1.0 / ks) * Delta(r + 1, p)
                    Beta(r) = Beta(r - 1) * b
                    BK = r + 2
                    sum = 0
                    For s = 1 To r + 1
                        BK = BK * (r + 2 - s) / (s + 1)
                        sum = sum + BK * d(s) * Beta(r + 1 - s)
                    Next s
                    omega(r) = k * sum / (r * (r + 1) * (r + 2) * Mur)
                    Console.WriteLine("r: {0}, omega(r): {1}", r, omega(r))
                    Mur = Mur * mu

' Equality of normal distributions
                Case "L2DIS"
                    If r <> 2 Then
                        omega(r) = 0
                    Else
                        Console.WriteLine("s2: {0}", s2)
                        omega(r) = (p * (p + 3) / (48 * rho ^ 2)) * ((s2 - 1 / (n * n)) * (p + 1) * (p + 2) - (6 * (1 - rho) ^ 2 * (k - 1)))
                        Console.WriteLine("r: {0}, omega(r): {1}", r, omega(r))
                    End If

' Mauchley test for sphericity
                Case "LSDIS"
                    NS = NS * (n / 2)
                    ps = ps * p
                    d(r + 1) = (Delta(r + 1, p) + (r + 2) / 2 * Bernoulli(r + 1, 0) / ps) / NS
                    Beta(r) = Beta(r - 1) * b
                    BK = r + 2
                    sum = 0
                    For s = 1 To r + 1
                        BK = BK * (r + 2 - s) / (s + 1)
                        sum = sum + BK * d(s) * Beta(r + 1 - s)
                    Next s
                    omega(r) = 2.0 / (r * (r + 1) * (r + 2) * rhor) * sum
                    If ((r Mod 2) <> 0) Then omega(r) = -omega(r)
                    rhor = rhor * rho

' Test for a given covariance matrix
                Case "LVCDIS"
                    NS = NS * (n / 2)
                    d(r + 1) = Delta(r + 1, p) / NS
                    Beta(r) = Beta(r - 1) * b
                    BK = r + 2
                    sum = 0
                    For s = 1 To r + 1
                        BK = BK * (r + 2 - s) / (s + 1)
                        sum = sum + BK * d(s) * Beta(r + 1 - s)
                    Next s
                    omega(r) = 2.0 / (r * (r + 1) * (r + 2) * rhor) * sum
                    If ((r Mod 2) <> 0) Then omega(r) = -omega(r)
                    rhor = rhor * rho

' Test for a given covariance matrix and mean vector
                Case "LVCMDIS"
                    TWO = TWO * 2
                    NS = NS * (n / 2)
                    d(r + 1) = (Delta(r + 1, p) + p * (r + 2) / TWO) / NS
                    Beta(r) = Beta(r - 1) * b
                    BK = r + 2
                    sum = 0
                    For s = 1 To r + 1
                        BK = BK * (r + 2 - s) / (s + 1)
                        sum = sum + BK * d(s) * Beta(r + 1 - s)
                    Next s
                    omega(r) = 2 / (r * (r + 1) * (r + 2) * rhor) * sum
                    If ((r Mod 2) <> 0) Then omega(r) = -omega(r)
                    rhor = rhor * rho
            End Select
        Next r

        If C_Result = "PValue" Then ' Get p-value
            If C_XScale = "LR" Then z = -rho * C_dfErr(1) * Math.Log(C_x)
            If C_Algorithm = "CHI2" Then
                '    Call BoxDavis1(False, cmax, f, z, omega, C_LeftTail, C_RightTail)
                Call Gupta(cmax, f, z / rho, rho, omega)
            Else
                Call BoxFApprox("PValue", f, z, omega(1), omega(2), C_LeftTail, C_RightTail)
            End If
        Else
            If C_Algorithm = "CHI2" Then ' Get percentile
                Call DavisPercentile(f, z, C_LeftTail, C_RightTail, rho, omega)
            Else
                Call BoxFApprox("XValue", f, z, omega(1), omega(2), C_LeftTail, C_RightTail)
            End If
            If C_XScale = "LR" Then z = Math.Exp(-z / C_dfErr(1))
            If C_XScale = "CHI2RHO" Then z = z * rho
            C_x = z
        End If
    End Sub

    Sub Gupta(cmax As Int32, f As Double, z As Double, rho As Double, omega() As Double)
        Console.WriteLine("f: {0}, z: {1}, rho: {2}", f, z, rho)

        Dim LogKB As Double = 0.0
        Dim sum As Double = cdis(f, z)
        Dim a(100) As Double
        a(0) = 1.0
        For j = 1 To cmax
            Dim temp As Double = 0.0
            For l = 1 To j
                temp = temp + l * omega(l) * a(j - l)
            Next l
            a(j) = temp / j
            LogKB = LogKB + omega(j)
            Dim adj As Double = cdis(f + 2 * j, z)
            Dim adj2 As Double = a(j) * adj
            sum = sum + adj2
            If j Mod 2 = 0 Then
                Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2}, adj: {3}, adj2: {4}", j, omega(j), a(j), adj, adj2)
            End If
        Next j
        Dim KB As Double = Math.Exp(-LogKB)
        Console.WriteLine("LogKB: {0}, KB: {1}, sum: {2}, LeftTail: {3}", LogKB, KB, sum, KB * sum)
    End Sub


    Sub Udisdemo()

        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
        C_dfErrCount As Integer, C_x As Double, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As Double, C_RightTail As Double
        C_Dis = "U1DIS"
        C_dfVarCount = 2
        ReDim C_dfVar(C_dfVarCount)
        C_dfVar(1) = 14
        C_dfVar(2) = 8
        C_dfErrCount = 1
        ReDim C_dfErr(C_dfErrCount)
        C_dfErr(1) = 125 + 7
        C_x = 0.5
        C_XScale = "CHI2"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = 0.9
        C_RightTail = 1 - C_LeftTail
        Call Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
        C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("Result X: {0}", C_x)
        C_x = C_x * 1
        C_Result = "PValue"

        'C_Algorithm = "F"

        Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
            C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub


    Sub Udis2demo()
        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
        C_dfErrCount As Integer, C_x As Double, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As Double, C_RightTail As Double, i As Int32
        C_Dis = "U2DIS"
        C_dfVarCount = 15
        ReDim C_dfVar(C_dfVarCount)
        For i = 1 To C_dfVarCount
            C_dfVar(i) = 1
        Next
        C_dfErrCount = 1
        ReDim C_dfErr(C_dfErrCount)
        C_dfErr(1) = 125 - 1
        C_x = 0.5
        C_XScale = "CHI2"

        ' Using Mathai's tables as comparison, one needs to use "C_XScale = CHI2RHO", not "C_XScale = CHI2" !!!
        ' Convergence for n = p + 1
        'C_XScale = "CHI2RHO"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = 0.99
        C_RightTail = 1 - C_LeftTail
        Call Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("Result X: {0}", C_x)
        C_x = C_x * 1
        C_Result = "PValue"

        'C_Algorithm = "F"

        Call Box(10, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub


    Sub Udis3demo()
        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
        C_dfErrCount As Integer, C_x As Double, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As Double, C_RightTail As Double
        C_Dis = "U2DIS"
        C_dfVarCount = 5
        'ReDim C_dfVar(C_dfVarCount)
        ReDim C_dfVar(10)
        C_dfVar(1) = 2
        C_dfVar(2) = 2
        C_dfVar(3) = 2
        C_dfVar(4) = 2
        C_dfVar(5) = 2
        C_dfErrCount = 1
        ReDim C_dfErr(C_dfErrCount)
        C_dfErr(1) = 46
        C_x = 0.5
        C_XScale = "CHI2"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = 0.9
        C_RightTail = 1 - C_LeftTail
        Call Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("Result X: {0}", C_x)
        'C_x = C_x * 1
        'C_Result = "PValue"

        ''C_Algorithm = "F"

        'Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        'Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub


    ' Mauchley test for sphericity
    Sub Mauchlydemo()
        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
        C_dfErrCount As Integer, C_x As Double, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As Double, C_RightTail As Double
        C_Dis = "LSDIS"
        C_dfVarCount = 1
        ReDim C_dfVar(C_dfVarCount)
        C_dfVar(1) = 15  ' = p
        C_dfErrCount = 1
        ReDim C_dfErr(C_dfErrCount)
        C_dfErr(1) = 125  ' = n
        C_x = 0.5
        C_XScale = "CHI2"

        ' Using Davis's tables as comparison,  one needs to use "C_XScale = CHI2RHO", not "C_XScale = CHI2" !!!
        ' Convergence for n = p + 1
        'C_XScale = "CHI2RHO"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = 0.9
        C_RightTail = 1 - C_LeftTail
        Call Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        Dim p As Double = C_dfVar(1)
        Dim chix As Double = cdisx(C_LeftTail, C_RightTail, (p - 1) * (p + 2) / 2)
        Console.WriteLine("p: {0}, n: {1}, chix: {2}", C_dfVar(1), C_dfErr(1), chix)
        Console.WriteLine("X: {0}, ratio: {1}", C_x, C_x / chix)
        'C_x = C_x * 1
        'C_Result = "PValue"

        ''C_Algorithm = "F"

        'Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        'Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub


    ' Test for a given covariance matrix
    Sub Lvcdemo()
        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
        C_dfErrCount As Integer, C_x As Double, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As Double, C_RightTail As Double
        C_Dis = "LVCDIS"
        C_dfVarCount = 1
        ReDim C_dfVar(C_dfVarCount)
        C_dfVar(1) = 6  ' = p
        C_dfErrCount = 1
        ReDim C_dfErr(C_dfErrCount)
        C_dfErr(1) = 20  ' = n
        C_x = 0.5
        C_XScale = "CHI2"

        ' Using Davis's tables as comparison.
        ' Convergence for n = p + 1
        'C_XScale = "CHI2RHO"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = 0.99
        C_RightTail = 1 - C_LeftTail
        Call Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        Dim p As Double = C_dfVar(1)
        Dim chix As Double = cdisx(C_LeftTail, C_RightTail, p * (p + 1) / 2)
        Console.WriteLine("p: {0}, n: {1}, chix: {2}", C_dfVar(1), C_dfErr(1), chix)
        Console.WriteLine("X: {0}, ratio: {1}", C_x, C_x / chix)
        'C_x = C_x * 1
        'C_Result = "PValue"

        ''C_Algorithm = "F"

        'Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        'Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub


    ' Test for a given covariance matrix and mean vector
    Sub Lvcmdemo()
        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
        C_dfErrCount As Integer, C_x As Double, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As Double, C_RightTail As Double
        C_Dis = "LVCMDIS"
        C_dfVarCount = 1
        ReDim C_dfVar(C_dfVarCount)
        C_dfVar(1) = 5  ' = p
        C_dfErrCount = 1
        ReDim C_dfErr(C_dfErrCount)
        C_dfErr(1) = 20  ' = n
        C_x = 0.5
        C_XScale = "CHI2"

        ' Using Nagarsenker's (1984) tables as comparison.
        ' Convergence for n = p + 1
        'C_XScale = "CHI2RHO"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = 0.99
        C_RightTail = 1 - C_LeftTail
        Call Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        Dim p As Double = C_dfVar(1)
        Dim chix As Double = cdisx(C_LeftTail, C_RightTail, p * (p + 3) / 2)
        Console.WriteLine("p: {0}, n: {1}, chix: {2}", C_dfVar(1), C_dfErr(1), chix)
        Console.WriteLine("X: {0}, ratio: {1}", C_x, C_x / chix)
        'C_x = C_x * 1
        'C_Result = "PValue"

        ''C_Algorithm = "F"

        'Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
        'Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub



    Sub Bartlettdemo()
        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
        C_dfErrCount As Integer, C_x As Double, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As Double, C_RightTail As Double, i As Int32

        C_Dis = "L1DIS"
        C_dfVarCount = 1
        ReDim C_dfVar(C_dfVarCount)
        C_dfVar(1) = 3  ' = p
        C_dfErrCount = 5 ' = q
        ReDim C_dfErr(C_dfErrCount)
        For i = 1 To C_dfErrCount
            C_dfErr(i) = 15
        Next
        C_x = 0.5
        ' Using Anderson's (1984), page 638 tables as comparison. Also see Davis 1971

        C_XScale = "CHI2"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = 0.95
        C_RightTail = 1 - C_LeftTail
        Call Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
        C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("Result X: {0}", C_x)
        C_x = C_x * 1
        C_Result = "PValue"

        'C_Algorithm = "F"

        Call Box(10, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
            C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub



    Sub EqualDistributions()
        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr() As Double,
        C_dfErrCount As Integer, C_x As Double, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As Double, C_RightTail As Double, i As Int32

        C_Dis = "L2DIS"
        C_dfVarCount = 1
        ReDim C_dfVar(C_dfVarCount)
        C_dfVar(1) = 3  ' = p
        C_dfErrCount = 5 ' = q
        ReDim C_dfErr(C_dfErrCount)
        For i = 1 To C_dfErrCount
            C_dfErr(i) = 15
        Next
        C_x = 0.5
        ' Using Anderson's (1984), page 638 tables as comparison. Also see Davis 1971

        C_XScale = "CHI2"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = 0.95
        C_RightTail = 1 - C_LeftTail
        Call Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
        C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("Result X: {0}", C_x)
        'C_x = C_x * 1
        'C_Result = "PValue"

        ''C_Algorithm = "F"

        'Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
        '    C_Result, C_LeftTail, C_RightTail)
        'Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub



    Sub TestBoxDavis(C_Result As String, C_Algorithm As String, a As Int32, b As Int32, x() As Double, y() As Double,
                     xi() As Double, eta() As Double, ByRef z As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim k, j, r, rsign As Int32
        Dim sum1, sum2, f, rho As Double
        Dim omega() As Double

        ' Calculate f
        sum1 = 0
        For k = 1 To a
            sum1 = sum1 + xi(k)
        Next
        sum2 = 0
        For j = 1 To b
            sum2 = sum2 + eta(j)
        Next
        f = -2 * (sum1 - sum2 - (a - b) / 2)
        Console.WriteLine("f: {0}", f)

        ' Calculate rho
        sum1 = 0
        For k = 1 To a
            sum1 = sum1 + Bernoulli(2, xi(k)) / x(k)
        Next
        sum2 = 0
        For j = 1 To b
            sum2 = sum2 + Bernoulli(2, eta(j)) / y(j)
        Next
        rho = 1 - (sum1 - sum2) / f
        Console.WriteLine("rho: {0}", rho)

        ' Calculate omega
        Dim rmax As Int32 = 20
        rsign = -1
        ReDim omega(rmax)
        For r = 1 To rmax
            rsign = -rsign
            sum1 = 0
            For k = 1 To a
                sum1 = sum1 + Bernoulli(r + 1, (1 - rho) * x(k) + xi(k)) / ((rho * x(k)) ^ r)
            Next
            sum2 = 0
            For j = 1 To b
                sum2 = sum2 + Bernoulli(r + 1, (1 - rho) * y(j) + eta(j)) / ((rho * y(j)) ^ r)
            Next
            omega(r) = rsign * (sum1 - sum2) / (r * (r + 1))

        Next

        If C_Result = "PValue" Then ' Get p-value
            'If C_XScale = "LR" Then z = -rho * C_dfErr(1) * Math.Log(C_x)
            If C_Algorithm = "CHI2" Then
                '    Call BoxDavis1(False, cmax, f, z, omega, C_LeftTail, C_RightTail)
                Call Gupta(rmax, f, z, rho, omega)
            Else
                'Call BoxFApprox("PValue", f, z, omega(1), omega(2), C_LeftTail, C_RightTail)
            End If
        Else
            If C_Algorithm = "CHI2" Then ' Get percentile
                Call DavisPercentile(f, z, LeftTail, RightTail, rho, omega)
            Else
                'Call BoxFApprox("XValue", f, z, omega(1), omega(2), C_LeftTail, C_RightTail)
            End If
            'If C_XScale = "LR" Then z = Math.Exp(-z / C_dfErr(1))
            'If C_XScale = "CHI2RHO" Then z = z * rho
            'C_x = z
        End If

        'Exit Sub

        ' Calculate cumulants
        Console.WriteLine("")
        Console.WriteLine("Hello Calculate cumulants")


        rmax = 12
        Dim kappa(rmax) As Double
        For r = 1 To rmax
            sum1 = 0
            For k = 1 To a
                sum1 = sum1 + ((-2 * rho * x(k)) ^ r) * math53.polygamma(r - 1, x(k) + xi(k))
            Next k
            sum2 = 0
            For j = 1 To b
                sum2 = sum2 + ((-2 * rho * y(j)) ^ r) * math53.polygamma(r - 1, y(j) + eta(j))
            Next j
            kappa(r) = sum1 - sum2
            Console.WriteLine("r: {0}, kappa (r): {1}", r, kappa(r))
        Next r
        Dim mean = kappa(1)
        Dim sigma = Math.Sqrt(kappa(2))
        Dim sigma2 = kappa(2)
        Dim fxTarget = (z - mean) / sigma
        Dim testXrho = (z / rho - mean) / sigma
        Console.WriteLine("z: {0}, fxTarget: {1}, testXrho: {2}", z, fxTarget, testXrho)

        If C_Result = "PValue" Then ' Get p-value
            Dim o(0 To rmax + 10) As Double
            Call CumulantToGamma(rmax, mean, sigma, kappa, o)
            Call CalcEdgeworth(True, False, 0, rmax - 2, (z - mean) / sigma, o, LeftTail, RightTail)
            Console.WriteLine("Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)
        Else
            Dim x2 = CalcCornish(LeftTail, RightTail, mean, sigma, kappa, rmax)
            Console.WriteLine("Cornish X2: {0}", x2)
        End If


    End Sub



    Sub NewTestR0DisX()
        Dim j As Integer, LeftTail As Double, Righttail As Double, p As Integer, n As Double
        Dim LeftTail2, RightTail2 As Double
        p = 15  ' number of variables
        n = 85 - 1  'Coelho_2012, equation 9, n + 1 is sample size
        'LeftTail = 0.99999
        'Righttail = 1 - LeftTail

        Righttail = 0.001
        LeftTail = 1 - Righttail

        Dim b(p) As Double, c(p) As Double
        For j = 1 To p - 1
            b(j) = (n - p + j) / 2
            c(j) = b(j) + (p - j) / 2
            'c(j) = (p - j) / 2
            Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
        Next j
        Dim result2 = BetaflintodDisX2(LeftTail, Righttail, p - 1, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultM = -n * Math.Log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2(p, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDist(LeftTail, Righttail, p - 1, n / 2, b, c)
    End Sub


    'Note: In Coelho_2016, equation 53, n is sample size 
    ' Tables are on page 10
    Sub NewTestLvcDisX()
        Dim j As Integer, LeftTail As Double, Righttail As Double, p As Integer, n As Double
        Dim LeftTail2, RightTail2 As Double
        p = 5 ' number of variables
        n = 65   ' n is sample size
        LeftTail = 0.95
        Righttail = 1 - LeftTail
        Dim b(p) As Double, c(p) As Double
        For j = 2 To p
            b(j - 1) = (n - j) / 2
            c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j - 1) / 2
            Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j - 1, b(j - 1), c(j - 1))
        Next j
        Dim result2 = BetaflintodDisX2(LeftTail, Righttail, p - 1, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultM = -n * Math.Log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2(p - 1, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDist(LeftTail, Righttail, p - 1, n / 2, b, c)
    End Sub


    'Note: In Coelho_2016, equation 32, n is sample size 
    ' Tables are on page 10
    Sub NewTestLvcmDisX()
        Dim j As Integer, LeftTail As Double, Righttail As Double, p As Integer, n As Double
        Dim LeftTail2, RightTail2 As Double
        p = 15 ' number of variables
        n = 65   ' n is sample size
        LeftTail = 0.95
        Righttail = 1 - LeftTail
        Dim b(p) As Double, c(p) As Double
        For j = 2 To p
            b(j - 1) = (n - j) / 2
            c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
            Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j - 1, b(j - 1), c(j - 1))
        Next j
        Dim result2 = BetaflintodDisX2(LeftTail, Righttail, p - 1, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultM = -n * Math.Log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2(p - 1, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDist(LeftTail, Righttail, p - 1, n / 2, b, c)
    End Sub


    'Note: In Coelho_2016, equation 55, n is sample size 
    ' Tables are on page 10
    Sub NewTestLvcm0DisX()
        Dim j As Integer, LeftTail As Double, Righttail As Double, p As Integer, n As Double
        Dim LeftTail2, RightTail2 As Double
        p = 15 ' number of variables
        n = 65   ' n is sample size
        LeftTail = 0.95
        Righttail = 1 - LeftTail
        Dim b(p) As Double, c(p) As Double
        For j = 2 To p
            b(j - 1) = (n - j) / 2
            c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
            Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j - 1, b(j - 1), c(j - 1))
        Next j
        b(p) = (n - 1) / 2
        c(p) = b(p) + 1 / 2
        Dim result2 = BetaflintodDisX2(LeftTail, Righttail, p, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultM = -n * Math.Log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2(p, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDist(LeftTail, Righttail, p, n / 2, b, c)
    End Sub


    'Note: In Coelho_2012c, equation 32, n is sample size (not n+1, as we use it here)
    Sub NewTestMauchley()
        Console.WriteLine("Hello NewTestMauchley")
        Dim j As Integer, LeftTail As Double, Righttail As Double, p As Integer, n As Double
        Dim LeftTail2, RightTail2 As Double
        p = 15 ' number of variables
        n = 125   ' n is sample size
        LeftTail = 0.95
        Righttail = 1 - LeftTail
        Dim b(p) As Double, c(p) As Double
        For j = 2 To p
            b(j - 1) = (n + 1 - j) / 2
            c(j - 1) = b(j - 1) + (j - 1) / p + (j - 1) / 2
            Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j - 1, b(j - 1), c(j - 1))
        Next j
        Dim result2 = BetaflintodDisX2(LeftTail, Righttail, p - 1, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultM = -n * Math.Log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2(p - 1, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDist(LeftTail, Righttail, p - 1, n / 2, b, c)
    End Sub


    Sub NewTestWilksU()
        Console.WriteLine("Hello NewTestWilksU")
        Dim f1, n As Integer, LeftTail As Double, Righttail As Double, p As Integer
        Dim LeftTail2, RightTail2 As Double
        'p = 4 ' number of variables
        'f1 = 7 - 1 ' number of groups
        'n = 20 - 7  ' n is sample size
        p = 5 ' number of variables
        f1 = 10 ' number of groups
        n = 20  ' n is sample size
        LeftTail = 0.1
        Righttail = 1 - LeftTail
        Dim b(p) As Double, c(p) As Double
        For i = 1 To p
            b(i) = (n - i + 1) / 2
            c(i) = b(i) + f1 / 2
            Console.WriteLine("j: {0}, b(i): {1}, c(i): {2}", i, b(i), c(i))
        Next i
        Dim result2 = BetaflintodDisX2(LeftTail, Righttail, p, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultL = -Math.Log(result2)
        Console.WriteLine("resultL: {0}", resultL)
        Dim resultM = -n * Math.Log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2(p, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDist(LeftTail, Righttail, p, n / 2, b, c)
    End Sub


    'Note: In Coelho_2012c, equation 30, n is sample size (not n+1, as we use it here)
    Sub NewTestBartlett()
        Console.WriteLine("Hello NewTestBartlett")
        Dim p, q, j, k, m, n As Integer
        Dim LeftTail, Righttail, LeftTail2, RightTail2 As Double
        p = 3 ' number of variables
        q = 5 ' number of variables
        n = 15   ' n + 1 is sample size
        LeftTail = 0.95
        Righttail = 1 - LeftTail
        Dim b(p * q) As Double, c(p * q) As Double

        m = 0
        For j = 1 To p
            For k = 1 To q
                If (j = 1 And k = 1) Then
                    Console.WriteLine("The item (j = 1 And k = 1) needs to be omitted")
                Else
                    m = m + 1
                    b(m) = (n + 1 - j) / 2
                    c(m) = b(m) + (j * (q - 1) + 2 * k - 1 - q) / (2 * q)
                    Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
                End If
            Next k
        Next j

        Dim result2 = BetaflintodDisX2(LeftTail, Righttail, m, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultM = -n * Math.Log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2(m, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDist(LeftTail, Righttail, m, n / 2, b, c)
    End Sub




    Sub NewTestR0KSetsDis()
        Dim LeftTail As Double, Righttail As Double, k As Integer, n As Double
        Dim LeftTail2, RightTail2 As Double
        Dim i, j, m, pmax As Integer
        n = 40
        k = 5
        LeftTail = 0.95
        Righttail = 1 - LeftTail
        Dim p(k) As Integer
        For i = 1 To k
            p(i) = 3
        Next

        Dim pp(k) As Integer
        pp(k) = 0
        pmax = 0
        For i = k - 1 To 1 Step -1
            pp(i) = pp(i + 1) + p(i)
            pmax = pmax + p(i)
        Next i
        Dim b() As Double, c() As Double
        ReDim b(pmax) : ReDim c(pmax)
        m = 0
        For i = 1 To k - 1
            For j = 1 To p(i)
                m = m + 1
                b(m) = (n + 1 - pp(i) - j) / 2
                c(m) = b(m) + pp(i) / 2
                Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
            Next j
        Next i

        Dim result2 = BetaflintodDisX2(LeftTail, Righttail, m, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultM = -n * Math.Log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2(m, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDist(LeftTail, Righttail, m, n / 2, b, c)
    End Sub


    Sub NewBetaflintodDist(LeftTail As Double, RightTail As Double, k As Int32, n2 As Double, bi() As Double, ci() As Double)
        Dim j As Int32
        Dim y(k), xi(k), eta(k) As Double

        For j = 1 To k
            y(j) = n2
            xi(j) = bi(j) - n2
            eta(j) = ci(j) - bi(j) + xi(j)   'simplify later
            'eta(j) = ci(j) - bi(j) + xi(j)   'simplify later
            Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}, xi(j): {3}", j, y(j), eta(j), xi(j))
        Next

        Console.WriteLine("")
        Console.WriteLine("Hello TestBoxDavis")

        Dim z As Double ', LeftTail As Double, RightTail As Double
        'LeftTail = 0.99
        'RightTail = 1 - LeftTail
        TestBoxDavis("Quantile", "CHI2", k, k, y, y, xi, eta, z, LeftTail, RightTail)
        Console.WriteLine("z: {0}", z)
        TestBoxDavis("PValue", "CHI2", k, k, y, y, xi, eta, z, LeftTail, RightTail)
        Console.WriteLine("LeftTail: {0}", LeftTail)
    End Sub


    Sub NewBartlett()
        Dim p, q, NN As Int32
        Dim a, b, i, j, k, g As Int32
        Dim x(), y(), xi(), eta() As Double
        Dim n() As Int32 ' Sample sizes -1 per group
        p = 3
        q = 5
        NN = 0
        ReDim n(q)
        For g = 1 To q
            n(g) = 15
            NN = NN + n(g)
        Next

        a = p * q
        b = p
        ReDim y(b) : ReDim eta(b)
        ReDim x(a) : ReDim xi(a)

        For j = 1 To b
            y(j) = NN / 2
            eta(j) = (1 - j) / 2
        Next
        k = 0
        For g = 1 To q
            For i = 1 To p
                k = k + 1  ' k = (g - 1) * p + i
                x(k) = n(g) / 2
                xi(k) = (1 - i) / 2
            Next i
        Next g

        For j = 1 To b
            Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}", j, y(j), eta(j))
        Next

        For k = 1 To a
            Console.WriteLine("k: {0}, x(k): {1}, xi(k): {2}", k, x(k), xi(k))
        Next

        Console.WriteLine("")
        Console.WriteLine("Hello TestBoxDavis")

        Dim z As Double, LeftTail As Double, RightTail As Double
        LeftTail = 0.95
        RightTail = 1 - LeftTail
        TestBoxDavis("Quantile", "CHI2", a, b, x, y, xi, eta, z, LeftTail, RightTail)
        Console.WriteLine("z: {0}", z)
        TestBoxDavis("PValue", "CHI2", a, b, x, y, xi, eta, z, LeftTail, RightTail)
        Console.WriteLine("LeftTail: {0}", LeftTail)


    End Sub

    Sub NewEqualDistributions()
        Dim p, q, NN As Int32
        Dim a, b, i, j, k, g As Int32
        Dim x(), y(), xi(), eta() As Double
        Dim N() As Int32  ' Sample sizes per group
        p = 3
        q = 5
        NN = 0
        ReDim N(q)
        For g = 1 To q
            N(g) = 15
            NN = NN + N(g)
        Next

        a = p * q
        b = p
        ReDim y(b) : ReDim eta(b)
        ReDim x(a) : ReDim xi(a)

        For j = 1 To b
            y(j) = NN / 2
            eta(j) = -j / 2
        Next
        k = 0
        For g = 1 To q
            For i = 1 To p
                k = k + 1  ' k = (g - 1) * p + i
                x(k) = N(g) / 2
                xi(k) = -i / 2
            Next i
        Next g

        For j = 1 To b
            Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}", j, y(j), eta(j))
        Next

        For k = 1 To a
            Console.WriteLine("k: {0}, x(k): {1}, xi(k): {2}", k, x(k), xi(k))
        Next

        Console.WriteLine("")
        Console.WriteLine("Hello TestBoxDavis")


        Dim z As Double, LeftTail As Double, RightTail As Double
        LeftTail = 0.9
        RightTail = 1 - LeftTail
        TestBoxDavis("Quantile", "CHI2", a, b, x, y, xi, eta, z, LeftTail, RightTail)
        Console.WriteLine("z: {0}", z)
        TestBoxDavis("PValue", "CHI2", a, b, x, y, xi, eta, z, LeftTail, RightTail)
        Console.WriteLine("LeftTail: {0}", LeftTail)



    End Sub

End Module

