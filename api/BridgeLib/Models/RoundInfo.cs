namespace BridgeLib.Models
{
    public class RoundInfo
    {
        public int RoundNumber { get; set; }
        public required IEnumerable<TableInfo> TableInfos { get; set; }
    }
}
