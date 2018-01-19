
# Amis Backend/Blockchain Engineer Test

## In Memory Blockchain
As an Amis blockchain/backend engineer, you will be dealing with backend, consensus, and distributed network problems. In this assignment we would like to see your abilities of coding, blockchain knowledge, as well as new technology adoption.

## Description:
In this test, you will work on an in-memory blockchain. To make it extremely simple, it's a single node blockchain setup, which means no network or p2p connections to deal with.  Also there is no signature or verification are necessary, so your consensus would be straightforward: just collect transactions and make them blocks.

## Specification:
1. It is an account based blockchain, which means there is no UTXO complication to deal with as well.
2. Newly observed accounts have 100 units of initial coins. For example, when your blockchain sees a transaction with a new sender or new recipient, it credits the new sender or/and recipient 100 coins.
3. The blockchain generates a new block every 10 seconds.
4. Block header has the following message

	- Block hash: Define your own hashing, can be something like SHA256(Block header)
	- Parent hash: Previous block hash.
	- Block height
	- Transactions: Array of transaction hashes belong to this block.

5. Transaction has the following message:

	- Transaction hash: hash of this transaction.
	- From: from address.
	- To: to address.
	- Value: coins to transaction.

6. Input: your program needs to take transaction input, it can be file, interactive console, command line, grpc API, JSON RPC API, you name it. Just whatever most efficient for you. Each transaction input contains: from address, to address, and value of coin.
7. Your program need to dump to blockchain log somewhere, can be console or file.

## Reference:
* [Thoughts on UTXOs by Vitalik Buterin, Co-Founder of Ethereum](https://medium.com/@ConsenSys/thoughts-on-utxo-by-vitalik-buterin-2bb782c67e53)
* [Go-ethereum (geth)](https://github.com/ethereum/go-ethereum/)
* [JSON RPC API](https://github.com/ethereum/wiki/wiki/JSON-RPC)
* [Web3.js](https://github.com/ethereum/web3.js/)