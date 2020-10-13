namespace EGO.View.GymGroup
{
    partial class FrmGymGroup
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
            this.labelGymGroupName = new System.Windows.Forms.Label();
            this.textBoxGymGroupName = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelGymGroupYear = new System.Windows.Forms.Label();
            this.numericUpDownGymGroupYear = new System.Windows.Forms.NumericUpDown();
            this.buttonBind = new System.Windows.Forms.Button();
            this.gYMGROUPNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMBEROFHOURSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gYMYEARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yEARPRICEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gymGroupSearchViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGymGroupYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymGroupSearchViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGymGroupName
            // 
            this.labelGymGroupName.AutoSize = true;
            this.labelGymGroupName.Location = new System.Drawing.Point(12, 9);
            this.labelGymGroupName.Name = "labelGymGroupName";
            this.labelGymGroupName.Size = new System.Drawing.Size(45, 13);
            this.labelGymGroupName.TabIndex = 0;
            this.labelGymGroupName.Text = "Groupe:";
            // 
            // textBoxGymGroupName
            // 
            this.textBoxGymGroupName.Location = new System.Drawing.Point(63, 5);
            this.textBoxGymGroupName.Name = "textBoxGymGroupName";
            this.textBoxGymGroupName.Size = new System.Drawing.Size(203, 20);
            this.textBoxGymGroupName.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(459, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Rechercher";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gYMGROUPNAMEDataGridViewTextBoxColumn,
            this.nUMBEROFHOURSDataGridViewTextBoxColumn,
            this.gYMYEARDataGridViewTextBoxColumn,
            this.yEARPRICEDataGridViewTextBoxColumn,
            this.Edit,
            this.Delete});
            this.dataGridView1.DataSource = this.gymGroupSearchViewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 403);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Modification";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Modifier";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Suppresion";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Supprimer";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(713, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Ajouter";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelGymGroupYear
            // 
            this.labelGymGroupYear.AutoSize = true;
            this.labelGymGroupYear.Location = new System.Drawing.Point(272, 8);
            this.labelGymGroupYear.Name = "labelGymGroupYear";
            this.labelGymGroupYear.Size = new System.Drawing.Size(41, 13);
            this.labelGymGroupYear.TabIndex = 5;
            this.labelGymGroupYear.Text = "Année:";
            // 
            // numericUpDownGymGroupYear
            // 
            this.numericUpDownGymGroupYear.Location = new System.Drawing.Point(319, 6);
            this.numericUpDownGymGroupYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownGymGroupYear.Name = "numericUpDownGymGroupYear";
            this.numericUpDownGymGroupYear.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownGymGroupYear.TabIndex = 6;
            // 
            // buttonBind
            // 
            this.buttonBind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBind.Location = new System.Drawing.Point(632, 3);
            this.buttonBind.Name = "buttonBind";
            this.buttonBind.Size = new System.Drawing.Size(75, 23);
            this.buttonBind.TabIndex = 7;
            this.buttonBind.Text = "Lier";
            this.buttonBind.UseVisualStyleBackColor = true;
            this.buttonBind.Click += new System.EventHandler(this.buttonBind_Click);
            // 
            // gYMGROUPNAMEDataGridViewTextBoxColumn
            // 
            this.gYMGROUPNAMEDataGridViewTextBoxColumn.DataPropertyName = "GYMGROUPNAME";
            this.gYMGROUPNAMEDataGridViewTextBoxColumn.HeaderText = "GYMGROUPNAME";
            this.gYMGROUPNAMEDataGridViewTextBoxColumn.Name = "gYMGROUPNAMEDataGridViewTextBoxColumn";
            // 
            // nUMBEROFHOURSDataGridViewTextBoxColumn
            // 
            this.nUMBEROFHOURSDataGridViewTextBoxColumn.DataPropertyName = "NUMBEROFHOURS";
            this.nUMBEROFHOURSDataGridViewTextBoxColumn.HeaderText = "NUMBEROFHOURS";
            this.nUMBEROFHOURSDataGridViewTextBoxColumn.Name = "nUMBEROFHOURSDataGridViewTextBoxColumn";
            // 
            // gYMYEARDataGridViewTextBoxColumn
            // 
            this.gYMYEARDataGridViewTextBoxColumn.DataPropertyName = "GYMYEAR";
            this.gYMYEARDataGridViewTextBoxColumn.HeaderText = "GYMYEAR";
            this.gYMYEARDataGridViewTextBoxColumn.Name = "gYMYEARDataGridViewTextBoxColumn";
            // 
            // yEARPRICEDataGridViewTextBoxColumn
            // 
            this.yEARPRICEDataGridViewTextBoxColumn.DataPropertyName = "YEARPRICE";
            this.yEARPRICEDataGridViewTextBoxColumn.HeaderText = "YEARPRICE";
            this.yEARPRICEDataGridViewTextBoxColumn.Name = "yEARPRICEDataGridViewTextBoxColumn";
            // 
            // gymGroupSearchViewBindingSource
            // 
            this.gymGroupSearchViewBindingSource.DataSource = typeof(EGO.ViewModel.Group.GymGroupSearchView);
            // 
            // FrmGymGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBind);
            this.Controls.Add(this.numericUpDownGymGroupYear);
            this.Controls.Add(this.labelGymGroupYear);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxGymGroupName);
            this.Controls.Add(this.labelGymGroupName);
            this.Name = "FrmGymGroup";
            this.Text = "Groupes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGymGroupYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymGroupSearchViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGymGroupName;
        private System.Windows.Forms.TextBox textBoxGymGroupName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelGymGroupYear;
        private System.Windows.Forms.NumericUpDown numericUpDownGymGroupYear;
        private System.Windows.Forms.BindingSource gymGroupSearchViewBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn gYMGROUPNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMBEROFHOURSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gYMYEARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yEARPRICEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button buttonBind;
    }
}