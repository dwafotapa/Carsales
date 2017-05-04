using AutoMapper;
using Carsales.Web.ViewModels;

namespace Carsales.Core.Domain
{
    public class EnquiryProfile : Profile
    {
        public EnquiryProfile()
        {
            CreateMap<EnquiryAddViewModel, Enquiry>();
        }
    }
}
