using BuildingBlock.BuildingBlocks.Exceptions;
namespace SmartClinicalSystem.Core.Exceptions.NotFound
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string id) : base("User", id)
        {
        }
    }
}
