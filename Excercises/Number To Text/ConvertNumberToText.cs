using System.Text;

namespace Helpers.NumberToText
{
    /*
    Sloution explantion :
    helpers-> 

    1. three lookup tables with the strings that represent the number as a word
       1->20, 20->100 (in + 10 -> like 20-30-40).
    2. stack which holds the word represention.
    3.an array of digits.

    algoritem->

    1. we brake the number into an array of digits 
    2. we create a the stack which hold the result 
    3. we iterate in the array 
        if (we number is zero)
            push(emptyString)
        else if (is the third digit)
            push(digitName)
            push("Hundred")
        else if (is second digit)
            if (we connect this digit the digit before we will get 11 12 13 14 which is one word could only happend from 10 to 20)
                pop(lastDigitName)
                posh(newDigitName)
            else
                push(digitName which is 20->100 in 20-30-40)
        else first digit 
            push(digitName)
            push(numberMarker "Thousand" -> "Milloin" -> "Billion")
        end loop

        return join all result to one string;
        */
    public class ConvertNumberToText
    {
        private readonly static string[] _oneToTwenty =
        {
            "","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
            "Eighteen", "Nineteen",
        };

        private readonly static string[] _twentyToHundred =
        {
            "","","Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety",
        };

        private readonly static string[] _hundredToBillion =
        {
            " ","Hundred", "Thousand", "Milloin", "Billion", "Trillion"
        };

        public static string ToText(int number)
        {
            int[] numberAsArray = NumberToArray(number);
            Stack<string> orderWords = new();

            if (TryHandleSpecialCases(number, out string value))
            {
                return value;
            }

            for (int i = 0; i < numberAsArray.Length; ++i)
            {
                if (0 == numberAsArray[i])
                {
                    HandleZero(orderWords);
                }
                else if (IsThirdDigit(i))
                {
                    HandleThirdDigit(orderWords, numberAsArray, i);
                }
                else if (IsSecondDigitFromClosestThird(i))
                {
                    HandleSecondDigit(orderWords, numberAsArray, i);
                }
                else
                {
                    HandleFirstDigit(orderWords, numberAsArray, i);
                }

            }
            return string.Join(" ", orderWords);
        }
        private static int[] NumberToArray(int number)
        {
            List<int> toReturn = new();

            while (0 != number)
            {
                int lastDigit = number % 10;
                toReturn.Add(lastDigit);
                number /= 10;
            }

            return toReturn.ToArray();
        }
        private static bool TryHandleSpecialCases(int number, out string value)
        {
            if (0 == number)
            {
                value = "Zero";

                return true;
            }

            value = string.Empty;

            return false;
        }
        private static bool IsThirdDigit(int index)
        {
            return 0 == (index + 1) % 3;
        }

        private static bool IsInOneToTwentyRange(int[] numberAsArray, int index)
        {
            return (numberAsArray[index] * 10) + numberAsArray[index - 1] < _oneToTwenty.Length;
        }

        private static void HandleThirdDigit(Stack<string> pushResultTo, int[] numberAsArray, int index)
        {
            pushResultTo.Push(_hundredToBillion[(int)SpecialIndexGetters.Hundred]);
            pushResultTo.Push(_oneToTwenty[numberAsArray[index]]);
        }

        private static bool IsSecondDigitFromClosestThird(int index)
        {
            return 0 == (((index + 1) % 3) % 2);
        }

        private static void HandleSecondDigit(Stack<string> pushResultTo, int[] numberAsArray, int index)
        {
            if ((numberAsArray[index] * 10) + numberAsArray[index - 1] < _oneToTwenty.Length)
            {
                pushResultTo.Pop();
                pushResultTo.Push(_oneToTwenty[(numberAsArray[index] * 10) + numberAsArray[index - 1]]);
            }
            else
            {
                pushResultTo.Push(_twentyToHundred[numberAsArray[index]]);
            }
        }
        private static void HandleFirstDigit(Stack<string> pushResultTo, int[] numberAsArray, int index)
        {
            pushResultTo.Push(_hundredToBillion[((index / 3) + 1) & ~Convert.ToInt16((index / 3) + 1 == 1)]);
            pushResultTo.Push(_oneToTwenty[numberAsArray[index]]);
        }
        private static void HandleZero(Stack<string> pushResultTo)
        {
            pushResultTo.Push(_oneToTwenty[(int)SpecialIndexGetters.Zero]);
        }

        private enum SpecialIndexGetters
        {
            Zero = 0,
            Hundred = 1,
        }
    }
}