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
        https://leetcode.com/problems/maximum-candies-you-can-get-from-boxes/
        Hard
        Tag:  广度优先搜索

        思路：使用广度优先搜索，从initiabox开始遍历，直到找到所有的可打开盒子
        remainBox 剩余没有取蜡烛的盒子
        hasKeys 记录当前拥有的钥匙
        hasBox 记录当前拥有的上锁的，但是没有找到钥匙的盒子

        错误记录：2次， TLE错误
            问题原因：队列中可能出现重复的盒子下标，遍历的时候没有进行判断是否已经取出盒子的蜡烛
            导致TLE问题。

        改进： 可以使用status记录找到的钥匙，移除hasKeys表

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

                //  如果已经取过该盒子，则跳过
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