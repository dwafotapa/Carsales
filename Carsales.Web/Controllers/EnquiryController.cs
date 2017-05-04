using System.Linq;
using AutoMapper;
using Carsales.Core.Domain;
using Carsales.Core.Repositories;
using Carsales.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carsales.Web.Controllers
{
    public class EnquiryController : Controller
    {
        private readonly IEnquiryRepository _enquiryRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public EnquiryController(IEnquiryRepository enquiryRepository, ICarRepository carRepository, IMapper mapper)
        {
            _enquiryRepository = enquiryRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int? id, EnquiryAddViewModel model)
        {
            if (id == null) return this.NotFound();

            if (ModelState.IsValid)
            {
                var car = _carRepository.Get(id.Value);
                if (car == null) return this.NotFound();

                var enquiry = _mapper.Map<EnquiryAddViewModel, Enquiry>(model);
                enquiry.Car = car;
                _enquiryRepository.Save(enquiry);
                return this.RedirectToAction("ThankYou");
            }
            
            return this.RedirectToAction("Details", "Car", new { id });
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
