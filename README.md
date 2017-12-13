# GitHub repositories search page
 by Olga Veysberg

### Technologies used
###### Server side
- cross-platform .NET Core (developed in VS 2017)
- Octokit library to access GitHub API
- Autofac (Inversion of Control container for .NET Core, ASP.NET Core, .NET 4.5.1+)
- Swashbuckle (an open source project for generating Swagger documents for ASP.NET Core Web APIs, machine-readable representation of a RESTful API)

###### Client side
- Angular 4
- Bootstrap
- Less
- TypeScript

### Architecture
###### Server side
- Based on IDesign method, with which we captured the requirement and created the IDesign flows: 
  The Business Logic Layer (Managers)
  Accessors Layer (Responsible for the connection, communication and any other low-level resource related such as file-system, database and external systems)
- RESTfull Web API

 ###### Client side
- Based on Angular architecture best practices
- Components are the fundamental building blocks of Angular applications. They display data on the screen, listen for user input, and take action based on that input
- Services are a way to share information among classes that don't know each other. Angular dependency injection inject it into components constructor when required

## Run Application (how to)
## Server side
- Open GithubRepository.sln in Visual Studio 2017
- Set GithubRepository.Api as startup project
- Press run (Swagger documentation page will be opened - see Swagger.png)

## Client side
### Prerequisites:
- Node npm installated (https://docs.npmjs.com/cli/install)
- Angular installed (open command prompt as administrator and run the following command:  npm install -g @angular/cli)
### Run application
- Open command prompt as administrator
- Navigate to Client\gethubrepository.client folder (use cd /d command)
- Run the application (use ng serve --open command) (see repositories.png)



  

