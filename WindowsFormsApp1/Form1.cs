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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            this.StartPosition = FormStartPosition.CenterScreen;

            Reminder rm = new Reminder();
            rm.MdiParent = this;
            rm.Show();
            rm.Location = new Point(0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sembarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            this.StartPosition = FormStartPosition.CenterScreen;

            ReportStock rs = new ReportStock();
            rs.MdiParent = this;
            rs.Show();
            rs.Location = new Point(0, 0);
        }
    }
}
