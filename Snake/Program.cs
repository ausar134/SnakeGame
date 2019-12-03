using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Snake
{
    public class Program
    {
        private static Random Random = new Random();

        private const string TopLeftCorner = "╔";

        private const int MaxHeight = 30;
        private const int MaxWidth = 119;

        private const int BorderSize = 4;

        private const int StartingX = 60;
        private const int StartingY = 15;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            DrawBorders();
            SelfMovingSnake();
            //#if (Debug)
            //Console.ReadLine();
            //#endif
        }

        static void InitGame()
        {
            
        }

        static void DrawBorders()
        {
            var color = Console.ForegroundColor;
            var x = Console.CursorTop;
            var y = Console.CursorLeft;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = BorderSize; i <= MaxHeight - BorderSize; i++)
            {
                Console.SetCursorPosition(BorderSize, i);
                Console.Write("║");
                Console.SetCursorPosition(MaxWidth - BorderSize, i);
                Console.Write("║");
            }

            for (int j = BorderSize; j <= MaxWidth - BorderSize; j++)
            {
                Console.SetCursorPosition(j, BorderSize);
                Console.Write("═");
                Console.SetCursorPosition(j, MaxHeight - BorderSize);
                Console.Write("═");
            }

            Console.SetCursorPosition(BorderSize, BorderSize);
            Console.Write(TopLeftCorner);

            Console.SetCursorPosition(MaxWidth - BorderSize, BorderSize);
            Console.Write("╗");

            Console.SetCursorPosition(BorderSize, MaxHeight - BorderSize);
            Console.Write("╚");

            Console.SetCursorPosition(MaxWidth - BorderSize, MaxHeight - BorderSize);
            Console.Write("╝");
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
        }

        #region Game Logic 
        private static void SelfMovingSnake()
        {
            int BorderHeight = MaxHeight-BorderSize;
            int BorderWidth = MaxWidth-BorderSize;
            
            int lifePosX = BorderSize - 3;
            int lifePosY = BorderSize - 3;
            int startingLives = 5;

            Console.SetCursorPosition(lifePosX, lifePosY);
            Console.Write("Remaining Lives : " + startingLives);

            int foodScoreX = MaxWidth - 12;
            int foodScoreY = MaxHeight - 29;
            int foodScore = 0;
            int resetSpeed = 500;

            Console.SetCursorPosition(foodScoreX, foodScoreY);
            Console.Write("Score : " + foodScore);

            int foodX = Random.Next(BorderSize + 2, BorderWidth-2);
            int foodY = Random.Next(BorderSize + 2, BorderHeight-2);

            int snakeSegments = 1;
            int snakeSpeed = 500;

            Point[] snakeBody = new Point[60];

            snakeBody[0] = new Point(StartingX, StartingY);

            for (int i = 1; i < snakeBody.Length; i++)
            {
                snakeBody[i] = new Point(0, 0);
            }

            Console.SetCursorPosition(foodX, foodY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("*");
            bool collision = false;
            int xStep = 0;
            int yStep = 0;
            ConsoleKeyInfo key;

            //Loop to play game...
            while (true)
            {
                //Input Handling and Snake Controls...
                if (Console.KeyAvailable)
                {
                    //Has to be true to stop printing
                    key = Console.ReadKey(true);

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

                Console.SetCursorPosition(snakeBody[snakeSegments - 1].X, snakeBody[snakeSegments - 1].Y);
                Console.Write(" ");

                //Enables snake movement and the body follows the same movement...
                for (int i = snakeSegments - 1; 0 < i; i--)
                {
                    snakeBody[i].X = snakeBody[i - 1].X;
                    snakeBody[i].Y = snakeBody[i - 1].Y;
                }

                snakeBody[0].X += xStep;
                snakeBody[0].Y += yStep;

                Console.SetCursorPosition(snakeBody[0].X, snakeBody[0].Y);
                Console.Write("#");

                //Add food to snake body and spawn new food...
                if (snakeBody[0].X == foodX && snakeBody[0].Y == foodY && snakeSegments < snakeBody.Length)
                {
                    bool isFoodUncollided = false;
                    do
                    {
                        foodX = Random.Next(BorderSize + 2, BorderWidth - 2);
                        foodY = Random.Next(BorderSize + 2, BorderHeight - 2);
                        for (int i = 0; i < snakeSegments; i++)
                        {
                            isFoodUncollided = isFoodUncollided
                         || (snakeBody[i].X == foodX && snakeBody[i].Y == foodY);
                        }
                    }
                    while (isFoodUncollided);
                    if (snakeSpeed > 40)
                    {
                        snakeSpeed /= 2;
                    }

                    foodScore += 1;
                    Console.SetCursorPosition(foodScoreX, foodScoreY);
                    Console.Write("Score : " + foodScore);
                    
                    Console.SetCursorPosition(foodX, foodY);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");
                    Console.Beep(800, 10);
                    snakeSegments++;
                }

                //Win Condition...
                if (snakeSegments == snakeBody.Length - 1)
                {

                    Console.SetCursorPosition(StartingX - 15, StartingY);
                    Console.WriteLine("Congratulations!!");
                    Console.SetCursorPosition(StartingX - 25, StartingY + 1);
                    Console.WriteLine("You cleared the first level!");
                    Console.SetCursorPosition(StartingX - 30, StartingY + 2);
                    Console.WriteLine("The game will now quit..");
                    Console.ReadLine();
                    Console.Clear();

#region Border Draw
                    for (int i = BorderSize; i <= MaxHeight - BorderSize; i++)
                    {
                        Console.SetCursorPosition(BorderSize, i);
                        Console.Write("║");
                        Console.SetCursorPosition(MaxWidth - BorderSize, i);
                        Console.Write("║");
                    }

                    for (int j = BorderSize; j <= MaxWidth - BorderSize; j++)
                    {
                        Console.SetCursorPosition(j, BorderSize);
                        Console.Write("═");
                        Console.SetCursorPosition(j, MaxHeight - BorderSize);
                        Console.Write("═");
                    }

                    Console.SetCursorPosition(BorderSize, BorderSize);
                    Console.Write("╔");

                    Console.SetCursorPosition(MaxWidth - BorderSize, BorderSize);
                    Console.Write("╗");

                    Console.SetCursorPosition(BorderSize, MaxHeight - BorderSize);
                    Console.Write("╚");

                    Console.SetCursorPosition(MaxWidth - BorderSize, MaxHeight - BorderSize);
                    Console.Write("╝");
#endregion

                    foodX = Random.Next(BorderSize + 2, BorderWidth - 2);
                    foodY = Random.Next(BorderSize + 2, BorderHeight - 2);

                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(StartingX, StartingY);
                        Console.WriteLine("Bye!");
                        break;
                    }

                    for (int i = 0; i < snakeBody.Length; i++)
                    {
                        snakeBody[i].X = 0;
                        snakeBody[i].Y = 0;
                    }

                    foodScore = 0;
                    snakeSegments = 1;
                    snakeBody[0].X = StartingX;
                    snakeBody[0].Y = StartingY;
                    collision = false;
                    xStep = 1;
                    yStep = 0;

                }

                //Check for collision with snakebody...
                for (int i = 2; i < snakeBody.Length; i++)
                {
                    collision = snakeBody[0].X == snakeBody[i].X
                        && snakeBody[0].Y == snakeBody[i].Y;

                    if (collision)
                    {
                        break;
                    }
                }

                //Lose condition...
                if (collision || snakeBody[0].X >= BorderWidth || snakeBody[0].X <= BorderSize 
                    || snakeBody[0].Y >= BorderHeight || snakeBody[0].Y <= BorderSize || startingLives==0)
                {

                    foodX = Random.Next(BorderSize + 2, BorderWidth - 2);
                    foodY = Random.Next(BorderSize + 2, BorderHeight - 2);
                    Console.SetCursorPosition(StartingX - 15, StartingY);
                    Console.WriteLine("You lost.. Press enter to quit.");
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(StartingX, StartingY);
                        Console.WriteLine("Bye!");
                        break;
                    }

                    for (int i = 0; i < snakeBody.Length; i++)
                    {
                        snakeBody[i].X = 0;
                        snakeBody[i].Y = 0;
                    }

                    for (int j = startingLives; j <= 5; ) 
                    {
                            startingLives -= 1;
                            Console.SetCursorPosition(lifePosX, lifePosY);
                            Console.Write("Remaining Lives : " + startingLives);
                            break;
                    }

                    //Restart and Redraw...
                    if (key.Key != ConsoleKey.Enter)
                    {
                        Console.Clear();
                        snakeSpeed = resetSpeed;

                        Console.SetCursorPosition(foodScoreX, foodScoreY);
                        Console.Write("Score : " + foodScore);
                        Console.SetCursorPosition(lifePosX, lifePosY);
                        Console.Write("Remaining Lives : " + startingLives);
                        Console.ForegroundColor = ConsoleColor.Green;
                        foodX = Random.Next(BorderSize + 2, BorderWidth - 2);
                        foodY = Random.Next(BorderSize + 2, BorderHeight - 2);
                        Console.SetCursorPosition(foodX, foodY);
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.White;

#region Border Draw
                        for (int i = BorderSize; i <= MaxHeight - BorderSize; i++)
                        {
                            Console.SetCursorPosition(BorderSize, i);
                            Console.Write("║");
                            Console.SetCursorPosition(MaxWidth - BorderSize, i);
                            Console.Write("║");
                        }

                        for (int j = BorderSize; j <= MaxWidth - BorderSize; j++)
                        {
                            Console.SetCursorPosition(j, BorderSize);
                            Console.Write("═");
                            Console.SetCursorPosition(j, MaxHeight - BorderSize);
                            Console.Write("═");
                        }

                        Console.SetCursorPosition(BorderSize, BorderSize);
                        Console.Write("╔");

                        Console.SetCursorPosition(MaxWidth - BorderSize, BorderSize);
                        Console.Write("╗");

                        Console.SetCursorPosition(BorderSize, MaxHeight - BorderSize);
                        Console.Write("╚");

                        Console.SetCursorPosition(MaxWidth - BorderSize, MaxHeight - BorderSize);
                        Console.Write("╝");
#endregion
                    }

                    if (startingLives == 0)
                    {
                        Console.SetCursorPosition(StartingX - 20, StartingY);
                        Console.Write("Too bad.. You don't have any lives left..");
                        Console.SetCursorPosition(StartingX - 20, StartingY + 1);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("The game will quit unless you press the Enter key..");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    snakeSegments = 1;
                    snakeBody[0].X = StartingX;
                    snakeBody[0].Y = StartingY;
                    collision = false;
                    xStep = 1;
                    yStep = 0;
                }

                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(snakeSpeed/2);
            }
        }
#endregion

       
    }
}














