using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using EGOFormsApp.Commun.Control;

namespace EGOFormsApp.Person
{
    public partial class FrmPersonCreationEdit : Form
    {
        private List<FAMILY> _familys;
        private List<KIND> _kinds;
        private PERSON _person;
        private bool _isUpdating = false;
        public FrmPersonCreationEdit(string FrmName = "Personn")
        {
            InitializeComponent();
            this.Text = FrmName;
        }

        public FrmPersonCreationEdit(PERSON person, string FrmName = "Personn")
        {
            InitializeComponent();
            _person = person;
            _isUpdating = true;

            this.Text = FrmName;
            textBoxLastName.Text = person.LASTNAME;
            textBoxFirstName.Text = person.FIRSTNAME;
            dateTimePickerBirthDate.Value = (DateTime)person.BIRTHDATE;
            numericUpDownHourlyRate.Value = (decimal)person.HOURLYRATE;

            FillComboBox();
        }

        private void FrmPersonCreationEdit_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                EGOEntities egoEntities = new EGOEntities();
                PERSON person = new PERSON();

                if (_person == null)
                {
                    person.FAMILYID = _familys[comboBoxFamily.SelectedIndex].FAMILYID;
                }
                person.LASTNAME = textBoxLastName.Text;
                person.FIRSTNAME = textBoxFirstName.Text;
                person.BIRTHDATE = dateTimePickerBirthDate.Value;
                person.HOURLYRATE = (float)numericUpDownHourlyRate.Value;

                if (!_isUpdating)
                {
                    egoEntities.PERSON.Add(person);
                }
                egoEntities.SaveChanges();

                MessageBox.Show("Enregistrer");

                CleanAllControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void CleanAllControl()
        {
            FillComboBox();
            textBoxLastName.Text = string.Empty;
            textBoxFirstName.Text = string.Empty;
            dateTimePickerBirthDate.Value = DateTime.Now;
            numericUpDownHourlyRate.Value = 0;
        }

        private void FillComboBox()
        {
            comboBoxFamily.Items.Clear();
            comboBoxFamily.Text = string.Empty;
            comboBoxKind.Items.Clear();
            comboBoxKind.Text = string.Empty;

            EGOEntities egoEntities = new EGOEntities();

            _familys = egoEntities.FAMILY.ToList();
            int i = 0;
            foreach (var family in _familys)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = family.LASTNAME + " - " + family.ADDRESS + " " + family.ZIPCODE + " " + family.CITY;
                item.Value = family.FAMILYID;

                comboBoxFamily.Items.Add(item);
                if (_person != null && family.FAMILYID == _person.FAMILYID)
                {
                    comboBoxFamily.SelectedIndex = i;
                }
                i++;
            }
           
        }
    }
}
