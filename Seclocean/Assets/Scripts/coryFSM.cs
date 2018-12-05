using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coryFSM : MonoBehaviour {

	public int speedMultiplier;

	public static float coryHealth;

	private int deathTimer;

	private float initialPos;
	private float changedPos;

	private GameObject Angie;
	public GameObject tracker;

	public GameObject sideSprite;
	public GameObject topSprite;
	public GameObject sideAreaCollider;
	public GameObject topAreaCollider;

	private bool angieNear;

	// Use this for initialization
	void Start () {
		coryHealth = 123.0f;;
		deathTimer = 120;
		angieNear = false;

	}
	
	// Update is called once per frame
	void Update () {
	
		scoreSaver.bossHP = coryHealth;
		Angie = scoreSaver.activeAngie;
		if(Angie.tag == "Player"){
			sideSprite.SetActive(true);
			topSprite.SetActive(false);
			sideAreaCollider.SetActive(true);
			topAreaCollider.SetActive(false);
		}
		else if(Angie.tag =="PlayerTop"){
			sideSprite.SetActive(false);
			topSprite.SetActive(true);
			sideAreaCollider.SetActive(false);
			topAreaCollider.SetActive(true);
		}
		initialPos = transform.position.x;
			if(!angieNear){
				 transform.position =  Vector3.MoveTowards(transform.position, tracker.transform.position , speedMultiplier * Time.deltaTime);
			}
			else{
				if(CoryLevelScript.round1Active){
					transform.Find("Side").GetComponent<Animator>().SetTrigger("attack 1");
					transform.Find("Top").GetComponent<Animator>().SetTrigger("attack 1");
				}
				else if(CoryLevelScript.round2Active){
					float chance = Random.Range(0.0f, 1.0f);

					if(chance < 0.05f){
						transform.Find("Side").GetComponent<Animator>().SetTrigger("attack 1");
						transform.Find("Top").GetComponent<Animator>().SetTrigger("attack 1");
					}
					else if(chance > 0.05f){
						transform.Find("Side").GetComponent<Animator>().SetTrigger("attack 2");
						transform.Find("Top").GetComponent<Animator>().SetTrigger("attack 2");
					}
				}
			}

		changedPos = transform.position.x;

		if(changedPos > initialPos){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(changedPos < initialPos){
            
            transform.localScale = new Vector3(1, 1, 1);
        }

		if(CoryLevelScript.round3Active){
				if(scoreSaver.bossHP <=0){
					if(deathTimer == 240)
					transform.Find("Side").GetComponent<Animator>().SetTrigger("death");
					deathTimer--;
					if(deathTimer <=0){
						//scoreSaver.cleared = true;
					}
			}
		}
	

	}


	  public void PullTrigger(){
        coryHealth = coryHealth - 1.0f;
    }

	

	  void OnTriggerEnter2D(Collider2D col)
    {
            if(col.isTrigger){
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
					angieNear = true;
                   
                }  
            }      	   
    }

	  void OnTriggerExit2D(Collider2D col)
    {
            if(col.isTrigger){
              if ((col.tag == "Player") || (col.tag == "PlayerTop")){
					angieNear = false;
                   
                }  
            }      	   
    }
}
