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
            if (dic.TryGetValue(s[r], out int val)) {
                l = Math.Max(val, l);
            }
            dic[s[r]] = r;
            res = Math.Max(res, r - l + 1);
        }
        return res;
    }
    
    public static int CharacterReplacement(string s, int k) { //https://leetcode.com/problems/longest-repeating-character-replacement
        int l = 0, r = 0;
        int final = 0;
        int[] rec = new int[26];
        int candidate = 0;

        while(r < s.Length){
            rec[s[r] - 'A']++;

        if (candidate < rec[s[r] - 'A']) 
            candidate = rec[s[r] - 'A'];

        while(r - l + 1 - candidate > k){
            rec[s[l] - 'A']--;
            l++;
        }

        final = Math.Max(r - l + 1, final);
        r++;
        }

        return final;
    }
    
    
    public static bool CheckInclusion(string s1, string s2) { //https://leetcode.com/problems/permutation-in-string/description/
        if(s1.Length > s2.Length) return false;
        int[] s1Rec = new int[26];
        int[] s2Rec = new int[26];
        int pt1 = 0, pt2 = 0, count = 0;
        while (pt2 < s1.Length){ //Initial Window Generation
            s1Rec[s1[pt2] - 'a']++;
            s2Rec[s2[pt2] - 'a']++;
            pt2++;
        }
        
        for(int i = 0; i < 26; i++){
            if(s1Rec[i] == s2Rec[i])
                count++;
        }

        while(pt2 < s2.Length){
            if(count == 26) return true;

            s2Rec[s2[pt2] - 'a']++;
            if(s2Rec[s2[pt2] - 'a'] == s1Rec[s2[pt2] - 'a']) count++;
            else if(s2Rec[s2[pt2] - 'a'] - 1 == s1Rec[s2[pt2] - 'a']) count--;
            
            s2Rec[s2[pt1] - 'a']--;
            if(s2Rec[s2[pt1] - 'a'] == s1Rec[s2[pt1] - 'a']) count++;
            else if(s2Rec[s2[pt1] - 'a'] + 1 == s1Rec[s2[pt1] - 'a']) count--;
            pt2++;
            pt1++;
        }
        return count == 26;
    }
}