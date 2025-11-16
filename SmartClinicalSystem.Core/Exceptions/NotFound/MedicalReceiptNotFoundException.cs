using BuildingBlock.BuildingBlocks.Exceptions;

namespace SmartClinicalSystem.Core.Exceptions.NotFound
{
    public class MedicalReceiptNotFoundException : NotFoundException
    {
        public MedicalReceiptNotFoundException(string id) : base("Medical Receipt", id)
        {
        }
    }
}
