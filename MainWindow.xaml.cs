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

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (Communicator.InitPort() == true)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Communicator.GetAvailablePorts();

        }

        private void InitMenus(object sender, RoutedEventArgs e)
        {
            int[] bauds = { 230400, 115200, 57600, 56000, 38400, 28800, 19200, 14400, 9600, 4800, 2400, 1200, 600, 300, 110 };

            bauds.ToList().ForEach(b => BaudsBox.Items.Add(b));

            PortsBox.Items.Clear();
            Communicator.GetAvailablePorts();
        }

        private void RefreshPorts(object sender, RoutedEventArgs e)
        {
            var index = PortsBox.SelectedIndex;
            PortsBox.Items.Clear();
            Communicator.GetAvailablePorts();
            PortsBox.SelectedIndex = index;
        }

        private void PortsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PortsBox.SelectedItem != null)
            {
                Communicator._comName = PortsBox.SelectedItem.ToString();
                Label2.Content = Communicator._comName;
            }
        }

        private void BaudBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Communicator._baudRate = (int)BaudsBox.SelectedItem;
            Label1.Content = Communicator._baudRate;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
        }

        private void RTSBox_Checked(object sender, RoutedEventArgs e)
        {
            Communicator.currentPort.RtsEnable = true;
        }

        private void RTSBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Communicator.currentPort.RtsEnable = false;
        }
        private void DTRBox_Checked(object sender, RoutedEventArgs e)
        {
            Communicator.currentPort.DtrEnable = true;
        }
        private void DTRBox_Unchecked(object sender, RoutedEventArgs e)
        {

            Communicator.currentPort.DtrEnable = false;
        }
    }
}
