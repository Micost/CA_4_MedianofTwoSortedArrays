using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_4_MedianofTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = { 1, 2 ,3 };
            int[] a2 = { 4, 5, 6 };
            Solution s1 = new Solution();
            Console.WriteLine(s1.FindMedianSortedArrays_v2(a1, a2));
            var a = Console.Read();
        }
    }
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int l1 = nums1.Length;
            int l2 = nums2.Length;
            int lenth = l1 + l2;
            int m = lenth / 2;
            int j = 0;
            int k = 0;
            int result1 = 0;
            int result2 = 0;
            int temp = 0;
            if (2 * m == lenth)
            {
                for (int i = 0; i <= m; i++)
                {
                    if (j == l1)
                    {
                        temp = nums2[k];
                        k++;
                    }
                    else if (k == l2)
                    {
                        temp = nums1[j];
                        j++;
                    }
                    else
                        if (nums1[j] < nums2[k])
                    {
                        temp = nums1[j];
                        j++;
                    }
                    else
                    {
                        temp = nums2[k];
                        k++;
                    }
                    if (i == m - 1)
                    {
                        result1 = temp;
                    }
                    else if (i == m)
                    {
                        result2 = temp;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= m; i++)
                {
                    if (j == l1)
                    {
                        temp = nums2[k];
                        k++;
                    }
                    else if (k == l2)
                    {
                        temp = nums1[j];
                        j++;
                    }
                    else
                        if (nums1[j] < nums2[k])
                    {
                        temp = nums1[j];
                        j++;
                    }
                    else
                    {
                        temp = nums2[k];
                        k++;
                    }
                    if (i == m)
                    {
                        result1 = temp;
                        result2 = temp;
                    }
                }
            }
            return ((double)result1 + (double)result2) / 2;
        }
        public double MedianArray(int[] nums)
        {
            //Array.Sort(nums);
            if (nums.Length % 2 == 1)
                return nums[nums.Length / 2];
            else
                return ((double)nums[nums.Length / 2 - 1] + (double)nums[nums.Length / 2]) / 2;
        }
        public double FindMedianSortedArrays_v2(int[] nums1, int[] nums2)
        {
            int[] n_short = null;
            int[] n_long = null;
            if (nums1.Length < nums2.Length)
            {
                n_short = nums1;
                n_long = nums2;
            }
            else
            {
                n_short = nums2;
                n_long = nums1;
            }
            if (n_long.Length == 1)
                if (n_short.Length == 1)
                    return ((double)n_long[0] + (double)n_short[0]) / 2;
                else
                    return ((double)n_long[0] ) / 2;
            if (n_short.Length <= 2)
            {
                //Calculate short case
                if (n_long.Length <= 4)
                {
                    int[] newArray = n_long.Concat(n_short).ToArray();
                    Array.Sort(newArray);
                    return MedianArray(newArray);
                }
                else
                {
                    int[] newArray = n_short.Concat(n_long.Skip(n_long.Length / 2 - 1).Take(4 - n_long.Length % 2).ToArray()).ToArray();
                    Array.Sort(newArray);
                    return MedianArray(newArray);
                }
            }
            else
            {
                //shorten the case
                double ml = MedianArray(n_long);
                double ms = MedianArray(n_short);
                if (ml == ms)
                    return ml;
                else if (ml > ms)
                    return FindMedianSortedArrays_v2(n_long.Take(n_long.Length - (n_short.Length / 2 - 1)).ToArray(), n_short.Skip(n_short.Length / 2 - 1).ToArray());
                else
                    return FindMedianSortedArrays_v2(n_short.Take(n_long.Length - (n_short.Length / 2 - 1)).ToArray(), n_long.Skip(n_short.Length / 2 - 1).ToArray());
            }
        }
    }
}
