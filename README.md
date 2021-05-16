# Priemier Service Solution

Welcome To Our 2021 SEN381 Project!


# Building Our Project

To run this solution it requires a connection to a MariaDB server with our database schema and a running instace of our Client Satisfaction Project.

### Order of Build

You should build these programs/services in this order:  

1. First build and start our `MariaDB SQL server`.
2. Next build and start our `Client Satisfaction Website`.
3. Finally build and run our `Main PSS Program`.

### The Containers

Fortunatly we included scripts to build our required services, so you don't have to figure it out!   
You can find them in our `Commands Folder`.  

- To build the `MariaDB SQL Server` and build the database schema, excecute the `MariaDBContainer` script.
- To build our `Client Satisfaction Website` excute the `ClientSatisfactionContainer` script.

#### Our Main Program

Open the main `PSS.sln` in VisualStudio 2019 and build the PSS project.

>You should not build the PSS-ClientSatisfaction project as that will not create a container



# The Code

*Please find the READMEs in our solution folders for further explanations of that particular project.*

# The Team

- Wessel Scholtz
- Marco Venter
- Hendrik Venter
- Christopher du Plessis
- Juan-Pierre-Prinsloo
