Imports System
Imports System.Numerics
Imports System.Diagnostics
'Imports mpFunLabNET



Module DistMCP



    Const NegMax = -1.79769313486231E+308
    Const sqrt2pi = 0.398942280401433
    Private Lastvalue As Double, X As Double, k As Integer, lmax As Integer,
      mu(0 To 100) As Double, lambda(0 To 100) As Double, L(0 To 100) As Integer,
      ShowRange As Boolean, twosided As Boolean, UseRightTail As Boolean, range As Boolean
    Private ShowSums As Boolean, ShowBorders As Boolean




    Function interpolate(UseRational As Boolean, X As Double, start As Integer, n As Integer, xt() As Double, t0() As Double) As Double
        Dim t(0 To 20, 0 To 20) As Double, x0(0 To 20) As Double
        Dim i As Integer, k As Integer
        Dim d As Double, o As Double, U As Double, RelError As Double, result2 As Double
        'Dim UseRational As Boolean
        '  UseRational = False
        k = 0
        For i = 0 To n
            t(i, 0) = t0(i + start)
            x0(i) = xt(i + start)
            '    Debug.Print i, k, t(i, k), x0(i)
        Next i
        '  For i = 0 To n
        '    If Abs((x0(i) - x) / x) < 0.00000000000001 Then
        '      Debug.Print "Replace", i, x0(i), x
        '      interpolate = t(i, 0)
        '      Exit Function
        '    End If
        '  Next i

        '  Debug.Print "-------------"
        result2 = t0(0) : RelError = 1 : k = 0
        While ((k < n) And (RelError > 0.0000000000000001))
            k = k + 1
            For i = k To n
                o = t(i, k - 1) - t(i - 1, k - 1)
                U = t(i, k - 1)
                If k > 1 Then U = U - t(i - 1, k - 2)
                If (UseRational And (U <> 0)) Then d = o / U Else d = 0
                U = ((X - x0(i - k)) / (X - x0(i))) * (1 - d) - 1
                t(i, k) = t(i, k - 1) + o / U
                '      Debug.Print i, k, T(i, k)
            Next i
            RelError = Math.Abs((result2 - t(n, k)) / t(n, k))
            '    Debug.Print "RelError: ", RelError
            result2 = t(n, k)
        End While
        '  Debug.Print "RelError: ", RelError
        interpolate = result2
    End Function

    Sub NewtonInter(start As Integer, n As Integer,
       xt() As Double, yt() As Double, deriv() As Double)
        Dim a(0 To 100) As Double, b(0 To 100) As Double
        Dim X(0 To 100) As Double, y(0 To 100) As Double
        Dim i As Integer, j As Integer, k As Integer
        Dim y2 As Double
        For i = 1 To n
            X(i) = xt(i + start - 1)
            y(i) = yt(i + start - 1)
        Next i
        a(1) = y(1)
        For j = 1 To n - 1
            For i = 1 To n - j
                y(i) = (y(i + 1) - y(i)) / (X(i + j) - X(i))
            Next i
            a(j + 1) = y(1)
        Next j
        b(n) = a(n)
        For k = n - 1 To 1 Step -1
            For j = n - 1 To 1 Step -1
                b(j) = a(j)
            Next j
            For i = n - 1 To k Step -1
                a(i) = a(i) - b(i + 1) * X(k)
            Next i
        Next k
        For j = 1 To n
            '    y1 = a(n)
            '    For i = n - 1 To 1 Step -1
            '      y1 = y1 * x(j) + a(i)
            '    Next i
            y2 = (n - 1) * a(n)
            For i = n - 1 To 2 Step -1
                y2 = y2 * X(j) + (i - 1) * a(i)
            Next i
            deriv(j + start - 1) = y2
            '    Debug.Print x(j), y1, y(j)
            '    Debug.Print x(j), y(j)
        Next j
    End Sub


    Private Function Hoch(RightTail As Double, k As Double) As Double
        Dim z As Double, z2 As Double, z3 As Double, sum As Double, i As Double

        If RightTail >= 1 Then
            Hoch = 1
            Exit Function
        End If
        If RightTail > 0.01 Then
            Hoch = 1 - Math.Exp(Math.Log(1 - RightTail) * k)
            Exit Function
        End If
        z2 = RightTail
        z3 = z2
        z = -RightTail
        sum = z
        i = 1
        Do
            i = i + 1
            z2 = z2 * z3
            sum = sum - z2 / i
        Loop Until sum = sum + z2 / i
        sum = sum * k
        z = sum
        z2 = z
        i = 1
        Do
            i = i + 1
            z2 = z2 * z / i
            sum = sum + z2
        Loop Until sum = sum + z2
        Hoch = -sum
    End Function

    Private Function LogHoch(UseLog As Boolean, ReturnLog As Boolean,
y As Double, k As Double) As Double
        Dim z As Double, z2 As Double, z3 As Double, sum As Double, i As Double
        Dim RightTail As Double
        If k = 1 Then
            If UseLog And Not (ReturnLog) Then
                LogHoch = Math.Exp(y)
            Else
                If (Not (UseLog) And ReturnLog) Then
                    LogHoch = Math.Log(y)
                Else
                    LogHoch = y
                End If
            End If
            Exit Function
        End If
        RightTail = y
        If UseLog Then
            If RightTail < -50 Then
                z = RightTail + Math.Log(k)
                If ReturnLog Then LogHoch = z Else LogHoch = Math.Exp(z)
                Exit Function
            Else
                RightTail = Math.Exp(y)
            End If
        End If
        If 1 - RightTail <= 0 Then
            If ReturnLog Then LogHoch = 0 Else LogHoch = 1
            Exit Function
        End If
        If RightTail > 0.1 Then
            z = (1 - Math.Exp(Math.Log(1 - RightTail) * k))
            If ReturnLog Then LogHoch = Math.Log(z) Else LogHoch = z
            Exit Function
        End If
        z2 = RightTail
        z3 = z2
        z = -RightTail
        sum = z
        i = 1
        Do
            i = i + 1
            z2 = z2 * z3
            sum = sum - z2 / i
        Loop Until sum = sum + z2 / i
        sum = sum * k
        z = sum
        z2 = z
        i = 1
        Do
            i = i + 1
            z2 = z2 * z / i
            sum = sum + z2
        Loop Until sum = sum + z2
        If ReturnLog Then LogHoch = Math.Log(-sum) Else LogHoch = -sum
    End Function

    Private Function CalcFRange3(ReturnLog As Boolean, X As Double, y As Double) As Double
        Dim l1 As Double, r1 As Double, l2 As Double, r2 As Double ', F As Double
        Dim LogZ As Double, Logf As Double, d1 As Double
        Dim LocalUseLog As Boolean ', UseLeftTail As Boolean
        Dim Q1 As Double, q2 As Double
        LocalUseLog = True
        '  If y < 0 Then UseLeftTail = True Else UseLeftTail = False
        Call ndis2(LocalUseLog, y, l1, r1, d1)
        Call ndis2(LocalUseLog, y - X, l2, r2, d1)
        LogZ = (-y * y / 2) + Math.Log((k + 1) * sqrt2pi)
        '    If UseLeftTail Then LogDiff = Log(LeftTail1 - LeftTail2) _
        '    Else: LogDiff = Log(RightTail2 - RightTail1)
        If LocalUseLog Then Q1 = l1 * k Else Q1 = Math.Log(l1) * k
        If LocalUseLog Then q2 = (l2 - l1) Else q2 = l2 / l1
        q2 = LogHoch(LocalUseLog, True, q2, k)
        Logf = (LogZ + Q1 + q2)
        '  Logf = Logz + LogDiff * k
        If ReturnLog Then CalcFRange3 = Logf Else CalcFRange3 = Math.Exp(Logf)
    End Function

    Private Function AddLogs(X As Double, y As Double,
a As Double, b As Double) As Double
        ' Calculates ln(exp(x) + a * exp(y-x) - b* exp(y))
        Dim S As Double, t As Double
        If X < y Then Call DistMain.SwapTails(X, y)
        t = a * Math.Exp(y - X)
        If b <> 0 Then t = t - b * Math.Exp(y)
        S = LogZPlusA(t, 1)
        AddLogs = X + S
    End Function

    Private Function CalcFNMult(ReturnLog As Boolean, X As Double, y As Double) As Double
        Dim lefttail1 As Double, RightTail1 As Double,
            LeftTail2 As Double, RightTail2 As Double, d1 As Double,
            fR As Double, F As Double,
            i As Integer
        Dim z As Double, result As Double, C As Double, d As Double
        Dim LocalUseLog As Boolean, LogZ As Double
        LocalUseLog = True
        z = Math.Exp(-y * y / 2) * sqrt2pi
        LogZ = (-y * y / 2) + Math.Log(sqrt2pi)
        F = 1 : fR = 0
        For i = 1 To lmax
            C = mu(i) + lambda(i) * y
            d = Math.Sqrt(1 - lambda(i) * lambda(i))
            Call ndis2(LocalUseLog, (X - C) / d, lefttail1, RightTail1, d1)
            If twosided Then
                Call ndis2(LocalUseLog, (-X - C) / d, LeftTail2, RightTail2, d1)
                '      LeftTail1 = LeftTail1 - LeftTail2
                '      Debug.Print "log R1,R2,L1,L2:", RightTail1, RightTail2, LeftTail1, LeftTail2
                If LocalUseLog Then RightTail1 = AddLogs(RightTail1, LeftTail2, 1, 0) _
                  Else RightTail1 = RightTail1 + LeftTail2
            End If
            If LocalUseLog Then fR = LogHoch(LocalUseLog, True, RightTail1, L(i)) _
              Else fR = Hoch(RightTail1, L(i))
            '    For j = 1 To l(i)
            '      f = f * LeftTail1
            '      fR = fR + RightTail1 - (fR * RightTail1)
            '    Next j
        Next i
        '  If UseRightTail Then
        '    Debug.Print "Use Righttail"
        If ReturnLog Then result = LogZ + fR Else result = Math.Exp(LogZ + fR)
        '  Else
        '    Result = f * z
        '  End If
        CalcFNMult = result
        '  Debug.Print "x, Result:", x, Result
    End Function

    Private Function CalcFRange(X As Double, y As Double) As Double
        Dim lefttail1 As Double, RightTail1 As Double,
            LeftTail2 As Double, RightTail2 As Double, d1 As Double,
            sum As Double, S1 As Double, s2 As Double, prod As Double,
            j1 As Integer, m As Integer, i As Integer, j As Integer
        sum = 0
        For i = 0 To lmax
            S1 = Math.Exp(-(y - mu(i)) * (y - mu(i)) / 2) * sqrt2pi
            prod = 1
            For j = 0 To lmax
                If Not ((i = j) And (L(i) = 1)) Then
                    Call ndis2(False, y - mu(j), lefttail1, RightTail1, d1)
                    Call ndis2(False, y - mu(j) - X, LeftTail2, RightTail2, d1)
                    s2 = lefttail1 - LeftTail2
                    If i = j Then m = L(j) - 1 Else m = L(j)
                    For j1 = 1 To m
                        prod = prod * s2
                    Next j1
                End If
            Next j
            sum = sum + S1 * prod * L(i)
        Next i
        CalcFRange = sum
    End Function

    Private Function CalcF2(y As Double) As Double
        If range Then CalcF2 = CalcFRange3(False, X, y) Else CalcF2 = CalcFNMult(False, X, y)
    End Function

    Private Function CalcLnF2(y As Double) As Double
        If range Then CalcLnF2 = CalcFRange3(True, X, y) Else CalcLnF2 = CalcFNMult(True, X, y)
    End Function

    Private Function studdis12(a As Double, xm As Double, b As Double) As Double
        Const points = 10
        Static null4(0 To points) As Double, gew4(0 To points) As Double
        Dim sneu As Double, y As Double, F As Double, S1 As Double
        Dim C As Double, d As Double, S As Double, i As Integer
        If null4(1) = 0 Then
            null4(1) = 0.245340708300901
            null4(2) = 0.737473728545394
            null4(3) = 1.23407621539532
            null4(4) = 1.73853771211659
            null4(5) = 2.25497400208928
            null4(6) = 2.78880605842813
            null4(7) = 3.34785456738322
            null4(8) = 3.94476404011563
            null4(9) = 4.60368244955074
            null4(10) = 5.38748089001123
            gew4(1) = 0.490921500666746
            gew4(2) = 0.493843385272053
            gew4(3) = 0.499920871336291
            gew4(4) = 0.509679027117458
            gew4(5) = 0.524080350948558
            gew4(6) = 0.54485174236452
            gew4(7) = 0.575262442852503
            gew4(8) = 0.622278696191412
            gew4(9) = 0.704332961176942
            gew4(10) = 0.898591961453191
        End If
        F = 5.4
        xm = (b + a) / 2
        C = xm - a
        d = xm
        S = 0
        For i = points To 1 Step -1
            y = C * null4(i) / F + d
            S1 = (C * gew4(i) / F) * CalcF2(y)
            '   Debug.Print y, s1
            S = S + S1
        Next i
        sneu = 0
        C = b - xm
        d = xm
        For i = points To 1 Step -1
            y = -C * null4(i) / F + d
            S1 = (C * gew4(i) / F) * CalcF2(y)
            '   Debug.Print y, s1
            sneu = sneu + S1
        Next i
        studdis12 = (S + sneu)
    End Function

    Private Function q2() As Double
        Dim xm As Double, a As Double, b As Double
        Dim NewMaxValue As Double, NewMaxPos As Double, Ratio As Double,
            LastMaxPos As Double, i As Integer, kl As Integer, kR As Integer,
            XPos(0 To 100) As Double, xvalue(0 To 100) As Double,
            deriv(0 To 100) As Double, C1 As Integer, NewLPos As Double, NewLValue As Double
        Dim Lr As Integer, MaxCount, LeftX As Integer, MidX As Integer, RightX As Integer
        Ratio = Math.Log(0.0000000001)
        b = 3.8
        a = -3.5
        xm = a + (b - a) / 2
        'Debug.Print "a:", a, "b:", b
        LeftX = 49 : MidX = 50 : RightX = 51
        XPos(LeftX) = a : XPos(RightX) = b : XPos(MidX) = xm
        For i = LeftX To RightX : xvalue(i) = CalcLnF2(XPos(i)) : Next i
        While (xvalue(RightX) > xvalue(MidX))
            RightX = RightX + 1
            '  XPos(RightX) = XPos(RightX - 1) * 1.5
            XPos(RightX) = XPos(RightX - 1) + Math.Abs(XPos(RightX - 1) - XPos(RightX - 2)) * 2
            xvalue(RightX) = CalcLnF2(XPos(RightX))
            MidX = MidX + 1
        End While
        While (xvalue(LeftX) > xvalue(MidX))
            LeftX = LeftX - 1
            XPos(LeftX) = XPos(LeftX + 1) - Math.Abs(XPos(LeftX + 1) - XPos(LeftX + 2)) * 2
            '  XPos(LeftX) = XPos(LeftX + 1) / 10
            xvalue(LeftX) = CalcLnF2(XPos(LeftX))
            '  Debug.Print XPos(LeftX), XValue(LeftX)
            MidX = MidX - 1
        End While
        LeftX = MidX - 1
        RightX = MidX + 1
        '  For i = LeftX To RightX
        '     Debug.Print XPos(i), XValue(i)
        '  Next i
        Call NewtonInter(LeftX, RightX - LeftX + 1, XPos, xvalue, deriv)
        'Debug.Print "Grenzen"
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
                            'Debug.Print "Interpolation"
                        End If
                    End If
                End If
            End If

            NewMaxValue = CalcLnF2(NewMaxPos)
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

        NewMaxValue = NewMaxValue + Ratio
        MaxCount = 0
        While (xvalue(LeftX)) > NewMaxValue
            LeftX = LeftX - 1
            XPos(LeftX) = XPos(LeftX + 1) - Math.Abs(XPos(LeftX + 1) - XPos(LeftX + 2)) * 2
            xvalue(LeftX) = CalcLnF2(XPos(LeftX))
            '  Debug.Print XPos(LeftX), XValue(LeftX)
        End While
        'LR: rechte grenze der besten schätzung für lightborder
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
                '    NewLPos = interpolate(NewMaxValue, MidX, RightX - MidX, XValue(), XPos())
                NewLPos = interpolate(True, NewMaxValue, LeftX, MidX - LeftX, xvalue, XPos)
                If ((NewLPos < XPos(Lr - 1)) Or (NewLPos > XPos(Lr))) Then
                    NewLPos = (XPos(Lr - 1) + XPos(Lr)) / 2
                    '      Debug.Print "Halbierung: Interpolation zu ungenau"
                Else
                    '      Debug.Print "Interpolation"
                End If
            End If
            NewLValue = CalcLnF2(NewLPos)
            If NewLValue > NewMaxValue Then Lr = Lr - 1
            '  Debug.Print NewLPos, NewLValue
            i = LeftX
            While XPos(i) < NewLPos
                XPos(i - 1) = XPos(i) : xvalue(i - 1) = xvalue(i) : i = i + 1
            End While
            LeftX = LeftX - 1
            XPos(i - 1) = NewLPos : xvalue(i - 1) = NewLValue
        Loop Until Math.Abs(NewMaxValue - NewLValue) < 0.0000001
        a = NewLPos

