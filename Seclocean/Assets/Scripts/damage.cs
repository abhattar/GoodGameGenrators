using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col)
    {
            if(col.isTrigger){
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
						scoreSaver.health = scoreSaver.health - 20 ;
                }
              
            }      	   
    }
}
