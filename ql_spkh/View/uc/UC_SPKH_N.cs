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
using Microsoft.Office.Interop.Word;
using ql_spkh.Model;
namespace ql_spkh.View.uc
{
    
    public partial class UC_SPKH_N : UserControl
    {
        public UC_SPKH_N(int isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
        }
        private int isCreate;
        private int projectidNew = -1;
        private void btnNhap_Click(object sender, EventArgs e)
        {

        }

        private void btnNhap_Click_1(object sender, EventArgs e)
        {
            loadNoidung2();
        }
        private void loadNoidung1()
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if( fileDialog.ShowDialog()== DialogResult.OK)
                {
                    txtFile.Text = fileDialog.FileName;
                    object readOnly = false;
                    object visiable = true;
                    object save = false;
                    object fileName = fileDialog.FileName;
                    object newTemplate = false;
                    object docType = 0;
                    object missing = Type.Missing;
                    pbLoad.Visible = true;

                    Microsoft.Office.Interop.Word._Document document;
                    Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                    document = application.Documents.Open(ref fileName,
                    ref missing, ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref visiable, ref missing, ref missing, ref missing, ref missing);
                    document.ActiveWindow.Selection.WholeStory();
                    document.ActiveWindow.Selection.Copy();

                    IDataObject dataObject = Clipboard.GetDataObject();

                    Invoke(new Action(() => { rtbShow.Rtf = dataObject.GetData(DataFormats.Rtf).ToString(); }));
                    //rtbShow.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();

                    pbLoad.Visible = false;
                    application.Quit(ref missing, ref missing, ref missing);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadNoidung2()
        {
            pbLoad.Visible = true;
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = fileDialog.FileName;
                object readOnly = false;
                object visiable = true;
                object save = false;
                object fileName = fileDialog.FileName;
                object newTemplate = false;
                object docType = 0;
                object missing = Type.Missing;
                pbLoad.Visible = true;

                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    try
                    {
                        string content = "";
                        if (true)
                        {
                            Microsoft.Office.Interop.Word._Document doc;
                            Microsoft.Office.Interop.Word._Application app = new Microsoft.Office.Interop.Word.Application();

                            doc = app.Documents.Open(fileName, ReadOnly: true, Visible: false);

                            doc.ActiveWindow.Selection.WholeStory();
                            doc.ActiveWindow.Selection.Copy();
                            
                                this.Invoke((MethodInvoker)delegate
                                {
                                    if (Clipboard.ContainsData(DataFormats.Rtf))
                                    {
                                        IDataObject dataObject = Clipboard.GetDataObject();
                                        if (dataObject.GetDataPresent(DataFormats.Rtf))
                                        {
                                            try
                                            {
                                                content = dataObject.GetData(DataFormats.Rtf).ToString();
                                            }
                                            catch (Exception)
                                            {
                                                MessageBox.Show("Đọc dữ liệu không hoàn chỉnh tuy nhiên điều này không ảnh hưởng việc thêm dữ liệu vào CSDL", "Thông báo");
                                            }
                                        }
                                    }
                                });
                            doc.Close();
                            app.Quit();
                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            rtbShow.Rtf = content;
                            pbLoad.Visible = false;
                        });
                    }
                    catch (Exception ex)
                    {
                        logError.log(ex.Message);
                        MessageBox.Show("Không tải được dữ liệu", "Lỗi");
                    }
                });
            }
        }
        private void UC_SPKH_N_Load(object sender, EventArgs e)
        {

            //Danh sách khoa
            string sql = "SELECT * FROM departments";
            cbbKhoa.DataSource = new database().QuerySQL(sql);
            cbbKhoa.DisplayMember = "departmentname";
            cbbKhoa.ValueMember = "departmentid";

            cbbKhoa.SelectedIndex = 0;
            //Danh sách giảng viên
            string sql2 = "SELECT * FROM advisors";
            cbbGV.DataSource = new database().QuerySQL(sql2);
            cbbGV.DisplayMember = "advisorname";
            cbbGV.ValueMember = "advisorid";
            cbbGV.SelectedIndex = 0;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string khoa, gv, grade, version = "", start, end, title,file;
            khoa = cbbKhoa.SelectedValue.ToString();
            gv = cbbGV.SelectedValue.ToString();
            int tmp = 0;
            int.TryParse(txtGrade.Text.Trim(), out tmp);
            grade = tmp.ToString();
            version = txtVersion.Text;
            title = txtTile.Text.Trim();
            start = dtpStart.Value.ToString("yyyy-MM-dd");
            end = dtpEnd.Value.ToString("yyyy-MM-dd");
            file = txtFile.Text.Trim();

            if(String.IsNullOrEmpty(title) || String.IsNullOrEmpty(version))
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql = "ThemProject";
                List<parameter> lst = new List<parameter>();
                lst.Add(new parameter()
                {
                    key = "@title",
                    value = title
                });
                lst.Add(new parameter()
                {
                    key = "@departmentid",
                    value = khoa
                });
                lst.Add(new parameter()
                {
                    key = "@advisorid",
                    value = gv
                });
                lst.Add(new parameter()
                {
                    key = "@startdate",
                    value = start
                });
                lst.Add(new parameter()
                {
                    key = "@enddate",
                    value = end
                });
                lst.Add(new parameter()
                {
                    key = "@FilePath",
                    value = file
                });
                lst.Add(new parameter()
                {
                    key = "@grade",
                    value = grade
                });
                lst.Add(new parameter()
                {
                    key = "@version",
                    value = version
                });
                lst.Add(new parameter()
                {
                    key = "@typeproject",
                    value = isCreate.ToString()
                });
                parameter.kiemTra_Value(lst);
                pbLoad.Visible = true;
                await System.Threading.Tasks.Task.Run(() =>
                {
                       return new database().Query_P(sql, lst);
                }).ContinueWith(task =>
                {
                    pbLoad.Invoke((Action)delegate
                    {
                        pbLoad.Visible = false;
                    });
                    int kq = task.Result;
                    if (kq != 0)
                    {
                        this.projectidNew = kq;
                        int id = int.Parse(new database().QuerySQL("SELECT TOP 1 projectid FROM projects ORDER BY projectid DESC").Rows[0][0].ToString());

                        string type = "CREATE";
                        string detail = "Username " + user.username + ", CREATE đề tài khoa học title: "+title+", id: "+id+", khoa: "+khoa+", giảng viên: "+gv+", Điểm: "+grade;
                        new database().ActivityLog(type, detail);
                        new frmCoreTD(title, isCreate).ShowDialog();
                        DialogResult rs =  MessageBox.Show("Thêm dữ liệu thành công, Tiếp tục nhập dữ liệu thành viên tham gia", "Thành công"+ id, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(rs == DialogResult.Yes)
                        {
                            new frmSV(id).ShowDialog();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại", "Thất bại"+kq);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
                
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtGrade.Clear();
            txtTile.Clear();
            txtVersion.Clear();
            txtFile.Clear();
        }
       private async System.Threading.Tasks.Task Loadnoidung(byte[] noiDungBytes)
       {
           pbLoad.Visible = true;

           string directoryPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Trash");
           if (!Directory.Exists(directoryPath))
           {
               Directory.CreateDirectory(directoryPath);
           }
           string fName = Path.Combine(directoryPath, "file_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rtf");
           if (noiDungBytes == null)
           {
               MessageBox.Show("Null", "ERROR");
               return;
           }

           await System.Threading.Tasks.Task.Run(() =>
           {
               File.WriteAllBytes(fName, noiDungBytes);

               try
               {
                   string content = "";
                   if (File.Exists(fName))
                   {
                       var app = new Microsoft.Office.Interop.Word.Application();
                       var doc = app.Documents.Open(fName, ReadOnly: true, Visible: false);

                       doc.ActiveWindow.Selection.WholeStory();
                       doc.ActiveWindow.Selection.Copy();

                       if (Clipboard.ContainsData(DataFormats.Rtf))
                       {
                           var dataObject = Clipboard.GetDataObject();
                           if (dataObject.GetDataPresent(DataFormats.Rtf))
                           {
                               content = dataObject.GetData(DataFormats.Rtf).ToString();
                           }
                       }
                       doc.Close();
                       app.Quit();
                   }

                   // Sử dụng Invoke để truy cập thành phần UI từ luồng UI chính
                   Invoke(new Action(() => { rtbShow.Rtf = content; }));
               }
               catch (Exception ex)
               {
                   logError.log(ex.Message);
                   MessageBox.Show("Không tải được dữ liệu", "Lỗi");
               }
               finally
               {
                   if (File.Exists(fName))
                   {
                       File.Delete(fName);
                   }
                   this.Invoke((MethodInvoker)delegate {
                       pbLoad.Visible = false;
                       });
                }
           });
       }
       
    }
}
