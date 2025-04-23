using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ServisMobilApp
{
    public partial class UC_Pelanggan1 : UserControl
    {
        private string connectionString = "Data Source=LAPTOP-N8SLA3LN\\IRFANFAUZI;Initial Catalog=ServisMobil;Integrated Security=True";

        public UC_Pelanggan1()
        {
            InitializeComponent();
            LoadPelanggan();
        }

        private void LoadPelanggan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID_Pelanggan, Nama, Telepon, Alamat, Email FROM Pelanggan";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }

        private bool ValidasiInput()
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtNoTelp.Text) ||
                string.IsNullOrWhiteSpace(txtAlamat.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Semua data wajib diisi!");
                return false;
            }
            return true;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Pelanggan (Nama, Telepon, Alamat, Email)
                                     VALUES (@Nama, @Telepon, @Alamat, @Email)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telepon", txtNoTelp.Text.Trim());
                    cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pelanggan berhasil ditambahkan!");
                        LoadPelanggan();
                        KosongkanForm();
                    }
                    else
                    {
                        MessageBox.Show("Query dijalankan, tapi tidak ada data yang masuk.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambah: " + ex.Message);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Pilih data yang ingin diubah!");
                return;
            }

            if (!ValidasiInput()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Pelanggan
                                     SET Nama = @Nama, Telepon = @Telepon, Alamat = @Alamat, Email = @Email
                                     WHERE ID_Pelanggan = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telepon", txtNoTelp.Text.Trim());
                    cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pelanggan berhasil diubah!");
                        LoadPelanggan();
                        KosongkanForm();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan atau tidak ada perubahan.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengubah: " + ex.Message);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Pelanggan WHERE ID_Pelanggan = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Pelanggan berhasil dihapus!");
                            LoadPelanggan();
                            KosongkanForm();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus: " + ex.Message);
                    }
                }
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                lblID.Text = row.Cells["ID_Pelanggan"].Value?.ToString() ?? "";
                txtNama.Text = row.Cells["Nama"].Value?.ToString() ?? "";
                txtNoTelp.Text = row.Cells["Telepon"].Value?.ToString() ?? "";
                txtAlamat.Text = row.Cells["Alamat"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            }
        }

        private void KosongkanForm()
        {
            lblID.Text = "";
            txtNama.Clear();
            txtNoTelp.Clear();
            txtAlamat.Clear();
            txtEmail.Clear();
        }
    }
}
