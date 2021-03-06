using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3535/
  ///    https://leetcode.com/submissions/detail/421575093/?from=/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3535/
  /// </summary>
  internal class Nov18
  {
    public class Solution
    {
      public int[][] Merge(int[][] intervals)
      {
        intervals = intervals.OrderBy(el => el[0]).ToArray();

        if (intervals.Length == 0)
          return new int[0][];

        if (intervals.Length == 1)
          return intervals;

        var res = new List<int[]>();
        var start = -1;
        var end = -1;

        for (var i = 0; i < intervals.Length - 1; i++)
        {
          if (start == -1)
          {
            start = intervals[i][0];
            end = intervals[i][1];
          }

          if (end >= intervals[i + 1][0])
          {
            end = Math.Max(end, intervals[i + 1][1]);
            if (i + 1 == intervals.Length - 1)
            {
              res.Add(new int[] { start, end });
            }
            continue;
          }

          res.Add(new int[] { start, end });
          start = -1;
          end = -1;
        }

        if (start == -1)
        {
          res.Add(new int[] { intervals[intervals.Length - 1][0], intervals[intervals.Length - 1][1] });
        }

        return res.ToArray();
      }
    }
  }
}
