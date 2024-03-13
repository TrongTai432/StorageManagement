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
    public partial class frmSuaPhieuNhap : Form
    {
        private SqlConnection connection;
        public frmSuaPhieuNhap()
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
                DialogResult result = MessageBox.Show("Bạn có muốn sửa hay không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                    string query = "UPDATE PhieuNhap SET NgayNhap = @ngaynhap, TenNguoiGiao = @tennguoigiao, MaNCC = @mancc, MaKho = @makho  WHERE MaPN = @mapn ";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@mapn", txtMaPN.Text);
                    cmd.Parameters.AddWithValue("@ngaynhap", dtpNgayNhap.Value);
                    cmd.Parameters.AddWithValue("@tennguoigiao", txtNguoiGiao.Text);
                    cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                    cmd.Parameters.AddWithValue("@makho", txtMaKho.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa phiếu nhập thành công!");
                }
                

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
    }
}
