using System;
using System.Collections.Generic;

namespace CSharp.LabExercise6
{
    internal class Program
    {
        class InputValidator
        {
            public bool IsValidInput(char[] convertedToChar)
            {
                foreach (char letter in convertedToChar)
                {
                    if (char.IsWhiteSpace(letter))
                    {
                        Console.WriteLine("Please enter a word without a space.");
                        return false;
                    }
                    if (!char.IsLetter(letter))
                    {
                        Console.WriteLine("Please enter a word without any number or special character");
                        return false;
                    }
                }
                return true;
            }

            public bool IsValidYesOrNo(string checkYesOrNo)
            {
                if (checkYesOrNo == null || (checkYesOrNo != "y" && checkYesOrNo != "n"))
                {
                    return false;
                }
                return true;
            }
        }

        class ScoreCounter
        {
            Dictionary<char, int> letterScoresDictionary = new Dictionary<char, int>()
            {
                {'A', 1 }, {'E', 1 }, {'I', 1 }, {'O', 1 }, {'U', 1 }, {'L', 1 }, {'N', 1 }, {'R', 1 }, {'S', 1 }, {'T', 1 },
                {'D', 2 }, {'G', 2 },
                {'B', 3 }, {'C', 3 }, {'M', 3 }, {'P', 3 },
                {'F', 4 }, {'H', 4 }, {'V', 4 }, {'W', 4 }, {'Y', 4 },
                {'K', 5 },
                {'J', 8 }, {'X', 8 },
                {'Q', 10 }, {'Z', 10 },
            };

            public int ScoreComputer(char[] convertedToChar)
            {

                int totalScore = 0;

                for (int index = 0; index < convertedToChar.Length; index++)
                {
                    if (letterScoresDictionary.TryGetValue(convertedToChar[index], out int letterScore))
                    {
                        totalScore += letterScore;
                    }
                }
                return totalScore;
            }
        }
        static void Main(string[] args)
        {

            InputValidator inputValidator = new InputValidator();
            ScoreCounter scoreCounter = new ScoreCounter();

            string toContinue = "y";

            do
            {
                System.Console.Write("Enter desired word: ");
                string desiredWord = Console.ReadLine();

                char[] convertedToChar = desiredWord.ToUpper().ToCharArray();

                if(!inputValidator.IsValidInput(convertedToChar))
                {
                    goto playAgain;
                }

                int totalScore = scoreCounter.ScoreComputer(convertedToChar) ;

                Console.WriteLine("Your score for the word {0} is: {1}", desiredWord, totalScore);


                playAgain:
                    Console.Write("Do you want to play again? (y/n)");
                    toContinue = Console.ReadLine().ToLower();

                if(!inputValidator.IsValidYesOrNo(toContinue))
                {
                    Console.WriteLine("Please enter 'y' or 'n' only {0}", toContinue);
                    goto playAgain;
                }

            } while (toContinue == "y");

        }
    }
}
