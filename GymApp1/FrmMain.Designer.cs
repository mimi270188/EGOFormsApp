﻿namespace GymApp1
{
    partial class FrmMain
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
            this.familyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.familyToolStripMenuItem,
            this.PersonToolStripMenuItem,
            this.groupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1295, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // familyToolStripMenuItem
            // 
            this.familyToolStripMenuItem.Name = "familyToolStripMenuItem";
            this.familyToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.familyToolStripMenuItem.Text = "Famille";
            this.familyToolStripMenuItem.Click += new System.EventHandler(this.familyToolStripMenuItem_Click);
            // 
            // PersonToolStripMenuItem
            // 
            this.PersonToolStripMenuItem.Name = "PersonToolStripMenuItem";
            this.PersonToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.PersonToolStripMenuItem.Text = "Adhérents";
            this.PersonToolStripMenuItem.Click += new System.EventHandler(this.PersonToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.groupToolStripMenuItem.Text = "Groupe";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Location = new System.Drawing.Point(6, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 390);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(659, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 93);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(659, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(630, 93);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Location = new System.Drawing.Point(659, 223);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(630, 93);
            this.panel4.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Location = new System.Drawing.Point(659, 322);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(630, 93);
            this.panel5.TabIndex = 16;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 421);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmMain";
            this.Text = "Espoirs Gymniques d\'Osny";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel5;
    }
}

