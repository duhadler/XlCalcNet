

Module PermKruskal




    ' Module to create and sort vectors for Kruskal-Wallis

    Dim NewDataX() As Double, OldDataX() As Double
    Dim NewDataR(,) As Integer, OldDataR(,) As Integer
    Dim NewDataSize() As Integer, OldDataSize() As Integer
    Dim NewDataStart() As Integer, OldDataStart() As Integer
    Dim m As Integer, MaxTLength As Integer

    Sub initdata(mm As Integer, MaxVLength As Integer, linear As Boolean)
        Dim j As Integer
        MaxTLength = 8192
        If linear Then m = 0 Else m = mm
        ReDim OldDataSize(MaxVLength)
        ReDim NewDataSize(MaxVLength)
        ReDim OldDataStart(MaxVLength)
        ReDim NewDataStart(MaxVLength)
        ReDim OldDataX(MaxTLength - 1)
        ReDim NewDataX(MaxTLength - 1)
        ReDim OldDataR(m, MaxTLength - 1)
        ReDim NewDataR(m, MaxTLength - 1)
        OldDataSize(0) = 0
        OldDataStart(0) = 0
        OldDataX(0) = 1
        For j = 0 To m
            OldDataR(j, 0) = 0
        Next j
    End Sub

    Sub DoneData()
        Erase NewDataSize
        Erase OldDataSize
        Erase NewDataStart
        Erase OldDataStart
        Erase NewDataX
        Erase OldDataX
        Erase NewDataR
        Erase OldDataR
    End Sub

    ' NextRank: The next rankvalue which will be added to form the new vector
    ' NewDest : ID-# of the new vector set in which the result will be stored
    ' CurNumCount: Count of the old vectors which form the new vector
    ' CurNum  : ID-# of the old vectors which form the new vectors
    ' AddPos: Position in the old vectors to which NextRank will be added
    ' N: Sample size per group for the new vector
    ' V: Parameters fot the Lehmann alternative
    Sub BuildNew(NextRank As Integer, NewDest As Integer, CurNumCount As Integer,
  ByRef CurNum() As Integer, ByRef AddPos() As Integer, ByRef n() As Double, ByRef v() As Double,
  linear As Boolean, score() As Integer)
        Dim w(,) As Integer, z() As Double, Min() As Integer, LocalPos() As Integer, NV() As Double
        Dim NewZ As Double, NewCount As Integer, NND As Integer, j1 As Integer, j As Integer, k As Integer
        Dim k4 As Integer, nvSum As Double
        ReDim w(CurNumCount, m) : ReDim z(CurNumCount) : ReDim Min(m)
        ReDim LocalPos(CurNumCount) : ReDim NV(CurNumCount)
        nvSum = 0
        For j = 0 To CurNumCount
            NV(j) = n(j) * v(j)
            nvSum = nvSum + NV(j)
        Next j
        For j = 0 To CurNumCount
            NV(j) = NV(j) / nvSum
        Next j
        If NewDest = 0 Then NewDataStart(NewDest) = 0 _
    Else NewDataStart(NewDest) = NewDataStart(NewDest - 1) + NewDataSize(NewDest - 1) + 1
        NND = NewDataStart(NewDest)
        NewCount = 0
        For j = 0 To CurNumCount
            LocalPos(j) = 0
            z(j) = OldDataX(OldDataStart(CurNum(j)))
            For k = 0 To m
                w(j, k) = OldDataR(k, OldDataStart(CurNum(j)))
                If linear Then
                    w(j, k) = w(j, k) + NextRank * score(AddPos(j))
                Else
                    If k = AddPos(j) Then w(j, k) = w(j, k) + NextRank
                End If
            Next k
            If j = 0 Then
                For k = 0 To m : Min(k) = w(j, k) : Next k
            End If
            k4 = -1
            Do : k4 = k4 + 1
            Loop Until Not ((k4 < (m - 1)) And (Min(k4) = w(j, k4)))
            If (w(j, k4) < Min(k4)) Then
                For k = 0 To m : Min(k) = w(j, k) : Next k
            End If
        Next j

        '  MainLoop
        While CurNumCount >= 0
            For j = 0 To CurNumCount
                k4 = -1
                Do : k4 = k4 + 1
                Loop Until Not ((k4 < (m - 1)) And (Min(k4) = w(j, k4)))
                If (w(j, k4) < Min(k4)) Then
                    For k = 0 To m : Min(k) = w(j, k) : Next k
                End If
            Next j
            NewZ = 0
            For j = 0 To CurNumCount
                k4 = -1
                Do : k4 = k4 + 1
                Loop Until Not ((k4 < (m - 1)) And (Min(k4) = w(j, k4)))
                If (Min(k4) = w(j, k4)) Then
                    NewZ = NewZ + NV(j) * z(j)
                    '                NewZ = NewZ + z(j)
                    If LocalPos(j) < OldDataSize(CurNum(j)) Then
                        LocalPos(j) = LocalPos(j) + 1
                        j1 = OldDataStart(CurNum(j)) + LocalPos(j)
                        z(j) = OldDataX(j1)
                        For k = 0 To m : w(j, k) = OldDataR(k, j1) : Next k
                        If linear Then
                            w(j, m) = w(j, m) + NextRank * score(AddPos(j))
                        Else
                            w(j, AddPos(j)) = w(j, AddPos(j)) + NextRank
                        End If
                    Else
                        For k = j + 1 To CurNumCount
                            CurNum(k - 1) = CurNum(k)
                            LocalPos(k - 1) = LocalPos(k)
                            AddPos(k - 1) = AddPos(k)
                            NV(k - 1) = NV(k)
                            score(k - 1) = score(k)
                        Next k
                        CurNumCount = CurNumCount - 1
                    End If
                End If
            Next j
            If NND + NewCount > MaxTLength - 1 Then
                MaxTLength = 2 * MaxTLength
                ReDim Preserve OldDataX(MaxTLength - 1)
                ReDim Preserve NewDataX(MaxTLength - 1)
                ReDim Preserve OldDataR(m, MaxTLength - 1)
                ReDim Preserve NewDataR(m, MaxTLength - 1)
                '     Debug.Print "New MaxTLength:", MaxTLength
            End If
            For k = 0 To m
                NewDataR(k, NND + NewCount) = Min(k)
            Next k
            NewDataX(NND + NewCount) = NewZ
            For k = 0 To m : Min(k) = w(0, k) : Next k
            NewCount = NewCount + 1
        End While
        NewDataSize(NewDest) = NewCount - 1
        '  Debug.Print "Top: ", NND + NewDataSize(NewDest)
    End Sub



    '  ' NextRank: The next rankvalue which will be added to form the new vector
    '  ' NewDest : ID-# of the new vector set in which the result will be stored
    '  ' CurNumCount: Count of the old vectors which form the new vector
    '  ' CurNum  : ID-# of the old vectors which form the new vectors
    '  ' AddPos: Position in the old vectors to which NextRank will be added
    '  ' N: Sample size per group for the new vector
    '  ' V: Parameters fot the Lehmann alternative
    '  Sub BuildNewLinear(NextRank As Integer, NewDest As Integer, CurNumCount As Integer,
    'ByRef CurNum() As Integer, ByRef AddPos() As Integer, ByRef n() As Double, ByRef v() As Double,
    'linear As Boolean, score() As Integer)
    '      Dim w(,) As Integer, z() As Double, Min() As Integer, LocalPos() As Integer, NV() As Double
    '      Dim NewZ As Double, NewCount As Integer, NND As Integer, j1 As Integer, j As Integer, k As Integer
    '      Dim nvSum As Double, CountToBeReduced() As Boolean, AnyCountToBeReduced As Boolean
    '      ReDim w(CurNumCount, m) : ReDim z(CurNumCount) : ReDim Min(m)
    '      ReDim LocalPos(CurNumCount) : ReDim NV(CurNumCount)
    '      ReDim CountToBeReduced(CurNumCount)
    '      nvSum = 0
    '      For j = 0 To CurNumCount
    '          NV(j) = n(j) * v(j)
    '          nvSum = nvSum + NV(j)
    '      Next j
    '      For j = 0 To CurNumCount
    '          NV(j) = NV(j) / nvSum
    '      Next j
    '      If NewDest = 0 Then
    '          NewDataStart(NewDest) = 0
    '      Else
    '          NewDataStart(NewDest) = NewDataStart(NewDest - 1) + NewDataSize(NewDest - 1) + 1
    '      End If
    '      NND = NewDataStart(NewDest)
    '      NewCount = 0
    '      For j = 0 To CurNumCount
    '          CountToBeReduced(j) = False
    '          LocalPos(j) = 0
    '          z(j) = OldDataX(OldDataStart(CurNum(j)))
    '          w(j, 0) = OldDataR(0, OldDataStart(CurNum(j)))
    '          w(j, 0) = w(j, 0) + NextRank * score((j))
    '      Next j
    '      AnyCountToBeReduced = False

    '      '  MainLoop
    '      While CurNumCount >= 0
    '          Min(0) = w(0, 0)
    '          For j = 0 To CurNumCount
    '              If w(j, 0) < Min(0) Then Min(0) = w(j, 0)
    '          Next j
    '          NewZ = 0
    '          For j = 0 To CurNumCount
    '              If (Min(0) = w(j, 0)) Then
    '                  NewZ = NewZ + NV(j) * z(j)
    '                  If LocalPos(j) < OldDataSize(CurNum(j)) Then
    '                      LocalPos(j) = LocalPos(j) + 1
    '                      j1 = OldDataStart(CurNum(j)) + LocalPos(j)
    '                      z(j) = OldDataX(j1)
    '                      w(j, 0) = OldDataR(0, j1)
    '                      w(j, 0) = w(j, 0) + NextRank * score((j))
    '                  Else
    '                      CountToBeReduced(j) = True
    '                      AnyCountToBeReduced = True
    '                  End If
    '              End If
    '          Next j
    '          If NND + NewCount > MaxTLength - 1 Then
    '              MaxTLength = 2 * MaxTLength
    '              ReDim Preserve OldDataX(MaxTLength - 1)
    '              ReDim Preserve NewDataX(MaxTLength - 1)
    '              ReDim Preserve OldDataR(m, MaxTLength - 1)
    '              ReDim Preserve NewDataR(m, MaxTLength - 1)
    '              '     Debug.Print "New MaxTLength:", MaxTLength
    '          End If
    '          NewDataR(0, NND + NewCount) = Min(0)
    '          NewDataX(NND + NewCount) = NewZ
    '          If AnyCountToBeReduced Then
    '              j = -1
    '              While j < CurNumCount
    '                  j = j + 1
    '                  If CountToBeReduced(j) = True Then
    '                      CountToBeReduced(j) = False
    '                      For k = j + 1 To CurNumCount
    '                          CurNum(k - 1) = CurNum(k)
    '                          LocalPos(k - 1) = LocalPos(k)
    '                          AddPos(k - 1) = AddPos(k)
    '                          NV(k - 1) = NV(k)
    '                          score(k - 1) = score(k)
    '                          z(k - 1) = z(k)
    '                          w(k - 1, 0) = w(k, 0)
    '                      Next k
    '                      CurNumCount = CurNumCount - 1
    '                  End If
    '              End While
    '              AnyCountToBeReduced = False
    '          End If
    '          NewCount = NewCount + 1
    '      End While
    '      NewDataSize(NewDest) = NewCount - 1
    '  End Sub


    Sub GetFinalVector(ByRef FinalSize As Integer, ByRef FinalX() As Double, ByRef FinalR(,) As Integer)
        Dim j As Integer, i As Integer, ok As Integer, k As Integer
        k = 0
        FinalSize = OldDataSize(k)
        ok = OldDataStart(k)
        ReDim FinalX(FinalSize)
        ReDim FinalR(m, FinalSize)
        '  Debug.Print "---Old Vector------Size: " + Str(OldDataSize(k))
        '  s2 = ""
        For i = 0 To OldDataSize(k)
            FinalX(i) = OldDataX(ok + i)
            's2 = Str(i) + ".  " + Str(OldDataX(ok + i)) + ": "
            For j = 0 To m
                FinalR(j, i) = OldDataR(j, ok + i)
                '      s2 = s2 + Str(OldDataR(j, ok + i))
                '      If j < m Then s2 = s2 + ","
            Next j
            '    Debug.Print s2
        Next i
    End Sub


    Sub ShowOldVector(k As Integer)
        Dim j As Integer, i As Integer, ok As Integer
        Dim s2 As String
        ok = OldDataStart(k)
        Console.WriteLine("---Old Vector------Size: " + Str(OldDataSize(k)))
        s2 = ""
        For i = 0 To OldDataSize(k)
            s2 = Str(i) + ".  " + Str(OldDataX(ok + i)) + ": "
            For j = 0 To m
                s2 = s2 + Str(OldDataR(j, ok + i))
                If j < m Then s2 = s2 + ","
            Next j
            Console.WriteLine(s2)
        Next i
    End Sub

    Sub ShowNewVector(k As Integer)
        Dim j As Integer, i As Integer, nk As Integer
        Dim s2 As String
        nk = NewDataStart(k)
        Console.WriteLine("---New Vector------Size: " + Str(NewDataSize(k)))
        s2 = ""
        For i = 0 To NewDataSize(k)
            s2 = Str(i) + ".  " + Str(NewDataX(nk + i)) + ": "
            For j = 0 To m
                s2 = s2 + Str(NewDataR(j, nk + i))
                If j < m Then s2 = s2 + ","
            Next j
            Console.WriteLine(s2)
        Next i
        Console.WriteLine("---End New Vector-----")
    End Sub

    Sub NewToOld(MaxVLength As Integer)
        Dim k As Integer, i As Integer, j As Integer, nk As Integer
        'Debug.Print "NewToOld: ", MaxVLength

        For k = 0 To MaxVLength
            nk = NewDataStart(k)
            OldDataSize(k) = NewDataSize(k)
            OldDataStart(k) = NewDataStart(k)
            For i = 0 To NewDataSize(k)
                OldDataX(nk + i) = NewDataX(nk + i)
                For j = 0 To m
                    OldDataR(j, nk + i) = NewDataR(j, nk + i)
                Next j
            Next i
        Next k
    End Sub



    ' Recursive algorithm for Kruskal-Wallis


    Sub CalcRankSums(m As Integer, ng As Integer, ByRef n() As Integer,
  ByRef v() As Double, ByRef Rank() As Integer, linear As Boolean, ByRef score() As Integer,
  ByRef FinalSize As Integer, ByRef FinalX() As Double, ByRef FinalR(,) As Integer)

        Dim AddPos() As Integer, w() As Integer, CurNum() As Integer, t() As Integer
        Dim z() As Integer, zstart() As Integer, zlength() As Integer, ztemp() As Integer, Last() As Integer
        Dim sortiert As Boolean, first As Boolean, EQ As Boolean, LE As Boolean
        Dim CurNumCount As Integer, zmax As Integer, h As Integer, k2 As Integer, i As Integer
        Dim r As Integer, k1 As Integer, i1 As Integer, i2 As Integer, vref As Integer, w1 As Integer
        Dim q As Integer, m1 As Integer
        Dim CurrentNumber As Integer, Lastj As Integer, scount As Integer
        Dim calc As Boolean, showstruc As Boolean, showvec As Boolean
        Dim s2 As String, s3 As String
        Dim j2 As Integer, k3 As Integer, j As Integer, k As Integer, l As Integer, zsize As Integer, ztempsize As Integer
        Dim v4() As Double, n4() As Double, Score4() As Integer

        calc = True : showstruc = False : showvec = False
        h = m - 1
        m1 = m + 1
        zsize = m1 * 6
        ztempsize = m1 * 6
        ReDim zlength(ng) : ReDim zstart(ng)
        ReDim AddPos(m) : ReDim w(m) : ReDim CurNum(m) : ReDim t(m)
        ReDim v4(m) : ReDim n4(m) : ReDim Score4(m)
        ReDim ztemp(ztempsize)
        ReDim z(zsize)
        For j = 0 To m : w(j) = n(j) : Next j
        For j = 0 To m : t(j) = j : Next j

        ' Sorting should be eliminated
        Do
            sortiert = True
            For k = 0 To m - 1
                k1 = k + 1
                If w(k) < w(k1) Then
                    w1 = w(k) : w(k) = w(k1) : w(k1) = w1
                    w1 = t(k) : t(k) = t(k1) : t(k1) = w1
                    sortiert = False
                End If
            Next k
        Loop Until sortiert

        For j = 0 To m : n(j) = w(j) : Next j
        For k = 0 To m : z(k) = w(k) : Next k
        zlength(ng) = 0 : zstart(ng) = 0

        zmax = 0
        For i = ng - 1 To 0 Step -1
            i1 = i + 1
            zstart(i) = zstart(i1) + (zlength(i1) + 1) * m1
            first = True
            For j = 0 To zlength(i1)
                For k2 = 0 To m
                    If z(zstart(i1) + j * m1 + k2) > 0 Then
                        For k1 = 0 To m
                            w(k1) = z(zstart(i1) + j * m1 + k1)
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
                                If ((zlength(i) + 1) * m1) > (ztempsize) Then
                                    ztempsize = ztempsize + ((zlength(i) + 1) * m1)
                                    ReDim Preserve ztemp(ztempsize)
                                    '              Debug.Print "New ztempsize: ", ztempsize
                                End If
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
                    End If
                Next k2
            Next j

            If ((zlength(i) + 1) * m1) > (zsize - zstart(i)) Then
                zsize = zsize + ((zlength(i) + 1) * m1)
                ReDim Preserve z(zsize)
                '     Debug.Print "New zsize: ", zsize
            End If
            For j = 0 To (zlength(i) + 1) * m1 - 1
                z(zstart(i) + j) = ztemp(j)
            Next j
            If zlength(i) > zmax Then zmax = zlength(i)
        Next i
        'Dim ztotal As Double, zfactorial As Double
        'ztotal = 0: zfactorial = 1
        'For i = 1 To ng
        '  ztotal = ztotal + zlength(i) + 1
        '  zfactorial = zfactorial * i
        '  Debug.Print i, zlength(i) + 1
        'Next i
        'Debug.Print "ztotal: ", ztotal, zfactorial


        ReDim Last((zmax + 1) * m1)

        'Calculate the Vectors
        s2 = ""
        s3 = ""
        If calc Then Call initdata(m, zmax, linear)
        If (calc And showvec) Then Call ShowOldVector(0)
        For i = 1 To ng
            '  Debug.Print "Iteration: ", i
            i1 = i - 1
            For j = 0 To (zlength(i1) + 1) * m1
                Last(j) = z(zstart(i1) + j)
            Next j
            Lastj = zlength(i1)
            If showstruc Then Debug.Print(Str(i) + ". Iteration")
            scount = 0

            For j = 0 To zlength(i)
                If showstruc Then
                    s2 = ""
                    For k = 0 To m : s2 = s2 + Str(z(zstart(i) + j * m1 + k)) : Next k
                    s2 = s2 + "  :" : s3 = "   "
                End If
                CurNumCount = -1
                For k = 0 To m
                    If z(zstart(i) + j * m1 + k) > 0 Then
                        For k1 = 0 To m
                            w(k1) = z(zstart(i) + j * m1 + k1)
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
                        n4(CurNumCount) = w(k) + 1
                        v4(CurNumCount) = v(k)
                        Score4(CurNumCount) = score(k)
                        If showstruc Then
                            s3 = s3 + " [" + Str(n4(CurNumCount)) + "; " + Str(v4(CurNumCount)) + Str(Score4(CurNumCount)) + "], "
                            s2 = s2 + " (" + Str(CurNum(CurNumCount)) + "; " + Str(AddPos(CurNumCount)) + ")"
                            s2 = s2 + ", "
                        End If
                    End If
                Next k
                If showstruc Then Console.WriteLine(s2 + s3)
                If calc Then
                    If linear Then
                        'Call BuildNewLinear(Rank(i), j, CurNumCount, CurNum, AddPos, n4, v4, linear, Score4)
                    Else
                        Call BuildNew(Rank(i), j, CurNumCount, CurNum, AddPos, n4, v4, linear, Score4)
                    End If
                End If
                If (calc And showvec) Then ShowNewVector(j)
            Next j
            If calc Then Call NewToOld(zlength(i))
        Next i

        Erase zlength : Erase zstart : Erase Last : Erase z : Erase ztemp
        Erase AddPos : Erase w : Erase CurNum : Erase t
        Erase v4 : Erase n4

        If calc Then Call GetFinalVector(FinalSize, FinalX, FinalR)
        'If calc Then Call ShowOldVector(0)
        If calc Then Call DoneData()
    End Sub


    Function KruskalDemoMain(GetWhat As Integer, k As Integer, CommonN As Integer) As Object
        Dim Rank() As Integer, n() As Integer, v() As Double, score() As Integer
        Dim linear As Boolean, ng As Integer, Mode As Integer
        Dim m As Integer, j As Integer, i As Integer
        'Dim IntCoeff() As Integer, m As Integer, Order As Integer, j As Integer, i As Integer
        Dim FinalSize As Integer, FinalX() As Double, FinalR(,) As Integer
        Dim nlength As Integer, Prob() As Double, x() As Double
        Dim p1 As Double, pcum As Double, Chi2 As Double
        Dim Varianz As Double, std As Double, LeftTail As Double, Righttail As Double, cdens As Double
        Dim Output(,) As Double ', title() As String
        'If GetWhat = 1 Then
        '    ReDim title(0, 6)
        '    If Mode = 1 Then title(0, 0) = "Chi2" Else title(0, 0) = "Z"
        '    title(0, 1) = "Density"
        '    title(0, 2) = "RightTail"
        '    title(0, 3) = "cdisx"
        '    title(0, 4) = "Temp"
        '    title(0, 5) = "Temp"
        '    title(0, 6) = "Temp"
        '    KruskalDemoMain = title
        '    Exit Function
        'End If

        m = k - 1
        linear = False
        ReDim n(m) : ReDim v(m) : ReDim score(m)
        '  If linear Then

        '      Call GetIntCoeff(k, IntCoeff)
        '      ' For order = 1 To k - 1
        '      Order = 2
        '      Debug.Print "Coeff of order :", Order
        'For j = 1 To k
        '          score(j - 1) = IntCoeff(Order, j) + 0
        '          Debug.Print j - 1, IntCoeff(Order, j)
        'Next j
        '      'Next order
        '  End If

        For j = 0 To m : v(j) = j * 0 + 1 : Next j
        For j = 0 To m : n(j) = CommonN : Next j
        ng = 0
        For j = 0 To m
            ng = ng + n(j)
            '        Debug.Print (Str(j) + Str(N(j)))
        Next j
        ReDim Rank(ng + 1)
        For j = 0 To ng
            Rank(j) = j
        Next j
        ReDim FinalX(1)
        ReDim FinalR(1,1)
        Call CalcRankSums(m, ng, n, v, Rank, linear, score, FinalSize, FinalX, FinalR)
        ' Define and set mode !!!!


        Mode = 2
        Mode = 1
        ReDim Prob(1)
        ReDim x(1)
        
        Call CalcStats(Mode, m, FinalSize, FinalX, FinalR, nlength, Prob, x)

        '  For i = 0 To nlength
        '    Debug.Print i, x(i), Prob(i)
        '  Next i


        ReDim Output(nlength, 3)
        Varianz = 12 / (ng * (ng + 1) * CommonN)
        std = Math.Sqrt(Varianz)
        For i = nlength To 0 Step -1
            p1 = Prob(i)
            pcum = pcum + p1
            If Mode = 1 Then Chi2 = x(i) * Varianz Else Chi2 = x(i) * std
            Output(i, 0) = Chi2
            Output(i, 1) = p1
            Output(i, 2) = pcum
            If Mode = 1 Then
                Call cdis2(m, Chi2, LeftTail, Righttail, cdens)
                Output(i, 3) = Righttail
            Else
                Call NormalRangeDis(Chi2 * Math.Sqrt(1), m + 1, LeftTail, Righttail)
                Output(i, 3) = Righttail
            End If
        Next i
        Erase x
        Erase Prob
        KruskalDemoMain = Output

    End Function




    Sub CalcStats(Mode As Integer, m As Integer, FinalSize As Integer, ByRef FinalX() As Double, ByRef FinalR(,) As Integer,
ByRef nlength As Integer, ByRef Prob() As Double, ByRef x() As Double)
        Dim j As Integer, i As Integer, mean As Integer, sum As Integer, sum2 As Integer, d As Integer, vmax As Integer
        Dim Chi2() As Double, j1 As Integer
        Dim s2 As String
        Console.WriteLine("---Final Vector------Size: " + Str(FinalSize))
        Select Case Mode
            Case 1
                sum = 0
                For j = 0 To m
                    sum = sum + FinalR(j, 0)
                Next j
                mean = sum \ (m + 1)
                sum2 = 0
                For j = 0 To m
                    d = FinalR(j, 0) - mean
                    sum2 = sum2 + d * d
                Next j
                vmax = sum2 + 2
                ReDim Chi2(vmax)
                'ReDim Chi2(10000)
                For i = 0 To vmax
                    Chi2(i) = 0
                Next i
                For i = 0 To FinalSize
                    s2 = Str(i) + ".  " + Str(FinalX(i)) + ": "
                    sum2 = 0
                    For j = 0 To m
                        d = FinalR(j, i) - mean
                        sum2 = sum2 + d * d
                        s2 = s2 + Str(FinalR(j, i))
                        If j < m Then s2 = s2 + ","
                    Next j
                    Chi2(sum2) = Chi2(sum2) + FinalX(i)
                    s2 = s2 + "  ;  " + Str(sum2)
                    'Console.WriteLine(s2)
                    'Debug.Print s2
                Next i
                Erase FinalX
                Erase FinalR
                Console.WriteLine("Chi2")
                j = 0
                For i = 0 To vmax
                    If Chi2(i) > 0 Then j = j + 1
                Next i
                nlength = j - 1

                ReDim x(nlength)
                ReDim Prob(nlength)
                j = 0
                For i = 0 To vmax
                    If Chi2(i) > 0 Then
                        Prob(j) = Chi2(i)
                        x(j) = i
                        j = j + 1
                    End If
                Next i
                Erase Chi2
            Case 2
                sum = 0
                vmax = Math.Abs(FinalR(m, 0))
                ReDim Chi2(vmax)
                For i = 0 To vmax
                    Chi2(i) = 0
                Next i
                For i = 0 To FinalSize
                    s2 = Str(i) + ".  " + Str(FinalX(i)) + ": "
                    sum2 = 0
                    For j = 0 To m
                        For j1 = j + 1 To m
                            d = FinalR(j, i) - FinalR(j1, i)
                            d = Math.Abs(d)
                            If d > sum2 Then sum2 = d

                            s2 = s2 + Str(FinalR(j, i))
                            If j < m Then s2 = s2 + ","
                        Next j1
                    Next j
                    Chi2(sum2) = Chi2(sum2) + FinalX(i)
                    s2 = s2 + "  ;  " + Str(sum2)
                    Console.WriteLine(s2)
                    'Debug.Print s2
                Next i
                Erase FinalX
                Erase FinalR
                Console.WriteLine("Chi2")
                j = 0
                For i = 0 To vmax
                    If Chi2(i) > 0 Then j = j + 1
                Next i
                nlength = j - 1

                ReDim x(nlength)
                ReDim Prob(nlength)
                j = 0
                For i = 0 To vmax
                    If Chi2(i) > 0 Then
                        Prob(j) = Chi2(i)
                        x(j) = i
                        j = j + 1
                    End If
                Next i
                Erase Chi2
            Case Else
        End Select
    End Sub



    Sub Kruskaldemo2()
        Dim Rank() As Integer, n() As Integer, v() As Double, score() As Integer
        Dim linear As Boolean, m As Integer, ng As Integer, Mode As Integer
        Dim j As Integer, i As Integer
        'Dim IntCoeff() As Integer, k As Integer, Order As Integer, j As Integer, i As Integer
        Dim FinalSize As Integer, FinalX() As Double, FinalR(,) As Integer
        Dim nlength As Integer, Prob() As Double, x() As Double

        m = 3  ' number of groups -1
        '  linear = True
        linear = False
        ReDim n(m) : ReDim v(m) : ReDim score(m)
        '  If linear Then
        '    k = m + 1
        '    Call GetIntCoeff(k, IntCoeff)
        '    ' For order = 1 To k - 1
        '      Order = 2
        '      Debug.Print "Coeff of order :", Order
        '      For j = 1 To k
        '        score(j - 1) = IntCoeff(Order, j) + 0
        '        Debug.Print j - 1, IntCoeff(Order, j)
        '      Next j
        '    'Next order
        '  End If

        For j = 0 To m : v(j) = j * 0 + 1 : Next j
        For j = 0 To m : n(j) = 5 : Next j
        'n(0) = 3
        'For j = 0 To m : n(j) = 10 : Next j
        ng = 0
        For j = 0 To m
            ng = ng + n(j)
            '        Debug.Print (Str(j) + Str(N(j)))
        Next j
        ReDim Rank(ng + 1)
        For j = 0 To ng
            Rank(j) = j
        Next j
        ReDim FinalX(1)
        ReDim FinalR(1,1)
        
        Call CalcRankSums(m, ng, n, v, Rank, linear, score, FinalSize, FinalX, FinalR)
        Mode = 1
        
        ReDim Prob(1)
        ReDim x(1)
        
        Call CalcStats(Mode, m, FinalSize, FinalX, FinalR, nlength, Prob, x)

        For i = 0 To nlength
            Console.WriteLine("i: {0}, x(i): {1}, Prob(i): {2}", i, x(i), Prob(i))
        Next i

    End Sub






End Module
