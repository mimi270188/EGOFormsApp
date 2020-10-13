using DAL;
using EGO.Container;
using EGO.Controller;
using EGO.ViewModel.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.View.Document
{
    public partial class FrmDocument : Form
    {
        private EgoObject _egoDocument = new EgoDocument();
        private EGOEntities _egoEntities;
        private List<DOCUMENT> _Documents;
        public FrmDocument()
        {
            InitializeComponent();
            numericUpDownDocumentYear.Value = DateTime.Now.Year;
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
            _egoDocument.CreateEditForm(frm, _egoEntities);
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                _egoEntities.DOCUMENT.Remove(_Documents[dataGridView1.CurrentCell.RowIndex]);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Form frm = new Form();
                frm.Text = "Modification";
                frm.Height = 600;
                frm.Width = 600;
                _egoDocument.CreateEditForm(frm, _egoEntities, _Documents[dataGridView1.CurrentCell.RowIndex]);
                frm.ShowDialog();
            }
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            _Documents = _egoEntities.DOCUMENT.Where(x => x.DOCUMENTYEAR == numericUpDownDocumentYear.Value).ToList();
            DocumentSearchView DocumentSearchView = new DocumentSearchView(_Documents);
            dataGridView1.DataSource = DocumentSearchView.DocumentSearchViews;
        }
    }
}
