// kto legenda kto chempion
internal class Program
{
    public static int[,] array2048 = new int[4, 4];
    private static void Main()
    {
        var key = Console.ReadKey();

        if (key.Key == ConsoleKey.UpArrow)
        {
            //MoveToTop(array);
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            //MoveToTop(array);
        }
        else if (key.Key == ConsoleKey.LeftArrow)
        {
            //MoveToTop(array);
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


        //testMoveToRight();
    }

    private static void testMoveToRight()
    {
        //test1
        var array = new int[4, 4]
        {
            {0,0,4,4},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
        };

        var expArray = new int[4, 4]
            {
                {0,0,0,8},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };

        if (AreArraysEqual(expArray, MoveRight(array)))
            Console.WriteLine("test 1 ishlayapti");
        else
            Console.WriteLine("2 ishlamiyapti");


            //test2
            array = new int[4, 4]
        {
            {0,4,0,4},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
        };

        expArray = new int[4, 4]
            {
                {0,0,0,8},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };

        if (AreArraysEqual(expArray, MoveRight(array)))
            Console.WriteLine("test 2 ishlayapti");
        else
            Console.WriteLine("2 ishlamiyapti");


        //test3
        array = new int[4, 4]
        {
            {4,0,0,4},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
        };

        expArray = new int[4, 4]
            {
                {0,0,0,8},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };

        if (AreArraysEqual(expArray, MoveRight(array)))
            Console.WriteLine("test 3 ishlayapti");
        else
            Console.WriteLine("3 ishlamiyapti");


        //test4
        array = new int[4, 4]
        {
            {4,0,4,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
        };

        expArray = new int[4, 4]
            {
                {0,0,0,8},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };

        if (AreArraysEqual(expArray, MoveRight(array)))
            Console.WriteLine("test 4 ishlayapti");
        else
            Console.WriteLine("4 ishlamiyapti");

        //test5
        array = new int[4, 4]
        {
            {0,2,0,4},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
        };

        expArray = new int[4, 4]
            {
                {0,0,2,4},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };

        if (AreArraysEqual(expArray, MoveRight(array)))
            Console.WriteLine("test 5 ishlayapti");
        else
            Console.WriteLine("5 ishlamiyapti");
        
        //test6
        array = new int[4, 4]
        {
            {2,0,4,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
        };

        expArray = new int[4, 4]
            {
                {0,0,2,4},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };

        if (AreArraysEqual(expArray, MoveRight(array)))
            Console.WriteLine("test 6 ishlayapti");
        else
            Console.WriteLine("6 ishlamiyapti");
        
        
        //test7
        array = new int[4, 4]
        {
            {4,0,4,4},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
        };

        expArray = new int[4, 4]
            {
                {0,0,4,8},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };

        if (AreArraysEqual(expArray, MoveRight(array)))
            Console.WriteLine("test 7 ishlayapti");
        else
            Console.WriteLine("7 ishlamiyapti");
    }

    //yutdikmi yo'q
    public static void IsGameWon(int[,] array)
    {
        for(int i=0; i<array.GetLength(0); i++)
        {
            for(int j = 0; j< array.GetLength(1); i++)
            {
                if (array[i,j] == 2048)
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
                if (array[i, j] == array[i + 1,j] || array[i,j] == array[i,j + 1])
                {
                    return false;
                }
            }
        }
        
        for (int j = 0; j < array.GetLength(1) -1; j++)
        {
            if (array[3,j] == array[3,j+1])
            {
                return false;
            }
        }
        
        for (int i = 0; i < array.GetLength(0) -1; i++)
        {
            if (array[i,3] == array[i+1,3])
            {
                return false;
            }
        }

        return true;
    }

    public static int[,] MoveRight(int[,] array)
    {
        int size = 4; // Assuming a 4x4 array

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



    /*    public static int[,] MoveRight(int[,] board)
        {
            for (int row = 0; row < 4; row++)
            {
                List<int> values = new List<int>();
                for (int col = 3; col >= 0; col--)
                {
                    if (board[row, col] != 0)
                    {
                        values.Add(board[row, col]);
                    }
                }

                for (int i = 0; i < values.Count - 1; i++)
                {
                    if (values[i] == values[i + 1])
                    {
                        values[i] *= 2;
                        values[i + 1] = 0;
                    }
                }

                values.RemoveAll(val => val == 0);

                for (int col = 3; col >= 0; col--)
                {
                    if (3 - col < values.Count)
                    {
                        board[row, col] = values[values.Count - 1 - (3 - col)];
                    }
                    else
                    {
                        board[row, col] = 0;
                    }
                }
            }

            return board;
        }
    */

    public static int RandomNumber()
    {
        Random random = new Random();
        int rand = random.Next(0,100);

        if(rand < 90)
            return 2;
        else
            return 4;
    }

    public static void Print2048(int[,] array2048)
    {
        Console.Clear();
        Console.WriteLine(
            $"     |     |     |     \n"+
            $"  {array2048[0,0]}  |  {array2048[0, 1]}  |  {array2048[0, 2]}  |  {array2048[0, 3]}  \n"+
            $"     |     |     |     \n"+
            $"-----------------------\n"+
            $"     |     |     |     \n"+
            $"  {array2048[1, 0]}  |  {array2048[1, 1]}  |  {array2048[1, 2]}  |  {array2048[1, 3]}  \n" +
            $"     |     |     |     \n"+
            $"-----------------------\n"+
            $"     |     |     |     \n"+
            $"  {array2048[2, 0]}  |  {array2048[2, 1]}  |  {array2048[2, 2]}  |  {array2048[2, 3]}  \n" +
            $"     |     |     |     \n"+
            $"-----------------------\n"+
            $"     |     |     |     \n"+
            $"  {array2048[3, 0]}  |  {array2048[3, 1]}  |  {array2048[3, 2]}  |  {array2048[3, 3]}  \n" +
            $"     |     |     |     \n"
            );
    }

    public static Tuple<int,int> RandomTile(int[,] array)
    {
        var tiles = new List<Tuple<int,int>>();
        
        for(int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i,j] == 0)
                {
                    Tuple<int,int> tuple = new Tuple<int,int>(i, j);
                    tiles.Add(tuple);
                }
            }
        }

        Random random = new Random();
        var rand = random.Next(0,tiles.Count);

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