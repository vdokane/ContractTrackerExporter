﻿using ContractTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExporter.ExportModels;
using ContractTracker.Repository.EntityModels;
using FileExporter.Infrastructure;

namespace FileExporter.Services
{
    public class DeliverableExportService
    {
        private readonly IDeliverableQueryRepository deliverableQueryRepository;
        public DeliverableExportService(IDeliverableQueryRepository deliverableQueryRepository)
        {
            this.deliverableQueryRepository = deliverableQueryRepository;
        }

        public async Task<List<DeliverableExportModel>> GetDeliverableModelsByContractId(int contractId)
        {
            var entities = await deliverableQueryRepository.GetDeliverablesByContractId(contractId);
            return entities.ConvertAll(x => MapEntityToModel(x));
        }
        public string BuildDeliverableRow(DeliverableExportModel model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(RowConstants.Deliverable).Append(FieldDelimiter.Delimiter);
            
             if (model.ExportDate.HasValue)
                 stringBuilder.Append(SaveConstants.Update).Append(FieldDelimiter.Delimiter);
             else
                 stringBuilder.Append(SaveConstants.Insert).Append(FieldDelimiter.Delimiter);
            
            stringBuilder.Append(model.CommodityCode.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.DeliverablePrices.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.DocumentationPageReference).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.MajorDeliverable).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.CommodityCode).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.PerformanceMatrix).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.NonPriceJustification).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.FinancialConsequences).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.PaymentDescription).Append(FieldDelimiter.Delimiter);
     
            return stringBuilder.ToString();
        }

        private DeliverableExportModel MapEntityToModel(Deliverables entity)
        {
            var model = new DeliverableExportModel();
            model.DeliverablePrices = entity.DeliverablePrices;
            model.MajorDeliverable  = entity.MajorDeliverable;
            model.DeliverableId = entity.DeliverableId;
            model.NonPriceJustification = entity.NonPriceJustification;
            model.ContractId = entity.ContractId;
            model.CommodityCode = entity.CommodityCode;
            model.DocumentationPageReference = entity.DocumentationPageReference;
            model.FinancialConsequences = entity.FinancialConsequences;
            model.MajorDeliverable = entity.MajorDeliverable;
            model.MethodOfPaymentId = entity.MethodOfPaymentId;  
            model.PaymentDescription = entity.MethodOfPayments?.PaymentDescription;
            model.NonPriceJustification = entity.NonPriceJustification;
            model.PerformanceMatrix = entity.PerformanceMatrix;
            //model.ExportDate = entity.Ex THE TSBLE DOESNT HAVE EXPORT DATE@?
            return model;
        }
    }
}