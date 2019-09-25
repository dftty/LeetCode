using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateBinarySearchTree : MonoBehaviour
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
    https://leetcode.com/problems/validate-binary-search-tree/

    递归解题思路，可以将当前最大值和最小值当做参数传递下去进行判断

    O(n) 空间解法
    使用前序遍历将其转化为列表，然后进行判断
     */
    public bool IsValidBST(TreeNode root) {
        List<int> list = new List<int>();
        dfs(root, list);
        for (int i = 1; i < list.Count; i++){
            if (list[i] <= list[i - 1]) return false;
        }
        
        for (int i = list.Count - 1; i >= 1; i--){
            if (list[i] <= list[i - 1]) return false;
        }
        
        return true;
    }
    
    void dfs(TreeNode root, List<int> list){
        if (root == null){
            return;
        }
        
        dfs(root.left, list);
        list.Add(root.val);
        dfs(root.right, list);
    }

    
}
