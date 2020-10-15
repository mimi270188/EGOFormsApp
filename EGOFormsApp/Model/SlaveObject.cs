using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EGOFormsApp.ViewModel;
using EGOFormsApp.Common;
using System.Security.Cryptography.X509Certificates;

namespace EGOFormsApp.Model
{
    public class SlaveObject<T>: ParentObject<T> where T : class
    {
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
                RefreshDataGridView(frmSlave);
            }
        }
        private FrmSlave frmSlave;
        public SlaveObject(FrmMain _frmMain, object _obj)
        {
            egoEntities = new EGOEntities();
            masterObj = _obj;
            frmSlave = new FrmSlave() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            SetEvent(frmSlave);
            GetFreePanel(_frmMain).Controls.Add(frmSlave);
            frmSlave.Show();
            RefreshDataGridView(frmSlave);
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button buttonAdd = (Button)sender;
            FrmSlave _frmSlave = (FrmSlave)buttonAdd.Parent;
            Add(masterObj);

            RefreshDataGridView(_frmSlave);
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
            FrmSlave _frmSlave = (FrmSlave)dataGridView.Parent;
            RefreshDataGridView(_frmSlave);
        }


        private void RefreshDataGridView(FrmSlave _frmSlave)
        {
            _frmSlave.dataGridView.Columns.Clear();
            if (typeof(T).Name == "FAMILY")
            {

            }
            else if (typeof(T).Name == "PERSON")
            {
                if (masterObj.GetType().BaseType.Name == "FAMILY")
                {
                    int _familyId = Convert.ToInt32(Reflection.GetValue(masterObj, "FAMILYID"));
                    PersonSearchView _personSearchView = new PersonSearchView(egoEntities.PERSON.Where(x => x.FAMILYID == _familyId).ToList());
                    _frmSlave.dataGridView.DataSource = _personSearchView.PersonSearchViews;
                    _frmSlave.dataGridView.Columns["PERSONID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave);
                }

            }
            else if (typeof(T).Name == "PHONE")
            {
                if (masterObj.GetType().BaseType.Name == "FAMILY")
                {
                    int _familyId = Convert.ToInt32(Reflection.GetValue(masterObj, "FAMILYID"));
                    PhoneSearchView _phoneSearchView = new PhoneSearchView(egoEntities.PHONE.Where(x => x.FAMILYID == _familyId).ToList());
                    _frmSlave.dataGridView.DataSource = _phoneSearchView.PhoneSearchViews;
                    _frmSlave.dataGridView.Columns["PHONEID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave);
                }
            }
            else if (typeof(T).Name == "DISCOUNT")
            {
                if (masterObj.GetType().BaseType.Name == "FAMILY")
                {
                    int _familyId = Convert.ToInt32(Reflection.GetValue(masterObj, "FAMILYID"));
                    DiscountSearchView _discountSearchView = new DiscountSearchView(egoEntities.DISCOUNT.Where(x => x.FAMILYID == _familyId).ToList());
                    _frmSlave.dataGridView.DataSource = _discountSearchView.DiscountSearchViews;
                    _frmSlave.dataGridView.Columns["DISCOUNTID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave);
                }
            }
            else if (typeof(T).Name == "PAYMENT")
            {
                if (masterObj.GetType().BaseType.Name == "FAMILY")
                {
                    int _familyId = Convert.ToInt32(Reflection.GetValue(masterObj, "FAMILYID"));
                    PaymentSearchView _paymentSearchView = new PaymentSearchView(egoEntities.PAYMENT.Where(x => x.FAMILYID == _familyId).ToList());
                    _frmSlave.dataGridView.DataSource = _paymentSearchView.PaymentSearchViews;
                    _frmSlave.dataGridView.Columns["PAYMENTID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave);
                }
            }
            else if (typeof(T).Name == "KIND")
            {
                if (masterObj.GetType().BaseType.Name == "PERSON")
                {
                    int _personId = Convert.ToInt32(Reflection.GetValue(masterObj, "PERSONID"));
                    KindSearchView _kindSearchView = new KindSearchView(egoEntities.PERSON_KIND.Where(x => x.PERSONID == _personId).Select(x => x.KIND).ToList());
                    _frmSlave.dataGridView.DataSource = _kindSearchView.KindSearchViews;
                    _frmSlave.dataGridView.Columns["KINDID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave);
                }
            }
            else if (typeof(T).Name == "DOCUMENT")
            {
                if (masterObj.GetType().BaseType.Name == "PERSON")
                {
                    int _personId = Convert.ToInt32(Reflection.GetValue(masterObj, "PERSONID"));
                    DocumentSearchView _documentSearchView = new DocumentSearchView(egoEntities.DOCUMENT.Where(x => x.PERSONID == _personId).ToList());
                    _frmSlave.dataGridView.DataSource = _documentSearchView.DocumentSearchViews;
                    _frmSlave.dataGridView.Columns["DOCUMENTID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(_frmSlave);
                }
            }
        }


        private void SetEvent(FrmSlave _frmSlave)
        {
            _frmSlave.buttonAdd.Click += new System.EventHandler(buttonAdd_Click);
            _frmSlave.dataGridView.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
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
    }
}
