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
    public partial class frmHangHoa : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlCommand command;

        public frmHangHoa()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                connection.Open();

                // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                string query = "SELECT * FROM HangHoa";

                // Khởi tạo SqlDataAdapter và DataTable
                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                dataAdapter.Fill(dataTable);

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dgvHangHoa.DataSource = dataTable;
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

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem sự kiện CellClick xảy ra trên dòng chứa dữ liệu (không phải dòng tiêu đề).
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ DataGridView và đưa nó lên các TextBox.
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];
                string mahh = row.Cells["MaHH"].Value.ToString();
                string tenhh = row.Cells["TenHH"].Value.ToString();
                string dvt = row.Cells["DVT"].Value.ToString();
                string gia = row.Cells["Gia"].Value.ToString();

                // Gán dữ liệu vào các TextBox.
                txtMaHH.Text = mahh;
                txtTenHH.Text = tenhh;
                txtDVT.Text = dvt;
                txtGia.Text = gia;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemMoiHangHoa f = new frmThemMoiHangHoa();
            f.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
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
                    string query = "UPDATE HangHoa SET TenHH = @tenhh,  DVT = @dvt, Gia = @gia  WHERE MaHH = @mahh ";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@mahh", txtMaHH.Text);
                    cmd.Parameters.AddWithValue("@tenhh", txtTenHH.Text);
                    cmd.Parameters.AddWithValue("@dvt", txtDVT.Text);
                    cmd.Parameters.AddWithValue("@gia", txtGia.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa hàng hóa thành công!");
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
                string query = "SELECT * FROM HangHoa WHERE LOWER(MaHH) like '%' + LOWER(LTRIM(RTRIM(@mahh)))+'%'";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@mahh", txtTuKhoa.Text);

                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvHangHoa.DataSource = dt;

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
                DialogResult result = MessageBox.Show("Bạn có muốn xóa hay không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        command = new SqlCommand(@" delete from ChiTietPhieuXuat where MaHH = @mahh
	                                        delete from ChiTietPhieuNhap where MaHH = @mahh
	                                        delete from HangHoa where MaHH = @mahh", connection);
                        command.Parameters.AddWithValue("@mahh", txtMaHH.Text);
                        command.ExecuteNonQuery();
                        connection.Close();

                        LoadData();

                        MessageBox.Show("Xóa hàng hóa thành công");
                    }
                    catch (Exception exeption)
                    {
                        MessageBox.Show(exeption.Message);
                        connection.Close();
                    }
                }
                else
                {

                }

            
            LoadData();
        }
    }
}
