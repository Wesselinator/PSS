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

    var clien: client = JSON.parse(req.body.dropdownSelectClient) //this JSON object does not contain functions    

    var isRequired: boolean = req.body.IsFollowUpRequired == 'Yes';
    var isResolved: boolean = req.body.IsIssueResolved == 'Yes';
    var report: feedbackReport;
    if (isRequired) {
        let dt = new Date(req.body.dtpFollowUpDate);
        report = new feedbackReport(req.body.FollowUpText, req.body.dropdownFollowUpType, req.body.FollowUpDescriptionText, isResolved, req.body.edtSatisfactionLvl, dt);
    }
    else {
        report = new feedbackReport(req.body.FollowUpText, req.body.dropdownFollowUpType, req.body.FollowUpDescriptionText, isResolved, req.body.edtSatisfactionLvl);
    }

    dh.saveFeedback(report, clien);
    
    res.status(200).send("Recieved!");

    //res.status(400); //you fuckyfukyedup
});

export default router;