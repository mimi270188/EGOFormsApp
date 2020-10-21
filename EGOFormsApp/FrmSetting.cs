using EGOFormsApp.Common;
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
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void buttonDrop_Click(object sender, EventArgs e)
        {
            Database.Drop();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Database.Create();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Reader.ImportExcel(this);
        }
    }
}
