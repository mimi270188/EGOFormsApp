namespace EGO
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFamily = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemGymGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemPerson,
            this.ToolStripMenuItemFamily,
            this.ToolStripMenuItemGymGroup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemPerson
            // 
            this.ToolStripMenuItemPerson.Name = "ToolStripMenuItemPerson";
            this.ToolStripMenuItemPerson.Size = new System.Drawing.Size(68, 20);
            this.ToolStripMenuItemPerson.Text = "Adhérent";
            this.ToolStripMenuItemPerson.Click += new System.EventHandler(this.ToolStripMenuItemPerson_Click);
            // 
            // ToolStripMenuItemFamily
            // 
            this.ToolStripMenuItemFamily.Name = "ToolStripMenuItemFamily";
            this.ToolStripMenuItemFamily.Size = new System.Drawing.Size(57, 20);
            this.ToolStripMenuItemFamily.Text = "Famille";
            this.ToolStripMenuItemFamily.Click += new System.EventHandler(this.ToolStripMenuItemFamily_Click);
            // 
            // ToolStripMenuItemGymGroup
            // 
            this.ToolStripMenuItemGymGroup.Name = "ToolStripMenuItemGymGroup";
            this.ToolStripMenuItemGymGroup.Size = new System.Drawing.Size(58, 20);
            this.ToolStripMenuItemGymGroup.Text = "Groupe";
            this.ToolStripMenuItemGymGroup.Click += new System.EventHandler(this.ToolStripMenuItemGymGroup_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 536);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(762, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 134);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(762, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(596, 134);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Location = new System.Drawing.Point(762, 307);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(596, 134);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Location = new System.Drawing.Point(762, 447);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(596, 116);
            this.panel5.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 575);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Espoirs Gymniques d\'Osny";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPerson;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFamily;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGymGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}

