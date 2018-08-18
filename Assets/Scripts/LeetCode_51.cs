using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_51 : MonoBehaviour {

    void Start(){
        Debug.Log(SolveNQueens(4));
    }

    // Hard https://leetcode.com/problems/n-queens/description/
    // 2018/8/14
    // backtrack
    public IList<IList<string>> SolveNQueens(int n) {
        List<IList<string>> result = new List<IList<string>>();
        if(n == 0) return result;
        List<StringBuilder> temp = new List<StringBuilder>();
        for(int i = 0; i < n; i++){
            StringBuilder sb = new StringBuilder();
            for(int j = 0; j < n; j++){
                sb.Append(".");
            }
            temp.Add(sb);
        }
        
        Find(result, temp, n, 0, 0, 0);
        return result;
    }
    
    public void Find(List<IList<string>> result, List<StringBuilder> temp, int n, int l, int k, int count){
        if(count == n){
            List<string> list = new List<string>();
            for(int i = 0; i < temp.Count; i++){
                list.Add(temp[i].ToString());
            }
            result.Add(list);
        }else{
            // 注意这里i是从l开始，防止出现重复
            for(int i = l; i < n; i++){
                for(int j = 0; j < n; j++){
                    if(isValid(i, j, temp)){
                        temp[i][j] = 'Q';
                        count++;
                        Find(result, temp, n , i, j, count);
                        temp[i][j] = '.';
                        count--;
                    }
                }
            }
        }
    }
    
    public bool isValid(int i, int j, List<StringBuilder> temp){
        for(int k = 0; k < temp.Count; k++){
            if(temp[i][k] == 'Q') return false;
            if(temp[k][j] == 'Q') return false;
        }
        
        int m = i, n = j;
        while(m >= 0 && n >= 0){
            if(temp[m][n] == 'Q') return false;
            m--;
            n--;
        }
        m = i;
        n = j;
        while(m < temp.Count && n >= 0){
            if(temp[m][n] == 'Q') return false;
            m++;
            n--;
        }
        m = i;
        n = j;
        while(m < temp.Count && n < temp.Count){
            if(temp[m][n] == 'Q') return false;
            m++;
            n++;
        }
        m = i;
        n = j;
        while(m >= 0 && n < temp.Count){
            if(temp[m][n] == 'Q') return false;
            m--;
            n++;
        }
        
        return true;
    }



    // Discuss solution 270ms, mine is 1600 ms
    public IList<IList<string>> SolveNQueens_(int n) {
        if(n==0)
            return new List<IList<string>>();
        
        List<IList<string>> res = new List<IList<string>>();
      //  for(int j = 0;j<n;j++)
      //  {
            //iterate through the initial queen position
        //    int[] qys = new int[n];
         //   qys[0]=[j];//seed the initial queen position
        //    if(helper(0, n, qys))
        //    {
         //       res.Add(buildGraph(qys));
          //  }
      //  }
        helper(res, 0, n, new int[n]);
        
        return res;
        
    }
    
    private bool helper(List<IList<string>> res, int row, int n, int[] qys)
    {
        //this helper function takes an existing board position and tries to place a queen, if success
        if(row==n){
            res.Add(BuildGraph(qys));
            return true;
        }
        
        int col;
        bool final = false;
        for(col = 0; col<n;col++){
            //iterate through the columns, trying to place the queen in that column at current row
            bool isSafe = true;
            //iterate through each row until this one, one queen per row
            for(int i = 0;i<row;i++)
            {
                if(col==qys[i]||col+row==i+qys[i]||col-row==qys[i]-i)//3 situations where queen is not safe
                {
                    isSafe = false;
                    break;// this column is not safe, break out of this and considers the next column 
                }
            }
            
            //current column 
            if(isSafe)
            {
                //this column is safe to place the queen in this row in
                qys[row]=col;
                //proceed to the next queen
                isSafe = helper( res,row+1, n, qys);
            }
            final = isSafe;
        }
        
        //after all the columns, if still safe return
        return final;
    }
    
    private List<string> BuildGraph(int[] pos)
    {
        //helper function to build the graphical representaiton of the position
        List<string> res = new List<string>();
        foreach(int p in pos)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            while(i<pos.Length)
            {
                if(i!=p)
                sb.Append(".");
                else
                    sb.Append("Q");
                i++;
            }
            res.Add(sb.ToString());
        }
        return res;
    }
}


