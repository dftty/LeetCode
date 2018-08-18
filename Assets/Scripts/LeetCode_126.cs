using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_126 : MonoBehaviour {

    void Start(){
        List<string> list = new List<string>(){"hot","cog","dog","tot","hog","hop","pot","dot"};
        FindLadders("hot", "dog", list);
    }

    // Hard https://leetcode.com/problems/word-ladder-ii/description/
    // 2018/8/7
    // use bfs
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
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


