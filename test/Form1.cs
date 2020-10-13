using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        Form2 _frm2;
        Form3 _frm3;
        public Form1()
        {
            InitializeComponent();
            _frm2 = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; ;
            panel1.Controls.Add(_frm2);
            _frm2.Show();

            _frm3 = new Form3() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; ;
            panel2.Controls.Add(_frm3);
            _frm3.Show();
        }

        protected virtual void button1_Click(object sender, EventArgs e)
        {
            _frm2.SetTxt("test");
            _frm3.SetTxt("test");
        }
    }
}
