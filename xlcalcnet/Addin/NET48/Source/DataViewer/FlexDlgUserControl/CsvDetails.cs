using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TinyDataViewerCtrl
{
    public partial class DataViewerCtrl : UserControl
    {


        private void readCSV(string filePath)
        {
            var dt = new DataTable();
            // Creating the columns
            foreach (var headerLine in File.ReadLines(filePath, Encoding.UTF8).Take(1))
            {
                foreach (var headerItem in headerLine.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dt.Columns.Add(headerItem.Trim());
                }
            }

            // Adding the rows
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                dt.Rows.Add(line.Split(','));
            }

            dataGridViewTablesOutput.DataSource = dt;

            FormatDataGridViewTablesOutputForGeneralTable();
        }


        //private void readCSV(string filePath)
        //{
        //    var dt = new DataTable();
        //    // Creating the columns
        //    foreach (var headerLine in File.ReadLines(filePath, Encoding.UTF8).Take(1))
        //    {
        //        foreach (var headerItem in headerLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            dt.Columns.Add(headerItem.Trim());
        //        }
        //    }

        //    // Adding the rows
        //    foreach (var line in File.ReadLines(filePath).Skip(1))
        //    {
        //        dt.Rows.Add(line.Split(';'));
        //    }

        //    dataGridViewTablesOutput.DataSource = dt;

        //    FormatDataGridViewTablesOutputForGeneralTable();
        //}


        private void readDataInputCSV(string filePath, DataGridView dgv)
        {
            var dt = new DataTable();
            // Creating the columns
            foreach (var headerLine in File.ReadLines(filePath, Encoding.UTF8).Take(1))
            {
                foreach (var headerItem in headerLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dt.Columns.Add(headerItem.Trim());
                }
            }

            // Adding the rows
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                dt.Rows.Add(line.Split(';'));
            }

            DataView view = new DataView(dt);
            DataTable dt1 = view.ToTable("dt1", false, "RowHeaders");
            dt.Columns.Remove("RowHeaders");

            dgv.DataSource = dt;
            for (int i = 0; i < dgv.ColumnCount; i++)
            { dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; }

            for (int j = 0; j < dgv.RowCount; j++)
            { dgv.Rows[j].HeaderCell.Value = dt1.Rows[j][0].ToString(); }
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }





        private void FormatDataGridViewTablesOutputForGeneralTable()
        {
            this.dataGridViewTablesOutput.RowHeadersVisible = false;

        }


        private void FormatDataGridViewTablesOutputForStats()
        {

            this.dataGridViewTablesOutput.RowHeadersVisible = true;
        }




    }

}
