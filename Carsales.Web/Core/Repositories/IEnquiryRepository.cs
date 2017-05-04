using System.Collections.Generic;
using Carsales.Core.Domain;

namespace Carsales.Core.Repositories
{
    public interface IEnquiryRepository
    {
        Enquiry Save(Enquiry enquiry);
    }
}
