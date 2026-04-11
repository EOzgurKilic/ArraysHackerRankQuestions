using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
namespace ArraysHackerRank;

public class TwoPointers
{
    public static void ReverseString(char[] s) { //https://leetcode.com/problems/reverse-string
        int low = 0, high = s.Length-1;
        char temp = ' ';
        while (low <= high){
            temp = s[low];
            s[low] = s[high];
            s[high] = temp;
            low++;
            high--;
        }
    }
    
    
    public static bool IsPalindrome(string s) //https://leetcode.com/problems/valid-palindrome
    {
        int pt1 = 0, pt2 = s.Length - 1;
        while(pt1 < pt2){
            if(!IsAlphaNumeric(s[pt1]))
                pt1++;
            else if (!IsAlphaNumeric(s[pt2]))
                pt2--;
            else if (char.ToLowerInvariant(s[pt1++]) != char.ToLowerInvariant(s[pt2--]))
                return false;
        } 
        return true;
        
        bool IsAlphaNumeric(char x)
        {
            return x >= 'A' && x <= 'Z' || x <= 'z' && x >= 'a' || x >= '0' && x <= '9'; 
        }
    }
    public static bool ValidPalindrome(string s) { //https://leetcode.com/problems/valid-palindrome-ii
        int l = 0, r = s.Length - 1;
        while (l < r) {
            if (s[l] != s[r]) {
                return IsPalindrome(s, l + 1, r) || IsPalindrome(s, l, r - 1);
            }
            l++;
            r--;
        }
        return true;
        bool IsPalindrome(string s, int l, int r)
        {
            while(l < r)
                if(s[l++] != s[r--])
                    return false;
            return true;
        }
    }
    public static string MergeAlternately(string word1, string word2) { //https://leetcode.com/problems/merge-strings-alternately
        StringBuilder result = new();
        int ptr1 = 0, ptr2 = 0;

        while (ptr1 < word1.Length && ptr2 < word2.Length) {
            result.Append(word1[ptr1++]);
            result.Append(word2[ptr2++]);
        }
        
        while(ptr1 < word1.Length) {
            result.Append(word1[ptr1++]);
        }
        
        while(ptr2 < word2.Length) {
            result.Append(word2[ptr2++]);
        }

        return result.ToString();
    }
    
    
    public static void Merge(int[] nums1, int m, int[] nums2, int n) { //https://leetcode.com/problems/merge-sorted-array
       
        int pt1 =  m - 1, pt2 = n - 1;
        int lastMax = nums1.Length-1;
        while (pt2 >= 0)
        {
            if (pt1 >= 0 && nums1[pt1] > nums2[pt2])
                nums1[lastMax--] = nums1[pt1--];
            else
                nums1[lastMax--] = nums2[pt2--];
        }
    }
    
    public int RemoveDuplicates(int[] nums) { //https://leetcode.com/problems/remove-duplicates-from-sorted-array
        //Two solutions below are much more efficient with dictionaries although the value parts are not used for particular reason. I have seen over 95% beating rates
        //whereas the solution with hashsets barely reaches 50%
        int pt1 = 0, pt2 = 1;
        while (pt2 < nums.Length)
        {
            if (nums[pt1] != nums[pt2])
                nums[++pt1] = nums[pt2++];
            else
                pt2++;
        }
        return ++pt1;
        //Faster Stats Longer Solution; Approximately 10 ms diff in time complexity
        /*
        HashSet<int> window = new(); //Dictionary<int, int> window = new();
        int initialSize = nums.Length >= k + 1 ? k + 1 : nums.Length;
        int l = 0, r = initialSize;
        for (int i = 0; i < initialSize; i++){
            if (!window.Add(nums[i])) return true; //(!window.TryAdd(nums[i], 0) return true;
        }
        while (r < nums.Length){
            window.Remove(nums[l++]);
            if (!window.Add(nums[r++])) return true; //if (!window.TryAdd(nums[r++], 0)) return true;
        }
        return false;
         */
    }
    
    
    //------ Medium Questions ------
    public IList<IList<int>> ThreeSum(int[] nums) { //https://leetcode.com/problems/3sum
        //Time Complexity: O(n^2)
        //Space Complexity: O(m) space for the output list.
        Array.Sort(nums);
        List<IList<int>> final = new();
        for(int i = 0; i < nums.Length-2; i++){ 
            if(nums[i] > 0) break;
            if (i > 0 && nums[i] == nums[i-1]) continue;
            int l = i + 1, r = nums.Length -1;
            while (l < r){
                int sum = nums[i] + nums[l] + nums[r];
                if(sum > 0) r--;
                else if(sum < 0) l++;
                else{
                    final.Add(new List<int>(){nums[i], nums[l], nums[r]});
                    r--;
                    l++;
                    while(l < r && nums[l] == nums[l-1]) l++;
                }
            }
        }
        return final;
    }
    
    
    public static int MaxArea(int[] height) { https://leetcode.com/problems/container-with-most-water
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        int pt1 = 0, pt2 = height.Length - 1, final = 0;
        while(pt1 < pt2){
            int area = Math.Min(height[pt1], height[pt2]) * (pt2 - pt1);
            final = Math.Max(final, area);

            if(height[pt1] <= height[pt2]) pt1++;
            else pt2--;
        }
        return final;
    }
    public static int[] TwoSumSorted(int[] numbers, int target) //https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    {
        //Can't say that this first solution of mine below is following the two pointers approach but still is optimal
        //I will add the one based on two pointers soon below this hashmap approach to the problem
        int[] res = new int[4001];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (res[target - numbers[i] + 2000] != 0)
                return new int[2] { res[target - numbers[i] + 2000], i + 1 };
            res[numbers[i] + 2000] = i + 1;
        }
        return new int[0];
    }
}