using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Program
    {

        private const int MaxHeight = 30;
        private const int MaxWidth = 119;

        static void Main(string[] args)
        {
            int xPos = 60;
            int yPos = 15;
            //int numberX = 0;
            //int numberY = 0;

            int origWidth;
            int origHeight;
            bool isGamePlayable = true;
            Random randomFood = new Random();

            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;

            ConsoleKeyInfo keyInfo = Console.ReadKey(); 

            Console.SetWindowSize(origWidth, origHeight);
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(xPos, yPos);

            while (isGamePlayable)
            {
                Console.Clear();
                


                //xPos += numberX;
                //yPos += numberY;

                #region Keyboard Controls and Window Boundary Check
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow when (yPos != 0):
                            yPos -= 1;
                            break;
                        case ConsoleKey.DownArrow when (yPos != MaxHeight):
                            yPos += 1;
                            break;
                        case ConsoleKey.RightArrow when (xPos != MaxWidth):
                            xPos += 1;
                            break;
                        case ConsoleKey.LeftArrow when (xPos != 0):
                            xPos -= 1;
                            break;
                        default:
                            break;
                    }
                }
                #endregion


                Console.SetCursorPosition(xPos, yPos);
                Console.Write("*");
                Thread.Sleep(50);
            }
        }
    }
}













