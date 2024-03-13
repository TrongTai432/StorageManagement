using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKho
{
    public partial class frmThemMoiNhaCC : Form
    {
        private SqlConnection connection;
        public frmThemMoiNhaCC()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public string MaNCC { get => txtMaNCC.Text; set => txtMaNCC.Text = value.ToString(); }
        public string TenNCC { get => txtTenNCC.Text; set => txtTenNCC.Text = value.ToString(); }
        public string DC { get => txtDC.Text; set => txtDC.Text = value.ToString(); }
        public string SDT { get => txtSDT.Text; set => txtSDT.Text = value.ToString(); }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Tạo đối tượng SqlCommand với truy vấn INSERT INTO và kết nối hiện tại
                SqlCommand cmd = new SqlCommand("INSERT INTO NhaCungCap (MaNCC, TenNCC,DiaChi, SDT) VALUES (@mancc, @tenncc,  @diachi, @sdt)", connection);

                // Thêm các tham số và giá trị tương ứng
                cmd.Parameters.AddWithValue("@mancc", MaNCC);
                cmd.Parameters.AddWithValue("@tenncc", TenNCC);
                cmd.Parameters.AddWithValue("@diachi", DC);
                cmd.Parameters.AddWithValue("@sdt", SDT);

                // Thực thi truy vấn INSERT INTO
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm nhà cung cấp thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
