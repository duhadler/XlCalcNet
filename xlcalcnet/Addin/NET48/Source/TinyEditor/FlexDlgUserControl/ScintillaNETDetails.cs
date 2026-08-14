
// See also: https://github.com/desjarlais/Scintilla.NET


using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ScintillaNET;
using ScintillaNET_FindReplaceDialog;
using ScintillaNET_FindReplaceDialog.FindAllResults;
using ScintillaPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace FlexDlgUserCtrl
{
    public partial class FlexDlgUserControl1 : UserControl
    {
        private const int NUMBER_MARGIN = 1;
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 3;
        private const int FOLDING_MARGIN = 3;

        private const int WARNING_ANNOTATION = 101;
        private const int ERROR_ANNOTATION = 102;

        private const int WARNING_INDICATOR = 8;
        private const int ERROR_INDICATOR = 9;

        private readonly string mAlphabet = "abcdefghijklmnopqrstuvwxyz";

        private readonly char[] mWord_Separator = new[] { ' ', '.', '(', ')', ',' };
        private readonly string[] mKeywords_endline = new[] { Constants.vbCrLf, Constants.vbLf };

        private List<string> mAssemblysCollection;

        private Struct_AutoComplete FoundType = default;


        string XlCalcKeyWords1 = "FixedPrecNet ArbPrecNet ArbPrec UserFixedPrecNet UserArbPrecNet UserMpPrecNet math53 cmath53 sreal scplx  dreal dcplx  ereal ecplx qreal qcplx oreal ocplx creal ccplx   mreal mcplx sflint sflintc dflint dflintc eflint eflintc qflint qflintc oflint oflintc mflint mflintc aflint aflintc   m53lib m53libc slib slibc dlib dlibc elib elibc qlib qlibc olib olibc clib clibc    mlib mlibc sflib sflibc dflib dflibc eflib eflibc qflib qflibc oflib oflibc  mflib mflibc aflib aflibc   fpm mpm ipm dpm qpm gpm apm npm  fpmlib mpmlib ipmlib dpmlib qpmlib gpmlib apmlib";

        string XlCalcKeyWords2 = " Single SingleC SingleMat SingleMatC  Double Complex DoubleMat ComplexMat DoubleSpMat ComplexSpMat  Extended ExtendedC ExtendedMat ExtendedMatC   Quadruple QuadrupleC QuadrupleMat QuadrupleMatC   Octuple OctupleC OctupleMat OctupleMatC  Mpfr MpfrC MpfrMat MpfrMatC  Arb ArbC ArbMat ArbMatC mp_mpf mp_mpf_or_mpc iv_mpi iv_mpi_or_mpc float float_or_complex Decimal Decimal_or_DecC Fraction QCplx Fraction_or_QCplx gmp2_mpfr gmp2_mpfr_or_mpc flint_arb flint_arb_or_acb   Ctx CtxLib CtxScalar CtxVec CtxMat ";

        string MoreInfo = "";
        string DocFileHtml = "";

        private struct Struct_ResultBlock
        {
            public int Start_Line;
            public string type;
            public int Indentation;
            public KeyValuePair<string, string> arguments; // name, type 
            public Struct_ResultBlock(int Indent, string BlockType)
            {
                Indentation = Indent;
                type = BlockType;
                Start_Line = 0;
                arguments = new KeyValuePair<string, string>();
            }
        }
        private Struct_ResultBlock mCurrentBlock;

        private struct Struct_AutoComplete
        {
            public string Completion;
            public Dictionary<string, string> Parameters;
            public string ReturnedType(string Parameter)
            {
                if (Parameter is null || !Parameters.ContainsKey(Parameter))
                    return null;
                string CurrentParameter = Parameters[Parameter];
                int endString = CurrentParameter.LastIndexOf(')');
                string result = Strings.Trim(CurrentParameter.Substring(endString + 1).Replace("As ", ""));
                return result;
            }
        }

        private struct Struct_CallTips
        {
            public int Start;
            public int End;
        }
        private List<Struct_CallTips> mCallTipsPos;
        private int mIndexCallTip = 0;
        private int mSelectedCallTip = 0;
        private List<string> mCallTipsFound = new List<string>();


        // Private AutoC_SelectedItem As String
        private bool AutoC_ValidatedBySpace = false;
        private string[] LastWordsEntered;
        private string KeyWordsSelected;

        private enum IndexType
        {
            keyword = 0,
            Method = 1,
            Property = 2,
            Member = 3,
            Namespace = 4,
            Enum = 5,
            Class = 6,
            Structure = 7
        }



        private string LastCategory = "";

        // Declare variable for ScriptType
        private string ScriptType = "Python";

        // Declare variable for the Filename of the current Script
        private string ScriptFileName;

        // Declare variable for Comments
        string CommentStr = "#";

        // Declare variable for Printing dialogs
        Printing Printer;

        // Declare variable for FindReplace dialog
        FindReplace ScFindReplace;

        // Declare variable for Brace Matching
        int LastCaretPos = 0;

        private Scintilla scintilla1 = new Scintilla();
        private FindAllResultsPanel findAllResultsPanel1 = new FindAllResultsPanel();




        public void InitScintilla()
        {
            tableLayoutPanelMain.Controls.Add(scintilla1, 0, 1);
            scintilla1.Dock = DockStyle.Fill;
            scintilla1.IndentationGuides = IndentView.LookBoth;
            scintilla1.MouseSelectionRectangularSwitch = true;
            scintilla1.Name = "scintilla1";
            scintilla1.ViewWhitespace = WhitespaceMode.VisibleAlways;
            scintilla1.VirtualSpaceOptions = VirtualSpace.RectangularSelection;
            scintilla1.WrapVisualFlags = ((WrapVisualFlags.End | WrapVisualFlags.Start)
            | WrapVisualFlags.Margin);

            scintilla1.ContextMenuStrip = contextMenuStripEditor;


            scintilla1.TextChanged += new EventHandler(scintilla1_TextChanged);

            scintilla1.KeyDown += new KeyEventHandler(scintilla1_KeyDown);
            scintilla1.KeyPress += new KeyPressEventHandler(scintilla1_KeyPress);

            // Hook into UpdateUI event to highlight matching braces
            scintilla1.UpdateUI += new EventHandler<UpdateUIEventArgs>(scintilla_UpdateUI);

            scintilla1.AutoCSelectionChange += AutoCSelectionChange;

            scintilla1.AutoCSelection += AutoCSelection;
            scintilla1.CharAdded += CharAdded;
            scintilla1.Delete += Delete;

            scintilla1.CallTipClick += CallTipClick;

            // Same with FindAllResultsPanel (which contains the ScintillaNET.Scintilla control)
            tabFind.Controls.Add(findAllResultsPanel1);
            findAllResultsPanel1.Dock = DockStyle.Fill;
            findAllResultsPanel1.Location = new Point(3, 3);
            findAllResultsPanel1.Margin = new Padding(7, 8, 7, 8);
            findAllResultsPanel1.Name = "findAllResultsPanel1";

            // Hook the Find All Results Panel to the Scintilla that is being searched.
            findAllResultsPanel1.Scintilla = scintilla1;

            // Connect to Find and Replace Dialogs
            ScFindReplace = new FindReplace();
            ScFindReplace.Scintilla = scintilla1;

            // Hook into find all results event
            ScFindReplace.FindAllResults += MyFindReplace_FindAllResults;

            // Set printing routines
            Printer = new Printing(scintilla1);

            // Hook into MarginClick event to set/delete bookmarks
            scintilla1.MarginClick += TextArea_MarginClick;


            scintilla1.RegisterRgbaImage((int)IndexType.keyword, Properties.Resources.key);
            scintilla1.RegisterRgbaImage((int)IndexType.Method, Properties.Resources.function);
            scintilla1.RegisterRgbaImage((int)IndexType.Property, Properties.Resources.cog);
            scintilla1.RegisterRgbaImage((int)IndexType.Member, Properties.Resources.visual_basic);
            scintilla1.RegisterRgbaImage((int)IndexType.Namespace, Properties.Resources.books);
            scintilla1.RegisterRgbaImage((int)IndexType.Enum, Properties.Resources.line_numbers);
            scintilla1.RegisterRgbaImage((int)IndexType.Structure, Properties.Resources.document_tree);
            scintilla1.RegisterRgbaImage((int)IndexType.Class, Properties.Resources.math_functions);


            // STYLING
            InitSyntaxColoring();

            Init_Assembly();

        }



        private void LoadScriptFromFile(string path)
        {
            //MessageBox.Show(path);
            //MessageBox.Show(File.Exists(path).ToString());
            if (File.Exists(path))
            {
                //MessageBox.Show("in LoadScriptFromFile");
                ScriptFileName = path;
                string ext = Path.GetExtension(path).ToLower();

                switch (ext)
                {
                    case ".svg":
                    case ".xml":
                        ScriptType = "Chart";
                        break;
                    case ".css":
                        ScriptType = "css";
                        break;
                    case ".data":
                        ScriptType = "Chart";
                        break;
                    case ".bib":
                        ScriptType = "Bib";
                        break;
                    case ".py":
                        ScriptType = "Python";
                        break;
                    case ".vb":
                        ScriptType = "Visual Basic";
                        break;
                    case ".cs":
                        ScriptType = "CSharp";
                        break;
                    case ".h":
                        ScriptType = "CSharp";
                        break;
                    case ".pas":
                        ScriptType = "CSharp";
                        break;
                    case ".r":
                        ScriptType = "R Stat";
                        break;
                    case ".rst":
                    case ".txt":
                    case ".tex":
                    case ".bat":
                        ScriptType = "markdown";
                        break;
                    default:
                        ScriptType = "Plain Text";
                        break;
                }
                string fn = Path.GetFileNameWithoutExtension(path);
                //MessageBox.Show(fn);
                if (fn == "__external__")
                {
                    string temppath = "";
                    var lines = File.ReadLines(path);
                    if (lines.Count() > 0)
                    {
                        temppath = lines.First();
                        if (File.Exists(temppath))
                        {
                            path = temppath;
                        }
                        toolStripButtonRun.Text = "External File";
                        toolStripButtonRun.ToolTipText = "External File: " + temppath;
                        toolStripButtonRun.Enabled = false;
                        saveToolStripMenuItem.Enabled = false;
                        saveAsToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    toolStripButtonRun.Text = "Run";
                    toolStripButtonRun.ToolTipText = "";
                    toolStripButtonRun.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    saveAsToolStripMenuItem.Enabled = true;
                }

                scintilla1.HScrollBar = false;
                scintilla1.VScrollBar = false;
                scintilla1.Text = File.ReadAllText(path, Encoding.UTF8);
                InitSyntaxColoring();


                if (ScriptType == "CSharp")
                {
                    string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string ArbPath = BinPath.Replace("xlcalcnet", "xlcalcnet2") + @"\ArbPrecNet.dll";
                    //MessageBox.Show(ArbPath);
                    bool hasArb = File.Exists(ArbPath);
                    //MessageBox.Show(hasArb.ToString());
                    //string s1 = "#define UsingArbPrecNet";
                    string s1 = "#define HasArbPrecNet";
                    string s2 = "//" + s1;
                    scintilla1.Text = scintilla1.Text.Replace(s2, s1);
                    if (!hasArb) scintilla1.Text = scintilla1.Text.Replace(s1, s2);

                    string UserBinPath = _LocalAppDataDir + @"\XlCalcNetIDE\Bin";
                    string UserFixedLibPath = UserBinPath + @"\UserFixedPrecNet.dll";
                    //MessageBox.Show(UserFixedLibPath);
                    bool hasUserFixedLib = File.Exists(UserFixedLibPath);
                    //MessageBox.Show(hasUserFixedLib.ToString());
                    //string s3 = "#define UsingUserFixedPrecNet";
                    string s3 = "#define HasUserFixedPrecNet";
                    string s4 = "//" + s3;
                    scintilla1.Text = scintilla1.Text.Replace(s4, s3);
                    if (!hasUserFixedLib) scintilla1.Text = scintilla1.Text.Replace(s3, s4);

                    string UserArbLibPath = UserBinPath + @"\UserArbPrecNet.dll";
                    //MessageBox.Show(UserArbLibPath);
                    bool hasUserArbLib = File.Exists(UserArbLibPath);
                    //MessageBox.Show(hasUserArbLib.ToString());
                    bool hasUserArbLibAll = hasUserArbLib && hasArb && hasUserFixedLib;
                    //MessageBox.Show(hasUserArbLibAll.ToString());
                    //string s5 = "#define UsingUserArbPrecNet";
                    string s5 = "#define HasUserArbPrecNet";
                    string s6 = "//" + s5;
                    scintilla1.Text = scintilla1.Text.Replace(s6, s5);
                    if (!hasUserArbLibAll) scintilla1.Text = scintilla1.Text.Replace(s5, s6);


                    // See also: https://github.com/jacobslusser/ScintillaNET/issues/307
                    int mylinecount = scintilla1.Lines.Count - 1;
                    for (int i = mylinecount; i > 0; i--)
                    {
                        string curline = scintilla1.Lines[i].Text;
                        if (curline.Contains("#region "))
                        {
                            scintilla1.Lines[i].FoldLine(FoldAction.Contract);
                        }
                    }
                }


                if (ScriptType == "Python")
                {
                    scintilla1.FoldAll(FoldAction.Contract);
                    int mylinecount = scintilla1.Lines.Count - 1;
                    for (int i = 0; i < mylinecount; i++)
                    {
                        string curline = scintilla1.Lines[i].Text;
                        if (curline.Contains("def main_tests():"))
                        {
                            scintilla1.Lines[i].FoldLine(FoldAction.Expand);
                        }
                    }
                }


                scintilla1.HScrollBar = true;
                scintilla1.VScrollBar = true;

                scintilla1.SetSavePoint();
                UpdateChangeIndicator();


            }
        }


        private void SaveScript()
        {
            string path = ActiveFileName;
            if (Path.IsPathRooted(path))
            {
                File.WriteAllText(path, scintilla1.Text, Encoding.UTF8);
                scintilla1.SetSavePoint();
                UpdateChangeIndicator();
            }
        }




        private void UpdateChangeIndicator()
        {
            //MessageBox.Show("in TextChange" + toolStripLabelScriptName.Text + "2");
            if (scintilla1.Modified)
            {
                if (toolStripButtonRun.Text == "Run")
                {
                    toolStripButtonRun.Text = "Run*";
                }
            }
            else
            if (toolStripButtonRun.Text == "Run*")
            {
                toolStripButtonRun.Text = "Run";
            }
            toolStripButtonRun.Invalidate();
            //this.Refresh();
        }

        private void scintilla1_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeIndicator();
        }



        private void scintilla1_KeyDown(object sender, KeyEventArgs e)
        {
            if (scintilla1.AutoCActive == false & e.Modifiers == 0)
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                }

                if (scintilla1.CallTipActive)
                {
                    if (e.KeyCode == Keys.PageDown)
                    {
                        mSelectedCallTip += 1;
                        UpdateCallTipsFromIndex();
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.PageUp)
                    {
                        mSelectedCallTip -= 1;
                        UpdateCallTipsFromIndex();
                        e.Handled = true;
                    }
                }
            }



            if (e.KeyCode == Keys.F5)
            {
                RunScript();
                e.Handled = true;
            }

            // if we delete an opened parenthese and the next char is also a parenthese, delete it
            if (e.KeyCode == Keys.Back)
            {
                char charNext = Strings.ChrW(scintilla1.GetCharAt(scintilla1.CurrentPosition));
                char charDeleted = Strings.ChrW(scintilla1.GetCharAt(scintilla1.CurrentPosition - 1));
                if (charDeleted == '(' && charNext == ')')
                {
                    scintilla1.DeleteRange(scintilla1.CurrentPosition, 1);
                }
            }

        }


        //Ctrl+´ : paragraph down
        //Ctrl+` : paragraph up
        //Ctrl+' : end of previous paragraph
        //Ctrl+D : Duplicate
        //Ctrl+L : Delete Line
        //Ctrl+M : New Line

        private void scintilla1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int AscWInt = Strings.AscW(e.KeyChar);
            //MessageBox.Show("KeyCode: " + AscWInt.ToString());
            switch (AscWInt)
            {
                default: if (AscWInt < 32 && AscWInt > 13 || AscWInt < 12) { e.Handled = true; } break;
            }

            if (!scintilla1.AutoCActive && (e.KeyChar == '.'))
            {
                string s = scintilla1.GetWordFromPosition(scintilla1.CurrentPosition);
                if (!string.IsNullOrEmpty(s))
                {
                    //MessageBox.Show("s:" + s + ":");
                    if (XlCalcKeyWords1.Contains(s))
                    {
                        tabControl1.SelectedTab = tabFunctionInfo;
                        scintilla1.Focus();
                    }
                    else
                    {
                        e.Handled = true;
                        int pos = scintilla1.CurrentPosition;
                        scintilla1.InsertText(pos, ".");
                        scintilla1.GotoPosition(pos + 1);
                    }
                }
            }
            if (scintilla1.AutoCActive && (e.KeyChar == ' ' || e.KeyChar == '.'))
            {
                AutoC_ValidatedBySpace = true;
                scintilla1.AutoCComplete();
            }

        }


        public void AutoCSelectionChange(object sender, AutoCSelectionChangeEventArgs e)
        {
            string LastCat = LastCategory;
            string MethodName = e.Text;
            AutoCSelectionChange2(LastCategory, e.Text);
        }

        public void AutoCSelectionChange2(string LastCategory, string MethodName)
        {
            DocFileHtml = "xlcalcnet";

            string Ext = Path.GetExtension(ActiveFileName);
            string XMLCommentsFilePath = "";
            string AssemblyFilePath = "";

            string GetBinPath1 = GetBinPath();
            string GetBinPath2 = GetBinPath1.Replace("xlcalcnet", "xlcalcnet2");
            string GetBinPath3 = _LocalAppDataDir + @"\XlCalcNetIDE\Bin";

            if (((LastCategory.Length == 4) && LastCategory.EndsWith("lib")) && "sdeqo".Contains(LastCategory.Substring(0, 1)) || (LastCategory.Length == 5) && LastCategory.EndsWith("libc") && "sdeqo".Contains(LastCategory.Substring(0, 1)))
            {
                DocFileHtml = "userlibnet";
                XMLCommentsFilePath = GetBinPath3 + @"\UserFixedPrecNet.xml";
                AssemblyFilePath = GetBinPath3 + @"\UserFixedPrecNet.dll";
            }

            else if ((LastCategory == "math53lib") || (LastCategory == "cmath53lib"))
            {
                DocFileHtml = "userlibnet";
                XMLCommentsFilePath = GetBinPath3 + @"\UserFixedPrecNet.xml";
                AssemblyFilePath = GetBinPath3 + @"\UserFixedPrecNet.dll";
            }

            else if ((LastCategory == "mlib") || (LastCategory == "mlibc"))
            {
                DocFileHtml = "userlibnet";
                XMLCommentsFilePath = GetBinPath3 + @"\UserArbPrecNet.xml";
                AssemblyFilePath = GetBinPath3 + @"\UserArbPrecNet.dll";
            }

            else if (((LastCategory.Length == 9) && LastCategory.EndsWith("flintlib")) && "sdeqombia".Contains(LastCategory.Substring(0, 1)))
            {
                DocFileHtml = "userlibnet";
                XMLCommentsFilePath = GetBinPath3 + @"\UserArbPrecNet.xml";
                AssemblyFilePath = GetBinPath3 + @"\UserArbPrecNet.dll";
            }

            else if (((LastCategory.Length == 10) && LastCategory.EndsWith("flintlibc")) && "sdeqombia".Contains(LastCategory.Substring(0, 1)))
            {
                DocFileHtml = "userlibnet";
                XMLCommentsFilePath = GetBinPath3 + @"\UserArbPrecNet.xml";
                AssemblyFilePath = GetBinPath3 + @"\UserArbPrecNet.dll";
            }

            else if ((LastCategory == "npm") || (LastCategory == "mpm") || (LastCategory == "ipm") || (LastCategory == "fpm") || (LastCategory == "dpm") || (LastCategory == "gpm") || (LastCategory == "apm"))
            {
                DocFileHtml = "mpfunlab";
                XMLCommentsFilePath = GetBinPath1 + @"\MpPrecNet.xml";
                AssemblyFilePath = GetBinPath1 + @"\MpPrecNet.dll";
            }


            else if ((LastCategory == "math53") || (LastCategory == "cmath53"))
            {
                XMLCommentsFilePath = GetBinPath1 + @"\FixedPrecNet.xml";
                AssemblyFilePath = GetBinPath1 + @"\FixedPrecNet.dll";
            }

            else if (LastCategory.Length == 5)
            {
                string s14 = LastCategory.Substring(1, 4);

                if (((s14 == "real") || (s14 == "cplx")) && (LastCategory.Length == 5))
                {
                    string s0 = LastCategory.Substring(0, 1);
                    if ("sdeqo".Contains(s0))
                    {
                        XMLCommentsFilePath = GetBinPath1 + @"\FixedPrecNet.xml";
                        AssemblyFilePath = GetBinPath1 + @"\FixedPrecNet.dll";
                    }
                    else if ("m".Contains(s0))
                    {
                        XMLCommentsFilePath = GetBinPath2 + @"\ArbPrecNet.xml";
                        AssemblyFilePath = GetBinPath2 + @"\ArbPrecNet.dll";
                    }
                }
            }

            else if (LastCategory.Length >= 6)
            {
                string s16 = "";
                string s15 = LastCategory.Substring(1, 5);
                if (LastCategory.Length >= 7)
                    s16 = LastCategory.Substring(1, 6);
                if (((s15 == "flint") && (LastCategory.Length == 6)) || ((s16 == "flintc") && (LastCategory.Length == 7)))
                {
                    string s0 = LastCategory.Substring(0, 1);
                    if ("sdeqombia".Contains(s0))
                        XMLCommentsFilePath = GetBinPath2 + @"\ArbPrecNet.xml";
                    AssemblyFilePath = GetBinPath2 + @"\ArbPrecNet.dll";
                }
            }

            if (XMLCommentsFilePath == "")
            {
                InfoDataScintilla.ClearAll();
            }
            else
            {
                //tabControl1.SelectedTab = tabFunctionInfo;

                InfoDataScintilla.ReadOnly = false;
                InfoDataScintilla.ClearAll();

                var Assemblies = Assembly.LoadFile(AssemblyFilePath);
                var reader = new LoxSmoke.DocXml.DocXmlReader(XMLCommentsFilePath);

                var XLtypes = Assemblies.GetTypes();
                Type CurType;
                //string MethodName = e.Text;
                //MethodInfo minfo = null;
                for (int j = 0, loopTo1 = XLtypes.Count() - 1; j <= loopTo1; j++)
                {
                    var XName = XLtypes[j].Name;
                    if (XName.ToUpper() == LastCategory.ToUpper())
                    {
                        CurType = XLtypes[j];
                        foreach (MethodInfo m in CurType.GetMethods())
                        {
                            if (m.Name.ToUpper() == MethodName.ToUpper())
                            {

                                string ReturnedType = Clean_Parameter(m.ReturnType.ToString());
                                if (!string.IsNullOrWhiteSpace(ReturnedType))
                                {
                                    ReturnedType = ReturnedType.Replace("Numerics.", "");
                                    ReturnedType = ReturnedType.Replace("FixedPrecNet.", "");
                                    ReturnedType = ReturnedType.Replace("ArbPrecNet.", "");
                                }


                                string StrPara = LastCategory + "." + m.Name + "(";
                                ParameterInfo[] parameters = m.GetParameters();
                                for (int k = 0, loopTo3 = parameters.Count() - 1; k <= loopTo3; k++)
                                {
                                    if (parameters[k].IsIn)
                                    {
                                        StrPara += "";
                                    }
                                    else if (parameters[k].IsOptional)
                                    {
                                        StrPara += "Optional ";
                                    }
                                    else if (parameters[k].IsOut)
                                    {
                                        StrPara += "ByRef ";
                                    }
                                    else if (parameters[k].ParameterType.Name.Contains("&"))
                                    {
                                        StrPara += "ByRef ";
                                    }

                                    if (Ext == ".py")
                                    {
                                        StrPara += parameters[k].Name + ": " + Clean_Parameter(parameters[k].ParameterType.Name.Replace("&", "").Replace("[", "(").Replace("]", ")"));
                                    }
                                    else if (Ext == ".vb")
                                    {
                                        StrPara += parameters[k].Name + " As " + Clean_Parameter(parameters[k].ParameterType.Name.Replace("&", "").Replace("[", "(").Replace("]", ")"));
                                    }
                                    else if (Ext == ".cs")
                                    {
                                        StrPara += Clean_Parameter(parameters[k].ParameterType.Name.Replace("&", "").Replace("[", "(").Replace("]", ")")) + " " + parameters[k].Name;
                                        //if ((!string.IsNullOrWhiteSpace(ReturnedType)) && (k == 0))
                                        //{
                                        //    StrPara = ReturnedType + " " + StrPara;
                                        //}
                                    }

                                    if (k < parameters.Count() - 1)
                                        StrPara += ", ";
                                }
                                StrPara += ")";
                                //string ReturnedType = Clean_Parameter(m.ReturnType.ToString());

                                if (!string.IsNullOrWhiteSpace(ReturnedType))
                                {
                                    if (Ext == ".py")
                                    {
                                        StrPara += " -> " + ReturnedType;
                                    }
                                    else if (Ext == ".vb")
                                    {
                                        StrPara += " As " + ReturnedType;
                                    }
                                    else if (Ext == ".cs")
                                    {
                                        StrPara = ReturnedType + " " + StrPara;
                                    }
                                }

                                InfoDataScintilla.AppendText(StrPara + Environment.NewLine);
                                var comments = reader.GetMethodComments(m);

                                if (comments != null)
                                {
                                    var cs = comments.Summary;
                                    if (!string.IsNullOrWhiteSpace(cs))
                                    {
                                        InfoDataScintilla.AppendText(cs + Environment.NewLine + Environment.NewLine);
                                    }

                                    var clist = comments.Parameters;
                                    if (clist != null)
                                    {
                                        if (clist.Count > 0)
                                        {
                                            InfoDataScintilla.AppendText("Parameters:" + Environment.NewLine);
                                            foreach (var c in clist)
                                            {
                                                InfoDataScintilla.AppendText(c + Environment.NewLine);
                                            }
                                            InfoDataScintilla.AppendText(Environment.NewLine);
                                        }
                                    }

                                    var cr = comments.Returns;
                                    if (!string.IsNullOrWhiteSpace(cr))
                                    {
                                        InfoDataScintilla.AppendText("Returns:" + Environment.NewLine);
                                        cr = cr.Replace("<br />", "");
                                        cr = cr.Replace("<em>", "");
                                        cr = cr.Replace("</em>", "");
                                        InfoDataScintilla.AppendText(cr + Environment.NewLine);
                                    }
                                    var slist = comments.SeeAlso;
                                    if (slist.Count > 0)
                                    {
                                        //InfoDataScintilla.AppendText("See also:" + Environment.NewLine);
                                        //foreach (var s in slist)
                                        //{
                                        //    InfoDataScintilla.AppendText("§" + s.Text + "§" + Environment.NewLine);
                                        //}
                                        //InfoDataScintilla.AppendText(Environment.NewLine);

                                        MoreInfo = slist[0].Text;
                                        toolStripButtonMoreInfo.Visible = true;
                                    }
                                    else
                                    {
                                        MoreInfo = "";
                                        toolStripButtonMoreInfo.Visible = false;
                                    }

                                }
                            }
                        }
                        //minfo = CurType.GetMethod(MethodName);
                    }
                }

                InfoDataScintilla.ReadOnly = true;


            }
            //}

        }




        public void CallTipClick(object sender, CallTipClickEventArgs e)
        {
            if (e.CallTipClickType == CallTipClickType.DownArrow)
            {
                mSelectedCallTip += 1;
                UpdateCallTipsFromIndex();
            }
            if (e.CallTipClickType == CallTipClickType.UpArrow)
            {
                mSelectedCallTip -= 1;
                UpdateCallTipsFromIndex();
            }
        }


        public void AutoCSelection(object sender, AutoCSelectionEventArgs e)
        {
            //MessageBox.Show(e.Text);
            //ShowIntellisense(e.Text);
            if (LastWordsEntered != null && LastWordsEntered.Count() > 1 && (IsAccesOrDeclarationType() || IsOnlySuggestion()) && AutoC_ValidatedBySpace == true && e.Text.ToLower() != "as")
            {
                scintilla1.AutoCCancel();
            }
            AutoC_ValidatedBySpace = false;
        }


        public void CharAdded(object sender, CharAddedEventArgs e)
        {
            // there are a multiple selection
            if (scintilla1.Selections.Count > 1)
                return;

            IntelliSense(e.Char);

            InsertMatchedChars(e);

            // if return is pressed check previous line
            if (e.Char == (int)Keys.Enter & scintilla1.AutoCActive == false) // enter = 13
            {
                int WorkingLine = scintilla1.CurrentLine - 1;

            }
        }

        public void Delete(object sender, ModificationEventArgs e)
        {
            // If scintilla1.CallTipActive Then
            if (e.Text == ",")
            {
                mIndexCallTip -= 1;
                CallTipsHighLight();
            }
            // End If
        }



        private static bool IsBrace(int c)
        {
            switch (c)
            {
                case '(':
                case ')':
                case '[':
                case ']':
                case '{':
                case '}':
                case '<':
                case '>':
                    return true;
            }

            return false;
        }

        private void scintilla_UpdateUI(object sender, UpdateUIEventArgs e)
        {

            // Has the caret changed position?
            var caretPos = scintilla1.CurrentPosition;
            if (LastCaretPos != caretPos)
            {
                LastCaretPos = caretPos;
                var bracePos1 = -1;
                var bracePos2 = -1;

                // Is there a brace to the left or right?
                if (caretPos > 0 && IsBrace(scintilla1.GetCharAt(caretPos - 1)))
                    bracePos1 = (caretPos - 1);
                else if (IsBrace(scintilla1.GetCharAt(caretPos)))
                    bracePos1 = caretPos;

                if (bracePos1 >= 0)
                {
                    // Find the matching brace
                    bracePos2 = scintilla1.BraceMatch(bracePos1);
                    if (bracePos2 == Scintilla.InvalidPosition)
                    {
                        scintilla1.BraceBadLight(bracePos1);
                        scintilla1.HighlightGuide = 0;
                    }
                    else
                    {
                        scintilla1.BraceHighlight(bracePos1, bracePos2);
                        scintilla1.HighlightGuide = scintilla1.GetColumn(bracePos1);
                    }
                }
                else
                {
                    // Turn off brace matching
                    scintilla1.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                    scintilla1.HighlightGuide = 0;
                }
            }
        }


        private void ToggleBookmark(int Position)
        {
            // Do we have a marker for this line?
            const uint mask = (1 << BOOKMARK_MARKER);
            var line = scintilla1.Lines[scintilla1.LineFromPosition(Position)];
            if ((line.MarkerGet() & mask) > 0)
            {
                // Remove existing bookmark
                line.MarkerDelete(BOOKMARK_MARKER);
            }
            else
            {
                // Add bookmark
                line.MarkerAdd(BOOKMARK_MARKER);

            }
        }

        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                ToggleBookmark(e.Position);
            }
        }


        private void MyFindReplace_FindAllResults(object sender, FindResultsEventArgs FindAllResults)
        {
            // Pass on find results which will populate the screen.
            findAllResultsPanel1.UpdateFindAllResults(FindAllResults.FindReplace, FindAllResults.FindAllResults);
            tabControl1.SelectedTab = tabFind;
            findAllResultsPanel1.Visible = true;

        }



        #region Assemblies
        private void Init_Assembly()
        {
            mAssemblysCollection = new List<string>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!(assembly.IsDynamic))
                {
                    string location = assembly.Location;
                    if (!string.IsNullOrEmpty(location) && !mAssemblysCollection.Contains(location) && !(Path.GetExtension(location).ToLower() == ".exe"))
                    {
                        mAssemblysCollection.Add(location);
                    }
                }
            }

            string GetBinPath1 = GetBinPath();
            string GetBinPath2 = GetBinPath1.Replace("xlcalcnet", "xlcalcnet2");
            string GetBinPath3 = _LocalAppDataDir + @"\XlCalcNetIDE\Bin";

            Add_Assembly(GetBinPath1 + @"\FixedPrecNet.dll");
            Add_Assembly(GetBinPath1 + @"\MpPrecNet.dll");
            Add_Assembly(GetBinPath2 + @"\ArbPrecNet.dll");

            Add_Assembly(GetBinPath3 + @"\UserFixedPrecNet.dll");
            Add_Assembly(GetBinPath3 + @"\UserMpPrecNet.dll");
            Add_Assembly(GetBinPath3 + @"\UserArbPrecNet.dll");



        }

        public void Add_Assembly(string Location)
        {
            if (!string.IsNullOrEmpty(Location) && !mAssemblysCollection.Contains(Location) && !(Path.GetExtension(Location).ToLower() == ".exe"))
            {
                mAssemblysCollection.Add(Location);
            }
        }
        #endregion




        #region AutoCompletion
        private void IntelliSense(int CharAdded)
        {
            LastWordsEntered = GetLastWordWords(false);
            int CurrentPos = scintilla1.CurrentPosition;
            int WordStartPos = scintilla1.WordStartPosition(CurrentPos, true);
            int LenEntered = CurrentPos - WordStartPos;

            if (CharAdded == Strings.AscW('.') && LastWordsEntered != null && LastWordsEntered.Count() > 1)
            {
                string Variable = LastWordsEntered[1];
                LastCategory = Variable;
                var VariableFound = default(bool);
                string variableType = Search_Type(scintilla1.CurrentPosition, Variable, ref VariableFound);
                bool IsStatic = false;
                if ((variableType ?? "") == (Variable ?? ""))
                    IsStatic = true;

                if (scintilla1.AutoCActive)
                    scintilla1.AutoCCancel();
                bool argBypassSearch = false;
                //Struct_AutoComplete argReturnedValue = null;
                Struct_AutoComplete argReturnedValue = new Struct_AutoComplete
                {
                    Completion = ""
                };

                FoundType = AutoComplete(variableType, IsStatic, 1, BypassSearch: ref argBypassSearch, ReturnedValue: ref argReturnedValue);
                if (!string.IsNullOrEmpty(FoundType.Completion))
                {
                    scintilla1.AutoCShow(LenEntered, FoundType.Completion);
                    return;
                }
            }

            if (CharAdded == Strings.AscW('(') && FoundType.Parameters != null && FoundType.Parameters.Count > 0)
            {
                mIndexCallTip = 0;
                mSelectedCallTip = 0;
                mCallTipsFound.Clear();
                if (FoundType.Parameters.ContainsKey(LastWordsEntered[1]))
                {

                    foreach (string Keys in FoundType.Parameters.Keys)
                    {
                        if ((Keys.ToLower() ?? "") == (LastWordsEntered[1].ToLower() ?? ""))
                        {
                            string[] parameters = Strings.Split(FoundType.Parameters[Keys], Constants.vbLf);
                            for (int i = 0, loopTo1 = parameters.Count() - 1; i <= loopTo1; i++)
                                mCallTipsFound.Add(parameters[i]);
                            break;
                        }
                    }
                    UpdateCallTipsFromIndex();
                }
            }
            if (CharAdded == Strings.AscW(','))
            {
                mIndexCallTip += 1;
            }
            CallTipsHighLight();

            KeyWordsSelected = Keywords_Selector(LastWordsEntered, CharAdded);
            bool VariableExist = false;
            string SearchVariable = LastWordsEntered is null ? Conversions.ToString(Strings.ChrW(CharAdded)) : LastWordsEntered[0];
            Search_Type(scintilla1.CurrentPosition, SearchVariable, ref VariableExist);
            if (VariableExist == true)
                return;

            if (!string.IsNullOrEmpty(KeyWordsSelected))
            {
                if (!scintilla1.AutoCActive && !scintilla1.CallTipActive)
                {
                    scintilla1.AutoCShow(LenEntered, KeyWordsSelected);
                }
                else if (scintilla1.AutoCActive && LastWordsEntered != null && LastWordsEntered[0].ToLower().Contains("(") && !scintilla1.CallTipActive)
                {
                    scintilla1.AutoCShow(LenEntered, KeyWordsSelected);
                }
            }
        }

        private void UpdateCallTipsFromIndex()
        {
            if (mCallTipsFound.Count == 0)
                return;
            if (mSelectedCallTip < 0)
                mSelectedCallTip = 0;
            if (mSelectedCallTip > mCallTipsFound.Count - 1)
                mSelectedCallTip = mCallTipsFound.Count - 1;
            string CurrentCallTips = mCallTipsFound[mSelectedCallTip];
            string Arrowtext = Conversions.ToString('\u0001') + (mSelectedCallTip + 1) + " of " + mCallTipsFound.Count + '\u0002';
            GetPositionArgument(CurrentCallTips);
            scintilla1.CallTipShow(scintilla1.CurrentPosition - LastWordsEntered[1].Length, Arrowtext + CurrentCallTips);
            CallTipsHighLight();
        }

        private void CallTipsHighLight()
        {
            try
            {
                if (scintilla1.CallTipActive)
                {
                    if (mIndexCallTip < 0)
                        mIndexCallTip = 0;
                    if (mIndexCallTip <= mCallTipsPos.Count - 1)
                    {
                        string Arrowtext = Conversions.ToString('\u0001') + (mSelectedCallTip + 1) + " of " + mCallTipsFound.Count + '\u0002';
                        scintilla1.CallTipSetHlt(mCallTipsPos[mIndexCallTip].Start + Arrowtext.Length, mCallTipsPos[mIndexCallTip].End + Arrowtext.Length);
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        private Struct_AutoComplete AutoComplete(string VariableType, bool isStatic, int CurrentWordIndex, ref bool BypassSearch, ref Struct_AutoComplete ReturnedValue)
        {
            string Ext = Path.GetExtension(ActiveFileName);

            if (BypassSearch == true)
                return ReturnedValue;
            if (string.IsNullOrWhiteSpace(VariableType))
                return default;

            if ((VariableType == "1") || (VariableType == "2"))
                return default;

            // VariableType = ToRealType(VariableType)

            Struct_AutoComplete FinalStruct = default;
            FinalStruct.Parameters = new Dictionary<string, string>();

            var bindStatic = BindingFlags.Instance;
            if (isStatic)
                bindStatic = BindingFlags.Static;

            var result = new List<string>();
            for (int i = 0, loopTo = mAssemblysCollection.Count - 1; i <= loopTo; i++)
            {
                try
                {

                    string assembly_File = mAssemblysCollection[i];
                    // If Exclude_Assembly(assembly_File) = False Then Continue For

                    // load assembly
                    var Assemblies = Assembly.LoadFile(assembly_File);
                    var name = Assemblies.GetName(true);

                    Type[] types = Assemblies.GetTypes();
                    for (int j = 0, loopTo1 = types.Count() - 1; j <= loopTo1; j++)
                    {
                        // we dont want private member or generic
                        if (types[j].IsPublic == false)
                            continue;
                        if (types[j].IsGenericTypeDefinition == true)
                            continue;

                        if (types[j].FullName != null && types[j].FullName.ToLower().Contains(VariableType.ToLower() + "."))
                        {

                            string AssemblyPath = null;

                            // if fullname start with VariableType & "."
                            int posName = types[j].FullName.IndexOf(VariableType.ToLower() + ".", StringComparison.OrdinalIgnoreCase);
                            if (posName > -1)
                            {
                                AssemblyPath = types[j].FullName.Substring(posName + (VariableType.ToLower() + ".").Length);
                            }
                            else if (types[j].FullName.ToLower().Contains(VariableType.ToLower() + "."))
                            {
                                AssemblyPath = types[j].FullName;
                            }
                            else
                            {
                                AssemblyPath = ".";

                            }

                            string assemblyName = Strings.Split(AssemblyPath, ".")[0];
                            assemblyName = Strings.Split(assemblyName, ".")[0];

                            //MessageBox.Show(assemblyName);

                            bool AddMe = true;
                            for (int r = 0, loopTo2 = result.Count - 1; r <= loopTo2; r++)
                            {
                                // if there are already something it is probably a Namespace
                                if (result[r].StartsWith(assemblyName + "?"))
                                {
                                    result[r] = assemblyName + "?" + ((int)IndexType.Namespace).ToString();
                                    AddMe = false;
                                    break;
                                }
                            }
                            if (AddMe == true)
                            {
                                result.Add(assemblyName + "?" + GetTypeIndex(types[j]).ToString());
                            }
                        }

                        if ((types[j].Name.ToLower() ?? "") == (VariableType.ToLower() ?? ""))
                        {
                            foreach (PropertyInfo p in types[j].GetProperties())
                            {
                                if (!result.Contains(p.Name + "?" + ((int)IndexType.Property).ToString()))
                                {
                                    result.Add(p.Name + "?" + ((int)IndexType.Property).ToString());
                                }
                            }

                            foreach (MethodInfo m in types[j].GetMethods())
                            {
                                //if (m.IsStatic == isStatic && !m.Name.StartsWith("op_"))
                                if (m.IsStatic == isStatic && !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_") && !m.Name.StartsWith("op_"))
                                {

                                    string ReturnedType = Clean_Parameter(m.ReturnType.ToString());
                                    if (!string.IsNullOrWhiteSpace(ReturnedType))
                                    {
                                        ReturnedType = ReturnedType.Replace("Numerics.", "");
                                        ReturnedType = ReturnedType.Replace("FixedPrecNet.", "");
                                        ReturnedType = ReturnedType.Replace("ArbPrecNet.", "");
                                    }

                                    string StrPara = m.Name + "(";
                                    ParameterInfo[] parameters = m.GetParameters();
                                    for (int k = 0, loopTo3 = parameters.Count() - 1; k <= loopTo3; k++)
                                    {
                                        if (parameters[k].IsIn)
                                        {
                                            StrPara += "";
                                        }
                                        else if (parameters[k].IsOptional)
                                        {
                                            StrPara += "Optional ";
                                        }
                                        else if (parameters[k].IsOut)
                                        {
                                            StrPara += "ByRef ";
                                        }
                                        else if (parameters[k].ParameterType.Name.Contains("&"))
                                        {
                                            StrPara += "ByRef ";
                                        }

                                        if (Ext == ".py")
                                        {
                                            StrPara += parameters[k].Name + ": " + Clean_Parameter(parameters[k].ParameterType.Name.Replace("&", "").Replace("[", "(").Replace("]", ")"));
                                        }
                                        else if (Ext == ".vb")
                                        {
                                            StrPara += parameters[k].Name + " As " + Clean_Parameter(parameters[k].ParameterType.Name.Replace("&", "").Replace("[", "(").Replace("]", ")"));
                                        }
                                        else if (Ext == ".cs")
                                        {
                                            StrPara += Clean_Parameter(parameters[k].ParameterType.Name.Replace("&", "").Replace("[", "(").Replace("]", ")")) + " " + parameters[k].Name;
                                        }



                                        if (k < parameters.Count() - 1)
                                            StrPara += ", ";
                                    }
                                    StrPara += ")";
                                    //string ReturnedType = Clean_Parameter(m.ReturnType.ToString());

                                    if (!string.IsNullOrWhiteSpace(ReturnedType))
                                    {
                                        if (Ext == ".py")
                                        {
                                            StrPara += " -> " + ReturnedType;
                                        }
                                        else if (Ext == ".vb")
                                        {
                                            StrPara += " As " + ReturnedType;
                                        }
                                        else if (Ext == ".cs")
                                        {
                                            StrPara = ReturnedType + " " + StrPara;
                                        }
                                    }

                                    if (FinalStruct.Parameters.ContainsKey(m.Name))
                                    {
                                        FinalStruct.Parameters[m.Name] += Constants.vbLf + StrPara;
                                    }
                                    else
                                    {
                                        FinalStruct.Parameters.Add(m.Name, StrPara);
                                    }
                                    if (!result.Contains(m.Name + "?" + ((int)IndexType.Method).ToString()))
                                    {
                                        result.Add(m.Name + "?" + ((int)IndexType.Method).ToString());
                                    }

                                }
                            }

                            foreach (MemberInfo m in types[j].GetMembers(bindStatic))
                            {
                                if (!m.Name.StartsWith("get_") && !m.Name.StartsWith("set_") && !m.Name.StartsWith("op_"))
                                {
                                    if (!result.Contains(m.Name + "?" + ((int)IndexType.Member).ToString()))
                                    {
                                        result.Add(m.Name + "?" + ((int)IndexType.Member).ToString());
                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception)
                {

                    //throw;
                }

            } // for loop

            // it can be a class
            if (result.Count == 0)
            {
                // get last word (before dot)
                bool IsNotWord = true;
                int previous_Index = CurrentWordIndex;
                string previous_word = "";

                while (IsNotWord)
                {
                    if (previous_Index > LastWordsEntered.Count() - 1)
                        return default;

                    previous_word = LastWordsEntered[previous_Index];
                    for (int w = 0, loopTo4 = previous_word.Count() - 1; w <= loopTo4; w++)
                    {
                        // if it is a word
                        if (mAlphabet.Contains(Conversions.ToString(previous_word.ToLower()[w])))
                        {
                            IsNotWord = false;
                            break;
                        }
                    }
                    previous_Index += 1;
                }

                bool PrevVariableFound = false;
                string PrevVariableType = Search_Type(scintilla1.CurrentPosition, previous_word, ref PrevVariableFound);
                bool PrevIsStatic = false;

                if ((PrevVariableType ?? "") == (previous_word ?? ""))
                    PrevIsStatic = true;
                var FoundClass = AutoComplete(PrevVariableType, PrevIsStatic, previous_Index, ref BypassSearch, ref ReturnedValue);

                if (string.IsNullOrEmpty(FoundClass.Completion))
                    return default;

                string returnedType = FoundClass.ReturnedType(VariableType);
                var FinalFound = AutoComplete(returnedType, false, previous_Index, ref BypassSearch, ref ReturnedValue);
                if (!string.IsNullOrEmpty(FinalFound.Completion) && !string.IsNullOrEmpty(returnedType))
                {
                    BypassSearch = true;
                    ReturnedValue = FinalFound;
                }
                return FinalFound;
            }

            result.Sort();
            string OutText = string.Join(" ", result);

            result.Clear();
            result = null;
            FinalStruct.Completion = Strings.Trim(OutText);
            return FinalStruct;
        }

        private int GetTypeIndex(Type T)
        {
            if (T.IsEnum)
                return (int)IndexType.Enum;
            if (T.IsClass)
                return (int)IndexType.Class;
            if (T.IsLayoutSequential)
                return (int)IndexType.Structure;
            return (int)IndexType.Namespace;
        }

        private void InsertMatchedChars(CharAddedEventArgs e)
        {
            int caretPos = scintilla1.CurrentPosition;
            bool docStart = caretPos == 1;
            bool docEnd = caretPos == scintilla1.Text.Length;
            int charPrev = docStart ? scintilla1.GetCharAt(caretPos) : scintilla1.GetCharAt(caretPos - 2);
            int charNext = scintilla1.GetCharAt(caretPos);
            bool isCharPrevBlank = charPrev == Strings.AscW(' ') || charPrev == Strings.AscW(Constants.vbTab) || charPrev == Strings.AscW(Constants.vbLf) || charPrev == Strings.AscW(Constants.vbCr);
            bool isCharNextBlank = charNext == Strings.AscW(' ') || charNext == Strings.AscW(Constants.vbTab) || charNext == Strings.AscW(Constants.vbLf) || charNext == Strings.AscW(Constants.vbCr) || docEnd;
            bool isEnclosed = charPrev == Strings.AscW('(') && charNext == Strings.AscW(')') || charPrev == Strings.AscW('{') && charNext == Strings.AscW('}') || charPrev == Strings.AscW('[') && charNext == Strings.AscW(']');
            bool isSpaceEnclosed = charPrev == Strings.AscW('(') && isCharNextBlank || isCharPrevBlank && charNext == Strings.AscW(')') || charPrev == Strings.AscW('{') && isCharNextBlank || isCharPrevBlank && charNext == Strings.AscW('}') || charPrev == Strings.AscW('[') && isCharNextBlank || isCharPrevBlank && charNext == Strings.AscW(']');
            bool isCharOrString = isCharPrevBlank && isCharNextBlank || isEnclosed || isSpaceEnclosed;
            bool charNextIsCharOrString = charNext == Strings.AscW('"') || charNext == Strings.AscW('\'');

            switch (e.Char)
            {
                case var @case when @case == Strings.AscW('('):
                    {
                        if (charNextIsCharOrString)
                            return;
                        scintilla1.InsertText(caretPos, ")");
                        break;
                    }
                case var case1 when case1 == Strings.AscW('{'):
                    {
                        if (charNextIsCharOrString)
                            return;
                        scintilla1.InsertText(caretPos, "}");
                        break;
                    }
                case var case2 when case2 == Strings.AscW('['):
                    {
                        if (charNextIsCharOrString)
                            return;
                        scintilla1.InsertText(caretPos, "]");
                        break;
                    }
                case var case3 when case3 == Strings.AscW('"'):
                    {
                        if (charPrev == 0x22 && charNext == 0x22)
                        {
                            scintilla1.DeleteRange(caretPos, 1);
                            scintilla1.GotoPosition(caretPos);
                            return;
                        }

                        if (isCharOrString)
                            scintilla1.InsertText(caretPos, "\"");
                        break;
                    }
                case var case4 when case4 == Strings.AscW(')'):
                    {
                        if (charNext == Strings.AscW(')'))
                        {
                            scintilla1.DeleteRange(caretPos, 1);
                            scintilla1.GotoPosition(caretPos);
                        }
                        break;
                    }
                case var case5 when case5 == Strings.AscW('}'):
                    {
                        if (charNext == Strings.AscW('}'))
                        {
                            scintilla1.DeleteRange(caretPos, 1);
                            scintilla1.GotoPosition(caretPos);
                        }
                        break;
                    }
                case var case6 when case6 == Strings.AscW(']'):
                    {
                        if (charNext == Strings.AscW(']'))
                        {
                            scintilla1.DeleteRange(caretPos, 1);
                            scintilla1.GotoPosition(caretPos);
                        }
                        break;
                    }
                case var case7 when case7 == Strings.AscW('"'):
                    {
                        if (charNext == Strings.AscW('"'))
                        {
                            scintilla1.DeleteRange(caretPos, 1);
                            scintilla1.GotoPosition(caretPos);
                        }
                        break;
                    }
            }
        }

        private string Search_Type(int CarretPosition, string Variable, ref bool Founded)
        {
            bool IsNotWord = true;
            for (int w = 0, loopTo = Variable.Count() - 1; w <= loopTo; w++)
            {
                if (mAlphabet.Contains(Conversions.ToString(Variable.ToLower()[w])))
                {
                    IsNotWord = false;
                    break;
                }
            }
            if (IsNotWord == true)
                return Variable;

            Founded = false;
            scintilla1.TargetStart = CarretPosition;
            scintilla1.TargetEnd = 0;
            scintilla1.SearchFlags = SearchFlags.WholeWord;

            int PositionFound = scintilla1.SearchInTarget(Variable);

            int currentLine = scintilla1.LineFromPosition(CarretPosition);

            while (PositionFound > -1)
            {
                currentLine = scintilla1.LineFromPosition(PositionFound);

                string check_line = scintilla1.Lines[currentLine].Text;

                // clean line
                check_line = Strings.Trim(check_line.Replace(Constants.vbCr, "").Replace(Constants.vbLf, "").Replace("vbcrlf", "").Replace(Constants.vbTab, "")).ToLower();


                scintilla1.TargetStart = PositionFound - 1;
                scintilla1.TargetEnd = 0;
                PositionFound = scintilla1.SearchInTarget(Variable);
            }


            return Variable;
        }


        private void GetPositionArgument(string text)
        {
            if (mCallTipsPos is null)
            {
                mCallTipsPos = new List<Struct_CallTips>();
            }
            else
            {
                mCallTipsPos.Clear();
            }
            bool Searching = true;
            int StartPos = text.IndexOf("(");
            int EndPos = text.IndexOf(",");
            if (EndPos == -1)
            {
                EndPos = text.IndexOf(")", StartPos);
                Searching = false;
            }
            Struct_CallTips structPos;
            structPos.Start = StartPos;
            structPos.End = EndPos;
            mCallTipsPos.Add(structPos);


            while (Searching)
            {
                StartPos = mCallTipsPos[mCallTipsPos.Count - 1].End + 1;
                EndPos = text.IndexOf(",", StartPos);
                if (EndPos == -1)
                {
                    Searching = false;
                    EndPos = text.IndexOf(")", StartPos);
                }
                structPos.Start = StartPos;
                structPos.End = EndPos;
                mCallTipsPos.Add(structPos);
            }
        }

        private string Keywords_Selector(string[] LastWords, int CharAdded)
        {

            switch (mCurrentBlock.type ?? "")
            {
                case var @case when @case == "":
                    {
                        if (CharAdded == (int)Keys.Space)
                        {
                            if (IsEmptyText(scintilla1.Lines[scintilla1.CurrentLine].Text) && (LastWords is null || LastWords.Count() == 0))
                            {
                                return "";
                            }
                        }
                        if (LastWords != null && LastWords.Count() == 1 && !(LastWords[0].ToLower() == "imports"))
                        {
                            return "";
                        }
                        break;
                    }

            }

            return "";
        }




        private string[] GetLastWordWords(bool SkipFirst)
        {
            string[] Words = null;
            int pos = scintilla1.CurrentPosition;

            //bool EndLine = false;
            string tmp = "";
            char f = new char();
            string CurrentWord = "";
            while (pos > scintilla1.Lines[scintilla1.CurrentLine].Position)
            {
                pos -= 1;
                tmp = scintilla1.Text.Substring(pos, 1);
                f = tmp[0];
                if (mKeywords_endline.Contains(Conversions.ToString(f)))
                {
                    //EndLine = true;
                    break;
                }

                if (mWord_Separator.Contains(f))
                {
                    AddWord_Tolist(ref Words, CurrentWord);
                    AddWord_Tolist(ref Words, Conversions.ToString(f));
                    CurrentWord = "";
                }
                else
                {
                    CurrentWord += Conversions.ToString(f);
                }

            }

            AddWord_Tolist(ref Words, CurrentWord);

            return SkipFirst ? Words.Skip(1).ToArray() : Words;
        }

        private bool IsAccesOrDeclarationType()
        {
            if (LastWordsEntered[0] == "(" || LastWordsEntered[0] == ",")
                return true;
            if (LastWordsEntered[1] == "(" || LastWordsEntered[1] == ",")
                return true;
            return false;
        }

        private bool IsOnlySuggestion()
        {
            if (LastWordsEntered[1].ToLower() == "for" | LastWordsEntered[1].ToLower() == "do")
                return true;
            return false;
        }

        #endregion



        #region Text changer

        private void AddWord_Tolist(ref string[] List, string word)
        {
            char[] ca = word.ToCharArray();
            Array.Reverse(ca);
            word = new string(ca);

            word = word.Trim().Replace(Constants.vbTab, "");

            if (string.IsNullOrEmpty(word))
                return;
            if (List is null)
            {
                Array.Resize(ref List, 1);
            }
            else
            {
                Array.Resize(ref List, List.Count() + 1);
            }
            List[List.Count() - 1] = word;
        }


        private bool IsEmptyText(string Text)
        {
            if (string.IsNullOrEmpty(Text.Replace(" ", "").Replace(Constants.vbTab, "").Replace(Constants.vbCrLf, "")))
            {
                return true;
            }
            return false;
        }

        private string Clean_Parameter(string Parameter)
        {
            Parameter = Parameter.Replace("System.Void", "");
            Parameter = Parameter.Replace("System.", "");
            return Parameter;
        }



        #endregion




        #region Set SyntaxColoring

        private void InitSyntaxColoring()
        {


            // Configure the default style
            scintilla1.StyleClearAll();




            //scintilla1.StyleResetDefault();

            scintilla1.IndentWidth = 4;

            scintilla1.SelectionBackColor = Color.LightBlue;
            scintilla1.SelectionInactiveBackColor = Color.LightGray;
            scintilla1.CaretForeColor = Color.Black;
            scintilla1.CaretWidth = 30;

            Color backColor = Color.White;

            //string FontName = richTextBoxLog.Font.Name;
            //float FontSize = richTextBoxLog.Font.Size;
            //fontToolStripMenuItem.ToolTipText = FontName + "; " + FontSize.ToString() + "pt";


            float FontSize = 10.125F;
            var NewFont = new System.Drawing.Font("Consolas", FontSize);
            string FontName = NewFont.Name;


            scintilla1.Styles[Style.Default].Font = FontName;
            scintilla1.Styles[Style.Default].SizeF = FontSize;
            scintilla1.Styles[Style.Default].BackColor = backColor;
            scintilla1.Styles[Style.Default].ForeColor = Color.Black;
            scintilla1.CaretForeColor = Color.Black;
            scintilla1.CaretLineBackColor = Color.OldLace;

            scintilla1.Styles[Style.BraceLight].BackColor = Color.LightGray;
            scintilla1.Styles[Style.BraceLight].ForeColor = Color.Black;
            scintilla1.Styles[Style.BraceLight].Font = FontName;
            scintilla1.Styles[Style.BraceLight].SizeF = FontSize;

            scintilla1.Styles[Style.BraceBad].BackColor = Color.LightGray;
            scintilla1.Styles[Style.BraceBad].ForeColor = Color.Red;
            scintilla1.Styles[Style.BraceBad].Font = FontName;
            scintilla1.Styles[Style.BraceBad].SizeF = FontSize;

            scintilla1.Styles[Style.LineNumber].Font = FontName;
            scintilla1.Styles[Style.LineNumber].SizeF = FontSize;


            // Reset number margin
            var nmargin = scintilla1.Margins[NUMBER_MARGIN];
            //nmargin.Width = (toolStripButtonRun.Width * 1);
            nmargin.Width = (toolStripDropDownButtonFile.Width * 16) / 10;
            nmargin.Type = MarginType.Number;
            nmargin.Sensitive = false;
            nmargin.Mask = 0;
            nmargin.Cursor = MarginCursor.Arrow;


            // Reset bookmark margin
            var bmargin = scintilla1.Margins[BOOKMARK_MARGIN];
            bmargin.Width = 20;
            bmargin.Sensitive = true;
            bmargin.Type = MarginType.Symbol;
            bmargin.Mask = (1 << BOOKMARK_MARKER);
            bmargin.Cursor = MarginCursor.Arrow;

            var bmarker = scintilla1.Markers[BOOKMARK_MARKER];
            bmarker.Symbol = MarkerSymbol.Bookmark;
            bmarker.SetBackColor(Color.DarkCyan);
            bmarker.SetAlpha(100);

            // Reset folder margin
            var fmargin = scintilla1.Margins[FOLDING_MARGIN];
            fmargin.Type = MarginType.Symbol;
            fmargin.Mask = Marker.MaskFolders;
            fmargin.Sensitive = true;
            fmargin.Width = 20;
            fmargin.Cursor = MarginCursor.Arrow;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                scintilla1.Markers[i].SetForeColor(Color.Green); // styles for [+] and [-]
                scintilla1.Markers[i].SetBackColor(Color.Black); // styles for [+] and [-]
            }

            // Style the folder markers
            scintilla1.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla1.Markers[Marker.Folder].SetBackColor(SystemColors.Control);
            scintilla1.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla1.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla1.Markers[Marker.FolderEnd].SetBackColor(SystemColors.Control);
            scintilla1.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla1.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla1.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla1.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            scintilla1.AutoCIgnoreCase = true;
            scintilla1.AutoCAutoHide = false;

            // Configure folding markers with respective symbols
            scintilla1.Markers[Marker.FolderEnd].SetBackColor(Color.Black);
            scintilla1.Markers[Marker.FolderEnd].SetForeColor(Color.Orange);

            // Enable automatic folding
            scintilla1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);


            // calltips style
            scintilla1.Styles[Style.CallTip].BackColor = Color.LightYellow;
            scintilla1.Styles[Style.CallTip].ForeColor = Color.Black;
            scintilla1.Styles[Style.CallTip].Bold = true;
            scintilla1.CallTipSetForeHlt(Color.FromArgb(86, 156, 214));
            //scintilla1.CallTipSetForeHlt(Color.Blue);



            scintilla1.Styles[WARNING_ANNOTATION].BackColor = Color.Moccasin;
            scintilla1.Styles[WARNING_ANNOTATION].ForeColor = Color.Black;
            scintilla1.Styles[WARNING_ANNOTATION].Italic = true;

            scintilla1.Styles[ERROR_ANNOTATION].BackColor = Color.MistyRose;
            scintilla1.Styles[ERROR_ANNOTATION].ForeColor = Color.Black;
            scintilla1.Styles[ERROR_ANNOTATION].Italic = true;


            // See https://github.com/jacobslusser/ScintillaNET/blob/master/docs/sections/indicators.md
            // Define an indicator
            scintilla1.Indicators[WARNING_INDICATOR].Style = IndicatorStyle.RoundBox;
            scintilla1.Indicators[WARNING_INDICATOR].ForeColor = Color.DarkOrange;

            scintilla1.Indicators[ERROR_INDICATOR].Style = IndicatorStyle.RoundBox;
            scintilla1.Indicators[ERROR_INDICATOR].ForeColor = Color.DarkRed;





            #region Python specific syntax coloring

            if (ScriptType.Contains("Python"))
            {
                //MessageBox.Show("Using Python Lexer");
                CommentStr = "#";
                //scintilla1.Lexer = Lexer.Python;
                //MessageBox.Show(scintilla1.LexerName);
                scintilla1.LexerName = "python";

                scintilla1.EdgeMode = EdgeMode.Line;
                scintilla1.EdgeColumn = 80;
                scintilla1.EdgeColor = Color.Black;


                scintilla1.SetKeywords(0, "and as assert break class continue def del elif else except exec finally for from global if import in is lambda not or pass print raise return try while with yield False None True self int float complex object");

                scintilla1.SetKeywords(1, XlCalcKeyWords1 + XlCalcKeyWords2 + " np53 np53c ");

                scintilla1.Styles[Style.Python.Default].BackColor = backColor;
                scintilla1.Styles[Style.Python.Default].ForeColor = Color.Black;
                scintilla1.Styles[Style.Python.Default].Bold = false;
                scintilla1.Styles[Style.Python.Default].Italic = false;
                scintilla1.Styles[Style.Python.Default].Underline = false;
                scintilla1.Styles[Style.Python.Default].Font = FontName;
                scintilla1.Styles[Style.Python.Default].SizeF = FontSize;

                // Set the styles
                scintilla1.Styles[Style.Python.CommentLine].ForeColor = Color.Green;
                scintilla1.Styles[Style.Python.CommentLine].Italic = true;
                scintilla1.Styles[Style.Python.CommentLine].Font = FontName;
                scintilla1.Styles[Style.Python.CommentLine].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Number].ForeColor = Color.FromArgb(255, 0xE2, 0x89, 0x13); // Golden Bell
                scintilla1.Styles[Style.Python.Number].Font = FontName;
                scintilla1.Styles[Style.Python.Number].SizeF = FontSize;

                scintilla1.Styles[Style.Python.String].ForeColor = Color.Red;
                scintilla1.Styles[Style.Python.String].Font = FontName;
                scintilla1.Styles[Style.Python.String].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Character].ForeColor = Color.FromArgb(255, 163, 21, 21);
                scintilla1.Styles[Style.Python.Character].Font = FontName;
                scintilla1.Styles[Style.Python.Character].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Word].ForeColor = Color.Blue;
                //scintilla1.Styles[Style.Python.Word].Bold = true;
                scintilla1.Styles[Style.Python.Word].Font = FontName;
                scintilla1.Styles[Style.Python.Word].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Triple].ForeColor = Color.FromArgb(0x7F, 0x00, 0x7F);
                scintilla1.Styles[Style.Python.Triple].Font = FontName;
                scintilla1.Styles[Style.Python.Triple].SizeF = FontSize;

                //scintilla1.Styles[Style.Python.TripleDouble].ForeColor = Color.DarkGray;
                scintilla1.Styles[Style.Python.TripleDouble].ForeColor = Color.FromArgb(255, 128, 128, 128);
                scintilla1.Styles[Style.Python.TripleDouble].Font = FontName;
                scintilla1.Styles[Style.Python.TripleDouble].SizeF = FontSize;

                scintilla1.Styles[Style.Python.ClassName].ForeColor = Color.Black;
                scintilla1.Styles[Style.Python.ClassName].Bold = true;
                scintilla1.Styles[Style.Python.ClassName].Font = FontName;
                scintilla1.Styles[Style.Python.ClassName].SizeF = FontSize;

                scintilla1.Styles[Style.Python.DefName].ForeColor = Color.Black;
                scintilla1.Styles[Style.Python.DefName].Bold = true;
                scintilla1.Styles[Style.Python.DefName].Font = FontName;
                scintilla1.Styles[Style.Python.DefName].SizeF = FontSize;

                //scintilla1.Styles[Style.Python.Operator].Bold = true;
                scintilla1.Styles[Style.Python.Operator].Font = FontName;
                scintilla1.Styles[Style.Python.Operator].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Identifier].ForeColor = Color.Black;
                scintilla1.Styles[Style.Python.Identifier].Font = FontName;
                scintilla1.Styles[Style.Python.Identifier].SizeF = FontSize;

                scintilla1.Styles[Style.Python.CommentBlock].ForeColor = Color.Black;
                scintilla1.Styles[Style.Python.CommentBlock].Italic = true;
                scintilla1.Styles[Style.Python.CommentBlock].Font = FontName;
                scintilla1.Styles[Style.Python.CommentBlock].SizeF = FontSize;

                scintilla1.Styles[Style.Python.StringEol].ForeColor = Color.FromArgb(0x00, 0x00, 0x00);
                scintilla1.Styles[Style.Python.StringEol].BackColor = Color.FromArgb(0xE0, 0xC0, 0xE0);
                scintilla1.Styles[Style.Python.StringEol].FillLine = true;
                scintilla1.Styles[Style.Python.StringEol].Font = FontName;
                scintilla1.Styles[Style.Python.StringEol].SizeF = FontSize;

                //scintilla1.Styles[Style.Python.Word2].ForeColor = Color.FromArgb(0x80, 0x50, 0x00);
                scintilla1.Styles[Style.Python.Word2].ForeColor = Color.DarkCyan;
                scintilla1.Styles[Style.Python.Word2].Font = FontName;
                scintilla1.Styles[Style.Python.Word2].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Decorator].ForeColor = Color.FromArgb(0x80, 0x50, 0x00);
                scintilla1.Styles[Style.Python.Decorator].Font = FontName;
                scintilla1.Styles[Style.Python.Decorator].SizeF = FontSize;

                // http://proton-ce.sourceforge.net/rc/scintilla/pyframe/www.pyframe.com/stc/lexing.html
                //Note: "tab.timmy.whinge.level" is a setting that determines how to indicate bad indentation.
                //    0 = ignore(default)
                //    1 = inconsistent
                //    2 = mixed spaces / tabs
                //    3 = spaces are bad
                //    4 = tabs are bad
                scintilla1.SetProperty("tab.timmy.whinge.level", "1");
                scintilla1.SetProperty("strip.trailing.spaces.*.py", "1");
                // Enable code folding
                scintilla1.SetProperty("fold", "1");

                // Does not display empty lines between folded items
                scintilla1.SetProperty("fold.compact", "1");
                //scintilla1.SetProperty("fold.comment.python", "1");
                //scintilla1.SetProperty("fold.quotes.python", "1");
            }

            #endregion


            #region BibTex specific syntax coloring

            if (ScriptType.Contains("Bib"))
            {
                //MessageBox.Show("Using Python Lexer");
                CommentStr = "#";
                scintilla1.LexerName = "python";
                scintilla1.EdgeMode = EdgeMode.None;

                scintilla1.SetKeywords(0, "author title journal year volume pages publisher note issn doi keywords howpublished edition issue_date month number numpages url acmid address archiveprefix eprint adsurl adsnote language booktitle series location isbn editor");

                scintilla1.Styles[Style.Python.Default].BackColor = backColor;
                scintilla1.Styles[Style.Python.Default].ForeColor = Color.Black;
                scintilla1.Styles[Style.Python.Default].Bold = false;
                scintilla1.Styles[Style.Python.Default].Italic = false;
                scintilla1.Styles[Style.Python.Default].Underline = false;
                scintilla1.Styles[Style.Python.Default].Font = FontName;
                scintilla1.Styles[Style.Python.Default].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Number].ForeColor = Color.SaddleBrown;
                scintilla1.Styles[Style.Python.Number].Font = FontName;
                scintilla1.Styles[Style.Python.Number].SizeF = FontSize;

                scintilla1.Styles[Style.Python.String].ForeColor = Color.DarkRed;
                scintilla1.Styles[Style.Python.String].Font = FontName;
                scintilla1.Styles[Style.Python.String].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Word].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Python.Word].Font = FontName;
                scintilla1.Styles[Style.Python.Word].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Decorator].ForeColor = Color.Black;
                scintilla1.Styles[Style.Python.Decorator].Font = FontName;
                scintilla1.Styles[Style.Python.Decorator].SizeF = FontSize;
                scintilla1.Styles[Style.Python.Decorator].Bold = true;

                // http://proton-ce.sourceforge.net/rc/scintilla/pyframe/www.pyframe.com/stc/lexing.html
                scintilla1.SetProperty("tab.timmy.whinge.level", "1");
                scintilla1.SetProperty("strip.trailing.spaces.*.py", "1");
                // Enable code folding
                scintilla1.SetProperty("fold", "1");

                // Does not display empty lines between folded items
                scintilla1.SetProperty("fold.compact", "1");
            }

            #endregion





            #region CSharp specific syntax coloring

            if (ScriptType.Contains("CSharp"))
            {
                //MessageBox.Show("Using CSharp Lexer");
                CommentStr = "//";
                //scintilla1.Lexer = Lexer.Cpp;
                scintilla1.LexerName = "cpp";

                scintilla1.EdgeMode = EdgeMode.Line;
                scintilla1.EdgeColumn = 80;
                scintilla1.EdgeColor = Color.Black;

                scintilla1.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double ascending descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield Object String Int32 Int64 Boolean join on equals let");

                scintilla1.SetKeywords(1, XlCalcKeyWords1 + XlCalcKeyWords2 + " Program DllImport xcn");


                scintilla1.Styles[Style.Cpp.Default].BackColor = backColor;
                scintilla1.Styles[Style.Cpp.Default].ForeColor = Color.Black;
                scintilla1.Styles[Style.Cpp.Default].Bold = false;
                scintilla1.Styles[Style.Cpp.Default].Italic = false;
                scintilla1.Styles[Style.Cpp.Default].Underline = false;
                scintilla1.Styles[Style.Cpp.Default].Font = FontName;
                scintilla1.Styles[Style.Cpp.Default].SizeF = FontSize;

                scintilla1.Styles[Style.Cpp.Character].SizeF = FontSize;

                scintilla1.Styles[Style.Cpp.Comment].SizeF = FontSize; // This is like /*  Comment  */
                scintilla1.Styles[Style.Cpp.Comment].Italic = true;
                //scintilla1.Styles[Style.Cpp.Comment].ForeColor = Color.DarkMagenta;
                scintilla1.Styles[Style.Cpp.Comment].ForeColor = Color.DarkGreen;

                scintilla1.Styles[Style.Cpp.CommentDoc].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.CommentDoc].Italic = true;
                scintilla1.Styles[Style.Cpp.CommentDoc].ForeColor = Color.DarkOliveGreen;
                scintilla1.Styles[Style.Cpp.CommentDoc].Bold = true;

                scintilla1.Styles[Style.Cpp.CommentDocKeyword].SizeF = FontSize;

                scintilla1.Styles[Style.Cpp.CommentDocKeywordError].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.CommentDocKeywordError].Italic = true;
                scintilla1.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = Color.FromArgb(255, 128, 128, 128); // XML Comment


                scintilla1.Styles[Style.Cpp.CommentLine].SizeF = FontSize; // This is like // Comment
                scintilla1.Styles[Style.Cpp.CommentLine].Italic = true;
                scintilla1.Styles[Style.Cpp.CommentLine].ForeColor = Color.DarkGreen;


                scintilla1.Styles[Style.Cpp.CommentLineDoc].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(255, 128, 128, 128); // XML Comment

                scintilla1.Styles[Style.Cpp.EscapeSequence].SizeF = FontSize;

                scintilla1.Styles[Style.Cpp.GlobalClass].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.GlobalClass].Bold = true;

                scintilla1.Styles[Style.Cpp.HashQuotedString].SizeF = FontSize;

                scintilla1.Styles[Style.Cpp.Identifier].SizeF = FontSize;

                scintilla1.Styles[Style.Cpp.Number].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.Number].ForeColor = Color.FromArgb(255, 0xE2, 0x89, 0x13); // Golden Bell

                scintilla1.Styles[Style.Cpp.Operator].SizeF = FontSize;

                scintilla1.Styles[Style.Cpp.Preprocessor].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.Preprocessor].Italic = true;
                //scintilla1.Styles[Style.Cpp.Preprocessor].ForeColor = Color.DarkMagenta;
                scintilla1.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Gray;
                scintilla1.Styles[Style.Cpp.Preprocessor].Bold = true;

                scintilla1.Styles[Style.Cpp.PreprocessorComment].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.PreprocessorComment].ForeColor = Color.Beige;

                scintilla1.Styles[Style.Cpp.PreprocessorCommentDoc].SizeF = FontSize;
                //scintilla1.Styles[Style.Cpp.PreprocessorCommentDoc].ForeColor = Color.Beige;

                scintilla1.Styles[Style.Cpp.Regex].SizeF = FontSize;

                scintilla1.Styles[Style.Cpp.String].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(255, 163, 21, 21);


                scintilla1.Styles[Style.Cpp.StringEol].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.StringRaw].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.TaskMarker].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.TripleVerbatim].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.UserLiteral].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.Uuid].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.Verbatim].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.Word].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.Word].ForeColor = Color.Blue;

                scintilla1.Styles[Style.Cpp.Word2].SizeF = FontSize;
                scintilla1.Styles[Style.Cpp.Word2].ForeColor = Color.DarkCyan;

                // Enable code folding
                scintilla1.SetProperty("fold", "1");
                scintilla1.SetProperty("styling.within.preprocessor", "1");
                scintilla1.SetProperty("fold.preprocessor", "1");

                // See https://github.com/jacobslusser/ScintillaNET/issues/109

                scintilla1.SetProperty("lexer.cpp.track.preprocessor", "1");
                scintilla1.SetProperty("lexer.cpp.update.preprocessor", "1");
                //scintilla1.SetKeywords(5, "HasArbPrecNet=1");

                scintilla1.Styles[Style.Cpp.Comment + 64].BackColor = Color.LightGray;

                //scintilla1.Styles[Style.Cpp.Default + 64].BackColor = backColor;
                //scintilla1.Styles[Style.Cpp.Default + 64].ForeColor = Color.Black;
                //scintilla1.Styles[Style.Cpp.Default + 64].Bold = false;
                //scintilla1.Styles[Style.Cpp.Default + 64].Italic = false;
                //scintilla1.Styles[Style.Cpp.Default + 64].Underline = false;
                //scintilla1.Styles[Style.Cpp.Default + 64].Font = FontName;
                //scintilla1.Styles[Style.Cpp.Default + 64].SizeF = FontSize;



                // Does not display empty lines between folded items
                //scintilla1.SetProperty("fold.compact", "1");


            }

            #endregion





            #region Visual Basic specific syntax coloring

            if (ScriptType.Contains("Visual Basic"))
            {
                //MessageBox.Show("Using Visual Basic Lexer");
                CommentStr = "'";
                //scintilla1.Lexer = Lexer.Vb;
                scintilla1.LexerName = "vb";
                scintilla1.EdgeMode = EdgeMode.None;



                scintilla1.SetKeywords(0, "addressof alias and as attribute base begin binary boolean byref byte byval call case cdbl cint clng compare const csng cstr currency date decimal declare defbool defbyte defcur defdate defdbl defdec defint deflng defobj defsng defstr defvar dim do double each else elseif empty end enum eqv erase error event exit explicit for friend function get global gosub goto if imp implements in input integer is len let lib like load lock long loop lset me mid midb mod new next not null object on option optional or paramarray preserve print private property public raiseevent randomize redim rem resume return rset seek select set single static step stop string sub text then time to type typeof unload until variant wend while with withevents xor");

                scintilla1.SetKeywords(1, "aggregate group into join equals order by descending ascending from where addhandler andalso ansi assembly auto catch cbool cbyte cchar cdate cdec char class cobj continue csbyte cshort ctype cuint culng cushort custom default delegate directcast endif externalsource finally gettype handles imports inherits interface isfalse isnot istrue module mustinherit mustoverride my mybase myclass namespace narrowing notinheritable notoverridable of off operator orelse overloads overridable overrides partial protected readonly region removehandler sbyte shadows shared short strict structure synclock throw try trycast uinteger ulong unicode ushort using when widening writeonly");

                scintilla1.SetKeywords(2, "false true nothing complex fixedprecnet arbprecnet userprecnet math53 cmath53 flint53 flintc53 boost53 sreal slib srealflint srealmat sboost scplx scplxflint scplxmat sreal_t scplx_t srealmat_t scplxmat_t  freal frealflint frealmat fboost fcplx fcplxflint fcplxmat freal_t fcplx_t frealmat_t fcplxmat_t  xreal xrealflint xrealmat xboost xcplx xcplxflint xcplxmat xreal_t xcplx_t xrealmat_t xcplxmat_t  qreal qrealflint qrealmat qboost qcplx qcplxflint qcplxmat qreal_t qcplx_t qrealmat_t qcplxmat_t  dreal drealflint drealmat dcplx dcplxflint dcplxmat dreal_t dcplx_t drealmat_t dcplxmat_t  oreal orealflint oboost ocplx ocplxflint oreal_t ocplx_t  mreal mrealflint mrealmat mcplx mcplxflint mcplxmat mreal_t mcplx_t mrealmat_t mcplxmat_t  ireal irealflint irealmat icplx icplxflint icplxmat ireal_t icplx_t irealmat_t icplxmat_t  areal arealflint arealmat acplx acplxflint acplxmat areal_t acplx_t arealmat_t acplxmat_t  breal brealflint brealmat bcplx bcplxflint bcplxmat breal_t bcplx_t brealmat_t bcplxmat_t  creal cboost crealflint ccplx ccplxflint creal_t ccplx_t  sreal_cs scplx_cs  freal_cs fcplx_cs  xreal_cs xcplx_cs  qreal_cs qcplx_cs  dreal_cs dcplx_cs  oreal_cs ocplx_cs  mreal_cs mcplx_cs  ireal_cs icplx_cs  areal_cs acplx_cs  breal_cs bcplx_cs  creal_cs ccplx_cs sreal_vb scplx_vb  freal_vb fcplx_vb  xreal_vb xcplx_vb  qreal_vb qcplx_vb  dreal_vb dcplx_vb  oreal_vb ocplx_vb  mreal_vb mcplx_vb  ireal_vb icplx_vb  areal_vb acplx_vb  breal_vb bcplx_vb  creal_vb ccplx_vb math_cs cmath_cs  math_vb cmath_vb");

                scintilla1.SetKeywords(3, "#end #region region");

                scintilla1.Styles[Style.Vb.Default].BackColor = backColor;
                scintilla1.Styles[Style.Vb.Default].ForeColor = Color.Black;
                scintilla1.Styles[Style.Vb.Default].Bold = false;
                scintilla1.Styles[Style.Vb.Default].Italic = false;
                scintilla1.Styles[Style.Vb.Default].Underline = false;
                scintilla1.Styles[Style.Vb.Default].Font = FontName;
                scintilla1.Styles[Style.Vb.Default].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.Asm].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.BinNumber].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.Comment].SizeF = FontSize;
                scintilla1.Styles[Style.Vb.Comment].ForeColor = Color.Green;
                scintilla1.Styles[Style.Vb.Comment].Italic = true;

                scintilla1.Styles[Style.Vb.CommentBlock].SizeF = FontSize;
                scintilla1.Styles[Style.Vb.CommentBlock].ForeColor = Color.Gray;

                scintilla1.Styles[Style.Vb.Constant].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.Date].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.DocBlock].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.DocKeyword].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.DocLine].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.Error].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.HexNumber].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.Identifier].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.Keyword].SizeF = FontSize;
                scintilla1.Styles[Style.Vb.Keyword].ForeColor = Color.Blue;

                scintilla1.Styles[Style.Vb.Keyword2].SizeF = FontSize;
                scintilla1.Styles[Style.Vb.Keyword2].ForeColor = Color.Blue;

                scintilla1.Styles[Style.Vb.Keyword3].SizeF = FontSize;
                scintilla1.Styles[Style.Vb.Keyword3].ForeColor = Color.DarkCyan;

                scintilla1.Styles[Style.Vb.Keyword4].SizeF = FontSize;
                scintilla1.Styles[Style.Vb.Keyword4].ForeColor = Color.DarkCyan;

                scintilla1.Styles[Style.Vb.Label].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.Number].SizeF = FontSize;
                scintilla1.Styles[Style.Vb.Number].ForeColor = Color.SaddleBrown;

                scintilla1.Styles[Style.Vb.Operator].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.Preprocessor].SizeF = FontSize;

                scintilla1.Styles[Style.Vb.String].SizeF = FontSize;
                scintilla1.Styles[Style.Vb.String].ForeColor = Color.DarkRed;

                scintilla1.Styles[Style.Vb.StringEol].SizeF = FontSize;

                // Enable code folding
                scintilla1.SetProperty("fold", "1");

                // Does not display empty lines between folded items
                scintilla1.SetProperty("fold.compact", "1");


            }

            #endregion






            #region R Stat syntax coloring

            if (ScriptType.Contains("R Stat"))
            {
                //MessageBox.Show("Using R Lexer");
                CommentStr = "#";
                //scintilla1.Lexer = Lexer.R;
                scintilla1.LexerName = "r";
                scintilla1.EdgeMode = EdgeMode.None;

                // Set the Styles


                // Set keyword lists
                // Word = 0

                // Word2 = 1
                scintilla1.SetKeywords(0, @"commandArgs detach length dev.off stop lm library predict lmer plot print display anova read.table read.csv complete.cases dim attach as.numeric seq max min data.frame lines curve as.integer levels nlevels ceiling sqrt ranef order AIC summary str head png tryCatch par mfrow interaction.plot qqnorm qqline ");
                // User1 = 4
                scintilla1.SetKeywords(1, @"TRUE FALSE if else for while in break continue function");
                // User2 = 5

                scintilla1.Styles[Style.R.Default].BackColor = backColor;
                scintilla1.Styles[Style.R.Default].ForeColor = Color.Black;
                scintilla1.Styles[Style.R.Default].Bold = false;
                scintilla1.Styles[Style.R.Default].Italic = false;
                scintilla1.Styles[Style.R.Default].Underline = false;
                scintilla1.Styles[Style.R.Default].Font = FontName;
                scintilla1.Styles[Style.R.Default].SizeF = FontSize;

                // Set the styles
                scintilla1.Styles[Style.R.Comment].ForeColor = Color.Green;
                scintilla1.Styles[Style.R.Comment].Italic = true;
                scintilla1.Styles[Style.R.Comment].Font = FontName;
                scintilla1.Styles[Style.R.Comment].SizeF = FontSize;

                scintilla1.Styles[Style.R.Number].ForeColor = Color.SaddleBrown;
                scintilla1.Styles[Style.R.Number].Font = FontName;
                scintilla1.Styles[Style.R.Number].SizeF = FontSize;

                scintilla1.Styles[Style.R.String].ForeColor = Color.Red;
                scintilla1.Styles[Style.R.String].Font = FontName;
                scintilla1.Styles[Style.R.String].SizeF = FontSize;

                scintilla1.Styles[Style.R.String2].ForeColor = Color.FromArgb(0x7F, 0x00, 0x7F);
                scintilla1.Styles[Style.R.String2].Font = FontName;
                scintilla1.Styles[Style.R.String2].SizeF = FontSize;

                //scintilla1.Styles[Style.R.Operator].Bold = true;
                scintilla1.Styles[Style.R.Operator].Font = FontName;
                scintilla1.Styles[Style.R.Operator].SizeF = FontSize;

                scintilla1.Styles[Style.R.Identifier].ForeColor = Color.Black;
                scintilla1.Styles[Style.R.Identifier].Font = FontName;
                scintilla1.Styles[Style.R.Identifier].SizeF = FontSize;


                scintilla1.Styles[Style.R.BaseKWord].ForeColor = Color.Blue;
                //scintilla1.Styles[Style.R.BaseKWord].Bold = true;
                scintilla1.Styles[Style.R.BaseKWord].Font = FontName;
                scintilla1.Styles[Style.R.BaseKWord].SizeF = FontSize;

                //scintilla1.Styles[Style.R.KWord].ForeColor = Color.Fuchsia;
                scintilla1.Styles[Style.R.KWord].ForeColor = Color.Blue;
                scintilla1.Styles[Style.R.KWord].Font = FontName;
                scintilla1.Styles[Style.R.KWord].SizeF = FontSize;

                scintilla1.Styles[Style.R.OtherKWord].ForeColor = Color.Fuchsia;
                scintilla1.Styles[Style.R.OtherKWord].Font = FontName;
                scintilla1.Styles[Style.R.OtherKWord].SizeF = FontSize;

                scintilla1.Styles[Style.R.InfixEol].ForeColor = Color.Green;
                scintilla1.Styles[Style.R.Infix].ForeColor = Color.FromArgb(255, 00, 128, 192);    //Medium Blue-Green



                // Instruct the lexer to calculate folding
                scintilla1.SetProperty("fold", "1");
                scintilla1.SetProperty("fold.comment", "1");

                scintilla1.SetFoldFlags(FoldFlags.LineAfterContracted);

                // Enable automatic folding
                scintilla1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

            }




            #endregion








            #region XML syntax coloring

            if (ScriptType.Contains("Chart"))
            {
                //MessageBox.Show("Using XML Lexer");
                //CommentStr = "--";
                //scintilla1.Lexer = Lexer.Xml;
                scintilla1.LexerName = "xml";
                scintilla1.EdgeMode = EdgeMode.None;

                scintilla1.IndentWidth = 4;

                // Set the Styles
                scintilla1.Styles[Style.Xml.Attribute].ForeColor = Color.Black;
                scintilla1.Styles[Style.Xml.Entity].ForeColor = Color.Black;
                scintilla1.Styles[Style.Xml.Comment].ForeColor = Color.Green;
                scintilla1.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Xml.DoubleString].ForeColor = Color.Red;
                scintilla1.Styles[Style.Xml.SingleString].ForeColor = Color.DeepPink;

                // Instruct the lexer to calculate folding
                scintilla1.SetProperty("fold", "1");
                scintilla1.SetProperty("fold.compact", "1");
                scintilla1.SetProperty("fold.html", "1");

                scintilla1.SetFoldFlags(FoldFlags.LineAfterContracted);

                // Enable automatic folding
                scintilla1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

            }


            #endregion



            #region Markup syntax coloring

            if (ScriptType.Contains("markdown"))
            {
                //MessageBox.Show("Using Python Lexer");
                CommentStr = "#";
                scintilla1.LexerName = "python";
                scintilla1.EdgeMode = EdgeMode.None;


                scintilla1.SetKeywords(0, "method math code block cite ref raw figure align figclass width only tip toctree caption maxdepth image");

                scintilla1.SetKeywords(1, "text displaystyle frac tfrac sqrt le ge ne infty quad newpage");

                scintilla1.Styles[Style.Python.Default].BackColor = backColor;
                scintilla1.Styles[Style.Python.Default].ForeColor = Color.Black;
                scintilla1.Styles[Style.Python.Default].Bold = false;
                scintilla1.Styles[Style.Python.Default].Italic = false;
                scintilla1.Styles[Style.Python.Default].Underline = false;
                scintilla1.Styles[Style.Python.Default].Font = FontName;
                scintilla1.Styles[Style.Python.Default].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Number].ForeColor = Color.FromArgb(255, 0xE2, 0x89, 0x13); // Golden Bell
                scintilla1.Styles[Style.Python.Number].Font = FontName;
                scintilla1.Styles[Style.Python.Number].SizeF = FontSize;

                scintilla1.Styles[Style.Python.String].ForeColor = Color.Red;
                scintilla1.Styles[Style.Python.String].Font = FontName;
                scintilla1.Styles[Style.Python.String].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Character].ForeColor = Color.FromArgb(255, 163, 21, 21);
                scintilla1.Styles[Style.Python.Character].Font = FontName;
                scintilla1.Styles[Style.Python.Character].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Word].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Python.Word].Font = FontName;
                scintilla1.Styles[Style.Python.Word].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Word2].ForeColor = Color.SaddleBrown;
                scintilla1.Styles[Style.Python.Word2].Font = FontName;
                scintilla1.Styles[Style.Python.Word2].SizeF = FontSize;

                scintilla1.Styles[Style.Python.Operator].ForeColor = Color.Green;
                scintilla1.Styles[Style.Python.Operator].Font = FontName;
                scintilla1.Styles[Style.Python.Operator].SizeF = FontSize;
                scintilla1.Styles[Style.Python.Operator].Bold = true;

                // http://proton-ce.sourceforge.net/rc/scintilla/pyframe/www.pyframe.com/stc/lexing.html
                scintilla1.SetProperty("tab.timmy.whinge.level", "1");
                scintilla1.SetProperty("strip.trailing.spaces.*.py", "1");
                // Enable code folding
                scintilla1.SetProperty("fold", "1");

                // Does not display empty lines between folded items
                scintilla1.SetProperty("fold.compact", "1");
            }

            #endregion



            #region CSS syntax coloring

            if (ScriptType.Contains("css"))
            {
                //MessageBox.Show("Using Markup Lexer");
                scintilla1.LexerName = "css";
                scintilla1.EdgeMode = EdgeMode.None;

                scintilla1.IndentWidth = 4;

                // Set the Styles
                scintilla1.Styles[Style.Css.Attribute].ForeColor = Color.Red;
                scintilla1.Styles[Style.Css.Class].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Css.Comment].ForeColor = Color.Green;
                scintilla1.Styles[Style.Css.Default].ForeColor = Color.Black;
                scintilla1.Styles[Style.Css.Directive].ForeColor = Color.Black;
                scintilla1.Styles[Style.Css.DoubleString].ForeColor = Color.DarkRed;
                scintilla1.Styles[Style.Css.ExtendedIdentifier].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Css.ExtendedPseudoClass].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Css.Id].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Css.Identifier].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Css.Identifier2].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Css.Identifier3].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Css.Important].ForeColor = Color.Purple;
                scintilla1.Styles[Style.Css.Media].ForeColor = Color.Black;
                scintilla1.Styles[Style.Css.Operator].ForeColor = Color.Black;
                scintilla1.Styles[Style.Css.PseudoClass].ForeColor = Color.Black;
                scintilla1.Styles[Style.Css.PseudoElement].ForeColor = Color.Black;
                scintilla1.Styles[Style.Css.SingleString].ForeColor = Color.Red;
                scintilla1.Styles[Style.Css.Tag].ForeColor = Color.Black;
                scintilla1.Styles[Style.Css.UnknownIdentifier].ForeColor = Color.Red;
                scintilla1.Styles[Style.Css.UnknownPseudoClass].ForeColor = Color.Red;
                scintilla1.Styles[Style.Css.Value].ForeColor = Color.Blue;
                scintilla1.Styles[Style.Css.Variable].ForeColor = Color.Magenta;

            }
            #endregion



            #region Batch syntax coloring

            if (ScriptType.Contains("bat"))
            {
                //MessageBox.Show("Using Markup Lexer");
                scintilla1.LexerName = "batch";
                scintilla1.EdgeMode = EdgeMode.None;

                scintilla1.IndentWidth = 4;

                // Set the Styles
                scintilla1.Styles[Style.Batch.Command].ForeColor = Color.Black;
                scintilla1.Styles[Style.Batch.Comment].ForeColor = Color.Black;
                scintilla1.Styles[Style.Batch.Default].ForeColor = Color.Black;
                scintilla1.Styles[Style.Batch.Hide].ForeColor = Color.Black;
                scintilla1.Styles[Style.Batch.Identifier].ForeColor = Color.Black;
                scintilla1.Styles[Style.Batch.Label].ForeColor = Color.Black;
                scintilla1.Styles[Style.Batch.Operator].ForeColor = Color.Black;
                scintilla1.Styles[Style.Batch.Word].ForeColor = Color.Black;
            }
            #endregion



            #region properties syntax coloring

            if (ScriptType.Contains("properties"))
            {
                //MessageBox.Show("Using Markup Lexer");
                scintilla1.LexerName = "properties";
                scintilla1.EdgeMode = EdgeMode.None;

                scintilla1.IndentWidth = 4;

                // Set the Styles
                scintilla1.Styles[Style.Properties.Assignment].ForeColor = Color.IndianRed;
                scintilla1.Styles[Style.Properties.Comment].ForeColor = Color.Green;
                scintilla1.Styles[Style.Properties.Default].ForeColor = Color.Khaki;
                scintilla1.Styles[Style.Properties.DefVal].ForeColor = Color.LightCyan;
                scintilla1.Styles[Style.Properties.Key].ForeColor = Color.DarkViolet;
                scintilla1.Styles[Style.Properties.Key].ForeColor = Color.Red;
                scintilla1.Styles[Style.Properties.Section].ForeColor = Color.Blue;


            }
            #endregion


            #region Plain text syntax coloring

            if (ScriptType.Contains("Plain Text"))
            {
                //MessageBox.Show("Using Plain Text Lexer");
                //scintilla1.Lexer = Lexer.Null;
                scintilla1.LexerName = "null";
                scintilla1.EdgeMode = EdgeMode.None;

            }

            #endregion


        }

        #endregion





    }


}

