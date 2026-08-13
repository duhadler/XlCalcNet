

Module PermMilton


    Const sqrt2pi = 0.398942280401433
    Const MaxGroup = 6
    Const rFieldsize = 1601
    'type rfeldMilton=array(0..rFieldsize) of extended
    '     rfeldpointer=^rfeldMilton
    '     type ifeldMilton=array(0..100) of integer
    Dim s() As Double
    Dim f2(,,) As Double
    Dim v(,,) As Double
    Dim HH(0 To 10) As Double, t2(0 To 10) As Double
    Dim a(0 To 10, 0 To 10) As Double
    Dim delta(0 To MaxGroup) As Double
    Dim Factor As Double, sum As Double, h As Double
    Dim icount As Integer, Index As Integer, left As Integer, Right As Integer
    Dim plimit As Integer, vp As Integer, p As Integer
    Dim IsNormal As Boolean, IsWilcoxon As Boolean
    Dim GlobalP1 As Double


    Sub DemoMilton()
        'Milton_Wilcoxon_Demo()
        MiltonDemo()
        'CalcNormalRO()
        'DemoCalcLehmannRO()
        'LehmanndemoNew()
        'LehmannDemoRecursive()
        'DemoSampleEstRO()
        'DemoUniformEstRO()
    End Sub

    'Log von n über k
    Function LnBin(n As Double, k As Double) As Double
        LnBin = LnGamma(n + 1) - LnGamma(k + 1) - LnGamma(n - k + 1)
    End Function

    'density of the binomial distribution
    'k: number of successes
    'n: sample size
    'p: prob of success
    Function BinDens(k As Double, n As Double, p As Double) As Double
        If (k < 0) Or (k > n) Or (n < 1) Then BinDens = 0 _
    Else BinDens = Math.Exp(LnBin(n, k) + Math.Log(p) * k + Math.Log(1 - p) * (n - k))
    End Function



    Function Myfunction(x As Double, j As Integer) As Double
        Dim b As Double, z As Double, LeftTail As Double, Righttail As Double, density As Double, k As Double
        Dim x1 As Double, d As Double, Lp1 As Double
        If IsWilcoxon Then
            d = delta(1)
            x = x + 8.0# + 0.00301
            Lp1 = 1
            '   If j = 1 Then Lp1 = 1 * GlobalP1 Else Lp1 = 1 * (1 - GlobalP1)
            If (j = 1) Then x1 = x - d
            If (j = 2) Then x1 = Math.Abs(-x - d)
            '    Console.WriteLine( "x1:", x1
            Myfunction = (Math.Exp(-(x1 ^ 2) / 2) * sqrt2pi) / Lp1
            Exit Function
        End If

        'If IsWilcoxon Then
        '    d = delta(1)
        '    'x = x + 8.0025
        '    X = X + 8#
        '    X = X / 2
        ''    Lp1 = 1
        '   If j = 1 Then Lp1 = 1 * GlobalP1 Else Lp1 = 1 * (1 - GlobalP1)
        '   Lp1 = Lp1 * 2
        '    If (j = 1) And (X >= 0) Then x1 = X - d
        ' '   If (j = 1) And (x < 0) Then x1 = x - d
        '    If (j = 2) And (X >= 0) Then x1 = -X - d
        ' '   If (j = 2) And (x < 0) Then x1 = -x - d
        '
        '        If X < 0 Then Myfunction = 0 Else Myfunction = (Exp(-(x1 ^ 2) / 2) * sqrt2pi) / Lp1
        ' 'Myfunction = (Exp(-(x1 ^ 2) / 2) * sqrt2pi) / Lp1
        '    Exit Function
        'End If


        If IsNormal Then
            Myfunction = Math.Exp(-((x - delta(j)) ^ 2) / 2) * sqrt2pi
        Else
            Call ndis2(False, x, LeftTail, Righttail, density)
            k = delta(j)
            Myfunction = density * k * (LeftTail ^ (k - 1))
            '  Myfunction = density * (k * (RightTail ^ (k - 1)))

            ' IsLogistic
            '  b = 1
            '  b = 0.25
            '  z = Exp(-(x - delta(j)) / b)
            '  Myfunction = z / (b * (1 + z) * (1 + z))
        End If
    End Function

    Sub demo()
        Dim x As Double, Result As Double
        IsNormal = True
        For x = -8 To 8
            delta(1) = 0.08
            Result = Myfunction(x, 1)
            Console.WriteLine("x: {0}, Result: {1}", x, Result)
        Next x
    End Sub

    Sub InitMilton(GroupAnz As Integer, ByRef n() As Integer)
        Dim k As Integer, i As Integer, j As Integer, iteration As Integer
        Factor = 1
        p = 0
        For j = 1 To GroupAnz
            For i = 1 To n(j)
                Factor = Factor * i
            Next i
            p = p + n(j)
        Next j
        plimit = 20
        icount = 8
        left = 0
        vp = p
        If p > plimit Then vp = plimit
        ReDim s(0 To rFieldsize)
        ReDim f2(0 To icount + 1, 0 To GroupAnz - 1, 0 To rFieldsize)
        ReDim v(0 To p + 1, 0 To vp + 1, 0 To rFieldsize)

        t2(0) = 4
        For k = 1 To icount - 2
            t2(k) = t2(k - 1) * 4
        Next k
        Right = 1600 * 2
        h = 0.01 / 2
        For iteration = 1 To icount
            Right = Right \ 2
            h = h * 2
            HH(iteration) = 1
            For i = 1 To p
                HH(iteration) = HH(iteration) * h
            Next i
            For k = left To Right
                For j = 0 To GroupAnz - 1
                    If IsNormal Then
                        f2(iteration, j, k) = Myfunction(k * h - 8, j + 1)
                    Else
                        f2(iteration, j, k) = Myfunction((k * h - 8) * 1.0#, j + 1)
                    End If
                Next j
            Next k
        Next iteration
    End Sub ' {InitMilton}

    Function RunMilton(z() As Integer) As Double
        Dim i As Integer, k As Integer, j As Integer, iteration As Integer
        Right = 1600 * 2
        h = 0.01 / 2
        For iteration = 1 To icount
            Right = Right \ 2
            h = h * 2
            Index = z(1)
            s(left) = 0
            For k = left To Right
                v(1, 1, k) = f2(iteration, Index, k)
                s(k + 1) = s(k) + v(1, 1, k)
            Next k

            For j = 2 To p
                Index = z(j)
                vp = j - 1
                If vp > plimit Then vp = plimit
                For i = 1 To vp
                    For k = left To Right
                        v(j, i, k) = v(j - 1, i, k) * f2(iteration, Index, k) / (j + 1 - i)
                    Next k
                Next i
                If j <= plimit Then
                    For k = left To Right
                        v(j, j, k) = s(k) * f2(iteration, Index, k)
                    Next k
                End If
                s(0) = 0
                For k = left To Right
                    sum = 0
                    vp = j
                    If vp > plimit Then vp = plimit
                    For i = 1 To vp
                        sum = sum + v(j, i, k)
                    Next i
                    s(k + 1) = s(k) + sum
                Next k
            Next j
            a(icount - iteration, 0) = Factor * HH(iteration) * s(Right + 1)
        Next iteration

        For k = 0 To icount - 2
            For i = (k + 1) To icount - 1
                a(i, k + 1) = (t2(k) * a(i, k) - a(i - 1, k)) / (t2(k) - 1)
            Next i
        Next k
        RunMilton = a(icount - 1, icount - 1)
    End Function ' RunMilton

    Sub DoneMilton()
        Erase v
        Erase f2
        Erase s
    End Sub 'DoneMilton

    Sub Chase2(ByRef x As Integer, ByRef y As Integer, k As Integer, u As Integer, ByRef done As Boolean, ByRef p() As Integer)
        Dim s As Integer, i As Integer, j As Integer, b As Integer
        j = 0
        b = 0
        s = 0
l1:     j = j + 1
        If Math.Abs(p(j)) = k Then
            If p(j) < 0 Then s = j
            GoTo l1
        End If
        If p(j - 1) = k Then
            For i = j - s - 1 To 2 Step -1
                p(s + i) = -k
            Next i
            If s > b Then p(s) = k
            p(s + 1) = p(j)
            p(j) = k
            x = s + 1
            y = j
            Exit Sub
        End If
        If s > b Then p(s) = k
l2:     j = j + 1
        If Math.Abs(p(j)) < k Then GoTo l2
        If j = u Then
            If k = 2 Then
                done = True
                Exit Sub
            End If
            j = s
            b = s
            k = k - 1
            GoTo l1
        End If
        b = j - 1
        i = b
l3:     i = i + 1
        If p(i) = k Then
            p(i) = -k
            GoTo l3
        End If
        If p(i) = -k Then
            p(i) = p(b)
            p(b) = -k
            x = b
            y = i
            Exit Sub
        End If
        If i = u Then
            If k = 2 Then
                done = True
                Exit Sub
            End If
            u = j
            j = s
            b = s
            k = k - 1
            GoTo l1
        End If
        x = j
        y = i
        p(j) = p(i)
        p(i) = k
    End Sub 'Chase

    Sub demoP1toP2()
        Dim p1 As Double, p2 As Double, pxy As Double, d As Double
        Dim p1_2 As Double, p2_2 As Double, pxy_2 As Double
        d = 1
        p1 = ndis(d)
        p2 = ndis(d * Math.Sqrt(2))
        pxy = (ndis(d * Math.Sqrt(2)) - ndis(d)) / (ndis(d) * ndis(-d))
        p1_2 = (1 / (2 * pxy) * (pxy + 1 - Math.Sqrt((pxy + 1) ^ 2 - 4 * pxy * p2)))
        p2_2 = (p1 - p1 * p1) * pxy + p1
        pxy_2 = (p2 - p1) / (p1 - p1 * p1)
        Console.WriteLine("p1: {0}, p2: {1}, pxy: {2}", p1, p2, pxy)
        Console.WriteLine("p1_2: {0}, p2_2: {1}, pxy_2: {2}", p1_2, p2_2, pxy_2)
    End Sub



    Sub Milton_Wilcoxon_Demo()
        Dim a(0 To 100) As Integer
        Dim n(0 To 100 + 1) As Integer
        Dim p(0 To 100) As Integer, id(0 To 100) As Integer, Ranks(100) As Integer
        Dim GroupAnz As Integer
        Dim x As Integer, y As Integer, temp As Integer, k As Integer
        Dim u As Integer, i1 As Integer, i2 As Integer, csum As Integer
        Dim count As Integer
        Dim done As Boolean
        Dim icount2 As Integer
        Dim ss As String, s3 As String
        Dim Result As Double
        Dim pcum(0 To 100) As Double, ptotal(0 To 100) As Double
        Dim Rmin As Integer, Rmax As Integer, m As Integer, NTotal As Integer, RTotalMax As Integer
        Dim p1 As Double, Pr As Double, p2 As Double
        Dim ptotalsum As Double
        Rmin = 32000 : Rmax = 0 : RTotalMax = 0
        Dim CdfSum As Double

        For i1 = 0 To 100
            pcum(i1) = 0
            ptotal(i1) = 0
        Next i1
        NTotal = 6
        For m = 0 To NTotal
            IsNormal = True
            IsWilcoxon = True
            GroupAnz = 2 '(*zahl der gruppen mit verschiedenen werten*)
            n(1) = m '(*gruppenstaerken*)
            n(2) = NTotal - m
            n(3) = 2
            n(4) = 1
            n(5) = 1
            n(6) = 1
            delta(1) = 1.12
            delta(2) = 0
            delta(3) = 0
            delta(4) = 2.5
            delta(5) = 2.5
            delta(6) = 2.5
            GlobalP1 = ndis(delta(1))
            For i1 = 1 To GroupAnz
                id(i1) = i1 - 1 ' (*werte der gruppen*)

            Next i1
            Call InitMilton(GroupAnz, n)

            csum = 0
            count = 0
            For i1 = 1 To GroupAnz
                csum = csum + n(i1)
                For i2 = 1 To n(i1)
                    count = count + 1
                    a(count) = id(i1)
                    p(count) = GroupAnz - i1 + 1
                Next i2
            Next i1

            icount2 = 1
            x = 1
            y = 2
            k = GroupAnz
            u = csum + 1
            done = False
            p(0) = GroupAnz + 1
            p(u) = GroupAnz + 1

            While Not (done)
                ss = Format(icount2, "#00") + ": "
                For i1 = 0 To GroupAnz : Ranks(i1) = 0 : Next i1
                For i1 = 1 To csum
                    ss = ss + Str(a(i1))
                    Ranks(a(i1)) = Ranks(a(i1)) + i1
                Next i1
                If Ranks(0) < Rmin Then Rmin = Ranks(0)
                If Ranks(0) > Rmax Then Rmax = Ranks(0)
                If Ranks(0) > RTotalMax Then RTotalMax = Ranks(0)
                s3 = "["
                For i1 = 1 To GroupAnz
                    s3 = s3 + Str(Ranks(i1 - 1)) + ","
                Next i1
                s3 = s3 + "]"
                Result = RunMilton(a)
                Console.WriteLine("Ranks(0): {0}, ss: {1}, s3: {2}, Result: {3}", Ranks(0), ss, s3, Result)
                pcum(Ranks(0)) = pcum(Ranks(0)) + Result
                'Console.WriteLine( ss, "        ", Format(result, "Scientific")
                If m = NTotal Then done = True
                Call Chase2(x, y, k, u, done, p)
                temp = a(x)
                a(x) = a(y)
                a(y) = temp
                icount2 = icount2 + 1
            End While

            p1 = GlobalP1
            Pr = BinDens(n(1), n(1) + n(2), p1)
            Console.WriteLine("Pr:: {0}", Pr)

            ptotalsum = 0
            For i1 = Rmin To Rmax
                ptotalsum = ptotalsum + pcum(i1)
            Next i1
            Console.WriteLine("local ptotalsum:: {0}", ptotalsum)
            For i1 = Rmin To Rmax
                ptotal(i1) = ptotal(i1) + pcum(i1) * Pr / ptotalsum
                Console.WriteLine("i1: {0}, pcum(i1): {1}, pcum(i1) / ptotalsum: {2}", i1, pcum(i1), pcum(i1) / ptotalsum)
            Next i1
            Rmin = 32000 : Rmax = 0
            For i1 = 0 To 100
                pcum(i1) = 0
            Next i1

        Next m
        Console.WriteLine("Total distribution")
        ptotalsum = 0
        For i1 = 0 To RTotalMax
            ptotalsum = ptotalsum + ptotal(i1)
        Next i1

        Dim mu1 As Double, mu2 As Double
        CdfSum = 0 : mu1 = 0 : mu2 = 0
        Console.WriteLine("ptotalsum:: {0}", ptotalsum)
        For i1 = 0 To RTotalMax
            CdfSum = CdfSum + (ptotal(i1) / ptotalsum)
            mu1 = mu1 + i1 * (ptotal(i1) / ptotalsum)
            Console.WriteLine("i1: {0}, CdfSum: {1}, 1 - CdfSum: {2}", i1, CdfSum, 1 - CdfSum)
            '  Console.WriteLine( i1, Format((ptotal(i1) / ptotalsum), "0.00000000000E+000"), Format(ptotal(i1), "0.00000000000E+000")
        Next i1
        Console.WriteLine("mu1: {0}", mu1)
        p1 = ndis(delta(1))
        p2 = ndis(delta(1) * Math.Sqrt(2))
        mu1 = NTotal * p1 + NTotal * (NTotal - 1) * p2 / 2
        Console.WriteLine("mu1: {0}", mu1)
        DoneMilton()
    End Sub



    Sub MiltonDemo()
        Dim a(0 To 100) As Integer
        Dim n(0 To 100 + 1) As Integer
        Dim p(0 To 100) As Integer, id(0 To 100) As Integer, Ranks(100) As Integer
        Dim GroupAnz As Integer
        Dim x As Integer, y As Integer, temp As Integer, k As Integer
        Dim u As Integer, i1 As Integer, i2 As Integer, csum As Integer
        Dim count As Integer
        Dim done As Boolean
        Dim icount2 As Integer
        Dim ss As String, s3 As String
        Dim Result As Double
        IsNormal = True
        IsWilcoxon = False
        GroupAnz = 2 '(*zahl der gruppen mit verschiedenen werten*)
        n(1) = 3 '(*gruppenstaerken*)
        n(2) = 3
        n(3) = 3
        'n(1) = 5 '(*gruppenstaerken*)
        'n(2) = 5
        'n(3) = 1
        'n(4) = 1
        'n(5) = 1
        'n(6) = 1

        delta(1) = 0
        delta(2) = 1
        delta(3) = 2


        'delta(1) = 1
        'delta(2) = 2
        'delta(3) = 3


        'delta(4) = 4.5
        'delta(5) = 2.5
        'delta(6) = 2.5
        For i1 = 1 To GroupAnz
            id(i1) = i1 - 1 ' (*werte der gruppen*)

        Next i1
        Call InitMilton(GroupAnz, n)

        csum = 0
        count = 0
        For i1 = 1 To GroupAnz
            csum = csum + n(i1)
            For i2 = 1 To n(i1)
                count = count + 1
                a(count) = id(i1)
                p(count) = GroupAnz - i1 + 1
            Next i2
        Next i1

        icount2 = 1
        x = 1
        y = 2
        k = GroupAnz
        u = csum + 1
        done = False
        p(0) = GroupAnz + 1
        p(u) = GroupAnz + 1
        Dim totalSum As Double = 0.0
        While Not (done)
            ss = Format(icount2, "#00") + ": "
            For i1 = 0 To GroupAnz : Ranks(i1) = 0 : Next i1
            For i1 = 1 To csum
                ss = ss + Str(a(i1))
                Ranks(a(i1)) = Ranks(a(i1)) + i1
            Next i1
            s3 = "["
            For i1 = 1 To GroupAnz
                s3 = s3 + Str(Ranks(i1 - 1)) + ","
            Next i1
            s3 = s3 + "]"
            Result = RunMilton(a)
            Console.WriteLine("ss: {0}, s3: {1}, Result: {2}", ss, s3, Result)
            totalSum = totalSum + Result
            'Console.WriteLine( ss, "        ", Format(result, "Scientific")
            Call Chase2(x, y, k, u, done, p)
            temp = a(x)
            a(x) = a(y)
            a(y) = temp
            icount2 = icount2 + 1
        End While
        Console.WriteLine("totalSum: {0}", totalSum)
        delta(1) = 1
        delta(2) = 2
        delta(3) = 3

        DoneMilton()
    End Sub




    Sub ChaseNewOld(ByRef x As Integer, ByRef y As Integer, k As Integer, u As Integer, ByRef done As Boolean, ByRef p() As Integer)
        Dim s As Integer, i As Integer, j As Integer, b As Integer
        j = 0
        b = 0
        s = 0
l1:

        j = j + 1
        If Math.Abs(p(j)) = k Then
            If p(j) < 0 Then s = j
            GoTo l1
        End If
        If p(j - 1) = k Then
            For i = j - s - 1 To 2 Step -1
                p(s + i) = -k
            Next i
            If s > b Then p(s) = k
            p(s + 1) = p(j) : p(j) = k : x = s + 1 : y = j
            Exit Sub
        End If
        If s > b Then p(s) = k
        While True
            j = j + 1
            If Math.Abs(p(j)) >= k Then Exit While
        End While
        If j = u Then
            If k = 2 Then
                done = True
                Exit Sub
            End If
            j = s : b = s : k = k - 1
            GoTo l1
        End If
        b = j - 1
        i = b
        While True
            i = i + 1
            If p(i) <> k Then Exit While
            p(i) = -k
        End While
        If p(i) = -k Then
            p(i) = p(b) : p(b) = -k : x = b : y = i
            Exit Sub
        End If
        If i = u Then
            If k = 2 Then
                done = True
                Exit Sub
            End If
            u = j : j = s : b = s : k = k - 1
            GoTo l1
        End If
        x = j
        y = i
        p(j) = p(i)
        p(i) = k
    End Sub 'Chase


    Sub ChaseNew(ByRef x As Integer, ByRef y As Integer, k As Integer, u As Integer, ByRef done As Boolean, ByRef p() As Integer)
        Dim s As Integer, i As Integer, j As Integer, b As Integer
        j = 0 : b = 0 : s = 0
        While True
            j = j + 1
            If Math.Abs(p(j)) = k Then
                If p(j) < 0 Then s = j
            Else
                If p(j - 1) = k Then
                    For i = j - s - 1 To 2 Step -1
                        p(s + i) = -k
                    Next i
                    If s > b Then p(s) = k
                    p(s + 1) = p(j) : p(j) = k : x = s + 1 : y = j
                    Exit Sub
                End If
                If s > b Then p(s) = k
                While True
                    j = j + 1
                    If Math.Abs(p(j)) >= k Then Exit While
                End While
                If j = u Then
                    If k = 2 Then
                        done = True
                        Exit Sub
                    End If
                    j = s : b = s : k = k - 1
                Else
                    b = j - 1
                    i = b
                    While True
                        i = i + 1
                        If p(i) <> k Then Exit While
                        p(i) = -k
                    End While
                    If p(i) = -k Then
                        p(i) = p(b) : p(b) = -k : x = b : y = i
                        Exit Sub
                    End If
                    If i = u Then
                        If k = 2 Then
                            done = True
                            Exit Sub
                        End If
                        u = j : j = s : b = s : k = k - 1
                    Else
                        Exit While
                    End If
                End If
            End If
        End While
        x = j : y = i : p(j) = p(i) : p(i) = k
    End Sub 'Chase


    Sub DemoChaseNew()
        Dim a(0 To 100) As Integer
        Dim n(0 To 100 + 1) As Integer
        Dim p(0 To 100) As Integer, id(0 To 100) As Integer, Ranks(100) As Integer
        Dim GroupAnz As Integer
        Dim x As Integer, y As Integer, temp As Integer, k As Integer
        Dim u As Integer, i1 As Integer, i2 As Integer, csum As Integer
        Dim count As Integer
        Dim done As Boolean
        Dim icount2 As Integer
        Dim ss As String, s3 As String
        Dim Result As Double
        IsNormal = True
        IsWilcoxon = False
        GroupAnz = 3 '(*zahl der gruppen mit verschiedenen werten*)
        n(1) = 1 '(*gruppenstaerken*)
        n(2) = 2
        n(3) = 3
        'n(1) = 5 '(*gruppenstaerken*)
        'n(2) = 5
        'n(3) = 1
        'n(4) = 1
        'n(5) = 1
        'n(6) = 1

        delta(1) = 0
        delta(2) = 0
        delta(3) = 0


        'delta(1) = 1
        'delta(2) = 2
        'delta(3) = 3


        'delta(4) = 4.5
        'delta(5) = 2.5
        'delta(6) = 2.5
        For i1 = 1 To GroupAnz
            id(i1) = i1 - 1 ' (*werte der gruppen*)

        Next i1
        Call InitMilton(GroupAnz, n)

        csum = 0
        count = 0
        For i1 = 1 To GroupAnz
            csum = csum + n(i1)
            For i2 = 1 To n(i1)
                count = count + 1
                a(count) = id(i1)
                p(count) = GroupAnz - i1 + 1
            Next i2
        Next i1

        icount2 = 1
        x = 1
        y = 2
        k = GroupAnz
        u = csum + 1
        done = False
        p(0) = GroupAnz + 1
        p(u) = GroupAnz + 1
        Dim totalSum As Double = 0.0
        While Not (done)
            ss = Format(icount2, "#00") + ": "
            For i1 = 0 To GroupAnz : Ranks(i1) = 0 : Next i1
            For i1 = 1 To csum
                ss = ss + Str(a(i1))
                Ranks(a(i1)) = Ranks(a(i1)) + i1
            Next i1
            s3 = "["
            For i1 = 1 To GroupAnz
                s3 = s3 + Str(Ranks(i1 - 1)) + ","
            Next i1
            s3 = s3 + "]"
            Result = RunMilton(a)
            Console.WriteLine("ss: {0}, s3: {1}, Result: {2}", ss, s3, Result)
            totalSum = totalSum + Result
            'Console.WriteLine( ss, "        ", Format(result, "Scientific")
            Call ChaseNew(x, y, k, u, done, p)
            temp = a(x)
            a(x) = a(y)
            a(y) = temp
            icount2 = icount2 + 1
        End While
        Console.WriteLine("totalSum: {0}", totalSum)
        delta(1) = 1
        delta(2) = 2
        delta(3) = 3

        DoneMilton()
    End Sub



    Function logistic(x As Double, a As Double, b As Double) As Double
        logistic = 1 / (1 + Math.Exp(-(x - a) / b))
    End Function


    Sub cn(Usenormal As Boolean, TargetU As Double, ParName As String, ParValue As Double, p As Double, q As Double, s As Double, u As Double, v As Double,
       aa As Double, w As Double, y As Double)
        Dim a(0 To 100) As Integer, n(0 To 100 + 1) As Integer
        Dim GroupAnz As Integer, ss As String, Result As Double
        Dim mu As Double
        IsNormal = Usenormal
        IsWilcoxon = False
        If IsNormal Then
            mu = Math.Sqrt(2) * ndisx(TargetU, 1 - TargetU)
            Console.WriteLine("Normal Distribution, mu = {0}", mu)
        Else
            mu = 0.25 * 1.5 * Math.Log(TargetU / (1 - TargetU))
            Console.WriteLine("Logistic Distribution, mu = {0}", mu)

        End If


        ParName = "mu"
        ParValue = mu
        '  mu = 0.9 * Sqr(2)
        GroupAnz = 2
        delta(1) = 0
        delta(2) = mu
        '  Console.WriteLine( "mu: ", delta(2)
        n(1) = 1 : n(2) = 1 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 1
        ss = "0, 1 :"
        Result = RunMilton(a)
        p = Result
        Console.WriteLine("ss: {0}, p: {1}", ss, p)
        DoneMilton()
        '  mu = Sqr(2) * ndisx(p, 1 - p)
        'Console.WriteLine( "mu: ", mu
        'Console.WriteLine( "ndis: ", ndis(delta(2) / Sqr(2))
        'Console.WriteLine( "ndis: ", ndis(mu / Sqr(2))
        n(1) = 2 : n(2) = 1 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 1
        ss = "0, 0, 1 :"
        Result = RunMilton(a)
        q = Result
        Console.WriteLine("ss: {0}, q: {1}", ss, q)
        DoneMilton()

        n(1) = 3 : n(2) = 1 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 1
        ss = "0, 0, 0, 1 :"
        Result = RunMilton(a)
        s = Result
        Console.WriteLine("ss: {0}, s: {1}", ss, s)
        DoneMilton()

        n(1) = 4 : n(2) = 1 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 0 : a(5) = 1
        ss = "0, 0, 0, 0, 1 :"
        Result = RunMilton(a)
        aa = Result
        Console.WriteLine("ss: {0}, aa: {1}", ss, aa)
        DoneMilton()

        n(1) = 2 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 1
        ss = "0, 0, 1, 1 :"
        Result = RunMilton(a)
        v = Result
        Console.WriteLine("ss: {0}, v: {1}", ss, v)
        DoneMilton()

        n(1) = 2 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 1
        ss = "0, 1, 0, 1 :"
        Result = RunMilton(a)
        u = v + (1 / 4) * Result
        Console.WriteLine("ss: {0}, u: {1}", ss, u)
        DoneMilton()

        n(1) = 3 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 1 : a(5) = 1
        ss = "0, 0, 0, 1, 1 :"
        Result = RunMilton(a)
        w = Result
        Console.WriteLine("ss: {0}, w1: {1}", ss, w)
        DoneMilton()

        n(1) = 3 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 0 : a(5) = 1
        ss = "0, 0, 1, 0, 1 :"
        Result = RunMilton(a)
        w = w + (1 / 3) * Result
        Console.WriteLine("ss: {0}, w: {1}", ss, w)
        DoneMilton()

        n(1) = 3 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 0 : a(5) = 1
        ss = "0, 1, 0, 0, 1 :"
        Result = RunMilton(a)
        y = w + (1 / 6) * Result
        Console.WriteLine("ss: {0}, y: {1}", ss, y)
        DoneMilton()

    End Sub




    Sub CalcNormalRO()
        Dim a(0 To 100) As Integer, n(0 To 100 + 1) As Integer
        Dim GroupAnz As Integer, ss As String, Result As Double
        Dim p As Double, q As Double, r As Double, s As Double, t As Double, u As Double, v As Double
        Dim aa As Double, b As Double, w As Double, x As Double, y As Double, z As Double
        IsNormal = True
        IsWilcoxon = False
        GroupAnz = 2
        delta(1) = 0
        delta(2) = 0.5 * Math.Sqrt(2)
        If IsNormal Then
            Console.WriteLine("Normal Distribution, D = {0}", delta(2))
        Else
            Console.WriteLine("Logistic Distribution, D = {0}", delta(2))
        End If
        n(1) = 1 : n(2) = 1 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 1
        ss = "0, 1 :"
        Result = RunMilton(a)
        p = Result
        Console.WriteLine("ss: {0}, p: {1}", ss, p)
        DoneMilton()

        n(1) = 2 : n(2) = 1 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 1
        ss = "0, 0, 1 :"
        Result = RunMilton(a)
        q = Result
        Console.WriteLine("ss: {0}, q: {1}", ss, q)
        DoneMilton()

        n(1) = 3 : n(2) = 1 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 1
        ss = "0, 0, 0, 1 :"
        Result = RunMilton(a)
        s = Result
        Console.WriteLine("ss: {0}, s: {1}", ss, s)
        DoneMilton()

        n(1) = 4 : n(2) = 1 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 0 : a(5) = 1
        ss = "0, 0, 0, 0, 1 :"
        Result = RunMilton(a)
        aa = Result
        Console.WriteLine("ss: {0}, a: {1}", ss, a)
        DoneMilton()

        n(1) = 2 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 1
        ss = "0, 0, 1, 1 :"
        Result = RunMilton(a)
        v = Result
        Console.WriteLine("ss: {0}, v: {1}", ss, v)
        DoneMilton()

        n(1) = 2 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 1
        ss = "0, 1, 0, 1 :"
        Result = RunMilton(a)
        u = v + (1 / 4) * Result
        Console.WriteLine("ss: {0}, u: {1}", ss, u)
        DoneMilton()

        n(1) = 3 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 1 : a(5) = 1
        ss = "0, 0, 0, 1, 1 :"
        Result = RunMilton(a)
        w = Result
        Console.WriteLine("ss: {0}, w1: {1}", ss, w)
        DoneMilton()

        n(1) = 3 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 0 : a(5) = 1
        ss = "0, 0, 1, 0, 1 :"
        Result = RunMilton(a)
        w = w + (1 / 3) * Result
        Console.WriteLine("ss: {0}, w: {1}", ss, w)
        DoneMilton()

        n(1) = 3 : n(2) = 2 : Call InitMilton(GroupAnz, n)
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 0 : a(5) = 1
        ss = "0, 1, 0, 0, 1 :"
        Result = RunMilton(a)
        y = w + (1 / 6) * Result
        Console.WriteLine("ss: {0}, y: {1}", ss, y)
        DoneMilton()
    End Sub



    Sub cU(TargetU As Double, ParName As String, ParValue As Double, p As Double, q As Double, s As Double, u As Double, v As Double,
       a As Double, w As Double, y As Double)
        Dim d As Double, d2 As Double, D3 As Double, D4 As Double, D5 As Double
        d = 1 - Math.Sqrt(1 + 2 * (0.5 - TargetU))
        ParName = "D"
        ParValue = d
        'D = -1 / 3
        d2 = d * d : D3 = d2 * d : D4 = D3 * d : D5 = D4 * d
        p = 1 / 2 + d - d2 / 2
        q = 1 / 3 + d - D3 / 3
        s = 1 / 4 + d - D4 / 4
        a = 1 / 5 + d - D5 / 5
        u = 5 / 24 + (5 / 6) * d + (3 / 4) * d2 - (5 / 6) * D3 + (1 / 24) * D4
        v = 1 / 6 + (2 / 3) * d + d2 - (2 / 3) * D3 - (1 / 6) * D4
        w = 2 / 15 + (2 / 3) * d + d2 - D3 / 3 - (2 / 3) * D4 + D5 / 5
        y = 3 / 20 + (3 / 4) * d + (5 / 6) * d2 - (1 / 2) * D3 - (1 / 4) * D4 + (1 / 60) * D5
    End Sub

    Sub cL(TargetU As Double, ParName As String, ParValue As Double, p As Double,
       q As Double, s2 As Double, u As Double, v As Double,
       aa As Double, w As Double, y As Double, r As Double, t As Double, b As Double, x As Double, z As Double)
        Dim a(0 To 100) As Integer, s(0 To 100) As Integer, n(0 To 100 + 1) As Integer
        Dim ss As String, Result As Double
        Dim k As Double
        k = TargetU / (1 - TargetU)
        ParName = "k"
        ParValue = k

        n(1) = 1 : n(2) = 1
        a(1) = 0 : a(2) = 1
        ss = "0, 1 :"
        Call A2S(a, s, n(1), n(2))
        Result = LehmannRO(s, n(1), n(2), k)
        p = Result
        '  Console.WriteLine( ss, "        p", Format(p, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 2 : n(2) = 1 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 0 : a(3) = 1
        ss = "0, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        q = Result
        '  Console.WriteLine( ss, "        q:", Format(q, "0.00000000000E+000")
        'DoneMilton

        n(1) = 3 : n(2) = 1 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 1
        ss = "0, 0, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        s2 = Result
        '  Console.WriteLine( ss, "        s:", Format(S2, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 4 : n(2) = 1 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 0 : a(5) = 1
        ss = "0, 0, 0, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        aa = Result
        '  Console.WriteLine( ss, "        a:", Format(aa, "0.00000000000E+000")
        '  DoneMilton



        n(1) = 1 : n(2) = 2 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 1 : a(3) = 1
        ss = "0, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        r = Result
        '  Console.WriteLine( ss, "        r:", Format(r, "0.00000000000E+000")
        'DoneMilton

        n(1) = 1 : n(2) = 3 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 1 : a(3) = 1 : a(4) = 1
        ss = "0, 1, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        t = Result
        '  Console.WriteLine( ss, "        t:", Format(T, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 1 : n(2) = 4 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 1 : a(3) = 1 : a(4) = 1 : a(5) = 1
        ss = "0, 1, 1, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        b = Result
        '  Console.WriteLine( ss, "        b:", Format(b, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 2 : n(2) = 2 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 1
        ss = "0, 0, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        v = Result
        '  Console.WriteLine( ss, "        v:", Format(v, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 2 : n(2) = 2 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 1
        ss = "0, 1, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        u = v + (1 / 4) * Result
        '  Console.WriteLine( ss, "       u: ", Format(u, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 3 : n(2) = 2 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 1 : a(5) = 1
        ss = "0, 0, 0, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        w = Result
        '  Console.WriteLine( ss, "       w1: ", Format(w, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 3 : n(2) = 2 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 0 : a(5) = 1
        ss = "0, 0, 1, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        w = w + (1 / 3) * Result
        '  Console.WriteLine( ss, "        w:", Format(w, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 3 : n(2) = 2 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 0 : a(5) = 1
        ss = "0, 1, 0, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        y = w + (1 / 6) * Result
        '  Console.WriteLine( ss, "       y: ", Format(y, "0.00000000000E+000")
        '  DoneMilton


        n(1) = 2 : n(2) = 3 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 1 : a(5) = 1
        ss = "0, 0, 1, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        x = Result
        '  Console.WriteLine( ss, "       x1: ", Format(x, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 2 : n(2) = 3 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 1 : a(5) = 1
        ss = "0, 1, 0, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        x = x + (1 / 3) * Result
        '  Console.WriteLine( ss, "        x:", Format(x, "0.00000000000E+000")
        '  DoneMilton

        n(1) = 2 : n(2) = 3 ':  Call InitMilton(GroupAnz, n())
        a(1) = 0 : a(2) = 1 : a(3) = 1 : a(4) = 0 : a(5) = 1
        ss = "0, 1, 1, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        z = x + (1 / 6) * Result
        '  Console.WriteLine( ss, "       z: ", Format(z, "0.00000000000E+000")
        '  DoneMilton



    End Sub

    Sub DemoCalcLehmannRO()
        Dim a(0 To 100) As Integer, s(0 To 100) As Integer, n(0 To 100 + 1) As Integer
        Dim GroupAnz As Integer, ss As String, Result As Double
        Dim p As Double, q As Double, r As Double, s2 As Double, t As Double, u As Double, v As Double
        Dim aa As Double, b As Double, w As Double, x As Double, y As Double, z As Double

        Dim k As Double

        k = 2.3
        GroupAnz = 2
        Console.WriteLine("Lehmann Alternatives")

        n(1) = 1 : n(2) = 1
        a(1) = 0 : a(2) = 1
        ss = "0, 1 :"
        Call A2S(a, s, n(1), n(2))
        Result = LehmannRO(s, n(1), n(2), k)
        p = Result
        Console.WriteLine("ss: {0}, p:{1}", ss, p)

        n(1) = 2 : n(2) = 1
        a(1) = 0 : a(2) = 0 : a(3) = 1
        ss = "0, 0, 1 :"
        Call A2S(a, s, n(1), n(2))
        Result = LehmannRO(s, n(1), n(2), k)
        q = Result
        Console.WriteLine("ss: {0}, q:{1}", ss, q)

        n(1) = 3 : n(2) = 1
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 1
        ss = "0, 0, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        s2 = Result
        Console.WriteLine("ss: {0}, s2:{1}", ss, s2)

        n(1) = 4 : n(2) = 1
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 0 : a(5) = 1
        ss = "0, 0, 0, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        aa = Result
        Console.WriteLine("ss: {0}, aa:{1}", ss, aa)



        n(1) = 1 : n(2) = 2
        a(1) = 0 : a(2) = 1 : a(3) = 1
        ss = "0, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        r = Result
        Console.WriteLine("ss: {0}, r:{1}", ss, r)

        n(1) = 1 : n(2) = 3
        a(1) = 0 : a(2) = 1 : a(3) = 1 : a(4) = 1
        ss = "0, 1, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        t = Result
        Console.WriteLine("ss: {0}, t:{1}", ss, t)

        n(1) = 1 : n(2) = 4
        a(1) = 0 : a(2) = 1 : a(3) = 1 : a(4) = 1 : a(5) = 1
        ss = "0, 1, 1, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        b = Result
        Console.WriteLine("ss: {0}, b:{1}", ss, b)

        n(1) = 2 : n(2) = 2
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 1
        ss = "0, 0, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        v = Result
        Console.WriteLine("ss: {0}, v:{1}", ss, v)

        n(1) = 2 : n(2) = 2
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 1
        ss = "0, 1, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        u = v + (1 / 4) * Result
        Console.WriteLine("ss: {0}, u:{1}", ss, u)

        n(1) = 3 : n(2) = 2
        a(1) = 0 : a(2) = 0 : a(3) = 0 : a(4) = 1 : a(5) = 1
        ss = "0, 0, 0, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        w = Result
        Console.WriteLine("ss: {0}, w1:{1}", ss, w)

        n(1) = 3 : n(2) = 2
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 0 : a(5) = 1
        ss = "0, 0, 1, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        w = w + (1 / 3) * Result
        Console.WriteLine("ss: {0}, w:{1}", ss, w)

        n(1) = 3 : n(2) = 2
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 0 : a(5) = 1
        ss = "0, 1, 0, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        y = w + (1 / 6) * Result
        Console.WriteLine("ss: {0}, y:{1}", ss, y)


        n(1) = 2 : n(2) = 3
        a(1) = 0 : a(2) = 0 : a(3) = 1 : a(4) = 1 : a(5) = 1
        ss = "0, 0, 1, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        x = Result
        Console.WriteLine("ss: {0}, x1:{1}", ss, x)

        n(1) = 2 : n(2) = 3
        a(1) = 0 : a(2) = 1 : a(3) = 0 : a(4) = 1 : a(5) = 1
        ss = "0, 1, 0, 1, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        x = x + (1 / 3) * Result
        Console.WriteLine("ss: {0}, x:{1}", ss, x)

        n(1) = 2 : n(2) = 3
        a(1) = 0 : a(2) = 1 : a(3) = 1 : a(4) = 0 : a(5) = 1
        ss = "0, 1, 1, 0, 1 :"
        Call A2S(a, s, n(1), n(2)) : Result = LehmannRO(s, n(1), n(2), k)
        z = x + (1 / 6) * Result
        Console.WriteLine("ss: {0}, z:{1}", ss, z)


    End Sub



    Sub A2S(a() As Integer, s() As Integer, m As Integer, n As Integer)
        Dim i As Integer, j As Integer
        j = 0
        For i = 1 To m + n
            If a(i) = 1 Then
                j = j + 1
                s(j) = i
            End If
        Next i
    End Sub

    Function LehmannRO(s() As Integer, m As Integer, n As Integer, k As Double) As Double
        Dim lnFaktor As Double, lnProd As Double, j As Integer
        lnFaktor = Math.Log(k) * n + LnGamma(n + 1) + LnGamma(m + 1) - LnGamma(n + m + 1 + n * (k - 1))
        lnProd = 0
        For j = 1 To n
            lnProd = lnProd + LnGamma(s(j) + j * (k - 1)) - LnGamma(s(j) + (j - 1) * (k - 1))
        Next j
        Return Math.Exp(lnFaktor + lnProd)
    End Function

    Function ExtremeValue(TargetU As Double, m As Integer, n As Integer, ind As Integer) As Double
        Dim i As Integer, k As Double, Result As Double
        Dim a() As Integer, s() As Integer
        ReDim a(m + n) : ReDim s(m + n)
        k = TargetU / (1 - TargetU)
        For i = 1 To m : a(i) = Math.Abs(0 - ind) : Next i
        For i = m + 1 To m + n : a(i) = 1 - ind : Next i
        Call A2S(a, s, m, n)
        'For i = 1 To m + n
        '  Console.WriteLine( i, a(i), s(i)
        'Next i
        Result = LehmannRO(s, m, n, k)
        Console.WriteLine("Result: {0}", Result)
        ExtremeValue = Result
    End Function

    Sub LehmanndemoNew()
        Dim pcum2 As Double
        Dim a(0 To 100) As Integer, s(0 To 100) As Integer
        Dim n(0 To 100 + 1) As Integer
        Dim pcum(0 To 100) As Double
        Dim p(0 To 100) As Integer, id(0 To 100) As Integer
        Dim GroupAnz As Integer, Index As Integer
        Dim x As Integer, y As Integer, temp As Integer, k As Integer
        Dim u As Integer, i1 As Integer, i2 As Integer, csum As Integer
        Dim count As Integer
        Dim done As Boolean
        Dim icount2 As Integer
        Dim ss As String
        Dim Result As Double
        Dim nmin As Integer
        Dim kValue As Double
        '  IsNormal = True
        GroupAnz = 3 '(*zahl der gruppen mit verschiedenen werten*)
        kValue = 8
        n(1) = 2 '(*gruppenstaerken*)
        n(2) = 2
        n(3) = 2
        n(4) = 1
        n(5) = 1
        n(6) = 1
        '  delta(1) = 0
        '  delta(2) = -1.2
        '  delta(3) = 3
        '  delta(4) = 2.5
        '  delta(5) = 2.5
        '  delta(6) = 2.5
        For i1 = 1 To GroupAnz
            id(i1) = i1 - 1 ' (*werte der gruppen*)
        Next i1
        '  Call InitMilton(GroupAnz, n())

        csum = 0
        count = 0
        For i1 = 1 To GroupAnz
            csum = csum + n(i1)
            For i2 = 1 To n(i1)
                count = count + 1
                a(count) = id(i1)
                p(count) = GroupAnz - i1 + 1
            Next i2
        Next i1

        icount2 = 1
        x = 1
        y = 2
        k = GroupAnz
        u = csum + 1
        done = False
        p(0) = GroupAnz + 1
        p(u) = GroupAnz + 1

        While Not (done)
            ss = Format(icount2, "#00") + ": "
            Index = 0
            For i1 = 1 To csum
                ss = ss + Str(a(i1))
                If a(i1) = 0 Then Index = Index + i1
            Next i1
            Call A2S(a, s, n(1), n(2))
            Result = LehmannRO(s, n(1), n(2), kValue)
            pcum(Index) = pcum(Index) + Result

            '    result = RunMilton(a)
            Console.WriteLine("ss: {0}, Index: {1}, Result: {2}", ss, Index, Result)

            '    Console.WriteLine( ss, "        ", Format(Result, "Scientific")
            Call Chase2(x, y, k, u, done, p)
            temp = a(x)
            a(x) = a(y)
            a(y) = temp
            icount2 = icount2 + 1
        End While

        ' DoneMilton

        nmin = n(1) * (n(1) + 1) \ 2
        Console.WriteLine("Verteilung")
        pcum2 = 0
        For Index = nmin To nmin + n(1) * n(2)
            pcum2 = pcum2 + pcum(Index)
            Console.WriteLine("Index: {0}, pcum(Index): {1}, pcum2: {2}", Index, pcum(Index), pcum2)
        Next Index
    End Sub



    Sub LehmannDemoRecursive()
        Dim kValue As Double, pprob() As Double
        Dim N1 As Integer, n2 As Integer, panz As Integer
        Dim i As Integer, p As Double, pcum As Double
        kValue = 2 : N1 = 8 : n2 = 8
        Call CalcMWLehmann(kValue, N1, n2, panz, pprob)

        Console.WriteLine("Final Result")
        pcum = 0
        For i = 0 To panz
            p = pprob(i)
            pcum = pcum + p
            Console.WriteLine("i: {0}, p: {1}, pcum: {2}, 1 - pcum: {3}", i, p, pcum, 1 - pcum)
        Next i
    End Sub

    ' Recursive algorithm for Lehmann alternatives for the Mann-Whitney test
    Sub CalcMWLehmann(kValue As Double, N1 As Integer, n2 As Integer, ByRef panz As Integer,
                      ByRef pprob() As Double)
        Dim Rank() As Integer
        Dim n() As Integer
        Dim j As Integer, m As Integer, ng As Integer
        Dim xvec(,,) As Double
        Dim i As Integer ', p As Double, pcum As Double
        m = 1
        ReDim n(m)
        n(0) = N1 : n(1) = n2
        ng = 0
        For j = 0 To m
            ng = ng + n(j)
        Next j

        ReDim Rank(ng + 1)
        For j = 0 To ng
            Rank(j) = j
        Next j
        Call CalcRankSums(kValue, xvec, m, ng, n, Rank)
        panz = n(0) * n(1)
        ReDim pprob(panz)
        For i = 0 To panz
            pprob(panz - i) = xvec(0, 0, i)
        Next i
        Erase xvec
    End Sub

    Sub CalcRankSums(kValue As Double, ByRef xvec(,,) As Double, ByRef m As Integer, ByRef ng As Integer,
                     ByRef n() As Integer, ByRef Rank() As Integer)
        Dim AddPos(10) As Integer, w(10) As Integer, CurNum(10) As Integer
        Dim z(,) As Integer, zlength() As Integer, ztemp() As Integer, Last() As Integer
        Dim first As Boolean, EQ As Boolean, LE As Boolean
        Dim CurNumCount As Integer, zmax As Integer, h As Integer, k2 As Integer, i As Integer
        Dim j As Integer, k As Integer, l As Integer, j2 As Integer, k3 As Integer, zul As Integer
        Dim r As Integer, k1 As Integer, i1 As Integer, i2 As Integer, msize As Integer, vref As Integer, w1 As Integer
        Dim j1 As Integer, q As Integer, m1 As Integer, CurrentNumber As Integer, Lastj As Integer, xstart As Integer
        Dim calc As Boolean, showstruc As Boolean, showvec As Boolean
        Dim s2 As String

        calc = True : showstruc = False : showvec = False
        h = m - 1
        m1 = m + 1
        ReDim zlength(ng + 1)
        zul = 1000
        If m = 1 Then
            If n(0) < n(1) Then zul = n(0) * (m1 + 1) Else zul = n(1) * (m1 + 1)
        End If
        ReDim ztemp(zul)
        ReDim Last(zul)
        ReDim z(ng + 1, zul)

        For j = 0 To m : w(j) = n(j) : Next j

        For j = 0 To m : n(j) = w(j) : Next j
        For k = 0 To m : z(ng, k) = w(k) : Next k
        zlength(ng) = 0

        zmax = 0
        For i = ng - 1 To 0 Step -1
            i1 = i + 1
            first = True
            For j = 0 To zlength(i1)
                For k2 = 0 To m
                    If z(i1, j * m1 + k2) > 0 Then
                        For k1 = 0 To m
                            w(k1) = z(i1, j * m1 + k1)
                        Next k1
                        w(k2) = w(k2) - 1
                        If first Then
                            first = False
                            zlength(i) = 0
                            For k = 0 To m
                                ztemp(k) = w(k)
                            Next k
                        Else
                            l = 0 : r = zlength(i)
                            Do
                                q = (l + r + 1) \ 2
                                k = -1
                                Do
                                    k = k + 1
                                    vref = ztemp(q * m1 + k)
                                    EQ = (vref = w(k))
                                Loop Until Not ((k < h) And EQ)
                                LE = (vref <= w(k))
                                If LE Then l = q Else r = q - 1
                            Loop Until l = r
                            k = 0
                            While (ztemp(l * m1 + k) = w(k)) And (k <= h) : k = k + 1 : End While
                            If k < m Then
                                zlength(i) = zlength(i) + 1
                                l = l + 1
                                If zlength(i) <> l Then
                                    For i2 = zlength(i) To 0 Step -1
                                        For k = 0 To m
                                            ztemp((i2 + 1) * m1 + k) = ztemp(i2 * m1 + k)
                                        Next k
                                    Next i2
                                End If
                                For k = 0 To m
                                    ztemp(l * m1 + k) = w(k)
                                Next k
                            End If
                        End If
                    End If '(*if w(k)-1>0*)
                Next k2
            Next j

            For j = 0 To (zlength(i) + 1) * m1 - 1
                z(i, j) = ztemp(j)
            Next j
            If zlength(i) > zmax Then zmax = zlength(i)
        Next i

        '{Calculate the Vectors}
        ReDim xvec(1, zmax, n(0) * n(1))
        xvec(0, 0, 0) = 1
        xstart = ng Mod 2
        For i = 1 To ng
            If calc Then
                If xstart = 1 Then xstart = 0 Else xstart = 1
            End If

            i1 = i - 1
            For j = 0 To (zlength(i1) + 1) * m1
                Last(j) = z(i1, j)
            Next j
            Lastj = zlength(i1)
            If showstruc Then Console.WriteLine((Str(i) + ". Iteration"))

            For j = 0 To zlength(i)
                If showstruc Then
                    s2 = Str(j) + ". Vector"
                    For k = 0 To m : s2 = s2 + Str(z(i, j * m1 + k)) : Next k
                    s2 = s2 + "  :"
                End If
                CurNumCount = -1
                For k = 0 To m
                    If z(i, j * m1 + k) > 0 Then
                        For k1 = 0 To m
                            w(k1) = z(i, j * m1 + k1)
                        Next k1
                        w(k) = w(k) - 1
                        If showstruc Then
                            For k1 = 0 To m
                                s2 = s2 + Str(w(k1))
                                If k = k1 Then s2 = s2 + "+"
                            Next k1
                        End If

                        j2 = -1
                        Do
                            j2 = j2 + 1
                            k3 = -1
                            Do
                                k3 = k3 + 1
                                EQ = (w(k3) = Last(j2 * m1 + k3))
                            Loop Until Not (EQ And (k3 < m))
                        Loop Until (EQ Or (j2 = Lastj))
                        CurrentNumber = j2

                        If Not (EQ) Then CurrentNumber = CurrentNumber + 1
                        CurNumCount = CurNumCount + 1
                        CurNum(CurNumCount) = CurrentNumber
                        AddPos(CurNumCount) = k
                        If showstruc Then
                            s2 = s2 + " (" + Str(CurNum(CurNumCount)) + "; " + Str(AddPos(CurNumCount)) + ")"
                            s2 = s2 + ", "
                        End If
                    End If
                Next k
                If showstruc Then Console.WriteLine(s2)
                If calc Then Call BuildMWVector(xvec, xstart, kValue, z(i, j * m1),
        z(i, j * m1 + 1), j, CurNum(0), CurNum(1))
            Next j
        Next i
        Erase zlength : Erase Last : Erase z : Erase ztemp
    End Sub

    Sub BuildMWVector(xvec(,,) As Double, xstart As Integer,
k As Double, n As Integer, m As Integer,
Target As Integer, Source1 As Integer, Source2 As Integer)

        Dim f1 As Double, f2 As Double, pcum As Double
        Dim i As Integer, ystart As Integer, p As Double
        If xstart = 1 Then ystart = 0 Else ystart = 1
        If ((n = 0) Or (m = 0)) Then
            xvec(xstart, Target, i) = 1
            Exit Sub
        End If
        f1 = n / (k * m + n)
        f2 = k * m / (k * m + n)
        For i = 0 To n * m
            xvec(xstart, Target, i) = 0
        Next i
        If f2 > 0 Then
            For i = 0 To n * (m - 1)
                xvec(xstart, Target, i) = xvec(xstart, Target, i) + f2 * xvec(ystart, Source2, i)
            Next i
        End If
        If f1 > 0 Then
            For i = m To m * n
                xvec(xstart, Target, i) = xvec(xstart, Target, i) + f1 * xvec(ystart, Source1, i - m)
            Next i
        End If
    End Sub


    '*************************************************************************************************************
    '*************************************************************************************************************


    Sub EstimateRankOrders2(m As Integer, n As Integer, ByRef u() As Double)
        Dim i As Integer, j As Integer, m1 As Double, m2 As Double, m3 As Double
        Dim N1 As Double, n2 As Double, n3 As Double, mn As Double, Uj As Double
        Dim P11 As Double, P21 As Double, P31 As Double, P41 As Double, P12 As Double, P13 As Double, P14 As Double
        Dim P22 As Double, P32 As Double, P23 As Double, P22j1 As Double, P32j1 As Double, P32j2 As Double
        Dim P23j1 As Double, P23j2 As Double
        Dim U11 As Double, U21 As Double, U31 As Double, U41 As Double, U12 As Double, U13 As Double, U14 As Double
        Dim U22 As Double, U32 As Double, U23 As Double, U22j1 As Double ', U32j1 As Double, U32j2 As Double
        Dim U23j1 As Double, U23j2 As Double
        'Dim p As Double, q As Double, r As Double, s As Double, t As Double, uu As Double, vv As Double
        'Dim a As Double, b As Double, ww As Double, x As Double, y As Double, z As Double

        Dim v() As Double, w() As Double, v2() As Double, vs() As Double
        ReDim v(m) : ReDim w(m) : ReDim v2(m) : ReDim vs(m)
        Console.WriteLine("Fast")

        v(1) = u(1) : For i = 2 To m : v(i) = v(i - 1) + u(i) : Next i
        vs(1) = v(1) : For i = 2 To m : vs(i) = vs(i - 1) + v(i) : Next i
        v2(1) = 1.0# * u(1) * u(1) : For i = 2 To m : v2(i) = v2(i - 1) + 1.0# * u(i) * u(i) : Next i
        w(m) = u(m) : For i = m - 1 To 1 Step -1 : w(i) = w(i + 1) + u(i) : Next i

        P11 = 0 : P21 = 0 : P31 = 0 : P41 = 0 : P12 = 0 : P13 = 0 : P14 = 0
        P22 = 0 : P32 = 0 : P23 = 0 : P22j1 = 0 : P32j1 = 0 : P32j2 = 0
        P23j1 = 0 : P23j2 = 0
        For i = 1 To m
            U11 = u(i)
            U21 = U11 * (i - 1)
            U31 = U21 * (i - 2)
            U41 = U31 * (i - 3)
            U12 = U11 * (U11 - 1)
            U13 = U12 * (U11 - 2)
            U14 = U13 * (U11 - 3)
            U22 = U12 * (i - 1)
            U32 = U22 * (i - 2)
            U23 = U13 * (i - 1)
            P11 = P11 + U11
            P21 = P21 + U21
            P31 = P31 + U31
            P41 = P41 + U41
            P12 = P12 + U12
            P13 = P13 + U13
            P14 = P14 + U14
            P22 = P22 + U22
            P32 = P32 + U32
            P23 = P23 + U23
        Next i
        For i = 2 To m
            U22j1 = u(i) * (v(i - 1) - u(i) * (i - 1))
            U23j1 = U22j1 * (u(i) - 1.0#)
            U23j2 = v2(i - 1) - (v(i - 1) * u(i))
            P22j1 = P22j1 + U22j1
            P23j1 = P23j1 + U23j1
            P23j2 = P23j2 + u(i) * (U23j2 - U22j1) - U22j1
        Next i
        For i = 2 To m - 1
            P32j1 = P32j1 + (u(i) * w(i + 1) - 0.5 * i * u(i + 1) * u(i + 1)) * (i - 1)
            P32j2 = P32j2 + u(i + 1) * (vs(i - 1) - 0.5 * i * (i - 1) * u(i + 1))
        Next i
        mn = 1.0# * m * n
        m1 = m - 1 : m2 = m - 2 : m3 = m - 3
        N1 = n - 1 : n2 = n - 2 : n3 = n - 3
        P11 = P11 / mn
        P21 = 2 * P21 / (mn * m1)
        P31 = 3 * P31 / (mn * m1 * m2)
        P41 = 4 * P41 / (mn * m1 * m2 * m3)
        P12 = P12 / (mn * N1)
        P13 = P13 / (mn * N1 * n2)
        P14 = P14 / (mn * N1 * n2 * n3)
        P22 = 2 * P22 / (mn * m1 * N1)
        P32 = 3 * P32 / (mn * m1 * m2 * N1)
        P23 = 2 * P23 / (mn * m1 * N1 * n2)
        P22j1 = 4 * P22j1 / (mn * m1 * N1)
        P32j1 = 12 * P32j1 / (mn * m1 * m2 * N1)
        P32j2 = 6 * P32j2 / (mn * m1 * m2 * N1)
        P23j1 = 6 * P23j1 / (mn * m1 * N1 * n2)
        P23j2 = 6 * P23j2 / (mn * m1 * N1 * n2)
        Console.WriteLine("P11:  {0}", P11)
        Console.WriteLine("P21:  {0}", P21)
        Console.WriteLine("P31:  {0}", P31)
        Console.WriteLine("P41:  {0}", P41)
        Console.WriteLine("P12:  {0}", P12)
        Console.WriteLine("P13:  {0}", P13)
        Console.WriteLine("P14:  {0}", P14)
        Console.WriteLine("P22:  {0}", P22)
        Console.WriteLine("P32:  {0}", P32)
        Console.WriteLine("P23:  {0}", P23)
        Console.WriteLine("P22j1:  {0}", P22j1)
        Console.WriteLine("P32j1:  {0}", P32j1)
        Console.WriteLine("P32j2:  {0}", P32j2)
        Console.WriteLine("P23j1:  {0}", P23j1)
        Console.WriteLine("P23j2:  {0}", P23j2)
        '
        'p = P11
        'q = P12
        's = P13
        'a = P14
        'vv = P22
        'uu = vv + (1 / 4) * P22j1
        'ww = P32 + (1 / 3) * P32j1
        'y = ww + (1 / 6) * P32j2
        'r = P21
        't = P31
        'b = P41
        'x = P23 + (1 / 3) * P23j1
        'z = x + (1 / 6) * P23j2
        'Console.WriteLine( "p: ", p
        'Console.WriteLine( "q: ", s
        'Console.WriteLine( "s: ", s
        'Console.WriteLine( "a: ", a
        'Console.WriteLine( "u: ", uu
        'Console.WriteLine( "v: ", vv
        'Console.WriteLine( "w: ", ww
        'Console.WriteLine( "y: ", y
        'Console.WriteLine( "r: ", r
        'Console.WriteLine( "t: ", t
        'Console.WriteLine( "b: ", b
        'Console.WriteLine( "x: ", x
        'Console.WriteLine( "z: ", z

    End Sub





    Sub FillData(NStart As Integer, Nstop As Integer, ByRef a() As Double, ByRef Ranks() As Integer, d As Double)
        Dim i As Integer, j As Integer
        'ReDim a(n): ReDim Ranks(n)

        For i = NStart To Nstop
            Ranks(i) = i
            a(i) = Rnd() + d
        Next i
    End Sub

    Sub ShowData(n As Integer, ByRef a() As Double, ByRef Ranks() As Integer)
        Dim i As Integer
        For i = 0 To n
            Console.WriteLine(" i: {0}, Ranks(i) {1}, a(i) {2}", i, Ranks(i), a(i))
        Next i
    End Sub


    Private Sub InsertSort(ByRef a() As Double, ByRef Lb As Integer, ByRef Ub As Integer)
        Dim i As Integer, j As Integer, x As Double
        For i = Lb + 1 To Ub
            x = a(i)
            For j = i - 1 To Lb Step -1
                If Not (x < a(j)) Then Exit For
                a(j + 1) = a(j)
            Next j
            a(j + 1) = x
        Next i
    End Sub


    Sub InsertSortRanks(ByRef a() As Double, ByRef Rank() As Integer, ByRef Lb As Integer, ByRef Ub As Integer)
        Dim i As Integer, j As Integer, x As Double, u As Integer
        For i = Lb + 1 To Ub
            x = a(i) : u = Rank(i)
            For j = i - 1 To Lb Step -1
                If Not (x < a(j)) Then Exit For
                a(j + 1) = a(j)
                Rank(j + 1) = Rank(j)
            Next j
            a(j + 1) = x : Rank(j + 1) = u
        Next i
    End Sub


    Sub SortRanks2(ByRef a() As Double, ByRef Rank() As Integer, Lb As Integer, Ub As Integer,
m As Integer, MedianOf3 As Boolean)
        Dim i As Integer, j As Integer, l As Integer, r As Integer, s As Integer
        Dim x As Double, w As Double, u As Integer
        Dim sl(64) As Integer, sr(64) As Integer, v(3) As Double
        'Dim smax As Integer
        'If IsMissing(m) Then m = 10
        'If IsMissing(MedianOf3) Then MedianOf3 = True

        s = 1 : sl(1) = Lb : sr(1) = Ub
        Do
            l = sl(s) : r = sr(s) : s = s - 1
            If ((r - l) <= m) Then
                Call InsertSortRanks(a, Rank, l, r)
            Else
                Do
                    i = l : j = r
                    x = a((l + r) \ 2)
                    If MedianOf3 Then
                        v(1) = a(l) : v(2) = x : v(3) = a(r)
                        Call InsertSort(v, 1, 3)
                        x = v(2)
                    End If
                    Do
                        While a(i) < x : i = i + 1 : End While
                        While x < a(j) : j = j - 1 : End While
                        If i <= j Then
                            w = a(i) : a(i) = a(j) : a(j) = w
                            u = Rank(i) : Rank(i) = Rank(j) : Rank(j) = u
                            i = i + 1 : j = j - 1
                        End If
                    Loop Until i > j
                    If (j - l) < (r - i) Then
                        If (i < r) Then
                            s = s + 1 : sl(s) = i : sr(s) = r
                        End If
                        r = j
                    Else
                        If l < j Then
                            s = s + 1 : sl(s) = l : sr(s) = j
                        End If
                        l = i
                    End If
                Loop Until l >= r
            End If
        Loop Until s = 0
    End Sub


    Sub DemoSampleEstRO()
        Dim n As Integer, a() As Double
        Dim ar() As Integer, d As Double
        Dim k As Integer, j As Integer
        Dim ysum As Integer, i As Integer, N1 As Integer, n2 As Integer, u() As Double
        N1 = 1000
        n2 = 1000
        d = 0
        n = (N1 + n2) - 1
        ReDim u(N1 + 1)
        ReDim a(n)
        ReDim ar(n)
        d = 0
        Call FillData(0, N1 - 1, a, ar, d)
        d = 0#
        Call FillData(N1, n, a, ar, d)
        Console.WriteLine("Sorting")
        Call SortRanks2(a, ar, 0, n, 10, True)
        '        Call SortRanksStats(a, ar, 0, n, 10)
        '    Call ShowData(n, a, ar)
        Console.WriteLine("Calculating U")
        ysum = 0 : j = 0
        For i = 0 To n
            If ar(i) > (N1 - 1) Then
                ysum = ysum + 1
            Else
                j = j + 1
                u(j) = n2 - ysum
            End If
        Next i
        '    For i = 1 To n1
        '      Console.WriteLine( i, U(i)
        '    Next i
        'Call EstimateRankOrders(n1, n2, U())
        Console.WriteLine("--------Rank Orders---------------")
        Call EstimateRankOrders2(N1, n2, u)
    End Sub

    Sub CalcUniformRO(d As Double)
        Dim d2 As Double, D3 As Double, D4 As Double, D5 As Double
        Dim p As Double, q As Double, r As Double, s As Double, t As Double, u As Double, v As Double
        Dim a As Double, b As Double, w As Double, x As Double, y As Double, z As Double
        d2 = d * d : D3 = d2 * d : D4 = D3 * d : D5 = D4 * d
        p = 1 / 2 + d - d2 / 2
        q = 1 / 3 + d - D3 / 3
        s = 1 / 4 + d - D4 / 4
        a = 1 / 5 + d - D5 / 5
        u = 5 / 24 + (5 / 6) * d + (3 / 4) * d2 - (5 / 6) * D3 + (1 / 24) * D4
        v = 1 / 6 + (2 / 3) * d + d2 - (2 / 3) * D3 - (1 / 6) * D4
        w = 2 / 15 + (2 / 3) * d + d2 - D3 / 3 - (2 / 3) * D4 + D5 / 5
        y = 3 / 20 + (3 / 4) * d + (5 / 6) * d2 - (1 / 2) * D3 - (1 / 4) * D4 + (1 / 60) * D5
        r = q
        t = s
        b = a
        x = w
        z = y
        Console.WriteLine("p:  {0}", p)
        Console.WriteLine("q:  {0}", s)
        Console.WriteLine("s:  {0}", s)
        Console.WriteLine("a:  {0}", a)
        Console.WriteLine("u:  {0}", u)
        Console.WriteLine("v:  {0}", v)
        Console.WriteLine("w:  {0}", w)
        Console.WriteLine("y:  {0}", y)
        Console.WriteLine("r:  {0}", r)
        Console.WriteLine("t:  {0}", t)
        Console.WriteLine("b:  {0}", b)
        Console.WriteLine("x:  {0}", x)
        Console.WriteLine("z:  {0}", z)
    End Sub

    Sub DemoUniformEstRO()
        Dim d As Double
        d = 0.2
        Console.WriteLine("Uniform for D = {0}", d)
        Call CalcUniformRO(d)
    End Sub


    Sub MW_Moments(dis As Integer, TargetU As Double, n As Integer, m As Integer, mu1 As Double, sigma As Double, g1 As Double, g2 As Double, LXV As Double, RXV As Double)
        Dim p As Double, q As Double, s As Double, u As Double, v As Double, a As Double, w As Double, y As Double, r As Double, t As Double, b As Double, x As Double, z As Double
        Dim p2 As Double, p3 As Double, p4 As Double, n2 As Double, n3 As Double, n4 As Double, m2 As Double, m3 As Double, m4 As Double, q2 As Double, r2 As Double
        Dim mu2 As Double, mu3 As Double, mu4 As Double, temp As Double
        Dim ParValue As Double, ParName As String, SmallTarget As Boolean
        'Dis: 0=null, 1=normal, 2=logistic, 3=uniform, 4=lehmann
        If TargetU < 0.5 Then
            TargetU = 1 - TargetU
            SmallTarget = True
        Else
            SmallTarget = False
        End If
        Select Case dis
            Case 0 : p = 0.5 : q = 1 / 3 : s = 0.25 : u = 1 / 4.8 : v = 1 / 6 : a = 0.2 : w = 2 / 15 : y = 0.15
            Case 1 : Call cn(True, TargetU, ParName, ParValue, p, q, s, u, v, a, w, y)
            Case 2 : Call cn(False, TargetU, ParName, ParValue, p, q, s, u, v, a, w, y)
            Case 3 : Call cU(TargetU, ParName, ParValue, p, q, s, u, v, a, w, y)
            Case 4 : Call cL(TargetU, ParName, ParValue, p, q, s, u, v, a, w, y, r, t, b, x, z)
        End Select
        If dis <= 3 Then
            r = q : t = s : b = a : x = w : z = y
        End If
        Console.WriteLine("ParName: {0}, ParValue: {1}", ParName, ParValue)
        n2 = n * n : n3 = n2 * n : n4 = n3 * n : m2 = m * m : m3 = m2 * m : m4 = m3 * m
        p2 = p * p : p3 = p2 * p : p4 = p3 * p : q2 = q * q : r2 = r * r
        If SmallTarget Then mu1 = m * n * (1 - p) Else mu1 = m * n * p
        ' mu2 to mu4 are central moments
        mu2 = m * n * ((p - p2) + (m - 1) * (q - p2) + (n - 1) * (r - p2))
        mu3 = (6 * p3 + 6 * u - 6 * p * q - 6 * p * r) * m2 * n2 _
      + (2 * p3 + s - 3 * p * q) * m3 * n + (2 * p3 + t - 3 * p * r) * m * n3 _
      + (9 * p * q + 6 * p * r + 3 * q - 3 * s - 6 * u - 3 * p2 - 6 * p3) * m2 * n _
      + (9 * p * r + 6 * p * q + 3 * r - 3 * t - 6 * u - 3 * p2 - 6 * p3) * m * n2 _
      + (4 * p3 + 3 * p2 + p + 6 * u + 2 * s + 2 * t - 6 * p * q - 6 * p * r - 3 * q - 3 * r) * m * n
        mu4 = 3 * (q - p2) ^ 2 * m4 * n2 + 6 * (q - p2) * (r - p2) * m3 * n3 + 3 * (r - p2) ^ 2 * m2 * n4 _
      + (12 * q * p2 + a - 4 * s * p - 3 * q2 - 6 * p4) * m4 * n + (12 * r * p2 + b - 4 * t * p - 3 * r2 - 6 * p4) * m * n4 _
      + (42 * r * p2 + 72 * q * p2 + 6 * q * p + 12 * w + 12 * y - 42 * p4 - 18 * q2 - 18 * q * r - 12 * s * p - 48 * u * p - 6 * p3) * m3 * n2 _
      + (42 * q * p2 + 72 * r * p2 + 6 * r * p + 12 * x + 12 * z - 42 * p4 - 18 * r2 - 18 * q * r - 12 * t * p - 48 * u * p - 6 * p3) * m2 * n3

        mu4 = mu4 + (36 * p4 + 18 * q2 + 12 * q * r - 72 * q * p2 - 36 * r * p2 + 24 * s * p - 6 * a + 48 * u * p - 12 * w - 12 * y + 12 * p3 - 18 * q * p + 6 * s) * m3 * n _
      + (36 * p4 + 18 * r2 + 12 * q * r - 72 * r * p2 - 36 * q * p2 + 24 * t * p - 6 * b + 48 * u * p - 12 * x - 12 * z + 12 * p3 - 18 * r * p + 6 * t) * m * n3 _
      + (105 * p4 + 42 * p3 + 3 * p2 + 33 * q2 + 33 * r2 + 54 * q * r - 174 * q * p2 - 174 * r * p2 - 42 * p * q _
        - 42 * p * r + 36 * s * p + 36 * t * p + 192 * u * p - 36 * w - 36 * x - 36 * y - 36 * z + 6 * v + 36 * u) * m2 * n2

        mu4 = mu4 + (132 * q * p2 + 108 * r * p2 - 66 * p4 - 33 * q2 - 36 * q * r - 18 * r2 - 44 * s * p - 24 * t * p + 11 * a _
        - 144 * u * p + 36 * w + 24 * x + 36 * y + 24 * z - 6 * v - 36 * p3 - 36 * u - 7 * p2 + 54 * p * q + 36 * p * r - 18 * s + 7 * q) * m2 * n _
      + (132 * r * p2 + 108 * q * p2 - 66 * p4 - 33 * r2 - 36 * q * r - 18 * q2 - 44 * t * p - 24 * s * p + 11 * b _
        - 144 * u * p + 24 * w + 36 * x + 24 * y + 36 * z - 6 * v - 36 * p3 - 36 * u - 7 * p2 + 54 * p * r + 36 * p * q - 18 * t + 7 * r) * m * n2

        mu4 = mu4 + (36 * p4 + 18 * q2 + 24 * q * r + 18 * r2 - 72 * q * p2 - 72 * r * p2 + 24 * s * p + 24 * t * p - 6 * a - 6 * b _
        + 96 * u * p - 24 * w - 24 * x - 24 * y - 24 * z + 6 * v + 24 * p3 + 36 * u _
        + 7 * p2 - 36 * p * q - 36 * p * r + 12 * s + 12 * t - 7 * q - 7 * r + p) * m * n

        sigma = Math.Sqrt(mu2)
        g1 = mu3 / (mu2 * sigma)
        g2 = mu4 / (mu2 * mu2) - 3
        LXV = ExtremeValue(TargetU, m, n, 1)
        RXV = ExtremeValue(TargetU, m, n, 0)
        If SmallTarget Then
            g1 = -g1
            temp = RXV : RXV = LXV : LXV = temp
        End If
        Console.WriteLine("Moments from formula")
        Console.WriteLine("mu2: {0}, mu3: {1}, m4: {2}", mu2, mu3, m4)
        Console.WriteLine("g1: {0}, g2: {1}", g1, g2)
    End Sub

    Function MW_Density(x As Double, sigma As Double, g1 As Double, g2 As Double) As Double
        Dim zz(0 To 6) As Double, density As Double, dsum1 As Double, dsum2 As Double
        Call NdensDeriv(6, x, zz)
        dsum1 = -g1 * zz(3) / 6
        dsum2 = g2 * zz(4) / 24 + g1 * g1 * zz(6) / 72
        density = (zz(0) + dsum1 + dsum2) / sigma
        If density < 0 Then density = -density
        MW_Density = density
    End Function

    Function MW_CDF2(x As Double, sigma As Double, g1 As Double, g2 As Double) As Double
        Dim zz(0 To 5) As Double, LeftTail As Double, dsum1 As Double, dsum2 As Double
        x = x + 1 / (sigma * 2)
        LeftTail = ndis(x)
        Call NdensDeriv(5, x, zz)
        dsum1 = -g1 * zz(2) / 6
        dsum2 = g2 * zz(3) / 24 + g1 * g1 * zz(5) / 72
        LeftTail = (LeftTail + dsum1 + dsum2)
        If LeftTail < 0 Then LeftTail = -LeftTail
        MW_CDF2 = LeftTail
    End Function

    Function MW_CDF(x As Double, sigma As Double, g1 As Double, g2 As Double) As Double
        Dim x2 As Double, x3 As Double, x5 As Double, e As Double, LeftTail As Double, Righttail As Double, density As Double
        x2 = x * x : x3 = x2 * x : x5 = x3 * x2
        Call ndis2(False, x, LeftTail, Righttail, density)
        e = 1 / (2 * sigma) + x / (12 * sigma * sigma) + g1 * (1 - x2) / 6 _
        - (g2 / 24 - g1 / (12 * sigma)) * (3 * x - x3) _
        + g1 * g1 * (15 * x - 10 * x3 + x5) / 72
        MW_CDF = LeftTail - density * e
    End Function












End Module
