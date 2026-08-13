
Imports System
Imports Num64

Public Class Program

    Public Sub test1()
        Dim x As Double
        x = 2.3
        Console.WriteLine("From userlocalvb.test1()")
        Console.WriteLine("x: {0}", x)
    End Sub


    Public Sub test2()
        Dim x As Double
        x = 5.5
        Console.WriteLine("From userlocalvb.test2()")
        Console.WriteLine("x: {0}", x)
    End Sub


    Public Function test3() As Object
        mp4.setdps(50)
        Dim res = Gpr.Exp(5)
        Console.WriteLine("From userlocalvb.test3()")
        Console.WriteLine("res: {0}", res)
        Return res.ToString()
    End Function


    Public Function Main() As Object
        test1()
        test2()
        test3()

        Return "Main Done"
    End Function


End Class

