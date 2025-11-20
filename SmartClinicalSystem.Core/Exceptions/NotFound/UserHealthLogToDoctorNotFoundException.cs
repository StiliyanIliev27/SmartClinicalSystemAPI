using BuildingBlock.BuildingBlocks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinicalSystem.Core.Exceptions.NotFound
{
    internal class UserHealthLogToDoctorNotFoundException : NotFoundException
    {
        public UserHealthLogToDoctorNotFoundException(string id) : base("User Health log to Doctor", id)
        {
        }
    }
}
