using BuildingBlock.BuildingBlocks.Exceptions;
namespace SmartClinicalSystem.Core.Exceptions
{
    public class MedicineAlreadyExistsException : BadRequestException
    {
        private const string MEDICNE_ALREADY_EXISTS_MESSAGE = "Medicne with the given name already exists.";
        public MedicineAlreadyExistsException() : base(MEDICNE_ALREADY_EXISTS_MESSAGE)
        {
        }
    }
}
