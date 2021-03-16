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
using Terminal;

namespace Windows_Terminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label1.Content = "dsadsasad";
        }

        private void MenuItem_Click_230(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 230400;
        }
        private void MenuItem_Click_115(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 115200;

        }
        private void MenuItem_Click_57(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 57600;

        }
        private void MenuItem_Click_56(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 56000;

        }
        private void MenuItem_Click_38(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 38400;

        }
        private void MenuItem_Click_28(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 28800;

        }
        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 19200;

        }
        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 14400;

        }
        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 9600;

        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 4800;

        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 2400;

        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 1200;

        }
        private void MenuItem_Click_06(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 600;

        }
        private void MenuItem_Click_03(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 300;

        }
        private void MenuItem_Click_01(object sender, RoutedEventArgs e)
        {
            Communicator._baudRate = 110;

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Label2.Content = Communicator._comName;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Label1.Content = Communicator._baudRate;
        }

        private void SetComName_Click_COM1(object sender, RoutedEventArgs e)
        {
            Communicator._comName = "COM1";
        }
        private void SetComName_Click_COM2(object sender, RoutedEventArgs e)
        {
            Communicator._comName = "COM2";
        }
        private void SetComName_Click_COM3(object sender, RoutedEventArgs e)
        {
            Communicator._comName = "COM3";
        }
        private void SetComName_Click_COM4(object sender, RoutedEventArgs e)
        {
            Communicator._comName = "COM4";
        }
        private void SetComName_Click_COM5(object sender, RoutedEventArgs e)
        {
            Communicator._comName = "COM5";
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if(Communicator.InitPort() == true)
            {
                Communicator.ReceiveCycle();
                
                ConnectButton.IsEnabled = false;
                DisconnectButton.IsEnabled = true;
            }
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            Communicator.Close();
            DisconnectButton.IsEnabled = false;
            ConnectButton.IsEnabled = true;
        }

        private void ProgramExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void Send(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var myString = TextBox2.Text;
                await Communicator.SendString(myString);
            }
        }
    }
}