GetRightBorder:
        'Debug.Print -Exp(-NewMaxValue)
        'NewMaxValue = -Exp(-NewMaxValue) + ratio
        'NewMaxValue = -Log(-NewMaxValue)
        'Debug.Print "NewMaxValue: ", NewMaxValue
        'NewMaxValue = NewMaxValue + ratio

        'Debug.Print "RightBorder", NewMaxValue
        MaxCount = 0
        While (xvalue(RightX)) > NewMaxValue
            RightX = RightX + 1
            '    XPos(RightX) = XPos(RightX - 1) * 2
            XPos(RightX) = XPos(RightX - 1) + Math.Abs(XPos(RightX - 1) - XPos(RightX - 2)) * 2
            xvalue(RightX) = CalcLnF2(XPos(RightX))
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
            NewLValue = CalcLnF2(NewLPos)
            If NewLValue > NewMaxValue Then Lr = Lr + 1
            '  Debug.Print NewLPos, NewLValue
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

        'a = -b
        'xm = 0
        'Debug.Print "a, xm, b"
        'Debug.Print a, xm, b
        '
        q2 = studdis12(a, xm, b)
    End Function

    Private Sub MCP2(range1 As Boolean, Twosided1 As Boolean, x1 As Double,
      k1 As Integer, lmax1 As Integer, ByRef LeftTail As Double, ByRef RightTail As Double,
                      lambda1() As Double, mu1 As Double(), l1 As Integer())
        ' x :  Stelle, an der die Funktion ausgewertet wird
        ' k :  Zahl der Blöcke mit unterschiedlichen Umfängen/Mittelwerten,
        '      außer Block 0 = Standard  (NMult)
        ' k :  Zahl der Gruppen - 1 (Range)
        ' lambda :  Zerlegung sodaß rho_ij = lambda_i*lambda_j
        ' mu :  Mittelwerte der Blöcke
        ' l :  Zahl der Gruppen in Block l(i)
        '  Der Nichtzentralitätsparameter hat folgende Struktur as
        '  mu(0) wird immer gleich 0 gesetzt
        '  mu(i) (i>0) enthält die Differenz von mu(i) zu mu(0)
        Dim i As Integer
        range = range1 : twosided = Twosided1 : X = x1 : k = k1 : lmax = lmax1
        For i = 0 To lmax
            mu(i) = mu1(i)
            lambda(i) = lambda1(i)
            L(i) = l1(i)
        Next i
        ShowSums = False
        ShowBorders = False
        ShowRange = False
        UseRightTail = True
        If UseRightTail Then
            RightTail = q2()
            LeftTail = 1 - RightTail
        Else
            LeftTail = q2()
            RightTail = 1 - LeftTail
        End If
    End Sub

    Private Sub NMultDis(twosided As Boolean, X As Double, k As Integer, lmax As Integer,
                      ByRef LeftTail As Double, ByRef RightTail As Double,
                      lambda As Double(), mu As Double(), L As Integer())
        Call MCP2(False, twosided, X, k, lmax, LeftTail, RightTail, lambda, mu, L)
    End Sub

    Public Sub NormalRangeDis(X As Double, k As Integer,
                       ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim mu(0 To 100) As Double, lambda(0 To 100) As Double, L(0 To 100) As Integer
        Dim i As Integer
        For i = 0 To lmax
            mu(i) = 0
            lambda(i) = 1
            L(i) = 1
        Next i
        Call MCP2(True, True, X, k, 1, LeftTail, RightTail, lambda, mu, L)
    End Sub

    Private Sub NormalRangeDisN(X As Double, k As Integer, lmax As Integer,
           mu() As Double, L() As Integer, LeftTail As Double, RightTail As Double)
        Dim lambda(0 To 100) As Double
        Dim i As Integer
        For i = 0 To lmax
            lambda(i) = 1 / Math.Sqrt(2)
        Next i
        Call MCP2(True, True, X, k, lmax, LeftTail, RightTail, lambda, mu, L)
    End Sub

    Private Sub ManyOneDis22(twosided As Boolean, X As Double, k As Integer, lmax As Integer,
                      n() As Double, mu() As Double, L() As Integer,
                      LeftTail As Double, RightTail As Double)
        ' x : Stelle, an der die Funktion ausgewertet wird
        ' k :  Zahl der Blöcke mit unterschiedlichen Umfängen/Mittelwerten,
        '    außer Block 0 = Standard
        ' n :  Stichprobenumfänge der Blöcke
        ' mu :  Mittelwerte der Blöcke
        ' l :  Zahl der Gruppen in Block l(i)

        Dim i As Integer, lambda(0 To 100) As Double
        For i = 1 To k
            lambda(i) = 1.0 / Math.Sqrt(1 + n(0) / n(i))
        Next i
        Call NMultDis(twosided, X, k, lmax, LeftTail, RightTail, lambda, mu, L)
    End Sub

    '
    'Sub NMultEqualCorrDis(ByVal Twosided As Boolean, ByVal x As Double, mu1() As Double, _
    'ByVal rho As Double, ByVal k As Integer, LeftTail As Double, RightTail As Double)
    'Dim mu(0 To 100) As Double, lambda(0 To 100) As Double, l(0 To 100) As Integer
    ' l(1) = k
    ' mu(1) = mu1(1)
    ' lambda(1) = Sqr(rho)
    ' k = 1
    ' Call NMultDis(Twosided, x, k, k, lambda(), mu(), l(), LeftTail, RightTail)
    'End Sub

    Public Sub NMultEqualCorrDisN(twosided As Boolean, X As Double, k As Integer,
rho As Double, ByRef LeftTail As Double, ByRef RightTail As Double,
        mu As Double(), L As Integer())
        Dim i As Integer, lambda(0 To 100) As Double, lmax As Integer
        lmax = 1
        L(1) = k
        For i = 1 To k
            lambda(i) = Math.Sqrt(rho)
        Next i
        Call NMultDis(twosided, X, k, lmax, LeftTail, RightTail, lambda, mu, L)
    End Sub

    Public Sub LnModulusDisN(ReturnLog As Boolean, twosided As Boolean,
X As Double, k As Integer, ByRef LeftTail As Double, ByRef RightTail As Double,
        Optional mu As Double() = Nothing, Optional L As Integer() = Nothing)
        Dim F As Double, fR As Double, l1 As Double, r1 As Double, l2 As Double, r2 As Double
        Dim First As Boolean, i As Integer, p As Double, d As Double, d1 As Double
        If IsNothing(mu) Then
            p = k : k = 1 : d = 0
        End If
        If (Not (IsNothing(mu)) And IsNothing(L)) Then p = 1
        First = True
        For i = 1 To k
            If Not (IsNothing(mu)) Then d = mu(i)
            Call ndis2(True, X - d, l1, r1, d1)
            If twosided Then
                Call ndis2(True, -X - d, l2, r2, d1)
                r1 = AddLogs(r1, l2, 1, 0)
                If l1 = l2 Then
                    l1 = -1.0E+20
                Else
                    l1 = AddLogs(l1, l2, -1, 0)
                End If
            End If
            If Not (IsNothing(L)) Then p = L(i)
            l1 = l1 * p
            r1 = LogHoch(True, True, r1, p)
            If First Then
                First = False : F = l1 : fR = r1
            Else
                F = F + l1 : fR = AddLogs(fR, r1, 1, 1)
            End If
        Next i
        If ReturnLog Then
            LeftTail = F : RightTail = fR
        Else
            LeftTail = Math.Exp(F) : RightTail = Math.Exp(fR)
        End If
    End Sub

    Public Sub ModulusDisN(twosided As Boolean, X As Double, k As Integer,
        ByRef LeftTail As Double, ByRef RightTail As Double, Optional mu As Double() = Nothing, Optional L As Integer() = Nothing)
        Dim fR As Double, F As Double, l1 As Double, r1 As Double, l2 As Double, r2 As Double
        Dim First As Boolean, i As Integer, p As Double, d As Double, d1 As Double
        If IsNothing(mu) Then
            p = k : k = 1 : d = 0
        End If
        If (Not (IsNothing(mu)) And IsNothing(L)) Then p = 1
        First = True
        For i = 1 To k
            If Not (IsNothing(mu)) Then d = mu(i)
            Call ndis2(False, X - d, l1, r1, d1)
            If twosided Then
                Call ndis2(False, -X - d, l2, r2, d1)
                r1 = r1 + l2
                l1 = l1 - l2
            End If
            If Not (IsNothing(L)) Then p = L(i)
            If l1 < 1.0E-60 Then l1 = 0 Else l1 = Math.Exp(Math.Log(l1) * p)
            r1 = Hoch(r1, p)
            If First Then
                First = False : F = l1 : fR = r1
            Else
                F = F * l1 : fR = fR + r1 - (fR * r1)
            End If
        Next i
        LeftTail = F : RightTail = fR
    End Sub

    Private Sub bonferroni(twosided As Boolean, x1 As Double, k As Integer, mu1() As Double, L() As Integer, LeftTail As Double, RightTail As Double)
        Dim i As Integer, lefttail1 As Double, RightTail1 As Double, LeftTail2 As Double,
        RightTail2 As Double, d1 As Double
        RightTail = 0
        For i = 1 To k
            Call ndis2(False, x1 - mu1(i), lefttail1, RightTail1, d1)
            If twosided Then
                Call ndis2(False, -x1 - mu1(i), LeftTail2, RightTail2, d1)
                RightTail1 = RightTail1 + LeftTail2
            End If
            RightTail = RightTail + RightTail1 * L(i)
        Next i
        LeftTail = 1 - RightTail
    End Sub

    Private Sub MCPdis(PChoice As Integer, twosided As Boolean, X As Double, rho As Double,
      k As Integer, n() As Double, lambda() As Double, mu() As Double, L() As Integer,
      LeftTail As Double, RightTail As Double)
        Select Case PChoice
            Case 1 : Call ModulusDisN(twosided, X, k, LeftTail, RightTail)
            Case 2 : Call ModulusDisN(twosided, X, k, LeftTail, RightTail, mu, L)
            Case 3 : Call NMultEqualCorrDisN(twosided, X, k, rho, LeftTail, RightTail, mu, L)
            Case 4 : Call ManyOneDis22(twosided, X, k, k, n, mu, L, LeftTail, RightTail)
            Case 5 : Call NMultDis(twosided, X, k, k, LeftTail, RightTail, lambda, mu, L)
            Case 6 : Call NormalRangeDis(X, k, LeftTail, RightTail)
            Case Else
        End Select
    End Sub

    Private Sub test43()
        Dim y As Double, k As Double, z As Double
        k = 1
        y = 1.0E-18
        y = y * 10
        z = Math.Log(y)
        Console.WriteLine("y: {0}, LogZPlusA(y, 1): {1}, Math.Log(y): {02", y, LogZPlusA(y, 1), Math.Log(y))
        Console.WriteLine("Hoch(y, k): {0}, k * y: {1}", Hoch(y, k), k * y)
        Console.WriteLine("Math.Log(Hoch(y, k)): {0}, Math.Log(k) + z: {1}, LogHoch(True, True, z, k): {2}", Math.Log(Hoch(y, k)), Math.Log(k) + z, LogHoch(True, True, z, k))
        Console.WriteLine("LogHoch(False, True, y, k): {0}, LogHoch(False, False, y, k): {1}", LogHoch(False, True, y, k), LogHoch(False, False, y, k))
    End Sub

    Public Sub DemoRange()
        Console.WriteLine("")
        Console.WriteLine("Hello DemoRange!")
        Dim x1 As Double, LeftTail As Double, RightTail As Double, k As Integer
        range = True
        x1 = 0.96
        k = 5
        Call NormalRangeDis(x1 * Math.Sqrt(2), k, LeftTail, RightTail)
        Console.WriteLine("Result:")
        Console.WriteLine("x1: {0}, LeftTail: {1}, RightTail: {2}", x1, LeftTail, RightTail)
        Call LnModulusDisN(False, True, x1, k * (k + 1) \ 2, LeftTail, RightTail)
        Console.WriteLine("x1: {0}, LeftTail: {1}, RightTail: {2}", x1, LeftTail, RightTail)
        Call LnModulusDisN(False, True, x1, k, LeftTail, RightTail)
        Console.WriteLine("x1: {0}, LeftTail: {1}, RightTail: {2}", x1, LeftTail, RightTail)
        '  Call LnModulusDisN(True, True, x1, k * (k + 1) \ 2, LeftTail, RightTail)
        '  Console.WriteLine("x1: {0}, Math.Exp(LeftTail): {0}, Math.Exp(RightTail): {0}", x1, Math.Exp(LeftTail), Math.Exp(RightTail))
        '  Console.WriteLine("x1: {0}, RightTail: {1}, LeftTail: {2}", x1, RightTail, LeftTail)
    End Sub

    Public Sub DemoModulus()
        Console.WriteLine("")
        Console.WriteLine("Hello DemoModulus!")
        Dim LeftTail As Double, RightTail As Double
        Dim x1 As Double, k1 As Integer, i As Integer, k2 As Integer
        Dim mu1(0 To 100) As Double, l1(0 To 100) As Integer
        Dim twosided As Boolean
        twosided = True
        x1 = 4.9
        k1 = 6
        Console.WriteLine("Means:")
        k2 = 0
        For i = 1 To k1
            mu1(i) = 1.5 * i / 2
            Console.WriteLine("i: {0}, mu1(i): {1}", i, mu1(i))
            l1(i) = i
            k2 = k2 + l1(i)
        Next i
        Console.WriteLine("Result:")
        'Call ModulusDis(Twosided, x1, k2, LeftTail, RightTail)
        'Debug.Print k2, LeftTail, RightTail
        Call ModulusDisN(twosided, x1, k2, LeftTail, RightTail)
        Console.WriteLine("k1: {0}, LeftTail: {1}, RightTail: {2}", k1, LeftTail, RightTail)
        Call ModulusDisN(twosided, x1, k1, LeftTail, RightTail, mu1, l1)
        Console.WriteLine("k1: {0}, LeftTail: {1}, RightTail: {2}", k1, LeftTail, RightTail)
        Call LnModulusDisN(True, twosided, x1, k1, LeftTail, RightTail, mu1, l1)
        Console.WriteLine("k1: {0}, LeftTail: {1}, RightTail: {2}", k1, Math.Exp(LeftTail), Math.Exp(RightTail))
        'Call bonferroni(Twosided, x1, k1, mu1(), l1(), LeftTail, RightTail)
        'Debug.Print k1, LeftTail, RightTail
    End Sub

    Public Sub DemoDunnett()
        Console.WriteLine("")
        Console.WriteLine("Hello DemoDunnett!")
        Dim x1 As Double, k1 As Integer, LeftTail As Double, RightTail As Double
        Dim twosided As Boolean, mu1(0 To 100) As Double, L(0 To 100) As Integer
        Dim LeftTail2 As Double, RightTail2 As Double, d1 As Double
        'x1 = 6.021
        x1 = 1.0
        k1 = 3
        mu1(1) = 0
        mu1(2) = mu1(1)
        twosided = False
        '  Call NMultEqualCorrDisN(twosided, X1, k1, 1 / 2, LeftTail, RightTail)
        Call NMultEqualCorrDisN(twosided, x1, k1, 1 / 2, LeftTail, RightTail, mu1, L)
        Console.WriteLine("Result:")
        Console.WriteLine("k1: {0}, x1: {1}, LeftTail: {2}, RightTail: {3}", k1, x1, LeftTail, RightTail)
        Call LnModulusDisN(False, twosided, x1, k1, LeftTail, RightTail, mu)
        Console.WriteLine("k1: {0}, x1: {1}, LeftTail: {2}, RightTail: {3}", k1, x1, LeftTail, RightTail)
        Call ndis2(False, x1 - mu1(1), LeftTail, RightTail, d1)
        If twosided Then
            Call ndis2(False, -x1 - mu1(1), LeftTail2, RightTail2, d1)
            RightTail = RightTail + LeftTail2
            LeftTail = LeftTail - LeftTail2
        End If
        Console.WriteLine("k1: {0}, x1: {1}, LeftTail: {2}, RightTail: {3}", k1, x1, LeftTail, RightTail)
    End Sub






End Module
