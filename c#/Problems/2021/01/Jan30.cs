using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/583/week-5-january-29th-january-31st/3622/
  ///    https://leetcode.com/submissions/detail/449630351/?from=explore&item_id=3622
  /// </summary>
  internal class Jan30
  {
    public class Solution
    {
      public int MinimumDeviation(int[] nums)
      {
        var arr = new SortedSet<(int n, int max)>();

        // reduce arr elements to their min values
        // also saving max possible values
        for (var i = 0; i < nums.Length; i++)
        {
          var value = nums[i];

          if (value % 2 == 0)
          {
            while (value % 2 == 0)
              value /= 2;

            arr.Add((value, nums[i]));
          }
          else
          {
            arr.Add((value, nums[i] * 2));
          }
        }

        var ans = arr.Max.n - arr.Min.n;

        // try increment minimum element
        while (true)
        {
          if (arr.Min.n == arr.Min.max)
            break;

          var min = arr.Min.n;
          min <<= 1;

          var el = arr.Min;
          arr.Remove(el);
          arr.Add((n: min, max: el.max));

          ans = Math.Min(ans, arr.Max.n - arr.Min.n);
        }

        return ans;
      }
    }
  }
}

