using DAL;
using EGO.Container;
using EGO.Controller;
using EGO.ViewModel.Kind;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.View.Kind
{
    public partial class FrmKind : Form
    {
        private EgoObject _egoKind = new EgoKind();
        private EGOEntities _egoEntities;
        private List<KIND> _Kinds;
        public FrmKind()
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
            _egoKind.CreateEditForm(frm, _egoEntities);
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                _egoEntities.KIND.Remove(_Kinds[dataGridView1.CurrentCell.RowIndex]);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Form frm = new Form();
                frm.Text = "Modification";
                frm.Height = 600;
                frm.Width = 600;
                _egoKind.CreateEditForm(frm, _egoEntities, _Kinds[dataGridView1.CurrentCell.RowIndex]);
                frm.ShowDialog();
            }
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            _Kinds = _egoEntities.KIND.Where(x => x.KINDNAME.Contains(textBoxKindName.Text)).ToList();
            KindSearchView KindSearchView = new KindSearchView(_Kinds);
            dataGridView1.DataSource = KindSearchView.KindSearchViews;
        }
    }
}