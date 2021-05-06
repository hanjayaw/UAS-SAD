
namespace WindowsFormsApp1
{
    partial class ReportPenjualan
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
            this.btnBack = new System.Windows.Forms.Button();
            this.lreport = new System.Windows.Forms.Label();
            this.dgPenjualan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgPenjualan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBack.Location = new System.Drawing.Point(1115, 47);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // lreport
            // 
            this.lreport.AutoSize = true;
            this.lreport.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lreport.Location = new System.Drawing.Point(437, 90);
            this.lreport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lreport.Name = "lreport";
            this.lreport.Size = new System.Drawing.Size(359, 45);
            this.lreport.TabIndex = 4;
            this.lreport.Text = "REPORT PENJUALAN";
            // 
            // dgPenjualan
            // 
            this.dgPenjualan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPenjualan.Location = new System.Drawing.Point(33, 184);
            this.dgPenjualan.Name = "dgPenjualan";
            this.dgPenjualan.RowHeadersWidth = 51;
            this.dgPenjualan.Size = new System.Drawing.Size(1200, 470);
            this.dgPenjualan.TabIndex = 5;
            // 
            // ReportPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dgPenjualan);
            this.Controls.Add(this.lreport);
            this.Controls.Add(this.btnBack);
            this.Name = "ReportPenjualan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Repor Penjualan";
            this.Load += new System.EventHandler(this.ReportPenjualan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPenjualan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lreport;
        private System.Windows.Forms.DataGridView dgPenjualan;
    }
}