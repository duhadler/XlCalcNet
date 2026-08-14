using System;
using System.Drawing;
using System.Windows.Forms;
using ScintillaNET;


namespace FlexDlgUserCtrl
{

    public partial class FlexDlgUserControl1 : UserControl
    {
        private Scintilla InfoDataScintilla;

        public void InitInfoData()
        {
            InfoDataScintilla = new Scintilla();
            tabFunctionInfo.Controls.Add(InfoDataScintilla);



            InfoDataScintilla.Dock = DockStyle.Fill;
            InfoDataScintilla.Location = new Point(0, 0);
            InfoDataScintilla.Name = "InfoDataScintilla";
            InfoDataScintilla.ScrollWidth = 5001;
            InfoDataScintilla.Size = new Size(556, 220);
            InfoDataScintilla.TabIndex = 4;
            InfoDataScintilla.Text = "InfoDataScintilla";
            InfoDataScintilla.UseTabs = false;

            InfoDataScintilla.WrapVisualFlags = ((WrapVisualFlags.End | WrapVisualFlags.Start) | WrapVisualFlags.Margin);

            CommentStr = "//";
            InfoDataScintilla.LexerName = "cpp";
            InfoDataScintilla.SetKeywords(0, " dynamic decimal default double string s uint ulong ushort  void Object Int32 ");

            InfoDataScintilla.SetKeywords(1, XlCalcKeyWords1 + XlCalcKeyWords2);

            InfoDataScintilla.WrapMode = WrapMode.Word;
            Color backColor = SystemColors.Control;
            float FontSize = 10.125F;
            var NewFont = new System.Drawing.Font("Consolas", FontSize);
            string FontName = NewFont.Name;


            InfoDataScintilla.Styles[Style.Default].Font = FontName;
            InfoDataScintilla.Styles[Style.Default].SizeF = FontSize;
            InfoDataScintilla.Styles[Style.Default].BackColor = backColor;
            InfoDataScintilla.Styles[Style.Default].ForeColor = Color.Black;


            InfoDataScintilla.Styles[Style.Cpp.Default].Bold = false;
            InfoDataScintilla.Styles[Style.Cpp.Default].Italic = false;
            InfoDataScintilla.Styles[Style.Cpp.Default].Underline = false;

            InfoDataScintilla.Styles[Style.Cpp.Number].ForeColor = Color.SaddleBrown;
            //InfoDataScintilla.Styles[Style.Cpp.String].ForeColor = Color.Green;
            InfoDataScintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(255, 163, 21, 21);
            InfoDataScintilla.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            InfoDataScintilla.Styles[Style.Cpp.Word2].ForeColor = Color.DarkCyan;


            InfoDataScintilla.Styles[Style.Cpp.Character].SizeF = FontSize;
            InfoDataScintilla.Styles[Style.Cpp.Identifier].SizeF = FontSize;
            InfoDataScintilla.Styles[Style.Cpp.Number].SizeF = FontSize;
            InfoDataScintilla.Styles[Style.Cpp.String].SizeF = FontSize;
            InfoDataScintilla.Styles[Style.Cpp.Word].SizeF = FontSize;
            InfoDataScintilla.Styles[Style.Cpp.Word2].SizeF = FontSize;


            InfoDataScintilla.Styles[Style.Cpp.Character].BackColor = backColor;
            InfoDataScintilla.Styles[Style.Cpp.Identifier].BackColor = backColor;
            InfoDataScintilla.Styles[Style.Cpp.Number].BackColor = backColor;
            InfoDataScintilla.Styles[Style.Cpp.String].BackColor = backColor;
            InfoDataScintilla.Styles[Style.Cpp.Word].BackColor = backColor;
            InfoDataScintilla.Styles[Style.Cpp.Word2].BackColor = backColor;

            InfoDataScintilla.Styles[Style.Cpp.Operator].BackColor = backColor;
            InfoDataScintilla.Styles[Style.Cpp.Default].BackColor = backColor;
            InfoDataScintilla.Styles[Style.Cpp.StringEol].BackColor = backColor;


            InfoDataScintilla.ReadOnly = true;
        }

    }

}




