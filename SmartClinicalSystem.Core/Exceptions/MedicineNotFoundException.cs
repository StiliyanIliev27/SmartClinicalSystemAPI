using BuildingBlock.BuildingBlocks.Exceptions;

namespace SmartClinicalSystem.Core.Exceptions
{
    public class MedicineNotFoundException : NotFoundException
    {
        public MedicineNotFoundException(string id) : base("Medicine", id)
        {
        }
    }
}
