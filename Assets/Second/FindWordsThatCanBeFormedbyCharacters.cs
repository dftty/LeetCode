using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWordsThatCanBeFormedbyCharacters : MonoBehaviour
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
    https://leetcode.com/problems/find-words-that-can-be-formed-by-characters/

    创建一个int数组对chars每个字符计数，然后和words中的字符数量进行比较
     */
    public int CountCharacters(string[] words, string chars) {
        int[] counts = new int[26];
        
        foreach (char c in chars){
            counts[c - 'a']++;
        }
        
        int res = 0;
        for (int i = 0; i < words.Length; i++){
            int[] wordCount = new int[26];
            foreach (char c in words[i]){
                wordCount[c - 'a']++;
            }
            
            bool formed = true;
            for (int j = 0; j < 26; j++){
                if (wordCount[j] > counts[j]){
                    formed = false;
                }
            }
            
            if (formed){
                res += words[i].Length;
            }
        }
        
        return res;
    }
}
