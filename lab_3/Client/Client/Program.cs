using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Server S;
            if(args.Length > 0)
            {
                S = new Server(args[0], Convert.ToInt32(args[1]));
            }
            else
            {
                S = new Server();
            }
            
            bool exit = false;
            string result;
            int g_id;
            Console.Write("Для использования программы введите выражение в поле 'In[<n>]'\nГде <n> - номер операции. Для вывода этой результата\nВведите [<r>], где <r> - номер нужной операции");
            while (!exit)
            {
                g_id = S.GetId();
                Console.Write($"In [{g_id}] = ");
                string message = Console.ReadLine();
                if (message.IndexOf("[") >= 0 && message.IndexOf("]") >= 0)
                {
                    string pattern = @"([\d])";
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(message);
                    int id;
                    if (match.Success)
                    {
                        id = Convert.ToInt32(match.Groups[1].Value);
                        Console.WriteLine($"Out [{g_id}] = {S.GetLastRes(id)}");
                    Console.WriteLine("\n=================================================\n");
                        
                    }
                }
                else if(message == "exit")
                {
                    S.Exit();
                    exit = true;
                }
                else
                {
                    Console.WriteLine($"Out [{g_id}] = {S.GetRes(message)}");
                    Console.WriteLine("\n=================================================\n");
                }
            }
        }
    }
}
