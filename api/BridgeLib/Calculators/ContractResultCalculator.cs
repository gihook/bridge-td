using BridgeLib.Models;

namespace BridgeLib.Calculators
{
    public class ContractResultCalculator
    {
        public int CalculateResult(Contract contract, int numberOfOverTricks)
        {
            var overtricksAward = numberOfOverTricks * GetOvertrickValue(contract);
            var bareContractValue = GetBareContractValue(contract, numberOfOverTricks);
            var gameBonus = bareContractValue >= 150 ? GetGameBonus(contract) : 0;

            var smallSlamBonus = contract.Level == 6 ? GetSmallSlamBonus(contract) : 0;
            var grandSlamBonus = contract.Level == 7 ? GetGrandSlamBonus(contract) : 0;

            var penaltyAward = GetPenaltyAward(contract);

            return bareContractValue
                + penaltyAward
                + overtricksAward
                + gameBonus
                + smallSlamBonus
                + grandSlamBonus;
        }

        private int GetPenaltyAward(Contract contract)
        {
            if (contract.Penalty == Penalty.Doubled)
                return 50;

            return 0;
        }

        private int GetBareContractValue(Contract contract, int numberOfOverTricks)
        {
            var contractBonus = GetContractBonus(contract);
            var levelAward = GetLevelAward(contract);

            if (contract.Penalty == Penalty.Doubled)
                return contractBonus + levelAward * 2;

            return contractBonus + levelAward;
        }

        private int GetOvertrickValue(Contract contract)
        {
            if (contract.Penalty == Penalty.Doubled)
                return 100;

            return GetTrickValue(contract);
        }

        private int GetLevelAward(Contract contract)
        {
            var trickValue = GetTrickValue(contract);
            var levelAward = contract.Level * trickValue;

            if (contract.Suit != Suit.NT)
                return levelAward;

            return levelAward + 10;
        }

        private int GetContractBonus(Contract contract) => 50;

        private int GetTrickValue(Contract contract) =>
            contract.Suit == Suit.Clubs || contract.Suit == Suit.Diamonds ? 20 : 30;

        private int GetGameBonus(Contract contract) => 250;

        private int GetSmallSlamBonus(Contract contract) => 500;

        private int GetGrandSlamBonus(Contract contract) => 1000;
    }
}
