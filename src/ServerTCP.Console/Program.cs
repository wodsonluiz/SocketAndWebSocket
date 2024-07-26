namespace ServerTCP.Console;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TcpListener server = null;

        try
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            server = new(localAddr, 6000);
            server.Start();

            Console.WriteLine("Server inited, waiting connections...");

            while (true)
            {
                var client = server.AcceptTcpClient();
                Console.WriteLine("Client connected!");

                NetworkStream stream = client.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes("Hello client!");
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Message send to client");

                client.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            server.Stop();
        }
    }
}
