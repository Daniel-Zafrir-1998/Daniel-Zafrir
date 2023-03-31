//https://leetcode.com/problems/single-row-keyboard/
class Solution {
public:
    const int ascii_offset = 97;

    int calculateTime(string keyboard, string word) {
        int keyboard_lut[26];
        int prev_number = 0;
        int ret = 0;

        buildKeyboardLut(keyboard_lut, sizeof(keyboard_lut)/sizeof(keyboard_lut[0]), keyboard);

        for (int i = 0; i < word.length(); ++i)
        {
            ret += abs(keyboard_lut[(word.at(i) - ascii_offset)] - prev_number);
            
            prev_number = keyboard_lut[(word.at(i) - ascii_offset)];
        }

        return ret;
    }
    void buildKeyboardLut(int keyboard_lut[], int lut_size, string keyboard){
        for (int i = 0; i < lut_size; ++i)
        {
            keyboard_lut[keyboard.at(i) - ascii_offset] = i;
        }
    }
};