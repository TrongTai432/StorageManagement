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
    public partial class frmThemMoiPhieuXuat : Form
    {
        private SqlConnection connection;
        public frmThemMoiPhieuXuat()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public string MaPK { get => txtMaPX.Text; set => txtMaPX.Text = value.ToString(); }
        public string NgayXuat
        {
            get => dtpNgayXuat.Value.ToString("yyyy-MM-dd"); // Chuyển đổi DateTime sang string theo định dạng yyyy-MM-dd
            set => dtpNgayXuat.Value = DateTime.Parse(value); // Chuyển đổi string thành DateTime và gán giá trị cho DateTimePicker
        }
        public string TenNguoiNhan { get => txtTenNN.Text; set => txtTenNN.Text = value.ToString(); }
        public string DiaChiNhan { get => txtDCN.Text; set => txtDCN.Text = value.ToString(); }
        public string MaKho { get => txtMaKho.Text; set => txtMaKho.Text = value.ToString(); }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Tạo đối tượng SqlCommand với truy vấn INSERT INTO và kết nối hiện tại
                SqlCommand cmd = new SqlCommand("INSERT INTO PhieuXuat (MaPX, NgayXuat, TenNguoiNhan, DiaChiNhan, MaKho) VALUES (@mapx, @ngayxuat, @tennguoinhan, @diachinhan, @makho)", connection);

                // Thêm các tham số và giá trị tương ứng
                cmd.Parameters.AddWithValue("@mapx", MaPK);
                cmd.Parameters.AddWithValue("@ngayxuat", NgayXuat);
                cmd.Parameters.AddWithValue("@tennguoinhan", TenNguoiNhan);
                cmd.Parameters.AddWithValue("@diachinhan", DiaChiNhan);
                cmd.Parameters.AddWithValue("@makho", MaKho);

                // Thực thi truy vấn INSERT INTO
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm phiếu xuất thành công!");
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

        private void frmThemMoiPhieuXuat_Load(object sender, EventArgs e)
        {

        }
    }
}
