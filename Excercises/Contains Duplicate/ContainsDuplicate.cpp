//https://leetcode.com/problems/contains-duplicate/
class Solution {
public:
  // Yair - I am curious why did you solve this in C++? Does C++ have a set structure? 
 // how can we solve the problem with a set?
    bool containsDuplicate(vector<int>& nums) {
        size_t nums_size = nums.size();
        unordered_map<int, char> dup_map;

        for (int i = 0; i < nums_size; ++i)
        {
            if (dup_map.find(nums[i]) != dup_map.end())
            {
                return true;
            }
            dup_map[nums[i]] = 0;
        }
        return false;
    }
};
