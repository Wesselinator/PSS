import mariadb = require('mariadb');
import client = require('./client');
import comboGroup = require('./comboGroup');
import itemPair = require('./itemPair');
import feedbackReport = require('./feedback');

const pool = mariadb.createPool({
    host: process.env.SQLHOST || 'localhost',
    port: 7331,
    user: "PSSuser",
    password: "τнιsραssωοяδιsωεακ",
    database: "PremierServiceSolutionsDB",
    rowsAsArray: false, //set to true if that will be easier
    connectionLimit: 5,
    connectTimeout: 5000 //fail faster
});

let excecuteQuery = (sql: string, action: string) =>
                    pool.query(sql)
                    .then(res => {
                        console.log(action + " Succeded!");
                    })
                    .catch(err => {
                        console.log(action + " Failed with: " + err);
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

        var dtfrm: string = "NULL";
        if (report.followupdate) {
            dtfrm =`'${report.followupdate.toISOString().slice(0, 19)}'`; //replace() required?
        }
        let reportSql = "INSERT INTO FollowUpReport (FollowUpReportID, FollowUpTitle, FollowUpType, FollowUpDescription, FollowUpDate, IsIssueResolved, SatisfactionLevel) " +
            `VALUES (${nextInt}, '${report.title}', '${report.type}', '${report.description}', ${dtfrm}, ${report.isIssueResolved}, ${report.satisfactionLevel});`;
        
        excecuteQuery(reportSql, "Foolow-Up Report Insert Action");

        var crossoverSql = clientCrossOver(clien, nextInt);

        excecuteQuery(crossoverSql, "Crossover Table Insert Action");
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
              return Promise.reject(err);
          });

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
            return Promise.reject(err);
        });

    var busGrp = new comboGroup("Business Client", busClients);

    return Promise.resolve([indvGrp, busGrp]);
}

export { saveFeedback, getClients }
