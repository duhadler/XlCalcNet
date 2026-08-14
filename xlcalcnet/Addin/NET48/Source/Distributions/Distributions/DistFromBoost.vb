Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet



Module DistFromBoost

    'Dim AcbParamsNC As ArbMatC = apc_mat.set_ones(100, 1)
    Dim AcbParamsNC As ArbMatC = aflintc.mat_ones(100, 1)

    Friend Const mp_df1_pos As Int32 = 1
    Friend Const mp_df2_pos As Int32 = 2
    Friend Const mp_nc_pos As Int32 = 3
    Friend Const mp_order As Int32 = 4


    Function Arb_Cauchy_pdf(x As Arb, a As Arb, b As Arb, log As Boolean) As Arb
        Dim pi_inv = 1 / aflint.pi()
        Dim result = pi_inv * b / ((x - a) * (x - a) + b * b)
        Return result
    End Function


    Function Arb_Cauchy_CDF(x As Arb, a As Arb, b As Arb, lower_tail As Boolean, log As Boolean) As Arb
        Dim result, pi_inv As New Arb
        pi_inv = 1 / aflint.pi()
        result = 0.5 + pi_inv * aflint.atan((x - a) / b)
        Return 1 - result
    End Function


    Function Arb_Cauchy_ICDF(p As Arb, a As Arb, b As Arb, lower_tail As Boolean, log As Boolean) As Arb
        Dim result, pi As New Arb
        Dim half = aflint.t("0.5")
        pi = aflint.pi()
        If p = half Then Return a
        If p < half Then Return a - b / aflint.tan(pi * p) Else Return a - b / aflint.tan(pi * (1 - p))
    End Function



    Function Arb_Exp_pdf(x As Arb, lambda As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = lambda * aflint.exp(-lambda * x)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Exp_CDF(x As Arb, lambda As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = -aflint.expm1(-x * lambda) Else result = aflint.exp(-x * lambda)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Exp_ICDF(prob As Arb, lambda As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, p As New Arb
        If log_p Then p = aflint.exp(prob) Else p = prob
        If lower_tail Then result = -aflint.log1p(-p) / lambda Else result = -aflint.log(p) / lambda
        Return result
    End Function


    Function Arb_Gumbel_pdf(x As Arb, a As Arb, b As Arb, log_p As Boolean) As Arb
        Dim result, c As New Arb
        c = aflint.exp(-(x - a) / b)
        result = c * aflint.exp(-c) / b
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Gumbel_CDF(x As Arb, a As Arb, b As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, c As New Arb
        c = aflint.exp(-(x - a) / b)
        If lower_tail Then result = aflint.exp(-c) Else result = -aflint.expm1(-c)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Gumbel_ICDF(prob As Arb, a As Arb, b As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, p As New Arb
        If log_p Then p = aflint.exp(prob) Else p = prob
        If lower_tail Then result = a - aflint.log(-aflint.log(p)) * b Else result = a - aflint.log(-aflint.log1p(-p)) * b
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Geom_pdf(k As Arb, p As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = p * aflint.exp(k * aflint.log1p(-p))
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Geom_CDF(k As Arb, p As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        'If lower_tail Then result = 1 - (1 - p) ^ (k + 1) Else result = aflint.exp(aflint.log1p(-p) * (k + 1))
        If lower_tail Then result = 1 - aflint.pow((1 - p), (k + 1)) Else result = aflint.exp(aflint.log1p(-p) * (k + 1))
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Geom_ICDF(prob As Arb, p As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, prob1 As New Arb
        If log_p Then prob1 = aflint.exp(prob) Else prob1 = prob
        If lower_tail Then result = aflint.log1p(-prob1) / aflint.log1p(-p) - 1 Else result = aflint.log(prob1) / aflint.log1p(-p) - 1
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_InvGauss_pdf(x As Arb, mu As Arb, lambda As Arb, log_p As Boolean) As Arb
        Dim result, pi As New Arb
        pi = aflint.pi()
        result = aflint.sqrt(lambda / (2 * pi * x * x * x)) * aflint.exp(-lambda * (x - mu) * (x - mu) / (2 * mu * mu * x))
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_InvGauss_CDF(x As Arb, mean As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, cdf1, cdf2, cdf As New Arb
        Dim n0, n1, n3, n4, expfactor As New Arb
        n0 = aflint.sqrt(scale / x)
        n0 *= ((x / mean) - 1)
        '        n1 = aflint.ndist(n0)
        expfactor = aflint.exp(2 * scale / mean)
        n3 = -aflint.sqrt(scale / x)
        n3 *= (x / mean) + 1
        '        n4 = aflint.ndist(n3)
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
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Laplace_pdf(x As Arb, location As Arb, scale As Arb, log_p As Boolean) As Arb
        Dim result, exponent As New Arb
        exponent = x - location
        If (exponent > 0) Then exponent = -exponent
        exponent /= scale
        result = aflint.exp(exponent)
        result /= 2 * scale
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Laplace_CDF(x As Arb, location As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, cdf1, cdf2 As New Arb
        If (x < location) Then cdf1 = aflint.exp((x - location) / scale) / 2 Else cdf1 = 1 - aflint.exp((location - x) / scale) / 2
        If (-x < -location) Then cdf2 = aflint.exp((-x + location) / scale) / 2 Else cdf2 = 1 - aflint.exp((-location + x) / scale) / 2
        If lower_tail Then result = cdf1 Else result = cdf2
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Function Arb_Laplace_ICDF(prob As Arb, location As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, prob1, q, ICDF1, ICDF2 As New Arb
        If log_p Then prob1 = aflint.exp(prob) Else prob1 = prob
        q = 1 - prob1
        If ((prob1 - 0.5) < 0) Then ICDF1 = location + scale * aflint.log((prob1 * 2)) Else ICDF1 = location - scale * aflint.log((-prob1 * 2 + 2))
        If ((0.5 - q) < 0) Then ICDF2 = location + scale * aflint.log((-q * 2 + 2)) Else ICDF2 = location - scale * aflint.log((q * 2))
        If lower_tail Then result = ICDF1 Else result = ICDF2
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Logistic_pdf(x As Arb, location As Arb, scale As Arb, log_p As Boolean) As Arb
        Dim result, c As New Arb
        c = aflint.exp(-(x - location) / scale)
        'result = c / (scale * (1 + c) ^ 2)
        result = c / (scale * aflint.pow((1 + c), 2))
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Logistic_CDF(x As Arb, location As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = 1 / (1 + aflint.exp(-(x - location) / scale)) Else result = 1 / (1 + aflint.exp((x - location) / scale))
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Logistic_ICDF(prob As Arb, location As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, prob1 As New Arb
        If log_p Then prob1 = aflint.exp(prob) Else prob1 = prob
        If lower_tail Then result = location - scale * aflint.log(1 / (prob1 - 1)) Else result = location + scale * aflint.log(prob1 / (1 - prob1))
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_LogNormal_pdf(x As Arb, mu As Arb, sigma As Arb, log_p As Boolean) As Arb
        Dim result, exponent, pi As New Arb
        pi = aflint.pi
        exponent = aflint.log(x) - mu
        exponent *= -exponent
        exponent /= 2 * sigma * sigma
        result = aflint.exp(exponent)
        result /= sigma * aflint.sqrt(2 * pi) * x
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_LogNormal_CDF(x As Arb, mu As Arb, sigma As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        result = Arb_Normal_CDF(aflint.log(x), mu, sigma, lower_tail, log_p)
        Return result
    End Function



    Function Arb_Normal_pdf(x As Arb, mu As Arb, sigma As Arb, log_p As Boolean) As Arb
        Dim result, exponent, pi As New Arb
        result = aflint.exp(-(x - mu) * (x - mu) / (2 * sigma * sigma)) / (sigma * aflint.sqrt(2 * aflint.pi()))
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Normal_CDF(x As Arb, mu As Arb, sigma As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then
            result = 0.5 * aflint.erfc(-(x - mu) / (sigma * aflint.sqrt(2)))
        Else
            result = 0.5 * aflint.erfc((x - mu) / (sigma * aflint.sqrt(2)))
        End If
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Function Acb_Beta_pdf(x As ArbC, a As ArbC, b As ArbC, log_p As Boolean) As ArbC
        Dim result As New ArbC

        ' Not yet implemented !!!
        result = aflintc.ibeta_derivative(a, b, x)
        If log_p Then result = aflintc.log(result)
        Return result
    End Function



    Function Arb_Beta_pdf(x As Arb, a As Arb, b As Arb, log_p As Boolean) As Arb
        Dim result As New Arb

        ' Not yet implemented !!!
        result = aflint.ibeta_derivative(a, b, x)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Beta_CDF(x As Arb, a As Arb, b As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = aflint.ibeta(a, b, x) Else result = aflint.ibetac(a, b, x)
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Function Arb_Binom_pdf(k As Arb, n As Arb, p As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = aflint.ibeta_derivative(k + 1, n - k + 1, p) / (n + 1)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Binom_CDF(k As Arb, n As Arb, p As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = aflint.ibetac(k + 1, n - k, p) Else result = aflint.ibeta(k + 1, n - k, p)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_ChiSquare_pdf(x As Arb, nu As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = aflint.gamma_p_derivative(nu / 2, x / 2) / 2
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Function Acb_ChiSquare_pdf(x As ArbC, nu As ArbC, log_p As Boolean) As ArbC
        Dim result As New ArbC
        result = aflintc.gamma_p_derivative(nu / 2, x / 2) / 2
        If log_p Then result = aflintc.log(result)
        Return result
    End Function




    Function Arb_ChiSquare_CDF(x As Arb, nu As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        ' Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
        If lower_tail Then result = aflint.gamma_p(nu / 2, x / 2) Else result = aflint.gamma_q(nu / 2, x / 2)
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    'Function Arb_ChiSquare_CDF(x As Arb, nu As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
    '    Dim result As New Arb
    '    ' Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
    '    Dim LeftTail As Arb, RightTail As Arb, density As Arb
    '    cdis2(nu, x, LeftTail, RightTail, density)
    '    If lower_tail Then result = LeftTail Else result = RightTail
    '    If log_p Then result = aflint.log(result)
    '    Return result
    'End Function



    Function Acb_F_pdf(x As ArbC, df1 As ArbC, df2 As ArbC, log_p As Boolean) As ArbC
        Dim result, v1x As New ArbC
        v1x = df1 * x
        If (aflintc.abs(v1x) > aflintc.abs(df2)) Then
            result = (df2 * df1) / ((df2 + v1x) * (df2 + v1x))
            result *= aflintc.ibeta_derivative(df2 / 2, df1 / 2, df2 / (df2 + v1x))
        Else
            result = df2 + df1 * x
            result = (result * df1 - x * df1 * df1) / (result * result)
            result *= aflintc.ibeta_derivative(df1 / 2, df2 / 2, v1x / (df2 + v1x))
        End If
        If log_p Then result = aflintc.log(result)
        Return result
    End Function


    Function Arb_F_pdf(x As Arb, df1 As Arb, df2 As Arb, log_p As Boolean) As Arb
        Dim result, v1x As New Arb
        v1x = df1 * x
        If (aflint.abs(v1x) > aflint.abs(df2)) Then
            result = (df2 * df1) / ((df2 + v1x) * (df2 + v1x))
            result *= aflint.ibeta_derivative(df2 / 2, df1 / 2, df2 / (df2 + v1x))
        Else
            result = df2 + df1 * x
            result = (result * df1 - x * df1 * df1) / (result * result)
            result *= aflint.ibeta_derivative(df1 / 2, df2 / 2, v1x / (df2 + v1x))
        End If
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_F_CDF(x As Arb, df1 As Arb, df2 As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, v1x, cdf1, cdf2 As New Arb
        ' Need to modify: dependend on predicted result, use _p or _q and use 1-result as appropriate
        v1x = df1 * x
        If (v1x > df2) Then
            cdf1 = aflint.ibetac(df2 / 2, df1 / 2, df2 / (df2 + v1x))
        Else
            cdf1 = aflint.ibeta(df1 / 2, df2 / 2, v1x / (df2 + v1x))
        End If

        If (v1x > df2) Then
            cdf2 = aflint.ibeta(df2 / 2, df1 / 2, df2 / (df2 + v1x))
        Else
            cdf2 = aflint.ibetac(df1 / 2, df2 / 2, v1x / (df2 + v1x))
        End If

        If lower_tail Then result = cdf1 Else result = cdf2
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Function Arb_Gamma_pdf(x As Arb, k As Arb, theta As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = aflint.gamma_p_derivative(k, x / theta) / theta
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Gamma_CDF(x As Arb, k As Arb, theta As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = aflint.gamma_p(k, x / theta) Else result = aflint.gamma_q(k, x / theta)
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Function Arb_Invchisq_pdf(x As Arb, df As Arb, scale As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = df * scale / 2 / x
        result = aflint.gamma_p_derivative(df / 2, result) * df * scale / 2
        result /= (x * x)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Invchisq_CDF(x As Arb, df As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = aflint.gamma_q(df / 2, (df * (scale / 2)) / x) Else result = aflint.gamma_p(df / 2, (df * scale / 2) / x)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_InvGamma_pdf(x As Arb, shape As Arb, scale As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = (aflint.pow(scale, shape) * aflint.pow(x, (-shape - 1)) * aflint.exp(-scale / x)) / aflint.gamma(shape)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_InvGamma_CDF(x As Arb, shape As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = aflint.gamma_q(shape, scale / x) Else result = aflint.gamma_p(shape, scale / x)
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Function Arb_Nbinom_pdf(k As Arb, r As Arb, p As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = (p / (r + k)) * aflint.ibeta_derivative(r, (k + 1), p)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Nbinom_CDF(k As Arb, r As Arb, p As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = aflint.ibeta(r, (k + 1), p) Else result = aflint.ibetac(r, (k + 1), p)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_T_pdf(x As Arb, df As Arb, log_p As Boolean) As Arb
        Dim result, basem1 As New Arb
        Dim E8 = aflint.t(0.125)
        basem1 = x * x / df
        If (basem1 < E8) Then
            result = aflint.exp(-aflint.log1p(basem1) * (1 + df) / 2)
        Else
            result = aflint.pow(1 / (1 + basem1), (df + 1) / 2)
        End If
        result /= aflint.sqrt(df) * aflint.beta(df / 2, 0.5)

        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_T_CDF(x As Arb, df As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, x2, z, probability, cdf1, cdf2 As New Arb

        x2 = x * x
        If (df > 2 * x2) Then
            z = x2 / (df + x2)
            probability = aflint.ibetac(0.5, df / 2, z) / 2
        Else
            z = df / (df + x2)
            probability = aflint.ibeta(df / 2, 0.5, z) / 2
        End If
        If (x > 0) Then cdf1 = 1 - probability Else cdf1 = probability
        If (x > 0) Then cdf2 = probability Else cdf2 = 1 - probability

        If lower_tail Then result = cdf1 Else result = cdf2
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Pareto_pdf(x As Arb, scale As Arb, shape As Arb, log_p As Boolean) As Arb
        Dim result, c As New Arb
        If (x < scale) Then result = aflint.t(0) Else result = shape * aflint.pow(scale, shape) / aflint.pow(x, shape + 1)
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Pareto_CDF(x As Arb, scale As Arb, shape As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = 1 - aflint.pow((scale / x), shape) Else result = aflint.pow((scale / x), shape)
        'If lower_tail Then result = 1 - (scale / x) ^ shape Else result = (scale / x) ^ shape
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Pareto_ICDF(prob As Arb, scale As Arb, shape As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, prob1 As New Arb
        If log_p Then prob1 = aflint.exp(prob) Else prob1 = prob
        If lower_tail Then result = scale / aflint.pow((1 - prob1), (1 / shape)) Else result = scale / aflint.pow((1 - prob1), (1 / shape))
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Poisson_pdf(k As Arb, mean As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        result = aflint.gamma_p_derivative(k + 1, mean)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Poisson_CDF(k As Arb, mean As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = aflint.gamma_q(k + 1, mean) Else result = aflint.gamma_p(k + 1, mean)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_RayLeigh_pdf(x As Arb, sigma As Arb, log_p As Boolean) As Arb
        Dim result, sigmasqr As New Arb
        sigmasqr = sigma * sigma
        result = x * (aflint.exp(-(x * x) / (2 * sigmasqr))) / sigmasqr
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_RayLeigh_CDF(x As Arb, sigma As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = aflint.expm1(-x * x / (2 * sigma * sigma)) Else result = aflint.exp(-(x * x) / (2 * sigma * sigma))
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_RayLeigh_ICDF(prob As Arb, sigma As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, prob1 As New Arb
        If log_p Then prob1 = aflint.exp(prob) Else prob1 = prob
        If lower_tail Then result = aflint.sqrt(-2 * sigma * sigma * aflint.log1p(-prob1)) Else result = aflint.sqrt(-2 * sigma * sigma * aflint.log(1 - prob1))
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Function Arb_Weibull_pdf(x As Arb, shape As Arb, scale As Arb, log_p As Boolean) As Arb
        Dim result, c As New Arb
        result = aflint.exp(-aflint.pow(x / scale, shape))
        result *= aflint.pow(x / scale, shape - 1) * shape / scale
        If log_p Then result = aflint.log(result)
        Return result
    End Function



    Function Arb_Weibull_CDF(x As Arb, shape As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result As New Arb
        If lower_tail Then result = -aflint.expm1(-aflint.pow(x / scale, shape)) Else result = aflint.exp(-aflint.pow(x / scale, shape))
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Weibull_ICDF(prob As Arb, shape As Arb, scale As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, prob1 As New Arb
        If log_p Then prob1 = aflint.exp(prob) Else prob1 = prob
        If lower_tail Then result = scale * aflint.pow(-aflint.log1p(-prob1), 1 / shape) Else result = scale * aflint.pow(-aflint.log(1 - prob1), 1 / shape)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Uniform_pdf(x As Arb, lower As Arb, upper As Arb, log_p As Boolean) As Arb
        Dim result As New Arb
        If ((x < lower) Or (x > upper)) Then result = aflint.t(0) Else result = 1 / (upper - lower)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Uniform_CDF(x As Arb, lower As Arb, upper As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, cdf1, cdf2 As New Arb
        If ((x < lower) Or (x > upper)) Then
            If (x < lower) Then
                cdf1 = aflint.t(0) : cdf2 = aflint.t(1)
            Else
                cdf1 = aflint.t(1) : cdf2 = aflint.t(0)
            End If
        Else
            cdf1 = (x - lower) / (upper - lower)
            cdf2 = (upper - x) / (upper - lower)
        End If
        If lower_tail Then result = cdf1 Else result = cdf2
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Function Arb_Uniform_ICDF(prob As Arb, lower As Arb, upper As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        Dim result, prob1, icdf1, icdf2 As New Arb
        If log_p Then prob1 = aflint.exp(prob) Else prob1 = prob
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
        If log_p Then result = aflint.log(result)
        Return result
    End Function

    Function Acb_GammaStar(t As ArbC, nu As ArbC, z As ArbC) As ArbC
        Dim d, c, result As New ArbC
        c = aflint.pow(z, nu) / aflintc.gamma(nu)
        d = aflint.pow(t, (nu - 1)) * aflintc.exp(-z * t)
        result = c * d
        Return result
    End Function


    Function Acb_GammaStar2(t As ArbC, nu As ArbC, z As ArbC, a As ArbC) As ArbC
        Dim d, c, result As New ArbC
        c = aflint.pow(z, nu) / aflintc.gamma(nu)
        d = aflintc.exp(-z * t)
        result = c * d
        Return result
    End Function


    'Function AcbIntegrand_NC(x As ArbC, params2 As ArbMatC) As ArbC
    Function AcbIntegrand_NC(x As ArbC, params2 As ArbMatC) As ArbC
        'Dim proc_outer As Int32 = AcbParamsNC(mp_proc_outer_pos).real.ToInt32
        Dim proc_outer As Int32 = aflint.lrint(AcbParamsNC(mp_proc_outer_pos).real)
        Dim fx As New ArbC
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
            'Case mp_integral_rho : fx = Acb_Rho_pdf(df1.real.ToInt32, x, nc)
            Case mp_integral_rho : fx = Acb_Rho_pdf(aflint.lrint(df1.real), x, nc)
            Case mp_integral_rho2 : fx = Acb_Rho2_pdf(x, df1, df2, nc, False)
            Case Else : Console.WriteLine("!!!! Error AcbIntegrand_NC !!!!!)") : fx = aflintc.nan()
        End Select
        '        Console.WriteLine("fx: {0}", fx)
        Return fx
    End Function

#If Win64 Then
    Sub WrapperParams_GL_NC(fxPtr As IntPtr, xPtr As IntPtr, paramsPtr As IntPtr, order As UInt64, prec As UInt64)
#Else
        Sub WrapperParams_GL_NC(ByVal fxPtr As IntPtr, ByVal xPtr As IntPtr, ByVal paramsPtr As IntPtr, ByVal order As UInt32, ByVal prec As UInt32)
#End If
        'Dim old_prec = mp4.getprec()
        'Console.WriteLine("In WrapperParams_GL_Outer: order: {0}, prec: {1}, paramsPtr: {2}", order, prec, paramsPtr)
        'mp4.setprec(CUInt(prec))
        'Dim x As New ArbC(xPtr, True)
        'Dim fx As New ArbC()
        'fx = AcbIntegrand_NC(x, Nothing)
        'fx.CopyToPtr(fxPtr)
        'mp4.setprec(old_prec)
    End Sub


    Sub DemoAcbIntegrationChiSquare()
        'mp4.setprec(400)
        AcbParamsNC(0) = aflintc.t(mp_integral_chisquare)
        Dim x = 5000000 - 0
        Dim nu = 5000000
        Dim lambda = 0
        'Dim result = dreal.dist_pchisq(x, nu, True)
        'Console.WriteLine("    result: {0}", result)


        AcbParamsNC(mp_df1_pos) = aflintc.t(nu)
        AcbParamsNC(mp_nc_pos) = aflintc.t(0)
        'Dim s, a, b As New ArbC
        'Dim workinmrealec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        Dim a = aflint.t(0)
        Dim b = aflint.t(x)
        'Dim rel_goal As UInt32 = workinmrealec
        'Dim abs_tol_bits As UInt32 = workinmrealec
        Dim rel_goal As UInt32 = 150
        Dim abs_tol_bits As UInt32 = 150
        Dim eval_limit As UInt32 = 0
        'Dim s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)
        'Dim alpha = 1
        'Dim beta = 1
        'Dim epsabsStart = aflint.t("1.0E-15")
        'epsabsStart = epsabsStart * result
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)
    End Sub

    Sub DemoAcbIntegrationGammaStar()
        'mp4.setprec(400)
        AcbParamsNC(0) = aflintc.t(mp_integral_gammastar)
        Dim z = 49999
        Dim nu = 50000
        Dim lambda = 0
        Dim result As New Arb
        'Dim result = dreal.dist_pchisq(X, nu, True)
        'Console.WriteLine("    result: {0}", result)


        AcbParamsNC(mp_df1_pos) = aflintc.t(nu)
        AcbParamsNC(mp_df2_pos) = aflintc.t(z)
        'Dim s, a, b As New ArbC
        'Dim workinmrealec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 1
        Dim a = 0.0
        Dim b = 1.0
        'Dim rel_goal As UInt32 = workinmrealec
        'Dim abs_tol_bits As UInt32 = workinmrealec
        Dim rel_goal As UInt32 = 153
        Dim abs_tol_bits As UInt32 = 153
        Dim eval_limit As UInt32 = 0
        'Dim s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)


        'Dim alpha = 0.999
        'Dim beta = 1.0
        'a = 0.95
        'b = 1.0
        'Dim epsabsStart = aflint.t("1.0E-15")
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
        'epsabsStart = aflint.t("1.0E-15")
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
        'mp4.setprec(100)
        AcbParamsNC(0) = aflintc.t(mp_integral_chisquare_nc)
        Dim x = 1050
        Dim nu = 80
        Dim lambda = 850
        'Dim result = dreal.dist_pchisq_nc(x, nu, lambda, True)
        'Console.WriteLine("    result: {0}", result)


        AcbParamsNC(mp_df1_pos) = aflintc.t(nu)
        AcbParamsNC(mp_nc_pos) = aflintc.t(lambda)
        'Dim s, a, b As New ArbC
        'Dim workinmrealec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        Dim a = aflint.t(899)
        Dim b = aflint.t(x)
        'Dim rel_goal As UInt32 = workinmrealec
        'Dim abs_tol_bits As UInt32 = workinmrealec
        Dim eval_limit As UInt32 = 0
        'Dim s = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)
        Dim alpha = 1
        Dim beta = 1
        Dim epsabsStart = aflint.t("1.0E-15")
        'epsabsStart = epsabsStart * result.value
        'DE_Integration(AddressOf AcbIntegrand_NC, AcbParamsNC, a, b, epsabsStart, alpha, beta)
        'Console.WriteLine("result:{0}", result)
    End Sub


    Function Includesmode(x As ArbC, nu As ArbC, lambda As ArbC) As Boolean
        If ((x.real.Infimum < lambda.real.Infimum) And (x.real.Supremum > lambda.real.Supremum)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function Acb_ChiSquare_NC_pdf(x As ArbC, nu As ArbC, lambda As ArbC, log_p As Boolean) As ArbC
        Dim order As Int32 = aflint.lrint(AcbParamsNC(mp_order).real)
        Dim result As New ArbC
        Console.WriteLine("Order: {0}", order)
        If (order = 1) Then
            If Includesmode(x, nu, lambda) Then
                Return aflintc.nan()
                'Else
                Dim x1 As New ArbC
                x1 = x
                Dim x1_re, x1_im, av1 As New Arb
                x1_re.Mid = x.real.Supremum
                x1_re.Rad = aflint.t(0)
                x1_im.Mid = x.imag.Supremum
                x1_im.Rad = aflint.t(0)
                x1 = aflintc.t(x1_re, x1_im)
                'x1.real = x1_re
                'x1.imag = x1_im
                Dim dens0 = Acb_ChiSquare_pdf(x1, nu, False)
                Dim hyper = aflintc.hyperg_0f1(nu / 2, lambda * x1 / 4)
                result = dens0 * aflintc.exp(-lambda / 2) * hyper
                If log_p Then result = aflintc.log(result)
            End If
        Else
            Dim dens0 = Acb_ChiSquare_pdf(x, nu, False)
            Dim hyper = aflintc.hyperg_0f1(nu / 2, lambda * x / 4)
            result = dens0 * aflintc.exp(-lambda / 2) * hyper
            If log_p Then result = aflintc.log(result)

        End If
        Return result
    End Function


    Function Arb_ChiSquare_NC_pdf(x As Arb, nu As Arb, lambda As Arb, log_p As Boolean) As Arb
        Dim dens0 = Arb_ChiSquare_pdf(x, nu, False)
        Dim hyper = aflint.hyperg_0f1(nu / 2, lambda * x / 4)
        Dim result = dens0 * aflint.exp(-lambda / 2) * hyper
        If log_p Then result = aflint.log(result)
        Return result
    End Function

    Sub DemoChiSquareDensity()
        Dim x, nu, lambda, result, dens0, hyper As New Arb
        x = aflint.t(12)
        nu = aflint.t(10)
        lambda = aflint.t(3)
        'result = aflint.t(dreal.dist_dchisq_nc(x.AsDouble, nu.AsDouble, lambda.AsDouble))
        'Console.WriteLine("   result: {0}", result)
        result = Arb_ChiSquare_NC_pdf(x, nu, lambda, False)
        Console.WriteLine("   result: {0}", result)
        'Dim resultc = Acb_ChiSquare_NC_pdf(x, nu, lambda, False)
        'Console.WriteLine("   resultc: {0}", resultc)
    End Sub



    Sub DemoAcbIntegrationTNC()
        'mp4.setprec(100)
        AcbParamsNC(0) = aflintc.t(mp_integral_t_nc)
        Dim x = 4
        Dim nu = 20
        Dim lambda = 5
        AcbParamsNC(mp_df1_pos) = aflintc.t(nu)
        AcbParamsNC(mp_nc_pos) = aflintc.t(lambda)
        Dim s, a, b As New ArbC
        Dim workinmrealec As UInt32 = 100
        'Dim workinmrealec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = aflintc.t(0)
        b = aflintc.t(x)
        Dim rel_goal As UInt32 = workinmrealec
        Dim abs_tol_bits As UInt32 = workinmrealec
        Dim eval_limit As UInt32 = 0
        's = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)
        'Dim resultint = NdisAcb(-lambda) + s
        'Console.WriteLine("resultint:{0}", resultint)
        'Dim result = dreal.dist_pt_nc(x, nu, lambda, True)
        'Console.WriteLine("    result: {0}", result)
    End Sub


    Function Acb_T_NC_pdf(x As ArbC, n As ArbC, delta As ArbC, log_p As Boolean) As ArbC
        Dim m = n / 2
        Dim a = n + x * x
        Dim d2 = delta * delta
        Dim y2 = d2 * x * x / (2 * a)
        Dim K1 = (aflintc.pow(n, m) * aflintc.gamma(n + 1) * aflintc.exp(-0.5 * d2)) / (aflintc.pow(2, n) * aflintc.pow(a, m) * aflintc.gamma(m))
        Dim LSide = (aflintc.sqrt(2) * delta * x * aflintc.hyperg_1f1(m + 1, 3 / 2, y2)) / (a * aflintc.gamma(m + 0.5))
        Dim RSide = aflintc.hyperg_1f1(m + 0.5, 0.5, y2) / (aflintc.sqrt(a) * aflintc.gamma(m + 1))
        Dim sum = LSide + RSide
        Dim result = K1 * (sum)
        'Console.WriteLine("result from Acb_T_NC_pdf: ", result)
        If log_p Then result = aflintc.log(result)
        Return result
    End Function


    Function Arb_T_NC_pdf(x As Arb, n As Arb, delta As Arb, log_p As Boolean) As Arb
        Dim m = n / 2
        Dim a = n + x * x
        Dim d2 = delta * delta
        Dim y2 = d2 * x * x / (2 * a)
        Dim K1 = (aflint.pow(n, m) * aflint.gamma(n + 1) * aflint.exp(-0.5 * d2)) / (aflint.pow(2, n) * aflint.pow(a, m) * aflint.gamma(m))
        Dim LSide = (aflint.sqrt(2) * delta * x * aflint.hyperg_1f1(m + 1, 3 / 2, y2)) / (a * aflint.gamma(m + 0.5))
        Dim RSide = aflint.hyperg_1f1(m + 0.5, 0.5, y2) / (aflint.sqrt(a) * aflint.gamma(m + 1))
        Dim sum = LSide + RSide
        Dim result = K1 * (sum)
        If log_p Then result = aflint.log(result)
        Return result
    End Function


    Sub DemoTDensity()
        ArbPrec.SetDps(100)
        Dim x, n, delta, result As New Arb
        Dim arbresult As New Arb
        x = aflint.t(4)
        n = aflint.t(13)
        delta = aflint.t(10)
        'result = aflint.t(dreal.dist_dt_nc(x.AsDouble, n.AsDouble, delta.AsDouble))
        Console.WriteLine("   result: {0}", result)
        result = Arb_T_NC_pdf(x, n, delta, False)
        Console.WriteLine("   result: {0}", result)
        'Dim resultc = Acb_T_NC_pdf(x, n, delta, False)
        'Console.WriteLine("   resultc: {0}", resultc)
    End Sub



    Sub DemoAcbIntegrationFNC()
        'mp4.setprec(100)
        AcbParamsNC(0) = aflintc.t(mp_integral_f_nc)
        Dim x = 3
        Dim m = 10
        Dim n = 20
        Dim lambda = 15
        AcbParamsNC(mp_df1_pos) = aflintc.t(m)
        AcbParamsNC(mp_df2_pos) = aflintc.t(n)
        AcbParamsNC(mp_nc_pos) = aflintc.t(lambda)
        Dim s, a, b As New ArbC
        'Dim workinmrealec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = aflintc.t(0)
        b = aflintc.t(x)
        'Dim rel_goal As UInt32 = workinmrealec
        'Dim abs_tol_bits As UInt32 = workinmrealec
        Dim eval_limit As UInt32 = 0
        's = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)
        'Dim result = dreal.dist_pf_nc(x, m, n, lambda, True)
        'Console.WriteLine("    result: {0}", result)
    End Sub





    Function Acb_F_NC_pdf(x As ArbC, m As ArbC, n As ArbC, lambda As ArbC, log_p As Boolean) As ArbC
        Dim dens0 = Acb_F_pdf(x, m, n, False)
        Dim hyper = aflintc.hyperg_1f1(0.5 * (m + n), 0.5 * m, (m * x * lambda) / (2 * (n + m * x)))
        Dim result = dens0 * aflintc.exp(-lambda / 2) * hyper
        'Console.WriteLine("result from Acb_F_NC_pdf: {0}", result)

        If log_p Then result = aflintc.log(result)
        Return result
    End Function


    Function Arb_F_NC_pdf(x As Arb, m As Arb, n As Arb, lambda As Arb, log_p As Boolean) As Arb
        Dim dens0 = Arb_F_pdf(x, m, n, False)
        Dim hyper = aflint.hyperg_1f1(0.5 * (m + n), 0.5 * m, (m * x * lambda) / (2 * (n + m * x)))
        Dim result = dens0 * aflint.exp(-lambda / 2) * hyper
        If log_p Then result = aflint.log(result)
        Return result
    End Function

    Sub DemoFDensity()
        Dim x, m, n, lambda, result As New Arb
        Dim arbresult, dens0, hyper As New Arb
        x = aflint.t(2)
        m = aflint.t(10)
        n = aflint.t(20)
        lambda = aflint.t(3)
        'result = aflint.t(dreal.dist_df_nc(x.AsDouble, m.AsDouble, n.AsDouble, lambda.AsDouble))
        'Console.WriteLine("   result: {0}", result)
        result = Arb_F_NC_pdf(x, m, n, lambda, False)
        Console.WriteLine("   result: {0}", result)
        'Dim resultc = Acb_F_NC_pdf(x, m, n, lambda, False)
        'Console.WriteLine("   resultc: {0}", resultc)
    End Sub




    Sub DemoAcbIntegrationBetaNC()
        'mp4.setprec(100)
        AcbParamsNC(0) = aflintc.t(mp_integral_beta_nc)
        Dim x = 0.5
        Dim alpha = 10
        Dim beta = 20
        Dim lambda = 30
        AcbParamsNC(mp_df1_pos) = aflintc.t(alpha)
        AcbParamsNC(mp_df2_pos) = aflintc.t(beta)
        AcbParamsNC(mp_nc_pos) = aflintc.t(lambda)
        Dim s, a, b As New ArbC
        'Dim workinmrealec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = aflintc.t(0)
        b = aflintc.t(x)
        'Dim rel_goal As UInt32 = workinmrealec
        'Dim abs_tol_bits As UInt32 = workinmrealec
        Dim eval_limit As UInt32 = 0
        's = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)
        'Dim result = dreal.dist_pbeta_nc(x, alpha, beta, lambda, True)
        'Console.WriteLine("    result: {0}", result)
    End Sub


    Function Acb_Beta_NC_pdf(x As ArbC, a As ArbC, b As ArbC, lambda As ArbC, log_p As Boolean) As ArbC
        Dim dens0 = Acb_Beta_pdf(x, a, b, False)
        Dim hyper = aflintc.hyperg_1f1(a + b, a, (x * lambda) / 2)
        Dim result = dens0 * aflintc.exp(-lambda / 2) * hyper
        'Console.WriteLine("result from Acb_F_NC_pdf: {0}", result)

        If log_p Then result = aflintc.log(result)
        Return result
    End Function


    Function Arb_Beta_NC_pdf(x As Arb, a As Arb, b As Arb, lambda As Arb, log_p As Boolean) As Arb
        Dim dens0 = Arb_Beta_pdf(x, a, b, False)
        Dim hyper = aflint.hyperg_1f1(a + b, a, (x * lambda) / 2)
        Dim result = dens0 * aflint.exp(-lambda / 2) * hyper
        If log_p Then result = aflint.log(result)
        Return result
    End Function




    Sub DemoBetaDensity()
        Dim x, a, b, lambda, result As New Arb
        Dim arbresult, dens0, hyper As New Arb
        x = aflint.t(0.5)
        a = aflint.t(10)
        b = aflint.t(20)
        lambda = aflint.t(3)
        'result = aflint.t(dreal.dist_dbeta_nc(x.AsDouble, a.AsDouble, b.AsDouble, lambda.AsDouble))
        'Console.WriteLine("   result: {0}", result)
        result = Arb_Beta_NC_pdf(x, a, b, lambda, False)
        Console.WriteLine("   result: {0}", result)
        'Dim resultc = Acb_Beta_NC_pdf(x, a, b, lambda, False)
        'Console.WriteLine("   resultc: {0}", resultc)
    End Sub



    Sub DemoAcbIntegrationRho()
        'mp4.setprec(100)
        AcbParamsNC(0) = aflintc.t(mp_integral_rho)
        Dim r = aflint.t(0.9)
        Dim N = aflint.t(25)  ' 35 already crashes
        Dim rho = aflint.t(0.9)
        AcbParamsNC(mp_df1_pos) = aflintc.t(N)
        AcbParamsNC(mp_nc_pos) = aflintc.t(rho)
        Dim s, a, b As New ArbC
        'Dim workinmrealec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = aflintc.t(0)
        b = aflintc.t(r)
        'Dim rel_goal As UInt32 = workinmrealec
        'Dim abs_tol_bits As UInt32 = workinmrealec
        Dim eval_limit As UInt32 = 0
        's = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)
        Dim Pr0 = aflint.ibeta(0.5, 0.5 * (N - 1), rho * rho)
        Pr0 = 0.5 * (1 + aflint.sign(rho) * Pr0)
        Dim resultint = 1 - (Pr0 - s)
        Console.WriteLine("resultint:{0}", resultint)
        Dim result = RhoExplicit_Arb(aflint.lrint(N), r, rho)
        Console.WriteLine("   result: {0}", result)
        Dim LeftTail, RightTail As Double
        RhoDisN_Guenther(N.AsDouble, r.AsDouble, rho.AsDouble, LeftTail, RightTail)
        Console.WriteLine("LeftTail:   {0}, RightTail: {1}", LeftTail, RightTail)

    End Sub


    Function Acb_Rho_pdf(n As Long, r As ArbC, rho As ArbC) As ArbC
        Dim w As ArbC, t As ArbC
        Dim x As ArbC, x2 As ArbC, r2 As ArbC, Rho2 As ArbC, U As ArbC, k1 As ArbC
        Dim A2 As ArbC, a As ArbC, c2 As ArbC, C As ArbC, b2 As ArbC, b As ArbC
        Dim ACTerm As ArbC, density As ArbC
        r2 = r * r : Rho2 = rho * rho
        x = r * rho : x2 = x * x : w = 0.5 * (1 + x)
        A2 = 1 - Rho2 : a = aflintc.sqrt(A2)
        c2 = 1 - r2 : C = aflintc.sqrt(c2)
        b2 = 1 - x2 : b = aflintc.sqrt(b2)
        U = aflintc.acos(-x) / b
        k1 = ((n - 2) / aflintc.sqrt(2 * aflint.pi())) * aflintc.exp(aflintc.lgamma(n - 1) - aflintc.lgamma(n - 0.5))
        ACTerm = aflintc.exp(aflintc.log(a) * (n - 1) + aflintc.log(C) * (n - 4) + aflintc.log(1 - x) * (1.5 - n))
        t = aflintc.hyperg_2f1(0.5, 0.5, n - 0.5, w)
        density = k1 * ACTerm * t
        Return density
    End Function

    Function Arb_Rho_pdf(n As Long, r As Arb, rho As Arb) As Arb
        Dim w As Arb, t As Arb
        Dim x As Arb, x2 As Arb, r2 As Arb, Rho2 As Arb, U As Arb, k1 As Arb
        Dim A2 As Arb, a As Arb, c2 As Arb, C As Arb, b2 As Arb, b As Arb
        Dim ACTerm As Arb, density As Arb
        r2 = r * r : Rho2 = rho * rho
        x = r * rho : x2 = x * x : w = 0.5 * (1 + x)
        A2 = 1 - Rho2 : a = aflint.sqrt(A2)
        c2 = 1 - r2 : C = aflint.sqrt(c2)
        b2 = 1 - x2 : b = aflint.sqrt(b2)
        U = aflint.acos(-x) / b
        k1 = ((n - 2) / aflint.sqrt(2 * aflint.pi())) * aflint.exp(aflint.lgamma(n - 1) - aflint.lgamma(n - 0.5))
        ACTerm = aflint.exp(aflint.log(a) * (n - 1) + aflint.log(C) * (n - 4) + aflint.log(1 - x) * (1.5 - n))
        t = aflint.hyperg_2f1(0.5, 0.5, n - 0.5, w)
        density = k1 * ACTerm * t
        Return density
    End Function

    Sub DemoPearsonRhoDensity()
        Dim n As Long
        Dim r, rho, result As New Arb
        n = 10
        r = aflint.t(0.5)
        rho = aflint.t(0.25)
        result = aflint.t(RhoDensity_2(n, r.AsDouble, rho.AsDouble))
        Console.WriteLine("     result: {0}", result)
        result = Arb_Rho_pdf(n, r, rho)
        Console.WriteLine("     result: {0}", result)
        Dim resultc = Acb_Rho_pdf(n, aflintc.t(r), aflintc.t(rho))
        Console.WriteLine("   resultc: {0}", resultc)
        Dim resultd = RhoDensityDirect(n, r, rho)
        Console.WriteLine("    resultd: {0}", resultd)
        Dim resulte = Acb_RhoDensityDirect(n, aflintc.t(r), aflintc.t(rho))
        Console.WriteLine("   resulte: {0}", resulte)
    End Sub



    Sub DemoAcbIntegrationRho2()
        'mp4.setprec(100)
        AcbParamsNC(0) = aflintc.t(mp_integral_rho2)
        Dim R2 = 0.41
        Dim p = 4
        Dim N = 100  ' crashes for 1000
        Dim Rho2 = 0.3
        AcbParamsNC(mp_df1_pos) = aflintc.t(p)
        AcbParamsNC(mp_df2_pos) = aflintc.t(N)
        AcbParamsNC(mp_nc_pos) = aflintc.t(Rho2)
        Dim s, a, b As New ArbC
        'Dim workinmrealec As UInt32 = mp4.getprec()
        Dim verbose As UInt32 = 2
        a = aflintc.t(0)
        b = aflintc.t(R2)
        'Dim rel_goal As UInt32 = workinmrealec
        'Dim abs_tol_bits As UInt32 = workinmrealec
        Dim eval_limit As UInt32 = 0
        's = aflintc.gl_integration(AddressOf WrapperParams_GL_NC, a, b, AcbParamsNC, workinmrealec, verbose, rel_goal, abs_tol_bits, eval_limit)
        'Console.WriteLine("Integral: {0}", s)
        Dim result = Rho2DisN8(False, p, N, R2, Rho2)
        Console.WriteLine("    result: {0}", result)
    End Sub

    Function Acb_Rho2_pdf(x As ArbC, p As ArbC, N As ArbC, rho2 As ArbC, log_p As Boolean) As ArbC
        'see Gurland 1968
        Dim PP = p + 1
        Dim NN = N + p + 1
        Dim n1 = NN - 1
        Dim dens0 = Acb_Beta_pdf(x, 0.5 * (PP - 1), 0.5 * (NN - PP), False)
        Dim hyper = aflintc.hyperg_2f1(0.5 * n1, 0.5 * n1, 0.5 * (PP - 1), rho2 * x)
        'Dim result = dens0 * (1 - rho2) ^ (n1 / 2) * hyper
        Dim result = dens0 * aflintc.pow((1 - rho2), (n1 / 2)) * hyper
        If log_p Then result = aflintc.log(result)
        Return result
    End Function


    Function Arb_Rho2_pdf(x As Arb, p As Arb, N As Arb, rho2 As Arb, log_p As Boolean) As Arb
        'see Gurland 1968
        Dim PP = p + 1
        Dim NN = N + p + 1
        Dim n1 = NN - 1
        Dim dens0 = Arb_Beta_pdf(x, 0.5 * (PP - 1), 0.5 * (NN - PP), False)
        Dim hyper = aflint.hyperg_2f1(0.5 * n1, 0.5 * n1, 0.5 * (PP - 1), rho2 * x)
        Dim result = dens0 * aflint.pow((1 - rho2), (n1 / 2)) * hyper
        If log_p Then result = aflint.log(result)
        Return result
    End Function

    Sub DemoR2Density()
        Dim result1d, result2d As Double
        Dim p, n As Double
        Dim x, rho2, result1, result2, xdiff, dens As New Arb
        p = 11
        n = 20
        x = aflint.t(0.125)
        rho2 = aflint.t(0.25)
        xdiff = aflint.t(0.000001)
        result1d = Rho2DisN8(False, p, n, x.AsDouble, rho2.AsDouble)
        'Console.WriteLine("   result1: {0}", result1)
        result2d = Rho2DisN8(False, p, n, x.AsDouble + xdiff.AsDouble, rho2.AsDouble)
        'Console.WriteLine("   result2: {0}", result2)
        dens = (result2d - result1d) / xdiff
        Console.WriteLine("     dens: {0}", dens)

        Dim result = Arb_Rho2_pdf(x, aflint.t(p), aflint.t(n), rho2, False)
        Console.WriteLine("   result: {0}", result)
        Dim resultc = Acb_Rho2_pdf(aflintc.t(x), aflintc.t(p), aflintc.t(n), aflintc.t(rho2), False)
        Console.WriteLine("   resultc: {0}", resultc)
    End Sub


    Public Sub DemoNoncentralPdf()
        DemoChiSquareDensity()
        DemoTDensity()
        DemoFDensity()
        DemoBetaDensity()
        DemoPearsonRhoDensity()
        DemoR2Density()
    End Sub

    Public Sub DemoNoncentralCDF()
        DemoAcbIntegrationChiSquare()
        DemoAcbIntegrationChiSquareNC()
        DemoAcbIntegrationTNC()
        DemoAcbIntegrationFNC()
        DemoAcbIntegrationBetaNC()
        DemoAcbIntegrationRho()
        DemoAcbIntegrationRho2()
    End Sub


    Public Sub DemoDistFromBoost()
        ArbPrec.SetDps(30)
        Dim x, y, a, b As Double
        a = 12
        x = 13.125

        Dim a_arb = aflint.t(a)
        Dim x_arb = aflint.t(x)

        Console.WriteLine("aflint.gamma_p_derivative:   {0}", aflint.gamma_p_derivative(a_arb, x_arb))
        Console.WriteLine("boost.gamma_p_derivative:  {0}", dreal.real_gamma_p_prime(a, x))

        Console.WriteLine("gamma_lower_r: {0}", aflint.real_gamma_lower(a_arb, x_arb))
        Console.WriteLine("boost.gamma_p:  {0}", dreal.real_gamma_lower(a, x))
        Console.WriteLine("gamma_upper_r: {0}", aflint.real_gamma_upper(a, x))
        Console.WriteLine("boost.gamma_q:  {0}", dreal.real_gamma_upper(a, x))
        Console.WriteLine("")

        x = 0.25
        y = 1 - x
        a = 12
        b = 23

        x_arb = aflint.t(x)
        Dim y_arb = aflint.t(y)
        a_arb = aflint.t(a)
        Dim b_arb = aflint.t(b)


        Console.WriteLine("beta:        {0}", aflint.real_beta(a, b))
        Console.WriteLine("boost.beta:   {0}", dreal.real_beta(a, b))
        Console.WriteLine("aflint.ibeta_derivative:   {0}", aflint.real_ibeta_prime(a, b, x))
        Console.WriteLine("boost.ibeta_derivative:  {0}", dreal.real_ibeta_prime(a, b, x))
        Console.WriteLine("aflint.ibeta:   {0}", aflint.real_ibeta(a, b, x))
        Console.WriteLine("boost.ibeta:  {0}", dreal.real_ibeta(a, b, x))
        Console.WriteLine("aflint.ibetac:  {0}", aflint.real_ibetac(a, b, x))
        Console.WriteLine("boost.ibetac: {0}", dreal.real_ibetac(a, b, x))
        Console.WriteLine("")

        'Console.WriteLine("dbeta(x=0.77, a=10.6, b=1.8):  {0}", dreal.dist_dbeta(0.5, 10.6, 1.8, False))
        Console.WriteLine("dbeta(x=0.77, a=10.6, b=1.8): {0}", Arb_Beta_pdf(aflint.t(0.5), aflint.t(10.6), aflint.t(1.8), False))
        'Console.WriteLine("pbeta(x=0.77, a=10.6, b=1.8):  {0}", dreal.dist_pbeta(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("pbeta(x=0.77, a=10.6, b=1.8): {0}", Arb_Beta_CDF(aflint.t(0.5), aflint.t(10.6), aflint.t(1.8), False, False))
        'Console.WriteLine("qbeta(p=0.5, a=10.6, b=1.8): {0}", dreal.dist_qbeta(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dbinom(k=7, n=11, p=0.1):  {0}", dreal.dist_dbinom(7, 11, 0.125, False))
        Console.WriteLine("dbinom(k=7, n=11, p=0.1): {0}", Arb_Binom_pdf(aflint.t(7), aflint.t(11), aflint.t(0.125), False))
        'Console.WriteLine("pbinom(k=7, n=11, p=0.1):  {0}", dreal.dist_pbinom(7, 11, 0.125, False, False))
        Console.WriteLine("pbinom(k=7, n=11, p=0.1): {0}", Arb_Binom_CDF(aflint.t(7), aflint.t(11), aflint.t(0.125), False, False))
        'Console.WriteLine("qbinom(p=0.5, size=11, prob=0.1): {0}", dreal.dist_qbinom(0.5, 11, 0.4, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5):  {0}", dreal.dist_dcauchy(10.2, 0.0, 0.5, False))
        Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5): {0}", Arb_Cauchy_pdf(aflint.t(10.2), aflint.t(0.0), aflint.t(0.5), False))
        'Console.WriteLine("pcauchy(x=10.2, a=0.0, b=0.5):  {0}", dreal.dist_pcauchy(10.2, 0.0, 0.5, False, False))
        Console.WriteLine("dcauchy(x=10.2, a=0.0, b=0.5): {0}", Arb_Cauchy_CDF(aflint.t(10.2), aflint.t(0.0), aflint.t(0.5), False, False))
        'Console.WriteLine("qcauchy(p=0.75, a=10.125, b=0.5): {0}", dreal.dist_qcauchy(0.75, 10.125, 0.5, False, False))
        Console.WriteLine("dcauchy(p=0.75, a=10.125, b=0.5): {0}", Arb_Cauchy_ICDF(aflint.t(0.75), aflint.t(10.125), aflint.t(0.5), False, False))
        Console.WriteLine("")

        'Console.WriteLine("dchisq(x=10.2, nu=10.0):  {0}", dreal.dist_dchisq(10.2, 10.0, False))
        Console.WriteLine("dchisq(x=10.2, nu=10.0): {0}", Arb_ChiSquare_pdf(aflint.t(10.2), aflint.t(10.0), False))
        'Console.WriteLine("pchisq(x=10.2, nu=10.0):  {0}", dreal.dist_pchisq(10.2, 10.0, False, False))
        Console.WriteLine("pchisq(x=10.2, nu=10.0): {0}", Arb_ChiSquare_CDF(aflint.t(10.2), aflint.t(10.0), False, False))
        'Console.WriteLine("qchisq(p=0.5, nu=10.0): {0}", dreal.dist_qchisq(0.5, 10.0, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dexp(x=10.2, lambda=10.0):  {0}", dreal.dist_dexp(10.25, 10.125, False))
        Console.WriteLine("dexp(x=10.2, lambda=10.0): {0}", Arb_Exp_pdf(aflint.t(10.25), aflint.t(10.125), False))
        'Console.WriteLine("pexp(x=10.2, lambda=10.0):  {0}", dreal.dist_pexp(10.25, 10.125, False, False))
        Console.WriteLine("pexp(x=10.2, lambda=10.0): {0}", Arb_Exp_CDF(aflint.t(10.25), aflint.t(10.125), False, False))
        'Console.WriteLine("qexp(p=0.5, lambda=10.0):  {0}", dreal.dist_qexp(aflint.t(0.5), aflint.t(10.0), False, False))
        Console.WriteLine("qexp(p=0.5, lambda=10.0): {0}", Arb_Exp_ICDF(aflint.t(0.5), aflint.t(10.0), False, False))
        Console.WriteLine("")

        'Console.WriteLine("dgumbel(x=10.2, a=2.0, b=0.5):  {0}", dreal.dist_dgumbel(10.25, 2.0, 0.5, False))
        Console.WriteLine("dgumbel(x=10.2, a=2.0, b=0.5): {0}", Arb_Gumbel_pdf(aflint.t(10.25), aflint.t(2.0), aflint.t(0.5), False))
        'Console.WriteLine("pgumbel(x=10.2, a=2.0, b=0.5):  {0}", dreal.dist_pgumbel(10.25, 2.0, 0.5, False, False))
        Console.WriteLine("pgumbel(x=10.2, a=2.0, b=0.5): {0}", Arb_Gumbel_CDF(aflint.t(10.25), aflint.t(2.0), aflint.t(0.5), False, False))
        'Console.WriteLine("qgumbel(p=0.5, a=2.0, b=0.5):  {0}", dreal.dist_qgumbel(0.5, 2.0, 0.5, False, False))
        Console.WriteLine("qgumbel(p=0.5, a=2.0, b=0.5): {0}", Arb_Gumbel_ICDF(aflint.t(0.5), aflint.t(2.0), aflint.t(0.5), False, False))
        Console.WriteLine("")

        'Console.WriteLine("df(x=10.77, a=10.6, b=1.8):  {0}", dreal.dist_df(10.5, 10.6, 1.8, False))
        Console.WriteLine("df(x=10.77, a=10.6, b=1.8): {0}", Arb_F_pdf(aflint.t(10.5), aflint.t(10.6), aflint.t(1.8), False))
        'Console.WriteLine("pf(x=10.77, a=10.6, b=1.8):  {0}", dreal.dist_pf(10.5, 10.6, 1.8, False, False))
        Console.WriteLine("pf(x=10.77, a=10.6, b=1.8): {0}", Arb_F_CDF(aflint.t(10.5), aflint.t(10.6), aflint.t(1.8), False, False))
        'Console.WriteLine("qf(p=0.5, a=10.6, b=1.8): {0}", dreal.dist_qf(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dgamma(x=10.77, a=10.6, b=1.8):  {0}", dreal.dist_dgamma(10.5, 10.6, 1.8, False))
        Console.WriteLine("dgamma(x=10.77, a=10.6, b=1.8): {0}", Arb_Gamma_pdf(aflint.t(10.5), aflint.t(10.6), aflint.t(1.8), False))
        'Console.WriteLine("pgamma(x=10.77, a=10.6, b=1.8):  {0}", dreal.dist_pgamma(10.5, 10.6, 1.8, False, False))
        Console.WriteLine("pgamma(x=10.77, a=10.6, b=1.8): {0}", Arb_Gamma_CDF(aflint.t(10.5), aflint.t(10.6), aflint.t(1.8), False, False))
        'Console.WriteLine("qgamma(p=0.5, a=10.6, b=1.8): {0}", dreal.dist_qgamma(0.5, 10.6, 1.8, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dgeom(x=2, lambda=0.125:  {0}", dreal.dist_dgeom(2, 0.75, False))
        Console.WriteLine("dgeom(x=2, lambda=0.125: {0}", Arb_Geom_pdf(aflint.t(2), aflint.t(0.75), False))
        'Console.WriteLine("pgeom(x=2, lambda=0.1:  {0}", dreal.dist_pgeom(2, 0.75, False, False))
        Console.WriteLine("pgeom(x=2, lambda=0.1: {0}", Arb_Geom_CDF(aflint.t(2), aflint.t(0.75), False, False))
        'Console.WriteLine("qgeom(p=0.5, lambda=0.1:  {0}", dreal.dist_qgeom(aflint.t(0.5), aflint.t(0.1), False, False))
        Console.WriteLine("qgeom(p=0.5, lambda=0.1: {0}", Arb_Geom_ICDF(aflint.t(0.5), aflint.t(0.1), False, False))
        Console.WriteLine("")

        'Console.WriteLine("dinvchisq(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_dinvchisq(1.5, 2.0, 3.0, False))
        Console.WriteLine("dinvchisq(x=11.5, df=2.0, scale=3.0): {0}", Arb_Invchisq_pdf(aflint.t(1.5), aflint.t(2.0), aflint.t(3.0), False))
        'Console.WriteLine("pinvchisq(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_pinvchisq(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("pinvchisq(x=11.5, df=2.0, scale=3.0): {0}", Arb_Invchisq_CDF(aflint.t(1.5), aflint.t(2.0), aflint.t(3.0), False, False))
        'Console.WriteLine("qinvchisq(p=0.5, df=2.0, scale=3.0): {0}", dreal.dist_qinvchisq(0.5, 2.0, 3.0, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dinvgamma(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_dinvgamma(1.5, 2.0, 3.0, False))
        Console.WriteLine("dinvgamma(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGamma_pdf(aflint.t(1.5), aflint.t(2.0), aflint.t(3.0), False))
        'Console.WriteLine("pinvgamma(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_pinvgamma(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("pinvgamma(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGamma_CDF(aflint.t(1.5), aflint.t(2.0), aflint.t(3.0), False, False))
        'Console.WriteLine("qinvgamma(p=0.5, df=2.0, scale=3.0): {0}", dreal.dist_qinvgamma(0.5, 2.0, 3.0, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dinvgauss(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_dinvgauss(1.5, 2.0, 3.0, False))
        Console.WriteLine("dinvgauss(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGauss_pdf(aflint.t(1.5), aflint.t(2.0), aflint.t(3.0), False))
        'Console.WriteLine("pinvgauss(x=11.5, df=2.0, scale=3.0):  {0}", dreal.dist_pinvgauss(1.5, 2.0, 3.0, False, False))
        Console.WriteLine("pinvgauss(x=11.5, df=2.0, scale=3.0): {0}", Arb_InvGauss_CDF(aflint.t(1.5), aflint.t(2.0), aflint.t(3.0), False, False))
        'Console.WriteLine("qinvgauss(p=0.5, df=2.0, scale=3.0): {0}", dreal.dist_pinvgauss(0.5, 2.0, 3.0, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dlaplace(x=5.7, a=-5.0, b=4.0):  {0}", dreal.dist_dlaplace(5.7, -5.0, 4.0, False))
        Console.WriteLine("dlaplace(x=5.7, a=-5.0, b=4.0): {0}", Arb_Laplace_pdf(aflint.t(5.7), aflint.t(-5.0), aflint.t(4.0), False))
        'Console.WriteLine("plaplace(x=5.7, a=-5.0, b=4.0):  {0}", dreal.dist_plaplace(5.7, -5.0, 4.0, False, False))
        Console.WriteLine("plaplace(x=5.7, a=-5.0, b=4.0): {0}", Arb_Laplace_CDF(aflint.t(5.7), aflint.t(-5.0), aflint.t(4.0), False, False))
        'Console.WriteLine("qlaplace(p=0.5, a=-5.0, b=4.0):  {0}", dreal.dist_qlaplace(0.6, -5.0, 4.0, False, False))
        Console.WriteLine("qlaplace(p=0.5, a=-5.0, b=4.0): {0}", Arb_Laplace_ICDF(aflint.t(0.6), aflint.t(-5.0), aflint.t(4.0), False, False))
        Console.WriteLine("")

        'Console.WriteLine("dlogis(x=4.3, a=9.1, b=3.2):  {0}", dreal.dist_dlogis(4.3, 9.1, 3.2, False))
        Console.WriteLine("dlogis(x=4.3, a=9.1, b=3.2): {0}", Arb_Logistic_pdf(aflint.t(4.3), aflint.t(9.1), aflint.t(3.2), False))
        'Console.WriteLine("plogis(x=4.3, a=9.1, b=3.2):  {0}", dreal.dist_plogis(4.3, 9.1, 3.2, False, False))
        Console.WriteLine("plogis(x=4.3, a=9.1, b=3.2): {0}", Arb_Logistic_CDF(aflint.t(4.3), aflint.t(9.1), aflint.t(3.2), False, False))
        'Console.WriteLine("qlogis(p=0.5, a=9.1, b=3.2):  {0}", dreal.dist_qlogis(0.5, 9.1, 3.2, False, False))
        Console.WriteLine("qlogis(p=0.5, a=9.1, b=3.2): {0}", Arb_Logistic_ICDF(aflint.t(0.5), aflint.t(9.1), aflint.t(3.2), False, False))
        Console.WriteLine("")

        'Console.WriteLine("dlnorm(x=0.4, a=0.0, b=1.0):  {0}", dreal.dist_dlnorm(0.4, 3.0, 1.0, False))
        Console.WriteLine("dlnorm(x=0.4, a=0.0, b=1.0): {0}", Arb_LogNormal_pdf(aflint.t(0.4), aflint.t(3.0), aflint.t(1.0), False))
        'Console.WriteLine("plnorm(x=0.4, a=0.0, b=1.0): {0}", dreal.dist_plnorm(0.4, 3.0, 1.0, False, False))
        Console.WriteLine("plnorm(x=0.4, a=0.0, b=1.0): {0}", Arb_LogNormal_CDF(aflint.t(0.4), aflint.t(3.0), aflint.t(1.0), False, False))
        'Console.WriteLine("qlnorm(p=0.5, a=0.0, b=1.0): {0}", dreal.dist_qlnorm(0.5, 3.0, 1.0, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dnbinom(x=4, a=20, prob=0.7):  {0}", dreal.dist_dnbinom(4, 20, 0.7, False))
        Console.WriteLine("dnbinom(x=4, a=20, prob=0.7): {0}", Arb_Nbinom_pdf(aflint.t(4), aflint.t(20), aflint.t(0.7), False))
        'Console.WriteLine("pnbinom(x=4, a=20, prob=0.7):  {0}", dreal.dist_pnbinom(4, 20, 0.7, False, False))
        Console.WriteLine("pnbinom(x=4, a=20, prob=0.7): {0}", Arb_Nbinom_CDF(aflint.t(4), aflint.t(20), aflint.t(0.7), False, False))
        'Console.WriteLine("qnbinom(p=0.5, a=20, prob=0.7): {0}", dreal.dist_qnbinom(0.5, 20, 0.7, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dnorm(x=0.4, mu=-2.0, std=0.5):  {0}", dreal.dist_dnorm(0.4, -2.0, 0.5, False))
        Console.WriteLine("dnorm(x=0.4, mu=-2.0, std=0.5): {0}", Arb_Normal_pdf(aflint.t(0.4), aflint.t(-2.0), aflint.t(0.5), False))
        'Console.WriteLine("pnorm(x=0.4, mu=-2.0, std=0.5):  {0}", dreal.dist_pnorm(0.4, -2.0, 0.5, False, False))
        Console.WriteLine("pnorm(x=0.4, mu=-2.0, std=0.5): {0}", Arb_Normal_CDF(aflint.t(0.4), aflint.t(-2.0), aflint.t(0.5), False, False))
        'Console.WriteLine("qnorm(p=0.5, mu=-2.0, std=0.5): {0}", dreal.dist_qnorm(0.5, -2.0, 0.5, False, False))
        Console.WriteLine("")

        'Console.WriteLine("dpareto(x=3.4, shape=3.0, scale=1.0):  {0}", dreal.dist_dpareto(3.4, 3.0, 1.0, False))
        Console.WriteLine("dpareto(x=3.4, shape=3.0, scale=1.0): {0}", Arb_Pareto_pdf(aflint.t(3.4), aflint.t(3.0), aflint.t(1.0), False))
        'Console.WriteLine("ppareto(x=3.4, shape=3.0, scale=1.0):  {0}", dreal.dist_ppareto(3.4, 3.0, 1.0, False, False))
        Console.WriteLine("ppareto(x=3.4, shape=3.0, scale=1.0): {0}", Arb_Pareto_CDF(aflint.t(3.4), aflint.t(3.0), aflint.t(1.0), False, False))
        'Console.WriteLine("qpareto(p=0.5, shape=3.0, scale=1.0):  {0}", dreal.dist_qpareto(0.5, 3.0, 1.0, False, False))
        Console.WriteLine("qpareto(p=0.5, shape=3.0, scale=1.0): {0}", Arb_Pareto_ICDF(aflint.t(0.5), aflint.t(3.0), aflint.t(1.0), False, False))
        Console.WriteLine("")

        'Console.WriteLine("dpois(x=11, lambda=4.0):  {0}", dreal.dist_dpois(11, 4.0, False))
        Console.WriteLine("dpois(x=11, lambda=4.0): {0}", Arb_Poisson_pdf(aflint.t(11), aflint.t(4.0), False))
        'Console.WriteLine("ppois(x=11, lambda=4.0):  {0}", dreal.dist_ppois(11, 4.0, False, False))
        Console.WriteLine("ppois(x=11, lambda=4.0): {0}", Arb_Poisson_CDF(aflint.t(11), aflint.t(4.0), False, False))
        'Console.WriteLine("qpois(p=0.5, lambda=4.0): {0}", dreal.dist_ppois(0.5, 4.0, False, False))
        Console.WriteLine("")

        'Console.WriteLine("drayleigh(x=6.3, nu=1.1):  {0}", dreal.dist_drayleigh(6.3, 1.1, False))
        Console.WriteLine("drayleigh(x=6.3, nu=1.1): {0}", Arb_RayLeigh_pdf(aflint.t(6.3), aflint.t(1.1), False))
        'Console.WriteLine("prayleigh(x=6.3, nu=1.1):  {0}", dreal.dist_prayleigh(aflint.t(6.3), aflint.t(1.1), False, False))
        Console.WriteLine("prayleigh(x=6.3, nu=1.1): {0}", Arb_RayLeigh_CDF(aflint.t(6.3), aflint.t(1.1), False, False))
        'Console.WriteLine("qrayleigh(p=0.5, nu=1.1):  {0}", dreal.dist_qrayleigh(aflint.t(0.5), aflint.t(1.1), False, False))
        Console.WriteLine("qrayleigh(p=0.5, nu=1.1): {0}", Arb_RayLeigh_ICDF(aflint.t(0.5), aflint.t(1.1), False, False))
        Console.WriteLine("")



        'Console.WriteLine("dt(x=11, nu=5.0):  {0}", dreal.dist_dt(11, 6.0, False))
        Console.WriteLine("dt(x=11, nu=5.0): {0}", Arb_T_pdf(aflint.t(11), aflint.t(6.0), False))
        'Console.WriteLine("pt(x=11, nu=5.0):  {0}", dreal.dist_pt(11, 6.0, False, False))
        Console.WriteLine("pt(x=11, nu=5.0): {0}", Arb_T_CDF(aflint.t(11), aflint.t(6.0), False, False))
        'Console.WriteLine("qt(p=0.5, nu=5.0): {0}", dreal.dist_qt(0.5, 6.0, False, False))
        Console.WriteLine("")

        ''Console.WriteLine("dtriangular(x=0.77, lower=0.0, mode=1.0, upper=4.0): {0}", dreal.dist_dtriangular(0.77, -2, 0, 3, False))
        ''Console.WriteLine("ptriangular(x=0.77, lower=0.0, mode=1.0, upper=4.0): {0}", dreal.dist_ptriangular(0.77, -2, 0, 3, False, False))
        ''Console.WriteLine("qtriangular(p=0.5, lower=0.0, mode=1.0, upper=4.0): {0}", dreal.dist_qtriangular(0.5, -2, 0, 3, False, False))
        ''Console.WriteLine("")

        'Console.WriteLine("dunif(x=0.77, lower=-2.0,  upper=3.0):  {0}", dreal.dist_dunif(0.77, -2, 3, False))
        Console.WriteLine("dunif(x=0.77, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_pdf(aflint.t(0.77), aflint.t(-2), aflint.t(3), False))
        'Console.WriteLine("punif(x=0.77, lower=-2.0,  upper=3.0):  {0}", dreal.dist_punif(0.77, -2, 3, False, False))
        Console.WriteLine("punif(x=0.77, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_CDF(aflint.t(0.77), aflint.t(-2), aflint.t(3), False, False))
        'Console.WriteLine("qunif(p=0.5, lower=-2.0,  upper=3.0): {0}", dreal.dist_qunif(0.5, -2, 3, False, False))
        Console.WriteLine("qunif(p=0.5, lower=-2.0,  upper=3.0): {0}", Arb_Uniform_ICDF(aflint.t(0.5), aflint.t(-2), aflint.t(3), False, False))
        Console.WriteLine("")

        'Console.WriteLine("dweibull(x=0.77, shape=0.5, scale=1.0):  {0}", dreal.dist_dweibull(0.77, 0.5, 1, False))
        Console.WriteLine("dweibull(x=0.77, shape=0.5, scale=1.0): {0}", Arb_Weibull_pdf(aflint.t(0.77), aflint.t(0.5), aflint.t(1), False))
        'Console.WriteLine("pweibull(x=0.77, shape=0.5, scale=1.0):  {0}", dreal.dist_pweibull(0.77, 0.5, 1, False, False))
        Console.WriteLine("pweibull(x=0.77, shape=0.5, scale=1.0): {0}", Arb_Weibull_CDF(aflint.t(0.77), aflint.t(0.5), aflint.t(1), False, False))
        'Console.WriteLine("qweibull(p=0.5, shape=0.5, scale=1.0):  {0}", dreal.dist_qweibull(0.5, 0.5, 1, False, False))
        Console.WriteLine("qweibull(p=0.5, shape=0.5, scale=1.0): {0}", Arb_Weibull_ICDF(aflint.t(0.5), aflint.t(0.5), aflint.t(1), False, False))
        Console.WriteLine("")


        '****************************************************************************************		
        '****************************************************************************************		


        'Console.WriteLine("dhyper(x=10, r=50, n=30, NN=500): {0}", dreal.dist_dhyper(10, 50, 30, 500, False))
        'Console.WriteLine("phyper(x=10, r=50, n=30, NN=500): {0}", dreal.dist_phyper(10, 50, 30, 500, False, False))
        'Console.WriteLine("qhyper(p=0.5, r=50, n=30, NN=500): {0}", dreal.dist_qhyper(0.5, 50, 30, 500, False, False))
        'Console.WriteLine("")


        'Console.WriteLine("dskewnormal(x=0.77, a=0.0, b=1.0, nc=4.0): {0}", dreal.dist_dskewnormal(0.77, 0, 1, 4, False))
        'Console.WriteLine("pskewnormal(x=0.77, a=0.0, b=1.0, nc=4.0): {0}", dreal.dist_pskewnormal(0.77, 0, 1, 4, False, False))
        'Console.WriteLine("qskewnormal(p=0.5, a=0.0, b=1.0, nc=4.0): {0}", dreal.dist_qskewnormal(0.5, 0, 1, 4, False, False))
        'Console.WriteLine("")


        'Console.WriteLine("dbeta_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_dbeta_nc(0.77, 3.0, 12.0, 30.0, False))
        'Console.WriteLine("pbeta_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_pbeta_nc(0.77, 3.0, 12.0, 30.0, False, False))
        'Console.WriteLine("qbeta_nc(p=0.5, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_qbeta_nc(0.5, 3.0, 12.0, 30.0, False, False))
        'Console.WriteLine("")

        'Console.WriteLine("dchisq_nc(x=4.23, nu=3.0,  nc=30.0): {0}", dreal.dist_dchisq_nc(4.23, 3.0, 30.0, False))
        'Console.WriteLine("pchisq_nc(x=4.23, nu=3.0,  nc=30.0): {0}", dreal.dist_pchisq_nc(4.23, 3.0, 30.0, False, False))
        'Console.WriteLine("qbinom(p=0.5, size=11, prob=0.1): {0}", dreal.dist_qbinom(0.5, 11, 0.4, False, False))
        'Console.WriteLine("")

        'Console.WriteLine("df_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_df_nc(0.77, 3.0, 12.0, 30.0, False))
        'Console.WriteLine("pf_nc(x=0.77, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_pf_nc(0.77, 3.0, 12.0, 30.0, False, False))
        'Console.WriteLine("qf_nc(p=0.5, a=3.0, b=12.0, nc=30.0): {0}", dreal.dist_qf_nc(0.5, 3.0, 12.0, 30.0, False, False))
        'Console.WriteLine("")

        'Console.WriteLine("dt_nc(x=4.23, nu=2.0,  nc=-5.0): {0}", dreal.dist_dt_nc(4.23, 2.0, -5.0, False))
        'Console.WriteLine("pt_nc(x=4.23, nu=2.0,  nc=-5.0): {0}", dreal.dist_pt_nc(4.23, 2.0, -5.0, False, False))
        'Console.WriteLine("qt_nc(p=0.5, nu=2.0,  nc=-5.0): {0}", dreal.dist_qt_nc(0.5, 2.0, -5.0, False, False))
        'Console.WriteLine("")


    End Sub





End Module
