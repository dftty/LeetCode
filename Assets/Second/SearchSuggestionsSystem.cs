using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SearchSuggestionsSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SuggestedProducts(new string[]{"bags","baggage","banner","box","cloths"}, "bags");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/search-suggestions-system/

    题意中每次只需要找到三个匹配字符串，因此排序后遍历查找即可

    */
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Array.Sort(products);
        
        IList<IList<string>> res = new List<IList<string>>();
        
        int start = 0;
        
        for (int i = 1; i <= searchWord.Length; i++){
            string temp = searchWord.Substring(0, i);
            
            IList<string> list = new List<string>();
            for (int j = start; j < products.Length; j++){
                if (products[j].StartsWith(temp))
                {
                    for (int k = j; k < products.Length && k < j + 3; k++){
                        if (!products[k].StartsWith(temp))break;
                        list.Add(products[k]);
                    }
                    start = j;
                    break;
                }
                start++;
            }
            
            res.Add(list);
        }
        return res;
    }
}
