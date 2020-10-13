namespace EGO.View.GymGroup
{
    partial class FrmGymGroupBind
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
            this.labelGymGroup = new System.Windows.Forms.Label();
            this.comboBoxGymGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.labelPerson = new System.Windows.Forms.Label();
            this.buttonBind = new System.Windows.Forms.Button();
            this.numericUpDownGymGroupYear = new System.Windows.Forms.NumericUpDown();
            this.labelGymGroupYear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGymGroupYear)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGymGroup
            // 
            this.labelGymGroup.AutoSize = true;
            this.labelGymGroup.Location = new System.Drawing.Point(51, 122);
            this.labelGymGroup.Name = "labelGymGroup";
            this.labelGymGroup.Size = new System.Drawing.Size(45, 13);
            this.labelGymGroup.TabIndex = 0;
            this.labelGymGroup.Text = "Groupe:";
            // 
            // comboBoxGymGroup
            // 
            this.comboBoxGymGroup.FormattingEnabled = true;
            this.comboBoxGymGroup.Location = new System.Drawing.Point(54, 138);
            this.comboBoxGymGroup.Name = "comboBoxGymGroup";
            this.comboBoxGymGroup.Size = new System.Drawing.Size(429, 21);
            this.comboBoxGymGroup.TabIndex = 1;
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Location = new System.Drawing.Point(54, 200);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(429, 21);
            this.comboBoxPerson.TabIndex = 3;
            // 
            // labelPerson
            // 
            this.labelPerson.AutoSize = true;
            this.labelPerson.Location = new System.Drawing.Point(51, 184);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(53, 13);
            this.labelPerson.TabIndex = 2;
            this.labelPerson.Text = "Adhérent:";
            // 
            // buttonBind
            // 
            this.buttonBind.Location = new System.Drawing.Point(190, 263);
            this.buttonBind.Name = "buttonBind";
            this.buttonBind.Size = new System.Drawing.Size(75, 23);
            this.buttonBind.TabIndex = 4;
            this.buttonBind.Text = "Lier";
            this.buttonBind.UseVisualStyleBackColor = true;
            this.buttonBind.Click += new System.EventHandler(this.buttonBind_Click);
            // 
            // numericUpDownGymGroupYear
            // 
            this.numericUpDownGymGroupYear.Location = new System.Drawing.Point(54, 86);
            this.numericUpDownGymGroupYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownGymGroupYear.Name = "numericUpDownGymGroupYear";
            this.numericUpDownGymGroupYear.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownGymGroupYear.TabIndex = 5;
            // 
            // labelGymGroupYear
            // 
            this.labelGymGroupYear.AutoSize = true;
            this.labelGymGroupYear.Location = new System.Drawing.Point(51, 70);
            this.labelGymGroupYear.Name = "labelGymGroupYear";
            this.labelGymGroupYear.Size = new System.Drawing.Size(41, 13);
            this.labelGymGroupYear.TabIndex = 6;
            this.labelGymGroupYear.Text = "Année:";
            // 
            // FrmGymGroupBind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 450);
            this.Controls.Add(this.labelGymGroupYear);
            this.Controls.Add(this.numericUpDownGymGroupYear);
            this.Controls.Add(this.buttonBind);
            this.Controls.Add(this.comboBoxPerson);
            this.Controls.Add(this.labelPerson);
            this.Controls.Add(this.comboBoxGymGroup);
            this.Controls.Add(this.labelGymGroup);
            this.Name = "FrmGymGroupBind";
            this.Text = "FrmGymGroupBind";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGymGroupYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGymGroup;
        private System.Windows.Forms.ComboBox comboBoxGymGroup;
        private System.Windows.Forms.ComboBox comboBoxPerson;
        private System.Windows.Forms.Label labelPerson;
        private System.Windows.Forms.Button buttonBind;
        private System.Windows.Forms.NumericUpDown numericUpDownGymGroupYear;
        private System.Windows.Forms.Label labelGymGroupYear;
    }
}