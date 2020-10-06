namespace EGOFormsApp.Group
{
    partial class FrmGroupCreationEdit
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
            this.groupBoxGroup = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.numericUpDownYearPrice = new System.Windows.Forms.NumericUpDown();
            this.labelYearPrice = new System.Windows.Forms.Label();
            this.GymYear = new System.Windows.Forms.Label();
            this.numericUpDownGymYear = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumberOfHours = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfHours = new System.Windows.Forms.Label();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.labelGroupName = new System.Windows.Forms.Label();
            this.groupBoxGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGymYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfHours)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxGroup
            // 
            this.groupBoxGroup.Controls.Add(this.buttonSave);
            this.groupBoxGroup.Controls.Add(this.numericUpDownYearPrice);
            this.groupBoxGroup.Controls.Add(this.labelYearPrice);
            this.groupBoxGroup.Controls.Add(this.GymYear);
            this.groupBoxGroup.Controls.Add(this.numericUpDownGymYear);
            this.groupBoxGroup.Controls.Add(this.numericUpDownNumberOfHours);
            this.groupBoxGroup.Controls.Add(this.labelNumberOfHours);
            this.groupBoxGroup.Controls.Add(this.textBoxGroupName);
            this.groupBoxGroup.Controls.Add(this.labelGroupName);
            this.groupBoxGroup.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGroup.Name = "groupBoxGroup";
            this.groupBoxGroup.Size = new System.Drawing.Size(776, 100);
            this.groupBoxGroup.TabIndex = 0;
            this.groupBoxGroup.TabStop = false;
            this.groupBoxGroup.Text = "Groupe";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(695, 71);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Enregistrer";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // numericUpDownYearPrice
            // 
            this.numericUpDownYearPrice.DecimalPlaces = 2;
            this.numericUpDownYearPrice.Location = new System.Drawing.Point(9, 71);
            this.numericUpDownYearPrice.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownYearPrice.Name = "numericUpDownYearPrice";
            this.numericUpDownYearPrice.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownYearPrice.TabIndex = 7;
            // 
            // labelYearPrice
            // 
            this.labelYearPrice.AutoSize = true;
            this.labelYearPrice.Location = new System.Drawing.Point(6, 55);
            this.labelYearPrice.Name = "labelYearPrice";
            this.labelYearPrice.Size = new System.Drawing.Size(92, 13);
            this.labelYearPrice.TabIndex = 6;
            this.labelYearPrice.Text = "Tarif pour l\'année:";
            // 
            // GymYear
            // 
            this.GymYear.AutoSize = true;
            this.GymYear.Location = new System.Drawing.Point(548, 16);
            this.GymYear.Name = "GymYear";
            this.GymYear.Size = new System.Drawing.Size(41, 13);
            this.GymYear.TabIndex = 5;
            this.GymYear.Text = "Année:";
            // 
            // numericUpDownGymYear
            // 
            this.numericUpDownGymYear.Location = new System.Drawing.Point(551, 32);
            this.numericUpDownGymYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownGymYear.Name = "numericUpDownGymYear";
            this.numericUpDownGymYear.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownGymYear.TabIndex = 4;
            // 
            // numericUpDownNumberOfHours
            // 
            this.numericUpDownNumberOfHours.DecimalPlaces = 2;
            this.numericUpDownNumberOfHours.Location = new System.Drawing.Point(425, 32);
            this.numericUpDownNumberOfHours.Name = "numericUpDownNumberOfHours";
            this.numericUpDownNumberOfHours.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNumberOfHours.TabIndex = 3;
            // 
            // labelNumberOfHours
            // 
            this.labelNumberOfHours.AutoSize = true;
            this.labelNumberOfHours.Location = new System.Drawing.Point(422, 16);
            this.labelNumberOfHours.Name = "labelNumberOfHours";
            this.labelNumberOfHours.Size = new System.Drawing.Size(85, 13);
            this.labelNumberOfHours.TabIndex = 2;
            this.labelNumberOfHours.Text = "Nombre d\'heure:";
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Location = new System.Drawing.Point(9, 32);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(407, 20);
            this.textBoxGroupName.TabIndex = 1;
            // 
            // labelGroupName
            // 
            this.labelGroupName.AutoSize = true;
            this.labelGroupName.Location = new System.Drawing.Point(6, 16);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(32, 13);
            this.labelGroupName.TabIndex = 0;
            this.labelGroupName.Text = "Nom:";
            // 
            // FrmGroupCreationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxGroup);
            this.Name = "FrmGroupCreationEdit";
            this.Text = "FrmGroup";
            this.groupBoxGroup.ResumeLayout(false);
            this.groupBoxGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGymYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxGroup;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfHours;
        private System.Windows.Forms.Label labelNumberOfHours;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.Label labelGroupName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.NumericUpDown numericUpDownYearPrice;
        private System.Windows.Forms.Label labelYearPrice;
        private System.Windows.Forms.Label GymYear;
        private System.Windows.Forms.NumericUpDown numericUpDownGymYear;
    }
}