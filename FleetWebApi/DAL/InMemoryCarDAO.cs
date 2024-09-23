namespace FleetWebApi.DAL
{
    public class InMemoryCarDAO : IDAO<Car>
    {
        private static List<Car> _cars = new List<Car>();
        private static int _carCount = 0;

        public Car? Get(int Id)
        {
            foreach (var car in _cars)
            {
                if (car.Id == Id)
                {
                    return car;
                }
            }
            return null;
        }

        public IEnumerable<Car> GetAll()
        {
            return _cars.ToList();
        }

        public int Insert(Car car)
        {
            _cars.Add(car);
            return ++_carCount;
        }

        public bool Update(Car car)
        {
            Car storedCar = Get(car.Id);
            if (storedCar == null) { return false; }

            storedCar.isAvailable = car.isAvailable;
            storedCar.Model = car.Model;

            return true;
        }

        public bool Delete(int Id)
        {
            Car carToDelete = Get(Id);
            if (carToDelete == null) { return false; }

            _cars.Remove(carToDelete);
            return true;
        }

        public IEnumerable<Car> GetAllNotRented()
        {
            return GetAllCarsBasedOnAvailability(false);
        }

        public IEnumerable<Car> GetAllRented()
        {
            return GetAllCarsBasedOnAvailability(true);
        }

        private IEnumerable<Car> GetAllCarsBasedOnAvailability(bool available)
        {
            var cars = new List<Car>();
            foreach (Car car in GetAll())
            {
                if ((available && car.isAvailable) || (!available && !car.isAvailable))
                {
                    cars.Add(car);
                }
            }
            return cars.ToList();
        }
    }
}