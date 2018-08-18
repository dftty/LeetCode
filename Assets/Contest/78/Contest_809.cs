using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_809 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(ExpressiveWords("dddiiiinnssssssoooo", new string[]{"dinnssoo","ddinso","ddiinnso","ddiinnssoo","ddiinso","dinsoo","ddiinsso","dinssoo","dinso"}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// dd -> ddd是ok的
	public int ExpressiveWords(string S, string[] words) {
		int second = 0;
		int firstNum = 1;
		int secondNum = 1;

		int result = 0;
		for(int j = 0; j < words.Length; j++){
			int i = 0;
			second = 0;
			if(words[i] == null) continue;
			while(i < S.Length && second < words[j].Length){
				while(i < S.Length - 1 && S[i] == S[i + 1]){
					firstNum++;
					i++;
				}
				i++;
				while(second < words[j].Length - 1 && words[j][second] == words[j][second + 1]){
					secondNum++;
					second++;
				}
				second++;


				
				if(firstNum < 3 && firstNum == secondNum && S[i - 1] == words[j][second - 1]){
					firstNum = secondNum = 1;
					if(i == S.Length) result++;
					continue;
				}else {
					if(S[i - 1] == words[j][second - 1] && firstNum - 3 >= secondNum - 1){
						firstNum = secondNum = 1;
						if(i == S.Length) result++;
						continue;
					}else {
						firstNum = secondNum = 1;
						break;
					}
				}
			}
		}

		return result;
		
    }


}
