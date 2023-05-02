# FruitSA_Dev_Test

Project has been created using the following technologies

  1.C#
  
  2.Net Core
  
  3.SQL
  
  4.HTML, CSS & Javascript
  
  5. N-Tier
  
 Application manages the creation of categories and products.
 
 Set Up
 1. Execute the sql script called DB.sql
 
 2. Change connection string in the appsettings.json file located in the FruitSA_Dev_Test.API project
 
 3. Solution might require multiple project start up
 
    3.1. Right click on solution
    
    3.2. Click Properties
    
    3.3. Check Multiple startup projects
    
    3.4. Set Action to start for both FruitSA_Dev_Test.API & FruitSA_Dev_Test.PL  projects
    
    3.5. Click OK
    
 4. Start Solution
 
 Application has been broken down into different projects to manage seperation of concern.
 
 FruitSA_Dev_Test.API - Is an API project that connects to the data and business layers creating the communication path to the database.
 
 FruitSA_Dev_Test.BLL - Business Layer responisble for the data exchange between the Data Access Layer and the API, contains services used in the communication flow
 
 FruitSA_Dev_Test.DAL - Data Access Layer is responsible for the interaction with the database, Generic repository is used
 
 FruitSA_Dev_Test.PL - Presenation Layer is the front end of the solution, razor pages, html, css and javascript used
