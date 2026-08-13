
/* If defined includes code requiring UserFixedPrecNet. Is set automatically */
#define HasUserFixedPrecNet

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#if HasUserFixedPrecNet
/* No syntax highlighting if HasUserFixedPrecNet is undefined */
using UserFixedPrecNet;
#endif
#endregion


static class Program
{


public static void MainTests()
{
            KendallPmfVectorDemo();
            //MannWhitneyPmfVectorDemo();
            //TerpstaPmfVectorDemo();

            //SpearmanPmfVectorDemo();
            //SignTestPmfVectorDemo();
            //WilcoxonPmfVectorDemo();
            //PagePmfVectorDemo();
            //PageQuadePmfVectorDemo();

            //DemoFriedman();
}


#region RankTestsPmf



        public static void KendallPmfVectorDemo()
        {
            int n = 18;
            Console.WriteLine("Distribution of Kendall's tau, pmf vector, n = {0}", n);
            double[] X = m53lib.KendallPmfVector(n);
            for (int i = 0; i < X.Length; i++)
                Console.WriteLine("i: {0}, X[i]: {1}", i, X[i]);
        }


        public static void MannWhitneyPmfVectorDemo()
        {
            int m = 10;
            int n = 10;
            double[] X = m53lib.MannWhitneyPmfVector(m, n);
            Console.WriteLine("Distribution of Mann-Whitney's U, pmf vector, m = {0}, n = {1}", m, n);
            for (int i = 0; i < X.Length; i++)
                Console.WriteLine("i: {0}, X[i]: {1}", i, X[i]);
        }


        public static void TerpstaPmfVectorDemo()
        {
            int k = 4;
            var n = new int[k + 1];
            //string nstr = "(";
            for (int j = 1; j <= k; j++)
                n[j] = 3;

            //int[] N = {5,5,5};

            Console.WriteLine("Distribution of Jomckheere-Terpsta's S, pmf vector, k = {0}, nj = {1}", k - 1, n[1]);
            double[] X = m53lib.TerpstaPmfVector(k, n);
            for (int i = 0; i < X.Length; i++)
                Console.WriteLine("i: {0}, X[i]: {1}", i, X[i]);

        }


        public static void SpearmanPmfVectorDemo()
        {
            int n = 8;
            Console.WriteLine("Distribution of Spearman's rho, pmf vector, n = {0}", n);
            double[] pmfvec = m53lib.SpearmanPmfVector(n);
            for (int i = 0; i < pmfvec.Length; i++)
            {
                Console.WriteLine("i: {0}, pmf[i]:{1}", i, pmfvec[i]);
            }
        }


        public static void SignTestPmfVectorDemo()
        {
            int N = 18;
            Console.WriteLine("Distribution of the Sign Test, pmf vector, N = {0}", N);
            double[] pmfvec = m53lib.SignTestPmfVector(N);
            for (int i = 0; i < pmfvec.Length; i++)
            {
                Console.WriteLine("i: {0}, pmf[i]:{1}", i, pmfvec[i]);
            }
        }


        public static void WilcoxonPmfVectorDemo()
        {
            int N = 18;
            Console.WriteLine("Distribution of the Wilcoxon Signed Rank Test, pmf vector,  N = {0}", N);
            double[] pmfvec = m53lib.WilcoxonPmfVector(N);
            for (int i = 0; i < pmfvec.Length; i++)
            {
                Console.WriteLine("i: {0}, pmf[i]:{1}", i, pmfvec[i]);
            }
        }


        public static void PagePmfVectorDemo()
        {
            int k = 3;
            int N = 8;
            Console.WriteLine("Distribution of Page's L, pmf vector, k = {0}, N = {1} ", k, N);
            double[] pmfvec = m53lib.PagePmfVector(k, N);
            for (int i = 0; i < pmfvec.Length; i++)
            {
                Console.WriteLine("i: {0}, pmf[i]:{1}", i, pmfvec[i]);
            }
        }


        public static void PageQuadePmfVectorDemo()
        {
            int k = 3;
            int N = 8;
            Console.WriteLine("Distribution of Page/Quade's L, pmf vector, k = {0}, N = {1} ", k, N);
            double[] pmfvec = m53lib.PageQuadePmfVector(k, N);
            for (int i = 0; i < pmfvec.Length; i++)
            {
                Console.WriteLine("i: {0}, pmf[i]:{1}", i, pmfvec[i]);
            }
        }


        public static void DemoFriedman()
        {
            int k = 3;  // number of groups
            int n = 10; // number of blocks
            int Quade = 1;  // 1=friedman 2=quade
            int Mode = 1;  // 1=anova 2=page
            int Mode2 = 1; // 1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit
            Console.WriteLine("Distribution of Friedman's S, pmf and sf vector, k = {0}, n = {1} ", k, n);

            double[,] Output = m53lib.Friedman(k, n, Quade, Mode, Mode2);

            Console.WriteLine("W,            pmf,               CDF,             Approx to CDF");
            for (int i = 0; i < Output.GetLength(0); i++)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", Output[i, 0], Output[i, 1], Output[i, 2], Output[i, 3]);
            }
        }





