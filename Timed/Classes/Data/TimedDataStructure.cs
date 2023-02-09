using Newtonsoft.Json;

namespace Timed.Classes.Data
{
    internal class TimedDataStructure
    {
        //Constants

        private const string fileName = "UserData.txt";
        private const string folderName = "Timed";

        // Properties

        [JsonProperty]
        internal List<TimedActivity> TimedActivities { get; private set; } = new List<TimedActivity>();

        // Constructor

        internal TimedDataStructure()
        {
            
        }

        // Public Methods

        internal static TimedDataStructure Load()
        {
            string path = GetPath();

            if (!File.Exists(path))
            {
                return new();
            }

            string fileContents = File.ReadAllText(path);

            var deserialisedObject = JsonConvert.DeserializeObject<TimedDataStructure>(fileContents);

            if (deserialisedObject == null)
            {
                throw new Exception($"Unable to deserialise {path}");
            }

            return deserialisedObject;
        }

        internal void Save()
        {
            string path = GetPath();

            string fileContents = JsonConvert.SerializeObject(this);

            FileInfo fileInfo = new(path);
            fileInfo.Directory.Create();

            File.WriteAllText(path, fileContents);
        }

        // Private Methods

        private static string GetPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName, fileName);
        }

        internal void AddActivity(TimedActivity timedActivity)
        {
            TimedActivities.Add(timedActivity);
            Save();
        }

        internal IEnumerable<string> GetRecentProjects()
        {
            return TimedActivities.OrderBy(x => x.End).Select(x => x.ProjectName).Distinct();

        }
    }
}
