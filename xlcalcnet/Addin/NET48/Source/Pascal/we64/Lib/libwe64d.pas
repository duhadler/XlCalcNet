library libwe64d;


uses
  damath,
  damtools,
  damcmplx,
  specfund,
  
  mp_types,
  mp_base,
  mp_numth,
  mp_modul,
  mp_ratio,
  mp_pfu,
  mp_prime,
  
  dfpu,
  sdpoly;   {Basic common code}



{------------------------ FPU precision mode ----------------------------}



procedure damath_setpmExtended();  cdecl; export;
begin
    SetPrecisionMode(pmExtended);  
end;



procedure damath_setpmDouble();  cdecl; export;
begin
  SetPrecisionMode(pmDouble);
end;


function damath_GetPrecisionMode(): longint;  cdecl; export;
var pm: longint;
var P: TFPUPrecisionMode;
begin
  
  P := GetPrecisionMode();
  if P = pmSingle then pm := 1;
  if P = pmReserved then pm := 2;
  if P = pmDouble then pm := 3;
  if P = pmExtended then pm := 4;

  { WriteLn('pm: ', pm); }
  damath_GetPrecisionMode := pm;
  
end;


{------------------------ 32 bit and floating point routines ----------------------------}



function  mpi_bitsize32(a: longint): integer;  cdecl; export;
  {-Return the number of bits in a (index of highest bit), 0 if no bit is set}
begin
  mpi_bitsize32 := bitsize32(a);
end;


function  mpi_gcd32(A, B: longint): longint;  cdecl; export;
  {-Calculate GCD of two longints}
begin
  mpi_gcd32 := gcd32(A, B);
end;


function  mpi_gcd32u(A, B: longint): longint;  cdecl; export;
  {-Calculate GCD of two longints (DWORD interpretation)}
begin
  mpi_gcd32u := gcd32u(A, B);
end;


function  mpi_exptmod32(a,b,c: longint): longint;  cdecl; export;
  {-Calculate a^b mod c if a>=0, b>=0, c>0; result=0 otherwise}
begin
  mpi_exptmod32 := exptmod32(a,b,c);
end;


function  mpi_icbrt32(a: longint): longint;  cdecl; export;
  {-Return the integer cube root sign(a)*floor(|a|^(1/3))}
begin
  mpi_icbrt32 := icbrt32(a);
end;


function  mpi_invmod32(a,b: longint): longint;  cdecl; export;
  {-Return a^-1 mod b, b>1. Result is 0 if gcd(a,b)<>1 or b<2}
begin
  mpi_invmod32 := invmod32(a, b);
end;


