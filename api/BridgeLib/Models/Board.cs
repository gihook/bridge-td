namespace BridgeLib.Models
{
    public class Board
    {
        public int BoardNumber { get; set; }
        public Vulnerability Vulnerability { get; set; }
        public required IEnumerable<Card> NorthCards { get; set; }
        public required IEnumerable<Card> SouthCards { get; set; }
        public required IEnumerable<Card> EastCards { get; set; }
        public required IEnumerable<Card> WestCards { get; set; }
    }
}
