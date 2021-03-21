using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3679/
  ///   
  /// </summary>
  internal class Mar21
  {
    public class Solution
    {
      public bool ReorderedPowerOf2(int N)
      {
        var hs = new HashSet<string>(
            Enumerable.Range(0, 31)
                .Select(_ => new string(Math.Pow(2, _).ToString().OrderBy(a => a).ToArray()))
        );

        return hs.Contains(new string(N.ToString().OrderBy(a => a).ToArray()));
      }
    }
  }
}
