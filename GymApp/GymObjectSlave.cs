using DAL;
using GymApp.Common;
using GymApp.Commun.Control;
using GymApp.ViewModel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{ 
    public class GymObjectSlave<T> where T: class
    {
        System.Windows.Forms.Form _Frm;
        EGOEntities _egoEntities = new EGOEntities();
        List<string> _tables = new List<string>() { "FAMILYID", "PERSONID" };
        bool _IsUpdating = false;
        object _EditObject;
        bool _Master = false;
        List<object> _GymObjects;
        private object currentObject;
        public object CurrentObject
        {
            get
            { 
                return currentObject;
            }
            set
            {
                currentObject = value;
                RefreshDataGridView(_Frm);
            }
        }

        public GymObjectSlave(FrmMain frmMain, object slaveObj = null)
        {

            currentObject = slaveObj;
            _Frm = new FrmSlave() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            SetPanel(frmMain);
            _Frm.Show();
            


            SetEvent(_Master, _Frm);
            RefreshDataGridView(_Frm);

            if (_Master)
            {
                SetChild(frmMain, _Frm);
            }
        }

        private void HideConrols(System.Windows.Forms.Form frm)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    Label label1 = (Label)_Frm.Controls.Find("label1", false).First();
                    label1.Visible = false;
                    NumericUpDown numericUpDown1 = (NumericUpDown)_Frm.Controls.Find("numericUpDown1", false).First();
                    numericUpDown1.Visible = false;
                    Label label2 = (Label)_Frm.Controls.Find("label2", false).First();
                    label2.Text = "Nom:";
                    break;
            }
        }
        private void RefreshDataGridView(System.Windows.Forms.Form frm)
        {
            frm.Controls.OfType<DataGridView>().First().Columns.Clear();
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    string lastName = frm.Controls.OfType<TextBox>().First().Text;
                    FamilySearchView FamilySearchView = new FamilySearchView(_egoEntities.FAMILY.Where(x => x.LASTNAME.Contains(lastName)).ToList());
                    frm.Controls.OfType<DataGridView>().First().DataSource = FamilySearchView.FamilySearchViews;
                    frm.Controls.OfType<DataGridView>().First().Columns["FAMILYID"].Visible = false;
                    AddColumnEditDeleteToDataGridView(frm);
                    break;
                case "PERSON":
                    if (!_Master)
                    {
                        int familyId = Convert.ToInt32(Reflection.GetValue(currentObject, "FAMILYID"));
                        PersonSearchView PersonSearchView = new PersonSearchView(_egoEntities.PERSON.Where(x => x.FAMILYID == familyId).ToList());
                        frm.Controls.OfType<DataGridView>().First().DataSource = PersonSearchView.PersonSearchViews;
                        frm.Controls.OfType<DataGridView>().First().Columns["PERSONID"].Visible = false;
                        AddColumnEditDeleteToDataGridView(frm);
                    }
                    break;
            }

        }
        private void EditById(int id)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    FAMILY family = _egoEntities.FAMILY.First(x => x.FAMILYID == id);
                    _EditObject = family;
                    System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
                    frm.Text = "Modification";
                    frm.Height = 600;
                    frm.Width = 600;
                    CreateEditForm(frm, family);
                    frm.ShowDialog();
                    _EditObject = null;
                    RefreshDataGridView(_Frm);
                    break;
            }
        }
        private void RemoveById(int id)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    FAMILY family = _egoEntities.FAMILY.First(x => x.FAMILYID == id);
                    _egoEntities.FAMILY.Remove(family);
                    break;
            }
            _egoEntities.SaveChanges();
        }
        private void SetChild(FrmMain frmMain, System.Windows.Forms.Form frm)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    _GymObjects = new List<object>();
                    //_GymObjects.Add(new GymObject<PERSON>(frmMain, GetCurrentObjectById(frm)));

                    break;
            }
        }
        private object GetCurrentObjectById(System.Windows.Forms.Form frm)
        {
            DataGridView dataGridView = frm.Controls.OfType<DataGridView>().First();
            if (dataGridView.Rows.Count == 0)
            {
                return null;
            }
            int id;
            if (dataGridView.CurrentCell == null)
            {
                id = Convert.ToInt32(dataGridView.Rows[0].Cells[0].Value);
            }
            else
            {
                id = Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[2].Value);
            }
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    return _egoEntities.FAMILY.First(x => x.FAMILYID == id);             
                    break;
            }
            return null;
        }
        private void UpdateChild(int id)
        {
            switch (typeof(T).Name)
            {
                case "FAMILY":
                    FAMILY family = _egoEntities.FAMILY.First(x => x.FAMILYID == id);
                    var GymObjectPerson = _GymObjects[0];
                    Reflection.SetValue(ref GymObjectPerson, "CurrentObject", family);
                    break;
            }
        }


        private void SetPanel(FrmMain frmMain)
        {
            bool findPanel = false;
            foreach (Panel panel in frmMain.Controls.OfType<Panel>())
            {
                if (!findPanel && panel.Controls.Count == 0)
                {
                    findPanel = true;
                    panel.Controls.Add(_Frm);
                }
            }
        }
        private void SetEvent(bool master, System.Windows.Forms.Form frm)
        {
            Button button;

            if (master)
            {
                button = (Button)_Frm.Controls.Find("buttonSearch", false).First();
                button.Click += new System.EventHandler(this.buttonSearch_Click);
            }
            DataGridView dataGridView = (DataGridView)_Frm.Controls.Find("dataGridView1", false).First();
            dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            button = (Button)_Frm.Controls.Find("buttonAdd", false).First();
            button.Click += new System.EventHandler(this.buttonAdd_Click);
        }
        private void AddColumnEditDeleteToDataGridView(System.Windows.Forms.Form frm)
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
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
            frm.Text = "Création";
            frm.Height = 600;
            frm.Width = 600;
            CreateEditForm(frm);
            frm.ShowDialog();
            RefreshDataGridView(_Frm);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(_Frm);
        }
        public void CreateEditForm(System.Windows.Forms.Form frm, object obj = null)
        {
            int y = 30;
            int x = 10;
            Type type = typeof(T);
            RemoveAllControls(frm);

            if (obj != null) { _IsUpdating = true; } else { _IsUpdating = false; }

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.Name != type.Name + "ID" && prop.Name != "FAMILY" && prop.Name != "KIND")
                {
                    if (prop.PropertyType.Name == "String" ||
                        prop.PropertyType.Name == "Int32" ||
                        prop.PropertyType.Name == "Single" ||
                        prop.PropertyType.GenericTypeArguments[0].Name == "DateTime" ||
                        prop.PropertyType.GenericTypeArguments[0].Name == "Single")
                    {
                        Label label = new Label();
                        label.Text = Translation.GetByKey(prop.Name) + ":";
                        label.Location = new Point(x, y);
                        y = y + 24;
                        frm.Controls.Add(label);
                    }

                    if (prop.PropertyType.Name == "String")
                    {
                        TextBox textBox = new TextBox();
                        textBox.Width = 150;
                        textBox.Name = prop.Name;
                        if (obj != null) { textBox.Text = obj.GetType().GetProperty(prop.Name).GetValue(obj, null).ToString(); }
                        textBox.Location = new Point(x, y);
                        textBox.Enter += new System.EventHandler(this.textBox_Enter);
                        y = y + 24;
                        frm.Controls.Add(textBox);
                    }
                    else if (prop.PropertyType.Name == "Int32")
                    {
                        if (_tables.Contains(prop.Name))
                        {
                            frm.Controls.Add(CreateCombobox(prop.Name, ref x, ref y, obj));
                        }
                        else
                        {
                            NumericUpDown numericUpDown = new NumericUpDown();
                            numericUpDown.Width = 100;
                            numericUpDown.Maximum = 3000;
                            numericUpDown.Name = prop.Name;
                            if (obj != null) { numericUpDown.Value = Convert.ToDecimal(obj.GetType().GetProperty(prop.Name).GetValue(obj, null)); }
                            numericUpDown.Location = new Point(x, y);
                            y = y + 24;
                            frm.Controls.Add(numericUpDown);
                        }
                    }
                    else if (prop.PropertyType.Name == "Single")
                    {
                        NumericUpDown numericUpDown = new NumericUpDown();
                        numericUpDown.Width = 100;
                        numericUpDown.DecimalPlaces = 2;
                        numericUpDown.Maximum = 3000;
                        numericUpDown.Name = prop.Name;
                        if (obj != null) { numericUpDown.Value = Convert.ToDecimal(obj.GetType().GetProperty(prop.Name).GetValue(obj, null)); }
                        numericUpDown.Location = new Point(x, y);
                        y = y + 24;
                        frm.Controls.Add(numericUpDown);
                    }
                    else if (prop.PropertyType.GenericTypeArguments[0].Name == "DateTime")
                    {
                        DateTimePicker dateTimePicker = new DateTimePicker();
                        dateTimePicker.Name = prop.Name;
                        if (obj != null) { dateTimePicker.Value = (DateTime)obj.GetType().GetProperty(prop.Name).GetValue(obj, null); }
                        dateTimePicker.Format = DateTimePickerFormat.Short;
                        dateTimePicker.Location = new Point(x, y);
                        y = y + 24;
                        frm.Controls.Add(dateTimePicker);
                    }
                    else if (prop.PropertyType.GenericTypeArguments[0].Name == "Single")
                    {
                        NumericUpDown numericUpDown = new NumericUpDown();
                        numericUpDown.Width = 100;
                        numericUpDown.DecimalPlaces = 2;
                        numericUpDown.Maximum = 3000;
                        numericUpDown.Name = prop.Name;
                        if (obj != null) { numericUpDown.Value = Convert.ToDecimal(obj.GetType().GetProperty(prop.Name).GetValue(obj, null)); }
                        numericUpDown.Location = new Point(x, y);
                        y = y + 24;
                        frm.Controls.Add(numericUpDown);
                    }
                }
            }

            Button button = new Button();
            button.Location = new Point(x, y);
            button.Click += new System.EventHandler(this.buttonSave_Click);
            button.Text = "Enregistrer";
            frm.Controls.Add(button);
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save((System.Windows.Forms.Form)((Button)sender).Parent);
        }
        private void Save(System.Windows.Forms.Form frm)
        {
            try
            {
                Type type = typeof(T);
                object obj;
                if (_EditObject == null)
                {
                    obj = Activator.CreateInstance(type);
                }
                else
                {
                    obj = _EditObject;
                }

                foreach (Control control in frm.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        if (obj.GetType().GetProperties().ToList().Any(x => x.Name.Contains(textBox.Name)))
                        {
                            PropertyInfo prop = obj.GetType().GetProperties().ToList().First(x => x.Name.Contains(textBox.Name));
                            prop.SetValue(obj, textBox.Text);
                        }
                    }
                    else if (control is NumericUpDown)
                    {
                        NumericUpDown numericUpDown = (NumericUpDown)control;
                        if (obj.GetType().GetProperties().ToList().Any(x => x.Name.Contains(numericUpDown.Name)))
                        {
                            PropertyInfo prop = obj.GetType().GetProperties().ToList().First(x => x.Name.Contains(numericUpDown.Name));
                            if (prop.PropertyType.Name == "Int32")
                            {
                                prop.SetValue(obj, Decimal.ToInt32(numericUpDown.Value));
                            }
                            else if (prop.PropertyType.Name == "Single")
                            {
                                prop.SetValue(obj, Decimal.ToSingle(numericUpDown.Value));
                            }
                            else if (prop.PropertyType.GenericTypeArguments[0].Name == "Single")
                            {
                                prop.SetValue(obj, Decimal.ToSingle(numericUpDown.Value));
                            }
                            else
                            {
                                MessageBox.Show(prop.PropertyType.Name);
                            }
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)control;
                        if (obj.GetType().GetProperties().ToList().Any(x => x.Name.Contains(comboBox.Name)))
                        {
                            PropertyInfo prop = obj.GetType().GetProperties().ToList().First(x => x.Name.Contains(comboBox.Name));
                            prop.SetValue(obj, ((ComboboxItem)comboBox.SelectedItem).Value);
                        }
                    }
                    else if (control is DateTimePicker)
                    {
                        DateTimePicker dateTimePicker = (DateTimePicker)control;
                        if (obj.GetType().GetProperties().ToList().Any(x => x.Name.Contains(dateTimePicker.Name)))
                        {
                            PropertyInfo prop = obj.GetType().GetProperties().ToList().First(x => x.Name.Contains(dateTimePicker.Name));
                            prop.SetValue(obj, dateTimePicker.Value);
                        }
                    }
                }
                if (!_IsUpdating)
                {
                    _egoEntities.Set(type).Add(obj);
                }
                _egoEntities.SaveChanges();

                MessageBox.Show(Translation.GetByKey("Enregistrer"));
                if (_EditObject == null)
                {
                    RemoveAllControls(frm);
                    CreateEditForm(frm);
                }
                else
                {
                    frm.Dispose();
                    frm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void RemoveAllControls(System.Windows.Forms.Form frm)
        {
            List<Control> controls = new List<Control>();
            foreach (Control control in frm.Controls)
            {
                if (!(control is MenuStrip) & !(control is Panel))
                {
                    controls.Add(control);
                }
            }
            foreach (Control control in controls)
            {
                frm.Controls.Remove(control);
            }
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            var currentTextBox = sender as TextBox;
            currentTextBox.SelectionStart = currentTextBox.TextLength;
        }
        private ComboBox CreateCombobox(string propName, ref int x, ref int y, object obj)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Name = propName;
            comboBox.Location = new Point(x, y);
            comboBox.Width = 400;
            y = y + 24;

            if (propName == "FAMILYID")
            {
                List<FAMILY> familys = new List<FAMILY>();
                familys = _egoEntities.FAMILY.ToList();
                int i = 0;
                foreach (var family in familys)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = family.LASTNAME + " - " + family.ADDRESS + " " + family.ZIPCODE + " " + family.CITY;
                    item.Value = family.FAMILYID;

                    comboBox.Items.Add(item);
                    if (obj != null && family.FAMILYID == (int)obj.GetType().GetProperty(propName).GetValue(obj, null))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    i++;
                }
            }

            return comboBox;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                RemoveById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value));
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                EditById(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value));
            }else
            {
                UpdateChild(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
            }
            RefreshDataGridView(_Frm);
        }
    }
}
