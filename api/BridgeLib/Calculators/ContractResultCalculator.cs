using BridgeLib.Models;

namespace BridgeLib.Calculators
{
    public class ContractResultCalculator
    {
        public int CalculateResult(Contract contract, int numberOfOverTricks)
        {
            var contractBonus = GetContractBonus(contract);
            var trickValue = GetTrickValue(contract);

            var levelAward = contract.Level * trickValue;
            var overtricksAward = numberOfOverTricks * trickValue;

            var bareContractValue = contractBonus + levelAward;
            var gameBonus = bareContractValue >= 150 ? GetGameBonus(contract) : 0;

            var smallSlamBonus = contract.Level == 6 ? GetSmallSlamBonus(contract) : 0;
            var grandSlamBonus = contract.Level == 7 ? GetGrandSlamBonus(contract) : 0;

            return bareContractValue
                + overtricksAward
                + gameBonus
                + smallSlamBonus
                + grandSlamBonus;
        }

        private int GetContractBonus(Contract contract) => contract.Suit == Suit.NT ? 60 : 50;

        private int GetTrickValue(Contract contract) =>
            contract.Suit == Suit.Clubs || contract.Suit == Suit.Diamonds ? 20 : 30;

        private int GetGameBonus(Contract contract) => 250;

        private int GetSmallSlamBonus(Contract contract) => 500;

        private int GetGrandSlamBonus(Contract contract) => 1000;
    }
}
