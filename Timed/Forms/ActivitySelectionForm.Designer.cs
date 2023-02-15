namespace Timed.Forms
{
    partial class ActivitySelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivitySelectionForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProject = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxPreviousActivities = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxPreviousProjects = new System.Windows.Forms.ListBox();
            this.buttonTeaBreak = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonBioBreak = new System.Windows.Forms.Button();
            this.buttonTeamMeeting = new System.Windows.Forms.Button();
            this.buttonEmailAdmin = new System.Windows.Forms.Button();
            this.buttonWorloadPlanning = new System.Windows.Forms.Button();
            this.buttonGeneral = new System.Windows.Forms.Button();
            this.buttonIFSAdmin = new System.Windows.Forms.Button();
            this.buttonColleagues = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonBabyDuty = new System.Windows.Forms.Button();
            this.buttonCatAttack = new System.Windows.Forms.Button();
            this.buttonLunch = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxProject);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Activity      (type description then press enter to start a new task)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Project";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Activity Description";
            // 
            // textBoxProject
            // 
            this.textBoxProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProject.Location = new System.Drawing.Point(123, 19);
            this.textBoxProject.Name = "textBoxProject";
            this.textBoxProject.Size = new System.Drawing.Size(288, 23);
            this.textBoxProject.TabIndex = 0;
            this.textBoxProject.TextChanged += new System.EventHandler(this.TextBoxProject_TextChanged);
            this.textBoxProject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(123, 45);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(288, 23);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listBoxPreviousActivities);
            this.groupBox2.Location = new System.Drawing.Point(12, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 230);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Previous Tasks      (double click to resume task)";
            // 
            // listBoxPreviousActivities
            // 
            this.listBoxPreviousActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPreviousActivities.FormattingEnabled = true;
            this.listBoxPreviousActivities.ItemHeight = 15;
            this.listBoxPreviousActivities.Location = new System.Drawing.Point(7, 20);
            this.listBoxPreviousActivities.Name = "listBoxPreviousActivities";
            this.listBoxPreviousActivities.ScrollAlwaysVisible = true;
            this.listBoxPreviousActivities.Size = new System.Drawing.Size(404, 199);
            this.listBoxPreviousActivities.TabIndex = 0;
            this.listBoxPreviousActivities.SelectedIndexChanged += new System.EventHandler(this.ListBoxPreviousActivities_SelectedIndexChanged);
            this.listBoxPreviousActivities.DoubleClick += new System.EventHandler(this.ListBoxPreviousActivities_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listBoxPreviousProjects);
            this.groupBox3.Location = new System.Drawing.Point(12, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 148);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Previous Projects      (click to select and filter previous tasks)";
            // 
            // listBoxPreviousProjects
            // 
            this.listBoxPreviousProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPreviousProjects.FormattingEnabled = true;
            this.listBoxPreviousProjects.ItemHeight = 15;
            this.listBoxPreviousProjects.Location = new System.Drawing.Point(6, 19);
            this.listBoxPreviousProjects.Name = "listBoxPreviousProjects";
            this.listBoxPreviousProjects.ScrollAlwaysVisible = true;
            this.listBoxPreviousProjects.Size = new System.Drawing.Size(404, 109);
            this.listBoxPreviousProjects.TabIndex = 1;
            this.listBoxPreviousProjects.SelectedIndexChanged += new System.EventHandler(this.ListBoxPreviousProjects_SelectedIndexChanged);
            // 
            // buttonTeaBreak
            // 
            this.buttonTeaBreak.Location = new System.Drawing.Point(6, 52);
            this.buttonTeaBreak.Name = "buttonTeaBreak";
            this.buttonTeaBreak.Size = new System.Drawing.Size(177, 23);
            this.buttonTeaBreak.TabIndex = 51;
            this.buttonTeaBreak.Text = "Tea break";
            this.buttonTeaBreak.UseVisualStyleBackColor = true;
            this.buttonTeaBreak.Click += new System.EventHandler(this.ButtonTeaBreak_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.buttonBioBreak);
            this.groupBox4.Controls.Add(this.buttonTeamMeeting);
            this.groupBox4.Controls.Add(this.buttonEmailAdmin);
            this.groupBox4.Controls.Add(this.buttonWorloadPlanning);
            this.groupBox4.Controls.Add(this.buttonGeneral);
            this.groupBox4.Controls.Add(this.buttonIFSAdmin);
            this.groupBox4.Location = new System.Drawing.Point(441, 194);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(189, 198);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Indirect";
            // 
            // buttonBioBreak
            // 
            this.buttonBioBreak.Location = new System.Drawing.Point(6, 164);
            this.buttonBioBreak.Name = "buttonBioBreak";
            this.buttonBioBreak.Size = new System.Drawing.Size(177, 23);
            this.buttonBioBreak.TabIndex = 58;
            this.buttonBioBreak.Text = "Bio Break";
            this.buttonBioBreak.UseVisualStyleBackColor = true;
            this.buttonBioBreak.Click += new System.EventHandler(this.ButtonBioBreak_Click);
            // 
            // buttonTeamMeeting
            // 
            this.buttonTeamMeeting.Location = new System.Drawing.Point(6, 135);
            this.buttonTeamMeeting.Name = "buttonTeamMeeting";
            this.buttonTeamMeeting.Size = new System.Drawing.Size(177, 23);
            this.buttonTeamMeeting.TabIndex = 57;
            this.buttonTeamMeeting.Text = "Team Meeting";
            this.buttonTeamMeeting.UseVisualStyleBackColor = true;
            this.buttonTeamMeeting.Click += new System.EventHandler(this.ButtonTeamMeeting_Click);
            // 
            // buttonEmailAdmin
            // 
            this.buttonEmailAdmin.Location = new System.Drawing.Point(6, 77);
            this.buttonEmailAdmin.Name = "buttonEmailAdmin";
            this.buttonEmailAdmin.Size = new System.Drawing.Size(177, 23);
            this.buttonEmailAdmin.TabIndex = 55;
            this.buttonEmailAdmin.Text = "Email Admin e.g. Tidying";
            this.buttonEmailAdmin.UseVisualStyleBackColor = true;
            this.buttonEmailAdmin.Click += new System.EventHandler(this.ButtonEmailAdmin_Click);
            // 
            // buttonWorloadPlanning
            // 
            this.buttonWorloadPlanning.Location = new System.Drawing.Point(6, 106);
            this.buttonWorloadPlanning.Name = "buttonWorloadPlanning";
            this.buttonWorloadPlanning.Size = new System.Drawing.Size(177, 23);
            this.buttonWorloadPlanning.TabIndex = 56;
            this.buttonWorloadPlanning.Text = "Workload Planning";
            this.buttonWorloadPlanning.UseVisualStyleBackColor = true;
            this.buttonWorloadPlanning.Click += new System.EventHandler(this.ButtonWorloadPlanning_Click);
            // 
            // buttonGeneral
            // 
            this.buttonGeneral.Location = new System.Drawing.Point(6, 19);
            this.buttonGeneral.Name = "buttonGeneral";
            this.buttonGeneral.Size = new System.Drawing.Size(177, 23);
            this.buttonGeneral.TabIndex = 53;
            this.buttonGeneral.Text = "General";
            this.buttonGeneral.UseVisualStyleBackColor = true;
            this.buttonGeneral.Click += new System.EventHandler(this.ButtonGeneral_Click);
            // 
            // buttonIFSAdmin
            // 
            this.buttonIFSAdmin.Location = new System.Drawing.Point(6, 48);
            this.buttonIFSAdmin.Name = "buttonIFSAdmin";
            this.buttonIFSAdmin.Size = new System.Drawing.Size(177, 23);
            this.buttonIFSAdmin.TabIndex = 54;
            this.buttonIFSAdmin.Text = "IFS Admin: Timesheets/Expenses";
            this.buttonIFSAdmin.UseVisualStyleBackColor = true;
            this.buttonIFSAdmin.Click += new System.EventHandler(this.ButtonIFSAdmin_Click);
            // 
            // buttonColleagues
            // 
            this.buttonColleagues.Location = new System.Drawing.Point(6, 81);
            this.buttonColleagues.Name = "buttonColleagues";
            this.buttonColleagues.Size = new System.Drawing.Size(177, 23);
            this.buttonColleagues.TabIndex = 52;
            this.buttonColleagues.Text = "Colleagues Nattering";
            this.buttonColleagues.UseVisualStyleBackColor = true;
            this.buttonColleagues.Click += new System.EventHandler(this.ButtonColleagues_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.buttonBabyDuty);
            this.groupBox6.Controls.Add(this.buttonCatAttack);
            this.groupBox6.Controls.Add(this.buttonLunch);
            this.groupBox6.Controls.Add(this.buttonColleagues);
            this.groupBox6.Controls.Add(this.buttonTeaBreak);
            this.groupBox6.Location = new System.Drawing.Point(441, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(189, 171);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Breaks";
            // 
            // buttonBabyDuty
            // 
            this.buttonBabyDuty.Location = new System.Drawing.Point(6, 139);
            this.buttonBabyDuty.Name = "buttonBabyDuty";
            this.buttonBabyDuty.Size = new System.Drawing.Size(177, 23);
            this.buttonBabyDuty.TabIndex = 54;
            this.buttonBabyDuty.Text = "Baby Duty";
            this.buttonBabyDuty.UseVisualStyleBackColor = true;
            this.buttonBabyDuty.Click += new System.EventHandler(this.ButtonBabyDuty_Click);
            // 
            // buttonCatAttack
            // 
            this.buttonCatAttack.Location = new System.Drawing.Point(6, 110);
            this.buttonCatAttack.Name = "buttonCatAttack";
            this.buttonCatAttack.Size = new System.Drawing.Size(177, 23);
            this.buttonCatAttack.TabIndex = 53;
            this.buttonCatAttack.Text = "Cat Attack";
            this.buttonCatAttack.UseVisualStyleBackColor = true;
            this.buttonCatAttack.Click += new System.EventHandler(this.ButtonCatAttack_Click);
            // 
            // buttonLunch
            // 
            this.buttonLunch.Location = new System.Drawing.Point(6, 22);
            this.buttonLunch.Name = "buttonLunch";
            this.buttonLunch.Size = new System.Drawing.Size(177, 23);
            this.buttonLunch.TabIndex = 50;
            this.buttonLunch.Text = "Lunch";
            this.buttonLunch.UseVisualStyleBackColor = true;
            this.buttonLunch.Click += new System.EventHandler(this.ButtonLunch_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.buttonTraining);
            this.groupBox5.Location = new System.Drawing.Point(441, 405);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(189, 61);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Training";
            // 
            // buttonTraining
            // 
            this.buttonTraining.Location = new System.Drawing.Point(6, 22);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(177, 23);
            this.buttonTraining.TabIndex = 58;
            this.buttonTraining.Text = "Training";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.ButtonTraining_Click);
            // 
            // ActivitySelectionForm
            // 
            this.ClientSize = new System.Drawing.Size(636, 489);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActivitySelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Define Activity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActivitySelectionForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxProject;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ListBox listBoxPreviousActivities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxPreviousProjects;
        private System.Windows.Forms.Button buttonTeaBreak;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonColleagues;
        private System.Windows.Forms.Button buttonIFSAdmin;
        private System.Windows.Forms.Button buttonEmailAdmin;
        private System.Windows.Forms.Button buttonWorloadPlanning;
        private System.Windows.Forms.Button buttonGeneral;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonLunch;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.Button buttonTeamMeeting;
        private System.Windows.Forms.Button buttonBioBreak;
        private System.Windows.Forms.Button buttonCatAttack;
        private System.Windows.Forms.Button buttonBabyDuty;
    }
}