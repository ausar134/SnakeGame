using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Program
    {
        private static Random Random = new Random(100);


        private const int MaxHeight = 30;
        private const int MaxWidth = 119;

        private const int StartingX = 60;
        private const int StartingY = 15;
       
        private static int xPos;
        private static int yPos;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            SelfMovingSnake();
            
        }


        private static void SelfMovingSnake()
        {
            xPos = StartingX;
            yPos = StartingY;
            int foodX = Random.Next(2, MaxWidth - 2);
            int foodY = Random.Next(2, MaxHeight - 2);

            int snakeSegments = 1;
            Point[] snakeBody = new Point[]
            {
                new Point(xPos,yPos),
                new Point(0,0),
                new Point(0,0),
                new Point(0,0),
                new Point(0,0),
            };

            int xStep = 1;
            int yStep = 0;
            ConsoleKeyInfo key;

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(foodX, foodY);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("#");

                // Input Handling
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow when (xStep == 0):
                            xStep = -1;
                            yStep = 0;
                            break;
                        case ConsoleKey.RightArrow when (xStep == 0):
                            xStep = 1;
                            yStep = 0;
                            break;
                        case ConsoleKey.UpArrow when (yStep == 0):
                            xStep = 0;
                            yStep = -1;
                            break;
                        case ConsoleKey.DownArrow when (yStep == 0):
                            xStep = 0;
                            yStep = 1;
                            break;
                        default:
                            break;
                    }
                }

                xPos += xStep;
                yPos += yStep;

                if(xPos == foodX && yPos == foodY)
                {
                    foodX = Random.Next( 2 , MaxWidth -2);
                    foodY = Random.Next(2, MaxHeight - 2);
                }

                // Lose condition
                if (xPos >= MaxWidth || xPos <=0 || yPos >= MaxHeight || yPos <= 0 )
                {
                    Console.SetCursorPosition(55, 15);
                    Console.WriteLine("You lose... Press enter to restart.");
                    key = Console.ReadKey();
                    if (key.Key != ConsoleKey.Enter)
                    {
                        Console.WriteLine("bye!");
                        break;
                    }

                    xPos = StartingX;
                    yPos = StartingY;
                    xStep = 1;
                    yStep = 0;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("*");
                Thread.Sleep(50);
            }
        }

        private static void InitialAttempt()
        {
            int xPos = 60;
            int yPos = 15;

            int origWidth;
            int origHeight;
            bool isGamePlayable = true;

            Random random = new Random();
            var FoodX = random.Next(1, MaxWidth - 1);
            var FoodY = random.Next(1, MaxHeight - 1);


            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(origWidth, origHeight);
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(xPos, yPos);


            #region Game Loop Logic

            while (isGamePlayable)
            {

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
                    if (xPos == FoodX && yPos == FoodY)
                    {

                    }

                }
                #endregion

                #region Lose Condition and Restart

                if (xPos <= 0 || yPos <= 0 || xPos >= MaxWidth || yPos >= MaxHeight)
                {
                    isGamePlayable = false;
                    Console.SetCursorPosition(55, 15);
                    Console.WriteLine("You lose...");
                    Console.SetCursorPosition(48, 16);
                    Console.WriteLine("To try again press Enter...");
                    keyInfo = Console.ReadKey();
                    xPos = 60;
                    yPos = 15;
                    FoodX = random.Next(1, MaxWidth - 1);
                    FoodY = random.Next(1, MaxHeight - 1);

                    if (!isGamePlayable && keyInfo.Key != ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(55, 17);
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                    }
                }
                isGamePlayable = true;
                #endregion


                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("*");
                Console.SetCursorPosition(FoodX, FoodY);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("x");


                Thread.Sleep(100);
            }
            #endregion
        }
    }
}

#region More Advanced Way Of Handling Controls
//while (isGamePlayable)
//{
//    if (Console.KeyAvailable)
//    {
//        keyInfo = Console.ReadKey();
//        xPos = keyInfo.Key switch
//        {
//            _ when (xPos == 0 || xPos == MaxWidth) => - 1,
//            ConsoleKey.LeftArrow => xPos - 1,
//            ConsoleKey.RightArrow=> xPos + 1,
//            _ => xPos,
//        };
//        yPos = keyInfo.Key switch
//        {
//            _ when (yPos == 0 || yPos == MaxHeight) { - 1,
//            ConsoleKey.UpArrow} {yPos - 1,
//            ConsoleKey.DownArrow }{ yPos + 1,
//            _ => yPos,
//        };

//        if (xPos < 0 || yPos < 0)
//        {
//            Console.SetCursorPosition(1, 1);
//            Console.WriteLine("ΕΧΑΣΕΣ");
//            break;
//        }
//    }
#endregion














