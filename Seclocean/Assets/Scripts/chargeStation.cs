using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeStation : MonoBehaviour {

	public GameObject glow;
	private bool angieIn;
	private bool charging;

	// Use this for initialization
	void Start () {
		angieIn = false;
		charging = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(angieIn){
			if(Input.GetKeyDown(KeyCode.Semicolon)){
							
							charging = true;
							GetComponent<Animator>().SetBool("if angie on", true)  ;
           	}
			 
			if(charging){
							if(scoreSaver.health < 123.0f){
                        		scoreSaver.health = scoreSaver.health + 0.25f;
           					 }
							
			}
			
			if(Input.GetKeyUp(KeyCode.Semicolon)){
							scoreSaver.checkPointX = scoreSaver.activeAngie.transform.position.x;
                        	scoreSaver.checkPointY = scoreSaver.activeAngie.transform.position.y;
							charging = false;
							GetComponent<Animator>().SetBool("if angie on", false) ;
           	}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
						
		   if ((col.tag == "Player")|| (col.tag == "PlayerTop")){
			   print("here");
			angieIn = true;
                    
            }
    }

		


	void OnTriggerExit2D(Collider2D col)
    {
        if(col.isTrigger){
			 if ((col.tag == "Player")|| (col.tag == "PlayerTop")){
           		angieIn = false;
			 }
    	}
	}
}
