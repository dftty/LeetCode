using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_100 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool same = true;
    
    // Easy https://leetcode.com/problems/same-tree/description/
    // 2018/7/9
    // 使用任意一种遍历方法都可以检查
    public bool IsSameTree(TreeNode p, TreeNode q) {
        check(p, q);
        return same;
    }
    
    void check(TreeNode p, TreeNode q){
        if(p == null && q != null){
            same = false;
            return;
        }
        if(p != null && q == null){
            same = false;
            return;
        }
        
        if(p == null && q == null){
            return ;
        }
        if(p != null && q != null){
            if(p.val != q.val){
                same = false;
            }
        }
        
        check(p.left, q.left);
        check(p.right, q.right);
    }

    // Discuss solution
    public bool isSameTree_(TreeNode p, TreeNode q) {
        if(p == null && q == null) return true;
        if(p == null || q == null) return false;
        if(p.val == q.val)
            return isSameTree_(p.left, q.left) && isSameTree_(p.right, q.right);
        return false;
    }
    
    
}
