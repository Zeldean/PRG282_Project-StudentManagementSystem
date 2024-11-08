namespace StudentManagementSystem
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AGEtb = new System.Windows.Forms.NumericUpDown();
            this.COURSEtb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NAMEtb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IDtb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ADDbtn = new System.Windows.Forms.Button();
            this.UPDATEbtn = new System.Windows.Forms.Button();
            this.DELETEbtn = new System.Windows.Forms.Button();
            this.SUMMARYbtn = new System.Windows.Forms.Button();
            this.SEARCHtb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VIEWbtn = new System.Windows.Forms.Button();
            this.dgvDataOutput = new System.Windows.Forms.DataGridView();
            this.btnDiscardChanges = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAvgAge = new System.Windows.Forms.Label();
            this.lblStdCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AGEtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataOutput)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Controls.Add(this.COURSEtb);
            this.groupBox1.Controls.Add(this.AGEtb);
            this.groupBox1.Controls.Add(this.NAMEtb);
            this.groupBox1.Controls.Add(this.IDtb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(19, 184);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(288, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Information";
            // 
            // AGEtb
            // 
            this.AGEtb.BackColor = System.Drawing.Color.White;
            this.AGEtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AGEtb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AGEtb.Location = new System.Drawing.Point(12, 176);
            this.AGEtb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AGEtb.Name = "AGEtb";
            this.AGEtb.Size = new System.Drawing.Size(255, 30);
            this.AGEtb.TabIndex = 3;
            // 
            // COURSEtb
            // 
            this.COURSEtb.BackColor = System.Drawing.Color.White;
            this.COURSEtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.COURSEtb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.COURSEtb.Location = new System.Drawing.Point(11, 244);
            this.COURSEtb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.COURSEtb.Name = "COURSEtb";
            this.COURSEtb.Size = new System.Drawing.Size(257, 30);
            this.COURSEtb.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Course";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student ID:";
            // 
            // NAMEtb
            // 
            this.NAMEtb.BackColor = System.Drawing.Color.White;
            this.NAMEtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NAMEtb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NAMEtb.Location = new System.Drawing.Point(9, 114);
            this.NAMEtb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NAMEtb.Name = "NAMEtb";
            this.NAMEtb.Size = new System.Drawing.Size(257, 30);
            this.NAMEtb.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Age:";
            // 
            // IDtb
            // 
            this.IDtb.BackColor = System.Drawing.Color.White;
            this.IDtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IDtb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.IDtb.Location = new System.Drawing.Point(11, 53);
            this.IDtb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IDtb.Name = "IDtb";
            this.IDtb.Size = new System.Drawing.Size(255, 30);
            this.IDtb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // ADDbtn
            // 
            this.ADDbtn.BackColor = System.Drawing.Color.Pink;
            this.ADDbtn.FlatAppearance.BorderSize = 0;
            this.ADDbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ADDbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ADDbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADDbtn.ForeColor = System.Drawing.Color.Black;
            this.ADDbtn.Location = new System.Drawing.Point(19, 598);
            this.ADDbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ADDbtn.Name = "ADDbtn";
            this.ADDbtn.Size = new System.Drawing.Size(141, 37);
            this.ADDbtn.TabIndex = 1;
            this.ADDbtn.Text = "ADD";
            this.ADDbtn.UseVisualStyleBackColor = false;
            this.ADDbtn.Click += new System.EventHandler(this.ADDbtn_Click);
            // 
            // UPDATEbtn
            // 
            this.UPDATEbtn.BackColor = System.Drawing.Color.Pink;
            this.UPDATEbtn.FlatAppearance.BorderSize = 0;
            this.UPDATEbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.UPDATEbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UPDATEbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UPDATEbtn.ForeColor = System.Drawing.Color.Black;
            this.UPDATEbtn.Location = new System.Drawing.Point(165, 598);
            this.UPDATEbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UPDATEbtn.Name = "UPDATEbtn";
            this.UPDATEbtn.Size = new System.Drawing.Size(141, 37);
            this.UPDATEbtn.TabIndex = 2;
            this.UPDATEbtn.Text = "UPDATE";
            this.UPDATEbtn.UseVisualStyleBackColor = false;
            this.UPDATEbtn.Click += new System.EventHandler(this.UPDATEbtn_Click);
            // 
            // DELETEbtn
            // 
            this.DELETEbtn.BackColor = System.Drawing.Color.Pink;
            this.DELETEbtn.FlatAppearance.BorderSize = 0;
            this.DELETEbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.DELETEbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DELETEbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DELETEbtn.ForeColor = System.Drawing.Color.Black;
            this.DELETEbtn.Location = new System.Drawing.Point(19, 640);
            this.DELETEbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DELETEbtn.Name = "DELETEbtn";
            this.DELETEbtn.Size = new System.Drawing.Size(288, 37);
            this.DELETEbtn.TabIndex = 3;
            this.DELETEbtn.Text = "DELETE";
            this.DELETEbtn.UseVisualStyleBackColor = false;
            this.DELETEbtn.Click += new System.EventHandler(this.DELETEbtn_Click);
            // 
            // SUMMARYbtn
            // 
            this.SUMMARYbtn.BackColor = System.Drawing.Color.Pink;
            this.SUMMARYbtn.FlatAppearance.BorderSize = 0;
            this.SUMMARYbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SUMMARYbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SUMMARYbtn.ForeColor = System.Drawing.Color.Black;
            this.SUMMARYbtn.Location = new System.Drawing.Point(359, 640);
            this.SUMMARYbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SUMMARYbtn.Name = "SUMMARYbtn";
            this.SUMMARYbtn.Size = new System.Drawing.Size(372, 37);
            this.SUMMARYbtn.TabIndex = 4;
            this.SUMMARYbtn.Text = "SUMMARY";
            this.SUMMARYbtn.UseVisualStyleBackColor = false;
            this.SUMMARYbtn.Click += new System.EventHandler(this.SUMMARYbtn_Click);
            // 
            // SEARCHtb
            // 
            this.SEARCHtb.BackColor = System.Drawing.Color.White;
            this.SEARCHtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SEARCHtb.Location = new System.Drawing.Point(48, 64);
            this.SEARCHtb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SEARCHtb.Name = "SEARCHtb";
            this.SEARCHtb.Size = new System.Drawing.Size(221, 22);
            this.SEARCHtb.TabIndex = 6;
            this.SEARCHtb.TextChanged += new System.EventHandler(this.SEARCHtb_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(92, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Search ID:";
            // 
            // VIEWbtn
            // 
            this.VIEWbtn.BackColor = System.Drawing.Color.Pink;
            this.VIEWbtn.FlatAppearance.BorderSize = 0;
            this.VIEWbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.VIEWbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VIEWbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VIEWbtn.ForeColor = System.Drawing.Color.Black;
            this.VIEWbtn.Location = new System.Drawing.Point(18, 557);
            this.VIEWbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VIEWbtn.Name = "VIEWbtn";
            this.VIEWbtn.Size = new System.Drawing.Size(288, 37);
            this.VIEWbtn.TabIndex = 8;
            this.VIEWbtn.Text = "VIEW";
            this.VIEWbtn.UseVisualStyleBackColor = false;
            this.VIEWbtn.Click += new System.EventHandler(this.VIEWbtn_Click);
            // 
            // dgvDataOutput
            // 
            this.dgvDataOutput.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgvDataOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDataOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataOutput.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDataOutput.GridColor = System.Drawing.Color.Navy;
            this.dgvDataOutput.Location = new System.Drawing.Point(359, 48);
            this.dgvDataOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDataOutput.Name = "dgvDataOutput";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataOutput.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDataOutput.RowHeadersWidth = 50;
            this.dgvDataOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDataOutput.Size = new System.Drawing.Size(711, 544);
            this.dgvDataOutput.TabIndex = 9;
            this.dgvDataOutput.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            
            // 
            // btnDiscardChanges
            // 
            this.btnDiscardChanges.BackColor = System.Drawing.Color.Pink;
            this.btnDiscardChanges.FlatAppearance.BorderSize = 0;
            this.btnDiscardChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscardChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscardChanges.ForeColor = System.Drawing.Color.Black;
            this.btnDiscardChanges.Location = new System.Drawing.Point(879, 598);
            this.btnDiscardChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDiscardChanges.Name = "btnDiscardChanges";
            this.btnDiscardChanges.Size = new System.Drawing.Size(197, 37);
            this.btnDiscardChanges.TabIndex = 10;
            this.btnDiscardChanges.Text = "Discard Changes";
            this.btnDiscardChanges.UseVisualStyleBackColor = false;
            this.btnDiscardChanges.Click += new System.EventHandler(this.btnDiscardChanges_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.Pink;
            this.btnSaveChanges.FlatAppearance.BorderSize = 0;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.Black;
            this.btnSaveChanges.Location = new System.Drawing.Point(879, 640);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(197, 37);
            this.btnSaveChanges.TabIndex = 11;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(355, 607);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Students:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(561, 607);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Average Age:";
            // 
            // lblAvgAge
            // 
            this.lblAvgAge.AutoSize = true;
            this.lblAvgAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgAge.Location = new System.Drawing.Point(687, 607);
            this.lblAvgAge.Name = "lblAvgAge";
            this.lblAvgAge.Size = new System.Drawing.Size(19, 20);
            this.lblAvgAge.TabIndex = 13;
            this.lblAvgAge.Text = "0";
            // 
            // lblStdCount
            // 
            this.lblStdCount.AutoSize = true;
            this.lblStdCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdCount.Location = new System.Drawing.Point(488, 607);
            this.lblStdCount.Name = "lblStdCount";
            this.lblStdCount.Size = new System.Drawing.Size(19, 20);
            this.lblStdCount.TabIndex = 14;
            this.lblStdCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ADDbtn);
            this.panel1.Controls.Add(this.UPDATEbtn);
            this.panel1.Controls.Add(this.DELETEbtn);
            this.panel1.Controls.Add(this.VIEWbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 699);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.SEARCHtb);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(331, 119);
            this.panel2.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Linen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(991, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 34);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1093, 699);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStdCount);
            this.Controls.Add(this.lblAvgAge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnDiscardChanges);
            this.Controls.Add(this.dgvDataOutput);
            this.Controls.Add(this.SUMMARYbtn);
            this.ForeColor = System.Drawing.Color.Azure;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AGEtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataOutput)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox COURSEtb;
        private System.Windows.Forms.TextBox NAMEtb;
        private System.Windows.Forms.TextBox IDtb;
        private System.Windows.Forms.Button ADDbtn;
        private System.Windows.Forms.Button UPDATEbtn;
        private System.Windows.Forms.Button DELETEbtn;
        private System.Windows.Forms.Button SUMMARYbtn;
        private System.Windows.Forms.TextBox SEARCHtb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button VIEWbtn;
        private System.Windows.Forms.NumericUpDown AGEtb;
        private System.Windows.Forms.DataGridView dgvDataOutput;
        private System.Windows.Forms.Button btnDiscardChanges;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAvgAge;
        private System.Windows.Forms.Label lblStdCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

