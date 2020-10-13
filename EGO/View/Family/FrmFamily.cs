using DAL;
using EGO.Container;
using EGO.ViewModel.Family;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EGO.Controller;

namespace EGO.View.Family
{
    public partial class FrmFamily : Form
    {
        private EgoObject _egoFamily = new EgoFamily();
        private EGOEntities _egoEntities;
        private List<FAMILY> _Familys;
        public FrmFamily()
        {
            InitializeComponent();
            _egoEntities = new EGOEntities();
            RefreshDataGridView();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Création";
            frm.Height = 600;
            frm.Width = 600;
            _egoFamily.CreateEditForm(frm, _egoEntities);
            frm.ShowDialog();
            RefreshDataGridView();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                _egoEntities.FAMILY.Remove(_Familys[dataGridView1.CurrentCell.RowIndex]);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Form frm = new Form();
                frm.Text = "Modification";
                frm.Height = 600;
                frm.Width = 600;
                _egoFamily.CreateEditForm(frm, _egoEntities, _Familys[dataGridView1.CurrentCell.RowIndex]);
                frm.ShowDialog();
            }
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            _Familys = _egoEntities.FAMILY.Where(x => x.LASTNAME.Contains(textBoxLastName.Text)).ToList();
            FamilySearchView FamilySearchView = new FamilySearchView(_Familys);
            dataGridView1.DataSource = FamilySearchView.FamilySearchViews;
        }
    }
}