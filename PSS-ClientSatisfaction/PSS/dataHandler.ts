import mariadb = require('mariadb');
import client = require('./client');
import comboGroup = require('./comboGroup');
import itemPair = require('./itemPair');
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

let excecuteQuery = (sql: string) => pool.query(sql)
                                     .then(res => {
                                         console.log(res);
                                     })
                                     .catch(err => {
                                         console.log(err);
                                     });

async function getNextFeedbackInt(): Promise<number> {
    var nextId: number = -1
    let sql = "SELECT (fur.FollowUpReportID + 1) AS NextID " +
              "FROM followupreport fur " +
              "ORDER BY fur.FollowUpReportID DESC " +
              "LIMIT 1;"
    await pool.query(sql)
          .then(rows => {
              nextId = rows[0].NextID;
          })
          .catch(err => {
              console.error("SQL to find next id failed with: ");
          });

    return nextId;
}

function saveFeedback(report: feedbackReport, clien: client): void {
    getNextFeedbackInt().then(nextInt => {

        var dtfrm = report.followupdate.toISOString().slice(0, 19).replace('T', ' ');
        let reportSql = "INSERT INTO FollowUpReport (FollowUpReportID, FollowUpTitle, FollowUpType, FollowUpDescription, FollowUpDate, IsIssueResolved, SatisfactionLevel) " +
            `VALUES (${nextInt}, '${report.title}', '${report.type}', '${report.description}', '${dtfrm}', ${report.isIssueResolved}, ${report.satisfactionLevel});`;
        
        excecuteQuery(reportSql);

        var crossoverSql = clientCrossOver(clien, nextInt);

        excecuteQuery(crossoverSql);
    });
}

function clientCrossOver(clien: client, reportId: number) {
    var firstHalf: string;

    if (clien.isIndividual) {
        firstHalf = "BusinessClientFollowUp (BusinessClientID,";
    } else {
        firstHalf = "IndividualClientFollowUp (IndividualClientID,";
    };

    return "INSERT INTO " + firstHalf + " FollowUpReportID) " +
        `VALUES (${clien.clientID}, ${reportId})`;
}


//TODO: move that block to its own function
async function getClients(): Promise<comboGroup[]> {
    let indSql = "SELECT ic.IndividualClientID, CONCAT(p.FirstName , ' ', p.LastName) AS FullName FROM individualclient ic " +
                 "INNER JOIN person p ON ic.IndividualClientID = p.PersonID;";

    var indClients: itemPair[] = [];
    await pool.query(indSql)
          .then(rows => {
              rows.forEach(row => {
                  var indCl = new client(row.IndividualClientID, true);
                  indClients.push(new itemPair(row.FullName, JSON.stringify(indCl)))
              });
          })
          .catch(err => {
              console.error("Individual clients failed with: " + err);
          });

    console.log(indClients + "fuck");

    var indvGrp = new comboGroup("Individual Client", indClients);


    let busSql = "SELECT bc.BusinessClientID, bc.BusinessName FROM businessclient bc;";

    var busClients: itemPair[] = [];
    await pool.query(busSql)
        .then(rows => {
            rows.forEach(row => {
                var busCl = new client(row.BusinessClientID, true);
                busClients.push(new itemPair(row.BusinessName, JSON.stringify(busCl)));
            });
        })
        .catch(err => {
            console.error("Business clients failed with: " + err);
        });

    var busGrp = new comboGroup("Business Client", busClients);

    return [indvGrp, busGrp];
}

export { saveFeedback, getClients }
