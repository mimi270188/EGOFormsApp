using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGOFormsApp.Model
{
    public abstract class ParentObject<T> where T : class
    {
        public EGOEntities egoEntities;

        protected void Add() {
            FrmAddEdit _frmAddEdit = new FrmAddEdit(egoEntities, typeof(T));
            _frmAddEdit.ShowDialog();
        }
        protected void Add(object objMaster)
        {
            FrmAddEdit _frmAddEdit = new FrmAddEdit(egoEntities, typeof(T), _objMaster:objMaster);
            _frmAddEdit.ShowDialog();
        }
        protected void Edit(object obj)
        {
            FrmAddEdit _frmAddEdit = new FrmAddEdit(egoEntities, typeof(T), obj);
            _frmAddEdit.ShowDialog();
        }
        protected void Delete(object obj)
        {
            try
            {
                egoEntities.Entry(obj).State = EntityState.Deleted;
                egoEntities.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Suppression impossible car quelque chose s'y rattache");
            }
        }

        protected void AddColumnEditDeleteToDataGridView(Form _frm, bool _bindTables)
        {
            var dataGridViewButtonColumn = new DataGridViewButtonColumn();
            if (!_bindTables)
            {
                dataGridViewButtonColumn.Name = "Edit";
                dataGridViewButtonColumn.HeaderText = "Modification";
                dataGridViewButtonColumn.Text = "Modifier";
                dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

                _frm.Controls.OfType<DataGridView>().First().Columns.Add(dataGridViewButtonColumn);
            }

            dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Name = "Delete";
            dataGridViewButtonColumn.HeaderText = "Suppression";
            dataGridViewButtonColumn.Text = "Supprimer";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

            _frm.Controls.OfType<DataGridView>().First().Columns.Add(dataGridViewButtonColumn);
        }
        protected object GetObjectById(int _id, bool _master = false)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    return _id == 0 ? egoEntities.FAMILY.First() : egoEntities.FAMILY.First(x => x.FAMILYID == _id);
                case "PERSON":
                    if (_master)
                    {
                        return _id == 0 ? egoEntities.PERSON.First() : egoEntities.PERSON.First(x => x.PERSONID == _id);
                    }
                    else
                    {
                        return _id == 0 ? egoEntities.PERSON_GYMGROUP.First() : egoEntities.PERSON_GYMGROUP.First(x => x.PERSON_GYMGROUP_ID == _id);
                    }
                case "PHONE":
                    return _id == 0 ? egoEntities.PHONE.First() : egoEntities.PHONE.First(x => x.PHONEID == _id);
                case "DISCOUNT":
                    return _id == 0 ? egoEntities.DISCOUNT.First() : egoEntities.DISCOUNT.First(x => x.DISCOUNTID == _id);
                case "PAYMENT":
                    return _id == 0 ? egoEntities.PAYMENT.First() : egoEntities.PAYMENT.First(x => x.PAYMENTID == _id);
                case "DOCUMENT":
                    return _id == 0 ? egoEntities.DOCUMENT.First() : egoEntities.DOCUMENT.First(x => x.DOCUMENTID == _id);
                case "KIND":
                    return _id == 0 ? egoEntities.PERSON_KIND.First() : egoEntities.PERSON_KIND.First(x => x.PERSON_KIND_ID == _id);
                case "GYMGROUP":
                    if (_master)
                    {
                        return _id == 0 ? egoEntities.GYMGROUP.First() : egoEntities.GYMGROUP.First(x => x.GYMGROUPID == _id);
                    }
                    else
                    {
                        return _id == 0 ? egoEntities.PERSON_GYMGROUP.First() : egoEntities.PERSON_GYMGROUP.First(x => x.PERSON_GYMGROUP_ID == _id);
                    }
            }
            return null;
        }
        protected void ColorFirstRow(FrmMaster _frmMaster)
        {
            _frmMaster.dataGridView.Rows[0].DefaultCellStyle.BackColor = Color.Blue;
            _frmMaster.dataGridView.Rows[0].DefaultCellStyle.ForeColor = Color.White;
        }
    }
}
