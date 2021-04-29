"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/*
 * GET home page.
 */
const express = require("express");
const router = express.Router();
router.get('/', (req, res) => {
    res.render('index', { title: 'Client Satisfaction' });
});
exports.default = router;
//# sourceMappingURL=index.js.map