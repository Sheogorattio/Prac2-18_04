using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prac2_18_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank b = new Bank("MBank");
            b.Money = 6;
            b.Percent = 25;
            Thread.Sleep(1000);
            Console.WriteLine(b.Money.ToString() + " " +  b.Percent.ToString());
            Console.Read();
        }
    }
}
