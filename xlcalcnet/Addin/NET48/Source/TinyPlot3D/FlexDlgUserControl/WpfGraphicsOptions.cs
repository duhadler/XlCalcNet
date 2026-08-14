using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;





namespace TinyPlot3DCtrl
{



    #region PlotsSettings

    public class Resolution3D : Int32Converter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new int[]{
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                16,
                32,
                48,
                64,
                96,
                128,
                192,
                256,
                512,
                1024
            });
        }
    }







    public class SurfaceMaterial : StringConverter
    {
        public static string[] GetItems()
        {
            return new string[]{
                "PlainColor",
                "GlossyColor",
                "Gradient",
                "ColorMap",
                "Texture",
            };
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetItems());
        }
    }


    public class BackMaterial : StringConverter
    {
        public static string[] GetItems()
        {
            return new string[]{
                "None",
                "SameAsForeground",
                "PlainColor",
                "GlossyColor",
            };
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetItems());
        }
    }


    public class SurfaceGradient : StringConverter
    {
        public static string[] GetItems()
        {
            return new string[]{
                "None",
                "HeightGradient0",
                "HeightGradient1",
                "SequenceGradient0",
                "SequenceGradient1",
            };
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetItems());
        }
    }


    public class SurfaceColorMap : StringConverter
    {
        public static string[] GetItems()
        {
            return new string[]{
                "None",
                "ALTITUDEMAP",
                "ALTITUDEMAP2",
                "ARGUMENTMAP",
                "DomainColoringPlain",
                "DomainColoringContourPhase",
                "DomainColoringContourModulus",
                "DomainColoringContourPhaseAndModulus",
            };
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetItems());
        }
    }



    public class SurfaceOpacity : Int32Converter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new int[]{
                0,
                1,
                16,
                32,
                48,
                64,
                96,
                128,
                192,
                224,
                255,
            });
        }
    }







    // See also: https://mathworld.wolfram.com/BranchCut.html

    public class Branchcuts : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        // See also: https://mathworld.wolfram.com/BranchCut.html

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{
                "None",
                "-inf to 0",
                "-inf to +1",
                "+1 to +inf",

                "-1 to +1",
                "-inf to 0; +1 to +inf",
                "-inf to -1; +1 to +inf",
                "-1i to +1i",
                "-i inf to 0; +1i to +i inf",
                "-i inf to -1i; +1i to +i inf",
            });
        }
    }



    public class SameScale : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{
                "All",
                "None",
                "X, Y",
                "X, F(X,Y)",
                "Y, F(X,Y)"
            });
        }
    }



    public class PathEvaluationOrder : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{
                "N/A",
                "SequenceX",
                "SequenceY",
                "SequenceZ"
            });
        }
    }



    public class RunAfterLoading : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{
                "Always",
                "Always, clear previous",
                "Never",
                "With XlCalcNet2",
                "With UserLibrary",
                "With Both"
            });
        }
    }

    public class FinalRotationOrder : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{
                "X-Y-Z",
                "X-Z-Y",
                "Y-X-Z",
                "Y-Z-X",
                "Z-X-Y",
                "Z-Y-X",
            });
        }
    }


    public class ComplexType : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{
                "N/A",
                "REAL",
                "IMAGINARY",
                "MAGNITUDE"
            });
        }
    }


    public class Plot3DType : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{
                "Altitude surface, real function",
                "Altitude surface, complex function",
                "Parametric surface",
                "Path surface",
                "Builtin solid",
            });
        }
    }


    public class StyleOfAxes : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{"FullCage", "BackPanel",});
        }
    }


    public class BrushTexture2 : StringConverter
    {
        private string[] GetValues()
        {
            string TexturePath = Plot3DCtrl._TexturePath;
            var folders = new DirectoryInfo(TexturePath).GetFiles().
                 Where(f => f.FullName.EndsWith(".jpg") || f.Name.EndsWith(".png")).ToArray();
            string[] result = new string[folders.Length + 1];
            result[0] = "None";
            int i = 0;
            foreach (var element in folders)
            {
                i = i + 1;
                string s = Path.GetFileName(element.Name);
                result[i] = s;
            }
            return result;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetValues());
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string s = value.ToString();
            ArrayList AL = new ArrayList(GetValues());
            if (AL.Contains(s)) { return s; }
            else throw new ArgumentException("The value '" + s + "' is not supported");
        }
    }

    public class TagAttribute : Attribute
    {
        public string TagValue { get; set; }

        public TagAttribute(string tagValue)
        {
            TagValue = tagValue;
        }
    }



    public class SolidStr : StringConverter
    {
        public static string[] GetItems()
        {
            return new string[]{
                "None",
                "Column",
                "Cone",
                "Sphere",
                "Torus",
            };
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetItems());
        }
    }







    [Serializable()]
    public partial class WpfGraphicsSettings
    {

        public WpfGraphicsSettings() { }


        public string m_ChartCategory;
        private static readonly TypeConverter FontConverter = TypeDescriptor.GetConverter(typeof(Font));
        private static PictureBox pictureBox1_ = null;
        private static TabControl tabControl1_ = null;
        private static Label lblPictures_ = null;
        private static bool NoTabChange_ = false;


        public void SetParams(PictureBox pictureBox1, TabControl tabControl1, Label lblPictures)
        {
            pictureBox1_ = pictureBox1;
            tabControl1_ = tabControl1;
            lblPictures_ = lblPictures;
        }


        public void SetNoTabChange(bool NoTabChange)
        {
            NoTabChange_ = NoTabChange;
        }


        private void HandleImage(ref string MyImage, string MyValue)
        {
            MyImage = MyValue;
            if (MyImage != "None")
            {
                string ImageFullPath = Plot3DCtrl._TexturePath + @"\" + MyImage;
                if (File.Exists(ImageFullPath))
                {
                    pictureBox1_.ImageLocation = ImageFullPath;
                    lblPictures_.Text = MyImage;
                    if (!NoTabChange_) tabControl1_.SelectedIndex = 1;
                }
                else
                {
                    MyImage = "None";
                    lblPictures_.Text = "";
                    pictureBox1_.Image = null;
                }
            }
            else
            {
                MyImage = "None";
                lblPictures_.Text = "";
                pictureBox1_.Image = null;
            }
        }




        private static string FromColor(Color color)
        {
            if (color.IsNamedColor)
            { return color.Name; }
            else
            { return color.ToArgb().ToString(); }
        }

        private static Color ToColor(string value)
        {
            bool converted = int.TryParse(value, out int colorValue);
            if (converted) return Color.FromArgb(colorValue);
            else return Color.FromName(value);
        }



        [Category("01. General"), Description("Title"), DisplayName("A. Title")]
        public string Title { get; set; }


        [Category("01. General"), Description("Camera angle theta"), DisplayName("C. Camera Angle Theta")]
        public double CameraAngleTheta { get; set; }


        [Category("01. General"), Description("Camera angle phi"), DisplayName("D. Camera Angle Phi")]
        public double CameraAnglePhi { get; set; }


        [Category("01. General"), Description("Camera radius exponent"), DisplayName("E. Camera Radius Exponent")]
        public double CameraRadius { get; set; }


        [Category("01. General"), Description("If true, uses the orthographic camera, otherwise the perspective camera"), DisplayName("F. Camera Is Orthographic")]
        public bool CameraIsOrthographic { get; set; }



        [Category("01. General"), Description("If true, shows the x, y, and z axes"), DisplayName("G. Show Axes")]
        public bool ShowAxes { get; set; }



        [TypeConverter(typeof(StyleOfAxes)), Category("01. General"), Description("Style of Axes (if any) which is used for the 3D plot"), DisplayName("H. Style Of Axes")]
        public string StyleOfAxes { get; set; }



        [TypeConverter(typeof(RunAfterLoading)), Category("01. General"), Description("Determines whether the script is run immediately after loading"), DisplayName("I. Run After Loading")]
        public string RunAfterLoading { get; set; }






        [TypeConverter(typeof(Plot3DType)), Category("02. Evaluation"), Description("Plot Type"), DisplayName("A. Plot Type")]
        public string Plot3DType1 { get; set; }



        [Tag("ScriptEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("02. Evaluation"), Description("The mathematical equations which define the solid or surface"), Browsable(true), DisplayName("B. Defining Equations")]
        public string Code { get; set; }



        [TypeConverter(typeof(Resolution3D)), Category("02. Evaluation"), Description("Resolution of x, u, t"), DisplayName("C. Resolution of x, u, t")]
        public int Resolution { get; set; }


        [TypeConverter(typeof(Resolution3D)), Category("02. Evaluation"), Description("Resolution of y, v"), DisplayName("D. Resolution of y, v, polygon")]
        public int Resolution2 { get; set; }



        [Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("02. Evaluation"), Description("Variables x, u, t: Start"), Browsable(true), DisplayName("E. Start of x, u, t")]
        public string xmin { get; set; }



        [Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("02. Evaluation"), Description("Variables x, u, t: Stop"), Browsable(true), DisplayName("F. Stop of x, u, t")]
        public string xmax { get; set; }



        [Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("02. Evaluation"), Description("Variables y, v, polysize: Start"), Browsable(true), DisplayName("G. Start of y, v, polysize")]
        public string zmin { get; set; }




        [Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("02. Evaluation"), Description("Variables y, v, polysize: Stop"), Browsable(true), DisplayName("H. Stop of y, v, polysize")]
        public string zmax { get; set; }



        [Category("02. Evaluation"), Description("Determines whether the end of the path will be extended, possibly closing the path. Only relevant for path surfaces."), DisplayName("I. Extend path end")]
        public bool RepeatStart { get; set; }



        [TypeConverter(typeof(PathEvaluationOrder)), Category("02. Evaluation"), Description("Sets the path evaluation sequence. Only relevant for path surfaces."), DisplayName("J. Path evaluation sequence")]
        public string PathEvalOrder { get; set; }






        [TypeConverter(typeof(FinalRotationOrder)), Category("03. Reshaping"), Description("Sets the order for the final rotations."), DisplayName("A. Final Rotation Order")]
        public string FinalRotationOrder { get; set; }


        [Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("03. Reshaping"), Description("Rotation X (in degrees)"), Browsable(true), DisplayName("B. Final XRotation (in degrees)")]
        public string FinalXRotation { get; set; }


        [Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("03. Reshaping"), Description("Rotation Y (in degrees)"), Browsable(true), DisplayName("C. Final YRotation (in degrees)")]
        public string FinalYRotation { get; set; }


        [Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("03. Reshaping"), Description("Rotation Z (in degrees)"), Browsable(true), DisplayName("D. Final ZRotation (in degrees)")]
        public string FinalZRotation { get; set; }


        [Category("03. Reshaping"), Description("Truncation value"), DisplayName("E. Truncate")]
        public double Truncate { get; set; }



        [Category("03. Reshaping"), Description("Sets y = Lnp1(|y|)*sgn(y). This is done twice in a row."), DisplayName("F. LogLogTransform")]
        public bool LogLogTransform { get; set; }




        [Category("03. Reshaping"), Description("Determines whether the X and Y components of the path will be centered. Only relevant for path surfaces"), DisplayName("G. Centered XY")]
        public bool CenteredXY { get; set; }



        [TypeConverter(typeof(SameScale)), Category("03. Reshaping"), Description("Determines which axes are set to the same scale, if any"), DisplayName("H. Same Scale")]
        public string SameScale { get; set; }




        [TypeConverter(typeof(ComplexType)), Category("03. Reshaping"), Description("The components of a complex result which are used for display. Only relevant for complex functions (altitude surfaces)."), DisplayName("I. Complex Component")]
        public string ComplexType { get; set; }



        [TypeConverter(typeof(Branchcuts)), Category("03. Reshaping"), Description("Determines which branchcuts are set, if any. Only relevant for complex functions (altitude surfaces)."), DisplayName("J. Branchcuts")]
        public string Branchcuts { get; set; }






        //[Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("04. Formatting"), Description("MapStart"), Browsable(true), DisplayName("A0. MapStart")]
        //public string MapStart { get; set; }




        //[Tag("ExpressionEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("04. Formatting"), Description("MapFactor"), Browsable(true), DisplayName("A1. MapFactor")]
        //public string MapFactor { get; set; }


        [TypeConverter(typeof(SurfaceMaterial)), Category("04. Formatting"), Description("Surface Material"), DisplayName("A. Surface Material")]
        public string SurfaceMaterial1 { get; set; }


        #region B. Surface Color

        private Color SurfaceColor_;
        private string SurfaceColorString_;

        [Category("04. Formatting"), Description("Sets the Surface Color"), ReadOnly(false), XmlIgnore(), Browsable(true), DisplayName("B. Surface Color")]
        public Color SurfaceColor
        {
            get { return SurfaceColor_; }
            set { SurfaceColor_ = value; SurfaceColorString_ = FromColor(value); }
        }

        [Category("04. Formatting"), Description("Sets the Surface Color"), ReadOnly(false), Browsable(false), DisplayName("B. Surface Color")]
        public string SurfaceColorString
        {
            get { return SurfaceColorString_; }
            set { SurfaceColorString_ = value; SurfaceColor_ = ToColor(value); }
        }

        #endregion 



        [TypeConverter(typeof(SurfaceGradient)), Category("04. Formatting"), Description("Gradient used for the surface"), DisplayName("C. Surface Gradient")]
        public string SurfaceGradient1 { get; set; }


        [TypeConverter(typeof(SurfaceColorMap)), Category("04. Formatting"), Description("ColorMap used for the surface"), DisplayName("D. Surface ColorMap")]
        public string SurfaceColorMap1 { get; set; }



        private string SurfaceTexture1_;
        [TypeConverter(typeof(BrushTexture2)), Category("04. Formatting"), Description("Surface Texture used for the surface"), ReadOnly(false), Browsable(true), DisplayName("E. Surface Texture")]
        public string SurfaceTexture1
        {
            get { return SurfaceTexture1_; }
            set { HandleImage(ref SurfaceTexture1_, value); }
        }





        [Category("04. Formatting"), Description("Surface Smoothing"), DisplayName("F. Surface Smoothing")]
        public bool SurfaceSmoothing { get; set; }



        [TypeConverter(typeof(SurfaceOpacity)), Category("04. Formatting"), Description("Transparency"), DisplayName("G. Surface Transparency")]
        public int Transparency { get; set; }



        [TypeConverter(typeof(BackMaterial)), Category("04. Formatting"), Description("Back Material"), DisplayName("H. Back Material")]
        public string BackMaterial1 { get; set; }



        #region I. Back Color

        private Color BackColor_;
        private string BackColorString_;

        [Category("04. Formatting"), Description("Sets the Back Color"), ReadOnly(false), XmlIgnore(), Browsable(true), DisplayName("I. Back Color")]
        public Color BackColor
        {
            get { return BackColor_; }
            set { BackColor_ = value; BackColorString_ = FromColor(value); }
        }

        [Category("04. Formatting"), Description("Sets the Back Color"), ReadOnly(false), Browsable(false), DisplayName("I. Back Color")]
        public string BackColorString
        {
            get { return BackColorString_; }
            set { BackColorString_ = value; BackColor_ = ToColor(value); }
        }

        #endregion 







        [Category("04. Formatting"), Description("Show Wireframe"), DisplayName("J. Show Wireframe")]
        public bool ShowWireframe { get; set; }



        [Category("04. Formatting"), Description("WireframeThickness"), DisplayName("K. WireframeThickness")]
        public double WireframeThickness { get; set; }



        #region L. Wireframe Color

        private Color WireframeColor_;
        private string WireframeColorString_;

        [Category("04. Formatting"), Description("Sets the Wireframe Color"), ReadOnly(false), XmlIgnore(), Browsable(true), DisplayName("L. Wireframe Color")]
        public Color WireframeColor
        {
            get { return WireframeColor_; }
            set { WireframeColor_ = value; WireframeColorString_ = FromColor(value); }
        }

        [Category("04. Formatting"), Description("Sets the Wireframe Color"), ReadOnly(false), Browsable(false), DisplayName("L. Wireframe Color")]
        public string WireframeColorString
        {
            get { return WireframeColorString_; }
            set { WireframeColorString_ = value; WireframeColor_ = ToColor(value); }
        }

        #endregion 




        [Category("04. Formatting"), Description("Highlight Vertices"), DisplayName("M. Highlight Vertices")]
        public bool HighlightVertices { get; set; }



        [Category("04. Formatting"), Description("Vertices Thickness"), DisplayName("N. Vertices Thickness")]
        public double VerticesThickness { get; set; }



        #region O. Vertices Color

        private Color VerticesColor_;
        private string VerticesColorString_;

        [Category("04. Formatting"), Description("Sets the Vertices Color"), ReadOnly(false), XmlIgnore(), Browsable(true), DisplayName("O. Vertices Color")]
        public Color VerticesColor
        {
            get { return VerticesColor_; }
            set { VerticesColor_ = value; VerticesColorString_ = FromColor(value); }
        }

        [Category("04. Formatting"), Description("Sets the Vertices Color"), ReadOnly(false), Browsable(false), DisplayName("O. Vertices Color")]
        public string VerticesColorString
        {
            get { return VerticesColorString_; }
            set { VerticesColorString_ = value; VerticesColor_ = ToColor(value); }
        }

        #endregion



        [TypeConverter(typeof(SolidStr)), Category("04. Formatting"), Description("Background Solid Type. Only relevant for path surfaces."), DisplayName("P. Background Solid Type")]
        public string SolidType { get; set; }




        #region Q. Background Solid Color

        private Color BackgroundSolidColor_;
        private string BackgroundSolidColorString_;

        [Category("04. Formatting"), Description("Sets the Background Solid Color. Only relevant for path surfaces."), ReadOnly(false), XmlIgnore(), Browsable(true), DisplayName("Q. Background Solid Color")]
        public Color BackgroundSolidColor
        {
            get { return BackgroundSolidColor_; }
            set { BackgroundSolidColor_ = value; BackgroundSolidColorString_ = FromColor(value); }
        }

        [Category("04. Formatting"), Description("Sets the Generator Color. Only relevant for path surfaces."), ReadOnly(false), Browsable(false), DisplayName("Q. Generator Color")]
        public string GeneratorColorString
        {
            get { return BackgroundSolidColorString_; }
            set { BackgroundSolidColorString_ = value; BackgroundSolidColor_ = ToColor(value); }
        }

        #endregion





        [TypeConverter(typeof(SurfaceOpacity)), Category("04. Formatting"), Description("Background Solid Transparency. Only relevant for path surfaces."), DisplayName("R. Background Solid Transparency")]
        public int BackgroundSolidTransparency { get; set; }








        public WpfGraphicsSettings Load(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WpfGraphicsSettings));
            WpfGraphicsSettings retVal = null;
            TextReader reader = null;
            bool fileNotFound = false;

            try
            {
                reader = new StreamReader(filename);
            }
            catch (FileNotFoundException)
            {
                // Take the defaults
                fileNotFound = true;
            }

            if (fileNotFound)
            {
                retVal = new WpfGraphicsSettings();
            }
            else
            {
                //Read it from the file
                retVal = (WpfGraphicsSettings)serializer.Deserialize(reader);
                reader.Close();
            }

            return retVal;
        }

        public void Save(string FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WpfGraphicsSettings));
            TextWriter writer = new StreamWriter(FileName);
            serializer.Serialize(writer, this);
            writer.Close();
        }

    }

    #endregion




}
