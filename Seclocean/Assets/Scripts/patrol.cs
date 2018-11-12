using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour {

	private float timer;
	private bool turn;
	// Use this for initialization
	void Start () {
		timer = 200;
		turn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0){
			if(!turn){
				transform.Translate(new Vector3(0.07f,0,0)  * Time.deltaTime);
			}
			else if (turn){
				transform.Translate(new Vector3(-0.07f,0,0)  * Time.deltaTime);
			}
			timer--;
		}
		else if(timer == 0){
			timer=200;
			turn = !turn;
		}

	}
}
