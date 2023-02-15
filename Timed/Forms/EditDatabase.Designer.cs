namespace Timed.Forms
{
    partial class EditDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDatabase));
            this.listBoxActivities = new System.Windows.Forms.ListBox();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.textBoxActivityName = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.buttonSaveAllRecords = new System.Windows.Forms.Button();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveOnly = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxActivities
            // 
            this.listBoxActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxActivities.FormattingEnabled = true;
            this.listBoxActivities.ItemHeight = 15;
            this.listBoxActivities.Location = new System.Drawing.Point(0, 0);
            this.listBoxActivities.Name = "listBoxActivities";
            this.listBoxActivities.ScrollAlwaysVisible = true;
            this.listBoxActivities.Size = new System.Drawing.Size(397, 450);
            this.listBoxActivities.TabIndex = 0;
            this.listBoxActivities.SelectedIndexChanged += new System.EventHandler(this.ListBoxActivities_SelectedIndexChanged);
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProjectName.Location = new System.Drawing.Point(113, 70);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(274, 23);
            this.textBoxProjectName.TabIndex = 3;
            // 
            // textBoxActivityName
            // 
            this.textBoxActivityName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxActivityName.Location = new System.Drawing.Point(113, 99);
            this.textBoxActivityName.Name = "textBoxActivityName";
            this.textBoxActivityName.Size = new System.Drawing.Size(274, 23);
            this.textBoxActivityName.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxActivities);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxDuration);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSaveAllRecords);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePickerEnd);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePickerStart);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSaveOnly);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxProjectName);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxActivityName);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 397;
            this.splitContainer1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Duration";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDuration.Enabled = false;
            this.textBoxDuration.Location = new System.Drawing.Point(113, 186);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(274, 23);
            this.textBoxDuration.TabIndex = 7;
            // 
            // buttonSaveAllRecords
            // 
            this.buttonSaveAllRecords.Location = new System.Drawing.Point(141, 12);
            this.buttonSaveAllRecords.Name = "buttonSaveAllRecords";
            this.buttonSaveAllRecords.Size = new System.Drawing.Size(121, 41);
            this.buttonSaveAllRecords.TabIndex = 2;
            this.buttonSaveAllRecords.Text = "Save Names\r\n(Affect all records)";
            this.buttonSaveAllRecords.UseVisualStyleBackColor = true;
            this.buttonSaveAllRecords.Click += new System.EventHandler(this.ButtonSaveAllRecords_Click);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerEnd.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(113, 157);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(274, 23);
            this.dateTimePickerEnd.TabIndex = 6;
            this.dateTimePickerEnd.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.DateTimePickers_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Start";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerStart.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(113, 128);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(274, 23);
            this.dateTimePickerStart.TabIndex = 5;
            this.dateTimePickerStart.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.DateTimePickers_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Activity Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Name";
            // 
            // buttonSaveOnly
            // 
            this.buttonSaveOnly.Location = new System.Drawing.Point(14, 12);
            this.buttonSaveOnly.Name = "buttonSaveOnly";
            this.buttonSaveOnly.Size = new System.Drawing.Size(121, 41);
            this.buttonSaveOnly.TabIndex = 1;
            this.buttonSaveOnly.Text = "Save only \r\nthis record";
            this.buttonSaveOnly.UseVisualStyleBackColor = true;
            this.buttonSaveOnly.Click += new System.EventHandler(this.ButtonSaveOnlyOne_Click);
            // 
            // EditDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditDatabase";
            this.Text = "EditDatabase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditDatabase_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBoxActivities;
        private TextBox textBoxProjectName;
        private TextBox textBoxActivityName;
        private SplitContainer splitContainer1;
        private Button buttonSaveOnly;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Label label4;
        private Label label3;
        private Button buttonSaveAllRecords;
        private Label label5;
        private TextBox textBoxDuration;
    }
}