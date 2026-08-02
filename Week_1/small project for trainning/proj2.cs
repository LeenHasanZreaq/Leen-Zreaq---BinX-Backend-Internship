using System;

class Program
{
    static void Main(string[] args)
    {
        char[,] game = new char[3, 3];

        int row, column;
        bool gameOn = true;
        char winner = '\0';

        Console.WriteLine("  (0,0)  ,  (0,1)  ,  (0,2)  .");
        Console.WriteLine("  (1,0)  ,  (1,1)  ,  (1,2)  .");
        Console.WriteLine("  (2,0)  ,  (2,1)  ,  (2,2)  .");

        while (gameOn)
        {
            Console.WriteLine("Enter the row: ");
            row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the column: ");
            column = int.Parse(Console.ReadLine());

            if (row >= 0 && row < 3 && column >= 0 && column < 3)
            {
                if (game[row, column] == '\0')
                {
                    Console.WriteLine("Enter the Letter (X or O): ");
                    char letter = char.ToUpper(Console.ReadLine()[0]);
                    if (letter == 'X' || letter == 'O')
                    {
                        game[row, column] = letter;
                    }
                    else
                    {
                        Console.WriteLine("Invalid letter. Please enter X or O only.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("The site is booked. Try another site.");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Outside the limits of the game.");
                continue;
            }

            // Print the board
            Console.WriteLine("Current Board:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(game[i, j] == '\0' ? "." : game[i, j].ToString());
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            // Check for winner
            foreach (char player in new char[] { 'X', 'O' })
            {
                if (
                    (game[0, 0] == player && game[0, 1] == player && game[0, 2] == player) ||
                    (game[1, 0] == player && game[1, 1] == player && game[1, 2] == player) ||
                    (game[2, 0] == player && game[2, 1] == player && game[2, 2] == player) ||
                    (game[0, 0] == player && game[1, 0] == player && game[2, 0] == player) ||
                    (game[0, 1] == player && game[1, 1] == player && game[2, 1] == player) ||
                    (game[0, 2] == player && game[1, 2] == player && game[2, 2] == player) ||
                    (game[0, 0] == player && game[1, 1] == player && game[2, 2] == player) ||
                    (game[0, 2] == player && game[1, 1] == player && game[2, 0] == player)
                )
                {
                    winner = player;
                    gameOn = false;
                    break;
                }
            }

            // Check for full board
            // its O(n^2) , too much time in the future i can make it betten .
            bool full = true;
            for (int i = 0; i < 3 && full; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (game[i, j] == '\0')
                    {
                        full = false;
                        break;
                    }
                }
            }

            // Check for draw 
            if (full && winner == '\0')
            {
                Console.WriteLine("The game is a draw.");
                gameOn = false;
            }

            // Check for winner
            if (winner != '\0')
            {
                Console.WriteLine($"Player {winner} wins!");
            }
        }
    }
}