﻿using System.Net.Sockets;
using System.Text;

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
        int[] nums = { 3,2,3 };
        var no = MajorityElement(nums);
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
    
    public static int[] GetConcatenation(int[] nums)//https://leetcode.com/problems/concatenation-of-array/
    { 
        List<int> result = new List<int>(nums);
        result.AddRange(nums);
        return result.ToArray(); 
    } 
    public static string LongestCommonPrefix(string[] strs) //https://leetcode.com/problems/longest-common-prefix/
    {
        (int length, int index) shortestStr = (200, 0); 
        int temp = 0;
        StringBuilder sb = new StringBuilder();
        sb.Append("");
        for (int i = 0 ; i < strs.Length; i++)
        {
            shortestStr = shortestStr.length > strs[i].Length ? (strs[i].Length, i) : shortestStr;
        }

        for (int i = 0; i < shortestStr.length; i++)
        {
            while  (temp < strs.Count())
            {
                if (strs[shortestStr.index][i]!=strs[temp][i])
                {
                    return sb.ToString();
                }
                temp++;
            }
            sb.Append(strs[shortestStr.index][i]);
            temp = 0;
        }

        return sb.ToString();
    }

    public static int RemoveElement(int[] nums, int val)
    {
        int temp = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {
                continue;
            }
            nums[temp] = nums[i];
            temp++;
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
}