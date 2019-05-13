# Sample APP

Windows WPF APP exam for candidate123

Getting Started
- Please install Visual Studio Express first.
https://visualstudio.microsoft.com/zh-hant/vs/express/

- Please go GitLab to register a account and clone the following project.
https://gitlab.com/ts-candidate-windows/sample-app

- Open the solution file: SampleApp.sln

In this APP, you have to finish the 2 functions :

1. XML Parser :
There is a XML file on the web :https://s3-ap-northeast-1.amazonaws.com/test.storejetcloud.com/product.xml
Please implement a function to parser the content and fill the value (SN/PN/IO/FW) on the TextBlock in the APP.

Expected result : 
Tap "Get Info" button. The App get the value of XML and fill on the TextBlock.



2. Google Login
Please implement a function with OAuth 2.0 Authorization flow to Google.
Using Google Oauth2 to Access Google User Data and get your Google account and profile photo. 
Please use the client id and client secret in the project.
client id : 1088687769016-hj3n1g4buthbtc7o4fl7qap9v9acfg0q.apps.googleusercontent.com
client secret : eynEMBbul62RaQWjG6LqmF6F
Reference : https://developers.google.com/identity/protocols/OAuth2InstalledApp

Expected result : 
Step1. Tap "Sign In" button > open browser 
Step2. Enter "Email" > Enter "Password" > get access_token
Step3. Show Userinfo - Email / Name / Picture in the APP.

