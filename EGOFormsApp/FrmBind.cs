using DAL;
using EGOFormsApp.Common;
using EGOFormsApp.Model;
using EGOFormsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGOFormsApp
{
    public partial class FrmBind : Form
    {
        private Type type;
        private int currentChildId = 0;
        private object masterObj;
        private EGOEntities egoEntities;
        public FrmBind(object _masterObj, Type _type, EGOEntities _egoEntities)
        {
            InitializeComponent();
            type = _type;
            masterObj = _masterObj;
            egoEntities = _egoEntities;
            CreateStructure(_masterObj, _type, _egoEntities);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void CreateStructure(object _masterObj, Type _type, EGOEntities _egoEntities)
        {
            int _personId;
            var dataGridViewButtonColumn = new DataGridViewButtonColumn();

            switch (_type.Name)
            {
                case "KIND":
                    textBoxParent.Text = Reflection.GetValue(_masterObj, "LASTNAME").ToString() + " " + Reflection.GetValue(_masterObj, "FIRSTNAME").ToString();
                    _personId = Convert.ToInt32(Reflection.GetValue(_masterObj, "PERSONID"));
                    KindSearchView _kindSearchView = new KindSearchView(_egoEntities.KIND.ToList());
                    dataGridView.DataSource = _kindSearchView.KindSearchViews;
                    dataGridView.Columns["KINDID"].Visible = false;

                    dataGridViewButtonColumn.Name = "Select";
                    dataGridViewButtonColumn.HeaderText = "Choix";
                    dataGridViewButtonColumn.Text = "Choisir";
                    dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

                    dataGridView.Columns.Add(dataGridViewButtonColumn);
                    break;
                case "GYMGROUP":
                    textBoxParent.Text = Reflection.GetValue(_masterObj, "LASTNAME").ToString() + " " + Reflection.GetValue(_masterObj, "FIRSTNAME").ToString();
                    _personId = Convert.ToInt32(Reflection.GetValue(_masterObj, "PERSONID"));
                    GymGroupSearchView _gymGroupSearchView = new GymGroupSearchView(_egoEntities.GYMGROUP.ToList());
                    dataGridView.DataSource = _gymGroupSearchView.GymGroupSearchViews;
                    dataGridView.Columns["GYMGROUPID"].Visible = false;

                    dataGridViewButtonColumn.Name = "Select";
                    dataGridViewButtonColumn.HeaderText = "Choix";
                    dataGridViewButtonColumn.Text = "Choisir";
                    dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

                    dataGridView.Columns.Add(dataGridViewButtonColumn);
                    break;
                case "PERSON":
                    textBoxParent.Text = Reflection.GetValue(_masterObj, "GYMGROUPYEAR").ToString() + " " + Reflection.GetValue(_masterObj, "GYMGROUPNAME").ToString();
                    int _gymGroupId = Convert.ToInt32(Reflection.GetValue(_masterObj, "GYMGROUPID"));
                    PersonSearchView _personSearchView = new PersonSearchView(_egoEntities.PERSON.ToList());
                    dataGridView.DataSource = _personSearchView.PersonSearchViews;
                    dataGridView.Columns["PERSONID"].Visible = false;

                    dataGridViewButtonColumn.Name = "Select";
                    dataGridViewButtonColumn.HeaderText = "Choix";
                    dataGridViewButtonColumn.Text = "Choisir";
                    dataGridViewButtonColumn.UseColumnTextForButtonValue = true;

                    dataGridView.Columns.Add(dataGridViewButtonColumn);
                    break;
                default:
                    break;
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.Columns[e.ColumnIndex].Name == "Select")
            {
                currentChildId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[1].Value);
                switch (type.Name)
                {
                    case "KIND":
                        textBoxChild.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        break;
                    case "GYMGROUP":
                        textBoxChild.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        break;
                    case "PERSON":
                        textBoxChild.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() + "-" + dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (currentChildId == 0)
            {
                MessageBox.Show("Merci de choisir avant d'enregistrer");
                return;
            }
            PERSON_GYMGROUP person_GymGroup;
            switch (type.Name)
            {
                case "KIND":
                    PERSON_KIND person_Kind = new PERSON_KIND();
                    person_Kind.PERSONID = Convert.ToInt32(Reflection.GetValue(masterObj, "PERSONID"));
                    person_Kind.KINDID = currentChildId;

                    egoEntities.PERSON_KIND.Add(person_Kind);
                    break;
                case "GYMGROUP":
                    person_GymGroup = new PERSON_GYMGROUP();
                    person_GymGroup.PERSONID = Convert.ToInt32(Reflection.GetValue(masterObj, "PERSONID"));
                    person_GymGroup.GYMGROUPID = currentChildId;

                    egoEntities.PERSON_GYMGROUP.Add(person_GymGroup);
                    break;
                case "PERSON":
                    person_GymGroup = new PERSON_GYMGROUP();
                    person_GymGroup.PERSONID = currentChildId;
                    person_GymGroup.GYMGROUPID = Convert.ToInt32(Reflection.GetValue(masterObj, "GYMGROUPID"));

                    egoEntities.PERSON_GYMGROUP.Add(person_GymGroup);
                    break;
                default:
                    break;
            }
            egoEntities.SaveChanges();
            this.Dispose();
            this.Close();
        }
    }
}
