namespace BridgeLib.Models
{
    public class Tournament
    {
        public required IEnumerable<Pair> Pairs { get; set; }
        public required IEnumerable<Board> Boards { get; set; }
        public required Movement Movement { get; set; }
        public required Dictionary<int, IEnumerable<BoardEntry>> boardEntriesPerBoard { get; set; }
        public int CurrentRound { get; set; }
        public bool IsCompleted { get; set; }
    }
}
