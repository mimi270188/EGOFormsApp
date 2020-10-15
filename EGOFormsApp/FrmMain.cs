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

namespace EGOFormsApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            int heightPanel = ((this.Height - 70) / 4);
            int y = 25;
            panel2.Location = new Point(659, y);
            panel2.Height = heightPanel;

            y = y + heightPanel;
            panel3.Location = new Point(659, y);
            panel3.Height = heightPanel;

            y = y + heightPanel;
            panel4.Location = new Point(659, y);
            panel4.Height = heightPanel;

            y = y + heightPanel;
            panel5.Location = new Point(659, y);
            panel5.Height = heightPanel;

            //panel1.BackColor = Color.Green;
            //panel2.BackColor = Color.Red;
            //panel3.BackColor = Color.Blue;
            //panel4.BackColor = Color.Yellow;
            //panel5.BackColor = Color.Pink;
        }

        private void familyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterObject<FAMILY> _masterObjectFamily = new MasterObject<FAMILY>(this);
        }


        private void PersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterObject<PERSON> _masterObjectPerson = new MasterObject<PERSON>(this);
        }
    }
}
