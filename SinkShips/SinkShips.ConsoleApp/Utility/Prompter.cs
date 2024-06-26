using System;

namespace SinkShips.ConsoleApp.Utility
{
    public class Prompter
    {
        public ConsoleKeyInfo GetAlphabeticOrNumericKey(string text, bool isNumeric = false)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            bool isKeyConditionMet = false;

            while (!isKeyConditionMet)
            {
                isKeyConditionMet = isNumeric ? char.IsNumber(key.KeyChar) : char.IsLetter(key.KeyChar);
                if (isKeyConditionMet) break;

                Console.Write(text);
                key = Console.ReadKey();
                Console.WriteLine();
            }

            return key;
        }
    }
}