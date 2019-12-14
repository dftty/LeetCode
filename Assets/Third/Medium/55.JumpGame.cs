using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class JumpGame : MonoBehaviour
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
        https://leetcode.com/problems/jump-game/
        Medium
        Tag: 数组 贪心

        思路：使用一个变量记录上一步和这一步之间的最大值，然后每次遍历，改值减一

        提交错误次数：1次
            https://leetcode.com/submissions/detail/284544442/
            题意理解错误
        */
        public bool CanJump(int[] nums) {
            if (nums == null || nums.Length == 0) return true;
            
            int last = 1;
            for (int i = 0; i < nums.Length; i++){
                last--;
                last = Math.Max(last, nums[i]);
                
                if (i == nums.Length - 1) return true;
                
                if (last == 0){
                    return false;
                }
            }
            return true;
        }
    }

}