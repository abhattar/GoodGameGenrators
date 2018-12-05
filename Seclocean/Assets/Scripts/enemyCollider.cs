using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollider : MonoBehaviour {

	public GameObject attachedEnemy;

	public float damage;
	private bool bloodSpat;
	private int Timer;

	// Use this for initialization
	void Start () {
		Timer = 60;
		bloodSpat = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(scoreSaver.health >= 50)
		{
			if(bloodSpat && (Timer > 0)){
			
				scoreSaver.bloodSplatLightActive = true;
				Timer--;
				
			}
			else if(bloodSpat && (Timer <= 0 ))
			{
		
				scoreSaver.bloodSplatLightActive = false;
				Timer = 60;
				bloodSpat = false;
			}
		}
		else if(scoreSaver.health > 1){
			scoreSaver.bloodSplatLightActive = false;
				
			if(bloodSpat && (Timer > 0)){

									scoreSaver.bloodSplatDarkActive = true;
									Timer--;
									
			}
			else if(bloodSpat && (Timer <= 0 )){
					
									scoreSaver.bloodSplatDarkActive = false;
									Timer = 60;
									bloodSpat = false;
								
			}
		}
		
	}

	   void OnTriggerStay2D(Collider2D col)
    {
			//print(ya; 
            if(col.isTrigger){
				
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
					if(col.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Angie Bite"))
					{
						transform.parent.GetComponent<FSMmove>().PullTrigger();
						
					}
					else if(attachedEnemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("attack")){
						if(scoreSaver.health > 0){
                        	scoreSaver.health = scoreSaver.health - damage;
							bloodSpat = true;
						}
						transform.parent.GetComponent<FSMmove>().PlaySound();
					}
					else if(!attachedEnemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("attack")){
						transform.parent.GetComponent<FSMmove>().StopSound();
					}
                }
				
            }      	   
    }
	
}
