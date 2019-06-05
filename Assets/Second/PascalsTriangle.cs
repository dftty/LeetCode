using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PascalsTriangle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> result = new List<IList<int>>();
        if(numRows == 0) return result;
        result.Add(new List<int>(){1});
        
        for(int i = 2; i <= numRows; i++){
            int[] temp = new int[i];
            temp[0] = temp[i - 1] = 1;
            int lo = 1;
            int hi = i - 2;
            while(lo <= hi){
                temp[lo] = temp[hi] = result[i - 2][lo] + result[i - 2][lo - 1];
                lo++;
                hi--;
            }
            
            result.Add(new List<int>(temp));
        }
        
        return result;
    }
}
