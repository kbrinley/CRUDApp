namespace CRUDApp.WinForm
{
    partial class StudentList
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
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLine1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLine2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressZipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentsModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.AutoGenerateColumns = false;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.middleNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.addressLine1DataGridViewTextBoxColumn,
            this.addressLine2DataGridViewTextBoxColumn,
            this.addressCityDataGridViewTextBoxColumn,
            this.addressStateDataGridViewTextBoxColumn,
            this.addressZipDataGridViewTextBoxColumn});
            this.dgvStudents.DataSource = this.studentsModelBindingSource;
            this.dgvStudents.Location = new System.Drawing.Point(12, 56);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(973, 368);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellDoubleClick);
            this.dgvStudents.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvStudents_RowValidating);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(818, 12);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(167, 23);
            this.btnAddStudent.TabIndex = 1;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            this.middleNameDataGridViewTextBoxColumn.DataPropertyName = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.HeaderText = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.Name = "middleNameDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // addressLine1DataGridViewTextBoxColumn
            // 
            this.addressLine1DataGridViewTextBoxColumn.DataPropertyName = "AddressLine1";
            this.addressLine1DataGridViewTextBoxColumn.HeaderText = "AddressLine1";
            this.addressLine1DataGridViewTextBoxColumn.Name = "addressLine1DataGridViewTextBoxColumn";
            // 
            // addressLine2DataGridViewTextBoxColumn
            // 
            this.addressLine2DataGridViewTextBoxColumn.DataPropertyName = "AddressLine2";
            this.addressLine2DataGridViewTextBoxColumn.HeaderText = "AddressLine2";
            this.addressLine2DataGridViewTextBoxColumn.Name = "addressLine2DataGridViewTextBoxColumn";
            // 
            // addressCityDataGridViewTextBoxColumn
            // 
            this.addressCityDataGridViewTextBoxColumn.DataPropertyName = "AddressCity";
            this.addressCityDataGridViewTextBoxColumn.HeaderText = "AddressCity";
            this.addressCityDataGridViewTextBoxColumn.Name = "addressCityDataGridViewTextBoxColumn";
            // 
            // addressStateDataGridViewTextBoxColumn
            // 
            this.addressStateDataGridViewTextBoxColumn.DataPropertyName = "AddressState";
            this.addressStateDataGridViewTextBoxColumn.HeaderText = "AddressState";
            this.addressStateDataGridViewTextBoxColumn.Name = "addressStateDataGridViewTextBoxColumn";
            // 
            // addressZipDataGridViewTextBoxColumn
            // 
            this.addressZipDataGridViewTextBoxColumn.DataPropertyName = "AddressZip";
            this.addressZipDataGridViewTextBoxColumn.HeaderText = "AddressZip";
            this.addressZipDataGridViewTextBoxColumn.Name = "addressZipDataGridViewTextBoxColumn";
            // 
            // studentsModelBindingSource
            // 
            this.studentsModelBindingSource.DataSource = typeof(CRUDApp.Model.StudentsModel);
            this.studentsModelBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.studentsModelBindingSource_AddingNew);
            this.studentsModelBindingSource.CurrentItemChanged += new System.EventHandler(this.studentsModelBindingSource_CurrentItemChanged);
            // 
            // StudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 436);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.dgvStudents);
            this.Name = "StudentList";
            this.Text = "Student List";
            this.Activated += new System.EventHandler(this.StudentList_Activated);
            this.Load += new System.EventHandler(this.StudentList_OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLine1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLine2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressCityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressZipDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource studentsModelBindingSource;
    }
}

