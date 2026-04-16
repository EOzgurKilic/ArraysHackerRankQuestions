using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
namespace ArraysHackerRank;

public class Stack
{
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

    //-------------------Medium Questions--------------------
    /*
    public class MinStack { //https://leetcode.com/problems/min-stack/
    Stack<int> minLog; 
    Stack<int> stack;
    public MinStack() {
        stack = new();
        minLog = new(); 
    }
    
    public void Push(int val) {
        stack.Push(val);
        if(minLog.Count == 0 || val <= minLog.Peek())
            minLog.Push(val);
    }
    
    public void Pop() {
        if(stack.Pop() == minLog.Peek())
            minLog.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return minLog.Peek();
    }
    }
    */
    
    
    public static int[] DailyTemperatures(int[] temperatures) { //https://leetcode.com/problems/daily-temperatures/
        Stack<(int ind, int val)> rec = new();
        int[] final = new int[temperatures.Length];
        for(int i = 0; i < temperatures.Length; i++){
            while(rec.Count != 0 && rec.Peek().val < temperatures[i]){
                final[rec.Peek().ind] = i - rec.Pop().ind;
            }
            rec.Push((i, temperatures[i]));
        }
        return final;
    } 
    
    
    public static int EvalRPN(string[] tokens) {
        Stack<int> rec = new();
        
        int no1 = 0, no2 = 0;
        foreach (var i in tokens)
        {
            switch (i)
            {
                case "+": no2 = rec.Pop(); no1 = rec.Pop() + no2; break;
                case "-": no2 = rec.Pop(); no1 = rec.Pop() - no2; break;
                case "*": no2 = rec.Pop(); no1 = rec.Pop() * no2; break;
                case "/": no2 = rec.Pop(); no1 = rec.Pop() / no2; break;
                default: no1 = int.Parse(i); break;
            }
            rec.Push(no1);
        }
        return rec.Pop();
    }
}