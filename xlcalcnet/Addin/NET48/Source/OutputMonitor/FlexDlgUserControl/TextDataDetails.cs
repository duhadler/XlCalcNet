using System;
using System.Drawing;
using System.Windows.Forms;
using ScintillaNET;
using ScintillaPrinting;


namespace TinyOutputMonitorCtrl
{


    public partial class OutputMonitorCtrl : UserControl
    {
        private Scintilla TextDataScintilla;
        private const int NUMBER_MARGIN = 1;
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 3;
        private const int FOLDING_MARGIN = 3;


        // Declare variable for Printing dialogs
        Printing TextDataPrinter;

        private void TextData_TToggleBookmark(int Position)
        {
            // Do we have a marker for this line?
            const uint mask = 1 << BOOKMARK_MARKER;
            var line = TextDataScintilla.Lines[TextDataScintilla.LineFromPosition(Position)];
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

        private void TextData_TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                TextData_TToggleBookmark(e.Position);
            }
        }

        public void InitTextData()
        {
            TextDataScintilla = new Scintilla();
            TextDataScintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            TextDataScintilla.Location = new Point(0, 0);
            TextDataScintilla.Name = "TextDataScintilla";
            TextDataScintilla.ScrollWidth = 5001;
            TextDataScintilla.Size = new Size(556, 220);
            TextDataScintilla.TabIndex = 4;
            TextDataScintilla.Text = "TextDataScintilla";
            TextDataScintilla.UseTabs = false;

            tabText.Controls.Add(TextDataScintilla);

            TextDataScintilla.ContextMenuStrip = contextMenuStripTextData;
            TextDataScintilla.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleAlways;
            TextDataScintilla.VirtualSpaceOptions = ScintillaNET.VirtualSpace.RectangularSelection;
            TextDataScintilla.WrapVisualFlags = (WrapVisualFlags)(ScintillaNET.WrapVisualFlags.End | ScintillaNET.WrapVisualFlags.Start
            | ScintillaNET.WrapVisualFlags.Margin);


            // Set printing routines
            TextDataPrinter = new Printing(TextDataScintilla);


            //// Hook into MarginClick event to set/delete bookmarks
            //TextDataScintilla.MarginClick += TextData_TextArea_MarginClick;

            //CommentStr = "--";
            //TextDataScintilla.Lexer = Lexer.Xml;
            TextDataScintilla.LexerName = "xml";
            InitTextDataSyntaxColoring();

        }


        private void InitTextDataSyntaxColoring()
        {

            // Configure the default style
            TextDataScintilla.StyleClearAll();
            TextDataScintilla.IndentWidth = 4;

            //TextDataScintilla.SetSelectionBackColor(true, Color.LightBlue);

            Color backColor = SystemColors.Control;
            Color selectionColor = Color.LightGray;

            float FontSize = 10.125F;
            var NewFont = new System.Drawing.Font("Consolas", FontSize);

            string FontName = NewFont.Name;
            //fontToolStripMenuItem.ToolTipText = FontName + "; " + FontSize.ToString() + "pt";
            TextDataScintilla.Styles[Style.Default].Font = FontName;
            TextDataScintilla.Styles[Style.Default].SizeF = FontSize;
            TextDataScintilla.Styles[Style.Default].BackColor = backColor;
            TextDataScintilla.Styles[Style.Default].ForeColor = Color.Black;
            TextDataScintilla.CaretForeColor = Color.Black;
            TextDataScintilla.CaretWidth = 30;
            TextDataScintilla.CaretLineBackColor = Color.OldLace;



            TextDataScintilla.Styles[Style.LineNumber].Font = FontName;
            //TextDataScintilla.Styles[Style.LineNumber].SizeF = (float)(FontSize * 0.915);
            TextDataScintilla.Styles[Style.LineNumber].SizeF = (float)(FontSize * 0.9);


            // Reset number margin
            var nmargin = TextDataScintilla.Margins[NUMBER_MARGIN];
            //nmargin.Width = toolStripButtonRun.Width;
            nmargin.Width = 40;
            int temp = TextDataScintilla.Lines.Count.ToString().Length;
            if (temp > 4)
            {
                nmargin.Width = nmargin.Width * temp / 4;
            }
            nmargin.Type = MarginType.Number;
            nmargin.Sensitive = false;
            nmargin.Mask = 0;
            nmargin.Cursor = MarginCursor.Arrow;


            // Reset bookmark margin
            var bmargin = TextDataScintilla.Margins[BOOKMARK_MARGIN];
            bmargin.Width = 20;
            bmargin.Sensitive = true;
            bmargin.Type = MarginType.Symbol;
            bmargin.Mask = 1 << BOOKMARK_MARKER;
            bmargin.Cursor = MarginCursor.Arrow;

            var bmarker = TextDataScintilla.Markers[BOOKMARK_MARKER];
            bmarker.Symbol = MarkerSymbol.Circle;
            bmarker.SetBackColor(Color.DarkCyan);
            bmarker.SetAlpha(100);

            // Reset folder margin
            var fmargin = TextDataScintilla.Margins[FOLDING_MARGIN];
            fmargin.Type = MarginType.Symbol;
            fmargin.Mask = Marker.MaskFolders;
            fmargin.Sensitive = true;
            fmargin.Width = 20;
            fmargin.Cursor = MarginCursor.Arrow;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                TextDataScintilla.Markers[i].SetForeColor(Color.Green); // styles for [+] and [-]
                TextDataScintilla.Markers[i].SetBackColor(Color.Black); // styles for [+] and [-]
            }

