using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindElementsinaContaminatedBinaryTree : MonoBehaviour
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
    https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree/

    利用dfs恢复二叉树的值，使用set来保存其中出现的值，然后进行判断
    
    */
    public class FindElements {
    
        HashSet<int> vals = new HashSet<int>();

        public FindElements(TreeNode root) {
            if (root == null) return;
            root.val = 0;
            dfs(root);
        }
        
        public bool Find(int target) {
            return vals.Contains(target);
        }
        
        private void dfs(TreeNode root){
            if (root == null){
                return;
            }
            vals.Add(root.val);
            
            if (root.left != null){
                root.left.val = 2 * root.val + 1;
                dfs(root.left);
            }
            
            if (root.right != null){
                root.right.val = 2 * root.val + 2;
                dfs(root.right);
            }
        }
    }

}
