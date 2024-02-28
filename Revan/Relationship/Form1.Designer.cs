namespace Relationship
{
    partial class Form1
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
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label hire_dateLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label phone_numberLabel;
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.hire_dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.phone_numberTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phonenumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiredateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mutationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promotionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            emailLabel = new System.Windows.Forms.Label();
            hire_dateLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            phone_numberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(33, 55);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(43, 16);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "email:";
            // 
            // hire_dateLabel
            // 
            hire_dateLabel.AutoSize = true;
            hire_dateLabel.Location = new System.Drawing.Point(33, 84);
            hire_dateLabel.Name = "hire_dateLabel";
            hire_dateLabel.Size = new System.Drawing.Size(62, 16);
            hire_dateLabel.TabIndex = 3;
            hire_dateLabel.Text = "hire date:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(33, 111);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(44, 16);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "name:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(33, 139);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(69, 16);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "password:";
            // 
            // phone_numberLabel
            // 
            phone_numberLabel.AutoSize = true;
            phone_numberLabel.Location = new System.Drawing.Point(33, 167);
            phone_numberLabel.Name = "phone_numberLabel";
            phone_numberLabel.Size = new System.Drawing.Size(96, 16);
            phone_numberLabel.TabIndex = 9;
            phone_numberLabel.Text = "phone number:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.employeeBindingSource;
            this.comboBox1.DisplayMember = "email";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(33, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(292, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "id";
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(Relationship.employee);
            this.employeeBindingSource.CurrentChanged += new System.EventHandler(this.employeeBindingSource_CurrentChanged);
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "email", true));
            this.emailTextBox.Location = new System.Drawing.Point(135, 52);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 22);
            this.emailTextBox.TabIndex = 2;
            // 
            // hire_dateDateTimePicker
            // 
            this.hire_dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.employeeBindingSource, "hire_date", true));
            this.hire_dateDateTimePicker.Location = new System.Drawing.Point(135, 80);
            this.hire_dateDateTimePicker.Name = "hire_dateDateTimePicker";
            this.hire_dateDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.hire_dateDateTimePicker.TabIndex = 4;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(135, 108);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 22);
            this.nameTextBox.TabIndex = 6;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "password", true));
            this.passwordTextBox.Location = new System.Drawing.Point(135, 136);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(200, 22);
            this.passwordTextBox.TabIndex = 8;
            // 
            // phone_numberTextBox
            // 
            this.phone_numberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "phone_number", true));
            this.phone_numberTextBox.Location = new System.Drawing.Point(135, 164);
            this.phone_numberTextBox.Name = "phone_numberTextBox";
            this.phone_numberTextBox.Size = new System.Drawing.Size(200, 22);
            this.phone_numberTextBox.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.jobColumn,
            this.levelColumn,
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.phonenumberDataGridViewTextBoxColumn,
            this.hiredateDataGridViewTextBoxColumn,
            this.createdatDataGridViewTextBoxColumn,
            this.deletedatDataGridViewTextBoxColumn,
            this.mutationDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.promotionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.employeeBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(33, 253);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(969, 150);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "name";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.MinimumWidth = 6;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Width = 125;
            // 
            // jobColumn
            // 
            this.jobColumn.HeaderText = "Job";
            this.jobColumn.MinimumWidth = 6;
            this.jobColumn.Name = "jobColumn";
            this.jobColumn.Width = 125;
            // 
            // levelColumn
            // 
            this.levelColumn.HeaderText = "Level";
            this.levelColumn.MinimumWidth = 6;
            this.levelColumn.Name = "levelColumn";
            this.levelColumn.Width = 125;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Visible = false;
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Visible = false;
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "password";
            this.passwordDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.Visible = false;
            this.passwordDataGridViewTextBoxColumn.Width = 125;
            // 
            // phonenumberDataGridViewTextBoxColumn
            // 
            this.phonenumberDataGridViewTextBoxColumn.DataPropertyName = "phone_number";
            this.phonenumberDataGridViewTextBoxColumn.HeaderText = "phone_number";
            this.phonenumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phonenumberDataGridViewTextBoxColumn.Name = "phonenumberDataGridViewTextBoxColumn";
            this.phonenumberDataGridViewTextBoxColumn.Visible = false;
            this.phonenumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // hiredateDataGridViewTextBoxColumn
            // 
            this.hiredateDataGridViewTextBoxColumn.DataPropertyName = "hire_date";
            this.hiredateDataGridViewTextBoxColumn.HeaderText = "hire_date";
            this.hiredateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hiredateDataGridViewTextBoxColumn.Name = "hiredateDataGridViewTextBoxColumn";
            this.hiredateDataGridViewTextBoxColumn.Visible = false;
            this.hiredateDataGridViewTextBoxColumn.Width = 125;
            // 
            // createdatDataGridViewTextBoxColumn
            // 
            this.createdatDataGridViewTextBoxColumn.DataPropertyName = "created_at";
            this.createdatDataGridViewTextBoxColumn.HeaderText = "created_at";
            this.createdatDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.createdatDataGridViewTextBoxColumn.Name = "createdatDataGridViewTextBoxColumn";
            this.createdatDataGridViewTextBoxColumn.Visible = false;
            this.createdatDataGridViewTextBoxColumn.Width = 125;
            // 
            // deletedatDataGridViewTextBoxColumn
            // 
            this.deletedatDataGridViewTextBoxColumn.DataPropertyName = "deleted_at";
            this.deletedatDataGridViewTextBoxColumn.HeaderText = "deleted_at";
            this.deletedatDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deletedatDataGridViewTextBoxColumn.Name = "deletedatDataGridViewTextBoxColumn";
            this.deletedatDataGridViewTextBoxColumn.Visible = false;
            this.deletedatDataGridViewTextBoxColumn.Width = 125;
            // 
            // mutationDataGridViewTextBoxColumn
            // 
            this.mutationDataGridViewTextBoxColumn.DataPropertyName = "mutation";
            this.mutationDataGridViewTextBoxColumn.HeaderText = "mutation";
            this.mutationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mutationDataGridViewTextBoxColumn.Name = "mutationDataGridViewTextBoxColumn";
            this.mutationDataGridViewTextBoxColumn.Visible = false;
            this.mutationDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "position";
            this.positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.Visible = false;
            this.positionDataGridViewTextBoxColumn.Width = 125;
            // 
            // promotionDataGridViewTextBoxColumn
            // 
            this.promotionDataGridViewTextBoxColumn.DataPropertyName = "promotion";
            this.promotionDataGridViewTextBoxColumn.HeaderText = "promotion";
            this.promotionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.promotionDataGridViewTextBoxColumn.Name = "promotionDataGridViewTextBoxColumn";
            this.promotionDataGridViewTextBoxColumn.Visible = false;
            this.promotionDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeBindingSource1
            // 
            this.employeeBindingSource1.DataSource = typeof(Relationship.employee);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.dataGridView2.DataSource = this.employeeBindingSource2;
            this.dataGridView2.Location = new System.Drawing.Point(33, 421);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(969, 150);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Job";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Level";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn4.HeaderText = "id";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn5.HeaderText = "name";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "email";
            this.dataGridViewTextBoxColumn6.HeaderText = "email";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "password";
            this.dataGridViewTextBoxColumn7.HeaderText = "password";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "phone_number";
            this.dataGridViewTextBoxColumn8.HeaderText = "phone_number";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "hire_date";
            this.dataGridViewTextBoxColumn9.HeaderText = "hire_date";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "created_at";
            this.dataGridViewTextBoxColumn10.HeaderText = "created_at";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "deleted_at";
            this.dataGridViewTextBoxColumn11.HeaderText = "deleted_at";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 125;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "mutation";
            this.dataGridViewTextBoxColumn12.HeaderText = "mutation";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 125;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "position";
            this.dataGridViewTextBoxColumn13.HeaderText = "position";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 125;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "promotion";
            this.dataGridViewTextBoxColumn14.HeaderText = "promotion";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 125;
            // 
            // employeeBindingSource2
            // 
            this.employeeBindingSource2.DataSource = typeof(Relationship.employee);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 692);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(hire_dateLabel);
            this.Controls.Add(this.hire_dateDateTimePicker);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(phone_numberLabel);
            this.Controls.Add(this.phone_numberTextBox);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.DateTimePicker hire_dateDateTimePicker;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox phone_numberTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource employeeBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phonenumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiredateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mutationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn promotionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.BindingSource employeeBindingSource2;
    }
}

