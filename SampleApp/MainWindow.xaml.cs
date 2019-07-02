using Dropbox.Api;
using Dropbox.Api.Users;
using Microsoft.VisualBasic;
using RestSharp;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleApp
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TokenText_GotFocus(object sender, RoutedEventArgs e)
        {
            if(TokenText.Tag.ToString() == "True")
            {
                TokenText.Tag = "False";
                TokenText.Text = "";
            }
        }

        private void TokenText_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TokenText.Text) && TokenText.Tag.ToString() == "False")
            {
                TokenText.Text = "Enter user secret here";
                TokenText.Tag = "True";
            }
        }
        
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
                var textSN = this.FindName("SN") as TextBlock;
                var textPN = this.FindName("PN") as TextBlock;
                var textIO = this.FindName("IO") as TextBlock;
                var textFW = this.FindName("FW") as TextBlock;
                #endregion

                var displayData = ea.Result as Product;

                textSN.Text = @"SN :" + displayData.SN;
                textPN.Text = @"PN :" + displayData.PN;
                textIO.Text = @"IO :" + displayData.IO;
                textFW.Text = @"FW :" + displayData.FW;

                //work has completed. you can now interact with the UI
                _busyIndicator.IsBusy = false;
            };
            
            //set the IsBusy before you start the thread
            _busyIndicator.IsBusy = true;

            worker.RunWorkerAsync();
        }

        private void OnSigninClick(object sender, RoutedEventArgs e) {
            BackgroundWorker worker = new BackgroundWorker();

            var DropboxKey = ConfigurationManager.AppSettings["DropboxKey"];
            var DropboxSecret = ConfigurationManager.AppSettings["DropboxSecret"];

            var url = DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Code, DropboxKey, redirectUri: null as Uri);

            Process.Start(url.ToString());
            var token = Interaction.InputBox(@"Enter the code from Transcend Candidate to finish the process.");

            if (!string.IsNullOrEmpty(token)) {
                worker.DoWork += (o, ea) =>
                {
                    var response = DropboxOAuth2Helper.ProcessCodeFlowAsync(token, DropboxKey, DropboxSecret);
                    
                    var client = new DropboxClient(response.Result.AccessToken);

                    var account = client.Users.GetCurrentAccountAsync();

                    ea.Result = account.Result;
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    var displayData = ea.Result as FullAccount;

                    Name.Text = "Name: " + displayData.Name.DisplayName;
                    Email.Text = "Email: " + displayData.Email;

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

    }
}
