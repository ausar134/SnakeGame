﻿using System;
using System.Collections.Generic;

namespace Snake
{
    public class Program
    {
        

        static void Main(string[] args)

        {
            string myName = "Aggelos";
            string mySurname = "Theofanous";
            int myAge = 23;

            string playersName = "";
            int playersAge;


            //Create a variable and add 1 more until the total is equal to 10...
            //int number = 0;
            //do
            //{
            //    Console.WriteLine("Hello, my name is " + myName + " " + mySurname + " and I am " + myAge + " years old");
            //    number++;
            //} while (number < 10);

            //Create a count that is equal to 0 and add 1 more until count reaches 10, the print my name...
            for (int count = 0; count < 10; count++)
            {
                Console.WriteLine(myName);
            }
            Console.ReadLine();

            Console.WriteLine("What is your name?");
            playersName = Console.ReadLine();
            Console.WriteLine("Hello " + playersName + "! ");
            Console.WriteLine("What is your age " + playersName);
            playersAge = Console.Read();
            Console.WriteLine("So just to make sure, your name is " + playersName + " and you are " + playersAge);

        }
    }
}
