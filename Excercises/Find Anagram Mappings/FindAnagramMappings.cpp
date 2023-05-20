//https://leetcode.com/problems/find-anagram-mappings/
class Solution {
public:
    vector<int> anagramMappings(vector<int>& nums1, vector<int>& nums2) {
        std::unordered_map<int, int> nums2_indexes_map;
        std::vector<int> ret;

        for (int i = 0; i < nums2.size(); ++i)
        {
            nums2_indexes_map[nums2[i]] = i;
        }

        for(int i = 0; i < nums1.size(); ++i)
        {
            ret.push_back(nums2_indexes_map[nums1[i]]);
        }

        return ret;
    }
};