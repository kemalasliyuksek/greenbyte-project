using System.Drawing;
using System.Windows.Forms;

namespace greenByte
{
    internal static class Utils
    { 
             public static void StyleDataGrid(DataGridView dgv)
             {
                if (dgv == null) return;

                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgv.RowHeadersVisible = false;
                dgv.BorderStyle = BorderStyle.None;
                dgv.GridColor = Color.LightGray;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.RowTemplate.Height = 32;

                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
        }

    }
}
