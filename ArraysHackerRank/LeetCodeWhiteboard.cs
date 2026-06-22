namespace ArraysHackerRank;

public static class LeetCodeWhiteboard
{
    public static void Run()
    {
        
    }
}

public class Solution
{
    public static void AnswerVoid(){}
    public static int AnswerInt()
    {
        return 0;
    }
    public static int[] AnswerIntArr()
    {
        return new int[0];
    }
    public static string AnswerString()
    {
        return "";
    }

    public static bool AnswerBool(char[][] board)
    {
        
        return true;
    }
}
public class TimeMap {
    Dictionary<string, List<(int timestamp, string value)>> rec;
    public TimeMap() {
        rec = new();
    }
    
    public void Set(string key, string value, int timestamp) {
        if(!rec.ContainsKey(key)) rec[key] = new();
        rec[key].Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
    if(!rec.ContainsKey(key)) return "";

    int r = rec[key].Count - 1, l = 0;
    while(l <= r)
        {
            int m = (r - l)/2 + l;
            if(rec[key][m].timestamp == timestamp) return rec[key][m].value;
            else if(rec[key][m].timestamp > timestamp) r = m - 1;
            else l = m + 1;
        }
        return rec[key][l].value;
    }
}