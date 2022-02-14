using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    interface ISoundable
    {
        public static void HappySound()
        {
            Console.Beep(330, 300);
          //  Console.Beep(262, 300);
            //Console.Beep(330, 300);
        }
        public static void WelcomeSound()
        {

            Console.Beep(262, 500);
            Console.Beep(330, 500);
            Console.Beep(392, 500);

           
            Console.Beep(330, 500);
            Console.Beep(392, 500);
            Console.Beep(530, 500);
        }
        public static void UnhappySound()
        {
            Console.Beep(250, 500);
            Console.Beep(250, 500);
            Console.Beep(250, 500);

        }
       
       
        
        
    }
}
