using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_830 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(LargeGroupPositions("aaabbb"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IList<IList<int>> LargeGroupPositions(string S) {
        IList<IList<int>> result = new List<IList<int>>();

		int count = 1;
		int start = 0;

		for(int i = 1; i < S.Length; i++){
			if(S[i] == S[i - 1]){
				count++;
				if(i == S.Length - 1 && count >= 3){
					List<int> temp = new List<int>();
					temp.Add(start);
					temp.Add(i);
					result.Add(temp);
				}
				continue;
			}else {
				if(count >= 3){
					List<int> temp = new List<int>();
					temp.Add(start);
					temp.Add(i - 1);
					result.Add(temp);
				}
				count = 1;
				start = i;
			}
		}

		return result;
    }
}
