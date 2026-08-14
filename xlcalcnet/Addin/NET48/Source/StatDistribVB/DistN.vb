Imports System
Imports System.Numerics
Imports System.Diagnostics

Imports FixedPrecNet

'Imports mpFunLabNET
'Imports fpFunLabNET


'!!! Need to replace all references to boost2  !!!

Module boost2
    
    
    Function gamma(x As Double) As Double
        Return dreal.real_gamma(x)
    End Function


    Function gamma_delta_ratio(x As Double, y As Double) As Double
        Return dreal.real_gamma_delta_ratio(x, y)
    End Function


    Function gamma_p_derivative(a As Double, x As Double) As Double
        Return dreal.real_gamma_p_prime(a, x)
    End Function
    
    
    Function gamma_q(a As Double, x As Double) As Double
        Return dreal.real_gamma_q(a, x)
    End Function
    
    Function gamma_p(a As Double, x As Double) As Double
        Return dreal.real_gamma_p(a, x)
    End Function
    
    
    Function dist_normal(xqp As Double, mean As Double, sd As Double, target As Double) As Double
        Return 1
    End Function
    
    
    
    Function ibeta_derivative(a As Double, b As Double, x As Double) As Double
        Return dreal.real_ibeta_prime(a, b, x)
    End Function
    
    
    Function ibeta(a As Double, b As Double, x As Double) As Double
        Return dreal.real_ibeta(a, b, x)
    End Function
    
    
    
    Function owens_t(a As Double, h As Double) As Double
        Return 1
    End Function
    
    
    
    
    Function dist_student_t(xqp As Double, df As Double, target As Double) As Double
        Return 1
    End Function




    Function dist_chisq(xqp As Double, df As Double, target As Double) As Double
        Dim result As Double = Double.NaN
        Dim rv = dreal.dist_chi2(df)
        If (target = 6) Then result = rv.qtf(xqp)
        If (target = 7) Then result = rv.sf(xqp)
        Return result
    End Function



    Function dist_fisher_f(xqp As Double, df1 As Double, df2 As Double, target As Double) As Double
        Return 1
    End Function



    Function dist_beta(xqp As Double, a As Double, b As Double, target As Integer) As Double
        Dim result As Double = Double.NaN
        Dim rv = dreal.dist_beta(a, b)
        If (target = 2) Then result = rv.cdf(xqp)
        If (target = 3) Then result = rv.sf(xqp)
        If (target = 6) Then result = rv.qtf(xqp)
        Return result
    End Function


    Function polygamma(r As Integer, x As Double) As Double
        Return dreal.polygamma(r, x)
    End Function





End Module





Module DistN





    '**********************************************************************
    'Noncentral ChiSquare
    ''**********************************************************************


