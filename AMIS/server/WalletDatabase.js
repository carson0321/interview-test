/*
 * File Name: WalletDatabase.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-22 18:19:29
 */

const Wallet = require('./Wallet');
const _ = require('lodash');

class WalletDatabase {
    constructor() {
        this.data = [];
    }

    // check if wallet exists
    exist(address) {
        const match = _.findIndex(this.data, (o) => {
            return o.address == address;
        });
        return match == -1 ? false : true ;
    }

    get_wallet(address) {
        let wallet;
        // create new wallet
        if(!this.exist(address)) {
            wallet = new Wallet(address, 100);
            this.data.push(wallet);
        }
        // get existing wallet
        else wallet = _.find(this.data, {address: address});
        return wallet;
    }
}

module.exports = WalletDatabase;
