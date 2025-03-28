﻿// <auto-generated />
using System;
using System.Collections.Generic;
using IPS_survey.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IPS_survey.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250221082346_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IPS_survey.models.Survey", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ClientSignature")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ClientSignatureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WealthMgr_Signature")
                        .HasColumnType("text");

                    b.Property<DateTime?>("WealthMgr_SignatureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("absoluteReturn")
                        .HasColumnType("numeric");

                    b.Property<string>("additionalInfo")
                        .HasColumnType("text");

                    b.Property<decimal?>("alternatives")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("annualIncome")
                        .HasColumnType("numeric");

                    b.Property<string>("assetAvoidance")
                        .HasColumnType("text");

                    b.Property<decimal?>("bonds")
                        .HasColumnType("numeric");

                    b.PrimitiveCollection<List<string>>("currency")
                        .HasColumnType("text[]");

                    b.Property<int?>("dependents")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("dob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("equities")
                        .HasColumnType("numeric");

                    b.Property<string>("ethicalAvoidance")
                        .HasColumnType("text");

                    b.Property<bool?>("ethicalConsiderations")
                        .HasColumnType("boolean");

                    b.Property<string>("ethical_considerationsRank")
                        .HasColumnType("text");

                    b.Property<string>("feeCommunication")
                        .HasColumnType("text");

                    b.Property<string>("feeStructure")
                        .HasColumnType("text");

                    b.Property<bool?>("fees")
                        .HasColumnType("boolean");

                    b.Property<string>("fees_and_costsRank")
                        .HasColumnType("text");

                    b.Property<string>("hasAssetAvoidance")
                        .HasColumnType("text");

                    b.Property<string>("hasEthicalAvoidance")
                        .HasColumnType("text");

                    b.Property<decimal?>("investmentExperience")
                        .HasColumnType("numeric");

                    b.PrimitiveCollection<List<string>>("investmentGoals")
                        .HasColumnType("text[]");

                    b.Property<string>("investmentType")
                        .HasColumnType("text");

                    b.Property<string>("legalConsiderations")
                        .HasColumnType("text");

                    b.Property<string>("liquidAssetPortion")
                        .HasColumnType("text");

                    b.Property<string>("liquidityNeeds")
                        .HasColumnType("text");

                    b.Property<bool?>("managementQuality")
                        .HasColumnType("boolean");

                    b.Property<string>("management_qualityRank")
                        .HasColumnType("text");

                    b.Property<string>("maritalStatus")
                        .HasColumnType("text");

                    b.Property<string>("marketOpportunity")
                        .HasColumnType("text");

                    b.Property<decimal?>("moneyMarket")
                        .HasColumnType("numeric");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<decimal?>("netWorth")
                        .HasColumnType("numeric");

                    b.Property<string>("occupation")
                        .HasColumnType("text");

                    b.Property<string>("otherFactors")
                        .HasColumnType("text");

                    b.Property<string>("otherRank")
                        .HasColumnType("text");

                    b.Property<bool?>("performanceHistory")
                        .HasColumnType("boolean");

                    b.Property<string>("performance_historyRank")
                        .HasColumnType("text");

                    b.Property<string>("portfolioDeclineReaction")
                        .HasColumnType("text");

                    b.Property<string>("rebalancing")
                        .HasColumnType("text");

                    b.Property<string>("rebalancingPreference")
                        .HasColumnType("text");

                    b.Property<decimal?>("rebalancingThreshold")
                        .HasColumnType("numeric");

                    b.Property<string>("reportFrequency")
                        .HasColumnType("text");

                    b.Property<string>("returnExpectations")
                        .HasColumnType("text");

                    b.Property<string>("reviewFrequency")
                        .HasColumnType("text");

                    b.Property<bool?>("riskLevel")
                        .HasColumnType("boolean");

                    b.Property<string>("riskTolerance")
                        .HasColumnType("text");

                    b.Property<string>("risk_levelRank")
                        .HasColumnType("text");

                    b.Property<string>("specificConcerns")
                        .HasColumnType("text");

                    b.Property<string>("sri")
                        .HasColumnType("text");

                    b.Property<string>("timeHorizon")
                        .HasColumnType("text");

                    b.Property<string>("wealthSource")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("surveyRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
