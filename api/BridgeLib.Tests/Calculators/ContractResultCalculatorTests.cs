using BridgeLib.Calculators;
using BridgeLib.Models;

namespace BridgeLib.Tests.Calculators;

public class ContractResultCalculatorTests
{
    [Theory(DisplayName = "NT contracts non vulnerable")]
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

    [Theory(DisplayName = "Minor contracts non vulnerable")]
    [InlineData(2, 0, 90)]
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

    [Theory(DisplayName = "Major contracts non vulnerable")]
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

    [Theory(DisplayName = "Doubled contracts non vulnerable")]
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

    [Theory(DisplayName = "Redoubled contracts non vulnerable")]
    [InlineData(1, Suit.NT, 0, 560)]
    [InlineData(1, Suit.NT, 6, 1760)]
    [InlineData(3, Suit.NT, 1, 1000)]
    [InlineData(1, Suit.Hearts, 1, 720)]
    [InlineData(1, Suit.Clubs, 1, 430)]
    [InlineData(7, Suit.NT, 0, 2280)]
    public void Test5(int level, Suit suit, int overtricks, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract
        {
            Level = level,
            Suit = suit,
            Penalty = Penalty.Redoubled
        };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }

    [Theory(DisplayName = "Vulnerable scores")]
    [InlineData(1, Suit.NT, 3, 180)]
    [InlineData(3, Suit.NT, 3, 690)]
    [InlineData(5, Suit.Hearts, 2, 710)]
    [InlineData(5, Suit.Clubs, 2, 640)]
    [InlineData(6, Suit.Clubs, 1, 1390)]
    [InlineData(7, Suit.Clubs, 0, 2140)]
    [InlineData(6, Suit.NT, 0, 1440)]
    public void Test6(int level, Suit suit, int overtricks, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract
        {
            Level = level,
            Suit = suit,
            IsVulnerable = true
        };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }

    [Fact(DisplayName = "Random tests for contracts")]
    public void Tests6()
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract
        {
            Level = 4,
            Suit = Suit.NT,
            IsVulnerable = true,
            Penalty = Penalty.Redoubled
        };
        var score = 1920;
        Assert.Equal(calculator.CalculateResult(contract, 2), score);

        var contract2 = new Contract
        {
            Level = 4,
            Suit = Suit.NT,
            IsVulnerable = true,
            Penalty = Penalty.Doubled
        };
        var score2 = 1210;
        Assert.Equal(calculator.CalculateResult(contract2, 2), score2);
    }

    [Theory(DisplayName = "Defeated contracts")]
    [InlineData(-1, false, -50)]
    [InlineData(-2, false, -100)]
    [InlineData(-4, false, -200)]
    [InlineData(-4, true, -400)]
    [InlineData(-5, true, -500)]
    public void Test7(int overtricks, bool IsVulnerable, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract
        {
            Level = 7,
            Suit = Suit.NT,
            IsVulnerable = IsVulnerable
        };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }

    [Theory(DisplayName = "Defeated contracts doubled")]
    [InlineData(-1, false, -100)]
    [InlineData(-2, false, -300)]
    [InlineData(-3, false, -500)]
    [InlineData(-4, false, -800)]
    [InlineData(-5, false, -1100)]
    [InlineData(-13, false, -3500)]
    [InlineData(-1, true, -200)]
    [InlineData(-2, true, -500)]
    [InlineData(-13, true, -3800)]
    public void Test8(int overtricks, bool IsVulnerable, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract
        {
            Level = 7,
            Suit = Suit.NT,
            IsVulnerable = IsVulnerable,
            Penalty = Penalty.Doubled
        };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }

    [Theory(DisplayName = "Defeated contracts redoubled")]
    [InlineData(-1, false, -200)]
    [InlineData(-2, false, -600)]
    [InlineData(-3, false, -1000)]
    [InlineData(-4, false, -1600)]
    [InlineData(-5, false, -2200)]
    [InlineData(-13, false, -7000)]
    [InlineData(-1, true, -400)]
    [InlineData(-2, true, -1000)]
    [InlineData(-13, true, -7600)]
    [InlineData(-6, true, -3400)]
    public void Test9(int overtricks, bool IsVulnerable, int score)
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract
        {
            Level = 7,
            Suit = Suit.NT,
            IsVulnerable = IsVulnerable,
            Penalty = Penalty.Redoubled
        };
        Assert.Equal(calculator.CalculateResult(contract, overtricks), score);
    }

    [Fact(DisplayName = "Passed contract should score 0")]
    public void Test10()
    {
        var calculator = new ContractResultCalculator();
        var contract = new Contract { Suit = Suit.Pass };
        Assert.Equal(calculator.CalculateResult(contract, 0), 0);
    }
}
