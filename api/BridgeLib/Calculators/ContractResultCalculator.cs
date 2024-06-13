using BridgeLib.Models;

namespace BridgeLib.Calculators
{
    public class ContractResultCalculator
    {
        public int CalculateResult(Contract contract, int numberOfOverTricks)
        {
            if (numberOfOverTricks < 0)
                return GetMinusScore(contract, numberOfOverTricks);

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

        private int GetMinusScore(Contract contract, int numberOfOverTricks)
        {
            if (contract.Penalty == Penalty.Doubled)
                return GetDoubledMinusScore(contract, numberOfOverTricks);

            if (contract.Penalty == Penalty.Redoubled)
                return GetDoubledMinusScore(contract, numberOfOverTricks) * 2;

            return 50 * numberOfOverTricks * VulnerabilityMultiplier(contract);
        }

        private int GetDoubledMinusScore(Contract contract, int numberOfOverTricks)
        {
            if (numberOfOverTricks == -1)
                return (-100 * VulnerabilityMultiplier(contract));

            if (numberOfOverTricks == -2)
                return -100 + -200 * VulnerabilityMultiplier(contract);

            return -200 + (numberOfOverTricks + 3 - VulnerabilityMultiplier(contract)) * 300;
        }

        private int GetPenaltyAward(Contract contract)
        {
            if (contract.Penalty == Penalty.Redoubled)
                return 100;

            if (contract.Penalty == Penalty.Doubled)
                return 50;

            return 0;
        }

        private int GetBareContractValue(Contract contract, int numberOfOverTricks)
        {
            var contractBonus = GetContractBonus(contract);
            var levelAward = GetLevelAward(contract);

            if (contract.Penalty == Penalty.Redoubled)
                return contractBonus + levelAward * 4;

            if (contract.Penalty == Penalty.Doubled)
                return contractBonus + levelAward * 2;

            return contractBonus + levelAward;
        }

        private int GetOvertrickValue(Contract contract)
        {
            if (contract.Penalty == Penalty.Redoubled)
                return 200 * VulnerabilityMultiplier(contract);

            if (contract.Penalty == Penalty.Doubled)
                return 100 * VulnerabilityMultiplier(contract);

            return GetTrickValue(contract);
        }

        private int VulnerabilityMultiplier(Contract contract) => contract.IsVulnerable ? 2 : 1;

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

        private int GetGameBonus(Contract contract) => contract.IsVulnerable ? 450 : 250;

        private int GetSmallSlamBonus(Contract contract) => contract.IsVulnerable ? 750 : 500;

        private int GetGrandSlamBonus(Contract contract) => 2 * GetSmallSlamBonus(contract);
    }
}
