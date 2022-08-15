using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{
    public int RandomizedBlocks()
    {
        int randomBlock = UnityEngine.Random.Range(0, 100);
        int randomBlockIndex = 0;

        if (Settings.instance.Difficulty == 1)
        {
            if (randomBlock <= 65)
            {
                randomBlockIndex = 0;
            }
            else if (randomBlock > 65 && randomBlock <= 85)
            {
                randomBlockIndex = 1;
            }
            else if (randomBlock > 85 && randomBlock <= 95)
            {
                randomBlockIndex = 2;
            }
            else if (randomBlock > 95)
            {
                randomBlockIndex = 3;
            }
        }

        if (Settings.instance.Difficulty == 2)
        {
            if (randomBlock <= 55)
            {
                randomBlockIndex = 0;
            }
            else if (randomBlock > 55 && randomBlock <= 75)
            {
                randomBlockIndex = 1;
            }
            else if (randomBlock > 75 && randomBlock <= 90)
            {
                randomBlockIndex = 2;
            }
            else if (randomBlock > 90)
            {
                randomBlockIndex = 3;
            }
        }

        if (Settings.instance.Difficulty == 3)
        {
            if (randomBlock <= 45)
            {
                randomBlockIndex = 0;
            }
            else if (randomBlock > 45 && randomBlock <= 65)
            {
                randomBlockIndex = 1;
            }
            else if (randomBlock > 65 && randomBlock <= 85)
            {
                randomBlockIndex = 2;
            }
            else if (randomBlock > 85)
            {
                randomBlockIndex = 3;
            }
        }

        return randomBlockIndex;
    }


    public void CheckerBoard(int[,] board)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (j % 2 == 0 && i % 2 != 0 || i % 2 == 0 && j % 2 != 0)
                {
                    board[i, j] = 1;
                }
            }
        }
    }
    public void Stack(int[,] board, int direction)
    {
        int k = 0;
        int l = 10;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (direction == 0)
                {
                    if (l <= j)
                    {
                        board[i, j] = 0;
                    }
                    else
                    {
                        board[i, j] = 1;
                    }
                }
                if (direction == 1)
                {
                    if (l - 1 > j)
                    {
                        board[i, j] = 0;
                    }
                    else
                    {
                        board[i, j] = 1;
                    }
                }
                if (direction == 2)
                {
                    if (k >= j)
                    {
                        board[i, j] = 1;
                    }
                    else
                    {
                        board[i, j] = 0;
                    }
                }
                if (direction == 3)
                {
                    if (k - 1 < j)
                    {
                        board[i, j] = 1;
                    }
                    else
                    {
                        board[i, j] = 0;
                    }
                }
            }
            l--;
            k++;
        }

    }

    public void Rectangle(int[,] board, int length, int height, int x, int y)
    {

        for (int i = 0; i < 10; i++)
        {

            for (int j = 0; j < 10; j++)
            {
                if ((i == x && j >= y && j < y + length - 1) || // horyzontalne sciany
                    (i == x + height - 1 && j >= y && j < y + length - 1))
                {
                    board[i, j] = 1;
                }

                if ((j == y && i >= x && i < x + height) ||  // wertyklane sciany
                    (j == y + length - 1 && i >= x && i < x + height))
                {
                    board[i, j] = 1;
                }

            }
        }

    }
    public void MultipleRectangles(int[,] board)
    {
        int amount = Random.Range(1, 4);

        for (int i = 0; i < amount; i++)
        {
            int x = 0;
            int y = 0;

            int lenght = 0;
            int height = 0;


            if (amount == 1)
            {
                x = Random.Range(0, 3);
                y = Random.Range(0, 3);
                height = Random.Range(7, 9);
                lenght = Random.Range(7, 9);
            }
            else if (amount == 2)
            {
                y = Random.Range(0, 2);
                height = Random.Range(3, 8);
                lenght = Random.Range(3, 5);

                if (i == 0)
                {
                    x = Random.Range(0, 2);          
                }
                else
                {
                    x = Random.Range(5, 7);     
                }
            }
            else if (amount == 3)
            {
                lenght = Random.Range(7, 9);
                x = Random.Range(0, 4);
                height = 3;

                if (i == 0)
                {
                    y = 7;
                    
                }
                else if (i == 1)
                {
                    y = 4;             
                }
                else if (i == 2)
                {      
                    y = 1;       
                }
               
            }

            if (height == 0)
            {
                break;
            }

            Rectangle(board, height, lenght, x, y);




        }
    }
}
