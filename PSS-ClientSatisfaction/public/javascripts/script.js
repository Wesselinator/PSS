var mysql = require('mysql');

var con = mysql.createConnection({
    host: "127.0.0.1",
    user: "PSSuser",
    password: "???s??ss?????s????",
    database: "PremierServiceSolutionsDB"
});

con.connect(function (err) {
    if (err) throw err;
    console.log("Connected!");
});