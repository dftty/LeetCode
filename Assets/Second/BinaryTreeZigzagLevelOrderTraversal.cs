using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTreeZigzagLevelOrderTraversal : MonoBehaviour
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
    https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/

    使用一个数字记录当前行数,用于判断奇偶
     */
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int num = 0;
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null) return res;
        while(queue.Count > 0){
            int len = queue.Count;
            IList<int> temp = new List<int>();
            for (int i = 0; i < len; i++){
                TreeNode node = queue.Dequeue();
                if (num % 2 == 0){
                    temp.Add(node.val);
                }else{
                    temp.Insert(0, node.val);
                }
                
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            res.Add(temp);
            num++;
        }
        
        return res;
    }
}
