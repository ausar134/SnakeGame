using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            int xPos = 60;
            int yPos = 15;
            //int numberX = 0;
            //int numberY = 0;

            int origWidth;
            int origHeight;

            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;

            ConsoleKeyInfo keyInfo = Console.ReadKey(); 

            Console.SetWindowSize(origWidth, origHeight);
            Console.CursorVisible = false;
            Console.Clear();
            


            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(xPos, yPos);

               
                //xPos += numberX;
                //yPos += numberY;

                #region Keyboard Controls and Boundary check

                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow && yPos !=0)
                    {
                        yPos -= 1;

                        if(keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            return;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.LeftArrow && xPos !=0)
                    {
                        xPos -= 1;


                       if(keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            return;
                        }
                    }
                    
                        if (keyInfo.Key == ConsoleKey.RightArrow && xPos !=119)
                        {
                        xPos += 1;
                           
                          if(keyInfo.Key == ConsoleKey.LeftArrow)
                        { return; }
                            
                        }
                    if(keyInfo.Key == ConsoleKey.DownArrow && yPos !=30)
                    {
                        yPos += 1;

                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        { return; }
                    }
                }
                #endregion 


                //if (xPos >= origWidth-1 || xPos == 0)
                //{
                //    numberX = numberX * (-1);
                //    //xAsc = !xAsc;
                //}
                //if (yPos >= origHeight || yPos ==0)
                //{
                //    numberY = numberY * (-1);
                //  //  yAsc = !yAsc;
                //}
                
                Console.Write("*");
                Thread.Sleep(50);
            }
        }
    }
}













