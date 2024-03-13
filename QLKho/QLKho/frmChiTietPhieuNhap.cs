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
    public partial class frmChiTietPhieuNhap : Form
    {
        public frmChiTietPhieuNhap(string mapn, string ngaynhap, string tennguoigiao, string tenncc, string tenkho)
        {
            InitializeComponent();
            txtMaPN.Text = mapn;
            dtpNgayNhap.Value = DateTime.Parse(ngaynhap);
            txtTenNguoiGiao.Text = tennguoigiao;
            txtTenNCC.Text = tenncc;
            txtTenKho.Text = tenkho;
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            string query = "SELECT MaHH, TenHH FROM HangHoa";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string MaHH = reader["MaHH"].ToString();
                    cbMaHH.Items.Add(MaHH);
                }
            }

           cbMaHH.SelectedIndex = 0;
        }
        
        private void LoadData()
        {
            // Kết nối tới cơ sở dữ liệu
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Thực hiện truy vấn SQL để lấy dữ liệu từ cơ sở dữ liệu
                    string query = "select hh.MaHH, hh.TenHH, hh.DVT, hh.Gia, ctpn.SoLuong, SUM(ctpn.SoLuong*hh.Gia)as TongTien from ChiTietPhieuNhap as ctpn join HangHoa as hh on ctpn.MaHH = hh.MaHH join PhieuNhap as pn on ctpn.MaPN = pn.MaPN where ctpn.MaPN = @mapn and ctpn.MaHH = hh.MaHH GROUP BY hh.MaHH, hh.TenHH, hh.DVT, hh.Gia, ctpn.SoLuong ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mapn", txtMaPN.Text);
                        SqlDataReader reader = command.ExecuteReader();

                        // Thêm dữ liệu vào từng cột của DataGridView
                        while (reader.Read())
                        {
                            string mahh = reader["MaHH"].ToString();
                            string tenhh = reader["TenHH"].ToString();
                            string dvt = reader["DVT"].ToString();
                            float gia = Convert.ToSingle(reader["Gia"].ToString());
                            int soluong = Convert.ToInt32(reader["SoLuong"].ToString());
                            float tongtien = Convert.ToSingle(reader["TongTien"].ToString());


                            dgvThongTinMatHang.Rows.Add(mahh, tenhh, dvt, gia, soluong, tongtien);
                        }
                        
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }

        }

        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }
        
        private void dgvThongTinMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem sự kiện CellClick xảy ra trên dòng chứa dữ liệu (không phải dòng tiêu đề).
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ DataGridView và đưa nó lên các TextBox.
                DataGridViewRow row = dgvThongTinMatHang.Rows[e.RowIndex];
                string mahh = row.Cells["MaHH"].Value.ToString();
                string tenhh = row.Cells["TenHH"].Value.ToString();
                string dvt = row.Cells["DVT"].Value.ToString();
                String gia = row.Cells["Gia"].Value.ToString();
                string soluong = row.Cells["SoLuong"].Value.ToString();
                // Gán dữ liệu vào các TextBox.
                cbMaHH.Text = mahh;
                txtTenHH.Text = tenhh;
                txtDVT.Text = dvt;
                txtGia.Text = gia;
                txtSoLuong.Text = soluong;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox và ComboBox
            string mapn = txtMaPN.Text;

            string mahh = cbMaHH.Text;
            //string tenhh = txtTenHH.Text;
            //string dvt = txtDVT.Text;
            //float gia = float.Parse(txtGia.Text);
            int soluong = int.Parse(txtSoLuong.Text);

            // Kết nối tới cơ sở dữ liệu
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Kiểm tra xem hàng hóa đã tồn tại trong phiếu nhập kho hay chưa
                string checkQuery = "SELECT COUNT(*) FROM ChiTietPhieuNhap WHERE MaHH = @MaHH and MaPN = @mapn";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MaHH", mahh);
                    checkCommand.Parameters.AddWithValue("@mapn", mapn);

                    int rowCount = (int)checkCommand.ExecuteScalar();

                    if (rowCount > 0)
                    {
                        // Nếu hàng hóa đã tồn tại, tăng số lượng hàng hóa lên và cập nhật vào cơ sở dữ liệu
                        string updateQuery = "UPDATE ChiTietPhieuNhap SET SoLuong = SoLuong + @SoLuong WHERE MaHH = @MaHH";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@MaHH", mahh);
                            updateCommand.Parameters.AddWithValue("@SoLuong", soluong);


                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật số lượng hàng hóa thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Không thể cập nhật số lượng hàng hóa. Vui lòng kiểm tra lại.");
                            }
                        }
                    }
                    else
                    {
                        // Nếu hàng hóa chưa tồn tại, thêm một hàng mới vào phiếu nhập kho
                        string insertQuery = "INSERT INTO ChiTietPhieuNhap (MaPN, MaHH, SoLuong) VALUES (@mapn, @mahh, @soluong)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@mahh", mahh);
                            insertCommand.Parameters.AddWithValue("@soluong", soluong);
                            insertCommand.Parameters.AddWithValue("@mapn", mapn);

                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm hàng hóa thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Không thể thêm hàng hóa. Vui lòng kiểm tra lại.");
                            }
                        }
                    }
                }
            }
            dgvThongTinMatHang.Rows.Clear();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox và ComboBox
            string mapn = txtMaPN.Text;

            string mahh = cbMaHH.Text;
            //string tenhh = txtTenHH.Text;
            //string dvt = txtDVT.Text;
            //float gia = float.Parse(txtGia.Text);
            int soluong = int.Parse(txtSoLuong.Text);

            // Kết nối tới cơ sở dữ liệu
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    // Kiểm tra điều kiện số lượng nhập của hàng hóa trước khi xóa
                    string checkQuery = "SELECT SoLuong FROM ChiTietPhieuNhap WHERE MaPN = @mapn AND MaHH = @mahh";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@mapn", mapn);
                        checkCommand.Parameters.AddWithValue("@mahh", mahh);

                        int soLuongNhapHienTai = (int)checkCommand.ExecuteScalar();

                        if (soLuongNhapHienTai <= soluong)
                        {
                            // Thực hiện truy vấn SQL để xóa hàng hóa khỏi phiếu nhập
                            string deleteQuery = "DELETE FROM ChiTietPhieuNhap WHERE MaPN = @mapn AND MaHH = @mahh";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@mapn", mapn);
                                deleteCommand.Parameters.AddWithValue("@mahh", mahh);

                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Xóa hàng hóa khỏi phiếu nhập thành công!");
                                }
                                else
                                {
                                    MessageBox.Show("Không thể xóa hàng hóa khỏi phiếu nhập. Vui lòng kiểm tra lại mã hàng hóa và mã phiếu nhập.");
                                }
                            }
                        }
                        else
                        {
                            string updateQuery = "UPDATE ChiTietPhieuNhap SET SoLuong = SoLuong - @SoLuong WHERE MaHH = @MaHH";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@MaHH", mahh);
                                updateCommand.Parameters.AddWithValue("@SoLuong", soluong);


                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cập nhật số lượng hàng hóa thành công!");
                                }
                                else
                                {
                                    MessageBox.Show("Không thể cập nhật số lượng hàng hóa. Vui lòng kiểm tra lại.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hàng hóa khỏi phiếu nhập: " + ex.Message);
                }
                finally
                {
                    dgvThongTinMatHang.Rows.Clear();
                    LoadData();
                }
            }
        }

        private void btnThanhTien_Click(object sender, EventArgs e)
        {
            // Tạo biến để lưu tổng tiền
            float tongTien = 0;

            // Duyệt qua từng hàng trong DataGridView
            foreach (DataGridViewRow row in dgvThongTinMatHang.Rows)
            {
                // Kiểm tra nếu dòng không phải là dòng Header hoặc dòng trống
                if (!row.IsNewRow)
                {
                    // Lấy giá trị từ cột tổng tiền (giả sử cột có chỉ số là 3)
                    float giaTriTongTien = float.Parse(row.Cells["TongTien"].Value.ToString());
                    // Cộng giá trị tổng tiền từ từng hàng vào biến tongTien
                    tongTien += giaTriTongTien;
                }
            }

            // Hiển thị tổng tiền lên TextBox
            txtThanhTien.Text = tongTien.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvThongTinMatHang_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Lấy số thứ tự hiện tại của hàng
            string rowIndex = (e.RowIndex + 1).ToString();

            // Tạo một font và màu sắc cho số thứ tự
            Font font = this.dgvThongTinMatHang.Font;
            Brush brush = SystemBrushes.ControlText;

            // Xác định vị trí vẽ số thứ tự bên trái của hàng
            int x = e.RowBounds.Left + 4;
            int y = e.RowBounds.Top + ((e.RowBounds.Height - font.Height) / 2);

            // Vẽ số thứ tự vào DataGridView
            e.Graphics.DrawString(rowIndex, font, brush, x, y);
        }

        private void cbMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectMaHH = cbMaHH.SelectedItem.ToString();
            string connectionString = @"Data Source=DELLW10;Initial Catalog=QLKho;Integrated Security=True";
            string query = "SELECT TenHH, DVT, Gia FROM HangHoa WHERE MaHH = @MaHH";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHH", SelectMaHH);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtTenHH.Text = reader["TenHH"].ToString();
                    txtDVT.Text = reader["DVT"].ToString();
                    txtGia.Text = reader["Gia"].ToString();
                }
                else
                {
                    txtTenHH.Text = "(Không tìm thấy)";
                    txtDVT.Text = "";
                    txtGia.Text = "";
                }

            }

        }
    }
}
