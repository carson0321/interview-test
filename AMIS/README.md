# Environment
* OS X EI capitan 10.11.6
* npm 5.6.0
* node 9.3.0

# Files Tree
Without node_modules.

```bash
.
├── README.md
├── SPEC.md
├── blockchain.json
├── client.js
├── package.json
├── server
│   ├── Block.js
│   ├── BlockChain.js
│   ├── Transaction.js
│   ├── Wallet.js
│   ├── WalletDatabase.js
│   └── server.js
├── test
│   ├── test_blockchain.js
│   └── test_walletdatabase.js
└── wallets.json
```

- blockchain.json: Dump all information for blockchain.
- wallets.json: Dump all information for wallets.

# Usages
* First, compress files and install required modules:

```bash
unzip amis-test
cd amis-test
npm install
```

* Second, run server to create blockchain on localhost:


```npm run server``` or ```node server/server.js```

* Finally, begin to take transaction input. There are two ways. 

	1. Execute client progrom: ```npm start``` or ```npm run client``` or ```node client.js```
	2. Use command directly:
		* Create transaction:
```
curl -i -H "Content-Type: application/json" -X POST -d
'{"from":"from_address","to":"to_address","value":20}'
http://localhost:8888/transaction
```

		* Get all information for blockchain:
```
curl -i -H "Content-Type: application/json" -X POST http://localhost:8888/blockchain
```

		* Get all information for wallets:
```
curl -i -H "Content-Type: application/json" -X POST http://localhost:8888/wallets
```

# Unit testing
There are some test cases.

* Use previous hash to verify blockchain ```npm run test-blockchain``` or ```mocha test/test_blockchain.js```
* Simple test wallet and transaction ```npm run test-walletdatabase``` or ```mocha test/test_walletdatabase.js```
* Run all test cases: ```npm test``` or ```mocha test/```

# Download
* [Google Cloud Storage]()
