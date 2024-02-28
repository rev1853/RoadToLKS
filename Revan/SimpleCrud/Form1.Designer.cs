namespace SimpleCrud
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
            System.Windows.Forms.Label artisLabel;
            System.Windows.Forms.Label judulLabel;
            System.Windows.Forms.Label studioRekamanLabel;
            this.laguDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laguBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.artisTextBox = new System.Windows.Forms.TextBox();
            this.judulTextBox = new System.Windows.Forms.TextBox();
            this.studioRekamanTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            artisLabel = new System.Windows.Forms.Label();
            judulLabel = new System.Windows.Forms.Label();
            studioRekamanLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.laguDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laguBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // artisLabel
            // 
            artisLabel.AutoSize = true;
            artisLabel.Location = new System.Drawing.Point(196, 264);
            artisLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            artisLabel.Name = "artisLabel";
            artisLabel.Size = new System.Drawing.Size(30, 13);
            artisLabel.TabIndex = 1;
            artisLabel.Text = "Artis:";
            // 
            // judulLabel
            // 
            judulLabel.AutoSize = true;
            judulLabel.Location = new System.Drawing.Point(196, 287);
            judulLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            judulLabel.Name = "judulLabel";
            judulLabel.Size = new System.Drawing.Size(35, 13);
            judulLabel.TabIndex = 3;
            judulLabel.Text = "Judul:";
            // 
            // studioRekamanLabel
            // 
            studioRekamanLabel.AutoSize = true;
            studioRekamanLabel.Location = new System.Drawing.Point(196, 310);
            studioRekamanLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            studioRekamanLabel.Name = "studioRekamanLabel";
            studioRekamanLabel.Size = new System.Drawing.Size(89, 13);
            studioRekamanLabel.TabIndex = 5;
            studioRekamanLabel.Text = "Studio Rekaman:";
            // 
            // laguDataGridView
            // 
            this.laguDataGridView.AllowUserToAddRows = false;
            this.laguDataGridView.AutoGenerateColumns = false;
            this.laguDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.laguDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.laguDataGridView.DataSource = this.laguBindingSource;
            this.laguDataGridView.Location = new System.Drawing.Point(96, 28);
            this.laguDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.laguDataGridView.Name = "laguDataGridView";
            this.laguDataGridView.RowHeadersWidth = 51;
            this.laguDataGridView.RowTemplate.Height = 24;
            this.laguDataGridView.Size = new System.Drawing.Size(496, 179);
            this.laguDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Judul";
            this.dataGridViewTextBoxColumn2.HeaderText = "Judul";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Artis";
            this.dataGridViewTextBoxColumn3.HeaderText = "Artis";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "StudioRekaman";
            this.dataGridViewTextBoxColumn4.HeaderText = "StudioRekaman";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // laguBindingSource
            // 
            this.laguBindingSource.DataSource = typeof(SimpleCrud.Lagu2);
            // 
            // artisTextBox
            // 
            this.artisTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.laguBindingSource, "Artis", true));
            this.artisTextBox.Location = new System.Drawing.Point(284, 262);
            this.artisTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.artisTextBox.Name = "artisTextBox";
            this.artisTextBox.Size = new System.Drawing.Size(210, 20);
            this.artisTextBox.TabIndex = 2;
            // 
            // judulTextBox
            // 
            this.judulTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.laguBindingSource, "Judul", true));
            this.judulTextBox.Location = new System.Drawing.Point(284, 284);
            this.judulTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.judulTextBox.Name = "judulTextBox";
            this.judulTextBox.Size = new System.Drawing.Size(210, 20);
            this.judulTextBox.TabIndex = 4;
            // 
            // studioRekamanTextBox
            // 
            this.studioRekamanTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.laguBindingSource, "StudioRekaman", true));
            this.studioRekamanTextBox.Location = new System.Drawing.Point(284, 307);
            this.studioRekamanTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.studioRekamanTextBox.Name = "studioRekamanTextBox";
            this.studioRekamanTextBox.Size = new System.Drawing.Size(210, 20);
            this.studioRekamanTextBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 338);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(518, 212);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 26);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(artisLabel);
            this.Controls.Add(this.artisTextBox);
            this.Controls.Add(judulLabel);
            this.Controls.Add(this.judulTextBox);
            this.Controls.Add(studioRekamanLabel);
            this.Controls.Add(this.studioRekamanTextBox);
            this.Controls.Add(this.laguDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.laguDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laguBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource laguBindingSource;
        private System.Windows.Forms.DataGridView laguDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox artisTextBox;
        private System.Windows.Forms.TextBox judulTextBox;
        private System.Windows.Forms.TextBox studioRekamanTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

