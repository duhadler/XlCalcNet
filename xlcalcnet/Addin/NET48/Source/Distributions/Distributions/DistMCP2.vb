Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet



Module DistMCP2

    Const sqrtpi = 1.77245385090552
    Private S1 As Double, S As Double,
        n As Double, X As Double, N1 As Double, N2 As Double, gamman2 As Double,
        Lastvalue As Double, lefttail1 As Double, RightTail1 As Double,
        k As Integer, dis As Integer, L(0 To 100) As Integer, mu2(0 To 100) As Double,
        i As Integer, lmax As Integer,
        IsDuncan As Boolean, ShowRange As Boolean, ShowSum As Boolean, ShowBorder As Boolean,
        mu(0 To 100) As Double, xvalue(0 To 100) As Double, YValue(0 To 100) As Double

    Private Function Q(X As Double) As Double
        Dim myrho As Double
        ' dis=1: SR, 2: Duncan, 3: SMM1, 4:SMM2, 5: Dunnett1, 6: Dunnett2
        myrho = 0.5
        S1 = 1
        If dis = 1 Then Call NormalRangeDis(X, k, lefttail1, RightTail1)
        If dis = 2 Then Call NormalRangeDis(X, k, lefttail1, RightTail1)
        If dis = 3 Then Call ModulusDisN(False, X, k, lefttail1, RightTail1, mu, L)
        If dis = 4 Then Call ModulusDisN(True, X, k, lefttail1, RightTail1, mu, L)
        If dis = 5 Then Call NMultEqualCorrDisN(False, X, k, myrho, lefttail1, RightTail1, mu2, L)
        If dis = 6 Then Call NMultEqualCorrDisN(True, X, k, myrho, lefttail1, RightTail1, mu2, L)
        S1 = RightTail1
        Q = S1
    End Function

    Private Function LnQ(X As Double) As Double
        Dim k1 As Integer
        k1 = k
        If dis = 1 Or dis = 2 Then k1 = ((k + 1) * k) \ 2
        S1 = 1
        '    Call LnModulusDisN(True, True, x, k1, LeftTail1, RightTail1, mu, l)
        Call LnModulusDisN(True, True, X, k1, lefttail1, RightTail1)
        S1 = RightTail1
        LnQ = S1
    End Function

    Private Function CalcF(y As Double) As Double
        Dim F As Double, f1 As Double, f5 As Double
        If ((y <= 0) And (N1 > 0)) Then
            CalcF = 0
        Else
            F = -N2 * y * y
            If N1 > 0 Then f5 = N1 * Math.Log(y) Else f5 = 0
            F = F + f5
            F = F - gamman2
            f1 = Q(X * y)
            CalcF = Math.Exp(F) * f1
        End If
    End Function

    Private Function CalcLnF(y As Double) As Double
        Dim F As Double, f2 As Double, f3 As Double, f5 As Double, C As Double
        C = 100
        If ((y <= 0) And (N1 > 0)) Then y = 1.0E-100
        F = -N2 * y * y
        If N1 > 0 Then f5 = N1 * Math.Log(y) Else f5 = 0
        F = F + f5
        F = F - gamman2
        '   f2 = LnQ(x * y)
        f2 = Math.Log(Q(X * y))
        f3 = F + f2
        F = -Math.Log(-f3 + C)
        CalcLnF = F
    End Function

    Private Function studdis1(a As Double, xm As Double, b As Double) As Double
        Const points = 13
        Static null2(0 To points) As Double, gew2(0 To points) As Double
        Dim sneu As Double, y As Double, F As Double, S1 As Double
        Dim C As Double, d As Double, S As Double, i As Integer
        If null2(1) = 0 Then
            null2(1) = 0.201128576548871
            null2(2) = 0.603921058625552
            null2(3) = 1.00833827104672
            null2(4) = 1.41552780019819
            null2(5) = 1.82674114360369
            null2(6) = 2.2433914677615
            null2(7) = 2.66713212453562
            null2(8) = 3.09997052958644
            null2(9) = 3.54444387315535
            null2(10) = 4.00390860386123
            null2(11) = 4.48305535709252
            null2(12) = 4.98891896858994
            null2(13) = 5.5331471515675

            gew2(1) = 0.402346066701903
            gew2(2) = 0.403419816924804
            gew2(3) = 0.405605123325684
            gew2(4) = 0.408981575003532
            gew2(5) = 0.413679363611139
            gew2(6) = 0.419895003736824
            gew2(7) = 0.427918062932744
            gew2(8) = 0.438177022652684
            gew2(9) = 0.451321035991189
            gew2(10) = 0.468374812564729
            gew2(11) = 0.491057995832883
            gew2(12) = 0.522525689331355
            gew2(13) = 0.569402691949641
        End If
        F = 5.4
        xm = (b + a) / 2
        C = xm - a
        d = xm
        S = 0
        For i = points To 1 Step -1
            y = C * null2(i) / F + d
            S1 = gew2(i) * CalcF(y)
            '   Debug.Print i, y, x * y, s1
            S = S + S1
        Next i
        S = C * S / F
        sneu = 0
        C = b - xm
        d = xm
        For i = points To 1 Step -1
            y = -C * null2(i) / F + d
            S1 = gew2(i) * CalcF(y)
            '   Debug.Print i, y, x * y, s1
            sneu = sneu + S1
        Next i
        sneu = C * sneu / F
        studdis1 = S + sneu
    End Function

    Private Function studdis2(a As Double, xm As Double, b As Double) As Double
        Const points = 20
        Static null0(0 To points) As Double, gew0(0 To points) As Double
        Dim y As Double, S1 As Double, S As Double, i As Integer

        If null0(1) = 0 Then
            null0(1) = 0.0567047754527055
            null0(2) = 0.299010898586989
            null0(3) = 0.735909555435016
            null0(4) = 1.36918311603519
            null0(5) = 2.20132605372147
            null0(6) = 3.23567580355804
            null0(7) = 4.47649661507383
            null0(8) = 5.92908376270045
            null0(9) = 7.59989930995675
            null0(10) = 9.49674922093243
            null0(11) = 11.6290149117788
            null0(12) = 14.0079579765451
            null0(13) = 16.6471255972888
            null0(14) = 19.5628980114691
            null0(15) = 22.775241986835
            null0(16) = 26.3087723909689
            null0(17) = 30.1942911633161
            null0(18) = 34.471097571922
            null0(19) = 39.1906088039374
            null0(20) = 44.422349336162

            gew0(1) = 0.145549737845463
            gew0(2) = 0.33934977178631
            gew0(3) = 0.534736592221058
            gew0(4) = 0.732224872375163
            gew0(5) = 0.932615901494606
            gew0(6) = 1.1367925903897
            gew0(7) = 1.34572933788286
            gew0(8) = 1.56051904645081
            gew0(9) = 1.78240922631583
            gew0(10) = 2.01284914982045
            gew0(11) = 2.25355250263736
            gew0(12) = 2.50658251263117
            gew0(13) = 2.77447044296858
            gew0(14) = 3.06038486968816
            gew0(15) = 3.36838056665888
            gew0(16) = 3.70377658323782
            gew0(17) = 4.07375278882884
            gew0(18) = 4.48833451696969
            gew0(19) = 4.96210931402317
            gew0(20) = 5.51743186577412
        End If
        S = 0
        'Debug.Print "Show Sum Short"
        For i = points To 1 Step -1
            y = a + b * (null0(i)) / 45
            S1 = gew0(i) * CalcF(y)
            '   Debug.Print i, y, x * y, s1
            S = S + S1
        Next i
        S = b * S / 45
        studdis2 = S
    End Function


    Private Function studdis(X As Double) As Double
        Dim xm As Double, a As Double, b As Double
        Dim NewMaxValue As Double, NewMaxPos As Double, Ratio As Double,
            LastMaxPos As Double, i As Integer, kl As Integer, kR As Integer,
            XPos(0 To 100) As Double, xvalue(0 To 100) As Double,
            deriv(0 To 100) As Double, C1 As Integer, NewLPos As Double, NewLValue As Double
        Dim Lr As Integer, MaxCount As Integer, LeftX As Integer, MidX As Integer, RightX As Integer
        If n = 1 Then n = 1.000001
        N1 = n - 1
        N2 = n / 2
        gamman2 = LnGamma(N2) + (N2 - 1) * Math.Log(2) - N2 * Math.Log(n)
        If n > 14 Then Ratio = Math.Log(0.00000001) Else Ratio = Math.Log(0.000000001)
        '  Debug.Print "ratio:", ratio
        a = 0.6
        b = 1.5
        xm = a + (b - a) / 2
        If n = 1 Then n = 1.000001
        If n = 1 Then
            a = 0#
            xm = 0#
        End If
        'Debug.Print "a:", a, "b:", b, "xm:", xm
        LeftX = 49 : MidX = 50 : RightX = 51
        XPos(LeftX) = a : XPos(RightX) = b : XPos(MidX) = xm
        For i = LeftX To RightX
            xvalue(i) = CalcLnF(XPos(i))
            '  Debug.Print i, XValue(i)
        Next i
        If n = 1 Then
            NewMaxValue = xvalue(MidX)
            GoTo GetRightBorder
        End If
        While (xvalue(RightX) > xvalue(MidX))
            RightX = RightX + 1
            XPos(RightX) = XPos(RightX - 1) * 1.5
            xvalue(RightX) = CalcLnF(XPos(RightX))
            MidX = MidX + 1
        End While
        While (xvalue(LeftX) > xvalue(MidX))
            LeftX = LeftX - 1
            XPos(LeftX) = XPos(LeftX + 1) / 10
            xvalue(LeftX) = CalcLnF(XPos(LeftX))
            '  Debug.Print XPos(LeftX), XValue(LeftX)
            MidX = MidX - 1
        End While
        LeftX = MidX - 1
        RightX = MidX + 1

        Call NewtonInter(LeftX, RightX - LeftX + 1, XPos, xvalue, deriv)
        'For i = LeftX To RightX: Debug.Print XPos(i), XValue(i), Deriv(i): Next i
        MaxCount = 0
        Do
            MaxCount = MaxCount + 1
            For i = LeftX To RightX
                If xvalue(i) > xvalue(MidX) Then MidX = i
            Next i
            LastMaxPos = XPos(MidX)
            kl = MidX : kR = kl
            While ((kR < RightX) And (kR < MidX + 5) And (deriv(kR + 1) < deriv(kR))) : kR = kR + 1 : End While
            While ((kl > LeftX) And (kl > MidX - 5) And (deriv(kl - 1) > deriv(kl))) : kl = kl - 1 : End While
            '    Debug.Print "MidX, kL, kR"
            '    Debug.Print MidX, kL, kR
            If ((MidX = kl) Or (MidX = kR)) Then
                '      Debug.Print "!!!!Ableitungen nicht korrekt"
                If Math.Abs(xvalue(MidX - 1) - xvalue(MidX)) > Math.Abs(xvalue(MidX + 1) - xvalue(MidX)) _
                  Then C1 = -1 Else C1 = 1
                NewMaxPos = (XPos(MidX) + XPos(MidX + C1)) / 2
            Else
                If deriv(MidX) < 0 Then C1 = -1 Else C1 = 1
                C1 = -(kR + kl) + 2 * MidX + C1
                If Math.Abs(C1) >= 2 Then
                    '        Debug.Print "!!!Symmetrie: Adjustment"
                    If C1 < 0 Then C1 = -1 Else C1 = 1
                    NewMaxPos = (XPos(MidX) + XPos(MidX + C1)) / 2
                Else
                    NewMaxPos = interpolate(True, 0, kl, kR - kl, deriv, XPos)
                    If NewMaxPos <= XPos(MidX - 1) Then
                        NewMaxPos = (XPos(MidX) + XPos(MidX - 1)) / 2
                        '          Debug.Print "Halbierung: Interpolation zu ungenau"
                    Else
                        If NewMaxPos >= XPos(MidX + 1) Then
                            NewMaxPos = (XPos(MidX) + XPos(MidX + 1)) / 2
                            '            Debug.Print "Halbierung: Interpolation zu ungenau"
                        Else
                            '            Debug.Print "Interpolation"
                        End If
                    End If
                End If
            End If

            NewMaxValue = CalcLnF(NewMaxPos)
            i = RightX
            While XPos(i) > NewMaxPos
                XPos(i + 1) = XPos(i) : xvalue(i + 1) = xvalue(i) : i = i - 1
            End While
            RightX = RightX + 1 : kR = kR + 1 : XPos(i + 1) = NewMaxPos : xvalue(i + 1) = NewMaxValue
            NewMaxValue = xvalue(LeftX)
            For i = LeftX + 1 To RightX
                deriv(i) = 0
                If xvalue(i) > NewMaxValue Then
                    NewMaxValue = xvalue(i)
                    MidX = i
                End If
            Next i
            Call NewtonInter(LeftX, RightX - LeftX + 1, XPos, xvalue, deriv)
            '    Debug.Print "Iteration: ", MaxCount
            '    For i = LeftX To RightX
            '      Debug.Print i, XPos(i), XValue(i), Deriv(i)
            '    Next i
            '    Debug.Print "MidX:", MidX, "Deriv(MidX):", Deriv(MidX)

        Loop Until ((Math.Abs(deriv(MidX)) < 0.00001) Or (MaxCount = 20))
        xm = XPos(MidX)

        '    Debug.Print "Iteration: ", MaxCount
        '    For i = LeftX To RightX
        '      Debug.Print i, XPos(i), XValue(i), Deriv(i)
        '    Next i
        '    Debug.Print "MidX:", MidX, "Deriv(MidX):", Deriv(MidX)

        NewMaxValue = -Math.Exp(-NewMaxValue) + Ratio
        NewMaxValue = -Math.Log(-NewMaxValue)

        If ((n < 6) And (n > 1)) Then
            a = 10 ^ (n - 10)
            GoTo GetRightBorder
        End If
        'Debug.Print "LeftBorder, NewMaxValue:", NewMaxValue
        MaxCount = 0
        While (xvalue(LeftX)) > NewMaxValue
            LeftX = LeftX - 1
            XPos(LeftX) = XPos(LeftX + 1) / 6
            xvalue(LeftX) = CalcLnF(XPos(LeftX))
            '  Debug.Print XPos(LeftX), XValue(LeftX)
        End While
        'LR: rechte grenze der besten schätzung für Leftborder
        Lr = LeftX + 1
        While ((Lr < MidX) And (xvalue(Lr) < NewMaxValue))
            Lr = Lr + 1
        End While

        Do
            MaxCount = MaxCount + 1
            If ((Lr = MidX) And (Lr - 1 = LeftX)) Then
                NewLPos = (XPos(Lr) + XPos(Lr - 1)) / 2
                '    Debug.Print "Halbierung: nur 2 stützpunkte"
            Else
                NewLPos = interpolate(True, NewMaxValue, LeftX, MidX - LeftX, xvalue, XPos)
                If ((NewLPos < XPos(Lr - 1)) Or (NewLPos > XPos(Lr))) Then
                    NewLPos = (XPos(Lr - 1) + XPos(Lr)) / 2
                    'Debug.Print "Halbierung: Interpolation zu ungenau"
                Else
                    '      Debug.Print "Interpolation"
                End If
            End If
            NewLValue = CalcLnF(NewLPos)
            If NewLValue > NewMaxValue Then Lr = Lr - 1
            '  Debug.Print NewLPos, NewLValue
            i = LeftX
            While XPos(i) < NewLPos
                XPos(i - 1) = XPos(i) : xvalue(i - 1) = xvalue(i) : i = i + 1
            End While
            LeftX = LeftX - 1
            XPos(i - 1) = NewLPos : xvalue(i - 1) = NewLValue
        Loop Until Math.Abs(NewMaxValue - NewLValue) < 0.0000001
        '  Debug.Print "Iteration: ", MaxCount
        '  Debug.Print "LeftX, MidX, LR, RightX", LeftX, MidX, LR, RightX
        '  For i = MidX To LeftX Step -1
        '    Debug.Print XPos(i), XValue(i)
        '  Next i

        a = NewLPos

