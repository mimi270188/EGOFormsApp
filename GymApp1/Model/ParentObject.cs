using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp1.Model
{
    public abstract class ParentObject<T> where T : class
    {
        public EGOEntities egoEntities;

        protected void Add() {
            FrmAddEdit _frmAddEdit = new FrmAddEdit(egoEntities, typeof(T));
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

    }
}
