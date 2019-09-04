using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsDbContext _context;

        public CarsController(CarsDbContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarInfo>>> GetCars()
        {
            var carList = await _context.CarInfo.ToListAsync();

            return carList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarInfo>> GetCarById(int id)
        {
            var found = await _context.CarInfo.FindAsync(id);

            if (found == null)
            {
                return NotFound();
            }
            return found;

        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult<CarInfo>> PostCar(CarInfo car)
        {
            _context.CarInfo.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCarById), new { id = car.CarId }, car);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CarInfo>> PutCar(int id, CarInfo car)
        {
            if(id != car.CarId)
            {
                return BadRequest();
            }
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarInfo>> DeleteCar(int id)
        {
            var car = await _context.CarInfo.FindAsync(id);
            if(car == null)
            {
                return NotFound();
            }

            _context.CarInfo.Remove(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}