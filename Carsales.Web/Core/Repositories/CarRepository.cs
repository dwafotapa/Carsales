using System.Collections.Generic;
using System.Linq;
using Carsales.Core.Domain;

namespace Carsales.Core.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarsalesContext _context;

        public CarRepository(CarsalesContext context) {
            _context = context;
        }

        public Car Get(int id)
        {
            return _context.Cars.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }
    }
}
