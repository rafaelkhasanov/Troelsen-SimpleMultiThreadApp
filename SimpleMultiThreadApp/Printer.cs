using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Printer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Amazing Thread App");
            Console.WriteLine("Do you want [1] or [2] threds? ");
            string threadsCount = Console.ReadLine();
            //Назначить имя текущему потоку
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            //Вывести информацию о потоке
            Console.WriteLine($"-> {Thread.CurrentThread.Name} is executing Main()");
            //Создать рабочий класс

            Printer p = new Printer();
            switch (threadsCount)
            {
                case "2":
                    //Создать поток
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want...you get 1 thread may be.");
                    goto case "1";
            }

            //Выполнить некоторую дополнительную работу
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();
        }

        public void PrintNumbers()
        {
            //Вывести информацию о потоке
            Console.WriteLine($"->{Thread.CurrentThread.Name}");
            //Вывести числа
            Console.WriteLine("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i}, ");
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
