//https://leetcode.com/problems/can-place-flowers/
public class Solution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        for (int i = 0; i < flowerbed.Length; ++i)
        {
            if (0 == flowerbed[i])
            {
// Yair : the convert part is unradable , what did you try to do here? What's the Convert.ToInt32 for?
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
