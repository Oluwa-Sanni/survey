using IPS_survey.ENUMS;
using System.ComponentModel.DataAnnotations;

namespace IPS_survey.models
{
    public class Survey
    {

        public Survey()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string? Id { get; set; }

        public string? name { get; set; }
        public string email { get; set; }
        public DateTime? dob { get; set; }
        public string? occupation { get; set; }
        public string? maritalStatus { get; set; }
        public int? dependents { get; set; }
        //=================================
        public decimal? annualIncome { get; set; }
        public decimal? netWorth { get; set; }
        public string? wealthSource { get; set; }
        public decimal? investmentExperience { get; set; }
        //=================================
        public List<string>? investmentGoals { get; set; }
        public decimal? absoluteReturn { get; set; }
        public string? timeHorizon { get; set; }
        public string? investmentType { get; set; }
        public List<string>? currency { get; set; }
        public string? liquidityNeeds { get; set; }
        public string? liquidAssetPortion { get; set; }
        public string? legalConsiderations { get; set; }
        public string? riskTolerance { get; set; }
        public string? returnExpectations { get; set; }
        public string? portfolioDeclineReaction { get; set; }
        public decimal? moneyMarket { get; set; }
        public decimal? bonds { get; set; }
        public decimal? equities { get; set; }
        public decimal? alternatives { get; set; }

        public string? assetAvoidance { get; set; }//YES / NO / Please specify
        public string? marketOpportunity { get; set; }
        public string? sri { get; set; }//Yes or No
        public bool? performanceHistory { get; set; }//Yes or No
        public bool? riskLevel { get; set; }//Yes or No
        public bool? managementQuality { get; set; }
        public bool? fees { get; set; }
        public bool? ethicalConsiderations { get; set; }
        public string? otherFactors { get; set; }
        public string? reportFrequency { get; set; }
        public string? reviewFrequency { get; set; }
        public string? rebalancing { get; set; }
        public string? ethicalAvoidance { get; set; }


        public string? feeStructure { get; set; }
        public string? feeCommunication { get; set; }

        public string? additionalInfo { get; set; }
        public string? specificConcerns { get; set; }
        public string? performance_historyRank { get; set; }
        public string? risk_levelRank { get; set; }
        public string? management_qualityRank { get; set; }
        public string? hasEthicalAvoidance { get; set; }
        public string? hasAssetAvoidance { get; set; }
        public string? fees_and_costsRank { get; set; }
        public string? ethical_considerationsRank { get; set; }
        public string? otherRank { get; set; }
        public string? rebalancingPreference { get; set; }
        public decimal? rebalancingThreshold { get; set; }
        public string? ClientSignature { get; set; }
        public DateTime? ClientSignatureDate { get; set; }
        public string? WealthMgr_Signature { get; set; }
        public DateTime? WealthMgr_SignatureDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


    }
}
