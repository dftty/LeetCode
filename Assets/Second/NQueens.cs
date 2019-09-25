using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NQueens : MonoBehaviour
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
    https://leetcode.com/problems/n-queens/

    经典回溯算法题
     */
    public IList<IList<string>> SolveNQueens(int n) {
        IList<IList<string>> res = new List<IList<string>>();
        IList<char[]> list = new List<char[]>();
        
        for (int i = 0; i < n; i++){
            char[] ch = new char[n];
            for (int j = 0; j < ch.Length; j++){
                ch[j] = '.';
            }
            list.Add(ch);
        }
        BackTrack(res, list, 0);
        
        return res;
    }
    
    void BackTrack(IList<IList<string>> res, IList<char[]> list, int row){
        if (row == list.Count){
            IList<string> temp = new List<string>();
            foreach(char[] ch in list){
                temp.Add(new string(ch));
            }
            
            res.Add(temp);
            return;
        }
        
        for (int col = 0; col < list.Count; col++){
            if (!Check(row, col, list)){
                list[row][col] = 'Q';
                BackTrack(res, list, row + 1);
                list[row][col] = '.';
            }
        }
    }
    
    /// <summary>
    /// 判断是否成立
    /// </summary>
    /// <returns></returns>
    bool Check(int row, int col, IList<char[]> list){
        
        // 判断列
        for (int i = 0; i < row; i++){
            if (list[i][col] == 'Q'){
                return true;
            }
        }
        
        // 判断45度方向，仅需要判断左下角，因为右上角还没有遍历到
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--){
            if (list[i][j] == 'Q'){
                return true;
            }
        }
        
        // 判断135度方向，仅需要判断右下角，上方还没有遍历到
        for (int i = row - 1, j = col + 1; i >= 0 && j < list.Count; i--, j++){
            if (list[i][j] == 'Q'){
                return true;
            }
        }
        
        return false;
    }
}
