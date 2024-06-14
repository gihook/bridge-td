using BridgeLib.Models;
using Newtonsoft.Json.Linq;

namespace BridgeLib.Tests.Loaders;

public class TournamentFileLoader
{
    public async Task<Tournament> Load(string filePath)
    {
        var content = await File.ReadAllTextAsync(filePath);
        var json = JObject.Parse(content);

        var pair = new List<Pair>();
        var boardEntries = GetBoardEntries(json);
        var tournament = new Tournament()
        {
            Pairs = pair,
            BoardEntriesPerBoard = boardEntries,
            Boards = new List<Board>(),
            Movement = new Movement()
        };

        return tournament;
    }

    public async Task<TournamentSampleDescriptor> LoadDescriptor(string filePath)
    {
        var content = await File.ReadAllTextAsync(filePath);
        var json = JObject.Parse(content);

        return json?.ToObject<TournamentSampleDescriptor>() ?? new TournamentSampleDescriptor();
    }

    private Dictionary<int, IEnumerable<BoardEntry>> GetBoardEntries(JObject json)
    {
        var result = new Dictionary<int, IEnumerable<BoardEntry>>();

        var boardResults = json["boardResults"] as JObject ?? new JObject();

        foreach (var item in boardResults)
        {
            var boardNumber = int.Parse(item.Key);
            result[boardNumber] = ParseBoardEntries(item.Value ?? new JObject());
        }

        return result;
    }

    private List<BoardEntry> ParseBoardEntries(JToken json)
    {
        var result = new List<BoardEntry>();

        foreach (var item in json)
        {
            var contractCode = item["contract"]?.ToString() ?? string.Empty;
            var (contract, numberOfOvertricks) = ParseContract(contractCode);

            var seatMap = new Dictionary<int, PlayerSeat>
            {
                ['N'] = PlayerSeat.North,
                ['S'] = PlayerSeat.South,
                ['E'] = PlayerSeat.East,
                ['W'] = PlayerSeat.West,
            };

            contract.Declarer = seatMap[item["declarer"]?.ToString()[0] ?? ' '];
            var boardEntry = new BoardEntry()
            {
                NsPairId = item["nsId"]?.ToObject<int>() ?? 0,
                EwPairId = item["ewId"]?.ToObject<int>() ?? 0,
                BoardNumber = 1,
                Contract = contract,
                NumberOfOvertricks = numberOfOvertricks
            };
            result.Add(boardEntry);
        }

        return result;
    }

    private (Contract contract, int numberOfOvertricks) ParseContract(string contractCode)
    {
        var chars = contractCode.ToCharArray();
        var level = int.Parse(chars[0].ToString());
        var contract = new Contract();

        var suitMap = new Dictionary<int, Suit>
        {
            ['S'] = Suit.Spades,
            ['H'] = Suit.Hearts,
            ['D'] = Suit.Diamonds,
            ['C'] = Suit.Clubs,
            ['N'] = Suit.NT,
        };
        contract.Level = level;
        contract.Suit = suitMap[chars[1]];
        var numberOfXs = contractCode.Where(x => x == 'x').Count();

        if (numberOfXs > 0)
        {
            contract.Penalty = numberOfXs == 1 ? Penalty.Doubled : Penalty.Redoubled;
        }

        var minusSplit = contractCode.Split('-');

        if (minusSplit.Length > 1)
        {
            var numberOfUnderTricks = int.Parse(minusSplit[1]);

            return (contract, -numberOfUnderTricks);
        }

        var plusSplit = contractCode.Split('+');

        if (plusSplit.Length > 1)
        {
            var numberOfOvertricks = int.Parse(plusSplit[1]);

            return (contract, numberOfOvertricks);
        }

        return (contract, 0);
    }
}
