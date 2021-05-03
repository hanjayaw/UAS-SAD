
namespace WindowsFormsApp1
{
    partial class Reminder
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
            this.dgvbulanini = new System.Windows.Forms.DataGridView();
            this.dgvbulandepan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbulanini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbulandepan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvbulanini
            // 
            this.dgvbulanini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbulanini.Location = new System.Drawing.Point(63, 98);
            this.dgvbulanini.Name = "dgvbulanini";
            this.dgvbulanini.Size = new System.Drawing.Size(1135, 307);
            this.dgvbulanini.TabIndex = 0;
            this.dgvbulanini.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbulanini_CellClick);
            // 
            // dgvbulandepan
            // 
            this.dgvbulandepan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbulandepan.Location = new System.Drawing.Point(63, 516);
            this.dgvbulandepan.Name = "dgvbulandepan";
            this.dgvbulandepan.Size = new System.Drawing.Size(1135, 125);
            this.dgvbulandepan.TabIndex = 28;
            this.dgvbulandepan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbulandepan_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(564, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 33);
            this.label1.TabIndex = 29;
            this.label1.Text = "BULAN INI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(545, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 33);
            this.label2.TabIndex = 30;
            this.label2.Text = "BULAN DEPAN";
            // 
            // Reminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvbulandepan);
            this.Controls.Add(this.dgvbulanini);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reminder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reminder";
            this.Load += new System.EventHandler(this.Reminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbulanini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbulandepan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvbulanini;
        private System.Windows.Forms.DataGridView dgvbulandepan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}