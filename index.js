/*
 * File Name: index.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-20 00:38:19
 */

const BlockChain = require('./BlockChain');
//const Transaction = require('./Transaction');
const CronJob = require('cron').CronJob;

const block_chain = new BlockChain();

function autoGeneratesBlock() {
    const job = new CronJob({
        cronTime: '*/1 * * * * *',
        onTick: () => {
            const last_block = block_chain.get_last_block();
            console.log(`Block Index: ${last_block.index}, Pre_Hash: ${last_block.pre_hash}, Hash: ${last_block.get_hash()}`);
            //console.log(block_chain.chain);
            const proof = block_chain.create_proof_of_work(last_block.proof);
            block_chain.create_new_block(proof, last_block.get_hash());
            console.log('------------------------------------------------------');
        },
        start: false,
        timeZone: 'Asia/Taipei',
    });
    job.start();
}

autoGeneratesBlock();
