using System;
using Timed.Classes;
using Timed.Classes.Data;

namespace Timed.Forms
{
    public partial class MainForm : Form
    {
        // Fields

        internal TimedDataStructure TimedDataStructure { get; }

        private DateTime? resumePoint = null;

        // Constructor

        public MainForm()
        {
            InitializeComponent();
            try
            {
                TimedDataStructure = TimedDataStructure.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        //UI Events
        
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            ActivitySelectionForm newForm = new(this);
            Hide();
            newForm.Show();
        }

        private void ButtonResume_Click(object sender, EventArgs e)
        {
            ActivitySelectionForm newForm = new(this, resumePoint);
            Hide();
            newForm.Show();
        }

        private void ButtonEditDatabase_Click(object sender, EventArgs e)
        {
            EditDatabase newForm = new(this);
            Hide();
            newForm.Show();
        }

        private void ButtonReview_Click(object sender, EventArgs e)
        {
            ReviewForm newForm = new(this);
            Hide();
            newForm.Show();
        }
     
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimedDataStructure?.Save();
        }

        private void ButtonPrivacy_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This application does not 'phone home' with any data and there is no functionality programmed in to send data on a network. " +
                Environment.NewLine + Environment.NewLine +
                "Your activity is stored in a text file called UserData.txt which is kept in the same folder as the application itself. " +
                Environment.NewLine + Environment.NewLine +
                "If you open it in notepad, you can see what information is being stored and you can easily delete it at will." +
                Environment.NewLine + Environment.NewLine +
                "This application hooks into Windows in order to check when you were last active and this is done for the purposes of letting you choose when to end a task." +
                Environment.NewLine + Environment.NewLine +
                "This hook is not used to record your mouse movements or keyboard presses, it only knows when you were last inactive." +
                Environment.NewLine + Environment.NewLine +
                "This application is open source and can be found here https://github.com/weesleekit/Timed . If any of the above concerns you then you can easily download the source code, check it and compile it yourself.",
                "Privacy Statement",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TimerUIRefresh_Tick(object sender, EventArgs e)
        {
            RefreshUI();
        }

        //Public Methods

        internal void TaskFinished(TimedActivity timedActivity)
        {
            if (buttonStart.Location.Y < buttonResume.Location.Y)
            {
                var temp = buttonStart.Location;
                buttonStart.Location = buttonResume.Location;
                buttonResume.Location = temp;
            }

            buttonResume.Select();

            TimedDataStructure?.AddActivity(timedActivity);

            resumePoint = timedActivity.End;
            RefreshUI();

            Show();
        }

        // Private Methods

        private void RefreshUI()
        {
            if (resumePoint == null)
            {
                buttonResume.Text = "";
                buttonResume.Enabled = false;
                return;
            }

            TimeSpan timeSpan = DateTime.UtcNow - resumePoint.Value;
            buttonResume.Text = $"Start New Task {Environment.NewLine} from {timeSpan.UIFriendlyToString()} ago";
            buttonResume.Enabled = true;
        }
    }
}
