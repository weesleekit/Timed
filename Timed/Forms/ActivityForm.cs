using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Timed.Classes;

namespace Timed.Forms
{
    public partial class ActivityForm : Form
    {
        //Constants

        private readonly TimeSpan idleThreshold = new TimeSpan(0, 1, 0);

        private readonly TimeSpan idleThresholdForPopup = new TimeSpan(0, 3, 0);

        //Nested Classes

        private class EndTime
        {
            //Fields

            public bool SpecialNowEndTime { get; } = false;

            private readonly DateTime dateTime;

            public DateTime DateTime 
            {
                get
                {
                    if (SpecialNowEndTime)
                    {
                        return DateTime.UtcNow;
                    }
                    else
                    {
                        return dateTime;
                    }
                }
            }

            //Constructor

            public EndTime()
            {
                SpecialNowEndTime = true;
            }

            public EndTime(DateTime dateTime)
            {
                this.dateTime = dateTime;
            }

            //Public Overrides

            public override string ToString()
            {
                if (SpecialNowEndTime)
                {
                    return "Now";
                }
                else
                {
                    return GetUIFriendlyTimeSpent(DateTime.UtcNow - DateTime) + " ago";
                }
            }

        }

        //Static Flags

        private static bool systemTrayHasPoppedUpHelp = false;

        //Fields

        private readonly MainForm mainForm;
        private readonly string projectName;
        private readonly string activityName;

        private readonly DateTime startTime;

        /// <summary>
        /// Set to true when the application intended the form to close
        /// </summary>
        private bool plannedClose = false;

        private List<EndTime> endTimes = new List<EndTime>();

        private bool userInactive = false;
        private bool nagGiven = false;

        //Constructor

        public ActivityForm(string projectName, string activityName, MainForm mainForm, DateTime startTime)
        {
            //Store the main form and initialise
            this.mainForm = mainForm;
            this.projectName = projectName;
            this.activityName = activityName;
            InitializeComponent();

            //Store the start time
            this.startTime = startTime;

            //Add the "Now" end time to the list
            EndTime endTime = new EndTime();
            endTimes.Add(endTime);
            listBoxEndTimeOptions.Items.Add(endTime);
        }

        /// <summary>
        /// This UI work needs to be done here instead of the constructor
        /// </summary>
        private void ActivityForm_Load(object sender, EventArgs e)
        {
            //Show the tray Icon
            notifyIcon.Visible = true;

            //Display the help (as appropriate, it fires one time per life of the application)
            if (!systemTrayHasPoppedUpHelp)
            {
                systemTrayHasPoppedUpHelp = true;
                notifyIcon.ShowBalloonTip(10000, "Timed icon will hide in your system tray", "Start working and then click the icon when you're finished", ToolTipIcon.Info);
            }

            Hide();
        }

        //UI Events
        
        /// <summary>
        /// The user is wanting to bring back the form from the system tray
        /// </summary>
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            BringBackTheForm(false);
        }

        /// <summary>
        /// Timer ticks to keep the form up to date and monitor inactivity
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Get the time spent
            TimeSpan timeSpan = DateTime.UtcNow - startTime;

            //Update the label
            labelSummary.Text = $"Project: {projectName}{Environment.NewLine}Activity: {activityName}{Environment.NewLine}Time Spent: {GetUIFriendlyTimeSpent(timeSpan)}";

            //Check for Inactivity
            CheckInactivity();
        }

        /// <summary>
        /// The user could be minimising the form and if so hide it
        /// </summary>
        private void ActivityForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();

                //Show the tray Icon
                notifyIcon.Visible = true;
            }
        }

        /// <summary>
        /// The user is wanting to finish the task
        /// </summary>
        private void ListBoxEndTimeOptions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxEndTimeOptions.SelectedItem != null)
            {
                EndTime endTime = (EndTime)listBoxEndTimeOptions.SelectedItem;

                TimedActivity timedActivity = new TimedActivity()
                {
                    ProjectName = projectName,
                    Name = activityName,
                    Start = startTime,
                };

                if (endTime.SpecialNowEndTime)
                {
                    timedActivity.End = DateTime.UtcNow;
                    mainForm.TaskFinished(timedActivity, null);
                }
                else
                {
                    timedActivity.End = endTime.DateTime;
                    mainForm.TaskFinished(timedActivity, endTime.DateTime);

                }
                plannedClose = true;
                Close();
            }
        }

        //Private Methods

        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        private void BringBackTheForm(bool shakeNotification)
        {

            //Show the form
            Show();

            //Set the window state to normal
            WindowState = FormWindowState.Normal;

            //Set the form to the top
            TopMost = true;

            //Set the focus on this form
            Focus();

            //Hide the tray Icon
            notifyIcon.Visible = false;

            //Shake as appropriate
            if (shakeNotification)
            {
                FlashWindow(Handle, true);
            }
        }

        public static string GetUIFriendlyTimeSpent(TimeSpan timeSpan)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (timeSpan.TotalHours > 1)
            {
                stringBuilder.Append($"{Math.Truncate(timeSpan.TotalHours)} hours, ");
            }

            if (timeSpan.TotalMinutes > 1)
            {
                stringBuilder.Append($"{timeSpan.Minutes} minutes, ");
            }

            stringBuilder.Append($"{timeSpan.Seconds} seconds");

            return stringBuilder.ToString();
        }

        bool alreadyWantToClose = false;

        private void ActivityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!plannedClose)
            {
                if (alreadyWantToClose)
                {
                    Application.Exit();
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("This will close the whole application and your activity won't be saved. If you want to keep working, minimise the form instead." + Environment.NewLine + Environment.NewLine + "Do you want to close the application?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes)
                {
                    alreadyWantToClose = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void CheckInactivity()
        {
            //Fetch when the user last interacted with the system
            TimeSpan idleTime = TimeSpan.FromMilliseconds(IdleTimeFinder.GetIdleTime());

            //Determine whether the user is considered inactive
            bool userConsideredInactive = (idleTime > idleThreshold);
            
            //If the user is now considered inactive when they were active before
            if (userConsideredInactive && !userInactive)
            {
                //Update the field with this change
                userInactive = true;

                //Create an end time and add it to the list
                EndTime newEndTime = new EndTime(DateTime.UtcNow - idleTime);
                endTimes.Add(newEndTime);
                endTimes = endTimes.OrderByDescending(x => x.DateTime).ToList();
                listBoxEndTimeOptions.Items.Clear();
                foreach (EndTime endTime in endTimes)
                {
                    listBoxEndTimeOptions.Items.Add(endTime);
                }
            }
            //If the user is now considered active when they were inactive before
            else if (!userConsideredInactive && userInactive)
            {
                //Update the field with this change
                userInactive = false;
                nagGiven = false;
            }
            else if (userConsideredInactive)
            {
                if (idleTime > idleThresholdForPopup)
                {
                    if (!nagGiven)
                    {
                        nagGiven = true;
                        BringBackTheForm(true);
                    }

                    FlashWindow(Handle, true);
                }
            }

            for (int i = 0; i < listBoxEndTimeOptions.Items.Count; i++)
            {
                listBoxEndTimeOptions.Items[i] = listBoxEndTimeOptions.Items[i];
            }
        }

    }
}
