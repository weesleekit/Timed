using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Timed.Classes;

namespace Timed.Forms
{
    public partial class ActivitySelectionForm : Form
    {
        //Nested Classes

        class RecentProject
        {
            //Properties

            public string ProjectName { get; }
            public DateTime MostRecent { get; private set; }

            //Constructor

            public RecentProject(string projectName, DateTime mostRecent)
            {
                ProjectName = projectName;
                MostRecent = mostRecent;
            }

            //Public Method

            public void TakeInActivityEndTime(DateTime dateTime)
            {
                if (dateTime > MostRecent)
                {
                    MostRecent = dateTime;
                }
            }

            //Public Override

            public override string ToString()
            {
                return ProjectName;
            }
        }

        class RecentActivity
        {
            //Properties

            public string ActivityName { get; }
            public string ProjectName { get; }
            public DateTime MostRecent { get; private set; }


            public RecentActivity(string projectName, string activityName, DateTime mostRecent)
            {
                ActivityName = activityName;
                ProjectName = projectName;
                MostRecent = mostRecent;
            }

            //Public Method

            public void TakeInActivityEndTime(DateTime dateTime)
            {
                if (dateTime > MostRecent)
                {
                    MostRecent = dateTime;
                }
            }

            //Public Override

            public override string ToString()
            {
                return ProjectName + " - " + ActivityName;
            }
        }

        //Fields

        /// <summary>
        /// The reference to the main form
        /// </summary>
        public MainForm mainForm;

        /// <summary>
        /// Set to true when the application intended the form to close
        /// </summary>
        private bool plannedClose = false;

        private readonly DateTime startPoint;

        //Constructor

        public ActivitySelectionForm(MainForm mainForm, DateTime? resumePoint = null)
        {
            //Store the main form and initialise
            this.mainForm = mainForm;
            InitializeComponent();

            if (resumePoint == null)
            {
                startPoint = DateTime.UtcNow;
            }
            else
            {
                startPoint = (DateTime)resumePoint;
            }

            //Create an aggregate of the projects with when they were most recently worked on:
            List<RecentProject> recentProjects = new List<RecentProject>();

            foreach (TimedActivity timedActivity in mainForm.TimedDataStructure.TimedActivities)
            {
                RecentProject recentProject = recentProjects.Find(x => x.ProjectName == timedActivity.ProjectName);

                if (recentProject == null)
                {
                    recentProjects.Add(new RecentProject(timedActivity.ProjectName, timedActivity.End));
                }
                else
                {
                    recentProject.TakeInActivityEndTime(timedActivity.End);
                }
            }

            //Order by most recent
            recentProjects = recentProjects.OrderBy(x => x.MostRecent).ToList();

            //Populate the listbox
            foreach(var project in recentProjects)
            {
                listBoxPreviousProjects.Items.Add(project);
            }

            //Update the UI for the tasklist
            UpdateRecentActivities(null);
        }

        //UI Events
        
        /// <summary>
        /// If enter is pressed then it's a new activity
        /// </summary>
        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxName.Text.Trim() == "" || textBoxProject.Text.Trim() == "")
                {
                    return;
                }
                else
                {
                    StartActivity(textBoxProject.Text.Trim(), textBoxName.Text.Trim());
                }
            }
        }

        /// <summary>
        /// Resuming an previous activity
        /// </summary>
        private void ListBoxPreviousActivities_DoubleClick(object sender, EventArgs e)
        {
            //See if there is an activity selected
            if (listBoxPreviousActivities.SelectedItem != null)
            {
                //Get the project
                RecentActivity recentActivity = (RecentActivity)listBoxPreviousActivities.SelectedItem;

                StartActivity(recentActivity.ProjectName, recentActivity.ActivityName);
            }
        }

        /// <summary>
        /// Filtering on previous project but also pre-populating the input box
        /// </summary>
        private void ListBoxPreviousProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            //See if there is a project selected
            if (listBoxPreviousProjects.SelectedItem != null)
            {
                //Get the project
                RecentProject recentProject = (RecentProject)listBoxPreviousProjects.SelectedItem;

                //Filter the activity to that project only
                UpdateRecentActivities(recentProject);

                //Pre-populate the project input box
                textBoxProject.Text = recentProject.ProjectName;

                //Focus on the activity input box
                textBoxName.Focus();
            }
        }

        /// <summary>
        /// Prepopulating input box
        /// </summary>
        private void ListBoxPreviousActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            //See if there is a project selected
            if (listBoxPreviousActivities.SelectedItem != null)
            {
                //Get the project
                RecentActivity recentActivity = (RecentActivity)listBoxPreviousActivities.SelectedItem;

                //Pre-populate the project input box
                textBoxProject.Text = recentActivity.ProjectName;

                //Focus on the activity input box
                textBoxName.Focus();
            }
        }

        private void ActivitySelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!plannedClose)
            {
                Application.Exit();
            }
        }

        private void ButtonLunch_Click(object sender, EventArgs e)
        {
            StartActivity("Lunch", "Lunch");
        }

        private void ButtonTeaBreak_Click(object sender, EventArgs e)
        {
            StartActivity("Break", "Tea Break");
        }

        private void ButtonColleagues_Click(object sender, EventArgs e)
        {
            StartActivity("Break", "Colleagues Nattering");
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

        private void ButtonTraining_Click(object sender, EventArgs e)
        {
            StartActivity("Training", "Training");
        }


        //Private Methods

        private void StartActivity(string projectName, string activityName)
        {
#pragma warning disable IDE0067 // Dispose objects before losing scope
            ActivityForm activityForm = new ActivityForm(projectName, activityName, mainForm, startPoint)
            {
                WindowState = FormWindowState.Minimized
            };
#pragma warning restore IDE0067 // Dispose objects before losing scope

            activityForm.Show();
            plannedClose = true;
            Close();
        }

        private void UpdateRecentActivities(RecentProject recentProject)
        {
            //Determine which activities are relevant
            List<TimedActivity> relevantTimedActivities;

            //See if there is a project selected
            if (recentProject == null)
            {
                //Show all the activity
                relevantTimedActivities = mainForm.TimedDataStructure.TimedActivities;
            }
            else
            {
                //Filter the activity to that project only
                relevantTimedActivities = mainForm.TimedDataStructure.TimedActivities.FindAll(x => x.ProjectName == recentProject.ProjectName);
            }

            //Create an aggregate of the activities with when they were most recently worked on:
            List<RecentActivity> recentActivities = new List<RecentActivity>();

            foreach (TimedActivity timedActivity in relevantTimedActivities)
            {
                RecentActivity recentActivity = recentActivities.Find(x => x.ProjectName == timedActivity.ProjectName && x.ActivityName == timedActivity.Name);

                if (recentActivity == null)
                {
                    recentActivities.Add(new RecentActivity(timedActivity.ProjectName, timedActivity.Name, timedActivity.End));
                }
                else
                {
                    recentActivity.TakeInActivityEndTime(timedActivity.End);
                }
            }

            //Order by most recent
            recentActivities = recentActivities.OrderByDescending(x => x.MostRecent).ToList();

            listBoxPreviousActivities.Items.Clear();

            //Populate the listbox
            foreach (var activity in recentActivities)
            {
                listBoxPreviousActivities.Items.Add(activity);
            }
        }

    }
}
