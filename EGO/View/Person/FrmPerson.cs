using DAL;
using EGO.Container;
using EGO.Controller;
using EGO.ViewModel.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.View.Person
{
    public delegate void Notify(PERSON person, Form frmMain);
    public partial class FrmPerson : Form
    {
        private EgoObject _egoPerson = new EgoPerson();
        private EGOEntities _egoEntities;
        private List<PERSON> _Persons;
        public event Notify _dataUpdated;
        public FrmPerson()
        {
            InitializeComponent();
            _egoEntities = new EGOEntities();
            RefreshDataGridView();
        }

        protected virtual void _OnDatasUpdate(PERSON person, Form frmMain)
        {
            _dataUpdated?.Invoke(person, frmMain);
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
            _egoPerson.CreateEditForm(frm, _egoEntities);
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                _egoEntities.PERSON.Remove(_Persons[dataGridView1.CurrentCell.RowIndex]);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Form frm = new Form();
                frm.Text = "Modification";
                frm.Height = 600;
                frm.Width = 600;
                _egoPerson.CreateEditForm(frm, _egoEntities, _Persons[dataGridView1.CurrentCell.RowIndex]);
                frm.ShowDialog();
            }else
            {
                _OnDatasUpdate(_Persons[dataGridView1.CurrentCell.RowIndex], this.Parent.Parent as Form);
            }
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            _Persons = _egoEntities.PERSON.Where(x => x.LASTNAME.Contains(textBoxLastName.Text)).ToList();
            PersonSearchView PersonSearchView = new PersonSearchView(_Persons);
            dataGridView1.DataSource = PersonSearchView.PersonSearchViews;
        }
    }
}
