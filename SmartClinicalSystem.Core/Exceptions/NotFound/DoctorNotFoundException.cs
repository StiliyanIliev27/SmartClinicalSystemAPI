using BuildingBlock.BuildingBlocks.Exceptions;

namespace SmartClinicalSystem.Core.Exceptions.NotFound
{
    public class DoctorNotFoundException : NotFoundException
    {
        public DoctorNotFoundException(string id) : base("Doctor", id)
        {
        }
    }
}
