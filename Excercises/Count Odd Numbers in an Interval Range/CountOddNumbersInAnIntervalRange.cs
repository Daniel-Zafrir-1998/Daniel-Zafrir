using System.Text;

/*
Given two non-negative integers low and high. Return the count of odd numbers between low and high (inclusive).
*/

namespace Quiz.CountOddNumbersInAnIntervalRange
{
    /*
    At the start i solved it like the first Solution and i had a feeling 
    there is a mathmatical solution but still i needed to answer.
    so this is my first solution.
    after that i read that the odd numbers between n to 1 is n / 2 from there i solved that in one line 
    in Second solution 

    */


    public class FirstSolution {
        public int CountOdds(int low, int high) {
            int toReturn = 0;

            while(low <= high)
            {
                toReturn += (low % 2);
                ++low;
            }

            return toReturn;
        }
    }
    public class SecondSolution {
        public int CountOdds(int low, int high) {
            return ((high + 1) / 2) - (low / 2);
        }
    }
}