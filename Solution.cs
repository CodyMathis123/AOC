namespace AOC2024
{
    public class Solution
    {
        public int Day { get; set; }
        public int Part { get; set; }
        public TimeSpan Elapsed { get; set; }
        public string Answer { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[Day: {Day}] [Part: {Part}] [Answer: {Answer}] [Elapsed: {Elapsed.TotalMicroseconds}]";
        }
    }
}