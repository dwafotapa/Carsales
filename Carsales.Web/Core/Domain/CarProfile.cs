using AutoMapper;
using Carsales.Web.ViewModels;

namespace Carsales.Core.Domain
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarIndexViewModel>();
            CreateMap<Car, SellerDetailsViewModel>();
            CreateMap<Car, CarDetailsViewModel>();
        }
    }
}
