﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Player player = new Player())
            {
                player.Jump();
            }
            Console.ReadLine();
        }
    }
}