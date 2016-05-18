using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ranMatrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var r = new RanMatrix();
            r.ConsoleWrite();
            Console.WriteLine();
            
            int n;
            while (true)
            {
                n = r.Next();
                if (n == -1)
                    break;
                Console.Write("{0} ", n);   
            }
            
            Console.ReadKey();
        }
    }
}
