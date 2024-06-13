namespace BridgeLib.Models
{
    public class TableInfo
    {
        public int TableNumber { get; set; }
        public required Pair NsPair { get; set; }
        public required Pair EwPair { get; set; }
    }
}
