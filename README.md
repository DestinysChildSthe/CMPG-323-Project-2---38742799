# CMPG-323-Project-2---38742799

Link to API on Azure:
https://apiprojectdev.azurewebsites.net/index.html

This API project is to be developed that stores data in the cloud provides authorized access to the data, gives insights of the data, and be able to manipulate data by creating, retrieving, reading, updating and deleting when necessary. The API is then executed by using Swagger and it is hosted in the cloud.

The report from the API provides the stakeholders access to data and insights:
-	To help understand what is happening in the business.
-	That will allow stakeholders to make informed decisions about their business. 
-	To help develop products and services that meet the needs of their customers.
-	To help to improve the delivery of goods to customers.
-	To improve their work structure by showing which department requires more attention.
-	To provide feedback on their profits/losses.
-	To identify new opportunities to expand the business.

# User Manual
The API will open a tab that has A heading with the name of the project 'EcoPower logistics' and four dropdowns namely 'Authenticate','Customer','OrderDetail','Order' and 'Product'.

## Authenticate
1. For the user to be able to access any data under 'Customer','OrderDetail','Order' and 'Product' they to first register with their Username,email and password.
2. Once it is successful, login with your username and password to get a token.
3. This token should then be copied.

## Customer/OrderDetail/Order/Product
1. Go to the customer dropdown.
2. Under tab click the lock in 'GET/api/Customers'.
3. A pop-up will appear and that will require the user to paste the token.
4. Then click the execute button
5. Then click the close button
6. This process will allow the user to be able to access data from Customers ,OrderDetails, Orders and Products

## Methods
Each method in Customers ,OrderDetails, Orders and Products dropdown has 6-7 methods that do specific features namely:

  -GET => It retrieves all the data
  -POST => It creates new data
  -GET => It retrieves specific data based on the ID
  -PUT => It retrieves all the data and updates it
  -PATCH => It retrieves specific data based on the ID and updates it
  -DELETE => It removes existing data
  -GET => It retrieves all the data from a different database based on the ID 
  

   
