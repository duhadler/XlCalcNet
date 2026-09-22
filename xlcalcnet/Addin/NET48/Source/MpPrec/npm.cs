using System;



namespace FixedPrecNet
{



    /// <summary>
    /// Represents a mp_numpy_array
    /// </summary>
    public class mp_numpy_array
    {
    }






    public class npm
    {


        public static String fmt(dynamic z)
        {
            return "fmt(t(z))";
        }




        #region 7.1 Numpy array creation from shape or value



        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/eye/*' />
        public static mp_numpy_array eye(string PyStr = "N, M=None, k=0, dtype=<class 'float'>, order='C', *, device=None, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/identity/*' />
        public static mp_numpy_array identity(string PyStr = "n, dtype=None, *, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/ones/*' />
        public static mp_numpy_array ones(string PyStr = "shape, dtype=None, order='C', *, device=None, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/ones_like/*' />
        public static mp_numpy_array ones_like(string PyStr = "a, dtype=None, order='K', subok=True, shape=None, *, device=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/zeros/*' />
        public static mp_numpy_array zeros(string PyStr = "shape, dtype=float, order='C', *, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/zeros_like/*' />
        public static mp_numpy_array zeros_like(string PyStr = "a, dtype=None, order='K', subok=True, shape=None, *, device=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/full/*' />
        public static mp_numpy_array full(string PyStr = "shape, fill_value, dtype=None, order='C', *, device=None, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/full_like/*' />
        public static mp_numpy_array full_like(string PyStr = "a, fill_value, dtype=None, order='K', subok=True, shape=None, *, device=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/tri/*' />
        public static mp_numpy_array tri(string PyStr = "N, M=None, k=0, dtype=<class 'float'>, *, like=None")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.2 Numpy array creation from existing data


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/array/*' />
        public static mp_numpy_array array(string PyStr="object, dtype=None, *, copy=True, order='K', subok=False, ndmin=0, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/asarray/*' />
        public static mp_numpy_array asarray(string PyStr = "a, dtype=None, order=None, *, device=None, copy=None, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/asanyarray/*' />
        public static mp_numpy_array asanyarray(string PyStr = "a, dtype=None, order=None, *, device=None, copy=None, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/fromfile/*' />
        public static mp_numpy_array fromfile(string PyStr = "file, dtype=float, count=-1, sep='', offset=0, *, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/fromfunction/*' />
        public static mp_numpy_array fromfunction(string PyStr = "function, shape, *, dtype=<class 'float'>, like=None, **kwargs")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/fromiter/*' />
        public static mp_numpy_array fromiter(string PyStr = "iter, dtype, count=-1, *, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/fromstring/*' />
        public static mp_numpy_array fromstring(string PyStr = "string, dtype=float, count=-1, *, sep, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/loadtxt/*' />
        public static mp_numpy_array loadtxt(string PyStr = "fname, dtype=<class 'float'>, comments='#', delimiter=None, converters=None, skiprows=0, usecols=None, unpack=False, ndmin=0, encoding=None, max_rows=None, *, quotechar=None, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/genfromtxt/*' />
        public static mp_numpy_array genfromtxt(string PyStr = "fname, dtype=<class 'float'>, comments='#', delimiter=None, skip_header=0, skip_footer=0, converters=None, missing_values=None, filling_values=None, usecols=None, names=None, excludelist=None, deletechars=\" !#$%&'()*+, -./:;<=>?@[\\\\]^{|}~\", replace_space='_', autostrip=False, case_sensitive=True, defaultfmt='f%i', unpack=None, usemask=False, loose=True, invalid_raise=True, max_rows=None, encoding=None, *, ndmin=0, like=None")
        {
            return new mp_numpy_array();
        }



        #endregion




        #region 7.3 Building special arrays for numerical work


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/arange/*' />
        public static mp_numpy_array arange(string PyStr = "[start, ]stop, [step, ]dtype=None, *, device=None, like=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/linspace/*' />
        public static mp_numpy_array linspace(string PyStr = "start, stop, num=50, endpoint=True, retstep=False, dtype=None, axis=0, *, device=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/logspace/*' />
        public static mp_numpy_array logspace(string PyStr = "start, stop, num=50, endpoint=True, base=10.0, dtype=None, axis=0")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/geomspace/*' />
        public static mp_numpy_array geomspace(string PyStr = "start, stop, num=50, endpoint=True, dtype=None, axis=0")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/diag/*' />
        public static mp_numpy_array diag(string PyStr = "v, k=0")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/diagonal/*' />
        public static mp_numpy_array diagonal(string PyStr = "a, offset=0, axis1=0, axis2=1")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/diagflat/*' />
        public static mp_numpy_array diagflat(string PyStr = "v, k=0")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/tril/*' />
        public static mp_numpy_array tril(string PyStr = "m, k=0")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/triu/*' />
        public static mp_numpy_array triu(string PyStr = "m, k=0")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/vander/*' />
        public static mp_numpy_array vander(string PyStr = "x, N=None, increasing=False")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.4 Numpy indexing



        #endregion




        #region 7.5 Numpy basic array manipulation routines


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/copyto/*' />
        public static mp_numpy_array copyto(string PyStr = "dst, src, casting='same_kind', where=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/shape/*' />
        public static mp_numpy_array shape(string PyStr = "a")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/reshape/*' />
        public static mp_numpy_array reshape(string PyStr = "a, \u2215, shape=None, order='C', *, newshape=None, copy=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/ravel/*' />
        public static mp_numpy_array ravel(string PyStr = "a, order='C'")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/flat/*' />
        public static mp_numpy_array flat(string PyStr = "")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/flatten/*' />
        public static mp_numpy_array flatten(string PyStr = "order='C'")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.6 Numpy array manipulation: Transpose-like operations


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/moveaxis/*' />
        public static mp_numpy_array moveaxis(string PyStr = "a, source, destination")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/swapaxes/*' />
        public static mp_numpy_array swapaxes(string PyStr = "a, axis1, axis2")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/transpose/*' />
        public static mp_numpy_array transpose(string PyStr = "a, axes=None")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.7 Numpy array manipulation: Changing number of dimensions


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/atleast_1d/*' />
        public static mp_numpy_array atleast_1d(string PyStr = "*arys")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/atleast_2d/*' />
        public static mp_numpy_array atleast_2d(string PyStr = "*arys")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/atleast_3d/*' />
        public static mp_numpy_array atleast_3d(string PyStr = "*arys")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/broadcast_to/*' />
        public static mp_numpy_array broadcast_to(string PyStr = "array, shape, subok=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/broadcast_arrays/*' />
        public static mp_numpy_array broadcast_arrays(string PyStr = "*args, subok=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/expand_dims/*' />
        public static mp_numpy_array expand_dims(string PyStr = "a, axis")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/squeeze/*' />
        public static mp_numpy_array squeeze(string PyStr = "a, axis=None")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.8 Numpy array manipulation: Joining arrays


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/concatenate/*' />
        public static mp_numpy_array concatenate(string PyStr = "(a1, a2, ...), axis=0, out=None, dtype=None, casting=\"same_kind\"")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/stack/*' />
        public static mp_numpy_array stack(string PyStr = "arrays, axis=0, out=None, *, dtype=None, casting='same_kind'")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/block/*' />
        public static mp_numpy_array block(string PyStr = "arrays")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/vstack/*' />
        public static mp_numpy_array vstack(string PyStr = "tup, *, dtype=None, casting='same_kind'")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/hstack/*' />
        public static mp_numpy_array hstack(string PyStr = "tup, *, dtype=None, casting='same_kind'")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/dstack/*' />
        public static mp_numpy_array dstack(string PyStr = "tup")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/column_stack/*' />
        public static mp_numpy_array column_stack(string PyStr = "tup")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.9 Numpy array manipulation: Splitting and tiling arrays


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/split/*' />
        public static mp_numpy_array split(string PyStr = "ary, indices_or_sections, axis=0")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/array_split/*' />
        public static mp_numpy_array array_split(string PyStr = "ary, indices_or_sections, axis=0")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/dsplit/*' />
        public static mp_numpy_array dsplit(string PyStr = "ary, indices_or_sections")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/hsplit/*' />
        public static mp_numpy_array hsplit(string PyStr = "ary, indices_or_sections")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/vsplit/*' />
        public static mp_numpy_array vsplit(string PyStr = "ary, indices_or_sections")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/tile/*' />
        public static mp_numpy_array tile(string PyStr = "A, reps")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/repeat/*' />
        public static mp_numpy_array repeat(string PyStr = "a, repeats, axis=None")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.10 Numpy array manipulation: Adding and removing elements


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/pad/*' />
        public static mp_numpy_array pad(string PyStr = "array, pad_width, mode='constant', **kwargs")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/delete/*' />
        public static mp_numpy_array delete(string PyStr = "arr, obj, axis=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/insert/*' />
        public static mp_numpy_array insert(string PyStr = "arr, obj, values, axis=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/append/*' />
        public static mp_numpy_array append(string PyStr = "arr, values, axis=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/trim_zeros/*' />
        public static mp_numpy_array trim_zeros(string PyStr = "filt, trim='fb', axis=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/unique/*' />
        public static mp_numpy_array unique(string PyStr = "ar, return_index=False, return_inverse=False, return_counts=False, axis=None, *, equal_nan=True")
        {
            return new mp_numpy_array();
        }

        #endregion




        #region 7.11 Numpy array manipulation: Rearranging elements


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/flip/*' />
        public static mp_numpy_array flip(string PyStr = "m, axis=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/fliplr/*' />
        public static mp_numpy_array fliplr(string PyStr = "m")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/flipud/*' />
        public static mp_numpy_array flipud(string PyStr = "m")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/roll/*' />
        public static mp_numpy_array roll(string PyStr = "a, shift, axis=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/rot90/*' />
        public static mp_numpy_array rot90(string PyStr = "m, k=1, axes=(0, 1)")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.12 Numpy array manipulation: Sorting


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/sort/*' />
        public static mp_numpy_array sort(string PyStr = "a, axis=-1, kind=None, order=None, *, stable=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/lexsort/*' />
        public static mp_numpy_array lexsort(string PyStr = "keys, axis=-1")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/argsort/*' />
        public static mp_numpy_array argsort(string PyStr = "a, axis=-1, kind=None, order=None, *, stable=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/take_along_axis/*' />
        public static mp_numpy_array take_along_axis(string PyStr = "arr, indices, axis=-1")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/sort_complex/*' />
        public static mp_numpy_array sort_complex(string PyStr = "a, axis=-1, kind=None, order=None, *, stable=None")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.13 Numpy array manipulation: Searching


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/argmax/*' />
        public static mp_numpy_array argmax(string PyStr = "a, axis=None, out=None, *, keepdims=<no value>")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/argmin/*' />
        public static mp_numpy_array argmin(string PyStr = "a, axis=None, out=None, *, keepdims=<no value>")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/argwhere/*' />
        public static mp_numpy_array argwhere(string PyStr = "a")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/nonzero/*' />
        public static mp_numpy_array nonzero(string PyStr = "a")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/where/*' />
        public static mp_numpy_array where(string PyStr = "condition, [x, y, ]/")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/select/*' />
        public static mp_numpy_array select(string PyStr = "condlist, choicelist, default=0")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.14 Numpy mathematical functions: Sums, products, differences


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/prod/*' />
        public static mp_numpy_array prod(string PyStr = "a, axis=None, dtype=None, out=None, keepdims=<no value>, initial=<no value>, where=<no value>")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/sum/*' />
        public static mp_numpy_array sum(string PyStr = "a, axis=None, dtype=None, out=None, keepdims=<no value>, initial=<no value>, where=<no value>")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/cumprod/*' />
        public static mp_numpy_array cumprod(string PyStr = "a, axis=None, dtype=None, out=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/cumsum/*' />
        public static mp_numpy_array cumsum(string PyStr = "a, axis=None, dtype=None, out=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/diff/*' />
        public static mp_numpy_array diff(string PyStr = "a, n=1, axis=-1, prepend=<no value>, append=<no value>")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/ediff1d/*' />
        public static mp_numpy_array ediff1d(string PyStr = "ary, to_end=None, to_begin=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/gradient/*' />
        public static mp_numpy_array gradient(string PyStr = "f, *varargs, axis=None, edge_order=1")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/trapezoid/*' />
        public static mp_numpy_array trapezoid(string PyStr = "y, x=None, dx=1.0, axis=-1")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.15 Numpy mathematical functions: Extrema Finding


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/maximum/*' />
        public static mp_numpy_array maximum(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/minimum/*' />
        public static mp_numpy_array minimum(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/max/*' />
        public static mp_numpy_array max(string PyStr = "a, axis=None, out=None, keepdims=<no value>, initial=<no value>, where=<no value>")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/min/*' />
        public static mp_numpy_array min(string PyStr = "a, axis=None, out=None, keepdims=<no value>, initial=<no value>, where=<no value>")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.16 Numpy mathematical functions: Arithmetic operations, elementwise


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/positive/*' />
        public static mp_numpy_array positive(string PyStr = "x, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }
        

        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/negative/*' />
        public static mp_numpy_array negative(string PyStr = "x, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/add/*' />
        public static mp_numpy_array add(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/subtract/*' />
        public static mp_numpy_array subtract(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/multiply/*' />
        public static mp_numpy_array multiply(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/divide/*' />
        public static mp_numpy_array divide(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/floor_divide/*' />
        public static mp_numpy_array floor_divide(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/remainder/*' />
        public static mp_numpy_array remainder(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/square/*' />
        public static mp_numpy_array square(string PyStr = "x, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/reciprocal/*' />
        public static mp_numpy_array reciprocal(string PyStr = "x, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.17 Numpy mathematical functions: Averages and variances


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/median/*' />
        public static mp_numpy_array median(string PyStr = "a, axis=None, out=None, overwrite_input=False, keepdims=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/average/*' />
        public static mp_numpy_array average(string PyStr = "a, axis=None, weights=None, returned=False, *, keepdims=<no value>")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/mean/*' />
        public static mp_numpy_array mean(string PyStr = "a, axis=None, dtype=None, out=None, keepdims=<no value>, *, where=<no value>")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/var/*' />
        public static mp_numpy_array var(string PyStr = "a, axis=None, dtype=None, out=None, ddof=0, keepdims=<no value>, *, where=<no value>, mean=<no value>, correction=<no value>")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.18 Numpy mathematical functions: Matrix and vector products


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/dot/*' />
        public static mp_numpy_array dot(string PyStr = "a, b, out=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/vdot/*' />
        public static mp_numpy_array vdot(string PyStr = "a, b, \u2215")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/inner/*' />
        public static mp_numpy_array inner(string PyStr = "a, b, \u2215")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/outer/*' />
        public static mp_numpy_array outer(string PyStr = "a, b, out=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/matmul/*' />
        public static mp_numpy_array matmul(string PyStr = "x1, x2, \u2215, out=None, *, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/tensordot/*' />
        public static mp_numpy_array tensordot(string PyStr = "a, b, axes=2")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/einsum/*' />
        public static mp_numpy_array einsum(string PyStr = "subscripts, *operands, out=None, dtype=None, order='K', casting='safe', optimize=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/kron/*' />
        public static mp_numpy_array kron(string PyStr = "a, b")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/convolve/*' />
        public static mp_numpy_array convolve(string PyStr = "a, v, mode='full'")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.19 Numpy logical functions: Truth value testing


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/all/*' />
        public static Boolean all(string PyStr = "a, axis=None, out=None, keepdims=<no value>, *, where=<no value>")
        {
            return new Boolean();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/any/*' />
        public static Boolean any(string PyStr = "a, axis=None, out=None, keepdims=<no value>, *, where=<no value>")
        {
            return new Boolean();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/logical_and/*' />
        public static mp_numpy_array logical_and(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/logical_or/*' />
        public static mp_numpy_array logical_or(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/logical_xor/*' />
        public static mp_numpy_array logical_xor(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/array_equal/*' />
        public static Boolean array_equal(string PyStr = "a1, a2, equal_nan=False")
        {
            return new Boolean();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/array_equiv/*' />
        public static Boolean array_equiv(string PyStr = "a1, a2")
        {
            return new Boolean();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/greater/*' />
        public static mp_numpy_array greater(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/greater_equal/*' />
        public static mp_numpy_array greater_equal(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/less/*' />
        public static mp_numpy_array less(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/less_equal/*' />
        public static mp_numpy_array less_equal(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/equal/*' />
        public static mp_numpy_array equal(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/not_equal/*' />
        public static mp_numpy_array not_equal(string PyStr = "x1, x2, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.20 Numpy mathematical functions: Integer and fractional


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/floor/*' />
        public static mp_numpy_array floor(string PyStr = "x, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/ceil/*' />
        public static mp_numpy_array ceil(string PyStr = "x, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/trunc/*' />
        public static mp_numpy_array trunc(string PyStr = "x, \u2215, out=None, *, where=True, casting='same_kind', order='K', dtype=None, subok=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/fix/*' />
        public static mp_numpy_array fix(string PyStr = "x, out=None")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.21 Numpy mathematical functions: Miscellaneous


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/vectorize/*' />
        public static mp_numpy_array vectorize(string PyStr = "pyfunc=np._NoValue, otypes=None, doc=None, excluded=None, cache=False, signature=None")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.22 Summary and examples: Numpy utility functions





        #endregion




        #region 7.23 Arithmetic operations with scalars and iterables

        // these function need to be moved to mpm


        #endregion




        #region 7.24 Numerical transformations and descriptive statistics


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/centered/*' />
        public static mp_numpy_array centered(string PyStr = "res, data, population, opt")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/standardized/*' />
        public static mp_numpy_array standardized(string PyStr = "res, data, population, opt")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/trace/*' />
        public static mp_numpy_array trace(string PyStr = "")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/squaredNorm/*' />
        public static mp_numpy_array squaredNorm(string PyStr = "partialmode=full")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/Norm/*' />
        public static mp_numpy_array Norm(string PyStr = "partialmode=full")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/covariance_matrix/*' />
        public static mp_numpy_array covariance_matrix(string PyStr = "use_crossproduct=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/correlation/*' />
        public static mp_numpy_array correlation(string PyStr = "use_crossproduct=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/summary/*' />
        public static mp_numpy_array summary(string PyStr = "summary, data, population, opt")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/norm/*' />
        public static mp_numpy_array norm(string PyStr = "x, p=2")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/mnorm/*' />
        public static mp_numpy_array mnorm(string PyStr = "A, p=1")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.25 Standard decompositions and linear solving


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/cholesky/*' />
        public static mp_numpy_array cholesky(string PyStr = "(A, tol=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/cholesky_solve/*' />
        public static mp_numpy_array cholesky_solve(string PyStr = "A, b, **kwargs")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/lu/*' />
        public static mp_numpy_array lu(string PyStr = "A")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/det/*' />
        public static mp_numpy_array det(string PyStr = "A")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/inverse/*' />
        public static mp_numpy_array inverse(string PyStr = "A, **kwargs")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/lu_solve/*' />
        public static mp_numpy_array lu_solve(string PyStr = "A, b")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/residual/*' />
        public static mp_numpy_array residual(string PyStr = "A, x, b, **kwargs")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/improve_solution/*' />
        public static mp_numpy_array improve_solution(string PyStr = "ctx, A, x, b, maxsteps=1")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/cond/*' />
        public static mp_numpy_array cond(string PyStr = "A, norm=None")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/qr/*' />
        public static mp_numpy_array qr(string PyStr = "A, mode='full', edps=10")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/qr_solve/*' />
        public static mp_numpy_array qr_solve(string PyStr = "A, b, norm=None, **kwargs")
        {
            return new mp_numpy_array();
        }


        #endregion




        #region 7.26 Singular Value and Eigen decompositions


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/svd_r/*' />
        public static mp_numpy_array svd_r(string PyStr = "A, full_matrices=False, compute_uv=True, overwrite_a=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/svd_c/*' />
        public static mp_numpy_array svd_c(string PyStr = "A, full_matrices=False, compute_uv=True, overwrite_a=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/svd/*' />
        public static mp_numpy_array svd(string PyStr = "A, full_matrices=False, compute_uv=True, overwrite_a=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/eigsy/*' />
        public static mp_numpy_array eigsy(string PyStr = "d, e, z=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/eighe/*' />
        public static mp_numpy_array eighe(string PyStr = "A, eigvals_only=False, overwrite_a=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/eigh/*' />
        public static mp_numpy_array eigh(string PyStr = "A, eigvals_only=False, overwrite_a=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/r_sy_tridiag/*' />
        public static mp_numpy_array r_sy_tridiag(string PyStr = "ctx, A, D, E, calc_ev=True")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/c_he_tridiag_0/*' />
        public static mp_numpy_array c_he_tridiag_0(string PyStr = "ctx, A, D, E, S")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/tridiag_eigen/*' />
        public static mp_numpy_array tridiag_eigen(string PyStr = "ctx, d, e, z=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/eig/*' />
        public static mp_numpy_array eig(string PyStr = "A, left=False, right=True, overwrite_a=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/eig_sort/*' />
        public static mp_numpy_array eig_sort(string PyStr = "E, EL=False, ER=False, f='real'")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/hessenberg/*' />
        public static mp_numpy_array hessenberg(string PyStr = "A, overwrite_a=False")
        {
            return new mp_numpy_array();
        }


        /// <include file="docs.xml" path='docs/members[@name="MpNumpy"]/schur/*' />
        public static mp_numpy_array schur(string PyStr = "A, overwrite_a=False")
        {
            return new mp_numpy_array();
        }


        #endregion







    }





}