using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaximumLevelSumofaBinaryTree : MonoBehaviour
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
    https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/
    BFS 每次计算当前层的sum然后比较即可
     */
    public int MaxLevelSum(TreeNode root) {
        if (root == null) return 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        int maxLevel = 1;
        int maxSum = root.val;
        queue.Enqueue(root);
        int currentLevel = 1;
        while (queue.Count > 0){
            int count = queue.Count;
            int sum = 0;
            for (int i = 0; i < count; i++){
                TreeNode node = queue.Dequeue();
                sum += node.val;
                if (node.left != null){
                    queue.Enqueue(node.left);
                }
                
                if (node.right != null){
                    queue.Enqueue(node.right);
                }
            }
            
            if (sum > maxSum){
                maxLevel = currentLevel;
                maxSum = sum;
            }
            currentLevel++;
        }
        
        return maxLevel;
    }


    /**
    深度优先搜索解法
     */
    List<int> sums = new List<int>();
    public int MaxLevelSum_DFS(TreeNode root) {
        Dfs(root, 0);
        int res = 0;
        int sum = 0;
        for (int i = 0; i < sums.Count; i++){
            if (sums[i] > sum){
                res = i;
                sum = sums[i];
            }
        }
        
        return res + 1;
    }
    
    void Dfs(TreeNode root, int level){
        if (root == null) return ;
        while(sums.Count - 1 < level){
            sums.Add(0);
        }
        
        sums[level] += root.val;
        Dfs(root.left, level + 1);
        Dfs(root.right, level + 1);
    }
}
