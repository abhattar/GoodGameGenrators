using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthoCannonFSM : MonoBehaviour {

	public int attackTimer;
	public int hitPoints;

	
	private GameObject activeAngie;
	private int initialAttackTimer;
	// Use this for initialization
	void Start () {
		initialAttackTimer = attackTimer;
	}
	
	// Update is called once per frame
	void Update () {
		attackTimer--;
		if(attackTimer <=0){
			attackTimer = initialAttackTimer;
			transform.Find("Side").GetComponent<Animator>().SetTrigger("Attack");
			transform.Find("Top").GetComponent<Animator>().SetTrigger("Attack");
		}

		if(hitPoints<=0){
			print("Imded");
			transform.Find("Side").GetComponent<Animator>().SetTrigger("Death");
			transform.Find("Top").GetComponent<Animator>().SetTrigger("Death");
		}
	}

	    void OnTriggerEnter2D(Collider2D col)
    {
            if(col.isTrigger){
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
                    if(col.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Angie Bite")){
						hitPoints--;
					}
                }
              
            }      	   
    }

	

    

   
}
