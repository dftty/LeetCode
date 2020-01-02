using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class WordLadderII : MonoBehaviour
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
        https://leetcode.com/problems/word-ladder-ii/
        Hard
        Tag: 数组 字符串 广度优先搜索

        思路：
        */
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
            IList<IList<string>> res = new List<IList<string>>();
            
            HashSet<string> wordSet = new HashSet<string>(wordList);
            if (!wordSet.Contains(endWord)){
                return res;
            }
            wordSet.Remove(beginWord);
            
            var dic = new Dictionary<string, List<List<string>>>();
            List<string> init = new List<string>(){beginWord};
            dic.Add(beginWord, new List<List<string>>(){ init });
            
            bool found = false;
            HashSet<string> start = new HashSet<string>();
            start.Add(beginWord);
            while (start.Count > 0 && !found && wordSet.Count > 0){
                
                HashSet<string> newStart = new HashSet<string>();
                foreach (string str in start){
                    char[] ch = str.ToCharArray();
                    for (int i = 0; i < ch.Length; i++){
                        char temp = ch[i];
                        for (char c = 'a'; c <= 'z'; c++){
                            ch[i] = c;
                            string newStr = new string(ch);
                            
                            if (!wordSet.Contains(newStr)) continue;
                            
                            newStart.Add(newStr);
                            List<List<string>> list = dic[str];
                            foreach (List<string> l in list){
                                List<string> newList = new List<string>(l);
                                newList.Add(newStr);
                                if (!dic.ContainsKey(newStr)){
                                    dic.Add(newStr, new List<List<string>>(){newList});
                                }else{
                                    dic[newStr].Add(newList);
                                }
                                
                                if (newStr == endWord){
                                    res.Add(newList);
                                    found = true;
                                }
                            }
                        }
                        ch[i] = temp;
                    }
                }
                
                foreach (string str in newStart){
                    wordSet.Remove(str);
                }
                
                start = newStart;
            }
            
            return res;
        }

        public IList<IList<string>> FindLadders_(string beginWord, string endWord, IList<string> wordList) {
            var ans = new List<IList<string>>();
            HashSet<string> dict = new HashSet<string>(wordList);
            if (!dict.Contains(endWord)) return ans;   // endWord不在wordList中，无法找到解
            int l = beginWord.Length;
            var set1 = new HashSet<string>(); 
            set1.Add(beginWord); //set1把beginWord加入作为初始，控制循环。
            var set2 = new HashSet<string>(); 
            set2.Add(endWord); //set2把endWord加入作为初始，控制循环。
            var children = new Dictionary<string, List<string>>(); //存储每个单词的children(就是能扩展成哪些词),从父->子是正向,不需要stack倒序了。
            bool found = false; //记录当前层是否已经找到一个解
            bool backword = false; //记录是否是反向的扩展

            while (set1.Count != 0 && set2.Count != 0 && !found) {
                if (set1.Count > set2.Count) { // 小技巧，选短的一边当"正向",另一边算"逆向"
                    swap(ref set1, ref set2);
                    backword = !backword;
                }
                foreach (string w in set1) dict.Remove(w); // 将扩展出来的词都删掉，这样以后就不会扩展出同样的词了
                foreach (string w in set2) dict.Remove(w);
                var set = new HashSet<string>(); // 临时变量set.退出循环时候会自动回收掉
                foreach (string word in set1) {
                    char[] cur = word.ToCharArray();
                    for (int i = 0; i < l; i++) {
                        char ch = cur[i];
                        for (char j = 'a'; j <= 'z'; j++) {
                            cur[i] = j;
                            string newWord = new string(cur);
                            string parent = (!backword) ? word : newWord;
                            string child = (!backword) ? newWord : word;
                            if (set2.Contains(newWord)) {
                                found = true; // 一边set找到了另一边set包含的词，那就是找到了。
                                AddOrUpdateDictionary(children, parent, child);
                            } else if (dict.Contains(newWord) && !found) {
                                set.Add(newWord);
                                AddOrUpdateDictionary(children, parent, child);
                            }
                        }
                        cur[i] = ch;
                    }
                }
                set1 = set;
            }
            if (found) {
                List<string> path = new List<string>(); path.Add(beginWord);
                getPaths(beginWord, endWord, children, path, ans);
            }
            return ans;
        }
        public static void AddOrUpdateDictionary(System.Collections.Generic.Dictionary<string, List<string>> dict, string key, string value) {
            if (dict.ContainsKey(key)) dict[key].Add(value);   // 这样可以更新value的值
            else {
                var _list = new List<string>(); 
                _list.Add(value); 
                dict.Add(key, _list); // 新建列表,存入value
            }
        }
        public static void getPaths(string word, string endWord,
            Dictionary<string, List<string>> children, List<string> path, List<IList<string>> ans) {   // DFS产生结果
            if (word == endWord) { // 如果word=endWord,表示找完一条路径了
                var curCopy = new List<string>(path); //注意不能直接把path引用加入ans,要创建一个copy加入。因为后面path会被修改。
                ans.Add(curCopy);
                return; // 这条路径加入ans后，函数返回，递归继续调用。
            }
            if (!children.ContainsKey(word)) return;
            var it = children[word];
            foreach (string child in it) {   // 对于word的所有child迭代
                path.Add(child); // path先加入这个child
                getPaths(child, endWord, children, path, ans);  //递归求child的child.
                path.Remove(child);  // 递归调用后把之前加入的临时child删掉，这样就一层一层退回到分叉点 children[key(hot),value(dot,lot)]
            }
        }
        public static void swap(ref HashSet<string> set1, ref HashSet<string> set2) {
            var t = set1; set1 = set2; set2 = t;
        }
    }

}