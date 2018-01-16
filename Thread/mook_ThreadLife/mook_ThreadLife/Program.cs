using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mook_ThreadLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread lifeThread = new Thread(DoStop);
            lifeThread.Start();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Main Thread Count : {0}", i);
                Thread.Sleep(5);
            }
            lifeThread.Join();
            Console.WriteLine("End Of Thread");
        }

        private static void DoStop()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Sub Thread Count : {0}", i);
                Thread.Sleep(5);
            }
        }
    }
}
