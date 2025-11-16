using BuildingBlock.BuildingBlocks.CQRS;

namespace SmartClinicalSystem.Core.Queries.AI
{
    public record GetSummaryCheckQuery(int Period) : IQuery<GetSummaryCheckResult>;
    public record GetSummaryCheckResult(string Summary);
    public class GetSummaryCheckQueryHandler
    {
    }
}
