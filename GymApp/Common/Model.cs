using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using GymApp.ViewModel;

namespace GymApp.Common
{
    public static class Model
    {
        public static void Search(ref DataGridView dataGridView, TextBox textBox, Type type, EGOEntities egoEntities)
        {
            dataGridView.Columns.Clear();
            switch (type.Name)
            {
                case "FAMILY":
                    string lastName = textBox.Text;
                    FamilySearchView FamilySearchView = new FamilySearchView(egoEntities.FAMILY.Where(x => x.LASTNAME.Contains(lastName)).ToList());
                    dataGridView.DataSource = FamilySearchView.FamilySearchViews;
                    dataGridView.Columns["FAMILYID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(ref dataGridView);
                    break;
                case "PERSON":
                    break;
            }
        }

        private static void AddColumnEditDeleteToDataGridView(ref DataGridView dataGridView)
        {
            var dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Name = "Edit";
            dataGridViewButtonColumn.HeaderText = "Modification";
            dataGridViewButtonColumn.Text = "Modifier";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

            dataGridView.Columns.Add(dataGridViewButtonColumn);

            dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Name = "Delete";
            dataGridViewButtonColumn.HeaderText = "Suppression";
            dataGridViewButtonColumn.Text = "Supprimer";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

            dataGridView.Columns.Add(dataGridViewButtonColumn);
        }

        public static void CellContentClickMaster(ref DataGridView dataGridView, TextBox textBox, Type type, EGOEntities egoEntities, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                RemoveById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value));
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                //EditById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value));
            }
            else
            {
                UpdateChild(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
            }
            Search(ref dataGridView, textBox, type, egoEntities);
        }

        private static void EditById(int id, Type type, EGOEntities egoEntities)
        {
            switch (type.Name)
            {
                case "FAMILY":
                    //FAMILY family = egoEntities.FAMILY.First(x => x.FAMILYID == id);
                    //System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
                    //frm.Text = "Modification";
                    //frm.Height = 600;
                    //frm.Width = 600;
                    //CreateEditForm(frm, family);
                    //frm.ShowDialog();
                    //_EditObject = null;
                    //RefreshDataGridView(_Frm);
                    break;
            }
        }
        private static void RemoveById(int id)
        {
            //switch (typeof(T).Name)
            //{
            //    case "FAMILY":
            //        FAMILY family = _egoEntities.FAMILY.First(x => x.FAMILYID == id);
            //        _egoEntities.FAMILY.Remove(family);
            //        break;
            //}
            //_egoEntities.SaveChanges();
        }

        private static void UpdateChild(int id)
        {
            //switch (typeof(T).Name)
            //{
            //    case "FAMILY":
            //        FAMILY family = _egoEntities.FAMILY.First(x => x.FAMILYID == id);
            //        var GymObjectPerson = _GymObjects[0];
            //        Reflection.SetValue(ref GymObjectPerson, "CurrentObject", family);
            //        break;
            //}
        }

    }
}
