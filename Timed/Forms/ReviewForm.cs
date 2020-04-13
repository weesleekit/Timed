using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timed.Classes;

namespace Timed.Forms
{
    public partial class ReviewForm : Form
    {
        //Nested Classes

        /// <summary>
        /// A small wrapper to total up time spend based on a task name
        /// </summary>
        class ActivityTimeSpentCounter
        {
            public TimeSpan timeSpent;

            public string ProjectName;

            public string ActivityName;

            public ActivityTimeSpentCounter(string projectName, string activityName, TimeSpan timeSpent)
            {
                ProjectName = projectName;
                ActivityName = activityName;
                this.timeSpent = timeSpent;
            }

            public void AddTime(TimeSpan timeToAdd)
            {
                timeSpent += timeToAdd;
            }
        }

        //Fields

        /// <summary>
        /// The reference to the main form
        /// </summary>
        public MainForm mainForm;

        //Constructor

        public ReviewForm(MainForm main)
        {
            //Store the main forma and initialise
            this.mainForm = main;
            InitializeComponent();

            //Set up the UI
            dateTimePickerStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTimePickerEnd.Value = dateTimePickerStart.Value;

            //Update the UI
            UpdateUI();
        }

        //UI Events

        private void ReviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            //Take the difference in time
            TimeSpan difference = (dateTimePickerEnd.Value.AddDays(1) - dateTimePickerStart.Value);
            //Move the pickers accordingly
            dateTimePickerEnd.Value -= difference;
            dateTimePickerStart.Value -= difference;
            //Update the ui
            UpdateUI();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            //Take the difference in time
            TimeSpan difference = (dateTimePickerEnd.Value.AddDays(1) - dateTimePickerStart.Value);
            //Move the pickers accordingly
            dateTimePickerEnd.Value += difference;
            dateTimePickerStart.Value += difference;
            //Update the ui
            UpdateUI();
        }

        private void DateTimePickers_ValueChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        //Private Methods

