using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_71 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(SimplifyPath("/.."));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string SimplifyPath(string path) {
        StringBuilder sb = new StringBuilder();
        
        int i = 0;
        Stack<string> s = new Stack<string>();
        while(i < path.Length){
            int count = 0;
            if(i < path.Length && path[i] == '/'){
                i++;
                continue;
            }
            
            while(i < path.Length &&path[i] == '.'){
                i++;
                count++;
            }
            if(count == 2 && i < path.Length && path[i] == '/'){
                if(s.Count > 0) s.Pop();
                continue;
            }else if(count == 1 && i < path.Length && path[i] == '/'){
                continue;
            }else if(count == 2 && i == path.Length){
				if(s.Count > 0) s.Pop();
				continue;
			}else if(count == 1 && i == path.Length){
				continue;
			}
            
            while(i < path.Length && path[i] != '.' && path[i] != '/') {
                i++;
                count++;
            }
            s.Push(path.Substring(i - count, count));
        }
        
        
        while(s.Count > 0){
			sb.Insert(0, "/" + s.Pop());
		}
        
        return sb.Length > 0 ? sb.ToString() : "/";
    }
}
