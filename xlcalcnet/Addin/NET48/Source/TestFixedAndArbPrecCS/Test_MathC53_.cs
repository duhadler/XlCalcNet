using System;
using System.Diagnostics;
using System.Numerics;
using FixedPrecNet;

namespace TestXlCalcNetPrecCS
{




    internal static class TestmathC53
    {



        public static void TestComplex1()
        {
            Console.WriteLine("Hello TestComplex1");
            // int i1 = 3
            double d1 = 8.34d;
            var z1 = new Complex(8.34d, 1.23d);
            var z2 = new Complex(2.79d, 3.86d);
            var i = Complex.ImaginaryOne;
            Console.WriteLine("z1: {0}", z1);
            Console.WriteLine("z2: {0}", z2);
            Console.WriteLine();


            double d3 = Complex.Abs(z1);
            double d4 = cmath53.abs(z1);
            Console.WriteLine("d3 = Complex.Abs(z1): {0}", d3);
            Console.WriteLine("d4 =  mathC53.Abs(z1): {0}", d4);
            Console.WriteLine();

            var z3 = z1 + z2;
            Console.WriteLine("z3 = z1 + z2            : {0}", z3);
            z3 = Complex.Add(z1, z2);
            Console.WriteLine("z3 = Complex.Add(z1, z2): {0}", z3);
            // Dim z4 = mathC53.Add(z1, z2)
            // Console.WriteLine("z4 =  mathC53.Add(z1, z2): {0}", z4)
            // Console.WriteLine()

            d3 = z1.Phase;
            d4 = cmath53.phase(z1);
            Console.WriteLine("d3 = z1.Phase:       {0}", d3);
            Console.WriteLine("d4 = mathC53.Arg(z1): {0}", d4);
            Console.WriteLine();

            Complex z4; 

            //z3 = Complex.Exp(d1 * i);
            //var z4 = cmath53.expj(d1);
            //Console.WriteLine("Complex.Exp(d1 * i): {0}", z3);
            //Console.WriteLine("mathC53.Cis(d1)                        : {0}", z4);
            //Console.WriteLine();

            z3 = Complex.Conjugate(z1);
            z4 = cmath53.conj(z1);
            Console.WriteLine("z3 = Complex.Conjugate(z1): {0}", z3);
            Console.WriteLine("z4 = mathC53.Conjugate(z1) : {0}", z4);
            Console.WriteLine();

            z3 = z1 / z2;
            Console.WriteLine("z3 = z1 / z2               : {0}", z3);
            z3 = Complex.Divide(z1, z2);
            Console.WriteLine("z3 = Complex.Divide(z1, z2): {0}", z3);
            // z4 = cmath53.Divide(z1, z2)
            // Console.WriteLine("z4 =  mathC53.Div(z1, z2)   : {0}", z4)
            // Console.WriteLine()

            z3 = Complex.Reciprocal(z1);
            // z4 = cmath53.Reciprocal(z1)
            // Console.WriteLine("z3 = Complex.Reciprocal(z1): {0}", z3)
            // Console.WriteLine("z4 =  mathC53.Reciprocal(z1):        {0}", z4)
            // Console.WriteLine()

            z3 = z1 * z2;
            Console.WriteLine("z3 = z1 * z2                 : {0}", z3);
            z3 = Complex.Multiply(z1, z2);
            Console.WriteLine("z3 = Complex.Multiply(z1, z2): {0}", z3);
            // z4 = cmath53.Multiply(z1, z2)
            // Console.WriteLine("z4 =  mathC53.Multiply(z1, z2)     : {0}", z4)
            // Console.WriteLine()

            z3 = Complex.Negate(z1);
            // z4 = cmath53.Neg(z1)
            // Console.WriteLine("z3 = Complex.Negate(z1): {0}", z3)
            // Console.WriteLine("z4 =  mathC53.Neg(z1):    {0}", z4)
            // Console.WriteLine()

            //cmath53.polar(z1, ref d3, ref d4);
            //Console.WriteLine("Complex.Polar(z1, d3, d4), d3: {0}", d3);
            //Console.WriteLine("Complex.Polar(z1, d3, d4), d4: {0}", d4);
            //Console.WriteLine();
            // 
            // z3 = Complex.Pow(z1, i1)
            // Console.WriteLine("z3 = Complex.Pow(z1, i1) : {0}", z3)
            // z4 = mathC53.Powi(z1, i1)
            // Console.WriteLine("z4 =  mathC53.Powi(z1, i1): {0}", z4)
            // Console.WriteLine()


            z3 = d1 / z2;
            Console.WriteLine("z3 = d1 / z2               : {0}", z3);
            z3 = Complex.Divide(d1, z2);
            Console.WriteLine("z3 = Complex.Divide(d1, z2): {0}", z3);
            // z4 = cmath53.Rdivc(d1, z2)
            // Console.WriteLine("z4 =   mathC53.Rdivc(d1, z2): {0}", z4)
            // Console.WriteLine()
            // 
            z3 = z1 * z1;
            z4 = cmath53.sqr(z1);
            Console.WriteLine("z3 = z1 * z1       : {0}", z3);
            Console.WriteLine("z4 = mathC53.Sqr(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Sqrt(z1);
            Console.WriteLine("z3 = Complex.Sqrt(z1): {0}", z3);
            z4 = cmath53.sqrt(z1);
            Console.WriteLine("z4 =  mathC53.Sqrt(z1): {0}", z4);
            // z4 = flintc53.sqrt(z1)
            // Console.WriteLine("z4 =  flintc53.Sqrt(z1): {0}", z4)
            Console.WriteLine();

            z3 = Complex.Sqrt(1 - z1 * z1);
            z4 = cmath53.sqrt1mz2(z1);
            Console.WriteLine("z3 = Complex.Sqrt(1 - z1 * z1): {0}", z3);
            Console.WriteLine("z4 = mathC53.Sqrt1mz2(z1)      : {0}", z4);
            Console.WriteLine();

            z3 = z1 - z2;
            Console.WriteLine("z3 = z1 - z2                 : {0}", z3);
            z3 = Complex.Subtract(z1, z2);
            Console.WriteLine("z3 = Complex.Subtract(z1, z2): {0}", z3);
            // z4 = cmath53.Subtract(z1, z2)
            // Console.WriteLine("z4 =  mathC53.Subtract(z1, z2): {0}", z4)
            // Console.WriteLine()
        }


        public static void TestComplex2()
        {
            Console.WriteLine("Hello TestComplex2");
            // int i1 = 3
            double d1 = 8.34d;
            var z1 = new Complex(8.34d, 1.23d);
            var z2 = new Complex(2.79d, 3.86d);
            var i = Complex.ImaginaryOne;
            Console.WriteLine("z1: {0}", z1);
            Console.WriteLine("z2: {0}", z2);
            Console.WriteLine();


            var z4 = cmath53.agm(z1, z2);
            Console.WriteLine("z4 =  mathC53.Agm(z1, z2): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.agm1(z1);
            int z5 = 4;
            Console.WriteLine("z4 = mathC53.Agm1(z1): {0}", z4);
            Console.WriteLine();
            // 
            var z3 = Complex.Acos(z1);
            z4 = cmath53.acos(z1);
            Console.WriteLine("z3 = Complex.Acos(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Acos(z1): {0}", z4);
            Console.WriteLine();
            // 
            z4 = cmath53.acosh(z1);
            Console.WriteLine("z4 =  mathC53.Acosh(z1):  {0}", z4);
            Console.WriteLine();

            z4 = cmath53.acot(z1);
            Console.WriteLine("z4 =  mathC53.Acot(z1):  {0}", z4);
            Console.WriteLine();

            z3 = 0.5d * Math.PI - Complex.Atan(z1);
            z4 = cmath53.acotc(z1);
            Console.WriteLine("z3  0.5 * Math.PI - Complex.Atan(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Acotc(z1):               {0}", z4);
            Console.WriteLine();

            z4 = cmath53.acoth(z1);
            Console.WriteLine("z4 =  mathC53.Acoth(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Atan(i * z1) / i + i * Math.PI / 2;
            z4 = cmath53.acothc(z1);
            Console.WriteLine("z3 = Complex.Atan(i*z1) / i + i * Math.PI/2:   {0}", z3);
            Console.WriteLine("z4 =  mathC53.Acothc(z1):                       {0}", z4);
            Console.WriteLine();

            z4 = cmath53.acsc(z1);
            Console.WriteLine("z4 =  mathC53.Acsc(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.acsch(z1);
            Console.WriteLine("z4 =  mathC53.Acsch(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.asec(z1);
            Console.WriteLine("z4 =  mathC53.Asec(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.asech(z1);
            Console.WriteLine("z4 =  mathC53.Asech(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Asin(z1);
            z4 = cmath53.asin(z1);
            Console.WriteLine("z3 = Complex.Asin(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Asin(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.asinh(z1);
            Console.WriteLine("z4 =  mathC53.Asinh(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Atan(z1);
            z4 = cmath53.atan(z1);
            Console.WriteLine("z3 = Complex.Atan(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Atan(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.atanh(z1);
            Console.WriteLine("z4 =  mathC53.Atanh(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.cbrt(z1);
            Console.WriteLine("z4 =  mathC53.Cbrt(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.jacobi_cn(z1, k: 2.0d);
            Console.WriteLine("z4 =  mathC53.Cn(z1, k:=2): {0}", z4);
            Console.WriteLine("Missing");
            Console.WriteLine();

            z3 = Complex.Cos(z1);
            z4 = cmath53.cos(z1);
            Console.WriteLine("z3 = Complex.Cos(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Cos(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Cosh(z1);
            z4 = cmath53.cosh(z1);
            Console.WriteLine("z3 = Complex.Cosh(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Cosh(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.cot(z1);
            Console.WriteLine("z4 =  mathC53.Cot(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.coth(z1);
            Console.WriteLine("z4 =  mathC53.Coth(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.csc(z1);
            Console.WriteLine("z4 =  mathC53.Csc(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.csch(z1);
            Console.WriteLine("z4 =  mathC53.Csch(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.dilog(z1);
            Console.WriteLine("z4 =  mathC53.Dilog(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.jacobi_dn(z1, k: 2.0d);
            Console.WriteLine("z4 =  mathC53.Dn(z1, k:=2): {0}", z4);
            Console.WriteLine("Missing");
            Console.WriteLine();

            z4 = cmath53.exp_integral_e1(z1);
            Console.WriteLine("z4 =  mathC53.E1(z1): {0}", z4);
            Console.WriteLine("Missing");
            Console.WriteLine();

            z4 = cmath53.exp_integral_ei(z1);
            Console.WriteLine("z4 =  mathC53.Ei(z1): {0}", z4);
            Console.WriteLine();

            // z4 = cmath53.Ellck(z1)
            // Console.WriteLine("z4 =  mathC53.Ellck(z1): {0}", z4)
            // Console.WriteLine()

            z4 = cmath53.elliptic_e(z1);
            Console.WriteLine("z4 =  mathC53.Elle(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.elliptic_k(z1);
            Console.WriteLine("z4 =  mathC53.Ellk(z1): {0}", z4);
            Console.WriteLine();

            // !!! MISSING: Ellke !!!


            z4 = cmath53.erf(z1);
            Console.WriteLine("z4 =  mathC53.Erf(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.erfc(z1);
            Console.WriteLine("z4 =  mathC53.Erfc(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Exp(z1);
            z4 = cmath53.exp(z1);
            Console.WriteLine("z3 = Complex.Exp(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Exp(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.exp2(z1);
            Console.WriteLine("z4 =  mathC53.Exp2(z1): {0}", z4);
            Console.WriteLine("z5 =     xpc.exp2(z1): {0}", z5);
            Console.WriteLine();

            z4 = cmath53.exp10(z1);
            Console.WriteLine("z4 =  mathC53.Exp10(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.expm1(z1);
            Console.WriteLine("z4 =  mathC53.Expm1(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.gamma(z1);
            Console.WriteLine("z4 =  mathC53.Gamma(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.lambert_w0(z1);
            Console.WriteLine("z4 =  mathC53.LambertW(z1): {0}", z4);
            Console.WriteLine("z5 =  xpc.lambertw(z1, 0): {0}", z5);
            Console.WriteLine();

            z4 = cmath53.lambert_wk(z1, 2);
            Console.WriteLine("z4 =  mathC53.LambertW(2, z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.log_integral(z1);
            Console.WriteLine("z4 =  mathC53.Li(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Log(z1);
            z4 = cmath53.log(z1);
            Console.WriteLine("z3 = Complex.Log(z1): {0}", z3);
            Console.WriteLine("z4 =   mathC53.Ln(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.log1p(z1);
            Console.WriteLine("z4 =  mathC53.Ln1p(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.lgamma(z1);
            Console.WriteLine("z4 =  mathC53.Lngamma(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Log10(z1);
            z4 = cmath53.log10(z1);
            Console.WriteLine("z3 = Complex.Log10(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Log10(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.logbase(z1, z2);
            // Console.WriteLine("z3 = Complex.Log(z2) / Complex.Log(z1): {0}", z3)
            Console.WriteLine("z4 = mathC53.Logbase(z1, z2):            {0}", z4);
            Console.WriteLine();

            z4 = cmath53.root_si(z1, 3);
            Console.WriteLine("z4 = mathC53.root_si(z1, 3): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Exp(2.0d * Math.PI * i / 3.0d);
            z4 = cmath53.nroot1(3);
            Console.WriteLine("z3 = Complex.Exp(2 * Math.PI * i / 3.0): {0}", z3);
            Console.WriteLine("z4 = mathC53.Nroot1(3):    {0}", z4);
            Console.WriteLine();

            z3 = Complex.Pow(z1, z2);
            z4 = cmath53.pow(z1, z2);
            Console.WriteLine("z3 = Complex.Pow(z1, z2): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Pow(z1, z2): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Pow(z1, d1);
            // z4 = cmath53.Powx(z1, d1)
            Console.WriteLine("z3 = Complex.Pow(z1, d1): {0}", z3);
            // Console.WriteLine("z4 = mathC53.Powx(z1, d1): {0}", z4)
            Console.WriteLine();

            z4 = cmath53.digamma(z1);
            Console.WriteLine("z4 =  mathC53.digamma(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.rgamma(z1);
            Console.WriteLine("z4 =  mathC53.Rgamma(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.hardy_theta(z1);
            Console.WriteLine("z4 =  mathC53.HardyTheta(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.sec(z1);
            Console.WriteLine("z4 =  mathC53.Sec(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.sech(z1);
            Console.WriteLine("z4 =  mathC53.Sech(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Sin(z1);
            z4 = cmath53.sin(z1);
            Console.WriteLine("z3 = Complex.Sin(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Sin(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Sinh(z1);
            z4 = cmath53.sinh(z1);
            Console.WriteLine("z3 = Complex.Sinh(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Sinh(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.sinpi(z1);
            Console.WriteLine("z4 =  mathC53.Sinpi(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.jacobi_sn(z1, k: 2.0d);
            Console.WriteLine("z4 =  mathC53.Sn(z1, k:=2): {0}", z4);
            Console.WriteLine("Missing");
            Console.WriteLine();

            z3 = Complex.Pow(z1, 1.0d / 3.0d);
            z4 = cmath53.surd(z1, 3);
            Console.WriteLine("z3 = Complex.Pow(z1, 1.0/3.0): {0}", z3);
            Console.WriteLine("z4 = mathC53.Surd(z1, 3):       {0}", z4);
            Console.WriteLine();

            z3 = Complex.Tan(z1);
            z4 = cmath53.tan(z1);
            Console.WriteLine("z3 = Complex.Tan(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Tan(z1): {0}", z4);
            Console.WriteLine();

            z3 = Complex.Tanh(z1);
            z4 = cmath53.tanh(z1);
            Console.WriteLine("z3 = Complex.Tanh(z1): {0}", z3);
            Console.WriteLine("z4 =  mathC53.Tanh(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.zeta(z1);
            Console.WriteLine("z4 =  mathC53.Zeta(z1): {0}", z4);
            Console.WriteLine();



            z4 = cmath53.erf(z1);
            Console.WriteLine("z4 =  mathC53.Erf(z1): {0}", z4);
            Console.WriteLine();

            z4 = cmath53.erfc(z1);
            Console.WriteLine("z4 =  mathC53.Erfc(z1): {0}", z4);
            Console.WriteLine();





            z4 = cmath53.elliptic_rc(z1, z2);
            Console.WriteLine("z4 =  mathC53.EllintRC(z1, z2): {0}", z4);
            // z4 = flintc53.elliptic_rc(z1, z2)
            // Console.WriteLine("z4 =  flintc53.elliptic_rc(z1, z2): {0}", z4)

            Console.WriteLine();


            z4 = cmath53.elliptic_rd(z1, z2, 2 * z2);
            Console.WriteLine("z4 =  mathC53.elliptic_rd(z1, z2, 2 * z2): {0}", z4);
            // z4 = flintc53.elliptic_rd(z1, z2, 2 * z2)
            // Console.WriteLine("z4 =  flintc53.elliptic_rd(z1, z2, 2 * z2): {0}", z4)

            Console.WriteLine();


            z4 = cmath53.elliptic_rf(z1, z2, 2 * z2);
            Console.WriteLine("z4 =  mathC53.elliptic_rf(z1, z2, 2 * z2): {0}", z4);
            // z4 = flintc53.elliptic_rf(z1, z2, 2 * z2)
            // Console.WriteLine("z4 =  flintc53.elliptic_rf(z1, z2, 2 * z2): {0}", z4)

            Console.WriteLine();


            z4 = cmath53.elliptic_rg(z1, z2, 2 * z2);
            Console.WriteLine("z4 =  mathC53.elliptic_rg(z1, z2, 2 * z2): {0}", z4);
            // z4 = flintc53.elliptic_rg(z1, z2, 2 * z2)
            // Console.WriteLine("z4 =  flintc53.elliptic_rg(z1, z2, 2 * z2): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.elliptic_rj(z1, z2, 2 * z2, 3 * z2);
            Console.WriteLine("z4 =  mathC53.elliptic_rj(z1, z2, 2 * z2, 3 * z2): {0}", z4);
            // z4 = flintc53.elliptic_rj(z1, z2, 2 * z2, 3 * z2)
            // Console.WriteLine("z4 =  flintc53.elliptic_rj(z1, z2, 2 * z2, 3 * z2): {0}", z4)
            Console.WriteLine();





            z4 = cmath53.faddeeva(z1);
            Console.WriteLine("z4 =  mathC53.FaddeevaW(z1): {0}", z4);
            Console.WriteLine();


            z4 = cmath53.erfcx(z1);
            Console.WriteLine("z4 =  mathC53.Erfcx(z1): {0}", z4);
            Console.WriteLine();


            z4 = cmath53.Erf_Xsf(z1);
            Console.WriteLine("z4 =  mathC53.Erf_Xsf(z1): {0}", z4);
            Console.WriteLine();


            z4 = cmath53.Erfc_Xsf(z1);
            Console.WriteLine("z4 =  mathC53.Erfc_Xsf(z1): {0}", z4);
            Console.WriteLine();


            z4 = cmath53.dawson(z1);
            Console.WriteLine("z4 =  mathC53.Dawson(z1): {0}", z4);
            Console.WriteLine();




            //z4 = cmath53.bessel_jve(2.0d, z1);
            //Console.WriteLine("z4 =  mathC53.bessel_jv_scaled(2, z1): {0}", z4);
            //Console.WriteLine();


            //z4 = cmath53.bessel_yve(2.0d, z1);
            //Console.WriteLine("z4 =  mathC53.bessel_yv_scaled(2, z1): {0}", z4);
            //Console.WriteLine();


            //z4 = cmath53.bessel_ive(2.0d, z1);
            //Console.WriteLine("z4 =  mathC53.bessel_iv_scaled(2, z1): {0}", z4);
            //// z4 = flintc53.bessel_iv_scaled(2, z1)  ' not done yet
            //// Console.WriteLine("z4 =  flintc53.bessel_iv_scaled(2, z1): {0}", z4)
            //Console.WriteLine();


            //z4 = cmath53.bessel_kve(2.0d, z1);
            //Console.WriteLine("z4 =  mathC53.bessel_kv_scaled(2, z1): {0}", z4);
            //// z4 = flintc53.bessel_kv_scaled(2, z1)  ' not done yet
            //// Console.WriteLine("z4 =  flintc53.bessel_kv_scaled(2, z1): {0}", z4)
            //Console.WriteLine();


            //z4 = cmath53.Hankel1Scaled(2.0d, z1);
            //Console.WriteLine("z4 =  mathC53.Hankel1e(2, z1): {0}", z4);
            //Console.WriteLine();


            //z4 = cmath53.Hankel2Scaled(2.0d, z1);
            //Console.WriteLine("z4 =  mathC53.Hankel2e(2, z1): {0}", z4);
            //Console.WriteLine();




            z4 = cmath53.bessel_jv(2.0d, z1);
            Console.WriteLine("z4 =  mathC53.BesselJ(2, z1): {0}", z4);
            // z4 = flintc53.bessel_jv(2, z1)
            // Console.WriteLine("z4 =  flintc53.BesselJ(2, z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.bessel_yv(2.0d, z1);
            Console.WriteLine("z4 =  mathC53.BesselY(2, z1): {0}", z4);
            // z4 = flintc53.bessel_yv(2, z1)
            // Console.WriteLine("z4 =  flintc53.BesselY(2, z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.bessel_iv(2.0d, z1);
            Console.WriteLine("z4 =  mathC53.BesselI(2, z1): {0}", z4);
            // z4 = flintc53.bessel_iv(2, z1)
            // Console.WriteLine("z4 =  flintc53.BesselI(2, z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.bessel_kv(2.0d, z1);
            Console.WriteLine("z4 =  mathC53.BesselK(2, z1): {0}", z4);
            // z4 = flintc53.bessel_kv(2, z1)
            // Console.WriteLine("z4 =  flintc53.bessel_kv(2, z1): {0}", z4)
            Console.WriteLine();


            //z4 = cmath53.Hankel1(2.0d, z1);
            //Console.WriteLine("z4 =  mathC53.Hankel1(2, z1): {0}", z4);
            //Console.WriteLine();


            //z4 = cmath53.Hankel2(2.0d, z1);
            //Console.WriteLine("z4 =  mathC53.Hankel2(2, z1): {0}", z4);
            //Console.WriteLine();




            z4 = cmath53.airy_ai(z1);
            Console.WriteLine("z4 =  mathC53.airy_ai(z1): {0}", z4);
            // z4 = flintc53.airy_ai(z1)
            // Console.WriteLine("z4 =  flintc53.airy_ai(z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.airy_bi(z1);
            Console.WriteLine("z4 =  mathC53.airy_bi(z1): {0}", z4);
            // z4 = flintc53.airy_bi(z1)
            // Console.WriteLine("z4 =  flintc53.airy_bi(z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.airy_ai_scaled(z1);
            Console.WriteLine("z4 =  mathC53.airy_ai_scaled(z1): {0}", z4);
            Console.WriteLine();


            z4 = cmath53.airy_bi_scaled(z1);
            Console.WriteLine("z4 =  mathC53.airy_bi_scaled(z1): {0}", z4);
            Console.WriteLine();




            z4 = cmath53.airy_ai_prime(z1);
            Console.WriteLine("z4 =  mathC53.airy_ai_prime(z1): {0}", z4);
            // z4 = flintc53.airy_ai_prime(z1)
            // Console.WriteLine("z4 =  flintc53.airy_ai_prime(z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.airy_bi_prime(z1);
            Console.WriteLine("z4 =  mathC53.airy_bi_prime(z1): {0}", z4);
            // z4 = flintc53.airy_bi_prime(z1)
            // Console.WriteLine("z4 =  flintc53.AiryBiPrime(z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.airy_ai_scaled_prime(z1);
            Console.WriteLine("z4 =  mathC53.airy_ai_scaled_prime(z1): {0}", z4);
            Console.WriteLine();


            z4 = cmath53.airy_bi_scaled_prime(z1);
            Console.WriteLine("z4 =  mathC53.airy_bi_scaled_prime(z1): {0}", z4);
            Console.WriteLine();




            z4 = cmath53.CerfSF(z1);
            Console.WriteLine("z4 =  mathC53.CerfSF(z1): {0}", z4);
            // z4 = flintc53.erf(z1)
            // Console.WriteLine("z4 =  flintc53.erf(z1): {0}", z4)
            Console.WriteLine();




            z4 = cmath53.fresnel_s(z1);
            Console.WriteLine("z4 =  mathC53.fresnel_s(z1): {0}", z4);
            // z4 = flintc53.fresnel_s(z1)
            // Console.WriteLine("z4 =  flintc53.fresnel_s(z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.fresnel_c(z1);
            Console.WriteLine("z4 =  mathC53.fresnel_c(z1): {0}", z4);
            // z4 = flintc53.fresnel_c(z1)
            // Console.WriteLine("z4 =  flintc53.fresnel_c(z1): {0}", z4)
            Console.WriteLine();



            z4 = cmath53.sin_integral(z1);
            Console.WriteLine("z4 =  mathC53.sin_integral(z1): {0}", z4);
            // z4 = flintc53.sin_integral(z1)
            // Console.WriteLine("z4 =  flintc53.sin_integral(z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.cos_integral(z1);
            Console.WriteLine("z4 =  mathC53.Cos_Integral(z1): {0}", z4);
            // z4 = flintc53.cos_integral(z1)
            // Console.WriteLine("z4 =  flintc53.cos_integral(z1): {0}", z4)
            Console.WriteLine();





            z4 = cmath53.hyperg_2f1(1.1d, 2.2d, 3.3d, z1);
            Console.WriteLine("z4 =  mathC53.hyperg_2f1(1.1, 2.2, 3.3, z1): {0}", z4);
            // z4 = flintc53.hyperg_2f1(1.1, 2.2, 3.3, z1)
            // Console.WriteLine("z4 =  flintc53.hyperg_2f1(1.1, 2.2, 3.3, z1): {0}", z4)
            Console.WriteLine();


            ////z4 = cmath53.Hypergeom2F1SF(1.1d, 2.2d, 3.3d, z1);
            ////Console.WriteLine("z4 =  mathC53.Hypergeo2F1SF(1.1, 2.2, 3.3, z1): {0}", z4);
            ////// z4 = flintc53.hyperg_2f1(1.1, 2.2, 3.3, z1)
            ////// Console.WriteLine("z4 =  flintc53.hyperg_2f1(1.1, 2.2, 3.3, z1): {0}", z4)
            ////Console.WriteLine();


            z4 = cmath53.hyperg_1f1(1.1d, 2.2d, z1);
            Console.WriteLine("z4 =  mathC53.hyperg_1f1(1.1, 2.2, z1): {0}", z4);
            // z4 = flintc53.hyperg_1f1(1.1, 2.2, z1)
            // Console.WriteLine("z4 =  flintc53.hyperg_1f1(1.1, 2.2, z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.hyperg_u(1.1d, 2.2d, z1);
            Console.WriteLine("z4 =  mathC53.hyperg_u(1.1, 2.2, z1): {0}", z4);
            // z4 = flintc53.hyperg_u(1.1, 2.2, z1)
            // Console.WriteLine("z4 =  flintc53.hyperg_u(1.1, 2.2, z1): {0}", z4)
            Console.WriteLine();


            z4 = cmath53.hyperg_0f1(2.2d, z1);
            Console.WriteLine("z4 =  mathC53.hyperg_0f1(2.2, z1): {0}", z4);
            // z4 = flintc53.hyperg_0f1(2.2, z1)
            // Console.WriteLine("z4 =  flintc53.hyperg_0f1(2.2, z1): {0}", z4)
            Console.WriteLine();

        }


        public static void TestComplex3()
        {

            var phi = new Complex(-1.2d, 4.1d);
            var m = new Complex(1.2d, 4.3d);

            var res1 = EllipticFunctions.EllipticF(phi, m);
            Console.WriteLine("res1 = EllipticFunctions.ellipticF(phi, m): {0}", res1);
            Console.WriteLine();

            // Dim res2 = flintc53.m_elliptic_f(phi, m)
            // Console.WriteLine("res2 = flintc53.m_elliptic_f(phi, m): {0}", res2)
            Console.WriteLine();


            phi = new Complex(1.2d, 4.1d);
            m = new Complex(1.2d, 4.3d);

            res1 = EllipticFunctions.EllipticF(phi, m);
            Console.WriteLine("res1 = EllipticFunctions.ellipticF(phi, m): {0}", res1);
            Console.WriteLine();

            // res2 = flintc53.m_elliptic_f(phi, m)
            // Console.WriteLine("res2 = flintc53.m_elliptic_f(phi, m): {0}", res2)
            Console.WriteLine();

            int n0 = 2;
            phi = new Complex(1.2d + n0 * Math.PI, 4.1d);
            m = new Complex(1.2d, 4.3d);

            var res0 = EllipticFunctions.EllipticK(m);
            Console.WriteLine("res1 = EllipticFunctions.ellipticK(m): {0}", res0);
            Console.WriteLine();

            res1 = EllipticFunctions.EllipticF(phi, m);
            Console.WriteLine("res1 = EllipticFunctions.ellipticF(phi, m): {0}", res1);
            Console.WriteLine();

            // res2 = flintc53.m_elliptic_f(phi, m)
            // Console.WriteLine("res2 = flintc53.m_elliptic_f(phi, m): {0}", res2)
            Console.WriteLine();




            var z1 = new Complex(-1.2d, 4.1d);
            double g2 = 2.2d;
            double g3 = 3.2d;

            var z4 = cmath53.WeierstrassP(g2, g3, z1);
            Console.WriteLine("z4 = mathC53.WeierstrassP(g2, g3, z1): {0}", z4);

            z4 = cmath53.WeierstrassPPrime(g2, g3, z1);
            Console.WriteLine("z4 = mathC53.WeierstrassPPrime(g2, g3, z1): {0}", z4);

            z4 = cmath53.WeierstrassZeta(g2, g3, z1);
            Console.WriteLine("z4 = mathC53.WeierstrassZeta(g2, g3, z1): {0}", z4);

            z4 = cmath53.WeierstrassSigma(g2, g3, z1);
            Console.WriteLine("z4 = mathC53.WeierstrassSigma(g2, g3, z1): {0}", z4);

            z1 = new Complex((double)-1.2m, 4.1d);
            z4 = cmath53.hardy_theta(z1);
            Console.WriteLine("z4 = mathC53.HardyTheta(z1): {0}", z4);

            // z4 = flintc53.hardy_theta(z1)
            // Console.WriteLine("z4 = flintc53.HardyTheta(z1): {0}", z4)

            z4 = cmath53.hardy_z(z1);
            Console.WriteLine("z4 = mathC53.HardyZ(z1): {0}", z4);

            // z4 = flintc53.hardy_z(z1)
            // Console.WriteLine("z4 = flintc53.HardyZ(z1): {0}", z4)

            int n = 3;
            z4 = cmath53.polylog(n, z1);
            Console.WriteLine("z4 = mathC53.Polylog(n, z1): {0}", z4);

            // z4 = flintc53.polylog(n, z1)
            // Console.WriteLine("z4 = mathC53.flintc53(n, z1): {0}", z4)



        }













        public static void RunTestsFComplex53()
        {
            TestComplex1();
            TestComplex2();
            TestComplex3();
        }



        public static void Test_mathC53()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            RunTestsFComplex53();

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