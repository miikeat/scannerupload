scannerupload
=============

Demo of the HTTP Post for the scanner data upload functionality.

Prerequisites
=============

Rest-Client: https://code.google.com/p/rest-client/

Setup
=====

- Clone or Download the Repository, run it in Visual Studio 2013.
- Start Rest-Client and load the TestRequest from ```/DemoData/``` Directory.

This should give you a Status Code 200 OK.

If you change the Username in the JSON message in the Request Body you should get a Status Code 401 Unauthorized.
If you remove the Cart from the JSON message or send the request without any Data in Body you should get a Status Code 400 Bad Request.

