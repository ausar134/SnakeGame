using System;
using System.Collections.Generic;

namespace Snake
{
    public class Program
    {


        static void Main(string[] args)

        {
            string myName = "Aggelos";
            string pointString = "";
            bool increasingNumber = true;
            int pointNumber = 0;

            //Cycle through 20 times... 
            //We start from 0-19 it's used for increase and decrease...
            for (int i = 0; i < 19; i++)
            {
                //When it completes 9 cycles...
                //Increase changes to false because of the trigger below...
                if (increasingNumber)
                {
                    pointNumber += 1;
                }
                else
                {
                    pointNumber -= 1;
                }
                //Trigger to change from increase to decrease...
                if (i == 9)
                {
                    increasingNumber = false;
                }

                //Reset the string each time...
                pointString = "";

                //Re-create and add the "!" N times
                //depending on the value of pointNumber...
                for (int j = 0; j < pointNumber; j++)
                {
                    pointString += "!";
                }
                Console.WriteLine(myName + pointString);
                
            }
            Console.ReadLine();

        }
    } 
}

