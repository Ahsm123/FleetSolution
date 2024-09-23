using FleetWebApi.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FleetWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarsController : ControllerBase
    {
        const string baseURI = "api/v1/[controller]";
        private readonly IDAO<Car> _dao;

        public CarsController(IDAO<Car> dao)
        {
            _dao = dao;
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            car.Id = _dao.Insert(car);
            return Created($"{baseURI}/{car.Id}", car);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCar(int id)
        {
            Car car = _dao.Get(id);
            if (car == null) { return NotFound(); }
            _dao.Update(car);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCar(int id)
        {
            if(!_dao.Delete(id)) { return NotFound() ; }
            return Ok();
        }
        
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAllNotRented()
        {
            return Ok(_dao.GetAllNotRented());
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAllRented()
        {
            return Ok(_dao.GetAllRented());
        }


    }
}