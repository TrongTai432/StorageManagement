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
    public partial class frmThemMoiHangHoa : Form
    {
        private SqlConnection connection;
        public frmThemMoiHangHoa()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public string MaHH { get => txtMaHH.Text; set => txtMaHH.Text = value.ToString(); }
        public string TenHH { get => txtTenHH.Text; set => txtTenHH.Text = value.ToString(); }
        public string DVT { get => txtDVT.Text; set => txtDVT.Text = value.ToString(); }
        public string Gia { get => txtGia.Text; set => txtGia.Text = value.ToString(); }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Tạo đối tượng SqlCommand với truy vấn INSERT INTO và kết nối hiện tại
                SqlCommand cmd = new SqlCommand("INSERT INTO HangHoa (MaHH, TenHH, DVT, Gia) VALUES (@mahh, @tenhh,  @dvt, @gia)", connection);

                // Thêm các tham số và giá trị tương ứng
                cmd.Parameters.AddWithValue("@mahh", MaHH);
                cmd.Parameters.AddWithValue("@tenhh", TenHH);
                cmd.Parameters.AddWithValue("@dvt", DVT);
                cmd.Parameters.AddWithValue("@gia", Gia);

                // Thực thi truy vấn INSERT INTO
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm hàng hóa thành công!");
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
