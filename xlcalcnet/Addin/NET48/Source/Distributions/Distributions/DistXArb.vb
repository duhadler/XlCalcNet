Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet


'
Public Module DistXArb


    Friend Const mp_ndisx As Int32 = 0
    Friend Const mp_cdisx As Int32 = 1
    Friend Const mp_fdisx As Int32 = 2

    Function gamma_p(a As Arb, x As Arb) As Arb
        Dim LeftTail, RightTail As New Arb
        gamma_inc_Arb(a, x, LeftTail, RightTail)
        Return LeftTail
    End Function


    Sub DemoGamma_Arb_p()
        Dim a, x As New Arb
        a = aflint.t("12123.1")
        x = aflint.t("11134.1")
        'a = aflint.t("1000000000000")
        'x = a
        'x = x - 150 * aflint.sqrt(x)
        Console.WriteLine("a: {0}", a)
        Console.WriteLine("x:  {0}", x)
        'Dim result1 = aflint.gamma_p_hyper(a, x)
        'Console.WriteLine("result1: {0}", result1)
        Dim result2 = aflint.gamma_p(a, x)
        Console.WriteLine("result2: {0}", result2)
        Dim result3 = gamma_p(a, x)
        Console.WriteLine("result3: {0}", result3)
    End Sub


    Function gamma_q(a As Arb, x As Arb) As Arb
        Dim LeftTail, RightTail As New Arb
        gamma_inc_Arb(a, x, LeftTail, RightTail)
        Return RightTail
    End Function


    Sub DemoGamma_q()
        Dim a, x As New Arb
        'a = aflint.t("5")
        'x = aflint.t("6")
        a = aflint.t("18")
        x = aflint.t("10")
        'Dim result1 = aflint.gamma_q_hyper(a, x)
        'Console.WriteLine("result1: {0}", result1)
        Dim result2 = aflint.gamma_q(a, x)
        Console.WriteLine("result2: {0}", result2)
        Dim result3 = gamma_q(a, x)
        Console.WriteLine("result3: {0}", result3)
    End Sub


    Sub gamma_inc_Arb(b As Arb, m As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim j As Integer, i As Integer
        Dim eps, k, sum0, sum1 As Arb
        Dim xsum As Arb, a0 As Arb, a1 As Arb, a2 As Arb
        Dim an As Arb, b0 As Arb, b1 As Arb, b2 As Arb, bn As Arb
        Dim MinRelError As Arb
        Dim swapped As Boolean
        MinRelError = aflint.epsilon()
        If (m <= aflint.t("0")) Then
            LeftTail = aflint.t(0)
            RightTail = aflint.t(1)
            Exit Sub
        End If
        k = aflint.gamma_p_derivative(b, m)
        If ((m <= aflint.t("6.0")) Or (m <= b)) Then
            swapped = True
            'Console.WriteLine("Using C3")
        Else
            swapped = False
            'Console.WriteLine("NOT Using C3")
        End If
        a0 = aflint.t(1)
        b0 = aflint.t(1)
        bn = aflint.t(0)
        j = 0
        sum0 = aflint.t(1)
        sum1 = aflint.t(1)
        If swapped Then
            k = k * m / b
            b1 = b + 1
            bn = b1
            a1 = -m
        Else
            b1 = m
            a1 = 1 - b
        End If
        Dim nord = 100000
        Dim aCoeff As New ArbMat
        Dim bCoeff As New ArbMat
        aCoeff.Resize(nord + 1, 1)
        bCoeff.Resize(nord + 1, 1)
        aCoeff(0) = a0
        aCoeff(1) = a1
        bCoeff(0) = b0
        bCoeff(1) = b1
        Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}", 0, a0, b0)
        Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}", 1, a1, b1)

        a1 = b1 + a1
        Do
            j = j + 1
            For i = 0 To 1
                If i = 1 Then
                    If swapped Then
                        an = -(b + j) * m
                        bn = bn + 1
                    Else
                        an = j + 1 - b
                        bn = m
                    End If
                Else
                    If swapped Then
                        an = j * m
                        bn = bn + 1
                    Else
                        an = aflint.t(j)
                        bn = aflint.t(1)
                    End If
                End If

                aCoeff(2 * j + i) = an
                bCoeff(2 * j + i) = bn
                a2 = bn * a1 + an * a0
                b2 = bn * b1 + an * b0
                Dim b2_inv = 1 / b2
                a2 = a2 * b2_inv
                a1 = a1 * b2_inv
                b1 = b1 * b2_inv
                b2 = aflint.t(1)
                a0 = a1
                a1 = a2
                b0 = b1
                b1 = b2
                a2.Rad = aflint.t(0)
                Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}, a2: {2}", 2 * j + i, an, bn, a2)
                If (i = 0) Then sum0 = a2 Else sum1 = a2
            Next i
            'xsum = aflint.union(sum0, sum1)
            xsum = (sum0 + sum1) / 2
            eps = (sum0 - sum1) / xsum
            'Console.WriteLine("sum{0}: {1}, sum{2}: {3},  eps: {4}, xsum: {5}", 2 * j - 2, sum0, 2 * j - 1, sum1, eps, xsum)
        Loop Until ((aflint.abs(eps) < MinRelError) And ((j Mod 2) = 0))
        'Console.WriteLine("j: {0,4}", j)
        'Console.WriteLine("1/xsum: {0}", 1 / xsum)

        Dim Fk1 = aflint.t("0")
        For i = 2 * j + 1 To 0 Step -1
            Fk1 = aCoeff(i) / (bCoeff(i) + Fk1)
            'Console.WriteLine("i: {0}, aCoeff(i): {1}, bCoeff(i): {2}, Fk1: {3}", i, aCoeff(i), bCoeff(i), Fk1)
        Next
        'Console.WriteLine("Fk1:    {0}", Fk1)

        Dim Fk0 = aflint.t("0")
        For i = 2 * j + 0 To 0 Step -1
            Fk0 = aCoeff(i) / (bCoeff(i) + Fk0)
            'Console.WriteLine("i: {0}, aCoeff(i): {1}, bCoeff(i): {2}, Fk0: {3}", i, aCoeff(i), bCoeff(i), Fk0)
        Next
        'Console.WriteLine("Fk0:    {0}", Fk0)

        'Dim Fk = aflint.union(Fk1, Fk0)
        Dim Fk = Fk1 + Fk0
        RightTail = k * Fk
        LeftTail = 1 - RightTail
        If swapped Then
            Dim temp = LeftTail
            LeftTail = RightTail
            RightTail = temp
            'aflint.swap(LeftTail, RightTail)
        End If
    End Sub


    Sub cdis2Arb(n As Arb, X As Arb, ByRef LeftTail As Arb,
      ByRef RightTail As Arb, ByRef density As Arb)
        gamma_inc_Arb(n / 2, X / 2, LeftTail, RightTail)
        density = DistFromBoost.Arb_ChiSquare_pdf(X, n, False)
    End Sub







    Sub beta_inc_Arb_(aa As Arb, bb As Arb, qq As Arb,
pp As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb, ByRef density As Arb)
        Dim swapped As Boolean
        Dim j As Integer, i As Integer
        Dim eps As Arb, qp As Arb
        Dim xsum, sum0, sum1, n As Arb
        Dim a0 As Arb, a1 As Arb, a2 As Arb, an As Arb
        Dim b0 As Arb, b1 As Arb, b2 As Arb, bn As Arb
        Dim x As Arb, limit As Arb, MinRelError As Arb
        Dim a, b, p, q As New Arb
        a = aa + 0
        b = bb + 0
        q = qq + 0
        p = pp + 0
        'Console.WriteLine("a: {0}, b: {1}", a, b)
        'Console.WriteLine("q: {0}, p: {1}", q, p)
        MinRelError = 1 * aflint.epsilon()
        If (q <= aflint.t("0.0")) Then
            LeftTail = aflint.t(0)
            RightTail = aflint.t(1)
            Exit Sub
        End If
        If (p <= aflint.t("0.0")) Then
            LeftTail = aflint.t(1)
            RightTail = aflint.t(0)
            Exit Sub
        End If
        density = aflint.ibeta_derivative(a, b, q)

        'Dim BBB = aflint.floor(b)
        'Console.WriteLine("BBB: {0}", BBB)
        qp = q / p
        b0 = aflint.t(1)
        b1 = a + 1
        a0 = aflint.t(1)
        a1 = -(b - 1) * qp
        n = a + b - 1
        j = 0
        bn = a + 1
        sum0 = aflint.t(1)
        sum1 = aflint.t(1)
        Dim nord = 100000
        Dim aCoeff As New ArbMat
        Dim bCoeff As New ArbMat
        aCoeff.Resize(nord + 1, 1)
        bCoeff.Resize(nord + 1, 1)

        aCoeff(0) = a0
        aCoeff(1) = a1
        bCoeff(0) = b0
        bCoeff(1) = b1
        'Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}", 0, a0, b0)
        'Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}", 1, a1, b1)

        a1 = a1 + b1
        Do
            j = j + 1
            For i = 0 To 1

                If i = 1 Then
                    an = -(a + j) * (b - j - 1) * qp
                    bn = bn + 1
                Else
                    an = j * (n + j) * qp
                    bn = bn + 1
                End If

                aCoeff(2 * j + i) = an
                bCoeff(2 * j + i) = bn
                a2 = bn.Mid() * a1.Mid() + an.Mid() * a0.Mid()
                b2 = bn.Mid() * b1.Mid() + an.Mid() * b0.Mid()
                Dim b2_inv = 1 / b2.Mid()
                a2 = a2 * b2_inv
                a1 = a1 * b2_inv
                b1 = b1 * b2_inv
                b2 = aflint.t(1)
                a0 = a1
                a1 = a2
                b0 = b1
                b1 = b2
                a2.Rad = aflint.t(0)
                'Console.WriteLine("2*j+{0}: {1}, an: {2}, bn: {3}", i, 2 * j + i, an, bn)
                If (i = 0) Then sum0 = a2 Else sum1 = a2
            Next i
            'xsum = aflint.union(sum0, sum1)
            xsum = (sum0 + sum1) / 2
            eps = (sum0 - sum1) / xsum
            'Console.WriteLine("sum{0}: {1}, sum{2}: {3},  eps: {4}, xsum: {5}", 2 * j - 2, sum0, 2 * j - 1, sum1, eps, xsum)
        Loop Until ((aflint.abs(eps) < MinRelError) And ((j Mod 2) = 0))
        Console.WriteLine("j: {0,4}", j)
        'Console.WriteLine("1/xsum: {0}", 1 / xsum)

        Dim Fk1 = aflint.t("0")
        For i = 2 * j + 1 To 0 Step -1
            Fk1 = aCoeff(i) / (bCoeff(i) + Fk1)
            'Console.WriteLine("i: {0}, aCoeff(i): {1}, bCoeff(i): {2}, Fk1: {3}", i, aCoeff(i), bCoeff(i), Fk1)
        Next
        'Console.WriteLine("Fk1:    {0}", Fk1)

        Dim Fk0 = aflint.t("0")
        For i = 2 * j + 0 To 0 Step -1
            Fk0 = aCoeff(i) / (bCoeff(i) + Fk0)
            'Console.WriteLine("i: {0}, aCoeff(i): {1}, bCoeff(i): {2}, Fk0: {3}", i, aCoeff(i), bCoeff(i), Fk0)
        Next
        'Console.WriteLine("Fk0:    {0}", Fk0)

        'Dim Fk = aflint.union(Fk1, Fk0)
        Dim Fk = (Fk1 + Fk0) / 2
        LeftTail = Fk * density * q / a
        RightTail = 1 - LeftTail

    End Sub


    Sub beta_inc_Arb(a As Arb, b As Arb, q As Arb, p As Arb, ByRef L As Arb, ByRef R As Arb, ByRef density As Arb)
        Dim NeedToConvert As Boolean, Temp As New Arb
        NeedToConvert = Not ((b - 0.5) <= (a + b - 1) * p)
        Console.WriteLine("NeedToConvert: {0}", NeedToConvert)
        If NeedToConvert Then
            Temp = a : a = b : b = Temp
            Temp = q : q = p : p = Temp
        End If
        beta_inc_Arb_(a, b, q, p, L, R, density)
        If NeedToConvert Then
            Temp = L : L = R : R = Temp
        End If
    End Sub


    Sub betadisArb(a As Arb, b As Arb, q As Arb, p As Arb, ByRef L As Arb, ByRef R As Arb, ByRef density As Arb)
        beta_inc_Arb(a, b, q, p, L, R, density)
    End Sub


    Function ibeta(a As Arb, b As Arb, x As Arb) As Arb
        Dim LeftTail, RightTail, density, y As New Arb
        y = 1 - x
        beta_inc_Arb(a, b, x, y, LeftTail, RightTail, density)
        Return LeftTail
    End Function



    Function ibetac(a As Arb, b As Arb, x As Arb) As Arb
        Dim LeftTail, RightTail, density, y As New Arb
        y = 1 - x
        beta_inc_Arb(a, b, x, y, LeftTail, RightTail, density)
        Return RightTail
    End Function



    Sub Demo_arb_ibeta()
        Dim a, b, x As New Arb
        'x = aflint.t("0.52")
        'a = aflint.t("1124.1")
        'b = aflint.t("1114.1")

        a = aflint.t("50000000.1")
        b = aflint.t("50000000.1")
        'x = aflint.t("0.4991")
        x = aflint.t("0.5009")
        Console.WriteLine("a: {0}, b: {1}, x: {2}", a, b, x)

        'Dim result1 = aflint.ibeta_hyper(a, b, x)
        'Console.WriteLine("result1: {0}", result1)
        Dim result2 = aflint.ibeta(a, b, x)
        Console.WriteLine("result2: {0}", result2)
        Dim result3 = ibeta(a, b, x)
        Console.WriteLine("ibeta : {0}", result3)
        Dim result4 = ibetac(a, b, x)
        Console.WriteLine("ibetac: {0}", result4)

    End Sub







    Function GetS3(n As Int32) As ArbMat
        Dim S3 As New ArbMat
        S3.Resize(3 * n + 3, n + 3)
        S3(0, 0) = aflint.t(1)
        For k = 3 To 3 * n
            S3(k, 1) = aflint.t(1)
        Next
        For j = 2 To n
            For k = 3 * j - 1 To 3 * n
                'S3(k + 1, j) = j * S3(k, j) + aflint.bin_ui_ui(k, 2) * S3(k - 2, j - 1)
                S3(k + 1, j) = j * S3(k, j) + aflint.real_binomial(k, 2) * S3(k - 2, j - 1)
            Next
        Next
        Return S3
    End Function

    Function GetPK(n As Int32, x As Arb) As ArbMat
        Dim pk As New ArbMat
        pk.Resize(n + 3, 1)
        pk(0) = aflint.t(1)
        pk(1) = -x
        For k = 1 To n
            pk(k + 1) = (pk(k - 1) - x * pk(k)) / (k + 1)
        Next
        Return pk
    End Function

    Function GetQK(n As Int32, x As Arb) As ArbMat
        Dim qk As New ArbMat
        qk.Resize(n + 2, 1)
        qk(0) = aflint.t(0)
        qk(1) = aflint.t(-1)
        For k = 1 To n
            qk(k + 1) = (qk(k - 1) - x * qk(k)) / (k + 1)
        Next
        Return qk
    End Function

    Function d0(x As Arb) As Arb
        Dim a1 = aflint.sqrt(0.5 * aflint.pi())
        Dim a2 = aflint.exp(0.5 * x * x)
        Dim a3 = aflint.erfc(x * aflint.sqrt(0.5))
        Dim result = a1 * a2 * a3
        Return result
    End Function


    Sub demoParis()
        Dim z, a, x, f, d, z2, result As New Arb
        Dim UseLeftTail As Boolean = True
        a = aflint.t(1000000)
        z = a - 10000
        z2 = aflint.sqrt(z)
        x = (z - a) / z2
        f = aflint.pow(z, a - 0.5) * aflint.exp(-z) / aflint.gamma(a)
        If x > 0 Then UseLeftTail = False
        d = d0(aflint.abs(x))


        Dim n = 5
        Dim ak, bk As New ArbMat
        ak.Resize(n + 3, 1)
        bk.Resize(n + 3, 1)

        Dim S3 = GetS3(4 * n)
        Dim pk = GetPK(4 * n, x)
        Dim qk = GetQK(4 * n, x)
        For k = 0 To n
            Dim sumak = aflint.t("0")
            Dim sumbk = aflint.t("0")
            'Console.WriteLine("k: {0}", k)
            Dim jsign = 1
            For j = 0 To k
                Dim s = S3(k + 2 * j, j)
                Dim p = pk(k + 2 * j)
                Dim q = qk(k + 2 * j)
                sumak = sumak + jsign * s * p
                sumbk = sumbk + jsign * s * q
                'Console.WriteLine("j: {0,2}, k+2*j: {1,2}, jsign: {2}, s: {3}, p: {4}, q: {4}", k, k + 2 * j, jsign, s, p, q)
                jsign = -jsign
            Next
            ak(k) = sumak
            bk(k) = sumbk
        Next
        Dim aksum = aflint.t("0")
        Dim bksum = aflint.t("0")
        Dim zk2 = aflint.t("1")

        Console.WriteLine("a: {0}", a)
        Console.WriteLine("z: {0}", z)
        Console.WriteLine("x: {0}", x)
        Console.WriteLine("d: {0}", d)
        For k = 0 To n
            aksum = aksum + ak(k) / zk2
            bksum = bksum + bk(k) / zk2
            zk2 = zk2 * z2
            Console.WriteLine("k: {0}, d*aksum: {1}, bksum: {2}", k, d * aksum, bksum)
        Next
        If UseLeftTail Then
            result = f * (d * aksum + bksum)
        Else
            result = f * (d * aksum - bksum)
        End If

        Console.WriteLine("result:   {0}", result)

        Dim LeftTail, RightTail As New Arb
        gamma_inc_Arb(a, z, LeftTail, RightTail)
        Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail)

    End Sub






    ' Nemes 2016, Incomplete beta function for large a and a/b > 20; for x less than the median
    Sub demoNemes()
        Dim a, b, x, xi, sum, scale, result As New Arb
        ArbPrec.SetDps(160)
        'a = aflint.t("5000.1")
        'b = aflint.t("4000.1")
        'x = aflint.t("0.4351")

        a = aflint.t("5000000.1")
        b = aflint.t("25000.1")
        x = aflint.t("0.99481")
        Console.WriteLine("a: {0}, b: {1}, x: {2}", a, b, x)

        ArbPrec.SetDps(60)
        a = a.Mid
        b = b.Mid
        x = x.Mid
        xi = -aflint.log(x).Mid
        scale = aflint.gamma(a + b) / aflint.gamma(a)
        Console.WriteLine("scale:  {0}", scale)
        Console.WriteLine("xi:  {0}", xi)
        Console.WriteLine("a*xi:  {0}", a * xi)
        Dim NN = 50
        Dim Fk, dk As New ArbMat
        Fk.resize(NN + 3, 1)
        dk.resize(NN + 3, 1)

        Dim Q = aflint.gamma_q(b, a * xi)
        Console.WriteLine("Q:  {0}", Q)
        Fk(0) = (aflint.pow(a, -b) * Q).Mid
        Fk(1) = ((b - a * xi) * Fk(0) / a + (aflint.pow(xi, b) * aflint.exp(-a * xi)) / (a * aflint.gamma(b))).mid

        dk(0) = (aflint.pow((1 - x) / xi, b - 1)).Mid
        dk(1) = ((x * xi + x - 1) * (b - 1) * dk(0) / ((1 - x) * xi)).mid

        ArbPrec.SetDps(160)
        Dim ra = (1 / a).Mid

        For n = 1 To NN - 1
            'Fk(n + 1) = ((n + b - a * xi) * Fk(n) + n * xi * Fk(n - 1)) / a
            Fk(n + 1) = (((n + b - a * xi) * Fk(n) + n * xi * Fk(n - 1)) * ra).mid
            Console.WriteLine("Fk(n + 1):  {0}", Fk(n + 1))
        Next

        Console.WriteLine("")
        ArbPrec.SetDps(160)
        For n = 0 To NN - 2
            Dim sum1 = aflint.t("0")
            Dim sum2 = aflint.t("0")
            Dim sum3 = aflint.t("0")
            For m = 0 To n
                sum1 += ((m + 1) * (n - 2 * m + 1 + (m - n - 1) / (b - 1)) * dk(m + 1) * dk(n - m + 1)).mid
                sum2 += ((m + 1) * (n - 2 * m - 2 - xi + (m - n) / (b - 1)) * dk(m + 1) * dk(n - m)).mid
                sum3 += ((1 - m - b) * dk(m) * dk(n - m)).mid
            Next
            dk(n + 2) = ((xi * sum1 + sum2 + sum3) / (xi * (n + 1) * (n + 2) * dk(0))).mid
            Console.WriteLine("dk(n + 2):  {0}", dk(n + 2))
        Next
        ArbPrec.SetDps(40)
        sum = aflint.t(0)
        Dim LastSummand = aflint.t(0)
        'For i = 0 To 30
        For i = 0 To 50
            Dim summand = (dk(i) * Fk(i)) * scale
            sum = sum + dk(i) * Fk(i)
            Console.WriteLine("i: {0}, sum: {1}, sc: {2}, dk(i): {3}, Fk(i): {4}", i, summand, sum * scale, dk(i), Fk(i))
            If (i > 6) And (aflint.abs(summand) > aflint.abs(LastSummand)) Then
                Console.WriteLine("No Convergence!")
                Exit For
            End If
            LastSummand = summand
        Next
        result = sum * scale
        Console.WriteLine("result:  {0}", result)

        Dim result3 = ibeta(a, b, x)
        Console.WriteLine("result3: {0}", result3)
        Console.WriteLine("result3: {0}", 1 - result3)

    End Sub




















    'Sub betadisArb_old(ByVal a As Arb, ByVal b As Arb, ByVal Q As Arb, ByVal p As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb, ByRef density As Arb)
    '    Dim fit As Boolean
    '    Dim j As Integer, i As Integer
    '    Dim sum(0 To 1) As Arb
    '    Dim eps As Arb, qp As Arb, k As Arb
    '    Dim xsum As Arb
    '    Dim a0 As Arb, A1 As Arb, A2 As Arb, an As Arb
    '    Dim b0 As Arb, b1 As Arb, b2 As Arb, bn As Arb
    '    Dim X As Arb, limit As Arb, MinRelError As Arb
    '    MinRelError = aflint.t("1E-30")
    '    If (Q <= aflint.t("0.0")) Then
    '        LeftTail = 0
    '        RightTail = 1
    '        density = 0
    '        Exit Sub
    '    End If
    '    If (p <= aflint.t("0.0")) Then
    '        LeftTail = 1
    '        RightTail = 0
    '        density = 0
    '        Exit Sub
    '    End If
    '    k = aflint.lgamma(a + b) - aflint.lgamma(a) - aflint.lgamma(b)
    '    'k = aflint.l - Lnbeta(a, b)
    '    k = k + (b - 1) * aflint.log(p) + (a - 1) * aflint.log(Q)
    '    density = aflint.exp(k)
    '    X = (b * Q) / (a * p)
    '    limit = 4.5 - a
    '    If limit < aflint.t("1") Then
    '        limit = 1
    '    End If
    '    fit = (X < limit)
    '    If Not fit Then
    '        Call SwapTails(a, b)
    '        Call SwapTails(p, Q)
    '    End If
    '    qp = Q / p
    '    a0 = 1
    '    A1 = a + 1 - (b - 1) * qp
    '    b0 = 1
    '    b1 = a + 1
    '    j = 0
    '    bn = a + 1
    '    sum(0) = 1
    '    sum(1) = 1
    '    Do
    '        j = j + 1
    '        For i = 0 To 1
    '            If i = 1 Then
    '                an = -(a + j) * (b - j - 1) * qp
    '            Else
    '                an = j * (a + b - 1 + j) * qp
    '            End If
    '            bn = bn + 1
    '            A2 = bn * A1 + an * a0
    '            b2 = bn * b1 + an * b0
    '            A2 = A2 / b2
    '            A1 = A1 / b2
    '            b1 = b1 / b2
    '            b2 = 1
    '            a0 = A1
    '            A1 = A2
    '            b0 = b1
    '            b1 = b2
    '            A2.rad = 0

    '            sum(i) = A2
    '        Next i
    '        'xsum = (sum(0) + sum(1)) * 0.5
    '        xsum = aflint.union(sum(0), sum(1))
    '        eps = (sum(0) - sum(1)) / xsum
    '        Console.WriteLine("j: {0}, sum(0): {1}, sum(1): {2},  eps: {3}, xsum: {4}", j, sum(0), sum(1), eps, xsum)
    '    Loop Until (aflint.abs(eps) < MinRelError)
    '    Console.WriteLine("j: {0}", j)
    '    RightTail = density * Q / (a * xsum)
    '    LeftTail = 1 - RightTail
    '    If fit Then
    '        Call SwapTails(LeftTail, RightTail)
    '    End If
    'End Sub




    Sub SwapTails(x As Arb, y As Arb)
        Dim temp = x
        y = x
        x = temp
        'aflint.swap(x, y)
    End Sub

    Function FdisArb(m As Arb, n As Arb, a As Arb) As Arb
        Dim X As Arb, y As Arb, p As Arb, Q As Arb
        Dim density As Arb, LeftTail As Arb, RightTail As Arb
        If a <= 0 Then
            Return aflint.t(0)
            Exit Function
        End If
        X = m * a / (m * a + n)
        y = n / (m * a + n)
        p = m / 2
        Q = n / 2
        betadisArb(p, Q, X, y, LeftTail, RightTail, density)
        Return RightTail
    End Function

    'Sub Fdis_aArb(ByVal m As Arb, ByVal n As Arb, ByVal a As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
    '    Dim X As Arb, y As Arb, p As Arb, Q As Arb
    '    Dim density As Arb
    '    If a <= 0 Then
    '        LeftTail = 0
    '        RightTail = 1
    '        Exit Sub
    '    End If
    '    X = m * a / (m * a + n)
    '    y = n / (m * a + n)
    '    p = m / 2
    '    Q = n / 2
    '    Call betadis(p, Q, X, y, LeftTail, RightTail, density)
    'End Sub



    'Function tdisArb(ByVal n As Arb, ByVal t As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb) As Arb
    '    Dim temp As Arb
    '    If t = 0 Then
    '        LeftTail = 0.5
    '        RightTail = 0.5
    '        Return 0.5
    '        Exit Function
    '    End If
    '    Call Fdis_a(1, n, t * t, LeftTail, RightTail)
    '    RightTail = RightTail / 2
    '    LeftTail = 1 - RightTail
    '    'Debug.Print LeftTail, RightTail
    '    If t < 0 Then
    '        temp = LeftTail
    '        LeftTail = RightTail
    '        RightTail = temp
    '    End If
    '    Return LeftTail
    'End Function





    Function tdensArb(n As Arb, X As Arb) As Arb
        Dim C As Arb, h As Arb
        C = (1 + X * X / n)
        h = aflint.exp(aflint.lgamma((n + 1) / 2) - aflint.lgamma(n / 2)) / aflint.sqrt(aflint.pi()) / aflint.sqrt(n)
        'Return h * C ^ (-(n / 2 + 1 / 2))
        Return h * aflint.pow(C, (-(n / 2 + 1 / 2)))
    End Function



    Function cdisOwenArb(n As Long, X As Arb) As Arb
        Dim C As Arb, F As Arb, k As Long, i As Long
        C = -aflint.exp(-X / 2)
        F = aflint.t(1)
        k = n Mod 2
        If k <> 0 Then
            C = C * aflint.sqrt(2 * X / aflint.pi())    ' C=ndens(x)
            F = 1 - 2 * aflint.ndis(-aflint.sqrt(X))
        End If
        k = k + 2
        For i = k To n Step 2
            F = F + C
            C = C * X / i
        Next i
        Return F
    End Function


    Function tdisOwen(X As Arb, n As Long) As Arb
        Dim a As Arb, b As Arb, C As Arb, F As Arb, k As Long, i As Long
        a = X / aflint.sqrt(n)
        b = 1 + a * a
        k = n Mod 2
        If k <> 0 Then
            C = a / (b * aflint.pi())
            F = 0.5 + aflint.atan(a) / aflint.pi()
        Else
            C = a / (2 * aflint.sqrt(b))
            F = aflint.t(0.5)
        End If
        k = k + 2
        For i = k To n Step 2
            F = F + C
            C = C * (1 - aflint.t("1") / i) / b
        Next i
        Return F
    End Function


    Function FdisOwenArb(m As Long, n As Long, X As Arb) As Arb
        Dim U As Arb, sum As Arb, a As Arb, z As Arb
        Dim result As Arb, i As Long, k As Long
        k = m Mod 2
        If k = 0 Then
            z = n / (n + m * X)
            'result = z ^ (n / 2)
            result = aflint.pow(z, (n / 2))
            If m > 2 Then
                U = 1 - z
                sum = aflint.t(1) : a = aflint.t(1)
                For i = 1 To (m - 2) \ 2
                    a = a * U * (2 * i + n - 2) / (2 * i)
                    sum = sum + a
                Next i
                result = result * sum
            End If
        Else
            z = aflint.sqrt(m * X)
            result = 2 * tdisOwen(-z, n)
            If m > 1 Then
                U = z * z / (z * z + n)
                sum = z : a = z
                For i = 2 To (m - 1) \ 2
                    a = a * U * (2 * i + n - 3) / (2 * i - 1)
                    sum = sum + a
                Next i
                result = result + 2 * sum * tdensArb(aflint.t(n), z)
            End If
        End If
        Return result
    End Function


















    Function AdjustSignArb(UseLeftTail As Boolean, x As Arb) As Arb
        If (UseLeftTail) Then Return x Else Return -x
    End Function


    Sub BrentArb(UseLeftTail As Boolean, IsExact As Boolean, IsGLM As Boolean, proc As Int32,
                               ByRef a As Arb, ByRef b As Arb, fa As Arb, fb As Arb,
                               eps As Arb, LogTarget As Arb, Df1 As Arb, Df2 As Arb, t1 As Arb, omega As Arb)
        Console.WriteLine("In BrentArb")
        ArbPrec.SetDps(60)
        Dim c As New Arb, d As New Arb, e As New Arb, tol As New Arb ', eps As New Arb
        Dim s As New Arb, p As New Arb, q As New Arb, r As New Arb, xs As New Arb
        Dim fc As New Arb, m As New Arb
        Dim iter As Long, maxiter As Long
        Dim LogRefTail As New Arb
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
            If aflint.abs(fc) < aflint.abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * aflint.abs(b) : m = (c - b) / 2  'Tolerance
            If (aflint.abs(m) > tol) And (aflint.abs(fb) > 0) Then
                If (aflint.abs(e) < tol) Or (aflint.abs(fa) <= aflint.abs(fb)) Then
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
                    If (2 * p < 3 * m * q - aflint.abs(tol * q)) And (p < aflint.abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If aflint.abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            Select Case proc
                Case mp_ndisx : LogRefTail = DistFromBoost.Arb_Normal_CDF(b, aflint.t(0), aflint.t(1), UseLeftTail, True)
                Case mp_cdisx : LogRefTail = DistFromBoost.Arb_ChiSquare_CDF(b, Df1, UseLeftTail, True)
                Case mp_fdisx : LogRefTail = DistFromBoost.Arb_F_CDF(b, Df1, Df2, UseLeftTail, True)
                Case Else : LogRefTail = aflint.nan()
            End Select
            fb = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, aflint.Abs(m): {5}", iter, a, b, fa, fb, aflint.abs(m))
        End While
Finish:
        'Console.WriteLine("final: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}", iter, a, b, fa, fb)
        'xs = aflint.union(a, b)
        xs = (a + b) / 2
        'Console.WriteLine("xs: {0}", xs)
        b = xs
        ArbPrec.SetDps(40)
    End Sub




    Function Wichura(Q As Double, r0 As Double) As Double
        Console.WriteLine("In Wichura, Q:{0}, r0:{1}", Q, r0)
        Dim split1 As Double = 0.425
        Dim split2 As Double = 5.0
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

        If (Math.Abs(Q) <= split1) Then
            'Console.WriteLine("in abs(Q) <= split1")
            r = const1 - Q * Q
            ppnd16 = Q * (((((((A7 * r + a6) * r + A5) * r + a4) * r + a3) * r + A2) * r + A1) * r + a0) /
                     (((((((B7 * r + B6) * r + B5) * r + b4) * r + B3) * r + b2) * r + b1) * r + 1)
            Return ppnd16
        Else
            r = r0
            If (r <= split2) Then
                'Console.WriteLine("in r <= split2")
                r = r - const2
                ppnd16 = (((((((C7 * r + c6) * r + c5) * r + c4) * r + c3) * r + c2) * r + C1) * r + C0) /
                 (((((((D7 * r + D6) * r + D5) * r + D4) * r + D3) * r + d2) * r + d1) * r + 1)
            Else
                'Console.WriteLine("in r > split2")
                r = r - split2
                ppnd16 = (((((((E7 * r + E6) * r + E5) * r + E4) * r + E3) * r + e2) * r + e1) * r + E0) /
                  (((((((f7 * r + f6) * r + f5) * r + f4) * r + f3) * r + f2) * r + f1) * r + 1)
            End If
            If Q < 0 Then ppnd16 = -ppnd16
            Return ppnd16
        End If
    End Function



    Function ndisxArb_approx(LeftTailTarget As Arb, RightTailTarget As Arb) As Arb
        Dim RefTailTarget, result As New Arb
        Dim swapped As Boolean = False
        If LeftTailTarget < RightTailTarget Then
            RefTailTarget = LeftTailTarget
            swapped = True
        Else
            RefTailTarget = RightTailTarget
        End If
        If RefTailTarget < aflint.t("1.0E-3084") Then
            ' this solves (approximately) for x the equation  Q(x) = (1/x) * ndens(x)
            Dim logRefTail = aflint.log(RefTailTarget)
            Dim c1 = logRefTail + 0.918938533204673  ' + ln(1/sqrt(2*pi))
            Dim v1 = aflint.t("4.78")  ' 4.78 = log(ndisx(p)), where p = 1.0E-3084 is the crossover point from the Wichura approximation
            Dim d1 = v1 + c1
            d1 = -2 * d1
            d1 = aflint.sqrt(d1)
            v1 = aflint.log(d1)
            d1 = v1 + c1
            d1 = -2 * d1
            d1 = aflint.sqrt(d1)
            result = d1
        Else
            Dim Q, r0 As New Arb
            Q = 0.5 - RefTailTarget
            If (aflint.abs(Q) > 0.425) Then
                r0 = aflint.sqrt(-aflint.log(RefTailTarget))
            End If
            Console.WriteLine("Q:{0}", Q)
            Dim Q_ As Double = Q.AsDouble()
            Console.WriteLine("Q.AsDouble(): {0}", Q_)
            result = aflint.t(Wichura(Q.AsDouble, r0.AsDouble))
            Console.WriteLine("result: {0}", result)
        End If
        If swapped Then result = -result
        Return result
    End Function


















    Function NdisArb(x As Arb) As Arb
        Return aflint.ndis(x)
    End Function


    Function NdensArb(x As Arb) As Arb
        Return aflint.ndens(x)
    End Function


    Function ndisxArb(LeftTail As Arb, RightTail As Arb) As Arb
        Console.WriteLine("L:{0}, R:{1}", LeftTail, RightTail)
        Dim x1, LogTarget, LogRefTail, Factor As New Arb
        Dim UseLeftTail As Boolean = True
        If LeftTail > aflint.t("0.5") Then UseLeftTail = False
        'Dim eps = aflint.t("1E-40")
        Dim eps = aflint.epsilon()
        If UseLeftTail Then LogTarget = aflint.log(LeftTail) Else LogTarget = aflint.log(RightTail)

        x1 = ndisxArb_approx(LeftTail, RightTail)
        Console.WriteLine("x1: {0}", x1)
        LogRefTail = DistFromBoost.Arb_Normal_CDF(x1, aflint.t(0), aflint.t(1), UseLeftTail, True)
        Dim L1 = x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail)

        Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = +1 Else LSign = -1
        If Not (UseLeftTail) Then
            Factor = aflint.t("0.9999999")
            If F_L1 > 0 Then Factor = aflint.t("1.0000001")
        Else
            Factor = aflint.t("1.0000001")
            If F_L1 > 0 Then Factor = aflint.t("0.9999999")
        End If
        Console.WriteLine("L1: {0}, RefTail: {1}, LogRefTail: {2}, F_L1: {3}", L1, aflint.exp(LogRefTail), LogRefTail, F_L1)

        Dim count As Int32 = 1
        Do
            count = count + 1
            L1 = L2 : F_L1 = F_L2
            L2 = L1 * Factor
            LogRefTail = DistFromBoost.Arb_Normal_CDF(L2, aflint.t(0), aflint.t(1), UseLeftTail, True)
            F_L2 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail)
            Console.WriteLine("L2: {0}, RefTail: {1}, LogRefTail: {2}, F_L2: {3}", L2, aflint.exp(LogRefTail), LogRefTail, F_L2)
            Factor = Factor * Factor
        Loop Until F_L2 * LSign < 0
        'Loop Until count > 10


        BrentArb(UseLeftTail, True, True, mp_ndisx, L1, L2, F_L1, F_L2, eps, LogTarget, aflint.t(0), aflint.t(0), aflint.t(0), aflint.t(0))
        Return L2
    End Function





    Function cdisx_approxArb(LeftTail As Arb, RightTail As Arb, n As Arb) As Arb
        Dim t As New Arb, d As New Arb, k As New Arb, a As New Arb, result As New Arb, UseLambert As Boolean
        Dim h As New Arb, L As New Arb, mean As New Arb, stdev As New Arb, u As New Arb
        Dim m As New Arb, m2 As New Arb, m3 As New Arb, g As New Arb, z As New Arb
        If (n < 1) Then n = aflint.t(1)
        UseLambert = True
        a = 1 / (0.5 * (n + 2) - 1)
        k = aflint.lgamma(0.5 * (n + 2))
        d = a * (aflint.log(LeftTail) + k)
        t = -a * aflint.exp(LeftTail + d)
        'Console.WriteLine("t :{0}", t)
        If aflint.abs(t) > aflint.t("0.1") Then UseLambert = False
        If UseLambert Then
            'Console.WriteLine("UseLambert")
            result = -(((((125 * t - 64) * t + 36) * t - 24) * t + 24) * t) / (12 * a)  'Result = -2 * LambertW(t) / a
        Else
            'Console.WriteLine("UseCanal")
            z = ndisxArb_approx(LeftTail, RightTail)
            m = 1 / n : m2 = m * m : m3 = m2 * m
            mean = (14580 - 1944 * m - 189 * m2 + 200 * m3) / 17496
            stdev = aflint.sqrt(aflint.abs(648 * m + 72 * m2 - 37 * m3)) / 108
            g = aflint.sqrt(0.5 * m3) / 162
            z = z - g + (z * g) * (z - (2 * z * z - 5) * g)
            L = 6 * (z * stdev + mean)
            h = aflint.cbrt(2 * (L + aflint.sqrt(13 + L * (L - 5))) - 5)
            u = 0.5 + 0.5 * h - 1.5 / h
            u = u * u * u
            u = u * u
            'Console.WriteLine("u :{0}", u)
            result = n * u
        End If
        'Console.WriteLine("chisquare quantile: {0} ", result)
        Return aflint.abs(result)
    End Function



    Function cdisxArb(LeftTail As Arb, RightTail As Arb, Df1 As Arb) As Arb
        Dim x1, LogTarget, LogRefTail As New Arb
        Dim UseLeftTail As Boolean = True
        If LeftTail > aflint.t("0.5") Then UseLeftTail = False
        Dim eps = aflint.t("1E-40")
        If UseLeftTail Then LogTarget = aflint.log(LeftTail) Else LogTarget = aflint.log(RightTail)

        x1 = cdisx_approxArb(LeftTail, RightTail, Df1)

        LogRefTail = DistFromBoost.Arb_ChiSquare_CDF(x1, Df1, UseLeftTail, True)
        Dim L1 = x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail)

        Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = +1 Else LSign = -1
        Dim Factor = 0.9
        If F_L1 > 0 Then Factor = 1.1
        Console.WriteLine("L1: {0}, RefTail: {1}, LogRefTail: {2}, F_L1: {3}", L1, aflint.exp(LogRefTail), LogRefTail, F_L1)

        Do
            L1 = L2 : F_L1 = F_L2
            L2 = L1 * Factor
            LogRefTail = DistFromBoost.Arb_ChiSquare_CDF(L2, Df1, UseLeftTail, True)
            F_L2 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail)
            Console.WriteLine("L2: {0}, RefTail: {1}, LogRefTail: {2}, F_L2: {3}", L2, aflint.exp(LogRefTail), LogRefTail, F_L2)
            Factor = Factor * Factor
        Loop Until F_L2 * LSign < 0

        BrentArb(UseLeftTail, True, True, mp_cdisx, L1, L2, F_L1, F_L2, eps, LogTarget, Df1, aflint.t(0), aflint.t(0), aflint.t(0))
        Console.WriteLine("L2 after Brent: {0}", L2)
        Return L2
    End Function




    Function gamma_p_inv_2Arb(a As Arb, p As Arb) As Arb
        Return cdisxArb(p, 1 - p, 2 * a) / 2
    End Function


    Function gamma_q_inv_2Arb(a As Arb, q As Arb) As Arb
        Return cdisxArb(1 - q, q, 2 * a) / 2
    End Function





    Function fdisx_approx_2Arb(l As Arb, r As Arb, m As Arb, n As Arb) As Arb
        Dim z, q, d, u, v, h As New Arb
        q = n - 1 + m / 2
        d = (m * m - 4) / (24 * q * q)
        z = cdisx_approxArb(l, r, m)
        z = z * (1 + d) + z * z * (d / (m + 2))
        h = -z / q
        u = aflint.exp(h)
        v = -aflint.expm1(h)
        Return (v / u) * (n / m)
    End Function


    Function fdisx_approx_1Arb(l As Arb, r As Arb, m As Arb, n As Arb) As Arb
        Dim u, b As New Arb
        u = ndisxArb_approx(l, r)
        If u < 0 Then b = aflint.t(0.8) Else b = aflint.t(0.4)
        If ((m / n) < (1 - b * u / 4.7)) And (u <= n - 1) Then
            Return fdisx_approx_2Arb(l, r, m, n)
        Else
            Return 1 / fdisx_approx_2Arb(r, l, n, m)
        End If
    End Function


    Function fdisx_approxArb(L As Arb, r As Arb, m As Arb, n As Arb) As Arb
        If m <= n Then
            Return fdisx_approx_1Arb(L, r, m, n)
        Else
            Return 1 / fdisx_approx_1Arb(r, L, n, m)
        End If
    End Function







    Function fdisxArb(LeftTail As Arb, RightTail As Arb, Df1 As Arb, Df2 As Arb) As Arb
        Dim x1, LogTarget, LogRefTail As New Arb
        Dim UseLeftTail As Boolean = True
        Dim eps = aflint.t("1E-40")
        If LeftTail > aflint.t("0.5") Then UseLeftTail = False
        If UseLeftTail Then LogTarget = aflint.log(LeftTail) Else LogTarget = aflint.log(RightTail)

        x1 = fdisx_approxArb(LeftTail, RightTail, Df1, Df2)

        LogRefTail = DistFromBoost.Arb_F_CDF(x1, Df1, Df2, UseLeftTail, True)
        Dim L1 = x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail)

        Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = +1 Else LSign = -1
        Dim Factor = 0.9
        If F_L1 > 0 Then Factor = 1.1
        'Console.WriteLine("L1: {0}, RefTail: {1}, LogRefTail: {2}, F_L1: {3}", L1, aflint.exp(LogRefTail), LogRefTail, F_L1)

        Do
            L1 = L2 : F_L1 = F_L2
            L2 = L1 * Factor
            LogRefTail = DistFromBoost.Arb_F_CDF(L2, Df1, Df2, UseLeftTail, True)
            F_L2 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail)
            'Console.WriteLine("L2: {0}, RefTail: {1}, LogRefTail: {2}, F_L2: {3}", L2, aflint.exp(LogRefTail), LogRefTail, F_L2)
            Factor = Factor * Factor
        Loop Until F_L2 * LSign < 0

        BrentArb(UseLeftTail, True, True, mp_fdisx, L1, L2, F_L1, F_L2, eps, LogTarget, Df1, Df2, aflint.t(0), aflint.t(0))
        Return L2
    End Function


    Sub betadisxArb(LeftTail As Arb, RightTail As Arb, a As Arb, b As Arb, ByRef x As Arb, ByRef y As Arb)
        Dim w = aflint.abs(fdisxArb(LeftTail, RightTail, 2 * a, 2 * b))
        x = a * w / (a * w + b)
        y = b / (a * w + b)
    End Sub


    Function ibeta_inv_2Arb(a As Arb, b As Arb, p As Arb) As Arb
        Dim x, y As Arb
        betadisxArb(p, 1 - p, a, b, x, y)
        Return x
    End Function


    Function ibetac_inv_2Arb(a As Arb, b As Arb, q As Arb) As Arb
        Dim x, y As Arb
        betadisxArb(1 - q, q, a, b, x, y)
        Return x
    End Function



    Function TdisxArb(LeftTail As Arb, RightTail As Arb, n As Arb) As Arb
        Dim t As New Arb, Swapped As Boolean
        If LeftTail = aflint.t("0.5") Then Return aflint.t(0)
        Swapped = False
        If LeftTail < aflint.t("0.5") Then
            t = LeftTail
            LeftTail = RightTail
            RightTail = t
            Swapped = True
        End If
        RightTail = 2 * RightTail
        LeftTail = 1 - RightTail
        t = aflint.sqrt(fdisxArb(LeftTail, RightTail, aflint.t(1), n))
        If Swapped Then t = -t
        Return t
    End Function


    Sub demoNdisxArb()
        ArbPrec.SetDps(60)
        Console.WriteLine(" Hello demoNdisxArb ")
        Dim LeftTail, RightTail, R0, R1, Check, Exponent As New Arb
        RightTail = aflint.t("1.0E-1")
        Exponent = aflint.t("1.0E+0")
        'RightTail = RightTail ^ Exponent
        RightTail = aflint.pow(RightTail, Exponent)
        LeftTail = 1 - RightTail

        Console.WriteLine(" Before swap L:{0}, R:{1}", LeftTail, RightTail)
        SwapTails(LeftTail, RightTail)
        Console.WriteLine(" After swap L:{0}, R:{1}", LeftTail, RightTail)


        R0 = ndisxArb(LeftTail, RightTail)
        Console.WriteLine("R0: {0} ", R0)
        'Console.WriteLine("R1: {0} ", Approx)
        'Dim R5 = ndisxArb_approx(LeftTail, RightTail)

        Check = NdisArb(R0)
        Console.WriteLine("Check: {0}", Check)
        Check = NdisArb(-R0)
        Console.WriteLine("Check: {0}", Check)

        Check = NdensArb(R0)
        Console.WriteLine("Check: {0}", Check)


    End Sub


    Sub demoCdisxArb()
        ArbPrec.SetDps(50)
        Dim m, LeftTail, RightTail, R0, R1, Check, Exponent As New Arb
        m = aflint.t(500)
        Console.WriteLine("m: {0}", m)
        RightTail = aflint.t("1.0E-5")
        Exponent = aflint.t("1.0E+0")
        RightTail = aflint.pow(RightTail, Exponent)
        LeftTail = 1 - RightTail

        R1 = cdisxArb(LeftTail, RightTail, m)
        Console.WriteLine("R1: {0} ", R1)
        Check = DistFromBoost.Arb_ChiSquare_CDF(R1, m, True, False)
        Console.WriteLine("CheckL1: {0}", Check)
        Check = DistFromBoost.Arb_ChiSquare_CDF(R1, m, False, False)
        Console.WriteLine("CheckR1: {0}", Check)
    End Sub


    Sub demoFdisxArb()
        ArbPrec.SetDps(50)
        Dim m, n, LeftTail, RightTail, R1, Check As New Arb
        m = aflint.t(6)
        n = aflint.t(6000)
        RightTail = aflint.t("5.0E-5")
        LeftTail = 1 - RightTail

        SwapTails(LeftTail, RightTail)

        Console.WriteLine("")

        R1 = fdisxArb(LeftTail, RightTail, m, n)
        Console.WriteLine("R1:  {0} ", R1)

        Check = DistFromBoost.Arb_F_CDF(R1, m, n, True, False)
        Console.WriteLine("Check: {0}", Check)
        Check = DistFromBoost.Arb_F_CDF(R1, m, n, False, False)
        Console.WriteLine("Check: {0}", Check)

        'Check = DistFromBoost.Arb_F_pdf(R1, m, n, False)
        'Console.WriteLine("PDF2: {0}", Check)
    End Sub


    Sub demoTdisxArb()
        ArbPrec.SetDps(50)
        Dim m, LeftTail, RightTail, R1, Check As New Arb
        m = aflint.t(1000)
        RightTail = aflint.t("1.0E-2")
        LeftTail = 1 - RightTail

        'aflint.swap(LeftTail, RightTail)

        Console.WriteLine("")
        R1 = TdisxArb(LeftTail, RightTail, m)
        Console.WriteLine("R1: {0} ", R1)
        Check = DistFromBoost.Arb_T_CDF(R1, m, True, False)
        Console.WriteLine("Check: {0}", Check)
        Check = DistFromBoost.Arb_T_CDF(R1, m, False, False)
        Console.WriteLine("Check: {0}", Check)
    End Sub


    Sub demoBetadisxArb()
        ArbPrec.SetDps(60)
        Dim x, y, a, b, LeftTail, RightTail, R1, R2 As New Arb
        a = aflint.t(2)
        b = aflint.t(6)
        LeftTail = aflint.t("0.01")
        RightTail = 1 - LeftTail

        betadisxArb(LeftTail, RightTail, a, b, x, y)

        Console.WriteLine("x: {0} ", x)
        Console.WriteLine("")
        Console.WriteLine("y: {0} ", y)

    End Sub


    Sub demo_ibeta_invArb()
        Dim a, b, p, R1 As New Arb
        a = aflint.t(1.5)
        b = aflint.t(6)
        p = aflint.t(0.99)
        Dim R0 = aflint.real_ibeta_inv(a, b, p)
        Console.WriteLine("R0:  {0}", R0)

        R1 = ibeta_inv_2Arb(a, b, p)
        Console.WriteLine("R1: {0}", R1)
    End Sub


    Sub demo_ibetac_invArb()
        Dim a, b, q, R1 As New Arb
        a = aflint.t(1.5)
        b = aflint.t(6)
        q = aflint.t(0.99)
        Dim R0 = aflint.real_ibetac_inv(a, b, q)
        Console.WriteLine("R0:  {0}", R0)

        R1 = ibetac_inv_2Arb(a, b, q)
        Console.WriteLine("R1: {0}", R1)
    End Sub


    Sub demoGamma_p_invArb()
        Dim a, p, R1 As New Arb
        a = aflint.t(1.5)
        p = aflint.t(0.99)
        Dim R0 = aflint.real_gamma_p_inv(a, p)
        Console.WriteLine("R0:  {0}", R0)

        R1 = gamma_p_inv_2Arb(a, p)
        Console.WriteLine("R1: {0}", R1)
    End Sub


    Sub demoGamma_q_invArb()
        Dim a, q, R1 As New Arb
        a = aflint.t(1.5)
        q = aflint.t(0.99)
        Dim R0 = aflint.real_gamma_q_inv(a, q)
        Console.WriteLine("R0:  {0}", R0)

        R1 = gamma_q_inv_2Arb(a, q)
        Console.WriteLine("R1: {0}", R1)
    End Sub



End Module
