using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Third
{

    public class GroupthePeopleGiventheGroupSizeTheyBelongTo : MonoBehaviour
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
        https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
        Medium
        Tag: 贪心

        思路:使用一个字典来保存组中人数相同的组的列表，字典的key是组的人数，value是所有的组
        每次遍历到相同人数的组的人，向最后人数不满的组中添加，如果没有，则新创建一个组。
        */
        public IList<IList<int>> GroupThePeople(int[] g) {
            IList<IList<int>> res = new List<IList<int>>();
            
            Dictionary<int, IList<IList<int>>> dic = new Dictionary<int, IList<IList<int>>>();
            
            for (int i = 0; i < g.Length; i++){
                if (!dic.ContainsKey(g[i])){
                    IList<IList<int>> temp = new List<IList<int>>();
                    temp.Add(new List<int>(){i});
                    dic.Add(g[i], temp);
                }else {
                    var temp = dic[g[i]];
                    
                    bool added = false;
                    for (int j = 0; j < temp.Count; j++){
                        if (temp[j].Count < g[i]){
                            temp[j].Add(i);
                            added = true;
                        }
                    }
                    
                    if (!added){
                        temp.Add(new List<int>(){i});
                    }
                }
            }
            
            foreach (IList<IList<int>> values in dic.Values){
                foreach (IList<int> list in values){
                    res.Add(list);
                }
            }
            
            return res;
        }

        /**
        
        思路：字典的key保存组的人数，value保存所有人的ID列表，
        然后遍历字典构建分组

        */
        public IList<IList<int>> GroupThePeople_(int[] g) {
            IList<IList<int>> res = new List<IList<int>>();
            
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            
            for (int i = 0; i < g.Length; i++){
                if (dic.ContainsKey(g[i])){
                    dic[g[i]].Add(i);
                }else{
                    dic.Add(g[i], new List<int>(){i});
                }
            }
            
            foreach (var list in dic){
                for (int i = 0; i < list.Value.Count / list.Key; i++){
                    IList<int> temp = new List<int>();
                    for (int j = 0; j < list.Key; j++){
                        temp.Add(list.Value[j]);
                    }
                    
                    list.Value.RemoveRange(0, list.Key);
                    res.Add(temp);
                }
            }
            
            return res;
        }

        /**
        c++ 实现
        vector<vector<int>> groupThePeople(vector<int>& groupSizes) {
            vector<vector<int>> res, group(groupSizes.size(), vector<int>());
            
            for (int i = 0; i < groupSizes.size(); i++){
                group[groupSizes[i] - 1].push_back(i);
                if (group[groupSizes[i] - 1].size() == groupSizes[i]){
                    res.push_back({});
                    swap(res.back(), group[groupSizes[i] - 1]);
                }
            }
            
            return res;
        }

        */

    }

}