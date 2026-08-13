using System;
using System.Runtime.InteropServices;


namespace FixedPrecNet
{


    internal static class slib
    {


        public static int GetModuleIndex(Type MyType)
        {
            // Dim Result As Int32 = mp_real
            int Result = 0; // = mp_cplx
            string s = MyType.Name;
            // Console.WriteLine("s: {0}", s)
            if (s.EndsWith("Single"))
                Result = constants.mp_real;
            if (s.EndsWith("SingleC"))
                Result = constants.mp_cplx;

            return Result;
        }



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_Eigen_SReal_Init_Func(int mpCat, int mpType);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Clear(int mpCat, int mpType, IntPtr AnyPtr);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_Eigen_SReal_GetInfo(int mpCat, int mpType, int what, IntPtr MatrixPtr_source);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Get_Block(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Put_Block(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_SetSpecialValue(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int m, int n);


        internal static void Call_Eigen_SetSpecialValue(int mpCat, int mpType, dynamic result, int what, int m, int n)
        {
            Lib_Eigen_SReal_SetSpecialValue(mpCat, mpType, (IntPtr)result.mpPtr, what, m, n);
        }




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_SetSpecialValue2(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Compare", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint Lib_Eigen_SReal_Compare(int mpCat, int mpType, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_BasicArithmetic(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_CplxScalarArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_CplxScalarArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, ref Single Y_re, ref Single Y_im);

        //internal static extern void Lib_Eigen_SReal_Real_CplxScalarArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr Y_re, IntPtr Y_im);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Stats", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Stats(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int PartialMode, IntPtr MatrixPtr_source);


        // !!! Needs to be modified to remove ByRef !!! Switch from Int32 to Fmpz
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Stats2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Stats2(int mpCat, int mpType, IntPtr MatrixPtr_result, ref int IndexX, ref int IndexY, int what, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Map_GetItemValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Map_GetItemValue(int mpCat, int mpType, IntPtr res_mpPtr, IntPtr mpPtr, string str);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_MultipleResults", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_MultipleResults(int mpCat, int mpType, IntPtr ResMap, int what, string str, IntPtr MatA, IntPtr MatB);

        internal static void Call_Eigen_MultipleResults(int mpCat, int mpType, dynamic ResMap, int what, string str, dynamic MatA, dynamic MatB)
        {
            Lib_Eigen_SReal_MultipleResults(mpCat, mpType, (IntPtr)ResMap.mpPtr, what, str, (IntPtr)MatA.mpPtr, (IntPtr)MatB.mpPtr);
        }




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Sort", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Sort(int numType, IntPtr MatrixPtr_result_val, int SortOrder, int SortCriterion);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_SortRowsByColumn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_SortRowsByColumn(int numType, IntPtr MatrixPtr_result_val, int ColumnToSortBy, int SortOrder, int SortCriterion);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Select_Rows", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Select_Rows(int numType, IntPtr MatrixPtr_result_val, IntPtr MatrixPtr_source);



        #region MINPACK


        public static void testHybrj_ext(cbProc2Ptr F1, cbProc2Ptr F2, SingleMat xMat, SingleMat fvecMat, SingleMat fjacMat, SingleMat matInput)
        {
            Lib_Eigen_SReal_Real_testHybrj_ext(F1, F2, xMat.mpPtr, fvecMat.mpPtr, fjacMat.mpPtr, matInput.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_testHybrj_ext", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_testHybrj_ext(cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matFvecPtr, IntPtr matFjacPtr, IntPtr matInput);



        public static void testLmder_ext(cbProc2Ptr F1, cbProc2Ptr F2, SingleMat xMat, SingleMat fvecMat, SingleMat fjacMat, SingleMat matInput)
        {
            Lib_Eigen_SReal_Real_testLmder_ext(F1, F2, xMat.mpPtr, fvecMat.mpPtr, fjacMat.mpPtr, matInput.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_testLmder_ext", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_testLmder_ext(cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matFvecPtr, IntPtr matFjacPtr, IntPtr matInput);


        #endregion






    }




    public class SingleMatBase<MyType, MatType, RealMatType, RetMatType, RetRealMatType, RetScalarType, RetMapType, RetCMapType>
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
            mpPtr = slib.Lib_Eigen_SReal_Init_Func(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)));
        }


        public SingleMatBase()
        {
            // Console.WriteLine("New: , MyMatType: {0} ", GetType(MyType))
        }

        #endregion



        #region Get Info

        public int rows
        {
            get
            {
                return slib.Lib_Eigen_SReal_GetInfo(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_rows, mpPtr);
            }
        }


        public int cols
        {
            get
            {
                return slib.Lib_Eigen_SReal_GetInfo(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return slib.Lib_Eigen_SReal_GetInfo(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_size, mpPtr);
            }
        }

        #endregion





        #region Get and Set Blocks, Rows, Cols, Triangular ...

        public RetMatType get_Block(int i, int j, int p, int q)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_Get_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_Block(int i, int j, int p, int q, RetMatType value)
        {
            slib.Lib_Eigen_SReal_Put_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_block, i, j, p, q, GetPtr(value));
        }



        public RetMatType get_Row(int i)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_Get_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_Row(int i, RetMatType value)
        {
            slib.Lib_Eigen_SReal_Put_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, GetPtr(value));
        }



        public RetMatType get_Col(int j)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_Get_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_Col(int j, RetMatType value)
        {
            slib.Lib_Eigen_SReal_Put_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, GetPtr(value));
        }




        public RetMatType get_Diagonal(int q = 0)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_Get_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_Diagonal(int q, RetMatType value)
        {
            slib.Lib_Eigen_SReal_Put_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, GetPtr(value));
        }




        public RetMatType get_TriangularView(int View = 1)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_Get_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_TriangularView(int View, RetMatType value)
        {
            slib.Lib_Eigen_SReal_Put_Block(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, GetPtr(value));
        }



        #endregion



        #region SetSpecialValue




        public void Resize(int n, int m)
        {
            slib.Lib_Eigen_SReal_SetSpecialValue(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_Resize, n, m);
        }


        public void ConservativeResize(int n, int m)
        {
            slib.Lib_Eigen_SReal_SetSpecialValue(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_conservativeResize, n, m);
        }




        #endregion



        #region SetSpecialValue2


        public void ResizeLike(RetMatType m1)
        {
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_ResizeLike, 0, 0, 0, GetPtr(m1));
        }


        public RetMatType AsDiagonal()
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Adjoint()
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Conjugate()
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Transpose()
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public RetMatType ReverseFull()
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public RetMatType ReverseRowwise()
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public RetMatType ReverseColwise()
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public RetMatType ReplicateFull(int Vertical, int Horizontal)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public RetMatType ReplicateRowwise(int Vertical)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public RetMatType ReplicateColwise(int Horizontal)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_SetSpecialValue2(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
            return m1;
        }

