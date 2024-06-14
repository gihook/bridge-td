namespace BridgeLib.Models
{
    public class BoardEntry
    {
        public int NsPairId { get; set; }
        public int EwPairId { get; set; }
        public int BoardNumber { get; set; }
        public required Contract Contract { get; set; }
        public int NumberOfOvertricks { get; set; }
        public int Result { get; set; }
    }
}
