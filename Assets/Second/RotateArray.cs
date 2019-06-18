using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateArray : MonoBehaviour
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
    https://leetcode.com/problems/rotate-array/

    O(n) time O(n) space 解法
    申请一个数组，将偏移后的数组值赋给申请的数组，然后再给原数组赋值.
    
     */
    public void Rotate(int[] nums, int k) {
        k = k % nums.Length;
        int len = nums.Length;
        
        int[] temp = new int[len];
        
        for(int i = 0; i < len ; i++){
            temp[(i + k) % len] = nums[i];
        }
        for(int i = 0; i < len ;i++){
            nums[i] = temp[i];
        }
    }

    /**
    Discuss方法， 只需要reverse数组3次即可

    这里应该学会的技巧是 数组的位移可以和reverse方法联系起来
    c# 种reverse方法第三个参数是数量
     */
    public void Rotate_Discuss(int[] nums, int k) {
        k = k % nums.Length;
        

        Array.Reverse(nums, 0, nums.Length);
        Array.Reverse(nums, 0, k);
        Array.Reverse(nums, k, nums.Length - k);
    }

    /**
    Discuss 另一种解法
    startIndex 是内部循环的index
     */
    public void Rotate_2(int[] nums, int k){
        k = k % nums.Length;
        
        int count = 0;
        int currentIndex = 0;
        int startIndex = 0;
        int num = 1;
        while(count < nums.Length){
            num = nums[startIndex];
            do{
                int index = (currentIndex + k) % nums.Length;
                int temp = nums[index];
                nums[index] = num;
                count++;
                num = temp;
                currentIndex = index;
            }while(startIndex != currentIndex);
            startIndex++;
            currentIndex = startIndex;
        }
    }
}
