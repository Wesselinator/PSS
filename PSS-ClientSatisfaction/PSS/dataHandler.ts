import mariadb = require('mariadb');
import client = require('./client');
import comboGroup = require('./comboGroup');
import feedbackReport = require('./feedback');

const pool = mariadb.createPool({
    host: "localhost", //use env when in docker maybe
    port: 7331,
    user: "PSSuser",
    password: "τнιsραssωοяδιsωεακ",
    database: "PremierServiceSolutionsDB",
    rowsAsArray: false, //set to true if that will be easier
    connectionLimit: 5
});

let query = (sql: string) => pool.query(sql)
                             .then(res => {
                                 console.log(res);
                             })
                             .catch(err => {
                                 console.log(err);
                             });

function getNextFeedbackInt() : number {
    return 1;
}

function saveFeedback(report: feedbackReport, client: client): void {
    var nextInt = getNextFeedbackInt();
    let reportSql = "NSERT INTO FollowUpReport (FollowUpReportID, FollowUpTitle, FollowUpType, FollowUpDescription, FollowUpDate, IsIssueResolved, SatisfactionLevel) " +
        `VALUES (${nextInt}, '${report.title}', '${report.type}', '${report.description}', '${report.followupdate.toUTCString()}', ${report.isIssueResolved}, ${report.satisfactionLevel});`;
        //pretty sure thats the tostring;
    query(reportSql);

    let crossoverSql = client.crossoversql(nextInt);

    query(crossoverSql);
}

export { saveFeedback }
