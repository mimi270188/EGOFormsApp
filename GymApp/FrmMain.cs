using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace GymApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void PersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GymObject<FAMILY> GymObject = new GymApp.GymObject<FAMILY>(this);
            
        }
    }
}
