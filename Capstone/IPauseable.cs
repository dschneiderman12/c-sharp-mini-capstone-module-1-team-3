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
            Thread.Sleep(400);
        }
        public static void mediumPause()
        {
            Thread.Sleep(2000);
        
        }
        public static void pauseWithRedirect()
        {
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.Write("Redirecting");


            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(600);
                Console.Write(".");

            }
            Thread.Sleep(1500);
            Console.WriteLine();
        
        
        
        }




    }
}
