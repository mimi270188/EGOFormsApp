using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using EGOFormsApp.Common;
using EGOFormsApp.ViewModel;

namespace EGOFormsApp.Model
{
    public class MasterObject<T> : ParentObject<T> where T : class
    {
        List<object> slaveObjects;

        public MasterObject(FrmMain _frmMain)
        {
            egoEntities = new EGOEntities();
            FrmMaster _frmMaster = new FrmMaster() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            SetConrols(_frmMaster);
            SetEvent(_frmMaster);
            _frmMain.panel1.Controls.Add(_frmMaster);
            _frmMaster.Show();
            RefreshDataGridView(_frmMaster);
            SetChild(_frmMain);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Button buttonSearch = (Button)sender;
            FrmMaster _frmMaster = (FrmMaster)buttonSearch.Parent;
            RefreshDataGridView(_frmMaster);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button buttonAdd = (Button)sender;
            FrmMaster _frmMaster = (FrmMaster)buttonAdd.Parent;
            Add();

            RefreshDataGridView(_frmMaster);
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                Delete(GetObjectById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value)));
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                Edit(GetObjectById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value)));
            }
            else
            {
                UpdateChild(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
            }
            FrmMaster _frmMaster = (FrmMaster)dataGridView.Parent;
            RefreshDataGridView(_frmMaster);
        }


        private void RefreshDataGridView(FrmMaster _frmMaster)
        {
            _frmMaster.dataGridView.Columns.Clear();
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    string lastNameFamily = _frmMaster.textBox1.Text;
                    FamilySearchView familySearchView = new FamilySearchView(egoEntities.FAMILY.Where(x => x.LASTNAME.Contains(lastNameFamily)).ToList());
                    _frmMaster.dataGridView.DataSource = familySearchView.FamilySearchViews;
                    _frmMaster.dataGridView.Columns["FAMILYID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmMaster);
                    break;
                case "PERSON":
                    string lastNamePerson = _frmMaster.textBox1.Text;
                    PersonSearchView personSearchView = new PersonSearchView(egoEntities.PERSON.Where(x => x.LASTNAME.Contains(lastNamePerson)).ToList());
                    _frmMaster.dataGridView.DataSource = personSearchView.PersonSearchViews;
                    _frmMaster.dataGridView.Columns["PERSONID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmMaster);
                    break;
            }
        }
        private void UpdateChild(int id)
        {
            foreach (object slaveObj in slaveObjects)
            {
                Reflection.SetValue(slaveObj, "MasterObj", GetObjectById(id));
            }
        }

        private void SetChild(FrmMain _frmMain)
        {
            slaveObjects = new List<object>();
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    slaveObjects.Add(new SlaveObject<PERSON>(_frmMain, GetObjectById(0)));
                    slaveObjects.Add(new SlaveObject<PHONE>(_frmMain, GetObjectById(0)));
                    slaveObjects.Add(new SlaveObject<DISCOUNT>(_frmMain, GetObjectById(0)));
                    slaveObjects.Add(new SlaveObject<PAYMENT>(_frmMain, GetObjectById(0)));
                    break;
                case "PERSON":
                    slaveObjects.Add(new SlaveObject<KIND>(_frmMain, GetObjectById(0)));
                    slaveObjects.Add(new SlaveObject<DOCUMENT>(_frmMain, GetObjectById(0)));
                    slaveObjects.Add(new SlaveObject<GYMGROUP>(_frmMain, GetObjectById(0)));
                    break;
                default:
                    break;
            }
        }
        private void SetEvent(FrmMaster _frmMaster)
        {
            _frmMaster.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            _frmMaster.dataGridView.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            _frmMaster.buttonAdd.Click += new System.EventHandler(buttonAdd_Click);
        }
        private void SetConrols(FrmMaster _frmMaster)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                case "PERSON":
                    Label label1 = (Label)_frmMaster.Controls.Find("label1", false).First();
                    label1.Visible = false;
                    NumericUpDown numericUpDown1 = (NumericUpDown)_frmMaster.Controls.Find("numericUpDown1", false).First();
                    numericUpDown1.Visible = false;
                    Label label2 = (Label)_frmMaster.Controls.Find("label2", false).First();
                    label2.Text = "Nom:";
                    break;
            }
        }
    }
}
