using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.AI
{
    public record DiagnoseResultDto(
        string PossibleConditions, 
        IEnumerable<Medicine> RecommendedMedicines, 
        string Advice
    );
    public record GetDiagnoseQuery(string Symptoms) : IQuery<GetDiagnoseResult>;
    public record GetDiagnoseResult(DiagnoseResultDto? Result);
    public class GetDiagnoseQueryHandler(ISmartService smartService) : IQueryHandler<GetDiagnoseQuery, GetDiagnoseResult>
    {
        public async Task<GetDiagnoseResult> Handle(GetDiagnoseQuery request, CancellationToken cancellationToken)
        {
            var result = await smartService.GetDiagnosisAsync(request.Symptoms);
            
            if(result == null)
            {
                return new GetDiagnoseResult(new DiagnoseResultDto("", null!, ""));
            }

            return new GetDiagnoseResult(result);
        }
    }
}
