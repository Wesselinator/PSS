/*
 * GET clients
 */
import express = require('express');
const router = express.Router();

import dh = require('./../PSS/dataHandler');

router.get('/', (req: express.Request, res: express.Response) => {
    dh.getClients()
        .then(cbxgroups => {
            console.log(cbxgroups);
            res.status(200).send(JSON.stringify(cbxgroups))
        })
        .catch(err => {
            console.error("failed to get clients!")
            res.status(500).send("FAILURE!");
        });    
});

export default router;