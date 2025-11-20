using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.Users
{
    public record GetNotificationsQuery(string UserId) : IQuery<GetNotificationsResult>;
    public record GetNotificationsResult(IEnumerable<Notification> Notifications);
    public class GetNotificationsByUserQueryHandler(INotificationService notificationService) 
        : IQueryHandler<GetNotificationsQuery, GetNotificationsResult>
    {
        public async Task<GetNotificationsResult> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            return new GetNotificationsResult(await notificationService.GetNotificationsByUser(request.UserId));
        }
    }
}
