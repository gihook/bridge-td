namespace BridgeLib.Models
{
    public class BoardScore
    {
        public required IEnumerable<BoardEntry> BoardEntries { get; set; }
        public decimal PairScore { get; set; }
    }
}
