Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet



Module DistBoxDavisArb


    'Function Arb_ChiSquare_pdf(x As Arb, nu As Arb, log_p As Boolean) As Arb
    '    Dim result As New Arb
    '    result = aflint.gamma_p_derivative(nu / 2, x / 2) / 2
    '    If log_p Then result = aflint.log(result)
    '    Return result
    'End Function


    'Function Arb_ChiSquare_CDF(x As Arb, nu As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
    '    Dim result As New Arb
    '    If lower_tail Then result = aflint.gamma_p(nu / 2, x / 2) Else result = aflint.gamma_q(nu / 2, x / 2)
    '    If log_p Then result = aflint.log(result)
    '    Return result
    'End Function


    Sub BoxFApproxArb(result As String, f1 As Arb, ByRef m As Arb, omeg1 As Arb, omeg2 As Arb, LeftTail As Arb, RightTail As Arb)
        Dim f2 As New Arb, A1 As New Arb, A2 As New Arb, C As New Arb, b As New Arb, x As New Arb
        A1 = 2 * omeg1 / f1 : A2 = 4 * omeg2 / f1
        C = A2 - A1 * A1
        'x = 1
        x = aflint.one
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
            'LeftTail = Fdisn(f1.AsDouble, f2.AsDouble, x.AsDouble, 0)
            LeftTail = aflint.t(Fdisn(f1.AsDouble, f2.AsDouble, x.AsDouble, 0))
        Else
            x = aflint.t(fdisx(f1.AsDouble, f2.AsDouble, LeftTail.AsDouble, RightTail.AsDouble))
            If C > 0 Then m = x * b Else m = b / (f2 / (f1 * x) + 1)
        End If
    End Sub


    Sub DavisPercentileArb(f As Arb, ByRef x As Arb, LeftTail As Arb, RightTail As Arb, rho As Arb, o As ArbMat)
        Dim p1 As New Arb, p2 As New Arb, p3 As New Arb, p4 As New Arb, P5 As New Arb, p6 As New Arb, P7 As New Arb, P22 As New Arb, P32 As New Arb, P42 As New Arb, P33 As New Arb, P222 As New Arb, P52 As New Arb, P43 As New Arb, P322 As New Arb,
            f2 As New Arb, f3 As New Arb, f4 As New Arb, f5 As New Arb, f6 As New Arb, f7 As New Arb,
            f12 As New Arb, f13 As New Arb, f22 As New Arb,
            S1 As New Arb, u As New Arb, u2 As New Arb, u3 As New Arb, u4 As New Arb, u5 As New Arb, u6 As New Arb, u7 As New Arb,
            sum As New Arb, i As Integer, show As Boolean
        Dim s As New ArbMat
        s.resize(7 + 1, 1)
        show = True
        u = cdisxArb(LeftTail, RightTail, f)
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
        's(4) = o(4) * p4 + 0.5 * (o(2) ^ 2) * P22
        s(4) = o(4) * p4 + 0.5 * aflint.pow(o(2), 2) * P22
        s(5) = o(5) * P5 + o(3) * o(2) * P32
        's(6) = o(6) * p6 + o(4) * o(2) * P42 + 0.5 * (o(3) ^ 2) * P33 _
        '              + o(2) * o(2) * o(2) * P222 / 6
        s(6) = o(6) * p6 + o(4) * o(2) * P42 + 0.5 * aflint.pow(o(3), 2) * P33 _
                      + o(2) * o(2) * o(2) * P222 / 6
        's(7) = o(7) * P7 + o(5) * o(2) * P52 + o(4) * o(3) * P43 _
        '              + 0.5 * o(3) * (o(2) ^ 2) * P322
        s(7) = o(7) * P7 + o(5) * o(2) * P52 + o(4) * o(3) * P43 _
                      + 0.5 * o(3) * aflint.pow(o(2), 2) * P322
        'sum = 0
        sum = aflint.zero
        If show Then Console.WriteLine("u: {0}", u)
        For i = 2 To 7
            sum = sum + s(i)
            If show Then Console.WriteLine("i: {0}, sum: {1}, s(i): {2}", i, sum, s(i))
        Next i
        x = u + 2 * sum
        Console.WriteLine("resultM/rho in DavisPercentile: {0}", x / rho)
        'x = x / rho
    End Sub


    Function DeltaArb(s As Integer, p As Integer) As Arb
        Dim sum As New Arb, j As Integer
        'sum = 0
        sum = aflint.zero
        For j = 0 To p - 1
            '    sum = sum + Bernoulli(s, -j / 2)
            'sum = sum + aflint.bernpoly(-aflint.t(j) / 2, s)
            sum = sum + aflint.bernpoly(-aflint.t(j) / 2, s)
        Next j
        DeltaArb = -sum * (s + 1) / 2
    End Function



    Sub BoxArb(cmax As Integer, C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr As ArbMat,
C_dfErrCount As Integer, ByRef C_x As Arb, C_XScale As String, C_Algorithm As String,
C_Result As String, C_LeftTail As Arb, C_RightTail As Arb)

        Dim sum As New Arb, Mur As New Arb, z As New Arb, f As New Arb, b As New Arb, mu As New Arb, rho As New Arb
        Dim S1 As New Arb, s2 As New Arb, s3 As New Arb, sigma2 As New Arb, sigma3 As New Arb
        Dim k As Integer, p As Integer, j As Integer, r As Integer, s As Integer, i As Integer
        Dim BK As New Arb, ks As New Arb, TWO As New Arb, nu As New Arb, n As New Arb
        Dim rhor As New Arb, NS As New Arb, ps As New Arb

        Dim d As New ArbMat, Beta As New ArbMat, nr As New ArbMat
        Dim ss As New ArbMat, omega As New ArbMat

        d.Resize(100, 1)
        Beta.Resize(100, 1)
        nr.Resize(100, 1)
        ss.Resize(100, 1)
        omega.Resize(100, 1)

        b = aflint.one : S1 = aflint.one : p = 1 : Mur = aflint.one : s2 = aflint.one : k = 1
        n = aflint.one : rho = aflint.one : mu = aflint.one : nu = aflint.one : TWO = aflint.one : ks = aflint.one
        f = aflint.one : rhor = aflint.one : NS = aflint.one : ps = aflint.one
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
                S1 = aflint.zero : s2 = aflint.zero : s3 = aflint.zero : ss(0) = aflint.zero
                For i = 1 To C_dfVarCount
                    Dim cdi As Int32 = C_dfVar(i)
                    ss(i) = cdi + ss(i - 1)
                    S1 = S1 + cdi
                    s2 = s2 + (cdi * cdi)
                    s3 = s3 + (cdi * cdi * cdi)
                Next i
                sigma2 = S1 * S1 - s2
                sigma3 = S1 * S1 * S1 - s3
                f = sigma2 / 2
                n = C_dfErr(1)
                rho = aflint.t(1) - (aflint.t(2) * sigma3 + aflint.t(3) * sigma2) / aflint.t(12 * f * n)
                z = rho * C_x
                Console.WriteLine("C_x: {0}, z: {1}, rho: {2}", C_x, z, rho)
                b = n * (1 - rho)
                mu = n * rho
                Mur = -mu / 2

