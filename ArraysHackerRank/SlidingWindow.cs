namespace ArraysHackerRank;

public class SlidingWindow
{
    public bool ContainsNearbyDuplicate(int[] nums, int k) //https://leetcode.com/problems/contains-duplicate-ii
    {
        HashSet<int> window = new();
        int ptr1 = 0, ptr2 = 0;
        while(ptr2 < nums.Length){
            if(ptr2 > ptr1 + k)
                window.Remove(nums[ptr1++]);
            if (!window.Add(nums[ptr2++]))
                return true;
        }
        return false;
    }
    
    
    public static int MaxProfit(int[] prices) { //https://leetcode.com/problems/best-time-to-buy-and-sell-stock
        int left = 0, right = 1, maxProfit = 0;

        while (right < prices.Length)
        {
            if (prices[right] > prices[left])
                maxProfit = Math.Max(maxProfit, prices[right] - prices[left]);
            else
                left = right;

            right++;
        }
        return maxProfit;
    }
    
    
    //------ Medium Questions ------
    public static int LengthOfLongestSubstring(string s) { //https://leetcode.com/problems/longest-substring-without-repeating-characters
        //Time Complexity: O(n)
        //Space Complexity: O(m) space where m is the total number of unique characters in the string.
        Dictionary<char, int> dic = new Dictionary<char, int>();
        int l = 0, res = 0;

        for (int r = 0; r < s.Length; r++) {
            if (dic.ContainsKey(s[r])) {
                l = Math.Max(dic[s[r]] + 1, l);
            }
            dic[s[r]] = r;
            res = Math.Max(res, r - l + 1);
        }
        return res;
    }
    
    public static int CharacterReplacement(string s, int k) { //https://leetcode.com/problems/longest-repeating-character-replacement
        Dictionary<char, int> count = new Dictionary<char, int>();
        int res = 0;

        int l = 0, maxf = 0;
        for (int r = 0; r < s.Length; r++) {
            if (count.ContainsKey(s[r])) {
                count[s[r]]++;
            } else {
                count[s[r]] = 1;
            }
            maxf = Math.Max(maxf, count[s[r]]);

            while ((r - l + 1) - maxf > k) {
                count[s[l]]--;
                l++;
            }
            res = Math.Max(res, r - l + 1);
        }

        return res;
    }
}