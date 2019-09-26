using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class SmallestStringWithSwaps : MonoBehaviour
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
    https://leetcode.com/problems/smallest-string-with-swaps/
    并查集 
    并查集教程： https://bbs.codeaha.com/forum.php?mod=viewthread&tid=11223&fromuid=1
    其中两个重要的方法在下方  union 和find

    可以将所有路径进行分组，分组之后每个组是独立的,所以可以对每个组中的字母进行排序，然后重新组合字符串
     */
    public string SmallestStringWithSwaps_(string s, IList<IList<int>> pairs) {
        int[] uf = new int[s.Length];
        for (int i = 0; i < uf.Length; i++)
        {
            uf[i] = i;
        }

        for (int i = 0; i < pairs.Count; i++)
        {
            union(uf ,pairs[i][0], pairs[i][1]);
        }

        List<List<int>> m = new List<List<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            m.Add(new List<int>());
        }

        for (int i = 0; i < uf.Length; i++)
        {
            m[find(uf, uf[i])].Add(i);
        }

        char[] str = s.ToCharArray();

        foreach (List<int> list in m)
        {
            char[] ch = new char[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                ch[i] = s[list[i]];
            }

            Array.Sort(ch);
            for (int i = 0; i < list.Count; i++)
            {
                str[list[i]] = ch[i];
            }

        }

        return new string(str);
    }

    public void union(int[] uf, int x, int y)
    {
        int index_x = find(uf, x);
        int index_y = find(uf, y);
        if (index_x != index_y)
        {
            uf[index_x] = index_y;
        }
    }

    public int find(int[] uf, int index)
    {
        if (index != uf[index]){
            uf[index] = find(uf, uf[index]); 
        }

        return uf[index];
    }
}
