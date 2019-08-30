using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedDNASequences : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindRepeatedDnaSequences_("TCCGTCCCCCC");

        int v = 0;
        v |= '1';
        Debug.Log(v);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/repeated-dna-sequences/

    做题反思：做题的时候没有仔细阅读题目要求，导致自己没有注意到题目中只要求长度为10的子字符串
            ，要求找到字符串中所有出现过一次以上的长度为10的子字符串
            示例答案中的两个字符串从左向右的确出现了两次。

    边界情况：遍历时 i + 9 需要小于字符串长度
     */
    public IList<string> FindRepeatedDnaSequences(string s) {
        HashSet<string> hashSet = new HashSet<string>();
        HashSet<string> repeat = new HashSet<string>();
        
        for (int i = 0; i + 9 < s.Length; i++){
            string subS = s.Substring(i, 10);
            if (!hashSet.Add(subS)){
                repeat.Add(subS);
            }
        }
        return new List<string>(repeat);
    }

    /**
    使用2个bit位来记录每个字符
    A 00
    C 01
    G 10
    T 11
    10 个字符组成不会超过最大的int数

    因为只有四种字符，并且字符串的长度为10， 所以可以将字符映射为bit位

    出错记录：ch数组最初用的是char数组，使用的是字符 '1', '2', '3' ，然后强转int，
    强转int之后其实是字符对应的ascii 十进制值，导致出问题。

     */
    public IList<string> FindRepeatedDnaSequences_(string s) {
        HashSet<int> hashSet = new HashSet<int>();
        HashSet<int> repeat = new HashSet<int>();
        List<string> list = new List<string>();
        int[] ch = new int[26];
        ch['C' - 'A'] = 1;
        ch['G' - 'A'] = 2;
        ch['T' - 'A'] = 3;
        
        for (int i = 0; i + 9 < s.Length; i++){
            int v = 0;
            for (int j = i; j < i + 10; j++){
                v <<= 2;
                v |= ch[s[j] - 'A'];
            }
            if (!hashSet.Add(v) && repeat.Add(v)){
                
                list.Add(s.Substring(i, 10));
            }
            
        }


        
        return list;
    }
}
