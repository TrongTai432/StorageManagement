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
    public partial class frmThemMoiPhieuNhap : Form
    {
        private SqlConnection connection;
        public frmThemMoiPhieuNhap()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            connection = new SqlConnection(connectionString);

        }
        public string MaPN { get => txtMaPN.Text; set => txtMaPN.Text = value.ToString(); }
        public string NgayNhap
        {
            get => dtpNgayNhap.Value.ToString("yyyy-MM-dd"); // Chuyển đổi DateTime sang string theo định dạng yyyy-MM-dd
            set => dtpNgayNhap.Value = DateTime.Parse(value); // Chuyển đổi string thành DateTime và gán giá trị cho DateTimePicker
        }
        public string TenNguoiGiao { get => txtNguoiGiao.Text; set => txtNguoiGiao.Text = value.ToString(); }
        public string MaNCC { get => txtMaNCC.Text; set => txtMaNCC.Text = value.ToString(); }
        public string MaKho { get => txtMaKho.Text; set => txtMaKho.Text = value.ToString(); }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Tạo đối tượng SqlCommand với truy vấn INSERT INTO và kết nối hiện tại
                SqlCommand cmd = new SqlCommand("INSERT INTO PhieuNhap (MaPN, NgayNhap, TenNguoiGiao, MaNCC, MaKho) VALUES (@mapn, @ngaynhap, @tennguoigiao, @mancc, @makho)", connection);

                // Thêm các tham số và giá trị tương ứng
                cmd.Parameters.AddWithValue("@mapn", MaPN);
                cmd.Parameters.AddWithValue("@ngaynhap", NgayNhap);
                cmd.Parameters.AddWithValue("@tennguoigiao", TenNguoiGiao);
                cmd.Parameters.AddWithValue("@mancc", MaNCC);
                cmd.Parameters.AddWithValue("@makho", MaKho);

                // Thực thi truy vấn INSERT INTO
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm phiếu nhập thành công!");
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
