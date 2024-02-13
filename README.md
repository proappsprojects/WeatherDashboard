Weather Dashboard Application

Weather Dashboard is a web application that allows users to search for weather conditions by city name. It uses the OpenWeatherMap to fetch data to display temperature, humidity, wind speed, a weather icon the city name, and the country. This project is divided into two main parts. 

1. .NET Core Web API for backend processing
1. React UI for frontend user interaction and data presentation.

Both projects have unit tests to cover the functionality. I’ve used xUnit and Moq to test Web API Controllers and Services. For React components, I’ve implemented the React testing library and Jest.

OpenWeatherMap is an online service, owned by OpenWeather Ltd, that provides global weather data via API, including current weather data. It has various subscription plans and offers free access to its APIs for non-commercial use, making it convenient for individuals and developers to explore and integrate weather data into their projects. I used the free plan that provides 60 calls/minute 1,000,000 calls/month by signing-up to OpenWeather service. 

## Development Toolkit:
- NET SDK for .NET 6.0
- Node.js and npm
- Visual Studio 2022 
- Visual Studio Code
- An OpenWeatherMap API key
- Git for version control

## Part 1 - Setting Up the .NET Core Web API
1. ### Clone the git repository**:** 

Open Git Bash and navigate to WeatherDashboard  folder. Run command

git clone


Navigate to .sln on your local project folder to open WeatherDashboard.sln in Visual Studio 2022.

![A screenshot of a computer

Description automatically generated](Aspose.Words.67362436-3e59-4ce9-b7a4-e4bf699855d9.001.png)

###
1. ### Running the .NET Core Web API:
Right-click on the Solution and build the solution to restore project dependencies. The API should be accessible at http://localhost:5000 or another port if configured in your local Properties\launchSettings.json file.
1. ### OpenWeatherMap: 

- Add your OpenWeatherMap API address and key to the appsettings.json file. 

- Create your API key by signing up for OpenWeatherMap and navigating to <https://openweathermap.org/current#one> 

- Build API request: 

  ![A screenshot of a computer code

Description automatically generated](Aspose.Words.67362436-3e59-4ce9-b7a4-e4bf699855d9.002.png)

For this project, we are using the first one and displaying the country code to the user to tackle multiple cities with the same name. 

https://api.openweathermap.org/data/2.5/weather?q=London&appid={API key}
1. ### Running xUnit Tests in Visual Studio:
- Open Solution in Visual Studio: Api Test project is provided under the solution.

![A screenshot of a computer

Description automatically generated](Aspose.Words.67362436-3e59-4ce9-b7a4-e4bf699855d9.003.png)

- Open Test Explore: Go to VS top menu Test > Test Explore

![A screenshot of a computer

Description automatically generated](Aspose.Words.67362436-3e59-4ce9-b7a4-e4bf699855d9.004.png)

- Run Tests: In the Test Explorer/Test menu, you can run all tests by selecting ‘Run all tests’ or run individual tests. 
- View Results:  Test explorer provides a detailed info of all tests

![A screenshot of a computer

Description automatically generated](Aspose.Words.67362436-3e59-4ce9-b7a4-e4bf699855d9.005.png)

## Part 2 - Setting Up the React UI:
1. ### Cloning the Repository (If Not Done Already):
If you haven't already cloned the main repository that includes both the .NET Core Web API and the React UI projects, follow the instructions in Part 1 to clone the repository.
1. ### Installing Dependencies
Navigate to the React ui directory under WeatherDashboard\weatherdashboard-ui
1. ### Install Node Modules:
Install the required node modules by running: 

npm install or npm i

![A screen shot of a computer

Description automatically generated](Aspose.Words.67362436-3e59-4ce9-b7a4-e4bf699855d9.006.png)

This command reads the package.json file located under weatherdashboard-ui folder and installs all the dependencies listed there.
1. ### Running the React UI
Run the following command to start the React development server: 

npm start

This command compiles the React app and opens it in your default web browser. The application typically runs on <http://localhost:3000>