        #endregion



        #region Arithmetic Comparisons (Compare)

        public uint GTcount(RetMatType Y)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_GT, mpPtr, GetPtr(Y));
        }


        public uint LTcount(RetMatType Y)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_LT, mpPtr, GetPtr(Y));
        }


        public uint LEcount(RetMatType Y)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_LE, mpPtr, GetPtr(Y));
        }


        public uint GEcount(RetMatType Y)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_GE, mpPtr, GetPtr(Y));
        }


        public uint EQcount(RetMatType Y)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_EQ, mpPtr, GetPtr(Y));
        }


        public uint NEcount(RetMatType Y)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), constants.mp_const_NE, mpPtr, GetPtr(Y));
        }


        #endregion



        #region Arithmetic Operators (BasicArithmetic)



        public RetMatType ConcatHorizontal(RetMatType x)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_concat_horizontal, mpPtr, GetPtr(x));
            return m1;
        }



        public RetMatType ConcatVertical(RetMatType x)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_concat_vertical, mpPtr, GetPtr(x));
            return m1;
        }




        public RetMatType CwiseProduct(RetMatType x)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_cwiseProduct, GetPtr(x), mpPtr);
            return m1;
        }




        public RetMatType DotProduct(RetMatType x)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_DotProduct, GetPtr(x), mpPtr);
            return m1;
        }




        public RetMatType CwiseQuotient(RetMatType x)
        {
            var m1 = new RetMatType();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_cwiseQuotient, GetPtr(x), mpPtr);
            return m1;
        }





        #endregion



        #region Multiple Results

        public RetMapType LDLT(string results, MatType B)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_ldlt, results, this, B);
            return res_map;
        }


        public RetMapType PartialPivLU(string results, MatType B)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_partialPivLu, results, this, B);
            return res_map;
        }


        public RetMapType FullPivLU(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_fullPivLu, results, this, b);
            return res_map;
        }


        public RetMapType LLT(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_llt, results, this, b);
            return res_map;
        }


        public RetMapType HouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_householderQr, results, this, b);
            return res_map;
        }


        public RetMapType ColPivHouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_colPivHouseholderQr, results, this, b);
            return res_map;
        }


        public RetMapType FullPivHouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_fullPivHouseholderQr, results, this, b);
            return res_map;
        }


        public RetMapType COD(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_COD, results, this, b);
            return res_map;
        }


        public RetMapType JacobiSVD(string results)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvd, results, this, this);
            return res_map;
        }


        public RetMapType JacobiSvdThin(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvdThin, results, this, b);
            return res_map;
        }


        public RetMapType JacobiSvdFull(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvdFull, results, this, b);
            return res_map;
        }


        public RetMapType Hessenberg(string results)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_hessenberg, results, this, this);
            return res_map;
        }


        public RetMapType Schur(string results)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_schur, results, this, this);
            return res_map;
        }


        public RetMapType Tridiag(string results)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_tridiag, results, this, this);
            return res_map;
        }


        public RetMapType SelfAdjointEigenValuesFromTridiag(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenValuesFromTridiag, results, this, b);
            return res_map;
        }


        public RetMapType SelfAdjointEigenSystemFromTridiag(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenSystemFromTridiag, results, this, b);
            return res_map;
        }


        public RetMapType SelfAdjointEigenValues(string results)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenValues, results, this, this);
            return res_map;
        }


        public RetMapType SelfAdjointEigenSystem(string results)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenSystem, results, this, this);
            return res_map;
        }


        public RetMapType GeneralizedSelfAdjointEigenValues(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_GeneralizedSelfAdjointEigenValues, results, this, b);
            return res_map;
        }


        public RetMapType GeneralizedSelfAdjointEigenSolver(string results, MatType b)
        {
            var res_map = new RetMapType();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_GeneralizedSelfAdjointEigenSolver, results, this, b);
            return res_map;
        }





        #endregion


    }



    public class SingleMatMap
    {

        public IntPtr mpPtr = IntPtr.Zero;

        private void Init()
        {
            xcn.Init();
            mpPtr = slib.Lib_Eigen_SReal_Init_Func(constants.mp_map, constants.mp_real);
        }


        public SingleMatMap()
        {
            Init();
        }


        ~SingleMatMap()
        {
            slib.Lib_Eigen_SReal_Clear(constants.mp_map, constants.mp_real, mpPtr);
        }


        public SingleMat this[string s]
        {
            get
            {
                var res = new SingleMat();
                slib.Lib_Eigen_SReal_Map_GetItemValue(constants.mp_eigen, constants.mp_real, res.mpPtr, mpPtr, s);
                return res;
            }
        }

    }






    public class SingleMat : SingleMatBase<Single, SingleMat, SingleMat, SingleMat, SingleMat, Single, SingleMatMap, SingleMatMapC>
    {


        #region Init

        public SingleMat()
        {
            Init();
        }

        private IntPtr GetPtr(dynamic x)
        {
            return (IntPtr)x.mpPtr;
        }

        ~SingleMat()
        {
            slib.Lib_Eigen_SReal_Clear(constants.mp_eigen, constants.mp_real, mpPtr);
        }


        public SingleSpMat ToSparse()
        {
            var res = new SingleSpMat();
            SLibSparse.EigenSparseLib_SReal_SparseFromDense(res.mpPtr, mpPtr);
            return res;
        }







        public override string ToString()
        {
            string res = "";
            var d1 = new Single();
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


        public Single this[int row_i, int col_j = 0]
        {
            get
            {
                var result = new Single();
                Eigen_SReal_GetCoeff(ref result, row_i, col_j, mpPtr);
                return result;
            }

            set
            {
                Eigen_SReal_SetCoeff(mpPtr, ref value, row_i, col_j);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_GetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_SReal_GetCoeff(ref Single result, int row, int col, IntPtr MatrixPtr_source);
        
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_SetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_SReal_SetCoeff(IntPtr MatrixPtr_result, ref Single in1, int row, int col);


        #endregion



        #region Arithmetic Comparisons (Compare)



        public static bool operator ==(SingleMat m1, SingleMat m2)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, constants.mp_real, constants.mp_const_EQ, m1.mpPtr, m2.mpPtr) == m1.size;
        }


        public static bool operator !=(SingleMat m1, SingleMat m2)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, constants.mp_real, constants.mp_const_NE, m1.mpPtr, m2.mpPtr) == m1.size;
        }




        #endregion



        #region Arithmetic Operators (BasicArithmetic)


        public static SingleMat operator +(SingleMat m1)
        {
            var one = sreal.t(1);
            return m1 * one;
        }


        public static SingleMat operator -(SingleMat m1)
        {
            var MinusOne = sreal.t(-1);
            return MinusOne * m1;
        }




        public static SingleMat operator +(SingleMat M1, SingleMat M2)
        {
            var Res = new SingleMat();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }




        public static SingleMat operator +(SingleMat M1, Single m2)
        {
            var Res = new SingleMat();
            var t = sreal.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static SingleMat operator +(Single m2, SingleMat M1)
        {
            var Res = new SingleMat();
            var t = sreal.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static SingleMatC operator +(SingleMat M1, SingleC m2)
        {
            var Res = new SingleMatC();
            Single x = m2.real;
            Single y = m2.imag;
            slib.Lib_Eigen_SReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }


        public static SingleMatC operator +(SingleMat m1, SingleMatC m2)
        {
            var m3 = new SingleMatC();
            var T1 = scplx.mat_t(m1);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_plus, T1.mpPtr, m2.mpPtr);
            return m3;
        }




        public static SingleMat operator -(SingleMat m1, SingleMat m2)
        {
            var m3 = new SingleMat();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }



        public static SingleMat operator -(SingleMat M1, Single m2)
        {
            var Res = new SingleMat();
            var t = sreal.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static SingleMat operator -(Single m2, SingleMat M1)
        {
            var Res = new SingleMat();
            var t = sreal.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, t.mpPtr);
            return -Res;
        }


        public static SingleMatC operator -(SingleMat M1, SingleC m2)
        {
            var Res = new SingleMatC();
            Single x = m2.real;
            Single y = m2.imag;
            slib.Lib_Eigen_SReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }


        public static SingleMatC operator -(SingleMat m1, SingleMatC m2)
        {
            var m3 = new SingleMatC();
            var T2 = scplx.mat_t(m1);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, T2.mpPtr, m2.mpPtr);
            return m3;
        }




        public static SingleMat operator *(SingleMat m1, SingleMat m2)
        {
            var m3 = new SingleMat();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static SingleMat operator *(SingleMat M1, Single m2)
        {
            var Res = new SingleMat();
            var t = sreal.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }




        public static SingleMat operator *(Single m2, SingleMat M1)
        {
            var Res = new SingleMat();
            var t = sreal.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }





        public static SingleMatC operator *(SingleMat M1, SingleC m2)
        {
            var Res = new SingleMatC();
            Single x = m2.real;
            Single y = m2.imag;
            slib.Lib_Eigen_SReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }


        public static SingleMatC operator *(SingleMat m1, SingleMatC m2)
        {
            var m3 = new SingleMatC();
            var T1 = scplx.mat_t(m1);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, T1.mpPtr, m2.mpPtr);
            return m3;
        }





        public static SingleMat operator /(SingleMat m1, SingleMat m2)
        {
            var m3 = new SingleMat();
            var m4 = m2.Inverse();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }


        public static SingleMat operator /(SingleMat M1, Single m2)
        {
            var Res = new SingleMat();
            var t = sreal.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        public static SingleMatC operator /(SingleMat M1, SingleC m2)
        {
            var Res = new SingleMatC();
            Single x = m2.real;
            Single y = m2.imag;
            slib.Lib_Eigen_SReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }



        #endregion



        #region Statistical Functions (Stats)


        public SingleMat sum(int PartialMode)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), constants.mp_const_sum, PartialMode, mpPtr);
            return m1;
        }



        public SingleMat prod(int PartialMode)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), constants.mp_const_prod, PartialMode, mpPtr);
            return m1;
        }



        public SingleMat mean(int PartialMode)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), constants.mp_const_mean, PartialMode, mpPtr);
            return m1;
        }



        public SingleMat minCoeff(int PartialMode)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), constants.mp_const_minCoeff, PartialMode, mpPtr);
            return m1;
        }



        public SingleMat maxCoeff(int PartialMode)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), constants.mp_const_maxCoeff, PartialMode, mpPtr);
            return m1;
        }



        public SingleMat squaredNorm(int PartialMode)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), constants.mp_const_squaredNorm, PartialMode, mpPtr);
            return m1;
        }



        public SingleMat Norm(int PartialMode)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), constants.mp_const_Norm, PartialMode, mpPtr);
            return m1;
        }



        public SingleMat stableNorm(int PartialMode)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), constants.mp_const_stableNorm, PartialMode, mpPtr);
            return m1;
        }


        #endregion



        #region Statistical Functions returning indices (Stats2)


        public SingleMat minCoeff_Index(ref int IndexX, ref int IndexY)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats2(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), ref IndexX, ref IndexY, constants.mp_const_minCoeff_Index, mpPtr);
            return m1;
        }


        public SingleMat maxCoeff_Index(ref int IndexX, ref int IndexY)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Stats2(constants.mp_eigen, slib.GetModuleIndex(typeof(sreal)), GetPtr(m1), ref IndexX, ref IndexY, constants.mp_const_maxCoeff_Index, mpPtr);
            return m1;
        }


        #endregion



        #region Det, Solve, Inverse


        public Single Det()
        {
            var res = PartialPivLU("det", this);
            return res["det"][(int)Math.Round(0.0)];
        }


        public SingleMat Solve(SingleMat B)
        {
            var res = PartialPivLU("x", B);
            return res["x"];
        }


        public SingleMat Inverse()
        {
            var res = PartialPivLU("inverse", this);
            return res["inverse"];
        }


        #endregion



        #region Sorting and Random




        public void Sort(int SortOrder, int SortCriterion)
        {
            slib.Lib_Eigen_SReal_Sort(constants.mp_real, mpPtr, SortOrder, SortCriterion);
        }


        public void SortRowsByCol(int ColumnToSortBy, int SortOrder, int SortCriterion)
        {
            slib.Lib_Eigen_SReal_SortRowsByColumn(constants.mp_real, mpPtr, ColumnToSortBy, SortOrder, SortCriterion);
        }


        // To be changed to remove nan and Inf
        public SingleMat SelectRows()
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_Select_Rows(constants.mp_real, m1.mpPtr, mpPtr);
            return m1;
        }



        #endregion




        #region Multiple Results


        public SingleMatMap RealQZ(string results, SingleMat b)
        {
            var res_map = new SingleMatMap();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(Single)), res_map, constants.mp_realQZ, results, this, b);
            return res_map;
        }


        public SingleMatMap PseudoEigenSystem(string results)
        {
            var res_map = new SingleMatMap();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(Single)), res_map, constants.mp_PseudoEigenSystem, results, this, this);
            return res_map;
        }



        public SingleMatMapC EigenValues(string results)
        {
            var res_map = new SingleMatMapC();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(SingleC)), res_map, constants.mp_EigenValuesFromRealInput, results, this, this);
            return res_map;
        }


        public SingleMatMapC EigenSystem(string results)
        {
            var res_map = new SingleMatMapC();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(SingleC)), res_map, constants.mp_EigenSystemFromRealInput, results, this, this);
            return res_map;
        }



        public SingleMatMapC GenEigenValues(string results, SingleMat B)
        {
            var res_map = new SingleMatMapC();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(SingleC)), res_map, constants.mp_EigenValuesFromRealInput, results, this, B);
            return res_map;
        }


        public SingleMatMapC GenEigenSystem(string results, SingleMat B)
        {
            var res_map = new SingleMatMapC();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(SingleC)), res_map, constants.mp_GeneralizedEigenSystemFromRealInput, results, this, B);
            return res_map;
        }



        #endregion






        #region Polynomials, Covariance



        public SingleMat Covariance(SingleMat Centered)
        {
            var m1 = new SingleMat();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m1.mpPtr, constants.mp_const_covariance, Centered.mpPtr, mpPtr);
            // Lib_Eigen_SReal_Real_Covariance(m1.mpPtr, Centered.mpPtr, mpPtr)
            return m1;
        }






        public SingleMat RootsToMonicPolynomial()
        {
            var m1 = new SingleMat();
            Lib_Eigen_SReal_Real_Roots_To_MonicPolynomial(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_Roots_To_MonicPolynomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_Roots_To_MonicPolynomial(IntPtr MatrixPtr_polynomial_result, IntPtr MatrixPtr_roots_source);



        public SingleMat PolyEval(SingleMat roots)
        {
            var m1 = new SingleMat();
            Lib_Eigen_SReal_Real_Poly_Eval(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_Poly_Eval", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_Poly_Eval(IntPtr MatrixPtr_evaluation_result, IntPtr MatrixPtr_polynomial_source, IntPtr MatrixPtr_roots_source);


        public SingleMatC PolyEval(SingleMatC roots)
        {
            var m1 = new SingleMatC();
            Lib_Eigen_SReal_Real_Poly_Eval_Complex(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_Poly_Eval_Complex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_Poly_Eval_Complex(IntPtr MatrixPtr_cplxevaluation_result, IntPtr MatrixPtr_realpolynomial_source, IntPtr MatrixPtr_cplxroots_source);


        public SingleMatC PolynomialSolver()
        {
            var m1 = new SingleMatC();
            Lib_Eigen_SReal_Real_PolynomialSolver(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_PolynomialSolver", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_PolynomialSolver(IntPtr MatrixPtr_cplxroots_result, IntPtr MatrixPtr_polynomial_source);




        #endregion



        #region MatrixFunctions


        public SingleMat ExpMat()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_exp, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_MatrixFunction", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_MatrixFunction(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_A);

        public SingleMat SinMat()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sin, mpPtr);
            return m3;
        }


        public SingleMat CosMat()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_cos, mpPtr);
            return m3;
        }


        public SingleMat SinhMat()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sinh, mpPtr);
            return m3;
        }


        public SingleMat CoshMat()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_cosh, mpPtr);
            return m3;
        }


        public SingleMat SqrtMat()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sqrt, mpPtr);
            return m3;
        }


        public SingleMat LogMat()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_log, mpPtr);
            return m3;
        }


        public SingleMat PowMat()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_pow, mpPtr);
            return m3;
        }



        #endregion



        #region FFT


        public SingleMatC FFTFwd()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Real_FFT_Real_Fwd(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_FFT_Real_Fwd", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_FFT_Real_Fwd(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);

        #endregion




    }





    public class SingleMatMapC
    {

        public IntPtr mpPtr = IntPtr.Zero;

        private void Init()
        {
            xcn.Init();
            mpPtr = slib.Lib_Eigen_SReal_Init_Func(constants.mp_map, constants.mp_cplx);
        }


        public SingleMatMapC()
        {
            Init();
        }


        ~SingleMatMapC()
        {
            slib.Lib_Eigen_SReal_Clear(constants.mp_map, constants.mp_cplx, mpPtr);
        }


        public SingleMatC this[string s]
        {
            get
            {
                var res = new SingleMatC();
                slib.Lib_Eigen_SReal_Map_GetItemValue(constants.mp_eigen, constants.mp_cplx, res.mpPtr, mpPtr, s);
                return res;
            }
        }

    }





    public class SingleMatC : SingleMatBase<SingleC, SingleMatC, SingleMat, SingleMatC, SingleMat, SingleC, SingleMatMapC, SingleMatMapC>
    {


        #region Init

        public SingleMatC()
        {
            Init();
        }


        private IntPtr GetPtr(dynamic x)
        {
            return (IntPtr)x.mpPtr;
        }


        ~SingleMatC()
        {
            slib.Lib_Eigen_SReal_Clear(constants.mp_eigen, constants.mp_cplx, mpPtr);
        }


        public SingleSpMatC ToSparse()
        {
            var res = new SingleSpMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_SparseFromDense(res.mpPtr, mpPtr);
            return res;
        }





        public override string ToString()
        {
            string res = "";
            var z1 = new SingleC();
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

        public SingleMat real
        {
            get
            {
                var m1 = new SingleMat();
                Lib_Eigen_SReal_ConvertRealCplx(GetPtr(m1), constants.mp_conv_get_from_complex_dbl, mpPtr);
                return m1;
            }

            set
            {
                Lib_Eigen_SReal_ConvertRealCplx(GetPtr(value), constants.mp_conv_set_to_complex_dbl, mpPtr);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_ConvertRealCplx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_ConvertRealCplx(IntPtr RMat, int what, IntPtr CMat);


        public SingleMat imag
        {
            get
            {
                var m1 = new SingleMat();
                Lib_Eigen_SReal_ConvertRealCplx(GetPtr(m1), constants.mp_conv_get_imag_from_complex_dbl, mpPtr);
                return m1;
            }

            set
            {
                Lib_Eigen_SReal_ConvertRealCplx(GetPtr(value), constants.mp_conv_set_imag_to_complex_dbl, mpPtr);
            }
        }

        #endregion



        #region Get and Set Coefficients


        public SingleC this[int row_i, int col_j = 0]
        {
            get
            {
                Single Re = new Single(), Im = new Single();
                Eigen_SCplx_GetCoeff2(ref Re, ref Im, row_i, col_j, mpPtr);
                return scplx.t(Re, Im);
            }

            set
            {
                Single x = value.real;
                Single y = value.imag;
                Eigen_SCplx_SetCoeff2(mpPtr, ref x, ref y, row_i, col_j);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Cplx_GetCoeff2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_SCplx_GetCoeff2(ref Single result1, ref Single result2, int row, int col, IntPtr MatrixPtr_source);

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Cplx_SetCoeff2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_SCplx_SetCoeff2(IntPtr MatrixPtr_result, ref Single source1, ref Single source2, int row, int col);
        #endregion



        #region Arithmetic Comparisons (Compare)


        public static bool operator ==(SingleMatC m1, SingleMatC m2)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, constants.mp_cplx, constants.mp_const_EQ, m1.mpPtr, m2.mpPtr) == m1.size;
        }


        public static bool operator !=(SingleMatC m1, SingleMatC m2)
        {
            return slib.Lib_Eigen_SReal_Compare(constants.mp_eigen, constants.mp_cplx, constants.mp_const_NE, m1.mpPtr, m2.mpPtr) == m1.size;
        }

        #endregion



        #region Arithmetic Operators (BasicArithmetic)


        public static SingleMatC operator +(SingleMatC m1)
        {
            var x = scplx.t("1", "0");
            return m1 * x;
        }


        public static SingleMatC operator -(SingleMatC m1)
        {
            var x = scplx.t("-1", "0");
            return m1 * x;
        }




        public static SingleMatC operator +(SingleMatC M1, SingleMatC M2)
        {
            var Res = new SingleMatC();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        public static SingleMatC operator +(SingleMatC m1, SingleMat m2)
        {
            var m3 = new SingleMatC();
            var T2 = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_plus, m1.mpPtr, T2.mpPtr);
            return m3;
        }





        public static SingleMatC operator +(SingleMatC M1, SingleC m2)
        {
            var Res = new SingleMatC();
            var t = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }







        public static SingleMatC operator -(SingleMatC m1, SingleMatC m2)
        {
            var m3 = new SingleMatC();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static SingleMatC operator -(SingleMatC m1, SingleMat m2)
        {
            var m3 = new SingleMatC();
            var T2 = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, T2.mpPtr);
            return m3;
        }


        public static SingleMatC operator -(SingleMatC M1, SingleC m2)
        {
            var Res = new SingleMatC();
            var t = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_minus, M1.mpPtr, t.mpPtr);
            return Res;
        }






        public static SingleMatC operator *(SingleMatC m1, SingleMatC m2)
        {
            var m3 = new SingleMatC();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static SingleMatC operator *(SingleMatC m1, SingleMat m2)
        {
            var m3 = new SingleMatC();
            var T2 = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, T2.mpPtr);
            return m3;
        }


        public static SingleMatC operator *(SingleMatC M1, SingleC m2)
        {
            var Res = new SingleMatC();
            var t = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        public static SingleMatC operator /(SingleMatC m1, SingleMatC m2)
        {
            var m3 = new SingleMatC();
            var m4 = new SingleMatC();
            m4 = m2.Inverse();
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }



        public static SingleMatC operator /(SingleMatC m1, SingleMat m2)
        {
            var m3 = new SingleMatC();
            var m4 = scplx.mat_t(m2.Inverse());
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }


        //public static SingleMatC operator /(SingleMat m1, SingleMatC m2)
        //{
        //    var m3 = new SingleMatC();
        //    var m4 = new SingleMatC();
        //    m4 = m2.Inverse();
        //    var T1 = scplx.mat_t(m1);
        //    slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, T1.mpPtr, m4.mpPtr);
        //    return m3;
        //}



        public static SingleMatC operator /(SingleMatC M1, SingleC m2)
        {
            var Res = new SingleMatC();
            var t = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        #endregion



        #region Det, Solve, Inverse


        public SingleC Det()
        {
            var res = PartialPivLU("det", this);
            return res["det"][(int)Math.Round(0.0)];
        }


        public SingleMatC Solve(SingleMatC b)
        {
            var res = PartialPivLU("x", b);
            return res["x"];
        }


        public SingleMatC Inverse()
        {
            var res = PartialPivLU("inverse", this);
            return res["inverse"];
        }


        #endregion



        #region Sorting and Random



        public void Sort(int SortOrder, int SortCriterion)
        {
            slib.Lib_Eigen_SReal_Sort(constants.mp_cplx, mpPtr, SortOrder, SortCriterion);
        }


        public void SortRowsByCol(int ColumnToSortBy, int SortOrder, int SortCriterion)
        {
            slib.Lib_Eigen_SReal_SortRowsByColumn(constants.mp_cplx, mpPtr, ColumnToSortBy, SortOrder, SortCriterion);
        }


        // To be changed to remove nan and Inf
        public SingleMatC SelectRows()
        {
            var m1 = new SingleMatC();
            slib.Lib_Eigen_SReal_Select_Rows(constants.mp_cplx, m1.mpPtr, mpPtr);
            return m1;
        }



        #endregion





        #region Polynomials

        public SingleMatC RootsToMonicPolynomial()
        {
            var m1 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_Roots_To_MonicPolynomial(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Cplx_Roots_To_MonicPolynomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Cplx_Roots_To_MonicPolynomial(IntPtr MatrixPtr_polynomial_result, IntPtr MatrixPtr_roots_source);



        public SingleMatC PolyEval(SingleMatC roots)
        {
            var m1 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_Poly_Eval_Complex(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Cplx_Poly_Eval_Complex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Cplx_Poly_Eval_Complex(IntPtr MatrixPtr_evaluation_result, IntPtr MatrixPtr_polynomial_source, IntPtr MatrixPtr_roots_source);



        public SingleMatC PolynomialSolver()
        {
            var m1 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_PolynomialSolver(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Cplx_PolynomialSolver", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Cplx_PolynomialSolver(IntPtr MatrixPtr_cplxroots_result, IntPtr MatrixPtr_polynomial_source);



        #endregion




        #region MatrixFunctions





        public SingleMatC ExpMat()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_exp, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Cplx_MatrixFunction", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Cplx_MatrixFunction(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_A);

        public SingleMatC SinMat()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sin, mpPtr);
            return m3;
        }


        public SingleMatC CosMat()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_cos, mpPtr);
            return m3;
        }


        public SingleMatC SinhMat()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sinh, mpPtr);
            return m3;
        }


        public SingleMatC CoshMat()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_cosh, mpPtr);
            return m3;
        }


        public SingleMatC SqrtMat()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sqrt, mpPtr);
            return m3;
        }


        public SingleMatC LogMat()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_log, mpPtr);
            return m3;
        }


        public SingleMatC PowMat()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_pow, mpPtr);
            return m3;
        }



        #endregion



        #region FFT


        public SingleMat FFTRealInv()
        {
            var m3 = new SingleMat();
            Lib_Eigen_SReal_Real_FFT_Real_Inv(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_FFT_Real_Inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_FFT_Real_Inv(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);


        public SingleMatC FFTFwd()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_FFT_Fwd(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Cplx_FFT_Fwd", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Cplx_FFT_Fwd(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);


        public SingleMatC FFTCplxInv()
        {
            var m3 = new SingleMatC();
            Lib_Eigen_SReal_Cplx_FFT_Inv(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Cplx_FFT_Inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Cplx_FFT_Inv(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);



        #endregion



        #region Multiple Results


        public SingleMatMapC EigenValues(string results)
        {
            var res_map = new SingleMatMapC();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(SingleC)), res_map, constants.mp_EigenValues, results, this, this);
            return res_map;
        }


        public SingleMatMapC EigenSystem(string results)
        {
            var res_map = new SingleMatMapC();
            slib.Call_Eigen_MultipleResults(constants.mp_eigen, slib.GetModuleIndex(typeof(SingleC)), res_map, constants.mp_EigenSystem, results, this, this);
            return res_map;
        }



        #endregion



    }




    internal static class SLibSparse
    {



        // *********************************************** Sparse Real**********************************************************



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_EigenSparse_SReal_Init_Func();


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Clear(IntPtr a);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_EigenSparse_SReal_GetInfo(int what, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_PrintSparseMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_PrintSparseMatrix(IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Get_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Put_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_SetSpecialValue(IntPtr MatrixPtr_result, int what, int m, int n);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_SetSpecialValue2(IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_BasicArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Stats", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Stats(IntPtr MatrixPtr_result, int what, int PartialMode, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_SReal_Solve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_SReal_Solve(IntPtr MatrixPtr_result, IntPtr MatrixPtr_A, IntPtr MatrixPtr_b, int Decomposition);



        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_SReal_DenseFromSparse", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_SReal_DenseFromSparse(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);


        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_SReal_SparseFromDense", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_SReal_SparseFromDense(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);









        // *********************************************** Sparse Complex*******************************************




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Cplx_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_EigenSparse_SReal_Cplx_Init_Func();


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Cplx_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Cplx_Clear(IntPtr a);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Cplx_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_EigenSparse_SReal_Cplx_GetInfo(int what, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Cplx_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Cplx_Get_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Cplx_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Cplx_Put_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Cplx_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Cplx_SetSpecialValue(IntPtr MatrixPtr_result, int what, int m, int n);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Cplx_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_SReal_Cplx_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_SReal_Cplx_BasicArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_SReal_Cplx_Solve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_SReal_Cplx_Solve(IntPtr MatrixPtr_result, IntPtr MatrixPtr_A, IntPtr MatrixPtr_b, int Decomposition);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_SReal_Cplx_DenseFromSparse", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_SReal_Cplx_DenseFromSparse(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_SReal_Cplx_SparseFromDense", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_SReal_Cplx_SparseFromDense(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);



    }




    public class SingleSpMat
    {

        public IntPtr mpPtr = IntPtr.Zero;


        #region Constructors

        private void Init()
        {
            xcn.Init();
            mpPtr = SLibSparse.Lib_EigenSparse_SReal_Init_Func();
        }



        private void Init(int m, int n = 1)
        {
            Init();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_Resize, m, n);
        }


        public SingleSpMat()
        {
            Init();
        }


        /// <summary>
        /// Create a new Matrix with m of rows and n columns.  
        /// </summary>
        /// <param name="m">Number of rows</param>
        /// <param name="n">Number of columns</param>
        public SingleSpMat(int m, int n)
        {
            Init(m, n);
        }


        // Public Sub New(x As Double)
        // Init()
        // Lib_EigenSparse_SReal_SetCoeff(mpPtr, x, 0, 0)
        // End Sub


        public SingleSpMat(SingleSpMat src)
        {
            Init();
            SLibSparse.Lib_EigenSparse_SReal_Put_Block(mpPtr, constants.mp_const_fullcopy, 0, 0, 0, 0, src.mpPtr);
        }


        public SingleSpMat(SingleMat src)
        {
            Init();
            SLibSparse.EigenSparseLib_SReal_SparseFromDense(mpPtr, src.mpPtr);
        }


        ~SingleSpMat()
        {
            SLibSparse.Lib_EigenSparse_SReal_Clear(mpPtr);
        }

        #endregion


        #region Input and Output


        public SingleMat ToDense()
        {
            var A = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_DenseFromSparse(A.mpPtr, mpPtr);
            return A;
        }

        public void Print(string Title, int digits = 6)
        {
            var A = ToDense();
            A.Print(Title, digits);
            // Lib_SReal_PrintSparseMatrix(mpPtr)
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
                return SLibSparse.Lib_EigenSparse_SReal_GetInfo(constants.mp_const_rows, mpPtr);
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
                return SLibSparse.Lib_EigenSparse_SReal_GetInfo(constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return SLibSparse.Lib_EigenSparse_SReal_GetInfo(constants.mp_const_size, mpPtr);
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
        public SingleSpMat get_block(int i, int j, int p, int q)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Get_Block(m1.mpPtr, constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_block(int i, int j, int p, int q, SingleSpMat value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Put_Block(mpPtr, constants.mp_const_block, i, j, p, q, value.mpPtr);
        }



        public SingleSpMat get_row(int i)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Get_Block(m1.mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_row(int i, SingleSpMat value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Put_Block(mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, value.mpPtr);
        }



        public SingleSpMat get_col(int j)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Get_Block(m1.mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_col(int j, SingleSpMat value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Put_Block(mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, value.mpPtr);
        }




        public SingleSpMat get_diagonal(int q = 0)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Get_Block(m1.mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_diagonal(int q, SingleSpMat value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Put_Block(mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, value.mpPtr);
        }




        public SingleSpMat get_triangularView(int View = 1)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Get_Block(m1.mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_triangularView(int View, SingleSpMat value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Put_Block(mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, value.mpPtr);
        }



        #endregion


        #region SetSpecialValue


        public void setZero(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_setZero, n, m);
        }



        public void setOnes(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_setOnes, n, m);
        }


        public void setIdentity(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_setIdentity, n, m);
        }


        public void resize(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_Resize, n, m);
        }


        public void conservative_resize(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_conservativeResize, n, m);
        }



        public void Random(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_setRandom_nm, n, m);
        }


        public void RandomSymmetric(int n)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_setRandomSymmetric, n, n);
        }



        public void FillLinear(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue(mpPtr, constants.mp_FillLinear, n, m);
        }


        #endregion





        #region SetSpecialValue2


        public void ResizeLike(SingleSpMat m1)
        {
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(mpPtr, constants.mp_ResizeLike, 0, 0, 0, m1.mpPtr);
        }


        public SingleSpMat asDiagonal()
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public SingleSpMat adjoint()
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public SingleSpMat conjugate()
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public SingleSpMat transpose()
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public SingleSpMat reverse_full()
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public SingleSpMat reverse_rowwise()
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public SingleSpMat reverse_colwise()
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public SingleSpMat replicate_full(int Vertical, int Horizontal)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public SingleSpMat replicate_rowwise(int Vertical)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public SingleSpMat replicate_colwise(int Horizontal)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
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




        public static SingleSpMat operator +(SingleSpMat M1, SingleSpMat M2)
        {
            var Res = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_BasicArithmetic(Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        // Public Shared Operator +(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_SReal_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator +(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_SReal_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
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




        public static SingleSpMat operator -(SingleSpMat m1, SingleSpMat m2)
        {
            var m3 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_BasicArithmetic(m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }



        // Public Shared Operator -(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_SReal_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_SReal_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
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



        public static SingleSpMat operator *(SingleSpMat m1, SingleSpMat m2)
        {
            var m3 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_BasicArithmetic(m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator *(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_SReal_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator *(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_SReal_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
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




        public SingleSpMat cwiseProduct(SingleSpMat x)
        {
            var m3 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseProduct(x As cplx_mat_t) As cplx_mat_t
        // Dim m3 As New cplx_mat_t()
        // Dim T1 As New cplx_mat_t(Me)
        // Lib_Eigen_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseProduct, T1.mpPtr, x.mpPtr)
        // Return m3
        // End Function



        public SingleSpMat dotProduct(SingleSpMat x)
        {
            var m3 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_BasicArithmetic(m3.mpPtr, constants.mp_const_DotProduct, x.mpPtr, mpPtr);
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
        // Lib_EigenSparse_SReal_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator /(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_SReal_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator /(ByVal M1 As dbl_spmat_t, ByVal m2 As Complex) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, T1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public SingleSpMat cwiseQuotient(SingleSpMat x)
        {
            var m3 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseQuotient, x.mpPtr, mpPtr);
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


        public SingleSpMat sum(int PartialMode)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Stats(m1.mpPtr, constants.mp_const_sum, PartialMode, mpPtr);
            return m1;
        }



        public SingleSpMat prod(int PartialMode)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Stats(m1.mpPtr, constants.mp_const_prod, PartialMode, mpPtr);
            return m1;
        }



        public SingleSpMat mean(int PartialMode)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Stats(m1.mpPtr, constants.mp_const_mean, PartialMode, mpPtr);
            return m1;
        }



        public SingleSpMat minCoeff(int PartialMode)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Stats(m1.mpPtr, constants.mp_const_minCoeff, PartialMode, mpPtr);
            return m1;
        }



        public SingleSpMat maxCoeff(int PartialMode)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Stats(m1.mpPtr, constants.mp_const_maxCoeff, PartialMode, mpPtr);
            return m1;
        }



        public SingleSpMat squaredNorm(int PartialMode)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Stats(m1.mpPtr, constants.mp_const_squaredNorm, PartialMode, mpPtr);
            return m1;
        }



        public SingleSpMat Norm(int PartialMode)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Stats(m1.mpPtr, constants.mp_const_Norm, PartialMode, mpPtr);
            return m1;
        }



        public SingleSpMat stableNorm(int PartialMode)
        {
            var m1 = new SingleSpMat();
            SLibSparse.Lib_EigenSparse_SReal_Stats(m1.mpPtr, constants.mp_const_stableNorm, PartialMode, mpPtr);
            return m1;
        }


        #endregion




        #region Solver

        public SingleMat solve(SingleMat b)
        {
            var x = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }


        public SingleMat SimplicialLLT_Solver(SingleMat b)
        {
            var x = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_llt);
            return x;
        }


        public SingleMat SimplicialLDLT_Solver(SingleMat b)
        {
            var x = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_ldlt);
            return x;
        }



        public SingleMat SparseLU_Solver(SingleMat b)
        {
            var x = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_lu);
            return x;
        }



        public SingleMat SparseQR_Solver(SingleMat b)
        {
            var x = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }



        public SingleMat ConjugateGradient_Solver(SingleMat b)
        {
            var x = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_CG_Solver);
            return x;
        }



        public SingleMat LeastSquaresConjugateGradient_Solver(SingleMat b)
        {
            var x = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_LSCG_Solver);
            return x;
        }



        public SingleMat BiCGSTAB_Solver(SingleMat b)
        {
            var x = new SingleMat();
            SLibSparse.EigenSparseLib_SReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_BiCGSTAB_Solver);
            return x;
        }


        #endregion


    }



    public class SingleSpMatC
    {

        internal IntPtr mpPtr = IntPtr.Zero;


        #region Constructors

        private void Init()
        {
            xcn.Init();
            mpPtr = SLibSparse.Lib_EigenSparse_SReal_Cplx_Init_Func();
        }


        public void Init(int m, int n = 1)
        {
            xcn.Init();
            // mpPtr = Lib_EigenSparse_SReal_Cplx_Init_Func()
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_Resize, m, n);
        }


        public SingleSpMatC()
        {
            Init();
        }


        /// <summary>
        /// Create a new Matrix with m of rows and n columns.  
        /// </summary>
        /// <param name="m">Number of rows</param>
        /// <param name="n">Number of columns</param>
        public SingleSpMatC(int m, int n = 1)
        {
            Init(m, n);
        }


        // Public Sub New(x As Complex)
        // mpPtr = Lib_EigenSparse_SReal_Cplx_Init_Func()
        // Lib_EigenSparse_SReal_Cplx_SetCoeff2Real(mpPtr, x.Real, x.Imaginary, 0, 0)
        // End Sub


        public SingleSpMatC(SingleSpMatC src)
        {
            Init();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Put_Block(mpPtr, constants.mp_const_fullcopy, 0, 0, 0, 0, src.mpPtr);
        }


        public SingleSpMatC(SingleMatC src)
        {
            Init();
            SLibSparse.EigenSparseLib_SReal_Cplx_SparseFromDense(mpPtr, src.mpPtr);
        }


        // Public Sub New(src As dbl_spmat_t)
        // Init(src.rows, src.cols)
        // Lib_Eigen_Set_Real_To_Complex_Dbl(mpPtr, src.mpPtr)
        // End Sub



        ~SingleSpMatC()
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Clear(mpPtr);
        }

        #endregion


        #region Input and Output


        public SingleMatC ToDense()
        {
            var A = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_DenseFromSparse(A.mpPtr, mpPtr);
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
        // Lib_EigenSparse_SReal_Cplx_GetCoeff2Real(res_re.mpPtr, res_im.mpPtr, row_i, col_j, mpPtr)
        // Return New Complex(res_re, res_im)
        // End Get
        // Set(ByVal m1 As Complex)
        // Lib_EigenSparse_SReal_Cplx_SetCoeff2Real(mpPtr, m1.Real, m1.Imaginary, row_i, col_j)
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
                return SLibSparse.Lib_EigenSparse_SReal_Cplx_GetInfo(constants.mp_const_rows, mpPtr);
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
                return SLibSparse.Lib_EigenSparse_SReal_Cplx_GetInfo(constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return SLibSparse.Lib_EigenSparse_SReal_Cplx_GetInfo(constants.mp_const_size, mpPtr);
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
        public SingleSpMatC get_block(int i, int j, int p, int q)
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_block(int i, int j, int p, int q, SingleSpMatC value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Put_Block(mpPtr, constants.mp_const_block, i, j, p, q, value.mpPtr);
        }



        public SingleSpMatC get_row(int i)
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_row(int i, SingleSpMatC value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Put_Block(mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, value.mpPtr);
        }



        public SingleSpMatC get_col(int j)
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_col(int j, SingleSpMatC value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Put_Block(mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, value.mpPtr);
        }




        public SingleSpMatC get_diagonal(int q = 0)
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_diagonal(int q, SingleSpMatC value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Put_Block(mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, value.mpPtr);
        }




        public SingleSpMatC get_triangularView(int View = 1)
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_triangularView(int View, SingleSpMatC value)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_Put_Block(mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, value.mpPtr);
        }



        #endregion


        #region SetSpecialValue




        public void setZero(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setZero, n, m);
        }



        public void setOnes(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setOnes, n, m);
        }


        public void setIdentity(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setIdentity, n, m);
        }



        public void resize(int rows, int cols)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_Resize, rows, cols);
        }



        public void conservative_resize(int rows, int cols)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_conservativeResize, rows, cols);
        }




        public void Random(int n, int m = 1)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandom_nm, n, m);
        }



        public void RandomSymmetric(int n)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandomSymmetric, n, n);
        }



        public void RandomHermitian(int n)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandomSA, n, n);
        }



        public void FillLinear(int n, int m)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue(mpPtr, constants.mp_FillLinear, n, m);
        }

        #endregion


        #region SetSpecialValue2


        public void ResizeLike(SingleSpMatC m1)
        {
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(mpPtr, constants.mp_ResizeLike, 0, 0, 0, m1.mpPtr);
        }


        public SingleSpMatC asDiagonal()
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public SingleSpMatC adjoint()
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public SingleSpMatC conjugate()
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public SingleSpMatC transpose()
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public SingleSpMatC reverse_full()
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public SingleSpMatC reverse_rowwise()
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public SingleSpMatC reverse_colwise()
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public SingleSpMatC replicate_full(int Vertical, int Horizontal)
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public SingleSpMatC replicate_rowwise(int Vertical)
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public SingleSpMatC replicate_colwise(int Horizontal)
        {
            var m1 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
            return m1;
        }

        #endregion


        #region Arithmetic Comparisons (Compare)


        // Public Shared Operator =(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As Boolean
        // Return (Lib_EigenSparse_SReal_Cplx_Compare(mp_const_EQ, m1.mpPtr, m2.mpPtr) = m1.Size)
        // End Operator
        // 
        // 
        // Public Shared Operator <>(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As Boolean
        // Return (Lib_EigenSparse_SReal_Cplx_Compare(mp_const_NE, m1.mpPtr, m2.mpPtr) = m1.Size)
        // End Operator

        #endregion


        #region Arithmetic Operators (BasicArithmetic)


        // Public Shared Operator +(ByVal m1 As cplx_spmat_t) As cplx_spmat_t
        // Return m1 + 0.0
        // End Operator


        // Public Shared Operator -(ByVal m1 As cplx_spmat_t) As cplx_spmat_t
        // Return (-1.0) * m1
        // End Operator




        public static SingleSpMatC operator +(SingleSpMatC M1, SingleSpMatC M2)
        {
            var Res = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_BasicArithmetic(Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        // Public Shared Operator +(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_plus, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator +(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_plus, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator +(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator +(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator





        public static SingleSpMatC operator -(SingleSpMatC m1, SingleSpMatC m2)
        {
            var m3 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator -(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_minus, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_minus, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator -(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return -Res
        // End Operator




        public static SingleSpMatC operator *(SingleSpMatC m1, SingleSpMatC m2)
        {
            var m3 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator *(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator *(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator *(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator *(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public SingleSpMatC cwiseProduct(SingleSpMatC x)
        {
            var m3 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseProduct(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseProduct, T1.mpPtr, mpPtr)
        // Return m3
        // End Function



        public SingleSpMatC dotProduct(SingleSpMatC x)
        {
            var m3 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_DotProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function dotProduct(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_DotProduct, mpPtr, T1.mpPtr)
        // Return m3
        // End Function




        // Public Shared Operator /(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t()
        // m4 = m2.inverse()
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator



        // Public Shared Operator /(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t(m2.inverse())
        // '        m4 = m2.inverse()
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator /(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t()
        // m4 = m2.inverse()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, T1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator



        // Public Shared Operator /(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public SingleSpMatC cwiseQuotient(SingleSpMatC x)
        {
            var m3 = new SingleSpMatC();
            SLibSparse.Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseQuotient, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseQuotient(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_SReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseQuotient, mpPtr, T1.mpPtr)
        // Return m3
        // End Function

        #endregion


        #region Solver

        public SingleMatC solve(SingleMatC b)
        {
            var x = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }


        public SingleMatC SimplicialLLT_Solver(SingleMatC b)
        {
            var x = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_llt);
            return x;
        }


        public SingleMatC SimplicialLDLT_Solver(SingleMatC b)
        {
            var x = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_ldlt);
            return x;
        }



        public SingleMatC SparseLU_Solver(SingleMatC b)
        {
            var x = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_lu);
            return x;
        }



        public SingleMatC SparseQR_Solver(SingleMatC b)
        {
            var x = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }



        public SingleMatC ConjugateGradient_Solver(SingleMatC b)
        {
            var x = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_CG_Solver);
            return x;
        }



        public SingleMatC LeastSquaresConjugateGradient_Solver(SingleMatC b)
        {
            var x = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_LSCG_Solver);
            return x;
        }



        public SingleMatC BiCGSTAB_Solver(SingleMatC b)
        {
            var x = new SingleMatC();
            SLibSparse.EigenSparseLib_SReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_BiCGSTAB_Solver);
            return x;
        }





        #endregion






    }





}