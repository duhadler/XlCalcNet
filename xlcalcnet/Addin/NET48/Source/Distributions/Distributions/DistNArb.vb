Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet


Module DistNArb





    '**********************************************************************
    'Noncentral ChiSquare
    ''**********************************************************************


    Function aflint_sign(x As Arb) As Arb
        If x.Mid < aflint.zero() Then Return aflint.t("-1")
        If x.Mid > aflint.zero() Then Return aflint.t("1") Else Return aflint.t("0")
    End Function


    'Function aflint_get_tol() As Arb
    '    Return 10 * aflint.t(mreal.machine_epsilon().ToString())
    'End Function



#Region "Noncentral ChiSquare"



    Function aflint_NonCentralChi2_CGF_Derivative(t As Arb, n As Arb, lambda As Arb, j As Integer) As Arb
        Dim result As New Arb
        If (j = 0) Then
            result = -(n / 2) * aflint.log(1 - 2 * t) + lambda * t / (1 - 2 * t)
        Else
            Dim p1 As Arb, p2 As New Arb
            'p1 = (2 ^ (j - 1)) * aflint.gamma(j) / ((1 - 2 * t) ^ j)
            p1 = (2 ^ (j - 1)) * aflint.gamma(j) / aflint.pow((1 - 2 * t), j)
            p2 = (n + (lambda * j) / (1 - 2 * t))
            result = p1 * p2
        End If
        Return result
    End Function


    Sub aflint_NonCentralChi2_SPA2(n As Arb, x As Arb, lambda As Arb, ByRef LeftTail As Arb, ByRef Righttail As Arb)
        Dim s, density As Arb
        Console.WriteLine("n: {0}, x: {1}, lambda: {2}", n, x, lambda)
        s = -(1 / (4 * x)) * (n - 2 * x + aflint.sqrt(n * n + 4 * x * lambda))
        Console.WriteLine("s: {0}", s)
        Dim order As Int32 = 18
        Dim kappa(order + 1) As Arb
        For j = 0 To order
            kappa(j) = aflint_NonCentralChi2_CGF_Derivative(s, n, lambda, j)
            Console.WriteLine("j: {0}, K(s): {1}", j, kappa(j))
        Next

        Console.WriteLine("")
        aflint_LugannaniRiceNew(order, kappa, s, density, LeftTail, Righttail)
    End Sub


    ' !!!!!  d(,) needs to be changed to ArbMat  !!!!
    Sub aflint_Fill_d(order As Int32, ByRef d(,) As Arb, theta() As Arb)
        d(0, 0) = aflint.t(1)
        For m = 0 To order
            For n = m To order
                Dim sum = aflint.t(0.0)
                For k = 1 To n - m + 1
                    sum = sum + k * theta(k + 2) * d(m, n - k + 1)
                Next
                d(m + 1, n + 1) = sum / (n + 1)
            Next
        Next
    End Sub



    Function aflint_GammaHalf(mj As Int32) As Arb
        Return aflint.gamma(mj + 0.5) / aflint.sqrt(aflint.pi())
    End Function


    Function aflint_Calc_A(j As Int32, A0 As Arb, mu As Arb, d(,) As Arb, theta() As Arb) As Arb
        Dim sum1 = aflint.t(0.0)
        For n = 0 To 2 * j
            Dim sum2 = aflint.t(0.0)
            For m = 0 To n
                Dim delta = d(m, n)
                'Console.WriteLine("m: {0}, n: {1}, delta: {2}", m, n, delta)
                Dim summand2 = delta * (-2) ^ (m + j) * aflint_GammaHalf(m + j)
                sum2 = sum2 + summand2
            Next
            Dim factor = aflint.pow((-mu), (2 * j - n))
            'Console.WriteLine("factor: {0}, sum2: {1}, -mu: {2}", factor, sum2, -mu)
            sum1 = sum1 + factor * sum2
        Next
        Return A0 * sum1
    End Function

    Sub aflint_LugannaniRiceNew(order As Int32, kappa() As Arb, s As Arb,
                         ByRef density As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim mu, w1, w2, LeftTail0, RightTail0, u, w As New Arb
        Dim theta(order + 1) As Arb
        Dim A(order + 1) As Arb
        Dim B(order + 1) As Arb
        Dim sum(order + 1) As Arb
        Dim d(2 * order + 3, 2 * order + 3) As Arb
        For i = 0 To 2 * order + 3
            For j = 0 To 2 * order + 3
                d(i, j) = aflint.t(0)
            Next
        Next

        w = aflint_sign(s) * aflint.sqrt(2 * (s * kappa(1) - kappa(0)))
        u = s * aflint.sqrt(kappa(2))
        w1 = 1 / w
        w2 = -2 * w1 * w1
        mu = 1 / u

        Dim k As Arb = aflint.sqrt(kappa(2))
        Dim factor As Arb = 2 * kappa(2)
        For j = 3 To order
            factor = factor * j * k
            theta(j) = kappa(j) / factor
            'Console.WriteLine("j: {0}, theta: {1}", j, theta(j))
        Next

        density = aflint.ndens(w)
        LeftTail0 = aflint.ndis(w)
        RightTail0 = aflint.ndis(-w)

        B(0) = density * w1
        factor = aflint.t(0.5)
        For j = 1 To order
            B(j) = B(j - 1) * w2 * factor
            factor = factor + 1
        Next

        aflint_Fill_d(order - 3, d, theta)
        A(0) = density * mu
        For j = 1 To order - 3
            A(j) = aflint_Calc_A(j, A(0), mu, d, theta)
        Next

        Dim totalsum As Arb = aflint.t(0)
        Dim useorder As Int32 = order - 3
        Dim LastSumj = aflint.t("10")
        'Console.WriteLine("j: {0}, Leftj: {1}, Rightj: {2}", 0, LeftTail0 - totalsum, RightTail0 + totalsum)
        Console.WriteLine("j: {0}, Rightj: {1}", 0, RightTail0 + totalsum)

        'For j = 0 To useorder
        '    sum(j) = A(j) - B(j)
        '    Dim abssumj = aflint.abs(sum(j))
        '    totalsum = totalsum + sum(j)
        '    LastSumj = abssumj
        '    'Console.WriteLine("j: {0}, Leftj: {1}, sumj: {2}", j, LeftTail0 - totalsum, sum(j))
        '    Console.WriteLine("j: {0}, Rightj: {1}, sumj: {2}", j, RightTail0 + totalsum, sum(j))
        'Next

        For j = 0 To useorder
            sum(j) = A(j) - B(j)
            Dim abssumj = aflint.abs(sum(j))
            If (LastSumj > abssumj) Then
                totalsum = totalsum + sum(j)
                LastSumj = abssumj
                'Console.WriteLine("j: {0}, Leftj: {1}, sumj: {2}", j, LeftTail0 - totalsum, sum(j))
                Console.WriteLine("j: {0}, Rightj: {1}, sumj: {2}", j, RightTail0 + totalsum, sum(j))
            Else
                Exit For
            End If
        Next


        LeftTail = LeftTail0 - totalsum
        RightTail = RightTail0 + totalsum
        Console.WriteLine("LeftTail: {0}", LeftTail)
        Console.WriteLine("")
    End Sub
















    Function aflint_non_central_chi_square(x As Arb, f As Arb, theta As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb) As Arb
        LeftTail = aflint_non_central_chi_square_p(x, f, theta, aflint.t(0))
        RightTail = aflint_non_central_chi_square_q(x, f, theta, aflint.t(0))
        Return LeftTail
    End Function


    Function aflint_non_central_chi_square_q(x As Arb, f As Arb, theta As Arb, init_sum As Arb) As Arb
        If (x = 0) Then Return aflint.t(1.0)

        Dim lambda As Arb = theta / 2
        Dim del As Arb = f / 2
        Dim y As Arb = x / 2
        Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        Dim errtol As Arb = aflint.epsilon() 'boost::math::policies::get_epsilon<T, Policy>()
        Dim sum As Arb = init_sum

        'Dim k As Int32 = Convert.ToInt32(aflint.round(lambda))
        Dim k As Int32 = aflint.lrint(lambda)
        ' Forwards and backwards Poisson weights:
        Dim poisf As Arb = aflint.gamma_p_derivative(aflint.t(1 + k), lambda)
        Dim poisb As Arb = poisf * k / lambda
        ' Initial forwards central chi squared term:
        Dim gamf As Arb = aflint.gamma_q(del + k, y)
        ' Forwards and backwards recursion terms on the central chi squared:
        Dim xtermf As Arb = aflint.gamma_p_derivative(del + 1 + k, y)
        Dim xtermb As Arb = xtermf * (del + k) / y
        ' Initial backwards central chi squared term:
        Dim gamb As Arb = gamf - xtermb

        ' Forwards iteration first, this is the
        ' stable direction for the gamma function
        ' recurrences:
        '
        Dim i As Int32
        For i = k To (max_iter - (i - k))
            Dim term As Arb = poisf * gamf
            sum += term
            poisf *= lambda / (i + 1)
            gamf += xtermf
            xtermf *= y / (del + i + 1)
            If (((sum = 0) Or (aflint.abs(term / sum) < errtol)) And (term >= poisf * gamf)) Then Exit For
        Next
        'Error check:
        If ((i - k) >= max_iter) Then
            Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum)
            Return aflint.t(0.0)
        End If

        ' Now backwards iteration: the gamma
        ' function recurrences are unstable in this
        ' direction, we rely on the terms deminishing in size
        ' faster than we introduce cancellation errors.
        ' For this reason it's very important that we start
        ' *before* the largest term so that backwards iteration
        ' is strictly converging.
        '
        For i = k - 1 To 0 Step -1
            Dim term As Arb = poisb * gamb
            sum += term
            poisb *= i / lambda
            xtermb *= (del + i) / y
            gamb -= xtermb
            If ((sum = 0) Or (aflint.abs(term / sum) < errtol)) Then Exit For
        Next

        Return sum
    End Function


    Function aflint_non_central_chi_square_p(y As Arb, n As Arb, lambda As Arb, init_sum As Arb) As Arb
        If (y = 0) Then Return aflint.t(0.0)

        '    Dim lambda As Arb = theta / 2
        Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        Dim errtol As Arb = aflint.epsilon() 'boost::math::policies::get_epsilon<T, Policy>()
        'Dim errtol As Arb = aflint.t("1E-15") 'boost::math::policies::get_epsilon<T, Policy>()
        Dim errorf As Arb = aflint.t(0.0)
        Dim errorb As Arb = aflint.t(0.0)



        Dim x As Arb = y / 2
        Dim del As Arb = lambda / 2
        '
        ' Starting location for the iteration, we'll iterate
        ' both forwards and backwards from this point.  The
        ' location chosen is the maximum of the Poisson weight
        ' function, which ocurrs *after* the largest term in the
        ' sum.
        '

        'Dim k As Int32 = Convert.ToInt32(round(lambda))
        Dim k As Int32 = aflint.lrint(lambda)
        Dim a As Arb = n / 2 + k
        ' Central chi squared term for forward iteration:
        Dim gamkf As Arb = aflint.gamma_p(a, x)

        If (lambda = 0) Then Return gamkf
        ' Central chi squared term for backward iteration:
        Dim gamkb As Arb = gamkf
        ' Forwards Poisson weight:
        Dim poiskf As Arb = aflint.gamma_p_derivative(aflint.t(k + 1), del)
        ' Backwards Poisson weight:
        Dim poiskb As Arb = poiskf
        ' Forwards gamma function recursion term:
        Dim xtermf As Arb = aflint.gamma_p_derivative(a, x)
        ' Backwards gamma function recursion term:
        Dim xtermb As Arb = xtermf * x / a
        Dim sum As Arb = init_sum + poiskf * gamkf
        If (sum = 0) Then Return sum
        Dim i As Int32 = 1
        '
        ' Backwards recursion first, this is the stable
        ' direction for gamma function recurrences:
        '
        While (i <= k)
            xtermb *= (a - i + 1) / x
            gamkb += xtermb
            poiskb = poiskb * (k - i + 1) / del
            errorf = errorb
            errorb = gamkb * poiskb
            sum += errorb
            If ((aflint.abs(errorb / sum) < errtol) And (errorb <= errorf)) Then Exit While
            i = i + 1
        End While

        i = 1
        '
        ' Now forwards recursion, the gamma function
        ' recurrence relation is unstable in this direction,
        ' so we rely on the magnitude of successive terms
        ' decreasing faster than we introduce cancellation error.
        ' For this reason it's vital that k is chosen to be *after*
        ' the largest term, so that successive forward iterations
        ' are strictly (and rapidly) converging.
        '
        Do
            xtermf = xtermf * x / (a + i - 1)
            gamkf = gamkf - xtermf
            poiskf = poiskf * del / (k + i)
            errorf = poiskf * gamkf
            sum += errorf
            i = i + 1
        Loop While ((aflint.abs(errorf / sum) > errtol) And ((i) < max_iter))

        'Error check:
        If ((i) >= max_iter) Then
            Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum)
            Return sum
        End If

        Return sum
    End Function


    Sub aflint_GetL(F As Arb, Chi2 As Arb, lambda As Arb, alpha As Arb, Beta As Arb)
        Dim t As Arb, n As Arb, t2 As Arb, t3 As Arb, t4 As Arb, X As Arb,
          x2 As Arb, x3 As Arb, x4 As Arb, x5 As Arb, y As Arb, Y_12 As Arb,
          Y_32 As Arb, Y_52 As Arb, Y_4 As Arb, Y_112 As Arb
        X = ndisxArb(1 - Beta, Beta)
        Chi2 = cdisxArb(1 - alpha, alpha, F)
        t = (Chi2 - F) / F
        n = F
        t2 = t * t : t3 = t2 * t : t4 = t3 * t
        x2 = X * X : x3 = x2 * X : x4 = x3 * X : x5 = x4 * X
        y = 2 * t + 1 : Y_12 = aflint.sqrt(y) : Y_32 = y * Y_12 * aflint.sqrt(n)
        Y_52 = y * Y_32 : Y_4 = Y_52 * Y_32 : Y_112 = Y_4 * Y_32
        lambda = n * t + aflint.sqrt(2 * n * y) * X + 2 * ((3 * t + 2) * x2 + (3 * t + 1)) / (3 * y) _
              - aflint.sqrt(2) * ((6 * t + 5) * x3 - (36 * t2 + 42 * t + 17) * X) / (18 * Y_52) _
              + ((324 * t2 + 594 * t + 276) * x4 - (1080 * t3 + 2484 * t2 + 2394 * t + 976) * x2 _
              + (1080 * t3 + 1512 * t2 + 612 * t + 148)) / (405 * Y_4) _
              - aflint.sqrt(2) * ((10368 * t3 + 30780 * t2 + 30564 * t + 10143) * x5 _
              - (25920 * t4 + 98928 * t3 + 163080 * t2 + 137544 * t + 47188) * x3 _
              + (45360 * t4 + 106704 * t3 + 80460 * t2 + 31092 * t + 13489) * X) / (9720 * Y_112)
        If lambda < 0 Then lambda = aflint.t(0.00001)
    End Sub






