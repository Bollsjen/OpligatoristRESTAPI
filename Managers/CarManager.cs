using ObligatoriskOpgave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpligatoristRESTAPI.Managers
{
    public class CarManager
    {
        private static int nextID = 1;
        private static List<Car> Cars = new List<Car>()
        {
            new Car(nextID++,"Model X", 599999.95,"XD69420"),
            new Car(nextID++,"XC90", 449999.95, "TR69421"),
            new Car(nextID++,"Golf", 120000, "BRIAN")
        };


        public IEnumerable<Car> GetAll()
        {
            return Cars;
        }

        public IEnumerable<Car> GetAll(string substring)
        {
            return Cars.;
        }

        public Car GetById(int id)
        {
            return Cars.Find(c => c.ID == id);
        }

        public Car CreateCar(Car car)
        {
            car.ID = nextID++;
            Cars.Add(car);
            return car;
        }

        public Car UpdateCar(Car car, int id)
        {
            Car modCar = GetById(id);
            modCar.Model = car.Model;
            modCar.LicensePlate = car.LicensePlate;
            modCar.Price = car.Price;
            return modCar;
        }

        public Car DeleteCar(int id)
        {
            int index = Cars.FindIndex(c => c.ID == id);
            Car toBeDeleted = Cars[index];
            Cars.RemoveAt(index);
            
            return toBeDeleted;
        }
    }
}
