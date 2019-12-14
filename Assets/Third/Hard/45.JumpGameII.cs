using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class JumpGameII : MonoBehaviour
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
        https://leetcode.com/problems/jump-game-ii/
        Hard
        Tag: 数组 贪心

        思路：类似于bfs，遍历时记录下一步会达到的最远距离。
        curEnd 表示本轮bfs的结束点，   curFastest表示本轮中遍历出的下一轮最远节点。

        提交错误次数：0次
        */
        public int Jump(int[] nums) {
            int res = 0, curEnd = 0, curFastest = 0;
            
            for (int i = 0; i < nums.Length - 1; i++){
                curFastest = Math.Max(curFastest, i + nums[i]);
                
                if (i == curEnd){
                    res++;
                    curEnd = curFastest;
                }
            }
            
            return res;
        }

        /**
        c++ 实现
        int jump(vector<int>& nums) {
            int res = 0, curEnd = 0, curFastest = 0;
            
            for (int i = 0 ;i < nums.size() - 1; i++){
                curFastest = max(curFastest, nums[i] + i);
                if (i == curEnd){
                    res++;
                    curEnd = curFastest;
                }
            }
            
            return res;
        }

        */

    }

}