GetRightBorder:
        NewMaxValue = -Math.Exp(-NewMaxValue) + Ratio
        NewMaxValue = -Math.Log(-NewMaxValue)

        'Debug.Print "RightBorder"
        MaxCount = 0
        While (xvalue(RightX)) > NewMaxValue
            RightX = RightX + 1
            XPos(RightX) = XPos(RightX - 1) * 2
            xvalue(RightX) = CalcLnF(XPos(RightX))
            '    Debug.Print XPos(RightX), XValue(RightX)
        End While
        'LR: linke grenze der besten schätzung für rightborder
        Lr = RightX - 1
        While ((Lr > MidX) And (xvalue(Lr) < NewMaxValue))
            Lr = Lr - 1
        End While

        Do
            MaxCount = MaxCount + 1
            If ((Lr = MidX) And (Lr + 1 = RightX)) Then
                NewLPos = (XPos(Lr) + XPos(Lr + 1)) / 2
                '    Debug.Print "Halbierung: nur 2 stützpunkte"
            Else
                NewLPos = interpolate(True, NewMaxValue, MidX, RightX - MidX, xvalue, XPos)
                If ((NewLPos < XPos(Lr)) Or (NewLPos > XPos(Lr + 1))) Then
                    NewLPos = (XPos(Lr) + XPos(Lr + 1)) / 2
                    '      Debug.Print "Halbierung: Interpolation zu ungenau"
                Else
                    '      Debug.Print "Interpolation"
                End If
            End If
            NewLValue = CalcLnF(NewLPos)
            If NewLValue > NewMaxValue Then Lr = Lr + 1
            'Debug.Print NewLPos, NewLValue
            i = RightX
            While XPos(i) > NewLPos
                XPos(i + 1) = XPos(i) : xvalue(i + 1) = xvalue(i) : i = i - 1
            End While
            RightX = RightX + 1
            XPos(i + 1) = NewLPos : xvalue(i + 1) = NewLValue
        Loop Until (Math.Abs(NewMaxValue - NewLValue) < 0.0000001)
        '  Debug.Print "Iteration: ", MaxCount
        '  Debug.Print "LeftX, MidX, LR, RightX", LeftX, MidX, LR, RightX
        '  For i = MidX To RightX
        '    Debug.Print XPos(i), XValue(i)
        '  Next i

        b = NewLPos
        'Debug.Print "a, xm, b"
        'Debug.Print a, xm, b
        If n > 14 Then studdis = studdis1(a, xm, b) Else studdis = studdis2(a, xm, b)
    End Function

    Public Sub MCPdis3(dis_1 As Integer, k_1 As Integer,
n_1 As Double, x_1 As Double,
      ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim i As Integer
        dis = dis_1 : k = k_1 : n = n_1 : X = x_1
        For i = 0 To k
            L(i) = 1
            mu(i) = 0
        Next i
        ShowSum = True
        ShowRange = True
        ShowBorder = True
        If ((dis = 1) Or (dis = 2)) Then X = X * Math.Sqrt(2)
        If dis = 2 Then
            dis = 1 : IsDuncan = True
        Else
            IsDuncan = False
        End If
        If ((n > 0) And (n < 1)) Then n = 1
        If ((n > 1000000.0#) Or (n <= 0#)) Then S = Q(X) Else S = studdis(X)
        RightTail = S
        LeftTail = 1 - RightTail
        If IsDuncan Then
            LeftTail = Math.Exp(Math.Log(LeftTail) / k) '  (*Duncan*)
            RightTail = 1 - LeftTail
        End If
    End Sub

    Sub DemoMCP3()
        Console.WriteLine("")
        Console.WriteLine("Hello DemoMCP3!")
        Dim i As Integer, k As Integer, LeftTail As Double, RightTail As Double
        Dim X As Double, n As Double, mu(0 To 100) As Double ', l1 As Double, r1 As Double
        k = 1
        n = 14.0#
        X = 4.1
        For i = 0 To k
            mu(i) = 0
        Next i
        mu(1) = 0
        Call MCPdis3(4, k, n, X, LeftTail, RightTail)
        Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail)
        'LeftTail = tdisn(n, x, mu(1)): RightTail = tdisn(n, -x, mu(1))
        'Debug.Print LeftTail, RightTail, LeftTail - RightTail
        RightTail = Fdisn(1, n, X * X, mu(1) * mu(1)) : LeftTail = 1 - RightTail
        Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail)
        '  Call Logndis2(x - mu(1), LeftTail, RightTail)
        '  Debug.Print LeftTail, RightTail, x - mu(1)
    End Sub


    Private Function ManyOneDisX2(MCP As Integer, LeftTail As Double, RightTail As Double,
      Proc As Integer, m As Integer, n As Double) As Double
        Dim temp, L, r As Double
        Select Case Proc
            Case 0
                Return Tdisx(LeftTail, RightTail, n)
            Case 1
                temp = Fdisx(LeftTail, RightTail, 1, n)
                Return Math.Sqrt(temp)
            Case 2
                Return Dunnett1disx(LeftTail, RightTail, m, n)
            Case 3
                Return Dunnett2disx(LeftTail, RightTail, m, n)
            Case 4
                r = RightTail / m
                L = 1 - r
                Return Tdisx(L, r, n)
            Case 5
                r = RightTail / m
                L = 1 - r
                temp = Fdisx(L, r, 1, n)
                Return Math.Sqrt(temp)
            Case Else
                Console.WriteLine("Außerhalb")
                Return 0
        End Select
    End Function

    Private Function MCPDisX3(dis As Integer, m As Integer, n As Double, LeftTail2 As Double,
      RightTail2 As Double) As Double
        Dim sg As Double, S As Double, x1 As Double, fx1 As Double
        Dim p1 As Double, x2 As Double, fx2 As Double
        Dim fx3 As Double, x3 As Double, delta As Double
        Dim LeftTail As Double, RightTail As Double
        Dim show As Boolean
        Dim sg2 As Double
        show = True
        S = LeftTail2 : sg2 = RightTail2 : sg = S
        Select Case dis
            Case 1, 2
                S = 1 - (1 - S) / 2
                p1 = Math.Exp(Math.Log(S) / ((m + 1) * m / 2))
                If dis = 2 Then p1 = Math.Exp(Math.Log(p1) * (m - 1))
            Case 3, 4, 5, 6
                If ((dis = 4) Or (dis = 6)) Then S = 1 - (1 - S) / 2
                p1 = Math.Exp(Math.Log(S) / m)
        End Select
        x1 = Tdisx(p1, 1 - p1, n)
        If m = 1 Then
            MCPDisX3 = x1
            Exit Function
        End If
        Call MCPdis3(dis, m, n, x1, LeftTail, RightTail)
        fx1 = RightTail
        '  If show Then Debug.Print x1, fx1
        x2 = 0.95 * x1
        Call MCPdis3(dis, m, n, x2, LeftTail, RightTail)
        fx2 = RightTail
        '  If show Then Debug.Print x2, fx2
        Do
            x3 = x1 - ((x2 - x1) / (fx2 - fx1)) * (fx1 - sg2)
            Call MCPdis3(dis, m, n, x3, LeftTail, RightTail)
            fx3 = RightTail
            delta = Math.Abs(fx3 - sg2) / sg2
            x1 = x2 : x2 = x3 : fx1 = fx2 : fx2 = fx3
            '    If show Then Debug.Print x3, fx3, delta
        Loop Until delta < 0.000000000001
        MCPDisX3 = x3
    End Function

    Function SRdis(m As Integer, n As Double,
X As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Call MCPdis3(1, m, n, X, LeftTail, RightTail)
        SRdis = LeftTail
    End Function

    Function Duncandis(m As Integer, n As Double,
X As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Call MCPdis3(2, m, n, X, LeftTail, RightTail)
        Duncandis = LeftTail
    End Function

    Function SMM1dis(m As Integer, n As Double,
X As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Call MCPdis3(3, m, n, X, LeftTail, RightTail)
        SMM1dis = LeftTail
    End Function

    Function SMM2dis(m As Integer, n As Double,
X As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Call MCPdis3(4, m, n, X, LeftTail, RightTail)
        SMM2dis = LeftTail
    End Function

    Function Dunnett1dis(m As Integer, n As Double,
X As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Call MCPdis3(5, m, n, X, LeftTail, RightTail)
        Dunnett1dis = LeftTail
    End Function

    Function Dunnett2dis(m As Integer, n As Double,
X As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Call MCPdis3(6, m, n, X, LeftTail, RightTail)
        Dunnett2dis = LeftTail
    End Function

    Function SRdisx(LeftTail As Double, RightTail As Double,
m As Integer, n As Double) As Double
        SRdisx = MCPDisX3(1, m, n, LeftTail, RightTail)
    End Function

    Function Duncandisx(LeftTail As Double, RightTail As Double,
m As Integer, n As Double) As Double
        Duncandisx = MCPDisX3(2, m, n, LeftTail, RightTail)
    End Function

    Function SMM1disx(LeftTail As Double, RightTail As Double,
m As Integer, n As Double) As Double
        SMM1disx = MCPDisX3(3, m, n, LeftTail, RightTail)
    End Function

    Function SMM2disx(LeftTail As Double, RightTail As Double,
m As Integer, n As Double) As Double
        SMM2disx = MCPDisX3(4, m, n, LeftTail, RightTail)
    End Function

    Function Dunnett1disx(LeftTail As Double, RightTail As Double,
m As Integer, n As Double) As Double
        Dunnett1disx = MCPDisX3(5, m, n, LeftTail, RightTail)
    End Function

    Function Dunnett2disx(LeftTail As Double, RightTail As Double,
m As Integer, n As Double) As Double
        Dunnett2disx = MCPDisX3(6, m, n, LeftTail, RightTail)
    End Function

    Public Sub demoMCP2()
        Dim m As Integer, n As Double, LeftTail As Double, RightTail As Double, result As Double, d As Double
        m = 3 ' number of groups - 1
        n = 14
        d = 0
        X = 3.1

        result = Dunnett1dis(m, n, X, LeftTail, RightTail)
        Console.WriteLine("result: {0}", result)
        result = tdisn(n, X, d, LeftTail, RightTail)
        Console.WriteLine("result:  {0}", result)

        'result = Dunnett2dis(m, n, X, LeftTail, RightTail)
        'Console.WriteLine("result: {0}", result)
        'result = tdisn(n, X, d, LeftTail, RightTail) - tdisn(n, -X, d, LeftTail, RightTail)
        'Console.WriteLine("result:  {0}", result)

        'result = SRdis(m, n, X, LeftTail, RightTail)
        'Console.WriteLine("result: {0}", result)
        'result = tdisn(n, X / Math.Sqrt(2), d, LeftTail, RightTail) - tdisn(n, -X / Math.Sqrt(2), d, LeftTail, RightTail)
        'Console.WriteLine("result:  {0}", result)
        'result = result ^ (m * (m + 1) / 2)
        'Console.WriteLine("result:  {0}", result)

    End Sub



End Module
