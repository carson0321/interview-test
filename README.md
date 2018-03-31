# Problem 1

Description: [trips-and-users](https://leetcode.com/problems/trips-and-users/description/)

# Problem 2

Description: Design a RESTful system. There are respectively four features:

* get /user/:id
* post /user
* get /user
* update user/:id

### Test environment

* Ubuntu 14.04.5 LTS
* Python 3.4.3

### Get started

```bash
(Optional)
$ cd ezprice
$ virtualenv --no-site-packages -p python3 env
$ source env/bin/activate
=========================================
(env)$ pip install -r requirements.txt
(env)$ python ezprice.py
```

### Usages


* Test to get /user/:id

```bash
curl -i -X GET http://127.0.0.1:5678/user/1
```

* Test to post /user
* Test to get /user

```bash
curl -i -X GET http://127.0.0.1:5678/user
```

* Test to update user/:id

P.S. You can use Postman, brower or other tools to test except curl command.
