namespace ServisMobilApp
{
    partial class UC_Kendaraan2
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvKendaraan = new System.Windows.Forms.DataGridView();
            this.txtTahun = new System.Windows.Forms.TextBox();
            this.lblTahun = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblMerek = new System.Windows.Forms.Label();
            this.lblPelanggan = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtMerek = new System.Windows.Forms.TextBox();
            this.cmbPelanggan = new System.Windows.Forms.ComboBox();
            this.lblNoPlat = new System.Windows.Forms.Label();
            this.txtNoPlat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKendaraan)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(653, 536);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 45);
            this.button2.TabIndex = 100;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(131, 536);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 46);
            this.button3.TabIndex = 99;
            this.button3.Text = "Hapus";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lime;
            this.button4.Location = new System.Drawing.Point(409, 536);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 46);
            this.button4.TabIndex = 98;
            this.button4.Text = "Tambah";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // dgvKendaraan
            // 
            this.dgvKendaraan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKendaraan.Location = new System.Drawing.Point(22, 606);
            this.dgvKendaraan.Name = "dgvKendaraan";
            this.dgvKendaraan.RowHeadersWidth = 62;
            this.dgvKendaraan.RowTemplate.Height = 28;
            this.dgvKendaraan.Size = new System.Drawing.Size(898, 293);
            this.dgvKendaraan.TabIndex = 97;
            // 
            // txtTahun
            // 
            this.txtTahun.Location = new System.Drawing.Point(449, 401);
            this.txtTahun.Name = "txtTahun";
            this.txtTahun.Size = new System.Drawing.Size(179, 26);
            this.txtTahun.TabIndex = 96;
            // 
            // lblTahun
            // 
            this.lblTahun.AutoSize = true;
            this.lblTahun.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTahun.Location = new System.Drawing.Point(251, 399);
            this.lblTahun.Name = "lblTahun";
            this.lblTahun.Size = new System.Drawing.Size(76, 26);
            this.lblTahun.TabIndex = 95;
            this.lblTahun.Text = "Tahun";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(251, 330);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(72, 26);
            this.lblModel.TabIndex = 94;
            this.lblModel.Text = "Model";
            // 
            // lblMerek
            // 
            this.lblMerek.AutoSize = true;
            this.lblMerek.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMerek.Location = new System.Drawing.Point(251, 246);
            this.lblMerek.Name = "lblMerek";
            this.lblMerek.Size = new System.Drawing.Size(73, 26);
            this.lblMerek.TabIndex = 93;
            this.lblMerek.Text = "Merek";
            // 
            // lblPelanggan
            // 
            this.lblPelanggan.AutoSize = true;
            this.lblPelanggan.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelanggan.Location = new System.Drawing.Point(251, 162);
            this.lblPelanggan.Name = "lblPelanggan";
            this.lblPelanggan.Size = new System.Drawing.Size(153, 26);
            this.lblPelanggan.TabIndex = 92;
            this.lblPelanggan.Text = "ID_Pelanggan";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(544, 97);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 26);
            this.lblID.TabIndex = 91;
            this.lblID.Click += new System.EventHandler(this.lblID_Click);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(449, 330);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(179, 26);
            this.txtModel.TabIndex = 90;
            // 
            // txtMerek
            // 
            this.txtMerek.Location = new System.Drawing.Point(449, 246);
            this.txtMerek.Name = "txtMerek";
            this.txtMerek.Size = new System.Drawing.Size(179, 26);
            this.txtMerek.TabIndex = 89;
            // 
            // cmbPelanggan
            // 
            this.cmbPelanggan.FormattingEnabled = true;
            this.cmbPelanggan.Location = new System.Drawing.Point(449, 164);
            this.cmbPelanggan.Name = "cmbPelanggan";
            this.cmbPelanggan.Size = new System.Drawing.Size(179, 28);
            this.cmbPelanggan.TabIndex = 102;
            this.cmbPelanggan.Click += new System.EventHandler(this.cmbPelanggan_SelectedIndexChanged);
            // 
            // lblNoPlat
            // 
            this.lblNoPlat.AutoSize = true;
            this.lblNoPlat.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoPlat.Location = new System.Drawing.Point(251, 461);
            this.lblNoPlat.Name = "lblNoPlat";
            this.lblNoPlat.Size = new System.Drawing.Size(86, 26);
            this.lblNoPlat.TabIndex = 103;
            this.lblNoPlat.Text = "No Plat";
            // 
            // txtNoPlat
            // 
            this.txtNoPlat.Location = new System.Drawing.Point(449, 463);
            this.txtNoPlat.Name = "txtNoPlat";
            this.txtNoPlat.Size = new System.Drawing.Size(179, 26);
            this.txtNoPlat.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 26);
            this.label1.TabIndex = 105;
            this.label1.Text = "ID_Kendaraan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 33);
            this.label3.TabIndex = 106;
            this.label3.Text = "KENDARAAN";
            // 
            // UC_Kendaraan2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoPlat);
            this.Controls.Add(this.lblNoPlat);
            this.Controls.Add(this.cmbPelanggan);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgvKendaraan);
            this.Controls.Add(this.txtTahun);
            this.Controls.Add(this.lblTahun);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblMerek);
            this.Controls.Add(this.lblPelanggan);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtMerek);
            this.Name = "UC_Kendaraan2";
            this.Size = new System.Drawing.Size(948, 906);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKendaraan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvKendaraan;
        private System.Windows.Forms.TextBox txtTahun;
        private System.Windows.Forms.Label lblTahun;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblMerek;
        private System.Windows.Forms.Label lblPelanggan;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtMerek;
        private System.Windows.Forms.ComboBox cmbPelanggan;
        private System.Windows.Forms.Label lblNoPlat;
        private System.Windows.Forms.TextBox txtNoPlat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
