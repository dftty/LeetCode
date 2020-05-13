using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third 
{

    public class MinimumTimetoCollectAllApplesinaTree : MonoBehaviour
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
        https://leetcode.com/problems/minimum-time-to-collect-all-apples-in-a-tree/
        Tag: Tree DFS

        思路：根据题意，需要自己保存每个节点可以到达的目标节点，因此创建一个字典来保存每个节点可以到达的节点的集合。
        在遍历edges时，正向反向都需要进行保存。
        在dfs时，使用一个bool数组来标记某个节点是否已经遍历过。

        */
        public int MinTime(int n, int[][] edges, IList<bool> hasApple) {
            Dictionary<int, HashSet<int>> dic = new Dictionary<int, HashSet<int>>();
            bool[] explore = new bool[n];
            for (int i = 0; i < edges.Length; i++){
                int[] array = edges[i];
                if (!dic.ContainsKey(array[0])) {
                    dic.Add(array[0], new HashSet<int>());
                }
                if (!dic.ContainsKey(array[1])) {
                    dic.Add(array[1], new HashSet<int>());
                }
                dic[array[0]].Add(array[1]);
                dic[array[1]].Add(array[0]);
            }
            
            return dfs(0, 0, hasApple, dic, explore);
        }
        
        int dfs(int n, int myCost, IList<bool> hasApple, Dictionary<int, HashSet<int>> dic, bool[] explore){
            if (explore[n]){
                return 0;
            }
            
            explore[n] = true;
            int res = 0;
            
            foreach (int num in dic[n]){
                res += dfs(num, 2, hasApple, dic, explore);
            }
            
            if (res == 0 && !hasApple[n]){
                return 0;
            }
            
            return res + myCost;
        }
    }

}