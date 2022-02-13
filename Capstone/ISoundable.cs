using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    interface ISoundable
    {
        public static void happySound()
        {
            Console.Beep();
                
        }
        public static void unhappySound()
        {
            Console.Beep(250, 600);
            Console.Beep(250, 600);
            Console.Beep(250, 600);

        }
        public static void freakingOutSound()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(233, 600);
            }
       
        
        }
    }
}
