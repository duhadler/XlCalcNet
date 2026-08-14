using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;

namespace TinyDataViewerCtrl
{


    public partial class DataViewerCtrl : UserControl
    {
        private Scintilla ViewSQLScintilla;


        public void InitSQLite()
        {
            ViewSQLScintilla = new Scintilla();
            ViewSQLScintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            ViewSQLScintilla.Location = new Point(0, 0);
            ViewSQLScintilla.Name = "ViewSQLScintilla";
            ViewSQLScintilla.ScrollWidth = 5001;
            ViewSQLScintilla.Size = new Size(556, 220);
            ViewSQLScintilla.TabIndex = 4;
            ViewSQLScintilla.Text = "ViewSQLScintilla";
            ViewSQLScintilla.UseTabs = false;
            this.tabSQL.Controls.Add(ViewSQLScintilla);
            ViewSQLScintilla.LexerName = "sql";

            // Configure the default style
            ViewSQLScintilla.StyleClearAll();
            ViewSQLScintilla.IndentWidth = 4;
            ViewSQLScintilla.CaretForeColor = Color.Black;
            ViewSQLScintilla.CaretWidth = 30;

            Color backColor = SystemColors.Control;
            Color selectionColor = Color.LightGray;

            float FontSize = 10.125F;
            var NewFont = new System.Drawing.Font("Consolas", FontSize);

            string FontName = NewFont.Name;
            //fontToolStripMenuItem.ToolTipText = FontName + "; " + FontSize.ToString() + "pt";
            ViewSQLScintilla.Styles[Style.Default].Font = FontName;
            ViewSQLScintilla.Styles[Style.Default].SizeF = FontSize;
            ViewSQLScintilla.Styles[Style.Default].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Default].ForeColor = Color.Black;
            ViewSQLScintilla.CaretForeColor = Color.Black;
            ViewSQLScintilla.CaretLineBackColor = Color.OldLace;

            //string CommentStr = "--";
            ViewSQLScintilla.Name = "Sql";

            // Set the Styles
            ViewSQLScintilla.Styles[Style.Sql.Default].ForeColor = Color.Black;
            ViewSQLScintilla.Styles[Style.Sql.Comment].ForeColor = Color.DarkGreen;
            ViewSQLScintilla.Styles[Style.Sql.CommentLine].ForeColor = Color.DarkGreen;
            ViewSQLScintilla.Styles[Style.Sql.CommentLineDoc].ForeColor = Color.DarkGreen;
            ViewSQLScintilla.Styles[Style.Sql.Number].ForeColor = Color.Green;
            ViewSQLScintilla.Styles[Style.Sql.Word].ForeColor = Color.Blue;
            ViewSQLScintilla.Styles[Style.Sql.Word2].ForeColor = Color.Fuchsia;
            ViewSQLScintilla.Styles[Style.Sql.User1].ForeColor = Color.DarkCyan;
            ViewSQLScintilla.Styles[Style.Sql.User2].ForeColor = Color.FromArgb(255, 00, 128, 192);    //Medium Blue-Green
            ViewSQLScintilla.Styles[Style.Sql.String].ForeColor = Color.Red;
            ViewSQLScintilla.Styles[Style.Sql.Character].ForeColor = Color.Red;
            ViewSQLScintilla.Styles[Style.Sql.Operator].ForeColor = Color.Black;

            ViewSQLScintilla.Styles[Style.Sql.Default].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.Identifier].BackColor = backColor;

