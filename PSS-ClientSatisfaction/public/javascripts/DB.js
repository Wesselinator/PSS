var mysql = require('mysql');

var con = mysql.createConnection({
    host: "localhost",
    port: "7331",
    user: "PSSuser",
    password: "τнιsραssωοяδιsωεακ",
    database: "PremierServiceSolutionsDB"
});

var x = "Not Connected!";

con.connect(function (err) {
    if (err) throw err;
    x = "Connected!";
	console.log(x);
});


