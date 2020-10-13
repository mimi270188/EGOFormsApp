namespace EGO.View.Document
{
    partial class FrmDocument
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
            this.labelDocumentYear = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.numericUpDownDocumentYear = new System.Windows.Forms.NumericUpDown();
            this.documentSearchViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dOCUMENTYEARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOCUMENTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mADATORYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDocumentYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentSearchViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDocumentYear
            // 
            this.labelDocumentYear.AutoSize = true;
            this.labelDocumentYear.Location = new System.Drawing.Point(12, 9);
            this.labelDocumentYear.Name = "labelDocumentYear";
            this.labelDocumentYear.Size = new System.Drawing.Size(41, 13);
            this.labelDocumentYear.TabIndex = 0;
            this.labelDocumentYear.Text = "Année:";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(185, 4);
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
            this.dOCUMENTYEARDataGridViewTextBoxColumn,
            this.dOCUMENTNAMEDataGridViewTextBoxColumn,
            this.mADATORYDataGridViewTextBoxColumn,
            this.Edit,
            this.Delete});
            this.dataGridView1.DataSource = this.documentSearchViewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 403);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // 
            // numericUpDownDocumentYear
            // 
            this.numericUpDownDocumentYear.Location = new System.Drawing.Point(59, 6);
            this.numericUpDownDocumentYear.Name = "numericUpDownDocumentYear";
            this.numericUpDownDocumentYear.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDocumentYear.TabIndex = 5;
            // 
            // documentSearchViewBindingSource
            // 
            this.documentSearchViewBindingSource.DataSource = typeof(EGO.ViewModel.Document.DocumentSearchView);
            // 
            // dOCUMENTYEARDataGridViewTextBoxColumn
            // 
            this.dOCUMENTYEARDataGridViewTextBoxColumn.DataPropertyName = "DOCUMENTYEAR";
            this.dOCUMENTYEARDataGridViewTextBoxColumn.HeaderText = "DOCUMENTYEAR";
            this.dOCUMENTYEARDataGridViewTextBoxColumn.Name = "dOCUMENTYEARDataGridViewTextBoxColumn";
            // 
            // dOCUMENTNAMEDataGridViewTextBoxColumn
            // 
            this.dOCUMENTNAMEDataGridViewTextBoxColumn.DataPropertyName = "DOCUMENTNAME";
            this.dOCUMENTNAMEDataGridViewTextBoxColumn.HeaderText = "DOCUMENTNAME";
            this.dOCUMENTNAMEDataGridViewTextBoxColumn.Name = "dOCUMENTNAMEDataGridViewTextBoxColumn";
            // 
            // mADATORYDataGridViewTextBoxColumn
            // 
            this.mADATORYDataGridViewTextBoxColumn.DataPropertyName = "MADATORY";
            this.mADATORYDataGridViewTextBoxColumn.HeaderText = "MADATORY";
            this.mADATORYDataGridViewTextBoxColumn.Name = "mADATORYDataGridViewTextBoxColumn";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Modification";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Modifer";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Suppression";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Supprimer";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // FrmDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericUpDownDocumentYear);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelDocumentYear);
            this.Name = "FrmDocument";
            this.Text = "Documents";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDocumentYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentSearchViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDocumentYear;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.NumericUpDown numericUpDownDocumentYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOCUMENTYEARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOCUMENTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mADATORYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.BindingSource documentSearchViewBindingSource;
    }
}