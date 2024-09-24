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
namespace ql_spkh
{
    public partial class frmChonDT : Form
    {
        public frmChonDT(int p)
        {
            InitializeComponent();
            this.projectCurr = p;
        }
        private int projectCurr;
        private int checkLoad = 0;
        public byte[] noiDungBytesCrr = null;
        public string contentCrr = "";
        private bool checkLoadC = false;
        public event EventHandler<DataReadyEventArgs> DataReady;
        private void frmChonDT_Load(object sender, EventArgs e)
        {
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
                this.contentCrr = rtbShow.Text;
            }
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
        private void Loadnoidung2(byte[] noiDungBytes)
        {
            this.noiDungBytesCrr = noiDungBytes;
            pbLoad.Visible = true;

            
            Task.Factory.StartNew(() =>
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
                                    content = dataObject.GetData(DataFormats.Rtf).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Clipboard không chứa dữ liệu định dạng RTF", "Thông báo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Clipboard không chứa dữ liệu", "Thông báo");
                            }

                        });
                       
                        doc.Close();
                        app.Quit();
                    }
                    this.Invoke((MethodInvoker)delegate
                    { 
                        rtbShow.Rtf = content;
                        this.contentCrr = rtbShow.Text;
                        this.checkLoadC = true;
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
                    this.Invoke((MethodInvoker)delegate
                    {
                        pbLoad.Visible = false;
                    });
                }
            });
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(this.checkLoadC)
            {
                DataReady?.Invoke(this, new DataReadyEventArgs(txtTieuDe.Text, this.contentCrr));
                this.Close();
            }
            else
            {
                MessageBox.Show("Quá trình tải nội dung chưa hoàn tất", "Lỗi");
            }
        }
        private void cbbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkLoad == 0)
            {
                checkLoad = 1;
                return;
            }
            object selectedValue = cbbVersion.SelectedValue;
            if (selectedValue != null && int.TryParse(selectedValue.ToString(), out int selectedAdvisorId))
            {
                if (selectedAdvisorId == 0)
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
    }
    public class DataReadyEventArgs : EventArgs
    {
        public string Data { get; private set; }
        public string title { get; private set; }
        public DataReadyEventArgs(string title,string data)
        {
            this.title = title;
            Data = data;
        }
    }
}
