using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace ArraysHackerRank;

class Program
{
    static void Main(string[] args)
    {
        char[] charArr = new char[]{'d','r','e'};
        Array.Sort(charArr);
        foreach (char item in charArr)
            Console.WriteLine(item);
        Dictionary<int,char> dic = new Dictionary<int,char>();
        dic[0] = 'i';
        dic[1] = 'e';
        foreach (var VARIABLE in dic.Values)
        {
            Console.WriteLine(VARIABLE);
        }

        Console.WriteLine(dic.Values.GetType().Name);
        /*List<int> numbers = new List<int>(){1,2,3,4,5};
        List<int> rotatedNumbers = rotateLeft(2, numbers);
        foreach (var variable in rotatedNumbers)
        Console.WriteLine(variable);*/
        /*List<string> stringList = new List<string>(){"ab", "ab", "abc"};
        List<string> queries = new List<string>(){"ab", "abc", "abcd", "abcde"};
        List<int> matchCount = matchingStrings(stringList, queries);
        foreach (int val in matchCount)
            Console.WriteLine(val);*/


        /*List<List<int>> list = new List<List<int>>()
        {
            new List<int>(){1,2,10},
            new List<int>(){2,4,80},
            new List<int>(){5,6,100},
            new List<int>(){3,5,10}
        };
        long result = arrayManipulation(6,list);
        Console.WriteLine(result);*/


        //RemoveElement
        /*int[] nums = { 3,2,2,3 };
        Console.WriteLine(RemoveElement(nums,3));
        foreach (int i in nums)
            Console.Write(i + " ");*/


        //MajorityElement
        /*int[] nums = { 3,2,3 };
        var no = MajorityElement(nums);*/


        //Longest Common Prefix
        /*string[] strArr = new []{"flower","flow","flight"};
        string longestPrefix = LongestCommonPrefix(strArr);*/



        /*
    Exercise: Method Revision

    You're managing a virtual fruit basket using a List<string>.
    Write a C# console app that performs the following steps in order:

    1. Create an empty list of strings called fruitBasket.
    2. Add the following fruits: "apple", "banana", "cherry".
    3. Add "orange" at the beginning of the list.
    4. Add "kiwi" and "grape" to the end of the list in one step.
    5. Ask the user to input a fruit name.
    If the fruit is in the basket, remove it and show a message like "Removed [fruit]".
    If not, say "Fruit not found".
    6. Insert "lemon" at the second position (index 1).
    7. Print the total number of fruits in the basket.
    8. Sort the list alphabetically.
    9. Reverse the list.
    10. Print the final list, one fruit per line.

    Bonus Challenge:
    - Ask the user to enter a number, and remove that many fruits starting from the 2nd index.
    - Convert the final list into an array and print it.
    */
        /*List<string> basket= new();
        basket.Add("apple");
        basket.Add("banana");
        basket.Add("cherry");
        basket.Insert(0,"orange");
        basket.AddRange(new string[] { "kiwi", "grape" });
        Console.Write("Type the fruit name that you want to be removed from the basket:");
        if(basket.Remove(Console.ReadLine().ToString().ToLower()))
           Console.WriteLine("Removed from the basket");
        else
            Console.WriteLine("Fruit not found!");
        basket.Insert(1,"Lemon");
        Console.WriteLine($"Total number of fruits: {basket.Count}");
        basket.Sort();
        basket.Reverse();
        foreach(var item in basket)
            Console.WriteLine(item);
        //Bonus
        if (int.TryParse(Console.ReadLine(), out int countToRemove) && basket.Count >= 2 + countToRemove)
            basket.RemoveRange(2, countToRemove);
        else
            Console.WriteLine("Invalid number or not enough items to remove.");
        string[] fruitArray = basket.ToArray();
        Console.WriteLine("Final fruits array:");
        foreach (var fruit in fruitArray)
            Console.WriteLine(fruit);*/


        //IsPalindrome
        /*string str = "A man, a plan, a canal: Panama";
        Console.WriteLine(IsPalindrome(str));*/


        //Merge
        /*int[] arr1 = {1,2,3,0,0,0};
        int[] arr2 = {2,5,6};
        Merge(arr1,3,arr2,3);*/


    }

