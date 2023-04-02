//https://leetcode.com/problems/can-place-flowers/
public class Solution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        for (int i = 0; i < flowerbed.Length; ++i)
        {
            if (0 == flowerbed[i])
            {
// The conversion part is unclear, why do u need to use Convert.Int32 here?
// The code is not that readable and hard to understand.

                flowerbed[i] = Convert
                    .ToInt32(
                    (i == flowerbed.Length - 1 ||
                        (i != flowerbed.Length - 1 && 0 == flowerbed[i + 1])) &&
                    (0 == i || (0 != i && 0 == flowerbed[i - 1])));
                n -= flowerbed[i];
            }
        }
        return n <= 0;
    }
}
