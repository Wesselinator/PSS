/*
 * GET clients
 */
import express = require('express');
const router = express.Router();

router.get('/', (req: express.Request, res: express.Response) => {
    res.status(200).send("I havent done this yet");
});

export default router;