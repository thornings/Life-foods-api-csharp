using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Life_foods_api_csharp.Models.V1;
using Life_foods_api_csharp.Services.V1;
using Newtonsoft.Json;

namespace Life_foods_api_csharp.Controller.V1
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly FoodApiContext _context;
        private readonly IFoodsService _foodsService;

        public FoodsController(FoodApiContext context, IFoodsService foodsService)
        {
            _context = context;
            _foodsService = foodsService;
        }

        // GET: api/Foods
        [HttpGet]
        public IActionResult GetFoods([FromQuery] FoodParameters foodParams)
        {
            var foods = _foodsService.GetAllFoods(foodParams);          
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(foods.PagedInformation()));
            return Ok(foods);
        }

        // GET: api/Foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

        // PUT: api/Foods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food food)
        {
            if (id != food.FoodId)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Foods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFood", new { id = food.FoodId }, food);
        }

        // DELETE: api/Foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.FoodId == id);
        }
    }
}
