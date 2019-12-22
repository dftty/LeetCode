using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class FirstMissingPositive : MonoBehaviour
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
        https://leetcode.com/problems/first-missing-positive/
        Hard
        Tag: 数组

        思路：想不到解决方案，因此看了提示1，先想一个O(n)空间的解决方案，
        可以定义一个数组arr， arr[i] = 1 表示数字i + 1 存在，0表示不存在，
        如果在nums中有超过nums.Length 的数字，则无需考虑，如果nums中出现
        一个这种数字，那么arr中一定存在一个下标 m， a[m] = 0. 答案就是m + 1
        如果nums中正好出现了前nums.Length 个数字，那么arr数组值全部为1，缺失的数字为
        nums.Length + 1

        技巧： 利用额外的一个数组来记录出现的数字。

        提交错误次数：2次
            1. 没有考虑空数组输入 
                https://leetcode.com/submissions/detail/283862395/
            2. 情况考虑不周全，当数组为 [1]时，返回值错误
                https://leetcode.com/submissions/detail/283863392/
        */
        public int FirstMissingPositive_(int[] nums) {
            if (nums == null || nums.Length == 0) return 1;
            int[] arr = new int[nums.Length];
            
            for (int i = 0; i < nums.Length; i++){
                if (nums[i] > 0 && nums[i] <= nums.Length){
                    arr[nums[i] - 1] = 1;
                }
            }
            
            for (int i = 0; i < arr.Length; i++){
                if (arr[i] == 0){
                    return i + 1;
                }
            }
            
            return nums.Length + 1;
        }

        /**
        Discuss 解法 O(1) space

        思路：使用原数组来保存找到的数字，实现了O(1)空间解法

        */
        public int FirstMissingPositive_D(int[] nums) {
            if (nums == null || nums.Length == 0) return 1;
            
            for (int i = 0; i < nums.Length; i++){
                while(nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i]){
                    Swap(nums, nums[i] - 1, i);
                }
            }
            
            for (int i = 0; i < nums.Length; i++){
                if (nums[i] != i + 1){
                    return i + 1;
                }
            }
            
            return nums.Length + 1;
        }
        
        public void Swap(int[] arr, int a, int b){
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        /**
        c++ 实现
        int firstMissingPositive(vector<int>& nums) {
            if (nums.size() == 0) return 1;
            
            for (int i = 0; i < nums.size(); i++){
                while (nums[i] - 1 >= 0 && nums[i] - 1 < nums.size() && nums[i] != nums[nums[i] - 1]){
                    swap(nums[i], nums[nums[i] - 1]);
                }
            }
            
            for (int i = 0; i < nums.size(); i++){
                if (nums[i] != i + 1){
                    return i + 1;
                }
            }
            
            return nums.size() + 1;
        }

        */
    }

}