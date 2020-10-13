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
using EGO.Commun.Control;
using EGO.Controller;

namespace EGO.View.GymGroup
{
    public partial class FrmGymGroupBind : Form
    {
        EGOEntities _egoEntities;
        public FrmGymGroupBind()
        {
            InitializeComponent();
            numericUpDownGymGroupYear.Value = DateTime.Now.Year;
            _egoEntities = new EGOEntities();

            List<GYMGROUP> gymGroups = _egoEntities.GYMGROUP.Where(x => x.GYMGROUPYEAR == numericUpDownGymGroupYear.Value).ToList();
            foreach (var gymGroup in gymGroups)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = gymGroup.GYMGROUPNAME;
                item.Value = gymGroup.GYMGROUPID;

                comboBoxGymGroup.Items.Add(item);
            }

            List<PERSON> persons = _egoEntities.PERSON.ToList();
            foreach (var person in persons)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = person.LASTNAME + " " + person.FIRSTNAME + " " + person.BIRTHDATE.ToString() + person.FAMILY.ZIPCODE;
                item.Value = person.PERSONID;

                comboBoxPerson.Items.Add(item);
            }
        }

        private void buttonBind_Click(object sender, EventArgs e)
        {
            PERSON_GYMGROUP person_GymGroup = new PERSON_GYMGROUP();
            person_GymGroup.GYMGROUPID = ((ComboboxItem)comboBoxGymGroup.SelectedItem).Value;
            person_GymGroup.PERSONID = ((ComboboxItem)comboBoxPerson.SelectedItem).Value;
            _egoEntities.PERSON_GYMGROUP.Add(person_GymGroup);
            _egoEntities.SaveChanges();
        }
    }
}
