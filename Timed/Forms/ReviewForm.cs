using System.Data;
using System.Text;
using Timed.Classes;
using Timed.Classes.Data;

namespace Timed.Forms
{
    public partial class ReviewForm : Form
    {
        // Fields

        private readonly MainForm mainForm;

        // Constructor

        public ReviewForm(MainForm main)
        {
            mainForm = main;
            InitializeComponent();

            dateTimePickerStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTimePickerEnd.Value = dateTimePickerStart.Value;

            UpdateUI();
        }

        // UI Events

        private void ReviewForm_Load(object sender, EventArgs e)
        {
            checkBoxMergeProjectTasks.Select();
        }

        private void ReviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            TimeSpan difference = (dateTimePickerEnd.Value.AddDays(1) - dateTimePickerStart.Value);
            dateTimePickerEnd.Value -= difference;
            dateTimePickerStart.Value -= difference;
            UpdateUI();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            TimeSpan difference = (dateTimePickerEnd.Value.AddDays(1) - dateTimePickerStart.Value);
            dateTimePickerEnd.Value += difference;
            dateTimePickerStart.Value += difference;
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

        // Private Methods

        private void UpdateUI()
        {
            DateTime from = dateTimePickerStart.Value;
            DateTime to = dateTimePickerEnd.Value + new TimeSpan(23, 55, 0);

            var relevantActivities = mainForm.TimedDataStructure.TimedActivities.Where(x => x.Start > from
                                                                                         && x.Start < to);

            var relevantWorkingActivites = relevantActivities.Where(x => x.ProjectName != "Break");

            IEnumerable<(string, TimeSpan)> summarisedWorkingActivities;

            bool roundUp = checkBoxRound.Checked;

            if (checkBoxMergeProjectTasks.Checked)
            {
                summarisedWorkingActivities = GetMergedProjectTaskSummary(relevantWorkingActivites, roundUp: roundUp);
            }
            else
            {
                summarisedWorkingActivities = GetIndividualProjectTaskSummary(relevantWorkingActivites, roundUp: roundUp);
            }

            TimeSpan timeWorked = new(summarisedWorkingActivities.Select(x => x.Item2.Ticks).Sum());

            TimeSpan timeTakenAsBreaks = new(relevantActivities.Where(x => x.ProjectName == "Break")
                                                                       .Sum(x => (x.End - x.Start).Ticks));

            TimeSpan totalTimeSpent = timeWorked + timeTakenAsBreaks;

            double workingHoursIncludingBreaks = GetWorkingHoursIncludingBreaks(from, to);
            double workingHoursExcludingBreaks = GetWorkingHoursExcludingBreaks(from, to);

            double fulfillmentOfWorkingHoursIncludingBreaks = totalTimeSpent.TotalHours / workingHoursIncludingBreaks;
            double fulfillmentOfWorkingHoursExcludingBreaks = timeWorked.TotalHours / workingHoursExcludingBreaks;

            double efficiency = timeWorked / totalTimeSpent;

            StringBuilder builder = new();
            builder.Append(""
                            + Math.Truncate(workingHoursIncludingBreaks).ToString("00") + TimeSpan.FromHours(workingHoursIncludingBreaks).ToString("\\:mm\\:ss") + "   working period (including breaks)"
                            + Environment.NewLine
                            + Math.Truncate(workingHoursExcludingBreaks).ToString("00") + TimeSpan.FromHours(workingHoursExcludingBreaks).ToString("\\:mm\\:ss") + "   working period (excluding breaks)"
                            + Environment.NewLine
                            + totalTimeSpent.ToString("hh\\:mm\\:ss") + "   total time (including breaks)"
                            + Environment.NewLine
                            + timeWorked.ToString("hh\\:mm\\:ss") + "   time worked (exluding breaks)"
                            + Environment.NewLine
                            + timeTakenAsBreaks.ToString("hh\\:mm\\:ss") + "   time taken as breaks"
                            + Environment.NewLine
                            + "This is a fulfillment of the working period (time logged including breaks vs working period including breaks) of " + fulfillmentOfWorkingHoursIncludingBreaks.ToString("P1")
                            + Environment.NewLine
                            );

            if (fulfillmentOfWorkingHoursIncludingBreaks > 1)
            {
                builder.Append("Surplus of: ");
            }
            else
            {
                builder.Append("Deficit of: ");
            }
            builder.Append(""
                            + TimeSpan.FromHours(totalTimeSpent.TotalHours - workingHoursIncludingBreaks).ToString("hh\\:mm\\:ss")
                            + Environment.NewLine
                            + "This is a fulfillment of the working period (time logged excluding breaks vs working period excluding breaks) of " + fulfillmentOfWorkingHoursExcludingBreaks.ToString("P1")
                            + Environment.NewLine
                            );
            if (fulfillmentOfWorkingHoursExcludingBreaks > 1)
            {
                builder.Append("Surplus of: ");
            }
            else
            {
                builder.Append("Deficit of: ");
            }
            builder.Append(""
                            + TimeSpan.FromHours(timeWorked.TotalHours - workingHoursExcludingBreaks).ToString("hh\\:mm\\:ss")
                            + Environment.NewLine
                            + "Time efficiency (time logged excluding breaks vs time logged including breaks) of " + efficiency.ToString("P1")
                            );
            bool isOnlyReviewingToday = DateTime.Now.Date == from.Date &&
                                    DateTime.Now.Date == to.Date;
            bool notYetFulfilledWorkingDay = fulfillmentOfWorkingHoursExcludingBreaks < 1;
            if (isOnlyReviewingToday && notYetFulfilledWorkingDay)
            {
                builder.Append(Environment.NewLine);
                double hoursStillToWork = workingHoursExcludingBreaks - timeWorked.TotalHours;
                DateTime finishTime = DateTime.Now.AddHours(hoursStillToWork);
                builder.Append($"Finish time of: {finishTime:t}");
            }
            builder.Append(Environment.NewLine);
            builder.Append(Environment.NewLine);

            var sortedActivities = summarisedWorkingActivities.OrderBy(x => x.Item1);

            foreach (var activity in sortedActivities)
            {
                builder.Append($"{activity.Item2.ToString("hh\\:mm\\:ss")} - {activity.Item1}");
                builder.Append(Environment.NewLine);
            }

            textBoxOutput.Text = builder.ToString();
        }

