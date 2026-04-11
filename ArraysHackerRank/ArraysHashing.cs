namespace ArraysHackerRank;

public class Arrays_Hashing
{
    public bool ContainsDuplicate(int[] nums) { //https://leetcode.com/problems/contains-duplicate
        HashSet<int> duplicate = new();
        foreach(var i in nums)
            if(!duplicate.Add(i))
                return true;
        return false;
        //With HashSet, Time Comp: O(n) & Space Comp: O(n)
    }
    public static int[] GetConcatenation(int[] nums)//https://leetcode.com/problems/concatenation-of-array/
    { 
        //return nums.Concat(nums).ToArray();
        List<int> result = new List<int>(nums);
        result.AddRange(nums);
        return result.ToArray();
    } 
    public static string LongestCommonPrefix(string[] strs) //https://leetcode.com/problems/longest-common-prefix/
    {
        for (int i = 0; i < strs[0].Length; i++) {
            foreach (string s in strs) {
                if (i == s.Length || s[i] != strs[0][i]) {
                    return s.Substring(0, i);
                }
            }
        }
        return strs[0];
    }

    public static int RemoveElement(int[] nums, int val)
    {
        int temp = 0;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] == val)
                continue;
            nums[temp++] = nums[i];
        }
        return temp; //temp only increases
        
        //Two Pointers
        /*int pt1 = 0, pt2 = 0;
        while(pt1 < nums.Length){
            if(nums[pt1] != val)
                nums[pt2++] = nums[pt1];
            pt1++;
        }
        return pt2; */
    }
    
    public static int MajorityElement(int[] nums)//https://leetcode.com/problems/majority-element/
    {
        /*
         The Boyer-Moore Voting Algorithm is used in this question;
         It’s a linear-time, constant-space algorithm for finding a majority element in a sequence — an element that appears more than half the time.\
         It doesn't count elements in full; instead, it uses a cancellation logic to narrow down to the likely winner.
         Think of it as an election simulator:
            -Every element "votes" for itself.
            -Opposing votes cancel each other out.
            -If one value has an actual majority, it survives the storm.
        It’s useful in any scenario where:
            -You expect a majority-like property
            -You need single-pass, low-memory processing
         */
        int potential = 0, counter = 0;
        foreach (int i in nums)
        {
            if(counter == 0){
                potential = i;
                counter++;
            }
            else
                counter += potential == i ? 1 : -1;
        }
        return potential;
    }
    
    
    public bool IsAnagram(string s, string t) {https://leetcode.com/problems/valid-anagram
        if(s.Length != t.Length) return false;
        int[] count = new int[26];
        for(int i = 0; i < s.Length; i++)
            count[s[i] - 'a']++;
        for(int i = 0; i < t.Length; i++)
            if(--count[t[i] - 'a'] < 0)
                return false;
        return true;
    }
    
    
    public int[] TwoSum(int[] nums, int target) { //https://leetcode.com/problems/two-sum
        Dictionary<int,int> rec = new();
        for(int i = 0; i < nums.Length; i++){
            if(rec.TryGetValue(target - nums[i], out int index)) return new int[2]{index, i};
            if(!rec.ContainsKey(nums[i])) rec[nums[i]] = i;
        }
        return new int[0];
    }
    
    
    //------ Medium Questions ------
    public IList<IList<string>> GroupAnagrams(string[] strs) { //https://leetcode.com/problems/group-anagrams
        var res = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            char[] charArray = s.ToCharArray();
            Array.Sort(charArray);
            string sortedS = new string(charArray);
            if (!res.ContainsKey(sortedS)) {
                res[sortedS] = new List<string>();
            }
            res[sortedS].Add(s);
        }
        return res.Values.ToList<IList<string>>();
    }
    
    public void SortColors(int[] nums) { https://leetcode.com/problems/sort-colors/description
        int i = 0, l = 0, r = nums.Length - 1;

        while (i <= r) {
            if (nums[i] == 0) {
                Swap(nums, l, i);
                l++;
            } else if (nums[i] == 2) {
                Swap(nums, i, r);
                r--;
                i--;
            }
            i++;
        }
        void Swap(int[] nums, int i, int j) {
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }
        
        
        //Two Pass Simple Solution
        /*
        int[] rec = new int[3];
        foreach(int no in nums)
            rec[no]++;
        for(int i = 0; i < nums.Length; i++){
            if(rec[0] > 0){rec[0]--; nums[i] = 0;}
            else if (rec[1] > 0){rec[1]--; nums[i] = 1;}
            else nums[i] = 2;
        }
         */
    }
    public int[] SortArray(int[] nums) { //https://leetcode.com/problems/sort-an-array
        MergeSort(nums, 0, nums.Length - 1);
        return nums;
        
        void MergeSort(int[] arr, int l, int r) {
            if (l == r) return;

            int m = (l + r) / 2;
            MergeSort(arr, l, m);
            MergeSort(arr, m + 1, r);
            Merge(arr, l, m, r);
        }
        
        void Merge(int[] arr, int l, int m, int r){
            int[] left = arr[l..(m+1)];
            int[] right = arr[(m+1)..(r + 1)];
            int pt = r;
            r = right.Length - 1;
            while(0 <= r){
                if(m >= l && arr[m] >= right[r])
                    arr[pt--] = arr[m--];
                else
                    arr[pt--] = right[r--];
            }
        }
    }
    
    public static int[] TopKFrequent(int[] nums, int k) { //https://leetcode.com/problems/top-k-frequent-elements
        Dictionary<int, int> count = new Dictionary<int, int>();
        List<int>[] freq = new List<int>[nums.Length + 1];
        for (int i = 0; i < freq.Length; i++) {
            freq[i] = new List<int>();
        }

        foreach (int n in nums) {
            if (count.ContainsKey(n)) {
                count[n]++;
            } else {
                count[n] = 1;
            }
        }
        foreach (var entry in count){
            freq[entry.Value].Add(entry.Key);
        }

        int[] res = new int[k];
        int index = 0;
        for (int i = freq.Length - 1; i > 0; i--) {
            foreach (int n in freq[i]) {
                res[index++] = n;
                if (index == k) {
                    return res;
                }
            }
        }
        return res;
    }
    
    
    public static int[] ProductExceptSelf(int[] nums) { //https://leetcode.com/problems/product-of-array-except-self
        int prefix = 1;
        int suffix = 1;
        int[] result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = prefix;
            prefix *= nums[i];
        }
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= suffix;
            suffix *= nums[i];
        }
        return result;
    }
    
    
    public class NumMatrix { //https://leetcode.com/problems/range-sum-query-2d-immutable
        private readonly int[][] ps;

        public NumMatrix(int[][] matrix) {
            int n = matrix.Length;
            int m = (n == 0) ? 0 : matrix[0].Length;
            ps = new int[n + 1][];
            for (int i = 0; i <= n; i++) ps[i] = new int[m + 1];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    ps[i + 1][j + 1] = matrix[i][j]
                                       + ps[i][j + 1]
                                       + ps[i + 1][j]
                                       - ps[i][j];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2) {
            return ps[row2 + 1][col2 + 1]
                   - ps[row1][col2 + 1]
                   - ps[row2 + 1][col1]
                   + ps[row1][col1];
        }
    }
    
    
    public static bool IsValidSudoku(char[][] board) { //https://leetcode.com/problems/valid-sudoku
        //This is the brute force solution.
        for (int row = 0; row < 9; row++) {
            HashSet<char> seen = new HashSet<char>();
            for (int i = 0; i < 9; i++) {
                if (board[row][i] == '.') continue;
                if (seen.Contains(board[row][i])) return false;
                seen.Add(board[row][i]);
            }
        }

        for (int col = 0; col < 9; col++) {
            HashSet<char> seen = new HashSet<char>();
            for (int i = 0; i < 9; i++) {
                if (board[i][col] == '.') continue;
                if (seen.Contains(board[i][col])) return false;
                seen.Add(board[i][col]);
            }
        }

        for (int square = 1; square <= 9; square++) {
            HashSet<char> seen = new HashSet<char>();
            for (int i = 0; i < 3; i++) {
                int row = ((square-1) / 3) * 3 + i;
                for (int j = 0; j < 3; j++) {
                    int col = ((square - 1) % 3) * 3 + j;
                    if (board[row][col] == '.') continue;
                    if (seen.Contains(board[row][col])) return false;
                    seen.Add(board[row][col]);
                }
            }
        }

        return true;
    }
    
    public static int LongestConsecutive(int[] nums) { //https://leetcode.com/problems/longest-consecutive-sequence
        //Time & Space Complexities: O(n)
        HashSet<int> _set = new HashSet<int>(nums);
        int counter = 0, highest = 0;
        foreach(int num in _set){
            if(!_set.Contains(num-1)){
                counter = 1;
                while(_set.Contains(num+counter))
                    counter++;
            }
            highest = Math.Max(counter, highest);
        }
        return highest;
    }
}