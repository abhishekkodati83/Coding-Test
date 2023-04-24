The application uses JWT tokens to manage sessions, it also has basic authentication implemented but is commented for the purpose of the assignment

Here is the tech stack

- Project is compatible with ASP.NET Core 3.1
- Uses Azure SQL with ADO.NET
- JWT Tokens
- SQL for setting up your DB

#### Step 1:

Create a new Azure SQL instance in Azure Cloud through the Azure Portal (did not have time to generate scripts otherwise one can use CLI commands as well to create resources),
ensure that you enable access to your computer by update the network settings to only enable your system IP

#### Step 2:
Clone this Repo and update the conn string with the newly created instance details

#### Step 3:
Build the application and run the app, this should open the Swagger UI

#### Step 4:
Generate a bearer token using the credentials provided

#### Step 5:
The resources folder should also have POSTMAN scripts that can be used to check the endpoints

#### TODO

- Unit Testing
- Proper Exception Handling
- A more cleaner structure