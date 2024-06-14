using BridgeLib.Models;

namespace BridgeLib.Calculators.Implementations;

public class MatchpointsResultCalculator : IResultCalculator
{
    public IEnumerable<BoardResult> CalculateBoardScore(IEnumerable<BoardEntry> boardEntries)
    {
        return boardEntries.Select(be =>
        {
            var restOfBoardEntries = boardEntries.Where(x => x != be);
            return CalculateBoardResult(be, restOfBoardEntries);
        });
    }

    private BoardResult CalculateBoardResult(
        BoardEntry boardEntry,
        IEnumerable<BoardEntry> boardEntries
    )
    {
        var result = new BoardResult();

        foreach (var rivalBoardEntry in boardEntries)
        {
            var comparativeResult = CompareResults(boardEntry, rivalBoardEntry);
            result.NsScore += comparativeResult.NsScore;
            result.EwScore += comparativeResult.EwScore;
        }

        return result;
    }

    private BoardResult CompareResults(BoardEntry targetEntry, BoardEntry comparedEntry)
    {
        if (targetEntry.Result > comparedEntry.Result)
            return new BoardResult { NsScore = 2, EwScore = 0 };

        if (targetEntry.Result < comparedEntry.Result)
            return new BoardResult { NsScore = 0, EwScore = 2 };

        return new BoardResult { NsScore = 1, EwScore = 1 };
    }
}
