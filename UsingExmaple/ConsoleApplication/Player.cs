using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Player : IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Dispose()
        {
            Console.WriteLine("Disposing Player");
            //this.Dispose();
        }

        public void Jump()
        {
            Console.WriteLine("Player: I'm jumping");
        }
    }
}
