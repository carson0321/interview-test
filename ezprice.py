#!/usr/bin/python
# -*- coding: utf-8 -*-
#########################################################################
# File Name: ezprice.py
# Author: Carson Wang
# mail: carson.wnag@droi.com
# Created Time: 2018-03-31 21:26:38
#########################################################################

from flask import Flask, abort, jsonify, make_response, request
import json

app = Flask(__name__)

class User:
    def __init__(self, _id, name, email):
        if not (_id or name or email):
            raise ValueError('Empty id, name, email not allowed.')
        self.id, self.name, self.email = _id, name, email

users = [
    json.loads(json.dumps(User('1','Hello World','0xdeadbeef@gmail.com').__dict__)),
    json.loads(json.dumps(User('2','Carson Wang','r03944040@g.ntu.edu.tw').__dict__)),
    json.loads(json.dumps(User('3','KaiSheng','r03944040@ntu.edu.tw').__dict__)),
]

@app.route('/user/<user_id>', methods=['GET'])
def getUser(user_id):
    user = [i for i in users if i['id'] == user_id]
    if len(user) == 0:
        abort(404)
    return jsonify({'user': user[0]})

@app.route('/user', methods=['GET'])
def getAllUser():
    return jsonify({'users': users})

@app.errorhandler(404)
def notFound(error):
    return make_response(jsonify({'error': 'Not found'}), 404)

if __name__ == '__main__':
    app.run(host='127.0.0.1', port=5678, debug=True)

