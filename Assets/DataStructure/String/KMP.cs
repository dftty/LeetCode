using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMP : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	获取text中所有匹配patten的开始下标
	知乎讲解链接
	https://www.zhihu.com/question/21923021
	 */
	List<int> getMatchList(string text, string patten){
		int[] maxMathcLength = calculateMaxPattenLength(patten);
		List<int> list = new List<int>();

		int count = 0;

		for(int i = 0; i < text.Length; i++){
			while(count > 0 && text[i] != text[count]){
				count = maxMathcLength[count - 1];
			}

			if(text[i] == text[count]){
				count++;
			}

			if(count == patten.Length){
				list.Add(i - patten.Length + 1);
				count = maxMathcLength[count - 1];
			}
		}

		return list;
	}

	/**
	计算KMP匹配字符串的最大匹配数表
	 */
	int[] calculateMaxPattenLength(string patten){
		int[] result = new int[patten.Length];
		int count = 0;

		for(int i = 1; i < patten.Length; i++){
			while(count > 0 && patten[i] != patten[count]){
				count = result[count - 1];
			}

			if(patten[i] == patten[count]){
				count++;
			}

			result[i] = count;
		}

		return result;
	}

	
}
