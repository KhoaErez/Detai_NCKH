using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_spkh.Model;
namespace ql_spkh.View.uc
{
    public partial class UC_SPKH_DT : UserControl
    {
        public UC_SPKH_DT(int id, frmSPKH cha)
        {
            InitializeComponent();
            this.projectCurr = id;
            this.cha = cha;
        }
        private int projectCurr;
        private frmSPKH cha;
        private int checkLoad = 0;
        private byte[] noiDungBytesCrr;
        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UC_SPKH_DT_Load(object sender, EventArgs e)
        {
            if(user.role == 1)
            {
                btnLuu.Enabled = false;
                btnNhap.Enabled = false;
                btnTaoV.Enabled = false;
                btnXoa.Enabled = false;
            }
            //Danh sách khoa
            string sql = "SELECT * FROM departments";
            cbbKhoa.DataSource = new database().QuerySQL(sql);
            cbbKhoa.DisplayMember = "departmentname";
            cbbKhoa.ValueMember = "departmentid";

            //Danh sách giảng viên
            string sql2 = "SELECT * FROM advisors";
            cbbGV.DataSource = new database().QuerySQL(sql2);
            cbbGV.DisplayMember = "advisorname";
            cbbGV.ValueMember = "advisorid";

            //Danh sách version
            load_version();

            load();
        }
        private void load_version()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            // Thêm cột versionid và versionname vào DataTable
            dt.Columns.Add("versionid", typeof(string));
            dt.Columns.Add("versionname", typeof(string));

            dt.Rows.Add("0", "0");

            string sql3 = "SELECT versionid, versionname FROM projectversions WHERE projectid = " + projectCurr;
            System.Data.DataTable dtFromDB = new System.Data.DataTable();
            dtFromDB = new database().QuerySQL(sql3);
            if (dtFromDB != null && dtFromDB.Rows.Count > 0)
            {
                foreach (DataRow row in dtFromDB.Rows)
                {
                    dt.Rows.Add(row["versionid"], row["versionname"]);
                }
            }

            cbbVersion.DataSource = dt;

            cbbVersion.DisplayMember = "versionname";
            cbbVersion.ValueMember = "versionid";

            cbbVersion.SelectedIndex = 0;

        }
        private void load()
        {
            string sql = "SELECT title,departmentid,advisorid,startdate,enddate,grade FROM projects WHERE projectid = " + projectCurr;
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = new database().QuerySQL(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTieuDe.Text = dt.Rows[0]["title"].ToString();
                cbbKhoa.SelectedValue = dt.Rows[0]["departmentid"].ToString();
                cbbGV.SelectedValue = dt.Rows[0]["advisorid"].ToString();
                DateTime startdate = Convert.ToDateTime(dt.Rows[0]["startdate"]);
                DateTime enddate = Convert.ToDateTime(dt.Rows[0]["enddate"]);
                dtpStart.Value = startdate;
                dtpEnd.Value = enddate;
                txtDiem.Text = dt.Rows[0]["grade"].ToString();
                //cbbVersion.SelectedIndex = 0;

                byte[] noiDungBytes = new database().GetNoiDung(projectCurr);//(byte[])dt.Rows[0]["projectcontent"];

                Loadnoidung2(noiDungBytes);//rtbShow.Text = System.Text.Encoding.UTF8.GetString(noiDungBytes); //noiDungBytes.ToString();

            }
        }
        
