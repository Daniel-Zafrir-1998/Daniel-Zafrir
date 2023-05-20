//https://leetcode.com/problems/top-k-frequent-elements/
class Solution {
public:
    vector<int> topKFrequent(vector<int>& nums, int k) {
        unordered_map<int, int> map_counter_nums;
        vector<pair<int, int>> pairs;
        vector<int> ret;

        for (int i = 0; i < nums.size(); ++i)
        {
            map_counter_nums[nums[i]] += 1;
        }

        for(auto& pair: map_counter_nums)
        {
            pairs.push_back(pair);
        }

        sort(pairs.begin(), pairs.end(), [](auto &left, auto &right) 
        {
            return left.second > right.second;
        });

        int counter = 0;

        while (k)
        {
            ret.push_back(pairs[counter].first);
            --k;
            ++counter;
        }

        return ret;
    }
};