using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatchetFishFSM : MonoBehaviour {


	
	public int speedMultiplier;
	public float hatchetHealth;
	public bool isBoss;
	public int attackTimer;

	private float min ;
    private float max ;

	private int deathTimer;
	private bool dead;
	private float initialPos;
	private float changedPos;
	private float hatchetInitialHealth;

	
	private int initialTimer;
	private int  nudgeTimer;

	private GameObject Angie;

	public GameObject sideSprite;
	public GameObject topSprite;
	public GameObject sideAreaCollider;
	public GameObject topAreaCollider;

	public GameObject sideHealthbar;
	public GameObject topHealthbar;

	  private float percentHitPoint;

	private bool angieNear;

	   public float add;

	public GameObject swingSound;


	// Use this for initialization
	void Start () {
		if(isBoss)
		{
			hatchetHealth = 123.0f;
			hatchetInitialHealth = hatchetHealth;
		}
		else
		{
			hatchetHealth = 25;
			hatchetInitialHealth = hatchetHealth;
		}

		nudgeTimer = 0;
		if(isBoss)
			scoreSaver.bossHP = hatchetHealth;

		 min = transform.position.x ;
        max = transform.position.x + add;

		deathTimer = 120;
		angieNear = false;
		dead = false;
		initialTimer = attackTimer;
		sideHealthbar.SetActive(false);
			topHealthbar.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		 initialPos = transform.position.x;;
		print(angieNear);
		if(isBoss)	
		hatchetHealth = scoreSaver.bossHP;
		if(!angieNear){
			transform.position = new Vector3(Mathf.PingPong(Time.time * speedMultiplier, max - min) + min, transform.position.y, transform.position.z);
			nudgeTimer = 0;
		}
		percentHitPoint = (hatchetHealth / hatchetInitialHealth * 100) / 100;
		attackTimer--;

		if(hatchetHealth <= hatchetInitialHealth/2){
           		transform.Find("Side").GetComponent<Animator>().SetTrigger("RemoveShield");
				transform.Find("Top").GetComponent<Animator>().SetTrigger("RemoveShield");
        }
		
		
		if(angieNear){
			if(attackTimer <= 0){
				if(!dead){
					transform.Find("Side").GetComponent<Animator>().SetTrigger("Attack");
					PlaySound();
				}
				if(dead){
					Destroy(gameObject);
				}
				attackTimer = initialTimer;
			}

			//transform.position = new Vector3(Mathf.PingPong(Time.time * speedMultiplier * 2, max - min) + min, transform.position.y, transform.position.z);
			transform.position =  Vector3.MoveTowards(transform.position, scoreSaver.activeAngie.transform.position , (speedMultiplier / 2) * Time.deltaTime);

						
		
							
						

				
		}
					
				
				
			
		

		changedPos = transform.position.x;
	      

        if (hatchetHealth <= 0){
            transform.Find("Side").GetComponent<Animator>().SetTrigger("Dead");
            transform.Find("Top").GetComponent<Animator>().SetTrigger("Dead");
            dead = true;
           	attackTimer = 200;
        }

		 if(changedPos > initialPos){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(changedPos < initialPos){
            
            transform.localScale = new Vector3(1, 1, 1);
        }

	}

	public void PlaySound(){
         swingSound.SetActive(true);
    }

    public void StopSound(){
        swingSound.SetActive(false);
    }

	public void PullTrigger(){
		if(isBoss){
			scoreSaver.bossHP--;
		}
		else{
        	hatchetHealth = hatchetHealth - 1.0f;
			sideHealthbar.SetActive(true);
			topHealthbar.SetActive(true);
		}
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
