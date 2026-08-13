using System;
using System.Diagnostics;
using System.Numerics;
using FixedPrecNet;

namespace TestXlCalcNetPrecCS
{



    // Size of FPC boolean: 1 byte, C# type: Byte
    // Size of FPC word: Uint16
    // Size of FPC integer: Int16
    // Size of FPC longint: Int32
    // Size of FPC mp_digit = cardinal: Uint32
    // Size of FPC cardinal: Uint32
    // Size of FPC mp-word: Int64

    // MAXDigits = $1000000




    internal static class TestMath53
    {


        public static void DemoDoubleTestFinite()
        {
            Console.WriteLine();
            Console.WriteLine("Hello DemoDoubleTestFinite!");

            double z1;
            // Dim d1 As Double = 0.75
            double d1 = 1.0d;


            for (int i = 1; i <= 2; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            d1 = 0.75d;
                            break;
                        }
                    case 2:
                        {
                            d1 = 1.0d;
                            break;
                        }
                        // Case 3 : d1 = math53.posinf()
                        // Case 4 : d1 = math53.nan()
                }
                z1 = d1;
                Console.WriteLine(" :: ");
                Console.WriteLine("z1: {0}", z1);

                // Console.WriteLine("is_zero: {0}", math53.is_zero(z1))
                // Console.WriteLine("is_one: {0}", math53.is_one(z1))
                Console.WriteLine("is_finite: {0}", math53.isfinite(z1));
                // 
                Console.WriteLine("is_nan: {0}", math53.isnan(z1));
                Console.WriteLine("is_inf: {0}", math53.isinf(z1));
                // 
                // Console.WriteLine("is_number: {0}", math53.is_number(z1))
                // Console.WriteLine("is_integer: {0}", math53.is_integer(z1))
                // Console.WriteLine("is_regular: {0}", math53.is_regular(z1))
            }

        }


        public static void DemoDoubleTestLE()
        {
            Console.WriteLine();
            Console.WriteLine("Hello DemoDoubleTestLE!");

            double z1, z2;
            double d1, d2;


            d1 = 0.75d;
            d2 = 0.25d;
            z1 = d1;
            z2 = d2;

            // Console.WriteLine("cmp: {0}", math53.cmp(z1, 2))

            Console.WriteLine("z1 <> z2: {0}", z1 != z2);
            Console.WriteLine("z1 = z2: {0}", z1 == z2);
            Console.WriteLine("z1 <= z2: {0}", z1 <= z2);
            Console.WriteLine("z1 < z2: {0}", z1 < z2);
            Console.WriteLine("z1 >= z2: {0}", z1 >= z2);
            Console.WriteLine("z1 > z2: {0}", z1 > z2);
        }


        // Public Sub DemoDoubleConstant()
        // Console.WriteLine()
        // Console.WriteLine("Hello DemoFprReal0!")

        // Console.WriteLine("pi: {0}", math53.pi())
        // Console.WriteLine("log2: {0}", math53.ln2())
        // Console.WriteLine("log10: {0}", math53.ln10())
        // Console.WriteLine("euler_gamma: {0}", math53.egamma())
        // Console.WriteLine("catalan: {0}", math53.catalan())
        // Console.WriteLine("e: {0}", math53.e())
        // Console.WriteLine("khinchin: {0}", math53.khinchin())
        // Console.WriteLine("glaisher: {0}", math53.glaisher())
        // Console.WriteLine("apery: {0}", math53.apery())
        // ' 
        // Console.WriteLine("nan: {0}", math53.nan())
        // Console.WriteLine("posinf: {0}", math53.posinf())
        // Console.WriteLine("neginf: {0}", math53.neginf())
        // Console.WriteLine("one: {0}", math53.one())

        // Console.WriteLine("machine_epsilon: {0}", math53.epsilon())
        // Console.WriteLine("maxval: {0}", math53.maxvalue())
        // Console.WriteLine("minval: {0}", math53.minvalue())


        // End Sub


        public static void TestRawOperations()
        {
            double f1 = math53.cbrt(2.0d);
            double f2 = 0.999999999999999d;
            int myiter = 100000000;
            int i = 0;
            int loopTo = myiter;

            while (i <= loopTo)
            {
                f1 = f1 / f2;
                i += 1;
            }
            Console.WriteLine("f1: {0}", f1);
        }



        public static void TestFRealRawOperations2()
        {
            double f0, res;
            double sum = 0;
            f0 = 2.0d;
            double f1 = math53.cbrt(f0);
            double f2 = 0.999999999999999d;
            int myiter = 1000000;
            int i = 0;
            int loopTo = myiter;

            while (i <= loopTo)
            {
                f1 = f1 + f2;
                res = math53.sin(f1);
                sum = sum + res;
                i += 1;
            }
            Console.WriteLine("sum: {0}", sum);
        }



        public static void DemoDoubleElementary1()
        {
            Console.WriteLine("Hello DemoDoubleElementary1!");
            // Dim n As Int32
            double x, y, res;

            // res = math53.posinf()
            // Console.WriteLine("res = math53.PositiveInfinity(): {0}", res)

            res = math53.neginf();
            Console.WriteLine("res = math53.NegativeInfinity(): {0}", res);

            res = math53.nan();
            Console.WriteLine("res = math53.Nan(): {0}", res);

            res = math53.pi();
            Console.WriteLine("res = math53.PI(): {0}", res);

            res = math53.e();
            Console.WriteLine("res = math53.E(): {0}", res);

            res = math53.epsilon();
            Console.WriteLine("res = math53.Epsilon(): {0}", res);

            // res = math53.maxvalue()
            // Console.WriteLine("res = math53.MaxValue(): {0}", res)

            // res = math53.minvalue()
            // Console.WriteLine("res = math53.MinValue(): {0}", res)


            res = math53.ln2();
            Console.WriteLine("res = math53.ConstLog2(): {0}", res);

            res = math53.ln10();
            Console.WriteLine("res = math53.ConstLog10(): {0}", res);

            res = math53.pi();
            Console.WriteLine("res = math53.ConstPi(): {0}", res);

            res = math53.e();
            Console.WriteLine("res = math53.ConstE(): {0}", res);

            res = math53.egamma();
            Console.WriteLine("res = math53.ConstEulerGamma(): {0}", res);

            res = math53.phi();
            Console.WriteLine("res = math53.ConstPhi(): {0}", res);

            res = math53.catalan();
            Console.WriteLine("res = math53.ConstCatalan(): {0}", res);

            res = math53.khinchin();
            Console.WriteLine("res = math53.ConstKhinchin(): {0}", res);

            res = math53.glaisher();
            Console.WriteLine("res = math53.ConstGlaisher(): {0}", res);

            res = math53.apery();
            Console.WriteLine("res = math53.ConstApery(): {0}", res);

            res = math53.degree();
            Console.WriteLine("res = math53.ConstDegree(): {0}", res);




            x = 4.5d;
            res = math53.ceil(x);
            Console.WriteLine("x: {0}, math53.Ceil(x): {1}", x, res);

            x = 4.5d;
            res = math53.floor(x);
            Console.WriteLine("x: {0}, math53.Floor(x): {1}", x, res);

            x = 4.5d;
            y = 7.3d;
            res = math53.fmod(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Fmod(x, y): {2}", x, y, res);

            x = 4.531d;
            var res_modf = math53.modf(x);
            Console.WriteLine("x: {0}, math53.Modf(x): {1}", x, res_modf);

            x = 4.5d;
            y = 7.3d;
            res = math53.remainder(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Remainder(x, y): {2}", x, y, res);

        }


        public static void DemoDoubleElementary2()
        {

            Console.WriteLine("Hello DemoDoubleElementary2!");
            int n;
            double x, y, res;

            x = 4.5d;
            y = -7.32d;
            res = math53.copysign(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Copysign(x, y): {2}", x, y, res);


            x = 4.531d;
            var res_frexp = math53.frexp(x);
            Console.WriteLine("x: {0}, math53.Frexp(x): {1}", x, res_frexp);


            x = 0.566375d;
            n = 3;
            res = math53.ldexp(x, n);
            Console.WriteLine("x: {0}, n: {1}, math53.Ldexp(x, n): {2}", x, n, res);


            // x = 4.5R
            // res = math53.pred(x)
            // Console.WriteLine("x: {0}, math53.Pred(x): {1}", x, res)

            // x = 4.5R
            // res = math53.succ(x)
            // Console.WriteLine("x: {0}, math53.Succ(x): {1}", x, res)

            x = 4.5d;
            res = math53.ulp(x);
            Console.WriteLine("x: {0}, math53.Ulp(x): {1}", x, res);

            x = 4.5d;
            res = math53.ilogb(x);
            Console.WriteLine("x: {0}, math53.Ilogb(x): {1}", x, res);

            x = 4.5d;
            res = math53.rint(x);
            Console.WriteLine("x: {0}, math53.Rint(x): {1}", x, res);


            x = 4.5d;
            n = 3;
            res = math53.scalbn(x, n);
            Console.WriteLine("x: {0}, n: {1}, math53.Scalbn(x, n): {2}", x, n, res);


            // x = 4.5R
            // y = 7.3R
            // res = math53.fmax(x, y)
            // Console.WriteLine("x: {0}, y: {1}, math53.Max(x, y): {2}", x, y, res)


            // x = 4.5R
            // y = 7.3R
            // res = math53.fmin(x, y)
            // Console.WriteLine("x: {0}, y: {1}, math53.Min(x, y): {2}", x, y, res)


        }


        public static void DemoDoubleElementary3()
        {

            Console.WriteLine("Hello DemoDoubleElementary3!");
            // mp4.setdps(30)
            // Dim k, n As Integer
            double x, y, z, fr;

            // int i1 = 3;
            // double d1 = 8.25d;
            var z1 = new Complex(8.75d, 1.125d);
            var z2 = new Complex(2.75d, 3.125d);
            // var z3 = new Complex();
            // var fc = new Complex();
            var i = Complex.ImaginaryOne;
            Console.WriteLine("z1: {0}", z1);
            Console.WriteLine("z2: {0}", z2);
            Console.WriteLine();




            Console.WriteLine("4.5 Exponential and related functions");

            x = 20.75d;
            fr = math53.exp(x);
            Console.WriteLine("x: {0}, math53.Exp(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.exp10(x);
            Console.WriteLine("x: {0}, math53.Exp10(x): {1}", x, fr);


            Console.WriteLine();


            x = 20.75d;
            fr = math53.exp2(x);
            Console.WriteLine("x: {0}, math53.Exp2(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.expm1(x);
            Console.WriteLine("x: {0}, math53.Expm1(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.exp10m1(x);
            Console.WriteLine("x: {0}, math53.Exp10m1(x): {1}", x, fr);

            x = 20.75d;
            fr = math53.exp2m1(x);
            Console.WriteLine("x: {0}, math53.Exp2m1(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.expmx2h(x);
            Console.WriteLine("x: {0}, math53.Expmx2h(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.exprel(x);
            Console.WriteLine("x: {0}, math53.Exprel(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.expx2(x);
            Console.WriteLine("x: {0}, math53.Expx2(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.logistic(x);
            Console.WriteLine("x: {0}, math53.Logistic(x): {1}", x, fr);






            Console.WriteLine();
            Console.WriteLine("4.6 Logarithms and related functions");


            x = 20.75d;
            fr = math53.log(x);
            Console.WriteLine("x: {0}, math53.Ln(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.log10(x);
            Console.WriteLine("x: {0}, math53.Log10(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.log2(x);
            Console.WriteLine("x: {0}, math53.Log2(x): {1}", x, fr);


            int b = 10;
            x = 4.5d;
            fr = math53.logbase(b, x);
            Console.WriteLine("b: {0}, x: {1}, math53.Logbase(b, x): {2}", b, x, fr);




            x = 0.0000075d;
            fr = math53.log1p(x);
            Console.WriteLine("x: {0}, math53.Ln1p(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.log2p1(x);
            Console.WriteLine("x: {0}, math53.Log2p1(x): {1}", x, fr);

            x = 20.75d;
            fr = math53.log10p1(x);
            Console.WriteLine("x: {0}, math53.Log10p1(x): {1}", x, fr);


            x = -20.75d;
            fr = math53.log1mexp(x);
            Console.WriteLine("x: {0}, math53.log1mexp(x): {1}", x, fr);

            x = 20.75d;
            fr = math53.log1pexp(x);
            Console.WriteLine("x: {0}, math53.log1pexp(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.log1pmx(x);
            Console.WriteLine("x: {0}, math53.log1pmx(x): {1}", x, fr);

            x = 20.75d;
            fr = math53.logcosh(x);
            Console.WriteLine("x: {0}, math53.logcosh(x): {1}", x, fr);

            x = 20.75d;
            fr = math53.logsinh(x);
            Console.WriteLine("x: {0}, math53.logsinh(x): {1}", x, fr);

            x = 4.5d;
            y = 7.3d;
            fr = math53.logaddexp(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Logaddexp(x, y): {2}", x, y, fr);

            x = 14.5d;
            y = 7.3d;
            fr = math53.logsubexp(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Logsubexp(x, y): {2}", x, y, fr);

            x = 0.51d;
            fr = math53.logit(x);
            Console.WriteLine("x: {0}, math53.Logit(x): {1}", x, fr);







            Console.WriteLine();
            Console.WriteLine("4.7 Power functions and roots");

            x = 4.5d;

            x = 4.5d;
            int n = 12;
            // fr = math53.powi(x, n)
            // Console.WriteLine("x: {0}, n: {1}, math53.Intpower(x, n): {2}", x, n, fr)



            //x = 20.75;
            //n = 12;
            //fr = math53.compound(x, n);
            // Console.WriteLine("x: {0}, n: {1}, math53.Compound(x, n): {2}", x, n, fr)

            x = 20.75d;
            n = 12;
            fr = math53.comprel(x, n);
            Console.WriteLine("x: {0}, n: {1}, math53.Comprel(x, n): {2}", x, n, fr);


            x = 4.5d;
            fr = math53.sqrt(x);
            Console.WriteLine("x: {0}, math53.Sqrt(x): {1}", x, fr);



            x = 0.000001d;
            fr = math53.sqrt1pmx(x);
            Console.WriteLine("x: {0}, math53.Sqrt1pmx(x): {1}", x, fr);



            x = 4.5d;
            y = 7.3d;
            z = 11.3d;
            fr = math53.hypot3(x, y, z);
            Console.WriteLine("x: {0}, y: {1}, z: {2}, math53.Hypot3(x, y, z): {3}", x, y, z, fr);

            Console.WriteLine();


            x = 4.5d;
            fr = math53.cbrt(x);
            Console.WriteLine("x: {0}, math53.Cbrt(x): {1}", x, fr);




            x = 4.5d;
            n = 12;
            fr = math53.nroot(x, n);
            Console.WriteLine("x: {0}, n: {1}, math53.Nroot(x, n): {2}", x, n, fr);



            x = 14.5d;
            y = 7.3d;
            fr = math53.pow(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Power(x, y): {2}", x, y, fr);



            x = 14.5d;
            y = 7.3d;
            fr = math53.powm1(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Powm1(x, y): {2}", x, y, fr);


            x = 14.5d;
            y = 7.3d;
            fr = math53.pow1p(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Pow1p(x, y): {2}", x, y, fr);




            x = 14.5d;
            y = 7.3d;
            fr = math53.pow1pm1(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Pow1pm1(x, y): {2}", x, y, fr);







            Console.WriteLine();
            Console.WriteLine("4.8 Trigonometric functions");


            x = 4.5d;
            fr = math53.sin(x);
            Console.WriteLine("x: {0}, math53.Sin(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.covers(x);
            Console.WriteLine("x: {0}, math53.Covers(x): {1}", x, fr);
            Console.WriteLine();


            x = 0.51d;
            fr = math53.versint(x);
            Console.WriteLine("x: {0}, math53.Versint(x): {1}", x, fr);
            Console.WriteLine();


            x = 180.0d;
            fr = math53.sind(x);
            Console.WriteLine("x: {0}, math53.Sind(x): {1}", x, fr);
            Console.WriteLine();


            x = 4.5d;
            fr = math53.sinpi(x);
            Console.WriteLine("x: {0}, math53.SinPi(x): {1}", x, fr);

            x = 20.75d;
            fr = math53.cos(x);
            Console.WriteLine("x: {0}, math53.Cos(x): {1}", x, fr);


            x = 0.51d;
            fr = math53.vers(x);
            Console.WriteLine("x: {0}, math53.Vers(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.hav(x);
            Console.WriteLine("x: {0}, math53.Hav(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.cosd(x);
            Console.WriteLine("x: {0}, math53.Cosd(x): {1}", x, fr);
            Console.WriteLine();


            x = 20.75d;
            fr = math53.cospi(x);
            Console.WriteLine("x: {0}, math53.CosPi(x): {1}", x, fr);


            x = 0.51d;
            fr = math53.sinc(x);
            Console.WriteLine("x: {0}, math53.Sinc(x): {1}", x, fr);


            x = 0.51d;
            fr = math53.sincpi(x);
            Console.WriteLine("x: {0}, math53.SincPi(x): {1}", x, fr);


            x = 0.51d;
            fr = math53.tan(x);


            x = 0.51d;
            fr = math53.tand(x);
            Console.WriteLine("x: {0}, math53.Tand(x): {1}", x, fr);
            Console.WriteLine();


            x = 0.51d;
            fr = math53.tanpi(x);
            Console.WriteLine("x: {0}, math53.TanPi(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.cot(x);
            Console.WriteLine("x: {0}, math53.Cot(x): {1}", x, fr);



            x = 20.75d;
            fr = math53.Cotd(x);
            Console.WriteLine("x: {0}, math53.Cotd(x): {1}", x, fr);
            Console.WriteLine();


            x = 20.75d;
            fr = math53.csc(x);
            Console.WriteLine("x: {0}, math53.Csc(x): {1}", x, fr);


            x = 0.51d;
            fr = math53.sec(x);
            Console.WriteLine("x: {0}, math53.Sec(x): {1}", x, fr);







            Console.WriteLine();
            Console.WriteLine("4.9 Hyperbolic functions");


            x = 0.51d;
            fr = math53.sinh(x);
            Console.WriteLine("x: {0}, math53.Sinh(x): {1}", x, fr);


            x = 0.51d;
            fr = math53.sinhc(x);
            Console.WriteLine("x: {0}, math53.Sinhc(x): {1}", x, fr);
            Console.WriteLine();


            x = 0.51d;
            fr = math53.sinhmx(x);
            Console.WriteLine("x: {0}, math53.Sinhmx(x): {1}", x, fr);
            Console.WriteLine();


            x = 20.75d;
            fr = math53.cosh(x);
            Console.WriteLine("x: {0}, math53.Cosh(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.coshm1(x);
            Console.WriteLine("x: {0}, math53.Coshm1(x): {1}", x, fr);
            Console.WriteLine();


            x = 0.51d;
            fr = math53.tanh(x);


            x = 0.75d;
            fr = math53.coth(x);
            Console.WriteLine("x: {0}, math53.Coth(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.csch(x);


            x = 0.51d;
            fr = math53.sech(x);
            Console.WriteLine("x: {0}, math53.Sech(x): {1}", x, fr);







            Console.WriteLine();
            Console.WriteLine("4.10 Inverse trigonometric functions");

            x = 0.75d;
            fr = math53.asin(x);
            Console.WriteLine("x: {0}, math53.Asin(x): {1}", x, fr);


            x = 0.75d;
            fr = math53.asind(x);
            Console.WriteLine("x: {0}, math53.Asind(x): {1}", x, fr);
            Console.WriteLine();


            x = 0.75d;
            fr = math53.acos(x);
            Console.WriteLine("x: {0}, math53.Acos(x): {1}", x, fr);



            x = 0.75d;
            fr = math53.acosd(x);
            Console.WriteLine("x: {0}, math53.Acosd(x): {1}", x, fr);
            Console.WriteLine();


            x = 0.000001d;
            fr = math53.acos1m(x);
            Console.WriteLine("x: {0}, math53.Acos1m(x): {1}", x, fr);
            Console.WriteLine();


            x = 20.75d;
            fr = math53.atan(x);
            Console.WriteLine("x: {0}, math53.Atan(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.atand(x);
            Console.WriteLine("x: {0}, math53.Atand(x): {1}", x, fr);
            Console.WriteLine();


            x = 4.5d;
            y = 7.3d;
            fr = math53.atan2(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Atan2(x, y): {2}", x, y, fr);


            x = 20.75d;
            fr = math53.acot(x);
            Console.WriteLine("x: {0}, math53.Acot(x): {1}", x, fr);



            x = 20.75d;
            fr = math53.acotd(x);
            Console.WriteLine("x: {0}, math53.Acotd(x): {1}", x, fr);
            Console.WriteLine();


            x = 20.75d;
            fr = math53.acotc(x);
            Console.WriteLine("x: {0}, math53.Acotc(x): {1}", x, fr);




            x = 20.75d;
            fr = math53.acotcd(x);
            Console.WriteLine("x: {0}, math53.Acotcd(x): {1}", x, fr);
            Console.WriteLine();


            x = 20.75d;
            fr = math53.acsc(x);
            Console.WriteLine("x: {0}, math53.Acsc(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.asec(x);
            Console.WriteLine("x: {0}, math53.Asec(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.gudermann(x);
            Console.WriteLine("x: {0}, math53.Gudermann(x): {1}", x, fr);
            Console.WriteLine();


            x = 0.75d;
            fr = math53.archav(x);
            Console.WriteLine("x: {0}, math53.Archav(x): {1}", x, fr);
            Console.WriteLine();








            Console.WriteLine();
            Console.WriteLine("4.11 Inverse hyperbolic functions");


            x = 20.75d;
            fr = math53.asinh(x);
            Console.WriteLine("x: {0}, math53.Asinh(x): {1}", x, fr);


            x = 20.75d;
            fr = math53.acosh(x);
            Console.WriteLine("x: {0}, math53.Acosh(x): {1}", x, fr);


            x = 0.000001d;
            fr = math53.acosh1p(x);
            Console.WriteLine("x: {0}, math53.Acosh1p(x): {1}", x, fr);


            x = 0.75d;
            fr = math53.atanh(x);
            Console.WriteLine("x: {0}, math53.Atanh(x): {1}", x, fr);
            Console.WriteLine();


            x = 20.75d;
            fr = math53.acoth(x);
            Console.WriteLine("x: {0}, math53.Acoth(x): {1}", x, fr);
            Console.WriteLine();




            x = 20.75d;
            fr = math53.acsch(x);
            Console.WriteLine("x: {0}, math53.Acsch(x): {1}", x, fr);


            x = 0.75d;
            fr = math53.asech(x);
            Console.WriteLine("x: {0}, math53.Asech(x): {1}", x, fr);


            x = 0.75d;
            fr = math53.arcgudermann(x);
            Console.WriteLine("x: {0}, math53.Arcgd(x): {1}", x, fr);




            // ******** End ***********







        }


        public static void DemoDoubleBessel()
        {
            Console.WriteLine("Hello DemoDoubleBessel!");
            int n;
            double x, v, u, res;


            Console.WriteLine();


            //x = 0.75d;
            //v = 3.1d;
            //res = math53.bessel_jv(v, x);
            //Console.WriteLine("v: {0}, x: {1}, math53.BesselJv(v, x): {2}", v, x, res);

            //x = 0.75d;
            //v = 3.1d;
            //res = math53.bessel_yv(v, x);
            //Console.WriteLine("v: {0}, x: {1}, math53.BesselYv(v, x): {2}", v, x, res);

            x = 0.75d;
            v = 3.1d;
            res = math53.bessel_lambda(v, x);
            Console.WriteLine("v: {0}, x: {1}, math53.BesselLambda(v, x): {2}", v, x, res);


            Console.WriteLine();


            //x = 0.75d;
            //v = 3.1d;
            //res = math53.bessel_iv(v, x);
            //Console.WriteLine("v: {0}, x: {1}, math53.BesselIv(v, x): {2}", v, x, res);

            //x = 0.75d;
            //v = 3.1d;
            //res = math53.bessel_ive(v, x);
            //Console.WriteLine("v: {0}, x: {1}, math53.BesselIve(v, x): {2}", v, x, res);

            //x = 0.75d;
            //v = 3.1d;
            //res = math53.bessel_kv(v, x);
            //Console.WriteLine("v: {0}, x: {1}, math53.BesselKv(v, x): {2}", v, x, res);

            //x = 0.75d;
            //v = 3.1d;
            //res = math53.bessel_kve(v, x);
            //Console.WriteLine("v: {0}, x: {1}, math53.BesselKve(v, x): {2}", v, x, res);


            Console.WriteLine();

            u = 4.75d;
            res = math53.bessel_i0_int(u);
            Console.WriteLine("u: {0}, math53.BesselI0Int(u): {1}", u, res);

            u = 4.75d;
            res = math53.bessel_j0_int(u);
            Console.WriteLine("u: {0}, math53.BesselJ0Int(u): {1}", u, res);

            u = 4.75d;
            res = math53.bessel_k0_int(u);
            Console.WriteLine("u: {0}, math53.BesselK0Int(u): {1}", u, res);

            u = 4.75d;
            res = math53.bessel_i0_int(u);
            Console.WriteLine("u: {0}, math53.BesselI0Int(u): {1}", u, res);


            Console.WriteLine();

            //x = 0.75d;
            //n = 3;
            //res = math53.sph_bessel_jn(n, x);
            //Console.WriteLine("n: {0}, x: {1}, math53.SphBesselJn(n, x): {2}", n, x, res);

            //x = 0.75d;
            //n = 3;
            //res = math53.sph_bessel_yn(n, x);
            //Console.WriteLine("n: {0}, x: {1}, math53.SphBesselYn(n, x): {2}", n, x, res);

            x = 0.75d;
            n = 3;
            res = math53.sph_bessel_in(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.SphBesselIn(n, x): {2}", n, x, res);

            //x = 0.75d;
            //n = 3;
            //res = math53.sph_bessel_ine(n, x);
            //Console.WriteLine("n: {0}, x: {1}, math53.SphBesselIne(n, x): {2}", n, x, res);

            x = 0.75d;
            n = 3;
            res = math53.sph_bessel_kn(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.SphBesselKn(n, x): {2}", n, x, res);

            //x = 0.75d;
            //n = 3;
            //res = math53.sph_bessel_kne(n, x);
            //Console.WriteLine("n: {0}, x: {1}, math53.SphBesselKne(n, x): {2}", n, x, res);



            Console.WriteLine();

            x = 0.75d;
            res = math53.airy_ai(x);
            Console.WriteLine("x: {0}, math53.AiryAi(x): {1}", x, res);

            x = 0.75d;
            res = math53.airy_ai_prime(x);
            Console.WriteLine("x: {0}, math53.AiryAip(x): {1}", x, res);

            x = 0.75d;
            res = math53.airy_ai_scaled_(x);
            Console.WriteLine("x: {0}, math53.AiryAis(x): {1}", x, res);

            x = 0.75d;
            res = math53.airy_bi(x);
            Console.WriteLine("x: {0}, math53.AiryBi(x): {1}", x, res);

            x = 0.75d;
            res = math53.airy_bi_prime(x);
            Console.WriteLine("x: {0}, math53.AiryBip(x): {1}", x, res);

            x = 0.75d;
            res = math53.airy_bi_scaled_(x);
            Console.WriteLine("x: {0}, math53.AiryBis(x): {1}", x, res);

            x = 0.75d;
            res = math53.airy_gi(x);
            Console.WriteLine("x: {0}, math53.AiryGi(x): {1}", x, res);

            x = 0.75d;
            res = math53.airy_hi(x);
            Console.WriteLine("x: {0}, math53.AiryHi(x): {1}", x, res);



            Console.WriteLine();

            x = 0.75d;
            res = math53.kelvin_bei0(x);
            Console.WriteLine("x: {0}, math53.KelvinBei(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_bei_prime0(x);
            Console.WriteLine("x: {0}, math53.KelvinBeip(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_ber0(x);
            Console.WriteLine("x: {0}, math53.KelvinBer(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_ber_prime0(x);
            Console.WriteLine("x: {0}, math53.KelvinBerp(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_kei0(x);
            Console.WriteLine("x: {0}, math53.KelvinKei(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_bei_prime0(x);
            Console.WriteLine("x: {0}, math53.KelvinKeip(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_ker0(x);
            Console.WriteLine("x: {0}, math53.KelvinKer(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_ker_prime0(x);
            Console.WriteLine("x: {0}, math53.KelvinKerp(x): {1}", x, res);

            // MISSING: KelvinKerKei
            // MISSING: KelvinBerBei
            // MISSING: KelvinDer




            Console.WriteLine();

            x = 0.75d;
            res = math53.struve_h0(x);
            Console.WriteLine("x: {0}, math53.StruveH0(x): {1}", x, res);

            x = 0.75d;
            res = math53.struve_h1(x);
            Console.WriteLine("x: {0}, math53.StruveH1(x): {1}", x, res);

            x = 0.75d;
            v = 3.1d;
            res = math53.struve_h(v, x);
            Console.WriteLine("v: {0}, x: {1}, math53.StruveH(x): {2}", v, x, res);


            x = 0.75d;
            res = math53.struve_l0(x);
            Console.WriteLine("x: {0}, math53.StruveL0(x): {1}", x, res);

            x = 0.75d;
            res = math53.struve_l1(x);
            Console.WriteLine("x: {0}, math53.StruveL1(x): {1}", x, res);

            x = 0.75d;
            v = 3.1d;
            res = math53.struve_l(v, x);
            Console.WriteLine("v: {0}, x: {1}, math53.StruveL(x): {2}", v, x, res);



            Console.WriteLine();

            int L = 3;
            double eta = 0.75d;
            res = math53.coulomb_cl(L, eta);
            Console.WriteLine("L: {0}, eta: {1}, math53.CoulombCL(L, eta): {2}", L, eta, res);

            L = 3;
            eta = 0.75d;
            res = math53.coulomb_sl(L, eta);
            Console.WriteLine("L: {0}, eta: {1}, math53.CoulombSL(L, eta): {2}", L, eta, res);

            L = 3;
            eta = 0.75d;
            x = 4.0d;
            res = math53.coulomb_f(L, eta, x);
            Console.WriteLine("L: {0}, eta: {1}, x: {2}, math53.CoulombF(L, eta, x): {3}", L, eta, x, res);


            // MISSING: CoulombFFp
            // MISSING: CoulombGGp



            Console.WriteLine();

            x = 0.75d;
            res = math53.synchrotron_f(x);
            Console.WriteLine("x: {0}, math53.SynchF(x): {1}", x, res);

            x = 0.75d;
            res = math53.synchrotron_g(x);
            Console.WriteLine("x: {0}, math53.SynchG(x): {1}", x, res);




            Console.WriteLine();

        }


        public static void DemoDoubleEllipticIntegrals()
        {
            Console.WriteLine("Hello DemoDoubleEllipticIntegrals!");
            // Dim n As Int32
            double phi, nu, k, res;
            double x, y, z, r;
            double kc, p, a, b;
            double m, n;

            k = 0.75d;
            res = math53.elliptic_k(k);
            Console.WriteLine("k: {0}, math53.elliptic_k(k): {1}", k, res);

            k = 0.75d;
            res = math53.elliptic_e(k);
            Console.WriteLine("k: {0}, math53.elliptic_e(k): {1}", k, res);

            nu = 3.0d;
            k = 0.75d;
            res = math53.elliptic_pi(nu, k);
            Console.WriteLine("nu: {0}, k: {1}, math53.elliptic_pi(nu, k): {2}", nu, k, res);

            k = 0.75d;
            res = math53.elliptic_b(k);
            Console.WriteLine("k: {0}, math53.elliptic_b(k): {1}", k, res);

            k = 0.75d;
            res = math53.elliptic_d(k);
            Console.WriteLine("k: {0}, math53.elliptic_d(k): {1}", k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.elliptic_f(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.Ellint1(phi, k): {2}", phi, k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.elliptic_e_inc(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.Ellint2(phi, k): {2}", phi, k, res);

            phi = 0.3d;
            nu = 3.0d;
            k = 0.75d;
            res = math53.elliptic_pi_inc(phi, nu, k);
            Console.WriteLine("phi: {0}, nu: {1}, k: {2}, math53.Ellint3(phi, nu, k): {3}", phi, nu, k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.elliptic_d_inc(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.elliptic_d_inc(phi, k): {2}", phi, k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.elliptic_b_inc(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.elliptic_b_inc(phi, k): {2}", phi, k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.heuman_lambda(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.HeumanLambda(phi, k): {2}", phi, k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.jacobi_zeta(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.JacobiZeta(phi, k): {2}", phi, k, res);


            Console.WriteLine();


            x = 0.75d;
            y = 0.1d;
            z = 0.4d;
            res = math53.elliptic_rd(x, y, z);
            Console.WriteLine("x: {0}, y: {1}, z: {2}, math53.EllipticRD(x, y, z): {3}", x, y, z, res);

            x = 0.75d;
            y = 0.1d;
            z = 0.4d;
            res = math53.elliptic_rf(x, y, z);
            Console.WriteLine("x: {0}, y: {1}, z: {2}, math53.EllipticRF(x, y, z): {3}", x, y, z, res);

            x = 0.75d;
            y = 0.1d;
            z = 0.4d;
            res = math53.elliptic_rd(x, y, z);
            Console.WriteLine("x: {0}, y: {1}, z: {2}, math53.EllipticRD(x, y, z): {3}", x, y, z, res);

            x = 0.75d;
            y = 0.1d;
            z = 0.4d;
            res = math53.elliptic_rg(x, y, z);
            Console.WriteLine("x: {0}, y: {1}, z: {2}, math53.EllipticRG(x, y, z): {3}", x, y, z, res);

            x = 0.75d;
            y = 0.1d;
            z = 0.4d;
            r = 0.7d;
            res = math53.elliptic_rj(x, y, z, r);
            Console.WriteLine("x: {0}, y: {1}, z: {2}, r: {3}, math53.EllipticRJ(x, y, z, r): {4}", x, y, z, r, res);



            Console.WriteLine();


            kc = 0.75d;
            res = math53.cel1(kc);
            Console.WriteLine("kc: {0}, math53.Cel1(kc): {1}", kc, res);

            kc = 0.75d;
            a = 1.4d;
            b = 1.6d;
            res = math53.cel2(kc, a, b);
            Console.WriteLine("kc: {0}, a: {1}, b: {2}, math53.Cel2(kc, a, b): {3}", kc, a, b, res);

            kc = 0.75d;
            p = 1.1d;
            a = 1.4d;
            b = 1.6d;
            res = math53.cel(kc, p, a, b);
            Console.WriteLine("kc: {0}, p: {1}, a: {2}, b: {3}, math53.Cel(kc, p, a, b): {4}", kc, p, a, b, res);

            x = 1.3d;
            kc = 0.75d;
            res = math53.el1(x, kc);
            Console.WriteLine("x: {0}, kc: {1}, math53.El1(x, kc): {2}", x, kc, res);

            x = 1.3d;
            kc = 0.75d;
            a = 1.4d;
            b = 1.6d;
            res = math53.el2(x, kc, a, b);
            Console.WriteLine("x: {0}, kc: {1}, a: {2}, b: {3}, math53.El2(x, kc, a, b): {4}", x, kc, a, b, res);

            x = 1.3d;
            kc = 0.75d;
            p = 1.4d;
            res = math53.el3(x, kc, p);
            Console.WriteLine("x: {0}, kc: {1}, p: {2}, math53.El3(x, kc, p): {3}", x, kc, p, res);




            Console.WriteLine();

            z = 0.75d;
            k = 0.1d;
            res = math53.ellipticF(z, k);
            Console.WriteLine("z: {0}, k: {1}, math53.EllipticF(z, k): {2}", z, k, res);

            k = 0.75d;
            res = math53.ellipticK(k);
            Console.WriteLine("k: {0}, math53.EllipticK(k): {1}", k, res);

            k = 0.75d;
            res = math53.ellipticKim(k);
            Console.WriteLine("k: {0}, math53.EllipticKim(k): {1}", k, res);

            k = 0.75d;
            res = math53.ellipticCK(k);
            Console.WriteLine("k: {0}, math53.EllipticCK(k): {1}", k, res);

            z = 0.75d;
            k = 0.1d;
            res = math53.ellipticE(z, k);
            Console.WriteLine("z: {0}, k: {1}, math53.EllipticE(z, k): {2}", z, k, res);

            k = 0.75d;
            res = math53.ellipticEC(k);
            Console.WriteLine("k: {0}, math53.EllipticEC(k): {1}", k, res);

            k = 0.75d;
            res = math53.ellipticECim(k);
            Console.WriteLine("k: {0}, math53.EllipticECim(k): {1}", k, res);

            k = 0.75d;
            res = math53.ellipticCE(k);
            Console.WriteLine("k: {0}, math53.EllipticCE(k): {1}", k, res);



            z = 0.75d;
            nu = 1.4d;
            k = 0.6d;
            res = math53.ellipticPi(z, nu, k);
            Console.WriteLine("z: {0}, nu: {1}, k: {2}, math53.EllipticPi(z, nu, k): {3}", z, nu, k, res);


            nu = 1.4d;
            k = 0.6d;
            res = math53.ellipticPiC(nu, k);
            Console.WriteLine("nu: {0}, k: {1}, math53.EllipticPiC(nu, k): {2}", nu, k, res);


            nu = 1.4d;
            k = 0.6d;
            res = math53.ellipticCPi(nu, k);
            Console.WriteLine("nu: {0}, k: {1}, math53.EllipticCPi(nu, k): {2}", nu, k, res);


            nu = 1.4d;
            k = 0.6d;
            res = math53.ellipticPiCim(nu, k);
            Console.WriteLine("nu: {0}, k: {1}, math53.EllipticPiCim(nu, k): {2}", nu, k, res);



            Console.WriteLine();


            m = 0.75d;
            res = math53.m_elliptic_k(m);
            Console.WriteLine("m: {0}, math53.M_EllipticK(m): {1}", m, res);

            m = 0.75d;
            res = math53.m_elliptic_e(m);
            Console.WriteLine("m: {0}, math53.M_EllipticEC(m): {1}", m, res);

            n = 3.1d;
            m = 0.75d;
            res = math53.m_elliptic_pi(n, m);
            Console.WriteLine("n: {0}, m: {1}, math53.M_EllipticPiC(n, m): {2}", n, m, res);

            phi = 0.1d;
            m = 0.75d;
            res = math53.m_elliptic_f(phi, m);
            Console.WriteLine("phi: {0}, m: {1}, math53.M_EllipticF(phi, m): {2}", phi, m, res);

            phi = 0.1d;
            m = 0.75d;
            res = math53.m_elliptic_e_inc(phi, m);
            Console.WriteLine("phi: {0}, m: {1}, math53.M_EllipticE(phi, m): {2}", phi, m, res);

            n = 3.1d;
            phi = 0.1d;
            m = 0.75d;
            res = math53.m_elliptic_pi_inc(n, phi, m);
            Console.WriteLine("n: {0}, phi: {1}, m: {2}, math53.M_EllipticPi(n, phi, m): {3}", n, phi, m, res);




            Console.WriteLine();


            double q = 0.05d;
            res = math53.elliptic_modulus(q);
            Console.WriteLine("q: {0}, math53.EllipticModulus(m): {1}", q, res);

            k = 0.75d;
            res = math53.elliptic_nome(k);
            Console.WriteLine("k: {0}, math53.EllipticNome(k): {1}", k, res);


            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_amplitude(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiAmplitude(x, k): {2}", x, k, res);


            Console.WriteLine();

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arccn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcCN(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arccd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcCD(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arccs(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcCS(x, k): {2}", x, k, res);

            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcdc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcDC(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 1.75d;
            res = math53.jacobi_arcdn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcDN(x, k): {2}", x, k, res);

            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcds(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcDS(x, k): {2}", x, k, res);

            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcnc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcNC(x, k): {2}", x, k, res);

            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcnd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcND(x, k): {2}", x, k, res);

            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcns(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcNS(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arcsc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcSC(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arcsd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcSD(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arcsn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiArcSN(x, k): {2}", x, k, res);


            Console.WriteLine();

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_sn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiSN(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_cn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiCN(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_dn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiDN(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_nc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiNC(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_sc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiSC(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_dc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiDC(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_nd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiND(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_sd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiSD(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_cd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiCD(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_ns(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiNS(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_cs(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiCS(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_ds(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.JacobiDS(x, k): {2}", x, k, res);

            // MISSING: sncndn


            Console.WriteLine();

            int nn = 1;
            x = 0.3d;
            q = 0.75d;
            res = math53.jacobi_theta(nn, x, q);
            Console.WriteLine("n: {0}, x: {1}, k: {2}, math53.JacobiTheta(nn, x, q): {3}", nn, x, k, res);

            q = 0.75d;
            res = math53.jacobi_theta1p(q);
            Console.WriteLine("q: {0}, math53.JacobiTheta1p(q): {1}", q, res);

            q = 0.75d;
            res = math53.jacobi_theta02(q);
            Console.WriteLine("q: {0}, math53.JacobiTheta2(q): {1}", q, res);

            q = 0.75d;
            res = math53.jacobi_theta03(q);
            Console.WriteLine("q: {0}, math53.JacobiTheta3(q): {1}", q, res);

            q = 0.75d;
            res = math53.jacobi_theta04(q);
            Console.WriteLine("q: {0}, math53.JacobiTheta4(q): {1}", q, res);



            Console.WriteLine();

            x = 0.3d;
            k = 0.75d;
            res = math53.neville_theta_c(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.NevilleThetaC(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.neville_theta_d(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.NevilleThetaD(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.neville_theta_n(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.NevilleThetaN(x, k): {2}", x, k, res);

            x = 0.3d;
            k = 0.75d;
            res = math53.neville_theta_s(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.NevilleThetaS(x, k): {2}", x, k, res);



            Console.WriteLine();

            x = 0.3d;
            res = math53.acos_lemniscate(x);
            Console.WriteLine("x: {0}, math53.AcosLemniscate(x): {1}", x, res);

            x = 0.3d;
            res = math53.asin_lemniscate(x);
            Console.WriteLine("x: {0}, math53.AsinLemniscate(x): {1}", x, res);

            // MISSING: SinCosLemniscate

            x = 0.3d;
            res = math53.sin_lemniscate(x);
            Console.WriteLine("x: {0}, math53.SinLemniscate(x): {1}", x, res);

            x = 0.3d;
            res = math53.cos_lemniscate(x);
            Console.WriteLine("x: {0}, math53.CosLemniscate(x): {1}", x, res);



            Console.WriteLine();

            y = 0.3d;
            res = math53.weierstrass_pl(y);
            Console.WriteLine("y: {0}, math53.Wpl(y): {1}", y, res);


            double e1, e2;
            x = 0.1d;
            e1 = 0.75d;
            e2 = 1.75d;
            res = math53.weierstrass_pe(x, e1, e2);
            Console.WriteLine("x: {0}, e1: {1}, e2: {2}, math53.Wpe(x, e1, e2): {3}", x, e1, e2, res);

            x = 0.1d;
            e1 = 0.75d;
            e2 = 1.75d;
            res = math53.weierstrass_pe_prime(x, e1, e2);
            Console.WriteLine("x: {0}, e1: {1}, e2: {2}, math53.WpeDer(x, e1, e2): {3}", x, e1, e2, res);

            y = 0.1d;
            e1 = 0.75d;
            e2 = 1.75d;
            res = math53.weierstrass_pe_im(y, e1, e2);
            Console.WriteLine("y: {0}, e1: {1}, e2: {2}, math53.WpeIm(x, e1, e2): {3}", y, e1, e2, res);

            double g2, g3;
            x = 0.1d;
            g2 = 0.75d;
            g3 = 1.75d;
            res = math53.weierstrass_pg(x, g2, g3);
            Console.WriteLine("x: {0}, g2: {1}, g3: {2}, math53.Wpg(x, g2, g3): {3}", x, g2, g3, res);

            x = 0.1d;
            g2 = 0.75d;
            g3 = 1.75d;
            res = math53.weierstrass_pg_prime(x, g2, g3);
            Console.WriteLine("x: {0}, g2: {1}, g3: {2}, math53.WpgDer(x, g2, g3): {3}", x, g2, g3, res);

            y = 0.1d;
            g2 = 0.75d;
            g3 = 1.75d;
            res = math53.weierstrass_pg_im(y, g2, g3);
            Console.WriteLine("x: {0}, g2: {1}, g3: {2}, math53.WpgIm(x, g2, g3): {3}", x, g2, g3, res);

            y = 0.1d;
            e1 = 0.75d;
            e2 = 1.75d;
            res = math53.weierstrass_pe_inv(y, e1, e2);
            Console.WriteLine("y: {0}, e1: {1}, e2: {2}, math53.WpeInv(y, e1, e2): {3}", y, e1, e2, res);

            y = 0.5d;
            g2 = 0.05d;
            g3 = 0.07d;
            res = math53.weierstrass_pg_inv(y, g2, g3);
            Console.WriteLine("y: {0}, g2: {1}, g3: {2}, math53.WpgInv(y, g2, g3): {3}", y, g2, g3, res);

            x = 0.3d;
            res = math53.dedekind_eta_i(x);
            Console.WriteLine("x: {0}, math53.Detai(x): {1}", x, res);

            y = 0.3d;
            res = math53.elliptic_modular_lambda(y);
            Console.WriteLine("y: {0}, math53.EmLambda(y): {1}", y, res);

            y = 0.3d;
            res = math53.klein_j_i(y);
            Console.WriteLine("y: {0}, math53.KleinJ(y): {1}", y, res);


            Console.WriteLine();

        }


        public static void DemoDoubleErrorFunction()
        {

            Console.WriteLine("Hello DemoDoubleErrorFunction!");
            int m;
            double x, x1, x2, p, h, a, b, res;

            x = 0.75d;
            res = math53.dawson(x);
            Console.WriteLine("x: {0}, math53.Dawson(x): {1}", x, res);

            p = 3.1d;
            x = 0.75d;
            res = math53.dawson2(p, x);
            Console.WriteLine("p: {0}, x: {1}, math53.Dawson2(p, x): {2}", p, x, res);

            x = 0.75d;
            res = math53.erf(x);
            Console.WriteLine("x: {0}, math53.Erf(x): {1}", x, res);

            p = 3.1d;
            x = 0.75d;
            res = math53.erfg(p, x);
            Console.WriteLine("p: {0}, x: {1}, math53.Erfg(p, x): {2}", p, x, res);

            x = 0.75d;
            res = math53.erfc(x);
            Console.WriteLine("x: {0}, math53.Erfc(x): {1}", x, res);

            x = 0.75d;
            res = math53.erfcx(x);
            Console.WriteLine("x: {0}, math53.erfcx(x): {1}", x, res);

            int pp;
            pp = 3;
            x = 0.75d;
            res = math53.inerfc(pp, x);
            Console.WriteLine("pp: {0}, x: {1}, math53.InErfc(pp, x): {2}", pp, x, res);

            x = 0.75d;
            res = math53.erfi(x);
            Console.WriteLine("x: {0}, math53.Erfi(x): {1}", x, res);

            x = 0.75d;
            h = 0.001d;
            res = math53.erfh(x, h);
            Console.WriteLine("x: {0}, h: {1}, math53.Erfh(x, h): {2}", x, h, res);

            x1 = 0.75d;
            x2 = 4.001d;
            res = math53.erf2(x1, x2);
            Console.WriteLine("x: {0}, h: {1}, math53.Erf2(x1, x2): {2}", x, h, res);

            x = 0.75d;
            res = math53.erf_inv(x);
            Console.WriteLine("x: {0}, math53.ErfInv(x): {1}", x, res);

            x = 0.75d;
            res = math53.erfc_inv(x);
            Console.WriteLine("x: {0}, math53.ErfcInv(x): {1}", x, res);

            x = 0.75d;
            res = math53.erfi_inv(x);
            Console.WriteLine("x: {0}, math53.ErfiInv(x): {1}", x, res);

            x = 0.75d;
            res = math53.ndis(x);
            Console.WriteLine("x: {0}, math53.ndis(x): {1}", x, res);

            x = 0.75d;
            res = math53.erfq(x);
            Console.WriteLine("x: {0}, math53.ErfQ(x): {1}", x, res);

            x = 0.75d;
            res = math53.ndens(x);
            Console.WriteLine("x: {0}, math53.ndens(x): {1}", x, res);

            x = 0.75d;
            res = math53.expint3(x);
            Console.WriteLine("x: {0}, math53.Expint3(x): {1}", x, res);


            Console.WriteLine();

            // MISSING: Fresnel


            x = 0.75d;
            res = math53.fresnel_c(x);
            Console.WriteLine("x: {0}, math53.FresnelC(x): {1}", x, res);

            x = 0.75d;
            res = math53.fresnel_s(x);
            Console.WriteLine("x: {0}, math53.FresnelS(x): {1}", x, res);

            // MISSING: FresnelFG


            x = 0.75d;
            res = math53.fresnel_f(x);
            Console.WriteLine("x: {0}, math53.FresnelF(x): {1}", x, res);

            x = 0.75d;
            res = math53.fresnel_g(x);
            Console.WriteLine("x: {0}, math53.FresnelG(x): {1}", x, res);

            x = 0.75d;
            res = math53.goodwin_staton(x);
            Console.WriteLine("x: {0}, math53.GoodwinStatonInt(x): {1}", x, res);


            m = 3;
            a = 0.75d;
            b = 4.001d;
            res = math53.marcum_q(m, a, b);
            Console.WriteLine("m: {0}, a: {1}, b: {2}, math53.MarcumQ(m, a, b): {3}", m, a, b, res);


            h = 0.75d;
            a = 4.001d;
            res = math53.owen_t(h, a);
            Console.WriteLine("h: {0}, a: {1}, math53.OwenT(h, a): {2}", h, a, res);

            Console.WriteLine();

        }


        public static void DemoDoubleExponentialIntegral()
        {

            Console.WriteLine("Hello DemoDoubleExponentialIntegral!");
            int n;
            double x, p, res;

            x = 0.75d;
            res = math53.cosh_integral(x);
            Console.WriteLine("x: {0}, math53.Chi(x): {1}", x, res);

            x = 0.75d;
            res = math53.cos_integral(x);
            Console.WriteLine("x: {0}, math53.Ci(x): {1}", x, res);

            x = 0.75d;
            res = math53.cin(x);
            Console.WriteLine("x: {0}, math53.Cin(x): {1}", x, res);

            x = 0.75d;
            res = math53.cinh(x);
            Console.WriteLine("x: {0}, math53.Cinh(x): {1}", x, res);

            x = 0.75d;
            res = math53.exp_integral_e1(x);
            Console.WriteLine("x: {0}, math53.E1(x): {1}", x, res);

            x = 0.75d;
            res = math53.exp_integral_e1_scaled(x);
            Console.WriteLine("x: {0}, math53.E1s(x): {1}", x, res);

            x = 0.75d;
            res = math53.exp_integral_ei(x);
            Console.WriteLine("x: {0}, math53.Ei(x): {1}", x, res);

            x = 0.75d;
            res = math53.exp_integral_ei_scaled(x);
            Console.WriteLine("x: {0}, math53.Eis(x): {1}", x, res);

            x = 0.75d;
            res = math53.eisx2(x);
            Console.WriteLine("x: {0}, math53.Eisx2(x): {1}", x, res);

            x = 0.75d;
            res = math53.ei_inv(x);
            Console.WriteLine("x: {0}, math53.EiInv(x): {1}", x, res);

            x = 0.75d;
            res = math53.ein(x);
            Console.WriteLine("x: {0}, math53.Ein(x): {1}", x, res);

            n = 3;
            x = 0.75d;
            res = math53.exp_integral_en(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.En(n, x): {2}", n, x, res);

            p = 3.1d;
            x = 0.75d;
            res = math53.gei(p, x);
            Console.WriteLine("p: {0}, x: {1}, math53.Gei(p, x): {2}", p, x, res);

            n = 3;
            x = 0.75d;
            res = math53.eibeta(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Eibeta(n, x): {2}", n, x, res);

            x = 0.75d;
            res = math53.log_integral(x);
            Console.WriteLine("x: {0}, math53.Li(x): {1}", x, res);

            x = 0.75d;
            res = math53.log_integral_inv(x);
            Console.WriteLine("x: {0}, math53.LiInv(x): {1}", x, res);

            x = 0.75d;
            res = math53.sinh_integral(x);
            Console.WriteLine("x: {0}, math53.Shi(x): {1}", x, res);

            x = 0.75d;
            res = math53.sin_integral(x);
            Console.WriteLine("x: {0}, math53.Si(x): {1}", x, res);

            x = 0.75d;
            res = math53.shifted_sin_integral(x);
            Console.WriteLine("x: {0}, math53.Ssi(x): {1}", x, res);




            Console.WriteLine();

        }


        public static void DemoDoubleGamma()
        {

            Console.WriteLine("Hello DemoDoubleGamma!");
            int n, k;
            double a, b, d, x, y, p, q, res;

            x = 0.75d;
            res = math53.gamma(x);
            Console.WriteLine("x: {0}, math53.Gamma(x): {1}", x, res);

            x = 0.75d;
            res = math53.gamma1pm1(x);
            Console.WriteLine("x: {0}, math53.Gamma1pm1(x): {1}", x, res);

            y = 1.75d;
            res = math53.gamma_inv(y);
            Console.WriteLine("y: {0}, math53.GammaInv(y): {1}", y, res);

            x = 0.75d;
            res = math53.gammastar(x);
            Console.WriteLine("x: {0}, math53.GammaStar(x): {1}", x, res);

            x = 0.75d;
            res = math53.lgamma(x);
            Console.WriteLine("x: {0}, math53.LnGamma(x): {1}", x, res);

            y = 1.75d;
            res = math53.lgamma_inv(y);
            Console.WriteLine("y: {0}, math53.LnGammaInv(y): {1}", y, res);

            x = 0.75d;
            res = math53.lgamma1p(x);
            Console.WriteLine("x: {0}, math53.LnGamma1p(x): {1}", x, res);

            x = 0.75d;
            res = math53.rgamma(x);
            Console.WriteLine("x: {0}, math53.RGamma(x): {1}", x, res);

            x = 0.75d;
            res = math53.signgamma(x);
            Console.WriteLine("x: {0}, math53.SignGamma(x): {1}", x, res);

            // MISSING: LnGammaS


            Console.WriteLine();

            // MISSING: IncGamma

            a = 10.3d;
            x = 12.75d;
            res = math53.gamma_p(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.IncGammaP(a, x): {2}", a, x, res);

            a = 10.3d;
            x = 12.75d;
            res = math53.gamma_q(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.IncGammaQ(a, x): {2}", a, x, res);

            a = 10.3d;
            x = 12.75d;
            res = math53.gamma_upper(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.IncGammaU(a, x): {2}", a, x, res);

            a = 10.3d;
            x = 12.75d;
            res = math53.gamma_lower(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.IncgammaL(a, x): {2}", a, x, res);

            a = 10.3d;
            x = 12.75d;
            res = math53.gamma_tricomi(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.IncGammaT(a, x): {2}", a, x, res);

            // MISSING: IncGammaInvIerr

            // a = 10.3R
            // p = 0.75R
            // q = 1.0R - p
            // res = math53.IncGammaInv(a, p, q)
            // Console.WriteLine("a: {0}, p: {1}, q: {2}, math53.IncGammaInv(a, p, q): {3}", a, p, q, res)

            a = 10.3d;
            p = 0.75d;
            res = math53.gamma_p_inv(a, p);
            Console.WriteLine("a: {0}, p: {1}, math53.IncGammaPInv(a, p): {2}", a, p, res);

            a = 10.3d;
            q = 0.75d;
            res = math53.gamma_q_inv(a, q);
            Console.WriteLine("a: {0}, q: {1}, math53.IncGammaQInv(a, q): {2}", a, q, res);

            a = 10.3d;
            x = 12.75d;
            res = math53.gamma_p_prime(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.IncGammaPDer(a, x): {2}", a, x, res);


            Console.WriteLine();


            x = 10.3d;
            y = 12.75d;
            res = math53.beta(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Beta(x, y): {2}", x, y, res);

            x = 10.3d;
            y = 12.75d;
            res = math53.logbeta(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.LnBeta(x, y): {2}", x, y, res);


            // x = 10.3R
            // y = 12.75R
            // res = math53.LnBeta(x, y)
            // Console.WriteLine("x: {0}, y: {1}, math53.LnBeta(x, y): {2}", x, y, res)

            a = 10.3d;
            b = 12.75d;
            x = 0.6d;
            res = math53.ibeta(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.IBeta(a, b, x): {3}", a, b, x, res);

            a = 10.3d;
            b = 12.75d;
            x = 0.6d;
            res = math53.beta_lower(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.Beta3(a, b, x): {3}", a, b, x, res);


            a = 10.3d;
            b = 12.75d;
            y = 0.99d;
            res = math53.ibeta_inv(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.IBetaInv(a, b, x): {3}", a, b, y, res);



            Console.WriteLine();

            n = 12;
            res = math53.factorial(n);
            Console.WriteLine("n: {0}, math53.Fac(n): {1}", n, res);

            n = 12;
            res = math53.doublefactorial(n);
            Console.WriteLine("n: {0}, math53.DFac(n): {1}", n, res);

            n = 12;
            res = math53.logfactorial(n);
            Console.WriteLine("n: {0}, math53.LnFac(n): {1}", n, res);

            n = 12;
            k = 6;
            res = math53.binomial(n, k);
            Console.WriteLine("n: {0}, k: {1}, math53.Binomial(n, k): {2}", n, k, res);

            n = 12;
            k = 6;
            res = math53.logbinomial(n, k);
            Console.WriteLine("n: {0}, k: {1}, math53.LnBinomial(n, k): {2}", n, k, res);

            a = 10.3d;
            x = 12.75d;
            res = math53.rising_factorial(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.Pochhammer(a, x): {2}", a, x, res);

            a = 10.3d;
            x = 12.75d;
            res = math53.poch1(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.Poch1(a, x): {2}", a, x, res);

            x = 130.3d;
            d = 0.000075d;
            res = math53.gamma_delta_ratio(x, d);
            Console.WriteLine("x: {0}, d: {1}, math53.GammaDeltaRatio(x, d): {2}", x, d, res);

            x = 10.3d;
            y = 12.75d;
            res = math53.gamma_ratio(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.GammaRatio(x, y): {2}", x, y, res);



            Console.WriteLine();

            x = 12.1d;
            res = math53.psi(x);
            Console.WriteLine("x: {0}, math53.Psi(x): {1}", x, res);

            x = 12.1d;
            res = math53.psistar(x);
            Console.WriteLine("x: {0}, math53.PsiStar(x): {1}", x, res);

            x = 12.1d;
            res = math53.trigamma(x);
            Console.WriteLine("x: {0}, math53.TriGamma(x): {1}", x, res);

            x = 12.1d;
            res = math53.tetragamma(x);
            Console.WriteLine("x: {0}, math53.TetraGamma(x): {1}", x, res);

            x = 12.1d;
            res = math53.pentagamma(x);
            Console.WriteLine("x: {0}, math53.PentaGamma(x): {1}", x, res);

            n = 8;
            x = 12.1d;
            res = math53.polygamma(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.PolyGamma(n, x): {2}", n, x, res);


            x = 12.1d;
            res = math53.psi_inv(x);
            Console.WriteLine("x: {0}, math53.PsiInv(x): {1}", x, res);

            x = 12.1d;
            res = math53.bateman_g(x);
            Console.WriteLine("x: {0}, math53.BatemanG(x): {1}", x, res);

            x = 12.1d;
            res = math53.logbarnes_g(x);
            Console.WriteLine("x: {0}, math53.LnBarnesG(x): {1}", x, res);



            Console.WriteLine();

        }


        public static void DemoDoubleZeta()
        {

            Console.WriteLine("Hello DemoDoubleZeta!");
            int n;
            double s, a, x, r, res;

            s = 0.75d;
            res = math53.zeta(s);
            Console.WriteLine("s: {0}, math53.Zeta(s): {1}", s, res);

            n = 5;
            res = math53.zeta_i(n);
            Console.WriteLine("n: {0}, math53.ZetaInt(n): {1}", n, res);

            s = 0.75d;
            res = math53.zeta1p(s);
            Console.WriteLine("s: {0}, math53.Zeta1p(s): {1}", s, res);

            s = 0.75d;
            res = math53.zetam1(s);
            Console.WriteLine("s: {0}, math53.Zetam1(s): {1}", s, res);

            s = 0.75d;
            res = math53.primezeta(s);
            Console.WriteLine("s: {0}, math53.PrimeZeta(s): {1}", s, res);

            s = 0.75d;
            res = math53.dirichlet_eta(s);
            Console.WriteLine("s: {0}, math53.DirichletEta(s): {1}", s, res);

            n = 5;
            res = math53.dirichlet_eta_i(n);
            Console.WriteLine("n: {0}, math53.DirichletEtaInt(n): {1}", n, res);

            s = 0.75d;
            res = math53.dirichlet_etam1(s);
            Console.WriteLine("s: {0}, math53.DirichletEtam1(s): {1}", s, res);

            s = 0.75d;
            res = math53.dirichlet_beta(s);
            Console.WriteLine("s: {0}, math53.DirichletBeta(s): {1}", s, res);

            s = 0.75d;
            res = math53.dirichlet_lambda(s);
            Console.WriteLine("s: {0}, math53.DirichletLambda(s): {1}", s, res);

            s = 0.75d;
            a = 2.1d;
            res = math53.hurwitz_zeta(s, a);
            Console.WriteLine("s: {0}, a: {1}, math53.HurwitzZeta(s, a): {2}", s, a, res);


            Console.WriteLine();


            s = 0.75d;
            x = 2.1d;
            res = math53.bose_einstein(s, x);
            Console.WriteLine("s: {0}, x: {1}, math53.BoseEinstein(s, x): {2}", s, x, res);

            s = 0.75d;
            x = 2.1d;
            res = math53.fermi_dirac(s, x);
            Console.WriteLine("s: {0}, x: {1}, math53.FermiDiracR(s, x): {2}", s, x, res);

            n = 5;
            x = 2.1d;
            res = math53.fermi_dirac(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.FermiDirac(n, x): {2}", n, x, res);


            s = 0.75d;
            res = math53.fermi_dirac_m05(s);
            Console.WriteLine("s: {0}, math53.FermiDiracm05(s): {1}", s, res);

            s = 0.75d;
            res = math53.fermi_dirac_p05(s);
            Console.WriteLine("s: {0}, math53.FermiDiracp05(s): {1}", s, res);

            s = 0.75d;
            res = math53.fermi_dirac_p15(s);
            Console.WriteLine("s: {0}, math53.FermiDiracp15(s): {1}", s, res);

            s = 0.75d;
            res = math53.fermi_dirac_p25(s);
            Console.WriteLine("s: {0}, math53.FermiDiracp25(s): {1}", s, res);

            s = 0.75d;
            x = 2.1d;
            res = math53.legendre_chi(s, x);
            Console.WriteLine("s: {0}, x: {1}, math53.LegendreChi(s, x): {2}", s, x, res);



            Console.WriteLine();

            double z;
            z = 0.5d;
            s = 0.75d;
            a = 2.1d;
            res = math53.lerch_phi(z, s, a);
            Console.WriteLine("z: {0}, s: {1},a: {2}, math53.LerchPhi(z, s, a): {3}", z, s, a, res);

            n = 5;
            x = 2.1d;
            res = math53.polylog(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Polylog(n, x): {2}", n, x, res);

            s = 0.75d;
            x = 2.1d;
            res = math53.polylog(s, x);
            Console.WriteLine("s: {0}, x: {1}, math53.PolylogR(s, x): {2}", s, x, res);

            x = 10.75d;
            res = math53.dilog(x);
            Console.WriteLine("x: {0}, math53.Dilog(x): {1}", x, res);

            x = 10.75d;
            res = math53.trilog(x);
            Console.WriteLine("x: {0}, math53.Trilog(x): {1}", x, res);

            x = 10.75d;
            res = math53.clausen2(x);
            Console.WriteLine("x: {0}, math53.Clausen2(x): {1}", x, res);

            x = 10.75d;
            res = math53.tangent_int_2(x);
            Console.WriteLine("x: {0}, math53.TangentInt2(x): {1}", x, res);

            s = 0.75d;
            x = 10.75d;
            res = math53.inverse_tan_integral(s, x);
            Console.WriteLine("s: {0}, x: {1}, math53.TangentInt(s, x): {2}", s, x, res);

            x = 10.75d;
            res = math53.lobachevsky_c(x);
            Console.WriteLine("x: {0}, math53.LobachevskyC(x): {1}", x, res);

            x = 10.75d;
            res = math53.lobachevsky_s(x);
            Console.WriteLine("x: {0}, math53.LobachevskyS(x): {1}", x, res);

            x = 10.75d;
            res = math53.harmonic(x);
            Console.WriteLine("x: {0}, math53.Harmonic(x): {1}", x, res);

            x = 0.75d;
            r = 10.75d;
            res = math53.harmonic2(x, r);
            Console.WriteLine("x: {0}, r: {1}, math53.Harmonic2(x, r): {2}", x, r, res);


            Console.WriteLine();


        }


        public static void DemoDoubleOrthogonal()
        {

            Console.WriteLine("Hello DemoDoubleOrthogonal!");
            int n, m, l;
            double r, x, a, b, res;

            n = 10;
            x = 0.75d;
            res = math53.chebyshev_t(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.ChebyshevT(n, x): {2}", n, x, res);

            n = 10;
            x = 0.75d;
            res = math53.chebyshev_u(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.ChebyshevU(n, x): {2}", n, x, res);

            n = 10;
            x = 0.75d;
            res = math53.chebyshev_v(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.ChebyshevV(n, x): {2}", n, x, res);

            n = 10;
            x = 0.75d;
            res = math53.chebyshev_w(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.ChebyshevW(n, x): {2}", n, x, res);

            // n = 10
            // x = 0.75R
            // res = math53.Chebyshev _F1(n, x)
            // Console.WriteLine("n: {0}, x: {1}, math53.ChebyshevF1(n, x): {2}", n, x, res)

            n = 10;
            a = 1.5d;
            x = 0.75d;
            res = math53.gegenbauer_c(n, a, x);
            Console.WriteLine("n: {0}, a: {1}, x: {2}, math53.GegenbauerC(n, a, x): {3}", n, a, x, res);

            n = 10;
            x = 0.75d;
            res = math53.hermite_h(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.HermiteH(n, x): {2}", n, x, res);

            n = 10;
            x = 0.75d;
            res = math53.hermite_he(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.HermiteHe(n, x): {2}", n, x, res);

            n = 10;
            a = 1.5d;
            b = 2.5d;
            x = 0.75d;
            res = math53.jacobi_p(n, a, b, x);
            Console.WriteLine("n: {0}, a: {1}, b: {2}, x: {3}, math53.JacobiP(n, a, b, x): {4}", n, a, b, x, res);

            n = 10;
            a = 1.5d;
            x = 0.75d;
            res = math53.laguerre(n, a, x);
            Console.WriteLine("n: {0}, a: {1}, x: {2}, math53.Laguerre(n, a, x): {3}", n, a, x, res);

            //n = 10;
            //x = 0.75d;
            //res = math53.laguerre_l(n, x);
            //Console.WriteLine("n: {0}, x: {1}, math53.LaguerreL(n, x): {2}", n, x, res);

            //n = 10;
            //m = 12;
            //x = 0.75d;
            //res = math53.laguerre_ass(n, m, x);
            //Console.WriteLine("n: {0}, m: {1}, x: {2}, math53.LaguerreAss(n, m, x): {3}", n, m, x, res);

            l = 10;
            x = 0.75d;
            res = math53.legendre_p(l, x);
            Console.WriteLine("l: {0}, x: {1}, math53.LegendreP(n, x): {2}", l, x, res);

            l = 10;
            x = 0.75d;
            res = math53.legendre_q(n, x);
            Console.WriteLine("l: {0}, x: {1}, math53.LegendreQ(n, x): {2}", l, x, res);

            l = 11;
            m = 13;
            x = 0.75d;
            res = math53.legendre_plm(l, m, x);
            Console.WriteLine("l: {0}, m: {1}, x: {2}, math53.LegendrePlm(l, m, x): {3}", l, m, x, res);

            l = 10;
            m = 12;
            x = 0.75d;
            res = math53.legendre_qlm(l, m, x);
            Console.WriteLine("l: {0}, m: {1}, x: {2}, math53.LegendreQlm(l, m, x): {3}", l, m, x, res);

            // MISSING: SphericalHarmonic


            l = 0;
            m = 12;
            x = 1.75d;
            res = math53.toroidal_qlm(l, m, x);
            Console.WriteLine("l: {0}, m: {1}, x: {2}, math53.ToroidalQlm(l, m, x): {3}", l, m, x, res);

            l = 1;
            m = 0;
            x = 1.75d;
            res = math53.toroidal_plm(l, m, x);
            Console.WriteLine("l: {0}, m: {1}, x: {2}, math53.ToroidalPlm(l, m, x): {3}", l, m, x, res);


            n = 10;
            x = 0.75d;
            res = math53.besselpoly(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.BesselPoly(n, x): {2}", n, x, res);


            n = 12;
            m = 10;
            r = 0.75d;
            res = math53.zernike_r(n, m, r);
            Console.WriteLine("n: {0}, m: {1}, r: {2}, math53.ZernikeR(l, m, r): {3}", n, m, r, res);


            Console.WriteLine();

        }


        public static void DemoDoubleHypergeometric()
        {
            Console.WriteLine("Hello DemoDoubleHypergeometric!");
            double a, b, c, x, k, m, v, res;

            a = 10.1d;
            b = 20.2d;
            c = 102.01d;
            x = 0.75d;
            res = math53.hyperg_2f1(a, b, c, x);
            Console.WriteLine("a: {0}, b: {1}, c: {2}, x: {3}, math53.Hyperg2F1(a, b, c, x): {4}", a, b, c, x, res);

            a = 10.1d;
            b = 20.2d;
            c = 102.01d;
            x = 0.75d;
            res = math53.hyperg_2f1r(a, b, c, x);
            Console.WriteLine("a: {0}, b: {1}, c: {2}, x: {3}, math53.Hyperg2F1r(a, b, c, x): {4}", a, b, c, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.hyperg_1f1(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.Hyperg1F1(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.hyperg_1f1r(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.Hyperg1F1r(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.hyperg_u(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.HypergU(a, b, x): {3}", a, b, x, res);

            b = 20.2d;
            x = 0.75d;
            res = math53.hyperg_0f1(b, x);
            Console.WriteLine("b: {0}, x: {1}, math53.Hyperg0F1(b, x): {2}", b, x, res);

            b = 20.2d;
            x = 0.75d;
            res = math53.hyperg_0f1r(b, x);
            Console.WriteLine("b: {0}, x: {1}, math53.Hyperg0F1r(b, x): {2}", b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = -0.75d;
            res = math53.hyperg_2f0(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.Hyperg2F0(a, b, x): {3}", a, b, x, res);

            k = 10.1d;
            m = 20.2d;
            x = 0.75d;
            res = math53.whittaker_m(k, m, x);
            Console.WriteLine("k: {0}, m: {1}, x: {2}, math53.WhittakerM(k, m, x): {3}", k, m, x, res);

            k = 10.1d;
            m = 20.2d;
            x = 0.75d;
            res = math53.whittaker_w(k, m, x);
            Console.WriteLine("k: {0}, m: {1}, x: {2}, math53.WhittakerW(k, m, x): {3}", k, m, x, res);


            //v = 20.2d;
            //x = 0.75d;
            //res = math53.cylinder_d(v, x);
            //Console.WriteLine("v: {0}, x: {1}, math53.CylinderD(v, x): {2}", v, x, res);

            //a = 20.2d;
            //x = 0.75d;
            //res = math53.cylinder_u(a, x);
            //Console.WriteLine("a: {0}, x: {1}, math53.CylinderU(a, x): {2}", a, x, res);

            //a = 5.0d;
            //x = 0.75d;
            //res = math53.cylinder_v(a, x);
            //Console.WriteLine("a: {0}, x: {1}, math53.CylinderV(a, x): {2}", a, x, res);

            v = 20.2d;
            x = 0.75d;
            res = math53.hermite_h((int)Math.Round(v), x);
            Console.WriteLine("v: {0}, x: {1}, math53.HermiteH(v, x): {2}", v, x, res);



            Console.WriteLine();

        }


        public static void DemoDoubleOther()
        {

            Console.WriteLine("Hello DemoDoubleOther!");
            int n;
            double x, y, v, q, M, e, res;

            x = 0.75d;
            y = 3.4d;
            res = math53.agm(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.Agm(x, y): {2}", x, y, res);

            n = 20;
            res = math53.bernoulli(n);
            Console.WriteLine("n: {0}, math53.Bernoulli(n): {1}", n, res);

            n = 20;
            x = 3.4d;
            res = math53.bernpoly(x, n);
            Console.WriteLine("x: {0}, y: {1}, math53.Bernpoly(n, x): {2}", x, y, res);

            x = 2.1d;
            res = math53.bring(x);
            Console.WriteLine("x: {0}, math53.Bring(x): {1}", x, res);

            x = 2.1d;
            res = math53.catalan_c(x);
            Console.WriteLine("x: {0}, math53.Catalan(x): {1}", x, res);

            n = 2;
            x = 3.4d;
            res = math53.debye(n, x);
            Console.WriteLine("x: {0}, y: {1}, math53.Debye(n, x): {2}", x, y, res);

            n = 2;
            x = 3.4d;
            res = math53.einstein(n, x);
            Console.WriteLine("x: {0}, y: {1}, math53.Einstein(n, x): {2}", x, y, res);

            n = 20;
            res = math53.eulernum(n);
            Console.WriteLine("n: {0}, math53.Euler(n): {1}", n, res);

            n = 20;
            x = 3.4d;
            res = math53.eulerpoly(x, n);
            Console.WriteLine("n: {0}, x: {1}, math53.Eulerpoly(n, x): {2}", n, x, res);

            n = 20;
            x = 3.4d;
            res = math53.expreln(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Expreln(n, x): {2}", n, x, res);

            n = 20;
            x = 3.4d;
            res = math53.fibpoly(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Fibpoly(n, x): {2}", n, x, res);

            v = 2.1d;
            x = 3.4d;
            res = math53.fibfun(v, x);
            Console.WriteLine("v: {0}, x: {1}, math53.Fibfun(v, x): {2}", v, x, res);

            n = 20;
            x = 3.4d;
            res = math53.cosint(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Cosint(n, x): {2}", n, x, res);

            n = 20;
            x = 3.4d;
            res = math53.sinint(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Sinint(n, x): {2}", n, x, res);

            x = 2.1d;
            res = math53.lambert_w0(x);
            Console.WriteLine("x: {0}, math53.LambertW0(x): {1}", x, res);

            x = -0.1d;
            res = math53.lambert_wm1(x);
            Console.WriteLine("x: {0}, math53.LambertW1(x): {1}", x, res);

            x = 2.1d;
            res = math53.langevinl(x);
            Console.WriteLine("x: {0}, math53.LangevinL(x): {1}", x, res);

            x = 0.71d;
            res = math53.langevinlinv(x);
            Console.WriteLine("x: {0}, math53.LangevinLInv(x): {1}", x, res);

            n = 20;
            x = 3.4d;
            res = math53.lucpoly(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Lucpoly(n, x): {2}", n, x, res);

            q = 0.1d;
            res = math53.euler_q(q);
            Console.WriteLine("q: {0}, math53.EulerQ(q): {1}", q, res);

            x = 210.0d;
            res = math53.riemann_r(x);
            Console.WriteLine("x: {0}, math53.RiemannR(x): {1}", x, res);

            x = 46.0d;
            res = math53.riemann_r_inv(x);
            Console.WriteLine("x: {0}, math53.RiemannRInv(x): {1}", x, res);

            q = 0.1d;
            res = math53.rogers_ramanujan_cf(q);
            Console.WriteLine("q: {0}, math53.RogersRamanujanCF(q): {1}", q, res);

            M = 0.75d;
            e = 3.4d;
            res = math53.kepler(M, e);
            Console.WriteLine("M: {0}, e: {1}, math53.Kepler(M, e): {2}", M, e, res);

            n = 3;
            x = 3.4d;
            res = math53.transport_jn(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.TransportJn(n, x): {2}", n, x, res);

            n = 3;
            x = 3.4d;
            res = math53.expn(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Expn(n, x): {2}", n, x, res);

            x = 46.1d;
            res = math53.wright_omega(x);
            Console.WriteLine("x: {0}, math53.WrightOmega(x): {1}", x, res);



            Console.WriteLine();

        }


        public static void DemoDoubleStatistical()
        {

            Console.WriteLine("Hello DemoDoubleStatistical!");
            int n, k, nu1, nu2;
            double alpha, p, r, a, b, c, x, y, res;

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.beta_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.BetaPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.beta_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.BetaCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.beta_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.BetaInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            p = 0.1d;
            n = 20;
            k = 12;
            res = math53.binomial_pmf(n, p, k);
            Console.WriteLine("p: {0}, n: {1}, k: {2}, math53.BinomialPmf(p, n, k): {3}", p, n, k, res);

            p = 0.1d;
            n = 20;
            k = 12;
            res = math53.binomial_cdf(n, p, k);
            Console.WriteLine("p: {0}, n: {1}, k: {2}, math53.BinomialCdf(p, n, k): {3}", p, n, k, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.cauchy_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.CauchyPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.cauchy_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.CauchyCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.cauchy_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.CauchyInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            n = 10;
            x = 5.75d;
            res = math53.chi_pdf(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.ChiPdf(n, x): {2}", n, x, res);

            n = 10;
            x = 5.75d;
            res = math53.chi_cdf(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.ChiCdf(n, x): {2}", n, x, res);

            n = 10;
            y = 0.95d;
            res = math53.chi_qtf(n, y);
            Console.WriteLine("n: {0}, y: {1}, math53.ChiInv(n, y): {2}", n, y, res);


            Console.WriteLine();

            n = 10;
            x = 5.75d;
            res = math53.chi2_pdf(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Chi2Pdf(n, x): {2}", n, x, res);

            n = 10;
            x = 5.75d;
            res = math53.chi2_cdf(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.Chi2Cdf(n, x): {2}", n, x, res);

            n = 10;
            y = 0.95d;
            res = math53.chi2_qtf(n, y);
            Console.WriteLine("n: {0}, y: {1}, math53.Chi2Inv(n, y): {2}", n, y, res);


            Console.WriteLine();

            a = 0.1d;
            alpha = 1.2d;
            x = 0.75d;
            res = math53.exponential_pdf(alpha, x);
            Console.WriteLine("a: {0}, alpha: {1}, x: {2}, math53.ExpPdf(a, alpha, x): {3}", a, alpha, x, res);

            a = 0.1d;
            alpha = 1.2d;
            x = 0.75d;
            res = math53.exponential_cdf(alpha, x);
            Console.WriteLine("a: {0}, alpha: {1}, x: {2}, math53.ExpCdf(a, alpha, x): {3}", a, alpha, x, res);

            a = 0.1d;
            alpha = 1.2d;
            y = 0.95d;
            res = math53.exponential_qtf(alpha, y);
            Console.WriteLine("a: {0}, alpha: {1}, y: {2}, math53.ExpInv(a, alpha, y): {3}", a, alpha, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.gumbel_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.Evt1Pdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.gumbel_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.Evt1Cdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.gumbel_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.Evt1Inv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            nu1 = 10;
            nu2 = 20;
            x = 10.75d;
            res = math53.fisher_f_pdf(nu1, nu2, x);
            Console.WriteLine("nu1: {0}, nu2: {1}, x: {2}, math53.FisherFPdf(nu1, nu2, x): {3}", nu1, nu2, x, res);

            nu1 = 10;
            nu2 = 20;
            x = 10.75d;
            res = math53.fisher_f_cdf(nu1, nu2, x);
            Console.WriteLine("nu1: {0}, nu2: {1}, x: {2}, math53.FisherFCdf(nu1, nu2, x): {3}", nu1, nu2, x, res);

            nu1 = 10;
            nu2 = 20;
            y = 0.95d;
            res = math53.fisher_f_qtf(nu1, nu2, y);
            Console.WriteLine("nu1: {0}, nu2: {1}, y: {2}, math53.FisherFInv(nu1, nu2, y): {3}", nu1, nu2, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.gamma_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.GammaPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.gamma_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.GammaCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.gamma_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.GammaInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            int n1, n2;
            n1 = 10;
            n2 = 20;
            n = 25;
            k = 8;
            res = math53.hypergeometric_pmf((ulong)n1, (ulong)n2, (ulong)n, k);
            Console.WriteLine("n1: {0}, n2: {1}, n: {2}, k: {3}, math53.HypergeoPmf(n1, n2, n, k): {4}", n1, n2, n, k, res);

            n1 = 10;
            n2 = 20;
            n = 25;
            k = 8;
            res = math53.hypergeometric_cdf((ulong)n1, (ulong)n2, (ulong)n, k);
            Console.WriteLine("n1: {0}, n2: {1}, n: {2}, k: {3}, math53.HypergeoCdf(n1, n2, n, k): {4}", n1, n2, n, k, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.inverse_gamma_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.InvGammaPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.inverse_gamma_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.InvGammaCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.inverse_gamma_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.InvGammaInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.kumaraswamy_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.KumaraswamyPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.kumaraswamy_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.KumaraswamyCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.kumaraswamy_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.KumaraswamyInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            x = 2.1d;
            res = math53.kolmogorovcdf(x);
            Console.WriteLine("x: {0}, math53.KolmogorovCdf(x): {1}", x, res);

            y = 0.95d;
            res = math53.kolmogorovinv(y);
            Console.WriteLine("y: {0}, math53.KolmogorovInv(x): {1}", y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.laplace_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.LaplacePdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.laplace_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.LaplaceCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.laplace_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.LaplaceInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.levy_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.LevyPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.levy_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.LevyCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.levy_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.LevyInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            a = 0.1d;
            k = 5;
            res = math53.logseries_pmf(a, k);
            Console.WriteLine("a: {0}, k: {1}, math53.LogseriesPmf(a, k): {2}", a, k, res);

            a = 0.1d;
            k = 5;
            res = math53.logseries_cdf(a, k);
            Console.WriteLine("a: {0}, k: {1}, math53.LogseriesCdf(a, k): {2}", a, k, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.logistic_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.LogisticPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.logistic_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.LogisticCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.logistic_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.LogisticInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.lognormal_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.LognormalPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.lognormal_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.LognormalCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.lognormal_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.LognormalInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            b = 20.2d;
            x = 0.75d;
            res = math53.maxwell_pdf(b, x);
            Console.WriteLine("b: {0}, x: {1}, math53.MaxwellPdf(b, x): {2}", b, x, res);

            b = 20.2d;
            x = 0.75d;
            res = math53.maxwell_cdf(b, x);
            Console.WriteLine("b: {0}, x: {1}, math53.MaxwellCdf(b, x): {2}", b, x, res);

            b = 20.2d;
            y = 0.95d;
            res = math53.maxwell_qtf(b, y);
            Console.WriteLine("b: {0}, y: {1}, math53.MaxwellInv(b, y): {2}", b, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.moyal_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.MoyalPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.moyal_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.MoyalCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.moyal_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.MoyalInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.nakagami_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.NakagamiPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.nakagami_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.NakagamiCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.nakagami_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.NakagamiInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            p = 0.1d;
            r = 20.0d;
            k = 12;
            res = math53.negbinomial_pmf((int)r, p, k);
            Console.WriteLine("p: {0}, r: {1}, k: {2}, math53.NegbinomPmf(p, r, k): {3}", p, r, k, res);

            p = 0.1d;
            r = 20.0d;
            k = 12;
            res = math53.negbinomial_cdf((int)r, p, k);
            Console.WriteLine("p: {0}, r: {1}, k: {2}, math53.NegbinomCdf(p, r, k): {3}", p, r, k, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.normal_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.NormalPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.normal_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.NormalCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.normal_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.NormalInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            double k1;
            k1 = 1.1d;
            a = 2.2d;
            x = 5.75d;
            res = math53.pareto_pdf(k1, a, x);
            Console.WriteLine("k1: {0}, a: {1}, x: {2}, math53.ParetoPdf(k1, a, x): {3}", k1, a, x, res);

            k1 = 1.1d;
            a = 2.2d;
            x = 5.75d;
            res = math53.pareto_cdf(k1, a, x);
            Console.WriteLine("k1: {0}, a: {1}, x: {2}, math53.ParetoCdf(k1, a, x): {3}", k1, a, x, res);

            k1 = 1.1d;
            a = 2.2d;
            y = 0.95d;
            res = math53.pareto_qtf(k1, a, y);
            Console.WriteLine("k1: {0}, a: {1}, y: {2}, math53.ParetoInv(k1, a, y): {3}", k1, a, y, res);


            Console.WriteLine();

            a = 0.1d;
            k = 5;
            res = math53.poisson_pmf(a, k);
            Console.WriteLine("a: {0}, k: {1}, math53.PoissonPmf(a, k): {2}", a, k, res);

            a = 0.1d;
            k = 5;
            res = math53.poisson_cdf(a, k);
            Console.WriteLine("a: {0}, k: {1}, math53.PoissonCdf(a, k): {2}", a, k, res);


            Console.WriteLine();

            b = 20.2d;
            x = 0.75d;
            res = math53.rayleigh_pdf(b, x);
            Console.WriteLine("b: {0}, x: {1}, math53.RayleighPdf(b, x): {2}", b, x, res);

            b = 20.2d;
            x = 0.75d;
            res = math53.rayleigh_cdf(b, x);
            Console.WriteLine("b: {0}, x: {1}, math53.RayleighCdf(b, x): {2}", b, x, res);

            b = 20.2d;
            y = 0.95d;
            res = math53.rayleigh_qtf(b, y);
            Console.WriteLine("b: {0}, y: {1}, math53.RayleighInv(b, y): {2}", b, y, res);


            Console.WriteLine();

            x = 0.75d;
            res = math53.normstd_pdf(x);
            Console.WriteLine("x: {0}, math53.NormstdPdf(b, x): {1}", x, res);

            x = 0.75d;
            res = math53.normstd_cdf(x);
            Console.WriteLine("x: {0}, math53.NormstdCdf(b, x): {1}", x, res);

            y = 0.95d;
            res = math53.normstd_qtf(y);
            Console.WriteLine("y: {0}, math53.NormstdInv(b, x): {1}", y, res);


            Console.WriteLine();

            n = 10;
            x = 5.75d;
            res = math53.student_t_pdf(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.StudentTPdf(n, x): {2}", n, x, res);

            n = 10;
            x = 5.75d;
            res = math53.student_t_cdf(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.StudentTCdf(n, x): {2}", n, x, res);

            n = 10;
            y = 0.95d;
            res = math53.student_t_qtf(n, y);
            Console.WriteLine("n: {0}, y: {1}, math53.StudentTInv(n, y): {2}", n, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            c = 15.3d;
            x = 12.75d;
            res = math53.triangular_pdf(a, b, c, x);
            Console.WriteLine("a: {0}, b: {1}, c: {2}, x: {3}, math53.TriangularPdf(a, b, c, x): {4}", a, b, c, x, res);

            a = 10.1d;
            b = 20.2d;
            c = 15.3d;
            x = 12.75d;
            res = math53.triangular_cdf(a, b, c, x);
            Console.WriteLine("a: {0}, b: {1}, c: {2}, x: {3}, math53.TriangularCdf(a, b, c, x): {4}", a, b, c, x, res);

            a = 10.1d;
            b = 20.2d;
            c = 15.3d;
            y = 0.95d;
            res = math53.triangular_qtf(a, b, c, y);
            Console.WriteLine("a: {0}, b: {1}, c: {2}, y: {3}, math53.TriangularInv(a, b, c, x): {4}", a, b, c, y, res);


            Console.WriteLine();

            a = 1.1d;
            b = 20.2d;
            x = 10.75d;
            res = math53.uniform_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.UniformPdf(a, b, x): {3}", a, b, x, res);

            a = 1.1d;
            b = 20.2d;
            x = 10.75d;
            res = math53.uniform_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.UniformCdf(a, b, x): {3}", a, b, x, res);

            a = 1.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.uniform_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.UniformInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.wald_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.WaldPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.wald_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.WaldCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.wald_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.WaldInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.weibull_pdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.WeibullPdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            x = 0.75d;
            res = math53.weibull_cdf(a, b, x);
            Console.WriteLine("a: {0}, b: {1}, x: {2}, math53.WeibullCdf(a, b, x): {3}", a, b, x, res);

            a = 10.1d;
            b = 20.2d;
            y = 0.95d;
            res = math53.weibull_qtf(a, b, y);
            Console.WriteLine("a: {0}, b: {1}, y: {2}, math53.WeibullInv(a, b, y): {3}", a, b, y, res);


            Console.WriteLine();

            a = 0.1d;
            k = 5;
            res = math53.zeta_pmf(a, k);
            Console.WriteLine("a: {0}, k: {1}, math53.ZipfPmf(a, k): {2}", a, k, res);

            a = 0.1d;
            k = 5;
            res = math53.zeta_cdf(a, k);
            Console.WriteLine("a: {0}, k: {1}, math53.ZipfCdf(a, k): {2}", a, k, res);



            Console.WriteLine();


        }



        public static void BigIntTestsNumth32()
        {
            Console.WriteLine("Hello from BigIntTestsNumth32!");
            short i16;

            i16 = math53.moebius(10);
            Console.WriteLine("i16 = math53.Moebius32(10):  {0}", i16);

            Console.WriteLine();
        }





        #region AMath Calculus


        public static void DemoDoubleToolsQuad()
        {
            double a, b, c;
            a = -13;
            b = 4.0d;
            c = 5.0d;
            var Res = math53.squadx(a, b, c);
            Console.WriteLine("Roots of Quadratic Equation: a = {0}, b = {1}, c = {2}", a, b, c);
            Console.WriteLine("Res: {0}", Res);
            Console.WriteLine();
        }

        public static void DemoDoubleToolsCube()
        {
            double a, b, c, d;
            a = -13;
            b = 4.0d;
            c = 5.0d;
            d = 1.0d;
            var Res = math53.cubsolve(a, b, c, d);
            Console.WriteLine("Roots of Cubic Equation: a = {0}, b = {1}, c = {2}, d = {3}", a, b, c, d);
            Console.WriteLine("Res: {0}", Res);
        }





        public static double F1(double x)
        {
            double y;
            y = -Math.Exp(-x * x);
            // Console.WriteLine("x : {0}, y: {1}", x, y)
            return y;
        }

        public static void DemoLocalMin()
        {
            double a = -10.0d;
            double b = 20.0d;
            double eps = 0.00000001d;
            double tol = 0.00000001d;
            var Res1 = math53.localmin(new cb1SDouble1S(F1), a, b, eps, tol);
            Console.WriteLine("Res1:(x, fx, ic) {0}", Res1);
            Console.WriteLine();
        }


        public static void DemoMBrent()
        {
            double a = -10.0d;
            double b = 20.0d;
            double tol = 0.00000001d;
            var Res2 = math53.mbrent(F1, a, b, tol);
            Console.WriteLine("Res1:(x, fx, ic) {0}", Res2);
            Console.WriteLine();
        }


        public static double F3(double x)
        {
            double y;
            y = Math.Exp(x) - 10.0d;
            // Console.WriteLine("x : {0}, y: {1}", x, y)
            return y;
        }

        public static void DemoZBrent()
        {
            int a = -20;
            int b = 10;
            double tol = 0.000000000001d;
            var Res3 = math53.zbrent(F3, a, b, tol);
            Console.WriteLine("Res3:(x, ic, err) {0}", Res3);
            Console.WriteLine();
        }

        public static void DemoZeroIn()
        {
            int a = -20;
            int b = 10;
            double tol = 0.000000000001d;
            double Res4 = math53.zeroin(F3, a, b, tol);
            Console.WriteLine("Res4:(x, ic, err) {0}", Res4);
            Console.WriteLine();
        }




        public static void DemoAmToolsMinAndRootsLambda()
        {
            double a = -10.0d;
            double b = 20.0d;
            double eps = 0.00000001d;
            double tol = 0.00000001d;
            Console.WriteLine("LocalMin: f = -Math.Exp(-x * x), a = {0}, b = {1}, eps = {2}, tol = {3}", a, b, eps, tol);
            var Res1 = math53.localmin(x => -Math.Exp(-x * x), a, b, eps, tol);
            Console.WriteLine("Res1:(x, fx, ic) {0}", Res1);
            Console.WriteLine();

            a = -10;
            b = 20.0d;
            tol = 0.000000000001d;
            Console.WriteLine("MBrent: f = -Math.Exp(-x * x), a = {0}, b = {1}, tol = {2}", a, b, tol);
            var Res2 = math53.mbrent(x => -Math.Exp(-x * x), a, b, tol);
            Console.WriteLine("Res2:(x, fx, ic) {0}", Res2);
            Console.WriteLine();

            a = -20;
            b = 10.0d;
            tol = 0.00000001d;
            Console.WriteLine("ZBrent: f = Math.Exp(x) - 10, a = {0}, b = {1}, tol = {2}", a, b, tol);
            var Res3 = math53.zbrent(x => Math.Exp(x) - 10.0d, a, b, tol);
            Console.WriteLine("Res3:(x, ic, err) {0}", Res3);
            Console.WriteLine();

            a = -20;
            b = 10.0d;
            tol = 0.00000001d;
            Console.WriteLine("ZeroIn: f = Math.Exp(x) - 10, a = {0}, b = {1}, tol = {2}", a, b, tol);
            double Res4 = math53.zeroin(x => Math.Exp(x) - 10.0d, a, b, tol);
            Console.WriteLine("Res4: {0}", Res4);
            Console.WriteLine();
        }



        public static double F4(double x)
        {
            double y;
            y = math53.student_t_pdf(10, x);
            // Console.WriteLine("x : {0}, y: {1}", x, y)
            return y;
        }

        public static void DemoQuanc8()
        {
            double a = 0.0d;
            double b = 2.0d;
            double abserr = 0.00000001d;
            double relerr = 0.00000001d;
            Console.WriteLine("quanc8: f = F4, a = {0}, b = {1}, abserr = {2}, abserr = {3}", a, b, abserr, relerr);
            var Res1 = math53.quanc8(F4, a, b, abserr, relerr);
            Console.WriteLine("Res1:(result, errest, flag, neval) {0}", Res1);
            Console.WriteLine();
        }

        public static void DemoQags()
        {
            double a = 0.0d;
            double b = 2.0d;
            double epsabs = 0.00000001d;
            double epsrel = 0.00000001d;
            int limit = 0;
            Console.WriteLine("Qags: f = F4, a = {0}, b = {1}, epsabs = {2}, epsrel = {3}, limit = {4}", a, b, epsabs, epsrel, limit);
            var Res2 = math53.qags(new cb1SDouble1S(F4), a, b, epsabs, epsrel);
            Console.WriteLine("Res2:(result, abserr, neval, ier) {0}", Res2);
            Console.WriteLine();
        }

        public static void DemoQagi()
        {
            double bound = 0.0d;
            int inf = 1;
            double epsabs = 0.00000001d;
            double epsrel = 0.00000001d;
            int limit = 0;
            Console.WriteLine("Qagi: f = F4, a = {0}, b = {1}, epsabs = {2}, epsrel = {3}, limit = {4}", bound, inf, epsabs, epsrel, limit);
            var Res3 = math53.qagi(F4, bound, inf, epsabs, epsrel);
            Console.WriteLine("Res3:(result, abserr, neval, ier) {0}", Res3);
            Console.WriteLine();
        }





        public static double F5(double x)
        {
            double y;
            y = 1.0d / (1.0d * (5.0d * x * x * x + 6.0d));
            // Console.WriteLine("x : {0}, y: {1}", x, y)
            return y;
        }

        public static void DemoQawc()
        {
            double a = -1.0d;
            double b = 5.0d;
            double c = 0.0d;
            double epsabs = 0.00001d;
            double epsrel = 0.00001d;
            int limit = 0;
            Console.WriteLine("Qawc: f = F5, a = {0}, b = {1}, c = {2}, epsabs = {3}, epsrel = {4}, limit = {5}", a, b, c, epsabs, epsrel, limit);
            var Res4 = math53.qawc(F5, a, b, c, epsabs, epsrel);
            Console.WriteLine("Res4:(result, abserr, neval, ier) {0}", Res4);
            Console.WriteLine();
        }



        public static void DemoIntde()
        {
            double a = 0.0d;
            double b = 2.0d;
            double epsabs = 0.00000001d;
            Console.WriteLine("Intde: f = F4, a = {0}, b = {1}, epsabs = {2}", a, b, epsabs);
            var Res5 = math53.intde(F4, a, b, epsabs);
            Console.WriteLine("Res5:(result, abserr, neval, ier) {0}", Res5);
            Console.WriteLine();
        }



        public static void DemoIntdei()
        {
            double a = 0.0d;
            double epsabs = 0.00000001d;
            Console.WriteLine("Intdei: f = F4, a = {0}, epsabs = {1}", a, epsabs);
            var Res6 = math53.intdei(F4, a, epsabs);
            Console.WriteLine("Res6:(result, abserr, neval, ier) {0}", Res6);
            Console.WriteLine();
        }





        public static double F6(double x)
        {
            double y;
            double alpha = 2.0d;
            y = math53.sin(x * alpha) / math53.sqrt(x);
            // Console.WriteLine("x : {0}, y: {1}", x, y)
            return y;
        }


        public static void DemoIntdeo()
        {
            double alpha = 2.0d;
            double a = 0.0d;
            double epsabs = 0.000000000001d;
            Console.WriteLine("Intdeo: f = F6, a = {0}, alpha = {1}, epsabs = {2}", a, alpha, epsabs);
            var Res7 = math53.intdeo(F6, a, alpha, epsabs);
            Console.WriteLine("Res7:(result, abserr, neval, ier) {0}", Res7);
            Console.WriteLine("Analytic: {0}", math53.sqrt(0.5d * Math.PI / alpha));
            Console.WriteLine();
        }




        public static void DemoAmToolsQuadpack()
        {
            double a = 0.0d;
            double b = 2.0d;
            double c = 0.0d;
            double abserr = 0.00000001d;
            double relerr = 0.00000001d;
            Console.WriteLine("Quanc8: f = StudentTPdf(10, x), a = {0}, b = {1}, abserr = {2}, abserr = {3}", a, b, abserr, relerr);
            var Res1 = math53.quanc8(x => math53.student_t_pdf(10, x), a, b, abserr, relerr);
            Console.WriteLine("Res1:(result, errest, flag, neval) {0}", Res1);
            Console.WriteLine();


            double epsabs = 0.00000001d;
            double epsrel = 0.00000001d;
            int limit = 0;
            a = 0.0d;
            b = 2.0d;
            Console.WriteLine("Qags: f = StudentTPdf(10, x), a = {0}, b = {1}, epsabs = {2}, epsrel = {3}, limit = {4}", a, b, epsabs, epsrel, limit);
            var Res2 = math53.qags(x => math53.student_t_pdf(10, x), a, b, epsabs, epsrel);
            Console.WriteLine("Res2:(result, abserr, neval, ier) {0}", Res2);
            Console.WriteLine();


            epsabs = 0.00000001d;
            epsrel = 0.00000001d;
            limit = 0;
            double bound = 0.0d;
            int inf = 1;
            Console.WriteLine("Qagi: f = StudentTPdf(10, x), a = {0}, b = {1}, epsabs = {2}, epsrel = {3}, limit = {4}", bound, inf, epsabs, epsrel, limit);
            var Res3 = math53.qagi(x => math53.student_t_pdf(10, x), bound, inf, epsabs, epsrel);
            Console.WriteLine("Res3:(result, abserr, neval, ier) {0}", Res3);
            Console.WriteLine();


            // Piessens, page 109
            a = -1.0d;
            b = 5.0d;
            c = 0.0d;
            epsabs = 0.00001d;
            epsrel = 0.00001d;
            limit = 0;
            Console.WriteLine("Qawc: f = 1.0/(x*(5*x*x*x + 6)), a = {0}, b = {1}, c = {2}, epsabs = {3}, epsrel = {4}, limit = {5}", a, b, c, epsabs, epsrel, limit);
            var Res4 = math53.qawc(x => 1.0d / (1.0d * (5.0d * x * x * x + 6.0d)), a, b, c, epsabs, epsrel);
            Console.WriteLine("Res4:(result, abserr, neval, ier) {0}", Res4);
            Console.WriteLine();


            a = 0.0d;
            b = 2.0d;
            epsabs = 0.00000001d;
            epsrel = 0.00000001d;
            limit = 0;
            Console.WriteLine("Intde: f = StudentTPdf(10, x), a = {0}, b = {1}, epsabs = {2}", a, b, epsabs);
            var Res5 = math53.intde(x => math53.student_t_pdf(10, x), a, b, epsabs);
            Console.WriteLine("Res5:(result, abserr, neval, ier) {0}", Res5);
            Console.WriteLine();


            a = 0.0d;
            epsabs = 0.00000001d;
            Console.WriteLine("Intdei: f = StudentTPdf(10, x), a = {0}, epsabs = {1}", a, epsabs);
            var Res6 = math53.intdei(x => math53.student_t_pdf(10, x), a, epsabs);
            Console.WriteLine("Res6:(result, abserr, neval, ier) {0}", Res6);
            Console.WriteLine();


            double alpha = 2.0d;
            a = 0.0d;
            epsabs = 0.000000000001d;
            Console.WriteLine("Intdeo: f = math53.Sin(x*alpha)/math53.Sqrt(x), a = {0}, alpha = {1}, epsabs = {2}", a, alpha, epsabs);
            var Res7 = math53.intdeo(x => math53.sin(x * alpha) / math53.sqrt(x), a, alpha, epsabs);
            Console.WriteLine("Res7:(result, abserr, neval, ier) {0}", Res7);
            Console.WriteLine("Analytic: {0}", math53.sqrt(0.5d * Math.PI / alpha));
            Console.WriteLine();

        }


        public static void DemoAMathCalculus()
        {
            DemoDoubleToolsQuad();
            DemoDoubleToolsCube();

            DemoLocalMin();
            DemoMBrent();
            DemoZBrent();
            DemoZeroIn();

            DemoAmToolsMinAndRootsLambda();

            DemoQuanc8();
            DemoQags();
            DemoQagi();
            DemoQawc();
            DemoIntde();
            DemoIntdei();
            DemoIntdeo();

            DemoAmToolsQuadpack();
        }



        #endregion





        #region Boost Calculus


        public static double F10(double x)
        {
            double fx;
            fx = x * x * x - 27.0d;
            // Console.WriteLine("In F1: x: {0}, f(x): {1}", x, fx)
            return fx;
        }


        public static double DF10(double x)
        {
            double df1x;
            df1x = 3.0d * x * x;
            // Console.WriteLine("In DF1: x: {0}, df1(x): {1}", x, df1x)
            return df1x;
        }


        public static double D2F10(double x)
        {
            double df2x;
            df2x = 6.0d * x;
            // Console.WriteLine("In DF2: x: {0}, df2(x): {1}", x, df2x)
            return df2x;
        }


        public static double F12(double x)
        {
            double fx;
            fx = (x + 3.0d) * (x - 1.0d) * (x - 1.0d);
            // Console.WriteLine("In F2: x: {0}, f(x): {1}", x, fx)
            return fx;
        }






        public static double F13(double x)
        {
            double fx;
            fx = 1.0d / (5.0d - 4.0d * math53.cos(x));
            // Console.WriteLine("In F3: x: {0}, f(x): {1}", x, fx)
            return fx;
        }


        public static double F14(double x)
        {
            double fx;
            fx = x * x * math53.atan(x);
            // Console.WriteLine("In F4: x: {0}, f(x): {1}", x, fx)
            return fx;
        }


        public static double F15(double x)
        {
            double fx;
            fx = math53.exp(-x * x / 2.0d);
            // Console.WriteLine("In F5: x: {0}, f(x): {1}", x, fx)
            return fx;
        }


        public static double F16(double x)
        {
            double fx;
            fx = 5.0d * x + 7.0d;
            // Console.WriteLine("In F6: x: {0}, f(x): {1}", x, fx)
            return fx;
        }


        public static double F17(double x)
        {
            double fx;
            fx = math53.exp(-x * x);
            // Console.WriteLine("In F7: x: {0}, f(x): {1}", x, fx)
            return fx;
        }


        public static double F18(double x)
        {
            double fx;
            fx = math53.exp(-3 * x);
            // Console.WriteLine("In F8: x: {0}, f(x): {1}", x, fx)
            return fx;
        }



        public static double F19(double x)
        {
            double fx;
            fx = 1.0d / (x * x + 1.0d);
            // Console.WriteLine("In F8: x: {0}, f(x): {1}", x, fx)
            return fx;
        }



        public static double F20(double x)
        {
            double fx;
            fx = 1.0d / x;
            // Console.WriteLine("In F8: x: {0}, f(x): {1}", x, fx)
            return fx;
        }






        #endregion




        public static void RunTestsFReal()
        {
            //TestRawOperations();
            //TestFRealRawOperations2();

            //DemoDoubleElementary1();
            //DemoDoubleElementary2();
            //DemoDoubleElementary3();
            //DemoDoubleBessel();
            //DemoDoubleEllipticIntegrals();
            //DemoDoubleErrorFunction();
            //DemoDoubleExponentialIntegral();
            //DemoDoubleGamma();
            //DemoDoubleZeta();
            //DemoDoubleOrthogonal();
            //DemoDoubleHypergeometric();
            //DemoDoubleStatistical();
            //DemoDoubleOther();
            //BigIntTestsNumth32();

            DemoAMathCalculus();
        }



        public static void Test_Math53()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTestsFReal();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10.0d);
            Console.WriteLine("Elapsed Time " + elapsedTime);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Memory used before collection:       {0:N0}", GC.GetTotalMemory(false));
            GC.Collect();
            Console.WriteLine("Memory used after full collection:   {0:N0}", GC.GetTotalMemory(true));
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("");
        }




    }
}