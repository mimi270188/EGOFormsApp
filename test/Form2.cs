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
    public partial class Form2 : Form
    {
        private string _txt;
        public string GetTxt()
        {
            return _txt;
        }

        public void SetTxt(string txt)
        {
            label1.Text = txt;
            _txt = txt;
        }
        public Form2()
        {
            InitializeComponent();
        }
    }
}
