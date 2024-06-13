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

    [Fact(DisplayName = "Major contracts")]
    public void Test3()
    {
        var calculator = new ContractResultCalculator();

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 2, Suit = Suit.Spades }, 0),
            110
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 4, Suit = Suit.Hearts }, 2),
            480
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 6, Suit = Suit.Hearts }, 1),
            1010
        );

        Assert.Equal(
            calculator.CalculateResult(new Contract() { Level = 7, Suit = Suit.Hearts }, 0),
            1510
        );
    }
}