#endregion



/* This region contains the program entry point. Do not change. */
#region Main

public static void Main(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine(
            "This application needs to be started with 2 arguments;");
        Console.WriteLine("See the manual of xlcalcnet for details.");
    }
    else
    {
        _PythonRootDir = args[0];
        _PythonNetPyDll = args[1];
        _LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder
            .LocalApplicationData);
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.AssemblyResolve += 
            new ResolveEventHandler(LoadFromXlCalcNet);
        currentDomain.AssemblyResolve += 
            new ResolveEventHandler(LoadFromXlCalcNet2);
        currentDomain.AssemblyResolve += 
            new ResolveEventHandler(LoadFromPythonNet);
        currentDomain.AssemblyResolve += 
            new ResolveEventHandler(LoadFromAppLocal);
        System.Threading.Thread.CurrentThread.CurrentCulture = 
            new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentUICulture = 
            new System.Globalization.CultureInfo("en-US");
        var ci = (System.Globalization.CultureInfo)System.Threading.Thread
            .CurrentThread.CurrentCulture.Clone();
        ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
        ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        var stopWatch = new System.Diagnostics.Stopwatch();
        stopWatch.Start();
        try
        {
            Environment.SetEnvironmentVariable("PYTHONHOME", _PythonRootDir);
            Environment.SetEnvironmentVariable("PYTHONPATH", _PythonRootDir);
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", 
                _PythonNetPyDll);
            MainTests();
        }
        catch (Exception Ex)
        {
            Console.Error.WriteLine(Ex.Message);
            Console.Error.WriteLine("$+$");
            Console.Error.WriteLine(Ex.StackTrace);
            Console.Error.WriteLine("$+$");
        }
        stopWatch.Stop();
        var ts = stopWatch.Elapsed;
        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", 
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        Console.WriteLine("<H1 Title=" + "\"" + "General Info" + "\"" + ">");
        Console.WriteLine("Elapsed Time " + elapsedTime);
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Memory used before collection:       {0:N0}", 
            GC.GetTotalMemory(false));
        GC.Collect();
        Console.WriteLine("Memory used after full collection:   {0:N0}", 
            GC.GetTotalMemory(true));
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("</H1>");
    }

}

private static string _PythonRootDir;
private static string _PythonNetPyDll;
private static string _LocalAppDataDir;

static System.Reflection.Assembly LoadFromXlCalcNet(object sender, 
    ResolveEventArgs args)
{
    string folderPath2 = _PythonRootDir + 
        @"\Lib\site-packages\xlcalcnet\Addin\NET48\Bin";
    string assemblyPath = System.IO.Path.Combine(folderPath2, new System
        .Reflection.AssemblyName(args.Name).Name + ".dll");
    if (!System.IO.File.Exists(assemblyPath)) return null; 
    else return System.Reflection.Assembly.LoadFrom(assemblyPath);
}


static System.Reflection.Assembly LoadFromXlCalcNet2(object sender, 
    ResolveEventArgs args)
{
    string folderPath2 = _PythonRootDir + 
        @"\Lib\site-packages\xlcalcnet2\Addin\NET48\Bin";
    string assemblyPath = System.IO.Path.Combine(folderPath2, new System
        .Reflection.AssemblyName(args.Name).Name + ".dll");
    if (!System.IO.File.Exists(assemblyPath)) return null; 
    else return System.Reflection.Assembly.LoadFrom(assemblyPath);
}


static System.Reflection.Assembly LoadFromPythonNet(object sender, 
    ResolveEventArgs args)
{
    string folderPath2 = _PythonRootDir + 
        @"\Lib\site-packages\pythonnet\runtime";
    string assemblyPath = System.IO.Path.Combine(folderPath2, new System
        .Reflection.AssemblyName(args.Name).Name + ".dll");
    if (!System.IO.File.Exists(assemblyPath)) return null; 
    else return System.Reflection.Assembly.LoadFrom(assemblyPath);
}


static System.Reflection.Assembly LoadFromAppLocal(object sender, 
    ResolveEventArgs args)
{
    string folderPath2 = _LocalAppDataDir + @"\Local\XlCalcNetIDE\Bin";
    string assemblyPath = System.IO.Path.Combine(folderPath2, new System
        .Reflection.AssemblyName(args.Name).Name + ".dll");
    if (!System.IO.File.Exists(assemblyPath)) return null; 
    else return System.Reflection.Assembly.LoadFrom(assemblyPath);
}


#endregion


}

/* Do not remove. Do not add anything after this. */
#region EOF
// Reserved
#endregion