' Bartlett Test
            Case "L1DIS"
                k = C_dfErrCount : p = C_dfVar(1)
                S1 = aflint.zero : s2 = aflint.zero : n = aflint.zero
                For i = 1 To k
                    n = n + C_dfErr(i)
                    S1 = S1 + 1.0 / C_dfErr(i)
                    's2 = s2 + (1.0 / C_dfErr(i)) ^ 2
                    s2 = s2 + aflint.sqr(1.0 / C_dfErr(i))
                    nr(i) = aflint.one
                Next i
                S1 = S1 - 1.0 / n
                rho = 1 - S1 * (2 * p * p + 3 * p - 1) / (6 * (p + 1) * (k - 1))
                nu = n / k : b = (1 - rho) * nu : mu = -rho * nu
                'f = (k - 1) * p * (p + 1) / 2
                f = (k - 1) * p * (p + 1) / aflint.t(2)
                z = rho * C_x
                'TWO = 2
                TWO = aflint.t(2)
                'ks = k
                ks = aflint.t(k)
                d(1) = TWO * (1 - 1.0 / ks) * DeltaArb(1, p)
                Beta(0) = aflint.one
                Mur = mu

' Equality of normal distributions
            Case "L2DIS"
                k = C_dfErrCount : p = C_dfVar(1)
                S1 = aflint.zero : s2 = aflint.zero : n = aflint.zero
                For i = 1 To k
                    n = n + C_dfErr(i)
                Next i
                For i = 1 To k
                    S1 = S1 + n / C_dfErr(i)
                    s2 = s2 + aflint.sqr(n / C_dfErr(i))
                Next i
                S1 = S1 - 1 : s2 = s2 - 1
                rho = (1.0 / n) * (n - S1 * (2.0 * p * p + 3 * p - 1) / (6 * (p + 3) * (k - 1)) - (p - k + 2.0) / (p + 3))
                mu = n * rho : f = (k - 1) * p * (p + 3) / aflint.t(2)
                z = rho * C_x
                If C_XScale = "CHI2RHO" Then z = z / rho

