# Container Batch Commands

You can use these to build the containers from this project.

## SQL Container

`MariaDBContainer` will build the Data Base container required by both the base program `PSS` and the `PSS-ClientSatisfaction`

>It will be accessable through port `1337`

## Client Satisfaction Container

`ClientSatisfactionContainer` will build the Node.js container that will serve the Client Satisfaction interface

>It can be accessable through port `7331`

---

## The reCreateContainer Script

>There should be no need for you to excute this file

This script is used by the other scripts. You shouldn't directly excute it without supplying it with arguments   

###### It requires 4 arguments:  
`Container Name`, `Container Image Name`, `Docker Port Asignment`, `Dockerfile Directory`  

###### The script will:
1. Stop the `Container Name` container.
2. Remove it's associated vloume(s) (*Usually only a the temporary `local volume`*).
3. Remove the `Container Image Name` image that the container was based on.
4. Build the `Container Image Name` image from the Docker file specified in Dockerfile Directory.
5. Create a container from the `Container Image Name` and give it the `Container Name`. This will assign ports from the `Docker Port Asignment` string.
6. Start the `Container Name` container.

