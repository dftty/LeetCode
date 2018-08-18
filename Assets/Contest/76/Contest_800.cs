using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class Contest_800 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(SimilarRGB("#09f166"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string SimilarRGB(string color) {
        char[] colors = color.ToCharArray();

		StringBuilder result = new StringBuilder();
		result.Append("#");

		
		GetResult(1, 2, result, colors);
		GetResult(3, 4, result, colors);
		GetResult(5, 6, result, colors);

		return result.ToString();
    }

	void GetResult(int left, int right, StringBuilder result, char[] colors){
		StringBuilder temp = new StringBuilder();
		
		if(colors[left] == colors[right]){
			result.Append(colors[left]);
			result.Append(colors[left]);
		}else{
			temp.Append(colors[left]);
			temp.Append(colors[right]);

			int first = int.Parse(temp.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);

			int low = first - 1;
			int hi = first + 1;
			while(low >= 0 || hi <= 255){
				if(low >= 0){
					String fir = Convert.ToString(low, 16);
					if(fir.Length == 2 && fir[0] == fir[1]){
						result.Append(fir[0]);
						result.Append(fir[0]);
						break;
					}else if(fir.Length == 1 && fir[0] == '0'){
						result.Append(fir[0]);
						result.Append(fir[0]);
						break;
					}
				}

				if(hi <= 255){
					String fir = Convert.ToString(hi, 16);
					if(fir.Length == 2 && fir[0] == fir[1]){
						result.Append(fir[0]);
						result.Append(fir[0]);
						break;
					}else if(fir.Length == 1 && fir[0] == '0'){
						result.Append(fir[0]);
						result.Append(fir[0]);
						break;
					}
				}

				low--;
				hi++;
			}
		}
	}

	
}
