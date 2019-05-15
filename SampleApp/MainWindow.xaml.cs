using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
