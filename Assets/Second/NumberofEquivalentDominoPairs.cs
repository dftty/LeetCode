using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberofEquivalentDominoPairs : MonoBehaviour
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
    https://leetcode.com/problems/number-of-equivalent-domino-pairs/

    c# 中类似于c++ 的pair类为KeyValuePair类，可以使用这个类来保存两个值

    
     */
    public int NumEquivDominoPairs(int[][] dominoes) {
        Dictionary<KeyValuePair<int, int>, int> dic = new Dictionary<KeyValuePair<int,int>, int>();
        int res = 0;
        for(int i = 0; i < dominoes.Length; i++){
            int first = dominoes[i][0];
            int second = dominoes[i][1];
            if(first > second){
                int temp = first;
                first = second;
                second = temp;
            }
            
            KeyValuePair<int, int> pair = new KeyValuePair<int, int>(first, second);
            if(dic.ContainsKey(pair)){
                dic[pair]++;
                res += dic[pair];
            }else{
                dic.Add(pair, 0);
            }
        }
        return res;
    }
}
