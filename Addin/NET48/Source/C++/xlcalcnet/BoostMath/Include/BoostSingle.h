



typedef float(*SingleFuncPtr) (float);



//*********************** Boost Rootfinding, float precision **********************************


void LibSingle_BracketRoot(float* res1, float* res2, int* iter, SingleFuncPtr f1, float guess, float factor, bool is_rising, int get_digits, unsigned int maxit);

void LibSingle_NewtonRaphson(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, float guess, float xmin, float xmax, int get_digits, unsigned int maxit);

void LibSingle_Halley(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3, float guess, float xmin, float xmax, int get_digits, unsigned int maxit);

void LibSingle_Schroder(float* res,  int* iter, SingleFuncPtr f1, SingleFuncPtr f2, SingleFuncPtr f3, float guess, float xmin, float xmax, int get_digits, unsigned int maxit);

void LibSingle_Brent_Minimum(float* res, float* resFx, int* iter, SingleFuncPtr f1, float bracket_min, float bracket_max, int bits, unsigned int maxit);



//*********************** Boost Numerical Integration, float precision **********************************




void LibSingle_Trapezoidal(float* res1, float* res2, float* res3, SingleFuncPtr f1, float a, float b);

void LibSingle_GaussLegendre(float* res1, float* res3, SingleFuncPtr f1, float a, float b);

void LibSingle_GaussKronrod(float* res1, float* res2, float* res3, SingleFuncPtr f1, float a, float b);

void LibSingle_TanhSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1, float* a, float* b);

void LibSingle_SinhSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1);

void LibSingle_ExpSinh(float* res1, float* res2, float* res3, int* levels_, SingleFuncPtr f1);

void LibSingle_Ooura_Cos(float* res1, float* res2, SingleFuncPtr f1);

void LibSingle_Ooura_Sin(float* res1, float* res2, SingleFuncPtr f1);



