namespace test
{
    partial class Form2
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
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.eGODataSet = new test.EGODataSet();
            this.kINDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kINDTableAdapter = new test.EGODataSetTableAdapters.KINDTableAdapter();
            this.kINDIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kINDNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eGODataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kINDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AutoGenerateColumns = false;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kINDIDDataGridViewTextBoxColumn,
            this.kINDNAMEDataGridViewTextBoxColumn});
            this.advancedDataGridView1.DataSource = this.kINDBindingSource;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.Size = new System.Drawing.Size(800, 450);
            this.advancedDataGridView1.TabIndex = 0;
            this.advancedDataGridView1.TimeFilter = false;
            // 
            // eGODataSet
            // 
            this.eGODataSet.DataSetName = "EGODataSet";
            this.eGODataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kINDBindingSource
            // 
            this.kINDBindingSource.DataMember = "KIND";
            this.kINDBindingSource.DataSource = this.eGODataSet;
            // 
            // kINDTableAdapter
            // 
            this.kINDTableAdapter.ClearBeforeFill = true;
            // 
            // kINDIDDataGridViewTextBoxColumn
            // 
            this.kINDIDDataGridViewTextBoxColumn.DataPropertyName = "KINDID";
            this.kINDIDDataGridViewTextBoxColumn.HeaderText = "KINDID";
            this.kINDIDDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.kINDIDDataGridViewTextBoxColumn.Name = "kINDIDDataGridViewTextBoxColumn";
            this.kINDIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.kINDIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // kINDNAMEDataGridViewTextBoxColumn
            // 
            this.kINDNAMEDataGridViewTextBoxColumn.DataPropertyName = "KINDNAME";
            this.kINDNAMEDataGridViewTextBoxColumn.HeaderText = "KINDNAME";
            this.kINDNAMEDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.kINDNAMEDataGridViewTextBoxColumn.Name = "kINDNAMEDataGridViewTextBoxColumn";
            this.kINDNAMEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.advancedDataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eGODataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kINDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private EGODataSet eGODataSet;
        private System.Windows.Forms.BindingSource kINDBindingSource;
        private EGODataSetTableAdapters.KINDTableAdapter kINDTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn kINDIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kINDNAMEDataGridViewTextBoxColumn;
    }
}