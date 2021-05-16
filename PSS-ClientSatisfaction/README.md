# PSS-ClientSatisfaction

Welcome to the Microservice Client Satisfaction Interface!

## Dockerfile

This sets up an `Alpine` image to run a node application by installing Node.js and then building our program in the image.

>This Image exposes port 1337  
>NOTE: We use this port

### Building The Container

>See Readme in the `Commands` folder

## Developing/Debuging
When developing the Node.js project, you can speed up your debugging by running the project in the VisualStudio ISSExpress Server Envoirnment.

You can do this by not building the docker image and running it in VisualStudio.
For even faster development right click the solution and select `Set as Startup Project`

>NOTE: You cannot run the container and IISExpress server concurently