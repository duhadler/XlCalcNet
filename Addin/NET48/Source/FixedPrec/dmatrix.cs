using System;
using System.Runtime.InteropServices;
using System.Numerics;


namespace FixedPrecNet
{


    internal static class dlib
    {


        public static int GetModuleIndex(Type MyType)
        {
            // Dim Result As Int32 = mp_real
            int Result = 0; // = mp_cplx
            string s = MyType.Name;
            // Console.WriteLine("s: {0}", s)
            if (s.EndsWith("Double"))
                Result = constants.mp_real;
            if (s.EndsWith("Complex"))
                Result = constants.mp_cplx;

            return Result;
        }



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_Eigen_FReal_Init_Func(int mpCat, int mpType);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Clear(int mpCat, int mpType, IntPtr AnyPtr);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_Eigen_FReal_GetInfo(int mpCat, int mpType, int what, IntPtr MatrixPtr_source);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Get_Block(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Put_Block(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_SetSpecialValue(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int m, int n);


        internal static void Call_Eigen_SetSpecialValue(int mpCat, int mpType, dynamic result, int what, int m, int n)
        {
            Lib_Eigen_FReal_SetSpecialValue(mpCat, mpType, (IntPtr)result.mpPtr, what, m, n);
        }




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_SetSpecialValue2(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Compare", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint Lib_Eigen_FReal_Compare(int mpCat, int mpType, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_BasicArithmetic(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_CplxScalarArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_CplxScalarArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, ref Double Y_re, ref Double Y_im);

        //internal static extern void Lib_Eigen_FReal_Real_CplxScalarArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr Y_re, IntPtr Y_im);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Stats", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Stats(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int PartialMode, IntPtr MatrixPtr_source);


        // !!! Needs to be modified to remove ByRef !!! Switch from Int32 to Fmpz
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Stats2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Stats2(int mpCat, int mpType, IntPtr MatrixPtr_result, ref int IndexX, ref int IndexY, int what, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Map_GetItemValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Map_GetItemValue(int mpCat, int mpType, IntPtr res_mpPtr, IntPtr mpPtr, string str);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_MultipleResults", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_MultipleResults(int mpCat, int mpType, IntPtr ResMap, int what, string str, IntPtr MatA, IntPtr MatB);

        internal static void Call_Eigen_MultipleResults(int mpCat, int mpType, dynamic ResMap, int what, string str, dynamic MatA, dynamic MatB)
        {
            Lib_Eigen_FReal_MultipleResults(mpCat, mpType, (IntPtr)ResMap.mpPtr, what, str, (IntPtr)MatA.mpPtr, (IntPtr)MatB.mpPtr);
        }




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Sort", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Sort(int numType, IntPtr MatrixPtr_result_val, int SortOrder, int SortCriterion);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_SortRowsByColumn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_SortRowsByColumn(int numType, IntPtr MatrixPtr_result_val, int ColumnToSortBy, int SortOrder, int SortCriterion);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Select_Rows", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Select_Rows(int numType, IntPtr MatrixPtr_result_val, IntPtr MatrixPtr_source);



        #region MINPACK


        public static void testHybrj_ext(cbProc2Ptr F1, cbProc2Ptr F2, DoubleMat xMat, DoubleMat fvecMat, DoubleMat fjacMat, DoubleMat matInput)
        {
            Lib_Eigen_FReal_Real_testHybrj_ext(F1, F2, xMat.mpPtr, fvecMat.mpPtr, fjacMat.mpPtr, matInput.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_testHybrj_ext", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_testHybrj_ext(cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matFvecPtr, IntPtr matFjacPtr, IntPtr matInput);



        public static void testLmder_ext(cbProc2Ptr F1, cbProc2Ptr F2, DoubleMat xMat, DoubleMat fvecMat, DoubleMat fjacMat, DoubleMat matInput)
        {
            Lib_Eigen_FReal_Real_testLmder_ext(F1, F2, xMat.mpPtr, fvecMat.mpPtr, fjacMat.mpPtr, matInput.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_testLmder_ext", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_testLmder_ext(cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matFvecPtr, IntPtr matFjacPtr, IntPtr matInput);


        #endregion








    }




    public class DoubleMatBase<MyType, MatType, RealMatType, RetMatType, RetRealMatType, RetScalarType, RetMapType, RetCMapType>
            where RetMatType : new()
            where RetRealMatType : new()
            where RetScalarType : new()
            where RetMapType : new()
            where RetCMapType : new()
    {


        #region Init

        public IntPtr mpPtr = IntPtr.Zero;


        private IntPtr GetPtr(dynamic x)
        {
            return (IntPtr)x.mpPtr;
        }


        public void Init()
        {
            xcn.Init();
            mpPtr = dlib.Lib_Eigen_FReal_Init_Func(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)));
        }


        public DoubleMatBase()
        {
            // Console.WriteLine("New: , MyMatType: {0} ", GetType(MyType))
        }

        #endregion



        #region Get Info

        public int rows
        {
            get
            {
                return dlib.Lib_Eigen_FReal_GetInfo(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_rows, mpPtr);
            }
        }


        public int cols
        {
            get
            {
                return dlib.Lib_Eigen_FReal_GetInfo(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return dlib.Lib_Eigen_FReal_GetInfo(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_size, mpPtr);
            }
        }

        #endregion





        #region Get and Set Blocks, Rows, Cols, Triangular ...

        public RetMatType get_Block(int i, int j, int p, int q)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_Get_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_Block(int i, int j, int p, int q, RetMatType value)
        {
            dlib.Lib_Eigen_FReal_Put_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_block, i, j, p, q, GetPtr(value));
        }



        public RetMatType get_Row(int i)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_Get_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_Row(int i, RetMatType value)
        {
            dlib.Lib_Eigen_FReal_Put_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, GetPtr(value));
        }



        public RetMatType get_Col(int j)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_Get_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_Col(int j, RetMatType value)
        {
            dlib.Lib_Eigen_FReal_Put_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, GetPtr(value));
        }




        public RetMatType get_Diagonal(int q = 0)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_Get_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_Diagonal(int q, RetMatType value)
        {
            dlib.Lib_Eigen_FReal_Put_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, GetPtr(value));
        }




        public RetMatType get_TriangularView(int View = 1)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_Get_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_TriangularView(int View, RetMatType value)
        {
            dlib.Lib_Eigen_FReal_Put_Block(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, GetPtr(value));
        }



        #endregion



        #region SetSpecialValue




        public void Resize(int n, int m)
        {
            dlib.Lib_Eigen_FReal_SetSpecialValue(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_Resize, n, m);
        }


        public void ConservativeResize(int n, int m)
        {
            dlib.Lib_Eigen_FReal_SetSpecialValue(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_conservativeResize, n, m);
        }




        #endregion



        #region SetSpecialValue2


        public void ResizeLike(RetMatType m1)
        {
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_ResizeLike, 0, 0, 0, GetPtr(m1));
        }


        public RetMatType AsDiagonal()
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Adjoint()
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Conjugate()
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Transpose()
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public RetMatType ReverseFull()
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public RetMatType ReverseRowwise()
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public RetMatType ReverseColwise()
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public RetMatType ReplicateFull(int Vertical, int Horizontal)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public RetMatType ReplicateRowwise(int Vertical)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public RetMatType ReplicateColwise(int Horizontal)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_SetSpecialValue2(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
            return m1;
        }

        #endregion



        #region Arithmetic Comparisons (Compare)

        public uint GTcount(RetMatType Y)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_GT, mpPtr, GetPtr(Y));
        }


