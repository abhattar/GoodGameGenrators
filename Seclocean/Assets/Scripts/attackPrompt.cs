using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPrompt : MonoBehaviour {

	private bool enter;
	private int firstTime;
	// Use this for initialization
	void Start () {
		enter = false;
		firstTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(enter){
			scoreSaver.dialogueOn = true;
			TutorialLevelScript.attackBoxOn = true;
			enter = false;
		}
	}

	
	void OnTriggerEnter2D(Collider2D col){
						
		   if ((col.tag == "Player")|| (col.tag == "PlayerTop")){
			   if(firstTime == 0){ 
				   enter = true;  
			   }
			     firstTime = 1;
            }
    }
}
