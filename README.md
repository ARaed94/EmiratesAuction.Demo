# EmiratesAuction.Demo

##	Specs:
o	Used ASP.NET Core (3.1) with EF Core and Ionic 4.
o	I have chosen to use ionic as it provides many of the client side (mobile friendly features) that are requested and can be used with many frontend JS frameworks such as Angular, Reach or Vue.js. (You can also generate a native iOS or Android application when using Ionic).

##	Notes about the application:
* I have implemented the requested features, such as pull-to-refresh, load more on scroll and auto refresh.
*	The application supports both Arabic and English UI and resources.
*	Used skeleton text to increase preserved performance 
* Regarding syncing the auction time with the backend, I have used Unix time as a seed for the internal clock, and incremented the time (per second) this will provide an accurate way to keep track of auction time and to prevent time from being skewed. (more information: https://en.wikipedia.org/wiki/Unix_time)
*	I have modified the schema of the auction response, and have it return only the requested data (based on the screenshot provided by the email). This way, all necessary data will be loaded without the need to include any other properties (which reduces performance)
*	You can run the API application and it will automatically redirect you to the API specs page (used Swagger)
*	I’ve built an API (api/v1/demo) that can be used to reset the demo data (more details can be found on the API specs)

##	How to run the app:
*	Kindly download and build the solution. This should restore all NuGet packages.
*	Update the connection string (under DataAccess/appsettings.json)
*	Then navigate to Clients.Web folder and run the command “npm install” then “ionic serve”. This should kick off the application and it should listen on port 8100 by default (you can specify which port to use)
* Please update the BaseUrl property found in the client app under \Clients.Web\src\app\config.ts and set it to the API URL.
