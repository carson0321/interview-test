/*
 * File Name: index.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-20 00:38:19
 */

const BlockChain = require('./BlockChain');
//const Transaction = require('./Transaction');
const CronJob = require('cron').CronJob;
const jsonfile = require('jsonfile');

const block_chain = new BlockChain();
print_block(block_chain.get_last_block()); //genesis block
jsonfile.writeFileSync('blockchain.json', block_chain.chain);

function print_block(block) {
    console.log(`Block Index: ${block.index}, Pre_Hash: ${block.pre_hash}, Hash: ${block.get_hash()}`);
    if (block.transactions.length > 0) console.log(block.transactions);
    console.log('------------------------------------------------------');
}

function autoGeneratesBlock() {
    const job = new CronJob({
        cronTime: '*/1 * * * * *',
        onTick: () => {
            const last_block = block_chain.get_last_block();
            const proof = block_chain.create_proof_of_work(last_block.proof);
            block_chain.create_new_block(proof, last_block.get_hash());
            print_block(block_chain.get_last_block());
            jsonfile.writeFileSync('blockchain.json', block_chain.chain);
        },
        start: false,
        timeZone: 'Asia/Taipei',
    });
    job.start();
}

autoGeneratesBlock();
