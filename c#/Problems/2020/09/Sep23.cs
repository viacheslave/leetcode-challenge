using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.September.Challenge.Problems
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3470/
  /// </summary>
  internal class Sep23
  {
    public class Solution
    {
      public int CanCompleteCircuit(int[] gas, int[] cost)
      {
        if (gas.Sum() < cost.Sum())
          return -1;

        for (var start = 0; start < gas.Length; start++)
        {
          var counter = 0;
          var currentPos = start + counter;
          var accum = 0;
          var possible = true;

          while (counter < gas.Length)
          {
            accum += gas[currentPos % gas.Length] - cost[currentPos % gas.Length];
            if (accum < 0)
            {
              possible = false;
              break;
            }

            counter++;
            currentPos = start + counter;
          }

          if (possible)
            return start;
        }

        return -1;
      }
    }
  }
}
