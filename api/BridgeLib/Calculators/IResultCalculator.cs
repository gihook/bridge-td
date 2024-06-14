using BridgeLib.Models;

namespace BridgeLib.Calculators;

public interface IResultCalculator
{
    /* +PairTournamnetScore[] calculatePairScores(Tournament tournament); */
    /* +BoardResult[] calculateBoardScore(BoardEntry[] boardEntries); */
    IEnumerable<BoardResult> CalculateBoardScore(IEnumerable<BoardEntry> boardEntries);
}
