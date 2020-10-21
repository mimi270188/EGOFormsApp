using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EGOFormsApp.Model;
using EGOFormsApp.Common;

namespace EGOFormsApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPanels();
            MasterObject<FAMILY> _masterObjectFamily = new MasterObject<FAMILY>(this);
        }


        private void PersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPanels();
            MasterObject<PERSON> _masterObjectPerson = new MasterObject<PERSON>(this);
        }
        private void GroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPanels();
            MasterObject<GYMGROUP> _masterObjectPerson = new MasterObject<GYMGROUP>(this);
        }

        private void ResetPanels()
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            panel4.Controls.Clear();
            panel5.Controls.Clear();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetting FrmSetting = new FrmSetting();
            FrmSetting.ShowDialog();
        }
    }
}
