using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Использование:\n" +
                "Когда первый символ '>' введите число или ячейчку памяти out[i] \n" +
                "Когда первый символ '@' введите операцию для выполнение действия\n" +
                "       n - новый блок"+
               // "       w <имя файла> - записать файл"+
               // "       o <имя файла> - открыть файл файл"+
                "       <число> вывода ячейки с результатом\n" +
                "       q - выход из программы");

            Wolfram W = new Wolfram();
            Calc c = new Calc();
            IO input = new IO();
        
            input.Actions(W);
            input.SaveFile(W.CreateFile());
        }
    }
}
