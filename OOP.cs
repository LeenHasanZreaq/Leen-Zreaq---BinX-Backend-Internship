using System;
using System.Security.Cryptography.X509Certificates;

namespace oop
{
    class OOPClass
    {
        public static void Main(string[] args)
        {
            Position player = new Position(10, 20);
            Console.WriteLine("X : " + player.x + " Y : " + player.y);
        }


        struct Position
        {
            public int x;
            public int y;

            // i cant make x = y becouse x and y are 2 variables in the deferent plase in the heap 


            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}