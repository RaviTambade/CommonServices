# CommonServices

# Role Based Access Control - User Management Microservice
<hr/>

## Overview
The need to manage a user base for an online system is very frequent. Goal of this project is to offer a generic user's data management microservice.

This microservice can offer a good and solid starting point for managing your accounts. Thanks to this Role Based Access Control implementation it's easy to define roles and permissions for your specific application/prototype and subsequently apply these access rules on the users.

This project lends itself very well to implement new prototypes or to create new solutions based on microservice architecture.

The solution is thought using the Docker technologies with two different containers:
- ASP.NET Core REST Apis
 -MySql 8.0 database
The code has been well tested (> 115 tests) using JUnit and Mockito, H2 in memory database and some standard libraries for the integration tests.


### Exposed REST apis
Here below the most relevant features exposed using REST Apis:

<b>User management features</b>
- Register a new user account
- Login with username & password
- Retrieve a single user account
- Retrieve the list of all the existing user accounts
- Update user account data (basic user data, contacts, address)
- Add or remove a role on an user account
- Delete a user account
- Define secured accounts that cannot be deleted but only modified
- Standard validation for email, phone, password

<b>RBAC features: manages roles and permissions</b>
- Retrieve all the permissions
- Retrieve the list of the existing roles
- Create a new role
- Retrieve a single role
- Delete a role
- Add a permission on a role
- Remove a permission on a role
- Create a new permission
- Update an existing permission (also enabled or disable it)
- Retrieve single permission
- Delete not used permission

### Api to generate a salt random value to encrypt password (configuration)

Using a browser it's possible to interact with the REST apis with Swagger:

http://localhost:8090/swagger-ui.html

<img src="/images/swaggermembershiprolesmgmt.png"/>

Another alternative is to using an external tool, for example Postman (https://www.postman.com/).

This project contains also the Postman export file with all the configured test calls:

<img src="/images/postman.png"/>

## Quick Start

### Setup using Docker containers
>Thanks to Docker it’s easy to create scalable and manageable applications built of microservices.

The project is designed to use two containers:
* one asp.net core microservice
* one MySql database

The Docker environment is necessary in order to work with the containers and the setup depends about your Os.

Proceed the setup for the Docker environment: [Get Docker](https://docs.docker.com/get-docker/)

To compile and run the Java project you need to install a Java 8 JDK on your local machine.

Follow the instructions below to setup a local docker image for a mysql8.0 database:

https://medium.com/@crmcmullen/how-to-run-mysql-in-a-docker-container-on-macos-with-persistent-local-data-58b89aec496a

The microservice application has been updated to support a docker dev-network and there are no needs to
 configure manually the IP address of the database target: this setup is necessary only one time.

Create the developer network:

    docker network create dev-network

Check that the network has been defined:

    docker network ls

Modify the file db.cmd and set a folder to use for the MySql's docker volume.

Run the MySql container:

    ./db.cmd

Execute the run bash script to compile and run the microservice container:

    ./run.cmd

Open a browser and explore the REST apis:

http://localhost:8090/swagger-ui.html

The RBAC microservice should be up and running and connecting with the MySql instance with the demo data.
If you want to remove this demo data proceed to configure your system as in "Setup a ready and empty RBAC" section.

Everything should be up and running :)

### Setup without Docker

>You can also setup and work on this project without to consider to use Docker.
You will just launch the Spring Boot application targeting the MySql database (on localhost or on a remote one).

- Install Dotnet core 8.0.

- Set up your MySql instance and create the empty database "users":

    CREATE DATABASE IF NOT EXISTS users;

- Create and grant a new MySql user on the "users" database.

- Open the appsettings.json file.

Target your localhost MySql database:

    connectionstring=mysql://localhost:3306/users?useSSL=false&allowPublicKeyRetrieval=true


Execute the microservice code using Dotnet CLI command:

    ./dotnet run
    
Open a browser and explore the REST apis:

http://localhost:8090/swagger-ui.html

<img src="/images/swaggermembershiprolesmgmt.png"/>

The RBAC microservice should be up and running and connecting with the MySql instance with the demo data.
If you want to remove this demo data proceed to configure your system as in "Setup a ready and empty RBAC" section.

Everything should be up and running using your local MySql :)

### Setup a ready and empty RBAC
>You can prepare a specific clean RBAC microservice setup without any demo data and
> without to reset the database content at each restart.

Install Dotnet core 8.0.

Set up your MySql instance and create the empty database "users":

    CREATE DATABASE IF NOT EXISTS users;

Create and grant a new MySql user on the "users" database.

Open the appsettings.json file located in /src.

Set the username and password of the MySql's user:


>For a production environment consider to create a specific MySql user for the database "users" using
 a strong password.

Disable the demo data setting as below:

    # enable initialization using schema.sql and data.sql


>If you need, you can launch the microservice and using Swagger to call the rest endpoint /users/rbac/salt
> in order to generate a new random one.

Save the application.properties file.

Run the build of the microservice and lunch the container:

    ./run.cmd

The RBAC microservice should be up and running and connecting with the MySql instance without demo data.
Proceed with your RBAC configuration using the REST apis:

http://localhost:8090/swagger-ui.html

Restarting the db or the microservices should not affect the persistence of your RBAC configuration.

#### Author
This project has been created in October 2023 by Pragati Bangar.

Andrea he's an italian Agile professional and Software Engineer actives in web systems and services.
Since 2022, Pragati is working in the Transflower as intern and she is contributing
 to the success of several solutions and products at Transflower.

About me:
https://www.linkedin.com/in/bangarpragati/