        public uint LTcount(RetMatType Y)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_LT, mpPtr, GetPtr(Y));
        }


        public uint LEcount(RetMatType Y)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_LE, mpPtr, GetPtr(Y));
        }


        public uint GEcount(RetMatType Y)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_GE, mpPtr, GetPtr(Y));
        }


        public uint EQcount(RetMatType Y)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_EQ, mpPtr, GetPtr(Y));
        }


        public uint NEcount(RetMatType Y)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), constants.mp_const_NE, mpPtr, GetPtr(Y));
        }


        #endregion



        #region Arithmetic Operators (BasicArithmetic)



        public RetMatType ConcatHorizontal(RetMatType x)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_concat_horizontal, mpPtr, GetPtr(x));
            return m1;
        }



        public RetMatType ConcatVertical(RetMatType x)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_concat_vertical, mpPtr, GetPtr(x));
            return m1;
        }




        public RetMatType CwiseProduct(RetMatType x)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_cwiseProduct, GetPtr(x), mpPtr);
            return m1;
        }




        public RetMatType DotProduct(RetMatType x)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_DotProduct, GetPtr(x), mpPtr);
            return m1;
        }




        public RetMatType CwiseQuotient(RetMatType x)
        {
            var m1 = new RetMatType();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_cwiseQuotient, GetPtr(x), mpPtr);
            return m1;
        }





        #endregion



        #region Multiple Results

        public RetMapType LDLT(string results, MatType B)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_ldlt, results, this, B);
            return res_map;
        }


        public RetMapType PartialPivLU(string results, MatType B)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_partialPivLu, results, this, B);
            return res_map;
        }


        public RetMapType FullPivLU(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_fullPivLu, results, this, b);
            return res_map;
        }


        public RetMapType LLT(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_llt, results, this, b);
            return res_map;
        }


        public RetMapType HouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_householderQr, results, this, b);
            return res_map;
        }


        public RetMapType ColPivHouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_colPivHouseholderQr, results, this, b);
            return res_map;
        }


        public RetMapType FullPivHouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_fullPivHouseholderQr, results, this, b);
            return res_map;
        }


        public RetMapType COD(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_COD, results, this, b);
            return res_map;
        }


        public RetMapType JacobiSVD(string results)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvd, results, this, this);
            return res_map;
        }


        public RetMapType JacobiSvdThin(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvdThin, results, this, b);
            return res_map;
        }


        public RetMapType JacobiSvdFull(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvdFull, results, this, b);
            return res_map;
        }


        public RetMapType Hessenberg(string results)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_hessenberg, results, this, this);
            return res_map;
        }


        public RetMapType Schur(string results)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_schur, results, this, this);
            return res_map;
        }


        public RetMapType Tridiag(string results)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_tridiag, results, this, this);
            return res_map;
        }


        public RetMapType SelfAdjointEigenValuesFromTridiag(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenValuesFromTridiag, results, this, b);
            return res_map;
        }


        public RetMapType SelfAdjointEigenSystemFromTridiag(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenSystemFromTridiag, results, this, b);
            return res_map;
        }


        public RetMapType SelfAdjointEigenValues(string results)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenValues, results, this, this);
            return res_map;
        }


        public RetMapType SelfAdjointEigenSystem(string results)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenSystem, results, this, this);
            return res_map;
        }


        public RetMapType GeneralizedSelfAdjointEigenValues(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_GeneralizedSelfAdjointEigenValues, results, this, b);
            return res_map;
        }


        public RetMapType GeneralizedSelfAdjointEigenSolver(string results, MatType b)
        {
            var res_map = new RetMapType();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_GeneralizedSelfAdjointEigenSolver, results, this, b);
            return res_map;
        }





        #endregion


    }



    public class DoubleMatMap
    {

        public IntPtr mpPtr = IntPtr.Zero;

        private void Init()
        {
            xcn.Init();
            mpPtr = dlib.Lib_Eigen_FReal_Init_Func(constants.mp_map, constants.mp_real);
        }


        public DoubleMatMap()
        {
            Init();
        }


        ~DoubleMatMap()
        {
            dlib.Lib_Eigen_FReal_Clear(constants.mp_map, constants.mp_real, mpPtr);
        }


        public DoubleMat this[string s]
        {
            get
            {
                var res = new DoubleMat();
                dlib.Lib_Eigen_FReal_Map_GetItemValue(constants.mp_eigen, constants.mp_real, res.mpPtr, mpPtr, s);
                return res;
            }
        }

    }






    public class DoubleMat : DoubleMatBase<Double, DoubleMat, DoubleMat, DoubleMat, DoubleMat, Double, DoubleMatMap, ComplexMatMap>
    {


        #region Init

        public DoubleMat()
        {
            Init();
        }

        private IntPtr GetPtr(dynamic x)
        {
            return (IntPtr)x.mpPtr;
        }

        ~DoubleMat()
        {
            dlib.Lib_Eigen_FReal_Clear(constants.mp_eigen, constants.mp_real, mpPtr);
        }


        public DoubleSpMat ToSparse()
        {
            var res = new DoubleSpMat();
            DLibSparse.EigenSparseLib_FReal_SparseFromDense(res.mpPtr, mpPtr);
            return res;
        }






        public override string ToString()
        {
            string res = "";
            var d1 = new Double();
            string s1, Lmt;
            for (int i = 0, loopTo = rows - 1; i <= loopTo; i++)
            {
                for (int j = 0, loopTo1 = cols - 1; j <= loopTo1; j++)
                {
                    d1 = this[i, j];
                    s1 = d1.ToString();
                    //if (Conversions.ToString(s1[0]) != "-")
                    //    s1 = " " + s1;
                    if (j == cols - 1)
                        Lmt = "; ";
                    else
                        Lmt = ", ";
                    res = res + s1 + Lmt;
                }
                res = res + Environment.NewLine;
            }
            return res;
        }


        public void Print(string Title, int digits = 6)
        {
            Console.WriteLine(Title);
            Console.WriteLine(this);
        }

        #endregion



        #region Get and Set Coefficients


        public Double this[int row_i, int col_j = 0]
        {
            get
            {
                var result = new Double();
                Eigen_FReal_GetCoeff(ref result, row_i, col_j, mpPtr);
                return result;
            }

            set
            {
                Eigen_FReal_SetCoeff(mpPtr, ref value, row_i, col_j);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_GetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_FReal_GetCoeff(ref Double result, int row, int col, IntPtr MatrixPtr_source);
        
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_SetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_FReal_SetCoeff(IntPtr MatrixPtr_result, ref Double in1, int row, int col);

        //[DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_GetCoeff", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Eigen_FReal_GetCoeff(IntPtr result, int row, int col, IntPtr MatrixPtr_source);
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_SetCoeff", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Eigen_FReal_SetCoeff(IntPtr MatrixPtr_result, IntPtr in1, int row, int col);


        #endregion



        #region Arithmetic Comparisons (Compare)



        public static bool operator ==(DoubleMat m1, DoubleMat m2)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, constants.mp_real, constants.mp_const_EQ, m1.mpPtr, m2.mpPtr) == m1.size;
        }


        public static bool operator !=(DoubleMat m1, DoubleMat m2)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, constants.mp_real, constants.mp_const_NE, m1.mpPtr, m2.mpPtr) == m1.size;
        }




        #endregion



        #region Arithmetic Operators (BasicArithmetic)


        public static DoubleMat operator +(DoubleMat m1)
        {
            var one = dreal.t(1);
            return m1 * one;
        }


        public static DoubleMat operator -(DoubleMat m1)
        {
            var MinusOne = dreal.t(-1);
            return MinusOne * m1;
        }




        public static DoubleMat operator +(DoubleMat M1, DoubleMat M2)
        {
            var Res = new DoubleMat();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }




        public static DoubleMat operator +(DoubleMat M1, Double m2)
        {
            var Res = new DoubleMat();
            var t = dreal.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static DoubleMat operator +(Double m2, DoubleMat M1)
        {
            var Res = new DoubleMat();
            var t = dreal.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static ComplexMat operator +(DoubleMat M1, Complex m2)
        {
            var Res = new ComplexMat();
            double x = m2.Real;
            double y = m2.Imaginary;
            dlib.Lib_Eigen_FReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }

        public static ComplexMat operator +(DoubleMat m1, ComplexMat m2)
        {
            var m3 = new ComplexMat();
            var T1 = dcplx.mat_t(m1);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_plus, T1.mpPtr, m2.mpPtr);
            return m3;
        }




        public static ComplexMat operator +(dynamic m2, DoubleMat M1) // Complex m2
        {
            Complex m2_ = dcplx.t(m2);
            double x = m2_.Real;
            double y = m2_.Imaginary;
            var Res = new ComplexMat();
            dlib.Lib_Eigen_FReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }



        public static DoubleMat operator -(DoubleMat m1, DoubleMat m2)
        {
            var m3 = new DoubleMat();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }



        public static DoubleMat operator -(DoubleMat M1, Double m2)
        {
            var Res = new DoubleMat();
            var t = dreal.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static DoubleMat operator -(Double m2, DoubleMat M1)
        {
            var Res = new DoubleMat();
            var t = dreal.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, t.mpPtr);
            return -Res;
        }




        public static ComplexMat operator -(DoubleMat M1, Complex m2)
        {
            var Res = new ComplexMat();
            double x = m2.Real;
            double y = m2.Imaginary;
            dlib.Lib_Eigen_FReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }


        public static ComplexMat operator -(DoubleMat m1, ComplexMat m2)
        {
            var m3 = new ComplexMat();
            var T2 = dcplx.mat_t(m1);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, T2.mpPtr, m2.mpPtr);
            return m3;
        }


        public static ComplexMat operator -(dynamic m2, DoubleMat M1) // Complex m2
        {
            Complex m2_ = dcplx.t(m2);
            double x = m2_.Real;
            double y = m2_.Imaginary;
            var Res = new ComplexMat();
            dlib.Lib_Eigen_FReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, ref x, ref y);
            return -Res;
        }



        public static DoubleMat operator *(DoubleMat m1, DoubleMat m2)
        {
            var m3 = new DoubleMat();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static DoubleMat operator *(DoubleMat M1, Double m2)
        {
            var Res = new DoubleMat();
            var t = dreal.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }




        public static DoubleMat operator *(Double m2, DoubleMat M1)
        {
            var Res = new DoubleMat();
            var t = dreal.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }





        public static ComplexMat operator *(DoubleMat M1, Complex m2)
        {
            var Res = new ComplexMat();
            double x = m2.Real;
            double y = m2.Imaginary;
            dlib.Lib_Eigen_FReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }


        public static ComplexMat operator *(DoubleMat m1, ComplexMat m2)
        {
            var m3 = new ComplexMat();
            var T1 = dcplx.mat_t(m1);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, T1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static ComplexMat operator *(dynamic m2, DoubleMat M1)
        {
            Complex m2_ = dcplx.t(m2);
            double x = m2_.Real;
            double y = m2_.Imaginary;
            var Res = new ComplexMat();
            dlib.Lib_Eigen_FReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }




        public static DoubleMat operator /(DoubleMat m1, DoubleMat m2)
        {
            var m3 = new DoubleMat();
            var m4 = m2.Inverse();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }


        public static DoubleMat operator /(DoubleMat M1, Double m2)
        {
            var Res = new DoubleMat();
            var t = dreal.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        public static ComplexMat operator /(DoubleMat M1, Complex m2)
        {
            var Res = new ComplexMat();
            double x = m2.Real;
            double y = m2.Imaginary;
            dlib.Lib_Eigen_FReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }


        public static ComplexMat operator /(DoubleMat m1, ComplexMat m2)
        {
            var m3 = new ComplexMat();
            var m4 = new ComplexMat();
            m4 = m2.Inverse();
            var T1 = dcplx.mat_t(m1);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, T1.mpPtr, m4.mpPtr);
            return m3;
        }



        #endregion



        #region Statistical Functions (Stats)


        public DoubleMat sum(int PartialMode)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), constants.mp_const_sum, PartialMode, mpPtr);
            return m1;
        }



        public DoubleMat prod(int PartialMode)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), constants.mp_const_prod, PartialMode, mpPtr);
            return m1;
        }



        public DoubleMat mean(int PartialMode)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), constants.mp_const_mean, PartialMode, mpPtr);
            return m1;
        }



        public DoubleMat minCoeff(int PartialMode)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), constants.mp_const_minCoeff, PartialMode, mpPtr);
            return m1;
        }



        public DoubleMat maxCoeff(int PartialMode)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), constants.mp_const_maxCoeff, PartialMode, mpPtr);
            return m1;
        }



        public DoubleMat squaredNorm(int PartialMode)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), constants.mp_const_squaredNorm, PartialMode, mpPtr);
            return m1;
        }



        public DoubleMat Norm(int PartialMode)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), constants.mp_const_Norm, PartialMode, mpPtr);
            return m1;
        }



        public DoubleMat stableNorm(int PartialMode)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), constants.mp_const_stableNorm, PartialMode, mpPtr);
            return m1;
        }


        #endregion



        #region Statistical Functions returning indices (Stats2)


        public DoubleMat minCoeff_Index(ref int IndexX, ref int IndexY)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats2(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), ref IndexX, ref IndexY, constants.mp_const_minCoeff_Index, mpPtr);
            return m1;
        }


        public DoubleMat maxCoeff_Index(ref int IndexX, ref int IndexY)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Stats2(constants.mp_eigen, dlib.GetModuleIndex(typeof(dreal)), GetPtr(m1), ref IndexX, ref IndexY, constants.mp_const_maxCoeff_Index, mpPtr);
            return m1;
        }


        #endregion



        #region Det, Solve, Inverse


        public Double Det()
        {
            var res = PartialPivLU("det", this);
            return res["det"][(int)Math.Round(0.0)];
        }


        public DoubleMat Solve(DoubleMat B)
        {
            var res = PartialPivLU("x", B);
            return res["x"];
        }


        public DoubleMat Inverse()
        {
            var res = PartialPivLU("inverse", this);
            return res["inverse"];
        }


        #endregion



        #region Sorting and Random




        public void Sort(int SortOrder, int SortCriterion)
        {
            dlib.Lib_Eigen_FReal_Sort(constants.mp_real, mpPtr, SortOrder, SortCriterion);
        }


        public void SortRowsByCol(int ColumnToSortBy, int SortOrder, int SortCriterion)
        {
            dlib.Lib_Eigen_FReal_SortRowsByColumn(constants.mp_real, mpPtr, ColumnToSortBy, SortOrder, SortCriterion);
        }


        // To be changed to remove nan and Inf
        public DoubleMat SelectRows()
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_Select_Rows(constants.mp_real, m1.mpPtr, mpPtr);
            return m1;
        }



        #endregion




        #region Multiple Results


        public DoubleMatMap RealQZ(string results, DoubleMat b)
        {
            var res_map = new DoubleMatMap();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(Double)), res_map, constants.mp_realQZ, results, this, b);
            return res_map;
        }


        public DoubleMatMap PseudoEigenSystem(string results)
        {
            var res_map = new DoubleMatMap();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(Double)), res_map, constants.mp_PseudoEigenSystem, results, this, this);
            return res_map;
        }



        public ComplexMatMap EigenValues(string results)
        {
            var res_map = new ComplexMatMap();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(Complex)), res_map, constants.mp_EigenValuesFromRealInput, results, this, this);
            return res_map;
        }


        public ComplexMatMap EigenSystem(string results)
        {
            var res_map = new ComplexMatMap();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(Complex)), res_map, constants.mp_EigenSystemFromRealInput, results, this, this);
            return res_map;
        }



        public ComplexMatMap GenEigenValues(string results, DoubleMat B)
        {
            var res_map = new ComplexMatMap();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(Complex)), res_map, constants.mp_EigenValuesFromRealInput, results, this, B);
            return res_map;
        }


        public ComplexMatMap GenEigenSystem(string results, DoubleMat B)
        {
            var res_map = new ComplexMatMap();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(Complex)), res_map, constants.mp_GeneralizedEigenSystemFromRealInput, results, this, B);
            return res_map;
        }



        #endregion






        #region Polynomials, Covariance



        public DoubleMat Covariance(DoubleMat Centered)
        {
            var m1 = new DoubleMat();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m1.mpPtr, constants.mp_const_covariance, Centered.mpPtr, mpPtr);
            // Lib_Eigen_FReal_Real_Covariance(m1.mpPtr, Centered.mpPtr, mpPtr)
            return m1;
        }






        public DoubleMat RootsToMonicPolynomial()
        {
            var m1 = new DoubleMat();
            Lib_Eigen_FReal_Real_Roots_To_MonicPolynomial(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_Roots_To_MonicPolynomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_Roots_To_MonicPolynomial(IntPtr MatrixPtr_polynomial_result, IntPtr MatrixPtr_roots_source);



        public DoubleMat PolyEval(DoubleMat roots)
        {
            var m1 = new DoubleMat();
            Lib_Eigen_FReal_Real_Poly_Eval(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_Poly_Eval", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_Poly_Eval(IntPtr MatrixPtr_evaluation_result, IntPtr MatrixPtr_polynomial_source, IntPtr MatrixPtr_roots_source);


        public ComplexMat PolyEval(ComplexMat roots)
        {
            var m1 = new ComplexMat();
            Lib_Eigen_FReal_Real_Poly_Eval_Complex(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_Poly_Eval_Complex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_Poly_Eval_Complex(IntPtr MatrixPtr_cplxevaluation_result, IntPtr MatrixPtr_realpolynomial_source, IntPtr MatrixPtr_cplxroots_source);


        public ComplexMat PolynomialSolver()
        {
            var m1 = new ComplexMat();
            Lib_Eigen_FReal_Real_PolynomialSolver(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_PolynomialSolver", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_PolynomialSolver(IntPtr MatrixPtr_cplxroots_result, IntPtr MatrixPtr_polynomial_source);




        #endregion



        #region MatrixFunctions


        public DoubleMat ExpMat()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_exp, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_MatrixFunction", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_MatrixFunction(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_A);

        public DoubleMat SinMat()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sin, mpPtr);
            return m3;
        }


        public DoubleMat CosMat()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_cos, mpPtr);
            return m3;
        }


        public DoubleMat SinhMat()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sinh, mpPtr);
            return m3;
        }


        public DoubleMat CoshMat()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_cosh, mpPtr);
            return m3;
        }


        public DoubleMat SqrtMat()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sqrt, mpPtr);
            return m3;
        }


        public DoubleMat LogMat()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_log, mpPtr);
            return m3;
        }


        public DoubleMat PowMat()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_pow, mpPtr);
            return m3;
        }



        #endregion



        #region FFT


        public ComplexMat FFTFwd()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Real_FFT_Real_Fwd(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_FFT_Real_Fwd", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_FFT_Real_Fwd(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);

        #endregion





    }





    public class ComplexMatMap
    {

        public IntPtr mpPtr = IntPtr.Zero;

        private void Init()
        {
            xcn.Init();
            mpPtr = dlib.Lib_Eigen_FReal_Init_Func(constants.mp_map, constants.mp_cplx);
        }


        public ComplexMatMap()
        {
            Init();
        }


        ~ComplexMatMap()
        {
            dlib.Lib_Eigen_FReal_Clear(constants.mp_map, constants.mp_cplx, mpPtr);
        }


        public ComplexMat this[string s]
        {
            get
            {
                var res = new ComplexMat();
                dlib.Lib_Eigen_FReal_Map_GetItemValue(constants.mp_eigen, constants.mp_cplx, res.mpPtr, mpPtr, s);
                return res;
            }
        }

    }





    public class ComplexMat : DoubleMatBase<Complex, ComplexMat, DoubleMat, ComplexMat, DoubleMat, Complex, ComplexMatMap, ComplexMatMap>
    {


        #region Init

        public ComplexMat()
        {
            Init();
        }


        private IntPtr GetPtr(dynamic x)
        {
            return (IntPtr)x.mpPtr;
        }


        ~ComplexMat()
        {
            dlib.Lib_Eigen_FReal_Clear(constants.mp_eigen, constants.mp_cplx, mpPtr);
        }


        public ComplexSpMat ToSparse()
        {
            var res = new ComplexSpMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_SparseFromDense(res.mpPtr, mpPtr);
            return res;
        }




        public override string ToString()
        {
            string res = "";
            var z1 = new Complex();
            for (int i = 0, loopTo = rows - 1; i <= loopTo; i++)
            {
                for (int j = 0, loopTo1 = cols - 1; j <= loopTo1; j++)
                {
                    z1 = this[i, j];
                    res = res + z1.ToString();
                }
                res = res + Environment.NewLine;
            }
            return res;
        }


        public void Print(string Title, int digits = 6)
        {
            Console.WriteLine(Title);
            Console.WriteLine(this);
        }

        #endregion



        #region Get and Set real and imag

        public DoubleMat real
        {
            get
            {
                var m1 = new DoubleMat();
                Lib_Eigen_FReal_ConvertRealCplx(GetPtr(m1), constants.mp_conv_get_from_complex_dbl, mpPtr);
                return m1;
            }

            set
            {
                Lib_Eigen_FReal_ConvertRealCplx(GetPtr(value), constants.mp_conv_set_to_complex_dbl, mpPtr);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_ConvertRealCplx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_ConvertRealCplx(IntPtr RMat, int what, IntPtr CMat);


        public DoubleMat imag
        {
            get
            {
                var m1 = new DoubleMat();
                Lib_Eigen_FReal_ConvertRealCplx(GetPtr(m1), constants.mp_conv_get_imag_from_complex_dbl, mpPtr);
                return m1;
            }

            set
            {
                Lib_Eigen_FReal_ConvertRealCplx(GetPtr(value), constants.mp_conv_set_imag_to_complex_dbl, mpPtr);
            }
        }

        #endregion



        #region Get and Set Coefficients


        public Complex this[int row_i, int col_j = 0]
        {
            get
            {
                Double Re = new Double(), Im = new Double();
                Eigen_FCplx_GetCoeff2(ref Re, ref Im, row_i, col_j, mpPtr);
                return dcplx.t(Re, Im);
            }

            set
            {
                double x = value.Real;
                double y = value.Imaginary;
                Eigen_FCplx_SetCoeff2(mpPtr, ref x, ref y, row_i, col_j);
            }
        }

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Cplx_GetCoeff2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_FCplx_GetCoeff2(ref Double result1, ref Double result2, int row, int col, IntPtr MatrixPtr_source);

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Cplx_SetCoeff2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_FCplx_SetCoeff2(IntPtr MatrixPtr_result, ref Double source1, ref Double source2, int row, int col);
        #endregion



        #region Arithmetic Comparisons (Compare)


        public static bool operator ==(ComplexMat m1, ComplexMat m2)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, constants.mp_cplx, constants.mp_const_EQ, m1.mpPtr, m2.mpPtr) == m1.size;
        }


        public static bool operator !=(ComplexMat m1, ComplexMat m2)
        {
            return dlib.Lib_Eigen_FReal_Compare(constants.mp_eigen, constants.mp_cplx, constants.mp_const_NE, m1.mpPtr, m2.mpPtr) == m1.size;
        }

        #endregion



        #region Arithmetic Operators (BasicArithmetic)


        public static ComplexMat operator +(ComplexMat m1)
        {
            var x = dcplx.t("1", "0");
            return m1 * x;
        }


        public static ComplexMat operator -(ComplexMat m1)
        {
            var x = dcplx.t("-1", "0");
            return m1 * x;
        }




        public static ComplexMat operator +(ComplexMat M1, ComplexMat M2)
        {
            var Res = new ComplexMat();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        public static ComplexMat operator +(ComplexMat m1, DoubleMat m2)
        {
            var m3 = new ComplexMat();
            var T2 = dcplx.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_plus, m1.mpPtr, T2.mpPtr);
            return m3;
        }





        public static ComplexMat operator +(ComplexMat M1, Complex m2)
        {
            var Res = new ComplexMat();
            var t = dcplx.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static ComplexMat operator +(dynamic m2, ComplexMat M1)  // Complex m2
        {
            var Res = new ComplexMat();
            var t = dcplx.mat_t(dcplx.t(m2));
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }





        public static ComplexMat operator -(ComplexMat m1, ComplexMat m2)
        {
            var m3 = new ComplexMat();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static ComplexMat operator -(ComplexMat m1, DoubleMat m2)
        {
            var m3 = new ComplexMat();
            var T2 = dcplx.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, T2.mpPtr);
            return m3;
        }


        public static ComplexMat operator -(ComplexMat M1, Complex m2)
        {
            var Res = new ComplexMat();
            var t = dcplx.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_minus, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static ComplexMat operator -(dynamic m2, ComplexMat M1)
        {
            var Res = new ComplexMat();
            var t = dcplx.mat_t(dcplx.t(m2));
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_minus, M1.mpPtr, t.mpPtr);
            return -Res;
        }




        public static ComplexMat operator *(ComplexMat m1, ComplexMat m2)
        {
            var m3 = new ComplexMat();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static ComplexMat operator *(ComplexMat m1, DoubleMat m2)
        {
            var m3 = new ComplexMat();
            var T2 = dcplx.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, T2.mpPtr);
            return m3;
        }


        public static ComplexMat operator *(ComplexMat M1, Complex m2)
        {
            var Res = new ComplexMat();
            var t = dcplx.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static ComplexMat operator *(dynamic m2, ComplexMat M1)
        {
            var Res = new ComplexMat();
            var t = dcplx.mat_t(dcplx.t(m2));
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        public static ComplexMat operator /(ComplexMat m1, ComplexMat m2)
        {
            var m3 = new ComplexMat();
            var m4 = new ComplexMat();
            m4 = m2.Inverse();
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }



        public static ComplexMat operator /(ComplexMat m1, DoubleMat m2)
        {
            var m3 = new ComplexMat();
            var m4 = dcplx.mat_t(m2.Inverse());
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }



        public static ComplexMat operator /(ComplexMat M1, Complex m2)
        {
            var Res = new ComplexMat();
            var t = dcplx.mat_t(m2);
            dlib.Lib_Eigen_FReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        #endregion



        #region Det, Solve, Inverse


        public Complex Det()
        {
            var res = PartialPivLU("det", this);
            return res["det"][(int)Math.Round(0.0)];
        }


        public ComplexMat Solve(ComplexMat b)
        {
            var res = PartialPivLU("x", b);
            return res["x"];
        }


        public ComplexMat Inverse()
        {
            var res = PartialPivLU("inverse", this);
            return res["inverse"];
        }


        #endregion



        #region Sorting and Random



        public void Sort(int SortOrder, int SortCriterion)
        {
            dlib.Lib_Eigen_FReal_Sort(constants.mp_cplx, mpPtr, SortOrder, SortCriterion);
        }


        public void SortRowsByCol(int ColumnToSortBy, int SortOrder, int SortCriterion)
        {
            dlib.Lib_Eigen_FReal_SortRowsByColumn(constants.mp_cplx, mpPtr, ColumnToSortBy, SortOrder, SortCriterion);
        }


        // To be changed to remove nan and Inf
        public ComplexMat SelectRows()
        {
            var m1 = new ComplexMat();
            dlib.Lib_Eigen_FReal_Select_Rows(constants.mp_cplx, m1.mpPtr, mpPtr);
            return m1;
        }



        #endregion





        #region Polynomials

        public ComplexMat RootsToMonicPolynomial()
        {
            var m1 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_Roots_To_MonicPolynomial(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Cplx_Roots_To_MonicPolynomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Cplx_Roots_To_MonicPolynomial(IntPtr MatrixPtr_polynomial_result, IntPtr MatrixPtr_roots_source);



        public ComplexMat PolyEval(ComplexMat roots)
        {
            var m1 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_Poly_Eval_Complex(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Cplx_Poly_Eval_Complex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Cplx_Poly_Eval_Complex(IntPtr MatrixPtr_evaluation_result, IntPtr MatrixPtr_polynomial_source, IntPtr MatrixPtr_roots_source);



        public ComplexMat PolynomialSolver()
        {
            var m1 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_PolynomialSolver(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Cplx_PolynomialSolver", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Cplx_PolynomialSolver(IntPtr MatrixPtr_cplxroots_result, IntPtr MatrixPtr_polynomial_source);



        #endregion




        #region MatrixFunctions





        public ComplexMat ExpMat()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_exp, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Cplx_MatrixFunction", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Cplx_MatrixFunction(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_A);

        public ComplexMat SinMat()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sin, mpPtr);
            return m3;
        }


        public ComplexMat CosMat()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_cos, mpPtr);
            return m3;
        }


        public ComplexMat SinhMat()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sinh, mpPtr);
            return m3;
        }


        public ComplexMat CoshMat()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_cosh, mpPtr);
            return m3;
        }


        public ComplexMat SqrtMat()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sqrt, mpPtr);
            return m3;
        }


        public ComplexMat LogMat()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_log, mpPtr);
            return m3;
        }


        public ComplexMat PowMat()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_pow, mpPtr);
            return m3;
        }



        #endregion



        #region FFT


        public DoubleMat FFTRealInv()
        {
            var m3 = new DoubleMat();
            Lib_Eigen_FReal_Real_FFT_Real_Inv(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_FFT_Real_Inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_FFT_Real_Inv(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);


        public ComplexMat FFTFwd()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_FFT_Fwd(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Cplx_FFT_Fwd", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Cplx_FFT_Fwd(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);


        public ComplexMat FFTCplxInv()
        {
            var m3 = new ComplexMat();
            Lib_Eigen_FReal_Cplx_FFT_Inv(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Cplx_FFT_Inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Cplx_FFT_Inv(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);



        #endregion



        #region Multiple Results


        public ComplexMatMap EigenValues(string results)
        {
            var res_map = new ComplexMatMap();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(Complex)), res_map, constants.mp_EigenValues, results, this, this);
            return res_map;
        }


        public ComplexMatMap EigenSystem(string results)
        {
            var res_map = new ComplexMatMap();
            dlib.Call_Eigen_MultipleResults(constants.mp_eigen, dlib.GetModuleIndex(typeof(Complex)), res_map, constants.mp_EigenSystem, results, this, this);
            return res_map;
        }



        #endregion



    }




    internal static class DLibSparse
    {



        // *********************************************** Sparse Real**********************************************************



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_EigenSparse_FReal_Init_Func();


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Clear(IntPtr a);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_EigenSparse_FReal_GetInfo(int what, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_PrintSparseMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_PrintSparseMatrix(IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Get_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Put_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_SetSpecialValue(IntPtr MatrixPtr_result, int what, int m, int n);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_SetSpecialValue2(IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_BasicArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Stats", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Stats(IntPtr MatrixPtr_result, int what, int PartialMode, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_FReal_Solve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_FReal_Solve(IntPtr MatrixPtr_result, IntPtr MatrixPtr_A, IntPtr MatrixPtr_b, int Decomposition);



        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_FReal_DenseFromSparse", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_FReal_DenseFromSparse(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);


        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_FReal_SparseFromDense", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_FReal_SparseFromDense(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);








        // *********************************************** Sparse Complex*******************************************




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Cplx_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_EigenSparse_FReal_Cplx_Init_Func();


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Cplx_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Cplx_Clear(IntPtr a);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Cplx_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_EigenSparse_FReal_Cplx_GetInfo(int what, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Cplx_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Cplx_Get_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Cplx_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Cplx_Put_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Cplx_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Cplx_SetSpecialValue(IntPtr MatrixPtr_result, int what, int m, int n);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Cplx_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_FReal_Cplx_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_FReal_Cplx_BasicArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_FReal_Cplx_Solve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_FReal_Cplx_Solve(IntPtr MatrixPtr_result, IntPtr MatrixPtr_A, IntPtr MatrixPtr_b, int Decomposition);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_FReal_Cplx_DenseFromSparse", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_FReal_Cplx_DenseFromSparse(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_FReal_Cplx_SparseFromDense", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_FReal_Cplx_SparseFromDense(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);



    }




    public class DoubleSpMat
    {

        public IntPtr mpPtr = IntPtr.Zero;


        #region Constructors

        private void Init()
        {
            xcn.Init();
            mpPtr = DLibSparse.Lib_EigenSparse_FReal_Init_Func();
        }



        private void Init(int m, int n = 1)
        {
            Init();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_Resize, m, n);
        }


        public DoubleSpMat()
        {
            Init();
        }


        /// <summary>
        /// Create a new Matrix with m of rows and n columns.  
        /// </summary>
        /// <param name="m">Number of rows</param>
        /// <param name="n">Number of columns</param>
        public DoubleSpMat(int m, int n)
        {
            Init(m, n);
        }


        // Public Sub New(x As Double)
        // Init()
        // Lib_EigenSparse_FReal_SetCoeff(mpPtr, x, 0, 0)
        // End Sub


        public DoubleSpMat(DoubleSpMat src)
        {
            Init();
            DLibSparse.Lib_EigenSparse_FReal_Put_Block(mpPtr, constants.mp_const_fullcopy, 0, 0, 0, 0, src.mpPtr);
        }


        public DoubleSpMat(DoubleMat src)
        {
            Init();
            DLibSparse.EigenSparseLib_FReal_SparseFromDense(mpPtr, src.mpPtr);
        }


        ~DoubleSpMat()
        {
            DLibSparse.Lib_EigenSparse_FReal_Clear(mpPtr);
        }

        #endregion


        #region Input and Output


        public DoubleMat ToDense()
        {
            var A = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_DenseFromSparse(A.mpPtr, mpPtr);
            return A;
        }

        public void Print(string Title, int digits = 6)
        {
            var A = ToDense();
            A.Print(Title, digits);
            // Lib_FReal_PrintSparseMatrix(mpPtr)
        }

        #endregion


        #region Get and Set Coefficients



        #endregion


        #region Get Info

        /// <summary>
        /// The number of rows in the matrix
        /// </summary>
        /// <returns>The number of rows in the matrix</returns>
        public int rows
        {
            get
            {
                return DLibSparse.Lib_EigenSparse_FReal_GetInfo(constants.mp_const_rows, mpPtr);
            }
        }


        /// <summary>
        /// The number of columns in the matrix
        /// </summary>
        /// <returns>The number of columns in the matrix</returns>
        public int cols
        {
            get
            {
                return DLibSparse.Lib_EigenSparse_FReal_GetInfo(constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return DLibSparse.Lib_EigenSparse_FReal_GetInfo(constants.mp_const_size, mpPtr);
            }
        }

        #endregion


        #region Get and Set Blocks, Rows, Cols, Triangular ...

        /// <summary>
        /// Gets or Sets a block
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public DoubleSpMat get_block(int i, int j, int p, int q)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Get_Block(m1.mpPtr, constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_block(int i, int j, int p, int q, DoubleSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Put_Block(mpPtr, constants.mp_const_block, i, j, p, q, value.mpPtr);
        }



        public DoubleSpMat get_row(int i)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Get_Block(m1.mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_row(int i, DoubleSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Put_Block(mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, value.mpPtr);
        }



        public DoubleSpMat get_col(int j)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Get_Block(m1.mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_col(int j, DoubleSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Put_Block(mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, value.mpPtr);
        }




        public DoubleSpMat get_diagonal(int q = 0)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Get_Block(m1.mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_diagonal(int q, DoubleSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Put_Block(mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, value.mpPtr);
        }




        public DoubleSpMat get_triangularView(int View = 1)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Get_Block(m1.mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_triangularView(int View, DoubleSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Put_Block(mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, value.mpPtr);
        }



        #endregion


        #region SetSpecialValue


        public void setZero(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_setZero, n, m);
        }



        public void setOnes(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_setOnes, n, m);
        }


        public void setIdentity(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_setIdentity, n, m);
        }


        public void resize(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_Resize, n, m);
        }


        public void conservative_resize(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_conservativeResize, n, m);
        }



        public void Random(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_setRandom_nm, n, m);
        }


        public void RandomSymmetric(int n)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_setRandomSymmetric, n, n);
        }



        public void FillLinear(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue(mpPtr, constants.mp_FillLinear, n, m);
        }


        #endregion





        #region SetSpecialValue2


        public void ResizeLike(DoubleSpMat m1)
        {
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(mpPtr, constants.mp_ResizeLike, 0, 0, 0, m1.mpPtr);
        }


        public DoubleSpMat asDiagonal()
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public DoubleSpMat adjoint()
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public DoubleSpMat conjugate()
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public DoubleSpMat transpose()
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public DoubleSpMat reverse_full()
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public DoubleSpMat reverse_rowwise()
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public DoubleSpMat reverse_colwise()
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public DoubleSpMat replicate_full(int Vertical, int Horizontal)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public DoubleSpMat replicate_rowwise(int Vertical)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public DoubleSpMat replicate_colwise(int Horizontal)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
            return m1;
        }

        #endregion


        #region Arithmetic Comparisons (Compare)



        #endregion


        #region Arithmetic Operators (BasicArithmetic)


        // Public Shared Operator +(ByVal m1 As dbl_spmat_t) As dbl_spmat_t
        // Return (1.0) * m1
        // End Operator


        // Public Shared Operator -(ByVal m1 As dbl_spmat_t) As dbl_spmat_t
        // Return (-1.0) * m1
        // End Operator




        public static DoubleSpMat operator +(DoubleSpMat M1, DoubleSpMat M2)
        {
            var Res = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_BasicArithmetic(Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        // Public Shared Operator +(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_FReal_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator +(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_FReal_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator +(ByVal M1 As dbl_spmat_t, ByVal m2 As Complex) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, T1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator +(ByVal m2 As Complex, ByVal M1 As dbl_spmat_t) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, T1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator




        public static DoubleSpMat operator -(DoubleSpMat m1, DoubleSpMat m2)
        {
            var m3 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_BasicArithmetic(m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }



        // Public Shared Operator -(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_FReal_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_FReal_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return -Res
        // End Operator



        // Public Shared Operator -(ByVal M1 As dbl_spmat_t, ByVal m2 As Complex) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, T1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m2 As Complex, ByVal M1 As dbl_spmat_t) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, T1.mpPtr, t.mpPtr)
        // Return -Res
        // End Operator



        public static DoubleSpMat operator *(DoubleSpMat m1, DoubleSpMat m2)
        {
            var m3 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_BasicArithmetic(m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator *(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_FReal_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator *(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_FReal_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator *(ByVal M1 As dbl_spmat_t, ByVal m2 As Complex) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, T1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator *(ByVal m2 As Complex, ByVal M1 As dbl_spmat_t) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, T1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator




        public DoubleSpMat cwiseProduct(DoubleSpMat x)
        {
            var m3 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseProduct(x As cplx_mat_t) As cplx_mat_t
        // Dim m3 As New cplx_mat_t()
        // Dim T1 As New cplx_mat_t(Me)
        // Lib_Eigen_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseProduct, T1.mpPtr, x.mpPtr)
        // Return m3
        // End Function



        public DoubleSpMat dotProduct(DoubleSpMat x)
        {
            var m3 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_BasicArithmetic(m3.mpPtr, constants.mp_const_DotProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function dotProduct(x As cplx_mat_t) As cplx_mat_t
        // Dim m3 As New cplx_mat_t()
        // Dim T1 As New cplx_mat_t(Me)
        // Lib_Eigen_Cplx_BasicArithmetic(m3.mpPtr, mp_const_DotProduct, T1.mpPtr, x.mpPtr)
        // Return m3
        // End Function



        // Public Shared Operator /(ByVal m1 As dbl_spmat_t, ByVal m2 As dbl_spmat_t) As dbl_spmat_t
        // Dim m3 As New dbl_spmat_t()
        // Dim m4 As New dbl_spmat_t()
        // m4 = m2.inverse()
        // Lib_EigenSparse_FReal_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator /(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_FReal_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator /(ByVal M1 As dbl_spmat_t, ByVal m2 As Complex) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, T1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public DoubleSpMat cwiseQuotient(DoubleSpMat x)
        {
            var m3 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseQuotient, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseQuotient(x As cplx_mat_t) As cplx_mat_t
        // Dim m3 As New cplx_mat_t()
        // Dim T1 As New cplx_mat_t(Me)
        // Lib_Eigen_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseQuotient, T1.mpPtr, x.mpPtr)
        // Return m3
        // End Function


        #endregion


        #region Statistical Functions (Stats)


        public DoubleSpMat sum(int PartialMode)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Stats(m1.mpPtr, constants.mp_const_sum, PartialMode, mpPtr);
            return m1;
        }



        public DoubleSpMat prod(int PartialMode)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Stats(m1.mpPtr, constants.mp_const_prod, PartialMode, mpPtr);
            return m1;
        }



        public DoubleSpMat mean(int PartialMode)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Stats(m1.mpPtr, constants.mp_const_mean, PartialMode, mpPtr);
            return m1;
        }



        public DoubleSpMat minCoeff(int PartialMode)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Stats(m1.mpPtr, constants.mp_const_minCoeff, PartialMode, mpPtr);
            return m1;
        }



        public DoubleSpMat maxCoeff(int PartialMode)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Stats(m1.mpPtr, constants.mp_const_maxCoeff, PartialMode, mpPtr);
            return m1;
        }



        public DoubleSpMat squaredNorm(int PartialMode)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Stats(m1.mpPtr, constants.mp_const_squaredNorm, PartialMode, mpPtr);
            return m1;
        }



        public DoubleSpMat Norm(int PartialMode)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Stats(m1.mpPtr, constants.mp_const_Norm, PartialMode, mpPtr);
            return m1;
        }



        public DoubleSpMat stableNorm(int PartialMode)
        {
            var m1 = new DoubleSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Stats(m1.mpPtr, constants.mp_const_stableNorm, PartialMode, mpPtr);
            return m1;
        }


        #endregion




        #region Solver

        public DoubleMat solve(DoubleMat b)
        {
            var x = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }


        public DoubleMat SimplicialLLT_Solver(DoubleMat b)
        {
            var x = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_llt);
            return x;
        }


        public DoubleMat SimplicialLDLT_Solver(DoubleMat b)
        {
            var x = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_ldlt);
            return x;
        }



        public DoubleMat SparseLU_Solver(DoubleMat b)
        {
            var x = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_lu);
            return x;
        }



        public DoubleMat SparseQR_Solver(DoubleMat b)
        {
            var x = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }



        public DoubleMat ConjugateGradient_Solver(DoubleMat b)
        {
            var x = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_CG_Solver);
            return x;
        }



        public DoubleMat LeastSquaresConjugateGradient_Solver(DoubleMat b)
        {
            var x = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_LSCG_Solver);
            return x;
        }



        public DoubleMat BiCGSTAB_Solver(DoubleMat b)
        {
            var x = new DoubleMat();
            DLibSparse.EigenSparseLib_FReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_BiCGSTAB_Solver);
            return x;
        }


        #endregion



    }



    public class ComplexSpMat
    {

        internal IntPtr mpPtr = IntPtr.Zero;


        #region Constructors

        private void Init()
        {
            xcn.Init();
            mpPtr = DLibSparse.Lib_EigenSparse_FReal_Cplx_Init_Func();
        }


        public void Init(int m, int n = 1)
        {
            xcn.Init();
            // mpPtr = Lib_EigenSparse_FReal_Cplx_Init_Func()
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_Resize, m, n);
        }


        public ComplexSpMat()
        {
            Init();
        }


        /// <summary>
        /// Create a new Matrix with m of rows and n columns.  
        /// </summary>
        /// <param name="m">Number of rows</param>
        /// <param name="n">Number of columns</param>
        public ComplexSpMat(int m, int n = 1)
        {
            Init(m, n);
        }


        // Public Sub New(x As Complex)
        // mpPtr = Lib_EigenSparse_FReal_Cplx_Init_Func()
        // Lib_EigenSparse_FReal_Cplx_SetCoeff2Real(mpPtr, x.Real, x.Imaginary, 0, 0)
        // End Sub


        public ComplexSpMat(ComplexSpMat src)
        {
            Init();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Put_Block(mpPtr, constants.mp_const_fullcopy, 0, 0, 0, 0, src.mpPtr);
        }


        public ComplexSpMat(ComplexMat src)
        {
            Init();
            DLibSparse.EigenSparseLib_FReal_Cplx_SparseFromDense(mpPtr, src.mpPtr);
        }


        // Public Sub New(src As dbl_spmat_t)
        // Init(src.rows, src.cols)
        // Lib_Eigen_Set_Real_To_Complex_Dbl(mpPtr, src.mpPtr)
        // End Sub



        ~ComplexSpMat()
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Clear(mpPtr);
        }

        #endregion


        #region Input and Output


        public ComplexMat ToDense()
        {
            var A = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_DenseFromSparse(A.mpPtr, mpPtr);
            return A;
        }


        public void Print(string Title, int digits = 6)
        {
            var FromSparse = ToDense();
            FromSparse.Print(Title);
            Console.WriteLine(this);
        }

        #endregion


        #region Get and Set Coefficients


        // ''' <summary>
        // ''' Gets and Sets an Item
        // ''' </summary>
        // ''' <param name="row_i"></param>
        // ''' <param name="col_j"></param>
        // Default Public Property item(ByVal row_i As Int32, Optional ByVal col_j As Int32 = 0) As Complex
        // Get
        // Dim res_re, res_im  As New dbl_t()
        // Lib_EigenSparse_FReal_Cplx_GetCoeff2Real(res_re.mpPtr, res_im.mpPtr, row_i, col_j, mpPtr)
        // Return New Complex(res_re, res_im)
        // End Get
        // Set(ByVal m1 As Complex)
        // Lib_EigenSparse_FReal_Cplx_SetCoeff2Real(mpPtr, m1.Real, m1.Imaginary, row_i, col_j)
        // End Set
        // End Property

        #endregion


        #region Get Info

        /// <summary>
        /// The number of rows in the matrix
        /// </summary>
        /// <returns>The number of rows in the matrix</returns>
        public int rows
        {
            get
            {
                return DLibSparse.Lib_EigenSparse_FReal_Cplx_GetInfo(constants.mp_const_rows, mpPtr);
            }
        }


        /// <summary>
        /// The number of columns in the matrix
        /// </summary>
        /// <returns>The number of columns in the matrix</returns>
        public int cols
        {
            get
            {
                return DLibSparse.Lib_EigenSparse_FReal_Cplx_GetInfo(constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return DLibSparse.Lib_EigenSparse_FReal_Cplx_GetInfo(constants.mp_const_size, mpPtr);
            }
        }

        #endregion


        #region Get and Set Real and Imag

        // Public Property real() As dbl_spmat_t
        // Get
        // Dim m1 As New dbl_spmat_t
        // Lib_Eigen_Get_Real_From_Complex_Dbl(m1.mpPtr, mpPtr)
        // Return m1
        // End Get
        // Set(ByVal m1 As dbl_spmat_t)
        // Lib_Eigen_Set_Real_To_Complex_Dbl(mpPtr, m1.mpPtr)
        // End Set
        // End Property
        // 
        // 
        // 
        // Public Property imag() As dbl_spmat_t
        // Get
        // Dim m1 As New dbl_spmat_t
        // Lib_Eigen_Get_Imag_From_Complex_Dbl(m1.mpPtr, mpPtr)
        // Return m1
        // End Get
        // Set(ByVal m1 As dbl_spmat_t)
        // Lib_Eigen_Set_Imag_To_Complex_Dbl(mpPtr, m1.mpPtr)
        // End Set
        // End Property

        #endregion


        #region Get and Set Blocks, Rows, Cols, Triangular ...

        /// <summary>
        /// Gets or Sets a block
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public ComplexSpMat get_block(int i, int j, int p, int q)
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_block(int i, int j, int p, int q, ComplexSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Put_Block(mpPtr, constants.mp_const_block, i, j, p, q, value.mpPtr);
        }



        public ComplexSpMat get_row(int i)
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_row(int i, ComplexSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Put_Block(mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, value.mpPtr);
        }



        public ComplexSpMat get_col(int j)
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_col(int j, ComplexSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Put_Block(mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, value.mpPtr);
        }




        public ComplexSpMat get_diagonal(int q = 0)
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_diagonal(int q, ComplexSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Put_Block(mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, value.mpPtr);
        }




        public ComplexSpMat get_triangularView(int View = 1)
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_triangularView(int View, ComplexSpMat value)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_Put_Block(mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, value.mpPtr);
        }



        #endregion


        #region SetSpecialValue




        public void setZero(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setZero, n, m);
        }



        public void setOnes(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setOnes, n, m);
        }


        public void setIdentity(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setIdentity, n, m);
        }



        public void resize(int rows, int cols)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_Resize, rows, cols);
        }



        public void conservative_resize(int rows, int cols)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_conservativeResize, rows, cols);
        }




        public void Random(int n, int m = 1)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandom_nm, n, m);
        }



        public void RandomSymmetric(int n)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandomSymmetric, n, n);
        }



        public void RandomHermitian(int n)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandomSA, n, n);
        }



        public void FillLinear(int n, int m)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue(mpPtr, constants.mp_FillLinear, n, m);
        }

        #endregion


        #region SetSpecialValue2


        public void ResizeLike(ComplexSpMat m1)
        {
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(mpPtr, constants.mp_ResizeLike, 0, 0, 0, m1.mpPtr);
        }


        public ComplexSpMat asDiagonal()
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public ComplexSpMat adjoint()
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public ComplexSpMat conjugate()
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public ComplexSpMat transpose()
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public ComplexSpMat reverse_full()
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public ComplexSpMat reverse_rowwise()
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public ComplexSpMat reverse_colwise()
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public ComplexSpMat replicate_full(int Vertical, int Horizontal)
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public ComplexSpMat replicate_rowwise(int Vertical)
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public ComplexSpMat replicate_colwise(int Horizontal)
        {
            var m1 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
            return m1;
        }

        #endregion


        #region Arithmetic Comparisons (Compare)


        // Public Shared Operator =(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As Boolean
        // Return (Lib_EigenSparse_FReal_Cplx_Compare(mp_const_EQ, m1.mpPtr, m2.mpPtr) = m1.Size)
        // End Operator
        // 
        // 
        // Public Shared Operator <>(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As Boolean
        // Return (Lib_EigenSparse_FReal_Cplx_Compare(mp_const_NE, m1.mpPtr, m2.mpPtr) = m1.Size)
        // End Operator

        #endregion


        #region Arithmetic Operators (BasicArithmetic)


        // Public Shared Operator +(ByVal m1 As cplx_spmat_t) As cplx_spmat_t
        // Return m1 + 0.0
        // End Operator


        // Public Shared Operator -(ByVal m1 As cplx_spmat_t) As cplx_spmat_t
        // Return (-1.0) * m1
        // End Operator




        public static ComplexSpMat operator +(ComplexSpMat M1, ComplexSpMat M2)
        {
            var Res = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_BasicArithmetic(Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        // Public Shared Operator +(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_plus, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator +(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_plus, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator +(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator +(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator





        public static ComplexSpMat operator -(ComplexSpMat m1, ComplexSpMat m2)
        {
            var m3 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator -(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_minus, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_minus, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator -(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return -Res
        // End Operator




        public static ComplexSpMat operator *(ComplexSpMat m1, ComplexSpMat m2)
        {
            var m3 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator *(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator *(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator *(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator *(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public ComplexSpMat cwiseProduct(ComplexSpMat x)
        {
            var m3 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseProduct(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseProduct, T1.mpPtr, mpPtr)
        // Return m3
        // End Function



        public ComplexSpMat dotProduct(ComplexSpMat x)
        {
            var m3 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_DotProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function dotProduct(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_DotProduct, mpPtr, T1.mpPtr)
        // Return m3
        // End Function




        // Public Shared Operator /(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t()
        // m4 = m2.inverse()
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator



        // Public Shared Operator /(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t(m2.inverse())
        // '        m4 = m2.inverse()
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator /(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t()
        // m4 = m2.inverse()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, T1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator



        // Public Shared Operator /(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public ComplexSpMat cwiseQuotient(ComplexSpMat x)
        {
            var m3 = new ComplexSpMat();
            DLibSparse.Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseQuotient, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseQuotient(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_FReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseQuotient, mpPtr, T1.mpPtr)
        // Return m3
        // End Function

        #endregion


        #region Solver

        public ComplexMat solve(ComplexMat b)
        {
            var x = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }


        public ComplexMat SimplicialLLT_Solver(ComplexMat b)
        {
            var x = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_llt);
            return x;
        }


        public ComplexMat SimplicialLDLT_Solver(ComplexMat b)
        {
            var x = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_ldlt);
            return x;
        }



        public ComplexMat SparseLU_Solver(ComplexMat b)
        {
            var x = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_lu);
            return x;
        }



        public ComplexMat SparseQR_Solver(ComplexMat b)
        {
            var x = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }



        public ComplexMat ConjugateGradient_Solver(ComplexMat b)
        {
            var x = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_CG_Solver);
            return x;
        }



        public ComplexMat LeastSquaresConjugateGradient_Solver(ComplexMat b)
        {
            var x = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_LSCG_Solver);
            return x;
        }



        public ComplexMat BiCGSTAB_Solver(ComplexMat b)
        {
            var x = new ComplexMat();
            DLibSparse.EigenSparseLib_FReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_BiCGSTAB_Solver);
            return x;
        }





        #endregion






    }





}