using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Terminal
{
    public static class Communicator
    {
        public static string _comName = "COM5";
        public static int _baudRate = 115200;
        public static Parity _parity = Parity.None;
        public static int _dataBits = 8;
        public static StopBits _stopBits = StopBits.One;


        static SerialPort myPort;

        public static bool InitPort()
        {
            myPort = new SerialPort(_comName, _baudRate, _parity, _dataBits, _stopBits);
            try
            {
                myPort.Open();
                return true;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                return false;
            }
        }

        public static void Close()
        {

            myPort.Close();
            myPort.Dispose();
            
        }

        public static async Task<string> Receive()
        {
            byte[] receiveBuffer = new byte[1024];
            var numBytesReaden = await myPort.BaseStream.ReadAsync(receiveBuffer);
            return Encoding.UTF8.GetString(receiveBuffer, 0, numBytesReaden);
        }

        public static async Task SendString(string inputString)
        {
            if (inputString == "+++" || inputString == "\\0")
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(inputString);
                await myPort.BaseStream.WriteAsync(sendBuffer);
            }
            else
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(inputString + "\r\n");
                await myPort.BaseStream.WriteAsync(sendBuffer);

            }
        }


        public static async void ReceiveCycle()
        {
            var parentWindow = Window.GetWindow(Application.Current.MainWindow) as Windows_Terminal.MainWindow;

            while (true)
            {
                try
                {
                    var receivedString = await Communicator.Receive();
                    parentWindow.TextBox1.Text += receivedString;
                    parentWindow.TextBox1.ScrollToEnd();

                }
                catch (System.OperationCanceledException)
                {
                    break;
                }
            }
        }

       


    }
}
