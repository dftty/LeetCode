using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Contest_811 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string[] temp = new string[]{"900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"};
		Debug.Log(SubdomainVisits(temp));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IList<string> SubdomainVisits(string[] cpdomains) {
        IList<string> result = new List<string>();
    
		Dictionary<string, int> temp = new Dictionary<string, int>();

		for(int i = 0; i < cpdomains.Length; i++){
			string[] first = cpdomains[i].Split(' ');

			string[] second = first[1].Split('.');

			StringBuilder sb = new StringBuilder();
			for(int j = second.Length - 1; j >= 0; j--){
				if(j != second.Length - 1) sb.Insert(0, ".");
				sb.Insert(0 ,second[j]);
				if(temp.ContainsKey(sb.ToString())){
					temp[sb.ToString()] = temp[sb.ToString()] + int.Parse(first[0]);
				}else{
					temp.Add(sb.ToString(), int.Parse(first[0]));
				}
			}
		}

		foreach(KeyValuePair<string, int> value in temp){
			StringBuilder sb = new StringBuilder();
			sb.Append(value.Value);
			sb.Append(" ");
			sb.Append(value.Value);
			result.Add(sb.ToString());
		}

		return result;
	}
}