' Mauchley test for sphericity
            Case "LSDIS"
                p = C_dfVar(1)
                n = C_dfErr(1)
                rho = 1 - (2 * p * p + p + 2.0) / (6 * p * n)
                f = (p - 1) * (p + 2.0) / aflint.t(2)
                z = rho * C_x : b = 1 - rho
                NS = aflint.one : ps = aflint.one
                rhor = rho
                d(1) = DeltaArb(1, p) - 0.5
                Beta(0) = aflint.one

' Test for a given covariance matrix
            Case "LVCDIS"
                p = C_dfVar(1)
                n = C_dfErr(1)
                rho = 1 - (2 * p * p + 3 * p - 1.0) / (6 * n * (p + 1))
                'f = p * (p + 1) / 2
                f = p * (p + 1) / aflint.t(2)
                z = rho * C_x
                NS = aflint.one : b = 1 - rho
                rhor = rho
                d(1) = DeltaArb(1, p)
                Beta(0) = aflint.one

' Test for a given covariance matrix and mean vector
            Case "LVCMDIS"
                p = C_dfVar(1)
                n = C_dfErr(1)
                rho = 1 - (2 * p * p + 9 * p + 11.0) / (6 * n * (p + 3))
                'f = p * (p + 3) / 2
                f = p * (p + 3) / aflint.t(2)
                z = rho * C_x
                NS = aflint.one : b = 1 - rho - 1.0 / n
                'TWO = 4
                TWO = aflint.t(4)
                rhor = rho
                d(1) = DeltaArb(1, p) + p * 2.0 / TWO
                Beta(0) = aflint.one

        End Select


        If (C_Algorithm = "CHI2") Or (C_Algorithm = "DEF") Then
            cmax = cmax
        Else
            rho = aflint.one : cmax = 2
        End If


        For r = 1 To cmax
            Select Case C_Dis

'Independence of sets of variates
                Case "U1DIS"
                    sum = aflint.zero
                    '    Console.WriteLine("b: {0}, Mur: {1}", b, Mur)
                    For i = 2 To C_dfVarCount
                        For j = 0 To C_dfVar(i) - 1
                            'sum = sum + aflint.bernpoly((b - j) / 2, r + 1) - aflint.bernpoly((b - ss(i - 1) - j) / 2, r + 1)
                            sum = sum + aflint.bernpoly((b - j) / 2, r + 1) - aflint.bernpoly((b - ss(i - 1) - j) / 2, r + 1)
                            '            sum = sum + Bernoulli(r + 1, (b - j) / 2) - Bernoulli(r + 1, (b - ss(i - 1) - j) / 2)
                        Next j
                    Next i
                    omega(r) = sum / (r * (r + 1) * Mur)
                    Mur = -Mur * mu / 2

