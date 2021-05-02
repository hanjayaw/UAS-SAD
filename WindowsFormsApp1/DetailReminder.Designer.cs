
namespace WindowsFormsApp1
{
    partial class DetailReminder
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
            this.dgvdetail = new System.Windows.Forms.DataGridView();
            this.tbid = new System.Windows.Forms.TextBox();
            this.lebeldetail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvdetail
            // 
            this.dgvdetail.AllowUserToAddRows = false;
            this.dgvdetail.AllowUserToDeleteRows = false;
            this.dgvdetail.AllowUserToResizeColumns = false;
            this.dgvdetail.AllowUserToResizeRows = false;
            this.dgvdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvdetail.Location = new System.Drawing.Point(12, 48);
            this.dgvdetail.Name = "dgvdetail";
            this.dgvdetail.Size = new System.Drawing.Size(680, 381);
            this.dgvdetail.TabIndex = 0;
            // 
            // tbid
            // 
            this.tbid.Location = new System.Drawing.Point(12, 12);
            this.tbid.Name = "tbid";
            this.tbid.Size = new System.Drawing.Size(50, 20);
            this.tbid.TabIndex = 1;
            this.tbid.Visible = false;
            // 
            // lebeldetail
            // 
            this.lebeldetail.AutoSize = true;
            this.lebeldetail.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.lebeldetail.Location = new System.Drawing.Point(209, 12);
            this.lebeldetail.Name = "lebeldetail";
            this.lebeldetail.Size = new System.Drawing.Size(41, 23);
            this.lebeldetail.TabIndex = 2;
            this.lebeldetail.Text = "text";
            // 
            // DetailReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.lebeldetail);
            this.Controls.Add(this.tbid);
            this.Controls.Add(this.dgvdetail);
            this.Name = "DetailReminder";
            this.Text = "DetailReminder";
            this.Load += new System.EventHandler(this.DetailReminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvdetail;
        public System.Windows.Forms.TextBox tbid;
        private System.Windows.Forms.Label lebeldetail;
    }
}