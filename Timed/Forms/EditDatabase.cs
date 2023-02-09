using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timed.Classes.Data;

namespace Timed.Forms
{
    public partial class EditDatabase : Form
    {
        // Fields

        private readonly MainForm mainForm;

        // Constructor

        public EditDatabase(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            RefreshUI();
            listBoxActivities.SelectedIndex = 0;
        }

        // UI Events

        private void EditDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }

        private void ListBoxActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxActivities.SelectedItem == null)
            {
                return;
            }

            TimedActivity timedActivity = (TimedActivity)listBoxActivities.SelectedItem;

            textBoxProjectName.Text = timedActivity.ProjectName;
            textBoxActivityName.Text = timedActivity.Name;
            dateTimePickerStart.Value = timedActivity.Start;
            dateTimePickerEnd.Value = timedActivity.End;
        }

        private void ButtonSaveOnlyOne_Click(object sender, EventArgs e)
        {
            if (listBoxActivities.SelectedItem == null)
            {
                return;
            }

            TimedActivity timedActivity = (TimedActivity)listBoxActivities.SelectedItem;
            
            timedActivity.ProjectName = textBoxProjectName.Text;
            timedActivity.Name = textBoxActivityName.Text;
            timedActivity.Start = dateTimePickerStart.Value;
            timedActivity.End = dateTimePickerEnd.Value;

            RefreshUI();

            listBoxActivities.SelectedItem = timedActivity;
        }

        private void ButtonSaveAllRecords_Click(object sender, EventArgs e)
        {
            if (listBoxActivities.SelectedItem == null)
            {
                return;
            }

            TimedActivity timedActivity = (TimedActivity)listBoxActivities.SelectedItem;

            bool projectNameChanged = textBoxProjectName.Text != timedActivity.ProjectName;
            bool activityNameChanged = textBoxActivityName.Text != timedActivity.Name;

            if (projectNameChanged && activityNameChanged)
            {
                var relevantRecords = mainForm.TimedDataStructure.TimedActivities.Where(x => x.ProjectName == timedActivity.ProjectName
                                                                                          && x.Name == timedActivity.Name).ToList();
                relevantRecords.ForEach(x => x.ProjectName = textBoxProjectName.Text);
                relevantRecords.ForEach(x => x.Name = textBoxActivityName.Text);
            }
            else if (projectNameChanged)
            {
                var relevantRecords = mainForm.TimedDataStructure.TimedActivities.Where(x => x.ProjectName == timedActivity.ProjectName).ToList();
                relevantRecords.ForEach(x => x.ProjectName = textBoxProjectName.Text);
            }
            else if (activityNameChanged)
            {
                // Note, still filtering by project name
                var relevantRecords = mainForm.TimedDataStructure.TimedActivities.Where(x => x.ProjectName == timedActivity.ProjectName
                                                                                          && x.Name == timedActivity.Name).ToList();                
                relevantRecords.ForEach(x => x.Name = textBoxActivityName.Text);
            }

            RefreshUI();

            listBoxActivities.SelectedItem = timedActivity;
        }

        // Private Methods

        private void RefreshUI()
        {
            listBoxActivities.Items.Clear();
            listBoxActivities.Items.AddRange(mainForm.TimedDataStructure.TimedActivities.OrderByDescending(x => x.Start).ToArray());
        }
    }
}
