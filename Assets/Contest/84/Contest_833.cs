using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Contest_833 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FindReplaceString("jjievdtjfb", new int[]{4,6,1}, new string[]{"md","tjgb","jf"}, new string[]{"foe","oov","e"});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	struct replace{
		public int index;
		public string sources;
		public string targets;
	}

    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
        StringBuilder sb = new StringBuilder();
        replace[] replaces = new replace[indexes.Length];
		for(int i = 0; i < indexes.Length; i++){
			replaces[i] = new replace();
			replaces[i].index = indexes[i];
			replaces[i].sources = sources[i];
			replaces[i].targets = targets[i];	
		}

        Array.Sort(replaces, (a, b) => a.index - b.index);
        
        int index = 0;
        for(int i = 0; i < replaces.Length; i++){
            for(int j = index; j < replaces[i].index; j++){
                sb.Append(S[j]);
            }
            index = replaces[i].index;
            if(index + replaces[i].sources.Length <= S.Length && replaces[i].sources.Equals(S.Substring(index, replaces[i].sources.Length))){
                index += replaces[i].sources.Length;
                sb.Append(replaces[i].targets);
                continue;
            }
            
        }
        
		for(int i = index; i < S.Length; i++){
			sb.Append(S[i]);
		}

        return sb.ToString();
    }
}
