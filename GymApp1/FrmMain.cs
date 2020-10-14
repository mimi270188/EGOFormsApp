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
using GymApp1.Model;

namespace GymApp1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            int heightPanel = (((this.Height + 200) - (3 * 6)) / 4);
            int y = -100;
            panel2.Location = new Point(659, y);
            panel2.Size = new Size(630, heightPanel);
            //panel2.BackColor = Color.Red;

            y = y + 6 + heightPanel;
            panel3.Location = new Point(659, y);
            panel3.Size = new Size(630, heightPanel);
            //panel3.BackColor = Color.Blue;

            y = y + 6 + heightPanel;
            panel4.Location = new Point(659, y);
            panel4.Size = new Size(630, heightPanel);
            //panel4.BackColor = Color.Yellow;

            y = y + 6 + heightPanel;
            panel5.Location = new Point(659, y);
            panel5.Size = new Size(630, heightPanel);
            //panel5.BackColor = Color.Pink;

        }

        private void familyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterObject<FAMILY> _masterObjectFamily = new MasterObject<FAMILY>(this);
        }
    }
}
