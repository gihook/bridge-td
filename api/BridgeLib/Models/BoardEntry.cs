namespace BridgeLib.Models
{
    public class BoardEntry
    {
        public int BoardNumber { get; set; }
        public required Contract Contract { get; set; }
    }
}
