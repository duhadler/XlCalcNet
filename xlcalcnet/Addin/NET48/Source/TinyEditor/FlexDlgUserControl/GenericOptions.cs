using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FlexDlgUserCtrl
{


    public class PaperType : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { "A0 (841 x 1189)",
                                                               "A1 (594 x 841)",
                                                               "A2 (420 x 594)",
                                                               "A3 (297 x 420)",
                                                               "A4 (210 x 297)",
                                                               "A5 (148 x 210)" });
        }
    }



    public class GenericOptions
    {


        [Category("Compiler Settings"),
        Description("References which need to be included for successful compilation")]
        public string[] CompilerReferences { get; set; }


        [Category("General Settings"),
         Description("TabName of the current setting")]
        public string TabName { get; set; }

    } // public class LanguageOptions




    [Serializable()]
    public partial class GenericParameterSettings
    {
        static string _filename;


        private int _left_margin;
        private int _right_margin;
        private int _top_margin;
        private int _bottom_margin;

        private double _preview_zoom;
        private int _preview_startpage;
        private int _preview_columns;
        private int _preview_rows;


        private bool _landscape;
        private bool _autozoom;

        private string _papertype;



        [Category("Preview Setup"), Description("Preview zoom")]
        public double Zoom
        {
            get { return _preview_zoom; }
            set { _preview_zoom = value; }
        }


        [Category("Preview Setup"), Description("Preview start page")]
        public int StartPage
        {

            get { return _preview_startpage; }
            set { _preview_startpage = value; }
        }


        [Category("Preview Setup"), Description("Preview number of page columns")]
        public int PageColumns
        {
            get { return _preview_columns; }
            set { _preview_columns = value; }
        }


        [Category("Preview Setup"), Description("Preview number of page rows")]
        public int PageRows
        {
            get { return _preview_rows; }
            set { _preview_rows = value; }
        }


        [Category("Preview Setup"), Description("Use automatic zoom")]
        public bool AutoZoom
        {
            get { return _autozoom; }
            set { _autozoom = value; }
        }


        [Category("Page Margins"), Description("Left margin of the page (mm)")]
        public int LeftMargin
        {
            get { return _left_margin; }
            set { _left_margin = value; }
        }


        [Category("Page Margins"), Description("Right margin of the page (mm)")]
        public int RightMargin
        {
            get { return _right_margin; }
            set { _right_margin = value; }
        }


        [Category("Page Margins"), Description("Top margin of the page (mm)")]
        public int TopMargin
        {
            get { return _top_margin; }
            set { _top_margin = value; }
        }


        [Category("Page Margins"), Description("Bottom margin of the page (mm)")]
        public int BottomMargin
        {
            get { return _bottom_margin; }
            set { _bottom_margin = value; }
        }


        [Category("Page Setup"), Description("Use Landscape")]
        public bool Landscape
        {
            get { return _landscape; }
            set { _landscape = value; }
        }




        [TypeConverter(typeof(PaperType)), Category("Page Setup"), Description("The paper type")]
        public string PaperType
        {
            get { return _papertype; }
            set { _papertype = value; }
        }









        public GenericParameterSettings Load(string filename)
        {
            _filename = filename;
            XmlSerializer serializer = new XmlSerializer(typeof(GenericParameterSettings));
            GenericParameterSettings retVal = null;
            TextReader reader = null;
            bool fileNotFound = false;

            try
            {
                reader = new StreamReader(_filename);
            }
            catch (FileNotFoundException)
            {
                // Take the defaults
                fileNotFound = true;
            }

            if (fileNotFound)
            {
                retVal = new GenericParameterSettings();
                retVal.AutoZoom = true;
                retVal.BottomMargin = 10;
                retVal.Landscape = false;
                retVal.LeftMargin = 10;
                retVal.PageColumns = 1;
                retVal.PageRows = 1;
                retVal.PaperType = "A4 (210 x 297)";
                retVal.RightMargin = 10;
                retVal.StartPage = 1;
                retVal.TopMargin = 15;
                retVal.Zoom = 1;
            }
            else
            {
                //Read it from the file
                retVal = (GenericParameterSettings)serializer.Deserialize(reader);
                reader.Close();
            }
            return retVal;
        }

        public void Save(string FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GenericParameterSettings));
            TextWriter writer = new StreamWriter(FileName);
            serializer.Serialize(writer, this);
            writer.Close();
        }


    }






}
