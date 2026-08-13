



typedef double(*DoubleFuncPtr) (double);



//*********************** Boost Rootfinding, double precision **********************************


void LibDouble_BracketRoot(double* res1, double* res2, int* iter, DoubleFuncPtr f1, double guess, double factor, bool is_rising, int get_digits, unsigned int maxit);

void LibDouble_NewtonRaphson(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, double guess, double xmin, double xmax, int get_digits, unsigned int maxit);

void LibDouble_Halley(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit);

void LibDouble_Schroder(double* res,  int* iter, DoubleFuncPtr f1, DoubleFuncPtr f2, DoubleFuncPtr f3, double guess, double xmin, double xmax, int get_digits, unsigned int maxit);

void LibDouble_Brent_Minimum(double* res, double* resFx, int* iter, DoubleFuncPtr f1, double bracket_min, double bracket_max, int bits, unsigned int maxit);



//*********************** Boost Numerical Integration, double precision **********************************




void LibDouble_Trapezoidal(double* res1, double* res2, double* res3, DoubleFuncPtr f1, double a, double b);

void LibDouble_GaussLegendre(double* res1, double* res3, DoubleFuncPtr f1, double a, double b);

void LibDouble_GaussKronrod(double* res1, double* res2, double* res3, DoubleFuncPtr f1, double a, double b);

void LibDouble_TanhSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1, double a, double b);

void LibDouble_SinhSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1);

void LibDouble_ExpSinh(double* res1, double* res2, double* res3, int* levels_, DoubleFuncPtr f1);

void LibDouble_Ooura_Cos(double* res1, double* res2, DoubleFuncPtr f1);

void LibDouble_Ooura_Sin(double* res1, double* res2, DoubleFuncPtr f1);



void LibDouble_Ooura_Cos2(double* res1, double* res2, DoubleFuncPtr f1, double omega);

void LibDouble_Ooura_Sin2(double* res1, double* res2, DoubleFuncPtr f1, double omega);


