using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_865 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	TreeNode res = null;
    int max_h, deep_node;
    
	// Medium https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/description/
	// 2018/7/24
	// Contest No.1 's solution
	// 
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        max_h = -1;
        ComputeDepth(root, 0);
        Find(root, 0);
        return res;
    }
    
    public void ComputeDepth(TreeNode root, int h){
        if(root == null) return;
        
        if(h > max_h){
            max_h = h;
            deep_node = 1;
        }else if(h == max_h){
            deep_node++;
        }
        
        ComputeDepth(root.left, h + 1);
        ComputeDepth(root.right, h + 1);
    }
    
    public int Find(TreeNode root, int depth){
        if(root == null) return 0;
        int x = 0;
        if(depth == max_h){
            x++;
        }
        
        x += Find(root.left, depth + 1);
        x += Find(root.right, depth + 1);
        
        if(x == deep_node){
            if(res == null){
                res = root;
            }
        }
        
        return x;
    }


    // Another solution
    public TreeNode subTree(TreeNode root){
        int tmp = Doit(root);
        return Doit2(root, tmp);
    }

    public int Doit(TreeNode root){
        int tmp1, tmp2;
        if(root == null) return 0;
        tmp1 = Doit(root.left);
        tmp2 = Doit(root.right);
        if(tmp1 > tmp2) return tmp1 + 1;
        else return tmp2 + 1;
    }

    public TreeNode Doit2(TreeNode root, int dep){
        if(root == null) return null;
        if(dep == 1) return root;
        TreeNode tmp1 = Doit2(root.left, dep - 1);
        TreeNode tmp2 = Doit2(root.right, dep - 1);
        if(tmp1 == null) return tmp2;
        else if(tmp2 == null) return tmp1;
        else return root;
    }

}
