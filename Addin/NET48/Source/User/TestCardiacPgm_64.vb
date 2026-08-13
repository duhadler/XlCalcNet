REM Ref:CardiacList.dll

Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Globalization
Imports System.Threading
Imports System.Diagnostics
Imports Num64
Imports CardiacList


Public Class Program

    Sub TestList(TList As List(Of Patient))
        For Each Pat In TList
            Console.WriteLine("Pat.PatId: {0}", Pat.PatId)
        Next
        Console.WriteLine()
        Dim Query = From Pat In TList
                    Where Pat.Age > 50
                    Select Pat
        For Each Pat In Query
            Console.WriteLine("Pat.PatId: {0}, Pat.Age: {1}", Pat.PatId, Pat.Age)
        Next
        Console.WriteLine("Done!")
    End Sub

    Sub TestList(TList As List(Of Clinical))
        For Each Clin In TList
            Console.WriteLine("Clin.PatId: {0}, Clin.TimeId: {1}, Clin.HR: {2}, Clin.DateAndTime: {3}",
            Clin.PatId, Clin.TimeId, Clin.HR, Clin.DateAndTime)
        Next
        Console.WriteLine()
        Dim Query = From Clin In TList
                    Where Clin.HR > 80
                    Select Clin
        For Each Clin In Query
            Console.WriteLine("Clin.PatId: {0}, Clin.TimeId: {1}, Clin.HR: {2}", Clin.PatId, Clin.TimeId, Clin.HR)
        Next
        Console.WriteLine("Done!")
    End Sub

    Sub TestList(TList As List(Of Laboratory))
        For Each Lab In TList
            Console.WriteLine("Lab.PatId: {0}", Lab.PatId)
        Next
        Console.WriteLine()
        Dim Query = From Lab In TList
                    Where Lab.Aldosteron > 80
                    Select Lab
        For Each Lab In Query
            Console.WriteLine("Lab.PatId: {0}, Lab.Aldosteron: {1}, Lab.Renin: {2}", Lab.PatId, Lab.Aldosteron, Lab.Renin)
        Next
        Console.WriteLine("Done!")
    End Sub

    Sub TestList(TList As List(Of Hemodynamic))
        For Each Hem In TList
            Console.WriteLine("Hem.PatId: {0}", Hem.PatId)
        Next
        Console.WriteLine()
        Dim Query = From Hem In TList
                    Where Hem.PAEDP > 18
                    Select Hem
        For Each Hem In Query
            Console.WriteLine("Hem.PatId: {0}, Hem.PAEDP: {1}", Hem.PatId, Hem.PAEDP)
        Next
        Console.WriteLine("Done!")
    End Sub

    Sub TestJoin(PatList As List(Of Patient), LabList As List(Of Laboratory))
        Dim Results = From Pat As Patient In PatList
                      Join Lab As Laboratory In LabList
        On Pat.PatId Equals Lab.PatId
                      Where Lab.TimeId = 101
                      Select Pat.Age, Lab.TimeId, Lab.Renin
                      Order By Age Descending
        For Each Res In Results
            Console.WriteLine("Res.Age: {0}, Res.TimeId: {1}, Res.Renin: {2}", Res.Age, Res.TimeId, Res.Renin)
        Next
    End Sub

    Sub TestJoinMath53(LabList As List(Of Laboratory))
        Console.WriteLine("Hello TestJoinDouble(LabList As List(Of Laboratory))")
        Dim Results = From Lab1 As Laboratory In LabList
                      Join Lab2 As Laboratory In LabList
        On Lab1.PatId Equals Lab2.PatId
                      Let Renin1 = Math53.T(Lab1.Renin)
                      Let Renin2 = Math53.T(Lab2.Renin)
                      Let ReninDiff = Renin1 - Renin2
                      Where (Lab1.TimeId = 101) And (Lab2.TimeId = 161) And (ReninDiff < 0) And Not Math53.IsNan(ReninDiff)
                      Select PatId = Lab1.PatId, Renin1, Renin2, ReninDiff
                      Order By PatId Ascending
        For Each Res In Results
            Console.WriteLine(" PatId: {0}, Renin1: {1}, Renin2: {2}, ReninDiff: {3}", Res.PatId, Res.Renin1, Res.Renin2, Res.ReninDiff)
        Next
        Dim AverageResult = Aggregate Res In Results
        Into Average(Res.ReninDiff)
        Console.WriteLine("Average: {0}", AverageResult)
    End Sub

    Sub TestJoinGpr(LabList As List(Of Laboratory))
        Console.WriteLine("Hello TestJoinGpr(LabList As List(Of Laboratory))")
        Dim Results = From Lab1 As Laboratory In LabList
                      Join Lab2 As Laboratory In LabList
        On Lab1.PatId Equals Lab2.PatId
                      Let Renin1 = Gpr.T(Lab1.Renin)
                      Let Renin2 = Gpr.T(Lab2.Renin)
                      Let ReninDiff = Renin1 - Renin2
                      Where (Lab1.TimeId = 101) And (Lab2.TimeId = 161) And (ReninDiff < 0) And Not Gpr.IsNan(ReninDiff)
                      Select PatId = Lab1.PatId, Renin1, Renin2, ReninDiff
                      Order By PatId Ascending
        For Each Res In Results
            Console.WriteLine(" PatId: {0}, Renin1: {1}, Renin2: {2}, ReninDiff: {3}", Res.PatId, Res.Renin1, Res.Renin2, Res.ReninDiff)
        Next
    End Sub

    Sub TestJoinDpr(LabList As List(Of Laboratory))
        Console.WriteLine("Hello TestJoinDpr(LabList As List(Of Laboratory))")
        Dim Results = From Lab1 As Laboratory In LabList
                      Join Lab2 As Laboratory In LabList
        On Lab1.PatId Equals Lab2.PatId
                      Let Renin1 = Dpr.T(Lab1.Renin)
                      Let Renin2 = Dpr.T(Lab2.Renin)
                      Let ReninDiff = Renin1 - Renin2
                      Where (Lab1.TimeId = 101) And (Lab2.TimeId = 161) And (ReninDiff < 0) And Not Dpr.IsNan(ReninDiff)
                      Select PatId = Lab1.PatId, Renin1, Renin2, ReninDiff
                      Order By PatId Ascending
        For Each Res In Results
            Console.WriteLine(" PatId: {0}, Renin1: {1}, Renin2: {2}, ReninDiff: {3}", Res.PatId, Res.Renin1, Res.Renin2, Res.ReninDiff)
        Next
    End Sub

    Sub TestJoinApr(LabList As List(Of Laboratory))
        Console.WriteLine("Hello TestJoinApr(LabList As List(Of Laboratory))")
        Dim Results = From Lab1 As Laboratory In LabList
                      Join Lab2 As Laboratory In LabList
        On Lab1.PatId Equals Lab2.PatId
                      Let Renin1 = Apr.T(Lab1.Renin)
                      Let Renin2 = Apr.T(Lab2.Renin)
                      Let ReninDiff = Renin1 - Renin2
                      Where (Lab1.TimeId = 101) And (Lab2.TimeId = 161) And (ReninDiff < 0) And Not Apr.IsNan(ReninDiff)
                      Select PatId = Lab1.PatId, Renin1, Renin2, ReninDiff
                      Order By PatId Ascending
        For Each Res In Results
            Console.WriteLine(" PatId: {0}, Renin1: {1}, Renin2: {2}, ReninDiff: {3}", Res.PatId, Res.Renin1, Res.Renin2, Res.ReninDiff)
        Next
    End Sub

    Sub TestJoinRealType(RealType As Object, LabList As List(Of Laboratory))
        Console.WriteLine("Hello TestJoinRealType(LabList As List(Of Laboratory))")
        Dim Results = From Lab1 As Laboratory In LabList
                      Join Lab2 As Laboratory In LabList
        On Lab1.PatId Equals Lab2.PatId
                      Let Renin1 = RealType.T(Lab1.Renin)
                      Let Renin2 = RealType.T(Lab2.Renin)
                      Let ReninDiff = Renin1 - Renin2
                      Where (Lab1.TimeId = 101) And (Lab2.TimeId = 161) And (ReninDiff < 0) And Not RealType.IsNan(ReninDiff)
                      Select PatId = Lab1.PatId, Renin1, Renin2, ReninDiff
                      Order By PatId Ascending
        For Each Res In Results
            Console.WriteLine(" PatId: {0}, Renin1: {1}, Renin2: {2}, ReninDiff: {3}", Res.PatId, Res.Renin1, Res.Renin2, Res.ReninDiff)
        Next
    End Sub

    Sub TestGroup(PatList As List(Of Patient), ClinList As List(Of Clinical))
        Dim Results = From Pat As Patient In PatList
                      Group By Gender = Pat.Gender, Stratum = Pat.Stratum
        Into GenRes = Group, Count(), AvHeight = Average(Pat.Height)
                      Order By Gender

        For Each Res In Results
            Console.WriteLine("{0}, {1}, {2}, {3}", Res.Gender, Res.Stratum, Res.Count, Res.AvHeight)
        Next
    End Sub

    Sub Main()
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")
        Dim ci As CultureInfo = Thread.CurrentThread.CurrentCulture.Clone()
        ci.NumberFormat.NegativeInfinitySymbol = "-Inf"
        ci.NumberFormat.PositiveInfinitySymbol = "+Inf"
        Thread.CurrentThread.CurrentCulture = ci
        Dim ProjDir = "C:\Users\dietrichhadler\Documents\mpfunlab.office\Projects"
        Try
            Dim FName As String = ProjDir & "\Cardiac"
            FName = FName & "\Cardiac.db"
            '            FName = FName & ".ods"
            '            FName = FName & ".xlsx"
            Dim Wb As New WDbCardiac(FName)

            If Wb.IsValid Then
                Dim PatientList = Wb.PatientList
                Console.WriteLine("Wb.PatientList.Count: {0}", PatientList.Count)
                TestList(PatientList)

                Dim ClinicalList = Wb.ClinicalList
                Console.WriteLine("Wb.ClinicalList.Count: {0}", ClinicalList.Count)
                TestList(ClinicalList)

                Dim LaboratoryList = Wb.LaboratoryList
                Console.WriteLine("Wb.LaboratoryList.Count: {0}", LaboratoryList.Count)
                TestList(LaboratoryList)

                Dim HemodynamicList = Wb.HemodynamicList
                Console.WriteLine("Wb.HemodynamicList.Count: {0}", HemodynamicList.Count)
                TestList(HemodynamicList)

                mp4.setdps(30)
                TestJoinMath53(LaboratoryList)
                TestJoinGpr(LaboratoryList)
                TestJoinDpr(LaboratoryList)
                TestJoinApr(LaboratoryList)

                Console.WriteLine()

                TestJoinRealType(New Math53, LaboratoryList)
                TestJoinRealType(New Gpr, LaboratoryList)
                TestJoinRealType(New Dpr, LaboratoryList)
                TestJoinRealType(New Apr, LaboratoryList)

                Wb.Release
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

End Class
