using BuildingBlock.BuildingBlocks.Exceptions;
namespace SmartClinicalSystem.Core.Exceptions.Other
{
    public class UserCreationFailedException : BadRequestException
    {
        public UserCreationFailedException(string message) : base(message)
        {
        }
    }
}
