using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace FixedPrecNet
{



    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void cbProc2Ptr(IntPtr x, IntPtr result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void cbProc3Ptr(IntPtr x, IntPtr result, IntPtr t);






    public static class xcn
    {



        #region Precision mode

        public static void SetPrecisionModeExtended()
        {
            damath_setpmExtended();
        }
        [DllImport(libwe64d, EntryPoint = "damath_setpmExtended", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_setpmExtended();


        public static void SetPrecisionModeDouble()
        {
            damath_setpmDouble();
        }
        [DllImport(libwe64d, EntryPoint = "damath_setpmDouble", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_setpmDouble();



        public static int GetPrecisionMode()
        {
            return damath_GetPrecisionMode();
        }
        [DllImport(libwe64d, EntryPoint = "damath_GetPrecisionMode", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int damath_GetPrecisionMode();


        #endregion




        public static Boolean UseRawDouble = false;


        public static bool IsExactDouble(Double z)
        {
            Double x = Math.Abs(z);
            if (x >= 1.0)
            {
                if (Math.Ceiling(x) == Math.Floor(x))
                {
                    return true;
                }
                else
                {
                    Double temp = 1048576;  // = 2^20
                    temp *= x;
                    if (Math.Ceiling(temp) == Math.Floor(temp))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                Double temp = 1125899906842624;  // = 2^50
                temp *= x;
                if (Math.Ceiling(temp) == Math.Floor(temp))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




        [DllImport("KERNEL32.dll", EntryPoint = "LoadLibraryA")]
        private static extern IntPtr LoadLibrary(string lpFile);
        public const string libwe64d = "libwe64d.dll";
        //internal const string mpNum = "BoostGCC64K8.dll";
        public const string mpNum = "FixedPrecGCC64K8.dll";



        internal static Double HasLibraryNumC()
        {
            string Curdir = Directory.GetCurrentDirectory();
            Double Result = 0d;

            string FullDLLPath = Assembly.GetExecutingAssembly().Location;
            string DLLPath = Path.GetDirectoryName(FullDLLPath) + @"\";
            //Console.WriteLine("DLLPath: {0}", DLLPath);

            Directory.SetCurrentDirectory(DLLPath);

            string FName = DLLPath + mpNum;
            Result = (Double)LoadLibrary(FName);
            if (Result == 0d)
            {
                Console.WriteLine("Could not load supporting library BoostGCC64K8.dll!");
                return 0d;
            }


            //string DLLPath2 = DLLPath.Replace("mpfunlabwin", "mpfunlab");
            //Console.WriteLine("DLLPath2: {0}", DLLPath2);
            //Directory.SetCurrentDirectory(DLLPath2);

            string FNameWe64d = DLLPath + libwe64d;
            Result = (Double)LoadLibrary(FNameWe64d);
            if (Result == 0d)
            {
                Console.WriteLine("Could not load supporting library libwe64d.dll!");
                return 0d;
            }

            Directory.SetCurrentDirectory(Curdir);

            return Result;
        }
        private static bool _Init_IsInitialized = false;



        public static void Init()
        {
            if (!_Init_IsInitialized)
            {
                _Init_IsInitialized = true;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                CultureInfo ci = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
                ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
                ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
                Thread.CurrentThread.CurrentCulture = ci;
                Double Result = HasLibraryNumC();
                SetPrecisionModeExtended();
            }
        }





    }
}