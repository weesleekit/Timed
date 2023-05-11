namespace Timed.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonReview = new System.Windows.Forms.Button();
            this.buttonPrivacy = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.buttonEditDatabase = new System.Windows.Forms.Button();
            this.timerUIRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(14, 14);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(180, 63);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start New Task\r\nFrom Now";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // buttonReview
            // 
            this.buttonReview.Location = new System.Drawing.Point(14, 244);
            this.buttonReview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonReview.Name = "buttonReview";
            this.buttonReview.Size = new System.Drawing.Size(180, 63);
            this.buttonReview.TabIndex = 4;
            this.buttonReview.Text = "Activity Report";
            this.buttonReview.UseVisualStyleBackColor = true;
            this.buttonReview.Click += new System.EventHandler(this.ButtonReview_Click);
            // 
            // buttonPrivacy
            // 
            this.buttonPrivacy.Location = new System.Drawing.Point(14, 313);
            this.buttonPrivacy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPrivacy.Name = "buttonPrivacy";
            this.buttonPrivacy.Size = new System.Drawing.Size(180, 63);
            this.buttonPrivacy.TabIndex = 5;
            this.buttonPrivacy.Text = "Privacy Statement";
            this.buttonPrivacy.UseVisualStyleBackColor = true;
            this.buttonPrivacy.Click += new System.EventHandler(this.ButtonPrivacy_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.Enabled = false;
            this.buttonResume.Location = new System.Drawing.Point(14, 83);
            this.buttonResume.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(180, 63);
            this.buttonResume.TabIndex = 1;
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.ButtonResume_Click);
            // 
            // buttonEditDatabase
            // 
            this.buttonEditDatabase.Location = new System.Drawing.Point(13, 175);
            this.buttonEditDatabase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonEditDatabase.Name = "buttonEditDatabase";
            this.buttonEditDatabase.Size = new System.Drawing.Size(180, 63);
            this.buttonEditDatabase.TabIndex = 3;
            this.buttonEditDatabase.Text = "Edit Database";
            this.buttonEditDatabase.UseVisualStyleBackColor = true;
            this.buttonEditDatabase.Click += new System.EventHandler(this.ButtonEditDatabase_Click);
            // 
            // timerUIRefresh
            // 
            this.timerUIRefresh.Enabled = true;
            this.timerUIRefresh.Interval = 1000;
            this.timerUIRefresh.Tick += new System.EventHandler(this.TimerUIRefresh_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(208, 390);
            this.Controls.Add(this.buttonEditDatabase);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.buttonPrivacy);
            this.Controls.Add(this.buttonReview);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonReview;
        private System.Windows.Forms.Button buttonPrivacy;
        private System.Windows.Forms.Button buttonResume;
        private Button buttonEditDatabase;
        private System.Windows.Forms.Timer timerUIRefresh;
    }
}