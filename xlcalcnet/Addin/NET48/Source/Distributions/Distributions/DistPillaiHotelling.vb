Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet




Module DistPillaiHotelling


    Sub CalcT2VMoments2(IsT2 As Boolean, k As Integer, m As Integer,
     N1 As Double, n2 As Double, Moment() As Double)
        ' calculates the raw moments of the null distribution of Hotelling's T2 and Pillai's V
        Dim mu(0 To 100) As Double, L0(0 To 100) As Double, nu(0 To 100) As Double, lambda(0 To 100) As Double, a(0 To 100) As Double, Lr(0 To 100) As Double
        Dim r As Integer, j As Integer
        Dim rfakt As Double, weight As Double, sum As Double
        For r = 0 To m
            a(r) = 0.5 * (m - r) * (n2 - r)
            If r = m Then lambda(r) = 0 Else lambda(r) = (r + 1) * (n2 - r - 1) * (m + n2 - r) _
      * (N1 - m + 1 + r) / ((m + n2 - 2 * r - 2) * (m + n2 - 2 * r - 1))
            mu(r) = (-r * (m + n2 - r) * (m + 2 * N1 + n2 + 1) + m * (N1 + n2) * (m + n2 + 1)) _
                   / ((m + n2 - 2 * r - 1) * (m + n2 - 2 * r + 1))
            If r = 0 Then nu(r) = 0 Else nu(r) = -(m - r + 1) * (N1 + n2 - r + 1) _
               / ((m + n2 - 2 * r + 1) * (m + n2 - 2 * r + 2))
            If r < m Then L0(r) = 0 Else L0(r) = 1
        Next r
        rfakt = 1
        For r = 1 To k
            rfakt = rfakt * r
            Moment(r) = 0
            weight = 1
            For j = m To 0 Step -1
                sum = 0
                If j > 0 Then sum = sum + nu(j) * L0(j - 1)
                sum = sum + mu(j) * L0(j)
                If j < m Then sum = sum + lambda(j) * L0(j + 1)
                sum = sum / (r - a(j))
                Lr(j) = sum
                Moment(r) = Moment(r) + sum / weight
                weight = weight * (n2 + m - j + 1)
            Next j
            If (IsT2 And ((r Mod 2) <> 0)) Then Moment(r) = -Moment(r)
            Moment(r) = Moment(r) * rfakt
            '    Debug.Print r, Moment(r)
            For j = 0 To m : L0(j) = Lr(j) : Next j
        Next r
    End Sub


    Sub CalcT2VMoments2Arb(IsT2 As Boolean, k As Integer, m As Integer,
     N1 As Arb, n2 As Arb, Moment As ArbMat)
        ' calculates the raw moments of the null distribution of Hotelling's T2 and Pillai's V
        'Dim mu(0 To 100) As Double, L0(0 To 100) As Double, nu(0 To 100) As Double, lambda(0 To 100) As Double, a(0 To 100) As Double, Lr(0 To 100) As Double

        Dim mu, L0, nu, lambda, a, Lr As New ArbMat
        mu.Resize(k + 1, 1)
        L0.Resize(k + 1, 1)
        nu.Resize(k + 1, 1)
        lambda.Resize(k + 1, 1)
        a.Resize(k + 1, 1)
        Lr.Resize(k + 1, 1)

        Dim r As Integer, j As Integer
        'Dim rfakt As Double, weight As Double, sum As Double
        Dim rfakt, weight, sum As New Arb

        For r = 0 To m
            a(r) = 0.5 * (m - r) * (n2 - r)
            If r = m Then lambda(r) = aflint.t(0) Else lambda(r) = (r + 1) * (n2 - r - 1) * (m + n2 - r) _
      * (N1 - m + 1 + r) / ((m + n2 - 2 * r - 2) * (m + n2 - 2 * r - 1))
            mu(r) = (-r * (m + n2 - r) * (m + 2 * N1 + n2 + 1) + m * (N1 + n2) * (m + n2 + 1)) _
                   / ((m + n2 - 2 * r - 1) * (m + n2 - 2 * r + 1))
            If r = 0 Then nu(r) = aflint.t(0) Else nu(r) = -(m - r + 1) * (N1 + n2 - r + 1) _
               / ((m + n2 - 2 * r + 1) * (m + n2 - 2 * r + 2))
            If r < m Then L0(r) = aflint.t(0) Else L0(r) = aflint.t(1)
        Next r
        rfakt = aflint.t(1)
        For r = 1 To k
            rfakt = rfakt * r
            Moment(r) = aflint.t(0)
            weight = aflint.t(1)
            For j = m To 0 Step -1
                sum = aflint.t(0)
                If j > 0 Then sum = sum + nu(j) * L0(j - 1)
                sum = sum + mu(j) * L0(j)
                If j < m Then sum = sum + lambda(j) * L0(j + 1)
                sum = sum / (r - a(j))
                Lr(j) = sum
                Moment(r) = Moment(r) + sum / weight
                weight = weight * (n2 + m - j + 1)
            Next j
            If (IsT2 And ((r Mod 2) <> 0)) Then Moment(r) = -Moment(r)
            Moment(r) = Moment(r) * rfakt
            '    Debug.Print r, Moment(r)
            For j = 0 To m : L0(j) = Lr(j) : Next j
        Next r
    End Sub



    Sub Hotelling3Moments(p As Double, N1 As Double, n2 As Double)
        Dim n As Double, m As Double, mu1 As Double, mu2 As Double, mu3 As Double, a As Double

        m = (N1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        mu1 = p * (2 * m + p + 1) / (2 * n)
        mu2 = mu1 * (2 * m + 2 * n + p + 1) * (2 * n + p) / (2 * n * (n - 1) * (2 * n + 1))
        mu3 = 2 * mu2 * (2 * m + n + p + 1) * (n + p) / (n * (n - 2) * (n + 1))
        a = mu3 + 3 * mu2 * mu1 + (mu1) ^ 2 * mu1
        Console.WriteLine("1.: {0}, 2.: {1}, 3.: {2}", mu1, mu2 + (mu1) ^ 2, a)
    End Sub

    Sub Pillai3Moments(p As Double, N1 As Double, n2 As Double)
        Dim s As Double, n As Double, m As Double, mu1 As Double, mu2 As Double, mu3 As Double, a As Double
        m = (N1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        s = p
        mu1 = s * (2 * m + s + 1) / (2 * (m + n + s + 1))
        mu2 = s * (2 * m + s + 1) * (2 * n + s + 1) * (2 * m + 2 * n + s + 2) _
       / (4 * (m + n + s + 1) ^ 2 * (m + n + s + 2) * (2 * m + 2 * n + 2 * s + 1))
        mu3 = s * (n - m) * (2 * m + s + 1) * (2 * n + s + 1) * (m + n + 1) * (2 * m + 2 * n + s + 2) _
     / ((m + n + s + 1) ^ 2 * (m + n + s + 1) * (m + n + s + 2) * (m + n + s + 3) _
     * (2 * m + 2 * n + 2 * s) * (2 * m + 2 * n + 2 * s + 1))
        a = mu3 + 3 * mu2 * mu1 + (mu1) ^ 2 * mu1
        Console.WriteLine("1.: {0}, 2.: {1}, 3.: {2}", mu1, mu2 + (mu1) ^ 2, a)
    End Sub

    Sub CalcT2Moments(k As Integer, m As Integer, N1 As Double, n2 As Double, mraw() As Double)
        Call CalcT2VMoments2(True, k, m, N1, n2, mraw)
    End Sub

    Sub CalcVMoments(k As Integer, m As Integer, N1 As Double, n2 As Double, mraw() As Double)
        Call CalcT2VMoments2(False, k, m, N1, (m - N1 - n2 + 1), mraw)
    End Sub


    Sub CalcT2MomentsArb(k As Integer, m As Integer, N1 As Double, n2 As Double, mraw As ArbMat)
        Call CalcT2VMoments2Arb(True, k, m, aflint.t(N1), aflint.t(n2), mraw)
    End Sub

    Sub CalcVMomentsArb(k As Integer, m As Integer, N1 As Double, n2 As Double, mraw As ArbMat)
        Call CalcT2VMoments2Arb(False, k, m, aflint.t(N1), aflint.t(m - N1 - n2 + 1), mraw)
    End Sub


    Sub DemoCalcT2()
        Dim k As Integer, p As Integer, N1 As Double, n2 As Double, mraw() As Double, mu() As Double, kappa() As Double
        k = 14
        p = 12
        N1 = 25
        n2 = 225


        Dim RightTail = 0.1
        Dim LeftTail = 1 - RightTail


        Pillai3Moments(p, N1, n2)
        ReDim mraw(k)
        Call CalcVMoments(k, p, N1, n2, mraw)
        Dim i As Integer
        For i = 1 To k
            Console.WriteLine("i: {0}, mraw(i): {1}", i, mraw(i))
        Next i

        ReDim mu(k)
        ReDim kappa(k)

        '!!!!! Replace with RawMomentsToCumulants !!!!

        RawMomentsToMoments(k, mraw, mu)
        For i = 1 To k
            Console.WriteLine("i: {0}, mu(i): {1}", i, mu(i))
        Next i

        MomentsToCumulants(k, mu, kappa)
        For i = 1 To k
            Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        '!!!!! Replace with RawMomentsToCumulants !!!!

        Dim kappaArb As New ArbMat
        kappaArb.Resize(100, 1)
        For i = 1 To k
            kappaArb(i) = aflint.t(kappa(i))
        Next

        Dim mean = kappaArb(1)
        Dim sigma = aflint.sqrt(kappaArb(2))
        'Dim sigma2 = kappaArb(2)

        Dim result As New Arb

        Dim XX = ndisxArb(aflint.t(LeftTail), aflint.t(1 - LeftTail))

        Dim XAdj = CFArb(k - 2, XX, kappaArb)
        Console.WriteLine("mean: {0}, sigma: {1}, XAdj: {2}", mean, sigma, XAdj)
        Console.WriteLine("(mean + sigma * XAdj): {0}", (mean + sigma * XAdj))

        Dim fxTarget = XAdj
        Console.WriteLine("fxTarget: {0}", fxTarget)

        Console.WriteLine("")
        Dim x3Start = CF_up(fxTarget, kappaArb)
        Console.WriteLine("x3Start : {0}", x3Start)

        'Dim Result2 As Arb = InvCornArb(fxTarget, x3Start, kappaArb, k)
        'Console.WriteLine("Result2 : {0}", Result2)
        'Console.WriteLine("x3Start: {0}", x3Start)

        'LeftTail = NdisArb(Result2)
        'RightTail = 1 - LeftTail
        'Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)


    End Sub



    Sub Pillai3Cumulants(p As Double, n1 As Double, n2 As Double)
        Dim s As Double, n As Double, m As Double, k1 As Double, k2 As Double, k3 As Double
        m = (n1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        s = p
        k1 = s * (2 * m + s + 1) / (2 * (m + n + s + 1))
        k2 = s * (2 * m + s + 1) * (2 * n + s + 1) * (2 * m + 2 * n + s + 2) _
       / (4 * (m + n + s + 1) ^ 2 * (m + n + s + 2) * (2 * m + 2 * n + 2 * s + 1))
        k3 = s * (n - m) * (2 * m + s + 1) * (2 * n + s + 1) * (m + n + 1) * (2 * m + 2 * n + s + 2) _
     / ((m + n + s + 1) ^ 2 * (m + n + s + 1) * (m + n + s + 2) * (m + n + s + 3) _
     * (2 * m + 2 * n + 2 * s) * (2 * m + 2 * n + 2 * s + 1))
        Console.WriteLine("1.: {0}, 2.: {1}, 3.: {2}", k1, k2, k3)

        Dim k12, k22, f1, f2, b As Double
        k12 = k1 * k1
        k22 = k2 * k2
        f1 = (4 * k1 * (k12 * k2 - k22 + k1 * k3)) / (4 * k1 * k22 - k12 * k3 + k2 * k3)
        f2 = (4 * k2 * (2 * k1 * k2 + k3) * (k12 * k2 - k22 + k1 * k3)) / ((k1 * k3 - 2 * k22) * (k12 * k3 - 4 * k1 * k22 - k2 * k3))
        b = (k12 * k3 - 4 * k1 * k22 - k2 * k3) / (k1 * k3 - 2 * k22)

        Dim RightTail = 0.01
        Dim LeftTail = 1 - RightTail
        Dim wx, wy As Double
        betadisx(LeftTail, RightTail, f1 / 2, f2 / 2, wx, wy)
        Dim V = b * wx
        Console.WriteLine("V: {0}", V)
    End Sub


    Function Pillai3VX(p As Double, n1 As Double, n2 As Double, LeftTail As Double, Righttail As Double) As Double
        Dim n As Double, m As Double, k1 As Double, k2 As Double, k3 As Double, r As Double
        m = (n1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        r = m + n + p
        k1 = p * (2 * m + p + 1) / (2 * (r + 1))
        k2 = k1 * (2 * n + p + 1) * (2 * m + 2 * n + p + 2) / (2 * (r + 1) * (r + 2) * (2 * r + 1))
        k3 = 4 * k2 * (n - m) * (m + n + 1) / ((r + 1) * (r + 3) * (2 * r))
        'Console.WriteLine("1.: {0}, 2.: {1}, 3.: {2}", k1, k2, k3)

        Dim k12, k22 As Double
        k12 = k1 * k1 : k22 = k2 * k2
        Dim a = (2 * k1 * (k12 * k2 - k22 + k1 * k3)) / (4 * k1 * k22 - k12 * k3 + k2 * k3)
        Dim b = (2 * k2 * (2 * k1 * k2 + k3) * (k12 * k2 - k22 + k1 * k3)) / ((k1 * k3 - 2 * k22) * (k12 * k3 - 4 * k1 * k22 - k2 * k3))
        Dim k = (k12 * k3 - 4 * k1 * k22 - k2 * k3) / (k1 * k3 - 2 * k22)

        Dim wx, wy As Double
        betadisx(LeftTail, Righttail, a, b, wx, wy)
        Dim V = k * wx
        'Console.WriteLine("(n + m) * V / n: {0}", (n1 + n2) * V / n1)

        Return V
    End Function

    Sub DemoCalcPillaiArb()
        Dim k As Integer, p As Integer
        Dim n1 As Double, n2 As Double
        Dim mraw, mu, kappa As New ArbMat
        'Dim mraw() As Double ', mu() As Double, kappa() As Double
        k = 22
        p = 4
        n1 = 10
        n2 = 125

        Dim RightTail = 0.05
        Dim LeftTail = 1 - RightTail


        Pillai3Cumulants(p, n1, n2)
        mraw.Resize(k + 1, 1)
        mu.Resize(k + 1, 1)
        kappa.Resize(k + 1, 1)

        Call CalcVMomentsArb(k, p, n1, n2, mraw)
        Dim i As Integer
        For i = 1 To k
            Console.WriteLine("i: {0}, mraw(i): {1}", i, mraw(i))
        Next i


        RawToCentralArb(k, mraw, mu)
        For i = 1 To k
            Console.WriteLine("i: {0}, mu(i): {1}", i, mu(i))
        Next i

        MomentsToCumulantsArb(k, mu, kappa)
        For i = 1 To k
            Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        Dim mean = kappa(1)
        Dim sigma = aflint.sqrt(kappa(2))

        Dim result As New Arb

        Dim XX = ndisxArb(aflint.t(LeftTail), aflint.t(1 - LeftTail))

        Dim XAdj = CFArb(k, XX, kappa)
        Console.WriteLine("mean: {0}, sigma: {1}, XAdj: {2}", mean, sigma, XAdj)
        Console.WriteLine("(mean + sigma * XAdj): {0}", (mean + sigma * XAdj))


        Dim V As Double
        PillaiVX(p, n1, n2, V, LeftTail, RightTail)
        Console.WriteLine("V2: {0}", V / n2)

        'Pillai3Cumulants(p, N1, n2)
        V = Pillai3VX(p, n1, n2, LeftTail, RightTail)
        Console.WriteLine("V3: {0}", V)
        Console.WriteLine("Comparison with Anderson 2003, Table 3, page 630 - 633")
        Console.WriteLine("(n1 + n2) * V / 1: {0}", (n1 + n2) * V / n1)


        'Dim fxTarget = XAdj
        'Console.WriteLine("fxTarget: {0}", fxTarget)

        'Console.WriteLine("")
        'Dim x3Start = CF_up(fxTarget, kappa)
        'Console.WriteLine("x3Start : {0}", x3Start)

        'Dim Result2 As Arb = InvCornArb(fxTarget, x3Start, kappa, k)
        'Console.WriteLine("Result2 : {0}", Result2)
        'Console.WriteLine("x3Start: {0}", x3Start)

        'LeftTail = NdisArb(Result2)
        'RightTail = 1 - LeftTail
        'Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)


    End Sub


    Sub DemoCalcHotellingArb()
        Dim k As Integer, p As Integer
        Dim n1 As Double, n2 As Double
        Dim mraw, mu, kappa As New ArbMat
        'Dim mraw() As Double ', mu() As Double, kappa() As Double
        k = 22
        p = 10
        n1 = 35
        n2 = 200

        Dim RightTail = 0.05
        Dim LeftTail = 1 - RightTail


        Hotelling3Moments(p, n1, n2)
        mraw.Resize(k + 1, 1)
        mu.Resize(k + 1, 1)
        kappa.Resize(k + 1, 1)

        Call CalcT2MomentsArb(k, p, n1, n2, mraw)
        Dim i As Integer
        For i = 1 To k
            Console.WriteLine("i: {0}, mraw(i): {1}", i, mraw(i))
        Next i


        RawToCentralArb(k, mraw, mu)
        For i = 1 To k
            Console.WriteLine("i: {0}, mu(i): {1}", i, mu(i))
        Next i

        MomentsToCumulantsArb(k, mu, kappa)
        For i = 1 To k
            Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        Dim mean = kappa(1)
        Dim sigma = aflint.sqrt(kappa(2))

        Dim result As New Arb

        Dim XX = ndisxArb(aflint.t(LeftTail), aflint.t(1 - LeftTail))

        Dim XAdj = CFArb(k, XX, kappa)
        Console.WriteLine("mean: {0}, sigma: {1}, XAdj: {2}", mean, sigma, XAdj)
        Console.WriteLine("(mean + sigma * XAdj): {0}", (mean + sigma * XAdj))

        Dim t2 As Double
        HotellingX2(p, n1, n2, t2, LeftTail, RightTail)
        Console.WriteLine("t2: {0}", t2 / n2)

        Console.WriteLine("Comparison with Anderson 2003, Table 2, page 616 - 629")
        Console.WriteLine("n2 * t2 / n1: {0}", n2 * t2 / n1 / n2)


        'Dim fxTarget = XAdj
        'Console.WriteLine("fxTarget: {0}", fxTarget)

        'Console.WriteLine("")
        'Dim x3Start = CF_up(fxTarget, kappa)
        'Console.WriteLine("x3Start : {0}", x3Start)

        'Dim Result2 As Arb = InvCornArb(fxTarget, x3Start, kappa, k)
        'Console.WriteLine("Result2 : {0}", Result2)
        'Console.WriteLine("x3Start: {0}", x3Start)

        'LeftTail = NdisArb(Result2)
        'RightTail = 1 - LeftTail
        'Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)


    End Sub


    Sub HotellingExact2(m As Double, n As Double, w As Double, LeftTail As Double, Righttail As Double)
        Dim y As Double, sum1 As Double, sum2 As Double, sum3 As Double, sum4 As Double, density As Double
        Const pi = 3.14159265358979
        w = w / n
        y = w / (2 + w)
        Call betadis(m - 1, n - 1, y, 1 - y, LeftTail, Righttail, density)
        sum1 = LeftTail
        Call betadis((m - 1) / 2, (n - 1) / 2, y * y, 1 - y * y, LeftTail, Righttail, density)
        sum2 = LeftTail
        sum3 = Math.Sqrt(pi) * Math.Exp(LnGamma((m + n - 1) / 2) - LnGamma(m / 2) - LnGamma(n / 2))
        sum4 = Math.Exp(Math.Log(1 + w) * (-0.5 * (n - 1)))
        LeftTail = sum1 - sum2 * sum3 * sum4
        Righttail = 1 - LeftTail
    End Sub


    ' Let m=(n1-p-1)/2 and n=(n2-p-1)/2.}

    Sub Hotelling(p As Double, m As Double, n As Double, x As Double, LeftTail As Double, Righttail As Double)
        Dim density As Double, mu1 As Double, mu2 As Double, mu3 As Double, mu12 As Double, mu13 As Double, mu22 As Double, a As Double, b As Double, k As Double, w As Double
        mu1 = p * (2 * m + p + 1) / (2 * n)
        mu2 = mu1 * (2 * m + 2 * n + p + 1) * (2 * n + p) / (2 * n * (n - 1) * (2 * n + 1))
        mu3 = 2 * mu2 * (2 * m + n + p + 1) * (n + p) / (n * (n - 2) * (n + 1))
        mu12 = mu1 ^ 2 : mu13 = mu1 * mu12 : mu22 = mu2 ^ 2
        a = (2 * mu13 * mu2 + 3 * mu12 * mu3 - 6 * mu1 * mu22 - mu2 * mu3) / (mu2 * mu3 + 4 * mu1 * mu22 - mu12 * mu3)
        b = ((a + 1) * (a + 3) - mu12 / mu2) / ((a + 1) - mu12 / mu2)
        k = mu1 * (b - a - 2) / (a + 1)
        w = x / (x + k)
        Call betadis(a + 1, b - a - 1, w, 1 - w, LeftTail, Righttail, density)
    End Sub


    Sub Hotelling2(p As Double, N1 As Double, n2 As Double, t2 As Double, LeftTail As Double, Righttail As Double)
        Dim m As Double, n As Double, x As Double
        m = (N1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        x = t2 / n2
        Call Hotelling(p, m, n, x, LeftTail, Righttail)
    End Sub


    'cdf of S_1/(S_1 + S_2)}

    Sub PillaiV(p As Double, N1 As Double, n2 As Double, x As Double, LeftTail As Double, Righttail As Double)
        Dim s As Double, n As Double, m As Double, density As Double, mu1 As Double, mu2 As Double, a As Double, b As Double, w As Double
        Dim m1 As Double, m2 As Double
        x = x / n2
        m = (N1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        s = p
        mu1 = s * (2 * m + s + 1) / (2 * (m + n + s + 1))
        mu2 = s * (2 * m + s + 1) * (2 * n + s + 1) * (2 * m + 2 * n + s + 2) _
       / (4 * (m + n + s + 1) ^ 2 * (m + n + s + 2) * (2 * m + 2 * n + 2 * s + 1))
        m1 = mu1 / p
        m2 = (mu2) / (p * p)
        a = (m1 / m2) * (m1 - (m1) ^ 2 - m2)
        b = a * (1 - m1) / m1
        w = x / p
        Call betadis(a, b, w, 1 - w, LeftTail, Righttail, density)
    End Sub



    Sub PillaiVX(p As Double, N1 As Double, n2 As Double, ByRef x As Double, LeftTail As Double, Righttail As Double)
        Dim s As Double, n As Double, m As Double, mu1 As Double, mu2 As Double, a As Double, b As Double
        Dim m1 As Double, m2 As Double, wx As Double, wy As Double
        m = (N1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        s = p
        mu1 = s * (2 * m + s + 1) / (2 * (m + n + s + 1))
        mu2 = s * (2 * m + s + 1) * (2 * n + s + 1) * (2 * m + 2 * n + s + 2) _
       / (4 * (m + n + s + 1) ^ 2 * (m + n + s + 2) * (2 * m + 2 * n + 2 * s + 1))
        m1 = mu1 / p
        m2 = (mu2) / (p * p)
        a = (m1 / m2) * (m1 - (m1) ^ 2 - m2)
        b = a * (1 - m1) / m1
        Call betadisx(LeftTail, Righttail, a, b, wx, wy)
        x = wx * n2 * p
    End Sub





    Sub HotellingX(p As Double, m As Double, n As Double, ByRef x As Double, LeftTail As Double, Righttail As Double)
        Dim mu1 As Double, mu2 As Double, mu3 As Double, mu12 As Double, mu13 As Double, mu22 As Double, a As Double, b As Double, k As Double, wx As Double, wy As Double
        mu1 = p * (2 * m + p + 1) / (2 * n)
        mu2 = mu1 * (2 * m + 2 * n + p + 1) * (2 * n + p) / (2 * n * (n - 1) * (2 * n + 1))
        mu3 = 2 * mu2 * (2 * m + n + p + 1) * (n + p) / (n * (n - 2) * (n + 1))
        mu12 = mu1 ^ 2 : mu13 = mu1 * mu12 : mu22 = mu2 ^ 2
        a = (2 * mu13 * mu2 + 3 * mu12 * mu3 - 6 * mu1 * mu22 - mu2 * mu3) / (mu2 * mu3 + 4 * mu1 * mu22 - mu12 * mu3)
        b = ((a + 1) * (a + 3) - mu12 / mu2) / ((a + 1) - mu12 / mu2)
        k = mu1 * (b - a - 2) / (a + 1)
        Call betadisx(LeftTail, Righttail, a + 1, b - a - 1, wx, wy)
        x = k * (wx / wy)
    End Sub

    ' x=T²/n2 is distributed as Iw(a+1,b-a-1), where w=x/(x+K)


    Sub HotellingX2(p As Double, n1 As Double, n2 As Double, ByRef t2 As Double, LeftTail As Double, Righttail As Double)
        Dim m As Double, n As Double, x As Double
        m = (n1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        Call HotellingX(p, m, n, x, LeftTail, Righttail)
        t2 = x * n2
    End Sub



    Private Function Getc(j As Integer, r As Integer, m As Integer, c(,) As Double) As Double
        If ((j = 0) And (r = 0)) Then
            Getc = 1 : Exit Function
        End If
        If ((j = 1) And (r = 1)) Then
            Getc = c(1, 1) '
            Exit Function
        End If
        If ((j <= 0) Or (j > m) Or (r <= 1)) Then Getc = 0 Else Getc = c(j, r)
    End Function

    Sub DavisOmega(dis As Integer, m As Integer, N1 As Double, n2 As Double,
                 omega() As Double, cmax As Integer)
        '{ dis=1 as Pillai dis=2 as Hotelling }
        Dim i As Integer, j As Integer, r As Integer, r1 As Integer, i2 As Integer
        Dim c11 As Double, sum As Double
        Dim s As Double, a As Double, k As Double
        Dim c(0 To 30, 0 To 30) As Double
        If dis = 1 Then
            s = 1 : k = m + 1 : a = 2 * k + N1
        Else
            s = -1 : k = -N1 : a = 2 * N1 + m + 1
        End If
        c(1, 1) = s * m * N1
        omega(1) = m * N1 * k / (2 * n2)
        Console.WriteLine("r: {0}, omega(r): {1}", 1, omega(1))
        For r = 2 To cmax
            r1 = r
            If r > m Then r1 = m
            For j = r1 To 1 Step -1
                i = r - j + 1
                If j <= m Then
                    c(j, i) = s * ((m - j + 1) * (N1 - j + 1)) * Getc(j - 1, i - 1, m, c) _
                              + s * ((j * (a - 2 * j) + 2 * (i - 1)) / n2) * Getc(j, i - 1, m, c) _
                              + ((j + 1) / n2 - (j + 1) * s * (s * k - j) / (n2 * n2)) * Getc(j + 1, i - 1, m, c) _
                              - s * ((m * N1 + 2 * (i - 2)) / n2) * Getc(j, i - 2, m, c)
                    sum = 0
                    For i2 = 1 To i - 2
                        sum = sum + s * i2 * omega(i2) * (Getc(j, i - i2 - 1, m, c) - Getc(j, i - i2 - 2, m, c))
                    Next i2
                    sum = 2 * sum / n2
                    c(j, i) = (c(j, i) + sum) / j
                End If
            Next j
            c11 = c(1, r)
            omega(r) = (2 * (r - 1) * omega(r - 1) - s * (1 - k / n2) * c11) / (2 * r)
            Console.WriteLine("r: {0}, omega(r): {1}", r, omega(r))
        Next r
    End Sub

    Sub DemoOmega_T()
        Dim LeftTail As Double, Righttail As Double
        Dim cmax As Integer, x As Double, m As Integer
        Dim N1 As Double, n2 As Double
        Dim omega(0 To 30) As Double
        Dim omegaArb As New ArbMat
        Console.WriteLine()

        x = 6
        cmax = 22
        m = 1
        N1 = 12
        n2 = 180
        Righttail = 0.01
        LeftTail = 1 - Righttail
        Call HotellingX2(m, N1, n2, x, LeftTail, Righttail)
        Console.WriteLine("x: {0}", x)
        'Debug.Print "x: ", x
        DavisOmega(2, m, N1, n2, omega, cmax)

        omegaArb.Resize(100, 1)
        For i = 1 To cmax
            omegaArb(i) = aflint.t(omega(i))
        Next

        Dim TargetError = aflint.t("1E-40")
        GuptaArb(cmax, aflint.t(m * N1), aflint.t(x), aflint.t(1.0), omegaArb, TargetError)
    End Sub


    Sub DemoOmega_V()
        Dim LeftTail As Double, Righttail As Double
        Dim cmax As Integer, x As Double, m As Integer
        Dim N1 As Double, n2 As Double
        Dim omega(0 To 30) As Double
        Dim omegaArb As New ArbMat
        x = 6
        cmax = 22
        m = 1
        N1 = 12
        n2 = 180
        Righttail = 0.01
        LeftTail = 1 - Righttail
        Call PillaiVX(m, N1, n2, x, LeftTail, Righttail)
        Console.WriteLine("x: {0}", x)
        'Debug.Print "x: ", x
        Call DavisOmega(1, m, N1, n2, omega, cmax)

        omegaArb.resize(100, 1)
        For i = 1 To cmax
            omegaArb(i) = aflint.t(omega(i))
        Next
        Dim TargetError = aflint.t("1.0E-10")
        GuptaArb(cmax, aflint.t(m * N1), aflint.t(x), aflint.t(1.0), omegaArb, TargetError)
    End Sub



    Sub FujiX(t2 As Boolean, p As Double, q As Double, n As Double, ByRef x As Double, LeftTail As Double, Righttail As Double)
        Dim u As Double, u2 As Double, u3 As Double, u4 As Double, u5 As Double, u6 As Double
        Dim h As Double, h2 As Double, h3 As Double, f4 As Double, f6 As Double, f8 As Double, pq As Double
        Dim sum0 As Double, sum1 As Double, sum2 As Double, sum3 As Double
        Dim f2 As Double, F As Double, G As Double, g2 As Double

        F = p * q : G = p + q + 1 : g2 = G * G : f2 = F * F
        u = cdisx(LeftTail, Righttail, F)
        u2 = u * u : u3 = u2 * u : u4 = u3 * u : u5 = u4 * u : u6 = u5 * u
        h = F + 2 : h2 = h * h : h3 = h2 * h
        f4 = F + 4 : f6 = f4 * (F + 6) : f8 = f6 * (F + 8)
        pq = (p - 1) * (p + 2) * (q - 1) * (q + 2)
        sum0 = u
        sum1 = G * (u - u2 / h)
        sum2 = u * (7 * g2 - 2 * G - 2 * h) _
        - u2 * (11 * g2 + 2 * G + 2 * h) / h _
        + 2 * u3 * (2 * (F + 5) * g2 - h * G - h2) / (h2 * f4) _
        + 6 * u4 * pq / (h2 * f6)
        sum3 = 3 * u * G * (3 * g2 - 2 * G - 2 * h) - u2 * G * (17 * g2 + 2 * G + 2 * h) / h _
        + 2 * u3 * G * ((5 * F + 26) * g2 - (F - 2) * G - (F - 2) * h) / (h2 * f4) _
        - 2 * u4 * G * ((f2 + 24 * F + 68) * g2 - (7 * F + 22) * h * G - (7 * F + 22) * h2) / (h3 * f6) _
        + 4 * u5 * pq * ((F - 28) * G + 6 * h) / (h3 * f8) _
        - 8 * u6 * pq * ((F - 10) * G + 3 * h) / (h3 * f8 * (F + 10))
        sum1 = sum1 / (2 * n)
        sum2 = sum2 / (24 * n * n)
        sum3 = sum3 / (48 * n * n * n)

        'Console.WriteLine(sum0)
        'Console.WriteLine(sum1)
        'Console.WriteLine(sum2)
        'Console.WriteLine(sum3)

        If t2 Then
            x = sum0 - sum1 + sum2 - sum3
        Else
            x = sum0 + sum1 + sum2 + sum3
        End If
    End Sub

    Function VdisX(LeftTail As Double, Righttail As Double, p As Double, q As Double, n As Double) As Double
        Dim x As Double
        Call FujiX(False, p, q, n + q, x, LeftTail, Righttail)
        VdisX = x / (n + q)
    End Function

    Function T2disX(LeftTail As Double, Righttail As Double, p As Double, q As Double, n As Double) As Double
        Dim x As Double, N1 As Double
        N1 = Math.Abs(n - p - 1)
        If N1 = 0 Then N1 = 1
        Call FujiX(True, p, q, N1, x, LeftTail, Righttail)
        T2disX = x / N1
    End Function







End Module


