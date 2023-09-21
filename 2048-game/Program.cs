namespace _2048_game;
internal class Program
{
    public static int[,] array2048 = new int[4, 4];
    private static void Main()
    {
        var key = Console.ReadKey();

        if (key.Key == ConsoleKey.UpArrow)
        {
            array2048 = MoveTop(array2048);
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            array2048 = MoveDown(array2048);
        }
        else if (key.Key == ConsoleKey.LeftArrow)
        {
            array2048 = MoveLeft(array2048);
        }
        else if (key.Key == ConsoleKey.RightArrow)
        {
            array2048 = MoveRight(array2048);
        }
        else
        {
            //Nothing
        }

        var index = RandomTile(array2048);
        array2048[index.Item1, index.Item2] = RandomNumber();

        Print2048(array2048);

        Main();
    }

    //yutdikmi yo'q
    public static void IsGameWon(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); i++)
            {
                if (array[i, j] == 2048)
                {
                    Console.WriteLine("Yutdingiz brat");
                    return;
                }
            }
        }
    }

    //tugadimi
    public static bool IsGameOver(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); i++)
            {
                if (array[i, j] == 0)
                {
                    return false;
                }
            }
        }

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); i++)
            {
                if (array[i, j] == array[i + 1, j] || array[i, j] == array[i, j + 1])
                {
                    return false;
                }
            }
        }

        for (int j = 0; j < array.GetLength(1) - 1; j++)
        {
            if (array[3, j] == array[3, j + 1])
            {
                return false;
            }
        }

        for (int i = 0; i < array.GetLength(0) - 1; i++)
        {
            if (array[i, 3] == array[i + 1, 3])
            {
                return false;
            }
        }

        return true;
    }

    public static int[,] MoveLeft(int[,] array)
    {
        int size = array.GetLength(0);

        for (int row = 0; row < size; row++)
        {
            int pointer = 0;

            for (int col = 1; col < size; col++)
            {
                if (array[row, col] != 0)
                {
                    int currentTile = array[row, col];
                    int nextTile = array[row, col - 1];

                    if (nextTile == 0 || nextTile == currentTile)
                    {
                        if (array[row, pointer] == currentTile)
                        {
                            array[row, pointer] *= 2;
                            array[row, col] = 0;
                        }
                        else
                        {
                            if (array[row, pointer] == 0)
                            {
                                array[row, pointer] = currentTile;
                                array[row, col] = 0;
                            }
                            else
                            {
                                array[row, ++pointer] = currentTile;
                                array[row, col] = 0;
                            }
                        }
                    }
                    else
                    {
                        pointer++;
                    }
                }
            }
        }

        return array;
    }

    public static int[,] MoveRight(int[,] array)
    {
        int size = 4;

        for (int row = 0; row < size; row++)
        {
            int pointer = size - 1;

            for (int col = size - 2; col >= 0; col--)
            {
                if (array[row, col] != 0)
                {
                    int currentTile = array[row, col];
                    int nextTile = array[row, col + 1];

                    if (nextTile == 0 || nextTile == currentTile)
                    {
                        if (array[row, pointer] == currentTile)
                        {
                            array[row, pointer] *= 2;
                            array[row, col] = 0;
                        }
                        else
                        {
                            if (array[row, pointer] == 0)
                            {
                                array[row, pointer] = currentTile;
                                array[row, col] = 0;
                            }
                            else
                            {
                                array[row, --pointer] = currentTile;
                                array[row, col] = 0;
                            }
                        }
                    }
                    else
                    {
                        pointer--;
                    }
                }
            }
        }

        return array;
    }

    public static int[,] MoveTop(int[,] array)
    {
        int size = array.GetLength(0);

        for (int col = 0; col < size; col++)
        {
            int pointer = 0;

            for (int row = 1; row < size; row++)
            {
                if (array[row, col] != 0)
                {
                    int currentTile = array[row, col];
                    int nextTile = array[row - 1, col];

                    if (nextTile == 0 || nextTile == currentTile)
                    {
                        if (array[pointer, col] == currentTile)
                        {
                            array[pointer, col] *= 2;
                            array[row, col] = 0;
                        }
                        else
                        {
                            if (array[pointer, col] == 0)
                            {
                                array[pointer, col] = currentTile;
                                array[row, col] = 0;
                            }
                            else
                            {
                                array[++pointer, col] = currentTile;
                                array[row, col] = 0;
                            }
                        }
                    }
                    else
                    {
                        pointer++;
                    }
                }
            }
        }

        return array;
    }

    public static int[,] MoveDown(int[,] array)
    {
        int size = array.GetLength(0);

        for (int col = 0; col < size; col++)
        {
            int pointer = size - 1;

            for (int row = size - 2; row >= 0; row--)
            {
                if (array[row, col] != 0)
                {
                    int currentTile = array[row, col];
                    int nextTile = array[row + 1, col];

                    if (nextTile == 0 || nextTile == currentTile)
                    {
                        if (array[pointer, col] == currentTile)
                        {
                            array[pointer, col] *= 2;
                            array[row, col] = 0;
                        }
                        else
                        {
                            if (array[pointer, col] == 0)
                            {
                                array[pointer, col] = currentTile;
                                array[row, col] = 0;
                            }
                            else
                            {
                                array[--pointer, col] = currentTile;
                                array[row, col] = 0;
                            }
                        }
                    }
                    else
                    {
                        pointer--;
                    }
                }
            }
        }

        return array;
    }

    public static int RandomNumber()
    {
        Random random = new Random();
        int rand = random.Next(0, 100);

        if (rand < 90)
            return 2;
        else
            return 4;
    }

    public static void Print2048(int[,] array2048)
    {
        Console.Clear();
        Console.WriteLine(
            $"     |     |     |     \n" +
            $"  {array2048[0, 0]}  |  {array2048[0, 1]}  |  {array2048[0, 2]}  |  {array2048[0, 3]}  \n" +
            $"     |     |     |     \n" +
            $"-----------------------\n" +
            $"     |     |     |     \n" +
            $"  {array2048[1, 0]}  |  {array2048[1, 1]}  |  {array2048[1, 2]}  |  {array2048[1, 3]}  \n" +
            $"     |     |     |     \n" +
            $"-----------------------\n" +
            $"     |     |     |     \n" +
            $"  {array2048[2, 0]}  |  {array2048[2, 1]}  |  {array2048[2, 2]}  |  {array2048[2, 3]}  \n" +
            $"     |     |     |     \n" +
            $"-----------------------\n" +
            $"     |     |     |     \n" +
            $"  {array2048[3, 0]}  |  {array2048[3, 1]}  |  {array2048[3, 2]}  |  {array2048[3, 3]}  \n" +
            $"     |     |     |     \n"
            );
    }

    public static Tuple<int, int> RandomTile(int[,] array)
    {
        var tiles = new List<Tuple<int, int>>();

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] == 0)
                {
                    Tuple<int, int> tuple = new Tuple<int, int>(i, j);
                    tiles.Add(tuple);
                }
            }
        }

        Random random = new Random();
        var rand = random.Next(0, tiles.Count);

        return tiles[rand];
    }

    static bool AreArraysEqual(int[,] arr1, int[,] arr2)
    {
        if (arr1.GetLength(0) != arr2.GetLength(0) || arr1.GetLength(1) != arr2.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i < arr1.GetLength(0); i++)
        {
            for (int j = 0; j < arr1.GetLength(1); j++)
            {
                if (arr1[i, j] != arr2[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}