# MariaDB SQL Container

Weclome to the SQL Container Build Files!

Here you will find the Dockerfile to build the container aswell as the SQL file to build the database with some database

## Basic Database Atributes
```js
Database Username: 'PSSuser'
Database Password: 'τнιsραssωοяδιsωεακ'
Database Name: 'PremierServiceSolutionsDB'
```

## Dockerfile

Our docker image is based on the popular `Alpine` image to keep our image small, lean and fast.
>This image publishes the default `3306` port  
>NOTE: We do not expose this spesific port

## SQL File

The SQL file in this folder will build the database and add some sample data to the database.

You can run this file again *(in a MariaDB/MySQL client application)* to rebuild the database.  
 **THIS WILL DELETE EVERYTHING IN THE DATABASE**
