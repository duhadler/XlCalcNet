Imports FixedPrecNet
Imports ArbPrecNet


Module PermFriedman



    Sub DemoFriedman()

        Dim Result As Object, What As Integer, k As Integer, n As Integer, Quade As Integer, Mode As Integer, Mode2 As Integer
        What = 0 ' not just titles
        k = 3  ' number of groups
        n = 10 ' Number of blocks
        Quade = 1  ' 1=friedman 2=quade
        Mode = 1  ' 1=anova 2=page
        Mode2 = 5 '1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit
        Result = Friedman(What, k, n, Quade, Mode, Mode2)
    End Sub

    Function Friedman(GetWhat As Integer, sum2 As Integer, n As Integer, Quade As Integer,
Mode As Integer, Mode2 As Integer) As Object

        ' sum2 : number of groups
        ' n: Number of blocks
        ' quade: 1=friedman 2=quade
        ' ties:  'J'
        ' asymend : number of asymmetric blocks
        ' mode : 1=anova 2=page
        ' mode2: 1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit
        Const vlimit = 1000000
        Dim Output(,) As Double ', title() As String
        Dim vfak() As Double, zfak() As Double, rv() As Double, rvfak() As Double
        Dim v(,) As Integer, zv(,) As Integer
        Dim w() As Integer, zz() As Integer, b() As Integer, y() As Integer
        Dim z() As Integer, diff() As Integer
        Dim perm(,) As Integer, pfak() As Integer
        Dim x(,) As Integer
        Dim k As Integer, asymend As Integer, vlength As Integer, permanz As Integer
        Dim rsum As Integer, i As Integer, j As Integer, ve As Integer, vneuend As Integer
        Dim Last As Integer, k1 As Integer, k2 As Integer, lh As Integer
        Dim i1 As Integer, i2 As Integer, m As Integer, m1 As Integer, l As Integer, r As Integer
        Dim h As Integer, w1 As Integer, pn As Integer, s2 As Integer, nr As Integer
        Dim permneu As Integer, k3 As Integer, mean As Integer, fit As Integer, it As Integer
        Dim lastrsum As Integer, sdiv2 As Integer, sumanz As Integer, yk As Integer
        Dim vref As Integer, sum3 As Integer, tsum As Integer, slength As Integer
        Dim sanz As Integer, dloop As Integer, dun1 As Integer, dun As Integer
        Dim zfaki1 As Double, s As Double, zfaki As Double, Varianz As Double
        Dim icum As Double
        Dim pcum As Double, p1 As Double, Chi2 As Double, stemp As Double
        Dim nnr As Double
        Dim sline As String
        Dim notsame As Boolean, notfound As Boolean, first As Boolean
        Dim show As Boolean, EQ As Boolean, LE As Boolean, sortiert As Boolean


        ReDim x(0 To n + 1, 0 To sum2 + 1)
        ReDim zfak(0 To vlimit)
        ReDim vfak(0 To vlimit)
        ReDim zv(0 To sum2 + 1, 0 To vlimit + 1)
        ReDim v(0 To sum2 + 1, 0 To vlimit + 1)
        ReDim w(0 To sum2 + 1)
        ReDim zz(0 To sum2 + 1)
        ReDim b(0 To sum2 + 1)
        ReDim y(0 To sum2 + 1)
        ReDim z(0 To sum2 + 1)
        ReDim diff(0 To 2 * (sum2 + 1) + 1)

        show = True
        For i = 1 To n
            For j = 1 To sum2
                If Quade = 2 Then x(i, j) = 2 * j * i Else x(i, j) = 2 * j
            Next j
        Next i
        asymend = 0

        If show Then
            Console.WriteLine("Listing des Datensatzes")
            Console.WriteLine("-----------------------")
            For i = 1 To n
                sline = Str(i) + ".Block"
                For j = 1 To sum2
                    sline = sline + Str(x(i, j)) + "  "
                Next j
                Console.WriteLine(sline)
            Next i
        End If

        sdiv2 = sum2 \ 2
        sum3 = sum2 + 1
        If Mode >= 2 Then sumanz = 1 Else sumanz = sum2 - 1
        fit = 1
        h = sumanz
        permanz = 1
        Last = 0
        Varianz = 0
        For k = 1 To sum2
            zv(k, 1) = 0
            y(k) = 0
            permanz = permanz * k
        Next k

        ReDim perm(0 To sum2 + 1, 0 To permanz + 1)
        ReDim pfak(0 To permanz + 1)

        vlength = 1
        rsum = 0
        zfak(1) = 1.0E-300 '   (*permanz;*)
        vfak(1) = 0

        For it = 1 To n
            vneuend = 1
            lastrsum = rsum
            first = True
            notsame = False
            mean = 0
            For k = 1 To sum2
                mean = mean + fit * x(it, k)
            Next k
            mean = mean \ sum2
            For k = 1 To sum2
                yk = fit * x(it, k) - mean
                rsum = rsum + yk
                Varianz = Varianz + (yk * yk)
                If yk <> y(k) Then notsame = True
                y(k) = yk
            Next k

            '(************************************
            ' *  permutations of the ith block  *
            ' ************************************)

            If notsame Then
                permneu = 0
                For j = permanz To 1 Step -1
                    z(1) = 0
                    nr = j
                    pn = permanz
                    For k = 1 To sum2
                        b(k) = k
                    Next k
                    For k = sum2 To 1 Step -1
                        pn = pn \ k
                        s2 = (nr - 1) \ pn
                        nr = nr - pn * s2
                        s2 = s2 + 1
                        If Mode = 1 Then z(k) = y(b(s2))
                        If Mode = 2 Then z(1) = z(1) - (2 * k - sum3) * y(b(s2))
                        For k1 = s2 To (k - 1)
                            b(k1) = b(k1 + 1)
                        Next k1
                    Next k
                    i = 1
                    notfound = True
                    While (notfound And (i <= permneu))
                        k = 1
                        While ((perm(k, i) = z(k)) And (k < sum2))
                            k = k + 1
                        End While
                        If k = sum2 Then notfound = False Else i = i + 1
                    End While
                    If notfound Then
                        permneu = permneu + 1
                        For k = 1 To sum2
                            perm(k, i) = z(k)
                        Next k
                        pfak(i) = 1
                    Else
                        pfak(i) = pfak(i) + 1
                    End If
                Next j
            End If '(*if notsame*)

            '(**************************************
            ' *   Calculate rank sums        *
            ' **************************************)

            k2 = 0
            For i = 1 To vlength
                zfaki1 = zfak(i)
                tsum = 0
                For k = 1 To h
                    k2 = k2 + 1
                    zz(k) = zv(k, i)
                    tsum = tsum + zz(k)
                Next k
                zz(sum2) = lastrsum - tsum

                For j = 1 To permneu
                    zfaki = zfaki1 * pfak(j)
                    If Mode > 1 Then
                        w(1) = zz(1) + perm(1, j)
                    Else
                        For k = 1 To sum2
                            w(k) = zz(k) + perm(k, j)
                        Next k
                        Do
                            sortiert = True
                            For k = 1 To sumanz
                                k1 = k + 1
                                If w(k) > w(k1) Then
                                    w1 = w(k)
                                    w(k) = w(k1)
                                    w(k1) = w1
                                    sortiert = False
                                End If
                            Next k
                        Loop Until sortiert

                        If it >= asymend Then
                            k = 0
                            k1 = sum3
                            Do
                                k = k + 1
                                k1 = k1 - 1
                            Loop Until ((-w(k) <> w(k1)) Or (k = sdiv2))

                            If -w(k) < w(k1) Then
                                For k = 1 To sum2
                                    w(k) = -w(k)
                                Next k
                                k1 = sum2
                                For k = 1 To sdiv2
                                    w1 = w(k)
                                    w(k) = w(k1)
                                    w(k1) = w1
                                    k1 = k1 - 1
                                Next k
                            End If
                        End If
                    End If

                    If first Then
                        first = False
                        For k = 1 To h
                            v(k, 1) = w(k)
                        Next k
                        vfak(1) = zfaki
                    Else
                        l = 1
                        r = vneuend
                        Do
                            m = (l + r + 1) \ 2
                            k = 0
                            Do
                                k = k + 1
                                vref = v(k, m)
                                EQ = (vref = w(k))
                            Loop Until (Not ((k < h) And EQ))
                            LE = (vref <= w(k))
                            If LE Then l = m Else r = m - 1
                        Loop Until l = r

                        k = 1
                        While (v(k, l) = w(k)) And (k <= h)
                            k = k + 1
                        End While
                        If k = h + 1 Then
                            vfak(l) = vfak(l) + zfaki
                        Else
                            vneuend = vneuend + 1
                            l = l + 1
                            If ve > vlimit Then
                                Console.WriteLine("Not enough memory")
                                Return Nothing
                            End If

                            If vneuend <> l Then
                                For i1 = vneuend To l Step -1
                                    i2 = i1 + 1
                                    vfak(i2) = vfak(i1)
                                    For k = 1 To h
                                        v(k, i2) = v(k, i1)
                                    Next k
                                Next i1
                            End If
                            vfak(l) = zfaki
                            For k = 1 To h
                                v(k, l) = w(k)
                            Next k
                        End If
                    End If
                Next j
            Next i

            ve = vneuend
            For i = 0 To ve
                zfak(i) = vfak(i)
                For k = 1 To h
                    zv(k, i) = v(k, i)
                Next k
            Next i
            vlength = vneuend
            Console.WriteLine("vlength: {0}", vlength)
            Last = vneuend
        Next it


        '{    CalcTestDis(mode2,sum2-1,vlength);}

        s = 0
        Erase v
        Erase vfak
        ReDim rv(0 To vlimit + 1)
        ReDim rvfak(0 To vlimit + 1)

        Console.WriteLine("Start Sorting")

        If Mode2 >= 7 Then Return Nothing
        slength = 1
        first = True
        k2 = 0

        Dim Ranks(,) As Integer
        ReDim Ranks(vlength - 1, h)
        For i = 1 To vlength
            zfaki = zfak(i)
            Console.WriteLine("i: {0}, zfaki: {1}", i, zfaki)
            sanz = 1
            tsum = 0
            For k = 1 To h
                k2 = k2 + 1
                w(k) = zv(k, i)
                tsum = tsum + w(k)
                'Console.WriteLine("i: {0}, k: {1}, Index: {2}, Z: {3}, V: {4}", i, k, zv(k, i), zfak(i), vfak(i))
                Ranks(i - 1, k - 1) = zv(k, i) \ 2
                'Console.WriteLine("i: {0}, k: {1}, Index: {2}", i, k, zv(k, i))


            Next k
            w(sum2) = rsum - tsum
            Ranks(i - 1, h) = w(sum2) \ 2
            ' Dim l1 As Integer, l2 As Integer, l3 As Integer
            ' l1 = -1 * w(1) + 2 * w(2) - 1 * w(3)
            ' l2 = 2 * w(1) - 1 * w(2) - 1 * w(3)
            ' l3 = -1 * w(1) - 1 * w(2) + 2 * w(3)
            ' Debug.Print w(1), w(2), w(3), l1, l2, l3, Round(zfaki * 1E+300)
            '
            If Mode2 = 1 Then
                s = 0
                For k = 1 To sum2
                    stemp = w(k)
                    stemp = stemp * stemp
                    s = s + stemp
                Next k
            End If

            If Mode2 = 6 Then
                s = w(1)
                For j = 2 To sum2
                    s = s + j * w(j)
                Next j
            End If

            If Mode2 = 2 Then s = w(sum2) - w(1)


            If ((Mode2 = 3) Or (Mode2 = 4)) Then
                If Mode2 = 3 Then dloop = 2 Else dloop = 1
                k3 = 1
                For j = 1 To dloop
                    For k = 1 To sum2
                        w(k) = -w(k)
                    Next k
                    For k = 1 To sum2
                        dun1 = -30000
                        For k1 = 1 To sum2
                            If k1 <> k Then
                                dun = w(k) - w(k1)
                                If Mode2 = 4 Then dun = Math.Abs(dun)
                                If dun > dun1 Then dun1 = dun
                            End If
                        Next k1
                        diff(k3) = dun1
                        k3 = k3 + 1
                    Next k
                Next j
                sanz = dloop * sum2
            End If

            If Mode2 = 5 Then
                s = -w(1)
                If s < w(sum2) Then s = w(sum2)
            End If

            While sanz > 0
                If (Mode2 = 3) Or (Mode2 = 4) Then s = diff(sanz)
                If first Then
                    first = False
                    rv(1) = s
                    rvfak(1) = zfaki
                Else
                    l = 1
                    r = slength
                    Do
                        m = (l + r + 1) \ 2     ' (* M:=(L+r+1) div 2;*)
                        If rv(m) >= s Then l = m Else r = m - 1
                    Loop Until l = r

                    If rv(l) = s Then
                        rvfak(l) = rvfak(l) + zfaki
                    Else
                        slength = (slength + 1)
                        l = l + 1
                        For i1 = slength To l Step -1
                            i2 = i1 + 1
                            rv(i2) = rv(i1)
                            rvfak(i2) = rvfak(i1)
                        Next i1
                        rvfak(l) = zfaki
                        rv(l) = s
                    End If
                End If
                sanz = sanz - 1
            End While
        Next i

        nnr = 1.0E-300
        icum = 0
        If ((Mode2 = 3) Or (Mode2 = 4)) Then nnr = nnr * sum2 * dloop
        For i = 1 To n
            nnr = nnr * permanz
        Next i
        pcum = 0
        ReDim Output(slength - 1, 3)
        Console.WriteLine("W,            pmf,               CDF,             Approx to CDF")

        For i = 1 To slength
            p1 = rvfak(i) / nnr
            pcum = pcum + p1
            '    If mode2 = 1 Then chi2 = rv(i) / 2 Else chi2 = rv(i) / 2
            If Mode2 = 1 Then Chi2 = rv(i) / Varianz * h Else Chi2 = rv(i) / 2
            '    output(i - 1, 0) = Chi2
            Output(i - 1, 0) = Chi2 / 2
            Output(i - 1, 1) = p1
            Output(i - 1, 2) = pcum
            Output(i - 1, 3) = 1 - cdis(h, Chi2)
            Console.WriteLine("{0}, {1}, {2}, {3}", Output(i - 1, 0), Output(i - 1, 1), Output(i - 1, 2), Output(i - 1, 3))
            '    If show Then
            '      sline = Str(i) + ".  "
            '      Debug.Print sline, Chi2, "  ", pcum
            '    End If
        Next i


        Console.WriteLine("Anzahl der Permutationen: {0}", 1.0E+300 * nnr)
        Erase rv
        Erase rvfak
        Erase zfak
        Erase zv
        Return Output
    End Function



    Private Sub perm2(pprob() As Double, X() As Integer, n As Integer, m As Integer, panz As Integer, success As Boolean)
        Dim ir(0 To 1024) As Integer, ira(0 To 1024) As Integer
        Dim ic(0 To 1024) As Integer, i1 As Integer
        Dim j3 As Integer
        Dim i As Integer, L As Integer, j As Integer, k As Integer
        Dim ici As Integer, il As Integer, ih As Integer, iminm As Integer
        Dim icm As Integer, irl As Integer, l2 As Integer, ib As Integer, jb As Integer
        Dim je As Integer, icj As Integer
        Dim pcum As Double, ai As Double, msum As Double, asum As Double
        Dim qmin As Integer, qmax As Integer
        Dim ASize As Integer
        'Dim a() As Double
        success = False
        If m > n / 2 Then m = n - m
        For i = 1 To n
            ir(i) = X(i)
        Next i
        ic(1) = 1
        ih = 1
        iminm = 0
        For i = 1 To m
            ic(i + 1) = ic(i) + ih
            iminm = iminm + ir(i)
            ih = ih + ir(n - i + 1) - ir(i)
        Next i
        icm = ic(m + 1) + ih
        ASize = icm + 10
        Dim a(ASize) As Double

        For i = 1 To icm
            a(i) = 0
        Next i
        a(1) = 1
        ira(1) = 0
        For L = 2 To n
            irl = ir(L)
            l2 = L \ 2
            ib = m + 1 - l2
            If ib < 1 Then
                ib = 1
            Else
                If 2 * l2 = L Then
                    jb = ic(l2)
                    je = jb + ira(l2)
                    icj = ic(l2 + 1) + je
                    For j = jb To je
                        a(icj - j) = a(j)
                    Next j
                End If
            End If
            For k = ib To m
                il = m + 1 - k
                jb = ic(il + 1) + irl - ir(il)
                je = jb + ira(il)
                ici = ic(il) - jb
                For j = jb To je
                    a(j) = a(j) + a(ici + j)
                Next j
                ira(il + 1) = ira(il) + irl - ir(il)
            Next k
        Next L

        asum = 1
        msum = 1
        For i = 1 To n
            asum = asum * i
        Next i
        For i = 1 To m
            msum = msum * i
        Next i
        For i = 1 To n - m
            msum = msum * i
        Next i
        asum = asum / msum
        qmin = iminm
        qmax = iminm + icm - ic(m + 1) - 1
        For i = ic(m + 1) To icm
            j3 = i - ic(m + 1) + 1
            a(j3) = a(i) / asum
        Next i
        pcum = 0
        panz = qmax - qmin
        ReDim pprob(panz)
        For i = 1 To qmax - qmin + 1
            i1 = i - 1
            ai = a(i)
            pprob(i1) = ai
            pcum = pcum + ai
        Next i
        Erase a
        success = True
    End Sub



    Function TerpstaCalc(k As Integer, n As Integer()) As Double()

        Dim panz As Integer, pprob() As Double
        Dim X() As Integer
        Dim pneu() As Double, qprob() As Double
        Dim TS As Integer, j As Integer, i4 As Integer, i2 As Integer
        Dim qanz As Integer, i As Integer, t As Integer, success As Boolean
        'Dim pmax As Double, pprobi As Double, p As Double, qmin As Integer, qmax As Integer
        'Dim pcum As Double, smin As Double, maxmoment As Integer, mi As Integer
        Dim m(k + 1) As Integer
        m(0) = 0
        For j = 1 To k : m(j) = m(j - 1) + n(j) : Next j
        TS = 0
        For j = 1 To k - 1 : TS = TS + m(j) * n(j + 1) : Next j
        ReDim pneu(TS + 2)
        '  ReDim pprob(TS + 2)
        '  ReDim qprob(TS + 2)
        ReDim X(m(k) + 2)
        For i = 1 To m(k) : X(i) = i : Next i
        '{Multiply}
        t = 0
        Call perm2(pprob, X, m(2), m(1), panz, success)
        '  If Not (success) Then Exit Function
        For j = 3 To k
            Call perm2(qprob, X, m(j), m(j - 1), qanz, success)
            '    If Not (success) Then Exit Function
            For i = 0 To qanz + panz
                pneu(i) = 0
            Next i
            For i = 0 To qanz
                For i2 = 0 To panz
                    i4 = i + i2
                    pneu(i4) = pneu(i4) + pprob(i2) * qprob(i)
                Next i2
            Next i
            panz = panz + qanz
            If j = 3 Then ReDim pprob(TS + 2)
            For i = 0 To panz : pprob(i) = pneu(i) : Next i
        Next j
        Erase X : Erase qprob : Erase pneu : Erase m
        ReDim Preserve pprob(panz)
        success = True
        TerpstaCalc = pprob
    End Function



    Function KendallCalc(n As Integer) As Double()
        Dim nl As Integer ', y() As Double , X() As Double
        Dim nmax As Integer, it As Integer
        Dim mitte As Integer, limit As Integer, j As Integer, i As Integer
        Dim yy As Double
        Dim permanz As Double ', SD As Double, p As Double
        nmax = n * (n - 1) + 1
        Dim X(nmax + 2) As Double
        Dim y(nmax + 2) As Double
        '  SD = Math.Sqrt(2 * (2 * n + 5) / (9 * n * (n - 1)))
        permanz = 1
        X(1) = permanz
        nl = 1
        For it = 2 To n
            permanz = permanz * it
            nl = nl + it - 1
            '    p = 0
            mitte = (nl + 1) \ 2
            For i = 1 To nl
                y(i) = 0
            Next i
            For i = mitte To 1 Step -1
                limit = i - it + 1
                If limit < 1 Then limit = 1
                yy = y(i)
                For j = i To limit Step -1
                    yy = yy + X(j)
                Next j
                y(i) = yy
            Next i
            j = nl + 1
            For i = 1 To mitte
                j = j - 1
                yy = y(i)
                X(i) = yy
                X(j) = yy
            Next i
        Next it
        permanz = 1 : For i = 2 To n : permanz = permanz * i : Next i
        For i = 1 To nl : X(i - 1) = X(i) / permanz : Next i : nl = nl - 1
        ReDim Preserve X(nl)
        Erase y
        KendallCalc = X
    End Function



    Sub PageQuadeCalc(UseRanks As Boolean, k As Integer, n As Integer, Order As Integer, Q As Double())
        Dim h As Integer, pl As Integer, j As Integer, i As Integer, F As Integer, ql As Integer
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
    End Sub



    Sub PageCalc(k As Integer, N As Integer, nl As Integer, x() As Double)
        PageQuadeCalc(False, k, N, 0, x)
    End Sub

    Sub PageQCalc(k As Integer, N As Integer, nl As Integer, x() As Double)
        PageQuadeCalc(True, k, N, 0, x)
    End Sub

    Sub WilcoxonCalc(N As Integer, nl As Integer, x() As Double)
        PageQuadeCalc(True, 2, N, 0, x)
    End Sub

    Sub SignCalc(N As Integer, nl As Integer, x() As Double)
        PageQuadeCalc(False, 2, N, 0, x)
    End Sub






End Module
