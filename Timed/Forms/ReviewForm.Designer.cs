namespace Timed.Forms
{
    partial class ReviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReviewForm));
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxRound = new System.Windows.Forms.CheckBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.checkBoxMergeProjectTasks = new System.Windows.Forms.CheckBox();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(11, 28);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(139, 20);
            this.dateTimePickerStart.TabIndex = 0;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.DateTimePickers_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(166, 28);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(135, 20);
            this.dateTimePickerEnd.TabIndex = 1;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.DateTimePickers_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "The morning of the:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To the evening of the:";
            // 
            // checkBoxRound
            // 
            this.checkBoxRound.AutoSize = true;
            this.checkBoxRound.Location = new System.Drawing.Point(325, 31);
            this.checkBoxRound.Name = "checkBoxRound";
            this.checkBoxRound.Size = new System.Drawing.Size(176, 17);
            this.checkBoxRound.TabIndex = 5;
            this.checkBoxRound.Text = "Round up to 15 minute intervals";
            this.checkBoxRound.UseVisualStyleBackColor = true;
            this.checkBoxRound.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(15, 55);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(471, 238);
            this.textBoxOutput.TabIndex = 6;
            // 
            // checkBoxMergeProjectTasks
            // 
            this.checkBoxMergeProjectTasks.AutoSize = true;
            this.checkBoxMergeProjectTasks.Location = new System.Drawing.Point(325, 8);
            this.checkBoxMergeProjectTasks.Name = "checkBoxMergeProjectTasks";
            this.checkBoxMergeProjectTasks.Size = new System.Drawing.Size(161, 17);
            this.checkBoxMergeProjectTasks.TabIndex = 7;
            this.checkBoxMergeProjectTasks.Text = "Merge project tasks together";
            this.checkBoxMergeProjectTasks.UseVisualStyleBackColor = true;
            this.checkBoxMergeProjectTasks.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(121, 4);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(29, 23);
            this.buttonPrevious.TabIndex = 8;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(155, 4);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(29, 23);
            this.buttonNext.TabIndex = 9;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 305);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.checkBoxMergeProjectTasks);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.checkBoxRound);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Spent Review";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReviewForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxRound;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.CheckBox checkBoxMergeProjectTasks;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
    }
}