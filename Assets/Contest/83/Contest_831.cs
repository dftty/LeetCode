using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Contest_831 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(MaskPII("86-(10)12345678"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string MaskPII(string S) {
        StringBuilder sb = new StringBuilder();

		string num = "0123456789";

		if(S.Contains("@")){
			string[] strs = S.Split('@');
			strs[0] = strs[0].ToLower();
			sb.Append(strs[0][0]);
			sb.Append("*****");
			sb.Append(strs[0][strs[0].Length - 1]);
			sb.Append("@");
			sb.Append(strs[1].ToLower());
		}else{
			StringBuilder temp = new StringBuilder();
			for(int i = 0; i < S.Length; i++){
				if(num.Contains(S[i].ToString())){
					temp.Append(S[i]);
				}
			}

			if(temp.Length > 10){
				int countryCode = temp.Length - 10;

				sb.Append("+");
				for(int i = 0; i < countryCode; i++){
					sb.Append("*");
				}
				sb.Append("-***-***-");
				sb.Append(temp.ToString().Substring(countryCode + 6, 4));
			}else{
				sb.Append("***-***-");
				sb.Append(temp.ToString().Substring(6, 4));
			}
		}

		return sb.ToString();
    }
}
