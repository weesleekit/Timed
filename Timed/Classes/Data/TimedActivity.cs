namespace Timed.Classes.Data
{
    public class TimedActivity
    {
        public required string ProjectName { get; set; }

        public required string Name { get; set; }
        
        public required DateTime Start { get; set; }

        public required DateTime End { get; set; }

        public override string ToString()
        {
            return $"{ProjectName} - {Name}";
        }
    }
}
