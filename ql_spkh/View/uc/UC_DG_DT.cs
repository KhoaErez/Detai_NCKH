using Microsoft.Office.Interop.Word;
using ql_spkh.Levenshtein;
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

namespace ql_spkh.View.uc
{
    public partial class UC_DG_DT : UserControl
    {
        public UC_DG_DT()
        {
            InitializeComponent();
        }
        private string content1 = null;
        private string content2 = null;

        private int button_click = 0;
        private void UC_DG_DT_Load(object sender, EventArgs e)
        {

        }

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
            if (button_click == 0)
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
                    else if (Path.GetExtension(filePath).Equals(".doc", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(filePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
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
            if (content1 == null || content2 == null)
            {
                MessageBox.Show("Dữ liệu không đầy đủ", "Lỗi");
                pbLoad.Visible = false;
                btnChon1.Enabled = true;
                btnChon2.Enabled = true;
                btnNhap1.Enabled = true;
                btnNhap2.Enabled = true;
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
                        txtKQ.Text += Task.Result + "%, Thời gian thực thi: " + LevenshteinRun.timeRun;
                        pbLoad.Visible = false;
                        btnChon1.Enabled = true;
                        btnChon2.Enabled = true;
                        btnNhap1.Enabled = true;
                        btnNhap2.Enabled = true;
                    });
                });

            }
        }
    }
}
