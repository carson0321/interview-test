# Problem 1

Description: [trips-and-users](https://leetcode.com/problems/trips-and-users/description/)

# Problem 2

Description: Design a RESTful system. There are respectively four features:

* get /user/:id
* post /user
* get /user
* update user/:id

In order to make work extremely simple, I work on in-memory user data. Besides, POST/PUT methods don't access multiple user data(JSON Array). Just a simple data. It's easy to implement. Hope you don't mind.

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
curl -i http://127.0.0.1:5678/user/\
93c736cbbde6d982743704cec290de50
```
==>

```JSON
{
  "user": {
    "email": "0xdeadbeef@gmail.com",
    "id": "93c736cbbde6d982743704cec290de50",
    "name": "Hello World"
  }
}
```

* Test to post /user

```bash
curl -i -H "Content-Type: application/json" -X POST \
-d '{"name":"Test Name1", "email": "test1@eamil"}' \
http://127.0.0.1:5678/user
```

* Test to get /user

```bash
curl -i http://127.0.0.1:5678/user
```

* Test to update user/:id

```bash
curl -i -H "Content-Type: application/json" -X PUT \
-d '{"name":"Test Name1", "email": "test1@eamil"}' \
curl -i http://127.0.0.1:5678/user/\
93c736cbbde6d982743704cec290de50 
```

P.S. You can use Postman, brower or other tools to test except curl command.
