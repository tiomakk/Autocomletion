using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProviders;
using AutoCompletion;

namespace SearchConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sbInputString = new StringBuilder();
            var autocomletion = new Autocompletion(new FileDataProvider(@"C:\Users\TiomaK\AppData\Roaming\Skype\My Skype Received Files\Задание\Задание\test.in.txt"));
            while (true)
            {           
                char inputSymbol = Console.ReadKey().KeyChar;
                Console.Clear();
                if (inputSymbol == '\r')
                {
                    autocomletion.AddToDictionary(sbInputString.ToString());
                    sbInputString.Clear();
                    continue;
                }
                sbInputString.Append(inputSymbol);
                Console.WriteLine(sbInputString.ToString());
                Console.WriteLine(String.Join("\n", autocomletion.Complete(sbInputString.ToString())));
               

            }
        }
    }
}
