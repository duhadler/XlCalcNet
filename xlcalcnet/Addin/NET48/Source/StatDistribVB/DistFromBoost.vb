Imports System


'#If Direct Then 
#If Win64 Then
Imports mpNative64
#Else
        Imports mpNative32
#End If
'#Else
'    Imports mpFormulaClient
'#End If



Module DistFromBoost

    Dim AcbParamsNC As acb_mat_t = acb_mat.set_ones(100, 1)

    Friend Const mp_df1_pos As Int32 = 1
    Friend Const mp_df2_pos As Int32 = 2
    Friend Const mp_nc_pos As Int32 = 3
    Friend Const mp_order As Int32 = 4


    Function Arb_Cauchy_pdf(x As arb_t, a As arb_t, b As arb_t, log As Boolean) As arb_t
        Dim result, pi_inv As New arb_t
        pi_inv = 1 / arb.const_pi()
        result = pi_inv * b / ((x - a) * (x - a) + b * b)
        Return result
    End Function


    Function Arb_Cauchy_CDF(x As arb_t, a As arb_t, b As arb_t, lower_tail As Boolean, log As Boolean) As arb_t
        Dim result, pi_inv As New arb_t
        pi_inv = 1 / arb.const_pi()
        result = 0.5 + pi_inv * arb.atan((x - a) / b)
        Return 1 - result
    End Function


    Function Arb_Cauchy_ICDF(p As arb_t, a As arb_t, b As arb_t, lower_tail As Boolean, log As Boolean) As arb_t
        Dim result, pi As New arb_t
        Dim half = arb.t("0.5")
        pi = arb.const_pi()
        If p = half Then Return a
        If p < half Then Return a - b / arb.tan(pi * p) Else Return a - b / arb.tan(pi * (1 - p))
    End Function



    Function Arb_Exp_pdf(x As arb_t, lambda As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = lambda * arb.exp(-lambda * x)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Exp_CDF(x As arb_t, lambda As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = -arb.expm1(-x * lambda) Else result = arb.exp(-x * lambda)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Exp_ICDF(prob As arb_t, lambda As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, p As New arb_t
        If log_p Then p = arb.exp(prob) Else p = prob
        If lower_tail Then result = -arb.log1p(-p) / lambda Else result = -arb.log(p) / lambda
        Return result
    End Function


    Function Arb_Gumbel_pdf(x As arb_t, a As arb_t, b As arb_t, log_p As Boolean) As arb_t
        Dim result, c As New arb_t
        c = arb.exp(-(x - a) / b)
        result = c * arb.exp(-c) / b
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Gumbel_CDF(x As arb_t, a As arb_t, b As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, c As New arb_t
        c = arb.exp(-(x - a) / b)
        If lower_tail Then result = arb.exp(-c) Else result = -arb.expm1(-c)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Gumbel_ICDF(prob As arb_t, a As arb_t, b As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, p As New arb_t
        If log_p Then p = arb.exp(prob) Else p = prob
        If lower_tail Then result = a - arb.log(-arb.log(p)) * b Else result = a - arb.log(-arb.log1p(-p)) * b
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Geom_pdf(k As arb_t, p As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = p * arb.exp(k * arb.log1p(-p))
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Geom_CDF(k As arb_t, p As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = 1 - (1 - p) ^ (k + 1) Else result = arb.exp(arb.log1p(-p) * (k + 1))
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Geom_ICDF(prob As arb_t, p As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, prob1 As New arb_t
        If log_p Then prob1 = arb.exp(prob) Else prob1 = prob
        If lower_tail Then result = arb.log1p(-prob1) / arb.log1p(-p) - 1 Else result = arb.log(prob1) / arb.log1p(-p) - 1
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_InvGauss_pdf(x As arb_t, mu As arb_t, lambda As arb_t, log_p As Boolean) As arb_t
        Dim result, pi As New arb_t
        pi = arb.const_pi
        result = arb.sqrt(lambda / (2 * pi * x * x * x)) * arb.exp(-lambda * (x - mu) * (x - mu) / (2 * mu * mu * x))
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_InvGauss_CDF(x As arb_t, mean As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, cdf1, cdf2, cdf As New arb_t
        Dim n0, n1, n3, n4, expfactor As New arb_t
        n0 = arb.sqrt(scale / x)
        n0 *= ((x / mean) - 1)
        '        n1 = arb.ndist(n0)
        expfactor = arb.exp(2 * scale / mean)
        n3 = -arb.sqrt(scale / x)
        n3 *= (x / mean) + 1
        '        n4 = arb.ndist(n3)
        cdf = n1 + expfactor * n4

        '   normal_distribution<RealType> n01;
        '   RealType n0 = sqrt(scale / x);
        '   n0 *= ((x / mean) -1);
        '   RealType cdf_1 = cdf(complement(n01, n0));
        '
        '   RealType expfactor = exp(2 * scale / mean);
        '   RealType n3 = - sqrt(scale / x);
        '   n3 *= (x / mean) + 1;
        '
        '   //RealType n5 = +sqrt(scale/x) * ((x /mean) + 1); // note now positive sign.
        '   RealType n6 = cdf(complement(n01, +sqrt(scale/x) * ((x /mean) + 1)));
        '   // RealType n4 = cdf(n01, n3); // = 
        '   result = cdf_1 - expfactor * n6; 
        '   return result;


        If lower_tail Then result = cdf Else result = 1 - cdf
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Laplace_pdf(x As arb_t, location As arb_t, scale As arb_t, log_p As Boolean) As arb_t
        Dim result, exponent As New arb_t
        exponent = x - location
        If (exponent > 0) Then exponent = -exponent
        exponent /= scale
        result = arb.exp(exponent)
        result /= 2 * scale
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Laplace_CDF(x As arb_t, location As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, cdf1, cdf2 As New arb_t
        If (x < location) Then cdf1 = arb.exp((x - location) / scale) / 2 Else cdf1 = 1 - arb.exp((location - x) / scale) / 2
        If (-x < -location) Then cdf2 = arb.exp((-x + location) / scale) / 2 Else cdf2 = 1 - arb.exp((-location + x) / scale) / 2
        If lower_tail Then result = cdf1 Else result = cdf2
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Function Arb_Laplace_ICDF(prob As arb_t, location As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, prob1, q, ICDF1, ICDF2 As New arb_t
        If log_p Then prob1 = arb.exp(prob) Else prob1 = prob
        q = 1 - prob1
        If ((prob1 - 0.5) < 0) Then ICDF1 = location + scale * arb.log((prob1 * 2)) Else ICDF1 = location - scale * arb.log((-prob1 * 2 + 2))
        If ((0.5 - q) < 0) Then ICDF2 = location + scale * arb.log((-q * 2 + 2)) Else ICDF2 = location - scale * arb.log((q * 2))
        If lower_tail Then result = ICDF1 Else result = ICDF2
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Logistic_pdf(x As arb_t, location As arb_t, scale As arb_t, log_p As Boolean) As arb_t
        Dim result, c As New arb_t
        c = arb.exp(-(x - location) / scale)
        result = c / (scale * (1 + c) ^ 2)
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Logistic_CDF(x As arb_t, location As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = 1 / (1 + arb.exp(-(x - location) / scale)) Else result = 1 / (1 + arb.exp((x - location) / scale))
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Logistic_ICDF(prob As arb_t, location As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, prob1 As New arb_t
        If log_p Then prob1 = arb.exp(prob) Else prob1 = prob
        If lower_tail Then result = location - scale * arb.log(1 / (prob1 - 1)) Else result = location + scale * arb.log(prob1 / (1 - prob1))
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_LogNormal_pdf(x As arb_t, mu As arb_t, sigma As arb_t, log_p As Boolean) As arb_t
        Dim result, exponent, pi As New arb_t
        pi = arb.const_pi
        exponent = arb.log(x) - mu
        exponent *= -exponent
        exponent /= 2 * sigma * sigma
        result = arb.exp(exponent)
        result /= sigma * arb.sqrt(2 * pi) * x
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_LogNormal_CDF(x As arb_t, mu As arb_t, sigma As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = Arb_Normal_CDF(arb.log(x), mu, sigma, lower_tail, log_p)
        Return result
    End Function



    Function Arb_Normal_pdf(x As arb_t, mu As arb_t, sigma As arb_t, log_p As Boolean) As arb_t
        Dim result, exponent, pi As New arb_t
        result = arb.exp(-(x - mu) * (x - mu) / (2 * sigma * sigma)) / (sigma * arb.sqrt(2 * arb.const_pi))
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Normal_CDF(x As arb_t, mu As arb_t, sigma As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then
            result = 0.5 * arb.erfc(-(x - mu) / (sigma * arb.sqrt(2)))
        Else
            result = 0.5 * arb.erfc((x - mu) / (sigma * arb.sqrt(2)))
        End If
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Function Acb_Beta_pdf(x As acb_t, a As acb_t, b As acb_t, log_p As Boolean) As acb_t
        Dim result As New acb_t
        result = acb.ibeta_derivative(a, b, x)
        If log_p Then result = acb.log(result)
        Return result
    End Function



    Function Arb_Beta_pdf(x As arb_t, a As arb_t, b As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = arb.ibeta_derivative(a, b, x)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Beta_CDF(x As arb_t, a As arb_t, b As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = arb.ibeta(a, b, x) Else result = arb.ibetac(a, b, x)
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Function Arb_Binom_pdf(k As arb_t, n As arb_t, p As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = arb.ibeta_derivative(k + 1, n - k + 1, p) / (n + 1)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Binom_CDF(k As arb_t, n As arb_t, p As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = arb.ibetac(k + 1, n - k, p) Else result = arb.ibeta(k + 1, n - k, p)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_ChiSquare_pdf(x As arb_t, nu As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = arb.gamma_p_derivative(nu / 2, x / 2) / 2
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Function Acb_ChiSquare_pdf(x As acb_t, nu As acb_t, log_p As Boolean) As acb_t
        Dim result As New acb_t
        result = acb.gamma_p_derivative(nu / 2, x / 2) / 2
        If log_p Then result = acb.log(result)
        Return result
    End Function




    Function Arb_ChiSquare_CDF(x As arb_t, nu As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        ' Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
        If lower_tail Then result = arb.gamma_p(nu / 2, x / 2) Else result = arb.gamma_q(nu / 2, x / 2)
        If log_p Then result = arb.log(result)
        Return result
    End Function



    'Function Arb_ChiSquare_CDF(x As arb_t, nu As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
    '    Dim result As New arb_t
    '    ' Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
    '    Dim LeftTail As arb_t, RightTail As arb_t, density As arb_t
    '    cdis2(nu, x, LeftTail, RightTail, density)
    '    If lower_tail Then result = LeftTail Else result = RightTail
    '    If log_p Then result = arb.log(result)
    '    Return result
    'End Function



    Function Acb_F_pdf(x As acb_t, df1 As acb_t, df2 As acb_t, log_p As Boolean) As acb_t
        Dim result, v1x As New acb_t
        v1x = df1 * x
        If (acb.abs(v1x) > acb.abs(df2)) Then
            result = (df2 * df1) / ((df2 + v1x) * (df2 + v1x))
            result *= acb.ibeta_derivative(df2 / 2, df1 / 2, df2 / (df2 + v1x))
        Else
            result = df2 + df1 * x
            result = (result * df1 - x * df1 * df1) / (result * result)
            result *= acb.ibeta_derivative(df1 / 2, df2 / 2, v1x / (df2 + v1x))
        End If
        If log_p Then result = acb.log(result)
        Return result
    End Function


    Function Arb_F_pdf(x As arb_t, df1 As arb_t, df2 As arb_t, log_p As Boolean) As arb_t
        Dim result, v1x As New arb_t
        v1x = df1 * x
        If (arb.abs(v1x) > arb.abs(df2)) Then
            result = (df2 * df1) / ((df2 + v1x) * (df2 + v1x))
            result *= arb.ibeta_derivative(df2 / 2, df1 / 2, df2 / (df2 + v1x))
        Else
            result = df2 + df1 * x
            result = (result * df1 - x * df1 * df1) / (result * result)
            result *= arb.ibeta_derivative(df1 / 2, df2 / 2, v1x / (df2 + v1x))
        End If
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_F_CDF(x As arb_t, df1 As arb_t, df2 As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, v1x, cdf1, cdf2 As New arb_t
        ' Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
        v1x = df1 * x
        If (v1x > df2) Then
            cdf1 = arb.ibetac(df2 / 2, df1 / 2, df2 / (df2 + v1x))
        Else
            cdf1 = arb.ibeta(df1 / 2, df2 / 2, v1x / (df2 + v1x))
        End If

        If (v1x > df2) Then
            cdf2 = arb.ibeta(df2 / 2, df1 / 2, df2 / (df2 + v1x))
        Else
            cdf2 = arb.ibetac(df1 / 2, df2 / 2, v1x / (df2 + v1x))
        End If

        If lower_tail Then result = cdf1 Else result = cdf2
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Function Arb_Gamma_pdf(x As arb_t, k As arb_t, theta As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = arb.gamma_p_derivative(k, x / theta) / theta
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Gamma_CDF(x As arb_t, k As arb_t, theta As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = arb.gamma_p(k, x / theta) Else result = arb.gamma_q(k, x / theta)
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Function Arb_Invchisq_pdf(x As arb_t, df As arb_t, scale As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = df * scale / 2 / x
        result = arb.gamma_p_derivative(df / 2, result) * df * scale / 2
        result /= (x * x)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Invchisq_CDF(x As arb_t, df As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = arb.gamma_q(df / 2, (df * (scale / 2)) / x) Else result = arb.gamma_p(df / 2, (df * scale / 2) / x)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_InvGamma_pdf(x As arb_t, shape As arb_t, scale As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = (arb.pow(scale, shape) * arb.pow(x, (-shape - 1)) * arb.exp(-scale / x)) / arb.gamma(shape)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_InvGamma_CDF(x As arb_t, shape As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = arb.gamma_q(shape, scale / x) Else result = arb.gamma_p(shape, scale / x)
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Function Arb_Nbinom_pdf(k As arb_t, r As arb_t, p As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = (p / (r + k)) * arb.ibeta_derivative(r, (k + 1), p)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Nbinom_CDF(k As arb_t, r As arb_t, p As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = arb.ibeta(r, (k + 1), p) Else result = arb.ibetac(r, (k + 1), p)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_T_pdf(x As arb_t, df As arb_t, log_p As Boolean) As arb_t
        Dim result, basem1 As New arb_t
        Dim E8 = arb.t(0.125)
        basem1 = x * x / df
        If (basem1 < E8) Then
            result = arb.exp(-arb.log1p(basem1) * (1 + df) / 2)
        Else
            result = arb.pow(1 / (1 + basem1), (df + 1) / 2)
        End If
        result /= arb.sqrt(df) * arb.beta(df / 2, 0.5)

        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_T_CDF(x As arb_t, df As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, x2, z, probability, cdf1, cdf2 As New arb_t

        x2 = x * x
        If (df > 2 * x2) Then
            z = x2 / (df + x2)
            probability = arb.ibetac(0.5, df / 2, z) / 2
        Else
            z = df / (df + x2)
            probability = arb.ibeta(df / 2, 0.5, z) / 2
        End If
        If (x > 0) Then cdf1 = 1 - probability Else cdf1 = probability
        If (x > 0) Then cdf2 = probability Else cdf2 = 1 - probability

        If lower_tail Then result = cdf1 Else result = cdf2
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Pareto_pdf(x As arb_t, scale As arb_t, shape As arb_t, log_p As Boolean) As arb_t
        Dim result, c As New arb_t
        If (x < scale) Then result = 0 Else result = shape * arb.pow(scale, shape) / arb.pow(x, shape + 1)
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Pareto_CDF(x As arb_t, scale As arb_t, shape As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = 1 - (scale / x) ^ shape Else result = (scale / x) ^ shape
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Pareto_ICDF(prob As arb_t, scale As arb_t, shape As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, prob1 As New arb_t
        If log_p Then prob1 = arb.exp(prob) Else prob1 = prob
        If lower_tail Then result = scale / (1 - prob1) ^ (1 / shape) Else result = scale / (1 - prob1) ^ (1 / shape)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Poisson_pdf(k As arb_t, mean As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        result = arb.gamma_p_derivative(k + 1, mean)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Poisson_CDF(k As arb_t, mean As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = arb.gamma_q(k + 1, mean) Else result = arb.gamma_p(k + 1, mean)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_RayLeigh_pdf(x As arb_t, sigma As arb_t, log_p As Boolean) As arb_t
        Dim result, sigmasqr As New arb_t
        sigmasqr = sigma * sigma
        result = x * (arb.exp(-(x * x) / (2 * sigmasqr))) / sigmasqr
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_RayLeigh_CDF(x As arb_t, sigma As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = arb.expm1(-x * x / (2 * sigma * sigma)) Else result = arb.exp(-(x * x) / (2 * sigma * sigma))
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_RayLeigh_ICDF(prob As arb_t, sigma As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, prob1 As New arb_t
        If log_p Then prob1 = arb.exp(prob) Else prob1 = prob
        If lower_tail Then result = arb.sqrt(-2 * sigma * sigma * arb.log1p(-prob1)) Else result = arb.sqrt(-2 * sigma * sigma * arb.log(1 - prob1))
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Function Arb_Weibull_pdf(x As arb_t, shape As arb_t, scale As arb_t, log_p As Boolean) As arb_t
        Dim result, c As New arb_t
        result = arb.exp(-arb.pow(x / scale, shape))
        result *= arb.pow(x / scale, shape - 1) * shape / scale
        If log_p Then result = arb.log(result)
        Return result
    End Function



    Function Arb_Weibull_CDF(x As arb_t, shape As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If lower_tail Then result = -arb.expm1(-arb.pow(x / scale, shape)) Else result = arb.exp(-arb.pow(x / scale, shape))
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Weibull_ICDF(prob As arb_t, shape As arb_t, scale As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, prob1 As New arb_t
        If log_p Then prob1 = arb.exp(prob) Else prob1 = prob
        If lower_tail Then result = scale * arb.pow(-arb.log1p(-prob1), 1 / shape) Else result = scale * arb.pow(-arb.log(1 - prob1), 1 / shape)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Uniform_pdf(x As arb_t, lower As arb_t, upper As arb_t, log_p As Boolean) As arb_t
        Dim result As New arb_t
        If ((x < lower) Or (x > upper)) Then result = 0 Else result = 1 / (upper - lower)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Uniform_CDF(x As arb_t, lower As arb_t, upper As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, cdf1, cdf2 As New arb_t
        If ((x < lower) Or (x > upper)) Then
            If (x < lower) Then
                cdf1 = 0 : cdf2 = 1
            Else
                cdf1 = 1 : cdf2 = 0
            End If
        Else
            cdf1 = (x - lower) / (upper - lower)
            cdf2 = (upper - x) / (upper - lower)
        End If
        If lower_tail Then result = cdf1 Else result = cdf2
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Function Arb_Uniform_ICDF(prob As arb_t, lower As arb_t, upper As arb_t, lower_tail As Boolean, log_p As Boolean) As arb_t
        Dim result, prob1, icdf1, icdf2 As New arb_t
        If log_p Then prob1 = arb.exp(prob) Else prob1 = prob
        If ((prob1 = 0) Or (prob1 = 0)) Then
            If (prob1 = 0) Then
                icdf1 = lower : icdf2 = upper
            Else
                icdf1 = upper : icdf2 = lower
            End If
        Else
            icdf1 = prob1 * (upper - lower) + lower
            icdf2 = -(1 - prob1) * (upper - lower) + upper
        End If
        If lower_tail Then result = icdf1 Else result = icdf2
        If log_p Then result = arb.log(result)
        Return result
    End Function

    Function Acb_GammaStar(t As acb_t, nu As acb_t, z As acb_t) As acb_t
        Dim d, c, result As New acb_t
        c = (z ^ nu) / acb.gamma(nu)
        d = t ^ (nu - 1) * acb.exp(-z * t)
        result = c * d
        Return result
    End Function


    Function Acb_GammaStar2(t As acb_t, nu As acb_t, z As acb_t, a As acb_t) As acb_t
        Dim d, c, result As New acb_t
        c = (z ^ nu) / acb.gamma(nu)
        d = acb.exp(-z * t)
        result = c * d
        Return result
    End Function


    Function AcbIntegrand_NC(x As acb_t, ByVal params2 As acb_mat_t) As acb_t
        Dim proc_outer As Int32 = AcbParamsNC(mp_proc_outer_pos).real.ToInt32
        Dim fx As New acb_t
        Dim df1 = AcbParamsNC(mp_df1_pos)
        Dim df2 = AcbParamsNC(mp_df2_pos)
        Dim nc = AcbParamsNC(mp_nc_pos)
        Select Case proc_outer
            Case mp_integral_chisquare_nc : fx = Acb_ChiSquare_NC_pdf(x, df1, nc, False)
            Case mp_integral_chisquare : fx = Acb_ChiSquare_pdf(x, df1, False)
            Case mp_integral_gammastar : fx = Acb_GammaStar(x, df1, df2)
            Case mp_integral_gammastar2 : fx = Acb_GammaStar2(x, df1, df2, nc)
            Case mp_integral_t_nc : fx = Acb_T_NC_pdf(x, df1, nc, False)
            Case mp_integral_f_nc : fx = Acb_F_NC_pdf(x, df1, df2, nc, False)
            Case mp_integral_beta_nc : fx = Acb_Beta_NC_pdf(x, df1, df2, nc, False)
            Case mp_integral_rho : fx = Acb_Rho_pdf(df1.real.ToInt32, x, nc)
            Case mp_integral_rho2 : fx = Acb_Rho2_pdf(x, df1, df2, nc, False)
            Case Else : Console.WriteLine("!!!! Error AcbIntegrand_NC !!!!!)") : fx = acb.nan()
        End Select
        '        Console.WriteLine("fx: {0}", fx)
        Return fx
    End Function

#If Win64 Then
    Sub WrapperParams_GL_NC(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt64, ByVal prec As UInt64)
#Else
    Sub WrapperParams_GL_NC(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt32, ByVal prec As UInt32)
#End If
        Dim old_prec = mp4.getprec()
        'Console.WriteLine("In WrapperParams_GL_Outer: order: {0}, prec: {1}, paramsPtr: {2}", order, prec, paramsPtr)
        mp4.setprec(CUInt(prec))
        Dim x As New acb_t(xPtr, True)
        Dim fx As New acb_t()
        fx = AcbIntegrand_NC(x, Nothing)
        fx.CopyToPtr(fxPtr)
        mp4.setprec(old_prec)
    End Sub


    Sub DemoAcbIntegrationChiSquare()
        mp4.setprec(400)
        AcbParamsNC(0) = mp_integral_chisquare
        Dim x = 5000000 - 0
        Dim nu = 5000000
        Dim lambda = 0
        Dim result = xrf.dist_pchisq(x, nu, True)
        Console.WriteLine("    result: {0}", result)


        AcbParamsNC(mp_df1_pos) = nu
        AcbParamsNC(mp_nc_pos) = 0
        'Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        Dim a = arb.t(0)
        Dim b = arb.t(x)
        'Dim rel_goal As UInt32 = workingprec
        'Dim abs_tol_bits As UInt32 = workingprec
        Dim rel_goal As UInt32 = 150
        Dim abs_tol_bits As UInt32 = 150
        Dim eval_limit As UInt32 = 0
        Dim s = acb.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
        'Dim alpha = 1
        'Dim beta = 1
        'Dim epsabsStart = arb.t("1.0E-15")
        'epsabsStart = epsabsStart * result
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)
    End Sub

    Sub DemoAcbIntegrationGammaStar()
        mp4.setprec(400)
        AcbParamsNC(0) = mp_integral_gammastar
        Dim z = 49999
        Dim nu = 50000
        Dim lambda = 0
        Dim result As New arb_t
        'Dim result = xrf.dist_pchisq(X, nu, True)
        'Console.WriteLine("    result: {0}", result)


        AcbParamsNC(mp_df1_pos) = nu
        AcbParamsNC(mp_df2_pos) = z
        'Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 1
        Dim a = 0.0
        Dim b = 1.0
        'Dim rel_goal As UInt32 = workingprec
        'Dim abs_tol_bits As UInt32 = workingprec
        Dim rel_goal As UInt32 = 153
        Dim abs_tol_bits As UInt32 = 153
        Dim eval_limit As UInt32 = 0
        Dim s = acb.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)


        'Dim alpha = 0.999
        'Dim beta = 1.0
        'a = 0.95
        'b = 1.0
        'Dim epsabsStart = arb.t("1.0E-15")
        'epsabsStart = epsabsStart '* result
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)

        'a = 0.8
        'b = 0.9
        'epsabsStart = epsabsStart '* result
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)

        'a = 0.9
        'b = 1.0
        'epsabsStart = epsabsStart '* result
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)


        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, 0, 0.5, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)

        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, 0.5, 1.0, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)


        'AcbParamsNC(0) = mp_integral_gammastar2
        'a = 0.0
        'b = 1.0
        'AcbParamsNC(mp_nc_pos) = a
        'alpha = nu
        'beta = 1
        'epsabsStart = arb.t("1.0E-15")
        'epsabsStart = epsabsStart '* result
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)

        'a = 0.0
        'b = 0.5
        'AcbParamsNC(mp_nc_pos) = a
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)

        'a = 0.5
        'b = 1.0
        'AcbParamsNC(mp_nc_pos) = a
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)

    End Sub


    Sub DemoAcbIntegrationChiSquareNC()
        mp4.setprec(100)
        AcbParamsNC(0) = mp_integral_chisquare_nc
        Dim x = 1050
        Dim nu = 80
        Dim lambda = 850
        Dim result = xrf.dist_pchisq_nc(x, nu, lambda, True)
        Console.WriteLine("    result: {0}", result)


        AcbParamsNC(mp_df1_pos) = nu
        AcbParamsNC(mp_nc_pos) = lambda
        'Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        Dim a = arb.t(899)
        Dim b = arb.t(x)
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        'Dim s = acb.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)
        Dim alpha = 1
        Dim beta = 1
        Dim epsabsStart = arb.t("1.0E-15")
        epsabsStart = epsabsStart * result.value
        DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        Console.WriteLine("result:{0}", result)
    End Sub


    Function Includesmode(ByVal x As acb_t, ByVal nu As acb_t, ByVal lambda As acb_t) As Boolean
        If ((x.real.Infimum < lambda.real.Infimum) And (x.real.Supremum > lambda.real.Supremum)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function Acb_ChiSquare_NC_pdf(ByVal x As acb_t, ByVal nu As acb_t, ByVal lambda As acb_t, ByVal log_p As Boolean) As acb_t
        Dim order As Int32 = AcbParamsNC(mp_order).real.ToInt32
        Console.WriteLine("Order: {0}", order)
        If (order = 1) Then
            If Includesmode(x, nu, lambda) Then
                Return acb.nan()
            Else
                Dim x1 As New acb_t
                x1 = x
                Dim x1_re, x1_im, av1 As New arb_t
                x1_re.mid = x.real.Supremum
                x1_re.rad = 0
                x1_im.mid = x.imag.Supremum
                x1_im.rad = 0
                x1.real = x1_re
                x1.imag = x1_im
                Dim dens0 = Acb_ChiSquare_pdf(x1, nu, False)
                Dim hyper = acb.hyp0f1(nu / 2, lambda * x1 / 4)
                Dim result = dens0 * acb.exp(-lambda / 2) * hyper
                If log_p Then result = acb.log(result)
                Return result
            End If
        Else
            Dim dens0 = Acb_ChiSquare_pdf(x, nu, False)
            Dim hyper = acb.hyp0f1(nu / 2, lambda * x / 4)
            Dim result = dens0 * acb.exp(-lambda / 2) * hyper
            If log_p Then result = acb.log(result)
            Return result
        End If

    End Function


    Function Arb_ChiSquare_NC_pdf(x As arb_t, nu As arb_t, lambda As arb_t, log_p As Boolean) As arb_t
        Dim dens0 = Arb_ChiSquare_pdf(x, nu, False)
        Dim hyper = arb.hyp0f1(nu / 2, lambda * x / 4)
        Dim result = dens0 * arb.exp(-lambda / 2) * hyper
        If log_p Then result = arb.log(result)
        Return result
    End Function

    Sub DemoChiSquareDensity()
        Dim x, nu, lambda, result, dens0, hyper As New arb_t
        x = 12
        nu = 10
        lambda = 3
        result = xrf.dist_dchisq_nc(x.ToDouble, nu.ToDouble, lambda.ToDouble)
        Console.WriteLine("   result: {0}", result)
        result = Arb_ChiSquare_NC_pdf(x, nu, lambda, False)
        Console.WriteLine("   result: {0}", result)
        Dim resultc = Acb_ChiSquare_NC_pdf(x, nu, lambda, False)
        Console.WriteLine("   resultc: {0}", resultc)
    End Sub



    Sub DemoAcbIntegrationTNC()
        mp4.setprec(100)
        AcbParamsNC(0) = mp_integral_t_nc
        Dim x = 4
        Dim nu = 20
        Dim lambda = 5
        AcbParamsNC(mp_df1_pos) = nu
        AcbParamsNC(mp_nc_pos) = lambda
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = 0
        b = x
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
        Dim resultint = NdisAcb(-lambda) + s
        Console.WriteLine("resultint:{0}", resultint)
        Dim result = xrf.dist_pt_nc(x, nu, lambda, True)
        Console.WriteLine("    result: {0}", result)
    End Sub


    Function Acb_T_NC_pdf(x As acb_t, n As acb_t, delta As acb_t, log_p As Boolean) As acb_t
        Dim m = n / 2
        Dim a = n + x * x
        Dim d2 = delta * delta
        Dim y2 = d2 * x * x / (2 * a)
        Dim K1 = (n ^ m * acb.gamma(n + 1) * acb.exp(-0.5 * d2)) / (2 ^ n * a ^ m * acb.gamma(m))
        Dim LSide = (acb.sqrt(2) * delta * x * acb.hyp1f1(m + 1, 3 / 2, y2)) / (a * acb.gamma(m + 0.5))
        Dim RSide = acb.hyp1f1(m + 0.5, 0.5, y2) / (acb.sqrt(a) * acb.gamma(m + 1))
        Dim sum = LSide + RSide
        Dim result = K1 * (sum)
        'Console.WriteLine("result from Acb_T_NC_pdf: ", result)
        If log_p Then result = acb.log(result)
        Return result
    End Function


    Function Arb_T_NC_pdf(x As arb_t, n As arb_t, delta As arb_t, log_p As Boolean) As arb_t
        Dim m = n / 2
        Dim a = n + x * x
        Dim d2 = delta * delta
        Dim y2 = d2 * x * x / (2 * a)
        Dim K1 = (n ^ m * arb.gamma(n + 1) * arb.exp(-0.5 * d2)) / (2 ^ n * a ^ m * arb.gamma(m))
        Dim LSide = (arb.sqrt(2) * delta * x * arb.hyp1f1(m + 1, 3 / 2, y2)) / (a * arb.gamma(m + 0.5))
        Dim RSide = arb.hyp1f1(m + 0.5, 0.5, y2) / (arb.sqrt(a) * arb.gamma(m + 1))
        Dim sum = LSide + RSide
        Dim result = K1 * (sum)
        If log_p Then result = arb.log(result)
        Return result
    End Function


    Sub DemoTDensity()
        mp4.setdps(100)
        Dim x, n, delta, result As New arb_t
        Dim arbresult As New arb_t
        x = 4
        n = 13
        delta = 10
        result = xrf.dist_dt_nc(x.ToDouble, n.ToDouble, delta.ToDouble)
        Console.WriteLine("   result: {0}", result)
        result = Arb_T_NC_pdf(x, n, delta, False)
        Console.WriteLine("   result: {0}", result)
        Dim resultc = Acb_T_NC_pdf(x, n, delta, False)
        Console.WriteLine("   resultc: {0}", resultc)
    End Sub



    Sub DemoAcbIntegrationFNC()
        mp4.setprec(100)
        AcbParamsNC(0) = mp_integral_f_nc
        Dim x = 3
        Dim m = 10
        Dim n = 20
        Dim lambda = 15
        AcbParamsNC(mp_df1_pos) = m
        AcbParamsNC(mp_df2_pos) = n
        AcbParamsNC(mp_nc_pos) = lambda
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = 0
        b = x
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
        Dim result = xrf.dist_pf_nc(x, m, n, lambda, True)
        Console.WriteLine("    result: {0}", result)
    End Sub





    Function Acb_F_NC_pdf(x As acb_t, m As acb_t, n As acb_t, lambda As acb_t, log_p As Boolean) As acb_t
        Dim dens0 = Acb_F_pdf(x, m, n, False)
        Dim hyper = acb.hyp1f1(0.5 * (m + n), 0.5 * m, (m * x * lambda) / (2 * (n + m * x)))
        Dim result = dens0 * acb.exp(-lambda / 2) * hyper
        'Console.WriteLine("result from Acb_F_NC_pdf: {0}", result)

        If log_p Then result = acb.log(result)
        Return result
    End Function


    Function Arb_F_NC_pdf(x As arb_t, m As arb_t, n As arb_t, lambda As arb_t, log_p As Boolean) As arb_t
        Dim dens0 = Arb_F_pdf(x, m, n, False)
        Dim hyper = arb.hyp1f1(0.5 * (m + n), 0.5 * m, (m * x * lambda) / (2 * (n + m * x)))
        Dim result = dens0 * arb.exp(-lambda / 2) * hyper
        If log_p Then result = arb.log(result)
        Return result
    End Function

    Sub DemoFDensity()
        Dim x, m, n, lambda, result As New arb_t
        Dim arbresult, dens0, hyper As New arb_t
        x = 2
        m = 10
        n = 20
        lambda = 3
        result = xrf.dist_df_nc(x.ToDouble, m.ToDouble, n.ToDouble, lambda.ToDouble)
        Console.WriteLine("   result: {0}", result)
        result = Arb_F_NC_pdf(x, m, n, lambda, False)
        Console.WriteLine("   result: {0}", result)
        Dim resultc = Acb_F_NC_pdf(x, m, n, lambda, False)
        Console.WriteLine("   resultc: {0}", resultc)
    End Sub




    Sub DemoAcbIntegrationBetaNC()
        mp4.setprec(100)
        AcbParamsNC(0) = mp_integral_beta_nc
        Dim x = 0.5
        Dim alpha = 10
        Dim beta = 20
        Dim lambda = 30
        AcbParamsNC(mp_df1_pos) = alpha
        AcbParamsNC(mp_df2_pos) = beta
        AcbParamsNC(mp_nc_pos) = lambda
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = 0
        b = x
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
        Dim result = xrf.dist_pbeta_nc(x, alpha, beta, lambda, True)
        Console.WriteLine("    result: {0}", result)
    End Sub


    Function Acb_Beta_NC_pdf(x As acb_t, a As acb_t, b As acb_t, lambda As acb_t, log_p As Boolean) As acb_t
        Dim dens0 = Acb_Beta_pdf(x, a, b, False)
        Dim hyper = acb.hyp1f1(a + b, a, (x * lambda) / 2)
        Dim result = dens0 * acb.exp(-lambda / 2) * hyper
        'Console.WriteLine("result from Acb_F_NC_pdf: {0}", result)

        If log_p Then result = acb.log(result)
        Return result
    End Function


    Function Arb_Beta_NC_pdf(x As arb_t, a As arb_t, b As arb_t, lambda As arb_t, log_p As Boolean) As arb_t
        Dim dens0 = Arb_Beta_pdf(x, a, b, False)
        Dim hyper = arb.hyp1f1(a + b, a, (x * lambda) / 2)
        Dim result = dens0 * arb.exp(-lambda / 2) * hyper
        If log_p Then result = arb.log(result)
        Return result
    End Function




    Sub DemoBetaDensity()
        Dim x, a, b, lambda, result As New arb_t
        Dim arbresult, dens0, hyper As New arb_t
        x = 0.5
        a = 10
        b = 20
        lambda = 3
        result = xrf.dist_dbeta_nc(x.ToDouble, a.ToDouble, b.ToDouble, lambda.ToDouble)
        Console.WriteLine("   result: {0}", result)
        result = Arb_Beta_NC_pdf(x, a, b, lambda, False)
        Console.WriteLine("   result: {0}", result)
        Dim resultc = Acb_Beta_NC_pdf(x, a, b, lambda, False)
        Console.WriteLine("   resultc: {0}", resultc)
    End Sub



    Sub DemoAcbIntegrationRho()
        mp4.setprec(100)
        AcbParamsNC(0) = mp_integral_rho
        Dim r = 0.9
        Dim N = 25  ' 35 already crashes
        Dim rho = 0.9
        AcbParamsNC(mp_df1_pos) = N
        AcbParamsNC(mp_nc_pos) = rho
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = 0
        b = r
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
        Dim Pr0 = arb.ibeta(0.5, 0.5 * (N - 1), rho * rho)
        Pr0 = 0.5 * (1 + Math.Sign(rho) * Pr0)
        Dim resultint = 1 - (Pr0 - s)
        Console.WriteLine("resultint:{0}", resultint)
        Dim result = RhoExplicit_Arb(N, r, rho)
        Console.WriteLine("   result: {0}", result)
        Dim LeftTail, RightTail As Double
        RhoDisN_Guenther(N, r, rho, LeftTail, RightTail)
        Console.WriteLine("LeftTail:   {0}, RightTail: {1}", LeftTail, RightTail)

    End Sub


    Function Acb_Rho_pdf(ByVal n As Long, ByVal r As acb_t, ByVal rho As acb_t) As acb_t
        Dim w As acb_t, t As acb_t
        Dim x As acb_t, x2 As acb_t, r2 As acb_t, Rho2 As acb_t, U As acb_t, k1 As acb_t
        Dim A2 As acb_t, a As acb_t, c2 As acb_t, C As acb_t, b2 As acb_t, b As acb_t
        Dim ACTerm As acb_t, density As acb_t
        r2 = r * r : Rho2 = rho * rho
        x = r * rho : x2 = x * x : w = 0.5 * (1 + x)
        A2 = 1 - Rho2 : a = acb.sqrt(A2)
        c2 = 1 - r2 : C = acb.sqrt(c2)
        b2 = 1 - x2 : b = acb.sqrt(b2)
        U = acb.acos(-x) / b
        k1 = ((n - 2) / acb.sqrt(2 * arb.const_pi())) * acb.exp(acb.lgamma(n - 1) - acb.lgamma(n - 0.5))
        ACTerm = acb.exp(acb.log(a) * (n - 1) + acb.log(C) * (n - 4) + acb.log(1 - x) * (1.5 - n))
        t = acb.hyp2f1(0.5, 0.5, n - 0.5, w)
        density = k1 * ACTerm * t
        Return density
    End Function

    Function Arb_Rho_pdf(ByVal n As Long, ByVal r As arb_t, ByVal rho As arb_t) As arb_t
        Dim w As arb_t, t As arb_t
        Dim x As arb_t, x2 As arb_t, r2 As arb_t, Rho2 As arb_t, U As arb_t, k1 As arb_t
        Dim A2 As arb_t, a As arb_t, c2 As arb_t, C As arb_t, b2 As arb_t, b As arb_t
        Dim ACTerm As arb_t, density As arb_t
        r2 = r * r : Rho2 = rho * rho
        x = r * rho : x2 = x * x : w = 0.5 * (1 + x)
        A2 = 1 - Rho2 : a = arb.sqrt(A2)
        c2 = 1 - r2 : C = arb.sqrt(c2)
        b2 = 1 - x2 : b = arb.sqrt(b2)
        U = arb.acos(-x) / b
        k1 = ((n - 2) / arb.sqrt(2 * arb.const_pi())) * arb.exp(arb.lgamma(n - 1) - arb.lgamma(n - 0.5))
        ACTerm = arb.exp(arb.log(a) * (n - 1) + arb.log(C) * (n - 4) + arb.log(1 - x) * (1.5 - n))
        t = arb.hyp2f1(0.5, 0.5, n - 0.5, w)
        density = k1 * ACTerm * t
        Return density
    End Function

    Sub DemoPearsonRhoDensity()
        Dim n As Long
        Dim r, rho, result As New arb_t
        n = 10
        r = 0.5
        rho = 0.25
        result = arb.t(RhoDensity_2(n, r.ToDouble, rho.ToDouble))
        Console.WriteLine("     result: {0}", result)
        result = Arb_Rho_pdf(n, r, rho)
        Console.WriteLine("     result: {0}", result)
        Dim resultc = Acb_Rho_pdf(n, r, rho)
        Console.WriteLine("   resultc: {0}", resultc)
        Dim resultd = RhoDensityDirect(n, r, rho)
        Console.WriteLine("    resultd: {0}", resultd)
        Dim resulte = Acb_RhoDensityDirect(n, r, rho)
        Console.WriteLine("   resulte: {0}", resulte)
    End Sub



    Sub DemoAcbIntegrationRho2()
        mp4.setprec(100)
        AcbParamsNC(0) = mp_integral_rho2
        Dim R2 = 0.41
        Dim p = 4
        Dim N = 100  ' crashes for 1000
        Dim Rho2 = 0.3
        AcbParamsNC(mp_df1_pos) = p
        AcbParamsNC(mp_df2_pos) = N
        AcbParamsNC(mp_nc_pos) = Rho2
        Dim s, a, b As New acb_t
        Dim workingprec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = 0
        b = R2
        Dim rel_goal As UInt32 = workingprec
        Dim abs_tol_bits As UInt32 = workingprec
        Dim eval_limit As UInt32 = 0
        s = acb.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workingprec, verbose, rel_goal, abs_tol_bits, eval_limit)
        Console.WriteLine("Integral: {0}", s)
        Dim result = Rho2DisN8(False, p, N, R2, Rho2)
        Console.WriteLine("    result: {0}", result)
    End Sub

    Function Acb_Rho2_pdf(x As acb_t, p As acb_t, N As acb_t, rho2 As acb_t, log_p As Boolean) As acb_t
        'see Gurland 1968
        Dim PP = p + 1
        Dim NN = N + p + 1
        Dim n1 = NN - 1
        Dim dens0 = Acb_Beta_pdf(x, 0.5 * (PP - 1), 0.5 * (NN - PP), False)
        Dim hyper = acb.hyp2f1(0.5 * n1, 0.5 * n1, 0.5 * (PP - 1), rho2 * x)
        Dim result = dens0 * (1 - rho2) ^ (n1 / 2) * hyper
        If log_p Then result = acb.log(result)
        Return result
    End Function


    Function Arb_Rho2_pdf(x As arb_t, p As arb_t, N As arb_t, rho2 As arb_t, log_p As Boolean) As arb_t
        'see Gurland 1968
        Dim PP = p + 1
        Dim NN = N + p + 1
        Dim n1 = NN - 1
        Dim dens0 = Arb_Beta_pdf(x, 0.5 * (PP - 1), 0.5 * (NN - PP), False)
        Dim hyper = arb.hyp2f1(0.5 * n1, 0.5 * n1, 0.5 * (PP - 1), rho2 * x)
        Dim result = dens0 * (1 - rho2) ^ (n1 / 2) * hyper
        If log_p Then result = arb.log(result)
        Return result
    End Function

    Sub DemoR2Density()
        Dim result1d, result2d As Double
        Dim p, n As Double
        Dim x, rho2, result1, result2, xdiff, dens As New arb_t
        p = 11
        n = 20
        x = 0.125
        rho2 = 0.25
        xdiff = 0.000001
        result1d = Rho2DisN8(False, p, n, x.ToDouble, rho2.ToDouble)
        'Console.WriteLine("   result1: {0}", result1)
        result2d = Rho2DisN8(False, p, n, x.ToDouble + xdiff.ToDouble, rho2.ToDouble)
        'Console.WriteLine("   result2: {0}", result2)
        dens = (result2d - result1d) / xdiff
        Console.WriteLine("     dens: {0}", dens)

        Dim result = Arb_Rho2_pdf(x, p, n, rho2, False)
        Console.WriteLine("   result: {0}", result)
        Dim resultc = Acb_Rho2_pdf(x, p, n, rho2, False)
        Console.WriteLine("   resultc: {0}", resultc)
    End Sub


    Public Sub DemoNoncentralPdf()
        DemoChiSquareDensity()
        'DemoTDensity()
        'DemoFDensity()
        'DemoBetaDensity()
        'DemoPearsonRhoDensity()
        'DemoR2Density()
    End Sub

    Public Sub DemoNoncentralCDF()
        DemoAcbIntegrationChiSquare()
        'DemoAcbIntegrationChiSquareNC()
        'DemoAcbIntegrationTNC()
        'DemoAcbIntegrationFNC()
        'DemoAcbIntegrationBetaNC()
        'DemoAcbIntegrationRho()
        'DemoAcbIntegrationRho2()
    End Sub


    Public Sub DemoDistFromBoost()
        mp4.setdps(30)
        Dim x, y, a, b As Double
        a = 12
        x = 13.125
        Console.WriteLine("arb.gamma_p_derivative:   {0}", arb.gamma_p_derivative(a, x))
        Console.WriteLine("boost.gamma_p_derivative:  {0}", xrf.gamma_p_derivative(a, x))

        Console.WriteLine("gamma_lower_r: {0}", arb.gamma_lower_r(a, x))
        Console.WriteLine("boost.gamma_p:  {0}", xrf.gamma_lower_r(a, x))
        Console.WriteLine("gamma_upper_r: {0}", arb.gamma_upper_r(a, x))
        Console.WriteLine("boost.gamma_q:  {0}", xrf.gamma_upper_r(a, x))
        Console.WriteLine("")

        x = 0.25
        y = 1 - x
        a = 12
        b = 23

        Console.WriteLine("beta:        {0}", arb.beta(a, b))
        Console.WriteLine("boost.beta:   {0}", xrf.beta(a, b))
        Console.WriteLine("arb.ibeta_derivative:   {0}", arb.ibeta_derivative(a, b, x))
        Console.WriteLine("boost.ibeta_derivative:  {0}", xrf.ibeta_derivative(a, b, x))
        Console.WriteLine("arb.ibeta:   {0}", arb.ibeta(a, b, x))
        Console.WriteLine("boost.ibeta:  {0}", xrf.ibeta(a, b, x))
        Console.WriteLine("arb.ibetac:  {0}", arb.ibetac(a, b, x))
        Console.WriteLine("boost.ibetac: {0}", xrf.ibetac(a, b, x))
        Console.WriteLine("")

        Console.WriteLine("dbeta(x=0.77, a=10.6, b=1.8):  {0}", xrf.dist_dbeta(0.5, 10.6, 1.8, False))
        Console.WriteLine("dbeta(x=0.77, a=10.6, b=1.8): {0}", Arb_Beta_pdf(0.5, 10.6, 1.8, False))
        Console.WriteLine("pbeta(x=0.77, a=10.6, b=1.8):  {0}", xrf.dist_pbeta(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("pbeta(x=0.77, a=10.6, b=1.8): {0}", Arb_Beta_CDF(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("qbeta(p=0.5, a=10.6, b=1.8): {0}", xrf.dist_qbeta(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("")

        Console.WriteLine("dbinom(k=7, n=11, p=0.1):  {0}", xrf.dist_dbinom(7, 11, 0.125, False))
        Console.WriteLine("dbinom(k=7, n=11, p=0.1): {0}", Arb_Binom_pdf(7, 11, 0.125, False))
        Console.WriteLine("pbinom(k=7, n=11, p=0.1):  {0}", xrf.dist_pbinom(7, 11, 0.125, False, False))
        Console.WriteLine("pbinom(k=7, n=11, p=0.1): {0}", Arb_Binom_CDF(7, 11, 0.125, False, False))
        Console.WriteLine("qbinom(p=0.5, size=11, prob=0.1): {0}", xrf.dist_qbinom(0.5, 11, 0.4, False, False))
        Console.WriteLine("")

        Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5):  {0}", xrf.dist_dcauchy(10.2, 0.0, 0.5, False))
        Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5): {0}", Arb_Cauchy_pdf(10.2, 0.0, 0.5, False))
        Console.WriteLine("pcauchy(x=10.2, a=0.0, b=0.5):  {0}", xrf.dist_pcauchy(10.2, 0.0, 0.5, False, False))
        Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5): {0}", Arb_Cauchy_CDF(10.2, 0.0, 0.5, False, False))
        Console.WriteLine("qcauchy(p=0.75, a=10.125, b=0.5): {0}", xrf.dist_qcauchy(0.75, 10.125, 0.5, False, False))
        Console.WriteLine("dcauchy(p=0.75, a=10.125, b=0.5): {0}", Arb_Cauchy_ICDF(0.75, 10.125, 0.5, False, False))
        Console.WriteLine("")

        Console.WriteLine("dchisq(x=10.2, nu=10.0):  {0}", xrf.dist_dchisq(10.2, 10.0, False))
        Console.WriteLine("dchisq(x=10.2, nu=10.0): {0}", Arb_ChiSquare_pdf(10.2, 10.0, False))
        Console.WriteLine("pchisq(x=10.2, nu=10.0):  {0}", xrf.dist_pchisq(10.2, 10.0, False, False))
        Console.WriteLine("pchisq(x=10.2, nu=10.0): {0}", Arb_ChiSquare_CDF(10.2, 10.0, False, False))
        Console.WriteLine("qchisq(p=0.5, nu=10.0): {0}", xrf.dist_qchisq(0.5, 10.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dexp(x=10.2, lambda=10.0):  {0}", xrf.dist_dexp(10.25, 10.125, False))
        Console.WriteLine("dexp(x=10.2, lambda=10.0): {0}", Arb_Exp_pdf(10.25, 10.125, False))
        Console.WriteLine("pexp(x=10.2, lambda=10.0):  {0}", xrf.dist_pexp(10.25, 10.125, False, False))
        Console.WriteLine("pexp(x=10.2, lambda=10.0): {0}", Arb_Exp_CDF(10.25, 10.125, False, False))
        Console.WriteLine("qexp(p=0.5, lambda=10.0):  {0}", xrf.dist_qexp(0.5, 10.0, False, False))
        Console.WriteLine("qexp(p=0.5, lambda=10.0): {0}", Arb_Exp_ICDF(0.5, 10.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dgumbel(x=10.2, a=2.0, b=0.5):  {0}", xrf.dist_dgumbel(10.25, 2.0, 0.5, False))
        Console.WriteLine("dgumbel(x=10.2, a=2.0, b=0.5): {0}", Arb_Gumbel_pdf(10.25, 2.0, 0.5, False))
        Console.WriteLine("pgumbel(x=10.2, a=2.0, b=0.5):  {0}", xrf.dist_pgumbel(10.25, 2.0, 0.5, False, False))
        Console.WriteLine("pgumbel(x=10.2, a=2.0, b=0.5): {0}", Arb_Gumbel_CDF(10.25, 2.0, 0.5, False, False))
        Console.WriteLine("qgumbel(p=0.5, a=2.0, b=0.5):  {0}", xrf.dist_qgumbel(0.5, 2.0, 0.5, False, False))
        Console.WriteLine("qgumbel(p=0.5, a=2.0, b=0.5): {0}", Arb_Gumbel_ICDF(0.5, 2.0, 0.5, False, False))
        Console.WriteLine("")

        Console.WriteLine("df(x=10.77, a=10.6, b=1.8):  {0}", xrf.dist_df(10.5, 10.6, 1.8, False))
        Console.WriteLine("df(x=10.77, a=10.6, b=1.8): {0}", Arb_F_pdf(10.5, 10.6, 1.8, False))
        Console.WriteLine("pf(x=10.77, a=10.6, b=1.8):  {0}", xrf.dist_pf(10.5, 10.6, 1.8, False, False))
        Console.WriteLine("pf(x=10.77, a=10.6, b=1.8): {0}", Arb_F_CDF(10.5, 10.6, 1.8, False, False))
        Console.WriteLine("qf(p=0.5, a=10.6, b=1.8): {0}", xrf.dist_qf(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("")

        Console.WriteLine("dgamma(x=10.77, a=10.6, b=1.8):  {0}", xrf.dist_dgamma(10.5, 10.6, 1.8, False))
        Console.WriteLine("dgamma(x=10.77, a=10.6, b=1.8): {0}", Arb_Gamma_pdf(10.5, 10.6, 1.8, False))
        Console.WriteLine("pgamma(x=10.77, a=10.6, b=1.8):  {0}", xrf.dist_pgamma(10.5, 10.6, 1.8, False, False))
        Console.WriteLine("pgamma(x=10.77, a=10.6, b=1.8): {0}", Arb_Gamma_CDF(10.5, 10.6, 1.8, False, False))
        Console.WriteLine("qgamma(p=0.5, a=10.6, b=1.8): {0}", xrf.dist_qgamma(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("")

        Console.WriteLine("dgeom(x=2, lambda=0.125:  {0}", xrf.dist_dgeom(2, 0.75, False))
        Console.WriteLine("dgeom(x=2, lambda=0.125: {0}", Arb_Geom_pdf(2, 0.75, False))
        Console.WriteLine("pgeom(x=2, lambda=0.1:  {0}", xrf.dist_pgeom(2, 0.75, False, False))
        Console.WriteLine("pgeom(x=2, lambda=0.1: {0}", Arb_Geom_CDF(2, 0.75, False, False))
        Console.WriteLine("qgeom(p=0.5, lambda=0.1:  {0}", xrf.dist_qgeom(0.5, 0.1, False, False))
        Console.WriteLine("qgeom(p=0.5, lambda=0.1: {0}", Arb_Geom_ICDF(0.5, 0.1, False, False))
        Console.WriteLine("")

        Console.WriteLine("dinvchisq(x=11.5, df=2.0, scale=3.0):  {0}", xrf.dist_dinvchisq(1.5, 2.0, 3.0, False))
        Console.WriteLine("dinvchisq(x=11.5, df=2.0, scale=3.0): {0}", Arb_Invchisq_pdf(1.5, 2.0, 3.0, False))
        Console.WriteLine("pinvchisq(x=11.5, df=2.0, scale=3.0):  {0}", xrf.dist_pinvchisq(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("pinvchisq(x=11.5, df=2.0, scale=3.0): {0}", Arb_Invchisq_CDF(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("qinvchisq(p=0.5, df=2.0, scale=3.0): {0}", xrf.dist_qinvchisq(0.5, 2.0, 3.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dinvgamma(x=11.5, df=2.0, scale=3.0):  {0}", xrf.dist_dinvgamma(1.5, 2.0, 3.0, False))
        Console.WriteLine("dinvgamma(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGamma_pdf(1.5, 2.0, 3.0, False))
        Console.WriteLine("pinvgamma(x=11.5, df=2.0, scale=3.0):  {0}", xrf.dist_pinvgamma(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("pinvgamma(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGamma_CDF(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("qinvgamma(p=0.5, df=2.0, scale=3.0): {0}", xrf.dist_qinvgamma(0.5, 2.0, 3.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dinvgauss(x=11.5, df=2.0, scale=3.0):  {0}", xrf.dist_dinvgauss(1.5, 2.0, 3.0, False))
        Console.WriteLine("dinvgauss(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGauss_pdf(1.5, 2.0, 3.0, False))
        Console.WriteLine("pinvgauss(x=11.5, df=2.0, scale=3.0):  {0}", xrf.dist_pinvgauss(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("pinvgauss(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGauss_CDF(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("qinvgauss(p=0.5, df=2.0, scale=3.0): {0}", xrf.dist_pinvgauss(0.5, 2.0, 3.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dlaplace(x=5.7, a=-5.0, b=4.0):  {0}", xrf.dist_dlaplace(5.7, -5.0, 4.0, False))
        Console.WriteLine("dlaplace(x=5.7, a=-5.0, b=4.0): {0}", Arb_Laplace_pdf(5.7, -5.0, 4.0, False))
        Console.WriteLine("plaplace(x=5.7, a=-5.0, b=4.0):  {0}", xrf.dist_plaplace(5.7, -5.0, 4.0, False, False))
        Console.WriteLine("plaplace(x=5.7, a=-5.0, b=4.0): {0}", Arb_Laplace_CDF(5.7, -5.0, 4.0, False, False))
        Console.WriteLine("qlaplace(p=0.5, a=-5.0, b=4.0):  {0}", xrf.dist_qlaplace(0.6, -5.0, 4.0, False, False))
        Console.WriteLine("qlaplace(p=0.5, a=-5.0, b=4.0): {0}", Arb_Laplace_ICDF(0.6, -5.0, 4.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dlogis(x=4.3, a=9.1, b=3.2):  {0}", xrf.dist_dlogis(4.3, 9.1, 3.2, False))
        Console.WriteLine("dlogis(x=4.3, a=9.1, b=3.2): {0}", Arb_Logistic_pdf(4.3, 9.1, 3.2, False))
        Console.WriteLine("plogis(x=4.3, a=9.1, b=3.2):  {0}", xrf.dist_plogis(4.3, 9.1, 3.2, False, False))
        Console.WriteLine("plogis(x=4.3, a=9.1, b=3.2): {0}", Arb_Logistic_CDF(4.3, 9.1, 3.2, False, False))
        Console.WriteLine("qlogis(p=0.5, a=9.1, b=3.2):  {0}", xrf.dist_qlogis(0.5, 9.1, 3.2, False, False))
        Console.WriteLine("qlogis(p=0.5, a=9.1, b=3.2): {0}", Arb_Logistic_ICDF(0.5, 9.1, 3.2, False, False))
        Console.WriteLine("")

        Console.WriteLine("dlnorm(x=0.4, a=0.0, b=1.0):  {0}", xrf.dist_dlnorm(0.4, 3.0, 1.0, False))
        Console.WriteLine("dlnorm(x=0.4, a=0.0, b=1.0): {0}", Arb_LogNormal_pdf(0.4, 3.0, 1.0, False))
        Console.WriteLine("plnorm(x=0.4, a=0.0, b=1.0): {0}", xrf.dist_plnorm(0.4, 3.0, 1.0, False, False))
        Console.WriteLine("plnorm(x=0.4, a=0.0, b=1.0): {0}", Arb_LogNormal_CDF(0.4, 3.0, 1.0, False, False))
        Console.WriteLine("qlnorm(p=0.5, a=0.0, b=1.0): {0}", xrf.dist_qlnorm(0.5, 3.0, 1.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dnbinom(x=4, a=20, prob=0.7):  {0}", xrf.dist_dnbinom(4, 20, 0.7, False))
        Console.WriteLine("dnbinom(x=4, a=20, prob=0.7): {0}", Arb_Nbinom_pdf(4, 20, 0.7, False))
        Console.WriteLine("pnbinom(x=4, a=20, prob=0.7):  {0}", xrf.dist_pnbinom(4, 20, 0.7, False, False))
        Console.WriteLine("pnbinom(x=4, a=20, prob=0.7): {0}", Arb_Nbinom_CDF(4, 20, 0.7, False, False))
        Console.WriteLine("qnbinom(p=0.5, a=20, prob=0.7): {0}", xrf.dist_qnbinom(0.5, 20, 0.7, False, False))
        Console.WriteLine("")

        Console.WriteLine("dnorm(x=0.4, mu=-2.0, std=0.5):  {0}", xrf.dist_dnorm(0.4, -2.0, 0.5, False))
        Console.WriteLine("dnorm(x=0.4, mu=-2.0, std=0.5): {0}", Arb_Normal_pdf(0.4, -2.0, 0.5, False))
        Console.WriteLine("pnorm(x=0.4, mu=-2.0, std=0.5):  {0}", xrf.dist_pnorm(0.4, -2.0, 0.5, False, False))
        Console.WriteLine("pnorm(x=0.4, mu=-2.0, std=0.5): {0}", Arb_Normal_CDF(0.4, -2.0, 0.5, False, False))
        Console.WriteLine("qnorm(p=0.5, mu=-2.0, std=0.5): {0}", xrf.dist_qnorm(0.5, -2.0, 0.5, False, False))
        Console.WriteLine("")

        Console.WriteLine("dpareto(x=3.4, shape=3.0, scale=1.0):  {0}", xrf.dist_dpareto(3.4, 3.0, 1.0, False))
        Console.WriteLine("dpareto(x=3.4, shape=3.0, scale=1.0): {0}", Arb_Pareto_pdf(3.4, 3.0, 1.0, False))
        Console.WriteLine("ppareto(x=3.4, shape=3.0, scale=1.0):  {0}", xrf.dist_ppareto(3.4, 3.0, 1.0, False, False))
        Console.WriteLine("ppareto(x=3.4, shape=3.0, scale=1.0): {0}", Arb_Pareto_CDF(3.4, 3.0, 1.0, False, False))
        Console.WriteLine("qpareto(p=0.5, shape=3.0, scale=1.0):  {0}", xrf.dist_qpareto(0.5, 3.0, 1.0, False, False))
        Console.WriteLine("qpareto(p=0.5, shape=3.0, scale=1.0): {0}", Arb_Pareto_ICDF(0.5, 3.0, 1.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dpois(x=11, lambda=4.0):  {0}", xrf.dist_dpois(11, 4.0, False))
        Console.WriteLine("dpois(x=11, lambda=4.0): {0}", Arb_Poisson_pdf(11, 4.0, False))
        Console.WriteLine("ppois(x=11, lambda=4.0):  {0}", xrf.dist_ppois(11, 4.0, False, False))
        Console.WriteLine("ppois(x=11, lambda=4.0): {0}", Arb_Poisson_CDF(11, 4.0, False, False))
        Console.WriteLine("qpois(p=0.5, lambda=4.0): {0}", xrf.dist_ppois(0.5, 4.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("drayleigh(x=6.3, nu=1.1):  {0}", xrf.dist_drayleigh(6.3, 1.1, False))
        Console.WriteLine("drayleigh(x=6.3, nu=1.1): {0}", Arb_RayLeigh_pdf(6.3, 1.1, False))
        Console.WriteLine("prayleigh(x=6.3, nu=1.1):  {0}", xrf.dist_prayleigh(6.3, 1.1, False, False))
        Console.WriteLine("prayleigh(x=6.3, nu=1.1): {0}", Arb_RayLeigh_CDF(6.3, 1.1, False, False))
        Console.WriteLine("qrayleigh(p=0.5, nu=1.1):  {0}", xrf.dist_qrayleigh(0.5, 1.1, False, False))
        Console.WriteLine("qrayleigh(p=0.5, nu=1.1): {0}", Arb_RayLeigh_ICDF(0.5, 1.1, False, False))
        Console.WriteLine("")



        Console.WriteLine("dt(x=11, nu=5.0):  {0}", xrf.dist_dt(11, 6.0, False))
        Console.WriteLine("dt(x=11, nu=5.0): {0}", Arb_T_pdf(11, 6.0, False))
        Console.WriteLine("pt(x=11, nu=5.0):  {0}", xrf.dist_pt(11, 6.0, False, False))
        Console.WriteLine("pt(x=11, nu=5.0): {0}", Arb_T_CDF(11, 6.0, False, False))
        Console.WriteLine("qt(p=0.5, nu=5.0): {0}", xrf.dist_qt(0.5, 6.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dtriangular(x=0.77, lower=0.0, mode=1.0, upper=4.0): {0}", xrf.dist_dtriangular(0.77, -2, 0, 3, False))
        Console.WriteLine("ptriangular(x=0.77, lower=0.0, mode=1.0, upper=4.0): {0}", xrf.dist_ptriangular(0.77, -2, 0, 3, False, False))
        Console.WriteLine("qtriangular(p=0.5, lower=0.0, mode=1.0, upper=4.0): {0}", xrf.dist_qtriangular(0.5, -2, 0, 3, False, False))
        Console.WriteLine("")

        Console.WriteLine("dunif(x=0.77, lower=-2.0,  upper=3.0):  {0}", xrf.dist_dunif(0.77, -2, 3, False))
        Console.WriteLine("dunif(x=0.77, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_pdf(0.77, -2, 3, False))
        Console.WriteLine("punif(x=0.77, lower=-2.0,  upper=3.0):  {0}", xrf.dist_punif(0.77, -2, 3, False, False))
        Console.WriteLine("punif(x=0.77, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_CDF(0.77, -2, 3, False, False))
        Console.WriteLine("qunif(p=0.5, lower=-2.0,  upper=3.0): {0}", xrf.dist_qunif(0.5, -2, 3, False, False))
        Console.WriteLine("qunif(p=0.5, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_ICDF(0.5, -2, 3, False, False))
        Console.WriteLine("")

        Console.WriteLine("dweibull(x=0.77, shape=0.5, scale=1.0):  {0}", xrf.dist_dweibull(0.77, 0.5, 1, False))
        Console.WriteLine("dweibull(x=0.77, shape=0.5, scale=1.0): {0}", Arb_Weibull_pdf(0.77, 0.5, 1, False))
        Console.WriteLine("pweibull(x=0.77, shape=0.5, scale=1.0):  {0}", xrf.dist_pweibull(0.77, 0.5, 1, False, False))
        Console.WriteLine("pweibull(x=0.77, shape=0.5, scale=1.0): {0}", Arb_Weibull_CDF(0.77, 0.5, 1, False, False))
        Console.WriteLine("qweibull(p=0.5, shape=0.5, scale=1.0):  {0}", xrf.dist_qweibull(0.5, 0.5, 1, False, False))
        Console.WriteLine("qweibull(p=0.5, shape=0.5, scale=1.0): {0}", Arb_Weibull_ICDF(0.5, 0.5, 1, False, False))
        Console.WriteLine("")


        '****************************************************************************************		
        '****************************************************************************************		


        Console.WriteLine("dhyper(x=10, r=50, n=30, NN=500): {0}", xrf.dist_dhyper(10, 50, 30, 500, False))
        Console.WriteLine("phyper(x=10, r=50, n=30, NN=500): {0}", xrf.dist_phyper(10, 50, 30, 500, False, False))
        Console.WriteLine("qhyper(p=0.5, r=50, n=30, NN=500): {0}", xrf.dist_qhyper(0.5, 50, 30, 500, False, False))
        Console.WriteLine("")


        Console.WriteLine("dskewnormal(x=0.77, a=0.0, b=1.0, nc=4.0): {0}", xrf.dist_dskewnormal(0.77, 0, 1, 4, False))
        Console.WriteLine("pskewnormal(x=0.77, a=0.0, b=1.0, nc=4.0): {0}", xrf.dist_pskewnormal(0.77, 0, 1, 4, False, False))
        Console.WriteLine("qskewnormal(p=0.5, a=0.0, b=1.0, nc=4.0): {0}", xrf.dist_qskewnormal(0.5, 0, 1, 4, False, False))
        Console.WriteLine("")


        Console.WriteLine("dbeta_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", xrf.dist_dbeta_nc(0.77, 3.0, 12.0, 30.0, False))
        Console.WriteLine("pbeta_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", xrf.dist_pbeta_nc(0.77, 3.0, 12.0, 30.0, False, False))
        Console.WriteLine("qbeta_nc(p=0.5, a=3.0, b=12.0, nc=30.0): {0}", xrf.dist_qbeta_nc(0.5, 3.0, 12.0, 30.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dchisq_nc(x=4.23, nu=3.0,  nc=30.0): {0}", xrf.dist_dchisq_nc(4.23, 3.0, 30.0, False))
        Console.WriteLine("pchisq_nc(x=4.23, nu=3.0,  nc=30.0): {0}", xrf.dist_pchisq_nc(4.23, 3.0, 30.0, False, False))
        Console.WriteLine("qbinom(p=0.5, size=11, prob=0.1): {0}", xrf.dist_qbinom(0.5, 11, 0.4, False, False))
        Console.WriteLine("")

        Console.WriteLine("df_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", xrf.dist_df_nc(0.77, 3.0, 12.0, 30.0, False))
        Console.WriteLine("pf_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", xrf.dist_pf_nc(0.77, 3.0, 12.0, 30.0, False, False))
        Console.WriteLine("qf_nc(p=0.5, a=3.0, b=12.0, nc=30.0): {0}", xrf.dist_qf_nc(0.5, 3.0, 12.0, 30.0, False, False))
        Console.WriteLine("")

        Console.WriteLine("dt_nc(x=4.23, nu=2.0,  nc=-5.0): {0}", xrf.dist_dt_nc(4.23, 2.0, -5.0, False))
        Console.WriteLine("pt_nc(x=4.23, nu=2.0,  nc=-5.0): {0}", xrf.dist_pt_nc(4.23, 2.0, -5.0, False, False))
        Console.WriteLine("qt_nc(p=0.5, nu=2.0,  nc=-5.0): {0}", xrf.dist_qt_nc(0.5, 2.0, -5.0, False, False))
        Console.WriteLine("")


    End Sub





End Module
