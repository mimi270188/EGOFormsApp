using EGOFormsApp.Common;
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
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
            textBox1.Text = @"C:\Users\mgrandiere.COMMANDALKON\Downloads\EGO 2020-2021.xlsx";
        }

        private void buttonDrop_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Database.Drop();
            MessageBox.Show("Suppression terminée");
            Cursor.Current = Cursors.Default;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Database.Create();
            MessageBox.Show("Création terminée");
            Cursor.Current = Cursors.Default;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Substring(textBox1.Text.Length - 5, 5) == ".xlsx")
            {
                Reader.ImportExcel(this, textBox1.Text);
            }
            else
            {
                MessageBox.Show("Merci de selectionner un fichier .xlsx");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.Substring(openFileDialog.FileName.Length - 5, 5) == ".xlsx")
            {
                textBox1.Text = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Merci de selectionner un fichier .xlsx");
            }
        }
    }
}
