using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class AllElementsinTwoBinarySearchTrees : MonoBehaviour
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
        https://leetcode.com/problems/all-elements-in-two-binary-search-trees/
        Tag: 树

        思路：使用深度优先搜索将两个树中的元素遍历到两个list中，然后遍历两个list求结果

        */
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
            List<int> first = new List<int>();
            Dfs(first, root1);
            List<int> second = new List<int>();
            Dfs(second, root2);
            
            List<int> res = new List<int>();
            int i = 0, j = 0;
            while (i < first.Count || j < second.Count){
                if (i < first.Count && j < second.Count){
                    if (first[i] > second[j]){
                        res.Add(second[j++]);
                    }else{
                        res.Add(first[i++]);
                    }
                }else if (i < first.Count){
                    res.Add(first[i++]);
                }else{
                    res.Add(second[j++]);
                }
            }
            return res;
        }
        
        void Dfs(List<int> list, TreeNode root){
            if (root == null) return ;
            
            Dfs(list, root.left);
            list.Add(root.val);
            Dfs(list, root.right);
            
        }
    }

}