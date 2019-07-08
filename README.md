## Selling points
* Models
```csharp
        [XmlRoot(ElementName = "product")]
        public class Product
        {
            [XmlElement(ElementName = "SN")]
            public string SN { get; set; }
            [XmlElement(ElementName = "PN")]
            public string PN { get; set; }
            [XmlElement(ElementName = "IO")]
            public string IO { get; set; }
            [XmlElement(ElementName = "FW")]
            public string FW { get; set; }
        }
```
* BackgroundWorker
* RestSharp
* BusyIndicator
```csharp
        private void OnGetInfoClick(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();

            //this is where the long running process should go
            worker.DoWork += (o, ea) =>
            {
                //no direct interaction with the UI is allowed from this method
                var ProductUrl = ConfigurationManager.AppSettings["ProductUrl"];

                var client = new RestClient();
                client.BaseUrl = new Uri(ProductUrl, UriKind.Absolute);

                var request = new RestRequest();
                request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
                request.RequestFormat = RestSharp.DataFormat.Xml;

                var response = client.Execute<Product>(request);
                var displayData = response.Data;

                ea.Result = displayData;
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                #region TextBlock
                ...
                #endregion

                var displayData = ea.Result as Product;

                ...

                //work has completed. you can now interact with the UI
                _busyIndicator.IsBusy = false;
            };
            
            //set the IsBusy before you start the thread
            _busyIndicator.IsBusy = true;

            worker.RunWorkerAsync();
        }
```
* Programatically Set
```csharp
        private void OnSigninClick(object sender, RoutedEventArgs e) {
            BackgroundWorker worker = new BackgroundWorker();

            ...

            if (!string.IsNullOrEmpty(token)) {
                worker.DoWork += (o, ea) =>
                {
                    ...
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    ...

                    if (!string.IsNullOrEmpty(displayData.ProfilePhotoUrl)) {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(displayData.ProfilePhotoUrl);
                        bitmap.EndInit();

                        ViewBox.Child = new Image()
                        {
                            Source = bitmap
                        };
                    }
                    
                    _busyIndicator.IsBusy = false;
                };

                _busyIndicator.IsBusy = true;

                worker.RunWorkerAsync();
            }
        }
```

## FAQ
* FAT(12, 16, 32)
    * File Allocation Table
* exFAT
    * Extended File Allocation Table
* NTFS
    * New Technology File System
    
[https://www.mobile01.com/topicdetail.php?f=297&t=5459371]
* MBR
    * Master Boot Record
* GPT
    * GUID Partition Table
    
[https://kknews.cc/zh-tw/news/3ll6k2g.html]
* File System vs Partition
    * [http://jasonyychiu.blogspot.com/2017/06/ntfsfat32mbrgpt.html]
* ext4
    * Fourth extended filesystem
    * ext vs ntfs [https://www.ubuntu-tw.org/modules/newbb/viewtopic.php?post_id=299000]

<a name="To-Windows-APP-Candidate"></a>

# To Windows APP Candidate (Transcend)

Hi ,

Thanks for your interest in the position.  

We have a Windows APP exam (C#) before interview. Please finish it and commit your code to GitLab before interview. 

Please create a new branch for your commit. **You may need the permission to commit and create branch, please provide your GitLab account to us.**

<a name="Getting-Started"></a>

## Getting Started

- Please install Visual Studio Express first.  
[https://visualstudio.microsoft.com/zh-hant/vs/express/](https://visualstudio.microsoft.com/zh-hant/vs/express/)

- Please go GitLab to register an account and clone the following project.  
[https://gitlab.com/ts-candidate-windows/sample-app](https://gitlab.com/ts-candidate-windows/sample-app)

- Open the solution file: SampleApp.sln

In this APP, you have to finish the 2 functions :

<a name="1-XML-Parser-"></a>

## 1\. XML Parser :

There is a XML file on the web : https://s3-ap-northeast-1.amazonaws.com/test.storejetcloud.com/product.xml  
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

[https://github.com/dropbox/dropbox-sdk-dotnet](https://github.com/dropbox/dropbox-sdk-dotnet)

![](https://s3-ap-northeast-1.amazonaws.com/test.storejetcloud.com/ex4.png)
