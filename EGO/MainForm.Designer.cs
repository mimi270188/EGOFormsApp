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
            this.adhérentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechercheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rechercheToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créationToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rechercheToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adhérentToolStripMenuItem,
            this.familleToolStripMenuItem,
            this.groupeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adhérentToolStripMenuItem
            // 
            this.adhérentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créationToolStripMenuItem,
            this.rechercheToolStripMenuItem});
            this.adhérentToolStripMenuItem.Name = "adhérentToolStripMenuItem";
            this.adhérentToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.adhérentToolStripMenuItem.Text = "Adhérent";
            // 
            // créationToolStripMenuItem
            // 
            this.créationToolStripMenuItem.Name = "créationToolStripMenuItem";
            this.créationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.créationToolStripMenuItem.Text = "Création";
            // 
            // rechercheToolStripMenuItem
            // 
            this.rechercheToolStripMenuItem.Name = "rechercheToolStripMenuItem";
            this.rechercheToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rechercheToolStripMenuItem.Text = "Recherche";
            // 
            // familleToolStripMenuItem
            // 
            this.familleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créationToolStripMenuItem1,
            this.rechercheToolStripMenuItem1});
            this.familleToolStripMenuItem.Name = "familleToolStripMenuItem";
            this.familleToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.familleToolStripMenuItem.Text = "Famille";
            // 
            // créationToolStripMenuItem1
            // 
            this.créationToolStripMenuItem1.Name = "créationToolStripMenuItem1";
            this.créationToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.créationToolStripMenuItem1.Text = "Création";
            this.créationToolStripMenuItem1.Click += new System.EventHandler(this.créationToolStripMenuItem1_Click);
            // 
            // rechercheToolStripMenuItem1
            // 
            this.rechercheToolStripMenuItem1.Name = "rechercheToolStripMenuItem1";
            this.rechercheToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.rechercheToolStripMenuItem1.Text = "Recherche";
            // 
            // groupeToolStripMenuItem
            // 
            this.groupeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créationToolStripMenuItem2,
            this.rechercheToolStripMenuItem2});
            this.groupeToolStripMenuItem.Name = "groupeToolStripMenuItem";
            this.groupeToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.groupeToolStripMenuItem.Text = "Groupe";
            // 
            // créationToolStripMenuItem2
            // 
            this.créationToolStripMenuItem2.Name = "créationToolStripMenuItem2";
            this.créationToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.créationToolStripMenuItem2.Text = "Création";
            // 
            // rechercheToolStripMenuItem2
            // 
            this.rechercheToolStripMenuItem2.Name = "rechercheToolStripMenuItem2";
            this.rechercheToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.rechercheToolStripMenuItem2.Text = "Recherche";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Espoirs Gymniques d\'Osny";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adhérentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem créationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechercheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem créationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rechercheToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem groupeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem créationToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem rechercheToolStripMenuItem2;
    }
}

