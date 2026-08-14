using System;
using System.Runtime.InteropServices;


namespace FixedPrecNet
{


    internal static class qlib
    {


        public static int GetModuleIndex(Type MyType)
        {
            // Dim Result As Int32 = mp_real
            int Result = 0; // = mp_cplx
            string s = MyType.Name;
            // Console.WriteLine("s: {0}", s)
            if (s.EndsWith("Quadruple"))
                Result = constants.mp_real;
            if (s.EndsWith("QuadrupleC"))
                Result = constants.mp_cplx;

            return Result;
        }



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_Eigen_QReal_Init_Func(int mpCat, int mpType);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Clear(int mpCat, int mpType, IntPtr AnyPtr);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_Eigen_QReal_GetInfo(int mpCat, int mpType, int what, IntPtr MatrixPtr_source);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Get_Block(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Put_Block(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_SetSpecialValue(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int m, int n);


        internal static void Call_Eigen_SetSpecialValue(int mpCat, int mpType, dynamic result, int what, int m, int n)
        {
            Lib_Eigen_QReal_SetSpecialValue(mpCat, mpType, (IntPtr)result.mpPtr, what, m, n);
        }




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_SetSpecialValue2(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Compare", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint Lib_Eigen_QReal_Compare(int mpCat, int mpType, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_BasicArithmetic(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_CplxScalarArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_CplxScalarArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr Y_re, IntPtr Y_im);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Stats", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Stats(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int PartialMode, IntPtr MatrixPtr_source);


        // !!! Needs to be modified to remove ByRef !!! Switch from Int32 to Fmpz
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Stats2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Stats2(int mpCat, int mpType, IntPtr MatrixPtr_result, ref int IndexX, ref int IndexY, int what, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Map_GetItemValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Map_GetItemValue(int mpCat, int mpType, IntPtr res_mpPtr, IntPtr mpPtr, string str);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_MultipleResults", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_MultipleResults(int mpCat, int mpType, IntPtr ResMap, int what, string str, IntPtr MatA, IntPtr MatB);

        internal static void Call_Eigen_MultipleResults(int mpCat, int mpType, dynamic ResMap, int what, string str, dynamic MatA, dynamic MatB)
        {
            Lib_Eigen_QReal_MultipleResults(mpCat, mpType, (IntPtr)ResMap.mpPtr, what, str, (IntPtr)MatA.mpPtr, (IntPtr)MatB.mpPtr);
        }




        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Sort", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Sort(int numType, IntPtr MatrixPtr_result_val, int SortOrder, int SortCriterion);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_SortRowsByColumn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_SortRowsByColumn(int numType, IntPtr MatrixPtr_result_val, int ColumnToSortBy, int SortOrder, int SortCriterion);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Select_Rows", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Select_Rows(int numType, IntPtr MatrixPtr_result_val, IntPtr MatrixPtr_source);




        #region MINPACK


        public static void testHybrj_ext(cbProc2Ptr F1, cbProc2Ptr F2, QuadrupleMat xMat, QuadrupleMat fvecMat, QuadrupleMat fjacMat, QuadrupleMat matInput)
        {
            Lib_Eigen_QReal_Real_testHybrj_ext(F1, F2, xMat.mpPtr, fvecMat.mpPtr, fjacMat.mpPtr, matInput.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_testHybrj_ext", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_testHybrj_ext(cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matFvecPtr, IntPtr matFjacPtr, IntPtr matInput);



        public static void testLmder_ext(cbProc2Ptr F1, cbProc2Ptr F2, QuadrupleMat xMat, QuadrupleMat fvecMat, QuadrupleMat fjacMat, QuadrupleMat matInput)
        {
            Lib_Eigen_QReal_Real_testLmder_ext(F1, F2, xMat.mpPtr, fvecMat.mpPtr, fjacMat.mpPtr, matInput.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_testLmder_ext", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_testLmder_ext(cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matFvecPtr, IntPtr matFjacPtr, IntPtr matInput);


        #endregion









    }




    public class QuadrupleMatBase<MyType, MatType, RealMatType, RetMatType, RetRealMatType, RetScalarType, RetMapType, RetCMapType>
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
            mpPtr = qlib.Lib_Eigen_QReal_Init_Func(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)));
        }


        public QuadrupleMatBase()
        {
            // Console.WriteLine("New: , MyMatType: {0} ", GetType(MyType))
        }

        #endregion



        #region Get Info

        public int rows
        {
            get
            {
                return qlib.Lib_Eigen_QReal_GetInfo(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_rows, mpPtr);
            }
        }


        public int cols
        {
            get
            {
                return qlib.Lib_Eigen_QReal_GetInfo(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return qlib.Lib_Eigen_QReal_GetInfo(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_size, mpPtr);
            }
        }

        #endregion





        #region Get and Set Blocks, Rows, Cols, Triangular ...

        public RetMatType get_Block(int i, int j, int p, int q)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_Get_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_Block(int i, int j, int p, int q, RetMatType value)
        {
            qlib.Lib_Eigen_QReal_Put_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_block, i, j, p, q, GetPtr(value));
        }



        public RetMatType get_Row(int i)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_Get_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_Row(int i, RetMatType value)
        {
            qlib.Lib_Eigen_QReal_Put_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, GetPtr(value));
        }



        public RetMatType get_Col(int j)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_Get_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_Col(int j, RetMatType value)
        {
            qlib.Lib_Eigen_QReal_Put_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, GetPtr(value));
        }




        public RetMatType get_Diagonal(int q = 0)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_Get_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_Diagonal(int q, RetMatType value)
        {
            qlib.Lib_Eigen_QReal_Put_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, GetPtr(value));
        }




        public RetMatType get_TriangularView(int View = 1)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_Get_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_TriangularView(int View, RetMatType value)
        {
            qlib.Lib_Eigen_QReal_Put_Block(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, GetPtr(value));
        }



        #endregion



        #region SetSpecialValue




        public void Resize(int n, int m)
        {
            qlib.Lib_Eigen_QReal_SetSpecialValue(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_Resize, n, m);
        }


        public void ConservativeResize(int n, int m)
        {
            qlib.Lib_Eigen_QReal_SetSpecialValue(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_conservativeResize, n, m);
        }




        #endregion



        #region SetSpecialValue2


        public void ResizeLike(RetMatType m1)
        {
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), mpPtr, constants.mp_ResizeLike, 0, 0, 0, GetPtr(m1));
        }


        public RetMatType AsDiagonal()
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Adjoint()
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Conjugate()
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public RetMatType Transpose()
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public RetMatType ReverseFull()
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public RetMatType ReverseRowwise()
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public RetMatType ReverseColwise()
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public RetMatType ReplicateFull(int Vertical, int Horizontal)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public RetMatType ReplicateRowwise(int Vertical)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public RetMatType ReplicateColwise(int Horizontal)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_SetSpecialValue2(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
            return m1;
        }

        #endregion



        #region Arithmetic Comparisons (Compare)

