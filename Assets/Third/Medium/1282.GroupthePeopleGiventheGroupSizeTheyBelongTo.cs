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

        提交错误 1次
            错误原因：cost[i][j] = cost[i + 1][j - 1] + (s[i] == s[j] ? 0 : 1);
            上述代码后面三目运算符没有添加括号，导致+号的运算优先于 == 出错

        int cost[110][110];

        int palindromePartition(string s, int k) {
            for (int i = 0; i < s.size() - 1; i++){
                cost[i][i + 1] = s[i] == s[i + 1] ? 0 : 1;
            }
            
            for (int m = 2; m <= s.size(); m++){
                for (int i = 0; i + m <= s.size(); i++){
                    int j = i + m - 1;
                    cost[i][j] = cost[i + 1][j - 1] + (s[i] == s[j] ? 0 : 1);
                    if (m == 4)
                        cout << cost[i][j] << endl;
                }
            }
            
            // for (int i = 0; i < s.size(); i++){
            //     for (int j = i; j < s.size(); j++){
            //         cost[i][j] = go(s, i, j);
            //     }
            // }
            
            vector<vector<int>> dp(s.size() + 1, vector(k + 1, 1 << 29));
            dp[0][0] = 0;
            for (int i = 1; i <= s.size(); i++){
                for (int j = 1; j <= k; j++){
                    for (int x = 0; x < i; x++){
                        dp[i][j] = min(dp[i][j], dp[x][j - 1] + cost[x][i - 1]);
                    }
                }
            }
            
            return dp[s.size()][k];
        }
        
        int go(string s, int x, int y){
            int res = 0;
            while (x < y){
                if (s[x] != s[y]){
                    res++;
                }
                
                x++;
                y--;
            }
            
            return res;
        }

        */
    }

}