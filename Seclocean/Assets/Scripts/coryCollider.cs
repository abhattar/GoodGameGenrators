using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coryCollider : MonoBehaviour {

	public GameObject linkedSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	   void OnTriggerStay2D(Collider2D col)
    {
			//print(ya; 
            if(col.isTrigger){
				
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
					if(col.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Angie Bite"))
					{
						if(transform.parent.GetComponent<coryFSM>()!= null)
						transform.parent.GetComponent<coryFSM>().PullTrigger();
					}
					if(linkedSprite.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("attack")){
						if(gameObject.tag == "Projectile")
						scoreSaver.health = scoreSaver.health - 1.0f;
					}
                }
				
            }      	   
    }
}
