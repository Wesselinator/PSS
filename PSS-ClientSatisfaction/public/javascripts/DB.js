//Sources looked at https://www.tutorialspoint.com/expressjs/expressjs_url_building.htm & https://www.tutorialspoint.com/expressjs/expressjs_database.htm & https://www.w3schools.com/nodejs/nodejs_mysql_insert.asp & https://www.w3schools.com/nodejs/nodejs_mysql_select.asp

var mysql = require('mysql');
var express = require('express');
var app = express();

//sql connection to database
var con = mysql.createConnection({
    host: "localhost",
    port: "7331",
    user: "PSSuser",
    password: "τнιsραssωοяδιsωεακ",
    database: "PremierServiceSolutionsDB"
});

var x = "Not Connected!";

//route to test connection
app.get('/testconn', function (req, res) {

    con.connect(function (err) {
        if (err) throw err;
        x = "Connected!";
        console.log(x);
    });

    res.send((x));
});

//route to get business clients 
app.get('/ic', function (req, res) {

    //con.connect(function (err) {
    //    if (err) throw err;
    //    con.query("SELECT * FROM BusinessClient", function (err, result, fields) {
    //        if (err) throw err;
    //        console.log(result);
    //    });
    //});

    res.send('Will eventualy Return individual clients');
});

//route to get individual clients
app.get('/bc', function (req, res) {

    //con.connect(function (err) {
    //    if (err) throw err;
    //    con.query("SELECT * FROM IndividualClient", function (err, result, fields) {
    //        if (err) throw err;
    //        console.log(result);
    //    });
    //});

    res.send('Will eventualy Return business clients');
});

//route to receive info from webcite and store in DB
app.post('/feedback', function (req, res){

    var feedbackInfo = req.body; //Get the parsed information

    //con.connect(function (err) {
    //    if (err) throw err;
    //    console.log("Connected!");
    //    var sql = "INSERT INTO FollowUpReport (FollowUpReportID, FollowUpTitle, FollowUpType, FollowUpDescription, FollowUpDate, IsIssueResolved, SatisfactionLevel) VALUES ()"; //add values
    //    con.query(sql, function (err, result) {
    //        if (err) throw err;
    //        console.log("1 record inserted");
    //    });
    //});

});

app.listen(3000);
