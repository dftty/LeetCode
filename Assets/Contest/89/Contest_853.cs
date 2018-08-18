using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Contest_853 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(CarFleet(12, new int[]{10,8,0,5,3}, new int[]{2,4,1,1,3}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int CarFleet(int target, int[] position, int[] speed) {
        if(position == null || speed == null || position.Length == 0) return 0;
        
        car[] cars = new car[speed.Length];
        for(int i = 0; i < position.Length; i++){
            car temp = new car();
            temp.position = position[i];
            temp.speed = speed[i];
            cars[i] = temp;
        }
        
        Array.Sort(cars, (a, b) => a.position - b.position);
        
        List<car> result = new List<car>();
        result.Add(cars[cars.Length - 1]);
        for(int i = cars.Length - 2; i >= 0; i--){
            car car1 = result[result.Count - 1];
            float time1 = (float)(target - car1.position) / (float)car1.speed;
            float time2 = (float)(target - cars[i].position) / (float)cars[i].speed;
            if(time1 >= time2){
                car1.position = cars[i].position;
            }else{
                result.Add(cars[i]);
            }
        }
        
        return result.Count;
    }
    
    struct car{
        public int position;
        public int speed;
    }
}
