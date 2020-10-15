using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        protected void Add(object obj)
        {
            FrmAddEdit _frmAddEdit = new FrmAddEdit(egoEntities, typeof(T), obj);
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

        protected void AddColumnEditDeleteToDataGridView(Form frm)
        {
            var dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Name = "Edit";
            dataGridViewButtonColumn.HeaderText = "Modification";
            dataGridViewButtonColumn.Text = "Modifier";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

            frm.Controls.OfType<DataGridView>().First().Columns.Add(dataGridViewButtonColumn);

            dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Name = "Delete";
            dataGridViewButtonColumn.HeaderText = "Suppression";
            dataGridViewButtonColumn.Text = "Supprimer";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

            frm.Controls.OfType<DataGridView>().First().Columns.Add(dataGridViewButtonColumn);
        }
        protected object GetObjectById(int id)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    return id == 0 ? egoEntities.FAMILY.First() : egoEntities.FAMILY.First(x => x.FAMILYID == id);
                    break;
                case "PERSON":
                    return id == 0 ? egoEntities.PERSON.First() : egoEntities.PERSON.First(x => x.PERSONID == id);
                    break;
                case "PHONE":
                    return id == 0 ? egoEntities.PHONE.First() : egoEntities.PHONE.First(x => x.PHONEID == id);
                    break;
                case "DISCOUNT":
                    return id == 0 ? egoEntities.DISCOUNT.First() : egoEntities.DISCOUNT.First(x => x.DISCOUNTID == id);
                    break;
                case "PAYMENT":
                    return id == 0 ? egoEntities.PAYMENT.First() : egoEntities.PAYMENT.First(x => x.PAYMENTID == id);
                case "KIND":
                    return id == 0 ? egoEntities.PERSON_KIND.First() : egoEntities.PERSON_KIND.First(x => x.PERSON_KIND_ID == id);
                case "DOCUMENT":
                    return id == 0 ? egoEntities.DOCUMENT.First() : egoEntities.DOCUMENT.First(x => x.DOCUMENTID == id);
                    break;
                    break;
            }
            return null;
        }
    }
}
