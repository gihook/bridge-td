namespace BridgeLib.Models
{
    public class TournamentPlayer
    {
        public int UserId { get; set; }
        public required string PairId { get; set; }
        public required string DisplayName { get; set; }
    }
}
