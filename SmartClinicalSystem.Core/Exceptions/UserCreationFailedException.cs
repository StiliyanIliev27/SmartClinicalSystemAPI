using BuildingBlock.BuildingBlocks.Exceptions;
namespace SmartClinicalSystem.Core.Exceptions
{
    public class UserCreationFailedException : BadRequestException
    {
        public UserCreationFailedException(string message) : base(message)
        {
        }
    }
}
