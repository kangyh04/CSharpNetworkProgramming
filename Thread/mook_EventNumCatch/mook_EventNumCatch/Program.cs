using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mook_EventNumCatch
{
    class Program
    {
        static void Catch1(object sender, EventArgs e)
        {
            Console.Write("even");
        }

        static void Catch2(object setdern, EventArgs e)
        {
            Console.Write("3 times");
        }

        static void Main(string[] args)
        {
            CatchClass ctc = new CatchClass();
            ctc.NumCatch += new CatchClass.OnEventHandler(Catch1);

            for (int i = 1; i < 10; ++i)
            {
                if (i % 2 == 0 && i < 5)
                {
                    ctc.GoEvent();
                }

                if (i == 5)
                {
                    ctc.NumCatch -= new CatchClass.OnEventHandler(Catch1);
                    ctc.NumCatch += new CatchClass.OnEventHandler(Catch2);
                }

                if (i % 3 == 0 && i > 5)
                {
                    ctc.GoEvent();
                }
                Console.WriteLine("{0}", i);
            }
        }

        class CatchClass
        {
            public delegate void OnEventHandler(object sender, EventArgs e);
            public event OnEventHandler NumCatch;
            public void GoEvent()
            {
                if (NumCatch != null)
                {
                    EventArgs e = new EventArgs();
                    NumCatch(this, e);
                }
            }
        }
    }
}
