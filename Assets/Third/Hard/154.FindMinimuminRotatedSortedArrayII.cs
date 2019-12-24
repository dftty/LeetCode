using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class FindMinimuminRotatedSortedArrayII : MonoBehaviour
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
        https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/

        */
        public int FindMin(int[] nums) {
            if (nums == null || nums.Length == 0) return 0;
            int lo = 0, hi = nums.Length - 1;
            
            while (lo < hi){
                int mid = lo + (hi - lo) / 2;
                
                if (nums[mid] > nums[hi]){
                    lo = mid + 1;
                }else if (nums[mid] < nums[hi]){
                    hi = mid;
                }else{
                    hi--;
                }
            }
            
            return nums[lo];
        }
    }

}