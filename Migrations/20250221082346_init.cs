using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPS_survey.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "surveyRequest",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    occupation = table.Column<string>(type: "text", nullable: true),
                    maritalStatus = table.Column<string>(type: "text", nullable: true),
                    dependents = table.Column<int>(type: "integer", nullable: true),
                    annualIncome = table.Column<decimal>(type: "numeric", nullable: true),
                    netWorth = table.Column<decimal>(type: "numeric", nullable: true),
                    wealthSource = table.Column<string>(type: "text", nullable: true),
                    investmentExperience = table.Column<decimal>(type: "numeric", nullable: true),
                    investmentGoals = table.Column<List<string>>(type: "text[]", nullable: true),
                    absoluteReturn = table.Column<decimal>(type: "numeric", nullable: true),
                    timeHorizon = table.Column<string>(type: "text", nullable: true),
                    investmentType = table.Column<string>(type: "text", nullable: true),
                    currency = table.Column<List<string>>(type: "text[]", nullable: true),
                    liquidityNeeds = table.Column<string>(type: "text", nullable: true),
                    liquidAssetPortion = table.Column<string>(type: "text", nullable: true),
                    legalConsiderations = table.Column<string>(type: "text", nullable: true),
                    riskTolerance = table.Column<string>(type: "text", nullable: true),
                    returnExpectations = table.Column<string>(type: "text", nullable: true),
                    portfolioDeclineReaction = table.Column<string>(type: "text", nullable: true),
                    moneyMarket = table.Column<decimal>(type: "numeric", nullable: true),
                    bonds = table.Column<decimal>(type: "numeric", nullable: true),
                    equities = table.Column<decimal>(type: "numeric", nullable: true),
                    alternatives = table.Column<decimal>(type: "numeric", nullable: true),
                    assetAvoidance = table.Column<string>(type: "text", nullable: true),
                    marketOpportunity = table.Column<string>(type: "text", nullable: true),
                    sri = table.Column<string>(type: "text", nullable: true),
                    performanceHistory = table.Column<bool>(type: "boolean", nullable: true),
                    riskLevel = table.Column<bool>(type: "boolean", nullable: true),
                    managementQuality = table.Column<bool>(type: "boolean", nullable: true),
                    fees = table.Column<bool>(type: "boolean", nullable: true),
                    ethicalConsiderations = table.Column<bool>(type: "boolean", nullable: true),
                    otherFactors = table.Column<string>(type: "text", nullable: true),
                    reportFrequency = table.Column<string>(type: "text", nullable: true),
                    reviewFrequency = table.Column<string>(type: "text", nullable: true),
                    rebalancing = table.Column<string>(type: "text", nullable: true),
                    ethicalAvoidance = table.Column<string>(type: "text", nullable: true),
                    feeStructure = table.Column<string>(type: "text", nullable: true),
                    feeCommunication = table.Column<string>(type: "text", nullable: true),
                    additionalInfo = table.Column<string>(type: "text", nullable: true),
                    specificConcerns = table.Column<string>(type: "text", nullable: true),
                    performance_historyRank = table.Column<string>(type: "text", nullable: true),
                    risk_levelRank = table.Column<string>(type: "text", nullable: true),
                    management_qualityRank = table.Column<string>(type: "text", nullable: true),
                    hasEthicalAvoidance = table.Column<string>(type: "text", nullable: true),
                    hasAssetAvoidance = table.Column<string>(type: "text", nullable: true),
                    fees_and_costsRank = table.Column<string>(type: "text", nullable: true),
                    ethical_considerationsRank = table.Column<string>(type: "text", nullable: true),
                    otherRank = table.Column<string>(type: "text", nullable: true),
                    rebalancingPreference = table.Column<string>(type: "text", nullable: true),
                    rebalancingThreshold = table.Column<decimal>(type: "numeric", nullable: true),
                    ClientSignature = table.Column<string>(type: "text", nullable: true),
                    ClientSignatureDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WealthMgr_Signature = table.Column<string>(type: "text", nullable: true),
                    WealthMgr_SignatureDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveyRequest", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "surveyRequest");
        }
    }
}
