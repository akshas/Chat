using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _Ip;
        public string Ip
        {
            get
            {
                return _Ip;
            }
            set
            {
                _Ip = value;
            }
        }
        private string _Port;

        public string SPort
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        private string _Nick;
        public string Nick
        {
            get
            {
                return _Nick;
            }
            set
            {
                _Nick = value;
            }
        }


        private string _Chat;
        public string Chat
        {
            get
            {
                return _Chat;
            }
            set
            {
                _Chat = value;
            }
        }

        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        TcpClient client;
        StreamReader sr;
        StreamWriter sw;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Ip = "127.0.0.1";
            SPort = "5000";
            Nick = "Alex";

            Task.Run(() => { 
            
                while (true)
                {
                    try
                    {
                        if (client?.Connected == true)
                        {
                            string line = sr.ReadLine();
                            Chat += line + "\n";
                            MessageBox.Show(Chat);
                        }
                        Task.Delay(10).Wait();
                    }
                    catch
                    {

                    }

                }
            });

        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
             
                    try
                    {
      
                        client = new TcpClient();
                        Int32.TryParse(SPort, out int Port);
                        client.Connect(Ip, Port);
                        sr = new StreamReader(client.GetStream());
                        sw = new StreamWriter(client.GetStream());
                        sw.AutoFlush = true;
                        sw.WriteLine($"Login: {Nick}");
                    }
                    catch { }
            });
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                try
                {
                    sw.WriteLine($"{Nick}: {Message}");
                }
                catch { }
            });
        }
    }
}
