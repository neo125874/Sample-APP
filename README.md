<a name="To-Windows-APP-Candidate"></a>

# To Windows APP Candidate (Transcend)

Hi ,

Thanks for your interest in the position.  
We have a Windows APP exam (C#) before interview. Please finish it and commit your code to GitLab before interview. You can create a branch for you.

<a name="Getting-Started"></a>

## Getting Started

- Please install Visual Studio Express 2017 first.  
[https://visualstudio.microsoft.com/zh-hant/vs/express/](https://visualstudio.microsoft.com/zh-hant/vs/express/)

- Please go GitLab to register an account and clone the following project.  
[https://gitlab.com/ts-candidate-windows/sample-app](https://gitlab.com/ts-candidate-windows/sample-app)

- Open the solution file: SampleApp.sln

In this APP, you have to finish the 2 functions :

<a name="1-XML-Parser-"></a>

## 1\. XML Parser :

There is a XML file on the web :https://s3-ap-northeast-1.amazonaws.com/test.storejetcloud.com/product.xml  
Please implement a function to parser the content and fill the value (SN/PN/IO/FW) on the TextBlock in the APP.

**Expected result :  
Tap "Get Info" button. The App get the value of XML and fill on the TextBlock.**

![](https://s3-ap-northeast-1.amazonaws.com/test.storejetcloud.com/ex1.png)

## 2\. Dropbox Login

Please implement a function with OAuth 2.0 Authorization flow to Dropbox.  
Using Dropbox Oauth2 to Access Dropbox User Data and get your Dropbox account email.  
Please use App key and App secret in the project.

**App key : kht9ypqs7csaj4l**  
**App secret : 6mp365k86ad85ms**

Reference :  
[https://www.nuget.org/packages/Dropbox.Api/](https://www.nuget.org/packages/Dropbox.Api/)  
[https://dropbox.github.io/dropbox-sdk-dotnet/html/T_Dropbox_Api_DropboxOAuth2Helper.htm](https://dropbox.github.io/dropbox-sdk-dotnet/html/T_Dropbox_Api_DropboxOAuth2Helper.htm)  
[https://dropbox.github.io/dropbox-sdk-dotnet/html/T_Dropbox_Api_OAuth2Response.htm](https://dropbox.github.io/dropbox-sdk-dotnet/html/T_Dropbox_Api_OAuth2Response.htm)

![](https://s3-ap-northeast-1.amazonaws.com/test.storejetcloud.com/ex4.png)