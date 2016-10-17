using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CoffeeMenu.DAL;
using CoffeeMenu.Models;

namespace CoffeeMenu.Controllers
{
    public class DrinksV2Controller : ApiController
    {
        private MenuContext db = new MenuContext();

        // GET: api/DrinksV2
        public IQueryable<Drink> GetDrinks()
        {
            var drinks = db.Drinks.OrderBy(drink => drink.Price);

            return drinks;
        }

        // GET: api/DrinksV2/5
        [ResponseType(typeof(Drink))]
        public IHttpActionResult GetDrink(int id)
        {
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }

        // PUT: api/DrinksV2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrink(int id, Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drink.Id)
            {
                return BadRequest();
            }

            db.Entry(drink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DrinksV2
        [ResponseType(typeof(Drink))]
        public IHttpActionResult PostDrink(Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drinks.Add(drink);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drink.Id }, drink);
        }

        // DELETE: api/DrinksV2/5
        [ResponseType(typeof(Drink))]
        public IHttpActionResult DeleteDrink(int id)
        {
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return NotFound();
            }

            db.Drinks.Remove(drink);
            db.SaveChanges();

            return Ok(drink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrinkExists(int id)
        {
            return db.Drinks.Count(e => e.Id == id) > 0;
        }
    }
}