using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_911 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Init(new int[]{0,1,1,0,0,1,0}, new int[]{0,5,10,15,20,25,30});
		Q(12);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int[] leading;
    public int[] times;
    
    public void Init(int[] persons, int[] times_) {
        leading = new int[persons.Length];
        times = times_;
        leading[0] = persons[0];
        int maxVote = 1;
        Dictionary<int, int> voteDic = new Dictionary<int, int>();
        voteDic.Add(persons[0], 1);
        for(int i = 1; i < persons.Length; i++){
            if(voteDic.ContainsKey(persons[i])){
                voteDic[persons[i]]++;
                if(voteDic[persons[i]] >= maxVote){
                    maxVote = voteDic[persons[i]];
                    leading[i] = persons[i];
                }else{
                    leading[i] = leading[i - 1];
                }
            }else{
                voteDic.Add(persons[i], 1);
                if(maxVote == 1){
                    leading[i] = persons[i];
                }else{
                    leading[i] = leading[i - 1];
                }
            }
        }
    }
    
    public int Q(int t) {
        int index = Find(t);
        //return index;
        return leading[index];
    }
    
    public int Find(int t){
        if(t >= times[times.Length - 1]){
            return times.Length - 1;
        }
        
        int lo = 0; 
        int hi = times.Length - 1;
        while(lo < hi){
            int mid = (lo + hi) / 2;
            if(t == times[mid]) return mid;
            if(mid < times.Length - 1 && t > times[mid] && t < times[mid + 1]) return mid;
            if(t > times[mid]){
                lo = mid;
            }else{
				hi = mid;
            }
        }
        return 0;
    }
}
