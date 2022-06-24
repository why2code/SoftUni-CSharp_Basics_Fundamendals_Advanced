using System;

namespace TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());

            //Creating and filling in the matrix
            char[][] matrix = new char[matrixSize][];
            FillDataIntoMatrix(matrix, matrixSize);

            //Finding where the Army (A) is
            int[] armyStartingIndexes = FindArmyPosition(matrix);
            int armyRowStartingIndex = armyStartingIndexes[0];
            int armyColStartingIndex = armyStartingIndexes[1];

            while (armor > 0)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                matrix[row][col] = 'O';
                armor -= 1;
                //Trying to move the Army based on the provided direction.
                //Returns same indexes (if not moved), or new indexes if the Army moved successfully.
                //Armor is reduced by 1 in both instances. If Army moved, old position is changed to '-'.
                int[] newIndexes = ArmyMovingIntoField(matrix, armyRowStartingIndex, armyColStartingIndex, direction);
                int newRowAfterSuccessfullMove = newIndexes[0]; //same as previously or new if moved
                int newColAfterSuccessfullMove = newIndexes[1]; //same as previously or new if moved

                //Verifying where Army lands after moving (if moved successfully)
                if (matrix[newRowAfterSuccessfullMove][newColAfterSuccessfullMove] == 'O')
                {
                    armor -= 2;
                    if (armor <= 0)
                    {
                        Console.WriteLine($"The army was defeated at {newRowAfterSuccessfullMove};{newColAfterSuccessfullMove}.");
                        matrix[newRowAfterSuccessfullMove][newColAfterSuccessfullMove] = 'X';
                        break;
                    }
                    else
                    {
                        matrix[newRowAfterSuccessfullMove][newColAfterSuccessfullMove] = 'A';
                    }
                }
                else if (matrix[newRowAfterSuccessfullMove][newColAfterSuccessfullMove] == 'M')
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    matrix[newRowAfterSuccessfullMove][newColAfterSuccessfullMove] = '-';
                    break;

                }
                else if (matrix[newRowAfterSuccessfullMove][newColAfterSuccessfullMove] == '-')
                {
                    if (armor <= 0)
                    {
                        Console.WriteLine($"The army was defeated at {newRowAfterSuccessfullMove};{newColAfterSuccessfullMove}.");
                        matrix[newRowAfterSuccessfullMove][newColAfterSuccessfullMove] = 'X';
                        break;
                    }
                    matrix[newRowAfterSuccessfullMove][newColAfterSuccessfullMove] = 'A';
                }

                armyRowStartingIndex = newRowAfterSuccessfullMove;
                armyColStartingIndex = newColAfterSuccessfullMove;

                //if (armor <= 0)
                //{
                //    Console.WriteLine($"The army was defeated at {newRowAfterSuccessfullMove};{newColAfterSuccessfullMove}.");
                //}
            }

            //Printing the matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }

            int[] ArmyMovingIntoField(char[][] matrix, int row, int col, string direction)
            {
                int[] outputIndexes = new int[2];
                int oldRow = row;
                int oldCol = col;
                if (direction == "up")
                {
                    row -= 1;
                }
                else if (direction == "down")
                {
                    row += 1;
                }
                else if (direction == "left")
                {
                    col -= 1;
                }
                else if (direction == "right")
                {
                    col += 1;
                }

                if (row >= 0 && row < matrix.GetLength(0)
                    && col >= 0 && col < matrix[row].Length)
                {
                    //The Army can move within the matrix (new position indexes are valid)
                    matrix[oldRow][oldCol] = '-';
                    outputIndexes[0] = row;
                    outputIndexes[1] = col;

                }
                else
                {
                    //The Army tries to move into invalid index, therefore does not move and only loses energy

                    outputIndexes[0] = oldRow;
                    outputIndexes[1] = oldCol;
                }
                return outputIndexes;
            }


        }

        public static int[] FindArmyPosition(char[][] matrix)
        {
            int rowIndex = int.MinValue;
            int colIndex = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'A')
                    {
                        rowIndex = i;
                        colIndex = j;
                    }
                }
            }
            return new int[] { rowIndex, colIndex };
        }

        public static void FillDataIntoMatrix(char[][] matrix, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();

            }
        }

    }
}

