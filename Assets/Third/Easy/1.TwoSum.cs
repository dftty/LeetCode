using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class TwoSum : MonoBehaviour
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
        https://leetcode.com/problems/two-sum/
        Easy
        Tag: 数组 哈希表

        思路： 暴力解法，题意中要求找两个数，因此可以使用两个for循环来解决。
        第一层for循环遍历整个数组，第二层for循环从i + 1开始遍历，如果找到
        这两个数，则返回下标

        关键词：遍历数组
        */
        public int[] TwoSum_My(int[] nums, int target) {
            for (int i = 0; i < nums.Length; i++){
                for (int j = i + 1; j < nums.Length; j++){
                    if (nums[i] + nums[j] == target){
                        return new int[2]{i, j};
                    }
                }
            }
            return null;
        }


        /**
        Discuss 解法
        思路：因为要寻找两个数，因此我们可以考虑使用字典来保存其中一个
        数的值和下标。
            遍历数组，判断字典中是否存在target - nums[i]的值。
        如果没有找到，则把当前数和下标保存到字典中。

        关键点：
            1.字典
        
        注意：C#语言中如果字典中存在该key值，继续添加相同key值会报错误。
        因此添加前需要判断字典中是否已经存在该key。

        */
        public int[] TwoSum_Discuss(int[] nums, int target) {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++){
                if (dic.ContainsKey(target - nums[i])){
                    return new int[2]{dic[target - nums[i]], i};
                }
                
                if (!dic.ContainsKey(nums[i])){
                    dic.Add(nums[i], i);
                }
            }
            
            return null;
        }

    }

}