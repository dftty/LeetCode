using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class RemoveDuplicatesfromSortedArrayII : MonoBehaviour
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
        https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
        Medium 
        Tag: 数组

        */
        public int RemoveDuplicates(int[] nums) {
            if (nums == null || nums.Length == 0) return 0;
            int index = 1;
            int count = 1;
            int last = nums[0];
            
            for (int i = 1; i < nums.Length; i++){
                if (nums[i] == last && count < 2){
                    nums[index++] = last;
                    count++;
                }
                
                if (nums[i] != last){
                    last = nums[i];
                    count = 1;
                    nums[index++] = last;
                }
            }
            
            return index;
        }

        /**
        更加简洁的写法

        */
        public int RemoveDuplicates__(int[] nums) {
            if (nums == null || nums.Length == 0) return 0;
            
            int index = 0;
            for (int i = 0; i < nums.Length; i++){
                if (index < 2 || nums[i] > nums[index - 2]){
                    nums[index++] = nums[i];
                }
            }
            
            return index;
        }
    }

}