#End Region







    '**********************************************************************
    'Noncentral Beta cdf
    ''**********************************************************************


#Region "Noncentral Beta"



    'Function non_central_beta_p(a As Arb, b As Arb, lambda As Arb, x As Arb, y As Arb, init_val As Arb) As Arb

    '    Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
    '    Dim errtol As Arb = 0.000000000000001 'boost::math::policies::get_epsilon<T, Policy>()

    '    Dim l2 As Arb = lambda / 2



    '    Dim k As Int32 = Convert.ToInt32(round(l2))

    '    ' Forwards and backwards Poisson weights:
    '    Dim poisf As Arb = boost.gamma_p_derivative((1 + k), lambda)
    '    Dim poisb As Arb = poisf * k / lambda
    '    ' Initial forwards central chi squared term:
    '    Dim gamf As Arb = boost.gamma_q(del + k, y)
    '    ' Forwards and backwards recursion terms on the central chi squared:
    '    Dim xtermf As Arb = boost.gamma_p_derivative(del + 1 + k, y)
    '    Dim xtermb As Arb = xtermf * (del + k) / y
    '    ' Initial backwards central chi squared term:
    '    Dim gamb As Arb = gamf - xtermb

    '    ' Forwards iteration first, this is the
    '    ' stable direction for the gamma function
    '    ' recurrences:
    '    '
    '    Dim i As Int32
    '    For i = k To (max_iter - (i - k))
    '        Dim term As Arb = poisf * gamf
    '        sum += term
    '        poisf *= lambda / (i + 1)
    '        gamf += xtermf
    '        xtermf *= y / (del + i + 1)
    '        If (((sum = 0) Or (aflint.abs(term / sum) < errtol)) And (term >= poisf * gamf)) Then Exit For
    '    Next
    '    'Error check:
    '    If ((i - k) >= max_iter) Then
    '        Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum)
    '        Return 0.0
    '    End If

    '    ' Now backwards iteration: the gamma
    '    ' function recurrences are unstable in this
    '    ' direction, we rely on the terms deminishing in size
    '    ' faster than we introduce cancellation errors.
    '    ' For this reason it's very important that we start
    '    ' *before* the largest term so that backwards iteration
    '    ' is strictly converging.
    '    '
    '    For i = k - 1 To 0 Step -1
    '        Dim term As Arb = poisb * gamb
    '        sum += term
    '        poisb *= i / lambda
    '        xtermb *= (del + i) / y
    '        gamb -= xtermb
    '        If ((sum = 0) Or (aflint.abs(term / sum) < errtol)) Then Exit For
    '    Next

    '    Return sum
    'End Function






    Sub aflint_Betadisn(a As Arb, b As Arb,
X As Arb, y As Arb, d As Arb,
      ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim n As Long, Mode As Long
        Dim density As Arb, t As Arb, snRight As Arb
        Dim d2 As Arb, sn As Arb, rn As Arb
        Dim FehlerLeft As Arb, RelFehlerLeft As Arb
        Dim ResultLeft As Arb, qsum As Arb
        Dim expd2 As Arb, Lastvalue As Arb, l1 As Arb
        Dim RelFehlerRight As Arb, ResultRight As Arb ', l2 As Arb, r2 As Arb

        LeftTail = FdisArb((2 * a + d) * (2 * a + d) / (2 * (a + d)), 2 * b, 2 * b / (2 * a + d) * X / (1 - X))
        If (LeftTail < aflint.t("0.01")) Then Mode = 1 Else Mode = 2

        'Mode = 1
        d2 = d / 2
        rn = aflint.t(1)
        n = 1
        expd2 = aflint.exp(-d2)
        '  t = LnGamma(a + b) - LnGamma(a + 1) - LnGamma(b)
        '  t = t + a * Log(X) + b * Log(y)
        '  t = Exp(t)
        Call betadisArb(a, b, X, y, LeftTail, RightTail, density)
        t = density * X * y / a
        '  Debug.Print "t: ", t, density * X * y / a
        sn = LeftTail
        Lastvalue = LeftTail
        snRight = RightTail
        qsum = aflint.t(1)
        If Mode = 1 Then
            Do
                rn = rn * d2 / n
                qsum = qsum + rn
                LeftTail = LeftTail - t
                If (Lastvalue / LeftTail) > aflint.t("1000") Then
                    Call betadisArb(a + n, b, X, y, l1, RightTail, density)
                    Lastvalue = l1
                    LeftTail = l1
                End If
                sn = sn + rn * LeftTail
                t = t * X * (a + b + n - 1) / (a + n)
                FehlerLeft = LeftTail * (1 - expd2 * qsum)
                ResultLeft = expd2 * sn
                RelFehlerLeft = FehlerLeft / ResultLeft
                n = n + 1
            Loop Until (RelFehlerLeft < aflint.t("1E-15"))
            LeftTail = ResultLeft
            RightTail = 1 - LeftTail
        End If

        'Mode = 2
        If Mode = 2 Then
            Do
                rn = rn * d2 / n
                RightTail = RightTail + t
                snRight = snRight + rn * RightTail
                t = t * X * (a + b + n - 1) / (a + n)
                RelFehlerRight = rn * RightTail / snRight
                n = n + 1
            Loop Until (RelFehlerLeft < aflint.t("1E-15"))
            ResultRight = expd2 * snRight
            RightTail = ResultRight
            LeftTail = 1 - RightTail
        End If




    End Sub


#End Region







    '**********************************************************************
    'Singly noncentral F cdf
    ''**********************************************************************


#Region "Noncentral F"


    Function aflint_Fdisn(m As Arb, n As Arb, a As Arb, NC As Arb) As Arb
        Dim X As Arb, y As Arb, p As Arb, Q As Arb, L As Arb, r As Arb
        'Dim density As Arb
        If a <= 0 Then
            Return aflint.t(0)
        End If
        X = m * a / (m * a + n)
        y = n / (m * a + n)
        p = m / 2
        Q = n / 2
        ''' !!! Still Missing !!!!
        Call aflint_Betadisn(p, Q, X, y, NC, L, r)
        Return r
        '  If Not (IsMissing(LeftTail)) Then LeftTail = L
        '  If Not (IsMissing(RightTail)) Then RightTail = r
    End Function



    Sub aflint_Fdis_a(m As Arb, n As Arb, a As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim X As Arb, y As Arb, p As Arb, Q As Arb
        If a <= 0 Then
            LeftTail = aflint.t(0)
            RightTail = aflint.t(1)
            Exit Sub
        End If
        X = m * a / (m * a + n)
        y = n / (m * a + n)
        p = m / 2
        Q = n / 2
        Call aflint_Betadisn(p, Q, X, y, aflint.t(0), LeftTail, RightTail)
    End Sub



    Function aflint_fdisnOwen(a As Arb, m As Arb, n As Long, d As Arb) As Arb
        Dim X As Arb, p As Arb, Q As Long, C As Arb, b As Arb, b0 As Arb, b1 As Arb, S As Arb, k As Long
        X = m * a / (m * a + n)
        p = m / 2 : Q = n \ 2
        C = aflint.pow(X, p) * aflint.exp(d * (X - 1) / 2)
        b0 = aflint.t(0) : b1 = aflint.t(1) : S = aflint.t(1) : k = n Mod 2
        If k <> 0 Then
            Console.WriteLine("n needs to be an even integer")
            Return aflint.t(0)
        Else
            For k = 2 To Q
                b = (2 * k - 4 + p + d * X / 2) * b1 + (k - 3 + p) * (X - 1) * b0
                b = b * (1 - X) / (k - 1) : S = S + b : b0 = b1 : b1 = b
            Next k
            Return 1 - C * S ' RightTail
        End If
    End Function


    Function aflint_fdisnOwen2(a As Arb, m As Arb, n As Long, d As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb) As Arb
        Dim X As Arb, p As Arb, Q As Long, C As Arb, b As Arb, b0 As Arb, b1 As Arb, S As Arb, k As Long
        X = m * a / (m * a + n)
        p = m / 2 : Q = n \ 2
        C = aflint.pow(X, p) * aflint.exp(d * (X - 1) / 2)
        b0 = aflint.t(0) : b1 = aflint.t(1) : S = aflint.t(1) : k = n Mod 2
        If k <> 0 Then
            Console.WriteLine("n needs to be an even integer")
            Return aflint.t(0)
        Else
            For k = 2 To Q
                b = (2 * k - 4 + p + d * X / 2) * b1 + (k - 3 + p) * (X - 1) * b0
                b = b * (1 - X) / (k - 1) : S = S + b : b0 = b1 : b1 = b
            Next k
            LeftTail = C * S
            RightTail = 1 - C * S ' RightTail
            Return LeftTail
        End If
    End Function



#End Region







    '**********************************************************************
    'Singly noncentral T cdf
    ''**********************************************************************


#Region "NoncentralT"


    Function Arbdisn(F As Arb, t As Arb, d As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb) As Arb
        Dim sqrtpi As Arb = aflint.pi()
        Dim S(0 To 1) As Arb
        Dim a As Arb, b As Arb, y As Arb, X As Arb
        Dim z As Arb, h As Arb, g As Arb, k As Arb
        Dim r As Arb, ss As Arb
        Dim ak As Arb, C As Arb, pk0 As Arb
        Dim pk1 As Arb, pk2 As Arb ', lnB As Arb
        Dim i As Integer
        Dim fit As Boolean

        ' ERROR: Calculation in double precision !!!!!
        If d = 0 Then
            Return aflint.t(tdis(F.AsDouble, t.AsDouble, LeftTail.AsDouble, RightTail.AsDouble))
        End If
        fit = True
        If t > 0 Then
            fit = False
            t = -t
            d = -d
        End If
        a = t / aflint.sqrt(F)
        b = F / (F + t * t)
        y = d * aflint.sqrt(b / 2) / sqrtpi
        X = d * d * b / 2
        z = a * a * b
        h = NdisArb(-d * aflint.sqrt(b))

        ' ERROR: Calculation in double precision !!!!!
        g = aflint.exp(-Lnbeta(F.AsDouble / 2, 1 / 2))
        ak = aflint.t(1)
        C = aflint.t(0.5)
        For i = 0 To 1
            k = aflint.t(0)
            S(i) = aflint.t(0)
            pk2 = aflint.t(1)
            pk1 = aflint.t(0)
            Do
                S(i) = S(i) + ak * pk2
                pk0 = pk1
                pk1 = pk2
                ss = k + C
                pk2 = pk1 * (1 + (k - X) / ss) - pk0 * k / ss
                k = k + 1
                r = 2 * k
                If i = 0 Then
                    ak = ak * z * (r - F) * (r - 1) / (r * (r + 1))
                Else
                    ak = ak * z * (r + 1 - F) / (r + 2)
                End If
            Loop Until S(i) = S(i) + ak * pk2
            ak = z * (1 - F) / 2
            C = aflint.t(1.5)
        Next i
        h = h + (g * a * aflint.sqrt(b) * S(0) - y * S(1)) * aflint.exp(-X)
        If h < 0 Then h = aflint.t(0)
        If h > 1 Then h = aflint.t(1)
        LeftTail = h
        RightTail = 1 - h
        If Not fit Then
            RightTail = h
            LeftTail = 1 - h
        End If
        Return LeftTail
    End Function



    Function ArbdisnR(F As Arb, t As Arb, d As Arb) As Arb
        Dim LeftTail As Arb, RightTail As Arb
        Call Arbdisn(F, t, d, LeftTail, RightTail)
        Return RightTail
    End Function


    Sub ArbdisnOwen_Combined(n As Long, t As Arb, d As Arb, ByRef PDF As Arb, ByRef CDF As Arb)
        Dim F0 As Arb, f2 As Arb, LeftTail As Arb, RightTail As Arb
        F0 = ArbdisnOwen(n, t, d, LeftTail, RightTail)
        f2 = ArbdisnOwen(n + 2, t * aflint.sqrt(1 + 2 / n), d, LeftTail, RightTail)
        CDF = F0
        PDF = (n / t) * (f2 - F0)
    End Sub




    Function ArbdisnOwen(n As Long, X As Arb, d As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb) As Arb
        'Const h = 0.797884560802866 '  H = 2 / Sqrt(2 * Pi)
        Dim h = 2 / aflint.sqrt(2 * aflint.pi())
        Dim a As Arb, b As Arb, b2 As Arb, k As Long, i As Long, j As Long
        Dim C As Arb, C0 As Arb, C1 As Arb, g As Arb, F As Arb
        Dim one = aflint.one()
        a = X / aflint.sqrt(n)
        b2 = one / (one + a * a) : b = aflint.sqrt(b2)
        k = n Mod 2
        If k = 0 Then F = NdisArb(-d) Else Console.WriteLine("Need to implement Owen's t")
        'If k = 0 Then F = ndis(-d) Else F = ndis(-d * b) + 2 * t(d * b, a)
        '    t = THA(h, 1, a, 1)

        If n > 1 Then
            C0 = a * b * NdisArb(d * a * b) * aflint.exp(-0.5 * d * d * b2)
            C1 = a * b2 * (d * C0 + 0.5 * aflint.exp(-0.5 * d * d) * h)
            If k = 0 Then F = F + C0 Else F = F + h * C1
            g = aflint.t(1) : i = 2
            While Not (i >= n - k)
                For j = 1 To 2
                    'C = b2 * (1 - 1 / i) * (a * g * d * C1 + C0)
                    C = b2 * (one - one / i) * (a * g * d * C1 + C0)
                    C0 = C1 : C1 = C : i = i + 1
                    g = one / (g * (i - 2))
                Next j
                If k = 0 Then F = F + C0 Else F = F + h * C1
            End While
        End If
        LeftTail = F
        RightTail = 1 - F
        Return F
    End Function


#End Region









    '**********************************************************************
    'Doubly noncentral F cdf
    ''**********************************************************************

#Region "DoublyNoncentralF"


    Sub aflint_LugannaniRice(w As Arb, U As Arb, k2 As Arb, k3 As Arb,
k4 As Arb, ByRef density As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim w1 As Arb, U1 As Arb, Adj1 As Arb, Adj As Arb
        w1 = 1 / w
        U1 = 1 / U
        k3 = k3 / (k2 * aflint.sqrt(k2))
        k4 = k4 / (k2 * k2)
        Adj1 = (0.125 * k4 - 5 * k3 * k3 / 24)
        Adj = U1 * Adj1 - (U1 * U1 * U1) - (0.5 * k3 * U1 * U1) + (w1 * w1 * w1)

        ' ERROR: !!!! Calculation in double precision !!!!
        Call ndis2(False, w.AsDouble, LeftTail.AsDouble, RightTail.AsDouble, density.AsDouble)
        LeftTail = LeftTail + density * (w1 - U1 - Adj)
        RightTail = RightTail - density * (w1 - U1 - Adj)
        'density = density * S * U1 * v2 * (t2 * v2 + N2) * (1 - 2 * Adj1 / 3)

    End Sub


    Function aflint_JensenR(w As Arb, U As Arb) As Arb
        Return w + (1 / w) * aflint.log(U / w)
    End Function


    Sub aflint_Jensen(w As Arb, U As Arb)
        Dim r As Arb, lefttail1 As Arb, RightTail1 As Arb, density1 As Arb
        r = aflint_JensenR(w, U)

        ' ERROR: !!!! Calculation in double precision !!!!
        Call ndis2(False, r.AsDouble, lefttail1.AsDouble, RightTail1.AsDouble, density1.AsDouble)
        Console.WriteLine("Lr_s: {0}, R: {1}", lefttail1, RightTail1)
    End Sub



    Sub aflint_FdisnCalcSaddlepoint(ByRef S As Arb, N1 As Arb, N2 As Arb,
F As Arb, t1 As Arb, t2 As Arb)
        Dim Pi = aflint.pi()
        Dim f2 As Arb, n22 As Arb, n12 As Arb, a As Arb, a0 As Arb, A1 As Arb
        Dim A2 As Arb, Q As Arb, p As Arb

        f2 = F * F : n22 = N2 * N2 : n12 = N1 * N1

        If (t1 * t2) <> 0 Then
            a = 1 / (8 * f2 * n22 * (N1 + N2))
            a0 = (F * t2 * n12 - (1 - F) * n12 * N2 - N1 * N2 * t1) * a
            A1 = (2 * (n22 * N1 + n12 * N2 * f2) - 4 * F * N1 * N2 * (N1 + N2 + t1 + t2)) * a
            A2 = (8 * F * (1 - F) * N1 * n22 + 4 * F * (N2 * n22 + t2 * n22 - n12 * N2 * F - N1 * N2 * t1 * F)) * a / 3
            p = aflint.sqrt(aflint.abs(A1 - 3 * A2 * A2) / 3)
            Q = A2 * (2 * A2 * A2 - A1) + a0
            S = -2 * p * aflint.cos((aflint.acos(-Q / (2 * p * p * p)) + Pi) / 3) - A2
        ElseIf t1 > 0 Then
            p = f2 * N1 * n12 + 2 * f2 * n12 * t1 + 2 * n12 * F * N2 + 4 * f2 * N1 * N2 * t1 _
                + N1 * t1 * t1 * f2 + 2 * N1 * t1 * F * N2 + n22 * N1 + 4 * F * n22 * t1
            S = (F * N1 * (N1 + 2 * N2 + t1) - N1 * N2 - aflint.sqrt(N1 * p)) / (4 * N2 * F * (N1 + N2))
        Else
            S = N1 * (F - 1) / (2 * F * (N1 + N2))
        End If



    End Sub



    Sub aflint_FdisNCalcSaddlepointCum(S As Arb, N1 As Arb, N2 As Arb,
F As Arb, t1 As Arb, t2 As Arb,
    ByRef k As Arb, ByRef k1 As Arb, ByRef k2 As Arb, ByRef k3 As Arb, ByRef k4 As Arb,
    ByRef w As Arb, ByRef U As Arb)

        Dim l1 As Arb, l2 As Arb, v1 As Arb, v2 As Arb, g1 As Arb, g2 As Arb
        Dim H1 As Arb, h2 As Arb, g12 As Arb, g22 As Arb
        l1 = N2 / N1 : l2 = -F
        v1 = 1 / (1 - 2 * S * l1) : v2 = 1 / (1 - 2 * S * l2)
        g1 = l1 * v1 : g2 = l2 * v2
        H1 = t1 * v1 : h2 = t2 * v2
        g12 = g1 * g1 : g22 = g2 * g2

        k = 0.5 * (N1 * aflint.log(v1) + N2 * aflint.log(v2)) + S * (t1 * g1 + t2 * g2)
        k1 = g1 * (N1 + H1) + g2 * (N2 + h2)
        k2 = 2 * (g12 * (N1 + 2 * H1) + g22 * (N2 + 2 * h2))
        k3 = 8 * ((g1 * g12) * (N1 + 3 * H1) + (g2 * g22) * (N2 + 3 * h2))
        k4 = 48 * ((g12 * g12) * (N1 + 4 * H1) + (g22 * g22) * (N2 + 4 * h2))

        U = S * aflint.sqrt(k2)
        w = aflint_sign(S) * aflint.sqrt(2 * (S * k1 - k))

        'Debug.Print "K1: ", k1
        'Debug.Print "s: ", S
        Dim C As Arb, f2 As Arb
        Dim a As Arb, b As Arb, Q As Arb
        If t2 = 0 Then
            Console.WriteLine("Linear")
            C = -(g1 * (N1 + H1)) / N2
            f2 = -C / (1 + 2 * S * C)
            Console.WriteLine("F2: {0}", f2)
        Else
            Console.WriteLine("Quadratic")
            C = -(g1 * (N1 + H1))
            a = 4 * C * S * S + 2 * S * N2
            b = -(4 * C * S + t2 + N2)
            Q = aflint.sqrt(b * b - 4 * a * C) / (2 * a)
            Console.WriteLine("F1: {0}", -(b / (2 * a)) + Q, -(b / (2 * a)) - Q)
            f2 = a * (l2 * l2) + b * l2 + C
        End If

    End Sub



    Sub ArbestFdisnPaolella(N1 As Arb, N2 As Arb, F As Arb, t1 As Arb, t2 As Arb,
      ByRef density As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim S As Arb, w As Arb, U As Arb
        Dim k As Arb, k1 As Arb, k2 As Arb, k3 As Arb, k4 As Arb

        Call aflint_FdisnCalcSaddlepoint(S, N1, N2, F, t1, t2)
        Call aflint_FdisNCalcSaddlepointCum(S, N1, N2, F, t1, t2, k, k1, k2, k3, k4, w, U)
        Call aflint_LugannaniRice(w, U, k2, k3, k4, density, LeftTail, RightTail)
        Call aflint_Jensen(w, U)
    End Sub




    Sub aflint_Doubly_Fdisn(N1 As Arb, n2 As Arb, F As Arb, Theta1 As Arb, Theta2 As Arb, ByRef left As Arb, ByRef Right As Arb)
        Dim l2 As Arb, q As Arb, x As Arb, sum As Arb, k As Long, summand As Arb, RelError As Arb, Result As Arb
        Dim y As Arb, a As Arb, b As Arb, l As Arb, r As Arb
        l2 = Theta2 / 2 : q = aflint.t(1)
        x = N1 * F / (n2 + N1 * F) : y = n2 / (N1 * F + n2) : a = N1 / 2 : b = n2 / 2
        Call aflint_Betadisn(a, b, x, y, Theta1, l, r)
        sum = l : k = 0
        'Console.WriteLine("sum0: {0}", sum)
        Do
            k = k + 1
            q = q * l2 / k
            Call aflint_Betadisn(a, b + k, x, y, Theta1, l, r)
            summand = q * l
            sum = sum + summand
            RelError = summand / sum
            'Console.WriteLine("k: {0}, sum: {1}, summand: {2}, RelError: {3}", k, sum, summand, RelError)
        Loop Until aflint.abs(RelError) < aflint.t(0.00000000000001)
        'Console.WriteLine("k: {0}, sum: {1}, summand: {2}, RelError: {3}", k, sum, summand, RelError)

        Result = aflint.exp(-l2) * sum
        left = Result : Right = 1 - left
    End Sub



    Sub aflint_Doubly_Fdisn_Paolella_Combined(N1 As Arb, n2 As Arb, F As Arb, t1 As Arb, t2 As Arb,
        ByRef density As Arb, ByRef LeftTail As Arb, ByRef Righttail As Arb)
        Const eps = 0.1
        Dim sx As Arb
        Dim density1 As Arb, lefttail1 As Arb, RightTail1 As Arb, Density2 As Arb, LeftTail2 As Arb, RightTail2 As Arb
        sx = (1 + t1 / N1) / (1 + t2 / n2)
        If aflint.abs(F - sx) > eps Then
            Call ArbestFdisnPaolella(N1, n2, F, t1, t2, density, LeftTail, Righttail)
            Exit Sub
        End If
        Console.WriteLine("Arb")
        Call ArbestFdisnPaolella(N1, n2, (sx - eps), t1, t2, density1, lefttail1, RightTail1)
        Call ArbestFdisnPaolella(N1, n2, (sx + eps), t1, t2, Density2, LeftTail2, RightTail2)
        density = density1 + (Density2 - density1) * (eps + F - sx) / (2 * eps)
        LeftTail = lefttail1 + (LeftTail2 - lefttail1) * (eps + F - sx) / (2 * eps)
        Righttail = RightTail1 + (RightTail2 - RightTail1) * (eps + F - sx) / (2 * eps)
    End Sub



    Function aflint_Doubly_Fdisn_2M(f1 As Arb, f2 As Arb, x As Arb, l1 As Arb, l2 As Arb, ByRef LeftTail As Arb, ByRef Righttail As Arb) As Arb
        Dim x1 As Arb, m1 As Arb, m2 As Arb, A1 As Arb, b1 As Arb, A2 As Arb, b2 As Arb
        '2 moment approximation
        A1 = f1 + l1
        b1 = A1 + l1
        m1 = A1 * A1 / b1
        A2 = f2 + l2
        b2 = A2 + l2
        m2 = A2 * A2 / b2
        x1 = f1 * A2 * x / (A1 * f2)
        Call aflint_Fdis_a(m1, m2, x1, LeftTail, Righttail)
        Return LeftTail
    End Function


    Function aflint_Doubly_Fdisnx_2M(LeftTail As Arb, Righttail As Arb, f1 As Arb, f2 As Arb, l1 As Arb, l2 As Arb) As Arb
        Dim x1 As Arb, m1 As Arb, m2 As Arb, A1 As Arb, b1 As Arb, A2 As Arb, b2 As Arb
        '2 moment approximation
        A1 = f1 + l1
        b1 = A1 + l1
        m1 = A1 * A1 / b1
        A2 = f2 + l2
        b2 = A2 + l2
        m2 = A2 * A2 / b2
        x1 = fdisxArb(LeftTail, Righttail, m1, m2)
        Return x1 * A1 * f2 / (f1 * A2)
    End Function


    Sub aflint_Demo_Doubly_Fdisn()
        Dim N1 As Arb, n2 As Arb, F As Arb, t1 As Arb, t2 As Arb
        Dim eps As Arb, l As Arb, rt As Arb ' , rt2 As Arb , rt3 As Arb
        Dim density As Arb, LeftTail As Arb, Righttail As Arb
        N1 = aflint.t(1)
        n2 = aflint.t(72)
        F = aflint.t(14.5)
        t1 = aflint.t(10)
        t2 = aflint.t(10)
        eps = aflint.t(0.0000001)
        Call aflint_Doubly_Fdisn_Paolella_Combined(N1, n2, F, t1, t2, density, LeftTail, Righttail)
        Console.WriteLine("L3:   {0}, R: {1}:", LeftTail, Righttail)
        Call aflint_Doubly_Fdisn(N1, n2, F, t1, t2, l, rt)
        Console.WriteLine("L_:   {0}, R: {1}:", l, rt)
        Console.WriteLine("Density: {0}:", density)

    End Sub


    Sub aflint_Demo_Doubly_FdisnX()
        Dim N1 As Arb, n2 As Arb, F As Arb, t1 As Arb, t2 As Arb
        Dim density As Arb, LeftTail As Arb, Righttail As Arb, RefTail As Arb, RelErr As Arb, l1 As Arb, r1 As Arb
        Dim x As Arb
        N1 = aflint.t(2)
        n2 = aflint.t(14)
        t1 = aflint.t(30)
        t2 = aflint.t(20)
        LeftTail = aflint.t(0.001)
        Righttail = 1 - LeftTail
        If LeftTail < aflint.t("0.5") Then RefTail = LeftTail Else RefTail = Righttail
        x = aflint_Doubly_Fdisnx_2M(LeftTail, Righttail, N1, n2, t1, t2)
        Console.WriteLine("***************************************************************")
        Console.WriteLine("X: {0}", x)
        aflint_Doubly_Fdisn_2M(N1, n2, x, t1, t2, LeftTail, Righttail)
        Console.WriteLine("L0_x: {0}, R: {1}", LeftTail, Righttail)
        Do
            aflint_Doubly_Fdisn_Paolella_Combined(N1, n2, x, t1, t2, density, l1, r1)
            'Console.WriteLine("L3_x: {0}, R: {1}", l1, r1)
            l1 = l1 - LeftTail
            RelErr = l1 / RefTail
            x = x - l1 / density
            'Console.WriteLine("X: {0}, RelErr: {1}", x, RelErr)
        Loop Until aflint.abs(RelErr) < aflint.t(0.0000000001)

        aflint_Doubly_Fdisn(N1, n2, x, t1, t2, l1, r1)
        Console.WriteLine("L3_x: {0}, R: {1}", l1, r1)
        l1 = l1 - LeftTail
        RelErr = l1 / RefTail
        Console.WriteLine("X: {0}, RelErr: {1}", x, RelErr)

    End Sub





#End Region






    '**********************************************************************
    'Doubly noncentral t cdf
    ''**********************************************************************

#Region "DoublyNoncentralT"

    Sub ArbDisN_Broda_Combined(n As Arb, t As Arb, mu As Arb, theta As Arb, ByRef PDF As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim eps = aflint.t("0.001")
        Dim sx, CDF As Arb
        Dim PDF1 As Arb, cdf1 As Arb, PDF2 As Arb, cdf2 As Arb
        sx = mu / aflint.sqrt(1 + theta / n)
        If aflint.abs(t - sx) > eps Then
            Call ArbDistDoublyNC_Broda_Combined(n, t, mu, theta, PDF, CDF)
        Else
            Call ArbDistDoublyNC_Broda_Combined(n, sx - eps, mu, theta, PDF1, cdf1)
            Call ArbDistDoublyNC_Broda_Combined(n, sx + eps, mu, theta, PDF2, cdf2)
            PDF = PDF1 + (PDF2 - PDF1) * (eps + t - sx) / (2 * eps)
            CDF = cdf1 + (cdf2 - cdf1) * (eps + t - sx) / (2 * eps)
        End If
        LeftTail = CDF
        RightTail = 1 - CDF
    End Sub


    Sub ArbDistDoublyNC_Broda_Combined(n As Arb, y1 As Arb, mu As Arb, theta As Arb, ByRef PDF As Arb, ByRef CDF As Arb)
        Dim y13 As Arb, y14 As Arb, N2 As Arb, nu As Arb, alpha As Arb, t2 As Arb
        Dim Q As Arb, r As Arb, a As Arb, C1 As Arb, c2 As Arb, C0 As Arb
        Dim y12 As Arb, y2 As Arb, t1 As Arb, d As Arb, U As Arb, w As Arb
        y12 = y1 * y1

        Console.WriteLine("y1: {0}", y1)

        If theta <> 0 Then
            y13 = y12 * y1 : y14 = y12 * y12
            N2 = n * n
            a = y14 + 2 * n * y12 + N2
            c2 = (-2 * y13 * mu - 2 * y1 * n * mu) / a
            C1 = (y12 * mu * mu - n * y12 - N2 - theta * n) / a
            C0 = (y1 * n * mu) / a
            Q = C1 / 3 - c2 * c2 / 9
            r = (C1 * c2 - 3 * C0) / 6 - c2 * c2 * c2 / 27
            y2 = aflint.sqrt(-4 * Q) * aflint.cos((1 / 3) * aflint.acos(r / aflint.sqrt(-Q * Q * Q))) - c2 / 3
            t1 = -mu + y1 * y2
            t2 = -y1 * t1 / (2 * n * y2)
            nu = 1 / (1 - 2 * t2)
            alpha = mu / aflint.sqrt(1 + theta / n)
            d = 1 / (t1 * y2)
            U = aflint.sqrt((y12 + 2 * n * t2) * (2 * n * nu * nu + 4 * theta * nu * nu * nu) + 4 * N2 * y2 * y2) / (2 * n * y2 * y2)
            w = aflint.sqrt((-mu * t1 - n * aflint.log(nu) - 2 * theta * nu * t2)) * aflint_sign(y1 - alpha)
        Else
            If (mu <> 0) Then
                y2 = (mu * y1 + aflint.sqrt(4 * n * (y12 + n) + mu * mu * y12)) / (2 * (y12 + n))
                t1 = -mu + y1 * y2
                t2 = -y1 * t1 / (2 * n * y2)
                d = 1 / (t1 * y2)
                U = aflint.sqrt((mu * y1 * y2 + 2 * n) / (2 * n)) / y2
                w = aflint.sqrt(-mu * t1 - 2 * n * aflint.log(y2)) * aflint_sign(y1 - mu)
            Else
                y2 = aflint.sqrt(n / (y12 + n))
                d = 1 / (y1 * y2 * y2)
                U = 1 / y2
                w = aflint.sqrt(-2 * n * aflint.log(y2)) * aflint_sign(y1)
            End If
        End If

        CDF = NdisArb(w) + NdensArb(w) * (1 / w - d / U)
        PDF = NdensArb(w) * (1 / U)
    End Sub



#End Region







    '**********************************************************************
    'Pearson's rho cdf
    ''**********************************************************************

#Region "PearsonRho"

    'Algorithm by Hotelling, 1953
    Sub aflint_RhoDisN2(n As Arb, r As Arb, rho As Arb, LeftTail As Arb, RightTail As Arb)
        Dim a As Arb ', LeftTail2 As Arb
        Dim gf As Arb, A1 As Arb, sum3 As Arb, summand As Arb, RelError2 As Arb
        Dim m As Integer, k As Integer, smax As Integer, j As Integer, S As Integer
        Dim RelError As Arb, Q As Arb, BK As Arb, sign As Arb, t2 As Arb
        Dim X As Arb, y As Arb, sum As Arb, sum2 As Arb, Factor As Arb, TWO As Arb
        Dim fs(0 To 1) As Arb, Betas(0 To 1) As Arb, Dens(0 To 1) As Arb
        Dim IBeta() As Arb, nk() As Arb
        Dim Swapped As Boolean, slimit As Integer, mlimit As Integer
        slimit = 100
        mlimit = 10

        ReDim IBeta(slimit)
        ReDim nk(mlimit)
        Swapped = False
        If rho > r Then
            r = -r
            rho = -rho
            Swapped = True
        End If
        n = n - 1
        smax = -1

        ' ERROR: constant needs to be in arbitrary precision !!!
        Q = (n - 1) * 0.398942280401433
        Q = Q * aflint.exp(aflint.lgamma(n) - aflint.lgamma(n + 0.5))
        X = ((r - rho) / (1 - rho * r))
        X = X * X
        y = 1 - X
        Factor = aflint.t(1)
        A1 = 1 - rho * rho
        a = aflint.t(1)
        TWO = aflint.t(1)
        RelError = aflint.t(1)
        m = 0
        sum3 = aflint.t(0)
        sum = aflint.t(0)
        While aflint.abs(RelError) > aflint.t("0.0000000001")
            S = 0
            gf = aflint.t(1)
            RelError2 = aflint.t(1)
            While (aflint.abs(RelError2) > aflint.t("0.0000000001"))
                If S > smax Then
                    smax = S
                    If smax > slimit Then
                        slimit = 2 * slimit
                        ReDim Preserve IBeta(slimit)
                    End If
                    If (S Mod 2 <> 0) Then j = 1 Else j = 0
                    If S <= 1 Then
                        Call betadisArb(aflint.t(S + 1) / 2, (n - 1) / 2, X, y, LeftTail, Betas(j), Dens(j))

                        ' ERROR: Lnbeta needs to be in arbitrary precision !!!
                        fs(j) = aflint.exp(Lnbeta((S + 1) / 2, (n.AsDouble - 1) / 2))
                        Dens(j) = 2 * y * Dens(j)
                    Else
                        fs(j) = fs(j) * (S - 1) / (n + S - 2)
                        Dens(j) = Dens(j) * X / (S - 1)
                        Betas(j) = Betas(j) + Dens(j)
                        Dens(j) = Dens(j) * (n + S - 2)
                    End If
                    IBeta(S) = Betas(j) * fs(j)
                End If
                If S = 0 Then
                    sum3 = IBeta(0)
                Else
                    gf = gf * rho * (1.5 - m - S) / S
                    summand = gf * IBeta(S)
                    sum3 = sum3 + summand
                    If sum3 <> 0 Then RelError2 = summand / sum3
                End If
                S = S + 1
            End While
            nk(m) = a * sum3 / 2
            a = a * A1
            If m = 0 Then
                sum = nk(0)
            Else
                TWO = TWO * 2
                Factor = Factor * (2.0# * m - 1) * (2.0# * m - 1) / (m * 4 * (2 * n + 2 * m - 1))
                sum2 = TWO * nk(0)
                t2 = TWO
                sign = aflint.t(-1)
                BK = aflint.t(1)
                For k = 1 To m
                    BK = BK * (m - k + 1) / k
                    t2 = t2 / 2
                    sum2 = sum2 + sign * BK * t2 * nk(k)
                    sign = -sign
                Next k
                sum2 = Factor * sum2
                sum = sum + sum2
                RelError = sum2 / sum
            End If
            m = m + 1
            If m > mlimit Then
                mlimit = 2 * mlimit
                ReDim Preserve nk(mlimit)
            End If
        End While
        '  Debug.Print "smax,m", smax, m, slimit, mlimit
        RightTail = Q * sum
        LeftTail = 1 - RightTail
        If Swapped Then
            sum = RightTail
            RightTail = LeftTail
            LeftTail = sum
        End If
        Erase IBeta
        Erase nk
        '  Debug.Print "slimit: ", slimit, "mlimit:", mlimit
    End Sub



    Sub aflint_RhoDisN1(n As Integer, r As Arb, rho As Arb,
      LeftTail As Arb, RightTail As Arb)
        Dim delta As Arb, t As Arb, result As Arb
        t = r * aflint.sqrt((n - 2) / (1 - r * r))
        delta = rho * aflint.sqrt((n - 2) / (1 - rho * rho))
        '   result = tdisn(n - 2, t, delta, LeftTail, RightTail)
        result = ArbdisnOwen(n - 2, t, delta, LeftTail, RightTail)

    End Sub


    Sub aflint_demordisn_nc()
        Dim LeftTail As Arb, RightTail As Arb, n As Arb ', d As Arb, t As Arb, p As Arb, t2 As Arb, p2 As Arb
        Dim z As Arb, RefTail As Arb ', CDF As Arb, PDF As Arb, i As Long, RelErr As Arb
        Dim rho_alpha As Arb, rho As Arb, rTail As Arb ', d_rho  As Arb, t_delta As Arb
        LeftTail = aflint.t(0.99)
        RightTail = 1 - LeftTail
        If LeftTail < aflint.t("0.5") Then RefTail = LeftTail Else RefTail = RightTail
        z = ndisxArb(LeftTail, RightTail)
        n = aflint.t(14)
        rho = aflint.t(0.6)

        'Debug.Print "****************************************************************"

        rho_alpha = aflint_Rhodis_NC(n, rho, LeftTail, RightTail)
        Console.WriteLine("rho_alpha W: {0}, {1}, {2}, {3}", rho_alpha, 1 - rho_alpha, LeftTail, RightTail)

        rTail = aflint_RhoDis_W(rho, n, rho_alpha)
        Console.WriteLine("rTail: {0}", rTail)


    End Sub





    Function aflint_CornishFisher4_kappa(z As Arb, k1 As Arb, k2 As Arb, k3 As Arb, k4 As Arb) As Arb
        Dim U As Arb, u2 As Arb, u3 As Arb, X As Arb, g1 As Arb, g2 As Arb
        g1 = k3 / (aflint.sqrt(k2) * k2)
        g2 = k4 / (k2 * k2)
        U = (z - k1) / aflint.sqrt(k2)
        u2 = U * U : u3 = U * u2
        X = U - (u2 - 1) * g1 / 6 - (u3 - 3 * U) * g2 / 24 + (4 * u3 - 7 * U) * g1 * g1 / 36
        Return NdisArb(X)
    End Function


    Function aflint_CornishFisher4_kappa_X(LeftTail As Arb, RightTail As Arb, k1 As Arb, k2 As Arb, k3 As Arb, k4 As Arb) As Arb
        Dim U As Arb, u2 As Arb, u3 As Arb, X As Arb, g1 As Arb, g2 As Arb
        g1 = k3 / (aflint.sqrt(k2) * k2)
        g2 = k4 / (k2 * k2)
        U = ndisxArb(LeftTail, RightTail)
        u2 = U * U : u3 = U * u2
        X = U + (u2 - 1) * g1 / 6 + (u3 - 3 * U) * g2 / 24 + (2 * u3 - 5 * U) * g1 * g1 / 36
        Return k1 + aflint.sqrt(k2) * X
    End Function


    Function aflint_Fisher_kappa_X(LeftTail As Arb, RightTail As Arb, n As Arb, rho As Arb) As Arb
        Dim Rho2 As Arb, rho3 As Arb, rho4 As Arb, N1 As Arb, N2 As Arb, n3 As Arb
        Dim k1 As Arb, k2 As Arb, k3 As Arb, k4 As Arb, y As Arb ', e As Arb
        ' Note: n = sample size
        N1 = n - 1
        N2 = N1 * N1
        n3 = N2 * N1
        Rho2 = rho * rho
        rho3 = Rho2 * rho
        rho4 = Rho2 * Rho2
        k1 = 0.5 * aflint.log((1 + rho) / (1 - rho)) + rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1)
        k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1
        k3 = rho3 / n3
        k4 = 2 / n3
        y = aflint_CornishFisher4_kappa_X(LeftTail, RightTail, k1, k2, k3, k4)
        Return aflint_zTransformInverse(y)
    End Function

    Function aflint_zTransformInverse(y As Arb) As Arb
        y = aflint.exp(2 * y)
        Return (y - 1) / (y + 1)
    End Function

    Function aflint_zTransform(r As Arb) As Arb
        Return 0.5 * aflint.log((1 + r) / (1 - r))
    End Function

    Function aflint_Fisher_simple(r As Arb, n As Arb, rho As Arb) As Arb
        Dim X As Arb
        X = (aflint_zTransform(r) - aflint_zTransform(rho)) * aflint.sqrt(n - 3)
        Return NdisArb(X)
    End Function



    Function aflint_Fisher_simple_X(LeftTail As Arb, RightTail As Arb, n As Arb, rho As Arb) As Arb
        Dim k1 As Arb, U As Arb, y As Arb ', e As Arb
        U = ndisxArb(LeftTail, RightTail)
        k1 = aflint_zTransform(rho)
        '  k1 = 0.5 * Log((1 + rho) / (1 - rho))
        y = U / aflint.sqrt(n - 3) + k1
        Return aflint_zTransformInverse(y)
    End Function

    Sub aflint_DemoFisher_kappa_X()
        Dim LeftTail As Arb, RightTail As Arb, r As Arb
        Dim n As Arb, rho As Arb, result As Arb
        Dim lefttail1 As Arb, RightTail1 As Arb
        n = aflint.t(17)
        rho = aflint.t(-0.714)
        LeftTail = aflint.t(0.90000005)
        RightTail = 1 - LeftTail
        Console.WriteLine("----------------------")
        r = aflint_Fisher_simple_X(LeftTail, RightTail, n, rho)
        Console.WriteLine("r_alpha: {0}, {1}", r, 1 - r)
        result = aflint_Fisher_simple(r, n, rho)
        Console.WriteLine("Fishersimp: {0} ", result)
        Call aflint_RhoDisN2(n, r, rho, lefttail1, RightTail1)
        Console.WriteLine("LeftTail {0}", lefttail1)

        r = aflint_Fisher_kappa_X(LeftTail, RightTail, n, rho)
        Console.WriteLine("r_alpha: {0}, {1}", r, 1 - r)
        result = aflint_Fisher_kappa(r, n, rho)
        Console.WriteLine("Fisherk:  {0}", result)

        Call aflint_RhoDisN2(n, r, rho, lefttail1, RightTail1)
        Console.WriteLine("LeftTail: {0}", lefttail1)

        r = aflint_Rhodisx_W(LeftTail, RightTail, n, rho)
        Console.WriteLine("r_alpha W: {0}, {1}, {2}, {3}, {4}, {5}", r, 1 - r, LeftTail, RightTail, n, rho)

        lefttail1 = aflint_RhoDis_W(r, n, rho)
        Console.WriteLine("LeftTail W: {0}", lefttail1)

        Call aflint_RhoDisN2(n, r, rho, lefttail1, RightTail1)
        Console.WriteLine("LeftTail W: {0}", lefttail1)

    End Sub

    Function aflint_Fisher_kappa(r As Arb, n As Arb, rho As Arb) As Arb
        Dim Rho2 As Arb, rho3 As Arb, rho4 As Arb, N1 As Arb, N2 As Arb, n3 As Arb
        Dim z As Arb, k1 As Arb, k2 As Arb, k3 As Arb, k4 As Arb
        ' Note: n = sample size
        N1 = n - 1
        N2 = N1 * N1
        n3 = N2 * N1
        Rho2 = rho * rho
        rho3 = Rho2 * rho
        rho4 = Rho2 * Rho2
        z = 0.5 * aflint.log((1 + r) / (1 - r))
        k1 = 0.5 * aflint.log((1 + rho) / (1 - rho)) + rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1)
        k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1
        k3 = rho3 / n3
        k4 = 2 / n3
        Return aflint_CornishFisher4_kappa(z, k1, k2, k3, k4)
    End Function


    Function aflint_CornishFisher4_kappa2(z As Arb, k1 As Arb, k2 As Arb, k3 As Arb, k4 As Arb, k6 As Arb) As Arb
        Dim U As Arb, u2 As Arb, u3 As Arb, u4 As Arb, u5 As Arb, X As Arb, g1 As Arb, g2 As Arb, g4 As Arb
        g1 = k3 / (aflint.sqrt(k2) * k2)
        g2 = k4 / (k2 * k2)
        g4 = k6 / (k2 * k2 * k2)
        U = (z - k1) / aflint.sqrt(k2)
        u2 = U * U : u3 = U * u2 : u5 = u3 * u2 : u4 = u2 * u2
        X = U - (u2 - 1) * g1 / 6 - (u3 - 3 * U) * g2 / 24 + (4 * u3 - 7 * U) * g1 * g1 / 36
        X = X + (11 * u4 - 42 * u2 + 15) * g1 * g2 / 144
        X = X - (u5 - 10 * u3 + 15 * U) * g4 / 720
        Return NdisArb(X)
    End Function


    Function aflint_Fisher_kappa2(r As Arb, n As Arb, rho As Arb) As Arb
        Dim Rho2 As Arb, rho3 As Arb, rho4 As Arb, N1 As Arb, N2 As Arb, n3 As Arb
        Dim z As Arb, k1 As Arb, k2 As Arb, k3 As Arb, k4 As Arb, k6 As Arb
        ' Note: n = sample size
        N1 = n - 1
        N2 = N1 * N1
        n3 = N2 * N1
        Rho2 = rho * rho
        rho3 = Rho2 * rho
        rho4 = Rho2 * Rho2
        z = 0.5 * aflint.log((1 + r) / (1 - r)) - 0.5 * aflint.log((1 + rho) / (1 - rho))
        k1 = rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1)
        k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1
        k3 = rho3 / n3
        k4 = 2 / n3 + 3 * (4 - rho4) / (N2 * N2)
        k6 = 24 / (n3 * N2)
        k6 = aflint.t(0)
        Return aflint_CornishFisher4_kappa2(z, k1, k2, k3, k4, k6)
    End Function


    'These approximations are sensitive to whether rho and or r are negative. Still need to figure out the details!!!

    'Algorithm by Winterbottom, 1980
    Function aflint_RhoDis_W(r As Arb, n As Arb, rho As Arb) As Arb
        Dim y As Arb, m As Arb, w As Arb, r2 As Arb, r3 As Arb, r4 As Arb, m2 As Arb
        Dim w2 As Arb, w3 As Arb, w5 As Arb
        r2 = r * r : r3 = r2 * r
        r4 = r2 * r2
        m = n - 1
        m2 = m * m
        w = (aflint_zTransform(r) - aflint_zTransform(rho))
        w2 = w * w : w3 = w2 * w : w5 = w2 * w3
        y = -r / (2 * m) - (3 * r + r3) / (12 * m2)
        y = y + (1 - (1 + r2) / (4 * m) + (3 - 11 * r4) / (96 * m2)) * w
        y = y + ((3 * r - 4 * r3) / (24 * m)) * w2
        y = y - ((1 / 12) - (2 + 7 * r2 - 6 * r4) / (48 * m)) * w3
        y = y + (3 / 160) * w5
        Return NdisArb(aflint.sqrt(m) * y)
    End Function



    'Algorithm by Winterbottom, 1980
    Function aflint_Rhodisx_W(LeftTail As Arb, RightTail As Arb, n As Arb, rho As Arb) As Arb
        Dim y As Arb, X As Arb, m As Arb, m2 As Arb, m12 As Arb, m32 As Arb, m52 As Arb
        Dim Rho2 As Arb, rho3 As Arb, rho4 As Arb, z As Arb, x2 As Arb, x3 As Arb, x4 As Arb, x5 As Arb
        X = ndisxArb(LeftTail, RightTail)
        z = aflint_zTransform(rho)
        '  z = 0.5 * Log((1 + rho) / (1 - rho))
        m = n - 1
        m2 = m * m : m12 = aflint.sqrt(m) : m32 = m * m12 : m52 = m2 * m12
        x2 = X * X : x3 = x2 * X : x4 = x3 * X : x5 = x4 * X
        Rho2 = rho * rho : rho3 = Rho2 * rho : rho4 = rho3 * rho
        y = z + X / m12 + rho / (2 * m)
        y = y + (x3 + 3 * (3 - Rho2) * X) / (12 * m32)
        y = y + (4 * rho3 * x2 - rho3 + 15 * rho) / (24 * m2)
        y = y + (x5 + (-60 * rho4 + 30 * Rho2 + 80) * x3 + (45 * rho4 - 21 * Rho2 + 375) * X) / (480 * m52)
        Return aflint_zTransformInverse(y)
        '  Rhodisx_W = (Exp(2 * y) - 1) / (Exp(2 * y) + 1)
    End Function



    'Algorithm by Winterbottom, 1980
    Function aflint_Rhodis_NC(n As Arb, r As Arb, LeftTail As Arb, RightTail As Arb) As Arb
        Dim y As Arb, X As Arb, m As Arb, m2 As Arb, m12 As Arb, m32 As Arb, m52 As Arb
        Dim r2 As Arb, r3 As Arb, r4 As Arb, z As Arb, x2 As Arb, x3 As Arb, x4 As Arb, x5 As Arb
        X = ndisxArb(LeftTail, RightTail)
        z = aflint_zTransform(r)
        '  z = 0.5 * Log((1 + r) / (1 - r))
        m = n - 1
        m2 = m * m : m12 = aflint.sqrt(m) : m32 = m * m12 : m52 = m2 * m12
        x2 = X * X : x3 = x2 * X : x4 = x3 * X : x5 = x4 * X
        r2 = r * r : r3 = r2 * r : r4 = r3 * r
        y = z + X / m12 - r / (2 * m)
        y = y + (x3 + 3 * (1 + r2) * X) / (12 * m32)
        y = y - (4 * r3 * x2 + 5 * r3 + 9 * r) / (24 * m2)
        y = y + (x5 + (60 * r4 - 30 * r2 + 20) * x3 + (165 * r4 + 30 * r2 + 15) * X) / (480 * m52)
        Return aflint_zTransformInverse(y)
        '  Rhodis_NC = (Exp(2 * y) - 1) / (Exp(2 * y) + 1)
    End Function






    Sub aflint_DemoRhoExplicit()
        Dim n As Integer, r As Arb, rho As Arb, result As Arb
        Dim LeftTail As Arb, density As Arb
        ' Smallest N: N = 3
        n = 6
        r = aflint.t(0.1)
        rho = aflint.t(0.99)
        result = RhoExplicit_Arb(n, r, rho)
        '  Call RhoDisN2(n, r, rho, LeftTail, RightTail)
        '  Debug.Print LeftTail, RightTail
        Console.WriteLine("result: {0}, result / LeftTail: {1}", result, result / LeftTail)
        density = aflint_RhoDensity(n, r, rho)
        Console.WriteLine("density: {0}", density)
    End Sub


    Function aflint_RhoDensity(n As Long, r As Arb, rho As Arb) As Arb
        Dim w As Arb, t As Arb
        Dim X As Arb, x2 As Arb, r2 As Arb, Rho2 As Arb, U As Arb, k1 As Arb
        Dim A2 As Arb, a As Arb, c2 As Arb, C As Arb, b2 As Arb, b As Arb
        Dim ACTerm As Arb, density As Arb

        Const Pi = 3.14159265358979
        r2 = r * r : Rho2 = rho * rho
        X = r * rho : x2 = X * X : w = 0.5 * (1 + X)
        A2 = 1 - Rho2 : a = aflint.sqrt(A2)
        c2 = 1 - r2 : C = aflint.sqrt(c2)
        b2 = 1 - x2 : b = aflint.sqrt(b2)
        U = aflint.acos(-X) / b

        t = Arb1(aflint.t(n), w)
        k1 = ((n - 2) / aflint.sqrt(2 * Pi)) * aflint.exp(LnGamma(n - 1) - LnGamma(n - 0.5))
        ACTerm = aflint.exp(aflint.log(a) * (n - 1) + aflint.log(C) * (n - 4) + aflint.log(1 - X) * (1.5 - n))
        density = k1 * ACTerm * t
        Return density

    End Function


    'Hypergeometric function for density of pearson's rho
    Function Arb1(n As Arb, w As Arb) As Arb
        Dim i As Integer, A1 As Arb, C1 As Arb, m1 As Arb, sum As Arb, RelErr As Arb
        A1 = aflint.t(0.5)
        C1 = n - 0.5
        m1 = 0.25 * w / C1
        sum = 1 + m1
        i = 1
        Do
            i = i + 1
            A1 = A1 + 1
            C1 = C1 + 1
            m1 = m1 * A1 * A1 * w / (C1 * i)
            sum = sum + m1
            RelErr = m1 / sum
            '  Debug.Print i, sum, M1, M1 / sum
        Loop Until RelErr < aflint.t("1E-15")
        Return sum
    End Function




    ' Algorithm by Guenther
    Sub aflint_RhoDisN5(n As Arb, r As Arb, rho As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Const Pi = 3.14159265358979
        Dim sign As Arb, r2 As Arb, Rho2 As Arb, Left1 As Arb, Right1 As Arb
        Dim RelError As Arb, summand As Arb, sum0 As Arb, sum1 As Arb,
            sum2 As Arb, k1 As Arb, k2 As Arb, density As Arb
        Dim j As Long
        Dim sum4 As Arb, sum3 As Arb, RelError3 As Arb
        Rho2 = rho * rho
        r2 = r * r
        If rho < 0 Then sign = aflint.t(-1) Else If rho > 0 Then sign = aflint.t(1) Else sign = aflint.t(0)
        Call betadisArb(aflint.t(1 / 2), (n - 1) / 2, Rho2, 1 - Rho2, Left1, Right1, density)
        sum0 = 0.5 * (1 + sign * Left1)
        If r = 0 Then
            RightTail = sum0
            LeftTail = 1 - RightTail
            Exit Sub
        End If
        k1 = 0.5 * aflint.exp(aflint.log(1 - Rho2) * (n - 1) / 2)
        Call betadisArb(aflint.t(1 / 2), (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
        sum1 = k1 * Left1
        sum3 = k1 * Right1
        j = 0 : RelError = aflint.t(1) : RelError3 = aflint.t(1)
        While RelError > aflint.t("1E-15")
            j = j + 1
            k1 = ((2 * j + n - 3) / (2 * j)) * Rho2 * k1
            Call betadisArb(aflint.t(2 * j + 1) / 2, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
            summand = k1 * Left1
            sum1 = sum1 + summand
            RelError = summand / sum1
            summand = k1 * Right1
            sum3 = sum3 + summand
            If sum3 <> 0 Then RelError3 = summand / sum3
            '    Debug.Print j, sum1, RelError, Left1
            '    Debug.Print j, sum3, RelError3, Right1
        End While
        '  Debug.Print "Gunther j1:", j
        If rho = 0 Then
            sum2 = aflint.t(0) : sum4 = aflint.t(0)
        Else
            k2 = rho / aflint.sqrt(Pi) * aflint.exp(aflint.lgamma(n / 2) - aflint.lgamma((n - 1) / 2) + aflint.log(1 - Rho2) * (n - 1) / 2)
            Call betadisArb(aflint.t(1), (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
            sum2 = k2 * Left1
            sum4 = k2 * Right1
            j = 0 : RelError = aflint.t(1) : RelError3 = aflint.t(1)
            While RelError > aflint.t("1E-15")
                j = j + 1
                k2 = ((2 * j + n - 2) / (2 * j + 1)) * Rho2 * k2
                Call betadisArb(aflint.t(j + 1), (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
                summand = k2 * Left1
                sum2 = sum2 + summand
                If sum2 <> 0 Then RelError = summand / sum2
                summand = k2 * Right1
                sum4 = sum4 + summand
                If sum4 <> 0 Then RelError3 = summand / sum4
                '    Debug.Print j, sum2, RelError, Left1
                '    Debug.Print j, sum4, RelError3, Right1
            End While
            '  Debug.Print "j2:"; j
        End If
        '  Debug.Print "sum0:", 1 - sum0, sum0
        '  Debug.Print "sum1:", sum1, sum2, sum1 + sum2
        '  Debug.Print "sum3:", sum3, sum4, sum3 + sum4
        '  Debug.Print "sum5:", , sum1 + sum3, sum2 + sum4
        RightTail = sum0 - (sum1 + sum2)
        LeftTail = (1 - sum0) + (sum1 + sum2)
    End Sub



    Sub aflint_demoRho_Guenther()
        Dim result As Arb, n As Integer, rho As Arb, r As Arb ', X As Arb, y As Arb
        Dim LeftTail As Arb, RightTail As Arb ', l2 As Arb, r2 As Arb
        n = 7
        r = aflint.t(0.236)
        rho = aflint.t(0.9)
        RightTail = aflint.t(0.05)
        LeftTail = 1 - RightTail
        '  r = RhoDisX0(LeftTail, RightTail, n)
        Console.WriteLine("r: {0}", r)
        Call aflint_RhoDisN5(aflint.t(n), r, rho, LeftTail, RightTail)
        Console.WriteLine("Guenther: {0}, {1} ", LeftTail, RightTail)
        '  Debug.Print ndisx(LeftTail, RightTail)
        '  LeftTail = tdisn(N - 2, R * Sqr((N - 2) / (1 - R * R)), 0, L2, R2)
        '  RightTail = 1 - LeftTail
        '  Debug.Print LeftTail, RightTail
        '  Call RhoDisN2(n, r, rho, LeftTail, RightTail)
        '  Debug.Print "Hotelling: ", LeftTail, RightTail
        LeftTail = RhoExplicit_Arb(n, r, rho)
        Console.WriteLine("RhoExplicit: {0}, {1} ", LeftTail, 1 - LeftTail)

        '    result = Rhodis_B(r, n, rho)
        '  Debug.Print "Fisherb:  ", result
        '    result = Rhodis_B_2(r, n, rho)
        '  Debug.Print "Fisherb2:  ", result
        '
        result = aflint_Fisher_kappa(r, aflint.t(n), rho)
        Console.WriteLine("Fisherk: {0} ", result)
        result = aflint_Fisher_kappa2(r, aflint.t(n), rho)
        Console.WriteLine("Fisherk2: {0} ", result)

    End Sub


#End Region








    '**********************************************************************
    'Rho2 cdf
    ''**********************************************************************


#Region "Rho2"

    Function aflint_Rho2DisN8(IsGLM As Boolean, p As Arb, n As Arb,
X As Arb, Rho2 As Arb) As Arb
        Dim LeftTail As Arb, RightTail As Arb
        ' p: df1=# of variables-1
        ' N: df2=# of observatons - # of variables
        Call aflint_R2DisN(IsGLM, p, n, X, Rho2, LeftTail, RightTail)
        Return LeftTail
    End Function


    Sub aflint_R2DisN(IsGLM As Boolean, p As Arb, n As Arb,
X As Arb, Rho2 As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        ' p: df1=# of variables-1
        ' N: df2=# of observatons - # of variables
        p = p + 1
        If IsGLM Then
            Call aflint_RHO2_EXACT_I(X, p, n + p, Rho2, LeftTail, RightTail)
        Else
            Call aflint_RHO2_EXACT(False, X, p, n + p, Rho2, LeftTail, RightTail)
        End If
    End Sub




    Sub aflint_RHO2_EXACT(IsOdd As Boolean, X As Arb, p As Arb,
ng As Arb, Rho2 As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim p1 As Arb, y As Arb, summand As Arb, RelErr As Arb,
            k As Arb, a As Arb, n As Arb
        Dim density As Arb, BK As Arb, t1 As Arb, theta As Arb,
            b As Arb, cj As Arb, lefttail1 As Arb,
            RightTail1 As Arb, sum As Arb, binom As Arb
        Dim j As Long

        a = 1.0# / (1 - Rho2)
        n = ng - 1
        k = (ng - p) / 2
        If IsOdd Then
            theta = -Rho2
            b = aflint.t(1)
            BK = -n / 2
        Else
            theta = Rho2 / (1 - Rho2)
            b = a
            BK = k
        End If
        '{  cj=1}
        p1 = (p - 1) / 2
        binom = aflint.t(1)
        t1 = aflint.t(1)
        y = 2 * k * X / (b * (1 - X))
        y = y / (y + 2 * k)
        Call betadisArb(p1, k, y, 1 - y, lefttail1, RightTail1, density)
        sum = lefttail1
        j = 1
        Do
            binom = binom * (BK - j + 1) / j
            t1 = t1 * theta
            cj = binom * t1
            Call betadisArb(p1 + j, k, y, 1 - y, lefttail1, RightTail1, density)
            summand = cj * lefttail1
            sum = sum + summand
            RelErr = summand / sum
            j = j + 1
        Loop Until RelErr < aflint.t("0.000000000001")
        If Not (IsOdd) Then sum = sum * aflint.exp(aflint.log(b) * (p - 1) / 2)
        sum = sum / aflint.exp(aflint.log(a) * n / 2)
        LeftTail = sum
        RightTail = 1 - sum
    End Sub

    Sub aflint_RHO2_EXACT_I(X As Arb, p As Arb, ng As Arb, Rho2 As Arb,
    ByRef LeftTail As Arb, ByRef RightTail As Arb)
        Dim y As Arb, lambda As Arb, DF1 As Arb, DF2 As Arb ', l1 As Arb, r1 As Arb
        y = X / (1 - X) * (ng - p) / (p - 1)
        lambda = Rho2 * (ng - p) / (1 - Rho2)
        DF1 = p - 1
        DF2 = ng - p
        RightTail = aflint_Fdisn(DF1, DF2, y, lambda)
        LeftTail = 1 - RightTail
        '  LeftTail = Fdisn(DF1, DF2, y, lambda, l1, r1)
        '  RightTail = 1 - LeftTail

    End Sub

#End Region




    Sub aflint_DemoNoncentral()
        ArbPrec.SetDps(60)
        Dim eps = aflint.epsilon()
        Console.WriteLine("eps: {0}", eps)

        Dim nu, mu, a, b, x, nc, nc2, xbeta, ybeta, LeftTail0, RightTail0 As New Arb
        Dim LeftTail1, RightTail1 As New Arb
        Dim LeftTail2, RightTail2 As New Arb
        Dim LeftTail3, RightTail3 As New Arb
        Dim LeftTail3d, RightTail3d As Double
        Dim PDF As New Arb
        Dim PDFd As Double
        Dim dis As Int32 = 4
        mu = aflint.t(6)
        nu = aflint.t(40)
        x = aflint.t(61.0)
        nc = aflint.t(0)
        nc2 = aflint.t(6)

        Dim n As Int32 = aflint.lrint(nu)

        a = mu / 2
        b = nu / 2
        xbeta = mu * x / (mu * x + nu)
        ybeta = 1 - xbeta

        Select Case dis
            Case 1 : Console.WriteLine("Noncentral Chi-Square")
                'Cdisn2(nu, x, nc, LeftTail0, RightTail0)
                'LeftTail1 = aflint.t(dreal.dist_pchisq_nc(x.AsDouble, nu.AsDouble, nc.AsDouble, True, False))
                'RightTail1 = aflint.t(dreal.dist_pchisq_nc(x.AsDouble, nu.AsDouble, nc.AsDouble, False, False))
                aflint_non_central_chi_square(x, nu, nc, LeftTail2, RightTail2)
                aflint_NonCentralChi2_SPA2(nu, x, nc, LeftTail3, RightTail3)

            Case 2 : Console.WriteLine("Noncentral t")
                'tdisn(nu, x, nc, LeftTail0, RightTail0)
                'LeftTail1 = aflint.t(dreal.dist_pt_nc(x.AsDouble, nu.AsDouble, nc.AsDouble, True, False))
                'RightTail1 = aflint.t(dreal.dist_pt_nc(x.AsDouble, nu.AsDouble, nc.AsDouble, False, False))
                ArbdisnOwen(n, x, nc, LeftTail2, RightTail2)
                ArbDisN_Broda_Combined(nu, x, nc, aflint.t(0), PDF, LeftTail3, RightTail3)

            Case 3 : Console.WriteLine("Noncentral F")
                'Fdisn2(mu, nu, x, nc, LeftTail0, RightTail0)
                'LeftTail1 = aflint.t(dreal.dist_pf_nc(x.AsDouble, mu.AsDouble, nu.AsDouble, nc.AsDouble, True, False))
                'RightTail1 = aflint.t(dreal.dist_pf_nc(x.AsDouble, mu.AsDouble, nu.AsDouble, nc.AsDouble, False, False))
                aflint_fdisnOwen2(x, mu, n, nc, LeftTail2, RightTail2)
                'FdisnPaolella(mu.AsDouble, nu.AsDouble, x.AsDouble, nc.AsDouble, 0, PDFd, LeftTail3d, RightTail3d)
                'PDF = PDFd : LeftTail3 = LeftTail3d : RightTail3 = RightTail3d

            Case 4 : Console.WriteLine("Noncentral beta")
                'Betadisn(a, b, xbeta, ybeta, nc, LeftTail0, RightTail0)
                'LeftTail1 = aflint.t(dreal.dist_pbeta_nc(xbeta.AsDouble, a.AsDouble, b.AsDouble, nc.AsDouble, True, False))
                'RightTail1 = aflint.t(dreal.dist_pbeta_nc(xbeta.AsDouble, a.AsDouble, b.AsDouble, nc.AsDouble, False, False))
                '                LeftTail1 = dreal.dist_pf_nc(x, mu, nu, nc, True, False)
                '                RightTail1 = dreal.dist_pf_nc(x, mu, nu, nc, False, False)

            Case Else : Console.WriteLine("Not implemented")

        End Select

        'Console.WriteLine("LeftTail0: {0}, RightTail0: {1}", LeftTail0, RightTail0)
        Console.WriteLine("LeftTail1: {0}, RightTail1: {1}", LeftTail1, RightTail1)
        Console.WriteLine("LeftTail2: {0}, RightTail2: {1}", LeftTail2, RightTail2)
        Console.WriteLine("LeftTail3: {0}, RightTail3: {1}", LeftTail3, RightTail3)
        Console.WriteLine("PDF:  {0}", PDF)
    End Sub





End Module
