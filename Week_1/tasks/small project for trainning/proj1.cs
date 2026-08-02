// i want to make small project about what i learn in c# language yasterday .

using System;

//  calculater 

// first i will make a calculater for the basic operations like : + , - , * , / , % .

namespace miniProject
{
    class Calculator
    {
        static void Main(string[] args)
        {
            int number1, number2, result;

            Console.WriteLine("Enter the first number: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            number2 = Convert.ToInt32(Console.ReadLine());

            char operation;

            Console.WriteLine("Enter the operation (+, -, *, /): ");
            operation = Convert.ToChar(Console.ReadLine());


            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    Console.WriteLine("The sum is: " + result);
                    break;

                case '-':
                    result = number1 - number2;
                    Console.WriteLine("The difference is: " + result);
                    break;


                // if the number1 in the Numerator and number2 in the Denominator 
                case '/':
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                        Console.WriteLine("The quotient is: " + result);

                    }


                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }

                    break;


                case '*':
                    result = number1 * number2;
                    Console.WriteLine("The product is: " + result);
                    break;


                default:
                    Console.WriteLine("Invalid operator.");
                    break;
            }

        }
    }
}