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

namespace EGO.Container
{
    abstract class EgoObject : IEgoObject
    {
        public void CreateEditForm(Form frm, Type type)
        {
            int i = 30;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.Name != type.Name + "ID")
                {
                    if (prop.PropertyType.Name == "String")
                    {
                        Label label = new Label();
                        label.Text = Translation.GetByKey(prop.Name)+ ":";
                        label.Location = new Point(10, i);
                        i = i + 24;
                        frm.Controls.Add(label);
                        TextBox textBox = new TextBox();
                        textBox.Width = 100;
                        textBox.Name = prop.Name;
                        textBox.Location = new Point(10, i);
                        i = i + 24;
                        frm.Controls.Add(textBox);
                    }
                    else if (prop.PropertyType.Name == "Int32")
                    {
                        Label label = new Label();
                        label.Text = Translation.GetByKey(prop.Name) + ":";
                        label.Location = new Point(10, i);
                        i = i + 24;
                        frm.Controls.Add(label);
                        NumericUpDown numericUpDown = new NumericUpDown();
                        numericUpDown.Width = 100;
                        numericUpDown.Name = prop.Name;
                        numericUpDown.Location = new Point(10, i);
                        i = i + 24;
                        frm.Controls.Add(numericUpDown);
                    }
                }
            }
        }

        public void SearchFrom(Form frm)
        {
            throw new NotImplementedException();
        }
    }
}
