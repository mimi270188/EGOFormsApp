using DAL;
using EGOFormsApp.Common;
using EGOFormsApp.Commun.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EGOFormsApp
{
    public partial class FrmAddEdit : Form
    {
        private Type type;
        private object objSlave;
        private object objMaster;
        public EGOEntities egoEntities;
        private List<string> _tables = new List<string>() { "FAMILYID", "PERSONID", "PAYMENTTYPEID", "DOCUMENTTYPEID", "PERSONID" };

        public FrmAddEdit(EGOEntities _egoEntities, Type _type, object _objSlave = null, object _objMaster = null)
        {
            InitializeComponent();
            type = _type;
            objSlave = _objSlave;
            objMaster = _objMaster;
            egoEntities = _egoEntities;
            CreateEditForm(objSlave, objMaster);
        }

        public void CreateEditForm(object _objSlave, object _objMaster)
        {
            int y = 30;
            int x = 10;

            RemoveAllControls();

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.Name != type.Name + "ID" && prop.Name != "FAMILY" && prop.Name != "KIND" && prop.Name != "PAYMENTTYPE" && prop.Name != "DOCUMENTTYPE" && prop.Name != "PERSON")
                {
                    if (prop.PropertyType.Name == "String" ||
                        prop.PropertyType.Name == "Int32" ||
                        prop.PropertyType.Name == "Single" ||
                        prop.PropertyType.Name == "DateTime" ||
                        prop.PropertyType.GenericTypeArguments[0].Name == "DateTime" ||
                        prop.PropertyType.GenericTypeArguments[0].Name == "Single" ||
                        prop.PropertyType.GenericTypeArguments[0].Name == "Int32")
                    {
                        Label label = new Label();
                        label.Text = Translation.GetByKey(prop.Name) + ":";
                        label.Location = new Point(x, y);
                        y = y + 24;
                        this.Controls.Add(label);
                    }

                    if (prop.PropertyType.Name == "String" || (prop.PropertyType.GenericTypeArguments.Length > 0 && prop.PropertyType.GenericTypeArguments[0].Name == "String"))
                    {
                        TextBox textBox = new TextBox();
                        textBox.Width = 150;
                        textBox.Name = prop.Name;
                        if (_objSlave != null) { textBox.Text = _objSlave.GetType().GetProperty(prop.Name).GetValue(_objSlave, null).ToString(); }
                        textBox.Location = new Point(x, y);
                        textBox.Enter += new System.EventHandler(this.textBox_Enter);
                        y = y + 24;
                        this.Controls.Add(textBox);
                    }
                    else if (prop.PropertyType.Name == "Int32" || (prop.PropertyType.GenericTypeArguments.Length > 0 && prop.PropertyType.GenericTypeArguments[0].Name == "Int32"))
                    {
                        if (_tables.Contains(prop.Name))
                        {
                            this.Controls.Add(CreateCombobox(prop.Name, ref x, ref y, _objMaster, _objSlave));
                        }
                        else
                        {
                            NumericUpDown numericUpDown = new NumericUpDown();
                            numericUpDown.Width = 100;
                            numericUpDown.Maximum = 9999999;
                            numericUpDown.Name = prop.Name;
                            if (prop.Name.Contains("YEAR")){ numericUpDown.Value = DateTime.Now.Year; }
                            if (_objSlave != null) { numericUpDown.Value = Convert.ToDecimal(_objSlave.GetType().GetProperty(prop.Name).GetValue(_objSlave, null)); }
                            numericUpDown.Location = new Point(x, y);
                            y = y + 24;
                            this.Controls.Add(numericUpDown);
                        }
                    }
                    else if (prop.PropertyType.Name == "DateTime" || (prop.PropertyType.GenericTypeArguments.Length > 0 && prop.PropertyType.GenericTypeArguments[0].Name == "DateTime"))
                    {
                        DateTimePicker dateTimePicker = new DateTimePicker();
                        dateTimePicker.Name = prop.Name;
                        if (_objSlave != null) 
                        {
                            if (_objSlave.GetType().GetProperty(prop.Name).GetValue(_objSlave, null) == null)
                            {
                                dateTimePicker.Value = DateTime.Now;
                            }
                            else
                            {
                                dateTimePicker.Value = (DateTime)_objSlave.GetType().GetProperty(prop.Name).GetValue(_objSlave, null);
                            }
                        }
                        dateTimePicker.Format = DateTimePickerFormat.Short;
                        dateTimePicker.Location = new Point(x, y);
                        y = y + 24;
                        this.Controls.Add(dateTimePicker);
                    }
                    else if (prop.PropertyType.Name == "Single" || (prop.PropertyType.GenericTypeArguments.Length > 0 && prop.PropertyType.GenericTypeArguments[0].Name == "Single"))
                    {
                        NumericUpDown numericUpDown = new NumericUpDown();
                        numericUpDown.Width = 100;
                        numericUpDown.DecimalPlaces = 2;
                        numericUpDown.Maximum = 9999999;
                        numericUpDown.Name = prop.Name;
                        if (_objSlave != null) { numericUpDown.Value = Convert.ToDecimal(_objSlave.GetType().GetProperty(prop.Name).GetValue(_objSlave, null)); }
                        numericUpDown.Location = new Point(x, y);
                        y = y + 24;
                        this.Controls.Add(numericUpDown);
                    }
                }
            }

            Button button = new Button();
            button.Location = new Point(x, y);
            button.Click += new System.EventHandler(this.buttonSave_Click);
            button.Text = "Enregistrer";
            this.Controls.Add(button);
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save(objSlave, objMaster);
        }
        private void Save(object _objSlave, object _objMaster)
        {
            try
            {
                object _obj;
                if (_objSlave == null)
                {
                    _obj = Activator.CreateInstance(type);
                }
                else
                {
                    _obj = _objSlave;
                }

                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        if (_obj.GetType().GetProperties().ToList().Any(x => x.Name.Contains(textBox.Name)))
                        {
                            PropertyInfo prop = _obj.GetType().GetProperties().ToList().First(x => x.Name.Contains(textBox.Name));
                            prop.SetValue(_obj, textBox.Text);
                        }
                    }
                    else if (control is NumericUpDown)
                    {
                        NumericUpDown numericUpDown = (NumericUpDown)control;
                        if (_obj.GetType().GetProperties().ToList().Any(x => x.Name.Contains(numericUpDown.Name)))
                        {
                            PropertyInfo prop = _obj.GetType().GetProperties().ToList().First(x => x.Name.Contains(numericUpDown.Name));
                            if (prop.PropertyType.Name == "Int32" || (prop.PropertyType.GenericTypeArguments.Length > 0 && prop.PropertyType.GenericTypeArguments[0].Name == "Int32"))
                            {
                                prop.SetValue(_obj, Decimal.ToInt32(numericUpDown.Value));
                            }
                            else if (prop.PropertyType.Name == "Single" || (prop.PropertyType.GenericTypeArguments.Length > 0 && prop.PropertyType.GenericTypeArguments[0].Name == "Single"))
                            {
                                prop.SetValue(_obj, Decimal.ToSingle(numericUpDown.Value));
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
                        if (_obj.GetType().GetProperties().ToList().Any(x => x.Name.Contains(comboBox.Name)))
                        {
                            PropertyInfo prop = _obj.GetType().GetProperties().ToList().First(x => x.Name.Contains(comboBox.Name));
                            prop.SetValue(_obj, ((ComboboxItem)comboBox.SelectedItem).Value);
                        }
                    }
                    else if (control is DateTimePicker)
                    {
                        DateTimePicker dateTimePicker = (DateTimePicker)control;
                        if (_obj.GetType().GetProperties().ToList().Any(x => x.Name.Contains(dateTimePicker.Name)))
                        {
                            PropertyInfo prop = _obj.GetType().GetProperties().ToList().First(x => x.Name.Contains(dateTimePicker.Name));
                            prop.SetValue(_obj, dateTimePicker.Value);
                        }
                    }
                }
                if (_objSlave == null)
                {
                    egoEntities.Set(type).Add(_obj);
                }
                egoEntities.SaveChanges();

                if (_objSlave == null)
                {
                    MessageBox.Show(Translation.GetByKey("Enregistrer"));
                    RemoveAllControls();
                    CreateEditForm(_objSlave, _objMaster);
                }
                else
                {
                    this.Dispose();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void RemoveAllControls()
        {
            List<Control> controls = new List<Control>();
            foreach (Control control in this.Controls)
            {
                if (!(control is MenuStrip) & !(control is Panel))
                {
                    controls.Add(control);
                }
            }
            foreach (Control control in controls)
            {
                this.Controls.Remove(control);
            }
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            var currentTextBox = sender as TextBox;
            currentTextBox.SelectionStart = currentTextBox.TextLength;
        }

        private ComboBox CreateCombobox(string propName, ref int x, ref int y, object _objMaster, object _objSlave)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Name = propName;
            comboBox.Location = new Point(x, y);
            comboBox.Width = 400;
            y = y + 24;

            if (propName == "FAMILYID")
            {
                List<FAMILY> familys = new List<FAMILY>();
                familys = egoEntities.FAMILY.ToList().OrderBy(a => a.LASTNAME).ToList();
                int i = 0;
                foreach (var family in familys)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = family.LASTNAME + " - " + family.ADDRESS + " " + family.ZIPCODE + " " + family.CITY;
                    item.Value = family.FAMILYID;

                    comboBox.Items.Add(item);
                    if (_objMaster != null && _objMaster.GetType().GetProperty(propName) != null && family.FAMILYID == (int)Reflection.GetValue(_objMaster, propName))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    else if (_objSlave != null && _objSlave.GetType().GetProperty(propName) != null && family.FAMILYID == (int)Reflection.GetValue(_objSlave, propName))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    i++;
                }
            }
            if (propName == "PAYMENTTYPEID")
            {
                List<PAYMENTTYPE> paymentTypes = new List<PAYMENTTYPE>();
                paymentTypes = egoEntities.PAYMENTTYPE.ToList();
                int i = 0;
                foreach (var paymentType in paymentTypes)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = paymentType.NAME;
                    item.Value = paymentType.PAYMENTTYPEID;

                    comboBox.Items.Add(item);
                    if (_objMaster != null && _objMaster.GetType().GetProperty(propName) != null && paymentType.PAYMENTTYPEID == (int)Reflection.GetValue(_objMaster, propName))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    else if (_objSlave != null && _objSlave.GetType().GetProperty(propName) != null && paymentType.PAYMENTTYPEID == (int)Reflection.GetValue(_objSlave, propName))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    i++;
                }
            }
            if (propName == "DOCUMENTTYPEID")
            {
                List<DOCUMENTTYPE> documentTypes = new List<DOCUMENTTYPE>();
                documentTypes = egoEntities.DOCUMENTTYPE.ToList();
                int i = 0;
                foreach (var documentType in documentTypes)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = documentType.DOCUMENTNAME;
                    item.Value = documentType.DOCUMENTTYPEID;

                    comboBox.Items.Add(item);
                    if (_objMaster != null && _objMaster.GetType().GetProperty(propName) != null && documentType.DOCUMENTTYPEID == (int)Reflection.GetValue(_objMaster, propName))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    else if (_objSlave != null && _objSlave.GetType().GetProperty(propName) != null && documentType.DOCUMENTTYPEID == (int)Reflection.GetValue(_objSlave, propName))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    i++;
                }
            }
            if (propName == "PERSONID")
            {
                List<PERSON> persons = new List<PERSON>();
                persons = egoEntities.PERSON.ToList().OrderBy(a => a.LASTNAME).ToList();
                int i = 0;
                foreach (var person in persons)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = person.LASTNAME + " " + person.FIRSTNAME + " " + person.FAMILY.CITY;
                    item.Value = person.PERSONID;

                    comboBox.Items.Add(item);
                    if (_objMaster != null && _objMaster.GetType().GetProperty(propName) != null && person.PERSONID == (int)Reflection.GetValue(_objMaster, propName))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    else if (_objSlave != null && _objSlave.GetType().GetProperty(propName) != null && person.PERSONID == (int)Reflection.GetValue(_objSlave, propName))
                    {
                        comboBox.SelectedIndex = i;
                    }
                    i++;
                }
            }

            return comboBox;
        }
    }
}