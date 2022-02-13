using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Capstone
{
    interface IPauseable
    {
        public static void longPause()
        {
            Thread.Sleep(3000);
        }
        public static void shortPause()
        {
            Thread.Sleep(800);
        }
        public static void pauseWithRedirect()
        {
            Thread.Sleep(3000);
            Console.WriteLine();
            Console.Write("Redirecting");


            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");

            }
            Console.WriteLine();
        
        
        
        }




    }
}
