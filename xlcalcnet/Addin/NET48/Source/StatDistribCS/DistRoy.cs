
// Imports System
// Imports System.Numerics
// Imports System.Diagnostics
// 'Imports mpFunLabNET
// 'Imports fpFunLabNET
// 
// 
// 
// Module DistRoy
// 
// 
// Function TW1(x As Double) As Double
// Dim k As Double = 46.446
// Dim t As Double = 0.186054
// Dim a As Double = 9.84801
// Dim P1 = boost2.gamma_p(k, (x + a) / t)
// Return P1
// End Function
// 
// Sub DemoTW1()
// Console.WriteLine("Result: {0}", TW1(3.24))
// End Sub
// 
// 
// 'Function IBeta(x As Double, a As Double, b As Double) As Double
// '    Dim LeftTail As Double, Righttail As Double, density As Double
// '    Call betadis(a, b, x, 1 - x, LeftTail, Righttail, density)
// '    IBeta = LeftTail * boost.beta(a, b)
// '    Dim resarb = apr.beta_lower(a, b, x)
// 'End Function
// 
// Function beta_lower(a As Double, b As Double, x As Double) As Double
// Dim LeftTail As Double, Righttail As Double, density As Double
// Call betadis(a, b, x, 1 - x, LeftTail, Righttail, density)
// Dim res = LeftTail * boost2.beta(a, b)
// 'Dim res2 As Double = apr.beta_lower(a, b, x)
// 'Dim resarb = apr.beta_lower(a, b, x)
// 'Console.WriteLine("res: {0}, res2: {1}, resarb: {2}", res, res2, resarb)
// Return res.ToDouble
// End Function
// 
// 
// 'Chiani 2017, Algorithm 1
// Function Roy_Chiani(x As Double, s As Int32, m As Double, n As Double) As Double
// Dim d = s + (s Mod 2)
// Dim k = n + 1
// Dim b = apr_mat.set_zero(s, 1)
// Dim t = apr_mat.set_zero(s, 1)
// Dim A = apr_mat.set_zero(d, d)
// 
// For i = 0 To s - 1
// t(i) = beta_lower(m + i + 1, k, x)
// If (s <> d) Then
// A(i, s) = t(i)
// A(s, i) = -A(i, s)
// End If
// Next
// 
// If (s <> 1) Then
// For i = 0 To s - 1
// b(i) = 0.5 * t(i) * t(i)
// For j = i + 1 To s - 1
// b(j) = ((m + j) * b(j - 1) - beta_lower(2 * m + i + j + 1, 2 * k, x)) / (m + j + k)
// A(i, j) = t(i) * t(j) - 2 * b(j)
// A(j, i) = -A(i, j)
// Next
// Next
// End If
// 
// Dim det = A.det()(0, 0)
// 
// 
// Console.WriteLine("Det: {0}, Det: {1}", det, Math.Log(det.ToDouble))
// 
// 
// 
// Dim res1 = A.colPivHouseholderQr2("logabsdet", A)
// Console.WriteLine("logabsdet1: {0}", res1("logabsdet")(0, 0))
// 
// Dim res2 = A.fullPivHouseholderQr2("logabsdet", A)
// Console.WriteLine("logabsdet2: {0}", res2("logabsdet")(0, 0))
// 
// 
// Dim res3 = A.COD2("logabsdet", A)
// Console.WriteLine("logabsdet3: {0}", res3("logabsdet")(0, 0))
// 
// 
// Dim sqrtdet = apr.sqrt(det)
// Return sqrtdet.ToDouble
// End Function
// 
// 
// 'Chiani 2017, Algorithm 1
// Function apr_Roy_A(x As apr_t, s As Int32, m As apr_t, n As apr_t) As apr_mat_t
// Dim d = s + (s Mod 2)
// Dim k = n + 1
// Dim b = apr_mat.set_zero(s, 1)
// Dim t = apr_mat.set_zero(s, 1)
// Dim A = apr_mat.set_zero(d, d)
// Dim m2 As Int32 = (2 * m).ToInt32
// Dim xinv = 1 / x
// 
// Dim b1 = k
// Dim z = (1 - x) ^ b1
// Dim xa1 = z * x ^ (m + s)
// t(s - 1) = apr.beta_lower(m + s, b1, x)
// For i = s - 2 To 0 Step -1
// Dim a1 = m + i + 1
// xa1 = xa1 * xinv
// t(i) = ((a1 + b1) * t(i + 1) + xa1) / a1
// If (s <> d) Then
// A(i, s) = t(i)
// A(s, i) = -A(i, s)
// End If
// Next
// 
// 
// If (s <> 1) Then
// Dim amin As Int32 = m2 + 2
// Dim amax As Int32 = m2 + 2 * (s - 1)
// Dim t4 = apr_mat.set_zero(amax - amin + 1, 1)
// 'Console.WriteLine("amin: {0}", amin)
// 'Console.WriteLine("amax: {0}", amax)
// 
// b1 = 2 * k
// z = (1 - x) ^ b1
// xa1 = z * x ^ (amax)
// t4(amax - amin) = apr.beta_lower(amax, b1, x)
// For a1 = amax - 1 To amin Step -1
// xa1 = xa1 * xinv
// t4(a1 - amin) = ((a1 + b1) * t4(a1 + 1 - amin) + xa1) / a1
// Next
// 
// 
// For i = 0 To s - 1
// b(i) = 0.5 * t(i) * t(i)
// For j = i + 1 To s - 1
// Dim a1 = m2 + i + j + 1
// Dim t6 = t4(a1 - amin)
// b(j) = ((m + j) * b(j - 1) - t6) / (m + j + k)
// A(i, j) = t(i) * t(j) - 2 * b(j)
// A(j, i) = -A(i, j)
// Next
// Next
// End If
// 
// Return A
// End Function
// 
// Function Trace(A As apr_mat_t) As apr_t
// Dim sum = apr.t(0)
// For i = 0 To A.rows - 1
// sum = sum + A(i, i)
// Next
// Return sum
// End Function
// 
// 
// 'Chiani 2017, Algorithm 1
// Function apr_Roy_Chiani(x As apr_t, s As Int32, m As apr_t, n As apr_t, ByRef pdf_factor As apr_t) As apr_t
// 
// Dim eps = apr.t("10E-20")
// Dim A = apr_Roy_A(x, s, m, n)
// 'Dim A1 = apr_Roy_A(x + eps, s, m, n)
// 'Dim A2 = apr_Roy_A(x - eps, s, m, n)
// 'Dim ADiff = (A1 - A2) / (2 * eps)
// 
// Console.WriteLine("start det")
// 
// 'Dim res0 = A.fullPivLu2("det, x", ADiff)
// Dim res0 = A.fullPivLu2("det, x", A)
// Dim det = res0("det")(0, 0)
// Dim Xmat = res0("x")
// Dim tr = Trace(Xmat)
// Console.WriteLine("tr(Xmat): {0}", tr)
// pdf_factor = 0.5 * tr
// 
// Console.WriteLine("mat_fullPivLu2 det: {0}, Log(Det): {1}", det, apr.log(det))
// 
// Dim sqrtdet = apr.sqrt(det)
// Console.WriteLine("sqrtdet: {0}", sqrtdet)
// Return sqrtdet
// End Function
// 
// 
// 'Chiani 2017, Algorithm 1
// Function apr_Roy_Chiani2(x As apr_t, s As Int32, m As apr_t, n As apr_t) As apr_t
// Dim d = s + (s Mod 2)
// Dim k = n + 1
// Dim b = apr_mat.set_zero(s, 1)
// Dim t = apr_mat.set_zero(s, 1)
// Dim A = apr_mat.set_zero(d, d)
// Dim m2 As Int32 = (2 * m).ToInt32
// Dim xinv = 1 / x
// 
// Dim b1 = k
// Dim z = (1 - x) ^ b1
// Dim xa1 = z * x ^ (m + s)
// t(s - 1) = apr.beta_lower(m + s, b1, x)
// For i = s - 2 To 0 Step -1
// Dim a1 = m + i + 1
// xa1 = xa1 * xinv
// t(i) = ((a1 + b1) * t(i + 1) + xa1) / a1
// If (s <> d) Then
// A(i, s) = t(i)
// A(s, i) = -A(i, s)
// End If
// Next
// 
// 
// If (s <> 1) Then
// Dim amin As Int32 = m2 + 2
// Dim amax As Int32 = m2 + 2 * (s - 1)
// Dim t4 = apr_mat.set_zero(amax - amin + 1, 1)
// Console.WriteLine("amin: {0}", amin)
// Console.WriteLine("amax: {0}", amax)
// 
// b1 = 2 * k
// z = (1 - x) ^ b1
// xa1 = z * x ^ (amax)
// t4(amax - amin) = apr.beta_lower(amax, b1, x)
// For a1 = amax - 1 To amin Step -1
// xa1 = xa1 * xinv
// t4(a1 - amin) = ((a1 + b1) * t4(a1 + 1 - amin) + xa1) / a1
// Next
// 
// 
// For i = 0 To s - 1
// b(i) = 0.5 * t(i) * t(i)
// For j = i + 1 To s - 1
// Dim a1 = m2 + i + j + 1
// Dim t6 = t4(a1 - amin)
// b(j) = ((m + j) * b(j - 1) - t6) / (m + j + k)
// A(i, j) = t(i) * t(j) - 2 * b(j)
// A(j, i) = -A(i, j)
// Next
// Next
// End If
// 
// A.print("Matrix A:", 15)
// 
// Console.WriteLine("start det")
// 
// Dim res0 = A.fullPivLu2("det", A)
// Dim det = res0("det")(0, 0)
// Console.WriteLine("mat_fullPivLu2 det: {0}, Log(Det): {1}", det, apr.log(det))
// 
// Dim sqrtdet = apr.sqrt(det)
// Console.WriteLine("sqrtdet: {0}", sqrtdet)
// Return sqrtdet
// End Function
// 
// 
// Function Roy_Const(s As Int32, m As Double, n As Double) As Double
// Dim C1 As Double = 0.0
// For i = 1 To s
// C1 += apr.lgamma(0.5 * (i + 2 * m + 2 * n + s + 2)).ToDouble _
// - apr.lgamma(0.5 * i).ToDouble _
// - apr.lgamma(0.5 * (i + 2 * m + 1)).ToDouble _
// - apr.lgamma(0.5 * (i + 2 * n + 1)).ToDouble
// Next
// Dim C As Double = Math.Pow(Math.PI, 0.5 * s) * Math.Exp(C1)
// Console.WriteLine("C: {0}", C)
// 
// Return C
// End Function
// 
// 
// Function apr_Roy_Const(s As Int32, m As apr_t, n As apr_t) As apr_t
// Dim C1 = apr.t(0)
// For i = 1 To s
// C1 += apr.lgamma(0.5 * (i + 2 * m + 2 * n + s + 2)) _
// - apr.lgamma(0.5 * i) _
// - apr.lgamma(0.5 * (i + 2 * m + 1)) _
// - apr.lgamma(0.5 * (i + 2 * n + 1))
// Next
// Dim C = apr.pow(apr.const_pi(), 0.5 * s) * apr.exp(C1)
// Console.WriteLine("C: {0}", C)
// 
// Return C
// End Function
// 
// 
// Function RoyCDF(x As Double, p As Int32, n1 As Double, n2 As Double) As Double
// Dim m = 0.5 * (Math.Abs(n1 - p) - 1)
// Dim n = 0.5 * (Math.Abs(n2 - p) - 1)
// Return Roy_Const(p, m, n) * Roy_Chiani(x, p, m, n)
// End Function
// 
// Function apr_RoyCDF(x As apr_t, p As Int32, n1 As apr_t, n2 As apr_t) As apr_t
// Dim pdf_factor = apr.t(0)
// Dim m = 0.5 * (apr.abs(n1 - p) - 1)
// Dim n = 0.5 * (apr.abs(n2 - p) - 1)
// Dim C = apr_Roy_Const(p, m, n)
// Dim SqrtDet = apr_Roy_Chiani(x, p, m, n, pdf_factor)
// Console.WriteLine("pdf_factor: {0}", pdf_factor)
// Dim pdf = C * SqrtDet * pdf_factor
// Console.WriteLine("pdf: {0}", pdf)
// Return C * SqrtDet
// End Function
// 
// 
// Function gpr_RoyCDF(x As gpr_t, p As Int32, n1 As gpr_t, n2 As gpr_t) As gpr_t
// Dim result = apr_RoyCDF(x, p, n1, n2)
// Return gpr.t(result)
// End Function
// 
// 
// 
// Function RoyCDFApprox(t1 As Double, p As Double, n1 As Double, n2 As Double) As Double
// Dim k = 46.446
// Dim delta = 0.186054
// Dim alpha = 9.84801
// 
// Dim phi = Math.Acos((n2 - n1) / (n2 + n1 - 1))
// Dim g = Math.Acos((n2 + n1 - 2 * p) / (n2 + n1 - 1))
// Dim s3 = 16 / (((n2 + n1 - 1) ^ 2) * (Math.Sin(g + phi) ^ 2) * Math.Sin(g) * Math.Sin(phi))
// 
// Dim mu = 2 * Math.Log(Math.Tan((g + phi) / 2))
// Dim sigma = s3 ^ (1 / 3)
// Dim x = (Math.Log(t1 / (1 - t1)) - mu + sigma * alpha) / (delta * sigma)
// Dim P1 = apr.gamma_p(k, x)
// Return P1.ToDouble
// End Function
// 
// 
// 
// Function RoyQuantileApprox(LeftTail As Double, p As Double, n1 As Double, n2 As Double) As Double
// Dim k = 46.446
// Dim delta = 0.186054
// Dim alpha = 9.84801
// 
// Dim phi = Math.Acos((n2 - n1) / (n2 + n1 - 1))
// Dim g = Math.Acos((n2 + n1 - 2 * p) / (n2 + n1 - 1))
// Dim s3 = 16 / (((n2 + n1 - 1) ^ 2) * (Math.Sin(g + phi) ^ 2) * Math.Sin(g) * Math.Sin(phi))
// 
// Dim mu = 2 * Math.Log(Math.Tan((g + phi) / 2))
// Dim sigma = s3 ^ (1 / 3)
// Dim P1 = apr.gamma_p_inv(k, LeftTail).ToDouble
// Dim num = Math.Exp(sigma * (delta * P1 - alpha) + mu)
// Dim result = num / (1 + num)
// Return result
// End Function
// 
// 
// Sub Swap(ByRef a As Int32, ByRef b As Int32)
// Dim Tmp As Int32 = a
// a = b
// b = Tmp
// End Sub
// 
// Sub RoyDemoAnderson()
// Dim x1 = 3.512
// x1 = 4.692
// 'Dim x1 = 4.235
// 'Dim x1 = 5.938
// 'Dim x1 = apr.t(2.16)
// 
// Dim p = 2
// Dim n1 = 3
// Dim n2 = 123   '128
// Console.WriteLine("x1 (Anderson): {0}", x1)
// 
// Dim f = n1 / (n2 + n1)
// Dim x = x1 * f
// Console.WriteLine("x: {0}", x)
// 
// If (n1 < p) Then
// n2 = n2 + n1 - p
// Swap(p, n1)
// Console.WriteLine("New p: {0}", p)
// Console.WriteLine("New n1: {0}", n1)
// Console.WriteLine("New n2: {0}", n2)
// End If
// 
// 'Dim Result0 = RoyCDF(x, p, n1, n2)
// 'Console.WriteLine("Result0: {0}", Result0)
// 
// 
// Dim Result1 = apr_RoyCDF(x, p, n1, n2)
// Console.WriteLine("Result1: {0}", Result1)
// 
// Dim Result2 = RoyCDFApprox(x, p, n1, n2)
// Console.WriteLine("Result2: {0}", Result2)
// 
// Dim x2 = RoyQuantileApprox(Result1.ToDouble, p, n1, n2)
// Console.WriteLine("x2: {0}", x2)
// 
// 'x2 = x2 / f
// 'Console.WriteLine("x2 (Anderson): {0}", x2)
// End Sub
// 
// 
// Sub RoyDemo()
// Dim LeftTail = apr.t("0.99")
// 
// Dim p = 2
// 'Dim n1 = 100  ' m = -1/2 implies n1 = p
// 'Dim n2 = 88   ' n = 100 implies n2 = 201 + p
// 
// Dim n1 = 2 * p  ' m = -1/2 implies n1 = p
// 'Dim n2 = 201 + p   ' n = 100 implies n2 = 201 + p
// Dim n2 = 300 + p   ' n = 100 implies n2 = 201 + p
// 
// ' m=-0.5; n=100; p=5, 15, 100 
// 'Dim 0 = (n1 - p) 
// 'Dim 2*n+1+p = n2
// 
// 
// If (n1 < p) Then
// n2 = n2 + n1 - p
// Swap(p, n1)
// Console.WriteLine("New p: {0}", p)
// Console.WriteLine("New n1: {0}", n1)
// Console.WriteLine("New n2: {0}", n2)
// End If
// 
// Dim x As Double = RoyQuantileApprox(LeftTail.ToDouble, p, n1, n2)
// Console.WriteLine("x: {0}", x)
// 
// Dim Result1 = apr_RoyCDF(x, p, n1, n2)
// Console.WriteLine("Result1: {0}", Result1)
// 
// 'Dim eps = apr.t("1E-20")
// 'Dim D1 = apr_RoyCDF(x + eps, p, n1, n2)
// 'Console.WriteLine("Result1: {0}", Result1)
// 'Dim D2 = apr_RoyCDF(x - eps, p, n1, n2)
// 'Console.WriteLine("Result1: {0}", Result1)
// 'Dim pdf = (D1 - D2) / (2 * eps)
// 'Console.WriteLine("pdf: {0}", pdf)
// 
// 'Dim Result2 = RoyCDFApprox(x, p, n1, n2)
// 'Console.WriteLine("Result2: {0}", Result2)
// 
// End Sub
// 
// 
// 
// 
// 
// 
// Function NdisMpfr(x As gpr_t) As gpr_t
// Dim z As New gpr_t
// z = 0.5 * (1 + gpr.erf(x / gpr.sqrt(2)))
// '        Console.WriteLine("x: {0}, z: {1}", x, z)
// Return z
// End Function
// 
// 
// 'Function NdensMpfr(x As gpr_t) As gpr_t
// '    Dim z As New gpr_t
// '    z = gpr.exp(-x * x / 2) / gpr.sqrt(2 * gpr.const_pi())
// '    '        Console.WriteLine("x: {0}, z: {1}", x, z)
// '    Return z
// 'End Function
// 
// 
// Sub mprfF1(xPtr As IntPtr, fxPtr As IntPtr)
// Dim x As New gpr_t(xPtr, True)
// Dim fx As New gpr_t()
// fx = NdisMpfr(x) - gpr.t("0.99")
// Console.WriteLine("In  F1: x: {0}, f(x): {1}", x, fx)
// fx.CopyToPtr(fxPtr)
// End Sub
// 
// 
// 'Sub DemoMpfrSolverBoost()
// '    Dim result As New gpr_t
// '    mp4.setprec(300)
// 
// '    Dim factor, xmin, xmax, guess, bracket_min, bracket_max As New gpr_t
// '    Dim get_digits As Int32 = 49, maxit As UInt32 = 25
// '    Dim is_rising As Boolean = True ' Set to true if f(x) is rising on x and false if f(x) is falling on x. This value is used along with the result of f(guess) to determine if guess is above or below the root.
// '    guess = 3.33
// '    xmin = 0.0
// '    xmax = 4.0
// '    factor = 1.2
// '    get_digits = 150
// 
// 
// '    Console.WriteLine("BracketRoot")
// '    result = mpfrCallback.BracketRoot(AddressOf mprfF1, guess, factor, is_rising, get_digits, maxit)
// '    Console.WriteLine("x: {0}", result)
// 
// 
// 'End Sub
// 
// Function f(x As apr_t) As apr_t
// Dim y = 1 / x
// If apr.is_zero(x.mid) Then y = apr.posinf
// Return apr.exp(-y)
// End Function
// 
// Function s1(x As apr_t) As apr_t
// If apr.is_zero(x.mid) Then
// Return apr.t(0)
// Else
// Return apr.exp(-1 / x) / (x * x)
// End If
// End Function
// 
// Sub DemoArbInt()
// Console.WriteLine("In DemoArbInt")
// For i = 0 To 10
// Dim x = i / 100
// Dim y = s1(x)
// Console.WriteLine("i: {0}, y: {1}, f(x) * y: {2}", i, y, f(x) * y)
// Next
// End Sub
// 
// 
// 
// End Module
// 
// 
