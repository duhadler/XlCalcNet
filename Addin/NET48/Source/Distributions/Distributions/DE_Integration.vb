Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet


Module Module1

    Public Delegate Function aflintFunction(x As Arb) As Arb

    Public Delegate Function apcFunction(x As ArbC) As ArbC


    'wolfram alpha: integrate sin(exp(x))/sqrt(x) from 0 to 2 = 1.50572...
    Sub Calc_Integration(a As Arb, b As Arb, epsabsStart As Arb, alpha As Arb, beta As Arb)
        Console.WriteLine("Test_Integration")

        Dim pi = aflint.pi
        Dim p2 = pi / 2
        Dim zero = aflint.t(0)
        Dim one = aflint.t(1)

        Dim hmin = zero : Dim C1Final = zero : Dim epsabsFinal = zero
        Dim ds, radX, radY As String
        Dim nmin = aflint.t("1E1000000000000")

        Dim mu = beta
        Dim nu = alpha
        If alpha < beta Then
            mu = alpha
            nu = beta
        End If
        Dim ab1 = alpha + beta - 1

        'Determine optimal h and n
        For d1 As Integer = 1 To 26
            GetRectAndK(d1, radX, radY, ds)
            Dim d = aflint.t(ds)
            '           Console.WriteLine("radX: {0:f}, radY: {1:f}, d: {2:f}", radX, radY, d)
            Dim radX_ = aflint.t(radX)
            Dim radY_ = aflint.t(radY)
            Dim K = GetAcbK(a.Mid, b.Mid, radX_, radY_)


            'Dim C1 = (1 / mu) * 2 * K * (b - a) ^ ab1
            Dim C1 = (1 / mu) * 2 * K * (b - a)
            ''If (ab1 <> one) Then C1 = C1 ^ ab1
            If (ab1 <> one) Then C1 = aflint.pow(C1, ab1)
            Dim epsabs = epsabsStart / C1
            'Dim C2 = 2 / ((aflint.cos(p2 * aflint.sin(d))) ^ (alpha + beta) * aflint.cos(d))
            Dim C2 = 2 / (aflint.pow((aflint.cos(p2 * aflint.sin(d))), (alpha + beta)) * aflint.cos(d))
            '            Console.WriteLine("C1: {0}", C1)
            '            Console.WriteLine("C2: {0}", C2)
            '            Console.WriteLine("epsabs: {0}", epsabs)
            Dim h = 2 * pi * d / (aflint.log(1 + 2 * C2 / epsabs))
            Dim n = (1 / h) * aflint.log(2 / (pi * mu) * aflint.log(2 * aflint.exp(p2 * nu) / epsabs))

            If n < nmin Then
                nmin = n
                hmin = h
                C1Final = C1
                epsabsFinal = epsabs
            End If
            Console.WriteLine("h: {0}, n: {1:f}", h.mid, n.mid)
            '            Console.WriteLine()
            '            Console.WriteLine()
            '            Console.WriteLine("hmin: {0}, nmin: {1:f}", hmin,nmin)
        Next

        Console.WriteLine("Final epsabs {0}: ", epsabsFinal)
        Console.WriteLine("Final C1 {0:f}: ", C1Final)
        '        Determine NN and MM if alpha <> beta
        Console.WriteLine("hmin: {0}, nmin: {1:f}", hmin, nmin)
        'Dim MM = aflint.ceil(nmin).ToInt32 : Dim NN = MM
        Dim MM = aflint.lrint(aflint.ceil(nmin)) : Dim NN = MM
        Console.WriteLine("n0: {0}", NN)
        If (mu = alpha) Then
            'NN = NN - (aflint.floor(aflint.log(beta / alpha) / hmin)).ToInt32
            NN = NN - aflint.lrint(aflint.floor(aflint.log(beta / alpha) / hmin))
        Else
            MM = MM - aflint.lrint((aflint.floor(aflint.log(alpha / beta) / hmin)))
        End If
        Console.WriteLine("NN: {0}", NN)
        Console.WriteLine("MM: {0}", MM)


        'Perform actual integration
        Dim sum = aflint.t(0)
        'c = p2 * ((b-a)/2) ^ (alpha+beta-1) 
        Dim b1 = (b - a) / 2
        Dim b2 = (b + a) / 2
        'Dim c = p2 * (b1) ^ ab1
        Dim c = p2 * aflint.pow(b1, ab1)

        For kk As Integer = -MM To NN
            Dim u = hmin * kk
            Dim eu1 = aflint.exp(u)
            Dim eu2 = 1 / eu1
            Dim su = (eu1 - eu2) * 0.5
            Dim cu = (eu1 + eu2) * 0.5
            Dim x1 = (p2 * su)
            Dim e1 = aflint.exp(x1)
            Dim e2 = 1 / e1
            Dim e3 = 1 / (e1 + e2)
            Dim f = (e1 - e2) * e3
            Dim fp1 = 2 * e1 * e3
            Dim fm1 = 2 * e2 * e3
            'PHI2 = c * aflint.cosh(u) * (aflint.abs(1+f))^alpha * (aflint.abs(1-f))^beta
            'If alpha <> 1 Then fp1 = fp1 ^ alpha
            If alpha <> 1 Then fp1 = aflint.pow(fp1, alpha)
            'If beta <> 1 Then fm1 = fm1 ^ beta
            If beta <> 1 Then fm1 = aflint.pow(fm1, beta)
            Dim PHI2 = c * cu * fp1 * fm1
            Dim t = f * b1 + b2
            sum = sum + g(t) * PHI2
        Next
        Dim res = hmin * sum
        Console.WriteLine("ED+ET: {0}", C1Final * epsabsFinal)
        Console.WriteLine("Int1: {0}", res)
        Console.WriteLine("Int2: {0} = aflint.sqrt(2*p2)/2)", aflint.sqrt(2 * p2) / 2)

    End Sub





    Function GetAcbK(a As Arb, b As Arb, radX As Arb, radY As Arb) As Arb
        Dim ba2 = (b - a) / 2
        Dim x_re = aflint.t(0)
        x_re.Mid = (b + a) / 2
        x_re.Rad = ba2 * radX
        Dim x_im = aflint.t(0)
        x_im.Mid = aflint.t(0)
        x_im.Rad = ba2 * radY
        'Dim x = aflintc.t(0)
        Dim x = aflintc.t(x_re, x_im)
        'x.real = x_re
        'x.imag = x_im
        Dim z = cplx_g(x)
        Dim av = aflintc.abs(z)
        Console.WriteLine("Infimum: {0}", av.Infimum)
        Console.WriteLine("Supremum: {0}", av.Supremum)
        Return av.Supremum
    End Function








    Sub GetRectAndK(d1 As Integer, ByRef radX As String, ByRef radY As String, ByRef ds As String)
        Select Case d1
            Case 1 : radX = "165.2" : radY = "254.3" : ds = "1.5"
            Case 2 : radX = "28.375" : radY = "43.75" : ds = "1.4"
            Case 3 : radX = "11.3" : radY = "17.46" : ds = "1.3"
            Case 4 : radX = "6.06" : radY = "9.34" : ds = "1.2"
            Case 5 : radX = "3.8" : radY = "5.795" : ds = "1.1"
            Case 6 : radX = "2.633" : radY = "3.933" : ds = "1.0"
            Case 7 : radX = "1.968" : radY = "2.826" : ds = "0.9"
            Case 8 : radX = "1.566" : radY = "2.103" : ds = "0.8"
            Case 9 : radX = "1.312" : radY = "1.5994" : ds = "0.7"
            Case 10 : radX = "1.1552" : radY = "1.2276" : ds = "0.6"
            Case 11 : radX = "1.065" : radY = "0.937" : ds = "0.5"
            Case 12 : radX = "1.0197" : radY = "0.702" : ds = "0.4"
            Case 13 : radX = "1.0032" : radY = "0.5008" : ds = "0.3"
            Case 14 : radX = "1.001" : radY = "0.41" : ds = "0.25"
            Case 15 : radX = "1.001" : radY = "0.3228" : ds = "0.2"
            Case 16 : radX = "1.001" : radY = "0.199" : ds = "0.125"
            Case 17 : radX = "1.001" : radY = "0.1584" : ds = "0.1"
            Case 18 : radX = "1.001" : radY = "0.1423" : ds = "0.09"
            Case 19 : radX = "1.001" : radY = "0.1263" : ds = "0.08"
            Case 20 : radX = "1.001" : radY = "0.11037" : ds = "0.07"
            Case 21 : radX = "1.001" : radY = "0.09456" : ds = "0.06"
            Case 22 : radX = "1.001" : radY = "0.0787" : ds = "0.05"
            Case 23 : radX = "1.001" : radY = "0.06296" : ds = "0.04"
            Case 24 : radX = "1.001" : radY = "0.0472" : ds = "0.03"
            Case 25 : radX = "1.001" : radY = "0.03145" : ds = "0.02"
            Case 26 : radX = "1.0" : radY = "0.01572" : ds = "0.01"
            Case Else : Console.WriteLine("Error")
        End Select


    End Sub



    Function g(t As Arb) As Arb
        'Dim res = aflint.sin(aflint.exp(t))
        Dim res = aflint.exp(-t * t)
        '        res = 1/((1-t*t)*(1-t*t) + t*t)
        '        y = 1/(1+t*t)
        '        res = -(1/(1+y*y)) * 1/(y*y)
        Return res
    End Function


    Function cplx_g(t As ArbC) As ArbC
        'Dim res = aflintc.sin(aflintc.exp(t))
        Dim res = aflintc.exp(-t * t)
        Return res
    End Function


    Sub Test_Integration()
        ArbPrec.SetDps(40)
        Dim a = aflint.t("0.0")
        Dim b = aflint.t("10.0")
        Dim alpha = aflint.t("1.0")
        Dim beta = aflint.t("1.0")
        'a = 5.0 : b = 10.0 : alpha = 1.0 : beta = 1.0
        'a = 0.0 : b = 1.0 : alpha = 0.5 : beta = 1.0
        'epsabsStart = "1.0E-2"
        Dim epsabsStart = aflint.t("1.0E-35")
        Calc_Integration(a, b, epsabsStart, alpha, beta)
    End Sub





    Sub DE_Int_Main()
        Test_Integration()
    End Sub

End Module
