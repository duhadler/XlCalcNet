Imports FixedPrecNet
Imports ArbPrecNet

Module DistCornish




    Sub RawMomentsToMoments(k As Integer, ByRef mraw() As Double, ByRef mu() As Double)
        Dim n As Integer, j As Integer
        Dim sign As Double, sum As Double, prod As Double, BK As Double
        mraw(0) = 1
        mu(1) = mraw(1)
        For n = 2 To k
            sum = 0
            BK = 1
            prod = 1
            sign = 1
            For j = n To 0 Step -1
                sum = sum + sign * BK * mraw(j) * prod
                BK = BK * j / (n - j + 1)
                sign = -sign
                prod = prod * mu(1)
            Next j
            mu(n) = sum
        Next n
    End Sub

    Sub MomentsToRawMoments(k As Integer, ByRef mraw() As Double, ByRef mu() As Double)
        Dim n As Integer, j As Integer
        Dim sum As Double, prod As Double, BK As Double
        mu(0) = 1
        mraw(1) = mu(1)
        mu(1) = 0
        For n = 2 To k
            sum = 0
            BK = 1
            prod = 1
            For j = 0 To n
                sum = sum + BK * mu(n - j) * prod
                BK = BK * (n - j) / (j + 1)
                prod = prod * mraw(1)
            Next j
            mraw(n) = sum
        Next n
        mu(1) = mraw(1)
    End Sub

    Sub MomentsToCumulants(n As Integer, ByRef mu() As Double, ByRef kappa() As Double)
        ' Calculates cumulants from central moments
        ' Lee, 1992
        Dim r As Integer, j As Integer, sum As Double, F As Double
        kappa(1) = mu(1)
        For r = 2 To n
            sum = 0
            F = r - 1
            For j = 2 To r - 2
                sum = sum + F * mu(r - j) * kappa(j)
                F = F * (r - j) / j
            Next j
            kappa(r) = mu(r) - sum
        Next r
    End Sub


    Sub RawMomentsToCumulants(n As Integer, ByRef mu() As Double, ByRef kappa() As Double)
        ' Calculates cumulants from raw moments
        Dim r As Integer, j As Integer, sum As Double, f As Double
        kappa(1) = mu(1)
        For r = 1 To n
            sum = 0
            f = 1
            For j = 1 To r - 1
                sum = sum + f * mu(r - j) * kappa(j)
                f = f * (r - j) / j
            Next j
            kappa(r) = mu(r) - sum
        Next r
    End Sub



    Sub CumulantsToRawMoments(n As Integer, ByRef kappa() As Double, ByRef mu() As Double)
        ' Calculates cumulants from raw moments
        Dim r As Integer, j As Integer, sum As Double, f As Double
        mu(1) = kappa(1)
        For r = 1 To n
            sum = 0
            f = 1
            For j = 1 To r - 1
                sum = sum + f * mu(r - j) * kappa(j)
                f = f * (r - j) / j
            Next j
            mu(r) = kappa(r) + sum
        Next r
    End Sub




    Sub CumulantToGamma(m As Integer, mean As Double, ByRef sigma As Double, ByRef k() As Double, ByRef o() As Double)
        ' Calculates gamma-coefficients (for the Edgeworth expansion) from cumulants
        Dim sign As Double, fakt As Double
        Dim i As Integer
        sigma = Math.Sqrt(k(2))
        mean = (mean - k(1)) / sigma
        sign = -1
        fakt = 2 * k(2)
        For i = 3 To m
            fakt = fakt * sigma * i
            o(i - 2) = sign * k(i) / fakt
            sign = -sign
        Next i
    End Sub



    'Get cumulants from discrete null-distribution
    Sub GetRawMoments(nl As Int32, maxmoment As Int32, x() As Double, mu() As Double)
        Dim s As Int32, i As Int32, j As Int32
        Dim sk As Double
        s = 0
        ReDim mu(maxmoment) ': ReDim kappa(maxmoment)
        For j = 1 To maxmoment : mu(j) = 0 : Next j
        For i = 0 To nl
            sk = 1
            For j = 1 To maxmoment Step 1
                sk = sk * s
                mu(j) = mu(j) + x(i) * sk
            Next j
            s = s + 1
        Next i
        ' Call MomentsToCumulants(maxmoment, mu(), kappa())
        Console.WriteLine("Raw Moments")
        For j = 1 To maxmoment
            Console.WriteLine("j: {0}, mu(j): {1}", j, mu(j))
        Next j

    End Sub













    Private Sub enumerate(m As Integer, nr As Integer, ByRef p() As Integer, ByRef t() As Integer, ByRef hcount() As Integer)
        Dim sum As Integer, F As Integer
        Dim minus As Boolean
        sum = 0
        minus = ((m - nr) Mod 2) > 0
        For F = 1 To nr
            sum = sum + p(t(F))
        Next F
        If minus Then hcount(sum) = hcount(sum) - 1 Else hcount(sum) = hcount(sum) + 1
    End Sub

    Private Sub initialize(a As Integer, active As Integer, nr As Integer, ByRef t() As Integer)
        Dim i As Integer
        t(a) = t(a) + 1
        For i = a + 1 To nr
            t(i) = t(i - 1) + 1
        Next i
        active = nr
    End Sub

    Private Function CalcH(ByRef h() As Double, ByRef p() As Integer, m As Integer) As Double
        Dim hmax As Integer, i As Integer, Index As Integer, nr As Integer, active As Integer
        Dim hcount(0 To 100) As Integer, t(0 To 100) As Integer
        Dim sum As Double
        hmax = 0
        For i = 1 To m
            hmax = hmax + p(i)
        Next i
        For i = 1 To hmax
            hcount(i) = 0
        Next i
        Index = 1
        For nr = 1 To m
            t(1) = 0
            t(0) = m
            Call initialize(1, active, nr, t)
            Call enumerate(m, nr, p, t, hcount)
            Do
                If active >= 0 Then
                    If t(active) < m - (nr - active) Then
                        t(active) = t(active) + 1
                        Call enumerate(m, nr, p, t, hcount)
                    Else
                        active = active - 1
                        If active >= 0 Then
                            If t(active) < m - (nr - active) Then
                                Call initialize(active, active, nr, t)
                                Call enumerate(m, nr, p, t, hcount)
                            End If
                        End If
                    End If
                End If
            Loop Until active = 0
        Next nr
        sum = 0
        For i = hmax To 1 Step -1
            If hcount(i) <> 0 Then
                sum = sum + hcount(i) * h(i)
            End If
        Next i
        CalcH = sum
    End Function

    Private Sub cp(n As Integer, k As Integer, h As Integer, ByRef p() As Integer, F As Boolean, z As Boolean)
        Dim a As Integer, b As Integer, i As Integer, j As Integer, Q As Integer, r As Integer
        If F Then
            If z Then
                a = n
                p(k) = -1
            Else
                a = n - k
                p(k) = 0
            End If
            F = False
            j = k
        Else
            a = p(1) - p(2) - 2
            j = 2
            While p(1) - p(j) < 2
                a = a - 1 + j * (p(j) - p(j + 1))
                j = j + 1
            End While
        End If
        b = h - 1 - p(j)
        Q = a \ b
        r = a - b * Q
        For i = 1 To Q
            p(i) = h
        Next i
        If Q = k Then
            F = True
            Exit Sub
        End If
        For i = Q + 1 To j
            p(i) = 1 + p(j)
        Next i
        p(Q + 1) = r + p(Q + 1)
        If p(1) - p(k) < 2 Then F = True
    End Sub

    Private Function CalcOmega(ByRef o() As Double, ByRef p() As Integer, m As Integer) As Double
        Dim j As Integer, position As Integer, i As Integer
        Dim Value(0 To 100) As Integer, count(0 To 100) As Integer
        Dim prod As Double
        Value(1) = p(1)
        count(1) = 1
        position = 1
        For i = 2 To m
            If p(i - 1) = p(i) Then
                count(position) = count(position) + 1
            Else
                position = position + 1
                Value(position) = p(i)
                count(position) = 1
            End If
        Next i
        prod = 1
        For i = 1 To position
            prod = prod * o(Value(i))
            For j = 2 To count(i)
                prod = prod * o(Value(i)) / j
            Next j
        Next i
        CalcOmega = prod
    End Function

    Private Function CalcZ(ByRef h() As Double, ByRef p() As Integer,
      m As Integer, n_order As Integer) As Double
        Dim d As Integer, i As Integer
        d = 0
        For i = 1 To m
            d = d + p(i) + 2
        Next i
        CalcZ = h(n_order + d - 1)
    End Function

    Private Function calc(IsBoxDavis As Boolean, ByRef h() As Double, ByRef o() As Double,
                  ByRef p() As Integer, k As Integer, n_order As Integer) As Double
        Dim m As Integer, i As Integer
        Dim co As Double, ch As Double
        i = 1
        While ((p(i) <> 0) And (i < k + 1))
            i = i + 1
        End While
        m = i - 1
        If IsBoxDavis Then
            co = CalcOmega(o, p, m)
            ch = CalcH(h, p, m)
            calc = co * ch
        Else
            calc = CalcOmega(o, p, m) * CalcZ(h, p, m, n_order)
        End If
    End Function

    Private Function BoxDavisSum(IsBoxDavis As Boolean, UseOne As Boolean,
    ByRef h() As Double, ByRef o() As Double, n As Integer, n_order As Integer) As Double
        Dim icount As Integer, k As Integer, HH As Integer, i As Integer
        Dim p(0 To 100) As Integer
        Dim F As Boolean, z As Boolean
        Dim sum As Double
        HH = n
        icount = 1
        z = True  'Teil kann 0 sein
        F = True
        '  UseOne=true Teil kann 1 sein
        If UseOne Then k = n Else k = n \ 2
        sum = 0
        Call cp(n, k, HH, p, F, z)
        sum = sum + calc(IsBoxDavis, h, o, p, k, n_order)
        While F = False
            Call cp(n, k, HH, p, F, z)
            If Not (UseOne) Then
                i = 1
                While ((p(i) <> 1) And (i < k + 1))
                    i = i + 1
                End While
                If i = (k + 1) Then
                    sum = sum + calc(IsBoxDavis, h, o, p, k, n_order)
                    icount = icount + 1
                End If
            Else
                sum = sum + calc(IsBoxDavis, h, o, p, k, n_order)
                icount = icount + 1
            End If
        End While
        BoxDavisSum = sum
    End Function

    Sub BoxDavis1(UseOne As Boolean, Order As Integer,
f1 As Double, X As Double, ByRef o() As Double,
                        ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim start As Integer, i As Integer, j As Integer
        Dim S(0 To 100) As Double, F(0 To 100) As Double, h(0 To 100) As Double
        Dim density As Double, xr As Double, S1 As Double, s2 As Double, show As Boolean
        show = True
        If UseOne Then start = 1 Else start = 2
        F(1) = f1
        h(1) = X / f1
        xr = X
        For j = 2 To Order
            F(j) = F(j - 1) * (f1 + 2 * j - 2)
            xr = xr * X
            h(j) = h(j - 1) + xr / F(j)
        Next j
        Call cdis2(f1, X, LeftTail, RightTail, density)
        S1 = RightTail
        For i = start To Order
            S(i) = BoxDavisSum(True, UseOne, h, o, i, 0)
        Next i
        s2 = 0
        If Not (UseOne) Then S(1) = 0
        If show Then Console.WriteLine("Adjustments: ")
        For i = start To Order
            s2 = s2 + S(i)
            If show Then Console.WriteLine(" i: {0}, s2: {1}, S(i): {2}", i, s2, S(i))
        Next i
        s2 = s2 * 2 * cdens(f1, X)
        S1 = S1 + s2
        LeftTail = 1 - S1
        RightTail = S1
    End Sub

    Sub NdensDeriv(k As Integer, X As Double, ByRef z() As Double)
        Dim m As Integer
        Const sqrt2pi = 0.398942280401433
        z(0) = Math.Exp(-X * X / 2) * sqrt2pi
        z(1) = -X * z(0)
        For m = 0 To k - 2
            z(m + 2) = -X * z(m + 1) - (m + 1) * z(m)
        Next m
    End Sub

    Private Sub CF(nord As Integer, X As Double, ByRef ac() As Double, ByRef del() As Double)
        ' Calculates adjustments for Cornish expansion
        Dim a() As Double, d() As Double, h() As Double, p() As Double
        Dim j As Integer, ja As Integer, jal As Integer, jb As Integer, jbl As Integer, k As Integer, L As Integer
        Dim aa As Double, bc As Double, cc As Double, DD As Double, fac As Double
        ReDim a(nord)
        ReDim d(nord)
        ReDim h(3 * nord)
        ReDim p((3 * nord) * (nord + 1) \ 2)
        cc = -1
        For j = 1 To nord
            a(j) = cc * ac(j) / ((j + 1) * (j + 2))
            cc = -cc
        Next j
        h(1) = -X
        h(2) = X * X - 1
        For j = 3 To 3 * nord
            h(j) = -(X * h(j - 1) + (j - 1) * h(j - 2))
        Next j
        For j = 1 To 3 * nord * (nord + 1) \ 2
            p(j) = 0
        Next j
        d(1) = -a(1) * h(2)
        del(1) = d(1)
        p(1) = d(1)
        p(3) = a(1)
        ja = 0
        fac = 1
        For j = 2 To nord
            fac = fac * j
            ja = ja + 3 * (j - 1)
            jb = ja
            bc = 1
            For k = 1 To j - 1
                DD = bc * d(k)
                aa = bc * a(k)
                jb = jb - 3 * (j - k)
                For L = 1 To 3 * (j - k)
                    jbl = jb + L
                    jal = ja + L
                    p(jal + 1) = p(jal + 1) + DD * p(jbl)
                    p(jal + k + 2) = p(jal + k + 2) + aa * p(jbl)
                Next L
                bc = bc * (j - k) / k
            Next k
            p(ja + j + 2) = p(ja + j + 2) + a(j)
            d(j) = 0
            For L = 2 To 3 * j
                d(j) = d(j) - p(ja + L) * h(L - 1)
            Next L
            p(ja + 1) = d(j)
            del(j) = d(j) / fac
            'Console.WriteLine("del(j): {0}, fac: {1}", del(j), fac)

        Next j
    End Sub

    Sub CalcEdgeworth(UpdateNdis As Boolean, UseOnlyEvenCumulants As Boolean, deriv As Integer,
Order As Integer, X As Double, ByRef o() As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        ' UpdateNdis: true if recalculation of ndis and ndensderiv is required
        ' UseOnlyEvenCumulants: true, if only even cumulants are used
        ' deriv: 0 for CDF, 1 for density, or k for kth. derivative of CDF
        ' order: number of standardized cumulants to be used in the calculation
        ' o: array of standardised cumulants
        ' x: standardized approx. normal variate, for which cdf is evaluated
        ' LeftTail, RightTail: result
        Dim i As Integer, n_order As Integer
        Dim S(0 To 100) As Double
        Static h(0 To 100) As Double
        Dim S1 As Double, s2 As Double, s3 As Double
        If UpdateNdis Then Call NdensDeriv(100, X, h)
        If deriv <= 0 Then S1 = ndis(X) Else S1 = h(deriv - 1)
        s3 = ndis(-X)
        For i = 1 To Order
            n_order = deriv
            If UseOnlyEvenCumulants Then n_order = n_order + i
            S(i) = BoxDavisSum(False, True, h, o, i, n_order)
        Next i
        s2 = 0
        For i = 1 To Order
            s2 = s2 + S(i)
            Console.WriteLine("i: {0}, S(i): {1}, S1 + s2: {2}", i, S(i), S1 + s2)
        Next i
        's2 = S1 + s2
        LeftTail = S1 + s2
        If deriv > 0 Then RightTail = 1 - LeftTail Else RightTail = s3 - s2
    End Sub

    Function CalcCornish(LeftTail As Double, RightTail As Double,
mean As Double, sigma As Double, ByRef kappa() As Double, nord As Integer) As Double
        Dim i As Integer, S As Double, X As Double, ac() As Double, del() As Double
        'Dim m As Integer, m1 As Integer, m2 As Integer
        ReDim ac(nord) : ReDim del(nord)
        S = sigma * sigma
        For i = 3 To nord
            S = S * sigma
            ac(i - 2) = kappa(i) / S
        Next i
        X = ndisx(LeftTail, RightTail)
        Call CF(nord, X, ac, del)

        'm1 = 1
        'm2 = 2
        'For i = 1 To nord - 2 Step 2
        '    If Math.Abs(del(i)) < Math.Abs(del(m1)) Then m1 = i
        '    '    sum = sum + del(i)
        '    '    Debug.Print i, del(i), x + del(i), sum
        'Next i
        'For i = 2 To nord - 2 Step 2
        '    If Math.Abs(del(i)) < Math.Abs(del(m2)) Then m2 = i
        '    '    sum = sum + del(i)
        '    '    Debug.Print i, del(i), x + del(i), sum
        'Next i
        'If del(m1) > del(m2) Then m = m1 Else m = m2
        ''  m = 20

        '  For i = 1 To m
        'Console.WriteLine("X: {0}", X)
        For i = 1 To nord - 2
            X = X + del(i)
            Console.WriteLine("X: {0}, del(i): {1}, del(i)/X: {2}", X, del(i), del(i) / X)

        Next i
        '    Debug.Print "m: ", m, "x: ", x
        CalcCornish = mean + sigma * X
    End Function

    Function InvCorn(sg2 As Double, LeftTail As Double, RightTail As Double, mean As Double, sigma As Double, ByRef k() As Double, Order As Integer) As Double
        Dim delta As Double, Factor As Double, FoundLimit As Boolean, i As Integer
        Dim x1 As Double, x2 As Double, x3 As Double, fx1 As Double, fx2 As Double, fx3 As Double
        Dim Leftx1 As Double, Leftx2 As Double, Rightx1 As Double, Rightx2 As Double, UseLeftTail As Boolean

        Leftx2 = Math.Abs(LeftTail)
        Rightx2 = Math.Abs(RightTail)
        If Leftx2 < Rightx2 Then Rightx2 = 1 - Leftx2 Else Leftx2 = 1 - Rightx2

        ' Debug.Print "sg2,LeftTail,RightTail: ", sg2, Leftx2, Rightx2
        fx2 = CalcCornish(Leftx2, Rightx2, mean, sigma, k, Order)
        ' Debug.Print "Cornish X2:", Leftx2, Rightx2, fx2
        If fx2 > sg2 Then Factor = 2 Else Factor = 0.5
        Do
            Leftx1 = Leftx2 : Rightx1 = Rightx2 : fx1 = fx2
            If Rightx1 < 0.5 Then
                Rightx2 = Rightx1 * Factor
                Leftx2 = 1 - Rightx2
            Else
                Leftx2 = Leftx1 / Factor
                Rightx2 = 1 - Leftx2
            End If
            fx2 = CalcCornish(Leftx2, Rightx2, mean, sigma, k, Order)
            If Factor = 0.5 Then FoundLimit = fx2 > sg2 Else FoundLimit = fx2 <= sg2
            '   Debug.Print "Cornish X2:", Leftx2, Rightx2, fx2, FoundLimit
        Loop Until FoundLimit
        If Leftx2 < 0.5 Then
            x1 = Leftx1
            x2 = Leftx2
            UseLeftTail = True
        Else
            x1 = Rightx1
            x2 = Rightx2
            UseLeftTail = False
        End If
        i = 0
        Do
            i = i + 1
            If (fx2 - fx1) = 0 Then
                x3 = x2 : Exit Do
            End If
            x3 = x1 - ((x2 - x1) / (fx2 - fx1)) * (fx1 - sg2)
            If UseLeftTail Then
                Leftx1 = x3 : Rightx1 = 1 - Leftx1
            Else
                Rightx1 = x3 : Leftx1 = 1 - Rightx1
            End If
            fx3 = CalcCornish(Leftx1, Rightx1, mean, sigma, k, Order) 'l2
            If sg2 <> 0 Then delta = Math.Abs((fx3 - sg2) / sg2) Else delta = 0
            '        Console.WriteLine("x3: {0}, fx3: {1}, delta: {2}", x3, fx3, delta)
            x1 = x2 : x2 = x3 : fx1 = fx2 : fx2 = fx3
            '    Debug.Print x3, fx3, delta
        Loop Until ((delta < 0.000000000000001) Or (i > 100))
        '  Debug.Print "Result:", x3
        If UseLeftTail Then InvCorn = x3 Else InvCorn = 1 - x3
    End Function


    Sub CalcChiPowerRawMoments(m As Integer, n As Double, L As Double, ByRef mraw() As Double)
        Dim a As Double
        Dim k As Integer
        a = n / 2
        For k = 1 To m
            mraw(k) = Math.Exp(LnGamma(a + k * L) - LnGamma(a) - Math.Log(0.5) * k * L)
        Next k
    End Sub




    Sub CalcChiPowerCumulants(k As Integer, n As Double, L As Double, ByRef kappa() As Double)
        Dim mraw() As Double, mu() As Double
        'Dim i As Integer
        ReDim mraw(k) : ReDim mu(k)
        '  Call FindL(N, L)
        Call CalcChiPowerRawMoments(k, n, L, mraw)
        '!!!!! Replace with RawMomentsToCumulants !!!!
        Call RawMomentsToMoments(k, mraw, mu)
        Call MomentsToCumulants(k, mu, kappa)
        '!!!!! Replace with RawMomentsToCumulants !!!!
    End Sub



    Sub DemoPowerCumulants()
        Dim i As Integer, k As Integer, n As Double, L As Double, kappa() As Double
        Dim mean As Double, sigma As Double, omega() As Double
        Dim X As Double, z As Double, LeftTail As Double, RightTail As Double
        k = 9
        n = 30
        L = 1 / 3
        RightTail = 0.001
        LeftTail = 1 - RightTail
        X = cdisx(LeftTail, RightTail, n)
        X = X ^ L
        mean = X
        ReDim kappa(k)
        ReDim omega(k)
        Call CalcChiPowerCumulants(k, n, L, kappa)
        Call CumulantToGamma(k, mean, sigma, kappa, omega)
        Console.WriteLine("Lambda: {0}", L)
        For i = 1 To k
            Console.WriteLine("i: {0}, kappa(i): {1}, omega(i): {2}", i, kappa(i), omega(i))
        Next i
        mean = X - kappa(1)
        z = mean / sigma
        Console.WriteLine("mean: {0}, sigma: {1}, kappa(1): {2}, Sqr(kappa(2)): {3}", mean, sigma, kappa(1), Math.Sqrt(kappa(2)))
        Console.WriteLine("n: {0}, X: {1}, z: {2}, ndis(-z): {3}", n, X, z, ndis(-z))
        Call CalcEdgeworth(True, False, 0, k - 2, z, omega, LeftTail, RightTail)
        Console.WriteLine("Edgeworth LeftTail: {0}, RightTail: {1}", LeftTail, RightTail)

    End Sub






    'Get cumulants from discrete null-distribution
    Sub GetCumulants(nl As Integer, maxmoment As Integer, ByRef X() As Double, ByRef kappa() As Double)
        Dim S As Integer, i As Integer, j As Integer
        Dim sk As Double, mu() As Double
        S = -nl
        ReDim mu(maxmoment) : ReDim kappa(maxmoment)
        For j = 1 To maxmoment : mu(j) = 0 : Next j
        For i = 0 To nl
            sk = 1
            For j = 1 To maxmoment Step 1
                sk = sk * S
                If j Mod 2 = 0 Then mu(j) = mu(j) + X(i) * sk
            Next j
            S = S + 2
        Next i
        Call MomentsToCumulants(maxmoment, mu, kappa)
        '  Debug.Print "Cumulants"
        '  For j = 1 To maxmoment
        '    Debug.Print j, mu(j), kappa(j)
        '  Next j

    End Sub




    Function JTCum(j As Integer, k As Integer, ByRef n() As Integer, ByRef m() As Integer) As Double
        ' Robillard, 1972
        Dim F As Double, i As Integer, j2 As Integer, j21 As Integer, k1 As Integer,
          nn As Integer, sum As Double
        nn = m(k)
        k1 = k
        j2 = j
        j21 = j2 + 1
        sum = 0
        F = 1
        For i = 1 To j
            F = F * 2
        Next i
        For i = 1 To k
            sum = sum + Bernoulli(j21, n(i) + 1)
        Next i
        JTCum = F * Bn0(j2) / (1.0 * j2 * j21) _
                * (Bernoulli(j21, nn + 1) + (k - 1) * Bn0(j21) - sum)
    End Function

    Sub TerpstaCum(k As Integer, n() As Integer, maxmoment As Integer, ByRef kappa() As Double, ByRef TS As Integer)
        Dim m(k) As Integer, j As Integer
        'Dim TS As Integer
        '  ReDim m(k) As Integer
        m(0) = 0
        For j = 1 To k
            m(j) = m(j - 1) + n(j)
        Next j
        TS = 0
        For j = 1 To k - 1 : TS = TS + m(j) * n(j + 1) : Next j
        '  Debug.Print "TS:", TS
        For j = 2 To maxmoment Step 2
            kappa(j) = JTCum(j, k, n, m)
        Next j
    End Sub


    Sub KendallCum(n As Integer, maxcum As Integer, ByRef kappa() As Double, ByRef nl As Integer)
        'Praskova, 1976
        Dim j2 As Integer, j As Integer ', t As Integer, r As Integer
        Dim sign As Double, sum As Double, p2 As Double
        Dim Bern As Double, Bn0j2_1 As Double, Bn0j2 As Double
        maxcum = maxcum \ 2
        For j = 1 To 2 * maxcum
            kappa(j) = 0.0
        Next j
        p2 = 0.5
        For j = 1 To maxcum
            If ((j Mod 2) <> 0) Then sign = 1.0 Else sign = -1.0
            j2 = 2 * j
            p2 = p2 * 4.0
            Bern = Bernoulli(j2 + 1, n + 1.0)
            Bn0j2_1 = Bn0(j2 + 1)
            sum = (Bern - Bn0j2_1) / (j2 + 1.0)

            Bn0j2 = Math.Abs(Bn0(j2))
            Console.WriteLine("Bern: {0}, Bn0j2: {1}, sum: {2}, Bn0j2: {3}", Bern, Bn0j2_1, sum, Bn0j2)

            kappa(j2) = sign * p2 * Math.Abs(Bn0(j2)) * (sum - n) / j
            '  Debug.Print j2, "  ", kappa(j2)
        Next j
        nl = n * (n - 1) \ 2
    End Sub



    Sub WilcoxonCum(n As Integer, maxcum As Integer, ByRef kappa() As Double, ByRef nl As Integer)
        ' Fellingham, 1964
        Dim gamma(0 To 20) As Double
        Dim j2 As Integer, j As Integer ', t As Integer, r As Integer
        Dim sum As Double, p2 As Double
        Dim S As Double, sigma2 As Double
        maxcum = maxcum \ 2
        For j = 1 To 2 * maxcum : gamma(j) = 0.0 : kappa(j) = 0.0 : Next j
        sigma2 = 1.0 * n * (n + 1.0) * (2.0 * n + 1.0) / 6.0
        kappa(2) = sigma2
        S = sigma2
        p2 = 4.0
        For j = 2 To maxcum
            j2 = 2 * j
            p2 = p2 * 4.0
            sum = (Bernoulli(j2 + 1, n + 1.0) - Bn0(j2 + 1)) / (j2 + 1.0)
            S = S * sigma2
            kappa(j2) = p2 * (p2 - 1.0) * (Bn0(j2)) * (sum) / (j2)
            gamma(j2 - 2) = p2 * (p2 - 1.0) * (Bn0(j2)) * (sum) / (j2 * S)
            '  Debug.Print j2, "  ", kappa(j2), gamma(j2 - 2)
        Next j
        nl = n * (n + 1) \ 2
    End Sub







    Sub SpearmanCalcdemo0()
        Dim X() As Double, nl As Integer, n As Integer
        n = 8
        Call SpearmanCalc(n, 0, nl, X)
        '    SpearmanCalcdemo = X
    End Sub


    'Function SpearmanCalcdemo(ByVal n As Integer) As Variant
    'Dim X() As Double, nl As Integer
    '    Call SpearmanCalc(n, 0, nl, X)
    '    SpearmanCalcdemo = X
    'End Function

    Sub SpearmanCalc(n As Integer, Order As Integer, ByRef Valcount As Integer, ByRef xx() As Double)
        Dim X() As Integer, y() As Integer, p() As Integer, d() As Integer, result() As Integer
        Dim i As Integer, nn As Integer, count As Integer, sum As Integer, k As Integer
        Dim Q As Integer, Upper As Integer, lower As Integer, t As Integer
        Dim fraction As Double
        Dim First As Boolean
        If n <= 0 Then Exit Sub
        ReDim X(n) : ReDim y(n)
        ReDim p(n) : ReDim d(n)
        nn = n : First = True
        count = 0 : Upper = 0 : lower = 0
        For i = 1 To nn
            X(i) = i : y(i) = i
        Next i

        '  If Order > 0 Then
        '  Select Case n
        '    Case 3:  Select Case Order '3 groups
        '      Case 1:                    ' linear: no change
        '      Case 2:  X(1) = 0: X(2) = 1: X(3) = 1 'quadratic
        '    End Select
        '    Case 4: Select Case Order '4 groups
        '      Case 1:                   ' linear: no change
        '      Case 2:  X(1) = 0: X(2) = 0: X(3) = 1: X(4) = 1 ' quadratic
        '      Case 3:                   'cubic: no Change
        '    End Select
        '    Case 5: Select Case Order '5 groups
        '      Case 1:                   ' linear: no change
        '      Case 2:  X(1) = 0: X(2) = 1: X(3) = 1: X(4) = 4: X(5) = 4 ' quadratic
        '      Case 3:                   ' cubic: no change
        '      Case 4:  X(1) = 0: X(2) = 0: X(3) = 1: X(4) = 1: X(5) = 2 ' quartic
        '    End Select
        '  End Select
        '  End If

        For i = 1 To nn
            Upper = Upper + X(i) * y(i)
            lower = lower + X(i) * y(nn + 1 - i)
        Next i
        Valcount = Upper - lower
        ReDim result(Valcount) : ReDim xx(Valcount)
        For i = 0 To Valcount : result(i) = 0 : Next i
        '  Debug.Print "Lower:", Lower, "Upper:", Upper, "ValCount:", Valcount
        Do
            n = nn
            If First Then
                For k = 2 To n
                    p(k) = 0 : d(k) = 1
                Next k
                First = False
            End If
            k = 0
index1:
            Q = p(n) + d(n)
            p(n) = Q
            If Q = n Then
                d(n) = -1 : GoTo loop1
            End If
            If Q <> 0 Then GoTo transpose1
            d(n) = 1 : k = k + 1
loop1:
            If n > 2 Then
                n = n - 1 : GoTo index1
            End If
            Q = 1 : First = True
transpose1:
            Q = Q + k
            t = X(Q) : X(Q) = X(Q + 1) : X(Q + 1) = t
            count = count + 1
            sum = 0
            For i = 1 To nn : sum = sum + (X(i) * y(i)) : Next i
            result(sum - lower) = result(sum - lower) + 1
        Loop Until First = True
        ' Debug.Print "Anzahl der Permutationen:", count
        For i = 0 To Valcount
            fraction = (1.0# * result(i)) / (1.0# * count)
            Console.WriteLine(" i: {0}, fraction: {1}", i, fraction)
            xx(i) = fraction
        Next i
        Erase X : Erase y : Erase X : Erase p : Erase d
        Erase result
    End Sub

    Function PageQuadeCalc(ByVal UseRanks As Boolean, ByVal k As Integer, ByVal n As Integer, ByVal Order As Integer) As Double()
        Dim h As Integer, pl As Integer, j As Integer, i As Integer, F As Integer, ql As Integer, Q() As Double
        Dim p() As Double, r() As Double
        If UseRanks Then F = n * (n + 1) \ 2 Else F = n
        Call SpearmanCalc(k, Order, pl, p)
        ReDim Q(pl * F) : ReDim r(pl * F)
        For i = 0 To pl : Q(i) = p(i) : Next i
        ql = pl
        For h = 2 To n
            If UseRanks Then F = h Else F = 1
            For i = 0 To pl
                For j = 0 To ql
                    r(F * i + j) = r(F * i + j) + p(i) * Q(j)
                Next j
            Next i
            ql = ql + F * pl
            For i = 0 To ql : Q(i) = r(i) : r(i) = 0 : Next i
        Next h
        PageQuadeCalc = Q
    End Function

    'Sub PageCalc(ByVal k As Integer, ByVal N As Integer, nl As Integer, x() As Double)
    '    Call PageQuadeCalc(False, k, N, 0, nl, x())
    'End Sub

    'Sub PageQCalc(ByVal k As Integer, ByVal N As Integer, nl As Integer, x() As Double)
    '    Call PageQuadeCalc(True, k, N, 0, nl, x())
    'End Sub

    'Sub WilcoxonCalc(ByVal N As Integer, nl As Integer, x() As Double)
    '    Call PageQuadeCalc(True, 2, N, 0, nl, x())
    'End Sub

    'Sub SignCalc(ByVal N As Integer, nl As Integer, x() As Double)
    '    Call PageQuadeCalc(False, 2, N, 0, nl, x())
    'End Sub

    Sub PageCum(k As Integer, n As Integer, maxmoment As Integer, ByRef kappa() As Double, ByRef nl As Integer)
        Dim X() As Double, kl As Integer, i As Integer
        Call SpearmanCalc(k, 0, kl, X)
        Call GetCumulants(kl, maxmoment, X, kappa)
        For i = 1 To maxmoment : kappa(i) = kappa(i) * n : Next i
        Erase X
        nl = n * kl
        Console.WriteLine("nl: {0}", nl)
    End Sub



    Sub CornishEdgeworthDemo()
        Dim i As Integer
        Dim k(0 To 100) As Double, o(0 To 100) As Double
        Dim mean As Double, X As Double, sigma As Double, F As Double
        Dim LeftTail As Double, RightTail As Double ', density As Double
        Dim Order As Integer
        Order = 20
        F = 100
        LeftTail = 1 - 0.00001
        RightTail = 1 - LeftTail

        k(1) = F
        For i = 2 To Order
            k(i) = k(i - 1) * 2 * (i - 1)
        Next i
        '  Call CumulantToGamma(order, mean, sigma, k(), o())
        '  For i = 1 To order
        '    Debug.Print i, k(i), o(i)
        '  Next i
        '  Exit Sub
        mean = k(1)
        sigma = Math.Sqrt(k(2))
        X = CalcCornish(LeftTail, RightTail, mean, sigma, k, Order)
        Console.WriteLine("Cornish X: {0}", X)
        Console.WriteLine("Exact   X: {0}", cdisx(LeftTail, RightTail, F))
        'Call CumulantToGamma(Order, X, sigma, k, o)
        'Call CalcEdgeworth(True, False, 0, Order - 2, (X - mean) / sigma, o, LeftTail, RightTail)
        'Console.WriteLine(  "Edgeworth LeftTail: {0}, RightTail: {1}", RightTail, LeftTail)
        'Call cdis2(F, X, LeftTail, RightTail, density)
        'Console.WriteLine(  "Excat LeftTail: {0}, RightTail: {1}", RightTail, LeftTail)
    End Sub




    Sub InversCornishEdgeworthDemo()
        Dim i As Integer
        Dim k(0 To 100) As Double, o(0 To 100) As Double
        Dim mean As Double, X As Double, sigma As Double, F As Double
        Dim LeftTail As Double, RightTail As Double ', density As Double
        Dim Order As Integer ', delta As Double, Factor As Double, FoundLimit As Boolean
        Dim sg2 As Double ', x1 As Double, x2 As Double, x3 As Double, fx1 As Double, fx2 As Double, fx3 As Double
        Order = 10
        F = 80
        RightTail = 0.000001
        LeftTail = 1 - RightTail
        'RightTail = 1 - LeftTail

        k(1) = F
        For i = 2 To Order
            k(i) = k(i - 1) * 2 * (i - 1)
        Next i
        mean = k(1)
        sigma = Math.Sqrt(k(2))
        sg2 = cdisx(LeftTail, RightTail, F)
        X = sg2
        Console.WriteLine("Exact   X: {0}", sg2)
        Call CumulantToGamma(Order, X, sigma, k, o)
        Call CalcEdgeworth(True, False, 0, Order - 2, (X - mean) / sigma, o, LeftTail, RightTail)
        Console.WriteLine("Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

        Dim Result As Double = InvCorn(sg2, LeftTail, RightTail, mean, sigma, k, Order)
        Console.WriteLine("LeftTail: {0}, RightTail: {1}", Result, 1 - Result)

    End Sub



    Sub KendallInversCornishEdgeworthDemo()
        'Dim i As Integer
        Dim kappa(0 To 100) As Double, o(0 To 100) As Double
        Dim mean As Double, X As Double, sigma As Double ', F As Double
        Dim LeftTail As Double, RightTail As Double, sumKR As Double ', density As Double
        Dim Order As Integer ', delta As Double, Factor As Double, FoundLimit As Boolean
        'Dim sg2 As Double', x1 As Double, x2 As Double, x3 As Double, fx1 As Double, fx2 As Double, fx3 As Double
        Dim n As Int32, nl As Int32

        Order = 32
        n = 40
        RightTail = 0.00000000000001
        LeftTail = 1 - RightTail
        'RightTail = 1 - LeftTail

        Call KendallCum(n, Order, kappa, nl)  'Kendall  

        Dim i As Int32 = 0
        Dim d As Double = 1
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*Bn0(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * Bn0(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i
        Dim KR = KendallCalc(n)


        X = -610

        i = 0
        Dim CDF_KR(nl + 1) As Double
        For Index = -nl To 0 Step 2
            sumKR = sumKR + KR(i)
            CDF_KR(i) = sumKR
            If (Math.Abs(Math.Abs(X) - Math.Abs(Index)) < 10) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
            i = i + 1
        Next Index



        mean = kappa(1)
        sigma = Math.Sqrt(kappa(2))
        '  sg2 = cdisx(LeftTail, RightTail, F)
        '  X = sg2
        '  Console.WriteLine( "Exact   X: {0}", sg2)
        Call CumulantToGamma(Order, X, sigma, kappa, o)
        '  Call CalcEdgeworth(True, False, 0, Order - 2, (X - mean) / sigma, o, LeftTail, RightTail)

        Dim z As Double = (X - mean) / sigma
        LeftTail = ndis(z)
        RightTail = 1 - LeftTail


        '  Call CalcEdgeworth(True, False, 0, 0, (X - mean) / sigma, o, LeftTail, RightTail)
        Console.WriteLine("Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

        Dim xpos As Int32 = Convert.ToInt32((X + nl)) \ 2
        Dim ExactResult As Double = CDF_KR(xpos - 1)
        Console.WriteLine("ExactResult: {0}", ExactResult)

        '  For Order_i = 2 To Order Step 2
        '      Dim Result As Double = InvCorn(X-0, LeftTail, RightTail, mean, sigma, kappa, Order_i)
        '      Console.WriteLine("Order_i: {0}, LeftTail: {1}, RefDiff: {2}", Order_i, Result, (ExactResult-Result)/ExactResult)
        '      LeftTail = Result: RightTail = 1-LeftTail
        '  Next

        Dim S(,) As Double
        ReDim S(20, 20)



        Dim j As Int32 = 0
        For Order_i = 4 To Order Step 2
            Dim Result As Double = InvCorn(X - 0, LeftTail, RightTail, mean, sigma, kappa, Order_i)
            'Console.WriteLine("Order_i: {0}, LeftTail: {1}, RefDiff: {2}", Order_i, Result, (ExactResult - Result) / ExactResult)
            LeftTail = Result : RightTail = 1 - LeftTail
            S(j, 0) = LeftTail
            j = j + 1
        Next

        Dim k As Int32 = j - 1
        For j = 0 To k
            Console.WriteLine("j: {0}, S(j, 0): {1}", j, S(j, 0))
        Next

        For j = 0 To k - 1
            S(j, 1) = 1 / (S(j + 1, 0) - S(j, 0))
        Next

        For j = 0 To k - 1
            Console.WriteLine("j: {0}, S(j, 1): {1}", j, S(j, 1))
        Next

        Dim m As Int32

        For m = 2 To 14

            For j = 0 To k - m
                S(j, m) = S(j + 1, m - 2) + 1 / (S(j + 1, m - 1) - S(j, m - 1))
            Next

            For j = 0 To k - m
                Console.WriteLine("j: {0}, S(j, m): {1}", j, S(j, m))
            Next

        Next m

        Console.WriteLine("ExactResult: {0}", ExactResult)


    End Sub


    Sub DemoShanks()
        Dim S(,) As Double
        ReDim S(40, 40)

        Dim k As Int32 = 8

        Dim sum = 0.0
        For j = 0 To k
            Dim n = j + 0
            Dim temp = 4 * ((-1) ^ n) / (2 * n + 1)
            sum = sum + temp
            S(j, 0) = sum
        Next

        For j = 0 To k
            Console.WriteLine("j: {0}, S(j, 0): {1}", j, S(j, 0))
        Next

        'Exit Sub

        For j = 0 To k - 1
            s(j, 1) = 1 / (s(j + 1, 0) - s(j, 0))
        Next

        For j = 0 To k - 1
            Console.WriteLine("j: {0}, S(j, 1): {1}", j, s(j, 1))
        Next

        Dim m As Int32

        For m = 2 To k

            For j = 0 To k - m
                S(j, m) = S(j + 1, m - 2) + 1 / (S(j + 1, m - 1) - S(j, m - 1))
            Next

            For j = 0 To k - m
                Console.WriteLine("j: {0}, S(j, m): {1}", j, S(j, m))
            Next

        Next m

        'Console.WriteLine("ExactResult: {0}", ExactResult)


    End Sub





    Sub ListNullCDFbyCumDemo()
        Dim k As Integer
        Dim j As Integer, maxmoment As Integer, i As Integer, dis As Integer
        'Dim kappa() As Double, o() As Double
        Dim mu As Double, sigma As Double, X As Double, RightTail As Double
        Dim Index As Integer ', index2 As Integer
        Dim OnlyEvenCumulants As Boolean, LeftTail0 As Double, LeftTail2 As Double

        'Dim sum As Double, LeftTail As Double, S1 As Double, s2 As Double, b As Double

        Dim nl As Integer
        'Dim sigma_old As Double
        Console.WriteLine("PermCumulants")
        '  OnlyEvenCumulants = True
        OnlyEvenCumulants = False
        dis = 6
        maxmoment = 12
        Dim o(maxmoment) As Double
        Dim kappa(maxmoment) As Double
        k = 3 : Dim n(k) As Integer
        For j = 1 To k : n(j) = 20 : Next j
        'nl is the highest score, counted continuously from 0 to nl with spacing 1
        'the mean is nl/2 with spacing of 1
        'All cumulants assume a spacing of 2
        Select Case dis
            Case 1 : Call TerpstaCum(k, n, maxmoment, kappa, nl) 'Terpsta
            Case 2 : Call TerpstaCum(2, n, maxmoment, kappa, nl) 'Mann-Whitney
            Case 3 : Call WilcoxonCum(n(1), maxmoment, kappa, nl) 'Wilcoxon
            Case 4 : Call KendallCum(n(1), maxmoment, kappa, nl)  'Kendall
'    Case 5: Call SpearmanCum(n, maxmoment, kappa, nl) 'Spearman
            Case 6 : Call PageCum(k, n(1), maxmoment, kappa, nl) 'Page
        End Select
        'Exit Sub

        Dim d As Double = 1
        For i = 1 To maxmoment
            d = 2 * d
            Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d * Bn0(i) / i)
            If (i > 0) Then kappa(i) = kappa(i) - d * Bn0(i) / i
            Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        Exit Sub

        Dim KR = KendallCalc(n(1))


        '     Dim kappa2(maxmoment) As Double
        'GetCumulants(nl, maxmoment, KR, kappa2)
        '   For i = 1 To maxmoment
        '      Console.WriteLine("i: {0}, kappa2(i): {1}, Bn0(i): {2}", i, kappa2(i), (2^i)*Bn0(i)/i)
        '   Next i


        sigma = Math.Sqrt(kappa(2))
        Call CumulantToGamma(maxmoment, 0, sigma, kappa, o)

        If OnlyEvenCumulants Then
            maxmoment = maxmoment \ 2 - 1
            For i = 1 To maxmoment
                o(i) = o(2 * i) ': o(2 * i) = 0
            Next i
        End If

        'change to a spacing of 1

        Dim sumKR As Double = 0.0
        '  For i=0 To nl
        '         sumKR = sumKR +  KR(i)
        '   Console.WriteLine(" KR(i): {0}, sumKR: {1}", KR(i), sumKR)
        'Next

        sumKR = 0.0


        '  sigma = sigma / 2
        '  mu = 1# * nl / 2
        '  For Index = 0 To nl

        sigma = sigma / 1
        mu = 0
        i = 0
        Dim CDF_KR(nl + 1) As Double
        For Index = -nl To nl Step 2
            sumKR = sumKR + KR(i)
            CDF_KR(i) = sumKR
            i = i + 1
        Next Index

        sumKR = 0.0
        i = 0
        For Index = -100 To 100 Step 2
            '  For Index = -nl To nl Step 2

            '      X = (Index - mu + 0.5) / sigma
            X = (Index - mu + 1.0) / sigma

            Call CalcEdgeworth(True, OnlyEvenCumulants, 0, maxmoment, X, o, LeftTail0, RightTail)
            Call CalcEdgeworth(True, OnlyEvenCumulants, 0, 0, X, o, LeftTail2, RightTail)

            '  
            '  X = (Index - mu) / sigma
            '  Call CalcEdgeworth(True, True, 0, maxmoment, X, o, LeftTail, RightTail)
            '  sum = LeftTail
            '  s2 = 1
            '  For i = 1 To 2 'maxmoment
            '    Call CalcEdgeworth(False, True, i, maxmoment, X, o, LeftTail, RightTail)
            '    b = Bn0(i)
            '    s2 = s2 * sigma * i
            '    S1 = b * (LeftTail) / s2
            '    If i = 2 Then S1 = -S1
            '' Debug.Print i, LeftTail, sigma * x, sum, S1, s2, b
            '    sum = sum - S1
            '  Next i

            '1 * (Index - mu)
            '    sumKR = sumKR +  KR(i)
            sumKR = CDF_KR((Index + nl) \ 2)


            Console.WriteLine("i: {0}, s: {1}, L0: {2}, L2: {3}, L2: {4}, L2: {5}, D2: {6}", 1 * (Index - mu), sumKR, LeftTail0, LeftTail2, (LeftTail0 - sumKR) / sumKR, (LeftTail2 - sumKR) / sumKR, (LeftTail2 - sumKR) / (LeftTail0 - sumKR))
            '  Console.WriteLine("i: {0}, s: {1}, L: {2}",  2 * (Index - mu), sumKR, LeftTail2)
            '  i = i + 1
        Next Index


    End Sub










End Module
