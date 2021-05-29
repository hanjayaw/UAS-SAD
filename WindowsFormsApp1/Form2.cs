using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class mdiuser : Form
    {
        public mdiuser()
        {
            InitializeComponent();
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            this.StartPosition = FormStartPosition.CenterScreen;

            FormPembelian fp = new FormPembelian();
            fp.MdiParent = this;
            fp.Show();
            fp.Location = new Point(0, 0);
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            this.StartPosition = FormStartPosition.CenterScreen;

            FormPenjualan fj = new FormPenjualan();
            fj.MdiParent = this;
            fj.Show();
            fj.Location = new Point(0, 0);
        }

        private void reminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            this.StartPosition = FormStartPosition.CenterScreen;

            Reminder rm = new Reminder();
            rm.MdiParent = this;
            rm.Show();
            rm.Location = new Point(0, 0);
        }
    }
}
