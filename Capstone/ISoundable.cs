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

            Console.Beep(262, 350);
            Console.Beep(330, 350);
            Console.Beep(392, 350);
            
           
         

        }
        public static void UnhappySound()
        {
            Console.Beep(250, 600);
            Console.Beep(250, 600);
            Console.Beep(250, 600);

        }
       
       
        
        
    }
}
