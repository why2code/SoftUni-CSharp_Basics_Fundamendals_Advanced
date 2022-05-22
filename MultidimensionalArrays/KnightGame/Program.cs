using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            char[,] board = new char[boardSize, boardSize];

            for (int row = 0; row < boardSize; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = input[col];
                }
            }

            int removedKnights = 0;
            while (true)
            {
                int maxAttack = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (board[row, col] == '0')
                        {
                            continue;
                        }

                        int currentAttack = 0;

                        //topLeft, topRight
                        if (IsInRange(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                        {
                            currentAttack++;
                        }

                        if (IsInRange(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                        {
                            currentAttack++;
                        }
                        //botLeft, botRight
                        if (IsInRange(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                        {
                            currentAttack++;
                        }

                        if (IsInRange(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                        {
                            currentAttack++;
                        }
                        //LeftTop, LeftBot
                        if (IsInRange(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                        {
                            currentAttack++;
                        }

                        if (IsInRange(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                        {
                            currentAttack++;
                        }
                        //rightTop, rightBot
                        if (IsInRange(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                        {
                            currentAttack++;
                        }

                        if (IsInRange(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                        {
                            currentAttack++;
                        }

                        if (currentAttack > maxAttack)
                        {
                            maxAttack = currentAttack;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttack > 0)
                {
                    removedKnights++;
                    board[knightRow, knightCol] = '0';
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}