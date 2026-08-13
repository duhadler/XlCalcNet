using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;

namespace UserTestScript64
{

    static class Program
    {



        public static object RunScriptFromFile(string FName, string Proc)
        {
            string ProviderName;
            string MainClass;
            ProviderName = "CSharp";
            MainClass = "EvaluateCS.Program";
            var provider = CodeDomProvider.CreateProvider(ProviderName);
            var cp = new CompilerParameters();
            try
            {
                cp.ReferencedAssemblies.Add("System.dll");
                cp.ReferencedAssemblies.Add("System.Core.dll");
                cp.ReferencedAssemblies.Add("System.Numerics.dll");
                cp.ReferencedAssemblies.Add("System.Data.dll");
                cp.ReferencedAssemblies.Add("FixedPrecNet.dll");
                cp.CompilerOptions = "/t:library -platform:x64";
                cp.CompilerOptions = cp.CompilerOptions + " -langversion:5 -preferreduilang:en-us";
                cp.GenerateInMemory = true;
                var cr = provider.CompileAssemblyFromFile(cp, FName);
                if (cr.Errors.Count > 0)
                {
                    var sbError = new StringBuilder("");
                    for (int i = 0, loopTo = cr.Errors.Count - 1; i <= loopTo; i++)
                        sbError.Append(Constants.vbCrLf + "Line " + cr.Errors[i].Line.ToString() + ":" + " Error " + cr.Errors[i].ErrorNumber + ": " + cr.Errors[i].ErrorText);
                    return sbError.ToString();
                }
                var LocalAssembly = cr.CompiledAssembly;
                var LocalInstance = LocalAssembly.CreateInstance(MainClass);
                var LocalInstanceType = LocalInstance.GetType();
                var mi = LocalInstanceType.GetMethod(Proc);
                object Result = null;
                for (int i = 1; i <= 1; i++)
                    Result = mi.Invoke(LocalInstance, null);
                return Result;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
                return "Error";
            }
        }


        public static string GetFunctionCode()
        {
            StringBuilder sb = new StringBuilder(10000);
            sb.Append("double c = 1.0;" + Environment.NewLine);
            sb.Append("phi = (double t) => c * Math.Cos(t);" + Environment.NewLine);
            sb.Append("psi = (double t) => c * Math.Sin(t);" + Environment.NewLine);
            string Code = sb.ToString();
            return Code;
        }

        public static string GetFunctionPath()
        {
            StringBuilder sb = new StringBuilder(10000);
            sb.Append("var r = Math.Sqrt(3) / 3;" + Environment.NewLine);
            sb.Append("var x = Math.Cos(t);" + Environment.NewLine);
            sb.Append("var y = Math.Sin(t) + r;" + Environment.NewLine);
            sb.Append("var z = Math.Cos(3 * t) / 3;" + Environment.NewLine);
            string Code = sb.ToString();
            return Code;
        }

        public static string GetFunctionReal()
        {
            StringBuilder sb = new StringBuilder(10000);
            sb.Append("var a = 1.0;" + Environment.NewLine);
            sb.Append("var b = 1.0;" + Environment.NewLine);
            sb.Append("var z = x * x / (b * b) - y * y / (a * a);" + Environment.NewLine);
            string Code = sb.ToString();
            return Code;
        }

        public static string GetFunctionComplex()
        {
            StringBuilder sb = new StringBuilder(10000);
            sb.Append("Complex c1 = new Complex(x, y);" + Environment.NewLine);
            sb.Append("var cplxResult = c1 * c1;" + Environment.NewLine);
            string Code = sb.ToString();
            return Code;
        }

        public static string GetFunctionParams()
        {
            StringBuilder sb = new StringBuilder(10000);
            sb.Append("var x = Math.Cos(u) * Math.Sin(v);" + Environment.NewLine);
            sb.Append("var y = Math.Cos(u) * Math.Cos(v);" + Environment.NewLine);
            sb.Append("var z = u;" + Environment.NewLine);
            string Code = sb.ToString();
            return Code;
        }