![A screenshot of a weather dashboard

Description automatically generated](Aspose.Words.67362436-3e59-4ce9-b7a4-e4bf699855d9.007.png)

1. ### Environment Configuration: 
Ensure that your React application is configured to communicate with your .NET Core Web API. This typically involves setting the base URL of your API in a .env file or a configuration file within your React project. 

![](Aspose.Words.67362436-3e59-4ce9-b7a4-e4bf699855d9.008.png)
###
1. ### Running Jest & Testing-Library
Used Jest - Javascript Testing Framework and Testing Library that provides testing utilities.  React testing-library is a testing tool that provides the ability to test the actual DOM tree rendered by React on the browser.

To run unit tests, use **‘npm test’** command in the project terminal window. This cmd will start the test in watch mode to automatically re-run the test when it detects any changes. 

Jest - <https://jestjs.io/docs/getting-started>

Testing Library - <https://testing-library.com/docs>
## Part 3 – .NET Web API Endpoint:
This project provides a single API endpoint within the WeatherController class to interface current weather data for the given city by communicating with OpenWeatherMap api.

- *GET /api/weather/{cityName}*

Parameters: 

`	`cityName: The name of the city for which to fetch weather data. 

- *Responses***:**

**200 OK:** The request was successful, and the weather data for the specified city was returned.

**404 Not Found:** No weather data was returned by the external API for the specified city name.

**400 Bad Request:** Indicates an error in fetching weather details from the external weather service.

Example:

/api/Weather/London'

Response Code - 200

**{**

`  `**"id": 2643743,**

`  `**"name": "London",**

`  `**"weather": [**

`    `**{**

`      `**"id": 800,**

`      `**"main": "Clear",**

`      `**"description": "clear sky",**

`      `**"icon": "01d"**

`    `**}**

`  `**],**

`  `**"main": {**

`    `**"temp": 9.54,**

`    `**"humidity": 63**

`  `**},**

`  `**"wind": {**

`    `**"speed": 5.14**

`  `**},**

`  `**"sys": {**

`    `**"id": 2075535,**

`    `**"country": "GB"**

`  `**}**

**}**



## Part 4 – Reflecting on the architecture:
This project is built on ASP.NET 6 Web API as backend processing and React for UI capabilities. Web API is based on Model-View-Controller architecture. The ‘View’ part is less important in APIs since it started providing JSON and XML format in response instead of HTML.  This new approach allows us to reuse the backend for web, mobile, IoT, and desktop applications with the help of frontend frameworks and libraries like React, Angular, Vue etc. The API project architecture includes Controllers, Models, Services, and exception logging capabilities, reflecting on a clean, maintainable, and extendable approach.

Below are some of the architectural styles and patterns that are used in the application.


**RESTful Architecture**:

.NET Web APIs are designed to facilitate the RESTful (Representational State Transfer) architecture style. This emphasis is on light and stateless communication between the client and server over the HTTP.

**Microservices Architecture**:

This project is built on the ASP.NET platform to take benefits of lightweight, modular-based, cross-platform capabilities that allow it to be built as microservices. Since ‘Services’ are part of the project this could be considered an autonomous service and be deployable as a microservice on cloud infrastructure.

**Dependency Injection Pattern:**

DI is used extensively within the project in the way of services like IWeatherService and IHttpClientService which are injected into controllers. This pattern is decoupling the class and their dependencies making the system more maintainable and testable. 

**Repository pattern, Repository pattern**

Used Repository pattern while implementing IhttpClientService by abstracting the logic of interacting with external API. IWeatherService is built in such a way that it allows us to implement Strategy pattern by providing different implementations for fetching data. 

**Singleton Pattern** for is used for DI and logging (NLog) purposes.

This interacts with an external API called OpenWeatherMap to fetch current weather data for a given city. The API project architecture includes Controllers, Models, Services, and exception logging capabilities, reflecting on clean, maintainable, and extendable approach. It uses several design and architectural pattern that are critical to an enterprise application.

