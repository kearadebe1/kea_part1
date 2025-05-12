using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kea_part1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //creating instance for voice_over
            new voice_over() { };

            new logo() { };


            //creating an instance for security_awe
            new security_awe() { };

            //creating an instance for MemoryRecall_generic
            new MemoryRecall_generic() { };
        }
    }
}


