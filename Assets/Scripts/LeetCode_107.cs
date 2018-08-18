using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_107 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int depth = 0;

    // Easy https://leetcode.com/problems/binary-tree-level-order-traversal-ii/description/
    // 2018/7/10
    // 使用前序遍历从上到下添加，然后将列表反转
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        List<IList<int>> result = new List<IList<int>>();
        Compute(0, root, result);
        result.Reverse();
        return result;
    }
    
    public void Compute(int deep, TreeNode root, IList<IList<int>> result){
        if(root == null) return ;
        
        if(result.Count <= deep){
            List<int> temp = new  List<int>();
            temp.Add(root.val);
            result.Add(temp);
        }else{
            result[deep].Add(root.val);
        }
        
        Compute(++deep, root.left, result);
        Compute(deep, root.right, result);
        
        return;
    }
}
