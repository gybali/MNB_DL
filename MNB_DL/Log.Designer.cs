namespace MNB_DL
{
    partial class Log
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mNBLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mNB_LogDataSet = new MNB_DL.MNB_LogDataSet();
            this.mNBLogTableAdapter = new MNB_DL.MNB_LogDataSetTableAdapters.MNBLogTableAdapter();
            this.logSave = new System.Windows.Forms.Button();
            this.logCancel = new System.Windows.Forms.Button();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mNBLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mNB_LogDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.mNBLogBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(984, 676);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // mNBLogBindingSource
            // 
            this.mNBLogBindingSource.DataMember = "MNBLog";
            this.mNBLogBindingSource.DataSource = this.mNB_LogDataSet;
            // 
            // mNB_LogDataSet
            // 
            this.mNB_LogDataSet.DataSetName = "MNB_LogDataSet";
            this.mNB_LogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mNBLogTableAdapter
            // 
            this.mNBLogTableAdapter.ClearBeforeFill = true;
            // 
            // logSave
            // 
            this.logSave.BackColor = System.Drawing.SystemColors.Control;
            this.logSave.Location = new System.Drawing.Point(921, 694);
            this.logSave.Name = "logSave";
            this.logSave.Size = new System.Drawing.Size(75, 23);
            this.logSave.TabIndex = 1;
            this.logSave.Text = "Save";
            this.logSave.UseVisualStyleBackColor = false;
            this.logSave.Click += new System.EventHandler(this.logSave_Click);
            // 
            // logCancel
            // 
            this.logCancel.Location = new System.Drawing.Point(840, 694);
            this.logCancel.Name = "logCancel";
            this.logCancel.Size = new System.Drawing.Size(75, 23);
            this.logCancel.TabIndex = 2;
            this.logCancel.Text = "Cancel";
            this.logCancel.UseVisualStyleBackColor = true;
            this.logCancel.Click += new System.EventHandler(this.logCancel_Click);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            this.iDDataGridViewTextBoxColumn.Width = 200;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "userName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "Felhasználó";
            this.userNameDataGridViewTextBoxColumn.MinimumWidth = 290;
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Időpont";
            this.timeDataGridViewTextBoxColumn.MinimumWidth = 300;
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Indoklás";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 400;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.logCancel);
            this.Controls.Add(this.logSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Log";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Log_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mNBLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mNB_LogDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MNB_LogDataSet mNB_LogDataSet;
        private MNB_LogDataSetTableAdapters.MNBLogTableAdapter mNBLogTableAdapter;
        private System.Windows.Forms.BindingSource mNBLogBindingSource;
        private System.Windows.Forms.Button logSave;
        private System.Windows.Forms.Button logCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}