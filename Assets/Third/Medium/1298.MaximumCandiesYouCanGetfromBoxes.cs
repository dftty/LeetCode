using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Third
{

    public class MaximumCandiesYouCanGetfromBoxes : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /**
        https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers/
        Medium
        Tag: 数组 贪心

        思路：使用一个字典来保存每个数字对应的set列表

        */
        public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
            HashSet<int> remainBox = new HashSet<int>();
            HashSet<int> hasKeys = new HashSet<int>();
            HashSet<int> hasBox = new HashSet<int>();

            for (int i = 0; i < status.Length; i++){
                remainBox.Add(i);
            }

            Queue<int> q = new Queue<int>();
            for (int i = 0; i < initialBoxes.Length; i++){
                q.Enqueue(initialBoxes[i]);
            }

            int sum = 0;
            while (q.Count > 0){
                int index = q.Dequeue();
                if (!remainBox.Contains(index)) continue;
                if (status[index] == 0 && !hasKeys.Contains(index)){
                    hasBox.Add(index);
                    continue;
                }

                remainBox.Remove(index);
                hasKeys.Remove(index);

                sum += candies[index];

                for (int i = 0; i < keys[index].Length; i++){
                    hasKeys.Add(keys[index][i]);
                    if (hasBox.Contains(keys[index][i]) && remainBox.Contains(keys[index][i])){
                        q.Enqueue(keys[index][i]);
                    }
                }

                for (int i = 0; i < containedBoxes[index].Length; i++){
                    if (remainBox.Contains(containedBoxes[index][i])){
                        q.Enqueue(containedBoxes[index][i]);
                    }
                }
            }

            return sum;
        }
    }

}