' Bartlett Test
                Case "L1DIS"
                    TWO = 2 * TWO
                    ks = ks * k
                    sum = aflint.zero
                    For i = 1 To k
                        nr(i) = nr(i) * nu / C_dfErr(i)
                        sum = sum + nr(i)
                    Next i
                    d(r + 1) = TWO * (sum / k - 1.0 / ks) * DeltaArb(r + 1, p)
                    Beta(r) = Beta(r - 1) * b
                    'BK = r + 2
                    BK = aflint.t(r + 2)
                    sum = aflint.zero
                    For s = 1 To r + 1
                        BK = BK * (r + 2 - s) / (s + 1)
                        sum = sum + BK * d(s) * Beta(r + 1 - s)
                    Next s
                    omega(r) = k * sum / (r * (r + 1) * (r + 2) * Mur)
                    Mur = Mur * mu

' Equality of normal distributions
                Case "L2DIS"
                    If r <> 2 Then omega(r) = aflint.t(0) Else
                    omega(r) = 1.0 * p / (288 * mu * mu) * (6 * s2 * (p + 1) * (p - 1) * (p + 2) - S1 * S1 * Math.Sqrt(2.0 * p *
                    p + 3 * p - 1) / ((k - 1) * (p + 3)) - 12 * S1 * (2 * p * p + 3 * p - 1) * (p - k + 2) / (p + 3) - 36 * (k - 1) _
                    * Math.Sqrt(1.0 * p - k + 2) / (p + 3) - 12 * (k - 1) * (-2 * k * k + 7 * k + 3 * p * k - 2 * p * p - 6 * p - 4))

