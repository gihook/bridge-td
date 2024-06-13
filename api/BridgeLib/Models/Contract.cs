namespace BridgeLib.Models
{
    public class Contract
    {
        public PlayerSeat Declarer { get; set; }
        public Suit Suit { get; set; }
        public int Level { get; set; }
        public Penalty Penalty { get; set; }
        public Card? Lead { get; set; }
        public bool IsVulnerable { get; set; }
    }
}
