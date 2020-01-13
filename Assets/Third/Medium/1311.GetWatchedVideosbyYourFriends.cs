using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

    public class GetWatchedVideosbyYourFriends : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Tuple<string,int> tuple = new Tuple<string, int>("", 0);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /**
        https://leetcode.com/problems/get-watched-videos-by-your-friends/
        Medium
        Tag: 广度优先搜索

        提交错误一次：
            原因：对已经遍历过得节点赋值错误

        */
        public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level) {
        
            bool[] check = new bool[friends.Length];
            
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(id);
            check[id] = true;
            
            int curLevel = 0;
            while (queue.Count > 0){
                int count = queue.Count;
                if (curLevel == level){
                    Dictionary<string, int> dic_1 = new Dictionary<string, int>();
                    List<string> list = new List<string>();
                    for (int i = 0; i < count; i++){
                        id = queue.Dequeue();
                        
                        for (int j = 0; j < watchedVideos[id].Count; j++){
                            if (dic_1.ContainsKey(watchedVideos[id][j])){
                                dic_1[watchedVideos[id][j]]++;
                            }else {
                                dic_1.Add(watchedVideos[id][j], 1);
                            }
                        }
                    }

                    List<Tuple<string, int>> tuples = new List<Tuple<string, int>>();

                    foreach (KeyValuePair<string, int> keyValue in dic_1)
                    {
                        tuples.Add(Tuple.Create(keyValue.Key, keyValue.Value));
                    }

                    tuples.Sort((a, b) => {
                        return a.Item2.CompareTo(b.Item2) != 0 ? a.Item2.CompareTo(b.Item2) : string.Compare(a.Item1, b.Item1, StringComparison.Ordinal);
                    });

                    foreach (var tuple in tuples)
                    {
                        list.Add(tuple.Item1);
                    }
                    
                    // SortedDictionary<int, List<string>> sortDic = new SortedDictionary<int, List<string>>();
                    // foreach (KeyValuePair<string, int> keyValue in dic_1){
                    //     if (sortDic.ContainsKey(keyValue.Value)){
                    //         sortDic[keyValue.Value].Add(keyValue.Key);
                    //     }else{
                    //         sortDic.Add(keyValue.Value, new List<string>(){keyValue.Key});
                    //     }
                    // }
                    
                    // foreach (KeyValuePair<int, List<string>> keyValue in sortDic){
                    //     List<string> temp = keyValue.Value;
                    //     temp.Sort();
                    //     list.AddRange(temp);
                    // }
                    
                    return list;
                }                                                        
                
                for (int i = 0; i < count; i++){
                    id = queue.Dequeue();
                    
                    foreach (int num in friends[id]){
                        if (!check[num]){
                            check[num] = true;
                            queue.Enqueue(num);
                        }
                    }
                }
                
                curLevel++;
            }
            return null;
        }
    }

}