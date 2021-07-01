using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!\n" +
               "Press ENTER to continue....");
            Console.ReadKey();

            int lives = 6;
            int points = 0;

            string[] listWords = new string[4];
            listWords[0] = "house";
            listWords[1] = "found";
            listWords[2] = "stack";
            listWords[3] = "place";

            Random randGen = new Random();
            var index = randGen.Next(0, 4);

            char[] array = listWords[index].ToCharArray();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Guess a letter: ");
                char guessedLetter;
                string userInput = Console.ReadLine();
                while (!Char.TryParse(userInput, out guessedLetter) || !char.IsLetter(guessedLetter))
                {
                    Console.WriteLine("You can only enter ONE letter.");
                    userInput = Console.ReadLine();
                }

                if (array.Contains(guessedLetter))
                {
                    Console.WriteLine("That is correct!");
                    points += 1;
                }
                else
                {
                    Console.WriteLine("Try again.");
                    lives -= 1;
                }

                Console.WriteLine($"Total Lives:{lives}");

                if (points == 5)
                {
                    Console.WriteLine($"YOU WON! The word was: {listWords[index]}");
                    keepRunning = false;
                }


                if (lives == 0)
                {
                    Console.WriteLine("HANGMAN! Better luck next time.");
                    keepRunning = false;
                }


            }

            Console.ReadLine();
        }
    }
}
