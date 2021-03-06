import * as express from 'express';
import { AddressInfo } from "net";
import * as path from 'path';

import routes from './routes/index';
import users from './routes/user';
import feedback from './routes/feedback';
import clients from './routes/clients';

const debug = require('debug')('PSS-ClientSatisfaction Microservice');
const app = express();


//allows for the parsing of application/x-www-form-urlencoded
app.use(express.urlencoded({ extended: true }));


// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'pug');

app.use(express.static(path.join(__dirname, 'public')));

app.use('/', routes);
app.use('/users', users);
app.use('/feedback', feedback);
app.use('/clients', clients);

// catch 404 and forward to error handler
app.use((req, res, next) => {
    const err = new Error('Not Found');
    err[ 'status' ] = 404;
    next(err);
});

// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
    app.use((err, req, res, next) => { // eslint-disable-line @typescript-eslint/no-unused-vars
        res.status(err[ 'status' ] || 500);
        res.render('error', {
            message: err.message,
            error: err
        });
    });
}

// production error handler
// no stacktraces leaked to user
app.use((err, req, res, next) => { // eslint-disable-line @typescript-eslint/no-unused-vars
    res.status(err.status || 500);
    res.render('error', {
        message: err.message,
        error: {}
    });
});

// listening net

const ePORT = 'port';
const eHOST = 'host';

app.set(ePORT, process.env.PORT || 3000);       //set from envoirnment or default
app.set(eHOST, process.env.HOST || '0.0.0.0');

const server = app.listen(app.get(ePORT), app.get(eHOST), function () {
    var message = `Express server listening on port ${(server.address() as AddressInfo).port}`;
    debug(message);
    console.info(message);
});
