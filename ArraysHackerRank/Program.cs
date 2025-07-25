﻿using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace ArraysHackerRank;

class Program
{
    static void Main(string[] args)
    {
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
        string str = "A man, a plan, a canal: Panama";
        Console.WriteLine(IsPalindrome(str));
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
    public static int[] GetConcatenation(int[] nums)//https://leetcode.com/problems/concatenation-of-array/
    { 
        //return nums.Concat(nums).ToArray();
        List<int> result = new List<int>(nums);
        result.AddRange(nums);
        return result.ToArray();
    } 
    public static string LongestCommonPrefix(string[] strs) //https://leetcode.com/problems/longest-common-prefix/
    {
        int _strIndex = 0, _arrIndex = 0;
        (int index,int length) shortest = (0,200);
        StringBuilder _sb = new();
        if (strs.Length == 1) _sb.Append(strs[0]);
        else {
            _sb.Append("");
            for(int i = 0; i < strs.Length; i++) {
                if(shortest.length > strs[i].Length) {
                    shortest.index = i;
                    shortest.length = strs[i].Length;
                }
            }
            if(shortest.length != 0) {
                while (_strIndex != strs[shortest.index].Length) {
                    if (!(strs[shortest.index][_strIndex] == strs[_arrIndex][_strIndex])) break;
                    if(++_arrIndex == strs.Length) {
                        _sb.Append(strs[shortest.index][_strIndex]);
                        _arrIndex = 0;
                        _strIndex++;
                    }
                }
            }
        }    
        return _sb.ToString();
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
    }
    
    public static int MajorityElement(int[] nums)//https://leetcode.com/problems/majority-element/
    {
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
    #endregion
    
    #region Two Pointers - NeetCode
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
            while (l < r)
            {
                if (s[l] != s[r]) return false;
                l++;
                r--;
            }

            return true;
        }
    }
    public string MergeAlternately(string word1, string word2) { //https://leetcode.com/problems/merge-strings-alternately
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
    #endregion
}