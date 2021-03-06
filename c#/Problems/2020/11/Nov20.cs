using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3537/
  ///    https://leetcode.com/submissions/detail/422263373/?from=/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3537/
  /// </summary>
  internal class Nov20
  {
    public class Solution
    {
      public bool Search(int[] nums, int target)
      {
        if (nums.Length == 0)
          return false;

        var pivot = -1;

        for (var i = 0; i < nums.Length - 1; i++)
        {
          if (nums[i] > nums[i + 1])
          {
            pivot = i + 1;
            break;
          }
        }

        if (pivot == -1)
          return BinarySearch(nums, target, 0, nums.Length - 1);

        return BinarySearch(nums, target, 0, pivot - 1) ||
            BinarySearch(nums, target, pivot, nums.Length - 1);
      }

      private bool BinarySearch(int[] nums, int target, int v1, int v2)
      {
        while (true)
        {
          if (v1 == v2)
            return nums[v1] == target;

          if (v2 - v1 == 1)
            return nums[v1] == target || nums[v2] == target;

          var mid = (v1 + v2) / 2;

          if (target < nums[v1] || target > nums[v2])
            return false;

          if (target < nums[mid])
            v2 = mid;
          else
            v1 = mid;
        }
      }
    }
  }
}