            ViewSQLScintilla.Styles[Style.Sql.Comment].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.CommentLine].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.CommentLineDoc].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.Number].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.Word].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.Word2].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.User1].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.User2].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.String].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.Character].BackColor = backColor;
            ViewSQLScintilla.Styles[Style.Sql.Operator].BackColor = backColor;

            // Set keyword lists
            // Word = 0
            ViewSQLScintilla.SetKeywords(0, @"add alter as authorization backup begin bigint binary bit break browse bulk by cascade case catch check checkpoint close clustered column commit compute constraint containstable continue create current cursor cursor database date datetime datetime2 datetimeoffset dbcc deallocate decimal declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor float for foreign freetext freetexttable from full function goto grant group having hierarchyid holdlock identity identity_insert identitycol if image index insert int intersect into key kill lineno load merge money national nchar nocheck nocount nolock nonclustered ntext numeric nvarchar of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext real reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select set setuser shutdown smalldatetime smallint smallmoney sql_variant statistics table table tablesample text textsize then time timestamp tinyint to top tran transaction trigger truncate try union unique uniqueidentifier update updatetext use user values varbinary varchar varying view waitfor when where while with writetext xml go ");
            // Word2 = 1
            ViewSQLScintilla.SetKeywords(1, @"ascii cast char charindex ceiling coalesce collate contains convert current_date current_time current_timestamp current_user floor isnull max min nullif object_id session_user substring system_user tsequal ");
            // User1 = 4
            ViewSQLScintilla.SetKeywords(4, @"all and any between cross exists in inner is join left like not null or outer pivot right some unpivot ( ) * ");
            // User2 = 5
            ViewSQLScintilla.SetKeywords(5, @"sys objects sysobjects ");

            // Instruct the lexer to calculate folding
            ViewSQLScintilla.SetProperty("fold", "1");
            ViewSQLScintilla.SetProperty("fold.comment", "1");

            ViewSQLScintilla.SetFoldFlags(FoldFlags.LineAfterContracted);

            // Enable automatic folding
            ViewSQLScintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }






        private void GetDBInfo2(string FileName2)
        {
            string connString = "Data Source = " + FileName2 + ";Version=3;";
            DataTable DataTable1 = new DataTable();
            SQLiteConnection Conn = new SQLiteConnection(connString);
            Conn.Open();
            string sql = "SELECT name FROM sqlite_master WHERE (type =  'table' OR type = 'view') ORDER BY 1";
            SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(sql, Conn);
            IsTableGridInitializing = true;
            dAdapter.Fill(DataTable1);
            if (DataTable1.Rows.Count > 0)
            {
                dataGridViewTables.DataSource = DataTable1;
                dataGridViewTables.Columns[0].Width = 600;
                //string FName = comboBoxFiles.SelectedItem.ToString();
                string TableName = DataTable1.Rows[0].Field<String>("name");
                getSQLiteTable2(FileName2, TableName);
                if (dataGridViewTablesIsNotFormatted)
                {
                    getSQLiteTable2(FileName2, TableName);
                    dataGridViewTablesIsNotFormatted = false;
                }
            }
            else
            {
                DataTable1.Clear();
                dataGridViewTables.DataSource = DataTable1;
            }
            IsTableGridInitializing = false;
            this.dataGridViewTables.CurrentCell = this.dataGridViewTables[0, 0];
        }
        
        
        int LoadDataTable(DataGridView dgv, string connString, string query)
        {
            int result = 0;
            try
            {
                dgv.DataSource = null;
                DataTable dTable = new DataTable();
                SQLiteConnection con = new SQLiteConnection(connString);
                con.Open();
                SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(query, con);
                dAdapter.Fill(dTable);
                con.Close();
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dTable;
                dgv.DataSource = bSource;
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            }
            catch (Exception ex)
            {
                richTextBoxSQLErrors.Text = ex.ToString();
                result = 1;
            }
            return result;
        }

        private int runSQLiteCmd(string connString, string CmdStr)
        {
            int result = 0;
            try
            {
                var Connection = new SQLiteConnection();
                Connection.ConnectionString = connString;
                Connection.Open();
                var Command = new SQLiteCommand();
                Command.Connection = Connection;
                Command.CommandText = CmdStr;
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                richTextBoxSQLErrors.Text = ex.ToString();
                result = 1;
            }
            return result;
        }



