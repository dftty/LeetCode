using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlantingWithNoAdjacent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	使用字典来保存路径即可
	 */
	public int[] GardenNoAdj(int N, int[][] paths) {
        Dictionary<int, List<int>> pathsDic = new Dictionary<int, List<int>>();
        
        for(int i = 0; i < paths.Length; i++){
            if(pathsDic.ContainsKey(paths[i][0])){
                pathsDic[paths[i][0]].Add(paths[i][1]);
            }else{
                List<int> temp = new List<int>(){paths[i][1]};
                pathsDic.Add(paths[i][0], temp);
            }
            
            if(pathsDic.ContainsKey(paths[i][1])){
                pathsDic[paths[i][1]].Add(paths[i][0]);
            }else{
                List<int> temp = new List<int>(){paths[i][0]};
                pathsDic.Add(paths[i][1], temp);
            }
        }
        
        int[] result = new int[N];
        for(int i = 1; i <= N; i++){
            List<int> list = new List<int>(){1, 2, 3, 4};
            
            if(pathsDic.ContainsKey(i)){
                List<int> path = pathsDic[i];
                foreach(int j in path){
                    list.Remove(result[j - 1]);
                }
                
                result[i - 1] = list[0];
            }else{
                result[i - 1] = list[0];
            }
        }
        
        return result;
    }
}
