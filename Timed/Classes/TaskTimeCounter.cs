using Timed.Classes.Data;

namespace Timed.Classes
{
    internal class TaskTimeCounter
    {
        public TimeSpan timeSpent;

        public string ProjectName;

        public string ActivityName;

        public TaskTimeCounter(TimedActivity timedActivity)
        {
            ProjectName = timedActivity.ProjectName;
            ActivityName = timedActivity.Name;
            timeSpent = timedActivity.End - timedActivity.Start;
        }

        public void AddTime(TimedActivity timedActivity)
        {
            timeSpent += timedActivity.End - timedActivity.Start;
        }
    }
}
