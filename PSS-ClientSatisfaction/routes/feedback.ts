/*
 * POST feedback report.
 */
import express = require('express');
import client = require('../PSS/client');
import feedbackReport = require('../PSS/feedback');
const router = express.Router();

import dh = require('./../PSS/dataHandler');

router.post('/', (req: express.Request, res: express.Response) => {
    console.log(req.body);

    var clien: client = JSON.parse(req.body.dropdownSelectClient) //this JSON object does not contain the functions

    //TODO: why isn't date being sent
    var dt = new Date();

    var isRequired: boolean = req.body.IsFollowUpRequired == 'Yes';
    var isResolved: boolean = req.body.IsIssueResolved == 'Yes';

    var report = new feedbackReport(req.body.FollowUpText, req.body.dropdownFollowUpType, req.body.FollowUpDescriptionText, dt, isResolved, req.body.edtSatisfactionLvl);

    dh.saveFeedback(report, clien);

    res.status(200).send("Recieved!");

    //res.status(400); //you fuckyfukyedup
});

export default router;