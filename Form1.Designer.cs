namespace StudentManagementSystem
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IDtb = new System.Windows.Forms.TextBox();
            this.NAMEtb = new System.Windows.Forms.TextBox();
            this.AGEtb = new System.Windows.Forms.TextBox();
            this.COURSEtb = new System.Windows.Forms.TextBox();
            this.ADDbtn = new System.Windows.Forms.Button();
            this.UPDATEbtn = new System.Windows.Forms.Button();
            this.DELETEbtn = new System.Windows.Forms.Button();
            this.SUMMARYbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SEARCHtb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VIEWbtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.COURSEtb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.AGEtb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NAMEtb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IDtb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Age:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Course";
            // 
            // IDtb
            // 
            this.IDtb.Location = new System.Drawing.Point(9, 50);
            this.IDtb.Name = "IDtb";
            this.IDtb.Size = new System.Drawing.Size(144, 22);
            this.IDtb.TabIndex = 1;
            // 
            // NAMEtb
            // 
            this.NAMEtb.Location = new System.Drawing.Point(9, 107);
            this.NAMEtb.Name = "NAMEtb";
            this.NAMEtb.Size = new System.Drawing.Size(144, 22);
            this.NAMEtb.TabIndex = 2;
            // 
            // AGEtb
            // 
            this.AGEtb.Location = new System.Drawing.Point(9, 166);
            this.AGEtb.Name = "AGEtb";
            this.AGEtb.Size = new System.Drawing.Size(144, 22);
            this.AGEtb.TabIndex = 3;
            // 
            // COURSEtb
            // 
            this.COURSEtb.Location = new System.Drawing.Point(9, 223);
            this.COURSEtb.Name = "COURSEtb";
            this.COURSEtb.Size = new System.Drawing.Size(144, 22);
            this.COURSEtb.TabIndex = 4;
            // 
            // ADDbtn
            // 
            this.ADDbtn.Location = new System.Drawing.Point(233, 390);
            this.ADDbtn.Name = "ADDbtn";
            this.ADDbtn.Size = new System.Drawing.Size(80, 37);
            this.ADDbtn.TabIndex = 1;
            this.ADDbtn.Text = "ADD";
            this.ADDbtn.UseVisualStyleBackColor = true;
            // 
            // UPDATEbtn
            // 
            this.UPDATEbtn.Location = new System.Drawing.Point(466, 390);
            this.UPDATEbtn.Name = "UPDATEbtn";
            this.UPDATEbtn.Size = new System.Drawing.Size(82, 37);
            this.UPDATEbtn.TabIndex = 2;
            this.UPDATEbtn.Text = "UPDATE";
            this.UPDATEbtn.UseVisualStyleBackColor = true;
            // 
            // DELETEbtn
            // 
            this.DELETEbtn.Location = new System.Drawing.Point(704, 390);
            this.DELETEbtn.Name = "DELETEbtn";
            this.DELETEbtn.Size = new System.Drawing.Size(84, 37);
            this.DELETEbtn.TabIndex = 3;
            this.DELETEbtn.Text = "DELETE";
            this.DELETEbtn.UseVisualStyleBackColor = true;
            // 
            // SUMMARYbtn
            // 
            this.SUMMARYbtn.Location = new System.Drawing.Point(12, 353);
            this.SUMMARYbtn.Name = "SUMMARYbtn";
            this.SUMMARYbtn.Size = new System.Drawing.Size(87, 37);
            this.SUMMARYbtn.TabIndex = 4;
            this.SUMMARYbtn.Text = "SUMMARY";
            this.SUMMARYbtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(233, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(555, 364);
            this.dataGridView1.TabIndex = 5;
            // 
            // SEARCHtb
            // 
            this.SEARCHtb.Location = new System.Drawing.Point(32, 31);
            this.SEARCHtb.Name = "SEARCHtb";
            this.SEARCHtb.Size = new System.Drawing.Size(155, 22);
            this.SEARCHtb.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Search ID:";
            // 
            // VIEWbtn
            // 
            this.VIEWbtn.Location = new System.Drawing.Point(122, 353);
            this.VIEWbtn.Name = "VIEWbtn";
            this.VIEWbtn.Size = new System.Drawing.Size(84, 37);
            this.VIEWbtn.TabIndex = 8;
            this.VIEWbtn.Text = "VIEW";
            this.VIEWbtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VIEWbtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SEARCHtb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SUMMARYbtn);
            this.Controls.Add(this.DELETEbtn);
            this.Controls.Add(this.UPDATEbtn);
            this.Controls.Add(this.ADDbtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TextBox AGEtb;
        private System.Windows.Forms.TextBox NAMEtb;
        private System.Windows.Forms.TextBox IDtb;
        private System.Windows.Forms.Button ADDbtn;
        private System.Windows.Forms.Button UPDATEbtn;
        private System.Windows.Forms.Button DELETEbtn;
        private System.Windows.Forms.Button SUMMARYbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox SEARCHtb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button VIEWbtn;
    }
}

