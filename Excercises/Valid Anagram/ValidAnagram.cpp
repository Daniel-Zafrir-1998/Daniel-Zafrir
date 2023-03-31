//https://leetcode.com/problems/valid-anagram/
#define ACCII_ARRAY_SIZE 26

class Solution {
public:
    bool isAnagram(string s, string t) {
        int counter[ACCII_ARRAY_SIZE] = {0};
        size_t s_size = s.length();
        size_t t_size = t.length();

        if (s_size != t_size)
        {
            return false;
        }

        for (int i = 0; i < s_size; ++i)
        {
            ++counter[s[i] - 'a'];
            --counter[t[i] - 'a'];
        }

        for (int i = 0; i < ACCII_ARRAY_SIZE; ++i)
        {
            if (counter[i] < 0)
            {
                return false;
            }
        }
        return true;
    }
};