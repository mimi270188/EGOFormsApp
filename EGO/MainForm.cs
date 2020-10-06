using DAL;
using EGO.Container;
using EGO.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void créationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EgoObject egoObject = new EgoFamille();
            egoObject.CreateEditForm(this, typeof(FAMILY));
                      
        }
    }
}
