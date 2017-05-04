using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Carsales.Web.Controllers;
using Carsales.Core.Domain;
using Carsales.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Carsales.Core.Repositories;

namespace Carsales.Web.UnitTests.Controllers
{
    public class CarControllerUnitTests
    {
        protected CarController _controller;
        protected Mock<ICarRepository> _repository = new Mock<ICarRepository>();
        protected Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public CarControllerUnitTests()
        {
            _controller = new CarController(_repository.Object, _mapperMock.Object);
        }
        
        public class TheDetailsMethod : CarControllerUnitTests
        {
            [Fact]
            public void ReturnsNotFoundResult_WhenIdIsNull()
            {
                var result = _controller.Details(id: null);

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public void ReturnsNotFoundResult_WhenCarIsNotFound()
            {
                var car = new Car { Id = 1 };
                _repository.Setup(r => r.Get(car.Id)).Returns(car);

                var result = _controller.Details(id: 10);

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public void ReturnsViewResultWithCarDetailsViewModel_WhenCarIsFound()
            {
                var car = new Car { Id = 1 };
                var model = new CarDetailsViewModel { Id = car.Id };
                _repository.Setup(r => r.Get(car.Id)).Returns(car);
                _mapperMock.Setup(m => m.Map<Car, CarDetailsViewModel>(car)).Returns(model);
                
                var result = _controller.Details(id: car.Id);

                var viewResult = Assert.IsType<ViewResult>(result);
                var viewModel = Assert.IsType<CarDetailsViewModel>(viewResult.Model);
                Assert.Equal(viewModel.Id, car.Id);
            }
        }
    }
}