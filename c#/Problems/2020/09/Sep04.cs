using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3448/
  ///    https://leetcode.com/submissions/detail/390887531/?from=/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3448/  
  /// </summary>
  internal class Sep04
  {
    public class Solution
    {
      public IList<int> PartitionLabels(string S)
      {
        var partitions = new List<(int, int)>();
        var chMap = new Dictionary<char, int>();

        var chStart = 0;

        for (int i = 0; i < S.Length; i++)
        {
          var ch = S[i];
          var exists = chMap.TryGetValue(ch, out var pos);

          if (!exists)
          {
            chMap[ch] = i;
            partitions.Add((chStart, i));

            chStart = i + 1;
            continue;
          }

          if (pos >= chStart)
          {
            chMap[ch] = i;
            continue;
          }

          chMap[ch] = i;
          chStart = Merge(partitions, pos);

          partitions.Add((chStart, i));
          chStart = i + 1;
        }

        return partitions.Select(_ => _.Item2 - _.Item1 + 1).ToArray();
      }

      private int Merge(List<(int, int)> partitions, int pos)
      {
        var partitionIndex = -1;
        for (int i = 0; i < partitions.Count; i++)
        {
          if (partitions[i].Item1 <= pos && pos <= partitions[i].Item2)
          {
            partitionIndex = i;
            break;
          }
        }

        for (int i = partitions.Count - 1; i >= 0; i--)
        {
          if (i >= partitionIndex)
            partitions.RemoveAt(i);
        }

        return partitions.Count > 0 ? partitions[partitions.Count - 1].Item2 + 1 : 0;
      }
    }
  }
}