            // Style the folder markers
            TextDataScintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            TextDataScintilla.Markers[Marker.Folder].SetBackColor(SystemColors.Control);
            TextDataScintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            TextDataScintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            TextDataScintilla.Markers[Marker.FolderEnd].SetBackColor(SystemColors.Control);
            TextDataScintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            TextDataScintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            TextDataScintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            TextDataScintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Configure folding markers with respective symbols
            TextDataScintilla.Markers[Marker.FolderEnd].SetBackColor(Color.Black);
            TextDataScintilla.Markers[Marker.FolderEnd].SetForeColor(Color.Orange);



            // Set the Styles
            TextDataScintilla.Styles[Style.Xml.Attribute].ForeColor = Color.Black;
            TextDataScintilla.Styles[Style.Xml.Entity].ForeColor = Color.Black;
            TextDataScintilla.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            TextDataScintilla.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
            TextDataScintilla.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
            TextDataScintilla.Styles[Style.Xml.DoubleString].ForeColor = Color.Red;
            TextDataScintilla.Styles[Style.Xml.SingleString].ForeColor = Color.DeepPink;
            TextDataScintilla.Styles[Style.Xml.Other].ForeColor = Color.Black;
            TextDataScintilla.Styles[Style.Xml.Number].ForeColor = Color.Blue;
            TextDataScintilla.Styles[Style.Xml.Default].ForeColor = Color.Black;

            TextDataScintilla.Styles[Style.Xml.Attribute].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.Entity].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.Comment].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.Tag].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.TagEnd].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.DoubleString].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.SingleString].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.Other].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.Number].BackColor = backColor;
            TextDataScintilla.Styles[Style.Xml.Default].BackColor = backColor;






            // Instruct the lexer to calculate folding
            TextDataScintilla.SetProperty("fold", "1");
            TextDataScintilla.SetProperty("fold.compact", "1");
            TextDataScintilla.SetProperty("fold.html", "1");

            TextDataScintilla.SetFoldFlags(FoldFlags.LineAfterContracted);

            // Enable automatic folding
            TextDataScintilla.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
        }





        #region text data specific menu items


        private void printPreviewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = TextDataPrinter.PrintDocument;
            objPPdialog.WindowState = FormWindowState.Maximized;
            objPPdialog.ShowDialog();
        }



        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextDataScintilla.Copy();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextDataScintilla.SelectAll();
        }

        private void wordWrapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // toggle word wrap
            wordWrapToolStripTextDataMenuItem.Checked = !wordWrapToolStripTextDataMenuItem.Checked;
            TextDataScintilla.WrapMode = wordWrapToolStripTextDataMenuItem.Checked ? WrapMode.Word : WrapMode.None;
        }


        private void collapseAllFoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextDataScintilla.FoldAll(ScintillaNET.FoldAction.Contract);
        }

        private void expandAllFoldsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextDataScintilla.FoldAll(ScintillaNET.FoldAction.Expand);
        }


        private void nextBookmarkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var line = TextDataScintilla.LineFromPosition(TextDataScintilla.CurrentPosition);
            var nextLine = TextDataScintilla.Lines[++line].MarkerNext(1 << BOOKMARK_MARKER);
            if (nextLine != -1)
                TextDataScintilla.Lines[nextLine].Goto();
        }

        private void previousBookmarkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var line = TextDataScintilla.LineFromPosition(TextDataScintilla.CurrentPosition);
            var prevLine = TextDataScintilla.Lines[--line].MarkerPrevious(1 << BOOKMARK_MARKER);
            if (prevLine != -1)
                TextDataScintilla.Lines[prevLine].Goto();
        }


        private void deleteAllBookmarksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextDataScintilla.MarkerDeleteAll(BOOKMARK_MARKER);
        }

        #endregion



    }





}




