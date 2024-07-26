namespace Client.Console;
using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            TcpClient client = new("127.0.0.1", 6000);
            Console.WriteLine("Connected client");

            NetworkStream stream = client.GetStream();

            byte[] data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string responseData = Encoding.ASCII.GetString(data, 0, bytes);

            System.Console.WriteLine($"Receive: {responseData}");

            client.Close();

        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
