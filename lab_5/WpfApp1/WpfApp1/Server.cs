using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1 
{
    public class Server
    {
        private static Socket socket;
        public Server(string adress = "127.0.0.1", int port = 904)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(adress, port);
        }
        public int Send(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            socket.Send(buffer);
            return 1;
        }
        public string Receive()
        {
            byte[] buffer = new byte[1024];
            int n = socket.Receive(buffer);
            return Encoding.ASCII.GetString(buffer, 0, n);
        }
        public int GetId()
        {
            Send("i_g");
            string[] res = Receive().Split('_');
            if(res[0] == "i")
            {
            //    Console.WriteLine(Convert.ToInt32(res[1]));
                return Convert.ToInt32(res[1]);
            }
            else
            {
                return -1;
            }
            
        }
        public double GetRes(string expression)
        {
            Send("r_" + expression);
            string[] res = Receive().Split('_');
            if(res[0] == "r")
            {
                return Convert.ToDouble(res[1]);
            }
            else
            {
                return double.NaN;
            }
        } 
        public double GetLastRes(int id)
        {
            Send("lr_" + id.ToString());
            string[] res = Receive().Split('_');
            if(res[0] == "lr")
            {
                return Convert.ToDouble(res[1]);
            }
            else
            {
                return double.NaN;
            }
        }
        public void Exit()
        {
            Send("exit");
            Send("exit");
            //socket.Shutdown(SocketShutdown.Both);
            //socket.Disconnect(true);
            socket.Close();
        }
        ~Server()
        {
            //Send("exit");
            //Send("exit");
            //socket.Close();
        }
    }
}
