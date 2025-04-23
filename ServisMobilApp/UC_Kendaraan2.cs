using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ServisMobilApp
{
    public partial class UC_Kendaraan2 : UserControl
    {
        private string connectionString = "Data Source=LAPTOP-N8SLA3LN\\IRFANFAUZI;Initial Catalog=ServisMobil;Integrated Security=True";

        public UC_Kendaraan2()
        {
            InitializeComponent();
            LoadPelanggan();
            LoadKendaraan();
            dgvKendaraan.CellClick += dgvKendaraan_CellClick;
        }

        private void LoadPelanggan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID_Pelanggan, Nama FROM Pelanggan";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbPelanggan.DataSource = dt;
                    cmbPelanggan.DisplayMember = "Nama";
                    cmbPelanggan.ValueMember = "ID_Pelanggan";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat pelanggan: " + ex.Message);
                }
            }
        }

        private void LoadKendaraan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT k.ID_Kendaraan, k.Merek, k.Model, k.Tahun, k.NomorPlat,
                                            p.Nama AS NamaPelanggan
                                     FROM Kendaraan k
                                     JOIN Pelanggan p ON k.ID_Pelanggan = p.ID_Pelanggan";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKendaraan.DataSource = dt;
                    KosongkanForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat kendaraan: " + ex.Message);
                }
            }
        }

        private void KosongkanForm()
        {
            lblID.Text = "";
            txtMerek.Clear();
            txtModel.Clear();
            txtTahun.Clear();
            txtNoPlat.Clear();
            txtMerek.Focus();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            int selectedPelangganID = Convert.ToInt32(cmbPelanggan.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Kendaraan (ID_Pelanggan, Merek, Model, Tahun, NomorPlat)
                                     VALUES (@ID_Pelanggan, @Merek, @Model, @Tahun, @NomorPlat)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_Pelanggan", selectedPelangganID);
                    cmd.Parameters.AddWithValue("@Merek", txtMerek.Text.Trim());
                    cmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                    cmd.Parameters.AddWithValue("@Tahun", txtTahun.Text.Trim());
                    cmd.Parameters.AddWithValue("@NomorPlat", txtNoPlat.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kendaraan berhasil ditambahkan!");
                    LoadKendaraan();
                }
                catch (SqlException ex)
                {
                    TampilkanPesanKesalahan(ex);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Pilih kendaraan yang ingin diubah!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Kendaraan
                                     SET Merek = @Merek, Model = @Model, Tahun = @Tahun, NomorPlat = @NomorPlat
                                     WHERE ID_Kendaraan = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@Merek", txtMerek.Text.Trim());
                    cmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                    cmd.Parameters.AddWithValue("@Tahun", txtTahun.Text.Trim());
                    cmd.Parameters.AddWithValue("@NomorPlat", txtNoPlat.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kendaraan berhasil diubah!");
                    LoadKendaraan();
                }
                catch (SqlException ex)
                {
                    TampilkanPesanKesalahan(ex);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Pilih kendaraan yang ingin dihapus!");
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus kendaraan ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Kendaraan WHERE ID_Kendaraan = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kendaraan berhasil dihapus!");
                        LoadKendaraan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus kendaraan: " + ex.Message);
                    }
                }
            }
        }

        private void dgvKendaraan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKendaraan.Rows[e.RowIndex].Cells.Count >= 6)
            {
                DataGridViewRow row = dgvKendaraan.Rows[e.RowIndex];
                lblID.Text = row.Cells["ID_Kendaraan"].Value?.ToString() ?? "";
                txtMerek.Text = row.Cells["Merek"].Value?.ToString() ?? "";
                txtModel.Text = row.Cells["Model"].Value?.ToString() ?? "";
                txtTahun.Text = row.Cells["Tahun"].Value?.ToString() ?? "";
                txtNoPlat.Text = row.Cells["NomorPlat"].Value?.ToString() ?? "";
            }
        }

        private void cmbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tidak perlu filter berdasarkan pelanggan, semua kendaraan ditampilkan
        }

        private void TampilkanPesanKesalahan(SqlException ex)
        {
            if (ex.Message.Contains("CK__Kendaraan")) // CHECK constraint Tahun
            {
                MessageBox.Show("Tahun kendaraan harus antara 2000 dan tahun sekarang.", "Validasi Tahun", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ex.Message.Contains("UNIQUE") && ex.Message.Contains("NomorPlat"))
            {
                MessageBox.Show("Nomor plat kendaraan sudah digunakan oleh kendaraan lain.", "Validasi Nomor Plat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ex.Message.Contains("Cannot insert the value NULL"))
            {
                MessageBox.Show("Semua field harus diisi. Pastikan tidak ada kolom yang kosong.", "Validasi Data Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ex.Message.Contains("FK__Kendaraan")) // Foreign Key gagal
            {
                MessageBox.Show("Pelanggan yang dipilih tidak valid.", "Validasi Pelanggan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Kesalahan SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }
    }
}
