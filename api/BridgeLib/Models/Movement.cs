namespace BridgeLib.Models
{
    public class Movement
    {
        public string Id { get; set; } = string.Empty;
        public int NumberOfTables { get; set; }
        public int NumberOfPairs { get; set; }

        public IEnumerable<RoundInfo> RoundInfos { get; set; } = new List<RoundInfo>();
    }
}
