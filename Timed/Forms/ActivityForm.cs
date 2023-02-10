using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timed.Classes;
using Timed.Classes.Data;

namespace Timed.Forms
{
    public partial class ActivityForm : Form
    {
        // Constants

        private readonly TimeSpan idleThreshold = new(0, 0, 20);

        private readonly TimeSpan idleThresholdForPopup = new(0, 3, 0);

        // Nested Classes

        private class PresetEndTime
        {
            public int Minutes { get; }

            public PresetEndTime(int minutes)
            {
                Minutes = minutes;
            }

            public override string ToString()
            {
                if (Minutes == 0)
                {
                    return "Now";
                }
                else
                {
                    return $"{Minutes} minutes ago";
                }
            }
        }

        private class EndTime
        {
            internal DateTime DateTime { get; }

            public EndTime(DateTime dateTime)
            {
                DateTime = dateTime;
            }

            public override string ToString()
            {
                TimeSpan timeSpan = DateTime.UtcNow - DateTime;
                return $"{timeSpan.UIFriendlyToString()} ago";
            }
        }

        // Static Flags

        private static bool hasOneOffTutorialMessagePopped = false;

        // Fields

        private readonly MainForm mainForm;
        private readonly TimedActivity timedActivity;

        private bool closingFormDueToTaskEnded = false;
        private bool userInactive = false;
        private bool nagGiven = false;

        //Constructor

        public ActivityForm(TimedActivity timedActivity, MainForm mainForm)
        {
            this.timedActivity = timedActivity;
            this.mainForm = mainForm;

            InitializeComponent();

            //Add the preset times to the list
            for (int i = 0; i < 6; i++)
            {
                listBoxPresetEndOptions.Items.Add(new PresetEndTime(i));
            }
            for (int i = 10; i < 35; i += 5)
            {
                listBoxPresetEndOptions.Items.Add(new PresetEndTime(i));
            }
        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {
            notifyIcon.Visible = true;
            notifyIcon.Text = $"{timedActivity.ProjectName} - {timedActivity.Name}";

            if (!hasOneOffTutorialMessagePopped)
            {
                hasOneOffTutorialMessagePopped = true;
                notifyIcon.ShowBalloonTip(10000, "Timed icon will hide in your system tray", "Start working and then click the icon when you're finished", ToolTipIcon.Info);
            }

            Hide();
        }

        //UI Events

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            BringBackTheForm(shakeNotification: false);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = DateTime.UtcNow - timedActivity.Start;

            labelSummary.Text = $"Project: {timedActivity.ProjectName}" +
                                $"{Environment.NewLine}Activity: {timedActivity.Name}" +
                                $"{Environment.NewLine}Time Spent: {timeSpan.UIFriendlyToString()}";

            for (int i = 0; i < listBoxEndTimeOptions.Items.Count; i++)
            {
                listBoxEndTimeOptions.Items[i] = listBoxEndTimeOptions.Items[i];
            }

            CheckInactivity();
        }

        private void ActivityForm_Resize(object sender, EventArgs e)
        {
            bool userHasMinimisedForm = WindowState == FormWindowState.Minimized;

            if (!userHasMinimisedForm)
            {
                return;
            }

            Hide();
            notifyIcon.Visible = true;
        }

        private void ListBoxEndTimeOptions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxEndTimeOptions.SelectedItem == null)
            {
                return;
            }

            EndTime endTime = (EndTime)listBoxEndTimeOptions.SelectedItem;

            ActivityFinished(endTime.DateTime);
        }

        private void ListBoxPresetEndOptions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxPresetEndOptions.SelectedItem == null)
            {
                return;
            }

            PresetEndTime presetEndTime = (PresetEndTime)listBoxPresetEndOptions.SelectedItem;
            DateTime endTime = DateTime.UtcNow.AddMinutes(-presetEndTime.Minutes);
            bool tryingToEndActivityBeforeItStarted = timedActivity.Start > endTime;
            if (tryingToEndActivityBeforeItStarted)
            {
                MessageBox.Show("You've not spent this much time on the task yet", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActivityFinished(endTime);
        }

        private void ActivityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closingFormDueToTaskEnded)
            {
                return;
            }

            if (closingFormDueToUserConfirmedTheyWantToExit)
            {
                Application.Exit();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("This will close the whole application and your activity won't be saved. If you want to keep working, minimise the form instead." + Environment.NewLine + Environment.NewLine + "Do you want to close the application?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dialogResult == DialogResult.Yes)
            {
                closingFormDueToUserConfirmedTheyWantToExit = true;
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        // Private Methods

        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        private void BringBackTheForm(bool shakeNotification)
        {
            Show();
            WindowState = FormWindowState.Normal;
            TopMost = true;
            Focus();
            notifyIcon.Visible = false;
            
            if (shakeNotification)
            {
                FlashWindow(Handle, true);
            }
        }

        bool closingFormDueToUserConfirmedTheyWantToExit = false;


        private void CheckInactivity()
        {
            TimeSpan idleTime = TimeSpan.FromMilliseconds(IdleTimeFinder.GetIdleTime());

            bool userConsideredInactive = (idleTime > idleThreshold);

            //If the user is now considered inactive when they were active before
            if (userConsideredInactive && !userInactive)
            {
                userInactive = true;

                EndTime newEndTime = new(DateTime.UtcNow - idleTime);
                
                listBoxEndTimeOptions.Items.Insert(0, newEndTime);
            }
            //If the user is now considered active when they were inactive before
            else if (!userConsideredInactive && userInactive)
            {
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
        }

        private void ActivityFinished(DateTime end)
        {
            timedActivity.End = end;
            mainForm.TaskFinished(timedActivity);

            closingFormDueToTaskEnded = true;
            Close();
        }
    }
}