#Region "Noncentral ChiSquare"



    Function Get_Normal_Delta(alpha As Double, Beta As Double) As Double
        Dim xa = ndisx(1 - alpha, alpha)
        Dim xb = ndisx(Beta, 1 - Beta)
        Dim Delta = xa - xb
        Return Delta
    End Function



    Sub GetL(F As Double, ByRef Chi2 As Double, ByRef lambda As Double, alpha As Double, Beta As Double)
        Dim t As Double, n As Double, t2 As Double, t3 As Double, t4 As Double, X As Double,
          x2 As Double, x3 As Double, x4 As Double, x5 As Double, y As Double, Y_12 As Double,
          Y_32 As Double, Y_52 As Double, Y_4 As Double, Y_112 As Double
        X = ndisx(1 - Beta, Beta)
        Chi2 = cdisx(1 - alpha, alpha, F)
        t = (Chi2 - F) / F
        n = F
        t2 = t * t : t3 = t2 * t : t4 = t3 * t
        x2 = X * X : x3 = x2 * X : x4 = x3 * X : x5 = x4 * X
        y = 2 * t + 1 : Y_12 = Math.Sqrt(y) : Y_32 = y * Y_12 * Math.Sqrt(n)
        Y_52 = y * Y_32 : Y_4 = Y_52 * Y_32 : Y_112 = Y_4 * Y_32
        lambda = n * t + Math.Sqrt(2 * n * y) * X + 2 * ((3 * t + 2) * x2 + (3 * t + 1)) / (3 * y) _
              - Math.Sqrt(2) * ((6 * t + 5) * x3 - (36 * t2 + 42 * t + 17) * X) / (18 * Y_52) _
              + ((324 * t2 + 594 * t + 276) * x4 - (1080 * t3 + 2484 * t2 + 2394 * t + 976) * x2 _
              + (1080 * t3 + 1512 * t2 + 612 * t + 148)) / (405 * Y_4) _
              - Math.Sqrt(2) * ((10368 * t3 + 30780 * t2 + 30564 * t + 10143) * x5 _
              - (25920 * t4 + 98928 * t3 + 163080 * t2 + 137544 * t + 47188) * x3 _
              + (45360 * t4 + 106704 * t3 + 80460 * t2 + 31092 * t + 13489) * X) / (9720 * Y_112)
        If lambda < 0 Then lambda = 0.00001
    End Sub



    Function NoncentralChisquareX_Approx(n As Double, lambda As Double, LeftTail As Double, RightTail As Double) As Double
        Dim n1 = (n + lambda) ^ 2 / (n + 2 * lambda)
        Dim b = lambda / (n + lambda)
        Dim x = cdisx(LeftTail, RightTail, n1)
        Return (1 + b) * x
    End Function


    Sub DemoQuantileNoncentralChisquare()
        Dim LeftTail As Double, Righttail As Double, RefTail As Double
        Dim x1 As Double, lambda As Double
        Dim IsGLM As Boolean = True
        Dim IsExact As Boolean = False
        Dim Df1 = 24
        lambda = 30.0
        'LeftTail = 0.9999
        'Righttail = 1 - LeftTail
        LeftTail = 0.0001
        Righttail = 1 - LeftTail

        If LeftTail < 0.5 Then RefTail = LeftTail Else RefTail = Righttail
        Dim LogBeta = Math.Log(LeftTail)

        x1 = NoncentralChisquareX_Approx(Df1, lambda, LeftTail, Righttail)
        LeftTail = non_central_chi_square_cdf(x1, Df1, lambda)

        Dim fx1 = LeftTail
        Console.WriteLine("x1: {0}, fx1: {1}", x1, fx1)

        Dim lnPower = Math.Log(LeftTail)
        Dim L1 = x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = LogBeta - lnPower : Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = +1 Else LSign = -1
        Dim Factor = 0.1
        Dim LStep = x1 * (Factor)
        Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1)

        Do
            L1 = L2 : F_L1 = F_L2
            L2 = L1 + LStep * LSign
            LeftTail = non_central_chi_square_cdf(L2, Df1, lambda)
            lnPower = Math.Log(LeftTail)
            F_L2 = LogBeta - lnPower
            Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_L2: {3}", L2, LeftTail, lnPower, F_L2)
            Factor = Factor + 0.1
            LStep = x1 * (Factor)
        Loop Until F_L2 * LSign < 0

        BrentNoncentralChisquareQuantile(IsExact, IsGLM, L1, L2, F_L1, F_L2, lambda, LogBeta, Df1, 0, 0)

    End Sub



    Function NoncentralChisquare_Quantile(IsExact As Boolean, IsGLM As Boolean, x1 As Double, lambda As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double) As Double
        Dim lnPower As Double, LeftTail As Double ', Righttail As Double
        LeftTail = non_central_chi_square_cdf(x1, Df1, lambda)
        lnPower = Math.Log(LeftTail)
        Return LogBeta - lnPower
    End Function


    Sub BrentNoncentralChisquareQuantile(IsExact As Boolean, IsGLM As Boolean, ByRef a As Double, ByRef b As Double, fa As Double, fb As Double, t1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        eps = 0.00000000000001
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
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
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
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            'Function
            fb = NoncentralChisquare_Quantile(IsExact, IsGLM, b, t1, LogBeta, Df1, Df2, omega)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub




    Sub Demo_ChiSquare_Lambda()
        Dim lambda As Double, alpha As Double, Beta As Double
        Dim DF1, LeftTail  As Double ', Righttail As Double
        Dim x1 As Double

        Dim IsGLM As Boolean = True
        Dim IsExact As Boolean = False
        DF1 = 4
        alpha = 0.0002
        Beta = 0.003 ' Beta must be < 1-alpha
        Console.WriteLine()


        Dim LogBeta = Math.Log(Beta)
        Console.WriteLine()
        GetL(DF1, x1, lambda, alpha, Beta) ' this returns a value for x1 (at level alpha) and lambda

        Dim lambda_x1 = lambda
        LeftTail = non_central_chi_square_cdf(x1, DF1, lambda)
        Console.WriteLine("lambda_x1: {0}, fx1: {1}", lambda_x1, LeftTail)

        Dim lnPower = Math.Log(LeftTail)
        Dim L1 = lambda_x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = LogBeta - lnPower : Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = -1 Else LSign = 1
        Dim Factor = 0.2
        Dim LStep = lambda * (Factor)
        Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1)
        Do
            L1 = L2 : F_L1 = F_L2
            L2 = L1 + LStep * LSign
            LeftTail = non_central_chi_square_cdf(x1, DF1, L2)
            lnPower = Math.Log(LeftTail)
            F_L2 = LogBeta - lnPower
            Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L2, LeftTail, lnPower, F_L2)
            Factor = Factor + 0.2
            LStep = lambda * (Factor)
        Loop Until F_L2 * LSign > 0

        BrentChisquareLambda(IsExact, IsGLM, L1, L2, F_L1, F_L2, x1, LogBeta, DF1, 0, 0)

    End Sub



    Function Chisquare_New_Lambda(IsExact As Boolean, IsGLM As Boolean, L2 As Double, x1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double) As Double
        Dim lnPower As Double, LeftTail As Double
        LeftTail = non_central_chi_square_cdf(x1, Df1, L2)
        'FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, L2, omega, LeftTail, Righttail)
        lnPower = Math.Log(LeftTail)
        Return LogBeta - lnPower
    End Function


    Sub BrentChisquareLambda(IsExact As Boolean, IsGLM As Boolean, ByRef a As Double, ByRef b As Double, fa As Double, fb As Double, x1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        eps = 0.00000000000001
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
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
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
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            'Function
            fb = Chisquare_New_Lambda(IsExact, IsGLM, b, x1, LogBeta, Df1, Df2, omega)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub




    Function non_central_chi_square_cdf(x As Double, k As Double, l As Double) As Double
        Dim result As Double
        Dim invert As Boolean = False
        If (x > k + l) Then
            result = non_central_chi_square_q(x, k, l, -1.0)
            invert = Not (invert)
        Else
            result = non_central_chi_square_p(x, k, l, 0.0)
        End If
        If invert Then result = -result
        Return result
    End Function


    Function non_central_chi_square_cdf_complement(x As Double, k As Double, l As Double) As Double
        Dim result As Double
        Dim invert As Boolean = True
        If (x > k + l) Then
            result = non_central_chi_square_q(x, k, l, 0.0)
            invert = Not (invert)
        Else
            result = non_central_chi_square_p(x, k, l, -1.0)
        End If
        If invert Then result = -result
        Return result
    End Function



    Function non_central_chi_square_q(x As Double, f As Double, theta As Double, init_sum As Double) As Double
        If (x = 0) Then Return 1.0

        Dim lambda As Double = theta / 2
        Dim del As Double = f / 2
        Dim y As Double = x / 2
        Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        Dim errtol As Double = 0.000000000000001 'boost::math::policies::get_epsilon<T, Policy>()
        Dim sum As Double = init_sum

        'Dim k As Int32 = Convert.ToInt32(round(lambda))
        Dim k As Int32 = Convert.ToInt32(Math.Round(lambda))
        ' Forwards and backwards Poisson weights:
        'Dim poisf As Double = xpr.gamma_p_derivative((1 + k), lambda)
        Dim poisf As Double = boost2.gamma_p_derivative((1 + k), lambda)
        Dim poisb As Double = poisf * k / lambda
        ' Initial forwards central chi squared term:
        'Dim gamf As Double = xpr.gamma_q(del + k, y)
        Dim gamf As Double = boost2.gamma_q(del + k, y)
        ' Forwards and backwards recursion terms on the central chi squared:
        'Dim xtermf As Double = xpr.gamma_p_derivative(del + 1 + k, y)
        Dim xtermf As Double = boost2.gamma_p_derivative(del + 1 + k, y)
        Dim xtermb As Double = xtermf * (del + k) / y
        ' Initial backwards central chi squared term:
        Dim gamb As Double = gamf - xtermb

        ' Forwards iteration first, this is the
        ' stable direction for the gamma function
        ' recurrences:
        '
        Dim i As Int32
        For i = k To (max_iter - (i - k))
            Dim term As Double = poisf * gamf
            sum += term
            poisf *= lambda / (i + 1)
            gamf += xtermf
            xtermf *= y / (del + i + 1)
            If (((sum = 0) Or (Math.Abs(term / sum) < errtol)) And (term >= poisf * gamf)) Then Exit For
        Next
        'Error check:
        If ((i - k) >= max_iter) Then
            Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum)
            Return 0.0
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
            Dim term As Double = poisb * gamb
            sum += term
            poisb *= i / lambda
            xtermb *= (del + i) / y
            gamb -= xtermb
            If ((sum = 0) Or (Math.Abs(term / sum) < errtol)) Then Exit For
        Next

        Return sum
    End Function





    Function non_central_chi_square_p(y As Double, n As Double, lambda As Double, init_sum As Double) As Double
        If (y = 0) Then Return 0.0

        '    Dim lambda As Double = theta / 2
        Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        Dim errtol As Double = 0.000000000000001 'boost::math::policies::get_epsilon<T, Policy>()
        Dim errorf As Double = 0.0
        Dim errorb As Double = 0.0

        Dim x As Double = y / 2
        Dim del As Double = lambda / 2
        '
        ' Starting location for the iteration, we'll iterate
        ' both forwards and backwards from this point.  The
        ' location chosen is the maximum of the Poisson weight
        ' function, which ocurrs *after* the largest term in the
        ' sum.
        '

        'Dim k As Int32 = Convert.ToInt32(round(lambda))
        Dim k As Int32 = Convert.ToInt32(Math.Round(lambda))
        Dim a As Double = n / 2 + k
        ' Central chi squared term for forward iteration:
        'Dim gamkf As Double = xpr.gamma_p(a, x)
        Dim gamkf As Double = boost2.gamma_p(a, x)

        If (lambda = 0) Then Return gamkf
        ' Central chi squared term for backward iteration:
        Dim gamkb As Double = gamkf
        ' Forwards Poisson weight:
        'Dim poiskf As Double = xpr.gamma_p_derivative((k + 1), del)
        Dim poiskf As Double = boost2.gamma_p_derivative((k + 1), del)
        ' Backwards Poisson weight:
        Dim poiskb As Double = poiskf
        ' Forwards gamma function recursion term:
        'Dim xtermf As Double = xpr.gamma_p_derivative(a, x)
        Dim xtermf As Double = boost2.gamma_p_derivative(a, x)

        ' Backwards gamma function recursion term:
        Dim xtermb As Double = xtermf * x / a
        Dim sum As Double = init_sum + poiskf * gamkf
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
            If ((Math.Abs(errorb / sum) < errtol) And (errorb <= errorf)) Then Exit While
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
        Loop While ((Math.Abs(errorf / sum) > errtol) And ((i) < max_iter))

        'Error check:
        If ((i) >= max_iter) Then
            Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum)
            Return sum
        End If

        Return sum
    End Function





    Function Cdisn(n As Double, X As Double,
lambda As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Call Cdisn2(n, X, lambda, LeftTail, RightTail)
        Cdisn = LeftTail
    End Function

    Sub Cdisn2(n As Double, X As Double, lambda As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim j As Long
        Dim EL As Double, L As Double, Lj As Double, sumL As Double,
            sumR As Double, Left1 As Double, Right1 As Double,
            RelError As Double, density As Double, r2 As Double,
            Right2 As Double, lefttail1 As Double, RightTail1 As Double
        Dim NotAccurate As Boolean
        L = lambda / 2
        EL = Math.Exp(-L)
        Call cdis2(n, X, sumL, sumR, density)
        Right2 = sumR
        r2 = 2 * density * X / n
        Lj = 1
        RelError = 1
        NotAccurate = True
        j = 0

        While NotAccurate
            j = j + 1
            Lj = Lj * L / j
            Right2 = Right2 + r2
            r2 = r2 * X / (n + 2 * j)
            RightTail1 = Right2
            lefttail1 = 1 - RightTail1
            Left1 = lefttail1
            Right1 = RightTail1
            sumL = sumL + Left1 * Lj
            sumR = sumR + Right1 * Lj
            RelError = (sumL * Lj) / sumL
            NotAccurate = (RelError > 0.0000000000000001)
        End While
        LeftTail = sumL * EL
        RightTail = sumR * EL
    End Sub





    Sub CdisnCohen(n As Double, X As Double, lambda As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        'Dim n As Int32 = 9
        'Dim x = 4
        'Dim lambda = 6
        Dim x1 = Math.Sqrt(X)
        Dim d = Math.Sqrt(lambda)
        Dim e = Math.Exp(0.5 * (X + lambda))

        Dim g1 = Math.Cosh(Math.Sqrt(X * lambda)) / Math.Sqrt(2 * Math.PI * X) / e
        Dim g3 = Math.Sinh(Math.Sqrt(X * lambda)) / Math.Sqrt(2 * Math.PI * lambda) / e
        'Dim F1 = xpr.dist_pnorm(x1 - d, 0, 1, True) - xpr.dist_pnorm(-x1 - d, 0, 1, True)
        Dim F1 As Double = boost2.dist_normal(x1 - d, 0, 1, 2) - boost2.dist_normal(-x1 - d, 0, 1, 2)
        Dim F3 = F1 - 2 * g3

        'Console.WriteLine("F1: {0}", F1)
        'Console.WriteLine("i: {0}; g1: {1}; F1: {2}", 1, g1, F1)
        'Console.WriteLine("i: {0}; g3: {1}; F3: {2}", 3, g3, F3)
        For i = 5 To n Step 2
            Dim g5 = (X * g1 - (i - 4) * g3) / lambda
            Dim F5 = F3 - 2 * g5
            g1 = g3
            g3 = g5
            F3 = F5
            'Console.WriteLine("i: {0}; g5: {1}; F3: {2}", i, g5, F5)
        Next
        LeftTail = F3
        RightTail = 1 - LeftTail

    End Sub


    Sub Cdisn_Penev(n As Double, x As Double, l As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim s As Double, z As Double, m2 As Double, hs As Double, sg As Double
        m2 = l / n
        If m2 = 0 Then s = x / n Else s = (-1 + Math.Sqrt(1 + (4 * x * m2) / n)) / (2 * m2)
        'Debug.Print "s:", S
        If s = 1 Then s = 1 + 0.0000001 / n
        If s > 1 Then sg = 1 Else sg = -1
        hs = h(s)
        z = n * (s - 1) ^ 2
        z = z * (1 / (2 * s) + m2 - (1 / s) * hs)
        z = z - Math.Log(1 / s - (2 / s) * hs / (1 + 2 * m2 * s))
        z = z + (2 * (1 + 3 * m2) ^ 2) / (9 * n * (1 + 2 * m2) ^ 3)
        z = sg * Math.Sqrt(Math.Abs(z))
        LeftTail = ndis(z)
        RightTail = 1 - LeftTail
    End Sub


    Private Function h2(y As Double) As Double
        If y = 0 Then
            Return 0.0
        Else
            Return 1 / (y * y) * ((1 - y) * Math.Log(1 - y) + y - 0.5 * y * y)
        End If
    End Function


    Private Function h(s As Double) As Double
        If s <= 0 Then h = h2(1 - s) Else h = -h2(1 - 1 / s)
    End Function




    Sub NonCentralChi2_SPA(n As Double, x As Double, lambda As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        Dim k As Double, k1 As Double, k2 As Double, k3 As Double, k4 As Double
        Dim s As Double, t As Double, t2 As Double, t3 As Double, t4 As Double
        Dim u As Double, w As Double, density As Double

        s = -(1 / (4 * x)) * (n - 2 * x + Math.Sqrt(n * n + 4 * x * lambda))
        t = 1 / (1 - 2 * s)
        t2 = t * t : t3 = t2 * t : t4 = t3 * t
        k = -(n / 2) * Math.Log(1 - 2 * s) + lambda * s * t
        k1 = t * (n + lambda * t)
        k2 = 2 * t2 * (n + 2 * lambda * t)
        k3 = 8 * t3 * (n + 3 * lambda * t)
        k4 = 48 * t4 * (n + 4 * lambda * t)
        w = Math.Sign(s) * Math.Sqrt(2 * (s * k1 - k))
        u = s * Math.Sqrt(k2)
        LugannaniRice(w, u, k2, k3, k4, density, LeftTail, Righttail)
    End Sub


    Function NonCentralChi2_CGF_Derivative(t As Double, n As Double, lambda As Double, j As Integer) As Double
        Dim p1 As Double, p2 As Double
        'p1 = (2 ^ (j - 1)) * xpr.gamma(j) / ((1 - 2 * t) ^ j)
        p1 = (2 ^ (j - 1)) * boost2.gamma(j) / ((1 - 2 * t) ^ j)
        p2 = (n + (lambda * j) / (1 - 2 * t))
        Return p1 * p2
    End Function


    Sub NonCentralChi2_SPA2(n As Double, x As Double, lambda As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        Dim s, density As Double
        Console.WriteLine("n: {0}, x: {1}, lambda: {2}", n, x, lambda)
        s = -(1 / (4 * x)) * (n - 2 * x + Math.Sqrt(n * n + 4 * x * lambda))

        Dim order As Int32 = 28
        Dim kappa(order + 1) As Double
        kappa(0) = -(n / 2) * Math.Log(1 - 2 * s) + lambda * s / (1 - 2 * s)
        For j = 1 To order
            kappa(j) = NonCentralChi2_CGF_Derivative(s, n, lambda, j)
            'Console.WriteLine("j: {0}, kappa: {1}", j, kappa(j))
        Next

        'Console.WriteLine("")
        LugannaniRiceNew(order, kappa, s, density, LeftTail, Righttail)
    End Sub


    Sub Fill_d(order As Int32, ByRef d(,) As Double, theta() As Double)
        d(0, 0) = 1
        For m = 0 To order
            For n = m To order
                Dim sum = 0.0
                For k = 1 To n - m + 1
                    sum = sum + k * theta(k + 2) * d(m, n - k + 1)
                Next
                d(m + 1, n + 1) = sum / (n + 1)
            Next
        Next
    End Sub



    Function GammaHalf(mj As Int32) As Double
        'Return xpr.gamma(mj + 0.5) / Math.Sqrt(Math.PI)
        Return boost2.gamma(mj + 0.5) / Math.Sqrt(Math.PI)
    End Function


    Function Calc_A(j As Int32, A0 As Double, mu As Double, d(,) As Double, theta() As Double) As Double
        Dim sum1 = 0.0
        For n = 0 To 2 * j
            Dim sum2 = 0.0
            For m = 0 To n
                Dim delta = d(m, n)
                'Console.WriteLine("m: {0}, n: {1}, delta: {2}", m, n, delta)
                Dim summand2 = delta * (-2) ^ (m + j) * GammaHalf(m + j)
                sum2 = sum2 + summand2
            Next
            Dim factor = ((-mu) ^ (2 * j - n))
            'Console.WriteLine("factor: {0}, sum2: {1}, -mu: {2}", factor, sum2, -mu)
            sum1 = sum1 + factor * sum2
        Next
        Return A0 * sum1
    End Function

    Sub LugannaniRiceNew(order As Int32, kappa() As Double, s As Double,
                         ByRef density As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim mu, w1, w2, LeftTail0, RightTail0, u, w As Double
        Dim theta(order + 1) As Double
        Dim A(order + 1) As Double
        Dim B(order + 1) As Double
        Dim sum(order + 1) As Double
        Dim d(2 * order + 3, 2 * order + 3) As Double


        w = Math.Sign(s) * Math.Sqrt(2 * (s * kappa(1) - kappa(0)))
        u = s * Math.Sqrt(kappa(2))
        w1 = 1 / w
        w2 = -2 * w1 * w1
        mu = 1 / u

        Dim k As Double = Math.Sqrt(kappa(2))
        Dim factor As Double = 2 * kappa(2)
        For j = 3 To order
            factor = factor * j * k
            theta(j) = kappa(j) / factor
            'Console.WriteLine("j: {0}, theta: {1}", j, theta(j))
        Next
        'Console.WriteLine("")


        Call ndis2(False, w, LeftTail0, RightTail0, density)
        B(0) = density * w1
        factor = 0.5
        For j = 1 To order
            B(j) = B(j - 1) * w2 * factor
            factor = factor + 1
        Next

        Fill_d(order - 2, d, theta)
        A(0) = density * mu
        For j = 1 To order - 2
            A(j) = Calc_A(j, A(0), mu, d, theta)
        Next

        Dim totalsum As Double = 0
        Dim useorder As Int32 = order - 2
        Console.WriteLine("j: {0}, Leftj: {1}, Rightj: {2}", 0, LeftTail0 - totalsum, RightTail0 + totalsum)
        For j = 0 To useorder
            sum(j) = A(j) - B(j)
            totalsum = totalsum + sum(j)
            Console.WriteLine("j: {0}, Leftj: {1}, Rightj: {2}, Aj: {3}, Bj: {4}, sumj: {5}", j, LeftTail0 - totalsum, RightTail0 + totalsum, A(j), B(j), sum(j))
        Next

        LeftTail = LeftTail0 - totalsum
        RightTail = RightTail0 + totalsum
        Console.WriteLine("")
        Console.WriteLine("")
    End Sub




    Sub TestNonCentralChi2()
        Dim n As Double, lambda As Double, x As Double
        Dim LeftTail As Double, Righttail As Double
        x = 10
        n = 12.5
        lambda = 200

        NonCentralChi2_SPA(n, x, lambda, LeftTail, Righttail)
        Console.WriteLine("LeftTail: {0}, Righttail:{1}", LeftTail, Righttail)

        'LeftTail = xpr.dist_pchisq_nc(x, n, lambda, True, False)
        'LeftTail = boost2.dist_chisq_nc(x, n, lambda, 2)
        'Righttail = xpr.dist_pchisq_nc(x, n, lambda, False, False)
        'Righttail = boost2.dist_chisq_nc(x, n, lambda, 3)
        Console.WriteLine("LeftTail: {0}, Righttail:{1}", LeftTail, Righttail)

        Cdisn_Penev(n, x, lambda, LeftTail, Righttail)
        Console.WriteLine("LeftTail: {0}, Righttail:{1}", LeftTail, Righttail)
    End Sub



    Function MarcumQ(nu As Double, a As Double, b As Double) As Double
        'Return xpr.dist_pchisq_nc(b * b, nu * 2, a * a, False, False)
        'Return boost2.dist_chisq_nc(b * b, nu * 2, a * a, 3)
        Return 1
    End Function

    Sub DemoMarcumQ()
        Dim nu = 7.7
        Dim a = 2.2
        Dim b = 2.6
        Dim result = MarcumQ(nu, a, b)
        Console.WriteLine("MarcumQ result: {0}", result)
    End Sub



#End Region







    '**********************************************************************
    'Noncentral Beta cdf
    ''**********************************************************************


#Region "Noncentral Beta"

    Function ibeta_imp(a As Double, b As Double, x As Double, inv As Boolean, normalised As Boolean, ByRef xterm As Double) As Double
        'xterm = xpr.ibeta_derivative(a, b, x)
        xterm = boost2.ibeta_derivative(a, b, x)
        'Return xpr.ibeta(a, b, x)
        Return boost2.ibeta(a, b, x)
    End Function




    Function non_central_beta_cdf(a As Double, b As Double, lambda As Double, x As Double, y As Double) As Double
        Dim invert As Boolean = False
        Dim result As Double
        Dim c = a + b + lambda / 2
        Dim cross = 1 - (b / c) * (1 + lambda / (2 * c * c))
        If (x > cross) Then
            result = non_central_beta_q(a, b, lambda, x, y, -1.0)
            invert = Not (invert)
        Else
            result = non_central_beta_p(a, b, lambda, x, y, 0.0)
        End If
        If invert Then result = -result
        Return result
    End Function



    Function non_central_beta_cdf_complement(a As Double, b As Double, lambda As Double, x As Double, y As Double) As Double
        Dim invert As Boolean = True
        Dim result As Double
        Dim c = a + b + lambda / 2
        Dim cross = 1 - (b / c) * (1 + lambda / (2 * c * c))
        If (x > cross) Then
            result = non_central_beta_q(a, b, lambda, x, y, 0.0)
            invert = Not (invert)
        Else
            result = non_central_beta_p(a, b, lambda, x, y, -1.0)
        End If
        If invert Then result = -result
        Return result
    End Function


    Function non_central_beta_p(a As Double, b As Double, lambda As Double, x As Double, y As Double, init_val As Double) As Double
        Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        Dim errtol As Double = 0.000000000000001 'boost::math::policies::get_epsilon<T, Policy>()

        Dim l2 As Double = lambda / 2

        ' k is the starting point for iteration, And Is the
        ' maximum of the poisson weighting term,
        ' note that unlike other similar code, we do not set
        ' k to zero, when l2 Is small, as forward iteration
        ' is unstable
        Dim k As Int32 = Convert.ToInt32(Math.Round(l2))

        If (k = 0) Then k = 1

        ' Forwards and backwards Poisson weights:
        'Dim pois As Double = xpr.gamma_p_derivative((k + 1), l2)
        Dim pois As Double = boost2.gamma_p_derivative((k + 1), l2)
        If (pois = 0) Then Return init_val
        Dim xterm, beta As Double
        If x < y Then
            beta = ibeta_imp(a + k, b, x, False, True, xterm)
        Else
            beta = ibeta_imp(b, a + k, y, True, True, xterm)
        End If
        xterm *= y / (a + b + k - 1)
        Dim poisf = pois
        Dim betaf = beta
        Dim xtermf = xterm
        Dim sum = init_val
        If ((beta = 0) And (xterm = 0)) Then
            Return init_val
        End If

        ' Backwards recursion first, this is the stable
        ' direction for recursion:
        Dim last_term As Double = 0
        Dim count As Int32 = k
        For i = k To 0 Step -1
            Dim term As Double = beta * pois
            sum += term
            If (((Math.Abs(term / sum) < errtol) And (last_term >= term)) Or (term = 0)) Then
                count = k - i
                Exit For 'break
            End If
            pois *= i / l2
            beta += xterm
            xterm *= (a + i - 1) / (x * (a + b + i - 2))
            last_term = term
        Next

        ' Now forward recursion
        For i = k + 1 To max_iter
            poisf *= l2 / i
            xtermf *= (x * (a + b + i - 2)) / (a + i - 1)
            betaf -= xtermf

            Dim term = poisf * betaf
            sum += term
            If ((Math.Abs(term / sum) < errtol) Or (term = 0)) Then
                Exit For 'break
            End If

            'Error check:
            If ((i) >= max_iter) Then
                Console.WriteLine("cdf(non_central_beta_distribution) Series did not converge, closest value was {0}", sum)
                Return sum
            End If
        Next
        Return sum

    End Function



    Function non_central_beta_q(a As Double, b As Double, lambda As Double, x As Double, y As Double, init_val As Double) As Double
        Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        Dim errtol As Double = 0.000000000000001 'boost::math::policies::get_epsilon<T, Policy>()

        Dim l2 As Double = lambda / 2

        ' k is the starting point for iteration, and is the
        ' maximum of the poisson weighting term:
        Dim k As Int32 = Convert.ToInt32(Math.Round(l2))
        Dim pois As Double
        If (k <= 30) Then
            ' Might as well start at 0 since we'll likely have this number of terms anyway:
            If (a + b > 1) Then
                k = 0
            Else
                If (k = 0) Then
                    k = 1
                End If
            End If
        End If

        If (k = 0) Then
            ' Starting Poisson weight:
            pois = Math.Exp(-l2)
        Else
            ' Starting Poisson weight:
            'pois = xpr.gamma_p_derivative((k + 1), l2)
            pois = boost2.gamma_p_derivative((k + 1), l2)
        End If

        If (pois = 0) Then Return init_val
        ' recurance term:
        Dim xterm, beta As Double
        If x < y Then
            beta = ibeta_imp(a + k, b, x, True, True, xterm)
        Else
            beta = ibeta_imp(b, a + k, y, False, True, xterm)
        End If
        xterm *= y / (a + b + k - 1)
        Dim poisf = pois
        Dim betaf = beta
        Dim xtermf = xterm
        Dim sum = init_val
        If ((beta = 0) And (xterm = 0)) Then
            Return init_val
        End If

        ' Forwards recursion first, this is the stable
        ' direction for recursion, and the location
        ' of the bulk of the sum

        Dim last_term As Double = 0
        Dim count As Int32 = 0
        For i = k + 1 To max_iter
            poisf *= l2 / i
            xtermf *= (x * (a + b + i - 2)) / (a + i - 1)
            betaf += xtermf

            Dim term = poisf * betaf
            sum += term
            If ((Math.Abs(term / sum) < errtol) And (last_term >= term)) Then
                count = i - k
                Exit For 'break
            End If

            'Error check:
            If ((i - k) >= max_iter) Then
                Console.WriteLine("cdf(non_central_beta_distribution) Series did not converge, closest value was {0}", sum)
            End If
            last_term = term
        Next


        ' Now backward recursion
        For i = k To 0 Step -1
            Dim term As Double = beta * pois
            sum += term
            If (Math.Abs(term / sum) < errtol) Then
                Exit For 'break
            End If

            'Error check:
            If ((count + k - i) >= max_iter) Then
                Console.WriteLine("cdf(non_central_beta_distribution) Series did not converge, closest value was {0}", sum)
            End If

            pois *= i / l2
            beta -= xterm
            xterm *= (a + i - 1) / (x * (a + b + i - 2))
        Next

        Return sum

    End Function



    Sub BetadisnPaolella(a As Double, b As Double, xbeta As Double, ybeta As Double, nc As Double,
      ByRef density As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        FdisnPaolella(2 * a, 2 * b, (b * xbeta) / (a * ybeta), nc, 0, density, LeftTail, RightTail)
    End Sub



    Function BetadisnSeber(x As Double, a As Double, b As Long, lambda As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Dim C As Double, f As Double, b0 As Double, b1 As Double, S As Double, k As Long
        C = (x ^ a) * Math.Exp(lambda * (x - 1) / 2)
        b0 = 0 : b1 = 1 : S = 1
        For k = 2 To b
            f = (2 * k - 4 + a + lambda * x / 2) * b1 + (k - 3 + a) * (x - 1) * b0
            f = f * (1 - x) / (k - 1) : S = S + f : b0 = b1 : b1 = f
        Next k
        LeftTail = C * S
        RightTail = 1 - LeftTail
        Return LeftTail
    End Function


    Sub Betadisn(a As Double, b As Double,
X As Double, y As Double, d As Double,
      ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim n As Long, Mode As Long
        Dim density As Double, t As Double, snRight As Double
        Dim d2 As Double, sn As Double, rn As Double
        Dim FehlerLeft As Double, RelFehlerLeft As Double
        Dim ResultLeft As Double, qsum As Double
        Dim expd2 As Double, Lastvalue As Double, l1 As Double
        Dim RelFehlerRight As Double, ResultRight As Double ', l2 As Double, r2 As Double

        LeftTail = Fdis((2 * a + d) * (2 * a + d) / (2 * (a + d)), 2 * b, 2 * b / (2 * a + d) * X / (1 - X))
        If (LeftTail < 0.01) Then Mode = 1 Else Mode = 2

        'Mode = 1
        d2 = d / 2
        rn = 1
        n = 1
        expd2 = Math.Exp(-d2)
        '  t = LnGamma(a + b) - LnGamma(a + 1) - LnGamma(b)
        '  t = t + a * Log(X) + b * Log(y)
        '  t = Exp(t)
        Call betadis(a, b, X, y, LeftTail, RightTail, density)
        t = density * X * y / a
        '  Debug.Print "t: ", t, density * X * y / a
        sn = LeftTail
        Lastvalue = LeftTail
        snRight = RightTail
        qsum = 1
        If Mode = 1 Then
            Do
                rn = rn * d2 / n
                qsum = qsum + rn
                LeftTail = LeftTail - t
                If (Lastvalue / LeftTail) > 1000.0# Then
                    Call betadis(a + n, b, X, y, l1, RightTail, density)
                    Lastvalue = l1
                    LeftTail = l1
                End If
                sn = sn + rn * LeftTail
                t = t * X * (a + b + n - 1) / (a + n)
                FehlerLeft = LeftTail * (1 - expd2 * qsum)
                ResultLeft = expd2 * sn
                RelFehlerLeft = FehlerLeft / ResultLeft
                n = n + 1
            Loop Until (RelFehlerLeft < 0.0000000000000001)
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
            Loop Until RelFehlerRight < 0.0000000000000001
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



    Function non_central_f_cdf(xparam As Double, df1 As Double, df2 As Double, lambda As Double) As Double
        Dim alpha = df1 / 2
        Dim beta = df2 / 2
        Dim y = xparam * alpha / beta
        Dim x = y / (1 + y)
        Dim cx = 1 / (1 + y)
        Dim result = non_central_beta_cdf(alpha, beta, lambda, x, cx)
        Return result
    End Function


    Function non_central_f_cdf_complement(xparam As Double, df1 As Double, df2 As Double, lambda As Double) As Double
        Dim alpha = df1 / 2
        Dim beta = df2 / 2
        Dim y = xparam * alpha / beta
        Dim x = y / (1 + y)
        Dim cx = 1 / (1 + y)
        Dim result = non_central_beta_cdf_complement(alpha, beta, lambda, x, cx)
        Return result
    End Function



    Function Fdisn(m As Double, n As Double, a As Double, NC As Double) As Double
        Dim X As Double, y As Double, p As Double, Q As Double, L As Double, r As Double
        'Dim density As Double
        If a <= 0 Then
            Fdisn = 0
            Exit Function
        End If
        X = m * a / (m * a + n)
        y = n / (m * a + n)
        p = m / 2
        Q = n / 2
        Call Betadisn(p, Q, X, y, NC, L, r)
        Fdisn = r
        '  If Not (IsMissing(LeftTail)) Then LeftTail = L
        '  If Not (IsMissing(RightTail)) Then RightTail = r
    End Function



    Function Fdisn2(m As Double, n As Double, a As Double, NC As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Dim X As Double, y As Double, p As Double, Q As Double
        'Dim density As Double
        If a <= 0 Then
            Fdisn2 = 0
            Exit Function
        End If
        X = m * a / (m * a + n)
        y = n / (m * a + n)
        p = m / 2
        Q = n / 2
        Call Betadisn(p, Q, X, y, NC, LeftTail, RightTail)
        Fdisn2 = RightTail
        '  If Not (IsMissing(LeftTail)) Then LeftTail = L
        '  If Not (IsMissing(RightTail)) Then RightTail = r
    End Function




    Function FdisnSeber(x As Double, m As Double, n As Long, lambda As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        If (n Mod 2) <> 0 Then
            Return Double.NaN  'n needs to be an even integer
        Else
            Return BetadisnSeber(m * x / (m * x + n), m / 2, n \ 2, lambda, LeftTail, RightTail)
        End If
    End Function



#End Region







    '**********************************************************************
    'Singly noncentral T cdf
    ''**********************************************************************


#Region "NoncentralT"



    Function non_central_t_cdf(v As Double, delta As Double, t As Double) As Double
        Return non_central_t_cdf_main(v, delta, t, False)
    End Function


    Function non_central_t_cdf_complement(v As Double, delta As Double, t As Double) As Double
        Return non_central_t_cdf_main(v, delta, t, True)
    End Function


    Function non_central_t_cdf_main(v As Double, delta As Double, t As Double, invert As Boolean) As Double
        If (t < 0) Then
            t = -t
            delta = -delta
            invert = Not (invert)
        End If

        ' x and y are the corresponding random
        ' variables for the noncentral beta distribution,
        ' with y = 1 - x
        Dim X = t * t / (v + t * t)
        Dim y = v / (v + t * t)
        Dim d2 = delta * delta
        Dim a = 0.5
        Dim b = v / 2
        Dim c = a + b + d2 / 2
        '
        ' Crossover point for calculating p Or q Is the same
        ' as for the noncentral beta:
        '
        Dim cross = 1 - (b / c) * (1 + d2 / (2 * c * c))
        Dim result As Double

        If (X < cross) Then
            ' Calculate p
            If (X <> 0) Then
                result = non_central_beta_p(a, b, d2, X, y, 0.0)
                result = non_central_t2_p(v, delta, X, y, result)
                result /= 2
            Else
                result = 0
                'result += xpr.dist_pnorm(-delta, 0, 1)
                result += boost2.dist_normal(-delta, 0, 1, 2)
            End If
        Else
            ' Calculate q:
            invert = Not (invert)
            If (X <> 0) Then
                result = non_central_beta_q(a, b, d2, X, y, 0)
                result = non_central_t2_q(v, delta, X, y, result)
                result /= 2
            Else ' x == 0
                'result = xpr.dist_pnorm(-delta, 0, 1)
                result = boost2.dist_normal(-delta, 0, 1, 2)
            End If
        End If
        If (invert) Then result = 1 - result
        Return result
    End Function


    Function non_central_t2_p(v As Double, delta As Double, x As Double, y As Double, init_val As Double) As Double
        Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        Dim errtol As Double = 0.000000000000001 'boost::math::policies::get_epsilon<T, Policy>()

        Dim d2 As Double = delta * delta / 2

        ' k is the starting point for iteration, And Is the
        ' maximum of the poisson weighting term,
        ' note that unlike other similar code, we do not set
        ' k to zero, when l2 Is small, as forward iteration
        ' is unstable
        Dim k As Int32 = Convert.ToInt32(Math.Round(d2))
        If (k = 0) Then k = 1
        Dim pois As Double
        If (k = 0) Then k = 1
        ' Forwards and backwards Poisson weights:
        'pois = xpr.gamma_p_derivative((k + 1), d2) _
        '       * xpr.gamma_delta_ratio(k + 1, 0.5) _
        '       * delta / Math.Sqrt(2)
        pois = boost2.gamma_p_derivative((k + 1), d2) _
               * boost2.gamma_delta_ratio(k + 1, 0.5) _
               * delta / Math.Sqrt(2)

        If (pois = 0) Then Return init_val
        Dim xterm, beta As Double
        ' Recurrance & starting beta terms:
        If x < y Then
            beta = ibeta_imp(k + 1, v / 2, x, False, True, xterm)
        Else
            beta = ibeta_imp(v / 2, k + 1, y, True, True, xterm)
        End If
        xterm *= y / (v / 2 + k)
        Dim poisf = pois
        Dim betaf = beta
        Dim xtermf = xterm
        Dim sum = init_val
        If ((beta = 0) And (xterm = 0)) Then
            Return init_val
        End If

        ' Backwards recursion first, this is the stable
        ' direction for recursion:
        Dim last_term As Double = 0
        Dim count As Int32 = 0
        For i = k To 0 Step -1
            Dim term As Double = beta * pois
            sum += term
            ' Don't terminate on first term in case we "fixed" k above:
            If ((Math.Abs(last_term) >= Math.Abs(term)) And (Math.Abs(term / sum) < errtol)) Then
                Exit For 'break
            End If
            last_term = term
            pois *= (i + 0.5) / d2
            beta += xterm
            xterm *= (i) / (x * (v / 2 + i - 1))
            count = count + 1
        Next

        ' Now forward recursion
        last_term = 0
        For i = k + 1 To max_iter
            poisf *= d2 / (i + 0.5)
            xtermf *= (x * (v / 2 + i - 1)) / (i)
            betaf -= xtermf
            Dim term = poisf * betaf
            sum += term
            If ((Math.Abs(last_term) >= Math.Abs(term)) And (Math.Abs(term / sum) < errtol)) Then
                Exit For 'break
            End If
            last_term = term
            count = count + 1

            'Error check:
            If (count >= max_iter) Then
                Console.WriteLine("cdf(non_central_t_distribution) Series did not converge, closest value was {0}", sum)
                Return sum
            End If
        Next
        Return sum

    End Function


    Function non_central_t2_q(v As Double, delta As Double, x As Double, y As Double, init_val As Double) As Double
        Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        Dim errtol As Double = 0.000000000000001 'boost::math::policies::get_epsilon<T, Policy>()

        Dim d2 As Double = delta * delta / 2

        ' k Is the starting point for iteration, And Is the
        ' maximum of the poisson weighting term, we don't allow
        ' k == 0 as this can cause catastrophic cancellation errors
        ' (test case Is v = 561908036470413.25, delta = 0.056190803647041321,
        ' x = 1.6155232703966216)

        Dim k As Int32 = Convert.ToInt32(Math.Round(d2))
        If (k = 0) Then k = 1
        ' Starting Poisson weight:
        Dim pois As Double
        ' Forwards and backwards Poisson weights:
        'pois = xpr.gamma_p_derivative((k + 1), d2) _
        '       * xpr.gamma_delta_ratio(k + 1, 0.5) _
        '       * delta / Math.Sqrt(2)
        pois = boost2.gamma_p_derivative((k + 1), d2) _
               * boost2.gamma_delta_ratio(k + 1, 0.5) _
               * delta / Math.Sqrt(2)
        If (pois = 0) Then Return init_val
        Dim xterm, beta As Double
        ' Recurrance & starting beta terms:
        If x < y Then
            beta = ibeta_imp(k + 1, v / 2, x, False, True, xterm)
        Else
            beta = ibeta_imp(v / 2, k + 1, y, True, True, xterm)
        End If
        xterm *= y / (v / 2 + k)
        Dim poisf = pois
        Dim betaf = beta
        Dim xtermf = xterm
        Dim sum = init_val
        If ((beta = 0) And (xterm = 0)) Then
            Return init_val
        End If

        ' Fused forward And backwards recursion
        Dim last_term As Double = 0
        Dim count As Int32 = 0
        Dim j As Int32 = k + 1
        For i = k + 1 To max_iter
            j = j - 1
            poisf *= d2 / (i + 0.5)
            xtermf *= (x * (v / 2 + i - 1)) / (i)
            betaf += xtermf
            Dim term = poisf * betaf

            If (j >= 0) Then
                term += beta * pois
                pois *= (j + 0.5) / d2
                beta -= xterm
                xterm *= (j) / (x * (v / 2 + j - 1))
            End If

            sum += term
            ' Don't terminate on first term in case we "fixed" k above:
            If ((Math.Abs(last_term) >= Math.Abs(term)) And (Math.Abs(term / sum) < errtol)) Then
                Exit For 'break
            End If
            last_term = term
            'Error check:
            If (count >= max_iter) Then
                Console.WriteLine("cdf(non_central_t_distribution) Series did not converge, closest value was {0}", sum)
                Return sum
            End If
            count = count + 1
        Next
        Return sum

    End Function




    Function tdisn(F As Double, t As Double, d As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Const sqrtpi As Double = 1.77245385090552
        Dim S(0 To 1) As Double
        Dim a As Double, b As Double, y As Double, X As Double
        Dim z As Double, h As Double, g As Double, k As Double
        Dim r As Double, ss As Double
        Dim ak As Double, C As Double, pk0 As Double
        Dim pk1 As Double, pk2 As Double ', lnB As Double
        Dim i As Integer
        Dim fit As Boolean
        If d = 0 Then
            tdisn = tdis(F, t, LeftTail, RightTail)
            Exit Function
        End If
        fit = True
        If t > 0 Then
            fit = False
            t = -t
            d = -d
        End If
        a = t / Math.Sqrt(F)
        b = F / (F + t * t)
        y = d * Math.Sqrt(b / 2) / sqrtpi
        X = d * d * b / 2
        z = a * a * b
        h = ndis(-d * Math.Sqrt(b))
        g = Math.Exp(-Lnbeta(F / 2, 1 / 2))
        ak = 1
        C = 0.5
        For i = 0 To 1
            k = 0
            S(i) = 0
            pk2 = 1
            pk1 = 0
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
            C = 1.5
        Next i
        h = h + (g * a * Math.Sqrt(b) * S(0) - y * S(1)) * Math.Exp(-X)
        If h < 0 Then h = 0
        If h > 1 Then h = 1
        LeftTail = h
        RightTail = 1 - h
        If Not fit Then
            RightTail = h
            LeftTail = 1 - h
        End If
        Return LeftTail
    End Function




    Sub tdisnOwen_Combined(n As Long, t As Double, d As Double, ByRef PDF As Double, ByRef CDF As Double)
        Dim F0 As Double, f2 As Double, LeftTail As Double, RightTail As Double
        F0 = TdisnOwen(n, t, d, LeftTail, RightTail)
        f2 = TdisnOwen(n + 2, t * Math.Sqrt(1 + 2 / n), d, LeftTail, RightTail)
        CDF = F0
        PDF = (n / t) * (f2 - F0)
    End Sub


    Function TdisnOwen(n As Long, X As Double, d As Double, ByRef LeftTail As Double, ByRef RightTail As Double) As Double
        Const h = 0.797884560802866 '  H = 2 / Sqrt(2 * Pi)
        Dim a As Double, b As Double, b2 As Double, k As Long, i As Long, j As Long
        Dim C As Double, C0 As Double, C1 As Double, g As Double, F As Double
        a = X / Math.Sqrt(n)
        b2 = 1 / (1 + a * a) : b = Math.Sqrt(b2)
        k = n Mod 2
        'If k = 0 Then F = ndis(-d) Else F = ndis(-d * b) + 2 * xpr.owens_t(d * b, a)
        If k = 0 Then F = ndis(-d) Else F = ndis(-d * b) + 2 * boost2.owens_t(d * b, a)

        If n > 1 Then
            C0 = a * b * ndis(d * a * b) * Math.Exp(-0.5 * d * d * b2)
            C1 = a * b2 * (d * C0 + 0.5 * Math.Exp(-0.5 * d * d) * h)
            If k = 0 Then F = F + C0 Else F = F + h * C1
            g = 1 : i = 2
            While Not (i >= n - k)
                For j = 1 To 2
                    C = b2 * (1 - 1 / i) * (a * g * d * C1 + C0)
                    C0 = C1 : C1 = C : i = i + 1
                    g = 1 / (g * (i - 2))
                Next j
                If k = 0 Then F = F + C0 Else F = F + h * C1
            End While
        End If
        LeftTail = F
        RightTail = 1 - F
        Return F
    End Function


    Function tdisn_delta_approx(IsGLM As Boolean, Df2 As Double, t As Double, beta As Double) As Double
        Dim delta As Double
        If IsGLM Then
            'Algorithm by Akahira (1995)
            Dim k As Double, bn As Double, a As Double, u As Double, b As Double, c As Double
            Dim nn = Df2
            bn = Math.Sqrt(2 / nn) * Math.Exp(LnGamma((nn + 1) / 2) - LnGamma(nn / 2))
            k = 1 + (1 - bn * bn) * t * t
            a = t * t * t * (1 / (nn * nn) + 1 / (4 * nn * nn * nn)) / (24 * k)
            b = -Math.Sqrt(k)
            c = bn * t - a
            u = ndisx(beta, 1 - beta)
            delta = a * u * u + b * u + c
        Else
            'Algorithm by Winterbottom (1980)
            Dim r = t / Math.Sqrt(t * t + Df2)
            Dim rho = Rhodis_NC(beta, 1 - beta, Df2 + 2, r)
            delta = rho * Math.Sqrt(Df2 / (1 - rho * rho))
        End If
        Console.WriteLine("delta: {0}", delta)
        Return delta
    End Function


    Sub demo_tdisn_delta()
        Dim LeftTail As Double, Righttail As Double, t As Double

        Dim IsGLM As Boolean = True
        Dim IsExact As Boolean = False
        Dim Df2 = 20
        Dim omega = 0
        Dim alpha = 0.01
        Dim beta = 0.03 ' Beta must be < 1-alpha
        Dim LogBeta = Math.Log(beta)
        Console.WriteLine()

        t = Tdisx(1 - alpha, alpha, Df2)
        Console.WriteLine("t: {0}", t)
        Dim delta = tdisn_delta_approx(IsGLM, Df2, t, beta)

        Dim x1 = t
        Dim lambda_x1 = delta
        TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, lambda_x1, omega, LeftTail, Righttail)
        Dim fx1 = LeftTail
        Console.WriteLine("lambda_x1: {0}, fx1: {1}", lambda_x1, fx1)

        Dim lnPower = Math.Log(LeftTail)
        Dim L1 = lambda_x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = LogBeta - lnPower : Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = -1 Else LSign = 1
        Dim Factor = 0.2
        Dim LStep = Math.Abs(delta) * (Factor)
        Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1)
        Do
            L1 = L2 : F_L1 = F_L2
            L2 = L1 + LStep * LSign
            TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, L2, omega, LeftTail, Righttail)
            lnPower = Math.Log(LeftTail)
            F_L2 = LogBeta - lnPower
            Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L2, LeftTail, lnPower, F_L2)
            Factor = Factor + 0.2
            LStep = Math.Abs(delta) * (Factor)
        Loop Until F_L2 * LSign > 0

        DemoBrentDelta(IsExact, IsGLM, L1, L2, F_L1, F_L2, x1, LogBeta, 0, Df2, omega)

    End Sub


    Function T_New_Lambda(IsExact As Boolean, IsGLM As Boolean, L2 As Double, x1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double) As Double
        Dim lnPower As Double, LeftTail As Double, Righttail As Double
        TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, L2, omega, LeftTail, Righttail)
        'FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, L2, omega, LeftTail, Righttail)
        lnPower = Math.Log(LeftTail)
        Return LogBeta - lnPower
    End Function


    Sub DemoBrentDelta(IsExact As Boolean, IsGLM As Boolean, ByRef a As Double, ByRef b As Double, fa As Double, fb As Double, x1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        eps = 0.00000000000001
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
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
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
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            'Function
            fb = T_New_Lambda(IsExact, IsGLM, b, x1, LogBeta, Df1, Df2, omega)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub



    Function tdix_approx(IsGLM As Boolean, LeftTail As Double, RightTail As Double, n As Double, d As Double) As Double
        Dim t As Double
        Dim z = ndisx(LeftTail, RightTail)
        If (IsGLM And (d <= 0)) Then
            t = z + d
        Else
            Dim rho = d / Math.Sqrt(d * d + n)
            Console.WriteLine("rho: {0}", rho)
            Dim r = Rhodisx_W(LeftTail, RightTail, n + 2, rho)
            Console.WriteLine("r_alpha W, r: {0}, 1 - r: {1}, LeftTail: {2}, Righttail: {3}", r, 1 - r, LeftTail, RightTail)
            t = r * Math.Sqrt(n / (1 - r * r))
            Console.WriteLine("T_r: {0}", t)
        End If
        Return t
    End Function

    Sub demo_tdisnx()
        'Dim LeftTail As Double, Righttail As Double, n As Double, d As Double
        Dim RefTail As Double
        Dim IsGLM As Boolean = True
        Dim IsExact As Boolean = False
        Dim LeftTail = 0.99
        Dim Righttail = 1 - LeftTail
        Dim n = 20
        Dim d = 288
        Dim omega = 0

        If LeftTail < 0.5 Then RefTail = LeftTail Else RefTail = Righttail
        Dim LogBeta = Math.Log(LeftTail)
        Dim x1 = tdix_approx(IsGLM, LeftTail, Righttail, n, d)
        TDisnOrRhoSquareDis(IsExact, IsGLM, n, x1, d, omega, LeftTail, Righttail)
        Dim fx1 = LeftTail
        Console.WriteLine("x1: {0}, fx1: {1}", x1, fx1)


        Dim lnPower = Math.Log(LeftTail)
        Dim L1 = x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = LogBeta - lnPower : Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = +1 Else LSign = -1
        Dim Factor = 0.1
        Dim LStep = x1 * (Factor)
        Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1)

        Do
            L1 = L2 : F_L1 = F_L2
            L2 = L1 + LStep * LSign
            TDisnOrRhoSquareDis(IsExact, IsGLM, n, L2, d, omega, LeftTail, Righttail)
            lnPower = Math.Log(LeftTail)
            F_L2 = LogBeta - lnPower
            Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_L2: {3}", L2, LeftTail, lnPower, F_L2)
            Factor = Factor + 0.1
            LStep = x1 * (Factor)
        Loop Until F_L2 * LSign < 0

        Quantile_T_Brent(IsExact, IsGLM, L1, L2, F_L1, F_L2, d, LogBeta, 1.0, n, omega)

    End Sub



    Function Quantile_T_Func(IsExact As Boolean, IsGLM As Boolean, x1 As Double, t1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double) As Double
        Dim lnPower As Double, LeftTail As Double, Righttail As Double
        TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, t1, omega, LeftTail, Righttail)
        lnPower = Math.Log(LeftTail)
        Return LogBeta - lnPower
    End Function


    Sub Quantile_T_Brent(IsExact As Boolean, IsGLM As Boolean, ByRef a As Double, ByRef b As Double, fa As Double, fb As Double, t1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        'eps = 0.00000000000001
        eps = 0.0000001
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
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
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
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            'Function
            fb = Quantile_T_Func(IsExact, IsGLM, b, t1, LogBeta, Df1, Df2, omega)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub


    Function tdisn_samplesize_approx(IsGLM As Boolean, alpha As Double, Beta As Double, effect_size As Double) As Double
        Dim za As Double, zb As Double
        Dim a As Double, b As Double, c As Double, d As Double, p As Double, k As Double, x As Double
        Dim n As Double
        za = ndisx(1 - alpha, alpha)
        zb = ndisx(Beta, 1 - Beta)
        If IsGLM Then
            ' approximation derived from van Eden
            Dim r = effect_size
            a = 4 * r
            b = 4 * (zb - za) + r * r * zb
            c = r * (zb * zb + 1)
            d = (zb * zb * zb + zb) - (za * za * za + za)
            b = b / a : c = c / a : d = d / a
            d = d + b * c / 3 - 2 * b * b * b / 27
            c = c - b * b / 3
            p = (12 * c * c * c + 81 * d * d) 'revise if negative
            p = Math.Sqrt(Math.Abs(p)) 'revise if negative
            k = (108 * d + 12 * p)
            k = Math.Abs(k) ^ (1 / 3)
            x = k / 6 - 2 * c / k - b / 3
            n = Math.Round(x * x)
        Else
            Dim e2 = effect_size * effect_size
            Dim rho = Math.Sqrt(e2 / (1 + e2))
            a = 0.5 * Math.Log((1 + rho) / (1 - rho))
            b = (zb - za)
            c = rho / 2
            x = -(b / (2 * a)) + (1 / (2 * a)) * Math.Sqrt(b * b - 4 * a * c)
            n = Math.Round(2 + x * x)
        End If
        Return n
    End Function


    Sub demo_tdisn_samplesize()
        Dim alpha As Double, Beta As Double
        Dim LeftTail, RightTail, FSign, Factor As Double
        Dim IsExact = False
        Dim IsGLM = True

        alpha = 0.000000005 ' Type 1 error
        Beta = 0.00000001  'Type 2 error
        Dim effect_size = 1.57 ' effect_size = mu/sigma = rho/sqrt(1-rho^2)
        Dim omega = 0
        Dim LogBeta = Math.Log(Beta)

        Dim Df2 = tdisn_samplesize_approx(IsGLM, alpha, Beta, effect_size)
        Dim n = Df2
        Console.WriteLine("sample size: {0}", Df2)
        'Dim x1 = xpr.dist_qt(alpha, Df2, False)
        Dim x1 = boost2.dist_student_t(alpha, Df2, 6)
        Console.WriteLine("t: {0}", x1)
        TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, Math.Sqrt(Df2) * effect_size, omega, LeftTail, RightTail)

        Dim lnPower = Math.Log(LeftTail)

        Dim N1 = Df2 : Dim N2 = N1
        Dim F_n1 = LogBeta - lnPower : Dim F_n2 = F_n1
        If F_n1 > 0 Then FSign = -1 Else FSign = 1
        Factor = 0.2
        Dim FStep = Df2 * (Factor)
        If FStep < 2 Then FStep = 2
        Console.WriteLine("n1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", n, LeftTail, lnPower, F_n1)
        Do
            N1 = N2 : F_n1 = F_n2
            N2 = N1 + FStep * FSign
            'x1 = xpr.dist_qt(alpha, N2, False)
            x1 = boost2.dist_student_t(alpha, N2, 6)
            TDisnOrRhoSquareDis(IsExact, IsGLM, N2, x1, Math.Sqrt(N2) * effect_size, omega, LeftTail, RightTail)
            lnPower = Math.Log(LeftTail)
            F_n2 = LogBeta - lnPower
            Console.WriteLine("n2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", N2, LeftTail, lnPower, F_n2)
        Loop Until F_n2 * FSign > 0

        BrentSampleSizeT(IsExact, IsGLM, N1, N2, F_n1, F_n2, alpha, LogBeta, 0, effect_size, omega)

        Dim Final_N2 As Double = Math.Round(N2) + 1 * 0
        Console.WriteLine("Final_N2 size: {0}", Final_N2)
        TDisnOrRhoSquareDis(True, IsGLM, Final_N2, x1, Math.Sqrt(Final_N2) * effect_size, omega, LeftTail, RightTail)
        Console.WriteLine("LeftTail: {0}", LeftTail)
        Final_N2 = Final_N2 + 4
        Console.WriteLine("Final_N2 size: {0}", Final_N2)
        TDisnOrRhoSquareDis(True, IsGLM, Final_N2, x1, Math.Sqrt(Final_N2) * effect_size, omega, LeftTail, RightTail)
        Console.WriteLine("LeftTail: {0}", LeftTail)
    End Sub


    Function T_New_SampleSize(IsExact As Boolean, IsGLM As Boolean, N2 As Double, alpha As Double, LogBeta As Double, m As Double, r As Double, omega As Double) As Double
        Dim x1 As Double, lnPower As Double, LeftTail As Double, Righttail As Double
        'x1 = xpr.dist_qt(alpha, N2, False)
        x1 = boost2.dist_student_t(alpha, N2, 6)
        TDisnOrRhoSquareDis(IsExact, IsGLM, N2, x1, Math.Sqrt(N2) * r, omega, LeftTail, Righttail)
        lnPower = Math.Log(LeftTail)
        Return LogBeta - lnPower
    End Function


    Sub BrentSampleSizeT(IsExact As Boolean, IsGLM As Boolean, ByRef a As Double, ByRef b As Double, fa As Double, fb As Double, alpha As Double, LogBeta As Double, m1 As Double, r_ As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        eps = 0.00000000000001
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
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
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
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            'Function
            fb = T_New_SampleSize(IsExact, IsGLM, b, alpha, LogBeta, m1, r_, omega)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub



    Sub demo_tdis()
        demo_tdisn_samplesize()
        demo_tdisn_delta()
        demo_tdisnx()
    End Sub


#End Region









    '**********************************************************************
    'Doubly noncentral F cdf
    ''**********************************************************************

#Region "DoublyNoncentralF"


    Sub Fdisn_Doubly_nc(N1 As Double, n2 As Double, F As Double, Theta1 As Double, Theta2 As Double, ByRef left As Double, ByRef Right As Double)
        Dim l2 As Double, q As Double, x As Double, sum As Double, k As Long, summand As Double, RelError As Double, Result As Double
        Dim y As Double, a As Double, b As Double, l As Double, r As Double
        l2 = Theta2 / 2 : q = 1
        x = N1 * F / (n2 + N1 * F) : y = n2 / (N1 * F + n2) : a = N1 / 2 : b = n2 / 2
        Call Betadisn(a, b, x, y, Theta1, l, r)
        sum = l : k = 0
        'Console.WriteLine("sum0: {0}", sum)
        Do
            k = k + 1
            q = q * l2 / k
            Call Betadisn(a, b + k, x, y, Theta1, l, r)
            summand = q * l
            sum = sum + summand
            RelError = summand / sum
            'Console.WriteLine("k: {0}, sum: {1}, summand: {2}, RelError: {3}", k, sum, summand, RelError)
        Loop Until Math.Abs(RelError) < 0.00000000000001
        'Console.WriteLine("k: {0}, sum: {1}, summand: {2}, RelError: {3}", k, sum, summand, RelError)

        Result = Math.Exp(-l2) * sum
        left = Result : Right = 1 - left
    End Sub


    Sub FdisNCalcSaddlepoint(ByRef S As Double, N1 As Double, N2 As Double,
F As Double, t1 As Double, t2 As Double)
        Const Pi = 3.14159265358979
        Dim f2 As Double, n22 As Double, n12 As Double, a As Double, a0 As Double, A1 As Double
        Dim A2 As Double, Q As Double, p As Double

        f2 = F * F : n22 = N2 * N2 : n12 = N1 * N1

        If (t1 * t2) <> 0 Then
            a = 1 / (8 * f2 * n22 * (N1 + N2))
            a0 = (F * t2 * n12 - (1 - F) * n12 * N2 - N1 * N2 * t1) * a
            A1 = (2 * (n22 * N1 + n12 * N2 * f2) - 4 * F * N1 * N2 * (N1 + N2 + t1 + t2)) * a
            A2 = (8 * F * (1 - F) * N1 * n22 + 4 * F * (N2 * n22 + t2 * n22 - n12 * N2 * F - N1 * N2 * t1 * F)) * a / 3
            p = Math.Sqrt(Math.Abs(A1 - 3 * A2 * A2) / 3)
            Q = A2 * (2 * A2 * A2 - A1) + a0
            S = -2 * p * Math.Cos((Math.Acos(-Q / (2 * p * p * p)) + Pi) / 3) - A2
        ElseIf t1 > 0 Then
            p = f2 * N1 * n12 + 2 * f2 * n12 * t1 + 2 * n12 * F * N2 + 4 * f2 * N1 * N2 * t1 _
                + N1 * t1 * t1 * f2 + 2 * N1 * t1 * F * N2 + n22 * N1 + 4 * F * n22 * t1
            S = (F * N1 * (N1 + 2 * N2 + t1) - N1 * N2 - Math.Sqrt(N1 * p)) / (4 * N2 * F * (N1 + N2))
        Else
            S = N1 * (F - 1) / (2 * F * (N1 + N2))
        End If



    End Sub



    Sub FdisNCalcSaddlepointCum(S As Double, N1 As Double, N2 As Double,
F As Double, t1 As Double, t2 As Double,
    ByRef k As Double, ByRef k1 As Double, ByRef k2 As Double, ByRef k3 As Double, ByRef k4 As Double,
    ByRef w As Double, ByRef U As Double)

        Dim l1 As Double, l2 As Double, v1 As Double, v2 As Double, g1 As Double, g2 As Double
        Dim H1 As Double, h2 As Double, g12 As Double, g22 As Double
        l1 = N2 / N1 : l2 = -F
        v1 = 1 / (1 - 2 * S * l1) : v2 = 1 / (1 - 2 * S * l2)
        g1 = l1 * v1 : g2 = l2 * v2
        H1 = t1 * v1 : h2 = t2 * v2
        g12 = g1 * g1 : g22 = g2 * g2

        k = 0.5 * (N1 * Math.Log(v1) + N2 * Math.Log(v2)) + S * (t1 * g1 + t2 * g2)
        k1 = g1 * (N1 + H1) + g2 * (N2 + h2)
        k2 = 2 * (g12 * (N1 + 2 * H1) + g22 * (N2 + 2 * h2))
        k3 = 8 * ((g1 * g12) * (N1 + 3 * H1) + (g2 * g22) * (N2 + 3 * h2))
        k4 = 48 * ((g12 * g12) * (N1 + 4 * H1) + (g22 * g22) * (N2 + 4 * h2))

        U = S * Math.Sqrt(k2)
        w = Math.Sign(S) * Math.Sqrt(2 * (S * k1 - k))

        'Debug.Print "K1: ", k1
        'Debug.Print "s: ", S
        Dim C As Double, f2 As Double
        Dim a As Double, b As Double, Q As Double
        If t2 = 0 Then
            'Console.WriteLine("Linear")
            C = -(g1 * (N1 + H1)) / N2
            f2 = -C / (1 + 2 * S * C)
            'Console.WriteLine("F2: {0}", f2)
        Else
            'Console.WriteLine("Quadratic")
            C = -(g1 * (N1 + H1))
            a = 4 * C * S * S + 2 * S * N2
            b = -(4 * C * S + t2 + N2)
            Q = Math.Sqrt(b * b - 4 * a * C) / (2 * a)
            'Console.WriteLine("F1: {0}", -(b / (2 * a)) + Q, -(b / (2 * a)) - Q)
            f2 = a * (l2 * l2) + b * l2 + C
        End If

    End Sub



    Sub FdisnPaolella(N1 As Double, N2 As Double, F As Double, t1 As Double, t2 As Double,
      ByRef density As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim S As Double, w As Double, U As Double
        Dim k As Double, k1 As Double, k2 As Double, k3 As Double, k4 As Double

        Call FdisNCalcSaddlepoint(S, N1, N2, F, t1, t2)
        Call FdisNCalcSaddlepointCum(S, N1, N2, F, t1, t2, k, k1, k2, k3, k4, w, U)
        Call LugannaniRice(w, U, k2, k3, k4, density, LeftTail, RightTail)
        'Call Jensen(w, U)
    End Sub





    Sub DoublyFdisn_Paolella_Combined(N1 As Double, n2 As Double, F As Double, t1 As Double, t2 As Double,
        ByRef density As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        Const eps = 0.1
        Dim sx As Double
        Dim density1 As Double, lefttail1 As Double, RightTail1 As Double, Density2 As Double, LeftTail2 As Double, RightTail2 As Double
        sx = (1 + t1 / N1) / (1 + t2 / n2)
        If Math.Abs(F - sx) > eps Then
            Call FdisnPaolella(N1, n2, F, t1, t2, density, LeftTail, Righttail)
            Exit Sub
        End If
        Console.WriteLine("Double")
        Call FdisnPaolella(N1, n2, (sx - eps), t1, t2, density1, lefttail1, RightTail1)
        Call FdisnPaolella(N1, n2, (sx + eps), t1, t2, Density2, LeftTail2, RightTail2)
        density = density1 + (Density2 - density1) * (eps + F - sx) / (2 * eps)
        LeftTail = lefttail1 + (LeftTail2 - lefttail1) * (eps + F - sx) / (2 * eps)
        Righttail = RightTail1 + (RightTail2 - RightTail1) * (eps + F - sx) / (2 * eps)
    End Sub





    Sub DemoDoublyFdisn()
        Dim N1 As Double, n2 As Double, F As Double, t1 As Double, t2 As Double
        Dim eps As Double, l As Double, rt As Double ' , rt2 As Double , rt3 As Double
        Dim density As Double, LeftTail As Double, Righttail As Double
        N1 = 1
        n2 = 72
        F = 14.5
        t1 = 10
        t2 = 10
        eps = 0.0000001
        Call DoublyFdisn_Paolella_Combined(N1, n2, F, t1, t2, density, LeftTail, Righttail)
        Console.WriteLine("L3:   {0}, R: {1}:", LeftTail, Righttail)
        Call Fdisn_Doubly_nc(N1, n2, F, t1, t2, l, rt)
        Console.WriteLine("L_:   {0}, R: {1}:", l, rt)
        Console.WriteLine("Density: {0}:", density)

    End Sub




#End Region






    '**********************************************************************
    'Doubly noncentral t cdf
    ''**********************************************************************

#Region "DoublyNoncentralT"


    Sub TDistDoublyNC_Broda_Combined(n As Double, y1 As Double, mu As Double, theta As Double, ByRef PDF As Double, ByRef CDF As Double)
        Dim y13 As Double, y14 As Double, N2 As Double, nu As Double, alpha As Double, t2 As Double
        Dim Q As Double, r As Double, a As Double, C1 As Double, c2 As Double, C0 As Double
        Dim y12 As Double, y2 As Double, t1 As Double, d As Double, U As Double, w As Double
        y12 = y1 * y1
        'Console.WriteLine("y1: {0}", y1)
        If theta <> 0 Then
            y13 = y12 * y1 : y14 = y12 * y12
            N2 = n * n
            a = y14 + 2 * n * y12 + N2
            c2 = (-2 * y13 * mu - 2 * y1 * n * mu) / a
            C1 = (y12 * mu * mu - n * y12 - N2 - theta * n) / a
            C0 = (y1 * n * mu) / a
            Q = C1 / 3 - c2 * c2 / 9
            r = (C1 * c2 - 3 * C0) / 6 - c2 * c2 * c2 / 27
            y2 = Math.Sqrt(-4 * Q) * Math.Cos((1 / 3) * Math.Acos(r / Math.Sqrt(-Q * Q * Q))) - c2 / 3
            t1 = -mu + y1 * y2
            t2 = -y1 * t1 / (2 * n * y2)
            nu = 1 / (1 - 2 * t2)
            alpha = mu / Math.Sqrt(1 + theta / n)
            d = 1 / (t1 * y2)
            U = Math.Sqrt((y12 + 2 * n * t2) * (2 * n * nu * nu + 4 * theta * nu * nu * nu) + 4 * N2 * y2 * y2) / (2 * n * y2 * y2)
            w = Math.Sqrt((-mu * t1 - n * Math.Log(nu) - 2 * theta * nu * t2)) * Math.Sign(y1 - alpha)
        Else
            If (mu <> 0) Then
                y2 = (mu * y1 + Math.Sqrt(4 * n * (y12 + n) + mu * mu * y12)) / (2 * (y12 + n))
                t1 = -mu + y1 * y2
                t2 = -y1 * t1 / (2 * n * y2)
                d = 1 / (t1 * y2)
                U = Math.Sqrt((mu * y1 * y2 + 2 * n) / (2 * n)) / y2
                w = Math.Sqrt(-mu * t1 - 2 * n * Math.Log(y2)) * Math.Sign(y1 - mu)
            Else
                y2 = Math.Sqrt(n / (y12 + n))
                d = 1 / (y1 * y2 * y2)
                U = 1 / y2
                w = Math.Sqrt(-2 * n * Math.Log(y2)) * Math.Sign(y1)
            End If
        End If
        CDF = ndis(w) + ndens(w) * (1 / w - d / U)
        PDF = ndens(w) * (1 / U)
    End Sub


    Sub TDisN_Broda_Combined(n As Double, t As Double, mu As Double, theta As Double, ByRef PDF As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Const eps = 0.001
        Dim sx, CDF As Double
        Dim PDF1 As Double, cdf1 As Double, PDF2 As Double, cdf2 As Double
        sx = mu / Math.Sqrt(1 + theta / n)
        If Math.Abs(t - sx) > eps Then
            Call TDistDoublyNC_Broda_Combined(n, t, mu, theta, PDF, CDF)
        Else
            Call TDistDoublyNC_Broda_Combined(n, sx - eps, mu, theta, PDF1, cdf1)
            Call TDistDoublyNC_Broda_Combined(n, sx + eps, mu, theta, PDF2, cdf2)
            PDF = PDF1 + (PDF2 - PDF1) * (eps + t - sx) / (2 * eps)
            CDF = cdf1 + (cdf2 - cdf1) * (eps + t - sx) / (2 * eps)
        End If
        LeftTail = CDF
        RightTail = 1 - CDF
    End Sub



    Sub Tdis_Doubly_nc(n As Double, t As Double, mu As Double, theta As Double, ByRef left As Double, ByRef Right As Double)
        Dim t2 As Double, F As Double, sum As Double, summand As Double, RelError As Double, Result As Double, l As Double, r As Double, i As Long, s As Double
        Dim LeftTail As Double, RightTail As Double
        t2 = theta / 2
        F = 1 : i = 0
        sum = tdisn(n, t, mu, LeftTail, RightTail)
        'Console.WriteLine("sum0: {0}", sum)
        Do
            i = i + 1
            F = F * t2 / i
            s = Math.Sqrt((n + 2 * i) / n)
            summand = F * tdisn(n + 2 * i, s * t, mu, l, r)
            sum = sum + summand
            RelError = summand / sum
            'Console.WriteLine("i: {0}, summand: {1}, RelError: {2}", i, summand, RelError)
        Loop Until Math.Abs(RelError) < 0.000001
        Console.WriteLine("i: {0}, RelError: {1}", i, RelError)
        Result = (Math.Exp(-t2)) * sum
        left = Result : Right = 1 - left
    End Sub





#End Region







    '**********************************************************************
    'Pearson's rho cdf
    ''**********************************************************************

#Region "PearsonRho"


    Function RhoDensity(n As Long, r As Double, rho As Double) As Double
        Dim w As Double, t As Double
        Dim X As Double, x2 As Double, r2 As Double, Rho2 As Double, U As Double, k1 As Double
        Dim A2 As Double, a As Double, c2 As Double, C As Double, b2 As Double, b As Double
        Dim ACTerm As Double, density As Double

        Const Pi = 3.14159265358979
        r2 = r * r : Rho2 = rho * rho
        X = r * rho : x2 = X * X : w = 0.5 * (1 + X)
        A2 = 1 - Rho2 : a = Math.Sqrt(A2)
        c2 = 1 - r2 : C = Math.Sqrt(c2)
        b2 = 1 - x2 : b = Math.Sqrt(b2)
        U = Math.Acos(-X) / b

        t = t1(n, w)
        k1 = ((n - 2) / Math.Sqrt(2 * Pi)) * Math.Exp(LnGamma(n - 1) - LnGamma(n - 0.5))
        ACTerm = Math.Exp(Math.Log(a) * (n - 1) + Math.Log(C) * (n - 4) + Math.Log(1 - X) * (1.5 - n))
        density = k1 * ACTerm * t
        RhoDensity = density

    End Function


    'Hypergeometric function for density of pearson's rho
    Function t1(n As Double, w As Double) As Double
        Dim i As Integer, A1 As Double, C1 As Double, m1 As Double, sum As Double, RelErr As Double
        A1 = 0.5
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
        Loop Until RelErr < 0.0000000000000001
        Return sum
    End Function


    'Algorithm using finite series, Hotelling, 1953
    Function RhoExplicit(n As Integer, r As Double, rho As Double) As Double
        Dim F() As Double, d() As Double
        Dim sum1 As Double, sum2 As Double, sum3 As Double, sum31 As Double, sum32 As Double
        Dim X As Double, x2 As Double, r2 As Double, Rho2 As Double, U As Double
        Dim A2 As Double, a As Double, c2 As Double, C As Double, b2 As Double, b As Double
        Dim d1 As Double, f6 As Double, f6u As Double, result As Double
        Dim k As Integer, k1 As Integer, k4 As Integer
        Const Pi = 3.14159265358979
        r2 = r * r : Rho2 = rho * rho
        X = r * rho : x2 = X * X
        A2 = 1 - Rho2 : a = Math.Sqrt(A2)
        c2 = 1 - r2 : C = Math.Sqrt(c2)
        b2 = 1 - x2 : b = Math.Sqrt(b2)
        U = Math.Acos(-X) / b
        ReDim F(n)
        ReDim d(n)

        If (n Mod 2) <> 0 Then
            k1 = 2
            d1 = Math.Acos(-r) / Pi
            result = d1 - (rho * C * U) / Pi
            If (n = 3) Then RhoExplicit = result : Exit Function Else : F(1 + k1) = result
            result = d1 + ((x2 + 2 - 3 * Rho2) * r * C * A2 + (Rho2 - 3 + 2 * Rho2 * x2) * rho * c2 * C * U) / (2 * Pi * b2 * b2)
            If (n = 5) Then RhoExplicit = result : Exit Function Else : F(3 + k1) = result
        Else
            k1 = 3
            d1 = Math.Acos(rho) / Pi
            result = d1 + (-rho * a * c2 + r * A2 * a * U) / (Pi * b2)
            If (n = 4) Then RhoExplicit = result : Exit Function Else : F(1 + k1) = result
            f6 = (X * r * (2 * x2 + 13) - 2 * rho * (4 * x2 * x2 + 6 * x2 + 5) + Rho2 * rho * (11 * x2 + 4)) * a * c2
            f6u = ((-r2 + 3) + 2 * x2 * (-2 * r2 + 1)) * r * A2 * A2 * a * U
            result = d1 + (f6 + 3 * f6u) / (6 * Pi * b2 * b2 * b2)
            If (n = 6) Then RhoExplicit = result : Exit Function Else : F(3 + k1) = result
        End If

        d(3) = A2 * (1 + X * U) / (Pi * b2 * C)
        d(4) = A2 * a * (b2 * U + 3 * X * (1 + X * U)) / (b2 * b2 * Pi)

        ' This is calculating the density
        For k = 5 To n
            d(k) = (a * C * X * d(k - 1) * (2 * k - 5) / (k - 3) + A2 * c2 * d(k - 2) * (k - 3) / (k - 4)) / b2
        Next k

        ' This is calculating the CDF
        For k = k1 + 5 To n Step 2
            k4 = k - 4
            sum1 = (2 * k4 * Rho2 - k + 5) * F(k - 2)
            sum2 = (k - 5) * A2 * F(k4)
            sum31 = rho * (k4 * a * C - (2 * k - 9) * b2 / (a * C)) * d(k - 1) / k4
            k4 = k4 * k4
            sum32 = r * (k4 + (3 * k * (k - 8) + 47) * Rho2) * d(k - 2) / k4
            sum3 = (sum31 + sum32)
            F(k) = (sum1 + sum2 + sum3) / ((k - 3) * Rho2)
            '  Debug.Print k, F(k + 5), sum1, sum2, sum31, sum32, (sum31 + sum32) / sum31
        Next k


        RhoExplicit = F(n)
    End Function


    ' Algorithm using infinite series, Guenther 1971
    Sub RhoDisN_Guenther(n As Double, r As Double, rho As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Const Pi = 3.14159265358979
        Dim sign As Double, r2 As Double, Rho2 As Double, Left1 As Double, Right1 As Double
        Dim RelError As Double, summand As Double, sum0 As Double, sum1 As Double,
            sum2 As Double, k1 As Double, k2 As Double, density As Double
        Dim j As Long
        Dim sum4 As Double, sum3 As Double, RelError3 As Double
        Rho2 = rho * rho
        r2 = r * r
        If rho < 0 Then sign = -1 Else If rho > 0 Then sign = 1 Else sign = 0
        Call betadis(1 / 2, (n - 1) / 2, Rho2, 1 - Rho2, Left1, Right1, density)
        sum0 = 0.5 * (1 + sign * Left1)
        If r = 0 Then
            RightTail = sum0
            LeftTail = 1 - RightTail
            Exit Sub
        End If
        k1 = 0.5 * Math.Exp(Math.Log(1 - Rho2) * (n - 1) / 2)
        Call betadis(1 / 2, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
        sum1 = k1 * Left1
        sum3 = k1 * Right1
        j = 0 : RelError = 1 : RelError3 = 1
        While RelError > 0.00000000000001
            j = j + 1
            k1 = ((2 * j + n - 3) / (2 * j)) * Rho2 * k1
            Call betadis((2 * j + 1) / 2, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
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
            sum2 = 0 : sum4 = 0
        Else
            k2 = rho / Math.Sqrt(Pi) * Math.Exp(LnGamma(n / 2) - LnGamma((n - 1) / 2) + Math.Log(1 - Rho2) * (n - 1) / 2)
            Call betadis(1, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
            sum2 = k2 * Left1
            sum4 = k2 * Right1
            j = 0 : RelError = 1 : RelError3 = 1
            While RelError > 0.00000000000001
                j = j + 1
                k2 = ((2 * j + n - 2) / (2 * j + 1)) * Rho2 * k2
                Call betadis(j + 1, (n - 2) / 2, r2, 1 - r2, Left1, Right1, density)
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



    'Algorithm using infinite series, Hotelling, 1953
    Sub RhoDisN_Hotelling(n As Double, r As Double, rho As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim a As Double ', LeftTail2 As Double
        Dim gf As Double, A1 As Double, sum3 As Double, summand As Double, RelError2 As Double
        Dim m As Integer, k As Integer, smax As Integer, j As Integer, S As Integer
        Dim RelError As Double, Q As Double, BK As Double, sign As Double, t2 As Double
        Dim X As Double, y As Double, sum As Double, sum2 As Double, Factor As Double, TWO As Double
        Dim fs(0 To 1) As Double, Betas(0 To 1) As Double, Dens(0 To 1) As Double
        Dim IBeta() As Double, nk() As Double
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
        Q = (n - 1) * 0.398942280401433
        Q = Q * Math.Exp(LnGamma(n) - LnGamma(n + 0.5))
        X = ((r - rho) / (1 - rho * r))
        X = X * X
        y = 1 - X
        Factor = 1
        A1 = 1 - rho * rho
        a = 1
        TWO = 1
        RelError = 1
        m = 0
        sum3 = 0
        sum = 0
        While Math.Abs(RelError) > 0.0000000001
            S = 0
            gf = 1
            RelError2 = 1
            While (Math.Abs(RelError2) > 0.0000000001)
                If S > smax Then
                    smax = S
                    If smax > slimit Then
                        slimit = 2 * slimit
                        ReDim Preserve IBeta(slimit)
                    End If
                    If (S Mod 2 <> 0) Then j = 1 Else j = 0
                    If S <= 1 Then
                        Call betadis((S + 1) / 2, (n - 1) / 2, X, y, LeftTail, Betas(j), Dens(j))
                        fs(j) = Math.Exp(Lnbeta((S + 1) / 2, (n - 1) / 2))
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
                sign = -1
                BK = 1
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



    Sub TDisnOrRhoSquareDis(IsExact As Boolean, IsGLM As Boolean, df2 As Double,
t As Double, delta As Double, omega As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        If IsGLM Then
            If IsExact Then
                If omega = 0 Then
                    TdisnOwen(Convert.ToInt32(df2), t, delta, LeftTail, RightTail)
                Else
                    ' This should be replaced by T_Doubly_Noncentral_Exact later
                    Dim PDF As Double
                    TDisN_Broda_Combined(df2, t, delta, 0.0, PDF, LeftTail, RightTail)
                End If
            Else
                Dim PDF As Double
                TDisN_Broda_Combined(df2, t, delta, omega, PDF, LeftTail, RightTail)
            End If
        Else
            Dim r = t / Math.Sqrt(t * t + df2)
            Dim rho = delta / Math.Sqrt(delta * delta + df2)
            RhoDisNew(IsExact, IsGLM, df2 + 2, r, rho, LeftTail, RightTail)
        End If
    End Sub


    Sub RhoDisNew(IsExact As Boolean, IsGLM As Boolean, N As Double, r As Double, rho As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        If IsGLM Then
            Dim delta As Double, t As Double ', result As Double
            t = r * Math.Sqrt((N - 2) / (1 - r * r))
            delta = rho * Math.Sqrt((N - 2) / (1 - rho * rho))
            If IsExact Then
                TdisnOwen(Convert.ToInt32(N) - 2, t, delta, LeftTail, RightTail)
            Else
                Dim PDF As Double
                TDisN_Broda_Combined(N - 2, t, delta, 0.0, PDF, LeftTail, RightTail)
            End If
        Else
            Dim result As Double
            If IsExact Then
                'result = RhoExplicit(N, r, rho)
                'LeftTail = result
                'RightTail = 1 - LeftTail
                RhoDisN_Guenther(N, r, rho, LeftTail, RightTail)
            Else
                result = Rhodis_DH(N, r, rho)
                LeftTail = result
                RightTail = 1 - LeftTail
            End If
        End If
    End Sub



    'Algorithm using non-central t, N is total sample size
    Sub RhoDisN_Fixed(N As Integer, r As Double, rho As Double, LeftTail As Double, RightTail As Double)
        Dim delta As Double, t As Double, result As Double
        t = r * Math.Sqrt((N - 2) / (1 - r * r))
        delta = rho * Math.Sqrt((N - 2) / (1 - rho * rho))
        result = TdisnOwen(N - 2, t, delta, LeftTail, RightTail)

    End Sub




    Function zTransformInverse(y As Double) As Double
        y = Math.Exp(2 * y)
        zTransformInverse = (y - 1) / (y + 1)
    End Function

    Function zTransform(r As Double) As Double
        zTransform = 0.5 * Math.Log((1 + r) / (1 - r))
    End Function

    'These approximations are sensitive to whether rho and or r are negative. Still need to figure out the details!!!

    'Algorithm for CDF, Winterbottom 1980
    Function RhoDis_W(n As Double, r As Double, rho As Double) As Double
        Dim y As Double, m As Double, w As Double, r2 As Double, r3 As Double, r4 As Double, m2 As Double
        Dim w2 As Double, w3 As Double, w5 As Double
        r2 = r * r : r3 = r2 * r
        r4 = r2 * r2
        m = n - 1
        m2 = m * m
        w = (zTransform(r) - zTransform(rho))
        w2 = w * w : w3 = w2 * w : w5 = w2 * w3
        y = -r / (2 * m) - (3 * r + r3) / (12 * m2)
        y = y + (1 - (1 + r2) / (4 * m) + (3 - 11 * r4) / (96 * m2)) * w
        y = y + ((3 * r - 4 * r3) / (24 * m)) * w2
        y = y - ((1 / 12) - (2 + 7 * r2 - 6 * r4) / (48 * m)) * w3
        y = y + (3 / 160) * w5
        Dim x = Math.Sqrt(m) * y
        Dim result = ndis(x)
        Return result
    End Function

    'Algorithm for CDF, DH version, derived from Winterbottom 1980
    Function Rhodis_DH(N As Double, r As Double, rho As Double) As Double
        Dim m2 As Double, m1 As Double, m3 As Double, m4 As Double, m5 As Double
        Dim r2 As Double, r3 As Double, r4 As Double, F As Double
        Dim a As Double, b As Double, C As Double, d As Double
        Dim X As Double, p As Double, k As Double
        m2 = 1 / (N - 1) : m1 = Math.Sqrt(m2) : m3 = m2 * m1 : m4 = m2 * m2 : m5 = m2 * m3
        r2 = r * r : r3 = r2 * r : r4 = r3 * r : F = 1.2

        a = m3 / 12 + (6 * r4 - 3 * r2 + 2 * F) * m5 / 48
        b = -r3 * m4 / 6
        C = m1 + (1 + r2) * m3 / 4 + (11 * r4 + 2 * r2 + 1) * m5 / 32
        d = r * m2 / 2 + (5 * r3 + 9 * r) * m4 / 24
        d = 0.5 * Math.Log((1 + rho) / (1 - rho)) - 0.5 * Math.Log((1 + r) / (1 - r)) + d

        b = b / a : C = C / a : d = d / a
        d = d + b * C / 3 - 2 * b * b * b / 27
        C = C - b * b / 3
        p = Math.Sqrt(Math.Abs((12 * C * C * C + 81 * d * d))) 'revise if negative
        k = (108 * d + 12 * p) ^ (1 / 3)
        X = k / 6 - 2 * C / k - b / 3
        Return ndis(-X)
    End Function




    'Algorithm for ICDF, Winterbottom 1980
    Function Rhodisx_W(LeftTail As Double, RightTail As Double, n As Double, rho As Double) As Double
        Dim y As Double, X As Double, m As Double, m2 As Double, m12 As Double, m32 As Double, m52 As Double
        Dim Rho2 As Double, rho3 As Double, rho4 As Double, z As Double, x2 As Double, x3 As Double, x4 As Double, x5 As Double
        X = ndisx(LeftTail, RightTail)
        z = zTransform(rho)
        m = n - 1
        m2 = m * m : m12 = Math.Sqrt(m) : m32 = m * m12 : m52 = m2 * m12
        x2 = X * X : x3 = x2 * X : x4 = x3 * X : x5 = x4 * X
        Rho2 = rho * rho : rho3 = Rho2 * rho : rho4 = rho3 * rho
        y = z + X / m12 + rho / (2 * m)
        y = y + (x3 + 3 * (3 - Rho2) * X) / (12 * m32)
        y = y + (4 * rho3 * x2 - rho3 + 15 * rho) / (24 * m2)
        y = y + (x5 + (-60 * rho4 + 30 * Rho2 + 80) * x3 + (45 * rho4 - 21 * Rho2 + 375) * X) / (480 * m52)
        Dim rdisx = zTransformInverse(y)
        Console.WriteLine("rdisx: {0}", rdisx)
        Return rdisx
    End Function


    'Algorithm for rho (noncentrality), Winterbottom 1980
    Function Rhodis_NC(LeftTail As Double, RightTail As Double, N As Double, r As Double) As Double
        Dim y As Double, X As Double, m As Double, m2 As Double, m12 As Double, m32 As Double, m52 As Double
        Dim r2 As Double, r3 As Double, r4 As Double, z As Double, x2 As Double, x3 As Double, x4 As Double, x5 As Double
        X = -ndisx(LeftTail, RightTail)
        z = zTransform(r)
        m = N - 1
        m2 = m * m : m12 = Math.Sqrt(m) : m32 = m * m12 : m52 = m2 * m12
        x2 = X * X : x3 = x2 * X : x4 = x3 * X : x5 = x4 * X
        r2 = r * r : r3 = r2 * r : r4 = r3 * r
        y = z + X / m12 - r / (2 * m)
        y = y + (x3 + 3 * (1 + r2) * X) / (12 * m32)
        y = y - (4 * r3 * x2 + 5 * r3 + 9 * r) / (24 * m2)
        y = y + (x5 + (60 * r4 - 30 * r2 + 20) * x3 + (165 * r4 + 30 * r2 + 15) * X) / (480 * m52)
        Dim rdis_nc = zTransformInverse(y)
        Return rdis_nc
    End Function


    Sub DemoRhoExplicit()
        Dim n As Integer, r As Double, rho As Double, result As Double
        Dim LeftTail, RightTail As Double, density As Double
        ' Smallest N: N = 3
        n = 16
        r = 0.9
        rho = 0.6
        LeftTail = 0.95
        RightTail = 1 - LeftTail

        Dim rho1 = Rhodis_NC(LeftTail, RightTail, n, r)
        Console.WriteLine("rho: {0}", rho1)
        result = RhoExplicit(n, r, rho1)
        Console.WriteLine("result: {0}, result / LeftTail: {1}", result, result / LeftTail)
        density = RhoDensity(n, r, rho1)
        Console.WriteLine("density: {0}", density)

        Console.WriteLine("")
        Dim r1 = Rhodisx_W(LeftTail, RightTail, n, rho)
        Console.WriteLine("r: {0}", r1)
        result = RhoExplicit(n, r1, rho)
        Console.WriteLine("result: {0}, result / LeftTail: {1}", result, result / LeftTail)
        density = RhoDensity(n, r1, rho)
        Console.WriteLine("density: {0}", density)
    End Sub


#End Region








    '**********************************************************************
    'Rho2 cdf
    ''**********************************************************************


#Region "Rho2"

    Function Rho2DisN8(IsGLM As Boolean, p As Double, n As Double,
X As Double, Rho2 As Double) As Double
        Dim LeftTail As Double, RightTail As Double
        ' p: df1=# of variables-1
        ' N: df2=# of observatons - # of variables
        Call R2DisN(IsGLM, p, n, X, Rho2, LeftTail, RightTail)
        Rho2DisN8 = LeftTail
    End Function


    Sub R2DisN(IsGLM As Boolean, p As Double, n As Double,
X As Double, Rho2 As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        ' p: df1=# of variables-1
        ' N: df2=# of observatons - # of variables
        p = p + 1
        If IsGLM Then
            Call RHO2_EXACT_I(True, X, p, n + p, Rho2, 0, LeftTail, RightTail)
        Else
            Call RHO2_EXACT(False, X, p, n + p, Rho2, LeftTail, RightTail)
        End If
    End Sub


    Sub FDisnByRhoSquareDis(IsExact As Boolean, IsGLM As Boolean, df1 As Double, df2 As Double,
F As Double, Lambda As Double, omega As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        If IsGLM Then
            If IsExact Then
                If omega = 0 Then
                    'LeftTail = xpr.dist_pf_nc(F, df1, df2, Lambda, True, False)
                    'LeftTail = boost2.dist_fisher_f_nc(F, df1, df2, Lambda, 6)
                    'RightTail = xpr.dist_pf_nc(F, df1, df2, Lambda, False, False)
                    'RightTail = boost2.dist_fisher_f_nc(F, df1, df2, Lambda, 7)
                Else
                    ' This should be replaced by F_Doubly_Noncentral_Exact later
                    Dim density As Double
                    DoublyFdisn_Paolella_Combined(df1, df2, F, Lambda, omega, density, LeftTail, RightTail)
                End If
            Else
                Dim density As Double
                DoublyFdisn_Paolella_Combined(df1, df2, F, Lambda, omega, density, LeftTail, RightTail)
            End If
        Else
            Dim R2 = df1 * F / (df1 * F + df2)
            Dim Rho2 = Lambda / (Lambda + df2)
            Dim p As Integer = CInt(df1 + 1)
            RhoSquareDis(IsExact, IsGLM, p, df2 + df1 + 1, R2, Rho2, omega, LeftTail, RightTail)
        End If
    End Sub



    Sub RhoSquareDis(IsExact As Boolean, IsGLM As Boolean, p As Integer, N As Double,
R2 As Double, Rho2 As Double, omega As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        ' p: # of variables
        ' N: # of observatons
        If IsGLM Then
            RHO2_EXACT_I(IsExact, R2, p, N, Rho2, omega, LeftTail, RightTail)
        Else
            If IsExact Then
                RHO2_EXACT(False, R2, p, N, Rho2, LeftTail, RightTail)
            Else
                RhoSquareDis_Lee(p, N, R2, Rho2, LeftTail, RightTail)
            End If
        End If
    End Sub



    Sub RHO2_EXACT(IsOdd As Boolean, X As Double, p As Double,
ng As Double, Rho2 As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim p1 As Double, y As Double, summand As Double, RelErr As Double,
            k As Double, a As Double, n As Double
        Dim density As Double, BK As Double, t1 As Double, theta As Double,
            b As Double, cj As Double, lefttail1 As Double,
            RightTail1 As Double, sum As Double, binom As Double
        Dim j As Long

        'Console.WriteLine("p: {0}, N: {1}, R2: {2}, Rho2: {3}", p, ng, X, Rho2)


        a = 1.0# / (1 - Rho2)
        n = ng - 1
        k = (ng - p) / 2
        If IsOdd Then
            theta = -Rho2
            b = 1
            BK = -n / 2
        Else
            theta = Rho2 / (1 - Rho2)
            b = a
            BK = k
        End If
        '{  cj=1}
        p1 = (p - 1) / 2
        binom = 1
        t1 = 1
        y = 2 * k * X / (b * (1 - X))
        y = y / (y + 2 * k)
        Call betadis(p1, k, y, 1 - y, lefttail1, RightTail1, density)
        sum = lefttail1
        j = 1
        Do
            binom = binom * (BK - j + 1) / j
            t1 = t1 * theta
            cj = binom * t1
            Call betadis(p1 + j, k, y, 1 - y, lefttail1, RightTail1, density)
            summand = cj * lefttail1
            sum = sum + summand
            RelErr = summand / sum
            j = j + 1
        Loop Until RelErr < 0.000000000001
        If Not (IsOdd) Then sum = sum * Math.Exp(Math.Log(b) * (p - 1) / 2)
        sum = sum / Math.Exp(Math.Log(a) * n / 2)
        LeftTail = sum
        RightTail = 1 - sum
    End Sub





    Sub RHO2_EXACT_I(IsExact As Boolean, R2 As Double, p As Double, N As Double, Rho2 As Double, omega As Double,
    ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim X As Double, lambda As Double, DF1 As Double, DF2 As Double ', l1 As Double, r1 As Double
        DF1 = p - 1
        DF2 = N - p
        lambda = DF2 * Rho2 / (1 - Rho2)
        X = (DF2 / DF1) * R2 / (1 - R2)

        If IsExact Then
            If omega = 0 Then
                'LeftTail = xpr.dist_pf_nc(X, DF1, DF2, lambda, True, False)
                'LeftTail = boost2.dist_fisher_f_nc(X, DF1, DF2, lambda, 2)
                'RightTail = xpr.dist_pf_nc(X, DF1, DF2, lambda, False, False)
                'RightTail = boost2.dist_fisher_f_nc(X, DF1, DF2, lambda, 3)
            Else
                Dim density As Double
                DoublyFdisn_Paolella_Combined(DF1, DF2, X, lambda, omega, density, LeftTail, RightTail)
            End If
        Else
            Dim density As Double
            DoublyFdisn_Paolella_Combined(DF1, DF2, X, lambda, omega, density, LeftTail, RightTail)
        End If


        'LeftTail = non_central_f_cdf(X, DF1, DF2, lambda)
        'RightTail = non_central_f_cdf_complement(X, DF1, DF2, lambda)

    End Sub




    Sub RhoSquareDis_Lee(p As Double, N As Double, r2 As Double, Rho2 As Double, ByRef LeftTail As Double, ByRef RightTail As Double)
        Dim A1 As Double, A2 As Double, A3 As Double, x1 As Double
        Dim gamma2 As Double, m As Double, G As Double, lambda As Double, nu As Double, density As Double
        '3 moment approximation by noncentral F (Lee, 1970)
        Dim f1 = p - 1
        Dim f2 = N - p
        gamma2 = 1 / (1 - Rho2)
        m = f2 + f1
        A1 = m * (gamma2 - 1) + f1
        A2 = m * (gamma2 * gamma2 - 1) + f1
        A3 = m * (gamma2 * gamma2 * gamma2 - 1) + f1
        G = (A2 - Math.Sqrt(A2 * A2 - A1 * A3)) / A1
        lambda = Rho2 * gamma2 * Math.Sqrt(gamma2 * m * f2) / (G * G)
        nu = A2 / (G * G) - 2 * lambda
        x1 = (r2 / (1 - r2)) * (f2 / (nu * G))
        Call DoublyFdisn_Paolella_Combined(nu, f2, x1, lambda, 0, density, LeftTail, RightTail)
    End Sub




    Function QuantileR2_Approx(IsGLM As Boolean, LeftTail As Double, Righttail As Double, f1 As Double, f2 As Double, l1 As Double, l2 As Double) As Double
        Dim x1 As Double, m1 As Double, m2 As Double, A1 As Double, b1 As Double, A2 As Double, b2 As Double
        Dim g2 As Double, Rho2 As Double, n As Double
        '2 moment approximation
        If IsGLM Then
            A1 = f1 + l1
            b1 = A1 + l1
            m1 = A1 * A1 / b1
            A2 = f2 + l2
            b2 = A2 + l2
            m2 = A2 * A2 / b2
        Else
            Rho2 = l1 / (l1 + f2) : g2 = 1 / (1 - Rho2) : n = f2 + f1
            A1 = n * (g2 - 1) + f1
            A2 = n * (g2 * g2 - 1) + f1
            m1 = A1 * A1 / A2
            m2 = f2
        End If
        x1 = fdisx(LeftTail, Righttail, m1, m2)
        If IsGLM Then Return x1 * A1 * f2 / (f1 * A2) Else Return x1 * A1 / f1
    End Function


    Sub DemoQuantileR2()
        Dim LeftTail As Double, Righttail As Double, RefTail As Double
        Dim x1 As Double
        Dim IsGLM As Boolean = True
        Dim IsExact As Boolean = False
        Dim Df1 = 24
        Dim Df2 = 34
        Dim t1 = 30.0
        Dim omega = 60
        'LeftTail = 0.9999
        'Righttail = 1 - LeftTail
        LeftTail = 0.0001
        Righttail = 1 - LeftTail

        If LeftTail < 0.5 Then RefTail = LeftTail Else RefTail = Righttail
        Dim LogBeta = Math.Log(LeftTail)
        x1 = QuantileR2_Approx(IsGLM, LeftTail, Righttail, Df1, Df2, t1, omega)
        FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, t1, omega, LeftTail, Righttail)  'fdis
        Dim fx1 = LeftTail
        Console.WriteLine("x1: {0}, fx1: {1}", x1, fx1)

        Dim lnPower = Math.Log(LeftTail)
        Dim L1 = x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = LogBeta - lnPower : Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = +1 Else LSign = -1
        Dim Factor = 0.1
        Dim LStep = x1 * (Factor)
        'If LStep < 2 Then LStep = 2
        Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1)

        Do
            L1 = L2 : F_L1 = F_L2
            L2 = L1 + LStep * LSign
            FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, L2, t1, omega, LeftTail, Righttail)
            lnPower = Math.Log(LeftTail)
            F_L2 = LogBeta - lnPower
            Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_L2: {3}", L2, LeftTail, lnPower, F_L2)
            Factor = Factor + 0.1
            LStep = x1 * (Factor)
        Loop Until F_L2 * LSign < 0

        DemoBrentQuantile(IsExact, IsGLM, L1, L2, F_L1, F_L2, t1, LogBeta, Df1, Df2, omega)

    End Sub


    Function F_New_Quantile(IsExact As Boolean, IsGLM As Boolean, x1 As Double, t1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double) As Double
        Dim lnPower As Double, LeftTail As Double, Righttail As Double
        FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, t1, omega, LeftTail, Righttail)
        lnPower = Math.Log(LeftTail)
        Return LogBeta - lnPower
    End Function


    Sub DemoBrentQuantile(IsExact As Boolean, IsGLM As Boolean, ByRef a As Double, ByRef b As Double, fa As Double, fb As Double, t1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        eps = 0.00000000000001
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
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
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
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            'Function
            fb = F_New_Quantile(IsExact, IsGLM, b, t1, LogBeta, Df1, Df2, omega)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub




    Sub DemoNoncentralityR2()
        Dim DF2 As Double, lambda As Double, alpha As Double, Beta As Double
        Dim DF1 As Double, x1 As Double, LeftTail As Double, Righttail As Double

        Dim IsGLM As Boolean = True
        Dim IsExact As Boolean = False
        Dim omega = 0
        DF1 = 4
        DF2 = 100
        lambda = 0
        alpha = 0.002
        Beta = 0.003 ' Beta must be < 1-alpha

        Dim LogBeta = Math.Log(Beta)
        Console.WriteLine()
        GetL(DF1, x1, lambda, alpha, Beta) ' this returns a value for x1 (at level alpha) and lambda

        'lambda = Get_ChiSquare_Lambda(DF1, alpha, Beta)

        x1 = fdisx(1 - alpha, alpha, DF1, DF2)
        Dim lambda_x1 = lambda
        Call FDisnByRhoSquareDis(IsExact, IsGLM, DF1, DF2, x1, lambda_x1, omega, LeftTail, Righttail)  'fdis
        Dim fx1 = LeftTail
        Console.WriteLine("lambda_x1: {0}, fx1: {1}", lambda_x1, fx1)

        Dim lnPower = Math.Log(LeftTail)
        Dim L1 = lambda_x1 : Dim L2 = L1 : Dim LSign = 0.0
        Dim F_L1 = LogBeta - lnPower : Dim F_L2 = F_L1
        If F_L1 > 0 Then LSign = -1 Else LSign = 1
        Dim Factor = 0.2
        Dim LStep = lambda * (Factor)
        'If LStep < 2 Then LStep = 2
        Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1)
        Do
            L1 = L2 : F_L1 = F_L2
            L2 = L1 + LStep * LSign
            ' is the following superfluous?
            'x1 = Fdisx(1 - alpha, alpha, DF1, DF2)
            FDisnByRhoSquareDis(IsExact, IsGLM, DF1, DF2, x1, L2, omega, LeftTail, Righttail)
            lnPower = Math.Log(LeftTail)
            F_L2 = LogBeta - lnPower
            Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L2, LeftTail, lnPower, F_L2)
            Factor = Factor + 0.2
            LStep = lambda * (Factor)
        Loop Until F_L2 * LSign > 0

        DemoBrentLambda(IsExact, IsGLM, L1, L2, F_L1, F_L2, x1, LogBeta, DF1, DF2, omega)

    End Sub


    Function F_New_Lambda(IsExact As Boolean, IsGLM As Boolean, L2 As Double, x1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double) As Double
        Dim lnPower As Double, LeftTail As Double, Righttail As Double
        FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, L2, omega, LeftTail, Righttail)
        lnPower = Math.Log(LeftTail)
        Return LogBeta - lnPower
    End Function


    Sub DemoBrentLambda(IsExact As Boolean, IsGLM As Boolean, ByRef a As Double, ByRef b As Double, fa As Double, fb As Double, x1 As Double, LogBeta As Double, Df1 As Double, Df2 As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        eps = 0.00000000000001
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
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
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
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            'Function
            fb = F_New_Lambda(IsExact, IsGLM, b, x1, LogBeta, Df1, Df2, omega)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub




    Sub DemoSampleSizeR2()
        Dim lambda As Double, alpha As Double, Beta As Double
        Dim DF1 As Double, x1 As Double, LeftTail As Double, Righttail As Double
        Dim IsGLM As Boolean, Rho2 As Double, n As Double
        Dim R2Tilde As Double, n0 As Double
        Dim LogBeta As Double, lnPower As Double, IsExact As Boolean
        Dim N1 As Double, n2 As Double, F_n1 As Double, F_n2 As Double, FSign As Double, Factor As Double, FStep As Double

        IsExact = True
        IsGLM = True
        Dim omega = 0

        DF1 = 4
        lambda = 0.0
        alpha = 0.04
        Beta = 0.001 ' Beta must be < 1-alpha
        Rho2 = 0.3

        LogBeta = Math.Log(Beta)
        R2Tilde = Rho2 / (1 - Rho2)

        GetL(DF1, x1, lambda, alpha, Beta) ' this returns a value for x1 (at level alpha) and lambda

        'lambda = Get_ChiSquare_Lambda(m, alpha, Beta)


        Console.WriteLine("LambdaC: {0}", lambda)
        Console.WriteLine("R2Tilde: {0}", R2Tilde)
        n = lambda / R2Tilde
        n0 = n
        If n < 3 Then n = 3
        x1 = fdisx(1 - alpha, alpha, DF1, n)
        FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n, x1, n * R2Tilde, omega, LeftTail, Righttail)

        lnPower = Math.Log(LeftTail)

        N1 = n : n2 = N1
        F_n1 = LogBeta - lnPower : F_n2 = F_n1
        If F_n1 > 0 Then FSign = -1 Else FSign = 1
        If Rho2 > 0.2 Then Factor = Rho2 Else Factor = 0.2
        FStep = n0 * (Factor)
        If FStep < 2 Then FStep = 2
        Console.WriteLine("n1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", n, LeftTail, lnPower, F_n1)
        Do
            N1 = n2 : F_n1 = F_n2
            n2 = N1 + FStep * FSign
            x1 = fdisx(1 - alpha, alpha, DF1, n2)
            FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, LeftTail, Righttail)
            lnPower = Math.Log(LeftTail)
            F_n2 = LogBeta - lnPower
            Console.WriteLine("n2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", n2, LeftTail, lnPower, F_n2)
        Loop Until F_n2 * FSign > 0

        DemoBrentSampleSizeR2(IsExact, IsGLM, N1, n2, F_n1, F_n2, alpha, LogBeta, DF1, R2Tilde, omega)




        n2 = n2 * 1.0#
        Console.WriteLine("Lambda: {0}", n2 * R2Tilde)
        x1 = fdisx(1 - alpha, alpha, DF1, n2)
        FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, LeftTail, Righttail)
        Console.WriteLine("n2: {0}, LeftTail: {1}, Diff: {2}", n2, LeftTail, Beta - LeftTail)

        n2 = Int(n2)
        x1 = fdisx(1 - alpha, alpha, DF1, n2)
        FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, LeftTail, Righttail)
        Console.WriteLine("n2: {0}, LeftTail: {1}, Diff: {2}", n2, LeftTail, Beta - LeftTail)

        n2 = n2 + 1
        x1 = fdisx(1 - alpha, alpha, DF1, n2)
        FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, LeftTail, Righttail)
        Console.WriteLine("n2: {0}, LeftTail: {1}, Diff: {2}", n2, LeftTail, Beta - LeftTail)

        FDisnByRhoSquareDis(True, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, LeftTail, Righttail)
        Console.WriteLine("n2: {0}, LeftTail: {1}, Diff: {2}", n2, LeftTail, Beta - LeftTail)
    End Sub


    Function F_New_SampleSizeR2(IsExact As Boolean, IsGLM As Boolean, n As Double, alpha As Double, LogBeta As Double, m As Double, R2Tilde As Double, omega As Double) As Double
        Dim x1 As Double, lnPower As Double, LeftTail As Double, Righttail As Double
        x1 = fdisx(1 - alpha, alpha, m, n)
        FDisnByRhoSquareDis(IsExact, IsGLM, m, n, x1, n * R2Tilde, omega, LeftTail, Righttail)
        lnPower = Math.Log(LeftTail)
        Return LogBeta - lnPower
    End Function


    Sub DemoBrentSampleSizeR2(IsExact As Boolean, IsGLM As Boolean, ByRef a As Double, ByRef b As Double, fa As Double, fb As Double, alpha As Double, LogBeta As Double, m1 As Double, R2Tilde As Double, omega As Double)
        Dim c As Double, d As Double, e As Double, tol As Double, eps As Double
        Dim s As Double, p As Double, q As Double, r As Double, xs As Double
        Dim fc As Double, m As Double
        Dim iter As Long, maxiter As Long
        eps = 0.00000000000001
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
            If Math.Abs(fc) < Math.Abs(fb) Then
                a = b : b = c : c = a
                fa = fb : fb = fc : fc = fa
            End If
            tol = 2 * eps * Math.Abs(b) : m = (c - b) / 2  'Tolerance
            If (Math.Abs(m) > tol) And (Math.Abs(fb) > 0) Then
                If (Math.Abs(e) < tol) Or (Math.Abs(fa) <= Math.Abs(fb)) Then
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
                    If (2 * p < 3 * m * q - Math.Abs(tol * q)) And (p < Math.Abs(s * q / 2)) Then
                        d = p / q
                    Else
                        d = m : e = m
                    End If
                End If
                a = b : fa = fb
                If Math.Abs(d) > tol Then
                    b = b + d
                Else
                    If m > 0 Then b = b + tol Else b = b - tol
                End If
            Else
                GoTo Finish
            End If
            'Function
            fb = F_New_SampleSizeR2(IsExact, IsGLM, b, alpha, LogBeta, m1, R2Tilde, omega)
            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        End While
Finish:
        Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
        xs = b
    End Sub






#End Region




    Sub DemoNoncentral()
        Dim r, rho, nu, mu, a, b, x, nc, nc2, xbeta, ybeta, LeftTail0, RightTail0 As Double
        Dim LeftTail1, RightTail1 As Double
        Dim LeftTail2, RightTail2 As Double
        Dim LeftTail3, RightTail3 As Double
        Dim PDF As Double
        Dim dis As Int32 = 2
        mu = 16
        nu = 20
        x = 3.1
        nc = 5
        nc2 = 6

        Dim p As Int32 = 2 ' p >= 2
        Dim N As Int32 = 11 ' N >= p + 1

        r = 0.5
        rho = 0.59

        Dim R2 = r * r
        Dim Rho2 = rho * rho

        a = 10
        b = 20
        xbeta = 0.7
        ybeta = 1 - xbeta

        Select Case dis
            Case 1 : Console.WriteLine("Noncentral Chi-Square")
                'Cdisn2(nu, x, nc, LeftTail0, RightTail0)
                'CdisnCohen(N, x, nc, LeftTail0, RightTail0)
                NonCentralChi2_SPA(nu, x, nc, LeftTail0, RightTail0)
                'LeftTail1 = xpr.dist_pchisq_nc(x, nu, nc, True, False)
                'LeftTail1 = boost2.dist_chisq_nc(x, nu, nc, 2)
                'RightTail1 = xpr.dist_pchisq_nc(x, nu, nc, False, False)
                'RightTail1 = boost2.dist_chisq_nc(x, nu, nc, 3)
                LeftTail2 = non_central_chi_square_cdf(x, nu, nc)
                RightTail2 = non_central_chi_square_cdf_complement(x, nu, nc)
                NonCentralChi2_SPA2(nu, x, nc, LeftTail3, RightTail3)
                'Cdisn_Penev(nu, x, nc, LeftTail3, RightTail3)


            Case 2 : Console.WriteLine("Noncentral t")
                'tdisn(nu, x, nc, LeftTail0, RightTail0)
                TdisnOwen(N, x, nc, LeftTail0, RightTail0)
                'LeftTail1 = xpr.dist_pt_nc(x, nu, nc, True, False)
                'LeftTail1 = boost2.dist_student_t_nc(x, nu, nc, 2)
                'RightTail1 = xpr.dist_pt_nc(x, nu, nc, False, False)
                'RightTail1 = boost2.dist_student_t_nc(x, nu, nc, 3)
                LeftTail2 = non_central_t_cdf(nu, nc, x)
                RightTail2 = non_central_t_cdf_complement(nu, nc, x)
                TDisN_Broda_Combined(nu, x, nc, 0, PDF, LeftTail3, RightTail3)


            Case 3 : Console.WriteLine("Noncentral F")
                Fdisn2(mu, nu, x, nc, LeftTail0, RightTail0)
                FdisnSeber(x, mu, N, nc, LeftTail0, RightTail0)
                'LeftTail1 = xpr.dist_pf_nc(x, mu, nu, nc, True, False)
                'LeftTail1 = boost2.dist_fisher_f_nc(x, mu, nu, nc, 2)
                'RightTail1 = xpr.dist_pf_nc(x, mu, nu, nc, False, False)
                'RightTail1 = boost2.dist_fisher_f_nc(x, mu, nu, nc, 3)
                LeftTail2 = non_central_f_cdf(x, mu, nu, nc)
                RightTail2 = non_central_f_cdf_complement(x, mu, nu, nc)
                FdisnPaolella(mu, nu, x, nc, 0, PDF, LeftTail3, RightTail3)


            Case 4 : Console.WriteLine("Noncentral beta")
                'Console.WriteLine("xbeta: {0}, ybeta: {1}", xbeta, ybeta)
                'Betadisn(a, b, xbeta, ybeta, nc, LeftTail0, RightTail0)
                BetadisnSeber(xbeta, a, Convert.ToInt32(b), nc, LeftTail0, RightTail0)
                'LeftTail1 = xpr.dist_pbeta_nc(xbeta, a, b, nc, True, False)
                'LeftTail1 = boost2.dist_beta_nc(xbeta, a, b, nc, 2)
                'RightTail1 = xpr.dist_pbeta_nc(xbeta, a, b, nc, False, False)
                'RightTail1 = boost2.dist_beta_nc(xbeta, a, b, nc, 3)

                LeftTail2 = non_central_beta_cdf(a, b, nc, xbeta, ybeta)
                RightTail2 = non_central_beta_cdf_complement(a, b, nc, xbeta, ybeta)
                BetadisnPaolella(a, b, xbeta, ybeta, nc, PDF, LeftTail3, RightTail3)


            Case 5 : Console.WriteLine("Pearson rho")
'                LeftTail0 = RhoExplicit_Arb(N, r, rho).ToDouble
'                RightTail0 = 1 - LeftTail0
                RhoDisN_Guenther(N, r, rho, LeftTail1, RightTail1)
                RhoDisN_Hotelling(N, r, rho, LeftTail2, RightTail2)
                LeftTail3 = RhoDis_W(N, r, rho)
                RightTail3 = 1 - LeftTail3


            Case 6 : Console.WriteLine("RhoSquare")
                RhoSquareDis(True, True, p, N, R2, Rho2, 0, LeftTail0, RightTail0)
                RhoSquareDis(True, False, p, N, R2, Rho2, 0, LeftTail1, RightTail1)
'                LeftTail2 = RhoExplicit_Arb(N, r, rho).ToDouble - RhoExplicit_Arb(N, -r, rho).ToDouble
'                RightTail2 = 1 - LeftTail2
                RhoSquareDis_Lee(p, N, R2, Rho2, LeftTail3, RightTail3)


            Case 7 : Console.WriteLine("Doubly Noncentral t")
                Tdis_Doubly_nc(nu, x, nc, nc2, LeftTail0, RightTail0)
                TDisN_Broda_Combined(nu, x, nc, nc2, PDF, LeftTail1, RightTail1)
                ' approximation by singly noncentral t
                Dim A2 = nu + nc2
                Dim B2 = nu + 2 * nc2
                Dim m2 = A2 * A2 / B2
                Dim y = x * Math.Sqrt(A2 / nu)
                TDisN_Broda_Combined(m2, y, nc, 0, PDF, LeftTail2, RightTail2)


            Case 8 : Console.WriteLine("Doubly Noncentral F")
                Fdisn_Doubly_nc(mu, nu, x, nc, nc2, LeftTail0, RightTail0)
                DoublyFdisn_Paolella_Combined(mu, nu, x, nc, nc2, PDF, LeftTail1, RightTail1)
                ' approximation by singly noncentral F
                Dim A2 = nu + nc2
                Dim B2 = nu + 2 * nc2
                Dim m2 = A2 * A2 / B2
                Dim y = x * A2 / nu
                DoublyFdisn_Paolella_Combined(mu, m2, y, nc, 0, PDF, LeftTail2, RightTail2)


            Case Else : Console.WriteLine("Not implemented")

        End Select

        Console.WriteLine("LeftTail0: {0}, RightTail0: {1}", LeftTail0, RightTail0)
        'Console.WriteLine("LeftTail1: {0}, RightTail1: {1}", LeftTail1, RightTail1)
        Console.WriteLine("LeftTail2: {0}, RightTail2: {1}", LeftTail2, RightTail2)
        Console.WriteLine("LeftTail3: {0}, RightTail3: {1}", LeftTail3, RightTail3)
        Console.WriteLine("PDF:  {0}", PDF)
    End Sub





End Module
