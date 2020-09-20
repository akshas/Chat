using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static IPAddress IP = IPAddress.Parse("127.0.0.1");
        static TcpListener listener = new TcpListener(IP, 5000);
        static List<ConnectedClient> clients = new List<ConnectedClient>();

        static void Main(string[] args)
        {
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Task.Run(() => 
                {
                    StreamReader sr = new StreamReader(client.GetStream());
                    while (client.Connected)
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("Login: ") && !string.IsNullOrWhiteSpace(line.Replace("Login: ", "")))
                        {
                            string nick = line.Replace("Login: ","");
                            if (clients.FirstOrDefault(connectedClient => connectedClient.Name == nick) == null)
                            {
                                clients.Add(new ConnectedClient(client, nick));
                                Console.WriteLine("New connection: " + nick);
                                break;
                            }
                            else
                            {
                                StreamWriter sw = new StreamWriter(client.GetStream());
                                sw.AutoFlush = true;
                                sw.WriteLine($"Es gibt schon ein Benutzern min dem Namen [{nick}]");
                                client.Client.Disconnect(false);
                            }
                        }
                    }

                    while (client.Connected)
                    {
                        try
                        {
                            sr = new StreamReader(client.GetStream());
                            string line = sr.ReadLine();
                            SendToAllClients(line);
                            Console.WriteLine(line);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                });
            }
        }

        private static async void SendToAllClients(string message)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(clients[i].Client.GetStream());
                        sw.AutoFlush = true;
                        sw.WriteLine(message);
                    }
                    catch { }
                } 
            });
        }
    }
}
