using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using Timed.Classes;

namespace Timed.Forms
{
    public partial class MainForm : Form
    {
        //Constants

        private const string filePath = "UserData.txt";

        //Fields

        public TimedDataStructure TimedDataStructure { get; } = null;

        private DateTime? resumePoint = null;

        //Constructor

        public MainForm(out bool success)
        {
            InitializeComponent();

            //Set up the data
            TimedDataStructure = LoadDataStructure();

            //Return whether or not successful
            success = TimedDataStructure != null;

            //Set up the buttons
            buttonResume.Enabled = false;
            buttonResume.Text = "";
        }
        
        //UI Events

        /// <summary>
        /// Creates the input form and hides this form
        /// </summary>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            //Start a new task
#pragma warning disable IDE0067 // Dispose objects before losing scope
            ActivitySelectionForm taskSelectionForm = new ActivitySelectionForm(this);
#pragma warning restore IDE0067 // Dispose objects before losing scope
            Hide();
            taskSelectionForm.Show();
        }
        private void ButtonResume_Click(object sender, EventArgs e)
        {
            if (resumePoint == null)
            {
                buttonResume.Enabled = false;
                buttonResume.Text = "";
                return;
            }

            //Start a new task
#pragma warning disable IDE0067 // Dispose objects before losing scope
            ActivitySelectionForm taskSelectionForm = new ActivitySelectionForm(this, resumePoint);
#pragma warning restore IDE0067 // Dispose objects before losing scope
            Hide();
            taskSelectionForm.Show();
        }

        /// <summary>
        /// Creates the review form and hides this form
        /// </summary>
        private void ButtonReview_Click(object sender, EventArgs e)
        {
            //Start a review
#pragma warning disable IDE0067 // Dispose objects before losing scope
            ReviewForm reviewForm = new ReviewForm(this);
#pragma warning restore IDE0067 // Dispose objects before losing scope
            this.Hide();
            reviewForm.Show();
        }

        /// <summary>
        /// This saves the datastructure to disk
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataStructure();
        }

        //Public Methods

        public void TaskFinished(TimedActivity timedActivity, DateTime? resumePoint)
        {
            //Add the activity to the list
            TimedDataStructure.TimedActivities.Add(timedActivity);

            //Save to disk
            SaveDataStructure();

            //Set up the UI as appropriate
            this.resumePoint = resumePoint;
            buttonResume.Enabled = resumePoint != null;
            buttonResume.Text = "";

            if (resumePoint != null)
            {
                buttonResume.Text = $"Start New Task Starting from {ActivityForm.GetUIFriendlyTimeSpent(DateTime.UtcNow - (DateTime)resumePoint)}";
            }
            
            Show();
        }

        //Private Methods

        private void SaveDataStructure()
        {
            if (TimedDataStructure != null)
            {
                try
                {
                    string fileContents = JsonConvert.SerializeObject(TimedDataStructure);

                    File.WriteAllText(filePath, fileContents);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Loads the saved JSON object (if it exists), otherwise creates a new one to start with
        /// </summary>
        /// <returns></returns>
        private TimedDataStructure LoadDataStructure()
        {
            TimedDataStructure timedDataStructure;

            if (File.Exists(filePath))
            {
                try
                {
                    string fileContents = File.ReadAllText(filePath);

                    timedDataStructure = JsonConvert.DeserializeObject<TimedDataStructure>(fileContents);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                timedDataStructure = new TimedDataStructure();
            }

            return timedDataStructure;
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
                "This application is open source and can be found here https://github.com/jclark-sda/Timed/tree/master/Timed . If any of the above concerns you then you can easily download the source code, check it and compile it yourself.",
                "Privacy Statement",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
