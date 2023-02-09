using System.Text;

namespace Timed.Classes
{
    internal static class UIFriendlyTime
    {
        public static string UIFriendlyToString(this TimeSpan timeSpan)
        {
            StringBuilder stringBuilder = new();

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
    }
}
