using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Carsales.Core.Domain;
using Carsales.Core.Repositories;
using Carsales.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carsales.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var models = _repository.GetAll().AsQueryable().ProjectTo<CarIndexViewModel>().ToList();
            return View(models);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var car = _repository.Get(id.Value);
            if (car == null) return NotFound();
            
            var sellerDetailsViewModel = _mapper.Map<Car, SellerDetailsViewModel>(car);
            var carDetailsViewModel = _mapper.Map<Car, CarDetailsViewModel>(car);
            carDetailsViewModel.SellerDetailsViewModel = sellerDetailsViewModel;
            return View(carDetailsViewModel);
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
