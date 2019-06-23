using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class ZigZagConversion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Convert("PAYPALISHIRING", 3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/zigzag-conversion/

    "PAYPALISHIRING"  3

    P   A   H   N
    A P L S I I G   这是完整组
    Y   I   R           

    P   
    A P   这是单个组
    Y  

    可以将转换后的字符串想象成一个二维char数组，每个字符代表数组中的一个char值，然后可以将组成Z的上面横线和斜线看成一个组
    对于上面的字符串，可以将其分为四组，最后一组不完整
     */
    public string Convert(string s, int numRows) {
        if(numRows == 1 || numRows < 1 || s == null) return s;
        // 每组中单个字母的列数
        int single = numRows - 2;
        
        // 首先计算完整组的列数
        int col = (s.Length / (numRows + single)) * (1 + single);
        // 除去完整组剩余字母数量
        int left = s.Length % (numRows + single);
        // 所有的列数
        col = col + (left > numRows ? 1 + left - numRows : 1);
        char[,] c = new char[numRows, col];
        
        // 组的长度
        int totalGroupLength = s.Length / (numRows + single) + (left > 0 ? 1 : 0);
        // 单个完整组的列数
        int singleGroupCol = 1 + single;
        // 当前遍历到的列数
        int currentCol = 0;
        // 当前字符串下标
        int charIndex = 0;
        for(int i = 0; i < totalGroupLength; i++){
            for(int j = 0; j < numRows; j++){
                if(charIndex == s.Length) break;
                c[j,currentCol] = s[charIndex++];
            }
            currentCol++;
            int singleRow = numRows - 2;
            for(int j = 0; j < single; j++){
                if(charIndex == s.Length) break;
                c[singleRow--,currentCol++] = s[charIndex++];
            }
        }
        
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < numRows; i++){
            for(int j = 0; j < col; j++){
                if(c[i,j] != '\0'){
                    sb.Append(c[i,j]);
                }
            }
        }
        
        return sb.ToString();
    }
}