    static int TwoDArrayDS(List<List<int>> arr) //https://www.hackerrank.com/challenges/2d-array/problem?isFullScreen=true
    {
        int sum = -63;
        for (int i = 1; i < 5; i++)
        {
            for (int j = 1; j < 5; j++)
            {
                if (sum < arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1] + arr[i][j] + arr[i + 1][j - 1] +
                    arr[i + 1][j] + arr[i+1][j + 1])
                    sum = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1] 
                          + arr[i][j] 
                          + arr[i + 1][j - 1] + arr[i + 1][j] + arr[i+1][j + 1];
            }
        }

        return sum;
    }
    
    static List<int> rotateLeft(int d, List<int> arr) //https://www.hackerrank.com/challenges/array-left-rotation/problem?isFullScreen=true
    {
        int temp = d % arr.Count;
        List<int> result = new List<int>();
        for (int i = temp; i < arr.Count; i++)
        {
            result.Add(arr[i]);
        }
        for (int i = 0; i < temp; i++)
        {
            result.Add(arr[i]);
        }

        return result;
    }
    
    public static List<int> matchingStrings(List<string> stringList, List<string> queries) //https://www.hackerrank.com/challenges/sparse-arrays/problem?isFullScreen=true
    {
        List<int> result = new List<int>();
        
        Dictionary<string,int> dict = new Dictionary<string,int>();
        for (int i = 0; i < stringList.Count; i++)
        {
            if (dict.ContainsKey(stringList[i]))
                dict[stringList[i]]++;
            else 
                dict.Add(stringList[i], 1);
        }

        for (int i = 0; i < queries.Count; i++)
            if (dict.TryGetValue(queries[i], out int temp))
            result.Add(temp);
        else
            result.Add(0);
        return result;
    }
    
    public static long arrayManipulation(int n, List<List<int>> queries) //https://www.hackerrank.com/challenges/crush/problem?isFullScreen=true
    {
        //Utilizing from difference array technique
        //The update part equals O(1) this way rather than O(n) since we only perform a certain amount of operations (2), increasing...
        //... the element corresponding to the beginning of the range (arr[StartOfRange]) and subtracting the k from arr[EndOfRange + 1].
        //In the other case, the operation amount is based on how many elements will be within the mentioned range. Therefore the complexity...
        //... equals O(n) and pretty inefficient in cases the ranges given in the 2D list are considerably wide.
        int[] arr = new int[n + 2]; 

        foreach (var query in queries)
        {
            int a = query[0];
            int b = query[1];
            int k = query[2];

            arr[a] += k;
            arr[b + 1] -= k;
        }

        long max = 0;
        long current = 0;

        for (int i = 1; i <= n; i++)
        {
            current += arr[i];
            if (current > max)
                max = current;
        }

        return max;
    }
    
    
    #region Arrays&Hashing - NeetCode
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
        if (s.Length != t.Length)
            return false;
        Dictionary<char,int> rec = new();
        foreach (var i in s){
            if(!rec.ContainsKey(i))
                rec.Add(i,0);
            rec[i]++;
        }
        foreach (var i in t){
            if(!(rec.ContainsKey(i) && --rec[i] >= 0))
                return false;
        }
        return true;
    }
    
    
    public int[] TwoSum(int[] nums, int target) { //https://leetcode.com/problems/two-sum
        Dictionary<int,int> _rec = new();
        for(int i = 0; i < nums.Length; i++){
            if(_rec.TryGetValue(target - nums[i], out int index))
                return new int[2]{index, i};
            if(!_rec.ContainsKey(nums[i]))
                _rec.Add(nums[i], i);
        }
        return Array.Empty<int>();
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
    
    
    public IList<IList<int>> ThreeSum(int[] nums) { //https://leetcode.com/problems/3sum
        //Time Complexity: O(n^2)
        //Space Complexity: O(m) space for the output list.
        Array.Sort(nums);
        List<IList<int>> res = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int l = i + 1, r = nums.Length - 1;
            while (l < r) {
                int sum = nums[i] + nums[l] + nums[r];
                if (sum > 0) {
                    r--;
                } else if (sum < 0) {
                    l++;
                } else {
                    res.Add(new List<int> {nums[i], nums[l], nums[r]});
                    l++;
                    r--;
                    while (l < r && nums[l] == nums[l - 1]) {
                        l++;
                    }
                }
            }
        }
        return res;
    }
    #endregion
    
    #region Two Pointers - NeetCode
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
        var left = 0;
        var right = s.Length - 1;
        while (left <= right)
        {
            if (!IsAlphaNumeric(s[left]))
            {
                left++;
                continue;
            }

            if (!IsAlphaNumeric(s[right]))
            {
                right--;
                continue;
            }
            
            if(char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right])) 
                return false;
            
            left++; right--;
        }

        return true;

        bool IsAlphaNumeric(char c)
        {
            return c is >= '0' and <= '9' or >= 'A' and <= 'Z' or >= 'a' and <= 'z';
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
    
    #endregion

    #region Sliding Window - NeetCode
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
    #endregion
    
    #region Stack
    public static int CalPoints(string[] ops) //https://leetcode.com/problems/baseball-game
    {
        Stack<int> _rec = new();
        int _temp = 0, _sum = 0;

        foreach (var i in ops)
        {
            if(i == "C"){
                _sum -= _rec.Pop();
            }
            else if(i == "D"){
                _rec.Push(_rec.Peek()*2);
                _sum += _rec.Peek();
            }
            else if (i == "+"){
                _temp += _rec.Pop();
                _temp += _rec.Peek();
                _rec.Push(_temp - _rec.Peek());
                _rec.Push(_temp);
                _sum += _temp;
                _temp = 0;
            }
            else {
                _rec.Push(int.Parse(i));
                _sum += _rec.Peek();
            }
        }
        return _sum;
        //Alternative
        /*int temp = 0, sum = 0;
        Stack<int> records = new();
        for(int i = 0; i < operations.Length; i++){
            switch (operations[i]){
                case "+" : 
                temp += records.Pop();
                temp += records.Peek();
                records.Push(temp - records.Peek());
                records.Push(temp);
                temp = 0; 
                sum += records.Peek();
                break;
                case "D" : 
                records.Push(records.Peek()*2);
                sum += records.Peek();
                break;
                case "C":
                sum -= records.Pop();
                break;
                default:  
                records.Push(int.Parse(operations[i]));
                sum += records.Peek();
                break;
            }
        }
        return sum;*/
    }
    public static bool IsValid(string s) //https://leetcode.com/problems/valid-parentheses
    {
        Stack<char> track = new();
        foreach (var i in s){
            switch (i){
                case '{': track.Push('}'); break;
                case '[': track.Push(']'); break;
                case '(': track.Push(')'); break;
                default: 
                    if(track.Count == 0 || track.Pop() != i) return false;
                    break;
            }
        }
        return track.Count == 0;
    }
    
    public class MyStack { //https://leetcode.com/problems/implement-stack-using-queues  
        Queue<int> que;
        public MyStack() {
            que = new();
        }
    
        public void Push(int x) {
            que.Enqueue(x);
            for (int i = 0; i < que.Count - 1; i++){
                que.Enqueue(que.Dequeue());
            }
        }
    
        public int Pop() {
            return que.Dequeue();
        }
    
        public int Top() {
            return que.Peek();
        }
    
        public bool Empty() {
            return que.Count == 0;
        }
    }
    
    
    public class MyQueue //https://leetcode.com/problems/implement-queue-using-stacks
    {
        private readonly Stack<int> inSt = new();
        private readonly Stack<int> outSt = new();

        public void Push(int x) => inSt.Push(x);

        public int Pop()
        {
            MoveIfNeeded();
            return outSt.Pop();
        }

        public int Peek()
        {
            MoveIfNeeded();
            return outSt.Peek();
        }

        public bool Empty() => inSt.Count == 0 && outSt.Count == 0;

        private void MoveIfNeeded()
        {
            if (outSt.Count == 0)
                while (inSt.Count > 0)
                    outSt.Push(inSt.Pop());
        }
    }
    #endregion
    
    #region Binary Search - NeetCode
    public static int SearchInsert(int[] arr, int val) { //https://leetcode.com/problems/search-insert-position
        int l = 0, h = arr.Length -1;
        int avg = (h+l)/2;
        while(l<=h){
            if(arr[avg] == val) return avg;
            else if(arr[avg] < val) l = avg + 1;
            else h = avg - 1;
            avg = (l+h)/2; 
        }
        return arr[avg] > val ? avg: avg + 1;
    }
    
    
    /*public class Solution : GuessGame { //GuessGame was an internal class in the question https://leetcode.com/problems/guess-number-higher-or-lower
        public int GuessNumber(int n) {
            int low = 1, high = n;
            int mid = low+(high-low)/2;
            while (low <= high)
            {
                int result = guess(mid);
                if(result == 0)
                    return mid;
                else if (result == -1)
                    high = mid - 1;
                else
                    low = mid + 1;
                mid = low+(high-low)/2;
            }
            return -1;
        }
    }*/
    
    
    public static int MySqrt(int x) { //https://leetcode.com/problems/sqrtx
        int l = 0, h = x/2;
        int avg = (h+l)/2;
        while(l <= h){
            if((long)avg*avg == x) break;
            else if ((long)avg*avg > x) h = avg - 1;
            else l = avg+1;
            avg = (h-l)/2+l;
        }
        return (long)avg*avg > x ? avg-1: avg;
    }
    #endregion
    
    #region LinkedLists - NeetCode
    /*public ListNode ReverseList(ListNode head) { //https://leetcode.com/problems/reverse-linked-list
        ListNode next = null, prev = null;
        while (head != null){
            next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        return prev;
    }*/
    
    
    /*public ListNode MergeTwoLists(ListNode list1, ListNode list2) { //https://leetcode.com/problems/merge-two-sorted-lists
        ListNode final = new();
        ListNode temp = final;
        while(list1 != null && list2 != null){
            if(list1.val <= list2.val){
                temp.next = list1;
                list1 = list1.next;
            }
            else {
                temp.next = list2;
                list2 = list2.next;
            }
            temp = temp.next;
        }
        temp.next = list1 != null ? list1: list2; //Wiring it to the remaining of the notnull list.
        return final.next;
    }*/

    /*public bool HasCycle(ListNode head) { https://leetcode.com/problems/linked-list-cycle
     //The algorithm works because if the list has no cycle, the fast pointer will eventually reach null and we know there is no loop.
     //But if there is a cycle, once both pointers are inside it, the fast pointer moves two steps while the slow moves one, so the distance between them decreases by one each time.
     //Eventually the fast pointer catches up to the slow pointer, which proves there is a cycle.
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null) { 
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) return true; //by the name comparison, it regards the object references not the vals, this way diff nodes containing the same vals do not cause trouble.
        }
        return false;
    }*/
    #endregion
    
}