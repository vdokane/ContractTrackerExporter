using ContractTracker.Repository.CommandRepositories;
using ContractTracker.Repository.Implementation;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.MockQueryRepositories;
using ContractTracker.Repository.QueryRepositories;
using FileExporter.Services;


namespace FileExporter.Factory
{
    public class ServiceFactory
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceFactory(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public ContractExportService BuildContractExportService(bool useMock)
        {
            IContractQueryRepository contractQueryRepository;
            IContractPersonQueryRepository contractPersonQueryRepository;
            IContractTrackingHistoryQueryRepository contractTrackingHistoryQueryRepository;
            if (useMock)
            {
                contractQueryRepository = new MockContractQueryRepository();
                contractPersonQueryRepository = new ContractPersonQueryRepository(unitOfWork); //TODO need a mock
                contractTrackingHistoryQueryRepository = new ContractTrackingHistoryQueryRepository(unitOfWork);
            }
            else
            {
                contractQueryRepository = new ContractQueryRepository(unitOfWork);
                contractPersonQueryRepository = new ContractPersonQueryRepository(unitOfWork);
                contractTrackingHistoryQueryRepository = new ContractTrackingHistoryQueryRepository(unitOfWork);
            }

            return new ContractExportService(contractQueryRepository, contractPersonQueryRepository, contractTrackingHistoryQueryRepository);
        }

        public DocumentAttachmentService BuildDocumentAttachmentService(bool useMock)
        {
            IDocumentQueryRepository documentQueryRepository;
            if (useMock)
            {
                documentQueryRepository = new MockDocumentAttachmentQueryRepository(unitOfWork);
            }
            else
            {
                documentQueryRepository = new DocumentAttachmentQueryRepository(unitOfWork);
            }
            return new DocumentAttachmentService(documentQueryRepository);
        }

        public BudgetExportService BuildBudgetExportService(bool useMock)
        {
            if (!useMock)
            {
                IBudgetQueryRepository budgetQueryRepository = new BudgetQueryRepository(unitOfWork);
                return new BudgetExportService(budgetQueryRepository);
            }
            else
            {
                var mockRepo = new MockBudgetQueryRepository();
                return new BudgetExportService(mockRepo);
            }

        }

        //Currently doesn't hit the db, booya! Easy!
        public VendorExportService BuildVendorExportService()
        {
            return new VendorExportService();
        }
        public DeliverableExportService BuildDeliverableExportService(bool useMock)
        {
            if (!useMock)
            {
                var repo = new DeliverableQueryRepository(unitOfWork);
                return new DeliverableExportService(repo);
            }
            else
            {
                var mockRepo = new MockDeliverableQueryRepository();
                return new DeliverableExportService(mockRepo);
            }

        }

        public ContractChangeExportService BuildContractChangeExportService(bool useMock)
        {
            var repo = new ContractChangeQueryRepository(unitOfWork);
            return new ContractChangeExportService(repo);
        }

        public ContractChangeAttachmentExportService BuildContractChangeAttachmentExportService(bool useMock)
        {
            var repo = new ContractChangeAttachmentRepository(unitOfWork);
            return new ContractChangeAttachmentExportService(repo);
        }

        public ExportLogService BuildExportLogService()
        {
            var repo = new ExportLogCommandRepository(unitOfWork);
            return new ExportLogService(repo);
        }

    }
}
