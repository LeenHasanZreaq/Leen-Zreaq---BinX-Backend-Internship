using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // a simple basic for the data type of variable is : char , double , float , int , long , short , string , bool
            char ch = 'A';
            double d = 3.14;
            float fl = 3.14f;
            int x = 42;
            long l = 1234567890L;
            short sh = 32767;
            string s = "Hello, World!";
            bool b = true;

            Console.WriteLine("Character: " + ch);
            Console.WriteLine("Double: " + d);
            Console.WriteLine("Float: " + fl);
            Console.WriteLine("Integer: " + x);
            Console.WriteLine("Long: " + l);
            Console.WriteLine("Short: " + sh);
            Console.WriteLine("String: " + s);
            Console.WriteLine("Boolean: " + b);


            // if else statement 
            int number = 10;
            if (number > 0)
            {
                Console.WriteLine("The number is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine("The number is negative.");
            }
            else
            {
                Console.WriteLine("The number is zero.");
            }


            // switch case statement

            int day = 3;
            switch (day)
            {
                case 2:
                    Console.WriteLine("Monday");
                    break;

                case 3:
                    Console.WriteLine("Tuesday");
                    break;

                case 4:
                    Console.WriteLine("Wednesday");
                    break;

                default:
                    Console.WriteLine("sunday");
                    break;
            }


            // for loop statement
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("For loop iteration: " + i);
            }





            // input from user && output to user
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name);



            // while loop statement
            int num = 4;
            while (num < 10)
            {
                Console.WriteLine("Using while loop the number is : " + num);
                num++;
            }

            // do while loop statement
            int num1 = 9;
            do
            {
                Console.WriteLine("Using do while loop the number is : " + num1);
                num1++;
            } while (num1 < 10);

            // continue statement
            int num2 = 0;
            string result = num2 < 5 ? "less than 5" : "greater than 5";
            Console.WriteLine("Using continue statement the number is : " + result);

            // numeric formatting
            double number1 = 12345.6789;
            Console.WriteLine("Number in currency format: " + number1.ToString("C"));

            string name1 = "leen";
            int age1 = 20;
            Console.WriteLine("My name is {0} and I am {1:0.00} years old.", name1, age1);



            // TryParse function example
            string input1 = "123zz";
            int num23;
            int.TryParse(input1, out num23);
            Console.WriteLine("TryParse result: " + num23);


        }
    }
}