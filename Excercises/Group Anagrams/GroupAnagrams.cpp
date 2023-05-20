//https://leetcode.com/problems/group-anagrams/
class Solution {
public:
    vector<vector<string>> groupAnagrams(vector<string>& strs) {
        vector<vector<string>> ret;
        unordered_map<string, vector<string>> anagram_group;
        size_t strs_size = strs.size();

        for (int i = 0; i < strs_size; ++i)
        {
            string saver = strs[i];

            sort(strs[i].begin(), strs[i].end());

            anagram_group[strs[i]].push_back(saver);
        }

        for (auto const& pair : anagram_group) 
        {
            ret.push_back(pair.second);
        }
        return ret;
    }
};