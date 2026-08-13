using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel.Design;
using System.Drawing.Design;





namespace FlexDlgUserCtrl
{



    #region OptionssSettings



    [Serializable()]
    public partial class OptionsSettings
    {

        [Category("00. Use last size and position"), Description("Use last size and position of Tiny Script Editor+ when called from Windows Explorer")]
        public bool Explorer { get; set; }


        [Category("00. Use last size and position"), Description("Use last size and position of Tiny Script Editor+ when called from LibreOffice")]
        public bool LibreOffice { get; set; }

        [Category("00. Use last size and position"), Description("Use last size and position of Tiny Script Editor+ when called from MS Excel")]
        public bool MSExcel { get; set; }

        [Category("00. Use last size and position"), Description("Use last size and position of Tiny Script Editor+ when called from SharpDevelop")]
        public bool SharpDevelop { get; set; }
        

        

        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("01. IronPython"), Description("Assemblies which will be referenced by the IronPython compiler")]
        public string IPYAssemblies { get; set; }
        

        

        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("02. Visual Basic"), Description("Assemblies which will be referenced by the Visual Basic compiler")]
        public string VBAssemblies { get; set; }

        [Category("02. Visual Basic"), Description("Options which will be used by the Visual Basic compiler")]
        public string VBOptions { get; set; }

        
        
        
        
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("03. CSharp"), Description("Assemblies which will be referenced by the CSharp compiler")]
        public string CSAssemblies { get; set; }

        [Category("03. CSharp"), Description("Options which will be used by the CSharp compiler")]
        public string CSOptions { get; set; }
        
        
        

        [Category("04. CPython"), Description("Path to the CPython interpreter")]
        public string CPythonPath { get; set; }
        

        [Category("05. R (Statistical System)"), Description("Path to the RScript executable")]
        public string RScriptPath { get; set; }
        
        

        
        public OptionsSettings Load(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OptionsSettings));
            OptionsSettings retVal = null;
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
                retVal = new OptionsSettings();
            }
            else
            {
                //Read it from the file
                retVal = (OptionsSettings)serializer.Deserialize(reader);
                reader.Close();
            }

            return retVal;
        }

        public void Save(string FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OptionsSettings));
            TextWriter writer = new StreamWriter(FileName);
            serializer.Serialize(writer, this);
            writer.Close();
        }

    }

    #endregion




}
