namespace BridgeLib.Tests.Loaders;

public class TournamentSampleDescriptor
{
    public Dictionary<int, IEnumerable<TournamentBoardResult>> BoardResults { get; set; } =
        new Dictionary<int, IEnumerable<TournamentBoardResult>>();
    public List<TournamentResult> TournamentResults { get; set; } = new List<TournamentResult>();
}

public class TournamentBoardResult
{
    public int NsId { get; set; }
    public int EwId { get; set; }
    public string Contract { get; set; } = string.Empty;
    public string Declarer { get; set; } = string.Empty;
    public string Lead { get; set; } = string.Empty;
    public int NsResult { get; set; }
    public int EwResult { get; set; }
    public string NsPair { get; set; } = string.Empty;
    public string EwPair { get; set; } = string.Empty;
}

public class TournamentResult
{
    public int Rank { get; set; }
    public int PairId { get; set; }
    public string PairNames { get; set; } = string.Empty;
    public int NumberOfBoards { get; set; }
    public int Score { get; set; }
    public int MaxScore { get; set; }
    public int TournamentScore { get; set; }
}
