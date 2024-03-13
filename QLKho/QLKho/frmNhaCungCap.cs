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
    
    public partial class frmNhaCungCap : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlCommand command;
        public frmNhaCungCap()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                connection.Open();

                // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                string query = "SELECT * FROM NhaCungCap";

                // Khởi tạo SqlDataAdapter và DataTable
                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                dataAdapter.Fill(dataTable);

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dgvNhaCungCap.DataSource = dataTable;
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
                DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];
                string mancc = row.Cells["MaNCC"].Value.ToString();
                string tenncc = row.Cells["TenNCC"].Value.ToString();
                string dc = row.Cells["DiaChi"].Value.ToString();
                string sdt = row.Cells["SDT"].Value.ToString();

                // Gán dữ liệu vào các TextBox.
                txtMaNCC.Text = mancc;
                txtTenNCC.Text = tenncc;
                txtDC.Text = dc;
                txtSDT.Text = sdt;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemMoiNhaCC f = new frmThemMoiNhaCC();
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
                    string query = "UPDATE NhaCungCap SET TenNCC = @tenncc,  DiaChi = @diachi, SDT = @sdt  WHERE MaNCC = @mancc ";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                    cmd.Parameters.AddWithValue("@tenncc", txtTenNCC.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDC.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa nhà cung cấp thành công!");
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
            DialogResult result = MessageBox.Show("Bạn có muốn xóa hay không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand(@" delete from NhaCungCap where MaNCC = @mancc
                                                ", connection);
                    command.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                    command.ExecuteNonQuery();
                    connection.Close();

                    LoadData();

                    MessageBox.Show("Xóa nhà cung cấp thành công");
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Tạo truy vấn SELECT để lấy dữ liệu từ bảng
                string query = "SELECT * FROM NhaCungCap WHERE LOWER(MaNCC) like '%' + LOWER(LTRIM(RTRIM(@mancc)))+'%'";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@mancc", txtTuKhoa.Text);

                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvNhaCungCap.DataSource = dt;

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
    }
}
