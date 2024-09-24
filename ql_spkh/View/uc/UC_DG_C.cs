using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_spkh.Levenshtein;
using ql_spkh.Model;
namespace ql_spkh.View.uc
{
    public partial class UC_DG_C : UserControl
    {
        public UC_DG_C()
        {
            InitializeComponent();
            load();
        }
        private int typeproject = 0;
        private int loadFirst = 0;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void load()
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

        private void cbbLoaiProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loadFirst == 0)
            {
                loadFirst = 1;
                return;
            }
            typeproject = int.Parse(cbbLoaiProject.SelectedValue?.ToString());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(txtTileKey.Text.Trim() ==  "")
            {
                MessageBox.Show("Yêu cầu 1 nội dung để thực hiện đối sánh","Lỗi");
                return;
            }
            new frmCoreTD(txtTileKey.Text.Trim(), typeproject).Show();
        }
    }
}
