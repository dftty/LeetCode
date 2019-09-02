using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueBinarySearchTreesII : MonoBehaviour
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
    https://leetcode.com/problems/unique-binary-search-trees-ii/

    二叉搜索树的一个特点就是根节点的左子树中的所有值都小于等于根节点的值，
    右子树中的所有值都大于等于根节点中的值。

    
     */
    public IList<TreeNode> GenerateTrees(int n) {
        if (n == 0) return new List<TreeNode>();
        return generate(1, n);
    }
    
    public List<TreeNode> generate(int s, int e){
        List<TreeNode> res = new List<TreeNode>();
        
        if (s > e){
            res.Add(null);
            return res;
        }
        
        for (int i = s; i <= e; i++){
            List<TreeNode> left = generate(s, i - 1);
            List<TreeNode> right = generate(i + 1, e);
            
            foreach(TreeNode l in left){
                foreach(TreeNode r in right){
                    TreeNode root = new TreeNode(i);
                    root.left = l;
                    root.right = r;
                    res.Add(root);
                }
            }
        }
        
        return res;
    }
}
