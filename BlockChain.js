/*
 * File Name: BlockChain.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-20 00:01:33
 */

const Block = require('./Block');

class BlockChain {
    constructor() {
        this.chain = [];
        this.cur_block_transactions = [];
        this.create_genesis_block();
    }

    create_genesis_block() {
        this.create_new_block(0, 0);
    }
    
    create_new_block(proof, pre_hash) {
        const block = new Block(
            this.chain.length,
            proof,
            pre_hash,
            this.cur_block_transactions
        );
        this.cur_block_transactions = [];
        this.chain.push(block);
        return block;
    }

    create_new_transaction(from, to, value) {
        this.cur_block_transactions.append({
            'from': sender,
            'to': recipient,
            'value': amount
        });
        return this.get_last_block().index + 1;
    }

    create_proof_of_work(pre_proof) {
        let proof = pre_proof + 1
        while ((proof + pre_proof) % 7 != 0) {
            proof += 1;
        }
        return proof;
    }

    get_last_block() {
        return this.chain.slice(-1).pop();
    }
}

module.exports = BlockChain
