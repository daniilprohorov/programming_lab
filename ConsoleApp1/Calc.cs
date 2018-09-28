using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Calc
    {
        private List<double> Result = new List<double>();
        private int count = 0;
        public List<String> StringWolfram = new List<String>();
        public Calc()
        {
        }
        public void initResult(double el)
        {
            Result.Add(el);
            count++;
        }

        public double getResult()
        {
            if (Result.Count > 0)
                return Result[Result.Count -1];
            else
            {
                Console.WriteLine("\n Список пуст ");
                return 0;
            }
                
        }
        public double getResult(int n)
        {
            if (Result.Count > 0 && n >= 1 && n <= Result.Count)
            {
                double Out = Result[n - 1];
                return Out;
            }
            else
            {
                if (n > Result.Count || n <= 0)
                {
                    Console.WriteLine("\n Нет такой ячейки ");
                    return 0;
                }
                else
                {
                    Console.WriteLine("\n Список пуст ");
                    return 0;
                }
            }
        }
        public int getCount() => count;
        public int add(double n)
        {
            Result.Add(getResult() + n);
            count++;
            return 0;
        }

        public int sub(double n)
        {
            Result.Add(getResult() - n);
            count++;
            return 0;
        }

        public int mul(double n)
        {
            Result.Add(getResult() * n);
            count++;
            return 0;
        }
        
        public int div(double n)
        {
            if (n == 0)
            {
                Console.WriteLine("\nОшибка, деление на 0");
                return -1;
            }
            else
            {
                Result.Add(getResult() / n);
                count++;
                return 0;
            }
        }
        
    }
}