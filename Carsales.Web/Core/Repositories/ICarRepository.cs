using System.Collections.Generic;
using Carsales.Core.Domain;

namespace Carsales.Core.Repositories
{
    public interface ICarRepository
    {
        Car Get(int id);
        IEnumerable<Car> GetAll();
    }
}
