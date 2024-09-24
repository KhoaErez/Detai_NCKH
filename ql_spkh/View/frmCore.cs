using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using ql_spkh.Model;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_spkh.Levenshtein;
namespace ql_spkh.View
{
    public partial class frmCore : Form
    {
        public frmCore()
        {
            InitializeComponent();
        }
        private string content1 = null;
        private string content2 = null;

        private int button_click = 0;

        private int typeproject = 0;
        private int loadFirst = 0;
        private void btnChon1_Click(object sender, EventArgs e)
        {
            button_click = 0;
            frmChon form2 = new frmChon();
            form2.DataReady += Form2_DataReady;
            form2.ShowDialog();
        }
        private void Form2_DataReady(object sender, DataReadyEventArgs e)
        {
            string titlle = e.title;
            string dataFromForm2 = e.Data;
            if(button_click == 0)
            {
                txtFile1.Text = titlle;
                content1 = dataFromForm2;
                //MessageBox.Show(content1);
            }
            else
            {
                txtFile2.Text = titlle;
                content2 = dataFromForm2;
                //MessageBox.Show(content2);
            }
        }

        private void frmCore_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> dataList = new List<KeyValuePair<string, string>>();

            // Thêm các mục vào danh sách
            dataList.Add(new KeyValuePair<string, string>("0", "Đề tài NCKH CS"));
            dataList.Add(new KeyValuePair<string, string>("1", "Đề tài NCKH SV"));
            dataList.Add(new KeyValuePair<string, string>("2", "Sáng tạo KN"));

            // Đặt danh sách dữ liệu vào ComboBox
            cbbLoaiProject.DisplayMember = "Value"; // Hiển thị dữ liệu này
            cbbLoaiProject.ValueMember = "Key"; // Dữ liệu trả về
            cbbLoaiProject.DataSource = dataList;

            cbbLoaiProject.SelectedIndex = 0;
        }

        private void btnChon2_Click(object sender, EventArgs e)
        {
            button_click = 1;
            frmChon form2 = new frmChon();
            form2.DataReady += Form2_DataReady;
            form2.ShowDialog();
        }

        private void btnNhap1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Tập tin văn bản|*.txt|Tập tin Word|*.docx|Tất cả các tập tin|*.*";
            openFileDialog.Title = "Chọn tập tin để mở";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (File.Exists(filePath))
                {
                    
                    if (Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        content1 = File.ReadAllText(filePath);
                    }
                    else if (Path.GetExtension(filePath).Equals(".doc", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(filePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
                    {
                        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                        Document doc = wordApp.Documents.Open(filePath);
                        content1 = doc.Content.Text;
                        doc.Close();
                        wordApp.Quit();
                    }
                    else
                    {
                        MessageBox.Show("Phần mở rộng không được hỗ trợ.");
                        return;
                    }

                    txtFile1.Text = filePath;

                }
                else
                {
                    MessageBox.Show("Tập tin không tồn tại.");
                }
            }
        }

        private void btnNhap2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Tập tin văn bản|*.txt|Tập tin Word|*.docx|Tất cả các tập tin|*.*";
            openFileDialog.Title = "Chọn tập tin để mở";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (File.Exists(filePath))
                {

                    if (Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        content2 = File.ReadAllText(filePath);
                    }
                    else if (Path.GetExtension(filePath).Equals(".doc", StringComparison.OrdinalIgnoreCase)|| Path.GetExtension(filePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
                    {
                        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                        Document doc = wordApp.Documents.Open(filePath);
                        content2 = doc.Content.Text;
                        doc.Close();
                        wordApp.Quit();
                    }
                    else
                    {
                        MessageBox.Show("Phần mở rộng không được hỗ trợ.");
                        return;
                    }

                    txtFile2.Text = filePath;

                }
                else
                {
                    MessageBox.Show("Tập tin không tồn tại.");
                }
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            btnChon1.Enabled = false;
            btnChon2.Enabled = false;
            btnNhap1.Enabled = false;
            btnNhap2.Enabled = false;
            if(content1 == null || content2 == null)
            {
                MessageBox.Show("Dữ liệu không đầy đủ", "Lỗi");
            }
            else
            {
                pbLoad.Visible = true;
                System.Threading.Tasks.Task.Run(() =>
                {
                    return LevenshteinRun.run(content1, content2);
                }).ContinueWith(Task =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtKQ.Text += Task.Result+"%, Thời gian thực thi: "+LevenshteinRun.timeRun;
                        pbLoad.Visible = false;
                        btnChon1.Enabled = true;
                        btnChon2.Enabled = true;
                        btnNhap1.Enabled = true;
                        btnNhap2.Enabled = true;
                    });
                });
                
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT title FROM projects WHERE typeproject = " + typeproject;

            System.Data.DataTable rs = new System.Data.DataTable();
            rs = new database().QuerySQL(sql);
            List<KeyValuePair<string, int>> dataList = new List<KeyValuePair<string, int>>();
            btnChon1.Enabled = false;
            btnChon2.Enabled = false;
            btnNhap1.Enabled = false;
            btnNhap2.Enabled = false;
            guna2Button1.Enabled = false;
            System.Threading.Tasks.Task.Run(() =>
            {
                foreach (DataRow row in rs.Rows)
                {
                    string ten = row["title"].ToString();
                    int giaTri = int.Parse(LevenshteinRun.run(txtTileKey.Text,ten)); 

                    dataList.Add(new KeyValuePair<string, int>(ten, giaTri));
                }
                dataList.Sort((x, y) => y.Value.CompareTo(x.Value));
                this.Invoke((MethodInvoker)delegate
                {
                    //new frmCoreTD(dataList).Show();
                    pbLoad.Visible = false;
                    btnChon1.Enabled = true;
                    btnChon2.Enabled = true;
                    btnNhap1.Enabled = true;
                    btnNhap2.Enabled = true;
                    guna2Button1.Enabled=true;
                });
            });
        }

        private void cbbLoaiProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadFirst == 0)
            {
                loadFirst = 1;
                return;
            }
            typeproject = int.Parse(cbbLoaiProject.SelectedValue?.ToString());
        }
    }
}
