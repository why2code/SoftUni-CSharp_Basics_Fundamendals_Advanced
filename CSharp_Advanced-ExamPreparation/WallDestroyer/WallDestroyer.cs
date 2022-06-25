using System;

namespace WallDestroyer
{
    internal class WallDestroyer
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            FillDataIntoMatrix(matrix, n, n);
            int holesCount = 0;
            int rodsCount = 0;
            bool isElectrified = false;

            int[] initialStartingPosition = FindStartingPosition(matrix);
            int initialStartRow = initialStartingPosition[0];
            int initialStartCol = initialStartingPosition[1];

            //initial position considered successful hole made
            matrix[initialStartRow, initialStartCol] = '*';
            holesCount++;

            string command = Console.ReadLine();
            while (command != "End" && isElectrified == false)
            {
                
                int[] newPositionsAfterMoveAttempt = VankoDigsHole(matrix, initialStartRow, initialStartCol, command);
                initialStartRow = newPositionsAfterMoveAttempt[0];
                initialStartCol = newPositionsAfterMoveAttempt[1];

                //Reading new command and marking his last position with V if the command is End (as there will be no more moves)
                command = Console.ReadLine();
                if (command == "End")
                {
                    matrix[initialStartRow, initialStartCol] = 'V';
                }
            }

            //Final printout
            if (command == "End")
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsCount} rod(s).");
            }
            if (isElectrified == true)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }


            int[] VankoDigsHole(char[,] matrix, int startRow, int startCol, string direction)
            {
                //memorizing initial positions and then checking the command
                int[] outputIndexes = new int[2];
                int oldRow = startRow;
                int oldCol = startCol;

                if (direction == "up")
                {
                    startRow -= 1;
                }
                else if (direction == "down")
                {
                    startRow += 1;
                }
                else if (direction == "left")
                {
                    startCol -= 1;
                }
                else if (direction == "right")
                {
                    startCol += 1;
                }

                if (startRow >= 0 && startRow < matrix.GetLength(0)
                    && startCol >= 0 && startCol < matrix.GetLength(1))
                {
                    //Vanko can move within the matrix (new position indexes are valid)
                    if (matrix[startRow, startCol] == '-')
                    {
                        outputIndexes[0] = startRow;
                        outputIndexes[1] = startCol;
                        matrix[startRow, startCol] = '*';
                        holesCount++;
                    }
                    else if (matrix[startRow, startCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        outputIndexes[0] = oldRow;
                        outputIndexes[1] = oldCol;
                        rodsCount++;
                    }
                    else if (matrix[startRow, startCol] == 'C')
                    {
                        isElectrified = true;
                        matrix[startRow, startCol] = 'E';
                        outputIndexes[0] = startRow;
                        outputIndexes[1] = startCol;
                        holesCount++;
                    }
                    else if (matrix[startRow, startCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                        outputIndexes[0] = startRow;
                        outputIndexes[1] = startCol;
                    }
                }
                else
                {
                    //Vanko tries to move into invalid index, therefore does not move 
                    outputIndexes[0] = oldRow;
                    outputIndexes[1] = oldCol;
                }
                return outputIndexes;
            }
        }


        private static void FillDataIntoMatrix(char[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }

            }
        }

        public static int[] FindStartingPosition(char[,] matrix)
        {
            int rowIndex = int.MinValue;
            int colIndex = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'V')
                    {
                        rowIndex = i;
                        colIndex = j;
                    }
                }
            }
            return new int[] { rowIndex, colIndex };
        }

    }

}
