using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using FileExporter.ExportModels;
using System;


namespace FileExporter.Services
{

    public class ContractChangeAttachmentExportService
    {
        private readonly IContractChangeAttachmentRepository contractChangeAttachmentRepository;
        public ContractChangeAttachmentExportService(IContractChangeAttachmentRepository contractChangeAttachmentRepository)
        {
            this.contractChangeAttachmentRepository = contractChangeAttachmentRepository;
        }

        public async Task<ContractChangeAttachmentExportModel?> GetOriginalContractChangeAttachmentExportModel(int contractChangeId)
        {
            var entity = await contractChangeAttachmentRepository.GetOriginalAmnededContractDocument(contractChangeId);
            if (entity == null)
                return null;

            return MapEntityToModel(entity);
        }

        public async Task<ContractChangeAttachmentExportModel?> GetRedactedContractChangeAttachmentExportModelById(int contractChangeAttachmentId)
        {
            var entity = await contractChangeAttachmentRepository.GetRedactedAmendedContractDocument(contractChangeAttachmentId);
            if (entity == null)
                return null;

            return MapEntityToModel(entity);
        }


        private ContractChangeAttachmentExportModel? MapEntityToModel(ContractChangeAttachments entity)
        {
            var model = new ContractChangeAttachmentExportModel();
            model.Attachment = entity.Attachment;
            model.AttachmentFilename = entity.AttachmentFilename;
            model.AddedDate = entity.AddedDate;
            model.ExportDate = entity.ExportDate;
            model.ContractChangeAttachmentId = entity.ContractChangeAttachmentId;
            return model;
        }
    }
}