function  mpi_isqrt32(a: longint): longint;
  {-Return floor(sqrt(abs(a))}
begin
  mpi_isqrt32 := isqrt32(a);
end;


function  mpi_is_square32(a: longint): boolean;  cdecl; export;
  {-Test if a is square, i.e. test if a=sqr(isqrt32(a)), false if a<0}
begin
  mpi_is_square32 := is_square32(a);
end;


function  mpi_is_square32ex(a: longint; var b: longint): boolean;  cdecl; export;
  {-Test if a is square, false if a<0. If yes, b = sqrt(a) else b is undefined}
begin
  mpi_is_square32ex := is_square32ex(a, b);
end;


function  mpi_jacobi32(a,b: longint): integer;  cdecl; export;
  {-Compute the Jacobi/Legendre symbol (a|b), b: odd and > 2}
begin
  mpi_jacobi32 := jacobi32(a, b);
end;


function  mpi_kronecker32(a,b: longint): integer;  cdecl; export;
  {-Compute the Kronecker symbol (a|b)}
begin
  mpi_kronecker32 := kronecker32(a, b);
end;


function  mpi_mulmod32(a,b,n: longint): longint;  cdecl; export;
  {-Return a*b mod n, assumes n>0, a,b>=0}
begin
  mpi_mulmod32 := mulmod32(a, b, n);
end;


function  mpi_popcount16(w: word): integer;  cdecl; export;
  {-Get population count = number of 1-bits in a word}
begin
  mpi_popcount16 := popcount16(w);
end;


function  mpi_popcount32(l: longint): integer;  cdecl; export;
  {-Get population count = number of 1-bits in a longint}
begin
  mpi_popcount32 := popcount32(l);
end;


procedure mpi_xgcd32(a,b: longint; var u1,u2,u3: longint);  cdecl; export;
  {-Extended gcd algorithm, calculate a*u1 + b*u2 = u3 = gcd(a,b); a,b <> -2^31}
begin
  xgcd32(a,b,u1,u2,u3);
end;













{----------------------------- Start mp_prime -----------------------------------}

{------------------------ Basic prime functions ----------------------------}

function mpi_IsPrime16(N: word): boolean;  cdecl; export;
  {-Test if N is prime}
begin
  mpi_IsPrime16 := IsPrime16(N);
end;


function mpi_Primes16Index(n: word): integer;  cdecl; export;
  {-Return index of largest prime <= n in Primes16 array; 1 if n<=2}
  { Since Primes16[1]=2, this is identical to primepi(n) for n>=2. }
begin
  mpi_Primes16Index := Primes16Index(n);
end;


function mpi_IsPrime32(N: longint): boolean;  cdecl; export;
  {-Test if longint (DWORD) N is prime}
begin
  mpi_IsPrime32 :=IsPrime32(N);
end;


function mpi_is_primepower32(n: longint; var p: longint): integer;  cdecl; export;
  {-Test if n is a prime power: return 0 if not, n = p^result otherwise.}
  { Note: contrary to mp_is_primepower a prime n is returned as n = n^1!}
begin
  mpi_is_primepower32 := is_primepower32(n, p);
end;


function mpi_lsumphi32(x: longint; a: integer): longint;  cdecl; export;
  {-Return the partial sieve function Phi(x,a), the number of integers in}
  { (0,x] which are co-prime to the first a primes, aka 'Legendre's sum'}
begin
  mpi_lsumphi32 := lsumphi32(x, a);
end;


function mpi_primepi32(x: longint):  longint;  cdecl; export;
  {-Return the prime counting function pi(x) using Lehmer's formula}
begin
  mpi_primepi32 := primepi32(x);
end;


function mpi_is_spsp32(N, A: longint): boolean;  cdecl; export;
  {-Strong probable prime test for N with base A, calls is_spsp32A}
begin
  mpi_is_spsp32 := is_spsp32(N, A);
end;




{--------------------- 32-bit number-theoretic functions -------------------}

function  mpi_Carmichael32(n: longint): longint;  cdecl; export;
  {-Return the Carmichael function lambda(|n|), lambda(0)=0. For n > 0 this}
  { is the least k such that x^k = 1 (mod n) for all x with gcd(x,n) = 1.  }
begin
  mpi_Carmichael32 := Carmichael32(n);
end;


function  mpi_core32(n: longint): longint;  cdecl; export;
  {-Return the squarefree part of n, n<>0, i.e. the unique squarefree integer c with n=c*f^2}
begin
  mpi_core32 :=core32(n);
end;


function  mpi_dlog32(a,b,p: longint): longint;  cdecl; export;
  {-Compute the discrete log_a(b) mod p using Pollard's rho algorithm: i.e.}
  { solve a^x = b mod p, with p prime, a > 1, b > 0; return -1 for failure.}
  { If a is no primitive root mod p, solutions may not exist or be unique. }
begin
  mpi_dlog32 := dlog32(a,b,p);
end;


function  mpi_dlog32_ex(a,b,p,JMAX: longint): longint;  cdecl; export;
  {-Compute the discrete log_a(b) mod p using Pollard's rho  }
  { algorithm; p prime, a > 1, b > 0; return -1 for failure. }
  { Expanded version with variable trial parameter JMAX >= 0.}
begin
  mpi_dlog32_ex := dlog32_ex(a,b,p,JMAX);
end;


function  mpi_EulerPhi32(n: longint): longint;  cdecl; export;
  {-Return Euler's totient function phi(|n|), phi(0)=0. For n > 0 }
  { this the number of positive integers k <= n with gcd(n,k) = 1.}
begin
  mpi_EulerPhi32 := EulerPhi32(n);
end;


function  mpi_is_Carmichael32(n: longint): boolean;  cdecl; export;
  {-Test if |n| is a Carmichael number}
begin
  mpi_is_Carmichael32 := is_Carmichael32(n);
end;


function  mpi_is_fundamental32(d: longint): boolean;  cdecl; export;
  {-Return true, if d is a fundamental discriminant (either d=1 mod 4 and }
  { squarefree, or d=0 mod 4, d/4 = 2,3 mod and squarefree), false if not.}
begin
  mpi_is_fundamental32 := is_fundamental32(d);
end;


function  mpi_is_primroot32(g,n: longint): boolean;  cdecl; export;
  {-Test if g is primitive root mod n}
begin
  mpi_is_primroot32 := is_primroot32(g,n);
end;


function  mpi_is_squarefree32(n: longint): boolean;  cdecl; export;
  {-Return true if n is squarefree, i.e. not divisible by a square > 1}
begin
  mpi_is_squarefree32 := is_squarefree32(n);
end;


function  mpi_Moebius32(n: longint): integer;  cdecl; export;
  {-Return the Moebius function mu(abs(n)), mu(0)=0, mu(1)=1. mu(n)=(-1)^k }
  { if n > 1 is the product of k different primes; otherwise mu(n)=0.      }
begin
  mpi_Moebius32 := Moebius32(n);
end;


function  mpi_order32(n,m: longint): longint;  cdecl; export;
  {-Return the order of n mod m, m > 1, i.e. the smallest integer}
  { e with n^e = 1 mod m; if gcd(n,m) <> 1 the result is 0.}
begin
  mpi_order32 := order32(n,m);
end;


function  mpi_prime32(k: longint): longint;  cdecl; export;
  {-Return the kth prime if 1 <= k <= 105097565, 0 otherwise}
begin
  mpi_prime32 := prime32(k);
end;


procedure mpi_PrimeFactor32(n: longint; var FR: TFactors32);  cdecl; export;
  {-Return the prime factorization of n > 1, FR.pcount=0 if n < 2}
begin
  PrimeFactor32(n, FR);
end;


function  mpi_primroot32(n: longint): longint;  cdecl; export;
  {-Compute the smallest primitive root mod n, 0 if n does not have a prim.root}
begin
  mpi_primroot32 := primroot32(n);
end;


function  mpi_quaddisc32(n: longint): longint;  cdecl; export;
  {-Return the discriminant of the quadratic field Q(sqrt(n))}
begin
  mpi_quaddisc32 := quaddisc32(n);
end;


function  mpi_rad32(n: longint): longint;  cdecl; export;
  {-Return the radical rad(n) of n = product of the distinct prime factors of n.}
begin
  mpi_rad32 := rad32(n);
end;


function  mpi_tau32(n: longint): integer;  cdecl; export;
  {-Return the number of positive divisors of n (including 1 and n)}
begin
  mpi_tau32 := tau32(n);
end;


{------------------------ Prime sieve functions ----------------------------}

procedure mpi_FindFirstPrime32(n: longint; var ctx: TPrimeContext);  cdecl; export;
  {-Find first prime >= n and initialize ctx for FindNextPrime32}
begin
  FindFirstPrime32(n, ctx);
end;


procedure mpi_FindNextPrime32(var ctx: TPrimeContext);  cdecl; export;
  {-Find next 32 bit prime (DWORD interpretation, see note), success if ctx.prime<>0}
begin
  FindNextPrime32(ctx);
end;


function  mpi_nextprime32(n: longint): longint;  cdecl; export;
  {-Next 32 bit prime >= n (DWORD interpretation, see note)}
begin
  mpi_nextprime32 := nextprime32(n);
end;




function  mpi_prevprime32(n: longint): longint;  cdecl; export;
  {-Previous 32 bit prime <= n, prevprime32(0)=0, (DWORD interpretation)}
begin
  mpi_prevprime32 := prevprime32(n);
end;


function  mpi_safeprime32(n: longint): longint;  cdecl; export;
  {-Return the next safe prime p >= n, i.e. p and (p-1)/2 prime; 0 if n > 2147483579}
begin
  mpi_safeprime32 := safeprime32(n);
end;


{------------------------ Numerical calculus ----------------------------}




  

function damath_squadx(a,b,c: double; var x1,y1,x2,y2: double): integer;  cdecl; export;
  {-Solve the quadratic equation a*x^2 + b*x + c = 0. Result is the number}
  { of different solutions: 0 (if a=b=0 or INF/NAN), 1 (x1), or 2 (x1,x2).}
  { If the result is = -2, then x1 + i*y1 and x2 + i*y2 are the two complex}
  { solutions. Uses scaling by powers of two to minimize over/underflows.}
begin
    damath_squadx := squadx(a, b, c, x1, y1, x2, y2);
end;


procedure damath_cubsolve(a,b,c,d: double; var x,x1,y1,x2,y2: double);  cdecl; export;
  {-Solve the cubic equation ax^3 + bx^2 + cx + d = 0: compute a real root}
  { x (may be INF if a~0) and two complex zeros x1 + i*y1, x2 + i*y2 where}
  { y2 = -y1 may be zero, i.e. there are three reel roots.}
begin
    cubsolve(a, b, c, d, x, x1, y1, x2, y2);
end;




procedure damath_localmin(f: TFuncD; a,b,eps,t: double; var x,fx: double; var ic: integer);  cdecl; export;
  {-Brent's algorithm (with guaranteed convergence) for finding a local    }
  { minimum of the function f in the interval (a,b). x is the approximate  }
  { minimum abscissa, fx=f(x). eps and t define a tolerance tol =eps*|x|+t.}
  { f is never evaluated for 2 points closer together than tol. eps shall  }
  { not be < 2*eps_d, preferably not smaller than sqrt(eps_d). ic is the   }
  { iteration count, -1 if a=b, 0 if max. count = 5000 exceeded.}
  { The algorithm combines golden section search and successive parabolic  }
  { interpolation using only function (not derivative) evaluations.        }
begin
   localmin(f, a, b, eps, t, x, fx, ic);
end;


procedure damath_mbrent(f: TFuncD;  a,b,t: double; var x,fx: double; var ic: integer);  cdecl; export;
  {-Find a local minimum of the function f in the interval (a,b). }
  { x is the approximate minimum abscissa, fx = f(x). Simplified  }
  { version of procedure localmin with fixed eps=0.5*sqrt(eps_d). }
  { ic is the iteration count, -1 if a=b, 0 if max.=5000 exceeded.}
begin
   mbrent(f, a, b, t, x, fx, ic);
end;


function damath_zbrent(f: TFuncD;  a,b,t: double; var ic,err: integer): double;  cdecl; export;
  {-Brent/Dekker algorithm with guaranteed convergence for finding a zero  }
  { of a function: Return a zero x of the function f in the interval [a,b] }
  { to within a tolerance 6*eps_d*|x|+2*t, where t is a positive tolerance;}
  { assumes that f(a) and f(b) have different signs. ic is the iteration   }
  { count; err is an error code (0: no error, -1: if f(a) and f(b) have the}
  { same sign, -2: max. iteration count exceeded). The algorithm is based  }
  { on a combination of successive interpolations and bisection.           }
begin
   damath_zbrent := zbrent(f, a, b, t, ic, err);
end;



function damath_zeroin(f: TFuncD;  a,b,t: double): double;  cdecl; export;
  {-Return a zero x of the function f in the interval [a, b] to within a  }
  { tolerance 6*eps_d*|x| + 2*t, where t is a positive tolerance, assumes }
  { that f(a) and f(b) have different signs. Simplified version of zbrent.}
begin
   damath_zeroin:= zeroin(f, a, b, t);
end;



procedure damath_quanc8(f: TFuncD; a,b,abserr,relerr: double;
                 var result, errest, flag: double; var nofun: longint);
  {-Estimate the integral of fun(x) from a to b to a user provided tolerance.}
  { Pascal translation of the Fortran subroutine by Forsythe, Malcolm, Moler.}
begin
   quanc8(f, a, b, abserr, relerr, result, errest, flag, nofun);
end;



procedure damath_qags(f: TFuncD;  a, b, epsabs, epsrel: double; limit: integer;
               var result, abserr: double; var neval: longint; var ier: integer);  cdecl; export;
  {-Global adaptive quadrature of f over (a,b) based on 21-point Gauss-Kronrod}
  { rule for the subintervals, with acceleration by Wynn's epsilon algorithm.}
  { Simplified user interface to procedure qagse}
begin
   qags(f, a, b, epsabs, epsrel, limit, result, abserr, neval, ier);
end;



procedure damath_qagi(f: TFuncD;  bound: double;inf: integer; epsabs, epsrel: double; limit: integer;
               var result, abserr: double; var neval: longint; var ier: integer);  cdecl; export;
  {-Global adaptive quadrature of f over an infinite interval based on trans- }
  { formed 15-point Gauss-Kronrod rule for the subintervals, with acceleration}
  { by Wynn's epsilon algorithm. Simplified user interface to procedure qagie.} 
begin
   qagi(f, bound, inf, epsabs, epsrel, limit, result, abserr, neval, ier);
end;


procedure damath_qawc(f: TFuncD;  a, b, c, epsabs, epsrel: double;
               limit: integer; var result, abserr: double;
               var neval: longint; var ier: integer);  cdecl; export;
  {-Adaptive quadrature of the function f(x)/(x-c) over the finite interval}
  { (a,b) with the singularity at c with c<>a, c<>b. The routine calculates}
  { an approximation result to the Cauchy principal value.  Simplified user}
  { interface to procedure qawce. Parameters:}
begin
   qawc(f, a, b, c, epsabs, epsrel, limit, result, abserr, neval, ier);
end;



procedure damath_intde(f: TFuncD;  a, b, eps: double; var result, abserr: double;
                var neval: longint; var ier: integer);  cdecl; export;
  {-Automatic quadrature of f(x) over the finite interval (a,b)}
  { using Double Exponential (DE) transformation. Parameters:  }
begin
   intde(f, a, b, eps, result, abserr, neval, ier);
end;



procedure damath_intdei(f: TFuncD;  a, eps: double; var result, abserr: double;
                var neval: longint; var ier: integer);  cdecl; export;
  {-Automatic quadrature of f(x) over (a,INF) using Double Exponential}
  { transformation when f(x) has no oscillatory factor. Parameters:   }  
begin
   intdei(f, a, eps, result, abserr, neval, ier);
end;


procedure damath_intdeo(f: TFuncD;  a, omega, eps: double; var result, abserr: double;
                var neval: longint; var ier: integer);  cdecl; export;
  {-Automatic quadrature of f(x) over (a,INF) using Double Exponential}
  { transformation when f(x) has an oscillatory factor. Parameters:   } 
begin
   intdeo(f, a, omega, eps, result, abserr, neval, ier);
end;




{#Z+}
{---------------------------------------------------------------------------}
{---------------------- Elementary numerical functions ---------------------}
{---------------------------------------------------------------------------}
{#Z-}

function damath_sqrt(x: double): double; cdecl; export;
  {-Return the cube root of x}
begin
    damath_sqrt:= (sqrt(x));
end;


function damath_cbrt(x: double): double; cdecl; export;
  {-Return the cube root of x}
begin
    damath_cbrt:= (cbrt(x));
end;



function damath_ceil(x: double): longint; cdecl; export;
  {-Return the smallest integer >= x; |x|<=MaxLongint}
begin
    damath_ceil:= ceil(x);
end;




function damath_ceild(x: double): double; cdecl; export;
  {-Return the smallest integer >= x}
begin
    damath_ceild:= (ceild(x));
end;




function damath_floor(x: double): longint; cdecl; export;
  {-Return the largest integer <= x; |x|<=MaxLongint}
begin
    damath_floor:= floor(x);
end;




function damath_floord(x: double): double; cdecl; export;
  {-Return the largest integer <= x}
begin
    damath_floord:= (floord(x));
end;




function damath_fmod(x,y: double): double; cdecl; export;
  {-Return x mod y, y<>0, sign(result) = sign(x)}
begin
    damath_fmod:= (fmod(x, y));
end;




function damath_hypot(x,y: double): double; cdecl; export;
  {-Return sqrt(x*x + y*y)}
begin
    damath_hypot:= (hypot(x, y));
end;




function damath_hypot3(x,y,z: double): double; cdecl; export;
  {-Return sqrt(x*x + y*y + z*z)}
begin
    damath_hypot3:= (hypot3(x, y, z));
end;




function damath_intpower(x: double; n: longint): double; cdecl; export;
  {-Return x^n; via binary exponentiation (no overflow detection)}
begin
    damath_intpower:= (intpower(x, n));
end;




function damath_modf(x: double; var ip: longint): double; cdecl; export;
  {-Return frac(x) and trunc(x) in ip, |x|<=MaxLongint}
begin
    damath_modf:= (modf(x, ip));
end;




function damath_nroot(x: double; n: integer): double; cdecl; export;
  {-Return the nth root of x; n<>0, x >= 0 if n is even}
begin
    damath_nroot:= (nroot(x, n));
end;




function damath_remainder(x,y: double): double; cdecl; export;
  {-Return the IEEE754 remainder x REM y = x - rmNearest(x/y)*y}
begin
    damath_remainder:= (remainder(x, y));
end;




function damath_sqrt1pm1(x: double): double; cdecl; export;
  {-Return sqrt(1+x)-1, accurate even for x near 0, x>=-1}
begin
    damath_sqrt1pm1:= (sqrt1pm1(x));
end;



function damath_sqrt1pmx(x: double): double; cdecl; export;
  {-Return sqrt(1+x)-1, accurate even for x near 0, x>=-1}
begin
    damath_sqrt1pmx:= (sqrt1pmx(x));
end;






{*************************Floating point functions (Amath)***********************************************}


function  damath_copysignd(x,y: double): double; cdecl; export;  
  {-Return abs(x)*sign(y)}
begin
    damath_copysignd := copysignd(x, y);
end;




procedure damath_frexpd(d: double; var m: double; var e: longint); cdecl; export;
  {-Return the mantissa m and exponent e  of d with d = m*2^e, 0.5 < m < 1;}
  { if d is 0, +-INF, NaN, return m=d, e=0}
begin
    frexpd(d, m, e);
end;


function  damath_ldexpd(d: double; e: longint): double; cdecl; export;
  {-Return d*2^e}
begin
    damath_ldexpd:= ldexpd(d, e);
end;


function  damath_predd(d: double): double; cdecl; export;
  {-Return next representable double after d in the direction -Inf}
begin
    damath_predd:= predd(d);
end;



function  damath_succd(d: double): double; cdecl; export;
  {-Return next representable double after d in the direction +Inf}
begin
    damath_succd:= succd(d);
end;


function  damath_ulpd(d: double): double; cdecl; export;
  {-Return the 'unit in the last place': ulpd(d)=|d|-predd(|d|) for finite d}
begin
    damath_ulpd:= ulpd(d);
end;


function damath_maxd(x, y: double): double; cdecl; export;  
  {-Return the maximum of two doubles; x,y <> NAN}
begin
    damath_maxd:= maxd(x, y);
end;


function damath_mind(x, y: double): double; cdecl; export;  
  {-Return the maximum of two doubles; x,y <> NAN}
begin
    damath_mind:= mind(x, y);
end;




{************************************************************************}






{#Z+}
{---------------------------------------------------------------------------}
{----------------------- Floating point functions --------------------------}
{---------------------------------------------------------------------------}
{#Z-}
function  damath_ilogb(x: double): longint; cdecl; export;
  {-Return base 2 exponent of x. For finite x ilogb = floor(log2(|x|))}
  { otherwise -MaxLongint for x=0 and MaxLongint if x = +-INF or Nan. }
begin
    damath_ilogb:= ilogb(x);
end;



function  damath_rint(x: double): double; cdecl; export;
  {-Return the integral value nearest x for the current rounding mode}
begin
    damath_rint:= rint(x);
end;




function  damath_scalbn(x: double; e: longint): double; cdecl; export;
  {-Return x*2^e}
begin
    damath_scalbn:= scalbn(x, e);
end;





{#Z+}
{---------------------------------------------------------------------------}
{------------------- Elementary transcendental functions -------------------}
{---------------------------------------------------------------------------}
{#Z-}

function damath_arccos(x: double): double; cdecl; export;
  {-Return the inverse circular cosine of x, |x| <= 1}
begin
    damath_arccos:= (arccos(x));
end;


function damath_arccos1m(x: double): double; cdecl; export;
  {-Return arccos(1-x), 0 <= x <= 2, accurate even for x near 0}
begin
    damath_arccos1m:= (arccos1m(x));
end;



function damath_arccosd(x: double): double; cdecl; export;
  {-Return the inverse circular cosine of x, |x| <= 1, result in degrees}
begin
    damath_arccosd:= (arccosd(x));
end;




function damath_arccosh(x: double): double; cdecl; export;
  {-Return the inverse hyperbolic cosine, x >= 1. Note: for x near 1 the }
  { function arccosh1p(x-1) should be used to reduce cancellation errors!}
begin
    damath_arccosh:= (arccosh(x));
end;




function damath_arccosh1p(x: double): double; cdecl; export;
  {-Return arccosh(1+x), x>=0, accurate even for x near 0}
begin
    damath_arccosh1p:= (arccosh1p(x));
end;




function damath_arccot(x: double): double; cdecl; export;
  {-Return the sign symmetric inverse circular cotangent; arccot(x) = arctan(1/x), x <> 0}
begin
    damath_arccot:= (arccot(x));
end;




function damath_arccotc(x: double): double; cdecl; export;
  {-Return the continuous inverse circular cotangent; arccotc(x) = Pi/2 - arctan(x)}
begin
    damath_arccotc:= (arccotc(x));
end;




function damath_arccotcd(x: double): double; cdecl; export;
  {-Return the continuous inverse circular cotangent;}
  { arccotcd(x) = 90 - arctand(x), result in degrees }
begin
    damath_arccotcd:= (arccotcd(x));
end;




function damath_arccotd(x: double): double; cdecl; export;
  {-Return the sign symmetric inverse circular cotangent,}
  { arccotd(x) = arctand(1/x), x <> 0, result in degrees }
begin
    damath_arccotd:= (arccotd(x));
end;




function damath_arccoth(x: double): double; cdecl; export;
  {-Return the inverse hyperbolic cotangent of x, |x| > 1}
begin
    damath_arccoth:= (arccoth(x));
end;




function damath_arccsc(x: double): double; cdecl; export;
  {-Return the inverse cosecant of x, |x| >= 1}
begin
    damath_arccsc:= (arccsc(x));
end;




function damath_arccsch(x: double): double; cdecl; export;
  {-Return the inverse hyperbolic cosecant of x, x <> 0}
begin
    damath_arccsch:= (arccsch(x));
end;




function damath_arcgd(x: double): double; cdecl; export;
  {-Return the inverse Gudermannian function arcgd(x), |x| < Pi/2}
begin
    damath_arcgd:= (arcgd(x));
end;




function damath_archav(x: double): double; cdecl; export;
  {-Return the inverse haversine archav(x), 0 <= x <= 1}
begin
    damath_archav:= (archav(x));
end;




function damath_arcsec(x: double): double; cdecl; export;
  {-Return the inverse secant of x, |x| >= 1}
begin
    damath_arcsec:= (arcsec(x));
end;




function damath_arcsech(x: double): double; cdecl; export;
  {-Return the inverse hyperbolic secant of x, 0 < x <= 1}
begin
    damath_arcsech:= (arcsech(x));
end;




function damath_arcsin(x: double): double; cdecl; export;
  {-Return the inverse circular sine of x, |x| <= 1}
begin
    damath_arcsin:= (arcsin(x));
end;




function damath_arcsind(x: double): double; cdecl; export;
  {-Return the inverse circular sine of x, |x| <= 1, result in degrees}
begin
    damath_arcsind:= (arcsind(x));
end;




function damath_arcsinh(x: double): double; cdecl; export;
  {-Return the inverse hyperbolic sine of x}
begin
    damath_arcsinh:= (arcsinh(x));
end;




function damath_arctan2(y, x: double): double; cdecl; export;
  {-Return arctan(y/x); result in [-Pi..Pi] with correct quadrant}
begin
    damath_arctan2:= (arctan2(x, y));
end;




function damath_arctand(x: double): double; cdecl; export;
  {-Return the inverse circular tangent of x, result in degrees}
begin
    damath_arctand:= (arctand(x));
end;



function damath_arctan(x: double): double; cdecl; export;
  {-Return the inverse circular tangent of x}
begin
    damath_arctan:= (arctan(x));
end;





function damath_arctanh(x: double): double; cdecl; export;
  {-Return the inverse hyperbolic tangent of x, |x| < 1}
begin
    damath_arctanh:= (arctanh(x));
end;




function damath_compound(x: double; n: longint): double; cdecl; export;
  {-Return (1+x)^n; accurate version of Delphi/VP internal function}
begin
    damath_compound:= (compound(x, n));
end;



function damath_comprel(x: double; n: longint): double; cdecl; export;
  {-Return (1+x)^n; accurate version of Delphi/VP internal function}
begin
    damath_comprel:= (comprel(x, n));
end;



function damath_cos(x: double): double; cdecl; export;
  {-Accurate version of circular cosine, uses system.cos for |x| <= Pi/4}
begin
    damath_cos:= (cos(x));
end;




function damath_cosd(x: double): double; cdecl; export;
  {-Return cos(x), x in degrees}
begin
    damath_cosd:= (cosd(x));
end;




function damath_cosh(x: double): double; cdecl; export;
  {-Return the hyperbolic cosine of x}
begin
    damath_cosh:= (cosh(x));
end;




function damath_coshm1(x: double): double; cdecl; export;
  {-Return cosh(x)-1, accurate even for x near 0}
begin
    damath_coshm1:= (coshm1(x));
end;



function damath_cosPi(x: double): double; cdecl; export;
  {-Return cos(Pi*x), result will be 1 for abs(x) >= 2^52}
begin
    damath_cosPi:= (cosPi(x));
end;




function damath_cot(x: double): double; cdecl; export;
  {-Return the circular cotangent of x, x mod Pi <> 0}
begin
    damath_cot:= (cot(x));
end;




function damath_cotd(x: double): double; cdecl; export;
  {-Return cot(x), x in degrees}
begin
    damath_cotd:= (cotd(x));
end;




function damath_coth(x: double): double; cdecl; export;
  {-Return the hyperbolic cotangent of x, x<>0}
begin
    damath_coth:= (coth(x));
end;




function damath_covers(x: double): double; cdecl; export;
  {-Return the coversine covers(x) = 1 - sin(x)}
begin
    damath_covers:= (covers(x));
end;




function damath_csc(x: double): double; cdecl; export;
  {-Return the circular cosecant of x, x mod Pi <> 0}
begin
    damath_csc:= (csc(x));
end;



function damath_csch(x: double): double; cdecl; export;
  {-Return the hyperbolic cosecant of x, x<>0}
begin
    damath_csch:= (csch(x));
end;




function damath_exp(x: double): double; cdecl; export;
  {-Return exp(x), overflow if x>ln_MaxDbl}
begin
    damath_exp:= (exp(x));
end;




function damath_exp10(x: double): double; cdecl; export;
  {-Return 10^x}
begin
    damath_exp10:= (exp10(x));
end;




function damath_exp10m1(x: double): double; cdecl; export;
  {-Return 10^x - 1; special code for small x}
begin
    damath_exp10m1:= (exp10m1(x));
end;




function damath_exp2(x: double): double; cdecl; export;
  {-Return 2^x}
begin
    damath_exp2:= (exp2(x));
end;




function damath_exp2m1(x: double): double; cdecl; export;
  {-Return 2^x-1, accurate even for x near 0}
begin
    damath_exp2m1:= (exp2m1(x));
end;




function damath_exp3(x: double): double; cdecl; export;
  {-Return 3^x}
begin
    damath_exp3:= (exp3(x));
end;




function damath_exp5(x: double): double; cdecl; export;
  {-Return 5^x}
begin
    damath_exp5:= (exp5(x));
end;




function damath_exp7(x: double): double; cdecl; export;
  {-Return 7^x}
begin
    damath_exp7:= (exp7(x));
end;




function damath_expm1(x: double): double; cdecl; export;
  {-Return exp(x)-1, accurate even for x near 0}
begin
    damath_expm1:= (expm1(x));
end;




function damath_expmx2h(x: double): double; cdecl; export;
  {-Return exp(-0.5*x^2) with damped error amplification}
begin
    damath_expmx2h:= (expmx2h(x));
end;



function damath_exprel(x: double): double; cdecl; export;
  {-Return exprel(x) = (exp(x) - 1)/x,  1 for x=0}
begin
    damath_exprel:= (exprel(x));
end;




function damath_expx2(x: double): double; cdecl; export;
  {-Return exp(x*|x|) with damped error amplification in computing exp of the product.}
  { Used for exp(x^2) = expx2(abs(x)) and exp(-x^2) = expx2(-abs(x))}
begin
    damath_expx2:= (expx2(x));
end;






function damath_gd(x: double): double; cdecl; export;
  {-Return the Gudermannian function gd(x)}
begin
    damath_gd:= (gd(x));
end;




function damath_hav(x: double): double; cdecl; export;
  {-Return the haversine hav(x) = 0.5*(1 - cos(x))}
begin
    damath_hav:= (hav(x));
end;





function damath_ln(x: double): double; cdecl; export;
  {-Return natural logarithm of x, x may be denormal}
begin
    damath_ln:= (ln(x));
end;




function damath_ln1mexp(x: double): double; cdecl; export;
  {-Return ln(1-exp(x)), x<0}
begin
    damath_ln1mexp:= (ln1mexp(x));
end;




function damath_ln1p(x: double): double; cdecl; export;
  {-Return ln(1+x), accurate even for x near 0}
begin
    damath_ln1p:= (ln1p(x));
end;




function damath_ln1pexp(x: double): double; cdecl; export;
  {-Return ln(1+x)-x, x>-1, accurate even for -0.5 <= x <= 1.0}
begin
    damath_ln1pexp:= (ln1pexp(x));
end;




function damath_ln1pmx(x: double): double; cdecl; export;
  {-Return ln(1+x)-x, x>-1, accurate even for -0.5 <= x <= 1.0}
begin
    damath_ln1pmx:= (ln1pmx(x));
end;



function damath_lncosh(x: double): double; cdecl; export;
  {-Return ln(1+x)-x, x>-1, accurate even for -0.5 <= x <= 1.0}
begin
    damath_lncosh:= (lncosh(x));
end;



function damath_lnsinh(x: double): double; cdecl; export;
  {-Return ln(1+x)-x, x>-1, accurate even for -0.5 <= x <= 1.0}
begin
    damath_lnsinh:= (lnsinh(x));
end;




function damath_log10(x: double): double; cdecl; export;
  {-Return base 10 logarithm of x}
begin
    damath_log10:= (log10(x));
end;




function damath_log10p1(x: double): double; cdecl; export;
  {-Return log10(1+x), accurate even for x near 0}
begin
    damath_log10p1:= (log10p1(x));
end;




function damath_log2(x: double): double; cdecl; export;
  {-Return base 2 logarithm of x}
begin
    damath_log2:= (log2(x));
end;




function damath_log2p1(x: double): double; cdecl; export;
  {-Return log2(1+x), accurate even for x near 0}
begin
    damath_log2p1:= (log2p1(x));
end;




function damath_logaddexp(x, y : double): double; cdecl; export;
  {-Accurately compute ln[exp(x) + exp(y)]}
begin
    damath_logaddexp:= (logaddexp(x, y));
end;



function damath_logbase(b, x: double): double; cdecl; export;
  {-Return base b logarithm of x}
begin
    damath_logbase:= (logbase(b, x));
end;




function damath_logistic(x: double): double; cdecl; export;
  {-Return logistic(x) = 1/(1+exp(-x))}
begin
    damath_logistic:= (logistic(x));
end;




function damath_logit(x: double): double; cdecl; export;
  {-Return logit(x) = ln(x/(1.0-x)), accurate near x=0.5}
begin
    damath_logit:= (logit(x));
end;




function damath_logsubexp(x, y : double): double; cdecl; export;
  {-Accurately compute ln[exp(x) + exp(y)]}
begin
    damath_logsubexp:= (logsubexp(x, y));
end;




function damath_pow1p(x,y: double): double; cdecl; export;
  {-Return (1+x)^y, x > -1}
begin
    damath_pow1p:= (pow1p(x, y));
end;



function damath_pow1pf(x,y: double): double; cdecl; export;
  {-Return (1+x)^y, x > -1}
begin
    damath_pow1pf:= (pow1pf(x, y));
end;




function damath_pow1pm1(x,y: double): double; cdecl; export;
  {-Return (1+x)^y - 1; special code for small x,y}
begin
    damath_pow1pm1:= (pow1pm1(x, y));
end;




function damath_power(x, y : double): double; cdecl; export;
  {-Return x^y; if frac(y)<>0 then x must be > 0}
begin
    damath_power:= (power(x, y));
end;




function damath_powm1(x,y: double): double; cdecl; export;
  {-Return x^y - 1; special code for small x,y}
begin
    damath_powm1:= (powm1(x, y));
end;



function damath_powpi(n: longint): double; cdecl; export;
  {-Return accurate powers of Pi, result = Pi^n}
begin
    damath_powpi:= (powpi(n));
end;




function damath_powpi2k(k,n: longint): double; cdecl; export;
  {-Return accurate scaled powers of Pi, result = (Pi*2^k)^n}
begin
    damath_powpi2k:= (powpi2k(k, n));
end;





function damath_sec(x: double): double; cdecl; export;
  {-Return the circular secant of x, x mod Pi <> Pi/2}
begin
    damath_sec:= (sec(x));
end;




function damath_sech(x: double): double; cdecl; export;
  {-Return the hyperbolic secant of x}
begin
    damath_sech:= (sech(x));
end;




function damath_sin(x: double): double; cdecl; export;
  {-Accurate version of circular sine, uses system.sin for |x| <= Pi/4}
begin
    damath_sin:= (sin(x));
end;




procedure damath_sincos(x: double; var s,c: double); cdecl; export;
  {-Return accurate values s=sin(x), c=cos(x)}
    var sx, cx: double;   
begin    
    sincos(x, sx, cx);
    s := (sx);
    c := (cx);
end;




procedure damath_sincosd(x: double; var s,c: double); cdecl; export;
  {-Return sin(x) and cos(x), x in degrees}
    var sx, cx: double;   
begin    
    sincosd(x, sx, cx);
    s := (sx);
    c := (cx);
end;




procedure damath_sincosPi(x: double; var s,c: double); cdecl; export;
  {-Return s=sin(Pi*x), c=cos(Pi*x); (s,c)=(0,1) for abs(x) >= 2^52}
    var sx, cx: double;   
begin    
    sincosPi(x, sx, cx);
    s := (sx);
    c := (cx);
end;




procedure damath_sinhcosh(x: double; var s,c: double); cdecl; export;
  {-Return s=sinh(x) and c=cosh(x)}
    var sx, cx: double;   
begin    
    sinhcosh(x, sx, cx);
    s := (sx);
    c := (cx);
end;




function damath_sinc(x: double): double; cdecl; export;
  {-Return the cardinal sine sinc(x) = sin(x)/x}
begin
    damath_sinc:= (sinc(x));
end;




function damath_sincPi(x: double): double; cdecl; export;
  {-Return the normalised cardinal sine sincPi(x) = sin(Pi*x)/(Pi*x)}
begin
    damath_sincPi:= (sincPi(x));
end;




function damath_sind(x: double): double; cdecl; export;
  {-Return sin(x), x in degrees}
begin
    damath_sind:= (sind(x));
end;




function damath_sinh(x: double): double; cdecl; export;
  {-Return the hyperbolic sine of x, accurate even for x near 0}
begin
    damath_sinh:= (sinh(x));
end;




function damath_sinhc(x: double): double; cdecl; export;
  {-Return sinh(x)/x, accurate even for x near 0}
begin
    damath_sinhc:= (sinhc(x));
end;




function damath_sinhmx(x: double): double; cdecl; export;
  {-Return sinh(x)-x, accurate even for x near 0}
begin
    damath_sinhmx:= (sinhmx(x));
end;




function damath_sinPi(x: double): double; cdecl; export;
  {-Return sin(Pi*x), result will be 0 for abs(x) >= 2^52}
begin
    damath_sinPi:= (sinPi(x));
end;




function damath_tan(x: double): double; cdecl; export;
  {-Return the circular tangent of x, x mod Pi <> Pi/2}
begin
    damath_tan:= (tan(x));
end;




function damath_tand(x: double): double; cdecl; export;
  {-Return tan(x), x in degrees}
begin
    damath_tand:= (tand(x));
end;




function damath_tanh(x: double): double; cdecl; export;
  {-Return the hyperbolic tangent of x, accurate even for x near 0}
begin
    damath_tanh:= (tanh(x));
end;




function damath_tanPi(x: double): double; cdecl; export;
  {-Return the hyperbolic tangent of x, accurate even for x near 0}
begin
    damath_tanPi:= (tanPi(x));
end;




function damath_vers(x: double): double; cdecl; export;
  {-Return the versine vers(x) = 1 - cos(x)}
begin
    damath_vers:= (vers(x));
end;




function damath_versint(x: double): double; cdecl; export;
  {-Return versint(x) = integral(vers(t),t=0..x) = x - sin(x), accurate near 0}
begin
    damath_versint:= (versint(x));
end;






{**************************Bessel functions**********************************************}


{**************************  Bessel functions of integer order  *************************}



function damath_bessel_j0(x: double): double; cdecl; export;
  {-Return J0(x), the Bessel function of the 1st kind, order zero}
begin
    damath_bessel_j0:= bessel_j0(x);
end;


function damath_bessel_j1(x: double): double; cdecl; export;
  {-Return J1(x), the Bessel function of the 1st kind, order one}
begin
    damath_bessel_j1:= bessel_j1(x);
end;


function damath_bessel_jn(n: integer; x: double): double; cdecl; export;
  {-Return J_n(x), the Bessel function of the 1st kind, order n; not suitable for large n or x.}
begin
    damath_bessel_jn:= bessel_jn(n, x);
end;



function damath_bessel_y0(x: double): double; cdecl; export;
  {-Return Y0(x), the Bessel function of the 2nd kind, order zero; x>0}
begin
    damath_bessel_y0:= bessel_y0(x);
end;


function damath_bessel_y1(x: double): double; cdecl; export;
  {-Return Y1(x), the Bessel function of the 2nd kind, order one; x>0}
begin
    damath_bessel_y1:= bessel_y1(x);
end;

function damath_bessel_yn(n: integer; x: double): double; cdecl; export;
  {-Return Y_n(x), the Bessel function of the 2nd kind, order n, x>0, not suitable for large n or x}
begin
    damath_bessel_yn:= bessel_yn(n, x);
end;



{**************************  Modified Bessel functions of integer order  **********************************************}


function damath_bessel_i0(x: double): double; cdecl; export;
  {-Return I0(x), the modified Bessel function of the 1st kind, order zero}
begin
    damath_bessel_i0:= bessel_i0(x);
end;


function damath_bessel_i0e(x: double): double; cdecl; export;
  {-Return I0(x)*exp(-|x|), the exponentially scaled modified Bessel function of the 1st kind, order zero}
begin
    damath_bessel_i0e:= bessel_i0e(x);
end;


function damath_bessel_i1(x: double): double; cdecl; export;
  {-Return I1(x), the modified Bessel function of the 1st kind, order one}
begin
    damath_bessel_i1:= bessel_i1(x);
end;


function damath_bessel_i1e(x: double): double; cdecl; export;
  {-Return I1(x)*exp(-|x|), the exponentially scaled modified Bessel function of the 1st kind, order one}
begin
    damath_bessel_i1e:= bessel_i1e(x);
end;


function damath_bessel_in(n: integer; x: double): double; cdecl; export;
  {-Return I_n(x), the modified Bessel function of the 1st kind, order n; not suitable for large n or x.}
begin
    damath_bessel_in:= bessel_in(n, x);
end;


function damath_bessel_k0(x: double): double; cdecl; export;
  {-Return K0(x), the modified Bessel function of the 2nd kind, order zero, x>0}
begin
    damath_bessel_k0:= bessel_k0(x);
end;


function damath_bessel_k0e(x: double): double; cdecl; export;
  {-Return K0(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order zero, x>0}
begin
    damath_bessel_k0e:= bessel_k0e(x);
end;


function damath_bessel_k1(x: double): double; cdecl; export;
  {-Return K1(x), the modified Bessel function of the 2nd kind, order one, x>0}
begin
    damath_bessel_k1:= bessel_k1(x);
end;


function damath_bessel_k1e(x: double): double; cdecl; export;
  {-Return K1(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order one, x>0}
begin
    damath_bessel_k1e:= bessel_k1e(x);
end;


function damath_bessel_kn(n: integer; x: double): double; cdecl; export;
  {-Return K_n(x), the modified Bessel function of the 2nd kind, order n, x>0, not suitable for large n}
begin
    damath_bessel_kn:= bessel_kn(n, x);
end;





{**************************  Modified Bessel functions of real order  **********************************************}


function damath_bessel_jv(v, x: double): double; cdecl; export;
  {-Return J_v(x), the Bessel function of the 1st kind, order v; not suitable for large v.}
begin
    damath_bessel_jv:= bessel_jv(v, x);
end;


function damath_bessel_yv(v, x: double): double; cdecl; export;
  {-Return Y_v(x), the Bessel function of the 2nd kind, order v; x > 0; not suitable for large v.}
begin
    damath_bessel_yv:= bessel_yv(v, x);
end;


function damath_bessel_lambda(v, x: double): double; cdecl; export;
  {-Compute lambda(v,x) = Gamma(v+1)*J(v,x)/(0.5x)^v for v,x >= 0}
begin
    damath_bessel_lambda:= bessel_lambda(v, x);
end;




{**************************  Modified Bessel functions of real order  **********************************************}


function damath_bessel_iv(v, x: double): double; cdecl; export;
  {-Return I_v(x), the modified Bessel function of the 1st kind, order v.}
begin
    damath_bessel_iv:= bessel_iv(v, x);
end;


function damath_bessel_ive(v, x: double): double; cdecl; export;
  {-Return I_v(x)*exp(-|x|), the exponentially scaled modified Bessel function of the 1st kind, order v.}
begin
    damath_bessel_ive:= bessel_ive(v, x);
end;




function damath_bessel_kv(v, x: double): double; cdecl; export;
  {-Return K_v(x), the modified Bessel function of the 2nd kind, order v, x>0}
begin
    damath_bessel_kv:= bessel_kv(v, x);
end;


function damath_bessel_kve(v, x: double): double; cdecl; export;
  {-Return K_v(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order v, x>0}
begin
    damath_bessel_kve:= bessel_kve(v, x);
end;




{**************************  Integrals of zero-order Bessel functions  **********************************************}


function damath_bessel_i0_int(x: double): double; cdecl; export;
  {-Return K1(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order one, x>0}
begin
    damath_bessel_i0_int:= bessel_i0_int(x);
end;


function damath_bessel_j0_int(x: double): double; cdecl; export;
  {-Return K1(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order one, x>0}
begin
    damath_bessel_j0_int:= bessel_j0_int(x);
end;


function damath_bessel_k0_int(x: double): double; cdecl; export;
  {-Return K1(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order one, x>0}
begin
    damath_bessel_k0_int:= bessel_k0_int(x);
end;


function damath_bessel_y0_int(x: double): double; cdecl; export;
  {-Return K1(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order one, x>0}
begin
    damath_bessel_y0_int:= bessel_y0_int(x);
end;





{**************************  Spherical Bessel functions  **********************************************}


function damath_sph_bessel_jn(n: integer; x: double): double; cdecl; export;
  {-Return j_n(x), the spherical Bessel function of the 1st kind, order n}
begin
    damath_sph_bessel_jn:= sph_bessel_jn(n, x);
end;


function damath_sph_bessel_yn(n: integer; x: double): double; cdecl; export;
  {-Return y_n(x), the spherical Bessel function of the 2nd kind, order n >=0 , x<>0}
begin
    damath_sph_bessel_yn:= sph_bessel_yn(n, x);
end;


function damath_sph_bessel_in(n: integer; x: double): double; cdecl; export;
  {-Return i_n(x), the modified spherical Bessel function of the 1st/2nd kind, order n}
begin
    damath_sph_bessel_in:= sph_bessel_in(n, x);
end;


function damath_sph_bessel_ine(n: integer; x: double): double; cdecl; export;
  {-Return i_n(x)*exp(-|x|), the exponentially scaled modified spherical Bessel function of the 1st/2nd kind, order n}
begin
    damath_sph_bessel_ine:= sph_bessel_ine(n, x);
end;


function damath_sph_bessel_kn(n: integer; x: double): double; cdecl; export;
  {-Return k_n(x), the modified spherical Bessel function of the 3rd kind, order n, x>0}
begin
    damath_sph_bessel_kn:= sph_bessel_kn(n, x);
end;


function damath_sph_bessel_kne(n: integer; x: double): double; cdecl; export;
  {-Return k_n(x)*exp(x), the exponentially scaled modified spherical Bessel function of the 3rd kind, order n, x>0}
begin
    damath_sph_bessel_kne:= sph_bessel_kne(n, x);
end;



{**************************Airy functions**********************************************}




function damath_airy_ai(x: double): double; cdecl; export;
  {-Return the Airy function Ai(x)}
begin
    damath_airy_ai:= airy_ai(x);
end;


function damath_airy_aip(x: double): double; cdecl; export;
  {-Return the Airy function Ai'(x)}
begin
    damath_airy_aip:= airy_aip(x);
end;


function damath_airy_ais(x: double): double; cdecl; export;
  {-Return the scaled Airy function Ai(x) if x <= 0, Ai(x)*exp(2/3*x^1.5) for x > 0}
begin
    damath_airy_ais:= airy_ais(x);
end;


function damath_airy_bi(x: double): double; cdecl; export;
  {-Return the Airy function Bi(x)}
begin
    damath_airy_bi:= airy_bi(x);
end;


function damath_airy_bip(x: double): double; cdecl; export;
  {-Return the Airy function Bi'(x)}
begin
    damath_airy_bip:= airy_bip(x);
end;


function damath_airy_bis(x: double): double; cdecl; export;
  {-Return the scaled Airy function Bi(x) if x <= 0, Bi(x)*exp(-2/3*x^1.5) for x > 0}
begin
    damath_airy_bis:= airy_bis(x);
end;


function damath_airy_gi(x: double): double; cdecl; export;
  {-Return the Airy/Scorer function Gi(x) = 1/Pi*integral(sin(x*t+t^3/3), t=0..INF)}
begin
    damath_airy_gi:= airy_gi(x);
end;


function damath_airy_hi(x: double): double; cdecl; export;
  {-Return the Airy/Scorer function Hi(x) = 1/Pi*integral(exp(x*t-t^3/3), t=0..INF)}
begin
    damath_airy_hi:= airy_hi(x);
end;






{**************************Kelvin functions**********************************************}



function damath_kelvin_bei(x: double): double; cdecl; export;
  {-Return the Kelvin function bei(x)}
begin
    damath_kelvin_bei:= kelvin_bei(x);
end;



function damath_kelvin_beip(x: double): double; cdecl; export;
  {-Return the Kelvin function bei'(x)}
begin
    damath_kelvin_beip:= kelvin_beip(x);
end;



function damath_kelvin_ber(x: double): double; cdecl; export;
  {-Return the Kelvin function ber(x)}
begin
    damath_kelvin_ber:= kelvin_ber(x);
end;



function damath_kelvin_berp(x: double): double; cdecl; export;
  {-Return the Kelvin function ber'(x)}
begin
    damath_kelvin_berp:= kelvin_berp(x);
end;


function damath_kelvin_kei(x: double): double; cdecl; export;
  {-Return the Kelvin function kei(x), x >= 0}
begin
    damath_kelvin_kei:= kelvin_kei(x);
end;


function damath_kelvin_keip(x: double): double; cdecl; export;
  {-Return the Kelvin function kei'(x), x >= 0}
begin
    damath_kelvin_keip:= kelvin_keip(x);
end;




function damath_kelvin_ker(x: double): double; cdecl; export;
  {-Return the Kelvin function ker(x), x > 0}
begin
    damath_kelvin_ker:= kelvin_ker(x);
end;



function damath_kelvin_kerp(x: double): double; cdecl; export;
  {-Return the Kelvin function ker(x), x > 0}
begin
    damath_kelvin_kerp:= kelvin_kerp(x);
end;




procedure damath_kelvin_der(x: double; var berp, beip, kerp, keip: double); cdecl; export;
  {-Return the Kelvin functions kr=ker(x), ki=kei(x), x > 0}
begin
    kelvin_der(x, berp, beip, kerp, keip);
end;



procedure damath_kelvin_kerkei(x: double; var kr, ki: double); cdecl; export;
  {-Return the Kelvin functions kr=ker(x), ki=kei(x), x > 0}
begin
    kelvin_kerkei(x, kr, ki);
end;


procedure damath_kelvin_berbei(x: double; var br, bi: double); cdecl; export;
  {-Return the Kelvin functions br=ber(x), bi=bei(x)}
begin
    kelvin_berbei(x, br, bi);
end;



{**************************Struve functions**********************************************}


function damath_struve_h0(x: double): double; cdecl; export;
 {-Return H0(x), the Struve function of order 0}
begin
    damath_struve_h0:= struve_h0(x);
end;


function damath_struve_h1(x: double): double; cdecl; export;
  {-Return H1(x), the Struve function of order 1}
begin
    damath_struve_h1:= struve_h1(x);
end;


function damath_struve_h(v, x: double): double; cdecl; export;
  {-Return H_v(x), the Struve function of order v, x < 0 only if v is an integer.}
begin
    damath_struve_h:= struve_h(v, x);
end;


function damath_struve_l0(x: double): double; cdecl; export;
  {-Return L0(x), the modified Struve function of order 0}
begin
    damath_struve_l0:= struve_l0(x);
end;


function damath_struve_l1(x: double): double; cdecl; export;
  {-Return L1(x), the modified Struve function of order 1}
begin
    damath_struve_l1:= struve_l1(x);
end;



function damath_struve_l(v, x: double): double; cdecl; export;
  {-Return L_v(x), the modified Struve function of order v, x < 0 only if v is an integer.}
begin
    damath_struve_l:= struve_l(v, x);
end;




{-------------------------- Coulomb functions ---------------------------------}


function damath_CoulombCL(L: integer; eta: double): double; cdecl; export;
  {-Returns the normalizing constant CL for Coulomb wave function, L >= 0}
begin
    damath_CoulombCL:= CoulombCL(L, eta);
end;



function damath_CoulombSL(L: integer; eta: double): double; cdecl; export;
  {-Returns the Coulomb phase shift sigma_L(eta) for L >= 0}
begin
    damath_CoulombSL:= CoulombSL(L, eta);
end;



function damath_CoulombF(L: integer; eta, x: double): double; cdecl; export;
  {-Returns the Coulomb phase shift sigma_L(eta) for L >= 0}
begin
    damath_CoulombF:= CoulombF(L, eta, x);
end;



procedure damath_CoulombFFp (L : integer ; eta , x : double ; var fc , fcp : double ; var ifail : integer ); cdecl; export;
  {-Return the Kelvin functions kr=ker(x), ki=kei(x), x > 0}
begin
    CoulombFFp(L, eta, x, fc, fcp, ifail);
end;



procedure damath_CoulombGGp (L : integer ; eta , x : double ; var gc , gcp : double ; var ifail : integer ); cdecl; export;
  {-Return the Kelvin functions kr=ker(x), ki=kei(x), x > 0}
begin
    CoulombGGp(L, eta, x, gc, gcp, ifail);
end;





{------------------- Synchrotron functions -------------------}


function damath_SynchF(x: double): double; cdecl; export;
  {-Returns the first synchrotron function  F(x) = integral(x*BesselK(5/3,t), t=x..INF) for x >= 0}
begin
    damath_SynchF:= SynchF(x);
end;


function damath_SynchG(x: double): double; cdecl; export;
  {-Returns the second synchrotron function G(x) = x*BesselK(2/3,x) for x >= 0}
begin
    damath_SynchG:= SynchG(x);
end;






{**************************  Elliptic integrals, elliptic and theta functions  **************************}


{------------------- Elliptic integrals (Legendre style) -------------------}

function damath_comp_ellint_1(k: double): double; cdecl; export;
  {-Return the complete elliptic integral of the 1st kind, |k| < 1}
begin
    damath_comp_ellint_1:= comp_ellint_1(k);
end;


function damath_comp_ellint_2(k: double): double; cdecl; export;
  {-Return the complete elliptic integral of the 2nd kind, |k| <= 1}
begin
    damath_comp_ellint_2:= comp_ellint_2(k);
end;


function damath_comp_ellint_3(nu,k: double): double; cdecl; export;
  {-Return the complete elliptic integral of the 3rd kind, |k|<1, nu<>1}
begin
    damath_comp_ellint_3:= comp_ellint_3(nu, k);
end;



function damath_comp_ellint_b(k: double): double; cdecl; export;
  {-Returns the complete elliptic integral B(k) = (E(k) - kc^2*K(k))/k^2, real part for |k| > 1}
begin
    damath_comp_ellint_b:= comp_ellint_b(k);
end;


function damath_comp_ellint_d(k: double): double; cdecl; export;
  {-Return the complete elliptic integral D(k) = (K(k) - E(k))/k^2, |k| < 1}
begin
    damath_comp_ellint_d:= comp_ellint_d(k);
end;




function damath_ellint_1(phi,k: double): double; cdecl; export;
  {-Return the Legendre elliptic integral F(phi,k) of the 1st kind}
  { = integral(1/sqrt(1-k^2*sin(x)^2),x=0..phi), |k*sin(phi)| <= 1}
begin
    damath_ellint_1:= ellint_1(phi, k);
end;


function damath_ellint_2(phi,k: double): double; cdecl; export;
  {-Return the Legendre elliptic integral E(phi,k) of the 2nd kind}
  { = integral(sqrt(1-k^2*sin(x)^2),x=0..phi), |k*sin(phi)| <= 1}
begin
    damath_ellint_2:= ellint_2(phi, k);
end;


function damath_ellint_3(phi,nu,k: double): double; cdecl; export;
  {-Return the Legendre elliptic integral PI(phi,nu,k) of the 3rd kind}
  { = integral(1/sqrt(1-k^2*sin(x)^2)/(1-nu*sin(x)^2),x=0..phi) with  }
  { |k*sin(phi)|<=1, returns Cauchy principal value if nu*sin(phi)^2>1}
begin
    damath_ellint_3:= ellint_3(phi, nu, k);
end;




function damath_ellint_b(phi,k: double): double; cdecl; export;
  {-Return the Legendre elliptic integral D(phi,k) = (F(phi,k) - E(phi,k))/k^2 }
  { = integral(sin(x)^2/sqrt(1-k^2*sin(x)^2),x=0..phi), |k*sin(phi)| <= 1      }
begin
    damath_ellint_b:= ellint_b(phi, k);
end;




function damath_ellint_d(phi,k: double): double; cdecl; export;
  {-Return the Legendre elliptic integral D(phi,k) = (F(phi,k) - E(phi,k))/k^2 }
  { = integral(sin(x)^2/sqrt(1-k^2*sin(x)^2),x=0..phi), |k*sin(phi)| <= 1      }
begin
    damath_ellint_d:= ellint_d(phi, k);
end;




function damath_heuman_lambda(phi,k: double): double; cdecl; export;
  {-Return Heuman's function damath_Lambda_0(phi,k) = F(phi,k')/K(k') + 2/Pi*K(k)*Z(phi,k'), |k|<=1}
begin
    damath_heuman_lambda:= heuman_lambda(phi, k);
end;


function damath_jacobi_zeta(phi,k: double): double; cdecl; export;
  {-Return the Jacobi Zeta function damath_Z(phi,k) = E(phi,k) - E(k)/K(k)*F(phi,k), |k|<=1}
begin
    damath_jacobi_zeta:= jacobi_zeta(phi, k);
end;




{------------------- Elliptic integrals (Carlson style) --------------------}


function damath_ell_rc(x,y: double): double; cdecl; export;
  {-Return Carlson's degenerate elliptic integral RC; x>=0, y<>0}
begin
    damath_ell_rc:= ell_rc(x, y);
end;


function damath_ell_rf(x,y,z: double): double; cdecl; export;
  {-Return Carlson's elliptic integral of the 1st kind; x,y,z >=0, at most one =0}
begin
    damath_ell_rf:= ell_rf(x, y, z);
end;


function damath_ell_rd(x,y,z: double): double; cdecl; export;
  {-Return Carlson's elliptic integral of the 2nd kind; z>0; x,y >=0, at most one =0}
begin
    damath_ell_rd:= ell_rd(x, y, z);
end;


function damath_ell_rg(x,y,z: double): double; cdecl; export;
  {-Return Carlson's completely symmetric elliptic integral of the 2nd kind; x,y,z >= 0}
begin
    damath_ell_rg:= ell_rg(x, y, z);
end;


function damath_ell_rj(x,y,z,r: double): double; cdecl; export;
  {-Return Carlson's elliptic integral of the 3rd kind; r<>0; x,y,z >=0, at most one =0}
begin
    damath_ell_rj:= ell_rj(x, y, z, r);
end;



{------------------- Elliptic integrals (Bulirsch style) -------------------}


function damath_cel1(kc: double): double; cdecl; export;
  {-Return Bulirsch's complete elliptic integral of the 1st kind, kc<>0}
begin
    damath_cel1:= cel1(kc);
end;


function damath_cel2(kc, a, b: double): double; cdecl; export;
  {-Return Bulirsch's complete elliptic integral of the 2nd kind, kc<>0}
begin
    damath_cel2:= cel2(kc, a, b);
end;


function damath_cel(kc, p, a, b: double): double; cdecl; export;
  {-Return Bulirsch's general complete elliptic integral, kc<>0, Cauchy principle value if p<0}
begin
    damath_cel:= cel(kc, p, a, b);
end;


function damath_el1(x,kc: double): double; cdecl; export;
  {-Return Bulirsch's incomplete elliptic integral of the 1st kind}
begin
    damath_el1:= el1(x, kc);
end;


function damath_el2(x,kc,a,b: double): double; cdecl; export;
  {-Return Bulirsch's incomplete elliptic integral of the 2nd kind, kc<>0}
begin
    damath_el2:= el2(x, kc, a, b);
end;


function damath_el3(x,kc,p: double): double; cdecl; export;
  {-Return Bulirsch's incomplete elliptic integral of the 3rd kind, 1+p*x^2<>0}
begin
    damath_el3:= el3(x, kc, p);
end;




{------------------- Elliptic integrals (Maple V style) --------------------}

function damath_EllipticF(z,k: double): double; cdecl; export;
  {-Return the incomplete elliptic integral of the 1st kind; |z|<=1, |k*z|<1}
begin
    damath_EllipticF:= EllipticF(z, k);
end;


function damath_EllipticK(k: double): double; cdecl; export;
  {-Return the complete elliptic integral of the 1st kind, |k| < 1}
begin
    damath_EllipticK:= EllipticK(k);
end;


function damath_EllipticKim(k: double): double; cdecl; export;
  {-Return K(i*k), the complete elliptic integral of the 1st kind with}
  { imaginary modulus = integral(1/sqrt(1-x^2)/sqrt(1+k^2*x^2),x=0..1)}
begin
    damath_EllipticKim:= EllipticKim(k);
end;


function damath_EllipticCK(k: double): double; cdecl; export;
  {-Return the complementary complete elliptic integral of the 1st kind, k<>0}
begin
    damath_EllipticCK:= EllipticCK(k);
end;


function damath_EllipticE(z,k: double): double; cdecl; export;
  {Return the incomplete elliptic integrals of the 2nd kind, |z|<=1, |k*z| <= 1}
begin
    damath_EllipticE:= EllipticE(z, k);
end;


function damath_EllipticEC(k: double): double; cdecl; export;
  {-Return the complete elliptic integral of the 2nd kind, |k| < 1}
begin
    damath_EllipticEC:= EllipticEC(k);
end;


function damath_EllipticECim(k: double): double; cdecl; export;
  {-Return E(i*k), the complete elliptic integral of the 2nd kind with}
  { imaginary modulus = integral(sqrt(1+k^2*x^2)/sqrt(1-x^2),x=0..1)  }
begin
    damath_EllipticECim:= EllipticECim(k);
end;


function damath_EllipticCE(k: double): double; cdecl; export;
  {-Return the complementary complete elliptic integral of the 2nd kind}
begin
    damath_EllipticCE:= EllipticCE(k);
end;


function damath_EllipticPi(z,nu,k: double): double; cdecl; export;
  {-Return the incomplete elliptic integral of the 3rd kind, |z|<=1, |k*z|<1}
begin
    damath_EllipticPi:= EllipticPi(z, nu, k);
end;


function damath_EllipticPiC(nu,k: double): double; cdecl; export;
  {-Return the complete elliptic integral of the 3rd kind, |k|<1, nu<>1}
begin
    damath_EllipticPiC:= EllipticPiC(nu, k);
end;


function damath_EllipticCPi(nu,k: double): double; cdecl; export;
  {-Return the complementary complete elliptic integral of the 3rd kind, k<>0, nu<>1}
begin
    damath_EllipticCPi:= EllipticCPi(nu, k);
end;


function damath_EllipticPiCim(nu,k: double): double; cdecl; export;
  {-Return the complementary complete elliptic integral of the 3rd kind with imaginary modulus k, k<>0, nu<>1, real part if nu>1}
begin
    damath_EllipticPiCim:= EllipticPiCim(nu, k);
end;



{------------------- Elliptic integrals (Mathematica style) --------------------}



function damath_M_EllipticK (m : double ): double; cdecl; export;
  {-Returns the complete elliptic integral of the 1st kind, K(m) = integral(dx/sqrt(1-m*sin(x)^2),x=0..Pi/2), real part for m>1}
begin
    damath_M_EllipticK:= M_EllipticK(m);
end;


function damath_M_EllipticEC (m : double ): double; cdecl; export;
  {-Returns the complete elliptic integral of the 1st kind, K(m) = integral(dx/sqrt(1-m*sin(x)^2),x=0..Pi/2), real part for m>1}
begin
    damath_M_EllipticEC:= M_EllipticEC(m);
end;


function damath_M_EllipticPiC (n, m : double ): double; cdecl; export;
  {-Returns the complete elliptic integral of the 3rd kind, n <> 1, m <> 1, real part for m > 1;}
begin
    damath_M_EllipticPiC:= M_EllipticPiC(n, m);
end;


function damath_M_EllipticF (phi, m : double ): double; cdecl; export;
  {-Returns the incomplete elliptic integral of the 1st kind}
begin
    damath_M_EllipticF:= M_EllipticF(phi, m);
end;


function damath_M_EllipticE (phi, m : double ): double; cdecl; export;
  {-Returns the incomplete elliptic integral of the 2nd kind}
begin
    damath_M_EllipticE:= M_EllipticE(phi, m);
end;


function damath_M_EllipticPi (n, phi, m : double ): double; cdecl; export;
  {-Returns the incomplete elliptic integral Pi(n,phi,m) of the 3rd kind}
begin
    damath_M_EllipticPi:= M_EllipticPi(n, phi, m);
end;







{--------------------- Jacobi elliptic and theta functions -------------------}

function damath_EllipticModulus(q: double): double; cdecl; export;
  {-Return the elliptic modulus k(q) = theta_2(q)^2/theta_3(q)^2, 0 <= q <= 1}
begin
    damath_EllipticModulus:= EllipticModulus(q);
end;


function damath_EllipticNome(k: double): double; cdecl; export;
  {-Return the elliptic nome q(k) = exp(-Pi*EllipticCK(k)/EllipticK(k)), |k| < 1}
begin
    damath_EllipticNome:= EllipticNome(k);
end;


function damath_jacobi_am(x,k: double): double; cdecl; export;
  {-Return the Jacobi amplitude am(x,k)}
begin
    damath_jacobi_am:= jacobi_am(x, k);
end;


function damath_jacobi_arccn(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arccn(x,k), |x| <= 1, x >= sqrt(1 - 1/k^2) if k >= 1}
begin
    damath_jacobi_arccn:= jacobi_arccn(x, k);
end;


function damath_jacobi_arccd(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arccd(x,k); |x| <= 1 if |k| < 1; |x| >= 1 if |k| > 1 }
begin
    damath_jacobi_arccd:= jacobi_arccd(x, k);
end;


function damath_jacobi_arccs(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arccs(x,k), |x| >= sqrt(k^2-1) for |k|>1}
begin
    damath_jacobi_arccs:= jacobi_arccs(x, k);
end;


function damath_jacobi_arcdc(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcdc(x,k); |x| >= 1 if |k| < 1; |x| <= 1 if |k| > 1 }
begin
    damath_jacobi_arcdc:= jacobi_arcdc(x, k);
end;


function damath_jacobi_arcdn(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcdn(x,k), 0 <= x <= 1, x^2 + k^2 > 1 if |k| < 1;  |x| <= 1 if |k| > 1}
begin
    damath_jacobi_arcdn:= jacobi_arcdn(x, k);
end;


function damath_jacobi_arcds(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcds(x,k), x^2 + k^2 >= 1}
begin
    damath_jacobi_arcds:= jacobi_arcds(x, k);
end;


function damath_jacobi_arcnc(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcnc(x,k), x >= 1, x^2 <= k^2/(k^2-1) for |k|>1}
begin
    damath_jacobi_arcnc:= jacobi_arcnc(x, k);
end;


function damath_jacobi_arcnd(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcnd(x,k), x >= 1, x^2 <= k^2/(1-k^2) if k < 1}
begin
    damath_jacobi_arcnd:= jacobi_arcnd(x, k);
end;


function damath_jacobi_arcns(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcns(x,k), |x| >= 1, |x| >= k if k>=1}
begin
    damath_jacobi_arcns:= jacobi_arcns(x, k);
end;


function damath_jacobi_arcsc(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcsc(x,k), |x| <= 1/sqrt(k^2-1) for |k|>1}
begin
    damath_jacobi_arcsc:= jacobi_arcsc(x, k);
end;


function damath_jacobi_arcsd(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcsd(x,k), x^2*(1-k^2) <= 1}
begin
    damath_jacobi_arcsd:= jacobi_arcsd(x, k);
end;


function damath_jacobi_arcsn(x,k: double): double; cdecl; export;
  {-Return the inverse Jacobi elliptic function damath_arcsn(x,k), |x| <= 1 and |x*k| <= 1}
begin
    damath_jacobi_arcsn:= jacobi_arcsn(x, k);
end;


function damath_jacobi_sn(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_sn(x,k)}
begin
    damath_jacobi_sn:= jacobi_sn(x, k);
end;


function damath_jacobi_cn(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_cn(x,k)}
begin
    damath_jacobi_cn:= jacobi_cn(x, k);
end;


function damath_jacobi_dn(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_dn(x,k)}
begin
    damath_jacobi_dn:= jacobi_dn(x, k);
end;


function damath_jacobi_nc(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_nc(x,k)}
begin
    damath_jacobi_nc:= jacobi_nc(x, k);
end;


function damath_jacobi_sc(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_sc(x,k)}
begin
    damath_jacobi_sc:= jacobi_sc(x, k);
end;


function damath_jacobi_dc(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_dc(x,k)}
begin
    damath_jacobi_dc:= jacobi_dc(x, k);
end;


function damath_jacobi_nd(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_nd(x,k)}
begin
    damath_jacobi_nd:= jacobi_nd(x, k);
end;


function damath_jacobi_sd(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_sd(x,k)}
begin
    damath_jacobi_sd:= jacobi_sd(x, k);
end;


function damath_jacobi_cd(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_cd(x,k)}
begin
    damath_jacobi_cd:= jacobi_cd(x, k);
end;


function damath_jacobi_ns(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_ns(x,k)}
begin
    damath_jacobi_ns:= jacobi_ns(x, k);
end;


function damath_jacobi_cs(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_cs(x,k)}
begin
    damath_jacobi_cs:= jacobi_cs(x, k);
end;


function damath_jacobi_ds(x,k: double): double; cdecl; export;
  {-Return the Jacobi elliptic function damath_ds(x,k)}
begin
    damath_jacobi_ds:= jacobi_ds(x, k);
end;


procedure damath_sncndn(x,mc: double; var sn,cn,dn: double);
  {-Return the Jacobi elliptic functions sn,cn,dn for argument x and}
  { complementary parameter mc.}
begin
    sncndn(x, mc, sn, cn, dn);
end;




{--------------------- Jacobi theta functions -------------------}


function damath_jacobi_theta(n: integer; x,q: double): double; cdecl; export;
  {-Return the Jacobi theta function damath_theta_n(x,q), n=1..4, 0 <= q < 1}
begin
    damath_jacobi_theta:= jacobi_theta(n, x, q);
end;



function damath_theta1p(q: double): double; cdecl; export;
  {-Return the derivative  theta1p(q) := d/dx(theta_1(x,q)) at x=0,}
  { = 2*q^(1/4)*sum((-1)^n*(2n+1)*q^(n*(n+1)),n=0..Inf), 0 <= q < 1}
begin
    damath_theta1p:= theta1p(q);
end;


function damath_theta2(q: double): double; cdecl; export;
  {-Return Jacobi theta_2(q) = 2*q^(1/4)*sum(q^(n*(n+1)),n=0..Inf) 0 <= q < 1}
begin
    damath_theta2:= theta2(q);
end;


function damath_theta3(q: double): double; cdecl; export;
  {-Return Jacobi theta_3(q) = 1 + 2*sum(q^(n*n)),n=1..Inf); |q| < 1}
begin
    damath_theta3:= theta3(q);
end;


function damath_theta4(q: double): double; cdecl; export;
  {-Return Jacobi theta_4(q) = 1 + 2*sum((-1)^n*q^(n*(n+1)),n=1..Inf); |q| < 1}
begin
    damath_theta4:= theta4(q);
end;




{--------------------- Neville and lemniscate  functions -------------------}


function damath_ntheta_c(x,k: double): double; cdecl; export;
  {-Returns the Neville theta_c function, |k| <= 1}
begin
    damath_ntheta_c:= ntheta_c(x, k);
end;


function damath_ntheta_d(x,k: double): double; cdecl; export;
  {-Returns the Neville theta_d function, |k| <= 1}
begin
    damath_ntheta_d:= ntheta_d(x, k);
end;


function damath_ntheta_n(x,k: double): double; cdecl; export;
  {-Returns the Neville theta_n function, |k| <= 1}
begin
    damath_ntheta_n:= ntheta_n(x, k);
end;


function damath_ntheta_s(x,k: double): double; cdecl; export;
  {-Returns the Neville theta_s function, |k| <= 1}
begin
    damath_ntheta_s:= ntheta_s(x, k);
end;



function damath_arccl(x: double): double; cdecl; export;
  {-Returns the inverse lemniscate cosine function, |x| <= 1}
begin
    damath_arccl:= arccl(x);
end;


function damath_arcsl(x: double): double; cdecl; export;
  {-Returns the inverse lemniscate cosine function, |x| <= 1}
begin
    damath_arcsl:= arcsl(x);
end;



procedure  damath_sincos_lemn(x: double;  var sl,cl: double); cdecl; export;
  {-Return the lemniscate functions sl = sin_lemn(x), cl = cos_lemn(x)}
begin
    sincos_lemn(x, sl, cl);
end;


function damath_sin_lemn(x: double): double; cdecl; export;
  {-Return the lemniscate sine function sl = sin_lemn(x)}
begin
    damath_sin_lemn:= sin_lemn(x);
end;


function damath_cos_lemn(x: double): double; cdecl; export;
  {-Return the lemniscate cosine function cl = cos_lemn(x)}
begin
    damath_cos_lemn:= cos_lemn(x);
end;


{--------------------- Weierstrass P and related  functions -------------------}



function damath_wpl(x: double): double; cdecl; export;
  {-Returns the Weierstrass function wp(x,1,0)=wpe(x,1/2,0), basic lemniscatic case}
begin
    damath_wpl:= wpl(x);
end;


function damath_wpe(x , e1 , e2 : double): double; cdecl; export;
  {-Returns Weierstrass P(x,e1,e2) from the lattice roots e1 &lt; e2}
begin
    damath_wpe:= wpe(x , e1 , e2);
end;


function damath_wpe_der(x , e1 , e2 : double): double; cdecl; export;
  {-Returns Weierstrass P'(x,e1,e2) from the lattice roots e1 &lt; e2}
begin
    damath_wpe_der:= wpe_der(x , e1 , e2);
end;


function damath_wpe_im(y , e1 , e2 : double): double; cdecl; export;
  {-Returns the Weierstrass function P(iy,e1,e2) from the lattice roots e1 &lt; e2}
begin
    damath_wpe_im:= wpe_im(y , e1 , e2);
end;


function damath_wpg(x , g2 , g3 : double): double; cdecl; export;
  {-Returns the Weierstrass function P(x,e1,e2) from lattice invariants g2, g3}
begin
    damath_wpg:= wpg(x , g2 , g3);
end;


function damath_wpg_der(x , g2 , g3 : double): double; cdecl; export;
  {-Returns Weierstrass P'(x,e1,e2) from lattice invariants g2, g3}
begin
    damath_wpg_der:= wpg_der(x , g2 , g3);
end;


function damath_wpg_im(y , g2 , g3 : double): double; cdecl; export;
  {-Returns the Weierstrass function P(iy, g2, g3)}
begin
    damath_wpg_im:= wpg_im(y , g2 , g3);
end;


function damath_wpe_inv(y , e1 , e2 : double): double; cdecl; export;
  {-Returns the smallest positive x with wpe(x)=y, y &#8805; e1}
begin
    damath_wpe_inv:= wpe_inv(y , e1 , e2);
end;


function damath_wpg_inv(y , g2 , g3 : double): double; cdecl; export;
  {-Returns the smallest positive x with wpg(x,g2,g3)=y, y >= e2}
begin
    damath_wpg_inv:= wpg_inv(y , g2 , g3);
end;


function damath_detai(x: double): double; cdecl; export;
  {-Returns Dedekind eta(i*x), x >= 0}
begin
    damath_detai:= detai(x);
end;


function damath_emlambda(y: double): double; cdecl; export;
  {-Returns the elliptic modular function lambda(iy), y >= 0}
begin
    damath_emlambda:= emlambda(y);
end;


function damath_KleinJ(y: double): double; cdecl; export;
  {-Returns Klein's complete invariant J(iy), y>0}
begin
    damath_KleinJ:= KleinJ(y);
end;






{**************************  Error function and related  **********************************************}


function damath_dawson(x: double): double; cdecl; export;
  {-Return Dawson's integral: dawson(x) = exp(-x^2)*integral(exp(t^2), t=0..x)}
begin
    damath_dawson:= dawson(x);
end;


function damath_dawson2(p,x: double): double; cdecl; export;
  {-Return the generalized Dawson integral F(p,x) = exp(-x^p)*integral(exp(t^p), t=0..x); x,p >= 0}
begin
    damath_dawson2:= dawson2(p, x);
end;


function damath_erf(x: double): double; cdecl; export;
  {-Return the error function damath_erf(x) = 2/sqrt(Pi)*integral((exp(-t^2), t=0..x)}
begin
    damath_erf:= erf(x);
end;


function damath_erfg(p,x: double): double; cdecl; export;
  {-Return the generalized error function damath_integral(exp(-t^p), t=0..x); x,p >= 0}
begin
    damath_erfg:= erfg(p, x);
end;



function damath_erfc(x: double): double; cdecl; export;
  {-Return the complementary error function damath_erfc(x) = 1-erf(x)}
begin
    damath_erfc:= erfc(x);
end;


function damath_erfce(x: double): double; cdecl; export;
  {-Return the exponentially scaled complementary error function damath_erfce(x) = exp(x^2)*erfc(x)}
begin
    damath_erfce:= erfce(x);
end;


function damath_inerfc(n: integer; x: double): double; cdecl; export;
  {-Return the repeated integrals of erfc, n >= -1; scaled with exp(x^2) for x>0}
begin
    damath_inerfc:= inerfc(n, x);
end;


function damath_erfi(x: double): double; cdecl; export;
  {-Return the imaginary error function damath_erfi(x) = erf(ix)/i}
begin
    damath_erfi:= erfi(x);
end;


function damath_erfh(x, h: double): double; cdecl; export;
  {-Accurately compute erf(x+h) - erf(x-h)}
begin
    damath_erfh:= erfh(x, h);
end;



function damath_erf2(x1, x2: double): double; cdecl; export;
  {-Accurately compute erf(x2) - erf(x1)}
begin
    damath_erf2:= erf2(x1, x2);
end;



function damath_erf_inv(x: double): double; cdecl; export;
  {-Return the inverse function damath_of erf, erf(erf_inv(x)) = x, -1 < x < 1}
begin
    damath_erf_inv:= erf_inv(x);
end;


function damath_erfc_inv(x: double): double; cdecl; export;
  {-Return the inverse function damath_of erfc, erfc(erfc_inv(x)) = x, 0 < x < 2}
begin
    damath_erfc_inv:= erfc_inv(x);
end;


function damath_erfce_inv(x: double): double; cdecl; export;
  {-Returns the functional inverse of erfce, erfce(erfce_inv(x)) = x, x > 0}
begin
    damath_erfce_inv:= erfce_inv(x);
end;


function damath_erfi_inv(x: double): double; cdecl; export;
  {-Returns the functional inverse of the imaginary error function erfi, i.e. erfi(erfi−1(y)) = y,}
begin
    damath_erfi_inv:= erfi_inv(x);
end;




function damath_erf_p(x: double): double; cdecl; export;
  {-Return the probability function damath_erf_p = integral(exp(-t^2/2)/sqrt(2*Pi), t=-Inf..x)}
begin
    damath_erf_p:= erf_p(x);
end;


function damath_erf_q(x: double): double; cdecl; export;
  {-Return the probability function damath_erf_q = integral(exp(-t^2/2)/sqrt(2*Pi), t=x..Inf)}
begin
    damath_erf_q:= erf_q(x);
end;


function damath_erf_z(x: double): double; cdecl; export;
  {-Return the probability function damath_erf_z = exp(-x^2/2)/sqrt(2*Pi)}
begin
    damath_erf_z:= erf_z(x);
end;


function damath_expint3(x: double): double; cdecl; export;
  {-Return the integral(exp(-t^3), t=0..x), x >= 0}
begin
    damath_expint3:= expint3(x);
end;


procedure damath_Fresnel(x: double; var s,c: double);
  {-Return the Fresnel integrals S(x)=integral(sin(Pi/2*t^2),t=0..x) and C(x)=integral(cos(Pi/2*t^2),t=0..x)}
begin
    Fresnel(x, s, c);
end;


function damath_FresnelC(x: double): double; cdecl; export;
  {-Return the Fresnel integral C(x)=integral(cos(Pi/2*t^2),t=0..x)}
begin
    damath_FresnelC:= FresnelC(x);
end;


function damath_FresnelS(x: double): double; cdecl; export;
  {-Return the Fresnel integral S(x)=integral(sin(Pi/2*t^2),t=0..x)}
begin
    damath_FresnelS:= FresnelS(x);
end;




procedure damath_FresnelFG(x: double; var f, g: double);
  {-Simulateously calculates the Fresnel auxiliary functions f,g for x >= 0}
begin
    FresnelFG(x, f, g);
end;


function damath_FresnelF(x: double): double; cdecl; export;
  {-Returns the Fresnel auxiliary function  f for x >= 0}
begin
    damath_FresnelF:= FresnelF(x);
end;


function damath_FresnelG(x: double): double; cdecl; export;
  {-Returns the Fresnel auxiliary function  g for x >= 0}
begin
    damath_FresnelG:= FresnelG(x);
end;




function damath_gsi(x: double): double; cdecl; export;
  {-Return the Goodwin-Staton integral = integral(exp(-t*t)/(t+x), t=0..Inf), x > 0}
begin
    damath_gsi:= gsi(x);
end;



function damath_MarcumQ(m : integer ; a , b : double): double; cdecl; export;
  {-Returns the generalized Marcum Q function Q(m,a,b), a,b >= 0}
begin
    damath_MarcumQ:= MarcumQ(m, a, b);
end;



function damath_OwenT(h, a: double): double; cdecl; export;
  {-Returns Owen's T function T(h,a)}
begin
    damath_OwenT:= OwenT(h, a);
end;






{**************************  Exponential integrals and related  **********************************************}


function damath_chi(x: double): double; cdecl; export;
  {-Return the hyperbolic cosine integral = EulerGamma + ln(|x|) + integral((cosh(t)-1)/t, t=0..|x|)}
begin
    damath_chi:= chi(x);
end;


function damath_ci(x: double): double; cdecl; export;
  {-Return the cosine integral, ci(x) = EulerGamma + ln(|x|) + integral((cos(t)-1)/t, t=0..|x|)}
begin
    damath_ci:= ci(x);
end;


function damath_cin(x: double): double; cdecl; export;
  {-Return the entire cosine integral, cin(x) = integral((1-cos(t))/t, t=0..x)}
begin
    damath_cin:= cin(x);
end;


function damath_cinh(x: double): double; cdecl; export;
  {-Return the entire hyperbolic cosine integral, cinh(x) = integral((cosh(t)-1)/t, t=0..x)}
begin
    damath_cinh:= cinh(x);
end;



function damath_e1(x: double): double; cdecl; export;
  {-Return the exponential integral E1(x) = integral(exp(-x*t)/t, t=1..Inf), x <> 0}
begin
    damath_e1:= e1(x);
end;



function damath_e1s(x: double): double; cdecl; export;
  {-Returns E1s(x) = exp(x)*E1(x), 0 x <> 0}
begin
    damath_e1s:= e1(x);
end;



function damath_ei(x: double): double; cdecl; export;
  {-Return the exponential integral Ei(x) = PV-integral(exp(t)/t, t=-Inf..x)}
begin
    damath_ei:= ei(x);
end;



function damath_eis(x: double): double; cdecl; export;
  {-Returns exp(-x)*Ei(x),  x <> 0}
begin
    damath_eis:= eis(x);
end;



function damath_eisx2(x: double): double; cdecl; export;
  {-Returns exp(-x^2)*Ei(x^2), x <> 0}
begin
    damath_eisx2:= eisx2(x);
end;


function damath_ei_inv(x: double): double; cdecl; export;
  {-Return the functional inverse of Ei(x), ei_inv(ei(x))=x}
begin
    damath_ei_inv:= ei_inv(x);
end;



function damath_ein(x: double): double; cdecl; export;
  {-Return the entire exponential integral ein(x) = integral((1-exp(-t))/t, t=0..x)}
begin
    damath_ein:= ein(x);
end;


function damath_en(n: longint; x: double): double; cdecl; export;
  {-Return the exponential integral E_n(x) = integral(exp(-x*t)/t^n, t=1..Inf), x > 0}
begin
    damath_en:= en(n, x);
end;


function damath_gei(p,x: double): double; cdecl; export;
  {-Return the generalized exponential integral E_p(x) = integral(exp(-x*t)/t^p, t=1..Inf), x >= 0}
begin
    damath_gei:= gei(p, x);
end;


function damath_eibeta(n : integer ; x : double): double; cdecl; export;
  {-Returns the exponential integral beta(n,x) = int(t^n*exp(-x*t), t=-1..1), n >= 0}
begin
    damath_eibeta:= eibeta(n, x);
end;



function damath_li(x: double): double; cdecl; export;
  {-Return the logarithmic integral li(x) = PV-integral(1/ln(t), t=0..x), x >= 0, x <> 1}
begin
    damath_li:= li(x);
end;


function damath_li_inv(x: double): double; cdecl; export;
  {-Return the functional inverse of li(x), li(li_inv(x))=x}
begin
    damath_li_inv:= li_inv(x);
end;


function damath_shi(x: double): double; cdecl; export;
  {-Return the hyperbolic sine integral, integral(sinh(t)/t, t=0..x)}
begin
    damath_shi:= shi(x);
end;


function damath_si(x: double): double; cdecl; export;
  {-Return the sine integral, si(x) = integral(sin(t)/t, t=0..x)}
begin
    damath_si:= si(x);
end;


function damath_ssi(x: double): double; cdecl; export;
  {-Return the shifted sine integral, ssi(x) = si(x) - Pi/2}
begin
    damath_ssi:= ssi(x);
end;





{**************************  Gamma function and related  *********************************}

{--------------------- Gamma functions  ---------------------}


function damath_gamma(x: double): double; cdecl; export;
  {-Return gamma(x), x <= MAXGAM; invalid if x is a non-positive integer}
begin
    damath_gamma:= gamma(x);
end;


function damath_gamma1pm1(x: double): double; cdecl; export;
  {-Return gamma(1+x)-1 with increased accuracy for x near 0}
begin
    damath_gamma1pm1:= gamma1pm1(x);
end;


function damath_inv_gamma(y: double): double; cdecl; export;
  {-Returns the inverse of gamma: return x with gamma(x) = y, y >= 0.8857421875}
begin
    damath_inv_gamma:= inv_gamma(y);
end;


function damath_gammastar(x: double): double; cdecl; export;
  {-Return Temme's gammastar(x) = gamma(x)/(sqrt(2*Pi)*x^(x-0.5)*exp(-x)), x>0.}
  { For large x the asymptotic expansion is gammastar(x) = 1 + 1/12x + O(1/x^2)}
begin
    damath_gammastar:= gammastar(x);
end;


function damath_lngamma(x: double): double; cdecl; export;
  {-Return ln(|gamma(x)|), |x| <= MAXLGM, invalid if x is a non-positive integer}
  { function damath_signgamma can be used if the sign of gamma(x) is needed.}
begin
    damath_lngamma:= lngamma(x);
end;


function damath_lngamma_inv(x: double): double; cdecl; export;
  {-Inverse of lngamma: return x with lngamma(x) = y, y >= -0.12142, x > 1.4616}
begin
    damath_lngamma_inv:= lngamma_inv(x);
end;


function damath_lngamma1p(x: double): double; cdecl; export;
  {-Return ln(|gamma(1+x)|) with increased accuracy for x near 0}
begin
    damath_lngamma1p:= lngamma1p(x);
end;


function damath_rgamma(x: double): double; cdecl; export;
  {-Return the reciprocal gamma function damath_rgamma = 1/gamma(x)}
begin
    damath_rgamma:= rgamma(x);
end;


function damath_signgamma(x: double): double; cdecl; export;
  {-Return sign(gamma(x)), useless for 0 or negative integer}
begin
    damath_signgamma:= signgamma(x);
end;


function damath_lngammas(x: double; var s: integer): double; cdecl; export;
  {-Return ln(|gamma(x)|), |x| <= MAXLGM, s=-1,1 is the sign of gamma}
begin
    damath_lngammas:= lngammas(x, s);
end;




{--------------------- Incomplete gamma functions  ---------------------}


procedure damath_incgamma(a,x: double; var p,q: double);
  {-Return the normalised incomplete gamma functions P and Q, a>=0, x>=0}
  { P(a,x) = integral(exp(-t)*t^(a-1), t=0..x  )/gamma(a)}
  { Q(a,x) = integral(exp(-t)*t^(a-1), t=x..Inf)/gamma(a)}
begin
    incgamma(a, x, p, q);
end;


function damath_igammap(a,x: double): double; cdecl; export;
  {-Return the normalised lower incomplete gamma function damath_P(a,x), a>=0, x>=0}
  { P(a,x) = integral(exp(-t)*t^(a-1), t=0..x)/gamma(a)}
begin
    damath_igammap:= igammap(a, x);
end;


function damath_igammaq(a,x: double): double; cdecl; export;
  {-Return the normalised upper incomplete gamma function damath_Q(a,x), a>=0, x>=0}
  { Q(a,x) = integral(exp(-t)*t^(a-1), t=x..Inf)/gamma(a)}
begin
    damath_igammaq:= igammaq(a, x);
end;


function damath_igamma(a,x: double): double; cdecl; export;
  {-Return the non-normalised upper incomplete gamma function}
  { GAMMA(a,x) = integral(exp(-t)*t^(a-1), t=x..Inf), x>=0}
begin
    damath_igamma:= igamma(a, x);
end;


function damath_igammal(a,x: double): double; cdecl; export;
  {-Return the non-normalised lower incomplete gamma function}
  { gamma(a,x) = integral(exp(-t)*t^(a-1), t=0..x); x>=0, a<>0,-1,-2,..}
begin
    damath_igammal:= igammal(a, x);
end;


function damath_igammat(a,x: double): double; cdecl; export;
  {-Return Tricomi's entire incomplete gamma function damath_gammastar(a,x)}
  { = igammal(a,x)/gamma(a)/x^a = P(a,x)/x^a }
begin
    damath_igammat:= igammat(a, x);
end;



procedure damath_incgamma_inv(a,p,q: double; var x: double; var ierr: integer);
  {-Return the inverse normalised incomplete gamma function, i.e. calculate}
  { x with P(a,x)=p and Q(a,x)=q. Input parameter a>0, p>=0, q>0 and p+q=1.}
  { ierr is >= 0 for success, < 0 for input errors or iterations failures. }
begin
    incgamma_inv(a, p, q, x, ierr);
end;


function damath_igamma_inv(a,p,q: double): double; cdecl; export;
  {-Return the inverse normalised incomplete gamma function, i.e. calculate}
  { x with P(a,x)=p and Q(a,x)=q. Input parameter a>0, p>=0, q>0 and p+q=1.}
begin
    damath_igamma_inv:= igamma_inv(a, p, q);
end;


function damath_igammap_inv(a,p: double): double; cdecl; export;
  {-Inverse incomplete gamma: return x with P(a,x)=p, a>=0, 0<=p<1}
begin
    damath_igammap_inv:= igammap_inv(a, p);
end;


function damath_igammaq_inv(a,q: double): double; cdecl; export;
  {-Inverse complemented incomplete gamma: return x with Q(a,x)=q, a>=0, 0<q<=1}
begin
    damath_igammaq_inv:= igammaq_inv(a, q);
end;


function damath_igammap_der(a,x: double): double; cdecl; export;
  {-Returns the partial derivative with respect to x of the normalised lower incomplete gamma function }
begin
    damath_igammap_der:= igammap_der(a, x);
end;




{--------------------- Beta functions  ---------------------}

function damath_beta(x,y: double): double; cdecl; export;
  {-Return the function damath_beta(x,y)=gamma(x)*gamma(y)/gamma(x+y)}
begin
    damath_beta:= beta(x, y);
end;


function damath_lnbeta(x,y: double): double; cdecl; export;
  {-Return the logarithm of |beta(x,y)|=|gamma(x)*gamma(y)/gamma(x+y)|}
begin
    damath_lnbeta:= lnbeta(x, y);
end;


function damath_ibeta(a, b, x: double): double; cdecl; export;
  {-Return the normalised incomplete beta function, a>0, b>0, 0 <= x <= 1}
  { ibeta = integral(t^(a-1)*(1-t)^(b-1) / betax(a,b), t=0..x)}
begin
    damath_ibeta:= ibeta(a, b, x);
end;


function damath_beta3(a, b, x: double): double; cdecl; export;
  {-Return the non-normalised incomplete beta function damath_B_x(a,b)}
  { for 0<=x<=1, B_x = integral(t^(a-1)*(1-t)^(b-1), t=0..x).  }
begin
    damath_beta3:= beta3(a, b, x);
end;


function damath_ibeta_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the normalised incomplete beta function}
  { with a > 0, b > 0, and 0 <= y <= 1.}
begin
    damath_ibeta_inv:= ibeta_inv(a, b, y);
end;




{--------------------- Factorials, Pochhammer symbol, binomial coefficient  ---------------------}

function damath_fac(n: integer): double; cdecl; export;
  {-Return the factorial n!, n<MAXGAM-1; INF if n<0}
begin
    damath_fac:= fac(n);
end;


function damath_dfac(n: integer): double; cdecl; export;
  {-Return the double factorial n!!, n<=MAXDFAC; INF for even n<0}
begin
    damath_dfac:= dfac(n);
end;


function damath_lnfac(n: longint): double; cdecl; export;
  {-Return ln(n!), INF if n<0}
begin
    damath_lnfac:= lnfac(n);
end;


function damath_binomial(n,k: integer): double; cdecl; export;
  {-Return the binomial coefficient 'n choose k'}
begin
    damath_binomial:= binomial(n, k);
end;


function damath_lnbinomial(n,k: integer): double; cdecl; export;
  {-Return the binomial coefficient 'n choose k'}
begin
    damath_lnbinomial:= lnbinomial(n, k);
end;


function damath_pochhammer(a,x: double): double; cdecl; export;
  {-Return the Pochhammer symbol gamma(a+x)/gamma(a)}
begin
    damath_pochhammer:= pochhammer(a, x);
end;


function damath_poch1(a,x: double): double; cdecl; export;
  {-Return (pochhammer(a,x)-1)/x, psi(a) if x=0; accurate even for small |x|}
begin
    damath_poch1:= poch1(a, x);
end;






{--------------------- Ratio of gamma functions  ---------------------}

function damath_gamma_delta_ratio(x,d: double): double; cdecl; export;
  {-Return gamma(x)/gamma(x+d), accurate even for |d| << |x|}
begin
    damath_gamma_delta_ratio:= gamma_delta_ratio(x, d);
end;


function damath_gamma_ratio(x,y: double): double; cdecl; export;
  {-Return gamma(x)/gamma(y)}
begin
    damath_gamma_ratio:= gamma_ratio(x, y);
end;



{--------------------- Psi and polygamma functions  ---------------------}

function damath_psi(x: double): double; cdecl; export;
  {-Return the psi (digamma) function damath_of x, INF if x is a non-positive integer}
begin
    damath_psi:= psi(x);
end;


function damath_psistar(x: double): double; cdecl; export;
  {-Returns psi(x) - ln(x), x > 0}
begin
    damath_psistar:= psistar(x);
end;


function damath_trigamma(x: double): double; cdecl; export;
  {-Return the trigamma function damath_of x, INF if x is a negative integer}
begin
    damath_trigamma:= trigamma(x);
end;


function damath_tetragamma(x: double): double; cdecl; export;
  {-Return the tetragamma function damath_psi''(x), NAN/RTE if x is a negative integer}
begin
    damath_tetragamma:= tetragamma(x);
end;


function damath_pentagamma(x: double): double; cdecl; export;
  {-Return the pentagamma function damath_psi'''(x), INF if x is a negative integer}
begin
    damath_pentagamma:= pentagamma(x);
end;


function damath_polygamma(n: integer; x: double): double; cdecl; export;
  {-Return the polygamma function: n'th derivative of psi; n>=0, x>0 for n>12.}
  { Note: Accuracy may be reduced for n>=MAXGAMX due to ln/exp operations.}
begin
    damath_polygamma:= polygamma(n, x);
end;


function damath_psi_inv(x: double): double; cdecl; export;
  {-Inverse of psi, return x with psi(x)=y, y <= ln_MaxDbl}
begin
    damath_psi_inv:= psi_inv(x);
end;


function damath_BatemanG(x: double): double; cdecl; export;
  {-Return the Bateman function damath_G(x) = psi((x+1)/2) - psi(x/2), x<>0,-1,-2,...}
begin
    damath_BatemanG:= BatemanG(x);
end;


{--------------------- Logarithm of Barnes G function  ---------------------}


function damath_lnBarnesG(x: double): double; cdecl; export;
  {-Returns ln(BarnesG(x)), real part for x < 0}
begin
    damath_lnBarnesG:= lnBarnesG(x);
end;





{*********************  Zeta functions, polylogarithms, and related  ******************}

{--------------------- Riemann zeta functions  ---------------------}



function damath_zeta(s: double): double; cdecl; export;
  {-Return the Riemann zeta function damath_at s, s<>1}
begin
    damath_zeta:= zeta(s);
end;


function damath_zetaint(n: integer): double; cdecl; export;
  {-Return zeta(n) for integer arguments, n<>1}
begin
    damath_zetaint:= zetaint(n);
end;


function damath_zeta1p(x: double): double; cdecl; export;
  {-Return the Riemann zeta function damath_at 1+x, x<>0}
begin
    damath_zeta1p:= zeta1p(x);
end;


function damath_zetam1(s: double): double; cdecl; export;
  {-Return Riemann zeta(s)-1, s<>1}
begin
    damath_zetam1:= zetam1(s);
end;


function damath_primezeta(x: double): double; cdecl; export;
  {-Return the prime zeta function damath_P(x) = sum(1/p^x, p prime), x > 1}
begin
    damath_primezeta:= primezeta(x);
end;



function damath_eta(s: double): double; cdecl; export;
  {-Return the Dirichlet eta function}
begin
    damath_eta:= eta(s);
end;


function damath_etaint(n: integer): double; cdecl; export;
  {-Return the Dirichlet function damath_eta(n) for integer arguments}
begin
    damath_etaint:= etaint(n);
end;


function damath_etam1(s: double): double; cdecl; export;
  {-Return Dirichlet eta(s)-1}
begin
    damath_etam1:= etam1(s);
end;


function damath_DirichletBeta(s: double): double; cdecl; export;
  {-Return the Dirichlet beta function damath_sum((-1)^n/(2n+1)^s, n=0..INF)}
begin
    damath_DirichletBeta:= DirichletBeta(s);
end;


function damath_DirichletLambda(s: double): double; cdecl; export;
  {-Return the Dirichlet lambda function damath_sum(1/(2n+1)^s, n=0..INF), s<>1}
begin
    damath_DirichletLambda:= DirichletLambda(s);
end;



function damath_zetah(s,a: double): double; cdecl; export;
  {-Return the Hurwitz zeta function damath_zetah(s,a) = sum(1/(i+a)^s, i=0..INF), s<>1, a>0}
begin
    damath_zetah:= zetah(s, a);
end;





function damath_bose_einstein(s, x: double): double; cdecl; export;
  {-Returns the Bose-Einstein integral of real order s >= -1}
begin
    damath_bose_einstein:= bose_einstein(s, x);
end;


function damath_fermi_dirac_r(s, x: double): double; cdecl; export;
  {-Returns the Bose-Einstein integral of real order s >= -1}
begin
    damath_fermi_dirac_r:= fermi_dirac_r(s, x);
end;



function damath_fermi_dirac(n: integer; x: double): double; cdecl; export;
  {-Return the integer order Fermi-Dirac integral F_n(x) = 1/n!*integral(t^n/(exp(t-x)+1), t=0..INF)}
begin
    damath_fermi_dirac:= fermi_dirac(n, x);
end;


function damath_fermi_dirac_m05(x: double): double; cdecl; export;
  {-Return the complete Fermi-Dirac integral F(-1/2,x)}
begin
    damath_fermi_dirac_m05:= fermi_dirac_m05(x);
end;


function damath_fermi_dirac_p05(x: double): double; cdecl; export;
  {-Return the complete Fermi-Dirac integral F(1/2,x)}
begin
    damath_fermi_dirac_p05:= fermi_dirac_p05(x);
end;


function damath_fermi_dirac_p15(x: double): double; cdecl; export;
  {-Return the complete Fermi-Dirac integral F(3/2,x)}
begin
    damath_fermi_dirac_p15:= fermi_dirac_p15(x);
end;


function damath_fermi_dirac_p25(x: double): double; cdecl; export;
  {-Return the complete Fermi-Dirac integral F(5/2,x)}
begin
    damath_fermi_dirac_p25:= fermi_dirac_p25(x);
end;




function damath_LegendreChi(s, x: double): double; cdecl; export;
  {-Return Legendre's Chi-function damath_chi(s,x); s>=0, |x|<=1, x<>1 if s<=1}
begin
    damath_LegendreChi:= LegendreChi(s, x);
end;


function damath_LerchPhi(z,s,a: double): double; cdecl; export;
  {-Return the Lerch transcendent Phi(z,s,a) = sum(z^n/(n+a)^s, n=0..INF), |z|<=1, s>=0, a>=0; s>1 if z=1}
begin
    damath_LerchPhi:= LerchPhi(z, s, a);
end;


function damath_polylog(n: integer; x: double): double; cdecl; export;
  {-Return the polylogarithm Li_n(x) of integer order; x<1 for n >= 0}
begin
    damath_polylog:= polylog(n, x);
end;


function damath_polylogr(s, x: double): double; cdecl; export;
  {-Return the polylogarithm Li_s(x) of real order; s>=0, |x|<=1, x<>1 if s<=1}
begin
    damath_polylogr:= polylogr(s, x);
end;


function damath_dilog(x: double): double; cdecl; export;
  {-Return dilog(x) = Re(Li_2(x)), Li_2(x) = -integral(ln(1-t)/t, t=0..x)}
begin
    damath_dilog:= dilog(x);
end;


function damath_trilog(x: double): double; cdecl; export;
  {-Return the trilogarithm function damath_trilog(x) = Re(Li_3(x))}
begin
    damath_trilog:= trilog(x);
end;




function damath_cl2(x: double): double; cdecl; export;
  {-Return the Clausen function: integral(-ln(2*|sin(t/2)|),t=0..x) = Im(Li_2(exp(ix)))}
begin
    damath_cl2:= cl2(x);
end;


function damath_ti2(x: double): double; cdecl; export;
  {-Return the inverse tangent integral, ti2(x) = integral(arctan(t)/t, t=0..x)}
begin
    damath_ti2:= ti2(x);
end;



function damath_ti(s, x: double): double; cdecl; export;
  {-Return the inverse tangent integral, ti2(x) = integral(arctan(t)/t, t=0..x)}
begin
    damath_ti:= ti(s, x);
end;



function damath_lobachevsky_c(x: double): double; cdecl; export;
  {-Return the Lobachevski function L(x) = integral(-ln(|cos(t)|), t=0..x)}
begin
    damath_lobachevsky_c:= lobachevsky_c(x);
end;


function damath_lobachevsky_s(x: double): double; cdecl; export;
  {-Return the Lobachevski function Lambda(x) = integral(-ln(|2sin(t)|), t=0..x)}
begin
    damath_lobachevsky_s:= lobachevsky_s(x);
end;



function damath_harmonic(x: double): double; cdecl; export;
  {-Return the harmonic number function H(x) = psi(x+1) + EulerGamma}
begin
    damath_harmonic:= harmonic(x);
end;


function damath_harmonic2(x,r: double): double; cdecl; export;
  {-Return the harmonic number function H(x) = psi(x+1) + EulerGamma}
begin
    damath_harmonic2:= harmonic2(x, r);
end;




{*********************  Orthogonal polynomials and Legendre functions  **********************}


function damath_chebyshev_t(n: integer; x: double): double; cdecl; export;
  {-Return T_n(x), the Chebyshev polynomial of the first kind, degree n}
begin
    damath_chebyshev_t:= chebyshev_t(n, x);
end;


function damath_chebyshev_u(n: integer; x: double): double; cdecl; export;
  {-Return U_n(x), the Chebyshev polynomial of the second kind, degree n}
begin
    damath_chebyshev_u:= chebyshev_u(n, x);
end;


function damath_chebyshev_v(n: integer; x: double): double; cdecl; export;
  {-Return V_n(x), the Chebyshev polynomial of the third kind, degree n>=0}
begin
    damath_chebyshev_v:= chebyshev_v(n, x);
end;


function damath_chebyshev_w(n: integer; x: double): double; cdecl; export;
  {-Return W_n(x), the Chebyshev polynomial of the fourth kind, degree n>=0}
begin
    damath_chebyshev_w:= chebyshev_w(n, x);
end;


function damath_chebyshev_f1(n: integer; x: double): double; cdecl; export;
  {-Returns the Chebyshev function the first kind, real part for x < -1}
begin
    damath_chebyshev_f1:= chebyshev_f1(n, x);
end;


function damath_gegenbauer_c(n: integer; a,x: double): double; cdecl; export;
  {-Return Cn(a,x), the nth Gegenbauer (ultraspherical) polynomial with}
  { parameter a. The degree n must be non-negative; a should be > -0.5 }
  { When a = 0,   C0(0,x) = 1,  and   Cn(0,x) = 2/n*Tn(x)   for n <> 0.}
begin
    damath_gegenbauer_c:= gegenbauer_c(n, a, x);
end;


function damath_hermite_h(n: integer; x: double): double; cdecl; export;
  {-Return Hn(x), the nth Hermite polynomial, degree n >= 0}
begin
    damath_hermite_h:= hermite_h(n, x);
end;


function damath_hermite_he(n: integer; x: double): double; cdecl; export;
  {-Returns He_n(x), the nth "probabilists'" Hermite polynomial, degree n >= 0}
begin
    damath_hermite_he:= hermite_he(n, x);
end;


function damath_jacobi_p(n: integer; a,b,x: double): double; cdecl; export;
  {-Return Pn(a,b,x), the nth Jacobi polynomial with parameters a,b. Degree n}
  { must be >= 0; a,b should be > -1 (a+b must not be an integer < -1).}
begin
    damath_jacobi_p:= jacobi_p(n, a, b, x);
end;


function damath_laguerre(n: integer; a,x: double): double; cdecl; export;
  {-Return Ln(a,x), the nth generalized Laguerre polynomial with parameter a;}
  { degree n must be >= 0. x >=0 and a > -1 are the standard ranges.}
begin
    damath_laguerre:= laguerre(n, a, x);
end;


function damath_laguerre_l(n: integer; x: double): double; cdecl; export;
  {-Return the nth Laguerre polynomial Ln(0,x); n >= 0}
begin
    damath_laguerre_l:= laguerre_l(n, x);
end;


function damath_laguerre_ass(n,m: integer; x: double): double; cdecl; export;
  {-Return the associated Laguerre polynomial Ln(m,x); n,m >= 0}
begin
    damath_laguerre_ass:= laguerre_ass(n, m, x);
end;


function damath_legendre_p(l: integer; x: double): double; cdecl; export;
  {-Return P_l(x), the Legendre polynomial/function damath_P_l, degree l}
begin
    damath_legendre_p:= legendre_p(l, x);
end;


function damath_legendre_q(l: integer; x: double): double; cdecl; export;
  {-Return Q_l(x), the Legendre function damath_of the 2nd kind, degree l >=0, |x| <> 1}
begin
    damath_legendre_q:= legendre_q(l, x);
end;


function damath_legendre_plm(l,m: integer; x: double): double; cdecl; export;
  {-Return the associated Legendre polynomial P_lm(x)}
begin
    damath_legendre_plm:= legendre_plm(l, m, x);
end;


function damath_legendre_qlm(l,m: integer; x: double): double; cdecl; export;
  {-Return Q(l,m,x), the associated Legendre function damath_of the second kind; l >= 0, l+m >= 0, |x|<>1}
begin
    damath_legendre_qlm:= legendre_qlm(l, m, x);
end;


procedure damath_spherical_harmonic(l, m: integer; theta, phi: double; var yr,yi: double);
  {-Return Re and Im of the spherical harmonic function damath_Y_lm(theta,phi)}
begin
    spherical_harmonic(l, m, theta, phi, yr, yi);
end;


function damath_toroidal_qlm(l,m: integer; x: double): double; cdecl; export;
  {-Return the toroidal harmonic function damath_Q(l-0.5,m,x); l=0,1; x > 1}
begin
    damath_toroidal_qlm:= toroidal_qlm(l, m, x);
end;


function damath_toroidal_plm(l,m: integer; x: double): double; cdecl; export;
  {-Return the toroidal harmonic function damath_P(l-0.5,m,x); l,m=0,1; x >= 1}
begin
    damath_toroidal_plm:= toroidal_plm(l, m, x);
end;


function damath_besselpoly(n: integer; x: double): double; cdecl; export;
  {-Returns yn(x), the nth Bessel polynomial}
begin
    damath_besselpoly:= besselpoly(n, x);
end;


function damath_zernike_r(n,m: integer; r: double): double; cdecl; export;
  {-Return the Zernike radial polynomial Rnm(r), r >= 0, n >= m >= 0, n-m even}
begin
    damath_zernike_r:= zernike_r(n, m, r);
end;





{*********************  Hypergeometric functions  **********************}



function damath_hyperg_2F1(a,b,c,x: double): double; cdecl; export;
  {-Return the Gauss hypergeometric function damath_2F1(a,b;c;x)}
begin
    damath_hyperg_2F1:= hyperg_2F1(a, b, c, x);
end;


function damath_hyperg_2F1r(a,b,c,x: double): double; cdecl; export;
  {-Return the regularized Gauss hypergeometric function damath_2F1(a,b,c,x)/Gamma(c)}
begin
    damath_hyperg_2F1r:= hyperg_2F1r(a, b, c, x);
end;


function damath_hyperg_1F1(a,b,x: double): double; cdecl; export;
  {-Return the confluent hypergeometric function damath_1F1(a,b,x); Kummer's function damath_M(a,b,x)}
begin
    damath_hyperg_1F1:= hyperg_1F1(a, b, x);
end;


function damath_hyperg_1F1r(a,b,x: double): double; cdecl; export;
  {-Return the regularized Kummer hypergeometric function damath_1F1(a,b,x)/Gamma(b)}
begin
    damath_hyperg_1F1r:= hyperg_1F1r(a, b, x);
end;


function damath_hyperg_u(a,b,x: double): double; cdecl; export;
  {-Return Tricomi's confluent hypergeometric function damath_U(a,b,x), x>0}
begin
    damath_hyperg_u:= hyperg_u(a, b, x);
end;


function damath_hyperg_0F1(b,x: double): double; cdecl; export;
  {-Return the confluent hypergeometric limit function damath_0F1(;b;x)}
begin
    damath_hyperg_0F1:= hyperg_0F1(b, x);
end;


function damath_hyperg_0F1r(b,x: double): double; cdecl; export;
  {-Return the regularized confluent hypergeometric limit function damath_0F1(;b;x)/Gamma(b)}
begin
    damath_hyperg_0F1r:= hyperg_0F1r(b, x);
end;


function damath_hyperg_2F0(a,b,x: double): double; cdecl; export;
  {-Returns 2F0(a,b,x), if x>0 then a or b must be a negative integer}
begin
    damath_hyperg_2F0:= hyperg_2F0(a, b, x);
end;


function damath_WhittakerM(k,m,x: double): double; cdecl; export;
  {-Return the Whittaker M function damath_= exp(-x/2)*x^(0.5+m) * 1F1(m-k-0.5,2m+1,x)}
begin
    damath_WhittakerM:= WhittakerM(k, m, x);
end;


function damath_WhittakerW(k,m,x: double): double; cdecl; export;
  {-Return the Whittaker W function damath_= exp(-x/2)*x^(0.5+m) * U(m-k-0.5,2m+1,x)}
begin
    damath_WhittakerW:= WhittakerW(k, m, x);
end;


function damath_CylinderD(v,x: double): double; cdecl; export;
  {-Return Whittaker's parabolic cylinder function D_v(x)}
begin
    damath_CylinderD:= CylinderD(v, x);
end;


function damath_CylinderU(a,x: double): double; cdecl; export;
  {-Return the parabolic cylinder function U(a,x)}
begin
    damath_CylinderU:= CylinderU(a, x);
end;


function damath_CylinderV(a,x: double): double; cdecl; export;
  {-Return the parabolic cylinder function V(a,x) with 2a integer}
begin
    damath_CylinderV:= CylinderV(a, x);
end;


function damath_HermiteH(v,x: double): double; cdecl; export;
  {-Return the Hermite function H_v(x) of degree v}
begin
    damath_HermiteH:= HermiteH(v, x);
end;







{*********************  Statistical distributions  **********************}

{---------------------- Beta distribution --------------------------}

function damath_beta_pdf(a, b, x: double): double; cdecl; export;
  {-Return the probability density function damath_of the beta distribution with}
  { parameters a and b: beta_pdf = x^(a-1)*(1-x)^(b-1) / beta(a,b)}
begin
    damath_beta_pdf:= beta_pdf(a, b, x);
end;


function damath_beta_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative beta distribution function, a>0, b>0}
begin
    damath_beta_cdf:= beta_cdf(a, b, x);
end;


function damath_beta_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the beta distribution function. a>0, b>0;}
  { 0 <= y <= 1. Given y the function damath_finds x such that beta_cdf(a, b, x) = y}
begin
    damath_beta_inv:= beta_inv(a, b, y);
end;



{---------------------- Binomial distribution --------------------------}

function damath_binomial_cdf(p: double; n, k: longint): double; cdecl; export;
  {-Return the cumulative binomial distribution function damath_with number}
  { of trials n >= 0 and success probability 0 <= p <= 1}
begin
    damath_binomial_cdf:= binomial_cdf(p, n, k);
end;


function damath_binomial_pmf(p: double; n, k: longint): double; cdecl; export;
  {-Return the binomial distribution probability mass function damath_with number}
  { of trials n >= 0 and success probability 0 <= p <= 1}
begin
    damath_binomial_pmf:= binomial_pmf(p, n, k);
end;



{---------------------- Cauchy distribution --------------------------}

function damath_cauchy_pdf(a, b, x: double): double; cdecl; export;
  {-Return the Cauchy probability density function damath_with location a }
  { and scale b > 0, 1/(Pi*b*(1+((x-a)/b)^2))}
begin
    damath_cauchy_pdf:= cauchy_pdf(a, b, x);
end;


function damath_cauchy_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative Cauchy distribution function damath_with location a}
  { and scale b > 0, = 1/2 + arctan((x-a)/b)/Pi}
begin
    damath_cauchy_cdf:= cauchy_cdf(a, b, x);
end;


function damath_cauchy_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of Cauchy distribution function}
  { with location a and scale b > 0}
begin
    damath_cauchy_inv:= cauchy_inv(a, b, y);
end;


{---------------------- Chi distribution --------------------------}

function damath_chi_pdf(nu: longint; x: double): double; cdecl; export;
  {-Return the probability density function damath_of the chi-square distribution, nu>0}
begin
    damath_chi_pdf:= chi_pdf(nu, x);
end;


function damath_chi_cdf(nu: longint; x: double): double; cdecl; export;
  {-Return the cumulative chi-square distribution with nu>0 degrees of freedom, x >= 0}
begin
    damath_chi_cdf:= chi_cdf(nu, x);
end;


function damath_chi_inv(nu: longint; p: double): double; cdecl; export;
  {-Return the functional inverse of the chi-square distribution, nu>0, 0 <= p < 1}
begin
    damath_chi_inv:= chi_inv(nu, p);
end;




{---------------------- Chi-square distribution --------------------------}

function damath_chi2_pdf(nu: longint; x: double): double; cdecl; export;
  {-Return the probability density function damath_of the chi-square distribution, nu>0}
begin
    damath_chi2_pdf:= chi2_pdf(nu, x);
end;


function damath_chi2_cdf(nu: longint; x: double): double; cdecl; export;
  {-Return the cumulative chi-square distribution with nu>0 degrees of freedom, x >= 0}
begin
    damath_chi2_cdf:= chi2_cdf(nu, x);
end;


function damath_chi2_inv(nu: longint; p: double): double; cdecl; export;
  {-Return the functional inverse of the chi-square distribution, nu>0, 0 <= p < 1}
begin
    damath_chi2_inv:= chi2_inv(nu, p);
end;



{---------------------- Exponential distribution --------------------------}

function damath_exp_pdf(a, alpha, x: double): double; cdecl; export;
  {-Return the exponential probability density function damath_with location a }
  { and rate alpha > 0, = alpha*exp(-alpha*(x-a)) if x >= a, 0 if x < a.}
begin
    damath_exp_pdf:= exp_pdf(a, alpha, x);
end;


function damath_exp_cdf(a, alpha, x: double): double; cdecl; export;
  {-Return the cumulative exponential distribution function damath_with location a}
  { and rate alpha > 0, = 1 - exp(-alpha*(x-a)) if x >= a, 0 if x < a.}
begin
    damath_exp_cdf:= exp_cdf(a, alpha, x);
end;


function damath_exp_inv(a, alpha, y: double): double; cdecl; export;
  {-Return the functional inverse of exponential distribution function damath_with}
  { location a and rate alpha > 0}
begin
    damath_exp_inv:= exp_inv(a, alpha, y);
end;



{---------------------- Extreme Value Type I distribution --------------------------}

function damath_evt1_pdf(a, b, x: double): double; cdecl; export;
  {-Return the probability density function damath_of the Extreme Value Type I distribution}
  { with location a and scale b > 0, result = exp(-(x-a)/b)/b * exp(-exp(-(x-a)/b)) }
begin
    damath_evt1_pdf:= evt1_pdf(a, b, x);
end;


function damath_evt1_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative Extreme Value Type I distribution function}
  { with location a and scale b > 0;  result = exp(-exp(-(x-a)/b)). }
begin
    damath_evt1_cdf:= evt1_cdf(a, b, x);
end;


function damath_evt1_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the Extreme Value Type I distribution}
  { function damath_with location a and scale b > 0;  result = a - b*ln(ln(-y)). }
begin
    damath_evt1_inv:= evt1_inv(a, b, y);
end;



{---------------------- F-distribution --------------------------}

function damath_f_pdf(nu1, nu2: longint; x: double): double; cdecl; export;
  {-Return the probability density function damath_of the F distribution; x >= 0, nu1, nu2 > 0}
begin
    damath_f_pdf:= f_pdf(nu1, nu2, x);
end;


function damath_f_cdf(nu1, nu2: longint; x: double): double; cdecl; export;
  {-Return the cumulative F distribution function; x >= 0, nu1, nu2 > 0}
begin
    damath_f_cdf:= f_cdf(nu1, nu2, x);
end;


function damath_f_inv(nu1, nu2: longint; y: double): double; cdecl; export;
  {-Return the functional inverse of the F distribution, nu1, nu2 > 0, 0 <= y <= 1}
begin
    damath_f_inv:= f_inv(nu1, nu2, y);
end;



{---------------------- Gamma distribution --------------------------}

function damath_gamma_pdf(a, b, x: double): double; cdecl; export;
  {-Return the probability density function damath_of a gamma distribution with shape}
  { a>0, scale b>0: gamma_pdf = x^(a-1)*exp(-x/b)/gamma(a)/b^a, x>0}
begin
    damath_gamma_pdf:= gamma_pdf(a, b, x);
end;


function damath_gamma_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative gamma distribution function, shape a>0, scale b>0}
begin
    damath_gamma_cdf:= gamma_cdf(a, b, x);
end;


function damath_gamma_inv(a, b, p: double): double; cdecl; export;
  {-Return the functional inverse of the gamma distribution function, shape a>0,}
  { scale b>0, 0 <= p <= 1, i.e. finds x such that gamma_cdf(a, b, x) = p}
begin
    damath_gamma_inv:= gamma_inv(a, b, p);
end;



{---------------------- Hypergeometric distribution --------------------------}

function damath_hypergeo_pmf(n1,n2,n,k: longint): double; cdecl; export;
  {-Return the hypergeometric distribution probability mass function; n,n1,n2 >= 0, n <= n1+n2;}
  { i.e. the probability that among n randomly chosen samples from a container}
  { with n1 type1 objects and n2 type2 objects are exactly k type1 objects:}
begin
    damath_hypergeo_pmf:= hypergeo_pmf(n1, n2, n, k);
end;


function damath_hypergeo_cdf(n1,n2,n,k: longint): double; cdecl; export;
  {-Return the cumulative hypergeometric distribution function; n,n1,n2 >= 0, n <= n1+n2}
begin
    damath_hypergeo_cdf:= hypergeo_cdf(n1, n2, n, k);
end;



{---------------------- Inverse gamma distribution --------------------------}

function damath_invgamma_pdf(a, b, x: double): double; cdecl; export;
  {-Return the probability density function of an inverse gamma distribution}
  { with shape a>0, scale b>0: result = (b/x)^a/x*exp(-b/x)/Gamma(a), x >= 0}
begin
    damath_invgamma_pdf:= invgamma_pdf(a, b, x);
end;


function damath_invgamma_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative inverse gamma distribution function, shape a>0, scale}
  { b>0: result = Gamma(a,b/x)/Gamma(a) = Q(a,b/x) = igammaq(a,b/x), x >= 0}
begin
    damath_invgamma_cdf:= invgamma_cdf(a, b, x);
end;


function damath_invgamma_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the inverse gamma distribution function, shape}
  { a>0, scale b>0, 0 <= y <= 1, i.e. find x such that invgamma_cdf(a, b, x) = y  }
begin
    damath_invgamma_inv:= invgamma_inv(a, b, y);
end;



{---------------------- Kumaraswamy distribution --------------------------}

function damath_kumaraswamy_pdf(a, b, x: double): double; cdecl; export;
  {-Return the Kumaraswamy probability density function damath_with shape}
  { parameters a,b>0, 0<=x<=1; result = a*b*x^(a-1)*(1-x^a)^(b-1) }
begin
    damath_kumaraswamy_pdf:= kumaraswamy_pdf(a, b, x);
end;


function damath_kumaraswamy_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative Kumaraswamy distribution function damath_with}
  { shape parameters a,b > 0, 0 <= x <= 1; result = 1-(1-x^a)^b}
begin
    damath_kumaraswamy_cdf:= kumaraswamy_cdf(a, b, x);
end;


function damath_kumaraswamy_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the Kumaraswamy distribution}
  { with shape parameters a,b > 0; result = [1-(1-y)^(1/b)]^(1/a)}
begin
    damath_kumaraswamy_inv:= kumaraswamy_inv(a, b, y);
end;



{---------------------- Kolmogorov distribution --------------------------}

function damath_kolmogorov_cdf(x: double): double; cdecl; export;
  {-Returns the limiting form for the cumulative Kolmogorov distribution function}
begin
    damath_kolmogorov_cdf:= kolmogorov_cdf(x);
end;


function damath_kolmogorov_inv(y: double): double; cdecl; export;
  {-Returns the functional inverse of the Kolmogorov distribution}
begin
    damath_kolmogorov_inv:= kolmogorov_inv(y);
end;



{---------------------- Laplace distribution --------------------------}

function damath_laplace_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative Laplace distribution function damath_with location a and scale b > 0}
begin
    damath_laplace_cdf:= laplace_cdf(a, b, x);
end;


function damath_laplace_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the Laplace distribution with location a and scale b > 0}
begin
    damath_laplace_inv:= laplace_inv(a, b, y);
end;


function damath_laplace_pdf(a, b, x: double): double; cdecl; export;
  {-Return the Laplace probability density function damath_with location a}
  { and scale b > 0, result = exp(-abs(x-a)/b) / (2*b)}
begin
    damath_laplace_pdf:= laplace_pdf(a, b, x);
end;



{---------------------- Levy distribution --------------------------}

function damath_levy_pdf(a, b, x: double): double; cdecl; export;
  {-Return the Levy probability density function with}
  { location a and scale parameter b > 0}
begin
    damath_levy_pdf:= levy_pdf(a, b, x);
end;


function damath_levy_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative Levy distribution function with}
  { location a and scale parameter b > 0}
begin
    damath_levy_cdf:= levy_cdf(a, b, x);
end;


function damath_levy_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the Levy distribution}
  { with location a and scale parameter b > 0}
begin
    damath_levy_inv:= levy_inv(a, b, y);
end;



{---------------------- Logarithmic (series) distribution --------------------------}

function damath_logseries_pmf(a: double; k: longint): double; cdecl; export;
  {-Return the logarithmic (series) probability mass function}
  { with shape 0 < a < 1, k > 0; result = -a^k/(k*ln(1-a))   }
begin
    damath_logseries_pmf:= logseries_pmf(a, k);
end;


function damath_logseries_cdf(a: double; k: longint): double; cdecl; export;
  {-Return the cumulative logarithmic (series) distribution function with shape 0 < a < 1, k > 0}
begin
    damath_logseries_cdf:= logseries_cdf(a, k);
end;



{---------------------- Logistic distribution --------------------------}

function damath_logistic_pdf(a, b, x: double): double; cdecl; export;
  {-Return the logistic probability density function damath_with location a}
  { and scale parameter b > 0, exp(-(x-a)/b)/b/(1+exp(-(x-a)/b))^2}
begin
    damath_logistic_pdf:= logistic_pdf(a, b, x);
end;


function damath_logistic_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative logistic distribution function damath_with}
  { location a and scale parameter b > 0}
begin
    damath_logistic_cdf:= logistic_cdf(a, b, x);
end;


function damath_logistic_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the logistic distribution}
  { with location a and scale parameter b > 0}
begin
    damath_logistic_inv:= logistic_inv(a, b, y);
end;


{---------------------- Log-normal distribution --------------------------}

function damath_lognormal_pdf(a, b, x: double): double; cdecl; export;
  {-Return the log-normal probability density function damath_with}
  { location a and scale parameter b > 0, zero for x <= 0.}
begin
    damath_lognormal_pdf:= lognormal_pdf(a, b, x);
end;


function damath_lognormal_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative log-normal distribution function damath_with}
  { location a and scale parameter b > 0, zero for x <= 0.}
begin
    damath_lognormal_cdf:= lognormal_cdf(a, b, x);
end;


function damath_lognormal_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the log-normal distribution}
  { with location a and scale parameter b > 0, 0 < y < 1.}
begin
    damath_lognormal_inv:= lognormal_inv(a, b, y);
end;



{---------------------- Maxwell distribution --------------------------}

function damath_maxwell_pdf(b, x: double): double; cdecl; export;
  {-Return the Maxwell probability density function damath_with scale b > 0, x >= 0}
begin
    damath_maxwell_pdf:= maxwell_pdf(b, x);
end;


function damath_maxwell_cdf(b, x: double): double; cdecl; export;
  {-Return the cumulative Maxwell distribution function damath_with scale b > 0, x >= 0}
begin
    damath_maxwell_cdf:= maxwell_cdf(b, x);
end;


function damath_maxwell_inv(b, y: double): double; cdecl; export;
  {-Return the functional inverse of the Maxwell distribution with scale b > 0}
begin
    damath_maxwell_inv:= maxwell_inv(b, y);
end;



{---------------------- Moyal distribution --------------------------}

function damath_moyal_pdf(a, b, x: double): double; cdecl; export;
  {-Return the Moyal probability density function damath_with}
  { location a and scale parameter b > 0}
begin
    damath_moyal_pdf:= moyal_pdf(a, b, x);
end;


function damath_moyal_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative Moyal distribution function damath_with}
  { location a and scale parameter b > 0}
begin
    damath_moyal_cdf:= moyal_cdf(a, b, x);
end;


function damath_moyal_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the Moyal distribution}
  { with location a and scale parameter b > 0}
begin
    damath_moyal_inv:= moyal_inv(a, b, y);
end;



{---------------------- Nakagami distribution --------------------------}

function damath_nakagami_pdf(a, b, x: double): double; cdecl; export;
  {-Returns the probability density function of the Nakagami distribution }
begin
    damath_nakagami_pdf:= nakagami_pdf(a, b, x);
end;


function damath_nakagami_cdf(a, b, x: double): double; cdecl; export;
  {-Returns the cumulative Nakagami distribution function, shape m>0, spread w>0}
begin
    damath_nakagami_cdf:= nakagami_cdf(a, b, x);
end;


function damath_nakagami_inv(a, b, y: double): double; cdecl; export;
  {-Returns the functional inverse of the Nakagami distribution function}
begin
    damath_nakagami_inv:= nakagami_inv(a, b, y);
end;




{---------------------- Negative binomial distribution --------------------------}

function damath_negbinom_cdf(p,r: double; k: longint): double; cdecl; export;
  {-Return the cumulative negative binomial distribution function damath_with target}
  { for number of successful trials r > 0 and success probability 0 <= p <= 1}
begin
    damath_negbinom_cdf:= negbinom_cdf(p, r, k);
end;


function damath_negbinom_pmf(p,r: double; k: longint): double; cdecl; export;
  {-Return the negative binomial distribution probability mass function damath_with target}
  { for number of successful trials r > 0 and success probability 0 <= p <= 1}
begin
    damath_negbinom_pmf:= negbinom_pmf(p, r, k);
end;



{---------------------- Normal (Gaussian) distribution --------------------------}

function damath_normal_pdf(mu, sd, x: double): double; cdecl; export;
  {-Return the normal (Gaussian) probability density function damath_with mean mu}
  { and standard deviation sd>0, exp(-0.5*(x-mu)^2/sd^2) / sqrt(2*Pi*sd^2)}
begin
    damath_normal_pdf:= normal_pdf(mu, sd, x);
end;


function damath_normal_cdf(mu, sd, x: double): double; cdecl; export;
  {-Return the normal (Gaussian) distribution density function}
  { with mean mu and standard deviation sd > 0}
begin
    damath_normal_cdf:= normal_cdf(mu, sd, x);
end;


function damath_normal_inv(mu, sd, y: double): double; cdecl; export;
  {-Return the functional inverse of the normal (Gaussian) distribution}
  { with mean mu and standard deviation sd > 0, 0 < y < 1.}
begin
    damath_normal_inv:= normal_inv(mu, sd, y);
end;



{---------------------- Pareto distribution --------------------------}

function damath_pareto_pdf(k, a, x: double): double; cdecl; export;
  {-Return the Pareto probability density function damath_with minimum value k > 0}
  { and shape a, x >= a > 0, result = (a/x)*(k/x)^a}
begin
    damath_pareto_pdf:= pareto_pdf(k, a, x);
end;


function damath_pareto_cdf(k, a, x: double): double; cdecl; export;
  {-Return the cumulative Pareto distribution function damath_minimum value k > 0}
  { and shape a, x >= a > 0, result = 1-(k/x)^a}
begin
    damath_pareto_cdf:= pareto_cdf(k, a,x);
end;


function damath_pareto_inv(k, a, y: double): double; cdecl; export;
  {-Return the functional inverse of the Pareto distribution with minimum}
  { value k > 0 and shape a, x >= a > 0, result = k/(1-x)^(1/a)}
begin
    damath_pareto_inv:= pareto_inv(k, a, y);
end;



{---------------------- Poisson distribution --------------------------}

function damath_poisson_cdf(mu: double; k: longint): double; cdecl; export;
  {-Return the cumulative Poisson distribution function damath_with mean mu >= 0}
begin
    damath_poisson_cdf:= poisson_cdf(mu, k);
end;


function damath_poisson_pmf(mu: double; k: longint): double; cdecl; export;
  {-Return the Poisson distribution probability mass function damath_with mean mu >= 0}
begin
    damath_poisson_pmf:= poisson_pmf(mu, k);
end;



{---------------------- Rayleigh distribution --------------------------}

function damath_rayleigh_pdf(b, x: double): double; cdecl; export;
  {-Return the Rayleigh probability density function damath_with}
  { scale b > 0, x >= 0; result = x*exp(-0.5*(x/b)^2)/b^2}
begin
    damath_rayleigh_pdf:= rayleigh_pdf(b, x);
end;


function damath_rayleigh_cdf(b, x: double): double; cdecl; export;
  {-Return the cumulative Rayleigh distribution function damath_with scale b > 0, x >= 0}
begin
    damath_rayleigh_cdf:= rayleigh_cdf(b, x);
end;


function damath_rayleigh_inv(b, y: double): double; cdecl; export;
  {-Return the functional inverse of the Rayleigh distribution with scale b > 0}
begin
    damath_rayleigh_inv:= rayleigh_inv(b, y);
end;



{---------------------- Standard normal distribution --------------------------}

function damath_normstd_pdf(x: double): double; cdecl; export;
  {-Return the std. normal probability density function damath_exp(-x^2/2)/sqrt(2*Pi)}
begin
    damath_normstd_pdf:= normstd_pdf(x);
end;


function damath_normstd_cdf(x: double): double; cdecl; export;
  {-Return the standard normal distribution function}
begin
    damath_normstd_cdf:= normstd_cdf(x);
end;


function damath_normstd_inv(y: double): double; cdecl; export;
  {-Return the inverse standard normal distribution function, 0 < y < 1.}
  { For x=normstd_inv(y) and y from (0,1), normstd_cdf(x) = y}
begin
    damath_normstd_inv:= normstd_inv(y);
end;



{---------------------- t-distribution --------------------------}

function damath_t_pdf(nu: longint; x: double): double; cdecl; export;
  {-Return the probability density function damath_of Student's t distribution, nu>0}
begin
    damath_t_pdf:= t_pdf(nu, x);
end;


function damath_t_cdf(nu: longint; t: double): double; cdecl; export;
  {-Return the cumulative Student t distribution with nu>0 degrees of freedom}
begin
    damath_t_cdf:= t_cdf(nu, t);
end;


function damath_t_inv(nu: longint; p: double): double; cdecl; export;
  {-Return the functional inverse of Student's t distribution, nu>0, 0 <= p <= 1}
begin
    damath_t_inv:= t_inv(nu, p);
end;



{---------------------- Triangular distribution --------------------------}

function damath_triangular_pdf(a, b, c, x: double): double; cdecl; export;
  {-Return the triangular probability density function damath_with}
  { lower limit a, upper limit b, mode c;  a<b, a <= c <= b}
begin
    damath_triangular_pdf:= triangular_pdf(a, b, c, x);
end;


function damath_triangular_cdf(a, b, c, x: double): double; cdecl; export;
  {-Return the cumulative triangular distribution function damath_with}
  { lower limit a, upper limit b, mode c;  a<b, a <= c <= b}
begin
    damath_triangular_cdf:= triangular_cdf(a, b, c, x);
end;


function damath_triangular_inv(a, b, c, y: double): double; cdecl; export;
  {-Return the functional inverse of the triangular distribution with}
  { lower limit a, upper limit b, mode c; a<b, a <= c <= b, 0 <= y <= 1}
begin
    damath_triangular_inv:= triangular_inv(a, b, c, y);
end;



{---------------------- Uniform distribution --------------------------}

function damath_uniform_pdf(a, b, x: double): double; cdecl; export;
  {-Return the uniform probability density function damath_on [a,b], a<b}
begin
    damath_uniform_pdf:= uniform_pdf(a, b, x);
end;


function damath_uniform_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative uniform distribution function damath_on [a,b], a<b}
begin
    damath_uniform_cdf:= uniform_cdf(a, b, x);
end;


function damath_uniform_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the uniform distribution on [a,b], a<b}
begin
    damath_uniform_inv:= uniform_inv(a, b, y);
end;



{---------------------- Wald or inverse Gaussian distribution --------------------------}

function damath_wald_pdf(mu, b, x: double): double; cdecl; export;
  {-Return the uniform probability density function damath_on [a,b], a<b}
begin
    damath_wald_pdf:= wald_pdf(mu, b, x);
end;


function damath_wald_cdf(mu, b, x: double): double; cdecl; export;
  {-Return the cumulative uniform distribution function damath_on [a,b], a<b}
begin
    damath_wald_cdf:= wald_cdf(mu, b, x);
end;


function damath_wald_inv(mu, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the uniform distribution on [a,b], a<b}
begin
    damath_wald_inv:= wald_inv(mu, b, y);
end;




{---------------------- Weibull distribution --------------------------}

function damath_weibull_pdf(a, b, x: double): double; cdecl; export;
  {-Return the Weibull probability density function damath_with shape a > 0}
  { and scale b > 0, result = a*x^(a-1)*exp(-(x/b)^a)/ b^a, x > 0}
begin
    damath_weibull_pdf:= weibull_pdf(a, b, x);
end;


function damath_weibull_cdf(a, b, x: double): double; cdecl; export;
  {-Return the cumulative Weibull distribution function damath_with}
  { shape parameter a > 0 and scale parameter b > 0}
begin
    damath_weibull_cdf:= weibull_cdf(a, b, x);
end;


function damath_weibull_inv(a, b, y: double): double; cdecl; export;
  {-Return the functional inverse of the Weibull distribution}
  { shape parameter a > 0 and scale parameter b > 0}
begin
    damath_weibull_inv:= weibull_inv(a, b, y);
end;


{---------------------- Zipf distribution --------------------------}

function damath_zipf_pmf(r: double; k: longint): double; cdecl; export;
  {-Return the Zipf distribution probability mass function k^(-(r+1))/zeta(r+1), r>0, k>0}
begin
    damath_zipf_pmf:= zipf_pmf(r, k);
end;


function damath_zipf_cdf(r: double; k: longint): double; cdecl; export;
  {-Return the cumulative Zipf distribution function H(k,r+1)/zeta(r+1), r>0, k>0}
begin
    damath_zipf_cdf:= zipf_cdf(r, k);
end;






{*********************** Other special functions *********************************}


function damath_agm(x,y: double): double; cdecl; export;
  {-Return the arithmetic-geometric mean of |x| and |y|}
begin
    damath_agm:= agm(x, y);
end;


function damath_bernoulli(n: integer): double; cdecl; export;
  {-Return the nth Bernoulli number, 0 if n<0 or odd n >= 3}
begin
    damath_bernoulli:= bernoulli(n);
end;


function damath_bernpoly(n: integer; x: double): double; cdecl; export;
  {-Return the Bernoulli polynomial B_n(x), 0 <= n <= MaxBernoulli}
begin
    damath_bernpoly:= bernpoly(n, x);
end;


function damath_bring(x: double): double; cdecl; export;
  {-Returns the Bring radical b := BR(x) with b^5 + b + x = 0}
begin
    damath_bring:= bring(x);
end;



function damath_catalan(x: double): double; cdecl; export;
  {-Return the Catalan function C(x) = binomial(2x,x)/(x+1)}
begin
    damath_catalan:= catalan(x);
end;



function damath_debye(n: integer; x: double): double; cdecl; export;
  {-Return the Debye function D(n,x) = n/x^n*integral(t^n/(exp(t)-1),t=0..x) of order n>0, x>=0}
begin
    damath_debye:= debye(n, x);
end;



function damath_einstein(n: integer; x: double): double; cdecl; export;
  {-Returns the Einstein function E_n, n=1..4, x > 0 for n=3,4}
begin
    damath_einstein:= einstein(n, x);
end;



function damath_euler(n: integer): double; cdecl; export;
  {-Return the nth Euler number, 0 if n<0 or odd n}
begin
    damath_euler:= euler(n);
end;



function damath_eulerpoly(n: integer; x: double): double; cdecl; export;
  {-Returns the Euler polynomial E_n(x), 0 <= n < MaxBernoulli}
begin
    damath_eulerpoly:= eulerpoly(n, x);
end;



function damath_expreln(n: integer; x: double): double; cdecl; export;
  {-Returns the relative exponential = (e^x-sum(x^k/k!, k=0..n-1)*n!/x^n}
begin
    damath_expreln:= expreln(n, x);
end;



function damath_fibpoly(n: integer; x: double): double; cdecl; export;
  {-Return the Fibonacci polynomial F_n(x)}
begin
    damath_fibpoly:= fibpoly(n, x);
end;



function damath_fibfun(v, x: double): double; cdecl; export;
  {-Return the Fibonacci polynomial F_n(x)}
begin
    damath_fibfun:= fibfun(v, x);
end;



function damath_cosint(n: integer; x: double): double; cdecl; export;
  {-Return cosint(n, x) = integral(cos(t)^n, t=0..x), n>=0}
begin
    damath_cosint:= cosint(n, x);
end;


function damath_sinint(n: integer; x: double): double; cdecl; export;
  {-Return sinint(n, x) = integral(sin(t)^n, t=0..x), n>=0}
begin
    damath_sinint:= sinint(n, x);
end;



function damath_LambertW(x: double): double; cdecl; export;
  {-Return the Lambert W function W_(principal branch), x >= -1/e}
begin
    damath_LambertW:= LambertW(x);
end;


function damath_LambertW1(x: double): double; cdecl; export;
  {-Return the Lambert W function W_(-1 branch), -1/e <= x < 0}
begin
    damath_LambertW1:= LambertW1(x);
end;



function damath_LangevinL(x: double): double; cdecl; export;
  {-Return the Langevin function L(x) = coth(x) - 1/x, L(0) = 0}
begin
    damath_LangevinL:= LangevinL(x);
end;


function damath_LangevinL_inv(x: double): double; cdecl; export;
  {-Returns the functional inverse of the Langevin function, |x| < 1}
begin
    damath_LangevinL_inv:= LangevinL_inv(x);
end;



function damath_lucpoly(n: integer; x: double): double; cdecl; export;
  {-Return the Lucas polynomial L_n(x)}
begin
    damath_lucpoly:= lucpoly(n, x);
end;



function damath_euler_q(q: double): double; cdecl; export;
  {-Returns the EulerQ function product(1-q^n, n=1..Inf), |q| <= 1}
begin
    damath_euler_q:= euler_q(q);
end;



function damath_RiemannR(x: double): double; cdecl; export;
  {-Return the Riemann prime counting function R(x), x >= 1/16}
begin
    damath_RiemannR:= RiemannR(x);
end;


function damath_RiemannR_inv(x: double): double; cdecl; export;
  {-Return the Riemann prime counting function R(x), x >= 1/16}
begin
    damath_RiemannR_inv:= RiemannR_inv(x);
end;



function damath_rrcf(q: double): double; cdecl; export;
  {-Returns the Rogers-Ramanujan continued fraction for |q| < 1}
begin
    damath_rrcf:= rrcf(q);
end;



function damath_kepler(M, e: double): double; cdecl; export;
  {-Solve Kepler's equation, result x is the eccentric anomaly from the mean anomaly M and the }
  { eccentricity e >= 0; x - e*sin(x) = M, x + x^3/3 = M, or e*sinh(x) - x = M for e <1, =1, >1}
begin
    damath_kepler:= kepler(M, e);
end;



function damath_transport(n: integer; x: double): double; cdecl; export;
  {-Returns the transport integral J_n(x) for x >= 0, n >= 2; J_n(x) = integral(t^n*exp(t)/(exp(t)-1)^2, t=0..x)}
begin
    damath_transport:= transport(n, x);
end;



function damath_expn(n: integer; x: double): double; cdecl; export;
  {-Returns the truncated exponential sum function e_n = sum(x^k/k!, k=0..n), 0 &#8804; n &lt; MAXGAM-1}
begin
    damath_expn:= expn(n, x);
end;



function damath_omega(x: double): double; cdecl; export;
  {-Returns the Wright omega function, i.e. the solution w of w + ln(w) = x}
begin
    damath_omega:= omega(x);
end;








{********************* Complex Numbers ***************************************************}




function damath_cabs(const z_re, z_im: double): double;  cdecl; export;        
  {-Return the complex absolute value |z| = sqrt(z.re^2 + z.im^2)}
var z: complex;
var y: double;
begin
   z.re := z_re;
   z.im := z_im;
   y := cabs(z);
   damath_cabs := y;
end;



procedure damath_cadd(const x_re, x_im, y_re, y_im: double; var z_re, z_im: double);  cdecl; export;         
  {-Return the complex sum z = x + y}
var x, y, z: complex;
begin
   x.re := x_re; x.im := x_im;
   y.re := y_re; y.im := y_im;
   cadd(x, y, z);
   z_re := z.re; z_im := z.im;
end;



function damath_carg(const z_re, z_im: double): double;  cdecl; export;        
  {-Return the principle value of the argument or phase angle arg(z) = arctan2(z.im, z.re)}
var z: complex;
var y: double;
begin
   z.re := z_re;
   z.im := z_im;
   y := carg(z);
   damath_carg := y;
end;



procedure damath_ccis(const x: double; var w_re, w_im: double);  cdecl; export;   
  {-Return z = exp(i*x) = cos(x) + i*sin(x)}
  var w: complex;
begin
   ccis(x, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cconj(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex conjugate w = z.re - i*z.im}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cconj(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_cdiv(const x_re, x_im, y_re, y_im: double; var z_re, z_im: double);  cdecl; export;        
  {-Return the quotient z = x/y}
var x, y, z: complex;
begin
   x.re := x_re; x.im := x_im;
   y.re := y_re; y.im := y_im;
   cdiv(x, y, z);
   z_re := z.re; z_im := z.im;
end;



procedure damath_cinv(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex inverse w = 1/z}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cinv(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cmul(const x_re, x_im, y_re, y_im: double; var z_re, z_im: double);  cdecl; export;        
  {-Return the complex product z = x*y}
var x, y, z: complex;
begin
   x.re := x_re; x.im := x_im;
   y.re := y_re; y.im := y_im;
   cmul(x, y, z);
   z_re := z.re; z_im := z.im;
end;



procedure damath_cneg(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the negative w = -z}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cneg(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cpolar(const z_re, z_im: double; var r, theta: double); cdecl; export;
  {-Return the polar form z = r*exp(i*theta) with r = |z|, theta = arg z}
  var z: complex;
  var rx, thetax: double;
begin
   z.re := z_re; z.im := z_im;
   cpolar(z, rx, thetax);
   r := rx; theta := thetax;
end;



procedure damath_cpowi(const z_re, z_im: double; n : longint ; var w_re, w_im: double);  cdecl; export;
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cpowi(z, n, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_rdivc(const x, z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   rdivc(x, z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csqr(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;  
  {-Return the square w = z^2}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csqr(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csqrt(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex principal square root w = sqrt(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csqrt(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csqrt1mz2(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex principal square root w = sqrt(1-z^2)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csqrt1mz2(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csub(const x_re, x_im, y_re, y_im: double; var z_re, z_im: double);  cdecl; export;        
  {-Return the complex difference z = x - y}
var x, y, z: complex;
begin
   x.re := x_re; x.im := x_im;
   y.re := y_re; y.im := y_im;
   csub(x, y, z);
   z_re := z.re; z_im := z.im;
end;






procedure damath_cagm(const x_re, x_im, y_re, y_im: double; var w_re, w_im: double);  cdecl; export;        
  {-Return the 'optimal' arithmetic-geometric mean w = AGM(x,y)}
var x, y, w: complex;
begin
   x.re := x_re; x.im := x_im;
   y.re := y_re; y.im := y_im;
   cagm(x, y, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cagm1(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the 'optimal' arithmetic-geometric mean w = AGM(1,z)}
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cagm1(z, w);
   w_re := w.re; w_im := w.im;
end;





procedure damath_carccos(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  {-Return the principal value of the complex inverse circular cosine w = arccos(z)}
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carccos(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_carccosh(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  {-Return the principal value of the complex inverse hyperbolic cosine w = arccosh(z)}
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carccosh(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carccot(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  {-Return the principal value of the complex inverse circular cotangent w = arccot(z) = arctan(1/z)}
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carccot(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_carccotc(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  {-Return the principal value of the complex inverse circular cotangent w = arccotc(z) = Pi/2 - arctan(z)}  
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carccotc(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carccoth(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  {-Return the principal value of the complex inverse hyperbolic cotangent w = arccoth(z) = arctanh(1/z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carccoth(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carccothc(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  {-Return the principal value of the complex inverse hyperbolic cotangent w = arccothc(z) = arctanh(z) + i*Pi/2}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carccothc(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carccsc(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal value of the complex inverse circular cosecant w = arccsc(z) = arcsin(1/z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carccsc(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carccsch(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal value of the complex inverse hyperbolic cosecant w = arccsch(z) = arcsinh(1/z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carccsch(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carcsec(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal value of the complex inverse circular secant w = arcsec(z) = arccos(1/z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carcsec(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carcsech(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal value of the complex inverse hyperbolic secant w = arcsech(z) = arccosh(1/z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carcsech(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carcsin(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal value of the complex inverse circular sine w = arcsin(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carcsin(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carcsinh(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal value of the complex inverse hyperbolic sine w = arcsinh(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carcsinh(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carctan(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal value of the complex inverse circular tangent w = arctan(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carctan(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_carctanh(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal value of the complex inverse hyperbolic tangent w = arctanh(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   carctanh(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_ccbrt(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex principal cube root w = cbrt(z) = z^(1/3)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ccbrt(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_ccn(const z_re, z_im, k: double; var w_re, w_im: double);  cdecl; export;
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ccn(z, k, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_ccos(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex circular cosine w = cos(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ccos(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_ccosh(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex hyperbolic cosine w = cosh(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ccosh(z, w);
   w_re := w.re; w_im := w.im;
end;


procedure damath_ccot(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex circular cotangent w = cot(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ccot(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_ccoth(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex hyperbolic cotangent w = coth(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ccoth(z, w);
   w_re := w.re; w_im := w.im;
end;


procedure damath_ccsc(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex circular cosecant w = csc(z) = 1/sin(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ccsc(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_ccsch(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex hyperbolic cosecant w = csch(z) = 1/sinh(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ccsch(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_cdilog(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal branch of the complex dilogarithm w = -integral(ln(1-t)/t, t=0..z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cdilog(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_cdn(const z_re, z_im, k: double; var w_re, w_im: double);  cdecl; export;
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cdn(z, k, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_ce1(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ce1(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cei(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cei(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_cellck(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return w = K'(k), the complementary complete elliptic integral of the first kind}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cellck(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_celle(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return w = E(k), the complete elliptic integral of the second kind}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   celle(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cellk(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return w = K(k), the complete elliptic integral of the first kind}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cellk(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cellke(const k_re, k_im: double; var kk_re, kk_im, ek_re, ek_im: double); cdecl; export;         
  {-Return the complete elliptic integrals kk = K(k), ek = E(k); kk=INF if k^2=1}
  var k, kk, ek: complex;
begin
   k.re := k_re; k.im := k_im;
   cellke(k, kk, ek);
   kk_re := kk.re; kk_im := kk.im;
   ek_re := ek.re; ek_im := ek.im;
end;




procedure damath_cerf(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cerf(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_cerfc(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cerfc(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_cexp(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex exponential function w = exp(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cexp(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cexp2(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return w = 2^z = exp(z*ln(2))}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cexp2(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cexp10(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return w = 10^z = exp(z*ln(10))}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cexp10(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cexpm1(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return w = exp(z)-1, accuracy improved for z near 0}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cexpm1(z, w);
   w_re := w.re; w_im := w.im;
end;





procedure damath_cgamma(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex Gamma function w = Gamma(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cgamma(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cLambertW(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cLambertW(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cLambertWk(k: integer; const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cLambertWk(k, z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_cli(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cli(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cln(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;   
  {-Return the complex natural logarithm w = ln(z); principal branch ln(|z|) + i*arg(z), accurate near |z|=1}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cln(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cln1p(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;    
  {-Return the principal branch of ln(1+z), accuracy improved for z near 0}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cln1p(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_clngamma(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return w = lnGamma(z), the principal branch of the log-Gamma function}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   clngamma(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_clog10(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the principal branch of the base 10 logarithm of z, w=ln(z)/ln(10)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   clog10(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_clogbase(const x_re, x_im, y_re, y_im: double; var z_re, z_im: double); cdecl; export;        
  {-Return the principal branch of the base b logarithm of z, w=ln(z)/ln(b)}
var x, y, z: complex;
begin
   x.re := x_re; x.im := x_im;
   y.re := y_re; y.im := y_im;
   clogbase(x, y, z);
   z_re := z.re; z_im := z.im;
end;




procedure damath_cnroot(const z_re, z_im: double; n: integer; var w_re, w_im: double); cdecl; export;         
  {-Return the complex principal n'th root w = z^(1/n)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cnroot(z, n, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cnroot1(const n: integer; var w_re, w_im: double); cdecl; export;         
  {-Return the principal nth root of unity z = exp(2*Pi*i/n)}
  var w: complex;
begin
   cnroot1(n, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cpow(const x_re, x_im, y_re, y_im: double; var z_re, z_im: double);  cdecl; export;        
  {-Return the principal value of the complex power w = z^a = exp(a*ln(z))}
var x, y, z: complex;
begin
   x.re := x_re; x.im := x_im;
   y.re := y_re; y.im := y_im;
   cpow(x, y, z);
   z_re := z.re; z_im := z.im;
end;



procedure damath_cpowx(const z_re, z_im: double; x: double; var w_re, w_im: double); cdecl; export;         
  {-Return the principal value w = z^x = |z|^x * exp(i*x*arg(z))}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cpowx(z, x, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_cpsi(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex digamma function w = psi(z), z <> 0,-1,-2...}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   cpsi(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_crgamma(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   crgamma(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_crstheta(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   crstheta(z, w);
   w_re := w.re; w_im := w.im;
end;




procedure damath_csec(const z_re, z_im: double; var w_re, w_im: double); cdecl; export; 
  {-Return the complex circular secant w = sec(z) = 1/cos(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csec(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csech(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex hyperbolic secant w = sech(z) = 1/cosh(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csech(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csin(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex circular sine w = sin(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csin(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csinh(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex hyperbolic sine w = sinh(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csinh(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csinpi(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csinpi(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csn(const z_re, z_im, k: double; var w_re, w_im: double);  cdecl; export;
var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csn(z, k, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_csurd(const z_re, z_im: double; n: integer; var w_re, w_im: double); cdecl; export;         
  {-Return the complex n'th root w = z^(1/n) with arg(w) closest to arg(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   csurd(z, n, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_ctan(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex circular tangent w = tan(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ctan(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_ctanh(const z_re, z_im: double; var w_re, w_im: double); cdecl; export;
  {-Return the complex hyperbolic tangent w = tanh(z)}
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   ctanh(z, w);
   w_re := w.re; w_im := w.im;
end;



procedure damath_czeta(const z_re, z_im: double; var w_re, w_im: double);  cdecl; export;
  var z, w: complex;
begin
   z.re := z_re; z.im := z_im;
   czeta(z, w);
   w_re := w.re; w_im := w.im;
end;


{******missing: cpoly******************************************************************}
{******missing: cpolyr******************************************************************}
{******not used: csgn******************************************************************}
{******not used: cset******************************************************************}






exports

damath_setpmExtended,
damath_setpmDouble,
damath_GetPrecisionMode,

mpi_IsPrime16,
mpi_Primes16Index,
mpi_IsPrime32,
mpi_is_primepower32,
mpi_lsumphi32,
mpi_primepi32,
mpi_is_spsp32,
mpi_Carmichael32,
mpi_core32,
mpi_dlog32,
mpi_dlog32_ex,
mpi_EulerPhi32,
mpi_is_Carmichael32,
mpi_is_fundamental32,
mpi_is_primroot32,
mpi_is_squarefree32,
mpi_Moebius32,
mpi_order32,
mpi_prime32,
mpi_PrimeFactor32,
mpi_primroot32,
mpi_quaddisc32,
mpi_rad32,
mpi_tau32,
mpi_FindFirstPrime32,
mpi_FindNextPrime32,
mpi_nextprime32,
mpi_prevprime32,
mpi_safeprime32,

damath_squadx,
damath_cubsolve,
damath_localmin,
damath_mbrent,
damath_zbrent,
damath_zeroin,
damath_quanc8,
damath_qags,
damath_qagi,
damath_qawc,
damath_intde,
damath_intdei,
damath_intdeo,

damath_sqrt,
damath_cbrt,
damath_ceil,
damath_ceild,
damath_floor,
damath_floord,
damath_fmod,
damath_hypot,
damath_hypot3,
damath_intpower,
damath_modf,
damath_nroot,
damath_remainder,
damath_sqrt1pm1,
damath_sqrt1pmx,

damath_copysignd,
damath_frexpd,
damath_ldexpd,
damath_predd,
damath_succd,
damath_ulpd,
damath_maxd,
damath_mind,
damath_ilogb,
damath_rint,
damath_scalbn,

damath_arccos,
damath_arccos1m,
damath_arccosd,
damath_arccosh,
damath_arccosh1p,
damath_arccot,
damath_arccotc,
damath_arccotcd,
damath_arccotd,
damath_arccoth,
damath_arccsc,
damath_arccsch,
damath_arcgd,
damath_archav,
damath_arcsec,
damath_arcsech,
damath_arcsin,
damath_arcsind,
damath_arcsinh,
damath_arctan2,
damath_arctan,
damath_arctand,
damath_arctanh,
damath_compound,
damath_comprel,
damath_cos,
damath_cosd,
damath_cosh,
damath_coshm1,
damath_cosPi,
damath_cot,
damath_cotd,
damath_coth,
damath_covers,
damath_csc,
damath_csch,
damath_exp,
damath_exp10,
damath_exp10m1,
damath_exp2,
damath_exp2m1,
damath_exp3,
damath_exp5,
damath_exp7,
damath_expm1,
damath_expmx2h,
damath_exprel,
damath_expx2,
damath_gd,
damath_hav,
damath_ln,
damath_ln1mexp,
damath_ln1p,
damath_ln1pexp,
damath_ln1pmx,
damath_lncosh,
damath_lnsinh,
damath_log10,
damath_log10p1,
damath_log2,
damath_log2p1,
damath_logaddexp,
damath_logbase,
damath_logistic,
damath_logit,
damath_logsubexp,
damath_pow1p,
damath_pow1pf,
damath_pow1pm1,
damath_power,
damath_powm1,
damath_powpi,
damath_powpi2k,
damath_sec,
damath_sech,
damath_sin,
damath_sincos,
damath_sincosd,
damath_sincosPi,
damath_sinhcosh,
damath_sinc,
damath_sincPi,
damath_sind,
damath_sinh,
damath_sinhc,
damath_sinhmx,
damath_sinPi,
damath_tan,
damath_tand,
damath_tanh,
damath_tanPi,
damath_vers,
damath_versint,


damath_bessel_j0,
damath_bessel_j1,
damath_bessel_jn,
damath_bessel_y0,
damath_bessel_y1,
damath_bessel_yn,

damath_bessel_i0,
damath_bessel_i0e,
damath_bessel_i1,
damath_bessel_i1e,
damath_bessel_in,
damath_bessel_k0,
damath_bessel_k0e,
damath_bessel_k1,
damath_bessel_k1e,
damath_bessel_kn,

damath_bessel_jv,
damath_bessel_yv,
damath_bessel_lambda,

damath_bessel_iv,
damath_bessel_ive,
damath_bessel_kv,
damath_bessel_kve,

damath_bessel_i0_int,
damath_bessel_j0_int,
damath_bessel_k0_int,
damath_bessel_y0_int,

damath_sph_bessel_jn,
damath_sph_bessel_yn,
damath_sph_bessel_in,
damath_sph_bessel_ine,
damath_sph_bessel_kn,
damath_sph_bessel_kne,

damath_airy_ai,
damath_airy_aip,
damath_airy_ais,
damath_airy_bi,
damath_airy_bip,
damath_airy_bis,
damath_airy_gi,
damath_airy_hi,

damath_kelvin_bei,
damath_kelvin_beip,
damath_kelvin_ber,
damath_kelvin_berp,
damath_kelvin_kei,
damath_kelvin_keip,
damath_kelvin_ker,
damath_kelvin_kerp,
damath_kelvin_der,
damath_kelvin_kerkei,
damath_kelvin_berbei,

damath_struve_h0,
damath_struve_h1,
damath_struve_h,
damath_struve_l0,
damath_struve_l1,
damath_struve_l,

damath_CoulombCL,
damath_CoulombSL,
damath_CoulombF,
damath_CoulombFFp,
damath_CoulombGGp,
damath_SynchF,
damath_SynchG,

damath_comp_ellint_1,
damath_comp_ellint_2,
damath_comp_ellint_3,
damath_comp_ellint_b,
damath_comp_ellint_d,
damath_ellint_1,
damath_ellint_2,
damath_ellint_3,
damath_ellint_d,
damath_ellint_b,
damath_heuman_lambda,
damath_jacobi_zeta,

damath_ell_rc,
damath_ell_rf,
damath_ell_rd,
damath_ell_rg,
damath_ell_rj,

damath_cel1,
damath_cel2,
damath_cel,
damath_el1,
damath_el2,
damath_el3,

damath_EllipticF,
damath_EllipticK,
damath_EllipticKim,
damath_EllipticCK,
damath_EllipticE,
damath_EllipticEC,
damath_EllipticECim,
damath_EllipticCE,
damath_EllipticPi,
damath_EllipticPiC,
damath_EllipticCPi,
damath_EllipticPiCim,

damath_M_EllipticK,
damath_M_EllipticEC,
damath_M_EllipticPiC,
damath_M_EllipticF,
damath_M_EllipticE,
damath_M_EllipticPi,

damath_EllipticModulus,
damath_EllipticNome,
damath_jacobi_am,

damath_jacobi_arccn,
damath_jacobi_arccd,
damath_jacobi_arccs,
damath_jacobi_arcdc,
damath_jacobi_arcdn,
damath_jacobi_arcds,
damath_jacobi_arcnc,
damath_jacobi_arcnd,
damath_jacobi_arcns,
damath_jacobi_arcsc,
damath_jacobi_arcsd,
damath_jacobi_arcsn,

damath_jacobi_sn,
damath_jacobi_cn,
damath_jacobi_dn,
damath_jacobi_nc,
damath_jacobi_sc,
damath_jacobi_dc,
damath_jacobi_nd,
damath_jacobi_sd,
damath_jacobi_cd,
damath_jacobi_ns,
damath_jacobi_cs,
damath_jacobi_ds,
damath_sncndn,

damath_jacobi_theta,
damath_theta1p,
damath_theta2,
damath_theta3,
damath_theta4,

damath_ntheta_c,
damath_ntheta_d,
damath_ntheta_n,
damath_ntheta_s,
damath_arccl,
damath_arcsl,
damath_sincos_lemn,
damath_sin_lemn,
damath_cos_lemn,

damath_wpl,
damath_wpe,
damath_wpe_der,
damath_wpe_im,
damath_wpg,
damath_wpg_der,
damath_wpg_im,
damath_wpe_inv,
damath_wpg_inv,
damath_detai,
damath_emlambda,
damath_KleinJ,


damath_dawson,
damath_dawson2,
damath_erf,
damath_erfg,
damath_erfc,
damath_erfce,
damath_inerfc,
damath_erfi,
damath_erfh,
damath_erf2,
damath_erf_inv,
damath_erfc_inv,
damath_erfce_inv,
damath_erfi_inv,
damath_erf_p,
damath_erf_q,
damath_erf_z,
damath_expint3,
damath_Fresnel,
damath_FresnelC,
damath_FresnelS,
damath_FresnelFG,
damath_FresnelF,
damath_FresnelG,
damath_gsi,
damath_MarcumQ,
damath_OwenT,


damath_chi,
damath_ci,
damath_cin,
damath_cinh,
damath_e1,
damath_e1s,
damath_ei,
damath_eis,
damath_eisx2,
damath_ei_inv,
damath_ein,
damath_en,
damath_gei,
damath_eibeta,
damath_li,
damath_li_inv,
damath_shi,
damath_si,
damath_ssi,


damath_gamma,
damath_gamma1pm1,
damath_inv_gamma, 
damath_gammastar,
damath_lngamma,
damath_lngamma_inv,
damath_lngamma1p,
damath_rgamma,
damath_signgamma,
damath_lngammas,

damath_incgamma,
damath_igammap,
damath_igammaq,
damath_igamma,
damath_igammal,
damath_igammat,
damath_incgamma_inv,
damath_igamma_inv,
damath_igammap_inv,
damath_igammaq_inv,
damath_igammap_der, 

damath_beta,
damath_lnbeta,
damath_ibeta,
damath_beta3,
damath_ibeta_inv,

damath_fac,
damath_dfac,
damath_lnfac,
damath_binomial,
damath_lnbinomial, 
damath_pochhammer,
damath_poch1,

damath_gamma_delta_ratio,
damath_gamma_ratio,

damath_psi,
damath_psistar, 
damath_trigamma,
damath_tetragamma,
damath_pentagamma,
damath_polygamma,
damath_psi_inv,
damath_BatemanG,
damath_lnBarnesG, 


damath_zeta,
damath_zetaint,
damath_zeta1p,
damath_zetam1,
damath_primezeta,

damath_eta,
damath_etaint,
damath_etam1,
damath_DirichletBeta,
damath_DirichletLambda,
damath_zetah,

damath_bose_einstein, 
damath_fermi_dirac_r, 
damath_fermi_dirac,
damath_fermi_dirac_m05,
damath_fermi_dirac_p05,
damath_fermi_dirac_p15,
damath_fermi_dirac_p25,

damath_LegendreChi,
damath_LerchPhi,
damath_polylog,
damath_polylogr,
damath_dilog,
damath_trilog,

damath_cl2,
damath_ti2,
damath_ti, 
damath_lobachevsky_c,
damath_lobachevsky_s,

damath_harmonic,
damath_harmonic2,



damath_chebyshev_t,
damath_chebyshev_u,
damath_chebyshev_v,
damath_chebyshev_w,
damath_chebyshev_f1, 
damath_gegenbauer_c,
damath_hermite_h,
damath_hermite_he, 
damath_jacobi_p,
damath_laguerre,
damath_laguerre_l,
damath_laguerre_ass,
damath_legendre_p,
damath_legendre_q,
damath_legendre_plm,
damath_legendre_qlm,
damath_spherical_harmonic,
damath_toroidal_qlm,
damath_toroidal_plm,
damath_besselpoly, 
damath_zernike_r,

damath_hyperg_2F1,
damath_hyperg_2F1r,
damath_hyperg_1F1,
damath_hyperg_1F1r,
damath_hyperg_u,
damath_hyperg_0F1,
damath_hyperg_0F1r,
damath_hyperg_2F0, 
damath_WhittakerM,
damath_WhittakerW,
damath_CylinderD,
damath_CylinderU,
damath_CylinderV,
damath_HermiteH,


damath_beta_pdf,
damath_beta_cdf,
damath_beta_inv,

damath_binomial_cdf,
damath_binomial_pmf,

damath_cauchy_pdf,
damath_cauchy_cdf,
damath_cauchy_inv,

damath_chi_pdf, 
damath_chi_cdf, 
damath_chi_inv, 

damath_chi2_pdf,
damath_chi2_cdf,
damath_chi2_inv,

damath_exp_pdf,
damath_exp_cdf,
damath_exp_inv,

damath_evt1_pdf,
damath_evt1_cdf,
damath_evt1_inv,

damath_f_pdf,
damath_f_cdf,
damath_f_inv,

damath_gamma_pdf,
damath_gamma_cdf,
damath_gamma_inv,

damath_hypergeo_pmf,
damath_hypergeo_cdf,

damath_invgamma_pdf,
damath_invgamma_cdf,
damath_invgamma_inv,

damath_kumaraswamy_pdf,
damath_kumaraswamy_cdf,
damath_kumaraswamy_inv,

damath_kolmogorov_cdf, 
damath_kolmogorov_inv, 

damath_laplace_cdf,
damath_laplace_inv,
damath_laplace_pdf,

damath_levy_pdf,
damath_levy_cdf,
damath_levy_inv,

damath_logseries_pmf,
damath_logseries_cdf,

damath_logistic_pdf,
damath_logistic_cdf,
damath_logistic_inv,

damath_lognormal_pdf,
damath_lognormal_cdf,
damath_lognormal_inv,

damath_maxwell_pdf,
damath_maxwell_cdf,
damath_maxwell_inv,

damath_moyal_pdf,
damath_moyal_cdf,
damath_moyal_inv,

damath_nakagami_pdf, 
damath_nakagami_cdf, 
damath_nakagami_inv, 

damath_negbinom_cdf,
damath_negbinom_pmf,

damath_normal_pdf,
damath_normal_cdf,
damath_normal_inv,

damath_pareto_pdf,
damath_pareto_cdf,
damath_pareto_inv,

damath_poisson_cdf,
damath_poisson_pmf,

damath_rayleigh_pdf,
damath_rayleigh_cdf,
damath_rayleigh_inv,

damath_normstd_pdf,
damath_normstd_cdf,
damath_normstd_inv,

damath_t_pdf,
damath_t_cdf,
damath_t_inv,

damath_triangular_pdf,
damath_triangular_cdf,
damath_triangular_inv,

damath_uniform_pdf,
damath_uniform_cdf,
damath_uniform_inv,

damath_wald_pdf,
damath_wald_cdf,
damath_wald_inv,

damath_weibull_pdf,
damath_weibull_cdf,
damath_weibull_inv,

damath_zipf_pmf,
damath_zipf_cdf,




damath_agm,
damath_bernoulli,
damath_bernpoly,
damath_bring, 
damath_catalan,
damath_debye,
damath_einstein, 
damath_euler,
damath_eulerpoly, 
damath_expreln, 
damath_fibpoly,
damath_fibfun, 
damath_cosint,
damath_sinint,
damath_LambertW,
damath_LambertW1,
damath_LangevinL, 
damath_LangevinL_inv, 
damath_lucpoly,
damath_euler_q, 
damath_RiemannR,
damath_RiemannR_inv, 
damath_rrcf, 
damath_kepler,
damath_transport, 
damath_expn, 
damath_omega, 




damath_cabs,
damath_cadd,
damath_carg,
damath_ccis,
damath_cconj,
damath_cdiv,
damath_cinv,
damath_cmul,
damath_cneg,
damath_cpolar,
damath_cpowi,
damath_rdivc,
damath_csqr,
damath_csqrt,
damath_csqrt1mz2,
damath_csub,


damath_cagm,
damath_cagm1,

damath_carccos,
damath_carccosh,
damath_carccot,
damath_carccotc,
damath_carccoth,
damath_carccothc,
damath_carccsc,
damath_carccsch,
damath_carcsec,
damath_carcsech,
damath_carcsin,
damath_carcsinh,
damath_carctan,
damath_carctanh,

damath_ccbrt,
damath_ccn,
damath_ccos,
damath_ccosh,
damath_ccot,
damath_ccoth,
damath_ccsc,
damath_ccsch,

damath_cdilog,
damath_cdn,
damath_ce1,
damath_cei,
damath_cellck,
damath_celle,
damath_cellk,
damath_cellke,

damath_cerf,
damath_cerfc,
damath_cexp,
damath_cexp2,
damath_cexp10,
damath_cexpm1,

damath_cgamma,
damath_cLambertW,
damath_cLambertWk,
damath_cli,
damath_cln,
damath_cln1p,
damath_clngamma,
damath_clog10,
damath_clogbase,

damath_cnroot,
damath_cnroot1,
damath_cpow,
damath_cpowx,

damath_cpsi,
damath_crgamma,
damath_crstheta,

damath_csec,
damath_csech,
damath_csin,
damath_csinh,
damath_csinpi,
damath_csn,
damath_csurd,
damath_ctan,
damath_ctanh,
damath_czeta;





begin
end.
