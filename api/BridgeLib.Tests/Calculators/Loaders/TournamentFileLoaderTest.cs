using BridgeLib.Models;

namespace BridgeLib.Tests.Loaders;

public class TournamentFileLoaderTest
{
    [Fact(DisplayName = "Load mitchell-6-24-boards.json")]
    public async Task Test1()
    {
        var loader = new TournamentFileLoader();
        var filePath = "./SampleTournamentResults/mitchell-6-24-boards.json";
        var tournament = await loader.Load(filePath);

        Assert.Contains(1, tournament.BoardEntriesPerBoard.Keys);
        Assert.Contains(17, tournament.BoardEntriesPerBoard.Keys);
        Assert.DoesNotContain(26, tournament.BoardEntriesPerBoard.Keys);

        var firstEntry = tournament.BoardEntriesPerBoard[1].ElementAt(0);
        Assert.Equal(1, firstEntry.BoardNumber);

        Assert.Equal(2, firstEntry.Contract.Level);
        Assert.Equal(Suit.Hearts, firstEntry.Contract.Suit);
        Assert.Equal(PlayerSeat.East, firstEntry.Contract.Declarer);
        Assert.Equal(-2, firstEntry.NumberOfOvertricks);
        Assert.Equal(Penalty.None, firstEntry.Contract.Penalty);

        Assert.Equal(1, firstEntry.NsPairId);
        Assert.Equal(7, firstEntry.EwPairId);

        var entryWithDouble = tournament.BoardEntriesPerBoard[4].ElementAt(1);
        Assert.Equal(Penalty.Doubled, entryWithDouble.Contract.Penalty);
    }

    [Fact(DisplayName = "Descriptors Load mitchell-6-24-boards.json")]
    public async Task Test2()
    {
        var loader = new TournamentFileLoader();
        var filePath = "./SampleTournamentResults/mitchell-6-24-boards.json";
        var tournament = await loader.LoadDescriptor(filePath);

        Assert.Contains(1, tournament.BoardResults.Keys);
        Assert.Contains(17, tournament.BoardResults.Keys);
        Assert.DoesNotContain(26, tournament.BoardResults.Keys);

        var firstEntry = tournament.BoardResults[1].ElementAt(0);

        Assert.Equal(1, firstEntry.NsId);
        Assert.Equal(7, firstEntry.EwId);
    }
}
