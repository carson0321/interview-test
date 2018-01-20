/*
 * File Name: client.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-20 22:47:48
 */

const term = require( 'terminal-kit' ).terminal;
const Client = require('node-rest-client').Client;
const client = new Client();
const async = require('async');
const chalk = require('chalk');
const readline = require('readline');
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

function list(path) {
    client.post(`http://localhost:8888/${path}`, { headers: { 'Content-Type': 'application/json' }}, (data) => {
        console.log(data);
        process.exit();
    });
}

function create_transaction(args) {
    client.post('http://localhost:8888/transaction', args, (data) => {
        console.log(chalk.magenta(data.toString()));
        process.exit();
    });
}

term.cyan( 'In this test, you will work on an in-memory blockchain. To make it extremely simple, it\'s a single node blockchain setup, which means no network or p2p connections to deal with. Also there is no signature or verification are necessary, so your consensus would be straightforward: just collect transactions and make them blocks.\n' );

const selects = [
    'a. List blockchain',
    'b. List wallets',
    'c. Create transaction',
];

term.singleColumnMenu(selects , (error, response) => {
    term('\n').eraseLineAfter.green(
        '#%s selected: %s\n',
        response.selectedIndex,
        response.selectedText,
    );
    if(parseInt(response.selectedIndex) === 0) list('blockchain');
    else if(parseInt(response.selectedIndex) === 1) list('wallets');
    else if(parseInt(response.selectedIndex) === 2) {
        const args = {
            data: {},
            headers: { 'Content-Type': 'application/json' },
        };
        const color = chalk.bold.yellow;
        async.series([
            (callback) => {
                rl.question(color('From: '), (from) => {
                    args.data.from = from;
                    callback();
                });
            },
            (callback) => {
                rl.question(color('To: '), (to) => {
                    args.data.to = to;
                    callback();
                });
            },
            (callback) => {
                rl.question(color('Value: '), (value) => {
                    args.data.value = value;
                    callback();
                });
            },
        ], () => {
            rl.close();
            create_transaction(args);
        });
    }
});

