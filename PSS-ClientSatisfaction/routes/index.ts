/*
 * GET home page.
 */
import express = require('express');
const router = express.Router();

import dh = require('./../PSS/dataHandler');

router.get('/', (req: express.Request, res: express.Response) => {
    dh.getClients().then(cbxClient => {
        console.log(cbxClient);
        res.render('index', { title: 'Client Satisfaction', clientGroup: cbxClient });
    })
    .catch(err => {
        console.error("Failed to get sql items back with: " + err);
        res.status(500).send("OwO yuw fogodt yrrrr esi-qewly swerver...");
    });
});

export default router;