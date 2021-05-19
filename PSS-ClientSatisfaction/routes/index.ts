/*
 * GET home page.
 */
import express = require('express');
const router = express.Router();

import dh = require('./../PSS/dataHandler');

router.get('/', (req: express.Request, res: express.Response) => {
    dh.getClients().then(cbxClient => {
        res.render('index', { title: 'Client Satisfaction', clientGroup: cbxClient });
    })
    .catch(err => {
        console.error("Failed to get sql items back with: " + err);
        var error = { status: "SQL Server Unreachable", stack: err };
        res.render('error', { title: 'SQL Connection Fail', message: "Couldn't connect SQL Server", error: error });
        res.status(500);
    });
});

export default router;