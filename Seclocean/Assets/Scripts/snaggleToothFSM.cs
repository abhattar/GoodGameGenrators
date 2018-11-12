using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snaggleToothFSM : MonoBehaviour {

	public int hitPoints;

	public float speedValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(hitPoints == 0) {
			 GetComponent<Animator>().SetTrigger("Bite");
		}

		for()

		
	}

	    void OnTriggerEnter2D(Collider2D col)
    {
            if(col.isTrigger){
                if (col.tag == "Player" || col.tag == "PlayerTop"){
                    if (col.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Angie Bite")) { 
                        hitPoints--;
                    }
                    else{
                       
                    }
                }
                else if (col.tag == "BlackPearl"){
                    scoreSaver.blackpearls++;
                    Destroy(col.gameObject);
                }
            }

            	   
    }
}
