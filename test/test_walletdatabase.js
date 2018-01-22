/*
 * File Name: test_walletdatabase.js
 * Author: Carson Wang
 * mail: r03944040@ntu.edu.tw
 * Created Time: 2018-01-22 18:45:59
 */

const WalletDatabase = require('../server/WalletDatabase');
const assert = require('assert');

describe('Verify walletdatabase', () => {
    const value = 30;
    const wallet_database = new WalletDatabase();
    const from_wallet = wallet_database.get_wallet('alice');
    const to_wallet = wallet_database.get_wallet('bob');
    it('simple test inital balance', () => {
        assert.equal(100, from_wallet.balance);
        assert.equal(100, to_wallet.balance);
    });
    it('simple test transaction', () => {
        from_wallet.balance -= value;
        to_wallet.balance += value;
        assert.equal(70, from_wallet.balance);
        assert.equal(130, to_wallet.balance);
    });
    it('simple test dultiple and unique wallet', () => {
        const existing_wallet_ignored = wallet_database.get_wallet('alice');
        assert.equal(2, wallet_database.data.length);
        const no_existing_wallet_ignored = wallet_database.get_wallet('carson');
        assert.equal(3, wallet_database.data.length);
    });
});

