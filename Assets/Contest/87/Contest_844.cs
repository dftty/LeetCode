using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Contest_844 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool BackspaceCompare(string S, string T) {
        StringBuilder sbS = new StringBuilder();
        StringBuilder sbT = new StringBuilder();
        
        int countS = 0;
        for(int i = S.Length - 1; i >= 0; i--){
            if(S[i] != '#'){
                if(countS > 0){
                    countS--;
                }else{
                    sbS.Append(S[i]);
                }
            }else{
                countS++;
            }
        }
        
        int countT = 0;
        for(int i = T.Length - 1; i >=0; i--){
            if(T[i] != '#'){
                if(countT > 0){
                    countT--;
                }else{
                    sbT.Append(T[i]);
                }
            }else{
                countT++;
            }
        }
        
        return sbS.ToString().Equals(sbT.ToString());
    }
}
