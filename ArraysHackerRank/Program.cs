using System.Net.Sockets;

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
        
        List<List<int>> list = new List<List<int>>()
        {
            new List<int>(){1,2,100},
            new List<int>(){2,5,100},
            new List<int>(){3,4,100}
        };
        long result = arrayManipulation(10,list);
        Console.WriteLine(result);
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
        int highestVal = 0;
        List<int> tempArr = new List<int>();
        List<int> queriesInd = new List<int>();
        List<List<int>> operationArr = new List<List<int>>();
        
        for (int j = 0; j < n; j++)
            tempArr.Add(0);
        
        for (int i = 0; i < queries.Count; i++)
        {
            queriesInd = queries[i];
            for (int j = queriesInd[0]-1; j < queriesInd[1]; j++)
            {   
                tempArr[j] += queriesInd[2];
                highestVal = tempArr[j] > highestVal ? tempArr[j] : highestVal;
            }
            operationArr.Add(new List<int>(tempArr));
        }
        
        return highestVal;
    }
}