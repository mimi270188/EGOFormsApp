namespace EGOFormsApp._Phone
{
    partial class FrmPhoneCreationEdit
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
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.buttonPhoneAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(328, 118);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(149, 20);
            this.textBoxPhoneNumber.TabIndex = 0;
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(325, 102);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(61, 13);
            this.labelPhoneNumber.TabIndex = 1;
            this.labelPhoneNumber.Text = "Téléphone:";
            // 
            // buttonPhoneAdd
            // 
            this.buttonPhoneAdd.Location = new System.Drawing.Point(483, 115);
            this.buttonPhoneAdd.Name = "buttonPhoneAdd";
            this.buttonPhoneAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonPhoneAdd.TabIndex = 2;
            this.buttonPhoneAdd.Text = "Enregistrer";
            this.buttonPhoneAdd.UseVisualStyleBackColor = true;
            this.buttonPhoneAdd.Click += new System.EventHandler(this.buttonPhoneAdd_Click);
            // 
            // FrmPhoneCreationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPhoneAdd);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Name = "FrmPhoneCreationEdit";
            this.Text = "FrmPhoneCreationEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Button buttonPhoneAdd;
    }
}