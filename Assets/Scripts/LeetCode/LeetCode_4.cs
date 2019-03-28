using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(FindMedianSortedArrays(new int[]{1, 2}, new int[]{3, 4}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Hard https://leetcode.com/problems/median-of-two-sorted-arrays/description/
	// 2018/3/28
	// 首先将两个数组 都重置为升序排序
	// 然后将nums1 和nums2 组合为一个新的数组
	public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        double result = 0;
        if(nums1 == null || nums1.Length == 0){
            if(nums2 != null){
                if(nums2.Length % 2 == 0){
                    result = ((double)(nums2[nums2.Length / 2] + nums2[nums2.Length / 2 - 1])) / 2;
                }else{
                    result = nums2[nums2.Length / 2];
                }
                return result;
            }
        }
        
        
        
        if(nums2 == null || nums2.Length == 0){
            if(nums1 != null){
                if(nums1.Length % 2 == 0){
                    result = ((double)(nums1[nums1.Length / 2] + nums1[nums1.Length / 2 - 1])) / 2;
                }else{
                    result = nums1[nums1.Length / 2];
                }
                
                return result;
            }
        }
        
        if(nums1[0] > nums1[nums1.Length - 1]){
            int lo = 0;
            int hi = nums1.Length;
            while(lo < hi){
                int temp = nums1[lo];
                nums1[lo] = nums1[hi];
                nums1[hi] = temp;
                lo++;
                hi--;
            }
        }
        
        if(nums2[0] > nums2[nums2.Length - 1]){
            int lo = 0;
            int hi = nums2.Length;
            while(lo < hi){
                int temp = nums2[lo];
                nums2[lo] = nums2[hi];
                nums2[hi] = temp;
                lo++;
                hi--;
            }
        }
        
        int[] newarray = combine(nums1, nums2);
        
        if(newarray.Length % 2 == 0){
            result = ((double)(newarray[newarray.Length / 2] + newarray[newarray.Length / 2 - 1])) / 2;
        }else{
            result = newarray[newarray.Length / 2];
        }
        
        return result;
        
    }

	int[] combine(int[] nums1, int[] nums2){
		int[] newarray = new int[nums1.Length + nums2.Length];
        
        for(int i = 0, j = 0, k = 0; i < nums1.Length + nums2.Length; i++){
			if(j == nums1.Length){
				newarray[i] = nums2[k++];
			}else if(k == nums2.Length){
				newarray[i] = nums1[j++];
			}else{
				if(nums1[j] > nums2[k]){
					newarray[i] = nums2[k++];
				}else{
					newarray[i] = nums1[j++];
				}
			}

        }

		return newarray;
	}
}
