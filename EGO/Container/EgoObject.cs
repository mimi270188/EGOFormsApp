using EGO.Common;
using EGO.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Security.Cryptography;
using System.Runtime.Remoting.Messaging;
using EGO.Commun.Control;

namespace EGO.Container
{
    abstract class EgoObject : IEgoObject
    {
        public Type _type { get; set; }
        private List<string> _tables = new List<string>() { "FAMILYID", "PERSONID" };
        private bool _IsUpdating = false;
        private EGOEntities _egoEntities;
        private object _obj;

        public void CreateEditForm(Form frm, EGOEntities egoEntities, object obj = null)
        {
            int y = 30;
            int x = 10;
            _egoEntities = egoEntities;
            _obj = obj;
            RemoveAllControls(frm);

            if(obj != null) { _IsUpdating = true; } else { _IsUpdating = false; }

            foreach (PropertyInfo prop in _type.GetProperties())
            {
                if (prop.Name != _type.Name + "ID" && prop.Name != "FAMILY" && prop.Name != "KIND")
                {
                    if (prop.PropertyType.Name == "String" || 
                        prop.PropertyType.Name == "Int32" ||
                        prop.PropertyType.Name == "Single" ||
                        prop.PropertyType.GenericTypeArguments[0].Name == "DateTime" || 
                        prop.PropertyType.GenericTypeArguments[0].Name == "Single")
                    {
                        Label label = new Label();
                        label.Text = Translation.GetByKey(prop.Name)+ ":";
                        label.Location = new Point(x, y);
                        y = y + 24;
                        frm.Controls.Add(label);
                    }

                    if (prop.PropertyType.Name == "String")
                    {
                        TextBox textBox = new TextBox();
                        textBox.Width = 150;
                        textBox.Name = prop.Name;
                        if (obj != null){ textBox.Text = obj.GetType().GetProperty(prop.Name).GetValue(obj, null).ToString(); }
                        textBox.Location = new Point(x, y);
                        textBox.Enter += new System.EventHandler(this.textBox_Enter);
                        y = y + 24;
                        frm.Controls.Add(textBox);
                    }
                    else if (prop.PropertyType.Name == "Int32")
                    {
                        if (_tables.Contains(prop.Name))
                        {
                            frm.Controls.Add(CreateCombobox(prop.Name, ref x, ref y, _obj));
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

        private void textBox_Enter(object sender, EventArgs e)
        {
            var currentTextBox = sender as TextBox;
            currentTextBox.SelectionStart = currentTextBox.TextLength;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save((Form)((Button)sender).Parent);
        }
        private void Save(Form frm)
        {
            try
            {
                object obj;
                if (_obj == null)
                {
                    obj = Activator.CreateInstance(_type);
                }
                else
                {
                    obj = _obj;
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
                    _egoEntities.Set(_type).Add(obj);
                }
                _egoEntities.SaveChanges();

                MessageBox.Show(Translation.GetByKey("Enregistrer"));
                if (_obj != null)
                {
                    frm.Dispose();
                    frm.Close();
                }
                else
                {
                    RemoveAllControls(frm);
                    CreateEditForm(frm, _egoEntities);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RemoveAllControls(Form frm)
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
    }
}
