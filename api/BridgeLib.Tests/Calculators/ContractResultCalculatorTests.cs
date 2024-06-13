using BridgeLib.Calculators;
using BridgeLib.Models;

namespace BridgeLib.Tests.Calculators;

public class ContractResultCalculatorTests
{
    [Theory(DisplayName = "NT contracts")]
    [InlineData(1, 0, 90)]
    [InlineData(2, 0, 120)]
    [InlineData(1, 1, 120)]
    [InlineData(3, 0, 400)]
    [InlineData(3, 1, 430)]
    [InlineData(6, 1, 1020)]
    [InlineData(7, 0, 1520)]
    public void Test1(int level, int overtricks, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract { Level = level, Suit = Suit.NT };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }

    [Theory(DisplayName = "Minor contracts")]
    [InlineData(2, 0, 90)]
    [InlineData(4, 1, 150)]
    [InlineData(4, 1, 150)]
    [InlineData(5, 1, 420)]
    [InlineData(6, 1, 940)]
    [InlineData(7, 0, 1440)]
    public void Test2(int level, int overtricks, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract { Level = level, Suit = Suit.Diamonds };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }

    [Theory(DisplayName = "Major contracts")]
    [InlineData(2, Suit.Spades, 0, 110)]
    [InlineData(4, Suit.Hearts, 1, 450)]
    [InlineData(6, Suit.Hearts, 0, 980)]
    [InlineData(7, Suit.Hearts, 0, 1510)]
    public void Test3(int level, Suit suit, int overtricks, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract() { Level = level, Suit = suit };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }

    [Theory(DisplayName = "Doubled contracts")]
    [InlineData(2, Suit.Spades, 0, 470)]
    [InlineData(2, Suit.Spades, 1, 570)]
    [InlineData(4, Suit.Spades, 0, 590)]
    [InlineData(4, Suit.Spades, 2, 790)]
    [InlineData(6, Suit.Spades, 1, 1310)]
    [InlineData(2, Suit.Diamonds, 1, 280)]
    [InlineData(3, Suit.Diamonds, 1, 570)]
    [InlineData(1, Suit.NT, 1, 280)]
    [InlineData(2, Suit.NT, 1, 590)]
    public void Test4(int level, Suit suit, int overtricks, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract
        {
            Level = level,
            Suit = suit,
            Penalty = Penalty.Doubled
        };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }
}
