using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTracker.Repository.MockQueryRepositories
{
    public class MockContractQueryRepository : IContractQueryRepository
    {
        public MockContractQueryRepository() { }
        public async Task<List<Contracts>> GetAllContractsReadyToBeSubmitted(List<int> allContractIds)
        {
            var allMockContracts = new List<Contracts>();
            allMockContracts.Add(new Contracts()
            {
                AdministrativeCostPercentage = "0.00",
                Amount = 1500,
                AuthorizedADPayment = false,
                BusinessCaseDate = new DateTime(2022, 1, 13),
                BusinessCaseStudyDone = true,
                CapitalImprovementDescription = "cap improve desc",
                CapitalImprovementsOnStateProperty = true,
                CFDA = "CFDA",
                Confidential = false,
                ConsideredBackToTheState = true,
                ContractAmmendedDate = new DateTime(2022, 2, 13),
                
                ContractEndDate = new DateTime(2013, 1, 13),
                ContractExecuteDate = new DateTime(2022, 1, 14),
                ContractID = 1,
                ContractInvolveFinancialAid = true,
                ContractNum = "SC0083",
                ContractStartDate = new DateTime(2022, 1, 15),
                ContractStatus = "A",
                ContractStatutoryAuthority = "stat auth",
               // ContractTypeID = 1,
                //CreatedByUserId = 1,
                //CreatedDate = new DateTime(2022, 1, 1),
                CSFA = "CFSA",
                ExemptionExplanation = "Exm expanation",
                ExistingContract = false,
                ExportDate = null,
               // FLAIRContractId = "99", //is this correct?
                GeneralComments = "These are general comments",
                HourlyRate = 33,
                IndirectCostInd = true,
                InternalComments = "Internal Comments",
              //  LastUpdateByUserId = 1,
               // LastUpdateDate = DateTime.Now,
                LegalChallengeDescription = "Legal challen desc",
                LegalChallengesProcurement = true,
                MarkedForDeletion = false,
                PeriodicIncreasePercentage = 99,
                PreviouslyDoneByTheState = false,
                ProcurementMethodID = 1,
                ProvidePeriodicIncrease = true,
              //  PublicContractAppContractId = 1,
                RecipientTypeCode = "RTC",
                Recurring = false,
                RejectionMessage = "reject meesage",
                ServiceType = "service t ype",
                StateTermContractIdentifier = "stci",
                SweepStatus = "sweep status",
                ValueCapitalImprovements = 334,
                ValueUnamortizedCapitalImprovements = 433,
                VendorNumber = "VENNUMBR",
                VendorNumberSequence = "002",
                VendorType = "F"


            });

            return await Task.FromResult(allMockContracts);
        }
    }
}
