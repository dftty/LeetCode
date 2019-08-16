using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    BFS 和DFS
     */
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> wordSet = new HashSet<string>(wordList);
        wordSet.Add(beginWord);
        IList<IList<string>> res = new List<IList<string>>();
        Dictionary<string, List<string>> neighbor = new Dictionary<string, List<string>>();
        Dictionary<string, int> distance = new Dictionary<string, int>();
        distance.Add(beginWord, 0);
        bfs(beginWord, endWord, wordSet, neighbor, distance);
        dfs(res, new List<string>(), beginWord, endWord, neighbor, distance);
        
        return res;
    }
    
    void dfs(IList<IList<string>> res, IList<string> solution, string beginWord, string endWord, Dictionary<string, List<string>> neighbors, Dictionary<string, int> distance){
        solution.Add(beginWord);
        
        if(beginWord.Equals(endWord)){
            res.Add(new List<string>(solution));
        }else{
            List<string> list = neighbors[beginWord];
            
            for(int i = 0; i < list.Count; i++){
                if(distance[beginWord] + 1 == distance[list[i]]){
                    dfs(res, solution, list[i], endWord, neighbors, distance);
                }
            }
        }
        
        solution.RemoveAt(solution.Count - 1);
    }
    
    void bfs(string beginWord, string endWord, HashSet<string> wordSet, Dictionary<string, List<string>> neighbors, Dictionary<string, int> distance){
        foreach(string str in wordSet){
            if(neighbors.ContainsKey(str)) continue;
            neighbors.Add(str, new List<string>());
        }
        
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(beginWord);
        
        while(queue.Count > 0){
            int count = queue.Count;
            
            for(int i = 0; i < count; i++){
                string str = queue.Dequeue();
                
                List<string> neiList = GetNeighbor(str, wordSet);
                foreach(string s in neiList){
                    neighbors[str].Add(s);
                    if(!distance.ContainsKey(s)){
                        distance.Add(s, distance[str] + 1);
                        queue.Enqueue(s);
                    }
                }
            }
        }
    }
    
    List<string> GetNeighbor(string str, HashSet<string> wordSet){
        List<string> res = new List<string>();
        char[] ch = str.ToCharArray();
        
        for(int i = 0; i < str.Length; i++){
            for(int j = 'a'; j <= 'z'; j++){
                char old = ch[i];
                ch[i] = (char)j;
                string s = new String(ch);
                if(wordSet.Contains(s)){
                    res.Add(s);
                }
                
                ch[i] = old;
            }
        }
        
        return res;
    }


    /**
    另一种解法， c#会导致TLE异常
     */
    public IList<IList<string>> FindLadders_(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> wordSet = new HashSet<string>();
        for(int i = 0;  i< wordList.Count; i++){
            wordSet.Add(wordList[i]);
        }
        if(!wordSet.Contains(endWord)) return new List<IList<string>>();
        wordSet.Remove(beginWord);
        Queue<List<string>> queue = new Queue<List<string>>();
        List<string> list = new List<string>();
        list.Add(beginWord);
        queue.Enqueue(list);
        queue.Enqueue(null);

        HashSet<string> useWord = new HashSet<string>();
        HashSet<string> tempSet = new HashSet<string>();
        int level = 0, endLevel = int.MinValue;
        while(queue.Count > 0 && endLevel + 1 != level){
            List<string> temp = queue.Dequeue();
            
            if(temp != null){
                string str = temp[temp.Count - 1];
                for(int i = 0; i < str.Length; i++){
                    char[] ch = str.ToCharArray();
                    for(int j = 'a'; j <= 'z'; j++){
                        ch[i] = (char)j;
                        string s = new string(ch);
                        if(endWord.Equals(s) && wordSet.Contains(endWord)){
                            List<string> l = new List<string>(temp);
                            l.Add(s);
                            queue.Enqueue(l);
                            endLevel = level;
                            continue;
                        }

                        if(wordSet.Contains(s) && !useWord.Contains(s)){
                            List<string> l = new List<string>(temp);
                            l.Add(s);
                            queue.Enqueue(l);

                            tempSet.Add(s);
                        }
                    }
                }
            }else{
                level++;
                foreach(string s in tempSet){
                    useWord.Add(s);
                }
                tempSet.Clear();
                if(queue.Count > 0){
                    queue.Enqueue(null);
                }
            }
            
        }

        List<IList<string>> result = new List<IList<string>>();
        while(queue.Count > 0){
            List<string> l = queue.Dequeue();
            if(l != null) {
                if(l[l.Count - 1].Equals(endWord)){
                    result.Add(l);
                }
            }else break;
        }

        return result;
    }
}
