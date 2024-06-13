using BridgeLib.Calculators;
using BridgeLib.Models;

namespace BridgeLib.Tests.Calculators;

public class ContractResultCalculatorTests
{
    [Fact(DisplayName = "NT contracts")]
    public void Test1()
    {
        var calculator = new ContractResultCalculator();

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 1, Suit = Suit.NT }, 0),
            90
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 2, Suit = Suit.NT }, 0),
            120
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 1, Suit = Suit.NT }, 1),
            120
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 3, Suit = Suit.NT }, 0),
            400
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 3, Suit = Suit.NT }, 1),
            430
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 6, Suit = Suit.NT }, 0),
            990
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 6, Suit = Suit.NT }, 1),
            1020
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 7, Suit = Suit.NT }, 0),
            1520
        );
    }

    [Fact(DisplayName = "Minor contracts")]
    public void Test2()
    {
        var calculator = new ContractResultCalculator();

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 2, Suit = Suit.Clubs }, 0),
            90
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 4, Suit = Suit.Clubs }, 1),
            150
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 5, Suit = Suit.Clubs }, 1),
            420
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 6, Suit = Suit.Clubs }, 1),
            940
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 7, Suit = Suit.Diamonds }, 0),
            1440
        );
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