//        private void getSQLiteTable(string FName, string TableOrViewOrTriggerName)
//        {
//            FormatDataGridViewTablesOutputForGeneralTable();
//            string t = comboBoxFiles.SelectedItem.ToString();
//            string t2 = " 'table' ";
////            string t2 = " 'view' ";
//            
//            if (t == "*.dbTables") t2 = " 'table' ";
//            if (t == "*.dbViews") t2 = " 'view' ";
//
//            string FileName = GetFullWorkPath() + @"\" + FName;
//            string connString = "Data Source = " + FileName + ";Version=3;";
//            if ((t == "*.dbTables") || (t == "*.dbViews"))
//            {
//                //MessageBox.Show("In getSQLiteTable");
//                string query = "select * from " + TableOrViewOrTriggerName;
//                int result = LoadDataTable(dataGridViewTablesOutput, connString, query);
//                if (result == 1)
//                {
//                    ShowOutputItem(0);
//                    tabControl1.SelectedTab = tabViewer;
//                    return;
//                }
//            }
//
//
//            String Code = "";
//            var conn = new SQLiteConnection("Data Source=" + FileName + ";Version=3;");
//            conn.Open();
//            DataSet ds = new DataSet();
//            //string sql = "Select sql From sqlite_master where type='table' and name='" + TableOrViewOrTriggerName + "';";
//            string sql = "Select sql From sqlite_master where type= " + t2 + " and name='" + TableOrViewOrTriggerName + "';";
//
//
//            //string sql = "Select sql From sqlite_master where type='view' and name='" + TableName + "';";
//            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
//            da.Fill(ds);
//            foreach (DataRow row in ds.Tables[0].Rows)
//            {
//                Code = row["sql"].ToString();
//            }
//            if (ds != null)
//                ds.Dispose();
//
//            ViewSQLScintilla.ReadOnly = false;
//            ViewSQLScintilla.Text = Code;
//            ViewSQLScintilla.ReadOnly = true;
//            openFileByName("between.sql");
//            ShowEditorAndSqlViewer();
//        }


        private void getSQLiteTable2(string FileName, string TableOrViewOrTriggerName)
        {
            FormatDataGridViewTablesOutputForGeneralTable();
            string t = comboBoxFiles.SelectedItem.ToString();
            string t2 = " 'table' ";
            if (TableOrViewOrTriggerName.StartsWith("View_")) {t2 = " 'view' "; }

            //string FileName = GetFullWorkPath() + @"\" + FName;
            string connString = "Data Source = " + FileName + ";Version=3;";
//            if ((t == "*.dbTables") || (t == "*.dbViews"))
//            {
                //MessageBox.Show("In getSQLiteTable");
                string query = "select * from " + TableOrViewOrTriggerName;
                int result = LoadDataTable(dataGridViewSQLiteDb, connString, query);
                if (result == 1)
                {
                //ShowOutputItem(0);
                tabControlSQLiteDb.SelectedTab = tabErrors;
                    return;
                }
//            }


            String Code = "";
            var conn = new SQLiteConnection("Data Source=" + FileName + ";Version=3;");
            conn.Open();
            DataSet ds = new DataSet();
            //string sql = "Select sql From sqlite_master where type='table' and name='" + TableOrViewOrTriggerName + "';";
            string sql = "Select sql From sqlite_master where type= " + t2 + " and name='" + TableOrViewOrTriggerName + "';";


            //string sql = "Select sql From sqlite_master where type='view' and name='" + TableName + "';";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Code = row["sql"].ToString();
            }
            if (ds != null)
                ds.Dispose();

            ViewSQLScintilla.ReadOnly = false;
            ViewSQLScintilla.Text = Code;
            ViewSQLScintilla.ReadOnly = true;
            //openFileByName("between.sql");
            //ShowEditorAndSqlViewer();
        }





        //private void getSQLiteTable2(string FName, string TableOrViewOrTriggerName)
        //{
        //    FormatDataGridViewTablesOutputForGeneralTable();
        //    string t = comboBoxFiles.SelectedItem.ToString();
        //    string t2 = " 'table' ";
        //    if (TableOrViewOrTriggerName.StartsWith("View_")) { t2 = " 'view' "; }

        //    string FileName = GetFullWorkPath() + @"\" + FName;
        //    string connString = "Data Source = " + FileName + ";Version=3;";
        //    //            if ((t == "*.dbTables") || (t == "*.dbViews"))
        //    //            {
        //    //MessageBox.Show("In getSQLiteTable");
        //    string query = "select * from " + TableOrViewOrTriggerName;
        //    int result = LoadDataTable(dataGridViewTablesOutput, connString, query);
        //    if (result == 1)
        //    {
        //        //ShowOutputItem(0);
        //        tabControlSQLiteDb.SelectedTab = tabErrors;
        //        return;
        //    }
        //    //            }


        //    String Code = "";
        //    var conn = new SQLiteConnection("Data Source=" + FileName + ";Version=3;");
        //    conn.Open();
        //    DataSet ds = new DataSet();
        //    //string sql = "Select sql From sqlite_master where type='table' and name='" + TableOrViewOrTriggerName + "';";
        //    string sql = "Select sql From sqlite_master where type= " + t2 + " and name='" + TableOrViewOrTriggerName + "';";


        //    //string sql = "Select sql From sqlite_master where type='view' and name='" + TableName + "';";
        //    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
        //    da.Fill(ds);
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        Code = row["sql"].ToString();
        //    }
        //    if (ds != null)
        //        ds.Dispose();

        //    ViewSQLScintilla.ReadOnly = false;
        //    ViewSQLScintilla.Text = Code;
        //    ViewSQLScintilla.ReadOnly = true;
        //    //openFileByName("between.sql");
        //    //ShowEditorAndSqlViewer();
        //}







    }



}
