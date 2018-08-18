using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_118 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/pascals-triangle/description/
	// 2018/2/12
	public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> result = new List<IList<int>>();
        
        for(int i = 1; i <= numRows; i++){
            List<int> temp = new List<int>();
            for(int j = 0; j < i; j++){
                if(j == 0){
                    temp.Add(1);
                }else if(j == (i - 1)){
                    temp.Add(1);   
                }else{
                    List<int> last = result[i - 2] as List<int>;
                    temp.Add(last[j] + last[j - 1]);
                }
            }
            
            result.Add(temp);
        }
        
        return result;
    }
}
