using System;

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

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}