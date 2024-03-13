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
    public partial class frmPhieuNhap : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public frmPhieuNhap()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

 

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                connection.Open();

                // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                string query = "SELECT pn.MaPN, pn.NgayNhap, pn.TenNguoiGiao, ncc.TenNCC, k.TenKho FROM PhieuNhap as pn join NhaCungCap as ncc on pn.MaNCC = ncc.MaNCC join Kho as k on pn.MaKho = k.MaKho";

                // Khởi tạo SqlDataAdapter và DataTable
                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                dataAdapter.Fill(dataTable);

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dgvNhapHang.DataSource = dataTable;
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

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemMoiPhieuNhap f = new frmThemMoiPhieuNhap();
            f.Show();
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmSuaPhieuNhap f = new frmSuaPhieuNhap();
            f.Show();
            
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
                    string query = "DELETE FROM PhieuNhap WHERE MaPN = @mapn ";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@mapn", txtMaPN.Text);



                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa phiếu nhập thành công!");
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

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem sự kiện CellClick xảy ra trên dòng chứa dữ liệu (không phải dòng tiêu đề).
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ DataGridView và đưa nó lên các TextBox.
                DataGridViewRow row = dgvNhapHang.Rows[e.RowIndex];
                string mapn = row.Cells["MaPN"].Value.ToString();
                string ngaynhap = row.Cells["NgayNhap"].Value.ToString();
                string tennguoigiao = row.Cells["TenNguoiGiao"].Value.ToString();
                string tenncc = row.Cells["TenNCC"].Value.ToString();
                string tenkho = row.Cells["TenKho"].Value.ToString();
                // Gán dữ liệu vào các TextBox.
                txtMaPN.Text = mapn;
                dtpNgayNhap.Text = ngaynhap;
                txtNguoiGiao.Text = tennguoigiao;
                txtMaNCC.Text = tenncc;
                txtMaKho.Text = tenkho;

            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                string query = "SELECT * FROM PhieuNhap WHERE LOWER(MaPN) like '%' + LOWER(LTRIM(RTRIM(@mapn)))+'%'";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@mapn", txtTuKhoa.Text);

                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvNhapHang.DataSource = dt;

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

        private void dgvNhapHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ DataGridView và đưa nó lên các TextBox.
                DataGridViewRow row = dgvNhapHang.Rows[e.RowIndex];
                string mapn = row.Cells["MaPN"].Value.ToString();
                string ngaynhap = row.Cells["NgayNhap"].Value.ToString();
                string tennguoigiao = row.Cells["TenNguoiGiao"].Value.ToString();
                string tenncc = row.Cells["TenNCC"].Value.ToString();
                string tenkho = row.Cells["TenKho"].Value.ToString();

                frmChiTietPhieuNhap f = new frmChiTietPhieuNhap(mapn, ngaynhap, tennguoigiao, tenncc, tenkho);
                f.Show();
            }
        }
    }
}
