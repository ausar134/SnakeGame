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
            int xPos = 0;
            int yPos = 0;
            int numberX = 1;
            int numberY = 1;

            

            int origWidth;
            int origHeight;
            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;
      
            Console.SetWindowSize(origWidth, origHeight);
            Console.CursorVisible = false;
            Console.Clear();



            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(xPos, yPos);

               
                xPos += numberX;
                yPos += numberY;

                if (xPos >= origWidth-1 || xPos == 0)
                {
                    numberX = numberX * (-1);
                    //xAsc = !xAsc;
                }
                if (yPos >= origHeight || yPos ==0)
                {
                    numberY = numberY * (-1);
                  //  yAsc = !yAsc;
                }

                Console.Write("*");
                Thread.Sleep(50);
            }
        }
    }
}













