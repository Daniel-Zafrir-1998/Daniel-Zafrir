//https://leetcode.com/problems/dot-product-of-two-sparse-vectors/
public class SparseVector
{
    public Dictionary<int, int> valuesVector;

    public SparseVector(int[] nums)
    {
        valuesVector = new();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (0 != nums[i])
            {
                valuesVector.Add(i, nums[i]);
            }
        }
    }

    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec)
    {
        int toReturn = 0;

        foreach (var key in vec.valuesVector.Keys)
        {
            if (valuesVector.ContainsKey(key))
            {
                toReturn += (vec.valuesVector[key] * valuesVector[key]);
            }
        }
        return toReturn;
    }
}