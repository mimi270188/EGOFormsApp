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
        private List<FAMILY> familys;
        private List<KIND> kinds;
        private FAMILY family;
        public FrmPersonCreationEdit()
        {
            InitializeComponent();
        }

        public FrmPersonCreationEdit(FAMILY _family)
        {
            InitializeComponent();
            family = _family;
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

                if (family != null)
                {
                    person.FAMILYID = family.FAMILYID;
                }
                else
                {
                    person.FAMILYID = familys[comboBoxFamily.SelectedIndex].FAMILYID;
                }
                person.KINDID = kinds[comboBoxKind.SelectedIndex].KINDID;
                person.LASTNAME = textBoxLastName.Text;
                person.FIRSTNAME = textBoxFirstName.Text;
                person.BIRTHDATE = dateTimePickerBirthDate.Value;
                person.HOURLYRATE = (float)numericUpDownHourlyRate.Value;

                egoEntities.PERSON.Add(person);
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
            if (family != null)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = family.LASTNAME + " - " + family.ADDRESS + " " + family.ZIPCODE + " " + family.CITY;
                item.Value = family.FAMILYID;

                comboBoxFamily.Items.Add(item);
                comboBoxFamily.SelectedIndex = 0;
            }
            else
            {
                familys = egoEntities.FAMILY.ToList();

                foreach (var family in familys)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = family.LASTNAME + " - " + family.ADDRESS + " " + family.ZIPCODE + " " + family.CITY;
                    item.Value = family.FAMILYID;

                    comboBoxFamily.Items.Add(item);
                }
            }

            kinds = egoEntities.KIND.ToList();

            foreach (var kind in kinds)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = kind.KINDNAME;
                item.Value = kind.KINDID;

                comboBoxKind.Items.Add(item);
            }
        }
    }
}