        private static IEnumerable<(string, TimeSpan)> GetIndividualProjectTaskSummary(IEnumerable<TimedActivity> relevantActivites, bool roundUp)
        {
            List<(string, TimeSpan)> returnList = new();

            var groupings = relevantActivites.GroupBy(x => new { x.ProjectName, x.Name });

            foreach (var group in groupings)
            {
                string projectName = group.Key.ProjectName;
                string name = group.Key.Name;
                TimeSpan totalTime = new(group.Sum(x => (x.End - x.Start).Ticks));
                if (roundUp)
                {
                    totalTime = RoundUpTo15MinuteIncrements(totalTime);
                }

                string title = $"{projectName} - {name}";
                returnList.Add(new (title, totalTime));
            }

            return returnList;
        }

        private static IEnumerable<(string, TimeSpan)> GetMergedProjectTaskSummary(IEnumerable<TimedActivity> relevantActivites, bool roundUp)
        {
            List<(string, TimeSpan)> returnList = new();

            var projectGroups = relevantActivites.GroupBy(x => x.ProjectName);

            foreach (var projectGroup in projectGroups)
            {
                string projectName = projectGroup.Key;
                TimeSpan totalTime = new(projectGroup.Sum(x => (x.End - x.Start).Ticks));
                if (roundUp)
                {
                    totalTime = RoundUpTo15MinuteIncrements(totalTime);
                }

                string title = $"{projectName}";
                returnList.Add(new(title, totalTime));
            }

            return returnList;
        }

        private static TimeSpan RoundUpTo15MinuteIncrements(TimeSpan originalTimeSpan)
        {
            int minutesRoundedUpTo15Increments = (int)(15 * Math.Ceiling(originalTimeSpan.TotalMinutes / 15));
            TimeSpan newTimeSpan = new(0, minutesRoundedUpTo15Increments, 0);
            return newTimeSpan;
        }

        private static double GetWorkingHoursIncludingBreaks(DateTime from, DateTime end)
        {
            double workingHours = 0;
            DateTime current = from;
            while (current < end)
            {
                switch (current.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                        workingHours += 8.5;
                        break;

                    case DayOfWeek.Friday:
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        //Do nothing
                        break;
                }

                current += new TimeSpan(1, 0, 0, 0);
            }

            return workingHours;
        }

        private static double GetWorkingHoursExcludingBreaks(DateTime from, DateTime to)
        {
            double workingHours = 0;
            DateTime current = from;
            while (current < to)
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
