using MoqExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player = new Player1();
            player.ID = 100;
            player.Name = "Jugador 1";
            player.JumpElevation = 3.8;

            PrintInfo(player);

            //move player
            IMovable moves = new Movements();
            moves.Jump(player.JumpElevation);
            Console.ReadLine();
        }

        public static void PrintInfo(IPlayer player)
        {
            Console.WriteLine("Welcome " + player.Name + "!!");
            Console.WriteLine("Your Information :");
            Console.WriteLine("ID: " + player.ID);
            Console.WriteLine("Name: " + player.Name);
            Console.WriteLine("Vertical Jump: " + player.JumpElevation);
            Console.ReadLine();
        }
    }
}
