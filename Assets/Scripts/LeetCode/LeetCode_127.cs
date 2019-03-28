using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_127 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    // Medium https://leetcode.com/problems/word-ladder/description/
    // 2018/7/31
    // Discuss solution use BFS 
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        int level = 1;
        HashSet<string> wordListSet = new HashSet<string>();
        
        foreach(string s in wordList){
            wordListSet.Add(s);
        }
        
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(beginWord);
        queue.Enqueue(null);
        
        HashSet<string> useSet = new HashSet<string>();
        useSet.Add(beginWord);
        
        while(queue.Count > 0){
            string s = queue.Dequeue();
            if(s != null){
                for(int i = 0; i < s.Length; i++){
                    for(int j = 'a'; j <= 'z'; j++){
                        char[] c = s.ToCharArray();
                        c[i] = (char)j;
                        string temp = new string(c);
                        if(temp.Equals(endWord) && wordListSet.Contains(temp)) return level + 1;
                        if(wordListSet.Contains(temp) && !useSet.Contains(temp)){
                            queue.Enqueue(temp);
                            useSet.Add(temp);
                        }
                    }
                }
            }else {
                level++;
                if(queue.Count > 0){
                    queue.Enqueue(null);
                }
            }
        }
        return 0;
    }

}


