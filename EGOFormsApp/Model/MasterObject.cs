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
            RefreshDataGridView(_frmMaster, egoEntities);
            SetChild(_frmMain, _frmMaster);
            PositionPanel(_frmMain);
            SimulateClickOneFirstDataGridViewRow(_frmMaster);
            _frmMaster.Show();

            Cursor.Current = Cursors.Default;
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Button buttonSearch = (Button)sender;
            FrmMaster _frmMaster = (FrmMaster)buttonSearch.Parent;
            string primaryKey = typeof(T).Name + "ID";

            RefreshDataGridView(_frmMaster, egoEntities);
            SimulateClickOneFirstDataGridViewRow(_frmMaster);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button buttonAdd = (Button)sender;
            FrmMaster _frmMaster = (FrmMaster)buttonAdd.Parent;
            Add();
            SimulateClickOneFirstDataGridViewRow(_frmMaster);
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string primaryKey = typeof(T).Name + "ID";
            if (e.RowIndex == -1){return;}
            Cursor.Current = Cursors.WaitCursor;
            DataGridView dataGridView = (DataGridView)sender;
            FrmMaster _frmMaster = (FrmMaster)dataGridView.Parent;
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                try 
                { 
                    Delete(GetObjectById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[primaryKey].Value), true, null, typeof(T).Name));
                    CurrencyManager currencyManager1 = (CurrencyManager)_frmMaster.dataGridView.BindingContext[_frmMaster.dataGridView.DataSource];
                    currencyManager1.SuspendBinding();
                    dataGridView.Rows[e.RowIndex].Visible = false;
                    currencyManager1.ResumeBinding();
                    SimulateClickOneFirstDataGridViewRow(_frmMaster);
                }
                catch (Exception)
                {
                    MessageBox.Show("Suppression impossible car quelque chose s'y rattache");
                }
        }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                Edit(GetObjectById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[primaryKey].Value), true, null, typeof(T).Name));
                RefreshDataGridView(_frmMaster, egoEntities);
                SimulateClickOneFirstDataGridViewRow(_frmMaster);
            }
            else
            {
                UpdateChild(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[primaryKey].Value), _frmMaster);
                UnColorDatagridView(dataGridView);
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
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
                    FamilySearchView familySearchView = new FamilySearchView(_egoEntities.FAMILY.Where(x => x.LASTNAME.Contains(lastNameFamily)).ToList().OrderBy(x => x.LASTNAME).ToList());
                    _frmMaster.dataGridView.DataSource = familySearchView.FamilySearchViews;
                    _frmMaster.dataGridView.Columns["FAMILYID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmMaster, false);
                    DataGridViewControl.SetHeaderName(_frmMaster.dataGridView);
                    SetAutoCompletion(_frmMaster.textBox1, familySearchView.FamilySearchViews.Select(x => x.LASTNAME).ToList());
                    _frmMaster.label3.Text = "Famille(" + familySearchView.FamilySearchViews.Count + ")";
                    break;
                case "PERSON":
                    string lastNamePerson = _frmMaster.textBox1.Text;
                    PersonMasterSearchView personSearchView = new PersonMasterSearchView(_egoEntities.PERSON.Where(x => x.LASTNAME.Contains(lastNamePerson)).ToList().OrderBy(x => x.LASTNAME).ToList());
                    _frmMaster.dataGridView.DataSource = personSearchView.PersonSearchViews;
                    _frmMaster.dataGridView.Columns["PERSONID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmMaster, false);
                    DataGridViewControl.SetHeaderName(_frmMaster.dataGridView);
                    SetAutoCompletion(_frmMaster.textBox1, personSearchView.PersonSearchViews.Select(x => x.LASTNAME).ToList());
                    _frmMaster.label3.Text = "Adhérent(" + personSearchView.PersonSearchViews.Count + ")";
                    break;
                case "GYMGROUP":
                    string gymGroupName = _frmMaster.textBox1.Text;
                    GymGroupSearchView gymGroupSearchView = new GymGroupSearchView(_egoEntities.GYMGROUP.Where(x => x.GYMGROUPNAME.Contains(gymGroupName) && x.GYMGROUPYEAR == _frmMaster.numericUpDown1.Value).ToList());
                    _frmMaster.dataGridView.DataSource = gymGroupSearchView.GymGroupSearchViews;
                    _frmMaster.dataGridView.Columns["GYMGROUPID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmMaster, false);
                    DataGridViewControl.SetHeaderName(_frmMaster.dataGridView);
                    SetAutoCompletion(_frmMaster.textBox1, gymGroupSearchView.GymGroupSearchViews.Select(x => x.GYMGROUPNAME).ToList());
                    _frmMaster.label3.Text = "Groupe - " + _frmMaster.numericUpDown1.Value + "(" + gymGroupSearchView.GymGroupSearchViews.Count + ")";
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        private void UpdateChild(int _id, FrmMaster _frmMaster)
        {
            object obj = GetObjectById(_id, true, null, typeof(T).Name);
            FrmMain frmMain = (FrmMain)_frmMaster.Parent.Parent;
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    frmMain.Text = "Espoirs Gymniques d'Osny - Famille - " + ((FAMILY)obj).LASTNAME + " " + ((FAMILY)obj).ZIPCODE + " " + ((FAMILY)obj).CITY + " " + ((FAMILY)obj).ADDRESS;
                    break;
                case "PERSON":
                    frmMain.Text = "Espoirs Gymniques d'Osny - Adhérent - " + ((PERSON)obj).LASTNAME + " " + ((PERSON)obj).FIRSTNAME;
                    break;
                case "GYMGROUP":
                    frmMain.Text = "Espoirs Gymniques d'Osny - Groupe - " + ((GYMGROUP)obj).GYMGROUPYEAR + " " + ((GYMGROUP)obj).GYMGROUPNAME;
                    break;
                default:
                    break;
            }
            foreach (object slaveObj in slaveObjects)
            {
                Reflection.SetValue(slaveObj, "MasterObj", obj);
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
        private void SimulateClickOneFirstDataGridViewRow(FrmMaster _frmMaster)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_frmMaster.dataGridView.Rows.Count == 0){ return; }
            string primaryKey = typeof(T).Name + "ID";
            UpdateChild(Convert.ToInt32(_frmMaster.dataGridView.Rows[0].Cells[primaryKey].Value), _frmMaster);
            if (_frmMaster.dataGridView.Rows.Count != 0)
            {
                _frmMaster.dataGridView.Rows[0].DefaultCellStyle.BackColor = Color.Blue;
                _frmMaster.dataGridView.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            }
            Cursor.Current = Cursors.Default;
        }
        private void SetChild(FrmMain _frmMain, FrmMaster _frmMaster)
        {
            slaveObjects = new List<object>();
            int currentStartYear = Common.Common.CurrentStartYear();
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    slaveObjects.Add(new SlaveObject<PERSON>(_frmMain, typeof(T).Name, currentStartYear));
                    slaveObjects.Add(new SlaveObject<PHONE>(_frmMain, typeof(T).Name, currentStartYear));
                    slaveObjects.Add(new SlaveObject<DISCOUNT>(_frmMain, typeof(T).Name, currentStartYear));
                    slaveObjects.Add(new SlaveObject<PAYMENT>(_frmMain, typeof(T).Name, currentStartYear));
                    break;
                case "PERSON":
                    slaveObjects.Add(new SlaveObject<DOCUMENT>(_frmMain, typeof(T).Name, currentStartYear));
                    slaveObjects.Add(new SlaveObject<GYMGROUP>(_frmMain, typeof(T).Name, currentStartYear));
                    break;
                case "GYMGROUP":
                    slaveObjects.Add(new SlaveObject<PERSON>(_frmMain, typeof(T).Name, currentStartYear));
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
                    _frmMaster.label2.Text = "Nom:";
                    _frmMaster.label1.Text = "Année";
                    _frmMaster.numericUpDown1.Maximum = 3000;
                    _frmMaster.numericUpDown1.Value = Common.Common.CurrentStartYear();
                    _frmMaster.label2.Text = "Nom du Groupe:";
        }
        private void PositionPanel(FrmMain _frmMain)
        {
            int heightPanel = slaveObjects.Count == 0 ? (_frmMain.Height - 70) : ((_frmMain.Height - 70) / slaveObjects.Count);
            int widthPanel = _frmMain.Width - 20;
            int y = 25;
            int x = (widthPanel / 2) + 5;

            _frmMain.panel1.Width = widthPanel / 2;
            widthPanel = (widthPanel / 2) - 10;


            _frmMain.panel2.Location = new Point(x, y);
            _frmMain.panel2.Height = heightPanel;
            _frmMain.panel2.Width = widthPanel;

            y = y + heightPanel;
            _frmMain.panel3.Location = new Point(x, y);
            _frmMain.panel3.Height = heightPanel;
            _frmMain.panel3.Width = widthPanel;

            y = y + heightPanel;
            _frmMain.panel4.Location = new Point(x, y);
            _frmMain.panel4.Height = heightPanel;
            _frmMain.panel4.Width = widthPanel;

            y = y + heightPanel;
            _frmMain.panel5.Location = new Point(x, y);
            _frmMain.panel5.Height = heightPanel;
            _frmMain.panel5.Width = widthPanel;

      
            //panel1.BackColor = Color.Green;
            //panel2.BackColor = Color.Red;
            //panel3.BackColor = Color.Blue;
            //panel4.BackColor = Color.Yellow;
            //panel5.BackColor = Color.Pink;         
        }
        private void UnColorDatagridView(DataGridView _dataGridView)
        {
            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
