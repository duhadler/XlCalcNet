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



        #region 26 Real Elementary Functions

        public static void Demo26RealElementaryFunctions()
        {

            Console.WriteLine("Hello Demo26RealElementaryFunctions!");
            int n, k;
            double a, x, y, res;
            double v, M, e;


            #region 26.1 Root, exponential, logarithmic and power functions


            x = 0.000001d;
            res = math53.sqrt1pmx(x);
            Console.WriteLine("x: {0}, math53.sqrt1pmx(x): {1}", x, res);


            x = 2.1d;
            res = math53.bring(x);
            Console.WriteLine("x: {0}, math53.bring(x): {1}", x, res);


            x = 20.75d;
            res = math53.expmx2h(x);
            Console.WriteLine("x: {0}, math53.expmx2h(x): {1}", x, res);




            x = 20.75d;
            res = math53.exprel(x);
            Console.WriteLine("x: {0}, math53.exprel(x): {1}", x, res);


            x = 20.75d;
            res = math53.expx2(x);
            Console.WriteLine("x: {0}, math53.expx2(x): {1}", x, res);


            x = 20.75d;
            res = math53.logistic(x);
            Console.WriteLine("x: {0}, math53.logistic(x): {1}", x, res);

            n = 2;
            x = 3.4d;
            res = math53.einstein(n, x);
            Console.WriteLine("x: {0}, y: {1}, math53.einstein(n, x): {2}", n, x, res);




            x = -20.75d;
            res = math53.log1mexp(x);
            Console.WriteLine("x: {0}, math53.log1mexp(x): {1}", x, res);

            x = 20.75d;
            res = math53.log1pexp(x);
            Console.WriteLine("x: {0}, math53.log1pexp(x): {1}", x, res);


            x = 20.75d;
            res = math53.log1pmx(x);
            Console.WriteLine("x: {0}, math53.log1pmx(x): {1}", x, res);

            x = 4.5d;
            y = 7.3d;
            res = math53.logaddexp(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.logaddexp(x, y): {2}", x, y, res);

            x = 14.5d;
            y = 7.3d;
            res = math53.logsubexp(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.logsubexp(x, y): {2}", x, y, res);

            x = 0.51d;
            res = math53.logit(x);
            Console.WriteLine("x: {0}, math53.logit(x): {1}", x, res);


            x = 46.1d;
            res = math53.wright_omega(x);
            Console.WriteLine("x: {0}, math53.wright_omega(x): {1}", x, res);


            x = 20.75;
            n = 12;
            res = math53.compound_si(x, n);
            Console.WriteLine("x: {0}, n: {1}, math53.compound_si(x, n): {2}", x, n, res);

            x = 20.75d;
            n = 12;
            res = math53.comprel(x, n);
            Console.WriteLine("x: {0}, n: {1}, math53.comprel(x, n): {2}", x, n, res);



            x = 4.5d;
            y = 7.3d;
            double z = 11.3d;
            res = math53.hypot3(x, y, z);
            Console.WriteLine("x: {0}, y: {1}, z: {2}, math53.hypot3(x, y, z): {3}", x, y, z, res);

            Console.WriteLine();


            n = 20;
            x = 3.4d;
            res = math53.fibpoly(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.fibpoly(n, x): {2}", n, x, res);

            n = 20;
            x = 3.4d;
            res = math53.lucpoly(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.lucpoly(n, x): {2}", n, x, res);

            v = 2.1d;
            x = 3.4d;
            res = math53.fibfun(v, x);
            Console.WriteLine("v: {0}, x: {1}, math53.fibfun(v, x): {2}", v, x, res);


            #endregion



            #region 26.2 Trigonometric functions


            x = 180.0d;
            res = math53.sind(x);
            Console.WriteLine("x: {0}, math53.sind(x): {1}", x, res);
            Console.WriteLine();


            x = 0.75d;
            res = math53.asind(x);
            Console.WriteLine("x: {0}, math53.asind(x): {1}", x, res);
            Console.WriteLine();


            x = 20.75d;
            res = math53.cosd(x);
            Console.WriteLine("x: {0}, math53.cosd(x): {1}", x, res);
            Console.WriteLine();



            x = 0.75d;
            res = math53.acosd(x);
            Console.WriteLine("x: {0}, math53.acosd(x): {1}", x, res);
            Console.WriteLine();


            x = 0.51d;
            res = math53.tand(x);
            Console.WriteLine("x: {0}, math53.tand(x): {1}", x, res);
            Console.WriteLine();


            x = 20.75d;
            res = math53.atand(x);
            Console.WriteLine("x: {0}, math53.atand(x): {1}", x, res);
            Console.WriteLine();


            x = 20.75d;
            res = math53.cotd(x);
            Console.WriteLine("x: {0}, math53.cotd(x): {1}", x, res);
            Console.WriteLine();


            x = 20.75d;
            res = math53.acotd(x);
            Console.WriteLine("x: {0}, math53.acotd(x): {1}", x, res);
            Console.WriteLine();



            x = 0.000001d;
            res = math53.acos1m(x);
            Console.WriteLine("x: {0}, math53.acos1m(x): {1}", x, res);
            Console.WriteLine();


            x = 20.75d;
            res = math53.hav(x);
            Console.WriteLine("x: {0}, math53.hav(x): {1}", x, res);


            x = 0.75d;
            res = math53.archav(x);
            Console.WriteLine("x: {0}, math53.archav(x): {1}", x, res);
            Console.WriteLine();


            x = 0.51d;
            res = math53.vers(x);
            Console.WriteLine("x: {0}, math53.vers(x): {1}", x, res);


            x = 20.75d;
            res = math53.covers(x);
            Console.WriteLine("x: {0}, math53.covers(x): {1}", x, res);
            Console.WriteLine();


            x = 0.51d;
            res = math53.versint(x);
            Console.WriteLine("x: {0}, math53.versint(x): {1}", x, res);
            Console.WriteLine();


            n = 20;
            x = 3.4d;
            res = math53.cosint(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.cosint(n, x): {2}", n, x, res);


            n = 20;
            x = 3.4d;
            res = math53.sinint(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.sinint(n, x): {2}", n, x, res);


            //x = 20.75d;
            //res = math53.acotc(x);
            //Console.WriteLine("x: {0}, math53.Acotc(x): {1}", x, res);


            //x = 20.75d;
            //res = math53.acotcd(x);
            //Console.WriteLine("x: {0}, math53.Acotcd(x): {1}", x, res);
            //Console.WriteLine();



            #endregion



            #region 26.3 Hyperbolic functions



            x = 0.51d;
            res = math53.sinhc(x);
            Console.WriteLine("x: {0}, math53.sinhc(x): {1}", x, res);
            Console.WriteLine();


            x = 0.51d;
            res = math53.sinhmx(x);
            Console.WriteLine("x: {0}, math53.sinhmx(x): {1}", x, res);
            Console.WriteLine();



            x = 20.75d;
            res = math53.coshm1(x);
            Console.WriteLine("x: {0}, math53.coshm1(x): {1}", x, res);
            Console.WriteLine();



            x = 0.000001d;
            res = math53.acosh1p(x);
            Console.WriteLine("x: {0}, math53.acosh1p(x): {1}", x, res);


            x = 20.75d;
            res = math53.logcosh(x);
            Console.WriteLine("x: {0}, math53.logcosh(x): {1}", x, res);


            x = 20.75d;
            res = math53.logsinh(x);
            Console.WriteLine("x: {0}, math53.logsinh(x): {1}", x, res);


            x = 20.75d;
            res = math53.gd(x);
            Console.WriteLine("x: {0}, math53.gd(x): {1}", x, res);
            Console.WriteLine();


            x = 0.75d;
            res = math53.arcgd(x);
            Console.WriteLine("x: {0}, math53.arcgd(x): {1}", x, res);


            x = 2.1d;
            res = math53.langevinl(x);
            Console.WriteLine("x: {0}, math53.langevinl(x): {1}", x, res);


            x = 0.71d;
            res = math53.langevinlinv(x);
            Console.WriteLine("x: {0}, math53.langevinlinv(x): {1}", x, res);


            M = 0.75d;
            e = 3.4d;
            res = math53.kepler(M, e);
            Console.WriteLine("M: {0}, e: {1}, math53.kepler(M, e): {2}", M, e, res);




            #endregion



            #region 26.4 Gamma functions

            x = 0.75d;
            res = math53.signgamma(x);
            Console.WriteLine("x: {0}, math53.signgamma(x): {1}", x, res);


            x = 0.75d;
            var res2 = math53.lgamma_s(x);
            Console.WriteLine("x: {0}, math53.lgamma_s(x): {1}", x, res2);


            x = 0.75d;
            res = math53.lgamma1p(x);
            Console.WriteLine("x: {0}, math53.lgamma1p(x): {1}", x, res);

            n = 12;
            res = math53.logfactorial(n);
            Console.WriteLine("n: {0}, math53.logfactorial(n): {1}", n, res);


            n = 12;
            k = 6;
            res = math53.logbinomial(n, k);
            Console.WriteLine("n: {0}, k: {1}, math53.logbinomial(n, k): {2}", n, k, res);


            x = 10.3d;
            y = 12.75d;
            res = math53.logbeta(x, y);
            Console.WriteLine("x: {0}, y: {1}, math53.logbeta(x, y): {2}", x, y, res);


            y = 1.75d;
            res = math53.gamma_inv(y);
            Console.WriteLine("y: {0}, math53.gamma_inv(y): {1}", y, res);


            y = 1.75d;
            res = math53.lgamma_inv(y);
            Console.WriteLine("y: {0}, math53.lgamma_inv(y): {1}", y, res);


            x = 0.75d;
            res = math53.gammastar(x);
            Console.WriteLine("x: {0}, math53.gammastar(x): {1}", x, res);

            a = 10.3d;
            x = 12.75d;
            res = math53.poch1(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.poch1(a, x): {2}", a, x, res);


            x = 2.1d;
            res = math53.catalan_c(x);
            Console.WriteLine("x: {0}, math53.catalan_c(x): {1}", x, res);

            x = 0.75d;
            v = 3.1d;
            res = math53.bessel_lambda(v, x);
            Console.WriteLine("v: {0}, x: {1}, math53.bessel_lambda(v, x): {2}", v, x, res);



            #endregion


        }


        #endregion



        #region 27 Real Elliptic Functions

        public static void Demo27RealEllipticFunctions()
        {
            Console.WriteLine("Hello DemoDoubleEllipticIntegrals!");
            double phi, nu, k, res;
            double x, z;
            double kc, p, a, b;


            #region 27.1 Conversions of parameters of elliptic functions


            Console.WriteLine();

            k = 0.75d;
            res = math53.elliptic_nome(k);
            Console.WriteLine("k: {0}, math53.elliptic_nome(k): {1}", k, res);


            double q = 0.05d;
            res = math53.elliptic_modulus(q);
            Console.WriteLine("q: {0}, math53.elliptic_modulus(m): {1}", q, res);


            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_amplitude(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_amplitude(x, k): {2}", x, k, res);

            #endregion


            #region 27.2 Elliptic integrals


            k = 0.75d;
            res = math53.elliptic_b(k);
            Console.WriteLine("k: {0}, math53.elliptic_b(k): {1}", k, res);

            k = 0.75d;
            res = math53.elliptic_d(k);
            Console.WriteLine("k: {0}, math53.elliptic_d(k): {1}", k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.elliptic_b_inc(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.elliptic_b_inc(phi, k): {2}", phi, k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.elliptic_d_inc(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.elliptic_d_inc(phi, k): {2}", phi, k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.heuman_lambda(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.heuman_lambda(phi, k): {2}", phi, k, res);

            phi = 0.3d;
            k = 0.75d;
            res = math53.jacobi_zeta(phi, k);
            Console.WriteLine("phi: {0}, k: {1}, math53.jacobi_zeta(phi, k): {2}", phi, k, res);

            #endregion


            #region 27.3 Bulirsch elliptic integrals

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

            #endregion


            #region 27.4 Maple style elliptic integrals

            Console.WriteLine();


            k = 0.75d;
            res = math53.EllipticK(k);
            Console.WriteLine("k: {0}, math53.EllipticK(k): {1}", k, res);


            k = 0.75d;
            res = math53.EllipticKim(k);
            Console.WriteLine("k: {0}, math53.EllipticKim(k): {1}", k, res);


            k = 0.75d;
            res = math53.EllipticCK(k);
            Console.WriteLine("k: {0}, math53.EllipticCK(k): {1}", k, res);


            k = 0.75d;
            res = math53.EllipticEC(k);
            Console.WriteLine("k: {0}, math53.EllipticEC(k): {1}", k, res);


            k = 0.75d;
            res = math53.EllipticECim(k);
            Console.WriteLine("k: {0}, math53.EllipticECim(k): {1}", k, res);


            k = 0.75d;
            res = math53.EllipticCE(k);
            Console.WriteLine("k: {0}, math53.EllipticCE(k): {1}", k, res);


            nu = 1.4d;
            k = 0.6d;
            res = math53.EllipticPiC(nu, k);
            Console.WriteLine("nu: {0}, k: {1}, math53.EllipticPiC(nu, k): {2}", nu, k, res);


            nu = 1.4d;
            k = 0.6d;
            res = math53.EllipticPiCim(nu, k);
            Console.WriteLine("nu: {0}, k: {1}, math53.EllipticPiCim(nu, k): {2}", nu, k, res);


            nu = 1.4d;
            k = 0.6d;
            res = math53.EllipticCPi(nu, k);
            Console.WriteLine("nu: {0}, k: {1}, math53.EllipticCPi(nu, k): {2}", nu, k, res);


            z = 0.75d;
            k = 0.1d;
            res = math53.EllipticF(z, k);
            Console.WriteLine("z: {0}, k: {1}, math53.EllipticF(z, k): {2}", z, k, res);


            z = 0.75d;
            k = 0.1d;
            res = math53.EllipticE(z, k);
            Console.WriteLine("z: {0}, k: {1}, math53.EllipticE(z, k): {2}", z, k, res);


            z = 0.75d;
            nu = 1.4d;
            k = 0.6d;
            res = math53.EllipticPi(z, nu, k);
            Console.WriteLine("z: {0}, nu: {1}, k: {2}, math53.EllipticPi(z, nu, k): {3}", z, nu, k, res);


            #endregion


            #region 27.5 Jacobi theta functions at x = 0

            Console.WriteLine();

            x = 0.3d;
            q = 0.75d;

            q = 0.75d;
            res = math53.jacobi_theta1p(q);
            Console.WriteLine("q: {0}, math53.jacobi_theta1p(q): {1}", q, res);

            q = 0.75d;
            res = math53.jacobi_theta02(q);
            Console.WriteLine("q: {0}, math53.jacobi_theta02(q): {1}", q, res);

            q = 0.75d;
            res = math53.jacobi_theta03(q);
            Console.WriteLine("q: {0}, math53.jacobi_theta03(q): {1}", q, res);

            q = 0.75d;
            res = math53.jacobi_theta04(q);
            Console.WriteLine("q: {0}, math53.jacobi_theta04(q): {1}", q, res);

            #endregion


            #region 27.6 Inverse Jacobi elliptic functions

            Console.WriteLine();


            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arcsn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcsn(x, k): {2}", x, k, res);


            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arccn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arccn(x, k): {2}", x, k, res);


            x = 0.3d;
            k = 1.75d;
            res = math53.jacobi_arcdn(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcdn(x, k): {2}", x, k, res);


            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arccd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arccd(x, k): {2}", x, k, res);


            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arcsd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcsd(x, k): {2}", x, k, res);


            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcnd(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcnd(x, k): {2}", x, k, res);


            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcdc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcdc(x, k): {2}", x, k, res);


            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcnc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcnc(x, k): {2}", x, k, res);


            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arcsc(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcsc(x, k): {2}", x, k, res);


            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcns(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcns(x, k): {2}", x, k, res);


            x = 1.3d;
            k = 0.75d;
            res = math53.jacobi_arcds(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arcds(x, k): {2}", x, k, res);


            x = 0.3d;
            k = 0.75d;
            res = math53.jacobi_arccs(x, k);
            Console.WriteLine("x: {0}, k: {1}, math53.jacobi_arccs(x, k): {2}", x, k, res);


            #endregion


            #region 27.7 Lemniscate functions

            Console.WriteLine();

            x = 0.3d;
            res = math53.sinlemn(x);
            Console.WriteLine("x: {0}, math53.sinlemn(x): {1}", x, res);

            x = 0.3d;
            res = math53.coslemn(x);
            Console.WriteLine("x: {0}, math53.coslemn(x): {1}", x, res);

            x = 0.3d;
            res = math53.arcsl(x);
            Console.WriteLine("x: {0}, math53.arcsl(x): {1}", x, res);

            x = 0.3d;
            res = math53.arccl(x);
            Console.WriteLine("x: {0}, math53.arccl(x): {1}", x, res);


            #endregion



            #region 27.8 Neville theta functions

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

            #endregion



        }


        #endregion



        #region 28 Lerch Phi

        public static void Demo28LerchPhi()
        {

            Console.WriteLine("Hello DemoDoubleZeta!");
            int n;
            double s, x, res;



            #region 28.1 Polygamma, and related functions


            x = 12.1d;
            res = math53.pentagamma(x);
            Console.WriteLine("x: {0}, math53.pentagamma(x): {1}", x, res);


            x = 12.1d;
            res = math53.tetragamma(x);
            Console.WriteLine("x: {0}, math53.tetragamma(x): {1}", x, res);


            x = 12.1d;
            res = math53.psistar(x);
            Console.WriteLine("x: {0}, math53.psistar(x): {1}", x, res);


            x = 12.1d;
            res = math53.psi_inv(x);
            Console.WriteLine("x: {0}, math53.psi_inv(x): {1}", x, res);

            x = 12.1d;
            res = math53.bateman_g(x);
            Console.WriteLine("x: {0}, math53.bateman_g(x): {1}", x, res);


            Console.WriteLine();

            #endregion



            #region 28.2 Polylogarithm, and related functions

            Console.WriteLine();

            n = 5;
            x = 2.1d;
            res = math53.polylog_i(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.polylog_i(n, x): {2}", n, x, res);


            n = 5;
            x = 2.1d;
            res = math53.fermi_dirac_i(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.fermi_dirac_i(n, x): {2}", n, x, res);


            s = 0.75d;
            res = math53.fermi_dirac_m05(s);
            Console.WriteLine("s: {0}, math53.fermi_dirac_m05(s): {1}", s, res);


            s = 0.75d;
            res = math53.fermi_dirac_p05(s);
            Console.WriteLine("s: {0}, math53.fermi_dirac_p05(s): {1}", s, res);


            s = 0.75d;
            res = math53.fermi_dirac_p15(s);
            Console.WriteLine("s: {0}, math53.fermi_dirac_p15(s): {1}", s, res);


            s = 0.75d;
            res = math53.fermi_dirac_p25(s);
            Console.WriteLine("s: {0}, math53.fermi_dirac_p25(s): {1}", s, res);


            x = 10.75d;
            res = math53.tangent_int_2(x);
            Console.WriteLine("x: {0}, math53.tangent_int_2(x): {1}", x, res);


            x = 10.75d;
            res = math53.lobachevsky_c(x);
            Console.WriteLine("x: {0}, math53.lobachevsky_c(x): {1}", x, res);


            x = 10.75d;
            res = math53.lobachevsky_s(x);
            Console.WriteLine("x: {0}, math53.lobachevsky_s(x): {1}", x, res);


            n = 2;
            x = 3.4d;
            res = math53.debye(n, x);
            Console.WriteLine("x: {0}, y: {1}, math53.debye(n, x): {2}", n, x, res);


            n = 3;
            x = 3.4d;
            res = math53.transport_jn(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.transport_jn(n, x): {2}", n, x, res);


            Console.WriteLine();

            #endregion



            #region 28.3 Riemann zeta, and related functions

            n = 5;
            res = math53.zeta_i(n);
            Console.WriteLine("n: {0}, math53.zeta_i(n): {1}", n, res);

            s = 0.75d;
            res = math53.zeta1p(s);
            Console.WriteLine("s: {0}, math53.zeta1p(s): {1}", s, res);

            n = 5;
            res = math53.dirichlet_eta_i(n);
            Console.WriteLine("n: {0}, math53.dirichlet_eta_i(n): {1}", n, res);


            s = 0.75d;
            res = math53.primezeta(s);
            Console.WriteLine("s: {0}, math53.primezeta(s): {1}", s, res);


            x = 210.0d;
            res = math53.riemann_r(x);
            Console.WriteLine("x: {0}, math53.riemann_r(x): {1}", x, res);


            x = 46.0d;
            res = math53.riemann_r_inv(x);
            Console.WriteLine("x: {0}, math53.riemann_r_inv(x): {1}", x, res);


            double q = 0.1d;
            res = math53.rogers_ramanujan_cf(q);
            Console.WriteLine("q: {0}, math53.rogers_ramanujan_cf(q): {1}", q, res);


            var i16 = math53.moebius(10);
            Console.WriteLine("i16 = math53.moebius(10):  {0}", i16);


            q = 0.1d;
            res = math53.euler_q(q);
            Console.WriteLine("q: {0}, math53.euler_q(q): {1}", q, res);


            #endregion



            #region 28.4 Miscellaneous functions

            double p = 0.1d;
            int k = 5;
            res = math53.logseries_pmf(p, k);
            Console.WriteLine("p: {0}, k: {1}, math53.logseries_pmf(p, k): {2}", p, k, res);

            p = 0.1d;
            k = 5;
            res = math53.logseries_cdf(p, k);
            Console.WriteLine("p: {0}, k: {1}, math53.logseries_cdf(p, k): {2}", p, k, res);


            Console.WriteLine();

            double r = 0.1d;
            k = 5;
            res = math53.zeta_pmf(r, k);
            Console.WriteLine("r: {0}, k: {1}, math53.zeta_pmf(r, k): {2}", r, k, res);

            r = 0.1d;
            k = 5;
            res = math53.zeta_cdf(r, k);
            Console.WriteLine("r: {0}, k: {1}, math53.zeta_cdf(r, k): {2}", r, k, res);




            #endregion


        }

        #endregion



        #region 29 Functions Related to 0F1

        public static void Demo29FunctionsRelatedTo0F1()
        {
            Console.WriteLine("Hello DemoDoubleBessel!");
            double x, u, res;
            int n;


            #region 29.1 Bessel functions of integer order


            x = 0.75d;
            res = math53.bessel_j0(x);
            Console.WriteLine("x: {0}, math53.bessel_j0(x): {2}", x, res);


            x = 0.75d;
            res = math53.bessel_j1(x);
            Console.WriteLine("x: {0}, math53.bessel_j1(x): {2}", x, res);


            x = 0.75d;
            n = 3;
            res = math53.bessel_jn(n, x);
            Console.WriteLine("v: {0}, x: {1}, math53.bessel_jn(n, x): {2}", n, x, res);


            x = 0.75d;
            res = math53.bessel_y0(x);
            Console.WriteLine("x: {0}, math53.bessel_y0(x): {2}", x, res);


            x = 0.75d;
            res = math53.bessel_y1(x);
            Console.WriteLine("x: {0}, math53.bessel_y1(x): {2}", x, res);


            x = 0.75d;
            n = 3;
            res = math53.bessel_yn(n, x);
            Console.WriteLine("v: {0}, x: {1}, math53.bessel_yn(n, x): {2}", n, x, res);






            Console.WriteLine();

            #endregion



            #region 29.2 Modified Bessel functions of integer order


            x = 0.75d;
            res = math53.bessel_i0(x);
            Console.WriteLine("x: {0}, math53.bessel_i0(x): {2}", x, res);


            x = 0.75d;
            res = math53.bessel_i1(x);
            Console.WriteLine("x: {0}, math53.bessel_i1(x): {2}", x, res);


            x = 0.75d;
            n = 3;
            res = math53.bessel_in(n, x);
            Console.WriteLine("v: {0}, x: {1}, math53.bessel_in(v, x): {2}", n, x, res);


            x = 0.75d;
            res = math53.bessel_k0(x);
            Console.WriteLine("x: {0}, math53.bessel_k0(x): {2}", x, res);


            x = 0.75d;
            res = math53.bessel_k1(x);
            Console.WriteLine("x: {0}, math53.bessel_k1(x): {2}", x, res);


            x = 0.75d;
            n = 3;
            res = math53.bessel_kn(n, x);
            Console.WriteLine("v: {0}, x: {1}, math53.bessel_kn(v, x): {2}", n, x, res);


            x = 0.75d;
            res = math53.bessel_i0e(x);
            Console.WriteLine("x: {0}, math53.bessel_i0e(x): {2}", x, res);


            x = 0.75d;
            res = math53.bessel_i1e(x);
            Console.WriteLine("x: {0}, math53.bessel_i1e(x): {2}", x, res);


            x = 0.75d;
            res = math53.bessel_k0e(x);
            Console.WriteLine("x: {0}, math53.bessel_k0e(x): {2}", x, res);


            x = 0.75d;
            res = math53.bessel_k1e(x);
            Console.WriteLine("x: {0}, math53.bessel_k1e(x): {2}", x, res);



            #endregion



            #region 29.3 Integrals of zero-order Bessel functions

            Console.WriteLine();

            u = 4.75d;
            res = math53.bessel_j0_int(u);
            Console.WriteLine("u: {0}, math53.bessel_j0_int(u): {1}", u, res);

            u = 4.75d;
            res = math53.bessel_y0_int(u);
            Console.WriteLine("u: {0}, math53.bessel_y0_int(u): {1}", u, res);

            u = 4.75d;
            res = math53.bessel_i0_int(u);
            Console.WriteLine("u: {0}, math53.bessel_i0_int(u): {1}", u, res);

            u = 4.75d;
            res = math53.bessel_k0_int(u);
            Console.WriteLine("u: {0}, math53.bessel_k0_int(u): {1}", u, res);

            #endregion



            #region 29.4 Kelvin functions of order 0

            Console.WriteLine();

            x = 0.75d;
            res = math53.kelvin_bei0(x);
            Console.WriteLine("x: {0}, math53.kelvin_bei0(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_ber0(x);
            Console.WriteLine("x: {0}, math53.kelvin_ber0(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_kei0(x);
            Console.WriteLine("x: {0}, math53.kelvin_kei0(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_ker0(x);
            Console.WriteLine("x: {0}, math53.kelvin_ker0(x): {1}", x, res);



            x = 0.75d;
            res = math53.kelvin_bei_prime0(x);
            Console.WriteLine("x: {0}, math53.kelvin_bei_prime0(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_ber_prime0(x);
            Console.WriteLine("x: {0}, math53.kelvin_ber_prime0(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_kei_prime0(x);
            Console.WriteLine("x: {0}, math53.kelvin_kei_prime0(x): {1}", x, res);

            x = 0.75d;
            res = math53.kelvin_ker_prime0(x);
            Console.WriteLine("x: {0}, math53.kelvin_ker_prime0(x): {1}", x, res);


            #endregion



            #region 29.5 Synchrotron functions
            Console.WriteLine();

            x = 0.75d;
            res = math53.synchrotron_f(x);
            Console.WriteLine("x: {0}, math53.synchrotron_f(x): {1}", x, res);

            x = 0.75d;
            res = math53.synchrotron_g(x);
            Console.WriteLine("x: {0}, math53.synchrotron_g(x): {1}", x, res);

            Console.WriteLine();

            #endregion


        }

        #endregion



        #region 30 Functions Related to 1F1

        public static void Demo30FunctionsRelatedTo1F1()
        {
            double x, x1, x2, p, h, a, res;
            int n;


            #region 30.1 Incomplete gamma functions


            Console.WriteLine();

            a = 10.3d;
            x = 12.75d;
            res = math53.gamma_tricomi(a, x);
            Console.WriteLine("a: {0}, x: {1}, math53.gamma_tricomi(a, x): {2}", a, x, res);


            n = 3;
            x = 3.4d;
            res = math53.expn(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.expn(n, x): {2}", n, x, res);


            n = 20;
            x = 3.4d;
            res = math53.expreln(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.expreln(n, x): {2}", n, x, res);


            #endregion



            #region 30.2 Coulomb wave functions

            Console.WriteLine();

            int L = 3;
            double eta = 0.75d;
            res = math53.coulomb_cl(L, eta);
            Console.WriteLine("L: {0}, eta: {1}, math53.coulomb_cl(L, eta): {2}", L, eta, res);

            L = 3;
            eta = 0.75d;
            res = math53.coulomb_sl(L, eta);
            Console.WriteLine("L: {0}, eta: {1}, math53.coulomb_sl(L, eta): {2}", L, eta, res);


            L = 3;
            eta = 0.75d;
            x = 4.0d;
            var res2 = math53.coulomb_f_fprime(L, eta, x);
            Console.WriteLine("L: {0}, eta: {1}, x: {2}, math53.coulomb_f_fprime(L, eta, x): {3}", L, eta, x, res2);


            L = 3;
            eta = 0.75d;
            x = 4.0d;
            res2 = math53.coulomb_g_gprime(L, eta, x);
            Console.WriteLine("L: {0}, eta: {1}, x: {2}, math53.coulomb_g_gprime(L, eta, x): {3}", L, eta, x, res2);


            #endregion



            #region 30.3 Error function, and related functions


            Console.WriteLine("Hello DemoDoubleErrorFunction!");


            x = 0.75d;
            res = math53.erfcx(x);
            Console.WriteLine("x: {0}, math53.erfcx(x): {1}", x, res);


            x = 0.75d;
            h = 0.001d;
            res = math53.erfh(x, h);
            Console.WriteLine("x: {0}, h: {1}, math53.erfh(x, h): {2}", x, h, res);


            x1 = 0.75d;
            x2 = 4.001d;
            res = math53.erf2(x1, x2);
            Console.WriteLine("x: {0}, h: {1}, math53.erf2(x1, x2): {2}", x, h, res);


            x = 0.75d;
            res = math53.erfq(x);
            Console.WriteLine("x: {0}, math53.erfq(x): {1}", x, res);


            x = 0.75d;
            res = math53.erfcx_inv(x);
            Console.WriteLine("x: {0}, math53.erfcx_inv(x): {1}", x, res);


            x = 0.75d;
            res = math53.erfi_inv(x);
            Console.WriteLine("x: {0}, math53.erfi_inv(x): {1}", x, res);


            p = 3.1d;
            x = 0.75d;
            res = math53.dawson2(p, x);
            Console.WriteLine("p: {0}, x: {1}, math53.dawson2(p, x): {2}", p, x, res);


            p = 3.1d;
            x = 0.75d;
            res = math53.erfg(p, x);
            Console.WriteLine("p: {0}, x: {1}, math53.erfg(p, x): {2}", p, x, res);


            x = 0.75d;
            res = math53.expint3(x);
            Console.WriteLine("x: {0}, math53.expint3(x): {1}", x, res);


            int pp;
            pp = 3;
            x = 0.75d;
            res = math53.inerfc(pp, x);
            Console.WriteLine("pp: {0}, x: {1}, math53.inerfc(pp, x): {2}", pp, x, res);


            x = 0.75d;
            res = math53.fresnel_f(x);
            Console.WriteLine("x: {0}, math53.fresnel_f(x): {1}", x, res);


            x = 0.75d;
            res = math53.fresnel_g(x);
            Console.WriteLine("x: {0}, math53.fresnel_g(x): {1}", x, res);


            x = 0.75d;
            res = math53.goodwin_staton(x);
            Console.WriteLine("x: {0}, math53.goodwin_staton(x): {1}", x, res);


            x = 0.75d;
            double t = 0.75d;
            res = math53.voigt_u(x, t);
            Console.WriteLine("x: {0}, x: {1}, math53.voigt_u(x, t): {2}", x, t, res);


            x = 0.75d;
            t = 0.75d;
            res = math53.voigt_v(x, t);
            Console.WriteLine("x: {0}, x: {1}, math53.voigt_v(x, t): {2}", x, t, res);


            a = 0.75d;
            double u = 0.75d;
            res = math53.voigt_h(a, u);
            Console.WriteLine("a: {0}, u: {1}, math53.voigt_h(a, u): {2}", x, t, res);


            x = 0.75d;
            double sigma = 0.75d;
            double gamma = 0.75d;
            res = math53.voigt_profile_pdf(x, sigma, gamma);
            Console.WriteLine("x: {0}, sigma: {1}, gamma: {2}, math53.voigt_profile_pdf(x, sigma, gamma): {3}", x, sigma, gamma, res);


            Console.WriteLine();

            #endregion



            #region 30.4 Exponential integrals, and related functions


            Console.WriteLine("Hello DemoDoubleExponentialIntegral!");


            x = 0.75d;
            res = math53.cin(x);
            Console.WriteLine("x: {0}, math53.cin(x): {1}", x, res);

            x = 0.75d;
            res = math53.cinh(x);
            Console.WriteLine("x: {0}, math53.cinh(x): {1}", x, res);

            x = 0.75d;
            res = math53.ein(x);
            Console.WriteLine("x: {0}, math53.ein(x): {1}", x, res);

            x = 0.75d;
            res = math53.exp_integral_e1_scaled(x);
            Console.WriteLine("x: {0}, math53.exp_integral_e1_scaled(x): {1}", x, res);


            x = 0.75d;
            res = math53.exp_integral_ei_scaled(x);
            Console.WriteLine("x: {0}, math53.exp_integral_ei_scaled(x): {1}", x, res);

            x = 0.75d;
            res = math53.eisx2(x);
            Console.WriteLine("x: {0}, math53.eisx2(x): {1}", x, res);

            x = 0.75d;
            res = math53.ei_inv(x);
            Console.WriteLine("x: {0}, math53.ei_inv(x): {1}", x, res);


            p = 3.1d;
            x = 0.75d;
            res = math53.gei(p, x);
            Console.WriteLine("p: {0}, x: {1}, math53.gei(p, x): {2}", p, x, res);

            n = 3;
            x = 0.75d;
            res = math53.eibeta(n, x);
            Console.WriteLine("n: {0}, x: {1}, math53.eibeta(n, x): {2}", n, x, res);

            x = 0.75d;
            res = math53.log_integral_inv(x);
            Console.WriteLine("x: {0}, math53.log_integral_inv(x): {1}", x, res);


            x = 0.75d;
            res = math53.shifted_sin_integral(x);
            Console.WriteLine("x: {0}, math53.shifted_sin_integral(x): {1}", x, res);




            Console.WriteLine();

            #endregion



            #region 30.5 Struve functions

            Console.WriteLine();

            x = 0.75d;
            res = math53.struve_h0(x);
            Console.WriteLine("x: {0}, math53.struve_h0(x): {1}", x, res);

            x = 0.75d;
            res = math53.struve_h1(x);
            Console.WriteLine("x: {0}, math53.struve_h1(x): {1}", x, res);


            x = 0.75d;
            res = math53.struve_l0(x);
            Console.WriteLine("x: {0}, math53.struve_l0(x): {1}", x, res);

            x = 0.75d;
            res = math53.struve_l1(x);
            Console.WriteLine("x: {0}, math53.struve_l1(x): {1}", x, res);

            #endregion


        }


        #endregion



        #region 31 Real And Complex Functions

        public static void Demo31RealAndComplexFunctions()
        {
            Console.WriteLine("Hello Demo31RealAndComplexFunctions!");
            double res;
            double x, y;

            #region 31.4 Real: Weierstrass elliptic functions, in terms of (real) lattice invariants g2, g3

            Console.WriteLine();

            y = 0.3d;
            res = math53.weierstrass_pl(y);
            Console.WriteLine("y: {0}, math53.Wpl(y): {1}", y, res);


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

            y = 0.5d;
            g2 = 0.05d;
            g3 = 0.07d;
            res = math53.weierstrass_pg_inv(y, g2, g3);
            Console.WriteLine("y: {0}, g2: {1}, g3: {2}, math53.WpgInv(y, g2, g3): {3}", y, g2, g3, res);

            #endregion


            #region 31.5 Real: Weierstrass elliptic functions, in terms of (real) lattice roots e1, e2

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

            y = 0.1d;
            e1 = 0.75d;
            e2 = 1.75d;
            res = math53.weierstrass_pe_inv(y, e1, e2);
            Console.WriteLine("y: {0}, e1: {1}, e2: {2}, math53.WpeInv(y, e1, e2): {3}", y, e1, e2, res);

            #endregion






            #region move_to_main

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

            #endregion


        }

        #endregion








        public static void RunTestsFReal()
        {
            TestRawOperations();
            //TestFRealRawOperations2();
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