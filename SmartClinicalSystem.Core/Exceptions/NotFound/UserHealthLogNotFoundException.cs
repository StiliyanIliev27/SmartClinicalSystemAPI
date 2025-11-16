using BuildingBlock.BuildingBlocks.Exceptions;
namespace SmartClinicalSystem.Core.Exceptions.NotFound
{
    public class UserHealthLogNotFoundException : NotFoundException
    {
        public UserHealthLogNotFoundException(string id) : base("Health Log", id)
        {
        }
    }
}
