scannerupload
=============

Demo of the HTTP Post for the scanner data upload functionality.

Prerequisites
=============

Rest-Client: https://code.google.com/p/rest-client/
Downloadpage: http://code.fosshub.com/WizToolsorg-RESTClient/downloads
Download the Jar of Version 3.4 GUI Edition

Project is written in VS2013 and makes use of asp.net Web API.

Setup & Use
===========

- Clone or Download the Repository, run it in Visual Studio 2013.
- Your Browser should open an you get a 404 Error page (thats OK! I didnt define any index page)
- Start Rest-Client and load the TestRequest from ```/DemoData/``` Directory. (Check if the url from the running application corresponds with the one in the template)
- When you send the Request you should get a Status Code 200 OK.
- If you change the Username in the Auth tab you should get a Status Code 401 Unauthorized.
- If you remove or rename the Cart from the JSON message under the Body tab you should get a Status Code 400 Bad Request.

If you open the page http://localhost:6251/api/scanner in your browser, you should see the last message sent with the user credentials attached at the end as XML Message.
 



