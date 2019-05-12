using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBoundedInCircle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Robot Bounded In Circle
	 */
	public bool IsRobotBounded(string instructions) {
        int[][] dirs = new int[4][]{new int[]{0, 1}, new int[]{-1, 0}, new int[]{0, -1}, new int[]{1, 0}};
        
        int curDir = 0;
        int[] startPosition = new int[2]{0, 0};
        for(int i = 0; i < 4; i++){
            for(int j = 0; j < instructions.Length; j++){
                if(instructions[j] == 'G'){
                    startPosition[0] += dirs[curDir][0];
                    startPosition[1] += dirs[curDir][1];
                }else if(instructions[j] == 'L'){
                    curDir += 1;
                    curDir = curDir % 4;
                }else{
                    curDir -= 1;
                    curDir = curDir < 0 ? 3 : curDir;
                }
            }
            
            if(startPosition[0] == 0 && startPosition[1] == 0){
                return true;
            }
        }
        
        return false;
    }
}
