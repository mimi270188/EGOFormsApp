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
            //label1.Text = txt;
            _txt = txt;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'eGODataSet.KIND'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.kINDTableAdapter.Fill(this.eGODataSet.KIND);

        }
    }
}
