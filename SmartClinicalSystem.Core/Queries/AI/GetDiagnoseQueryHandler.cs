using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Medicine;
using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Models;
using System.Text.Json;

namespace SmartClinicalSystem.Core.Queries.AI
{
    public record DiagnoseResultDto(
        string PossibleConditions, 
        IEnumerable<GetMedicinesAiConsultationDTO> RecommendedMedicines, 
        string Advice
    );
    public record GetDiagnoseQuery(string Symptoms, string UserId) : IQuery<GetDiagnoseResult>;
    public record GetDiagnoseResult(DiagnoseResultDto? Result);
    public class GetDiagnoseQueryHandler(ISmartService smartService, IRepository repository) : IQueryHandler<GetDiagnoseQuery, GetDiagnoseResult>
    {
        public async Task<GetDiagnoseResult> Handle(GetDiagnoseQuery query, CancellationToken cancellationToken)
        {
            var result = await smartService.GetDiagnosisAsync(query.Symptoms);
            
            if(result == null)
            {
                return new GetDiagnoseResult(new DiagnoseResultDto("", null!, ""));
            }

            var consulation = new AiDiagnosisConsultation()
            {
                AiResponseJson = JsonSerializer.Serialize(result),
                UserId = query.UserId,
                Symptoms = query.Symptoms
            };

            await repository.AddAsync(consulation);
            await repository.SaveChangesAsync();

            return new GetDiagnoseResult(result);
        }
    }
}
