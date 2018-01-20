/*
 * File Name: index.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-20 00:38:19
 */

const BlockChain = require('./BlockChain');
const Transaction = require('./Transaction');
const Wallet = require('./Wallet');
const CronJob = require('cron').CronJob;
const jsonfile = require('jsonfile');
const express = require('express');
const bodyParser = require('body-parser');
const _ = require('lodash');

const app = express();
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());
const port = 8888;
const wallet_database = [];
const block_chain = new BlockChain();
print_block(block_chain.get_last_block()); //genesis block
jsonfile.writeFileSync('blockchain.json', block_chain.chain, {spaces: 2, EOL: '\r\n'});

function print_block(block) {
    console.log(`Block Index: ${block.index}, Pre_Hash: ${block.pre_hash}, Hash: ${block.get_hash()}`);
    if (block.transactions.length > 0) console.log(block.transactions);
    console.log('------------------------------------------------------');
}

function autoGeneratesBlock() {
    const job = new CronJob({
        cronTime: '*/10 * * * * *',
        onTick: () => {
            const last_block = block_chain.get_last_block();
            const proof = block_chain.create_proof_of_work(last_block.proof);
            block_chain.create_new_block(proof, last_block.get_hash());
            print_block(block_chain.get_last_block());
            jsonfile.writeFileSync('blockchain.json', block_chain.chain, {spaces: 2, EOL: '\r\n'});
        },
        start: false,
        timeZone: 'Asia/Taipei',
    });
    job.start();
}

autoGeneratesBlock();

function get_wallet(address) {
    const match = _.findIndex(wallet_database, (o) => {
        return o.address == address;
    });
    let wallet;
    if(match == -1) {
        wallet = new Wallet(address, 100);
        wallet_database.push(wallet);
    }
    else {
        wallet = _.find(wallet_database, {address: address});
    }
    return wallet;
}

app.post('/transaction', (req, rsp) => {
    if(!req.body || !req.body.from || !req.body.to || !req.body.value) {
        rsp.send('Must provide parameters {from,to,value}.');
    }
    const from = req.body.from;
    const to = req.body.to;
    const value = req.body.value;
    const from_wallet = get_wallet(from);
    const to_wallet = get_wallet(to);
    try {
        if(from_wallet.balance > value) {
            from_wallet.balance -= value;
            to_wallet.balance += value;
            const transaction = new Transaction(from, to, value);
            block_chain.create_new_transaction(transaction);
            rsp.send('Transaction success.');
        }
        else {
            rsp.send('Failed transaction.');
        }
        jsonfile.writeFileSync('wallets.json', wallet_database, {spaces: 2, EOL: '\r\n'});
    } catch (err) {
        rsp.send('Failed transaction.');
    }
});

app.post('/blockchain', (req, rsp) => {
    rsp.json(block_chain.chain);
});

app.post('/wallets', (req, rsp) => {
    rsp.json(wallet_database);
});

app.listen(port);
