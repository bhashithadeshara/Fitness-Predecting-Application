
namespace FitnessPersonal
{
    partial class Home
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWorkOut = new System.Windows.Forms.ComboBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCheatMeal = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtWorkOutDuration = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWorkOutType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpWorkoutDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnViewAnalizeData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLoggedUserName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.workOutDataGrid = new System.Windows.Forms.DataGridView();
            this.Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workOutDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workOutTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workOutDurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheatMealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workOutDetailBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.workOutDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.workOutDataBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workOutDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOutDetailBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOutDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOutDataBindingSource5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workout Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Workut (Done/Not)";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(239, 274);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(312, 31);
            this.txtWeight.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Weight (Kg)";
            // 
            // cmbWorkOut
            // 
            this.cmbWorkOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWorkOut.FormattingEnabled = true;
            this.cmbWorkOut.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbWorkOut.Location = new System.Drawing.Point(239, 116);
            this.cmbWorkOut.Name = "cmbWorkOut";
            this.cmbWorkOut.Size = new System.Drawing.Size(312, 37);
            this.cmbWorkOut.TabIndex = 6;
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(237, 326);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(314, 33);
            this.txtHeight.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height (cm)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cheat Meal";
            // 
            // cmbCheatMeal
            // 
            this.cmbCheatMeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCheatMeal.FormattingEnabled = true;
            this.cmbCheatMeal.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbCheatMeal.Location = new System.Drawing.Point(237, 378);
            this.cmbCheatMeal.Name = "cmbCheatMeal";
            this.cmbCheatMeal.Size = new System.Drawing.Size(314, 37);
            this.cmbCheatMeal.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtWorkOutDuration);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtWorkOutType);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dtpWorkoutDate);
            this.panel1.Controls.Add(this.cmbCheatMeal);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.txtWeight);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbWorkOut);
            this.panel1.Location = new System.Drawing.Point(12, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 430);
            this.panel1.TabIndex = 11;
            // 
            // txtWorkOutDuration
            // 
            this.txtWorkOutDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkOutDuration.Location = new System.Drawing.Point(239, 222);
            this.txtWorkOutDuration.Name = "txtWorkOutDuration";
            this.txtWorkOutDuration.Size = new System.Drawing.Size(312, 33);
            this.txtWorkOutDuration.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(179, 25);
            this.label12.TabIndex = 14;
            this.label12.Text = "Workout Duration";
            // 
            // txtWorkOutType
            // 
            this.txtWorkOutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkOutType.Location = new System.Drawing.Point(239, 172);
            this.txtWorkOutType.Name = "txtWorkOutType";
            this.txtWorkOutType.Size = new System.Drawing.Size(312, 31);
            this.txtWorkOutType.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 25);
            this.label11.TabIndex = 12;
            this.label11.Text = "Workout Type";
            // 
            // dtpWorkoutDate
            // 
            this.dtpWorkoutDate.Location = new System.Drawing.Point(239, 70);
            this.dtpWorkoutDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpWorkoutDate.Name = "dtpWorkoutDate";
            this.dtpWorkoutDate.Size = new System.Drawing.Size(312, 26);
            this.dtpWorkoutDate.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(249, 619);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 49);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Submit";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(409, 619);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 49);
            this.button2.TabIndex = 14;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnExportReport
            // 
            this.btnExportReport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportReport.Location = new System.Drawing.Point(822, 686);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(195, 54);
            this.btnExportReport.TabIndex = 17;
            this.btnExportReport.Text = "Export Report";
            this.btnExportReport.UseVisualStyleBackColor = false;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(1513, 686);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(195, 54);
            this.btnClearAll.TabIndex = 18;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnViewAnalizeData
            // 
            this.btnViewAnalizeData.BackColor = System.Drawing.Color.SteelBlue;
            this.btnViewAnalizeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAnalizeData.Location = new System.Drawing.Point(589, 686);
            this.btnViewAnalizeData.Name = "btnViewAnalizeData";
            this.btnViewAnalizeData.Size = new System.Drawing.Size(195, 54);
            this.btnViewAnalizeData.TabIndex = 19;
            this.btnViewAnalizeData.Text = "View Analized Data";
            this.btnViewAnalizeData.UseVisualStyleBackColor = false;
            this.btnViewAnalizeData.Click += new System.EventHandler(this.btnViewAnalizeData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(124, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(303, 46);
            this.label6.TabIndex = 20;
            this.label6.Text = "Workout Details";
            // 
            // lblLoggedUserName
            // 
            this.lblLoggedUserName.AutoSize = true;
            this.lblLoggedUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedUserName.ForeColor = System.Drawing.Color.Black;
            this.lblLoggedUserName.Location = new System.Drawing.Point(1490, 18);
            this.lblLoggedUserName.Name = "lblLoggedUserName";
            this.lblLoggedUserName.Size = new System.Drawing.Size(132, 32);
            this.lblLoggedUserName.TabIndex = 21;
            this.lblLoggedUserName.Text = "Welcome";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1634, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 22;
            this.label9.Text = "Log Out";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // workOutDataGrid
            // 
            this.workOutDataGrid.AutoGenerateColumns = false;
            this.workOutDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workOutDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.workOutDateDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.workOutTypeDataGridViewTextBoxColumn,
            this.workOutDurationDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.heightDataGridViewTextBoxColumn,
            this.cheatMealDataGridViewTextBoxColumn,
            this.Update,
            this.Delete,
            this.userIdDataGridViewTextBoxColumn,
            this.userDataGridViewTextBoxColumn});
            this.workOutDataGrid.DataSource = this.workOutDetailBindingSource1;
            this.workOutDataGrid.Location = new System.Drawing.Point(589, 152);
            this.workOutDataGrid.Name = "workOutDataGrid";
            this.workOutDataGrid.RowHeadersWidth = 62;
            this.workOutDataGrid.RowTemplate.Height = 28;
            this.workOutDataGrid.Size = new System.Drawing.Size(1119, 515);
            this.workOutDataGrid.TabIndex = 23;
            this.workOutDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.workOutDataGrid_CellContentClick);
            // 
            // Update
            // 
            this.Update.HeaderText = "Update";
            this.Update.MinimumWidth = 8;
            this.Update.Name = "Update";
            this.Update.Text = "Update";
            this.Update.ToolTipText = "Update";
            this.Update.UseColumnTextForButtonValue = true;
            this.Update.Width = 150;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 8;
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 150;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // workOutDateDataGridViewTextBoxColumn
            // 
            this.workOutDateDataGridViewTextBoxColumn.DataPropertyName = "WorkOutDate";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workOutDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.workOutDateDataGridViewTextBoxColumn.HeaderText = "Workout Date";
            this.workOutDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.workOutDateDataGridViewTextBoxColumn.Name = "workOutDateDataGridViewTextBoxColumn";
            this.workOutDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WorkOut";
            this.dataGridViewTextBoxColumn1.HeaderText = "Workout (Done/Not)";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // workOutTypeDataGridViewTextBoxColumn
            // 
            this.workOutTypeDataGridViewTextBoxColumn.DataPropertyName = "WorkOutType";
            this.workOutTypeDataGridViewTextBoxColumn.HeaderText = "Workout Type";
            this.workOutTypeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.workOutTypeDataGridViewTextBoxColumn.Name = "workOutTypeDataGridViewTextBoxColumn";
            this.workOutTypeDataGridViewTextBoxColumn.Width = 150;
            // 
            // workOutDurationDataGridViewTextBoxColumn
            // 
            this.workOutDurationDataGridViewTextBoxColumn.DataPropertyName = "WorkOutDuration";
            this.workOutDurationDataGridViewTextBoxColumn.HeaderText = "Workout Duration (min)";
            this.workOutDurationDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.workOutDurationDataGridViewTextBoxColumn.Name = "workOutDurationDataGridViewTextBoxColumn";
            this.workOutDurationDataGridViewTextBoxColumn.Width = 150;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            this.weightDataGridViewTextBoxColumn.HeaderText = "Weight (kg)";
            this.weightDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.Width = 150;
            // 
            // heightDataGridViewTextBoxColumn
            // 
            this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
            this.heightDataGridViewTextBoxColumn.HeaderText = "Height (cm)";
            this.heightDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
            this.heightDataGridViewTextBoxColumn.Width = 150;
            // 
            // cheatMealDataGridViewTextBoxColumn
            // 
            this.cheatMealDataGridViewTextBoxColumn.DataPropertyName = "CheatMeal";
            this.cheatMealDataGridViewTextBoxColumn.HeaderText = "CheatMeal";
            this.cheatMealDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cheatMealDataGridViewTextBoxColumn.Name = "cheatMealDataGridViewTextBoxColumn";
            this.cheatMealDataGridViewTextBoxColumn.Width = 150;
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            this.userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            this.userIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            this.userIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            this.userIdDataGridViewTextBoxColumn.Visible = false;
            this.userIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.DataPropertyName = "User";
            this.userDataGridViewTextBoxColumn.HeaderText = "User";
            this.userDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.Visible = false;
            this.userDataGridViewTextBoxColumn.Width = 150;
            // 
            // workOutDetailBindingSource1
            // 
            this.workOutDetailBindingSource1.DataSource = typeof(FitnessPersonal.WorkOutDetail);
            // 
            // workOutDetailBindingSource
            // 
            this.workOutDetailBindingSource.DataSource = typeof(FitnessPersonal.WorkOutDetail);
            // 
            // workOutDataBindingSource5
            // 
            this.workOutDataBindingSource5.DataSource = typeof(FitnessPersonal.WorkOutDetail);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1924, 788);
            this.Controls.Add(this.workOutDataGrid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblLoggedUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnViewAnalizeData);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.Name = "Home";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workOutDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOutDetailBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOutDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOutDataBindingSource5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbWorkOut;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCheatMeal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnViewAnalizeData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource workOutDataBindingSource5;
        private System.Windows.Forms.Label lblLoggedUserName;
        private System.Windows.Forms.DateTimePicker dtpWorkoutDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtWorkOutDuration;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtWorkOutType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView workOutDataGrid;
        private System.Windows.Forms.BindingSource workOutDetailBindingSource;
        private System.Windows.Forms.BindingSource workOutDetailBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workOutDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn workOutTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workOutDurationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheatMealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Update;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
    }
}

