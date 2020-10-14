using GymApp.Common;
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
    public partial class FrmMaster : System.Windows.Forms.Form
    {
        private Type _Type;
        private EGOEntities _egoEntities;
        public FrmMaster(Type type)
        {
            InitializeComponent();
            _egoEntities = new EGOEntities();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Model.Search(ref dataGridView1, textBox1, _Type, _egoEntities);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
