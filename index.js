/*
 * File Name: index.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-20 00:38:19
 */

const BlockChain = require('./BlockChain');
const Transaction = require('./Transaction');

function freeze(time) {
    const stop = new Date().getTime() + time;
    while(new Date().getTime() < stop);
}

const block_chain = new BlockChain();
let index = 0;
while(index > 5) {
    const last_block = block_chain.get_last_block();
    console.log(`Block Index: ${last_block.index}, Pre_Hash: ${last_block.pre_hash}, Hash: ${last_block.get_hash()}`);
    if(index == 2) {
        const transaction = new Transaction('alice', 'bob', 100);
        block_chain.create_new_transaction(transaction);
    }
    console.log(last_block.transactions);
    //console.log(block_chain.chain);
    const proof = block_chain.create_proof_of_work(last_block.proof);
    block_chain.create_new_block(proof, last_block.get_hash());
    console.log('------------------------------------------------------');
    index += 1;
    freeze(3000);
}
