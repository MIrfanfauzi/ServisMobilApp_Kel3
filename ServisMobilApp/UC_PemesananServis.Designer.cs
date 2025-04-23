namespace ServisMobilApp
{
    partial class UC_PemesananServis
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTanggalServis = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMekanik = new System.Windows.Forms.Label();
            this.lblPelanggan = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblLayanan = new System.Windows.Forms.Label();
            this.lblKendaraan = new System.Windows.Forms.Label();
            this.dgvPemesanan = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.cmbPelanggan = new System.Windows.Forms.ComboBox();
            this.cmbKendaraan = new System.Windows.Forms.ComboBox();
            this.cmbLayanan = new System.Windows.Forms.ComboBox();
            this.cmbMekanik = new System.Windows.Forms.ComboBox();
            this.dtpTanggalServis = new System.Windows.Forms.DateTimePicker();
            this.dtpTanggalPesan = new System.Windows.Forms.DateTimePicker();
            this.labelStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemesanan)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTanggalServis
            // 
            this.labelTanggalServis.AutoSize = true;
            this.labelTanggalServis.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTanggalServis.Location = new System.Drawing.Point(196, 423);
            this.labelTanggalServis.Name = "labelTanggalServis";
            this.labelTanggalServis.Size = new System.Drawing.Size(164, 26);
            this.labelTanggalServis.TabIndex = 31;
            this.labelTanggalServis.Text = "Tanggal Servis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(191, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 26);
            this.label4.TabIndex = 30;
            this.label4.Text = "Tanggal Pesan";
            // 
            // lblMekanik
            // 
            this.lblMekanik.AutoSize = true;
            this.lblMekanik.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMekanik.Location = new System.Drawing.Point(196, 305);
            this.lblMekanik.Name = "lblMekanik";
            this.lblMekanik.Size = new System.Drawing.Size(128, 26);
            this.lblMekanik.TabIndex = 29;
            this.lblMekanik.Text = "ID_Mekanik";
            // 
            // lblPelanggan
            // 
            this.lblPelanggan.AutoSize = true;
            this.lblPelanggan.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelanggan.Location = new System.Drawing.Point(193, 145);
            this.lblPelanggan.Name = "lblPelanggan";
            this.lblPelanggan.Size = new System.Drawing.Size(153, 26);
            this.lblPelanggan.TabIndex = 28;
            this.lblPelanggan.Text = "ID_Pelanggan";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(538, 100);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 26);
            this.lblID.TabIndex = 27;
            // 
            // lblLayanan
            // 
            this.lblLayanan.AutoSize = true;
            this.lblLayanan.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayanan.Location = new System.Drawing.Point(191, 247);
            this.lblLayanan.Name = "lblLayanan";
            this.lblLayanan.Size = new System.Drawing.Size(131, 26);
            this.lblLayanan.TabIndex = 38;
            this.lblLayanan.Text = "ID_Layanan";
            // 
            // lblKendaraan
            // 
            this.lblKendaraan.AutoSize = true;
            this.lblKendaraan.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKendaraan.Location = new System.Drawing.Point(198, 196);
            this.lblKendaraan.Name = "lblKendaraan";
            this.lblKendaraan.Size = new System.Drawing.Size(156, 26);
            this.lblKendaraan.TabIndex = 37;
            this.lblKendaraan.Text = "ID_Kendaraan";
            // 
            // dgvPemesanan
            // 
            this.dgvPemesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPemesanan.Location = new System.Drawing.Point(24, 626);
            this.dgvPemesanan.Name = "dgvPemesanan";
            this.dgvPemesanan.RowHeadersWidth = 62;
            this.dgvPemesanan.RowTemplate.Height = 28;
            this.dgvPemesanan.Size = new System.Drawing.Size(899, 278);
            this.dgvPemesanan.TabIndex = 51;
            this.dgvPemesanan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPemesanan_CellClick);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(714, 558);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(109, 46);
            this.btnEdit.TabIndex = 58;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Red;
            this.btnHapus.Location = new System.Drawing.Point(117, 556);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(122, 44);
            this.btnHapus.TabIndex = 57;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.Lime;
            this.btnTambah.Location = new System.Drawing.Point(400, 556);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(138, 46);
            this.btnTambah.TabIndex = 56;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // cmbPelanggan
            // 
            this.cmbPelanggan.FormattingEnabled = true;
            this.cmbPelanggan.Location = new System.Drawing.Point(444, 147);
            this.cmbPelanggan.Name = "cmbPelanggan";
            this.cmbPelanggan.Size = new System.Drawing.Size(189, 28);
            this.cmbPelanggan.TabIndex = 60;
            this.cmbPelanggan.Click += new System.EventHandler(this.cmbPelanggan_SelectedIndexChanged);
            // 
            // cmbKendaraan
            // 
            this.cmbKendaraan.FormattingEnabled = true;
            this.cmbKendaraan.Location = new System.Drawing.Point(444, 194);
            this.cmbKendaraan.Name = "cmbKendaraan";
            this.cmbKendaraan.Size = new System.Drawing.Size(189, 28);
            this.cmbKendaraan.TabIndex = 61;
            // 
            // cmbLayanan
            // 
            this.cmbLayanan.FormattingEnabled = true;
            this.cmbLayanan.Location = new System.Drawing.Point(444, 249);
            this.cmbLayanan.Name = "cmbLayanan";
            this.cmbLayanan.Size = new System.Drawing.Size(189, 28);
            this.cmbLayanan.TabIndex = 62;
            // 
            // cmbMekanik
            // 
            this.cmbMekanik.FormattingEnabled = true;
            this.cmbMekanik.Location = new System.Drawing.Point(444, 303);
            this.cmbMekanik.Name = "cmbMekanik";
            this.cmbMekanik.Size = new System.Drawing.Size(180, 28);
            this.cmbMekanik.TabIndex = 63;
            // 
            // dtpTanggalServis
            // 
            this.dtpTanggalServis.Location = new System.Drawing.Point(444, 423);
            this.dtpTanggalServis.Name = "dtpTanggalServis";
            this.dtpTanggalServis.Size = new System.Drawing.Size(285, 26);
            this.dtpTanggalServis.TabIndex = 64;
            // 
            // dtpTanggalPesan
            // 
            this.dtpTanggalPesan.Location = new System.Drawing.Point(444, 364);
            this.dtpTanggalPesan.Name = "dtpTanggalPesan";
            this.dtpTanggalPesan.Size = new System.Drawing.Size(285, 26);
            this.dtpTanggalPesan.TabIndex = 65;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(205, 481);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(78, 26);
            this.labelStatus.TabIndex = 66;
            this.labelStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(444, 479);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 28);
            this.cmbStatus.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 26);
            this.label1.TabIndex = 68;
            this.label1.Text = "ID_Pemesanan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 33);
            this.label3.TabIndex = 69;
            this.label3.Text = "PEMESANAN SERVIS";
            // 
            // UC_PemesananServis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.dtpTanggalPesan);
            this.Controls.Add(this.dtpTanggalServis);
            this.Controls.Add(this.cmbMekanik);
            this.Controls.Add(this.cmbLayanan);
            this.Controls.Add(this.cmbKendaraan);
            this.Controls.Add(this.cmbPelanggan);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.dgvPemesanan);
            this.Controls.Add(this.lblLayanan);
            this.Controls.Add(this.lblKendaraan);
            this.Controls.Add(this.labelTanggalServis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMekanik);
            this.Controls.Add(this.lblPelanggan);
            this.Controls.Add(this.lblID);
            this.Name = "UC_PemesananServis";
            this.Size = new System.Drawing.Size(950, 930);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemesanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTanggalServis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMekanik;
        private System.Windows.Forms.Label lblPelanggan;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblLayanan;
        private System.Windows.Forms.Label lblKendaraan;
        private System.Windows.Forms.DataGridView dgvPemesanan;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.ComboBox cmbPelanggan;
        private System.Windows.Forms.ComboBox cmbKendaraan;
        private System.Windows.Forms.ComboBox cmbLayanan;
        private System.Windows.Forms.ComboBox cmbMekanik;
        private System.Windows.Forms.DateTimePicker dtpTanggalServis;
        private System.Windows.Forms.DateTimePicker dtpTanggalPesan;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
