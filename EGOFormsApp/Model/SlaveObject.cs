﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EGOFormsApp.ViewModel;
using EGOFormsApp.Common;
using System.Security.Cryptography.X509Certificates;
using EGOFormsApp.Common.Control;

namespace EGOFormsApp.Model
{
    public class SlaveObject<T>: ParentObject<T> where T : class
    {
        private List<BindingTables> bindsTables;
        private object masterObj;
        public object MasterObj
        {
            get
            {
                return masterObj;
            }
            set
            {
                masterObj = value;
                RefreshDataGridView(frmSlave, currentStartYear);
            }
        }
        private FrmSlave frmSlave;
        private int currentStartYear;
        public SlaveObject(FrmMain _frmMain, string _masterTypeName, int _currentStartYear)
        {
            egoEntities = new EGOEntities();
            currentStartYear = _currentStartYear;
            frmSlave = new FrmSlave() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            CreateBinding();
            SetEvent(frmSlave, _masterTypeName);
            GetFreePanel(_frmMain).Controls.Add(frmSlave);
            frmSlave.label1.Text = Translation.GetByKey(typeof(T).Name);
            frmSlave.Show();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button buttonAdd = (Button)sender;
            FrmSlave _frmSlave = (FrmSlave)buttonAdd.Parent;
            Add(masterObj);

            RefreshDataGridView(_frmSlave, currentStartYear);
        }
        private void buttonBind_Click(object sender, EventArgs e)
        {
            Button buttonAdd = (Button)sender;
            FrmSlave _frmSlave = (FrmSlave)buttonAdd.Parent;
            Bind(masterObj);

            RefreshDataGridView(_frmSlave, currentStartYear);
        }
        private void Bind(object _masterObj)
        {
            FrmBind frmBind = new FrmBind(_masterObj, typeof(T), egoEntities);
            frmBind.ShowDialog();
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                try
                {
                    Delete(GetObjectById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value), false, typeof(T).Name, masterObj.GetType().BaseType.Name));

                }
                catch (Exception)
                {
                    MessageBox.Show("Suppression impossible car quelque chose s'y rattache");
                }
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                Edit(GetObjectById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value), false, typeof(T).Name, masterObj.GetType().BaseType.Name));
            }
            FrmSlave _frmSlave = (FrmSlave)dataGridView.Parent;
            RefreshDataGridView(_frmSlave, currentStartYear);
        }


        private void RefreshDataGridView(FrmSlave _frmSlave, int _currentStartYear)
        {
            _frmSlave.dataGridView.Columns.Clear();
            string masterObjectTypeName = GetObjectTypeName(masterObj);
            if (typeof(T).Name == "PERSON")
            {
                if (masterObjectTypeName == "FAMILY")
                {
                    int _familyId = Convert.ToInt32(Reflection.GetValue(masterObj, "FAMILYID"));
                    PersonSlaveSearchView _personSlaveSearchView = new PersonSlaveSearchView(egoEntities.PERSON.Where(x => x.FAMILYID == _familyId).ToList(), _currentStartYear);
                    _frmSlave.dataGridView.DataSource = _personSlaveSearchView.PersonSlaveSearchViews;
                    _frmSlave.dataGridView.Columns["PERSONID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave, false);
                    DataGridViewControl.SetHeaderName(_frmSlave.dataGridView);
                    frmSlave.label1.Text = Translation.GetByKey(typeof(T).Name) + "(" + _personSlaveSearchView.PersonSlaveSearchViews.Count + ")";
                }
                if (masterObjectTypeName == "GYMGROUP")
                {
                    int _gymGroupId = Convert.ToInt32(Reflection.GetValue(masterObj, masterObjectTypeName + "ID"));
                    if (_gymGroupId == 0){return;}
                    GymGroupPersonSearchView _gymGroupPersonSearchView = new GymGroupPersonSearchView(egoEntities.PERSON_GYMGROUP.Where(x => x.GYMGROUPID == _gymGroupId).ToList());
                    _frmSlave.dataGridView.DataSource = _gymGroupPersonSearchView.GymGroupPersonSearchViews;
                    _frmSlave.dataGridView.Columns["PERSON_GYMGROUP_ID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave, true);
                    DataGridViewControl.SetHeaderName(_frmSlave.dataGridView);
                    frmSlave.label1.Text = Translation.GetByKey(typeof(T).Name) + "(" + _gymGroupPersonSearchView.GymGroupPersonSearchViews.Count + ")";
                }
            }
            else if (typeof(T).Name == "PHONE")
            {
                if (masterObjectTypeName == "FAMILY")
                {
                    int _familyId = Convert.ToInt32(Reflection.GetValue(masterObj, "FAMILYID"));
                    PhoneSearchView _phoneSearchView = new PhoneSearchView(egoEntities.PHONE.Where(x => x.FAMILYID == _familyId).ToList());
                    _frmSlave.dataGridView.DataSource = _phoneSearchView.PhoneSearchViews;
                    _frmSlave.dataGridView.Columns["PHONEID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave, false);
                    DataGridViewControl.SetHeaderName(_frmSlave.dataGridView);
                    frmSlave.label1.Text = Translation.GetByKey(typeof(T).Name) + "(" + _phoneSearchView.PhoneSearchViews.Count + ")";
                }
            }
            else if (typeof(T).Name == "DISCOUNT")
            {
                if (masterObjectTypeName == "FAMILY")
                {
                    int _familyId = Convert.ToInt32(Reflection.GetValue(masterObj, "FAMILYID"));
                    DiscountSearchView _discountSearchView = new DiscountSearchView(egoEntities.DISCOUNT.Where(x => x.FAMILYID == _familyId).ToList());
                    _frmSlave.dataGridView.DataSource = _discountSearchView.DiscountSearchViews;
                    _frmSlave.dataGridView.Columns["DISCOUNTID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave, false);
                    DataGridViewControl.SetHeaderName(_frmSlave.dataGridView);
                    frmSlave.label1.Text = Translation.GetByKey(typeof(T).Name) + "(" + _discountSearchView.DiscountSearchViews.Count + ")";
                }
            }
            else if (typeof(T).Name == "PAYMENT")
            {
                if (masterObjectTypeName == "FAMILY")
                {
                    int _familyId = Convert.ToInt32(Reflection.GetValue(masterObj, "FAMILYID"));
                    PaymentSearchView _paymentSearchView = new PaymentSearchView(egoEntities.PAYMENT.Where(x => x.FAMILYID == _familyId).ToList());
                    _frmSlave.dataGridView.DataSource = _paymentSearchView.PaymentSearchViews;
                    _frmSlave.dataGridView.Columns["PAYMENTID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave, false);
                    DataGridViewControl.SetHeaderName(_frmSlave.dataGridView);
                    frmSlave.label1.Text = Translation.GetByKey(typeof(T).Name) + "(" + _paymentSearchView.PaymentSearchViews.Count + ")";
                }
            }
            else if (typeof(T).Name == "DOCUMENT")
            {
                if (masterObjectTypeName == "PERSON")
                {
                    int _personId = Convert.ToInt32(Reflection.GetValue(masterObj, "PERSONID"));
                    DocumentSearchView _documentSearchView = new DocumentSearchView(egoEntities.DOCUMENT.Where(x => x.PERSONID == _personId).ToList());
                    _frmSlave.dataGridView.DataSource = _documentSearchView.DocumentSearchViews;
                    _frmSlave.dataGridView.Columns["DOCUMENTID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave, false);
                    DataGridViewControl.SetHeaderName(_frmSlave.dataGridView);
                    frmSlave.label1.Text = Translation.GetByKey(typeof(T).Name) + "(" + _documentSearchView.DocumentSearchViews.Count + ")";
                }
            }
            else if (typeof(T).Name == "GYMGROUP")
            {
                if (masterObjectTypeName == "PERSON")
                {
                    int _personId = Convert.ToInt32(Reflection.GetValue(masterObj, "PERSONID"));
                    PersonGymGroupSearchView _personGymGroupSearchView = new PersonGymGroupSearchView(egoEntities.PERSON_GYMGROUP.Where(x => x.PERSONID == _personId).ToList());
                    _frmSlave.dataGridView.DataSource = _personGymGroupSearchView.PersonGymGroupSearchViews;
                    _frmSlave.dataGridView.Columns["PERSON_GYMGROUP_ID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave, true);
                    DataGridViewControl.SetHeaderName(_frmSlave.dataGridView);
                    frmSlave.label1.Text = Translation.GetByKey(typeof(T).Name) + "(" + _personGymGroupSearchView.PersonGymGroupSearchViews.Count + ")";
                }
            }
        }
        private string GetObjectTypeName(object obj)
        {
            List<string> possibleType = new List<string>() { "PERSON", "FAMILY", "GYMGROUP" };
            if (possibleType.Contains(obj.GetType().Name))
            {
                return obj.GetType().Name;
            }
            else
            {
                return obj.GetType().BaseType.Name;
            }
        }


        private void SetEvent(FrmSlave _frmSlave, string _masterTypeName)
        {
            string slaveObjectName = typeof(T).Name;
            if (bindsTables.Any(x => x.MasterObjectName == _masterTypeName && x.SlaveObjectName == slaveObjectName))
            {
                _frmSlave.buttonAdd.Text = "Lier";
                _frmSlave.buttonAdd.Click += new System.EventHandler(buttonBind_Click);
            }
            else
            {
                _frmSlave.buttonAdd.Text = "Ajouter";
                _frmSlave.buttonAdd.Click += new System.EventHandler(buttonAdd_Click);
            }
            _frmSlave.dataGridView.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
        }
        private Panel GetFreePanel(FrmMain _frmMain)
        {
            foreach (Panel panel in _frmMain.Controls.OfType<Panel>())
            {
                if (panel.Controls.Count == 0)
                {
                    return panel;
                }
            }
            return null;
        }
        private void CreateBinding()
        {
            bindsTables = new List<BindingTables>();
            bindsTables.Add(new BindingTables("PERSON", "KIND"));
            bindsTables.Add(new BindingTables("PERSON", "GYMGROUP"));
            bindsTables.Add(new BindingTables("GYMGROUP", "PERSON"));
        }
    }
}