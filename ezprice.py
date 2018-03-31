#!/usr/bin/python
# -*- coding: utf-8 -*-
#########################################################################
# File Name: ezprice.py
# Author: Carson Wang
# mail: carson.wnag@droi.com
# Created Time: 2018-03-31 21:26:38
#########################################################################

from flask import Flask, abort, jsonify, make_response, request
import functools

app = Flask(__name__)

users = [
    {
        'id': '1',
        'name': 'Hello world',
        'email': '0xdeadbeef@gmail.com'
    },
    {
        'id': '2',
        'name': 'Carson Wang',
        'email': 'r03944040@g.ntu.edu.tw'
    },
    {
        'id': '3',
        'name': 'KaiSheng Wang',
        'email': 'r03944040@ntu.edu.tw'
    }
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

