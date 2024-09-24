using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_spkh.Model;
namespace ql_spkh.View
{
    public partial class frmHTR : Form
    {
        public frmHTR()
        {
            InitializeComponent();
        }
        private DataTable log = new DataTable();
        private void frmHTR_Load(object sender, EventArgs e)
        {
            load();
            guna2ComboBox1.SelectedIndex = 0;
        }
        int keySearch = 0;
        private void load()
        {
            string sql = "SELECT * FROM activitylog";
            log=new database().QuerySQL(sql);
            dgvData.DataSource = log;
        }
        private void btnDon_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Hành động sẽ xóa hết lịch sử đã lưu. Khuyến nghị nên sao ra trước khi xóa.", "Cảnh báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rs == DialogResult.Yes)
            {
                string sql = "DELETE FROM activitylog";
                if(new database().QuerySQL_No(sql) > 0)
                {
                    MessageBox.Show("Dọn lịch sử thành công","Xong");
                    load();
                }
                else
                {
                    MessageBox.Show("ERROR", "ERROR");
                }
            }
        }

        private void btnSao_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    if(log != null)
                    {
                        WriteDataTableToFile(log, filePath);

                        MessageBox.Show("Dữ liệu đã ghi ra file","Thành công"); 
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu","EROR");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn 1 file .txt");
                }
            }
        }
        private void WriteDataTableToFile(DataTable dataTable, string filePath)
        {
            
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                
                foreach (DataColumn column in dataTable.Columns)
                {
                    writer.Write(column.ColumnName);
                    writer.Write("\t"); 
                }
                writer.WriteLine();

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        writer.Write(item.ToString());
                        writer.Write("\t"); 
                    }
                    writer.WriteLine(); 
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string sql = "SELECT * FROM activitylog WHERE" +
                " type like N'%"+key+"%'" +
                " OR details like N'%" + key + "%'";
            if(keySearch == 0)
            {
                sql = "SELECT * FROM activitylog WHERE userid = " + key;
            }
            log = new database().QuerySQL(sql);
            dgvData.DataSource = log;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keySearch = guna2ComboBox1.SelectedIndex;
        }
    }
}
