/*
 * File Name: Block.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-19 23:50:18
 */

const crypto = require('crypto');

class Block {
    constructor(index, proof, pre_hash, transactions) {
        this.index = index;
        this.proof = proof;
        this.pre_hash = pre_hash;
        this.transactions = transactions;
        this.timestamp = new Date().getTime();
    }

    get_hash() {
        const hash = `${this.index}${this.proof}${this.pre_hash}${this.transactions}${this.timestamp}`;
        return crypto.createHash('sha256').update(hash).digest('hex');
    }
}

module.exports = Block;
