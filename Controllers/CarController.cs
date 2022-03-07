using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using OpligatoristRESTAPI.Managers;

using ObligatoriskOpgave.Models;

namespace OpligatoristRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarManager _manager = new CarManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> OnGet()
        {
            IEnumerable<Car> list = _manager.GetAll();
            if (list == null)
                return NotFound();

            return Ok(list);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> OnGet([FromQuery]string substring)
        {
            IEnumerable<Car> list = _manager.GetAll(substring);
            if (list == null)
                return NotFound();

            return Ok(list);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Car>> OnGet(int id)
        {
            Car car = _manager.GetById(id);
            if (car == null)
                return NotFound();

            return Ok(car);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car car)
        {
            Car _car = _manager.CreateCar(car);
            if (_car != null)
                return Ok(_car);
            else
                return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put([FromBody] Car car, int id)
        {
            Car modCar = _manager.UpdateCar(car, id);
            if (modCar != null)
                return Ok(modCar);

            return NotFound();
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Car>> OnDelete(int id)
        {
            Car deletedCar = _manager.DeleteCar(id);
            if (deletedCar == null)
                return NotFound();

            return Ok(deletedCar);
        }
    }
}
