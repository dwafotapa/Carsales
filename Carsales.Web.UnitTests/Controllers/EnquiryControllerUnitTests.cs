using System.Collections.Generic;
using AutoMapper;
using Carsales.Web.Controllers;
using Carsales.Core.Domain;
using Carsales.Web.UnitTests.Extensions;
using Carsales.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Carsales.Core.Repositories;

namespace Carsales.Web.UnitTests.Controllers
{
    public class EnquiryControllerUnitTests
    {
        protected EnquiryController _controller;
        protected Mock<IEnquiryRepository> _enquiryRepositoryMock = new Mock<IEnquiryRepository>();
        protected Mock<ICarRepository> _carRepositoryMock = new Mock<ICarRepository>();
        protected Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public EnquiryControllerUnitTests()
        {
            _controller = new EnquiryController(_enquiryRepositoryMock.Object, _carRepositoryMock.Object, _mapperMock.Object);
        }

        public class TheAddMethod : EnquiryControllerUnitTests
        {
            [Fact]
            public void ReturnsNotFoundResult_WhenIdIsNull()
            {
                var result = _controller.Add(id: null, model: new EnquiryAddViewModel());

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public void ReturnsRedirectToActionResult_WhenModelStateIsNotValid()
            {
                var carId = 1;
                _controller.ModelState.AddModelError("Name", "The Name field is required.");

                var result = (RedirectToActionResult)_controller.Add(id: carId, model: new EnquiryAddViewModel());

                Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal(result.ControllerName, "Car");
                Assert.Equal(result.ActionName, "Details");
                Assert.Equal(result.RouteValues["Id"], carId);
            }

            [Fact]
            public void ReturnsNotFoundResult_WhenModelStateIsValidAndCarIsNotFound()
            {
                int carId = 10;
                _carRepositoryMock.Setup(r => r.Get(carId)).Returns((Car)null);

                var result = _controller.Add(id: carId, model: new EnquiryAddViewModel());

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public void ReturnsRedirectToActionResult_WhenModelStateIsValidAndCarIsFound()
            {
                var car = new Car { Id = 1 };
                var model = new EnquiryAddViewModel();
                var enquiry = new Enquiry { Id = 1 };
                _carRepositoryMock.Setup(r => r.Get(car.Id)).Returns(car);
                _mapperMock.Setup(m => m.Map<EnquiryAddViewModel, Enquiry>(model)).Returns(enquiry);
                _enquiryRepositoryMock.Setup(r => r.Save(enquiry));

                var result = (RedirectToActionResult)_controller.Add(id: car.Id, model: model);

                Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal(result.ActionName, "ThankYou");
            }
        }
    }

}