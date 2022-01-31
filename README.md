# Cuhadar.Bank
This is my table  Design 
Customer has many Accounts
Account has many Transaction
![alt text]https://ibb.co/jzP5RqT

If you want to check endpoints Please check https://application-url/swagger this url

I tried to develop the project through Clean Architecture with Domain Driven Design
The project requires Microsoft SQL Server and .net 5 and Visual Studio 2019+
Please download .net 5 sdk from https://dotnet.microsoft.com/en-us/download/visual-studio-sdks

1.If you want to run the project please change BankConnectionString field  at "projecturl/Cuhadar.Bank.API/appsettings.json"
![This is an image] (https://imgyukle.com/i/oFVtW6)

2.Open Visual studio and open Package Manager Console
![This is an image] (https://imgyukle.com/i/oFnJpS)

3.Choose Cuhadar.Bank.Infrastructure as Default Project and run these two Commands
![This is an image] (https://imgyukle.com/i/oFnqoH)

Update-Database -Context BankContext
Update-Database -Context AppIdentityDbContext

The Project is ready now.
