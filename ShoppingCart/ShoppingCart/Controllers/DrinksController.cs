using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    /// <summary>
    /// Drinks api - function
    /// </summary>
    public class DrinksController : ApiController
    {
        // Static list used as an easy implementation of data
        public static List<Drink> Drinks = new List<Drink>()
            {
                new Drink(){Name = "Fanta", Quantity = 3},
                new Drink(){Name = "Pepsi", Quantity = 1},
                new Drink(){Name = "Lilt", Quantity = 4},
                new Drink(){Name = "Tango", Quantity = 4}

            };

        // POST api/drinks
        /// <summary>
        /// Add a drink and quantity to the shopping list
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Drink value)
        {
            // Check if the drink is already on the shopping list
            var drinkExistsAlready = Drinks.FirstOrDefault(x => x.Name.ToLower() == value.Name.ToLower());
            // Add it to the list if not already there
            if (drinkExistsAlready == null) Drinks.Add(value);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Drink order updated");
            return response;


        }

        // PUT api/drinks/
        /// <summary>
        /// Update the quantity of a drink on the shopping list based on the drinks name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]Drink value)
        {
            //Find the supplied drink
            var requiredDrink = Drinks.FirstOrDefault(x => x.Name.ToLower() == id.ToLower());

            // Default message if drink not found
            var message = "Drink quantity not updated  -  please check your order is correct";

            // If it exsists then update the quanity
            if (requiredDrink != null && value.Quantity > 0)
            {
                requiredDrink.Quantity = value.Quantity;
                message = "Quantity successfully updated";
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
        }

        // DELETE api/drinks/pepsi
        /// <summary>
        /// Remove a  drink and its quantity from a shopping list based on its name
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            //Find the supplied drink
            var requiredDrink = Drinks.FirstOrDefault(x => x.Name.ToLower() == id.ToLower());
           
            // Default message if drink not found
            var message = "Drink order not found";
            // If it exists then delete from list
            if (requiredDrink != null)
            {
                Drinks.Remove(requiredDrink);
                message = "Drink order deleted";
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, message);
            return response;
            

        }
        
        // GET api/drinks
        /// <summary>
        /// Returns all drinks on the shopping list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            // Return response message containing the list of drinks on the shopping list
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Drinks);
            return response;
        }

        // GET api/drinks/pepsi
        /// <summary>
        /// Returns the quantity of a drink on the shopping list based on the drink name supplied
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            //Default quantity
            var quantity = 0;

            // Try and find the drink in the shopping list
            var drink = Drinks.FirstOrDefault(x => x.Name.ToLower() == id);
            
            // If drink is on the shopping list then return the quantity requested
            if(drink != null) quantity = drink.Quantity;

            // Genereate the response message
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, quantity);
            return response;
        }

        
    }
}