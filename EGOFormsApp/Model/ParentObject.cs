using DAL;
using EGOFormsApp.ViewModel;
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
                egoEntities.Entry(obj).State = EntityState.Deleted;
                egoEntities.SaveChanges();
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
        protected object GetObjectById(int _id, bool _master, string _slaveType, string _masterType)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    FAMILY family = null;
                    if (_id == 0)
                    {
                        family = egoEntities.FAMILY.FirstOrDefault();
                    }else
                    {
                        family = egoEntities.FAMILY.FirstOrDefault(x => x.FAMILYID == _id);
                    }
                    return family == null ? new FAMILY() : family;
                case "PERSON":
                    PERSON person = null;
                    if (_master)
                    {
                        person = _id == 0 ? egoEntities.PERSON.FirstOrDefault() : egoEntities.PERSON.FirstOrDefault(x => x.PERSONID == _id);
                    }
                    else
                    {
                        if (_masterType == "GYMGROUP")
                        {
                            PERSON_GYMGROUP person_gymGroup = new PERSON_GYMGROUP();
                            person_gymGroup = _id == 0 ? egoEntities.PERSON_GYMGROUP.FirstOrDefault() : egoEntities.PERSON_GYMGROUP.FirstOrDefault(x => x.PERSON_GYMGROUP_ID == _id);
                            return person_gymGroup == null ? new PERSON_GYMGROUP() : person_gymGroup;
                        }
                        else if (_masterType == "FAMILY")
                        {
                            person = _id == 0 ? egoEntities.PERSON.FirstOrDefault() : egoEntities.PERSON.FirstOrDefault(x => x.PERSONID == _id);
                        }
                    }
                    return person == null ? new PERSON() : person;
                case "PHONE":
                    PHONE Phone = null;
                    Phone = _id == 0 ? egoEntities.PHONE.FirstOrDefault() : egoEntities.PHONE.FirstOrDefault(x => x.PHONEID == _id);
                    return Phone == null ? new PHONE() : Phone;
                case "DISCOUNT":
                    DISCOUNT Discount = null;
                    Discount = _id == 0 ? egoEntities.DISCOUNT.FirstOrDefault() : egoEntities.DISCOUNT.FirstOrDefault(x => x.DISCOUNTID == _id);
                    return Discount == null ? new DISCOUNT() : Discount;
                case "PAYMENT":
                    PAYMENT Payment = null;
                    Payment = _id == 0 ? egoEntities.PAYMENT.FirstOrDefault() : egoEntities.PAYMENT.FirstOrDefault(x => x.PAYMENTID == _id);
                    return Payment == null ? new PAYMENT() : Payment ;
                case "DOCUMENT":
                    DOCUMENT Document = null;
                    Document = _id == 0 ? egoEntities.DOCUMENT.FirstOrDefault() : egoEntities.DOCUMENT.FirstOrDefault(x => x.DOCUMENTID == _id);
                    return Document == null ? new DOCUMENT() : Document;
                case "GYMGROUP":
                    if (_master)
                    {
                        GYMGROUP GymGroup = null;
                        GymGroup = _id == 0 ? egoEntities.GYMGROUP.FirstOrDefault() : egoEntities.GYMGROUP.FirstOrDefault(x => x.GYMGROUPID == _id);
                        return GymGroup == null ? new GYMGROUP() : GymGroup;
                    }
                    else
                    {
                        PERSON_GYMGROUP Person_GymGroup = new PERSON_GYMGROUP();
                        Person_GymGroup = _id == 0 ? egoEntities.PERSON_GYMGROUP.FirstOrDefault() : egoEntities.PERSON_GYMGROUP.First(x => x.PERSON_GYMGROUP_ID == _id);
                        return Person_GymGroup == null ? new PERSON_GYMGROUP() : Person_GymGroup;
                    }
            }

            return null;
        }
    }
}
