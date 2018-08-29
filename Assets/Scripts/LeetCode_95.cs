using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_95 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(generateTrees(0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Medium https://leetcode.com/problems/unique-binary-search-trees-ii/description/
    // 2018/7/21
    // Discuss solution DP
	public List<TreeNode> generateTrees(int n) {
        // c# 代码必须添加该行，不然不能通过
        if(n == 0) return new List<TreeNode>();
        return genTrees(1,n);
    }
        
    public List<TreeNode> genTrees (int start, int end)
    {

        List<TreeNode> list = new List<TreeNode>();

        if(start>end)
        {
            list.Add(null);
            return list;
        }
        
        if(start == end){
            list.Add(new TreeNode(start));
            return list;
        }
        
        List<TreeNode> left,right;
        for(int i=start;i<=end;i++)
        {
            
            left = genTrees(start, i-1);
            right = genTrees(i+1,end);
            
            foreach(TreeNode lnode in left)
            {
                foreach (TreeNode rnode in right)
                {
                    TreeNode root = new TreeNode(i);
                    root.left = lnode;
                    root.right = rnode;
                    if(root.left == null && root.right == null){

                    }
                    
                    list.Add(root);
                }
            }
                
        }
        
        return list;
    }
}
