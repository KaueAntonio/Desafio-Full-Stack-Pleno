using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TcpListener? server = null;
        try
        {
            Int32 port = Convert.ToInt32(Environment.GetEnvironmentVariable("PORT_APP") ?? "12345");

            IPAddress localAddr = IPAddress.Parse("0.0.0.0");

            server = new TcpListener(localAddr, port);

            server.Start();

            while (true)
            {
                Console.WriteLine("Aguardando conexão...");

                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Conectado!");

                Random rnd = new();
                int randomNumber = rnd.Next();

                string data = randomNumber.ToString();

                byte[] msg = Encoding.ASCII.GetBytes(data);

                NetworkStream stream = client.GetStream();

                stream.Write(msg, 0, msg.Length);

                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("Erro de socket: {0}", e);
        }
        finally
        {
            server.Stop();
        }
    }
}
