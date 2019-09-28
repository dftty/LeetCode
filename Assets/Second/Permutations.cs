using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permutations : MonoBehaviour
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
    https://leetcode.com/problems/permutations/

    回溯法，增加一个HashSet判断已经出现的元素
     */
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        if (nums == null || nums.Length == 0) return res;
        Recurision(new HashSet<int>(), res, new List<int>(), nums);
        return res;
    }
    
    public void Recurision(HashSet<int> hashSet, IList<IList<int>> res, IList<int> list, int[] nums){
        if (list.Count == nums.Length){
            res.Add(new List<int>(list));
            return ;
        }
        
        for (int i = 0; i < nums.Length; i++){
            if (hashSet.Contains(nums[i])) continue;
            list.Add(nums[i]);
            hashSet.Add(nums[i]);
            Recurision(hashSet, res, list, nums);
            list.RemoveAt(list.Count - 1);
            hashSet.Remove(nums[i]);
        }
    }
}
