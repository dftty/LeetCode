using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_2_3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetPrime_Stand(100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GetPrime(int maxCount){
		List<int> prime = new List<int>(){2, 3, 5};

		for(int i = 5; i < maxCount; i++){
			if(i % 2 == 0 || i % 3 == 0){
				continue;
			}

			for(int j = 0; j < prime.Count; j++){
				if((prime[j] << 1) > i){
					prime.Add(i);
					break;
				}

				if(i % prime[j] == 0){
					break;
				}
			}
		}

		for(int i = 0; i < prime.Count; i++){
			Debug.Log(prime[i]);
		}
	}

	void GetPrime_Stand(int maxCount){
		List<int> prime = new List<int>(){2, 3, 5};

		int gap = 2;
		int may_prime = 5;

		while(prime.Count < maxCount){
			may_prime += gap;
			gap = 6 - gap;

			for(int i = 0; i < prime.Count; i++){
				if((prime[i] << 1) > may_prime){
					prime.Add(may_prime);
					break;
				}

				if(may_prime % prime[i] == 0){
					break;
				}
			}
		}

		for(int i = 0; i < prime.Count; i++){
			Debug.Log(prime[i]);
		}
	}
}
