using IPS_survey.ENUMS;
using System.ComponentModel.DataAnnotations;

namespace IPS_survey.models
{
    public class IPSSurveyRequestDto
    {
        public string? name { get; set; } = string.Empty;
        [EmailAddress]
        public required string email { get; set; } = string.Empty;
        public DateTime? dob { get; set; }
        public string? occupation { get; set; } = string.Empty;
        public string? maritalStatus { get; set; } = string.Empty;
        public int? dependents { get; set; }
        public decimal? annualIncome { get; set; }
        public decimal? netWorth { get; set; }
        public string? wealthSource { get; set; } = string.Empty;
        public decimal? investmentExperience { get; set; }
        public List<string>? investmentGoals { get; set; } = new List<string>();
        public decimal? absoluteReturn { get; set; }
        public string? timeHorizon { get; set; } = string.Empty;
        public string? investmentType { get; set; } = string.Empty;
        public List<string>? currency { get; set; } = new List<string>();
        public string? liquidityNeeds { get; set; } = string.Empty;
        public string? liquidAssetPortion { get; set; } = string.Empty;
        public string? legalConsiderations { get; set; } = string.Empty;
        public string? riskTolerance { get; set; } = string.Empty;
        public string? returnExpectations { get; set; } = string.Empty;
        public string? portfolioDeclineReaction { get; set; } = string.Empty;
        public decimal? moneyMarket { get; set; }
        public decimal? bonds { get; set; }
        public decimal? equities { get; set; }
        public decimal? alternatives { get; set; }
        public string? assetAvoidance { get; set; } = string.Empty;
        public string? marketOpportunity { get; set; } = string.Empty;
        public string? sri { get; set; } = string.Empty;
        public bool? performanceHistory { get; set; }
        public bool? riskLevel { get; set; }
        public bool? managementQuality { get; set; }
        public bool? fees { get; set; }
        public bool? ethicalConsiderations { get; set; }
        public string? otherFactors { get; set; } = string.Empty;
        public string? reportFrequency { get; set; } = string.Empty;
        public string? reviewFrequency { get; set; } = string.Empty;
        public string? rebalancing { get; set; } = string.Empty;
        public string? ethicalAvoidance { get; set; } = string.Empty;
        public string? feeStructure { get; set; } = string.Empty;
        public string? feeCommunication { get; set; } = string.Empty;
        public string? additionalInfo { get; set; } = string.Empty;
        public string? specificConcerns { get; set; } = string.Empty;
        public string? performance_historyRank { get; set; } = string.Empty;
        public string? risk_levelRank { get; set; } = string.Empty;
        public string? management_qualityRank { get; set; } = string.Empty;
        public string? hasEthicalAvoidance { get; set; } = string.Empty;
        public string? hasAssetAvoidance { get; set; } = string.Empty;
        public string? fees_and_costsRank { get; set; } = string.Empty;
        public string? ethical_considerationsRank { get; set; } = string.Empty;
        public string? otherRank { get; set; } = string.Empty;
        public string? rebalancingPreference { get; set; } = string.Empty;
        public decimal? rebalancingThreshold { get; set; }
        public string? clientSignature { get; set; } //Base64
        public DateTime? ClientSignatureDate { get; set; }
        public string? WealthMgr_Signature { get; set; } = string.Empty;
        public DateTime? WealthMgr_SignatureDate { get; set; }
    }
}