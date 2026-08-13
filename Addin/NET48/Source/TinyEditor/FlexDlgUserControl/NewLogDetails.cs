using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace FlexDlgUserCtrl
{

    public partial class FlexDlgUserControl1 : UserControl
    {

        private Scintilla LogScintilla;


        private void tabNewLog_Enter(object sender, EventArgs e)
        {
            //LogScintilla.ReadOnly = false;
            //LogScintilla.Text = richTextBoxLog.Text;
            //LogScintilla.ReadOnly = true;
        }


        private IEnumerable<string> SplitToLines(string stringToSplit, int maxLineLength)
        {
            string[] words = stringToSplit.Split(' ');
            StringBuilder line = new StringBuilder();
            foreach (string word in words)
            {
                if (word.Length + line.Length <= maxLineLength)
                {
                    line.Append(word + " ");
                }
                else
                {
                    if (line.Length > 0)
                    {
                        yield return line.ToString().Trim() + "\n";
                        line.Clear();
                    }
                    string overflow = word;
                    while (overflow.Length > maxLineLength)
                    {
                        yield return overflow.Substring(0, maxLineLength);
                        overflow = overflow.Substring(maxLineLength);
                    }
                    line.Append(overflow + " ");
                }
            }
            yield return line.ToString().Trim() + "\n";
        }

        private string TrimmedLine(string stringToSplit, int maxLineLength)
        {
            StringBuilder line = new StringBuilder(10000);
            var sLines = SplitToLines(stringToSplit, maxLineLength);
            foreach (var s in sLines)
            {
                line.Append(s);
            }
            return line.ToString().Trim();
        }


        private void NewLogScintilla_LeftDoubleClick(object sender, MouseEventArgs e)
        {
            LogScintilla.SelectionEnd = LogScintilla.SelectionStart;
            if ((e.Clicks == 2) && (e.Button == MouseButtons.Left))
            {
                int curlineindex = LogScintilla.CurrentLine;
                string curline = LogScintilla.Lines[curlineindex].Text;
                //MessageBox.Show("curline: " + curline);
                //string curline = richTextBoxLog.Lines[line];

                string TargetFileName = "";

                scintilla1.FoldAll(FoldAction.Expand);

                // Python
                if (curline.Contains("File") &&
                    (Path.GetExtension(ActiveFileName).Contains("py") ||
                        Path.GetExtension(ActiveFileName).Contains("txt") ||
                        Path.GetExtension(ActiveFileName).Contains("rst")
                    ))
                {
                    int startpos = curline.IndexOf("\"");
                    int endpos = curline.IndexOf("\"", startpos + 1);
                    TargetFileName = curline.Substring(startpos + 1, endpos - startpos - 1);

                    //MessageBox.Show(TargetFileName);

                    startpos = curline.IndexOf(", line") + 6;
                    endpos = startpos;
                    int curLen = curline.Length;
                    while ((endpos < curLen) && (curline[endpos] != ',') && (curline[endpos] != ':'))
                    {
                        endpos = endpos + 1;
                    }
                    string resultString = curline.Substring(startpos + 1, endpos - startpos - 1);
                    int linepos;
                    try
                    {
                        linepos = Int32.Parse(resultString);
                    }
                    catch (Exception)
                    {
                        linepos = 1;
                    }

                    string errorcode = "";
                    if (IsBuildingUserLibDoc())
                    {
                        errorcode = LogScintilla.Lines[curlineindex + 1].Text;
                    }
                    else
                    {
                        int lc = LogScintilla.Lines.Count - 1;
                        curline = LogScintilla.Lines[lc].Text.Trim();
                        while (curline.Length <= 0)
                        {
                            lc = lc - 1;
                            curline = LogScintilla.Lines[lc].Text.Trim();
                        }
                        errorcode = curline;
                    }

                    if (ActiveFileName != TargetFileName)
                    {
                        bool IsIntern = true;
                        if (!TargetFileName.StartsWith(_WorkDir)) IsIntern = false;
                        if (IsIntern)
                        {
                            string[] sres = TargetFileName.Split(new string[] { @"\" }, StringSplitOptions.None);
                            int slen = sres.Length;
                            FillComboBoxFilesSetByName(sres[slen - 2]);
                            showProjectTreeAndFind(sres[slen - 1]);
                            //MessageBox.Show(sres[slen - 2]);
                            //MessageBox.Show(sres[slen - 1]);
                            //MessageBox.Show(TargetFileName);
                            ActiveFileName = TargetFileName;
                            LoadScriptFromFile(ActiveFileName);
                        }
                        else
                        {
                            var tpath = Path.GetDirectoryName(ActiveFileName);
                            ActiveFileName = tpath + @"\__external__.py";
                            File.WriteAllText(ActiveFileName, TargetFileName, Encoding.UTF8);
                            showProjectTreeAndFind(Path.GetFileName(ActiveFileName));
                            LoadScriptFromFile(ActiveFileName);
                        }
                    }

                    var myline9 = scintilla1.Lines[linepos - 1];
                    myline9.AnnotationStyle = ERROR_ANNOTATION;
                    string AnnoText9 = "";
                    AnnoText9 += TrimmedLine(errorcode, 70);
                    myline9.AnnotationText = AnnoText9;

                    scintilla1.AnnotationVisible = ScintillaNET.Annotation.Boxed;
                    scintilla1.GotoPosition(scintilla1.Lines[linepos - 1].Position);
                    scintilla1.Select();
                }

                else if (Path.GetExtension(ActiveFileName).Contains("cs"))
                {
                    // CS
                    if (curline.Contains("): error CS"))
                    {
                        int endpos = curline.IndexOf("): error CS");
                        int startpos = endpos;
                        while ((startpos > 0) && (curline[startpos] != '('))
                        {
                            startpos = startpos - 1;
                        }

                        string FName = curline.Substring(0, startpos);
                        //MessageBox.Show(FName);
                        string[] sres = FName.Split(new string[] { @"\" }, StringSplitOptions.None);
                        int sreslen = sres.Length;

                        TargetFileName = _WorkDir + @"\" + comboBoxLanguage.SelectedItem.ToString() + @"\" + comboBoxDirectories.SelectedItem.ToString() + @"\" + sres[sreslen-2] + @"\" + sres[sreslen-1];

                        //MessageBox.Show(TargetFileName);

                        string resultString = curline.Substring(startpos + 1, endpos - startpos - 1);
                        var sl = resultString.Split(',');
                        //MessageBox.Show(endpos.ToString() + curline[startpos] + curline[endpos] + " " + resultString);
                        string resultStringline = sl[0];
                        string resultStringcol = sl[1];
                        int linepos = Int32.Parse(resultStringline);
                        int colpos = Int32.Parse(resultStringcol);
                        int msgstartpos = curline.IndexOf(": error CS");
                        string resultString2 = curline.Substring(msgstartpos + 2);
                        int msgstartpos3 = resultString2.IndexOf(":");
                        string errorcode = resultString2.Substring(6, msgstartpos3 - 6);

                        if (ActiveFileName != TargetFileName)
                        {
                            FillComboBoxFilesSetByName(sres[0]);
                            showProjectTreeAndFind(sres[1]);

                            //MessageBox.Show(sres[0]);
                            //MessageBox.Show(sres[1]);
                            ActiveFileName = TargetFileName;
                            LoadScriptFromFile(ActiveFileName);
                        }

                        var myline9 = scintilla1.Lines[linepos - 1];
                        myline9.AnnotationStyle = ERROR_ANNOTATION;
                        string AnnoText9 = "";
                        AnnoText9 += TrimmedLine(resultString2, 70);
                        myline9.AnnotationText = AnnoText9;
                        scintilla1.AnnotationVisible = ScintillaNET.Annotation.Boxed;

                        scintilla1.GotoPosition(scintilla1.Lines[linepos - 1].Position);
                        scintilla1.Select();
                    }


                    // CS
                    if (curline.Contains(": runtime error:"))
                    {
                        int endpos = curline.IndexOf(": runtime error:");
                        int startpos = endpos;
                        while ((startpos > 0) && (curline[startpos] != 'e'))
                        {
                            startpos = startpos - 1;
                        }
                        string resultString = curline.Substring(startpos + 1, endpos - startpos - 1);
                        int linepos = Int32.Parse(resultString);

                        //MessageBox.Show(linepos.ToString());
                        string resultString2 = curline;

                        //if (ActiveFileName != TargetFileName)
                        //{
                        //    string[] sres = TargetFileName.Split(new string[] { @"\" }, StringSplitOptions.None);
                        //    int slen = sres.Length;
                        //    FillComboBoxFilesSetByName(sres[slen - 2]);
                        //    showProjectTreeAndFind(sres[slen - 1]);

                        //    //MessageBox.Show(sres[slen - 2]);
                        //    //MessageBox.Show(sres[slen - 1]);
                        //    ActiveFileName = TargetFileName;
                        //    LoadScriptFromFile(ActiveFileName);
                        //}

                        var myline9 = scintilla1.Lines[linepos - 1];
                        myline9.AnnotationStyle = ERROR_ANNOTATION;
                        string AnnoText9 = "";
                        AnnoText9 += TrimmedLine(resultString2, 70);
                        myline9.AnnotationText = AnnoText9;
                        scintilla1.AnnotationVisible = ScintillaNET.Annotation.Boxed;
                        scintilla1.GotoPosition(scintilla1.Lines[linepos - 1].Position);
                        scintilla1.Select();
                    }


                    // CS
                    else if (curline.Contains(": stacktrace:"))
                    {
                        int endpos = curline.IndexOf(": stacktrace:");
                        int startpos = endpos;
                        while ((startpos > 0) && (curline[startpos] != 'e'))
                        {
                            startpos = startpos - 1;
                        }
                        string resultString = curline.Substring(startpos + 1, endpos - startpos - 1);
                        int linepos = Int32.Parse(resultString);

                        //MessageBox.Show(linepos.ToString());
                        string resultString2 = curline;
                        var myline8 = scintilla1.Lines[linepos - 1];
                        myline8.AnnotationStyle = WARNING_ANNOTATION;
                        string AnnoText8 = "";
                        AnnoText8 += TrimmedLine(resultString2, 70);
                        myline8.AnnotationText = AnnoText8;
                        scintilla1.AnnotationVisible = ScintillaNET.Annotation.Boxed;
                        scintilla1.GotoPosition(scintilla1.Lines[linepos - 1].Position);
                        scintilla1.Select();
                    }






                    // CS
                    else if (curline.Contains("): warning CS"))
                    {
                        int endpos = curline.IndexOf("): warning CS");
                        int startpos = endpos;
                        while ((startpos > 0) && (curline[startpos] != '('))
                        {
                            startpos = startpos - 1;
                        }

                        string FName = curline.Substring(0, startpos);
                        //MessageBox.Show(FName);
                        string[] sres = FName.Split(new string[] { @"\" }, StringSplitOptions.None);
                        int sreslen = sres.Length;

                        TargetFileName = _WorkDir + @"\" + comboBoxLanguage.SelectedItem.ToString() + @"\" + comboBoxDirectories.SelectedItem.ToString() + @"\" + sres[sreslen - 2] + @"\" + sres[sreslen - 1];


                        //TargetFileName = _WorkDir + @"\" + comboBoxLanguage.SelectedItem.ToString() + @"\" + comboBoxDirectories.SelectedItem.ToString() + @"\" + sres[0] + @"\" + sres[1];
                        //MessageBox.Show(TargetFileName);

                        string resultString = curline.Substring(startpos + 1, endpos - startpos - 1);
                        var sl = resultString.Split(',');
                        string resultStringline = sl[0];
                        string resultStringcol = sl[1];
                        int linepos = Int32.Parse(resultStringline);
                        int colpos = Int32.Parse(resultStringcol);
                        int msgstartpos = curline.IndexOf(": warning CS");
                        string resultString2 = curline.Substring(msgstartpos + 2);
                        int msgstartpos3 = resultString2.IndexOf(":");
                        string warningcode = resultString2.Substring(8, msgstartpos3 - 8);

                        if (ActiveFileName != TargetFileName)
                        {
                            FillComboBoxFilesSetByName(sres[0]);
                            showProjectTreeAndFind(sres[1]);

                            //MessageBox.Show(sres[0]);
                            //MessageBox.Show(sres[1]);
                            ActiveFileName = TargetFileName;
                            LoadScriptFromFile(ActiveFileName);
                        }

                        var myline8 = scintilla1.Lines[linepos - 1];
                        myline8.AnnotationStyle = WARNING_ANNOTATION;
                        string AnnoText8 = "";
                        AnnoText8 += TrimmedLine(resultString2, 70);
                        myline8.AnnotationText = AnnoText8;
                        scintilla1.AnnotationVisible = ScintillaNET.Annotation.Boxed;

                        scintilla1.GotoPosition(scintilla1.Lines[linepos - 1].Position);
                        scintilla1.Select();
                    }

                } // else

            }
        }



        public void InitNewLogData()
        {
            //LogScintilla.ap

            LogScintilla = new Scintilla();
            LogScintilla.Dock = DockStyle.Fill;
            LogScintilla.Location = new Point(0, 0);
            LogScintilla.Name = "LogScintilla";
            LogScintilla.ScrollWidth = 5001;
            LogScintilla.Size = new Size(556, 220);
            LogScintilla.TabIndex = 4;
            LogScintilla.Text = "LogScintilla";
            LogScintilla.UseTabs = false;
            tabNewLog.Controls.Add(LogScintilla);
            LogScintilla.ViewWhitespace = WhitespaceMode.VisibleAlways;
            LogScintilla.VirtualSpaceOptions = VirtualSpace.RectangularSelection;
            LogScintilla.WrapVisualFlags = ((WrapVisualFlags)(((WrapVisualFlags.End | WrapVisualFlags.Start)
            | WrapVisualFlags.Margin)));
            LogScintilla.MouseDoubleClick += new MouseEventHandler(NewLogScintilla_LeftDoubleClick);

            TextDataScintilla.StyleClearAll();
            TextDataScintilla.IndentWidth = 4;

            Color backColor = SystemColors.Control;
            Color selectionColor = Color.LightGray;

            float FontSize = 10.125F;
            var NewFont = new System.Drawing.Font("Consolas", FontSize);
            string FontName = NewFont.Name;
            //fontToolStripMenuItem.ToolTipText = FontName + "; " + FontSize.ToString() + "pt";
            LogScintilla.Styles[Style.Default].Font = FontName;
            LogScintilla.Styles[Style.Default].SizeF = FontSize;
            LogScintilla.Styles[Style.Default].BackColor = backColor;
            LogScintilla.Styles[Style.Default].ForeColor = Color.Black;
            LogScintilla.CaretForeColor = Color.Black;
            LogScintilla.CaretWidth = 30;
            LogScintilla.CaretLineBackColor = Color.OldLace;

            LogScintilla.LexerName = "sql";
            // Set the Styles
            LogScintilla.Styles[Style.Sql.Default].ForeColor = Color.Black;
            LogScintilla.Styles[Style.Sql.Comment].ForeColor = Color.DarkRed;
            LogScintilla.Styles[Style.Sql.CommentLine].ForeColor = Color.DarkRed;
            LogScintilla.Styles[Style.Sql.CommentLineDoc].ForeColor = Color.DarkRed;
            LogScintilla.Styles[Style.Sql.Number].ForeColor = Color.Green;
            LogScintilla.Styles[Style.Sql.Word].ForeColor = Color.Blue;
            LogScintilla.Styles[Style.Sql.Word2].ForeColor = Color.Fuchsia;
            LogScintilla.Styles[Style.Sql.User1].ForeColor = Color.DarkCyan;
            LogScintilla.Styles[Style.Sql.User2].ForeColor = Color.FromArgb(255, 00, 128, 192);    //Medium Blue-Green
            //LogScintilla.Styles[Style.Sql.String].ForeColor = Color.Red;
            LogScintilla.Styles[Style.Sql.String].ForeColor = Color.Blue;
            LogScintilla.Styles[Style.Sql.Character].ForeColor = Color.Red;
            LogScintilla.Styles[Style.Sql.Operator].ForeColor = Color.Black;

            LogScintilla.Styles[Style.Sql.Default].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.Identifier].BackColor = backColor;

            LogScintilla.Styles[Style.Sql.Comment].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.CommentLine].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.CommentLineDoc].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.Number].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.Word].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.Word2].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.User1].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.User2].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.String].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.Character].BackColor = backColor;
            LogScintilla.Styles[Style.Sql.Operator].BackColor = backColor;
            //LogScintilla.ViewEol = true ;
            //LogScintilla.ReadOnly = true;

        }


    }

}




