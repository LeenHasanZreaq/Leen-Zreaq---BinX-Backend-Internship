using System;

namespace Trial
{
    class TryAndCatch
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to divide 100 by:");
            string input = Console.ReadLine();

            try
            {
                int div = int.Parse(input);
                int res = 100 / div;

                Console.WriteLine($"Result : {res}");
            }

            catch (DivideByZeroException)
            {
                Console.WriteLine("You can't divide by zero.");
            }

            catch (FormatException)
            {
                Console.WriteLine("That wasn't a valid number.");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }

            finally
            {
                Console.WriteLine("Program finished attempting the calculation.");
            }


        }
    }
}