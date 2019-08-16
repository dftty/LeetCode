using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class AlphabetBoardPath : MonoBehaviour
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
    https://leetcode.com/problems/alphabet-board-path/

    这道题的思路就在于将字符转换为board数组中的坐标点，然后考虑z这个特殊移动情况。

    根据字符计算出对应的数组坐标点，然后如果是z字符，则需要首先移动y值，然后其余首先移动x值，然后移动y值即可
     */
    public string AlphabetBoardPath_(string target) {
        int x = 0, y = 0;
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0; i < target.Length; i++){
            int num = target[i] - 'a';
            int target_x = num / 5;
            int target_y = num % 5;
            
            if(target_x == 5){
                while(target_y < y){
                    sb.Append('L');
                    y--;
                }
            }
            
            while(x != target_x){
                if(x > target_x){
                    sb.Append('U');
                    x--;
                }else{
                    sb.Append('D');
                    x++;
                }
            }
            
            while(y != target_y){
                if(y > target_y){
                    sb.Append('L');
                    y--;
                }else{
                    sb.Append("R");
                    y++;
                }
            }
            
            sb.Append('!');
        }
        
        return sb.ToString();
    }
}
