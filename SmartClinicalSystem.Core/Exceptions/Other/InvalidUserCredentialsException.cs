using BuildingBlock.BuildingBlocks.Exceptions;

namespace SmartClinicalSystem.Core.Exceptions.Other
{
    internal class InvalidUserCredentialsException : NotFoundException
    {
        private const string INVALID_CREDENTIALS_MESSAGE = "Invalid user credentials";

        public InvalidUserCredentialsException() : base(INVALID_CREDENTIALS_MESSAGE)
        {
        }
    }
}
