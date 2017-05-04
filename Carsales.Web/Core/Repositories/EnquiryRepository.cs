using System.Collections.Generic;
using System.Linq;
using Carsales.Core.Domain;

namespace Carsales.Core.Repositories
{
    public class EnquiryRepository : IEnquiryRepository
    {
        private readonly CarsalesContext _context;

        public EnquiryRepository(CarsalesContext context) {
            _context = context;
        }

        public Enquiry Save(Enquiry enquiry)
        {
            // Saves new enquiries, don't update an existing one
            if (enquiry == null || enquiry.Id != 0) return null;
            
            var entityEnty = _context.Enquiries.Add(enquiry);
            _context.SaveChanges();
            return enquiry;
        }
    }
}
