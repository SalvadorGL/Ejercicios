using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExample
{
    public class Player1 : IPlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public double JumpElevation { get; set; }

        public bool Jump(IMovable movement)
        {
            return movement.Jump(JumpElevation);
        }

    }
}
