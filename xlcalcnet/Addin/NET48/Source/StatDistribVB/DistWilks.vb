Imports System
Imports System.Numerics
Imports System.Diagnostics
'Imports mpFunLabNET
'Imports fpFunLabNET




Module DistWilks



    Private Const jmax = 6000



    Sub WilksExact2(p As Integer, f1 As Integer, f2 As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
        Dim i As Integer
        Dim b() As Double, c() As Double
        ReDim b(p) : ReDim c(p)
        For i = 1 To p
            b(i) = (f2 - i + 1) / 2
            c(i) = b(i) + f1 / 2
        Next i
        Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
    End Sub



    Function WilksExactX2(LeftTail As Double, Righttail As Double, p As Integer, f1 As Integer, f2 As Double) As Double
        Dim i As Integer
        Dim b() As Double, c() As Double
        ReDim b(p) : ReDim c(p)
        For i = 1 To p
            b(i) = (f2 - i + 1) / 2
            c(i) = b(i) + f1 / 2
        Next i
        Return BetaProdDisX2(LeftTail, Righttail, p, b, c)
    End Function





    'Sub TestMauchleyDis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 2 To p
    '        b(j - 1) = (n - j) / 2
    '        c(j - 1) = b(j - 1) + (j - 1) / p + (j - 1) / 2
    '        'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
    'End Sub


    'Function TestMauchleyDisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 2 To p
    '        b(j - 1) = (n + 1 - j) / 2
    '        c(j - 1) = b(j - 1) + (j - 1) / p + (j - 1) / 2
    '        'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    Return BetaProdDisX2(LeftTail, Righttail, p - 1, b, c)
    'End Function


    ''Note: In Coelho_2012c, equation 32, n is sample size (not n+1, as we use it here)
    'Sub DemoTestMauchley()
    '    '  p: # of variables in 1. set
    '    '  n: # of cases-1 }      
    '    Dim p, n As Int32
    '    Dim LeftTail, RightTail, result2, resultM As Double
    '    Dim LeftTail2, RightTail2 As Double
    '    p = 15  ' number of variables
    '    n = 125    ' n+1 is sample size
    '    LeftTail = 0.9
    '    RightTail = 1 - LeftTail

    '    result2 = TestMauchleyDisX(LeftTail, RightTail, p, n)
    '    Console.WriteLine("result2: {0}", result2)
    '    resultM = -n * Math.Log(result2)
    '    Console.WriteLine("resultM: {0}", resultM)

    '    TestMauchleyDis(p, n, result2, LeftTail2, RightTail2)
    '    Console.WriteLine("LeftTail2: {0}", LeftTail2)

    'End Sub


    'Sub TestWilksLvcm0Dis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 2 To p
    '        b(j - 1) = (n - j) / 2
    '        c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
    '        'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    b(p) = (n - 1) / 2
    '    c(p) = b(p) + 1 / 2
    '    Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
    'End Sub


    'Function TestWilksLvcm0DisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 2 To p
    '        b(j - 1) = (n - j) / 2
    '        c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
    '        'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    b(p) = (n - 1) / 2
    '    c(p) = b(p) + 1 / 2
    '    Return BetaProdDisX2(LeftTail, Righttail, p, b, c)
    'End Function


    ''Note: In Coelho_2016, equation 55, n is sample size 
    '' Tables are on page 10
    'Sub DemoTestWilksLvcm0()
    '    '  p: # of variables in 1. set
    '    '  n: # of cases-0 }      
    '    Dim p, n As Int32
    '    Dim LeftTail, RightTail, result2, resultM As Double
    '    Dim LeftTail2, RightTail2 As Double
    '    p = 15  ' number of variables
    '    n = 65   ' n is sample size
    '    LeftTail = 0.99
    '    RightTail = 1 - LeftTail

    '    result2 = TestWilksLvcm0DisX(LeftTail, RightTail, p, n)
    '    Console.WriteLine("result2: {0}", result2)
    '    resultM = -(n) * Math.Log(result2)
    '    Console.WriteLine("resultM: {0}", resultM)

    '    TestWilksLvcm0Dis(p, n, result2, LeftTail2, RightTail2)
    '    Console.WriteLine("LeftTail2: {0}", LeftTail2)

    'End Sub


    'Sub TestWilksLvcmDis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 2 To p
    '        b(j - 1) = (n - j) / 2
    '        c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
    '        'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
    'End Sub


    'Function TestWilksLvcmDisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 2 To p
    '        b(j - 1) = (n - j) / 2
    '        c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j) / 2
    '        'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    Return BetaProdDisX2(LeftTail, Righttail, p - 1, b, c)
    'End Function


    ''Note: In Coelho_2016, equation 32, n is sample size 
    '' Tables are on page 10
    'Sub DemoTestWilksLvcm()
    '    '  p: # of variables in 1. set
    '    '  n: # of cases-0 }      
    '    Dim p, n As Int32
    '    Dim LeftTail, RightTail, result2, resultM As Double
    '    Dim LeftTail2, RightTail2 As Double
    '    p = 15  ' number of variables
    '    n = 65   ' n is sample size
    '    LeftTail = 0.99
    '    RightTail = 1 - LeftTail

    '    result2 = TestWilksLvcmDisX(LeftTail, RightTail, p, n)
    '    Console.WriteLine("result2: {0}", result2)
    '    resultM = -(n) * Math.Log(result2)
    '    Console.WriteLine("resultM: {0}", resultM)

    '    TestWilksLvcmDis(p, n, result2, LeftTail2, RightTail2)
    '    Console.WriteLine("LeftTail2: {0}", LeftTail2)

    'End Sub

    'Sub TestWilksLvcDis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 2 To p
    '        b(j - 1) = (n - j) / 2
    '        c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j - 1) / 2
    '        'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
    'End Sub


    'Function TestWilksLvcDisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 2 To p
    '        b(j - 1) = (n - j) / 2
    '        c(j - 1) = b(j - 1) + (j - 2) / (p - 1) + (j - 1) / 2
    '        'Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    Return BetaProdDisX2(LeftTail, Righttail, p - 1, b, c)
    'End Function


    ''Note: In Coelho_2016, equation 53, n is sample size 
    '' Tables are on page 10
    'Sub DemoTestWilksLvc()
    '    '  p: # of variables in 1. set
    '    '  n: # of cases-0 }      
    '    Dim p, n As Int32
    '    Dim LeftTail, RightTail, result2, resultM As Double
    '    Dim LeftTail2, RightTail2 As Double
    '    p = 15 ' number of variables
    '    n = 65   ' n is sample size
    '    LeftTail = 0.99
    '    RightTail = 1 - LeftTail

    '    result2 = TestWilksLvcDisX(LeftTail, RightTail, p, n)
    '    Console.WriteLine("result2: {0}", result2)
    '    resultM = -(n) * Math.Log(result2)
    '    Console.WriteLine("resultM: {0}", resultM)

    '    TestWilksLvcDis(p, n, result2, LeftTail2, RightTail2)
    '    Console.WriteLine("LeftTail2: {0}", LeftTail2)

    'End Sub





    'Sub TestR0Dis(p As Integer, n As Double, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 1 To p - 1
    '        b(j) = (n - p + j) / 2
    '        c(j) = b(j) + (p - j) / 2
    '        Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    Call BetaProdDis2(p, b, c, l, LeftTail, Righttail)
    'End Sub


    'Function TestR0DisX(LeftTail As Double, Righttail As Double, p As Integer, n As Integer) As Double
    '    Dim j As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p) : ReDim c(p)
    '    For j = 1 To p - 1
    '        b(j) = (n - p + j) / 2
    '        c(j) = b(j) + (p - j) / 2
    '        Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b(j), c(j))
    '    Next j
    '    Return BetaProdDisX2(LeftTail, Righttail, p - 1, b, c)
    'End Function



    ''Coelho_2012, equation 9, n + 1 is sample size
    'Sub DemoTestR0()
    '    '  p: # of variables in 1. set
    '    '  n: # of cases-1 }      
    '    Dim p, n As Int32
    '    Dim LeftTail, RightTail, result2, resultM As Double
    '    Dim LeftTail2, RightTail2 As Double
    '    p = 5  ' number of variables
    '    n = 25 - 1   'Coelho_2012, equation 9, n + 1 is sample size
    '    LeftTail = 0.9
    '    RightTail = 1 - LeftTail

    '    result2 = TestR0DisX(LeftTail, RightTail, p, n)
    '    Console.WriteLine("result2: {0}", result2)
    '    resultM = -n * Math.Log(result2)
    '    Console.WriteLine("resultM: {0}", resultM)

    '    TestR0Dis(p, n, result2, LeftTail2, RightTail2)
    '    Console.WriteLine("LeftTail2: {0}", LeftTail2)

    'End Sub



    'Sub TestR0KSetsDis(k As Integer, p() As Integer, n As Integer, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
    '    Dim i, j, m, pmax As Integer
    '    Dim pp() As Int32
    '    ReDim pp(k)
    '    pp(k) = 0
    '    pmax = 0
    '    For i = k - 1 To 1 Step -1
    '        pp(i) = pp(i + 1) + p(i)
    '        pmax = pmax + p(i)
    '    Next i
    '    Dim b() As Double, c() As Double
    '    ReDim b(pmax) : ReDim c(pmax)
    '    m = 0
    '    For i = 1 To k - 1
    '        For j = 1 To p(i)
    '            m = m + 1
    '            b(m) = (n + 1 - pp(i) - j) / 2
    '            c(m) = b(m) + pp(i) / 2
    '            Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
    '        Next j
    '    Next i
    '    Call BetaProdDis2(m, b, c, l, LeftTail, Righttail)
    'End Sub



    'Function TestR0KSetsDisX(LeftTail As Double, Righttail As Double, k As Integer, p() As Integer, n As Integer) As Double
    '    Dim i, j, m, pmax As Integer
    '    Dim pp() As Int32
    '    ReDim pp(k)
    '    pp(k) = 0
    '    pmax = 0
    '    For i = k - 1 To 1 Step -1
    '        pp(i) = pp(i + 1) + p(i)
    '        pmax = pmax + p(i)
    '    Next i
    '    Dim b() As Double, c() As Double
    '    ReDim b(pmax) : ReDim c(pmax)
    '    m = 0
    '    For i = 1 To k - 1
    '        For j = 1 To p(i)
    '            m = m + 1
    '            b(m) = (n + 1 - pp(i) - j) / 2
    '            c(m) = b(m) + pp(i) / 2
    '            Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
    '        Next j
    '    Next i
    '    Return BetaProdDisX2(LeftTail, Righttail, m, b, c)
    'End Function



    'Sub TestBartlettDis(p As Integer, q As Integer, n As Integer, l As Double, ByRef LeftTail As Double, ByRef Righttail As Double)
    '    Dim j, k, m As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p * q) : ReDim c(p * q)
    '    m = 0
    '    For j = 1 To p
    '        For k = 1 To q
    '            If (j = 1 And k = 1) Then
    '                'Console.WriteLine("The item (j = 1 And k = 1) needs to be omitted")
    '            Else
    '                m = m + 1
    '                b(m) = (n + 1 - j) / 2
    '                c(m) = b(m) + (j * (q - 1) + 2 * k - 1 - q) / (2 * q)
    '                'Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
    '            End If
    '        Next k
    '    Next j
    '    Call BetaProdDis2(m, b, c, l, LeftTail, Righttail)
    'End Sub



    'Function TestBartlettDisX(LeftTail As Double, Righttail As Double, p As Integer, q As Integer, n As Integer) As Double
    '    Dim j, k, m As Integer
    '    Dim b() As Double, c() As Double
    '    ReDim b(p * q) : ReDim c(p * q)
    '    m = 0
    '    For j = 1 To p
    '        For k = 1 To q
    '            If (j = 1 And k = 1) Then
    '                Console.WriteLine("The item (j = 1 And k = 1) needs to be omitted")
    '            Else
    '                m = m + 1
    '                b(m) = (n + 1 - j) / 2
    '                c(m) = b(m) + (j * (q - 1) + 2 * k - 1 - q) / (2 * q)
    '                Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b(m), c(m))
    '            End If
    '        Next k
    '    Next j
    '    Return BetaProdDisX2(LeftTail, Righttail, m, b, c)
    'End Function


    ''Note: In Coelho_2012c, equation 30, n is sample size (not n+1, as we use it here)
    'Sub DemoTestBartlett()
    '    '  p: # of variables in 1. set
    '    '  n: # of cases-1 }      
    '    Dim n As Int32, p As Int32, k As Int32
    '    Dim LeftTail, RightTail, result2, resultM As Double
    '    Dim LeftTail2, RightTail2 As Double
    '    p = 3
    '    k = 5
    '    n = 15 ' n + 1 is sample size
    '    LeftTail = 0.95
    '    RightTail = 1 - LeftTail

    '    result2 = TestBartlettDisX(LeftTail, RightTail, p, k, n)
    '    Console.WriteLine("result2: {0}", result2)
    '    resultM = -n * Math.Log(result2)
    '    Console.WriteLine("resultM: {0}", resultM)

    '    TestBartlettDis(p, k, n, result2, LeftTail2, RightTail2)
    '    Console.WriteLine("LeftTail2: {0}", LeftTail2)

    'End Sub



    Function GammaP(p As Integer, x As Double) As Double
        Const pi = 3.14159265358979
        Dim i As Integer, prod As Double, k As Double
        prod = 1
        For i = 1 To p
            'prod = prod * xpr.gamma(x - 0.5 * (i - 1))
            prod = prod * boost2.gamma(x - 0.5 * (i - 1))
        Next i
        k = pi ^ (p * (p - 1) / 4)
        GammaP = k * prod
    End Function



    Function LnGammaP(p As Integer, x As Double) As Double
        Const pi = 3.14159265358979
        Dim i As Integer, sum As Double, k As Double
        sum = 0
        For i = 1 To p
            sum = sum + LnGamma(x - 0.5 * (i - 1))
        Next i
        'K = Log(pi ^ (p * (p - 1) / 4))
        k = Math.Log(pi) * (p * (p - 1) / 4)

        Return k + sum
    End Function


    Sub TestGammaP()
        Dim p As Integer, x As Double, Result As Double
        p = 1
        x = 14
        Result = LnGammaP(p, x)
        Console.WriteLine("lnG", Math.Exp(Result))
    End Sub



    Function Hypergeometric2F1Matrix(p As Int32, a As Double, b As Double, c As Double, x() As Double) As Double
        Dim k As Double, y() As Double, tau As Double, s() As Double
        Dim i As Int32, j As Int32, prod As Double, R21 As Double, Result As Double

        ReDim y(p) : ReDim s(p)
        prod = 1
        For i = 1 To p
            tau = x(i) * (b - a) - c
            y(i) = (2 * a) / (Math.Sqrt(tau * tau - 4 * a * x(i) * (c - b)) - tau)
            s(i) = x(i) * y(i) * (1 - y(i)) / (1 - x(i) * y(i))
            prod = prod * (((y(i) / a) ^ a) * (((1 - y(i)) / (c - a)) ^ (c - a)) * (1 - x(i) * y(i)) ^ (-b))
        Next i
        R21 = 1
        For i = 1 To p
            For j = i To p
                R21 = R21 * ((y(i) * y(j) / a) + (1 - y(i)) * (1 - y(j)) / (c - a) - b * s(i) * s(j) / (a * (c - a)))
            Next j
        Next i
        k = c ^ (p * c - p * (p + 1) / 4)
        Result = k * prod / Math.Sqrt(R21)
        'Debug.Print k, p, x(p)

        Return Result
    End Function

    Sub TestHypergeometric2F1Matrix()
        Dim p As Int32, a As Double, b As Double, c As Double, x() As Double
        Dim Result As Double
        p = 3
        a = 3
        b = 2.5
        c = 1.5
        ReDim x(p)
        x(1) = 1.0 / 5.0
        x(2) = 2.0 / 5.0
        x(3) = 3.0 / 5.0
        Result = Hypergeometric2F1Matrix(p, a, b, c, x)
        Console.WriteLine("Result: {0}", Result)
    End Sub



    Function LnHypergeometric1F1Matrix(p As Integer, a As Double, b As Double, x() As Double) As Double
        Dim k As Double, y() As Double, tau As Double
        Dim i As Integer, j As Integer, prod As Double, r11 As Double, Result As Double
        Dim sum As Double, LogK As Double

        ReDim y(p)
        prod = 1
        For i = 1 To p
            tau = b - x(i)
            y(i) = (2 * a) / (tau + Math.Sqrt(tau * tau + 4 * a * x(i)))
            '  Prod = Prod * (((y(i) / a) ^ a) * (((1 - y(i)) / (b - a)) ^ (b - a)) * Exp(x(i) * y(i)))
            sum = sum + ((Math.Log(y(i) / a) * a) + (Math.Log((1 - y(i)) / (b - a)) * (b - a)) + (x(i) * y(i)))

        Next i
        r11 = 1
        For i = 1 To p
            For j = i To p
                r11 = r11 * ((y(i) * y(j) / a) + (1 - y(i)) * (1 - y(j)) / (b - a))
            Next j
        Next i
        'K = b ^ (p * b - p * (p + 1) / 4)

        LogK = Math.Log(b) * (p * b - p * (p + 1) / 4)

        'Result = K * Prod / Sqr(R11)

        Result = (LogK + sum) - Math.Log(Math.Sqrt(r11))
        'Debug.Print K, p, x(p)

        Return Result
    End Function



    Function Hypergeometric1F1Matrix(p As Int32, a As Double, b As Double, x() As Double) As Double
        Dim k As Double, y() As Double, tau As Double
        Dim i As Int32, j As Int32, prod As Double, r11 As Double, Result As Double
        Dim sum As Double, LogK As Double

        ReDim y(p)
        prod = 1
        For i = 1 To p
            tau = b - x(i)
            y(i) = (2 * a) / (tau + Math.Sqrt(tau * tau + 4 * a * x(i)))
            prod = prod * (((y(i) / a) ^ a) * (((1 - y(i)) / (b - a)) ^ (b - a)) * Math.Exp(x(i) * y(i)))
            sum = sum + ((Math.Log(y(i) / a) * a) + (Math.Log((1 - y(i)) / (b - a)) * (b - a)) + (x(i) * y(i)))

        Next i
        r11 = 1
        For i = 1 To p
            For j = i To p
                r11 = r11 * ((y(i) * y(j) / a) + (1 - y(i)) * (1 - y(j)) / (b - a))
            Next j
        Next i
        k = b ^ (p * b - p * (p + 1) / 4)

        LogK = Math.Log(b) * (p * b - p * (p + 1) / 4)

        Result = k * prod / Math.Sqrt(r11)

        Result = Math.Exp(LogK + sum) / Math.Sqrt(r11)
        'Debug.Print K, p, x(p)

        Return Result
    End Function


    Sub TestHypergeometric1F1Matrix()
        Dim p As Integer, a As Double, b As Double, x() As Double
        Dim Result As Double
        p = 2
        a = 61
        b = 2
        ReDim x(p)
        x(1) = 1.34
        x(p) = 2.72
        Result = Hypergeometric1F1Matrix(p, a, b, x)
        Console.WriteLine("Result: {0}", Result)
    End Sub




    Function Hypergeometric0F1Matrix(p As Int32, n As Double, x() As Double) As Double
        Dim k As Double, y() As Double, tau As Double
        Dim i As Int32, j As Int32, prod As Double, r11 As Double, Result As Double

        ReDim y(p) ': ReDim s(p)
        prod = 1
        For i = 1 To p
            tau = 2 * x(i) / n
            y(i) = tau / (1 + Math.Sqrt(tau * tau + 1))
            prod = prod * (((1 - y(i)) ^ (n / 2)) * Math.Exp(x(i) * y(i)))
        Next i
        r11 = 1
        For i = 1 To p
            For j = i To p
                r11 = r11 * (1 - y(i) * y(j) * y(i) * y(j))
            Next j
        Next i
        k = 1
        Result = k * prod / Math.Sqrt(r11)
        'Debug.Print k, p, x(p)

        Return Result
    End Function


    Sub TestHypergeometric0F1Matrix()
        Dim p As Integer, n As Double, x() As Double
        Dim Result As Double
        p = 2
        n = 61
        ReDim x(p)
        x(1) = 1.34
        x(p) = 2.72
        Result = Hypergeometric0F1Matrix(p, n, x)
        Console.WriteLine("Result: {0}", Result)
    End Sub






    Sub DemoGLMPower()
        '  p: # of variables in 1. set
        '  q: # of variables in 2. set
        '  n: # of cases-1 }      
        Dim p, q, n As Int32
        Dim x, LeftTail, RightTail, Left1 As Double

        p = 4
        q = 6
        n = 80 + q
        LeftTail = 0.95
        RightTail = 1 - LeftTail

        Dim Omega2() As Double = {0, 0, 0, 0, 0}
        'Dim Omega() As Double = {0.0, 1.0, 1.0, 1.0}
        Dim Omega() As Double = {0.0, 11.0, 1.0, 1.0}
        Omega(0) = 27

        Console.WriteLine("")
        Console.WriteLine("grdis")
        x = GRDisX(LeftTail, RightTail, p, q, n - q)
        Console.WriteLine("x: {0}", x)

        Left1 = GRDisN(False, "GLM", p, q, n - q, x, Omega2)
        Console.WriteLine("Null:: {0}", Left1)

        Left1 = GRDisN(False, "CORR", p, q, n - q, x, Omega)
        Console.WriteLine("CORR:: {0}", Left1)

        Left1 = GRDisN(False, "GLM", p, q, n - q, x, Omega)
        Console.WriteLine("GLM: : {0}", Left1)


        Console.WriteLine("")
        Console.WriteLine("udis")
        x = Udisx(LeftTail, RightTail, p, q, n - q)
        Console.WriteLine("x: {0}", x)

        Left1 = UdisN("GLM", p, q, n - q, x, Omega2)
        Console.WriteLine("Null:: {0}", Left1)

        Left1 = UdisN("CORR", p, q, n - q, x, Omega)
        Console.WriteLine("CORR:: {0}", Left1)

        Left1 = UdisN("GLM", p, q, n - q, x, Omega)
        Console.WriteLine("GLM: : {0}", Left1)


        Console.WriteLine("")
        Console.WriteLine("t2dis")
        x = T2disX(LeftTail, RightTail, p, q, n - q)
        Console.WriteLine("x: {0}", x)

        Left1 = T2disN("GLM", p, q, n - q, x, Omega2)
        Console.WriteLine("Null:: {0}", Left1)

        Left1 = T2disN("CORR", p, q, n - q, x, Omega)
        Console.WriteLine("CORR:: {0}", Left1)

        Left1 = T2disN("GLM", p, q, n - q, x, Omega)
        Console.WriteLine("GLM: : {0}", Left1)

        Console.WriteLine("")
        Console.WriteLine("vdis")
        x = VdisX(LeftTail, RightTail, p, q, n - q)
        Console.WriteLine("x: {0}", x)

        Left1 = VdisN("GLM", p, q, n - q, x, Omega2)
        Console.WriteLine("Null:: {0}", Left1)

        Left1 = VdisN("CORR", p, q, n - q, x, Omega)
        Console.WriteLine("CORR:: {0}", Left1)

        Left1 = VdisN("GLM", p, q, n - q, x, Omega)
        Console.WriteLine("GLM: : {0}", Left1)

    End Sub




    Sub DemoUdisx()
        '  p: # of variables in 1. set
        '  q: # of variables in 2. set
        '  n: # of cases-1 }      
        Dim p, q, n As Int32
        Dim LeftTail, RightTail, resultX, result2, resultM, Left1, Right1 As Double

        'p = 14
        'q = 8
        ''n = 125 + 7
        'n = 125

        p = 4
        q = 7
        'n = 125 + 7
        n = 100

        LeftTail = 0.9
        RightTail = 1 - LeftTail
        resultX = Udisx(LeftTail, RightTail, p, q - 1, n - q)
        Console.WriteLine("resultX: {0}", resultX)
        Dim resultL = -Math.Log(resultX)
        Console.WriteLine("resultL: {0}", resultL)

        resultM = -n * Math.Log(resultX)
        Console.WriteLine("resultM: {0}", resultM)




        'WilksExact2(p, q - 1, n - q, resultX, Left1, Right1)
        'Console.WriteLine("WilksExact2: {0}", Left1)

        'Dim resultWX = WilksExactX2(LeftTail, RightTail, p, q - 1, n - q)
        'Console.WriteLine("resultWX: {0}", resultWX)

        ''Dim WilksdisLeft1 = Wilksdis(p, q, n - q, resultWX)
        'Dim WilksdisLeft1 = Wilksdis(p, q - 1, n - q, resultWX)
        'Console.WriteLine("WilksdisLeft1: {0}", WilksdisLeft1)



    End Sub


    Function Udisx(LeftTail As Double, Righttail As Double, p As Double, q As Double, n As Double) As Double
        '  p: # of variables in 1. set
        '  q: # of variables in 2. set
        '  n: # of cases-1-q }
        Dim F As Double, m As Double, pq As Double, s As Double, l As Double
        If ((n < p) Or (LeftTail <= 0) Or (Righttail >= 1)) Then
            Udisx = 0
            Exit Function
        End If
        pq = p * q
        s = (p * p + q * q - 5)
        If s <> 0 Then s = (pq * pq - 4) / s Else s = 1
        If s < 0 Then s = 1 Else s = Math.Sqrt(s)
        m = s * (n - (p + 1 - q) / 2) - (pq - 2) / 2
        'F = fdisx(LeftTail, Righttail, pq, m)
        'F = xpr.dist_qf(LeftTail, pq, m, True)
        F = boost2.dist_fisher_f(LeftTail, pq, m, 6)
        l = 1.0 / (1 + pq * F / m)
        Udisx = Math.Exp(s * Math.Log(l))
    End Function



    Function Wilksdis(p As Double, q As Double, n As Double, l1 As Double) As Double
        Dim LeftTail As Double, Righttail As Double, l2 As Double, r2 As Double
        '{ p: # of variables in 1. set
        '  q: # of variables in 2. set
        '  n: # of cases-1 }
        Dim F As Double, m As Double, pq As Double, s As Double, l As Double
        If (n < p) Or (l1 < 0) Then
            LeftTail = 0 : Righttail = 1
            Wilksdis = LeftTail
            Exit Function
        End If
        If (l1 >= 1) Then
            LeftTail = 1 : Righttail = 0
            Wilksdis = LeftTail
            Exit Function
        End If
        pq = p * q
        s = (p * p + q * q - 5)
        If s <> 0 Then s = (pq * pq - 4) / s Else s = 1
        If s < 0 Then s = 1 Else s = Math.Sqrt(s)
        '  printout('S2: ' + StrN(S*S,12,8))
        l = Math.Exp(Math.Log(l1) / s)
        m = s * (n - (p + 1 - q) / 2) - (pq - 2) / 2
        F = m * (1 - l) / (pq * l)
        Fdisn2(pq, m, F, 0, l2, r2)
        Console.WriteLine("l2: {0}, r2: {1}", l2, r2)
        Return l2

    End Function



    Sub Kulp2(IsRho As Boolean, p As Integer, f2 As Double, f1 As Double, lambda As Double, sigma() As Double,
                  LeftTail As Double, Righttail As Double)
        Dim Beta(0 To 3) As Double,
            g1 As Double, g2 As Double, g3 As Double, u As Double, delta As Double, m1 As Double, v As Double, a As Double, s2 As Double, s As Double, d1 As Double,
            sum As Double, sum1 As Double, sig1 As Double, sig12 As Double, sig2 As Double,
            l As Double, r2 As Double,
            i As Integer
        sig1 = 0 : sig2 = 0
        For i = 1 To p
            sig1 = sig1 + sigma(i)
            sig2 = sig2 + Math.Sqrt(sigma(i))
        Next i
        sig1 = sig1 / 2 : sig2 = sig2 / 4 : sig12 = Math.Sqrt(sig1)
        delta = (p - f2 + 1) / 4
        m1 = (f1 - 2 * delta) / 2
        v = p * f2 / 2
        a = (1 - v) / 2
        If p * f2 <= 2 Then s2 = 1 Else s2 = (Math.Sqrt(p * f2) - 4) / (p * p + f2 * f2 - 5)
        s = Math.Sqrt(s2)
        u = Math.Exp(Math.Log(lambda) / s)
        d1 = 2 * delta + f2
        d1 = d1
        g1 = sig1 * (d1 - (v + 1) / s) / 2
        g2 = (-sig1 * (d1 - (v + 1) / s) + sig2 - sig12 / s) / 2
        g3 = -(sig2 - sig12 / s) / 2
        l = 2 * sig1
        For i = 0 To 3
            '{    BetaDisN(v+i,m1*s+a,1-u,u,l,LeftTail,RightTail)}
            r2 = l / (2 * (m1 * s + a) + l)
            Call R2DisN(IsRho, 2 * (v + i), 2 * (m1 * s + a), 1 - u, r2, LeftTail, Righttail)
            Beta(i) = LeftTail
        Next i
        sum = Beta(0) : sum1 = 0
        Console.WriteLine("sum0: {0}", sum)
        If sig1 >= 0 Then
            sum1 = (1 / (m1)) * (g1 * Beta(1) + g2 * Beta(2) + g3 * Beta(3))
            If IsRho Then sum1 = 2.5 * sum1
            Console.WriteLine("sum1: {0}", sum1)
        End If
        LeftTail = sum + sum1
        Righttail = 1 - LeftTail
    End Sub



    Sub Fangdis(pp As Integer, qq As Integer, n As Double, l1 As Double,
    ByRef LeftTail As Double, ByRef Righttail As Double)
        '{ p as  # of variables in 1. set
        '  q as  # of variables in 2. set
        '  n as  # of cases-1 }
        Dim v As Double, delta As Double, s2 As Double
        Dim Ar2 As Double, sum1 As Double, sum2 As Double
        Dim d As Integer, b As Integer, i As Integer, j As Integer
        Dim p(0 To 10) As Integer

        If (n < pp) Or (l1 <= 0) Then
            LeftTail = 0 : Righttail = 1
            Exit Sub
        End If
        If (l1 >= 1) Then
            LeftTail = 1 : Righttail = 0
            Exit Sub
        End If
        d = 2
        p(1) = pp
        p(2) = qq

        '  p(1) = Int(pp + 0.5)
        '  p(2) = Int(qq + 0.5)

        b = 0
        v = 0
        For i = 1 To d : b = b + p(i) : Next i
        For i = 1 To d : v = v + p(i) * (p(i) + 1) : Next i
        v = 0.5 * (b * (b + 1) - v)
        delta = 0
        For i = 1 To d : delta = delta + p(i) * (p(i) + 1) * (2 * p(i) + 1) : Next i
        delta = (-delta - 6 * v + b * (b + 1) * (2 * b + 1)) / (12 * v)
        '  m=n-delta
        '  a=(1-v)/2
        '  Calc Ar
        sum1 = 0 : sum2 = 0
        For i = 1 To d
            For j = 1 To p(i)
                sum1 = sum1 + B3(delta - j + 1)
            Next j
        Next i
        For i = 1 To b
            sum2 = sum2 + B3(delta - i + 1)
        Next i
        Ar2 = -(sum1 - sum2) / (2 * 3)
        If Ar2 = 0 Then s2 = 1 Else s2 = v * (1 - v * v) / (24 * Ar2)
        Console.WriteLine("S2: {0}", s2)
    End Sub



    Sub WilksExact(p As Integer, f1 As Integer, f2 As Double, l As Double,
                         ByRef LeftTail As Double, ByRef Righttail As Double)
        Dim i As Integer
        Dim b() As Double, c() As Double
        ReDim b(p) : ReDim c(p)
        For i = 1 To p
            b(i) = (f2 - i + 1) / 2
            c(i) = b(i) + f1 / 2
            Console.WriteLine("i: {0}, b(i): {1}, c(i): {2}", i, b(i), c(i))
        Next i
        Call BetaProdDis(p, b, c, l, LeftTail, Righttail)
    End Sub


    '{Algorithm for sigma by Tang, 1984}
    Sub CalcSigma2(r As Integer, ByRef HH() As Double, ByRef sigma(,) As Double,
         p As Integer, ByRef F() As Double, ByRef m() As Double)
        Dim sum As Double, d As Double
        Dim k As Integer, s As Integer
        If r > 0 Then sigma(1, r) = 0
        For k = 2 To p
            sum = 0
            d = 1
            For s = 0 To r
                sum = sum + d * sigma(k - 1, r - s)
                d = d * (m(k) + s) / (s + 1)
            Next s
            sigma(k, r) = HH(k) * sum
        Next k
        For k = 2 To p
            HH(k) = HH(k) * (F(k - 1) + r) / (F(k) + r)
        Next k
    End Sub '(*CalcSigma*)


    '{Exact cdf, algorithm using beta, by Tang, 1984}
    Sub BetaProdDis(p As Integer, b() As Double, c() As Double, x As Double,
                          ByRef LeftTail As Double, ByRef Righttail As Double)

        Dim i As Integer, j As Integer
        Dim HH() As Double, F() As Double, m() As Double      ' r3feld
        Dim KBetaStart As Double, KBeta As Double, k As Double, sum As Double, summand As Double, RelError As Double, f1 As Double, f2 As Double
        Dim FAX As Double, density As Double, ax As Double, FIBeta As Double
        Dim sigma(,) As Double  'SFeld

        ReDim F(p)
        ReDim m(p)
        ReDim HH(p)

        ReDim sigma(p, 6000)
        '    For i = 1 To p
        '      New(sigma(i))
        '    End
        k = 0
        For i = 1 To p
            k = k + LnGamma(c(i))
            k = k - LnGamma(b(i))
        Next i
        k = Math.Exp(k)
        F(1) = c(1) - b(1)
        m(1) = 0
        For i = 2 To p
            F(i) = F(i - 1) + c(i) - b(i)
            m(i) = c(i) - b(i - 1)
        Next i
        sigma(1, 0) = 1.0# / Math.Exp(LnGamma(F(1)))
        For i = 2 To p
            HH(i) = Math.Exp(LnGamma(F(i - 1)) - LnGamma(F(i)))
        Next i
        f1 = b(p)
        f2 = F(p)
        sum = 0 : j = 0 : RelError = 1
        KBetaStart = Math.Exp(Lnbeta(f1, f2))
        KBeta = 1
        Call betadis(f1, f2, x, 1 - x, LeftTail, Righttail, density)
        FIBeta = Math.Exp(LnGamma(f1 + f2) - LnGamma(f2 + 1) - LnGamma(f1))
        ax = Math.Exp(f1 * Math.Log(x) + f2 * Math.Log(1 - x))
        FAX = FIBeta * ax
        While ((j <= jmax) And (RelError >= 0.0000000000000001))
            Call CalcSigma2(j, HH, sigma, p, F, m)
            '      {Betadis(f1,f2+j,x,1-x,Left,RightTail)}
            summand = KBeta * LeftTail * sigma(p, j) ^ (j)    ' need to check sigma (j, j) indices!!!!
            sum = sum + summand
            RelError = summand / sum

            Console.WriteLine("j: {0},  RelError: {1}", j, RelError)
            LeftTail = LeftTail + FAX
            FAX = FAX * (1 - x) * (f1 + f2 + j) / (f2 + j + 1)
            KBeta = KBeta * (f2 + j) / (f1 + f2 + j)
            j = j + 1
        End While
        '    For i = 1 To p
        '      dispose (sigma(i))
        '    End
        Righttail = KBetaStart * sum * k
        LeftTail = 1 - Righttail
    End Sub





    '{Exact cdf, algorithm using chi2, by Tang}
    Sub BetaProdDis5(first As Boolean, odd_f1 As Boolean, p As Integer, b() As Double,
     c() As Double, x As Double, LeftTail As Double, Righttail As Double)
        Const Rmax = 100
        Const pmax = 10

        Dim j1 As Integer, k As Integer, r As Integer, i As Integer, j As Integer
        Dim sum As Double, cc As Double, nu As Double
        Dim q() As Double, l() As Double
        Dim ar As Double, RelError As Double, density As Double, faktor As Double,
          LeftTail2 As Double, RightTail2 As Double
        Dim sign As Double, a As Double, m2 As Double, sum2 As Double, summand2 As Double
        Dim d() As Integer
        Dim sb(,) As Double
        Dim bb() As Double
        Dim UseBernoulli As Boolean, UseFullChi2 As Boolean, UseLnGamma As Boolean
        Dim Kp As Double
        ReDim q(Rmax)
        ReDim l(Rmax)
        ReDim d(pmax)
        ReDim sb(pmax, 10000)
        ReDim bb(pmax)
        Kp = 1
        UseBernoulli = False
        UseFullChi2 = False
        UseLnGamma = False
        x = -Math.Log(x)
        cc = 0
        nu = 0
        m2 = 0
        For i = 1 To p
            nu = nu + c(i) - b(i)
            m2 = m2 + (c(i)) ^ 2 - (b(i)) ^ 2
        Next i
        a = 0.5 * ((m2 / nu) - 1)

        If Not (UseBernoulli) Then
            For j = 1 To p
                If odd_f1 Then
                    If ((j Mod 2) <> 0) Then j1 = j + 1 Else j1 = j - 1
                Else
                    j1 = j
                End If
                bb(j) = b(j1) - a

                Dim temp As Double = Int(c(j) - b(j1) + 0.5)
                d(j) = Convert.ToInt32(temp)

                '      d(j) = Int(c(j) - b(j1) + 0.5)

                ' new(sb(j))
                For k = 0 To d(j)
                    sb(j, k) = 1
                Next k
            Next j
        End If

        If UseLnGamma Then
            For i = 1 To p
                cc = cc + LnGamma(c(i))
                cc = cc - LnGamma(b(i))
            Next i
            faktor = Math.Exp(cc - Math.Log(a) * nu)
        Else
            If Not (first) Then
                Kp = Kp * (c(1) - 1)
            Else
                Kp = 1
                For j = 1 To p
                    For k = 0 To d(j) - 1
                        Kp = Kp * (bb(j) + k + a)
                    Next k
                Next j
            End If
            faktor = Kp * Math.Exp(-Math.Log(a) * nu)
        End If

        Call cdis2(2 * nu, 2 * a * x, LeftTail2, RightTail2, density)
        sum2 = LeftTail2
        RelError = 1
        r = 1
        ar = 1
        l(0) = 1


        While (((RelError > 0.0000000000000001) Or (((r + 1) Mod 2) <> 0) Or (r < 10)) And (r < Rmax))
            If UseFullChi2 Then
                Call cdis2(2 * (nu + r), 2 * a * x, LeftTail2, RightTail2, density)
            Else
                density = density * (2 * a * x) / (2 * (nu + r - 1))
                LeftTail2 = LeftTail2 - 2 * density
            End If
            ar = ar / a
            If (((r + 1) Mod 2) <> 0) Then sign = -1 Else sign = 1
            If UseBernoulli Then
                sum = 0
                For j = 1 To p
                    sum = sum + Bernoulli(r + 1, b(j) - a) - Bernoulli(r + 1, c(j) - a)
                Next j
                q(r) = sign * sum / (r * (r + 1))
            Else
                sum = 0
                For j = 1 To p
                    For k = 0 To d(j) - 1
                        sb(j, k) = sb(j, k) * (bb(j) + k)
                        sum = sum + sb(j, k)
                    Next k
                Next j
                q(r) = -sign * sum / r
            End If
            sum = 0
            For k = 1 To r : sum = sum + k * q(k) * l(r - k) : Next k
            l(r) = sum / r
            summand2 = LeftTail2 * l(r) * ar
            sum2 = sum2 + summand2
            RelError = summand2 / sum2
            Console.WriteLine("r: {0}, LeftTail2: {1}, q(r) * ar: {2}, RelError: {3}, ", r, LeftTail2, q(r) * ar, RelError)
            r = r + 1
        End While
        LeftTail = faktor * sum2
        Righttail = 1 - LeftTail
    End Sub


    Sub WilksExactN2(IsRho As Boolean, p As Integer, f1 As Integer, f2 As Double, l As Double,
     lambda As Double, LeftTail As Double, Righttail As Double)
        Dim k As Integer, i As Integer
        Dim b() As Double, c() As Double
        Dim summand As Double, RelError As Double, sum As Double, Factor As Double, ck As Double
        Dim n2 As Double, Rho2 As Double, IsOdd_f1 As Boolean
        Const pi = 3.14159265358979
        
        ReDim b(p+1)
        ReDim c(p+1)
        If p > f1 Then
            Console.WriteLine("WilksExact: p must be <= f1")
            Exit Sub
        End If
        If l <= Math.Exp(-2 * pi) Then
            Console.WriteLine("WilksExact: L must be > exp(-2*pi)")
            Exit Sub
        End If
        IsOdd_f1 = ((f1 Mod 2) <> 0)
        lambda = lambda / 2
        Rho2 = 2 * lambda / (2 * lambda + f2)
        For i = 1 To p
            b(i) = (f2 - i + 1) / 2
            c(i) = b(i) + f1 / 2
        Next i
        ck = c(1)
        n2 = c(1)
        '{  BetaProdDis2(p,b,c,L,LeftTail,RightTail)}
        Call BetaProdDis5(True, IsOdd_f1, p, b, c, l, LeftTail, Righttail)
        sum = LeftTail
        If lambda > 0 Then RelError = 1 Else RelError = 0
        k = 0
        Factor = 1
        While RelError > 0.0000000000000001
            k = k + 1
            c(1) = ck + k
            If IsRho Then
                Factor = Factor * (n2 + k - 1) * Rho2 / k
            Else
                Factor = Factor * lambda / k
            End If
            '{    BetaProdDis2(p,b,c,L,LeftTail,RightTail)}
            Call BetaProdDis5(False, IsOdd_f1, p, b, c, l, LeftTail, Righttail)
            summand = LeftTail * Factor
            sum = sum + summand
            If sum <> 0 Then RelError = summand / sum
            Console.WriteLine("k: {0}, sum: {1}, RelError: {2}, ", k, sum, RelError)
        End While

        Console.WriteLine("Wilks Lambda, exact: {0} terms were used", k)
        If IsRho Then
            LeftTail = Math.Exp(Math.Log(1 - Rho2) * n2) * sum
        Else
            LeftTail = Math.Exp(-lambda) * sum
        End If
        Righttail = 1 - LeftTail
    End Sub







    Function R2DisX0(LeftTail As Double, Righttail As Double, a As Double, b As Double) As Double
        Dim x As Double, y As Double, w As Double
        w = Fdisx(LeftTail, Righttail, a, b)
        x = a * w / (a * w + b)
        y = b / (a * w + b)
        R2DisX0 = x
    End Function



    Function GRDisX(LeftTail As Double, Righttail As Double, p As Integer, m As Double, n As Double) As Double
        Dim x As Double ', y As Double
        LeftTail = Math.Exp(Math.Log(LeftTail) / p)
        Righttail = 1 - LeftTail
        x = R2DisX0(LeftTail, Righttail, m, n)
        GRDisX = x
    End Function




    ' Roy's Greatest Root
    ' Noncentral distribution function
    Function GRDisN(IsRho As Boolean, Model As String, p As Integer,
m As Double, n As Double, x As Double, omega() As Double) As Double
        Dim result As Double, Left1 As Double, rho As Double
        Dim i As Integer, IsGLM As Boolean
        Dim LeftTail As Double, Righttail As Double
        result = 1
        If Model = "GLM" Then IsGLM = True Else IsGLM = False
        For i = 1 To p
            'If IsRho Then rho = omega(i) Else rho = omega(i) / (n + omega(i))
            If IsRho Then rho = omega(i - 1) Else rho = omega(i - 1) / (n + omega(i - 1))
            Call R2DisN(IsGLM, m, n, x, rho, LeftTail, Righttail)
            Left1 = LeftTail
            result = result * Left1
        Next i
        GRDisN = result
    End Function

    ' Wilk's U
    ' Noncentral distribution function
    Function UdisN(Model As String, p As Integer,
q As Double, n As Double, x As Double, omega() As Double) As Double
        Dim LeftTail As Double, Righttail As Double ', i As Integer
        Dim IsRho As Boolean
        'Dim omega1(0 To 100) As Double
        IsRho = False
        'For i = 1 To p
        '    omega1(i) = omega(i)
        'Next i
        Call UT2VGRdisN(1, IsRho, Model, p, q, n, x, LeftTail, Righttail, omega)
        UdisN = LeftTail
    End Function

    ' Hotelling's T²
    ' Noncentral distribution function
    Function T2disN(Model As String, p As Integer,
q As Double, n As Double, x As Double, omega() As Double) As Double
        Dim LeftTail As Double, Righttail As Double ', i As Integer
        Dim IsRho As Boolean
        'Dim omega1(0 To 100) As Double
        IsRho = False
        'For i = 1 To p
        '    omega1(i) = omega(i)
        'Next i
        Call UT2VGRdisN(2, IsRho, Model, p, q, n, x, LeftTail, Righttail, omega)
        T2disN = LeftTail
    End Function

    ' Pillai 's V
    ' Noncentral distribution function
    Function VdisN(Model As String, p As Integer,
q As Double, n As Double, x As Double, omega() As Double) As Double
        Dim LeftTail As Double, Righttail As Double ', i As Integer
        Dim IsRho As Boolean
        'Dim omega1(0 To 100) As Double
        IsRho = False
        'For i = 1 To p
        '    omega1(i) = omega(i)
        'Next i
        Call UT2VGRdisN(3, IsRho, Model, p, q, n, x, LeftTail, Righttail, omega)
        VdisN = LeftTail
    End Function


    Sub UT2VGRdisN(dis As Integer, IsRho As Boolean, Model As String,
       p As Integer, q As Double, n As Double, x As Double,
       ByRef LeftTail As Double, ByRef Righttail As Double, omega() As Double)
        Dim a(0 To 4) As Double
        Dim b(0 To 8) As Double
        Dim c(0 To 9) As Double
        Dim left(0 To 9) As Double, Right(0 To 9) As Double
        Dim o1 As Double, o2 As Double, o3 As Double, o4 As Double
        Dim f2 As Double, F As Double, sum0 As Double, sum1 As Double
        Dim sum2 As Double, sum3 As Double, o12 As Double
        Dim o13 As Double, o22 As Double, o23 As Double
        Dim i As Integer
        Dim g3 As Double, G As Double, g2 As Double, L0 As Double, l1 As Double
        Dim l2 As Double, l3 As Double, l4 As Double
        Dim m As Double, omeg As Double, q2 As Double, p2 As Double
        Dim r As Double, l As Double, s As Double, S1 As Double, s2 As Double
        Dim s3 As Double, s12 As Double, p2p As Double, H1 As Double
        Dim h As Double, q3 As Double, p3 As Double, p4 As Double, q4 As Double
        Dim p1 As Double, s22 As Double
        Dim show As Boolean
        Dim OutStr As String
        Dim x0(0 To 10) As Double, t0(0 To 10) As Double

        show = False
        If dis = 1 Then
            l = (q - p - 1) / 2
            m = n + l
            x = -m * Math.Log(x)
        Else
            If (dis = 2) Then
                If Model = "GLM" Then
                    m = n - p - 1
                Else
                    m = n
                End If
            Else
                m = n + q
            End If
            x = x * m
        End If

        o1 = 0
        o2 = 0
        o3 = 0
        o4 = 0
        For i = 1 To p
            'omeg = omega(i)
            omeg = omega(i - 1)
            '{if the nc parameter is given as canonical correlation}
            If IsRho Then omeg = n * omeg / (1 - omeg)
            If (Not (Model = "GLM") And (dis = 3)) Then omeg = n * omeg / (n - q + omeg)
            o1 = o1 + omeg
            o2 = o2 + (omeg) ^ 2
            o3 = o3 + omeg * (omeg) ^ 2
            o4 = o4 + (omeg) ^ 4
            'Console.WriteLine("omeg: {0}", omeg)
        Next i
        'Console.WriteLine("o1: {0}", o1)
        o1 = o1 / 2
        o2 = o2 / 4
        o3 = o3 / 8
        o4 = o4 / 16
        o12 = (o1) ^ 2
        o13 = o1 * o12
        o22 = (o2) ^ 2
        o23 = o2 * o22

        F = p * q
        f2 = F * F
        p2 = p * p
        q2 = q * q
        G = p + q + 1
        g2 = G * G
        g3 = g2 * G
        s = (p + q + 1) / 4
        s2 = s * s
        s3 = s * s2
        r = F * (p2 + q2 - 5) / 48

        ' Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
        L0 = (3 * F - 8) * g2 + 4 * G + 4 * (F + 2)
        l1 = -12 * F * g2
        l2 = 6 * (3 * F + 8) * g2
        l3 = -4 * ((3 * F + 16) * g2 + 4 * G + 4 * (F + 2))
        l4 = 3 * ((F + 8) * g2 + 4 * G + 4 * (F + 2))

        Select Case dis
            Case 1
                If show Then Console.WriteLine("Udis")
                ' Fujikoshi (1973), Ann. Inst. Math. Statist., 25, p. 423
                If Model = "GLM" Then
                    If show Then Console.WriteLine("GLM")
                    a(0) = 0
                    a(1) = 2 * s * o1
                    a(2) = -(2 * s * o1 - o2)
                    a(3) = -o2
                    a(4) = 0

                    b(0) = -r
                    b(1) = 0
                    b(2) = r - 4 * s2 * o1 + 2 * s2 * o12 + 2 * s * o2
                    b(3) = 4 * s2 * o1 - (1 + 4 * s2) * o12 - (1 + 8 * s) * o2 _
                          + 2 * s * o1 * o2 + (4 / 3) * o3
                    b(4) = (1 + 2 * s2) * o12 + (1 + 6 * s) * o2 - 4 * s * o1 * o2 _
                          - 4 * o3 + o22 / 2
                    b(5) = 2 * s * o1 * o2 + (8 / 3) * o3 - o22
                    b(6) = o22 / 2
                    b(7) = 0
                    b(8) = 0

                    c(0) = 0
                    c(1) = 2 * r * s * o1
                    c(2) = -r * (2 * s * o1 - o2)
                    c(3) = -2 * s * (r + 4 * s2) * o1 + 2 * s * (1 + 4 * s2) * o12 + (-r + 2 * s _
                           + 12 * s2) * o2 - (4 / 3) * s3 * o13 - 4 * s2 * o1 * o2 - (8 / 3) * s * o3
                    c(4) = 2 * s * (r + 4 * s2) * o1 - (1 + 10 * s + 16 * s3) * o12 - (3 + r _
                           + 10 * s + 36 * s2) * o2 + 2 * s * (1 + 2 * s2) * o13 + 2 * (2 + s _
                           + 12 * s2) * o1 * o2 + 4 * (1 + 6 * s) * o3 - 2 * s2 * o12 * o2 -
                           2 * s * o22 - (8 / 3) * s * o1 * o3 - 2 * o4
                    c(5) = (1 + 8 * s + 8 * s3) * o12 + (3 + r + 8 * s + 24 * s2) * o2 -
                           4 * s * (1 + s2) * o13 - 4 * (3 + s + 9 * s2) * o1 * o2 -
                           12 * (1 + 4 * s) * o3 + (1 + 6 * s2) * o12 * o2 + (1 + 10 * s) * o22 _
                           + (32 / 3) * s * o1 * o3 + 12 * o4 - (4 / 3) * o2 * o3 - s * o1 * o22
                    c(6) = s * (2 + (4 / 3) * s2) * o13 + 2 * (4 + s + 8 * s2) * o1 * o2 +
                           8 * (1 + (10 / 3) * s) * o3 - 2 * (1 + 3 * s2) * o12 * o2 - 2 * (1 +
                           7 * s) * o22 - (40 / 3) * s * o1 * o3 - 20 * o4 + (16 / 3) * o2 * o3 +
                           3 * s * o1 * o22 - (1 / 6) * o23
                    c(7) = (1 + 2 * s2) * o12 * o2 + (1 + 6 * s) * o22 + (16 / 3) * s * o1 * o3 +
                           10 * o4 - (20 / 3) * o2 * o3 - 3 * s * o1 * o22 + (1 / 2) * o23
                    c(8) = (8 / 3) * o2 * o3 + s * o1 * o22 - (1 / 2) * o23
                    c(9) = (1 / 6) * o23

                Else
                    If show Then Console.WriteLine("CORR")
                    a(0) = -q * o1 + o2
                    a(1) = (2 * s + q) * o1 - 2 * o2
                    a(2) = -2 * s * o1 + 2 * o2
                    a(3) = -o2
                    a(4) = 0

                    b(0) = -r - q * l * o1 + (q + l) * o2 + 0.5 * q * q * o12 - 4 * o3 / 3 _
                           - q * o1 * o2 + 0.5 * o22
                    b(1) = q2 * o1 - 4 * q * o2 - q * (q + 2 * s) * o12 + 4 * o3 _
                           + (3 * q + 2 * s) * o1 * o2 - 2 * o22
                    b(2) = r - 2 * s * (q + 2 * s) * o1 + (2 * p + 6 * q + 3) * o2 + (0.5 * l * l _
                           + 6 * q * s + 1) * o12 - 8 * o3 - (4 * q + 6 * s) * o1 * o2 + 4 * o22
                    b(3) = 4 * s2 * o1 - (3 * p + 5 * q + 5) * o2 - (4 * s2 + 2 * q * s + 2) * o12 _
                           + 32 * o3 / 3 + (3 * q + 8 * s) * o1 * o2 - 5 * o22
                    b(4) = (6 * s + 1) * o2 + (2 * s2 + 1) * o12 - 8 * o3 - (q + 6 * s) * o1 * o2 _
                           + 4 * o22
                    b(5) = 8 * o3 / 3 + 2 * s * o1 * o2 - 2 * o22
                    b(6) = 0.5 * o22
                    b(7) = 0
                    b(8) = 0

                    For i = 0 To 9
                        c(i) = 0
                    Next i
                End If

            Case 2
                If show Then Console.WriteLine("T2dis")
                ' Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
                If Model = "GLM" Then
                    If show Then Console.WriteLine("GLM")
                    a(0) = F * G
                    a(1) = -2 * G * (F - 2 * o1)
                    a(2) = F * G - 8 * G * o1 + 4 * o2
                    a(3) = 4 * (G * o1 - 2 * o2)
                    a(4) = 4 * o2

                    b(0) = F * L0
                    b(1) = l1 * (F - 2 * o1)
                    b(2) = F * l2 + 2 * (l1 - 2 * l2) * o1 + 48 * g2 * o12 + 24 * (F + 4) * G * o2
                    b(3) = F * l3 + 2 * (2 * l2 - 3 * l3) * o1 - 192 * (g2 + 1) * o12 _
                           - 96 * ((F + 8) * G + 2) * o2 + 96 * G * o1 * o2 + 128 * o3
                    b(4) = F * l4 + 2 * (3 * l3 - 4 * l4) * o1 + 96 * (3 * g2 + 7) * o12 _
                           + 48 * (3 * (F + 12) * G + 14) * o2 - 384 * G * o1 * o2 - 768 * o3 + 48 * o22
                    b(5) = 8 * l4 * o1 - 192 * (g2 + 4) * o12 - 96 * ((F + 16) * G + 8) * o2 _
                           + 576 * G * o1 * o2 + 1536 * o3 - 192 * o22
                    b(6) = 48 * (g2 + 6) * o12 + 24 * ((F + 20) * G + 12) * o2 - 384 * G * o1 * o2 _
                           - 1280 * o3 + 288 * o22
                    b(7) = 96 * G * o1 * o2 + 384 * o3 - 192 * o22
                    b(8) = 48 * o22

                Else
                    If show Then Console.WriteLine("CORR")
                    S1 = o1 * 2
                    s2 = o2 * 4
                    s3 = o3 * 8
                    s12 = S1 * S1
                    s22 = s2 * s2
                    p1 = p + 1
                    p3 = p2 * p
                    p4 = p3 * p
                    q3 = q2 * q
                    q4 = q3 * q
                    h = q * p1
                    H1 = 2 * q + p1
                    p2p = p2 + p

                    a(0) = q * p * (q - p - 1) - 2 * q * S1 + s2
                    a(1) = -2 * q2 * p + 4 * q * S1 - 2 * s2
                    a(2) = q * p * (q + p + 1) - 2 * (2 * q + p + 1) * S1 + 2 * s2
                    a(3) = 2 * (q + p + 1) * S1 - 2 * s2
                    a(4) = s2
                    b(0) = q * p * (3 * q * p3 - 2 * (3 * q2 - 3 * q + 4) * p2 + 3 * (q3 - 2 * q2 _
                           + 5 * q - 4) * p - 8 * q2 + 12 * q + 4) - 12 * q2 * p * (q - p - 1) _
                           * S1 - 6 * q * (p2 - q * p + p - 4) * s2 + 12 * q2 * s12 - 16 * s3 _
                          - 12 * q * S1 * s2 + 3 * s22
                    b(1) = -12 * q3 * p2 * (q - p - 1) - 24 * q2 * (p2 - 2 * q * p + p - 2) * S1 _
                           + 12 * q * (p2 - 2 * q * p + p - 8) * s2 - 48 * q2 * s12 + 48 * s3 _
                           + 48 * q * S1 * s2 - 12 * s22
                    b(2) = -6 * q2 * p4 - 12 * q2 * p3 + 18 * q2 * (q2 + 1) * p2 + 24 * q2 * (2 *
                           q + 1) * p + 12 * q * (p3 + 2 * p2 - 7 * (q2 + 1) * p - 16 * q - 8) * S1 _
                           - 6 * (q * p2 - (7 * q2 - q + 8) * p - 40 * q - 12) * s2 + 24 * (q * p _
                           + 4 * q2 + q + 1) * s12 - 12 * (p + 8 * q + 1) * S1 * s2 - 96 * s3 + 24 * s22
                    b(3) = -(12 * q3 + 16 * q) * p3 - (12 * q4 + 12 * q3 + 96 * q2 + 48 * q) * p2 _
                           - (64 * q3 + 96 * q2 + 64 * q) * p + 12 * (-q * p3 + (4 * q2 - 2 * q + 4) _
                           * p2 + (7 * q3 + 4 * q2 + 31 * q + 12) * p + 4 * (7 * q2 + 8 * q + 4)) * S1 _
                           - 48 * ((q2 + 3) * p + 9 * q + 5) * s2 - 24 * (3 * q * p + 5 * q2 + 3 * q _
                           + 4) * s12 + 176 * s3 + 12 * (3 * p + 11 * q + 3) * S1 * s2 - 36 * s22
                    b(4) = 3 * q2 * p4 + (6 * q3 + 6 * q2 + 24 * q) * p3 + (3 * q4 + 6 * q3 + 63 * q2 _
                           + 60 * q) * p2 + (24 * q3 + 60 * q2 + 60 * q) * p - 12 * (q * p3 + (5 * q2 _
                           + 2 * q + 12) * p2 + (4 * q3 + 5 * q2 + 45 * q + 32) * p + 4 * (6 * q2 + 11 _
                           * q + 9)) * S1 + 6 * (q * p2 + (7 * q2 + q + 44) * p + 88 * q + 76) * s2 _
                          + 12 * (p2 + 2 * (4 * q + 1) * p + 8 * q2 + 8 * q + 17) * s12 _
                          - 12 * (4 * p + 11 * q + 4) * S1 * s2 - 240 * s3 + 42 * s22
                    b(5) = (12 * q * p3 + 24 * (q2 + q + 4) * p2 + 12 * (q3 + 2 * q2 + 21 * q + 20) _
                           * p + 48 * (2 * q2 + 5 * q + 5)) * S1 - 12 * (q * p2 + (2 * q2 + q + 24) _
                           * p + 32 * q + 40) * s2 - 24 * (p2 + (3 * q + 2) * p + 2 * q2 + 3 * q + 9) _
                           * s12 + 240 * s3 + 48 * (p + 2 * q + 1) * S1 * s2 - 36 * s22
                    b(6) = (6 * q * p2 + 6 * (q2 + q + 20) * p + 120 * q + 192) * s2 + (12 * p2 + 24 _
                           * (q + 1) * p + 12 * (q2 + 2 * q + 7)) * s12 - 12 * (3 * p + 4 * q + 3) _
                           * S1 * s2 - 160 * s3 + 24 * s22
                    b(7) = 48 * s3 + 12 * (q + p + 1) * S1 * s2 - 12 * s22
                    b(8) = 3 * s22
                End If

            Case 3
                ' Pillai's V, Manova
                ' Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
                If show Then Console.WriteLine("Vdis")
                If Model = "GLM" Then
                    If show Then Console.WriteLine("GLM")
                    a(0) = -F * G
                    a(1) = 2 * F * G
                    a(2) = -F * G + 4 * G * o1 + 4 * o2
                    a(3) = -4 * G * o1
                    a(4) = -4 * o2

                    b(0) = F * L0
                    b(1) = F * l1
                    b(2) = F * l2 + 2 * l1 * o1 - 24 * F * G * o2
                    b(3) = F * l3 + 4 * l2 * o1 + 48 * (F + 4) * G * o2 + 128 * o3
                    b(4) = F * l4 + 6 * l3 * o1 + 48 * (g2 - 2) * o12 - 96 * (G + 1) * o2 _
                           + 96 * G * o1 * o2 + 48 * o22
                    b(5) = 8 * (l4 * o1 - 12 * (g2 + 2) * o12 - 6 * ((F + 12) * G + 4) * o2 _
                           - 12 * G * o1 * o2 - 48 * o3)
                    b(6) = 8 * (6 * (g2 + 6) * o12 + 3 * ((F + 20) * G + 12) * o2 _
                           - 12 * G * o1 * o2 - 16 * o3 - 12 * o22)
                    b(7) = 96 * (G * o1 * o2 + 4 * o3)
                    b(8) = 48 * o22
                Else
                    If show Then Console.WriteLine("CORR")
                    a(0) = -F * G - 4 * o2
                    a(1) = 2 * F * G
                    a(2) = -F * G + 4 * G * o1 + 8 * o2
                    a(3) = -4 * G * o1
                    a(4) = -4 * o2
                    b(0) = F * L0 + 24 * F * G * o2 - 128 * o3 + 48 * o22
                    b(1) = F * l1 - 48 * F * G * o2
                    b(2) = F * l2 + 2 * l1 * o1 + 96 * o12 - 24 * (q * p2 + q * (q + 1) _
                           * p - 4) * o2 - 96 * G * o1 * o2 - 192 * o22
                    b(3) = F * l3 + 4 * l2 * o1 + 96 * (q * p2 + (q2 + q + 4) * p _
                           + 4 * (q + 1)) * o2 + 96 * G * o1 * o2 + 640 * o3
                    b(4) = F * l4 + 6 * l3 * o1 + 48 * (p2 + 2 * (q + 1) * p + q2 _
                           + 2 * q - 3) * o12 - 24 * (q * p2 + (q2 + q + 12) * p _
                           + 4 * (3 * q + 5)) * o2 + 192 * G * o1 * o2 + 288 * o22
                    b(5) = 8 * l4 * o1 - 96 * (p2 + 2 * (q + 1) * p + q2 + 2 * q + 3) * o12 _
                          - 48 * (q * p2 + (q2 + q + 12) * p + 4 * (3 * q + 4)) * o2 _
                          - 192 * G * o1 * o2 - 768 * o3
                    b(6) = 48 * (p2 + 2 * (q + 1) * p + q2 + 2 * q + 7) * o12 + 24 * (q * p2 _
                           + (q2 + q + 20) * p + 4 * (5 * q + 8)) * o2 - 96 * G * o1 * o2 _
                           - 128 * o3 - 192 * o22
                    b(7) = 96 * (G * o1 * o2 + 4 * o3)
                    b(8) = 48 * o22
                End If
        End Select

        If ((o1 = 0) And (dis <> 1)) Then
            c(0) = G * ((f2 - 8 * F + 16) * g2 + 4 * (F - 4) * G + 4 * (f2 - 2 * F - 8))
            c(1) = -2 * F * G * L0
            c(2) = F * G * (5 * (3 * F + 8) * g2 + 4 * G + 4 * (F + 2))
            c(3) = -(4 * G * (5 * (f2 + 8 * F + 16) * g2 + 4 * (F + 4) * G _
                   + 4 * (f2 + 6 * F + 8)))
            c(4) = 5 * (3 * f2 + 40 * F + 144) * g3 + 4 * (11 * F + 108) * g2 _
                   + 4 * (11 * f2 + 130 * F + 288) * G + 96 * (F + 2)
            c(5) = -(2 * ((3 * f2 + 56 * F + 288) * g3 + 4 * (5 * F + 72) * g2 _
                   + 4 * (5 * f2 + 82 * F + 216) * G + 96 * (F + 2)))
            c(6) = (f2 + 24 * F + 160) * g3 + 4 * (3 * F + 56) * g2 + 4 * (3 * f2 _
                   + 62 * F + 184) * G + 96 * (F + 2)
            c(7) = 0
            c(8) = 0
            c(9) = 0
        End If

        For i = 0 To 9
            Call Cdisn2(F + 2 * i, x, 2 * o1, LeftTail, Righttail)
            left(i) = LeftTail
        Next i

        sum0 = left(0)
        If show Then
            OutStr = Str(sum0)
            OutStr = "sum0:  " + OutStr
            Console.WriteLine(OutStr)
        End If
        sum1 = 0
        For i = 0 To 4
            sum1 = sum1 + a(i) * left(i)
        Next i
        sum1 = sum1 / m
        If dis <> 1 Then sum1 = sum1 / 4
        If show Then
            OutStr = Str(sum1)
            OutStr = "sum1:  " + OutStr
            Console.WriteLine(OutStr)
        End If

        sum2 = 0
        For i = 0 To 8
            sum2 = sum2 + b(i) * left(i)
        Next i
        sum2 = sum2 / (m * m)
        If dis <> 1 Then sum2 = sum2 / 96

        If show Then
            OutStr = Str(sum2)
            OutStr = "sum2:  " + OutStr
            Console.WriteLine(OutStr)
        End If

        sum3 = 0
        If ((o1 = 0) Or ((dis = 1) And (Model = "GLM"))) Then
            For i = 0 To 9
                sum3 = sum3 + c(i) * left(i)
            Next i
        End If
        sum3 = sum3 / (m * m * m)
        If dis <> 1 Then sum3 = F * sum3 / 384
        If ((dis = 3) Or (dis = 1)) Then sum3 = -sum3
        If show Then
            OutStr = Str(sum3)
            OutStr = "sum3:  " + OutStr
            Console.WriteLine(OutStr)
        End If
        'If (sum0 * sum1 * sum2) <> 0 Then
        't0(0) = -Abs(sum0):: x0(0) = -1
        't0(1) = -Abs(sum1):: x0(1) = -1 / Sqr(m)
        't0(2) = -Abs(sum2):: x0(2) = -1 / (m)
        't0(3) = Abs(sum2):: x0(3) = 1 / (m)
        't0(4) = Abs(sum1):: x0(4) = 1 / Sqr(m)
        't0(5) = Abs(sum0):: x0(5) = 1
        'result = interpolate(True, 1 / (m * Sqr(m)), 0, 5, x0(), t0())
        'If ((sum1 < 0) And (sum2 < 0)) Then result = -result
        'If show Then Debug.Print "Result   :", result
        'End If
        LeftTail = sum0 + sum1 + sum2 + sum3
        'If (LeftTail + sum1 < 1) And (LeftTail + sum1 > 0) Then LeftTail = LeftTail + sum1
        'If (LeftTail + sum2 < 1) And (LeftTail + sum2 > 0) Then LeftTail = LeftTail + sum2
        'If (LeftTail + sum3 < 1) And (LeftTail + sum3 > 0) Then LeftTail = LeftTail + sum3
        Righttail = 1 - LeftTail
        'If show Then Debug.Print "New:", LeftTail + result
        'Console.WriteLine("LeftTail: {0}, Righttail: {1}", LeftTail, Righttail)
    End Sub




End Module


