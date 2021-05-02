
namespace WindowsFormsApp1
{
    partial class Kontak
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tambah = new System.Windows.Forms.Label();
            this.dgvkontak = new System.Windows.Forms.DataGridView();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkontak)).BeginInit();
            this.SuspendLayout();
            // 
            // tambah
            // 
            this.tambah.AutoSize = true;
            this.tambah.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tambah.Location = new System.Drawing.Point(1006, 28);
            this.tambah.Name = "tambah";
            this.tambah.Size = new System.Drawing.Size(200, 23);
            this.tambah.TabIndex = 2;
            this.tambah.Text = "Tambahkan Kontak(+)";
            this.tambah.Click += new System.EventHandler(this.tambah_Click);
            // 
            // dgvkontak
            // 
            this.dgvkontak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkontak.Location = new System.Drawing.Point(45, 77);
            this.dgvkontak.Name = "dgvkontak";
            this.dgvkontak.Size = new System.Drawing.Size(1161, 562);
            this.dgvkontak.TabIndex = 1;
            // 
            // searchbox
            // 
            this.searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbox.Location = new System.Drawing.Point(221, 28);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(401, 29);
            this.searchbox.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 44;
            this.label2.Text = "Masukan Nama";
            // 
            // Kontak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.tambah);
            this.Controls.Add(this.dgvkontak);
            this.Name = "Kontak";
            this.Text = "Kontak";
            ((System.ComponentModel.ISupportInitialize)(this.dgvkontak)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tambah;
        private System.Windows.Forms.DataGridView dgvkontak;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Label label2;
    }
}