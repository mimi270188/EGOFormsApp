namespace EGOFormsApp.Group
{
    partial class FrmGroupSearch
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
            this.components = new System.ComponentModel.Container();
            this.pContainerFamilySearch = new System.Windows.Forms.Panel();
            this.dataGridViewGymGroup = new System.Windows.Forms.DataGridView();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelGymYear = new System.Windows.Forms.Label();
            this.numericUpDownGymYear = new System.Windows.Forms.NumericUpDown();
            this.gymGroupSearchViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gYMGROUPNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMBEROFHOURSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gYMYEARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yEARPRICEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pContainerFamilySearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGymGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGymYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymGroupSearchViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pContainerFamilySearch
            // 
            this.pContainerFamilySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContainerFamilySearch.AutoSize = true;
            this.pContainerFamilySearch.Controls.Add(this.dataGridViewGymGroup);
            this.pContainerFamilySearch.Location = new System.Drawing.Point(1, 31);
            this.pContainerFamilySearch.Name = "pContainerFamilySearch";
            this.pContainerFamilySearch.Size = new System.Drawing.Size(799, 416);
            this.pContainerFamilySearch.TabIndex = 8;
            // 
            // dataGridViewGymGroup
            // 
            this.dataGridViewGymGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGymGroup.AutoGenerateColumns = false;
            this.dataGridViewGymGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGymGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGymGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gYMGROUPNAMEDataGridViewTextBoxColumn,
            this.nUMBEROFHOURSDataGridViewTextBoxColumn,
            this.gYMYEARDataGridViewTextBoxColumn,
            this.yEARPRICEDataGridViewTextBoxColumn,
            this.Delete});
            this.dataGridViewGymGroup.DataSource = this.gymGroupSearchViewBindingSource;
            this.dataGridViewGymGroup.Location = new System.Drawing.Point(-2, 55);
            this.dataGridViewGymGroup.Name = "dataGridViewGymGroup";
            this.dataGridViewGymGroup.Size = new System.Drawing.Size(753, 361);
            this.dataGridViewGymGroup.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(224, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Rechercher";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelGymYear
            // 
            this.labelGymYear.AutoSize = true;
            this.labelGymYear.Location = new System.Drawing.Point(13, 5);
            this.labelGymYear.Name = "labelGymYear";
            this.labelGymYear.Size = new System.Drawing.Size(41, 13);
            this.labelGymYear.TabIndex = 5;
            this.labelGymYear.Text = "Année:";
            // 
            // numericUpDownGymYear
            // 
            this.numericUpDownGymYear.Location = new System.Drawing.Point(60, 3);
            this.numericUpDownGymYear.Name = "numericUpDownGymYear";
            this.numericUpDownGymYear.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownGymYear.TabIndex = 9;
            // 
            // gymGroupSearchViewBindingSource
            // 
            this.gymGroupSearchViewBindingSource.DataSource = typeof(EGOFormsApp.ViewModel.Group.GymGroupSearchView);
            // 
            // gYMGROUPNAMEDataGridViewTextBoxColumn
            // 
            this.gYMGROUPNAMEDataGridViewTextBoxColumn.DataPropertyName = "GYMGROUPNAME";
            this.gYMGROUPNAMEDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.gYMGROUPNAMEDataGridViewTextBoxColumn.Name = "gYMGROUPNAMEDataGridViewTextBoxColumn";
            // 
            // nUMBEROFHOURSDataGridViewTextBoxColumn
            // 
            this.nUMBEROFHOURSDataGridViewTextBoxColumn.DataPropertyName = "NUMBEROFHOURS";
            this.nUMBEROFHOURSDataGridViewTextBoxColumn.HeaderText = "Nombre d\'heures/semaine";
            this.nUMBEROFHOURSDataGridViewTextBoxColumn.Name = "nUMBEROFHOURSDataGridViewTextBoxColumn";
            // 
            // gYMYEARDataGridViewTextBoxColumn
            // 
            this.gYMYEARDataGridViewTextBoxColumn.DataPropertyName = "GYMYEAR";
            this.gYMYEARDataGridViewTextBoxColumn.HeaderText = "Année";
            this.gYMYEARDataGridViewTextBoxColumn.Name = "gYMYEARDataGridViewTextBoxColumn";
            // 
            // yEARPRICEDataGridViewTextBoxColumn
            // 
            this.yEARPRICEDataGridViewTextBoxColumn.DataPropertyName = "YEARPRICE";
            this.yEARPRICEDataGridViewTextBoxColumn.HeaderText = "Tarif/an";
            this.yEARPRICEDataGridViewTextBoxColumn.Name = "yEARPRICEDataGridViewTextBoxColumn";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Suppression";
            this.Delete.Name = "Delete";
            // 
            // FrmGroupSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericUpDownGymYear);
            this.Controls.Add(this.pContainerFamilySearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelGymYear);
            this.Name = "FrmGroupSearch";
            this.Text = "FrmGroupSearch";
            this.pContainerFamilySearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGymGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGymYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymGroupSearchViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pContainerFamilySearch;
        private System.Windows.Forms.DataGridView dataGridViewGymGroup;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelGymYear;
        private System.Windows.Forms.NumericUpDown numericUpDownGymYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gYMGROUPNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMBEROFHOURSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gYMYEARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yEARPRICEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.BindingSource gymGroupSearchViewBindingSource;
    }
}