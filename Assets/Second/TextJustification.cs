using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class TextJustification : MonoBehaviour
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
    https://leetcode.com/problems/text-justification/
     */
    public IList<string> FullJustify(string[] words, int maxWidth) {
        IList<string> res = new List<string>();
        
        int start = 0;
        int width = 0;
        int wordCount = 0;
        for(int i = 0; i < words.Length; i++){
            if(width + words[i].Length + wordCount - 1 < maxWidth){
                width += words[i].Length;
                wordCount++;
                
                continue;
            }
            int spaceCount = maxWidth - width;
            int eachSpace = wordCount == 1 ? spaceCount : spaceCount / (wordCount - 1);
            int leftSpace = wordCount == 1 ? 0 : spaceCount - (eachSpace * (wordCount - 1));
            StringBuilder sb = new StringBuilder();
            for(int j = start; j < i - 1; j++){
                sb.Append(words[j]);
                for(int k = 0; k < eachSpace; k++){
                    sb.Append(' ');
                }
                if(leftSpace-- > 0){
                    sb.Append(' ');
                }
            }
            sb.Append(words[i - 1]);
            if(wordCount == 1){
                while(spaceCount-- > 0){
                    sb.Append(' ');
                }
            }
            wordCount = 1;
            res.Add(sb.ToString());
            start = i;
            width = words[i].Length;
        }
        
        StringBuilder sb1 = new StringBuilder();
        for(int i = start; i < words.Length; i++){
            sb1.Append(words[i] + " ");
        }
        if(sb1.Length > maxWidth){
            sb1.Length = maxWidth;
        }
        while(sb1.Length < maxWidth){
            sb1.Append(' ');
        }
        res.Add(sb1.ToString());
        
        return res;
    }
}