        private void UpdateUI()
        {
            DateTime start = dateTimePickerStart.Value;

            DateTime end = dateTimePickerEnd.Value + new TimeSpan(23, 55, 0);

            //Create the list of activity counters and then start to populate it
            List<ActivityTimeSpentCounter> activityCounters = new List<ActivityTimeSpentCounter>();

            //Find the activities that fit the time requirements
            List<TimedActivity> relevantActivities = mainForm.TimedDataStructure.TimedActivities.FindAll(x => (x.Start > start) && (x.Start < end));

            //Go through each activity
            foreach (var activity in relevantActivities)
            {

                //Find the activity counter using the project guid and the activity name
                ActivityTimeSpentCounter activityTimeSpentCounter = activityCounters.Find(x => x.ProjectName == activity.ProjectName && x.ActivityName == activity.Name);

                //If it has not been found
                if (activityTimeSpentCounter == null)
                {
                    //Create the wrapper and add it to list
                    activityCounters.Add(new ActivityTimeSpentCounter(activity.ProjectName, activity.Name, activity.End - activity.Start));
                }
                else //It has been found
                {
                    //Add the time onto it
                    activityTimeSpentCounter.AddTime(activity.End - activity.Start);
                }
            }

            //If the user wishes the tasks to be merged into projects
            if (checkBoxMergeProjectTasks.Checked)
            {
                //Merge the tasks

                //Create a container for the output
                Dictionary<string, TimeSpan> projectTimeSpent = new Dictionary<string, TimeSpan>();

                //Get a list of the unique project names
                IEnumerable<string> projectNames = activityCounters.Select(x => x.ProjectName).Distinct().OrderBy(x => x);

                //Go through each project
                foreach (var projectName in projectNames)
                {
                    //Get the total time spent
                    long ticks = activityCounters.Where(x => x.ProjectName == projectName).Sum(y => y.timeSpent.Ticks);
                    TimeSpan timeSpan = new TimeSpan(ticks);

                    //If the check box is made then round up to nearest 15minutes
                    if (checkBoxRound.Checked)
                    {
                        //Get the number of minutes rounded up to 15
                        int minutes = (int)(15 * Math.Ceiling(timeSpan.TotalMinutes / 15));

                        //Convert back
                        timeSpan = new TimeSpan(0, minutes, 0);
                    }

                    //Add to the output container
                    projectTimeSpent.Add(projectName, timeSpan);
                }


                //Summate the working period
                double workingHours = FetchWorkingHours(start, end);
                //Summate the total hours
                TimeSpan workedTimeSpan = new TimeSpan();
                TimeSpan workedTimeSpanExcludingBreaks = new TimeSpan();
                //Go through each wrapper
                foreach (var keyValuePair1 in projectTimeSpent)
                {
                    //If the activity is lunch
                    if (keyValuePair1.Key == "Lunch")
                    {
                        //Only increment the main counter
                        workedTimeSpan += keyValuePair1.Value;
                    }
                    //If the activity is a break
                    else if (keyValuePair1.Key == "Break")
                    {
                        //Only increment the main counter
                        workedTimeSpan += keyValuePair1.Value;
                    }
                    //Otherwise
                    else
                    {
                        //Increment all counters
                        workedTimeSpan += keyValuePair1.Value;
                        workedTimeSpanExcludingBreaks += keyValuePair1.Value;
                    }
                }

                //Determine efficiency
                double efficiencyExcludingBreaks = workedTimeSpanExcludingBreaks.TotalHours / workingHours;

                //Populate the text box
                StringBuilder builder = new StringBuilder();
                builder.Append(Math.Truncate(workingHours).ToString("00") + TimeSpan.FromHours(workingHours).ToString("\\:mm\\:ss") + "   working period"
                                + Environment.NewLine
                                + workedTimeSpan.ToString("hh\\:mm\\:ss") + "   time logged"
                                + Environment.NewLine
                                + workedTimeSpanExcludingBreaks.ToString("hh\\:mm\\:ss") + "   time logged (exluding breaks) which is an efficiency of " + efficiencyExcludingBreaks.ToString("P1"));


                builder.Append(Environment.NewLine);
                builder.Append(Environment.NewLine);

                foreach (var keyValuePair in projectTimeSpent)
                {
                    builder.Append(string.Format("{0} ; {1}",
                                                    keyValuePair.Value.ToString("hh\\:mm\\:ss"),
                                                    keyValuePair.Key));
                    builder.Append(Environment.NewLine);
                }

                textBoxOutput.Text = builder.ToString();
            }
            else
            {
                //If the check box is made then round up to nearest 15minutes
                if (checkBoxRound.Checked)
                {
                    //Go through each wrapper
                    foreach (var task in activityCounters)
                    {
                        //Get the number of minutes rounded up to 15
                        int minutes = (int)(15 * Math.Ceiling(task.timeSpent.TotalMinutes / 15));

                        //Convert back into the wrapper
                        task.timeSpent = new TimeSpan(0, minutes, 0);
                    }
                }

                //Sort the list by project
                activityCounters = activityCounters.OrderBy(x => x.ProjectName).ToList();

                //Summate the working period
                double workingHours = FetchWorkingHours(start, end);
                //Summate the total hours
                TimeSpan workedTimeSpan = new TimeSpan();
                TimeSpan workedTimeSpanExcludingBreaks = new TimeSpan();
                //Go through each wrapper
                foreach (var task in activityCounters)
                {
                    //If the activity is lunch
                    if (task.ProjectName == "Lunch")
                    {
                        //Only increment the main counter
                        workedTimeSpan += task.timeSpent;
                    }
                    //If the activity is a break
                    else if (task.ProjectName == "Break")
                    {
                        //Only increment the main counter
                        workedTimeSpan += task.timeSpent;
                    }
                    //Otherwise
                    else
                    {
                        //Increment all counters
                        workedTimeSpan += task.timeSpent;
                        workedTimeSpanExcludingBreaks += task.timeSpent;
                    }
                }

                //Determine efficiency
                double efficiencyExcludingBreaks = workedTimeSpanExcludingBreaks.TotalHours / workingHours;

                //Populate the text box
                StringBuilder builder = new StringBuilder();
                builder.Append(Math.Truncate(workingHours).ToString("00") + TimeSpan.FromHours(workingHours).ToString("\\:mm\\:ss") + "   working period"
                                + Environment.NewLine
                                + workedTimeSpan.ToString("hh\\:mm\\:ss") + "   time logged"
                                + Environment.NewLine
                                + workedTimeSpanExcludingBreaks.ToString("hh\\:mm\\:ss") + "   time logged (exluding breaks) which is an efficiency of " + efficiencyExcludingBreaks.ToString("P1"));
                                
                                
                builder.Append(Environment.NewLine);
                builder.Append(Environment.NewLine);

                foreach (var task in activityCounters)
                {
                    builder.Append(string.Format("{0} ; {1} ; {2}",
                                                    task.timeSpent.ToString("hh\\:mm\\:ss"),
                                                    task.ProjectName,
                                                    task.ActivityName));
                    builder.Append(Environment.NewLine);
                }

                textBoxOutput.Text = builder.ToString();
            }
        }

        /// <summary>
        /// Returns the expected number of hours given the time span
        /// </summary>
        private double FetchWorkingHours(DateTime start, DateTime end)
        {
            double workingHours = 0;
            DateTime current = start;
            while(current < end)
            {
                switch (current.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                        workingHours += 7.5;
                        break;

                    case DayOfWeek.Friday:
                        workingHours += 6.75;
                        break;

                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        //Do nothing
                        break;
                }

                current += new TimeSpan(1, 0, 0, 0);
            }

            return workingHours;
        }

    }
}
