# Checkout.com
Checkout.com would like you to create a web service using the .NET framework of your choice that will enable us to manage a shopping list for our office.

1 - Service test

I have created a project named Shopping cart and added a API controller to the project called DrinksController to perform the following function

HTTP POST request for adding a drink to the shopping list with quantity, e.g. name of drink (Pepsi) and quantity (1).
HTTP PUT request for updating a drink's quantity.
HTTP DELETE request for removing a drink from the shopping list.
HTTP GET request for retrieving a drink by its name and displaying its quantity so we can see how many have been ordered.
HTTP GET request for retrieving what we have in the shopping list.


2 - Service Client

Please note I have altered the Checkout.ApiClient.Net40 project in the checkout-net-library-master solution(not the Net 4.5 as I had an older version of Visual studio which didnt support the c-sharp 6) to work with the API created above.
