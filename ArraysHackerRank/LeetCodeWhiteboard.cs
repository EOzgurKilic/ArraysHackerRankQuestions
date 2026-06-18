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
    public static int AnswerInt(int[] piles, int h)
    {
        int l = 0, r = piles.Max();
        int hour = 0;
        int m = 0;
        while (l <= r)
        {
            m = l + (r-l)/2;
            hour = 0;
            foreach (var pile in piles)
            {
                hour += (int)Math.Ceiling((double)pile/m);
            }
            if (hour > h)
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }
        return m;
    }
    public static int[] AnswerIntArr()
    {
        return new int[0];
    }
    public static string AnswerString()
    {
        return "";
    }
}
