# Problem 1

Description: [trips-and-users](https://leetcode.com/problems/trips-and-users/description/)

I haven't written in MySQL for a long time. I usually use mongoDB to handle data in my work. I try to think it over, and look up information online. Hope you don't mind.


* Flowchart:
    1. Search user who the status is cancellation
    2. Need to filter banned user between 2013/10/01-2013/10/03
    3. Compute cancellation rate


```sql
SELECT Request_at Day,
ROUND(SUM(IF(Status != 'completed', TRUE, 0)) / SUM(*), 2) 'Cancellation Rate'
FROM Trips WHERE (Request_at BETWEEN '2013-10-01' AND '2013-10-03') AND
Client_Id IN (SELECT Users_Id FROM Users WHERE Banned = 'No')
GROUP BY Request_at;
```

# Problem 2

Description: Design a RESTful system. There are respectively four features:

* get /user/:id
* post /user
* get /user
* update user/:id

In order to make work simple, I work on in-memory user data. Besides, POST/PUT methods doesn't access multiple user data(JSON Array). Just a simple data. It's easy to implement.

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