        private void Loadnoidung2(byte[] noiDungBytes)
        {
            this.noiDungBytesCrr = noiDungBytes;
            pbLoad.Visible = true;
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                string directoryPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Trash");
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                string fName = System.IO.Path.Combine(directoryPath, "file_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rtf");
                if (noiDungBytes == null)
                {
                    MessageBox.Show("Null", "ERROR");
                    return;
                }
                File.WriteAllBytes(fName, noiDungBytes);

                try
                {
                    string content = "";
                    if (File.Exists(fName))
                    {
                        Microsoft.Office.Interop.Word._Document doc;
                        Microsoft.Office.Interop.Word._Application app = new Microsoft.Office.Interop.Word.Application();

                        doc = app.Documents.Open(fName, ReadOnly: true, Visible: false);

                        doc.ActiveWindow.Selection.WholeStory();
                        doc.ActiveWindow.Selection.Copy();
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (Clipboard.ContainsData(DataFormats.Rtf))
                            {
                                IDataObject dataObject = Clipboard.GetDataObject();
                                if (dataObject != null && dataObject.GetDataPresent(DataFormats.Rtf))
                                {
                                    object data = dataObject.GetData(DataFormats.Rtf);
                                    if (data != null)
                                    {
                                        content = data.ToString();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Dataobjectnull", "ERROR");
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
                finally
                {
                    if (File.Exists(fName))
                    {
                        File.Delete(fName);
                    }
                }
            });
            
        }
        
        private void Loadnoidung(byte[] noiDungBytes)
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
        }
        
        private void btnMember_Click(object sender, EventArgs e)
        {
            new frmSV(projectCurr).ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xóa toàn bộ các version và bản gốc","Cảnh bảo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes )
            {
                string sql = "DELETE FROM projectversions WHERE projectid = " + projectCurr;
                string sql2 = "DELETE FROM projects WHERE projectid = " + projectCurr;
                string sql3 = "DELETE FROM projectparticipants WHERE projectid = " + projectCurr;
                try
                {
                    new database().QuerySQL_No(sql);
                    new database().QuerySQL_No(sql3);
                    if (new database().QuerySQL_No(sql2) > 0)
                    {
                        MessageBox.Show("Xóa thành công", "Thành công");

                        string type = "DELETE";
                        string detail = "Username " + user.username + ", Xóa project có id: " + projectCurr+", title: "+txtTieuDe.Text+", Khoa: "+cbbKhoa.Text+", giang vien: "+cbbGV.Text+", Time: "+dtpStart.Value.ToString()+" - "+dtpEnd.Value.ToString();
                        //MessageBox.Show(detail);
                        new database().ActivityLog(type, detail);

                        cha.close_uc();
                        cha.load();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR");
                    logError.log(ex.Message);
                }   
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            string khoa, gv, grade, start, end, title;
            khoa = cbbKhoa.SelectedValue.ToString();
            gv = cbbGV.SelectedValue.ToString();
            int tmp = 0;
            int.TryParse(txtDiem.Text.Trim(), out tmp);
            grade = tmp.ToString();
            title = txtTieuDe.Text.Trim();
            start = dtpStart.Value.ToString("yyyy-MM-dd");
            end = dtpEnd.Value.ToString("yyyy-MM-dd");


            if (String.IsNullOrEmpty(title))
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql = "Update_P";
                List<parameter> lst = new List<parameter>();
                lst.Add(new parameter()
                {
                    key = "@projectid",
                    value = projectCurr.ToString()
                });
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
                    key = "@grade",
                    value = grade
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
                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công", "Thành công" + kq);
                        string type = "UPDATE";
                        string detail = "Username " + user.username + ", Cập nhật project có id: " + projectCurr + ", title: " + txtTieuDe.Text+", khoa: "+cbbKhoa.Text+", giảng viên: "+cbbGV.Text+", điểm: "+txtDiem.Text;
                        new database().ActivityLog(type, detail);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dữ liệu thất bại", "Thất bại");
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileDialog.ShowDialog();
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
                    rtbShow.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();

                    pbLoad.Visible = false;
                    application.Quit(ref missing, ref missing, ref missing);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private async void btnTaoV_Click(object sender, EventArgs e)
        {
            string filePath, ten, mieuta;
            filePath = txtFile.Text.Trim();
            ten = txtVersionN.Text.Trim();
            mieuta = txtDescription.Text.Trim();

            if(filePath!=""&&ten!=""&&mieuta!="")
            {
                if(MessageBox.Show("Tạo 1 bản lưu trữ khác của project này. Điều này chị tạo ra 1 nội dung mới và không ảnh hưởng đến bản gốc","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    string sql = "Them_v";
                    List<parameter> parameters = new List<parameter>();
                    parameters.Add(new parameter()
                    {
                        key = "@projectid",
                        value = projectCurr.ToString()
                    }); ;
                    parameters.Add(new parameter()
                    {
                        key = "@versionname",
                        value = ten
                    });
                    parameters.Add(new parameter()
                    {
                        key = "@description",
                        value = mieuta
                    });
                    parameters.Add(new parameter()
                    {
                        key = "@FilePath",
                        value = filePath
                    });
                    parameter.kiemTra_Value(parameters);
                    pbLoad.Visible = true;
                    await System.Threading.Tasks.Task.Run(() =>
                    {
                        return new database().Query_P(sql, parameters);
                    }).ContinueWith(task =>
                    {
                        pbLoad.Invoke((Action)delegate
                        {
                            pbLoad.Visible = false;
                        });
                        int kq = task.Result;
                        if (kq > 0)
                        {
                            MessageBox.Show("Cập nhật dữ liệu thành công", "Thành công");
                            string type = "CREATE";
                            string detail = "Username " + user.username + ", Tạo version mới cho projectid: "+projectCurr+", tiêu đề version: "+txtVersionN.Text+", miêu tả: "+txtDescription.Text;
                            new database().ActivityLog(type, detail);
                            load_version();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật dữ liệu thất bại", "Thất bại");
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
            else
            {
                MessageBox.Show("Điền đầy đủ thông tin", "Thất bại");
            }
        }

        private void cbbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(checkLoad == 0)
            {
                checkLoad = 1;
                return;
            }
            object selectedValue = cbbVersion.SelectedValue;
            if (selectedValue != null && int.TryParse(selectedValue.ToString(), out int selectedAdvisorId))
            {
                if(selectedAdvisorId == 0)
                {
                    load();
                }
                else
                {
                    byte[] noiDungBytes = new database().GetNoiDung_V(selectedAdvisorId);
                    Loadnoidung2(noiDungBytes);
                }
                
            }
            else
            {
                logError.log("Load version Warning (Warning)");
            }
        }

        private void btnXuatF_Click(object sender, EventArgs e)
        {
            SaveToWord();
        }

        private void SaveToWord()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.doc;*.docx";
            openFileDialog.Title = "Chọn tệp Word";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string wordFilePath = openFileDialog.FileName;
                if (Path.GetExtension(wordFilePath).Equals(".doc", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(wordFilePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
                {

                    File.WriteAllBytes(wordFilePath, this.noiDungBytesCrr);

                    MessageBox.Show("Nội dung đã được lưu vào tệp Word thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một tệp Word (.doc hoặc .docx)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
