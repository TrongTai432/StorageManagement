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
    public partial class frmPhieuXuat : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public frmPhieuXuat()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                connection.Open();

                // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                string query = "SELECT * FROM PhieuXuat";

                // Khởi tạo SqlDataAdapter và DataTable
                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                dataAdapter.Fill(dataTable);

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dgvXuatHang.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dgvXuatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem sự kiện CellClick xảy ra trên dòng chứa dữ liệu (không phải dòng tiêu đề).
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ DataGridView và đưa nó lên các TextBox.
                DataGridViewRow row = dgvXuatHang.Rows[e.RowIndex];
                string mapx = row.Cells["MaPX"].Value.ToString();
                string ngayxuat = row.Cells["NgayXuat"].Value.ToString();
                string tnn = row.Cells["TenNguoiNhan"].Value.ToString();
                string dcn = row.Cells["DiaChiNhan"].Value.ToString();
                string makho = row.Cells["MaKho"].Value.ToString();
                // Gán dữ liệu vào các TextBox.
                txtMaPX.Text = mapx;
                dtpNgayXuat.Text = ngayxuat;
                txtTenNN.Text = tnn;
                txtDCN.Text = dcn;
                txtMaKho.Text = makho;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemMoiPhieuXuat f = new frmThemMoiPhieuXuat();
            f.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                DialogResult result = MessageBox.Show("Bạn có muốn sửa hay không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                    string query = "UPDATE PhieuXuat SET NgayXuat = @ngayxuat, TenNguoiNhan = @tnn, DiaChiNhan = @dcn, MaKho = @makho  WHERE MaPX = @mapx ";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@mapx", txtMaPX.Text);
                    cmd.Parameters.AddWithValue("@ngayxuat", dtpNgayXuat.Value);
                    cmd.Parameters.AddWithValue("@tnn", txtTenNN.Text);
                    cmd.Parameters.AddWithValue("@dcn", txtDCN.Text);
                    cmd.Parameters.AddWithValue("@makho", txtMaKho.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa phiếu xuất thành công!");
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
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa hay không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                    string query = "DELETE FROM PhieuXuat WHERE MaPX = @mapx ";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@mapx", txtMaPX.Text);



                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa phiếu xuất thành công!");
                }
                else
                {

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
            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                string query = "SELECT * FROM PhieuXuat WHERE LOWER(MaPX) like '%' + LOWER(LTRIM(RTRIM(@mapx)))+'%'";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@mapx", txtTuKhoa.Text);

                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvXuatHang.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dgvXuatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ DataGridView và đưa nó lên các TextBox.
                DataGridViewRow row = dgvXuatHang.Rows[e.RowIndex];
                string mapx = row.Cells["MaPX"].Value.ToString();
                string ngayxuat = row.Cells["NgayXuat"].Value.ToString();
                string tnn = row.Cells["TenNguoiNhan"].Value.ToString();
                string dcn = row.Cells["DiaChiNhan"].Value.ToString();
                string makho = row.Cells["MaKho"].Value.ToString();

                frmChiTietPhieuXuat f = new frmChiTietPhieuXuat(mapx, ngayxuat, tnn, dcn, makho);
                f.Show();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
