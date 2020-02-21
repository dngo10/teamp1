namespace WindowsFormsApp4
{
    partial class NewProjectForm
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
            this.oldLocationTextBox = new System.Windows.Forms.TextBox();
            this.newLocationTextBox = new System.Windows.Forms.TextBox();
            this.oldLocationButtonSearch = new System.Windows.Forms.Button();
            this.newLocationButtonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sn1CheckBox = new System.Windows.Forms.CheckBox();
            this.sn2CheckBox = new System.Windows.Forms.CheckBox();
            this.sd2CheckBox = new System.Windows.Forms.CheckBox();
            this.runButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // oldLocationTextBox
            // 
            this.oldLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.oldLocationTextBox.BackColor = System.Drawing.Color.LightGray;
            this.oldLocationTextBox.Location = new System.Drawing.Point(99, 21);
            this.oldLocationTextBox.Name = "oldLocationTextBox";
            this.oldLocationTextBox.Size = new System.Drawing.Size(354, 20);
            this.oldLocationTextBox.TabIndex = 0;
            // 
            // newLocationTextBox
            // 
            this.newLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.newLocationTextBox.Location = new System.Drawing.Point(99, 48);
            this.newLocationTextBox.Name = "newLocationTextBox";
            this.newLocationTextBox.Size = new System.Drawing.Size(354, 20);
            this.newLocationTextBox.TabIndex = 1;
            // 
            // oldLocationButtonSearch
            // 
            this.oldLocationButtonSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.oldLocationButtonSearch.Location = new System.Drawing.Point(459, 19);
            this.oldLocationButtonSearch.Name = "oldLocationButtonSearch";
            this.oldLocationButtonSearch.Size = new System.Drawing.Size(33, 23);
            this.oldLocationButtonSearch.TabIndex = 2;
            this.oldLocationButtonSearch.Text = "...";
            this.oldLocationButtonSearch.UseVisualStyleBackColor = true;
            this.oldLocationButtonSearch.Click += new System.EventHandler(this.oldLocationButtonSearch_Click);
            // 
            // newLocationButtonSearch
            // 
            this.newLocationButtonSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.newLocationButtonSearch.Location = new System.Drawing.Point(459, 46);
            this.newLocationButtonSearch.Name = "newLocationButtonSearch";
            this.newLocationButtonSearch.Size = new System.Drawing.Size(33, 23);
            this.newLocationButtonSearch.TabIndex = 3;
            this.newLocationButtonSearch.Text = "...";
            this.newLocationButtonSearch.UseVisualStyleBackColor = true;
            this.newLocationButtonSearch.Click += new System.EventHandler(this.newLocationButtonSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Old Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "New Location";
            // 
            // sn1CheckBox
            // 
            this.sn1CheckBox.AutoSize = true;
            this.sn1CheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.sn1CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sn1CheckBox.Location = new System.Drawing.Point(16, 19);
            this.sn1CheckBox.Name = "sn1CheckBox";
            this.sn1CheckBox.Size = new System.Drawing.Size(67, 17);
            this.sn1CheckBox.TabIndex = 6;
            this.sn1CheckBox.Text = "new SN1";
            this.sn1CheckBox.UseVisualStyleBackColor = true;
            // 
            // sn2CheckBox
            // 
            this.sn2CheckBox.AutoSize = true;
            this.sn2CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sn2CheckBox.Location = new System.Drawing.Point(16, 42);
            this.sn2CheckBox.Name = "sn2CheckBox";
            this.sn2CheckBox.Size = new System.Drawing.Size(67, 17);
            this.sn2CheckBox.TabIndex = 7;
            this.sn2CheckBox.Text = "new SN2";
            this.sn2CheckBox.UseVisualStyleBackColor = true;
            // 
            // sd2CheckBox
            // 
            this.sd2CheckBox.AutoSize = true;
            this.sd2CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sd2CheckBox.Location = new System.Drawing.Point(16, 65);
            this.sd2CheckBox.Name = "sd2CheckBox";
            this.sd2CheckBox.Size = new System.Drawing.Size(67, 17);
            this.sd2CheckBox.TabIndex = 8;
            this.sd2CheckBox.Text = "new SD2";
            this.sd2CheckBox.UseVisualStyleBackColor = true;
            // 
            // runButton
            // 
            this.runButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.runButton.Location = new System.Drawing.Point(238, 382);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(149, 23);
            this.runButton.TabIndex = 9;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 147);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(610, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 176);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(610, 157);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "Status...\n\n\n\n\n";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 121);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "Status";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "asdff",
            "d",
            "dd",
            "d",
            "d",
            "d",
            "fd",
            "sd",
            "fs"});
            this.comboBox1.Location = new System.Drawing.Point(570, 384);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(52, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Language";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(4, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 252);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.oldLocationButtonSearch);
            this.groupBox2.Controls.Add(this.oldLocationTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.newLocationTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.newLocationButtonSearch);
            this.groupBox2.Location = new System.Drawing.Point(4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 94);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.sd2CheckBox);
            this.groupBox3.Controls.Add(this.sn1CheckBox);
            this.groupBox3.Controls.Add(this.sn2CheckBox);
            this.groupBox3.Location = new System.Drawing.Point(508, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(125, 94);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Location = new System.Drawing.Point(4, 361);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(629, 56);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 419);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "NewProjectForm";
            this.Text = "Scooby Scooby Doo, Where are you!";
            this.Load += new System.EventHandler(this.NewProjectForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oldLocationTextBox;
        private System.Windows.Forms.TextBox newLocationTextBox;
        private System.Windows.Forms.Button oldLocationButtonSearch;
        private System.Windows.Forms.Button newLocationButtonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox sn1CheckBox;
        private System.Windows.Forms.CheckBox sn2CheckBox;
        private System.Windows.Forms.CheckBox sd2CheckBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

