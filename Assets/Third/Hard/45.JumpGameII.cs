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

        思路：

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

    }

}