namespace BridgeLib.Models
{
    public class BoardResult
    {
        public int BoardNumber { get; set; }
        public string NsPairId { get; set; } = string.Empty;
        public string EwPairId { get; set; } = string.Empty;
        public decimal NsScore { get; set; } = 0;
        public decimal EwScore { get; set; } = 0;
    }
}
