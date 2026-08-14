




#If Win64 Then
Imports mpNative64
#Else
Imports mpNative32
#End If


Module DistMCPArb

    Dim AcbParams As acb_mat_t = acb_mat.set_ones(100, 1)

    Dim MpfrParams As mprf_mat_t = mprf_mat.set_ones(100, 1)

    'wolfram alpha: integrate sin(exp(x))/sqrt(x) from 0 to 2 = 1.50572...
    Function DE_Integration(ByVal func As cbAcbFunctionPtr, ByVal params As acb_mat_t, a As arb_t, b As arb_t, epsabsStart As arb_t, alpha As arb_t, beta As arb_t) As arb_t
        Console.WriteLine("DE_Integration")

        Dim ds As String = ""
        Dim p2 = arb.const_pi / 2
        Dim pi = arb.const_pi
        Dim K, d, C1, C2, epsabs, h, n, hmin, C1Final, epsabsFinal As New arb_t
        Dim radX, radY As Double

        Dim nmin = arb.t("1.0E1000000000000")
        '        Console.WriteLine("nmin at start: {0}", nmin)
        Dim mu, nu As New arb_t
        If alpha < beta Then
            mu = alpha
            nu = beta
        Else
            mu = beta
            nu = alpha
        End If

        '        Determine optimal h and n
        For d1 As Integer = 1 To 26
            'For d1 As Integer = 10 To 16
            GetRectAndK(d1, radX, radY, ds)
            d = ds
            'Console.WriteLine("radX: {0:f}, radY: {1:f}, d: {2:f}, , d1: {3}", radX, radY, d, d1)
            Dim radX_, radY_ As New arb_t
            radX_ = radX : radY_ = radY
            params(mp_order) = 1
            K = GetAcbK(func, params, a.mid, b.mid, radX_, radY_)
            params(mp_order) = 0
            'Console.WriteLine("K: {0}", K)
            C1 = (1 / mu) * 2 * K * (b - a) ^ (alpha + beta - 1)
            epsabs = epsabsStart / C1
            C2 = 2 / ((arb.cos(p2 * arb.sin(d))) ^ (alpha + beta) * arb.cos(d))
            'Console.WriteLine("C1: {0}", C1)
            'Console.WriteLine("C2: {0}", C2)
            'Console.WriteLine("epsabs: {0}", epsabs)
            h = 2 * pi * d / (arb.log(1 + 2 * C2 / epsabs))
            n = (1 / h) * arb.log(2 / (pi * mu) * arb.abs(arb.log(2 * arb.exp(p2 * nu) / epsabs)))
            If (n < 6) Then n = 6
            'n = (1 / h) * arb.log(2 / (pi * mu) * arb.log(2 * arb.exp(p2 * nu) / epsabs))

            'Console.WriteLine("h: {0} n: {1}, nmin: {2}, n < nmin: {3}, ", h, n, nmin, (n < nmin))
            n = arb.abs(n)
            If (n < nmin) Then
                nmin = n
                hmin = h
                C1Final = C1
                epsabsFinal = epsabs
            End If
        Next

        'Console.WriteLine("Final epsabs {0}: ", epsabsFinal)
        'Console.WriteLine("Final C1 {0:f}: ", C1Final)
        '        Determine NN and MM if alpha <> beta
        'Console.WriteLine("hmin: {0}, nmin: {1:f}", hmin, nmin)
        Dim MM, NN As Integer
        MM = arb.ceil(nmin).ToInt32 : NN = MM
        '        Console.WriteLine("n0: {0}", NN)
        If (mu = alpha) Then
            NN = NN - arb.floor(arb.log(beta / alpha) / hmin).ToInt32
        Else
            MM = MM - arb.floor(arb.log(alpha / beta) / hmin).ToInt32
        End If
        Console.WriteLine("NN: {0}", NN)
        Console.WriteLine("MM: {0}", MM)


        '        Perform actual integration
        Dim res, sum, u, t, f, PHI2, c, b1, b2 As New arb_t
        Dim x1, e1, e2, e3, fp1, fm1, su, cu, eu1, eu2 As New arb_t
        Dim kk As Integer
        sum = 0.0
        '        c = p2 * ((b-a)/2) ^ (alpha+beta-1) 
        b1 = (b - a) / 2
        b2 = (b + a) / 2
        c = p2 * (b1) ^ (alpha + beta - 1)
        For kk = -MM To NN
            u = hmin * kk
            eu1 = arb.exp(u)
            eu2 = 1 / eu1
            su = (eu1 - eu2) * 0.5 ' su = sinh(u)
            cu = (eu1 + eu2) * 0.5 ' cu = cosh(u)
            x1 = (p2 * su)
            e1 = arb.exp(x1) ' e1 = exp(x1)
            e2 = 1 / e1 ' e2 = exp(-x1)
            e3 = 1 / (e1 + e2)
            f = (e1 - e2) * e3 ' f = tanh(x1) = (e1 - e2) / (e1 + e2)
            fp1 = 2 * e1 * e3 ' 1+f = 2 * e1 / (e1 + e2)
            fm1 = 2 * e2 * e3 ' 1-f = 2 * e2 / (e1 + e2)
            '            PHI2 = c * arb.cosh(u) * (arb.abs(1+f))^alpha * (arb.abs(1-f))^beta
            If alpha <> 1 Then fp1 = fp1 ^ alpha
            If beta <> 1 Then fm1 = fm1 ^ beta
            PHI2 = c * cu * fp1 * fm1
            t = f * b1 + b2
            '            sum = sum + g(t) * PHI2
            sum = sum + func(t, params).real * PHI2
        Next
        res = hmin * sum
        Console.WriteLine("ED+ET: {0}", C1Final * epsabsFinal)
        Console.WriteLine("Int1: {0}", res)
        Return res
    End Function



    Sub GetRectAndK(ByVal d1 As Integer, ByRef radX As Double, ByRef radY As Double, ByRef ds As String)
        Select Case d1
            Case 1 : radX = 165.2 : radY = 254.3 : ds = "1.5"
            Case 2 : radX = 28.375 : radY = 43.75 : ds = "1.4"
            Case 3 : radX = 11.3 : radY = 17.46 : ds = "1.3"
            Case 4 : radX = 6.06 : radY = 9.34 : ds = "1.2"
            Case 5 : radX = 3.8 : radY = 5.795 : ds = "1.1"
            Case 6 : radX = 2.633 : radY = 3.933 : ds = "1.0"

            Case 7 : radX = 1.968 : radY = 2.826 : ds = "0.9"
            Case 8 : radX = 1.566 : radY = 2.103 : ds = "0.8"
            Case 9 : radX = 1.312 : radY = 1.5994 : ds = "0.7"
            Case 10 : radX = 1.1552 : radY = 1.2276 : ds = "0.6"
            Case 11 : radX = 1.065 : radY = 0.937 : ds = "0.5"
            Case 12 : radX = 1.0197 : radY = 0.702 : ds = "0.4"
            Case 13 : radX = 1.0032 : radY = 0.5008 : ds = "0.3"
            Case 14 : radX = 1.001 : radY = 0.41 : ds = "0.25"
            Case 15 : radX = 1.001 : radY = 0.3228 : ds = "0.2"
            Case 16 : radX = 1.001 : radY = 0.199 : ds = "0.125"
            Case 17 : radX = 1.001 : radY = 0.1584 : ds = "0.1"

            Case 18 : radX = 1.001 : radY = 0.1423 : ds = "0.09"
            Case 19 : radX = 1.001 : radY = 0.1263 : ds = "0.08"
            Case 20 : radX = 1.001 : radY = 0.11037 : ds = "0.07"
            Case 21 : radX = 1.001 : radY = 0.09456 : ds = "0.06"
            Case 22 : radX = 1.001 : radY = 0.0787 : ds = "0.05"
            Case 23 : radX = 1.001 : radY = 0.06296 : ds = "0.04"
            Case 24 : radX = 1.001 : radY = 0.0472 : ds = "0.03"
            Case 25 : radX = 1.001 : radY = 0.03145 : ds = "0.02"
            Case 26 : radX = 1.0 : radY = 0.01572 : ds = "0.01"

            Case Else : Console.WriteLine("Error")
        End Select


    End Sub



    Function GetAcbK(ByVal func As cbAcbFunctionPtr, ByVal params As acb_mat_t, a As arb_t, b As arb_t, radX As arb_t, radY As arb_t) As arb_t
        Dim x, x1, z As New acb_t
        Dim ba2, av, x_re, x_im As New arb_t
        ba2 = (b - a) / 2
        x_re.mid = (b + a) / 2
        x_re.rad = ba2 * radX
        x_im.mid = 0
        x_im.rad = ba2 * radY
        x.real = x_re
        x.imag = x_im
        'Console.WriteLine("x.real.Infimum: {0}, x.real.Supremum: {1}", x.real.Infimum, x.real.Supremum)
        'Console.WriteLine("x.imag.Infimum: {0}, x.imag.Supremum: {1}", x.imag.Infimum, x.imag.Supremum)
        z = func(x, params)
        'Console.WriteLine("x: {0}, z: {1}", x, z)
        av = acb.abs(z)
        'Console.WriteLine("x: {0}, z: {1}, av: {2}", x, z, av)

        Return av.Supremum()
    End Function






    '**********************************************************************************************************    
    '**********************************************************************************************************    


