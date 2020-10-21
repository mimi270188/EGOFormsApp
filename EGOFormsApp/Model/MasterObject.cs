using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using EGOFormsApp.Common;
using EGOFormsApp.Common.Control;
using EGOFormsApp.ViewModel;

namespace EGOFormsApp.Model
{
    public class MasterObject<T> : ParentObject<T> where T : class
    {
        List<object> slaveObjects;

        public MasterObject(FrmMain _frmMain)
        {
            Cursor.Current = Cursors.WaitCursor;

            egoEntities = new EGOEntities();
            FrmMaster _frmMaster = new FrmMaster() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            SetConrols(_frmMaster);
            SetEvent(_frmMaster);
            _frmMain.panel1.Controls.Add(_frmMaster);
            _frmMaster.Show();
            RefreshDataGridView(_frmMaster, egoEntities);
            SetChild(_frmMain);
            PositionPanel(_frmMain);
            ColorFirstRow(_frmMaster);

            Cursor.Current = Cursors.Default;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Button buttonSearch = (Button)sender;
            FrmMaster _frmMaster = (FrmMaster)buttonSearch.Parent;
            RefreshDataGridView(_frmMaster, egoEntities);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button buttonAdd = (Button)sender;
            FrmMaster _frmMaster = (FrmMaster)buttonAdd.Parent;
            Add();

            RefreshDataGridView(_frmMaster, egoEntities);
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                Delete(GetObjectById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value), true, null, typeof(T).Name));
                UpdateChild(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                Edit(GetObjectById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value), true, null, typeof(T).Name));
                UpdateChild(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
            }
            else
            {
                UpdateChild(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
            }
            FrmMaster _frmMaster = (FrmMaster)dataGridView.Parent;
            RefreshDataGridView(_frmMaster, egoEntities);
            dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
            dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            Cursor.Current = Cursors.Default;
        }


        private void RefreshDataGridView(FrmMaster _frmMaster,EGOEntities _egoEntities)
        {
            Cursor.Current = Cursors.WaitCursor;
            _frmMaster.dataGridView.Columns.Clear();
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    string lastNameFamily = _frmMaster.textBox1.Text;
                    FamilySearchView familySearchView = new FamilySearchView(_egoEntities.FAMILY.Where(x => x.LASTNAME.Contains(lastNameFamily)).ToList());
                    _frmMaster.dataGridView.DataSource = familySearchView.FamilySearchViews;
                    _frmMaster.dataGridView.Columns["FAMILYID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmMaster, false);
                    DataGridViewControl.SetHeaderName(_frmMaster.dataGridView);
                    SetAutoCompletion(_frmMaster.textBox1, familySearchView.FamilySearchViews.Select(x => x.LASTNAME).ToList());
                    break;
                case "PERSON":
                    string lastNamePerson = _frmMaster.textBox1.Text;
                    PersonSearchView personSearchView = new PersonSearchView(_egoEntities.PERSON.Where(x => x.LASTNAME.Contains(lastNamePerson)).ToList());
                    _frmMaster.dataGridView.DataSource = personSearchView.PersonSearchViews;
                    _frmMaster.dataGridView.Columns["PERSONID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmMaster, false);
                    DataGridViewControl.SetHeaderName(_frmMaster.dataGridView);
                    SetAutoCompletion(_frmMaster.textBox1, personSearchView.PersonSearchViews.Select(x => x.LASTNAME).ToList());
                    break;
                case "GYMGROUP":
                    string gymGroupName = _frmMaster.textBox1.Text;
                    GymGroupSearchView gymGroupSearchView = new GymGroupSearchView(_egoEntities.GYMGROUP.Where(x => x.GYMGROUPNAME.Contains(gymGroupName) && x.GYMGROUPYEAR == _frmMaster.numericUpDown1.Value).ToList());
                    _frmMaster.dataGridView.DataSource = gymGroupSearchView.GymGroupSearchViews;
                    _frmMaster.dataGridView.Columns["GYMGROUPID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmMaster, false);
                    DataGridViewControl.SetHeaderName(_frmMaster.dataGridView);
                    SetAutoCompletion(_frmMaster.textBox1, gymGroupSearchView.GymGroupSearchViews.Select(x => x.GYMGROUPNAME).ToList());
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private void UpdateChild(int id)
        {
            foreach (object slaveObj in slaveObjects)
            {
                Reflection.SetValue(slaveObj, "MasterObj", GetObjectById(id, true, null, typeof(T).Name));
            }
        }
        private void SetAutoCompletion(TextBox _textBox, List<string> _listString)
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            foreach (var st in _listString)
            {
                autoCompleteStringCollection.Add(st);
            }
            _textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _textBox.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void SetChild(FrmMain _frmMain)
        {
            slaveObjects = new List<object>();
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    slaveObjects.Add(new SlaveObject<PERSON>(_frmMain, GetObjectById(0, true, null, typeof(T).Name))); ;
                    slaveObjects.Add(new SlaveObject<PHONE>(_frmMain, GetObjectById(0, true, null, typeof(T).Name)));
                    slaveObjects.Add(new SlaveObject<DISCOUNT>(_frmMain, GetObjectById(0, true, null, typeof(T).Name)));
                    slaveObjects.Add(new SlaveObject<PAYMENT>(_frmMain, GetObjectById(0, true, null, typeof(T).Name)));
                    break;
                case "PERSON":
                    slaveObjects.Add(new SlaveObject<KIND>(_frmMain, GetObjectById(0, true, null, typeof(T).Name)));
                    slaveObjects.Add(new SlaveObject<DOCUMENT>(_frmMain, GetObjectById(0, true, null, typeof(T).Name)));
                    slaveObjects.Add(new SlaveObject<GYMGROUP>(_frmMain, GetObjectById(0, true, null, typeof(T).Name)));
                    break;
                case "GYMGROUP":
                    slaveObjects.Add(new SlaveObject<PERSON>(_frmMain, GetObjectById(0, true, null, typeof(T).Name)));
                    break;
                default:
                    break;
            }
        }
        private void SetEvent(FrmMaster _frmMaster)
        {
            _frmMaster.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            _frmMaster.dataGridView.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
            _frmMaster.buttonAdd.Click += new System.EventHandler(buttonAdd_Click);
        }
        private void SetConrols(FrmMaster _frmMaster)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                case "PERSON":
                    _frmMaster.label1.Visible = false;
                    _frmMaster.numericUpDown1.Visible = false;
                    _frmMaster.label2.Text = "Nom:";
                    break;
                case "GYMGROUP":
                    _frmMaster.label1.Visible = true;
                    _frmMaster.label1.Text = "Année";
                    _frmMaster.numericUpDown1.Visible = true;
                    _frmMaster.numericUpDown1.Maximum = 3000;
                    _frmMaster.numericUpDown1.Value = DateTime.Now.Year;
                    _frmMaster.label2.Text = "Nom du Groupe:";
                    break;
            }
        }
        private void PositionPanel(FrmMain _frmMain)
        {
            int heightPanel = slaveObjects.Count == 0 ? (_frmMain.Height - 70) : ((_frmMain.Height - 70) / slaveObjects.Count);
            int y = 25;
            _frmMain.panel2.Location = new Point(659, y);
            _frmMain.panel2.Height = heightPanel;

            y = y + heightPanel;
            _frmMain.panel3.Location = new Point(659, y);
            _frmMain.panel3.Height = heightPanel;

            y = y + heightPanel;
            _frmMain.panel4.Location = new Point(659, y);
            _frmMain.panel4.Height = heightPanel;

            y = y + heightPanel;
            _frmMain.panel5.Location = new Point(659, y);
            _frmMain.panel5.Height = heightPanel;

            //panel1.BackColor = Color.Green;
            //panel2.BackColor = Color.Red;
            //panel3.BackColor = Color.Blue;
            //panel4.BackColor = Color.Yellow;
            //panel5.BackColor = Color.Pink;         
        }
    }
}
