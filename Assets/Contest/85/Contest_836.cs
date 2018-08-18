using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_836 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
        
		if(rec2[2] >= rec1[2] && rec2[3] >= rec1[3] && rec1[2] > rec2[0] && rec1[3] > rec2[1]){
			return true;
		}

		//if(rec1[0] <= rec2[0] && rec1[3] >= rec2[3] && rec1[2] > rec2[0] && rec1[1] )

		return false;
    }
}
