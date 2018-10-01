using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class IO
    {
        public void PrintCalc(Wolfram W)
        {
            var i = W.GetCalcs().Count;
            Calc c = W.LastCalc();
            string input = " in[" + i  + "] = " + String.Join("", c.StringWolfram);
            string output = " out[" + i + "] = " + c.GetResult();
            SaveFile(input + output); 
            Console.WriteLine("\n" + input);
            Console.WriteLine("\n" + output);
        }
        public double Num(Wolfram W)
        {
            Calc c = W.LastCalc();
            bool input = false;
            double num = 0;
            while (!input)
            {

                //c.StringWolfram.ForEach(Console.Write);
                Console.Write("> ");
                String consoleStr = Console.ReadLine().Split()[0];
                input = double.TryParse(consoleStr, out num);

                if (!input)
                {
                    List<Char> lstChar = new List<Char>(consoleStr.ToCharArray());
                    var lstOfPursantage = lstChar.Where(x => x == '%');
                    int n = lstOfPursantage.ToList().Count;
                    if (n > 0 && W.GetCalcs().Count > 0)
                    {
                        c.StringWolfram.Add(String.Join("", lstOfPursantage));
                        if (c.StringWolfram.Count >= 1)
                        {   
                            if(c.Count>= 1)
                            {
                                c.StringWolfram.Add(")");
                            }
                            Calc res = W.NCalc(n);
                            if(res != null)
                            {
                                return res.GetResult();
                            }
                          
                        }
                    }    
                    Console.WriteLine("\n Повторите ввод, введён неверный тип данных ");
                }
                else
                {
                    c.StringWolfram.Add(num.ToString());
                    if (c.StringWolfram.Count > 2)
                        c.StringWolfram.Add(")");
                }
            }
            return num;
        }

        public int SaveFile(String information, String path = "new6.nb")
        {
            try
            {
                if (File.Exists(path))
                {
                    File.WriteAllText(path, information);
                }
                else
                {
                    File.Create(path);
                    File.WriteAllText(path, information);
                }
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public delegate int actionFunc(double n);
        private void loop(actionFunc func, Wolfram W)
        {
            int res = 0;
            do
            {
                res = func(Num(W));
                if (res < 0)
                    Console.WriteLine("\n Повторите ввод данных, неверное число!");
            } while (res != 0);
        }
        public void PrintAnswer(Calc c)
        {
                    double prt = c.GetResult(c.Count);
                    Console.Write("\n[#{0}]= {1}", c.Count, prt);
            
        }
        public void Actions(Wolfram W)
        {
            int num;
            Boolean exit = false;
            do
            {
                Calc c = W.LastCalc();
                if (c.Count== 0)
                {
                    c.InitResult(Num(W));
                }

                
                Console.Write("\n@: ");
                bool input = false;

                String str = Console.ReadLine().Split()[0];


                input = Int32.TryParse(str, out num);
                if (!input)
                {
                    switch (str[0])
                    {
                        case '+':
                            c.StringWolfram.Add("+");
                            c.StringWolfram.Insert(0, "(");
                            loop(c.add, W);
                            PrintAnswer(c);
                            break;
                        case '-':
                            c.StringWolfram.Add("-");
                            c.StringWolfram.Insert(0, "(");
                            loop(c.sub, W);
                            PrintAnswer(c);
                            break;
                        case '*':
                            c.StringWolfram.Add("*");
                            c.StringWolfram.Insert(0, "(");
                            loop(c.mul, W);
                            PrintAnswer(c);
                            break;
                        case '/':
                            c.StringWolfram.Add("/");
                            c.StringWolfram.Insert(0, "(");
                            loop(c.div, W);
                            PrintAnswer(c);
                            break;
                        case 'n':
                            //c.StringWolfram.Insert(0, "(");
                            PrintCalc(W);
                            W.NewCalc();
                            break;
                        case 'q':
                            exit = true;
                            break;
                        default:
                            Console.Write("\nНеправильно введена команда");
                            break;
                    }
                }
                else
                {
                    c.GetResult(num);
                }
            } while (!exit);
        }
        
    }
}