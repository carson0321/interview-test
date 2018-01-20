/*
 * File Name: Transaction.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-20 18:55:26
 */

const crypto = require('crypto');

class Transaction {
    constructor(from, to, value) {
        const hash = `${from}${to}${value}`;
        this.from = from;
        this.to = to;
        this.value = value;
        this.hash = crypto.createHash('sha256').update(hash).digest('hex');
    }
}

module.exports = Transaction;