        public uint GTcount(RetMatType Y)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_GT, mpPtr, GetPtr(Y));
        }


        public uint LTcount(RetMatType Y)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_LT, mpPtr, GetPtr(Y));
        }


        public uint LEcount(RetMatType Y)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_LE, mpPtr, GetPtr(Y));
        }


        public uint GEcount(RetMatType Y)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_GE, mpPtr, GetPtr(Y));
        }


        public uint EQcount(RetMatType Y)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_EQ, mpPtr, GetPtr(Y));
        }


        public uint NEcount(RetMatType Y)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), constants.mp_const_NE, mpPtr, GetPtr(Y));
        }


        #endregion



        #region Arithmetic Operators (BasicArithmetic)



        public RetMatType ConcatHorizontal(RetMatType x)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_concat_horizontal, mpPtr, GetPtr(x));
            return m1;
        }



        public RetMatType ConcatVertical(RetMatType x)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_concat_vertical, mpPtr, GetPtr(x));
            return m1;
        }




        public RetMatType CwiseProduct(RetMatType x)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_cwiseProduct, GetPtr(x), mpPtr);
            return m1;
        }




        public RetMatType DotProduct(RetMatType x)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_DotProduct, GetPtr(x), mpPtr);
            return m1;
        }




        public RetMatType CwiseQuotient(RetMatType x)
        {
            var m1 = new RetMatType();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), GetPtr(m1), constants.mp_const_cwiseQuotient, GetPtr(x), mpPtr);
            return m1;
        }





        #endregion



        #region Multiple Results

        public RetMapType LDLT(string results, MatType B)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_ldlt, results, this, B);
            return res_map;
        }


        public RetMapType PartialPivLU(string results, MatType B)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_partialPivLu, results, this, B);
            return res_map;
        }


        public RetMapType FullPivLU(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_fullPivLu, results, this, b);
            return res_map;
        }


        public RetMapType LLT(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_llt, results, this, b);
            return res_map;
        }


        public RetMapType HouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_householderQr, results, this, b);
            return res_map;
        }


        public RetMapType ColPivHouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_colPivHouseholderQr, results, this, b);
            return res_map;
        }


        public RetMapType FullPivHouseholderQR(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_fullPivHouseholderQr, results, this, b);
            return res_map;
        }


        public RetMapType COD(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_COD, results, this, b);
            return res_map;
        }


        public RetMapType JacobiSVD(string results)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvd, results, this, this);
            return res_map;
        }


        public RetMapType JacobiSvdThin(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvdThin, results, this, b);
            return res_map;
        }


        public RetMapType JacobiSvdFull(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_jacobiSvdFull, results, this, b);
            return res_map;
        }


        public RetMapType Hessenberg(string results)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_hessenberg, results, this, this);
            return res_map;
        }


        public RetMapType Schur(string results)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_schur, results, this, this);
            return res_map;
        }


        public RetMapType Tridiag(string results)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_tridiag, results, this, this);
            return res_map;
        }


        public RetMapType SelfAdjointEigenValuesFromTridiag(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenValuesFromTridiag, results, this, b);
            return res_map;
        }


        public RetMapType SelfAdjointEigenSystemFromTridiag(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenSystemFromTridiag, results, this, b);
            return res_map;
        }


        public RetMapType SelfAdjointEigenValues(string results)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenValues, results, this, this);
            return res_map;
        }


        public RetMapType SelfAdjointEigenSystem(string results)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_SelfAdjointEigenSystem, results, this, this);
            return res_map;
        }


        public RetMapType GeneralizedSelfAdjointEigenValues(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_GeneralizedSelfAdjointEigenValues, results, this, b);
            return res_map;
        }


        public RetMapType GeneralizedSelfAdjointEigenSolver(string results, MatType b)
        {
            var res_map = new RetMapType();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(MyType)), res_map, constants.mp_GeneralizedSelfAdjointEigenSolver, results, this, b);
            return res_map;
        }





        #endregion


    }



    public class QuadrupleMatMap
    {

        public IntPtr mpPtr = IntPtr.Zero;

        private void Init()
        {
            xcn.Init();
            mpPtr = qlib.Lib_Eigen_QReal_Init_Func(constants.mp_map, constants.mp_real);
        }


        public QuadrupleMatMap()
        {
            Init();
        }


        ~QuadrupleMatMap()
        {
            qlib.Lib_Eigen_QReal_Clear(constants.mp_map, constants.mp_real, mpPtr);
        }


        public QuadrupleMat this[string s]
        {
            get
            {
                var res = new QuadrupleMat();
                qlib.Lib_Eigen_QReal_Map_GetItemValue(constants.mp_eigen, constants.mp_real, res.mpPtr, mpPtr, s);
                return res;
            }
        }

    }






    public class QuadrupleMat : QuadrupleMatBase<Quadruple, QuadrupleMat, QuadrupleMat, QuadrupleMat, QuadrupleMat, Quadruple, QuadrupleMatMap, QuadrupleMatMapC>
    {


        #region Init

        public QuadrupleMat()
        {
            Init();
        }

        private IntPtr GetPtr(dynamic x)
        {
            return (IntPtr)x.mpPtr;
        }

        ~QuadrupleMat()
        {
            qlib.Lib_Eigen_QReal_Clear(constants.mp_eigen, constants.mp_real, mpPtr);
        }


        public QuadrupleSpMat ToSparse()
        {
            var res = new QuadrupleSpMat();
            QLibSparse.EigenSparseLib_QReal_SparseFromDense(res.mpPtr, mpPtr);
            return res;
        }






        public override string ToString()
        {
            string res = "";
            var d1 = new Quadruple();
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


        public Quadruple this[int row_i, int col_j = 0]
        {
            get
            {
                var result = new Quadruple();
                Eigen_QReal_GetCoeff(result.mpPtr, row_i, col_j, mpPtr);
                return result;
            }

            set
            {
                Eigen_QReal_SetCoeff(mpPtr, value.mpPtr, row_i, col_j);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_GetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_QReal_GetCoeff(IntPtr result, int row, int col, IntPtr MatrixPtr_source);
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_SetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_QReal_SetCoeff(IntPtr MatrixPtr_result, IntPtr in1, int row, int col);


        #endregion



        #region Arithmetic Comparisons (Compare)



        public static bool operator ==(QuadrupleMat m1, QuadrupleMat m2)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, constants.mp_real, constants.mp_const_EQ, m1.mpPtr, m2.mpPtr) == m1.size;
        }


        public static bool operator !=(QuadrupleMat m1, QuadrupleMat m2)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, constants.mp_real, constants.mp_const_NE, m1.mpPtr, m2.mpPtr) == m1.size;
        }




        #endregion



        #region Arithmetic Operators (BasicArithmetic)


        public static QuadrupleMat operator +(QuadrupleMat m1)
        {
            var one = qreal.t(1);
            return m1 * one;
        }


        public static QuadrupleMat operator -(QuadrupleMat m1)
        {
            var MinusOne = qreal.t(-1);
            return MinusOne * m1;
        }




        public static QuadrupleMat operator +(QuadrupleMat M1, QuadrupleMat M2)
        {
            var Res = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }




        public static QuadrupleMat operator +(QuadrupleMat M1, Quadruple m2)
        {
            var Res = new QuadrupleMat();
            var t = qreal.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }


        public static QuadrupleMatC operator +(QuadrupleMat m1, QuadrupleMatC m2)
        {
            var m3 = new QuadrupleMatC();
            var T1 = qcplx.mat_t(m1);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_plus, T1.mpPtr, m2.mpPtr);
            return m3;
        }




        public static QuadrupleMat operator -(QuadrupleMat m1, QuadrupleMat m2)
        {
            var m3 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }



        public static QuadrupleMat operator -(QuadrupleMat M1, Quadruple m2)
        {
            var Res = new QuadrupleMat();
            var t = qreal.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }




        public static QuadrupleMatC operator -(QuadrupleMat M1, QuadrupleC m2)
        {
            var Res = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static QuadrupleMatC operator -(QuadrupleMat m1, QuadrupleMatC m2)
        {
            var m3 = new QuadrupleMatC();
            var T2 = qcplx.mat_t(m1);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, T2.mpPtr, m2.mpPtr);
            return m3;
        }







        public static QuadrupleMat operator *(QuadrupleMat m1, QuadrupleMat m2)
        {
            var m3 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static QuadrupleMat operator *(QuadrupleMat M1, Quadruple m2)
        {
            var Res = new QuadrupleMat();
            var t = qreal.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }




        public static QuadrupleMatC operator *(QuadrupleMat M1, QuadrupleC m2)
        {
            var Res = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static QuadrupleMatC operator *(QuadrupleMat m1, QuadrupleMatC m2)
        {
            var m3 = new QuadrupleMatC();
            var T2 = qcplx.mat_t(m1);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, T2.mpPtr, m2.mpPtr);
            return m3;
        }






        public static QuadrupleMat operator /(QuadrupleMat m1, QuadrupleMat m2)
        {
            var m3 = new QuadrupleMat();
            var m4 = m2.Inverse();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }


        public static QuadrupleMat operator /(QuadrupleMat M1, Quadruple m2)
        {
            var Res = new QuadrupleMat();
            var t = qreal.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        public static QuadrupleMatC operator /(QuadrupleMat M1, QuadrupleC m2)
        {
            var Res = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static QuadrupleMatC operator /(QuadrupleMat m1, QuadrupleMatC m2)
        {
            var m3 = new QuadrupleMatC();
            var m4 = new QuadrupleMatC();
            m4 = m2.Inverse();
            var T1 = qcplx.mat_t(m1);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, T1.mpPtr, m4.mpPtr);
            return m3;
        }



        #endregion



        #region Statistical Functions (Stats)


        public QuadrupleMat sum(int PartialMode)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), constants.mp_const_sum, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleMat prod(int PartialMode)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), constants.mp_const_prod, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleMat mean(int PartialMode)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), constants.mp_const_mean, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleMat minCoeff(int PartialMode)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), constants.mp_const_minCoeff, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleMat maxCoeff(int PartialMode)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), constants.mp_const_maxCoeff, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleMat squaredNorm(int PartialMode)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), constants.mp_const_squaredNorm, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleMat Norm(int PartialMode)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), constants.mp_const_Norm, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleMat stableNorm(int PartialMode)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), constants.mp_const_stableNorm, PartialMode, mpPtr);
            return m1;
        }


        #endregion



        #region Statistical Functions returning indices (Stats2)


        public QuadrupleMat minCoeff_Index(ref int IndexX, ref int IndexY)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats2(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), ref IndexX, ref IndexY, constants.mp_const_minCoeff_Index, mpPtr);
            return m1;
        }


        public QuadrupleMat maxCoeff_Index(ref int IndexX, ref int IndexY)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Stats2(constants.mp_eigen, qlib.GetModuleIndex(typeof(qreal)), GetPtr(m1), ref IndexX, ref IndexY, constants.mp_const_maxCoeff_Index, mpPtr);
            return m1;
        }


        #endregion



        #region Det, Solve, Inverse


        public Quadruple Det()
        {
            var res = PartialPivLU("det", this);
            return res["det"][(int)Math.Round(0.0)];
        }


        public QuadrupleMat Solve(QuadrupleMat B)
        {
            var res = PartialPivLU("x", B);
            return res["x"];
        }


        public QuadrupleMat Inverse()
        {
            var res = PartialPivLU("inverse", this);
            return res["inverse"];
        }


        #endregion



        #region Sorting and Random




        public void Sort(int SortOrder, int SortCriterion)
        {
            qlib.Lib_Eigen_QReal_Sort(constants.mp_real, mpPtr, SortOrder, SortCriterion);
        }


        public void SortRowsByCol(int ColumnToSortBy, int SortOrder, int SortCriterion)
        {
            qlib.Lib_Eigen_QReal_SortRowsByColumn(constants.mp_real, mpPtr, ColumnToSortBy, SortOrder, SortCriterion);
        }


        // To be changed to remove nan and Inf
        public QuadrupleMat SelectRows()
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_Select_Rows(constants.mp_real, m1.mpPtr, mpPtr);
            return m1;
        }



        #endregion




        #region Multiple Results


        public QuadrupleMatMap RealQZ(string results, QuadrupleMat b)
        {
            var res_map = new QuadrupleMatMap();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(Quadruple)), res_map, constants.mp_realQZ, results, this, b);
            return res_map;
        }


        public QuadrupleMatMap PseudoEigenSystem(string results)
        {
            var res_map = new QuadrupleMatMap();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(Quadruple)), res_map, constants.mp_PseudoEigenSystem, results, this, this);
            return res_map;
        }



        public QuadrupleMatMapC EigenValues(string results)
        {
            var res_map = new QuadrupleMatMapC();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(QuadrupleC)), res_map, constants.mp_EigenValuesFromRealInput, results, this, this);
            return res_map;
        }


        public QuadrupleMatMapC EigenSystem(string results)
        {
            var res_map = new QuadrupleMatMapC();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(QuadrupleC)), res_map, constants.mp_EigenSystemFromRealInput, results, this, this);
            return res_map;
        }



        public QuadrupleMatMapC GenEigenValues(string results, QuadrupleMat B)
        {
            var res_map = new QuadrupleMatMapC();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(QuadrupleC)), res_map, constants.mp_EigenValuesFromRealInput, results, this, B);
            return res_map;
        }


        public QuadrupleMatMapC GenEigenSystem(string results, QuadrupleMat B)
        {
            var res_map = new QuadrupleMatMapC();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(QuadrupleC)), res_map, constants.mp_GeneralizedEigenSystemFromRealInput, results, this, B);
            return res_map;
        }



        #endregion






        #region Polynomials, Covariance



        public QuadrupleMat Covariance(QuadrupleMat Centered)
        {
            var m1 = new QuadrupleMat();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, m1.mpPtr, constants.mp_const_covariance, Centered.mpPtr, mpPtr);
            // Lib_Eigen_QReal_Real_Covariance(m1.mpPtr, Centered.mpPtr, mpPtr)
            return m1;
        }






        public QuadrupleMat RootsToMonicPolynomial()
        {
            var m1 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_Roots_To_MonicPolynomial(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_Roots_To_MonicPolynomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_Roots_To_MonicPolynomial(IntPtr MatrixPtr_polynomial_result, IntPtr MatrixPtr_roots_source);



        public QuadrupleMat PolyEval(QuadrupleMat roots)
        {
            var m1 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_Poly_Eval(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_Poly_Eval", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_Poly_Eval(IntPtr MatrixPtr_evaluation_result, IntPtr MatrixPtr_polynomial_source, IntPtr MatrixPtr_roots_source);


        public QuadrupleMatC PolyEval(QuadrupleMatC roots)
        {
            var m1 = new QuadrupleMatC();
            Lib_Eigen_QReal_Real_Poly_Eval_Complex(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_Poly_Eval_Complex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_Poly_Eval_Complex(IntPtr MatrixPtr_cplxevaluation_result, IntPtr MatrixPtr_realpolynomial_source, IntPtr MatrixPtr_cplxroots_source);


        public QuadrupleMatC PolynomialSolver()
        {
            var m1 = new QuadrupleMatC();
            Lib_Eigen_QReal_Real_PolynomialSolver(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_PolynomialSolver", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_PolynomialSolver(IntPtr MatrixPtr_cplxroots_result, IntPtr MatrixPtr_polynomial_source);




        #endregion



        #region MatrixFunctions


        public QuadrupleMat ExpMat()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_exp, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_MatrixFunction", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_MatrixFunction(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_A);

        public QuadrupleMat SinMat()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sin, mpPtr);
            return m3;
        }


        public QuadrupleMat CosMat()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_cos, mpPtr);
            return m3;
        }


        public QuadrupleMat SinhMat()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sinh, mpPtr);
            return m3;
        }


        public QuadrupleMat CoshMat()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_cosh, mpPtr);
            return m3;
        }


        public QuadrupleMat SqrtMat()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_sqrt, mpPtr);
            return m3;
        }


        public QuadrupleMat LogMat()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_log, mpPtr);
            return m3;
        }


        public QuadrupleMat PowMat()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_MatrixFunction(m3.mpPtr, constants.mp_matrix_pow, mpPtr);
            return m3;
        }



        #endregion



        #region FFT


        public QuadrupleMatC FFTFwd()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Real_FFT_Real_Fwd(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_FFT_Real_Fwd", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_FFT_Real_Fwd(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);

        #endregion




    }





    public class QuadrupleMatMapC
    {

        public IntPtr mpPtr = IntPtr.Zero;

        private void Init()
        {
            xcn.Init();
            mpPtr = qlib.Lib_Eigen_QReal_Init_Func(constants.mp_map, constants.mp_cplx);
        }


        public QuadrupleMatMapC()
        {
            Init();
        }


        ~QuadrupleMatMapC()
        {
            qlib.Lib_Eigen_QReal_Clear(constants.mp_map, constants.mp_cplx, mpPtr);
        }


        public QuadrupleMatC this[string s]
        {
            get
            {
                var res = new QuadrupleMatC();
                qlib.Lib_Eigen_QReal_Map_GetItemValue(constants.mp_eigen, constants.mp_cplx, res.mpPtr, mpPtr, s);
                return res;
            }
        }

    }





    public class QuadrupleMatC : QuadrupleMatBase<QuadrupleC, QuadrupleMatC, QuadrupleMat, QuadrupleMatC, QuadrupleMat, QuadrupleC, QuadrupleMatMapC, QuadrupleMatMapC>
    {


        #region Init

        public QuadrupleMatC()
        {
            Init();
        }


        private IntPtr GetPtr(dynamic x)
        {
            return (IntPtr)x.mpPtr;
        }


        ~QuadrupleMatC()
        {
            qlib.Lib_Eigen_QReal_Clear(constants.mp_eigen, constants.mp_cplx, mpPtr);
        }


        public QuadrupleSpMatC ToSparse()
        {
            var res = new QuadrupleSpMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_SparseFromDense(res.mpPtr, mpPtr);
            return res;
        }





        public override string ToString()
        {
            string res = "";
            var z1 = new QuadrupleC();
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

        public QuadrupleMat real
        {
            get
            {
                var m1 = new QuadrupleMat();
                Lib_Eigen_QReal_ConvertRealCplx(GetPtr(m1), constants.mp_conv_get_from_complex_dbl, mpPtr);
                return m1;
            }

            set
            {
                Lib_Eigen_QReal_ConvertRealCplx(GetPtr(value), constants.mp_conv_set_to_complex_dbl, mpPtr);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_ConvertRealCplx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_ConvertRealCplx(IntPtr RMat, int what, IntPtr CMat);


        public QuadrupleMat imag
        {
            get
            {
                var m1 = new QuadrupleMat();
                Lib_Eigen_QReal_ConvertRealCplx(GetPtr(m1), constants.mp_conv_get_imag_from_complex_dbl, mpPtr);
                return m1;
            }

            set
            {
                Lib_Eigen_QReal_ConvertRealCplx(GetPtr(value), constants.mp_conv_set_imag_to_complex_dbl, mpPtr);
            }
        }

        #endregion



        #region Get and Set Coefficients


        public QuadrupleC this[int row_i, int col_j = 0]
        {
            get
            {
                Quadruple Re = new Quadruple(), Im = new Quadruple();
                Eigen_QCplx_GetCoeff2(Re.mpPtr, Im.mpPtr, row_i, col_j, mpPtr);
                return qcplx.t(Re, Im);
            }

            set
            {
                Eigen_QCplx_SetCoeff2(mpPtr, value.real.mpPtr, value.imag.mpPtr, row_i, col_j);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Cplx_GetCoeff2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_QCplx_GetCoeff2(IntPtr result1, IntPtr result2, int row, int col, IntPtr MatrixPtr_source);

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Cplx_SetCoeff2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_QCplx_SetCoeff2(IntPtr MatrixPtr_result, IntPtr source1, IntPtr source2, int row, int col);
        #endregion



        #region Arithmetic Comparisons (Compare)


        public static bool operator ==(QuadrupleMatC m1, QuadrupleMatC m2)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, constants.mp_cplx, constants.mp_const_EQ, m1.mpPtr, m2.mpPtr) == m1.size;
        }


        public static bool operator !=(QuadrupleMatC m1, QuadrupleMatC m2)
        {
            return qlib.Lib_Eigen_QReal_Compare(constants.mp_eigen, constants.mp_cplx, constants.mp_const_NE, m1.mpPtr, m2.mpPtr) == m1.size;
        }

        #endregion



        #region Arithmetic Operators (BasicArithmetic)


        public static QuadrupleMatC operator +(QuadrupleMatC m1)
        {
            var x = qcplx.t("1", "0");
            return m1 * x;
        }


        public static QuadrupleMatC operator -(QuadrupleMatC m1)
        {
            var x = qcplx.t("-1", "0");
            return x * m1;
        }




        public static QuadrupleMatC operator +(QuadrupleMatC M1, QuadrupleMatC M2)
        {
            var Res = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        public static QuadrupleMatC operator +(QuadrupleMatC m1, QuadrupleMat m2)
        {
            var m3 = new QuadrupleMatC();
            var T2 = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_plus, m1.mpPtr, T2.mpPtr);
            return m3;
        }



        public static QuadrupleMatC operator +(QuadrupleMatC M1, QuadrupleC m2)
        {
            var Res = new QuadrupleMatC();
            var t = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }





        public static QuadrupleMatC operator -(QuadrupleMatC m1, QuadrupleMatC m2)
        {
            var m3 = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static QuadrupleMatC operator -(QuadrupleMatC m1, QuadrupleMat m2)
        {
            var m3 = new QuadrupleMatC();
            var T2 = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_minus, m1.mpPtr, T2.mpPtr);
            return m3;
        }


        public static QuadrupleMatC operator -(QuadrupleMatC M1, QuadrupleC m2)
        {
            var Res = new QuadrupleMatC();
            var t = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_minus, M1.mpPtr, t.mpPtr);
            return Res;
        }




        public static QuadrupleMatC operator *(QuadrupleMatC m1, QuadrupleMatC m2)
        {
            var m3 = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        public static QuadrupleMatC operator *(QuadrupleMatC m1, QuadrupleMat m2)
        {
            var m3 = new QuadrupleMatC();
            var T2 = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, T2.mpPtr);
            return m3;
        }


        public static QuadrupleMatC operator *(QuadrupleMatC M1, QuadrupleC m2)
        {
            var Res = new QuadrupleMatC();
            var t = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        public static QuadrupleMatC operator /(QuadrupleMatC m1, QuadrupleMatC m2)
        {
            var m3 = new QuadrupleMatC();
            var m4 = new QuadrupleMatC();
            m4 = m2.Inverse();
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }



        public static QuadrupleMatC operator /(QuadrupleMatC m1, QuadrupleMat m2)
        {
            var m3 = new QuadrupleMatC();
            var m4 = qcplx.mat_t(m2.Inverse());
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr);
            return m3;
        }



        public static QuadrupleMatC operator /(QuadrupleMatC M1, QuadrupleC m2)
        {
            var Res = new QuadrupleMatC();
            var t = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_div_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }



        #endregion



        #region Det, Solve, Inverse


        public QuadrupleC Det()
        {
            var res = PartialPivLU("det", this);
            return res["det"][(int)Math.Round(0.0)];
        }


        public QuadrupleMatC Solve(QuadrupleMatC b)
        {
            var res = PartialPivLU("x", b);
            return res["x"];
        }


        public QuadrupleMatC Inverse()
        {
            var res = PartialPivLU("inverse", this);
            return res["inverse"];
        }


        #endregion



        #region Sorting and Random



        public void Sort(int SortOrder, int SortCriterion)
        {
            qlib.Lib_Eigen_QReal_Sort(constants.mp_cplx, mpPtr, SortOrder, SortCriterion);
        }


        public void SortRowsByCol(int ColumnToSortBy, int SortOrder, int SortCriterion)
        {
            qlib.Lib_Eigen_QReal_SortRowsByColumn(constants.mp_cplx, mpPtr, ColumnToSortBy, SortOrder, SortCriterion);
        }


        // To be changed to remove nan and Inf
        public QuadrupleMatC SelectRows()
        {
            var m1 = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_Select_Rows(constants.mp_cplx, m1.mpPtr, mpPtr);
            return m1;
        }



        #endregion





        #region Polynomials

        public QuadrupleMatC RootsToMonicPolynomial()
        {
            var m1 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_Roots_To_MonicPolynomial(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Cplx_Roots_To_MonicPolynomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Cplx_Roots_To_MonicPolynomial(IntPtr MatrixPtr_polynomial_result, IntPtr MatrixPtr_roots_source);



        public QuadrupleMatC PolyEval(QuadrupleMatC roots)
        {
            var m1 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_Poly_Eval_Complex(m1.mpPtr, mpPtr, roots.mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Cplx_Poly_Eval_Complex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Cplx_Poly_Eval_Complex(IntPtr MatrixPtr_evaluation_result, IntPtr MatrixPtr_polynomial_source, IntPtr MatrixPtr_roots_source);



        public QuadrupleMatC PolynomialSolver()
        {
            var m1 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_PolynomialSolver(m1.mpPtr, mpPtr);
            return m1;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Cplx_PolynomialSolver", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Cplx_PolynomialSolver(IntPtr MatrixPtr_cplxroots_result, IntPtr MatrixPtr_polynomial_source);



        #endregion




        #region MatrixFunctions





        public QuadrupleMatC ExpMat()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_exp, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Cplx_MatrixFunction", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Cplx_MatrixFunction(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_A);

        public QuadrupleMatC SinMat()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sin, mpPtr);
            return m3;
        }


        public QuadrupleMatC CosMat()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_cos, mpPtr);
            return m3;
        }


        public QuadrupleMatC SinhMat()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sinh, mpPtr);
            return m3;
        }


        public QuadrupleMatC CoshMat()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_cosh, mpPtr);
            return m3;
        }


        public QuadrupleMatC SqrtMat()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_sqrt, mpPtr);
            return m3;
        }


        public QuadrupleMatC LogMat()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_log, mpPtr);
            return m3;
        }


        public QuadrupleMatC PowMat()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_MatrixFunction(m3.mpPtr, constants.mp_matrix_pow, mpPtr);
            return m3;
        }



        #endregion



        #region FFT


        public QuadrupleMat FFTRealInv()
        {
            var m3 = new QuadrupleMat();
            Lib_Eigen_QReal_Real_FFT_Real_Inv(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_FFT_Real_Inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_FFT_Real_Inv(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);


        public QuadrupleMatC FFTFwd()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_FFT_Fwd(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Cplx_FFT_Fwd", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Cplx_FFT_Fwd(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);


        public QuadrupleMatC FFTCplxInv()
        {
            var m3 = new QuadrupleMatC();
            Lib_Eigen_QReal_Cplx_FFT_Inv(m3.mpPtr, mpPtr);
            return m3;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Cplx_FFT_Inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Cplx_FFT_Inv(IntPtr MatrixPtr_result, IntPtr MatrixPtr_source);



        #endregion



        #region Multiple Results


        public QuadrupleMatMapC EigenValues(string results)
        {
            var res_map = new QuadrupleMatMapC();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(QuadrupleC)), res_map, constants.mp_EigenValues, results, this, this);
            return res_map;
        }


        public QuadrupleMatMapC EigenSystem(string results)
        {
            var res_map = new QuadrupleMatMapC();
            qlib.Call_Eigen_MultipleResults(constants.mp_eigen, qlib.GetModuleIndex(typeof(QuadrupleC)), res_map, constants.mp_EigenSystem, results, this, this);
            return res_map;
        }



        #endregion



    }






    internal static class QLibSparse
    {



        // *********************************************** Sparse Real*********************************************



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_EigenSparse_QReal_Init_Func();


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Clear(IntPtr a);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_EigenSparse_QReal_GetInfo(int what, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_PrintSparseMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_PrintSparseMatrix(IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Get_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Put_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_SetSpecialValue(IntPtr MatrixPtr_result, int what, int m, int n);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_SetSpecialValue2(IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_BasicArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Stats", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Stats(IntPtr MatrixPtr_result, int what, int PartialMode, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_QReal_Solve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_QReal_Solve(IntPtr MatrixPtr_result, IntPtr MatrixPtr_A, IntPtr MatrixPtr_b, int Decomposition);



        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_QReal_DenseFromSparse", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_QReal_DenseFromSparse(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);


        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_QReal_SparseFromDense", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_QReal_SparseFromDense(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);








        // *********************************************** Sparse Complex*******************************************




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Cplx_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_EigenSparse_QReal_Cplx_Init_Func();


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Cplx_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Cplx_Clear(IntPtr a);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Cplx_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_EigenSparse_QReal_Cplx_GetInfo(int what, IntPtr MatrixPtr_source);




        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Cplx_Get_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Cplx_Get_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Cplx_Put_Block", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Cplx_Put_Block(IntPtr MatrixPtr_result, int what, int i, int j, int p, int q, IntPtr MatrixPtr_source);


        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Cplx_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Cplx_SetSpecialValue(IntPtr MatrixPtr_result, int what, int m, int n);



        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Cplx_SetSpecialValue2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(IntPtr MatrixPtr_result, int what, int Vertical, int Horizontal, int PartialMode, IntPtr MatrixPtr_source);





        [DllImport(xcn.mpNum, EntryPoint = "Lib_EigenSparse_QReal_Cplx_BasicArithmetic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_EigenSparse_QReal_Cplx_BasicArithmetic(IntPtr MatrixPtr_result, int what, IntPtr MatrixPtr_X, IntPtr MatrixPtr_Y);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_QReal_Cplx_Solve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_QReal_Cplx_Solve(IntPtr MatrixPtr_result, IntPtr MatrixPtr_A, IntPtr MatrixPtr_b, int Decomposition);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_QReal_Cplx_DenseFromSparse", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_QReal_Cplx_DenseFromSparse(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);




        [DllImport(xcn.mpNum, EntryPoint = "EigenSparseLib_QReal_Cplx_SparseFromDense", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void EigenSparseLib_QReal_Cplx_SparseFromDense(IntPtr MatrixPtr_result, IntPtr MatrixPtr_X);



    }





    public class QuadrupleSpMat
    {

        public IntPtr mpPtr = IntPtr.Zero;


        #region Constructors

        private void Init()
        {
            xcn.Init();
            mpPtr = QLibSparse.Lib_EigenSparse_QReal_Init_Func();
        }



        private void Init(int m, int n = 1)
        {
            Init();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_Resize, m, n);
        }


        public QuadrupleSpMat()
        {
            Init();
        }


        /// <summary>
        /// Create a new Matrix with m of rows and n columns.  
        /// </summary>
        /// <param name="m">Number of rows</param>
        /// <param name="n">Number of columns</param>
        public QuadrupleSpMat(int m, int n)
        {
            Init(m, n);
        }


        // Public Sub New(x As Double)
        // Init()
        // Lib_EigenSparse_QReal_SetCoeff(mpPtr, x, 0, 0)
        // End Sub


        public QuadrupleSpMat(QuadrupleSpMat src)
        {
            Init();
            QLibSparse.Lib_EigenSparse_QReal_Put_Block(mpPtr, constants.mp_const_fullcopy, 0, 0, 0, 0, src.mpPtr);
        }


        public QuadrupleSpMat(QuadrupleMat src)
        {
            Init();
            QLibSparse.EigenSparseLib_QReal_SparseFromDense(mpPtr, src.mpPtr);
        }


        ~QuadrupleSpMat()
        {
            QLibSparse.Lib_EigenSparse_QReal_Clear(mpPtr);
        }

        #endregion


        #region Input and Output


        public QuadrupleMat ToDense()
        {
            var A = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_DenseFromSparse(A.mpPtr, mpPtr);
            return A;
        }

        public void Print(string Title, int digits = 6)
        {
            var A = ToDense();
            A.Print(Title, digits);
            // Lib_QReal_PrintSparseMatrix(mpPtr)
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
                return QLibSparse.Lib_EigenSparse_QReal_GetInfo(constants.mp_const_rows, mpPtr);
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
                return QLibSparse.Lib_EigenSparse_QReal_GetInfo(constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return QLibSparse.Lib_EigenSparse_QReal_GetInfo(constants.mp_const_size, mpPtr);
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
        public QuadrupleSpMat get_block(int i, int j, int p, int q)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Get_Block(m1.mpPtr, constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_block(int i, int j, int p, int q, QuadrupleSpMat value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Put_Block(mpPtr, constants.mp_const_block, i, j, p, q, value.mpPtr);
        }



        public QuadrupleSpMat get_row(int i)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Get_Block(m1.mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_row(int i, QuadrupleSpMat value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Put_Block(mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, value.mpPtr);
        }



        public QuadrupleSpMat get_col(int j)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Get_Block(m1.mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_col(int j, QuadrupleSpMat value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Put_Block(mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, value.mpPtr);
        }




        public QuadrupleSpMat get_diagonal(int q = 0)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Get_Block(m1.mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_diagonal(int q, QuadrupleSpMat value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Put_Block(mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, value.mpPtr);
        }




        public QuadrupleSpMat get_triangularView(int View = 1)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Get_Block(m1.mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_triangularView(int View, QuadrupleSpMat value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Put_Block(mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, value.mpPtr);
        }



        #endregion


        #region SetSpecialValue


        public void setZero(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_setZero, n, m);
        }



        public void setOnes(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_setOnes, n, m);
        }


        public void setIdentity(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_setIdentity, n, m);
        }


        public void resize(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_Resize, n, m);
        }


        public void conservative_resize(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_conservativeResize, n, m);
        }



        public void Random(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_setRandom_nm, n, m);
        }


        public void RandomSymmetric(int n)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_setRandomSymmetric, n, n);
        }



        public void FillLinear(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue(mpPtr, constants.mp_FillLinear, n, m);
        }


        #endregion





        #region SetSpecialValue2


        public void ResizeLike(QuadrupleSpMat m1)
        {
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(mpPtr, constants.mp_ResizeLike, 0, 0, 0, m1.mpPtr);
        }


        public QuadrupleSpMat asDiagonal()
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public QuadrupleSpMat adjoint()
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public QuadrupleSpMat conjugate()
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public QuadrupleSpMat transpose()
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public QuadrupleSpMat reverse_full()
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public QuadrupleSpMat reverse_rowwise()
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public QuadrupleSpMat reverse_colwise()
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public QuadrupleSpMat replicate_full(int Vertical, int Horizontal)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public QuadrupleSpMat replicate_rowwise(int Vertical)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public QuadrupleSpMat replicate_colwise(int Horizontal)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
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




        public static QuadrupleSpMat operator +(QuadrupleSpMat M1, QuadrupleSpMat M2)
        {
            var Res = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_BasicArithmetic(Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        // Public Shared Operator +(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_QReal_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator +(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_QReal_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
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




        public static QuadrupleSpMat operator -(QuadrupleSpMat m1, QuadrupleSpMat m2)
        {
            var m3 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_BasicArithmetic(m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }



        // Public Shared Operator -(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_QReal_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_QReal_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
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



        public static QuadrupleSpMat operator *(QuadrupleSpMat m1, QuadrupleSpMat m2)
        {
            var m3 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_BasicArithmetic(m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator *(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_QReal_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator *(ByVal m2 As Double, ByVal M1 As dbl_spmat_t) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_QReal_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
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




        public QuadrupleSpMat cwiseProduct(QuadrupleSpMat x)
        {
            var m3 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseProduct(x As cplx_mat_t) As cplx_mat_t
        // Dim m3 As New cplx_mat_t()
        // Dim T1 As New cplx_mat_t(Me)
        // Lib_Eigen_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseProduct, T1.mpPtr, x.mpPtr)
        // Return m3
        // End Function



        public QuadrupleSpMat dotProduct(QuadrupleSpMat x)
        {
            var m3 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_BasicArithmetic(m3.mpPtr, constants.mp_const_DotProduct, x.mpPtr, mpPtr);
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
        // Lib_EigenSparse_QReal_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator /(ByVal M1 As dbl_spmat_t, ByVal m2 As Double) As dbl_spmat_t
        // Dim Res As New dbl_spmat_t()
        // Dim t As New dbl_spmat_t(m2)
        // Lib_EigenSparse_QReal_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator


        // Public Shared Operator /(ByVal M1 As dbl_spmat_t, ByVal m2 As Complex) As cplx_mat_t
        // Dim Res As New cplx_mat_t()
        // Dim t As New cplx_mat_t(m2)
        // Dim T1 As New cplx_mat_t(M1)
        // Lib_Eigen_Cplx_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, T1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public QuadrupleSpMat cwiseQuotient(QuadrupleSpMat x)
        {
            var m3 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseQuotient, x.mpPtr, mpPtr);
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


        public QuadrupleSpMat sum(int PartialMode)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Stats(m1.mpPtr, constants.mp_const_sum, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleSpMat prod(int PartialMode)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Stats(m1.mpPtr, constants.mp_const_prod, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleSpMat mean(int PartialMode)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Stats(m1.mpPtr, constants.mp_const_mean, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleSpMat minCoeff(int PartialMode)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Stats(m1.mpPtr, constants.mp_const_minCoeff, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleSpMat maxCoeff(int PartialMode)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Stats(m1.mpPtr, constants.mp_const_maxCoeff, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleSpMat squaredNorm(int PartialMode)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Stats(m1.mpPtr, constants.mp_const_squaredNorm, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleSpMat Norm(int PartialMode)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Stats(m1.mpPtr, constants.mp_const_Norm, PartialMode, mpPtr);
            return m1;
        }



        public QuadrupleSpMat stableNorm(int PartialMode)
        {
            var m1 = new QuadrupleSpMat();
            QLibSparse.Lib_EigenSparse_QReal_Stats(m1.mpPtr, constants.mp_const_stableNorm, PartialMode, mpPtr);
            return m1;
        }


        #endregion




        #region Solver

        public QuadrupleMat solve(QuadrupleMat b)
        {
            var x = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }


        public QuadrupleMat SimplicialLLT_Solver(QuadrupleMat b)
        {
            var x = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_llt);
            return x;
        }


        public QuadrupleMat SimplicialLDLT_Solver(QuadrupleMat b)
        {
            var x = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_ldlt);
            return x;
        }



        public QuadrupleMat SparseLU_Solver(QuadrupleMat b)
        {
            var x = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_lu);
            return x;
        }



        public QuadrupleMat SparseQR_Solver(QuadrupleMat b)
        {
            var x = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }



        public QuadrupleMat ConjugateGradient_Solver(QuadrupleMat b)
        {
            var x = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_CG_Solver);
            return x;
        }



        public QuadrupleMat LeastSquaresConjugateGradient_Solver(QuadrupleMat b)
        {
            var x = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_LSCG_Solver);
            return x;
        }



        public QuadrupleMat BiCGSTAB_Solver(QuadrupleMat b)
        {
            var x = new QuadrupleMat();
            QLibSparse.EigenSparseLib_QReal_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_BiCGSTAB_Solver);
            return x;
        }


        #endregion


    }





    public class QuadrupleSpMatC
    {

        internal IntPtr mpPtr = IntPtr.Zero;


        #region Constructors

        private void Init()
        {
            xcn.Init();
            mpPtr = QLibSparse.Lib_EigenSparse_QReal_Cplx_Init_Func();
        }


        public void Init(int m, int n = 1)
        {
            xcn.Init();
            // mpPtr = Lib_EigenSparse_QReal_Cplx_Init_Func()
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_Resize, m, n);
        }


        public QuadrupleSpMatC()
        {
            Init();
        }


        /// <summary>
        /// Create a new Matrix with m of rows and n columns.  
        /// </summary>
        /// <param name="m">Number of rows</param>
        /// <param name="n">Number of columns</param>
        public QuadrupleSpMatC(int m, int n = 1)
        {
            Init(m, n);
        }


        // Public Sub New(x As Complex)
        // mpPtr = Lib_EigenSparse_QReal_Cplx_Init_Func()
        // Lib_EigenSparse_QReal_Cplx_SetCoeff2Real(mpPtr, x.Real, x.Imaginary, 0, 0)
        // End Sub


        public QuadrupleSpMatC(QuadrupleSpMatC src)
        {
            Init();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Put_Block(mpPtr, constants.mp_const_fullcopy, 0, 0, 0, 0, src.mpPtr);
        }


        public QuadrupleSpMatC(QuadrupleMatC src)
        {
            Init();
            QLibSparse.EigenSparseLib_QReal_Cplx_SparseFromDense(mpPtr, src.mpPtr);
        }


        // Public Sub New(src As dbl_spmat_t)
        // Init(src.rows, src.cols)
        // Lib_Eigen_Set_Real_To_Complex_Dbl(mpPtr, src.mpPtr)
        // End Sub



        ~QuadrupleSpMatC()
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Clear(mpPtr);
        }

        #endregion


        #region Input and Output


        public QuadrupleMatC ToDense()
        {
            var A = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_DenseFromSparse(A.mpPtr, mpPtr);
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
        // Lib_EigenSparse_QReal_Cplx_GetCoeff2Real(res_re.mpPtr, res_im.mpPtr, row_i, col_j, mpPtr)
        // Return New Complex(res_re, res_im)
        // End Get
        // Set(ByVal m1 As Complex)
        // Lib_EigenSparse_QReal_Cplx_SetCoeff2Real(mpPtr, m1.Real, m1.Imaginary, row_i, col_j)
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
                return QLibSparse.Lib_EigenSparse_QReal_Cplx_GetInfo(constants.mp_const_rows, mpPtr);
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
                return QLibSparse.Lib_EigenSparse_QReal_Cplx_GetInfo(constants.mp_const_cols, mpPtr);
            }
        }


        public int size
        {
            get
            {
                return QLibSparse.Lib_EigenSparse_QReal_Cplx_GetInfo(constants.mp_const_size, mpPtr);
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
        public QuadrupleSpMatC get_block(int i, int j, int p, int q)
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_block, i, j, p, q, mpPtr);
            return m1;
        }

        public void set_block(int i, int j, int p, int q, QuadrupleSpMatC value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Put_Block(mpPtr, constants.mp_const_block, i, j, p, q, value.mpPtr);
        }



        public QuadrupleSpMatC get_row(int i)
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, mpPtr);
            return m1;
        }

        public void set_row(int i, QuadrupleSpMatC value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Put_Block(mpPtr, constants.mp_const_middleRows, 0, 0, i, 1, value.mpPtr);
        }



        public QuadrupleSpMatC get_col(int j)
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, mpPtr);
            return m1;
        }

        public void set_col(int j, QuadrupleSpMatC value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Put_Block(mpPtr, constants.mp_const_middleCols, 0, 0, j, 1, value.mpPtr);
        }




        public QuadrupleSpMatC get_diagonal(int q = 0)
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, mpPtr);
            return m1;
        }

        public void set_diagonal(int q, QuadrupleSpMatC value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Put_Block(mpPtr, constants.mp_const_diagonal, 0, 0, 0, q, value.mpPtr);
        }




        public QuadrupleSpMatC get_triangularView(int View = 1)
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Get_Block(m1.mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, mpPtr);
            return m1;
        }

        public void set_triangularView(int View, QuadrupleSpMatC value)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_Put_Block(mpPtr, constants.mp_const_triangularView, 0, 0, 0, View, value.mpPtr);
        }



        #endregion


        #region SetSpecialValue




        public void setZero(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setZero, n, m);
        }



        public void setOnes(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setOnes, n, m);
        }


        public void setIdentity(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setIdentity, n, m);
        }



        public void resize(int rows, int cols)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_Resize, rows, cols);
        }



        public void conservative_resize(int rows, int cols)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_conservativeResize, rows, cols);
        }




        public void Random(int n, int m = 1)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandom_nm, n, m);
        }



        public void RandomSymmetric(int n)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandomSymmetric, n, n);
        }



        public void RandomHermitian(int n)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_setRandomSA, n, n);
        }



        public void FillLinear(int n, int m)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue(mpPtr, constants.mp_FillLinear, n, m);
        }

        #endregion


        #region SetSpecialValue2


        public void ResizeLike(QuadrupleSpMatC m1)
        {
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(mpPtr, constants.mp_ResizeLike, 0, 0, 0, m1.mpPtr);
        }


        public QuadrupleSpMatC asDiagonal()
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_asDiagonal, 0, 0, 0, mpPtr);
            return m1;
        }


        public QuadrupleSpMatC adjoint()
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_adjoint, 0, 0, 0, mpPtr);
            return m1;
        }


        public QuadrupleSpMatC conjugate()
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_conjugate, 0, 0, 0, mpPtr);
            return m1;
        }


        public QuadrupleSpMatC transpose()
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_transpose, 0, 0, 0, mpPtr);
            return m1;
        }



        public QuadrupleSpMatC reverse_full()
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public QuadrupleSpMatC reverse_rowwise()
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public QuadrupleSpMatC reverse_colwise()
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_reverse, 0, 0, constants.mp_const_colwise, mpPtr);
            return m1;
        }


        public QuadrupleSpMatC replicate_full(int Vertical, int Horizontal)
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, Horizontal, constants.mp_const_full_matrix, mpPtr);
            return m1;
        }


        public QuadrupleSpMatC replicate_rowwise(int Vertical)
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, Vertical, 0, constants.mp_const_rowwise, mpPtr);
            return m1;
        }


        public QuadrupleSpMatC replicate_colwise(int Horizontal)
        {
            var m1 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_SetSpecialValue2(m1.mpPtr, constants.mp_replicate, 0, Horizontal, constants.mp_const_colwise, mpPtr);
            return m1;
        }

        #endregion


        #region Arithmetic Comparisons (Compare)


        // Public Shared Operator =(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As Boolean
        // Return (Lib_EigenSparse_QReal_Cplx_Compare(mp_const_EQ, m1.mpPtr, m2.mpPtr) = m1.Size)
        // End Operator
        // 
        // 
        // Public Shared Operator <>(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As Boolean
        // Return (Lib_EigenSparse_QReal_Cplx_Compare(mp_const_NE, m1.mpPtr, m2.mpPtr) = m1.Size)
        // End Operator

        #endregion


        #region Arithmetic Operators (BasicArithmetic)


        // Public Shared Operator +(ByVal m1 As cplx_spmat_t) As cplx_spmat_t
        // Return m1 + 0.0
        // End Operator


        // Public Shared Operator -(ByVal m1 As cplx_spmat_t) As cplx_spmat_t
        // Return (-1.0) * m1
        // End Operator




        public static QuadrupleSpMatC operator +(QuadrupleSpMatC M1, QuadrupleSpMatC M2)
        {
            var Res = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_BasicArithmetic(Res.mpPtr, constants.mp_const_plus, M1.mpPtr, M2.mpPtr);
            return Res;
        }


        // Public Shared Operator +(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_plus, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator +(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_plus, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator +(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator +(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_plus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator





        public static QuadrupleSpMatC operator -(QuadrupleSpMatC m1, QuadrupleSpMatC m2)
        {
            var m3 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_minus, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator -(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_minus, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_minus, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator -(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator -(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_minus_scalar, M1.mpPtr, t.mpPtr)
        // Return -Res
        // End Operator




        public static QuadrupleSpMatC operator *(QuadrupleSpMatC m1, QuadrupleSpMatC m2)
        {
            var m3 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_MatrixProduct, m1.mpPtr, m2.mpPtr);
            return m3;
        }


        // Public Shared Operator *(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T2 As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, T2.mpPtr)
        // Return m3
        // End Operator
        // 
        // 
        // Public Shared Operator *(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, T1.mpPtr, m2.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator *(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator
        // 
        // 
        // Public Shared Operator *(ByVal m2 As Complex, ByVal M1 As cplx_spmat_t) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_times_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public QuadrupleSpMatC cwiseProduct(QuadrupleSpMatC x)
        {
            var m3 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseProduct(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseProduct, T1.mpPtr, mpPtr)
        // Return m3
        // End Function



        public QuadrupleSpMatC dotProduct(QuadrupleSpMatC x)
        {
            var m3 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_DotProduct, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function dotProduct(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_DotProduct, mpPtr, T1.mpPtr)
        // Return m3
        // End Function




        // Public Shared Operator /(ByVal m1 As cplx_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t()
        // m4 = m2.inverse()
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator



        // Public Shared Operator /(ByVal m1 As cplx_spmat_t, ByVal m2 As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t(m2.inverse())
        // '        m4 = m2.inverse()
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, m1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator


        // Public Shared Operator /(ByVal m1 As dbl_spmat_t, ByVal m2 As cplx_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim m4 As New cplx_spmat_t()
        // m4 = m2.inverse()
        // Dim T1 As New cplx_spmat_t(m1)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_MatrixProduct, T1.mpPtr, m4.mpPtr)
        // Return m3
        // End Operator



        // Public Shared Operator /(ByVal M1 As cplx_spmat_t, ByVal m2 As Complex) As cplx_spmat_t
        // Dim Res As New cplx_spmat_t()
        // Dim t As New cplx_spmat_t(m2)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(Res.mpPtr, mp_const_div_scalar, M1.mpPtr, t.mpPtr)
        // Return Res
        // End Operator



        public QuadrupleSpMatC cwiseQuotient(QuadrupleSpMatC x)
        {
            var m3 = new QuadrupleSpMatC();
            QLibSparse.Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, constants.mp_const_cwiseQuotient, x.mpPtr, mpPtr);
            return m3;
        }


        // Public Function cwiseQuotient(x As dbl_spmat_t) As cplx_spmat_t
        // Dim m3 As New cplx_spmat_t()
        // Dim T1 As New cplx_spmat_t(x)
        // Lib_EigenSparse_QReal_Cplx_BasicArithmetic(m3.mpPtr, mp_const_cwiseQuotient, mpPtr, T1.mpPtr)
        // Return m3
        // End Function

        #endregion


        #region Solver

        public QuadrupleMatC solve(QuadrupleMatC b)
        {
            var x = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }


        public QuadrupleMatC SimplicialLLT_Solver(QuadrupleMatC b)
        {
            var x = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_llt);
            return x;
        }


        public QuadrupleMatC SimplicialLDLT_Solver(QuadrupleMatC b)
        {
            var x = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_ldlt);
            return x;
        }



        public QuadrupleMatC SparseLU_Solver(QuadrupleMatC b)
        {
            var x = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_lu);
            return x;
        }



        public QuadrupleMatC SparseQR_Solver(QuadrupleMatC b)
        {
            var x = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_householderQr);
            return x;
        }



        public QuadrupleMatC ConjugateGradient_Solver(QuadrupleMatC b)
        {
            var x = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_CG_Solver);
            return x;
        }



        public QuadrupleMatC LeastSquaresConjugateGradient_Solver(QuadrupleMatC b)
        {
            var x = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_LSCG_Solver);
            return x;
        }



        public QuadrupleMatC BiCGSTAB_Solver(QuadrupleMatC b)
        {
            var x = new QuadrupleMatC();
            QLibSparse.EigenSparseLib_QReal_Cplx_Solve(x.mpPtr, mpPtr, b.mpPtr, constants.mp_BiCGSTAB_Solver);
            return x;
        }





        #endregion






    }








}