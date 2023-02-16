using System.Data;
using Timed.Classes.Data;

namespace Timed.Forms
{
    public partial class ActivitySelectionForm : Form
    {
        // Fields

        private readonly MainForm mainForm;

        private readonly DateTime startPoint = DateTime.UtcNow;
        
        private bool closingFormDueToTaskStarting = false;

        private readonly string[] recentProjects;

        // Constructor

        public ActivitySelectionForm(MainForm mainForm, DateTime? resumePoint = null)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            if (resumePoint != null)
            {
                startPoint = resumePoint.Value;
            }

            recentProjects = mainForm.TimedDataStructure.GetRecentProjects().ToArray();

            listBoxPreviousProjects.Items.AddRange(recentProjects);

            UpdateRecentActivities(null);
        }

        // UI Events

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            string projectText = textBoxProject.Text.Trim();
            string nameText = textBoxName.Text.Trim();

            if (string.IsNullOrWhiteSpace(nameText) 
                || string.IsNullOrWhiteSpace(projectText))
            {
                return;
            }

            StartActivity(projectText, nameText);
        }

        private void ListBoxPreviousActivities_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxPreviousActivities.SelectedItem == null)
            {
                return;
            }

            TimedActivity timedActivity = (TimedActivity)listBoxPreviousActivities.SelectedItem;

            StartActivity(timedActivity.ProjectName, timedActivity.Name);
        }

        private void ListBoxPreviousProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPreviousProjects.SelectedItem == null)
            {
                return;
            }

            string projectName = (string)listBoxPreviousProjects.SelectedItem;

            UpdateRecentActivities(projectName);
        }

        private void ListBoxPreviousActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPreviousActivities.SelectedItem == null)
            {
                return;
            }

            TimedActivity recentActivity = (TimedActivity)listBoxPreviousActivities.SelectedItem;
            
            textBoxProject.Text = recentActivity.ProjectName;
            textBoxName.Focus();
        }

        private void ActivitySelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closingFormDueToTaskStarting)
            {
                return;
            }

            mainForm.Show();
        }

        private void TextBoxProject_TextChanged(object sender, EventArgs e)
        {
            CheckForProjectFiltering();
        }

        private void ButtonLunch_Click(object sender, EventArgs e)
        {
            StartActivity("Break", "Lunch");
        }

        private void ButtonTeaBreak_Click(object sender, EventArgs e)
        {
            StartActivity("Break", "Tea Break");
        }

        private void ButtonColleagues_Click(object sender, EventArgs e)
        {
            StartActivity("Break", "Colleagues Nattering");
        }

        private void ButtonCatAttack_Click(object sender, EventArgs e)
        {
            StartActivity("Break", "Cat Attack");
        }

        private void ButtonBabyDuty_Click(object sender, EventArgs e)
        {
            StartActivity("Break", "Baby Duty");
        }

        private void ButtonGeneral_Click(object sender, EventArgs e)
        {
            StartActivity("Indirect", "General");
        }

        private void ButtonIFSAdmin_Click(object sender, EventArgs e)
        {
            StartActivity("Indirect", "IFS Admin");
        }

        private void ButtonEmailAdmin_Click(object sender, EventArgs e)
        {
            StartActivity("Indirect", "Email Admin");
        }

        private void ButtonWorloadPlanning_Click(object sender, EventArgs e)
        {
            StartActivity("Indirect", "Workload Planning");
        }

        private void ButtonTeamMeeting_Click(object sender, EventArgs e)
        {
            StartActivity("Indirect", "Team Meeting");
        }

        private void ButtonBioBreak_Click(object sender, EventArgs e)
        {
            StartActivity("Indirect", "Biobreak");
        }

        private void ButtonTraining_Click(object sender, EventArgs e)
        {
            StartActivity("Training", "Training");
        }

        // Private Methods

        private void StartActivity(string projectName, string activityName)
        {
            TimedActivity timedActivity = new()
            {
                ProjectName = projectName,
                Name = activityName,
                Start = startPoint,
                End = startPoint,
            };

            ActivityForm activityForm = new(timedActivity, mainForm)
            {
                WindowState = FormWindowState.Minimized
            };

            activityForm.Show();
            closingFormDueToTaskStarting = true;
            Close();
        }

        private void UpdateRecentActivities(string? projectName)
        {
            IEnumerable<TimedActivity> timedActivities;
            if (projectName == null)
            {
                timedActivities = mainForm.TimedDataStructure.TimedActivities.OrderByDescending(x => x.End);
            }
            else
            {
                timedActivities = mainForm.TimedDataStructure.TimedActivities.Where(x => x.ProjectName == projectName).OrderByDescending(x => x.End);
            }

            listBoxPreviousActivities.Items.Clear();
            listBoxPreviousActivities.Items.AddRange(timedActivities.ToArray());

            textBoxProject.Text = projectName;
            textBoxName.Focus();
        }

        private void CheckForProjectFiltering()
        {
            if (string.IsNullOrWhiteSpace(textBoxProject.Text))
            {
                listBoxPreviousProjects.Items.Clear();
                listBoxPreviousProjects.Items.AddRange(recentProjects);
                return;
            }

            string searchText = textBoxProject.Text;

            string[] matchingProjects = recentProjects.Where(x => x.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).ToArray();
            
            bool onlyOneResultThatExactlyMatches = matchingProjects.Length == 1 && matchingProjects[0].ToLower() == searchText.ToLower();
            if (onlyOneResultThatExactlyMatches)
            {
                bool alreadyHasAllItems = matchingProjects.Length == listBoxPreviousProjects.Items.Count;
                if (alreadyHasAllItems)
                {
                    return;
                }

                int topIndex = listBoxPreviousProjects.TopIndex;
                listBoxPreviousProjects.Items.Clear();
                listBoxPreviousProjects.Items.AddRange(recentProjects);
                listBoxPreviousProjects.Text = matchingProjects[0];
                listBoxPreviousProjects.TopIndex = topIndex;
                return;
            }

            listBoxPreviousProjects.Items.Clear();
            listBoxPreviousProjects.Items.AddRange(matchingProjects);
        }
    }
}