using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_894 : MonoBehaviour {

    void Start(){
        
    }

    // Medium https://leetcode.com/problems/all-possible-full-binary-trees/description/
    // 2018/8/27
    // discuss solution 
    // 
    public IList<TreeNode> AllPossibleFBT(int N) {
        IList<TreeNode> result = new List<TreeNode>();
        
        if(N == 1){
            result.Add(new TreeNode(0));
            return result;
        }
        
        N = N - 1;
        for(int i = 1; i < N; i+= 2){
            IList<TreeNode> left = AllPossibleFBT(i);
            IList<TreeNode> right = AllPossibleFBT(N - i);
            
            foreach(TreeNode l in left){
                foreach(TreeNode r in right){
                    TreeNode tree = new TreeNode(0);
                    tree.left = l;
                    tree.right = r;
                    result.Add(tree);
                }
            }
        }
        
        return result;
    }

}


