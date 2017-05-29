using Checkout.ApiServices.Customers.RequestModels;
using Checkout.ApiServices.Customers.ResponseModels;
using Checkout.ApiServices.Drinks.RequestModels;
using Checkout.ApiServices.Drinks.ResponseModels;
using Checkout.ApiServices.SharedModels;
using Checkout.Utilities;
using System;
namespace Checkout.ApiServices.Customers
{
    public class DrinkService {
     
    /// <summary>
    /// Add a drink to the shopping list
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    public HttpResponse<OkResponse> AddDrink(AddDrink requestModel)
    {
        return new ApiHttpClient().PostRequest<OkResponse>(ApiUrls.Drinks, AppSettings.SecretKey, requestModel);
    }

    /// <summary>
    /// Update a drink in the shopping list
    /// </summary>
    /// <param name="drinkName"></param>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    public HttpResponse<OkResponse> UpdateDrink(string drinkName, UpdateDrink requestModel)
    {
        var updateDrinkUri = string.Format(ApiUrls.Drink, drinkName);
        return new ApiHttpClient().PutRequest<OkResponse>(updateDrinkUri, AppSettings.SecretKey, requestModel);
    }

    /// <summary>
    /// Delete a drink from the shopping list
    /// </summary>
    /// <param name="drinkName"></param>
    /// <returns></returns>
    public HttpResponse<OkResponse> DeleteDrink(string drinkName)
    {
        var deleteDrinkUri = string.Format(ApiUrls.Drink, drinkName);
        return new ApiHttpClient().DeleteRequest<OkResponse>(deleteDrinkUri, AppSettings.SecretKey);
    }

    /// <summary>
    /// Get the quantity of a drink on the shopping list
    /// </summary>
    /// <param name="drinkName"></param>
    /// <returns></returns>
    public HttpResponse<DrinkQuantity> GetDrinkQuantity(string drinkName)
    {
        var getDrinkUri = string.Format(ApiUrls.Drink, drinkName);
        return new ApiHttpClient().GetRequest<DrinkQuantity>(getDrinkUri, AppSettings.SecretKey);
    }

    /// <summary>
    /// Return all drinks on the shopping list
    /// </summary>
    /// <returns></returns>
    public HttpResponse<DrinksList> GetDrinksList()
    {
        var getDrinksListUri = ApiUrls.Customers;

        return new ApiHttpClient().GetRequest<DrinksList>(getDrinksListUri, AppSettings.SecretKey);
    }
}

}