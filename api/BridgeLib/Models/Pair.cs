namespace BridgeLib.Models
{
    public class Pair
    {
        public int Id { get; set; }
        public required IEnumerable<TournamentPlayer> Players { get; set; }
    }
}
