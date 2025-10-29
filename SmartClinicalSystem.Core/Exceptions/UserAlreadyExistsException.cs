using BuildingBlock.BuildingBlocks.Exceptions;

namespace SmartClinicalSystem.Core.Exceptions
{
    public class UserAlreadyExistsException : BadRequestException
    {
        private const string USER_ALREADY_EXISTS_MESSAGE = "User with the given {0} already exists.";
        public UserAlreadyExistsException(string field) : base(string.Format(USER_ALREADY_EXISTS_MESSAGE, field))
        {
        }
    }
}
