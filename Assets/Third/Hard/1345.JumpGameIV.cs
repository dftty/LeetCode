using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class JumpGameIV : MonoBehaviour
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
        https://leetcode.com/problems/jump-game-iv/
        Hard
        Tag: 广度优先搜索

        Contest解法：可以将本题想成搜寻最短路径

        */
        public int MinJumps(int[] arr) {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            int n = arr.Length;
            for (int i = 0; i < n; i++){
                if (dic.ContainsKey(arr[i])){
                    dic[arr[i]].Add(i);
                }else{
                    List<int> list = new List<int>(){i};
                    dic.Add(arr[i], list);
                }
            }
            
            bool[] vis = new bool[n];
            vis[0] = true;
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            int step = 0;
            while (q.Count > 0){
                int len = q.Count;
                for (int i = 0; i < len; i++){
                    int index = q.Dequeue();
                    
                    if (index == n - 1){
                        return step;
                    }
                    
                    List<int> list = dic[arr[index]];
                    list.Add(index - 1);
                    list.Add(index + 1);
                    
                    foreach (int j in list){
                        if (j >= 0 && j < n && !vis[j]){
                            q.Enqueue(j);
                            vis[j] = true;
                        }
                    }
                    
                    list.Clear();
                }
                step++;
            }
            
            return 0;
        }
    }

}