        public static string GetCodeTransformation(string FunctionCode, int numPoints, double tmin, double tmax)
        {
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string nstr = numPoints.ToString().Trim();
            string tminstr = tmin.ToString().Trim();
            string tmaxstr = tmax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public delegate double cbFuncDouble(double x);" + Environment.NewLine);
            sb.Append("        cbFuncDouble phi = null;" + Environment.NewLine);
            sb.Append("        cbFuncDouble psi = null;" + Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("        public double[,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append("            // Start function definition" + Environment.NewLine);

            sb.Append(FunctionCode);

            sb.Append("            // End function definition" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int numPoints = " + nstr + ";" + Environment.NewLine);
            sb.Append("            double tmin = " + tminstr + ";" + Environment.NewLine);
            sb.Append("            double tmax = " + tmaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,] twod = new double[2, numPoints+1];" + Environment.NewLine);
            sb.Append("            double tt = tmin;" + Environment.NewLine);
            sb.Append("            double dt = (tmax - tmin) / (numPoints);" + Environment.NewLine);

            sb.Append("            for (int i = 0; i < numPoints - 0; i++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);
            sb.Append("                twod[0, i] = phi(tt);" + Environment.NewLine);
            sb.Append("                twod[1, i] = psi(tt);" + Environment.NewLine);
            sb.Append("                tt += dt;" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            twod[0, numPoints] = phi(tmax);" + Environment.NewLine);
            sb.Append("            twod[1, numPoints] = psi(tmax);" + Environment.NewLine);
            sb.Append("            return twod;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            return sb.ToString();
        }


        public static string GetCodePath(string GetFunctionPath, int numPoints, int ExtraDt, double tmin, double tmax)
        {
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string nstr = numPoints.ToString().Trim();
            string EDstr = ExtraDt.ToString().Trim();
            string tminstr = tmin.ToString().Trim();
            string tmaxstr = tmax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public double[,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int numPoints = " + nstr + ";" + Environment.NewLine);
            sb.Append("            int ExtraDt = " + EDstr + ";" + Environment.NewLine);
            sb.Append("            double tmin = " + tminstr + ";" + Environment.NewLine);
            sb.Append("            double tmax = " + tmaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,] d3 = new double[3, numPoints+ExtraDt+1];" + Environment.NewLine);
            sb.Append("            double t = tmin;" + Environment.NewLine);
            sb.Append("            double dt = (tmax - tmin) / (numPoints);" + Environment.NewLine);

            sb.Append("            for (int i = 0; i < numPoints +ExtraDt; i++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);

            sb.Append("                // Start function definition" + Environment.NewLine);
            sb.Append(GetFunctionPath);
            sb.Append("                // End function definition" + Environment.NewLine);

            sb.Append("                d3[0, i] = x;;" + Environment.NewLine);
            sb.Append("                d3[1, i] = y;" + Environment.NewLine);
            sb.Append("                d3[2, i] = z;" + Environment.NewLine);
            sb.Append("                t += dt;" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            return d3;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            return sb.ToString();
        }



        public static string GetCodeReal(string GetFunctionReal, int xResolution, int yResolution, double xmin, double xmax, double ymin, double ymax)
        {
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string xResstr = xResolution.ToString().Trim();
            string yResstr = yResolution.ToString().Trim();
            string xminstr = xmin.ToString().Trim();
            string xmaxstr = xmax.ToString().Trim();
            string yminstr = ymin.ToString().Trim();
            string ymaxstr = ymax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public double[,,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int xResolution = " + xResstr + ";" + Environment.NewLine);
            sb.Append("            int yResolution = " + yResstr + ";" + Environment.NewLine);
            sb.Append("            double xmin = " + xminstr + ";" + Environment.NewLine);
            sb.Append("            double xmax = " + xmaxstr + ";" + Environment.NewLine);
            sb.Append("            double ymin = " + yminstr + ";" + Environment.NewLine);
            sb.Append("            double ymax = " + ymaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,,] d3 = new double[3, xResolution+2, yResolution+2];" + Environment.NewLine);
            sb.Append("            double dx = (xmax - xmin) / xResolution;" + Environment.NewLine);
            sb.Append("            double dy = (ymax - ymin) / yResolution;" + Environment.NewLine);

            sb.Append("            double x = 0.0;" + Environment.NewLine);
            sb.Append("            double y = 0.0;" + Environment.NewLine);

            sb.Append("            for (int ix = 0; ix <= xResolution + 1; ix++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);
            sb.Append("                for (int iy = 0; iy <= yResolution + 1; iy++)" + Environment.NewLine);
            sb.Append("                {" + Environment.NewLine);
            sb.Append("                    x = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    y = ymin + iy * dy;" + Environment.NewLine);

            sb.Append("                    // Start function definition" + Environment.NewLine);
            sb.Append(GetFunctionReal);
            sb.Append("                    // End function definition" + Environment.NewLine);

            sb.Append("                    d3[0, ix, iy] = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    d3[1, ix, iy] = ymin + iy * dy;" + Environment.NewLine);
            sb.Append("                    d3[2, ix, iy] = z;" + Environment.NewLine);
            sb.Append("                }" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            return d3;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            return sb.ToString();
        }


        public static string GetCodeComplex(string GetFunctionComplex, int xResolution, int yResolution, double xmin, double xmax, double ymin, double ymax)
        {
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string xResstr = xResolution.ToString().Trim();
            string yResstr = yResolution.ToString().Trim();
            string xminstr = xmin.ToString().Trim();
            string xmaxstr = xmax.ToString().Trim();
            string yminstr = ymin.ToString().Trim();
            string ymaxstr = ymax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public double[,,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int xResolution = " + xResstr + ";" + Environment.NewLine);
            sb.Append("            int yResolution = " + yResstr + ";" + Environment.NewLine);
            sb.Append("            double xmin = " + xminstr + ";" + Environment.NewLine);
            sb.Append("            double xmax = " + xmaxstr + ";" + Environment.NewLine);
            sb.Append("            double ymin = " + yminstr + ";" + Environment.NewLine);
            sb.Append("            double ymax = " + ymaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,,] d3 = new double[4, xResolution+2, yResolution+2];" + Environment.NewLine);
            sb.Append("            double dx = (xmax - xmin) / xResolution;" + Environment.NewLine);
            sb.Append("            double dy = (ymax - ymin) / yResolution;" + Environment.NewLine);

            sb.Append("            double x = 0.0;" + Environment.NewLine);
            sb.Append("            double y = 0.0;" + Environment.NewLine);

            sb.Append("            for (int ix = 0; ix <= xResolution + 1; ix++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);
            sb.Append("                for (int iy = 0; iy <= yResolution + 1; iy++)" + Environment.NewLine);
            sb.Append("                {" + Environment.NewLine);
            sb.Append("                    x = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    y = ymin + iy * dy;" + Environment.NewLine);

            sb.Append("                    // Start function definition" + Environment.NewLine);
            sb.Append(GetFunctionComplex);
            sb.Append("                    // End function definition" + Environment.NewLine);

            sb.Append("                    d3[0, ix, iy] = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    d3[1, ix, iy] = ymin + iy * dy;" + Environment.NewLine);
            sb.Append("                    d3[2, ix, iy] = cplxResult.Real;" + Environment.NewLine);
            sb.Append("                    d3[3, ix, iy] = cplxResult.Imaginary;" + Environment.NewLine);
            sb.Append("                }" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            return d3;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            return sb.ToString();
        }


        public static string GetCodeParams(string GetFunctionParams, int xResolution, int yResolution, double xmin, double xmax, double ymin, double ymax)
        {
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string xResstr = xResolution.ToString().Trim();
            string yResstr = yResolution.ToString().Trim();
            string xminstr = xmin.ToString().Trim();
            string xmaxstr = xmax.ToString().Trim();
            string yminstr = ymin.ToString().Trim();
            string ymaxstr = ymax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public double[,,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int xResolution = " + xResstr + ";" + Environment.NewLine);
            sb.Append("            int yResolution = " + yResstr + ";" + Environment.NewLine);
            sb.Append("            double xmin = " + xminstr + ";" + Environment.NewLine);
            sb.Append("            double xmax = " + xmaxstr + ";" + Environment.NewLine);
            sb.Append("            double ymin = " + yminstr + ";" + Environment.NewLine);
            sb.Append("            double ymax = " + ymaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,,] d3 = new double[3, xResolution+2, yResolution+2];" + Environment.NewLine);
            sb.Append("            double dx = (xmax - xmin) / xResolution;" + Environment.NewLine);
            sb.Append("            double dy = (ymax - ymin) / yResolution;" + Environment.NewLine);

            sb.Append("            double u = 0.0;" + Environment.NewLine);
            sb.Append("            double v = 0.0;" + Environment.NewLine);

            sb.Append("            for (int ix = 0; ix <= xResolution + 1; ix++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);
            sb.Append("                for (int iy = 0; iy <= yResolution + 1; iy++)" + Environment.NewLine);
            sb.Append("                {" + Environment.NewLine);
            sb.Append("                    u = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    v = ymin + iy * dy;" + Environment.NewLine);

            sb.Append("                    // Start function definition" + Environment.NewLine);
            sb.Append(GetFunctionParams);
            sb.Append("                    // End function definition" + Environment.NewLine);

            sb.Append("                    d3[0, ix, iy] = x;" + Environment.NewLine);
            sb.Append("                    d3[1, ix, iy] = y;" + Environment.NewLine);
            sb.Append("                    d3[2, ix, iy] = z;" + Environment.NewLine);
            sb.Append("                }" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            return d3;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            return sb.ToString();
        }




        public static void Main()
        {
            int xResolution = 4;
            int yResolution = 4;
            double xmin = -1.0;
            double xmax = 1.0;
            double ymin = -1.0;
            double ymax = 1.0;

            string FName = @"C:\Users\dietrichhadler\Documents\CodeTest.txt";
            string s1 = GetFunctionParams();
            string Code = GetCodeParams(s1, xResolution, yResolution, xmin, xmax, ymin, ymax);
            File.WriteAllText(FName, Code);
            Console.WriteLine("Hello Compiler 6448!");

            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            string Proc;
            dynamic Result;
            try
            {
                Console.WriteLine(FName);
                Proc = "test4";
                Result = RunScriptFromFile(FName, Proc);
                string RS = Result.ToString();
                Console.WriteLine(RS);
                if (RS.StartsWith("System.Double"))
                    for (int i = 0; i <= xResolution; i++)
                    {
                        for (int j = 0; j <= yResolution; j++)
                        {
                            Console.WriteLine("x: {0}, y: {1}, z: {2}", Result[0, i, j], Result[1, i, j], Result[2, i, j]);
                        }
                    }
            }
            finally
            {
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }



        //public static void Main()
        //{
        //    int xResolution = 4;
        //    int yResolution = 4;
        //    double xmin = -1.0;
        //    double xmax = 1.0;
        //    double ymin = -1.0;
        //    double ymax = 1.0;

        //    string FName = @"C:\Users\dietrichhadler\Documents\CodeTest.txt";
        //    string s1 = GetFunctionComplex();
        //    string Code = GetCodeComplex(s1, xResolution, yResolution, xmin, xmax, ymin, ymax);
        //    File.WriteAllText(FName, Code);
        //    Console.WriteLine("Hello Compiler 6448!");

        //    var ci = new CultureInfo("en-US", false);
        //    ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
        //    ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
        //    Thread.CurrentThread.CurrentCulture = ci;
        //    Thread.CurrentThread.CurrentUICulture = ci;
        //    string Proc;
        //    dynamic Result;
        //    try
        //    {
        //        Console.WriteLine(FName);
        //        Proc = "test4";
        //        Result = RunScriptFromFile(FName, Proc);
        //        string RS = Result.ToString();
        //        Console.WriteLine(RS);
        //        if (RS.StartsWith("System.Double"))
        //            for (int i = 0; i <= xResolution; i++)
        //            {
        //                for (int j = 0; j <= yResolution; j++)
        //                {
        //                    Console.WriteLine("x: {0}, y: {1}, re: {2}, im: {3}", Result[0, i, j], Result[1, i, j], Result[2, i, j], Result[3, i, j]);
        //                }
        //            }
        //    }
        //    finally
        //    {
        //    }
        //    Console.Write("Press any key to continue . . . ");
        //    Console.ReadKey(true);
        //}




        //public static void Main()
        //{
        //    int xResolution = 4;
        //    int yResolution = 4;
        //    double xmin = -1.0;
        //    double xmax = 1.0;
        //    double ymin = -1.0;
        //    double ymax = 1.0;

        //    string FName = @"C:\Users\dietrichhadler\Documents\CodeTest.txt";
        //    string s1 = GetFunctionReal();
        //    string Code = GetCodeReal(s1, xResolution, yResolution, xmin, xmax, ymin, ymax);
        //    File.WriteAllText(FName, Code);
        //    Console.WriteLine("Hello Compiler 6448!");

        //    var ci = new CultureInfo("en-US", false);
        //    ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
        //    ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
        //    Thread.CurrentThread.CurrentCulture = ci;
        //    Thread.CurrentThread.CurrentUICulture = ci;
        //    string Proc;
        //    dynamic Result;
        //    try
        //    {
        //        Console.WriteLine(FName);
        //        Proc = "test4";
        //        Result = RunScriptFromFile(FName, Proc);
        //        string RS = Result.ToString();
        //        Console.WriteLine(RS);
        //        if (RS.StartsWith("System.Double"))
        //            for (int i = 0; i <= xResolution; i++)
        //            {
        //                for (int j = 0; j <= yResolution; j++)
        //                {
        //                    Console.WriteLine("x: {0}, y: {1}, z: {2}", Result[0, i, j], Result[1, i, j], Result[2, i, j]);
        //                }
        //            }
        //    }
        //    finally
        //    {
        //    }
        //    Console.Write("Press any key to continue . . . ");
        //    Console.ReadKey(true);

        //}



        //public static void Main()
        //{
        //    int numPoints = 32;
        //    int ExtraDt = 3;
        //    double tmin = 0.0;
        //    double tmax = Math.PI;

        //    bool useold = false;
        //    string FName = "";
        //    if (useold)
        //    {
        //        FName = @"C:\Users\dietrichhadler\Documents\Python310\Lib\site-packages\mpfebnet\Source\User\UserEvaluateCSMain.cs";
        //    }
        //    else
        //    {
        //        FName = @"C:\Users\dietrichhadler\Documents\CodeTest.txt";
        //        string s1 = GetFunctionPath();
        //        string Code = GetCodePath(s1, numPoints, ExtraDt, tmin, tmax);
        //        File.WriteAllText(FName, Code);
        //    }
        //    Console.WriteLine("Hello Compiler 6448!");
        //    var ci = new CultureInfo("en-US", false);
        //    ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
        //    ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
        //    Thread.CurrentThread.CurrentCulture = ci;
        //    Thread.CurrentThread.CurrentUICulture = ci;
        //    string Proc;
        //    dynamic Result;
        //    try
        //    {
        //        Console.WriteLine(FName);
        //        Proc = "test4";
        //        Result = RunScriptFromFile(FName, Proc);
        //        string RS = Result.ToString();
        //        Console.WriteLine(RS);
        //        if (RS.StartsWith("System.Double"))
        //            for (int i = 0; i <= numPoints + ExtraDt; i++)
        //            {
        //                Console.WriteLine("x: {0}, y: {1}, z: {2}", Result[0, i], Result[1, i], Result[2, i]);
        //            }
        //    }
        //    finally
        //    {
        //    }
        //    Console.Write("Press any key to continue . . . ");
        //    Console.ReadKey(true);
        //}






        //public static void Main()
        //{
        //    int numPoints = 32;
        //    double tmin = 0.0;
        //    double tmax = Math.PI;

        //    bool useold = true;
        //    string FName = "";
        //    if (useold)
        //    {
        //        FName = @"C:\Users\dietrichhadler\Documents\Python310\Lib\site-packages\mpfebnet\Source\User\UserEvaluateCSMain.cs";
        //    }
        //    else
        //    {
        //        FName = @"C:\Users\dietrichhadler\Documents\CodeTest.txt";
        //        string s1 = GetFunctionCode();
        //        string Code = GetCodeTransformation(s1, numPoints, tmin, tmax);
        //        File.WriteAllText(FName, Code);
        //    }
        //    Console.WriteLine("Hello Compiler 6448!");
        //    var ci = new CultureInfo("en-US", false);
        //    ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
        //    ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
        //    Thread.CurrentThread.CurrentCulture = ci;
        //    Thread.CurrentThread.CurrentUICulture = ci;
        //    string Proc;
        //    dynamic Result;
        //    try
        //    {
        //        Console.WriteLine(FName);
        //        Proc = "test4";
        //        Result = RunScriptFromFile(FName, Proc);
        //        string RS = Result.ToString();
        //        Console.WriteLine(RS);
        //        if (RS.StartsWith("System.Double"))
        //            for (int i = 0; i <= numPoints; i++)
        //            {
        //                Console.WriteLine("x: {0}, y: {1}", Result[0, i], Result[1, i]);
        //            }
        //    }
        //    finally
        //    {
        //    }
        //    Console.Write("Press any key to continue . . . ");
        //    Console.ReadKey(true);
        //}












    }
}