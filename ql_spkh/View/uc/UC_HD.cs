using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;
using ql_spkh.Model;

namespace ql_spkh.View.uc
{
    public partial class UC_HD : UserControl
    {
        public UC_HD(int chon)
        {
            this._index = chon;
            InitializeComponent();
        }
        private int _index = 0;
        private string link1 = "C:\\Users\\Admin\\Desktop\\nckh_sv\\Application\\ql_spkh\\ql_spkh\\Root\\hd_dt.docx";
        private string link2 = "C:\\Users\\Admin\\Desktop\\nckh_sv\\Application\\ql_spkh\\ql_spkh\\Root\\hd_dg.docx";
        private void UC_HD_Load(object sender, EventArgs e)
        {
            if(_index == 0)
            {
                if (!File.Exists(link1))
                {
                    MessageBox.Show("Không tìm thầy dữ liệu hướng dẫn. Nội dung có thể bị thiếu hoặc đã bị xóa: "+ link1, "Lỗi");
                }
                else
                {
                    loadNoidung2(link1);
                }
            }
            else
            {
                if (!File.Exists(link2))
                {
                    MessageBox.Show("Không tìm thầy dữ liệu hướng dẫn. Nội dung có thể bị thiếu hoặc đã bị xóa: " + link2, "Lỗi");
                }
                else
                {
                    loadNoidung2(link2);
                }
            }
        }
        private void rtbShow_TextChanged(object sender, EventArgs e)
        {

        }
        private void loadNoidung2(string link)
        {
            pbLoad.Visible = true;
            if (true)
            {
                object fileName = link;
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
                                            MessageBox.Show("Lỗi tải dữ liệu", "Thông báo");
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

    }
}