#If Win64 Then
    Sub WrapperParams_GL_Outer(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt64, ByVal prec As UInt64)
#Else
        Sub WrapperParams_GL_Outer(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt32, ByVal prec As UInt32)
#End If
        Dim old_prec = mp4.getprec()
        'Console.WriteLine("In WrapperParams_GL_Outer: order: {0}, prec: {1}, paramsPtr: {2}", order, prec, paramsPtr)
        mp4.setprec(CUInt(prec))
        Dim x As New acb_t(xPtr, True)
        Dim fx As New acb_t()
        fx = AcbIntegrand_Outer(x, Nothing)
        fx.CopyToPtr(fxPtr)
        mp4.setprec(old_prec)
    End Sub


#If Win64 Then
    Sub WrapperParams_GL_Inner(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt64, ByVal prec As UInt64)
#Else
        Sub WrapperParams_GL_Inner(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt32, ByVal prec As UInt32)
#End If
        Dim old_prec = mp4.getprec()
        mp4.setprec(CUInt(prec))
        Dim x As New acb_t(xPtr, True)
        Dim fx As New acb_t()
        fx = AcbIntegrand_Inner(x, Nothing)
        fx.CopyToPtr(fxPtr)
        mp4.setprec(old_prec)
    End Sub




    Function RumpAcb_old(x As acb_t, ByVal params As acb_mat_t) As acb_t
        Return acb.sin(x + acb.exp(x))
    End Function




    Sub DemoAcbIntegrationRumpExample_GL_old()
        mp4.setprec(100)
        AcbParams(0) = mp_integral_Rump
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = 0
        b = 8
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
    End Sub


    Function RumpAcb(r As acb_t, ByVal params As acb_mat_t) As acb_t
        Dim a = arb.t("1000000")
        Dim z = a - 4000
        Dim f = acb.exp(-r)
        Dim c = (1 + f)
        Dim d = c ^ -(a + 1)
        Dim e = acb.exp(-z / c)
        Dim result = d * e * f
        result = result * z ^ a / acb.gamma(a)
        Return result
    End Function




    Sub DemoAcbIntegrationRumpExample_GL()
        mp4.setdps(40)
        AcbParams(0) = mp_integral_Rump
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 1
        a = 5.2
        b = 40
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
    End Sub





    Function AcbSinExp(t As acb_t, ByVal params As acb_mat_t) As acb_t
        Return acb.sin(acb.exp(t))
    End Function



    Public Sub DemoAcbSinExpIntegration_DE()
        mp4.setdps(40)
        AcbParams(0) = mp_integral_AcbSinExp_DE
        Dim a, b, epsabsStart, alpha, beta As New arb_t
        a = 0.0 : b = 2.0 : alpha = 0.5 : beta = 1.0 ' alpha = 0.5 to compensate for omitting division by sqrt(x)
        epsabsStart = "1.0E-30"
        DE_Integration(AddressOf AcbIntegrand_Outer, AcbParams, a, b, epsabsStart, alpha, beta)
    End Sub




    Function cf_chisquared(k As arb_t, t As acb_t) As acb_t
        Dim ione As New acb_t
        ione.real = 0
        ione.imag = 1
        Return (1 - 2 * ione * t) ^ (-k / 2)
    End Function


    Function g_chisquared(t As acb_t, ByVal params As acb_mat_t) As acb_t
        Dim k, x As New arb_t
        k = 10000
        x = k - 500
        Dim result, phi, z, ione As New acb_t
        ione.real = 0
        ione.imag = 1
        phi = cf_chisquared(k, t)
        z = acb.exp(-ione * t * x) * phi
        result = z.imag / t
        Return result
    End Function


    Function g_chisquared_u2(u As acb_t, ByVal params As acb_mat_t) As acb_t
        Dim t, g, result As New acb_t
        t = u / (1 - u)
        g = g_chisquared(t, params)
        result = g / ((1 - u) * (1 - u))
        Return result
    End Function



    Sub Demo_g_chisquared_GL()
        Dim p As UInt32 = 2
        mp4.setprec(100)
        AcbParams(0) = mp_integral_g_chisquared
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 1
        a = arb.t("1E-30")
        b = 0.9999999999
        'b = 0.1
        Dim rel_goal As UInt32 = workingprec \ p
        Dim abs_tol_bits As UInt32 = workingprec \ p
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
        Dim s1 = s / arb.const_pi()
        Console.WriteLine("Integral/pi: {0}", s1)
        Dim result = 0.5 - s1
        Console.WriteLine("Result: {0}", result)
    End Sub













    Function cf_betaproduct(t As acb_t, p As Int32, b As arb_mat_t, c As arb_mat_t) As acb_t
        Dim ione, result, bk, dk, g1, g2, g3, g4, prod1 As New acb_t
        result = 1
        ione.real = 0
        ione.imag = 1
        For k = 1 To p
            bk = b(k)
            dk = c(k)
            g1 = acb.gamma(bk - ione * t)
            g2 = acb.gamma(dk)
            g3 = acb.gamma(bk)
            g4 = acb.gamma(dk - ione * t)
            prod1 = (g1 * g2) / (g3 * g4)
            result = result * prod1
        Next
        Return result
    End Function


    Function g_betaproduct(t As acb_t, ByVal params As acb_mat_t) As acb_t
        Dim n, x As New arb_t
        x = 4.5292648821553
        Dim p As Int32 = 4
        Dim f1 As Int32 = 7 - 1
        n = 20 - 7
        Dim b, c As New arb_mat_t
        b.resize(p + 1, 1)
        c.resize(p + 1, 1)
        For i = 1 To p
            b(i) = ((n - i + 1) / 2)
            c(i) = (b(i) + f1 / 2)
        Next
        Dim result, phi, z, ione As New acb_t
        ione.real = 0
        ione.imag = 1
        phi = cf_betaproduct(t, p, b, c)
        z = acb.exp(-ione * t * x) * phi
        result = z.imag / t
        Return result
    End Function


    Function g_betaproduct_u2(u As acb_t, ByVal params As acb_mat_t) As acb_t
        Dim t, g, result As New acb_t
        t = u / (1 - u)
        g = g_betaproduct(t, params)
        result = g / ((1 - u) * (1 - u))
        Return result
    End Function


    Function g_betaproduct_u(u As acb_t, ByVal params As acb_mat_t) As acb_t
        Dim t, g, result As New acb_t
        t = (1 - u) / u
        g = g_betaproduct(t, params)
        result = g / (u * u)
        Return result
    End Function


    Sub Demo_g_betaproduct_GL()
        Dim p As UInt32 = 2
        mp4.setprec(100)
        AcbParams(0) = mp_integral_g_betaproduct
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 1
        'a = arb.t("1E-30")
        'b = 0.9999999999
        a = arb.t("1E-30")
        b = 100
        'b = 0.1
        Dim rel_goal As UInt32 = workingprec \ p
        Dim abs_tol_bits As UInt32 = workingprec \ p
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
        Dim s1 = s / arb.const_pi()
        Console.WriteLine("Integral/pi: {0}", s1)
        Dim result = 0.5 - s1
        Console.WriteLine("Result: {0}", result)

    End Sub





    '**********************************************************************************************************    
    '**********************************************************************************************************    
    '**********************************************************************************************************    
    '**********************************************************************************************************    





    Friend Const mp_proc_outer_pos As Int32 = 0
    Friend Const mp_mprf_function_choice_outer_pos As Int32 = 1
    Friend Const mp_abs_error_pos As Int32 = 2
    Friend Const mp_k_pos As Int32 = 3
    Friend Const mp_n_pos As Int32 = 4
    Friend Const mp_crit_outer_pos As Int32 = 5
    Friend Const mp_crit_inner_pos As Int32 = 6
    Friend Const mp_proc_inner_pos As Int32 = 7
    Friend Const mp_mprf_function_choice_inner_pos As Int32 = 8
    Friend Const mp_mu_start_pos As Int32 = 9




    Friend Const mp_integral_studentized_maximum As Int32 = 0
    Friend Const mp_integral_studentized_maxmodulus As Int32 = 1
    Friend Const mp_integral_normal_range As Int32 = 2
    Friend Const mp_integral_studentized_range As Int32 = 3
    Friend Const mp_integral_normal_dunnett1 As Int32 = 4
    Friend Const mp_integral_studentized_dunnett1 As Int32 = 5
    Friend Const mp_integral_normal_dunnett2 As Int32 = 6
    Friend Const mp_integral_studentized_dunnett2 As Int32 = 7
    Friend Const mp_integral_Rump As Int32 = 8
    Friend Const mp_integral_AcbSinExp_DE As Int32 = 9
    Friend Const mp_integral_AcbSinExp_GL As Int32 = 10
    Friend Const mp_integral_normal_maximum As Int32 = 12
    Friend Const mp_integral_normal_maxmodulus As Int32 = 13
    Friend Const mp_integral_normal_mcm1 As Int32 = 14
    Friend Const mp_integral_normal_mcm2 As Int32 = 15

    Friend Const mp_integral_chisquare_nc As Int32 = 15
    Friend Const mp_integral_t_nc As Int32 = 16
    Friend Const mp_integral_f_nc As Int32 = 17
    Friend Const mp_integral_beta_nc As Int32 = 18
    Friend Const mp_integral_rho As Int32 = 19
    Friend Const mp_integral_rho2 As Int32 = 20
    Friend Const mp_integral_chisquare As Int32 = 21

    Friend Const mp_integral_gammastar As Int32 = 22
    Friend Const mp_integral_gammastar2 As Int32 = 23
    Friend Const mp_integral_g_chisquared As Int32 = 24
    Friend Const mp_integral_g_betaproduct As Int32 = 25



    '**********************************************************************************************************    

    Function MpfrCalcParams_Outer(x As mprf_t, mprf_params As mprf_mat_t) As mprf_t
        'Dim params = acb.mat_t(mprf_params)
        'Dim resacb = AcbIntegrand_Outer(acb.t(x), params)
        Dim resacb = AcbIntegrand_Outer(acb.t(x), Nothing)
        Return mprf.t(resacb.real)
    End Function


    Sub FuncMpfrParams_Outer(ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal fxPtr As IntPtr)
        Dim x As New mprf_t(xPtr, True)
        Dim fx As New mprf_t()
        'Dim params As New mprf_mat_t()
        'Dim tparamsPtr As IntPtr : tparamsPtr = params.mpPtr : params.mpPtr = paramsPtr

        Dim proc As Int32 = MpfrParams(mp_mprf_function_choice_outer_pos).ToInt32
        Dim AbsCDFErr = MpfrParams(mp_abs_error_pos)

        Select Case proc
            Case 0 : fx = -MpfrCalcParams_Outer(x, MpfrParams)
            Case 1 : fx = (MpfrCalcParams_Outer(x, MpfrParams) * mprf.abs(x)) - AbsCDFErr
            Case 2 : fx = -MpfrCalcParams_Outer(x, MpfrParams) * x * x
            Case 3 : fx = ((MpfrCalcParams_Outer(x, MpfrParams) * x * x) * (1 / x)) - AbsCDFErr
            Case Else : fx = mprf.nan()
        End Select

        Console.WriteLine("Outer: x: {0}, f(x): {1}", x, fx)
        'paramsPtr = params.mpPtr : params.mpPtr = tparamsPtr
        fx.CopyToPtr(fxPtr)
    End Sub


    Sub MpfrSolverBoost_Outer(bracket_min As mprf_t, bracket_max As mprf_t, params2 As mprf_mat_t, ByRef Max_Simple As mprf_t, ByRef LeftBorder As mprf_t, ByRef RightBorder As mprf_t)
        '        mp4.setprec(100)

        Dim result As New mprf_t
        'Dim get_digits As Int32 = CInt(getprec()) - 5, maxit As UInt32 = 100
        Dim get_digits As Int32 = 10, maxit As UInt32 = 100

        MpfrParams(mp_mprf_function_choice_outer_pos) = 0
        'Dim bits As Int32 = CInt(getprec()) - 5
        Dim bits As Int32 = 10
        '        bracket_max = 100.0
        '        Console.WriteLine("Outer: Brent_MinimumParams: Max_Simple")
        Max_Simple = mpfrCallback.Brent_MinimumParams(AddressOf FuncMpfrParams_Outer, MpfrParams, bracket_min, bracket_max, bits, maxit)
        Console.WriteLine("Outer: Max_Simple: {0}", Max_Simple)

        MpfrParams(mp_mprf_function_choice_outer_pos) = 1
        Dim guess, factor As New mprf_t
        guess = Max_Simple / 1.02
        factor = 1.2
        Dim is_rising As Boolean = True
        '        Console.WriteLine("Outer: BracketRoot")
        LeftBorder = mpfrCallback.BracketRootParams(AddressOf FuncMpfrParams_Outer, MpfrParams, guess, factor, is_rising, get_digits, 2000)
        Console.WriteLine("Outer: LeftBorder: {0}", LeftBorder)


        Dim Max_X2 As New mprf_t
        MpfrParams(mp_mprf_function_choice_outer_pos) = 2
        bracket_min = Max_Simple
        bracket_max = Max_Simple + 1
        '        bracket_max = 100.0
        '        Console.WriteLine("Outer: Brent_MinimumParams: Max_X2")
        Max_X2 = mpfrCallback.Brent_MinimumParams(AddressOf FuncMpfrParams_Outer, MpfrParams, bracket_min, bracket_max, bits, maxit)
        Console.WriteLine("Outer: Max_X2: {0}", Max_X2)

        MpfrParams(mp_mprf_function_choice_outer_pos) = 3
        guess = Max_X2 * 1.02
        factor = 1.2
        is_rising = False
        '        Console.WriteLine("Outer: BracketRoot")
        RightBorder = mpfrCallback.BracketRootParams(AddressOf FuncMpfrParams_Outer, MpfrParams, guess, factor, is_rising, get_digits, maxit)
        Console.WriteLine("Outer: RightBorder: {0}", RightBorder)

    End Sub


    '**********************************************************************************************************    

    Function MpfrCalcParams_Inner(x As mprf_t, mprf_params As mprf_mat_t) As mprf_t
        'Dim params = acb.mat_t(mprf_params)
        'Dim resacb = AcbIntegrand_Inner(acb.t(x), params)
        Dim resacb = AcbIntegrand_Inner(acb.t(x), Nothing)
        Return mprf.t(resacb.real)
    End Function


    Sub FuncMpfrParams_Inner(ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal fxPtr As IntPtr)
        Dim x As New mprf_t(xPtr, True)
        Dim fx As New mprf_t()
        'Dim params As New mprf_mat_t()
        'Dim tparamsPtr As IntPtr : tparamsPtr = params.mpPtr : params.mpPtr = paramsPtr

        Dim proc As Int32 = MpfrParams(mp_mprf_function_choice_inner_pos).ToInt32
        Dim AbsCDFErr = MpfrParams(mp_abs_error_pos)

        Select Case proc
            Case 0 : fx = -MpfrCalcParams_Inner(x, MpfrParams)
            Case 1 : fx = (MpfrCalcParams_Inner(x, MpfrParams) * mprf.abs(x)) - AbsCDFErr
            Case 2 : fx = -MpfrCalcParams_Inner(x, MpfrParams) * x * x
            Case 3 : fx = ((MpfrCalcParams_Inner(x, MpfrParams) * x * x) * (1 / x)) - AbsCDFErr
            Case Else : fx = mprf.nan()
        End Select

        'Console.WriteLine("Inner: x: {0}, f(x): {1}", x, fx)
        'paramsPtr = params.mpPtr : params.mpPtr = tparamsPtr
        fx.CopyToPtr(fxPtr)
    End Sub



    Sub MpfrSolverBoost_Inner(bracket_min As mprf_t, bracket_max As mprf_t, params2 As mprf_mat_t, ByRef Max_Simple As mprf_t, ByRef LeftBorder As mprf_t, ByRef RightBorder As mprf_t)

        'Dim get_digits As Int32 = CInt(getprec()) - 5, maxit As UInt32 = 25
        'Dim bits As Int32 = CInt(getprec()) - 5

        Dim get_digits As Int32 = 10, maxit As UInt32 = 25
        Dim bits As Int32 = 10

        MpfrParams(mp_mprf_function_choice_inner_pos) = 0
        '        bracket_max = 100.0
        '        Console.WriteLine("Inner: Brent_MinimumParams: Max_Simple")
        Max_Simple = mpfrCallback.Brent_MinimumParams(AddressOf FuncMpfrParams_Inner, MpfrParams, bracket_min, bracket_max, bits, maxit)
        Console.WriteLine("Inner: Max_Simple: {0}", Max_Simple)

        MpfrParams(mp_mprf_function_choice_inner_pos) = 1
        Dim guess, factor As New mprf_t
        guess = -1
        factor = 1.2
        Dim is_rising As Boolean = True
        '        Console.WriteLine("Inner: BracketRoot")
        LeftBorder = mpfrCallback.BracketRootParams(AddressOf FuncMpfrParams_Inner, MpfrParams, guess, factor, is_rising, get_digits, 200)
        Console.WriteLine("Inner: LeftBorder: {0}", LeftBorder)


        Dim Max_X2 As New mprf_t
        MpfrParams(mp_mprf_function_choice_inner_pos) = 2
        bracket_min = Max_Simple
        bracket_max = Max_Simple + 1
        '        bracket_max = 100.0
        '        Console.WriteLine("Inner: Brent_MinimumParams: Max_X2")
        Max_X2 = mpfrCallback.Brent_MinimumParams(AddressOf FuncMpfrParams_Inner, MpfrParams, bracket_min, bracket_max, bits, maxit)
        Console.WriteLine("Inner: Max_X2: {0}", Max_X2)

        MpfrParams(mp_mprf_function_choice_inner_pos) = 3
        guess = Max_X2 * 1.02
        factor = 1.2
        is_rising = False
        '        Console.WriteLine("Inner: BracketRoot")
        RightBorder = mpfrCallback.BracketRootParams(AddressOf FuncMpfrParams_Inner, MpfrParams, guess, factor, is_rising, get_digits, maxit)
        Console.WriteLine("Inner: RightBorder: {0}", RightBorder)

    End Sub

    '**********************************************************************************************************    



    Function AcbIntegrand_Outer(x As acb_t, ByVal params2 As acb_mat_t) As acb_t
        'Console.WriteLine("Before Read: params.mpPtr: {0}", AcbParams.mpPtr)
        Dim proc_outer As Int32 = AcbParams(mp_proc_outer_pos).real.ToInt32
        'Console.WriteLine("After  Read: params.mpPtr: {0}, proc_outer: {1}", AcbParams.mpPtr, proc_outer)
        'Dim proc_outer As Int32 = 8
        Dim fx As New acb_t
        Select Case proc_outer
            Case mp_integral_studentized_maximum : fx = Studentize(x, AcbParams)
            Case mp_integral_studentized_maxmodulus : fx = Studentize(x, AcbParams)
            Case mp_integral_studentized_range : fx = Studentize(x, AcbParams)
            Case mp_integral_studentized_dunnett1 : fx = Studentize(x, AcbParams)
            Case mp_integral_studentized_dunnett2 : fx = Studentize(x, AcbParams)

            Case mp_integral_Rump : fx = RumpAcb(x, AcbParams)
            Case mp_integral_g_chisquared : fx = g_chisquared_u2(x, AcbParams)
            'Case mp_integral_g_betaproduct : fx = g_betaproduct_u2(x, AcbParams)
            Case mp_integral_g_betaproduct : fx = g_betaproduct(x, AcbParams)
            Case mp_integral_AcbSinExp_DE : fx = AcbSinExp(x, AcbParams)
            Case mp_integral_AcbSinExp_GL : fx = AcbSinExp(x, AcbParams) / acb.sqrt(x)
            Case Else : Console.WriteLine("!!!! Error AcbIntegrand_Outer !!!!!)") : fx = acb.nan()
        End Select
        '        Console.WriteLine("fx: {0}", fx)
        Return fx
    End Function


    Function AcbIntegrand_Inner(x As acb_t, ByVal params2 As acb_mat_t) As acb_t
        Dim proc_inner As Int32 = AcbParams(mp_proc_inner_pos).real.ToInt32
        Dim fx As New acb_t
        Select Case proc_inner
            Case mp_integral_normal_range : fx = AcbNormalRange(x, AcbParams)
            Case mp_integral_normal_dunnett1 : fx = AcbNormalDunnett1(x, AcbParams)
            Case mp_integral_normal_dunnett2 : fx = AcbNormalDunnett2(x, AcbParams)
            Case mp_integral_normal_mcm1 : fx = AcbNormalMCM1(x, AcbParams)
            Case mp_integral_normal_mcm2 : fx = AcbNormalMCM2(x, AcbParams)
            Case Else : Console.WriteLine("!!!! Error AcbIntegrand_Inner !!!!!)") : fx = acb.nan()
        End Select
        '        Console.WriteLine("fx: {0}", fx)
        Return fx
    End Function






    '**********************************************************************************************************    
    '**********************************************************************************************************    



    Function NdisAcb(x As acb_t) As acb_t
        Return acb.ndis(x)
    End Function


    Function NdensAcb(x As acb_t) As acb_t
        Return acb.ndens(x)
    End Function





    Function NormalMaxModulus(ByVal params2 As acb_mat_t) As acb_t
        Dim res, delta As New acb_t
        Dim proc_inner As Int32 = AcbParams(mp_proc_inner_pos).real.ToInt32
        Dim k As Int32 = AcbParams(mp_k_pos).real.ToInt32
        Dim x = AcbParams(mp_crit_inner_pos)
        res = 1.0
        For i As Int32 = 0 To (k - 1)
            delta = AcbParams(i + mp_mu_start_pos)
            Select Case proc_inner
                Case mp_integral_normal_maximum : res = res * (NdisAcb(x - delta))
                Case mp_integral_normal_maxmodulus : res = res * (NdisAcb(x - delta) - NdisAcb(-x - delta))
                Case Else : res = acb.nan()
            End Select
        Next
        Return res
    End Function




    Function AcbNormalDunnett1(y As acb_t, ByVal params2 As acb_mat_t) As acb_t
        Dim rho, k, x, d As New acb_t
        k = AcbParams(mp_k_pos)
        x = AcbParams(mp_crit_inner_pos)  ' critical value for inner integration
        rho = acb.t("0.5")
        d = NdisAcb((x + y * acb.sqrt(rho)) / acb.sqrt(1 - rho))
        d = d ^ k
        d = d * NdensAcb(y)
        '        Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
        Return d
    End Function



    Function AcbNormalDunnett2(y As acb_t, ByVal params2 As acb_mat_t) As acb_t
        Dim rho, k, x, d1, d2, d As New acb_t
        k = AcbParams(mp_k_pos)
        x = AcbParams(mp_crit_inner_pos)  ' critical value for inner integration
        rho = acb.t("0.5")
        d1 = NdisAcb((x + y * acb.sqrt(rho)) / acb.sqrt(1 - rho))
        d2 = NdisAcb((-x + y * acb.sqrt(rho)) / acb.sqrt(1 - rho))
        d = (d1 - d2) ^ k
        d = d * NdensAcb(y)
        '        Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
        Return d
    End Function


    ' Multiple comparisons with the mean: see Soong 2001
    Function AcbNormalMCM1(y As acb_t, ByVal params2 As acb_mat_t) As acb_t
        Dim rho, k, x, d As New acb_t
        k = AcbParams(mp_k_pos)
        x = AcbParams(mp_crit_inner_pos)  ' critical value for inner integration
        '        rho = acb.t("0.5")
        rho = -1 / (k)
        d = NdisAcb((x + y * acb.sqrt(rho)) / acb.sqrt(1 - rho))
        d = d ^ (k)
        d = d * NdensAcb(y)
        '        Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
        Return d
    End Function


    ' Multiple comparisons with the mean: see Soong 2001
    Function AcbNormalMCM2(y As acb_t, ByVal params2 As acb_mat_t) As acb_t
        Dim rho, k, x, d1, d2, d As New acb_t
        k = AcbParams(mp_k_pos)
        x = AcbParams(mp_crit_inner_pos)  ' critical value for inner integration
        '        rho = acb.t("0.5")
        rho = -1 / (k)
        d1 = NdisAcb((x + y * acb.sqrt(rho)) / acb.sqrt(1 - rho))
        d2 = NdisAcb((-x + y * acb.sqrt(rho)) / acb.sqrt(1 - rho))
        d = (d1 - d2) ^ (k)
        d = d * NdensAcb(y)
        '        Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
        Return d
    End Function


    Function AcbNormalRange(y As acb_t, ByVal params2 As acb_mat_t) As acb_t
        Dim k, x, d1, d2, d As New acb_t
        k = AcbParams(mp_k_pos) + 1
        x = AcbParams(mp_crit_inner_pos) * acb.sqrt(acb.t("2"))  ' critical value for inner integration
        d1 = NdisAcb(y)
        d2 = NdisAcb(y - x)
        d = k * ((d1 - d2) ^ (k - 1))
        d = d * NdensAcb(y)
        '        Console.WriteLine("y: {0}, x: {1}, d: {2}", y, x, d)
        Return d
    End Function



    Function Studentize(x As acb_t, ByVal params2 As acb_mat_t) As acb_t
        Dim n, c, a, b, res1, res2, fx As New acb_t
        Dim proc_outer As Int32 = AcbParams(mp_proc_outer_pos).real.ToInt32
        Dim k As Int32 = AcbParams(mp_k_pos).real.ToInt32
        n = AcbParams(mp_n_pos)
        c = AcbParams(mp_crit_outer_pos)
        AcbParams(mp_crit_inner_pos) = c * x
        Select Case proc_outer
            Case mp_integral_studentized_maximum : res1 = NormalMaxModulus(AcbParams)
            Case mp_integral_studentized_maxmodulus : res1 = NormalMaxModulus(AcbParams)
            Case mp_integral_studentized_dunnett1 : res1 = MultivariateNormalIntegral(AcbParams)
            Case mp_integral_studentized_dunnett2 : res1 = MultivariateNormalIntegral(AcbParams)
            Case mp_integral_studentized_range : res1 = MultivariateNormalIntegral(AcbParams)
            Case Else : res1 = acb.nan()
        End Select
        '        res1 = 1
        a = n ^ (n / 2) * x ^ (n - 1) * acb.exp(-n * x * x / 2)
        b = 2 ^ ((n - 1) / 2) * acb.gamma(n / 2) / acb.sqrt(2)
        res2 = a / b
        fx = res1 * res2
        '        Console.WriteLine("x: {0}, cx: {1}, res1: {2}, res1*res2: {3}", x, c*x, res1, fx)
        Return fx
    End Function



    Public Function MultivariateNormalIntegral(params2 As acb_mat_t) As acb_t
        Dim Max_Simple As New mprf_t
        Dim LeftBorder As New mprf_t
        Dim RightBorder As New mprf_t

        Dim x = AcbParams(mp_crit_inner_pos)

        Dim x0 As arb_t
        x0 = x.real.mid
        AcbParams(mp_crit_inner_pos) = x0
        Console.WriteLine("x0: {0}", x0)
        Console.WriteLine("")

        MpfrParams = mprf_mat.t(AcbParams.real)
        Dim bracket_min, bracket_max As New mprf_t
        bracket_min = -10.0
        bracket_max = 10.0
        MpfrSolverBoost_Inner(bracket_min, bracket_max, MpfrParams, Max_Simple, LeftBorder, RightBorder)
        AcbParams(mp_crit_inner_pos) = x
        Console.WriteLine("x: {0}", x)

        Dim peak, a, b As New acb_t
        peak = acb.t(Max_Simple)
        a = acb.t(LeftBorder)
        b = acb.t(RightBorder)

        '        Console.WriteLine("Inner: x: {0}, a: {1}, b: {2}", x, a, b)
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        Dim rel_goal As UInt32 = CUInt(workingprec)
        Dim abs_tol_bits As UInt32 = CUInt(workingprec)
        '        Dim rel_goal As UInt32 = CUInt( workingprec \ 2)
        '        Dim abs_tol_bits As UInt32 = CUInt( workingprec \ 2)
        Dim eval_limit As UInt32 = 0
        'Dim I1_GL = acb.gl_integration(AddressOf WrapperParams_GL_Inner, a, b, params, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Dim I1_GL = acb.gl_integration(AddressOf WrapperParams_GL_Inner, a, b, AcbParams, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        '        Console.WriteLine("Inner Integral_GL:{0}", I1_GL)
        '        Dim av = acb.abs(I1_GL)
        '        Console.WriteLine("av:  {0}, av.supremum(): {1}, ", av, av.supremum())
        Return I1_GL
    End Function



    Public Sub DemoMultivariateNormalIntegration()
        mp4.setdps(40)

        Dim n, x, RelErr As New acb_t
        Dim k, inner_proc As Int32
        Dim k1 As Double = 1.0

        'inner_proc = mp_integral_normal_dunnett1
        'inner_proc = mp_integral_normal_dunnett2
        'inner_proc = mp_integral_normal_range
        'inner_proc = mp_integral_normal_mcm1
        inner_proc = mp_integral_normal_mcm2


        x = acb.t("3.088")
        RelErr = acb.t("1.0E-20")
        k = 5 ' number of groups - 1
        If ((inner_proc = mp_integral_normal_mcm1) And (k > 1)) Then
            k1 = Math.Sqrt(k / (k - 1)) ' assumes k > 1; this factor is required to match for the tables of Nair 1948 and Grubbs 1950
        End If
        Console.WriteLine("k1: {0}", k1)
        x = k1 * x
        Dim x_re, x_im As arb_t
        x_re = 0
        x_im = 0
        x_re.mid = x.real
        x_re.rad = 4.5
        x_im.mid = x.imag
        x_im.rad = 4.5
        '        x.real = x_re
        '        x.imag = x_im


        'Dim params As New acb_mat_t
        'params = acb.mat_set_zero(mp_mu_start_pos + k, 1)
        AcbParams(mp_proc_outer_pos) = 0
        AcbParams(mp_mprf_function_choice_outer_pos) = 0 ' placeholder for proc outer integration
        '        params(mp_abs_error_pos) = AbsCDFErr
        AcbParams(mp_abs_error_pos) = RelErr

        AcbParams(mp_k_pos) = k
        AcbParams(mp_n_pos) = 0   ' placeholder for error df for outer integration
        AcbParams(mp_crit_outer_pos) = 0   ' critical value for outer integration
        AcbParams(mp_crit_inner_pos) = x   ' critical value for inner integration
        AcbParams(mp_proc_inner_pos) = inner_proc
        AcbParams(mp_mprf_function_choice_inner_pos) = 0 ' placeholder for proc inner integration

        'Dim result = MultivariateNormalIntegral(params)
        Dim result = MultivariateNormalIntegral(Nothing)
        Console.WriteLine("result DemoMultivariateNormalIntegration: {0}", result)
    End Sub




    Public Sub DemoStudentizedIntegration()
        mp4.setdps(40)

        Dim n, c, RelErr, AbsCDFErr As New acb_t
        Dim proc_outer, proc_inner, k As Int32
        'proc_outer = mp_integral_studentized_maximum
        proc_outer = mp_integral_studentized_maxmodulus
        'proc_outer = mp_integral_studentized_dunnett1
        '        proc_outer = mp_integral_studentized_dunnett2
        '        proc_outer = mp_integral_studentized_range

        Select Case proc_outer
            Case mp_integral_studentized_maximum : proc_inner = mp_integral_normal_maximum
            Case mp_integral_studentized_maxmodulus : proc_inner = mp_integral_normal_maxmodulus
            Case mp_integral_studentized_dunnett1 : proc_inner = mp_integral_normal_dunnett1
            Case mp_integral_studentized_dunnett2 : proc_inner = mp_integral_normal_dunnett2
            Case mp_integral_studentized_range : proc_inner = mp_integral_normal_range
            Case Else : proc_inner = 0
        End Select

        k = 4 ' number of normal variables
        n = acb.t("1.0")
        c = acb.t("3.1")
        RelErr = acb.t("1.0E-10")

        Dim mu = acb_mat.set_zero(k, 1)
        mu(0) = 0
        mu(1) = 0
        mu(2) = 0

        AbsCDFErr = RelErr

        'Dim params = acb.mat_set_zero(mp_mu_start_pos + k, 1)
        AcbParams(mp_proc_outer_pos) = proc_outer   ' proc for inner integratio
        AcbParams(mp_mprf_function_choice_outer_pos) = 0   ' placeholder for function choice in mprf
        AcbParams(mp_abs_error_pos) = AbsCDFErr  '  target absolute error for outer integral
        AcbParams(mp_k_pos) = k   ' number of groups
        AcbParams(mp_n_pos) = n   ' error df
        AcbParams(mp_crit_outer_pos) = c   ' critical value for outer integration
        AcbParams(mp_crit_inner_pos) = 0   ' critical value for inner integration
        AcbParams(mp_proc_inner_pos) = proc_inner   ' proc for inner integration
        AcbParams(mp_mprf_function_choice_inner_pos) = 0    ' function choice in mprf placeholder for proc inner integration
        For i = 0 To (k - 1)
            AcbParams(mp_mu_start_pos + i) = mu(i)
        Next

        Dim Max_Simple As New mprf_t
        Dim LeftBorder As New mprf_t
        Dim RightBorder As New mprf_t

        'Dim mprf_params = mprf.mat_t(params.real)
        MpfrParams = mprf_mat.t(AcbParams.real)
        Dim bracket_min, bracket_max As New mprf_t
        Dim peak, a, b As New arb_t

        bracket_min = 0.0
        bracket_max = 10.0
        MpfrSolverBoost_Outer(bracket_min, bracket_max, MpfrParams, Max_Simple, LeftBorder, RightBorder)
        peak = arb.t(Max_Simple)
        a = arb.t(LeftBorder)
        b = arb.t(RightBorder)

        peak = arb.t("1.0")
        a = arb.t("1E-10")
        b = arb.t("5")

        Dim workingprec As UInt32 = mp4.getprec()
        Console.WriteLine("workingprec : {0}", workingprec)
        Dim verbose As UInt32 = 2
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        Dim I1_GL = acb.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, AcbParams, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        '        Dim I1_GL = acb.gl_integration(AddressOf WrapperParams_GL_Outer, a, b, params, workingprec, verbose, rel_goal, abs_tol_bits)
        Console.WriteLine("Outer Integral_GL:{0}", I1_GL)
    End Sub



    ' Note: There are still a lot of issues with getting the right balance with:
    ' mp4.setprec(100)
    ' Dim eval_limit As UInt32 = 0
    ' This can easily cause crashes in form of seg faults




    Public Sub DemoMCPArb()
#If Win64 Then
        Console.WriteLine("Running 64 bit")
#Else
        Console.WriteLine("Running 32 bit")
#End If


        DemoAcbIntegrationRumpExample_GL()
        'DemoAcbSinExpIntegration_DE()

        'DemoStudentizedIntegration()
        'DemoMultivariateNormalIntegration()

    End Sub









End Module
