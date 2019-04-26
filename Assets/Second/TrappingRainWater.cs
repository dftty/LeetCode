using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrappingRainWater : MonoBehaviour {

	// Use this for initialization
	void Start () {
		trap(new int[]{0,1,0,2,1,0,1,3,2,1,2,1});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Trapping Rain Water

	Two Pointer 解法
	记录左边和右边的当前高度，然后计算。
	 */
	public int Trap(int[] height) {
        int leftHeight = 0;
        int rightHeight = 0;
        int left = 0;
        int right = height.Length - 1;
        int result = 0;
        while(left < right){
            int min = Math.Min(leftHeight, rightHeight);
            int leftResult = min - height[left] >= 0 ? min - height[left] : 0;
            int rightResult = min - height[right] >= 0 ? min - height[right] : 0;
            
            result += leftResult;
            result += rightResult;
            
            leftHeight = Math.Max(leftHeight, height[left]);
            rightHeight = Math.Max(rightHeight, height[right]);
            
            if(height[left] < height[right]){
                left++;
            }else{
                right--;
            }
        }
        
        return result;
    }

    public int Trap_(int[] height) {
        int leftHeight = 0;
        int rightHeight = 0;
        int left = 0;
        int right = height.Length - 1;
        int result = 0;
        while(left < right){
            if(height[left] <= height[right]){
                int leftResult = leftHeight - height[left] >= 0 ? leftHeight - height[left] : 0;
                leftHeight = Math.Max(leftHeight, height[left]);
                result += leftResult;
                left++;
            }else{
                int rightResult = rightHeight - height[right] >= 0 ? rightHeight - height[right] : 0;
                rightHeight = Math.Max(rightHeight, height[right]);
                result += rightResult;
                right--;
            }
        }
        
        return result;
    }

    public int trap(int[] A) {
        if (A==null) return 0;
        Stack<int> s = new Stack<int>();
        int i = 0, maxWater = 0, maxBotWater = 0;
        while (i < A.Length){
            if (s.Count == 0 || A[i]<=A[s.Peek()]){
                s.Push(i++);
            }
            else {
                int bot = s.Pop();
                maxBotWater = s.Count == 0? // empty means no il
                0:(Math.Min(A[s.Peek()],A[i])-A[bot])*(i-s.Peek()-1);
                maxWater += maxBotWater;
            }
        }
        return maxWater;
    }


}
