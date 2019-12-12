using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class SortColors : MonoBehaviour
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
        https://leetcode.com/problems/sort-colors/
        Medium 
        Tag: 数组

        思路：题目中只有三个数字，因此可以使用计数排序来解决

        */
        public void SortColors_(int[] nums) {
            if (nums == null || nums.Length == 0) return ;
            int[] count = new int[3];
            
            for (int i = 0; i < nums.Length; i++){
                count[nums[i]]++;
            }
            
            int cnt = 0;
            for (int i = 0; i < count.Length; i++){
                while(count[i] > 0){
                    nums[cnt++] = i;
                    count[i]--;
                }
            }
        }


        /**
        思路：额外使用两个指针j和k， j代表数组中0的下标，k代表数组中2的下标。

        技巧：在循环中操作数组，可以根据情况将指针后退。

        */
        public void SortColors_D(int[] nums) {
            if (nums == null || nums.Length == 0) return ;
            
            int j = 0, k = nums.Length - 1;
            
            for (int i = 0; i <= k; i++){
                if (nums[i] == 0){
                    Swap(nums, i, j);
                    j++;
                }else if (nums[i] == 2){
                    Swap(nums, i, k);
                    i--;
                    k--;
                }
            }
        }
        
        public void Swap(int[] nums, int i, int j){
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }

}