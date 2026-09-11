using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;





namespace TinyPlot2DCtrl
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




    public class PlotStyle : StringConverter
    {
        public static string[] GetItems()
        {
            return new string[]{
                "default",
                "Solarize_Light2",
                "_classic_test_patch",
                "_mpl-gallery",
                "_mpl-gallery-nogrid",
                "bmh",
                "classic",
                "dark_background",
                "fast",
                "fivethirtyeight",
                "ggplot",
                "grayscale",
                "petroff10",
                "seaborn-v0_8",
                "seaborn-v0_8-bright",
                "seaborn-v0_8-colorblind",
                 "seaborn-v0_8-dark",
                 "seaborn-v0_8-dark-palette",
                 "seaborn-v0_8-darkgrid",
                 "seaborn-v0_8-deep",
                 "seaborn-v0_8-muted",
                 "seaborn-v0_8-notebook",
                 "seaborn-v0_8-paper",
                 "seaborn-v0_8-pastel",
                 "seaborn-v0_8-poster",
                 "seaborn-v0_8-talk",
                 "seaborn-v0_8-ticks",
                 "seaborn-v0_8-white",
                 "seaborn-v0_8-whitegrid",
                 "tableau-colorblind10",
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




    public class OutputMode : StringConverter
    {
        public static string[] GetItems()
        {
            return new string[]{
                "gui",
                "svg",
                "pdf",
                "jpg",
                "pnf",
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




    public class TagAttribute : Attribute
    {
        public string TagValue { get; set; }

        public TagAttribute(string tagValue)
        {
            TagValue = tagValue;
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




    [Serializable()]
    public partial class WpfGraphicsSettings
    {

        public WpfGraphicsSettings() { }

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





        [Category("01. General"), Description("Import Statement"), DisplayName("A. Import Statement")]
        public string ImportStatement { get; set; }


        [Category("01. General"), Description("Function Name"), DisplayName("B. Function Name")]
        public string FunctionName { get; set; }


        [Category("01. General"), Description("Title"), DisplayName("C. Title")]
        public string Title { get; set; }





        [TypeConverter(typeof(PlotStyle)), Category("01. General"), Description("Determines the plot style"), DisplayName("D. Plot Style")]
        public string PlotStyle { get; set; }



        [TypeConverter(typeof(OutputMode)), Category("01. General"), Description("OutputMode "), DisplayName("E. OutputMode")]
        public string OutputMode { get; set; }



        [TypeConverter(typeof(Resolution3D)), Category("01. General"), Description("FigSizeX"), DisplayName("F. FigSizeX")]
        public int FigSizeX { get; set; }


        [TypeConverter(typeof(Resolution3D)), Category("01. General"), Description("FigSizeY"), DisplayName("G. FigSizeY")]
        public int FigSizeY { get; set; }



        [TypeConverter(typeof(Resolution3D)), Category("01. General"), Description("Resolution of x or t"), DisplayName("H. Resolution of x or t")]
        public int Resolution { get; set; }



        [Tag("ScriptEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("01. General"), Description("Local import statements, which are required by the key word arguments"), Browsable(true), DisplayName("I. Local imports")]
        public string LocalImports { get; set; }




        [Tag("ScriptEvaluator"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("01. General"), Description("The key word arguments which fine tune the result"), Browsable(true), DisplayName("J. Key word aguments")]
        public string Code { get; set; }



        [TypeConverter(typeof(RunAfterLoading)), Category("01. General"), Description("Determines whether the script is run immediately after loading"), DisplayName("K. Run After Loading")]
        public string RunAfterLoading { get; set; }







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
