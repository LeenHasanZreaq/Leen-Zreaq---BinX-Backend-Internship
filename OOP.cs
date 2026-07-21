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


            Trial test = new Trial("ahmed", "1234");
            test.equals();
            Console.WriteLine("Name : " + test.getName() + " 77, Pass : " + test.getPass());


            test.ToString();
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


    // make this class to test the oop class , and make constructor => defult constructor and full constructor
    // object , getter and setter for the class
    class Trial
    {
        private string name;
        private string pass;


        public Trial(string name, string pass)
        {
            this.name = name;
            this.pass = pass;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }


        public string getPass()
        {
            return pass;
        }

        public void setPass(string pass)
        {
            this.pass = pass;
        }

        public void equals()
        {
            if (name.Equals(pass))
            {
                Console.WriteLine("Name and Pass are equal");
            }
            else
            {
                Console.WriteLine("Name and Pass are not equal");
            }
        }



        public override string ToString()
        {
            return "Name : " + name + " Pass : " + pass;
        }

        // access modifier : 
        // public , private , protected , internal , protected internal , private protected

        class access
        {
            public string name;
            private string pass;
            protected string email;
            internal string phone; // anywhere in this project only

            protected internal string address; // same project OR any subclass
            private protected string city; // same class OR any subclass in the same project
        }
    }
}