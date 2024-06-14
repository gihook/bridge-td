using BridgeLib.Calculators.Implementations;
using BridgeLib.Models;

namespace BridgeLib.Tests.Calculators.Implementations;

public class MatchpointsResultCalculatorTest
{
    [Fact(DisplayName = "Matchpoints with 5 entries")]
    public void Test1()
    {
        var calculator = new MatchpointsResultCalculator();
        var boardEntries = new List<BoardEntry>()
        {
            new BoardEntry() { Contract = new Contract(), Result = 650 },
            new BoardEntry() { Contract = new Contract(), Result = 650 },
            new BoardEntry() { Contract = new Contract(), Result = 620 },
            new BoardEntry() { Contract = new Contract(), Result = -100 },
            new BoardEntry() { Contract = new Contract(), Result = 140 },
        };
        var results = calculator.CalculateBoardScore(boardEntries);

        Assert.Equal(7, results.ElementAt(0).NsScore);
        Assert.Equal(7, results.ElementAt(1).NsScore);
        Assert.Equal(4, results.ElementAt(2).NsScore);
        Assert.Equal(0, results.ElementAt(3).NsScore);
        Assert.Equal(2, results.ElementAt(4).NsScore);

        Assert.Equal(1, results.ElementAt(0).EwScore);
        Assert.Equal(1, results.ElementAt(1).EwScore);
        Assert.Equal(4, results.ElementAt(2).EwScore);
        Assert.Equal(8, results.ElementAt(3).EwScore);
        Assert.Equal(6, results.ElementAt(4).EwScore);
    }

    [Fact(DisplayName = "Matchpoints with flat entries")]
    public void Test2()
    {
        var calculator = new MatchpointsResultCalculator();
        var boardEntries = new List<BoardEntry>()
        {
            new BoardEntry() { Contract = new Contract(), Result = 650 },
            new BoardEntry() { Contract = new Contract(), Result = 650 },
            new BoardEntry() { Contract = new Contract(), Result = 650 },
        };
        var results = calculator.CalculateBoardScore(boardEntries);

        Assert.Equal(2, results.ElementAt(0).NsScore);
        Assert.Equal(2, results.ElementAt(1).NsScore);
        Assert.Equal(2, results.ElementAt(2).EwScore);
    }
}
