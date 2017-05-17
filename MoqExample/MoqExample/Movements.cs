using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExample
{
    public class Movements : IMovable
    {
        public bool Jump(double elevation)
        {
            //process to do player jump
            //...
            Console.WriteLine("Jump!!");
            return true; // just jump
        }
    }
}