' Mauchley test for sphericity
                Case "LSDIS"
                    NS = NS * (n / 2)
                    ps = ps * p
                    d(r + 1) = (DeltaArb(r + 1, p) + (r + 2) / 2 * aflint.bernoulli(r + 1) / ps) / NS
                    '    d(r + 1) = (deltaArb(r + 1, p) + (r + 2) / 2 * Bernoulli(r + 1, 0) / ps) / NS
                    Beta(r) = Beta(r - 1) * b
                    BK = aflint.t(r + 2)
                    sum = aflint.zero
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
                    d(r + 1) = DeltaArb(r + 1, p) / NS
                    Beta(r) = Beta(r - 1) * b
                    BK = aflint.t(r + 2)
                    sum = aflint.zero
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
                    d(r + 1) = (DeltaArb(r + 1, p) + p * (r + 2) / TWO) / NS
                    Beta(r) = Beta(r - 1) * b
                    BK = aflint.t(r + 2)
                    sum = aflint.zero
                    For s = 1 To r + 1
                        BK = BK * (r + 2 - s) / (s + 1)
                        sum = sum + BK * d(s) * Beta(r + 1 - s)
                    Next s
                    omega(r) = 2 / (r * (r + 1) * (r + 2) * rhor) * sum
                    If ((r Mod 2) <> 0) Then omega(r) = -omega(r)
                    rhor = rhor * rho
            End Select
        Next r

        Dim TargetError = aflint.t("1E-40")
        If C_Result = "PValue" Then ' Get p-value
            If C_XScale = "LR" Then z = -rho * C_dfErr(1) * aflint.log(C_x)
            If C_Algorithm = "CHI2" Then
                '    Call BoxDavis1(False, cmax, f, z, omega, C_LeftTail, C_RightTail)
                GuptaArb(cmax, f, z, rho, omega, TargetError)
            Else
                BoxFApproxArb("PValue", f, z, omega(1), omega(2), C_LeftTail, C_RightTail)
            End If
        Else
            If C_Algorithm = "CHI2" Then ' Get percentile
                DavisPercentileArb(f, z, C_LeftTail, C_RightTail, rho, omega)
                Console.WriteLine("z from within: {0}", z)
            Else
                BoxFApproxArb("XValue", f, z, omega(1), omega(2), C_LeftTail, C_RightTail)
            End If
            If C_XScale = "LR" Then z = aflint.exp(-z / C_dfErr(1))
            If C_XScale = "CHI2RHO" Then z = z * rho
            C_x = z
        End If
    End Sub

    Sub GuptaArb(cmax As Int32, f As Arb, z As Arb, rho As Arb, omega As ArbMat, TargetError As Arb)
        Console.WriteLine("f: {0}, z: {1}, rho: {2}", f, z, rho)
        Dim adj, adj2, KB, RelErr As New Arb
        Dim LogKB = aflint.t(0)
        Dim sum = Arb_ChiSquare_CDF(z, f, True, False)
        Console.WriteLine("sum: {0}", sum)
        Dim a As New ArbMat
        a.Resize(100, 1)
        a(0) = aflint.one
        For j = 1 To cmax
            Dim temp As New Arb
            temp = aflint.zero
            For l = 1 To j
                temp = temp + l * omega(l) * a(j - l)
            Next l
            a(j) = temp / j
            LogKB = LogKB + omega(j)


            '    Function Arb_ChiSquare_pdf(x As Arb, nu As Arb,  log_p As Boolean) As Arb


            '    Function Arb_ChiSquare_CDF(x As Arb, nu As Arb,  lower_tail As Boolean, log_p As Boolean) As Arb

            '        adj = cdis(f + 2*j, z)

            adj = Arb_ChiSquare_CDF(z, f + 2 * j, True, False)
            adj2 = a(j) * adj
            sum = sum + adj2
            If j Mod 2 = 0 Then
                'Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2}, adj: {3}, adj2: {4}", j, omega(j), a(j), adj, adj2)
                RelErr = aflint.abs(adj2 / sum)
                Console.WriteLine("j: {0}, sum: {1}, adj2: {2}, RelErr: {3}", j, sum, adj2, RelErr)
                If RelErr < TargetError Then Exit For
            End If
        Next j
        KB = aflint.exp(-LogKB)
        Console.WriteLine("LogKB: {0}, KB: {1}, sum: {2}, LeftTail: {3}", LogKB, KB, sum, KB * sum)
    End Sub


    Sub GuptaArbNew(cmax As Int32, f As Arb, z As Arb, rho As Arb, omega As ArbMat, TargetError As Arb, ByRef LeftTail As Arb)
        Console.WriteLine("f: {0}, z: {1}, rho: {2}", f, z, rho)
        Dim adj, adj2, KB, RelErr As New Arb
        Dim LogKB = aflint.t(0)
        Dim sum = Arb_ChiSquare_CDF(z, f, True, False)

        Dim a As New ArbMat
        a.Resize(100, 1)
        a(0) = aflint.one
        For j = 1 To cmax
            Dim temp As New Arb
            temp = aflint.zero
            For l = 1 To j
                temp = temp + l * omega(l) * a(j - l)
            Next l
            a(j) = temp / j
            LogKB = LogKB + omega(j)


            '    Function Arb_ChiSquare_pdf(x As Arb, nu As Arb,  log_p As Boolean) As Arb


            '    Function Arb_ChiSquare_CDF(x As Arb, nu As Arb,  lower_tail As Boolean, log_p As Boolean) As Arb

            '        adj = cdis(f + 2*j, z)

            adj = Arb_ChiSquare_CDF(z, f + 2 * j, True, False)
            adj2 = a(j) * adj
            sum = sum + adj2
            If j Mod 2 = 0 Then
                'Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2}, adj: {3}, adj2: {4}", j, omega(j), a(j), adj, adj2)
                RelErr = aflint.abs(adj2 / sum)
                Console.WriteLine("j: {0}, sum: {1}, adj2: {2}, RelErr: {3}", j, sum, adj2, RelErr)
                If RelErr < TargetError Then Exit For
            End If
        Next j
        KB = aflint.exp(-LogKB)
        Console.WriteLine("LogKB: {0}, KB: {1}, sum: {2}, LeftTail: {3}", LogKB, KB, sum, KB * sum)
        LeftTail = KB * sum
    End Sub



    Sub UdisdemoArb()
        Dim C_Dis As String, C_dfVarCount As Integer, C_dfVar() As Integer, C_dfErr As New ArbMat,
        C_dfErrCount As Integer, C_x As New Arb, C_XScale As String, C_Algorithm As String,
        C_Result As String, C_LeftTail As New Arb, C_RightTail As New Arb

        ArbPrec.SetDps(60)

        C_Dis = "U1DIS"
        C_dfVarCount = 2
        ReDim C_dfVar(C_dfVarCount)
        C_dfVar(1) = 5
        C_dfVar(2) = 7
        C_dfErrCount = 1
        'ReDim C_dfErr(C_dfErrCount)

        C_dfErr.Resize(C_dfErrCount + 1, 1)

        C_dfErr(1) = aflint.t(15 + 7)
        C_x = aflint.t(0.5)
        C_XScale = "CHI2"
        C_Algorithm = "CHI2"
        C_Result = "XValue"
        C_LeftTail = aflint.t("0.99")
        C_RightTail = 1 - C_LeftTail
        Call BoxArb(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
        C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("Result X: {0}", C_x)
        C_x = C_x * 1
        C_Result = "PValue"

        'C_Algorithm = "F"

        Call BoxArb(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
            C_Result, C_LeftTail, C_RightTail)
        Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
    End Sub





    Private Function B3Arb(h As Arb) As Arb
        Return h * h * h - 1.5 * h * h + 0.5 * h
    End Function


    '{Approximation by Nagarsenker}
    Sub BetaflintodDis2Arb(p As Integer, b As ArbMat, c As ArbMat, x As Arb,
                          ByRef LeftTail As Arb, ByRef Righttail As Arb)
        Dim i As Integer
        Dim k, s, v1, v2, m, alpha As New Arb
        v1 = aflint.zero
        v2 = aflint.zero
        For i = 1 To p
            v1 = v1 + c(i) - b(i)
            'v2 = v2 + (c(i)) ^ 2 - (b(i)) ^ 2
            v2 = v2 + aflint.sqr(c(i)) - aflint.sqr(b(i))
        Next i
        m = (v2 - v1) / (2 * v1)
        k = aflint.t(0)
        For i = 1 To p
            k = k + B3Arb(b(i) - m) - B3Arb(c(i) - m)
        Next i
        alpha = (1 - v1) / 2
        s = (-2 * B3Arb((1 + v1) / 2) / k)
        'Console.WriteLine("s: {0}", s)
        s = aflint.sqrt(s)
        x = aflint.exp(aflint.log(x) / s)
        Dim df2 = s * m + alpha
        Console.WriteLine("x: {0}", x)

        Righttail = aflint.ibetac(v1, df2, 1 - x)

        LeftTail = 1 - Righttail
    End Sub



    '{Approximation by Nagarsenker}
    Function BetaflintodDisX2Arb(LeftTail As Arb, Righttail As Arb, p As Integer, b As ArbMat, c As ArbMat) As Arb
        Dim i As Integer
        Dim k, s, v1, v2, m, alpha As New Arb
        Dim X2, X, Y As New Arb
        Console.WriteLine("In BetaflintodDisX2Arb: ")
        v1 = aflint.zero
        v2 = aflint.zero
        For i = 1 To p
            v1 = v1 + c(i) - b(i)
            'v2 = v2 + (c(i)) ^ 2 - (b(i)) ^ 2
            v2 = v2 + aflint.sqr(c(i)) - aflint.sqr(b(i))
            'Console.WriteLine("j: {0}, b(i): {1}, c(i): {2}", i, b(i), c(i))
        Next i
        m = (v2 - v1) / (2 * v1)
        k = aflint.zero
        For i = 1 To p
            k = k + B3Arb(b(i) - m) - B3Arb(c(i) - m)
        Next i
        alpha = (1 - v1) / 2
        s = (-2 * B3Arb((1 + v1) / 2) / k)
        Console.WriteLine("s: {0}", s)
        s = aflint.sqrt(s)
        Dim df2 = s * m + alpha

        Call betadisxArb(LeftTail, Righttail, v1, df2, X, Y)

        X2 = aflint.exp(s * aflint.log(Y))
        Return X2

    End Function


    Sub NewTestWilksUArb()
        ArbPrec.SetDps(20)
        Console.WriteLine("Hello NewTestWilksUArb")
        Dim i, f1, n, p As Integer
        Dim LeftTail, Righttail As New Arb
        Dim LeftTail2, RightTail2 As New Arb
        'p = 4 ' number of variables
        'f1 = 7 - 1 ' number of groups
        'n = 20 - 7  ' n is sample size
        p = 4 ' number of variables
        f1 = 70 ' number of groups
        n = 10000  ' n is sample size
        LeftTail = aflint.t("0.99")
        'LeftTail = aflint.t("0.51")
        Righttail = 1 - LeftTail
        Dim b As New ArbMat
        Dim c As New ArbMat
        b.Resize(p + 1, 1)
        c.Resize(p + 1, 1)

        For i = 1 To p
            b(i) = (n - i + 1) / aflint.t(2)
            c(i) = b(i) + f1 / 2
            'Console.WriteLine("j: {0}, b(i): {1}, c(i): {2}", i, b(i), c(i))
        Next i
        Dim result2 = BetaflintodDisX2Arb(LeftTail, Righttail, p, b, c)
        Console.WriteLine("result2: {0}", result2)
        Dim resultL = -aflint.log(result2)
        Console.WriteLine("resultL: {0}", resultL)
        Dim resultM = -n * aflint.log(result2)
        Console.WriteLine("resultM: {0}", resultM)
        Call BetaflintodDis2Arb(p, b, c, result2, LeftTail2, RightTail2)
        Console.WriteLine("LeftTail2: {0}", LeftTail2)

        NewBetaflintodDistArb(LeftTail, Righttail, p, n / aflint.t(2), b, c, resultM)
    End Sub


    Sub NewBetaflintodDistArb(LeftTail As Arb, RightTail As Arb, k As Int32, n2 As Arb, bi As ArbMat, ci As ArbMat, resultM As Arb)
        Dim j As Int32
        Dim y As New ArbMat
        Dim xi As New ArbMat
        Dim eta As New ArbMat
        y.Resize(k + 4, 1)
        xi.Resize(k + 4, 1)
        eta.Resize(k + 4, 1)

        For j = 1 To k
            y(j) = n2
            xi(j) = bi(j) - n2
            eta(j) = ci(j) - bi(j) + xi(j)   'simplify later
            'Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}, xi(j): {3}", j, y(j), eta(j), xi(j))
        Next

        Console.WriteLine("")
        Console.WriteLine("Hello TestBoxDavis")
        Dim TargetError = aflint.t("1.0E-20")

        'TestBoxDavisArb("Quantile", "CHI2", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
        'Console.WriteLine("resultM: {0}", resultM)
        TestBoxDavisArb("PValue", "CHI2", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
        Console.WriteLine("LeftTail: {0}", LeftTail)


        'TestBoxDavisArb("Quantile", "CornishFisher", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
        'Console.WriteLine("resultM: {0}", resultM)
        TestBoxDavisArb("PValue", "CornishFisher", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
        Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail)

    End Sub


    Sub TestBoxDavisArb(C_Result As String, C_Algorithm As String, a As Int32, b As Int32, x As ArbMat, y As ArbMat,
                     xi As ArbMat, eta As ArbMat, ByRef z As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb, TargetError As Arb)
        Dim k, j, r, rsign, rmax As Int32
        Dim sum1, sum2, f, rho As New Arb
        Dim omega As New ArbMat


        If C_Algorithm = "CHI2" Then

            ' Calculate f
            sum1 = aflint.zero
            For k = 1 To a
                sum1 = sum1 + xi(k)
            Next
            sum2 = aflint.zero
            For j = 1 To b
                sum2 = sum2 + eta(j)
            Next
            f = -2 * (sum1 - sum2 - (a - b) / 2)
            Console.WriteLine("f: {0}", f)

            ' Calculate rho
            sum1 = aflint.zero
            For k = 1 To a
                sum1 = sum1 + aflint.bernpoly(xi(k), 2) / x(k)
            Next
            sum2 = aflint.t(0)
            For j = 1 To b
                sum2 = sum2 + aflint.bernpoly(eta(j), 2) / y(j)
            Next
            rho = 1 - (sum1 - sum2) / f
            Console.WriteLine("rho: {0}", rho)

            ' Calculate omega
            rmax = 40
            rsign = -1
            omega.Resize(rmax + 1, 1)

            For r = 1 To rmax
                rsign = -rsign
                sum1 = aflint.zero
                For k = 1 To a
                    'sum1 = sum1 + aflint.bernpoly((1 - rho) * x(k) + xi(k), r + 1) / ((rho * x(k)) ^ r)
                    sum1 = sum1 + aflint.bernpoly((1 - rho) * x(k) + xi(k), r + 1) / aflint.pow((rho * x(k)), r)
                Next
                sum2 = aflint.zero
                For j = 1 To b
                    sum2 = sum2 + aflint.bernpoly((1 - rho) * y(j) + eta(j), r + 1) / aflint.pow((rho * y(j)), r)
                Next
                omega(r) = rsign * (sum1 - sum2) / (r * (r + 1))
            Next

            If C_Result = "PValue" Then ' Get p-value
                Call GuptaArbNew(rmax, f, z * rho, rho, omega, TargetError, LeftTail)
            End If

            If C_Result = "Quantile" Then ' Get Quantile
                Call DavisPercentileArb(f, z, LeftTail, RightTail, rho, omega)
            End If

        End If


        If C_Algorithm = "CornishFisher" Then

            ' Calculate cumulants
            Console.WriteLine("")
            Console.WriteLine("Hello Calculate cumulants")

            rmax = 60
            Dim kappa As New ArbMat()
            kappa.resize(rmax + 1, 1)
            For r = 1 To rmax
                sum1 = aflint.zero
                For k = 1 To a
                    'sum1 = sum1 + ((-2 * x(k)) ^ r) * aflint.polygamma(r - 1, x(k) + xi(k))
                    sum1 = sum1 + aflint.pow((-2 * x(k)), r) * aflint.polygamma(r - 1, x(k) + xi(k))
                Next k
                sum2 = aflint.zero
                For j = 1 To b
                    'sum2 = sum2 + ((-2 * y(j)) ^ r) * aflint.polygamma(r - 1, y(j) + eta(j))
                    sum2 = sum2 + aflint.pow((-2 * y(j)), r) * aflint.polygamma(r - 1, y(j) + eta(j))
                Next j
                kappa(r) = sum1 - sum2
                'Console.WriteLine("r: {0}, kappa (r): {1}", r, kappa(r))
            Next r
            Dim mean = kappa(1)
            Dim sigma = aflint.sqrt(kappa(2))

            If C_Result = "Quantile" Then ' Get quantile
                Dim XX = ndisxArb(LeftTail, RightTail)
                Dim XAdj = CFArb_Continuous(rmax, XX, kappa, TargetError)
                z = mean + sigma * XAdj
            End If

            If C_Result = "PValue" Then ' Get p-value
                Console.WriteLine("")
                Dim fxTarget = (z - mean) / sigma
                Console.WriteLine("z: {0}, fxTarget: {1}", z, fxTarget)
                Dim x3Start = CF_up(fxTarget, kappa)
                Dim Result2 As Arb = InvCornArbContinuous(fxTarget, x3Start, kappa, rmax, TargetError)
                LeftTail = NdisArb(Result2)
                RightTail = NdisArb(-Result2)
            End If
        End If

    End Sub




End Module

