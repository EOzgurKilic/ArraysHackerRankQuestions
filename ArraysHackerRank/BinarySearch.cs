namespace ArraysHackerRank;

public class BinarySearch
{
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
    
    
    //--------------------Medium Questions ---------------------------
    public static int FindMin(int[] nums) { //https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            if (nums[m] > nums[r])
                l = m + 1;
            else
                r = m; 
        }
        return nums[l];
    }
    
    
    public static int Search(int[] nums, int target) { //https://leetcode.com/problems/search-in-rotated-sorted-array
        int l = 0, r = nums.Length - 1;
        int m = (r-l)/2+l;
        while(l <= r){
            if(nums[m] == target) return m;
            if(nums[m] < nums[r])
                if(target > nums[m] && target <= nums[r])
                    l = m + 1;
                else r = m - 1;
            else{ 
                if (nums[m] > target && nums[l] <= target)
                    r = m - 1;
                else l = m + 1;
            }
        
            m = (r-l)/2+l;
        }
        return -1;
    }
    
    
    public bool SearchMatrix(int[][] matrix, int target) { //https://leetcode.com/problems/search-a-2d-matrix/
        int l = 0, r = matrix.Length * matrix[0].Length - 1, piv = matrix[0].Length;
        while (l <= r)
        {
            int avg = (r - l) / 2 + l;
            int val = matrix[avg / piv][avg % piv];
            if (val == target) return true;
            else if (val > target) r = avg - 1;
            else l = avg + 1;
        }
        return false;
    }
}