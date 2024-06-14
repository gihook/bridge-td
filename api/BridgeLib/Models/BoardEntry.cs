namespace BridgeLib.Models
{
    public class BoardEntry
    {
        public int BoardNumber { get; set; }
        public required Contract Contract { get; set; }
        public int Result { get; set; }
    }
}
