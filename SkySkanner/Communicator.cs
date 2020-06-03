using System;
using System.Collections.Generic;
using System.Text;

namespace SkySkanner
{
    public class Communicator //: ICommunicator
    {
        public string AskUserForString(string stringName)
        {
            Console.WriteLine($"Podaj nazwę dla {stringName}");
            return Console.ReadLine();
        }
        public double AskUserForDouble(string doubleValueName)
        {
            double userInput = 0;
            bool isInputdouble = false;
            while (isInputdouble == false)
            {
                Console.WriteLine($"Podaj wartość dla {doubleValueName}");
                isInputdouble = double.TryParse(Console.ReadLine(), out userInput);

                if (userInput < 0)
                {//dla tej aplikacji tylko liczby dodatnie
                    isInputdouble = false;
                }

                if (isInputdouble == false)
                {
                    PrintWrongInputMessage();
                }
            }
            return userInput;
        }
        public int AskUserForInt(string intValueName)
        {
            int userInput = 0;
            bool isInputInt = false;
            while (isInputInt == false)
            {
                Console.WriteLine($"Podaj wartość dla {intValueName}");
                isInputInt = int.TryParse(Console.ReadLine(), out userInput);

                if (userInput < 0)
                {//dla tej aplikacji tylko liczby dodatnie
                    isInputInt = false;
                }

                if (isInputInt == false)
                {
                    PrintWrongInputMessage();
                }
            }
            return userInput;
        }

        public void PrintWrongInputMessage()
        {
            Console.WriteLine("Nieprawidłowa wartość");
        }
    }
}
