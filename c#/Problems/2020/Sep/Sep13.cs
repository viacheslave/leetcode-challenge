﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///		https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3458/
  ///		https://leetcode.com/submissions/detail/394989583/?from=/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3458/
  ///	</summary>
  internal class Sep13
  {
    /*
    [[1,2],[3,5],[6,7],[8,10],[12,16]]
    [4,8]
    */

    public class Solution 
    {
      public int[][] Insert(int[][] intervals, int[] newInterval) 
      {
        var res = new List<int[]>();
        
        if (intervals.Length == 0)
          return new int[][] {newInterval};
        
        bool processed = false;
        bool processing = false;
        int start = 0;
        int end = 0;
        
        for (var i = 0; i < intervals.Length; i++)
        {
          var current = intervals[i];
          
          if (processed)
          {
            res.Add(current);
            continue;
          }
          
          if (processing)
          {
            if (end < current[0])
            {
              res.Add(new int[] {start, end});
              processed = true;
              processing = false;
              res.Add(current);
              continue;
            }
            
            if (end <= current[1])
            {
              res.Add(new int[] {start, current[1]});
              processed = true;
              processing = false;
              continue;
            }
            
            if (i == intervals.Length - 1)
            {
              res.Add(new int[] {start, end});
            } 
            
            continue;
          }
          
          // before
          if (newInterval[1] < current[0])
          {
            res.Add(newInterval);
            res.Add(current);
            processed = true;
            processing = false;
            
            continue;
          }
          
          // after
          if (newInterval[0] > current[1])
          {
            res.Add(current);
            
            if (i == intervals.Length - 1)
            {
              res.Add(newInterval);
            } 
            
            continue;
          }
          
          // inside
          if (newInterval[0] >= current[0] && newInterval[1] <= current[1])
          {
            res.Add(current);
            processed = true;
            processing = false;
            continue;
          }
          
          if (newInterval[0] <= current[0])
          {
            if (newInterval[1] <= current[1])
            {
              res.Add(new int[] {newInterval[0], current[1]});
              processed = true;
              processing = false;
              continue;
            }
            
            start = newInterval[0] < current[0] ? newInterval[0] : current[0];
            end = newInterval[1];
            processing = true;
            processed = false;
            
            if (i == intervals.Length - 1)
            {
              res.Add(new int[] {start, end});
            }          
            
            continue;
          }
          
          if (newInterval[0] > current[0])
          {
            start = current[0];
            end = newInterval[1];
            processing = true;
            processed = false;
            
            if (i == intervals.Length - 1)
            {
              res.Add(new int[] {start, end});
            }
            
            continue;
          }
          
          
        }
        
        return res.ToArray();
      }
    }
  }
}
