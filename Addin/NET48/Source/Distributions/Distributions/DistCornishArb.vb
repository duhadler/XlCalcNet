Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet


Module DistCornishArb


    Function CF_xp(xp As Arb, kappa As ArbMat) As Arb
        Dim result As New Arb, xp2 As New Arb, xp3 As New Arb, xp5 As New Arb
        Dim kappa3 As New Arb, kappa4 As New Arb, kappa5 As New Arb, kappa6 As New Arb, S2 As New Arb
        xp2 = xp * xp
        xp3 = xp * xp2
        xp5 = xp3 * xp2
        S2 = kappa(2) * kappa(2)
        kappa4 = kappa(4) / S2
        kappa6 = kappa(6) / (S2 * S2)
        result = xp + kappa4 * (xp3 - 3 * xp) / 24 + kappa6 * (xp5 - 100 * xp3 + 15 * xp) / 720 - kappa4 * kappa4 * (3 * xp5 - 24 * xp3 + 29 * xp) / 384
        Return result
    End Function


    Function CF_xp_new(xp As Arb, kappa As ArbMat) As Arb
        Dim result As New Arb, xp2 As New Arb, xp3 As New Arb, xp4 As New Arb, xp5 As New Arb
        Dim kappa3 As New Arb, kappa4 As New Arb, kappa5 As New Arb, kappa6 As New Arb, S As New Arb, S2 As New Arb
        Dim LeftApprox As New Arb, Adj As New Arb
        xp2 = xp * xp
        xp3 = xp * xp2
        xp4 = xp * xp3
        xp5 = xp3 * xp2
        S = aflint.sqrt(kappa(2))
        S2 = kappa(2) ' * kappa(2)
        kappa3 = kappa(3) / (S2 * S)
        kappa4 = kappa(4) / (S2 * S2)
        kappa5 = kappa(5) / (S2 * S2 * S)
        kappa6 = kappa(6) / (S2 * S2 * S2)
        'Console.WriteLine("kappa3: {0}", kappa3)
        'Console.WriteLine("kappa4: {0}", kappa4)
        'Console.WriteLine("kappa5: {0}", kappa5)
        'Console.WriteLine("kappa6: {0}", kappa6)

        'Console.WriteLine("")
        result = xp
        Console.WriteLine("result: {0}", result)

        Console.WriteLine("")
        Adj = +kappa3 * (xp2 - 1) / 6
        result = result + Adj
        Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)

        Console.WriteLine("")
        Adj = +kappa4 * (xp3 - 3 * xp) / 24
        result = result + Adj
        Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)

        Adj = -kappa3 * kappa3 * (2 * xp3 - 5 * xp) / 36
        result = result + Adj
        Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)

        Console.WriteLine("")
        Adj = +kappa5 * (xp4 - 6 * xp2 + 3) / 120
        result = result + Adj
        Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)


        Adj = -kappa3 * kappa4 * (1 * xp4 - 5 * xp2 + 2) / 24
        result = result + Adj
        Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)


        Adj = +kappa3 * kappa3 * kappa3 * (12 * xp4 - 53 * xp2 + 17) / 324
        result = result + Adj
        Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)

        'Console.WriteLine("")

        'Adj = +kappa6 * (xp5 - 100 * xp3 + 15 * xp) / 720
        'result = result + Adj
        'Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)


        'Adj = -kappa3 * kappa5 * (2 * xp5 - 17 * xp3 + 21 * xp) / 180
        'result = result + Adj
        'Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)

        'Adj = -kappa4 * kappa4 * (3 * xp5 - 24 * xp3 + 29 * xp) / 384
        'result = result + Adj
        'Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)


        'Adj = +kappa3 * kappa3 * kappa4 * (14 * xp5 - 103 * xp3 + 107 * xp) / 288
        'result = result + Adj
        'Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)


        'Adj = +kappa4 * kappa4 * kappa4 * (252 * xp5 - 1688 * xp3 + 1511 * xp) / 7776
        'result = result + Adj
        'Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)






        'result = xp + kappa4 * (xp3 - 3 * xp) / 24 + kappa6 * (xp5 - 100 * xp3 + 15 * xp) / 720 - kappa4 * kappa4 * (3 * xp5 - 24 * xp3 + 29 * xp) / 384
        Return result
    End Function

    Public Function CF_up(xp As Arb, kappa As ArbMat) As Arb
        Dim result As New Arb, xp2 As New Arb, xp3 As New Arb, xp4 As New Arb, xp5 As New Arb
        Dim kappa3 As New Arb, kappa4 As New Arb, kappa5 As New Arb, kappa6 As New Arb, S As New Arb, S2 As New Arb
        Dim LeftApprox As New Arb, Adj As New Arb
        xp2 = xp * xp
        xp3 = xp * xp2
        xp4 = xp * xp3
        xp5 = xp3 * xp2
        S = aflint.sqrt(kappa(2))
        S2 = kappa(2) ' * kappa(2)
        kappa3 = kappa(3) / (S2 * S)
        kappa4 = kappa(4) / (S2 * S2)
        kappa5 = kappa(5) / (S2 * S2 * S)
        kappa6 = kappa(6) / (S2 * S2 * S2)
        result = xp
        LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}", result, LeftApprox)

        'Console.WriteLine("")
        Adj = -kappa3 * (xp2 - 1) / 6
        result = result + Adj
        LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

        'Console.WriteLine("")
        Adj = -kappa4 * (xp3 - 3 * xp) / 24
        result = result + Adj
        LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


        Adj = +kappa3 * kappa3 * (4 * xp3 - 7 * xp) / 36
        result = result + Adj
        LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

        'Console.WriteLine("")
        Adj = -kappa5 * (xp4 - 6 * xp2 + 3) / 120
        result = result + Adj
        LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


        Adj = +kappa3 * kappa4 * (11 * xp4 - 42 * xp2 + 15) / 144
        result = result + Adj
        LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


        Adj = -kappa3 * kappa3 * kappa3 * (69 * xp4 - 187 * xp2 + 52) / 648
        result = result + Adj
        LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

        'Console.WriteLine("")
        'Adj = -kappa6 * (xp5 - 10 * xp3 + 15 * xp) / 720
        'result = result + Adj
        'LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


        'Adj = +kappa3 * kappa5 * (7 * xp5 - 48 * xp3 + 51 * xp) / 360
        'result = result + Adj
        'LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

        'Console.WriteLine("")
        'Adj = +kappa4 * kappa4 * (5 * xp5 - 32 * xp3 + 35 * xp) / 384
        'result = result + Adj
        'LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


        'Adj = -kappa3 * kappa3 * kappa4 * (111 * xp5 - 547 * xp3 + 456 * xp) / 8640
        'result = result + Adj
        'LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


        'Adj = +kappa4 * kappa4 * kappa4 * (948 * xp5 - 3628 * xp3 + 2473 * xp) / 7776
        'result = result + Adj
        'LeftApprox = NdisArb(result)
        'Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

        'Console.WriteLine("")
        'Console.WriteLine("")

        Return result
    End Function



    Function GuessLeftTailArb(x As Arb, kappa As ArbMat) As Arb
        Dim result As New Arb, xp As New Arb, up1 As New Arb
        Dim mean As New Arb, sigma As New Arb
        xp = x
        Console.WriteLine("x: {0}", x)
        mean = kappa(1)
        Console.WriteLine("mean: {0}", mean)

        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("sigma: {0}", sigma)

        up1 = CF_up(xp, kappa)
        Console.WriteLine("up1: {0}", up1)

        Dim LeftApprox As Arb = NdisArb(up1)
        Console.WriteLine("LeftApprox: {0}", LeftApprox)

        Return LeftApprox
    End Function






    Function GuessQuantileArb(LeftTail As Arb, kappa As ArbMat) As Arb
        Dim result As New Arb, xp As New Arb, up1 As New Arb
        Dim mean As New Arb, sigma As New Arb
        xp = ndisxArb(LeftTail, 1 - LeftTail)
        Console.WriteLine("xp: {0}", xp)
        mean = kappa(1)
        Console.WriteLine("mean: {0}", mean)

        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("sigma: {0}", sigma)

        up1 = CF_xp(xp, kappa)
        Console.WriteLine("up1: {0}", up1)


        result = mean + sigma * up1
        Return result
    End Function


    Sub aflint_NoncentralChi2_Cumulants(Order As Integer, nu As Arb, lambda As Arb, kappa As ArbMat)
        kappa.Resize(Order + 1, 1)
        kappa(1) = nu + lambda
        For i = 2 To Order
            kappa(i) = kappa(i - 1) * 2 * (i - 1) * (1 + lambda / (nu + (i - 1) * lambda))
            'Console.WriteLine("i: {0}, kappa(i): {1}, gamma(i+1): {2}", i, kappa(i), kappa(i) * s1 / aflint.gamma(i + 1))
        Next i
    End Sub


    Sub aflint_NoncentralChi2_CGF_By_Cumulants(deriv As Integer, Order As Integer, s As Arb, kappa As ArbMat)
        Dim s1 = aflint.t("1")
        Dim sum = aflint.t("0")
        If deriv > 0 Then
            sum = kappa(deriv)
        End If
        Dim count As Int32
        For i = 1 To Order - deriv
            count = count + 1
            s1 = s1 * s
            Dim k = kappa(i + deriv)
            Dim summand = k * s1 / aflint.gamma(i + 1)
            sum = sum + summand
            'Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
            If ((i Mod 2) = 0) Then
                Dim RelErr = summand / sum
                'Console.WriteLine("RelErr: {0}", RelErr)
                'If RelErr < aflint.epsilon() Then Exit For
                If RelErr < aflint.epsilon() Then Exit For
            End If
        Next i
        Console.WriteLine("count: {0}", count)
        Console.WriteLine("result1: {0}", sum)
    End Sub

    Sub Demo_CGF_By_Cumulants()
        ArbPrec.SetDps(60)
        Dim s, nu, lambda As Arb
        Dim Order As Integer
        Order = 300
        nu = aflint.t(5000)
        lambda = aflint.t(0)
        s = aflint.t("0.3")

        Dim kappa As New ArbMat()
        aflint_NoncentralChi2_Cumulants(Order, nu, lambda, kappa)
        Dim deriv = 3
        aflint_NoncentralChi2_CGF_By_Cumulants(deriv, Order, s, kappa)

        Dim result2 = aflint_NonCentralChi2_CGF_Derivative(s, nu, lambda, deriv)
        Console.WriteLine("result2: {0}", result2)
    End Sub


    Sub Demo_Saddlepoint_By_Cumulants()
        ArbPrec.SetDps(60)
        Dim s, nu, lambda As Arb
        Dim Order As Integer
        Order = 300
        nu = aflint.t(50)
        lambda = aflint.t(10)
        Dim deriv = 1
        Dim x = aflint.t("40.3")

        For i = -10 To 10
            s = aflint.t(i) / 11
            Dim result2 = aflint_NonCentralChi2_CGF_Derivative(s, nu, lambda, deriv)
            result2 = result2 - x
            Console.WriteLine("s: {0}, result2: {1}", s, result2)
        Next

        s = -(1 / (4 * x)) * (nu - 2 * x + aflint.sqrt(nu * nu + 4 * x * lambda))
        Console.WriteLine("s: {0}", s)


    End Sub











    Sub CornishEdgeworthDemoArb()
        ArbPrec.SetDps(760)

        'Dim i As Integer
        Dim mean As Arb, x As Arb, sigma As Arb, nu As Arb, lambda As Arb
        Dim LeftTail As Arb, RightTail As Arb ', density As Arb
        Dim Order As Integer
        Order = 200
        nu = aflint.t(5000)
        lambda = aflint.t(0)
        LeftTail = aflint.t("1E-16")
        RightTail = 1 - LeftTail

        'aflint.swap(LeftTail, RightTail)
        Console.WriteLine("Target LeftTail: {0}, Target RightTail: {1}", LeftTail, RightTail)


        Dim kappa As New ArbMat()
        aflint_NoncentralChi2_Cumulants(Order, nu, lambda, kappa)


        'aflint.mat_resize(kappa, Order + 1, 1)
        'kappa(1) = nu + lambda
        'For i = 2 To Order
        '    kappa(i) = kappa(i - 1) * 2 * (i - 1) * (1 + lambda / (nu + (i - 1) * lambda))
        'Next i



        mean = kappa(1)
        Console.WriteLine("mean: {0}", mean)

        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("sigma: {0}", sigma)


        x = ndisxArb(LeftTail, RightTail)
        Console.WriteLine("")

        Dim XAdj = CFArb_Continuous(Order - 2 * 0, x, kappa, aflint.t("1E-40"))
        Dim Quantile = mean + sigma * XAdj
        Console.WriteLine("(mean + sigma * XAdj): {0}", Quantile)

        'Quantile = aflint.floor(Quantile)
        Console.WriteLine("Quantile1: {0}", Quantile)

        Quantile = Quantile.Supremum

        Console.WriteLine("Quantile2: {0}", Quantile)


        Dim LeftTail1, RightTail1, density As New Arb
        Cdisn_Penev(nu.AsDouble, Quantile.AsDouble, lambda.AsDouble, LeftTail1.AsDouble, RightTail1.AsDouble)
        Console.WriteLine("LeftTail1: {0}, RightTail1: {1}", LeftTail1, RightTail1)

        cdis2Arb(nu, Quantile, LeftTail1, RightTail1, density)
        'cdis2Arb(F, aflint.t("51184"), LeftTail1, RightTail1, density)
        Console.WriteLine("LeftTail1: {0}, RightTail1: {1}, density: {2},", LeftTail1, RightTail1, density)

    End Sub



    Function InvCornArbContinuous(fxTarget As Arb, x3Start As Arb, kappa As ArbMat, nord As Integer, TargetError As Arb) As Arb
        Dim RelErrorEst As New Arb
        Dim x1 As New Arb, x2 As New Arb, x3 As New Arb, fx1 As New Arb, fx2 As New Arb, fx3 As New Arb
        fxTarget = fxTarget.Mid
        x2 = x3Start * aflint.t("0.9999")
        fx2 = CFArb_Continuous(nord - 2, x2, kappa, TargetError).Mid
        Dim i As Int32 = 0
        Do
            If (i = 0) Then x3 = x3Start.Mid Else x3 = (x1 - ((x2 - x1) / (fx2 - fx1)) * (fx1 - fxTarget)).Mid
            fx3 = CFArb_Continuous(nord - 2, x3, kappa, TargetError).Mid
            RelErrorEst = aflint.abs((fx3 - fxTarget) / fxTarget)
            Console.WriteLine("i: {0}, RelErrorEst: {1}", i, RelErrorEst)
            x1 = x2.Mid : x2 = x3.Mid : fx1 = fx2.Mid : fx2 = fx3.Mid
            i = i + 1
            'Loop Until ((RelErrorEst < aflint.t("1E-45")) Or (i > 100))
        Loop Until ((RelErrorEst < TargetError) Or (i > 100))
        Return x3
    End Function



    Public Function CFArb_Continuous(nord As Integer, X As Arb, kappa As ArbMat, TargetError As Arb) As Arb
        ' Calculates adjustments for Cornish expansion
        Dim a As New ArbMat, d As New ArbMat, h As New ArbMat, p As New ArbMat
        Dim j As Integer, ja As Integer, jal As Integer, jb As Integer, jbl As Integer, k As Integer, L As Integer
        Dim aa As New Arb, bc As New Arb, cc As New Arb, DD As New Arb, fac As New Arb

        Dim i As Integer, Sigma As New Arb, S2 As New Arb, ac As New ArbMat(), del As New ArbMat()
        ac.Resize(nord + 1, 1)
        del.Resize(nord + 1, 1)
        Sigma = aflint.sqrt(kappa(2))
        S2 = Sigma * Sigma
        For i = 3 To nord
            S2 = S2 * Sigma
            ac(i - 2) = kappa(i) / S2
            'Console.WriteLine("i: {0}, kappa(i): {1}, ac(i - 2): {2}", i, kappa(i), ac(i - 2))
        Next i

        a.Resize(nord + 1, 1)
        d.Resize(nord + 1, 1)
        h.Resize(3 * nord + 3, 1)
        p.Resize((3 * nord + 3) * (nord + 1 + 1) \ 2, 1)
        Dim Xadj As New Arb, dXadj As New Arb, LowestXadj As New Arb, LowestdXadj As New Arb
        Dim NoConvergence As Boolean = False
        Dim LowestXAdjPos As Int32 = 0
        Dim PosDiffMax As Int32 = 18
        'Xadj = X
        LowestXadj = X
        LowestdXadj = aflint.t(100)

        'Console.WriteLine("X: {0}", X)

        cc = aflint.t(-1)
        For j = 1 To nord
            a(j) = cc * ac(j) / ((j + 1) * (j + 2))
            cc = -cc
            'Console.WriteLine("j: {0}, a(j): {1}", j, a(j))
        Next j
        h(1) = -X
        h(2) = X * X - 1
        For j = 3 To 3 * nord
            h(j) = -(X * h(j - 1) + (j - 1) * h(j - 2))
        Next j
        For j = 1 To 3 * nord * (nord + 1) \ 2
            p(j) = aflint.t(0)
        Next j
        d(1) = -a(1) * h(2)
        del(1) = d(1)
        Xadj = X + del(1) ' New
        p(1) = d(1)
        p(3) = a(1)
        ja = 0
        fac = aflint.t(1)

        j = 1
        Do
            j = j + 1
            fac = fac * j
            ja = ja + 3 * (j - 1)
            jb = ja
            bc = aflint.t(1)
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
            d(j) = aflint.t(0)
            For L = 2 To 3 * j
                Dim temp = p(ja + L) * h(L - 1)
                d(j) = d(j) - temp
            Next L
            p(ja + 1) = d(j)
            del(j) = d(j) / fac
            'Console.WriteLine("del(j): {0}, fac: {1}", del(j), fac)


            If (aflint.abs(del(j)) > aflint.t(0)) Then
                Xadj = Xadj + del(j)
                dXadj = del(j) / Xadj
                If (aflint.abs(dXadj) < aflint.abs(LowestdXadj)) Then
                    If (j >= 6) Then
                        LowestdXadj = dXadj
                        LowestXadj = Xadj
                        LowestXAdjPos = j
                    End If
                End If
                'Console.WriteLine(" j: {0}, Xadj: {1}, dXadj: {2},  LowestXAdjPos: {3},  PosDiff: {4}", j, Xadj, dXadj, LowestXAdjPos, j - LowestXAdjPos)
            End If
            'Next j
            'If (aflint.abs(dXadj) > aflint.t("0.4")) Then NoConvergence = True

            'Loop Until (j >= nord) Or (aflint.abs(dXadj) < aflint.t("1E-18") Or ((j - LowestXAdjPos) > PosDiffMax) Or NoConvergence)
        Loop Until (j >= nord - 2) Or (aflint.abs(dXadj) < TargetError Or ((j - LowestXAdjPos) > PosDiffMax) Or NoConvergence)

        Console.WriteLine(" LowestXAdjPos: {0}, LowestXadj: {1}, LowestdXadj: {2},  ", LowestXAdjPos, LowestXadj, LowestdXadj)
        'If (aflint.abs(LowestdXadj) > aflint.t("1E-5") And (nord > 8)) Then NoConvergence = True
        'If (aflint.abs(LowestdXadj) > aflint.t("1E-1") And (nord > 8)) Then NoConvergence = True
        If NoConvergence Then Xadj = aflint.nan()
        Return Xadj
    End Function



    Public Function CFArb(nord As Integer, X As Arb, kappa As ArbMat) As Arb
        ' Calculates adjustments for Cornish expansion
        Dim a As New ArbMat, d As New ArbMat, h As New ArbMat, p As New ArbMat
        Dim j As Integer, ja As Integer, jal As Integer, jb As Integer, jbl As Integer, k As Integer, L As Integer
        Dim aa As New Arb, bc As New Arb, cc As New Arb, DD As New Arb, fac As New Arb

        Dim i As Integer, Sigma As New Arb, S2 As New Arb, ac As New ArbMat(), del As New ArbMat()
        ac.Resize(nord + 1, 1)
        del.Resize(nord + 1, 1)
        Sigma = aflint.sqrt(kappa(2))
        S2 = Sigma * Sigma
        For i = 3 To nord
            S2 = S2 * Sigma
            ac(i - 2) = kappa(i) / S2
            'Console.WriteLine("i: {0}, kappa(i): {1}, ac(i - 2): {2}", i, kappa(i), ac(i - 2))
        Next i

        a.Resize(nord + 1, 1)
        d.Resize(nord + 1, 1)
        h.Resize(3 * nord + 3, 1)
        p.Resize((3 * nord + 3) * (nord + 1 + 1) \ 2, 1)
        Dim Xadj As New Arb, dXadj As New Arb, LowestXadj As New Arb, LowestdXadj As New Arb
        Dim NoConvergence As Boolean = False
        Dim LowestXAdjPos As Int32 = 0
        Dim PosDiffMax As Int32 = 18
        'Xadj = X
        LowestXadj = X
        LowestdXadj = aflint.t(100)

        Console.WriteLine("X: {0}", X)

        cc = aflint.t(-1)
        For j = 1 To nord
            a(j) = cc * ac(j) / ((j + 1) * (j + 2))
            cc = -cc
            'Console.WriteLine("j: {0}, a(j): {1}", j, a(j))
        Next j
        h(1) = -X
        h(2) = X * X - 1
        For j = 3 To 3 * nord
            h(j) = -(X * h(j - 1) + (j - 1) * h(j - 2))
        Next j
        For j = 1 To 3 * nord * (nord + 1) \ 2
            p(j) = aflint.t(0)
        Next j
        d(1) = -a(1) * h(2)
        del(1) = d(1)
        Xadj = X + del(1) ' New
        p(1) = d(1)
        p(3) = a(1)
        ja = 0
        fac = aflint.t(1)

        j = 1
        Do
            j = j + 1
            fac = fac * j
            ja = ja + 3 * (j - 1)
            jb = ja
            bc = aflint.t(1)
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
            d(j) = aflint.t(0)
            For L = 2 To 3 * j
                Dim temp = p(ja + L) * h(L - 1)
                d(j) = d(j) - temp
            Next L
            p(ja + 1) = d(j)
            del(j) = d(j) / fac
            'Console.WriteLine("del(j): {0}, fac: {1}", del(j), fac)


            If (aflint.abs(del(j)) > aflint.t(0)) Then
                Xadj = Xadj + del(j)
                dXadj = del(j) / Xadj
                If (aflint.abs(dXadj) < aflint.abs(LowestdXadj)) Then
                    If (j >= 6) Then
                        LowestdXadj = dXadj
                        LowestXadj = Xadj
                        LowestXAdjPos = j
                    End If
                End If
                Console.WriteLine(" j: {0}, Xadj: {1}, dXadj: {2},  LowestXAdjPos: {3},  PosDiff: {4}", j, Xadj, dXadj, LowestXAdjPos, j - LowestXAdjPos)
            End If
            'Next j
            If (aflint.abs(dXadj) > aflint.t("0.4")) Then NoConvergence = True

            'Loop Until (j >= nord) Or (aflint.abs(dXadj) < aflint.t("1E-18") Or ((j - LowestXAdjPos) > PosDiffMax) Or NoConvergence)
        Loop Until (j >= nord - 2) Or (aflint.abs(dXadj) < aflint.t("1E-18") Or ((j - LowestXAdjPos) > PosDiffMax) Or NoConvergence)

        Console.WriteLine(" LowestXAdjPos: {0}, LowestXadj: {1}, LowestdXadj: {2},  ", LowestXAdjPos, LowestXadj, LowestdXadj)
        'If (aflint.abs(LowestdXadj) > aflint.t("1E-5") And (nord > 8)) Then NoConvergence = True
        If (aflint.abs(LowestdXadj) > aflint.t("1E-1") And (nord > 8)) Then NoConvergence = True
        If NoConvergence Then Xadj = aflint.nan()
        Return Xadj
    End Function



    Function InvCornArb(fxTarget As Arb, x3Start As Arb, kappa As ArbMat, nord As Integer) As Arb
        Dim RelErrorEst As New Arb
        Dim x1 As New Arb, x2 As New Arb, x3 As New Arb, fx1 As New Arb, fx2 As New Arb, fx3 As New Arb
        fxTarget = fxTarget.Mid
        x2 = x3Start * aflint.t("0.9999")
        fx2 = CFArb(nord - 2, x2, kappa).Mid
        Dim i As Int32 = 0
        Do
            If (i = 0) Then x3 = x3Start.Mid Else x3 = (x1 - ((x2 - x1) / (fx2 - fx1)) * (fx1 - fxTarget)).Mid
            fx3 = CFArb(nord - 2, x3, kappa).Mid
            RelErrorEst = aflint.abs((fx3 - fxTarget) / fxTarget)
            Console.WriteLine("i: {0}, RelErrorEst: {1}", i, RelErrorEst)
            x1 = x2.Mid : x2 = x3.Mid : fx1 = fx2.Mid : fx2 = fx3.Mid
            i = i + 1
        Loop Until ((RelErrorEst < aflint.t("1E-45")) Or (i > 100))
        Return x3
    End Function




    Sub RawToCentralArb(k As Integer, mraw As ArbMat, mu As ArbMat)
        Dim n As Integer, j As Integer
        Dim sign As New Arb, sum As New Arb, prod As New Arb, BK As New Arb
        mraw(0) = aflint.t(1)
        mu(1) = mraw(1)
        For n = 2 To k
            sum = aflint.t(0)
            BK = aflint.t(1)
            prod = aflint.t(1)
            sign = aflint.t(1)
            For j = n To 0 Step -1
                sum = sum + sign * BK * mraw(j) * prod
                BK = BK * aflint.t(j) / aflint.t(n - j + 1)
                sign = -sign
                prod = prod * mu(1)
            Next j
            mu(n) = sum
        Next n
    End Sub

    Sub CentralToRawArb(k As Integer, mraw As ArbMat, mu As ArbMat)
        Dim n As Integer, j As Integer
        Dim sum As New Arb, prod As New Arb, BK As New Arb
        mu(0) = aflint.t(1)
        mraw(1) = mu(1)
        mu(1) = aflint.t(0)
        For n = 2 To k
            sum = aflint.t(0)
            BK = aflint.t(1)
            prod = aflint.t(1)
            For j = 0 To n
                sum = sum + BK * mu(n - j) * prod
                BK = BK * aflint.t(n - j) / aflint.t(j + 1)
                prod = prod * mraw(1)
            Next j
            mraw(n) = sum
        Next n
        mu(1) = mraw(1)
    End Sub

    Sub MomentsToCumulantsArb(n As Integer, mu As ArbMat, kappa As ArbMat)
        ' Calculates cumulants from central moments
        ' Lee, 1992
        Dim r As Integer, j As Integer, sum As New Arb, F As New Arb
        kappa(1) = mu(1)
        For r = 2 To n
            sum = aflint.t(0)
            F = aflint.t(r - 1)
            For j = 2 To r - 2
                sum = sum + F * mu(r - j) * kappa(j)
                F = F * (r - j) / aflint.t(j)
            Next j
            kappa(r) = mu(r) - sum
        Next r
    End Sub


    Sub RawMomentsToCumulantsArb(n As Integer, mu As ArbMat, kappa As ArbMat)
        ' Calculates cumulants from central moments
        ' Lee, 1992
        Dim r As Integer, j As Integer, sum As New Arb, F As New Arb
        kappa(1) = mu(1)
        For r = 2 To n
            sum = aflint.t(0)
            F = aflint.t(1)
            For j = 1 To r - 1
                sum = sum + F * mu(r - j) * kappa(j)
                F = F * (r - j) / aflint.t(j)
            Next j
            kappa(r) = mu(r) - sum
        Next r
    End Sub




    'Get cumulants from discrete null-distribution
    Sub GetCumulantsArb(nl As Integer, maxmoment As Integer, X As ArbMat, kappa As ArbMat)
        Dim S As Integer, i As Integer, j As Integer
        Dim sk As New Arb, mu As New ArbMat
        S = -nl

        mu.Resize(maxmoment + 1, 1)
        kappa.Resize(maxmoment + 1, 1)

        'ReDim mu(maxmoment)
        'ReDim kappa(maxmoment)

        For j = 1 To maxmoment : mu(j) = aflint.t(0) : Next j
        For i = 0 To nl
            sk = aflint.t(1)
            For j = 1 To maxmoment Step 1
                sk = sk * S
                If j Mod 2 = 0 Then mu(j) = mu(j) + X(i) * sk
            Next j
            S = S + 2
        Next i
        Call MomentsToCumulantsArb(maxmoment, mu, kappa)
        '  Debug.Print "Cumulants"
        '  For j = 1 To maxmoment
        '    Debug.Print j, mu(j), kappa(j)
        '  Next j

    End Sub




    Function JTCumArb(j As Integer, k As Integer, ByRef n() As Integer, ByRef m() As Integer) As Arb
        ' Robillard, 1972
        Dim F As New Arb, i As Integer, j2 As Integer, j21 As Integer, k1 As Integer,
          nn As Integer, sum As New Arb
        nn = m(k)
        k1 = k
        j2 = j
        j21 = j2 + 1
        sum = aflint.t(0)
        F = aflint.t(1)
        For i = 1 To j
            F = F * 2
        Next i
        For i = 1 To k
            'sum = sum + aflint.bernpoly(j21, n(i) + 1)
            'sum = sum + aflint.bernpoly(n(i) + 1, j21)
            sum = sum + aflint.bernpoly(aflint.t(n(i) + 1), j21)
        Next i


        'Return F * aflint.bernoulli(j2) / aflint.t(j2 * j21) _
        '    * (aflint.bernpoly(j21, nn + 1) + (k - 1) * aflint.bernoulli(j21) - sum)

        Return F * aflint.bernoulli(j2) / aflint.t(j2 * j21) _
            * (aflint.bernpoly(aflint.t(nn + 1), j21) + (k - 1) * aflint.bernoulli(j21) - sum)

        '  JTCum = F * Bn0(j2) / (1.0 * j2 * j21) _
        '      * (Bernoulli(j21, nn + 1) + (k - 1) * Bn0(j21) - sum)


    End Function



    Sub TerpstaCumArb(k As Integer, n() As Integer, maxmoment As Integer, kappa As ArbMat, ByRef TS As Integer)
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
            kappa(j) = JTCumArb(j, k, n, m)
            'kappa(j) = JTCum(j, k, n, m)
        Next j
    End Sub



    Sub MannWhitneyCumArb(m As Integer, n As Integer, maxmoment As Integer, kappa As ArbMat, ByRef TS As Integer)
        Dim NN(2) As Integer
        NN(1) = m
        NN(2) = n
        TerpstaCumArb(2, NN, maxmoment, kappa, TS)
    End Sub



    Sub KendallCumArb(n As Integer, maxcum As Integer, kappa As ArbMat, ByRef nl As Integer)
        'Praskova, 1976
        Dim j2 As Integer, j As Integer ', t As Integer, r As Integer
        Dim sign As New Arb, sum As New Arb, sum2 As New Arb, p2 As New Arb
        Dim Bn0j2 As New Arb, Bn0j2_1 As New Arb, Bern As New Arb
        'Dim bn0dblj2 As Double

        maxcum = maxcum \ 2
        For j = 1 To 2 * maxcum
            kappa(j) = aflint.t(0.0)
        Next j
        p2 = aflint.t(0.5)
        For j = 1 To maxcum
            If ((j Mod 2) <> 0) Then sign = aflint.t(1) Else sign = aflint.t(-1)
            j2 = 2 * j
            p2 = p2 * 4

            Bern = aflint.bernpoly(aflint.t(n + 1), j2 + 1)
            Bn0j2_1 = aflint.bernoulli(j2 + 1)
            sum = (Bern - Bn0j2_1) / (j2 + 1)

            '  sum = (aflint.bernpoly(n + 1, j2 + 1) - aflint.bernoulli(j2 + 1)) / (j2 + 1.0)

            'Bn0j2 = aflint.neg(aflint.bernoulli(j2))
            Bn0j2 = aflint.abs(aflint.bernoulli(j2))
            'Bn0j2 = (aflint.bernoulli(j2))

            '  Console.WriteLine("Bern: {0}, Bn0j2_1: {1}, sum: {2}, Bn0j2: {3}", Bern, Bn0j2_1, sum, Bn0j2)


            sum2 = sign * p2 * Bn0j2 * (sum - n) / j
            kappa(j2) = sum2
            '  Console.WriteLine("sign: {0}, p2: {1}, j2: {2}, (sum - n): {3}", sign, p2, j2, (sum - n))
            '  Console.WriteLine("j: {0}, sum: {1}, sum2: {2}, kappa(j): {3}", j, sum, sum2, kappa(j))
            '  Debug.Print j2, "  ", kappa(j2)
        Next j
        nl = n * (n - 1) \ 2
    End Sub



    Sub WilcoxonCumArb(n As Integer, maxcum As Integer, kappa As ArbMat, ByRef nl As Integer)
        ' Fellingham, 1964
        Dim j2 As Integer, j As Integer ', t As Integer, r As Integer
        Dim sum As New Arb, p2 As New Arb
        Dim S As New Arb, sigma2 As New Arb
        maxcum = maxcum \ 2
        For j = 1 To 2 * maxcum
            kappa(j) = aflint.t(0.0)
        Next j
        sigma2 = aflint.t(1.0 * n * (n + 1.0) * (2.0 * n + 1.0)) / aflint.t(6.0)
        kappa(2) = sigma2
        S = sigma2
        p2 = aflint.t(4.0)
        For j = 2 To maxcum
            j2 = 2 * j
            p2 = p2 * 4.0
            sum = aflint.bernpoly(aflint.t(n + 1), j2 + 1)
            sum = sum - aflint.bernoulli(j2 + 1)
            sum = sum / aflint.t(j2 + 1.0)
            S = S * sigma2
            kappa(j2) = p2 * (p2 - 1.0) * (aflint.bernoulli(j2)) * (sum) / aflint.t(j2)
        Next j
        nl = n * (n + 1) \ 2
    End Sub






    Sub PageCumArb(k As Integer, n As Integer, maxmoment As Integer, kappa As ArbMat, ByRef nl As Integer)
        Dim X As New ArbMat, kl As Integer, i As Integer
        Call SpearmanCalcArb(k, 0, kl, X)
        Call GetCumulantsArb(kl, maxmoment, X, kappa)
        For i = 1 To maxmoment : kappa(i) = kappa(i) * n : Next i
        nl = n * kl
        Console.WriteLine("nl: {0}", nl)
    End Sub








    Sub KendallInversCornishDemoArb()

        Dim kappa As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb, LeftTail As New Arb, RightTail As New Arb, TargetLeftTail As New Arb
        Dim n As Int32, nl As Int32, Order As Int32
        Dim CompareToExact As Boolean = True

        ArbPrec.SetDps(240)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        n = 80
        TargetLeftTail = aflint.t("1.0E-5")
        Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

        kappa.Resize(Order + 1, 1)
        Call KendallCumArb(n, Order, kappa, nl)  'Kendall  
        Console.WriteLine("nl: {0}", nl)  ' 3160 for n=80;  16110 for n=180

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        X = KendallCornishArb(n, TargetLeftTail)
        X = aflint.floor(X)
        Console.WriteLine("New X: {0}", X)

        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        z = (X - mean) / sigma
        Console.WriteLine("z: {0}", z)

        LeftTail = GuessLeftTailArb(z, kappa)
        RightTail = 1 - LeftTail
        Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

        Dim fxTarget = z
        Dim x3Start = CF_up(z, kappa)
        Console.WriteLine("fxTarget: {0}", fxTarget)
        Console.WriteLine("x3Start : {0}", x3Start)

        Dim Result As Arb = InvCornArb(fxTarget, x3Start, kappa, Order)
        Console.WriteLine("Result : {0}", Result)
        Console.WriteLine("x3Start: {0}", x3Start)

        LeftTail = NdisArb(Result)
        RightTail = 1 - LeftTail
        Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)

        If CompareToExact Then
            Dim CDF_KR(nl + 1) As Arb
            Dim ExactResult As New Arb, sumKR As New Arb
            Dim KR As New ArbMat
            KR = KendallCalcArb(n)
            i = 0
            For Index = -nl To 0 Step 2
                sumKR = sumKR + KR(i)
                CDF_KR(i) = sumKR
                If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
                i = i + 1
            Next Index
            'Dim xpos As Int32 = (X + nl).ToInt32() \ 2
            Dim xpos As Int32 = aflint.lrint(X + nl) \ 2
            'Dim xpos As Int32 = Convert.ToInt32((X + nl)) \ 2
            ExactResult = CDF_KR(xpos - 1)
            Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos)
            Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult)
        End If

    End Sub

    '


    Sub WilcoxonInversCornishDemoArb()

        Dim kappa As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb, LeftTail As New Arb, RightTail As New Arb, TargetLeftTail As New Arb
        Dim n As Int32, nl As Int32, Order As Int32
        Dim CompareToExact As Boolean = True

        ArbPrec.SetDps(240)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        n = 80
        TargetLeftTail = aflint.t("1.0E-5")
        Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

        kappa.Resize(Order + 1, 1)
        Call WilcoxonCumArb(n, Order, kappa, nl)  'Wilcoxon  
        Console.WriteLine("nl: {0}", nl)  ' 3160 for n=80;  16110 for n=180

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        X = WilcoxonCornishArb(n, TargetLeftTail)
        X = aflint.floor(X)
        Console.WriteLine("New X: {0}", X)

        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        z = (X - mean) / sigma
        Console.WriteLine("z: {0}", z)

        LeftTail = GuessLeftTailArb(z, kappa)
        RightTail = 1 - LeftTail
        Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

        Dim fxTarget = z
        Dim x3Start = CF_up(z, kappa)
        Console.WriteLine("fxTarget: {0}", fxTarget)
        Console.WriteLine("x3Start : {0}", x3Start)

        Dim Result As Arb = InvCornArb(fxTarget, x3Start, kappa, Order)
        Console.WriteLine("Result : {0}", Result)
        Console.WriteLine("x3Start: {0}", x3Start)

        LeftTail = NdisArb(Result)
        RightTail = 1 - LeftTail
        Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)

        If CompareToExact Then
            Dim CDF_KR(nl + 1) As Arb
            Dim ExactResult As New Arb, sumKR As New Arb
            Dim KR As New ArbMat
            KR = WilcoxonCalcArb(n)
            i = 0
            For Index = -nl To 0 Step 2
                sumKR = sumKR + KR(i)
                CDF_KR(i) = sumKR
                If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
                i = i + 1
            Next Index
            'Dim xpos As Int32 = (X + nl).ToInt32() \ 2
            Dim xpos As Int32 = aflint.lrint(X + nl) \ 2
            ExactResult = CDF_KR(xpos - 1)
            Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos)
            Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult)
        End If

    End Sub



    ' Need to make sure that X is even or odd, as appropriate
    Sub MannWhitneyInversCornishDemoArb()

        Dim kappa As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb, LeftTail As New Arb, RightTail As New Arb, TargetLeftTail As New Arb
        Dim m As Int32, n As Int32, nl As Int32, Order As Int32
        Dim CompareToExact As Boolean = True

        ArbPrec.SetDps(240)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        'm = 40
        'n = 60
        m = 30
        n = 30
        TargetLeftTail = aflint.t("1.0E-5")
        Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

        kappa.Resize(Order + 1, 1)
        Call MannWhitneyCumArb(m, n, Order, kappa, nl)  'MannWhitney  
        Console.WriteLine("nl: {0}", nl)  ' 3160 for n=80;  16110 for n=180

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        X = MannWhitneyCornishArb(m, n, TargetLeftTail)
        X = aflint.floor(X)
        Console.WriteLine("New X: {0}", X)

        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        z = (X - mean) / sigma
        Console.WriteLine("z: {0}", z)

        LeftTail = GuessLeftTailArb(z, kappa)
        RightTail = 1 - LeftTail
        Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

        Dim fxTarget = z
        Dim x3Start = CF_up(z, kappa)
        Console.WriteLine("fxTarget: {0}", fxTarget)
        Console.WriteLine("x3Start : {0}", x3Start)

        Dim Result As Arb = InvCornArb(fxTarget, x3Start, kappa, Order)
        Console.WriteLine("Result : {0}", Result)
        Console.WriteLine("x3Start: {0}", x3Start)

        LeftTail = NdisArb(Result)
        RightTail = 1 - LeftTail
        Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)

        If CompareToExact Then
            Dim CDF_KR(nl + 1) As Arb
            Dim ExactResult As New Arb, sumKR As New Arb
            Dim KR As New ArbMat
            KR = MannWhitneyCalcArb(m, n)
            i = 0
            For Index = -nl To 0 Step 2
                sumKR = sumKR + KR(i)
                CDF_KR(i) = sumKR
                If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
                i = i + 1
            Next Index
            'Dim xpos As Int32 = (X + nl).ToInt32() \ 2
            Dim xpos As Int32 = aflint.lrint(X + nl) \ 2
            ExactResult = CDF_KR(xpos - 1)
            Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos)
            Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult)
        End If

    End Sub


    Sub TerpstaInversCornishDemoArb2()
        Dim k As Int32 = 6
        Dim n(k) As Int32
        For i = 1 To k : n(i) = 10 : Next i
        Dim TargetLeftTail = aflint.t("1.0E-5")
        Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)
        InversCornishDemoArb(k, n, TargetLeftTail)
    End Sub

    ' Need to make sure that X is even or odd, as appropriate
    Sub InversCornishDemoArb(m As Int32, n() As Int32, TargetLeftTail As Arb)

        Dim kappa As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb, LeftTail As New Arb, RightTail As New Arb
        Dim nl As Int32, Order As Int32, i As Int32
        Dim CompareToExact As Boolean = True

        ArbPrec.SetDps(240)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        '    m = 6
        '    Dim n(m) As Int32
        '    For i = 1 To m: n(i) = 10: Next i
        '    TargetLeftTail = aflint.t("1.0E-5")
        '    Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)  

        kappa.Resize(Order + 1, 1)
        Call TerpstaCumArb(m, n, Order, kappa, nl)  'Terpsta  
        Console.WriteLine("nl: {0}", nl)  ' 3160 for n=80;  16110 for n=180

        i = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        X = TerpstaCornishArb(m, n, TargetLeftTail)
        X = aflint.floor(X)
        Console.WriteLine("New X: {0}", X)

        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        z = (X - mean) / sigma
        Console.WriteLine("z: {0}", z)

        LeftTail = GuessLeftTailArb(z, kappa)
        RightTail = 1 - LeftTail
        Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

        Dim fxTarget = z
        Dim x3Start = CF_up(z, kappa)
        Console.WriteLine("fxTarget: {0}", fxTarget)
        Console.WriteLine("x3Start : {0}", x3Start)

        Dim Result As Arb = InvCornArb(fxTarget, x3Start, kappa, Order)
        Console.WriteLine("Result : {0}", Result)
        Console.WriteLine("x3Start: {0}", x3Start)

        LeftTail = NdisArb(Result)
        RightTail = 1 - LeftTail
        Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)

        If CompareToExact Then
            Dim CDF_KR(nl + 1) As Arb
            Dim ExactResult As New Arb, sumKR As New Arb
            Dim KR As New ArbMat
            KR = TerpstaCalcArb(m, n)
            i = 0
            For Index = -nl To 0 Step 2
                sumKR = sumKR + KR(i)
                CDF_KR(i) = sumKR
                If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
                i = i + 1
            Next Index
            'Dim xpos As Int32 = (X + nl).ToInt32() \ 2
            Dim xpos As Int32 = aflint.lrint(X + nl) \ 2
            ExactResult = CDF_KR(xpos - 1)
            Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos)
            Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult)
        End If

    End Sub



    ' Need to make sure that X is even or odd, as appropriate
    Sub PageInversCornishDemoArb()

        Dim kappa As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb, LeftTail As New Arb, RightTail As New Arb, TargetLeftTail As New Arb
        Dim m As Int32, n As Int32, nl As Int32, Order As Int32
        Dim CompareToExact As Boolean = True

        ArbPrec.SetDps(240)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        m = 6
        n = 40
        TargetLeftTail = aflint.t("1.0E-5")
        Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

        kappa.Resize(Order + 1, 1)
        Call PageCumArb(m, n, Order, kappa, nl)  'Page  
        Console.WriteLine("nl: {0}", nl)  ' 3160 for n=80;  16110 for n=180

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i

        X = PageCornishArb(m, n, TargetLeftTail)
        X = aflint.floor(X)
        Console.WriteLine("New X: {0}", X)

        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        z = (X - mean) / sigma
        Console.WriteLine("z: {0}", z)

        LeftTail = GuessLeftTailArb(z, kappa)
        RightTail = 1 - LeftTail
        Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

        Dim fxTarget = z
        Dim x3Start = CF_up(z, kappa)
        Console.WriteLine("fxTarget: {0}", fxTarget)
        Console.WriteLine("x3Start : {0}", x3Start)

        Dim Result As Arb = InvCornArb(fxTarget, x3Start, kappa, Order)
        Console.WriteLine("Result : {0}", Result)
        Console.WriteLine("x3Start: {0}", x3Start)

        LeftTail = NdisArb(Result)
        RightTail = 1 - LeftTail
        Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)

        If CompareToExact Then
            Dim CDF_KR(nl + 1) As Arb
            Dim ExactResult As New Arb, sumKR As New Arb
            Dim KR As New ArbMat
            KR = PageCalcArb(m, n, 0)
            i = 0
            For Index = -nl To 0 Step 2
                sumKR = sumKR + KR(i)
                CDF_KR(i) = sumKR
                If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
                i = i + 1
            Next Index
            'Dim xpos As Int32 = (X + nl).ToInt32() \ 2
            Dim xpos As Int32 = aflint.lrint(X + nl) \ 2
            ExactResult = CDF_KR(xpos - 1)
            Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos)
            Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult)
        End If

    End Sub



    Sub KendallCornishDemoArb()
        Dim n As Int32 = 80
        Dim LeftTail As New Arb, Result As New Arb
        LeftTail = aflint.t(0.00000000001)
        Result = KendallCornishArb(n, LeftTail)
        Console.WriteLine("Result: {0}", Result)
    End Sub



    Function KendallCornishArb(n As Int32, TargetLeftTail0 As Arb) As Arb
        Dim kappa As New ArbMat, omega As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb
        Dim RightTail As New Arb, sumKR As New Arb
        Dim Order As Integer
        Dim nl As Int32
        Dim LeftTail As New Arb, TargetLeftTail As New Arb, GuessedQuantile As New Arb

        ArbPrec.SetDps(60)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        n = 80
        kappa.Resize(Order + 1, 1)
        Call KendallCumArb(n, Order, kappa, nl)  'Kendall  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa)
        Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile)

        TargetLeftTail = TargetLeftTail0 / 1000
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(6, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            GuessedQuantile = mean + sigma * XAdj

            Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile)
            'Loop While X.IsNan
        Loop While aflint.isnan(X)


        TargetLeftTail = TargetLeftTail0 / 1000
        Dim fx2 As New Arb
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            '        z = (X - mean) / sigma
            '        Console.WriteLine( "z: {0}", z)
            '        
            '        LeftTail = NdisArb(z)
            '        RightTail = 1-LeftTail
            '        Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(Order - 2, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            fx2 = mean + sigma * XAdj
            Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj)
            'Loop While fx2.IsNan
        Loop While aflint.isnan(fx2)


        'Dim xd As Int32 = fx2.ToInt32
        Dim xd As Int32 = aflint.lrint(fx2)
        If (xd Mod 2) <> 0 Then
            xd = xd - 1
        End If
        X = aflint.t(xd)
        If Math.Abs(xd) > nl Then X = aflint.t(nl)
        Console.WriteLine("X: {0}", X)
        Dim KR As New ArbMat
        KR = KendallCalcArb(n)
        i = 0
        Dim CDF_KR(nl + 1) As Arb
        For Index = -nl To 0 Step 2
            sumKR = sumKR + KR(i)
            CDF_KR(i) = sumKR
            If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
            i = i + 1
        Next Index

        Return fx2
    End Function









    Sub WilcoxonCornishDemoArb()
        Dim n As Int32 = 10
        Dim LeftTail As New Arb, Result As New Arb
        LeftTail = aflint.t(0.00001)
        Result = WilcoxonCornishArb(n, LeftTail)
        Console.WriteLine("Result: {0}", Result)
    End Sub



    Function WilcoxonCornishArb(n As Int32, TargetLeftTail0 As Arb) As Arb
        Dim kappa As New ArbMat, omega As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb
        Dim RightTail As New Arb, sumKR As New Arb
        Dim Order As Integer
        Dim nl As Int32
        Dim LeftTail As New Arb, TargetLeftTail As New Arb, GuessedQuantile As New Arb

        ArbPrec.SetDps(240)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        n = 80
        kappa.Resize(Order + 1, 1)
        Call WilcoxonCumArb(n, Order, kappa, nl)  'Wilcoxon  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa)
        Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile)

        TargetLeftTail = TargetLeftTail0 / 1000
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(6, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            GuessedQuantile = mean + sigma * XAdj

            Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile)
            'Loop While X.IsNan
        Loop While aflint.isnan(X)


        TargetLeftTail = TargetLeftTail0 / 1000
        Dim fx2 As New Arb
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            '        z = (X - mean) / sigma
            '        Console.WriteLine( "z: {0}", z)
            '        
            '        LeftTail = NdisArb(z)
            '        RightTail = 1-LeftTail
            '        Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(Order - 2, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            fx2 = mean + sigma * XAdj
            Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj)
            'Loop While fx2.IsNan
        Loop While aflint.isnan(fx2)

        'Dim xd As Int32 = fx2.ToInt32
        Dim xd As Int32 = aflint.lrint(fx2)
        If (xd Mod 2) <> 0 Then
            xd = xd - 1
        End If
        X = aflint.t(xd)
        If Math.Abs(xd) > nl Then X = aflint.t(nl)
        Console.WriteLine("X: {0}", X)
        Dim KR As New ArbMat
        KR = WilcoxonCalcArb(n)
        i = 0
        Dim CDF_KR(nl + 1) As Arb
        For Index = -nl To 0 Step 2
            sumKR = sumKR + KR(i)
            CDF_KR(i) = sumKR
            If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
            i = i + 1
        Next Index

        Return fx2
    End Function



    Sub MannWhitneyCornishDemoArb()
        Dim m As Int32 = 30
        Dim n As Int32 = 30

        Dim LeftTail As New Arb, Result As New Arb
        'LeftTail = aflint.t(0.001)
        LeftTail = aflint.t(0.95325)
        Result = MannWhitneyCornishArb(m, n, LeftTail)
        Console.WriteLine("Result: {0}", Result)
    End Sub



    Function MannWhitneyCornishArb(m As Int32, n As Int32, TargetLeftTail0 As Arb) As Arb
        Dim kappa As New ArbMat, omega As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb
        Dim RightTail As New Arb, sumKR As New Arb
        Dim Order As Integer
        Dim nl As Int32
        Dim LeftTail As New Arb, TargetLeftTail As New Arb, GuessedQuantile As New Arb

        ArbPrec.SetDps(40)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        kappa.Resize(Order + 1, 1)
        Call MannWhitneyCumArb(m, n, Order, kappa, nl)  'MannWhitney  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa)
        Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile)

        TargetLeftTail = TargetLeftTail0 / 1000
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(6, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            GuessedQuantile = mean + sigma * XAdj

            Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile)
            'Loop While X.IsNan
        Loop While aflint.isnan(X)


        TargetLeftTail = TargetLeftTail0 / 1000
        Dim fx2 As New Arb
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            '        z = (X - mean) / sigma
            '        Console.WriteLine( "z: {0}", z)
            '        
            '        LeftTail = NdisArb(z)
            '        RightTail = 1-LeftTail
            '        Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(Order - 2, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            fx2 = mean + sigma * XAdj
            Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj)
            'Loop While fx2.IsNan
        Loop While aflint.isnan(fx2)


        'Dim xd As Int32 = fx2.ToInt32
        Dim xd As Int32 = aflint.lrint(fx2)
        If (xd Mod 2) <> 0 Then
            xd = xd - 1
        End If
        X = aflint.t(xd)
        If Math.Abs(xd) > nl Then X = aflint.t(nl)
        Console.WriteLine("X: {0}", X)
        Dim KR As New ArbMat
        KR = MannWhitneyCalcArb(m, n)
        i = 0
        Dim CDF_KR(nl + 1) As Arb
        For Index = -nl To 0 Step 2
            sumKR = sumKR + KR(i)
            CDF_KR(i) = sumKR
            If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
            i = i + 1
        Next Index

        Return fx2
    End Function





    Sub TerpstaCornishDemoArb()
        Dim k As Int32 = 3
        Dim n(k) As Int32
        For j = 1 To k : n(j) = 15 : Next j
        Dim LeftTail As New Arb, Result As New Arb
        LeftTail = aflint.t(0.01)
        Result = TerpstaCornishArb(k, n, LeftTail)
        Console.WriteLine("Result: {0}", Result)
    End Sub



    Function TerpstaCornishArb(m As Int32, n() As Int32, TargetLeftTail0 As Arb) As Arb
        Dim kappa As New ArbMat, omega As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb
        Dim RightTail As New Arb, sumKR As New Arb
        Dim Order As Integer
        Dim nl As Int32
        Dim LeftTail As New Arb, TargetLeftTail As New Arb, GuessedQuantile As New Arb

        ArbPrec.SetDps(60)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        kappa.Resize(Order + 1, 1)
        Call TerpstaCumArb(m, n, Order, kappa, nl)  'Terpsta  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa)
        Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile)

        TargetLeftTail = TargetLeftTail0 / 1000
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(6, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            GuessedQuantile = mean + sigma * XAdj

            Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile)
            'Loop While X.IsNan
        Loop While aflint.isnan(X)


        TargetLeftTail = TargetLeftTail0 / 1000
        Dim fx2 As New Arb
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            '        z = (X - mean) / sigma
            '        Console.WriteLine( "z: {0}", z)
            '        
            '        LeftTail = NdisArb(z)
            '        RightTail = 1-LeftTail
            '        Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(Order - 2, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            fx2 = mean + sigma * XAdj
            Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj)
            'Loop While fx2.IsNan
        Loop While aflint.isnan(fx2)


        'Dim xd As Int32 = fx2.ToInt32
        Dim xd As Int32 = aflint.lrint(fx2)
        If (xd Mod 2) <> 0 Then
            xd = xd - 1
        End If
        X = aflint.t(xd)
        If Math.Abs(xd) > nl Then X = aflint.t(nl)
        Console.WriteLine("X: {0}", X)
        Dim KR As New ArbMat
        KR = TerpstaCalcArb(m, n)
        i = 0
        Dim CDF_KR(nl + 1) As Arb
        For Index = -nl To 0 Step 2
            sumKR = sumKR + KR(i)
            CDF_KR(i) = sumKR
            If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
            i = i + 1
        Next Index

        Return fx2
    End Function





    Sub PageCornishDemoArb()
        Dim k As Int32 = 6
        Dim n As Int32 = 40

        Dim LeftTail As New Arb, Result As New Arb
        LeftTail = aflint.t(0.00001)
        Result = PageCornishArb(k, n, LeftTail)
        Console.WriteLine("Result: {0}", Result)
    End Sub



    Function PageCornishArb(m As Int32, n As Int32, TargetLeftTail0 As Arb) As Arb
        Dim kappa As New ArbMat, omega As New ArbMat
        Dim mean As New Arb, X As New Arb, sigma As New Arb, z As New Arb
        Dim RightTail As New Arb, sumKR As New Arb
        Dim Order As Integer
        Dim nl As Int32
        Dim LeftTail As New Arb, TargetLeftTail As New Arb, GuessedQuantile As New Arb

        ArbPrec.SetDps(240)
        Order = 64 '128 '96 '64 '32      ' multiple of 4
        kappa.Resize(Order + 1, 1)
        Call PageCumArb(m, n, Order, kappa, nl)  'Page  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            '      Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
            If (i > 0) Then kappa(i) = kappa(i) - d * aflint.bernoulli(i) / i
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        mean = kappa(1)
        sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)

        GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa)
        Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile)

        TargetLeftTail = TargetLeftTail0 / 1000
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(6, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            GuessedQuantile = mean + sigma * XAdj

            Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile)
            'Loop While X.IsNan
        Loop While aflint.isnan(X)


        TargetLeftTail = TargetLeftTail0 / 1000
        Dim fx2 As New Arb
        Do
            TargetLeftTail = TargetLeftTail * 1000
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)

            '        z = (X - mean) / sigma
            '        Console.WriteLine( "z: {0}", z)
            '        
            '        LeftTail = NdisArb(z)
            '        RightTail = 1-LeftTail
            '        Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

            X = ndisxArb(TargetLeftTail, 1 - TargetLeftTail)
            Dim XAdj = CFArb(Order - 2, X, kappa)
            Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj)
            fx2 = mean + sigma * XAdj
            Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj)
            'Loop While fx2.IsNan
        Loop While aflint.isnan(fx2)


        'Dim xd As Int32 = fx2.ToInt32
        Dim xd As Int32 = aflint.lrint(fx2)
        If (xd Mod 2) <> 0 Then
            xd = xd - 1
        End If
        X = aflint.t(xd)
        If Math.Abs(xd) > nl Then X = aflint.t(nl)
        Console.WriteLine("X: {0}", X)
        Dim KR As New ArbMat
        KR = PageCalcArb(m, n, 0)
        i = 0
        Dim CDF_KR(nl + 1) As Arb
        For Index = -nl To 0 Step 2
            sumKR = sumKR + KR(i)
            CDF_KR(i) = sumKR
            If (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20)) Then Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR(i))
            i = i + 1
        Next Index

        Return fx2
    End Function



    ' ********************************************************************************************************************************************
    ' ********************************************************************************************************************************************
    ' ********************************************************************************************************************************************



    Private Sub perm2Arb(pprob As ArbMat, X() As Integer, n As Integer, m As Integer, ByRef panz As Integer, ByRef success As Boolean)
        Dim ic(0 To 1024) As Integer, ir(0 To 1024) As Integer, ira(0 To 1024) As Integer
        Dim i1 As Integer, j3 As Integer
        Dim i As Integer, L As Integer, j As Integer, k As Integer
        Dim ici As Integer, il As Integer, ih As Integer, iminm As Integer
        Dim icm As Integer, irl As Integer, l2 As Integer, ib As Integer, jb As Integer
        Dim je As Integer, icj As Integer
        Dim pcum As New Arb, ai As New Arb, msum As New Arb, asum As New Arb
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

        '  Dim a(ASize) As Double

        Dim a As New ArbMat()
        a.Resize(ASize + 1, 1)

        For i = 1 To icm
            a(i) = aflint.t(0)
        Next i
        a(1) = aflint.t(1)
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

        asum = aflint.t(1)
        msum = aflint.t(1)
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
        pcum = aflint.t(0)
        panz = qmax - qmin

        '  ReDim pprob(panz)

        '  Dim a As New ArbMat()
        pprob.Resize(panz + 1, 1)

        For i = 1 To qmax - qmin + 1
            i1 = i - 1
            ai = a(i)
            pprob(i1) = ai
            pcum = pcum + ai
        Next i
        success = True
    End Sub






    Function TerpstaCalcArb(k As Integer, n As Integer()) As ArbMat

        Dim panz As Integer
        Dim X() As Integer
        Dim TS As Integer, j As Integer, i4 As Integer, i2 As Integer, success As Boolean
        Dim qanz As Integer, i As Integer ', t As Integer, success As Boolean

        Dim pneu As New ArbMat(), qprob As New ArbMat(), pprob As New ArbMat()

        Dim m(k + 1) As Integer
        m(0) = 0
        For j = 1 To k : m(j) = m(j - 1) + n(j) : Next j
        TS = 0
        For j = 1 To k - 1 : TS = TS + m(j) * n(j + 1) : Next j

        pneu.Resize(TS + 3, 1) '  ReDim pneu(TS + 2)
        ReDim X(m(k) + 2)

        For i = 1 To m(k) : X(i) = i : Next i

        't = 0
        Call perm2Arb(pprob, X, m(2), m(1), panz, success)
        For j = 3 To k
            Call perm2Arb(qprob, X, m(j), m(j - 1), qanz, success)
            For i = 0 To qanz + panz
                pneu(i) = aflint.t(0)
            Next i
            For i = 0 To qanz
                For i2 = 0 To panz
                    i4 = i + i2
                    pneu(i4) = pneu(i4) + pprob(i2) * qprob(i)
                Next i2
            Next i
            panz = panz + qanz

            '    If j = 3 Then ReDim pprob(TS + 2)
            If j = 3 Then pprob.Resize(TS + 3, 1)

            For i = 0 To panz
                pprob(i) = pneu(i)
            Next i
        Next j
        '  ReDim Preserve pprob(panz)
        'pprob.conservative_resize(panz + 1, 1)
        pprob.ConservativeResize(panz + 1, 1)
        success = True
        Return pprob
    End Function



    Function MannWhitneyCalcArb(m As Integer, n As Integer) As ArbMat
        Dim NN(2) As Integer
        NN(1) = m
        NN(2) = n
        Return TerpstaCalcArb(2, NN)
    End Function

    Function MannWhitneyCalcArb2(m As Integer, n As Integer) As ArbMat
        Dim panz As Integer, success As Boolean
        Dim X() As Integer
        ReDim X(m + n + 2)
        For i = 1 To m + n : X(i) = i : Next i
        Dim pprob As New ArbMat()
        perm2Arb(pprob, X, m + n, n, panz, success)
        Return pprob
    End Function




    Function KendallCalcArb(n As Integer) As ArbMat
        Dim nl As Integer ', y() As Double , X() As Double
        Dim nmax As Integer, it As Integer
        Dim mitte As Integer, limit As Integer, j As Integer, i As Integer
        Dim yy As New Arb
        Dim permanz As New Arb ', SD As Double, p As Double
        nmax = n * (n - 1) + 1


        Dim X As New ArbMat()
        X.Resize(nmax + 3, 1)

        Dim y As New ArbMat()
        y.Resize(nmax + 3, 1)

        '  Dim X(nmax + 2) As Double
        '  Dim y(nmax + 2) As Double
        '  SD = Math.Sqrt(2 * (2 * n + 5) / (9 * n * (n - 1)))
        permanz = aflint.t(1)
        X(1) = permanz
        nl = 1
        For it = 2 To n
            'Console.WriteLine("it: {0}", it)
            permanz = permanz * it
            nl = nl + it - 1
            '    p = 0
            mitte = (nl + 1) \ 2
            For i = 1 To nl
                y(i) = aflint.t(0)
            Next i
            For i = mitte To 1 Step -1
                'Console.WriteLine("i: {0}", i)
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
        permanz = aflint.t(1) : For i = 2 To n : permanz = permanz * i : Next i
        For i = 1 To nl : X(i - 1) = X(i) / permanz : Next i : nl = nl - 1
        'X.conservative_resize(nl + 1, 1)
        X.ConservativeResize(nl + 1, 1)
        '  ReDim Preserve X(nl)
        Return X
    End Function





    Sub SpearmanCalcArb(n As Integer, Order As Integer, ByRef Valcount As Integer, xx As ArbMat)
        Dim X() As Integer, y() As Integer, p() As Integer, d() As Integer, result() As Integer
        Dim i As Integer, nn As Integer, count As Integer, sum As Integer, k As Integer
        Dim Q As Integer, Upper As Integer, lower As Integer, t As Integer

        Dim fraction As New Arb
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

        '    aflint.mat_resize(result, Valcount + 1, 1) ' ReDim result(Valcount)

        ReDim result(Valcount)
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

        xx.Resize(Valcount + 1, 1) ' ReDim xx(Valcount)
        For i = 0 To Valcount
            fraction = aflint.t(result(i)) / aflint.t(count)
            Console.WriteLine(" i: {0}, fraction: {1}", i, fraction)
            xx(i) = fraction
        Next i

    End Sub




    Function PageQuadeCalcArb(UseRanks As Boolean, k As Integer, n As Integer, Order As Integer) As ArbMat
        Dim h As Integer, pl As Integer, j As Integer, i As Integer, F As Integer, ql As Integer
        Dim p As New ArbMat(), r As New ArbMat(), Q As New ArbMat()
        If UseRanks Then F = n * (n + 1) \ 2 Else F = n
        Call SpearmanCalcArb(k, Order, pl, p)

        Q.Resize(pl * F + 1, 1) ' ReDim Q(pl * F)
        r.Resize(pl * F + 1, 1) ' ReDim r(pl * F)

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
            For i = 0 To ql : Q(i) = r(i) : r(i) = aflint.t(0) : Next i
        Next h
        Return Q
    End Function



    ' ********************************************************************************************************************************************
    ' ********************************************************************************************************************************************
    ' ********************************************************************************************************************************************


    Function PageCalcArb(k As Integer, N As Integer, ByRef Order As Integer) As ArbMat
        Return PageQuadeCalcArb(False, k, N, Order)
    End Function



    Function PageQuadeCalcArb(k As Integer, N As Integer, ByRef Order As Integer) As ArbMat
        Return PageQuadeCalcArb(True, k, N, Order)
    End Function


    Function WilcoxonCalcArb(N As Integer) As ArbMat
        Return PageQuadeCalcArb(True, 2, N, 0)
    End Function


    Function SignCalcArb(N As Integer) As ArbMat
        Return PageQuadeCalcArb(False, 2, N, 0)
    End Function


    Sub DemoPageCalcArb()
        Dim k, N, Order, nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(40)
        k = 5
        N = 8
        Order = 0
        x = PageCalcArb(k, N, Order)
        nl = x.rows - 1
        For i = 0 To nl
            Console.WriteLine("i: {0}, x(i): {1}", i, x(i))
        Next
    End Sub


    Sub DemoQuadePageCalcArb()
        Dim k, N, Order, nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(40)
        k = 3
        N = 10
        Order = 0
        x = PageQuadeCalcArb(k, N, Order)
        nl = x.rows - 1
        For i = 0 To nl
            Console.WriteLine("i: {0}, x(i): {1}", i, x(i))
        Next
    End Sub



    Sub DemoSignCalcArb()
        Dim N, nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(40)
        N = 30
        x = SignCalcArb(N)
        nl = x.rows - 1
        For i = 0 To nl
            Console.WriteLine("i: {0}, x(i): {1}", i, x(i))
        Next
    End Sub


    Sub DemoMannWhitneyCalcArb()
        Dim m, n, nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(40)
        m = 30
        n = 30
        'x = MannWhitneyCalcArb(m, n)
        x = MannWhitneyCalcArb2(m, n)
        nl = x.rows - 1
        For i = 0 To nl
            Console.WriteLine("i: {0}, x(i): {1}", i, x(i))
        Next
    End Sub


    Sub DemoMannWhitneyCalcArb2(xvalue As Int32)
        Dim m, n, nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(80)
        m = 60
        n = 60
        x = MannWhitneyCalcArb(m, n)
        nl = x.rows - 1
        Dim sum = aflint.t("0")
        For i = 0 To nl
            sum = sum + x(i)
            Dim j = 2 * (i - nl \ 2)
            If Math.Abs(Math.Abs(j) - Math.Abs(xvalue)) < 10 Then
                Console.WriteLine("i: {0}, x(i): {1}, sum: {2}", j, x(i), sum)
            End If
        Next
    End Sub


    Sub DemoTerpstaCalcArb()
        Dim k, nl As Integer
        'Dim x As New ArbMat()
        ArbPrec.SetDps(25)
        k = 5
        Dim n(k) As Integer
        For j = 1 To k
            n(j) = 8
        Next j
        Dim x = TerpstaCalcArb(k, n)
        nl = x.rows - 1
        For i = 0 To nl
            Console.WriteLine("i: {0}, x(i): {1}", i, x(i))
        Next
    End Sub


    Sub DemoKendallCalcArb()
        Dim N, nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(40)
        N = 20
        x = KendallCalcArb(N)
        nl = x.rows - 1
        For i = 0 To nl
            Console.WriteLine("i: {0}, x(i): {1}", i, x(i))
        Next
    End Sub




    Sub DemoWilcoxonCalcArb()
        Dim N, nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(40)
        N = 10
        x = WilcoxonCalcArb(N)
        nl = x.rows - 1
        For i = 0 To nl
            Console.WriteLine("i: {0}, x(i): {1}", i, x(i))
        Next
    End Sub


    Sub DemoWilcoxonCalcArb2(xvalue As Int32)
        Dim N, nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(40)
        N = 80
        x = WilcoxonCalcArb(N)
        nl = x.rows - 1
        Dim sum = aflint.t("0")
        For i = 0 To nl
            Dim j = i - (N * (N + 1)) \ 4
            sum = sum + x(i)
            If Math.Abs(2 * Math.Abs(j) - Math.Abs(xvalue)) < 10 Then
                Console.WriteLine("i: {0}, x(i): {1}, sum: {2}", 2 * j, x(i), sum)
            End If
        Next
    End Sub


    Sub DemoWilcoxonCalcArb3(N As Int32, xvalue As Int32)
        Dim nl As Integer
        Dim x As New ArbMat()
        ArbPrec.SetDps(40)
        'N = 80
        x = WilcoxonCalcArb(N)
        nl = x.rows - 1
        Dim sum = aflint.t("0")
        For i = 0 To nl
            Dim j = i - (N * (N + 1)) \ 4
            sum = sum + x(i)
            If Math.Abs(2 * Math.Abs(j) - Math.Abs(xvalue)) < 10 Then
                Console.WriteLine("i: {0}, x(i): {1}, sum: {2}", 1 * j, x(i), sum)
            End If
        Next
    End Sub


    Sub aflint_MannWhitney_Cumulants(Order As Integer, m As Int32, n As Int32, kappa As ArbMat)
        Dim nl As Int32
        kappa.Resize(Order + 1, 1)
        Call MannWhitneyCumArb(m, n, Order, kappa, nl)  'MannWhitney  
        'Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            Dim adj = d * aflint.bernoulli(i) / i
            If (i = 1) Or (i Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
            End If
            If (i > 0) Then kappa(i) = (kappa(i) - adj) / (2 ^ i)
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        Dim mean = kappa(1)
        Dim sigma = aflint.sqrt(kappa(2))
        'Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
    End Sub




    Sub aflint_MannWhitney_Cumulants_Raw(Order As Integer, m As Int32, n As Int32, kappa As ArbMat)
        Dim nl As Int32
        kappa.Resize(Order + 1, 1)
        Call MannWhitneyCumArb(m, n, Order, kappa, nl)  'MannWhitney  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            'Dim adj = d * aflint.bernoulli(i) / i
            Dim adj = 0
            If (i = 1) Or (i Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
            End If
            'If (i > 0) Then kappa(i) = kappa(i) - adj
            If (i > 0) Then kappa(i) = kappa(i) / (2 ^ i)
            'Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        Dim mean = kappa(1)
        Dim sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
    End Sub


    Function aflint_MannWhitney_CGF_By_Cumulants(deriv As Integer, Order As Integer, s As Arb, kappa As ArbMat) As Arb
        Dim s1 = aflint.t("1")
        Dim sum = aflint.t("0")
        If deriv > 0 Then
            sum = kappa(deriv)
        End If
        Dim count As Int32
        Dim RelErr = aflint.t("1")
        For i = 1 To Order - deriv
            count = count + 1
            s1 = s1 * s
            Dim k = kappa(i + deriv)
            Dim summand = k * s1 / aflint.gamma(i + 1)
            sum = sum + summand
            If (i = 1) Or ((i + deriv) Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
            End If
            If (((i + deriv) Mod 2) = 0) Then
                RelErr = aflint.abs(summand / sum)
                'Console.WriteLine("RelErr: {0}", RelErr)
                If RelErr < aflint.epsilon() Then Exit For
            End If
        Next i
        'Console.WriteLine("count: {0}", count)
        'Console.WriteLine("result1: {0}", sum)
        Return sum
    End Function


    Function aflint_CGF_Sheppard(deriv As Integer, MaxOrder As Integer, stepsize As Arb, s As Arb) As Arb
        Dim s1 = aflint.t("1")
        Dim sum = aflint.t("0")
        Dim tol = aflint.epsilon()
        MaxOrder = 1000
        If deriv > 0 Then
            sum = aflint.bernoulli(deriv) / (deriv)
        End If
        Dim count As Int32
        Dim RelErr = aflint.t("1")
        Dim d = aflint.t("1")
        For i = 1 To MaxOrder - deriv
            count = count + 1
            d = stepsize * d
            Dim k = d * aflint.bernoulli(i + deriv) / (i + deriv)
            s1 = s1 * s
            Dim summand = k * s1 / aflint.gamma(i + 1)
            sum = sum + summand
            If (((i + deriv) Mod 2) = 0) Then
                RelErr = aflint.abs(summand / sum)
                If RelErr < tol Then Exit For
            End If
        Next i
        'Console.WriteLine("count: {0}", count)
        Return sum
    End Function



    Function Murakami2(m As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, sum, result As New Arb
        Ni = aflint.t(n)
        sum = aflint.t(0)
        For r = 1 To m
            Dim r2 = r * r
            Dim Nir = Ni + r
            Dim a1 = aflint.exp(r * s)
            Dim a2 = 1 - aflint.exp(r * s)
            a2 = a2 * a2
            Dim a3 = 1 - aflint.exp((Nir) * s)
            a3 = a3 * a3
            Dim b1 = aflint.exp(2 * s * (Nir))
            Dim b2 = aflint.exp(Ni * s)
            Dim b3 = aflint.exp(s * (Ni + 2 * r))
            Dim b4 = aflint.exp(s * (Nir))

            Dim f = a1 / (a2 * a3)
            'Dim g = r2 + b1 * r2 - (Nir) ^ 2 * b2 - (Nir) ^ 2 * b3 + 2 * Ni * (Ni + 2 * r) * b4
            Dim g = r2 + b1 * r2 - Nir * Nir * b2 - Nir * Nir * b3 + 2 * Ni * (Ni + 2 * r) * b4
            sum = sum + f * g
        Next
        Return sum
    End Function


    Function Murakami1(m As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, sum, result As New Arb
        Ni = aflint.t(n)
        sum = aflint.t(0)
        For r = 1 To m
            Dim Nir = Ni + r
            Dim a1 = aflint.exp(r * s)
            Dim a2 = 1 - a1
            Dim a3 = 1 - aflint.exp(s * (Nir))

            Dim b1 = aflint.exp(Ni * s)
            Dim b2 = aflint.exp(s * (Nir))

            Dim f = a1 / (a2 * a3)
            Dim g = Ni * b2 + r - Nir * b1
            sum = sum + f * g
        Next
        Return sum
    End Function




    Function Murakami1_new(m As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, sum, result As New Arb
        Ni = aflint.t(n)
        sum = aflint.t(0)
        For r = 1 To m
            Dim b = Ni + r
            Dim ebs = aflint.expm1(b * s)
            Dim sumA = b / ebs
            'Console.WriteLine("sumA2: {0}", sumA)

            Dim ers = aflint.expm1(r * s)
            Dim sumB = (-(b - r) * (ers + 1) + b) / ers
            'Console.WriteLine("sumB2: {0}", sumB)

            sum = sum + sumA - sumB
        Next
        Return sum
    End Function



    Function Murakami2_new(m As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, sum, result As New Arb
        Ni = aflint.t(n)
        sum = aflint.t(0)
        For r = 1 To m
            Dim b = Ni + r
            Dim a = b * b
            Dim ebs = aflint.expm1(b * s)
            Dim sumA = -a / ebs - a / (ebs * ebs)
            'Console.WriteLine("sumA2: {0}", sumA)

            Dim ers = aflint.expm1(r * s)
            a = aflint.t(r * r)
            Dim sumB = -a / ers - a / (ers * ers)
            'Console.WriteLine("sumB2: {0}", sumB)

            sum = sum + sumA - sumB
        Next
        Return sum
    End Function


    Function Murakami2_deriv(deriv As Int32, m As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, result, t, a, z, ar As New Arb
        Dim coeff(20, 20) As Int32
        Dim rsign As Int32 = -1
        Dim d = deriv - 2
        Dim sum(2) As Arb
        sum(0) = aflint.t("0")
        sum(1) = aflint.t("0")
        coeff(0, 1) = 1
        coeff(0, 2) = 1


        Ni = aflint.t(n)
        result = aflint.t(0)
        For r = 1 To m
            Dim b = Ni + r
            For i = 0 To 1
                If (i = 0) Then t = b Else t = aflint.t(r)
                a = t * t
                ar = a * r ^ d
                z = 1 / aflint.expm1(t * s)
                Dim localsum = aflint.t("0")
                For j = 1 To d + 2
                    'localsum = localsum + coeff(d, j) * z ^ j
                    localsum = localsum + coeff(d, j) * aflint.pow(z, j)
                Next
                sum(i) = rsign * ar * localsum

            Next
            result = result + sum(0) - sum(1)
        Next
        Return result
    End Function


    Function Murakami2_deriv2(deriv As Int32, m As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, result, t, a, z, ar As New Arb
        'Dim coeff(20, 20) As Int64
        Dim coeff As New ArbMat()
        'coeff.setZero(deriv + 3, deriv + 3)
        coeff.Resize(deriv + 3, deriv + 3)
        Dim rsign As Int32 = 1
        Dim d = deriv - 2
        Dim sum(2) As Arb
        If (deriv Mod 2) = 0 Then rsign = -1
        sum(0) = aflint.t("0")
        sum(1) = aflint.t("0")
        coeff(0, 1) = aflint.t(1)
        coeff(0, 2) = aflint.t(1)

        For i = 1 To deriv
            coeff(i, 1) = aflint.t(1)
            For j = 2 To deriv + 2
                coeff(i, j) = (j - 1) * coeff(i - 1, j - 1) + j * coeff(i - 1, j)
            Next
        Next

        Ni = aflint.t(n)
        result = aflint.t(0)
        For r = 1 To m
            For i = 0 To 1
                If (i = 0) Then t = Ni + r Else t = aflint.t(r)
                z = 1 / aflint.expm1(t * s)
                Dim localsum = aflint.t("0")
                Dim zj = z
                For j = 1 To deriv
                    localsum = localsum + coeff(d, j) * zj
                    zj = zj * z
                    'Console.WriteLine("deriv: {0}, j: {1}, coeff(i, j): {2}", deriv, j, coeff(d, j))
                Next
                'sum(i) = (t ^ (d + 2)) * localsum
                sum(i) = aflint.pow(t , (d + 2)) * localsum
            Next
            result = result + sum(0) - sum(1)
        Next
        Return rsign * result
    End Function



    Function Murakami0(m As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, sum, result As New Arb
        Ni = aflint.t(n)
        sum = aflint.t(0)
        For r = 1 To m
            Dim Nir = Ni + r
            Dim a1 = 1 - aflint.exp(s * (Nir))
            Dim a2 = 1 - aflint.exp(r * s)

            Dim f = a1 / a2
            Dim g = r / Nir
            sum = sum + aflint.log(f * g)
        Next
        Return sum
    End Function


    Function Murakami(deriv As Int32, m As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, sum, result As New Arb
        If deriv = 0 Then
            result = Murakami0(m, n, s)
            result = result - s * n * m / 2
            Return result
        End If
        If deriv = 1 Then
            result = Murakami1(m, n, s)
            result = result - n * m / 2
            Return result
        Else
            Return Murakami2_deriv2(deriv, m, n, s)
        End If
    End Function



    Sub Demo_MannWhitney_CGF_By_Cumulants()
        ArbPrec.SetDps(150)
        Dim kappa As New ArbMat
        Dim Order = 600 '128 '96 '64 '32      ' multiple of 4
        Dim m = 60
        Dim n = 40
        Dim NN = m + n
        Dim x = aflint.t("600")
        Dim stepsize = aflint.t("1")
        Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2)
        Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12)
        'Dim C = aflint.pi() * aflint.sqrt(1 / aflint.t("12"))
        'Console.WriteLine("C: {0}", C)
        'Dim CN = C * aflint.sqrt(NN)
        'Console.WriteLine("CN: {0}", CN)

        aflint_MannWhitney_Cumulants_Raw(Order, m, n, kappa)
        Dim s = (x - kappa(1)) / kappa(2)
        Console.WriteLine("s: {0}", s)
        Console.WriteLine("Kappa(1): {0}", kappa(1))
        Console.WriteLine("Kappa(2): {0}", kappa(2))


        Dim fx_raw = aflint_MannWhitney_CGF_By_Cumulants(0, Order, s, kappa)
        Console.WriteLine("CGF0 raw : {0}", fx_raw)

        aflint_MannWhitney_Cumulants(Order, m, n, kappa)
        Dim fx_corr = aflint_MannWhitney_CGF_By_Cumulants(0, Order, s, kappa)
        Console.WriteLine("CGF0 shep: {0}", fx_corr)

        Dim fx_diff = aflint_CGF_Sheppard(0, Order, stepsize, s)
        Console.WriteLine("CGF0 corr: {0}", fx_raw - fx_diff)
        Console.WriteLine("CGF0 diff: {0}", fx_diff)



        Console.WriteLine("")
        aflint_MannWhitney_Cumulants_Raw(Order, m, n, kappa)
        Dim fx_raw1 = aflint_MannWhitney_CGF_By_Cumulants(1, Order, s, kappa)
        Console.WriteLine("CGF1 raw : {0}", fx_raw1)

        aflint_MannWhitney_Cumulants(Order, m, n, kappa)
        Dim fx_corr1 = aflint_MannWhitney_CGF_By_Cumulants(1, Order, s, kappa)
        Console.WriteLine("CGF1 shep: {0}", fx_corr1)

        Dim fx_diff1 = aflint_CGF_Sheppard(1, Order, stepsize, s)
        Console.WriteLine("CGF1 corr: {0}", fx_raw1 - fx_diff1)
        Console.WriteLine("CGF1 diff: {0}", fx_diff1)



        Console.WriteLine("")
        aflint_MannWhitney_Cumulants_Raw(Order, m, n, kappa)
        Dim fx_raw2 = aflint_MannWhitney_CGF_By_Cumulants(2, Order, s, kappa)
        Console.WriteLine("CGF2 raw : {0}", fx_raw2)

        aflint_MannWhitney_Cumulants(Order, m, n, kappa)
        Dim fx_corr2 = aflint_MannWhitney_CGF_By_Cumulants(2, Order, s, kappa)
        Console.WriteLine("CGF2 shep: {0}", fx_corr2)

        Dim fx_diff2 = aflint_CGF_Sheppard(2, Order, stepsize, s)
        Console.WriteLine("CGF2 corr: {0}", fx_raw2 - fx_diff2)
        Console.WriteLine("CGF2 diff: {0}", fx_diff2)



        Console.WriteLine("")
        aflint_MannWhitney_Cumulants_Raw(Order, m, n, kappa)
        Dim fx_raw3 = aflint_MannWhitney_CGF_By_Cumulants(3, Order, s, kappa)
        Console.WriteLine("CGF3 raw : {0}", fx_raw3)

        aflint_MannWhitney_Cumulants(Order, m, n, kappa)
        Dim fx_corr3 = aflint_MannWhitney_CGF_By_Cumulants(3, Order, s, kappa)
        Console.WriteLine("CGF3 shep: {0}", fx_corr3)

        Dim fx_diff3 = aflint_CGF_Sheppard(3, Order, stepsize, s)
        Console.WriteLine("CGF3 corr: {0}", fx_raw3 - fx_diff3)
        Console.WriteLine("CGF3 diff: {0}", fx_diff3)


    End Sub



    Sub Demo_MannWhitney_CGF()
        ArbPrec.SetDps(50)
        Dim kappa As New ArbMat
        Dim Order = 600 '128 '96 '64 '32      ' multiple of 4
        Dim m = 60
        Dim n = 40
        Dim NN = m + n
        Dim x = aflint.t("600")
        Dim stepsize = aflint.t("1")
        Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2)
        Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12)

        aflint_MannWhitney_Cumulants(Order, m, n, kappa)
        Dim s = (x - kappa(1)) / kappa(2)
        Console.WriteLine("s: {0}", s)
        Console.WriteLine("Kappa(1): {0}", kappa(1))
        Console.WriteLine("Kappa(2): {0}", kappa(2))

        For j = 0 To 6
            Console.WriteLine("")
            Console.WriteLine("j: {0}", j)

            Dim CGF_cum = aflint_MannWhitney_CGF_By_Cumulants(j, Order, s, kappa)
            Console.WriteLine("CGF cum:  {0}", CGF_cum)

            Dim CGF_raw = Murakami(j, m, n, s)
            Dim CGF_sheppard = aflint_CGF_Sheppard(j, Order, stepsize, s)
            Dim CGF = CGF_raw - CGF_sheppard
            Console.WriteLine("CGF     : {0}", CGF)
            Console.WriteLine("Murakami: {0}", CGF_raw)
            Console.WriteLine("CGF diff: {0}", CGF_sheppard)
        Next

    End Sub



    Function aflint_MannWhitney_CGF(j As Int32, m As Int32, n As Int32, s As Arb, Order As Integer, stepsize As Arb) As Arb
        Dim CGF_raw = Murakami(j, m, n, s)
        Dim CGF_sheppard = aflint_CGF_Sheppard(j, Order, stepsize, s)
        Dim CGF = CGF_raw - CGF_sheppard
        Return CGF
    End Function


    Function MannWhitney_Get_Saddlepoint(m As Int32, n As Int32, x As Arb, Order As Int32, stepsize As Arb) As Arb
        Dim s = aflint.t("0.1")
        Dim RelErr = aflint.t("1")
        Dim tol = aflint.epsilon() * 100
        Do
            Console.WriteLine("s: {0}", s)
            Dim fx = x - aflint_MannWhitney_CGF(1, m, n, s, Order, stepsize)
            Dim dfx = aflint_MannWhitney_CGF(2, m, n, s, Order, stepsize)
            Dim adj = (fx / dfx).Mid
            s = (s + adj).Mid
            RelErr = aflint.abs((adj) / s)
            Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
        Loop Until (RelErr < tol)
        Return s
    End Function


    Function MannWhitney_Get_Saddlepoint_By_Cumulants(x As Arb, Order As Int32, kappa As ArbMat) As Arb
        Dim s = (x - kappa(1)) / kappa(2)
        Dim RelErr = aflint.t("1")
        Do
            'Console.WriteLine("s1: {0}", s)
            Dim deriv = 1
            Dim fx = x - aflint_MannWhitney_CGF_By_Cumulants(1, Order, s, kappa)
            RelErr = aflint.abs((fx) / x)
            'Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
            'Console.WriteLine("fx: {0}", fx)
            Dim dfx = aflint_MannWhitney_CGF_By_Cumulants(2, Order, s, kappa)
            'Console.WriteLine("dfx: {0}", dfx)
            Dim adj = fx / dfx
            'Console.WriteLine("adj: {0}", adj)
            s = s + adj
        Loop Until (RelErr < aflint.epsilon())
        Return s
    End Function


    Sub Demo_MannWhitney_Saddlepoint_By_Cumulants()
        ArbPrec.SetDps(240)
        Dim kappa As New ArbMat

        Dim Order = 800 '128 '96 '64 '32      ' multiple of 4
        Dim m = 60
        Dim n = 40
        Dim NN = m + n
        Dim x = aflint.t("1300")
        x = x / 2
        Dim stepsize = aflint.t("1")
        Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2)
        Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12)


        aflint_MannWhitney_Cumulants(Order, m, n, kappa)
        Dim s = (x - kappa(1)) / kappa(2)
        Dim RelErr = aflint.t("1")
        Do
            'Console.WriteLine("")
            Console.WriteLine("s1: {0}", s)
            Dim deriv = 1
            Dim fx = x - aflint_MannWhitney_CGF_By_Cumulants(1, Order, s, kappa)
            RelErr = aflint.abs((fx) / x)
            Console.WriteLine("fx:        {0}, RelErr: {1}", fx, RelErr)

            Dim k1 = Murakami1(m, n, s)
            k1 = k1 - n * m / 2
            Dim fx_diff1 = aflint_CGF_Sheppard(1, Order, stepsize, s)
            k1 = x - (k1 - fx_diff1)
            Console.WriteLine("CGF1 corr: {0}", k1)
            'Console.WriteLine("CGF1 diff: {0}", fx_diff1)

            Console.WriteLine("")

            Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
            'Console.WriteLine("fx: {0}", fx)
            Dim dfx = aflint_MannWhitney_CGF_By_Cumulants(2, Order, s, kappa)
            Console.WriteLine("dfx:         {0}", dfx)
            Dim k2 = Murakami2(m, n, s)
            Dim fx_diff2 = aflint_CGF_Sheppard(2, Order, stepsize, s)

            Console.WriteLine("Murakami k2: {0}", k2 - fx_diff2)

            Console.WriteLine("")

            'Console.WriteLine("dfx: {0}", dfx)
            Dim adj = fx / dfx
            'Console.WriteLine("adj: {0}", adj)
            s = s + adj
        Loop Until (RelErr < aflint.epsilon())
    End Sub


    Sub Demo_MannWhitney_Saddlepoint_By_CGF()
        ArbPrec.SetDps(240)
        Dim kappa As New ArbMat

        Dim Order = 800 '128 '96 '64 '32      ' multiple of 4
        Dim m = 60
        Dim n = 40
        Dim NN = m + n
        Dim x = aflint.t("2400")
        x = x / 2
        Dim stepsize = aflint.t("1")
        Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2)
        Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12)


        aflint_MannWhitney_Cumulants(Order, m, n, kappa)
        Dim s = (x - kappa(1)) / kappa(2)
        Dim RelErr = aflint.t("1")
        Do
            Console.WriteLine("s1: {0}", s)

            Dim CGF_raw = Murakami(1, m, n, s)
            Dim CGF_sheppard = aflint_CGF_Sheppard(1, Order, stepsize, s)
            Dim k1 = x - (CGF_raw - CGF_sheppard)
            Console.WriteLine("k1: {0}", k1)

            CGF_raw = Murakami(2, m, n, s)
            CGF_sheppard = aflint_CGF_Sheppard(2, Order, stepsize, s)
            Dim k2 = CGF_raw - CGF_sheppard
            Console.WriteLine("k2: {0}", k2)

            Dim fx = k1
            Dim dfx = k2
            RelErr = aflint.abs((fx) / x)
            Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
            'Console.WriteLine("dfx: {0}", dfx)
            Dim adj = fx / dfx
            'Console.WriteLine("adj: {0}", adj)
            s = s + adj
            Console.WriteLine("")

            'Loop Until (RelErr < aflint_get_tol())
        Loop Until (RelErr < aflint.t("1E-40"))
    End Sub



    Sub Demo_MannWhitney_CDF_SPA_By_Cumulants()
        ArbPrec.SetDps(140)
        Dim kappa As New ArbMat
        Dim Order = 100 '128 '96 '64 '32      ' multiple of 4
        Dim m = 60
        Dim n = 40
        Dim NN = m + n
        Dim x = aflint.t("1180")
        x = x / 2
        Dim stepsize = aflint.t("1")
        Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2)
        Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12)


        Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2)

        aflint_MannWhitney_Cumulants(Order, m, n, kappa)
        Dim s = MannWhitney_Get_Saddlepoint_By_Cumulants(x, Order, kappa)
        Console.WriteLine("s: {0}", s)

        Dim K_Order As Int32 = 12
        Dim K(K_Order + 1) As Arb
        For j = 0 To K_Order
            K(j) = aflint_MannWhitney_CGF_By_Cumulants(j, Order, s, kappa)
            Console.WriteLine("j: {0}, K(s): {1}", j, K(j))
        Next

        Console.WriteLine("")
        Dim density, LeftTail, Righttail As New Arb
        aflint_LugannaniRiceNew(K_Order, K, s, density, LeftTail, Righttail)

    End Sub


    Sub Demo_MannWhitney_CDF_SPA()
        ArbPrec.SetDps(50)
        Dim m = 30
        Dim n = 30
        Dim NN = m + n
        'Dim x = aflint.t("3528")
        Dim x = aflint.t("228")
        x = x / 2
        Console.WriteLine("x: {0}", x)
        Dim stepsize = aflint.t("1")
        Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, 2 * x, n * m / 2)
        Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12)

        Dim s = MannWhitney_Get_Saddlepoint(m, n, x, 1000, stepsize)
        Console.WriteLine("s: {0}", s)

        Dim K_Order As Int32 = 24
        Dim K(K_Order + 1) As Arb
        For j = 0 To K_Order
            K(j) = aflint_MannWhitney_CGF(j, m, n, s, 1000, stepsize)
            Console.WriteLine("j: {0}, K(s): {1}", j, K(j))
        Next

        Console.WriteLine("")
        Dim density, LeftTail, Righttail As New Arb
        aflint_LugannaniRiceNew(K_Order, K, s, density, LeftTail, Righttail)

        'DemoMannWhitneyCalcArb2(2 * x.ToInt32)

    End Sub






    Sub aflint_Wilcoxon_Cumulants_Raw(Order As Integer, n As Integer, kappa As ArbMat)
        Dim nl As Int32
        kappa.Resize(Order + 1, 1)
        Call WilcoxonCumArb(n, Order, kappa, nl)  'Kendall  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            'Dim adj = d * aflint.bernoulli(i) / i
            Dim adj = 0
            If (i = 1) Or (i Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
            End If
            'If (i > 0) Then kappa(i) = kappa(i) - adj
            If (i > -1) Then kappa(i) = kappa(i) / (2 ^ i)
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        Dim mean = kappa(1)
        Dim sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
    End Sub


    Function Bennett0(n As Int32, s As Arb) As Arb
        Dim sum = aflint.t("0")
        For h = 1 To n
            sum = sum + aflint.log(aflint.cosh(0.5 * h * s))
        Next
        'Return sum
        Return 0.25 * n * (n + 1) * s + sum
    End Function


    Function Bennett1a(n As Int32, s As Arb) As Arb
        Dim sum = aflint.t("0")
        For h = 1 To n
            sum = sum + aflint.tanh(0.5 * h * s) * 0.5 * h
        Next
        Return sum
    End Function


    Function Bennett1(n As Int32, s As Arb) As Arb
        Dim sum = aflint.t("0")
        For h = 1 To n
            sum = sum + (1 - 2 / (aflint.exp(h * s) + 1)) * 0.5 * h
        Next
        Return sum
    End Function


    Function Bennett2(n As Int32, s As Arb) As Arb
        Dim sum = aflint.t("0")
        For h = 1 To n + 0
            Dim z = 1 / (aflint.exp(h * s) + 1)
            sum = sum + h * h * (z - z * z)
        Next
        Return sum
    End Function


    Function Bennett3(n As Int32, s As Arb) As Arb
        Dim sum = aflint.t("0")
        For h = 1 To n + 0
            Dim z = 1 / (aflint.exp(h * s) + 1)
            sum = sum + h * h * h * (-z + 3 * z * z - 2 * z * z * z)
        Next
        Return sum
    End Function


    Function Bennett4(n As Int32, s As Arb) As Arb
        Dim sum = aflint.t("0")
        For h = 1 To n + 0
            Dim z = 1 / (aflint.exp(h * s) + 1)
            sum = sum + h * h * h * h * (z - 7 * z * z + 12 * z * z * z - 6 * z * z * z * z)
        Next
        Return sum
    End Function



    Function Bennet_deriv(deriv As Int32, n As Int32, s As Arb) As Arb
        Dim result, z As New Arb
        'Dim coeff(deriv + 2, deriv + 2) As Int64
        Dim coeff As New ArbMat()
        'coeff.setZero(deriv + 3, deriv + 3)
        coeff.Resize(deriv + 3, deriv + 3)
        Dim d = deriv - 2
        Dim sum As Arb
        'sum = aflint.t("0")
        coeff(0, 1) = aflint.t(1)
        coeff(0, 2) = aflint.t(1)

        For i = 1 To deriv
            coeff(i, 1) = aflint.t(1)
            For j = 2 To deriv + 2
                coeff(i, j) = (j - 1) * coeff(i - 1, j - 1) + j * coeff(i - 1, j)
            Next
        Next

        Dim loopsign = -1
        For i = 0 To deriv
            loopsign = -loopsign
            Dim loopsign2 = loopsign
            For j = 1 To deriv + 2
                coeff(i, j) = loopsign2 * coeff(i, j)
                'Console.WriteLine("i: {0}, j: {1}, coeff(i, j): {2}", i, j, coeff(i, j))
                loopsign2 = -loopsign2
            Next
            'Console.WriteLine()
        Next

        result = aflint.t(0)
        For h = 1 To n
            z = 1 / (aflint.exp(h * s) + 1)
            Dim localsum = aflint.t("0")
            Dim zj = z
            For j = 1 To deriv
                localsum = localsum + coeff(d, j) * zj
                zj = zj * z
                'Console.WriteLine("deriv: {0}, j: {1}, coeff(i, j): {2}", deriv, j, coeff(d, j))
            Next
            sum = (h ^ (d + 2)) * localsum
            result = result + sum
        Next
        Return result
    End Function



    Function Bennett(deriv As Int32, n As Int32, s As Arb) As Arb
        Dim Ni, sum, result As New Arb
        If deriv = 0 Then
            result = Bennett0(n, s)
            Return result
        End If
        If deriv = 1 Then
            result = Bennett1(n, s)
            Return result
        End If
        If deriv = 2 Then
            result = Bennett2(n, s)
            Return result
        Else
            Return Bennet_deriv(deriv, n, s)
        End If
    End Function



    Function aflint_Wilcoxon_CGF(j As Int32, n As Int32, s As Arb, stepsize As Arb) As Arb
        Dim CGF_raw = Bennett(j, n, s)
        Dim CGF_sheppard = aflint_CGF_Sheppard(j, 1000, stepsize, s)
        Dim CGF = CGF_raw - CGF_sheppard
        Return CGF
    End Function



    Sub Demo_Wilcoxon_CGF_By_Cumulants()
        ArbPrec.SetDps(60)
        Dim kappa As New ArbMat
        Dim Order = 464 '128 '96 '64 '32      ' multiple of 4
        Dim n = 8
        Dim x = aflint.t("622")
        Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n + 1) / 4)

        'aflint_Kendall_Cumulants(Order, n, kappa)
        aflint_Wilcoxon_Cumulants_Raw(Order, n, kappa)
        Dim s = (x - kappa(1)) / kappa(2)
        s = aflint.t(0.01)
        Console.WriteLine("s: {0}", s)
        Console.WriteLine("Kappa(1): {0}", kappa(1))
        Console.WriteLine("Kappa(2): {0}", kappa(2))


        For j = 0 To 12
            Console.WriteLine()
            Console.WriteLine("j: {0}", j)
            Dim fx_cum = aflint_Wilcoxon_CGF_By_Cumulants(j, Order, s, kappa)
            Console.WriteLine("fx_cum: {0}", fx_cum)
            Dim fx_ben = Bennett(j, n, s)
            Console.WriteLine("fx_ben: {0}", fx_ben)
            Console.WriteLine("ratio: {0}", fx_cum / fx_ben)

        Next

    End Sub



    Function aflint_Wilcoxon_CGF_By_Cumulants(deriv As Integer, Order As Integer, s As Arb, kappa As ArbMat) As Arb
        Dim s1 = aflint.t("1")
        Dim sum = aflint.t("0")
        If deriv > 0 Then
            sum = kappa(deriv)
        End If
        Dim count As Int32
        Dim RelErr = aflint.t("1")
        For i = 1 To Order - deriv
            count = count + 1
            s1 = s1 * s
            Dim k = kappa(i + deriv)
            Dim summand = k * s1 / aflint.gamma(i + 1)
            sum = sum + summand
            If (i = 1) Or ((i + deriv) Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
            End If
            If (((i + deriv) Mod 2) = 0) Then
                RelErr = aflint.abs(summand / sum)
                'Console.WriteLine("RelErr: {0}", RelErr)
                If RelErr < aflint.epsilon() Then Exit For
            End If
        Next i
        'Console.WriteLine("count: {0}", count)
        'Console.WriteLine("result1: {0}", sum)
        Return sum
    End Function


    'NOTE: limited RelErr
    Function Wilcoxon_Get_Saddlepoint_By_Cumulants(x As Arb, Order As Int32, kappa As ArbMat) As Arb
        Dim s = (x - kappa(1)) / kappa(2)
        Dim RelErr = aflint.t("1")
        Do
            'Console.WriteLine("s1: {0}", s)
            Dim deriv = 1
            Dim fx = x - aflint_Wilcoxon_CGF_By_Cumulants(1, Order, s, kappa)
            RelErr = aflint.abs((fx) / x)
            'Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
            'Console.WriteLine("fx: {0}", fx)
            Dim dfx = aflint_Wilcoxon_CGF_By_Cumulants(2, Order, s, kappa)
            'Console.WriteLine("dfx: {0}", dfx)
            Dim adj = fx / dfx
            'Console.WriteLine("adj: {0}", adj)
            s = s + adj
            Console.WriteLine("s :{0}", s)
            'Loop Until (RelErr < aflint.epsilon())
        Loop Until (RelErr < aflint.t(0.0000000001))
        Return s
    End Function



    Sub aflint_Wilcoxon_Cumulants(Order As Integer, n As Integer, kappa As ArbMat)
        Dim nl As Int32
        kappa.Resize(Order + 1, 1)
        Call WilcoxonCumArb(n, Order, kappa, nl)  'Kendall  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            Dim adj = d * aflint.bernoulli(i) / i
            If (i = 1) Or (i Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
            End If
            If (i > 0) Then kappa(i) = kappa(i) - adj
            'Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        Dim mean = kappa(1)
        Dim sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
    End Sub






    Function Wilcoxon_Get_Saddlepoint(n As Int32, x As Arb, stepsize As Arb) As Arb
        Dim s = aflint.t("0")
        Dim RelErr = aflint.t("1")
        Dim tol = aflint.epsilon() * 100
        aflint.epsilon()
        Do
            Console.WriteLine("s: {0}", s)
            Dim fx = x - aflint_Wilcoxon_CGF(1, n, s, stepsize)
            Dim dfx = aflint_Wilcoxon_CGF(2, n, s, stepsize)
            Dim adj = (fx / dfx).Mid
            s = (s + adj).Mid
            RelErr = aflint.abs((adj) / s)
            Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
        Loop Until (RelErr < tol)
        Return s
    End Function



    Function CoshArb(x As Arb) As Arb
        'Return 0.5 * (aflint.exp(x) + aflint.exp(-x))
        Return 1.0 * (aflint.exp(x) + aflint.exp(-x))

    End Function

    Sub Demo_Wilcoxon_CDF_SPA()
        ArbPrec.SetDps(40)
        Dim aflint_get_tol = aflint.epsilon()
        Console.WriteLine("aflint_get_tol: {0}", aflint_get_tol)
        'Dim n = 50
        'Dim x = aflint.t("308")

        Dim n = 80
        Dim x = aflint.t("1240")


        Dim maxvalue = n * (n + 1) / 4
        Console.WriteLine("maxvalue: {0}", maxvalue)
        Dim stepsize = aflint.t("1")
        Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n + 1) / 2)

        'Dim s = Wilcoxon_Get_Saddlepoint(n, x, stepsize)
        Dim s = aflint.t(0.00764263498788246)

        Console.WriteLine("s: {0}", s)

        Dim K_Order As Int32 = 24
        Dim K(K_Order + 1) As Arb

        ' Need to calculate K(0) separately

        Dim sum = aflint.t("0")

        'For h = 1 To n
        '    'sum = sum + aflint.log(aflint.cosh(0.5 * h * s))

        '    Dim temp0 = 0.5 * h * s
        '    'Dim temp1 = aflint.cosh(temp0)
        '    Dim temp1 = CoshArb(temp0)
        '    Dim temp2 = aflint.log(temp1)
        '    sum = sum + temp2
        'Next

        For h = 1 To n
            sum = sum + aflint.log((1 + aflint.exp(h * s)))
        Next
        sum = sum + aflint.log(1.0 / (2 ^ n))

        'K(0) = 0.25 * n * (n + 1) * s + sum
        K(0) = sum
        Console.WriteLine("j: {0}, K(s): {1}", 0, K(0))

        'For j = 1 To K_Order
        '    K(j) = aflint_Wilcoxon_CGF(j, n, s, stepsize)
        '    Console.WriteLine("j: {0}, K(s): {1}", j, K(j))
        'Next

        'Console.WriteLine("")
        'Dim density, LeftTail, Righttail As New Arb
        'aflint_LugannaniRiceNew(K_Order, K, s, density, LeftTail, Righttail)

        'DemoWilcoxonCalcArb3(n, 2 * x.ToInt32)
    End Sub



    Sub Demo_Wilcoxon_CDF_SPA_By_Cumulants()
        'ArbPrec.SetDps(240)
        ArbPrec.SetDps(100)
        Dim kappa As New ArbMat
        Dim Order = 864 '128 '96 '64 '32      ' multiple of 4
        Dim n = 80
        Dim x = aflint.t("1240")

        Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2)

        aflint_Wilcoxon_Cumulants(Order, n, kappa)
        Dim s = Wilcoxon_Get_Saddlepoint_By_Cumulants(x, Order, kappa)
        Console.WriteLine("s: {0}", s)

        Dim K_Order As Int32 = 18
        Dim K(K_Order + 1) As Arb
        For j = 0 To K_Order
            K(j) = aflint_Wilcoxon_CGF_By_Cumulants(j, Order, s, kappa)
            Console.WriteLine("j: {0}, K(s): {1}", j, K(j))
        Next

        Console.WriteLine("")
        Dim density, LeftTail, Righttail As New Arb
        aflint_LugannaniRiceNew(K_Order, K, s, density, LeftTail, Righttail)

        'DemoWilcoxonCalcArb2(x.ToInt32)
        DemoWilcoxonCalcArb2(aflint.lrint(x))
    End Sub






    Sub aflint_Kendall_Cumulants_Raw(Order As Integer, n As Integer, kappa As ArbMat)
        Dim nl As Int32
        kappa.Resize(Order + 1, 1)
        Call KendallCumArb(n, Order, kappa, nl)  'Kendall  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            'Dim adj = d * aflint.bernoulli(i) / i
            Dim adj = 0
            If (i = 1) Or (i Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
            End If
            'If (i > 0) Then kappa(i) = kappa(i) - adj
            If (i > 0) Then kappa(i) = kappa(i) / (2 ^ 0)
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        Dim mean = kappa(1)
        Dim sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
    End Sub




    Function Kendall_Get_Saddlepoint_By_Cumulants(x As Arb, Order As Int32, kappa As ArbMat) As Arb
        Dim s = (x - kappa(1)) / kappa(2)
        Dim RelErr = aflint.t("1")
        Do
            'Console.WriteLine("s1: {0}", s)
            Dim deriv = 1
            Dim fx = x - aflint_Kendall_CGF_By_Cumulants(1, Order, s, kappa)
            RelErr = aflint.abs((fx) / x)
            'Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
            'Console.WriteLine("fx: {0}", fx)
            Dim dfx = aflint_Kendall_CGF_By_Cumulants(2, Order, s, kappa)
            'Console.WriteLine("dfx: {0}", dfx)
            Dim adj = fx / dfx
            'Console.WriteLine("adj: {0}", adj)
            s = s + adj
        Loop Until (RelErr < aflint.epsilon())
        Return s
    End Function





    Function aflint_Kendall_CGF_By_Cumulants(deriv As Integer, Order As Integer, s As Arb, kappa As ArbMat) As Arb
        Dim s1 = aflint.t("1")
        Dim sum = aflint.t("0")
        If deriv > 0 Then
            sum = kappa(deriv)
        End If
        Dim count As Int32
        Dim RelErr = aflint.t("1")
        For i = 1 To Order - deriv
            count = count + 1
            s1 = s1 * s
            Dim k = kappa(i + deriv)
            Dim summand = k * s1 / aflint.gamma(i + 1)
            sum = sum + summand
            If (i = 1) Or ((i + deriv) Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
            End If
            If (((i + deriv) Mod 2) = 0) Then
                RelErr = aflint.abs(summand / sum)
                'Console.WriteLine("RelErr: {0}", RelErr)
                If RelErr < aflint.epsilon() Then Exit For
            End If
        Next i
        'Console.WriteLine("count: {0}", count)
        'Console.WriteLine("result1: {0}", sum)
        Return sum
    End Function



    Sub Demo_Kendall_Saddlepoint_By_Cumulants()
        ArbPrec.SetDps(140)
        Dim kappa As New ArbMat
        Dim Order = 464 '128 '96 '64 '32      ' multiple of 4
        Dim n = 80
        Dim x = aflint.t("1578")

        aflint_Kendall_Cumulants(Order, n, kappa)
        Dim s = (x - kappa(1)) / kappa(2)
        Dim RelErr = aflint.t("1")
        Do
            'Console.WriteLine("")
            Console.WriteLine("s1: {0}", s)
            Dim deriv = 1
            Dim fx = x - aflint_Kendall_CGF_By_Cumulants(1, Order, s, kappa)
            RelErr = aflint.abs((fx) / x)
            Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
            'Console.WriteLine("fx: {0}", fx)
            Dim dfx = aflint_Kendall_CGF_By_Cumulants(2, Order, s, kappa)
            'Console.WriteLine("dfx: {0}", dfx)
            Dim adj = fx / dfx
            'Console.WriteLine("adj: {0}", adj)
            s = s + adj
        Loop Until (RelErr < aflint.epsilon())
    End Sub



    Sub aflint_Kendall_Cumulants(Order As Integer, n As Integer, kappa As ArbMat)
        Dim nl As Int32
        kappa.Resize(Order + 1, 1)
        Call KendallCumArb(n, Order, kappa, nl)  'Kendall  
        Console.WriteLine("nl: {0}", nl)

        Dim i As Int32 = 0
        Dim d As Arb = aflint.t(1)
        For i = 1 To Order
            d = 2 * d
            Dim adj = d * aflint.bernoulli(i) / i
            If (i = 1) Or (i Mod 2 = 0) Then
                'Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
            End If
            If (i > 0) Then kappa(i) = kappa(i) - adj
            '      Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
        Next i


        Dim mean = kappa(1)
        Dim sigma = aflint.sqrt(kappa(2))
        Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
    End Sub




    Sub Demo_Kendall_CDF_SPA()
        ArbPrec.SetDps(40)
        Dim kappa As New ArbMat
        Dim Order = 864 '128 '96 '64 '32      ' multiple of 4
        Dim n = 80
        Dim x = aflint.t("1278")
        'Dim x = aflint.t("1606")
        'Dim x = aflint.t("40")

        Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2)

        aflint_Kendall_Cumulants(Order, n, kappa)
        Dim s = Kendall_Get_Saddlepoint_By_Cumulants(x, Order, kappa)
        Console.WriteLine("s: {0}", s)

        Dim K_Order As Int32 = 18
        Dim K(K_Order + 1) As Arb
        For j = 0 To K_Order
            K(j) = aflint_Kendall_CGF_By_Cumulants(j, Order, s, kappa)
            Console.WriteLine("j: {0}, K(s): {1}", j, K(j))
        Next

        Console.WriteLine("")
        Dim density, LeftTail, Righttail As New Arb
        aflint_LugannaniRiceNew(K_Order, K, s, density, LeftTail, Righttail)

    End Sub



    Sub Demo_Kendall_CGF_By_Cumulants()
        ArbPrec.SetDps(240)
        Dim kappa As New ArbMat
        Dim Order = 464 '128 '96 '64 '32      ' multiple of 4
        Dim n = 80
        Dim x = aflint.t("622")
        Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2)

        'aflint_Kendall_Cumulants(Order, n, kappa)
        aflint_Kendall_Cumulants_Raw(Order, n, kappa)
        Dim s = (x - kappa(1)) / kappa(2)
        s = aflint.t(0.01)
        Dim limit = aflint.pi() / n
        Console.WriteLine("limit: {0}", limit)
        Console.WriteLine("s: {0}", s)
        Console.WriteLine("Kappa(1): {0}", kappa(1))
        Console.WriteLine("Kappa(2): {0}", kappa(2))

        Dim RelErr = aflint.t("1")

        'Dim k1 = aflint_Kendall_CGF_By_Cumulants(1, Order, 0, kappa)
        'Console.WriteLine("k1: {0}", k1)

        Dim fx_new = aflint_Kendall_CGF_By_Cumulants(0, Order, s, kappa)
        Console.WriteLine("fx1: {0}", fx_new)


    End Sub






End Module
