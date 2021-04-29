"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const express = require("express");
const path = require("path");
const index_1 = require("./routes/index");
const user_1 = require("./routes/user");
const debug = require('debug')('my express app');
const app = express();
// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'pug');
app.use(express.static(path.join(__dirname, 'public')));
app.use('/', index_1.default);
app.use('/users', user_1.default);
// catch 404 and forward to error handler
app.use((req, res, next) => {
    const err = new Error('Not Found');
    err['status'] = 404;
    next(err);
});
// error handlers
// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
    app.use((err, req, res, next) => {
        res.status(err['status'] || 500);
        res.render('error', {
            message: err.message,
            error: err
        });
    });
}
// production error handler
// no stacktraces leaked to user
app.use((err, req, res, next) => {
    res.status(err.status || 500);
    res.render('error', {
        message: err.message,
        error: {}
    });
});
// listening net
const ePORT = 'port';
const eHOST = 'host';
app.set(ePORT, process.env.PORT || 3000); //set from envoirnment or default
app.set(eHOST, process.env.HOST || '0.0.0.0');
const server = app.listen(app.get(ePORT), app.get(eHOST), function () {
    debug(`Express server listening on port ${server.address().port}`);
});
console.log(app.get(ePORT));
console.log(app.get(eHOST));
//# sourceMappingURL=app.js.map