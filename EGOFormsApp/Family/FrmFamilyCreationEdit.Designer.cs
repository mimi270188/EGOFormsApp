namespace EGOFormsApp.Family
{
    partial class FrmFamilyCreationEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSaveFamily = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.textBoxZipCode = new System.Windows.Forms.TextBox();
            this.labelZipCode = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePerson = new System.Windows.Forms.TabPage();
            this.buttonPersonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPagePhone = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagePerson.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveFamily
            // 
            this.buttonSaveFamily.Location = new System.Drawing.Point(662, 103);
            this.buttonSaveFamily.Name = "buttonSaveFamily";
            this.buttonSaveFamily.Size = new System.Drawing.Size(99, 23);
            this.buttonSaveFamily.TabIndex = 42;
            this.buttonSaveFamily.Text = "Enregistrer";
            this.buttonSaveFamily.UseVisualStyleBackColor = true;
            this.buttonSaveFamily.Click += new System.EventHandler(this.buttonSaveFamily_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(6, 75);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(257, 20);
            this.textBoxEmail.TabIndex = 41;
            this.textBoxEmail.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(3, 59);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 40;
            this.labelEmail.Text = "Email:";
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(626, 38);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(135, 20);
            this.textBoxCity.TabIndex = 39;
            this.textBoxCity.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(623, 22);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(29, 13);
            this.labelCity.TabIndex = 38;
            this.labelCity.Text = "Ville:";
            // 
            // textBoxZipCode
            // 
            this.textBoxZipCode.Location = new System.Drawing.Point(483, 38);
            this.textBoxZipCode.Name = "textBoxZipCode";
            this.textBoxZipCode.Size = new System.Drawing.Size(135, 20);
            this.textBoxZipCode.TabIndex = 37;
            this.textBoxZipCode.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // labelZipCode
            // 
            this.labelZipCode.AutoSize = true;
            this.labelZipCode.Location = new System.Drawing.Point(480, 22);
            this.labelZipCode.Name = "labelZipCode";
            this.labelZipCode.Size = new System.Drawing.Size(67, 13);
            this.labelZipCode.TabIndex = 36;
            this.labelZipCode.Text = "Code Postal:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(161, 38);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(316, 20);
            this.textBoxAddress.TabIndex = 35;
            this.textBoxAddress.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(158, 22);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 34;
            this.labelAddress.Text = "Adresse:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(6, 38);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(135, 20);
            this.textBoxLastName.TabIndex = 33;
            this.textBoxLastName.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(3, 22);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(32, 13);
            this.labelLastName.TabIndex = 32;
            this.labelLastName.Text = "Nom:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxLastName);
            this.groupBox1.Controls.Add(this.labelLastName);
            this.groupBox1.Controls.Add(this.labelAddress);
            this.groupBox1.Controls.Add(this.textBoxAddress);
            this.groupBox1.Controls.Add(this.labelZipCode);
            this.groupBox1.Controls.Add(this.buttonSaveFamily);
            this.groupBox1.Controls.Add(this.textBoxZipCode);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.labelCity);
            this.groupBox1.Controls.Add(this.labelEmail);
            this.groupBox1.Controls.Add(this.textBoxCity);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 140);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Famille";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagePerson);
            this.tabControl.Controls.Add(this.tabPagePhone);
            this.tabControl.Location = new System.Drawing.Point(12, 158);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 266);
            this.tabControl.TabIndex = 50;
            // 
            // tabPagePerson
            // 
            this.tabPagePerson.Controls.Add(this.buttonPersonAdd);
            this.tabPagePerson.Controls.Add(this.panel1);
            this.tabPagePerson.Location = new System.Drawing.Point(4, 22);
            this.tabPagePerson.Name = "tabPagePerson";
            this.tabPagePerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePerson.Size = new System.Drawing.Size(768, 240);
            this.tabPagePerson.TabIndex = 0;
            this.tabPagePerson.Text = "Membre de la famille";
            this.tabPagePerson.UseVisualStyleBackColor = true;
            // 
            // buttonPersonAdd
            // 
            this.buttonPersonAdd.Location = new System.Drawing.Point(6, 6);
            this.buttonPersonAdd.Name = "buttonPersonAdd";
            this.buttonPersonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonPersonAdd.TabIndex = 1;
            this.buttonPersonAdd.Text = "Ajouter";
            this.buttonPersonAdd.UseVisualStyleBackColor = true;
            this.buttonPersonAdd.Click += new System.EventHandler(this.buttonPersonAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 198);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(768, 198);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPagePhone
            // 
            this.tabPagePhone.Location = new System.Drawing.Point(4, 22);
            this.tabPagePhone.Name = "tabPagePhone";
            this.tabPagePhone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhone.Size = new System.Drawing.Size(768, 240);
            this.tabPagePhone.TabIndex = 1;
            this.tabPagePhone.Text = "Téléphone";
            this.tabPagePhone.UseVisualStyleBackColor = true;
            // 
            // FrmFamilyCreationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmFamilyCreationEdit";
            this.Text = "Famille";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPagePerson.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSaveFamily;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxZipCode;
        private System.Windows.Forms.Label labelZipCode;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagePerson;
        private System.Windows.Forms.Button buttonPersonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPagePhone;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}