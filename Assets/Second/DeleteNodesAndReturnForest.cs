using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNodesAndReturnForest : MonoBehaviour
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
    https://leetcode.com/problems/delete-nodes-and-return-forest/

    在题目中看到了distinct，就应该思考HashSet对于解题是否会有帮助
    然后对于树类型的题目，首要解法就是递归，利用递归的函数返回值可以达成各种想要达到的条件
    本题，使用HashSet保存要删除的节点，然后我们在递归的时候遇到要删除的节点，那么我们就返回null，否则就返回节点本身.
    Discuss解法
     */
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        IList<TreeNode> res = new List<TreeNode>();
        if (root == null) return res;
        HashSet<int> hashSet = new HashSet<int>();
        foreach(int val in to_delete){
            hashSet.Add(val);
        }
        
        if (!hashSet.Contains(root.val)) res.Add(root);
        dfs(root, hashSet, res);
        
        return res;
    }
    
    TreeNode dfs(TreeNode node, HashSet<int> hashSet, IList<TreeNode> res){
        if (node == null) return null;
        
        node.left = dfs(node.left, hashSet, res);
        node.right = dfs(node.right, hashSet, res);
        
        if (hashSet.Contains(node.val)){
            if (node.left != null) res.Add(node.left);
            if (node.right != null) res.Add(node.right);
            
            return null;
        }
        
        return node;
    }
}
