namespace BridgeLib.Models
{
    public class PairTournamentScore
    {
        public required string PairId { get; set; }
        public decimal Score { get; set; }
        public int Position { get; set; }
        public ScoreType ScoreType { get; set; }
    }
}
