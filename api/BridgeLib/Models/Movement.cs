namespace BridgeLib.Models
{
    public class Movement
    {
        public required string Id { get; set; }
        public required int NumberOfTables { get; set; }
        public required int NumberOfPairs { get; set; }

        public required IEnumerable<RoundInfo> RoundInfos { get; set; }
    }
}
