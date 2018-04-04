/*
 * File Name: test_blockchain.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-20 18:25:33
 */

const BlockChain = require('../server/BlockChain');
const assert = require('assert');

describe('Verify blockchain', () => {
    const block_number = 20;
    const block_chain = new BlockChain();
    before(() => {
        for(let i = 0; i < block_number; i++) {
            const last_block = block_chain.get_last_block();
            const proof = block_chain.create_proof_of_work(last_block.proof);
            block_chain.create_new_block(proof, last_block.get_hash());
        }
    });
    it('simple test pre_hash', () => {
        for (let i in block_chain.chain) {
            const cur_block = block_chain.chain[i];
            if(i==0) {
                assert.equal(cur_block.pre_hash, 0);
            }
            else if(i < block_number) {
                assert.equal(block_chain.chain[i-1].get_hash(), cur_block.pre_hash);
            }
        }
    });
});
