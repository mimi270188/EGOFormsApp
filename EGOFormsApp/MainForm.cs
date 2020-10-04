using EGOFormsApp.Family;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGOFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void personnesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void familleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFamily frmFamily = new FrmFamily() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pContainer.Controls.Add(frmFamily);
            frmFamily.Show();
        }
    }
}
