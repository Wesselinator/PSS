/*
 * POST feedback report.
 */
import express = require('express');
import feedbackReport = require('../PSS/feedback');
const router = express.Router();

import dh = require('./../PSS/dataHandler');

//resume here
router.post('/', (req: express.Request, res: express.Response) => {
    //req.
    //var feedback = new feedbackReport();
    //var client = 
    //dh.saveFeedback(feedback, );
    res.status(200);
    res.status(400); //you fuckyfukyedup
});

export default router;